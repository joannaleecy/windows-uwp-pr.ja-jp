---
xxxxx: Xxx xx x xxxxxxxx
xxxxxxxxxxx: Xxx xx x Xxxxxxxx xx xxxx xxx, xxx xxxxx xxx xx xxxxxx xxxxxxxxxxxxx xx xxx xxxxxxxxxx xxx xxxxxxxxxx.
xx.xxxxxxx: XYXYYXYY-YYYY-YXXX-XYXY-YYYYXXYYXXXX
---

# Xxx xx x xxxxxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xx x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263587) xx xxxx xxx, xxx xxxxx xxx xx xxxxxx xxxxxxxxxxxxx xx xxx xxxxxxxxxx xxx xxxxxxxxxx.

**Xxx** Xx xxxxx xxxx xxxxx xxxxxxxxx xxxxxxxx xx xxxx xxx, xxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xxx [Xxxxxxx-xxxxxxxxx-xxxxxxx xxxx](http://go.microsoft.com/fwlink/p/?LinkId=619979) xx XxxXxx.

-   [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkId=619977)

## Xxxxxx xxx xxxxxxxx xxxxxxxxxx


1.  Xx **Xxxxxxxx Xxxxxxxx**, xxxxxx-xxxxx xx **xxxxxxx.xxxxxxxxxxxx** xxx xxxxxx xxx **Xxxxxxxxxxxx** xxx.
2.  Xx xxx **Xxxxxxxxxxxx** xxxx, xxxxx **Xxxxxxxx**. Xxxx xxxx xxx `Location` xxxxxx xxxxxxxxxx xx xxx xxxxxxx xxxxxxxx xxxx.

```xml
  <Capabilities>
    <!-- DeviceCapability elements must follow Capability elements (if present) -->
    <DeviceCapability Name="location"/>
  </Capabilities>
```

## Xxx xx x xxxxxxxx


### Xxxx Y: Xxxxxxx xxxxxx xx xxx xxxx'x xxxxxxxx

**Xxxxxxxxx** Xxx xxxx xxxxxxx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxx xxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn859152) xxxxxx xxxxxx xxxxxxxxxx xx xxxxxx xxx xxxx'x xxxxxxxx. Xxx xxxx xxxx xxx **XxxxxxxXxxxxxXxxxx** xxxxxx xxxx xxx XX xxxxxx xxx xxxx xxx xxxx xx xx xxx xxxxxxxxxx. Xxxx xxx xxxx xxx xx xxxx xx xxxxxx xxx xxxx'x xxxxxxxx xxxxxxxxxxx xxxxx xxxxx xxx xxxx xxxxxx xxxxxxxxxx xx xxxx xxx.

```csharp
using Windows.Devices.Geolocation;
...
var accessStatus = await Geolocator.RequestAccessAsync();
```

Xxx [**XxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/dn859152) xxxxxx xxxxxxx xxx xxxx xxx xxxxxxxxxx xx xxxxxx xxxxx xxxxxxxx. Xxx xxxx xx xxxx xxxxxxxx xxxx (xxx xxx). Xxxxx xxx xxxxx xxxx xxxx xxxxx xx xxxx xxxxxxxxxx, xxxx xxxxxx xx xxxxxx xxxxxxx xxx xxxx xxx xxxxxxxxxx. Xx xxxx xxx xxxx xxxxxx xxxxxxxx xxxxxxxxxxx xxxxx xxxx'xx xxxx xxxxxxxx, xx xxxxxxxxx xxxx xxx xxxxxxx x xxxx xx xxx xxxxxxxx xxxxxxxx xx xxxxxxxxxxxx xxxxx xx xxxx xxxxx.

### Xxxx Y: Xxxxxxxx xxx xxxxxxx xx xxxxxxxx xxxxx xxx xxxxxxxx xxxxxxxxxxx

Xx xxxx xxxxxxx, x **xxxxxx** xxxxxxxxx xx xxxx xxxx **xxxxxxXxxxxx** (xxxx xxx xxxxxxxx xxxxxxx) xx xxx xxxx xxxx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx. Xx xxxxxx xx xxx xxxx'x xxxxxxxx xx xxxxxxx, xxx xxxx xxxxxxxx xxx xxxxxxx xxxxxxxxx, xxxxxxxxx xxx xxxxxxxx xxxxx xxxxxxx, xxx xxxxxxxxx xxx xxxxxxx xx xxxxxxxx xxxxxxxxxxx.

**Xxx** Xxxx xxxxx x xxxxxxxx, xxxxxxx xxxxxxx xx xxxxxxxx xxxxxxxxxxx xxxxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263646) xxxxx xxxx xxx XxxxxxxxXxxxxxx xxxxx xxxxxxx xx xxx XxxxxxXxxxxxx xxxxx xxxx xxx Xxxxxxxxxx xxxxx. X [**XxxxxxxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263599) xx **Xxxxxxxx** xx xxxxxxxxxx xx x xxxxxxxx [**XxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br225599) - xxxx xxxxxxxx xxxx xxx xxx xxxx xxx xxxx xxxxxxxxxx xx xxxxxx xxx xxxx'x xxxxxxxx.

```csharp
switch (accessStatus)
{
    case GeolocationAccessStatus.Allowed:
        geofences = GeofenceMonitor.Current.Geofences;

        FillRegisteredGeofenceListBoxWithExistingGeofences();
        FillEventListBoxWithExistingEvents();

        // Register for state change events.
        GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
        GeofenceMonitor.Current.StatusChanged += OnGeofenceStatusChanged;
        break;

    case GeolocationAccessStatus.Denied:
        _rootPage.NotifyUser("Access denied.", NotifyType.ErrorMessage);
        break;

    case GeolocationAccessStatus.Unspecified:
        _rootPage.NotifyUser("Unspecified error.", NotifyType.ErrorMessage);
        break;
}
```

Xxxx, xxxx xxxxxxxxxx xxxx xxxx xxxx xxxxxxxxxx xxx, xxxxxxxxxx xxx xxxxx xxxxxxxxx.

```csharp
protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
{
    GeofenceMonitor.Current.GeofenceStateChanged -= OnGeofenceStateChanged;
    GeofenceMonitor.Current.StatusChanged -= OnGeofenceStatusChanged;

    base.OnNavigatingFrom(e);
}
```

### Xxxx Y: Xxxxxx xxx xxxxxxxx

Xxx, xxx xxx xxxxx xx xxxxxx xxx xxx xx x [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263587) xxxxxx. Xxxxx xxx xxxxxxx xxxxxxxxx xxxxxxxxxxx xxxxxxxxx xx xxxxxx xxxx, xxxxxxxxx xx xxxx xxxxx. Xx xxx xxxx xxxxx xxxxxxxx xxxxxxxxxxx, xxxxxxx xxxx xxx [**Xx**](https://msdn.microsoft.com/library/windows/apps/dn263724) xxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263718) xx xxxxx xxxx.

```csharp
// Set the fence ID.
string fenceId = "fence1";

// Define the fence location and radius.
BasicGeoposition position;
position.Latitude = 47.6510;
position.Longitude = -122.3473;
position.Altitude = 0.0;
double radius = 10; // in meters

// Set a circular region for the geofence.
Geocircle geocircle = new Geocircle(position, radius);

// Create the geofence.
Geofence geofence = new Geofence(fenceId, geocircle);
```

Xxx xxx xxxx-xxxx xxxx xxxxxxxx xxxxxxx xx xxxxx xxx xx xxx xxxxx xxxxxxxxxxxx. Xx xxx xxxx xxxxxxx, xxx xxxxxxxx xxxxxxxxxxx xxxxxxxxx xxxxx xxxxxxxxxx xxxxxxxxxx:

-   [
            **XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263728) - Xxxxxxxxx xxxx xxxxxxxx xxxxxx xxx xxxx xx xxxxxxx xxxxxxxxxxxxx xxx xxxxxxxx xxx xxxxxxx xxxxxx, xxxxxxx xxx xxxxxxx xxxxxx, xx xxxxxxx xx xxx xxxxxxxx.
-   [
            **XxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/dn263732) - Xxxxxxx xxx xxxxxxxx xxxx xxx xxx xxxxxx xxx xxxxxxxx xx xxxxx xxxxxxxxx xxx xxxx xxxx xxx.
-   [
            **XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn263703) - Xxxxxxxxx xxx xxxx xxx xxxx xxxx xx xx xx xxx xx xxx xxxxxxx xxxx xxxxxx xxx xxxxx/xxxx xxxxxx xxx xxxxxxxxx.
-   [
            **XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn263735) - Xxxxxxxxx xxxx xx xxxxx xxxxxxxxxx xxx xxxxxxxx.
-   [
            **Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263697) - Xxxxxxxxx xxx xxxxxx xxx xxxxx xx xxxxxxx xxx xxxxxxxx.

```csharp
// Set the fence ID.
string fenceId = "fence2";

// Define the fence location and radius.
BasicGeoposition position;
position.Latitude = 47.6510;
position.Longitude = -122.3473;
position.Altitude = 0.0;
double radius = 10; // in meters

// Set the circular region for geofence.
Geocircle geocircle = new Geocircle(position, radius);

// Remove the geofence after the first trigger.
bool singleUse = true;

// Set the monitored states.
MonitoredGeofenceStates monitoredStates = 
                MonitoredGeofenceStates.Entered | 
                MonitoredGeofenceStates.Exited | 
                MonitoredGeofenceStates.Removed;

// Set how long you need to be in geofence for the enter event to fire.
TimeSpan dwellTime = TimeSpan.FromMinutes(5);

// Set how long the geofence should be active.
TimeSpan duration = TimeSpan.FromDays(1);

// Set up the start time of the geofence.
DateTimeOffset startTime = DateTime.Now;

// Create the geofence.
Geofence geofence = new Geofence(fenceId, geocircle, monitoredStates, singleUse, dwellTime, startTime, duration);
```

### Xxxx Y: Xxxxxx xxxxxxx xx xxxxxxxx xxxxxxxxxxx

Xxx [**XxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263595) xxxxxx xxxxxxxx xxx [**XxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263646) xxxxx xx xxxxxxxx xxxx xxx xxxx'x xxxxxxxx xxxxxxxx xxxxxxx. Xxxx xxxxx xxxxxx xxx xxxxxxxxxxxxx xxxxxx xxx xxx xxxxxxxx'x **xxxxxx.Xxxxxx** xxxxxxxx (xx xxxx [**XxxxxxxxXxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263599)). Xxxx xxxx xxxx xxxxxx xx xxx xxxxxx xxxx xxx XX xxxxxx xxx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208211) xxxxxx xxxxxxx xxx XX xxxxxxx.

```csharp
using Windows.UI.Core;
...
public async void OnGeofenceStatusChanged(GeofenceMonitor sender, object e)
{
   await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
   {
    // Show the location setting message only if the status is disabled.
    LocationDisabledMessage.Visibility = Visibility.Collapsed;

    switch (sender.Status)
    {
     case GeofenceMonitorStatus.Ready:
      _rootPage.NotifyUser("The monitor is ready and active.", NotifyType.StatusMessage);
      break;

     case GeofenceMonitorStatus.Initializing:
      _rootPage.NotifyUser("The monitor is in the process of initializing.", NotifyType.StatusMessage);
      break;

     case GeofenceMonitorStatus.NoData:
      _rootPage.NotifyUser("There is no data on the status of the monitor.", NotifyType.ErrorMessage);
      break;

     case GeofenceMonitorStatus.Disabled:
      _rootPage.NotifyUser("Access to location is denied.", NotifyType.ErrorMessage);

      // Show the message to the user to go to the location settings.
      LocationDisabledMessage.Visibility = Visibility.Visible;
      break;

     case GeofenceMonitorStatus.NotInitialized:
      _rootPage.NotifyUser("The geofence monitor has not been initialized.", NotifyType.StatusMessage);
      break;

     case GeofenceMonitorStatus.NotAvailable:
      _rootPage.NotifyUser("The geofence monitor is not available.", NotifyType.ErrorMessage);
      break;

     default:
      ScenarioOutput_Status.Text = "Unknown";
      _rootPage.NotifyUser(string.Empty, NotifyType.StatusMessage);
      break;
    }
   });
}
```

## Xxx xx xxxxxxxxxx xxxxxxxxxxxxx


Xxxxx xxxx xxxxxxxxx xxx xxxxxxx, xxx xxxx xxx xxx xxxxx xx xxxxxx xxxx xxxxxxx xxxx x xxxxxxxx xxxxx xxxxxx. Xxxxxxxxx xx xxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263728) xxxx xxx xxxx xxx xx, xxx xxx xxxxxxx xx xxxxx xxxx:

-   Xxx xxxx xxxxxx x xxxxxx xx xxxxxxxx.
-   Xxx xxxx xxxxxx x xxxxxx xx xxxxxxxx.
-   Xxx xxxxxxxx xxx xxxxxxx xx xxxx xxxxxxx. Xxxx xxxx x xxxxxxxxxx xxx xx xxx xxxxxxxxx xxx x xxxxxxx xxxxx.

Xxx xxx xxxxxx xxx xxxxxx xxxxxxxx xxxx xxxx xxx xxxx xx xx xxxxxxx xx xxxxxxxx xxx x xxxxxxxxxx xxxx xx xxxx xxx xxxxxxx x xxxxxxxxxx xxxxxxxxxxxx xxxx xx xxxxx xxxxxx.

### Xxxx Y: Xxxxxxxx xxx xxxxxxxx xxxxx xxxxxx xxxxxx

Xxx xxxx xxx xx xxxxxxx x xxxxxxxxxx xxxxxxxxxxxx xx x xxxxxxxx xxxxx xxxxxx, xxx xxxx xxxxxxxx xx xxxxx xxxxxxx. Xxxx xx xxxxxxxxx xxx xx xxxx xxx xxxxxx xxx xxxxxxxx.

```csharp
private void Initialize()
{
    // Other initialization logic

    GeofenceMonitor.Current.GeofenceStateChanged += OnGeofenceStateChanged;
}

```

### Xxxx Y: Xxxxxxxxx xxx xxxxxxxx xxxxx xxxxxxx

Xxx xxxx xxxx xx xx xxxxxxxxx xxx xxxxx xxxxxxxx. Xxx xxxxxx xxxxx xxxx xxxxxxx xx xxxx xxxx xxx xx xxxxx xxx xxxxxxxx xxx.

```csharp
public async void OnGeofenceStateChanged(GeofenceMonitor sender, object e)
{
    var reports = sender.ReadReports();

    await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        foreach (GeofenceStateChangeReport report in reports)
        {
            GeofenceState state = report.NewState;

            Geofence geofence = report.Geofence;

            if (state == GeofenceState.Removed)
            {
                // Remove the geofence from the geofences collection.
                GeofenceMonitor.Current.Geofences.Remove(geofence);
            }
            else if (state == GeofenceState.Entered)
            {
                // Your app takes action based on the entered event.

                // NOTE: You might want to write your app to take a particular
                // action based on whether the app has internet connectivity.

            }
            else if (state == GeofenceState.Exited)
            {
                // Your app takes action based on the exited event.

                // NOTE: You might want to write your app to take a particular
                // action based on whether the app has internet connectivity.

            }
        }
    });
}



```

## Xxx xx xxxxxxxxxx xxxxxxxxxxxxx


Xxxxx xxxx xxxxxxxxx xxx xxxxxxx, xxx xxxx xxx xxx xxxxx xx xxxxxx xxxx xxxxxxx xxxx x xxxxxxxx xxxxx xxxxxx. Xxxxxxxxx xx xxx [**XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/dn263728) xxxx xxx xxxx xxx xx, xxx xxx xxxxxxx xx xxxxx xxxx:

-   Xxx xxxx xxxxxx x xxxxxx xx xxxxxxxx.
-   Xxx xxxx xxxxxx x xxxxxx xx xxxxxxxx.
-   Xxx xxxxxxxx xxx xxxxxxx xx xxxx xxxxxxx. Xxxx xxxx x xxxxxxxxxx xxx xx xxx xxxxxxxxx xxx x xxxxxxx xxxxx.

Xx xxxxxx xxx x xxxxxxxx xxxxx xx xxx xxxxxxxxxx

-   Xxxxxxx xxx xxxxxxxxxx xxxx xx xxxx xxx’x xxxxxxxx.
-   Xxxxxxxx xxx xxxxxxxxxx xxxx xx xxxx xxx. Xx xxxx xxx xxxxx xxxxxxxx xxxxxx, xxx xxx xxxxxxxxx x xxxxx xxxxxxx, xxx xxx xxx x xxxx xxx xxxx xxxx xxx xxxxx xx xxxxxxxxx. Xxx xxx xxxx xxx x xxxx xx xxxx xxxx xxxx xxx xxxx xx xxxxxxx xxxx xxx xxxxx xx xxxxxxxxx xx xxxx xxx xxx xxxx xxxx xxx xxxx xxxx xxxxxxxx.
-   Xxxxx xxxx xxx xx xxxxxxx xx xxx xxxxxxxxxx, xxxxxx xxx xxxx xx xxxxx xxxx xxx xxxxxxxx xxxxxxxxxxx.

### Xxxx Y: Xxxxxxxx xxx xxxxxxxx xxxxx xxxxxx xxxxxx

Xx xxxx xxx'x xxxxxxxx, xxxxx xxx **Xxxxxxxxxxxx** xxx, xxx x xxxxxxxxxxx xxx x xxxxxxxx xxxxxxxxxx xxxx. Xx xx xxxx:

-   Xxx x xxxxxxxxxxx xx xxxx **Xxxxxxxxxx Xxxxx**.
-   Xxx x xxxxxxxx xxxx xxxx xx **Xxxxxxxx**.
-   Xxx xx xxxxx xxxxx xxxx xxxx xxx xx xxxx xxxx xxx xxxxx xx xxxxxxxxx.

### Xxxx Y: Xxxxxxxx xxx xxxxxxxxxx xxxx

Xxx xxxx xx xxxx xxxx xxxxxxxxx xxx xxxxxxxxxx xxxxxxxxxx xxxx. Xxxxxxxx xxxx xxxx xxx xxxxxxxx xxx xxxxxxx, xx xxxxxxx xxx xxxxxxxx xxxxxxxxxxx. Xxx xxxx xxxx, xxx [Xxx xx x xxxxxxxx](#setup).

```csharp
async private void RegisterBackgroundTask(object sender, RoutedEventArgs e)
{
    // Get permission for a background task from the user. If the user has already answered once,
    // this does nothing and the user must manually update their preference via PC Settings.
    BackgroundAccessStatus backgroundAccessStatus = await BackgroundExecutionManager.RequestAccessAsync();

    // Regardless of the answer, register the background task. Note that the user can use
    // the Settings app to prevent your app from running background tasks.
    // Create a new background task builder.
    BackgroundTaskBuilder geofenceTaskBuilder = new BackgroundTaskBuilder();

    geofenceTaskBuilder.Name = SampleBackgroundTaskName;
    geofenceTaskBuilder.TaskEntryPoint = SampleBackgroundTaskEntryPoint;

    // Create a new location trigger.
    var trigger = new LocationTrigger(LocationTriggerType.Geofence);

    // Associate the location trigger with the background task builder.
    geofenceTaskBuilder.SetTrigger(trigger);

    // If it is important that there is user presence and/or
    // internet connection when OnCompleted is called
    // the following could be called before calling Register().
    // SystemCondition condition = new SystemCondition(SystemConditionType.UserPresent | SystemConditionType.InternetAvailable);
    // geofenceTaskBuilder.AddCondition(condition);

    // Register the background task.
    geofenceTask = geofenceTaskBuilder.Register();

    // Associate an event handler with the new background task.
    geofenceTask.Completed += new BackgroundTaskCompletedEventHandler(OnCompleted);

    BackgroundTaskState.RegisterBackgroundTask(BackgroundTaskState.LocationTriggerBackgroundTaskName);

    switch (backgroundAccessStatus)
    {
    case BackgroundAccessStatus.Unspecified:
    case BackgroundAccessStatus.Denied:
        rootPage.NotifyUser("This app is not allowed to run in the background.", NotifyType.ErrorMessage);
        break;

    }
}


```

### Xxxx Y: Xxxxxxxx xxx xxxxxxxxxx xxxxxxxxxxxx

Xxx xxxxxx xxxx xxx xxxx xx xxxxxx xxx xxxx xxxxxxx xx xxxx xxxx xxx xxxx, xxx xxx xxx xxxxxxx x xxxxx xxxxxxxxxxxx, xxxx xx xxxxx xxxxx, xx xxxxxx x xxxx xxxx. Xxx xxxx xx xxxx xxxx xxxxxxx xxx xxxxxxxxxxxx.

```csharp
async private void OnCompleted(IBackgroundTaskRegistration sender, BackgroundTaskCompletedEventArgs e)
{
    if (sender != null)
    {
        // Update the UI with progress reported by the background task.
        await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
        {
            try
            {
                // If the background task threw an exception, display the exception in
                // the error text box.
                e.CheckResult();

                // Update the UI with the completion status of the background task.
                // The Run method of the background task sets the LocalSettings. 
                var settings = ApplicationData.Current.LocalSettings;

                // Get the status.
                if (settings.Values.ContainsKey("Status"))
                {
                    rootPage.NotifyUser(settings.Values["Status"].ToString(), NotifyType.StatusMessage);
                }

                // Do your app work here.

            }
            catch (Exception ex)
            {
                // The background task had an error.
                rootPage.NotifyUser(ex.ToString(), NotifyType.ErrorMessage);
            }
        });
    }
}


```

## Xxxxxx xxx xxxxxxx xxxxxxxx


Xx xxx xxxxxxxx xxxxxxx xxxxxxxx xxx'x xxxxx xxxx xxx xx xxxxxx xxx xxxx'x xxxxxxxx, xx xxxxxxxxx xxxx xxx xxxxxxx x xxxxxxxxxx xxxx xx xxx **xxxxxxxx xxxxxxx xxxxxxxx** xx xxx **Xxxxxxxx** xxx. Xx xxxx xxxxxxx, x Xxxxxxxxx xxxxxxx xx xxxx xxxxxxxx xx xxx `ms-settings:privacy-location` XXX.

```xaml
<!--Set Visibility to Visible when access to the user&#39;s location is denied. -->  
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

## Xxxx xxx xxxxx xxxx xxx


Xxxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxx xxx xx x xxxxxxxxx xxxxxxx xxxx xxxxxx xx x xxxxxx'x xxxxxxxx. Xxxx, xx xxxxxxx xxxxxxx xxxxxxx xxx xxxxxxx xxxx xxxxxxxxxx xxx xxxxxxxxxx xxxxxxxxx.

**Xx xxxxx x xxxxxxxxxx xxx**

1.  Xxxxxxxxxx xxxx xxx xxxxxx xx xxx xxxxxxxxx.
2.  Xxxx xxxxxxxx x xxxxxxxx xx xxxxxxxx x xxxxxxxx xxxxxx xxxx xxxxxxxx xxxx xxxxxxx xxxxxxxx xxxxxxxx, xx xxx'xx xxxxxxx xxxxxx xxx xxxxxxxx xxx xxx "xxxxxxxx xxxxxxx" xxxxx xx xxxxxxxxx xxxxxxxxxxx.
3.  Xxx xxx Xxxxxxxxx Xxxxxx Xxxxxx xxxxxxxx xx xxxxxxxx xxxxxxxxx xxx xxx xxxxxx.

### Xxxx xxx xxxxx x xxxxxxxxxx xxx xxxx xx xxxxxxx xx xxx xxxxxxxxxx

**Xx xxxx xxxx xxxxxxxxxx xxx xxxx xx xxxxxxx xxx xxxxxxxxxx**

1.  Xxxxx xxxx xxx xx Xxxxxx Xxxxxx.
2.  Xxxxxx xxxx xxx xx xxx Xxxxxx Xxxxxx xxxxxxxx.
3.  Xxx xxxxx xxxxx xx xxxxxxxx xxxxxxx xxxxxxxxx xxxxxx xxx xxxxxxx xx xxxx xxxxxxxx xxxxxx. Xx xxxx xx xxxx xxxx xxxxxx xxxx xxx xxxx xxxxxxxxx xx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn263703) xxxxxxxx xx xxxxxxx xxx xxxxx. Xxxx xxxx xxx xxxx xxxxxx xxx xxxxxx xx xxxxxx xxxxxxxx xxxxxxxxxxx xxx xxx xxx. Xxx xxxx xxxx xxxxx xxxxxxxxxx xxxxxxxxx, xxx [Xxx xxx xxxxxxxxx xxxxxxxxxxx xx xxx xxxxxx](http://go.microsoft.com/fwlink/p/?LinkID=325245).
4.  Xxx xxx xxxx xxx xxx xxxxxxxx xx xxxxxxxx xxx xxxx xx xxxxxx xxx xxxxx xxxxx xxxxxxxxxxxxx xxxxxx xx xx xxxxxxxx xx xxxxxxxxx xxxxxx.

### Xxxx xxx xxxxx x xxxxxxxxxx xxx xxxx xx xxxxxxx xx xxx xxxxxxxxxx

**Xx xxxx xxxx xxxxxxxxxx xxx xxxx xx xxxxxxx xxx xxxxxxxxxx**

1.  Xxxxx xxxx xxx xx Xxxxxx Xxxxxx. Xxxx xxxx xxxx xxx xxxxxx xxx xxx **Xxxxxxxx** xxxxxxxxxx xxxx xxxx.
2.  Xxxxxx xxx xxx xxxxxxx xxxxx.
3.  Xxxxx xxxx xxx xxxx xx xxxxxxx xxxxxxx.
4.  Xxxxxx xxxx xxx xx xxx Xxxxxx Xxxxxx xxxxxxxx. Xxxx xxxx xxxxxxxxxx xxxxxxxxxx xxxxxxxxxx xx xxxxxxxxx xx xxxx xxx xxx xx x xxxx xxxxxx xxx xxxxxxxx. Xx xxx xxxxxx xxxxxxxx xxxxxxxxxx xxxx xxxxxx xxx xxxxxxxx.
5.  Xxxx xxx xxxxxxxx, xxxxxxxx xxxxxxx xxxxxxxxx xxxxxx xxx xxxxxxx xx xxxx xxxxxxxx xxxxxx. Xx xxxx xx xxxx xxxx xxxxxx xxxx xxx [**XxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn263703) xx xxxxxxx xxx xxxxx. Xxxx xxxx xxx xxxx xxxxxx xxx xxxxxx xx xxxxxx xxxxxxxx xxxxxxxxxxx xxx xxx xxx.
6.  Xxx Xxxxxx Xxxxxx xx xxxxxxx xxx xxxxxxxx xxxxxxxxxx xxxx. Xxx xxxx xxxx xxxxx xxxxxxxxxx xxxxxxxxxx xxxxx xx Xxxxxx Xxxxxx, xxx [Xxx xx xxxxxxx xxxxxxxxxx xxxxx](http://go.microsoft.com/fwlink/p/?LinkID=325378).

## Xxxxxxxxxxxx xxxx xxx


Xxxxxx xxxx xxx xxx xxxxxx xxxxxxxx, **Xxxxxxxx** xxxx xx xxxxxxx xx xxx xxxxxx. Xx xxx **Xxxxxxxx** xxx, xxxxx xxxx xxx xxxxxxxxx **xxxxxxxx xxxxxxx xxxxxxxx** xxx xxxxxx xx:

-   **Xxxxxxxx xxx xxxx xxxxxx...** xx xxxxxx **xx** (xxx xxxxxxxxxx xx Xxxxxxx YY Xxxxxx)
-   Xxx xxxxxxxx xxxxxxxx xxxxxxx, **Xxxxxxxx**, xx xxxxxx **xx**
-   Xxxxx **Xxxxxx xxxx xxxx xxx xxx xxxx xxxxxxxx**, xxxx xxx xx xxx xx **xx**

## Xxxxxxx xxxxxx

* [XXX xxxxxxxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=533278)
* [Xxxxxx xxxxxxxxxx xxx xxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/dn631756)
* [Xxxxxx xxxxxxxxxx xxx xxxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh465148)


<!--HONumber=Mar16_HO1-->
