---
title: コンポジション シャドウ
description: シャドウの Api を使用して、UI のコンテンツを動的にカスタマイズ可能なシャドウを追加できます。
ms.date: 07/16/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9541ea1c00d473bc4881a80d8597625592e278f9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57630837"
---
# <a name="shadows-in-windows-ui"></a><span data-ttu-id="68907-104">Windows UI のシャドウ</span><span class="sxs-lookup"><span data-stu-id="68907-104">Shadows in Windows UI</span></span>

<span data-ttu-id="68907-105">[DropShadow](/uwp/api/Windows.UI.Composition.DropShadow)クラスに適用できる構成可能なシャドウの作成方法を提供する、 [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)または[LayerVisual](/uwp/api/windows.ui.composition.layervisual) (ビジュアルのサブツリー)。</span><span class="sxs-lookup"><span data-stu-id="68907-105">The [DropShadow](/uwp/api/Windows.UI.Composition.DropShadow) class provides means of creating a configurable shadow that can be applied to a [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual) or [LayerVisual](/uwp/api/windows.ui.composition.layervisual) (subtree of Visuals).</span></span> <span data-ttu-id="68907-106">ビジュアル層でオブジェクトの慣習はでは、CompositionAnimations を使用して、DropShadow のすべてのプロパティをアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="68907-106">As is customary for objects in the Visual Layer, all properties of the DropShadow can be animated using CompositionAnimations.</span></span>

## <a name="basic-drop-shadow"></a><span data-ttu-id="68907-107">基本的なドロップ シャドウ</span><span class="sxs-lookup"><span data-stu-id="68907-107">Basic drop shadow</span></span>

<span data-ttu-id="68907-108">基本的な影を作成するには、新しい DropShadow を作成し、それをビジュアルに関連付けます。</span><span class="sxs-lookup"><span data-stu-id="68907-108">To create a basic shadow, simply create a new DropShadow and associate it to your visual.</span></span> <span data-ttu-id="68907-109">シャドウは既定では四角形です。</span><span class="sxs-lookup"><span data-stu-id="68907-109">The shadow is rectangular by default.</span></span> <span data-ttu-id="68907-110">標準的な一連のプロパティをシャドウのルック アンド フィールを調整する利用できます。</span><span class="sxs-lookup"><span data-stu-id="68907-110">A standard set of properties are available to tweak the look and feel of your shadow.</span></span>

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

![四角形のビジュアルを基本 DropShadow](images/rectangular-dropshadow.png)

## <a name="shaping-the-shadow"></a><span data-ttu-id="68907-112">影の整形</span><span class="sxs-lookup"><span data-stu-id="68907-112">Shaping the shadow</span></span>

<span data-ttu-id="68907-113">これには、DropShadow の形を定義するいくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="68907-113">There are a few ways to define the shape for your DropShadow:</span></span>

- <span data-ttu-id="68907-114">**既定値を使用して、** - 既定では、DropShadow 図形が CompositionDropShadowSourcePolicy で 'Default' モードで定義されています。</span><span class="sxs-lookup"><span data-stu-id="68907-114">**Use the default** - By default the DropShadow shape is defined by the ‘Default’ mode on CompositionDropShadowSourcePolicy.</span></span> <span data-ttu-id="68907-115">SpriteVisual で、既定値は四角形、マスクを指定しない場合です。</span><span class="sxs-lookup"><span data-stu-id="68907-115">For SpriteVisual, the Default is Rectangular unless a mask is provided.</span></span> <span data-ttu-id="68907-116">LayerVisual、既定値では、ビジュアルのブラシのアルファを使用してマスクを継承します。</span><span class="sxs-lookup"><span data-stu-id="68907-116">For LayerVisual, Default is to inherit a mask using the alpha of the visual’s brush.</span></span>
- <span data-ttu-id="68907-117">**マスクを設定**– を設定することがあります、[マスク](/uwp/api/windows.ui.composition.dropshadow.mask)シャドウの不透明度マスクを定義するプロパティ。</span><span class="sxs-lookup"><span data-stu-id="68907-117">**Set a mask** – You may set the [Mask](/uwp/api/windows.ui.composition.dropshadow.mask) property to define an opacity mask for the shadow.</span></span>
- <span data-ttu-id="68907-118">**継承されたマスクを使用するように指定**設定 –、 [SourcePolicy](/uwp/api/windows.ui.composition.dropshadow.sourcepolicy)プロパティを使用する[CompositionDropShadowSourcePolicy](/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy)します。</span><span class="sxs-lookup"><span data-stu-id="68907-118">**Specify to use Inherited mask** – Set the [SourcePolicy](/uwp/api/windows.ui.composition.dropshadow.sourcepolicy) property to use [CompositionDropShadowSourcePolicy](/uwp/api/windows.ui.composition.compositiondropshadowsourcepolicy).</span></span> <span data-ttu-id="68907-119">InheritFromVisualContent ビジュアルのブラシのアルファから生成されるマスクを使用します。</span><span class="sxs-lookup"><span data-stu-id="68907-119">InheritFromVisualContent to use the mask generated from the alpha of the visual’s brush.</span></span>

## <a name="masking-to-match-your-content"></a><span data-ttu-id="68907-120">コンテンツの一致するようにマスク</span><span class="sxs-lookup"><span data-stu-id="68907-120">Masking to match your content</span></span>

<span data-ttu-id="68907-121">ビジュアルのコンテンツの一致するように、シャドウする場合、ビジュアルのブラシを使用して、シャドウ マスク プロパティのかコンテンツからマスクを自動的に継承するように影を設定します。</span><span class="sxs-lookup"><span data-stu-id="68907-121">If you want your shadow to match the Visual’s content you can either use the Visual’s brush for your Shadow mask property, or set the shadow to automatically inherit mask from the content.</span></span> <span data-ttu-id="68907-122">場合は、LayerVisual を使用して、影は既定では、マスクを継承します。</span><span class="sxs-lookup"><span data-stu-id="68907-122">If using a LayerVisual, the shadow will inherit the mask by default.</span></span>

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

![マスクされたドロップ シャドウを伴って接続された web イメージ](images/ms-brand-web-dropshadow.png)

## <a name="using-an-alternative-mask"></a><span data-ttu-id="68907-124">代替のマスクを使用してください。</span><span class="sxs-lookup"><span data-stu-id="68907-124">Using an alternative mask</span></span>

<span data-ttu-id="68907-125">場合によっては、図形、影のビジュアルのコンテンツと一致しないようにする場合があります。</span><span class="sxs-lookup"><span data-stu-id="68907-125">In some cases, you may want to shape the shadow such that it doesn’t match your Visual’s content.</span></span> <span data-ttu-id="68907-126">この効果を実現するには、アルファのブラシを使って、マスク プロパティを明示的に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="68907-126">To achieve this effect, you’ll need to explicitly set the Mask property using a brush with alpha.</span></span>

<span data-ttu-id="68907-127">次の例では、2 つのサーフェスのビジュアルのコンテンツのいずれかと、シャドウ マスク用に 1 つを読み込んでいます。</span><span class="sxs-lookup"><span data-stu-id="68907-127">In the below example, we load two surfaces - one for the Visual content and one for the Shadow mask:</span></span>

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

![接続された web イメージ枠で囲まれたマスク ドロップ シャドウ](images/ms-brand-web-masked-dropshadow.png)

## <a name="animating"></a><span data-ttu-id="68907-129">アニメーション化</span><span class="sxs-lookup"><span data-stu-id="68907-129">Animating</span></span>

<span data-ttu-id="68907-130">ビジュアル層で標準では、合成アニメーションを使用して、DropShadow プロパティをアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="68907-130">As is standard in the Visual Layer, DropShadow properties can be animated using Composition Animations.</span></span> <span data-ttu-id="68907-131">次の影のぼかしの半径をアニメーション化するのには、上の結び付けたりサンプルからコードを変更します。</span><span class="sxs-lookup"><span data-stu-id="68907-131">Below, we modify the code from the sprinkles sample above to animate the blur radius for the shadow.</span></span>

```cs
ScalarKeyFrameAnimation blurAnimation = _compositor.CreateScalarKeyFrameAnimation();
blurAnimation.InsertKeyFrame(0.0f, 25.0f);
blurAnimation.InsertKeyFrame(0.7f, 50.0f);
blurAnimation.InsertKeyFrame(1.0f, 25.0f);
blurAnimation.Duration = TimeSpan.FromSeconds(4);
blurAnimation.IterationBehavior = AnimationIterationBehavior.Forever;
shadow.StartAnimation("BlurRadius", blurAnimation);
```

## <a name="shadows-in-xaml"></a><span data-ttu-id="68907-132">XAML で影</span><span class="sxs-lookup"><span data-stu-id="68907-132">Shadows in XAML</span></span>

<span data-ttu-id="68907-133">複雑なフレームワーク要素に影を追加する場合は、XAML と合成の影付きの相互運用機能のいくつかの方法があります。</span><span class="sxs-lookup"><span data-stu-id="68907-133">If you want to add a shadow to more complex framework elements, there are a couple ways to interop with shadows between XAML and Composition:</span></span>

1. <span data-ttu-id="68907-134">使用して、 [DropShadowPanel](https://github.com/Microsoft/UWPCommunityToolkit/blob/master/Microsoft.Toolkit.Uwp.UI.Controls/DropShadowPanel/DropShadowPanel.Properties.cs) Windows の Community Toolkit で使用できます。</span><span class="sxs-lookup"><span data-stu-id="68907-134">Use the [DropShadowPanel](https://github.com/Microsoft/UWPCommunityToolkit/blob/master/Microsoft.Toolkit.Uwp.UI.Controls/DropShadowPanel/DropShadowPanel.Properties.cs) available in the Windows Community Toolkit.</span></span> <span data-ttu-id="68907-135">参照してください、 [DropShadowPanel ドキュメント](https://docs.microsoft.com/windows/uwpcommunitytoolkit/controls/DropShadowPanel)それを使用する方法の詳細について。</span><span class="sxs-lookup"><span data-stu-id="68907-135">See the [DropShadowPanel documentation](https://docs.microsoft.com/windows/uwpcommunitytoolkit/controls/DropShadowPanel) for details on how to use it.</span></span>
1. <span data-ttu-id="68907-136">シャドウのホストとして使用して、& XAML 配布資料 Visual に関連付けることにビジュアルを作成します。</span><span class="sxs-lookup"><span data-stu-id="68907-136">Create a Visual to use as the shadow host & tie it to the XAML handout Visual.</span></span>
1. <span data-ttu-id="68907-137">使用して、コンポジション サンプル ギャラリーの[SamplesCommon](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SamplesCommon/SamplesCommon)カスタム CompositionShadow コントロール。</span><span class="sxs-lookup"><span data-stu-id="68907-137">Use the Composition Sample Gallery’s [SamplesCommon](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SamplesCommon/SamplesCommon) custom CompositionShadow control.</span></span> <span data-ttu-id="68907-138">使用状況の次の例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="68907-138">See the example here for usage.</span></span>

## <a name="performance"></a><span data-ttu-id="68907-139">パフォーマンス</span><span class="sxs-lookup"><span data-stu-id="68907-139">Performance</span></span>

<span data-ttu-id="68907-140">ビジュアル層は、多くの最適化を効率的かつ使用可能な効果を設定する場所には、影を生成すると、どのようなオプションを設定するによって比較的高価な操作を指定できます。</span><span class="sxs-lookup"><span data-stu-id="68907-140">Although the Visual Layer has many optimizations in place to make effects efficient and usable, generating shadows can be a relatively expensive operation depending on what options you set.</span></span> <span data-ttu-id="68907-141">高レベル '' のコストの影のさまざまな種類を次に示します。</span><span class="sxs-lookup"><span data-stu-id="68907-141">Below are high level 'costs' for different types of shadows.</span></span> <span data-ttu-id="68907-142">特定の影が高価な場合がありますが、ある可能性があります特定のシナリオで慎重に使用する適切なに注意してください。</span><span class="sxs-lookup"><span data-stu-id="68907-142">Note that although certain shadows may be expensive they may still be appropriate to use sparingly in certain scenarios.</span></span>

<span data-ttu-id="68907-143">シャドウの特性</span><span class="sxs-lookup"><span data-stu-id="68907-143">Shadow Characteristics</span></span>| <span data-ttu-id="68907-144">コスト</span><span class="sxs-lookup"><span data-stu-id="68907-144">Cost</span></span>
------------- | -------------
<span data-ttu-id="68907-145">[四角形の領域切り取り]</span><span class="sxs-lookup"><span data-stu-id="68907-145">Rectangular</span></span>    | <span data-ttu-id="68907-146">低</span><span class="sxs-lookup"><span data-stu-id="68907-146">Low</span></span>
<span data-ttu-id="68907-147">Shadow.Mask</span><span class="sxs-lookup"><span data-stu-id="68907-147">Shadow.Mask</span></span>      | <span data-ttu-id="68907-148">高</span><span class="sxs-lookup"><span data-stu-id="68907-148">High</span></span>
<span data-ttu-id="68907-149">CompositionDropShadowSourcePolicy.InheritFromVisualContent</span><span class="sxs-lookup"><span data-stu-id="68907-149">CompositionDropShadowSourcePolicy.InheritFromVisualContent</span></span> | <span data-ttu-id="68907-150">高</span><span class="sxs-lookup"><span data-stu-id="68907-150">High</span></span>
<span data-ttu-id="68907-151">静的ぼかしの半径</span><span class="sxs-lookup"><span data-stu-id="68907-151">Static Blur Radius</span></span> | <span data-ttu-id="68907-152">低</span><span class="sxs-lookup"><span data-stu-id="68907-152">Low</span></span>
<span data-ttu-id="68907-153">ぼかしの半径をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="68907-153">Animating Blur Radius</span></span> | <span data-ttu-id="68907-154">高</span><span class="sxs-lookup"><span data-stu-id="68907-154">High</span></span>

## <a name="additional-resources"></a><span data-ttu-id="68907-155">その他のリソース</span><span class="sxs-lookup"><span data-stu-id="68907-155">Additional Resources</span></span>

- [<span data-ttu-id="68907-156">コンポジション DropShadow API</span><span class="sxs-lookup"><span data-stu-id="68907-156">Composition DropShadow API</span></span>](/uwp/api/Windows.UI.Composition.DropShadow)
- [<span data-ttu-id="68907-157">WindowsUIDevLabs GitHub リポジトリ</span><span class="sxs-lookup"><span data-stu-id="68907-157">WindowsUIDevLabs GitHub Repo</span></span>](https://github.com/Microsoft/WindowsUIDevLabs)