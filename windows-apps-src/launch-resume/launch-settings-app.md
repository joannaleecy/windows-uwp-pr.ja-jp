---
xxxxx: Xxxxxx xxx Xxxxxxx Xxxxxxxx xxx
xxxxxxxxxxx: Xxxxx xxx xx xxxxxx xxx Xxxxxxx Xxxxxxxx xxx xxxx xxxx xxx. Xxxx xxxxx xxxxxxxxx xxx xx-xxxxxxxx XXX xxxxxx. Xxx xxxx XXX xxxxxx xx xxxxxx xxx Xxxxxxx Xxxxxxxx xxx xx xxxxxxxx xxxxxxxx xxxxx.
xx.xxxxxxx: XYYXYXXX-YXXX-YYYY-XXYX-YYYYXXXYYYYY
---

# Xxxxxx xxx Xxxxxxx Xxxxxxxx xxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476)
-   [**XxxxxxxxxXxxxxxxxxxxXxxxxxxXxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/hh965482)
-   [**XxxxxxxXxxxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/dn298314)

Xxxxx xxx xx xxxxxx xxx Xxxxxxx Xxxxxxxx xxx xxxx xxxx xxx. Xxxx xxxxx xxxxxxxxx xxx **xx-xxxxxxxx:** XXX xxxxxx. Xxx xxxx XXX xxxxxx xx xxxxxx xxx Xxxxxxx Xxxxxxxx xxx xx xxxxxxxx xxxxxxxx xxxxx.

Xxxxxxxxx xx xxx Xxxxxxxx xxx xx xx xxxxxxxxx xxxx xx xxxxxxx x xxxxxxx-xxxxx xxx. Xx xxxx xxx xxx'x xxxxxx x xxxxxxxxx xxxxxxxx, xx xxxxxxxxx xxxxxxxxx xxx xxxx x xxxxxxxxxx xxxx xx xxx xxxxxxx xxxxxxxx xxx xxxx xxxxxxxx. Xxx xxxx xxxx, xxx [Xxxxxxxxxx xxx xxxxxxx-xxxxx xxxx](https://msdn.microsoft.com/library/windows/apps/hh768223).

## Xxx xx xxxxxx xxx Xxxxxxxx xxx


Xx xxxxxxx xxxxxxxx xxx'x xxx xxxx xxx xxxxxx x xxxxxxxxx xxxxxxxx, xx xxxxxxxxx xxxxxxxxx x xxxxxxxxxx xxxx xx xxx xxxxxxx xxxxxxxx xx xxx **Xxxxxxxx** xxx. Xxxx xxxx xxxx xx xxxxxx xxx xxxxx xx xxxxxx xxxxx xxxxxxxx.

Xx xxxxxx xxxxxxxx xxxx xxx **Xxxxxxxx** xxx, xxx xxx `ms-settings:` XXX xxxxxx xx xxxxx xx xxx xxxxxxxxx xxxxxxxx.

Xx xxxx xxxxxxx, x Xxxxxxxxx XXXX xxxxxxx xx xxxx xx xxxxxx xxx xxxxxxx xxxxxxxx xxxx xxx xxx xxxxxxxxxx xxxxx xxx `ms-settings:privacy-microphone` XXX.

```xaml
<!--Set Visibility to Visible when access to the microphone is denied -->  
<TextBlock x:Name="LocationDisabledMessage" FontStyle="Italic" 
                 Visibility="Collapsed" Margin="0,15,0,0" TextWrapping="Wrap" >
          <Run Text="This app is not able to access the microphone. Go to " />
              <Hyperlink NavigateUri="ms-settings:privacy-microphone">
                  <Run Text="Settings" />
              </Hyperlink>
          <Run Text=" to check the microphone privacy settings."/>
</TextBlock>
```

Xxxxxxxxxxxxx, xxxx xxx xxx xxxx xxx [**XxxxxxXxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701476) xxxxxx xx xxxxxx xxx **Xxxxxxxx** xxx xxxx xxxx.

```cs
using Windows.System;
...
bool result = await Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-webcam"));
```

Xxxx xxxxxxx xxxxx xxx xx xxxxxx xx xxx xxxxxxx xxxxxxxx xxxx xxx xxx xxxxxx xxxxx xxx `ms-settings:privacy-webcam` XXX.

![xxxxxx xxxxxxx xxxxxxxx.](images/privacyawarenesssettingsapp.png)

Xxx xxxx xxxx xxxxx xxxxxxxxx XXXx, xxx [Xxxxxx xxx xxxxxxx xxx xxx x XXX](launch-default-app.md).

## xx-xxxxxxxx: XXX xxxxxx xxxxxxxxx


Xxx xxx xxxxxxxxx XXXx xx xxxx xxxxxxx xxxxx xx xxx Xxxxxxxx xxx. Xxxx xxxx xxx Xxxxxxxxx XXXx xxxxxx xxxxxxxxx xxxxxxx xxx xxxxxxxx xxxx xxxxxx xx Xxxxxxx YY xxx xxxxxxx xxxxxxxx (Xxxx, Xxx, Xxxxxxxxxx, xxx Xxxxxxxxx), Xxxxxxx YY Xxxxxx, xx xxxx.

| Xxxxxxxx           | Xxxxxxxx xxxx                          | Xxxxxxxxx XXXx | XXX                                       |
|--------------------|----------------------------------------|----------------|-------------------------------------------|
| Xxxx Xxxx          | Xxxxxxx xxxx xxx Xxxxxxxx              | Xxxx           | xx-xxxxxxxx:                              |
| Xxxxxx             | Xxxxxxx                                | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxxx                |
|                    | Xxxxxxxxxxxxx & xxxxxxx                | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxx                 |
|                    | Xxxxx                                  | Xxxxxx xxxx    | xx-xxxxxxxx:xxxxx                         |
|                    | Xxxxxxxxx                              | Xxxxxx xxxx    | xx-xxxxxxxx:xxxxxxxxx                     |
|                    | Xxxxxxx Xxxxx                          | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx                  |
|                    | Xxxxxxx Xxxxx / Xxxxxxx xxxxx xxxxxxxx | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxx         |
|                    | Xxxxxxx Xxxxx / Xxxxxxx xxx            | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxxxxxx     |
|                    | Xxxxx & xxxxx                          | Xxxxxxx xxxx   | xx-xxxxxxxx:xxxxxxxxxx                    |
|                    | Xxxxxxx: Xxxxx                         | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxxxxx              |
|                    |                                        |                |                                           |
|                    | Xxxxxx: Xxxxxx xxxxxxxxxx              |                |                                           |
|                    | Xxxxxxx Xxxx                           | Xxxx           | xx-xxxxxxxx:xxxx                          |
|                    | Xxxxx                                  | Xxxx           | xx-xxxxxxxx:xxxxx                         |
| Xxxxxxx            | Xxxxxxx xxxxxx                         | Xxxxxx xxxx    | xx-xxxxxxxx:xxxxxx                        |
|                    | Xxxxxxxxx                              | Xxxxxxx xxxx   | xx-xxxxxxxx:xxxxxxxxx                     |
|                    | Xxxxx & xxxxxxxx                       | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxx                 |
|                    | XXX                                    | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxxxx               |
| Xxxxxxx & Xxxxxxxx | Xx-Xx                                  | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxx                  |
|                    | Xxxxxxxx xxxx                          | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxxxx          |
| Xxxxxxx & Xxxxxxxx | Xxxx xxxxx                             | Xxxx           | xx-xxxxxxxx:xxxxxxxxx                     |
|                    | Xxxxxxxx & XXX                         | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxx              |
|                    | Xxxxxx xxxxxxx                         | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxxxxx         |
|                    | Xxxxx                                  | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxx                 |
| Xxxxxxxxxxxxxxx    | Xxxxxxxxxxxxxxx (xxxxxxxx)             | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxxxx               |
|                    | Xxxxxxxxxx                             | Xxxxxxx xxxx   | xx-xxxxxxxx:xxxxxxxxxxxxxxx-xxxxxxxxxx    |
|                    | Xxxxxx                                 | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxxxx-xxxxxx        |
|                    | Xxxxxx                                 | Xxxxxx xxxx    | xx-xxxxxxxx:xxxxxx                        |
|                    | Xxxx xxxxxx                            | Xxxx           | xx-xxxxxxxx:xxxxxxxxxx                    |
| Xxxxxxxx           | Xxxx xxxxx xxx xxxxxxxx                | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxxxxxx              |
|                    | Xxxx xxxxxx                            | Xxxx           | xx-xxxxxxxx:xxxxxxxxx                     |
|                    | Xxxx xxxx xxxxxxxx                     | Xxxx           | xx-xxxxxxxx:xxxx                          |
| Xxxx xxx xxxxxxxx  | Xxxx & xxxx                            | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxx                   |
|                    | Xxxxxx & xxxxxxxx                      | Xxxxxxx xxxx   | xx-xxxxxxxx:xxxxxxxxxxxxxx                |
| Xxxx xx Xxxxxx     | Xxxxxxxx                               | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxx         |
|                    | Xxxxxxxxx                              | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxxx        |
|                    | Xxxx xxxxxxxx                          | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxxxxxx     |
|                    | Xxxxxx xxxxxxxx                        | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxxxxxxxxxx |
|                    | Xxxxxxxx                               | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxx         |
|                    | Xxxxx                                  | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxx            |
|                    | Xxxxx xxxxxxx                          | Xxxx           | xx-xxxxxxxx:xxxxxxxxxxxx-xxxxxxxxxxxx     |
| Xxxxxxx            | Xxxxxxxx                               | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxx              |
|                    | Xxxxxx                                 | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxx                |
|                    | Xxxxxxxxxx                             | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxx            |
|                    | Xxxxxx                                 | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxx                |
|                    | Xxxxxx, xxxxxx & xxxxxx                | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxxxx          |
|                    | Xxxxxxx xxxx                           | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxxx           |
|                    | Xxxxxxxx                               | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxx              |
|                    | Xxxxxxxx                               | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxx              |
|                    | Xxxx xxxxxxx                           | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxxx           |
|                    | Xxxxx                                  | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxx                 |
|                    | Xxxxxxxxx                              | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxx             |
|                    | Xxxxxx                                 | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxx                |
|                    | Xxxxxxxxxx Xxxx                        | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxxxxxx        |
|                    | Xxxxx xxxxxxx                          | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxxxxxxx         |
|                    | Xxxxxxxx & xxxxxxxxxxx                 | Xxxx           | xx-xxxxxxxx:xxxxxxx-xxxxxxxx              |
| Xxxxxx & xxxxxxxx  | Xxx xxxxxxxxxx                         | Xxxx           | xx-xxxxxxxx:xxxxxxxxxx                    |
 



<!--HONumber=Mar16_HO1-->
