---
author: mcleanbyron
ms.assetid: F45E6F35-BC18-45C8-A8A5-193D528E2A4E
description: Learn how to enable in-app purchases and trials in UWP apps.
title: In-app purchases and trials
---

# In-app purchases and trials

The Windows SDK provides APIs you can use to add in-app purchases and trial functionality to your Universal Windows Platform (UWP) app to help monetize your app and add new functionality. These APIs also provide access to the license info for your app.

For these scenarios, Windows 10 offers two different APIs:

* All versions of Windows 10 support an API for in-app purchases and license info in the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace.

* Starting in Windows 10, version 1607, there is an alternate API for in-app purchases and license info in the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace.  

Although the APIs in these namespaces serve the same goals, they are designed quite differently, and code is not compatible between the two APIs. If your app targets Windows 10, version 1607 or later, we recommend that you use the **Windows.Services.Store** namespace. This namespace supports the latest add-on types, such as Store-managed consumable add-ons, and is designed to be compatible with future types of products and features supported by Windows Dev Center and the Store. The **Windows.Services.Store** namespace is also designed to have better performance than the **Windows.ApplicationModel.Store** namespace.

This article introduces in-app purchases for UWP apps and provides an overview of the **Windows.Services.Store** namespace that is available starting in Windows 10, version 1607. For information about using the members in the **Windows.ApplicationModel.Store** namespace, see [In-app purchases and trials using the Windows.ApplicationModel.Store namespace](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md).


## Overview of in-app purchases in UWP apps

This section describes core concepts about how in-app purchases and trials work with UWP apps in the Store. Most of these concepts apply to both the **Windows.Services.Store** and the **Windows.ApplicationModel.Store** namespaces.

Every item that is offered in the Store is generally called a *product*. Most developers work with the following types of products: *apps* and *add-ons* (also known as in-app products or IAPs). An add-on refers to a product or feature that you make available to your customers in the context of your app. An add-on can represent any functionality that your app offers to customers; for example, new maps or weapons for a game, the ability to use your app without ads, or digital content such as music or videos for apps that have the ability to offer that type of content.

Every app and add-on has an associated license that indicates whether the user is entitled to use the app or add-on. If the user is entitled to use the app or add-on as a trial, the license also provides additional info about the trial.

To offer an add-on to customers in your app, start by [defining the add-ons for your app in the Dev Center dashboard](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions). Then, write code in your app to determine whether the user has a license to use the feature that is represented by the add-on, and offer the add-on for sale to the user as an in-app purchase if they don't yet have a license for it. For examples that demonstrate related tasks using the **Windows.Services.Store** namespace in apps that target Windows 10, version 1607 or later, see the following articles:

* [Get product info for apps and add-ons](get-product-info-for-apps-and-add-ons.md)
* [Get license info for apps and add-ons](get-license-info-for-apps-and-add-ons.md)
* [Enable in-app purchases of apps and add-ons](enable-in-app-purchases-of-apps-and-add-ons.md)
* [Enable consumable add-on purchases](enable-consumable-add-on-purchases.md)
* [Implement a trial version of your app](implement-a-trial-version-of-your-app.md)

For examples that demonstrate related tasks using the **Windows.ApplicationModel.Store** namespace, see [In-app purchases and trials using the Windows.ApplicationModel.Store namespace](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md).

All developers can create the following types of add-ons.

| Add-on type |  Description  |
|---------|-------------------|
| Durable  |  An add-on that can only be purchased once. |
| Developer-managed consumable  |  An add-on that can be purchased, used, and purchased again. For this type of consumable, you are responsible for keep tracking of the user's balance of items that the add-on represents. For example, if your add-on represents 100 coins in a game and the user consumes 10 coins, your app must report the add-on as fulfilled to the Store and your app or service must update the new remaining balance for the user (in this example, the user now has 90 coins left).  |
| Store-managed consumable  |  An add-on that can be purchased, used, and purchased again. For this type of consumable, Microsoft keeps track of the user's balance of items that the add-on represents. For example, if your add-on represents an initial quantity of 100 coins in a game and the user consumes 10 coins, your app reports to the Store that 10 units of the add-on were fulfilled, and the Store updates the remaining balance. You can use a method to query for the current balance. <p/><p/> **Store-managed consumables are available starting in Windows 10, version 1607. The ability to create a Store-managed consumable in the Windows Dev Center dashboard is coming soon.**  |

<span />

>**Note** Other types of add-ons, such as durable add-ons with packages (also known as downloadable content or DLC) are only available to a restricted set of developers, and are not covered in this documentation.

<span id="api_intro" />
## Introduction to the Windows.Services.Store namespace

The main entry point to the **Windows.Services.Store** namespace is the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) class. This class provides methods you can use to get info for the current app and its available add-ons, purchase an app or add-on for the current user, get license info for the current app or its add-ons, and other tasks. To get a [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) object, do one of the following:

* In a single-user app (that is, an app that runs only in the context of the user that launched the app), use the [GetDefault](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getdefault.aspx) method to get a **StoreContext** object that you can use to access and manage Windows Store-related data for the user. Most Universal Windows Platform (UWP) apps are single-user apps.

  ```csharp
  Windows.Services.Store.StoreContext context = StoreContext.GetDefault();
  ```

* In a multi-user app (that is, an app that runs only in the context of the user that launched the app), use the [GetForUser](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getforuser.aspx) method to get a **StoreContext** object that you can use to access and manage Windows Store-related data for a specific user who is signed in with their Microsoft account while using the app. For more information about multi-user apps, see [Introduction to multi-user applications](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications). The following example gets a **StoreContext** object for the first available user.

  ```csharp
  var users = await Windows.System.User.FindAllAsync();
  Windows.Services.Store.StoreContext context = StoreContext.GetForUser(users[0]);
  ```

After you have a [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx), you can start calling methods to purchase an app or add-on for the current user and other tasks. For more information, see the following articles:

* [Get product info for apps and add-ons](get-product-info-for-apps-and-add-ons.md)
* [Get license info for apps and add-ons](get-license-info-for-apps-and-add-ons.md)
* [Enable in-app purchases of apps and add-ons](enable-in-app-purchases-of-apps-and-add-ons.md)
* [Enable consumable add-on purchases](enable-consumable-add-on-purchases.md)
* [Implement a trial version of your app](implement-a-trial-version-of-your-app.md)

<span />
### Object model for products, SKUs, and availabilities

Every product in the Store has at least one *SKU*, and each SKU has at least one *availability*. These concepts are abstracted away from most developers in the Windows Dev Center dashboard, and most developers will never define SKUs or availabilities for their apps or add-ons. However, because the object model for Store products in the **Windows.Services.Store** namespace includes SKUs and availabilities, a basic understanding of these concepts can be helpful.

| Object type |  Description  |
|---------|-------------------|
| Product  |  The [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) class represents any type of product that is available in the Store, including an app or add-on. This class provides properties you can use to access data such as the Store ID of the product, the images and videos for the Store listing, and pricing info. It also provides methods you can use to purchase the product. |
| SKU |  The [StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) class represents a *SKU* for a product. A SKU is a specific version of a product with its own description, price, and other unique product details. Each app or add-on has a default SKU. The only time most developers will ever have multiple SKUs for an app is if they publish a full version of your app and a trial version (in the Store catalog, each of these versions is a different SKU of the same app). <p/><p/> Some publishers have the ability to define their own SKUs. For example, a large game publisher might release a game with one SKU that shows green blood in markets that don't allow red blood and a different SKU that shows red blood in all other markets. Alternatively, a publisher who sells digital video content might publish two SKUs for a video, one SKU for the high-definition version and a different SKU for the standard-definition version. <p/><p/> Each product has a [Skus](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.skus.aspx) property you can use to access the SKUs. |
| Availability  |  The [StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) class represents an *availability* for a SKU. An availability is a specific version of a SKU with its own unique pricing info. Each SKU has a default availability. Some publishers have the ability to define their own availabilities to introduce different price options for a given SKU. <p/><p/> Each SKU has an [Availabilities](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.availabilities.aspx) property you can use to access the availabilities. For most developers, each SKU has a single default availability.  |

<span id="store_ids" />
### Store IDs

Every app and add-on in the Store has an associated **Store ID**. Many of the APIs in the **Windows.Services.Store** namespace require the Store ID in order to perform an operation on an app or add-on. Products, SKUs, and availabilities have different Store ID formats.

| Object type |  Store ID format  |
|---------|-------------------|
| Product  |  The Store ID of any product in the Store is 12-character alpha-numeric string, such as ```9NBLGGH4R315```. This Store ID is available in the Windows Dev Center dashboard page for the app or add-on, and it is returned by the [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.storeid.aspx) property [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) object. This ID is sometimes called the *product Store ID*. |
| SKU |  For a SKU, the Store ID has the format ```<product Store ID>/xxxx```, where ```xxxx``` is a 4-character alpha-numeric string that identifies a SKU for the product. For example, ```9NBLGGH4R315/000N```. This ID is returned by the [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.storeid.aspx) property of a  [StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) object, and it is sometimes called the *SKU Store ID*. |
| Availability  |  For an availability, the Store ID has the format ```<product Store ID>/xxxx/yyyyyyyyyyyy```, where ```xxxx``` is a 4-character alpha-numeric string that identifies a SKU for the product and ```yyyyyyyyyyyy``` is a 12-character alpha-numeric string that identifies an availability for the SKU. For example, ```9NBLGGH4R315/000N/4KW6QZD2VN6X```. This ID is returned by the [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.storeid.aspx) property of a  [StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) object, and it is sometimes called the *availability Store ID*.  |

<span id="testing" />
### Testing apps that use the Windows.Services.Store namespace

The **Windows.Services.Store** namespace does not provide a class that you can use to simulate license info during testing. Instead, you must publish an app to the Store and download that app to your development device to use its license for testing. This is a different experience from apps that use the **Windows.ApplicationModel.Store** namespace, as these apps can use the [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) class to simulate license info during testing

If your app uses APIs in the **Windows.Services.Store** namespace to access info for your app and its add-ons, follow this process to test your code:

1. If your app is already published and available in the Store and you want to update this app to use APIs in the **Windows.Services.Store** namespace, you are ready to get started. If you want to offer add-ons for the app, make sure that you [define the add-ons for your app](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions) in the Dev Center dashboard.

  If you don't yet have an app that is published and available in the Store, build a basic app that meets minimum [Windows App Certification Kit](https://developer.microsoft.com/windows/develop/app-certification-kit) requirements and [submit this app](https://msdn.microsoft.com/windows/uwp/publish/app-submissions) to the Windows Dev Center dashboard. If you want to offer add-ons for the app, make sure that you [define the add-ons for your app](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions). Optionally, you can [hide the app from the Store](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability) during testing.

2. Write code in your app that uses one of the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) methods in the **Windows.Services.Store** namespace to perform tasks such as [getting the add-ons available for the current app](get-product-info-for-apps-and-add-ons.md), [purchasing an app or add-on](enable-in-app-purchases-of-apps-and-add-ons.md), or [getting license info for your app](get-license-info-for-apps-and-add-ons.md). See the related topics section below for more examples.

3. In Visual Studio, click the **Project menu**, point to **Store**, and then click **Associate App with the Store**. Complete the instructions in the wizard to associate the app project with the app in your Windows Dev Center account that you want to use for testing.

  >**Note** If you do not associate your project with an app in the Store, the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) methods set the **ExtendedError** property of their return values to the error code value 0x803F6107. This value indicates that the Store doesn't have any knowledge about the app.

4. If you have not done so already, install the app from the Store that you specified in the previous step, run the app once, and then close this app. This ensures that a valid license for the app is installed to your development device.

5. In Visual Studio, start running or debugging your project. Your code should retrieve app and add-on data from the Store app that you associated with your local project. If you are prompted to reinstall the app, follow the instructions and then run or debug your project.

## Related topics

* [Get product info for apps and add-ons](get-product-info-for-apps-and-add-ons.md)
* [Get license info for apps and add-ons](get-license-info-for-apps-and-add-ons.md)
* [Enable in-app purchases of apps and add-ons](enable-in-app-purchases-of-apps-and-add-ons.md)
* [Enable consumable add-on purchases](enable-consumable-add-on-purchases.md)
* [Implement a trial version of your app](implement-a-trial-version-of-your-app.md)
* [In-app purchases and trials using the Windows.ApplicationModel.Store namespace](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)
