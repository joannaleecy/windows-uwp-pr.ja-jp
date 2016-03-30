---
Xxxxxxxxxxx: Xxxxxxxx xxxxxx xx x xxxxxxxxxx, xxxx xx xxxxxx xx xx xxxxx xx xxxxx xx x xxxxxxx xxxxxxx xxxx, xxx xxxxx xx x xxxx.
xxxxx: Xxxxxxxxxx xxx xxxx xxxx xxxxxxxx
xx.xxxxxxx: XYXYYXYY-YXYX-YXXX-YYXY-YYYYYXXYXYXY
xxxxx: Xxxx xxxx
xxxxxxxx: xxxxxx.xxx
---
# Xxxx xxxx

Xxx x xxxx xxxx xxx xxxxxxxx xxxxxx xx xxxxx xxxxx xx x xxxxxxxxxx, xxxx xx xxxxxx xx xx xxxxx xx xxxxx xx x xxxxxxx xxxxxxx xxxx, xxx xxxx xx x xxxx. Xxx xxxxx xxxxxxx, xxxxxxx xxxxxx xx xxxx xxxxx xxxxxxx xxx xxxxxxxxxx. Xxx x xxxxx, xxxxxxxxxx xxxxxxx xxxxxx xx xxxxx xxxxx. Xxx x xxxxxxxx, xxxxx xxxx xxxx xxxxxxx xxx xxxxxxxxxx.


<span class="sidebar_heading" style="font-weight: bold;">Xxxxxxxxx XXXx</span>

-   [**XxxxXxxx xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.flipview.aspx)
-   [**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx)
-   [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx)

## Xx xxxx xxx xxxxx xxxxxxx?

Xxxx xxxx xx xxxx xxx xxxxxxxx xxxxxx xx xxxxx xx xxxxxx xxxxxxxxxxx (xx xx YY xx xx xxxxx). Xxxxxxxx xx xxxx xxxxxxxxxxx xxxxxxx xxxxx xx x xxxxxxx xxxxxxx xxxx xx xxxxxx xx x xxxxx xxxxx. Xxxxxxxx xx xxx'x xxxxxxxxx xxxx xxxx xxx xxxx xxxxx xxxxxxxxxxx, xxx xxxxxxx xx xxxxxx xxx xxxxxxx xxxxxxxxxx xxxxxx xx x xxxxx xxxxx.

## Xxxxxxxx

Xxxxxxxxxx xxxxxxxx, xxxxxxxx xx xxx xxxx-xxxx xxxx xxx xxxxxxxx xxxxx, xx xxx xxxxxxx xxxxxx xxx x xxxx xxxx. Xxxx xxxxxx xxxxx xxxx xx xxxxxx xxxxxxxx xx xxxxxxxxx xxxxxxxxxxx xx xxx xxxxxxx:

![Xxxxxxx xx xxxxxxxxxx xxxx xxxx xxxxxx](images/controls_flipview_horizonal.jpg)

X xxxx xxxx xxx xxxx xx xxxxxxx xxxxxxxxxx:

![Xxxxxxx xx xxxxxxxx xxxx xxxx](images/controls_flipview_vertical.jpg)

## Xxxxxx x xxxx xxxx

XxxxXxxx xx xx [XxxxxXxxxxxx](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.aspx), xx xx xxx xxxxxxx x xxxxxxxxxx xx xxxxx xx xxx xxxx. Xx xxxxxxxx xxx xxxx, xxx xxxxx xx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) xxxxxxxxxx, xx xxx xxx [**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) xxxxxxxx xx x xxxx xxxxxx.

Xx xxxxxxx, x xxxx xxxx xx xxxxxxxxx xx xxx xxxx xxxx xx xxx xxxxxx xxxxxxxxxxxxxx xx xxx xxxx xxxxxx xx'x xxxxx xx. Xx xxxxxxx xxxxxxx xxx xxxxx xx xxx xxxx xxxx xxx xxxxxxxxx, xxx xxxxxx x [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.datatemplate.aspx) xx xxxxxx xxx xxxxxx xx xxxxxxxx xxxx xx xxxxxxx xx xxxxxxxxxx xxxx. Xxx xxxxxxxx xx xxx xxxxxx xxx xx xxxxx xx xxxxxxxxxx xx x xxxx xxxxxx, xx xxxx xxxxxxx xxxxxxx xxxxxx. Xxx xxxxxx xxx XxxxXxxxxxxx xx xxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) xxxxxxxx xx xxx XxxxXxxx.

### Xxx xxxxx xx xxx Xxxxx xxxxxxxxxx

Xxx xxx xxx xxxxx xx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.items.aspx) xxxxxxxxxx xxxxx XXXX xx xxxx. Xxx xxxxxxxxx xxx xxxxx xxxx xxx xx xxx xxxx x xxxxx xxxxxx xx xxxxx xxxx xxx'x xxxxxx xxx xxx xxxxxx xxxxxxx xx XXXX, xx xx xxx xxxxxxxx xxx xxxxx xx xxxx xx xxx xxxx. Xxxx'x x xxxx xxxx xxxx xxxxx xxxxxxx xxxxxx.

```xaml
<FlipView x:Name="flipView1">
    <Image Source="Assets/Logo.png" />
    <Image Source="Assets/SplashScreen.png" />
    <Image Source="Assets/SmallLogo.png" />
</FlipView>
```

```csharp
// Create a new flip view, add content, 
// and add a SelectionChanged event handler.
FlipView flipView1 = new FlipView();
flipView1.Items.Add("Item 1");
flipView1.Items.Add("Item 2");

// Add the flip view to a parent container in the visual tree.
stackPanel1.Children.Add(flipView1);
```

Xxxx xxx xxx xxxxx xx x xxxx xxxx xxxx xxx xxxxxxxxxxxxx xxxxxx xx x [**XxxxXxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.flipviewitem.aspx) xxxxxxxxx. Xx xxxxxx xxx xx xxxx xx xxxxxxxxx xxx xxx xxxxx x xxxxx xx xxx xxxx xxxxxxxxx xx xxxxxxx xxx [**XxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemcontainerstyle.aspx) xxxxxxxx. 

Xxxx xxx xxxxxx xxx xxxxx xx XXXX, xxxx xxx xxxxxxxxxxxxx xxxxx xx xxx Xxxxx xxxxxxxxxx.

### Xxx xxx xxxxx xxxxxx

Xxx xxxxxxxxx xxx x xxxx xxxx xx xxxxxxx xxxx xxxx x xxxxxx xxxx xx x xxxxxxxx xx xxx Xxxxxxxx. Xx xxxxxxxx x xxxx xxxx xxxx x xxxx xxxxxx, xxx xxx xxx [**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemssource.aspx) xxxxxxxx xx x xxxxxxxxxx xx xxxx xxxxx.

Xxxx, xxx xxxx xxxx'x XxxxxXxxxxx xx xxx xx xxxx xxxxxxxx xx xx xxxxxxxx xx x xxxxxxxxxx.

```csharp
// Data source.
List<String> itemsList = new List<string>();
itemsList.Add("Item 1");
itemsList.Add("Item 2");

// Create a new flip view, add content, 
// and add a SelectionChanged event handler.
FlipView flipView1 = new FlipView();
flipView1.ItemsSource = itemsList;
flipView1.SelectionChanged += FlipView_SelectionChanged;

// Add the flip view to a parent container in the visual tree.
stackPanel1.Children.Add(flipView1);
```

Xxx xxx xxxx xxxx xxx XxxxxXxxxxx xxxxxxxx xx x xxxxxxxxxx xx XXXX. Xxx xxxx xxxx, xxx [Xxxx xxxxxxx xxxx XXXX](../data-binding/data-binding-quickstart.md).

Xxxx, xxx XxxxxXxxxxx xx xxxxx xx x [**XxxxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.data.collectionviewsource.aspx) xxxxx `itemsViewSource`. 

```xaml
<Page.Resources>
    <!-- Collection of items displayed by this page -->
    <CollectionViewSource x:Name="itemsViewSource" Source="{Binding Items}"/>
</Page.Resources>

...

<FlipView x:Name="itemFlipView" 
          ItemsSource="{Binding Source={StaticResource itemsViewSource}}"/>
```

>**Xxxx**&xxxx;&xxxx;Xxx xxx xxxxxxxx x xxxx xxxx xxxxxx xx xxxxxx xxxxx xx xxx Xxxxx xxxxxxxxxx, xx xx xxxxxxx xxx XxxxxXxxxxx xxxxxxxx, xxx xxx xxx'x xxx xxxx xxxx xx xxx xxxx xxxx. Xx xxx xxx xxx XxxxxXxxxxx xxxxxxxx xxx xxx xxx xx xxxx xx XXXX, xxx xxxxx xxxx xx xxxxxxx. Xx xxx xxx xxx XxxxxXxxxxx xxxxxxxx xxx xxx xxx xx xxxx xx xxx Xxxxx xxxxxxxxxx xx xxxx, xx xxxxxxxxx xx xxxxxx.

### Xxxxxxx xxx xxxx xx xxx xxxxx

Xx xxxxxxx, x xxxx xxxx xx xxxxxxxxx xx xxx xxxx xxxx xx xxx xxxxxx xxxxxxxxxxxxxx xx xxx xxxx xxxxxx xx'x xxxxx xx. Xxx xxxxxxxxx xxxx xx xxxx x xxxx xxxx xxxxxxxxxxxx xx xxxx xxxx. Xx xxxxxxx xxxxxxx xxx xxxxx xx xxx xxxx xxxx xxx xxxxxxxxx, xxx xxxxxx x [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.datatemplate.aspx). Xxx XXXX xx xxx XxxxXxxxxxxx xxxxxxx xxx xxxxxx xxx xxxxxxxxxx xx xxxxxxxx xxxx xx xxxxxxx xx xxxxxxxxxx xxxx. Xxx xxxxxxxx xx xxx xxxxxx xxx xx xxxxx xx xxxxxxxxxx xx x xxxx xxxxxx, xx xxxx xxxxxxx xxxxxxx xxxxxx. Xxx XxxxXxxxxxxx xx xxxxxxxx xx xxx [**XxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.itemscontrol.itemtemplate.aspx) xxxxxxxx xx xxx XxxxXxxx xxxxxxx.

Xx xxxx xxxxxxx, xxx XxxxXxxxxxxx xx x XxxxXxxx xx xxxxxxx xxxxxx. Xx xxxxxxx xx xxxxx xx xxx xxxxx xx xxxxxxx xxx xxxxx xxxx. 

```XAML
<FlipView x:Name="flipView1" Width="480" Height="270" 
          BorderBrush="Black" BorderThickness="1">
    <FlipView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Image Width="480" Height="270" Stretch="UniformToFill"
                       Source="{Binding Image}"/>
                <Border Background="#A5000000" Height="80" VerticalAlignment="Bottom">
                    <TextBlock Text="{Binding Name}" 
                               FontFamily="Segoe UI" FontSize="26.667" 
                               Foreground="#CCFFFFFF" Padding="15,20"/>
                </Border>
            </Grid>
        </DataTemplate>
    </FlipView.ItemTemplate>
</FlipView>
```

Xxxx'x xxxx xxx xxxxxx xxxxxxx xx xxx xxxx xxxxxxxx xxxxx xxxx.

Xxxx xxxx xxxx xxxxxxxx.

### Xxx xxx xxxxxxxxxxx xx xxx xxxx xxxx

Xx xxxxxxx, xxx xxxx xxxx xxxxx xxxxxxxxxxxx. Xx xxxx xxx xx xxxx xxxxxxxxxx, xxx x xxxxx xxxxx xxxx x xxxxxxxx xxxxxxxxxxx xx xxx xxxx xxxx'x [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.itemscontrol.itemspanel.aspx).

Xxxx xxxxxxx xxxxx xxx xx xxx x xxxxx xxxxx xxxx x xxxxxxxx xxxxxxxxxxx xx xxx XxxxxXxxxx xx x XxxxXxxx.

```XAML
<FlipView x:Name="flipViewVertical" Width="480" Height="270" 
          BorderBrush="Black" BorderThickness="1">
    
    <!-- Use a vertical stack panel for vertical flipping. -->
    <FlipView.ItemsPanel>
        <ItemsPanelTemplate>
            <VirtualizingStackPanel Orientation="Vertical"/>
        </ItemsPanelTemplate>
    </FlipView.ItemsPanel>
    
    <FlipView.ItemTemplate>
        <DataTemplate>
            <Grid>
                <Image Width="480" Height="270" Stretch="UniformToFill"
                       Source="{Binding Image}"/>
                <Border Background="#A5000000" Height="80" VerticalAlignment="Bottom">
                    <TextBlock Text="{Binding Name}" 
                               FontFamily="Segoe UI" FontSize="26.667" 
                               Foreground="#CCFFFFFF" Padding="15,20"/>
                </Border>
            </Grid>
        </DataTemplate>
    </FlipView.ItemTemplate>
</FlipView>
```

Xxxx'x xxxx xxx xxxx xxxx xxxxx xxxx xxxx x xxxxxxxx xxxxxxxxxxx.

![Xxxxxxx xx xxxxxxxx xxxx xxxx](images/controls_flipview_vertical.jpg)

## Xxxxxx x xxxxxxx xxxxxxxxx

X xxxxxxx xxxxxxxxx xx x xxxx xxxx xxxxxxxx x xxxxxx xxxxx xx xxxxxxxxx. Xxx xxxx xx x xxxxxxxx xxxxxxx xxxxxxxxx xxxx'x xxxxxxxxxxx. Xx xxxx xx xxxx xxxxxxx, xxx xxxx xxxxxxxxx xx xxxxxxx xxxxxxxx xxx xxxxx xxx xxxxxxx:

![Xxxxxxx xx x xxxx xxxxxxxxx](images/controls_pageindicator.png)

Xxx xxxxxx xxxxxxxxxxx (YY-YY xxxxx), xxxxxxxx xxxxx xx xxxxxxxxx xxxx xxxxxxxx xxxx xxxxxxx, xxxx xx x xxxx xxxxx xx xxxxxxxxxx. Xxxxxx x xxxxxxx xxxxxxxxx xxxx xxxx xxxxxx xxxx, xxxx xxxxxxxxx xx xxx xxxx xxxxx xxxxx x xxxxx xxxxxxx xx xxx xxxxxxxxxxxxx xxxxx xxx xxxxxx xx xxxxxxxxxx:

![Xxxxxxx xx xxxxxxx xxxxxxxxx](images/controls_contextindicator.jpg)

## Xxxxxxxxxxxxxxx

-   Xxxx xxxxx xxxx xxxx xxx xxxxxxxxxxx xx xx xx YY xx xx xxxxx.
-   Xxxxx xxxxx x xxxx xxxx xxxxxxx xxx xxxxxx xxxxxxxxxxx, xx xxx xxxxxxxxxx xxxxxx xx xxxxxxxx xxxxxxx xxxx xxxx xxx xx xxxxxxx. Xx xxxxxxxxx xxxxx xx xxx xxxxx xxxxxx, xxxxx xxxxx xxxx xxxxxxxx xx xxxxxxxxx xx xxxxxx. Xxxxx xxxxxx xxxxxx xxxxxx xxxxxx xx x xxxx xxxx xxxx x xxxxx xxx xxxx xxxxxxxx xx xxx xxxx xxxx xxxxxx. Xxx xxxxx xxxxx xxxxxxxxxxx, xxxxxxxx x [Xxxx xxxx xx xxxx xxxx](lists.md).
-   Xxx xxxxxxx xxxxxxxxxx:
    -   Xxx xxxxx xx xxxx (xx xxxxxxxxx xxxxxx xxxxxx xxx xxxxxx) xxxxx xxxx xxxx xxxxxxxx xxx xxxxx x xxxxxxxxxxxx-xxxxxxx xxxxxxx.
    -   Xx xxx xxxx x xxxxxxx xxxxxxxxx xx x xxxxxxxxxx-xxxxxxx xxxxxxx, xx xxxxx xxxx xxxxxxxx xxx xx xxx xxxxx xx xxx xxxxxx.
    -   Xxx xxxxxxxxxxx xxx xxxxxxxxx xxx xxxxxxx xxxx. Xxxxxxx xxx xxxxxxxxxxx xxx xx xxxxx xxx xxx xxxxx xxxx xxx xxxx.
    -   Xxx xxxxxx xx xxxx xxx xxxx, xxx xxx'x xxxx xx xxxx xxxx xxx xxxx xxxxx xxxxxxxx xx xxxx xxx xx xxx xxxxx - YY xxxx xx xxxxxxx xxx xxxxxxx xxxxxx xx xxxx.

\[Xxxx xxxxxxx xxxxxxxx xxxxxxxxxxx xxxx xx xxxxxxxx xx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx xxx Xxxxxxx YY. Xxx Xxxxxxx Y.Y xxxxxxxx, xxxxxx xxxxxxxx xxx [Xxxxxxx Y.Y xxxxxxxxxx XXX](https://go.microsoft.com/fwlink/p/?linkid=258743).\]

## Xxxxxxx xxxxxxxx

[Xxxxxxxxxx xxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt186889)
- [**XxxxXxxx xxxxx (XXXX)**](https://msdn.microsoft.com/library/windows/apps/br242678)
- [**XxxxxxxxXxxxx xxxxx (XXXX)**](https://msdn.microsoft.com/library/windows/apps/hh967950)
<!--HONumber=Mar16_HO1-->
