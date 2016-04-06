---
title: Handle app resume
description: Learn how to refresh displayed content when the system resumes your app.
ms.assetid: DACCC556-B814-4600-A10A-90B82664EA15
---

# Handle app resume


\[ Updated for UWP apps on Windows 10. For Windows 8.x articles, see the [archive](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Important APIs**

-   [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339)

Learn how to refresh displayed content when the system resumes your app. The example in this topic registers an event handler for the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event.

**Roadmap:** How does this topic relate to others? See:

-   [Roadmap for Windows Runtime apps using C# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/br229583)
-   [Roadmap for Windows Runtime apps using C++](https://msdn.microsoft.com/library/windows/apps/hh700360)

## Register the resuming event handler

Register to handle the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event, which indicates that the user switched away from your app and then back to it.

> [!div class="tabbedCodeSnippets"]
```cs
partial class MainPage
{
   public MainPage()
   {
      InitializeComponent();
      Application.Current.Resuming += new EventHandler<Object>(App_Resuming);
   }
}
```
```vb
Public NonInheritable Class MainPage

   Public Sub New()
      InitializeComponent() 
      AddHandler Application.Current.Resuming, AddressOf App_Resuming
   End Sub

End Class
```
```cpp
MainPage::MainPage()
{
    InitializeComponent();
    Application::Current->Resuming += 
        ref new EventHandler<Platform::Object^>(this, &amp;MainPage::App_Resuming);
}
```

## Refresh displayed content after suspension

When your app handles the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event, it has the opportunity to refresh its displayed content.

> [!div class="tabbedCodeSnippets"]
```cs
partial class MainPage
{
    private void App_Resuming(Object sender, Object e)
    {
        // TODO: Refresh network data
    }
}
```
```vb
Public NonInheritable Class MainPage

    Private Sub App_Resuming(sender As Object, e As Object)
 
        ' TODO: Refresh network data

    End Sub

End Class
```
```cpp
void MainPage::App_Resuming(Object^ sender, Object^ e)
{
    // TODO: Refresh network data
}
```

> **Note**  Because the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event is not raised from the UI thread, a dispatcher must be used to get to the UI thread and inject an update to the UI, if that's something you want to do in your handler.

## Remarks


The system suspends your app whenever the user switches to another app or to the desktop. The system resumes your app whenever the user switches back to it. When the system resumes your app, the content of your variables and data structures is the same as it was before the system suspended the app. The system restores the app exactly where it left off, so that it appears to the user as if it's been running in the background. However, the app may have been suspended for a significant amount of time, so it should refresh any displayed content that might have changed while the app was suspended, such as news feeds or the user's location.

If your app doesn't have any displayed content to refresh, there's no need for it to handle the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event.

**A note about debugging using Visual Studio:  ** When your app is attached to the Visual Studio debugger, you can send it a **Resume** event. Make sure the **Debug Location toolbar** is being shown, and click the drop-down next to the **Suspend** icon. Then choose **Resume**.

> **Note**  For Windows Phone Store apps, the [**Resuming**](https://msdn.microsoft.com/library/windows/apps/br242339) event is always followed by [**OnLaunched**](https://msdn.microsoft.com/library/windows/apps/br242335), even when your app is currently suspended and the user re-launches your app from a primary tile or app list. Apps can skip initialization if there is already content set on the current window. You can check the [**LaunchActivatedEventArgs.TileId**](https://msdn.microsoft.com/library/windows/apps/br224736) property to determine if the app was launched from a primary or a secondary tile and, based on that information, decide whether you should present a fresh or resume app experience.

## Related topics

* [Handle app activation](activate-an-app.md)
* [Handle app suspend](suspend-an-app.md)
* [Guidelines for app suspend and resume](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [App lifecycle](app-lifecycle.md)




<!--HONumber=Mar16_HO1-->


