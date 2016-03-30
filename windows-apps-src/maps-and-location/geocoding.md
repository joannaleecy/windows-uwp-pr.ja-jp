---
xxxxx: Xxxxxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxx
xxxxxxxxxxx: Xxxxxxx xxxxxxxxx xx xxxxxxxxxx xxxxxxxxx (xxxxxxxxx) xxx xxxxxxx xxxxxxxxxx xxxxxxxxx xx xxxxxxxxx (xxxxxxx xxxxxxxxx) xx xxxxxxx xxx xxxxxxx xx xxx XxxXxxxxxxxXxxxxx xxxxx xx xxx Xxxxxxx.Xxxxxxxx.Xxxx xxxxxxxxx.
xx.xxxxxxx: XYYYXXYY-YXYX-YYXX-YYYX-YXYYYYYYYYXY
---

# Xxxxxxx xxxxxxxxx xxx xxxxxxx xxxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxx xxxxxxxxx xx xxxxxxxxxx xxxxxxxxx (xxxxxxxxx) xxx xxxxxxx xxxxxxxxxx xxxxxxxxx xx xxxxxxxxx (xxxxxxx xxxxxxxxx) xx xxxxxxx xxx xxxxxxx xx xxx [**XxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627550) xxxxx xx xxx [**Xxxxxxx.Xxxxxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/dn636979) xxxxxxxxx.

**Xxx** Xx xxxxx xxxx xxxxx xxxxx xxxx xx xxxx xxx, xxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

-   [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)

Xxxx'x xxx xxx xxxxxxx xxx xxxxxxxxx xxx xxxxxxx xxxxxxxxx xxx xxxxxxx:

-   Xxx [**XxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627550) xxxxx xxx xxxxxxx xxxx xx xxxxxxxxx ([**XxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636925)) xxx xxxxxxx xxxxxxxxx ([**XxxxXxxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636928)).
-   Xxxxx xxxxxxx xxxxxx x [**XxxXxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627551).
-   Xxx [**XxxXxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627551) xxxxxxxx x xxxxxxxxxx xx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627549) xxxxxxx. Xxxxxx xxxx xxxxxxxxxx xxxxxxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627552) xxxxxxxx xx xxx **XxxXxxxxxxxXxxxxxXxxxxx**.
-   Xxxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627549) xxxxxx xxxxxxxx x [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627533) xxxxxx. Xxxxxx xxxx xxxxxx xxxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636929) xxxxxxxx xx xxxx **XxxXxxxxxxx**.

**Xxxxxxxxx**  Xxx xxxx xxxxxxx x xxxx xxxxxxxxxxxxxx xxx xxxxxx xxx xxx xxx xxx xxxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxx x xxxx xxxxxxxxxxxxxx xxx](authentication-key.md).

 

## Xxx x xxxxxxxx (Xxxxxxx)


Xxxxxxx xx xxxxxxx xx x xxxxx xxxx xx x xxxxxxxxxx xxxxxxxx (xxxxxxxxx) xx xxxxxxxxxx xxx xxxxxxxxx xxxxx.

1.  Xxxx xxx xx xxx xxxxxxxxx xx xxx [**XxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636925) xxxxxx xx xxx [**XxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627550) xxxxx.
2.  Xxx [**XxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636925) xxxxxx xxxxxxx x [**XxxXxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627551) xxxxxx xxxx xxxxxxxx x xxxxxxxxxx xx xxxxxxxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627549) xxxxxxx.
3.  Xxxxxx xxxx xxxxxxxxxx xxxxxxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627552) xxxxxxxx xx xxx [**XxxXxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627551).

```csharp
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
...
private async void geocodeButton_Click(object sender, RoutedEventArgs e)
{
   // The address or business to geocode.
   string addressToGeocode = "Microsoft";

   // The nearby location to use as a query hint.
   BasicGeoposition queryHint = new BasicGeoposition();
   queryHint.Latitude = 47.643;
   queryHint.Longitude = -122.131;
   Geopoint hintPoint = new Geopoint(queryHint);

   // Geocode the specified address, using the specified reference point
   // as a query hint. Return no more than 3 results.
   MapLocationFinderResult result =
         await MapLocationFinder.FindLocationsAsync(
                           addressToGeocode,
                           hintPoint,
                           3);

   // If the query returns results, display the coordinates
   // of the first result.
   if (result.Status == MapLocationFinderStatus.Success)
   {
      tbOutputText.Text = "result = (" +
            result.Locations[0].Point.Position.Latitude.ToString() + "," +
            result.Locations[0].Point.Position.Longitude.ToString() + ")";
   }
}
```

Xxxx xxxx xxxxxxxx xxx xxxxxxxxx xxxxxxx xx xxx `tbOutputText` xxxxxxx.

``` syntax
result = (47.6406099647284,-122.129339994863)
```

## Xxx xx xxxxxxx (xxxxxxx xxxxxxx)


Xxxxxxx x xxxxxxxxxx xxxxxxxx xx xx xxxxxxx (xxxxxxx xxxxxxxxx) xx xxxxxxxxxx xxx xxxxxxxxx xxxxx.

1.  Xxxx xxx [**XxxxXxxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636928) xxxxxx xx xxx [**XxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627550) xxxxx.
2.  Xxx [**XxxxXxxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636928) xxxxxx xxxxxxx x [**XxxXxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627551) xxxxxx xxxx xxxxxxxx x xxxxxxxxxx xx xxxxxxxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627549) xxxxxxx.
3.  Xxxxxx xxxx xxxxxxxxxx xxxxxxx xxx [**Xxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627552) xxxxxxxx xx xxx [**XxxXxxxxxxxXxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627551).
4.  Xxxxxx xxx [**XxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627533) xxxxxx xxxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636929) xxxxxxxx xx xxxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627549).

```csharp
using Windows.Services.Maps;
using Windows.Devices.Geolocation;
...
private async void reverseGeocodeButton_Click(object sender, RoutedEventArgs e)
{
   // The location to reverse geocode.
   BasicGeoposition location = new BasicGeoposition();
   location.Latitude = 47.643;
   location.Longitude = -122.131;
   Geopoint pointToReverseGeocode = new Geopoint(location);

   // Reverse geocode the specified geographic location.
   MapLocationFinderResult result =
         await MapLocationFinder.FindLocationsAtAsync(pointToReverseGeocode);

   // If the query returns results, display the name of the town
   // contained in the address of the first result.
   if (result.Status == MapLocationFinderStatus.Success)
   {
      tbOutputText.Text = "town = " +
            result.Locations[0].Address.Town;
   }
}
```

Xxxx xxxx xxxxxxxx xxx xxxxxxxxx xxxxxxx xx xxx `tbOutputText` xxxxxxx.

``` syntax
town = Redmond
```

## Xxxxxxx xxxxxx

* [Xxxx Xxxx Xxxxxxxxx Xxxxxx](https://www.bingmapsportal.com/)
* [XXX xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [Xxxxxx xxxxxxxxxx xxx xxxx](https://msdn.microsoft.com/library/windows/apps/dn596102)
* [Xxxxx YYYY xxxxx: Xxxxxxxxxx Xxxx xxx Xxxxxxxx Xxxxxx Xxxxx, Xxxxxx, xxx XX xx Xxxx Xxxxxxx Xxxx](https://channel9.msdn.com/Events/Build/2015/2-757)
* [XXX xxxxxxx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619982)
* [**XxxXxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn627550)
* [**XxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636925)
* [**XxxxXxxxxxxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn636928)


<!--HONumber=Mar16_HO1-->
