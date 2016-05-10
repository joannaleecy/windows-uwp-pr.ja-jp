---
author: mcleblanc
title: App lifecycle
description: This topic describes the lifecycle of a Universal Windows Platform (UWP) app, from the time it is activated until it is closed.
ms.assetid: 6C469E77-F1E3-4859-A27B-C326F9616D10
---

# App lifecycle


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Important APIs**

-   [**Windows.UI.Xaml.Application class**](https://msdn.microsoft.com/library/windows/apps/br242324)
-   [**Windows.ApplicationModel.Activation namespace**](https://msdn.microsoft.com/library/windows/apps/br224766)

This topic describes the lifecycle of a Universal Windows Platform (UWP) app, from the time it is activated until it is closed. Many users spread their work and play across multiple devices and apps. Users now expect your app to remember its state as they multitask on their device. For example, they expect the page to be scrolled to the same position and all of the controls to be in the same state as before. By understanding the application lifecycle of launching, suspending, and resuming, you can provide this kind of seamless behavior.

## App execution state


This illustration represents the transitions between app execution states. We describe these states and events in the next several sections. For more info about each state transition and what your app should do in response, see the reference for the [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) enumeration.

![state diagram showing transitions between app execution states](images/state-diagram.png)

## Deployment


In order for an app to be activated it must first be deployed. You app is deployed when a user installs your app or when you use Visual Studio to build and run your app during development and testing. For more info on this and on advanced deployment scenarios, see [App packages and deployment](https://msdn.microsoft.com/library/windows/apps/hh464929).

## App launch


An app is launched when it is in the **NotRunning** state and the user taps the app tile on the start screen or on the application list. Frequently used apps may also be prelaunched to optimize responsiveness (see [Handle app prelaunch](handle-app-prelaunch.md)). An app could be in the **NotRunning** state because it has never been launched, because it was running but then crashed, or because it was suspended but then couldn't be kept in memory and was terminated by the system. Launching is different then activation. Activation is when your app is activated via a contract or extension such as the Search contract.

The [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method is called when an app is launched— including when the app is currently suspended in memory. The [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) parameter contains the previous state of your app and the activation arguments.

When the user switches to your terminated app, the system sends the [**LaunchActivatedEventArgs**](https://msdn.microsoft.com/library/windows/apps/br224731) args with [**Kind**](https://msdn.microsoft.com/library/windows/apps/br224728) set to **Launch** and [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) set to **Terminated** or **ClosedByUser**. The app should load its saved application data and refresh its displayed content.

If the value of [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) is **NotRunning**, the app should start over as if it were being initially launched.

When an app is launched, Windows displays a splash screen for the app. To configure the splash screen, see [Adding a splash screen](https://msdn.microsoft.com/library/windows/apps/xaml/hh465331).

While the splash screen is displayed, your app should ready its user interface. The primary tasks for the app are to register event handlers and set up any custom UI it needs for loading the initial page. These tasks should only take a few seconds. If an app needs to request data from the network or needs to retrieve large amounts of data from disk, these activities should be completed outside of activation. An app can use its own custom loading UI or an extended splash screen while it waits for these long running operations to finish. See [Display a splash screen for more time](create-a-customized-splash-screen.md) and the [Splash screen sample](http://go.microsoft.com/fwlink/p/?linkid=234889) for more info. After the app completes activation, it enters the **Running** state and the splash screen disappears (and all its resources and objects are cleared).

## App activation


An app can be activated by the user through a variety of extensions and contracts such as the Share contract. For a list of ways your app can be activated, see [**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693).

The [**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) class defines methods you can override to handle the various activation types. Several of the activation types have a specific method that you can override such as such as [**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331), [**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/br242336), etc. For the other activation types, override the [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) method.

Your app's activation code can test to see why it was activated and whether it was already in the **Running** state.

Your app can restore previously saved data during activation in the event that the operating system terminated your app, and the user subsequently re-launched it. Windows may terminate your app after it has been suspended for a number of reasons. The user may manually close your app, or sign out, or the system may be running low on resources. If the user launches your app after Windows has terminated it, the app receives an [**Application.OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) callback and the user sees your app's splash screen until the app is activated. You can use this event to determine whether your app needs to restore the data which it had saved when it was last suspended, or whether you must load your app’s default data. Because the splash screen is up, your app code can invest some processing time to get this done without there being any apparent delay to the user although previously-mentioned concerns about long-running operations also apply if you're restarting or continuing.

The [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) event data includes a [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) property that tells you which state your app was in before it was activated. This property is one of the values from the [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) enumeration:

| Reason for termination                                                        | Value of [**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) property | Action to take          |
|-------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------|-------------------------|
| Terminated by the system (for example, because of resource constraints)       | **Terminated**                                                                                          | Restore session data    |
| Closed by the user, or process-terminated by user                             | **ClosedByUser**                                                                                        | Start with default data |
| Unexpectedly terminated, or app has not run during the *current user session* | **NotRunning**                                                                                          | Start with default data |

 

**Note**  *Current user session* is based on Windows logon. So long as the current user hasn't explicitly logged off, shut down, or Windows hasn't restarted for other reasons, the current user session persists across events such as lock screen authentication, switch-user and so on.

 

[**PreviousExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224729) could also have a value of **Running** or **Suspended**, but in these cases your app was not previously terminated and therefore you don’t have to restore any data because everything is already in memory.

**Note**  

If you log on using the computer's Administrator account, you can't activate any UWP apps.

For more info, see [App extensions](https://msdn.microsoft.com/library/windows/apps/hh464906).

### **OnActivated** versus specific activations

The [**OnActivated**](https://msdn.microsoft.com/library/windows/apps/br242330) method is the means to handle all possible activation types. However, it's more common to use different methods to handle the most common activation types, and use **OnActivated** only as the fallback method for the less common activation types. For example, [**Application**](https://msdn.microsoft.com/library/windows/apps/br242324) has an [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method that's invoked as a callback whenever [**ActivationKind**](https://msdn.microsoft.com/library/windows/apps/br224693) is **Launch**, and this is the typical activation for most apps. There are 6 more **On\*** methods for specific activations: [**OnCachedFileUpdaterActivated**](https://msdn.microsoft.com/library/windows/apps/hh701797), [**OnFileActivated**](https://msdn.microsoft.com/library/windows/apps/br242331), [**OnFileOpenPickerActivated**](https://msdn.microsoft.com/library/windows/apps/hh701799), [**OnFileSavePickerActivated**](https://msdn.microsoft.com/library/windows/apps/hh701801), [**OnSearchActivated**](https://msdn.microsoft.com/library/windows/apps/br242336), [**OnShareTargetActivated**](https://msdn.microsoft.com/library/windows/apps/hh701806). Starting templates for a XAML app have an implementation for **OnLaunched** and a handler for [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341).

## App suspend


The system suspends your app whenever the user switches to another app or to the desktop or Start screen. You app may also be suspended when the device enters a low power state. The system resumes your app whenever the user switches back to it. When the system resumes your app, the content of your variables and data structures is the same as it was before the system suspended the app. The system restores the app exactly where it left off, so that it appears to the user as if it's been running in the background.

When the user moves an app to the background, Windows waits a few seconds to see whether the user will immediately switch back to the app so that the transition will be fast if they do. If the user does not switch back within this time window, Windows suspends the app.

If you need to do asynchronous work when your app is being suspended you will need to defer completion of suspend until after your work completes. You can use the [**GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) method on the [**SuspendingOperation**](https://msdn.microsoft.com/library/windows/apps/br224688) object (available via the event args) to delay completion of suspend until after you call the [**Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) method on the returned [**SuspendingDeferral**](https://msdn.microsoft.com/library/windows/apps/br224684) object.

The system attempts to keep your app and its data in memory while it's suspended. However, if the system does not have the resources to keep your app in memory, the system will terminate your app. Apps don't receive a notification that they are being terminated, so the only opportunity you have to save your app's data is during suspension. When an app determines that it has been activated after being terminated, it should load the application data that it saved during suspend so that the app is in the same state as if was before it was suspended. When the user switches back to a suspended app that has been terminated, the app should restore its application data in its [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method. The system doesn't notify an app when it's terminated, so your app must save its application data and release exclusive resources and file handles when it's suspended, and restore them when the app is activated after termination.

If an app has registered an event handler for the [**Application.Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) event, this code is called immediately before the app is suspended. You can use the event handler to save app and user data. We recommended that you use the application data APIs for this purpose because they are guaranteed to complete before the app enters the **Suspended** state. For more info, see [Store and retrieve settings and other app data](https://msdn.microsoft.com/library/windows/apps/mt299098).

You should also release exclusive resources and file handles so that other apps can access them while your app isn't using them. Examples of exclusive resources include cameras, I/O devices, external devices, and network resources. Explicitly releasing exclusive resources and file handles helps to ensure that other apps can access them while your app isn't using them. When the app is activated after termination, it should reopen its exclusive resources and file handles.

Generally, your app should save its state and release its resources and file handles immediately when handling the suspending event, and the code should not take more than a second to complete. If an app does not return from the suspending event within a few seconds, Windows assumes that the app has stopped responding and terminates it.

There are some app scenarios where the app must continue to run to complete background tasks. For example, your app can continue to play audio in the background; for more info, see [Background Audio](https://msdn.microsoft.com/library/windows/apps/mt282140)). Also, background transfer operations continue even if your app is suspended or even terminated; for more info, see [How to download a file](https://msdn.microsoft.com/en-us/library/windows/apps/xaml/jj152726.aspx#downloading_a_file_using_background_transfer)).

For guidelines, see [Guidelines for app suspend and resume](https://msdn.microsoft.com/library/windows/apps/hh465088).

**A note about debugging using Visual Studio:  **Visual Studio prevents Windows from suspending an app that is attached to the debugger. This is to allow the user to view the Visual Studio debug UI while the app is running. When you're debugging an app, you can send it a suspend event using Visual Studio. Make sure the **Debug Location** toolbar is being shown, then click the **Suspend** icon.

## App visibility


When the user switches from your app to another app, your app is no longer visible but remains in the **Running** state until Windows suspends it. If the user switches away from your app but activates or switches back to it before it can suspended, the app remains in the **Running** state.

Your app doesn't receive an activation event when its visibility changes because the app is still running. Windows simply switches to and from the app as necessary. If your app needs to do something when the user switches away and back, handle the [**Window.VisibilityChanged**](https://msdn.microsoft.com/library/windows/apps/hh702458) event.

Do not rely on a specific ordering of these events.

## App resume


A suspended app is resumed when the user switches to it or when it is the active app when the device comes out of a low power state.

For an enumeration of the states that your app can be in when your app is resumed, see [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694). When an app is resumed from the **Suspended** state, it enters the **Running** state and continues from where it was when it was suspended. No app data stored in memory is lost. Therefore, most apps don't need to do anything when they are resumed. However, the app could have been suspended for hours or even days. If your app has content or network connections that may have gone stale, these should be refreshed when the app resumes. If an app registered an event handler for the [**Application.Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event, it is called when the app is resumed from the **Suspended** state. You can refresh your app content and data using this event handler.

If a suspended app is activated to participate in an app contract or extension, it receives the **Resuming** event first, then the **Activated** event.

While en an app is suspended, it does not receive any of the network events that it registered to receive. These network events are not queued, they are simply missed. Therefore, your app should test the network status when it is resumed.

**Note**  Because the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event is not raised from the UI thread, a dispatcher must be used if the code in your resume handler communicates with your UI.

 

For guidelines, see [Guidelines for app suspend and resume](https://msdn.microsoft.com/library/windows/apps/hh465088).

## App close


Generally, users don't need to close apps, they can let Windows manage them. However, users can choose to close an app using the close gesture or by pressing Alt+F4 on Windows or by using the task switcher on Windows Phone.

There's no special event to indicate that the user closed the app.

After an app has been closed by the user, it's first suspended and then terminated, and enters the **NotRunning** state.

In Windows 8.1 and later, after an app has been closed by the user, the app is removed from the screen and switch list but not explicitly terminated.

If an app has registered an event handler for the **Suspending** event, it is called when the app is suspended. You can use this event handler to save relevant application and user data to persistent storage.

**Closed-by-user behavior:  **If your app needs to do something different when it is closed by the user than when it is closed by Windows, you can use the activation event handler to determine whether the app was terminated by the user or by Windows. See the descriptions of **ClosedByUser** and **Terminated** states in the reference for the [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) enumeration.

We recommend that apps not close themselves programmatically unless absolutely necessary. For example, if an app detects a memory leak, it can close itself to ensure the security of the user's personal data. When you close an app programmatically, the system treats it as an app crash.

## App crash


The system crash experience is designed to get users back to what they were doing as quickly as possible. You shouldn't provide a warning dialog or other notification because that will delay the user.

If your app crashes, stops responding, or generates an exception, a problem report is sent to Microsoft per the user's [feedback and diagnostics settings](http://go.microsoft.com/fwlink/p/?LinkID=614828). Microsoft provides a subset of the error data in the problem report to you so that you can use it to improve your app. You'll be able to see this data in your app's Quality page in your Dashboard.

When the user activates an app after it crashes, its activation event handler receives an [**ApplicationExecutionState**](https://msdn.microsoft.com/library/windows/apps/br224694) value of **NotRunning**, and should display its initial UI and data. After a crash, don't routinely use the app data you would have used for **Resuming** with **Suspended** because that data could be corrupt; see [Guidelines for app suspend and resume](https://msdn.microsoft.com/library/windows/apps/hh465088).

## App removal


When a user deletes your app, the app is removed, along with all its local data. Removing an app doesn't affect the user's data that was stored in common locations such as the Documents or Pictures libraries.

## App lifecycle and the Visual Studio project templates


The basic code that is relevant to the app lifecycle is provided in the starting Visual Studio project templates. The basic app handles launch activation, provides a place for you to restore your app data, and displays the primary UI even before you've added any of your own code. For more info, see [C#, VB, and C++ project templates for apps](https://msdn.microsoft.com/library/windows/apps/hh768232).

## Application lifecycle key APIs


-   [**Windows.ApplicationModel**](https://msdn.microsoft.com/library/windows/apps/br224691) namespace
-   [**Windows.ApplicationModel.Activation**](https://msdn.microsoft.com/library/windows/apps/br224766) namespace
-   [**Windows.ApplicationModel.Core**](https://msdn.microsoft.com/library/windows/apps/br205865) namespace
-   [**Windows.UI.Xaml.Application**](https://msdn.microsoft.com/library/windows/apps/br242324) class (XAML)
-   [**Windows.UI.Xaml.Window**](https://msdn.microsoft.com/library/windows/apps/br209041) class (XAML)

**Note**  
This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

## Related topics


* [Guidelines for app suspend and resume](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [Handle app prelaunch](handle-app-prelaunch.md)
* [Handle app activation](activate-an-app.md)
* [Handle app suspend](suspend-an-app.md)
* [Handle app resume](resume-an-app.md)

 

 



