---
xxxxx: 'Xxxxxxx xxxxxx xx xxxxxxxx (XXX) xx x xxx'
xxxxxxxxxxx: Xxx xxxxxx xx xxxxxxxx (XXX) xx x xxx xxxxx xxxxxxxx, xxxxxx, xxxxxx, xxx XXXX XX xxxxxxxx.
xx.xxxxxxx: XXYYXYXX-YXYX-YYYY-YYYY-YXXXXYXYYXXX
---

# Xxxxxxx xxxxxx xx xxxxxxxx (XXX) xx x xxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xxxxxx xx xxxxxxxx (XXX) xx x xxx xxxxx xxxxxxxx, xxxxxx, xxxxxx, xxx XXXX XX xxxxxxxx. X XXX xx x xxxxxxxx xxxxx xx xxx xxx xxxx xxxxxxxxxx xxxxxxxxx xx xxxxxxxx. Xxx xxxxxxx, xxx xxxxxxxx xx x xxxxxxxx, xxxx, xx xxxxxx.

**Xxx** Xx xxxxx xxxx xxxxx xxxxxxxxxx XXX xx xxxx xxx, xxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

-   [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)

Xxxxxxx xxxxxxxx, xxxxxx, xxx xxxxxx xx xxx xxx xx xxxxxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077), [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637103), xxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637114) xxxxxxx xx xxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637033) xxxxxxxxxx xx xxx xxx xxxxxxx. Xxx xxxx xxxxxxx xx xxx xxxxx xxxxxxxxxxxxxxxx; xxx xxx'x xxxx xx xxx **XxxXxxxxxxx** xxxxxxxxxx xxxxxxxxxxxxx xx xxxx XXXX xxxxxx.

Xxxxxxx XXXX xxxx xxxxxxxxx xxxxxxxx xxxx xx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209265), x [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br242739), xx x [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209652) xx xxx xxx xx xxxxxx xxxx xx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637008) xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004). Xxx xxx xxxx xxx xxxx xx xxx [**XxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637094), xx xxxx xxx **XxxXxxxxXxxxxxx** xx x xxxxxxxxxx xx xxxxx.

Xx xxxxxxx:

-   [Xxx x XxxXxxx xx xxx xxx](#mapicon) xx xxxxxxx xx xxxxx xxxx xx x xxxxxxx xxxx xxxxxxxx xxxx.
-   [Xxx x XxxXxxxxxx xx xxx xxx](#mappolygon) xx xxxxxxx x xxxxx-xxxxx xxxxx.
-   [Xxx x XxxXxxxxxxx xx xxx xxx](#mappolyline) xx xxxxxxx xxxxx xx xxx xxx.
-   [Xxx XXXX xx xxx xxx](#mapxaml) xx xxxxxxx xxxxxx XX xxxxxxxx.

Xx xxx xxxx x xxxxx xxxxxx xx xxxxxxxx xx xxxxx xx xxx xxx, xxxxxxxx [xxxxxxxxxx xxxxx xxxxxx xx xxx xxx](overlay-tiled-images.md). Xx xxxxxxx xxxxx xx xxx xxx, xxx [Xxxxxxx xxxxxx xxx xxxxxxxxxx](routes-and-directions.md).

## Xxx x XxxXxxx


Xxxxxxx xx xxxxx xxxx x xxxxxxx, xxxx xxxxxxxx xxxx, xx xxx xxx xx xxxxx xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077) xxxxx. Xxx xxx xxxxxx xxx xxxxxxx xxxxx xx xxxxxxx x xxxxxx xxxxx xx xxxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637078) xxxxxxxx. Xxx xxxxxxxxx xxxxx xxxxxxxx xxx xxxxxxx xxxxx xxx x **XxxXxxx** xxxx xx xxxxx xxxxxxxxx xxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637088) xxxxxxxx, xxxx x xxxxx xxxxx, xxxx x xxxx xxxxx, xxx xxxx x xxxx xxxx xxxxx.

![xxxxxx xxxxxxx xxxx xxxxxx xx xxxxxxxxx xxxxxxx.](images/mapctrl-mapicons.png)

Xxx xxxxxxxxx xxxxxxx xxxxx x xxx xx xxx xxxx xx Xxxxxxx xxx xxxx x [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077) xxxx xxx xxxxxxx xxxxx xxx xx xxxxxxxx xxxxx xx xxxxxxxx xxx xxxxxxxx xx xxx Xxxxx Xxxxxx. Xx xxxx xxxxxxx xxx xxx xxxx xxx xxxx xxx xxxxx xx. Xxx xxxxxxx xxxx xxxxx xxxxx xxx xxx xxxxxxx, xxx [Xxxxxxx xxxx xxxx YX, YX, xxx Xxxxxxxxxx xxxxx](display-maps.md).

```csharp
      private void displayPOIButton_Click(object sender, RoutedEventArgs e)
      {
         // Specify a known location.
         BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 47.620, Longitude = -122.349 };
         Geopoint snPoint = new Geopoint(snPosition);

         // Create a MapIcon.
         MapIcon mapIcon1 = new MapIcon();
         mapIcon1.Location = snPoint;
         mapIcon1.NormalizedAnchorPoint = new Point(0.5, 1.0);
         mapIcon1.Title = "Space Needle";
         mapIcon1.ZIndex = 0;

         // Add the MapIcon to the map.
         MapControl1.MapElements.Add(mapIcon1);

         // Center the map over the POI.
         MapControl1.Center = snPoint;
         MapControl1.ZoomLevel = 14;
      }
```

Xxxx xxxxxxx xxxxxxxx xxx xxxxxxxxx XXX xx xxx xxx (xxx xxxxxxx xxxxx xx xxx xxxxxx).

![xxx xxxx xxxxxxx](images/displaypoidefault.png)

Xxx xxxxxxxxx xxxx xx xxxx xxxxxxxx xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077) xxxx x xxxxxx xxxxx xxxxx xx xxx Xxxxxx xxxxxx xx xxx xxxxxxx. Xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637078) xxxxxxxx xx xxx **XxxXxxx** xxxxxxx x xxxxx xx xxxx [**XxxxxxXxxxxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701813). Xxxx xxxx xxxxxxxx x **xxxxx** xxxxxxxxx xxx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br241791) xxxxxxxxx.

**Xxx** Xx xxx xxx xxx xxxx xxxxx xxx xxxxxxxx xxx xxxxx, xxxxxxx xxx [**XxxxxxXxxxxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701813) xx xxx xxxx xx xxx xxxxx xxx xxx xxxx xxxxxxxxxxx.

```csharp
    MapIcon1.Image =
        RandomAccessStreamReference.CreateFromUri(new Uri("ms-appx:///Assets/customicon.png"));
```

Xxxx xxxxx xxxxxxxxxxxxxx xx xxxx xxxx xxxxxxx xxxx xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077) xxxxx:

-   Xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637078) xxxxxxxx xxxxxxxx x xxxxxxx xxxxx xxxx xx YYYY×YYYY xxxxxx.
-   Xx xxxxxxx, xxx xxx xxxx'x xxxxx xx xxx xxxxxxxxxx xx xx xxxxx. Xx xxx xx xxxxxx xxxx xx xxxxxxxx xxxxx xxxxxxxx xx xxxxxx xx xxx xxx. Xx xxxx xx xxxxxxx, xxx xxx xxx xxxx'x [**XxxxxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974327) xxxxxxxx xx [**XxxXxxxxxxXxxxxxxxxXxxxxxxx.XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974314).
-   Xxx xxxxxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637088) xx xxx [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077) xx xxx xxxxxxxxxx xx xx xxxxx. Xx xxx xxx'x xxx xxx xxxx, xxxx xxx xx xxxxxxxxxx xxx xxxxx xx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637068) xxxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004).
-   Xxxx xxx xxxxxxx x [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077) xxxxx xxxx xxxxxx xx x xxxxxxxx xxxxxxxx xx xxx xxx - xxx xxxxxxx, x xxxxxxx xx xx xxxxx - xxxxxxxx xxxxxxx xxx xxxxx xx xxx [**XxxxxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637082) xxxxxxxx xx xxx xxxxxxxxxxx xxxxxxxx xx xxx xxxxxxx xx xxx xxxxx. Xx xxx xxxxx xxx xxxxx xx **XxxxxxxxxxXxxxxxXxxxx** xx xxx xxxxxxx xxxxx xx (Y, Y), xxxxx xxxxxxxxxx xxx xxxxx xxxx xxxxxx xx xxx xxxxx, xxxxxxx xx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637068) xx xxx xxx xxx xxxxx xxx xxxxx xxxxxxxx xx x xxxxxxxxx xxxxxxxx.

## Xxx x XxxXxxxxxx


Xxxxxxx x xxxxx-xxxxx xxxxx xx xxx xxx xx xxxxx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637103) xxxxx. Xxx xxxxxxxxx xxxxxxx, xxxx xxx [XXX xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977), xxxxxxxx x xxx xxx xxxx xxxx xxxxxx xx xxx xxx.

```csharp
private void mapPolygonAddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
   double centerLatitude = myMap.Center.Position.Latitude;
   double centerLongitude = myMap.Center.Position.Longitude;
   MapPolygon mapPolygon = new MapPolygon();
   mapPolygon.Path = new Geopath(new List<BasicGeoposition>() {
         new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude-0.001 },                
         new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },                
         new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude+0.001 },
         new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },

   });
           
   mapPolygon.ZIndex = 1;
   mapPolygon.FillColor = Colors.Red;
   mapPolygon.StrokeColor = Colors.Blue;
   mapPolygon.StrokeThickness = 3;
   mapPolygon.StrokeDashed = false;
   myMap.MapElements.Add(mapPolygon);
}
```

## Xxx x XxxXxxxxxxx


Xxxxxxx x xxxx xx xxx xxx xx xxxxx xxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637114) xxxxx. Xxx xxxxxxxxx xxxxxxx, xxxx xxx [XXX xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977), xxxxxxxx x xxxxxx xxxx xx xxx xxx.

```csharp
private void mapPolylineAddButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
{
   double centerLatitude = myMap.Center.Position.Latitude;
   double centerLongitude = myMap.Center.Position.Longitude;
   MapPolyline mapPolyline = new MapPolyline();
   mapPolyline.Path = new Geopath(new List<BasicGeoposition>() {                
         new BasicGeoposition() {Latitude=centerLatitude-0.0005, Longitude=centerLongitude-0.001 },                
         new BasicGeoposition() {Latitude=centerLatitude+0.0005, Longitude=centerLongitude+0.001 },
   });
              
   mapPolyline.StrokeColor = Colors.Black;
   mapPolyline.StrokeThickness = 3;
   mapPolyline.StrokeDashed = true;
   myMap.MapElements.Add(mapPolyline);
}
```

## Xxx XXXX


Xxxxxxx xxxxxx XX xxxxxxxx xx xxx xxx xxxxx XXXX. Xxxxxxxx XXXX xx xxx xxx xx xxxxxxxxxx xxx xxxxxxxx xxx xxxxxxxxxx xxxxxx xxxxx xx xxx XXXX.

-   Xxx xxx xxxxxxxx xx xxx xxx xxxxx xxx XXXX xx xxxxxx xx xxxxxxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/desktop/ms704369).
-   Xxx xxx xxxxxxxx xxxxxxxx xx xxx XXXX xxxx xxxxxxxxxxx xx xxx xxxxxxxxx xxxxxxxx xx xxxxxxx [**XxxXxxxxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637050).

Xxx xxxxxxxxx xxxxxxx xxxxx x xxx xx xxx xxxx xx Xxxxxxx xxx xxxx x XXXX [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209250) xxxxxxx xx xxxxxxxx xxx xxxxxxxx xx xxx Xxxxx Xxxxxx. Xx xxxx xxxxxxx xxx xxx xxxx xxx xxxx xxx xxxxx xx. Xxx xxxxxxx xxxx xxxxx xxxxx xxx xxx xxxxxxx, xxx [Xxxxxxx xxxx xxxx YX, YX, xxx Xxxxxxxxxx xxxxx](display-maps.md).

```csharp
private void displayXAMLButton_Click(object sender, RoutedEventArgs e)
{
   // Specify a known location.
   BasicGeoposition snPosition = new BasicGeoposition() { Latitude = 47.620, Longitude = -122.349 };
   Geopoint snPoint = new Geopoint(snPosition);

   // Create a XAML border.
   Border border = new Border
   {
      Height = 100,
      Width = 100,
      BorderBrush = new SolidColorBrush(Windows.UI.Colors.Blue),
      BorderThickness = new Thickness(5),
   };

   // Center the map over the POI.
   MapControl1.Center = snPoint;
   MapControl1.ZoomLevel = 14;

   // Add XAML to the map.
   MapControl1.Children.Add(border);
   MapControl.SetLocation(border, snPoint);
   MapControl.SetNormalizedAnchorPoint(border, new Point(0.5, 0.5));
}
```

Xxxx xxxxxxx xxxxxxxx x xxxx xxxxxx xx xxx xxx.

![](images/displaypoixaml.png)

Xxx xxxx xxxxxxxx xxxx xxx xx xxx XXXX XX xxxxxxxx xxxxxxxx xx xxx XXXX xxxxxx xx xxx xxxx xxxxx xxxx xxxxxxx. Xx xxxx xxxxx XXXX xxxxxxxx xxxx xxxxxxx xxxxxxx, [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637008) xx xxx xxxxxxx xxxxxxx xxxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004) xxx xxxx xxx xxxx xx xx xxxxxxxxx xxxxxxxxxx xx XXXX xxxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxxxxxx xxx XXXX xxxxxxxx xx xxxxxxxx xxxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004).

```xaml
<maps:MapControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{Binding SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{Binding BellevueLocation}"/>
</maps:MapControl>
```

Xxxx xxxxxxx xxxxx xxx xx xxxxxxx xxx XXXX xxxxxxxx xxxxxxxxx xxxxxx x [**XxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637094).

```xaml
<maps:MapControl>
  <maps:MapItemsControl>
    <TextBox Text="Seattle" maps:MapControl.Location="{Binding SeattleLocation}"/>
    <TextBox Text="Bellevue" maps:MapControl.Location="{Binding BellevueLocation}"/>
  </maps:MapItemsControl>
</maps:MapControl>
```

Xxxx xxxxxxx xxxxxxxx x xxxxxxxxxx xx XXXX xxxxxxxx xxxxx xx x [**XxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637094).

```xaml
<maps:MapControl x:Name="MapControl" MapTapped="MapTapped" MapDoubleTapped="MapTapped" MapHolding="MapTapped">
  <maps:MapItemsControl ItemsSource="{Binding StateOverlays}">
    <maps:MapItemsControl.ItemTemplate>
      <DataTemplate>
        <StackPanel Background="Black" Tapped="Overlay_Tapped">
          <TextBlock maps:MapControl.Location="{Binding Location}" Text="{Binding Name}" maps:MapControl.NormalizedAnchorPoint="0.5,0.5" FontSize="20" Margin="5"/>
        </StackPanel>
      </DataTemplate>
    </maps:MapItemsControl.ItemTemplate>
  </maps:MapItemsControl>
</maps:MapControl>
```

## Xxxxxxx xxxxxx

* [Xxxx Xxxx Xxxxxxxxx Xxxxxx](https://www.bingmapsportal.com/)
* [XXX xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [Xxxxxx xxxxxxxxxx xxx xxxx](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Xxxxx YYYY xxxxx: Xxxxxxxxxx Xxxx xxx Xxxxxxxx Xxxxxx Xxxxx, Xxxxxx, xxx XX xx Xxxx Xxxxxxx Xxxx](https://channel9.msdn.com/Events/Build/2015/2-757)
* [XXX xxxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**XxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637077)
* [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637103)
* [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637114)


<!--HONumber=Mar16_HO1-->
