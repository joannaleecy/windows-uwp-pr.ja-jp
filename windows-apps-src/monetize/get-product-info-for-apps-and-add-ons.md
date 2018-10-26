---
author: Xansky
ms.assetid: 89178FD9-850B-462F-9016-1AD86D1F6F7F
description: Windows.Services.Store 名前空間を使って、現在のアプリまたはそのアドオンのストアに関連する製品情報を取得する方法について説明します。
title: アプリとアドオンの製品情報の取得
ms.author: mhopkins
ms.date: 02/08/2018
ms.topic: article
keywords: Windows 10, UWP, アプリ内購入, IAP, アドオン, Windows.Services.Store
ms.localizationpriority: medium
ms.openlocfilehash: e8f82bc3045d56f93e8d42ea183e2ac2bc788380
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5665141"
---
# <a name="get-product-info-for-apps-and-add-ons"></a>アプリとアドオンの製品情報の取得

この記事では、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスのメソッドを使って、現在のアプリとそのアドオンの Microsoft Store に関連する情報を取得する方法について説明します。

完全なサンプル アプリケーションについては、[Store サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

> [!NOTE]
> **Windows.Services.Store** 名前空間は、Windows 10 バージョン 1607 で導入され、Visual Studio で、**Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするプロジェクトでのみ使用できます。 アプリが Windows 10 の以前のバージョンをターゲットとする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、[この記事](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)をご覧ください。

## <a name="prerequisites"></a>前提条件

これらの例には、次の前提条件があります。
* **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降のリリースをターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュボードで[アプリの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)し、このアプリが Microsoft Store で公開されている。 必要に応じで、テスト中にストアでアプリを検索できないようにアプリを構成することも可能です。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。
* アプリのアドオンの製品情報を取得する場合、[デベロッパー センター ダッシュボードでアドオンを作成](../publish/add-on-submissions.md)する必要もあります。

これらの例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

> [!NOTE]
> [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションがある場合、これらの例には示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[デスクトップ ブリッジを使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## <a name="get-info-for-the-current-app"></a>現在のアプリの情報の取得

現在のアプリに関するストア製品情報を取得するには、[GetStoreProductForCurrentAppAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getstoreproductforcurrentappasync) メソッドを使います。 これは、価格などの情報の取得に使うことができる [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトを返す非同期メソッドです。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetAppInfoPage.xaml.cs#GetAppInfo)]

## <a name="get-info-for-add-ons-with-known-store-ids-that-are-associated-with-the-current-app"></a>現在のアプリに関連付けられている既知の Store ID を持つアドオンの情報の取得

現在のアプリに関連付けられていて、既に [Store ID](in-app-purchases-and-trials.md#store_ids) がわかっているアドオンの Store 製品情報を取得するには、[GetStoreProductsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getstoreproductsasync) メソッドを使います。 これは、各アドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 このメソッドには、Store ID に加えて、アドオンの種類を識別する文字列のリストを渡す必要があります。 サポートされている文字列値の一覧については [ProductKind](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.productkind) プロパティをご覧ください。

> [!NOTE]
> **GetStoreProductsAsync** メソッドは、アドオンが現在購入可能かどうかにかかわらず、アプリに関連付けられている指定のアドオンの製品情報を返します。 現在のアプリで現在購入可能なすべてのアドオンの情報を取得するには、代わりに[次のセクション](#get-info-for-add-ons-that-are-available-for-purchase-from-the-current-app)で説明する **GetAssociatedStoreProductsAsync** メソッドを使います。

次の例では、現在のアプリに関連付けられていて、指定された Store ID を持つ永続的なアドオンの情報を取得します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetProductInfoPage.xaml.cs#GetProductInfo)]

## <a name="get-info-for-add-ons-that-are-available-for-purchase-from-the-current-app"></a>現在のアプリから購入可能なアドオンの情報の取得

現在のアプリから現在購入可能なアドオンの Store 製品情報を取得するには、[GetAssociatedStoreProductsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getassociatedstoreproductsasync) メソッドを使います。 これは、利用可能な各アドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 取得するアドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については [ProductKind](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.productkind) プロパティをご覧ください。

> [!NOTE]
> アプリから購入可能なアドオンの数が多い場合は、代わりに [GetAssociatedStoreProductsWithPagingAsync](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreContext.GetAssociatedStoreProductsWithPagingAsync) メソッドを使って、ページングを利用してアドオンの結果を返すこともできます。

次の例では、現在のアプリから購入できる、すべての永続的なアドオン、Store で管理されるコンシューマブルなアドオン、開発者により管理されるコンシューマブルなアドオンの情報を取得します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetAddOnInfoPage.xaml.cs#GetAddOnInfo)]


## <a name="get-info-for-add-ons-for-the-current-app-that-the-user-has-purchased"></a>現在のアプリでユーザーが購入済みのアドオンの情報の取得

現在のユーザーが購入したアドオンの Store 製品情報を取得するには、[GetUserCollectionAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getusercollectionasync) メソッドを使います。 これは、各アドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 取得するアドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については [ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) プロパティをご覧ください。

> [!NOTE]
> アプリのアドオンが多くある場合、代わりに [GetUserCollectionWithPagingAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getusercollectionwithpagingasync) メソッドを使ってページングを利用し、アドオンの結果を返すこともできます。

次の例では、指定された [Store ID](in-app-purchases-and-trials.md#store_ids) を持つ永続的なアドオンの情報を取得します。

> [!div class="tabbedCodeSnippets"]
[!code-cs[GetProductInfo](./code/InAppPurchasesAndLicenses_RS1/cs/GetUserCollectionPage.xaml.cs#GetUserCollection)]

## <a name="related-topics"></a>関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)
