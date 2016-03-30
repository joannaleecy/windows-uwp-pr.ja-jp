---
Xxxxxxxxxxx: Xxx xxxxxx xxxxxx xxxxxxxxxx x xxxxxxxx xxxxxx xxxx xxxxxx xxxxx xx xxxx xxxxxx xx xx xxx.
xxxxx: Xxxxxxxxxx xxx xxxxxx xxxxxx xxxxxxxx
xx.xxxxxxx: YYYXXXXY-YYXY-YYYX-XYXY-YYYXYYYXYXXX
xxxxx: Xxxxxx xxxxxxxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxxxx xxxxxxxx

Xxx xxxxxx xxxxxx xxxxxxxxxx x xxxxxxxx xxxxxx xxxx xxxxxx xxxxx xx xxxx xxxxxx xx xx xxx. Xxx **XxxxxxXxxxxx** xxxxxxxx xx xxxxxxx xxxxx xxxx xxxxxxx xxx xxxxxxxx xxxxxxxxx xxxxxxx (xxxx xx/xxx), xxxxx xxxxxxxx xx xxxxxx xxxxxxx xx xx xxxxxxxxx xxxxxx.

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**XxxxxxXxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.aspx)
-   [**XxXx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.ison.aspx)
-   [**Xxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.toggled.aspx)

## Xx xxxx xxx xxxxx xxxxxxx?

Xxx x xxxxxx xxxxxx xxx xxxxxx xxxxxxxxxx xxxx xxxx xxxxxx xxxxx xxxxx xxx xxxx xxxxx xxx xxxxxx xxxxxx. Xxx xxxxxxx, xxx x xxxxxx xxxxxx xx xxxx xxxxxxxx xx xxxxxxxx xxxxxxxxxx xx xx xxx, xxxx xx XxXx:

![XxXx xxxxxx xxxxxx, xx xxx xxx](images/toggleswitches01.png)

Xx x xxxxxxxx xxxxxx xxxxx xxxx xxx xxx xxxxxx, x xxxxxx xxxxxx xx xxxxxxxx xxx xxxx xxxxxxx xx xxx.

Xxxxx xxx xxxx xxxxxxx xxx xxxxxx xx xx xxx, xx xxxxxxxxx xxxx xxx xxxxxxxxxxxxx xxxxxx xx xxxxxxxxxxx xxxxxxxxx.

### Xxxxxxxx xxxxxxx xxxxxx xxxxxx xxx xxxxx xxx

Xxx xxxx xxxxxxx, xxxxxx x xxxxxx xxxxxx xx x xxxxx xxx xxxxx xxxx. Xx xxxxxx xxxxx xxxxxxx xxxxx xxxx xxxxxx, xxxxxx xxxxx xxxx:

-   Xxx x xxxxxx xxxxxx xxx xxxxxx xxxxxxxx xxxx xxxxxxx xxxxxx xxxxxxxxx xxxxxxxxxxx xxxxx xxx xxxx xxxxxxx xxxx.

    ![Xxxxxx xxxxxx xxxxxx xxxxx xxx](images/toggleswitches02.png)

    Xx xxx xxxxx xxxxxxx, xx'x xxxxx xxxx xxx xxxxxx xxxxxx xxxx xxx xxxxxxxx xx xxx xx "Xx." Xxx xxxx xxx xxxxxxxx, xxx xxxx xxxxx xx xxxxx xxxxx xxxxxxx xxx xxxxxxxx xx xx xxx xx xxxxxxx xxxx xxxx xx xxxxx xxx xxx xx xxxx xxxxxxxx xx.

-   Xxx x xxxxxxxx xxxx xxx xxxx xxx xx xxxxxxx xxxxx xxxxx xxx xxxxxxx xx xx xxxxxxxxx. Xxx xxxxxxx, xx xxx xxxx xxxx xxxxx x "xxxxxx" xx "xxxx" xxxxxx xx xxxxx xxxxxxx, xxx x xxxxx xxx.

    ![X xxxxxxxx xxx x Xxxxxx xxxxxx](images/submitcheckbox.png)

-   Xxx xxxxx xxxxx xx x [xxxx xxx](lists.md) xxxx xxx xxxx xxx xxxxxx xxxxxxxx xxxxx:

    ![X xxxxxxxx xxxx xxx xxxxxxxx xxxxx xxxxxxxx](images/guidelines_and_checklist_for_toggle_switches_checkbox_multi_select.png)

## Xxxxxx x xxxxxx xxxxxx

Xxxx'x xxx xx xxxxxx x xxxxxx xxxxxx xxxxxx. Xxxx XXXX xxxxxxx xxx XxXx xxxxxx xxxxxx xxxxx xxxxxxxxxx.

```xaml
<ToggleSwitch x:Name="wiFiToggle" Header="Wifi"/>
```
Xxxx'x xxx xx xxxxxx xxx xxxx xxxxxx xxxxxx xx xxxx.

```csharp
ToggleSwitch wiFiToggle = new ToggleSwitch();
wiFiToggle.Header = "WiFi";

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(wiFiToggle);
```

### XxXx

Xxx xxxxxx xxx xx xxxxxx xx xx xxx. Xxx xxx [**XxXx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.ison.aspx) xxxxxxxx xx xxxxxxxxx xxx xxxxx xx xxx xxxxxx. Xxxx xxx xxxxxx xx xxxx xx xxxxxxx xxx xxxxx xx xxxxxxx xxxxxx xxxxxxxx, xxx xxx xxx x xxxxxxx xx xxxxx xxxx.

```
<StackPanel Orientation="Horizontal">
    <ToggleSwitch x:Name="ToggleSwitch1" IsOn="True"/>
    <ProgressRing IsActive="{x:Bind ToggleSwitch1.IsOn, Mode=OneWay}" Width="130"/>
</StackPanel>
```

### Xxxxxxx

Xx xxxxx xxxxx, xxx xxx xxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.toggled.aspx) xxxxx xx xxxxxxx xx xxxxxxx xx xxx xxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxx x Xxxxxxx xxxxx xxxxxxx xx XXXX xxx xx xxxx. Xxx Xxxxxxx xxxxx xx xxxxxxx xx xxxx x xxxxxxxx xxxx xx xx xxx, xxx xxxxxx xxx xxxxxxxxxx.

```xaml
<ToggleSwitch x:Name="toggleSwitch1" IsOn="True" 
              Toggled="ToggleSwitch_Toggled"/>
```

Xxxx'x xxx xx xxxxxx xxx xxxx xxxxxx xxxxxx xx xxxx.

```csharp
// Create a new toggle switch and add a Toggled event handler.
ToggleSwitch toggleSwitch1 = new ToggleSwitch();
toggleSwitch1.Toggled += ToggleSwitch_Toggled;

// Add the toggle switch to a parent container in the visual tree.
stackPanel1.Children.Add(toggleSwitch1);
```

Xxxx'x xxx xxxxxxx xxx xxx Xxxxxxx xxxxx.

```csharp
private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
{
    ToggleSwitch toggleSwitch = sender as ToggleSwitch;
    if (toggleSwitch != null)
    {
        if (toggleSwitch.IsOn == true)
        {
            progress1.IsActive = true;
            progress1.Visibility = Visibility.Visible;
        }
        else
        {
            progress1.IsActive = false;
            progress1.Visibility = Visibility.Collapsed;
        }
    }
}
```

### Xx/Xxx xxxxxx

Xx xxxxxxx, xxx xxxxxx xxxxxx xxxxxxxx xxxxxxx Xx xxx Xxx xxxxxx, xxxxx xxx xxxxxxxxx xxxxxxxxxxxxx. Xxx xxx xxxxxxx xxxxx xxxxxx xx xxxxxxx xxx [**XxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.oncontent.aspx), xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.offcontent.aspx) xxxxxxxxxx.

Xxxx xxxxxxx xxxxxxxx xxx Xx/Xxx xxxxxx xxxx Xxxx/Xxxx xxxxxx.  

```xaml
<ToggleSwitch x:Name="imageToggle" Header="Show images"
              OffContent="Show" OnContent="Hide" 
              Toggled="ToggleSwitch_Toggled"/>
```

Xxx xxx xxxx xxx xxxx xxxxxxx xxxxxxx xx xxxxxxx xxx [**XxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.oncontenttemplate.aspx) xxx [**XxxXxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.toggleswitch.offcontenttemplate.aspx) xxxxxxxxxx.

## Xxxxxxxxxxxxxxx

-   Xxxxxxx xxx Xx xxx Xxx xxxxxx xxxx xxxxx xxx xxxx xxxxxxxx xxxxxx xxx xxx xxxxxxx. Xx xxxxx xxx xxxxx (Y-Y xxxxxxxxxx) xxxxxx xxxx xxxxxxxxx xxxxxx xxxxxxxxx xxxx xxx xxxx xxxxxxxxxxx xxx x xxxxxxxxxx xxxxxxx, xxx xxxxx. Xxx xxxxxxx, xxx xxxxx xxx "Xxxx/Xxxx" xx xxx xxxxxxx xx "Xxxx xxxxxx." Xxxxx xxxx xxxxxxxx xxxxxx xxx xxxx xxxx xxxxxxxxxx xxx XX.
-   Xxxxx xxxxxxxxx xxx Xx xxx Xxx xxxxxx xxxxxx xxx xxxx; xxxxx xxxx xxx xxxxxxx xxxxxx xxxxxx xxx xxxxxxxxx xxxxx xxx xxxxxx xxxx.
-   Xxxxxx xxxxxx xx xx xxxx xxxx Y xxxxxxxxxx xxxx.

## Xxxxxxx xxxxxxxx

[**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701411)
- [Xxxxx xxxxxxx](radio-button.md)
- [Xxxxxx xxxxxxxx](toggles.md)
- [Xxxxx xxxxx](checkbox.md)

**Xxx xxxxxxxxxx (XXXX)**
- [**XxxxxxXxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209712)
<!--HONumber=Mar16_HO1-->
