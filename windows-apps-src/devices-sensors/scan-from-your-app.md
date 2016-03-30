---
xx.xxxxxxx: YYYXYYYY-YYXY-YXYY-XXXX-YYYYYXXXYXYX
xxxxx: Xxxx xxxx xxxx xxx
xxxxxxxxxxx: Xxxxx xxxx xxx xx xxxx xxxxxxx xxxx xxxx xxx xx xxxxx x xxxxxxx, xxxxxx, xx xxxx-xxxxxxxxxx xxxx xxxxxx.
---
# Xxxx xxxx xxxx xxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

** Xxxxxxxxx XXXx **

-   [**Xxxxxxx.Xxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn264250)
-   [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225393)
-   [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225381)

Xxxxx xxxx xxx xx xxxx xxxxxxx xxxx xxxx xxx xx xxxxx x xxxxxxx, xxxxxx, xx xxxx-xxxxxxxxxx xxxx xxxxxx.

**Xxxxxxxxx**  Xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn264250) XXXx xxx xxxx xx xxx xxxxxxx [xxxxxx xxxxxx](https://msdn.microsoft.com/library/windows/apps/Dn894631). Xxxx xxx xxx xxxxx XXXx xxxx xx xxx xxxxxxx xxxxxxx xx Xxxxxxx YY.

Xx xxxx xxxx xxxx xxx, xxx xxxx xxxxx xxxx xxx xxxxxxxxx xxxxxxxx xx xxxxxxxxx x xxx [**XxxxxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225393) xxxxxx xxx xxxxxxx xxx [**XxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225381) xxxx. Xxxx xxxxxxxx xxxx xxx xxxxxxxxx xxxxxxx xxxx XXX xxxxxxx xxx xxxxxx xxx xxxxxxxxx xx xxxx xxx.

Xxxxx xxxx xxx xxx xxxxxx xxxxxxxxx xxxxxxxx, xx xxx xxx xxx xxxx-xxxxxxxxxx xxxx xxxxxxxx xxxxx xx xxx xxxxxxx xxxx, xx xxxx xxxx xxxxx xxx xxxxxxxxx xxxxxxx xx xxxxxx xxxx xxxxxx. Xx xxx xxxx-xxxxxxxxxx xxxxxxxx, xxx xxxxxxx xxxx xx xxxxxxx xxx xxxx-xxxxxxxxxxxxx xxxx xxx xx xxxxxxxx xxxx xxxx x xxxxxxx xxx x xxxxxx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxx-Xxxxxxxxxx Xxxxxxxx](https://msdn.microsoft.com/library/windows/hardware/Ff539393).

## Xxxxxxxxx xxxxxxxxx xxxxxxxx

Xxxxxxx xxxx xxx xxxxxx xxxxxxxx xxxxxxxxxxxxx. Xxx xxxx xxxxxxx xxxx xxxx xx xxxxx xxx xxxx xxx xx xxxxxxxxxxx xxxx xxx xxxxxxx. Xx xxxx xxxxxxx, xxx xxxxxxx xxxxxx xxxxxxxxxxx xx xxxx xxxxx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR225459) xxxxxxxxx.

1.  Xxxxx, xxx xxxxx xxxxx xxxxxxxxxx xx xxxx xxxxx xxxxxxxxxx xxxx.

``` csharp
    using Windows.Devices.Enumeration;
    using Windows.Devices.Scanners;
```

2.  Xxxx, xxxxxxxxx x xxxxxx xxxxxxx xx xxxxx xxxxxxxxxxx xxxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxxxx xxxxxxx](enumerate-devices.md).

```csharp
    void InitDeviceWatcher()
    {
       // Create a Device Watcher class for type Image Scanner for enumerating scanners
       scannerWatcher = DeviceInformation.CreateWatcher(DeviceClass.ImageScanner);

       scannerWatcher.Added += OnScannerAdded;
       scannerWatcher.Removed += OnScannerRemoved;
       scannerWatcher.EnumerationCompleted += OnScannerEnumerationComplete;
    }
```

3.  Xxxxxx xx xxxxx xxxxxxx xxx xxxx x xxxxxxx xx xxxxx.

```csharp
    private async void OnScannerAdded(DeviceWatcher sender,  DeviceInformation deviceInfo)
    {
       await
       MainPage.Current.Dispatcher.RunAsync(
             Windows.UI.Core.CoreDispatcherPriority.Normal,
             () =&gt;
             {
                MainPage.Current.NotifyUser(String.Format(&quot;Scanner with device id {0} has been added&quot;, deviceInfo.Id), NotifyType.StatusMessage);

                // search the device list for a device with a matching device id
                ScannerDataItem match = FindInList(deviceInfo.Id);

                // If we found a match then mark it as verified and return
                if (match != null)
                {
                   match.Matched = true;
                   return;
                }

                // Add the new element to the end of the list of devices
                AppendToList(deviceInfo);
             }
       );
    }
```

## Xxxx

1.  **Xxx xx XxxxxXxxxxxx xxxxxx**

Xxx xxxx [**XxxxxXxxxxxxXxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn264238) xxxxxxxxxxx xxxx, xxxxxxx xx'x **Xxxxxxx**, **XxxxXxxxxxxxxx**, **Xxxxxxx**, xx **Xxxxxx**, xxx xxxx xxxxx xxxxxx xx [**XxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263806) xxxxxx xx xxxxxxx xxx [**XxxxxXxxxxxx.XxxxXxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.devices.scanners.imagescanner.fromidasync) xxxxxx, xxxx xxxx.

 ```csharp
    ImageScanner myScanner = await ImageScanner.FromIdAsync(deviceId);
 ```

2.  **Xxxx xxxx**

Xx xxxx xxxx xxx xxxxxxx xxxxxxxx, xxxx xxx xxxxxx xx xxx [**Xxxxxxx.Xxxxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn264250) xxxxxxxxx xx xxxxxx x xxxxxxx xxx xxxxx xxxx xxxx xxxxxx. Xx xxxx xxxxxxxx xxx xxxxxxx. Xxx xxxxxxxx xxxxxxxx xxx xxxx-xxxxxxxxx, xxxxxxx, xx xxxxxx. Xxxx xxxx xx xxxx xxxx xxxx xxxxxx xxxxxxx x xxxxxxxxxx xxxx xxxxxxxxx, xxxx xx xx xxxxx xxxx xxx xxxxx xxxxxx, xxxx xxxxxxx xxxxxxx xx xxxxxx.

**Xxxx**  Xx xxx xxxx xxxxxx xxx xxxxxxxx xx xxxx xx xxx xxxxxx, xxx xxxxxxx xxxx xxxx xxxx xxx xxxxxxx xxxxxxx. Xx xxx xxxx xxxxx xx xxxx xxxx xx xxxxx xxxxxx, xxx xxxx xxx xxx'x xxxxxxx xxx xxxxxxx xxxxx.
 
```csharp
    var result = await myScanner.ScanFilesToFolderAsync(ImageScannerScanSource.Default, 
        folder).AsTask(cancellationToken.Token, progress);
```

3.  **Xxxx xxxx Xxxx-xxxxxxxxxx, Xxxxxxx, xx Xxxxxx xxxxxx**

Xxxx xxx xxx xxx xxx xxxxxx'x [Xxxx-Xxxxxxxxxx Xxxxxxxx](https://msdn.microsoft.com/library/windows/hardware/Ff539393) xx xxxx xxxx xxx xxxx xxxxxxx xxxx xxxxxxxx. Xxxx xxxx xxxxxx, xxx xxxxxx xxxxxx xxx xxxxxxxxx xxx xxxx xxxx xxxxxxxx, xxxx xxxxx xxxx xxx xxxx xxxxxxxxxx, xxxxx xx xxx xxxxxxx xxxxx xxxxxxx. Xxx xxxxxx xxxxxxx xxx xxxx xxxxxxxx xx xxx xxxx xxx xxxx xxx xxxx xxx.

**Xxxx**  Xxx xxx xxxxxxxx xxxxxxx xxxx xxxxxxx, xx xxx xxx xxxx xxxxx xx xxx xxxxxxx xxxxxxxx xxxx xxxxxxx xxxxxx xxxxx xxxx xxxxxxx.

Xx xxxx xxxxxxx, xxx xxx xxxxx xxxxxx xx xxx xxxxxxx xx xxxxxxx xx xxxx-xxxxxxxxxxxxx xxx xxxx xxxxx. Xx xxxxxxx xxxxxx xxxxxxx xx xxxxxx xxxxxxx, xxxxxx xxxxxxx **XxxxXxxxxxxxxx** xxxx **Xxxxxxx** xx **Xxxxxx**.

```csharp
    if (myScanner.IsScanSourceSupported(ImageScannerScanSource.AutoConfigured))
    {
        ...
        // Scan API call to start scanning with Auto-Configured settings. 
        var result = await myScanner.ScanFilesToFolderAsync(
            ImageScannerScanSource.AutoConfigured, folder).AsTask(cancellationToken.Token, progress);
        ...
    }
```

## Xxxxxxx xxx xxxx

Xxx xxx xxx xxxx xx xxxxxxx xxx xxxx xxxxxx xxxxxxxx xx x xxxxxx. Xx xxx xxxxxxx xxxxx, xxx xxx xxxxxx xx xxx **Xxxxxxx** xxxxxxx xxxxxxxx xxxxxxx, xxxx xxxxxxxx xxx xxxx.

```csharp
if (myScanner.IsPreviewSupported(ImageScannerScanSource.Flatbed))
{
    rootPage.NotifyUser(&quot;Scanning&quot;, NotifyType.StatusMessage);
                // Scan API call to get preview from the flatbed.
                var result = await myScanner.ScanPreviewToStreamAsync(
                    ImageScannerScanSource.Flatbed, stream);
```

## Xxxxxx xxx xxxx

Xxx xxx xxx xxxxx xxxxxx xxx xxxx xxx xxxxxx xxxxxxx x xxxx, xxxx xxxx.

```csharp
void CancelScanning()
{
    if (ModelDataContext.ScenarioRunning)
    {
        if (cancellationToken != null)
        {
            cancellationToken.Cancel();
        }                
        DisplayImage.Source = null;
        ModelDataContext.ScenarioRunning = false;
        ModelDataContext.ClearFileList();
    }
}
```

## Xxxx xxxx xxxxxxxx

1.  Xxxxxx x **Xxxxxx.Xxxxxxxxx.XxxxxxxxxxxxXxxxxXxxxxx** xxxxxx.

```csharp
cancellationToken = new CancellationTokenSource();
```

2.  Xxx xx xxx xxxxxxxx xxxxx xxxxxxx xxx xxx xxx xxxxxxxx xx xxx xxxx.

```csharp
    rootPage.NotifyUser(&quot;Scanning&quot;, NotifyType.StatusMessage);
    var progress = new Progress&lt;UInt32&gt;(ScanProgress);
```

## Xxxxxxxx xx xxx xxxxxxxx xxxxxxx

Xxxxx xxx xxxx xx xxx xxxxxx xxxxxxxxxxx xxxxx xxx [**XxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR207881) xxxxx, xxx xxx xxxx xxxxxxx xxx *Xxxxxxxx Xxxxxxx* xxxxxxxxxx xx xxx xxxxxxxx xx xxxxx xxxxx xx xxxx xx xxxx xxxxxx. Xxx xxxx xxxx xx xxx xxxxxxxxxxxx, xxx [Xxx xxxxxxxxxx xxxxxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/Mt270968).

<!--HONumber=Mar16_HO1-->
