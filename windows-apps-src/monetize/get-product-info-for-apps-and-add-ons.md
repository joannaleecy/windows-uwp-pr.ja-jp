---
author: mcleanbyron
ms.assetid: 89178FD9-850B-462F-9016-1AD86D1F6F7F
description: "Windows.Services.Store 名前空間を使って、現在のアプリまたはそのアドオンのストアに関連する製品情報を取得する方法について説明します。"
title: "アプリとアドオンの製品情報の取得"
translationtype: Human Translation
ms.sourcegitcommit: 962bee0cae8c50407fe1509b8000dc9cf9e847f8
ms.openlocfilehash: 8471dfd24b189ff6ca4f50c4461b72ac5d81659d

---

# アプリとアドオンの製品情報の取得

Windows 10 バージョン 1607以降をターゲットとするアプリは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間で [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスのメソッドを使って、現在のアプリとそのアドオン (アプリ内製品または IAP とも呼ばれます) のストアに関連する情報にアクセスできます。 この記事の例では、さまざまなシナリオでこれを行う方法を説明します。 完全なアプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

>**注**&nbsp;&nbsp;この記事は、Windows 10 バージョン 1607 以降をターゲットとするアプリに適用されます。 アプリが Windows 10 の以前のバージョンをターゲットする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

## 必要条件

これらの例には、次の必要条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュ ボードでアプリを作成し、このアプリが公開されてストアで入手可能になっている。 これは、ユーザーにリリースするアプリでも、[Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最小要件を満たす、テスト目的でのみ使う基本的なアプリでもかまいません。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。

これらの例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

>**注:**&nbsp;&nbsp;[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使うデスクトップ アプリケーションがある場合、これらの例には示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[Desktop Bridge を使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## 現在のアプリの情報の取得

現在のアプリに関するストア製品情報を取得するには、[GetStoreProductForCurrentAppAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getstoreproductforcurrentappasync.aspx) メソッドを使います。 これは、価格などの情報の取得に使うことができる [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトを返す非同期メソッドです。

```csharp
private StoreContext context = null;

public async void GetAppInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    // Get app store product details. Because this might take several moments,   
    // display a ProgressRing during the operation.
    workingProgressRing.IsActive = true;
    StoreProductResult queryResult = await context.GetStoreProductForCurrentAppAsync();
    workingProgressRing.IsActive = false;

    if (queryResult.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {queryResult.ExtendedError.Message}";
        return;
    }

    if (queryResult.Product == null)
    {
        // The Store catalog returned an unexpected result.
        textBlock.Text = "Something went wrong, the product was not returned.";
        return;
    }

    // Display the price of the app.
    textBlock.Text = $"The price of this app is: {queryResult.Product.Price.FormattedBasePrice}";
}
```

## 既知のストア ID による製品の情報の取得

既に[ストア ID](in-app-purchases-and-trials.md#store_ids) を知っているアプリまたはアドオンのストア製品情報を取得するには、[GetStoreProductsAsync](https://msdn.microsoft.com/library/windows/apps/mt706579.aspx) メソッドを使います。 これは、各アプリまたはアドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 ストア ID に加えて、アドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については[ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) プロパティをご覧ください。

次の例では、指定されたストア ID を持つ永続的なアドオンの情報を取得します。

```csharp
private StoreContext context = null;

public async void GetProductInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    // Specify the kinds of add-ons to retrieve.
    string[] productKinds = { "Durable" };
    List<String> filterList = new List<string>(productKinds);

    // Specify the Store IDs of the products to retrieve.
    string[] storeIds = new string[] { "9NBLGGH4TNMP", "9NBLGGH4TNMN" };

    workingProgressRing.IsActive = true;
    StoreProductQueryResult queryResult =
        await context.GetStoreProductsAsync(filterList, storeIds);
    workingProgressRing.IsActive = false;

    if (queryResult.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {queryResult.ExtendedError.Message}";
        return;
    }

    foreach (KeyValuePair<string, StoreProduct> item in queryResult.Products)
    {
        // Access the Store info for the product.
        StoreProduct product = item.Value;

        // Use members of the product object to access info for the product...
    }
}
```

## 現在のアプリで利用可能なアドオンの情報の取得

現在のアプリで利用可能なアドオンのストア製品情報を取得するには、[GetAssociatedStoreProductsAsync](https://msdn.microsoft.com/library/windows/apps/mt706571.aspx) メソッドを使います。 これは、利用可能な各アドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 取得するアドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については[ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) プロパティをご覧ください。

次の例では、すべての永続的なアドオン、ストアで管理されるコンシューマブルなアドオン、開発者により管理されるコンシューマブルなアドオンの情報を取得します。

```csharp
private StoreContext context = null;

public async void GetAddOnInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    // Specify the kinds of add-ons to retrieve.
    string[] productKinds = { "Durable", "Consumable", "UnmanagedConsumable" };
    List<String> filterList = new List<string>(productKinds);

    workingProgressRing.IsActive = true;
    StoreProductQueryResult queryResult = await context.GetAssociatedStoreProductsAsync(filterList);
    workingProgressRing.IsActive = false;

    if (queryResult.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {queryResult.ExtendedError.Message}";
        return;
    }

    foreach (KeyValuePair<string, StoreProduct> item in queryResult.Products)
    {
        // Access the Store product info for the add-on.
        StoreProduct product = item.Value;

        // Use members of the product object to access listing info for the add-on...
    }
}
```

>**注**&nbsp;&nbsp;アプリのアドオンが多くある場合、代わりに [GetAssociatedStoreProductsWithPagingAsync](https://msdn.microsoft.com/library/windows/apps/mt706572.aspx) メソッドを使ってページングを使い、アドオン結果を返すこともできます。


## 現在のユーザーが使う権利を持つ現在のアプリのアドオンの情報を取得します。

現在のユーザーが使う権利を持つアドオンのストア製品情報を取得するには、[GetUserCollectionAsync](https://msdn.microsoft.com/library/windows/apps/mt706580.aspx) メソッドを使います。 これは、各アドオンを表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトのコレクションを返す非同期メソッドです。 取得するアドオンの種類を識別する文字列の一覧をこのメソッドに渡す必要があります。 サポートされている文字列値の一覧については[ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) プロパティをご覧ください。

次の例では、指定されたストア ID を持つ永続的なアドオンの情報を取得します。

```csharp
private StoreContext context = null;

public async void GetUserCollection()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
        // If your app is a desktop app that uses the Desktop Bridge, you
        // may need additional code to configure the StoreContext object.
        // For more info, see https://aka.ms/storecontext-for-desktop.
    }

    // Specify the kinds of add-ons to retrieve.
    string[] productKinds = { "Durable" };
    List<String> filterList = new List<string>(productKinds);

    workingProgressRing.IsActive = true;
    StoreProductQueryResult queryResult = await context.GetUserCollectionAsync(filterList);
    workingProgressRing.IsActive = false;

    if (queryResult.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {queryResult.ExtendedError.Message}";
        return;
    }

    foreach (KeyValuePair<string, StoreProduct> item in queryResult.Products)
    {
        StoreProduct product = item.Value;

        // Use members of the product object to access info for the product...
    }
}
```

>**注**&nbsp;&nbsp;アプリのアドオンが多くある場合、代わりに [GetUserCollectionWithPagingAsync](https://msdn.microsoft.com/library/windows/apps/mt706581.aspx) メソッドを使ってページングを使い、アドオン結果を返すこともできます。

## 関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)



<!--HONumber=Nov16_HO1-->


