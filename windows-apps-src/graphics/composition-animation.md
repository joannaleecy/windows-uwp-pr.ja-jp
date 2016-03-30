---
xx.xxxxxxx: YYYxxxYY-YxYY-YxYx-xxxY-xYYYYYxYYYYY
xxxxx: Xxxxxxxxxxx xxxxxxxxxx
xxxxxxxxxxx: Xxxx xxxxxxxxxxx xxxxxx xxx xxxxxx xxxxxxxxxx xxx xx xxxxxxxx xxxxx xxx xxxxx xxx xxxxxxxxxx xxxxxxxxxx xxxxxxxx xxxxxxxxxx xx x XX xxxxxxx xx xxxxxx xxxx xxxx xx xxxxx xx x xxxxxxxxxxx.
---
# Xxxxxxxxxxx xxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxxx xxxxxxxxxxx xxxxxx xxx xxxxxx xxxxxxxxxx xxx xx xxxxxxxx xxxxx xxx xxxxx xxx xxxxxxxxxx xxxxxxxxxx xxxxxxxx xxxxxxxxxx xx x XX xxxxxxx xx xxxxxx xxxx xxxx xx xxxxx xx x xxxxxxxxxxx. Xxxxx xxx xxx xxxxx xx xxxxxxxxxx, xxxxxxxx xxxxxxxxxx, xxxxxxxxxxx xx xxx [**XxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706830) xxxxx, xxx xxxxxxxxxx xxxxxxxxxx xxxxxxxxxxx xx xxx [**XxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706817) xxxxx.

-   [Xxxxxxxxxx Xxxxxxxxxx](./composition-animation.md#animatable_properties)
-   [XxxXxxxx Xxxxxxxxxx](./composition-animation.md#keyframe-animations)
    -   [Xxxxxxxx xxxx xxxxxxxxx xxx XxxXxxxxx](./composition-animation.md#creating-your-animation-and-Keyframes)
    -   [XxxXxxxx Xxxxxxxxxx](./composition-animation.md#keyframe-properties)
    -   [Xxxxxx Xxxxxxxxx](./composition-animation.md#easing-functions)
    -   [Xxxxxxxx xxx Xxxxxxxx XxxXxxxx Xxxxxxxxxx](./composition-animation.md#starting-and-stopping-keyframe-animations)
    -   [Xxxxxxxxx Xxxxxxxxxx Xxxxxx](./composition-animation.md#animation-completion-events)
-   [Xxxxxxxxxx Xxxxxxxxxx](./composition-animation.md#expression-animations)
    -   [Xxxxxxxx xxxx Xxxxxxxxxx](./composition-animation.md#creating-your-expression)
    -   [Xxxxxxxx Xxxx](./composition-animation.md#property-sets)
    -   [Xxxxxxxxxx XxxXxxxxx](./composition-animation.md#expression_keyframes)

## Xxxxxxxxxx Xxxxxxxxxx

Xxx xxxxxxxxx xxxxxxxxxx xxx xxxxxxxxxx xx xxxxxxxxxxx xxxx xxxx x XxxXxxxx xx Xxxxxxxxxx Xxxxxxxxx:

-   XxxxxxxxxxxXxxxxXxxxx.Xxxxx
-   XxxxxXxxx.XxxxxxXxxxx
-   XxxxxXxxx.XxxxXxxxx
-   XxxxxXxxx.XxxxxXxxxx
-   XxxxxXxxx.XxxXxxxx
-   Xxxxxx.XxxxxxXxxxx
-   Xxxxxx.XxxxxxXxxxx
-   Xxxxxx.Xxxxxx
-   Xxxxxx.Xxxxxxx
-   Xxxxxx.Xxxxxxxxxxx
-   Xxxxxx.XxxxxxxxXxxxx
-   Xxxxxx.XxxxxxxxXxxx
-   Xxxxxx.Xxxx
-   Xxxxxx.XxxxxxxxxXxxxxx
-   XxxxxxxxxxxXxxxxxxxXxx

## XxxXxxxx Xxxxxxxxxx

XxxXxxxx Xxxxxxxxxx xxx xxxx-xxxxx xxxxxxxxxx xxxx xxx xxx xx xxxx xxx xxxxxx xx xxxxxxx xxx xxx xxxxxxxx xxxxx xxxxxx xxxxxx xxxx xxxx. Xxx xxxxxx xxxxxxxxx xxxxxxx, xxxxxxxx xxx xx xxxxxx xxxx xxx xxxxxxxx xxxxx xxxxxx xx xx x xxxxxxxx xxxx.

### Xxxxxxxx xxxx xxxxxxxxx xxx XxxXxxxxx

Xx xxxxxxxxx x XxxXxxxx Xxxxxxxxx, xxx xxx xx xxx xxxxxxxxxxx xxxxxxx xx xxx Xxxxxxxxxx xxxxx xxxx xxxxxxxxxx xx xxx xxxxxxxxx xxxx xx xxx xxxxxxxx xxx xxxx xx xxxxxxx.

-   [**XxxxxxXxxxxXxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589424)
-   [**XxxxxxXxxxxxxxxxXxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt517858)
-   [**XxxxxxXxxxxxXxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706803)
-   [**XxxxxxXxxxxxYXxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706806)
-   [**XxxxxxXxxxxxYXxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706807)
-   [**XxxxxxXxxxxxYXxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706808)

Xxx xxxxxxx, xxx xxxxxxxxx xxxxxxx xxxxxxx x XxxxxxY xxxxxxxx xxxxxxxxx:

```cs
var animation = _compositor.CreateVector3KeyFrameAnimation();
```

Xxxx XxxXxxxx xx xxxxxxxxxxx xx xxxxxxx xxx XxxxxxXxxXxxxx xxxxxx xx x XxxXxxxxXxxxxxxxx xxx xxxxxxxxxx xxx xxxxxxxxxx xxx xxxxxxxxxx x xxxxx xxxxxxxxx:

-   Xxxx: xxxxxxxxxx xxxxxxxx xxxxx xx xxx XxxXxxxx xxxxxxx Y.Y – Y.Y
-   Xxxxx: xxxxxxxx xxxxx xx xxx xxxxxxxxx xxxxx xx xxx xxxx xxxxx
-   (Xxxxxxxx) Xxxxxx xxxxxxxx: xxxxxxxx xx xxxxxxxx xxxxxxxxxxxxx xxxxxxx xxxxxxxx xxx xxxxxxx XxxXxxxx (xxxxxxxxx xxxxx xx)

Xxx xxxxxxx, xxx xxxxxxxxx xxxxxxx xxxxxxx x xxxxxxxx xx x XxxxxxYXxxXxxxxXxxxxxxxx xxxx xxxx xxxxxxxxx xxxx xxx xxxxxxx xxx xxxxxxxxx:

```cs
animation.InsertKeyFrame(0.5f, new Vector3(50.0f, 80.0f, 0.0f));
```

### XxxXxxxx Xxxxxxxxxx

Xxxx xxx'xx xxxxxxx xxxx XxxXxxxx Xxxxxxxxx xxx xxx xxxxxxxxxx XxxXxxxxx, xxx xxx xxxx xx xxxxxx xxxxxxxx xxxxxxxxxx xx xxxx xxxxxxxxx:

-   XxxxxXxxx – xxxx xxxxxx xx xxxxxxxxx xxxxxx xxxxx XxxxxXxxxxxxxx() xx xxxxxx
-   Xxxxxxxx – xxxxxxxx xx xxx xxxxxxxxx
-   XxxxxxxxxXxxxxxxx – xxxxx xx xxxxxxxx xxxxxx xxxxxxxx xxx xx xxxxxxxxx
-   XxxxxxxxxXxxxx – xxxxxx xx xxxxxx xxxxx x XxxXxxxx Xxxxxxxxx xxxx xxxxxx
-   XxxXxxxx Xxxxx – xxxxxx xx XxxXxxxxx xx x xxxxxxxxxx XxxXxxxxXxxxxxxxx
-   XxxxXxxxxxxx – xxxxxxxxx xxx xxxxxxxx xx xx xxxxxxxxx xxxxxxxx xxxxx xxxx XxxxXxxxxxxxx xx xxxxxx.

Xxx xxxxxxx, xxx xxxxxxxxx xxxxxxx xxxx xxx xxxxxxxx xx xxx xxxxxxxxx xx xxxx xxxxxxx:

```cs
animation.Duration = TimeSpan.FromSeconds(5);
```

### Xxxxxx Xxxxxxxxx

X xxx xxxxx xxxxxx xxxxxxxx, x XxxxxxxxxxxXxxxxxXxxxxxxx, xxxxxxxxx xxx xxxxxxxxxxxx xxxxxx xxxxxxxx xxxx xxx xxxxxxxx xxx xxxxx xxxxx xx xxx xxxxxxx xxx xxxxx xxxxx. Xx xxx xx xxx xxxxxxx xx xxxxxx xxxxxxxx xxx xxx XxxXxxxx, x xxxxxxx xxxxx xxxx xx xxxx.

Xxxxx xxx xxx xxxxx xx xxxxxx xxxxxxxxx xxxxxxxxx:

-   Xxxxxx ([**XxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706839))
-   Xxxxx Xxxxxx ([**XxxxxXxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706812))

Xx xxxxxx xx xxxxxx xxxxxxxx, xxx xxxxxx xxx [**XxxxxxXxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706801) xx [**XxxxxxXxxxxXxxxxxXxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706791) xxxxxx xx xxx [**Xxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706761) xxxxx:

```cs
var linear = _compositor.CreateLinearEasingFunction();
var easeIn = _compositor.CreateCubicBezierEasingFunction(new Vector2(0.5f, 0.0f), new Vector2(1.0f, 1.0f));
```

Xxxx: X xxxxxx xxxx xxx xxxxxxxxxx xxx xxxxxx xxx xxxx Xxxxx Xxxxxx xxx xx xxxxx xxxx.

Xx xxx xxxx xxxxxx xxxxxxxx xxxx xxxx XxxXxxxx, xxxxxx xxx xx xxx xxxxx xxxxxxxxx xx xxx XxxXxxxx xxxx xxxxxxxxx xx xxxx xxx Xxxxxxxxx:

```cs
animation.InsertKeyFrame(0.5f, new Vector3(50.0f, 80.0f, 0.0f), easeIn);
```

### Xxxxxxxx xxx Xxxxxxxx XxxXxxxx Xxxxxxxxxx

Xxxxx xxx xxxx xxxxxxx xxxx xxxxxxxxx, XxxXxxxxx xxx xxxxxxxxxx, xxx xxx xxxxx xx xxxxxxx xxx xxxxxxxxx xx xxx xxxxxxxx xxx xxxx xx xxxxxxx. Xxx xxxxxxx xxxx xxxxxxxxx xx xxx xxxxxxxx xxx xxxx xx xxxxxxx xx xxxxxxx [**XxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt590840) xx xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706858) xxxxxx xxx xxxxxxxx xxxxxxx xx.

Xxx xxxxxxx xxxxxx xxx xx xxxxxxx xx xx xxxxxxx:

```cs
targetVisual.StartAnimation(“Offset”, animation);
```

Xxxxx xxxxxxxx xxxx xxxxxxxxx, xxx xxxx xxxx xxx xxxxxxx xx xxxx xxx xxxxxxxxxx xx xx xxxx. Xxxx xx xxxx xx xxxxx xxx [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt590841) xxxxxx xxx xxxxxxxxxx xxx xxxxxxxx xxx xxxx xx xxxx xxxxxxxxx.

Xxx xxxxxxx:

```cs
targetVisual.StopAnimation(“Offset”);
```

### Xxxxxxxxx Xxxxxxxxxx Xxxxxx

XxxXxxxx xxxxxxxxxx xxxx x xxxxxxx xxx, xxxxxx Xxxxxxxxxx Xxxxxxxxxx, xxxxx xxx xxxxxxxxxxx. Xxxxxxxxxx xxx xxxxxxxxx xxxx xxxxxx xx x xxxxxx XxxXxxxx xxxxxxxxx xxxxxxxxx xx xxxxx xxxxxxx. Xxxxxxx xxx xx xxxxxxx xx xxxxxxxxx, xxxxxxxxx xx xxx xxxxx xxxxxx xxxx, xxx xxx xxxx xx xxxxxxxxx xxx xxx xxxxx xx xxxxxxxxxx. Xxxxxx xxxxxxx xxx xxxxxxx xxxxx Xxxxxx xxxxxxx xxx xxxxxxxxx, xxx xxx xx xxxxx xxxxxxxxx xxxxxxx xxx xxxxxxxxx xxxxx.

X xxxxx xxxxxxxxxx xxxxx xxxxx xxxx xxx xxxxxxxxxx xxxxxx xxx xxxxx xxxx xxxxxxxxx. Xxx xxxx xx xxxxx xxx x xxxxx'x xxxxxxxxxx xxxxx xx xxxx xxxxxxx xx xxx xxxxxxx xx xxxx xxxxxxx xxxxxxxxx xx xxx xxxxx. Xxxxxxxxxxx xxx xxxxxx xx xxxxxx xxxx xxx xxxx xx xxxx xxxx xxxxxx xx xxxxxx xxxxxxxxxx xxxxxxxx xx xxxxx xx xxxxxxxx xxxxx xxxx.

### Xxxxxx xxxxxxx

Xx xxxxxxxxx x xxxxxxxx xxxxx xx x xxxxxx xxxxxxxxx, xxx xxxxx xxxx xx xxxxxx x Xxxxxx xxxxx xx xxxxxxx [**XxxxxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589425).

```cs
myScopedBatch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
```

Xxxxx xxxxxxxx x Xxxxxx xxxxx, xxx xxxxxxx xxxxxxxxxx xxxxxxxxx xxxxx xxx xxxxx xx xxxxxxxxxx xxxxxxxxx xx xxxxx xxxxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt590848) xx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/Mt590844).

Xxxxxxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt590848) xxxxx xxxxxxxxxxx xxxxxxxxx xxx xxxxxx xxxxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt590847) xx xxxxxx. Xxxx xxxxxx xxx xx xxxxxxxxxx xxxxxxx xxxxxxx xxxx x xxxxx xxxxx.

```cs
myScopedBatch.Suspend();
```

Xx xxxxx xx xxxxxxxx xxxx xxxxx xxx xxxx xxxx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/Mt590844). Xxxxxxx xx Xxx xxxx, xxx xxxxx xxxx xxxxxx xxxx xxxxxxx-xxxxxxxxxx xxxxxxx.

```cs
myScopedBatch.End();
```

Xx xxx xxxx xx xxxx xxxx x xxxxxx xxxxxxxxx xxxx, xxx xxxx xx xxxxxx x Xxxxxx xxxxx, xxxxx xxx xxxxxxxxx xxx xxx xxx xxxxx.

Xxx xxxxxxx:

```cs
myScopedBatch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
Visual.StartAnimation(“Opacity”, myAnimation);
myScopedBatch.End();
```

### Xxxxxx xxxxxxx

X xxxxxx xxxxx xx x xxxxx xxxx xx xxxxxxxxxx xxxxxxx xxxxxx xxx xxxxxx xxxxx. Xxx xxxxxxx Xxxxxx xxxxx xxx xx xxxxxxxxx xx xxxxxxx [**XxxXxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt589430) xx xxx xxxx xxxxxx xxx xxxxxx xxxxx. Xxx xxxxxx xxxxx xx xxxxxxx xx xxx xxxx xxxxxxx xxxxxxx xxxx xxx xxxxxxxxxx. Xxxxxxx xxx xxxxxx xxxxx xxx xxxxxx xx xxxxx xx xxxxxxx xxx xxxxxxx xxx xxxx xxxx xx xxx xxxxxx. Xxxxxx xx xxx xxxxxxx xxxx xxxxxxx xxxxxx. Xxx Xxxxxx xxxxx xxxx xxxxxxxxx xxx xxxxxxx xxxxxx xxx xxxxxx xxxxx, xxxxx xxxxxx xxx xxxxx XxxXxxxxxXxxxx xxx xxxxxx. Xxxxx xx xxxx xxx Xxxxxx xxxxx xxx xxxxxx xxxxx xxx xxx xx xxx xxxx xx xxxxxxxxxx xxxx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/Mt590844) xx xxx xxxxxx xxxxx.

```cs
myCommitBatch = _compositor.GetCommitBatch(CompositionBatchTypes.Animation);
```

### Xxxxx xxxxxx

Xx xxxxxxxxx xx x xxxxx xx xxxx xx xxxxxxxxxxx xxxxxxxxxx xxx xxx xxx xxx **XxXxxxxx** xxxxxxxx. Xx xxx **XxXxxxx** xxxxxxxx xxxxxx xxxx, xxx xxxxxx xxx xx xxxxxxxxx xx xxxx xxxxxxxx xxxxx. Xxxxxx xxxxxxx xxx “xxxxx” xxxx xxxx xxxx xxxx xxxxxxxxxx xxxxx xx xxxxxxx xxx [**Xxx**](https://msdn.microsoft.com/library/windows/apps/Mt590844) xxxxxx. Xxxxxx xxxxxxx xxx xxxxx xxxx xxx xxxxxxx xxxxxx xxxxx xxx xxxxx.

## Xxxxxxxxxx Xxxxxxxxxx

Xxxxxxxxxx Xxxxxxxxxx xxx xxxxxxxxxx xxxx xxx x xxxxxxxxxxxx xxxxxxxxxx xx xxxxxxx xxx xxx xxxxxxxx xxxxx xxxxxx xx xxxxxxxxxx xxx xxxx xxxxx. Xxx xxxxxxxxxx xxxxxxxx xxxxxx xxx xxxxxxxxx xxxxxxxxxx xxxx xxxxx xxxxxxxxxxx xxxxxxx. Xxxxxx XxxXxxxx Xxxxxxxxxx, Xxxxxxxxxxx xxx xxx xxxx-xxxxx xxx xxx xxxxxxxxx xxxx xxxxx (xx xxxxxxxxx). Xxxxxxxxxxx xxx xx xxxxxx xx xxxxxxxx xxxx xxxxxxx xxxx xxxxxxxxxxx xxxx xxx xx xxxxxxxxx xx xxx Xxxxxxxxxxx xxxxxx, xxx xxxxxxx xxxxxx xxxxxxx xxx xxxxxxxx.

### Xxxxxxxx xxxx Xxxxxxxxxx

Xx xxxxxx xxxx xxxxxxxxxx, xxx xxxx [**XxxxxxXxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt187002) xx xxxx Xxxxxxxxxx xxxxxx xxx xxxxxxxxxx xxx xxxxxxxxxx xxx xxxx xx xxx:

```cs
var expression = _compositor.CreateExpressionAnimation(“INSERT_EXPRESSION_STRING”)
```

### Xxxxxxxxx, Xxxxxxxxxx xxx Xxxxxxxxxxxxx

Xxx Xxxxxxxxxx xxxxxxxx xxxxxxxx xxx xxxxxxxxx xxxxxxxxx xxx xxxxxxx xx xxxxxxxx xxxxxxxxxx xxx xxxxxxxxxxxxx xx xxxxxxx xx xxx X# Xxxxxxxx Xxxxxxxxxxxxx:

-   Xxxxx (-)
-   Xxxxxxxxxxxxxx (\* /)
-   Xxxxxxxx (- +)

Xxx Xxxxxxxxxx xxxxxxxx xxxx xxxxxxxx xxx xxxxxxx xx xxx-xxxxxxxxx xxxx xxxxxxxxxx. Xxxxx xxxxxx-xxxxxx (x.x) xxxxxxxxx xxx xxxx xxxxxxxxx xx “xxxxxxxxx” xxxxx (Xxxxxx xxx Xxxxxxxx). Xxx xxxxxxx:

```cs
Offset.x + 5.0
```

### Xxxxxxxx Xxxxxxxxxx

Xxx xx xxx xxxxxxxx xxxxxxxxxx xx xxx Xxxxxxxxxx xxxxxxxx xx xxxxx xxxx xxx xxxxxxxxxx xx xxxxxxxxx xx xxx xxxxxxxxxx. Xxx xxxxxxxxxx xxxxxx xxx xxxxxxx xxxxxxxxxx xxxxx xxx xxxxxxxx xxxx xxxxxx x xxxxxxxx xxxxx xx xxx xxxxxxxxxx xx xxxxxxx xxxxxx'x xxxxxxxx xxxxx xxxx xxxxxxxxxx. Xxx xxxxxxx:

```cs
ChildVisual.Offset.X / ParentVisual.Offset.Y
```

Xx xxxx xxxxxxx XxxxxXxxxxx xxx XxxxxxXxxxxx xxx xxxxxxxxxx xxxx xxxxxxxxx xxx xxxxxx xxxxxxxx xx xxx xxxxxxx. Xxx xxxxxx xxxxxxxxxx xxxxx xxx **Xxx\*Xxxxxxxxx** xxxxxxx xx xxx [**XxxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706708) xxxxx:

-   Xx xxxxxx x xxxxxx xxxxxxxxx xxx xxx [**XxxXxxxxxYXxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionanimation.setvector2parameter.aspx), [**XxxXxxxxxYXxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionanimation.setvector3parameter.aspx), xx [**XxxXxxxxxYXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setvector4parameter).
-   Xx xxxxxx x xxxxxx xxxxxxxxx xxx xxx [**XxxXxxxxxYxYXxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.composition.compositionanimation.setmatrix3x2parameter.aspx), xx [**XxxXxxxxxYxYXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setmatrix4x4parameter).
-   xx xxxxxx x xxxxxx xxxxxxxxx xxx xxx [**XxxXxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setscalarparameter).
-   Xx xxxxxx x xxxxx xxxxxxxxx xxx xxx [**XxxXxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setcolorparameter).
-   Xx xxxxxx x xxxxxxxxxx xxxxxxxxx xxx xxx [**XxxXxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setquaternionparameter).
-   Xx xxxxxx x xxxxxxxxx xxxxxxxxx xxx xxx [**XxxXxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.compositionanimation.setreferenceparameter).

Xx xxx Xxxxxxxxxx Xxxxxx xxxxx, xx xxxxx xxxx xx xxxxxx xxx xxxxxxxxxx xx xxxxxx xxx xxx Xxxxxxx:

```cs
Expression.SetReferenceParameter(“ChildVisual”, childVisual);
Expression.SetReferenceParameter(“ParentVisual”, parentVisual);
```

### Xxxxxxxxxx Xxxxxx Xxxxxxxxx

Xx xxxxxxxx xx xxxxxx xxxxxx xx xxxxxxxxx xxx xxxxxxxx xxxxxxxxxx, xxx xxxx xxxx xxxxxx xx xxx xxxx xxxxxx xxxxxxxx xxxxxxx xx xxx xxxxxxxxxx xxxxxxxx. Xxx xxx xxxx xxx xxxx xxxx xx xxxxxx xxxxxxxxx xx xxx xxxxxxx xxxxxxx xx xxx [**XxxxxxxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn706817) xxxxx, xxx xxxx xxx x xxx:

-   Xxx (Xxxxxx xxxxxY, Xxxxxx xxxxxY)
-   Xxxxx (XxxxxxY xxxxx, Xxxxxx xxxxxx)
-   Xxxxxxxxx(XxxxxxY xxxxx, Xxxxxx YxY xxxxxx)

Xxxx’x x xxxx xxxxxxx xxxxxxxxxx xxxxxx xxxxxxx xxxx xxxx xxx Xxxxx xxxxxx xxxxxxxx:

```cs
Clamp((scroller.Offset.y * -1.0) – container.Offset.y, 0, container.Size.y – header.Size.y)
```

### Xxxxxxxx xxx xxxxxxxx xxxx Xxxxxxxxxx Xxxxxxxxx

Xx xxxxx xxx xxxx xxxx Xxxxxxxxxx Xxxxxxxxxx, xxx xxx xxx xxxx xxxxxxxxx ([**XxxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt590840), [**XxxxXxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Mt590841)) xx xxx xx xxxx XxxXxxxx Xxxxxxxxxx. Xxxx: Xxxxxxxxxx Xxxxxxxxxx xxxx xxxxxxxx xx xxx xxxxx xxxx xxx xxxxxxx xxxxx **XxxxXxxxxxxxx** – xxxxxx XxxXxxxx Xxxxxxxxxx, xxxx xx xxx xxxx x xxxxxx xxxxxxxx.

### Xxxxxxxx Xxxx

Xx xxxxxxxx xx xxxxx xxxx xx xxxxxxxxx xxxxxxxxxx xx xxxxx Xxxxxxxxxxx xxxxxxx, xxx xxxx xxxx xxx xxxxxxx xx xxxxxx xxx xxxxx xxxxxxxx xxxxxx xx xxxx xxx xxxx xxx xx xxxx xxxxxx xxxxxxxx xxxxxxxxxx. Xxxxxxxx xxxx xxx xxxxxxxxxxx xx xxx [**XxxxxxxxxxxXxxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/Dn706772) xxxxx. Xxxxxxxx xxxx xxxxx xxx xx xxxxxx x xxxxxxxx xxxx x xxxxx xxx xxxxxxxxx xx xxxxx xx xx xxxxxxxxxx xx xxxx xxxx xx xx xx xxx xxxxxx xx x XxxXxxxx Xxxxxxxxx.

Xx xxxxxx x xxxxxxxx xxx, xxx xxx [**XxxxxxXxxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/Dn706802) xxxxxx xx xxx Xxxxxxxxxx xxxxx. Xxx xxxxxxx:

```cs
_sharedProperties = _compositor.CreatePropertySet();
```

Xxxx xxx’xx xxxxxxx xxxx xxxxxxxx xxx, xxx xxx xxx x xxxxxxxx xxx xxxxx xx xx xxxxx xxx xx xxx **Xxxxxx\*** xxxxxxx xx [**XxxxxxxxxxxXxxxxxxxXxx**](https://msdn.microsoft.com/library/windows/apps/Dn706772). Xxx xxxxxxx:

```cs
_sharedProperties.InsertVector3(“NewOffset”, offset);
```

Xxxxx xxx'xx xxxxxxx xxxx xxxxxxxxxx xxxxxxxxx, xxx xxx xxxxxxxxx xxxxxxxxxx xxxx xxx xxxxxxxx xxx xx xxx xxxxxxxxxx xxxxxx xxxx xxx xxx xx x xxxxxxxxx xxxxxxxxx. Xxx xxxxxxx:

```cs
var expression = _compositor.CreateExpressionAnimation(“sharedProperties.NewOffset”);
expression.SetReferenceParameter(“sharedProperties”, _sharedProperties);
```

### Xxxxxxxxxx XxxXxxxxx

Xxxxxxx xx xxxx xxxxxxxx, xx xxxxxxxxx xxx xxx xxxxxx XxxXxxxx Xxxxxxxxxx xxx xxxxx xxxxxxxxxx XxxXxxxxx. Xx xxxxxxxx xx xxxxxx xxx xxxxxxxxxxx XxxXxxxx xxxx x xxxxxxxxxx xxxx xxx xxxxx xxxxxxxxx, xxx xxx xxxx xxxx xx xxxxxx xxxxxxxxxx XxxXxxxxx.

Xxxxxxx xx xxxxxxxx xx xxxxxxxx xxxxx xxx x xxxxxxxxxx xxxx xx xxx XxxXxxxx, xx xxx xxxx xx xxx xxx xxxxxxxxxx xxxxxx xx xxxxxxxx xxx xxx xxxxx xxxxxx xx xxxxxxxxxx xx xxxx xxxxxxxxxx xxxxx xx xxx XxxXxxxx xxxxxxxx. Xxx xxx xxxx xx xxx xxx xxxxx xxxxxxxxxx XxxXxxxxx xxxx xxxxx XxxXxxxxx xx xxxx XxxXxxxx Xxxxxxxxx.

### Xxxxxxxxxxxx Xxxxxxxxxx XxxXxxxxx

Xxxxxxx xx xxxxxxxxxxx XxxXxxxxx, xxxxxxxxxx XxxXxxxxx xxx xxxxxxxxxxx xx xxxxxxxxxx Y xxxxxxxxxx:

-   Xxxx: xxxxxxxxxx xxxx xxxxx xx xxx XxxXxxxx xxxxxxx Y.Y – Y.Y
-   Xxxxx: Xxx xxxxxxxxxx xxxxxx xxxx xx xxxxxxxx xxx xxx xxxxx xxxxxx xx xxxxxxxxxx

Xxx xxxxxxx, xxx xxxxxxxxx xxxxxxx xxxx x xxxxxxxxxxx xx xxxx xxxxxxx xxx xxxxxxxxxx XxxXxxxxx:

```cs
var animation = _compositor.CreateScalarKeyFrameAnimation();
animation.InsertExpressionKeyFrame(0.25, “VisualBOffset.X / VisualAOffset.Y”);
animation.InsertKeyFrame(1.00f, 0.8f);
```

### Xxxxx xxxxxxx xxx xxxxxxxx xxxxxx

Xx xxx xxxxxxxxxx xxxxxxxx, xx xx xxxxxxxx xx xxxxxxxxx xxxx xxx xxxxxxx xxx xxx xxxxxxxx xxxxx xx xx xxxxxxxxx. Xxxxx xxxxxx xxx xxx-xxxxx xx xxx xxxxxxxxxx xxxxxxxx xxxx “xxxx”:

-   xxxx.XxxxxxxXxxxx
-   xxxx.XxxxxxxxXxxxx

Xx xxxxxxx xx xxxxx xxxxx xx xx Xxxxxxxxxx XxxXxxxx:

```cs
animation.InsertExpressionKeyFrame(0.0f, “this.CurrentValue + delta”);
```

### Xxxxxxxxxxx Xxxxxxxxxxx

Xx xxxxxxxx xx xxxxxxxxxx xxxxx xxxxxxxxxxxx xxxxxxxxxxx, xxx xxx xxxx xxxxxx x xxxxxxxxxxx xxxxxxxxxx xxxxx x xxxxxxx xxxxxxxx:

```cs
(condition ? first_expression : second_expression)
```

Xxxxxx xxx xxxxxxxxxxx xxxxxxxxxx, xxx xxxxxxxxx xxxxxxxxxxx xxxxxxxxx xxx xxxxxxxxx xx xxx xxxxxxxxx xxxxxxxxx:

-   Xxxxxx (==)
-   Xxx Xxxxxx (!=)
-   Xxxx xxxx (<)
-   Xxxx xxxx xx xxxxx xx (<=)
-   Xxxxx xxxx (>)
-   Xxxxx xxxx xx xxxxx xx (>=)

Xxxxxxx, xxx xxxxxxxxx xxxxxxxxxxxx xxx xxxxxxxxx xx xxxxxxxxx xx xxxxxxxxx xx xxx xxxxxxxxx xxxxxxxxx:

-   Xxx: ! / Xxx(xxxxY)
-   Xxx: && / Xxx(xxxxY, xxxxY)
-   Xx: || / Xx(xxxxY, xxxxY)

Xxx xxxxxxxxx xxxxxxx xxxxx xx xxxxxxx xx xxxxx xxxxxxxxxxxx xx xx xxxxxxxxxx:

```cs
var expression = _compositor.CreateExpressionAnimation(“target.Offset.x > 50 ? 0.0f +   (target.Offset.x / parent.Offset.x) : 1.0f”);
```

 

 




<!--HONumber=Mar16_HO1-->
