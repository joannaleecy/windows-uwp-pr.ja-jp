---
title: Handle app suspend
description: Learn how to save important application data when the system suspends your app.
ms.assetid: F84F1512-24B9-45EC-BF23-A09E0AC985B0
---

# Handle app suspend


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Important APIs**

-   [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341)

Learn how to save important application data when the system suspends your app. The example registers an event handler for the [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) event and saves a string to a file.

## Register the suspending event handler


Register to handle the [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) event, which indicates that your app should save its application data before the system suspends it.

> [!div class="tabbedCodeSnippets"]
```cs
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

partial class MainPage
{
   public MainPage()
   {
      InitializeComponent();
      Application.Current.Suspending += new SuspendingEventHandler(App_Suspending);
   }
}
```
```vb
Public NotInheritable Class MainPage

   Public Sub New()
      InitializeComponent() 
      AddHandler Application.Current.Suspending, AddressOf App_Suspending
   End Sub
   
End Class
```
```cpp
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace AppName;

MainPage::MainPage()
{
   InitializeComponent();
   Application::Current->Suspending += 
       ref new SuspendingEventHandler(this, &amp;MainPage::App_Suspending);
}
```

## Save application data before suspension


When your app handles the [**Suspending**](https://msdn.microsoft.com/library/windows/apps/br242341) event, it has the opportunity to save its important application data in the handler function. The app should use the [**LocalSettings**](https://msdn.microsoft.com/library/windows/apps/br241622) storage API to save simple application data synchronously.

> [!div class="tabbedCodeSnippets"]
```cs
partial class MainPage
{
    async void App_Suspending(
        Object sender, 
        Windows.ApplicationModel.SuspendingEventArgs e)
    {
        // TODO: This is the time to save app data in case the process is terminated
    }
}
```
```vb
Public NonInheritable Class MainPage

    Private Sub App_Suspending(
        sender As Object, 
        e As Windows.ApplicationModel.SuspendingEventArgs) Handles OnSuspendEvent.Suspending

        ' TODO: This is the time to save app data in case the process is terminated
    End Sub

End Class
```
```cpp
void MainPage::App_Suspending(Object^ sender, SuspendingEventArgs^ e)
{
    // TODO: This is the time to save app data in case the process is terminated
}
```

## Remarks


The system suspends your app whenever the user switches to another app or to the desktop or Start screen. The system resumes your app whenever the user switches back to it. When the system resumes your app, the content of your variables and data structures is the same as it was before the system suspended the app. The system restores the app exactly where it left off, so that it appears to the user as if it's been running in the background.

The system attempts to keep your app and its data in memory while it's suspended. However, if the system does not have the resources to keep your app in memory, the system will terminate your app. When the user switches back to a suspended app that has been terminated, the system sends an [**Activated**](https://msdn.microsoft.com/library/windows/apps/br225018) event and should restore its application data in its [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335) method.

The system doesn't notify an app when it's terminated, so your app must save its application data and release exclusive resources and file handles when it's suspended, and restore them when the app is activated after termination.

> **Note**   If you need to do asynchronous work when your app is being suspended you will need to defer completion of suspend until after your work completes. You can use the [**GetDeferral**](https://msdn.microsoft.com/library/windows/apps/br224690) method on the [**SuspendingOperation**](https://msdn.microsoft.com/library/windows/apps/br224688) object (available via the event args) to delay completion of suspend until after you call the [**Complete**](https://msdn.microsoft.com/library/windows/apps/br224685) method on the returned [**SuspendingDeferral**](https://msdn.microsoft.com/library/windows/apps/br224684) object.

> **Note**  To improve system responsiveness in Windows 8.1, apps are given low priority access to resources after they are suspended. To support this new priority, the suspend operation timeout is extended so that the app has the equivalent of the 5-second timeout for normal priority on Windows or between 1 and 10 seconds on Windows Phone. You cannot extend or alter this timeout window.

> **A note about debugging using Visual Studio:**  Visual Studio prevents Windows from suspending an app that is attached to the debugger. This is to allow the user to view the Visual Studio debug UI while the app is running. When you're debugging an app, you can send it a suspend event using Visual Studio. Make sure the **Debug Location** toolbar is being shown, then click the **Suspend** icon.

## Related topics


* [Handle app activation](activate-an-app.md)
* [Handle app resume](resume-an-app.md)
* [UX guidelines for launch, suspend, and resume](https://msdn.microsoft.com/library/windows/apps/dn611862)
* [App lifecycle](app-lifecycle.md)

 

 





<!--HONumber=Mar16_HO1-->


