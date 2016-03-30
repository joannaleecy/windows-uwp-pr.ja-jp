---
xxxxxxxxxxx: Xxx xxxxxxxx xx xxxxxxxx XX xx xxx xxxx xx xxxxxxxxxxx XXXX xxxxxx xxxxxxxxxx xxxxxxxxx xxxx xxxx Xxxxxxxxx Y.Y xxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx.
xxxxx: Xxxxxxx Xxxxxxx Xxxxxxx Y.x XXXX xxx XX xx XXX'
xx.xxxxxxx: YYxYYYYY-YYYY-YYYx-xYxY-xYxYxxYxxYYY
---

# Xxxxxxx Xxxxxxx Xxxxxxx Y.x XXXX xxx XX xx XXX

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx xxxxxxxx xxxxx xxx [Xxxxxxxxxxxxxxx](w8x-to-uwp-troubleshooting.md).

Xxx xxxxxxxx xx xxxxxxxx XX xx xxx xxxx xx xxxxxxxxxxx XXXX xxxxxx xxxxxxxxxx xxxxxxxxx xxxx xxxx Xxxxxxxxx Y.Y xxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xxx'xx xxxx xxxx xxxx xx xxxx xxxxxx xx xxxxxxxxxx, xxxxxxxx xxx xxx xxxx xx xxxx xxxx xxxxxxxxxxx xx xxx xxxxxx Xxxxxxxx xxxx xx xxxxxx xxxxxxxxx xxxx xxx'xx xxxxx. Xxx xxxxxxxxxx xxxx xx xxxx xxxx xxxxxx xxxx xxxxxxx xxxxxx xx xx xxxxxx. Xxxx xxxx, xx xxxx, xx xxx xxxx xx xxxx xxxxxxxxxxxx xxxxx xxxx xxxxxxxxxxx XX xxxxxxxx xxxxxx xxxx xx xxxxxxxxxxxxxxx xx xxxx.

## Xxxxxxxxxx xxxx

Xx xxx xxxx xxxx xx xxx xx xxx xxxxx xxxxx xxxx xxxxxxx xxxxxx, xxx xxx xxxxxxx xx xxxx xxx xxx xxx-xxxxxxxxx xxxx. Xxxx xxxxxxx, xxx xxxxx xx x xxxx, xxx xxxxx xx xxx xxxxxxxxx xxxxxx xx xxxx xxxxxxx (xxx xxx xxxxxxxx xxxxx: [Xxxxxxxxxxxxxxx](w8x-to-uwp-troubleshooting.md)), xxxxx xxx xxxxx xxx xxxxxxx xxxxxx xxx xxxxxx-xxx xxx xxxx xxxx xx xxxxxxxx.

## Xxxxxxxx/xxxxxxxxxx XX

Xxxxxxx xxxx xxx xxx xxx xx x xxxxxxxxxxx xxxx xxxxx xx xxxxxxx—xxxx xxxx xxx xxx xxxxxx xxxx xxx xxxxxxxxxx—xxx'xx xxxx xx xx xxxxxx xxx xxxxxxx xxxxx xx xxxx xxxx xxx xxx xxx'xx xxxx xx xxxxxx xxxx XX xx xxxx xxx xxxx xx xxxxx xxxxxxx. Xxx xxx xxx xxx xxxxxxxx Xxxxxx Xxxxx Xxxxxxx xxxxxxx xx xxxxxxxxxxx xxxxxx xxxxxx xxxx xxx xx xxxxxx xxxxxx xx xxxxxxxx, xxx xx xxxxxxx xx xxx xx xx xxxx xx xxxxx xx xxx xxxxxxx [Xxxxxxxx XX](w8x-to-uwp-case-study-bookstore2.md#adaptive-ui) xx xxx XxxxxxxxxY xxxx xxxxx xxxxx.

## Xxxx xxxxxx xxxxxxxx

Xxx Xxxxxxxxx Y.Y xxxx, Xxxxxxx Xxxxx xxxx xxx Xxxxxxx Xxxxx Xxxxx xxxx xxxx xxxxxxxxx xxxxxxxxxx xx xxx XX xxx xxxx xxx xxx xxxxxx xxx xxxxxx xxx xxx xxxx xxxxxx. Xxx, xxx Xxxxxxx YY xxxx, xxx xxx xxx x xxxxxx xxxxxxxx xx xxxx xxx. Xx xxxxxx xxxxxxx, xxx xxxxxx xx xxxxxxxx xxx xxx xx x xxxxxxxxxx xxxxxx xx xxx xxxxxx, xx xx x xxxxxx xx xxx xxxxx. Xx x xxxxxxx xxxxxx, xxx xxx x xxxxxx xx xxxx xxx'x xxxxxx xxxxxxxx xxxx-xxxxxxxxxx xx xxxxxxxx xxxxxx xxx xxx, xxx xxxx xxxxxxx xx xxx xxxxx xxx xxx xxxxxxxx xxxx xx xx xxx xxxx xxx xxx Xxxxxx xxxx. Xxx xxxx xxxxxx xxxxx xx x xxxxxxxxx xxxxxxx xxxxxx xxx xxxxxx xxxxxxxx, xxx xxxxxxx xxxxxxxxxxx xx xxxxxxxx xx xx xxxxxxxx xxxxx xxx xxxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn893596) xxxxx.

Xxx xxxxxxx xxxxx xxxxx xxx xxx xxxxxx xxxxxxxx xxx xx xx xxxx xxx xxxxx xxxxx xxx xxxx xxxxxxxxxx xxxxxxx xx xxx xxxxx, xxx xxxxx xxx xx xxx xxxx xx xxxxxxx xxxxxxxxxx (xxx xxxxxxx, xx xxxx xxxxx xxxxxxx xxxxxxx).

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
        // but it will have no effect. Such device families provide back button UI for you.
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
   Windows.UI.Xaml.Application.Current.Exit();</code></pre></td>
</tr>
</tbody>
</table>
```

## Xxxxxx

Xxx xxx'x xxxx xx xxxxxx xxx xx xxxx xxxx xxxx xxxxxxxxxx xxxx xxxxxx, xxx xxx xx xxxx xx xxx xxxx XX xx xxxx xxx xx xxxx xxx xxxxx xx xxx Xxxxxx xxx, xxxxx xx xxx x xxxx xx xxx Xxxxxxx YY xxxxx. X Xxxxxxxxx Y.Y xxx xxxxxxx xx Xxxxxxx YY xxx xxx xxx xxxxxxxxxxx XX xxxxxxxx xx xxxxxx-xxxxxxxx xxxxxx xx xxx xxx'x xxxxx xxx.

## Xxxxxxxx, xxx xxxxxxx xxxxxx/xxxxxxxxx

X Xxxxxxxxx Y.Y xxx xxxxxxx xx Xxxxxxx YY xxxx xxxxxx xxx Y.Y xxxxxxxxxx xxx xxxxxxxx xxxx xxxxxxx xx xxxxxxxx. Xxx, xxxx xxx xxxx xxxx xxx xx x Xxxxxxx YY xxx, xxxxx xxx xxxx xxxxxxxxxxx xx xxxxxxxxxx xxx xxxxxxxx xx xx xxxxx xx. Xxx xxxxxxxxxxxx xxx xxxxxx xx xxxxxxxx xx xxxxxxxxxxx xxxxxxxxx xxx Xxxxxxx YY xxxx, xx xxx xxxxxxx xxx xxxxxx xxxxxx [xxxxxx xxxxxxxx](#design-language), xxxxxxxxxxxxxx, xxx xxxxxxxxx xxxxxxxxxxxx.

**Xxxx**   Xxx XxxxxxxXxxx xxxxxx xxxxx xx xxxxxxxx xx xxxxxx xxxxxx/xxxxxxxxx xx Xxxxxxx YY xxxx xxx xx Xxxxxxx Xxxxx xxxx, xxx xxx xx Xxxxxxx Xxxxx Xxxxx xxxx. Xxx xxxx xxxxxx (xxx xxxxxxx xx xxx xxxxxx xxxxxxxx xxxx xxxx xxx xxxxxxxxx xxx Xxxxxxx YY xxxx), xx xxxxxxxxx xxxx xxx xx-xxx xxx xxxxxx xxxxxx/xxxxxxxxx xxxx xxxx Xxxxxxx Xxxxx xxxx xxxx xxx'xx xxxxxxx xxxx xxx xx Xxxxxxx YY.
Xx xxx xxxx xx xx xxxxxxx xxxx xxxx xxxxxx xxxxxx/xxxxxxxxx xxx xxxxx xxx xxxxxx xxx xx xxxxxx xxxxxx, xxx xxx xxxxxxxxxxx xxxx xxxxxxxxxxx xxxxxxxxxxxx xxxx xx xxx xxxxxxx xxxxxx/xxxxxxxxx, xxxx xxxx x xxxx xx xxx xxx Xxxxxxx YY xxxxxxx xxxxxxxx xxx xx-xxxxx xxxx xxxxxxxxxxxxx xx xxxx. Xxx xxxxxxx xx x xxxxxxxxxxx xxxxxxxxxxx xx xxxx xxx **Xxxxxx** xxxx xxxxxxxx xxxxxxxx x **XxxxxxxXxxxxxxxx** xx x Xxxxx xxx xxxx xxxxxxx xxx x xxxxx xxxxxxx xxx xxxxxxx xxx xxxxxx.

Xxxx xxx xxxx xxxx xxxxxxxx xxxxxxxx xx xxxxxxx xx xxxxxxxx.

| Xxxxxxx xxxx | Xxxxxx |
|--------------|--------|
| **XxxXxx**   | Xx xxx xxx xxxxx xxx **XxxXxx** xxxxxxx ([**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) xx xxxxxxxxxxx xxxxxxx), xxxx xx xx xxx xxxxxx xx xxxxxxx xx x Xxxxxxx YY xxx. Xxx xxx xxxxxxx xxxx xxxx xxx [**XxxXxx.XxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn633872) xxxxxxxx. |
| **XxxXxx**, [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) | Xx x Xxxxxxx YY xxx, **XxxXxx** xxx [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) xxxx x **Xxx xxxx** xxxxxx (xxx xxxxxxxx). |
| [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) | Xx x Xxxxxxx Xxxxx xxx, xxx xxxxxxxxx xxxxxxxx xx x [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) xxx xxxxxx xxxxxxx. Xx x Xxxxxxx Xxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xxx xxx'x xxxxxx xxxxx xxx xxxxxxx xxx xxxxx. |
| [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) | Xxx x Xxxxxxx Xxxxx Xxxxx xxx, xxx xxxxx xx [**XxxxxxxXxx.XxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701944) xxxx xxx xxxxxx xxxxxxx xx xxx xxx xxx xx xxxxx-xxxxxxxxxxx. Xxx x Xxxxxxx YY xxx, xx **XxXxxxxx** xx xxx xx xxxx, xxxx xxx **XxxxxxxXxx** xxxxxxxxxx x xxxxx xxxxxxx xxxxxxx. |
| [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) | Xx x Xxxxxxx YY xxx, [**XxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/hh701927) xxxx xxx xxxxxx xxx [**XxxxXxxxxxx.Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701622) xxx [**XXXxxxxxx.XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208984) xxxxxx. Xxx xxxx xx xxxxxxx xx x xxx xxx x xxxxx xx. Xxx xxxxx xxxx xxx xxxxxx xx xxxxxx xxxxx xxxxxx xxx xxx [**XxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh701939). |
| [
            **XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298584), [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn299280) | Xxxxxx xxx xxxx xxx xxxxx xxxx xxx xxxxxx xxxxxxx xx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298584) xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn299280). Xxx x Xxxxxxx YY xxx xxxxxxx xx x xxxxxx xxxxxx, xxxxx xxxxxxxx xx xxxxxx xxxxxxxx xx x xxxxxxxxx xxxx xxx xxxxxxx xxx x xxxxx-xxxxxxxxxxx xxxxx. |
| [
            **XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298584), [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn299280) | Xx x Xxxxxxx YY xxx, xxx xxx'x xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298584) xx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn299280) xxxxxx x xxx-xxx. Xx xxx xxxx xxxxx xxxxxxxx xx xx xxxxxxxxx xx x xxxxx-xxxx xxxxxxx, xxxx xxx xxx xxx [**XxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn625013) xxx [**XxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn608313). |
| **XxxxXxxx**, **XxxxXxxx** | Xxx **XxxxXxxx**/**XxxxXxxx**, xxx [XxxxXxxx/XxxxXxxx xxxxxxx](#gridview). |
| [**Xxx**](https://msdn.microsoft.com/library/windows/apps/dn251843) | Xx x Xxxxxxx Xxxxx Xxxxx xxx, x [**Xxx**](https://msdn.microsoft.com/library/windows/apps/dn251843) xxxxxxx xxxxx xxxxxx xxxx xxx xxxx xxxxxxx xx xxx xxxxx. Xx x Xxxxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xxx xxxxxxxx xx xxx xxxx xxxxxx. |
| [**Xxx**](https://msdn.microsoft.com/library/windows/apps/dn251843) | Xx x Xxxxxxx Xxxxx Xxxxx xxx, x [**Xxx**](https://msdn.microsoft.com/library/windows/apps/dn251843) xxxxxxx'x xxxxxxxxxx xxxxx xxxxx xx xxxxxxxx xxxxxxxx xx xxx xxx xxxxxxxx. Xx x Xxxxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xxxxxxxx xx xxx xxxx. |
| [**Xxx**](https://msdn.microsoft.com/library/windows/apps/dn251843)  | Xx x Xxxxxxxxx Y.Y xxx, xxx [**XxxXxxxxxx.XxXxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251917) xxxxxxxx xxxxxx xxx xxxxxxx xxxxxx—xxx x xxxxxxx xxxxx xxxxxxxx xxxx xx xx—xx xxxxxx xxxxxxxxxxx. Xx x Xxxxxxx YY xxx, xxxxx xx xx xxxxxxxxxxx "Xxx xxxx" xxxxxxxxxx xxxxxx xxx xxxxxx, xxx xxx xxxxxx xxxxxx xx xxx xxxxxxxxxxx. **XxXxxxxxXxxxxxxxxxx** xxxxx xxxxxxxxxx xxxxxxx xxxxxxxxxxx xxxxxx xxx [**Xxx.XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn251953) xxxxx. |
| **XxxxxxxXxxxxx** | Xx xxx'xx xxxxx **XxxxxxxXxxxxx**, xxxx xxxxxxxx xxxxxxx xxxxx xxx xxxx xxxxxxxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn633972). Xxxx, xxx xxx [XXXX XX Xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619992) xxxxxx. |
| **XxxxXxxxxxXxxxxx**, **XxxxxxXxxxxx**  | **XxxxXxxxxxXxxxxx** xxx **XxxxxxXxxxxx** xxx xxxxxxxxxx xxx x Xxxxxxx YY xxx. Xxx x xxxxxx xxxxxxxxx xxx-xxx, xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn299030); xxx xxxx xxxxxxx xxxxxxxxxxx, xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279496). |
| [**XxxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br227519) | Xxx [**XxxxxxxxXxx.XxXxxxxxxxXxxxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh702579) xxxxxxxx xx xxxxxxxxxx xx x Xxxxxxx YY xxx, xxx xxxxxxx xx xxx xx xxxxxx. Xxx [**XxxxxxxxXxx.XxxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn890867) xxxxxxx, xxxxx xxxxxxxx xx **Xxxx** (xx xxxxx xx xxx xxxxx xx xxxxxxxxx, xxxx xx x Xxxxxxx Xxxxx xxx). Xxxx, xxx [Xxxxxxxxxx xxx xxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/dn596103). |
| [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn608241) | Xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn608241) xxxxxxx xx xxx xxxxxxxxx, xx xx xx xxxxxx xxxxxxx xx xxx xx xxxxxx xxxxxxx. |
| [**XxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn252771) | Xxxxxxxx [**XxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn252803) xx xxxxxxxxxxx xx xxx Xxxxxxxxx xxxxxx xxxxxx, xx xx xxx xxxxx xxxxxxxxxx xx xxxxxx xxxxxxx. Xxx [XxxxxxXxx xxxxxxxxxx xx xxxxx xx XxxxXxxxxxxXxx](#searchbox). |
| **XxxxxxxxXxxx** | Xxx **XxxxxxxxXxxx**, xxx [XxxxxxxxXxxx xxxxxxx](#semantic-zoom). |
| [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209527)  | Xxxx xxxxxxx xxxxxxxxxx xx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209527) xxxx xxxxxxx. [
            **XxxxxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209549) xx **Xxxx**, [**XxxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209589) xx **Xxxx**, xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209601) xx **Xxxxxxxx**. Xx xxx xxx xxxxxxx xxxxxx xxx xxx xxxxxxxxxxx xxx xxxx xxx, xxxx xxx xxx xxxxxx xxxx xxxxxx xx x xxxxx xx xx xxxxx xxxxxx xx xxx xxxxxxx xxxxxx.  |
| [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) | Xx x Xxxxxxx Xxxxx xxx, xxxxx-xxxxxxxx xx xxx xx xxxxxxx xxx x [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683). Xx x Xxxxxxx Xxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xx xx xx xx xxxxxxx. |
| [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) | Xxx xxxxxxx xxxx xxxx xxx x [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) xxx xxxxxxx xxxx YY xx YY. |
| [**XxxxXxx**](https://msdn.microsoft.com/library/windows/apps/br209683) | Xxx xxxxxxx xxxxx xx [**XxxxXxx.XxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn252859) xxx xxxxxxx xxxx **Xxxxxxx** xx **XxxxxxXxxxXxxxxxx**. Xx xxxx'x xxxxxxxxxxx, xxxx xxx **XxxXxxxXxxxxxxxx**. **Xxxxxxx** xx xxxxxxxxxx. |
| Xxxxxxx | Xxxxxx xxxxx xxxxxxx xx x Xxxxxxx Xxxxx Xxxxx xxxx, xxx xx Xxxxxxx YY xxxx, xxx xxx xx Xxxxxxx Xxxxx xxxx.  |

Xxx xxxx xxxx xx XXX xxx xxxxxxxx, xxx [Xxxxxxxx xx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185405), [Xxxxxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/mt185406), xxx [Xxxxxxxxxx xxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn611856).

##  Xxxxxx xxxxxxxx xx Xxxxxxx YY

Xxxxx xxx xxxx xxxxx xxx xxxxxxxxx xxxxxxxxxxx xx xxxxxx xxxxxxxx xxxxxxx Xxxxxxxxx Y.Y xxxx xxx Xxxxxxx YY xxxx. Xxx xxx xxx xxxxxxx, xxx [Xxxxxx](http://dev.windows.com/design). Xxxxxxx xxx xxxxxx xxxxxxxx xxxxxxx, xxx xxxxxx xxxxxxxxxx xxxxxx xxxxxxxxxx: xx xxxxxxxxx xx xxxxxx xxx xxxxxx xxxxxx xxx xxxxxxxxxx xxxxxxx xxxxxxxx xx xxxxxxx xxx xxxxxx, xxxxxxxx xxxxxxxx xxxxxx xxxxxxxx, xxx xxxxxxxxx xxxxxxxxx xx xxx xxxxxxx xxxxxx; xxx xxxxxx xxxxxxxxx xxxxxxxxxx xxxx xxxxxxxxxx; xxxxxx xx x xxxx; xxx xxxxx xxxx xxxxxxxxxxx xx xxxx xxxx xxxxx xxxxxxxxxx.

## Xxxxxxxxx xxxxxx, xxxxxxx xxxxxxxx, xxx xxxxx xxxxxxx

Xxxxxxxxxx, xxxx xxxxxx xxxx xxx xxx xx xxxxxxxx xxx xxxx xxx xxxxxx xx XX xxxxxxxx xxxx xxxx xxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxxxx xx xxxxxxx. Xxxx xxxxxx xxxx xxx xxxxxxx xxxx xxxxxxxxx xxxxxx, xxx xxxx'x xx xxxxxxxxxxx xx xxxx xxxx, xxxx xx xxxxx, xxx xxx xxxxx xxxxx xx xxxxxx.

Xxx xxxx "xxxxxxxxxx" xxxxxx xx x xxxxxxx xx xxxxx xxxxxxx xxx xxx, xx xx xxxxxxxx xxxxxxx, xxxxx xxxxx. "Xxxxxxxxx xxxxxxxxxx" xx xxx xxx xxx xxxxxxxx xxxxxx xxxx xxxxxxx xx xxxxx xx xxxxx xxxxxxx xx xxx xxx xxxxx xxxxxxxxxxx xx xxxxxxx xxxxxxxx xxx xxx xxxxxxxx xxxxx xxxx xx xxx xxxxxx (xxxxx xxxxxxx xxxxx xxx xxxxxxxxxx xx xxxxxxxx xxxxx xxxx). Xxxxxxxxx xxxxxxxxxx xx x xxxx xxxxxx xx xxxxx xx xxxxxxxxxx xxxxxx xxxxxxx xx xx xxxx-xxxxxxx. Xx xxxxxxxxxxxxx xxx xxx xxxxxxx, xxx xxxxxxxxxxx xxx xxxx xx XX xxxxxxxx, xxx xxx xxxx xxx xxxx'x xxxxxxxxxx x xxxx xxx.

Xxxxxxxxx xxxxxxx xxx x xxxxxxxxx xxxxxx xx xxxxxxxxx xxxxxx xxxx, xxxxxxx xxxx YYY xxx xxx xxx xxxxxxxx xxxxxxx, xx YYYY xxx xxx x xxxxxx-xxxxx xxxxxxx, xxx xxx xxxxxx xx xxxx xxxxxx xxxxxx. Xxx xxx xxxx xx xx xx xxxxxxxx xx xxx xxxx-xxxxx xxxxxxxx xxx xxxxxxx xxxxxx xxxxxx xx xxx xxxxxx xxxx. Xxxxx xxxx xxxx xx xxxx xxxxx xxxxx xxx'xx xxx xxx xxxxxxxxxx xx xxxx XX xxxxxxxx xx x xxxxx xxxx xx XXXX xxxxxx. X xxxxx xxxxxx xx xxxxxxxxxxxxx xxxxxxx xx xxxx xxx xxxxxxxxx xx xxxx xxxxxx xx xxxx xx xxx xxx xxxxxxx xxxxxxxx xxxx xx xxx xxxx. Xxx xxxx xxxxx xxxxxx xxxxxx xx xxxx xxx XX xxxxxxx xxxx x xxxxx xxxx xxxxxxxxxx x xxxx-xx-xxxx xxxxxxxx-xxxxx xxxxx (xxx xxxxxxx) xxxxxx xx xxx xxxx xxxxxx x xxxx xxxxxxx xx xxxxxx xxxxx. Xxx xxxxxxxx xxxx xxxxxxx xxxxxx, xxxx XX xxx'x xxxxxx xxxxxxxxx xxxxx xx xxxxxxxxx xxxxxxx. Xx xxxx xxxxxxx xx xxxx'x xxxxxxxxx xx xxx xxx xxxxxxxxxxx xxxxxx xx xxxxxxx xxxx xxx xxxxxxxxx xxxxx.

Xx xxxx xxxx xxx xxx xxx xxxx xxxxxxxxxx xxxxxx xxx xxxxxxxx, xx xxxxxxxxx xxxx xxx xxxxxx xxxx xxxxxx xxxxx xx x xxxxx xx xxxxx, xxxx xxxxxxxx xxx x xxxxxxxxxx xxxxx xxxxxx. Xxxxxxxxx xxxxxx xx YYY%-xxxxx, YYY%-xxxxx, xxx YYY%-xxxxx (xx xxxx xxxxxxxx xxxxx) xxxx xxxx xxx xxxxxxxxx xxxxxxx xx xxxx xxxxx xx xxx xxx xxxxxxxxxxxx xxxxx xxxxxxx.

**Xxxx**  Xx, xxx xxxxxxxx xxxxxx, xxx xxxxxx xxxxxx xxxxxx xx xxxx xxxx xxx xxxx, xxxx xxxxxx YYY%-xxxxx xxxxxx. Xx Xxxxxxxxx Xxxxxx Xxxxxx, xxx xxxxxxx xxxxxxx xxxxxxxx xxx XXX xxxx xxxxxxxx xxxxxxxx xxxxxx (xxxx xxxxxx xxx xxxxx) xx xxxx xxx xxxx, xxx xxxx xxx xxx YYY%-xxxxx. Xxxx xxxxxxxxx xxxxxx xxx xxxx xxx xxx, xxxxxx xxx xxxxxxxx xx xxxx xxxxxxx xxx xxxxxxx YYY%, YYY%, xxx YYY% xxxxx, xxx xxx xxxxx xxxxx.

Xx xxx xxxx xxxxxxxxx xxxxxxx, xxxx xxx xxx xxxx xx xxxxxxx xxxx xxxxxx xx xxxx xxxx xxxxx. Xx xxx'xx xxxxxxxx xxxx xxxxxx xxx, xxxx xx'x xxxxxxxxxx xxxx xx xxxxxxxx xxxx-xxxxxxx xxxxxx xx xxx xxxxx xxxxxx.

Xx xxx'x xxxxxxxxx xxxx xxx xxx xx xxxxxxx xxx xx xxx xxxxx xxxxxxx, xxx xxx xxxx xxxx xx xxxxx xxxxxxx xxx Xxxxxxx YY xxxx xx YYY%, YYY%, YYY%, YYY%, YYY%, YYY%, xxx YYY%. Xx xxx xxxxxxx xxxx, xxx Xxxxx xxxx xxxx xxx xxxxxxx-xxxxx xxxxx(x) xxx xxxx xxxxxx, xxx xxxx xxxxx xxxxxx xxxx xx xxxxxxxxxx. Xxx Xxxxx xxxxxxx xxx xxxxxx xx xxxxxxxx xxxxx xx xxx XXX xx xxx xxxxxx. Xxx xxx xx-xxx xxxxxx xxxx xxxx Xxxxxxx Xxxxx xxx xx xxxxx xxxxxxx xxxx xx YYY% xxx YYY%, xxx xxxx xxx xxxx xxx xx xxx xx xxx xxx xxxxx xxxxxxx xxx xx xxxx xxxxxx xxxxxxx xxxx xx xxxxxxxxxxx. Xxxx xxxx xxx xx x xxxxx xx xxxxxxx xx xxx xxxxxxx xxx'xx xxxxx xxxx xxx xxxxxxx xx xxxx xxxx.

Xxx xxx xx xx-xxxxx XXXX xxxxxx xxxx x Xxxxxxx Xxxxx xxx xxxxx xxxxxxx xxxxxxxxx xxxxxx xxx xxxx xx xxx xxxxxx (xxxxxxx xx xxxx xxxxxx xx xxxxx xxxxxxxx, xxxxxxx xxx xxxxxxxxxx). Xxx, xx xxxx xxxxx, x xxxxxx xxxxx xxxxxx xx xxxx xx x xxxxxx xxx x Xxxxxxx YY xxx xxxx xxx x Xxxxxxxxx Y.Y xxx (xxx xxxxxxx, YYY% xx xxxx xxxxx YYY% xxx xxxxxx, xxx YYY% xx xxxx xxxxx YYY% xxx). Xx, xx xxx xxxx xxxx xxxxx xxxxxxx xxxxxx xxx xxx xxx xxx xx Xxxxxxx YY, xxxx xxx xxxxxxxxxxx xxxx xx Y.Y. Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxxxxx YYY xxx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/dn958435).

## XxxxXxxx/XxxxXxxx xxxxxxx

Xxxxxxx xxxxxxx xxxx xxxx xxxx xx xxx xxxxxxx xxxxx xxxxxxx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242705) xx xxxx xxx xxxxxxx xxxxxx xxxxxxxxxx (xxxxxxx xx xxxxxxxxxxxx, xx xx xxx xxxxxxxxxx xx xxxxxxx). Xx xxx xxxxxx x xxxx xx xxx xxxxxxx xxxxx xx xxxx xxxxxxx, xxxx xxxx xxxx xxx'x xxxx xxxxx xxxxxxx, xx xxx'xx xxxx xx xxxx xxxx xxxxxxxx. Xxxx xx x xxxx xx xxx xxxxxxx.

-   Xxx xxxxxx xxx [**XxxxxxXxxxxx.XxxxxxxxxxXxxxxxXxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209547) xxx xxxxxxx xxxx **Xxxx** xx **Xxxxxxxx**.
-   Xxx xxxxxx xxx [**XxxxxxXxxxxx.XxxxxxxxXxxxxxXxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209587) xxx xxxxxxx xxxx **Xxxxxxxx** xx **Xxxx**.
-   Xxx xxxxxx xxx [**XxxxxxXxxxxx.XxxxxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209549) xxx xxxxxxx xxxx **Xxxxxxx** xx **Xxxxxxxx**.
-   Xxx xxxxxx xxx [**XxxxxxXxxxxx.XxxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br209589) xxx xxxxxxx xxxx **Xxxxxxxx** xx **Xxxxxxx**.
-   Xx xxx xxxxxx xxx [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br242826), xxx xxxxx xx [**XxxxxXxxxXxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298907) xxx xxxxxxx xxxx **Xxxxxxxx** xx **Xxxxxxxxxx**.

Xx xxxx xxxx xxxxxx (xxx xxxxxx xx **Xxxxxxxxxxx**) xxxxx xxxxxxxxxxxxx, xxxx xxxxxxxx xxxx xx'xx xxxxxxx xxxxx x xxxx xxxx. X xxxxxxxxxxxx-xxxxxxxx xxxx xxxx (xxx xxx xxxxx) xx xxxxxxx xx x xxxxxxx xxxxxx xxxxx xxxx xxxxx xxxxxxxxxxxx xxx xxxxxx xx xxx xxxx xxxx xxxx xx xxx xxx xx x xxxx. X xxxx xx xxxx xxxx xxxx xxxxxxx xxxxxxxxxx. Xxxxxxxxxx, x xxxxxxxxxx-xxxxxxxx xxxx xxxx (xxx xxxxxxxx xxxxx) xx xxxxxxx xx x xxxxxxx xxxxxx xxxxx xxxx xxxxx xxxxxxxxxx xxx xxxxxxxxx xxxxxxx xxxxxxxxxxxx.

Xxxx xxx xxx xxxxxxx xx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242705) xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242878) xxxx xxxx xxxxxx xx xxx xxx xxxxxxxxx xx Xxxxxxx YY.

-   Xxx [**XxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh702518) xxxxxxxx (Xxxxxxx Xxxxx xxxx xxxx) xx xxx xxxxxxxxx xxx Xxxxxxx YY xxxx. Xxx XXX xx xxxxx xxxxxxx, xxx xxxxxxx xx xxx xx xxxxxx. Xxx xxxxxxxx xxxxxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxx xxxxxxxx xxxxx (xxxxx xx xxxxxxxxxxx xxxxxxx xxxx xxxxx xxxx xx xx xxx xxxxxxxxxxxx) xxx xxxxx-xxxxx (xxxxx xx xxxxxxxx xxx xxxxxxx x xxxxxxx xxxx).
-   Xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn625099) xxxxxxxx (Xxxxxxx Xxxxx Xxxxx xxxx xxxx) xx xxx xxxxxxxxx xxx Xxxxxxx YY xxxx. Xxx XXX xx xxxxx xxxxxxx, xxx xxxxxxx xx xxx xx xxxxxx. Xxxxxxx, xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br208912) xxx [**XxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br242882) xx xxxx xx xxxx **XxxxXxxx** xx **XxxxXxxx** xxx xxxx xxx xxxx xxxx xx xxxx xx xxxxxxx xxxxx x xxxxx-xxx-xxxx (xx xxxxx-xxx-xxxx) xxxxxxx.
-   Xxxx xxxxxxxxxx xxx Xxxxxxx YY, xxx [**XxxxXxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298500) xxxxxxx xx [**XxxxXxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279298) xx xxxx xxxx xxxxxxxxx xxxxx, xxxx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242878) xxx xxx [**XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242705). Xx xxx xxxx x xxxx xx xxx xxxxxxx xxxx xxxxxxxxx xxxxxx, xxxx xxx xxxx xxx xxx xxxxxxx xxxx.
-   Xxx xxxxxxxxx xxxxxxx xxxx xxxxxxx xxx x Xxxxxxx YY xxx. Xx xxx xxx [**XxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242915) xx **Xxxxxxxx**, xxxx xx xxxxxxx, x xxxxx xxx xx xxxxxxxx xxx xxxx xxxx. Xxx xxxxxxx xxxxxxx xxx **XxxxXxxx** xxxxx xxxxx xxxx xxx xxxxx xxx xx xxxx xxx xxxxxx xxxxxx xxx xxxx, xxx xx x xxxxxx, xxx xxxxx xxxxxxxx xx xxx xxxx xx xxx xxxx xxxx xx xxxxxxxx xxxxxxx xxx xxxxxxx. Xxx **XxxxXxxx** xxxxx, xxx xxxxx xxx xx xxxxxxxx xx xxx xx xxx xxxx xx xxxxxxx. Xxx, xx xxxxxx xxxx, xxx xxx xxxxxxx xxx xxxxxx (Xxxxxx xx Xxxxxxx) xx xxx xxxxx xxxxx (xxxx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn913923) xxxxxxxx) xxx xxxxxxx xxxx xxx xxxxx xx xxx (xxxx xxx [**XxxxxxxxxXxxxxXxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298541) xxxxxxxx) xx xxx [**XxxxXxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.aspx) xxxxxxx xxxxxx xxxx xxxx xxxxxxxxx xxxxx xx xx xxx xxxxxxx xxxxx.
-   Xx Xxxxxxx YY, xxx [**XxxxxxxxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298914) xxxxx xx xxxxxx xxxxx xxx xxxx xxxxxx XX xxxxxxxxxxxxxx: xxxx xxx xxx xxxxxxx, xxx xxxx xxx xxx xx-xxx. Xx xxx xxxxx xx [**XxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn279443) xx **xxxx** xxx xxx xxxx xx xxxxxxx xxxxxxx xxxx xx xx, xxxx xxx xxx xxxx xxxx xxxxx xxxxxxx xxxxxxxxxxx xxxx xxx xxxxxxxxx xxxx xx xxxx xx xx-xxxxxxx xxxx xxxx xxxx xxxx xx xx-xxxx (xx xxxxx xxxx **XxXxxxxxxXxxxx** xxxx xx **xxxxx**).

```xaml
<Style x:Key="CustomItemContainerStyle" TargetType="ListViewItem|GridViewItem">
    ...
    <Setter.Value>
        <ControlTemplate TargetType="ListViewItem|GridViewItem">
            <ListViewItemPresenter CheckMode="Inline|Overlay" ... />
        </ControlTemplate>
    </Setter.Value>
    ...
</Style>
```

![x xxxxxxxxxxxxxxxxxxxxx xxxx xxxxxx xxxxx xxx](images/w8x-to-uwp-case-studies/ui-listviewbase-cb-inline.jpg)

X XxxxXxxxXxxxXxxxxxxxx xxxx xxxxxx xxxxx xxx

![x xxxxxxxxxxxxxxxxxxxxx xxxx xxxxxxxx xxxxx xxx](images/w8x-to-uwp-case-studies/ui-listviewbase-cb-overlay.jpg)

X XxxxXxxxXxxxXxxxxxxxx xxxx xx xxxxxxxx xxxxx xxx

-   Xxxx xxx xxxxxxx xx xxxxxxxx xxxxx xxx xxxxx-xxxxx xxxxxxxx xxx xxxxxxxxx (xxx xxx xxxxxxx xxxxx xxxxx), xxx xxxxxxxxxxx xxxxx xxx xxxxxxx, xxx xxxxxxxxxxx xx xxxxx xx xxxx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br242904) xxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209776) xxxxxx xxx xx xxxxxx xxxxxxxx xxxxxxxxx. Xxx xxxx Xxxxxxx YY xxx, xxxxxx xxxx xxxxxxxxx xxx xxxxxx xxxxxxx xx xxxxx xxx "xxxxxxxxx" xx xxx "xxxxxx" xxxxxxxxxxx xxxxx. Xxx xxxxxxx, xxx [Xxx xx xxxxxx xxx xxxxxxxxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/xaml/hh780625).
-   Xxxxx xxx xxxx xxxxxxx xx xxx xxxxxxxxxx xxxx xxx xxx xx xxxxx [**XxxxXxxxXxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.listviewitempresenter.aspx). Xxxxxxxxxx xxxx xxx xxx xxx [**XxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913905), [**XxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913931), [**XxxxxxxxXxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn913937), xxx [**XxxxxXxxxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn898370). Xxxxxxxxxx xxxx xxx xxxxxxx xxx x Xxxxxxx YY xxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn424775) (xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn424773) xxxxxxx), [**XxxxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298504), [**XxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298506), [**XxxxxxxXxxxXxxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn424778), [**XxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298528), [**XxxxxxxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298533), xxx [**XxxxxxxxXxxxxxxXxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn298539).

Xxxx xxxxx xxxxxxxxx xxx xxxxxxx xx xxx xxxxxx xxxxxx xxx xxxxxx xxxxx xxxxxx xx xxx [**XxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242919) xxx [**XxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh738501) xxxxxxx xxxxxxxxx.

| Y.Y                 |                         | Xxxxxxx YY        |                     |
|---------------------|-------------------------|-------------------|---------------------|
| XxxxxxXxxxxx        |                         | XxxxxxXxxxxx      |                     |
|                     | Xxxxxx                  |                   | Xxxxxx              |
|                     | XxxxxxxXxxx             |                   | XxxxxxxXxxx         |
|                     | Xxxxxxx                 |                   | Xxxxxxx             |
|                     | XxxxxxxXxxxXxxxxxx      |                   | [xxxxxxxxxxx]       |
|                     | Xxxxxxxx                |                   | [xxxxxxxxxxx]       |
|                     | [xxxxxxxxxxx]           |                   | XxxxxxxXxxxXxxxxxxx |
|                     | [xxxxxxxxxxx]           |                   | Xxxxxxxx            |
|                     | [xxxxxxxxxxx]           |                   | XxxxxxxXxxxxxxx     |
| [xxxxxxxxxxx]       |                         | XxxxxxxxXxxxxx    |                     |
|                     | [xxxxxxxxxxx]           |                   | Xxxxxxxx            |
|                     | [xxxxxxxxxxx]           |                   | Xxxxxxx             |
| XxxxxxxxxXxxxXxxxxx |                         | [xxxxxxxxxxx]     |                     |
|                     | XxxxxxxxXxxxxxxxxXxxx   |                   | [xxxxxxxxxxx]       |
|                     | XxxxxxxxxxXxxxxxxxxXxxx |                   | [xxxxxxxxxxx]       |
|                     | XxXxxxxxxxxXxxx         |                   | [xxxxxxxxxxx]       |
| [xxxxxxxxxxx]       |                         | XxxxxXxxxxxXxxxxx |                     |
|                     | [xxxxxxxxxxx]           |                   | XxxxxXxxxxxXxxxxxxx |
|                     | [xxxxxxxxxxx]           |                   | XxxxxXxxxxxXxxxxxx  |
| XxxxxxxxxXxxxxx     |                         | [xxxxxxxxxxx]     |                     |
|                     | Xxxxxxxxxxx             |                   | [xxxxxxxxxxx]       |
|                     | Xxxxxxxxxx              |                   | [xxxxxxxxxxx]       |
|                     | XxxxxxxxxxXxxxxxxXxxx   |                   | [xxxxxxxxxxx]       |
|                     | XxxxxxxxxxXxxxxxx       |                   | [xxxxxxxxxxx]       |
|                     | Xxxxxxxxx               |                   | [xxxxxxxxxxx]       |
|                     | Xxxxxxxx                |                   | [xxxxxxxxxxx]       |
|                     | XxxxxxxxXxxxxxx         |                   | [xxxxxxxxxxx]       |
|                     | XxxxxxxxXxxxxxxxx       |                   | [xxxxxxxxxxx]       |

Xx xxx xxxx x xxxxxx [**XxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br242919) xx [**XxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh738501) xxxxxxx xxxxxxxx, xxxx xxxxxx xx xx xxxxx xx xxx xxxxx xxxxxxx. Xx xxxxxxxxx xxxx xxx xxxxx xxxx xx xxxxxxx x xxxx xx xxx xxx xxxxxxx xxxxxxxx xxx xx-xxxxxxxx xxxx xxxxxxxxxxxxx xx xxxx. Xx, xxx xxxxxxxx xxxxxx, xxx xxx'x xx xxxx xxx xxx xxxx xx xxxx xxxx xxxxxxxx xxxxxxxx, xxxx xxxx xx xxxx xxxxxxx xxxxxxxx xxxxxx xxx xxx xxxxx xx xxxxx xxxxx xxxx.

-   Xxx xxx xxx XxxxxXxxxxxXxxxxx xxxxxx xxxxx xxxxx.
-   Xxx xxx xxx XxxxxXxxxxxXxxxxxxx xxxxxx xxxxx.
-   Xxx xxx xxx XxxxxXxxxxxXxxxxxx xxxxxx xxxxx.
-   Xxx xxx xxx XxxxxxxxXxxxxx xxxxxx xxxxx xxxxx.
-   Xxx xxx xxx Xxxxxxx xxxxxx xxxxx.
-   Xx xxx XxxxxxXxxxxx xxxxxx xxxxx xxxxx, xxxxxx xxx XxxxxxxXxxxXxxxxxx xxxxxx xxxxx.
-   Xxxx xxx Xxxxxxxx xxxxxx xxxxx xx xxx XxxxxxxxXxxxxx xxxxxx xxxxx xxxxx.
-   Xxx xxx xxx XxxxxxxXxxxXxxxxxxx xxxxxx xxxxx.
-   Xxx xxx xxx XxxxxxxXxxxxxxx xxxxxx xxxxx.
-   Xxxxxx xxx XxxxxxxxXxxxXxxxxx xxxxxx xxxxx xxxxx.
-   Xx xxx XxxxxxxxxXxxxxx xxxxxx xxxxx xxxxx, xxxx xxx Xxxxxxxx xxxxxx xxxxx xx xxx XxxxxxXxxxxx xxxxxx xxxxx xxxxx.
-   Xxxxxx xxx xxxxxx XxxxxxxxxXxxxxx xxxxxx xxxxx xxxxx.

## Xxxxxxxxxxxx xxx xxxxxxxxxxxxx

Xxx xxx xx-xxx xxx Xxxxxxxxx.xxxx xxxxx xxxx xxxx Xxxxxxxxx Y.Y xxxxxxx xx xxxx XXX xxx xxxxxxx. Xxxxx xxxxxxx xxx xxxx xxxx, xxx xx xx xxx xxxxxxx xxx xxx **Xxxxx Xxxxxx** xx **XXXXxxxxxxx** xxx **Xxxx xx Xxxxxx Xxxxxxxxx** xx **Xx xxx xxxx**. Xxx [**XxxxxxxxXxxxxxx.XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206071) xxxxx xxxxxxxxx xxx xx xxxx xxxxxx xxxxxx-xxxxxxxx xxxxxxxxx xxxxx xx xxx xxxxxx xxxxxx xxxxxxxx xxxxxxxxx xxxxxx.

## Xxxx Xx

Xxx XXXx xx xxx [**Xxxxxxx.Xxxxx.XxxxXx**](https://msdn.microsoft.com/library/windows/apps/br207025) xxxxxxxxx xxx xxxxxxxxxx xxx Xxxxxxx YY xxxx xx xxxxx xx xxx [**Xxxxxxx.Xxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn972568) XXXx.

## Xxxxxxxx xxxx, xxx XxxxXxxxx xxxxx xxxxx

Xxx xxxxxx xxxxxxxx xxx xxxxxxx xxx Xxxxxxx YY xxx xxxxxxxxxxxx xxxxxxx xxxxxx xxxxxx xxxx xxxxxxx. Xx xxxx xxxxx, xxx xxxx xxxx xx xxxxxxx xxx xxxxxx xxxxxxx xx xxxx xxxxx xx xxxx xxxx xxx xx xxxxxxx xxxx xxx xxxxx xxxxxxxxxx xxxx xxxx xxxxxxx.

Xx xxxxx xxxxx, xxxxxxxx xxxx xxx xx xxxxxx xxxxxxxxx. Xxx XXXX xxxxxx xxxxxx xx Xxxxxx Xxxxxx xxxxxxxxxx xxxxxxxxxx xx xxxxxxxx xxxx xxxx xxx'x xx xxxxxxxx. Xxx xxxxxxx, xxx XXXX xxxxxx xxxxxx xxxx xxxxxxxxx x xxxxxxxxx xx xxx xxxxx xxx `ListViewItemTextBlockStyle` xxxx x xxx xxxxxxxx. Xx xxxx xxx'x xxxxxxxxx, xxxx xxx xxx xxxx xxxxxxxxxxx xxxxxxxxx xxxx xxx xxx xx xxxxxx xx xx xxx xxxxxxxx xx xxxxxx. Xx, xx'x xxxxxxxxx xx xxxxxx xx XXXX xxxxxx xxxxxxxxxxx. Xxx xxx xxxx xxxx Xxxxxx Xxxxxx xx xx x xxxxx xxxx xxx xxxxxxxx xxxx xxxxxx.

Xxx xxxx xxxx xxx xxxxx xxxxxxxxx, xxxxxxx xx xxxxxx xxxxxxxx xxxx xxxx xxxxxxxxxx xxx xx xxxx xxxxxx xxxx xxxxxxx. Xxx xxxxxxx, `TitleTextBlockStyle` xxxx **XxxxXxxx** xx YY.YYYxx xx x Xxxxxxx Xxxxx xxx xxx YY.YYxx xx x Xxxxxxx Xxxxx Xxxxx xxx. Xxx, xxx xxxx xxxxx xxxx **XxxxXxxx** xx x xxxx xxxxxx YYxx xx x Xxxxxxx YY xxx. Xxxxxx xxxx xxxxxxx xxx xxxxxxx xxx xxx xxx xxxxxxxxxxx xxxxxx xx xxx xxxxx xxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxx xxxxx](https://msdn.microsoft.com/library/windows/apps/hh700394.aspx) xxx [Xxxxxx XXX xxxx](http://dev.windows.com/design).

Xxxx xx x xxxx xxxx xx xxx xxxx xxxx xxx xx xxxxxx xxxxxxxxx.

-   XxxxxXxxXxxXxxxxXxxxxxXxxXxxxxXxxx
-   XxxxxXxxXxxXxxxxXxxxxxXxxxXxxxxxxXxxxxxxxx
-   XxxxxXxxXxxxxxXxxxXxxxxxxxxxxXxxxXxxxxxx
-   XxxxxXxxXxxxxxXxxxXxxxxxxxxxxXxxxXxxxxXxxxxx
-   XxxxxXxxXxxxxxxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxXxxXxxxxxxxxxxXxxxxxXxxxxXxxxx
-   XxxxxXxxXxxxxxxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxXxxXxxxxxXxxxxxxxxxxXxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxXxxXxxxxxXxxxxxxxxxxXxxxXxxxxXxxxXxxxxx
-   XxxxxXxxXxxxXxxxxxxxXxxxxXxxxxxx
-   XxxxxXxxXxxxXxxxXxxxxxxxXxxxxxxxxxXxxxxXxxxxx
-   XxxxxXxxXxxxXxxXxxxxxXxxxxXxxx
-   XxxxxXxxXxxxxxxxxxxXxxxXxxxxXxxxx
-   XxxxxXxxXxxxxxxxxxxXxxxXxxxxXxxxxx
-   XxxxxxxXxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxxxXxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxxxXxxxxxXxxxxxYXxxxXxxxxxx
-   XxxxxxxXxxxxxXxxxxxYXxxxXxxxxxx
-   XxxxxxxXxxxxxXxxxxxxXxxXxxxxx
-   XxxxxxxXxxxxxXxxxxxxXxxxxxxxxXxxxx
-   XxxxxxxXxxxxxXxxxxxxXxxXxxxxx
-   XxxxxxxXxxxxxXxxxxxxXxxxx
-   XxxxxxxXxxxxxXxxxxXxxXxxxxx
-   XxxxxxxXxxxxxxxxxXxxxXxxxXxxxxXxxxx
-   XxxxxxxXxxxxxXxxxxxxXxxxxxxxxXxxxx
-   XxxxxxxXxxxxxXxxxXxxxxXxxxx
-   XxxxxxXxxxxxxXxxxxXxxxxxxxxXxxxxXxxxxx
-   XxxxxxXxxxxxxXxxxxXxxxxxxxXxxxxXxxxxx
-   XxxxxxxXxxxxx
-   XxxxXxxxXxxxXxxxxx
-   XxxxXxxxXxxxXxxxxxxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxXxxxxxXxxxXxxxxXxxxx
-   XxxxxxXxxxxxxXxxxxxxxxXxxxx
-   XxxxXxxxxxxxXxxxx
-   XxxxXxxxxxxxXxxxx
-   XxxXxxxxxXxxxxxxxxXxxxxxx
-   XxxXxxxxxXxxxXxxx
-   XxxXxxxxxXxxxxxXxxxxxxxx
-   XxxXxxxxxxXxxxxxXxxxxxxxxXxxxxxx
-   XxxXxxxxxxXxxxxxXxxxXxxx
-   XxxXxxxxxxXxxxxxXxxxxxXxxxxxxxx
-   XxxXxxxxxxXxxxxxXxxxxxxxx
-   XxxxxxXxxxxxXxxxXxxxxXxxxxx
-   XxxxXxxxxxxx
-   XxxxXxxxXxxxxxXxxxxx
-   XxxxXxxxxx
-   XxxxXxxxXxxxxXxxxxxXxxxXxxxxXxxxx
-   XxxxXxxxXxxxXxxxxxxXxxxXxxxxXxxxx
-   XxxxXxxxXxxxXxxxxxxXxxxxxxxxX
-   XxxxXxxxXxxxXxxxxx
-   XxxxXxxxXxxxXxxxxxxxxxxXxxxxXxxXxxxxx
-   XxxxXxxxXxxxXxxxxxxxxXxxxXxxxxXxxxx
-   XxxxXxxxXxxxXxxxXxxxxXxxxx
-   XxxxxXxxxxxxXxxxxXxxxxXxxxxXxxxx
-   XxxxxXxxxxxxXxxxxXxxxxXxxxxXxxxxXxxxx
-   XxxxxXxxxxxxXxxxxXxxxxXxxxxXxxxx
-   XxxxxXxxxxxxXxxxxXxxxxXxxxxXxxxx
-   XxxxxXxxxxxxXxxxXxxxxXxxxxXxxxx
-   XxxxxXxxxxxxXxxxXxxXxxxxXxxxx
-   XxxxxXxxxxxxXxxxXxxXxxxxXxxxx
-   XxxxxXxxxxxxxXxxxxxxxXxxxxxxxxXxxxxXxxxx
-   XxxxxXxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxXxxxXxxxxXxxxx
-   XxxxXxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxXxxxxxXxxxxxXxxxxXxxxx
-   XxxxXxxxxxXxxxxxxxxXxxxxXxxxxxx
-   XxxxXxxxxxXxxxXxxxxxxxxXxxxxxXxxxxXxxxxxxxx
-   XxxxXxxxxxXxxxxxxxXxxxxxXxxxxXxxxxxxxx
-   XxxxXxxxxxXxxxxxxxXxxxxXxxxxxx
-   XxxxXxxxxxXxxxxXxxxxxxxxXxxxxxXxxxxXxxxxxxxx
-   XxxxxxxXxxxxxXxxxxxxXxxxx
-   XxxxxxxXxxxxxXxxxxXxxxx
-   XxxxxxxXxxxxxXxxxxx
-   XxxxxxxxXxxXxxxxXxxXxxxxXxxxxx
-   XxxxxXxxxxxXxxxx
-   XxxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxXxxxxXxxxx
-   XxxxxXxxxXxxxXxxxx
-   XxxxxXxxxXxxXxxxx
-   XxxxxXxxxXxxXxxxxXxxxx
-   XxxxxXxxxXxxxxxXxxxXxxxx
-   XxxxxXxxxXxxxxxXxxXxxxx
-   XxxxxXxxxXxxxxxXxxXxxxxXxxxx
-   XxxxxXxxxXxxXxxxx
-   XxxxxXxxxXxxxxXxxxx
-   XxxxxXxxxxxXxxxxxxxx
-   XxxxxXxxxxxXxxxXxxxxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxxxXxxxxxxXxxxxxx
-   XxxxxXxxxxxXxxxXxxxxx
-   XxxxxXxxxxxXxxXxxxxx
-   XxxxxXxxxxxXxxXxxxx
-   XxxxxXxxxxxXxxxx
-   XxxxxXxxxxxXxxxx
-   XxxxxXxxxxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxxxxXxxxxxxxXxxxx
-   XxxxxXxxxxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxxxxxXxxxx
-   XxxxxXxxxxxxxXxxxx
-   XxxxxXxxxXxxxxxXxxxx
-   XxxxxXxxxXxxxxxXxxxXxxx
-   XxxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxXxxxxxxxXxxxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxXxxxXxxxxxxxXxxxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxXxxxxXxxxxxxxxxxXxxxx
-   XxxxxXxxXxxxx
-   XxxxxXxxXxxxx
-   XxxxxXxxxXxxxxxxxxxXxxxx
-   XxxxxXxxxxXxxxxxXxxxxxxxxxx
-   XxxxxXxxxxXxxxxxxxxxXxxxXxxxxxx
-   XxxxxXxxxxXxxxxXxxXxxxxxXxxxx
-   XxxxxXxxxxXxxxxXxxXxxxx
-   XxxxxXxxxxXxxxxXxxXxxxxXxxxx
-   XxxxxXxxxxXxxxxXxxXxxxxxxXxxxx
-   XxxxxXxxxxxXxxxxxxxx
-   XxxxxXxxxXxxxXxxxx
-   XxxxxXxxxXxxXxxxx
-   XxxxxXxxxXxxXxxxx
-   XxxxxXxxxXxxxXxxxxxXxxxx
-   XxxxxXxxxxXxxxxxXxxxxXxxxxxxx
-   XxxxxXxxxxXxxxxxXxxxxxxx
-   XxxxxXxxxxxXxxxXxxxxxx
-   XxxxxxxxxxxXxxxxxxXxxxxxxxxXxxxx
-   XxxxxxxxXxxXxxxXxxxxxxxXxxxxxXxxXxxxxXxxxx
-   XxxxxxxxXxxXxxxxxxxxxxxxXxxxxxxxXxxxxXxxx
-   XxxxxxxxXxxXxxxxxxxxXxxxx
-   XxxxxxxxXxxxXxxxxxXxxxxxxxxxXxxxxxx
-   XxxxxxxxXxxxXxxxxxXxxxxXxxxxx
-   XxxxxxxxXxxxXxxxxxXxxxxXxxx
-   XxxxxxxxXxxxXxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxxxxxXxxxXxxxXxxxxXxxxxx
-   XxxxxxxxXxxxXxxxxXxxx
-   XxxxXxxxXxxXxxxXxxxxXxxxxx
-   XxxxxXxxxXxxxxxXxxxxx
-   XxxxxXxxxxx
-   XxxxxxXxxXxxXxxxxXxxxxx
-   XxxxxxXxxXxxXxxxxXxxxx
-   XxxxxxXxxXxxxxxxXxxxxXxxxxXxxxxx
-   XxxxxxXxxXxxxxxxXxxxxXxxxxXxxxx
-   XxxxxxXxxxxXxxxxxxxXxxxxxXxxxxXxxxx
-   XxxxxxXxxxxXxxxxxXxxxxXxxxx
-   XxxxxxXxxxxXxxxxxxxXxxxxxXxxxxXxxxx
-   XxxxXxxXxxxxxxxxxXxxxx
-   XxxxXxxXxxxxxXxxxx
-   XxxxXxxXxxxxxxxXxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxXxxXxxxxxxXxxxxxxxxxXxxxxXxxxx
-   XxxxXxxXxxxxxxxxxXxxxx
-   XxxxXxxXxxxxxxxxxxXxxxx
-   XxxxXxxxxxxXxxxxxXxxxxxXxxxxXxxxxxxxx
-   XxxxXxxxxxxXxxxxxXxxXxxxxxXxxx
-   XxxxXxxxxXxxxxXxxxxXxxxxXxxxXxxx
-   XxxxXxxxxXxxxxXxxxxXxxxXxxxXxxx
-   XxxxXxxxxXxxxxxXxxxXxxx
-   XxxxXxxxxXxxxxXxxxXxxx
-   XxxxXxxxxxxxxXxxxxxxXxxxxx

## XxxxxxXxx xxxxxxxxxx xx xxxxx xx XxxxXxxxxxxXxx

Xxxxxxxx [**XxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn252803) xx xxxxxxxxxxx xx xxx Xxxxxxxxx xxxxxx xxxxxx, xx xx xxx xxxxx xxxxxxxxxx xx xxxxxx xxxxxxx. Xxx [**XxxxXxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn633874) xxx xxxx xxxxxxxxx xxxxxx xxxxxxxxxx. Xxxx'x xxx xxx xxxxxxxxx xxxxxxxxx x xxxxxx xxxxxxxxxx xxxx **XxxxXxxxxxxXxx**.

Xxxx xxx xxxx xxxxxx xxxxxx, xxx **XxxxXxxxxxx** xxxxx xx xxxxxx, xxxx x xxxxxx xx **XxxxXxxxx**. Xxx xxxx xxxxxxxx xxx xxxx xx xxxxxxxxxxx xxx xxx xxx **XxxxxXxxxxx** xx xxx [**XxxxXxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn633874). Xx xxx xxxx xxxxxxxxx xxx xxxx, xxx **XxxxxxxxxxXxxxxx** xxxxx xx xxxxxx (xxx xx xxx xxxx xxx **XxxxXxxxxxXxxxxxxXxxx**, xxx xxxx xxx xx xxxx-xxxxxx xxxx xxx xxxxxxxx xxxxxxxxx). Xxxx xxx xxxx xxxxxxx x xxxxxx xxxx xxx Xxxxx xxx, xxx **XxxxxXxxxxxxxx** xxxxx xx xxxxxx, xx xxxxx xxxxx xxx xxx xxxx xxxxxx xx xxxx xxxxxxxxxx (xx xxxx xxxx, xxxx xxxxxx xxxxxxxxxx xx xxxxxxx xxxx xxxx xxxx xxxxxxx xx xxx xxxxxxxxx xxxxxxx). Xxxx xxxx xxx **XxxxxxxxxxXxxxxxx** xxx **Xxxxxxxx** xxxxxxxxxx xx **XxxxxxXxxXxxxxXxxxxxxxxXxxxxXxxx** xxx xx xxxxxx xxxxxxxxx (xxxxx xxx xxxxxxxxxx XXXx xx xxxxxxx xxxx xxxxxxxxxxxxx). Xxx **XxxXxxxxxxxx** xx xx xxxxxx xxxxxxxxx.

[
            **XxxxXxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn633874) xxxx xxx xxxxxxx xxx xxxxx xxxxxx xxxxxxx (XXXx). Xxx, xx xxx xxxx xx xxxx x "xxxx" xxxx, xxxx xxx xxx xx xxxx xxx (xxxxxxxxxxx xxxx xxx xxxx xxxx xxxxx xxx **XxxxxXxxxxxxxx** xxxxx xx xx xxxxxx).

```xaml
   <AutoSuggestBox ... >
        <AutoSuggestBox.QueryIcon>
            <SymbolIcon Symbol="Find"/>
        </AutoSuggestBox.QueryIcon>
    </AutoSuggestBox>
```

Xxxx, xxx [XxxxXxxxxxxXxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619996).

## XxxxxxxxXxxx xxxxxxx

Xxx xxxxxxx-xxx xxxxxxx xxx x [**XxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh702601) xxx xxxxxxxxx xx xxx Xxxxxxx Xxxxx xxxxx, xxxxx xx xx xxx xx xxxxx x xxxxx xxxxxx (xx, xx xxxxxxx xxxxxxxxx, xxx xxxxx xxxxxx xxxxxxxxxx xx xxxx xxx xx xx xxxxxx xxxxxxxxx). Xxx, xx xxx xxx xxxx, xxxxxxxxxx, xxxxxxxx xxx xxxx xx xxx xxxxxxx. Xxx xxxxxxxx xxxxxxxxxx xxxx xxx Xxxxxxx Xxxxx xxxxx xx xxxx xxx xxxxxx-xxx xxxx (xxx xxxx xxxx) xxxxxxxx xxx xxxxxx-xx xxxx xxxxxx xxxx xxxxxxxxxx xx. Xxx xxxx xxxxxx, xxx xxx xxxxxx xxx xxxx-xxxxxx xxxxxxxxxxx xxxx xxxxxx-xxx xxxxx.

Xx x Xxxxxxx Xxxxx Xxxxx xxx, xxx xxxxxx-xxx xxxx xxxxxxx xx xxx xxxx xx xxx xxxxxx. Xx x Xxxxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xxx xxxx xx xxx xxxxxx-xxx xxxx xx xxxxxxxxxxx xx xxx xxxxxx xx xxx **XxxxxxxxXxxx** xxxxxxx.

Xx x Xxxxxxx Xxxxx Xxxxx xxx, xxxxxxx xxxxxx xxx xxxxxx-xxx xxxx (xx x-xxxxx) xxxxx xxxxxxx xx xxx xxxxxx-xxx xxxx xxx xxx xxxxxxxxxxxx xx xxx xxxxxxxxxx. Xx x Xxxxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xxxxxxx xx xxxxxxx xxxxxx xxx xxxxxx xxx xxxx.

Xx x Xxxxxxx Xxxxx xxx, xxxx xxx xxx xx xxxxxxxxxxx xxx xxxxxxxxxxx, xxx xxxxxx-xxx xxxx xx xxxxxxxxx (xx xx xxx xxxxx xxxxx) xxx xxx xxxxxx-xx xxxx xx xxxxx xxxxxxx. Xx x Xxxxxxx Xxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xxx xxxxxx-xxx xxxx xxxx xxxxxx xxxxxxx xx xx xxx xxxxx xxxxx.

Xx x Xxxxxxx Xxxxx Xxxxx xxx, xxx xx x Xxxxxxx YY xxx, xxx xxxxxx-xxx xxxx xx xxxxxxxxx xxxx xxx xxxx xxxxxx xx xxxxxxx. Xxx x Xxxxxxx Xxxxx xxx, xxxxx xx xx xxxxx-xx xxxx xxxxxx xxxxxxxxxx, xx xxx xxxxxxxx xxxxx'x xxxxx.

## Xxxxxxxx

Xxx Xxxxxxx Xxxxxxx Y.x **XxxxxxxxXxxx** xxxxx xx xxx xxxxxxxxxxx xxx Xxxxxxx YY. Xxxxxxx, xx xxxxxxxx xx xxxxxxxx x Xxxxxxxx xxxx, xxx xxxxxx xxxx xxxx xxxxx x xxx xx xxxxxx xx xxxx xxxxxx xxxx xxx. Xx xxxxxxxxx xxxx xxx xxxxxx xxxx xxx Xxxxxxxx xxxx xx xxx xxx xxxxx, xx xxx xxxx xxxxxx xxxx xx xxxx xxxxxxxxxx xxxx, xxx xxxx xxx xxx xxxx xxx xx xxxx xxxxxxx.

-   Xxxxxxxxxx xxxx. Xxxxxxxx xxxxxx xx xxx xxxx xxxx xx xxx xxxxxxxxxxxx xxxx xx xxxxxxx, xxx xxxxxx xx xxx xxxxxx.
-   Xxxxxx/xxxxxxx (xxxxxx x xxxx xxxx xx xxxxx xxxxxx). Xxxxxxxx xxxxxx xx xxx xxxx xxxx xx xxx xxxxxx xx xxxxxxx xxxx xxxxxx. Xx xx xxx xxxxxxxxxxx xxx Xxxxxxxx xx xx xxx xx xxx xxx-xxxxx xxxxx xxxxxx xxx xxxxxxxxxx.
-   Xxx. Xxxxxxxx xxxxxx xx xxxxxxx xxxxxx xx xxx xxxx xxxxxx (xxxxx xx xxxx xxx xxx xxx xxxx xx xxx xxxxxxx xxxx xxxxxx xxx Xxx xxxxxx).

Xx'x xxxx xxx xxxxxxxxxxx xx xxxx Xxxxxxxx xxxxxx x xxxxxx-xxxxxx xxxx.

Xxxx Xxxxxxxx xxxx xxxxxx xxxx xxx xxxxx xx xxxx xxx'x xxxxxx, xxx xxxx Xxxxxxxx xxxx xx xxxx xxxxx Xxxxx xxx Xxxxxxxx xxxxxx xx. Xxx xxxxxxxx xx xxx xxxxxx xx xxxx Xxxxxxxx xxxx, xxx [Xxxxxxxxxx xxx xxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/hh770544).

## Xxxx

Xxxx (xx xxxxxxxxxx) xx xx xxxxxxxxx xxxxxx xx x XXX xxx xxx, xxxxx xxxxxxx, xxx xxx xxxx xx xxxxxxx xxx xxxxxx xxxxxxx xx xxxx xxxxx xx xxxx xxxx xxx xx xxxxxxx xxxx xxx xxx xxxxxx xxxxxxxx. Xxx xxxxx xxxxxxxxxxxxx xx xxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) **XxxxXxxxx** xxxxxx xxxxxx xxxx xxx xxxxxxxxx. Xxxx xxx xxxx xxxx xxxxxxxxxx xx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxx xxx xxxx. Xxxxxxxxxxxxx, xxx xxx xxxxxx xxxx xxx xxxxxxxxx xxxxxx xxx xxxx xxx xxxxxxxxxx xxxx xxx Xxxxxxx Xxxxx Xxxxxxxxxxx xxxxxx xxxxxx xxxx xxxxx.

![xxxxxx xxxxxxxxx xxxxxx xxx xxxxxxx YY xxxx](images/label-uwp10stylegallery.png) <br/>Xxxxxx XxxxXxxxx xxxxxx xxx Xxxxxxx YY xxxx

Xx Xxxxxxx Xxxxx xxxx xxx Xxxxxxx Xxxxx Xxxxx xxxx, xxx xxxxxxx xxxx xxxxxx xx Xxxxxx Xxxx Xxxxxxxxx. Xx x Xxxxxxx YY xxx, xxx xxxxxxx xxxx xxxxxx xx Xxxxx XX. Xx x xxxxxx, xxxx xxxxxxx xx xxxx xxx xxx xxxx xxxxxxxxx. Xx xxx xxxx xx xxxxxxxxx xxx xxxx xx xxxx Y.Y xxxx, xxx xxx xxx xxxx xxx xxxxxxx xxxxx xxxxxxxxxx xxxx xx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209671) xxx [**XxxxXxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br244362).

Xx Xxxxxxx Xxxxx xxxx xxx Xxxxxxx Xxxxx Xxxxx xxxx, xxx xxxxxxx xxxxxxxx xxx xxxx xx xxx xx xxx xxxxxxxx xx xxx xxxxx, xx xx xx-xx. Xx x Xxxxxxx YY xxx, xxx xxxxxxx xxxxxxxx xx xxx xx xxx xxx xxx xxxxxxxx (xxxx xxxxxxxx). Xxx xxx xxx [**XxxxxxxxxXxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh702066) xxxxxxxxxx, xxx xxx xxxx xxxxx xxxxxx xxxx xxxxxxxx xxxxxxxx xx xxx xx xxx xxx x xxxxx xxx xxxx xxxxxxxx.

Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxx xxxxx](https://msdn.microsoft.com/library/windows/apps/hh700394.aspx) xxx [Xxxxxx XXX xxxx](http://go.microsoft.com/fwlink/p/?LinkID=533896). Xxxx, xxx xxx [Xxxxxxxx](#controls) xxxxxxx xxxxx xxx xxxxxxx xx xxxx xxxxxxxx.

## Xxxxx xxxxxxx

Xxx x Xxxxxxxxx Y.Y xxx, xxx xxxxxxx xxxxx xx xxxx xx xxxxxxx. Xxx Xxxxxxx YY xxxxxxx, xxx xxxxxxx xxxxx xxx xxxxxxx, xxx xxx xxx xxxxxxx xxx xxxxx xxxx xx xxxxxxxxx x xxxxxxxxx xxxxx xx Xxx.xxxx. Xxx xxxxxxx, xx xxx x xxxx xxxxx xx xxx xxxxxxx, xxx `RequestedTheme="Dark"` xx xxx xxxx Xxxxxxxxxxx xxxxxxx.

## Xxxxx xxx xxxxxx

Xxx xxxxx xxx xxxxxx, xxx xxxxxxxxx xxx'xx xxxxxxxxx xxxxx xxxx xxxxxxxx xx xxxx xx xxxx Xxxxxxx YY xxx. Xxx, xxxxx xxx xxx, xxxxxxxx xxxxxxxxx xxxxxxxxx xxx xxx xx xxx, xxx xxxxx xxx xxxxxxxxx xx [Xxxxxxxxxxxxx, xxxxx, xxxxxx, xxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/mt185606).

Xxxxxxxxxx, xx xxxxxxx xxxxxxxxx, x xxxxx xxxxxxxxxxxx xxx x xxxxxxxxxx xxxxxxx. Xx xxxxx xxxxxxxxx, xxx xx xxxxxx xx xxxxxxxxxxx, xxxx xx xxx xxxxxx xx xxxxxxx. Xx Xxxxxxx Xxxxx, xx x xxxxx xxxxxxxxxxxx xx xxxxxxx xx xxxxxxxxxxx xxxxxxxxx, xx xxxxx xx xxxx xxx Xxxxxx Xxxxxx. Xxx, Xxxxxx Xxxxxx xx xx xxxxxx xxxxxxx xx xxx Xxxxxx xxxxxx xxxxxx.

Xx xxxx x xxxxx xxxxxxxxxxxx, xxxxx xx xx xxxxxx xxx xxxx xx xxxxxxx x xxxxxxxxxx.

## Xxxxxx xxxx

Xxx x Xxxxxxxxx Y.Y xxx, xxx [**XxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn391667) xxx xxxxxxxx xxxxxxx xx xxxx xx xxxxxxx x xxxxxxx xxxxxx xxxxx. Xx xxxx XXX xxx, xxx xxx xxxxxxx x xxxxxxx xxxx (xxxx xxxxx xxx xxxxxx) xxxx xxxxxxxxxx xxxx. Xxx xxxxxxx xxxxxxx xxxx xx YYYxYYYxxx, xxx xxxx'x xxxx xxx xxxxxxxx xxxxxxx xxxx xxxxxxxx. Xxx xxxxxxx xxxxxxx xxxx xxxxxxxx xx YYYxYYYxxx.

```csharp
   Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetPreferredMinSize
        (new Size { Width = 500, Height = 500 });
```

Xxx xxxx xxxxx xx [Xxxxxxx xxx X/X, xxxxxx, xxx xxx xxxxx](w8x-to-uwp-input-and-sensors.md).

<!--HONumber=Mar16_HO1-->
