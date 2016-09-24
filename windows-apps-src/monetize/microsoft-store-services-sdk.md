---
author: mcleanbyron
Description: The Microsoft Store Services SDK provides libraries and tools that you can use to add features to your apps that help you make more money and gain customers.
title: Microsoft Store Services SDK
ms.assetid: 518516DB-70A7-49C4-B3B6-CD8A98320B9C
---

# Microsoft Store Services SDK

The Microsoft Store Services SDK provides libraries and tools that help you make more money and gain customers in your Universal Windows Platform (UWP) apps, such as displaying ads in your apps and running experiments with A/B testing. This SDK will evolve over time to include new engagement and monetization features.


## Features available in the SDK

The Microsoft Store Services SDK provides libraries and tools that support the following features.

### Run experiments with A/B testing for UWP apps

Run A/B tests in your Universal Windows Platform (UWP) apps to measure the effectiveness of features on some customers before you release the features to everyone. After you define an experiment in your Dev Center dashboard, use the [StoreServicesExperimentVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesexperimentvariation.aspx) class to get variations for your experiment in your app, use this data to modify the behavior of the feature you are testing, and then use the [LogForVariation](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomeventlogger.logforvariation.aspx) method to send view event and conversion events to Dev Center. Finally, use your dashboard to view the results and manage the experiment.

For more information, see [Run experiments with A/B testing](run-app-experiments-with-a-b-testing.md).

### App feedback for UWP apps

Use the [StoreServicesFeedbackLauncher](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicesfeedbacklauncher.aspx) class in your UWP apps to direct your Windows 10 customers to Feedback Hub, where they can submit problems, suggestions, and upvotes. Then, manage this feedback in the [Feedback report](../publish/feedback-report.md) in the Dev Center dashboard.

For more information, see [Launch Feedback Hub from your app](launch-feedback-hub-from-your-app.md).

### Display ads in your apps

Increase your revenue by displaying banner ads or video interstitial ads from Microsoft in UWP apps. You can also maximize your ad fill rates by using ad mediation to display ads from multiple ad network providers.

For more information, see [Display ads in your app](display-ads-in-your-app.md).

>**Note**&nbsp;&nbsp;Microsoft Store Services SDK only supports UWP apps. To display ads in Windows 8.1 and Windows Phone 8.x apps, use the [Microsoft Advertising SDK for Windows and Windows Phone 8.x](http://aka.ms/store-8-sdk).

### API reference

For reference documentation about the APIs in the Microsoft Store Services SDK, see [Microsoft Store Services SDK API reference](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx).

## Install the SDK

To install the Microsoft Store Services SDK:

1.  Close all instances of Visual Studio 2013 or Visual Studio 2015 and uninstall any previous versions of the Microsoft Store Engagement and Monetization SDK, Universal Ad Client SDK, Ad Mediator extension or Microsoft Advertising SDK.
2.  Download and install the [SDK](http://aka.ms/store-em-sdk). It may take a few minutes to install. Be sure and wait until the process has finished.
3.  Restart Visual Studio.

Microsoft periodically releases new versions of the Microsoft Store Services SDK with performance improvements and new features. If you have existing projects that use the Microsoft Store Services SDK and you want to use the latest version, simply download and install the latest version of the SDK.

The advertising features for UWP apps from previous releases of the Microsoft Store Engagement and Monetization SDK, Universal Ad Client SDK, Ad Mediator extension and Microsoft Advertising SDK are now included in the Microsoft Store Services SDK. If you have existing UWP projects that use advertising features from one of these previous releases, you can continue working with your projects without any changes after you install the Microsoft Store Services SDK.

>**Note**  To install the Microsoft Store Services SDK with Visual Studio 2015, you must have version 1.1 or later of the Visual Studio Tools for Universal Windows Apps installed. For more information about this update to the Visual Studio Tools for Universal Windows Apps, see the [release notes](http://go.microsoft.com/fwlink/?LinkID=624516).

## Framework packages in the SDK

The following libraries in the Microsoft Store Services SDK are configured as *framework packages*:

* Microsoft.Advertising.dll. This library contains the advertising APIs in the [Microsoft.Advertising](https://msdn.microsoft.com/en-us/library/windows/apps/mt313187.aspx) and [Microsoft.Advertising.WinRT.UI](https://msdn.microsoft.com/en-us/library/windows/apps/microsoft.advertising.winrt.ui.aspx) namespaces.
* Microsoft.Services.Store.Engagement.dll. This library contains the APIs in the [Microsoft.Services.Store.Engagement](https://msdn.microsoft.com/en-us/library/windows/apps/microsoft.services.store.engagement.aspx) namespace.

This means that after you install the SDK on your development computer, these libraries are automatically updated through Windows Update whenever we publish new versions of the libraries with fixes and performance improvements. This helps to ensure that you always have the latest available version of the libraries installed on your development computer.

In addition, after a user installs a version of your app that uses these libraries, the libraries will also automatically be updated on their device whenever we publish new versions of the libraries with fixes and performance improvements. This means that users will always have the most current version of the libraries, without any need for you to publish updated versions of your app to the Store.

However, if we release a new version of the SDK that introduces new APIs or features in these libraries, you will need to install the latest version of the SDK to use those features. In this scenario, you would also need to publish your updated app to the Store.

## Related topics

* [Microsoft Store Services SDK API reference](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx)
* [Run experiments with A/B testing](run-app-experiments-with-a-b-testing.md)
* [Launch Feedback Hub from your app](launch-feedback-hub-from-your-app.md)
* [Display ads in your app](display-ads-in-your-app.md)
