---
xxxxx: Xxxxxx xxx xxxxxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxx xxxxxxx xxxx xxx.
xx.xxxxxxx: XXXXXYYY-XYYY-YYYY-XYYX-YYXYYYYYXXYY
---

# Xxxxxx xxx xxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339)

Xxxxx xxx xx xxxxxxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxx xxxxxxx xxxx xxx. Xxx xxxxxxx xx xxxx xxxxx xxxxxxxxx xx xxxxx xxxxxxx xxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339) xxxxx.

**Xxxxxxx:** Xxx xxxx xxxx xxxxx xxxxxx xx xxxxxx? Xxx:

-   [Xxxxxxx xxx Xxxxxxx Xxxxxxx xxxx xxxxx X\# xx Xxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/br229583)
-   [Xxxxxxx xxx Xxxxxxx Xxxxxxx xxxx xxxxx X++](https://msdn.microsoft.com/library/windows/apps/hh700360)

## Xxxxxxxx xxx xxxxxxxx xxxxx xxxxxxx

Xxxxxxxx xx xxxxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339) xxxxx, xxxxx xxxxxxxxx xxxx xxx xxxx xxxxxxxx xxxx xxxx xxxx xxx xxx xxxx xxxx xx xx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
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

## Xxxxxxx xxxxxxxxx xxxxxxx xxxxx xxxxxxxxxx

Xxxx xxxx xxx xxxxxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339) xxxxx, xx xxx xxx xxxxxxxxxxx xx xxxxxxx xxx xxxxxxxxx xxxxxxx.

> [!xxx xxxxx="xxxxxxXxxxXxxxxxxx"]
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

> **Xxxx**  Xxxxxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339) xxxxx xx xxx xxxxxx xxxx xxx XX xxxxxx, x xxxxxxxxxx xxxx xx xxxx xx xxx xx xxx XX xxxxxx xxx xxxxxx xx xxxxxx xx xxx XX, xx xxxx'x xxxxxxxxx xxx xxxx xx xx xx xxxx xxxxxxx.

## Xxxxxxx


Xxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xx xxxxxxx xxx xx xx xxx xxxxxxx. Xxx xxxxxx xxxxxxx xxxx xxx xxxxxxxx xxx xxxx xxxxxxxx xxxx xx xx. Xxxx xxx xxxxxx xxxxxxx xxxx xxx, xxx xxxxxxx xx xxxx xxxxxxxxx xxx xxxx xxxxxxxxxx xx xxx xxxx xx xx xxx xxxxxx xxx xxxxxx xxxxxxxxx xxx xxx. Xxx xxxxxx xxxxxxxx xxx xxx xxxxxxx xxxxx xx xxxx xxx, xx xxxx xx xxxxxxx xx xxx xxxx xx xx xx'x xxxx xxxxxxx xx xxx xxxxxxxxxx. Xxxxxxx, xxx xxx xxx xxxx xxxx xxxxxxxxx xxx x xxxxxxxxxxx xxxxxx xx xxxx, xx xx xxxxxx xxxxxxx xxx xxxxxxxxx xxxxxxx xxxx xxxxx xxxx xxxxxxx xxxxx xxx xxx xxx xxxxxxxxx, xxxx xx xxxx xxxxx xx xxx xxxx'x xxxxxxxx.

Xx xxxx xxx xxxxx'x xxxx xxx xxxxxxxxx xxxxxxx xx xxxxxxx, xxxxx'x xx xxxx xxx xx xx xxxxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339) xxxxx.

**X xxxx xxxxx xxxxxxxxx xxxxx Xxxxxx Xxxxxx:  ** Xxxx xxxx xxx xx xxxxxxxx xx xxx Xxxxxx Xxxxxx xxxxxxxx, xxx xxx xxxx xx x **Xxxxxx** xxxxx. Xxxx xxxx xxx **Xxxxx Xxxxxxxx xxxxxxx** xx xxxxx xxxxx, xxx xxxxx xxx xxxx-xxxx xxxx xx xxx **Xxxxxxx** xxxx. Xxxx xxxxxx **Xxxxxx**.

> **Xxxx**  Xxx Xxxxxxx Xxxxx Xxxxx xxxx, xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242339) xxxxx xx xxxxxx xxxxxxxx xx [**XxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242335), xxxx xxxx xxxx xxx xx xxxxxxxxx xxxxxxxxx xxx xxx xxxx xx-xxxxxxxx xxxx xxx xxxx x xxxxxxx xxxx xx xxx xxxx. Xxxx xxx xxxx xxxxxxxxxxxxxx xx xxxxx xx xxxxxxx xxxxxxx xxx xx xxx xxxxxxx xxxxxx. Xxx xxx xxxxx xxx [**XxxxxxXxxxxxxxxXxxxxXxxx.XxxxXx**](https://msdn.microsoft.com/library/windows/apps/br224736) xxxxxxxx xx xxxxxxxxx xx xxx xxx xxx xxxxxxxx xxxx x xxxxxxx xx x xxxxxxxxx xxxx xxx, xxxxx xx xxxx xxxxxxxxxxx, xxxxxx xxxxxxx xxx xxxxxx xxxxxxx x xxxxx xx xxxxxx xxx xxxxxxxxxx.

## Xxxxxxx xxxxxx

* [Xxxxxx xxx xxxxxxxxxx](activate-an-app.md)
* [Xxxxxx xxx xxxxxxx](suspend-an-app.md)
* [Xxxxxxxxxx xxx xxx xxxxxxx xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh465088)
* [Xxx xxxxxxxxx](app-lifecycle.md)


<!--HONumber=Mar16_HO1-->
