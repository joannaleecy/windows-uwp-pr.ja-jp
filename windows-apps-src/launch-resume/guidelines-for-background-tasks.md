---
author: mcleblanc
title: Guidelines for background tasks
description: Ensure your app meets the requirements for running background tasks.
ms.assetid: 18FF1104-1F73-47E1-9C7B-E2AA036C18ED
---

# Guidelines for background tasks


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Ensure your app meets the requirements for running background tasks.

## Background task guidance


Consider the following guidance when developing your background task, and before publishing your app.

**CPU quotas:  **Background tasks are limited by the amount of wall-clock usage time they get based on trigger type. Most triggers are limited to 30 seconds of wall-clock usage, while some have the ability to run up to 10 minutes in order to complete intensive tasks. Background tasks should be lightweight to save battery life and provide a better user experience for foreground apps. See [Support your app with background tasks](support-your-app-with-background-tasks.md) for the resource constraints applied to background tasks.

**Manage background tasks:  **Your app should get a list of registered background tasks, register for progress and completion handlers, and handle those events appropriately. Your background task classes should report progress, cancellation, and completion. For more info see [Handle a cancelled background task](handle-a-cancelled-background-task.md), and [Monitor background task progress and completion](monitor-background-task-progress-and-completion.md).

**Use [**BackgroundTaskDeferral**](https://msdn.microsoft.com/library/windows/apps/hh700499):  **If your background task class runs asynchronous code, make sure to use deferrals. Otherwise your background task may be terminated prematurely when the [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) method completes. For more information, see [Create and register a background task](create-and-register-a-background-task.md).

Alternatively, request one deferral, and use **async/await** to complete asynchronous method calls. Close the deferral after the **await** method calls.

**Update the app manifest:  **Declare each background task in the application manifest, along with the type of triggers it is used with. Otherwise your app will not be able to register the background task at runtime. For more information, see [Declare background tasks in the application manifest](declare-background-tasks-in-the-application-manifest.md).

**Prepare for app updates:  **If your app will be updated, create and register a **ServicingComplete** background task (see [**SystemTriggerType**](https://msdn.microsoft.com/library/windows/apps/br224839)) to help perform app updates that may be necessary outside the context of running in the foreground.

**Request to execute background tasks:  **

> **Important**  Starting in Windows 10, apps are no longer required to be on the lock screen in order to run background tasks.

Universal Windows Platform (UWP) apps can run all supported task types without being pinned to the lock screen. However, apps must call [**RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/hh700485) before registering any type of background task. This method will return [**BackgroundAccessStatus.Denied**](https://msdn.microsoft.com/library/windows/apps/hh700439) if the user has explicitly denied background task permissions for your app in the device's settings.
## Background task checklist


The following checklist applies to all background tasks.

-   Associate your background task with the correct trigger.
-   Add conditions to help ensure your background task runs successfully.
-   Handle background task progress, completion, and cancellation.
-   Do not display UI other than toasts, tiles, and badge updates from the background task.
-   In the [Run](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx) method, request deferrals for each asynchronous method call, and close them when the method is done. Or, use one deferral with **async/await**.
-   Use persistent storage to share data between the background task and the app.
-   Declare each background task in the application manifest, along with the type of triggers it is used with. Make sure the entry point and trigger types are correct.
-   Write background tasks that are short-lived. Background tasks are limited to 30 seconds of wall-clock usage.
-   Do not rely on user interaction in background tasks.
-   Re-register your background tasks during app launch. This ensures that they are registered the first time the app is launched. It also provides a way to detect whether the user has disabled your app's background execution capabilities (in the event registration fails).
-   Do not specify an Executable element in the manifest unless you are using a trigger that should be run in the same context as the app (such as the [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032)).
-   Check for background task registration errors. If appropriate, attempt to register the background task again with different parameter values.
-   For all device families except desktop, if the device becomes low on memory, background tasks may be terminated. If an out of memory exception is not surfaced, or the app does not handle it, then the background task will be terminated without warning and without raising the OnCanceled event. This helps to ensure the user experience of the app in the foreground. Your background task should be designed to handle this scenario.

## Windows: Background task checklist for lock screen-capable apps


Follow this guidance when developing background tasks for apps that are capable of being on the lock screen. Follow the guidance in [Guidelines and checklist for lock screen tiles](https://msdn.microsoft.com/library/windows/apps/hh465403).

-   Make sure your app needs to be on the lock screen before developing it as lock screen-capable. For more info see [Lock screen overview](https://msdn.microsoft.com/library/windows/apps/hh779720).

-   Make sure your app will still work without being on the lock screen.

-   Include a background task registered with [**PushNotificationTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700543), [**ControlChannelTrigger**](https://msdn.microsoft.com/library/windows/apps/hh701032), or [**TimeTrigger**](https://msdn.microsoft.com/library/windows/apps/br224843) and declare it in the app manifest. Make sure the entry point and trigger types are correct. This is required for certification, and enables the user to place the app on the lock screen.

**Note**  
This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

## Related topics

* [Create and register a background task](create-and-register-a-background-task.md)
* [Declare background tasks in the application manifest](declare-background-tasks-in-the-application-manifest.md)
* [Handle a cancelled background task](handle-a-cancelled-background-task.md)
* [Monitor background task progress and completion](monitor-background-task-progress-and-completion.md)
* [Register a background task](register-a-background-task.md)
* [Respond to system events with background tasks](respond-to-system-events-with-background-tasks.md)
* [Set conditions for running a background task](set-conditions-for-running-a-background-task.md)
* [Update a live tile from a background task](update-a-live-tile-from-a-background-task.md)
* [Use a maintenance trigger](use-a-maintenance-trigger.md)
* [Run a background task on a timer](run-a-background-task-on-a-timer-.md)
* [Debug a background task](debug-a-background-task.md)
* [How to trigger suspend, resume, and background events in Windows Store apps (when debugging)](http://go.microsoft.com/fwlink/p/?linkid=254345)

 

 



