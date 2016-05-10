---
author: mcleblanc
title: Launching, resuming, and background tasks
description: This section describes what happens when a Universal Windows Platform (UWP) app is started, suspended, resumed, and terminated.
ms.assetid: 75011D52-1511-4ECF-9DF6-52CBBDB15BD7
---

# Launching, resuming, and background tasks


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


This section describes what happens when a Universal Windows Platform (UWP) app is started, suspended, resumed, and terminated. It covers how to activate apps by using a contract or extension, and how to use background tasks which allow a UWP app to do work even when the app is not in the foreground. Finally, it covers how to add a splash screen to your app.

## The app lifecycle

| Topic                                            | Description                                                                                                     |
|--------------------------------------------------|-----------------------------------------------------------------------------------------------------------------|
| [App lifecycle](app-lifecycle.md)               | Learn about the life cycle of a UWP app and what happens when Windows launches, suspends, and resumes your app. |
| [Handle app prelaunch](handle-app-prelaunch.md) | Learn how to handle app prelaunch.                                                                              |
| [Handle app activation](activate-an-app.md)     | Learn how to handle app activation.                                                                             |
| [Handle app suspend](suspend-an-app.md)         | Learn how to save important application data when the system suspends your app.                                 |
| [Handle app resume](resume-an-app.md)           | Learn how to refresh displayed content when the system resumes your app.                                        |

 

## Launch apps


| URI and File activation                                                                         | Description                                                                                                                                                                |
|-------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Launch an app for results](how-to-launch-an-app-for-results.md)                               | Learn how to launch an app from another app and exchange data between the two.                                                                                             |
| [Launch the default app for a URI](launch-default-app.md)                                      | Learn how to launch the default app for a Uniform Resource Identifier (URI).                                                                                               |
| [Handle URI activation](handle-uri-activation.md)                                              | Learn how to register an app to become the default handler for a URI scheme name.                                                                                          |
| [Launch the default app for a file](launch-the-default-app-for-a-file.md)                      | Learn how to launch the default app for a file type.                                                                                                                       |
| [Handle file activation](handle-file-activation.md)                                            | Learn how to register your app to be the default handler for a file type.                                                                                                  |
| [Guidelines for file types and URIs](https://msdn.microsoft.com/library/windows/apps/hh700321) | By understanding the relationship between UWP apps and the file types and protocols they support, you can provide a more consistent and elegant experience for your users. |
| [Reserved file and URI scheme names](reserved-uri-scheme-names.md)                             | This topic lists the reserved file and URI scheme names that are not available to your app.                                                                                |
| Activate built-in apps                                                                          | Description                                                                                                                                                                |
| [Launch the Windows Settings app](launch-settings-app.md)                                      | Learn how to launch the Windows Settings app.                                                                                                                              |
| [Launch the Windows Store app](launch-store-app.md)                                            | Learn how to launch the Windows Store app.                                                                                                                                 |
| [Launch the Windows Maps app](launch-maps-app.md)                                              | Learn how to launch the Windows Maps app.                                                                                                                                  |

 

## Background tasks and services



| Topic                                                                                                            | Description                                                                                                                                                                                   |
|------------------------------------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Support your app with background tasks](support-your-app-with-background-tasks.md)                             | The topics in this section show how to run your own lightweight code in the background by responding to triggers with background tasks.                                                       |
| [Access sensors and devices from a background task](access-sensors-and-devices-from-a-background-task.md)       | [**DeviceUseTrigger**](https://msdn.microsoft.com/library/windows/apps/dn297337) lets your Universal Windows app access sensors and peripheral devices in the background, even when your foreground app is suspended. |
| [Guidelines for background tasks](guidelines-for-background-tasks.md)                                           | Ensure your app meets the requirements for running background tasks.                                                                                                                          |
| [Create and consume an app service](how-to-create-and-consume-an-app-service.md)                                | Learn how to write a UWP app that can provide services to other UWP apps, and how to consume those services.                                                                                  |
| [Create and register a background task](create-and-register-a-background-task.md)                               | Create a background task class and register it to run when your app is not in the foreground.                                                                                                 |
| [Debug a background task](debug-a-background-task.md)                                                           | Learn how to debug a background task, including background task activation and debug tracing in the Windows event log.                                                                        |
| [Declare background tasks in the application manifest](declare-background-tasks-in-the-application-manifest.md) | Enable the use of background tasks by declaring them as extensions in the app manifest.                                                                                                       |
| [Handle a cancelled background task](handle-a-cancelled-background-task.md)                                     | Learn how to make a background task that recognizes cancellation requests and stops work, reporting the cancellation to the app using persistent storage.                                     |
| [Monitor background task progress and completion](monitor-background-task-progress-and-completion.md)           | Learn how your app can recognize background task progress and completion.                                                                                                                     |
| [Register a background task](register-a-background-task.md)                                                     | Learn how to create a function that can be re-used to safely register most background tasks.                                                                                                  |
| [Respond to system events with background tasks](respond-to-system-events-with-background-tasks.md)             | Learn how to create a background task that responds to [**SystemTrigger**](https://msdn.microsoft.com/library/windows/apps/br224839) events.                                                                         |
| [Run a background task on a timer](run-a-background-task-on-a-timer-.md)                                        | Learn how to schedule a one-time background task, or run a periodic background task.                                                                                                          |
| [Set conditions for running a background task](set-conditions-for-running-a-background-task.md)                 | Learn how to set conditions that control when your background task will run.                                                                                                                  |
| [Transfer data in the background](https://msdn.microsoft.com/library/windows/apps/mt280377)                                           | Use the background transfer API to copy files in the background.                                                                                                                              |
| [Update a live tile from a background task](update-a-live-tile-from-a-background-task.md)                       | Use a background task to update your app's live tile with fresh content.                                                                                                                      |
| [Use a maintenance trigger](use-a-maintenance-trigger.md)                                                       | Learn how to use the [**MaintenanceTrigger**](https://msdn.microsoft.com/library/windows/apps/hh700517) class to run lightweight code in the background while the device is plugged in.                             |

 

## Add a splash screen


All UWP apps must have a splash screen, which is a composite of a splash screen image and a background color, both of which can be customized.

Your splash screen is displayed immediately when the user launches your app. This provides immediate feedback to users while app resources are initialized. As soon as your app is ready for interaction, the splash screen is dismissed.

A well-designed splash screen can make your app more inviting. Here's a simple, understated splash screen:

![a 75% scaled screen capture of the splash screen from the splash screen sample.](images/regularsplashscreen.png)

This splash screen is created by combining a green background color with a transparent PNG.

Putting an image and background color together to form the splash screen helps the splash screen look good, regardless of the device your app is installed on. When the splash screen is displayed, only the size of the background changes to compensate for a variety of screen sizes. Your image always remains intact.

Additionally, you can use the [**SplashScreen**](https://msdn.microsoft.com/library/windows/apps/br224763) class to customize your app's launch experience. You can position an extended splash screen, which you create, to give your app more time to complete additional tasks like preparing app UI or completing networking operations. You can also use the **SplashScreen** class to notify you when the splash screen is dismissed, so that you can begin entrance animations.

| Topic                                                                          | Description                                                                                                                                                                                       |
|--------------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [Add a splash screen](add-a-splash-screen.md)                                 | Set your app's splash screen image and background color.                                                                                                                                          |
| [Display a splash screen for more time](create-a-customized-splash-screen.md) | Display a splash screen for more time by creating an extended splash screen for your app. This extended screen imitates the splash screen shown when your app is launched, and can be customized. |

 

 

 



