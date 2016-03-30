---
xx.xxxxxxx: YxYxYxxY-YYYx-YxYY-YYYY-YxxxYxYYxxYx
xxxxx: Xxxxxxxxxxx xxxxxxx
xxxxxxxxxxx: Xxx xxxxxx XXXx xxxxxx xxxxxxxxxx xx xxxxxxxxx xxx xxxxx XX xx xxxxxxxx.
---
# Xxxxxxxxxxx xxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx [**Xxxxxxx.XX.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706878) XxxXX XXX xxxxxx Xxxx-xxxx xxxxxxx xx xx xxxxxxx xx xxxxxx xxx XX xxxx xxxxxxxxxx xxxxxx xxxxxxxxxx. Xx xxxx xxxxxxxx, xx’xx xxx xxxxxxx xxx xxxxxxxxxxxxx xxxxxxxxx xxxx xxxxxx xxxxxxx xx xx xxxxxxx xx x xxxxxxxxxxx xxxxxx.

Xx xxxxxxx [Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX)](https://msdn.microsoft.com/library/windows/apps/dn726767.aspx) xxxxxxxxxxx xxx xxxxxxxxxx xxxxxxxxxx xxxxxxx xx xxxxx xxxxxxxxxxxx, xxxxxxxxxxx xxxxxxx xxxxxxxx XxxYX’x XXxxxxxxxXxxxxx xxxxxxxxx xx xxx xxxxxx xxxxxxxxxxxx xxx xxx [Xxxxxxxxx.Xxxxxxxx.Xxxxxx.Xxxxxxx](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.md) Xxxxxxxxx.

Xxxxx xxxxxxx xxx xxxx xx xxxxx xxxxx xx xx xxxxxxxxxxx xx xxxxxxxx xxxxxxx xx x xxx xx xxxxxxxx xxxxxx. Xxxxxxx YY xxxxxxxxxxx xxxxxx XXXx xxx xxxxxxx xx Xxxxxx Xxxxxxx. Xxx XxxxxxXxxxxx xxxxxx xxx xxxxxxxxxxx xxx xxxxxxxxx xx xxxxx, xxxxx xxx xxxxxx xxxxxxxx. Xxx XxxxxxXxxxxx xx x xxxxxxxxxxx xxxxxx xxxx xxxx xxx xxxx x YX xxxxxxxxx xxxx x xxxxx. Xxx xxxxxx xxxxxxx xxx xxxxxx xx xxx xxxxxxxxx xxx xxx xxxxx xxxxxxx xxx xxxxxx xxxx xx xxxxx xxx xxxxxxxxx.

Xxxxxx xxxxxxx xxx xxxx xx xxxxxxxxxxx xxxx xxxxxxx xxxxx xxxxxxx xxxxx xxxx xxx xxxxxx xx xx xxxxxx xxxxx. Xxxxxxx xxx xxxxxxxxx xxxxxxxx xxxxxxxx/xxxxxxxx, xxx xxx xxx xxxxxx xx xxxxx xxxxxxxxxxx xxxxx.

## Xxxxxx Xxxxxxxx

-   [Xxxxxx Xxxxxxx](./composition-effects.md#effect-library)
-   [Xxxxxxxx Xxxxxxx](./composition-effects.md#chaining-effects)
-   [Xxxxxxxxx Xxxxxxx](./composition-effects.md#animation-support)
-   [Xxxxxx xxxxxxxxxx – Xxxxxxxx xx. Xxxxxxxx](./composition-effects.md#effect-properties-constant-vs-animated)
-   [Xxxxxxxx Xxxxxx Xxxxxxxxx xxxx Xxxxxxxxxxx Xxxxxxxxxx](./composition-effects.md#multiple-effect-instances-with-independent-properties)

### Xxxxxx Xxxxxxx

Xxxxxxxxx xxxxxxxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxxx:

| Xxxxxx               | Xxxxxxxxxxx                                                                                                                                                                                                                |
|----------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| YX xxxxxx xxxxxxxxx  | Xxxxxxx x YX xxxxxx xxxxxxxxx xxxxxx xx xx xxxxx. Xx xxxx xxxx xxxxxx xx xxxxxxx xxxxx xxxx xx xxx xxxxxx [xxxxxxx](https://github.com/Microsoft/composition/tree/master/SDK10240_WIN10_RTM/BasicCompositonEffects).       |
| Xxxxxxxxxx xxxxxxxxx | Xxxxxxxx xxx xxxxxx xxxxx x xxxxxxxx xxxxxxxx. Xx xxxx xxxxxxxxxx xxxxxxxxx xx xxxxxx x xxxxxxxxx xxxxxx xx xxx [xxxxxxx](https://github.com/Microsoft/composition/tree/master/SDK10240_WIN10_RTM/BasicCompositonEffects). |
| Xxxxx xxxxxx         | Xxxxxxx x xxxxx xxxxxx xxxx xxxxxxxx xxx xxxxxx. Xxxxxxxxxxx xxxxxxxx YY xx xxx YY [xxxxx xxxxx](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_Effects_BlendEffectMode.md) xxxxxxxxx xx XxxYX.        |
| Xxxxx xxxxxx         | Xxxxxxxxx xx xxxxx xxxxxxxxxx x xxxxx xxxxx.                                                                                                                                                                               |
| Xxxxxxxxx            | Xxxxxxxx xxx xxxxxx. Xxxxxxxxxxx xxxxxxxx xxx YY [xxxxxxxxx xxxxx](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_CanvasComposite.md) xxxxxxxxx xx XxxYX.                                              |
| Xxxxxxxx             | Xxxxxxxxx xx xxxxxxxxx xxx xxxxxxxx xx xx xxxxx.                                                                                                                                                                           |
| Xxxxxxxx             | Xxxxxxxxx xx xxxxxxxxx xxx xxxxxxxx xx xx xxxxx.                                                                                                                                                                           |
| Xxxxxxxxx            | Xxxxxxxx xx xxxxx xx xxxxxxxxxxxxx xxxx.                                                                                                                                                                                   |
| Xxxxx xxxxxxxx       | Xxxxxx xxx xxxxxx xx xx xxxxx xx xxxxxxxx x xxx-xxxxxxx xxxxx xxxxxxxx xxxxxxxx.                                                                                                                                           |
| Xxx xxxxxx           | Xxxxxx xxx xxxxx xx xx xxxxx xx xxxxxxxx xxx xxx xxxxxx.                                                                                                                                                                   |
| Xxxxxx               | Xxxxxxx xxx xxxxxx xx xx xxxxx.                                                                                                                                                                                            |
| Xxxxxxxx             | Xxxxxx xxx xxxxxxxxxx xx xx xxxxx.                                                                                                                                                                                         |
| Xxxxx                | Xxxxxxxx xx xxxxx xx xxxxx xxxxx.                                                                                                                                                                                          |
| Xxxxxxxxxxx xxx xxxx | Xxxxxxx xxx xxxxxxxxxxx xxx/xx xxxx xx xx xxxxx.                                                                                                                                                                           |

 

Xxx XxxYX’x [Xxxxxxxxx.Xxxxxxxx.Xxxxxx.Xxxxxxx](http://microsoft.github.io/Win2D/html/N_Microsoft_Graphics_Canvas_Effects.md) Xxxxxxxxx xxx xxxx xxxxxxxx xxxxxxxxxxx. Xxxxxxx xxx xxxxxxxxx xx xxxxxxxxxxx xxx xxxxx xx \[XxXxxxxxxxxxx\].

### Xxxxxxxx Xxxxxxx

Xxxxxxx xxx xx xxxxxxx, xxxxxxxx xx xxxxxxxxxxx xx xxxxxxxxxxxxxx xxx xxxxxxxx xxxxxxx xx xx xxxxx. Xxxxxx xxxxxx xxx xxxxxxx xxxxxxxx xxxxxxx xxxx xxx xxxxx xx xxx xxx xxxxx. Xxxx xxxxxxxxxx xxxx xxxxxx, xxxxxx xxx xx xxxxxx xx xxxxx xx xxxx xxxxxx.

```cs
IGraphicsEffect graphicsEffect =
new Microsoft.Graphics.Canvas.Effects.ArithmeticCompositeEffect
{
  Source1 = new CompositionEffectSourceParameter("source1"),
  Source2 = new SaturationEffect
  {
    Saturation = 0,
    Source = new CompositionEffectSourceParameter("source2")
  },
  MultiplyAmount = 0,
  Source1Amount = 0.5f,
  Source2Amount = 0.5f,
  Offset = 0    
}
  
```

Xxx xxxxxxx xxxxx xxxxxxxxx xx xxxxxxxxxx xxxxxxxxx xxxxxx xxxxx xxx xxx xxxxxx. Xxx xxxxxx xxxxx xxx x xxxxxxxxxx xxxxxx xxxx x .Y xxxxxxxxxx xxxxxxxx.

### Xxxxxxxxx Xxxxxxx

Xxxxxx xxxxxxxxxx xxxxxxx xxxxxxxxx, xxxxxx xxxxxx xxxxxxxxxxx xxx xxx xxxxxxx xxxxxx xxxxxxxxxx xxx xx xxxxxxxx xxx xxxxx xxx xx "xxxxx xx" xx xxxxxxxxx. Xxx xxxxxxxxxx xxxxxxxxxx xxx xxxxxxxxx xxxxxxx xxxxxxx xx xxx xxxx “xxxxxx xxxx.xxxxxxxx xxxx”. Xxxxx xxxxxxxxxx xxx xx xxxxxxxx xxxxxxxxxxxxx xxxx xxxxxxxx xxxxxxxxxxxxxx xx xxx xxxxxx.

### Xxxxxx xxxxxxxxxx – Xxxxxxxx xx Xxxxxxxx

Xxxxxx xxxxxx xxxxxxxxxxx xxx xxx xxxxxxx xxxxxx xxxxxxxxxx xx xxxxxxx xx xx xxxxxxxxxx xxxx xxx "xxxxx xx" xx xxxxxxxxx. Xxx xxxxxxx xxxxxxxxxx xxx xxxxxxxxx xxxxxxx xxxxxxx xx xxx xxxx “<effect name>.<property name>”. Xxx xxxxxxx xxxxxxxxxx xxx xx xxx xx x xxxxxxxx xxxxx xx xxx xx xxxxxxxx xxxxx xxx xxxxxxxxxxx xxxxxxxxx xxxxxx.

Xxxx xxxxxxxxx xxx xxxxxx xxxxxxxxxxx xxxxx, xxx xxxx xxx xxxxxxxxxxx xx xxxxxx xxxxxx xx xxxxxxxxxx xx xx xxxxx xx Y.Y xx xxxxxx xx xxxxxxx xxx xxxxxxx xx xxxxxxxxxxx xx xxxxxxxxx xx.

Xxxxxxxxx xx xxxxxx xxxx xxxxxxxxxx xxxxx xx:

```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);              
```

Xxxxxxxxx xx xxxxxx xxxx xxxxxxx xxxxxxxxxx:

```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect, new[]{SaturationEffect.Saturation});
_catEffect = effectFactory.CreateBrush();
_catEffect.SetSourceParameter("mySource", surfaceBrush);
_catEffect.Properties.InsertScalar("saturationEffect.Saturation", 0f);
```

Xxx xxxxxxxxxx xxxxxxxx xx xxx xxxxxx xxxxx xxx xxxx xx xxxxxx xxx xx x xxxxxx xxxxx xx xxxxxxxx xxxxx xxxxxx Xxxxxxxxxx xx XxxxxxXxxXxxxx xxxxxxxxxx.

Xxx xxx xxxxxx x XxxxxxXxxXxxxx xxxx xxxx xx xxxx xx xxxxxxx xxx Xxxxxxxxxx xxxxxxxx xx xx xxxxxx xxxx xxxx:

```cs
ScalarKeyFrameAnimation effectAnimation = _compositor.CreateScalarKeyFrameAnimation();
            effectAnimation.InsertKeyFrame(0f, 0f);
            effectAnimation.InsertKeyFrame(0.50f, 1f);
            effectAnimation.InsertKeyFrame(1.0f, 0f);
            effectAnimation.Duration = TimeSpan.FromMilliseconds(2500);
            effectAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
```

Xxxxx xxx xxxxxxxxx xx xxx Xxxxxxxxxx xxxxxxxx xx xxx xxxxxx xxxx xxxx:

```cs
catEffect.Properties.StartAnimation("saturationEffect.Saturation", effectAnimation);
```

Xxx xxx [Xxxxxxxxxxxx - Xxxxxxxxx xxxxxx](https://github.com/Microsoft/composition/tree/master/SDK10586_NOV_UPDATE_RTM/BasicCompositonEffects/Desaturation%20-%20Animation) xxx xxxxxx xxxxxxxxxx xxxxxxxx xxxx xxx xxxxxx xxx xxx [XxxxxXxxx xxxxxx](https://github.com/Microsoft/composition/tree/master/SDK10586_NOV_UPDATE_RTM/BasicCompositonEffects/AlphaMask) xxx xxx xx xxxxxxx xxx xxxxxxxxxxx.

### Xxxxxxxx Xxxxxx Xxxxxxxxx xxxx Xxxxxxxxxxx Xxxxxxxxxx

Xx xxxxxxxxxx xxxx x xxxxxxxxx xxxxxx xx xxxxxxx xxxxxx xxxxxx xxxxxxxxxxx, xxx xxxxxxxxx xxx xxxx xx xxxxxxx xx x xxx-xxxxxx xxxxxxxx xxxxx. Xxxx xxxxxx xxx Xxxxxxx xx xxx xxx xxxx xxxxxx xxx xx xxxxxxxx xxxx xxxxxxxxx xxxxxx xxxxxxxxxx. Xxx xxx XxxxxXxxxxx xxx Xxxxx [xxxxxx](https://github.com/Microsoft/composition/tree/master/SDK10586_NOV_UPDATE_RTM/BasicCompositonEffects/ColorSource%20and%20Blend) xxx xxxx xxxxxxxxxxx.

## Xxxxxxx Xxxxxxx xxxx Xxxxxxxxxxx Xxxxxxx

Xxxx xxxxx xxxxx xxxxxxxx xxxxx xxx xxx xx xxxx xxx xx xxxx xx xxx xxxxx xxxxxxxxxxxx xx xxxxxxx.

-   [Xxxxxxxxxx Xxxxxx Xxxxxx](./composition-effects.md#installing-visual-studio)
-   [Xxxxxxxx x xxx xxxxxxx](./composition-effects.md#creating-a-new-project)
-   [Xxxxxxxxxx XxxYX](./composition-effects.md#installing-win2d)
-   [Xxxxxxx xxxx Xxxxxxxxxxx Xxxxxx](./composition-effects.md#setting-your-composition-basics)
-   [Xxxxxxxx x XxxxxxxxxxxXxxxxxx Xxxxx](./composition-effects.md#creating-a-compositionsurface-brush)
-   [Xxxxxxxx, Xxxxxxxxx xxx Xxxxxxxx Xxxxxxx](./composition-effects.md#creating,-compiling-and-applying-effects)

### Xxxxxxxxxx Xxxxxx Xxxxxx

-   Xx xxx xxx'x xxxx x xxxxxxxxx xxxxxxx xx Xxxxxx Xxxxxx xxxxxxxxx, xx xx xxx Xxxxxx Xxxxxx Xxxxxxxxx xxxx [xxxx](https://www.visualstudio.com/downloads/download-visual-studio-vs.aspx).

### Xxxxxxxx x xxx xxxxxxx

-   Xx xx Xxxx->Xxx->Xxxxxxx...
-   Xxxxxx 'Xxxxxx X#'
-   Xxxxxx x 'Xxxxx Xxx (Xxxxxxx Xxxxxxxxx)' (Xxxxxx Xxxxxx YYYY)
-   Xxxxx x xxxxxxx xxxx xx xxxx xxxxxxxx
-   Xxxxx 'XX'

### Xxxxxxxxxx XxxYX

XxxYX xx xxxxxxxx xx x Xxxxx.xxx xxxxxxx xxx xxxxx xx xx xxxxxxxxx xxxxxx xxx xxx xxx xxxxxxx.

Xxxxx xxx xxx xxxxxxx xxxxxxxx, xxx xxx Xxxxxxx YY xxx xxx xxx Xxxxxxx Y.Y. Xxx Xxxxxxxxxxx xxxxxxx xxx’xx xxx xxx Xxxxxxx YY xxxxxxx.

-   Xxxxxx xxx XxXxx Xxxxxxx Xxxxxxx xx xxxxx xx Xxxxx → XxXxx Xxxxxxx Xxxxxxx → Xxxxxx XxXxx Xxxxxxxx xxx Xxxxxxxx.
-   Xxxxxx xxx "XxxYX" xxx xxxxxx xxx xxxxxxxxxxx xxxxxxx xxx xxxx xxxxxx xxxxxxx xx Xxxxxxx. Xxxxxxx Xxxxxxx.XX. Xxxxxxxxxxx xxxxxxxx Xxxxxxx YY (xxx Y.Y), xxxxxx XxxYX.xxx.
-   Xxxxxx xxx xxxxxxx xxxxxxxxx
-   Xxxxx 'Xxxxx'

Xx xxx xxxx xxx xxxxx xx xxxx xxx xxxxxxxxxxx XXX’x xx xxxxx x xxxxxxxxxx xxxxxx xx xxxx xxx xxxxx xxxxx xxxx xxxxxx xxx xxxxxxxxxx. Xx xxxx xxxxx xxx xxxxxx xx xxxxxxx xxx xxxx xxxxxxx xx xx xxxxx.

![Xxxxxx xxxxx](images/composition-cat-source.png)
### Xxxxxxx xxxx Xxxxxxxxxxx Xxxxxx

Xxx xxx [Xxxxxxxxxxx Xxxxxx Xxxx Xxxxxx](https://github.com/Microsoft/composition/tree/master/SDK10586_NOV_UPDATE_RTM/CompositionVisual) xx xxx XxxXxx xxx xx xxxxxxx xx xxx xx xxx xx Xxxxxxx.XX.Xxxxxxxxxxx Xxxxxxxxxx, xxxx XxxxxxxxxXxxxxx, xxx xxxxxxxxx xxxx xxx Xxxx Xxxxxx.

```cs
_compositor = new Compositor();
_root = _compositor.CreateContainerVisual();
_target = _compositor.CreateTargetForCurrentView();
_target.Root = _root;
_imageFactory = new CompositionImageFactory(_compositor)
Desaturate();
```

### Xxxxxxxx x XxxxxxxxxxxXxxxxxx Xxxxx

```cs
CompositionSurfaceBrush surfaceBrush = _compositor.CreateSurfaceBrush();
LoadImage(surfaceBrush); 
```

### Xxxxxxxx, Xxxxxxxxx xxx Xxxxxxxx Xxxxxxx

Y.) Xxxxxx xxx xxxxxxxx xxxxxx
```cs
var graphicsEffect = new SaturationEffect
{
  Saturation = 0.0f,
  Source = new CompositionEffectSourceParameter("mySource")
};
```

Y.) Xxxxxxx xxx xxxxxx xxx xxxxxx xxxxxx xxxxx
```cs
var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);

var catEffect = effectFactory.CreateBrush();
catEffect.SetSourceParameter("mySource", surfaceBrush);
```

Y.) Xxxxxx x XxxxxxXXxxxx xx xxx xxxxxxxxxxx xxxx xxx xxxxx xxx xxxxxx
```cs
var catVisual = _compositor.CreateSpriteVisual();
  catVisual.Brush = catEffect;
  catVisual.Size = new Vector2(219, 300);
  _root.Children.InsertAtBottom(catVisual);
}
```

Y.) Xxxxxx xxxx xxxxx xxxxxx xx xxxx.
```cs
CompositionImage imageSource = _imageFactory.CreateImageFromUri(new Uri("ms-appx:///Assets/cat.png"));
CompositionImageLoadResult result = await imageSource.CompleteLoadAsync();
if (result.Status == CompositionImageLoadStatus.Success)
```

Y.) Xxxx xxx xxxxx xxx xxxxxxx xx xxx XxxxxxXxxxxx
```cs
brush.Surface = imageSource.Surface;
```

Y.) Xxx xxxx xxx – xxxx xxxxxxx xxxxxx xx x xxxxxxxxxxx xxx:

![Xxxxxxxxxxx xxxxx](images/composition-cat-desaturated.png)
## Xxxx Xxxxxxxxxxx

-   [Xxxxxxxxx – Xxxxxxxxxxx XxxXxx](https://github.com/Microsoft/composition)
-   [**Xxxxxxx.XX.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706878)
-   [Xxxxxxx Xxxxxxxxxxx xxxx xx Xxxxxxx](https://twitter.com/wincomposition)
-   [Xxxxxxxxxxx Xxxxxxxx](https://blogs.windows.com/buildingapps/2015/12/08/awaken-your-creativity-with-the-new-windows-ui-composition/)
-   [Xxxxxx Xxxx Xxxxxx](composition-visual-tree.md)
-   [Xxxxxxxxxxx Xxxxxxx](composition-brushes.md)
-   [Xxxxxxxxx Xxxxxxxx](composition-animation.md)
-   [Xxxxxxxxxxx xxxxxx XxxxxxX xxx XxxxxxYX xxxxxxxxxxxxxx xxxx XxxxxXxxx xxx XxxXxxx](composition-native-interop.md)

 

 




<!--HONumber=Mar16_HO1-->
