---
Xxxxxxxxxxx: Xxxxxx xxxxx xxxx xxxxxxxxx xxx xxxxxxxxxx xx xxxx xxx.
xxxxx: Xxxxxxxxxx xxx xxxxxxxxxx xxxx
xx.xxxxxxx: XYYYXXYY-YYYX-YYYY-YYXX-YYXYXYXXXYYY
---

# Xxxxxxxxxx xxx xxxxxxxxxx xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxxxxx xxxxx (XXXX)**](https://msdn.microsoft.com/library/windows/apps/dn263587)
-   [**Xxxxxxxxxx xxxxx (XXXX)**](https://msdn.microsoft.com/library/windows/apps/br225534)

Xxxxxx xxxxx xxxx xxxxxxxxx xxx [**xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263744) xx xxxx xxx.

## Xxxxxxxxxxxxxxx


-   Xx xxxx xxx xxxx xxxx xxxxxxxx xxxxxx xxxx x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263587) xxxxx xxxxxx, xxxxx xxx xxxxxxxx xxxxxx xxxxxx xxxxxxxx xxx xxxxxxxx.
    -   Xx xxx xxx xxxxx'x xxxxxxxxx xxxx xxxxxxxx xxxxxx, xxx xxx xxxxxx xxx xxxx xx xxxxxxx xx xxx xxxxxxxx xxxxxx xxx xxx xx xxx xxxxxxxx.
    -   Xx xxxxxxxx xxxxxx xxx'x xxxxxxxx, xxxxx xxxxxxxxx xxx xxxxx xxxxxxxx xxx xxx xxxxxxxxxx xxxxxxxx xxxxxx.
-   Xxxxxx xxx xxxxxxxxx xx xxxxxxxxxx xxxxxxxxxxxxx xx xxxxxxxx xxx xxxx xxxxx xxx xxxxxxx xxxxxxxx xxxx x xxxxxxxx xxxxx xxxxxxxxx xxxxxxx xx xx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263660) xx **Xxxxxx** xxxxx. Xxx [Xxxxxxxx xxx xxxx xxxxx xxx xxxxxxx xxxxxxxx](#timestamp) xxxxx xxx xxxx xxxxxxxxxxx.
-   Xxxxxx xxxxxxxxxx xx xxxxxx xxxxx xxxx x xxxxxx xxx'x xxxxxx xxxxxxxx xxxx, xxx xxxxxx xxx xxxx xx xxxxxxxxx. Xxxxxxxx xxxx xxx xx xxxxxxxxxxx xxxxxxx xxxxxxxxxxx xxx xxxxxx xxx, xxx xxxxxx xxxxx'x xxxxxxx x XXX xxxxx, xxx XXX xxxxxx xx xxxxxxx, xx xxx Xx-Xx xxxxxx xxx'x xxxxxx xxxxxx.
-   Xx xxxxxxx, xx xxx'x xxxxxxxxx xx xxxxxx xxx xxxxxxxx xxxxxx xx xxx xxxxxxxxxx xxx xxxxxxxxxx xx xxx xxxx xxxx. Xxxxxxx, xx xxxx xxx xxxxx xx xxxxxx xxx xxxxxxxx xxxxxx xx xxxx xxx xxxxxxxxxx xxx xxxxxxxxxx:

    -   Xxxx xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263633) xxxxxx xx xxxx xxx xx xx xxxxx xxx xxxxxxxx.
    -   Xxxxxxxxxx xxxx xxxxxxxxxx xxxxx xxxxxxxx xxxx xxxx xxx xxx'x xxxxxxx xx xxx xxxx xxx xx-xxxxxxxx xxxx xx xxxxxxx xxxxxxx xxxxx.

    Xxx [Xxxxxxxxxx xxx xxxxxxxxxx xxxxxxxxx](#background-and-foreground-listeners) xxx xxxx xxxxxxxx xxx xxxx xxxxxxxxxxx.

-   Xxx'x xxx xxxx xxxx YYYY xxxxxxxxx xxx xxx. Xxx xxxxxx xxxxxxxx xxxxxxxx xxxxxxxxx xx xxxxxxxxx xxx xxx, xxx xxx xxxxxxxx xxxx xxx xxxxxxxxxxx xx xxxx xxxxxx xxx xxx'x xxxxxx xxxxx xx xxxxx xx xxxx xxxx YYYY.
-   Xxx'x xxxxxx x xxxxxxxx xxxx x xxxxxx xxxxxxx xxxx YY xxxxxx. Xx xxxx xxx xxxxx xx xxx x xxxxxxxx xxxx x xxxxx xxxxxx, xxxxxx xxxxx xx xxx xxxx xxx xx x xxxxxx xxxx x XXX xxxxx xx xxxxxx xxx xxxx xxxxxxxxxxx.

## Xxxxxxxxxx xxxxx xxxxxxxx

### Xxxxxxxx xxx xxxx xxxxx xxx xxxxxxx xxxxxxxx

Xxxx xx xxxxx xxxxxxxxx x xxxxxx xx xx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263660) xx **Xxxxxx** xxxxx, xxxxx xxxx xxx xxxx xxxxx xx xxx xxxxx xxx xxxx xxxxxxx xxxxxxxx. Xxxxxxx xxxxxxx, xxxx xx xxx xxxxxx xxx xxxxxx xxxxxx xxxxxxxxx xx xxxxxx x xxxxxxxxxx xxxx, xxx xxxx xxx xxxxxxxx xxx xxxxxxxxxxxx, xx xxx xxxxxx xxxxx xx xxxxxxx (xx Xxxxxxx), xxx xxxxxx xxxx xxx xxxxx xx xxxxxxxx xxxxxxxxx xx xxx xxxx. Xxx xxxxxxx, xxx xxxxxxxxx xxxxxxxx xxx xxxxx:

-   Xxxx xxx xxxxxxx x xxxxxxxx xxx xxxxxxxx xxx xxxxxxxx xxx xxxxx xxx xxxx xxxxxx.
-   Xxx xxxx xxxxx xxx xxxxxx xxxxxx xx xxx xxxxxxxx, xxxxxxx xx xxxxx xxxxx xx xx xxxxxxxxx.
-   Xxxx xxx xxxxx x xxxxxxxxxxxx xx xxx xxxx xxxx xxxx xxx xxx xxxxxx xxx xxxxxxxx.
-   Xxx xxxx xxx xxxx xxx xxxx xxx xxxxxx xxx xxxxxxxxxxxx xxxxx YY xxxxxxx xxxxx.
-   Xxxxxx xxxx YY xxxxxx xxxxx, xxx xxxx xxx xxxxx xxxx xxxxxxx xx xxx xxxxxxxx.

Xxxx xxx xxxxxxxxx, xxx xxx xxxx xxxx xxx xxxxxx xxxxxxxx xx xxx xxxx. Xxxx xxx xxxxxxx xxxxxxxx, xxx xxx xxx xxxx xxx xxxx xx xxx xxxx xxxxxxx xx xxx xxxxxxxx. Xxxxxxxxx xx xxx xxxxxxxxxxxxx xx xxxx xxx, xxx xxx xxxx xx xxxxxx xxx xxxx xxxxx.

### Xxxxxxxxxx xxx xxxxxxxxxx xxxxxxxxx

Xx xxxxxxx, xxxx xxx xxxxx'x xxxx xx xxxxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263587) xxxxxx xxxx xx xxx xxxxxxxxxx xxx xx x xxxxxxxxxx xxxx xx xxx xxxx xxxx. Xxx xxxxxxxx xxxxxx xxx xxxxxxxx x xxxx xxxxx xxx xxxxx xxxx xxxx xx xx xxx xxx xxxxxxxxxx xxxx xxxxxx xxx xxxxxxxxxxxxx. Xx xxx xx xxx xx xxxx xxxxxxxxxx xxx xxxxxxxxxx xxxxxxxx xxxxxxxxx, xxxxx xx xx xxxxxxxxx xxxxx xxxx xx xxxxxxxxx xxxxx xxx xx xxx xxxx xxxxxx xxxx xxx [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263633) xxxxxx xx xxxx xxx xx xx xxxxx xxx xxxxxxxx.

Xx xxx xxxx xxx xx xxxx xxxxxxxxxx xxx xxxxxxxxxx xxxxxxxx xxxxxxxxx, xxx xxxxxx xxxxxxxxxx xxxx xxxxxxxxxx xxxxx xxxxxxxx xxxxxxxx xxxx xxx xx xxx xxxxxxx xx xxx xxxx xxx xx-xxxxxxxx xxxx xxx xxxx xx xxxxxxx xxxxxxx xxxxx. Xxxx'x xxxx xxxxxxx xxxx xxxx xxxxxxxxx xxx xxx xxxxxxxxxx xxxxx.

```csharp
    Windows.UI.Core.CoreWindow coreWindow;    
    
    // This needs to be set before InitializeComponent sets up event registration for app visibility
    coreWindow = CoreWindow.GetForCurrentThread(); 
    coreWindow.VisibilityChanged += OnVisibilityChanged;
```

```javascript
 document.addEventListener("visibilitychange", onVisibilityChanged, false);
```

Xxxx xxx xxxxxxxxxx xxxxxxx, xxx xxx xxxx xxxxxx xx xxxxxxx xxx xxxxxxxxxx xxxxx xxxxxxxx xx xxxxx xxxx.

```csharp
private void OnVisibilityChanged(CoreWindow sender, VisibilityChangedEventArgs args)
{
    // NOTE: After the app is no longer visible on the screen and before the app is suspended
    // you might want your app to use toast notification for any geofence activity.
    // By registering for VisibiltyChanged the app is notified when the app is no longer visible in the foreground.

    if (args.Visible)
    {
        // register for foreground events
        GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        GeofenceMonitor.Current.StatusChanged += OnGeofenceStatusChanged;
    }
    else
    {
        // unregister foreground events (let background capture events)
        GeofenceMonitor.Current.GeofenceStateChanged -= OnGeofenceStateChanged;
        GeofenceMonitor.Current.StatusChanged -= OnGeofenceStatusChanged;
    }
}
```

```javascript
function onVisibilityChanged() {
    // NOTE: After the app is no longer visible on the screen and before the app is suspended
    // you might want your app to use toast notification for any geofence activity.
    // By registering for VisibiltyChanged the app is notified when the app is no longer visible in the foreground.

    if (document.msVisibilityState === "visible") {
        // register for foreground events
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.addEventListener("geofencestatechanged", onGeofenceStateChanged);
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.addEventListener("statuschanged", onGeofenceStatusChanged);
    } else {
        // unregister foreground events (let background capture events)
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.removeEventListener("geofencestatechanged", onGeofenceStateChanged);
        Windows.Devices.Geolocation.Geofencing.GeofenceMonitor.current.removeEventListener("statuschanged", onGeofenceStatusChanged);
    }
}
```

### Xxxxxx xxxx xxxxxxxxx

Xxxxx XXX xxx xxxxxxx xxx xxxx xxxxxxxx xxxxxxxx xxxx, xxxxxxxxxx xxx xxxx xxx Xx-Xx xx xxxxx xxxxxxxx xxxxxxx xx xxxxxxxxx xxx xxxx'x xxxxxxx xxxxxxxx. Xxx xxxxx xxxxx xxxxx xxxxxxx xxx xxxxxx xxx xxxx xx xxx xxxxxxxxx xxx xxx xxxxxx. Xx xxx xxxxxxxx xxxxx xx xxx, xxxxxxxx xxxxx xxxxxxxxx xxx'x xx xxxxxx. Xx xxxxxxx, xx xx xxxxxxxxxxx xxxx xxx xx xxx xxxxxx x xxxxxxxx xxxx x xxxxxx xxxxxxx xxxx YY xxxxxx. Xxxx, xxxxxxxx xxxxxxxxxx xxxxx xxxx xxx xxxxxxxxxxxx xx Xxxxxxx; xx xxx xxx x xxxxx xxxxxxxx, xxxxx'x x xxxxxxxxxxx xxxx xxx xxxxx xxxx xx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263660) xx **Xxxx** xxxxx xxxxxxxx.

Xx xxxx xxx xxxxx xx xxx x xxxxxxxx xxxx x xxxxx xxxxxx, xxxxxx xxxxx xx xxx xxxx xxx xx x xxxxxx xxxx x XXX xxxxx xx xxxxxx xxx xxxx xxxxxxxxxxx.

## Xxxxxxx xxxxxx


* [Xxx xx x xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt219702)
* [Xxx xxxxxxx xxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt219698)
<!--* [Design guidelines for privacy-aware apps](guidelines-for-enabling-sensitive-devices.md)-->
* [UWP location sample (geolocation)](http://go.microsoft.com/fwlink/p/?linkid=533278)
 

 




<!--HONumber=Mar16_HO1-->
