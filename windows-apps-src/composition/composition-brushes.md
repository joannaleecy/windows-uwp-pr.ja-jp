---
ms.assetid: 03dd256f-78c0-e1b1-3d9f-7b3afab29b2f
title: コンポジションのブラシ
description: ブラシは、その出力で Visual の領域を塗りつぶします。 さまざまなブラシで、出力の種類もさまざまです。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e8c995c5a9513bea44664bcb395cd604ba2668c3
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8797119"
---
# <a name="composition-brushes"></a><span data-ttu-id="4cd95-105">コンポジションのブラシ</span><span class="sxs-lookup"><span data-stu-id="4cd95-105">Composition brushes</span></span>
<span data-ttu-id="4cd95-106">ブラシによって描画されているために、すべての UWP アプリケーションから、画面に表示されることが表示されます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-106">Everything visible on your screen from a UWP application is visible because it was painted by a Brush.</span></span> <span data-ttu-id="4cd95-107">ブラシを使用すると、シンプルで単色の色から画像や複雑な効果のチェーンに描画に至るまでコンテンツを持つユーザー インターフェイス (UI) オブジェクトを使ってペイントできます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-107">Brushes enable you to paint user interface (UI) objects with content ranging from simple, solid colors to images or drawings to complex effects chain.</span></span> <span data-ttu-id="4cd95-108">このトピックでは、CompositionBrush と描画の概念を紹介します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-108">This topic introduces the concepts of painting with CompositionBrush.</span></span>

<span data-ttu-id="4cd95-109">注意してください、XAML UWP アプリでは、操作するときを塗りつぶす[XAML ブラシ](/windows/uwp/design/style/brushes)や[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)の UIElement を選択することができます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-109">Note, when working with XAML UWP app, you can chose to paint a UIElement with a [XAML Brush](/windows/uwp/design/style/brushes) or a [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush).</span></span> <span data-ttu-id="4cd95-110">通常より簡単かつ XAML ブラシで自分のシナリオがサポートされている場合は、XAML ブラシを選択することをお勧めです。</span><span class="sxs-lookup"><span data-stu-id="4cd95-110">Typically, it is easier and advisable to choose a XAML brush if your scenario is supported by a XAML Brush.</span></span> <span data-ttu-id="4cd95-111">たとえば、テキストまたは画像を持つ図形の塗りつぶしの変更、ボタンの色をアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-111">For example, animating the color of a button, changing the fill of a text or a shape with an image.</span></span> <span data-ttu-id="4cd95-112">その一方で、アニメーションのマスクやアニメーションの 9 グリッド stretch またはエフェクト チェーンを使ってペイントなどの XAML ブラシでサポートされていない処理を実行しようとすることができますに使用する場合、CompositionBrush[を使用して、UIElement の描画XamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-112">On the other hand, if you are trying to do something that is not supported by a XAML brush like painting with an animated mask or an animated nine-grid stretch or an effect chain, you can use a CompositionBrush to paint a UIElement through the use of [XamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase).</span></span>

<span data-ttu-id="4cd95-113">ビジュアル レイヤーを使用する場合、CompositionBrush は[SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual)の領域を塗りつぶすために使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cd95-113">When working with the Visual layer, a CompositionBrush must be used to paint the area of a [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual).</span></span>

-   [<span data-ttu-id="4cd95-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="4cd95-114">Prerequisites</span></span>](./composition-brushes.md#prerequisites)
-   [<span data-ttu-id="4cd95-115">CompositionBrush での塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4cd95-115">Paint with CompositionBrush</span></span>](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [<span data-ttu-id="4cd95-116">単色で塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-116">Paint with a solid color</span></span>](./composition-brushes.md#paint-with-a-solid-color)
    -   [<span data-ttu-id="4cd95-117">線状グラデーションで描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-117">Paint with a linear gradient</span></span>](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [<span data-ttu-id="4cd95-118">イメージで描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-118">Paint with an image</span></span>](./composition-brushes.md#paint-with-an-image)
    -   [<span data-ttu-id="4cd95-119">カスタム描画で描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-119">Paint with a custom drawing</span></span>](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [<span data-ttu-id="4cd95-120">ビデオで描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-120">Paint with a video</span></span>](./composition-brushes.md#paint-with-a-video)
    -   [<span data-ttu-id="4cd95-121">フィルター効果で描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-121">Paint with a filter effect</span></span>](./composition-brushes.md#paint-with-a-filter-effect)
    -   [<span data-ttu-id="4cd95-122">CompositionBrush 不透明マスクを描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-122">Paint with a CompositionBrush with an opacity mask</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [<span data-ttu-id="4cd95-123">NineGrid stretch を使用して CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-123">Paint with a CompositionBrush using NineGrid stretch</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [<span data-ttu-id="4cd95-124">バック グラウンドのピクセルを使用してペイント</span><span class="sxs-lookup"><span data-stu-id="4cd95-124">Paint using Background Pixels</span></span>](./composition-brushes.md#paint-using-background-pixels)
-   [<span data-ttu-id="4cd95-125">CompositionBrushes を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="4cd95-125">Combining CompositionBrushes</span></span>](./composition-brushes.md#combining-compositionbrushes)
-   [<span data-ttu-id="4cd95-126">使用する XAML ブラシと CompositionBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-126">Using a XAML Brush vs. CompositionBrush</span></span>](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [<span data-ttu-id="4cd95-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4cd95-127">Related Topics</span></span>](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a><span data-ttu-id="4cd95-128">前提条件</span><span class="sxs-lookup"><span data-stu-id="4cd95-128">Prerequisites</span></span>
<span data-ttu-id="4cd95-129">この概要では、熟知している基本的なコンポジション アプリケーションの構造と[ビジュアル レイヤーの概要](visual-layer.md)」の説明に従って前提としています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-129">This overview assumes that you are familiar with the structure of a basic Composition application, as described in the [Visual layer overview](visual-layer.md).</span></span>

## <a name="paint-with-a-compositionbrush"></a><span data-ttu-id="4cd95-130">CompositionBrush の塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4cd95-130">Paint with a CompositionBrush</span></span>

<span data-ttu-id="4cd95-131">[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)は、その出力で、領域を「塗りつぶします」します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-131">A [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) "paints" an area with its output.</span></span> <span data-ttu-id="4cd95-132">さまざまなブラシで、出力の種類もさまざまです。</span><span class="sxs-lookup"><span data-stu-id="4cd95-132">Different brushes have different types of output.</span></span> <span data-ttu-id="4cd95-133">いくつかのブラシは、単色の色、グラデーション、画像、カスタムの描画や効果を他のユーザーで領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-133">Some brushes paint an area with a solid color, others with a gradient, image, custom drawing, or effect.</span></span> <span data-ttu-id="4cd95-134">その他のブラシの動作を変更する特殊なブラシが用意されています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-134">There are also specialized brushes that modify the behavior of other brushes.</span></span> <span data-ttu-id="4cd95-135">たとえば、コントロールによって、CompositionBrush には、どの領域を塗りつぶすに不透明マスクを使用できますか、9 グリッドは、領域をペイントする際に、CompositionBrush に適用される stretch を制御するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-135">For example, opacity mask can be used to control which area is painted by a CompositionBrush, or a nine-grid can be used to control the stretch applied to a CompositionBrush when painting an area.</span></span> <span data-ttu-id="4cd95-136">次の種類のいずれかの CompositionBrush を指定できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-136">CompositionBrush can be of one of the following types:</span></span>

|<span data-ttu-id="4cd95-137">クラス</span><span class="sxs-lookup"><span data-stu-id="4cd95-137">Class</span></span>                                   |<span data-ttu-id="4cd95-138">詳細</span><span class="sxs-lookup"><span data-stu-id="4cd95-138">Details</span></span>                                         |<span data-ttu-id="4cd95-139">導入されました。</span><span class="sxs-lookup"><span data-stu-id="4cd95-139">Introduced In</span></span>|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[<span data-ttu-id="4cd95-140">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-140">CompositionColorBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |<span data-ttu-id="4cd95-141">領域を単色で塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="4cd95-141">Paints an area with a solid color</span></span>                        |<span data-ttu-id="4cd95-142">Windows 10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="4cd95-142">Windows10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="4cd95-143">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-143">CompositionSurfaceBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |<span data-ttu-id="4cd95-144">[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)の内容で、領域を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="4cd95-144">Paints an area with the contents of an [ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)</span></span>|<span data-ttu-id="4cd95-145">Windows 10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="4cd95-145">Windows10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="4cd95-146">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-146">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |<span data-ttu-id="4cd95-147">コンポジション効果の内容で、領域を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="4cd95-147">Paints an area with the contents of a composition effect</span></span> |<span data-ttu-id="4cd95-148">Windows 10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="4cd95-148">Windows10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="4cd95-149">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-149">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |<span data-ttu-id="4cd95-150">不透明度マスクを使用する CompositionBrush にビジュアルを塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="4cd95-150">Paints a visual with a CompositionBrush with an opacity mask</span></span> |<span data-ttu-id="4cd95-151">Windows 10 Anniversary Update (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="4cd95-151">Windows10 Anniversary Update (SDK 14393)</span></span>
|[<span data-ttu-id="4cd95-152">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-152">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |<span data-ttu-id="4cd95-153">NineGrid stretch を使用して CompositionBrush で、領域を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="4cd95-153">Paints an area with a CompositionBrush using a NineGrid stretch</span></span> |<span data-ttu-id="4cd95-154">Windows 10 Anniversary Update SDK (14393)</span><span class="sxs-lookup"><span data-stu-id="4cd95-154">Windows10 Anniversary Update SDK (14393)</span></span>
|[<span data-ttu-id="4cd95-155">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-155">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|<span data-ttu-id="4cd95-156">線状グラデーションで領域を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="4cd95-156">Paints an area with a linear gradient</span></span>                    |<span data-ttu-id="4cd95-157">Windows 10 Fall Creators Update (Insider Preview SDK)</span><span class="sxs-lookup"><span data-stu-id="4cd95-157">Windows 10 Fall Creators Update (Insider Preview SDK)</span></span>
|[<span data-ttu-id="4cd95-158">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-158">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |<span data-ttu-id="4cd95-159">アプリケーションのいずれかからバック グラウンド ピクセルまたはデスクトップ アプリケーションのウィンドウの背後にあるピクセルのサンプリングによって、領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-159">Paints an area by sampling background pixels from either the application or pixels directly behind the application's window on desktop.</span></span> <span data-ttu-id="4cd95-160">別の CompositionBrush、CompositionEffectBrush などへの入力として使われる</span><span class="sxs-lookup"><span data-stu-id="4cd95-160">Used as an input to another CompositionBrush like a CompositionEffectBrush</span></span> | <span data-ttu-id="4cd95-161">Windows 10 Anniversary Update (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="4cd95-161">Windows 10 Anniversary Update (SDK 14393)</span></span>

### <a name="paint-with-a-solid-color"></a><span data-ttu-id="4cd95-162">単色で塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-162">Paint with a solid color</span></span>

<span data-ttu-id="4cd95-163">[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)領域を単色で塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-163">A [CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush) paints an area with a solid color.</span></span> <span data-ttu-id="4cd95-164">さまざまな SolidColorBrush の色を指定する方法があります。</span><span class="sxs-lookup"><span data-stu-id="4cd95-164">There are a variety of ways to specify the color of a SolidColorBrush.</span></span> <span data-ttu-id="4cd95-165">たとえば、そのアルファ、赤、青、および緑 (ARGB) のチャネルを指定したり、[色](https://docs.microsoft.com/uwp/api/windows.ui.colors)クラスによって提供される定義済みの色のいずれかを使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-165">For example, you can specify its alpha, red, blue, and green (ARGB) channels or use one of the predefined colors provided by the [Colors](https://docs.microsoft.com/uwp/api/windows.ui.colors) class.</span></span>

<span data-ttu-id="4cd95-166">次の図とコードは、黒の色ブラシで描かれた四角形を、色の値が 0x9ACD32 である単色ブラシで塗りつぶす小規模なビジュアル ツリーを示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-166">The following illustration and code shows a small visual tree to create a rectangle that is stroked with a black color brush and painted with a solid color brush that has the color value of 0x9ACD32.</span></span>

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

### <a name="paint-with-a-linear-gradient"></a><span data-ttu-id="4cd95-168">線状グラデーションで描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-168">Paint with a linear gradient</span></span>

<span data-ttu-id="4cd95-169">[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)では、線形グラデーションで領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-169">A [CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush) paints an area with a linear gradient.</span></span> <span data-ttu-id="4cd95-170">線状グラデーションでは、行、グラデーション軸間で 2 つ以上の色をブレンドします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-170">A linear gradient blends two or more colors across a line, the gradient axis.</span></span> <span data-ttu-id="4cd95-171">GradientStop オブジェクトを使用するには、グラデーションとその位置で色を指定します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-171">You use GradientStop objects to specify the colors in the gradient and their positions.</span></span>

<span data-ttu-id="4cd95-172">次の図とコードは、赤と黄色の色を使用して 2 つの位置と、LinearGradientBrush で塗りつぶす SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-172">The following illustration and code shows a SpriteVisual painted with a LinearGradientBrush with 2 stops using a red and yellow color.</span></span>

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

### <a name="paint-with-an-image"></a><span data-ttu-id="4cd95-174">イメージで描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-174">Paint with an image</span></span>

<span data-ttu-id="4cd95-175">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) ICompositionSurface 上にレンダリングされるピクセルで、領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-175">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) paints an area with pixels rendered onto an ICompositionSurface.</span></span> <span data-ttu-id="4cd95-176">たとえば、 [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API を使用して、ICompositionSurface サーフェス上にレンダリングされた画像で領域を塗りつぶす、CompositionSurfaceBrush を使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-176">For example, a CompositionSurfaceBrush can be used to paint an area with an image rendered onto an ICompositionSurface surface using [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API.</span></span>

<span data-ttu-id="4cd95-177">次の図とコードはレンダリング先 LoadedImageSurface を使用して、ICompositionSurface licorice のビットマップが描かれて SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-177">The following illustration and code shows a SpriteVisual painted with a bitmap of a licorice rendered onto an ICompositionSurface using LoadedImageSurface.</span></span> <span data-ttu-id="4cd95-178">CompositionSurfaceBrush のプロパティは、ストレッチし、整列ビジュアルの境界内でのビットマップを使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-178">The properties of CompositionSurfaceBrush can be used to stretch and align the bitmap within the bounds of the visual.</span></span>

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

### <a name="paint-with-a-custom-drawing"></a><span data-ttu-id="4cd95-180">カスタム描画で描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-180">Paint with a custom drawing</span></span>
<span data-ttu-id="4cd95-181">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)は、 [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (または D2D) を使用してレンダリング、ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-181">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (or D2D).</span></span>

<span data-ttu-id="4cd95-182">次のコードは、Win2D を使用して、SpriteVisual が描かれて実行、ICompositionSurface 上にレンダリングされたテキストを示します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-182">The following code shows a SpriteVisual painted with a text run rendered onto an ICompositionSurface using Win2D.</span></span> <span data-ttu-id="4cd95-183">注: をプロジェクトに[Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp)パッケージを含める必要がある Win2D を使用するためにします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-183">Note, in order to use Win2D you need to include the [Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp) package into your project.</span></span>

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

<span data-ttu-id="4cd95-184">同様に、CompositionSurfaceBrush は、Win2D の相互運用機能を使用する SwapChain と SpriteVisual の描画にも使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-184">Similarly, the CompositionSurfaceBrush can also be used to paint a SpriteVisual with a SwapChain using Win2D interop.</span></span> <span data-ttu-id="4cd95-185">[このサンプル](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を使用して、swapchain に SpriteVisual をペイントする方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-185">[This sample](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample) provides an example of how to use Win2D to paint a SpriteVisual with a swapchain.</span></span>

### <a name="paint-with-a-video"></a><span data-ttu-id="4cd95-186">ビデオで描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-186">Paint with a video</span></span>
<span data-ttu-id="4cd95-187">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer)クラスによって読み込まれるビデオを使用してレンダリング、ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-187">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using a video loaded through the [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) class.</span></span>

<span data-ttu-id="4cd95-188">次のコードは、SpriteVisual が描かれて、ICompositionSurface に読み込まれるビデオを示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-188">The following code shows a SpriteVisual painted with a video loaded onto an ICompositionSurface.</span></span>

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

### <a name="paint-with-a-filter-effect"></a><span data-ttu-id="4cd95-189">フィルター効果で描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-189">Paint with a filter effect</span></span>

<span data-ttu-id="4cd95-190">[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)は、CompositionEffect の出力で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-190">A [CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) paints an area with output of a CompositionEffect.</span></span> <span data-ttu-id="4cd95-191">ビジュアル レイヤーの効果は、色、グラデーション、画像、ビデオ、スワップ、UI の地域またはツリーの視覚効果などのソースのコンテンツのコレクションに適用される効果をアニメーション化可能なフィルターと考えることがあります。</span><span class="sxs-lookup"><span data-stu-id="4cd95-191">Effects in the Visual Layer may be thought of as animatable filter effects applied to a collection of source content such as colors, gradients, images, videos, swapchains, regions of your UI, or trees of Visuals.</span></span> <span data-ttu-id="4cd95-192">ソース コンテンツは通常別 CompositionBrush を使用して指定します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-192">The source content is typically specified using another CompositionBrush.</span></span>

<span data-ttu-id="4cd95-193">次の図とコードを持つについてフィルター効果が適用された猫の画像で塗りつぶす SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-193">The following illustration and code shows a SpriteVisual painted with an image of a cat that has desaturation filter effect applied.</span></span>

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

<span data-ttu-id="4cd95-195">CompositionBrushes を使用して、効果の作成について詳しくは、[ビジュアル レイヤーの効果](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4cd95-195">For more information on creating an Effect using CompositionBrushes see [Effects in Visual layer](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)</span></span>

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a><span data-ttu-id="4cd95-196">不透明度マスクが適用された、CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-196">Paint with a CompositionBrush with opacity mask applied</span></span>

<span data-ttu-id="4cd95-197">[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)は、不透明マスクを適用すると、CompositionBrush で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-197">A [CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush) paints an area with a CompositionBrush with an opacity mask applied to it.</span></span> <span data-ttu-id="4cd95-198">不透明度マスクのソースが CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、または CompositionNineGridBrush の種類のすべての CompositionBrush できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-198">The source of the opacity mask can be any CompositionBrush of type CompositionColorBrush, CompositionLinearGradientBrush, CompositionSurfaceBrush, CompositionEffectBrush, or CompositionNineGridBrush.</span></span> <span data-ttu-id="4cd95-199">不透明マスクは、CompositionSurfaceBrush として指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4cd95-199">The opacity mask must be specified as a CompositionSurfaceBrush.</span></span>

<span data-ttu-id="4cd95-200">次の図とコードは、CompositionMaskBrush で塗りつぶす SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-200">The following illustration and code shows a SpriteVisual painted with a CompositionMaskBrush.</span></span> <span data-ttu-id="4cd95-201">マスクのソースとは、円の中に、マスクとして円のイメージを使用するような外観にマスクされた CompositionLinearGradientBrush です。</span><span class="sxs-lookup"><span data-stu-id="4cd95-201">The source of the mask is a CompositionLinearGradientBrush which is masked to look like a circle using an image of circle as a mask.</span></span>

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

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a><span data-ttu-id="4cd95-203">NineGrid stretch を使用して CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-203">Paint with a CompositionBrush using NineGrid stretch</span></span>

<span data-ttu-id="4cd95-204">[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)は 9-グリッド形式を使用して拡大する CompositionBrush で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-204">A [CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) paints an area with a CompositionBrush that is stretched using the nine-grid metaphor.</span></span> <span data-ttu-id="4cd95-205">9-グリッド形式を使用すると、その中心よりも異なるエッジと、CompositionBrush の角に丸みを拡大できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-205">The nine-grid metaphor enables you to stretch edges and corners of a CompositionBrush differently than its center.</span></span> <span data-ttu-id="4cd95-206">9 グリッドの stretch のソースは、任意の種類の CompositionColorBrush の CompositionBrush、CompositionSurfaceBrush、または CompositionEffectBrush によってことができます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-206">The source of the nine-grid stretch can by any CompositionBrush of type CompositionColorBrush, CompositionSurfaceBrush, or CompositionEffectBrush.</span></span>

<span data-ttu-id="4cd95-207">次のコードは、SpriteVisual が描かれて、CompositionNineGridBrush を示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-207">The following code shows a SpriteVisual painted with a CompositionNineGridBrush.</span></span> <span data-ttu-id="4cd95-208">マスクのソースとは、9 グリッドを使用して拡大する CompositionSurfaceBrush です。</span><span class="sxs-lookup"><span data-stu-id="4cd95-208">The source of the mask is a CompositionSurfaceBrush which is stretched using a Nine-Grid.</span></span>

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

### <a name="paint-using-background-pixels"></a><span data-ttu-id="4cd95-209">バック グラウンドのピクセルを使用してペイント</span><span class="sxs-lookup"><span data-stu-id="4cd95-209">Paint using Background Pixels</span></span>

<span data-ttu-id="4cd95-210">[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)は、領域の背後にコンテンツを含む領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4cd95-210">A [CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)  paints an area with the content behind the area.</span></span> <span data-ttu-id="4cd95-211">CompositionBackdropBrush は、単独で使用されていませんが、代わりに、EffectBrush などの別の CompositionBrush への入力として使われます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-211">A CompositionBackdropBrush is never used on its own, but instead is used as an input to another CompositionBrush like an EffectBrush.</span></span> <span data-ttu-id="4cd95-212">たとえば、ぼかし効果への入力として使用すると、CompositionBackdropBrush、すりガラス効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-212">For example, by using a CompositionBackdropBrush as an input to a Blur effect, you can achieve a frosted glass effect.</span></span>

<span data-ttu-id="4cd95-213">次のコードは、CompositionSurfaceBrush と画像の上のすりガラス オーバーレイを使用してイメージを作成する小規模なビジュアル ツリーを示しています。</span><span class="sxs-lookup"><span data-stu-id="4cd95-213">The following code shows a small visual tree to create an image using CompositionSurfaceBrush and a frosted glass overlay above the image.</span></span> <span data-ttu-id="4cd95-214">すりガラス オーバーレイが画像の上、EffectBrush 塗りつぶさ SpriteVisual を配置することによって作成されます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-214">The frosted glass overlay is created by placing a SpriteVisual filled with an EffectBrush above the image.</span></span> <span data-ttu-id="4cd95-215">EffectBrush、ぼかし効果への入力として、CompositionBackdropBrush を使用します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-215">The EffectBrush uses a CompositionBackdropBrush as an input to the blur effect.</span></span>

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

## <a name="combining-compositionbrushes"></a><span data-ttu-id="4cd95-216">CompositionBrushes を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="4cd95-216">Combining CompositionBrushes</span></span>
<span data-ttu-id="4cd95-217">CompositionBrushes 数は、他の CompositionBrushes を入力として使用します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-217">A number of CompositionBrushes use other CompositionBrushes as inputs.</span></span> <span data-ttu-id="4cd95-218">たとえば、別の CompositionBrush を CompositionEffectBrush への入力として設定するには、SetSourceParameter メソッドを使用してを使用できます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-218">For example, using the SetSourceParameter method can be used to set another CompositionBrush as an input to a CompositionEffectBrush.</span></span> <span data-ttu-id="4cd95-219">次の表では、サポートされている CompositionBrushes の組み合わせについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-219">The table below outlines the supported combinations of CompositionBrushes.</span></span> <span data-ttu-id="4cd95-220">サポートされていない組み合わせを使用すると例外がスローされることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4cd95-220">Note, that using an unsupported combination will throw an exception.</span></span>

<table>
<tbody>
<tr>
<th><span data-ttu-id="4cd95-221">Brush</span><span class="sxs-lookup"><span data-stu-id="4cd95-221">Brush</span></span></th>
<th><span data-ttu-id="4cd95-222">EffectBrush.SetSourceParameter()</span><span class="sxs-lookup"><span data-stu-id="4cd95-222">EffectBrush.SetSourceParameter()</span></span></th>
<th><span data-ttu-id="4cd95-223">MaskBrush.Mask</span><span class="sxs-lookup"><span data-stu-id="4cd95-223">MaskBrush.Mask</span></span></th>
<th><span data-ttu-id="4cd95-224">MaskBrush.Source</span><span class="sxs-lookup"><span data-stu-id="4cd95-224">MaskBrush.Source</span></span></th>
<th><span data-ttu-id="4cd95-225">NineGridBrush.Source</span><span class="sxs-lookup"><span data-stu-id="4cd95-225">NineGridBrush.Source</span></span></th>
</tr>
<tr>
<td><span data-ttu-id="4cd95-226">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-226">CompositionColorBrush</span></span></td>
<td><span data-ttu-id="4cd95-227">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-227">YES</span></span></td>
<td><span data-ttu-id="4cd95-228">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-228">YES</span></span></td>
<td><span data-ttu-id="4cd95-229">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-229">YES</span></span></td>
<td><span data-ttu-id="4cd95-230">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-230">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4cd95-231">CompositionLinear</span><span class="sxs-lookup"><span data-stu-id="4cd95-231">CompositionLinear</span></span><br /><span data-ttu-id="4cd95-232">GradientBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-232">GradientBrush</span></span></td>
<td><span data-ttu-id="4cd95-233">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-233">YES</span></span></td>
<td><span data-ttu-id="4cd95-234">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-234">YES</span></span></td>
<td><span data-ttu-id="4cd95-235">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-235">YES</span></span></td>
<td><span data-ttu-id="4cd95-236">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-236">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4cd95-237">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-237">CompositionSurfaceBrush</span></span></td>
<td><span data-ttu-id="4cd95-238">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-238">YES</span></span></td>
<td><span data-ttu-id="4cd95-239">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-239">YES</span></span></td>
<td><span data-ttu-id="4cd95-240">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-240">YES</span></span></td>
<td><span data-ttu-id="4cd95-241">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-241">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4cd95-242">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-242">CompositionEffectBrush</span></span></td>
<td><span data-ttu-id="4cd95-243">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-243">NO</span></span></td>
<td><span data-ttu-id="4cd95-244">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-244">NO</span></span></td>
<td><span data-ttu-id="4cd95-245">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-245">YES</span></span></td>
<td><span data-ttu-id="4cd95-246">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-246">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4cd95-247">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-247">CompositionMaskBrush</span></span></td>
<td><span data-ttu-id="4cd95-248">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-248">NO</span></span></td>
<td><span data-ttu-id="4cd95-249">使用不可</span><span class="sxs-lookup"><span data-stu-id="4cd95-249">NO</span></span></td>
<td><span data-ttu-id="4cd95-250">使用不可</span><span class="sxs-lookup"><span data-stu-id="4cd95-250">NO</span></span></td>
<td><span data-ttu-id="4cd95-251">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-251">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4cd95-252">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-252">CompositionNineGridBrush</span></span></td>
<td><span data-ttu-id="4cd95-253">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-253">YES</span></span></td>
<td><span data-ttu-id="4cd95-254">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-254">YES</span></span></td>
<td><span data-ttu-id="4cd95-255">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-255">YES</span></span></td>
<td><span data-ttu-id="4cd95-256">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-256">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4cd95-257">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-257">CompositionBackdropBrush</span></span></td>
<td><span data-ttu-id="4cd95-258">使用可能</span><span class="sxs-lookup"><span data-stu-id="4cd95-258">YES</span></span></td>
<td><span data-ttu-id="4cd95-259">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-259">NO</span></span></td>
<td><span data-ttu-id="4cd95-260">使用不可</span><span class="sxs-lookup"><span data-stu-id="4cd95-260">NO</span></span></td>
<td><span data-ttu-id="4cd95-261">NO</span><span class="sxs-lookup"><span data-stu-id="4cd95-261">NO</span></span></td>
</tr>
</tbody>
</table>


## <a name="using-a-xaml-brush-vs-compositionbrush"></a><span data-ttu-id="4cd95-262">使用する XAML ブラシと CompositionBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-262">Using a XAML Brush vs. CompositionBrush</span></span>

<span data-ttu-id="4cd95-263">次の表では、シナリオと、UIElement またはアプリケーションで SpriteVisual を描画するときに XAML またはコンポジションのブラシの使用を規定するかどうかの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-263">The following table provides a list of scenarios and whether XAML or Composition brush use is prescribed when painting a UIElement or a SpriteVisual in your application.</span></span> 

> [!NOTE]
> <span data-ttu-id="4cd95-264">XAML UIElement には、CompositionBrush を使用することをお勧めに XamlCompositionBrushBase を使用して、CompositionBrush がパッケージ化すると見なされます。</span><span class="sxs-lookup"><span data-stu-id="4cd95-264">If a CompositionBrush is suggested for a XAML UIElement, it is assumed that the CompositionBrush is packaged using a XamlCompositionBrushBase.</span></span>

|<span data-ttu-id="4cd95-265">シナリオ</span><span class="sxs-lookup"><span data-stu-id="4cd95-265">Scenario</span></span>                                                                   | <span data-ttu-id="4cd95-266">XAML UIElement</span><span class="sxs-lookup"><span data-stu-id="4cd95-266">XAML UIElement</span></span>                                                                                                |<span data-ttu-id="4cd95-267">コンポジション SpriteVisual</span><span class="sxs-lookup"><span data-stu-id="4cd95-267">Composition SpriteVisual</span></span>
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|<span data-ttu-id="4cd95-268">領域を単色で塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-268">Paint an area with solid color</span></span>                                             |[<span data-ttu-id="4cd95-269">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-269">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="4cd95-270">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-270">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="4cd95-271">アニメーション化された色で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-271">Paint an area with animated color</span></span>                                          |[<span data-ttu-id="4cd95-272">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-272">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="4cd95-273">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-273">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="4cd95-274">静的なグラデーションで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-274">Paint an area with a static gradient</span></span>                                       |[<span data-ttu-id="4cd95-275">LinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-275">LinearGradientBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[<span data-ttu-id="4cd95-276">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-276">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="4cd95-277">アニメーション化されたグラデーションで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-277">Paint an area with animated gradient stops</span></span>                                 |[<span data-ttu-id="4cd95-278">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-278">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[<span data-ttu-id="4cd95-279">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-279">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="4cd95-280">画像で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-280">Paint an area with an image</span></span>                                                |[<span data-ttu-id="4cd95-281">ImageBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-281">ImageBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[<span data-ttu-id="4cd95-282">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-282">CompositionSurfaceBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|<span data-ttu-id="4cd95-283">Web ページで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-283">Paint an area with a webpage</span></span>                                               |[<span data-ttu-id="4cd95-284">WebViewBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-284">WebViewBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |<span data-ttu-id="4cd95-285">該当なし</span><span class="sxs-lookup"><span data-stu-id="4cd95-285">N/A</span></span>
|<span data-ttu-id="4cd95-286">NineGrid stretch を使用してイメージで領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-286">Paint an area with an image using NineGrid stretch</span></span>                         |[<span data-ttu-id="4cd95-287">Image コントロール</span><span class="sxs-lookup"><span data-stu-id="4cd95-287">Image Control</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[<span data-ttu-id="4cd95-288">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-288">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="4cd95-289">アニメーション化された NineGrid stretch で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-289">Paint an area with animated NineGrid stretch</span></span>                               |[<span data-ttu-id="4cd95-290">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-290">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[<span data-ttu-id="4cd95-291">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-291">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="4cd95-292">Swapchain で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-292">Paint an area with a swapchain</span></span>                                             |[<span data-ttu-id="4cd95-293">SwapChainPanel</span><span class="sxs-lookup"><span data-stu-id="4cd95-293">SwapChainPanel</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |<span data-ttu-id="4cd95-294">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (swapchain の相互運用機能を使用)</span><span class="sxs-lookup"><span data-stu-id="4cd95-294">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ swapchain interop</span></span>
|<span data-ttu-id="4cd95-295">ビデオで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-295">Paint an area with a video</span></span>                                                 |[<span data-ttu-id="4cd95-296">MediaElement</span><span class="sxs-lookup"><span data-stu-id="4cd95-296">MediaElement</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |<span data-ttu-id="4cd95-297">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (メディアの相互運用機能を使用)</span><span class="sxs-lookup"><span data-stu-id="4cd95-297">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ media interop</span></span>
|<span data-ttu-id="4cd95-298">カスタムの 2D 描画で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-298">Paint an area with custom 2D drawing</span></span>                                       |<span data-ttu-id="4cd95-299">Win2D から[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm)</span><span class="sxs-lookup"><span data-stu-id="4cd95-299">[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm) from Win2D</span></span>                                                                                                 |<span data-ttu-id="4cd95-300">Win2D の相互運用機能と[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)</span><span class="sxs-lookup"><span data-stu-id="4cd95-300">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ Win2D interop</span></span>
|<span data-ttu-id="4cd95-301">マスクのアニメーション化で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-301">Paint an area with non-animated mask</span></span>                                       |<span data-ttu-id="4cd95-302">マスクを定義する XAML[の図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-302">Use XAML [shapes](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes) to define a mask</span></span>   |[<span data-ttu-id="4cd95-303">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-303">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="4cd95-304">アニメーションのマスクで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-304">Paint an area with an animated mask</span></span>                                        |[<span data-ttu-id="4cd95-305">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-305">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[<span data-ttu-id="4cd95-306">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-306">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="4cd95-307">アニメーション化されたフィルター効果で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4cd95-307">Paint an area with an animated filter effect</span></span>                               |[<span data-ttu-id="4cd95-308">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-308">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[<span data-ttu-id="4cd95-309">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-309">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|<span data-ttu-id="4cd95-310">バック グラウンド ピクセルに適用する効果で領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="4cd95-310">Paint an area with an effect applied to background pixels</span></span>        |[<span data-ttu-id="4cd95-311">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-311">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[<span data-ttu-id="4cd95-312">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4cd95-312">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a><span data-ttu-id="4cd95-313">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4cd95-313">Related Topics</span></span>

[<span data-ttu-id="4cd95-314">コンポジション ネイティブ DirectX と Direct2D の相互運用機能 BeginDraw と EndDraw による</span><span class="sxs-lookup"><span data-stu-id="4cd95-314">Composition native DirectX and Direct2D interop with BeginDraw and EndDraw</span></span>](composition-native-interop.md)

[<span data-ttu-id="4cd95-315">XamlCompositionBrushBase と XAML ブラシの相互運用</span><span class="sxs-lookup"><span data-stu-id="4cd95-315">XAML brush interop with XamlCompositionBrushBase</span></span>](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
