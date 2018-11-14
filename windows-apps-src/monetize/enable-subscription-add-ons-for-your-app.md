---
author: Xansky
description: Windows.Services.Store 名前空間を使ってサブスクリプション アドオンを実装する方法について説明します。
title: アプリのサブスクリプション アドオンの有効化
keywords: Windows 10, UWP, サブスクリプション, アドオン, アプリ内購入, IAP, Windows.Services.Store
ms.author: mhopkins
ms.date: 12/06/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 971e828f4642a0a9c47994b1c7c0bfdbc5f01ad3
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6251233"
---
# <a name="enable-subscription-add-ons-for-your-app"></a>アプリのサブスクリプション アドオンの有効化

ユニバーサル Windows プラットフォーム (UWP) アプリでは、ユーザーに*サブスクリプション* アドオンのアプリ内購入を提供できます。 サブスクリプションを使用すると、自動の定期的な課金期間を設定してアプリ内でデジタル製品 (アプリの機能やデジタル コンテンツなど) を販売できます。

> [!NOTE]
> アプリ内でサブスクリプション アドオンの購入を有効にするには、Visual Studio でプロジェクトが **Windows 10 Anniversary Edition (10.0、ビルド 14393)** またはそれ以降のリリース (これは、Windows 10 バージョン 1607 に対応) をターゲットにしている必要があります。また、**Windows.ApplicationModel.Store** 名前空間の代わりに、**Windows.Services.Store** 名前空間の API を使用して、アプリ内購入エクスペリエンスを実装している必要があります。 これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。

## <a name="feature-highlights"></a>機能の概要

UWP アプリのサブスクリプション アドオンでは、次の機能をサポートします。

* サブスクリプション期間を 1 か月、3 か月、6 か月、1 年、または 2 年から選択できます。
* サブスクリプションに 1 週間または 1 か月の無料試用期間を追加できます。
* Windows SDK では、アプリで利用可能なサブスクリプション アドオンに関する情報を入手したり、サブスクリプション アドオンを購入できるようにしたりするためにアプリで利用できる [API を提供](#code-examples)しています。 また、サービスから呼び出して[ユーザーのサブスクリプションを管理](#manage-subscriptions)できる REST API も提供しています。
* サブスクリプションの取得数、アクティブなサブスクリプション会員数、および特定の期間中に取り消されたサブスクリプション数を表示する分析レポートを確認できます。
* ユーザーは、自分の Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページでサブスクリプションを管理できます。 ユーザーはこのページを使用して、取得したサブスクリプションすべての表示、サブスクリプションの取り消し、およびサブスクリプションに関連付けられた支払方法の変更ができます。

## <a name="steps-to-enable-a-subscription-add-on-for-your-app"></a>アプリのサブスクリプション アドオンを有効化する手順

アプリでサブスクリプション アドオンを購入できるようにするには、次の手順に従います。

1. パートナー センターで、サブスクリプション[アドオンの申請を作成](../publish/add-on-submissions.md)し、申請を公開します。 アドオンの申請プロセスに従い、次のプロパティをよく確認します。

    * [製品の種類](../publish/set-your-add-on-product-id.md#product-type): **[サブスクリプション]** を選択していることを確認します。

    * [サブスクリプション期間](../publish/enter-add-on-properties.md#subscription-period): サブスクリプションの定期的な課金期間を選択します。 アドオンの公開後にサブスクリプション期間を変更することはできません。

        各サブスクリプション アドオンがサポートするのは、単一のサブスクリプション期間と試用期間だけです。 アプリで提供するサブスクリプションの種類ごとに異なるサブスクリプション アドオンを作成する必要があります。 たとえば、試用期間のない月間サブスクリプション、1 か月の試用期間のある月間サブスクリプション、試用期間のない年間サブスクリプション、1 か月の試用期間のある年間サブスクリプションを提供する場合、サブスクリプション アドオンを 4 つ作成する必要があります。

    * [試用期間](../publish/enter-add-on-properties.md#free-trial): ユーザーがサブスクリプション コンテンツを購入する前に試すことのできる期間を 1 週間にするか、1 か月にするかを選択することを検討します。 サブスクリプション アドオンの公開後に試用期間を変更または削除することはできません。

        サブスクリプションの無料試用版を取得するには、ユーザーは有効な支払方法の設定も含めて標準のアプリ内購入プロセスに従って、サブスクリプションを購入する必要があります。 試用期間中に料金を請求されることはありません。 試用期間の終わりに、サブスクリプションは自動的に完全なサブスクリプションに変わり、有料サブスクリプションの最初の期間の料金がユーザーの支払方法に請求されます。 ユーザーが試用期間中にサブスクリプションを取り消した場合、試用期間が終わるまでサブスクリプションは有効のままです。 一部の試用期間は、すべてのサブスクリプション期間では利用できません。

        > [!NOTE]
        > 各ユーザーは、サブスクリプション アドオンの無料試用版を 1 回だけ取得できます。 ユーザーがサブスクリプションの無料試用版を取得したら、Microsoft Store では、同じユーザーが今後同じ無料試用版のサブスクリプションを取得しないようにします。

    * [可視性](../publish/set-add-on-pricing-and-availability.md#visibility): サブスクリプションのアプリ内購入エクスペリエンスのテストだけに使用するテスト用アドオンを作成している場合は、**[ストアに表示しない]** オプションのいずれかを選択することをお勧めします。 それ以外の場合は、シナリオに最適な可視化オプションを選択します。

    * [価格](../publish/set-add-on-pricing-and-availability.md?#pricing): このセクションでサブスクリプションの価格を選択します。 アドオンの公開後にサブスクリプションの価格を上げることはできません。 ただし、後で価格を下げることはできます。
        > [!IMPORTANT]
        > アドオンの作成時、既定では、最初の価格は **[無料]** に設定されています。 サブスクリプション アドオンの申請の完了後にアドオンの価格を上げることはできないため、ここで必ずサブスクリプションの価格を選択してください。

2. アプリで [**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して、現在のユーザーが既にサブスクリプション アドオンを取得しているかどうかを確認し、そのユーザーにアドオンをアプリ内購入として販売するかどうかを決定します。 詳細については、この記事の[コード サンプル](#code-examples)を参照してください。

3. アプリで、サブスクリプションのアプリ内購入の実装をテストします。 ストアからアプリを開発用デバイスに 1 回ダウンロードして、そのライセンスをテストに使用する必要があります。 詳細については、アプリ内購入の[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。  

4. テストしたコードを含む更新したアプリ パッケージを含めたアプリの申請を作成して公開します。 詳しくは、「[アプリの申請](../publish/app-submissions.md)」をご覧ください。

<span id="code-examples"/>

## <a name="code-examples"></a>コード例

このセクションのコード例では、[**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して現在のアプリのサブスクリプション アドオンに関する情報を取得する方法および現在のユーザーの代わりにサブスクリプション アドオンの購入を要求する方法を説明します。

これらの例には、次の前提条件があります。
* **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* パートナー センター内にある[アプリの申請を作成](https://docs.microsoft.com/windows/uwp/publish/app-submissions)し、このアプリは、ストアで公開します。 必要に応じで、テスト中にストアでアプリを検索できないようにアプリを構成することも可能です。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。
* パートナー センターで[、アプリのサブスクリプション アドオンを作成](../publish/add-on-submissions.md)あります。

これらの例のコードは、次の点を前提としています。
* コード ファイルに **Windows.Services.Store** 名前空間と **System.Threading.Tasks** 名前空間を使うための **using** ステートメントがある。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリである。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

> [!NOTE]
> [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションがある場合、これらの例には示されていないコードを追加して [**StoreContext**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext) オブジェクトを構成することが必要になることがあります。 詳しくは、「[デスクトップ ブリッジを使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

### <a name="purchase-a-subscription-add-on"></a>サブスクリプション アドオンの購入

この例では、現在のユーザーに代わって、アプリの既知のサブスクリプション アドオンの購入を要求する方法を示します。 この例は、サブスクリプションに試用期間がある場合の処理方法も示しています。

1. コードではまず、ユーザーがサブスクリプションのアクティブなライセンスを既に持っているかどうかを確認します。 ユーザーがアクティブなラインセンスを既に持っている場合は、必要に応じてコードでサブスクリプション機能のロックを解除する必要があります (これはアプリに固有の処理なので、例ではコメントで示されています)。
2. 次に、ユーザーに代わって購入するサブスクリプションを表す [**StoreProduct**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct) オブジェクトを取得します。 コードでは、購入するサブスクリプション アドオンの [Store ID](in-app-purchases-and-trials.md#store-ids) が既にわかっていて、その値が *subscriptionStoreId* 変数に割り当てられていると想定しています。
3. コードは次に、サブスクリプションに試用期間があるかどうかを確認します。 アプリでは、必要に応じてこの情報を使って、利用可能な試用版サブスクリプションまたは製品版サブスクリプションの詳細をユーザーに表示することができます。
4. 最後に、コードで [**RequestPurchaseAsync**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.RequestPurchaseAsync) メソッドを呼び出して、サブスクリプションの購入を要求します。 サブスクリプションに試用版がある場合は、試用版がユーザーに提供されます。 それ以外の場合は、製品版のサブスクリプションが購入用に提供されます。

> [!div class="tabbedCodeSnippets"]
[!code-cs[Subscriptions](./code/InAppPurchasesAndLicenses_RS1/cs/PurchaseSubscriptionAddOnTrialPage.xaml.cs#PurchaseTrialSubscription)]

### <a name="get-info-about-subscription-add-ons-for-the-current-app"></a>現在のアプリのサブスクリプション アドオンの情報の取得

このコード例では、アプリで利用可能なすべてのサブスクリプション アドオンの情報を取得する方法を示しています。 この情報を取得するには、まず [**GetAssociatedStoreProductsAsync**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext.GetAssociatedStoreProductsAsync) メソッドを使用して、アプリで利用可能なアドオンそれぞれを表す [**StoreProduct**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct) オブジェクトのコレクションを取得します。 次に、各製品の [**StoreSku**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku) を取得し、[**IsSubscription**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.IsSubscription) プロパティと [**SubscriptionInfo**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.SubscriptionInfo) プロパティを使ってサブスクリプション情報にアクセスします。

> [!div class="tabbedCodeSnippets"]
[!code-cs[Subscriptions](./code/InAppPurchasesAndLicenses_RS1/cs/GetSubscriptionAddOnsPage.xaml.cs#GetSubscriptions)]

<span id="manage-subscriptions" />

## <a name="manage-subscriptions-from-your-services"></a>サービスからのサブスクリプションの管理

更新したアプリがストアで公開され、ユーザーがサブスクリプション アドオンを購入できるようになったら、ユーザーのサブスクリプションの管理が必要になる可能性があります。 サービスから呼び出して次のサブスクリプション管理タスクを実行できる REST API が用意されています。

* [ユーザーが使う権利を持っているサブスクリプションを取得する](get-subscriptions-for-a-user.md)。 サブスクリプションがクロスプラットフォーム サービスの一部である場合は、この API を呼び出して、指定のユーザーにサブスクリプションの権利があるかどうかや、UWP アプリのコンテキストにおけるサブスクリプションの状態を判断することができます。 その後、この情報を使用して、サービスでサポートしている他のプラットフォームにおけるサブスクリプションの状態を更新できます。

* [特定のユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)。 この API を使用して、サブスクリプションの取り消し、延長、または自動更新の無効化を行えます。

## <a name="cancellations"></a>取り消し

ユーザーは、Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページを使って、取得したすべてのサブスクリプションの表示、サブスクリプションの取り消し、サブスクリプションに関連付けられている支払い方法の変更ができます。 ユーザーがこのページを使ってサブスクリプションを取り消した場合でも、現在の請求期間中はサブスクリプションを引き続き利用できます。 現在の請求期間に対する払い戻しは一切行われません。 現在の請求期間の終了時に、サブスクリプションが無効になります。

REST API を使用して、ユーザーの代わりにサブスクリプションを取り消して、[特定のユーザーのサブスクリプションに関する請求の状態を変更](change-the-billing-state-of-a-subscription-for-a-user.md)することもできます。

## <a name="subscription-renewals-and-grace-periods"></a>サブスクリプションの更新と猶予期間

請求期間中のある時点で、ユーザーのクレジット カードに対して次の請求期間分の請求が試みられます。 この請求に失敗すると、ユーザーのサブスクリプションは*催促中*の状態になります。 つまり、現在の請求期間が終わるまでの間、サブスクリプションはアクティブですが、サブスクリプションを自動更新するためにクレジット カードへの請求が定期的に試みられます。 この状態は、現在の請求期間が終了して次の請求期間が更新される日まで、最大で 2 週間続く可能性があります。

サブスクリプションの請求に対する猶予期間は用意されていません。 現在の請求期間が終了するまでにユーザーのクレジット カードに請求できなかった場合、サブスクリプションは取り消され、現在の請求期間後にユーザーがサブスクリプションにアクセスすることはできなくなります。

## <a name="unsupported-scenarios"></a>サポートされていないシナリオ

次のシナリオは、サブスクリプション アドオンで現在サポートされていません。

* 現時点では、ストアを通じたユーザーへのサブスクリプションの直接販売はサポートされていません。 サブスクリプションはデジタル製品のアプリ内購入でのみ利用可能です。
* ユーザーが Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページを使ってサブスクリプション期間を切り替えることはできません。 切り替える別のサブスクリプション期間中に、顧客が現在サブスクリプションを取り消すし、アプリから別のサブスクリプション期間のサブスクリプションを購入する必要があります。
* サブスクリプション アドオンでは現在、サブスクリプション レベルの切り替えはサポートされていません (たとえば、ユーザーをベーシック サブスクリプションから機能の多いプレミアム サブスクリプションに切り替えるなど)。
* サブスクリプション アドオンでは現在、[セール](../publish/put-apps-and-add-ons-on-sale.md)と[プロモーション コード](../publish/generate-promotional-codes.md)はサポートされていません。


## <a name="related-topics"></a>関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
