---
author: jwmsft
ms.assetid: 03dd256f-78c0-e1b1-3d9f-7b3afab29b2f
title: コンポジションのブラシ
description: ブラシは、その出力で Visual の領域を塗りつぶします。 さまざまなブラシで、出力の種類もさまざまです。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 730d5ae9062fe39533cd615facaf5beaa7d02ffd
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6995106"
---
# <a name="composition-brushes"></a>コンポジションのブラシ
ブラシによって描画されているために、すべての UWP アプリケーションから、画面に表示されることが表示されます。 ブラシを使用すると、シンプルで単色の色から画像や複雑な効果のチェーンに描画に至るまでコンテンツを持つユーザー インターフェイス (UI) オブジェクトを使ってペイントできます。 このトピックでは、CompositionBrush と描画の概念を紹介します。

注意してください XAML UWP アプリでは、操作するとき、 [XAML ブラシ](/windows/uwp/design/style/brushes)や[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)UIElement をペイントする選択を実行できます。 通常より簡単かつ XAML ブラシで自分のシナリオがサポートされている場合は、XAML ブラシを選択することをお勧めです。 たとえば、テキストまたは画像を持つ図形の塗りつぶしの変更、ボタンの色をアニメーション化します。 その一方で、アニメーションのマスクやアニメーションの 9 グリッド stretch またはエフェクト チェーンを使ってペイントなどの XAML ブラシでサポートされていない処理を実行しようとしている場合、CompositionBrush に使える[を使用して UIElement を塗りつぶすXamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)します。

ビジュアル レイヤーを使用する場合、CompositionBrush は[SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual)の領域を塗りつぶすために使用する必要があります。

-   [前提条件](./composition-brushes.md#prerequisites)
-   [CompositionBrush での塗りつぶし](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [単色で塗りつぶす](./composition-brushes.md#paint-with-a-solid-color)
    -   [線状グラデーションで描画します。](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [イメージで描画します。](./composition-brushes.md#paint-with-an-image)
    -   [カスタム描画で描画します。](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [ビデオで描画します。](./composition-brushes.md#paint-with-a-video)
    -   [フィルター効果で描画します。](./composition-brushes.md#paint-with-a-filter-effect)
    -   [不透明度マスクを使用 CompositionBrush で描画します。](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [NineGrid stretch を使用して CompositionBrush で描画します。](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [バック グラウンドのピクセルを使用してペイント](./composition-brushes.md#paint-using-background-pixels)
-   [CompositionBrushes を組み合わせる](./composition-brushes.md#combining-compositionbrushes)
-   [使用する XAML ブラシと CompositionBrush](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [関連トピック](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a>前提条件
この概要では、熟知している基本的なコンポジション アプリケーションの構造と[ビジュアル レイヤーの概要](visual-layer.md)」の説明に従って前提としています。

## <a name="paint-with-a-compositionbrush"></a>CompositionBrush の塗りつぶし

[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)は、その出力で、領域を「塗りつぶします」。 さまざまなブラシで、出力の種類もさまざまです。 一部のブラシを単色でグラデーション、画像、カスタムの描画や効果を他のユーザーで領域を塗りつぶします。 その他のブラシの動作を変更する特殊なブラシが用意されています。 たとえば、コントロールによって、CompositionBrush 領域を塗りつぶすに不透明度マスクを使用または 9 グリッドは、領域をペイントする際に、CompositionBrush に適用される stretch を制御するために使用できます。 次の種類のいずれかの CompositionBrush を指定できます。

|クラス                                   |詳細                                         |導入されました。|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |領域を単色で塗りつぶします                        |Windows 10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)の内容で、領域を塗りつぶします|Windows 10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |コンポジション効果の内容で、領域を塗りつぶします |Windows 10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |不透明度マスク CompositionBrush にビジュアルを塗りつぶします |Windows 10 Anniversary Update (SDK 14393)
|[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |NineGrid stretch を使用して CompositionBrush で、領域を塗りつぶします |Windows 10 Anniversary Update SDK (14393)
|[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|線状グラデーションで領域を塗りつぶします                    |Windows 10 Fall Creators Update (Insider Preview SDK)
|[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |アプリケーションのいずれかからバック グラウンド ピクセルまたはデスクトップ アプリケーションのウィンドウの背後にあるピクセルのサンプリングによって、領域を塗りつぶします。 別の CompositionBrush、CompositionEffectBrush などへの入力として使われる | Windows 10 Anniversary Update (SDK 14393)

### <a name="paint-with-a-solid-color"></a>単色で塗りつぶす

[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)では、単色で領域を塗りつぶします。 さまざまな SolidColorBrush の色を指定する方法があります。 たとえば、そのアルファ、赤、青、および緑 (ARGB) のチャネルを指定したり、[色](https://docs.microsoft.com/uwp/api/windows.ui.colors)クラスによって提供される定義済みの色のいずれかを使用できます。

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

### <a name="paint-with-a-linear-gradient"></a>線状グラデーションで描画します。

[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)では、線状グラデーションで領域を塗りつぶします。 線状グラデーションでは、行、グラデーション軸間で 2 つ以上の色をブレンドします。 GradientStop オブジェクトを使用するには、グラデーションとその位置で色を指定します。

次の図とコードは、赤と黄色の色を使用して 2 つの位置を LinearGradientBrush で塗りつぶす SpriteVisual を示しています。

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

### <a name="paint-with-an-image"></a>イメージで描画します。

[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) ICompositionSurface 上にレンダリングされるピクセルで、領域を塗りつぶします。 たとえば、 [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API を使用して、ICompositionSurface サーフェス上にレンダリングされた画像で領域をペイントする、CompositionSurfaceBrush を使用できます。

次の図とコードはレンダリング先 LoadedImageSurface を使用して、ICompositionSurface licorice のビットマップが描かれて SpriteVisual を示しています。 CompositionSurfaceBrush のプロパティは、ストレッチし、整列ビジュアルの境界内でのビットマップを使用できます。

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

### <a name="paint-with-a-custom-drawing"></a>カスタム描画で描画します。
[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)は、 [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (または D2D) を使用してレンダリングする ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。

次のコードは、Win2D を使用して、SpriteVisual が描かれて実行、ICompositionSurface 上にレンダリングされたテキストを示します。 注: をプロジェクトに[Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp)パッケージを含める必要がある Win2D を使用するためにします。

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

同様に、CompositionSurfaceBrush は、Win2D の相互運用機能を使用して SwapChain に SpriteVisual を塗りつぶすにも使用できます。 [このサンプル](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を使用して、swapchain に SpriteVisual をペイントする方法の例を示します。

### <a name="paint-with-a-video"></a>ビデオで描画します。
[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)は、 [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer)クラスによって読み込まれるビデオを使用してレンダリングする ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。

次のコードは、SpriteVisual が描かれて、ICompositionSurface に読み込まれるビデオを示しています。

```cs
Compositor _compositor;
SpriteVisual _videoVisual;
CompositionSurfaceBrush _videoBrush;

// MediaPlayer set up with a create from URI

_mediaPlayer = new MediaPlayer();

// Get a source from a URI. This could also be from a file via a picker or a stream
var source = MediaSource.CreateFromUri(new Uri("http://go.microsoft.com/fwlink/?LinkID=809007&clcid=0x409"));
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

### <a name="paint-with-a-filter-effect"></a>フィルター効果で描画します。

[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)は、CompositionEffect の出力で領域を塗りつぶします。 ビジュアル レイヤーの効果は、アニメーション化可能なフィルター効果の色、グラデーション、画像、ビデオ、スワップ、UI の地域またはツリーの視覚効果などのソースのコンテンツのコレクションに適用されると考えることがあります。 ソース コンテンツは通常別 CompositionBrush を使用して指定します。

次の図とコードを持つについてフィルター効果が適用された猫の画像で塗りつぶす SpriteVisual を示しています。

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

CompositionBrushes を使用して、効果の作成について詳しくは、[ビジュアル レイヤーの効果](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)をご覧ください。

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a>不透明度マスクが適用された、CompositionBrush で描画します。

[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)は、不透明マスクを適用すると、CompositionBrush で領域を塗りつぶします。 不透明度マスクのソースが CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、または CompositionNineGridBrush の種類の任意の CompositionBrush できます。 不透明マスクは、CompositionSurfaceBrush として指定する必要があります。

次の図とコードは、CompositionMaskBrush で塗りつぶす SpriteVisual を示しています。 マスクのソースとは、円の中に、マスクとして円のイメージを使用するような外観にマスクする CompositionLinearGradientBrush です。

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

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a>NineGrid stretch を使用して CompositionBrush で描画します。

[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)は 9-グリッド形式を使用して拡大する CompositionBrush で領域を塗りつぶします。 9-グリッド形式を使用すると、その中心よりも異なりますエッジと、CompositionBrush の角に丸みを拡大できます。 9 グリッドの stretch のソースは、任意の種類の CompositionColorBrush の CompositionBrush、CompositionSurfaceBrush、または CompositionEffectBrush によってことができます。

次のコードは、SpriteVisual が描かれて、CompositionNineGridBrush を示しています。 マスクのソースとは、9 グリッドを使用して拡大する CompositionSurfaceBrush です。

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

### <a name="paint-using-background-pixels"></a>バック グラウンドのピクセルを使用してペイント

[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)は、領域の背後にあるコンテンツで領域を塗りつぶします。 CompositionBackdropBrush は、単独で使用されていませんが、代わりに、EffectBrush などの別の CompositionBrush への入力として使われます。 たとえば、ぼかし効果への入力として、CompositionBackdropBrush を使用して、すりガラス効果を実現できます。

次のコードは、CompositionSurfaceBrush とイメージ上ですりガラス オーバーレイを使用してイメージを作成する小規模なビジュアル ツリーを示しています。 すりガラス オーバーレイを作成するには、画像の上、EffectBrush 塗りつぶさ SpriteVisual を配置します。 EffectBrush、ぼかし効果への入力として、CompositionBackdropBrush を使用します。

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

## <a name="combining-compositionbrushes"></a>CompositionBrushes を組み合わせる
CompositionBrushes の数は、入力として他の CompositionBrushes を使用します。 たとえば、CompositionEffectBrush への入力として別の CompositionBrush を設定するには、SetSourceParameter メソッドを使用してを使用できます。 次の表では、サポートされている CompositionBrushes の組み合わせについて説明します。 サポートされていない組み合わせを使用すると例外がスローされることに注意してください。

<table>
<tbody>
<tr>
<th>Brush</th>
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
<td>NO</td>
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
<td>NO</td>
<td>NO</td>
<td>使用可能</td>
<td>NO</td>
</tr>
<tr>
<td>CompositionMaskBrush</td>
<td>NO</td>
<td>使用不可</td>
<td>使用不可</td>
<td>NO</td>
</tr>
<tr>
<td>CompositionNineGridBrush</td>
<td>使用可能</td>
<td>使用可能</td>
<td>使用可能</td>
<td>NO</td>
</tr>
<tr>
<td>CompositionBackdropBrush</td>
<td>使用可能</td>
<td>NO</td>
<td>使用不可</td>
<td>NO</td>
</tr>
</tbody>
</table>


## <a name="using-a-xaml-brush-vs-compositionbrush"></a>使用する XAML ブラシと CompositionBrush

次の表では、シナリオと、UIElement またはアプリケーションで SpriteVisual を描画するときに XAML またはコンポジションのブラシの使用を規定するかどうかの一覧を示します。 

> [!NOTE]
> XAML UIElement には、CompositionBrush を使用することをお勧めに XamlCompositionBrushBase を使用して、CompositionBrush がパッケージ化すると見なされます。

|シナリオ                                                                   | XAML UIElement                                                                                                |コンポジション SpriteVisual
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|領域を単色で塗りつぶす                                             |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|アニメーション化された色で領域を塗りつぶす                                          |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|静的なグラデーションで領域を塗りつぶす                                       |[LinearGradientBrush](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|アニメーション化されたグラデーションで領域を塗りつぶす                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|画像で領域を塗りつぶす                                                |[ImageBrush](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|Web ページで領域を塗りつぶす                                               |[WebViewBrush](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |該当なし
|NineGrid stretch を使用してイメージで領域を描画します。                         |[画像コントロール](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|アニメーション化された NineGrid stretch で領域を塗りつぶす                               |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|Swapchain で領域を塗りつぶす                                             |[SwapChainPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (swapchain の相互運用機能を使用)
|ビデオで領域を塗りつぶす                                                 |[MediaElement](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (メディアの相互運用機能を使用)
|カスタムの 2D 描画で領域を塗りつぶす                                       |Win2D から[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm)                                                                                                 |Win2D の相互運用機能と[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|マスクのアニメーション化で領域を塗りつぶす                                       |マスクを定義する XAML[の図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用します。   |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|アニメーションのマスクで領域を塗りつぶす                                        |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|アニメーション化されたフィルター効果で領域を塗りつぶす                               |[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|バック グラウンド ピクセルに適用される効果で領域を描画します。        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a>関連トピック

[コンポジション ネイティブ DirectX と Direct2D の相互運用機能 BeginDraw と EndDraw による](composition-native-interop.md)

[XamlCompositionBrushBase と XAML ブラシの相互運用](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
