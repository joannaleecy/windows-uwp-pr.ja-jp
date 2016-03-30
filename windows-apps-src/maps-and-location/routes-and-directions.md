---
xxxxx: Xxxxxxx xxxxxx xxx xxxxxxxxxx xx x xxx
xxxxxxxxxxx: Xxxxxxx xxxxxx xxx xxxxxxxxxx, xxx xxxxxxx xxxx xx xxxx xxx.
xx.xxxxxxx: XXXYXYYX-YXYY-YYXY-YYXX-YYYXXYYXXXYY
---

# Xxxxxxx xxxxxx xxx xxxxxxxxxx xx x xxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxx xxxxxx xxx xxxxxxxxxx, xxx xxxxxxx xxxx xx xxxx xxx.

**Xxx** Xx xxxxx xxxx xxxxx xxxxx xxxx xx xxxx xxx, xxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

-   [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)

**Xxx**  Xx xxxxxxx xxx'x x xxxx xxxxxxx xx xxxx xxx, xxxxxxxx xxxxxxxxx xxx Xxxxxxx Xxxx xxx xxxxxxx. Xxx xxx xxx xxx `bingmaps:`, `ms-drive-to:`, xxx `ms-walk-to:` XXX xxxxxxx xx xxxxxx xxx Xxxxxxx Xxxx xxx xx xxxxxxxx xxxx xxx xxxx-xx-xxxx xxxxxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxx xxx Xxxxxxx Xxxx xxx](https://msdn.microsoft.com/library/windows/apps/mt228341).

 

## Xx xxxxx xx XxxXxxxxXxxxxx xxxxxxx


Xxxx'x xxx xxx xxxxxxx xxx xxxxxx xxx xxxxxxxxxx xxx xxxxxxx:

-   Xxx [**XxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636938) xxxxx xxx xxxxxxx xxxx xxx xxxxxx xxx xxxxxxxxxx.
-   Xxxxx xxxxxxx xxxxxx x [**XxxXxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636939).
-   Xxx [**XxxXxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636939) xxxxxxxx x [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636937) xxxxxx. Xxxxxx xxxx xxxxxx xxxxxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636940) xxxxxxxx xx xxx **XxxXxxxxXxxxxxXxxxxx**.
-   Xxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636937) xxxxxxxx x xxxxxxxxxx xx [**XxxXxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636955) xxxxxxx. Xxxxxx xxxx xxxxxxxxxx xxxxxxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn636973) xxxxxxxx xx xxx **XxxXxxxx**.
-   Xxxx [**XxxXxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636955) xxxxxxxx x xxxxxxxxxx xx [**XxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636961) xxxxxxx. Xxxxxx xxxx xxxxxxxxxx xxxxxxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636959) xxxxxxxx xx xxx **XxxXxxxxXxx**.

## Xxxxxxx xxxxxxxxxx


Xxx x xxxxxxx xx xxxxxxx xxxxx xxx xxxxxxxxxx xx xxxxxxx xxx xxxxxxx xx xxx [**XxxXxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636938) xxxxx—xxx xxxxxxx, [**XxxXxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636943) xx [**XxxXxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636953). Xxx [**XxxXxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636939) xxxxxx xxxxxxxx x [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636937) xxxxxx xxxx xxx xxx xxxxxx xxxxxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636940) xxxxxxxx.

Xxxx xxx xxxxxxx x xxxxx, xxx xxx xxxxxxx xxx xxxxxxxxx xxxxxx:

-   Xxx xxx xxxxxxx x xxxxx xxxxx xxx xxx xxxxx xxxx, xx xxx xxx xxxxxxx x xxxxxx xx xxxxxxxxx xx xxxxxxx xxx xxxxx.
-   Xxx xxx xxxxxxx xxxxxxxxxxxxx - xxx xxxxxxx, xxxxxxxx xxx xxxxxxxx.
-   Xxx xxx xxxxxxx xxxxxxxxxxxx - xxx xxxxxxx, xxxxx xxxxxxxx.

Xxx xxxxxxxx [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636937) xxx xxxxxxxxxx xxxx xxxxxxx xxx xxxx xx xxxxxxxx xxx xxxxx, xxx xxxxxx xx xxx xxxxx, xxx xxx xxxxxxxxxx xx [**XxxXxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn636955) xxxxxxx xxxx xxxxxxx xxx xxxx xx xxx xxxxx. Xxxx **XxxXxxxxXxx** xxxxxx xxxxxxxx x xxxxxxxxxx xx [**XxxXxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636961) xxxxxxx. Xxx **XxxXxxxxXxxxxxxx** xxxxxx xxxxxxxx xxxxxxxxxx xxxx xxx xxx xxxxxx xxxxxxx xxx [**XxxxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn636964) xxxxxxxx.

**Xxxxxxxxx**  Xxx xxxx xxxxxxx x xxxx xxxxxxxxxxxxxx xxx xxxxxx xxx xxx xxx xxx xxxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxx x xxxx xxxxxxxxxxxxxx xxx](authentication-key.md).

 

```csharp
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
...
private async void button_Click(object sender, RoutedEventArgs e)
{
   // Start at Microsoft in Redmond, Washington.
   BasicGeoposition startLocation = new BasicGeoposition() {Latitude=47.643,Longitude=-122.131};

   // End at the city of Seattle, Washington.
   BasicGeoposition endLocation = new BasicGeoposition() {Latitude = 47.604,Longitude= -122.329};

   // Get the route between the points.
   MapRouteFinderResult routeResult =
         await MapRouteFinder.GetDrivingRouteAsync(
         new Geopoint(startLocation),
         new Geopoint(endLocation),
         MapRouteOptimization.Time,
         MapRouteRestrictions.None);

   if (routeResult.Status == MapRouteFinderStatus.Success)
   {
      System.Text.StringBuilder routeInfo = new System.Text.StringBuilder();

      // Display summary info about the route.
      routeInfo.Append("Total estimated time (minutes) = ");
      routeInfo.Append(routeResult.Route.EstimatedDuration.TotalMinutes.ToString());
      routeInfo.Append("\nTotal length (kilometers) = ");
      routeInfo.Append((routeResult.Route.LengthInMeters / 1000).ToString());

      // Display the directions.
      routeInfo.Append("\n\nDIRECTIONS\n");

      foreach (MapRouteLeg leg in routeResult.Route.Legs)
      {
         foreach (MapRouteManeuver maneuver in leg.Maneuvers)
         {
            routeInfo.AppendLine(maneuver.InstructionText);
         }
      }

      // Load the text box.
      tbOutputText.Text = routeInfo.ToString();
   }
   else
   {
      tbOutputText.Text =
            "A problem occurred: " + routeResult.Status.ToString();
   }
}
```

Xxxx xxxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxxx xx xxx `tbOutputText` xxxx xxx.

``` syntax
Total estimated time (minutes) = 18.4833333333333
Total length (kilometers) = 21.847

DIRECTIONS
Head north on 157th Ave NE.
Turn left onto 159th Ave NE.
Turn left onto NE 40th St.
Turn left onto WA-520 W.
Enter the freeway WA-520 from the right.
Keep left onto I-5 S/Portland.
Keep right and leave the freeway at exit 165A towards James St..
Turn right onto James St.
You have reached your destination.
```

## Xxxxxxx xxxxxx


Xx xxxxxxx x [**XxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636937) xx x [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004), xxxxxxxxx x [**XxxXxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn637122) xxxx xxx **XxxXxxxx**. Xxxx, xxx xxx **XxxXxxxxXxxx** xx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637047) xxxxxxxxxx xx xxx **XxxXxxxxxx**.

**Xxxxxxxxx**  Xxx xxxx xxxxxxx x xxxx xxxxxxxxxxxxxx xxx xxxxxx xxx xxx xxx xxx xxxxxxxx xx xxx xxx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxx x xxxx xxxxxxxxxxxxxx xxx](authentication-key.md).

 

```csharp
using System;
using Windows.Devices.Geolocation;
using Windows.Services.Maps;
using Windows.UI;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
...
private async void ShowRouteOnMap()
{
   // Start at Microsoft in Redmond, Washington.
   BasicGeoposition startLocation = new BasicGeoposition() { Latitude = 47.643, Longitude = -122.131 };

   // End at the city of Seattle, Washington.
   BasicGeoposition endLocation = new BasicGeoposition() { Latitude = 47.604, Longitude = -122.329 };


   // Get the route between the points.
   MapRouteFinderResult routeResult =
         await MapRouteFinder.GetDrivingRouteAsync(
         new Geopoint(startLocation),
         new Geopoint(endLocation),
         MapRouteOptimization.Time,
         MapRouteRestrictions.None);

   if (routeResult.Status == MapRouteFinderStatus.Success)
   {
      // Use the route to initialize a MapRouteView.
      MapRouteView viewOfRoute = new MapRouteView(routeResult.Route);
      viewOfRoute.RouteColor = Colors.Yellow;
      viewOfRoute.OutlineColor = Colors.Black;

      // Add the new MapRouteView to the Routes collection
      // of the MapControl.
      MapWithRoute.Routes.Add(viewOfRoute);

      // Fit the MapControl to the route.
      await MapWithRoute.TrySetViewBoundsAsync(
            routeResult.Route.BoundingBox,
            null,
            Windows.UI.Xaml.Controls.Maps.MapAnimationKind.None);
   }
}
```

Xxxx xxxxxxx xxxxxxxx xxx xxxxxxxxx xx x [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn637004) xxxxx **XxxXxxxXxxxx**.

![xxx xxxxxxx xxxx xxxxx xxxxxxxxx.](images/routeonmap.png)

## Xxxxxxx xxxxxx

* [Xxxx Xxxx Xxxxxxxxx Xxxxxx](https://www.bingmapsportal.com/)
* [XXX xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [Xxxxxx xxxxxxxxxx xxx xxxx](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Xxxxx YYYY xxxxx: Xxxxxxxxxx Xxxx xxx Xxxxxxxx Xxxxxx Xxxxx, Xxxxxx, xxx XX xx Xxxx Xxxxxxx Xxxx](https://channel9.msdn.com/Events/Build/2015/2-757)
* [XXX xxxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619982)

<!--HONumber=Mar16_HO1-->
