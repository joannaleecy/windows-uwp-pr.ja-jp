---
Xxxxxxxxxxx: Xxxx xxx xxxx xxx x xxxxx xx x xxxxx xxxxx.
xxxxx: Xxxxxxx
xx.xxxxxxx: YXXYXXYY-XXYX-YXXY-XYYY-XYXXYXYYYXXX
xxxxx: Xxxxxxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxxxxx

X xxxxxx xx x xxxxxxx xxxx xxxx xxx xxxx xxxxxx xxxx x xxxxx xx xxxxxx xx xxxxxx x xxxxx xxxxxxx xxxxx x xxxxx.

<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**Xxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.slider.aspx)
-   [**Xxxxx xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx)
-   [**XxxxxXxxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx)

X xxxxxx xxxxxxx xxxx xxx xxxx xxx x xxxxx xx x xxxxx xxxxx xx xxxxxxx—xx xxxxxxxxx xxxx xxx xxxxx—xx x xxxxx.

## Xx xxxx xxx xxxxx xxxxxxx?

Xxx x xxxxxx xxxx xxx xxxx xxxx xxxxx xx xx xxxx xx xxx xxxxxxx, xxxxxxxxxx xxxxxx (xxxx xx xxxxxx xx xxxxxxxxxx) xx x xxxxx xx xxxxxxxx xxxxxx (xxxx xx xxxxxx xxxxxxxxxx xxxxxxxx).

X xxxxxx xx x xxxx xxxxxx xxxx xxx xxxx xxxx xxxxx xxxxx xx xxx xxxxx xx x xxxxxxxx xxxxxxxx, xxx x xxxxxxx xxxxx. Xxx xxxxxxx, xxxxx xxxxx xxxxx xxxxxxx xxxxx xxxxx xxxxxx xx xxx xx xxxxxx—xxx xxxxx xxxxxxx xxx xxxxx xx Y xx Y.

Xxx'x xxx x xxxxxx xxx xxxxxx xxxxxxxx. Xxx x [xxxxxx xxxxxx](toggles.md) xxxxxxx.

Xxxx xxx xxxx xxxxxxxxxx xxxxxxx xx xxxxxxxx xxxx xxxxxxxx xxxxxxx xx xxx x xxxxxx:

-   **Xxxx xxx xxxxxxx xxxx xxxx x xxxxxxxx xxxxxxxx?** Xx xxx, xxx [xxxxx xxxxxxx](radio-button.md) xx x [xxxx xxx](lists.md).
-   **Xx xxx xxxxxxx xx xxxxx, xxxxx xxxxxxx xxxxx?** Xx xx, xxx x xxxxxxx [xxxx xxx](text-box.md).
-   **Xxxxx x xxxx xxxxxxx xxxx xxxxxxx xxxxxxxx xx xxx xxxxxx xx xxxxxxx xxxxxxx?** Xx xx, xxx x xxxxxx. Xxx xxxxxxx, xxxxx xxx xxxxxx x xxxxx xxxx xxxxxx xx xxxxxxxxxxx xxxxxx xxx xxxxxx xx xxxxxxx xx xxx, xxxxxxxxxx, xx xxxxxxxxxx xxxxxx.
-   **Xxxx xxx xxxxxxx xxxx x xxxxx xx xxxx xx xxxx xxxxxx?** Xx xxx, xxx [xxxxx xxxxxxx](radio-button.md).
-   **Xxx xxx xxxx xxxxxx xxx xxxxx?** Xxxxxxx xxx xxx xxxx xxxxxxxxxxx. Xx x xxxx xxx'x xxxx xxxxxx xxx xxxxx, xxx xxxx-xxxx xxxx xxxxxxx.

Xx xxx xxx xxxxxxxx xxxxxxx x xxxxxx xxx x xxxxxxx xxxx xxx, xxx x xxxxxxx xxxx xxx xx:

-   Xxxxxx xxxxx xx xxxxx.
-   Xxx xxxx xx xxxxxx xx xxxxxx xxxxx xxx xxxxxxxx.

Xxx x xxxxxx xx:

-   Xxxxx xxxx xxxxxxx xxxx xxxxxxx xxxxxxxx.

## Xxxxxxxx

![X xxxxxx xxxxxxx](images/slider_basic.PNG)

## Xxxxxx x xxxxxx

Xxxx'x xxx xx xxxxxx x xxxxxx xx XXXX.

```xaml
<Slider x:Name="volumeSlider" Header="Volume" Width="200"
        ValueChanged="Slider_ValueChanged"/>
```

```csharp
Slider volumeSlider = new Slider();
volumeSlider.Header = "Volume";
volumeSlider.Width = 200;
volumeSlider.ValueChanged += Slider_ValueChanged;

// Add the slider to a parent container in the visual tree.
stackPanel1.Children.Add(volumeSlider);
```

Xxx xxx xxx xxx xxx xxxxx xx xxx xxxxxx xxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.value.aspx) xxxxxxxx. Xx xxxxxxx xx xxxxx xxxxxxx, xxx xxx xxx xxxx xxxxxxx, xx xxxxxx xxx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.primitives.rangebase.valuechanged.aspx) xxxxx.

```csharp
private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
{
    Slider slider = sender as Slider;
    if (slider != null)
    {
        media.Volume = slider.Value;
    }
}
```

## Xxxxxxxxxxxxxxx

-   Xxxx xxx xxxxxxx xx xxxx xxxxx xxx xxxxxx xxx xxx xxxxx xxxx xxxx. Xxx xxxxxxxx xxxx xxxxxxxx xxxxxx, xxxx xxxx xxx xxxx xxx xxxxxx xxxxxx xxx xxxxx xxxxx xxx xxxxx. Xxxx xxxx xxx xxxxxxxxx xx xxx xxxxxx xxxxxx xxx xxxxxx xxx xxxxxx xx x xxxx.
-   Xxxx xxxxxxxxx xxxxxxxx xxxxx xx xxxxx x xxxx xxxxx x xxxxxxxxx (xxxx xxxxxxxxx). Xxx xxxxxxx, xxx Xxxxxxx xxxxxx xxxxxxx xxxxx xx xxxxxxxx xxx xxxxxxxx xxxxx xxxxxx.
-   Xxx xxxxxx xx xxxx xxx xxxxx xx xxxxxx. Xxxxxxxxx: Xx xxx xxxxxx xx xxxxxxxxxx xxxxxxxx xxx xxx xxx xxxxx xx Xxxxxxx, Xxxx, Xxxx, xx xxxxxxxxxx, xxx xxx xxxx xxx xxxxx xxxxxx xxxxxxx xxx xxxxxxx xx xxxxx.
-   Xxxxxxx xxx xxxxxxxxxx xxxxxx xx xxxxxxxx xxxxxxx xxxx xxx xxxxxxx xxx xxxxxx.
-   Xxxxxxxx xxx xxxxxxxxx xx xxxx xxxx xxxxxxx xxx xxxx xxxxxxxxx xxx/xx xxxxxxxxxxx xx xxxx xxxxxx. Xxxxxx xxxxx xxxx xxxx xx xxxxx xx xxxx xxxxxxxxx, xxx xxxx xxxxx xx xxxx xx xxxxxx.
-   Xxx'x xxx x xxxxxx xx x xxxxxxxx xxxxxxxxx.
-   Xxx'x xxxxxx xxx xxxx xx xxx xxxxxx xxxxx xxxx xxx xxxxxxx xxxx.
-   Xxx'x xxxxxx x xxxxxxxxxx xxxxxx xx xxx xxxxx xx xxxxxx xx xxxxx xxx xxxxx xxxx xxxx xxxxxx xxxxxx xxx xx xxxxxxx xxxxxxxxxxxxxx xxxxxx xxxx xxx xxxxx. Xxxxxxx, xxx xxxxx xxxxxx xx xxx xxxx xxxxx xxxxxxx. Xxx xxxxxxx xx xxxx xxxxx xxxxx xx xx xx Y xxxxx xxx xxxxx xxxx xxxx xx xxxx xxxx Y xxxxxx, Y xxxx, Y xxx xx Y xxxxx, xxxx xxxxxx x xxxxxx xxxx xxxx Y xxxx xxxxxx.

## Xxxxxxxxxx xxxxx xxxxxxxx

### Xxxxxxxx xxx xxxxx xxxxxx: xxxxxxxxxx xx xxxxxxxx

Xxx xxx xxxxxx xxxx xxxxxx xxxxxxxxxxxx xx xxxxxxxxxx. Xxx xxxxx xxxxxxxxxx xx xxxxxxxxx xxxxx xxxxxx xx xxx.

-   Xxx x xxxxxxx xxxxxxxxxxx. Xxx xxxxxxx, xx xxx xxxxxx xxxxxxxxxx x xxxx-xxxxx xxxxx xxxx xx xxxxxxxx xxxxx xxxxxxxxxx (xxxx xx xxxxxxxxxxx), xxx x xxxxxxxx xxxxxxxxxxx.
-   Xx xxx xxxxxxx xx xxxx xx xxxx xxxxxx xxxxx, xxxx xx x xxxxx xxx, xxx x xxxxxxxxxx xxxxxxxxxxx.
-   Xxxx xxxxx x xxxxxx xx xxxx xxxx xxx xx xxxxxx xx xxx xxxxxxxxx (xxxxxxxxxxxx xx xxxxxxxxxx), xxx x xxxxxxxxx xxxxxxxxxxx xxx xxx xxxxxx xxxx xxx xxxxxxx xxxxxxxxx. Xxxxxxxxx, xxxxx xxxxx xxxxx xxx xxxxxx xxx xxxxxx xxx xxxxx xxxxxxxxxxxx xxxx xxxx xxx xx xxx xxx xxxx.
-   Xx xxx'xx xxxxx xxx xxxx xxxxx xxxxxxxxxxx xx xxx, xxx xxx xxx xxxx xxxx xxxx xxxx xxxx xxxxxx.

### Xxxxx xxxxxxxxx

Xxx xxxxx xxxxxxxxx xx xxx xxxxxxxxx xxx xxxx xxx xxxxxx xxxx xxx xxxxx xx xxxx xxx xxxxxxx xxxxx xx xxx xxx xxxxx.

-   Xxx xxxxxxxx xxxxxx, xxx xxx xxxxxxx xxxxx xx xxx xxx xx xxx xxxxxx, xxxxxxxxxx xx xxxxxxx xxxxxxxxx. Xxx xxxxxxx, xxx x xxxxxx xxxxxx, xxxxxx xxx xxx xxxxxxx xxxxxx xxxxxxx xx xxx xxx xx xxx xxxxxx. Xxx xxxxx xxxxx xx xxxxxx (xxxx xx xxxx xx xxx xxxx), xxxxxx xxx xxxxxxx xxxxxxxxx xx xxx xxxx.
-   Xxx xxxxxxxxxx xxxxxx, xxx xxx xxxxx xxxxx xx xxx xxxx xxxx xx xxx xxxxxx xxx xxxx-xx-xxxxx xxxx xxxxxx, xxx xx xxx xxxxx xxx xxxxx-xx-xxxx xxxx xxxxxx.
-   Xxx xxx xxxxxxxxx xx xxx xxxxxxxx xxxxxxxxx xx xxx xxxxx xxxx xxxx: xxxxxx xxx xxx xxxxx xxxxx xx xxx xxxx xxxx xx xxx xxxxxx.

### Xxxxx xxx xxxx xxxxx

-   Xxx xxxx xxxxxx xx xxx xxx'x xxxx xxx xxxxxx xx xxxxx xxxxxxxxx xxxxxx xxxxxxx xxx xxx xxx. Xxx xxxxxxx, xx xxx xxx x xxxxxx xx xxxxxxx xxx xxxxxx xx xxxxx xxxxxxx xx xxx, xxx'x xxxxx xxxxxxxx xxxxx xxxxxx. Xxxx xx x xxxx xxxxx xx Y.
-   Xx xxx xxxxxxx xxxxx (xxxx xxxxx xx xxxx xxxxxx), xxxx xxxx xxxx xxx xxxxx xxxx xxxxxx xx xxx xxxxxx'x xxx xxxxx.
-   Xxx xxxx xxxxx xxxx xxx xxxx xx xxxx xxxxx xxx xxxxxxxx xx xxxxx xx xxxxxxxxxxx xxxxxx. Xxx xxxxxxx, x xxxxxx xxxx xxxxxxxx x xxxx xxxxx xxxx xxxx xxxxx xxx YY%, YYY%, xxx YYY%.
-   Xxxx xxxx xxxxx xxxx xxxxx xxxx xx xxxx xxx xxxxxxxxxxx xxxxx xx xxx xxxxxxx.
-   Xxxx xxxx xxxxx xxx x xxxxx xxxxx xxxx xxxxx xxxx xx xxxx xxx xxxxx xxxxx xx xxx xxxxxxx xxxx xxxxxx, xxxxxxx xxxxxxxxxxx xxxx xxx xxxxxxx. Xxxxxxxxx, xxxx xxx xxx xxx xxxxx xxxxxxx xx xxx xxx xxxxx xxxxx.
-   Xxxxxx xxxx xxxx xxxxx xxxx xxxx xxxxxx xxxx'x xxxxxxx. Xxx xxxxxxx, xx xxx xxxxxx xx YYY xxxxxx xxxx xxx xxx YYY xxxx xxxxxx, xxx xxx xxxx xxx xxxx xxxxx xxxxxxx xxxxx xxx'x xxxxxx xxx xxxxxxxx xxxxxxxx. Xxx xx xxxxx xxx xxxx YY xxxx xxxxxx, xxxx xxxx xxxxx.

### Xxxxxx

-   **Xxxxxx xxxxxx**

    Xxx xxxxxx xxxxx xxxxxxxxx xxxx xxx xxxxxx xx xxxx xxx.

    -   Xxx x xxxxx xxxx xx xxxxxx xxxxxxxxxxx (xxxx xx xxx xxxxxxxxxx xxx xxx xxxxxxx xxxxxx).
    -   Xxxxxxxx xxxxxx xxxxx xxx xxxxxx xxxx xxx xxxxxx xx xx x xxxx xxxx xxxxxx xxxx xx xxx xxxxxx xxxxx xxxxx xxxxxxxx.
    -   Xxxxxxxx xxxxxx xx xxx xxxxx xxxx xxx xxxxxx xx xx x xxxx xxxx xxxxxx xxxx xx xxx xxxxxx xx xxx xxxx xx xxxxx xxxxxxxx.
    -   Xxxxx xxxxxxx xxxxxx xxxxx xxx xxxxxx xxxxxxx xxx xxxx'x xxxxxx xxxxx xxxxxxx xxx xxxxx xxxx xxx xxxx xxxxxxx xxx xxxxxx.
-   **Xxxxx xxxxxx**

    Xxx xxxxx, xx xxxx, xxxxxx xxxxxxxx xxx xxxxxx'x xxxxxxx xxx xxxxxxx xxxxxx.

    -   Xxxxx xxx xxx xxxx xx xxx xxxxxx xxxxx, xxxxxx x xxxxxxxx xxxxxxxxxxx xxxxx xxxx xxxxxxxxxxx.
    -   Xxx xxxx xxx xxxx, xx xxxxxxxx, xxx xxxx xxxxx.
    -   Xxx'x xxx xxxxxx xxxxxxxxxxx.
    -   Xxxx xxxx xxxxx xxxxxx xxx xxxxxxxxxxx xxx xxxxxxxx. Xxxxxxxx: Xxxxxxx/Xxxxxxx, Xxxx/Xxxx, Xxx/Xxxx, Xxxx/Xxxx.
-   **Xxxxx xxxxxx**

    X xxxxx xxxxx xxxxxxxx xxx xxxxxxx xxxxx xx xxx xxxxxx.

    -   Xx xxx xxxx x xxxxx xxxxx, xxxxxxx xx xxxxx xxx xxxxxx.
    -   Xxxxxx xxx xxxx xxxxxxxx xx xxx xxxxxxx xxx xxxxxxx xxx xxxxx (xxxx xx xxxxxx).
    -   Xxxxx xxx xxxxxx’x xxxxx xx xxxxxxx xxxxxx xxxxxxxxx, xxxxxxxx xxxxxxx xxx xxxxxxx xxxxx xxxx xxxxx xxx, xxxx x xxxxx xx xxxxx xxxxxx. X xxxxxx xxxxxxx xxxx xxxx xxxxx xxxxxx xxxx xxxxxx xxxx xx xxx xxxxx xxxx xxxxxx xxx xxxxxx.

### Xxxxxxxxxx xxx xxxxxxxxxxx

X xxxxxx xx xxxxxxxx xx x xxxxx xxx x xxxxx. Xxx xxxxx xx x xxx (xxxxx xxx xxxxxxxxxx xxxx xxxxxxx xxxxxx xx xxxx xxxxx) xxxxxxxxxxxx xxx xxxxx xx xxxxxx xxxx xxx xx xxxxx. Xxx xxxxx xx x xxxxxxxx, xxxxx xxx xxxx xxx xxxxxxxx xx xxxxxx xxxxxxx xxx xxxxx xx xx xxxxxxxxx xxxx xxx xxxxx xx xx.

X xxxxxx xxx x xxxxx xxxxx xxxxxx. Xx xxxxxxxx xxxxx xxxxxxxxxxxxx, x xxxxxx xxxxxx xx xxxxxxxxxx xxx xxxxxx xxxx xxxx xxx xxxx xx xxx xxxxxxx.

Xxxx xxx’xx xxxxxxxxx x xxxxxx xxxxxx, xxxxxxxx xxxx xx xxxxxxx xxx xxx xxxxxxxxx xxxx xx xxx xxxx xxxx xx xxxxxx xxxxxxx xx xxxxxxxx. Xxx x xxxxx xxxxx xx x xxxx xxxxx xx xxxx xxx xxxxx xx xxxxx xx xxxxxxxxxx xxx xxxxxxx; xxxx xxxxxxxx xxxx xx xxxxxxxxx xxxxx xxxxxx xxxxxxxxxxx. X xxxxxx xxxx xxxxxxxx xxxxxx, xxx xxxxxxx, xxxxx xxxxxxx x xxxxxxx xxxxxxx xxxxxxx xxxxx xxxxx xx xxx xxxxxxx xxx xx xxx xxxxxx, xxx x xxxxxxx xxxxxxx xxxx xxxxx xxxxx xx xxx xxxxxxx xxx.

## Xxxxxxx xxxxxx

**Xxx xxxxxxxxx**
* [Xxxxxxxxxx xxx xxxxxx xxxxxxxx](toggles.md)
**Xxx xxxxxxxxxx (XXXX)**
* [**Xxxxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/br209614)
<!--HONumber=Mar16_HO1-->
