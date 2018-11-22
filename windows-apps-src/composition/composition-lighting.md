---
author: daneuber
title: コンポジションの照明
description: アプリに 3D の動的な照明を追加する、コンポジションの照明 Api を使用できます。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: c5c7bfcb06eb673b0516cef7882685ebd19ddb97
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7573076"
---
# <a name="using-lights-in-windows-ui"></a><span data-ttu-id="d5f01-104">Windows UI でのライトの使用</span><span class="sxs-lookup"><span data-stu-id="d5f01-104">Using lights in Windows UI</span></span>

<span data-ttu-id="d5f01-105">Windows.UI.Composition Api を使用すると、リアルタイムのアニメーションや効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-105">The Windows.UI.Composition APIs enable you to create real-time animations and effects.</span></span> <span data-ttu-id="d5f01-106">コンポジションの照明は、2 D のアプリケーションで 3D の照明を使用できます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-106">Composition Lighting enables 3D lighting in 2D applications.</span></span> <span data-ttu-id="d5f01-107">この概要では、コンポジションの照明をセットアップし、各ライトを受信する視覚効果を識別し、効果を使用して、コンテンツの素材を定義する方法の機能を実行します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-107">In this overview, we will run through the functionality of how to setup composition lights, identify visuals to receive each light, and use effects to define materials for your content.</span></span>

> [!NOTE]
> <span data-ttu-id="d5f01-108">[XamlLight](/uwp/api/windows.ui.xaml.media.xamllight)オブジェクトが XAML Uielement を照射する[Compositionlight](/uwp/api/Windows.UI.Composition.CompositionLight)を適用する方法を読み取り、 [XAML の照明](xaml-lighting.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d5f01-108">To read how [XamlLight](/uwp/api/windows.ui.xaml.media.xamllight) objects apply [CompositionLights](/uwp/api/Windows.UI.Composition.CompositionLight) to illuminate XAML UIElements, see [XAML lighting](xaml-lighting.md).</span></span>

<span data-ttu-id="d5f01-109">コンポジションの照明を使用することを許可する UI を興味深いを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-109">Composition lighting lets you create interesting UI by allowing:</span></span>

- <span data-ttu-id="d5f01-110">音楽再生シーンなどのイマーシブのシナリオを実現するシーン内の他のオブジェクトのライトに依存しないの変換します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-110">Transformation of a light independent of other objects in the scene to enable immersive scenarios like music playback scenes.</span></span>
- <span data-ttu-id="d5f01-111">一緒に移動できるように、ライトを使ってオブジェクトをペアリングする機能を Fluent[表示](/design/style/reveal.md)ハイライトなどのシナリオを有効にするシーンの残りの部分の独立しました。</span><span class="sxs-lookup"><span data-stu-id="d5f01-111">The ability to pair an object with a light so they move together independent of the rest of the scene to enable scenarios like Fluent [Reveal](/design/style/reveal.md) highlight.</span></span>
- <span data-ttu-id="d5f01-112">素材と深度を作成するグループとして光とシーン全体の変換します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-112">Transformation of the light and entire scene as a group to create materials and depth.</span></span>

<span data-ttu-id="d5f01-113">コンポジションの照明は次の 3 つの主要な概念をサポートしています:**光**、**ターゲット**、および**SceneLightingEffect**します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-113">Composition lighting supports three key concepts: **Light**, **Targets**, and **SceneLightingEffect**.</span></span>

## <a name="light"></a><span data-ttu-id="d5f01-114">Light</span><span class="sxs-lookup"><span data-stu-id="d5f01-114">Light</span></span>

<span data-ttu-id="d5f01-115">[CompositionLight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight)を使用すると、さまざまなライトを作成し、座標空間に配置できます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-115">[CompositionLight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight) allows you to create various lights and place them in coordinate space.</span></span> <span data-ttu-id="d5f01-116">これらのライトがライトによって照らさとしてを識別するための視覚効果をターゲットします。</span><span class="sxs-lookup"><span data-stu-id="d5f01-116">These lights target visuals that you wish to identify as lit by the light.</span></span>

### <a name="light-types"></a><span data-ttu-id="d5f01-117">光源の種類</span><span class="sxs-lookup"><span data-stu-id="d5f01-117">Light Types</span></span>

| <span data-ttu-id="d5f01-118">種類</span><span class="sxs-lookup"><span data-stu-id="d5f01-118">Type</span></span> | <span data-ttu-id="d5f01-119">説明</span><span class="sxs-lookup"><span data-stu-id="d5f01-119">Description</span></span> |
| --- | --- |
| [<span data-ttu-id="d5f01-120">AmbientLight</span><span class="sxs-lookup"><span data-stu-id="d5f01-120">AmbientLight</span></span>](/uwp/api/windows.ui.composition.ambientlight) | <span data-ttu-id="d5f01-121">シーン内のすべてで表示される非方向領光を照射する光源が反映されます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-121">A light source that emits non-directional light that appears reflected by everything in the scene.</span></span> |
| [<span data-ttu-id="d5f01-122">DistantLight</span><span class="sxs-lookup"><span data-stu-id="d5f01-122">DistantLight</span></span>](/uwp/api/windows.ui.composition.distantlight) | <span data-ttu-id="d5f01-123">無限に大規模な離れた場所にある光源を 1 つの方向に光を照射します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-123">An infinitely large distant light source that emits light in a single direction.</span></span> <span data-ttu-id="d5f01-124">(太陽など)。</span><span class="sxs-lookup"><span data-stu-id="d5f01-124">Like the sun.</span></span> |
| [<span data-ttu-id="d5f01-125">PointLight</span><span class="sxs-lookup"><span data-stu-id="d5f01-125">PointLight</span></span>](/uwp/api/windows.ui.composition.pointlight) | <span data-ttu-id="d5f01-126">すべての方向に光を放射光のポイントのソース。</span><span class="sxs-lookup"><span data-stu-id="d5f01-126">A point source of light that emits light in all directions.</span></span> <span data-ttu-id="d5f01-127">電球など。</span><span class="sxs-lookup"><span data-stu-id="d5f01-127">Like a lightbulb.</span></span> |
| [<span data-ttu-id="d5f01-128">スポットライト</span><span class="sxs-lookup"><span data-stu-id="d5f01-128">SpotLight</span></span>](/uwp/api/windows.ui.composition.spotlight) | <span data-ttu-id="d5f01-129">内部コーンおよび外部コーン光を照射する光源です。</span><span class="sxs-lookup"><span data-stu-id="d5f01-129">A light source that emits inner and outer cones of light.</span></span> <span data-ttu-id="d5f01-130">など、しない懐中電灯します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-130">Like a flashlight.</span></span> |

## <a name="targets"></a><span data-ttu-id="d5f01-131">ターゲット</span><span class="sxs-lookup"><span data-stu-id="d5f01-131">Targets</span></span>

<span data-ttu-id="d5f01-132">ライトがビジュアルをターゲットと ([ターゲット](/uwp/api/windows.ui.composition.compositionlight.targets)の一覧に追加)、ビジュアル オブジェクトとすべてのサブフォルダーはの認識し、この光源に応答します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-132">When lights target a Visual (add to [Targets](/uwp/api/windows.ui.composition.compositionlight.targets) list), the Visual and all its descendants are aware of and respond to this light source.</span></span> <span data-ttu-id="d5f01-133">ポイント ライトの方向のアニメーションに対応するツリーと下にあるすべての視覚効果のルートに PointLight ソースの設定としてシンプルなことができます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-133">This can be something as simple as a setting a PointLight source at the root of a tree and all visuals below react to the animation of the point lights direction.</span></span>

<span data-ttu-id="d5f01-134">**ExclusionsFromTargets**では、ターゲットを追加する場合と同様の方法でビジュアルやビジュアルのサブツリーの照明を削除する機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-134">**ExclusionsFromTargets** gives you the ability to remove the lighting of a visual or of a subtree of visuals in a similar manner as adding targets.</span></span> <span data-ttu-id="d5f01-135">除外されるビジュアルをルートとツリー内の子がその結果点灯していません。</span><span class="sxs-lookup"><span data-stu-id="d5f01-135">Children in the tree rooted by the visual that's excluded are not lit as a result.</span></span>

### <a name="sample-targets"></a><span data-ttu-id="d5f01-136">(ターゲット) のサンプル</span><span class="sxs-lookup"><span data-stu-id="d5f01-136">Sample (Targets)</span></span>

<span data-ttu-id="d5f01-137">次のサンプルでは、XAML の TextBlock を対象に、CompositionPointLight を使用します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-137">In the sample below, we use a CompositionPointLight to target a XAML TextBlock.</span></span>

```cs
    _pointLight = _compositor.CreatePointLight();
    _pointLight.Color = Colors.White;
    _pointLight.CoordinateSpace = text; //set up co-ordinate space for offset
    _pointLight.Targets.Add(text); //target XAML TextBlock
```

<span data-ttu-id="d5f01-138">ポイント ライトのオフセットをアニメーションを追加することで光る効果は簡単に実現されます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-138">By adding animation to the offset of the point light, a shimmering effect is easily achieved.</span></span>

```cs
_pointLight.Offset = new Vector3(-(float)TextBlock.ActualWidth, (float)TextBlock.ActualHeight / 2, (float)TextBlock.FontSize);
```

<span data-ttu-id="d5f01-139">詳細については WindowUIDevLabs サンプル ゲラビューで[テキストちらついて](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/TextShimmer)の完全なサンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="d5f01-139">See the complete [Text Shimmer](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/TextShimmer) sample at the WindowUIDevLabs Sample Galley to learn more.</span></span>

## <a name="restrictions"></a><span data-ttu-id="d5f01-140">制限</span><span class="sxs-lookup"><span data-stu-id="d5f01-140">Restrictions</span></span>

<span data-ttu-id="d5f01-141">CompositionLight によって照らさ コンテンツを決定するときに考慮するいくつかの要因があります。</span><span class="sxs-lookup"><span data-stu-id="d5f01-141">There are several factors to consider when determining which content will be lit by CompositionLight.</span></span>

<span data-ttu-id="d5f01-142">概念</span><span class="sxs-lookup"><span data-stu-id="d5f01-142">Concept</span></span> | <span data-ttu-id="d5f01-143">詳細</span><span class="sxs-lookup"><span data-stu-id="d5f01-143">Details</span></span>
--- | ---
**<span data-ttu-id="d5f01-144">環境光</span><span class="sxs-lookup"><span data-stu-id="d5f01-144">Ambient Light</span></span>** | <span data-ttu-id="d5f01-145">シーンに非アンビエント照明を追加することにより、既存の光をすべてオフにします。</span><span class="sxs-lookup"><span data-stu-id="d5f01-145">Adding a non-ambient light to your scene will turn off all existing light.</span></span>  <span data-ttu-id="d5f01-146">非環境光が対象としないアイテムは黒く表示されます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-146">Items not targeted by a non-ambient light will appear black.</span></span>  <span data-ttu-id="d5f01-147">自然な方法でライトによって発信周囲の視覚効果を照射するには、他のライトと連携して、環境光を使用します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-147">To illuminate surrounding visuals not targeted by the light in a natural way, use an ambient light in conjunction with other lights.</span></span>
**<span data-ttu-id="d5f01-148">ライトの数</span><span class="sxs-lookup"><span data-stu-id="d5f01-148">Number of Lights</span></span>** | <span data-ttu-id="d5f01-149">任意の組み合わせで、2 つの非アンビエント コンポジション ライトを使用すると、UI をターゲットにすること。</span><span class="sxs-lookup"><span data-stu-id="d5f01-149">You may use any two non-ambient composition lights in any combination to target your UI.</span></span> <span data-ttu-id="d5f01-150">アンビエント照明ではありません。スポット、点、および離れた場所にあるライトがします。</span><span class="sxs-lookup"><span data-stu-id="d5f01-150">Ambient lights are not restricted; spot, point, and distant lights are.</span></span>
**<span data-ttu-id="d5f01-151">有効期間</span><span class="sxs-lookup"><span data-stu-id="d5f01-151">Lifetime</span></span>** | <span data-ttu-id="d5f01-152">CompositionLight 有効期間の条件が発生する可能性があります (例: が使用する前に、ガーベジ コレクターはライト オブジェクトをリサイクル可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="d5f01-152">CompositionLight may experience lifetime conditions (example: the garbage collector may recycle the light object before it is used).</span></span>  <span data-ttu-id="d5f01-153">アプリケーションの有効期間を管理するためのメンバーとして照明を追加することで、ライトへの参照を保持することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d5f01-153">We recommended keeping a reference to your lights by adding lights as a member to help the application manage lifetime.</span></span>
**<span data-ttu-id="d5f01-154">変換</span><span class="sxs-lookup"><span data-stu-id="d5f01-154">Transforms</span></span>** | <span data-ttu-id="d5f01-155">ライトは、ノード上では、[視点の変換](/design/layout/3-d-perspective-effects.md)のような効果、視覚的構造を適切に描画する UI に配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5f01-155">Lights must be placed in a node above UI that uses effects like [perspective transforms](/design/layout/3-d-perspective-effects.md) in your visual structure to be drawn properly.</span></span>
**<span data-ttu-id="d5f01-156">ターゲットと座標空間</span><span class="sxs-lookup"><span data-stu-id="d5f01-156">Targets and Coordinate Space</span></span>** | <span data-ttu-id="d5f01-157">CoordinateSpace は、ビジュアルの領域のすべてのライトのプロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5f01-157">CoordinateSpace is the visual space in which all the lights properties must be set.</span></span> <span data-ttu-id="d5f01-158">CompositionLight.Targets は CoordinateSpace ツリー内である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d5f01-158">CompositionLight.Targets must be within the CoordinateSpace tree.</span></span>

## <a name="lighting-properties"></a><span data-ttu-id="d5f01-159">光源のプロパティ</span><span class="sxs-lookup"><span data-stu-id="d5f01-159">Lighting Properties</span></span>

<span data-ttu-id="d5f01-160">、使用される光源の種類に応じて、光の減衰と領域のプロパティことができます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-160">Depending on the type of light used, a light can have properties for attenuation and space.</span></span> <span data-ttu-id="d5f01-161">すべての種類の光源がすべてのプロパティを使うわけではありません。</span><span class="sxs-lookup"><span data-stu-id="d5f01-161">Not all types of lights use all properties.</span></span>

<span data-ttu-id="d5f01-162">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d5f01-162">Property</span></span> | <span data-ttu-id="d5f01-163">説明</span><span class="sxs-lookup"><span data-stu-id="d5f01-163">Description</span></span>
--- | ---
**<span data-ttu-id="d5f01-164">色</span><span class="sxs-lookup"><span data-stu-id="d5f01-164">Color</span></span>** | <span data-ttu-id="d5f01-165">光の[色](/uwp/api/windows.ui.color)。</span><span class="sxs-lookup"><span data-stu-id="d5f01-165">The [Color](/uwp/api/windows.ui.color) of the light.</span></span> <span data-ttu-id="d5f01-166">照明の適用色の値は、 [D3D](https://docs.microsoft.com/windows/uwp/graphics-concepts/light-properties)拡散、アンビエント、および放射される色を定義するスペキュラによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-166">Lighting color values are defined by [D3D](https://docs.microsoft.com/windows/uwp/graphics-concepts/light-properties) Diffuse, Ambient, and Specular that defines the color being emitted.</span></span> <span data-ttu-id="d5f01-167">照明がライトの RGBA 値を使用します。アルファ色コンポーネントは使われません。</span><span class="sxs-lookup"><span data-stu-id="d5f01-167">Lighting uses RGBA values for lights; the alpha color component is not used.</span></span>
**<span data-ttu-id="d5f01-168">Direction</span><span class="sxs-lookup"><span data-stu-id="d5f01-168">Direction</span></span>** | <span data-ttu-id="d5f01-169">光の方向です。</span><span class="sxs-lookup"><span data-stu-id="d5f01-169">The direction of light.</span></span> <span data-ttu-id="d5f01-170">その[CoordinateSpace](/uwp/api/windows.ui.composition.distantlight.coordinatespace) Visual を基準とした、光が指している方向を指定します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-170">The direction in which the light is pointing is specified relative to its [CoordinateSpace](/uwp/api/windows.ui.composition.distantlight.coordinatespace) Visual.</span></span>
**<span data-ttu-id="d5f01-171">座標空間</span><span class="sxs-lookup"><span data-stu-id="d5f01-171">Coordinate Space</span></span>** | <span data-ttu-id="d5f01-172">すべてのビジュアルには、暗黙的な 3D の座標空間があります。</span><span class="sxs-lookup"><span data-stu-id="d5f01-172">Every Visual has an implicit 3D coordinate space.</span></span> <span data-ttu-id="d5f01-173">X 方向が左から右にです。</span><span class="sxs-lookup"><span data-stu-id="d5f01-173">X direction is from left to right.</span></span> <span data-ttu-id="d5f01-174">Y 方向は、上から下です。</span><span class="sxs-lookup"><span data-stu-id="d5f01-174">Y direction is from top to bottom.</span></span> <span data-ttu-id="d5f01-175">Z 方向は、平面外ポイントです。</span><span class="sxs-lookup"><span data-stu-id="d5f01-175">Z direction is a point out of the plane.</span></span> <span data-ttu-id="d5f01-176">この座標の元のポイントは、ビジュアルの左上隅と、単位は、デバイス依存しないピクセル (DIP)。</span><span class="sxs-lookup"><span data-stu-id="d5f01-176">The original point of this coordinate is the upper-left corner of the visual, and the unit is Device Independent Pixel (DIP).</span></span> <span data-ttu-id="d5f01-177">この座標で定義されている光のオフセットです。</span><span class="sxs-lookup"><span data-stu-id="d5f01-177">A light's offset defined in this coordinate.</span></span>
**<span data-ttu-id="d5f01-178">内部コーンおよび外部コーン</span><span class="sxs-lookup"><span data-stu-id="d5f01-178">Inner and Outer Cones</span></span>** | <span data-ttu-id="d5f01-179">スポットライトは、明るい内部コーンと外部コーンの 2 つの部分を持つ光のコーンを放射します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-179">Spotlights emit a cone of light that has two parts: a bright inner cone and an outer cone.</span></span> <span data-ttu-id="d5f01-180">コンポジションでは、内部および外部コーン角度と色を制御できます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-180">Composition allows you control over inner and outer cone angles and color.</span></span>
**<span data-ttu-id="d5f01-181">Offset</span><span class="sxs-lookup"><span data-stu-id="d5f01-181">Offset</span></span>** | <span data-ttu-id="d5f01-182">その座標空間 Visual を基準とした光源のオフセットです。</span><span class="sxs-lookup"><span data-stu-id="d5f01-182">Offset of the light source relative to its coordinate space Visual.</span></span>

> [!NOTE]
> <span data-ttu-id="d5f01-183">複数の照明同じのビジュアルに当たったとき、または光の色の値が 1.0 を超過する十分な大きさが取得されるたびには、ライト カラー チャネルのクランプがあるため、光の色が変更できます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-183">When multiple lights hit the same Visual, or whenever a light's color value gets large enough to exceed 1.0, the color of the light may change because of clamping of a lights color channel.</span></span>

### <a name="advanced-lighting-properties"></a><span data-ttu-id="d5f01-184">高度なライティング プロパティ</span><span class="sxs-lookup"><span data-stu-id="d5f01-184">Advanced Lighting Properties</span></span>

<span data-ttu-id="d5f01-185">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d5f01-185">Property</span></span> | <span data-ttu-id="d5f01-186">説明</span><span class="sxs-lookup"><span data-stu-id="d5f01-186">Description</span></span>
--- | ---
**<span data-ttu-id="d5f01-187">強さ</span><span class="sxs-lookup"><span data-stu-id="d5f01-187">Intensity</span></span>** | <span data-ttu-id="d5f01-188">光の明るさを制御します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-188">Controls the brightness of the light.</span></span>
**<span data-ttu-id="d5f01-189">減衰</span><span class="sxs-lookup"><span data-stu-id="d5f01-189">Attenuation</span></span>** | <span data-ttu-id="d5f01-190">減衰は、範囲プロパティによって指定された最大距離にいたるまでに光の強さがどのように弱くなっていくかを制御します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-190">Attenuation controls how a light's intensity decreases toward the maximum distance specified by the range property.</span></span>  <span data-ttu-id="d5f01-191">定数、Quadradic と線形減衰プロパティことができます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-191">Constant, Quadradic and Linear attenuation properties can be used.</span></span>

## <a name="getting-started-with-lighting"></a><span data-ttu-id="d5f01-192">照明の概要</span><span class="sxs-lookup"><span data-stu-id="d5f01-192">Getting Started with Lighting</span></span>

<span data-ttu-id="d5f01-193">照明を追加する一般的な手順に従います。</span><span class="sxs-lookup"><span data-stu-id="d5f01-193">Follow these general steps to add lights:</span></span>

- <span data-ttu-id="d5f01-194">作成し、ライトを配置: ライトを作成して、指定された座標空間に配置します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-194">Create and place the lights: Create lights and place them in a specified coordinate space.</span></span>
- <span data-ttu-id="d5f01-195">ライトへのオブジェクトを識別する: 関連する視覚効果に光をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="d5f01-195">Identify objects to light: Target light at relevant visuals.</span></span>
- <span data-ttu-id="d5f01-196">[オプション]個々 のオブジェクトを定義ライトへの対応: 光が反射 SpriteVisual を表示するためのカスタマイズ、EffectBrush と SceneLightingEffect を使用します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-196">[Optional] Define how individual objects react to lights: Use SceneLightingEffect with an EffectBrush to customize light reflection for displaying the SpriteVisual.</span></span> <span data-ttu-id="d5f01-197">反射の既定値は、光源の CoordinateSpace の子の照明をサポートします。</span><span class="sxs-lookup"><span data-stu-id="d5f01-197">Reflection defaults support the lighting of children of a light source’s CoordinateSpace.</span></span>  <span data-ttu-id="d5f01-198">視覚的な SceneLightingEffect で塗りつぶすには、そのビジュアルの既定の照明が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-198">A visual painted with a SceneLightingEffect overwrites the default lighting for that visual.</span></span>

## <a name="scenelightingeffect"></a><span data-ttu-id="d5f01-199">SceneLightingEffect</span><span class="sxs-lookup"><span data-stu-id="d5f01-199">SceneLightingEffect</span></span>

<span data-ttu-id="d5f01-200">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)を使用して、 [CompositionLight](/uwp/api/windows.ui.composition.compositionlight)の対象となる[SpriteVisual](/uwp/api/Windows.UI.Composition.SpriteVisual)の内容に適用される既定の照明を変更できます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-200">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) is used to modify the default lighting applied to the contents of a [SpriteVisual](/uwp/api/Windows.UI.Composition.SpriteVisual) targeted by a [CompositionLight](/uwp/api/windows.ui.composition.compositionlight).</span></span>

<span data-ttu-id="d5f01-201">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)は、素材の作成によく使用されます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-201">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) is frequently used for material creation.</span></span> <span data-ttu-id="d5f01-202">SceneLightingEffect は、イメージの反射プロパティを有効にするや、法線マップを使用して、奥行き感を提供するようより複雑なものを実現するために必要なときに使用する効果です。</span><span class="sxs-lookup"><span data-stu-id="d5f01-202">A SceneLightingEffect is an effect used when you want to achieve something more complex, like enabling reflective properties on an image and/or providing an illusion of depth with a normal map.</span></span> <span data-ttu-id="d5f01-203">SceneLightingEffect 反射および拡散量などの照明のプロパティを使用して、UI をカスタマイズする機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-203">A SceneLightingEffect provides the ability to customize your UI by using the lighting properties like specular and diffuse amounts.</span></span> <span data-ttu-id="d5f01-204">個別にブレンドし、コンテンツを含むさまざまな照明反応できる効果パイプラインの残りの部分で照明効果をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-204">You can further customize lighting effects with the rest of the effects pipeline allowing you individually to blend and compose different lighting reactions with your content.</span></span>

> [!NOTE]
> <span data-ttu-id="d5f01-205">シーンの照明がシャドウを生成しません。2D レンダリングに重点を置いて効果です。</span><span class="sxs-lookup"><span data-stu-id="d5f01-205">Scene lighting does not produce shadows; it is an effect focused on 2D rendering.</span></span>  <span data-ttu-id="d5f01-206">実際の照明モデルでは、シャドウをなどが含まれている考慮 3D 照明シナリオには実行されません。</span><span class="sxs-lookup"><span data-stu-id="d5f01-206">It does not take into consideration 3D lighting scenarios that include real lighting models, including shadows.</span></span>


<span data-ttu-id="d5f01-207">プロパティ</span><span class="sxs-lookup"><span data-stu-id="d5f01-207">Property</span></span> | <span data-ttu-id="d5f01-208">説明</span><span class="sxs-lookup"><span data-stu-id="d5f01-208">Description</span></span>
--- | ---
**<span data-ttu-id="d5f01-209">法線マップ</span><span class="sxs-lookup"><span data-stu-id="d5f01-209">Normal Map</span></span>** | <span data-ttu-id="d5f01-210">NormalMaps では、位置、光の方向に通常のポイントは明るくなりますができ、法線を指している離れた調光のテクスチャの効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-210">NormalMaps create an effect of a texture where a normal pointing towards the light will be brighter and a normal pointing away will be dimmer.</span></span> <span data-ttu-id="d5f01-211">対象となる visual NormalMap を追加するには、NormalMap アセットを読み込む LoadedImageSurface を使用して[CompositionSurfaceBrush](/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)を使用します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-211">To add a NormalMap to your targeted visual use a [CompositionSurfaceBrush](/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) using LoadedImageSurface to load a NormalMap asset.</span></span>
**<span data-ttu-id="d5f01-212">環境光</span><span class="sxs-lookup"><span data-stu-id="d5f01-212">Ambient</span></span>** | <span data-ttu-id="d5f01-213">環境光のプロパティは、全体的な色のリフレクションを制御するほとんど使用されます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-213">Ambient properties are mostly used to control the overall color reflection.</span></span>
**<span data-ttu-id="d5f01-214">反射</span><span class="sxs-lookup"><span data-stu-id="d5f01-214">Specular</span></span>** | <span data-ttu-id="d5f01-215">反射光では、オブジェクト、光沢のある表示したりすることで強調表示を作成します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-215">Specular reflection creates highlights on objects, making them appear shiny.</span></span> <span data-ttu-id="d5f01-216">反射光のレベルだけでなく輝きのレベルを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-216">You can control the level of specular reflection as well as the level of shine.</span></span>  <span data-ttu-id="d5f01-217">これらのプロパティは、光沢金属または光沢のあるホワイト ペーパーなどのマテリアルの効果を作成する操作されます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-217">These properties are manipulated to create material effects like shinny metals or glossy paper.</span></span>
**<span data-ttu-id="d5f01-218">拡散</span><span class="sxs-lookup"><span data-stu-id="d5f01-218">Diffuse</span></span>** | <span data-ttu-id="d5f01-219">拡散されたリフレクションでは、すべての方向に光を拡散します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-219">Diffused reflection scatters the light in all directions.</span></span>
**<span data-ttu-id="d5f01-220">反射率モデル</span><span class="sxs-lookup"><span data-stu-id="d5f01-220">Reflectance Model</span></span>** | <span data-ttu-id="d5f01-221">[反射率モデル](/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel)では、 [Blinn フォン](https://docs.microsoft.com/visualstudio/designers/how-to-create-a-basic-phong-shader)Blinn フォンを物理的に基づくどれかを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="d5f01-221">[Reflectance Model](/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel) allows you to choose between [Blinn Phong](https://docs.microsoft.com/visualstudio/designers/how-to-create-a-basic-phong-shader) and Physically Based Blinn Phong.</span></span>  <span data-ttu-id="d5f01-222">反射光が縮小する場合は、Blinn フォンを物理的に基づくを選択します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-222">You would choose Physically Based Blinn Phong when you want to have condensed specular highlights.</span></span>

### <a name="sample-scenelightingeffect"></a><span data-ttu-id="d5f01-223">サンプル (SceneLightingEffect)</span><span class="sxs-lookup"><span data-stu-id="d5f01-223">Sample (SceneLightingEffect)</span></span>

<span data-ttu-id="d5f01-224">次のサンプルは、SceneLightingEffect に通常マップを追加する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="d5f01-224">The sample below shows how to add a normal map to a SceneLightingEffect.</span></span>

```cs
CompositionBrush CreateNormalMapBrush(ICompositionSurface normalMapImage)
{
    var colorSourceEffect = new ColorSourceEffect()
    {
        Color = Colors.White
    };
    var sceneLightingEffect = new SceneLightingEffect()
    {
        NormalMapSource = new CompositionEffectSourceParameter("NormalMap")
    };

    var compositeEffect = new ArithmeticCompositeEffect()
    {
        Source1 = colorSourceEffect,
        Source2 = sceneLightingEffect,
    };

    var factory = _compositor.CreateEffectFactory(sceneLightingEffect);

    var normalMapBrush = _compositor.CreateSurfaceBrush();
    normalMapBrush.Surface = normalMapImage;
    normalMapBrush.Stretch = CompositionStretch.Fill;

    var brush = factory.CreateBrush();
    brush.SetSourceParameter("NormalMap", normalMapBrush);

    return brush;
}
```

## <a name="related-articles"></a><span data-ttu-id="d5f01-225">関連記事</span><span class="sxs-lookup"><span data-stu-id="d5f01-225">Related articles</span></span>

- [<span data-ttu-id="d5f01-226">ビジュアル レイヤーの素材とライトを作成します。</span><span class="sxs-lookup"><span data-stu-id="d5f01-226">Creating Materials and Lights in the Visual Layer</span></span>](https://blogs.windows.com/buildingapps/2017/08/04/creating-materials-lights-visual-layer/)
- [<span data-ttu-id="d5f01-227">光源の概要</span><span class="sxs-lookup"><span data-stu-id="d5f01-227">Lighting Overview</span></span>](https://docs.microsoft.com/windows/uwp/graphics-concepts/lighting-overview)
- [<span data-ttu-id="d5f01-228">CompositionCapabilities API</span><span class="sxs-lookup"><span data-stu-id="d5f01-228">CompositionCapabilities API</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositioncapabilities)
- [<span data-ttu-id="d5f01-229">光源の計算</span><span class="sxs-lookup"><span data-stu-id="d5f01-229">Mathematics of Lighting</span></span>](https://docs.microsoft.com/windows/uwp/graphics-concepts/mathematics-of-lighting)
- [<span data-ttu-id="d5f01-230">SceneLightingEffect</span><span class="sxs-lookup"><span data-stu-id="d5f01-230">SceneLightingEffect</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffect)
- [<span data-ttu-id="d5f01-231">WindowsUIDevLabs GitHub リポジトリ</span><span class="sxs-lookup"><span data-stu-id="d5f01-231">WindowsUIDevLabs GitHub Repo</span></span>](https://github.com/Microsoft/WindowsUIDevLabs)
