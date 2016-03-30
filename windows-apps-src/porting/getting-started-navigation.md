---
xxxxx: Xxxxxxx xxxxxxx xxxx Xxxxxxxxxx
xxxxxxxxxxx: Xxxxxxx xxxxxxx xxxx xxxxxxxxxx
xx.xxxxxxx: XYXXYXYX-XYYY-YYYY-XXXX-YYYXYXYXYXXX
---

# Xxxxxxx xxxxxxx: Xxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

## Xxxxxx xxxxxxxxxx

xXX xxxxxxxx xxx **XXXxxxxxxxxxXxxxxxxxxx** xxxxx xx xxxx xxxx xx-xxx xxxxxxxxxx: xxx xxx xxxx xxx xxx xxxxx xx xxxxxx xxx xxxxxxxxx xx **XXXxxxXxxxxxxxxxx** xxxx xxxxxx xxxx xxx.

Xx xxxxxxxx, x Xxxxxxx YY xxx xxxxxxxxxx xxxxxxxx xxxxx xxxxx xxxx xx x xxx-xxxx xxxxxxxx xx xxxxxxxxxx. Xxx xxx xxxxxxx xxxx xxxxx xxxxxxx xxxx xxxx xx xxxx xx xxxx xxxxx xx xxxxxxxx xx xxxx xxxxx xxx xxxxxxx xxx xxx. Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/dn958438).

Xxx xx xxx xxxx xx xxxxxx xxxx xxxxxxxxxx xx x Xxxxxxx YY xxx xx xx xxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682) xxxxx. Xxx xxxxxxxxx xxxxxxxxxxx xxxxx xxx xxx xx xxx xxxx xxx.

Xxxxxxxxxx xxxx xxx xxxxxxxx xxx xxxxxxx xxxxxxx, xxxx xxx **XxxxXxxx.xxxx** xxxx, xxx xxx x xxxxxx xx xxx **Xxxxxx** xxxx. Xxxxxx xxx xxxxxx'x **Xxxxxxx** xxxxxxxx xxxx "Xxxxxx" xx "Xx Xx Xxxx". Xxxx, xxxxxx x xxxxxxx xxx xxx xxxxxx'x **Xxxxx** xxxxx, xx xxxxx xx xxx xxxxxxxxx xxxxxx. Xx xxx xxx'x xxxxxxxx xxx xx xx xxxx, xxxxxx xxx xxxxxxxxxxx xx xxx xxxxxxxx xxxxxxx (Xxxx: xxxxxx-xxxxx xxx xxxxxx xx xxx **Xxxxxx** xxxx).

![xxxxxx x xxxxxx xxx xxx xxxxx xxxxx xx xxxxxx xxxxxx](images/ios-to-uwp/vs-go-to-page.png)

Xxx'x xxx x xxx xxxx. Xx xxx **Xxxxxxxx** xxxx, xxx xxx **Xxxxxxx** xxxx, xxx xxx **Xxx Xxx Xxxx**. Xxx **Xxxxx Xxxx** xx xxxxx xx xxx xxxxxxxxx xxxxxx, xxx xxxx xxx **Xxx**.

![xxxxxx x xxx xxxx xx xxxxxx xxxxxx](images/ios-to-uwp/vs-add-new-page.png)

Xxxx, xxx x xxxxxx xx xxx XxxxxXxxx.xxxx xxxx. Xxx'x xxx xxx XxxXxxXxxxxx xxxxxxx, xxx xxx'x xxxx xx x xxxx xxxxx xxxxx: xx xxx **XXXX** xxxx, xxx ` <AppBarButton Icon="Back"/>` xxxxxxx xxx `<Grid> </Grid>` xxxxxxxx.

Xxx, xxx'x xxx xx xxxxx xxxxxxx xx xxx xxxxxx: xxxxxx-xxxxx xxx xxxxxxx xx xxx **Xxxxxx** xxxx xxx Xxxxxxxxx Xxxxxx Xxxxxx xxxx xxx xxxx "XxxXxxXxxxxx\_Xxxxx" xx xxx **Xxxxx** xxx, xx xxxxx xx xxx xxxxxxxxx xxxxxx, xxx xxxx xxxx xxx xxxxxxxx xxx xxxxxxxxxxxxx xxxxx xxxxxxx xx xxx XxxxxXxxx.xxxx.xx xxxx.

![xxxxxx x xxxx xxxxxx xxx xxx xxxxx xxxxx xx xxxxxx xxxxxx](images/ios-to-uwp/vs-add-back-button.png)

Xx xxx xxxxxx xx xxx XxxxxXxxx.xxxx xxxx'x **XXXX** xxxx, xxx `<AppBarButton>` xxxxxxx'x Xxxxxxxxxx Xxxxxxxxxxx Xxxxxx Xxxxxxxx (XXXX) xxxx xxxxxx xxx xxxx xxxx xxxx:

` <AppBarButton Icon="Back" Click="AppBarButton_Click"/>`

Xxxxxx xx xxx XxxxxXxxx.xxxx.xx xxxx, xxx xxx xxxx xxxx xx xx xx xxx xxxxxxxx xxxx xxxxx xxx xxxx xxxx xxx xxxxxx.

```csharp
private void AppBarButton_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.    
    Frame.GoBack();
}
```

Xxxxxxx, xxxx xxx XxxxXxxx.xxxx.xx xxxx xxx xxx xxxx xxxx. Xx xxxxx XxxxxXxxx xxxxx xxx xxxx xxxx xxx xxxxxx.

```csharp
private void Button_Click(object sender, RoutedEventArgs e)
{
    // Add the following line of code.
    Frame.Navigate(typeof(BlankPage1));
}
```

Xxx, xxx xxx xxxxxxx. Xxx xxx "Xx Xx Xxxx" xxxxxx xx xx xx xxx xxxxx xxxx, xxx xxxx xxx xxx xxxx-xxxxx xxxxxx xx xxxxxx xx xxx xxxxxxxx xxxx.

Xxxx xxxxxxxxxx xx xxxxxxx xx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682) xxxxx. Xx xxx **XXXxxxxxxxxxXxxxxxxxxx** xxxxx xx xXX xxxx **xxxxXxxxXxxxxxxxxx** xxx **xxxXxxxXxxxxxxxxx** xxxxxxx, xxx **Xxxxx** xxxxx xxx Xxxxxxx Xxxxx xxxx xxxxxxxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694) xxx [**XxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn996568) xxxxxxx. Xxx **Xxxxx** xxxxx xxxx xxx x xxxxxx xxxxxx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242693), xxxxx xxxx xxxx xxx xxxxx xxxxxx.

Xxxx xxxxxxxxxxx xxxxxxx x xxx xxxxxxxx xx XxxxxXxxx xxxx xxxx xxx xxxxxxxx xx xx. (Xxx xxxxxxxx xxxxxxxx xxxx xx xxxxx, xx *xxxxxxxx*, xxxxxxxxxxxxx). Xx xxx xxx'x xxxx x xxx xxxxxxxx xx xx xxxxxxx xxxx xxxx, xxx xxx xxxxxxxxx xxxx xx xxx XxxxxXxxx xxxxx'x xxxxxxxxxxx xx xxx XxxxxXxxx.xxxx.xx xxxx. Xxxx xxxx xxxxxx xxx [**XxxxxxxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br227506) xxxxxxxx.

```csharp
public BlankPage()
{
    this.InitializeComponent();
    // Add the following line of code.
    this.NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
}
```

Xxx xxx xxxx xxx xx xxx xxx **Xxxxx** xxxxx'x [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242683) xxxxxxxx xx xxxxxx xxx xxxx xxxxx xx xxx xxxxxxxxxx xxxxxxx xxx xx xxxxxx.

Xxx xxxx xxxx xxxxx xxxxxxxxxx, xxx [Xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt187344) xxx [XXXX xxxxxxxxxxx xxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=242401).

**Xxxx**  Xxx xxxx xxxxx xxxxxxxxxx xxx Xxxxxxx Xxxxx xxxx xxxxx XxxxXxxxxx xxx XXXX, xxx [Xxxxxxxxxx: Xxxxx xxxxxx-xxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh452768).
 
### Xxxx xxxx

[Xxxxxxx xxxxxxx: Xxxxxxxxx](getting-started-animation.md)

<!--HONumber=Mar16_HO1-->
