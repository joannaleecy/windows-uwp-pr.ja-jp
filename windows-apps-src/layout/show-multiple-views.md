---
Xxxxxxxxxxx: Xxxx xxxx xxxxx xx xxxx xxxxxxxxxx xx xxxxxxx xxxx xxxx xxxxxxxx xxxxxxxxxxx xxxxx xx xxxx xxx xx xxxxxxxx xxxxxxx.
xxxxx: Xxxx xxxxxxxx xxxxx xxx xx xxx
xx.xxxxxxx: XXXYYYYX-XXXX-YYXX-XYXX-YYYYXYYYYXYY
xxxxx: Xxxx xxxxxxxx xxxxx xxx xx xxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxx xxxxxxxx xxxxx xxx xx xxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xxx xxxx xxxx xxxxx xx xxxx xxxxxxxxxx xx xxxxxxx xxxx xxxx xxxxxxxx xxxxxxxxxxx xxxxx xx xxxx xxx xx xxxxxxxx xxxxxxx. X xxxxxxx xxxxxxx xx xx x-xxxx xxx xxxxx xxx xxxx XX xxxxx xxx xxxx xx xxxxxx xxx x xxxxxxx xx xxx xxxxxxxx x-xxxx. Xxx xxxxx xxx xxxx xxxx xxxxxxxx xx xxxxxxxx xxxxxxx xxx xxxx xxxx xxxx-xx-xxxx.

**Xxxxxxxxx XXXx**

-   [**XxxxxxxxxxxXxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn281094)
-   [**XxxxxxXxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn297278)

Xxxx xxx xxxxxx xxxxxxxx xxxxxxx xxx xx xxx, xxxx xxxxxx xxxxxxx xxxxxxxxxxxxx. Xxx xxxxxxx xxxxx xxxx xxxxxx xxxxxxxxxx. Xxxxx xxx xxxx, xxxxxx, xxxx, xxx xxxx xxx xxxxxxx xxxxxxxxxxxxx xxx xxx xxxxxx xxxxxxx xxx xxxxxxx xx xx xxxx xxxx xxxxxxxx xxxx. Xxxx xxxxxx xxxxxxxx xx xxx xxx xxxxxx.

## <span id="What_is_a_view_">
            </span>
            <span id="what_is_a_view_">
            </span>
            <span id="WHAT_IS_A_VIEW_">
            </span>Xxxx xx x xxxx?


Xx xxx xxxx xx xxx Y:Y xxxxxxx xx x xxxxxx xxx x xxxxxx xxxx xxx xxx xxxx xx xxxxxxx xxxxxxx. Xx'x xxxxxxxxxxx xx x [**XxxxXxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br225017) xxxxxx.

Xxxxx xxx xxxxxxx xx xxx [**XxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225016) xxxxxx. Xxx xxxx [**XxxxXxxxxxxxxxx.XxxxxxXxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn297278) xx xxxxxx x[**XxxxXxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br225017) xxxxxx. Xxx **XxxxXxxxxxxxxxxXxxx** xxxxxx xxxxxxxx x [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxx x [**XxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208211) (xxxxxx xx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225019) xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn433264) xxxxxxxxxx). Xxx xxx xxxxx xx xxx **XxxxXxxxxxxxxxxXxxx** xx xxx xxxxxx xxxx xxx Xxxxxxx Xxxxxxx xxxx xx xxxxxxxx xxxx xxx xxxx Xxxxxxx xxxxxx.

Xxx xxxxxxxxx xxx’x xxxx xxxxxxxx xxxx xxx [**XxxxXxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br225017). Xxxxxxx, xxx Xxxxxxx Xxxxxxx xxxxxxxx xxx [**XxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh701658) xxxxx xx xxx [**Xxxxxxx.XX.XxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242295) xxxxxxxxx. Xxxx xxxxx xxxxxxxx xxxxxxxxxx, xxxxxxx, xxx xxxxxx xxxx xxx xxx xxxx xxxx xxx xxxxxxxxx xxxx xxx xxxxxxxxx xxxxxx. Xx xxxx xxxx xx **XxxxxxxxxxxXxxx**, xxxx xxx xxxxxx [**XxxxxxxxxxxXxxx.XxxXxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh701672) xxxxxx, xxxxx xxxx xx **XxxxxxxxxxxXxxx** xxxxxxxx xxxx xx xxx xxxxxxx **XxxxXxxxxxxxxxxXxxx**’x xxxxxx.

Xxxxxxxx, xxx XXXX xxxxxxxxx xxxxx xxx [**XxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208225) xxxxxx xx x [**Xxxxxxx.XX.XXXX.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209041) xxxxxx. Xx x XXXX xxx, xxx xxxxxxxxx xxxxxxxx xxxx xxx **Xxxxxx** xxxxxx xxxxxx xxxx xxxxxxx xxxxxxxx xxxx xxx **XxxxXxxxxx**.

## <span id="Show_a_new_view">
            </span>
            <span id="show_a_new_view">
            </span>
            <span id="SHOW_A_NEW_VIEW">
            </span>Xxxx x xxx xxxx


Xxxxxx xx xx xxxxxxx, xxx'x xxxx xx xxx xxxxx xx xxxxxx x xxx xxxx. Xxxx, xxx xxx xxxx xx xxxxxxxx xx xxxxxxxx xx x xxxxxx xxxxx.

```CSharp
private async void Button_Click(object sender, RoutedEventArgs e)
{
    CoreApplicationView newView = CoreApplication.CreateNewView();
    int newViewId = 0;
    await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        Frame frame = new Frame();
        frame.Navigate(typeof(SecondaryPage), null);   
        Window.Current.Content = frame;
        // You have to activate the window in order to show it later.
        Window.Current.Activate();

        newViewId = ApplicationView.GetForCurrentView().Id;
    });
    bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);
}
```

**Xx xxxx x xxx xxxx**

1.  Xxxx [**XxxxXxxxxxxxxxx.XxxxxxXxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn297291) xx xxxxxx x xxx xxxxxx xxx xxxxxx xxx xxx xxxx xxxxxxx.

```    CSharp
CoreApplicationView newView = CoreApplication.CreateNewView();</code></pre></td>
    </tr>
    </tbody>
    </table>
```

2.  Xxxxx xxx [**Xx**](https://msdn.microsoft.com/library/windows/apps/dn281120) xx xxx xxx xxxx. Xxx xxx xxxx xx xxxx xxx xxxx xxxxx.

    Xxx xxxxx xxxx xx xxxxxxxx xxxxxxxx xxxx xxxxxxxxxxxxxx xxxx xxxx xxx xx xxxx xxxx xxxxxxxx xxx xxxxx xxx xxxxxx. Xxx xxx `ViewLifetimeControl` xxxxx xx xxx [XxxxxxxxXxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620574) xxx xx xxxxxxx.

    <span codelanguage="CSharp"></span>
```    CSharp
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
int newViewId = 0;</code></pre></td>
    </tr>
    </tbody>
    </table>
```

3.  Xx xxx xxx xxxxxx, xxxxxxxx xxx xxxxxx.

    Xxx xxx xxx [**XxxxXxxxxxxxxx.XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh750317) xxxxxx xx xxxxxxxx xxxx xx xxx XX xxxxxx xxx xxx xxx xxxx. Xxx xxx x [xxxxxx xxxxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=389615) xx xxxx x xxxxxxxx xx xx xxxxxxxx xx xxx **XxxXxxxx** xxxxxx. Xxx xxxx xxx xx xx xxx xxxxxx xxxxxxxx xxxxxxx xx xxx xxx xxxx'x xxxxxx.

    Xx XXXX, xxx xxxxxxxxx xxx x [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br242682) xx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209041)'x [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209051) xxxxxxxx, xxxx xxxxxxxx xxx **Xxxxx** xx x XXXX [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br227503) xxxxx xxx'xx xxxxxxx xxxx xxx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxx-xx-xxxx xxxxxxxxxx xxxxxxx xxx xxxxx](peer-to-peer-navigation-between-two-pages.md).

    Xxxxx xxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209041) xx xxxxxxxxx, xxx xxxx xxxx xxx **Xxxxxx**'x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209046) xxxxxx xx xxxxx xx xxxx xxx **Xxxxxx** xxxxx. Xxxx xxxx xxxxxxx xx xxx xxx xxxx'x xxxxxx, xx xxx xxx **Xxxxxx** xx xxxxxxxxx.

    Xxxxxxx, xxx xxx xxx xxxx'x [**Xx**](https://msdn.microsoft.com/library/windows/apps/dn281120) xxxx xxx xxx xx xxxx xxx xxxx xxxxx. Xxxxx, xxxx xxxx xx xx xxx xxx xxxx'x xxxxxx, xx [**XxxxxxxxxxxXxxx.XxxXxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh701672) xxxx xxx **Xx** xx xxx xxx xxxx.

    <span codelanguage="CSharp"></span>
```    CSharp
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
await newView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        Frame frame = new Frame();
        frame.Navigate(typeof(SecondaryPage), null);   
        Window.Current.Content = frame;
        // You have to activate the window in order to show it later.
        Window.Current.Activate();

        newViewId = ApplicationView.GetForCurrentView().Id;
    });
```

4.  Xxxx xxx xxx xxxx xx xxxxxxx [**XxxxxxxxxxxXxxxXxxxxxxx.XxxXxxxXxXxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn281101).

    Xxxxx xxx xxxxxx x xxx xxxx, xxx xxx xxxx xx xx x xxx xxxxxx xx xxxxxxx xxx [**XxxxxxxxxxxXxxxXxxxxxxx.XxxXxxxXxXxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn281101) xxxxxx. Xxx *xxxxXx* xxxxxxxxx xxx xxxx xxxxxx xx xx xxxxxxx xxxx xxxxxxxx xxxxxxxxxx xxxx xx xxx xxxxx xx xxxx xxx. Xxx xxxxxxxx xxx xxxx [**Xx**](https://msdn.microsoft.com/library/windows/apps/dn281120) xx xxxxx xxxxxx xxx **XxxxxxxxxxxXxxx.Xx** xxxxxxxx xx xxx [**XxxxxxxxxxxXxxx.XxxXxxxxxxxxxxXxxxXxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn281109) xxxxxx.

```    CSharp
bool viewShown = await ApplicationViewSwitcher.TryShowAsStandaloneAsync(newViewId);</code></pre></td>
    </tr>
    </tbody>
    </table>
```

## <span id="The_main_view">
            </span>
            <span id="the_main_view">
            </span>
            <span id="THE_MAIN_VIEW">
            </span>Xxx xxxx xxxx


Xxx xxxxx xxxx xxxx’x xxxxxxx xxxx xxxx xxx xxxxxx xx xxxxxx xxx *xxxx xxxx*. Xxxx xxxx xx xxxxxx xx xxx [**XxxxXxxxxxxxxxx.XxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh700465) xxxxxxxx, xxx xxx [**XxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh700452) xxxxxxxx xx xxxx. Xxx xxx’x xxxxxx xxxx xxxx; xx’x xxxxxxx xx xxx xxx. Xxx xxxx xxxx'x xxxxxx xxxxxx xx xxx xxxxxxx xxx xxx xxx, xxx xxx xxx xxxxxxxxxx xxxxxx xxx xxxxxxxxx xx xxxx xxxxxx.

Xx xxxxxxxxx xxxxx xxx xxxx, xxx xxxx xxxx’x xxxxxx xxx xx xxxxxx – xxx xxxxxxx, xx xxxxxxxx xxx xxxxx (x) xxxxxx xx xxx xxxxxx xxxxx xxx - xxx xxx xxxxxx xxxxxxx xxxxxx. Xxxxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209049) xx xxx xxxx xxxx’x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209041) xxxxxx xx **XxxxxxxXxxxxxxxxXxxxxxxxx** xx xxxxx. (Xxx [**Xxxxxxxxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/br242327) xx xxxxx xxxx xxx.) Xx xxx xxxx xxxx’x xxxxxx xx xxxxxxxxxx, xxx xxx xxxxxx.

## <span id="Secondary_views">
            </span>
            <span id="secondary_views">
            </span>
            <span id="SECONDARY_VIEWS">
            </span>Xxxxxxxxx xxxxx


Xxxxx xxxxx, xxxxxxxxx xxx xxxxx xxxx xxx xxxxxx xx xxxxxxx [**XxxxxxXxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn297278) xx xxxx xxx xxxx, xxx xxxxxxxxx xxxxx. Xxxx xxx xxxx xxxx xxx xxxxxxxxx xxxxx xxx xxxxxx xx xxx [**XxxxXxxxxxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br205861) xxxxxxxxxx. Xxxxxxxxx, xxx xxxxxx xxxxxxxxx xxxxx xx xxxxxxxx xx x xxxx xxxxxx. Xx xxxx xxxxxxxxx, xxx xxxxxx xxxxxxx xxxxxxxxx xxxxx xxx xxxx xxx.

**Xxxx**  Xxx xxx xxx xxx Xxxxxxx *xxxxxxxx xxxxxx* xxxxxxx xx xxx xx xxx xx [xxxxx xxxx](https://technet.microsoft.com/library/mt219050.aspx). Xxxx xxx xx xxxx, xxx xxxxxx xxxxxxx x xxxxxxxxx xxxx xx xxxxxxx xxxx xxx XX xxxxx xxx xxxx xxxxxx. Xxx-xxxxxxx xxxxxxxxx xxxxx xxx xxx xxxxxxx, xx xx xxx xxx xx xxxx xxxx xxx xxxxxxxxx xxxx xx xxxxx xxxx, xx xxxxxxxxx xx xxxxxx.

 

## <span id="Switch_from_one_view_to_another">
            </span>
            <span id="switch_from_one_view_to_another">
            </span>
            <span id="SWITCH_FROM_ONE_VIEW_TO_ANOTHER">
            </span>Xxxxxx xxxx xxx xxxx xx xxxxxxx


Xxx xxxx xxxxxxx x xxx xxx xxx xxxx xx xxxxxxxx xxxx x xxxxxxxxx xxxxxx xxxx xx xxx xxxx xxxxxx. Xx xx xxxx, xxx xxx [**XxxxxxxxxxxXxxxXxxxxxxx.XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn281097) xxxxxx. Xxx xxxx xxxx xxxxxx xxxx xxx xxxxxx xx xxx xxxxxx xxx'xx xxxxxxxxx xxxx xxx xxxx xxx xxxx XX xx xxx xxxxxx xxx'xx xxxxxxxxx xx.

<span codelanguage="CSharp"></span>
```CSharp
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
await ApplicationViewSwitcher.SwitchAsync(viewIdToShow);</code></pre></td>
</tr>
</tbody>
</table>
```

Xxxx xxx xxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn281097), xxx xxx xxxxxx xx xxx xxxx xx xxxxx xxx xxxxxxx xxxxxx xxx xxxxxx xx xxxx xxx xxxxxxx xx xxxxxxxxxx xxx xxxxx xx [**XxxxxxxxxxxXxxxXxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn281105).

 

 




<!--HONumber=Mar16_HO1-->
