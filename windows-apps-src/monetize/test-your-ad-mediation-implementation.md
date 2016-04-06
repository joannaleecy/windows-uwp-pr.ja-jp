---
ms.assetid: 54ECD653-7FC2-4A95-AC5A-972C4FB5A54B
description: Before you submit your app, we recommend testing your ad mediation implementation.
title: Test your ad mediation implementation
---

# Test your ad mediation implementation


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Before you submit your app, we recommend testing your ad mediation implementation.

## Testing with test ad network configuration values


If you run your app without entering ad network configuration by launching **Connected Services** for your project in Visual Studio, ad mediation will automatically use test configuration values when you run your app on your development computer (for Universal Windows Platform (UWP) and Windows 8.1 XAML apps) or on the emulator or device (for Windows Phone apps). This enables you to quickly test your app and make sure it's coded correctly before you've entered your ad network required parameters.

The ad networks will rotate in sequential order, with one network displayed after another for equal amounts of time. Be sure to wait long enough to run through a few cycles so you can view all ad networks and reduce the chance of any temporary connectivity issues which may occur.

Test ads will be displayed for ad networks which support them. Note that the test ads can sometimes look like errors. Be sure to review your events to determine if errors have occurred.

**Note**  When testing a Windows Phone Silverlight app, Google AdMob will always return an **Invalid Request** error since it does not use test metadata. To verify your Google AdMob implementation, you must enter the required parameters, as described in the next section.

 

If you used the event handling code shown in [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md), any errors will be shown in the console output.

## Testing with your ad network configuration values


After testing your app with test configuration data, you’ll want to test your app with the ad network configuration values that you intend to use for the version of your app that you publish to the Windows Store.

First, open the **Add Connected Service** window (Visual Studio 2015) or **Services Manager** window (Visual Studio 2013) and configure each ad network as described in [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md). Enter the required parameters for each ad network.

Now you’re ready to test your app. Make sure to run the app long enough to verify that each ad network can properly display an ad. Check for any exceptions and fix coding errors before you submit your app.

When you submit your app package to the Windows Dev Center dashboard, the configuration values you enter in Visual Studio are automatically populated in the **Monetize with ads** dashboard page. You can modify these values to configure ad network behavior for your app in the Windows Store. For more information, see [Submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md).

## Related topics

* [Select and manage your ad networks](select-and-manage-your-ad-networks.md)
* [Add and use the ad mediation control](add-and-use-the-ad-mediator-control.md)
* [Submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md)
* [Troubleshoot ad mediation](troubleshoot-ad-mediation.md)
 

 





<!--HONumber=Mar16_HO1-->


