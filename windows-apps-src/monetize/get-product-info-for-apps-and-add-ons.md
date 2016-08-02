---
author: mcleanbyron
ms.assetid: 89178FD9-850B-462F-9016-1AD86D1F6F7F
description: Learn how to use the Windows.Services.Store namespace to get Store-related product info for the current app or one of its add-ons.
title: Get product info for apps and add-ons
---

# Get product info for apps and add-ons

Apps that target Windows 10, version 1607 or later can use methods of the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) class in the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace to access Store-related info for the current app or one of its add-ons (also known as in-app products or IAPs). The following examples demonstrate how to do this for different scenarios.

>**Note** This article is applicable to apps that target Windows 10, version 1607 or later. If your app targets an earlier version of Windows 10, you must use the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace instead of the **Windows.Services.Store** namespace. For more information, see [In-app purchases and trials using the Windows.ApplicationModel.Store namespace](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md).

## Prerequisites

These examples have the following prerequisites:
* A Visual Studio project for a Universal Windows Platform (UWP) app that targets Windows 10, version 1607 or later.
* You have created an app in the Windows Dev Center dashboard, and this app is published and available in the Store. This can be an app that you want to release to customers, or it can be a basic app that meets minimum [Windows App Certification Kit](https://developer.microsoft.com/windows/develop/app-certification-kit) requirements that you are using for testing purposes only. For more information, see the [testing guidance](in-app-purchases-and-trials.md#testing).

The code in these examples assume:
* The code runs in the context of a [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) that contains a [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) named ```workingProgressRing``` and a [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) named ```textBlock```. These objects are used to indicate that an asynchronous operation is occurring and to display output messages, respectively.
* The code file has a **using** statement for the **Windows.Services.Store** namespace.
* The app is a single-user app that runs only in the context of the user that launched the app. For more information, see [In-app purchases and trials](in-app-purchases-and-trials.md#api_intro).

## Get info for the current app

To get Store product info about the current app, use the [GetStoreProductForCurrentAppAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getstoreproductforcurrentappasync.aspx) method. This is an asynchronous method that returns a [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) object that you can use to get info such as the price.

```csharp
private StoreContext context = null;

public async void GetAppInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // Get app store product details. Because this might take several moments,   
    // display a ProgressRing during the operation.
    workingProgressRing.IsActive = true;
    var queryResult = await context.GetStoreProductForCurrentAppAsync();
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

## Get info for products with known Store IDs

To get Store product info for apps or add-ons for which you already know the [Store IDs](in-app-purchases-and-trials.md#store_ids), use the [GetStoreProductsAsync](https://msdn.microsoft.com/library/windows/apps/mt706579.aspx) method. This is an asynchronous method that returns a collection of  [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) objects that represent each of the apps or add-ons. In addition to the Store IDs, you must pass a list of strings to this method that identify the types of the add-ons. For a list of the supported string values, see the [ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) property.

The following example retrieves info for durable add-ons with the specified Store IDs.

```csharp
private StoreContext context = null;

public async void GetProductInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // Specify the kinds of add-ons to retrieve.
    string[] productKinds = { "Durable" };
    List<String> filterList = new List<string>(productKinds);

    // Specify the Store IDs of the products to retrieve.
    string[] storeIds = new string[] { "9NBLGGH4TNMP", "9NBLGGH4TNMN" };

    workingProgressRing.IsActive = true;
    var queryResult = await context.GetStoreProductsAsync(filterList, storeIds);
    workingProgressRing.IsActive = false;

    if (queryResult.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {queryResult.ExtendedError.Message}";
        return;
    }

    foreach (var item in queryResult.Products)
    {
        // Access the Store info for the product.
        StoreProduct product = item.Value;

        // Use members of the product object to access info for the product...
    }
}
```

## Get info for add-ons that are available for the current app

To get Store product info for the add-ons that are available for the current app, use the [GetAssociatedStoreProductsAsync](https://msdn.microsoft.com/library/windows/apps/mt706571.aspx) method. This is an asynchronous method that returns a collection of  [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) objects that represent each of the available add-ons. You must pass a list of strings to this method that identify the types of add-ons you want to retrieve. For a list of the supported string values, see the [ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) property.

The following example retrieves info for all durable add-ons, Store-managed consumable add-ons, and developer-managed consumable add-ons.

```csharp
private StoreContext context = null;

public async void GetAddOnInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // Specify the kinds of add-ons to retrieve.
    string[] productKinds = { "Durable", "Consumable", "UnmanagedConsumable" };
    List<String> filterList = new List<string>(productKinds);

    workingProgressRing.IsActive = true;
    var queryResult = await context.GetAssociatedStoreProductsAsync(filterList);
    workingProgressRing.IsActive = false;

    if (queryResult.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {queryResult.ExtendedError.Message}";
        return;
    }

    foreach (var item in queryResult.Products)
    {
        // Access the Store product info for the add-on.
        StoreProduct product = item.Value;

        // Use members of the product object to access listing info for the add-on...
    }
}
```

>**Note** If the app has many add-ons, you can alternatively use the [GetAssociatedStoreProductsWithPagingAsync](https://msdn.microsoft.com/library/windows/apps/mt706572.aspx) method to use paging to return the add-on results.


## Get info for add-ons for the current app that the current user is entitled to use

To get Store product info for add-ons that the current user is entitled to use, use the [GetUserCollectionAsync](https://msdn.microsoft.com/library/windows/apps/mt706580.aspx) method. This is an asynchronous method that returns a collection of  [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) objects that represent each of the add-ons. You must pass a list of strings to this method that identify the types of add-ons you want to retrieve. For a list of the supported string values, see the [ProductKind](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.productkind.aspx) property.

The following example retrieves info for durable add-ons with the specified Store IDs.

```csharp
private StoreContext context = null;

public async void GetUserCollection()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // Specify the kinds of add-ons to retrieve.
    string[] productKinds = { "Durable" };
    List<String> filterList = new List<string>(productKinds);

    // Specify the Store IDs of the products to retrieve.
    string[] storeIds = new string[] { "9NBLGGH4TNMP", "9NBLGGH4TNMN" };

    workingProgressRing.IsActive = true;
    var queryResult = await context.GetUserCollectionAsync(filterList);
    workingProgressRing.IsActive = false;

    if (queryResult.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {queryResult.ExtendedError.Message}";
        return;
    }

    foreach (var item in queryResult.Products)
    {
        StoreProduct product = item.Value;

        // Use members of the product object to access info for the product...
    }
}
```

>**Note** If the app has many add-ons, you can alternatively use the [GetUserCollectionWithPagingAsync](https://msdn.microsoft.com/library/windows/apps/mt706581.aspx) method to use paging to return the add-on results.

## Related topics

* [In-app purchases and trials](in-app-purchases-and-trials.md)
* [Get license info for apps and add-ons](get-license-info-for-apps-and-add-ons.md)
* [Enable in-app purchases of apps and add-ons](enable-in-app-purchases-of-apps-and-add-ons.md)
* [Enable consumable add-on purchases](enable-consumable-add-on-purchases.md)
* [Implement a trial version of your app](implement-a-trial-version-of-your-app.md)
