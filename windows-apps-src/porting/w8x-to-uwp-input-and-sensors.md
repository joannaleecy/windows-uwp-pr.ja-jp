---
xxxxxxxxxxx: Xxxx xxxx xxxxxxxxxx xxxx xxx xxxxxx xxxxxx xxx xxx xxxxxxx xxxxxxxx xxxxx xxxx, xxx xxxxxx xx, xxx xxxx.
xxxxx: Xxxxxxx Xxxxxxx Xxxxxxx Y.x xx XXX xxx X/X, xxxxxx, xxx xxx xxxxx'
xx.xxxxxxx: xxYYxxYx-xxxx-YYxY-YYYY-YYxxYxxYxYYx
---

# Xxxxxxx Xxxxxxx Xxxxxxx Y.x xx XXX xxx X/X, xxxxxx, xxx xxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxx xxxxxxxx xxxxx xxx [Xxxxxxx XXXX xxx XX](w8x-to-uwp-porting-xaml-and-ui.md).

Xxxx xxxx xxxxxxxxxx xxxx xxx xxxxxx xxxxxx xxx xxx xxxxxxx xxxxxxxx xxxxx xxxx, xxx xxxxxx xx, xxx xxxx. Xx xxx xxxx xxxxxxx xxxxxxxxxx xxxx. Xxx, xxxx xxxx xx xxx xxxxxxxxx xxxxxxx xx xx xxxxxx xxx XX xxxxx *xx* xxx xxxx xxxxx. Xxxx xxxx xxxxxxxx xxxxxxxxxxx xxxx xxx xxxxxxxxx xxxxxxxxxx, xxxxxxxxxxxxx, xxxxxxxxx, xxxxxxxxxx xxx xxxxxxx (xxxxx xxxxxxxxx xxxx xxxxxx xxxxxxxxxxx xxx xxxxxxxxx), (xxx)xxxxxxxx, xxx xxxxx xxxxxxxxxx xxxx xx xxxxx, xxxxx, xxxxxxxx, xxx xxx.

## Xxxxxxxxxxx xxxxxxxxx (xxxxxxx xxxxxxxx xxxxxxxxxx)


Xxx x Xxxxxxxxx Y.Y xxx, xxxxx xx x xxx-xxxxxx "xxxxxxxx xxxxxx" xx xxxx xxxxxxx xxx xxx xxxxxxxx xxxxxxxx xxx xxx xxxxxx xxxxxxx xxx xxxxxxxxxx xxxxx. Xxxxx xxxx xxxxxxxx xxxxxx xx xxxxx xxxx xx xxxxxxx xxxxx xx xxxxxx, xxx xxx x Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx, xxxxx xx xx xxxxxxxx xxxxxx xx xxx; xxx xxxxxxxxxx xxxxx xx xxxxxx xx xxxx xx xx xxx xxxxxxx xxxxxxxx.

Xxx xxxx xxxx, xxx [Xxx xxxxxxxxx](https://msdn.microsoft.com/library/windows/apps/mt243287).

## Xxxxxxxxxx xxxxx


Xxx xxx [**XxxxxXxxxxxx.XxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227352) xxxxxxxx, **XxxxxxxxxxXxxxXxxxx** xxx **XxxxxxxxxxXxxxxxxXxxxx** xxx xxxxxxxxxx xxx Xxxxxxx YY xxxx. Xxx xxx Xxxxxxx Xxxxx Xxxxx xxx xxxxx xxxxxxx. Xxx xxxx xxxxxxxxxxx, xxx [Xxxxxxxxxx Xxxxx](https://msdn.microsoft.com/library/windows/apps/mt282140).

## Xxxxxxxxx xxx xxxxxxxx xxxx xxx xx xxxxxxx xx


Xxx xxx xx xxxxxxxx xxxxx xxx-xxxxxxxxx xxxxxxx xxxx Xxxxxxx YY. Xxx xxx xxxxxxxxxx xxxxx xx xxxx xx xxx xxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxx xxxxxx xxx Xxxxxxx xxxxxxx. Xx xxx xxxx xxx xx xxxxx xx xxxxxxxx xxxx xxx xxxxxxxxx xx xxxxxxxxxx xxxxxx xxxxxxxx. Xx xxxxxx, xxx xxx xxxx xxx xxx xxxxxx xx xxxxx xxxxxx xx xxxxxxxxx xxx xx xxxx xxxxxx xxxxxxxx xxxxxxxxxxxx. Xxx xxxx xxxx xx xxxx xxxxxx xxxxxxxx xxx—xxx xxx xx xxxxxx xxxxx xxxxxx xxxxxx xx xxxxxx—xxx [Xxxxx xx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/dn894631).

Xx xxx xxxx xxxx xx xxxx Xxxxxxxxx Y.Y xxx xxxx xxxxxxx xxxx xxxxxxxxx xxxxxx xx xx xxxxxxx xx, xxxx xxx xxx xxxx xx xxxxxx xxxx xxxxxxxxx xx xxx xxxxxx xxx xxx xxxxx. Xx xxx xxx xx xxxxxxx xxx xxxxx xxxxxxx, xxx xxx xxxxxx xx xx, xxxx xxx xxx xxxx xx xxxxxxxx xx xxxxxxx xxx xxxxxxxxx xxxxxx xxxx.

**Xxxx**   Xx xxxxxxxxx xxxx xxx xxx xxx xxxxxxxxx xxxxxx xx xxxxxx xxxxxx xx xxxxxx xxx xxxxxxxx xx xxxxxxxx. Xxxxxxxxxxx xxx xxxxxxx xxxxxxxxx xxxxxx xx xxxxxx xxxxxx xx xxxxxxx xxx xxx xxxx xxx xx xxxxxxxxx xxxxxxx x xxxxxxxxxx xxxxxxxxx xxxxxx xx xxxxxx xxxxxx xxxxxxx xx xxxxxxx. Xxxxxx xxxx xxxxxxxxx xxx xxxxxxxxx xxxxxx xx xxxxxx xxxxxx (xxx xxxxxxx xxxxxx), xxxx xxx xxx xxxxxxxx xx xxx xxxxxxx xxxxxx (xxx [Xxxxxxxxxxx xxxxxxxxxxx, xxx xxxxxxxx xxxx](w8x-to-uwp-porting-to-a-uwp-project.md#reviewing-conditional-compilation)). Xx xxx xxxx xxxxxxx x xxxxxxxxxx xxxxxxxxx xxxxxx xx xxxxxx xxxxxx, xx xxxx xx xxx xx xx x xxxxxxx xxxxxxxxx xxxxxxx, xxxxxx xxxx xxxxxx xxx xxxx xxx xxxx xxx xxxxxxx.

 

Xx xxxxxx xxxx xxx'x XX xx xxxxxxxxx xxxxxxx, xxxxx xxx xxxxxxx xxxxxxxxxx xxxx xx xxxxxxxxx. Xxxxxxxx xx xxx xxxx-xxxxx xxxxxxxx xxx xxxxxxx xxxxxx xxxxxx xx xxx xxxxxx xxxx. Xx xxxx XXXX xxxxxx, xxxxxxxx xx xxx xxxxx xx xxxxxxxxx xxxxxx (xxxxxxxx xxxx xxxxxx) xx xxxx xxxx XX xxxxxx xx xxxxxxxxx xxxxxxxxxxx xxx xxxxx xxxxxxx (xxx [Xxxxxxxxx xxxxxx, xxxxxxx xxxxxxxx, xxx xxxxx xxxxxxx](w8x-to-uwp-porting-xaml-and-ui.md#effective-pixels).). Xxx xxx Xxxxxx Xxxxx Xxxxxxx'x xxxxxxxx xxxxxxxx xxx xxxxxxx xx xxxxx xxxx XX xx xxx xxxxxx xxxx (xxx [Xxxxx xx XXX xxxx](https://msdn.microsoft.com/library/windows/apps/dn894631).).

Xxxxxxx, xx xxx xxxx x xxxxxxxx xxxxx xx xx xxxxxxxxxxx xx xxxxxx xxx xxxxxx xxxxxx, xxxx xxx xxx xx xxxx. Xx xxxx xxxxxxx, xx xxx xxx [**XxxxxxxxxXxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn960165) xxxxx xx xxxxxxxx xx x xxxx xxxxxxxx xxx xxx xxxxxx xxxxxx xxxxxx xxxxx xxxxxxxxxxx, xxx xx xxxx xxxx xx xxxx xxxx xx x xxxxxxx xxxx xxxxxxxxx.

```csharp
   if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
        rootFrame.Navigate(typeof(MainPageMobile), e.Arguments);
    else
        rootFrame.Navigate(typeof(MainPage), e.Arguments);
```

Xxxx xxx xxx xxxx xxxxxxxxx xxx xxxxxx xxxxxx xxxx xx xx xxxxxxx xx xxxx xxx xxxxxxxx xxxxxxxxx xxxxxxx xxxx xxx xx xxxxxx. Xxx xxxxxxx xxxxx xxxxx xxx xx xx xxxx xxxxxxxxxxxx, xxx xxx [**XxxxxxxxXxxxxxx.XxxxxxxxxXxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206071) xxxxx xxxxxxxxx xxx xxxx xxxxxxx xxx xxxx xxx xxx xxxxx xx xxxxxxx xxxxxx xxxxxx-xxxxxxxx xxxxxxxxx xxxxx xx xxx xxxxxx xxxxxx xxxxxx.

```csharp
var qualifiers = Windows.ApplicationModel.Resources.Core.ResourceContext.GetForCurrentView().QualifierValues;
string deviceFamilyName;
bool isDeviceFamilyNameKnown = qualifiers.TryGetValue("DeviceFamily", out deviceFamilyName);
```

Xxxx, xxx [Xxxxxxxxxxx xxxxxxxxxxx, xxx xxxxxxxx xxxx](w8x-to-uwp-porting-to-a-uwp-project.md#reviewing-conditional-compilation).

## Xxxxxxxx


Xxxx xx xxx xxxx xxxxxxxx xxx Xxxxxxxx xxxxxxxxxx xx xxx xxx xxxxxxx xxxxxxxx xxxx xx Xxxxxxx YY, xxx xxxxxx xxxx xxxxxx xxx xxx-xxxx xxx xxxxxxx. Xxxx xx xxxx xxxxxxx xxx xxx xx x Xxxxxxx Xxxxx Xxxxx xxx xx x Xxxxxxx YY xxx. Xx, xx xxxx xxx xxxxxxxx xxx xxx xxxxxx xxxxxxx xxxxxx, xx xx xx xxxxxxxx xx xx-xxx xxxxxx, xxxx xxx xxxx xxxx xx xxxxxx xxxx xx xxxx xxx xxx-xxxx xx xxxx xxxxxxxx xxxx.

 

 




<!--HONumber=Mar16_HO1-->
