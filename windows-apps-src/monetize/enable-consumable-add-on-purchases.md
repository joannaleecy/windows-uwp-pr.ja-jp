---
author: mcleanbyron
ms.assetid: FD381669-F962-465E-940B-AED9C8D19C90
description: Learn how to use the Windows.Services.Store namespace to work with consumable add-ons.
title: Enable consumable add-on purchases
keywords: in-app offer
keywords: consumable
keywords: in-app purchase
keywords: in-app product
keywords: how to support in-app
keywords: in-app purchase code sample
keywords: in-app offer code sample
---

# Enable consumable add-on purchases

Apps that target Windows 10, version 1607 or later can use methods of the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) class in the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace to manage the user's fulfillment of consumable add-ons in your UWP apps (add-ons are also known as in-app products or IAPs). Use consumable add-ons for items that can be purchased, used, and purchased again. This is especially useful for things like in-game currency (gold, coins, etc.) that can be purchased and then used to purchase specific power-ups.

>**Note** This article is applicable to apps that target Windows 10, version 1607 or later. If your app targets an earlier version of Windows 10, you must use the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace instead of the **Windows.Services.Store** namespace. For more information, see [In-app purchases and trials using the Windows.ApplicationModel.Store namespace](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md).

## Overview of consumable add-ons

Apps that target Windows 10, version 1607 or later can offer two types of consumable add-ons that differ in the way that fulfillments are managed:

* **Developer-managed consumable**. For this type of consumable, you are responsible for keep tracking of the user's balance of items that the add-on represents. For example, if your add-on represents 100 coins in a game and the user consumes 10 coins, your app must report the add-on as fulfilled to the Store and your app or service must maintain the new remaining balance for the user.
* **Store-managed consumable**. For this type of consumable, Microsoft keeps track of the user's balance of items that the add-on represents. For example, if your add-on represents an initial quantity of 100 coins in a game and the user consumes 10 coins, your app reports to the Store that 10 units of the add-on were fulfilled, and the Store maintains the remaining balance. **This type is available starting in Windows 10, version 1607. The ability to create a Store-managed consumable in the Windows Dev Center dashboard is coming soon.**

To offer a consumable add-on to a user, follow this general process:

1. Enable users to [purchase the add-on](enable-in-app-purchases-of-apps-and-add-ons.md) from your app.
3. When the user consumes the add-on (for example, they spend coins in a game), [report the add-on as fulfilled](enable-consumable-add-on-purchases.md#report_fulfilled).

At any time, you can also [get the remaining balance](enable-consumable-add-on-purchases.md#get_balance) for a Store-managed consumable.

## Prerequisites

These examples have the following prerequisites:
* A Visual Studio project for a Universal Windows Platform (UWP) app that targets Windows 10, version 1607 or later.
* You have created an app in the Windows Dev Center dashboard with consumable add-ons (also known as in-app products or IAPs), and this app is published and available in the Store. This can be an app that you want to release to customers, or it can be a basic app that meets minimum [Windows App Certification Kit](https://developer.microsoft.com/windows/develop/app-certification-kit) requirements that you are using for testing purposes only. For more information, see the [testing guidance](in-app-purchases-and-trials.md#testing).

The code in these examples assume:
* The code runs in the context of a [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) that contains a [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) named ```workingProgressRing``` and a [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) named ```textBlock```. These objects are used to indicate that an asynchronous operation is occurring and to display output messages, respectively.
* The code file has a **using** statement for the **Windows.Services.Store** namespace.
* The app is a single-user app that runs only in the context of the user that launched the app. For more information, see [In-app purchases and trials](in-app-purchases-and-trials.md#api_intro).

<span id="report_fulfilled" />
## Report a consumable add-on as fulfilled

After the user [purchases the add-on](enable-in-app-purchases-of-apps-and-add-ons.md) from your app and they consume your add-on, your app must report the add-on as fulfilled by calling the [ReportConsumableFulfillmentAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.reportconsumablefulfillmentasync.aspx) method of the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) class. You must pass the following information to this method:

* The [Store ID](in-app-purchases-and-trials.md#store_ids) of the add-on that you want to report as fulfilled.
* The units of the add-on you want to report as fulfilled.
  * For a developer-managed consumable, specify 1 for the *quantity* parameter. This alerts the Store that the consumable has been fulfilled, and the customer can then purchase the consumable again. The user cannot purchase the consumable again until your app has notified the Store that it was fulfilled.
  * For a Store-managed consumable, specify the actual number of units that have been consumed. The Store will update the remaining balance for the consumable.
* The tracking ID for the fulfillment. This is a developer-supplied GUID that identifies the specific transaction that the fulfillment operation is associated with for tracking purposes. For more information, see the remarks in [ReportConsumableFulfillmentAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.reportconsumablefulfillmentasync.aspx).

This example demonstrates how to report a Store-managed consumable as fulfilled.

```csharp
private StoreContext context = null;

public async void ConsumeAddOn(string storeId)
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    // This is an example for a Store-managed consumable, where you specify the actual number
    // of units that you want to report as consumed so the Store can update the remaining
    // balance. For a developer-managed consumable where you maintain the balance, specify 1
    // to just report the add-on as fulfilled to the Store.
    uint quantity = 10;
    string addOnStoreId = "9NBLGGH4TNNR";
    Guid trackingId = Guid.NewGuid();

    workingProgressRing.IsActive = true;
    StoreConsumableResult result = await context.ReportConsumableFulfillmentAsync(
        addOnStoreId, quantity, trackingId);
    workingProgressRing.IsActive = false;

    if (result.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {result.ExtendedError.Message}";
        return;
    }

    switch (result.Status)
    {
        case StoreConsumableStatus.Succeeded:
            textBlock.Text = "The fulfillment was successful. Remaining balance: " +
                result.BalanceRemaining;
            break;

        case StoreConsumableStatus.InsufficentQuantity:
            textBlock.Text = "The fulfillment was unsuccessful because the user " +
            "doesn't have enough remaining balance." + result.BalanceRemaining;
            break;

        case StoreConsumableStatus.NetworkError:
            textBlock.Text = "The fulfillment was unsuccessful due to a network error.";
            break;

        case StoreConsumableStatus.ServerError:
            textBlock.Text = "The fulfillment was unsuccessful due to a server error.";
            break;

        default:
            textBlock.Text = "The fulfillment was unsuccessful due to an unknown error.";
            break;
    }
}
```

<span id="get_balance" />
## Get the remaining balance for a Store-managed consumable

This example demonstrates how to use the [GetConsumableBalanceRemainingAsync](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getconsumablebalanceremainingasync.aspx) method of the [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) class to get the remaining balance for a Store-managed consumable add-on.

```csharp
private StoreContext context = null;

public async void GetRemainingBalance(string storeId)
{
    if (context == null)
    {
        context = StoreContext.GetDefault();
    }

    string addOnStoreId = "9NBLGGH4TNNR";

    workingProgressRing.IsActive = true;
    StoreConsumableResult result = await context.GetConsumableBalanceRemainingAsync(addOnStoreId);
    workingProgressRing.IsActive = false;

    if (result.ExtendedError != null)
    {
        // The user may be offline or there might be some other server failure.
        textBlock.Text = $"ExtendedError: {result.ExtendedError.Message}";
        return;
    }

    switch (result.Status)
    {
        case StoreConsumableStatus.Succeeded:
            textBlock.Text = "Remaining balance: " + result.BalanceRemaining;
            break;

        case StoreConsumableStatus.NetworkError:
            textBlock.Text = "Could not retrieve balance due to a network error.";
            break;

        case StoreConsumableStatus.ServerError:
            textBlock.Text = "Could not retrieve balance due to a server error.";
            break;

        default:
            textBlock.Text = "Could not retrieve balance due to an unknown error.";
            break;
    }
}
```

## Related topics

* [In-app purchases and trials](in-app-purchases-and-trials.md)
* [Get product info for apps and add-ons](get-product-info-for-apps-and-add-ons.md)
* [Get license info for apps and add-ons](get-license-info-for-apps-and-add-ons.md)
* [Enable in-app purchases of apps and add-ons](enable-in-app-purchases-of-apps-and-add-ons.md)
* [Implement a trial version of your app](implement-a-trial-version-of-your-app.md)
