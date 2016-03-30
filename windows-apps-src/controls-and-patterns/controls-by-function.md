---
Xxxxxxxxxxx: Xxxxxxxx x xxxx xx xxxxxxxx xx xxxx xx xxx xxxxxxxx xxxx xxx xxx xxx xx xxxx xxxx.
xxxxx: Xxxxxxxx xx xxxxxxxx
xx.xxxxxxx: YXXYYYYX-YYXY-YYYY-YYXY-YYXXXYXXXYYY
xxxxx: Xxxxxxxx xx xxxxxxxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxxxxxx xx xxxxxxxx

Xxx XXXX XX xxxxxxxxx xxx Xxxxxxx xxxxxxxx xx xxxxxxxxx xxxxxxx xx xxxxxxxx xxxx xxxxxxx XX xxxxxxxxxxx. Xxxx xx xxxxx xxxxxxxx xxxx x xxxxxx xxxxxxxxxxxxxx; xxxxxx xxxxxxxx xx xxx xxxxxxxxxx xxx xxxxx xxxxxxxx xx xxxxxxx, xxxx xx xxxxxx xxx xxxxx. 

Xxx xxx xxx xxxx xx xxx Xxxxxxx XX xxxxxxxx xx xxxxxx xx xxxxxxxxxxx xxx [**XXXX XX Xxxxxx xxxxxx**](http://go.microsoft.com/fwlink/p/?LinkId=619992). 

Xxxx'x x xxxx xx xxxxxxxx xx xxx xxxxxx XXXX xxxxxxxx xxx xxx xxx xx xxxx xxx. 

## Xxxxxxx xxx xxxxxxxx

### Xxx xxx
X xxxxxxx xxx xxxxxxxxxx xxxxxxxxxxx-xxxxxxxx xxxxxxxx. Xxx Xxxxxxx xxx.

Xxxxxxxxx: [XxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbar.aspx) 

### Xxx xxx xxxxxx
X xxxxxx xxx xxxxxxx xxxxxxxx xxxxx xxx xxx xxxxxxx.

*Xxx xxx xxxxxx xxxxx* 

Xxxxxxxxx: [XxxXxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarbutton.aspx), [XxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.symbolicon.aspx), [XxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.bitmapicon.aspx), [XxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.fonticon.aspx), [XxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pathicon.aspx) 

Xxxxxx xxx xxx-xx: [Xxx xxx xxx xxxxxxx xxx xxxxxxx xxxxx](app-bars.md) 

Xxxxxx xxxx: [XXXX Xxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620019)

### Xxx xxx xxxxxxxxx
Xxxxxxxx xxxxxxxxx xxxxxx xx xxxxxxxx xx x xxxxxxx xxx.

Xxxxxxxxx: [XxxXxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbarseparator.aspx) 

Xxxxxx xxxx: [XXXX Xxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620019)

### Xxx xxx xxxxxx xxxxxx
X xxxxxx xxx xxxxxxxx xxxxxxxx xx x xxxxxxx xxx.

Xxxxxxxxx: [XxxXxxXxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.appbartogglebutton.aspx) 

Xxxxxx xxxx: [XXXX Xxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620019)

### Xxxxxxx xxx
X xxxxxxxxxxx xxx xxx xxxx xxxxxxx xxx xxxxxxxx xx xxx xxx xxxxxx xxxxxxxx.

*Xxxxxxx xxx xxxxxxx* 

```xaml
<CommandBar>
    <AppBarButton Icon="Back" Label="Back" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Stop" Label="Stop" Click="AppBarButton_Click"/>
    <AppBarButton Icon="Play" Label="Play" Click="AppBarButton_Click"/>
</CommandBar>
```
Xxxxxxxxx: [XxxxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.commandbar.aspx) 

Xxxxxx xxx xxx-xx: [Xxx xxx xxx xxxxxxx xxx xxxxxxx xxxxx](app-bars.md)

Xxxxxx xxxx: [XXXX Xxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620019)

## Xxxxxxx

### Xxxxxx
X xxxxxxx xxxx xxxxxxxx xx xxxx xxxxx xxx xxxxxx x **Xxxxx** xxxxx.
 
*X xxxxxxxx xxxxxx xxx x xxxxxx xxxxxx* 

```xaml
<Button x:Name="button1" Content="Button" 
        Click="Button_Click" />
```

Xxxxxxxxx: [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxx xxxxxxx xxxxx](buttons.md) 

### Xxxxxxxxx
Xxx Xxxxxxxxx xxxxxx.

### Xxxxxxxxx xxxxxx
X xxxxxx xxxx xxxxxxx xx xxxxxx xx xxxx, xxxxxxxxx xxxx xxxxxx xxxxxx xxxx xxxxxx.

*Xxxxxxxxx xxxxxx* 

```xaml
<HyperlinkButton Content="www.microsoft.com" NavigateUri="http://www.microsoft.com"/>
```

Xxxxxxxxx: [XxxxxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hyperlinkbutton.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxxxxx xxxxxxx xxxxx](hyperlinks.md)

### Xxxxxx xxxxxx
X xxxxxx xxxx xxxxxx xxx **Xxxxx** xxxxx xxxxxxxxxx xxxx xxx xxxx xx'x xxxxxxx xxxxx xx'x xxxxxxxx. 

*X xxxxxx xxxxxx xxxxxxx* 

```xaml
<RepeatButton x:Name="repeatButton1" Content="Repeat Button" 
              Click="RepeatButton_Click" />
```

Xxxxxxxxx: [XxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.repeatbutton.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxx xxxxxxx xxxxx](buttons.md) 

## Xxxxxxxxxx/xxxx xxxxxxxx

### Xxxx xxxx
X xxxxxxx xxxx xxxxxxxx x xxxxxxxxxx xx xxxxx xxxx xxx xxxx xxx xxxx xxxxxxx, xxx xxxx xx x xxxx.

*Xxxx xxxx xxxxxxx* 

```xaml
<FlipView x:Name="flipView1" SelectionChanged="FlipView_SelectionChanged">
    <Image Source="Assets/Logo.png" />
    <Image Source="Assets/SplashScreen.png" />
    <Image Source="Assets/SmallLogo.png" />
</FlipView>
```

Xxxxxxxxx: [XxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipview.aspx) 

Xxxxxx xxx xxx-xx: [Xxxx xxxx xxxxxxx xxxxx](flipview.md) 

### Xxxx xxxx
X xxxxxxx xxxx xxxxxxxx x xxxxxxxxxx xx xxxxx xx xxxx xxx xxxxxxx xxxx xxx xxxxxx xxxxxxxxxxxx.

```xaml
<GridView x:Name="gridView1" SelectionChanged="GridView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</GridView>
```

Xxxxxxxxx: [XxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.gridview.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx](lists.md) 

Xxxxxx xxxx: [XxxxXxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619900)

### Xxx
X xxxxxxxxx xxxxxxx xxxx xxxx xxx xxxx xxxx xxx xxxxxxxx xx xxxxxxxxx xxxxxxxx xx xxxxxxx.

```xaml
<Hub>
    <HubSection>
        <!--- hub section content -->
                </HubSection>
    <HubSection>
        <!--- hub section content -->
                </HubSection>
</Hub>
```

Xxxxxxxxx: [Xxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hub.aspx) 

Xxxxxx xxx xxx-xx: [Xxx xxxxxxx xxxxx](hub.md) 

Xxxxxx xxxx:[XXXX Xxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=309828)

### Xxxxx xxxxxxx
X xxxxxxx xxxx xxxxxxxx x xxxxxxxxxx xx xxxxx xx x XX xxxxxxxxx xx x xxxx xxxxxxxx. 

```xaml
<ItemsControl/>
```

Xxxxxxxxx: [XxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.aspx) 

### Xxxx xxxx
X xxxxxxx xxxx xxxxxxxx x xxxxxxxxxx xx xxxxx xx x xxxx xxxx xxx xxxxxx xxxxxxxxxx.

```xaml
<ListView x:Name="listView1" SelectionChanged="ListView_SelectionChanged">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
</ListView>
```

Xxxxxxxxx: [XxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listview.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx](lists.md) 

Xxxxxx xxxx: [XxxxXxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619900)

## Xxxx xxx xxxx xxxxxxxx

### Xxxxxxxx xxxx xxxxxx
X xxxxxxx xxxx xxxx x xxxx xxxxxx x xxxx xxxxx x xxxx-xxxx xxxxxxxx xxxxxxx.

*X xxxxxxxx xxxx xxxxxx xxxx xxxx xxxxxxxx xxxx* 

```xaml
<CalendarDatePicker/>
```

Xxxxxxxxx: [XxxxxxxxXxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendardatepicker.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxxx, xxxx, xxx xxxx xxxxxxxx](date-and-time.md)
 
### Xxxxxxxx xxxx
X xxxxxxxxxxxx xxxxxxxx xxxxxxx xxxx xxxx x xxxx xxxxxx xxxxxx xx xxxxxxxx xxxxx.

```xaml
<CalendarView/>
```

Xxxxxxxxx: [XxxxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.calendarview.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxxx, xxxx, xxx xxxx xxxxxxxx](date-and-time.md) 

### Xxxx xxxxxx
X xxxxxxx xxxx xxxx x xxxx xxxxxx x xxxx.

*Xxxx xxxxxx xxxxxxx* 

```xaml
<DatePicker Header="Arrival Date"/>
```

Xxxxxxxxx: [XxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.datepicker.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxxx, xxxx, xxx xxxx xxxxxxxx](date-and-time.md)
 
### Xxxx xxxxxx
X xxxxxxx xxxx xxxx x xxxx xxx x xxxx xxxxx.

*XxxxXxxxxx xxxxxxx* 

```xaml
<TimePicker Header="Arrival Time"/>
```

Xxxxxxxxx: [XxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.timepicker.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxxx, xxxx, xxx xxxx xxxxxxxx](date-and-time.md)

## Xxxxxxx

### Xxxxxxx xxxx
Xxx Xxxx xxxxxx xxx Xxxxx xxxx.

### Xxxxxx
Xxxxxxxx x xxxxxxx xxxx xxxxxxxx xxxx xxxxxxxxxxx. (Xxxxxx x xxxxxx, x xxxxxx xxxx xxx xxxxxx x xxxxxxxx xxxxxx, xxx xxxx xxx xxxxx xxxxx xxxx xxxxxxxxxxx.)

*Xxxxxx xxxxxxx* 

```xaml
<Flyout>
    <StackPanel>
        <TextBlock>All items will be permanently removed from your cart.</TextBlock>
        <Button Click="DeleteConfirmation_Click">Empty my cart</Button>
    </StackPanel>
</Flyout>
```

Xxxxxxxxx: [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flyout.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxx xxxxx xxx xxxxxxx](dialogs-popups-menus.md) 

### Xxxx xxxxxx
Xxxxxxxxxxx xxxxxxxx x xxxx xx xxxxxxxx xx xxxxxxx xxxxxxx xx xxxx xxx xxxx xx xxxxxxxxx xxxxx.

*Xxxx xxxxxx xxxxxxx* 

```xaml
<MenuFlyout>
    <MenuFlyoutItem Text="Reset" Click="Reset_Click"/>
    <MenuFlyoutSeparator/>
    <ToggleMenuFlyoutItem Text="Shuffle" 
                          IsChecked="{Binding IsShuffleEnabled, Mode=TwoWay}"/>
    <ToggleMenuFlyoutItem Text="Repeat" 
                          IsChecked="{Binding IsRepeatEnabled, Mode=TwoWay}"/>
</MenuFlyout>
```

Xxxxxxxxx: [XxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyout.aspx), [XxxxXxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutitem.aspx), [XxxxXxxxxxXxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.menuflyoutseparator.aspx), [XxxxxxXxxxXxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.togglemenuflyoutitem.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxx xxxxx xxx xxxxxxx](dialogs-popups-menus.md) 

Xxxxxx xxxx: [XXXX Xxxxxxx Xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620021)

### Xxxxx xxxx
X xxxxxx xxxx xxxx xxxxxxxx xxxxxxxx xxxx xxx xxxxxxx.

Xxxxxxxxx: [XxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.popups.popupmenu.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxx xxxxx xxx xxxxxxx](dialogs-popups-menus.md) 

### Xxxxxxx
X xxx-xx xxxxxx xxxx xxxxxxxx xxxxxxxxxxx xxx xx xxxxxxx. 

*Xxxx xxx xxxxxxx* 

```xaml
<Button Content="Button" Click="Button_Click" 
        ToolTipService.ToolTip="Click to perform action" />
```

Xxxxxxxxx: [XxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltip.aspx), [XxxxXxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.tooltipservice.aspx) 

Xxxxxx xxx xxx-xx: Xxxxxxxxxx xxx xxxxxxxx 

## Xxxxxx

### Xxxxx
X xxxxxxx xxxx xxxxxxxx xx xxxxx.

*Xxxxx xxxxxxx*

```xaml
<Image Source="Assets/Logo.png" />
```

Xxxxxxxxx: [Xxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx xxx XxxxxXxxxx](images-imagebrushes.md) 

Xxxxxx xxxx: [XXXX xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=226867)

## Xxxxxxxx xxx xxx

### XxxXxxxxx
X xxxxxxx xxxx xxxxxxxx xxx xxxxxxxx xxx xxxxxxx.

```xaml
<InkCanvas/>
```

Xxxxxxxxx: [XxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.inkcanvas.aspx) 

### Xxxxxx
Xxxxxxx xxxxxxxx xxxx xxxxxxxxx xxxxxxx xxxx xxx xx xxxxxxxxx xxxx xxxxxxxx, xxxxxxxxxx, xxxxx, Xxxxxx xxxxx, xxx.

*X xxxxxxx**X xxxx* 

```xaml
<Ellipse/>
<Path/>
<Rectangle/>
```

Xxxxxxxxx: [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.aspx) 

Xxx xx: [Xxxxxxx xxxxxx](../graphics/drawing-shapes.md) 

Xxxxxx xxxx: [XXXX xxxxxx-xxxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=226866)

## Xxxxxx xxxxxxxx

### Xxxxxx
X xxxxxxxxx xxxxxxx xxxx xxxxx x xxxxxx, xxxxxxxxxx, xx xxxx, xxxxxx xxxxxxx xxxxxx.

*X xxxxxx xxxxxx Y xxxxxxxxxx* 

```xaml
<Border BorderBrush="Gray" BorderThickness="4" 
        Height="108" Width="64">
    <StackPanel>
        <Rectangle Fill="Yellow"/>
        <Rectangle Fill="Green"/>
    </StackPanel>
</Border>
```

Xxxxxxxxx: [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.border.aspx)

### Xxxxxx
X xxxxxx xxxxx xxxx xxxxxxxx xxx xxxxxxxx xxxxxxxxxxx xx xxxxx xxxxxxxx xxxxxxxx xx xxx xxx xxxx xxxxxx xx xxx xxxxxx.
 
*Xxxxxx xxxxxx xxxxx* 

```xaml
<Canvas Width="120" Height="120">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Canvas.Left="20" Canvas.Top="20"/>
    <Rectangle Fill="Green" Canvas.Left="40" Canvas.Top="40"/>
    <Rectangle Fill="Yellow" Canvas.Left="60" Canvas.Top="60"/>
</Canvas>
```

Xxxxxxxxx: [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)
 
### Xxxx
X xxxxxx xxxxx xxxx xxxxxxxx xxx xxxxxxxxx xx xxxxx xxxxxxxx xx xxxx xxx xxxxxxx.

*Xxxx xxxxxx xxxxx* 

```xaml
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="50"/>
        <RowDefinition Height="50"/>
    </Grid.RowDefinitions>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="50"/>
        <ColumnDefinition Width="50"/>
    </Grid.ColumnDefinitions>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Grid.Row="1"/>
    <Rectangle Fill="Green" Grid.Column="1"/>
    <Rectangle Fill="Yellow" Grid.Row="1" Grid.Column="1"/>
</Grid>
```

Xxxxxxxxx: [Xxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)
 
### Xxxxxxx xxxxxx xxxxxx
Xxx Xxxxxx xxxxxx.

### XxxxxxxxXxxxx
X xxxxx xxxx xxxx xxx xxxxxxxx xxx xxxxx xxxxx xxxxxxx xx xxxxxxxx xx xxxx xxxxx xx xxx xxxxxx xxxxx.

*Xxxxxxxx xxxxx xxxxxx xxxxx* 

```xaml
<RelativePanel>
    <TextBox x:Name="textBox1" RelativePanel.AlignLeftWithPanel="True"/>
    <Button Content="Submit" RelativePanel.Below="textBox1"/>
</RelativePanel>
```

Xxxxxxxxx: [XxxxxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)

### Xxxxxx xxx
Xxx xxxxxx xxxxxx. (XxxxxxXxx xx xx xxxxxxx xx XxxxxxXxxxxx. Xxx xxx'x xxxxxxxxx xxx xx xx x xxxxx-xxxxx xxxxxxx.)

Xxxxxxxxx: [XxxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.scrollbar.aspx)
 
### Xxxxxx xxxxxx
X xxxxxxxxx xxxxxxx xxxx xxxx xxx xxxx xxx xxx xxxx xxx xxxxxxx.

```xaml
<ScrollViewer ZoomMode="Enabled" MaxZoomFactor="10" 
              HorizontalScrollMode="Enabled" HorizontalScrollBarVisibility="Visible"
              Height="200" Width="200">
    <Image Source="Assets/Logo.png" Height="400" Width="400"/>
</ScrollViewer>
```

Xxxxxxxxx: [XxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.scrollviewer.aspx)

Xxxxxx xxx xxx-xx: [Xxx, xxxxxx, xxx xxxx xxxxxxxx xxxxx](scroll-controls.md) 

Xxxxxx xxxx: [XXXX xxxxxxxxx, xxxxxxx xxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=238577)

### XxxxxXxxx
X xxxxxxxxx xxxxxxx xxxx xxx xxxxx; xxx xxxx xxx xxx xxxx xxxxxxx xxx xxxxxxx xxxx xxxx xx xxxxxxxxx xxxx xxx x xxxxxxxxxx xxxx.

*Xxxxx xxxx xxxxxxx* 

```xaml
<SplitView>
    <SplitView.Pane>
        <!-- Menu content -->
    </SplitView.Pane>
    <SplitView.Content>
        <!-- Main content -->
    </SplitView.Content>
</SplitView>
```

Xxxxxxxxx: [XxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx xxxx xxxxxxx xxxxx]()

### Xxxxx xxxxx
X xxxxxx xxxxx xxxx xxxxxxxx xxxxx xxxxxxxx xxxx x xxxxxx xxxx xxxx xxx xx xxxxxxxx xxxxxxxxxxxx xx xxxxxxxxxx.

*Xxxxx xxxxx xxxxxx xxxxxxx* 

```xaml
<StackPanel>
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue"/>
    <Rectangle Fill="Green"/>
    <Rectangle Fill="Yellow"/>
</StackPanel>
```

Xxxxxxxxx: [XxxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx)
 
### XxxxxxxxXxxxxXxxxXxxx
X xxxxxx xxxxx xxxx xxxxxxxx xxx xxxxxxxxx xx xxxxx xxxxxxxx xx xxxx xxx xxxxxxx. Xxxx xxxxx xxxxxxx xxx xxxx xxxxxxxx xxxx xxx xxxxxxx.

*Xxxxxxxx xxxxx xxxx xxxx xxxxxx xxxxx* 

```xaml
<VariableSizedWrapGrid MaximumRowsOrColumns="3" ItemHeight="44" ItemWidth="44">
    <Rectangle Fill="Red"/>
    <Rectangle Fill="Blue" Height="80" 
               VariableSizedWrapGrid.RowSpan="2"/>
    <Rectangle Fill="Green" Width="80" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
    <Rectangle Fill="Yellow" Height="80" Width="80" 
               VariableSizedWrapGrid.RowSpan="2" 
               VariableSizedWrapGrid.ColumnSpan="2"/>
</VariableSizedWrapGrid>
```

Xxxxxxxxx: [XxxxxxxxXxxxxXxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx)

### Xxxxxxx
X xxxxxxxxx xxxxxxx xxxx xxxxxx xxx xxxxxxx xx x xxxxxxxxx xxxx.

*Xxxxxxx xxxxxxx* 

```xaml
<Viewbox MaxWidth="25" MaxHeight="25">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
<Viewbox MaxWidth="75" MaxHeight="75">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
<Viewbox MaxWidth="150" MaxHeight="150">
    <Image Source="Assets/Logo.png"/>
</Viewbox>
```

Xxxxxxxxx: [Xxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.viewbox.aspx)
 
### Xxxxxxx xxxxxx xxxxxx
Xxx Xxxxxx xxxxxx.

## Xxxxx xxxxxxxx

### Xxxxx
Xxx Xxxxx xxxxxxx.

### Xxxxx xxxxxxx
X xxxxxxx xxxx xxxxx xxxxx xxx xxxxx xxxxxxx.

```xaml
<MediaElement x:Name="myMediaElement"/>
```

Xxxxxxxxx: [XxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediaelement.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx xxxxxxx xxxxxxx xxxxx](media-playback.md)

### XxxxxXxxxxxxxxXxxxxxxx
X xxxxxxx xxxx xxxxxxxx xxxxxxxx xxxxxxxx xxx x XxxxxXxxxxxx.

*Xxxxx xxxxxxx xxxx xxxxxxxxx xxxxxxxx* 

```xaml
<MediaTransportControls MediaElement="myMediaElement"/>
```

Xxxxxxxxx: [XxxxxXxxxxxxxxXxxxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.mediatransportcontrols.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx xxxxxxx xxxxxxx xxxxx](media-playback.md) 

Xxxxxx xxxx: [Xxxxx Xxxxxxxxx Xxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=620023)

### Xxxxx
Xxx Xxxxx xxxxxxx.

## Xxxxxxxxxx

### Xxxxx
X xxxx-xxxxxx xxxxxxxxx xxx xxxxxxxxxx xxxxx xxxx xxxx xxxxxxxx x xxxxx xxx xx xxxx xxxxxxx xxxxxxxxx xxxxxx (xxxxx xx xxxxxxx), xxxxxxxxx xx xxx xxxx xxx xx xxxx.

Xxx Xxxxx xxxxxxx xxx xx xxxxxx xx xxxx x "xxx" xxxxxx.

Xxxxxxxxx: [Xxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) 

Xxxxxx xxx xxx-xx: [Xxxx xxx xxxxx xxxxxxx xxxxx](tabs-pivot.md) 

Xxxxxx xxxx: [Xxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619903&amp;clcid=0x409)

### Xxxxxxxx xxxx
X xxxxxxxxx xxxxxxx xxxx xxxx xxx xxxx xxxx xxxxxxx xxx xxxxx xx x xxxxxxxxxx xx xxxxx.

*Xxxxxxxx xxxx xxxxxxx* 

```xaml
<SemanticZoom>
    <ZoomedInView>
        <GridView></GridView>
    </ZoomedInView>
    <ZoomedOutView>
        <GridView></GridView>
    </ZoomedOutView>
</SemanticZoom>
```

Xxxxxxxxx: [XxxxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.semanticzoom.aspx) 

Xxxxxx xxx xxx-xx: [Xxxx xxxx](semantic-zoom.md) 

Xxxxxx xxxx: [XXXX XxxxXxxx xxxxxxxx xxx XxxxxxxxXxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=226564)

### Xxx xxxx
X xxxxxxxxx xxxxxxx xxxx xxxxx xxx xxxxxxx.

```xaml
<WebView x:Name="webView1" Source="http://dev.windows.com" 
         Height="400" Width="800"/>
```

Xxxxxxxxx: [XxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.webview.aspx) 

Xxxxxx xxx xxx-xx: Xxxxxxxxxx xxx Xxx xxxxx 

Xxxxxx xxxx: [XXXX XxxXxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=238582)

## Xxxxxxxx xxxxxxxx

### Xxxxxxxx xxx
X xxxxxxx xxxx xxxxxxxxx xxxxxxxx xx xxxxxxxxxx x xxx.

*Xxxxxxxx xxx xxxxxxx*

X xxxxxxxx xxx xxxx xxxxx x xxxxxxxx xxxxx.

```xaml
<ProgressBar x:Name="progressBar1" Value="50" Width="100"/>
```

*Xxxxxxxxxxxxx xxxxxxxx xxx xxxxxxx*

X xxxxxxxx xxx xxxx xxxxx xxxxxxxxxxxxx xxxxxxxx.

```xaml
<ProgressBar x:Name="indeterminateProgressBar1" IsIndeterminate="True" Width="100"/>
```

Xxxxxxxxx: [XxxxxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressbar.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxxx xxxxxxxx xxxxx](progress-controls.md) 

### Xxxxxxxx xxxx
X xxxxxxx xxxx xxxxxxxxx xxxxxxxxxxxxx xxxxxxxx xx xxxxxxxxxx x xxxx. 

*Xxxxxxxx xxxx xxxxxxx* 

```xaml
<ProgressRing x:Name="progressRing1" IsActive="True"/>
```

Xxxxxxxxx: [XxxxxxxxXxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.progressring.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxxxx xxxxxxxx xxxxx](progress-controls.md) 

## Xxxx xxxxxxxx

### Xxxx xxxxxxx xxx
X xxxx xxxxx xxx xxxx xxxxxxxx xxxxxxxxx xxxx xx xxx xxxx xxxxx.

Xx xxxx xxxxxxx xxx xxx xxxxxx 

Xxxxxxxxx: [XxxxXxxxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.autosuggestbox.aspx)

Xxxxxx xxx xxx-xx: [Xxxx xxxxxxxx](text-controls.md), [Xxxx xxxxxxx xxx xxxxxxx xxxxx](auto-suggest-box.md)

Xxxxxx xxxx: [XxxxXxxxxxxXxx xxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619996)

### Xxxxx-xxxx xxxx xxx
Xxx Xxxx xxx.

### Xxxxxxxx xxx
X xxxxxxx xxx xxxxxxxx xxxxxxxxx.

*Xxxxxxxx xxx xxxxxxx* 

```xaml
<PasswordBox x:Name="passwordBox1" PasswordChanged="PasswordBox_PasswordChanged" />
```

Xxxxxxxxx: [XxxxxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.passwordbox.aspx) 

Xxxxxx xxx xxx-xx: [Xxxx xxxxxxxx](text-controls.md), [Xxxxxxxx xxx xxxxxxx xxxxx](password-box.md) 

Xxxxxx xxxx: [XXXX xxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=238579), [XXXX xxxx xxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=251417)

### Xxxx xxxx xxx
X xxxxxxx xxxx xxxx x xxxx xxxx xxxx xxxx xxxxxxxxx xxxx xxxxxxx xxxx xxxxxxxxx xxxx, xxxxxxxxxx, xxx xxxxxx.

```xaml
<RichEditBox />
```

Xxxxxxxxx: [XxxxXxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richeditbox.aspx) 

Xxxxxx xxx xxx-xx: [Xxxx xxxxxxxx](text-controls.md), [Xxxx xxxx xxx xxxxxxx xxxxx](rich-edit-box.md)

Xxxxxx xxxx: [XXXX xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=238578)

### Xxxxxx xxx
Xxx Xxxx xxxxxxx xxx.

### Xxxxxx-xxxx xxxx xxx
Xxx Xxxx xxx.

### Xxxxxx xxxx/xxxxxxxxx
Xxx Xxxx xxxxx.

### Xxxx xxxxx
X xxxxxxx xxxx xxxxxxxx xxxx.

*Xxxx xxxxx xxxxxxx* 

```xaml
<TextBlock x:Name="textBlock1" Text="I am a TextBlock"/>
```

Xxxxxxxxx: [XxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx), [XxxxXxxxXxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx) 

Xxxxxx xxx xxx-xx: [Xxxx xxxxxxxx](text-controls.md), [Xxxx xxxxx xxxxxxx xxxxx](text-block.md), [Xxxx xxxx xxxxx xxxxxxx xxxxx](rich-text-block.md)

Xxxxxx xxxx: [XXXX xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=238578)

### Xxxx xxx
X xxxxxx-xxxx xx xxxxx-xxxx xxxxx xxxx xxxxx.

*Xxxx xxx xxxxxxx* 

```xaml
<TextBox x:Name="textBox1" Text="I am a TextBox" 
         TextChanged="TextBox_TextChanged"/>
```

Xxxxxxxxx: [XxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx) 

Xxxxxx xxx xxx-xx: [Xxxx xxxxxxxx](text-controls.md), [Xxxx xxx xxxxxxx xxxxx](text-box.md) 

Xxxxxx xxxx: [XXXX xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=238578)

## Xxxxxxxxx xxxxxxxx

### Xxxxx xxx
X xxxxxxx xxxx x xxxx xxx xxxxxx xx xxxxx.

*Xxx Y xxxxxx xx x xxxxx xxx* 

```xaml
<CheckBox x:Name="checkbox1" Content="CheckBox" 
          Checked="CheckBox_Checked"/>
```

Xxxxxxxxx: [XxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.checkbox.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx xxx xxxxxxx xxxxx](checkbox.md) 

### Xxxxx xxx
X xxxx-xxxx xxxx xx xxxxx x xxxx xxx xxxxxx xxxx.

*Xxxx xxxxx xxx* 

```xaml
<ComboBox x:Name="comboBox1" SelectionChanged="ComboBox_SelectionChanged" Width="100">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ComboBox>
```

Xxxxxxxxx: [XxxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.combobox.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx](lists.md) 

### Xxxx xxx
X xxxxxxx xxxx xxxxxxxx xx xxxxxx xxxx xx xxxxx xxxx xxx xxxx xxx xxxxxx xxxx. 

*Xxxx xxx xxxxxxx*

```xaml
<ListBox x:Name="listBox1" SelectionChanged="ListBox_SelectionChanged" Width="100">
    <x:String>Item 1</x:String>
    <x:String>Item 2</x:String>
    <x:String>Item 3</x:String>
</ListBox>
```

Xxxxxxxxx: [XxxxXxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.listbox.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx](lists.md) 

### Xxxxx xxxxxx
X xxxxxxx xxxx xxxxxx x xxxx xx xxxxxx x xxxxxx xxxxxx xxxx x xxxxx xx xxxxxxx. Xxxx xxxxx xxxxxxx xxx xxxxxxx xxxxxxxx, xxxx xxx xxxxxxxx xxxxxxxxx.

*Xxxxx xxxxxx xxxxxxxx* 

```xaml
<RadioButton x:Name="radioButton1" Content="RadioButton 1" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
<RadioButton x:Name="radioButton2" Content="RadioButton 2" GroupName="Group1" 
             Checked="RadioButton_Checked" IsChecked="True"/>
<RadioButton x:Name="radioButton3" Content="RadioButton 3" GroupName="Group1" 
             Checked="RadioButton_Checked"/>
```

Xxxxxxxxx: [XxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.radiobutton.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxx xxxxxx xxxxxxx xxxxx](radio-button.md)
 
### Xxxxxx
X xxxxxxx xxxx xxxx xxx xxxx xxxxxx xxxx x xxxxx xx xxxxxx xx xxxxxx x Xxxxx xxxxxxx xxxxx x xxxxx.

*Xxxxxx xxxxxxx* 

```xaml
<Slider x:Name="slider1" Width="100" ValueChanged="Slider_ValueChanged" />
```

Xxxxxxxxx: [Xxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.slider.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxx xxxxxxx xxxxx](slider.md) 

### Xxxxxx xxxxxx
X xxxxxx xxxx xxx xx xxxxxxx xxxxxxx Y xxxxxx.

*X xxxxxx xxxxxx xxxxxxx* 

```xaml
<ToggleButton x:Name="toggleButton1" Content="Button" 
              Checked="ToggleButton_Checked"/>
```

Xxxxxxxxx: [XxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.primitives.togglebutton.aspx)

Xxxxxx xxx xxx-xx: [Xxxxxx xxxxxxx xxxxx](toggles.md) 

### Xxxxxx xxxxxx
X xxxxxx xxxx xxx xx xxxxxxx xxxxxxx Y xxxxxx.

*Xxxxxx xxxxxx xxxxxxx* 

```xaml
<ToggleSwitch x:Name="toggleSwitch1" Header="ToggleSwitch" 
              OnContent="On" OffContent="Off" 
              Toggled="ToggleSwitch_Toggled"/>
```

Xxxxxxxxx: [XxxxxxXxxxxx](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.toggleswitch.aspx) 

Xxxxxx xxx xxx-xx: [Xxxxxx xxxxxxx xxxxx](toggles.md) 
<!--HONumber=Mar16_HO1-->
