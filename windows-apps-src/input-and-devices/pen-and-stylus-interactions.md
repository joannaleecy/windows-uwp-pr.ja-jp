---
Xxxxxxxxxxx: Xxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxxx xxxxxxx xxxxxx xxxxxxxxxxxx xxxx xxx xxx xxxxxx xxxxxxx, xxxxxxxxx xxxxxxx xxx xxx xxxxxxx xxxxxxx xxx xxxxxxx xxxxxxxxxxx.
xxxxx: Xxx xxx xxxxxx xxxxxxxxxxxx
xx.xxxxxxx: YXXYXYXY-YYYY-YYXY-YXXY-YXYYXXXYYXYY
xxxxx: Xxx xxx xxxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxx xxx xxxxxx xxxxxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxxxxxx xxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxx xxx xxxxx xxxxx xxx xxx xxxxx xxx xxxxxxx xx xxxxxxx.

Xxx XXX xxx xxx xxxxxxxx, xxxxxxxx xxxx x xxx xxxxxx, xxxxxxxx x xxxxxxx xxx xx xxxxxx xxxxxxxxxxx xxxxx, xxxxxxxx, xxx xxxxxxxxxxx. Xxx xxxxxxxx xxxxxxxx xxxxxxxxx xxx xxxx xxxx xxxxxxxxx xxxxx, xxxxxxxxxx xxx xxxx, xxxxxxxxx xxxx xxxx xx xxx xxxxxxx xx xxx xxxxxx xxxxxx, xxxxxxxx xxx xxx xxxx, xxx xxxxxxxxxx xxxxxxxxxxx xxxxxxxxxxx.

![xxxxxxxx](images/input-patterns/input-pen.jpg)


**Xxxxxxxxx XXXx**

-   [**Xxxxxxx.Xxxxxxx.Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225648)
-   [**Xxxxxxx.XX.Xxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208524)
-   [**Xxxxxxx.XX.Xxxxx.Xxxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn958452)


Xx xxxxxxxx xx xxxxxxx xx x [**xxxxxxx xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225633) (xxxxxxx xx xxxxx xxx xxxxx), x xxx/xxxxxx xx xxxxxxxxx xxxxxxxxxx xxxx xxxxxxx xx xxxxxxx xxxxxxxx xx x xxxxxx xxxxx xxxxxxx xxx.

Xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxxx, xxxxxxxx xxxx x xxx/xxxxxx xxxxxx, xxxxxxxx x xxxxxxx xxx xx xxxxxx xxxxxxx xxxxxxxxxxx xxxxx, xxxxxxxx, xxx xxxxxxxxxxx. Xxx xxxxxxxx xxxxxxxx xxxxxxxxx xxxxxxxxx xxxxx xx xxx xxxx, xxxxxxxxxx xxx xxxx, xxxxxxxx xxx xxxx, xxxxxxxxx xxx xxxx xx xxxxxxx, xxx xxxxxxxxxx xxx xx xxxx xxxxxxx xxxxxxxxxxx xxxxxxxxxxx.

Xx xxxxxxxx xx xxxxxxxxx xxx xxxxx xxxxxxxx xxx xxxxxxxx xx xxx xxx xx xxx xxxx xxxxxx xx xxxxx, xxxx xxx xxx xxxx xxxxx xxx xxxxxxx xxx xxxxxxx xxxxxxx xx xxxxxxxx xxxx xxxxxxxxxx x xxxxxx. Xxxx xxxxxxxxxxx, xxxxx xxxx xxxxxxxx xxx xxx xxx xxxxx, xxxx, xxx xxxxxxxx, xxx xxxxx, xxx xxxxxxx (xxxxx xxx, xxxxxxx, xxxxxxxxxxxx, xxx xxxxxxxxx), xxxxxxx xxx xx xxxxxxx xxxx xxxxxxxxxxx xxxx xxxxxxx xxxxxxxx xxxxxxx xx xxxxxxx xx xxxxx xxxx x xxx, xxxxxx, xx xxxxx.

**Xxxx**  Xxxx xxx xxx xxxx xxxxxxx xxx xxxxx xxxx xxxxx xxxxxxx-xxxxx xxxxxxx, xxxxxxxxx xxxxx xxxxxxxxxx xxx xxxxx xxxxxxx.

 

Xxx xxx xxxxxxxx xx xxxx xxxxxxxx. Xx xx xxxxxxxx xx xxxxxxx xxxxxxx xxxxxx xx xxxxxxxxxxxxx, xxxxxxxxx xx xxxx xxxxxxxxxxxx.

Xxxxx xxx xxxxx xxxxxxxxxx xx xxx xxx xxxxxxxx:

-   [
            **XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) - X XXXX XX xxxxxxxx xxxxxxx xxxx, xx xxxxxxx, xxxxxxxx xxx xxxxxxxx xxx xxxxx xxxx x xxx xx xxxxxx xx xxx xxxxxx xx xx xxxxx xxxxxx.

-   [
            **XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922011) - X xxxx-xxxxxx xxxxxx, xxxxxxxxxxxx xxxxx xxxx xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx (xxxxxxx xxxxxxx xxx [**XxxXxxxxx.XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxxxxxxx). Xxxx xxxxxx xxxxxxxx xxx xxxxxxx xxxxxx xxxxxxxxxxxxx xxxxxxx xx xxx **XxxXxxxxx**, xxxxx xxxx x xxxxxxxxxxxxx xxx xx XXXx xxx xxxxxxxxxx xxxxxxxxxxxxx xxx xxxxxxxxxxxxxxx.

-   [
            **XXxxXYXXxxxxxxx**](https://msdn.microsoft.com/library/mt147263) - Xxxxxxx xxx xxxxxxxxx xx xxx xxxxxxx xxxx xxx xxxxxxxxxx XxxxxxYX xxxxxx xxxxxxx xx x Xxxxxxxxx Xxxxxxx xxx, xxxxxxx xx xxx xxxxxxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx. Xxxx xxxxxxx xxxx xxxxxxxxxxxxx xx xxx xxxxxx xxxxxxxxxx.

## <span id="inkcanvas">
            </span>
            <span id="INKCANVAS">
            </span>Xxxxx xxxxxx xxxx XxxXxxxxx


Xxx xxxxx xxxxxx xxxxxxxxxxxxx, xxxx xxxxx xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxxx xx x xxxx.

Xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxxx xxx xxxxx xxxx xxxx x xxx. Xxx xxxxx xx xxxxxx xxxxxxxx xx xx xxx xxxxxx xxxxx xxxxxxx xxxxxxxx xxx xxxxx xxx xxxxxxxxx, xx xxxxxxx xx x xxxxxx xxxxxx (xxxx xxxxx xx xxxx xx xxxxxx xxx xx xxx xxx xxx xxxxxxxx xxxx xx xxxxx xxxxxx).

Xx xxxx xxxxxxx, xx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxxx x xxxxxxxxxx xxxxx.

```XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header" 
                   Text="Basic ink sample" 
                   Style="{ThemeResource HeaderTextBlockStyle}" 
                   Margin="10,0,0,0" />            
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

Xxxx xxxxxx xx xxxxxx xxxxx xxx xxx xxxxx xx xxxxxxxx xx xxxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx.

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left"><img src="images/ink_basic_1_small.png" alt="The blank InkCanvas with a background image" /></td>
<td align="left"><img src="images/ink_basic_2_small.png" alt="The InkCanvas with ink strokes" /></td>
<td align="left"><img src="images/ink_basic_3_small.png" alt="The InkCanvas with one stroke erased" /></td>
</tr>
<tr class="even">
<td align="left">Xxx xxxxx [<strong>XxxXxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY) xxxx x xxxxxxxxxx xxxxx.</td>
<td align="left">Xxx [<strong>XxxXxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY) xxxx xxx xxxxxxx.</td>
<td align="left">Xxx [<strong>XxxXxxxxx</strong>](xxxxx://xxxx.xxxxxxxxx.xxx/xxxxxxx/xxxxxxx/xxxx/xxYYYYYY) xxxx xxx xxxxxx xxxxxx.
<p>Xxxx xxx xxxxx xxxxxxxx xx xx xxxxxx xxxxxx, xxx x xxxxxxx.</p></td>
</tr>
</tbody>
</table>

 

Xxx xxxxxx xxxxxxxxxxxxx xxxxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx xx xxxxxxxx xx x xxxx-xxxxxx xxxxxx xxxxxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922011).

Xxx xxxxx xxxxxx, xxx xxx'x xxxx xx xxxxxxx xxxxxxxx xxxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922011). Xxxxxxx, xx xxxxxxxxx xxx xxxxxxxxx xxxxxx xxxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535), xxx xxxx xxxxxx xxx xxxxxxxxxxxxx **XxxXxxxxxxxx** xxxxxx.

## <span id="inkpresenter">
            </span>
            <span id="INKPRESENTER">
            </span>Xxxxx xxxxxxxxxxxxx xxxx XxxXxxxxxxxx


Xx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922011) xxxxxx xx xxxxxxxxxxxx xxxx xxxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx.

Xxxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxx xxxxxxxxx xx xxx xxxxxxxxxxxxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx, xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922011) xxxxxxxx x xxxxxxxxxxxxx xxx xx XXXx xxx xxxxxxxxxx xxxxxx xxxxxxxxxxxxx. Xxxx xxxxxxxx xxxxxx xxxxxxxxxx, xxxxxxxxx xxxxx xxxxxx xxxxx, xxx xxxxxxx xxxxx xx xxxxxxxxx xx xxx xxxxxx xx xxxxxx xx xxx xxx.

**Xxxx**  
Xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922011) xxxxxx xx xxxxxxxxxxxx xxxxxxxx. Xxxxxxx, xx xx xxxxxxxx xxxxxxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535).

 

Xxxx, xx xxxxxxxxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx. Xx xxxx xxx xxxx xxxxxxx xxx xxxxxx xxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535).

```CSharp
public MainPage()
{
    this.InitializeComponent();

    // Set supported inking device types.
    inkCanvas.InkPresenter.InputDeviceTypes = 
        Windows.UI.Core.CoreInputDeviceTypes.Mouse | 
        Windows.UI.Core.CoreInputDeviceTypes.Pen;

    // Set initial ink stroke attributes.
    InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
    drawingAttributes.Color = Windows.UI.Colors.Black;
    drawingAttributes.IgnorePressure = false;
    drawingAttributes.FitToCurve = true;
    inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
}
```

Xxx xxxxxx xxxxxxxxxx xxx xx xxx xxxxxxxxxxx xx xxxxxxxxxxx xxxx xxxxxxxxxxx xx xxx xxxxxxxxxxxx.

Xxxx, xx xxx x xxxx xxxxxx xxxx x xxxx xx xxx xxxxxx.

```XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <Grid.RowDefinitions>
        <RowDefinition Height="Auto"/>
        <RowDefinition Height="*"/>
    </Grid.RowDefinitions>
    <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
        <TextBlock x:Name="Header" 
                   Text="Basic ink customization sample" 
                   VerticalAlignment="Center"
                   Style="{ThemeResource HeaderTextBlockStyle}" 
                   Margin="10,0,0,0" />
        <TextBlock Text="Color:"
                   Style="{StaticResource SubheaderTextBlockStyle}"
                   VerticalAlignment="Center"
                   Margin="50,0,10,0"/>
        <ComboBox x:Name="PenColor"
                  VerticalAlignment="Center"
                  SelectedIndex="0"
                  SelectionChanged="OnPenColorChanged">
            <ComboBoxItem Content="Black"/>
            <ComboBoxItem Content="Red"/>
        </ComboBox>
    </StackPanel>
    <Grid Grid.Row="1">
        <Image Source="Assets\StoreLogo.png" />
        <InkCanvas x:Name="inkCanvas" />
    </Grid>
</Grid>
```

Xx xxxx xxxxxx xxxxxxx xx xxx xxxxxxxx xxxxx xxx xxxxxx xxx xxx xxxxxx xxxxxxxxxx xxxxxxxxxxx.

```CSharp
// Update ink stroke color for new strokes.
private void OnPenColorChanged(object sender, SelectionChangedEventArgs e)
{
    if (inkCanvas != null)
    {
        InkDrawingAttributes drawingAttributes = 
            inkCanvas.InkPresenter.CopyDefaultDrawingAttributes();

        string value = ((ComboBoxItem)PenColor.SelectedItem).Content.ToString();

        switch (value)
        {
            case "Black":
                drawingAttributes.Color = Windows.UI.Colors.Black;
                break;
            case "Red":
                drawingAttributes.Color = Windows.UI.Colors.Red;
                break;
            default:
                drawingAttributes.Color = Windows.UI.Colors.Black;
                break;
        };

        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);
    }
}
```

Xxxxx xxxxxx xxxxx xxx xxx xxxxx xx xxxxxxxxx xxx xxxxxxxxxx xx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081).

|                                                                                      |                                                                                          |
|--------------------------------------------------------------------------------------|------------------------------------------------------------------------------------------|
| ![xxx xxxxxxxxx xxxx xxxxxxx xxxxx xxx xxxxxxx](images/ink-basic-custom-1-small.png) | ![xxx xxxxxxxxx xxxx xxxx xxxxxxxx xxx xxx xxxxxxx](images/ink-basic-custom-2-small.png) |
| Xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxx xxxxxxx xxxxx xxx xxxxxxx.        | Xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxx xxxx xxxxxxxx xxx xxx xxxxxxx.        |

 

Xx xxxxxxx xxxxxxxxxxxxx xxxxxx xxxxxx xxx xxxxxxx, xxxx xx xxxxxx xxxxxxxxx, xxxx xxx xxxx xxxxxxxx xxxxxxxx xxxxx xxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxx xxxxxxx xxxxxxxxxxx xxx xxxxxxxx xx xxxx xxx.

## <span id="passthrough">
            </span>
            <span id="PASSTHROUGH">
            </span>Xxxx-xxxxxxx xxxxx xxx xxxxxxxx xxxxxxxxxx


Xx xxxxxxx, [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxxxxxxxx xxx xxxxx xx xxxxxx xx xxx xxxxxx xx xx xxxxx xxxxxx. Xxxx xxxxxxxx xxxxx xxxxxxxx xx x xxxxxxxxx xxxxxxxx xxxxxxxxxx xxxx xx x xxx xxxxxx xxxxxx, x xxxxx xxxxx xxxxxx, xx xxxxxxx.

Xxxx xxxxx xxxxx xxxxxxxxx xxxxxxxxxxx, xxxxx xxxxxxxxx xxxxxx xxxx xxxxxxxxxx xxxxxxxxxxxxx xx x xxxxxxxx xxxxxxxx.

Xx xxxx xxxxx, xxx xxxxx xxxx xx xxxxxx xxxxx xxx xxxxxxxxxxxxx xxx xxxx xxxxxxx xxxxxxxxx xxxxxxxxxxx (xxxxxxxxxxxxx xxx xxxxxxx xxxxxxxxxx xxxx xxx xxx xxx), xxxxx xxxxx xxxxxx xxxxx, xx xxxxxxxxxx xxxxxxxxxxxxx, xx xxxxxxxx xxxxxxxx, xxxxx xx x xxxx xxxxxxxxx xx xxxx xxx'x XX.

Xx xxxxxxx xxxx, [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xxx xx xxxxxxxxxx xx xxxxx xxxxxxxx xxxxx xxxxxxxxxxx. Xxxx xxxxxxxxxxx xxxxx xx xxxx xxxxxx xxxxxxx xx xxxx xxx xxx xxxxxxxxxx.

Xxx xxxxxxxxx xxxx xxxxxxx xxxxx xxxxxxx xxx xx xxxxxx xxxxxx xxxxxxxxx xxxx xxxxx xx xxxxxxxx xxxx x xxx xxxxxx xxxxxx (xx xxxxx xxxxx xxxxxx).

Xxx xxxx xxxxxxx, xx xxx xxx XxxxXxxx.xxxx xxx XxxxXxxx.xxxx.xx xxxxx xx xxxx xxx xxxx.

1.  Xxxxx, xx xxx xx xxx XX xx XxxxXxxx.xxxx.

    Xxxx, xx xxx x xxxxxx (xxxxx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535)) xx xxxx xxx xxxxxxxxx xxxxxx. Xxxxx x xxxxxxxx xxxxx xx xxxx xxx xxxxxxxxx xxxxxx xxxxxx xxx **XxxXxxxxx** xxx xxx xxxxxxx xxxxxxxxx.

    ![xxx xxxxx xxxxxxxxx xxxx xx xxxxxxxxxx xxxxxxxxx xxxxxx](images/ink-unprocessed-1-small.png)

```    XAML
<Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto"/>
            <RowDefinition Height="*"/>
        </Grid.RowDefinitions>
        <StackPanel x:Name="HeaderPanel" Orientation="Horizontal" Grid.Row="0">
            <TextBlock x:Name="Header" 
                       Text="Advanced ink customization sample" 
                       VerticalAlignment="Center"
                       Style="{ThemeResource HeaderTextBlockStyle}" 
                       Margin="10,0,0,0" />
        </StackPanel>
        <Grid Grid.Row="1">
            <!-- Canvas for displaying selection UI. -->
            <Canvas x:Name="selectionCanvas"/>
            <!-- Inking area -->
            <InkCanvas x:Name="inkCanvas"/>
        </Grid>
    </Grid>
```

2.  Xx XxxxXxxx.xxxx.xx, xx xxxxxxx x xxxxxx xx xxxxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxxx xx xxxxxxx xx xxx xxxxxxxxx XX. Xxxxxxxxxxxx, xxx xxxxxxxxx xxxxx xxxxxx xxx xxx xxxxxxxx xxxxxxxxx xxxx xxxxxxxxxx xxx xxxxxxxx xxxxxxx.

```    CSharp
// Stroke selection tool.
    private Polyline lasso;
    // Stroke selection area.
    private Rect boundingRect;
```

3.  Xxxx, xx xxxxxxxxx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxxx xxxxx xxxx xxxx xxxx xxx xxx xxxxx xx xxx xxxxxxx, xxx xxx xxxx xxxxxxx xxx xxxxxx xxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxx xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535).

    Xxxx xxxxxxxxxxx, xx xxx xxx [**XxxxxXxxxxxxxxxXxxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn948764) xxxxxxxx xx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081) xx xxxxxxxx xxxx xxx xxxxxxxx xxxxx xxxxxx xx xxxxxxxxx xx xxx xxx. Xxxxxxxx xxxxx xx xxxxxxxxx xx xxxxxxxxx **XxxxxXxxxxxxxxxXxxxxxxxxxxxx.XxxxxXxxxXxxxxx** x xxxxx xx [**XxxXxxxxXxxxxXxxxXxxxxx.XxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn948760).

    Xx xxxx xxxxxx xxxxxxxxx xxx xxx xxxxxxxxxxx [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914712), [**XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914711), xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914713) xxxxxx xxxxxx xxxxxxx xx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081). Xxx xxxxxxxxx xxxxxxxxxxxxx xx xxxxxxxxxxx xx xxx xxxxxxxx xxx xxxxx xxxxxx.

    Xxxxxxx, xx xxxxxx xxxxxxxxx xxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914702) xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn948767) xxxxxx xx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081). Xx xxx xxx xxxxxxxx xxx xxxxx xxxxxx xx xxxxx xx xxx xxxxxxxxx XX xx x xxx xxxxxx xx xxxxxxx xx xx xxxxxxxx xxxxxx xx xxxxxx.

    ![xxx xxxxxxxxx xxxx xxxxxxx xxxxx xxx xxxxxxx](images/ink-unprocessed-2-small.png)

```    CSharp
public MainPage()
    {
        this.InitializeComponent();

        // Set supported inking device types.
        inkCanvas.InkPresenter.InputDeviceTypes =
            Windows.UI.Core.CoreInputDeviceTypes.Mouse |
            Windows.UI.Core.CoreInputDeviceTypes.Pen;

        // Set initial ink stroke attributes.
        InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
        drawingAttributes.Color = Windows.UI.Colors.Black;
        drawingAttributes.IgnorePressure = false;
        drawingAttributes.FitToCurve = true;
        inkCanvas.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

        // By default, the InkPresenter processes input modified by 
        // a secondary affordance (pen barrel button, right mouse 
        // button, or similar) as ink.
        // To pass through modified input to the app for custom processing 
        // on the app UI thread instead of the background ink thread, set 
        // InputProcessingConfiguration.RightDragAction to LeaveUnprocessed.
        inkCanvas.InkPresenter.InputProcessingConfiguration.RightDragAction = 
            InkInputRightDragAction.LeaveUnprocessed;

        // Listen for unprocessed pointer events from modified input.
        // The input is used to provide selection functionality.
        inkCanvas.InkPresenter.UnprocessedInput.PointerPressed += 
            UnprocessedInput_PointerPressed;
        inkCanvas.InkPresenter.UnprocessedInput.PointerMoved += 
            UnprocessedInput_PointerMoved;
        inkCanvas.InkPresenter.UnprocessedInput.PointerReleased += 
            UnprocessedInput_PointerReleased;

        // Listen for new ink or erase strokes to clean up selection UI.
        inkCanvas.InkPresenter.StrokeInput.StrokeStarted += 
            StrokeInput_StrokeStarted;
        inkCanvas.InkPresenter.StrokesErased += 
            InkPresenter_StrokesErased;
    }
```

4.  Xx xxxx xxxxxx xxxxxxxx xxx xxx xxxxxxxxxxx [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914712), [**XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914711), xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914713) xxxxxx xxxxxx xxxxxxx xx xxx [**XxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn899081).

    Xxx xxxxxxxxx xxxxxxxxxxxxx xx xxxxxxxxxxx xx xxxxx xxxxxxxx, xxxxxxxxx xxx xxxxx xxxxxx xxx xxx xxxxxxxx xxxxxxxxx.

    ![xxx xxxxxxxxx xxxxx](images/ink-unprocessed-3-small.png)

```    CSharp
// Handle unprocessed pointer events from modifed input.
    // The input is used to provide selection functionality.
    // Selection UI is drawn on a canvas under the InkCanvas.
    private void UnprocessedInput_PointerPressed(
        InkUnprocessedInput sender, PointerEventArgs args)
    {
        // Initialize a selection lasso.
        lasso = new Polyline()
        {
            Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
            StrokeThickness = 1,
            StrokeDashArray = new DoubleCollection() { 5, 2 },
        };

        lasso.Points.Add(args.CurrentPoint.RawPosition);

        selectionCanvas.Children.Add(lasso);
    }

    private void UnprocessedInput_PointerMoved(
        InkUnprocessedInput sender, PointerEventArgs args)
    {
        // Add a point to the lasso Polyline object.
        lasso.Points.Add(args.CurrentPoint.RawPosition);
    }

    private void UnprocessedInput_PointerReleased(
        InkUnprocessedInput sender, PointerEventArgs args)
    {
        // Add the final point to the Polyline object and 
        // select strokes within the lasso area.
        // Draw a bounding box on the selection canvas 
        // around the selected ink strokes.
        lasso.Points.Add(args.CurrentPoint.RawPosition);

        boundingRect = 
            inkCanvas.InkPresenter.StrokeContainer.SelectWithPolyLine(
                lasso.Points);

        DrawBoundingRect();
    }
```

5.  Xx xxxxxxxx xxx XxxxxxxXxxxxxxx xxxxx xxxxxxx, xx xxxxx xxx xxxxxxxxx xxxxx xx xxx xxxxxxx (xxx xxxxx xxxxxx) xxx xxxx xxxx x xxxxxx xxxxxxxx xxxxxxxxx xxxxxx xxx xxx xxxxxxx xxxxxxxxxxx xx xxx xxxxx xxxx.

    ![xxx xxxxxxxxx xxxxxxxx xxxx](images/ink-unprocessed-4-small.png)

```    CSharp
// Draw a bounding rectangle, on the selection canvas, encompassing 
    // all ink strokes within the lasso area.
    private void DrawBoundingRect()
    {
        // Clear all existing content from the selection canvas.
        selectionCanvas.Children.Clear();

        // Draw a bounding rectangle only if there are ink strokes 
        // within the lasso area.
        if (!((boundingRect.Width == 0) || 
            (boundingRect.Height == 0) || 
            boundingRect.IsEmpty))
        {
            var rectangle = new Rectangle()
            {
                Stroke = new SolidColorBrush(Windows.UI.Colors.Blue),
                StrokeThickness = 1,
                StrokeDashArray = new DoubleCollection() { 5, 2 },
                Width = boundingRect.Width,
                Height = boundingRect.Height
            };

            Canvas.SetLeft(rectangle, boundingRect.X);
            Canvas.SetTop(rectangle, boundingRect.Y);

            selectionCanvas.Children.Add(rectangle);
        }
    }
```

6.  Xxxxxxx, xx xxxxxx xxxxxxxx xxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn914702) xxx [**XxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn948767) XxxXxxxxxxxx xxxxxx.

    Xxxxx xxxx xxxx xxxx xxx xxxx xxxxxxx xxxxxxxx xx xxxxx xxx xxxxxxx xxxxxxxxx xxxxxxxx x xxx xxxxxx xx xxxxxxxx.

```    CSharp
// Handle new ink or erase strokes to clean up selection UI.
    private void StrokeInput_StrokeStarted(
        InkStrokeInput sender, Windows.UI.Core.PointerEventArgs args)
    {
        ClearSelection();
    }

    private void InkPresenter_StrokesErased(
        InkPresenter sender, InkStrokesErasedEventArgs args)
    {
        ClearSelection();
    }
```

7.  Xxxx'x xxx xxxxxxxx xx xxxxxx xxx xxxxxxxxx XX xxxx xxx xxxxxxxxx xxxxxx xxxx x xxx xxxxxx xx xxxxxxx xx xx xxxxxxxx xxxxxx xx xxxxxx.

```    CSharp
// Clean up selection UI.
    private void ClearSelection()
    {
        var strokes = inkCanvas.InkPresenter.StrokeContainer.GetStrokes();
        foreach (var stroke in strokes)
        {
            stroke.Selected = false;
        }
        ClearDrawnBoundingRect();
    }

    private void ClearDrawnBoundingRect()
    {
        if (selectionCanvas.Children.Any())
        {
            selectionCanvas.Children.Clear();
            boundingRect = Rect.Empty;
        }
    }
```

## <span id="iinkd2drenderer">
            </span>
            <span id="IINKD2DRENDERER">
            </span>Xxxxxx xxx xxxxxxxxx


Xx xxxxxxx, xxx xxxxx xx xxxxxxxxx xx x xxx-xxxxxxx xxxxxxxxxx xxxxxx xxx xxxxxxxx "xxx" xx xx xx xxxxx. Xxxx xxx xxxxxx xx xxxxxxxxx (xxx xx xxxxxx xxxxxx, xx xxxxx xxxxxx xxxxxxxx), xxx xxxxxx xx xxxxxxxxx xx xxx XX xxxxxx xxx xxxxxxxx "xxx" xx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxx (xxxxx xxx xxxxxxxxxxx xxxxxxx xxx xxxxxxxxx xxx xxx xxx).

Xxx xxx xxxxxxxx xxxxxxx xxx xx xxxxxxxx xxxx xxxxxxxx xxx xxxxxxxxxx xxxxxxxxx xxx xxxxxx xxxxxxxxxx xx xxxxxx xxxxxx xxx xxx xxxxx.

Xxxxxx xxxxxx xxxxxxxx xx [**XXxxXYXXxxxxxxx**](https://msdn.microsoft.com/library/mt147263) xxxxxx xx xxxxxx xxx xxx xxxxx xxx xxxxxx xx xx xxx XxxxxxYX xxxxxx xxxxxxx xx xxxx Xxxxxxxxx Xxxxxxx xxx, xxxxxxx xx xxx xxxxxxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xxxxxxx.

Xx xxxxxxx [**XxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn922012) (xxxxxx xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn858535) xx xxxxxx), xx xxx xxxxxxx xx [**XxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn903979) xxxxxx xx xxxxxxxxx xxx xx xxx xxxxxx xx xxxxxxxx xxx xx x [**XxxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh702041) xx [**XxxxxxxXxxxxxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh702050). Xxx xxxxxxx, xx xxx xxxxxx xxxxx xx xxxxxxxxxx xxx xxxxxxxxxx xxxx xxxxxxxxxxx xxxxxxx xxxxxxx xx xx x xxxxxxxx **XxxXxxxxx** xxxxx.

Xxx x xxxx xxxxxxx xx xxxx xxxxxxxxxxxxx, xxx xxx [Xxxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620314) .


## Xxxxx xxxxxxxx xx xxxx xxxxxxx 
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">Xxxxx</th>
<th align="left">Xxxxxxxxxxx</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[Recognize ink strokes](convert-ink-to-text.md)</p></td>
<td align="left"><p>Xxxxxxx xxx xxxxxxx xx xxxx xxxxx xxxxxxxxxxx xxxxxxxxxxx, xx xx xxxxxx xxxxx xxxxxx xxxxxxxxxxx.</p></td>
</tr>
<tr class="even">
<td align="left"><p>[Store and retrieve ink strokes](save-and-load-ink.md)</p></td>
<td align="left"><p>Xxxxx xxx xxxxxx xxxx xx x Xxxxxxxx Xxxxxxxxxxx Xxxxxx (XXX) xxxx xxxxx xxxxxxxx Xxx Xxxxxxxxxx Xxxxxx (XXX) xxxxxxxx.</p></td>
</tr>
</tbody>
</table>

 


## <span id="related_topics">
            </span>Xxxxxxx xxxxxxxx


* [Xxxxxx xxxxxxx xxxxx](handle-pointer-input.md)
* [Xxxxxxxx xxxxx xxxxxxx](identify-input-devices.md)
**Xxxxxxx**
* [Xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620308)
* [Xxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620312)
* [Xxxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620314)
* [Xxxxx xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620302)
* [Xxx xxxxxxx xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=620304)
* [Xxxx xxxxxxxxxxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619894)
* [Xxxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=619895)
**Xxxxxxx Xxxxxxx**
* [Xxxxx: Xxxxxx xxxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=231530)
* [Xxxxx: XXXX xxxx xxxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=226855)
* [XXXX xxxxxxxxx, xxxxxxx, xxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=251717)
* [Xxxxx: Xxxxxxxx xxx xxxxxxxxxxxxx xxxx XxxxxxxXxxxxxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=231605)
 

 




<!--HONumber=Mar16_HO1-->
