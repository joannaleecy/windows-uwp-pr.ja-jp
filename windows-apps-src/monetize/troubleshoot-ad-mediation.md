---
Description: Following are some solutions to several common development issues related to ad mediation.
title: Troubleshoot ad mediation
ms.assetid: 8728DE4F-E050-4217-93D3-588DD3280A3A
---

# Troubleshoot ad mediation


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Following are some solutions to several common development issues related to ad mediation.

**You can't add an AdMediatorControl to the design surface**  
When you drag the **AdMediatorControl** control to the designer for the first time in a Universal Windows Platform (UWP), Windows 8.1, or Windows Phone 8.1 project using C# or Visual Basic with XAML, Visual Studio adds the required ad mediator assembly reference to your project, but the control isn't added to the designer yet. To add the control, click OK in the message displayed by Visual Studio, wait several seconds for the designer to refresh, and then drag the control back to the designer again.

If you still can't successfully add the control to the designer, make sure your project targets the applicable processor architecture for your app (for example, **x86**) rather than **Any CPU**. The control cannot be added to the designer if the project targets **Any CPU** for the build platform.

**The AdMediatorControl shows the error “&lt;*width*&gt; x &lt;*height*&gt; Not supported” at run time when serving ads from Microsoft**  
Microsoft advertising only supports [certain ad sizes recommended by the Interactive Advertising Bureau (IAB)](add-and-use-the-ad-mediator-control.md#supported-ad-sizes-for-microsoft-advertising). In some cases, even if you set the height and width of the ad mediator control in the designer or in your XAML to one of these supported ad sizes, scaling and rounding issues might cause prevent the ad mediation framework from serving an ad. To avoid this issue, assign the **Width** and **Height** optional parameters for Microsoft advertising in your code to one of the supported ad sizes.

The following code example demonstrates how to assign the **Width** and **Height** optional parameters for Microsoft advertising to 728 x 90.

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Width"] = 728;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Height"] = 90;
```

**Ad mediation does not include location (latitude/longitude) for the ad network**  
If you enable the location capability in your app, the ad mediator control will automatically fetch the latitude/longitude coordinates and provide them to ad networks that support them.

**The Smaato ad control doesn’t line up correctly**  
Try using the optional parameters to set values on the SDK controls:

```
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato][“Margin”] = new Thickness(0, -20, 0, 0);
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato][“Width”] = 50d;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato][“Height”] = 320d;
```

**The AdDuplex ad control does not show with the correct size (it shows as 250×250)**  
Ad mediation does not set any value for the size, so you should change it using the optional parameter Size. For example:

```
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.AdDuplex][“Size”] = “160×600″;
```

**You receive the error “Something is covering the ad control”**  
Ad Duplex will always show an error if the ad is obscured in any way within your app. [Read their solution](http://blog.adduplex.com/2014/01/solving-something-is-covering-ad.mdl) to this error.

**You receive the error "There was a conflict between two files"**  
You have referenced the Microsoft advertising assemblies elsewhere in your app. Ad mediation is designed to work exclusively in your app, and it will not work if other references to the Microsoft advertising assemblies are used. Remove the Microsoft advertising references manually and reinstall the Microsoft Store Engagement and Monetization SDK to clear the error.

## Related topics

* [Select and manage your ad networks](select-and-manage-your-ad-networks.md)
* [Add and use the ad mediation control](add-and-use-the-ad-mediator-control.md)
* [Test your ad mediation implementation](test-your-ad-mediation-implementation.md)
* [Submit your app and configure ad mediation](submit-your-app-and-configure-ad-mediation.md)
 

 


<!--HONumber=Mar16_HO5-->


