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
# <a name="composition-brushes"></a><span data-ttu-id="b7b0b-105">コンポジションのブラシ</span><span class="sxs-lookup"><span data-stu-id="b7b0b-105">Composition brushes</span></span>
<span data-ttu-id="b7b0b-106">UWP のアプリケーションから、画面に表示できるものは、ブラシによって描画されているために表示されます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-106">Everything visible on your screen from a UWP application is visible because it was painted by a Brush.</span></span> <span data-ttu-id="b7b0b-107">ブラシを使用すると、単純な純色からイメージや複雑なエフェクト チェーンへの描画に至るまでのコンテンツでユーザー インターフェイス (UI) オブジェクトを描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-107">Brushes enable you to paint user interface (UI) objects with content ranging from simple, solid colors to images or drawings to complex effects chain.</span></span> <span data-ttu-id="b7b0b-108">このトピックでは、CompositionBrush を使用してペイントの概念を説明します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-108">This topic introduces the concepts of painting with CompositionBrush.</span></span>

<span data-ttu-id="b7b0b-109">注意してください、XAML UWP のアプリケーションを操作するときの[XAML ブラシ](/windows/uwp/design/style/brushes)または、 [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush)に、UIElement を描画するを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-109">Note, when working with XAML UWP app, you can chose to paint a UIElement with a [XAML Brush](/windows/uwp/design/style/brushes) or a [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush).</span></span> <span data-ttu-id="b7b0b-110">通常、簡単であり、XAML ブラシで、シナリオがサポートされている場合、XAML のブラシを選択することをお勧めです。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-110">Typically, it is easier and advisable to choose a XAML brush if your scenario is supported by a XAML Brush.</span></span> <span data-ttu-id="b7b0b-111">たとえば、テキストまたはイメージを持つ図形の塗りつぶしの変更、ボタンの色をアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-111">For example, animating the color of a button, changing the fill of a text or a shape with an image.</span></span> <span data-ttu-id="b7b0b-112">その一方で場合は、アニメーション化されたマスクやアニメーションの 9 グリッド ストレッチ、エフェクト チェーンを使用してペイントなどの XAML ブラシでサポートされていない処理を実行しようとすることができますを使用する、CompositionBrush[を使用して、UIElement をペイントするにはXamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-112">On the other hand, if you are trying to do something that is not supported by a XAML brush like painting with an animated mask or an animated nine-grid stretch or an effect chain, you can use a CompositionBrush to paint a UIElement through the use of [XamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase).</span></span>

<span data-ttu-id="b7b0b-113">ビジュアル層を使用する場合、 [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual)の領域を描画するのには、CompositionBrush を使用しなければなりません。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-113">When working with the Visual layer, a CompositionBrush must be used to paint the area of a [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual).</span></span>

-   [<span data-ttu-id="b7b0b-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="b7b0b-114">Prerequisites</span></span>](./composition-brushes.md#prerequisites)
-   [<span data-ttu-id="b7b0b-115">CompositionBrush での塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="b7b0b-115">Paint with CompositionBrush</span></span>](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [<span data-ttu-id="b7b0b-116">純色で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-116">Paint with a solid color</span></span>](./composition-brushes.md#paint-with-a-solid-color)
    -   [<span data-ttu-id="b7b0b-117">線形グラデーションで描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-117">Paint with a linear gradient</span></span>](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [<span data-ttu-id="b7b0b-118">イメージで描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-118">Paint with an image</span></span>](./composition-brushes.md#paint-with-an-image)
    -   [<span data-ttu-id="b7b0b-119">カスタム図面で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-119">Paint with a custom drawing</span></span>](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [<span data-ttu-id="b7b0b-120">ビデオで描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-120">Paint with a video</span></span>](./composition-brushes.md#paint-with-a-video)
    -   [<span data-ttu-id="b7b0b-121">フィルター効果で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-121">Paint with a filter effect</span></span>](./composition-brushes.md#paint-with-a-filter-effect)
    -   [<span data-ttu-id="b7b0b-122">不透明マスクで、CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-122">Paint with a CompositionBrush with an opacity mask</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [<span data-ttu-id="b7b0b-123">NineGrid ストレッチを使用して、CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-123">Paint with a CompositionBrush using NineGrid stretch</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [<span data-ttu-id="b7b0b-124">背景のピクセルを使用してペイントします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-124">Paint using Background Pixels</span></span>](./composition-brushes.md#paint-using-background-pixels)
-   [<span data-ttu-id="b7b0b-125">CompositionBrushes を組み合わせること。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-125">Combining CompositionBrushes</span></span>](./composition-brushes.md#combining-compositionbrushes)
-   [<span data-ttu-id="b7b0b-126">XAML ブラシと CompositionBrush を使用してください。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-126">Using a XAML Brush vs. CompositionBrush</span></span>](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [<span data-ttu-id="b7b0b-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b7b0b-127">Related Topics</span></span>](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a><span data-ttu-id="b7b0b-128">前提条件</span><span class="sxs-lookup"><span data-stu-id="b7b0b-128">Prerequisites</span></span>
<span data-ttu-id="b7b0b-129">この概要では、熟知している、基本的な構成アプリケーションの構造を[ビジュアル層の概要](visual-layer.md)で説明したように想定しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-129">This overview assumes that you are familiar with the structure of a basic Composition application, as described in the [Visual layer overview](visual-layer.md).</span></span>

## <a name="paint-with-a-compositionbrush"></a><span data-ttu-id="b7b0b-130">CompositionBrush での塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="b7b0b-130">Paint with a CompositionBrush</span></span>

<span data-ttu-id="b7b0b-131">[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) 「描画」の出力を使用して領域。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-131">A [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) "paints" an area with its output.</span></span> <span data-ttu-id="b7b0b-132">さまざまなブラシで、出力の種類もさまざまです。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-132">Different brushes have different types of output.</span></span> <span data-ttu-id="b7b0b-133">純色、グラデーション、イメージ、カスタムの描画、または効果を持つ他のユーザーを使用して領域を塗りつぶすブラシ。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-133">Some brushes paint an area with a solid color, others with a gradient, image, custom drawing, or effect.</span></span> <span data-ttu-id="b7b0b-134">その他のブラシの動作を変更する専用のブラシが用意されています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-134">There are also specialized brushes that modify the behavior of other brushes.</span></span> <span data-ttu-id="b7b0b-135">によって、CompositionBrush では、描画領域を制御する不透明度マスクを使用することができますなど、領域を塗りつぶすときに、CompositionBrush に適用するストレッチを制御する 9 グリッドを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-135">For example, opacity mask can be used to control which area is painted by a CompositionBrush, or a nine-grid can be used to control the stretch applied to a CompositionBrush when painting an area.</span></span> <span data-ttu-id="b7b0b-136">CompositionBrush は、次の種類のいずれかのできます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-136">CompositionBrush can be of one of the following types:</span></span>

|<span data-ttu-id="b7b0b-137">クラス</span><span class="sxs-lookup"><span data-stu-id="b7b0b-137">Class</span></span>                                   |<span data-ttu-id="b7b0b-138">詳細</span><span class="sxs-lookup"><span data-stu-id="b7b0b-138">Details</span></span>                                         |<span data-ttu-id="b7b0b-139">導入されました。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-139">Introduced In</span></span>|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[<span data-ttu-id="b7b0b-140">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-140">CompositionColorBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |<span data-ttu-id="b7b0b-141">純色で領域を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="b7b0b-141">Paints an area with a solid color</span></span>                        |<span data-ttu-id="b7b0b-142">Windows10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-142">Windows10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="b7b0b-143">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-143">CompositionSurfaceBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |<span data-ttu-id="b7b0b-144">[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)の内容を使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-144">Paints an area with the contents of an [ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)</span></span>|<span data-ttu-id="b7b0b-145">Windows10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-145">Windows10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="b7b0b-146">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-146">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |<span data-ttu-id="b7b0b-147">合成効果の内容を使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-147">Paints an area with the contents of a composition effect</span></span> |<span data-ttu-id="b7b0b-148">Windows10 年 11 月の更新プログラム (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-148">Windows10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="b7b0b-149">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-149">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |<span data-ttu-id="b7b0b-150">不透明マスクで、CompositionBrush のビジュアルを描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-150">Paints a visual with a CompositionBrush with an opacity mask</span></span> |<span data-ttu-id="b7b0b-151">Windows10 記念日の更新プログラム (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-151">Windows10 Anniversary Update (SDK 14393)</span></span>
|[<span data-ttu-id="b7b0b-152">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-152">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |<span data-ttu-id="b7b0b-153">NineGrid ストレッチを使用して、CompositionBrush の領域を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="b7b0b-153">Paints an area with a CompositionBrush using a NineGrid stretch</span></span> |<span data-ttu-id="b7b0b-154">Windows10 記念更新 SDK (14393)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-154">Windows10 Anniversary Update SDK (14393)</span></span>
|[<span data-ttu-id="b7b0b-155">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-155">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|<span data-ttu-id="b7b0b-156">線形グラデーションで領域を塗りつぶします</span><span class="sxs-lookup"><span data-stu-id="b7b0b-156">Paints an area with a linear gradient</span></span>                    |<span data-ttu-id="b7b0b-157">Windows 10 作成者の更新プログラム (内部関係者によるプレビュー SDK) の分類</span><span class="sxs-lookup"><span data-stu-id="b7b0b-157">Windows 10 Fall Creators Update (Insider Preview SDK)</span></span>
|[<span data-ttu-id="b7b0b-158">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-158">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |<span data-ttu-id="b7b0b-159">背景のピクセルのいずれかのアプリケーションまたはデスクトップ上のアプリケーションのウィンドウの背後にあるピクセルをサンプリングして領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-159">Paints an area by sampling background pixels from either the application or pixels directly behind the application's window on desktop.</span></span> <span data-ttu-id="b7b0b-160">CompositionEffectBrush のような他の CompositionBrush への入力として使用</span><span class="sxs-lookup"><span data-stu-id="b7b0b-160">Used as an input to another CompositionBrush like a CompositionEffectBrush</span></span> | <span data-ttu-id="b7b0b-161">Windows 10 記念日の更新プログラム (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-161">Windows 10 Anniversary Update (SDK 14393)</span></span>

### <a name="paint-with-a-solid-color"></a><span data-ttu-id="b7b0b-162">純色で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-162">Paint with a solid color</span></span>

<span data-ttu-id="b7b0b-163">の[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)では、純色で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-163">A [CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush) paints an area with a solid color.</span></span> <span data-ttu-id="b7b0b-164">さまざまな、SolidColorBrush の色を指定する方法があります。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-164">There are a variety of ways to specify the color of a SolidColorBrush.</span></span> <span data-ttu-id="b7b0b-165">など、アルファ、赤、青、および緑 (ARGB) のチャネルを指定したり、[色](https://docs.microsoft.com/uwp/api/windows.ui.colors)クラスによって提供される定義済みの色のいずれかを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-165">For example, you can specify its alpha, red, blue, and green (ARGB) channels or use one of the predefined colors provided by the [Colors](https://docs.microsoft.com/uwp/api/windows.ui.colors) class.</span></span>

<span data-ttu-id="b7b0b-166">次の図とコードは、黒の色ブラシで描かれた四角形を、色の値が 0x9ACD32 である単色ブラシで塗りつぶす小規模なビジュアル ツリーを示しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-166">The following illustration and code shows a small visual tree to create a rectangle that is stroked with a black color brush and painted with a solid color brush that has the color value of 0x9ACD32.</span></span>

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

### <a name="paint-with-a-linear-gradient"></a><span data-ttu-id="b7b0b-168">線形グラデーションで描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-168">Paint with a linear gradient</span></span>

<span data-ttu-id="b7b0b-169">の[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)では、線形グラデーションで領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-169">A [CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush) paints an area with a linear gradient.</span></span> <span data-ttu-id="b7b0b-170">線形グラデーションは、グラデーション軸の行の間で 2 つ以上の色をブレンドします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-170">A linear gradient blends two or more colors across a line, the gradient axis.</span></span> <span data-ttu-id="b7b0b-171">GradientStop オブジェクトを使用するにはグラデーションとその位置の色を指定します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-171">You use GradientStop objects to specify the colors in the gradient and their positions.</span></span>

<span data-ttu-id="b7b0b-172">次の図とコードは、赤と黄色の色を使用して 2 つの停止と、なりますと描画の SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-172">The following illustration and code shows a SpriteVisual painted with a LinearGradientBrush with 2 stops using a red and yellow color.</span></span>

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

### <a name="paint-with-an-image"></a><span data-ttu-id="b7b0b-174">イメージで描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-174">Paint with an image</span></span>

<span data-ttu-id="b7b0b-175">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) ICompositionSurface の上にレンダリングされるピクセルで領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-175">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) paints an area with pixels rendered onto an ICompositionSurface.</span></span> <span data-ttu-id="b7b0b-176">たとえば、 [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API を使用して、ICompositionSurface 画面にレンダリングされたイメージで領域を塗りつぶすには CompositionSurfaceBrush を使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-176">For example, a CompositionSurfaceBrush can be used to paint an area with an image rendered onto an ICompositionSurface surface using [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API.</span></span>

<span data-ttu-id="b7b0b-177">次の図とコードは、SpriteVisual が LoadedImageSurface を使用して、ICompositionSurface 上に表示される、licorice のビットマップを描画を示します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-177">The following illustration and code shows a SpriteVisual painted with a bitmap of a licorice rendered onto an ICompositionSurface using LoadedImageSurface.</span></span> <span data-ttu-id="b7b0b-178">拡大し、ビジュアルの境界内のビットマップを配置するのには、CompositionSurfaceBrush のプロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-178">The properties of CompositionSurfaceBrush can be used to stretch and align the bitmap within the bounds of the visual.</span></span>

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

### <a name="paint-with-a-custom-drawing"></a><span data-ttu-id="b7b0b-180">カスタム図面で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-180">Paint with a custom drawing</span></span>
<span data-ttu-id="b7b0b-181">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) ICompositionSurface [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (D2D) を使用してレンダリングされるピクセルで領域を塗りつぶすにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-181">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using [Win2D](http://microsoft.github.io/Win2D/html/Introduction.htm) (or D2D).</span></span>

<span data-ttu-id="b7b0b-182">次のコードは、Win2D を使用して、SpriteVisual は、ICompositionSurface 上にレンダリングされたテキストの描画を示します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-182">The following code shows a SpriteVisual painted with a text run rendered onto an ICompositionSurface using Win2D.</span></span> <span data-ttu-id="b7b0b-183">[Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp)パッケージをプロジェクトに挿入する必要があります Win2D を使用するためにメモします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-183">Note, in order to use Win2D you need to include the [Win2D NuGet](http://www.nuget.org/packages/Win2D.uwp) package into your project.</span></span>

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

<span data-ttu-id="b7b0b-184">同様に、CompositionSurfaceBrush は、SpriteVisual と Win2D の相互運用機能を使用しての SwapChain の描画にも使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-184">Similarly, the CompositionSurfaceBrush can also be used to paint a SpriteVisual with a SwapChain using Win2D interop.</span></span> <span data-ttu-id="b7b0b-185">[このサンプル](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を SpriteVisual、swapchain での描画に使用する方法の例を提供します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-185">[This sample](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample) provides an example of how to use Win2D to paint a SpriteVisual with a swapchain.</span></span>

### <a name="paint-with-a-video"></a><span data-ttu-id="b7b0b-186">ビデオで描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-186">Paint with a video</span></span>
<span data-ttu-id="b7b0b-187">の[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)は、 [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer)クラスによって読み込まれたビデオを使用してレンダリング、ICompositionSurface からのピクセル単位で領域を塗りつぶすにも使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-187">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using a video loaded through the [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) class.</span></span>

<span data-ttu-id="b7b0b-188">次のコードは、SpriteVisual は、ICompositionSurface にロードされているビデオを使用して描画を示しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-188">The following code shows a SpriteVisual painted with a video loaded onto an ICompositionSurface.</span></span>

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

### <a name="paint-with-a-filter-effect"></a><span data-ttu-id="b7b0b-189">フィルター効果で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-189">Paint with a filter effect</span></span>

<span data-ttu-id="b7b0b-190">[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) CompositionEffect の出力を使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-190">A [CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) paints an area with output of a CompositionEffect.</span></span> <span data-ttu-id="b7b0b-191">ビジュアル層でのエフェクトは、アニメーション化可能なフィルター効果の色、グラデーション、イメージ、ビデオ、swapchains、UI の領域またはビジュアルの木などのソースのコンテンツのコレクションに適用されると考えることがあります。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-191">Effects in the Visual Layer may be thought of as animatable filter effects applied to a collection of source content such as colors, gradients, images, videos, swapchains, regions of your UI, or trees of Visuals.</span></span> <span data-ttu-id="b7b0b-192">ソースのコンテンツを別の CompositionBrush を使用して提供します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-192">The source content is typically specified using another CompositionBrush.</span></span>

<span data-ttu-id="b7b0b-193">次の図とコードは、彩度を下げて光沢フィルター効果のある猫のイメージでペイントの SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-193">The following illustration and code shows a SpriteVisual painted with an image of a cat that has desaturation filter effect applied.</span></span>

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

<span data-ttu-id="b7b0b-195">CompositionBrushes を使用してエフェクトを作成する方法の詳細については、[ビジュアル層でのエフェクト](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-195">For more information on creating an Effect using CompositionBrushes see [Effects in Visual layer](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)</span></span>

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a><span data-ttu-id="b7b0b-196">不透明度マスクが適用された、CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-196">Paint with a CompositionBrush with opacity mask applied</span></span>

<span data-ttu-id="b7b0b-197">の[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)では、不透明マスクが適用されていると、CompositionBrush を使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-197">A [CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush) paints an area with a CompositionBrush with an opacity mask applied to it.</span></span> <span data-ttu-id="b7b0b-198">不透明度マスクの元のタイプ CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、または CompositionNineGridBrush、CompositionBrush ができます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-198">The source of the opacity mask can be any CompositionBrush of type CompositionColorBrush, CompositionLinearGradientBrush, CompositionSurfaceBrush, CompositionEffectBrush, or CompositionNineGridBrush.</span></span> <span data-ttu-id="b7b0b-199">CompositionSurfaceBrush として、不透明度マスクを指定してください。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-199">The opacity mask must be specified as a CompositionSurfaceBrush.</span></span>

<span data-ttu-id="b7b0b-200">次の図とコードは、SpriteVisual、CompositionMaskBrush で描画を示しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-200">The following illustration and code shows a SpriteVisual painted with a CompositionMaskBrush.</span></span> <span data-ttu-id="b7b0b-201">マスクのソースは、円のイメージをマスクとして使用する円のようにマスクされている CompositionLinearGradientBrush です。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-201">The source of the mask is a CompositionLinearGradientBrush which is masked to look like a circle using an image of circle as a mask.</span></span>

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

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a><span data-ttu-id="b7b0b-203">NineGrid ストレッチを使用して、CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-203">Paint with a CompositionBrush using NineGrid stretch</span></span>

<span data-ttu-id="b7b0b-204">の[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)は、9 グリッドのメタファを使用して伸縮する CompositionBrush を使用して領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-204">A [CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) paints an area with a CompositionBrush that is stretched using the nine-grid metaphor.</span></span> <span data-ttu-id="b7b0b-205">9 グリッドのメタファを使用すると、中心よりも、CompositionBrush の端および角を異なる方法で拡大できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-205">The nine-grid metaphor enables you to stretch edges and corners of a CompositionBrush differently than its center.</span></span> <span data-ttu-id="b7b0b-206">9 グリッド ストレッチのソースは、任意のタイプ CompositionColorBrush の CompositionBrush、CompositionSurfaceBrush、または CompositionEffectBrush でことができます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-206">The source of the nine-grid stretch can by any CompositionBrush of type CompositionColorBrush, CompositionSurfaceBrush, or CompositionEffectBrush.</span></span>

<span data-ttu-id="b7b0b-207">次のコードは、SpriteVisual は、CompositionNineGridBrush で描画を示しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-207">The following code shows a SpriteVisual painted with a CompositionNineGridBrush.</span></span> <span data-ttu-id="b7b0b-208">マスクのソースは、9 のグリッドを使用して伸縮する CompositionSurfaceBrush です。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-208">The source of the mask is a CompositionSurfaceBrush which is stretched using a Nine-Grid.</span></span>

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

### <a name="paint-using-background-pixels"></a><span data-ttu-id="b7b0b-209">背景のピクセルを使用してペイントします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-209">Paint using Background Pixels</span></span>

<span data-ttu-id="b7b0b-210">の[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)は、領域の背後にあるコンテンツで領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-210">A [CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)  paints an area with the content behind the area.</span></span> <span data-ttu-id="b7b0b-211">CompositionBackdropBrush を独自に使用されることはありませんが、代わりに、EffectBrush のような他の CompositionBrush への入力として使用されます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-211">A CompositionBackdropBrush is never used on its own, but instead is used as an input to another CompositionBrush like an EffectBrush.</span></span> <span data-ttu-id="b7b0b-212">たとえば、ぼかしの効果への入力として、CompositionBackdropBrush を使用して、すりガラス効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-212">For example, by using a CompositionBackdropBrush as an input to a Blur effect, you can achieve a frosted glass effect.</span></span>

<span data-ttu-id="b7b0b-213">次のコードは、CompositionSurfaceBrush と画像の上のすりガラスのオーバーレイを使用してイメージを作成する小規模のビジュアル ツリーを示しています。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-213">The following code shows a small visual tree to create an image using CompositionSurfaceBrush and a frosted glass overlay above the image.</span></span> <span data-ttu-id="b7b0b-214">すりガラスのオーバーレイは、画像の上に EffectBrush を入力する SpriteVisual を配置することによって作成されます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-214">The frosted glass overlay is created by placing a SpriteVisual filled with an EffectBrush above the image.</span></span> <span data-ttu-id="b7b0b-215">EffectBrush では、ぼかしの効果への入力として、CompositionBackdropBrush を使用します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-215">The EffectBrush uses a CompositionBackdropBrush as an input to the blur effect.</span></span>

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

## <a name="combining-compositionbrushes"></a><span data-ttu-id="b7b0b-216">CompositionBrushes を組み合わせること。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-216">Combining CompositionBrushes</span></span>
<span data-ttu-id="b7b0b-217">CompositionBrushes の数値は、入力として他の CompositionBrushes を使用します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-217">A number of CompositionBrushes use other CompositionBrushes as inputs.</span></span> <span data-ttu-id="b7b0b-218">など、CompositionEffectBrush への入力として、別の CompositionBrush を設定するには、SetSourceParameter メソッドを使用するを使用できます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-218">For example, using the SetSourceParameter method can be used to set another CompositionBrush as an input to a CompositionEffectBrush.</span></span> <span data-ttu-id="b7b0b-219">CompositionBrushes のサポートされている組み合わせを次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-219">The table below outlines the supported combinations of CompositionBrushes.</span></span> <span data-ttu-id="b7b0b-220">サポートされていない組み合わせを使用すると例外がスローされることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-220">Note, that using an unsupported combination will throw an exception.</span></span>

<table>
<tbody>
<tr>
<th><span data-ttu-id="b7b0b-221">Brush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-221">Brush</span></span></th>
<th><span data-ttu-id="b7b0b-222">EffectBrush.SetSourceParameter()</span><span class="sxs-lookup"><span data-stu-id="b7b0b-222">EffectBrush.SetSourceParameter()</span></span></th>
<th><span data-ttu-id="b7b0b-223">MaskBrush.Mask</span><span class="sxs-lookup"><span data-stu-id="b7b0b-223">MaskBrush.Mask</span></span></th>
<th><span data-ttu-id="b7b0b-224">MaskBrush.Source</span><span class="sxs-lookup"><span data-stu-id="b7b0b-224">MaskBrush.Source</span></span></th>
<th><span data-ttu-id="b7b0b-225">NineGridBrush.Source</span><span class="sxs-lookup"><span data-stu-id="b7b0b-225">NineGridBrush.Source</span></span></th>
</tr>
<tr>
<td><span data-ttu-id="b7b0b-226">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-226">CompositionColorBrush</span></span></td>
<td><span data-ttu-id="b7b0b-227">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-227">YES</span></span></td>
<td><span data-ttu-id="b7b0b-228">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-228">YES</span></span></td>
<td><span data-ttu-id="b7b0b-229">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-229">YES</span></span></td>
<td><span data-ttu-id="b7b0b-230">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-230">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="b7b0b-231">CompositionLinear</span><span class="sxs-lookup"><span data-stu-id="b7b0b-231">CompositionLinear</span></span><br /><span data-ttu-id="b7b0b-232">GradientBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-232">GradientBrush</span></span></td>
<td><span data-ttu-id="b7b0b-233">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-233">YES</span></span></td>
<td><span data-ttu-id="b7b0b-234">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-234">YES</span></span></td>
<td><span data-ttu-id="b7b0b-235">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-235">YES</span></span></td>
<td><span data-ttu-id="b7b0b-236">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-236">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="b7b0b-237">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-237">CompositionSurfaceBrush</span></span></td>
<td><span data-ttu-id="b7b0b-238">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-238">YES</span></span></td>
<td><span data-ttu-id="b7b0b-239">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-239">YES</span></span></td>
<td><span data-ttu-id="b7b0b-240">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-240">YES</span></span></td>
<td><span data-ttu-id="b7b0b-241">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-241">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="b7b0b-242">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-242">CompositionEffectBrush</span></span></td>
<td><span data-ttu-id="b7b0b-243">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-243">NO</span></span></td>
<td><span data-ttu-id="b7b0b-244">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-244">NO</span></span></td>
<td><span data-ttu-id="b7b0b-245">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-245">YES</span></span></td>
<td><span data-ttu-id="b7b0b-246">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-246">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="b7b0b-247">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-247">CompositionMaskBrush</span></span></td>
<td><span data-ttu-id="b7b0b-248">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-248">NO</span></span></td>
<td><span data-ttu-id="b7b0b-249">使用不可</span><span class="sxs-lookup"><span data-stu-id="b7b0b-249">NO</span></span></td>
<td><span data-ttu-id="b7b0b-250">使用不可</span><span class="sxs-lookup"><span data-stu-id="b7b0b-250">NO</span></span></td>
<td><span data-ttu-id="b7b0b-251">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-251">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="b7b0b-252">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-252">CompositionNineGridBrush</span></span></td>
<td><span data-ttu-id="b7b0b-253">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-253">YES</span></span></td>
<td><span data-ttu-id="b7b0b-254">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-254">YES</span></span></td>
<td><span data-ttu-id="b7b0b-255">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-255">YES</span></span></td>
<td><span data-ttu-id="b7b0b-256">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-256">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="b7b0b-257">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-257">CompositionBackdropBrush</span></span></td>
<td><span data-ttu-id="b7b0b-258">使用可能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-258">YES</span></span></td>
<td><span data-ttu-id="b7b0b-259">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-259">NO</span></span></td>
<td><span data-ttu-id="b7b0b-260">使用不可</span><span class="sxs-lookup"><span data-stu-id="b7b0b-260">NO</span></span></td>
<td><span data-ttu-id="b7b0b-261">NO</span><span class="sxs-lookup"><span data-stu-id="b7b0b-261">NO</span></span></td>
</tr>
</tbody>
</table>


## <a name="using-a-xaml-brush-vs-compositionbrush"></a><span data-ttu-id="b7b0b-262">XAML ブラシと CompositionBrush を使用してください。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-262">Using a XAML Brush vs. CompositionBrush</span></span>

<span data-ttu-id="b7b0b-263">次の表は、シナリオと、UIElement またはアプリケーションで、SpriteVisual を描画するときに XAML またはコンポジションのブラシの使用を規定するかどうかの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-263">The following table provides a list of scenarios and whether XAML or Composition brush use is prescribed when painting a UIElement or a SpriteVisual in your application.</span></span> 

> [!NOTE]
> <span data-ttu-id="b7b0b-264">XAML UIElement の提案は、CompositionBrush、XamlCompositionBrushBase を使用して、CompositionBrush がパッケージされていると見なされます。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-264">If a CompositionBrush is suggested for a XAML UIElement, it is assumed that the CompositionBrush is packaged using a XamlCompositionBrushBase.</span></span>

|<span data-ttu-id="b7b0b-265">シナリオ</span><span class="sxs-lookup"><span data-stu-id="b7b0b-265">Scenario</span></span>                                                                   | <span data-ttu-id="b7b0b-266">XAML UIElement</span><span class="sxs-lookup"><span data-stu-id="b7b0b-266">XAML UIElement</span></span>                                                                                                |<span data-ttu-id="b7b0b-267">コンポジション SpriteVisual</span><span class="sxs-lookup"><span data-stu-id="b7b0b-267">Composition SpriteVisual</span></span>
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|<span data-ttu-id="b7b0b-268">純色で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-268">Paint an area with solid color</span></span>                                             |[<span data-ttu-id="b7b0b-269">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-269">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="b7b0b-270">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-270">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="b7b0b-271">アニメーションの色で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-271">Paint an area with animated color</span></span>                                          |[<span data-ttu-id="b7b0b-272">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-272">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="b7b0b-273">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-273">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="b7b0b-274">静的なグラデーションで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-274">Paint an area with a static gradient</span></span>                                       |[<span data-ttu-id="b7b0b-275">LinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-275">LinearGradientBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[<span data-ttu-id="b7b0b-276">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-276">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="b7b0b-277">アニメーションのグラデーションで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-277">Paint an area with animated gradient stops</span></span>                                 |[<span data-ttu-id="b7b0b-278">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-278">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[<span data-ttu-id="b7b0b-279">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-279">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="b7b0b-280">イメージで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-280">Paint an area with an image</span></span>                                                |[<span data-ttu-id="b7b0b-281">ImageBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-281">ImageBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[<span data-ttu-id="b7b0b-282">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-282">CompositionSurfaceBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|<span data-ttu-id="b7b0b-283">Web ページで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-283">Paint an area with a webpage</span></span>                                               |[<span data-ttu-id="b7b0b-284">WebViewBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-284">WebViewBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |<span data-ttu-id="b7b0b-285">該当なし</span><span class="sxs-lookup"><span data-stu-id="b7b0b-285">N/A</span></span>
|<span data-ttu-id="b7b0b-286">NineGrid ストレッチを使用してイメージで領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-286">Paint an area with an image using NineGrid stretch</span></span>                         |[<span data-ttu-id="b7b0b-287">イメージ コントロール</span><span class="sxs-lookup"><span data-stu-id="b7b0b-287">Image Control</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[<span data-ttu-id="b7b0b-288">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-288">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="b7b0b-289">アニメーションの NineGrid ストレッチで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-289">Paint an area with animated NineGrid stretch</span></span>                               |[<span data-ttu-id="b7b0b-290">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-290">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[<span data-ttu-id="b7b0b-291">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-291">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="b7b0b-292">Swapchain で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-292">Paint an area with a swapchain</span></span>                                             |[<span data-ttu-id="b7b0b-293">SwapChainPanel</span><span class="sxs-lookup"><span data-stu-id="b7b0b-293">SwapChainPanel</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |<span data-ttu-id="b7b0b-294">Swapchain の相互運用機能付き[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-294">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ swapchain interop</span></span>
|<span data-ttu-id="b7b0b-295">ビデオで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-295">Paint an area with a video</span></span>                                                 |[<span data-ttu-id="b7b0b-296">MediaElement</span><span class="sxs-lookup"><span data-stu-id="b7b0b-296">MediaElement</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |<span data-ttu-id="b7b0b-297">メディアの相互運用機能付き[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-297">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ media interop</span></span>
|<span data-ttu-id="b7b0b-298">カスタムの 2 D 図面で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-298">Paint an area with custom 2D drawing</span></span>                                       |<span data-ttu-id="b7b0b-299">Win2D から[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-299">[CanvasControl](http://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm) from Win2D</span></span>                                                                                                 |<span data-ttu-id="b7b0b-300">Win2D の相互運用機能付き[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415)</span><span class="sxs-lookup"><span data-stu-id="b7b0b-300">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ Win2D interop</span></span>
|<span data-ttu-id="b7b0b-301">マスクをアニメーション化されていない領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-301">Paint an area with non-animated mask</span></span>                                       |<span data-ttu-id="b7b0b-302">マスクを定義する XAML の[図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-302">Use XAML [shapes](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes) to define a mask</span></span>   |[<span data-ttu-id="b7b0b-303">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-303">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="b7b0b-304">アニメーション化されたマスクを使用して領域を塗りつぶす. します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-304">Paint an area with an animated mask</span></span>                                        |[<span data-ttu-id="b7b0b-305">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-305">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[<span data-ttu-id="b7b0b-306">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-306">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="b7b0b-307">フィルターのアニメーション効果が適用された領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="b7b0b-307">Paint an area with an animated filter effect</span></span>                               |[<span data-ttu-id="b7b0b-308">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-308">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[<span data-ttu-id="b7b0b-309">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-309">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|<span data-ttu-id="b7b0b-310">背景のピクセルに適用される効果で領域を描画します。</span><span class="sxs-lookup"><span data-stu-id="b7b0b-310">Paint an area with an effect applied to background pixels</span></span>        |[<span data-ttu-id="b7b0b-311">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-311">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[<span data-ttu-id="b7b0b-312">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="b7b0b-312">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a><span data-ttu-id="b7b0b-313">関連トピック</span><span class="sxs-lookup"><span data-stu-id="b7b0b-313">Related Topics</span></span>

[<span data-ttu-id="b7b0b-314">コンポジション ネイティブ DirectX および Direct2D との相互運用 BeginDraw と EndDraw</span><span class="sxs-lookup"><span data-stu-id="b7b0b-314">Composition native DirectX and Direct2D interop with BeginDraw and EndDraw</span></span>](composition-native-interop.md)

[<span data-ttu-id="b7b0b-315">XAML ブラシ XamlCompositionBrushBase との相互運用機能</span><span class="sxs-lookup"><span data-stu-id="b7b0b-315">XAML brush interop with XamlCompositionBrushBase</span></span>](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
