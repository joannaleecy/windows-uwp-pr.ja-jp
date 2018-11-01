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
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919789"
---
# <a name="composition-brushes"></a>コンポジションのブラシ
UWP のアプリケーションから、画面に表示できるものは、ブラシによって描画されているために表示されます。 ブラシを使用すると、単純な純色からイメージや複雑なエフェクト チェーンへの描画に至るまでのコンテンツでユーザー インターフェイス (UI) オブジェクトを描画します。 このトピックでは、CompositionBrush を使用してペイントの概念を説明します。

注意してください、XAML UWP のアプリケーションを操作するときの[XAML ブラシ](/windows/uwp/design/style/brushes)または、 [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)に、UIElement を描画するを選択することができます。 通常、簡単であり、XAML ブラシで、シナリオがサポートされている場合、XAML のブラシを選択することをお勧めです。 たとえば、テキストまたはイメージを持つ図形の塗りつぶしの変更、ボタンの色をアニメーション化します。 その一方で場合は、アニメーション化されたマスクやアニメーションの 9 グリッド ストレッチ、エフェクト チェーンを使用してペイントなどの XAML ブラシでサポートされていない処理を実行しようとすることができますを使用する、CompositionBrush[を使用して、UIElement をペイントするにはXamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)。

ビジュアル層を使用する場合、 [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual)の領域を描画するのには、CompositionBrush を使用しなければなりません。

-   [前提条件](./composition-brushes.md#prerequisites)
-   [CompositionBrush での塗りつぶし](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [純色で描画します。](./composition-brushes.md#paint-with-a-solid-color)
    -   [線形グラデーションで描画します。](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [イメージで描画します。](./composition-brushes.md#paint-with-an-image)
    -   [カスタム図面で描画します。](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [ビデオで描画します。](./composition-brushes.md#paint-with-a-video)
    -   [フィルター効果で描画します。](./composition-brushes.md#paint-with-a-filter-effect)
    -   [不透明マスクで、CompositionBrush で描画します。](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [NineGrid ストレッチを使用して、CompositionBrush で描画します。](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [背景のピクセルを使用してペイントします。](./composition-brushes.md#paint-using-background-pixels)
-   [CompositionBrushes を組み合わせること。](./composition-brushes.md#combining-compositionbrushes)
-   [XAML ブラシと CompositionBrush を使用してください。](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [関連トピック](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a>前提条件
この概要では、熟知している、基本的な構成アプリケーションの構造を[ビジュアル層の概要](visual-layer.md)で説明したように想定しています。

## <a name="paint-with-a-compositionbrush"></a>CompositionBrush での塗りつぶし

[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) 「描画」の出力を使用して領域。 さまざまなブラシで、出力の種類もさまざまです。 純色、グラデーション、イメージ、カスタムの描画、または効果を持つ他のユーザーを使用して領域を塗りつぶすブラシ。 その他のブラシの動作を変更する専用のブラシが用意されています。 によって、CompositionBrush では、描画領域を制御する不透明度マスクを使用することができますなど、領域を塗りつぶすときに、CompositionBrush に適用するストレッチを制御する 9 グリッドを使用することができます。 CompositionBrush は、次の種類のいずれかのできます。

|クラス                                   |詳細                                         |導入されました。|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |純色で領域を塗りつぶします                        |Windows10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)の内容を使用して領域を描画します。|Windows10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |合成効果の内容を使用して領域を描画します。 |Windows10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |不透明マスクで、CompositionBrush のビジュアルを描画します。 |Windows10 記念日の更新プログラム (SDK 14393)
|[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |NineGrid ストレッチを使用して、CompositionBrush の領域を塗りつぶします |Windows10 記念更新 SDK (14393)
|[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|線形グラデーションで領域を塗りつぶします                    |Windows 10 作成者の更新プログラム (内部関係者によるプレビュー SDK) の分類
|[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |背景のピクセルのいずれかのアプリケーションまたはデスクトップ上のアプリケーションのウィンドウの背後にあるピクセルをサンプリングして領域を塗りつぶします。 CompositionEffectBrush のような他の CompositionBrush への入力として使用 | Windows 10 記念日の更新プログラム (SDK 14393)

### <a name="paint-with-a-solid-color"></a>純色で描画します。

の[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)では、純色で領域を塗りつぶします。 さまざまな、SolidColorBrush の色を指定する方法があります。 など、アルファ、赤、青、および緑 (ARGB) のチャネルを指定したり、[色](https://docs.microsoft.com/uwp/api/windows.ui.colors)クラスによって提供される定義済みの色のいずれかを使用できます。

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

### <a name="paint-with-a-linear-gradient"></a>線形グラデーションで描画します。

の[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)では、線形グラデーションで領域を塗りつぶします。 線形グラデーションは、グラデーション軸の行の間で 2 つ以上の色をブレンドします。 GradientStop オブジェクトを使用するにはグラデーションとその位置の色を指定します。

次の図とコードは、赤と黄色の色を使用して 2 つの停止と、なりますと描画の SpriteVisual を示しています。

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

[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) ICompositionSurface の上にレンダリングされるピクセルで領域を塗りつぶします。 たとえば、 [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API を使用して、ICompositionSurface 画面にレンダリングされたイメージで領域を塗りつぶすには CompositionSurfaceBrush を使用できます。

次の図とコードは、SpriteVisual が LoadedImageSurface を使用して、ICompositionSurface 上に表示される、licorice のビットマップを描画を示します。 拡大し、ビジュアルの境界内のビットマップを配置するのには、CompositionSurfaceBrush のプロパティを使用できます。

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

### <a name="paint-with-a-custom-drawing"></a>カスタム図面で描画します。
[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) ICompositionSurface [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (D2D) を使用してレンダリングされるピクセルで領域を塗りつぶすにも使用できます。

次のコードは、Win2D を使用して、SpriteVisual は、ICompositionSurface 上にレンダリングされたテキストの描画を示します。 [Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp)パッケージをプロジェクトに挿入する必要があります Win2D を使用するためにメモします。

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

同様に、CompositionSurfaceBrush は、SpriteVisual と Win2D の相互運用機能を使用しての SwapChain の描画にも使用できます。 [このサンプル](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を SpriteVisual、swapchain での描画に使用する方法の例を提供します。

### <a name="paint-with-a-video"></a>ビデオで描画します。
の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)は、 [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer)クラスによって読み込まれたビデオを使用してレンダリング、ICompositionSurface からのピクセル単位で領域を塗りつぶすにも使用できます。

次のコードは、SpriteVisual は、ICompositionSurface にロードされているビデオを使用して描画を示しています。

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

[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) CompositionEffect の出力を使用して領域を描画します。 ビジュアル層でのエフェクトは、アニメーション化可能なフィルター効果の色、グラデーション、イメージ、ビデオ、swapchains、UI の領域またはビジュアルの木などのソースのコンテンツのコレクションに適用されると考えることがあります。 ソースのコンテンツを別の CompositionBrush を使用して提供します。

次の図とコードは、彩度を下げて光沢フィルター効果のある猫のイメージでペイントの SpriteVisual を示しています。

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

CompositionBrushes を使用してエフェクトを作成する方法の詳細については、[ビジュアル層でのエフェクト](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)を参照してください。

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a>不透明度マスクが適用された、CompositionBrush で描画します。

の[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)では、不透明マスクが適用されていると、CompositionBrush を使用して領域を描画します。 不透明度マスクの元のタイプ CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、または CompositionNineGridBrush、CompositionBrush ができます。 CompositionSurfaceBrush として、不透明度マスクを指定してください。

次の図とコードは、SpriteVisual、CompositionMaskBrush で描画を示しています。 マスクのソースは、円のイメージをマスクとして使用する円のようにマスクされている CompositionLinearGradientBrush です。

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

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a>NineGrid ストレッチを使用して、CompositionBrush で描画します。

の[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)は、9 グリッドのメタファを使用して伸縮する CompositionBrush を使用して領域を描画します。 9 グリッドのメタファを使用すると、中心よりも、CompositionBrush の端および角を異なる方法で拡大できます。 9 グリッド ストレッチのソースは、任意のタイプ CompositionColorBrush の CompositionBrush、CompositionSurfaceBrush、または CompositionEffectBrush でことができます。

次のコードは、SpriteVisual は、CompositionNineGridBrush で描画を示しています。 マスクのソースは、9 のグリッドを使用して伸縮する CompositionSurfaceBrush です。

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

### <a name="paint-using-background-pixels"></a>背景のピクセルを使用してペイントします。

の[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)は、領域の背後にあるコンテンツで領域を塗りつぶします。 CompositionBackdropBrush を独自に使用されることはありませんが、代わりに、EffectBrush のような他の CompositionBrush への入力として使用されます。 たとえば、ぼかしの効果への入力として、CompositionBackdropBrush を使用して、すりガラス効果を実現できます。

次のコードは、CompositionSurfaceBrush と画像の上のすりガラスのオーバーレイを使用してイメージを作成する小規模のビジュアル ツリーを示しています。 すりガラスのオーバーレイは、画像の上に EffectBrush を入力する SpriteVisual を配置することによって作成されます。 EffectBrush では、ぼかしの効果への入力として、CompositionBackdropBrush を使用します。

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

## <a name="combining-compositionbrushes"></a>CompositionBrushes を組み合わせること。
CompositionBrushes の数値は、入力として他の CompositionBrushes を使用します。 など、CompositionEffectBrush への入力として、別の CompositionBrush を設定するには、SetSourceParameter メソッドを使用するを使用できます。 CompositionBrushes のサポートされている組み合わせを次の表に示します。 サポートされていない組み合わせを使用すると例外がスローされることに注意してください。

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


## <a name="using-a-xaml-brush-vs-compositionbrush"></a>XAML ブラシと CompositionBrush を使用してください。

次の表は、シナリオと、UIElement またはアプリケーションで、SpriteVisual を描画するときに XAML またはコンポジションのブラシの使用を規定するかどうかの一覧を示します。 

> [!NOTE]
> XAML UIElement の提案は、CompositionBrush、XamlCompositionBrushBase を使用して、CompositionBrush がパッケージされていると見なされます。

|シナリオ                                                                   | XAML UIElement                                                                                                |コンポジション SpriteVisual
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|純色で領域を塗りつぶす                                             |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|アニメーションの色で領域を塗りつぶす                                          |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|静的なグラデーションで領域を塗りつぶす                                       |[LinearGradientBrush](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|アニメーションのグラデーションで領域を塗りつぶす                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|イメージで領域を塗りつぶす                                                |[ImageBrush](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|Web ページで領域を塗りつぶす                                               |[WebViewBrush](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |該当なし
|NineGrid ストレッチを使用してイメージで領域を描画します。                         |[イメージ コントロール](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|アニメーションの NineGrid ストレッチで領域を塗りつぶす                               |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|Swapchain で領域を塗りつぶす                                             |[SwapChainPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |Swapchain の相互運用機能付き[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|ビデオで領域を塗りつぶす                                                 |[MediaElement](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |メディアの相互運用機能付き[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|カスタムの 2 D 図面で領域を塗りつぶす                                       |Win2D から[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm)                                                                                                 |Win2D の相互運用機能付き[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|マスクをアニメーション化されていない領域を塗りつぶす                                       |マスクを定義する XAML の[図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用します。   |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|アニメーション化されたマスクを使用して領域を塗りつぶす. します。                                        |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|フィルターのアニメーション効果が適用された領域を塗りつぶす                               |[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|背景のピクセルに適用される効果で領域を描画します。        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a>関連トピック

[コンポジション ネイティブ DirectX および Direct2D との相互運用 BeginDraw と EndDraw](composition-native-interop.md)

[XAML ブラシ XamlCompositionBrushBase との相互運用機能](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
