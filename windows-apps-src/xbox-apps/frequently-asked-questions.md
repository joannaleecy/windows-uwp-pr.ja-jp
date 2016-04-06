---
title: Frequently asked questions
description: FAQ about UWP on Xbox.
area: Xbox
---

# Frequently asked questions

Things not working the way you expected? 
Look through this page of frequently asked questions. 
Also check out the [Known issues](known-issues.md) topic and the [Developing Universal Windows apps](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/home?forum=wpdevelop) forum. 

### Why are my games and apps not working?

If your games and apps are not working, or if you don’t have access to the store or to Live services, you are probably running in Developer Mode. 
You can tell you’re running in Developer Mode if you select Home and you see a big Dev Home tile on the right side of your screen, instead of the usual Gold/Live content. 
If you want to play games, you can open Dev Home and switch back to Retail Mode by using the **Leave developer mode** button.

### Why can’t I connect to my Xbox One using Visual Studio?

Start by verifying that you are running in Developer Mode, and not in Retail Mode. 
You cannot connect to your Xbox One when it is in Retail Mode. 
You can simply check this by pressing the **Home** button and looking for the Dev Home tile on the right side of your screen. 
If the tile is not there, but instead you see Gold/Live content, you are in Retail Mode. 
You need to run the Dev Mode Activation app to switch to Developer Mode.

For more information, see [Fixing deployment failures](frequently-asked-questions.md#fixing-deployment-failures) later on this page.

### How do I switch between Retail Mode and Developer Mode?

Follow the [Xbox One Developer Mode Activation](devkit-activation.md) instructions to understand more about these states.

### How do I know if I am in Retail Mode or Developer Mode?

Follow the [Xbox One Developer Mode Activation](devkit-activation.md) instructions to understand more about these states. 

You can simply check this by pressing the **Home** button and looking at the right side of the screen. 
If you are in Developer Mode, you will see the Dev Home tile on the right side. 
If you are in Retail Mode, you will see the usual Gold/Live content.

### Will my games and apps still work if I activate Developer Mode?

Yes, you can switch from Developer Mode to Retail Mode, where you can play your games. 
For more information, see the [Xbox One Developer Mode Activation](devkit-activation.md) page. 

> **CAUTION**&nbsp;&nbsp;The Xbox Developer Preview System Update includes experimental and early pre-release software. 
This means that some popular games and apps will not work as expected and you may experience occasional crashes and data loss.

### Will I lose my games and apps or saved changes?

If you decide to leave the developer preview program, you might have to do a factory reset, which will erase all the content on your console. 
If that happens, you will have to reinstall all the games and apps. 
As long as you were online when you played them, your saved games are all saved on your Live account cloud profile, so you won’t lose them.

### How do I leave the developer preview?

See the [Xbox One Developer Mode Deactivation](devkit-deactivation.md) topic for details about how to leave the developer preview.

### I sold my Xbox One and left it in Developer Mode. How do I deactivate Developer Mode?

If you no longer have access to your Xbox One, you can deactivate it in Windows Dev Center. 
For details, see the **Deactivate your console using Windows Dev Center** section in the [Xbox One Developer Mode Deactivation](devkit-deactivation.md#deactivate-your-console-through-windows-dev-center) topic.

### I left the developer preview using Windows Dev Center but I’m in still Developer Mode. What do I do?

Start Dev Home and select the **Leave developer mode** button. 
This will restart your console in Retail Mode. 

### Can I publish my app?

Publishing for apps will be available through Dev Center later in the year. 
UWP apps created and tested on a retail Xbox One will go through the same ingestion, review, and publication process that Windows conducts today, with additional reviews to meet today’s Xbox One standards.

### Can I publish my game?

You can use UWP and your Xbox One in Developer Mode to build and test your games on Xbox One. 
To publish UWP games you must register with [ID@XBOX](http://www.xbox.com/en-us/Developers/id). 
[ID@XBOX](http://www.xbox.com/en-us/Developers/id) provides developers full access to Xbox Live APIs for their games, including Gamerscore and Achievements, 
as well as the ability to take advantage of multiplayer between devices, cloud saves, and all the features of Xbox Live on Xbox One. 
[ID@XBOX](http://www.xbox.com/en-us/Developers/id) can also provide access to Xbox One development kits for games that require access to the maximum potential of the Xbox One hardware.

### Will the standard Game engines work?

Check out the [Known issues](known-issues.md) page for this preview release.

### What capabilities and system resources are available to UWP games on Xbox One? 

See [System resources for UWP apps and games on Xbox One](system-resource-allocation.md) for information.

### If I create a DirectX 12 UWP game, will it run on my Xbox One in Developer Mode?

See [System resources for UWP apps and games on Xbox One](system-resource-allocation.md) for information.

### Will the entire UWP API surface be available on Xbox?

Check out the [Known issues](known-issues.md) page for this preview release.

### Fixing deployment failures

If you can’t deploy your app from Visual Studio, these steps may help you fix the problem. 
If you get stuck, ask for help on the forum.

If Visual Studio cannot connect to your Xbox One:

1. Make sure that you are in Developer Mode (discussed earlier on this page).
2. Make sure that you have set up your development PC correctly. Did you follow *all* of the directions in [Getting started with UWP app development on Xbox One](getting-started.md)? 

3. If you haven’t yet, read through the [Development environment setup](development-environment-setup.md) topic and the [Introduction to Xbox One tools](introduction-to-xbox-tools.md) topic.

4. Make sure that you are using a wired network connection to Xbox One. We’ve seen performance and connectivity issues with some wireless endpoints.

5. Make sure that you can “ping” your console IP address from your development PC.

6. Make sure that you are using the Universal (Unencrypted Protocol) in the Authentication drop-down list on the **Debug** tab. See [Development environment setup](development-environment-setup.md) for more details.

7. Make sure you are not hitting a PIN pairing issue; see "Visual Studio/Xbox PIN pairing failures" in the [FAQ](frequently-asked-questions.md) topic.

If Visual Studio can connect, but deployment is failing (for example you get this error message: "DEP0700 : Registration of the app failed.(0x80073cf9)"):

1. Make sure that your app is not installed by uninstalling it from the Collections app in the Xbox One shell. 

> **Note**&nbsp;&nbsp;Uninstalling your app from Windows Device Portal (WDP) will not resolve the issue.

2. If your issues persist, uninstall your app or game in the Collections app, leave Developer Mode, restart to Retail Mode, and then switch back to Developer Mode. 
This will clear Dev Storage.

3. If your issues persist, follow the steps above and then use **Reset and keep my games & apps** to delete any stored state on your Xbox One. 
Go to Settings > System > Console info & updates > Reset console, and select the **Reset and keep my games & apps** button.

> **Caution**&nbsp;&nbsp;Doing this will delete all saved settings on your Xbox One including wireless settings, user accounts and any game progress that has not been saved to cloud storage.

> **Caution**&nbsp;&nbsp;DO NOT select the **Reset and remove everything** button.
This will delete all of your games, apps, settings and content, deactivate Developer Mode, and remove you console from the Developer Preview group.

### If I’m building an app using HTML/JavaScript, how do I enable Gamepad navigation?

TVHelpers is a set of JavaScript and XAML/C# samples and libraries to help you build great Xbox One and TV experiences in JavaScript and C#. 
TVJS is a library that helps you build premium UWP apps for Xbox One. TVJS includes support for automatic controller navigation, rich media playback, search, and more. 
You can use TVJS with your hosted web app just as easily as with a packaged web UWP app with full access to the Windows Runtime APIs.

For more information see the [TVHelpers](https://github.com/Microsoft/TVHelpers) project and the project [wiki](https://github.com/Microsoft/TVHelpers/wiki).

## See also
- [Known issues with UWP on Xbox One developer preview](known-issues.md)
- [UWP on Xbox One](index.md)


<!--HONumber=Mar16_HO5-->


