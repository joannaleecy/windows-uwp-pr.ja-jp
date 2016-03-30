---
Xxxxxxxxxxx: Xxxxx xx xxxxx xxxx xxx x xxxxxx Xxxxx xxxxx, xxxxxxxxxxxx XxxxxxxXxxxxxxx xxx XxxxxxxXxxxxxxx xxxxxxx, xxx xxxxx xxx Xxxxxxxx xxxxxxxx.
xxxxx: XxxXxxxx, xx xxxxxxx xxxxxx xxxxx
xx.xxxxxxx: YYYYYYXX-YYXY-YXYX-XYYY-YYYYXYYXYYXY
xxxxx: XxxXxxxx, xx xxxxxxx xxxxxx xxxxx
xxxxxxxx: xxxxxx.xxx
---

# XxxXxxxx, xx xxxxxxx xxxxxx xxxxx


\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


**Xxxxxxxxx XXXx**

-   [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227511)
-   [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208711)
-   [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208730)

Xxxxx xx xxxxx xxxx xxx x xxxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227511) xxxxx, xxxxxxxxxxxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208711) xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208730) xxxxxxx, xxx xxxxx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227514) xxxxxxxx. Xxx xxxxxxx xxxx xxxxx x xxxxxx xxxxx xxxxxxxxxxxxxx, xxx xx xxx'x xxxxxx x xxx xx xxxx xxxxxxxxxx xxx xxxxxx xxxxxxxx xxxx xxxxxxxxx xxx xxx xxx xxxxxxxxx x xxxxx xxx xxxxxxxxx xxxxxx xxxxxxxxx. Xx xxx xxxx xxxx xxxx xxxxx xxxxx xxxxxx xxxxxxxx xxx xxx xxxx xxxxx xxxxx xx xxxx xxxxxxxxxx xxxxxx xxxxxxxx, xxx [XXXX xxxxxx xxxxxx xxxxxxxx](custom-panels-overview.md).

X *xxxxx* xx xx xxxxxx xxxx xxxxxxxx x xxxxxx xxxxxxxx xxx xxxxx xxxxxxxx xx xxxxxxxx, xxxx xxx XXXX xxxxxx xxxxxx xxxx xxx xxxx xxx XX xx xxxxxxxx. Xxx xxx xxxxxx xxxxxx xxxxxx xxx XXXX xxxxxx xx xxxxxxxx x xxxxxx xxxxx xxxx xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227511) xxxxx. Xxx xxxxxxx xxxxxxxx xxx xxxx xxxxx xx xxxxxxxxxx xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208711) xxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208730) xxxxxxx, xxxxxxxxx xxxxx xxxx xxxxxxxx xxx xxxxxxxx xxx xxxxx xxxxxxxx. Xxxx xxxxxxx xxxxxxx xxxx **Xxxxx**. Xxxx xxx xxxxx xxxx **Xxxxx**, **XxxxxxxXxxxxxxx** xxx **XxxxxxxXxxxxxxx** xxxxxxx xxx'x xxxx x xxxxxxxx xxxxxxxx. Xxxx xxxx xx xxxxxxxxx xxx xxxxxxx xx xxxxx xxxxx xxxxxxxx xxxxxx xxxxx xx xxx XXXX xxxxxx xxxxxx xxx xxx xxxxxxxx xx xxx XX. Xx, xx'x xxxxxx xxxxxxxxx xxxx xxxx xxxx xxxxxxxx xxx xxx xxxxx xxxxxxxx xxx xxxxxxx xxx xxxxxxxx xxx xxxxxx xxxxxx xxxxxxx.

## Xxxx xxxxxx xxxxxxxx


Xxxx xxx xxxxxx x xxxxxx xxxxx, xxx'xx xxxxxxxx x xxxxxx xxxxxxxx.

X xxxxxx xxxxxxxx xx xxxxxxxxx xxxxxxx:

-   Xxxx xxx xxxxx xxxx xx xxxx xx xxx xxxxx xxxxxxxx
-   Xxxx xxx xxxxx xxx xxxxxxxxxxx xx xxx xxx xxxxx
-   Xxx xxx xxxxx xx xxx xxxxx xxxxxxxxxx xxx xxx xxxxxxxxxxxx, xxxxxxxxx, xxxxxxxxx, xxx xxxxxxx xxxx xxxxxxxxxx xxxxxx xx x xxxxxxxx XX xxxxxx xx xxxxxxxx

Xxxx xxxx xx xxxx, xxx `BoxPanel` xxxxx xxxx xx xxx x xxxxxxxxxx xxxxxxxx. Xx xxx xxxxxxxx xx xxxxxxx xxx xxxx xxxxxxxx xx xxxx xxxxxxx, xx xxx'x xxxxxxx xxx xxxxxxxx xx xxxxxx xxx, xxx xxxxxxx xxxxxxxxxxx xx xxx xxxxx xxxxxx xxx xxx xxxxxx xxxxxxxx. Xx xxx xxxx xx xxxx xxxx xxxxx xxx xxxxxxxx xxxxx, xxxx xxxxx xx ["Xxx xxxxxxxx xxx `BoxPanel`"](#scenario), xxx xxxx xxxx xxxx xx xxx xxxx.
## Xxxxx xx xxxxxxxx xxxx **Xxxxx**


Xxxxx xx xxxxxxxx x xxxxxx xxxxx xxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227511). Xxxxxxxx xxx xxxxxxx xxx xx xx xxxx xx xx xxxxxx x xxxxxxxx xxxx xxxx xxx xxxx xxxxx, xxxxx xxx **Xxx** | **Xxx Xxxx** | **Xxxxx** xxxxxxx xxxx xxxxxxx xxx x xxxxxxx xxxx xxx **Xxxxxxxx Xxxxxxxx** xx Xxxxxxxxx Xxxxxx Xxxxxx. Xxxx xxx xxxxx (xxx xxxx) `BoxPanel`.

Xxx xxxxxxxx xxxx xxx x xxxxx xxxxx'x xxxxx xxxx xxxx **xxxxx** xxxxxxxxxx xxxxxxx xx'x xxx xxxxxxxxxxxx xxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxxxx, xxx **xxxxx** xxxxxxxxxx. Xxx xxxxxxxx xxxx xxxx xxxxxx xxxx x xxx **xxxxx** xxxxxxxxxx xxxx xxx xxxxxxxx xxx'x xxxx, xxx xxx xx xxxxxxx. Xxxx'x x xxxxxxxxx xxxx xx **xxxxx** xxxxxxxxxx xxxx xxx xxxxxxx xxxxx xxx'xx xxxx xxx xxxxxxx xxxxxx xxxxx xxxx:

```CSharp
using System;
using System.Collections.Generic; //if you need to cast IEnumerable for iteration, or define your own collection properties
using Windows.Foundation; //Point Size and Rect
using Windows.UI.Xaml; //DependencyObject UIElement and FrameworkElement
using Windows.UI.Xaml.Controls; //Panel
using Windows.UI.Xaml.Media; //if you need Brushes or other utilities
```

Xxx xxxx xxx xxx xxxxxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227511), xxxx xx xxx xxxx xxxxx xx `BoxPanel`. Xxxx, xxxx `BoxPanel` xxxxxx:

```CSharp
public class BoxPanel : Panel
{
}
```

Xx xxx xxxxx xxxxx, xxxxxx xxxx **xxx** xxx **xxxxxx** xxxxxx xxxx xxxx xx xxxxxx xx xxxxxxx xx xxxx xxxxx xxxxxxxxx, xxx xxxxx xxx'x xxxx xx xx xxxxxxx xx xxxxxx XXX. Xx xxx xxxxxxx, xxxxx xxx xxxxx: `maxrc`, `rowcount`, `colcount`, `cellwidth`, `cellheight`, `maxcellheight`, `aspectratio`.

Xxxxx xxx'xx xxxx xxxx, xxx xxxxxxxx xxxx xxxx xxxxx xxxx xxxx (xxxxxxxx xxxxxxxx xx **xxxxx**, xxx xxxx xxx xxxx xxx xx xxxx xxxx):

```CSharp
using System;
using System.Collections.Generic;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

public class BoxPanel : Panel 
{
    int maxrc, rowcount, colcount;
    double cellwidth, cellheight, maxcellheight, aspectratio;
}
```

Xxxx xxxx xx xxx, xx'xx xx xxxxxxx xxx xxx xxxxxx xxxxxxxxxx xx x xxxx, xx xxxx x xxxxxx xxxxxxxx xx xxxxxxxxx xxxxxxxxxx xxxx xx x xxxxxxxxxx xxxxxxxx. Xxx xxx xxx xxxxx xx xxx xxxxxxxx xxxxx xx xxx xxxxx, xxx xx xxx'x xx xxxxxxx xxx **xxxxx** xxxxxxxxxx xx xxx xxxxxxxxxx xx xxx xxxxx xxxxx xxxxx xx xxx xxxxxxxx xxxxx xx xxxx xxx xxxxx xxxx.

## **XxxxxxxXxxxxxxx**


```CSharp
protected override Size MeasureOverride(Size availableSize)
{
    Size returnSize;
    // Determine the square that can contain this number of items.
    maxrc = (int)Math.Ceiling(Math.Sqrt(Children.Count));
    // Get an aspect ratio from availableSize, decides whether to trim row or column.
    aspectratio = availableSize.Width / availableSize.Height;

    // Now trim this square down to a rect, many times an entire row or column can be omitted.
    if (aspectratio > 1)
    {
        rowcount = maxrc;
        colcount = (maxrc > 2 &amp;&amp; Children.Count < maxrc * (maxrc - 1)) ? maxrc - 1 : maxrc;
    } 
    else 
    {
        rowcount = (maxrc > 2 &amp;&amp; Children.Count < maxrc * (maxrc - 1)) ? maxrc - 1 : maxrc;
        colcount = maxrc;
    }

    // Now that we have a column count, divide available horizontal, that&#39;s our cell width.
    cellwidth = (int)Math.Floor(availableSize.Width / colcount);
    // Next get a cell height, same logic of dividing available vertical by rowcount.
    cellheight = Double.IsInfinity(availableSize.Height) ? Double.PositiveInfinity : availableSize.Height / rowcount;
           
    foreach (UIElement child in Children)
    {
        child.Measure(new Size(cellwidth, cellheight));
        maxcellheight = (child.DesiredSize.Height > maxcellheight) ? child.DesiredSize.Height : maxcellheight;
    }
    return LimitUnboundedSize(availableSize);
}
```

Xxx xxxxxxxxx xxxxxxx xx x [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208730) xxxxxxxxxxxxxx xx xxx xxxx xxxxxxx xxxx xxxxxxx xx [**Xxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227514). Xxxxxx xxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208952) xxxxxx xx xxxx xx xxxxx xxxxxxxx. **Xxxxxxx** xxx x xxxxxxxxx xx xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br225995). Xxxx xxx'xx xxxxxxx xxxx xx xxx xxxx xxxx xxxx xxxxx xx xxxxxxxxxx xx xxxx xxxxxxxxx xxx xxxx xxxxxxxxxx xxxxx xxxxxxx. Xx, xxxxxx xxx xxx xx xxx xxxx xxx xxxxx xxxxxxx **Xxxxxxx**, xxx xxxx xx xxxx xxx xxxx xxxxx xxxx xxxx xxx xxxxxx. Xxxx xxx **XxxxxxxXxxxxxxx** xxxxxx xxxxxx, xxx xxxx xxx *xxxxxxxxxXxxx* xxxxx. Xxxx xx xxx xxxx xxxx xxx xxxxx'x xxxxxx xxxx xxxx xx xxxxxx **Xxxxxxx**, xxxxx xxx xxx xxxxxxx xxx xxxx **XxxxxxxXxxxxxxx** xxxxx xxxxxx xx xxx xxxxx xxxxx. Xx x xxxxxxx xxxxx xx xx xxxxxx x xxxxxx xxxxxxx xxxx xxxxx xxxxxxx xxxxxxx xxx xxxxx xx xxx xxxxx'x xxxxxxx *xxxxxxxxxXxxx*. Xxx xxxx xxxx xxxx xxxxxxxx xx xxxx xx **Xxxxxxx** xx xxxx xxxxx xxxxxxx.

Xxx `BoxPanel` xxxxxxx xxxx xx xxxxxx xxxxxx: xx xxxxxxx xxx xxxxx xxxx x xxxxxx xx xxxxx xxxx'x xxxxxxx xxxxxxxxxx xx xxx xxxxxx xx xxxxx. Xxxxx xxx xxxxx xxxxx xx xxx xxx xxxxxx xxxxx xxx xxx xxxxxxxxx xxxx. Xxxxxxxxx xxx xxx xx xxxxxx xxxx x xxxxxx xxx'x xxxxxx, xx xx'x xxxxxxx xxx xxx xxxxx xxxxxxx x xxxxxxxxx xxxxxx xxxx xxxxxx xx xxxxx xx xxx xxx : xxxxxx xxxxx. Xxx xxxx xxxx xxxxx xxx xxxx xxxxx xxx xxxxxxx xx, xxxx xxxxx xx ["Xxx xxxxxxxx xxx `BoxPanel`"](#scenario).

Xx xxxx xxxx xxx xxxxxxx xxxx xx? Xx xxxx x xxxxx xxx xxx xxxx-xxxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br208921) xxxxxxxx xx xxxx xxxxxxx xxxxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208952) xxx xxxxxx. Xxxxxx x **XxxxxxxXxxx** xxxxx xx xxxxxxxx xxxxxxxxx xxxx xxx xxx xx xxx xxxxxxx xxxx, xxxxxxx xxx **XxxxxxxXxxx** xxxxxxxxxxxx xxxx xxx xxxx xxx xx xxxxxx xx xxxx xxxxxxxxx xxx xx xxx xxxxx xxxxxxxxx. Xxxx xx xxx xxx'x xxx **XxxxxxxXxxx** xx xxxx xxx xxxxx, xxx xxxxxx xxxxx xxxxx xx.

Xx'x xxxxxxxx xxx xxxx xxxxx xx xx xxxx xxxx xxx xxxxxx xxxxxxxxx xx *xxxxxxxxxXxxx* xx xxxxxxxxx. Xx xxxx'x xxxx, xxx xxxxx xxxxx'x xxxx x xxxxx xxxxxx xx xxxxxx. Xx xxxx xxxx, xxx xxxxx xxx xxx xxxxxxx xxxx xxxxxxx xxxx xxxxx xxxx xx xxxxx'x xxxx x xxxxxxx xxxxxx, xxx. Xx xxxx xx xx xxxxxxx x [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br225995) xx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208952) xxxx xxx xxxxxxxx xxxxx [**Xxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh763910) xx xxxxxxxx. Xxxx'x xxxxx. Xxxx **Xxxxxxx** xx xxxxxx, xxx xxxxx xx xxxx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br208921) xx xxx xx xxx xxxxxxx xx xxxxx: xxxx xxx xxxxxx xx **Xxxxxxx**, xx xxxx xxxxxxx'x xxxxxxx xxxx xxxx xxxxxxx xxxx xx xxxxxxxxxx-xxx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208718) xxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br208751).

**Xxxx**????Xxx xxxxxxxx xxxxx xx [**XxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/br209635) xxxx xxx xxxx xxxxxxxx: **XxxxxXxxxx** xxxxxx xx xxxxxxxx xxxxxxxxx xxxxx xx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208952) xx xxxxxxxx, xxxxxxxxxx xxxx xxxxx xx xx xxxxxxxxxx xx xxxxxxxx xx xxx xxxxxxxxxxx xxxxxxxxx. **XxxxxXxxxx** xxxxxxxxx xxxxx xxxxxx xxxxxxxxxxx, xx xxxxxxxxxxx xxx xxxxxxxx xx x xxxxx xxxx xxxxx xx xxxx xxxxxxxxx.

??

Xxxxxxx, xxx xxxxx xxxxxx xxx'x xxxxxx x [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br225995) xxxx xx xxxxxxxx xxxxx xxxx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208730); xxxx xxxxxx xx xxxxxxxxx xxxxxx xxxxxx. Xx, xxxx xx xxx xxxxx xx xx xxxx xxx xxx xxxxxxx xxxxxx xxxx xxx xxxxx xxxxxxxx, xxx xxx xxxx xxxxxx xx xxx xxxx xxxxxx xx xxxx xxxx xxx'x xxxxxx xxxx xxx xxxxx'x xxx xxxx xxxxxxxxxxx xxxxxxx. Xxxx'x xxx xxxxxx xxxxxxxx `LimitUnboundedSize` xxxx xxx xxxxxxxxxx xx xxxxxxxx xxxx, xxxxx xxxx xxxxx xxxx xxxxxxx xxxx xxxxxx xxx xxxx xx xx xxxx xxx xxxxx x xxxxxx xxxxxx xx xxxxxx, xx xxxx xx xxxxxxxx xxxx `cellheight` xx x xxxxxx xxxxxx xxxxxx xxx xxxxxxx xxxx xx xxxxxxxxx:

```CSharp
// This method is called only if one of the availableSize dimensions of measure is infinite.
// That can happen to height if the panel is close to the root of main app window.
// In this case, base the height of a cell on the max height from desired size
// and base the height of the panel on that number times the #rows.

Size LimitUnboundedSize(Size input)
{
    if (Double.IsInfinity(input.Height))
    {
        input.Height = maxcellheight * colcount;
        cellheight = maxcellheight;
    }
    return input;
}
```

## **XxxxxxxXxxxxxxx**


```CSharp
protected override Size ArrangeOverride(Size finalSize)
{
     int count = 1
     double x, y;
     foreach (UIElement child in Children)
     {
          x = (count - 1) % colcount * cellwidth;
          y = ((int)(count - 1) / colcount) * cellheight;
          Point anchorPoint = new Point(x, y);
          child.Arrange(new Rect(anchorPoint, child.DesiredSize));
          count++;
     }
     return finalSize;
}
```

Xxx xxxxxxxxx xxxxxxx xx xx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208711) xxxxxxxxxxxxxx xx xxx xxxx xxxxxxx xxxx xxxxxxx xx [**Xxxxx.Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227514). Xxxxxx xxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208914) xxxxxx xx xxxx xx xxxxx xxxxxxxx.

Xxxx xxx xxxxx xxxx'x xx xxxx xxxxxxxxxxxx xx xx [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208730); xxxx'x xxxxxxx. Xxx xxxx xx xxxxxxxx xx xxxxxxx xxxxx xxxx xxx xxxxx'x xxx **XxxxxxxXxxxxxxx** xxxxx, xx xxxx xxx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br208921) xxxxx xx xxxx xxxxx xxx xxxxxx xxx xxxxxxx xxxx. Xxxxxxx, xx xxxxx xxxx xx xxxxxx xxx xxxxxxxx xxxxxx xxx xxxxx xxxxx xxxx xxxxx xxxx xxxxxx. Xx x xxxxxxx xxxxx, xxxx xxxxx xxxxxx xxxxxx xx x xxxxxxxxx xxxxxxxx. X xxxxx xxxx xxxxxxx xxxxxxxxxxx xxxxxxxx xxx'x xxxxxxxxx xxx xxxxxxx xxxxxxxxx (xxxxxxxx xx'x xxx xxx xx xxx xxxxxxxx xx xxxxxx xxxxxx xxxx xxxx xxxxxxxxxx xxxxxxxx, xx xxxx'x xxxxxx xxxx xxxxxxxx xxxxxxxx).

Xxxx xxxxx xxxxxxxx xx xxx xxxxxxx xx xxxx xxx xxxxxxx. Xxx xxxxxx xx xxxx xxx xxxxxxx xxx xxxxxxx xxxxxxxxxx (xx xxx xxxxxxxxx xxx xxxxxxxxxxx). Xx xxx xxx xxxxx xx xxx xxxx xxx xxxxxxx xxxx xxx xxxxx xxxxx xx xxxx xxxx xxxxxxxxxx xx xxx xxxxx xx xxxxxxxx x xxxxxxxxx xxxxxxxx (xxx `anchorPoint`) xxx xxxx xxxxxxx xxxx xxxx xxxxx xxxxxxxx. Xxxx [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br225870), xxxxx xxxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br225995) xxxxxxx xxxxx xxxx xxxxxxx, xxx xxxx xx xxx xxx xxxxxxxxxx xxxx xxxxxxxxx x [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br225994). **Xxxx** xx xxx xxxxx xxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208914).

Xxxxxx xxxxxxxxx xxxx xx xxxx xxxxx xxxxxxx. Xx xxxx xx, xxx xxxxxxx xxxx xx xxx xxxx xxxx'x xxxxxxx xx [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br208921), xxxxxxx xxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208952) xxxxx xxxx xx xx xxx xxxxxxx xx xxxx xxx xxxxxx xx **Xxxxxxx**, xx xxxxx xxxxxxx xxxx xxxxxxx. Xx xxx xxx'x xxxxxxxxx xxxx xx xxxxxxxxxxxx xxxxx xxx xxxxxxxx xxxxxx [**Xxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208914); xxx xxxxxxxx xxxx xxxxxxx xxxxx xx xxxxxxx xxx **XxxxxxxXxxx** xxxxxxx xx xxxx **Xxxxxxx** xxxx.

Xxx xxx'x xxxxxx xxxx x xxxxx xxxxx xxxxx xxxxxxx xxx xxxx xx xxx xxx xxxx xxx xxxx xxx xxxxxxxx xxx xxxxxxxxx xxxxxxxx xx xxxxx xx xxxxx xxxxx. Xxx xxxxxxx, xx [**Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209267) xxxxxx xxxxx, xxx xxxxxxxx xx xxx [**Xxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227514) xxxxxxxxxx xxxxx'x xxxxxx. Xxx xxx xxxx xxxxxx xx xxxxxxxx xxxx xxxxxxx xx x **Xxxxxx** xx xxxxx xx xxxxxxx [**Xxxxxx.Xxxx**](https://msdn.microsoft.com/library/windows/apps/hh759771) xxx [**Xxxxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/hh759772) xxxxxx xx xxxxxxxx xx xxxx xx xxx xxxxxxx xxxxx. Xxx `BoxPanel` xxxxx xxxxxxx xx xxxx x xxxxx xx xxxxxxx xx xxx *xxxxxxxx* xx xx'x xxxxx xxxx xx xxxxx x xxx xxx xxx xxxxxx xxx *x* xxxxx.

Xx'x xxxxxxx xxxx xxx xxxxx *xxxxxXxxx* xxx xxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br225995) xxx xxxxxx xxxx x [**XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208711) xxxxxxxxxxxxxx xxx xxx xxxx. Xxx xxxx xxxx xxxxx xxx, xxx "**XxxxxxxXxxxxxxx**" xxxxxxx xx [XXXX xxxxxx xxxxxx xxxxxxxx](custom-panels-overview.md).

## X xxxxxxxxxx: xxxxxxxxxxx xxx xxx xx. xxxxxx xxxxx


Xxx xxxxx xxxxxxx xxx xxx xxxx xxxxx xxxx xx xx xx xxx. Xxxxxxx, xx'xx xxx xxx xxxx xxxxxxxxxx. Xx xxx xxxx xxxx xxxxx, xxx xxxxx xxxx xxx xxxxx xxx xx xxxxxx xx xxx xxxx xxxx'x xxxxxxx xx xxxxxx xxxxx. Xxx xxx xxxxxxx xxxxxxx xxxx xxx xxxxxx xx xxxxx, xx xxxxx xx xxxxxxxxx xx xxxxxx x Y??Y xxx xx xxxxx xxxxxxx xx Y??Y xxxx xx xxx xxxxx'x xxx xxxxxx xxxxx xx "xxxxxxxx." Xx xx'xx xxx xx xxxxxxxx xxxxxxxxxx xxxxxxxx xxxx xxx xxxxx xxxxxxxx xxx xxx xx xxxxxxx xxxx xxxxxxxx. Xxxx'x xxx xxxxxxxxxx xxxxxxxx xxxxxxxxxx, xxxxx xx xxxx xxxxx:

```CSharp
public static readonly DependencyProperty UseOppositeRCRatioProperty =
   DependencyProperty.Register("UseOppositeRCRatio", typeof(bool), typeof(BoxPanel), null);

public bool UseSquareCells
{
    get { return (bool)GetValue(UseOppositeRCRatioProperty); }
    set { SetValue(UseOppositeRCRatioProperty, value); }
}
```

Xxx xxxx'x xxx xxxxx `UseOppositeRCRatio` xxxxxxx xxx xxxxxxx xxxxx. Xxxxxx xxx xx'x xxxxx xx xxxxxxxx xxx `rowcount` xxx `colcount` xxx xxxxxxx xxxx `maxrc` xxx xxx xxxx xxxxxx xxxxx, xxx xxxxx xxx xxxxxxxxxxxxx xxxx xxxxxxxxxxx xxx xxxx xxxx xxxxxxx xx xxxx. Xxxx `UseOppositeRCRatio` xx **xxxx**, xx xxxxxxx xxx xxxxx xx xxx xxxx xxxxxx xxxxx xxxxxx xxxxx xx xxx xxx xxx xxxxxx xxxxxx.

```CSharp
if (UseOppositeRCRatio) { aspectratio = 1 / aspectratio;}
```

## Xxx xxxxxxxx xxx `BoxPanel`


Xxx xxxxxxxxxx xxxxxxxx xxx `BoxPanel` xx xxxx xx'x x xxxxx xxxxx xxx xx xxx xxxx xxxxxxxxxxxx xx xxx xx xxxxxx xxxxx xx xx xxxxxxx xxx xxxxxx xx xxxxx xxxxx, xxx xxxxxxxx xxx xxxxx xxxxxxxxx xxxxx xxx xxx xxxxx. Xxxxxx xxx xxxxxxxx xxxxxxxxx xxxxxx. Xxxx xxxxxx xxxxxxx xx xxxxxxxx xxxx xxxxxxxxx xxxxx xxxx xxxxxxx xxxxxxxxxx; xxxx'x xxxx [**Xxxx**](https://msdn.microsoft.com/library/windows/apps/br242704) xxxx xxx xxx xxxxx. Xx **Xxxx**'x xxxx, xxx xxxx xx xxx xxxxx xx xxx xx [**XxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br209324) xxx [**XxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br227606) xxxxxx, xxx xxxxxxxx xxxxxxx xxx xxxxx xxxx xxxx xx xxxx xxxx [**Xxxx.Xxx**](https://msdn.microsoft.com/library/windows/apps/hh759795) xxx [**Xxxx.Xxxxxx**](https://msdn.microsoft.com/library/windows/apps/hh759774) xxxxxxxx xxxxxxxxxx. Xxxxxxx xxxx xxxxxx xxxx x **Xxxx** xxxxxxx xxxxxxxx xxxxxxx xxx xxxxxx xx xxxxx xxxxxxxx xxxxxxxxxx, xx xxxx xxxxx xxx xxxxxx xxxxx xxx xxxx xxxxx xxxxxxx xxxx xxx xxxxxxxx xxxxxxxxxx xx xxx xxxx xxx xxx xxxx.

Xxx xxxx xx xxx xxxxxx xx xxxxxxxx xx xxxxxxx? Xxxx'x xxxxxxxxx xxxxxxxx; xxxx xxx xxxx xxx xxx xxxxx xx xxxxxxxxxxx, xx xxxxxxxx xx xxx xxxxxxx xxx-xxxx xxxxxxxxx xxx xxxxxxxx xx xx xxxxxxxxx xxxxxx xx xx xxxxx xxxxxxxx xxxx XX. Xx xxx'xx xxxxx xxxx xxxxxxx xx xxxxxxx xxxxxxxxxxx/xxxxxxxx xxxxxxx, xxxxxxx xxxx xxxxxxx xxx xxxxxxxx xxx XX xx xxxxxxx xxxxxxxxxxxxx, xx xxxx'x xxxxx xxx xxxxxxxxx xxxxxxxxx (xxx [Xxxx xxxxxxx xx xxxxx](https://msdn.microsoft.com/library/windows/apps/mt210946)).

Xxx xxx xxx xxx xxxxxxxxx xxxx xxxxxxxxxx xx xxxx xxxxxxx. Xxxxxxxxx, xxx xxxx xx xxxxxx xxx XX xxxxxxxx xx xxxxxxx xxx xxxx xxxx xxxxxxx. `BoxPanel` xx xxx xxxx xxxxxxxx. X xxxxxxxx xxxxxx xx xxxxx xxxxx xx xx xxxxxxx xxx `BoxPanel` xxxxxxx xx'x xxxxx xxx xxxxx xxxxx xx xxxxxxxxxxxx, xxx xxxxxxx xxxx xxx xxxxxxxx xxx xxx xxxxx xxxxxxxx xxxx x xxx xxxxxx xx xxxx xxx xxx.

Xx xxxxxxxx xxxxxxxx xxx xxxxxxxxx `BoxPanel` xxxxxxx (xxx xxxxx xxxx) xxxxx xxxx xxxxxxxxxxx xxxxxxx xxxxxxxx xxx xxx x xxxxx'x [**XxxxxxxXxxx**](https://msdn.microsoft.com/library/windows/apps/br208921) xx x xxxxxxxx xxxxxx xxx xxx xxxxxx xx xxxxxxxxxx xxxxx. Xxxx xxxxxxxx xxxxx xxx xxxxxxx xxx xx xxxxxx xxxxx xx xxx-xxxx xxxxxx xx xxxx xxxxx'x xxxx "xxxxxx" xxxxx. Xxxx xxxxxxxx x xxxxxxxx xxx xxx xxxxxxxx xxxxxxxxxx xx xxxxxxx xxxxx xxx xxxxxx xxxxxx xxx xxx xxx xxxx x xxxxxxxxxx xxxxxxxxx xxxx xxx xxxxxxxxxx xxx xxxxxxxx xxxx. `BoxPanel` xxxxx'x xx xxxx; xx'x xxxxx x xxxxxxx xxxxxxxxx xxx xxxxxxxx xxxxx. `BoxPanel`'x xxxxxxxxx xx xx xxxxxxxxx xxx xxxxx xxxxxx xxxxxx xxxx'x xxxxxxx xxxx xxx xxxxx xxxxx. Xxx xxxxxxx, Y xxxxx xxxxx xxx xx x Y??Y xxxxxx. YY xxxxx xxxxxxx x Y??Y xxxxxx. Xxxxxxx, xxx xxx xxxxx xxx xxxxx xxxxx xxxxx xxxxxxxx xxx xxx xx xxxxxx xx xxx xxxxxxxx xxxxxx, xx xxxx xxxxx. Xx xxx xxxxx=YY xxxxxxx, xxxx xxxx xx x Y??Y xx Y??Y xxxxxxxxx.

Xxx xxxxx xxxxxx xxx xxx xxxxx xxxxxx'x xxxxxxx xxxxxx Y??Y xxx YY xxxxx, xxxxxxx xxxx xxxx xxx xxxx xxxxxx xxxxxx. Xxxxxxx, xx xxxxxxxx, xxxxxx xxx xxxxx xx xxxxxxxxxx xxxx xxxxxx xxxx x xxxxxxxx xxxxxxxx xxxxxx xxxxx. Xxx xxxxx-xxxxxxx xxxxxxxxx xx x xxx xx xxxx xxx xxxxxx xxxxx xx xxxx xxxx xxxx xxxxxxx xxxxxx xxxxxx xxx xxx xxxxxxxxx xxxxxx xxxxx xxx xxxx xxxxxx xxx xxx xxxxxx xxxxxx.

**Xxxx**????
Xxxx xxxxxxx xx xxx Xxxxxxx YY xxxxxxxxxx xxxxxxx Xxxxxxxxx Xxxxxxx Xxxxxxxx (XXX) xxxx. Xx xxx???xx xxxxxxxxxx xxx Xxxxxxx Y.x xx Xxxxxxx Xxxxx Y.x, xxx xxx [xxxxxxxx xxxxxxxxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132).

??

## Xxxxxxx xxxxxx


**Xxxxxxxxx**
*[**XxxxxxxxxXxxxxxx.XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208711)

* [**XxxxxxxxxXxxxxxx.XxxxxxxXxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/br208730)
* [**Xxxxx**](https://msdn.microsoft.com/library/windows/apps/br227511)

**Xxxxxxxx**
* [Xxxxxxxxx, xxxxxx, xxx xxxxxxx](alignment-margin-padding.md)

<!--HONumber=Mar16_HO1-->
