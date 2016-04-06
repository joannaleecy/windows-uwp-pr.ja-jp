---
ms.assetid: 772DEBF2-1578-4330-9C14-70BCC6F55005
description: Microsoft provides support for ad mediation, which lets you optimize your in-app advertising revenue by mediating banner ad requests from multiple ad networks.
title: Use ad mediation to maximize revenue
---

#  Use ad mediation to maximize revenue


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Microsoft provides support for ad mediation, which lets you optimize your in-app advertising revenue by mediating banner ad requests from multiple ad networks. Different ad networks may have their own strengths, with some having a higher cost per thousand views (eCPM) or higher fill rate (percentage of ads served when your app makes a request) in certain markets than others. With a single ad network, you may end up with unfilled ad requests, causing you to lose potential revenue. Ad mediation helps you maximize your ad monetization by making sure you are always showing a live ad.

Ad mediation support is available through the [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk). After you've installed the SDK and added the ad mediator control to your app, you'll be able to specify how often each network is used by updating your mediation configuration in Dev Center. You can optimize this by market, so that you're using the most effective ad networks in the appropriate regions. And you can make changes to how each ad network is used without having to republish your app.

## Get started with ad mediation


Follow these steps to set up and configure ad mediation in your app:

1.  Review the list of ad networks and project types supported by ad mediation, set up accounts with the ad networks you want to use, and follow the instructions from each ad network to onboard an app. For more information, see [Select and manage your ad networks](select-and-manage-your-ad-networks.md).

2.  Install the [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk) with Visual Studio 2015 or Visual Studio 2013.

3.  In Visual Studio, open your project or create a new project. Open the page where you want to host ads and drag an **AdMediatorControl** to the page. If you are using Microsoft advertising, adjust the height and width of the control to fit the supported ad sizes. For more information, see [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md).

4.  Run **Connected Services** to choose the ad networks you want to target and configure the required parameters for each ad network. For more information, see [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md).

5.  Test the ad mediation implementation in your app. For more information, see [Test your ad mediation implementation](test-your-ad-mediation-implementation.md).

6.  Submit your app to the Windows Dev Center dashboard and configure your ad mediation settings in the dashboard. For more information, see [Submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md).

7.  Review your ad mediation reports in the Dev Center dashboard. For more information, see [Ad mediation report](https://msdn.microsoft.com/library/windows/apps/mt148521)

## Using Microsoft advertising without ad mediation


If you don't want to use ad mediation or if your project type isn't currently supported by ad mediation, you can still serve banner ads from Microsoft without using ad mediation. For more information, see [AdControl in XAML and .NET](https://msdn.microsoft.com/library/mt313186.aspx) and [AdControl in HTML 5 and JavaScript](https://msdn.microsoft.com/library/mt313130.aspx).

## Related topics

* [Select and manage your ad networks](select-and-manage-your-ad-networks.md)
* [Add and use the ad mediation control](add-and-use-the-ad-mediator-control.md)
* [Test your ad mediation implementation](test-your-ad-mediation-implementation.md)
* [Submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md)
* [Troubleshoot ad mediation](troubleshoot-ad-mediation.md)
 

 


<!--HONumber=Mar16_HO5-->


