---
author: mcleanbyron
ms.assetid: 89178FD9-850B-462F-9016-1AD86D1F6F7F
description: "Windows.Services.Store 名前空間を使って、現在のアプリまたはそのアドオンのストアに関連する製品情報を取得する方法について説明します。"
title: "アプリとアドオンの製品情報の取得"
translationtype: Human Translation
ms.sourcegitcommit: ffda100344b1264c18b93f096d8061570dd8edee
ms.openlocfilehash: dd58103d22314081985cd5ce0f98f2f25e1e7287

---

# <a name="get-product-info-for-apps-and-add-ons"></a>アプリとアドオンの製品情報の取得

Windows 10 バージョン 1607以降をターゲットとするアプリは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間で [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスのメソッドを使って、現在のアプリとそのアドオン (アプリ内製品または IAP とも呼ばれます) のストアに関連する情報にアクセスできます。 この記事の例では、さまざまなシナリオでこれを行う方法を説明します。 完全なアプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

>**注**&nbsp;&nbsp;この記事は、Windows 10 バージョン 1607 以降をターゲットとするアプリに適用されます。 アプリが Windows 10 の以前のバージョンをターゲットする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

## <a name="prerequisites"></a>前提条件

これらの例には、次の前提条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュ ボードでアプリを作成し、このアプリが公開されてストアで入手可能になっている。 これは、ユーザーにリリースするアプリでも、[Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最小要件を満たす、テスト目的でのみ使う基本的なアプリでもかまいません。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。

これらの例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

>**注:**&nbsp;&nbsp;[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使うデスクトップ アプリケーションがある場合、これらの例には示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[Desktop Bridge を使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## <a name="get-info-for-the-current-app"></a>現在のアプリの情報の取得

現在のアプリに関するストア製品情報を取得するには、[GetStoreProductForCurrentAppAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getstoreproductforcurrentappasync.aspx) メソッドを使います。 これは、価格などの情報の取得に使うことができる [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトを返す非同期メソッドです。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetAppInfoPage.xaml.cs#GetAppInfo)]

## <a name="get-info-for-products-with-known-store-ids"></a>既知のストア ID による製品の情報の取得

既に[ストア ID](in-app-purchases-and-trials.md#store_ids) を知っているアプリまたはアドオンのストア製品情報を取得するには、[GetStoreProductsAsync](https://msdn.microsoft.com/library/windows/apps/mt706579.aspx) メソッドを使います。 これは、各アプリまたはアドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 ストア ID に加えて、アドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については[ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) プロパティをご覧ください。

次の例では、指定されたストア ID を持つ永続的なアドオンの情報を取得します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetProductInfoPage.xaml.cs#GetProductInfo)]

## <a name="get-info-for-add-ons-that-are-available-for-the-current-app"></a>現在のアプリで利用可能なアドオンの情報の取得

現在のアプリで利用可能なアドオンのストア製品情報を取得するには、[GetAssociatedStoreProductsAsync](https://msdn.microsoft.com/library/windows/apps/mt706571.aspx) メソッドを使います。 これは、利用可能な各アドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 取得するアドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については [ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) プロパティをご覧ください。

>**注**&nbsp;&nbsp;アプリのアドオンが多くある場合、代わりに [GetAssociatedStoreProductsWithPagingAsync](https://msdn.microsoft.com/library/windows/apps/mt706572.aspx) メソッドを使ってページングを使い、アドオン結果を返すこともできます。

次の例では、すべての永続的なアドオン、ストアで管理されるコンシューマブルなアドオン、開発者により管理されるコンシューマブルなアドオンの情報を取得します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetAddOnInfoPage.xaml.cs#GetAddOnInfo)]


## <a name="get-info-for-add-ons-for-the-current-app-that-the-current-user-is-entitled-to-use"></a>現在のユーザーが使う権利を持つ現在のアプリのアドオンの情報を取得します。

現在のユーザーが使う権利を持つアドオンのストア製品情報を取得するには、[GetUserCollectionAsync](https://msdn.microsoft.com/library/windows/apps/mt706580.aspx) メソッドを使います。 これは、各アドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 取得するアドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については [ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) プロパティをご覧ください。

>**注**&nbsp;&nbsp;アプリのアドオンが多くある場合、代わりに [GetUserCollectionWithPagingAsync](https://msdn.microsoft.com/library/windows/apps/mt706581.aspx) メソッドを使ってページングを使い、アドオン結果を返すこともできます。

次の例では、指定されたストア ID を持つ永続的なアドオンの情報を取得します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetUserCollectionPage.xaml.cs#GetUserCollection)]

## <a name="related-topics"></a>関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)



<!--HONumber=Dec16_HO1-->


