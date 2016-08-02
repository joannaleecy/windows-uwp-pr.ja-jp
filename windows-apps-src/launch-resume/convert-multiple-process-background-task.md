---
author: TylerMSFT
title: Convert a multi-process background task to a single-process background task
description: Convert a background task that runs in a separate process into a background task that runs inside your foreground app process.
---

# Convert a multi-process background task to a single-process background task

The simplest way to convert your multiple process background activity into single process is to bring your [IBackgroundTask.Run](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.ibackgroundtask.run.aspx?f=255&MSPPError=-2147217396) method code inside your application and initiate it from [OnBackgroundActivated](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.application.onbackgroundactivated.aspx).

If your app has multiple background tasks, the [Background Activation Sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/BackgroundActivation) shows how you can use `BackgroundActivatedEventArgs.TaskInstance.Task.Name` to identify which task is being initiated.

If you are currently communicating between background and foreground processes, you can remove that state management and communication code.

## Background tasks and trigger types that cannot be converted

* Single-process background tasks don't support activating a VoIP background task.
* Single-process background tasks don't support the following triggers:  [DeviceUseTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceusetrigger.aspx?f=255&MSPPError=-2147217396), [DeviceServicingTrigger](https://msdn.microsoft.com/en-us/library/windows/apps/windows.applicationmodel.background.deviceservicingtrigger.aspx) and **IoTStartupTask**
