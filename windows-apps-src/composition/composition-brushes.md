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
# <a name="composition-brushes"></a><span data-ttu-id="3701e-105">コンポジションのブラシ</span><span class="sxs-lookup"><span data-stu-id="3701e-105">Composition brushes</span></span>
<span data-ttu-id="3701e-106">UWP アプリケーションから、画面上に表示されているすべてのアイテムは、ブラシによって描画されているために表示されます。</span><span class="sxs-lookup"><span data-stu-id="3701e-106">Everything visible on your screen from a UWP application is visible because it was painted by a Brush.</span></span> <span data-ttu-id="3701e-107">ブラシを使用すると、画像または複雑な効果のチェーンに図面に単純な純色のようなコンテンツをユーザー インターフェイス (UI) のオブジェクトを描くことができます。</span><span class="sxs-lookup"><span data-stu-id="3701e-107">Brushes enable you to paint user interface (UI) objects with content ranging from simple, solid colors to images or drawings to complex effects chain.</span></span> <span data-ttu-id="3701e-108">このトピックでは、CompositionBrush と描画の概念を紹介します。</span><span class="sxs-lookup"><span data-stu-id="3701e-108">This topic introduces the concepts of painting with CompositionBrush.</span></span>

<span data-ttu-id="3701e-109">メモ、XAML UWP アプリを使用する場合に、UIElement [XAML ブラシ](/windows/uwp/design/style/brushes)または[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)を描画する] を選択することができます。</span><span class="sxs-lookup"><span data-stu-id="3701e-109">Note, when working with XAML UWP app, you can chose to paint a UIElement with a [XAML Brush](/windows/uwp/design/style/brushes) or a [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush).</span></span> <span data-ttu-id="3701e-110">通常、簡単かつ XAML ブラシで自分のシナリオがサポートされている場合は、XAML ブラシを選択することをお勧めです。</span><span class="sxs-lookup"><span data-stu-id="3701e-110">Typically, it is easier and advisable to choose a XAML brush if your scenario is supported by a XAML Brush.</span></span> <span data-ttu-id="3701e-111">たとえば、テキストまたは画像を含む図形の塗りつぶしの変更] ボタンの色のアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="3701e-111">For example, animating the color of a button, changing the fill of a text or a shape with an image.</span></span> <span data-ttu-id="3701e-112">その一方で、定型アニメーションまたはアニメーションの 9 グリッド ストレッチ、効果のチェーンに描画などのような XAML ブラシでサポートされていないことを実行しようとしている場合、CompositionBrush に使える[を使用して、UIElement を描くXamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)します。</span><span class="sxs-lookup"><span data-stu-id="3701e-112">On the other hand, if you are trying to do something that is not supported by a XAML brush like like painting with an animated mask or an animated nine-grid stretch or an effect chain, you can use a CompositionBrush to paint a UIElement through the use of [XamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase).</span></span>

<span data-ttu-id="3701e-113">視覚的なレイヤーを使用する場合の[SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual)の領域を描画する、CompositionBrush を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3701e-113">When working with the Visual layer, a CompositionBrush must be used to paint the area of a [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual).</span></span>

-   [<span data-ttu-id="3701e-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="3701e-114">Prerequisites</span></span>](./composition-brushes.md#prerequisites)
-   [<span data-ttu-id="3701e-115">CompositionBrush での塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="3701e-115">Paint with CompositionBrush</span></span>](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [<span data-ttu-id="3701e-116">均一な色で塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-116">Paint with a solid color</span></span>](./composition-brushes.md#paint-with-a-solid-color)
    -   [<span data-ttu-id="3701e-117">線形グラデーションで描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-117">Paint with a linear gradient</span></span>](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [<span data-ttu-id="3701e-118">画像で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-118">Paint with an image</span></span>](./composition-brushes.md#paint-with-an-image)
    -   [<span data-ttu-id="3701e-119">ユーザー設定の図面で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-119">Paint with a custom drawing</span></span>](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [<span data-ttu-id="3701e-120">ビデオで描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-120">Paint with a video</span></span>](./composition-brushes.md#paint-with-a-video)
    -   [<span data-ttu-id="3701e-121">フィルターの効果で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-121">Paint with a filter effect</span></span>](./composition-brushes.md#paint-with-a-filter-effect)
    -   [<span data-ttu-id="3701e-122">CompositionBrush 不透明マスクを描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-122">Paint with a CompositionBrush with an opacity mask</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [<span data-ttu-id="3701e-123">[引き伸ばし] NineGrid を使用して CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-123">Paint with a CompositionBrush using NineGrid stretch</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [<span data-ttu-id="3701e-124">背景のピクセルを使用してペイントします。</span><span class="sxs-lookup"><span data-stu-id="3701e-124">Paint using Background Pixels</span></span>](./composition-brushes.md#paint-using-background-pixels)
-   [<span data-ttu-id="3701e-125">CompositionBrushes を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="3701e-125">Combining CompositionBrushes</span></span>](./composition-brushes.md#combining-compositionbrushes)
-   [<span data-ttu-id="3701e-126">XAML ブラシと CompositionBrush を使用します。</span><span class="sxs-lookup"><span data-stu-id="3701e-126">Using a XAML Brush vs. CompositionBrush</span></span>](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [<span data-ttu-id="3701e-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3701e-127">Related Topics</span></span>](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a><span data-ttu-id="3701e-128">前提条件</span><span class="sxs-lookup"><span data-stu-id="3701e-128">Prerequisites</span></span>
<span data-ttu-id="3701e-129">ここで熟知している、基本的な構成アプリケーションの構造を[視覚的なレイヤーの概要](visual-layer.md)で説明するようにします。</span><span class="sxs-lookup"><span data-stu-id="3701e-129">This overview assumes that you are familiar with the structure of a basic Composition application, as described in the [Visual layer overview](visual-layer.md).</span></span>

## <a name="paint-with-a-compositionbrush"></a><span data-ttu-id="3701e-130">ペイントを CompositionBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-130">Paint with a CompositionBrush</span></span>

<span data-ttu-id="3701e-131">の[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) 「描画」領域を出力します。</span><span class="sxs-lookup"><span data-stu-id="3701e-131">A [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) "paints" an area with its output.</span></span> <span data-ttu-id="3701e-132">さまざまなブラシで、出力の種類もさまざまです。</span><span class="sxs-lookup"><span data-stu-id="3701e-132">Different brushes have different types of output.</span></span> <span data-ttu-id="3701e-133">塗りつぶしの色、グラデーション、イメージ、カスタムの描画または効果を持つその他の領域を塗りつぶすブラシします。</span><span class="sxs-lookup"><span data-stu-id="3701e-133">Some brushes paint an area with a solid color, others with a gradient, image, custom drawing, or effect.</span></span> <span data-ttu-id="3701e-134">その他のブラシの動作を変更する、特殊なブラシがあります。</span><span class="sxs-lookup"><span data-stu-id="3701e-134">There are also specialized brushes that modify the behavior of other brushes.</span></span> <span data-ttu-id="3701e-135">たとえば、のどの領域が、CompositionBrush、して描画を制御する利用される不透明マスクか、領域を描画するときに、CompositionBrush に適用された拡大を制御する 9 グリッドを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="3701e-135">For example, opacity mask can be used to control which area is painted by a CompositionBrush, or a nine-grid can be used to control the stretch applied to a CompositionBrush when painting an area.</span></span> <span data-ttu-id="3701e-136">CompositionBrush は、次の種類のいずれかの指定できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-136">CompositionBrush can be of one of the following types:</span></span>

|<span data-ttu-id="3701e-137">クラス</span><span class="sxs-lookup"><span data-stu-id="3701e-137">Class</span></span>                                   |<span data-ttu-id="3701e-138">詳細</span><span class="sxs-lookup"><span data-stu-id="3701e-138">Details</span></span>                                         |<span data-ttu-id="3701e-139">を導入</span><span class="sxs-lookup"><span data-stu-id="3701e-139">Introduced In</span></span>|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[<span data-ttu-id="3701e-140">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-140">CompositionColorBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |<span data-ttu-id="3701e-141">均一な色を使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-141">Paints an area with a solid color</span></span>                        |<span data-ttu-id="3701e-142">Windows 10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="3701e-142">Windows 10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="3701e-143">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-143">CompositionSurfaceBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |<span data-ttu-id="3701e-144">領域を[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)の内容を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="3701e-144">Paints an area with the contents of an [ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)</span></span>|<span data-ttu-id="3701e-145">Windows 10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="3701e-145">Windows 10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="3701e-146">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-146">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |<span data-ttu-id="3701e-147">構成の効果の内容がある領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-147">Paints an area with the contents of a composition effect</span></span> |<span data-ttu-id="3701e-148">Windows 10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="3701e-148">Windows 10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="3701e-149">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-149">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |<span data-ttu-id="3701e-150">不透明マスクと、CompositionBrush で視覚的に描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-150">Paints a visual with a CompositionBrush with an opacity mask</span></span> |<span data-ttu-id="3701e-151">Windows 10 の記念日の更新プログラム (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="3701e-151">Windows 10 Anniversary Update (SDK 14393)</span></span>
|[<span data-ttu-id="3701e-152">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-152">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |<span data-ttu-id="3701e-153">NineGrid の引き伸ばし] を使用して CompositionBrush の領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-153">Paints an area with a CompositionBrush using a NineGrid stretch</span></span> |<span data-ttu-id="3701e-154">Windows 10 の記念日更新 SDK (14393)</span><span class="sxs-lookup"><span data-stu-id="3701e-154">Windows 10 Anniversary Update SDK (14393)</span></span>
|[<span data-ttu-id="3701e-155">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-155">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|<span data-ttu-id="3701e-156">線形グラデーションを使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-156">Paints an area with a linear gradient</span></span>                    |<span data-ttu-id="3701e-157">Windows 10 の分類の作成者の更新プログラム (内部の SDK プレビュー版)</span><span class="sxs-lookup"><span data-stu-id="3701e-157">Windows 10 Fall Creators Update (Insider Preview SDK)</span></span>
|[<span data-ttu-id="3701e-158">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-158">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |<span data-ttu-id="3701e-159">サンプルのいずれかのアプリケーションからの背景ピクセルまたはデスクトップ アプリケーションのウィンドウの背後にあるピクセルして領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-159">Paints an area by sampling background pixels from either the application or pixels directly behind the application's window on desktop.</span></span> <span data-ttu-id="3701e-160">CompositionEffectBrush などの別の CompositionBrush への入力として使用します。</span><span class="sxs-lookup"><span data-stu-id="3701e-160">Used as an input to another CompositionBrush like a CompositionEffectBrush</span></span> | <span data-ttu-id="3701e-161">Windows 10 の記念日の更新プログラム (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="3701e-161">Windows 10 Anniversary Update (SDK 14393)</span></span>

### <a name="paint-with-a-solid-color"></a><span data-ttu-id="3701e-162">均一な色で塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-162">Paint with a solid color</span></span>

<span data-ttu-id="3701e-163">の[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)単色を使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-163">A [CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush) paints an area with a solid color.</span></span> <span data-ttu-id="3701e-164">さまざまなを SolidColorBrush の色を指定する方法があります。</span><span class="sxs-lookup"><span data-stu-id="3701e-164">There are a variety of ways to specify the color of a SolidColorBrush.</span></span> <span data-ttu-id="3701e-165">たとえば、アルファ、赤、青、および緑 (ARGB) チャンネルを指定したり、[色](https://docs.microsoft.com/uwp/api/windows.ui.colors)のクラスによって提供される、事前に定義された色のいずれかを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-165">For example, you can specify its alpha, red, blue, and green (ARGB) channels or use one of the predefined colors provided by the [Colors](https://docs.microsoft.com/uwp/api/windows.ui.colors) class.</span></span>

<span data-ttu-id="3701e-166">次の図とコードは、黒の色ブラシで描かれた四角形を、色の値が 0x9ACD32 である単色ブラシで塗りつぶす小規模なビジュアル ツリーを示しています。</span><span class="sxs-lookup"><span data-stu-id="3701e-166">The following illustration and code shows a small visual tree to create a rectangle that is stroked with a black color brush and painted with a solid color brush that has the color value of 0x9ACD32.</span></span>

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

### <a name="paint-with-a-linear-gradient"></a><span data-ttu-id="3701e-168">線形グラデーションで描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-168">Paint with a linear gradient</span></span>

<span data-ttu-id="3701e-169">の[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)線形グラデーションを使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-169">A [CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush) paints an area with a linear gradient.</span></span> <span data-ttu-id="3701e-170">線形グラデーションは、線、グラデーションの軸の 2 つ以上の色をブレンドします。</span><span class="sxs-lookup"><span data-stu-id="3701e-170">A linear gradient blends two or more colors across a line, the gradient axis.</span></span> <span data-ttu-id="3701e-171">グラデーションとその位置に色を指定するのには、GradientStop オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="3701e-171">You use GradientStop objects to specify the colors in the gradient and their positions.</span></span>

<span data-ttu-id="3701e-172">次の図とコードは、赤、黄色の色を使用して 2 つの位置に、によってでペイント SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="3701e-172">The following illustration and code shows a SpriteVisual painted with a LinearGradientBrush with 2 stops using a red and yellow color.</span></span>

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

### <a name="paint-with-an-image"></a><span data-ttu-id="3701e-174">画像で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-174">Paint with an image</span></span>

<span data-ttu-id="3701e-175">の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)を ICompositionSurface 上に表示するピクセルを使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-175">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) paints an area with pixels rendered onto an ICompositionSurface.</span></span> <span data-ttu-id="3701e-176">たとえば、 [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API を使用して、ICompositionSurface 画面に表示される画像の領域を塗りつぶす、CompositionSurfaceBrush を使用できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-176">For example, a CompositionSurfaceBrush can be used to paint an area with an image rendered onto an ICompositionSurface surface using [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API.</span></span>

<span data-ttu-id="3701e-177">次の図とコード LoadedImageSurface を使用して、ICompositionSurface 上に表示される licorice のビットマップ、SpriteVisual の描画を示しています。</span><span class="sxs-lookup"><span data-stu-id="3701e-177">The following illustration and code shows a SpriteVisual painted with a bitmap of a licorice rendered onto an ICompositionSurface using LoadedImageSurface.</span></span> <span data-ttu-id="3701e-178">拡大して、ビットマップ ビジュアルの境界内に揃えるには、CompositionSurfaceBrush のプロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-178">The properties of CompositionSurfaceBrush can be used to stretch and align the bitmap within the bounds of the visual.</span></span>

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

### <a name="paint-with-a-custom-drawing"></a><span data-ttu-id="3701e-180">ユーザー設定の図面で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-180">Paint with a custom drawing</span></span>
<span data-ttu-id="3701e-181">の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (または D2D) を使用して描画を ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-181">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (or D2D).</span></span>

<span data-ttu-id="3701e-182">次のコードは、Win2D を使用して、実行、ICompositionSurface 上に表示されるテキストを含む、SpriteVisual の描画を示します。</span><span class="sxs-lookup"><span data-stu-id="3701e-182">The following code shows a SpriteVisual painted with a text run rendered onto an ICompositionSurface using Win2D.</span></span> <span data-ttu-id="3701e-183">[Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp)パッケージをプロジェクトに含める必要があります Win2D を使用するために注意します。</span><span class="sxs-lookup"><span data-stu-id="3701e-183">Note, in order to use Win2D you need to include the [Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp) package into your project.</span></span>

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

<span data-ttu-id="3701e-184">同様に、CompositionSurfaceBrush は、SpriteVisual Win2D の相互運用性を使用して SwapChain での描画にも使用できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-184">Similarly, the CompositionSurfaceBrush can also be used to paint a SpriteVisual with a SwapChain using Win2D interop.</span></span> <span data-ttu-id="3701e-185">[この例](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を使用して、swapchain と、SpriteVisual を描画する方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="3701e-185">[This sample](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample) provides an example of how to use Win2D to paint a SpriteVisual with a swapchain.</span></span>

### <a name="paint-with-a-video"></a><span data-ttu-id="3701e-186">ビデオで描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-186">Paint with a video</span></span>
<span data-ttu-id="3701e-187">の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer)クラスで読み込まれているビデオを使用して描画を ICompositionSurface からピクセルで領域を塗りつぶすにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-187">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using a video loaded through the [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) class.</span></span>

<span data-ttu-id="3701e-188">次のコードを ICompositionSurface に読み込まれているビデオを使用して、SpriteVisual の描画を示します。</span><span class="sxs-lookup"><span data-stu-id="3701e-188">The following code shows a SpriteVisual painted with a video loaded onto an ICompositionSurface.</span></span>

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

### <a name="paint-with-a-filter-effect"></a><span data-ttu-id="3701e-189">フィルターの効果で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-189">Paint with a filter effect</span></span>

<span data-ttu-id="3701e-190">の[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)を CompositionEffect の出力がある領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-190">A [CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) paints an area with output of a CompositionEffect.</span></span> <span data-ttu-id="3701e-191">レイヤーを視覚的な効果は、色、グラデーション、画像、ビデオ、swapchains、自分のユーザー インターフェイスの領域またはビジュアルのツリーなどのソースのコンテンツのコレクションに適用されたフィルターのアニメーション効果と考えることがあります。</span><span class="sxs-lookup"><span data-stu-id="3701e-191">Effects in the Visual Layer may be thought of as animatable filter effects applied to a collection of source content such as colors, gradients, images, videos, swapchains, regions of your UI, or trees of Visuals.</span></span> <span data-ttu-id="3701e-192">別の CompositionBrush を使用して、ソースのコンテンツが通常指定します。</span><span class="sxs-lookup"><span data-stu-id="3701e-192">The source content is typically specified using another CompositionBrush.</span></span>

<span data-ttu-id="3701e-193">次の図とコードの彩度を下げて光沢フィルターの効果が適用されている猫の画像で塗りつぶさ SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="3701e-193">The following illustration and code shows a SpriteVisual painted with an image of a cat that has desaturation filter effect applied.</span></span>

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

<span data-ttu-id="3701e-195">CompositionBrushes を使用して、効果を作成する方法については、[視覚的なレイヤーの効果](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3701e-195">For more information on creating an Effect using CompositionBrushes see [Effects in Visual layer](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)</span></span>

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a><span data-ttu-id="3701e-196">不透明マスクが適用された、CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-196">Paint with a CompositionBrush with opacity mask applied</span></span>

<span data-ttu-id="3701e-197">[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)を対象となる不透明マスクで、CompositionBrush がある領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-197">A [CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush) paints an area with a CompositionBrush with an opacity mask applied to it.</span></span> <span data-ttu-id="3701e-198">不透明マスクのソース タイプ CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、または CompositionNineGridBrush の任意の CompositionBrush ができます。</span><span class="sxs-lookup"><span data-stu-id="3701e-198">The source of the opacity mask can be any CompositionBrush of type CompositionColorBrush, CompositionLinearGradientBrush, CompositionSurfaceBrush, CompositionEffectBrush, or CompositionNineGridBrush.</span></span> <span data-ttu-id="3701e-199">不透明マスクを CompositionSurfaceBrush として指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="3701e-199">The opacity mask must be specified as a CompositionSurfaceBrush.</span></span>

<span data-ttu-id="3701e-200">次の図とコードを CompositionMaskBrush でペイント SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="3701e-200">The following illustration and code shows a SpriteVisual painted with a CompositionMaskBrush.</span></span> <span data-ttu-id="3701e-201">マスクのソースとは、円の画像を使用して、マスクとして円のようにマスクされる CompositionLinearGradientBrush です。</span><span class="sxs-lookup"><span data-stu-id="3701e-201">The source of the mask is a CompositionLinearGradientBrush which is masked to look like a circle using an image of circle as a mask.</span></span>

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

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a><span data-ttu-id="3701e-203">[引き伸ばし] NineGrid を使用して CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-203">Paint with a CompositionBrush using NineGrid stretch</span></span>

<span data-ttu-id="3701e-204">の[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) 9 グリッド メタファを使用して拡大する CompositionBrush がある領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-204">A [CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) paints an area with a CompositionBrush that is stretched using the nine-grid metaphor.</span></span> <span data-ttu-id="3701e-205">9 グリッド メタファを使用するより、中央、CompositionBrush の端および角を異なる拡大できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-205">The nine-grid metaphor enables you to stretch edges and corners of a CompositionBrush differently than its center.</span></span> <span data-ttu-id="3701e-206">[引き伸ばし] 9 グリッドの任意の種類 CompositionColorBrush CompositionBrush、CompositionSurfaceBrush、または CompositionEffectBrush ことができます。</span><span class="sxs-lookup"><span data-stu-id="3701e-206">The source of the nine-grid stretch can by any CompositionBrush of type CompositionColorBrush, CompositionSurfaceBrush, or CompositionEffectBrush.</span></span>

<span data-ttu-id="3701e-207">次のコードは、SpriteVisual が、CompositionNineGridBrush でペイントが表示されます。</span><span class="sxs-lookup"><span data-stu-id="3701e-207">The following code shows a SpriteVisual painted with a CompositionNineGridBrush.</span></span> <span data-ttu-id="3701e-208">マスクのソースを CompositionSurfaceBrush 9 グリッドを使用して拡大するには</span><span class="sxs-lookup"><span data-stu-id="3701e-208">The source of the mask is a CompositionSurfaceBrush which is stretched using a Nine-Grid.</span></span>

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

### <a name="paint-using-background-pixels"></a><span data-ttu-id="3701e-209">背景のピクセルを使用してペイントします。</span><span class="sxs-lookup"><span data-stu-id="3701e-209">Paint using Background Pixels</span></span>

<span data-ttu-id="3701e-210">の[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)領域の背後にコンテンツがある領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-210">A [CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)  paints an area with the content behind the area.</span></span> <span data-ttu-id="3701e-211">CompositionBackdropBrush では、自身で使用されていませんが、代わりに、EffectBrush などの別の CompositionBrush への入力として使用します。</span><span class="sxs-lookup"><span data-stu-id="3701e-211">A CompositionBackdropBrush is never used on its own, but instead is used as an input to another CompositionBrush like an EffectBrush.</span></span> <span data-ttu-id="3701e-212">たとえば、ぼかし効果への入力として CompositionBackdropBrush を使用すると、すりガラスの効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-212">For example, by using a CompositionBackdropBrush as an input to a Blur effect, you can achieve a frosted glass effect.</span></span>

<span data-ttu-id="3701e-213">CompositionSurfaceBrush と画像の上にあるすりガラス オーバーレイを使用してイメージを作成する場合は、小さな視覚的なツリーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="3701e-213">The following code shows a small visual tree to create an image using CompositionSurfaceBrush and a frosted glass overlay above the image.</span></span> <span data-ttu-id="3701e-214">画像の上、EffectBrush で塗りつぶさ SpriteVisual を配置することによってすりガラスのオーバーレイが作成されます。</span><span class="sxs-lookup"><span data-stu-id="3701e-214">The frosted glass overlay is created by placing a SpriteVisual filled with an EffectBrush above the image.</span></span> <span data-ttu-id="3701e-215">[EffectBrush ぼかし効果への入力として、CompositionBackdropBrush を使用します。</span><span class="sxs-lookup"><span data-stu-id="3701e-215">The EffectBrush uses a CompositionBackdropBrush as an input to the blur effect.</span></span>

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

## <a name="combining-compositionbrushes"></a><span data-ttu-id="3701e-216">CompositionBrushes を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="3701e-216">Combining CompositionBrushes</span></span>
<span data-ttu-id="3701e-217">CompositionBrushes の数値では、入力としてその他の CompositionBrushes を使用します。</span><span class="sxs-lookup"><span data-stu-id="3701e-217">A number of CompositionBrushes use other CompositionBrushes as inputs.</span></span> <span data-ttu-id="3701e-218">たとえば、CompositionEffectBrush への入力として別の CompositionBrush を設定するには、SetSourceParameter メソッドを使用してを使用できます。</span><span class="sxs-lookup"><span data-stu-id="3701e-218">For example, using the SetSourceParameter method can be used to set another CompositionBrush as an input to a CompositionEffectBrush.</span></span> <span data-ttu-id="3701e-219">次の表は、サポートされている CompositionBrushes の組み合わせを示します。</span><span class="sxs-lookup"><span data-stu-id="3701e-219">The table below outlines the supported combinations of CompositionBrushes.</span></span> <span data-ttu-id="3701e-220">なお、サポートされていない組み合わせ例外が発生します。</span><span class="sxs-lookup"><span data-stu-id="3701e-220">Note, that using an unsupported combination will throw an exception.</span></span>

<table>
<tbody>
<tr>
<th><span data-ttu-id="3701e-221">Brush</span><span class="sxs-lookup"><span data-stu-id="3701e-221">Brush</span></span></th>
<th><span data-ttu-id="3701e-222">EffectBrush.SetSourceParameter()</span><span class="sxs-lookup"><span data-stu-id="3701e-222">EffectBrush.SetSourceParameter()</span></span></th>
<th><span data-ttu-id="3701e-223">MaskBrush.Mask</span><span class="sxs-lookup"><span data-stu-id="3701e-223">MaskBrush.Mask</span></span></th>
<th><span data-ttu-id="3701e-224">MaskBrush.Source</span><span class="sxs-lookup"><span data-stu-id="3701e-224">MaskBrush.Source</span></span></th>
<th><span data-ttu-id="3701e-225">NineGridBrush.Source</span><span class="sxs-lookup"><span data-stu-id="3701e-225">NineGridBrush.Source</span></span></th>
</tr>
<tr>
<td><span data-ttu-id="3701e-226">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-226">CompositionColorBrush</span></span></td>
<td><span data-ttu-id="3701e-227">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-227">YES</span></span></td>
<td><span data-ttu-id="3701e-228">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-228">YES</span></span></td>
<td><span data-ttu-id="3701e-229">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-229">YES</span></span></td>
<td><span data-ttu-id="3701e-230">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-230">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="3701e-231">CompositionLinear</span><span class="sxs-lookup"><span data-stu-id="3701e-231">CompositionLinear</span></span><br /><span data-ttu-id="3701e-232">GradientBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-232">GradientBrush</span></span></td>
<td><span data-ttu-id="3701e-233">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-233">YES</span></span></td>
<td><span data-ttu-id="3701e-234">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-234">YES</span></span></td>
<td><span data-ttu-id="3701e-235">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-235">YES</span></span></td>
<td><span data-ttu-id="3701e-236">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-236">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="3701e-237">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-237">CompositionSurfaceBrush</span></span></td>
<td><span data-ttu-id="3701e-238">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-238">YES</span></span></td>
<td><span data-ttu-id="3701e-239">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-239">YES</span></span></td>
<td><span data-ttu-id="3701e-240">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-240">YES</span></span></td>
<td><span data-ttu-id="3701e-241">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-241">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="3701e-242">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-242">CompositionEffectBrush</span></span></td>
<td><span data-ttu-id="3701e-243">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-243">NO</span></span></td>
<td><span data-ttu-id="3701e-244">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-244">NO</span></span></td>
<td><span data-ttu-id="3701e-245">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-245">YES</span></span></td>
<td><span data-ttu-id="3701e-246">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-246">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="3701e-247">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-247">CompositionMaskBrush</span></span></td>
<td><span data-ttu-id="3701e-248">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-248">NO</span></span></td>
<td><span data-ttu-id="3701e-249">使用不可</span><span class="sxs-lookup"><span data-stu-id="3701e-249">NO</span></span></td>
<td><span data-ttu-id="3701e-250">使用不可</span><span class="sxs-lookup"><span data-stu-id="3701e-250">NO</span></span></td>
<td><span data-ttu-id="3701e-251">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-251">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="3701e-252">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-252">CompositionNineGridBrush</span></span></td>
<td><span data-ttu-id="3701e-253">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-253">YES</span></span></td>
<td><span data-ttu-id="3701e-254">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-254">YES</span></span></td>
<td><span data-ttu-id="3701e-255">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-255">YES</span></span></td>
<td><span data-ttu-id="3701e-256">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-256">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="3701e-257">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-257">CompositionBackdropBrush</span></span></td>
<td><span data-ttu-id="3701e-258">使用可能</span><span class="sxs-lookup"><span data-stu-id="3701e-258">YES</span></span></td>
<td><span data-ttu-id="3701e-259">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-259">NO</span></span></td>
<td><span data-ttu-id="3701e-260">使用不可</span><span class="sxs-lookup"><span data-stu-id="3701e-260">NO</span></span></td>
<td><span data-ttu-id="3701e-261">NO</span><span class="sxs-lookup"><span data-stu-id="3701e-261">NO</span></span></td>
</tr>
</tbody>
</table>


## <a name="using-a-xaml-brush-vs-compositionbrush"></a><span data-ttu-id="3701e-262">XAML ブラシと CompositionBrush を使用します。</span><span class="sxs-lookup"><span data-stu-id="3701e-262">Using a XAML Brush vs. CompositionBrush</span></span>

<span data-ttu-id="3701e-263">次の表は、シナリオと、UIElement またはアプリケーションで、SpriteVisual を描画するときに XAML または合成ブラシの使用を指定するかどうかの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="3701e-263">The following table provides a list of scenarios and whether XAML or Composition brush use is prescribed when painting a UIElement or a SpriteVisual in your application.</span></span> 

> [!NOTE]
> <span data-ttu-id="3701e-264">CompositionBrush が XAML の UIElement に表示されている場合、XamlCompositionBrushBase を使用して、CompositionBrush をパッケージ化すると見なされます。</span><span class="sxs-lookup"><span data-stu-id="3701e-264">If a CompositionBrush is suggested for a XAML UIElement, it is assumed that the CompositionBrush is packaged using a XamlCompositionBrushBase.</span></span>

|<span data-ttu-id="3701e-265">シナリオ</span><span class="sxs-lookup"><span data-stu-id="3701e-265">Scenario</span></span>                                                                   | <span data-ttu-id="3701e-266">XAML UIElement</span><span class="sxs-lookup"><span data-stu-id="3701e-266">XAML UIElement</span></span>                                                                                                |<span data-ttu-id="3701e-267">合成 SpriteVisual</span><span class="sxs-lookup"><span data-stu-id="3701e-267">Composition SpriteVisual</span></span>
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|<span data-ttu-id="3701e-268">単色で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-268">Paint an area with solid color</span></span>                                             |[<span data-ttu-id="3701e-269">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-269">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="3701e-270">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-270">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="3701e-271">色のアニメーション効果のある領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-271">Paint an area with animated color</span></span>                                          |[<span data-ttu-id="3701e-272">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-272">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="3701e-273">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-273">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="3701e-274">静的なグラデーションを使用して領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-274">Paint an area with a static gradient</span></span>                                       |[<span data-ttu-id="3701e-275">LinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-275">LinearGradientBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[<span data-ttu-id="3701e-276">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-276">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="3701e-277">アニメーション効果のあるグラデーションの分岐点がある領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-277">Paint an area with animated gradient stops</span></span>                                 |[<span data-ttu-id="3701e-278">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-278">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[<span data-ttu-id="3701e-279">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-279">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="3701e-280">画像の領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-280">Paint an area with an image</span></span>                                                |[<span data-ttu-id="3701e-281">ImageBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-281">ImageBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[<span data-ttu-id="3701e-282">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-282">CompositionSurfaceBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|<span data-ttu-id="3701e-283">Web ページの領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-283">Paint an area with a webpage</span></span>                                               |[<span data-ttu-id="3701e-284">WebViewBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-284">WebViewBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |<span data-ttu-id="3701e-285">該当なし</span><span class="sxs-lookup"><span data-stu-id="3701e-285">N/A</span></span>
|<span data-ttu-id="3701e-286">[引き伸ばし] NineGrid を使用してイメージで領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="3701e-286">Paint an area with an image using NineGrid stretch</span></span>                         |[<span data-ttu-id="3701e-287">イメージ コントロール</span><span class="sxs-lookup"><span data-stu-id="3701e-287">Image Control</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[<span data-ttu-id="3701e-288">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-288">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="3701e-289">アニメーション効果のある NineGrid ストレッチで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-289">Paint an area with animated NineGrid stretch</span></span>                               |[<span data-ttu-id="3701e-290">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-290">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[<span data-ttu-id="3701e-291">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-291">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="3701e-292">領域を swapchain を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-292">Paint an area with a swapchain</span></span>                                             |[<span data-ttu-id="3701e-293">SwapChainPanel</span><span class="sxs-lookup"><span data-stu-id="3701e-293">SwapChainPanel</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |<span data-ttu-id="3701e-294">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) swapchain の相互運用性と</span><span class="sxs-lookup"><span data-stu-id="3701e-294">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ swapchain interop</span></span>
|<span data-ttu-id="3701e-295">ビデオを使用して領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-295">Paint an area with a video</span></span>                                                 |[<span data-ttu-id="3701e-296">MediaElement</span><span class="sxs-lookup"><span data-stu-id="3701e-296">MediaElement</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |<span data-ttu-id="3701e-297">メディアの相互運用性と[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)</span><span class="sxs-lookup"><span data-stu-id="3701e-297">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ media interop</span></span>
|<span data-ttu-id="3701e-298">ユーザー設定の 2D 図面で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-298">Paint an area with custom 2D drawing</span></span>                                       |<span data-ttu-id="3701e-299">Win2D から[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm)</span><span class="sxs-lookup"><span data-stu-id="3701e-299">[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm) from Win2D</span></span>                                                                                                 |<span data-ttu-id="3701e-300">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) Win2D の相互運用性と</span><span class="sxs-lookup"><span data-stu-id="3701e-300">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ Win2D interop</span></span>
|<span data-ttu-id="3701e-301">アニメーション化されていないマスクで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-301">Paint an area with non-animated mask</span></span>                                       |<span data-ttu-id="3701e-302">XAML[図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用して、マスクの定義</span><span class="sxs-lookup"><span data-stu-id="3701e-302">Use XAML [shapes](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes) to define a mask</span></span>   |[<span data-ttu-id="3701e-303">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-303">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="3701e-304">アニメーション効果のある定型で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-304">Paint an area with an animated mask</span></span>                                        |[<span data-ttu-id="3701e-305">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-305">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[<span data-ttu-id="3701e-306">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-306">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="3701e-307">フィルターのアニメーション効果が適用された領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-307">Paint an area with an animated filter effect</span></span>                               |[<span data-ttu-id="3701e-308">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-308">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[<span data-ttu-id="3701e-309">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-309">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|<span data-ttu-id="3701e-310">背景のピクセルに適用されている効果が適用された領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="3701e-310">Paint an area with an effect applied to background pixels</span></span>        |[<span data-ttu-id="3701e-311">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-311">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[<span data-ttu-id="3701e-312">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="3701e-312">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a><span data-ttu-id="3701e-313">関連トピック</span><span class="sxs-lookup"><span data-stu-id="3701e-313">Related Topics</span></span>

[<span data-ttu-id="3701e-314">合成ネイティブ DirectX と Direct2D 相互運用性 BeginDraw と EndDraw</span><span class="sxs-lookup"><span data-stu-id="3701e-314">Composition native DirectX and Direct2D interop with BeginDraw and EndDraw</span></span>](composition-native-interop.md)

[<span data-ttu-id="3701e-315">XamlCompositionBrushBase で XAML ブラシの相互運用性</span><span class="sxs-lookup"><span data-stu-id="3701e-315">XAML brush interop with XamlCompositionBrushBase</span></span>](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
