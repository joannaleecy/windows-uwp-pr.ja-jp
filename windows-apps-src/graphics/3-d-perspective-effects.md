---
xx.xxxxxxx: YYXYYYYY-YYXY-YYYY-YYYY-YYXXYXXYYYYY
xxxxx: Y-X xxxxxxxxxxx xxxxxxx xxx XXXX XX
xxxxxxxxxxx: Xxx xxx xxxxx Y-X xxxxxxx xx xxxxxxx xx xxxx Xxxxxxx Xxxxxxx xxxx xxxxx xxxxxxxxxxx xxxxxxxxxx. Xxx xxxxxxx, xxx xxx xxxxxx xxx xxxxxxxx xxxx xx xxxxxx xx xxxxxxx xxxxxx xx xxxx xxxx xxx, xx xxxxx xxxx.
---
# Y-X xxxxxxxxxxx xxxxxxx xxx XXXX XX

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]

Xxx xxx xxxxx Y-X xxxxxxx xx xxxxxxx xx xxxx Xxxxxxx Xxxxxxx xxxx xxxxx xxxxxxxxxxx xxxxxxxxxx. Xxx xxxxxxx, xxx xxx xxxxxx xxx xxxxxxxx xxxx xx xxxxxx xx xxxxxxx xxxxxx xx xxxx xxxx xxx, xx xxxxx xxxx.

![Xxxxx xxxx Xxxxxxxxxxx Xxxxxxxxx](images/3dsimple.png)

Xxxxxxx xxxxxx xxxxx xxx xxxxxxxxxxx xxxxxxxxxx xx xx xxxxxxx xxxxxxx xx xxxxxxxx xx xxx xxxxxxx xx xxxxxx x Y-X xxxxxx, xx xxxx.

![Xxxxxxxx xxxxxxx xx xxxxxx x Y-X xxxxxx](images/3dstacking.png)

Xxxxxxx xxxxxxxx xxxxxx Y-X xxxxxxx, xxx xxx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxx xxxxxxxxxx xx xxxxxx xxxxxx Y-X xxxxxxx. [Xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236111) xx xxx xx xxxxxxx xx xxxx.

Xxx xxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxxxxx xx xxxxxx, xxx xxx xxx xxxxx xxxxx xxxxxxx xx xxx [**XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208911), xxxxxxxxx xxxxxxxx. Xxx xxxxxxx, xxx xxx xxxxx x Y-X xxxxxx xx xx xxxxxx xxxxxxxxx xx xxxxxxxx xxxx xxxx:

![Y-X xxxxxx xxxxxxx xx x xxxxxxxxx xx xxxxxxxx](images/skewedstackpanel.png)

Xxxx xx xxx XXXX xxxx xxxx xx xxxxxx xxxx xxxxxx:

```xml
<StackPanel Margin="35" Background="Gray">    
    <StackPanel.Projection>        
        <PlaneProjection RotationX="-35" RotationY="-35" RotationZ="15"  />    
    </StackPanel.Projection>    
    <TextBlock Margin="10">Type Something Below</TextBlock>    
    <TextBox Margin="10"></TextBox>    
    <Button Margin="10" Content="Click" Width="100" />
</StackPanel>
```

Xxxx xx xxxxx xx xxx xxxxxxxxxx xx [**XxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR210192) xxxxx xx xxxx xx xxxxxx xxx xxxx xxxxxxx xx Y-X xxxxx. Xxx xxxx xxxxxx xxxxxx xxx xx xxxxxxxxxx xxxx xxxxx xxxxxxxxxx xxx xxx xxxxx xxxxxx xx xx xxxxxx.

[Xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236112)

## XxxxxXxxxxxxxxx xxxxx

Xxx xxx xxxxx YX xxxxxxx xxx xx xxx [**XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208911), xx xxxxxxx xxx XXXxxxxxx'x [**Xxxxxxxxxx**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.uielement.projection.aspx) xxxxxxxx xxxxx x [**XxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR210192). Xxx **XxxxxXxxxxxxxxx** xxxxxxx xxx xxx xxxxxxxxx xx xxxxxxxx xx xxxxx. Xxx xxxx xxxxxxx xxxxx x xxxxxx xxxx.

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35"   />
    </Image.Projection>
</Image>
```

Xxxx xxxxxx xxxxx xxxx xxx xxxxx xxxxxxx xx. Xxx x-xxxx, x-xxxx, xxx x-xxxx xxx xxxxx xx xxx xxxxx. Xxx xxxxx xx xxxxxxx xxxxxxxx YY xxxxxxx xxxxxx xxx x-xxxx xxxxx xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) xxxxxxxx.

![XxxxxxX xxxxx YY xxxxxxx](images/3drotatexminus35.png)

Xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) xxxxxxxx xxxxxxx xxxxxx xxx x-xxxx xx xxx xxxxxx xx xxxxxxxx.

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35"   />
    </Image.Projection>
</Image>
```

![XxxxxxX xxxxx YY xxxxxxx](images/3drotateyminus35.png)

Xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationz) xxxxxxxx xxxxxxx xxxxxx xxx x-xxxx xx xxx xxxxxx xx xxxxxxxx (x xxxx xxxx xx xxxxxxxxxxxxx xx xxx xxxxx xx xxx xxxxxx).

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationZ="-45"   />
    </Image.Projection>
</Image>
```

![XxxxxxX xxxxx YY xxxxxxx](images/3drotatezminus35.png)

Xxx xxxxxxxx xxxxxxxxxx xxx xxxxxxx x xxxxxxxx xx xxxxxxxx xxxxx xx xxxxxx xx xxxxxx xxxxxxxxx. Xxx xxxxxxxx xxxxxx xxx xx xxxxxxx xxxx YYY, xxxxx xxxxxxx xxx xxxxxx xxxx xxxx xxx xxxx xxxxxxxx. [Xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236112) xx xxxxxxxxxx xxxx xxxxxxxxx xxxxxx xxx xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx), [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy), xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationz) xxxxxxxxxx xx xxx xxx xxxxxx.

Xxx xxx xxxx xxx xxxxxx xx xxxxxxxx xx xxxxx xxx [**XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx.aspx), [**XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy), xxx [**XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) xxxxxxxxxx. Xx xxxxxxx, xxx xxxx xx xxxxxxxx xxx xxxxxxxx xxxxxxx xxx xxxxxx xx xxx xxxxxx, xxxxxxx xxx xxxxxx xx xxxxxx xxxxxx xxx xxxxxx. Xxx xx xxx xxxx xxx xxxxxx xx xxxxxxxx xx xxx xxxxx xxxx xx xxx xxxxxx, xx xxxx xxxxxx xxxxxx xxxx xxxx. Xxx xxxxxxx xxxxxx xxx **XxxxxxXxXxxxxxxxX** xxx **XxxxxxXxXxxxxxxxX** xxx Y.Y, xxx xxx xxxxxxx xxxxx xxx **XxxxxxXxXxxxxxxxX** xx Y. Xxx **XxxxxxXxXxxxxxxxX** xxx **XxxxxxXxXxxxxxxxX**, xxxxxx xxxxxxx Y xxx Y xxx xxx xxxxx xxxxx xx xxxx xxxxxxxx xxxxxx xxx xxxxxx. X xxxxx xx Y xxxxxxx xxx xxxxxx xxxx xxx Y xxxxxxx xxx xxxxxxxx xxxx. Xxxxxx xxxxxxx xx xxxx xxxxx xxx xxxxxxx xxx xxxx xxxx xxx xxxxxx xx xxxxxxxx xxxxxxxxxxx. Xxxxxxx xxx x-xxxx xx xxx xxxxxx xx xxxxxxxx xx xxxxx xxxxxxx xxx xxxxx xx xxx xxxxxx, xxx xxx xxxx xxx xxxxxx xx xxxxxxxx xxxxxx xxx xxxxxx xxxxx x xxxxxxxx xxxxxx xxx xx xxxxx xx xxx xxxxxx (xxxxxx xxx) xxxxx x xxxxxxxx xxxxxx.

[
            **XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx.aspx) xxxxx xxx xxxxxx xx xxxxxxxx xxxxx xxx x-xxxx xxxxxxxx xx xxx xxxxxx xxxxx [**XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) xxxxx xxx xxxxxx xx xxxxxxxx xxxxx xxx x-xxxx xx xxx xxxxxx. Xxx xxxx xxxxxxxxxxxxx xxxxxxxxxxx xxxxx xxxxxxxxx xxxxxx xxx **XxxxxxXxXxxxxxxxX**.

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35" CenterOfRotationY="0.5" />
    </Image.Projection>
</Image>
```

**XxxxxxXxXxxxxxxxX = "Y.Y" (xxxxxxx)**

![XxxxxxXxXxxxxxxxX xxxxxx Y.Y](images/3drotatexminus35.png)
```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationX="-35" CenterOfRotationY="0.1" />
    </Image.Projection>
</Image>
```

**XxxxxxXxXxxxxxxxX = "Y.Y"**

![XxxxxxXxXxxxxxxxX xxxxxx Y.Y](images/3dcenterofrotationy0point1.png)

Xxxxxx xxx xxx xxxxx xxxxxxx xxxxxx xxx xxxxxx xxxx xxx [**XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationy) xxxxxxxx xx xxx xx xxx xxxxxxx xxxxx xx Y.Y xxx xxxxxxx xxxx xxx xxxxx xxxx xxxx xxx xx Y.Y. Xxx xxx xxxxxxx xxxxxxxx xxxx xxxxxxxx xxx [**XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/en-us/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationx.aspx) xxxxxxxx xx xxxx xxxxx xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) xxxxxxxx xxxxxxx xxx xxxxxx.

```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35" CenterOfRotationX="0.5" />
    </Image.Projection>
</Image>
```

**XxxxxxXxXxxxxxxxX = "Y.Y" (xxxxxxx)**

![XxxxxxXxXxxxxxxxX xxxxxx Y.Y](images/3drotateyminus35.png)
```xml
<Image Source="kid.png">
    <Image.Projection>
        <PlaneProjection RotationY="-35" CenterOfRotationX="0.5" />
    </Image.Projection>
</Image>
```

**XxxxxxXxXxxxxxxxX = "Y.Y" (xxxxx-xxxx xxxx)**

![XxxxxxXxXxxxxxxxX xxxxxx Y.Y](images/3dcenterofrotationx0point9.png)

Xxx xxx [**XxxxxxXxXxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.centerofrotationz) xx xxxxx xxx xxxxxx xx xxxxxxxx xxxxx xx xxxxx xxx xxxxx xx xxx xxxxxx. Xxxx xxx, xxx xxx xxxxxx xxx xxxxxx xxxxxx xxx xxxxx xxxxxxxxx xx x xxxxxx xxxxxxxx xxxxxx x xxxx.

[Xxx xxxx xxxxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236112) xx xxxxxxxxxx xxxx xxxxxxxx xxx xxxxxx xxxxxx xxxxxxxxx xxxxxxxxx xxx xxx xxxxxx xx xxxxxxxx.

## Xxxxxxxxxxx xx xxxxxx

Xx xxx, xxx xxxxxxx xxx xx xxxxxx xx xxxxxx xx xxxxx. Xxx xxx xxxxxxxx xxxxx xxxxxxx xxxxxxx xx xxxxx xxxxxxxx xx xxx xxxxxxx xx xxxxx xxxxx xxxxxxxxxx:

-   [
            **XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx) xxxxx xx xxxxxx xxxxx xxx x-xxxx xx xxx xxxxx xx x xxxxxxx xxxxxx.
-   [
            **XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) xxxxx xx xxxxxx xxxxx xxx x-xxxx xx xxx xxxxx xx x xxxxxxx xxxxxx.
-   [
            **XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) xxxxx xx xxxxxx xxxxx xxx x-xxxx xx xxx xxxxx xx x xxxxxxx xxxxxx.
-   [
            **XxxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) xxxxx xx xxxxxx xxxxx xxx xxxxxx-xxxxxxx x-xxxx.
-   [
            **XxxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety) xxxxx xx xxxxxx xxxxx xxx xxxxxx-xxxxxxx x-xxxx.
-   [
            **XxxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) xxxxx xx xxxxxx xxxxx xxx xxxxxx-xxxxxxx x-xxxx.

**Xxxxx xxxxxx**

Xxx [**XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx), [**XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety), xxx [**XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) xxxxxxxxxx xxxxxxxxx xx xxxxxx xxxxx xxx xxxxxxxxxx xxxx xx xxx xxxxx xx xxx xxxxxx xxxxx xx xxx xxxx xxxxxxx. Xxxxxxxxx, xxx xxxxxxxx xx xxx xxxxxx xxxxxxxxxx xxx xxxxxxxxx xxxx xxx xxxxxx xx xxxxxxxxxx. Xx xxxxxxxxxxx xxxx xxxxxxx, xxx xxxx xxxxxx xxxxxxxx **XxxxxXxxxxxX** xxxx Y xx YYY xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) xxxx Y xx YY xxxxxxx.

[Xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236209)

Xxxxxx xx xxx xxxxxxxxx xxxxxx xxxx xxx xxxxxx xx xxxxxx xxxxx xxx xxx x-xxxx. Xx xxx xxxx xxxxxxxxx xx xxx xxxxxxxxx, xxxx xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) xxxxx xx xxxx xxxx (xxxxxxxx xx xxx xxxxxx), xxx xxxxxx xxxxx xxxxx xxx xxxxxx xx xxx x xxxxxxxxx, xxx xx xxx xxxxxx xxxxxxx xxxxxx xxx, xxx xxxxxx xxxxx xxxxx xxx x-xxxx xx xxx xxxxx xx xxx xxxxxx xxxxxx xxx. Xx xxx xxxxx xxxx, xx xxx xxxxxxxx xxx **XxxxxxxxX** xxxxxxxx xx -YY xxxxxxx, xxx xxxxxx xxxxx xxxxx xxxx xxxx xxx.

[
            **XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsety) xxxxx xxxxxxxxx xx [**XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetx), xxxxxx xxxx xx xxxxx xxxxx xxx xxxxxxxx xxxx, xx xxxxxxxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) xxxxxxx xxx xxxxxxxxx **XxxxxXxxxxxX** xxxxx xxx xxxxxx. Xx xxx xxxx xxxxxx, **XxxxxXxxxxxX** xx xxxxxxxx xxxx Y xx YYY xxx **XxxxxxxxX** xxxx Y xx YY xxxxxxx.

[Xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236210)

[
            **XxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.localoffsetz) xxxxxxxxxx xxx xxxxxx xxxxxxxxxxxxx xx xxx xxxxx xx xxx xxxxxx xx xxxxxx x xxxxxx xxx xxxxx xxxxxxxx xxxxxxx xxx xxxxxx xxxx xxxxxx xxx xxxxxx xxx xxxxxx xxx. Xx xxxxxxxxxxx xxx **XxxxxXxxxxxX** xxxxx, xxx xxxx xxxxxx xxxxxxxx **XxxxxXxxxxxX** xxxx Y xx YYY xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) xxxx Y xx YY xxxxxxx.

[Xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236211)

Xx xxx xxxxxxxxx xx xxx xxxxxxxxx, xxxx xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationx) xxxxx xx xxxx xxxx (xxxxxxxx xx xxx xxxxxx), xxx xxxxxx xxxxx xxxxxxxx xxx xxxxxx xxx, xxx xx xxx xxxx xx xxx xxxxxx xxxxxxx xxxx, xxx xxxxxx xxxxx xxxx xxxxxxx.

**Xxxxxx xxxxxx**

Xxx [**XxxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx), [**XxxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsety), xxx [**XxxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetz) xxxxxxxxxx xxxxxxxxx xxx xxxxxx xxxxx xxxx xxxxxxxx xx xxx xxxxxx. Xxxx xx, xxxxxx xxx xxxxx xxxxxx xxxxxxxxxx, xxx xxxx xxx xxxxxx xxxxx xxxxx xx xxxxxxxxxxx xx xxx xxxxxxxx xxxxxxx xx xxx xxxxxx. Xxxxx xxxxxxxxxx xxx xxxxxx xxxx xxx xxxx xx xxxxxx xxxx xxx xxxxxx xxxxx xxx x-, x-, xx x-xxxx xx xxx xxxxxx xxxxxxx xxxxxxxx xxxxx xxx xxxxxxxx xxxxxxx xx xxx xxxxxx.

Xxx xxxx xxxxxx xxxxxxxx [**XxxxxxXxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.globaloffsetx) xxxx Y xx YYY xxx [**XxxxxxxxX**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.planeprojection.rotationy) xxxx Y xx YY xxxxxxx.

[Xxx xxxx xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=236213)

Xxxxxx xx xxxx xxxxxx xxxx xxx xxxxxx xxxx xxx xxxxxx xxxxxx xx xx xxxxxxx. Xxxx xx xxxxxxx xxx xxxxxx xx xxxxx xxxxx xxxxx xxx x-xxxx xx xxx xxxxxx xxxxxxx xxxxxx xx xxx xxxxxxxx.

## Xxxxxxxxxxx xx xxxxxx

Xxx xxx xxx xxx [**XxxxxxYXXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR210128) xxx [**XxxxxxYX**](https://msdn.microsoft.com/library/windows/apps/BR243266) xxxxx xxx xxxx xxxxxxx xxxx-YX xxxxxxxxx xxxx xxx xxxxxxxx xxxx xxx [**XxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR210192). **XxxxxxYXXxxxxxxxxx** xxxxxxxx xxx xxxx x xxxxxxxx YX xxxxxxxxx xxxxxx xx xxxxx xx xxx [**XXXxxxxxx**](https://msdn.microsoft.com/library/windows/apps/BR208911), xx xxxx xxx xxx xxxxx xxxxxxxxx xxxxx xxxxxxxxxxxxxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxx xx xxxxxxxx. Xxxx xx xxxx xxxx xxxxx XXX xxx xxxxxxx xxx xxxxxxxxx xx xxx xxx xxxx, xxx xxxx xxxx xx xxxxx xxx xxxx xxxx xxxxxxxxx xxxxxxx xxx YX xxxxxxxxx xxxxxxxx. Xxxxxxx xx xxxx, xx xx xxxxxx xx xxx **XxxxxXxxxxxxxxx** xxx xxxxxx YX xxxxxxxxx.

 

 




<!--HONumber=Mar16_HO1-->
