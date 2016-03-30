---
xxxxx: Xxxxxx xxx xxxxxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx xxxxxxxxxx xx xxxxxxxxxx xxx XxXxxxxxxx xxxxxx.
xx.xxxxxxx: XXYXYXYY-XYYX-YYYY-XYXX-YXYYYYYYYYYY
---

# Xxxxxx xxx xxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335)

Xxxxx xxx xx xxxxxx xxx xxxxxxxxxx xx xxxxxxxxxx xxx [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335) xxxxxx..

## Xxxxxxxx xxx xxxxxx xxxxxxx

Xxxx xx xxx xx xxxxxxxxx, xxx xxx xxxxxx, xxx xxxxxx xxxxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225018) xxxxx. Xxx x xxxx xx xxxxxxxxxx xxxxx, xxx xxx [**XxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224693) xxxxxxxxxxx.

Xxx [**Xxxxxxx.XX.Xxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242324) xxxxx xxxxxxx xxxxxxx xxx xxx xxxxxxxx xx xxxxxx xxx xxxxxxx xxxxxxxxxx xxxxx. Xxxxxxx xx xxx xxxxxxxxxx xxxxx xxxx x xxxxxxxx xxxxxx xxxx xxx xxx xxxxxxxx. Xxx xxx xxxxx xxxxxxxxxx xxxxx, xxxxxxxx xxx [**XxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242330) xxxxxx.

Xxxxxx xxx xxxxx xxx xxxx xxxxxxxxxxx.

```xaml
<Application xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
             x:Class="AppName.App" >
```

Xxxxxxxx xxx [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335) xxxxxx. Xxxx xxxxxx xx xxxxxx xxxxxxxx xxx xxxx xxxxxxxx xxx xxx. Xxx [**XxxxxxXxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br224731) xxxxxxxxx xxxxxxxx xxx xxxxxxxx xxxxx xx xxxx xxx xxx xxx xxxxxxxxxx xxxxxxxxx.

**Xxxx**  Xxx Xxxxxxx Xxxxx Xxxxx xxxx, xxxx xxxxxx xx xxxxxx xxxx xxxx xxx xxxx xxxxxxxx xxx xxx xxxx Xxxxx xxxx xx xxx xxxx, xxxx xxxx xxx xxx xx xxxxxxxxx xxxxxxxxx xx xxxxxx. Xx Xxxxxxx, xxxxxxxxx x xxxxxxxxx xxx xxxx Xxxxx xxxx xx xxx xxxx xxxxx’x xxxx xxxx xxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
using System;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;

namespace AppName
{
   public partial class App
   {
      async protected override void OnLaunched(LaunchActivatedEventArgs args)
      {
         EnsurePageCreatedAndActivate();
      }
      
      // Creates the MainPage if it isn't already created.  Also activates
      // the window so it takes foreground and input focus.
      private MainPage EnsurePageCreatedAndActivate()
      {
         if (Window.Current.Content == null)
         {
             Window.Current.Content = new MainPage();
         }
         
         Window.Current.Activate();
         return Window.Current.Content as MainPage;
      }
   }
}
```
```vb
Class App
   Protected Overrides Sub OnLaunched(args As LaunchActivatedEventArgs)
      Window.Current.Content = New MainPage()
      Window.Current.Activate()
   End Sub
End Class
```
```cpp
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::Foundation;
using namespace Windows::UI::Xaml;
using namespace AppName;
void App::OnLaunched(LaunchActivatedEventArgs^ args)
{
   EnsurePageCreatedAndActivate();
}

// Creates the MainPage if it isn't already created.  Also activates
// the window so it takes foreground and input focus.
void App::EnsurePageCreatedAndActivate()
{
    if (_mainPage == nullptr)
    {
        // Save the MainPage for use if we get activated later
        _mainPage = ref new MainPage();
    }
    Window::Current->Content = _mainPage;
    Window::Current->Activate();
}
```

## Xxxxxxx xxxxxxxxxxx xxxx xx xxx xxx xxxxxxxxx xxxx xxxxxxxxxx


Xxxx xxx xxxx xxxxxxxx xx xxxx xxxxxxxxxx xxx, xxx xxxxxx xxxxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225018) xxxxx, xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br224728) xxx xx **Xxxxxx** xxx [**XxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br224729) xxx xx **Xxxxxxxxxx** xx **XxxxxxXxXxxx**. Xxx xxx xxxxxx xxxx xxx xxxxx xxxxxxxxxxx xxxx xxx xxxxxxx xxx xxxxxxxxx xxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
```cs
async protected override void OnLaunched(LaunchActivatedEventArgs args)
{
   if (args.PreviousExecutionState == ApplicationExecutionState.Terminated ||
       args.PreviousExecutionState == ApplicationExecutionState.ClosedByUser)
   {
      // TODO: Populate the UI with the previously saved application data
   }
   else
   {
      // TODO: Populate the UI with defaults
   }
   
   EnsurePageCreatedAndActivate();
}
```
```vb
Protected Overrides Sub OnLaunched(args As Windows.ApplicationModel.Activation.LaunchActivatedEventArgs)
   Dim restoreState As Boolean = False

   Select Case args.PreviousExecutionState
      Case ApplicationExecutionState.Terminated
         ' TODO: Populate the UI with the previously saved application data
         restoreState = True
      Case ApplicationExecutionState.ClosedByUser
         ' TODO: Populate the UI with the previously saved application data
         restoreState = True
      Case Else
         ' TODO: Populate the UI with defaults
   End Select

   Window.Current.Content = New MainPage(restoreState)
   Window.Current.Activate()
End Sub
```
```cpp
void App::OnLaunched(Windows::ApplicationModel::Activation::LaunchActivatedEventArgs^ args)
{
   if (args->PreviousExecutionState == ApplicationExecutionState::Terminated ||
       args->PreviousExecutionState == ApplicationExecutionState::ClosedByUser)
   {
      // TODO: Populate the UI with the previously saved application data
   }
   else
   {
      // TODO: Populate the UI with defaults
   }

   EnsurePageCreatedAndActivate();
}
```

Xx xxx xxxxx xx [**XxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br224729) xx **XxxXxxxxxx**, xxx xxx xxxxxx xx xxxx xxx xxxxxxxxxxx xxxx xxxxxxxxxxxx xxx xxx xxx xxxxxx xxxxx xxxx xx xx xx xxxx xxxxx xxxxxxxxx xxxxxxxx.

## Xxxxxxx

> **Xxxx**  Xxx Xxxxxxx Xxxxx Xxxxx xxxx, xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339) xxxxx xx xxxxxx xxxxxxxx xx [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335), xxxx xxxx xxxx xxx xx xxxxxxxxx xxxxxxxxx xxx xxx xxxx xx-xxxxxxxx xxxx xxx xxxx x xxxxxxx xxxx xx xxx xxxx. Xxxx xxx xxxx xxxxxxxxxxxxxx xx xxxxx xx xxxxxxx xxxxxxx xxx xx xxx xxxxxxx xxxxxx. Xxx xxx xxxxx xxx [**XxxxxxXxxxxxxxxXxxxxXxxx.XxxxXx**](https://msdn.microsoft.com/library/windows/apps/br224736) xxxxxxxx xx xxxxxxxxx xx xxx xxx xxx xxxxxxxx xxxx x xxxxxxx xx x xxxxxxxxx xxxx xxx, xxxxx xx xxxx xxxxxxxxxxx, xxxxxx xxxxxxx xxx xxxxxx xxxxxxx x xxxxx xx xxxxxx xxx xxxxxxxxxx.

## Xxxxxxx xxxxxx

* [Xxxxxx xxx xxxxxxx](suspend-an-app.md)
* [Xxxxxx xxx xxxxxx](resume-an-app.md)
* [Xxxxxxxxxx xxx xxx xxxxxxx xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [Xxx xxxxxxxxx](app-lifecycle.md)

**Xxxxxxxxx**

* [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224766)
* [**Xxxxxxx.XX.Xxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242324)

 

 



<!--HONumber=Mar16_HO1-->
