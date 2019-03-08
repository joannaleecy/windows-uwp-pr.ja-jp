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
# <a name="composition-brushes"></a><span data-ttu-id="4f46a-105">コンポジションのブラシ</span><span class="sxs-lookup"><span data-stu-id="4f46a-105">Composition brushes</span></span>
<span data-ttu-id="4f46a-106">UWP アプリケーションで画面に表示されるすべての情報は、ブラシによって塗りつぶされることによって表示されます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-106">Everything visible on your screen from a UWP application is visible because it was painted by a Brush.</span></span> <span data-ttu-id="4f46a-107">ブラシを使用すると、シンプルで単色のカラーからイメージや描画を複雑なエフェクト チェーンまで、さまざまなコンテンツを使用してユーザー インターフェイス (UI) オブジェクトを塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-107">Brushes enable you to paint user interface (UI) objects with content ranging from simple, solid colors to images or drawings to complex effects chain.</span></span> <span data-ttu-id="4f46a-108">このトピックでは、CompositionBrush を使用した塗りつぶしの概念を紹介します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-108">This topic introduces the concepts of painting with CompositionBrush.</span></span>

<span data-ttu-id="4f46a-109">注: XAML UWP アプリを扱う場合、[XAML ブラシ](/windows/uwp/design/style/brushes)または [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) を使用して UIElement を塗りつぶすことができます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-109">Note, when working with XAML UWP app, you can chose to paint a UIElement with a [XAML Brush](/windows/uwp/design/style/brushes) or a [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush).</span></span> <span data-ttu-id="4f46a-110">通常、自分のシナリオが XAML ブラシでサポートされている場合、XAML ブラシを選択する方が簡単であるため、この方法をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-110">Typically, it is easier and advisable to choose a XAML brush if your scenario is supported by a XAML Brush.</span></span> <span data-ttu-id="4f46a-111">たとえば、ボタンの色をアニメーション化する場合や、画像を使用してテキストや図形の塗りつぶしを変更する場合です。</span><span class="sxs-lookup"><span data-stu-id="4f46a-111">For example, animating the color of a button, changing the fill of a text or a shape with an image.</span></span> <span data-ttu-id="4f46a-112">その一方で、なアニメーションのマスクまたはアニメーションの 9 グリッド stretch、効果のチェーンでの描画などの XAML のブラシでサポートされていない操作を行う場合、CompositionBrush する際の使用により UIElement を描画[XamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase)します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-112">On the other hand, if you are trying to do something that is not supported by a XAML brush like painting with an animated mask or an animated nine-grid stretch or an effect chain, you can use a CompositionBrush to paint a UIElement through the use of [XamlCompositionBrushBase](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.xamlcompositionbrushbase).</span></span>

<span data-ttu-id="4f46a-113">ビジュアル レイヤーを扱う場合、CompositionBrush を使用して [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual) の領域を塗りつぶす必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f46a-113">When working with the Visual layer, a CompositionBrush must be used to paint the area of a [SpriteVisual](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.SpriteVisual).</span></span>

-   [<span data-ttu-id="4f46a-114">前提条件</span><span class="sxs-lookup"><span data-stu-id="4f46a-114">Prerequisites</span></span>](./composition-brushes.md#prerequisites)
-   [<span data-ttu-id="4f46a-115">CompositionBrush での塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-115">Paint with CompositionBrush</span></span>](./composition-brushes.md#paint-with-a-compositionbrush)
    -   [<span data-ttu-id="4f46a-116">純色で描画します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-116">Paint with a solid color</span></span>](./composition-brushes.md#paint-with-a-solid-color)
    -   [<span data-ttu-id="4f46a-117">線形グラデーションで塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-117">Paint with a linear gradient</span></span>](./composition-brushes.md#paint-with-a-linear-gradient)
    -   [<span data-ttu-id="4f46a-118">イメージで描画します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-118">Paint with an image</span></span>](./composition-brushes.md#paint-with-an-image)
    -   [<span data-ttu-id="4f46a-119">カスタム描画で塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-119">Paint with a custom drawing</span></span>](./composition-brushes.md#paint-with-a-custom-drawing)
    -   [<span data-ttu-id="4f46a-120">ビデオを描画します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-120">Paint with a video</span></span>](./composition-brushes.md#paint-with-a-video)
    -   [<span data-ttu-id="4f46a-121">フィルター効果で描画します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-121">Paint with a filter effect</span></span>](./composition-brushes.md#paint-with-a-filter-effect)
    -   [<span data-ttu-id="4f46a-122">不透明度マスクを持つ、CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-122">Paint with a CompositionBrush with an opacity mask</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-with-opacity-mask-applied)
    -   [<span data-ttu-id="4f46a-123">NineGrid stretch を使用して CompositionBrush で描画します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-123">Paint with a CompositionBrush using NineGrid stretch</span></span>](./composition-brushes.md#paint-with-a-compositionbrush-using-ninegrid-stretch)
    -   [<span data-ttu-id="4f46a-124">バック グラウンドのピクセルを使用して描画します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-124">Paint using Background Pixels</span></span>](./composition-brushes.md#paint-using-background-pixels)
-   [<span data-ttu-id="4f46a-125">結合 CompositionBrushes</span><span class="sxs-lookup"><span data-stu-id="4f46a-125">Combining CompositionBrushes</span></span>](./composition-brushes.md#combining-compositionbrushes)
-   [<span data-ttu-id="4f46a-126">XAML のブラシ vs を使用します。CompositionBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-126">Using a XAML Brush vs. CompositionBrush</span></span>](./composition-brushes.md#using-a-xaml-brush-vs-compositionbrush)
-   [<span data-ttu-id="4f46a-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4f46a-127">Related Topics</span></span>](./composition-brushes.md#related-topics)

## <a name="prerequisites"></a><span data-ttu-id="4f46a-128">前提条件</span><span class="sxs-lookup"><span data-stu-id="4f46a-128">Prerequisites</span></span>
<span data-ttu-id="4f46a-129">この概要では、「[ビジュアル レイヤーの概要](visual-layer.md)」で説明されているように、基本的なコンポジション アプリケーションの構造を理解していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-129">This overview assumes that you are familiar with the structure of a basic Composition application, as described in the [Visual layer overview](visual-layer.md).</span></span>

## <a name="paint-with-a-compositionbrush"></a><span data-ttu-id="4f46a-130">CompositionBrush による塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-130">Paint with a CompositionBrush</span></span>

<span data-ttu-id="4f46a-131">[CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) は、その出力で領域を "塗りつぶします"。</span><span class="sxs-lookup"><span data-stu-id="4f46a-131">A [CompositionBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBrush) "paints" an area with its output.</span></span> <span data-ttu-id="4f46a-132">さまざまなブラシで、出力の種類もさまざまです。</span><span class="sxs-lookup"><span data-stu-id="4f46a-132">Different brushes have different types of output.</span></span> <span data-ttu-id="4f46a-133">ブラシは、単色、グラデーション、画像、カスタム描画、効果を使用して領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-133">Some brushes paint an area with a solid color, others with a gradient, image, custom drawing, or effect.</span></span> <span data-ttu-id="4f46a-134">その他のブラシの動作を変更する特殊なブラシも用意されています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-134">There are also specialized brushes that modify the behavior of other brushes.</span></span> <span data-ttu-id="4f46a-135">たとえば、不透明度マスクを使用して、CompositionBrush によって塗りつぶされる領域を制御することや、9 グリッドを使用して、領域を描画するときに、CompositionBrush に適用されるストレッチを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-135">For example, opacity mask can be used to control which area is painted by a CompositionBrush, or a nine-grid can be used to control the stretch applied to a CompositionBrush when painting an area.</span></span> <span data-ttu-id="4f46a-136">CompositionBrush は次の種類のいずれかです。</span><span class="sxs-lookup"><span data-stu-id="4f46a-136">CompositionBrush can be of one of the following types:</span></span>

|<span data-ttu-id="4f46a-137">クラス</span><span class="sxs-lookup"><span data-stu-id="4f46a-137">Class</span></span>                                   |<span data-ttu-id="4f46a-138">詳細</span><span class="sxs-lookup"><span data-stu-id="4f46a-138">Details</span></span>                                         |<span data-ttu-id="4f46a-139">導入された製品</span><span class="sxs-lookup"><span data-stu-id="4f46a-139">Introduced In</span></span>|
|-------------------------------------|---------------------------------------------------------|--------------------------------------|
|[<span data-ttu-id="4f46a-140">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-140">CompositionColorBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush)         |<span data-ttu-id="4f46a-141">単色で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-141">Paints an area with a solid color</span></span>                        |<span data-ttu-id="4f46a-142">Windows 10 November Update (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="4f46a-142">Windows 10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="4f46a-143">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-143">CompositionSurfaceBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)       |<span data-ttu-id="4f46a-144">[ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface) の内容で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-144">Paints an area with the contents of an [ICompositionSurface](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Composition.ICompositionSurface)</span></span>|<span data-ttu-id="4f46a-145">Windows 10 November Update (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="4f46a-145">Windows 10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="4f46a-146">同様</span><span class="sxs-lookup"><span data-stu-id="4f46a-146">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)        |<span data-ttu-id="4f46a-147">コンポジション効果の内容で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-147">Paints an area with the contents of a composition effect</span></span> |<span data-ttu-id="4f46a-148">Windows 10 November Update (SDK 10586)</span><span class="sxs-lookup"><span data-stu-id="4f46a-148">Windows 10 November Update (SDK 10586)</span></span>|
|[<span data-ttu-id="4f46a-149">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-149">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)          |<span data-ttu-id="4f46a-150">不透明度マスクを使って CompositionBrush でビジュアルを塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-150">Paints a visual with a CompositionBrush with an opacity mask</span></span> |<span data-ttu-id="4f46a-151">Windows 10 Anniversary Update (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="4f46a-151">Windows 10 Anniversary Update (SDK 14393)</span></span>
|[<span data-ttu-id="4f46a-152">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-152">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)      |<span data-ttu-id="4f46a-153">NineGrid ストレッチを使って CompositionBrush で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-153">Paints an area with a CompositionBrush using a NineGrid stretch</span></span> |<span data-ttu-id="4f46a-154">Windows 10 Anniversary Update SDK (14393)</span><span class="sxs-lookup"><span data-stu-id="4f46a-154">Windows 10 Anniversary Update SDK (14393)</span></span>
|[<span data-ttu-id="4f46a-155">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-155">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)|<span data-ttu-id="4f46a-156">線形グラデーションで領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-156">Paints an area with a linear gradient</span></span>                    |<span data-ttu-id="4f46a-157">Windows 10 Fall Creators Update (Insider Preview SDK)</span><span class="sxs-lookup"><span data-stu-id="4f46a-157">Windows 10 Fall Creators Update (Insider Preview SDK)</span></span>
|[<span data-ttu-id="4f46a-158">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-158">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)     |<span data-ttu-id="4f46a-159">アプリケーションのピクセルから、または直接デスクトップ上のアプリケーション ウィンドウの背景のピクセルから背景ピクセルをサンプリングして領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-159">Paints an area by sampling background pixels from either the application or pixels directly behind the application's window on desktop.</span></span> <span data-ttu-id="4f46a-160">CompositionEffectBrush など、別の CompositionBrush への入力として使用されます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-160">Used as an input to another CompositionBrush like a CompositionEffectBrush</span></span> | <span data-ttu-id="4f46a-161">Windows 10 Anniversary Update (SDK 14393)</span><span class="sxs-lookup"><span data-stu-id="4f46a-161">Windows 10 Anniversary Update (SDK 14393)</span></span>

### <a name="paint-with-a-solid-color"></a><span data-ttu-id="4f46a-162">単色による塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-162">Paint with a solid color</span></span>

<span data-ttu-id="4f46a-163">[CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush) は単色で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-163">A [CompositionColorBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionColorBrush) paints an area with a solid color.</span></span> <span data-ttu-id="4f46a-164">SolidColorBrush の色を指定するには、さまざまな方法があります。</span><span class="sxs-lookup"><span data-stu-id="4f46a-164">There are a variety of ways to specify the color of a SolidColorBrush.</span></span> <span data-ttu-id="4f46a-165">たとえば、そのアルファ、赤、青、緑 (ARGB) チャネルを指定したり、[Colors](https://docs.microsoft.com/uwp/api/windows.ui.colors) クラスによって提供される定義済みの色のいずれかを使用したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-165">For example, you can specify its alpha, red, blue, and green (ARGB) channels or use one of the predefined colors provided by the [Colors](https://docs.microsoft.com/uwp/api/windows.ui.colors) class.</span></span>

<span data-ttu-id="4f46a-166">次の図とコードは、黒の色ブラシで描かれた四角形を、色の値が 0x9ACD32 である単色ブラシで塗りつぶす小規模なビジュアル ツリーを示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-166">The following illustration and code shows a small visual tree to create a rectangle that is stroked with a black color brush and painted with a solid color brush that has the color value of 0x9ACD32.</span></span>

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

### <a name="paint-with-a-linear-gradient"></a><span data-ttu-id="4f46a-168">線状グラデーションによる塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-168">Paint with a linear gradient</span></span>

<span data-ttu-id="4f46a-169">[CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush) は、線状グラデーションを使って領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-169">A [CompositionLinearGradientBrush](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush) paints an area with a linear gradient.</span></span> <span data-ttu-id="4f46a-170">線状グラデーションでは、線、つまりグラデーション軸に沿って 2 つ以上の色をブレンドします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-170">A linear gradient blends two or more colors across a line, the gradient axis.</span></span> <span data-ttu-id="4f46a-171">GradientStop オブジェクトを使って、グラデーションの色とその位置を指定します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-171">You use GradientStop objects to specify the colors in the gradient and their positions.</span></span>

<span data-ttu-id="4f46a-172">次の図とコードは、赤と黄色を使用した 2 ストップの LinearGradientBrush によって塗りつぶされた SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-172">The following illustration and code shows a SpriteVisual painted with a LinearGradientBrush with 2 stops using a red and yellow color.</span></span>

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

### <a name="paint-with-an-image"></a><span data-ttu-id="4f46a-174">画像による塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-174">Paint with an image</span></span>

<span data-ttu-id="4f46a-175">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) は、ICompositionSurface にレンダリングされるピクセルを使用して領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-175">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) paints an area with pixels rendered onto an ICompositionSurface.</span></span> <span data-ttu-id="4f46a-176">たとえば、CompositionSurfaceBrush を使用して、[LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API によって ICompositionSurface サーフェスにレンダリングされた画像で領域を塗りつぶすことができます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-176">For example, a CompositionSurfaceBrush can be used to paint an area with an image rendered onto an ICompositionSurface surface using [LoadedImageSurface](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.loadedimagesurface) API.</span></span>

<span data-ttu-id="4f46a-177">次の図とコードは、LoadedImageSurface を使って ICompositionSurface にレンダリングされたリコリスのビットマップで塗りつぶされた SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-177">The following illustration and code shows a SpriteVisual painted with a bitmap of a licorice rendered onto an ICompositionSurface using LoadedImageSurface.</span></span> <span data-ttu-id="4f46a-178">CompositionSurfaceBrush のプロパティを使用して、ビットマップを拡大し、ビジュアルの境界内に合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-178">The properties of CompositionSurfaceBrush can be used to stretch and align the bitmap within the bounds of the visual.</span></span>

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

### <a name="paint-with-a-custom-drawing"></a><span data-ttu-id="4f46a-180">カスタム描画による塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-180">Paint with a custom drawing</span></span>
<span data-ttu-id="4f46a-181">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) を使用して、[Win2D](https://microsoft.github.io/Win2D/html/Introduction.htm) (または D2D) によってレンダリングされた ICompositionSurface のピクセルで領域を塗りつぶすこともできます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-181">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using [Win2D](https://microsoft.github.io/Win2D/html/Introduction.htm) (or D2D).</span></span>

<span data-ttu-id="4f46a-182">次のコードは、Win2D を使用して ICompositionSurface にレンダリングされたテキストで塗りつぶされた SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-182">The following code shows a SpriteVisual painted with a text run rendered onto an ICompositionSurface using Win2D.</span></span> <span data-ttu-id="4f46a-183">Win2D を使用するには、[Win2D NuGet](https://www.nuget.org/packages/Win2D.uwp) パッケージをプロジェクトに含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f46a-183">Note, in order to use Win2D you need to include the [Win2D NuGet](https://www.nuget.org/packages/Win2D.uwp) package into your project.</span></span>

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

<span data-ttu-id="4f46a-184">同様に、CompositionSurfaceBrush を使用して、Win2D の相互運用機能を使う SwapChain で SpriteVisual を塗りつぶすこともできます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-184">Similarly, the CompositionSurfaceBrush can also be used to paint a SpriteVisual with a SwapChain using Win2D interop.</span></span> <span data-ttu-id="4f46a-185">[このサンプル](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample)では、Win2D を使用して、スワップ チェーンで SpriteVisual を塗りつぶす方法の例を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-185">[This sample](https://github.com/Microsoft/Win2D-Samples/tree/master/CompositionExample) provides an example of how to use Win2D to paint a SpriteVisual with a swapchain.</span></span>

### <a name="paint-with-a-video"></a><span data-ttu-id="4f46a-186">ビデオによる塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-186">Paint with a video</span></span>
<span data-ttu-id="4f46a-187">[CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) を使用して、[MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) クラスによって読み込まれたビデオを使ってレンダリングされた ICompositionSurface のピクセルで領域を塗りつぶすこともできます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-187">A [CompositionSurfaceBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) can also be used to paint an area with pixels from an ICompositionSurface rendered using a video loaded through the [MediaPlayer](https://docs.microsoft.com/en-us/uwp/api/Windows.Media.Playback.MediaPlayer) class.</span></span>

<span data-ttu-id="4f46a-188">次のコードは、ICompositionSurface に読み込まれたビデオで塗りつぶされた SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-188">The following code shows a SpriteVisual painted with a video loaded onto an ICompositionSurface.</span></span>

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

### <a name="paint-with-a-filter-effect"></a><span data-ttu-id="4f46a-189">フィルター エフェクトによる塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-189">Paint with a filter effect</span></span>

<span data-ttu-id="4f46a-190">[CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) は、CompositionEffect の出力で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-190">A [CompositionEffectBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush) paints an area with output of a CompositionEffect.</span></span> <span data-ttu-id="4f46a-191">ビジュアル レイヤーの効果は、色、グラデーション、画像、ビデオ、スワップ チェーン、UI の領域、ビジュアル ツリーなどのソース コンテンツのコレクションに適用された、アニメーション化可能なフィルター エフェクトと考えることができます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-191">Effects in the Visual Layer may be thought of as animatable filter effects applied to a collection of source content such as colors, gradients, images, videos, swapchains, regions of your UI, or trees of Visuals.</span></span> <span data-ttu-id="4f46a-192">ソース コンテンツは通常、別の CompositionBrush を使用して指定されます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-192">The source content is typically specified using another CompositionBrush.</span></span>

<span data-ttu-id="4f46a-193">次の図とコードは、彩度を下げるフィルター エフェクトを適用した猫の画像で塗りつぶされた SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-193">The following illustration and code shows a SpriteVisual painted with an image of a cat that has desaturation filter effect applied.</span></span>

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

<span data-ttu-id="4f46a-195">CompositionBrushes を使用したエフェクトの作成の詳細については、[ビジュアル レイヤーでの効果に関するトピック](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="4f46a-195">For more information on creating an Effect using CompositionBrushes see [Effects in Visual layer](https://docs.microsoft.com/en-us/windows/uwp/composition/composition-effects)</span></span>

### <a name="paint-with-a-compositionbrush-with-opacity-mask-applied"></a><span data-ttu-id="4f46a-196">不透明度マスクを適用した CompositionBrush による塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-196">Paint with a CompositionBrush with opacity mask applied</span></span>

<span data-ttu-id="4f46a-197">[CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush) は、不透明度マスクが適用された CompositionBrush で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-197">A [CompositionMaskBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush) paints an area with a CompositionBrush with an opacity mask applied to it.</span></span> <span data-ttu-id="4f46a-198">不透明度マスクのソースには、CompositionColorBrush、CompositionLinearGradientBrush、CompositionSurfaceBrush、CompositionEffectBrush、CompositionNineGridBrush の任意の種類の CompositionBrush を指定できます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-198">The source of the opacity mask can be any CompositionBrush of type CompositionColorBrush, CompositionLinearGradientBrush, CompositionSurfaceBrush, CompositionEffectBrush, or CompositionNineGridBrush.</span></span> <span data-ttu-id="4f46a-199">不透明度マスクは、CompositionSurfaceBrush として指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f46a-199">The opacity mask must be specified as a CompositionSurfaceBrush.</span></span>

<span data-ttu-id="4f46a-200">次の図とコードは、CompositionMaskBrush で塗りつぶされた SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-200">The following illustration and code shows a SpriteVisual painted with a CompositionMaskBrush.</span></span> <span data-ttu-id="4f46a-201">マスクのソースは、マスクとして円の画像を使用して、円形にマスクされた CompositionLinearGradientBrush です。</span><span class="sxs-lookup"><span data-stu-id="4f46a-201">The source of the mask is a CompositionLinearGradientBrush which is masked to look like a circle using an image of circle as a mask.</span></span>

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

### <a name="paint-with-a-compositionbrush-using-ninegrid-stretch"></a><span data-ttu-id="4f46a-203">NineGrid ストレッチを使った CompositionBrush による塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-203">Paint with a CompositionBrush using NineGrid stretch</span></span>

<span data-ttu-id="4f46a-204">[CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) は、9 グリッド形式で拡大された CompositionBrush で領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-204">A [CompositionNineGridBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush) paints an area with a CompositionBrush that is stretched using the nine-grid metaphor.</span></span> <span data-ttu-id="4f46a-205">9 グリッド形式によって、CompositionBrush の端と隅を中央とは別に伸縮できます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-205">The nine-grid metaphor enables you to stretch edges and corners of a CompositionBrush differently than its center.</span></span> <span data-ttu-id="4f46a-206">9 グリッド ストレッチのソースには、CompositionColorBrush、CompositionSurfaceBrush、CompositionEffectBrush の任意の種類の CompositionBrush を指定できます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-206">The source of the nine-grid stretch can by any CompositionBrush of type CompositionColorBrush, CompositionSurfaceBrush, or CompositionEffectBrush.</span></span>

<span data-ttu-id="4f46a-207">次の図とコードは、CompositionNineGridBrush で塗りつぶされた SpriteVisual を示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-207">The following code shows a SpriteVisual painted with a CompositionNineGridBrush.</span></span> <span data-ttu-id="4f46a-208">マスクのソースは、9 グリッドを使用して伸縮された CompositionSurfaceBrush です。</span><span class="sxs-lookup"><span data-stu-id="4f46a-208">The source of the mask is a CompositionSurfaceBrush which is stretched using a Nine-Grid.</span></span>

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

### <a name="paint-using-background-pixels"></a><span data-ttu-id="4f46a-209">背景のピクセルを使った塗りつぶし</span><span class="sxs-lookup"><span data-stu-id="4f46a-209">Paint using Background Pixels</span></span>

<span data-ttu-id="4f46a-210">[CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush) は、領域の背景のコンテンツを使用して領域を塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="4f46a-210">A [CompositionBackdropBrush](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)  paints an area with the content behind the area.</span></span> <span data-ttu-id="4f46a-211">CompositionBackdropBrush はそれだけでは使用されませんが、代わりに、EffectBrush などの別の CompositionBrush への入力として使用されます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-211">A CompositionBackdropBrush is never used on its own, but instead is used as an input to another CompositionBrush like an EffectBrush.</span></span> <span data-ttu-id="4f46a-212">たとえば、ぼかし効果への入力として CompositionBackdropBrush を使用することで、すりガラス効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-212">For example, by using a CompositionBackdropBrush as an input to a Blur effect, you can achieve a frosted glass effect.</span></span>

<span data-ttu-id="4f46a-213">次のコードは、CompositionSurfaceBrush と画像の上のすりガラスのオーバーレイを使用して画像を作成するための小さなビジュアル ツリーを示しています。</span><span class="sxs-lookup"><span data-stu-id="4f46a-213">The following code shows a small visual tree to create an image using CompositionSurfaceBrush and a frosted glass overlay above the image.</span></span> <span data-ttu-id="4f46a-214">すりガラスのオーバーレイは、画像の上に EffectBrush で塗りつぶされた SpriteVisual を配置することによって作成されます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-214">The frosted glass overlay is created by placing a SpriteVisual filled with an EffectBrush above the image.</span></span> <span data-ttu-id="4f46a-215">この EffectBrush は、ぼかし効果への入力として CompositionBackdropBrush を使用します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-215">The EffectBrush uses a CompositionBackdropBrush as an input to the blur effect.</span></span>

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

## <a name="combining-compositionbrushes"></a><span data-ttu-id="4f46a-216">CompositionBrush の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="4f46a-216">Combining CompositionBrushes</span></span>
<span data-ttu-id="4f46a-217">多くの CompositionBrush が入力として他の CompositionBrush を使用します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-217">A number of CompositionBrushes use other CompositionBrushes as inputs.</span></span> <span data-ttu-id="4f46a-218">たとえば、SetSourceParameter メソッドを使用して、CompositionEffectBrush への入力として別 CompositionBrush を設定できます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-218">For example, using the SetSourceParameter method can be used to set another CompositionBrush as an input to a CompositionEffectBrush.</span></span> <span data-ttu-id="4f46a-219">次の表では、サポートされている CompositionBrush の組み合わせについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-219">The table below outlines the supported combinations of CompositionBrushes.</span></span> <span data-ttu-id="4f46a-220">サポートされていない組み合わせを使用すると例外がスローされることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="4f46a-220">Note, that using an unsupported combination will throw an exception.</span></span>

<table>
<tbody>
<tr>
<th><span data-ttu-id="4f46a-221">ブラシ</span><span class="sxs-lookup"><span data-stu-id="4f46a-221">Brush</span></span></th>
<th><span data-ttu-id="4f46a-222">EffectBrush.SetSourceParameter()</span><span class="sxs-lookup"><span data-stu-id="4f46a-222">EffectBrush.SetSourceParameter()</span></span></th>
<th><span data-ttu-id="4f46a-223">MaskBrush.Mask</span><span class="sxs-lookup"><span data-stu-id="4f46a-223">MaskBrush.Mask</span></span></th>
<th><span data-ttu-id="4f46a-224">MaskBrush.Source</span><span class="sxs-lookup"><span data-stu-id="4f46a-224">MaskBrush.Source</span></span></th>
<th><span data-ttu-id="4f46a-225">NineGridBrush.Source</span><span class="sxs-lookup"><span data-stu-id="4f46a-225">NineGridBrush.Source</span></span></th>
</tr>
<tr>
<td><span data-ttu-id="4f46a-226">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-226">CompositionColorBrush</span></span></td>
<td><span data-ttu-id="4f46a-227">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-227">YES</span></span></td>
<td><span data-ttu-id="4f46a-228">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-228">YES</span></span></td>
<td><span data-ttu-id="4f46a-229">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-229">YES</span></span></td>
<td><span data-ttu-id="4f46a-230">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-230">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4f46a-231">CompositionLinear</span><span class="sxs-lookup"><span data-stu-id="4f46a-231">CompositionLinear</span></span><br /><span data-ttu-id="4f46a-232">GradientBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-232">GradientBrush</span></span></td>
<td><span data-ttu-id="4f46a-233">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-233">YES</span></span></td>
<td><span data-ttu-id="4f46a-234">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-234">YES</span></span></td>
<td><span data-ttu-id="4f46a-235">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-235">YES</span></span></td>
<td><span data-ttu-id="4f46a-236">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-236">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4f46a-237">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-237">CompositionSurfaceBrush</span></span></td>
<td><span data-ttu-id="4f46a-238">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-238">YES</span></span></td>
<td><span data-ttu-id="4f46a-239">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-239">YES</span></span></td>
<td><span data-ttu-id="4f46a-240">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-240">YES</span></span></td>
<td><span data-ttu-id="4f46a-241">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-241">YES</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4f46a-242">CompositionEffectBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-242">CompositionEffectBrush</span></span></td>
<td><span data-ttu-id="4f46a-243">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-243">NO</span></span></td>
<td><span data-ttu-id="4f46a-244">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-244">NO</span></span></td>
<td><span data-ttu-id="4f46a-245">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-245">YES</span></span></td>
<td><span data-ttu-id="4f46a-246">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-246">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4f46a-247">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-247">CompositionMaskBrush</span></span></td>
<td><span data-ttu-id="4f46a-248">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-248">NO</span></span></td>
<td><span data-ttu-id="4f46a-249">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-249">NO</span></span></td>
<td><span data-ttu-id="4f46a-250">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-250">NO</span></span></td>
<td><span data-ttu-id="4f46a-251">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-251">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4f46a-252">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-252">CompositionNineGridBrush</span></span></td>
<td><span data-ttu-id="4f46a-253">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-253">YES</span></span></td>
<td><span data-ttu-id="4f46a-254">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-254">YES</span></span></td>
<td><span data-ttu-id="4f46a-255">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-255">YES</span></span></td>
<td><span data-ttu-id="4f46a-256">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-256">NO</span></span></td>
</tr>
<tr>
<td><span data-ttu-id="4f46a-257">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-257">CompositionBackdropBrush</span></span></td>
<td><span data-ttu-id="4f46a-258">使用可能</span><span class="sxs-lookup"><span data-stu-id="4f46a-258">YES</span></span></td>
<td><span data-ttu-id="4f46a-259">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-259">NO</span></span></td>
<td><span data-ttu-id="4f46a-260">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-260">NO</span></span></td>
<td><span data-ttu-id="4f46a-261">使用不可</span><span class="sxs-lookup"><span data-stu-id="4f46a-261">NO</span></span></td>
</tr>
</tbody>
</table>


## <a name="using-a-xaml-brush-vs-compositionbrush"></a><span data-ttu-id="4f46a-262">XAML のブラシ vs を使用します。CompositionBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-262">Using a XAML Brush vs. CompositionBrush</span></span>

<span data-ttu-id="4f46a-263">次の表に、シナリオと、アプリケーションで UIElement や SpriteVisual を塗りつぶすときに XAML ブラシまたはコンポジション ブラシを使用できるかどうかの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="4f46a-263">The following table provides a list of scenarios and whether XAML or Composition brush use is prescribed when painting a UIElement or a SpriteVisual in your application.</span></span> 

> [!NOTE]
> <span data-ttu-id="4f46a-264">CompositionBrush が XAML UIElement 用に推奨されている場合、CompositionBrush は XamlCompositionBrushBase を使用してパッケージ化されている見なされます。</span><span class="sxs-lookup"><span data-stu-id="4f46a-264">If a CompositionBrush is suggested for a XAML UIElement, it is assumed that the CompositionBrush is packaged using a XamlCompositionBrushBase.</span></span>

|<span data-ttu-id="4f46a-265">シナリオ</span><span class="sxs-lookup"><span data-stu-id="4f46a-265">Scenario</span></span>                                                                   | <span data-ttu-id="4f46a-266">XAML UIElement</span><span class="sxs-lookup"><span data-stu-id="4f46a-266">XAML UIElement</span></span>                                                                                                |<span data-ttu-id="4f46a-267">コンポジションの SpriteVisual</span><span class="sxs-lookup"><span data-stu-id="4f46a-267">Composition SpriteVisual</span></span>
|---------------------------------------------------------------------------|---------------------------------------------------------------------------------------------------------------|----------------------------------
|<span data-ttu-id="4f46a-268">単色で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-268">Paint an area with solid color</span></span>                                             |[<span data-ttu-id="4f46a-269">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-269">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="4f46a-270">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-270">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="4f46a-271">アニメーション化された色で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-271">Paint an area with animated color</span></span>                                          |[<span data-ttu-id="4f46a-272">SolidColorBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-272">SolidColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR242962)                                |[<span data-ttu-id="4f46a-273">CompositionColorBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-273">CompositionColorBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589399)
|<span data-ttu-id="4f46a-274">静的なグラデーションで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-274">Paint an area with a static gradient</span></span>                                       |[<span data-ttu-id="4f46a-275">LinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-275">LinearGradientBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210108)                            |[<span data-ttu-id="4f46a-276">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-276">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="4f46a-277">アニメーション化されたグラデーション ストップで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-277">Paint an area with animated gradient stops</span></span>                                 |[<span data-ttu-id="4f46a-278">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-278">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)                                                                                 |[<span data-ttu-id="4f46a-279">CompositionLinearGradientBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-279">CompositionLinearGradientBrush</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlineargradientbrush)
|<span data-ttu-id="4f46a-280">画像で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-280">Paint an area with an image</span></span>                                                |[<span data-ttu-id="4f46a-281">ImageBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-281">ImageBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR210101)                                     |[<span data-ttu-id="4f46a-282">CompositionSurfaceBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-282">CompositionSurfaceBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/Mt589415)
|<span data-ttu-id="4f46a-283">Web ページで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-283">Paint an area with a webpage</span></span>                                               |[<span data-ttu-id="4f46a-284">WebViewBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-284">WebViewBrush</span></span>](https://msdn.microsoft.com/library/windows/apps/BR227703)                                   |<span data-ttu-id="4f46a-285">なし</span><span class="sxs-lookup"><span data-stu-id="4f46a-285">N/A</span></span>
|<span data-ttu-id="4f46a-286">NineGrid ストレッチを使った画像で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-286">Paint an area with an image using NineGrid stretch</span></span>                         |[<span data-ttu-id="4f46a-287">イメージ コントロール</span><span class="sxs-lookup"><span data-stu-id="4f46a-287">Image Control</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Image)                   |[<span data-ttu-id="4f46a-288">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-288">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="4f46a-289">アニメーション化された NineGrid ストレッチを使って領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-289">Paint an area with animated NineGrid stretch</span></span>                               |[<span data-ttu-id="4f46a-290">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-290">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)                                                                                       |[<span data-ttu-id="4f46a-291">CompositionNineGridBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-291">CompositionNineGridBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionNineGridBrush)
|<span data-ttu-id="4f46a-292">スワップ チェーンで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-292">Paint an area with a swapchain</span></span>                                             |[<span data-ttu-id="4f46a-293">SwapChainPanel</span><span class="sxs-lookup"><span data-stu-id="4f46a-293">SwapChainPanel</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.SwapChainPanel)                                                                                                 |<span data-ttu-id="4f46a-294">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (スワップ チェーンの相互運用機能を使用)</span><span class="sxs-lookup"><span data-stu-id="4f46a-294">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ swapchain interop</span></span>
|<span data-ttu-id="4f46a-295">ビデオで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-295">Paint an area with a video</span></span>                                                 |[<span data-ttu-id="4f46a-296">MediaElement</span><span class="sxs-lookup"><span data-stu-id="4f46a-296">MediaElement</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187272.aspx)                                                                                                  |<span data-ttu-id="4f46a-297">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (メディア相互運用機能を使用)</span><span class="sxs-lookup"><span data-stu-id="4f46a-297">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ media interop</span></span>
|<span data-ttu-id="4f46a-298">カスタム 2D 描画を使用して領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-298">Paint an area with custom 2D drawing</span></span>                                       |<span data-ttu-id="4f46a-299">[CanvasControl](https://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm) (Win2D より)</span><span class="sxs-lookup"><span data-stu-id="4f46a-299">[CanvasControl](https://microsoft.github.io/Win2D/html/T_Microsoft_Graphics_Canvas_UI_Xaml_CanvasControl.htm) from Win2D</span></span>                                                                                                 |<span data-ttu-id="4f46a-300">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) (Win2D 相互運用機能を使用)</span><span class="sxs-lookup"><span data-stu-id="4f46a-300">[CompositionSurfaceBrush](https://msdn.microsoft.com/library/windows/apps/Mt589415) w/ Win2D interop</span></span>
|<span data-ttu-id="4f46a-301">アニメーション化されていないマスクで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-301">Paint an area with non-animated mask</span></span>                                       |<span data-ttu-id="4f46a-302">XAML の[図形](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes)を使用してマスクを定義</span><span class="sxs-lookup"><span data-stu-id="4f46a-302">Use XAML [shapes](https://docs.microsoft.com/windows/uwp/graphics/drawing-shapes) to define a mask</span></span>   |[<span data-ttu-id="4f46a-303">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-303">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="4f46a-304">アニメーション化されたマスクで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-304">Paint an area with an animated mask</span></span>                                        |[<span data-ttu-id="4f46a-305">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-305">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)                                                                                           |[<span data-ttu-id="4f46a-306">CompositionMaskBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-306">CompositionMaskBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionMaskBrush)
|<span data-ttu-id="4f46a-307">アニメーション化されたフィルター エフェクトで領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-307">Paint an area with an animated filter effect</span></span>                               |[<span data-ttu-id="4f46a-308">同様</span><span class="sxs-lookup"><span data-stu-id="4f46a-308">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)                                                                                         |[<span data-ttu-id="4f46a-309">同様</span><span class="sxs-lookup"><span data-stu-id="4f46a-309">CompositionEffectBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionEffectBrush)
|<span data-ttu-id="4f46a-310">背景のピクセルに適用された効果で領域を塗りつぶす</span><span class="sxs-lookup"><span data-stu-id="4f46a-310">Paint an area with an effect applied to background pixels</span></span>        |[<span data-ttu-id="4f46a-311">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-311">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)                                                                                        |[<span data-ttu-id="4f46a-312">CompositionBackdropBrush</span><span class="sxs-lookup"><span data-stu-id="4f46a-312">CompositionBackdropBrush</span></span>](https://docs.microsoft.com/uwp/api/Windows.UI.Composition.CompositionBackdropBrush)

## <a name="related-topics"></a><span data-ttu-id="4f46a-313">関連トピック</span><span class="sxs-lookup"><span data-stu-id="4f46a-313">Related Topics</span></span>

[<span data-ttu-id="4f46a-314">コンポジション ネイティブ DirectX と Direct2D との相互運用 begindraw メソッドと EndDraw</span><span class="sxs-lookup"><span data-stu-id="4f46a-314">Composition native DirectX and Direct2D interop with BeginDraw and EndDraw</span></span>](composition-native-interop.md)

[<span data-ttu-id="4f46a-315">XamlCompositionBrushBase と XAML ブラシの相互運用</span><span class="sxs-lookup"><span data-stu-id="4f46a-315">XAML brush interop with XamlCompositionBrushBase</span></span>](/windows/uwp/design/style/brushes#xamlcompositionbrushbase)
