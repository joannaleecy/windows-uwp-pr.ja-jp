---
author: mcleanbyron
ms.assetid: 32572890-26E3-4FBB-985B-47D61FF7F387
description: Learn how to enable in-app purchases and trials in UWP apps that target releases before Windows 10, version 1607.
title: In-app purchases and trials using the Windows.ApplicationModel.Store namespace
---

# In-app purchases and trials using the Windows.ApplicationModel.Store namespace

The Windows SDK provides members in the [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) namespace that you can use to add in-app purchases and trial functionality to your Universal Windows Platform (UWP) app to help monetize your app and add new functionality. These APIs also provide access to the license info for your app.

>**Note** If your app targets Windows 10, version 1607 or later, we recommend that you use members of the [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) namespace instead of the **Windows.ApplicationModel.Store** namespace. The **Windows.Services.Store** namespace supports the latest add-on types, such as Store-managed consumable add-ons, and is designed to be compatible with future types of products and features supported by Windows Dev Center and the Store. The **Windows.Services.Store** namespace is also designed to have better performance. For more information, see [In-app purchases and trials](in-app-purchases-and-trials.md).

The articles in this section provide in-depth guidance and code examples for using the members in members in the **Windows.ApplicationModel.Store** namespace for several common scenarios. For an overview of concepts related to in-app purchases in UWP apps, see [In-app purchases and trials](in-app-purchases-and-trials.md).

## In this section


| Topic                                                                                                       | Description                 |
|-------------------------------------------------------------------------------------------------------------|-----------------------------|
| [Enable in-app product purchases](enable-in-app-product-purchases.md)      |  Whether your app is free or not, you can sell content, other apps, or new app functionality (such as unlocking the next level of a game) from right within the app. Here we show you how to enable these products in your app.  |
| [Enable consumable in-app product purchases](enable-consumable-in-app-product-purchases.md)      | Offer consumable in-app products—items that can be purchased, used, and purchased again—through the Store commerce platform to provide your customers with a purchase experience that is both robust and reliable. This is especially useful for things like in-game currency (gold, coins, etc.) that can be purchased and then used to purchase specific power-ups. |
| [Exclude or limit features in a trial version](exclude-or-limit-features-in-a-trial-version-of-your-app.md) | If you enable customers to use your app for free during a trial period, you can entice your customers to upgrade to the full version of your app by excluding or limiting some features during the trial period. |
| [Manage a large catalog of in-app products](manage-a-large-catalog-of-in-app-products.md)      |   If your app offers a large in-app product catalog, you can optionally follow the process described in this topic to help manage your catalog.    |
| [Use receipts to verify product purchases](use-receipts-to-verify-product-purchases.md)      |   Each Windows Store transaction that results in a successful product purchase can optionally return a transaction receipt that provides information about the listed product and monetary cost to the customer. Having access to this information supports scenarios where your app needs to verify that a user purchased your app, or has made in-app product purchases from the Windows Store. |
