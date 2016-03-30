---
xxxxxxxxxxx: Xxx xxxxxxxx xx xxxxxxxx XX xx xxx xxxx xx xxxxxxxxxxx XXXX xxxxxx xxxxxxxxxx xxxxxxxxx xxxx xxxx Xxxxxxx Xxxxx Xxxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx.
xxxxx: Xxxxxxx Xxxxxxx Xxxxx Xxxxxxxxxxx XXXX xxx XX xx XXX
xx.xxxxxxx: YYxxxxYY-YxxY-YYxY-YYxx-YYYxxxxxxxxx
---

#  Xxxxxxx Xxxxxxx Xxxxx Xxxxxxxxxxx XXXX xxx XX xx XXX

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xxxxxxxx xxxxx xxx [Xxxxxxxxxxxxxxx](wpsl-to-uwp-troubleshooting.md).

Xxx xxxxxxxx xx xxxxxxxx XX xx xxx xxxx xx xxxxxxxxxxx XXXX xxxxxx xxxxxxxxxx xxxxxxxxx xxxx xxxx Xxxxxxx Xxxxx Xxxxxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xxx'xx xxxx xxxx xxxxx xxxxxxxx xx xxxx xxxxxx xxx xxxxxxxxxx xxxx xxx'xx xxxxxxx xxxxxx Xxxxxxxx xxx xxxxxxxxxx, xxxxxxx xxxx xxxxxxx xxxx xxxxx, xxx xxxxxxx "xxx-xxxxxxxxx" xx "xxxxx". Xxxx xx xxx xxxxxxxxxx xxxx xx xxxx xxxxxxxxxxxx xxxxx—xxxx xxxxxx, xxx xxxx xxxx xxxxxxxxxxx XX xxxxxxxx—xxxx xxxx xx xxxxxxxxxxxxxxx xx xxxx.

## X xxxxx xxxx xx xxx XXXX xxxxxx

Xxx xxxxxxxx xxxxx xxxxxx xxx xxx xx xxxx xxxx XXXX xxx xxxx-xxxxxx xxxxx xxxx xxxx xxx Xxxxxxx YY Xxxxxx Xxxxxx xxxxxxx. Xxx xx xxx xxxxx xxxxxx xxx xxxxx xxxxxx xxxxxxxxxxx xx xxx Xxxxxx Xxxxxx XXXX xxxxxxxx xx xxxx xxx `PhoneApplicationPage` xxxxxxx xx xxx xxxx xx xxxx XXXX xxxx xx xxx xxxxx xxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxxxxx. Xx xxx xxxxxxxx xxxxx, xxx xxxxx x xxxx xx xxx XXXX xxxxx xxxx Xxxxxx Xxxxxx xxxxxxxxx xxxx xx xxxxxxx xxx Xxxxxxx YY xxxxxxx. Xx xxx xxxx xxxx xxxxxxx xx XxxxXxxx.xxxx, xxx'xx xxx xxxx xx xxx xxxx xx xxx xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br227503), xxxxx xx xx xxx [**Xxxxxxx.XX.Xxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227716) xxxxxxxxx. Xx, xxx xxx xxxxxx xxx `<phone:PhoneApplicationPage>` xxxxxxxx xx `<Page>` (xxx'x xxxxxx xxxxxxxx xxxxxxx xxxxxx) xxx xxx xxx xxxxxx xxx `xmlns:phone` xxxxxxxxxxx.

Xxx x xxxx xxxxxxx xxxxxxxx xx xxxxxxx xxx XXX xxxx xxxx xxxxxxxxxxx xx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx, xxx xxx xxxxx xx [Xxxxxxxxx xxx xxxxx xxxxxxxx](wpsl-to-uwp-namespace-and-class-mappings.md).

## XXXX xxxxxxxxx xxxxxx xxxxxxxxxxxx


Xx xxx xxx xxxxxxxxx xx xxxxxx xxxxx xx xxxx xxxxx—xxxxxxx x xxxx xxxxx xxxxxxxx xx x xxxxx xxxxxxxxx—xxxx xxx xxxx xxxx XXXX xxxxxxxxx xxxxxx xxxxxxxxxxxx xx xxxx XXXX xxxxxx. Xxx xxxxxx xx xxxxx xxxxxxx xxxxxxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxx xxx XXX. Xxxx xxx xxxx xxxxxxxx:

```xaml
    xmlns:ContosoTradingCore="clr-namespace:ContosoTradingCore;assembly=ContosoTradingCore"
    xmlns:ContosoTradingLocal="clr-namespace:ContosoTradingLocal"
```

Xxxxxx "xxx-xxxxxxxxx" xx "xxxxx" xxx xxxxxx xxx xxxxxxxx xxxxx xxx xxxx-xxxxx (xxx xxxxxxxx xxxx xx xxxxxxxx). Xxx xxxxxx xxxxx xxxx xxxx:

```xaml
    xmlns:ContosoTradingCore="using:ContosoTradingCore"
    xmlns:ContosoTradingLocal="using:ContosoTradingLocal"
```

Xxx xxx xxxx x xxxxxxxx xxxxx xxxx xx xxxxxxx xx xxx xxxxxx:

```xaml
    xmlns:System="clr-namespace:System;assembly=mscorlib"
    /* ... */
    <System:Double x:Key="FontSizeLarge">40</System:Double>
```

Xx xxx XXX, xxxx xxx "Xxxxxx" xxxxxx xxxxxxxxxxx xxx xxx xxx (xxxxxxx xxxxxxxx) "x" xxxxxx xxxxxxx:

```xaml
    <x:Double x:Key="FontSizeLarge">40</x:Double></code></pre></td>
</tr>
</tbody>
</table>
```

## Xxxxxxxxxx xxxx


Xxxx xxxx xxxxxx xxx xxx xxxxx xxxxx xxxxx'x xxxxxxxxxx xxxx xxxx xxxxxxxxxx XX xxxxx. Xxxxxxx xxxxx xx xxx xxxx-xxxxxx xxxxx xxxx xxxxxxxx xxxxxxxxxx XX xxxxxxxx. Xxx xxxxxxx, xxx xxxxx xxxx xxxx x xxxx xx xxxx xxxx xxxx xxx xxxxx'x xxxxxxx xxx:


```csharp
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">C#</th>
</tr>
</thead>
<tbody>
<tr class="odd">
    return new BitmapImage(new Uri(this.CoverImagePath, UriKind.Relative));</code></pre></td>
</tr>
</tbody>
</table>
```

**XxxxxxXxxxx** xx xx xxx **Xxxxxx.Xxxxxxx.Xxxxx.Xxxxxxx** xxxxxxxxx xx Xxxxxxx Xxxxx Xxxxxxxxxxx, xxx x xxxxx xxxxxxxxx xx xxx xxxx xxxx xxxxxx **XxxxxxXxxxx** xx xx xxxx xxxxxxx xxxxxxxxx xxxxxxxxxxxxx xx xx xxx xxxxxxx xxxxx. Xx x xxxx xxxx xxxx, xxx xxx xxxxx-xxxxx xxx xxxx xxxx (**XxxxxxXxxxx**) xx Xxxxxx Xxxxxx xxx xxx xxx **Xxxxxxx** xxxxxxx xx xxx xxxxxxx xxxx xx xxx x xxx xxxxxxxxx xxxxxxxxx xx xxx xxxx. Xx xxxx xxxx, xxx [**Xxxxxxx.XX.Xxxx.Xxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br243258) xxxxxxxxx xx xxxxx, xxxxx xx xxxxx xxx xxxx xxxxx xx xxx XXX. Xxx xxx xxxxxx xxx **Xxxxxx.Xxxxxxx.Xxxxx.Xxxxxxx** xxxxx xxxxxxxxx, xxx xxxx xxxx xx xxx xx xxxxx xx xxxx xxxx xxxx xxxx xx xxx xxxxxxx xxxxx. Xxxx xxx'xx xxxx, xxx'xx xxxx xxxxxxx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxxxxxx.

Xx xxxxxx xxxxx xxxx xxxx, xxxxx xxx'xx xxxxxxx xxx xxxxx xx xx xxx xxxxxxxxx xx xxx xxxx xxxxx xx x xxx xxx, xxx xxx xxx Xxxxxx Xxxxxx'x **Xxxx xxx Xxxxxxx** xxxxxxx xx xxxx xxxx xxxxxxx xx xxxx xxxxxx xxxx. Xxx **Xxxxxxx** xxxxxxx xx x xxxxx xxx xx xxxxxxxxxxx x xxxx'x xxx xxxxxxxxx. Xx xxxxxxx xxxxxxx, xxx xxx xxxxxxx xxx "Xxxxxx.Xxxxxxx" xxxx "Xxxxxxx.XX.Xxxx". Xxxx xxxx xxxxxxxxxxx xxxx xxx xxxxx xxxxxxxxxx xxx xxx xxxxx-xxxxxxxxx xxxx xxxxx xxxx xxxxx xx xxxx xxxxxxxxx.

Xxxx xxx xxx xxx xxxxx xxxxxxxxxx xxx xxxxxxx xxx xxx xxx xxxx xxxxx, xxx xxx xxx Xxxxxx Xxxxxx'x **Xxxxxxxx Xxxxxx** xxxxxxx xx xxxx xxxx xxxxxxxxxx xxx xxxxxx xxxxxx xxxx.

Xxxxxxxxx, xxxxxx xxxxxxxxxx xxxx xxxx xx xx xxxxx xx xxxxxxxx x xxxxxxxxx'x xxxx. Xxxxx xxxxx, xxx xxxx xxxx xx xxx XXX XXXx xxxxxxx xx .XXX XXXx xxx Xxxxxxx Xxxxx xxxx. Xx xxxxxxxx xxxxx XXXx xxx xxxxxxxxx, xxx xxx xxxx xx xxxx xxxxxxx xxxxx xx xxxxxxxxxxx xxxx [.XXX xxx Xxxxxxx Xxxxx xxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/br230302.aspx) xxx xxx [Xxxxxxx Xxxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/br211377).

Xxx, xx xxx xxxx xxxx xx xxx xx xxx xxxxx xxxxx xxxx xxxxxxx xxxxxx, xxx xxx xxxxxxx xx xxxx xxx xxx xxx-xxxxxxxxx xxxx. Xxxx xxxxxxx, xxx xxxxx xx x xxxx, xxx xxxxx xx xxx xxxxxxxxx xxxxxx xx xxxx xxxxxxx (xxx xxx xxxxxxxx xxxxx: [Xxxxxxxxxxxxxxx](wpsl-to-uwp-troubleshooting.md)), xxxxx xxx xxxxx xxx xxxxxxx xxxxxx xxx xxxxxx-xxx xxx xxxx xxxx xx xxxxxxxx.

## Xxxxxxxx/xxxxxxxxxx XX

Xxxxxxx xxxx Xxxxxxx YY xxx xxx xxx xx x xxxxxxxxxxx xxxx xxxxx xx xxxxxxx—xxxx xxxx xxx xxx xxxxxx xxxx xxx xxxxxxxxxx—xxx'xx xxxx xx xx xxxxxx xxx xxxxxxx xxxxx xx xxxx xxxx xxx xxx xxx'xx xxxx xx xxxxxx xxxx XX xx xxxx xxx xxxx xx xxxxx xxxxxxx. Xxx xxx xxx xxx xxxxxxxx Xxxxxx Xxxxx Xxxxxxx xxxxxxx xx xxxxxxxxxxx xxxxxx xxxxxx xxxx xxx xx xxxxxx xxxxxx xx xxxxxxxx, xxx xx xxxxxxx xx xxx xx xx xxxx xx xxxxx xx xxx xxxxxxx [Xxxxxxxx XX](wpsl-to-uwp-case-study-bookstore2.md#adaptive-ui) xx xxx XxxxxxxxxY xxxx xxxxx xxxxx.

## Xxxxxx xxx Xxxxxxxxx

Xxxx xxxxx xxx **Xxxxx** xx **Xxxxxxxx** xxxxxxx xxxxxx xx xxxxxx xx xxx xxx [**XxxxxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br224768) xxxxx xx xxxxxx xxx xxxxxxxx x xxxxxxxxxx xxxx, xxx xxxxxxx x xxxxx xx xxx xxxxxxxx xxxx. Xxx [Xxxxxxxxxx xxxxxxxxxx](wpsl-to-uwp-business-and-data.md#background-processing) xxx [Xxxxxx](#toasts).

## Xxxxxxxxx

Xx x xxxxxxxxx xxxxxxxxxxx xx xxxxxxxx xxxxxxxxxx xxx xxxx/xx xxxxxxxxxx, xxx XXX xxxxxxxxx xxxxxxx xx xxxxxxxxx xx XXX xxxx. Xxxxx xxxxxxxxxx xxxx xxxx xxxxxxxx xxx xxxxx xx xxx xxxxxxxx, xx xxxx xxxxx, xxx xx xxxx xxxx xxx xxxxxx xx xxxxxxxxxx xxxx Xxxxxxx xx xxx xxxxx-xx xxxx xx. Xxx [Xxxxxxxxxx: Xxxxxxxxx xxxx XX xxxxx xxxxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703).

Xx xxx xx xxx xxxxxxxx xxxxxxxxxx xx xxxx/xx xxxxxxxxxx xx xxxx XXX xxxx, xxxx xxx xxx xxxx xx xxxxxxxxxx xxx xxxxxxxxxxx xxxxxxx xxxxxxxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxx xxx xxx xxxxxxxx xxx xxxxxxxxxx. Xxx [Xxxxxxxx xxxxxxxxxx xxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt204774). Xxxxxxxxxx xxxx xxx xx xxx XX xxxxxx (xxxx xxxx xxxxxxx xxxxxx xxxxxxxxxx, xxx xxxxxxx) xxx xxxxx xx xxxxxxxxx xxxxxxxxxx, xxx xxxx xxx xx xxx xxx xxxxxxxx, xxxx xxxx xxxx xx xxxxxx xxxxxx xxx xx xxx xx xxx xxxxxx. Xxx xxx xxxxxx xx-xxxxxx xxxx xx xxxxxxx xxxxxxxxx xxxxxxxxxx, xxxx xx [**XxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208980), xxxxxxx xxxxxx xxxx xxxxxxxxxxx. Xx xxx xxx xxx `EnableDependentAnimation="True"` xx xxx xxxxxxxxx xxxxxxx xx xxxxx xx xxxxxxx xxxx xxxxxxxxx xx xxx xx xxxxxxxxx xxxx xxxxxx xx xxxxxxxxxx xx xxx xxxxxxxx. Xx xxx xxx Xxxxx xxx Xxxxxx Xxxxxx xx xxxxxx xxx xxxxxxxxxx, xxxx xxxx xxxxxxxx xxxx xx xxx xxx xxx xxxxx xxxxxxxxx.

## Xxxx xxxxxx xxxxxxxx

Xx x Xxxxxxx YY xxx, xxx xxx xxx x xxxxxx xxxxxxxx xx xxxxxxxx xxx xxxx xxxxxx xxx xx xxxx xxxx xx xxx xxxxxxx. Xx xxxxxx xxxxxxx, xxx xxxxxx xx xxxxxxxx xxx xxx xx x xxxxxxxxxx xxxxxx xx xxx xxxxxx, xx xx x xxxxxx xx xxx xxxxx. Xx x xxxxxxx xxxxxx, xxx xxx x xxxxxx xx xxxx xxx'x xxxxxx xxxxxxxx xxxx-xxxxxxxxxx xx xxxxxxxx xxxxxx xxx xxx, xxx xxxx xxxxxxx xx xxx xxxxx xxx xxx xxxxxxxx xxxx xx xx xxx xxxx xxx xxx Xxxxxx xxxx. Xxx xxxx xxxxxx xxxxx xx x xxxxxxxxx xxxxxxx xxxxxx xxx xxxxxx xxxxxxxx, xxx xxxxxxx xxxxxxxxxxx xx xxxxxxxx xx xx xxxxxxxx xxxxx xxx xxxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn893596) xxxxx.

Xxx xxxxxxx xxxxx xxxxx xxx xxx xxxxxx xxxxxxxx xxx xx xx xxxx xxx xxxxx xxxxx xxx xxxx xxxxxxxxxx xxxxxxx xx xxx xxxxx, xxx xxxxx xxx xxxxx'x xxxxxxx xxxxxxxxxx (xxx xxxxxxx, xx xxxx xxxxx xxxxxxx xxxxxxx).

```csharp
   // app.xaml.cs

    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        [...]

        Windows.UI.Core.SystemNavigationManager.GetForCurrentView().BackRequested += App_BackRequested;
        rootFrame.Navigated += RootFrame_Navigated;
    }

    private void RootFrame_Navigated(object sender, NavigationEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;

        // Note: On device families that have no title bar, setting AppViewBackButtonVisibility can safely execute 
        // but it will have no effect. Such device families provide a back button UI for you.
        if (rootFrame.CanGoBack)
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
                Windows.UI.Core.AppViewBackButtonVisibility.Visible;
        }
        else
        {
            Windows.UI.Core.SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = 
                Windows.UI.Core.AppViewBackButtonVisibility.Collapsed;
        }
    }

    private void App_BackRequested(object sender, Windows.UI.Core.BackRequestedEventArgs e)
    {
        Frame rootFrame = Window.Current.Content as Frame;

        if (rootFrame.CanGoBack)
        {
            rootFrame.GoBack();
        }
    }
```

Xxxxx'x xxxx x xxxxxx xxxxxxxx xxx xxx xxxxxx xxxxxxxx xxx xxxxxxxxxxxxxxxx xxxxxxx xxx xxx.

```csharp
   Windows.UI.Xaml.Application.Current.Exit();
```

## Xxxxxxx, xxx xxxxxxxx xxxxxxxx xxxx {x:Xxxx}

Xxx xxxxx xx xxxxxxx xxxxxxxx:

-   Xxxxxxx x XX xxxxxxx xx "xxxx" (xxxx xx, xx xxx xxxxxxxxxx xxx xxxxxxxx xx x xxxx xxxxx)
-   Xxxxxxx x XX xxxxxxx xx xxxxxxx XX xxxxxxx
-   Xxxxxxx x xxxx xxxxx xxxx xx xxxxxxxxxx (xxxx xx, xx xxxxxx xxxxxxxxxxxxx xxxx x xxxxxxxx xxxxx xxxxxxx xxx xxxx xxx xxxxxxxxxxxx xx x xxxxxxx xxxxxxx)

Xxx xx xxxxx xxxxxxx xxx xxxxxxx xxxxx xxxxxxxxx, xxx xxxxx xxx xxxxxxxxx xxxxxxxxxxx. Xxx xxxxxxx, **Xxxxxx.Xxxxxxx.Xxxx.Xxxxxxx** xxxx xx [**Xxxxxxx.XX.Xxxx.Xxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209820), **Xxxxxx.XxxxxxxxxXxxxx.XXxxxxxXxxxxxxxXxxxxxx** xxxx xx [**Xxxxxxx.XX.Xxxx.Xxxx.XXxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209899), xxx **Xxxxxx.Xxxxxxxxxxx.Xxxxxxxxxxx.XXxxxxxXxxxxxxxXxxxxxx** xxxx xx [**Xxxxxxx.XX.Xxxx.Xxxxxxx.XXxxxxxXxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh702001).

Xxxxxxx Xxxxx Xxxxxxxxxxx xxx xxxx xxx xxx xxx xxxxxxx xxx'x xx xxxxx xxxx xxxx xxx xx x XXX xxx. Xxx xxx xxxx xxxxxxxxxx xxxx xxxx xxxxxxxxxx xxxx xxx xxx xxx xxx xxxxxxx, xxxxx xxxx xx xxxxxxxxxx xxx xxxxxxxxx xxxxxxx, xxx xxxxxxx xxxxx xxxxxx. Xx xx, xxx xxx xxxx xxx xxxxxx xx xxxx xxxx xxxxxxxxxx xxxx xx xxxxxxxxx xx xxxx xxxxxxxxxxx xxxxxx xxxxx xx xxxxxxxxxx xxx xxxxxxxx, xxx xxxx xxxxxx xxxxxxxx xxxxxxxxxx, xxxx xxxxxx xxxx xxx xxxxxxxxxxxxx xxxxx xxx xxxx xxxxxxxxxxxx. Xxx xxx xxx Xxxxxx Xxxxxx xx Xxxxx xxx Xxxxxx Xxxxxx xx xxxx xxx xxxxx XXX xxx xxx xxxxxxx xxxx xxxx xxx xxxxx XXXX xxxxxxx. Xxxx xxxx xx x XXX xxx xxx xxxx xxxxx xxx xxx xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn279427) xxx [**XxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279244).

Xxx xxxxxxx-xxxxxxx xxxxxxxx xx XXX xxxx xxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxxxxxx:

-   Xxxxx xx xx xxxxx-xx xxxxxxx xxx xxxx-xxxxx xxxxxxxxxx xxx xxx [**XXxxxXxxxxXxxx**](T:System.ComponentModel.IDataErrorInfo) xxx [**XXxxxxxXxxxXxxxxXxxx**](T:System.ComponentModel.INotifyDataErrorInfo) xxxxxxxxxx.
-   Xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209820) xxxxx xxxx xxx xxxxxxx xxx xxxxxxxx xxxxxxxxxx xxxxxxxxxx xxxxxxxxx xx Xxxxxxx Xxxxx Xxxxxxxxxxx. Xxxxxxx, xxx xxx xxxxx xxxxxxxxx [**XXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209903) xx xxxxxxx xxxxxx xxxxxxxxxx.
-   Xxx [**XXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209903) xxxxxxx xxxx xxxxxxxx xxxxxxx xx xxxxxxxxxx xxxxxxx xx [**XxxxxxxXxxx**](T:System.Globalization.CultureInfo) xxxxxxx.
-   Xxx [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209833) xxxxx xxxx xxx xxxxxxx xxxxx-xx xxxxxxx xxx xxxxxxx xxx xxxxxxxxx, xxx xxxxxxxx xxxxx xxxxxxxxxxx. Xxx xxxx xxxx, xxx [Xxxx xxxxxxx xx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt210946) xxx xxx [Xxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=226854).

Xxxxxxxx xxx xxxx xxxxxxx xxxxxxxx xxx xxxxx xxxxxxx xxxxxxxxx, Xxxxxxx YY xxxxxx xxx xxxxxx xx x xxx xxx xxxx xxxxxxxxxx xxxxxxx xxxxxxxxx xxxxxx xxxxxxxx xxxxxxxx, xxxxx xxx xxx {x:Xxxx} xxxxxx xxxxxxxxx. Xxx [Xxxx Xxxxxxx: Xxxxx Xxxx Xxxx' Xxxxxxxxxxx Xxxxxxx Xxx Xxxxxxxxxxxx xx XXXX Xxxx Xxxxxxx](http://channel9.msdn.com/Events/Build/2015/3-635), xxx xxx [x:Xxxx Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619989).

## Xxxxxxx xx Xxxxx xx x xxxx xxxxx

Xxx xxx xxxx xxx [**Xxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242760) xxxxxxxx xx xxx xxxxxxxx xx x xxxx xxxxx xxxx'x xx xxxx [**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210107). Xxxx'x x xxxxxxx xxxxxxxxxxxxxx xx xxxx x xxxxxxxx xx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxx:

```csharp
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">C#</th>
</tr>
</thead>
<tbody>
<tr class="odd">
    // this.BookCoverImagePath contains a path of the form "/Assets/CoverImages/one.png".
    return new BitmapImage(new Uri(this.CoverImagePath, UriKind.Relative));
```

Xx x XXX xxx, xxx xxx xxx xx-xxxx [XXX xxxxxx](https://msdn.microsoft.com/library/windows/apps/jj655406). Xx xxxx xxx xxx xxxx xxx xxxx xx xxxx xxxx xxx xxxx, xxx xxx xxx x xxxxxxxxx xxxxxxxx xx xxx **Xxxxxx.Xxx** xxxxxxxxxxx xx xxx xxx xx-xxxx XXX xxxxxx xx x xxxx XXX xxx xxxxxx xxx xxxx xx xxx xxxx xxxx xxxx. Xxxx xxxx:

```csharp
    // this.BookCoverImagePath contains a path of the form "/Assets/CoverImages/one.png".
    return new BitmapImage(new Uri(new Uri("ms-appx://"), this.CoverImagePath));
```

Xxxx xxx, xxx xxxx xx xxx xxxx xxxxx, xxx xxxx xxxxxx xx xxx xxxxx xxxx xxxxxxxx, xxx xxx xxxxxxxx xx xxx XXXX xxxxxx, xxx xxx xxxx xxxxxxx xxx xxxx.

## Xxxxxxxx, xxx xxxxxxx xxxxxx/xxxxxxxxx

Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx xxx xxxxxxxx xxxxxxx xx xxx **Xxxxxxxxx.Xxxxx.Xxxxxxxx** xxxxxxxxx xxx xxx **Xxxxxx.Xxxxxxx.Xxxxxxxx** xxxxxxxxx. XXXX XXX xxxx xxx xxxxxxxx xxxxxxx xx xxx [**Xxxxxxx.XX.Xxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227716) xxxxxxxxx. Xxx xxxxxxxxxxxx xxx xxxxxx xx XXXX xxxxxxxx xx xxx XXX xx xxxxxxxxx xxx xxxx xx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxxxx. Xxx, xxxx xxxxxxx xxxx xxxx xxxx xx xxxxxxx xxx xxx xx xxxxxxxxx xxxxxxxx xxx xx xxxxx xxxx xxxx Xxxxxxx xxxx. Xxxx xxx xxxxxxxx xxxxxxxx.

| Xxxxxxx xxxx | Xxxxxx |
|--------------|--------|
| XxxxxxxxxxxXxx | Xxx [Xxxx.XxxXxxXxx](https://msdn.microsoft.com/library/windows/apps/hh702575) xxxxxxxx. |
| XxxxxxxxxxxXxxXxxxXxxxxx | Xxx XXX xxxxxxxxxx xx xxx [Xxxxx](https://msdn.microsoft.com/library/windows/apps/dn279538) xxxxxxxx. XxxxxxxXxxxxxxx xx xxx xxxxxxx xxxxxxxx xx XxxxxxxXxx. Xxx XXXX xxxxxx xxxxxxxxxx xx xxxxxxx'x xxxxx xxx xx xxx xxxxx xx xxx xxxxxxx xxxxxxxx. |
| XxxxxxxxxxxXxxXxxxXxxx | Xxx XXX xxxxxxxxxx xx xxx [XxxXxxXxxxxx.Xxxxx](https://msdn.microsoft.com/library/windows/apps/dn279261) xxx xx xxx xxxx xxxx xxxx. |
| XxxxxxxXxxx (xx xxx Xxxxxxx Xxxxx Xxxxxxx) | Xxx x xxxxxx xxxxxxxxx xxx-xxx, xxx [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/dn279496). |
| XxxxxxxXxxxXxxxxx.XxxxXxxxxx xxxxx | Xxxxxxxxxx xxxx xxx XXX xxxxxxxxx xxxxxxx xxx xxxxx xxxx xxx xxxxxxx Xxxxxx xx xxx xxxxxx xxxxxxxx. Xxx xxx [Xxxxxxxxx xxxxxxx xxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/jj649432). |
| XxxxXxxxXxxxxxxx xxxx xxxxxxx xxxx | Xxx Xxxxxxx Xxxxx Xxxxxxxxxxx XxxxXxxxXxxxxxxx xxxxxxxxx xx xxx xxxx, xxxxx xxx xx xxxx xx xxxxxxx. Xxxxx, xx xx xxxx xx xxxxxxx xxxx xxxx xx xxxxxxx xx x xxx, xxx xxxxxxx, x xxxx xx xxxxx xxxxxxx xx xxxxxxx xxxxxx. Xxxxxx, xx xx xxxx xx "xxxx" xxxxxxx xxx xxxxxxxx xxxxx: xxx xxxxxxx xxxx xx xxxxx (xxx xxxxxxx, xxxxx), xxx x xxxx xx xxxx xxx xxxxx xxxx xxxxxxxxxx (xxx xxxxxxx, xxxxxxx xxxxxxx). Xxxx xxx XXX, xxx xxx xxxxxxx xxxxxxx xxxx xxxx xxx [Xxxxxxxxxx xxx xxxx xxx xxxx xxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt186889). |
| XxxxXxxxXxxxxxxx xxxx xxxx xxxx | Xxx xxxxxxxxxxx xxxxxxx, xx xxx xxxx xx xxxx xxxx xxxxx, xx xxxxxxxxxxx XxxxXxxxXxxxxxxx xxxxxxx xx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx xxx xxxx xxx xxxx, xxx-xxxxxxx xxxx. Xx x XXX xxx, [XxxxXxxx](https://msdn.microsoft.com/library/windows/apps/br242705) xxx xxxxxxxxx xxx xxxx xxxxx xx xxxxx xxxxxxx xx xxx xxx xxxx xxx xxxxxxxx xx xxxxxxxx. |
| Xxxxxxxx | Xxx Xxxxxxx Xxxxx Xxxxxxxxxxx Xxxxxxxx xxxxxxx xxxx xx xxx [Xxxxxxxxxx xxx xxx xxxxxxxx xx Xxxxxxx Xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/dn449149) xxx Xxxxxxxxxx xxx xxx xxx xxxxxxx. <br/> Xxxx xxxx x Xxxxxxxx xxxxxxx xxxxx xxxxxx xxxx xxx xxxx xxxxxxx xx xxx xxxxx, xxx xxx xxxxxxxxxx xxxxx xxxxx xx xxxxxxxx xxxxxxxx xx xxx xxxxxxxx. [Xxx](https://msdn.microsoft.com/library/windows/apps/dn251843) xxxxxxxx xx xxx xxxx xxxxxx, xxx xxxxxxxx xx xxx xxxx. |
| Xxxxx | Xxx XXX xxxxxxxxxx xx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx Xxxxx xxxxxxx xx [Xxxxxxx.XX.Xxxx.Xxxxxxxx.Xxxxx](https://msdn.microsoft.com/library/windows/apps/dn608241). Xx xx xxxxxxxxx xxx xxx xxxxxx xxxxxxxx. |

**Xxxx**   Xxx XxxxxxxXxxx xxxxxx xxxxx xx xxxxxxxx xx xxxxxx xxxxxx/xxxxxxxxx xx Xxxxxxx YY xxxx, xxx xxx xx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx. Xxxxx xxx xxxxx xxxxxxx xxx xxxx xxxxxxxx xxxxxx xxxxxx/xxxxxxxxx xxx xxx xx xxxxxxxxxxx xxx Xxxxxxx YY xxxx, xxxxxxxxx xxxxxx xxxxxxxx xxxx xxx xxx xxxxx, xxxxxxx xx xxx xxxx xx xxxxxx xxxxxx xxxx, xxx xxxxxxxxxxx xxxxxxxxxxxx xxxx xx xxx Xxxxxxx YY xxxxxxx xxxxxx/xxxxxxxxx. Xx xxxxxxxxx xxxx xxx xxxx x xxxxx xxxx xx x xxxxxxx'x xxxxxxx xxxxxxxx xxx Xxxxxxx YY xxx xxxx xx-xxxxx xxxx xxxxx xxx xxxxxxxx xxxxxxxxxxxxx xx xxxx.

Xxx xxxx xxxx xx XXX xxxxxxxx, xxx [Xxxxxxxx xx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185405), [Xxxxxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/mt185406), xxx [Xxxxxxxxxx xxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn611856).

##  Xxxxxx xxxxxxxx xx Xxxxxxx YY

Xxxxx xxx xxxx xxxxxxxxxxx xx xxxxxx xxxxxxxx xxxxxxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx xxx Xxxxxxx YY xxxx. Xxx xxx xxx xxxxxxx, xxx [Xxxxxx](http://dev.windows.com/design). Xxxxxxx xxx xxxxxx xxxxxxxx xxxxxxx, xxx xxxxxx xxxxxxxxxx xxxxxx xxxxxxxxxx: xx xxxxxxxxx xx xxxxxx xxx xxxxxx xxxxxx xxx xxxxxxxxxx xxxxxxx xxxxxxxx xx xxxxxxx xxx xxxxxx, xxxxxxxx xxxxxxxx xxxxxx xxxxxxxx, xxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxxx xxxxxx; xxx xxxxxx xxxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxx; xxxxxx xx x xxxx; xxx xxxxx xxxx xxxxxxxxxxx xx xxxx xxxx xxxxx xxxxxxxxxx.

## Xxxxxxxxxxxx xxx xxxxxxxxxxxxx

Xxx xxxxxxxxx xxxxxxx, xxx xxx xx-xxx xxx .xxxx xxxx xxxx xxxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxxx xx xxxx XXX xxx xxxxxxx. Xxxx xxx xxxx xxxx, xxx xx xx xxx xxxxxxx, xxx xxxxxx xx xx Xxxxxxxxx.xxxx xx xxxx xxx xxxxxx xxxxxxxxx xxxx xxxx xx xx xxxxxxx. Xxx **Xxxxx Xxxxxx** xx **XXXXxxxxxxx** xxx **Xxxx xx Xxxxxx Xxxxxxxxx** xx **Xx xxx xxxx**. Xxx xxx xxxx xxx xxx xxxxxxx xx xxxxxx xx xxxxxxxxxx xxx **x:Xxx** xxxxxxxxx xx xxxx XXXX xxxxxxxx. Xxx [Xxxxxxxxxx: Xxxxx xxxxxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh965329).

Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx xxx xxx **XxxxxxxXxxx** xxxxx xx xxxx xxxxxxxxx xx xxx. XXX xxxx xxx XXX (Xxxxxx Xxxxxxxx Xxxxxxxxxx), xxxxx xxxxxxx xxx xxxxxxx xxxxxxx xx xxx xxxxxxxxx (xxxxxxxxxxxx, xxxxx, xxx xxxxx) xxxx xx xxxxxxx xxx xx xxx Xxxxxx Xxxxxx xxxxxx xxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxxxxx xxx xxxxx, xxxx, xxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn611859).

Xxx [**XxxxxxxxXxxxxxx.XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206071) xxxxx xxxxxxxxx xxx xx xxxx xxxxxx xxxxxx-xxxxxxxx xxxxxxxxx xxxxx xx xxx xxxxxx xxxxxx xxxxxxxx xxxxxxxxx xxxxxx.

## Xxxxx xxx xxxxxxxx

Xx xxx xxxx xxxxx XXX xxxxx xxx xxxxxxxx, xxxx xx xxxx xxxx xxx Xxxxxxx xxxxxx xxxxxxxxxx xxxxxxxxx x xxxxxx xxxxxxxxx xx xxxxxxxx xxxxxxxxxxx, xxxxxxxxx xxxxxxxxx xxxxxxxxxx xxx xxxxxxx. Xxxxxxx xxxxxx xx xxxxxxxx xx xxxxx xxx xxxxx xxxxxxx, xxxxxxxxxx, xxx xxxxxx. Xx xxxx xxx xxxxxxx xxx xxxx xxxxxxxxxx, xxxx xx xxxx xxxx xxxx xxxx xxx xxxxx-xx xxxx.

Xxxxxxx Xxxxx Xxxxxxxxxxx xxx x **XxxxxxXxxxxxxxXxxxx** xxxx xxxxx xx xxx xxxxxxx xx xxx XXX, xxxxxxxx xxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br228076) xxxxx xxx. Xx xxxx xxxxx, xxx xxxx xx xxxx xx xxx x xxxxxxx xxxxxx xxxx x xxxxxx. Xxxx xxxx xxx xxx [xxxxxx x xxxxxx xxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/desktop/dd756679) xxxx XxxxxxYX xx x [Xxxxxxxxx XxxxxxX](https://msdn.microsoft.com/library/windows/desktop/ee663274) xxx XXXX X++ XXX.

Xxxxxxx Xxxxx Xxxxxxxxxxx xxx xxx **Xxxxxx.Xxxxxxx.XXXxxxxxx.XxxxxxxXxxx** xxxxxxxx, xxx xxxx xxxxxxxx xx xxx x xxxxxx xx xxx XXX [**XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208911) xxxx. Xx xxxx xxxxx, xxx xxxx xx xxxx xx xxx x xxxxxxx xxxxxx xxxx x xxxxxx. Xxx xxx xxx [xxxxxx xx xxxxxxx xxxx](https://msdn.microsoft.com/library/windows/desktop/ee329947) xxxx XxxxxxYX xx x [Xxxxxxxxx XxxxxxX](https://msdn.microsoft.com/library/windows/desktop/ee663274) xxx XXXX X++ XXX xxx. Xxx, x xxxxxx xxx xxxx xxx **XxxxxxxXxxx** xx xx xxx x xxxxxx xxxxxx xxxx xxxxxx xx xxxx xxxxx xxx xxxx xxxxxx. Xxx xxxxxx xxxxxxxx, xxx xxx xxx xxxxx-xxxxx xxxxxx xxxxxxx (xxxx xx xxx xxx xxxxxx xxxxxxxxxxx xxxxx). Xxx, xx xxxx x xxxxx-xxxxx xxxxxx (xxxx xx xxx xxxxx xxxxx xxxxxxxxxxx xxxxx), xxxxxxxx x xxxxxxxxx xxxxxxxx.

![x xxxxx-xxxxx xxxxxx](images/wpsl-to-uwp-case-studies/wpsl-to-uwp-theme-aware-bitmap.png)

Xx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxx, xxx xxxxxxxxx xx xx xxx xx xxxxx xxxx (xx xxx xxxx xx x xxxxxx) xx xxx **XxxxxxxXxxx** xxx x **Xxxxxxxxx** xxxxxx xxxx xxx xxxxxxxxxx xxxxx:

```xaml
    <Rectangle Fill="{StaticResource PhoneForegroundBrush}" Width="26" Height="26">
        <Rectangle.OpacityMask>
            <ImageBrush ImageSource="/Assets/wpsl_check.png"/>
        </Rectangle.OpacityMask>
    </Rectangle>
```

Xxx xxxx xxxxxxxxxxxxxxx xxx xx xxxx xxxx xx x XXX xxx xx xx xxx x [**XxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn279306), xxxx xxxx:

```xaml
    <BitmapIcon UriSource="Assets/winrt_check.png" Width="21" Height="21"/></code></pre></td>
</tr>
</tbody>
</table>
```

Xxxx, xxxxx\_xxxxx.xxx xx xx xxxxx xxxx xx xxx xxxx xx x xxxxxx xxxx xx xxxx\_xxxxx.xxx xx, xxx xx xxxxx xxxx xxxx xx xxx xxxx xxxx. Xxxxxxx, xxx xxx xxxx xx xxxxxxx xxxxxxx xxxxxxxxx xxxxx xx xxxxx\_xxxxx.xxx xx xx xxxx xxx xxxxxxxxx xxxxxxx xxxxxxx. Xxx xxxx xxxx xx xxxx, xxx xxx xx xxxxxxxxxxx xx xxx xxxxxxx xx xxx **Xxxxx** xxx **Xxxxxx** xxxxxx, xxx [Xxxx/xxxxxxxxx xxxxxx, xxxxxxx xxxxxxxx, xxx xxxxx xxxxxxx](#view-effective-pixels-viewing-distance-and-scale-factors) xx xxxx xxxxx.

X xxxx xxxxxxx xxxxxxxx, xxxxx xx xxxxxxxxxxx xx xxxxx xxx xxxxxxxxxxx xxxxxxx xxx xxxxx xxx xxxx xxxxx xxxx xx x xxxxxx, xx xx xxx xxx xxxxx xxxxxx—xxx xxxx x xxxx xxxxxxxxxx (xxx xxxxx xxxxx) xxx xxx xxxx x xxxxx xxxxxxxxxx (xxx xxxx xxxxx). Xxx xxxxxxx xxxxxxx xxxxx xxx xx xxxx xxxx xxx xx xxxxxx xxxxxx, xxx [Xxx xx xxxx xxxxxxxxx xxxxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh965324). Xxxx x xxx xx xxxxx xxxxx xxx xxxxxxxxx xxxxx, xxx xxx xxxxx xx xxxx xx xxx xxxxxxxx, xxxxx xxxxx xxxx xxxx, xxxx xxxx:

```xaml
<colgroup>
<col width="100%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">XAML</th>
</tr>
</thead>
<tbody>
<tr class="odd">
    <Image Source="Assets/winrt_check.png" Stretch="None"/></code></pre></td>
</tr>
</tbody>
</table>
```

Xx Xxxxxxx Xxxxx Xxxxxxxxxxx, xxx **XXXxxxxxx.Xxxx** xxxxxxxx xxx xx xxx xxxxx xxxx xxx xxx xxxxxxx xxxx x **Xxxxxxxx** xxx xx xxxxxxxxx xxxxxxxxxx xx XXXX xxxxxx xx xxx **XxxxxxXxxxxxxx** xxxx-xxxxxxxx. Xx xxx XXX, xxx xxxx xx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br208919) xxxxxxxx xx [**XxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br210259), xx xxx xxx xxxx xxxx x xxxxxxxxxxx xxxxxx. Xxxxxxxx x xxxxxxxxx xx xx xxxxxxx xxxxx xxxx-xxxxxxxx xxxxx xx xxx xxxxxxxxxx. Xx, xx xxxx x xxxxxxxx xxxxxx xx xxxxxx, xxxxxxx xxx **Xxxx** xxxxxxxxx xxxxxx xxx xxxx xx xxxx xxxxxxxx xxxxxxx xxxxxx xxxxxxx xx xxx xxxxxxxxx:

```xaml
    <UIElement.Clip>
        <RectangleGeometry Rect="10 10 50 50"/>
    </UIElement.Clip>
```

Xxxx xxxx xxx xxx [xxx xxxxxxxxx xxxxxxxx xx x xxxx xx x xxxxx](https://msdn.microsoft.com/library/windows/desktop/dd756654) xxxx XxxxxxYX xx x [Xxxxxxxxx XxxxxxX](https://msdn.microsoft.com/library/windows/desktop/ee663274) xxx XXXX X++ XXX xxx.

## Xxxxxxxxxx

Xxxx xxx xxxxxxxx xx x xxxx xx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxx, xxx xxx x Xxxxxxx Xxxxxxxx Xxxxxxxxxx (XXX) xxxxxxxxxx xxxxxx:

```csharp
    NavigationService.Navigate(new Uri("/AnotherPage.xaml", UriKind.Relative)/*, navigationState*/);</code></pre></td>
```

Xx x XXX xxx, xxx xxxx xxx [**Xxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694) xxxxxx xxx xxxxxxx xxx xxxx xx xxx xxxxxxxxxxx xxxx (xx xxxxxxx xx xxx **x:Xxxxx** xxxxxxxxx xx xxx xxxx'x XXXX xxxxxx xxxxxxxxxx):


```csharp
    // In a page:
    this.Frame.Navigate(typeof(AnotherPage)/*, parameter*/);

    // In a view model, perhaps inside an ICommand implementation:
    var rootFrame = Windows.UI.Xaml.Window.Current.Content as Windows.UI.Xaml.Controls.Frame;
    rootFrame.Navigate(typeof(AnotherPage)/*, parameter*/);
```

Xxx xxxxxx xxx xxxxxxx xxxx xxx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxx xx XXXxxXxxxxxxx.xxx:

```xml
    <DefaultTask Name="_default" NavigationPage="MainPage.xaml" />
```

Xx x XXX xxx, xxx xxx xxxxxxxxxx xxxx xx xxxxxx xxx xxxxxxx xxxx. Xxxx'x xxxx xxxx xxxx Xxx.xxxx.xx xxxx xxxxxxxxxxx xxx:

```csharp
    if (!rootFrame.Navigate(typeof(MainPage), e.Arguments))</code></pre></td>
```

XXX xxxxxxx xxx xxxxxxxx xxxxxxxxxx xxx XXX xxxxxxxxxx xxxxxxxxxx, xxx xx xxxx xxx xxx xxxxxxxxxx xx XXX xxxxxxxxxx, xxxxx xx xxx xxxxx xx XXXx. XXX xxxxxxx xxxxxx xx xxxxxxxx xx xxx xxxxxx-xxxxx xxxxxx xx xxxxxxxxxxx x xxxxxx xxxx xxxx x XXX xxxxxx, xxxxx xxxxx xx xxxxxxxxx xxx xxxxxxxxxxxxxxx xxxxxx xxxxxx xxx xxxx xxxx xx x xxxxxxxxx xxxxxx xxx xxxxx xx x xxxxxxxxx xxxxxxxx xxxx. XXX xxxx xxx xxxx-xxxxx xxxxxxxxxx, xxxxx xx xxxxxxxx-xxxxx xxx xxxxxxxx-xxxxxxx, xxx xxxx xxx xxxx xxx xxxxxxx xxxx XXX xxxxxxx xxxxxx. Xxx xxx xxxx xxx xxxxxxxx xxxxxxxxxx xx xx xxxx xxxxx xxxx xxxxxxx xx xxx xxxxxx xxxx xx xxxx xxx xxxx xxx xxxxx x xxxxxxxxxx xxxxxxxx xx xxx xxxxxxx xx xx xxxxxxxx xxxx xxxx, xx xxxxxxxxx xxxxxxxxx. Xxx xxxx xxxx xxx xx xxxxxxxx xx xxxxxxx x xxxxxxxxxx xxxxxxxxx xxxx xxx xxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242694) xxxxxx.

Xxx xxxx xxxx, xxx [Xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt187344).

## Xxxxxxxx xxx xxxxxxxxx

Xxx xxxxxx xxxxxxxx xxx xxxxxxx xxx Xxxxxxx YY xxx xxxxxxxxxxxx xxxxxxx xxxxxx xxxxxx xxxx xxxxxxx, xxx xxxx xxxxxx xxxxxxxx xxxx xxxx xxxx xxxxxxx xx xxxxxxx. Xxx XXXX xxxxxx xxxxxx xx Xxxxxx Xxxxxx xxxxxxxxxx xxxxxxxxxx xx xxxxxxxx xxxx xxxx xxx'x xx xxxxxxxx. Xxx xxxxxxx, xxx XXXX xxxxxx xxxxxx xxxx xxxxxxxxx x xxxxxxxxx xx xxx xxxxx xxx `PhoneTextNormalStyle` xxxx x xxx xxxxxxxx. Xx xxxx xxx'x xxxxxxxxx, xxxx xxx xxx xxxx xxxxxxxxxxx xxxxxxxxx xxxx xxx xxx xx xxxxxx xx xx xxx xxxxxxxx xx xxxxxx. Xx, xx'x xxxxxxxxx xx xxxxxx xx XXXX xxxxxx xxxxxxxxxxx. Xxx xxx xxxx xxxx Xxxxxx Xxxxxx xx xx x xxxxx xxxx xxx xxxxxxxx xxxx xxxxxx.

Xxxx, xxx [Xxxx](#text), xxxxx.

## Xxxxxx xxx (xxxxxx xxxx)

Xxx xxxxxx xxxx (xxx xx XXXX xxxxxx xxxx `shell:SystemTray.IsVisible`) xx xxx xxxxxx xxx xxxxxx xxx, xxx xx xx xxxxx xx xxxxxxx. Xxx xxx xxxxxxx xxx xxxxxxxxxx xx xxxxxxxxxx xxxx xx xxxxxxx xxx [**Xxxxxxx.XX.XxxxXxxxxxxxxx.XxxxxxXxx.XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn610343) xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn610339) xxxxxxx.

## Xxxx

Xxxx (xx xxxxxxxxxx) xx xx xxxxxxxxx xxxxxx xx x XXX xxx xxx, xxxxx xxxxxxx, xxx xxx xxxx xx xxxxxxx xxx xxxxxx xxxxxxx xx xxxx xxxxx xx xxxx xxxx xxx xx xxxxxxx xxxx xxx xxx xxxxxx xxxxxxxx. Xxx xxxxx xxxxxxxxxxxxx xx xxxx xxx XXX **XxxxXxxxx** xxxxxx xxxxxx xxxx xxx xxxxxxxxx. Xxxx xxx xxxx xxxx xxxxxxxxxx xx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxx xxx xxxx. Xxxxxxxxxxxxx, xxx xxx xxxxxx xxxx xxx xxxxxxxxx xxxxxx xxx xxxx xxx xxxxxxxxxx xxxx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxx xxxxxx xxxx xxxxx.

![xxxxxx xxxxxxxxx xxxxxx xxx xxxxxxx YY xxxx](images/label-uwp10stylegallery.png)
Xxxxxx XxxxXxxxx xxxxxx xxx Xxxxxxx YY xxxx

Xx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxx, xxx xxxxxxx xxxx xxxxxx xx Xxxxx XX. Xx x Xxxxxxx YY xxx, xxx xxxxxxx xxxx xxxxxx xx Xxxxx XX. Xx x xxxxxx, xxxx xxxxxxx xx xxxx xxx xxx xxxx xxxxxxxxx. Xx xxx xxxx xx xxxxxxxxx xxx xxxx xx xxxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx, xxx xxx xxx xxxx xxx xxxxxxx xxxxx xxxxxxxxxx xxxx xx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209671) xxx [**XxxxXxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br244362). Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxx xxxxx](https://msdn.microsoft.com/library/windows/apps/hh700394.aspx) xxx [Xxxxxx XXX xxxx](http://dev.windows.com/design).

## Xxxxx xxxxxxx

Xxx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxx, xxx xxxxxxx xxxxx xx xxxx xx xxxxxxx. Xxx Xxxxxxx YY xxxxxxx, xxx xxxxxxx xxxxx xxx xxxxxxx, xxx xxx xxx xxxxxxx xxx xxxxx xxxx xx xxxxxxxxx x xxxxxxxxx xxxxx xx Xxx.xxxx. Xxx xxxxxxx, xx xxx x xxxx xxxxx xx xxx xxxxxxx, xxx `RequestedTheme="Dark"` xx xxx xxxx Xxxxxxxxxxx xxxxxxx.

## Xxxxx

Xxxxx xxx XXX xxxx xxxx xxxxxxxxx xxxxxxx xx Xxxx Xxxxx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx, xxxxxxxx xxxxx xxx xxxx xxxxxxxxxxx. Xxx xxxxxxx, xxxx xxxx xxxxx xxx **Xxxxxxxxx.Xxxxx.Xxxxx.XxxxxXxxx.Xxxxxx** xxxxxx xx xxxxxx xxxxxxxxx xxxxx xxxxxx xx xxxxxx xx xxxx [**XxxxxxxxxXxxx.XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br230606). Xxxx xx x xxxxxx-xxx-xxxxx xxxxxxx, xxxxx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxxx:


```csharp
    var tileData = new IconicTileData()
    {
        Title = this.selectedBookSku.Title,
        WideContent1 = this.selectedBookSku.Title,
        WideContent2 = this.selectedBookSku.Author,
        SmallIconImage = this.SmallIconImageAsUri,
        IconImage = this.IconImageAsUri
    };

    ShellTile.Create(this.selectedBookSku.NavigationUri, tileData, true);
```

Xxx xxx XXX xxxxxxxxxx:

```csharp
    var tile = new SecondaryTile(
        this.selectedBookSku.Title.Replace(" ", string.Empty),
        this.selectedBookSku.Title,
        this.selectedBookSku.ArgumentString,
        this.IconImageAsUri,
        TileSize.Square150x150);

    await tile.RequestCreateAsync();
```

Xxxx xxxx xxxxxxx x xxxx xxxx xxx **Xxxxxxxxx.Xxxxx.Xxxxx.XxxxxXxxx.Xxxxxx** xxxxxx, xx xxx **Xxxxxxxxx.Xxxxx.Xxxxx.XxxxxXxxxXxxxxxxx** xxxxx, xxxxxx xx xxxxxx xx xxx xxx [**XxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208622), [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208628), [**XxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208616), xxx/xx [**XxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701637) xxxxxxx.

Xxx xxxx xxxx xx xxxxx, xxxxxx, xxxxxx, xxxxxxx, xxx xxxxxxxxxxxxx, xxx [Xxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh868260) xxx [Xxxxxxx xxxx xxxxx, xxxxxx, xxx xxxxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259). Xxx xxxxxxxxx xxxxx xxxxx xx xxxxxx xxxxxx xxxx xxx XXX Xxxxx, xxx [Xxxx xxx xxxxx xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/hh781198).

## Xxxxxx

Xxxx xxxx xxxxxxxx x xxxxx xxxx xxx **Xxxxxxxxx.Xxxxx.Xxxxx.XxxxxXxxxx** xxxxx xxxxxx xx xxxxxx xx xxx xxx [**XxxxxXxxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208642), [**XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208653), [**XxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208641), xxx/xx [**XxxxxxxxxXxxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208607) xxxxxxx. Xxxx xxxx xx xxxxxx xxxxxxx, xxx xxxxxxxx-xxxxxx xxxx xxx "xxxxx" xx "xxxxxx".

Xxx [Xxxxxxx xxxx xxxxx, xxxxxx, xxx xxxxx xxxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh868259).

## Xxxx/xxxxxxxxx xxxxxx, xxxxxxx xxxxxxxx, xxx xxxxx xxxxxxx

Xxxxxxx Xxxxx Xxxxxxxxxxx xxxx xxx Xxxxxxx YY xxxx xxxxxx xx xxx xxx xxxx xxxxxxxx xxx xxxx xxx xxxxxx xx XX xxxxxxxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxxxx xx xxxxxxx. X Xxxxxxx Xxxxx Xxxxxxxxxxx xxx xxxx xxxx xxxxxx xx xx xxxx. Xxxx Xxxxxxx YY, xxx xxxxxxx xx xxxx xxxxxx xxx xxxx xxxxxxx xxxx xxxx xx xxxxxxxxx xxxxxx. Xxxx'x xx xxxxxxxxxxx xx xxxx xxxx, xxxx xx xxxxx, xxx xxx xxxxx xxxxx xx xxxxxx.

Xxx xxxx "xxxxxxxxxx" xxxxxx xx x xxxxxxx xx xxxxx xxxxxxx xxx xxx, xx xx xxxxxxxx xxxxxxx, xxxxx xxxxx. "Xxxxxxxxx xxxxxxxxxx" xx xxx xxx xxx xxxxxxxx xxxxxx xxxx xxxxxxx xx xxxxx xx xxxxx xxxxxxx xx xxx xxx xxxxx xxxxxxxxxxx xx xxxxxxx xxxxxxxx xxx xxx xxxxxxxx xxxxx xxxx xx xxx xxxxxx (xxxxx xxxxxxx xxxxx xxx xxxxxxxxxx xx xxxxxxxx xxxxx xxxx). Xxxxxxxxx xxxxxxxxxx xx x xxxx xxxxxx xx xxxxx xx xxxxxxxxxx xxxxxx xxxxxxx xx xx xxxx-xxxxxxx. Xx xxxxxxxxxxxxx xxx xxx xxxxxxx, xxx xxxxxxxxxxx xxx xxxx xx XX xxxxxxxx, xxx xxx xxxx xxx xxxx'x xxxxxxxxxx x xxxx xxx.

Xx x Xxxxxxx Xxxxx Xxxxxxxxxxx xxx, xxx xxxxx xxxxxxx xxx xxxxxxx YYY xxxx xxxxxx xxxx, xxxxxxx xxxxxxxxx, xx xxxxxx xxx xxxx xxxxxxxx xxxxxx xxx xxxxxx xxx, xxx xxxx xxx xxxxx xxxxxxx xx xxxxxxxx xxxx xx. Xxxx xxxxx xxxx xx **Xxxxx** xxxxxxx xxxx `Width="48"` xxxx xx xxxxxxx xxx xxxxx xx xxx xxxxx xx xxx xxxxxx xx xxx xxxxx xxxx xxx xxx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxx.

Xx x Xxxxxxx YY xxx, xx xx *xxx* xxx xxxx xxxx xxx xxxxxxx xxx xxxx xxxxx xxxxxx xx xxxxxxxxx xxxxxx xxxx. Xxxx'x xxxxxxxx xxxxxxx, xxxxx xxx xxxx xxxxx xx xxxxxxx xxxx x XXX xxx xxx xxx xx. Xxxxxxxxx xxxxxxx xxx x xxxxxxxxx xxxxxx xx xxxxxxxxx xxxxxx xxxx, xxxxxxx xxxx YYY xxx xxx xxx xxxxxxxx xxxxxxx, xx YYYY xxx xxx x xxxxxx-xxxxx xxxxxxx, xxx xxx xxxxxx xx xxxx xxxxxx xxxxxx. Xxx xxx xxxx xx xx xx xxxxxxxx xx xxx xxxx-xxxxx xxxxxxxx xxx xxxxxxx xxxxxx xxxxxx xx xxx xxxxxx xxxx. Xxxxx xxxx xxxx xx xxxx xxxxx xxxxx xxx'xx xxx xxx xxxxxxxxxx xx xxxx XX xxxxxxxx xx x xxxxx xxxx xx XXXX xxxxxx. X xxxxx xxxxxx xx xxxxxxxxxxxxx xxxxxxx xx xxxx xxx xxxxxxxxx xx xxxx xxxxxx xx xxxx xx xxx xxx xxxxxxx xxxxxxxx xxxx xx xxx xxxx. Xxx xxxx xxxxx xxxxxx xxxxxx xx xxxx xxx XX xxxxxxx xxxx x xxxxx xxxx xxxxxxxxxx x xxxx-xx-xxxx xxxxxxxx-xxxxx xxxxx (xxx xxxxxxx) xxxxxx xx xxx xxxx xxxxxx x xxxx xxxxxxx xx xxxxxx xxxxx. Xxx xxxxxxxx xxxx xxxxxxx xxxxxx xxxx XX xxx'x xxxxxx xxxxxxxxx xxxxx xx xxxxxxxxx xxxxxxx, xx xxxx xxxxxxx xx xxxx'x xxxxxxxxx xx xxx xxx xxxxxxxxxxx xxxxxx xx xxxxxxx xxxx xxx xxxxxxxxx xxxxx.

Xxxxxxx YYY xxx xxxxxxxx xxx xxxxx xxxxx xx xxxx xxxxxx xxx x xxxxx-xxxxx xxxxxx, xxx xxxx xxxxx xx xxx xxxxxxxxx xxxxxxx xx xxxxxxxxx xxxxxx, x xxxx xx xxxxx xx xx xxxxxxxx xxx xxxxxxxxx xx xxxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxx xxxxxx xx x xxxxxx xx Y.Y.

Xx xxxx xxxx xxx xxx xxx xxxx xxxxxxxxxx xxxxxx xxx xxxxxxxx, xx xxxxxxxxx xxxx xxx xxxxxx xxxx xxxxxx xxxxx xx x xxxxx xx xxxxx, xxxx xxxxxxxx xxx x xxxxxxxxxx xxxxx xxxxxx. Xxxxxxxxx xxxxxx xx YYY%-xxxxx, YYY%-xxxxx, xxx YYY%-xxxxx (xx xxxx xxxxxxxx xxxxx) xxxx xxxx xxx xxxxxxxxx xxxxxxx xx xxxx xxxxx xx xxx xxx xxxxxxxxxxxx xxxxx xxxxxxx.

**Xxxx**  Xx, xxx xxxxxxxx xxxxxx, xxx xxxxxx xxxxxx xxxxxx xx xxxx xxxx xxx xxxx, xxxx xxxxxx YYY%-xxxxx xxxxxx. Xx Xxxxxxxxx Xxxxxx Xxxxxx, xxx xxxxxxx xxxxxxx xxxxxxxx xxx XXX xxxx xxxxxxxx xxxxxxxx xxxxxx (xxxx xxxxxx xxx xxxxx) xx xxxx xxx xxxx, xxx xxxx xxx xxx YYY%-xxxxx. Xxxx xxxxxxxxx xxxxxx xxx xxxx xxx xxx, xxxxxx xxx xxxxxxxx xx xxxx xxxxxxx xxx xxxxxxx YYY%, YYY%, xxx YYY% xxxxx, xxx xxx xxxxx xxxxx.

Xx xxx xxxx xxxxxxxxx xxxxxxx, xxxx xxx xxx xxxx xx xxxxxxx xxxx xxxxxx xx xxxx xxxx xxxxx. Xx xxx'xx xxxxxxxx xxxx xxxxxx xxx, xxxx xx'x xxxxxxxxxx xxxx xx xxxxxxxx xxxx-xxxxxxx xxxxxx xx xxx xxxxx xxxxxx.

Xx xxx'x xxxxxxxxx xxxx xxx xxx xx xxxxxxx xxx xx xxx xxxxx xxxxxxx, xxx xxx xxxx xxxx xx xxxxx xxxxxxx xxx Xxxxxxx YY xxxx xx YYY%, YYY%, YYY%, YYY%, YYY%, YYY%, xxx YYY%. Xx xxx xxxxxxx xxxx, xxx Xxxxx xxxx xxxx xxx xxxxxxx-xxxxx xxxxx(x) xxx xxxx xxxxxx, xxx xxxx xxxxx xxxxxx xxxx xx xxxxxxxxxx. Xxx Xxxxx xxxxxxx xxx xxxxxx xx xxxxxxxx xxxxx xx xxx XXX xx xxx xxxxxx.

Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxxxxx YYY xxx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/dn958435).

## Xxxxxx xxxx

Xx xxxx XXX xxx, xxx xxx xxxxxxx x xxxxxxx xxxx (xxxx xxxxx xxx xxxxxx) xxxx xxxxxxxxxx xxxx. Xxx xxxxxxx xxxxxxx xxxx xx YYYxYYYxxx, xxx xxxx'x xxxx xxx xxxxxxxx xxxxxxx xxxx xxxxxxxx. Xxx xxxxxxx xxxxxxx xxxx xxxxxxxx xx YYYxYYYxxx.

```csharp
   Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize
        (new Size { Width = 500, Height = 500 });
```

Xxx xxxx xxxxx xx [Xxxxxxx xxx X/X, xxxxxx, xxx xxx xxxxx](wpsl-to-uwp-input-and-sensors.md).

## Xxxxxxx xxxxxx

* [Xxxxxxxxx xxx xxxxx xxxxxxxx](wpsl-to-uwp-namespace-and-class-mappings.md)

<!--HONumber=Mar16_HO1-->
