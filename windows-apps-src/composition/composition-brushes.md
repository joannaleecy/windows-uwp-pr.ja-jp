---
ms.assetid: 03dd256f-78c0-e1b1-3d9f-7b3afab29b2f
title: コンポジションのブラシ
description: ブラシは、その出力で Visual の領域を塗りつぶします。 さまざまなブラシで、出力の種類もさまざまです。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: eb0d48cee4fe6698ec371c882c913affa5af7729
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57644887"
---
# <a name="composition-brushes"></a>コンポジションのブラシ
UWP アプリケーションで画面に表示されるすべての情報は、ブラシによって塗りつぶされることによって表示されます。 ブラシを使用すると、シンプルで単色のカラーからイメージや描画を複雑なエフェクト チェーンまで、さまざまなコンテンツを使用してユーザー インターフェイス (UI) オブジェクトを塗りつぶします。 このトピックでは、CompositionBrush を使用した塗りつぶしの概念を紹介します。

注: XAML UWP アプリを扱う場合、[XAML ブラシ](/windows/uwp/design/style/brushes)または [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) を使用して UIElement を塗りつぶすことができます。 通常、自分のシナリオが XAML ブラシでサポートされている場合、XAML ブラシを選択する方が簡単であるため、この方法をお勧めします。 たとえば、ボタンの色をアニメーション化する場合や、画像を使用してテキストや図形の塗りつぶしを変更する場合です。 その一方で、なアニメーションのマスクまたはアニメーションの 9 グリッド stretch、効果のチェーンでの描画などの XAML のブラシでサポートされていない操作を行う場合、CompositionBrush する際の使用により UIElement を描画[XamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)します。

ビジュアル レイヤーを扱う場合、CompositionBrush を使用して [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual) の領域を塗りつぶす必要があります。

-   [前提条件](./composition-brushes.md#prerequisites)
-   [CompositionBrush での塗りつぶし](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [純色で描画します。](./composition-brushes.md#paint-with-a-solid-color)
    -   [線形グラデーションで塗りつぶす](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [イメージで描画します。](./composition-brushes.md#paint-with-an-image)
    -   [カスタム描画で塗りつぶす](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [ビデオを描画します。](./composition-brushes.md#paint-with-a-video)
    -   [フィルター効果で描画します。](./composition-brushes.md#paint-with-a-filter-effect)
    -   [不透明度マスクを持つ、CompositionBrush で描画します。](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [NineGrid stretch を使用して CompositionBrush で描画します。](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [バック グラウンドのピクセルを使用して描画します。](./composition-brushes.md#paint-using-background-pixels)
-   [結合 CompositionBrushes](./composition-brushes.md#combining-compositionbrushes)
-   [XAML のブラシ vs を使用します。CompositionBrush](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [関連トピック](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a>前提条件
この概要では、「[ビジュアル レイヤーの概要](visual-layer.md)」で説明されているように、基本的なコンポジション アプリケーションの構造を理解していることを前提としています。

## <a name="paint-with-a-compositionbrush"></a>CompositionBrush による塗りつぶし

[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) は、その出力で領域を "塗りつぶします"。 さまざまなブラシで、出力の種類もさまざまです。 ブラシは、単色、グラデーション、画像、カスタム描画、効果を使用して領域を塗りつぶします。 その他のブラシの動作を変更する特殊なブラシも用意されています。 たとえば、不透明度マスクを使用して、CompositionBrush によって塗りつぶされる領域を制御することや、9 グリッドを使用して、領域を描画するときに、CompositionBrush に適用されるストレッチを制御することができます。 CompositionBrush は次の種類のいずれかです。

|クラス                                   |詳細                                         |導入された製品|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |単色で領域を塗りつぶします。                        |Windows 10 November Update (SDK 10586)|
|[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface) の内容で領域を塗りつぶします。|Windows 10 November Update (SDK 10586)|
|[同様](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |コンポジション効果の内容で領域を塗りつぶします。 |Windows 10 November Update (SDK 10586)|
|[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |不透明度マスクを使って CompositionBrush でビジュアルを塗りつぶします。 |Windows 10 Anniversary Update (SDK 14393)
|[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |NineGrid ストレッチを使って CompositionBrush で領域を塗りつぶします。 |Windows 10 Anniversary Update SDK (14393)
|[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|線形グラデーションで領域を塗りつぶします。                    |Windows 10 Fall Creators Update (Insider Preview SDK)
|[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |アプリケーションのピクセルから、または直接デスクトップ上のアプリケーション ウィンドウの背景のピクセルから背景ピクセルをサンプリングして領域を塗りつぶします。 CompositionEffectBrush など、別の CompositionBrush への入力として使用されます。 | Windows 10 Anniversary Update (SDK 14393)

### <a name="paint-with-a-solid-color"></a>単色による塗りつぶし

[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush) は単色で領域を塗りつぶします。 SolidColorBrush の色を指定するには、さまざまな方法があります。 たとえば、そのアルファ、赤、青、緑 (ARGB) チャネルを指定したり、[Colors](https://docs.microsoft.com/uwp/api/windows.ui.colors) クラスによって提供される定義済みの色のいずれかを使用したりすることができます。

次の図とコードは、黒の色ブラシで描かれた四角形を、色の値が 0x9ACD32 である単色ブラシで塗りつぶす小規模なビジュアル ツリーを示しています。

![CompositionColorBrush](images/composition-compositioncolorbrush.png)

```cs
Compositor _compositor;
ContainerVisual _container;
SpriteVisual _colorVisual1, _colorVisual2;
CompositionColorBrush _blackBrush, _greenBrush;

_compositor = Window.Current.Compositor;
_container = _compositor.CreateContainerVisual();

_blackBrush = _compositor.CreateColorBrush(Colors.Black);
_colorVisual1= _compositor.CreateSpriteVisual();
_colorVisual1.Brush = _blackBrush;
_colorVisual1.Size = new Vector2(156, 156);
_colorVisual1.Offset = new Vector3(0, 0, 0);
_container.Children.InsertAtBottom(_colorVisual1);

_ greenBrush = _compositor.CreateColorBrush(Color.FromArgb(0xff, 0x9A, 0xCD, 0x32));
_colorVisual2 = _compositor.CreateSpriteVisual();
_colorVisual2.Brush = _greenBrush;
_colorVisual2.Size = new Vector2(150, 150);
_colorVisual2.Offset = new Vector3(3, 3, 0);
_container.Children.InsertAtBottom(_colorVisual2);
```

### <a name="paint-with-a-linear-gradient"></a>線状グラデーションによる塗りつぶし

[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush) は、線状グラデーションを使って領域を塗りつぶします。 線状グラデーションでは、線、つまりグラデーション軸に沿って 2 つ以上の色をブレンドします。 GradientStop オブジェクトを使って、グラデーションの色とその位置を指定します。

次の図とコードは、赤と黄色を使用した 2 ストップの LinearGradientBrush によって塗りつぶされた SpriteVisual を示しています。

![CompositionLinearGradientBrush](images/composition-compositionlineargradientbrush.png)

```cs
Compositor _compositor;
SpriteVisual _gradientVisual;
CompositionLinearGradientBrush _redyellowBrush;

_compositor = Window.Current.Compositor;

_redyellowBrush = _compositor.CreateLinearGradientBrush();
_redyellowBrush.ColorStops.Add(_compositor.CreateColorGradientStop(0, Colors.Red));
_redyellowBrush.ColorStops.Add(_compositor.CreateColorGradientStop(1, Colors.Yellow));
_gradientVisual = _compositor.CreateSpriteVisual();
_gradientVisual.Brush = _redyellowBrush;
_gradientVisual.Size = new Vector2(156, 156);
```

### <a name="paint-with-an-image"></a>画像による塗りつぶし

[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) は、ICompositionSurface にレンダリングされるピクセルを使用して領域を塗りつぶします。 たとえば、CompositionSurfaceBrush を使用して、[LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API によって ICompositionSurface サーフェスにレンダリングされた画像で領域を塗りつぶすことができます。

次の図とコードは、LoadedImageSurface を使って ICompositionSurface にレンダリングされたリコリスのビットマップで塗りつぶされた SpriteVisual を示しています。 CompositionSurfaceBrush のプロパティを使用して、ビットマップを拡大し、ビジュアルの境界内に合わせることができます。

![CompositionSurfaceBrush](images/composition-compositionsurfacebrush.png)

```cs
Compositor _compositor;
SpriteVisual _imageVisual;
CompositionSurfaceBrush _imageBrush;

_compositor = Window.Current.Compositor;

_imageBrush = _compositor.CreateSurfaceBrush();

// The loadedSurface has a size of 0x0 till the image has been been downloaded, decoded and loaded to the surface. We can assign the surface to the CompositionSurfaceBrush and it will show up once the image is loaded to the surface.
LoadedImageSurface _loadedSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/licorice.jpg"));
_imageBrush.Surface = _loadedSurface;

_imageVisual = _compositor.CreateSpriteVisual();
_imageVisual.Brush = _imageBrush;
_imageVisual.Size = new Vector2(156, 156);
```

### <a name="paint-with-a-custom-drawing"></a>カスタム描画による塗りつぶし
[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) を使用して、[Win2D](https://microsoft.github.io/Win2D/html/Introduction.htm) (または D2D) によってレンダリングされた ICompositionSurface のピクセルで領域を塗りつぶすこともできます。

次のコードは、Win2D を使用して ICompositionSurface にレンダリングされたテキストで塗りつぶされた SpriteVisual を示しています。 Win2D を使用するには、[Win2D NuGet](https://www.nuget.org/packages/Win2D.uwp) パッケージをプロジェクトに含める必要があります。

```cs
Compositor _compositor;
CanvasDevice _device;
CompositionGraphicsDevice _compositionGraphicsDevice;
SpriteVisual _drawingVisual;
CompositionSurfaceBrush _drawingBrush;

_device = CanvasDevice.GetSharedDevice();
_compositionGraphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(_compositor, _device);

_drawingBrush = _compositor.CreateSurfaceBrush();
CompositionDrawingSurface _drawingSurface = _compositionGraphicsDevice.CreateDrawingSurface(new Size(256, 256), DirectXPixelFormat.B8G8R8A8UIntNormalized, DirectXAlphaMode.Premultiplied);

using (var ds = CanvasComposition.CreateDrawingSession(_drawingSurface))
{
     ds.Clear(Colors.Transparent);
     var rect = new Rect(new Point(2, 2), (_drawingSurface.Size.ToVector2() - new Vector2(4, 4)).ToSize());
     ds.FillRoundedRectangle(rect, 15, 15, Colors.LightBlue);
     ds.DrawRoundedRectangle(rect, 15, 15, Colors.Gray, 2);
     ds.DrawText("This is a composition drawing surface", rect, Colors.Black, new CanvasTextFormat()
     {
          FontFamily = "Comic Sans MS",
          FontSize = 32,
          WordWrapping = CanvasWordWrapping.WholeWord,
          VerticalAlignment = CanvasVerticalAlignment.Center,
          HorizontalAlignment = CanvasHorizontalAlignment.Center
     }
);

_drawingBrush.Surface = _drawingSurface;

_drawingVisual = _compositor.CreateSpriteVisual();
_drawingVisual.Brush = _drawingBrush;
_drawingVisual.Size = new Vector2(156, 156);
```

同様に、CompositionSurfaceBrush を使用して、Win2D の相互運用機能を使う SwapChain で SpriteVisual を塗りつぶすこともできます。 [このサンプル](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を使用して、スワップ チェーンで SpriteVisual を塗りつぶす方法の例を示しています。

### <a name="paint-with-a-video"></a>ビデオによる塗りつぶし
[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) を使用して、[MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) クラスによって読み込まれたビデオを使ってレンダリングされた ICompositionSurface のピクセルで領域を塗りつぶすこともできます。

次のコードは、ICompositionSurface に読み込まれたビデオで塗りつぶされた SpriteVisual を示しています。

```cs
Compositor _compositor;
SpriteVisual _videoVisual;
CompositionSurfaceBrush _videoBrush;

// MediaPlayer set up with a create from URI

_mediaPlayer = new MediaPlayer();

// Get a source from a URI. This could also be from a file via a picker or a stream
var source = MediaSource.CreateFromUri(new Uri("https://go.microsoft.com/fwlink/?LinkID=809007&clcid=0x409"));
var item = new MediaPlaybackItem(source);
_mediaPlayer.Source = item;
_mediaPlayer.IsLoopingEnabled = true;

// Get the surface from MediaPlayer and put it on a brush
_videoSurface = _mediaPlayer.GetSurface(_compositor);
_videoBrush = _compositor.CreateSurfaceBrush(_videoSurface.CompositionSurface);

_videoVisual = _compositor.CreateSpriteVisual();
_videoVisual.Brush = _videoBrush;
_videoVisual.Size = new Vector2(156, 156);
```

### <a name="paint-with-a-filter-effect"></a>フィルター エフェクトによる塗りつぶし

[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) は、CompositionEffect の出力で領域を塗りつぶします。 ビジュアル レイヤーの効果は、色、グラデーション、画像、ビデオ、スワップ チェーン、UI の領域、ビジュアル ツリーなどのソース コンテンツのコレクションに適用された、アニメーション化可能なフィルター エフェクトと考えることができます。 ソース コンテンツは通常、別の CompositionBrush を使用して指定されます。

次の図とコードは、彩度を下げるフィルター エフェクトを適用した猫の画像で塗りつぶされた SpriteVisual を示しています。

![CompositionEffectBrush](images/composition-cat-desaturated.png)

```cs
Compositor _compositor;
SpriteVisual _effectVisual;
CompositionEffectBrush _effectBrush;

_compositor = Window.Current.Compositor;

var graphicsEffect = new SaturationEffect {
                              Saturation = 0.0f,
                              Source = new CompositionEffectSourceParameter("mySource")
                         };

var effectFactory = _compositor.CreateEffectFactory(graphicsEffect);
_effectBrush = effectFactory.CreateBrush();

CompositionSurfaceBrush surfaceBrush =_compositor.CreateSurfaceBrush();
LoadedImageSurface loadedSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/cat.jpg"));
SurfaceBrush.surface = loadedSurface;

_effectBrush.SetSourceParameter("mySource", surfaceBrush);

_effectVisual = _compositor.CreateSpriteVisual();
_effectVisual.Brush = _effectBrush;
_effectVisual.Size = new Vector2(156, 156);
```

CompositionBrushes を使用したエフェクトの作成の詳細については、[ビジュアル レイヤーでの効果に関するトピック](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)をご覧ください。

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a>不透明度マスクを適用した CompositionBrush による塗りつぶし

[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush) は、不透明度マスクが適用された CompositionBrush で領域を塗りつぶします。 不透明度マスクのソースには、CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、CompositionNineGridBrush の任意の種類の CompositionBrush を指定できます。 不透明度マスクは、CompositionSurfaceBrush として指定する必要があります。

次の図とコードは、CompositionMaskBrush で塗りつぶされた SpriteVisual を示しています。 マスクのソースは、マスクとして円の画像を使用して、円形にマスクされた CompositionLinearGradientBrush です。

![CompositionMaskBrush](images/composition-compositionmaskbrush.png)

```cs
Compositor _compositor;
SpriteVisual _maskVisual;
CompositionMaskBrush _maskBrush;

_compositor = Window.Current.Compositor;

_maskBrush = _compositor.CreateMaskBrush();

CompositionLinearGradientBrush _sourceGradient = _compositor.CreateLinearGradientBrush();
_sourceGradient.ColorStops.Add(_compositor.CreateColorGradientStop(0,Colors.Red));
_sourceGradient.ColorStops.Add(_compositor.CreateColorGradientStop(1,Colors.Yellow));
_maskBrush.Source = _sourceGradient;

LoadedImageSurface loadedSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/circle.png"), new Size(156.0, 156.0));
_maskBrush.Mask = _compositor.CreateSurfaceBrush(loadedSurface);

_maskVisual = _compositor.CreateSpriteVisual();
_maskVisual.Brush = _maskBrush;
_maskVisual.Size = new Vector2(156, 156);
```

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a>NineGrid ストレッチを使った CompositionBrush による塗りつぶし

[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) は、9 グリッド形式で拡大された CompositionBrush で領域を塗りつぶします。 9 グリッド形式によって、CompositionBrush の端と隅を中央とは別に伸縮できます。 9 グリッド ストレッチのソースには、CompositionColorBrush、CompositionSurfaceBrush、CompositionEffectBrush の任意の種類の CompositionBrush を指定できます。

次の図とコードは、CompositionNineGridBrush で塗りつぶされた SpriteVisual を示しています。 マスクのソースは、9 グリッドを使用して伸縮された CompositionSurfaceBrush です。

```cs
Compositor _compositor;
SpriteVisual _nineGridVisual;
CompositionNineGridBrush _nineGridBrush;

_compositor = Window.Current.Compositor;

_ninegridBrush = _compositor.CreateNineGridBrush();

// nineGridImage.png is 50x50 pixels; nine-grid insets, as measured relative to the actual size of the image, are: left = 1, top = 5, right = 10, bottom = 20 (in pixels)

LoadedImageSurface _imageSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/nineGridImage.png"));
_nineGridBrush.Source = _compositor.CreateSurfaceBrush(_imageSurface);

// set Nine-Grid Insets

_ninegridBrush.SetInsets(1, 5, 10, 20);

// set appropriate Stretch on SurfaceBrush for Center of Nine-Grid

sourceBrush.Stretch = CompositionStretch.Fill;

_nineGridVisual = _compositor.CreateSpriteVisual();
_nineGridVisual.Brush = _ninegridBrush;
_nineGridVisual.Size = new Vector2(100, 75);
```

### <a name="paint-using-background-pixels"></a>背景のピクセルを使った塗りつぶし

[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush) は、領域の背景のコンテンツを使用して領域を塗りつぶします。 CompositionBackdropBrush はそれだけでは使用されませんが、代わりに、EffectBrush などの別の CompositionBrush への入力として使用されます。 たとえば、ぼかし効果への入力として CompositionBackdropBrush を使用することで、すりガラス効果を実現できます。

次のコードは、CompositionSurfaceBrush と画像の上のすりガラスのオーバーレイを使用して画像を作成するための小さなビジュアル ツリーを示しています。 すりガラスのオーバーレイは、画像の上に EffectBrush で塗りつぶされた SpriteVisual を配置することによって作成されます。 この EffectBrush は、ぼかし効果への入力として CompositionBackdropBrush を使用します。

```cs
Compositor _compositor;
SpriteVisual _containerVisual;
SpriteVisual _imageVisual;
SpriteVisual _backdropVisual;

_compositor = Window.Current.Compositor;

// Create container visual to host the visual tree
_containerVisual = _compositor.CreateContainerVisual();

// Create _imageVisual and add it to the bottom of the container visual.
// Paint the visual with an image.

CompositionSurfaceBrush _licoriceBrush = _compositor.CreateSurfaceBrush();

LoadedImageSurface loadedSurface = 
    LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/licorice.jpg"));
_licoriceBrush.Surface = loadedSurface;

_imageVisual = _compositor.CreateSpriteVisual();
_imageVisual.Brush = _licoriceBrush;
_imageVisual.Size = new Vector2(156, 156);
_imageVisual.Offset = new Vector3(0, 0, 0);
_containerVisual.Children.InsertAtBottom(_imageVisual)

// Create a SpriteVisual and add it to the top of the containerVisual.
// Paint the visual with an EffectBrush that applies blur to the content
// underneath the Visual to create a frosted glass effect.

GaussianBlurEffect blurEffect = new GaussianBlurEffect(){
                                    Name = "Blur",
                                    BlurAmount = 1.0f,
                                    BorderMode = EffectBorderMode.Hard,
                                    Source = new CompositionEffectSourceParameter("source");
                                    };

CompositionEffectFactory blurEffectFactory = _compositor.CreateEffectFactory(blurEffect);
CompositionEffectBrush _backdropBrush = blurEffectFactory.CreateBrush();

// Create a BackdropBrush and bind it to the EffectSourceParameter source

_backdropBrush.SetSourceParameter("source", _compositor.CreateBackdropBrush());
_backdropVisual = _compositor.CreateSpriteVisual();
_backdropVisual.Brush = _licoriceBrush;
_backdropVisual.Size = new Vector2(78, 78);
_backdropVisual.Offset = new Vector3(39, 39, 0);
_containerVisual.Children.InsertAtTop(_backdropVisual);
```

## <a name="combining-compositionbrushes"></a>CompositionBrush の組み合わせ
多くの CompositionBrush が入力として他の CompositionBrush を使用します。 たとえば、SetSourceParameter メソッドを使用して、CompositionEffectBrush への入力として別 CompositionBrush を設定できます。 次の表では、サポートされている CompositionBrush の組み合わせについて説明します。 サポートされていない組み合わせを使用すると例外がスローされることに注意してください。

<table>
<tbody>
<tr>
<th>ブラシ</th>
<th>EffectBrush.SetSourceParameter()</th>
<th>MaskBrush.Mask</th>
<th>MaskBrush.Source</th>
<th>NineGridBrush.Source</th>
</tr>
<tr>
<td>CompositionColorBrush</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用可能</td>
</tr>
<tr>
<td>CompositionLinear<br />GradientBrush</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用不可</td>
</tr>
<tr>
<td>CompositionSurfaceBrush</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用可能</td>
</tr>
<tr>
<td>CompositionEffectBrush</td>
<td>使用不可</td>
<td>使用不可</td>
<td>使用可能</td>
<td>使用不可</td>
</tr>
<tr>
<td>CompositionMaskBrush</td>
<td>使用不可</td>
<td>使用不可</td>
<td>使用不可</td>
<td>使用不可</td>
</tr>
<tr>
<td>CompositionNineGridBrush</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用不可</td>
</tr>
<tr>
<td>CompositionBackdropBrush</td>
<td>使用可能</td>
<td>使用不可</td>
<td>使用不可</td>
<td>使用不可</td>
</tr>
</tbody>
</table>


## <a name="using-a-xaml-brush-vs-compositionbrush"></a>XAML のブラシ vs を使用します。CompositionBrush

次の表に、シナリオと、アプリケーションで UIElement や SpriteVisual を塗りつぶすときに XAML ブラシまたはコンポジション ブラシを使用できるかどうかの一覧を示します。 

> [!NOTE]
> CompositionBrush が XAML UIElement 用に推奨されている場合、CompositionBrush は XamlCompositionBrushBase を使用してパッケージ化されている見なされます。

|シナリオ                                                                   | XAML UIElement                                                                                                |コンポジションの SpriteVisual
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|単色で領域を塗りつぶす                                             |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|アニメーション化された色で領域を塗りつぶす                                          |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|静的なグラデーションで領域を塗りつぶす                                       |[LinearGradientBrush](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|アニメーション化されたグラデーション ストップで領域を塗りつぶす                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|画像で領域を塗りつぶす                                                |[ImageBrush](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|Web ページで領域を塗りつぶす                                               |[WebViewBrush](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |なし
|NineGrid ストレッチを使った画像で領域を塗りつぶす                         |[イメージ コントロール](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|アニメーション化された NineGrid ストレッチを使って領域を塗りつぶす                               |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|スワップ チェーンで領域を塗りつぶす                                             |[SwapChainPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (スワップ チェーンの相互運用機能を使用)
|ビデオで領域を塗りつぶす                                                 |[MediaElement](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (メディア相互運用機能を使用)
|カスタム 2D 描画を使用して領域を塗りつぶす                                       |[CanvasControl](https://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm) (Win2D より)                                                                                                 |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (Win2D 相互運用機能を使用)
|アニメーション化されていないマスクで領域を塗りつぶす                                       |XAML の[図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用してマスクを定義   |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|アニメーション化されたマスクで領域を塗りつぶす                                        |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|アニメーション化されたフィルター エフェクトで領域を塗りつぶす                               |[同様](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[同様](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|背景のピクセルに適用された効果で領域を塗りつぶす        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a>関連トピック

[コンポジション ネイティブ DirectX と Direct2D との相互運用 begindraw メソッドと EndDraw](composition-native-interop.md)

[XamlCompositionBrushBase と XAML ブラシの相互運用](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
