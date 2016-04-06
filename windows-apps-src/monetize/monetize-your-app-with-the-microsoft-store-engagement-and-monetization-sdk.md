---
Description: The Microsoft Store Engagement and Monetization SDK provides libraries and tools that you can use to add features to your apps that help you make more money and gain customers.
title: Monetize your app and engage customers with the Microsoft Store Engagement and Monetization SDK
ms.assetid: 518516DB-70A7-49C4-B3B6-CD8A98320B9C
---

# Monetize your app and engage customers with the Microsoft Store Engagement and Monetization SDK

The Microsoft Store Engagement and Monetization SDK provides libraries and tools that help you make more money and gain customers, such as displaying ads in your apps and running experiments with A/B testing. This SDK replaces the Microsoft Universal Ad Client SDK, and it will evolve over time to include new engagement and monetization features.


## Features available in the SDK

The Microsoft Store Engagement and Monetization SDK provides libraries and tools that support the following features.

### Run experiments with A/B testing for UWP apps

Run A/B tests in your Universal Windows Platform (UWP) apps to measure the effectiveness of features on some customers before you release the features to everyone. After you define an experiment in your Dev Center dashboard, use the [ExperimentClient](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.engagementclient.aspx) class to get variations for your experiment in your app, use this data to modify the behavior of the feature you are testing, and then use the [Log](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.storeservicescustomevents.log.aspx) method to send view event and conversion events to Dev Center. Finally, use your dashboard to view the results and manage the experiment.

For more information, see [Run experiments with A/B testing](run-app-experiments-with-a-b-testing.md).

### App feedback for UWP apps

Use the [Feedback](https://msdn.microsoft.com/library/windows/apps/microsoft.services.store.engagement.feedback.aspx) class in your UWP apps to direct your Windows 10 customers to Feedback Hub, where they can submit problems, suggestions, and upvotes. Then, manage this feedback in the [Feedback report](../publish/feedback-report.md) in the Dev Center dashboard.

For more information, see [Launch Feedback Hub from your app](launch-feedback-hub-from-your-app.md).

### Display ads in your apps

Increase your revenue by displaying banner ads or video interstitial ads from Microsoft in UWP apps as well as Windows 8.1 and Windows Phone 8.x apps. You can also maximize your ad fill rates by using ad mediation to display ads from multiple ad network providers.

For more information, see [Display ads in your app](display-ads-in-your-app.md).

>**Note** The advertising features from previous releases of the Universal Ad Client SDK, Ad Mediator extension and Microsoft Advertising SDK are now included in the Microsoft Store Monetization and Engagement SDK.

### API reference

For reference documentation about the APIs in the SDK, see [Microsoft Store Engagement and Monetization SDK API reference](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx).

## Install the SDK

To install the Microsoft Store Monetization and Engagement SDK:

1.  Close all instances of Visual Studio 2013 or Visual Studio 2015 and uninstall any previous versions of the Universal Ad Client SDK, Ad Mediator extension or Microsoft Advertising SDK.
2.  Download and install the [SDK](http://aka.ms/store-em-sdk). It may take a few minutes to install. Be sure and wait until the process has finished.
3.  Restart Visual Studio.

Microsoft periodically releases new versions of the Microsoft Store Monetization and Engagement SDK with performance improvements and new features. If you have existing projects that use the Microsoft Store Monetization and Engagement SDK and you want to use the latest version, simply download and install the latest version of the SDK.

The advertising features from previous releases of the Universal Ad Client SDK, Ad Mediator extension and Microsoft Advertising SDK are now included in the Microsoft Store Monetization and Engagement SDK. If you have existing Visual Studio 2015 or Visual Studio 2013 projects that use advertising features from one of these previous releases, you can continue working with your projects without any changes after you install the Microsoft Store Monetization and Engagement SDK.

>**Note**  To install the Microsoft Store Engagement and Monetization SDK with Visual Studio 2015, you must have version 1.1 or later of the Visual Studio Tools for Universal Windows Apps installed. For more information about this update to the Visual Studio Tools for Universal Windows Apps, see the [release notes](http://go.microsoft.com/fwlink/?LinkID=624516).

## Framework packages in the SDK

The following library in the Microsoft Store Monetization and Engagement SDK is configured as a *framework package*:

* Microsoft.Advertising.dll (for UWP app projects only). This library contains the advertising APIs in the **Microsoft.Advertising** and **Microsoft.Advertising.WinRT.UI** namespaces.

This means that after you install the SDK on your development computer, this library is automatically updated through Windows Update whenever we publish new versions of the libraries with fixes and performance improvements. This helps to ensure that you always have the latest available version of the library installed on your development computer.

In addition, after a user installs a version of your app that uses this library, the library will also automatically be updated on their device whenever we publish new versions of the library with fixes and performance improvements. This means that users will always have the most current version of the library, without any need for you to publish updated versions of your app to the Store.

However, if we release a new version of the SDK that introduces new APIs or features in this library, you will need to install the latest version of the SDK to use those features. In this scenario, you would also need to publish your updated app to the Store.

Other libraries in the SDK, including Microsoft.Advertising.dll for other target platforms and the libraries for ad mediation, are not currently configured as framework libraries.

## Related topics

* [Run experiments with A/B testing](run-app-experiments-with-a-b-testing.md)
* [Microsoft Store Engagement and Monetization SDK API reference](https://msdn.microsoft.com/library/windows/apps/mt691886.aspx)
* [Launch Feedback Hub from your app](launch-feedback-hub-from-your-app.md)


<!--HONumber=Mar16_HO5-->


