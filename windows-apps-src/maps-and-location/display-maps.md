---
xxxxx: 'Xxxxxxx xxxx xxxx YX, YX, xxx Xxxxxxxxxx xxxxx'
xxxxxxxxxxx: Xxxxxxx xxxxxxxxxxxx xxxx xx xxxx xxx xx xxxxx xxx XxxXxxxxxx xxxxx. Xxxx xxxxx xxxx xxxxxxxxxx xxxxxx YX xxx Xxxxxxxxxx xxxxx.
xx.xxxxxxx: YYYYXYYX-YXYX-YYYY-XYYX-YXXXYYXYYYYX
---

# Xxxxxxx xxxx xxxx YX, YX, xxx Xxxxxxxxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxx xxxxxxxxxxxx xxxx xx xxxx xxx xx xxxxx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004) xxxxx. Xxxx xxxxx xxxx xxxxxxxxxx xxxxxx YX xxx Xxxxxxxxxx xxxxx.

**Xxx** Xx xxxxx xxxx xxxxx xxxxx xxxx xx xxxx xxx, xxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

-   [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## Xxx xxx xxx xxxxxxx xx xxxx xxx


Xxxxxxx x xxx xx x XXXX xxxx xx xxxxxx x [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004). Xx xxx xxx **XxxXxxxxxx**, xxx xxxx xxxxxxx xxx [**Xxxxxxx.XX.Xxxx.Xxxxxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn610751) xxxxxxxxx xx xxx XXXX xxxx xx xx xxxx xxxx. Xx xxx xxxx xxx xxxxxxx xxxx xxx Xxxxxxx, xxxx xxxxxxxxx xxxxxxxxxxx xx xxxxx xxxxxxxxxxxxx. Xx xxx xxx xxx **XxxXxxxxxx** xx xxx XXXX xxxx xxxxxxxx, xxx xxxx xxx xxx xxxxxxxxx xxxxxxxxxxx xxxxxxxx xx xxx xxx xx xxx xxxx.

Xxx xxxxxxxxx xxxxxxx xxxxxxxx x xxxxx xxx xxxxxxx xxx xxxxxxxxxx xxx xxx xx xxxxxxx xxx xxxx xxx xxxx xxxxxxxx xx xxxxxxxx xx xxxxxxxxx xxxxx xxxxxx. Xxx xxxx xxxx xxxxx xxxxxxxxxxx xxx xxxxxxxxxx xx xxx xxx, xxx [Xxxxxxxxx xxx xxx](#mapconfig).

```xaml
<Page
    x:Class="MapsAndLocation1.DisplayMaps"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:MapsAndLocation1"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    xmlns:Maps="using:Windows.UI.Xaml.Controls.Maps"
    mc:Ignorable="d">

 <Grid x:Name="pageGrid" Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">

    <Maps:MapControl
       x:Name="MapControl1"            
       ZoomInteractionMode="GestureAndControl"
       TiltInteractionMode="GestureAndControl"   
       MapServiceToken="EnterYourAuthenticationKeyHere"/>
  
 </Grid>
</Page>
```

Xx xxx xxx xxx xxx xxxxxxx xx xxxx xxxx, xxx xxxx xxxxxxx xxx xxxxxxxxx xxxxxxxx xx xxx xxx xx xxx xxxx xxxx.

```csharp
using Windows.UI.Xaml.Controls.Maps;
...

// Add the MapControl and the specify maps authentication key.
MapControl MapControl2 = new MapControl();
MapControl2.ZoomInteractionMode = MapInteractionMode.GestureAndControl;
MapControl2.TiltInteractionMode = MapInteractionMode.GestureAndControl;
MapControl2.MapServiceToken = "EnterYourAuthenticationKeyHere";
pageGrid.Children.Add(MapControl2);
```

## Xxx xxx xxx x xxxx xxxxxxxxxxxxxx xxx


Xxxxxx xxx xxx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004) xxx xxx xxxxxxxx, xxx xxxx xxxxxxx xxx xxxx xxxxxxxxxxxxxx xxx xx xxx xxxxx xx xxx [**XxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637036) xxxxxxxx. Xx xxx xxxxxxxx xxxxxxxx, xxxxxxx `EnterYourAuthenticationKeyHere` xxxx xxx xxx xxx xxx xxxx xxx [Xxxx Xxxx Xxxxxxxxx Xxxxxx](https://www.bingmapsportal.com/). Xxx xxxx **Xxxxxxx: XxxXxxxxxxXxxxx xxx xxxxxxxxx** xxxxxxxxx xx xxxxxx xxxxx xxx xxxxxxx xxxxx xxx xxxxxxx xxx xxxx xxxxxxxxxxxxxx xxx. Xxx xxxx xxxx xxxxx xxxxxxx xxx xxxxxxx x xxxx xxxxxxxxxxxxxx xxx, xxx [Xxxxxxx x xxxx xxxxxxxxxxxxxx xxx](authentication-key.md).

## Xxx x xxxxxxxx xxxxxxxx xxx xxx xxx


Xxx xxx xxxxxxxx xx xxxxxxx xx xxx xxx xx xxxxxxxxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637005) xxxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004) xx xxxx xxxx xx xx xxxxxxx xxx xxxxxxxx xx xxxx XXXX xxxxxx. Xxx xxxxxxxxx xxxxxxx xxxxxxxx x xxx xxxx xxx xxxx xx Xxxxxxx xx xxx xxxxxx.

**Xxx**  Xxxxx x xxxxxx xxx'x xx xxxxxxxxx xx x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263675), xxx xxx'x xxxxxxx x xxxxx xxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637005) xxxxxxxx xx XXXX xxxxxx xxxxxx xxx xxx xxxx xxxxxxx. (Xxxx xxxxxxxxxx xxxx xxxxxxx xx xxx [**XxxXxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn653264) xxxxxxxx xxxxxxxx.)

 

```csharp
protected override void OnNavigatedTo(NavigationEventArgs e)
{
   // Specify a known location.
   BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };
   Geopoint cityCenter = new Geopoint(cityPosition);

   // Set the map location.
   MapControl1.Center = cityCenter;
   MapControl1.ZoomLevel = 12;
   MapControl1.LandmarksVisible = true;
}
```

![xx xxxxxxx xx xxx xxx xxxxxxx.](images/displaymapsexample1.png)

## Xxx xxx xxxxxxx xxxxxxxx xx xxx xxx


Xxxxxx xxxx xxx xxx xxxxxx xxx xxxx’x xxxxxxxx, xxxx xxx xxxx xxxx xxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn859152) xxxxxx. Xx xxxx xxxx, xxxx xxx xxxx xx xx xxx xxxxxxxxxx xxx **XxxxxxxXxxxxxXxxxx** xxxx xx xxxxxx xxxx xxx XX xxxxxx. Xxxxx xxx xxxx xxxxxx xxxx xxx xxxxxxxxxx xx xxxxx xxxxxxxx, xxxx xxx xxx'x xxxxxx xxxxxxxx xxxx.

Xxx xxx xxxxxxx xxxxxxxx xx xxx xxxxxx (xx xxxxxxxx xx xxxxxxxxx) xx xxxxx xxx [**XxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh973536) xxxxxx xx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225534) xxxxx. Xx xxxxxx xxx xxxxxxxxxxxxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263675), xxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263665) xxxxxxxx xx xxx xxxxxxxxxxx'x xxxxxxxxxxxxx. Xxx xxxx xxxx, xxx [Xxx xxxxxxx xxxxxxxx](get-location.md).

```csharp
// Set your current location.
var accessStatus = await Geolocator.RequestAccessAsync();
switch (accessStatus)
{
   case GeolocationAccessStatus.Allowed:

      // Get the current location.
      Geolocator geolocator = new Geolocator();
      Geoposition pos = await geolocator.GetGeopositionAsync();
      Geopoint myLocation = pos.Coordinate.Point;

      // Set the map location.
      MapControl1.Center = myLocation;
      MapControl1.ZoomLevel = 12;
      MapControl1.LandmarksVisible = true;
      break;

   case GeolocationAccessStatus.Denied:
      // Handle the case  if access to location is denied.
      break;

   case GeolocationAccessStatus.Unspecified:
      // Handle the case if  an unspecified error occurs.
      break;
}
```

Xxxx xxx xxxxxxx xxxx xxxxxx'x xxxxxxxx xx x xxx, xxxxxxxx xxxxxxxxxx xxxxxxxx xxx xxxxxxx xxx xxxx xxxxx xxxxx xx xxx xxxxxxxx xx xxx xxxxxxxx xxxx. Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxx xxxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh465148).

## Xxxxxx xxx xxxxxxxx xx xxx xxx


Xx xxxxxx xxx xxxxxxxx xxxx xxxxxxx xx x YX xxx, xxxx xxx xx xxx xxxxxxxxx xx xxx [**XxxXxxXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637060) xxxxxx. Xxx xxxx xxxxxx xx xxxxxxx xxx xxxxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637005), [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637068), [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637019), xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637044). Xxx xxx xxxx xxxxxxx xx xxxxxxxx xxxxxxxxx xx xxx xxxx xxx xxxx xxxxxxx xx xxxxxxxxx x xxxxxxxx xxxx xxx [**XxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637002) xxxxxxxxxxx.

Xx xxxxxx xxx xxxxxxxx xx x YX xxx, xxx xxx [**XxxXxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974296) xxxxxx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxx YX xxxxx](#display3d).

Xxxx xxx [**XxxXxxXxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637065) xxxxxx xx xxxxxxx xxx xxxxxxxx xx x [**XxxxxxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn607949) xx xxx xxx. Xxx xxxx xxxxxx, xxx xxxxxxx, xx xxxxxxx x xxxxx xx x xxxxxxx xx x xxxxx xx xxx xxx. Xxx xxxx xxxx, xxx [Xxxxxxx xxxxxx xxx xxxxxxxxxx xx x xxx](routes-and-directions.md).

## Xxxxxxxxx xxx xxx


Xxxxxxxxx xxx xxx xxx xxx xxxxxxxxxx xx xxxxxxx xxx xxxxxx xx xxx xxxxxxxxx xxxxxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004).

**Xxx xxxxxxxx**

-   Xxx xxx **xxxxxx** xx xxx xxx xx x xxxxxxxxxx xxxxx xx xxxxxxx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637005) xxxxxxxx.
-   Xxx xxx **xxxx xxxxx** xx xxx xxx xx xxxxxxx xxx [**XxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637068) xxxxxxxx xx x xxxxx xxxxxxx Y xxx YY.
-   Xxx xxx **xxxxxxxx** xx xxx xxx xx xxxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637019) xxxxxxxx, xxxxx Y xx YYY xxxxxxx = Xxxxx, YY = Xxxx, YYY = Xxxxx, xxx YYY = Xxxx.
-   Xxx xxx **xxxx** xx xxx xxx xx xxxxxxx xxx [**XxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637012) xxxxxxxx xx x xxxxx xxxxxxx Y xxx YY xxxxxxx.

**Xxx xxxxxxxxxx**

-   Xxxxxxx xxx **xxxx** xx xxx - xxx xxxxxxx, x xxxx xxx xx xx xxxxxx xxx - xx xxxxxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637051) xxxxxxxx xxxx xxx xx xxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637127) xxxxxxxxx.
-   Xxx xxx **xxxxx xxxxxx** xx xxx xxx xx xxxxx xx xxxx xx xxxxxxx xxx [**XxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637010) xxxxxxxx xxxx xxx xx xxx [**XxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637003) xxxxxxxxx.

Xxxx xxxxxxxxxxx xx xxx xxx xx xxxxxxx xxx xxxxxx xx xxx xxxxxxxxx xxxxxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004).

-   Xxxxxxx **xxxxxxxxx xxx xxxxxxxxx** xx xxx xxx xx xxxxxxxx xx xxxxxxxxx xxx [**XxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637023) xxxxxxxx.
-   Xxxxxxx **xxxxxxxxxx xxxxxxxx** xxxx xx xxxxxx xxxxxx xx xxx xxx xx xxxxxxxx xx xxxxxxxxx xxx [**XxxxxxxxxxXxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637042) xxxxxxxx.
-   Xxxxxxx **xxxxxxx** xx xxx xxx xx xxxxxxxx xx xxxxxxxxx xxx [**XxxxxxxXxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637055) xxxxxxxx.
-   Xxxxxxx xxxxxxx xxx **xxxxxxxxx** xx xxxxxxxxx xx xxx xxx xx xxxxxxx xxx [**XxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637066) xxxxxxxx xx xxx xx xxx [**XxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn610749) xxxxxxxxx.
-   Xxxxxxx x **xxxxxxx xx xxxxxxx xxxxx** xx xxx xxx xx xxxxxx x [**XxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637122) xx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637047) xxxxxxxxxx xx xxx Xxx xxxxxxx. Xxx xxxx xxxx xxx xx xxxxxxx, xxx [Xxxxxxx xxxxxx xxx xxxxxxxxxx xx x xxx](routes-and-directions.md).

Xxx xxxx xxxxx xxx xx xxxxxxx xxxxxxxx, xxxxxx, xxx XXXX xxxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004), xxx [Xxxxxxx xxxxxx xx xxxxxxxx (XXX) xx x xxx](display-poi.md).

## Xxxxxxx Xxxxxxxxxx xxxxx


X Xxxxxxxxxx xxxx xx x xxxxxx-xxxxx xxxxxxxxxxx xx x xxxxxxxx xxxx xxxxxxx xx xxx xx xxx xxx xxxxxxx.

![xx xxxxxxx xx x xxxxxxxxxx xxxx xx xxx xxx xxxxxxx.](images/onlystreetside-730width.png)

Xxxxxxxx xxx xxxxxxxxxx "xxxxxx" xxx Xxxxxxxxxx xxxx xxxxxxxx xxxx xxx xxx xxxxxxxxxx xxxxxxxxx xx xxx xxx xxxxxxx. Xxx xxxxxxx, xxxxxxxx xxx xxxxxxxx xx xxx Xxxxxxxxxx xxxx xxxx xxx xxxxxx xxx xxxxxxxx xx xxxxxxxxxx xx xxx xxx "xxxxx" xxx Xxxxxxxxxx xxxx. Xxxxx xxx xxxxx xxx Xxxxxxxxxx xxxx (xx xxxxxxxx xxx **X** xx xxx xxxxx xxxxx xxxxxx xx xxx xxxxxxx), xxx xxxxxxxx xxx xxxxxxx xxxxxxxxx.

Xx xxxxxxx x Xxxxxxxxxx xxxx

1.  Xxxxxxxxx xx Xxxxxxxxxx xxxxx xxx xxxxxxxxx xx xxx xxxxxx xx xxxxxxxx [**XxXxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974271).
2.  Xx Xxxxxxxxxx xxxx xx xxxxxxxxx, xxxxxx x [**XxxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974360) xxxx xxx xxxxxxxxx xxxxxxxx xx xxxxxxx [**XxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974361).
3.  Xxxxxxxxx xx x xxxxxx xxxxxxxx xxx xxxxx xx xxxxxxxx xx xxx [**XxxxxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974360) xx xxx xxxx
4.  Xx x xxxxxx xxxxxxxx xxx xxxxx, xxxxxx x [**XxxxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974356) xxx xxx xxx xxxxxxx'x [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974263) xxxxxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxxxxxx x Xxxxxxxxxx xxxx xxxxxxx xx xxx xxxxxxxx xxxxx.

**Xxxx**  Xxx xxxxxxxx xxx xxxx xxx xxxxxx xx xxx xxx xxxxxxx xx xxxxx xxx xxxxx.

 

```csharp
private async void showStreetsideView()
{
   // Check if Streetside is supported.
   if (MapControl1.IsStreetsideSupported)
   {
      // Find a panorama near Avenue Gustave Eiffel.
      BasicGeoposition cityPosition = new BasicGeoposition() { Latitude = 48.858, Longitude = 2.295};
      Geopoint cityCenter = new Geopoint(cityPosition);
      StreetsidePanorama panoramaNearCity = await StreetsidePanorama.FindNearbyAsync(cityCenter);

      // Set the Streetside view if a panorama exists.
      if (panoramaNearCity != null)
      {
         // Create the Streetside view.
         StreetsideExperience ssView = new StreetsideExperience(panoramaNearCity);
         ssView.OverviewMapVisible = true;
         MapControl1.CustomExperience = ssView;
      }
   }
   else
   {
      // If Streetside is not supported
      ContentDialog viewNotSupportedDialog = new ContentDialog()
      {
         Title = "Streetside is not supported",
         Content ="\nStreetside views are not supported on this device.",
         PrimaryButtonText = "OK"
      };
      await viewNotSupportedDialog.ShowAsync();            
   }
}
```

## Xxxxxxx xxxxxx YX xxxxx


Xxxxxxx x YX xxxxxxxxxxx xx xxx xxx xx xxxxx xxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974329) xxxxx. Xxx xxx xxxxx xxxxxxxxxx xxx YX xxxx xxxx xxxxxxx xx xxx xxx. Xxx [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974244) xxxxx xxxxxxxxxx xxx xxxxxxxx xx xxx xxxxxx xxxx xxxxx xxxxxxx xxxx x xxxx.

![](images/mapcontrol-techdiagram.png)

Xx xxxx xxxxxxxxx xxx xxxxx xxxxxxxx xx xxx xxx xxxxxxx xxxxxx xx YX, xxx xxx xxx xxxxxxx'x [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637051) xxxxxxxx xx [**XxxXxxxx.XxxxxxYXXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637127). Xxxx xx xx xxxxxxx xx x YX xxxx xxxx xxx **XxxxxxYXXxxxXxxxx** xxxxx.

![xx xxxxxxx xx x Yx xxx xxxx.](images/only3d-730width.png)

Xx xxxxxxx x YX xxxx

1.  Xxxxxxxxx xx YX xxxxx xxx xxxxxxxxx xx xxx xxxxxx xx xxxxxxxx [**XxYXXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974265).
2.  Xx YX xxxxx xx xxxxxxxxx, xxx xxx xxx xxxxxxx'x [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637051) xxxxxxxx xx [**XxxXxxxx.XxxxxxYXXxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637127).
3.  Xxxxxx x [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974329) xxxxxx xxxxx xxx xx xxx xxxx **XxxxxxXxxx** xxxxxxx, xxxx xx [**XxxxxxXxxxXxxxxxxxXxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974336) xxx [**XxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974334).
4.  Xxxx [**XxxXxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn974296) xx xxxxxxx xxx YX xxxx. Xxx xxx xxxx xxxxxxx xx xxxxxxxx xxxxxxxxx xx xxx xxxx xxx xxxx xxxxxxx xx xxxxxxxxx x xxxxxxxx xxxx xxx [**XxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637002) xxxxxxxxxxx.

Xxxx xxxxxxx xxxxx xxx xx xxxxxxx x YX xxxx.

```csharp
private async void display3DLocation()
{
   if (MapControl1.Is3DSupported)
   {
      // Set the aerial 3D view.
      MapControl1.Style = MapStyle.Aerial3DWithRoads;

      // Specify the location.
      BasicGeoposition hwGeoposition = new BasicGeoposition() { Latitude = 34.134, Longitude = -118.3216};
      Geopoint hwPoint = new Geopoint(hwGeoposition);

      // Create the map scene.
      MapScene hwScene = MapScene.CreateFromLocationAndRadius(hwPoint,
                                                                           80, /* show this many meters around */
                                                                           0, /* looking at it to the North*/
                                                                           60 /* degrees pitch */);
      // Set the 3D view with animation.
      await MapControl1.TrySetSceneAsync(hwScene,MapAnimationKind.Bow);
   }
   else
   {
      // If 3D views are not supported, display dialog.
      ContentDialog viewNotSupportedDialog = new ContentDialog()
      {
         Title = "3D is not supported",
         Content = "\n3D views are not supported on this device.",
         PrimaryButtonText = "OK"
      };
      await viewNotSupportedDialog.ShowAsync();
   }
}
```

## Xxx xxxx xxxxx xxxxxxxxx xxx xxxxxxxx


Xxx xxxx xxxxx xxxxxxxxx xx xxx xxx xx xxxxxxx xxx xxxxxxxxx xxxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004).

-   [
            **XxxXxxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637016) xxxxxx - Xxx xxx xxxxxxxxxx xxxxxxxx xxxx xxxxxxxxxxx xx xxx xxxxxxxxx xxxxx xx xxx xxxxxxxx xx xxx Xxx xxxxxxx.
-   [
            **XxxXxxxxxXxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637018) xxxxxx - Xxx xxx xxxxx xx xxx xxxxxxxx xx xxx Xxx xxxxxxx xxxx xxxxxxxxxxx xx xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx.
-   [
            **XxXxxxxxxxXxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637022) xxxxxx - Xxxxxxxxx xxxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxxxxxx xx xxxxxxxxx xxxxxxx xx xxx xxxxxxxx xx xxx Xxx xxxxxxx.
-   [
            **XxxxXxxXxxxxxxxXxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637014) xxxxxx - Xxx xxx xxxxxxxx xx xxx xxx xxxxxxx xx xxx xxxxxxxxx xxxxx xx xxx xxxxxxxx xx xxx Xxx xxxxxxx.

## Xxxxxx xxxx xxxxxxxxxxx xxx xxxxxxx


Xxxxxx xxxx xxxxx xxxxxxxx xx xxx xxx xx xxxxxxxx xxx xxxxxxxxx xxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004). Xxx xxxx xxxxx xxx xxxxxxxxxx xxxxxxxx xx xxx xxx xxx xxx xxxxxxxx xxxxxxxx xx xxx xxxxxxxx xxxxx xxx xxxxxxx xxxxxxxx xx xxxxxxxx xxx xxxxxx xx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637091) xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637093) xxxxxxxxxx xx xxx [**XxxXxxxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637090).

-   [**XxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637038)
-   [**XxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637032)
-   [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637035)

Xxxxxxxxx xxxxxxx xxx xxx xx xxxxxxx xx xxxxxxxxxx xxxxxx xx xxxxxxxx xxx xxxxxxx'x [**XxxxxxxXxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637028) xxxxx.

Xxxxxx xxxxxxx xxxx xxxxxx xxxx xxx xxxx xx xxx xxx xxxxxxx xxx xxxxxxxx xx xxx xxx xx xxxxxxxx xxx xxxxxxxxx xxxxxx xx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004). [Xxxxxxxxxx xxx xxxx](https://msdn.microsoft.com/library/windows/apps/dn596102)

-   [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637006)
-   [**XxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637020)
-   [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637045)
-   [**XxxxXxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637069)

## Xxxxxxx xxxxxx

* [Xxxx Xxxx Xxxxxxxxx Xxxxxx](https://www.bingmapsportal.com/)
* [XXX xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [Xxx xxxxxxx xxxxxxxx](get-location.md)
* [Xxxxxx xxxxxxxxxx xxx xxxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh465148)
* [Xxxxxx xxxxxxxxxx xxx xxxx](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Xxxxx YYYY xxxxx: Xxxxxxxxxx Xxxx xxx Xxxxxxxx Xxxxxx Xxxxx, Xxxxxx, xxx XX xx Xxxx Xxxxxxx Xxxx](https://channel9.msdn.com/Events/Build/2015/2-757)
* [XXX xxxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004)


<!--HONumber=Mar16_HO1-->
