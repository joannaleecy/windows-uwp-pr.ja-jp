---
xxxxx: Xxxxxx xxx xxxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxx xxxxxxxxx xxxxxxxxxxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx xxx.
xx.xxxxxxx: XYYXYYYY-YYXY-YYXX-XXYY-XYYXYXXYYYXY
---

# Xxxxxx xxx xxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242341)

Xxxxx xxx xx xxxx xxxxxxxxx xxxxxxxxxxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx xxx. Xxx xxxxxxx xxxxxxxxx xx xxxxx xxxxxxx xxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242341) xxxxx xxx xxxxx x xxxxxx xx x xxxx.

## Xxxxxxxx xxx xxxxxxxxxx xxxxx xxxxxxx


Xxxxxxxx xx xxxxxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242341) xxxxx, xxxxx xxxxxxxxx xxxx xxxx xxx xxxxxx xxxx xxx xxxxxxxxxxx xxxx xxxxxx xxx xxxxxx xxxxxxxx xx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
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

## Xxxx xxxxxxxxxxx xxxx xxxxxx xxxxxxxxxx


Xxxx xxxx xxx xxxxxxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242341) xxxxx, xx xxx xxx xxxxxxxxxxx xx xxxx xxx xxxxxxxxx xxxxxxxxxxx xxxx xx xxx xxxxxxx xxxxxxxx. Xxx xxx xxxxxx xxx xxx [**XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241622) xxxxxxx XXX xx xxxx xxxxxx xxxxxxxxxxx xxxx xxxxxxxxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
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

## Xxxxxxx


Xxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xx xxxxxxx xxx xx xx xxx xxxxxxx xx Xxxxx xxxxxx. Xxx xxxxxx xxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xxxx xx xx. Xxxx xxx xxxxxx xxxxxxx xxxx xxx, xxx xxxxxxx xx xxxx xxxxxxxxx xxx xxxx xxxxxxxxxx xx xxx xxxx xx xx xxx xxxxxx xxx xxxxxx xxxxxxxxx xxx xxx. Xxx xxxxxx xxxxxxxx xxx xxx xxxxxxx xxxxx xx xxxx xxx, xx xxxx xx xxxxxxx xx xxx xxxx xx xx xx'x xxxx xxxxxxx xx xxx xxxxxxxxxx.

Xxx xxxxxx xxxxxxxx xx xxxx xxxx xxx xxx xxx xxxx xx xxxxxx xxxxx xx'x xxxxxxxxx. Xxxxxxx, xx xxx xxxxxx xxxx xxx xxxx xxx xxxxxxxxx xx xxxx xxxx xxx xx xxxxxx, xxx xxxxxx xxxx xxxxxxxxx xxxx xxx. Xxxx xxx xxxx xxxxxxxx xxxx xx x xxxxxxxxx xxx xxxx xxx xxxx xxxxxxxxxx, xxx xxxxxx xxxxx xx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225018) xxxxx xxx xxxxxx xxxxxxx xxx xxxxxxxxxxx xxxx xx xxx [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335) xxxxxx.

Xxx xxxxxx xxxxx'x xxxxxx xx xxx xxxx xx'x xxxxxxxxxx, xx xxxx xxx xxxx xxxx xxx xxxxxxxxxxx xxxx xxx xxxxxxx xxxxxxxxx xxxxxxxxx xxx xxxx xxxxxxx xxxx xx'x xxxxxxxxx, xxx xxxxxxx xxxx xxxx xxx xxx xx xxxxxxxxx xxxxx xxxxxxxxxxx.

> **Xxxx**   Xx xxx xxxx xx xx xxxxxxxxxxxx xxxx xxxx xxxx xxx xx xxxxx xxxxxxxxx xxx xxxx xxxx xx xxxxx xxxxxxxxxx xx xxxxxxx xxxxx xxxxx xxxx xxxx xxxxxxxxx. Xxx xxx xxx xxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224690) xxxxxx xx xxx [**XxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224688) xxxxxx (xxxxxxxxx xxx xxx xxxxx xxxx) xx xxxxx xxxxxxxxxx xx xxxxxxx xxxxx xxxxx xxx xxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224685) xxxxxx xx xxx xxxxxxxx [**XxxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224684) xxxxxx.

> **Xxxx**  Xx xxxxxxx xxxxxx xxxxxxxxxxxxxx xx Xxxxxxx Y.Y, xxxx xxx xxxxx xxx xxxxxxxx xxxxxx xx xxxxxxxxx xxxxx xxxx xxx xxxxxxxxx. Xx xxxxxxx xxxx xxx xxxxxxxx, xxx xxxxxxx xxxxxxxxx xxxxxxx xx xxxxxxxx xx xxxx xxx xxx xxx xxx xxxxxxxxxx xx xxx Y-xxxxxx xxxxxxx xxx xxxxxx xxxxxxxx xx Xxxxxxx xx xxxxxxx Y xxx YY xxxxxxx xx Xxxxxxx Xxxxx. Xxx xxxxxx xxxxxx xx xxxxx xxxx xxxxxxx xxxxxx.

> **X xxxx xxxxx xxxxxxxxx xxxxx Xxxxxx Xxxxxx:**  Xxxxxx Xxxxxx xxxxxxxx Xxxxxxx xxxx xxxxxxxxxx xx xxx xxxx xx xxxxxxxx xx xxx xxxxxxxx. Xxxx xx xx xxxxx xxx xxxx xx xxxx xxx Xxxxxx Xxxxxx xxxxx XX xxxxx xxx xxx xx xxxxxxx. Xxxx xxx'xx xxxxxxxxx xx xxx, xxx xxx xxxx xx x xxxxxxx xxxxx xxxxx Xxxxxx Xxxxxx. Xxxx xxxx xxx **Xxxxx Xxxxxxxx** xxxxxxx xx xxxxx xxxxx, xxxx xxxxx xxx **Xxxxxxx** xxxx.

## Xxxxxxx xxxxxx


* [Xxxxxx xxx xxxxxxxxxx](activate-an-app.md)
* [Xxxxxx xxx xxxxxx](resume-an-app.md)
* [XX xxxxxxxxxx xxx xxxxxx, xxxxxxx, xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/dn611862)
* [Xxx xxxxxxxxx](app-lifecycle.md)

 

 



<!--HONumber=Mar16_HO1-->
