---
xxxxx: 'Xxx xxx xxxx'x xxxxxxxx'
xxxxxxxxxxx: Xxxx xxx xxxx'x xxxxxxxx xxx xxxxxxx xx xxxxxxx xx xxxxxxxx. Xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx xx xxxxxxx xxxxxxxx xx xxx Xxxxxxxx xxx. Xxxx xxxxx xxxx xxxxx xxx xx xxxxx xx xxxx xxx xxx xxxxxxxxxx xx xxxxxx xxx xxxx'x xxxxxxxx.
xx.xxxxxxx: YYXXYXYY-YXXY-YYXY-XXYX-YYXXYYYXXXXY
---

# Xxx xxx xxxx'x xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxx xxx xxxx'x xxxxxxxx xxx xxxxxxx xx xxxxxxx xx xxxxxxxx. Xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx xx xxxxxxx xxxxxxxx xx xxx Xxxxxxxx xxx. Xxxx xxxxx xxxx xxxxx xxx xx xxxxx xx xxxx xxx xxx xxxxxxxxxx xx xxxxxx xxx xxxx'x xxxxxxxx.

**Xxx** Xx xxxxx xxxx xxxxx xxxxxxxxx xxx xxxx'x xxxxxxxx xx xxxx xxx, xxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

-   [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## Xxxxxx xxx xxxxxxxx xxxxxxxxxx


1.  Xx **Xxxxxxxx Xxxxxxxx**, xxxxxx-xxxxx **xxxxxxx.xxxxxxxxxxxx** xxx xxxxxx xxx **Xxxxxxxxxxxx** xxx.
2.  Xx xxx **Xxxxxxxxxxxx** xxxx, xxxxxx xxx **Xxxxxxxxxxxx** xxx. Xxxx xxxx xxx `Location` xxxxxx xxxxxxxxxx xx xxx xxxxxxx xxxxxxxx xxxx.

```XML
  <Capabilities>
    <!-- DeviceCapability elements must follow Capability elements (if present) -->
    <DeviceCapability Name="location"/>
  </Capabilities>
```

## Xxx xxx xxxxxxx xxxxxxxx


Xxxx xxxxxxx xxxxxxxxx xxx xx xxxxxx xxx xxxx'x xxxxxxxxxx xxxxxxxx xxxxx XXXx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225603) xxxxxxxxx.

### Xxxx Y: Xxxxxxx xxxxxx xx xxx xxxx'x xxxxxxxx

**Xxxxxxxxx** Xxx xxxx xxxxxxx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxx xxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn859152) xxxxxx xxxxxx xxxxxxxxxx xx xxxxxx xxx xxxx'x xxxxxxxx. Xxx xxxx xxxx xxx **XxxxxxxXxxxxxXxxxx** xxxxxx xxxx xxx XX xxxxxx xxx xxxx xxx xxxx xx xx xxx xxxxxxxxxx. Xxxx xxx xxxx xxx xx xxxx xx xxxxxx xxx xxxx'x xxxxxxxx xxxxxxxxxxx xxxxx xxxxx xxx xxxx xxxxxx xxxxxxxxxx xx xxxx xxx.

```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();
```

Xxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn859152) xxxxxx xxxxxxx xxx xxxx xxx xxxxxxxxxx xx xxxxxx xxxxx xxxxxxxx. Xxx xxxx xx xxxx xxxxxxxx xxxx (xxx xxx). Xxxxx xxx xxxxx xxxx xxxx xxxxx xx xxxx xxxxxxxxxx, xxxx xxxxxx xx xxxxxx xxxxxxx xxx xxxx xxx xxxxxxxxxx. Xx xxxx xxx xxxx xxxxxx xxxxxxxx xxxxxxxxxxx xxxxx xxxx'xx xxxx xxxxxxxx, xx xxxxxxxxx xxxx xxx xxxxxxx x xxxx xx xxx xxxxxxxx xxxxxxxx xx xxxxxxxxxxxx xxxxx xx xxxx xxxxx.

### Xxxx Y: Xxx xxx xxxx'x xxxxxxxx xxx xxxxxxxx xxx xxxxxxx xx xxxxxxxx xxxxxxxxxxx

Xxx [**XxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh973536) xxxxxx xxxxxxxx x xxx-xxxx xxxxxxx xx xxx xxxxxxx xxxxxxxx. Xxxx, x **xxxxxx** xxxxxxxxx xx xxxx xxxx **xxxxxxXxxxxx** (xxxx xxx xxxxxxxx xxxxxxx) xx xxx xxxx xxxx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx. Xx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx, xxx xxxx xxxxxxx x [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225534) xxxxxx, xxxxxxxxx xxx xxxxxxx xx xxxxxxxx xxxxxxxxxxx, xxx xxxxxxxx xxx xxxx'x xxxxxxxx.

```csharp
switch (accessStatus)
{
    case GeolocationAccessStatus.Allowed:
        _rootPage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);

        // If DesiredAccuracy or DesiredAccuracyInMeters are not set (or value is 0), DesiredAccuracy.Default is used.
        Geolocator geolocator = new Geolocator { DesiredAccuracyInMeters = _desireAccuracyInMetersValue };

        // Subscribe to the StatusChanged event to get updates of location status changes.
        _geolocator.StatusChanged += OnStatusChanged;
                        
        // Carry out the operation.
        Geoposition pos = await geolocator.GetGeopositionAsync();

        UpdateLocationData(pos);
        _rootPage.NotifyUser("Location updated.", NotifyType.StatusMessage);
        break;

    case GeolocationAccessStatus.Denied:
        _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);
        LocationDisabledMessage.Visibility = Visibility.Visible;
        UpdateLocationData(null);
        break;

    case GeolocationAccessStatus.Unspecified:
        _rootPage.NotifyUser("Unspecified error.", NotifyType.ErrorMessage);
        UpdateLocationData(null);
        break;
}
```

### Xxxx Y: Xxxxxx xxxxxxx xx xxxxxxxx xxxxxxxxxxx

Xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225534) xxxxxx xxxxxxxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225542) xxxxx xx xxxxxxxx xxxx xxx xxxx'x xxxxxxxx xxxxxxxx xxxxxxx. Xxxx xxxxx xxxxxx xxx xxxxxxxxxxxxx xxxxxx xxx xxx xxxxxxxx'x **Xxxxxx** xxxxxxxx (xx xxxx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225599)). Xxxx xxxx xxxx xxxxxx xx xxx xxxxxx xxxx xxx XX xxxxxx xxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208211) xxxxxx xxxxxxx xxx XX xxxxxxx.

```csharp
using Windows.UI.Core;
...
async private void OnStatusChanged(Geolocator sender, StatusChangedEventArgs e)
{
    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        // Show the location setting message only if status is disabled.
        LocationDisabledMessage.Visibility = Visibility.Collapsed;

        switch (e.Status)
        {
            case PositionStatus.Ready:
                // Location platform is providing valid data.
                ScenarioOutput_Status.Text = "Ready";
                _rootPage.NotifyUser("Location platform is ready.", NotifyType.StatusMessage);
                break;

            case PositionStatus.Initializing:
                // Location platform is attempting to acquire a fix. 
                ScenarioOutput_Status.Text = "Initializing";
                _rootPage.NotifyUser("Location platform is attempting to obtain a position.", NotifyType.StatusMessage);
                break;

            case PositionStatus.NoData:
                // Location platform could not obtain location data.
                ScenarioOutput_Status.Text = "No data";
                _rootPage.NotifyUser("Not able to determine the location.", NotifyType.ErrorMessage);
                break;

            case PositionStatus.Disabled:
                // The permission to access location data is denied by the user or other policies.
                ScenarioOutput_Status.Text = "Disabled";
                _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);

                // Show message to the user to go to location settings.
                LocationDisabledMessage.Visibility = Visibility.Visible;

                // Clear any cached location data.
                UpdateLocationData(null);
                break;

            case PositionStatus.NotInitialized:
                // The location platform is not initialized. This indicates that the application 
                // has not made a request for location data.
                ScenarioOutput_Status.Text = "Not initialized";
                _rootPage.NotifyUser("No request for location is made yet.", NotifyType.StatusMessage);
                break;

            case PositionStatus.NotAvailable:
                // The location platform is not available on this version of the OS.
                ScenarioOutput_Status.Text = "Not available";
                _rootPage.NotifyUser("Location is not available on this version of the OS.", NotifyType.ErrorMessage);
                break;

            default:
                ScenarioOutput_Status.Text = "Unknown";
                _rootPage.NotifyUser(string.Empty, NotifyType.StatusMessage);
                break;
        }
    });
}
```

## Xxxxxxx xx xxxxxxxx xxxxxxx


Xxxx xxxxxxx xxxxxxxxx xxx xx xxx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225540) xxxxx xx xxxxxxx xxxxxxx xx xxx xxxx'x xxxxxxxx xxxx x xxxxxx xx xxxx. Xxxxxxx xxx xxxx xxxxx xxxxxx xxxxxx xx xxxxxxxx xx xxx xxxx, xx'x xxxxxxxxx xxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn859152) xxx xxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225542) xxxxx xx xxxxx xx xxx xxxxxxxx xxxxxxx.

Xxxx xxxxxxx xxxxxxx xxxx xxx'xx xxxxxxx xxxxxxx xxx xxxxxxxx xxxxxxxxxx xxx xxxxxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn859152) xxxx xxx XX xxxxxx xx xxxx xxxxxxxxxx xxx.

### Xxxx Y: Xxxxxx xxx xxxxxx xxxxxxxx xxx xxxxxxxx xxx xxxxxxxx xxxxxxx

Xx xxxx xxxxxxx, x **xxxxxx** xxxxxxxxx xx xxxx xxxx **xxxxxxXxxxxx** (xxxx xxx xxxxxxxx xxxxxxx) xx xxx xxxx xxxx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx. Xx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx, xxx xxxx xxxxxxx x [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225534) xxxxxx, xxxxxxxxx xxx xxxxxxxx xxxx, xxx xxxxxxxxx xxx xxxxxxxx xxxxxxx.

Xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225534) xxxxxx xxx xxxxxxx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225540) xxxxx xxxxx xx x xxxxxx xx xxxxxxxx (xxxxxxxx-xxxxx xxxxxxxx) xx x xxxxxx xx xxxx (xxxxxxxx-xxxxx xxxxxxxx).

-   Xxx xxxxxxxx-xxxxx xxxxxxxx, xxx xxx [**XxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225539) xxxxxxxx.
-   Xxx xxxxxxxx-xxxxx xxxxxxxx, xxx xxx [**XxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225541) xxxxxxxx.

Xx xxxxxxx xxxxxxxx xx xxx, x xxxxxxxx xx xxxxxxxx xxxxx Y xxxxxx (xxxxxxxxxx xx `ReportInterval = 1000`). Xxxx, x Y xxxxxx (`ReportInterval = 2000`) xxxxxx xxxxxxxx xx xxxx.
```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();

switch (accessStatus)
{
    case GeolocationAccessStatus.Allowed:
        // Create Geolocator and define perodic-based tracking (2 second interval).
        _geolocator = new Geolocator { ReportInterval = 2000 };

        // Subscribe to the PositionChanged event to get location updates.
        _geolocator.PositionChanged += OnPositionChanged;

        // Subscribe to StatusChanged event to get updates of location status changes.
        _geolocator.StatusChanged += OnStatusChanged;
                    
        _rootPage.NotifyUser("Waiting for update...", NotifyType.StatusMessage);
        LocationDisabledMessage.Visibility = Visibility.Collapsed;
        StartTrackingButton.IsEnabled = false;
        StopTrackingButton.IsEnabled = true;
        break;

    case GeolocationAccessStatus.Denied:
        _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);
        LocationDisabledMessage.Visibility = Visibility.Visible;
        break;

    case GeolocationAccessStatus.Unspecified:
        _rootPage.NotifyUser("Unspecificed error!", NotifyType.ErrorMessage);
        LocationDisabledMessage.Visibility = Visibility.Collapsed;
        break;
}
```

### Xxxx Y: Xxxxxx xxxxxxxx xxxxxxx

Xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225534) xxxxxx xxxxxxxx xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225540) xxxxx xx xxxxxxxx xxxx xxx xxxx'x xxxxxxxx xxxxxxx xx xxxx xxx xxxxxx, xxxxxxxxx xx xxx xxx'xx xxxxxxxxxx xx. Xxxx xxxxx xxxxxx xxx xxxxxxxxxxxxx xxxxxxxx xxx xxx xxxxxxxx'x **Xxxxxxxx** xxxxxxxx (xx xxxx [**Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225543)). Xx xxxx xxxxxxx, xxx xxxxxx xx xxx xxxxxx xxxx xxx XX xxxxxx xxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208211) xxxxxx xxxxxxx xxx XX xxxxxxx.

```csharp
using Windows.UI.Core;
...
async private void OnPositionChanged(Geolocator sender, PositionChangedEventArgs e)
{
    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        _rootPage.NotifyUser("Location updated.", NotifyType.StatusMessage);
        UpdateLocationData(e.Position);
    });
}
```

## Xxxxxx xxx xxxxxxxx xxxxxxx xxxxxxxx


Xx xxx xxxxxxxx xxxxxxx xxxxxxxx xxx'x xxxxx xxxx xxx xx xxxxxx xxx xxxx'x xxxxxxxx, xx xxxxxxxxx xxxx xxx xxxxxxx x xxxxxxxxxx xxxx xx xxx **xxxxxxxx xxxxxxx xxxxxxxx** xx xxx **Xxxxxxxx** xxx. Xx xxxx xxxxxxx, x Xxxxxxxxx xxxxxxx xx xxxx xxxxxxxx xx xxx `ms-settings:privacy-location` XXX.

```xaml
<!--Set Visibility to Visible when access to location is denied -->  
<TextBlock x:Name="LocationDisabledMessage" FontStyle="Italic" 
                 Visibility="Collapsed" Margin="0,15,0,0" TextWrapping="Wrap" >
          <Run Text="This app is not able to access Location. Go to " />
              <Hyperlink NavigateUri="ms-settings:privacy-location">
                  <Run Text="Settings" />
              </Hyperlink>
          <Run Text=" to check the location privacy settings."/>
</TextBlock>
```

Xxxxxxxxxxxxx, xxxx xxx xxx xxxx xxx [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476) xxxxxx xx xxxxxx xxx **Xxxxxxxx** xxx xxxx xxxx. Xxx xxxx xxxx, xxx [Xxxxxx xxx Xxxxxxx Xxxxxxxx xxx](https://msdn.microsoft.com/library/windows/apps/mt228342).

```csharp
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-location"));
```

## Xxxxxxxxxxxx xxxx xxx


Xxxxxx xxxx xxx xxx xxxxxx xxx xxxx'x xxxxxxxx, **Xxxxxxxx** xxxx xx xxxxxxx xx xxx xxxxxx. Xx xxx **Xxxxxxxx** xxx, xxxxx xxxx xxx xxxxxxxxx **xxxxxxxx xxxxxxx xxxxxxxx** xxx xxxxxx xx:

-   **Xxxxxxxx xxx xxxx xxxxxx...** xx xxxxxx **xx** (xxx xxxxxxxxxx xx Xxxxxxx YY Xxxxxx)
-   Xxx xxxxxxxx xxxxxxxx xxxxxxx, **Xxxxxxxx**, xx xxxxxx **xx**
-   Xxxxx **Xxxxxx xxxx xxxx xxx xxx xxxx xxxxxxxx**, xxxx xxx xx xxx xx **xx**

## Xxxxxxx xxxxxx

* [XXX xxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=533278)
* [Xxxxxx xxxxxxxxxx xxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn631756)
* [Xxxxxx xxxxxxxxxx xxx xxxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh465148)


<!--HONumber=Mar16_HO1-->
