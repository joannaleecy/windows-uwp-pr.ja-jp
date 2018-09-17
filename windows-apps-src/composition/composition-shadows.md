---
author: daneuber
title: コンポジション シャドウ
description: シャドウ Api では、UI コンテンツを動的なカスタマイズ可能なシャドウを追加することができます。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 84e12d6c3e25a18902aaa55011949dd5b5ff97ca
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3988043"
---
# <a name="shadows-in-windows-ui"></a><span data-ttu-id="00bd4-104">Windows UI でのシャドウ</span><span class="sxs-lookup"><span data-stu-id="00bd4-104">Shadows in Windows UI</span></span>

<span data-ttu-id="00bd4-105">[DropShadow](/uwp/api/Windows.UI.Composition.DropShadow)クラスでは、 [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)または[LayerVisual](/uwp/api/windows.ui.composition.layervisual) (視覚効果のサブツリー) に適用可能な構成可能なシャドウを作成する手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-105">The [DropShadow](/uwp/api/Windows.UI.Composition.DropShadow) class provides means of creating a configurable shadow that can be applied to a [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual) or [LayerVisual](/uwp/api/windows.ui.composition.layervisual) (subtree of Visuals).</span></span> <span data-ttu-id="00bd4-106">ビジュアル レイヤー内のオブジェクトの通常は、Compositionanimation を使用して、DropShadow のすべてのプロパティをアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="00bd4-106">As is customary for objects in the Visual Layer, all properties of the DropShadow can be animated using CompositionAnimations.</span></span>

## <a name="basic-drop-shadow"></a><span data-ttu-id="00bd4-107">基本的なドロップ シャドウ</span><span class="sxs-lookup"><span data-stu-id="00bd4-107">Basic drop shadow</span></span>

<span data-ttu-id="00bd4-108">基本的なシャドウを作成するには、新しい DropShadow を作成し、ビジュアルに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="00bd4-108">To create a basic shadow, simply create a new DropShadow and associate it to your visual.</span></span> <span data-ttu-id="00bd4-109">影が既定では四角形です。</span><span class="sxs-lookup"><span data-stu-id="00bd4-109">The shadow is rectangular by default.</span></span> <span data-ttu-id="00bd4-110">シャドウの見た目や操作感を調整する標準的な一連のプロパティを利用できます。</span><span class="sxs-lookup"><span data-stu-id="00bd4-110">A standard set of properties are available to tweak the look and feel of your shadow.</span></span>

```cs
var basicRectVisual = _compositor.CreateSpriteVisual();
basicRectVisual.Brush = _compositor.CreateColorBrush(Colors.Blue);
basicRectVisual.Offset = new Vector3(100, 100, 20);
basicRectVisual.Size = new Vector2(300, 300);

var basicShadow = _compositor.CreateDropShadow();
basicShadow.BlurRadius = 25f;
basicShadow.Offset = new Vector3(20, 20, 20);

basicRectVisual.Shadow = basicShadow;
```

![四角形のビジュアルで基本的な DropShadow](images/rectangular-dropshadow.png)

## <a name="shaping-the-shadow"></a><span data-ttu-id="00bd4-112">シャドウを整える</span><span class="sxs-lookup"><span data-stu-id="00bd4-112">Shaping the shadow</span></span>

<span data-ttu-id="00bd4-113">これには、DropShadow の形状を定義するいくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="00bd4-113">There are a few ways to define the shape for your DropShadow:</span></span>

- <span data-ttu-id="00bd4-114">DropShadow 図形を既定では **、既定の使用**- は CompositionDropShadowSourcePolicy の '既定' モードによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="00bd4-114">**Use the default** - By default the DropShadow shape is defined by the ‘Default’ mode on CompositionDropShadowSourcePolicy.</span></span> <span data-ttu-id="00bd4-115">SpriteVisual が既定の四角形マスクが提供されている場合を除き、します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-115">For SpriteVisual, the Default is Rectangular unless a mask is provided.</span></span> <span data-ttu-id="00bd4-116">LayerVisual、既定ではビジュアル オブジェクトのブラシのアルファ マスクを継承します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-116">For LayerVisual, Default is to inherit a mask using the alpha of the visual’s brush.</span></span>
- <span data-ttu-id="00bd4-117">**マスクを設定**、シャドウの不透明度マスクを定義する[マスク](/uwp/api/windows.ui.composition.dropshadow.mask)プロパティを設定することがあります。</span><span class="sxs-lookup"><span data-stu-id="00bd4-117">**Set a mask** – You may set the [Mask](/uwp/api/windows.ui.composition.dropshadow.mask) property to define an opacity mask for the shadow.</span></span>
- <span data-ttu-id="00bd4-118">**継承マスクを使うことを指定する**– は、 [CompositionDropShadowSourcePolicy](/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy)を使用する[SourcePolicy](/uwp/api/windows.ui.composition.dropshadow.sourcepolicy)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-118">**Specify to use Inherited mask** – Set the [SourcePolicy](/uwp/api/windows.ui.composition.dropshadow.sourcepolicy) property to use [CompositionDropShadowSourcePolicy](/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy).</span></span> <span data-ttu-id="00bd4-119">ビジュアル オブジェクトのブラシのアルファから生成されたマスクを使用する InheritFromVisualContent します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-119">InheritFromVisualContent to use the mask generated from the alpha of the visual’s brush.</span></span>

## <a name="masking-to-match-your-content"></a><span data-ttu-id="00bd4-120">コンテンツに合わせてマスク</span><span class="sxs-lookup"><span data-stu-id="00bd4-120">Masking to match your content</span></span>

<span data-ttu-id="00bd4-121">シャドウ マスクのプロパティにビジュアル オブジェクトのブラシを使用するか、設定、コンテンツのマスクを自動的に継承するシャドウのビジュアル オブジェクトのコンテンツに合わせて、シャドウを実行する場合にします。</span><span class="sxs-lookup"><span data-stu-id="00bd4-121">If you want your shadow to match the Visual’s content you can either use the Visual’s brush for your Shadow mask property, or set the shadow to automatically inherit mask from the content.</span></span> <span data-ttu-id="00bd4-122">LayerVisual を使っている場合、シャドウは既定では、マスクを継承します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-122">If using a LayerVisual, the shadow will inherit the mask by default.</span></span>

```cs
var imageSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/myImage.png"));
var imageBrush = _compositor.CreateSurfaceBrush(imageSurface);

var imageSpriteVisual = _compositor.CreateSpriteVisual();
imageSpriteVisual.Size = new Vector2(400,400);
imageSpriteVisual.Offset = new Vector3(100, 500, 20);
imageSpriteVisual.Brush = imageBrush;

var shadow = _compositor.CreateDropShadow();
shadow.Mask = imageBrush;
// or use shadow.SourcePolicy = CompositionDropShadowSourcePolicy.InheritFromVisualContent;
shadow.BlurRadius = 25f;
shadow.Offset = new Vector3(20, 20, 20);

imageSpriteVisual.Shadow = shadow;
```

![接続されている web 画像マスク ドロップ シャドウ](images/ms-brand-web-dropshadow.png)

## <a name="using-an-alternative-mask"></a><span data-ttu-id="00bd4-124">代替のマスクを使用します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-124">Using an alternative mask</span></span>

<span data-ttu-id="00bd4-125">場合によっては、図形、シャドウのビジュアル オブジェクトの内容に一致しないようにすることがあります。</span><span class="sxs-lookup"><span data-stu-id="00bd4-125">In some cases, you may want to shape the shadow such that it doesn’t match your Visual’s content.</span></span> <span data-ttu-id="00bd4-126">この効果を実現するためには、ブラシを使用してアルファ マスク プロパティを明示的に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00bd4-126">To achieve this effect, you’ll need to explicitly set the Mask property using a brush with alpha.</span></span>

<span data-ttu-id="00bd4-127">次の例では、2 つのサーフェスに視覚的なコンテンツ用とシャドウ マスク用に 1 つを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="00bd4-127">In the below example, we load two surfaces - one for the Visual content and one for the Shadow mask:</span></span>

```cs
var imageSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/myImage.png"));
var imageBrush = _compositor.CreateSurfaceBrush(imageSurface);

var circleSurface = LoadedImageSurface.StartLoadFromUri(new Uri("ms-appx:///Assets/myCircleImage.png"));
var customMask = _compositor.CreateSurfaceBrush(circleSurface);

var imageSpriteVisual = _compositor.CreateSpriteVisual();
imageSpriteVisual.Size = new Vector2(400,400);
imageSpriteVisual.Offset = new Vector3(100, 500, 20);
imageSpriteVisual.Brush = imageBrush;

var shadow = _compositor.CreateDropShadow();
shadow.Mask = customMask;
shadow.BlurRadius = 25f;
shadow.Offset = new Vector3(20, 20, 20);

imageSpriteVisual.Shadow = shadow;
```

![接続されている web 画像の円をマスク ドロップ シャドウ](images/ms-brand-web-masked-dropshadow.png)

## <a name="animating"></a><span data-ttu-id="00bd4-129">アニメーション化</span><span class="sxs-lookup"><span data-stu-id="00bd4-129">Animating</span></span>

<span data-ttu-id="00bd4-130">標準のビジュアル レイヤーでは、DropShadow プロパティをコンポジションのアニメーションを使用してアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="00bd4-130">As is standard in the Visual Layer, DropShadow properties can be animated using Composition Animations.</span></span> <span data-ttu-id="00bd4-131">以下は、上記の影のぼかし半径をアニメーション化する散点サンプルからのコードを変更します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-131">Below, we modify the code from the sprinkles sample above to animate the blur radius for the shadow.</span></span>

```cs
ScalarKeyFrameAnimation blurAnimation = _compositor.CreateScalarKeyFrameAnimation();
blurAnimation.InsertKeyFrame(0.0f, 25.0f);
blurAnimation.InsertKeyFrame(0.7f, 50.0f);
blurAnimation.InsertKeyFrame(1.0f, 25.0f);
blurAnimation.Duration = TimeSpan.FromSeconds(4);
blurAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
shadow.StartAnimation("BlurRadius", blurAnimation);
```

## <a name="shadows-in-xaml"></a><span data-ttu-id="00bd4-132">XAML でのシャドウ</span><span class="sxs-lookup"><span data-stu-id="00bd4-132">Shadows in XAML</span></span>

<span data-ttu-id="00bd4-133">さらに複雑なフレームワーク要素にシャドウを追加する場合は、XAML とコンポジションの間で影付きの相互運用機能をいくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="00bd4-133">If you want to add a shadow to more complex framework elements, there are a couple ways to interop with shadows between XAML and Composition:</span></span>

1. <span data-ttu-id="00bd4-134">Windows コミュニティ ツールキットで利用可能な[DropShadowPanel](https://github.com/Microsoft/UWPCommunityToolkit/blob/master/Microsoft.Toolkit.Uwp.UI.Controls/DropShadowPanel/DropShadowPanel.Properties.cs)を使用します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-134">Use the [DropShadowPanel](https://github.com/Microsoft/UWPCommunityToolkit/blob/master/Microsoft.Toolkit.Uwp.UI.Controls/DropShadowPanel/DropShadowPanel.Properties.cs) available in the Windows Community Toolkit.</span></span> <span data-ttu-id="00bd4-135">その使用方法の詳細については、 [DropShadowPanel ドキュメント](https://docs.microsoft.com/windows/uwpcommunitytoolkit/controls/DropShadowPanel)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="00bd4-135">See the [DropShadowPanel documentation](https://docs.microsoft.com/windows/uwpcommunitytoolkit/controls/DropShadowPanel) for details on how to use it.</span></span>
1. <span data-ttu-id="00bd4-136">シャドウ ホストとして使用すると、XAML ハンドアウト Visual を関連付けるにビジュアルを作成します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-136">Create a Visual to use as the shadow host & tie it to the XAML handout Visual.</span></span>
1. <span data-ttu-id="00bd4-137">コンポジションのサンプル ギャラリーの[SamplesCommon](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SamplesCommon/SamplesCommon)カスタム CompositionShadow コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="00bd4-137">Use the Composition Sample Gallery’s [SamplesCommon](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SamplesCommon/SamplesCommon) custom CompositionShadow control.</span></span> <span data-ttu-id="00bd4-138">ここでの使用例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="00bd4-138">See the example here for usage.</span></span>

## <a name="performance"></a><span data-ttu-id="00bd4-139">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="00bd4-139">Performance</span></span>

<span data-ttu-id="00bd4-140">ビジュアル レイヤーは、多くの最適化を効率的で使用可能な効果を作成するには、シャドウを生成できる、比較的安価操作によっては、どのようなオプションを設定します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-140">Although the Visual Layer has many optimizations in place to make effects efficient and usable, generating shadows can be a relatively expensive operation depending on what options you set.</span></span> <span data-ttu-id="00bd4-141">高レベル '' のコストさまざまな種類のシャドウを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="00bd4-141">Below are high level 'costs' for different types of shadows.</span></span> <span data-ttu-id="00bd4-142">ある特定のシャドウのコストがかかる場合がありますが、可能性があります特定のシナリオで慎重に使用する適切な注意してください。</span><span class="sxs-lookup"><span data-stu-id="00bd4-142">Note that although certain shadows may be expensive they may still be appropriate to use sparingly in certain scenarios.</span></span>

<span data-ttu-id="00bd4-143">シャドウの特性</span><span class="sxs-lookup"><span data-stu-id="00bd4-143">Shadow Characteristics</span></span>| <span data-ttu-id="00bd4-144">費用</span><span class="sxs-lookup"><span data-stu-id="00bd4-144">Cost</span></span>
------------- | -------------
<span data-ttu-id="00bd4-145">[四角形の領域切り取り]</span><span class="sxs-lookup"><span data-stu-id="00bd4-145">Rectangular</span></span>    | <span data-ttu-id="00bd4-146">低</span><span class="sxs-lookup"><span data-stu-id="00bd4-146">Low</span></span>
<span data-ttu-id="00bd4-147">Shadow.Mask</span><span class="sxs-lookup"><span data-stu-id="00bd4-147">Shadow.Mask</span></span>      | <span data-ttu-id="00bd4-148">高</span><span class="sxs-lookup"><span data-stu-id="00bd4-148">High</span></span>
<span data-ttu-id="00bd4-149">CompositionDropShadowSourcePolicy.InheritFromVisualContent</span><span class="sxs-lookup"><span data-stu-id="00bd4-149">CompositionDropShadowSourcePolicy.InheritFromVisualContent</span></span> | <span data-ttu-id="00bd4-150">高</span><span class="sxs-lookup"><span data-stu-id="00bd4-150">High</span></span>
<span data-ttu-id="00bd4-151">静的なぼかし Radius</span><span class="sxs-lookup"><span data-stu-id="00bd4-151">Static Blur Radius</span></span> | <span data-ttu-id="00bd4-152">低</span><span class="sxs-lookup"><span data-stu-id="00bd4-152">Low</span></span>
<span data-ttu-id="00bd4-153">Radius のぼかしをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="00bd4-153">Animating Blur Radius</span></span> | <span data-ttu-id="00bd4-154">高</span><span class="sxs-lookup"><span data-stu-id="00bd4-154">High</span></span>

## <a name="additional-resources"></a><span data-ttu-id="00bd4-155">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="00bd4-155">Additional Resources</span></span>

- [<span data-ttu-id="00bd4-156">コンポジション DropShadow API</span><span class="sxs-lookup"><span data-stu-id="00bd4-156">Composition DropShadow API</span></span>](/uwp/api/Windows.UI.Composition.DropShadow)
- [<span data-ttu-id="00bd4-157">WindowsUIDevLabs GitHub リポジトリにあります。</span><span class="sxs-lookup"><span data-stu-id="00bd4-157">WindowsUIDevLabs GitHub Repo</span></span>](https://github.com/Microsoft/WindowsUIDevLabs)