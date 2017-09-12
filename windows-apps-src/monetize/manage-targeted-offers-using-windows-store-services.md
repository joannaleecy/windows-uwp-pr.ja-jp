---
author: mcleanbyron
ms.assetid: 9F0A59A1-FAD7-4AD5-B78B-C1280F215D23
description: "アプリで使用可能なターゲット オファーを要求するには、Windows ストア ターゲット オファー API を使います。"
title: "ストア サービスを使ってターゲット オファーを管理する"
ms.author: mcleans
ms.date: 05/11/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ストア サービス, Windows ストア ターゲット オファー API, ターゲット オファー"
ms.openlocfilehash: 684c37d4439f415ad607b7f3e6a166966cc9f835
ms.sourcegitcommit: eaacc472317eef343b764d17e57ef24389dd1cc3
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/17/2017
---
# <a name="manage-targeted-offers-using-store-services"></a>ストア サービスを使ってターゲット オファーを管理する

Windows デベロッパー センター ダッシュボードの **[関心を引く] > [ターゲット オファー]** ページで*ターゲット オファー*を作成した場合、アプリのコードで *Windows ストア ターゲット オファー API* を使ってターゲット オファーのアプリ内エクスペリエンスを実装します。 ターゲット オファーについてとダッシュボードで作成する方法について詳しくは、「[ターゲット オファーによるエンゲージメントとコンバージョンの最大化](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)」をご覧ください。

ターゲット オファー API は、以下のタスクの実行に使用できる REST API です。

* ユーザーがターゲット オファーの顧客セグメントの一部であるかどうか基づいて、現在のユーザーが利用可能なターゲット オファーを取得する。
* ユーザーがターゲット オファーを購入した場合、ターゲット オファーに関連付けられているボーナスを受け取ることができるようにストアに要求を提出できます。 これは、コンバージョンが成功するたびにボーナスが開発者に支払われる Microsoft 提供のプロモーションにターゲット オファーが関連付けられている場合のみ必要です。

アプリのコードでこの API を使うには、次の手順に従います。

1.  アプリの現在のサインインしているユーザーの [Microsoft アカウント トークンを取得します](#obtain-a-microsoft-account-token)。
2.  [現在のユーザーのターゲット オファーを取得します](#get-targeted-offers)。
3.  [ターゲット オファーに関連付けられているアドオンを購入します](#purchase-add-on)。
3.  [ターゲット オファーを要求します](#claim-targeted-offer) (コンバージョンが成功するたびにボーナスが開発者に支払われる Microsoft 提供プロモーションにターゲット オファーが関連付けられている場合)。

> [!NOTE]
> 現在のところ、すべての開発者アカウントで Microsoft 提供プロモーションにターゲット オファーを関連付け、オファーの要求を提出できるわけではありません。

上記のすべての手順を示す完全なコード例については、この記事の最後にある[コード例](#code-example)をご覧ください。 以降のセクションでは、各手順についてさらに詳しく説明します。

<span id="obtain-a-microsoft-account-token" />
## <a name="get-a-microsoft-account-token-for-the-current-user"></a>現在のユーザーの Microsoft アカウント トークンを取得する

アプリのコードで、現在サインインしているユーザーの Microsoft アカウント (MSA) トークンを取得します。 Windows ストア ターゲット オファー API では、各メソッドの ```Authorization``` 要求ヘッダーでこのトークンを渡す必要があります。 このトークンは、現在のユーザーが利用できるターゲット オファーを取得するためにストアにより使用されます。

MSA トークンを取得するには、[WebAuthenticationCoreManager](https://docs.microsoft.com/uwp/api/windows.security.authentication.web.core.webauthenticationcoremanager) クラスを使い、スコープ ```devcenter_implicit.basic,wl.basic``` を設定してトークンを要求します。 次の例は、この処理を実行する方法を示しています。 この例は、[完全な例](#code-example)からの抜粋です。また、完全な例で提供されている **using** ステートメントが必要です。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetMSAToken)]

MSA トークンの取得について詳しくは、「[Web アカウント マネージャー](../security/web-account-manager.md)」をご覧ください。

<span id="get-targeted-offers" />
## <a name="get-the-targeted-offers-for-the-current-user"></a>現在のユーザーのターゲット オファーを取得する

現在のユーザーの MSA トークンがある場合、```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI の GET メソッドを呼び出して、現在のユーザーの利用可能なターゲット オファーを取得します。 この REST メソッドについて詳しくは、「[ターゲット オファーを取得する](get-targeted-offers.md)」をご覧ください。

このメソッドは、現在のユーザーが利用可能なターゲット オファーに関連付けられているアドオンの製品 ID を返します。 この情報を使って、1 つ以上のターゲット オファーをアプリ内での購入としてユーザーに提供できます。 このメソッドは、ストアへの[要求の提出](#claim-targeted-offer)に使うことができる追跡 ID も返すため、ターゲット オファーに関連付けられているボーナスを受け取ることができます。

次の例は、現在のユーザーのターゲット オファーを取得する方法を示しています。 この例は、[完全な例](#code-example)からの抜粋です。 また、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリ、および完全な例で提供されている追加クラスと **using** ステートメントが必要です。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffers)]

<span id="purchase-add-on" />
## <a name="purchase-the-add-on-that-is-associated-with-a-targeted-offer"></a>ターゲット オファーに関連付けられているアドオンを購入する

次に、購入用のターゲット オファーのいずれかをユーザーに提供します。 ユーザーがターゲット オファーの購入に同意した場合、次のいずれかの方法を使って、ターゲット オファーに関連付けられているアドオンをプログラムにより購入します。 前の手順で取得した製品 ID 値を使って、購入するアドオンを特定します。

* アプリが Windows 10 バージョン 1607 以降をターゲットとする場合は、[Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間で **RequestPurchaseAsync** メソッドのいずれかを使うことをお勧めします。 これらのメソッドの使い方について詳しくは、「[アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)」をご覧ください。

* アプリが Windows 10 より前のバージョンをターゲットとしている場合、[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間で [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp#Windows_ApplicationModel_Store_CurrentApp_RequestProductPurchaseAsync_System_String_) メソッドを使ってアドオンを購入します。 このメソッドの使い方について詳しくは、「[アプリ内製品購入の有効化](enable-in-app-product-purchases.md)」をご覧ください。

各オプションを示すコード例については、この記事の最後にある[コード例](#code-example)をご覧ください。

> [!NOTE]
> UWP アプリでのアプリ内購入を実装するため、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) (Windows 10 バージョン 1607 で導入) と [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) (すべてのバージョンの Windows 10 で利用可能) の 2 つの異なる名前空間が用意されています。 これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。

<span id="claim-targeted-offer" />
## <a name="submit-a-claim-for-a-targeted-offer"></a>ターゲット オファーの要求を提出する

コンバージョンが成功するたびにボーナスが開発者に支払われる Microsoft 提供プロモーションに関連付けられているターゲット オファーをユーザーが購入した場合、ボーナスを受け取ることができるようにストアに要求を提出する必要があります。 要求を提出するときに、購入の確認を表す値を指定する必要があります。 この購入の確認を取得する方法は、アドオンを購入する際に、アプリで **Windows.ApplicationModel.Store** 名前空間と **Windows.Services.Store** 名前空間のどちらの API を使うかによって異なります。

> [!NOTE]
> 現在のところ、すべての開発者アカウントで Microsoft 提供プロモーションにターゲット オファーを関連付け、オファーの要求を提出できるわけではありません。

### <a name="apps-that-use-the-windowsapplicationmodelstore-namespace"></a>Windows.ApplicationModel.Store 名前空間を使うアプリ

1. **Windows.ApplicationModel.Store** 名前空間で [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store.CurrentApp#Windows_ApplicationModel_Store_CurrentApp_RequestProductPurchaseAsync_System_String_) メソッドを使ってアドオンを購入した後は、必ず[購入領収書](use-receipts-to-verify-product-purchases.md)を受け取ってください。 この領収書は、**RequestProductPurchaseAsync** メソッドにより返される [PurchaseResults.ReceiptXml](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.purchaseresults#Windows_ApplicationModel_Store_PurchaseResults_ReceiptXml_) オブジェクトで利用可能です。 この領収書は、次の手順で使う購入の確認を表します。

2. POST メッセージを ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI に送信し、ターゲット オファーのコンバージョン要求を提出します。 この REST メソッドについて詳しくは、「[ターゲット オファーを要求する](claim-a-targeted-offer.md)」をご覧ください。 要求の本文で、次のデータを渡します。

  * *storeOffer* フィールド: 「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法の応答本文で受け取った JSON オブジェクトのいずれかを渡します (このオブジェクトには *offers* フィールドと *trackingId* フィールドを含める必要があります)。

  * *receipt* フィールド: 前の手順で取得した領収書の文字列を渡します (これは **RequestProductPurchaseAsync** メソッドにより返される **PurchaseResults.ReceiptXml** オブジェクトで利用可能です)。

次の例は、**Windows.ApplicationModel.Store** 名前空間の API を使ってターゲット オファーを購入し要求する方法を示しています。 この例は、[完全な例](#code-example)からの抜粋です。 また、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリ、および完全な例で提供されている追加クラスと **using** ステートメントが必要です。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#ClaimOfferOnAnyVersionWindows10)]

### <a name="apps-that-use-the-windowsservicesstore-namespace"></a>Windows.Services.Store 名前空間を使うアプリ

1. [Windows.Services.Store](https://docs.microsoft.com/uwp/api/Windows.ApplicationModel.Store) 名前空間で **RequestPurchaseAsync** メソッドのいずれかを使ってアドオンを購入したら、次の手順に従って購入の*注文 ID* を取得します。 この値は、購入の確認を表します。

  1. [GetUserCollectionAsync](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext#Windows_Services_Store_StoreContext_GetUserCollectionAsync_Windows_Foundation_Collections_IIterable_System_String__) メソッドを呼び出して、ユーザーが取得したアドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを取得します。

  2. このコレクションで、ターゲット オファー用に購入されたアドオンを表す **StoreProduct** オブジェクトを取得します。

  3. この **StoreProduct** オブジェクトの [ExtendedJsonData](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct#Windows_Services_Store_StoreProduct_ExtendedJsonData_) プロパティの値を取得します。 このプロパティは、アドオンのストアに関連する完全なデータを含む JSON 形式の文字列を返します。

  4. この JSON 文字列を解析し、文字列に含まれている *orderId* フィールドの値を取得します。

2. POST メッセージを ```https://manage.devcenter.microsoft.com/v2.0/my/storeoffers/user``` URI に送信し、ターゲット オファーのコンバージョン要求を提出します。 この REST メソッドについて詳しくは、「[ターゲット オファーを要求する](claim-a-targeted-offer.md)」をご覧ください。 要求の本文で、次のオブジェクトを渡します。

  * *storeOffer* フィールド: 「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法の応答本文で受け取った JSON オブジェクトのいずれかを渡します (このオブジェクトには *offers* フィールドと *trackingId* フィールドを含める必要があります)。

  * *receipt* フィールド: 前の手順で取得した *orderId* 値を渡します。

次の例は、**Windows.Services.Store** 名前空間の API を使ってターゲット オファーを購入し要求する方法を示しています。 この例は、[完全な例](#code-example)からの抜粋です。 また、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリ、および完全な例で提供されている追加クラスと **using** ステートメントが必要です。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#ClaimOfferOnWindows1607AndLater)]

<span id="code-example" />
## <a name="complete-code-example"></a>完全なコード例

次のコード例は、次のタスクを示しています。

* 現在のユーザーの MSA トークンを取得する。
* 「[ターゲット オファーを取得する](get-targeted-offers.md)」の方法を使って、現在のユーザーのすべてのターゲット オファーを取得する。
* ターゲット オファーに関連付けられているアドオンを購入する。
* 「[ターゲット オファーを要求する](claim-a-targeted-offer.md)」の方法を使うことで、ターゲット オファーを要求する。

この例では、Newtonsoft の [Json.NET](http://www.newtonsoft.com/json) ライブラリが必要です。 この例では、このライブラリを使って JSON 形式のデータをシリアル化および逆シリアル化します。

> [!NOTE]
> UWP アプリでのアプリ内購入を実装するため、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) (Windows 10 バージョン 1607 で導入) と [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) (すべてのバージョンの Windows 10 で利用可能) の 2 つの異なる名前空間が用意されています。 この例では、[バージョン アダプティブ コード](../debug-test-perf/version-adaptive-code.md)を使うことで、同じアプリでそれら両方の名前空間を使って、アドオンを購入しターゲット オファーの要求を提出します。 このコードを使うには、プロジェクトのターゲット OS のバージョンが、**Windows 10 Anniversary Edition (10.0、ビルド 14394)** 以降である必要があります。ただし、以前のバージョンの Windows 10 でアプリを実行する場合は、最小 OS バージョンを以前のバージョンにすることができます。 これらの名前空間の違いについて詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。

[!code-cs[TargetedOffers](./code/StoreServicesExamples_TargetedOffers/cs/TargetedOffers.cs#GetTargetedOffersSample)]

## <a name="related-topics"></a>関連トピック

* [ターゲット オファーによるエンゲージメントとコンバージョンの最大化](../publish/use-targeted-offers-to-maximize-engagement-and-conversions.md)
* [ターゲット オファーを取得する](get-targeted-offers.md)
* [ターゲット オファーを要求する](claim-a-targeted-offer.md)
