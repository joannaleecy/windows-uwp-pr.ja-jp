---
author: TylerMSFT
title: Launch an app on a remote device
description: Learn how to launch an app on a remote device.
---

# Launch an app on a remote device

This article explains how to launch a Universal Windows Platform (UWP) app or Windows desktop app on a remote device.

Starting in Windows 10, version 1607, a UWP app can launch a UWP app or a Windows desktop application remotely on another device running Windows 10, version 1607 or later.

One scenario for launching an app on a remote device is to allow a user to start a task on one device and finish it on another. For example, if you are listening to music on your phone on the drive home, you could use remote launch to hand playback over to your Xbox when you get home. You can pass data to the remote app to provide context for the remote app to continue the task.

## Add the RemoteSystem capability

In order for your app to launch an app on a remote device, you must add the <uap3:Capability Name="remoteSystem"/> capability to your app package manifest. You can use the package manifest designer to add it by selecting **Remote System** on the **Capabilities** tab, or you can manually do what the package manifest designer would do and add the following to your Package.appxmanifest file.

``` xml
<Capabilities>
   <uap3:Capability Name="remoteSystem"/>
 </Capabilities>
```
## Find a connected device

You must first find the device that you want to connect with. [addlink] discusses how to do this in detail. We'll use a simple approach here that forgoes filtering by device or connectivity type. We will create a remote system watcher that looks for remote devices, and write event handlers that are notified when devices using the same Microsoft account are discovered or removed. This will provide us with a collection of connected devices.

The code in these examples assumes that you have a `using Windows.System.RemoteSystems` statement in your file.

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetBuildDeviceList)]

The first thing you must do before making a remote launch is call `RemoteSystem.RequestAccessAsync()`. Check the return value to make sure your app is allowed to access remote devices. One reason this check could fail is if you haven't added the `remoteSystem` capability to your app.

The system watcher event handlers are called when a device that we can connect with is discovered or is no longer available. We will use these event handlers to keep an updated list of devices that we can connect to.

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetEventHandlers)]

We will track the devices by remote system ID using a Dictionary. An ObservableCollection is used to hold the list of devices that we can enumerate. An ObservableCollection also makes it easy to bind the list of devices to UI, though we won't do that in this example.

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetMembers)]

Add a call to `BuildDeviceList()` in your app startup code before you attempt to launch a remote app.

## Launch an app on a remote device

Launch an app remotely by passing the device you wish to connect with to the  RemoteLauncher.LaunchUri API.  There are three overloads for this function.  The simplest, which this example demonstrates, specifies the URI that will activate the app on the remote device. In this example the URI opens the Maps app on the remote machine with a 3D view of the Space Needle.

Other **RemoteLauncher.LaunchUri** overloads allow you to specify options such as the URI of the web site to view if an app that can handle the URI can't be launched on the remote device, and an optional list of package family names that could be used to launch the URI on the remote device. You can also provide data in the form of key/value pairs. You might pass data to the app you are activing on the remote device to provide context to the remote app, such as the name of the song to play and the current playback location when you hand off playback from one device to another.

In real-world use, you might provide UI to select the device you wanted to use. But to simplify this example, we'll just use the first one in the list to make the remote call.

[!code-cs[Main](./code/RemoteLaunchScenario/MainPage.xaml.cs#SnippetRemoteUriLaunch)]

The RemoteLaunchUriStatus that is returned from LaunchUriAsync() provides information about whether the remote launch succeeded, and if not, a reason why.

## Related topics

[Remote Systems API reference](https://msdn.microsoft.com/en-us/library/windows/apps/Windows.System.RemoteSystems)    [Connected apps and devices overview](connected-apps-and-devices.md)  
[Remote Systems sample](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/RemoteSystems ) demonstrates how to discover a remote system, launch an app on a remote system, and use app services to send messages between apps running on two systems.
