---
xx.xxxxxxx: YYxxYYYx-YYxY-xYxY-YxYx-YxYxxxxYYxYx
xxxxx: Xxxxxxxxxxx xxxxxxx
xxxxxxxxxxx: .
---
# Xxxxxxxxxxx xxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

X xxxxx xxxxxx xxx xxxx xx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706858) xxxx xxx xxxxxx. Xxxxxxxxx xxxxxxx xxxx xxxxxxxxx xxxxx xx xxxxxx. Xxx Xxxxxxxxxxx XXX xxxxxxxx xxxxx xxxxx xxxxx:

-   [
            **XxxxxxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589399) xxxxxx x xxxxxx xxxx x xxxxx xxxxx
-   [
            **XxxxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589415) xxxxxx x xxxxxx xxxx xxx xxxxxxxx xx x xxxxxxxxxxx xxxxxxx
-   [
            **XxxxxxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589406) xxxxxx x xxxxxx xxxx xxx xxxxxxxx xx x xxxxxxxxxxx xxxxxx

Xxx xxxxxxx xxxxxxx xxxx [**XxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589398); xxxx xxx xxxxxxx xxxxxxxx xx xxxxxxxxxx xx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706789) xxx xxx xxxxxx-xxxxxxxxxxx xxxxxxxxx. Xxxxxxxx xxxxxxx xxx xxxxxx-xxxxxxxxxxx, [**XxxxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589415) xxx [**XxxxxxxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589406) xxxxx x [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706858) xxxx xxxxxxxx xxxx x xxxxxxxxxxx xxxxxxx xxxxx xxx xxxxxx-xxxxxxxxx.

-   [Xxxxxxxxxxxxx](./composition-brushes.md#prerequisites)
-   [Xxxxx Xxxxxx](./composition-brushes.md#color-basics)
    -   [Xxxxx Xxxxx](./composition-brushes.md#alpha-modes)
-   [Xxxxx Xxxxx Xxxxx](./composition-brushes.md#using-color-brush)
-   [Xxxxx Xxxxxxx Xxxxx](./composition-brushes.md#using-surface-brush)
-   [Xxxxxxxxxxx Xxxxxxx xxx Xxxxxxxxx](./composition-brushes.md#configuring-stretch-and-alignment)

## Xxxxxxxxxxxxx

Xxxx xxxxxxxx xxxxxxx xxxx xxx xxx xxxxxxxx xxxx xxx xxxxxxxxx xx x xxxxx Xxxxxxxxxxx xxxxxxxxxxx, xx xxxxxxxxx xx [Xxxxxxxxxxx XX](visual-layer.md).

## Xxxxx Xxxxxx

Xxxxxx xxx xxxxx xxxx x [**XxxxxxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589399), xxx xxxx xx xxxxxx xxxxxx. Xxx Xxxxxxxxxxx XXX xxxx xxx Xxxxxxx Xxxxxxx xxxxxxxxx, Xxxxx, xx xxxxxxxxx x xxxxx. Xxx Xxxxx xxxxxxxxx xxxx xXXX xxxxxxxx. xXXX xxxxxxxx xxxxxxx xxxxxx xxxx xxxx xxxxxxxx: xxxxx, xxx, xxxxx, xxx xxxx. Xxxx xxxxxxxxx xx xxxxxxxxxxx xx x xxxxxxxx xxxxx xxxxx xxxx x xxxxxx xxxxx xx Y.Y xx Y.Y. X xxxxx xx Y.Y xxxxxxxxx xxx xxxxxxxx xxxxxxx xx xxxx xxxxx, xxxxx x xxxxx xx Y.Y xxxxxxxxx xxxx xxx xxxxx xx xxxxx xxxxxxx. Xxx xxx xxxxx xxxxxxxxx, Y.Y xxxxxxxxxx x xxxxx xxxxxxxxxxx xxxxx xxx Y.Y xxxxxxxxxx x xxxxx xxxxxx xxxxx.

### Xxxxx Xxxxx

Xxxxx xxxxxx xx [**XxxxxxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589399) xxx xxxxxx xxxxxxxxxxx xx xxxxxxxx xxxxx.

## Xxxxx Xxxxx Xxxxx

Xx xxxxxx x xxxxx xxxxx, xxxx xxx Xxxxxxxxxx.[**XxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositor.createcolorbrush.aspx) xxxxxx, xxxxx xxxxxxx x [**XxxxxxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589399). Xxx xxxxxxx xxxxx xxx **XxxxxxxxxxxXxxxxXxxxx** xx \#YYYYYYYY. Xxx xxxxxxxxx xxxxxxxxxxxx xxx xxxx xxxxx x xxxxx xxxxxx xxxx xx xxxxxx x xxxxxxxxx xxxx xx xxxxxxx xxxx x xxxxx xxxxx xxxxx xxx xxxxxxx xxxx x xxxxx xxxxx xxxxx xxxx xxx xxx xxxxx xxxxx xx YxYXXXYY.

![XxxxxxxxxxxXxxxxXxxxx](images/composition-compositioncolorbrush.png)
```cs
Compositor _compositor;
ContainerVisual _container;
SpriteVisual visual1, visual2;
CompositionColorBrush _blackBrush, _greenBrush; 

_compositor = new Compositor();
_container = _compositor.CreateContainerVisual();

_blackBrush = _compositor.CreateColorBrush(Colors.Black);
visual1 = _compositor.CreateSpriteVisual();
visual1.Brush = _blackBrush;
visual1.Size = new Vector2(156, 156);
visual1.Offset = new Vector3(0, 0, 0);

_ greenBrush = _compositor.CreateColorBrush(Color.FromArgb(0xff, 0x9A, 0xCD, 0x32));
Visual2 = _compositor.CreateSpriteVisual();
Visual2.Brush = _greenBrush;
Visual2.Size = new Vector2(150, 150);
Visual2.Offset = new Vector3(3, 3, 0);
```

Xxxxxx xxxxx xxxxxxx, xxxxxxxx x [**XxxxxxxxxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589399) xx x xxxxxxxxxx xxxxxxxxxxx xxxxxxxxx. Xxx xxx xxxxxx **XxxxxxxxxxxXxxxxXxxxx** xxxxxxx xxxx xxxx xxx xxxxxx xxxx xxxxxx xx xx xxxxxxxxxxx xxxxxx.

## Xxxxx Xxxxxxx Xxxxx

X [**XxxxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589415) xxxxxx x xxxxxx xxxx x xxxxxxxxxxx xxxxxxx (xxxxxxxxxxx xx x [**XXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706819) xxxxxx). Xxx xxxxxxxxx xxxxxxxxxxxx xxxxx x xxxxxx xxxxxx xxxxxxx xxxx x xxxxxx xx xxxxxxxx xxxxxxxx xxxx x **XXxxxxxxxxxxXxxxxxx** xxxxx XYX.

![XxxxxxxxxxxXxxxxxxXxxxx](images/composition-compositionsurfacebrush.png)
Xxx xxxxx xxxxxxx xxxxxxxxxxx x xxxxxxxxxxx xxxxxxx xxx xxx xxxx xxx xxxxx. Xxx xxxxxxxxxxx xxxxxxx xx xxxxxxx xxxxx x xxxxxx xxxxxx, XxxxXxxxx xxxx xxxxx xx x [**XxxxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589415) xxx x Xxx xx x xxxxxx. Xx xxxxx xxx xxxxx xxxx xxx Xxx, xxxxxxx xxx xxxxx xxxx x [**XXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706819) xxx xxxx xxx xxxxxxx xx xxxxxxx xx xxx **XxxxxxxxxxxXxxxxxxXxxxx**. Xxxx, **XXxxxxxxxxxxXxxxxxx** xx xxxxxxx xx Xxxxxx xxxx xxxx, xxxxx XxxxXxxxx xxxxxx xx xxxxxxxxxxx xx xxxxxx xxxx.

```cs
LoadImage(Brush,
          "ms-appx:///Assets/liqorice.png");
```

Xx xxxxxx xxx xxxxxxx xxxxx, xxxx xxx Xxxxxxxxxx.[**XxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositor.createsurfacebrush.aspx) xxxxxx. Xxx xxxxxx xxxxxxx x [**XxxxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589415) xxxxxx. Xxx xxxx xxxxx xxxxxxxxxxx xxx xxxx xxxx xxx xx xxxx xx xxxxx x xxxxxx xxxx xxxxxxxx xx x **XxxxxxxxxxxXxxxxxxXxxxx**.

```cs
Compositor _compositor;
ContainerVisual _container;
SpriteVisual visual;
CompositionSurfaceBrush _surfaceBrush;

_surfaceBrush = _compositor.CreateSurfaceBrush();
LoadImage(_surfaceBrush, "ms-appx:///Assets/liqorice.png");
visual.Brush = _surfaceBrush;
```

## Xxxxxxxxxxx Xxxxxxx xxx Xxxxxxxxx

Xxxxxxxxx, xxx xxxxxxxx xx xxx [**XXxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706819) xxx x [**XxxxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589415) xxxxx’x xxxxxxxxxx xxxx xxx xxxxx xx xxx xxxxxx xxxx xx xxxxx xxxxxxx. Xxxx xxxx xxxxxxx, xxx Xxxxxxxxxxx XXX xxxx xxx xxxxx’x [**XxxxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionsurfacebrush.horizontalalignmentratio.aspx), [**XxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionsurfacebrush.verticalalignmentratio) xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionsurfacebrush.stretch) xxxx xxxxxxxx xx xxxxxxxxx xxx xx xxxx xxx xxxxxxxxx xxxx.

-   [
            **XxxxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionsurfacebrush.horizontalalignmentratio.aspx) xxx [**XxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionsurfacebrush.verticalalignmentratio) xxx xx xxxx xxxxx xxx xxx xx xxxx xx xxxxxxx xxx xxxxxxxxxxx xx xxx xxxxx xxxxxx xxx xxxxxx xxxxxx.
    -   Xxxxx Y.Y xxxxxx xxx xxxx/xxx xxxxxx xx xxx xxxxx xxxx xxx xxxx/xxx xxxxxx xx xxx xxxxxx
    -   Xxxxx xx Y.Y xxxxxx xxx xxxxxx xx xxx xxxxx xxxx xxx xxxxxx xx xxx xxxxxx
    -   Xxxxx xx Y.Y xxxxxx xxx xxxxx/xxxxxx xxxxxx xx xxx xxxxx xxxx xxx xxxxx/xxxxxx xxxxxx xx xxx xxxxxx
-   Xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionsurfacebrush.stretch) xxxxxxxx xxxxxxx xxxxx xxxxxx, xxxxx xxx [**XxxxxxxxxxxXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706786) xxxxxxxxxxx xxxxxxx:
    -   Xxxx: Xxx xxxxx xxxxx'x xxxxxxx xx xxxx xxx xxxxxx xxxxxx. Xx xxxxxxx xxxx xxxx Xxxxxxx xxxxxxx: xx xxx xxxxx xx xxxxxx xxxx xxx xxxxxx xxxxxx, xxx xxxxxxxx xx xxx xxxxx xxxx xx xxxxxxx. Xxx xxxxxxx xx xxxxx xxxx xx xxxxx xxx xxxxxx xxxxxx xxx xx xxxxxxxxxx xx xxxxx xxx [**XxxxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionsurfacebrush.horizontalalignmentratio.aspx) xxx [**XxxxxxxxXxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionsurfacebrush.verticalalignmentratio) xxxxxxxxxx.
    -   Xxxxxxx: Xxx xxxxx xx xxxxxx xx xxx xxx xxxxxx xxxxxx; xxx xxxxxx xxxxx xx xxx xxxxx xx xxxxxxxxx. Xxxx xx xxx xxxxxxx xxxxx.
    -   XxxxxxxXxXxxx: Xxx xxxxx xx xxxxxx xx xxxx xx xxxxxxxxxx xxxxx xxx xxxxxx xxxxxx; xxx xxxxxx xxxxx xx xxx xxxxx xx xxxxxxxxx.
    -   Xxxx: Xxx xxxxx xx xxxxxx xx xxx xxx xxxxxx xxxxxx. Xxxxxxx xxx xxxxx’x xxxxxx xxx xxxxx xxx xxxxxx xxxxxxxxxxxxx, xxx xxxxxxxx xxxxxx xxxxx xx xxx xxxxx xxxxx xxx xx xxxxxxxxx. Xxxx xx, xxx xxxxx xxxxx xx xxxxxxxxx xx xxxxxxxxxx xxxx xxx xxxxxx xxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
