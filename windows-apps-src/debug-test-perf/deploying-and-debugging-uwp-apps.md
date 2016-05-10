---
author: mcleblanc
ms.assetid: 9322B3A3-8F06-4329-AFCB-BE0C260C332C
description: This article guides you through the steps to target various deployment and debugging targets.
title: Deploying and debugging Universal Windows Platform (UWP) apps
---

# Deploying and debugging Universal Windows Platform (UWP) apps

\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

This article guides you through the steps to target various deployment and debugging targets.

Microsoft Visual Studio allows you to deploy and debug your Universal Windows Platform (UWP) apps on a variety of Windows 10 devices. Visual Studio will handle the process of building and registering the application on the target device.

## Picking a deployment target

To pick a target, navigate to the debug target dropdown next to the **Start Debugging** button and select which target you want to deploy your application to. After the target is selected, choose **Start Debugging (F5)** to deploy and debug on that target, or press **Ctrl+F5** to just deploy to that target.

![](images/debug-device-target-list.png)

-   **Local Machine** will deploy the application to your current development machine. This option is only available if your application's **Target Platform Min. Version** is less than or equal to the operating system on your development machine.
-   **Simulator** will deploy the application to a simulated environment on your current development machine. This option is only available if your application's **Target Platform Min. Version** is less than or equal to the operating system on your development machine.
-   **Device** will deploy the application to a USB connected device. The device must be developer unlocked and have the screen unlocked.
-   An **Emulator** target will boot up and deploy the application to an emulator with the configuration specified in the name. Emulators are only available on Hyper-V enabled machines running Windows 8.1 or beyond.
-   **Remote Machine** will let you specify a remote target to deploy the application. More information about deploying to a remote machine can be found in [Specifying a remote device](#specifying-a-remote-device).

## Specifying a remote device

### C# and Microsoft Visual Basic

To specify a remote machine for C# or Microsoft Visual Basic apps, select **Remote Machine** in the debug target dropdown. The **Remote Connections** dialog will appear which will let you specify an IP Address or select a discovered device. By default, the **Universal** authentication mode is selected. To determine which authentication mode to use, see [Authentication modes](#authentication-modes).

![](images/debug-remote-connections.png)

To return to this dialog, you can open project properties and navigate to the **Debug** tab. From there, select **Find…** next to **Remote machine:**

![](images/debug-remote-machine-config.png)

To deploy an application to a remote PC, you will also need to download and install the Visual Studio Remote Tools on the target PC. See [Remote PC instructions](#remote-pc-instructions) for full instructions.

### C++ and JavaScript

To specify a remote machine target for a C++ or JavaScript UWP app, go to project properties by right clicking on the project in the **Solution Explorer**, and clicking **Properties**. Navigate to **Debugging** settings and change **Debugger to launch** to **Remote Machine**. Then fill in the **Machine Name** (or click **Locate…** to find one) and set the **Authentication Type** property.

![](images/debug-property-pages.png)
After the machine is specified, you can select **Remote Machine** in the debug target dropdown to return to that specified machine. Only one remote machine can be selected at a time.

### Remote PC instructions

To deploy to a remote PC, the target PC must have the Visual Studio Remote Tools installed. The remote PC must also be running a version of Windows that is greater than or equal to your apps **Target Platform Min. Version** property. Once you have installed the remote tools, you must launch the remote debugger on the target PC. To do this, search for **Remote Debugger** in the **Start** menu launch it, and if prompted allow the debugger to configure your firewall settings. By default, the debugger launches with Windows authentication. This will require user credentials if the logged in user is not the same on both PCs. To change it to **No authentication**, go to **Tools** -&gt; **Options** in the **Remote Debugger** and set it to **No Authentication**. Once the remote debugger is setup, you can deploy from your development machine.

For more information see the [Remote Tools for Visual Studio]( http://go.microsoft.com/fwlink/?LinkId=717039) download page.

## Authentication modes

There are three authentication modes for remote machine deployment:

- **Universal (Unencrypted Protocol)**: Use this authentication mode whenever you are deploying to a remote device that is not a Windows PC (desktop or laptop). Currently, this is only IoT devices. Universal (Unencrypted Protocol) should only be used on trusted networks. The debugging connection is vulnerable to malicious users who could intercept and change data being passed between the development and remote machine.
- **Windows**: This authentication mode is only intended to be used for remote PC deployment (desktop or laptop). Use this authentication mode when you have access to the credentials of the logged in user of the target machine. This is the most secure channel for remote deployment.
- **None**: This authentication mode is only intended to be used for remote PC deployment (desktop or laptop). Use this authentication mode when you have a test machine setup in an environment that has a test account logged in and you cannot enter the credentials. Make sure the remote debugger settings are set to accept no authentication.

## Debugging options

On Windows 10, the startup performance of UWP apps is improved by proactively launching and then suspending apps in a technique called [prelaunch](https://msdn.microsoft.com/library/windows/apps/Mt593297). Many applications will not need to do anything special to work in this mode, but some applications may need to adjust their behavior. To help debug any issues in these code paths you can start debugging the app from Visual Studio in prelaunch mode. Debugging is supported both from a Visual Studio project (**Debug** -&gt; **Other Debug Targets** -&gt; **Debug Universal Windows App Prelaunch**), and for apps already installed on the machine (**Debug** -&gt; **Other Debug Targets** -&gt; **Debug Installed App Package**, and check the box for **Activate app with Prelaunch**). For more information read about how to [Debug UWP Prelaunch]( http://go.microsoft.com/fwlink/?LinkId=717245).

You can set the following deployment options on the **Debug** property page of the startup project.

**Allow Network Loopback**

For security reasons, a UWP app that is installed in the standard manner is not allowed to make network calls to the device it is installed on. By default, Visual Studio deployment creates an exemption from this rule for the deployed app. This exemption allows you to test communication procedures on a single machine. Before submitting your app to the Windows Store, you should test your app without the exemption.

To remove the network loopback exemption from the app:

-   On the C# and Visual Basic **Debug** property page, clear the **Allow Network Loopback** check box.
-   On the JavaScript and C++ **Debugging** property page, set the **Allow Network Loopback** value to **No**.

**Do not launch, but debug my code when it starts (C# and Visual Basic) / Launch App (JavaScript and C++)**

To configure the deployment to automatically start a debugging session when the app is launched:

-   On the C# and Visual Basic **Debug** property page, check the **Do not launch, but debug my code when it starts** check box.
-   On the JavaScript and C++ **Debugging** property page, set the **Launch Application** value to **Yes**.


