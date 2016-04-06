---
ms.assetid: 69E05E56-B5F0-4D4C-A1FF-B6EAFF5D0E28
description: During the submission process, you can configure the ad mediation behavior you'd like to see. You'll be able to adjust this later without having to make code changes or submit new packages.
title: Submit your app and configure ad mediation
---

# Submit your app and configure ad mediation


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Once you’ve built your app to include all of the ad networks you may want to use, and tested it to ensure everything’s working, you’re ready to submit the app. During the submission process, you can configure the ad mediation behavior you'd like to see. You'll be able to adjust this later without having to make code changes or submit new packages.

## Create a baseline configuration for an app package


When you upload your packages, Dev Center automatically detects that you're using ad mediation and identifies which ad networks you’re using. On the **Packages** page, you’ll see a **Configure ad mediation** link. Click this link to go to the [Monetize with ads](https://msdn.microsoft.com/library/windows/apps/mt170658) page, where you’ll configure your mediation logic in the **Windows ad mediation** section. For more information about the other sections on this page, see Monetize with ads.

The first time you configure ad mediation settings for your app, you’ll create a baseline configuration. After that's set up, you can add market-specific configurations to take advantage of specific ad networks’ strengths in different markets. If you choose not to configure your ad mediation settings before submitting your app, Dev Center automatically applies [default settings](#default-ad-mediation-settings), and you can [modify those settings later](#optimize-ad-mediation-after-the-app-has-been-published).

The following steps describe how to create a baseline configuration in the **Windows ad mediation** section of the **Monetize with ads** page.

1.  Under **Configure mediation for**, make sure the app package you want to configure is selected.
2.  Under **Target**, make sure **Baseline** is selected.
3.  Under **Refresh rate**, choose the length of the mediation cycle (how frequently new ads should be shown). The duration must be between 30 and 120 seconds.
    **Note**  If you've already configured a refresh rate in any of your ad network portals, make sure you set the same refresh rate here.
4.  Next, the **Windows ad mediation** section lists all of the ad networks used by your app and provides two different ways to specify how often your app should use each ad network. Choose one of these options in the **Mediation type** drop-down:

    -   **Order by weight**. Choose this option to apply percentage values to each ad network that specify how often they should be used by your app. The total percentages you set for all ad networks must add up to exactly 100%. For more information, see [Order ad networks by weight](#order-ad-networks-by-weight).
    -   **Order by rank**. Choose this option to apply a ranking number to each ad network, from 1 to *n*, that specifies how often your app should use each ad network. For more information, see [Order ad networks by rank](#order-ad-networkds-by-rank).

    Dev Center automatically applies [default settings](#default-ad-mediation-settings) that specify how often your app should use each ad network.

5.  In the list of ad networks used by your app, click the drop-down arrow for each ad network provider to view the required parameters for each network, and enter the required parameters. For a list of the parameters, see [Select and manage your ad networks](select-and-manage-your-ad-networks.md).

    In the expanded list of parameters for each network, you can optionally use the **Timeout** field to specify the number of seconds (from 2-120) for which ad mediation should wait after requesting an ad from that ad network before abandoning that request and making a request to another network instead. If you already [specify this value in your code](add-and-use-the-ad-mediator-control.md#set-timeouts), the value you specify in code overrides the value you specify here.

    If you are using Microsoft advertising, make note of the following:

    -   The parameters for **Microsoft Advertising** are filled in for you based on the contents of your app package. You can optionally specify your own **Application Id** and **Ad Unit Id** values for **Microsoft Advertising**.
    -   In addition to **Microsoft Advertising**, there is also a row for **Microsoft Advertising house ads**. House ads provide a way to create free ads that promote one of your apps in your other apps. Even though house ads are free, your allotment of house ads comes from the same pool as other ad networks. Therefore, if you allocate any ad requests to **Microsoft Advertising house ads**, you are choosing to use that percentage of your total ad supply for house ads. If you allocate ad requests to house ads, you must also create a house ad campaign for at least one other app registered to your developer account. For more information, see [About House ads](https://msdn.microsoft.com/library/windows/apps/mt148566).

6.  Click **Save** to save the baseline configuration.

### Order ad networks by weight

Choose this option in the **Mediation type** drop-down to specify percentage values that specifies how often your app should use each ad network. The total percentages you set for all ad networks must add up to exactly 100%.

To automatically spread requests equally across all of your networks, click **Distribute ad requests equally across all your active ad networks**. To spread requests unequally, use the slider controls to indicate how often your app should use each ad network. The total percentages you set for all ad networks must add up to exactly 100%. When dragging the slider controls, you have several options:

-   If you drag the slider to a number, the number indicates the percentage of time that this ad network will be called as the app's first choice in a mediation cycle.
-   If you drag the slider to **Backup**, this indicates that the ad network should be called only if none of the ad networks with a designated percentage can provide an ad. This is equivalent to setting the percentage at 0%.
-   If you drag the slider to **Inactive**, this indicates that this ad network will never be called. The assemblies for the ad network will remain in the package, but the mediator will not attempt to invoke them. You can set this option in market-specific configurations to exclude ad networks that are known to perform poorly in, or don’t support, a certain market.
-   When you adjust the percentage for an ad network, any other slider controls where you have selected a value other than **Backup** will automatically adjust so that the total distribution adds up to 100%. If you select the **Lock** check box for an ad network, that ad network will remain fixed at its currently selected value. You can then adjust the values for the other ad networks without affecting the value for the locked ad network

### Order ad networks by rank

Choose this option in the **Mediation type** drop-down to apply a ranking number to each ad network, from 1 to *n*, that specifies how often your app should use each ad network.

If you clear the **Active** check box for an ad network, this indicates that this ad network will never be called. The assemblies for the ad network will remain in the package, but the mediator will not attempt to invoke them. You can set this option in market-specific configurations to exclude ad networks that are known to perform poorly in, or don’t support, a certain market.

### Default ad mediation settings

By default, Dev Center applies the following ad mediation settings to your app on the **Monetize with ads** page. These same default values are also applied if you choose not to configure ad mediation before you submit your app.

-   If your app uses Microsoft advertising, **Microsoft Advertising** is set to 100 (if you choose **Order by weight**) or 1 (if you choose **Order by rank**), and all other ad networks are set to inactive.
-   If your app does not use Microsoft advertising, all ad networks are set to inactive.

## Create a new target configuration


After you create a baseline configuration for your app, you can create additional configurations to use in specific markets. These new configurations inherit their initial settings from the baseline configuration, but you can adjust details for the specific markets you are supporting for your app.

To create a new target configuration:

1.  Under **Target**, select the market for which you want to create the new configuration.
2.  Update the refresh rate and ad request distribution information as desired.
3.  Click **Save** to save the new configuration.

## Optimize ad mediation after the app has been published


If you want to adjust your ad mediation for a specific app, you can do so at any time without having to resubmit the app. This is useful if you’ve already added ad networks into your app that you hadn’t previously set up accounts for, or if you’re finding that one ad network is not able to fill ads reliably in specific markets. You can make changes to your baseline configuration as well as to market-specific configurations. You can also add or remove market-specific configurations if desired.

To return to the app mediation settings for your app, do one of the following:

-   From your account overview page on the dashboard, click your app under the **Ad mediation** section.
-   From the overview page for your app on the dashboard, expand **Monetization** and click **Monetize with ads**.

## Ad mediation settings and app updates


When you submit an app update, the existing ad mediation configuration information for your app is automatically applied to the updated package if the following conditions are met:

-   The number of **AdMediatorControl** controls is the same as the number of controls in the previous app package, and all of the controls have the same IDs as the previous app package.
-   The list of ad network providers is the same as the previous app package.

If either of these conditions are not met, you must recreate the baseline configuration and any applicable market-specific target configurations for your app.

**Note**  The ID of an **AdMediatorControl** is generated when you drag the control to a design surface in your app. This ID will not change unless you delete the control and then replace it by dragging a new control to the same design surface.

 

## Review ad mediation reports on the unified Dev Center dashboard


To review ad mediation reports, go to the **Analytics** section in Dev Center and click **Ad mediation**. For more information about this report, see [Ad mediation report](https://msdn.microsoft.com/library/windows/apps/mt148521).

## Example scenarios


You can configure your ad networks in a variety of ways to support different goals and scenarios. The examples below show how you might configure your ad mediation using **Order by weight** when you've included three ad networks. We'll use Microsoft advertising, Inneractive, and AdDuplex as our example networks here.

### Example 1

You want to find out the fill rate and cost per thousand views (eCPM) of all the networks, before starting to optimize.

To begin, set each network to use an equal distribution of mediation traffic. You can review each ad network's reports later to help determine the highest performing ad networks for each market.

After a few days or weeks, you'll want to check the fill rate and eCPM in each of the ad network portals. This will help you determine the best ad networks for each market. You can then make adjustments for specific markets (or overall) without having to submit new packages.

### Example 2

You want to use Microsoft advertising first whenever possible. If Microsoft advertising can't provide an ad, you're happy to use any of your other ad networks as backup, with no preference for one over another.

| Ad network            | Configuration |
|-----------------------|---------------|
| Microsoft             | 100%          |
| Inneractive           | Backup        |
| AdDuplex              | Backup        |

### Example 3

You generally want to use Microsoft advertising first. If Microsoft advertising can't provide an ad, you want to make sure Inneractive is called before AdDuplex.

| Ad network            | Configuration |
|-----------------------|---------------|
| Microsoft             | 90%           |
| Inneractive           | 10%           |
| AdDuplex              | Backup        |

### Example 4

You want to use Microsoft advertising and Inneractive equally, so that there's a greater variety of ads in your app than you'd see with just one network always called first. If neither ad network is available, you’ll use AdDuplex as backup.

| Ad network            | Configuration |
|-----------------------|---------------|
| Microsoft             | 50%           |
| Inneractive           | 50%           |
| AdDuplex              | Backup        |


## Related topics

* [Select and manage your ad networks](select-and-manage-your-ad-networks.md)
* [Add and use the ad mediation control](add-and-use-the-ad-mediator-control.md)
* [Test your ad mediation implementation](test-your-ad-mediation-implementation.md)
* [Troubleshoot ad mediation](troubleshoot-ad-mediation.md)
 

 


<!--HONumber=Mar16_HO5-->


