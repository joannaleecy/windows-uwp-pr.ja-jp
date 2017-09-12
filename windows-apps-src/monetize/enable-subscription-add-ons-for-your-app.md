---
author: mcleanbyron
description: "Windows.Services.Store 名前空間を使ってサブスクリプション アドオンを実装する方法について説明します。"
title: "アプリのサブスクリプション アドオンの有効化"
keywords: "Windows 10, UWP, サブスクリプション, アドオン, アプリ内購入, IAP, Windows.Services.Store"
ms.author: mcleans
ms.date: 08/01/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 16e2e8d160ad2236220dc6f19f578bbaa82c9dc0
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="enable-subscription-add-ons-for-your-app"></a>アプリのサブスクリプション アドオンの有効化

> [!IMPORTANT]
> 現在、サブスクリプション アドオンを作成できるのは、早期導入プログラムに参加している開発者アカウントに限られます。 いずれは、すべての開発者アカウントでサブスクリプション アドオンをご利用いただけます。現時点でこの正式リリース前のドキュメントを公開しているのは、この機能がどのようなものかを開発者の皆様に簡単に紹介することが目的です。

UWP アプリが Windows 10 バージョン 1607 以降を対象としている場合、ユーザーに*サブスクリプション* アドオンのアプリ内購入を提供できます。 サブスクリプションを使用すると、自動の定期的な課金期間を設定してアプリ内でデジタル製品 (アプリの機能やデジタル コンテンツなど) を販売できます。

## <a name="feature-highlights"></a>機能の概要

UWP アプリのサブスクリプション アドオンでは、次の機能をサポートします。

* サブスクリプション期間を 1 か月、3 か月、6 か月、1 年、または 2 年から選択できます。 一部のアプリでは、テスト目的専用の 6 時間のサブスクリプションを使用できます。
* サブスクリプションに 1 週間または 1 か月の無料試用期間を追加できます。
* Windows SDK では、アプリで利用可能なサブスクリプション アドオンに関する情報を入手したり、サブスクリプション アドオンを購入できるようにしたりするためにアプリで利用できる [API を提供](#code-examples)しています。 また、サービスから呼び出して[ユーザーのサブスクリプションを管理](#manage-subscriptions)できる REST API も提供しています。
* サブスクリプションの取得数、アクティブなサブスクリプション会員数、および特定の期間中に取り消されたサブスクリプション数を表示する分析レポートを確認できます。
* ユーザーは自分の Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページでサブスクリプションを管理できます。 ユーザーはこのページを使用して、取得したサブスクリプションすべての表示、サブスクリプションの取り消し、およびサブスクリプションに関連付けられた支払方法の変更ができます。

> [!NOTE]
> アプリでサブスクリプション アドオンの購入ができるようにするには、アプリは Windows 10 バージョン 1607 以降を対象とし、**Windows.ApplicationModel.Store** 名前空間ではなく、**Windows.Services.Store** 名前空間の API を使用して、アプリ内購入エクスペリエンスを実装する必要があります。 これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。

## <a name="steps-to-enable-a-subscription-add-on-for-your-app"></a>アプリのサブスクリプション アドオンを有効化する手順

アプリでサブスクリプション アドオンを購入できるようにするには、次の手順に従います。

1. デベロッパー センター ダッシュボードでサブスクリプションの[アドオンの申請を作成](../publish/add-on-submissions.md)し、申請を公開します。 アドオンの申請プロセスに従い、次のプロパティをよく確認します。

  * [製品の種類](../publish/set-your-add-on-product-id.md#product-type): **[サブスクリプション]**を選択していることを確認します。

  * [サブスクリプション期間](../publish/enter-add-on-properties.md#subscription-period): サブスクリプションの定期的な課金期間を選択します。 アドオンの公開後にサブスクリプション期間を変更することはできません。

    各サブスクリプション アドオンがサポートするのは、単一のサブスクリプション期間と試用期間だけです。 アプリで提供するサブスクリプションの種類ごとに異なるサブスクリプション アドオンを作成する必要があります。 たとえば、試用期間のない月間サブスクリプション、1 か月の試用期間のある月間サブスクリプション、試用期間のない年間サブスクリプション、1 か月の試用期間のある年間サブスクリプションを提供する場合、サブスクリプション アドオンを 4 つ作成する必要があります。
        > [!NOTE]
        > If you are in the process of implementing the in-app purchase experience for your subscription, we recommend that you create a test add-on with the **For testing only – 6 hours** subscription period to help you test the experience. You can choose this test period only if you select one of the **Hidden in the Store** [visibility options](../publish/set-add-on-pricing-and-availability.md#visibility) for your test add-on.

  * [試用期間](../publish/enter-add-on-properties.md#free-trial): ユーザーがサブスクリプション コンテンツを購入する前に試すことのできる期間を 1 週間にするか、1 か月にするかを選択することを検討します。 サブスクリプション アドオンの公開後に試用期間を変更または削除することはできません。

    サブスクリプションの無料試用版を取得するには、ユーザーは有効な支払方法の設定も含めて標準のアプリ内購入プロセスに従って、サブスクリプションを購入する必要があります。 試用期間中に料金を請求されることはありません。 試用期間の終わりに、サブスクリプションは自動的に完全なサブスクリプションに変わり、有料サブスクリプションの最初の期間の料金がユーザーの支払方法に請求されます。 ユーザーが試用期間中にサブスクリプションを取り消した場合、試用期間が終わるまでサブスクリプションは有効のままです。
        > [!NOTE]
        > Some trial durations are not available for all subscription periods.

  * [可視性](../publish/set-add-on-pricing-and-availability.md#visibility): サブスクリプションのアプリ内購入エクスペリエンスのテストだけに使用するテスト用アドオンを作成している場合は、**[ストアに表示しない]** オプションのいずれかを選択することをお勧めします。 それ以外の場合は、シナリオに最適な可視化オプションを選択します。

  * [価格](../publish/set-add-on-pricing-and-availability.md?#pricing): このセクションでサブスクリプションの価格を選択します。 アドオンの公開後にサブスクリプションの価格を上げることはできません (ただし、後で価格を下げることはできます)。
      > [!IMPORTANT]
      > アドオンの作成時、既定では、価格は最初 **[無料]** に設定されています。 サブスクリプション アドオンの申請の完了後にアドオンの価格を上げることはできないため、ここで必ずサブスクリプションの価格を選択してください。

2. アプリで、[**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して、現在のユーザーが既にサブスクリプション アドオンを取得していて、そのユーザーにアドオンをアプリ内購入として販売するかどうかを確認します。 詳細については、この記事の[コード サンプル](#code-examples)を参照してください。

3. アプリで、サブスクリプションのアプリ内購入の実装をテストします。 ストアからアプリを開発用デバイスに 1 回ダウンロードして、そのライセンスをテストに使用する必要があります。 詳細については、アプリ内購入の[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。  
    > [!NOTE]
    > アプリで、**テスト専用 (6 時間)** のサブスクリプション期間を利用できる場合、この期間を設定したテスト用アドオンを作成して、エクスペリエンスのテストに役立てることをお勧めします。 このテスト期間は、テスト用アドオンに **[ストアに表示しない]** [可視性オプション](../publish/set-add-on-pricing-and-availability.md#visibility)のいずれかを選択した場合にのみ選択できます。

4. テストしたコードを含む更新したアプリ パッケージを含めたアプリの申請を作成して公開します。 詳しくは、「[アプリの申請](../publish/app-submissions.md)」をご覧ください。

<span id="code-examples"/>
## <a name="code-examples"></a>コード例

このセクションのコード例では、[**Windows.Services.Store**](https://docs.microsoft.com/uwp/api/windows.services.store) 名前空間の API を使用して現在のアプリのサブスクリプション アドオンに関する情報を取得する方法および現在のユーザーの代わりにサブスクリプション アドオンの購入を要求する方法を説明します。

これらの例には、次の前提条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュボードで[アプリの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)し、このアプリがストアで公開されている。 必要に応じで、テスト中にストアでアプリを検索できないようにアプリを構成することも可能です。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。
* デベロッパー センター ダッシュボードで[アプリのサブスクリプション アドオンを作成](../publish/add-on-submissions.md)した。

これらの例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [**ProgressRing**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [**Page**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

> [!NOTE]
> [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションがある場合、これらの例には示されていないコードを追加して [**StoreContext**](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[デスクトップ ブリッジを使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

### <a name="get-info-about-subscription-add-ons-for-the-current-app"></a>現在のアプリのサブスクリプション アドオンの情報の取得

このコード例では、アプリで利用可能なサブスクリプション アドオンの情報を取得する方法を示しています。 この情報を取得するには、まず [**GetAssociatedStoreProductsAsync**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext#Windows_Services_Store_StoreContext_GetAssociatedStoreProductsAsync_) メソッドを使用して、アプリで利用可能なアドオンそれぞれを表す [**StoreProduct**](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct) オブジェクトのコレクションを取得します。 次に、各製品の [**StoreSku**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku) を取得し、[**IsSubscription**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku#Windows_Services_Store_StoreSku_IsSubscription_) プロパティと [**SubscriptionInfo**](https://docs.microsoft.com/uwp/api/windows.services.store.storesku#Windows_Services_Store_StoreSku_SubscriptionInfo_) プロパティを使用してサブスクリプション情報にアクセスします。

> [!div class="tabbedCodeSnippets"]
[!code-cs[サブスクリプション](./code/InAppPurchasesAndLicenses_RS1/cs/GetSubscriptionAddOnsPage.xaml.cs#GetSubscriptions)]

### <a name="purchase-a-subscription-add-on"></a>サブスクリプション アドオンの購入

この例では、[**StoreProduct**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct) クラスの [**RequestPurchaseAsync**](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct#Windows_Services_Store_StoreProduct_RequestPurchaseAsync_) メソッドを使用して、サブスクリプション アドオンを購入する方法を示しています。 この例では、購入するサブスクリプション アドオンの[ストア ID](in-app-purchases-and-trials.md#store-ids) を既に知っていることを前提とします。

> [!div class="tabbedCodeSnippets"]
[!code-cs[サブスクリプション](./code/InAppPurchasesAndLicenses_RS1/cs/PurchaseSubscriptionAddOnPage.xaml.cs#PurchaseSubscription)]

<span id="manage-subscriptions" />
## <a name="manage-subscriptions-from-your-services"></a>サービスからのサブスクリプションの管理

更新したアプリがストアで公開され、ユーザーがサブスクリプション アドオンを購入できるようになったら、ユーザーのサブスクリプションの管理が必要になる可能性があります。 サービスから呼び出して次のサブスクリプション管理タスクを実行できる REST API が用意されています。

* [ユーザーが使う権利を持っているサブスクリプションを取得する](get-subscriptions-for-a-user.md)。 サブスクリプションがクロスプラットフォーム サービスの一部である場合は、この API を呼び出して、指定のユーザーにサブスクリプションの権利があるかどうかや、UWP アプリのコンテキストにおけるサブスクリプションの状態を判断することができます。 その後、この情報を使用して、サービスでサポートしている他のプラットフォームにおけるサブスクリプションの状態を更新できます。

* [特定のユーザーのサブスクリプションに関する請求の状態を変更する](change-the-billing-state-of-a-subscription-for-a-user.md)。 この API を使用して、サブスクリプションの取り消し、延長、または自動更新の無効化を行えます。

<span id="cancellations" />
## <a name="cancellations"></a>取り消し

ユーザーは自分の Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページを使用して、取得したサブスクリプションすべての表示、サブスクリプションの取り消し、およびサブスクリプションに関連付けられた支払方法の変更ができます。 ユーザーがこのページを使用してサブスクリプションを取り消した場合、現在の請求サイクルの期間中はサブスクリプションを引き続き利用できます。 現在の請求サイクルのどのようなタイミングにおいても、払い戻しは行われません。 現在の請求サイクルの最後に、サブスクリプションが無効になります。

REST API を使用して、ユーザーの代わりにサブスクリプションを取り消して、[特定のユーザーのサブスクリプションに関する請求の状態を変更](change-the-billing-state-of-a-subscription-for-a-user.md)することもできます。

## <a name="unsupported-scenarios"></a>サポートされていないシナリオ

次のシナリオは、サブスクリプション アドオンで現在サポートされていません。

* 現時点では、ストアを通じたユーザーへのサブスクリプションの直接販売はサポートされていません。 サブスクリプションはデジタル製品のアプリ内購入でのみ利用可能です。
* ユーザーが自分の Microsoft アカウントの [http://account.microsoft.com/services](http://account.microsoft.com/services) ページを使用してサブスクリプション期間を切り替えることはできません。 異なるサブスクリプション期間に切り替えるには、ユーザーは現在のサブスクリプションを取り消して、アプリで別のサブスクリプション期間のサブスクリプションを購入する必要があります。
* サブスクリプション アドオンでは現在、サブスクリプション レベルの切り替えはサポートされていません (たとえば、ユーザーをベーシック サブスクリプションから機能の多いプレミアム サブスクリプションに切り替えるなど)。
* サブスクリプション アドオンでは現在、[セール](../publish/put-apps-and-add-ons-on-sale.md)と[プロモーション コード](../publish/generate-promotional-codes.md)はサポートされていません。


## <a name="related-topics"></a>関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
