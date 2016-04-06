---
ms.assetid: 03A74239-D4B6-4E41-B2FA-6C04F225B844
title: Create a Hello, world app (XAML)
description: This tutorial teaches you how to use Extensible Application Markup Language (XAML) with C# to create a simple Hello, world app that targets the Universal Windows Platform (UWP) on Windows 10.
---

# Create a "Hello, world" app (XAML)

This tutorial teaches you how to use Extensible Application Markup Language (XAML) with C# to create a simple "Hello, world" app that targets the Universal Windows Platform (UWP) on Windows 10. With a single project in Microsoft Visual Studio, you can build an app that runs on any Windows 10 device. Here we focus on creating an app that runs equally well on desktop and mobile devices.

**Important**   This tutorial is for use with Microsoft Visual Studio 2015 and Windows 10. It won't work correctly with earlier versions.

Here you'll learn how to:

-   Create a new Visual Studio project that targets Windows 10 and the UWP.
-   Add XAML content to your start page.
-   Handle touch, pen, and mouse input.
-   Run the project on the local desktop and on the phone emulator in Visual Studio.
-   Adapt the UI to different screen sizes.

## Before you start...


-   We're going to jump right into the steps you use to create a simple universal app. So we strongly recommend that you read and understand the overview information in [What's new in Windows 10](https://dev.windows.com/whats-new-windows-10-dev-preview) and [What's a Universal Windows app](whats-a-uwp.md) before you start this tutorial.
-   To complete this tutorial, you need Windows 10 and Visual Studio 2015. See [Get set up](get-set-up.md) for more info.
-   We assume you have a basic understanding of XAML and the concepts in the [XAML overview](https://msdn.microsoft.com/library/windows/apps/Mt185595).
-   We also assume you're using the default window layout in Visual Studio. If you change the default layout, you can reset it in the **Window** menu by using the **Reset Window Layout** command.

##  Step 1: Create a new project in Visual Studio


1.  Launch Visual Studio 2015.

   The Visual Studio 2015 Start page appears. (From now on, we'll refer to Visual Studio 2015 simply as Visual Studio .)

2.  On the **File** menu, select **New** > **Project**.

   The **New Project** dialog appears. The left pane of the dialog lets you select the type of templates to display.

3.  In the left pane, expand **Installed > Templates > Visual C# > Windows**, then pick the **Universal** template group. The dialog's center pane displays a list of project templates for Universal Windows Platform (UWP) apps.

   ![The New Project window ](images/newproject-cs.png)

4.  In the center pane, select the **Blank App (Universal Windows)** template.

   The **Blank App** template creates a minimal UWP app that compiles and runs, but contains no user-interface controls or data. You add controls to the app over the course of this tutorial.

5.  In the **Name** text box, type "HelloWorld".
6.  Click **OK** to create the project.

   Visual Studio creates your project and displays it in the **Solution Explorer**.

   ![Visual Studio Solution Explorer for the HelloWorld project](images/solutionexplorer-cs.png)

Although the **Blank App** is a minimal template, it still contains a lot of files:

-   A manifest file (Package.appxmanifest) that describes your app (its name, description, tile, start page, and so on) and lists the files that your app contains.
-   A set of logo images (Assets/Square150x150Logo.scale-200.png, Assets/Square44x44Logo.scale-200.png, and Assets/Wide310x150Logo.scale-200.png)to display in the start menu.
-   An image (Assets/StoreLogo.png) to represent your app in the Windows Store.
-   A splash screen (Assets/SplashScreen.scale-200.png) to display when your app starts.
-   XAML and code files for the app (App.xaml and App.xaml.cs).
-   A start page (MainPage.xaml) and an accompanying code file (MainPage.xaml.cs) that run when your app starts.

These files are essential to all UWP apps using C#. Every project that you create in Visual Studio contains them.

## Step 2: Modify your start page


### What's in the files?

To view and edit a file in your project, double-click the file in the **Solution Explorer**. By default, you can expand a XAML file just like a folder to see its associated code file. XAML files open in a split view that shows both the design surface and the XAML editor.

In this tutorial, you work with just a few of the files listed previously: App.xaml, MainPage.xaml, and MainPage.xaml.cs.

### App.xaml and App.xaml.cs

App.xaml is where you declare resources that are used across the app. App.xaml.cs is the code-behind file for App.xaml. Code-behind is the code that is joined with the XAML page's partial class. Together, the XAML and code-behind make a complete class. App.xaml.cs is the entry point for your app. Like all code-behind pages, it contains a constructor that calls the `InitializeComponent` method. You don't write the `InitializeComponent` method. It's generated by Visual Studio, and its main purpose is to initialize the elements declared in the XAML file. App.xaml.cs also contains methods to handle activation and suspension of the app.

### MainPage.xaml

In MainPage.xaml you define the UI for your app. You can add elements directly using XAML markup, or you can use the design tools provided by Visual Studio. MainPage.xaml.cs is the code-behind page for MainPage.xaml. It's where you add your app logic and event handlers.

Together these two files define a new class called `MainPage`, which inherits from [**Page**](https://msdn.microsoft.com/library/windows/apps/BR227503), in the `HelloWorld` namespace.

MainPage.xaml

```xml
    <Page
    x:Class="HelloWorld.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:HelloWorld"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    </Grid>
</Page>
```

MainPage.xaml.cs

```csharp
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HelloWorld
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
    }
}
```

### Modify the start page

Now, let's add some content to the app.

**To modify the start page**

1.  Double-click MainPage.xaml in **Solution Explorer** to open it.
2.  In the XAML editor, add the controls for the UI.

   In the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704), add this XAML. It contains a [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/BR209635) with a title [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652), a **TextBlock** that asks the user's name, a [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) element to accept the user's name, a [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265), and another **TextBlock** to show a greeting. Some of these controls have names so that you can refer to them later in your code.

```xml    
    <StackPanel x:Name="contentPanel" Margin="8,32,0,0">
        <TextBlock Text="Hello, world!" Margin="0,0,0,40"/>
        <TextBlock Text="What' s your name?"/>
        <StackPanel x:Name="inputPanel" Orientation="Horizontal" Margin="0,20,0,20">
            <TextBox x:Name="nameInput" Width="280" HorizontalAlignment="Left"/>
            <Button x:Name="inputButton" Content="Say &amp;quot;Hello&amp;quot;"/>
        </StackPanel>
        <TextBlock x:Name="greetingOutput"/>
    </StackPanel>
```    

    The controls that you added in the XAML editor show up in the design view.

## Step 3: Start the app


At this point, you've created a very simple app. This is a good time to build, deploy, and launch your app and see what it looks like. You can debug your app on the local machine, in a simulator or emulator, or on a remote device. Here's the target device menu in Visual Studio.

![Drop-down list of device targets for debugging your app](images/uap-debug.png)

### Start the app on a Desktop device

By default, the app runs on the local machine. The target device menu provides several options for debugging your app on devices from the desktop device family.

-   **Simulator**
-   **Local Machine**
-   **Remote Machine**

**To start debugging on the local machine**

1.  In the target device menu (![Start debugging menu](images/startdebug-full.png)) on the **Standard** toolbar, make sure that **Local Machine** is selected. (It's the default selection.)
2.  Click the **Start Debugging** button (![Start debugging button](images/startdebug-sm.png)) on the toolbar.

   –or–

   From the **Debug** menu, click **Start Debugging**.

   –or–

   Press F5.

The app opens in a window, and a default splash screen appears first. The splash screen is defined by an image (SplashScreen.png) and a background color (specified in your app's manifest file).

The splash screen disappears, and then your app appears. It looks like this.

![Initial app screen](images/helloworld-1-cs.png)

Press the Windows key to open the **Start** menu, then show all apps. Notice that deploying the app locally adds its tile to the **Start** menu. To run the app again (not in debugging mode), tap or click its tile in the **Start** menu.

It doesn't do much—yet—but congratulations, you've built your first UWP app!

**To stop debugging**

-   Click the **Stop Debugging** button (![Stop debugging button](images/stopdebug.png)) in the toolbar.

   –or–

   From the **Debug** menu, click **Stop debugging**.

   –or–

   Close the app window.

### Start the app on a mobile device emulator

Your app runs on any Windows 10 device, so let’s see how it looks on a Windows Phone.

In addition to the options to debug on a desktop device, Visual Studio provides options for deploying and debugging your app on a physical mobile device connected to the computer, or on a mobile device emulator. You can choose among emulators for devices with different memory and display configurations.

-   **Device**
-   **Emulator <SDK version> WVGA 4 inch 512MB**
-   **Emulator <SDK version> WVGA 4 inch 1GB**
-   etc... (Various emulators in other configurations)

It's a good idea to test your app on a device with a small screen and limited memory, so use the **Emulator 10.0.10240.0 WVGA 4 inch 512MB** option.
**To start debugging on a mobile device emulator**

1.  In the target device menu (![Start debugging menu](images/startdebug-full.png)) on the **Standard** toolbar, pick **Emulator 10.0.10240.0 WVGA 4 inch 512MB**.
2.  Click the **Start Debugging** button (![Start debugging button](images/startdebug-sm.png)) in the toolbar.

   –or–

   From the **Debug** menu, click **Start Debugging**.

   –or–

   Press F5.

Visual Studio starts the selected emulator and then deploys and starts your app. On the mobile device emulator, the app looks like this.

![Initial app screen on mobile device](images/helloworld-1-cs-phone.png)

The first thing you'll notice is the button is pushed off the smaller screen of a mobile device. Later in this tutorial, you'll learn how to adapt the UI to different screen sizes so your app always looks good.

You might also notice that you can type in the [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683), but right now, clicking or tapping the [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) doesn't do anything. In the next steps, you create an event handler for the button's [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) event to display a personalized greeting. You add the event handler code to your MainPage.xaml.cs file.

## Step 4: Create an event handler


XAML elements can send messages when certain events occur. These event messages give you the opportunity to take some action in response to the event. You put your code to respond to the event in an event handler method. One of the most common events in many apps is a user clicking a [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265).

Let's create an event handler for your button's [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) event. The event handler will get the user's name from the `nameInput` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) control and use it to output a greeting to the `greetingOutput` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652).

### Using events that work for touch, mouse, and pen input

What events should you handle? Because they can run on a variety of devices, design your Windows Store apps with touch input in mind. Your app must also be able to handle input from a mouse or a stylus. Fortunately, events such as [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) and [**DoubleTapped**](https://msdn.microsoft.com/library/windows/apps/BR208922) are device-independent. If you're familiar with Microsoft .NET programming, you might have seen separate events for mouse, touch, and stylus input, like **MouseMove**, **TouchMove**, and **StylusMove**. In Windows Store apps, these separate events are replaced with a single [**PointerMoved**](https://msdn.microsoft.com/library/windows/apps/BR208970) event that works equally well for touch, mouse, and stylus input.

**To add an event handler**

1.  In XAML or design view, select the "Say Hello" [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) that you added to MainPage.xaml.
2.  In the **Properties Window**, click the Events button (![Events button](images/eventsbutton.png)).
3.  Find the [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) event at the top of the event list. In the text box for the event, type the name of the function that handles the **Click** event. For this example, type "Button\_Click".

   ![Events list in the properties window](images/xaml-hw-event.png)

4.  Press Enter. The event handler method is created and opened in the code editor so you can add code to be executed when the event occurs.

    In the XAML editor, the XAML for the [**Button**](https://msdn.microsoft.com/library/windows/apps/BR209265) is updated to declare the [**Click**](https://msdn.microsoft.com/library/windows/apps/BR227737) event handler like this.

```xml   
   <Button x:Name="inputButton" Content="Say &amp;quot;Hello&amp;quot;" Click="Button_Click"/>
```    

5.  Add code to the event handler that you created in the code-behind page. In the event handler, retrieve the user's name from the `nameInput` [**TextBox**](https://msdn.microsoft.com/library/windows/apps/BR209683) control and use it to create a greeting. Use the `greetingOutput` [**TextBlock**](https://msdn.microsoft.com/library/windows/apps/BR209652) to display the result.
    
```csharp    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        greetingOutput.Text = "Hello, " + nameInput.Text + "!";
    }
```    

6.  Debug the app on the local machine. When you enter your name in the text box and click the button, the app displays a personalized greeting.

## Step 5: Adapt the UI to different window sizes


Now we'll make the UI adapt to different screen sizes so it looks good on mobile devices. To do this, you add a [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) and set properties that are applied for different visual states.

**To adjust the UI layout**

1.  In the XAML editor, add this block of XAML after the opening tag of the root [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) element.

```xml    
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState x:Name="wideState">
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="641" />
                </VisualState.StateTriggers>
            </VisualState>
            <VisualState x:Name="narrowState">
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="0" />
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="inputPanel.Orientation" Value="Vertical"/>
                    <Setter Target="inputButton.Margin" Value="0,4,0,0"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
```    

2.  Debug the app on the local machine. Notice that the UI looks the same as before unless the window gets narrower than 641 pixels.
3.  Debug the app on the mobile device emulator. Notice that the UI uses the properties you defined in the `narrowState` and appears correctly on the small screen.

![Mobile app screen](images/helloworld-2-cs-phone.png)

If you've used a [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/BR209021) in previous versions of XAML, you might notice that the XAML here uses a simplified syntax.

The [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007) named `wideState` has an [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) with its [**MinWindowWidth**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) property set to 641. This means that the state is to be applied only when the window width is not less than the minimum of 641 pixels. You don't define any [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) objects for this state, so it uses the layout properties you defined in the XAML for the page content.

The second [**VisualState**](https://msdn.microsoft.com/library/windows/apps/BR209007), `narrowState`, has an [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/Dn890382) with its [**MinWindowWidth**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.adaptivetrigger.minwindowwidth) property set to 0. This state is applied when the window width is greater than 0, but less than 641 pixels. (At 641 pixels, the `wideState` is applied.) In this state, you do define some [**Setter**](https://msdn.microsoft.com/library/windows/apps/BR208817) objects to change the layout properties of controls in the UI:

-   You change the [**Orientation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.stackpanel.orientation) of the `inputPanel` element from **Horizontal** to **Vertical**.
-   You add a top margin of 4 to the `inputButton` element.

## Summary


Congratulations, you've created your first app for Windows 10 and the UWP!


<!--HONumber=Mar16_HO1-->


