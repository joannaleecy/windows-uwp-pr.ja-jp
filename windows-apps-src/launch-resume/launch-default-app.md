---
xxxxx: Xxxxxx xxx xxxxxxx xxx xxx x XXX
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx xxxxxxx xxx xxx x Xxxxxxx Xxxxxxxx Xxxxxxxxxx (XXX). XXXx xxxxx xxx xx xxxxxx xxxxxxx xxx xx xxxxxxx x xxxxxxxx xxxx. Xxxx xxxxx xxxx xxxxxxxx xx xxxxxxxx xx xxx xxxx XXX xxxxxxx xxxxx xxxx Xxxxxxx.
xx.xxxxxxx: YXYXYXXY-XYYX-YXXY-YXYY-YYYYYXYYYYYX
---

# Xxxxxx xxx xxxxxxx xxx xxx x XXX


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-   [**XxxxxxxxxXxxxxxxxxxxXxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh965482)
-   [**XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314)

Xxxxx xxx xx xxxxxx xxx xxxxxxx xxx xxx x Xxxxxxx Xxxxxxxx Xxxxxxxxxx (XXX). XXXx xxxxx xxx xx xxxxxx xxxxxxx xxx xx xxxxxxx x xxxxxxxx xxxx. Xxxx xxxxx xxxx xxxxxxxx xx xxxxxxxx xx xxx xxxx XXX xxxxxxx xxxxx xxxx Xxxxxxx. Xxx xxx xxxxxx xxxxxx XXXx xxx. Xxx xxxx xxxx xxxxx xxxxxxxxxxx x xxxxxx XXX xxxxxx xxx xxxxxxxx XXX xxxxxxxxxx, xxx [Xxxxxx XXX xxxxxxxxxx](handle-uri-activation.md).

## Xxx xx xxxxxx x XXX


XXX xxxxxxx xxx xxx xxxx xxxx xx xxxxxxxx xxxxxxxxxx. Xxxx xx xxx xxx xxxxx x xxx xxxxx xxxxx **xxxxxx:**, xxx xxx xxxx xxx xxxxxxx xxx xxxxxxx xxxxx **xxxx:**. Xxxx xxxxx xxxxxxxxx xxxx xx xxx XXX xxxxxxx xxxxx xxxx Xxxxxxx:

-   Xxx [xx-xxxxxxxx: XXX xxxxxx](#settings) xxxxxxxx xxx Xxxxxxx Xxxxxxxx xxx
-   Xxx [xx-xxxxx: XXX xxxxxx](#store) xxxxxxxx xxx Xxxxxxx Xxxxx xxx
-   Xxx [xxxx: XXX xxxxxx](#browser) xxxxxxxx xxx xxxxxxx xxx xxxxxxx
-   Xxx [xxxxxx: XXX xxxxxx](#email) xxxxxxxx xxx xxxxxxx xxxxx xxx
-   Xxx [xxxxxxxx:, xx-xxxxx-xx:, xxx xx-xxxx-xx: XXX xxxxxxx](#maps) xxxxxx xxx Xxxxxxx Xxxx xxx

Xxx xxxxxxx, xxx xxxxxxxxx XXX xxxxx xxx xxxxxxx xxxxxxx xxx xxxxxxxx xxx Xxxx xxx xxxx.

`http://bing.com`

Xxx xxx xxxx xxxxxx xxxxxx XXX xxxxxxx xxx. Xx xxxxx xx xx xxx xxxxxxxxx xx xxxxxx xxxx XXX, xxx xxx xxxxxxxxx xx xxx xxx xxx xxxx xx xxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxxxx xx xxx](#recommend).

Xx xxxxxxx, xxxx xxx xxx'x xxxxxx xxx xxx xxxx xx xxxxxxxx. Xxx xxxx xxxxxxxxxx xxxxx xxx xx xxxxxxxx. Xxxx xxxx xxx xxx xxx xxxxxxxx xx xxxxxx xxx xxxx XXX xxxxxx. Xxx xxxxxxxxx xx xxxx xx xxx xxxxxxxx XXX xxxxxxx. Xxxxxxxxxxxxx xx xxxxxxxx XXX xxxxxxx xxx xxxxxxx. Xxx xxx xxxx xxxx xx xxxxxxxx XXX xxxxxxx, xxx [Xxxxxx XXX xxxxxxxxxx](handle-uri-activation.md). Xx xxxxx xxxxx xxxx xxxx xxx xxx xxx xxxx xxxxxxxxxx xxx xxxx XXX xxxxxx, xxxx xxx xxx xxxxxxxxx x xxxxxxxx xxx xx xx xxxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxxxx xx xxx](#recommend).

### Xxxx XxxxxxXxxXxxxx

Xxx xxx [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476) xxxxxx xx xxxxxx x XXX. Xxxx xxx xxxx xxxx xxxxxx, xxxx xxx xxxx xx xxx xxxxxxxxxx xxx, xxxx xx, xx xxxx xx xxxxxxx xx xxx xxxx. Xxxx xxxxxxxxxxx xxxxx xxxxxx xxxx xxx xxxx xxxxxxx xx xxxxxxx. Xx xxxx xxxx xxxxxxxxxxx, xxxx xxxx xxxx xxx xxx xxx XXX xxxxxxxx xxxxxxxx xx xxx XX xx xxxx xxx. Xxx xxxx xxxx xxxxxx xxxx xxxx xxxxxx xx xxxxxxxx x XXX xxxxxx. Xx xxx xxxxxxx xx xxxxxx x XXX xxx xxxx xxx xxx'x xx xxx xxxxxxxxxx, xxx xxxxxx xxxx xxxx xxx xxxx xxxxx xxxxxxxx xxxx xx xxxxxxx.

Xxxxx xxxxxx x [**Xxxxxx.Xxx**](T:System.Uri) xxxxxx xx xxxxxxxxx xxx XXX, xxxx xxxx xxxx xx xxx [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476) xxxxxx. Xxx xxx xxxxxx xxxxxx xx xxx xx xxx xxxx xxxxxxxxx, xx xxxxx xx xxx xxxxxxxxx xxxxxxx.

```cs
private async void launchURI_Click(object sender, RoutedEventArgs e)
{
   // The URI to launch
   var uriBing = new Uri(@"http://www.bing.com");

   // Launch the URI
   var success = await Windows.System.Launcher.LaunchUriAsync(uriBing);

   if (success)
   {
      // URI launched
   }
   else
   {
      // URI launch failed
   }
}
```

Xx xxxx xxxxx, xxx xxxxxxxxx xxxxxx xxxx xxxxxx xxx xxxx xx xxx xx xxx xxxxxxxx xxxx xx xxxxxx xxxx.

![x xxxxxxx xxxxxx xxxxxxxxx xx x xxxxxx xxx xxxxxxxxxx xx xxx xxx. xxx xxxxxx xxxx xxx xxxx xx xxxx xxxx xx xxxxxx xxxx xxx xxx ‘xxx’ xxx ‘xx’ xxxxxxx xx xxx xxxxxx xxxxx. xxx ‘xx’ xxxxxx xx xxxxxxxxxxx.](images/warningdialog.png)

Xx xxx xxxxxx xxxx xxxx xxxxxx xx xxxxx, xxx xxx [**Xxxxxxx.Xxxxxx.XxxxxxxxXxxxxxx.XxxxxXxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701442) xxxxxxxx xx xxxxxxxx xxxx xxx xxxxxxxxx xxxxxx xxxxxxx x xxxxxxx.

```cs
// The URI to launch
var uriBing = new Uri(@"http://www.bing.com");

// Set the option to show a warning
var promptOptions = new Windows.System.LauncherOptions();
promptOptions.TreatAsUntrusted = true;

// Launch the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriBing, promptOptions);
```

### Xxxxxxxxx xx xxx

Xx xxxx xxxxx, xxx xxxx xxxxx xxx xxxx xx xxx xxxxxxxxx xx xxxxxx xxx XXX xxxx xxx xxx xxxxxxxxx. Xx xxxxxxx, xxx xxxxxxxxx xxxxxx xxxxxxx xxxxx xxxxx xx xxxxxxxxx xxx xxxx xxxx x xxxx xx xxxxxx xxx xx xxxxxxxxxxx xxx xx xxx xxxxx. Xx xxx xxxx xx xxxx xxx xxxx x xxxxxxxx xxxxxxxxxxxxxx xxx xxxxx xxx xx xxxxxxx xx xxxx xxxxxxxx, xxx xxx xx xx xx xxxxxxx xxxx xxxxxxxxxxxxxx xxxxx xxxx xxx XXX xxxx xxx xxx xxxxxxxxx.

Xxxxxxxxxxxxxxx xxx xxxx xxxxxx xxxx xxxx xxxx xxx xxx xxx xxxxxxxxxx xx xxxxxx x XXX xxxxxx. Xx xxxxxxxxxxxx x xxxxxxxx xxx, Xxxxxxx xxxx xxxx xxxx xxx xx xx xx xxxxxxx xxxxxxxxx.

Xx xxxx x xxxxxxxxxxxxxx, xxxx xxx [**Xxxxxxx.Xxxxxx.Xxxxxxxx.XxxxxxXxxXxxxx(Xxx, XxxxxxxxXxxxxxx)**](https://msdn.microsoft.com/library/windows/apps/hh701484) xxxxxx xxxx [**XxxxxxxxXxxxxxx.xxxxxxxxxXxxxxxxxxxxXxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh965482) xxx xx xxx xxxxxxx xxxxxx xxxx xx xxx xxx xx xxx xxxxx xxxx xxx xxxx xx xxxxxxxxx. Xxx xxxxxxxxx xxxxxx xxxx xxxx xxxx xx xxxxxxx xxx xxxxxxx xxxxxx xx xxxxxx xxx xx xxx xx xxx xxxxx xxxx x xxxxxxxx xxxxxx xx xxxxxxx xxx xxxxxxxxxxx xxx xxxx xxx xxxxx.

```cs
// Set the recommended app
var options = new Windows.System.LauncherOptions();
options.PreferredApplicationPackageFamilyName = "Contoso.URIApp_8wknc82po1e";
options.PreferredApplicationDisplayName = "Contoso URI Ap";

// Launch the URI and pass in the recommended app 
// in case the user has no apps installed to handle the URI
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

### Xxx xxxxxxxxx xxxx xxxxxxxxxx

Xxxxxx xxxx xxxx xxxx [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476) xxx xxxxxxx xxxx xxxx xxxxxx xx xxxxxx xxxxx x XXX xxxxxx. Xx xxxxxxx, Xxxxxxx xxxxxxxx xx xxxxx xxx xxxxxxxxx xxxxx xxxxxxx xxxxxxx xxx xxxxxx xxx xxx xxx xxxxxx xxx xxxx xxxxxxx xxx XXX. Xxxxxx xxxx xxx xxx xxx [**XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314) xxxxxxxx xx xxxxxxxx xx xxx xxxxxxxxx xxxxxx xxxx xxxx xxxxxx xxxxx xxx xxxxxx xx xxxx xx xxxx xx xxxx xx xxx xxxxxxxxx xxxxx. **XxxxxxxXxxxxxxxxXxxx** xxx xxxx xx xxxx xx xxxxxxxx xxxx xxx xxxxxx xxx xxxxx'x xxxx xx xxxxxx xx xxxxxx xxxxx xxx XXX xxxxxx xxx xxx xx xxxxxxxxxx xxxxxxxx xx xxx xxxxxx xxx. Xxxx xxxxxxxx xxxx xxxxxxxxx xxx xxxxxxxxx xxxxxx xxxx xx xxx xxxxxxx xxx. Xx xxxxx'x xxxxxxx xxx xxxxxxxx xx xxxxx xxxx xxxx xxx xxxxxx xx xxxx xx xx xxxxxx xx xxx xxxx xxxx.

**Xxxx**  Xxxxxxx xxxxx xxxx xxxxxxx xxxxxxxx xxxxxxxxx xxxxxxx xxxx xx xxxxxxxxxx xxx xxxxxx xxx'x xxxxx xxxxxx xxxx, xxx xxxxxxx, xxx xxxxxxxxxx xx xxx xxxxxx xxx, xxx xxxxxx xx xxxx xx xxxxxx, xxx xxxxxx xxxxxxxxxxx, xxx xx xx. Xx xxxxxxx [**XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314), xxx xxxx'x xxxxxxxxxx x xxxxxxxx xxxxxxxxx xxxxxxxx xxx xxx xxxxxx xxx.

 

```cs
// Set the desired remaining view.
var options = new Windows.System.LauncherOptions();
options.DesiredRemainingView = Windows.UI.ViewManagement.ViewSizePreference.UseLess;

// Launch the URI 
var success = await Windows.System.Launcher.LaunchUriAsync(uriContoso, options);
```

## Xxxxxxx Xxxx xxx XXX xxxxxxx


Xxxx xxx xxx xxx xxx **xxxxxxxx:**, **xx-xxxxx-xx:**, xxx **xx-xxxx-xx:** XXX xxxxxxx xx [xxxxxx xxx Xxxxxxx Xxxx xxx](launch-maps-app.md) xx xxxxxxxx xxxx, xxxxxxxxxx, xxx xxxxxx xxxxxxx. Xxx xxxxxxx, xxx xxxxxxxxx XXX xxxxx xxx Xxxxxxx Xxxx xxx xxx xxxxxxxx x xxx xxxxxxxx xxxx Xxx Xxxx Xxxx.

`bingmaps:?cp=40.726966~-74.006076`

![xx xxxxxxx xx xxx xxxxxxx xxxx xxx.](images/mapnyc.png)

Xxx xxxx xxxx, xxx [Xxxxxx xxx Xxxxxxx Xxxx xxx](launch-maps-app.md). Xx xxx xxx xxx xxxxxxx xx xxxx xxx xxx, xxx [Xxxxxxx xxxx xxxx YX, YX, xxx Xxxxxxxxxx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt219695).

## Xxxxxxx Xxxxxxxx xxx XXX xxxxxx


Xxxx xxx xxx xxx xxx **xx-xxxxxxxx:** XXX xxxxxx xx [xxxxxx xxx Xxxxxxx Xxxxxxxx xxx](launch-settings-app.md). Xxxxxxxxx xx xxx Xxxxxxxx xxx xx xx xxxxxxxxx xxxx xx xxxxxxx x xxxxxxx-xxxxx xxx. Xx xxxx xxx xxx'x xxxxxx x xxxxxxxxx xxxxxxxx, xx xxxxxxxxx xxxxxxxxx xxx xxxx x xxxxxxxxxx xxxx xx xxx xxxxxxx xxxxxxxx xxx xxxx xxxxxxxx. Xxx xxxxxxx, xxx xxxxxxxxx XXX xxxxx xxx Xxxxxxxx xxx xxx xxxxxxxx xxx xxxxxx xxxxxxx xxxxxxxx.

`ms-settings:privacy-webcam`

![xxxxxx xxxxxxx xxxxxxxx.](images/privacyawarenesssettingsapp.png)

Xxx xxxx xxxx, xxx [Xxxxxx xxx Xxxxxxx Xxxxxxxx xxx](launch-settings-app.md) xxx [Xxxxxxxxxx xxx xxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh768223).

## Xxxxxxx Xxxxx xxx XXX xxxxxx


Xxxx xxx xxx xxx xxx **xx-xxxxxxx-xxxxx:** XXX xxxxxx xx [Xxxxxx xxx Xxxxxxx Xxxxx xxx](launch-store-app.md). Xxxx xxxxxxx xxxxxx xxxxx, xxxxxxx xxxxxx xxxxx, xxx xxxxxx xxxxx, xxx. Xxx xxxxxxx, xxx xxxxxxxxx XXX xxxxx xxx Xxxxxxx Xxxxx xxx xxx xxxxxxxx xxx xxxx xxxx xx xxx Xxxxx.

`ms-windows-store://home/`

Xxx xxxx xxxx, xxx [Xxxxxx xxx Xxxxxxx Xxxxx xxx](launch-store-app.md).

## Xxxx xxx XXX xxxxxx


Xxxx xxx xxx xxx xxx **xx-xxxx:** XXX xxxxxx xx xxxxxx xxx Xxxx xxx.

| XXX Xxxxxx       | Xxxxxxx                               |
|------------------|---------------------------------------|
| xx-xxxx:xxxxxxxx | Xxxxxxxx xxx Xxxxx xxx xxxxxxxx xxxx. |

 

## Xxxx xxx XXX xxxxxx


Xxxx xxx xxx xxx xxx **xx-xxxx:** XXX xxxxxx xx xxxxxx xxx Xxxxxxxxx xxx.

| XXX xxxxxx                               | Xxxxxxx                                                                                                                                                                                |
|------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| xx-xxxx:                                 | Xxxxxxxx xxx Xxxxxxxxx xxx.                                                                                                                                                            |
| xx-xxxx:?XxxxxxxXX={xxxxxxxxx}           | Xxxxxx xxx xxxxxxxxx xxxxxxxxxxx xx xx xxxxxxxx xxxx x xxxxxxxxxx xxxxxxx’x xxxxxxxxxxx.                                                                                               |
| xx-xxxx:?Xxxx={xxxx}                     | Xxxxxx xxx xxxxxxxxx xxxxxxxxxxx xx xx xxxxxxxx xxxx x xxxxxx xx xxx xx xxx xxxxxxx xx xxx xxxxxxx.                                                                                    |
| xx-xxxx:?Xxxxxxxxx={xxxxxxx}&Xxxx={xxxx} | Xxxxxx xxx xxxxxxxxx xxxxxxxxxxx xx xx xxxxxxxx xxxx x xxxxxxxxxx xxxxxxxxx' xxxxxxxxxxx, xxx xxxx x xxxxxx xx xxx xx xxx xxxxxxx xx xxx xxxxxxx. Xxxx: Xxxxxxxxx xxx xx xxxxxxxxxxxx. |
| xx-xxxx:?XxxxxxxxxXx={xxxxxxxxxXx}       | Xxxxxx xxx xxxxxxxxx xxxxxxxxxxx xx xx xxxxxxxx xxxx x xxxxxxxxxx xxxxxxxxx XX.                                                                                                        |

 

## Xxxxx XXX xxxxxx


Xxxx xxx xxx xxx xxx **xxxxxx:** XXX xxxxxx xx xxxxxx xxx xxxxxxx xxxx xxx.

| XXX Xxxxxx               | Xxxxxxx                                                                                                                                                     |
|--------------------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------|
| xxxxxx:                  | Xxxxxxxx xxx xxxxxxx xxxxx xxx.                                                                                                                             |
| xxxxxx:\[xxxxx xxxxxxx\] | Xxxxxxxx xxx xxxxx xxx xxx xxxxxxx x xxx xxxxxxx xxxx xxx xxxxxxxxx xxxxx xxxxxxx xx xxx Xx xxxx. Xxxx xxxx xxx xxxxx xx xxx xxxx xxxxx xxx xxxx xxxx xxxx. |

 

## XXXX XXX xxxxxx


Xxxx xxx xxx xxx xxx **xxxx:** XXX xxxxxx xx xxxxxx xxx xxxxxxx xxx xxxxxxx.

| XXX Xxxxxx | Xxxxxxx                           |
|------------|-----------------------------------|
| xxxx:      | Xxxxxxxx xxx xxxxxxx xxx xxxxxxx. |

 

## Xxxxxx Xxxxxxx xxx XXX xxxxxx


Xxxx xxx xxx xxx xxx **xx-xxxxxxxxxx:** XXX xxxxxx xx xxxxxx xxx Xxxxxx Xxxxxxx xxx.

| XXX Xxxxxx                                            | Xxxxxxx                                                                               |
|-------------------------------------------------------|---------------------------------------------------------------------------------------|
| xx-xxxxxxxxxx:?xxxxx=\[xxxxxxx\]&xxxxxx=\[Xxxxxx|XY\] | Xxxxxxxx xxx xxxxxxxxx Xxxxx xx Xxxxxxxx (XXX) xxxxxx xxx xxxx xxxxxxxx xxxx xxx XXX. |

 

## Xxxxxx xxx XXX xxxxxx


Xxxx xxx xxx xxx xxx **xx-xxxxxx:** XXX xxxxxx xx xxxxxx xxx Xxxxxx xxx.

Xxx xxxx xxxx, xxx [Xxxxxx xxx Xxxxxx xxx](launch-people-apps.md).

 

 



<!--HONumber=Mar16_HO1-->
