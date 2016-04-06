---
ms.assetid: 86D9D3CF-8FDC-4B67-881B-DF33A1BEE8BF
description: Before using ad mediation, you'll need to set up accounts with each ad network that you’d like to use in your apps.
title: Select and manage your ad networks
---

# Select and manage your ad networks


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Before using ad mediation, you'll need to set up accounts with each ad network that you’d like to use in your apps. We recommend doing this before you add the ad mediator control to your Microsoft Visual Studio project. We also recommend that you set up accounts with as many ad networks as possible, so you have maximum flexibility to optimize your ad mediation performance.

## Supported ad networks and project types

Currently, ad mediation is supported for the following ad networks and project types.

|  Ad network    | Universal Windows Platform (UWP) app using C# or Visual Basic with XAML | Windows 8.1 app using C# or Visual Basic with XAML | Windows Phone 8.1 app using C# or Visual Basic with XAML | Windows Phone 8.x Silverlight app |               
|-------------------------------------------------------------------------|----------------------------------------------------|----------------------------------------------------------|-----------------------------------|---------------|
| [Microsoft](#microsoft)                         | **Supported**                                      | **Supported**                                            | **Supported**                     | **Supported** |
| [AdDuplex](#adduplex)                                                   | **Supported**                                      | **Supported**                                            | **Supported**                     | **Supported** |
| [Smaato](#smaato)                                                       | Not supported                                      | **Supported**                                            | **Supported**                     | **Supported** |
| [AdMob (Google)](#admob)                                                | Not supported                                      | Not supported                                            | Not supported                     | **Supported** |
| [Inneractive](#inneractive)                                             | Not supported                                      | Not supported                                            | Not supported                     | **Supported** |
| [Vserv VMAX](#vserv)                                                    | Not supported                                      | Not supported                                            | **Supported**                     | Not supported | 

Some project types, such as C++ with XAML and JavaScript with HTML, are not currently supported by ad mediation. For these project types, you can show ads from Microsoft without using ad mediation. For more information, see [AdControl in XAML and .NET](https://msdn.microsoft.com/library/mt313186.aspx) and [AdControl in HTML 5 and JavaScript](https://msdn.microsoft.com/library/mt313130.aspx).

## Specific parameters and details for each network


Here are the specific details you'll need for each ad network, including how to set up your account and how to onboard an app. We also list the required parameters that you need to provide when you [submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md) (and/or in Connected Services for [testing your ad mediation implementation](test-your-ad-mediation-implementation.md)). For more details about using a specific ad network, visit its website.

In addition to the required parameters, each ad network also has additional optional parameters you can set via code in your app. For examples, see [Optional ad network parameters](#optionalparameters) later in this topic. For the complete list of optional parameters, see the documentation provided by each ad network. Some of these parameters will be ignored or overwritten by ad mediation, and these are listed in the sections below. For example, parameters related to current location are usually overwritten with information about the customer's location that is determined by the location capability within the app itself.

Note that when you [add the ad mediator control](add-and-use-the-ad-mediator-control.md) and specify which ad networks to use, Visual Studio attempts to fetch the required assemblies programmatically for some ad networks. If there are any assemblies that cannot be automatically retrieved, you can install them using the links shown below for each ad network.

### Microsoft

| Website                        | To configure ad network parameters, use the [Monetize with ads](https://msdn.microsoft.com/library/windows/apps/mt170658) page on the [Windows Dev Center dashboard](https://dev.windows.com/overview).   |
|--------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK location                   | [Microsoft Store Engagement and Monetization SDK](http://aka.ms/store-em-sdk).                                                                                                                                                                                                                         |
| Onboarding an app              | Add the ad mediation control to your app, and submit your app to the Windows Dev Center dashboard.                                                                                                                                                                                                            |
| Required parameters            | ApplicationId and AdUnitId: These parameters are automatically filled in for you when you submit your app package, based on the contents of your app. However, you can optionally edit these parameters when you [submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md). <br> <br> Height and Width (only required for Windows Phone 8 Silverlight and Windows Phone 8.1 Silverlight).                                                                                                                                                                                                           |
| Overwritten/ignored parameters | Latitude (overwritten)  <br><br> Longitude (overwritten) <br><br> AutoRefreshIntervalInSeconds (ignored) <br><br> IsAutoRefreshEnabled (ignored) <br><br> IsAutoCollapsedEnabled (ignored) <br><br> IsEngaged (ignored) <br><br> IsSuspended (ignored) |

 

### AdDuplex

| Website                        | [http://adduplex.com](http://go.microsoft.com/fwlink/p/?LinkId=518028)      |
|--------------------------------|-----------------------------------------------------------------------------|
| SDK location                   | First, try to let the ad mediator control retrieve the assemblies through Connected Services as described in [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md). If you need to download them manually, go to the [Getting Started](http://go.microsoft.com/fwlink/p/?LinkId=518029) section on the AdDuplex website. |
| Onboarding an app              | In the AdDuplex portal, create a new app.                                                                                                                                                                                                                                                                                                        |
| Required parameters            | AppKey <br><br> AdUnitId <br><br> Size (only required for Windows 8.1 XAML)  |
| Overwritten/ignored parameters | Latitude (overwritten) <br><br> Longitude (overwritten) <br><br> AutoRefreshIntervalInSeconds (ignored) <br><br> IsAutoRefreshEnabled (ignored) <br><br> IsAutoCollapsedEnabled (ignored) <br><br> IsEngaged (ignored) <br><br> IsSuspended (ignored) |
 

### Smaato

| Website                        | [http://www.smaato.com/](http://go.microsoft.com/fwlink/p/?LinkId=518030)                                                                                                                                                                                                        |
|--------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK location                   | First, try to let the ad mediator control retrieve the assemblies through Connected Services as described in [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md). If you need to download them manually, go to the Downloads tab in the Smaato portal. |
| Onboarding an app              | In the Smaato portal, go to My Spaces and generate a new Adspace.                                                                                                                                                                                                                |
| Required parameters            | Pub <br> <br> Adspace <br> <br> Height and Width (only required for Windows 8.1 XAML)  |
| Overwritten/ignored parameters | Gps (overwritten)                                                                                                                                                                                                                                                                |

 

### AdMob (Google)

| Website                        | [http://apps.admob.com](http://go.microsoft.com/fwlink/p/?LinkId=518031)                                               |
|--------------------------------|------------------------------------------------------------------------------------------------------------------------|
| SDK location                   | Get the Windows Phone 8 SDK from the [Google Mobile Ads SDK website](http://go.microsoft.com/fwlink/p/?LinkId=518032). |
| Onboarding an app              | In the AdMob portal, select Monetize new app.                                                                          |
| Required parameters            | AdUnitID <br> <br> Format                                                                                              |
| Overwritten/ignored parameters | Location (overwritten)  <br><br> ForceTesting (ignored) <br><br> Refresh Rate (ignored)                                |
 

### Inneractive

| Website             | [http://inner-active.com](http://go.microsoft.com/fwlink/p/?LinkId=518035)                                                                                                                                                                                                                                                             |
|---------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK location        | First, try to let the ad mediator control retrieve the assemblies through Connected Services as described in [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md). If you need to download them manually, sign in to your account and go to the SDK tab in the Dashboard to download the Windows Phone 8 SDK. |
| Onboarding an app   | In the Inneractive portal, create a new app.                                                                                                                                                                                                                                                                                           |
| Required parameters | AppID <br> <br> AdType (either IaAdType_Banner or IaAdType_Text)                                                                               |
 

### Vserv VMAX

| Website             | [http://www.vmax.com](http://www.vmax.com)                                                                                                                                                                                                                                                                         |
|---------------------|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| SDK location        | First, try to let the ad mediator control retrieve the assemblies through Connected Services as described in [Add and use the ad mediator control](add-and-use-the-ad-mediator-control.md). If you need to download them manually, go to the [SDK](http://go.microsoft.com/fwlink/?LinkId=627078) section on the VMAX website. |
| Onboarding an app   | Obtain the Adspot ID for your app from the VMAX website (the Adspot ID is called ZoneId in the VMAX APIs).                                                                                                                                                                                                                     |
| Required parameters | ZoneId                                                                                                                                                                                                                                                                                                                         |12345

 

## Optional ad network parameters


In addition to the required parameters, each ad network also has additional optional parameters you can set via code in your app. For the complete list of optional parameters, see the documentation provided by each ad network. To set these optional parameters in your code, use the **AdSdkOptionalParameters** property of your **AdMediatorControl** object.

The following example demonstrates how to set the **CountryOrRegion** parameter for Microsoft advertising.

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["CountryOrRegion"] = "IN";
```

The following example demonstrates how to set the **Width** and **Height** parameters for Smaato.

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Width"] = 300;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Height"] = 250;
```

## Related topics

* [Add and use the ad mediation control](add-and-use-the-ad-mediator-control.md)
* [Test your ad mediation implementation](test-your-ad-mediation-implementation.md)
* [Submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md)
* [Troubleshoot ad mediation](troubleshoot-ad-mediation.md)
 

 


<!--HONumber=Mar16_HO5-->


