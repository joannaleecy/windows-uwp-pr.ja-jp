---
author: mcleanbyron
ms.assetid: 9630AF6D-6887-4BE3-A3CB-D058F275B58F
description: Learn how to use the Windows.Services.Store namespace to get license info for the current app and its add-ons.
title: Get license info for your app and add-ons
---

# Get license info for your app and add-ons

Apps that target Windows 10, version 1607 or later can use methods of the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) class in the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace to get license info for the current app its add-ons (also known as in-app products or IAPs). For example, you can use this info to determine if the licenses for the app or its add-ons are active, or if they are trial licenses.

>**Note** This article is applicable to apps that target Windows 10, version 1607 or later. If your app targets an earlier version of Windows 10, you must use the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace instead of the **Windows.Services.Store** namespace. For more information, see [In-app purchases and trials using the Windows.ApplicationModel.Store namespace](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md).

## Prerequisites

This example has the following prerequisites:
* A Visual Studio project for a Universal Windows Platform (UWP) app that targets Windows 10, version 1607 or later.
* You have created an app in the Windows Dev Center dashboard, and this app is published and available in the Store. This can be an app that you want to release to customers, or it can be a basic app that meets minimum [Windows App Certification Kit](https://developer.microsoft.com/windows/develop/app-certification-kit) requirements that you are using for testing purposes only. For more information, see the [testing guidance](in-app-purchases-and-trials.md#testing).

The code in this example assumes:
* The code runs in the context of a [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) that contains a [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) named ```workingProgressRing``` and a [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) named ```textBlock```. These objects are used to indicate that an asynchronous operation is occurring and to display output messages, respectively.
* The code file has a **using** statement for the **Windows.Services.Store** namespace.
* The app is a single-user app that runs only in the context of the user that launched the app. For more information, see [In-app purchases and trials](in-app-purchases-and-trials.md#api_intro).

## Code example

To get license info for the current app and its add-ons, use the [GetAppLicenseAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getapplicenseasync.aspx) method. This is an asynchronous method that returns a   [StoreAppLicense](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.aspx) object that provides license info. The [AddOnLicenses](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) property provides access to info about the add-on licenses for the app.

```csharp
private StoreContext context = null;

public async void GetLicenseInfo()
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    workingProgressRing.IsActive = true;
    StoreAppLicense appLicense = await context.GetAppLicenseAsync();
    workingProgressRing.IsActive = false;

    if (appLicense == null)
    {
        textBlock.Text = "An error occurred while retrieving the license.";
        return;
    }

    // Use members of the appLicense object to access license info...

    // Access the add on licenses for add-ons for this app.
    foreach (var item in appLicense.AddOnLicenses)
    {
        StoreLicense addOnLicense = item.Value;
        // Use members of the addOnLicense object to access license info
        // for the add-on...
    }
}
```


## Related topics

* [In-app purchases and trials](in-app-purchases-and-trials.md)
* [Get product info for apps and add-ons](get-product-info-for-apps-and-add-ons.md)
* [Enable in-app purchases of apps and add-ons](enable-in-app-purchases-of-apps-and-add-ons.md)
* [Enable consumable add-on purchases](enable-consumable-add-on-purchases.md)
* [Implement a trial version of your app](implement-a-trial-version-of-your-app.md)
