---
author: jwmsft
ms.assetid: 03dd256f-78c0-e1b1-3d9f-7b3afab29b2f
title: コンポジションのブラシ
description: ブラシは、その出力で Visual の領域を塗りつぶします。 さまざまなブラシで、出力の種類もさまざまです。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 103ecd24c35d75d3ea1d305d7294048dc628d2e2
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1038572"
---
# <a name="composition-brushes"></a>コンポジションのブラシ
UWP アプリケーションから、画面上に表示されているすべてのアイテムは、ブラシによって描画されているために表示されます。 ブラシを使用すると、画像または複雑な効果のチェーンに図面に単純な純色のようなコンテンツをユーザー インターフェイス (UI) のオブジェクトを描くことができます。 このトピックでは、CompositionBrush と描画の概念を紹介します。

メモ、XAML UWP アプリを使用する場合に、UIElement [XAML ブラシ](/windows/uwp/design/style/brushes)または[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)を描画する] を選択することができます。 通常、簡単かつ XAML ブラシで自分のシナリオがサポートされている場合は、XAML ブラシを選択することをお勧めです。 たとえば、テキストまたは画像を含む図形の塗りつぶしの変更] ボタンの色のアニメーション化します。 その一方で、定型アニメーションまたはアニメーションの 9 グリッド ストレッチ、効果のチェーンに描画などのような XAML ブラシでサポートされていないことを実行しようとしている場合、CompositionBrush に使える[を使用して、UIElement を描くXamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)します。

視覚的なレイヤーを使用する場合の[SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual)の領域を描画する、CompositionBrush を使用する必要があります。

-   [前提条件](./composition-brushes.md#prerequisites)
-   [CompositionBrush での塗りつぶし](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [均一な色で塗りつぶす](./composition-brushes.md#paint-with-a-solid-color)
    -   [線形グラデーションで描画します。](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [画像で描画します。](./composition-brushes.md#paint-with-an-image)
    -   [ユーザー設定の図面で描画します。](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [ビデオで描画します。](./composition-brushes.md#paint-with-a-video)
    -   [フィルターの効果で描画します。](./composition-brushes.md#paint-with-a-filter-effect)
    -   [CompositionBrush 不透明マスクを描画します。](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [[引き伸ばし] NineGrid を使用して CompositionBrush で描画します。](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [背景のピクセルを使用してペイントします。](./composition-brushes.md#paint-using-background-pixels)
-   [CompositionBrushes を組み合わせる](./composition-brushes.md#combining-compositionbrushes)
-   [XAML ブラシと CompositionBrush を使用します。](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [関連トピック](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a>前提条件
ここで熟知している、基本的な構成アプリケーションの構造を[視覚的なレイヤーの概要](visual-layer.md)で説明するようにします。

## <a name="paint-with-a-compositionbrush"></a>ペイントを CompositionBrush

の[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) 「描画」領域を出力します。 さまざまなブラシで、出力の種類もさまざまです。 塗りつぶしの色、グラデーション、イメージ、カスタムの描画または効果を持つその他の領域を塗りつぶすブラシします。 その他のブラシの動作を変更する、特殊なブラシがあります。 たとえば、のどの領域が、CompositionBrush、して描画を制御する利用される不透明マスクか、領域を描画するときに、CompositionBrush に適用された拡大を制御する 9 グリッドを使用することができます。 CompositionBrush は、次の種類のいずれかの指定できます。

|クラス                                   |詳細                                         |を導入|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |均一な色を使用して領域を描画します。                        |Windows 10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |領域を[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)の内容を塗りつぶします|Windows 10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |構成の効果の内容がある領域を描画します。 |Windows 10 年 11 月の更新プログラム (SDK 10586)|
|[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |不透明マスクと、CompositionBrush で視覚的に描画します。 |Windows 10 の記念日の更新プログラム (SDK 14393)
|[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |NineGrid の引き伸ばし] を使用して CompositionBrush の領域を描画します。 |Windows 10 の記念日更新 SDK (14393)
|[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|線形グラデーションを使用して領域を描画します。                    |Windows 10 の分類の作成者の更新プログラム (内部の SDK プレビュー版)
|[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |サンプルのいずれかのアプリケーションからの背景ピクセルまたはデスクトップ アプリケーションのウィンドウの背後にあるピクセルして領域を描画します。 CompositionEffectBrush などの別の CompositionBrush への入力として使用します。 | Windows 10 の記念日の更新プログラム (SDK 14393)

### <a name="paint-with-a-solid-color"></a>均一な色で塗りつぶす

の[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)単色を使用して領域を描画します。 さまざまなを SolidColorBrush の色を指定する方法があります。 たとえば、アルファ、赤、青、および緑 (ARGB) チャンネルを指定したり、[色](https://docs.microsoft.com/uwp/api/windows.ui.colors)のクラスによって提供される、事前に定義された色のいずれかを使用できます。

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

の[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)線形グラデーションを使用して領域を描画します。 線形グラデーションは、線、グラデーションの軸の 2 つ以上の色をブレンドします。 グラデーションとその位置に色を指定するのには、GradientStop オブジェクトを使用します。

次の図とコードは、赤、黄色の色を使用して 2 つの位置に、によってでペイント SpriteVisual を示しています。

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

### <a name="paint-with-an-image"></a>画像で描画します。

の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)を ICompositionSurface 上に表示するピクセルを使用して領域を描画します。 たとえば、 [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API を使用して、ICompositionSurface 画面に表示される画像の領域を塗りつぶす、CompositionSurfaceBrush を使用できます。

次の図とコード LoadedImageSurface を使用して、ICompositionSurface 上に表示される licorice のビットマップ、SpriteVisual の描画を示しています。 拡大して、ビットマップ ビジュアルの境界内に揃えるには、CompositionSurfaceBrush のプロパティを使用できます。

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

### <a name="paint-with-a-custom-drawing"></a>ユーザー設定の図面で描画します。
の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (または D2D) を使用して描画を ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。

次のコードは、Win2D を使用して、実行、ICompositionSurface 上に表示されるテキストを含む、SpriteVisual の描画を示します。 [Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp)パッケージをプロジェクトに含める必要があります Win2D を使用するために注意します。

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

同様に、CompositionSurfaceBrush は、SpriteVisual Win2D の相互運用性を使用して SwapChain での描画にも使用できます。 [この例](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を使用して、swapchain と、SpriteVisual を描画する方法の例を示します。

### <a name="paint-with-a-video"></a>ビデオで描画します。
の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer)クラスで読み込まれているビデオを使用して描画を ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。

次のコードを ICompositionSurface に読み込まれているビデオを使用して、SpriteVisual の描画を示します。

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

### <a name="paint-with-a-filter-effect"></a>フィルターの効果で描画します。

の[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)を CompositionEffect の出力がある領域を描画します。 レイヤーを視覚的な効果は、色、グラデーション、画像、ビデオ、swapchains、自分のユーザー インターフェイスの領域またはビジュアルのツリーなどのソースのコンテンツのコレクションに適用されたフィルターのアニメーション効果と考えることがあります。 別の CompositionBrush を使用して、ソースのコンテンツが通常指定します。

次の図とコードの彩度を下げて光沢フィルターの効果が適用されている猫の画像で塗りつぶさ SpriteVisual を示しています。

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

CompositionBrushes を使用して、効果を作成する方法については、[視覚的なレイヤーの効果](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)を参照してください。

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a>不透明マスクが適用された、CompositionBrush で描画します。

[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)を対象となる不透明マスクで、CompositionBrush がある領域を描画します。 不透明マスクのソース タイプ CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、または CompositionNineGridBrush の任意の CompositionBrush ができます。 不透明マスクを CompositionSurfaceBrush として指定する必要があります。

次の図とコードを CompositionMaskBrush でペイント SpriteVisual を示しています。 マスクのソースとは、円の画像を使用して、マスクとして円のようにマスクされる CompositionLinearGradientBrush です。

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

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a>[引き伸ばし] NineGrid を使用して CompositionBrush で描画します。

の[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) 9 グリッド メタファを使用して拡大する CompositionBrush がある領域を描画します。 9 グリッド メタファを使用するより、中央、CompositionBrush の端および角を異なる拡大できます。 [引き伸ばし] 9 グリッドの任意の種類 CompositionColorBrush CompositionBrush、CompositionSurfaceBrush、または CompositionEffectBrush ことができます。

次のコードは、SpriteVisual が、CompositionNineGridBrush でペイントが表示されます。 マスクのソースを CompositionSurfaceBrush 9 グリッドを使用して拡大するには

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

の[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)領域の背後にコンテンツがある領域を描画します。 CompositionBackdropBrush では、自身で使用されていませんが、代わりに、EffectBrush などの別の CompositionBrush への入力として使用します。 たとえば、ぼかし効果への入力として CompositionBackdropBrush を使用すると、すりガラスの効果を実現できます。

CompositionSurfaceBrush と画像の上にあるすりガラス オーバーレイを使用してイメージを作成する場合は、小さな視覚的なツリーを次に示します。 画像の上、EffectBrush で塗りつぶさ SpriteVisual を配置することによってすりガラスのオーバーレイが作成されます。 [EffectBrush ぼかし効果への入力として、CompositionBackdropBrush を使用します。

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
CompositionBrushes の数値では、入力としてその他の CompositionBrushes を使用します。 たとえば、CompositionEffectBrush への入力として別の CompositionBrush を設定するには、SetSourceParameter メソッドを使用してを使用できます。 次の表は、サポートされている CompositionBrushes の組み合わせを示します。 なお、サポートされていない組み合わせ例外が発生します。

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


## <a name="using-a-xaml-brush-vs-compositionbrush"></a>XAML ブラシと CompositionBrush を使用します。

次の表は、シナリオと、UIElement またはアプリケーションで、SpriteVisual を描画するときに XAML または合成ブラシの使用を指定するかどうかの一覧を示します。 

> [!NOTE]
> CompositionBrush が XAML の UIElement に表示されている場合、XamlCompositionBrushBase を使用して、CompositionBrush をパッケージ化すると見なされます。

|シナリオ                                                                   | XAML UIElement                                                                                                |合成 SpriteVisual
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|単色で領域を塗りつぶす                                             |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|色のアニメーション効果のある領域を塗りつぶす                                          |[SolidColorBrush](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[CompositionColorBrush](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|静的なグラデーションを使用して領域を塗りつぶす                                       |[LinearGradientBrush](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|アニメーション効果のあるグラデーションの分岐点がある領域を塗りつぶす                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|画像の領域を塗りつぶす                                                |[ImageBrush](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|Web ページの領域を塗りつぶす                                               |[WebViewBrush](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |該当なし
|[引き伸ばし] NineGrid を使用してイメージで領域を描画します。                         |[イメージ コントロール](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|アニメーション効果のある NineGrid ストレッチで領域を塗りつぶす                               |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|領域を swapchain を塗りつぶす                                             |[SwapChainPanel](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) swapchain の相互運用性と
|ビデオを使用して領域を塗りつぶす                                                 |[MediaElement](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |メディアの相互運用性と[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|ユーザー設定の 2D 図面で領域を塗りつぶす                                       |Win2D から[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm)                                                                                                 |[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) Win2D の相互運用性と
|アニメーション化されていないマスクで領域を塗りつぶす                                       |XAML[図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用して、マスクの定義   |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|アニメーション効果のある定型で領域を塗りつぶす                                        |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|フィルターのアニメーション効果が適用された領域を塗りつぶす                               |[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|背景のピクセルに適用されている効果が適用された領域を塗りつぶす        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a>関連トピック

[合成ネイティブ DirectX と Direct2D 相互運用性 BeginDraw と EndDraw](composition-native-interop.md)

[XamlCompositionBrushBase で XAML ブラシの相互運用性](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
