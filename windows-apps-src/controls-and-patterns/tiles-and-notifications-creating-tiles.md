---
Xxxxxxxxxxx: X xxxx xx xx xxx'x xxxxxxxxxxxxxx xx xxx Xxxxx xxxx. Xxxxx xxx xxx x xxxx. Xxxx xxx xxxxxx x xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxx xx Xxxxxxxxx Xxxxxx Xxxxxx, xx xxxxxxxx x xxxxxxx xxxx xxxx xxxxxxxx xxxx xxx'x xxxx xxx xxxx.
xxxxx: Xxxxx
xx.xxxxxxx: YYXYXYXY-XYYX-YYYY-YYYY-YXYYYXYYYYYY
xxxxx: Xxxxx
xxxxxxxx: xxxxxx.xxx
---

# Xxxxx xxx XXX xxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


X *xxxx* xx xx xxx'x xxxxxxxxxxxxxx xx xxx Xxxxx xxxx. Xxxxx xxx xxx x xxxx. Xxxx xxx xxxxxx x xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxx xxxxxxx xx Xxxxxxxxx Xxxxxx Xxxxxx, xx xxxxxxxx x xxxxxxx xxxx xxxx xxxxxxxx xxxx xxx'x xxxx xxx xxxx. Xxxxxxx xxxxxxxx xxxx xxxx xxxx xxxx xxx xx xxxxx xxxxxxxxx. Xxxxx xxxx xxx xx xxxxxxxxx, xxx xxx xxxxxx xxxx xxxx'x xxxxxxx xxxxxxx xxxxxxxxxxxxx; xxx xxxxxxx, xxx xxx xxxxxx xxx xxxx xx xxxxxxxxxxx xxx xxxxxxxxxxx xx xxx xxxx, xxxx xx xxxx xxxxxxxxx, xx xxx xxxxxxx xx xxx xxxx xxxxxx xxxxxx xxxxxxx.

## <span id="Configure_the_default_tile">
            </span>
            <span id="configure_the_default_tile">
            </span>
            <span id="CONFIGURE_THE_DEFAULT_TILE">
            </span>Xxxxxxxxx xxx xxxxxxx xxxx


Xxxx xxx xxxxxx x xxx xxxxxxx xx Xxxxxx Xxxxxx, xx xxxxxxx x xxxxxx xxxxxxx xxxx xxxx xxxxxxxx xxxx xxx'x xxxx xxx xxxx.

```XML
  <Applications>
    <Application Id="App"
      Executable="$targetnametoken$.exe"
      EntryPoint="ExampleApp.App">
      <uap:VisualElements
        DisplayName="ExampleApp"
        Square150x150Logo="Assets\Logo.png"
        Square44x44Logo="Assets\SmallLogo.png"
        Description="ExampleApp"
        BackgroundColor="#464646">
        <uap:SplashScreen Image="Assets\SplashScreen.png" />
      </uap:VisualElements>
    </Application>
  </Applications>
```

Xxxxx xxx x xxx xxxxx xxx xxxxxx xxxxxx:

-   XxxxxxxXxxx: Xxxxxxx xxxx xxxxx xxxx xxx xxxx xxx xxxx xx xxxxxxx xx xxxx xxxx.
-   XxxxxXxxx: Xxxxxxx xxxxx xx xxxxxxx xxxx xxx xxxx xxxxxxx xxxx xx xxx xx xxxxx, xx xxxxxxxxx xxxx xxx xx xxxxxxx x XxxxxXxxx xx xxxx, xx xxxx xxxx xxxx xxx'x xxxx xxxxx’x xxx xxxxxxxxx.
-   Xxxx xxxxxx:

    Xxx xxxxxx xxxxxxx xxxxx xxxxxx xxxx xxxx xxx. Xxx xxxx xxx xxxxxx xx xxxxxxxxx xxxxxx xxx xxxxxxxxx xxxxxx xxxxxx, xxx xxx xxx xxx xxxxxxxx xx xxxxxx xxxx xxx. Xx xxxxxx xxxx xxx xxx xxxxx xxxx xx x xxxxx xx xxxxxxx, xx xxxxxxxxx xxxx xxx xxxxxxx YYY%, YYY%, xxx YYY% xxxxx xxxxxxxx xx xxxx xxxxx.

    Xxxxxx xxxxxx xxxxxx xxxx xxxxxx xxxxxxxxxx:
    
    *&xx;xxxxx xxxx&xx;*.xxxxx-*&xx;xxxxx xxxxxx&xx;*.*&xx;xxxxx xxxx xxxxxxxxx&xx;* 


     

    For example: SmallLogo.scale-100.png

    When you refer to the image, you refer to it as *&lt;image name&gt;*.*&lt;image file extension&gt;* ("SmallLogo.png" in this example). The system will automatically select the appropriate scaled image for the device from the images you've provided.

-   Xxx xxx'x xxxx xx, xxx xx xxxxxx xxxxxxxxx xxxxxxxxx xxxxx xxx xxxx xxx xxxxx xxxx xxxxx xx xxxx xxx xxxx xxx xxxxxx xxxx xxx'x xxxx xx xxxxx xxxxx. Xx xxxxxxx xxxxx xxxxxxxxxx xxxxxx, xxx xxxxxx x `DefaultTile` xxxxxxx xxx xxx xxx `Wide310x150Logo` xxx `Square310x310Logo` xxxxxxxxxx xx xxxxxxx xxx xxxxxxxxxx xxxxxx:
```    XML
  <Applications>
        <Application Id="App"
          Executable="$targetnametoken$.exe"
          EntryPoint="ExampleApp.App">
          <uap:VisualElements
            DisplayName="ExampleApp"
            Square150x150Logo="Assets\Logo.png"
            Square44x44Logo="Assets\SmallLogo.png"
            Description="ExampleApp"
            BackgroundColor="#464646">
            <uap:DefaultTile
              Wide310x150Logo="Assets\WideLogo.png"
              Square310x310Logo="Assets\LargeLogo.png">
            </uap:DefaultTile>
            <uap:SplashScreen Image="Assets\SplashScreen.png" />
          </uap:VisualElements>
        </Application>
      </Applications>
```

## <span id="Use_notifications_to_customize_your_tile">
            </span>
            <span id="use_notifications_to_customize_your_tile">
            </span>
            <span id="USE_NOTIFICATIONS_TO_CUSTOMIZE_YOUR_TILE">
            </span>Xxx xxxxxxxxxxxxx xx xxxxxxxxx xxxx xxxx


Xxxxx xxxx xxx xx xxxxxxxxx, xxx xxx xxx xxxxxxxxxxxxx xx xxxxxxxxx xxxx xxxx. Xxx xxx xx xxxx xxx xxxxx xxxx xxxx xxx xxxxxxxx xx xx xxxxxxxx xx xxxx xxxxx, xxxx xx x xxxx xxxxxxxxxxxx.

1.  Xxxxxx xx XXX xxxxxxx (xx xxx xxxx xx xx [**Xxxxxxx.Xxxx.Xxx.Xxx.XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206173)) xxxx xxxxxxxxx xxx xxxx.

    -   Xxxxxxx YY xxxxxxxxxx x xxx xxxxxxxx xxxx xxxxxx xxx xxx xxx. Xxx xxxxxxxxxxxx, xxx [Xxxxxxxx xxxxx](tiles-and-notifications-create-adaptive-tiles.md). Xxx xxx xxxxxx, xxx xxx [Xxxxxxxx xxxxx xxxxxx](tiles-and-notifications-adaptive-tiles-schema.md). 

    -   Xxx xxx xxx xxx Xxxxxxx Y.Y xxxx xxxxxxxxx xx xxxxxx xxxx xxxx. Xxx xxxx xxxx, xxx [Xxxxxxxx xxxxx xxx xxxxxx (Xxxxxxx Y.Y)](https://msdn.microsoft.com/library/windows/apps/xaml/hh868260).

2.  Xxxxxx x xxxx xxxxxxxxxxxx xxxxxx xxx xxxx xx xxx [**XxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br206173) xxx xxxxxxx. Xxxxx xxx xxxxxxx xxxxx xx xxxxxxxxxxxx xxxxxxx:
    -   X [**Xxxxxxx.XX.XxxxxxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208616) xxxxxx xxx xxxxxxxx xxx xxxx xxxxxxxxxxx.
    -   X [**Xxxxxxx.XX.Xxxxxxxxxxxxx.XxxxxxxxxXxxxXxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh701637) xxxxxx xxx xxxxxxxx xxx xxxx xx xxxx xxxxx xx xxx xxxxxx.

3.  Xxx xxx [**Xxxxxxx.XX.Xxxxxxxxxxxxx.XxxxXxxxxxXxxxxxx.XxxxxxXxxxXxxxxxxXxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208623) xx xxxxxx x [**XxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208628) xxxxxx.
4.  Xxxx xxx [**XxxxXxxxxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208632) xxxxxx xxx xxxx xx xxx xxxx xxxxxxxxxxxx xxxxxx xxx xxxxxxx xx xxxx Y.

 

 




<!--HONumber=Mar16_HO1-->
