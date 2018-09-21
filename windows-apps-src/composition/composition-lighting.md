---
author: daneuber
title: コンポジションの照明
description: アプリに 3D の動的な照明を追加する、コンポジションの照明の Api を使用できます。
ms.author: jimwalk
ms.date: 07/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: e634b18fffc4f601f6512d6ceeed51efbe9c1886
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4125797"
---
# <a name="using-lights-in-windows-ui"></a><span data-ttu-id="22fdf-104">Windows UI でのライトの使用</span><span class="sxs-lookup"><span data-stu-id="22fdf-104">Using lights in Windows UI</span></span>

<span data-ttu-id="22fdf-105">Windows.UI.Composition Api を使用すると、リアルタイムのアニメーションや効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-105">The Windows.UI.Composition APIs enable you to create real-time animations and effects.</span></span> <span data-ttu-id="22fdf-106">コンポジションの照明は、2 D のアプリケーションで 3D の照明を使用できます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-106">Composition Lighting enables 3D lighting in 2D applications.</span></span> <span data-ttu-id="22fdf-107">この概要では、コンポジションの照明をセットアップし、各ライトを受信する視覚効果を識別および、効果を使用して、コンテンツの素材を定義する方法の機能を実行します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-107">In this overview, we will run through the functionality of how to setup composition lights, identify visuals to receive each light, and use effects to define materials for your content.</span></span>

> [!NOTE]
> <span data-ttu-id="22fdf-108">[XamlLight](/uwp/api/windows.ui.xaml.media.xamllight)オブジェクトを XAML Uielement を照射する[Compositionlight](/uwp/api/Windows.UI.Composition.CompositionLight)の適用方法を読み取り、 [XAML の照明](xaml-lighting.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="22fdf-108">To read how [XamlLight](/uwp/api/windows.ui.xaml.media.xamllight) objects apply [CompositionLights](/uwp/api/Windows.UI.Composition.CompositionLight) to illuminate XAML UIElements, see [XAML lighting](xaml-lighting.md).</span></span>

<span data-ttu-id="22fdf-109">コンポジションの照明を使用することを許可する UI を興味深いを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-109">Composition lighting lets you create interesting UI by allowing:</span></span>

- <span data-ttu-id="22fdf-110">音楽再生シーンのようなイマーシブなシナリオを実現するシーン内の他のオブジェクトのライトに依存しないの変換します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-110">Transformation of a light independent of other objects in the scene to enable immersive scenarios like music playback scenes.</span></span>
- <span data-ttu-id="22fdf-111">一緒に移動できるように、光を持つオブジェクトをペアリングする機能を強調表示の Fluent を[表示](/design/style/reveal.md)するようなシナリオを有効にするシーンの残りの部分から独立しています。</span><span class="sxs-lookup"><span data-stu-id="22fdf-111">The ability to pair an object with a light so they move together independent of the rest of the scene to enable scenarios like Fluent [Reveal](/design/style/reveal.md) highlight.</span></span>
- <span data-ttu-id="22fdf-112">素材と深度を作成するグループとして光とシーン全体の変換します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-112">Transformation of the light and entire scene as a group to create materials and depth.</span></span>

<span data-ttu-id="22fdf-113">コンポジションの照明は次の 3 つの主要な概念をサポートしています:**光**、**ターゲット**、および**SceneLightingEffect**します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-113">Composition lighting supports three key concepts: **Light**, **Targets**, and **SceneLightingEffect**.</span></span>

## <a name="light"></a><span data-ttu-id="22fdf-114">Light</span><span class="sxs-lookup"><span data-stu-id="22fdf-114">Light</span></span>

<span data-ttu-id="22fdf-115">[CompositionLight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight)を使用すると、さまざまなライトを作成し、座標空間に配置できます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-115">[CompositionLight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight) allows you to create various lights and place them in coordinate space.</span></span> <span data-ttu-id="22fdf-116">これらのライトがライトによって照らさとしてを識別する視覚効果をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="22fdf-116">These lights target visuals that you wish to identify as lit by the light.</span></span>

### <a name="light-types"></a><span data-ttu-id="22fdf-117">光源の種類</span><span class="sxs-lookup"><span data-stu-id="22fdf-117">Light Types</span></span>

| <span data-ttu-id="22fdf-118">種類</span><span class="sxs-lookup"><span data-stu-id="22fdf-118">Type</span></span> | <span data-ttu-id="22fdf-119">説明</span><span class="sxs-lookup"><span data-stu-id="22fdf-119">Description</span></span> |
| --- | --- |
| [<span data-ttu-id="22fdf-120">AmbientLight</span><span class="sxs-lookup"><span data-stu-id="22fdf-120">AmbientLight</span></span>](/uwp/api/windows.ui.composition.ambientlight) | <span data-ttu-id="22fdf-121">シーン内のすべてで表示される非方向領光を照射する光源が反映されます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-121">A light source that emits non-directional light that appears reflected by everything in the scene.</span></span> |
| [<span data-ttu-id="22fdf-122">DistantLight</span><span class="sxs-lookup"><span data-stu-id="22fdf-122">DistantLight</span></span>](/uwp/api/windows.ui.composition.distantlight) | <span data-ttu-id="22fdf-123">無限に大規模な遠く光源が 1 つの方向に光を放射します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-123">An infinitely large distant light source that emits light in a single direction.</span></span> <span data-ttu-id="22fdf-124">(太陽など)。</span><span class="sxs-lookup"><span data-stu-id="22fdf-124">Like the sun.</span></span> |
| [<span data-ttu-id="22fdf-125">PointLight</span><span class="sxs-lookup"><span data-stu-id="22fdf-125">PointLight</span></span>](/uwp/api/windows.ui.composition.pointlight) | <span data-ttu-id="22fdf-126">すべての方向に光を放射光のポイントのソース。</span><span class="sxs-lookup"><span data-stu-id="22fdf-126">A point source of light that emits light in all directions.</span></span> <span data-ttu-id="22fdf-127">電球など。</span><span class="sxs-lookup"><span data-stu-id="22fdf-127">Like a lightbulb.</span></span> |
| [<span data-ttu-id="22fdf-128">スポットライト</span><span class="sxs-lookup"><span data-stu-id="22fdf-128">SpotLight</span></span>](/uwp/api/windows.ui.composition.spotlight) | <span data-ttu-id="22fdf-129">内部コーンおよび外部コーンの光を照射する光源です。</span><span class="sxs-lookup"><span data-stu-id="22fdf-129">A light source that emits inner and outer cones of light.</span></span> <span data-ttu-id="22fdf-130">など、しない懐中電灯します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-130">Like a flashlight.</span></span> |

## <a name="targets"></a><span data-ttu-id="22fdf-131">ターゲット</span><span class="sxs-lookup"><span data-stu-id="22fdf-131">Targets</span></span>

<span data-ttu-id="22fdf-132">ライトがビジュアルをターゲットと ([ターゲット](/uwp/api/windows.ui.composition.compositionlight.targets)の一覧に追加)、ビジュアル オブジェクトとすべてのサブフォルダーはの認識し、この光源に応答します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-132">When lights target a Visual (add to [Targets](/uwp/api/windows.ui.composition.compositionlight.targets) list), the Visual and all its descendants are aware of and respond to this light source.</span></span> <span data-ttu-id="22fdf-133">これは、単純なものツリーと下にあるすべての視覚効果のルートに PointLight ソースが対応ポイント ライトの方向のアニメーションを設定できます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-133">This can be something as simple as a setting a PointLight source at the root of a tree and all visuals below react to the animation of the point lights direction.</span></span>

<span data-ttu-id="22fdf-134">**ExclusionsFromTargets**では、ターゲットを追加する場合と同様の方法でビジュアルやビジュアルのサブツリーの照明を削除する機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-134">**ExclusionsFromTargets** gives you the ability to remove the lighting of a visual or of a subtree of visuals in a similar manner as adding targets.</span></span> <span data-ttu-id="22fdf-135">除外はビジュアルをルートとツリー内の子が結果として、点灯していません。</span><span class="sxs-lookup"><span data-stu-id="22fdf-135">Children in the tree rooted by the visual that's excluded are not lit as a result.</span></span>

### <a name="sample-targets"></a><span data-ttu-id="22fdf-136">(ターゲット) のサンプル</span><span class="sxs-lookup"><span data-stu-id="22fdf-136">Sample (Targets)</span></span>

<span data-ttu-id="22fdf-137">次のサンプルでは、XAML の TextBlock をターゲットにする CompositionPointLight を使用します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-137">In the sample below, we use a CompositionPointLight to target a XAML TextBlock.</span></span>

```cs
    _pointLight = _compositor.CreatePointLight();
    _pointLight.Color = Colors.White;
    _pointLight.CoordinateSpace = text; //set up co-ordinate space for offset
    _pointLight.Targets.Add(text); //target XAML TextBlock
```

<span data-ttu-id="22fdf-138">ポイント ライトのオフセットをアニメーションを追加することで光る効果は簡単に実現されます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-138">By adding animation to the offset of the point light, a shimmering effect is easily achieved.</span></span>

```cs
_pointLight.Offset = new Vector3(-(float)TextBlock.ActualWidth, (float)TextBlock.ActualHeight / 2, (float)TextBlock.FontSize);
```

<span data-ttu-id="22fdf-139">詳細については WindowUIDevLabs サンプル ゲラビューで[テキストちらついて](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/TextShimmer)の完全なサンプルを参照してください。</span><span class="sxs-lookup"><span data-stu-id="22fdf-139">See the complete [Text Shimmer](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/TextShimmer) sample at the WindowUIDevLabs Sample Galley to learn more.</span></span>

## <a name="restrictions"></a><span data-ttu-id="22fdf-140">制限</span><span class="sxs-lookup"><span data-stu-id="22fdf-140">Restrictions</span></span>

<span data-ttu-id="22fdf-141">CompositionLight によって照らさ コンテンツを決定するときに考慮するいくつかの要因があります。</span><span class="sxs-lookup"><span data-stu-id="22fdf-141">There are several factors to consider when determining which content will be lit by CompositionLight.</span></span>

<span data-ttu-id="22fdf-142">概念</span><span class="sxs-lookup"><span data-stu-id="22fdf-142">Concept</span></span> | <span data-ttu-id="22fdf-143">詳細</span><span class="sxs-lookup"><span data-stu-id="22fdf-143">Details</span></span>
--- | ---
**<span data-ttu-id="22fdf-144">環境光</span><span class="sxs-lookup"><span data-stu-id="22fdf-144">Ambient Light</span></span>** | <span data-ttu-id="22fdf-145">シーンに非アンビエント照明を追加することにより、既存の光をすべてオフにします。</span><span class="sxs-lookup"><span data-stu-id="22fdf-145">Adding a non-ambient light to your scene will turn off all existing light.</span></span>  <span data-ttu-id="22fdf-146">非アンビエント照明を対象としないアイテムは黒く表示されます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-146">Items not targeted by a non-ambient light will appear black.</span></span>  <span data-ttu-id="22fdf-147">自然な方法でライトによって対象のない周囲の視覚効果を照射するには、他のライトと組み合わせて環境光を使用します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-147">To illuminate surrounding visuals not targeted by the light in a natural way, use an ambient light in conjunction with other lights.</span></span>
**<span data-ttu-id="22fdf-148">ライトの数</span><span class="sxs-lookup"><span data-stu-id="22fdf-148">Number of Lights</span></span>** | <span data-ttu-id="22fdf-149">UI をターゲットに任意の組み合わせで、2 つの非アンビエント コンポジション ライトを使用する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="22fdf-149">You may use any two non-ambient composition lights in any combination to target your UI.</span></span> <span data-ttu-id="22fdf-150">アンビエント照明ではありません。スポット、点、および離れた場所にあるライトがします。</span><span class="sxs-lookup"><span data-stu-id="22fdf-150">Ambient lights are not restricted; spot, point, and distant lights are.</span></span>
**<span data-ttu-id="22fdf-151">有効期間</span><span class="sxs-lookup"><span data-stu-id="22fdf-151">Lifetime</span></span>** | <span data-ttu-id="22fdf-152">CompositionLight 有効期間の条件が発生する可能性があります (例: が使用する前に、ガベージ コレクターがライトのオブジェクトをリサイクル可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="22fdf-152">CompositionLight may experience lifetime conditions (example: the garbage collector may recycle the light object before it is used).</span></span>  <span data-ttu-id="22fdf-153">アプリケーションの有効期間を管理できるようにするにはメンバーとしてライトを追加することで、ライトへの参照を保持することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="22fdf-153">We recommended keeping a reference to your lights by adding lights as a member to help the application manage lifetime.</span></span>
**<span data-ttu-id="22fdf-154">変換</span><span class="sxs-lookup"><span data-stu-id="22fdf-154">Transforms</span></span>** | <span data-ttu-id="22fdf-155">ライトは、視覚的構造内の[視点の変換](/design/layout/3-d-perspective-effects.md)などの効果を使用して適切に描画される UI 上のノードに配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22fdf-155">Lights must be placed in a node above UI that uses effects like [perspective transforms](/design/layout/3-d-perspective-effects.md) in your visual structure to be drawn properly.</span></span>
**<span data-ttu-id="22fdf-156">ターゲットと座標空間</span><span class="sxs-lookup"><span data-stu-id="22fdf-156">Targets and Coordinate Space</span></span>** | <span data-ttu-id="22fdf-157">CoordinateSpace は、ビジュアルの領域のすべてのライトのプロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="22fdf-157">CoordinateSpace is the visual space in which all the lights properties must be set.</span></span> <span data-ttu-id="22fdf-158">CompositionLight.Targets は CoordinateSpace ツリー内である必要があります。</span><span class="sxs-lookup"><span data-stu-id="22fdf-158">CompositionLight.Targets must be within the CoordinateSpace tree.</span></span>

## <a name="lighting-properties"></a><span data-ttu-id="22fdf-159">光源のプロパティ</span><span class="sxs-lookup"><span data-stu-id="22fdf-159">Lighting Properties</span></span>

<span data-ttu-id="22fdf-160">使う光源の種類、に応じて光の減衰と領域のプロパティことができます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-160">Depending on the type of light used, a light can have properties for attenuation and space.</span></span> <span data-ttu-id="22fdf-161">すべての種類の光源がすべてのプロパティを使うわけではありません。</span><span class="sxs-lookup"><span data-stu-id="22fdf-161">Not all types of lights use all properties.</span></span>

<span data-ttu-id="22fdf-162">プロパティ</span><span class="sxs-lookup"><span data-stu-id="22fdf-162">Property</span></span> | <span data-ttu-id="22fdf-163">説明</span><span class="sxs-lookup"><span data-stu-id="22fdf-163">Description</span></span>
--- | ---
**<span data-ttu-id="22fdf-164">色</span><span class="sxs-lookup"><span data-stu-id="22fdf-164">Color</span></span>** | <span data-ttu-id="22fdf-165">光の[色](/uwp/api/windows.ui.color)。</span><span class="sxs-lookup"><span data-stu-id="22fdf-165">The [Color](/uwp/api/windows.ui.color) of the light.</span></span> <span data-ttu-id="22fdf-166">値が[D3D](https://docs.microsoft.com/windows/uwp/graphics-concepts/light-properties)拡散、アンビエント、放射される色を定義するスペキュラによって定義される color 照明の適用します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-166">Lighting color values are defined by [D3D](https://docs.microsoft.com/windows/uwp/graphics-concepts/light-properties) Diffuse, Ambient, and Specular that defines the color being emitted.</span></span> <span data-ttu-id="22fdf-167">照明がライトの RGBA 値を使用します。アルファ色コンポーネントは使われません。</span><span class="sxs-lookup"><span data-stu-id="22fdf-167">Lighting uses RGBA values for lights; the alpha color component is not used.</span></span>
**<span data-ttu-id="22fdf-168">Direction</span><span class="sxs-lookup"><span data-stu-id="22fdf-168">Direction</span></span>** | <span data-ttu-id="22fdf-169">光の方向です。</span><span class="sxs-lookup"><span data-stu-id="22fdf-169">The direction of light.</span></span> <span data-ttu-id="22fdf-170">その[CoordinateSpace](/uwp/api/windows.ui.composition.distantlight.coordinatespace) Visual を基準とした、光が指している方向を指定します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-170">The direction in which the light is pointing is specified relative to its [CoordinateSpace](/uwp/api/windows.ui.composition.distantlight.coordinatespace) Visual.</span></span>
**<span data-ttu-id="22fdf-171">座標空間</span><span class="sxs-lookup"><span data-stu-id="22fdf-171">Coordinate Space</span></span>** | <span data-ttu-id="22fdf-172">すべてのビジュアルでは、暗黙的な 3D の座標空間があります。</span><span class="sxs-lookup"><span data-stu-id="22fdf-172">Every Visual has an implicit 3D coordinate space.</span></span> <span data-ttu-id="22fdf-173">X 方向が左から右にです。</span><span class="sxs-lookup"><span data-stu-id="22fdf-173">X direction is from left to right.</span></span> <span data-ttu-id="22fdf-174">Y 方向は、上から下です。</span><span class="sxs-lookup"><span data-stu-id="22fdf-174">Y direction is from top to bottom.</span></span> <span data-ttu-id="22fdf-175">Z 方向は、平面外ポイントです。</span><span class="sxs-lookup"><span data-stu-id="22fdf-175">Z direction is a point out of the plane.</span></span> <span data-ttu-id="22fdf-176">この座標の元のポイントは、ビジュアルの左上隅と、単位は、デバイス依存しないピクセル (DIP)。</span><span class="sxs-lookup"><span data-stu-id="22fdf-176">The original point of this coordinate is the upper-left corner of the visual, and the unit is Device Independent Pixel (DIP).</span></span> <span data-ttu-id="22fdf-177">ライトのオフセットがこの座標で定義されています。</span><span class="sxs-lookup"><span data-stu-id="22fdf-177">A light's offset defined in this coordinate.</span></span>
**<span data-ttu-id="22fdf-178">内部コーンおよび外部コーン</span><span class="sxs-lookup"><span data-stu-id="22fdf-178">Inner and Outer Cones</span></span>** | <span data-ttu-id="22fdf-179">スポットライトは、明るい内部コーンと外部コーンの 2 つの部分を持つ光のコーンを放射します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-179">Spotlights emit a cone of light that has two parts: a bright inner cone and an outer cone.</span></span> <span data-ttu-id="22fdf-180">コンポジションにより、内部および外部コーン角度と色を制御できます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-180">Composition allows you control over inner and outer cone angles and color.</span></span>
**<span data-ttu-id="22fdf-181">Offset</span><span class="sxs-lookup"><span data-stu-id="22fdf-181">Offset</span></span>** | <span data-ttu-id="22fdf-182">光源の座標空間 Visual を基準としたのオフセットです。</span><span class="sxs-lookup"><span data-stu-id="22fdf-182">Offset of the light source relative to its coordinate space Visual.</span></span>

> [!NOTE]
> <span data-ttu-id="22fdf-183">複数の照明ヒット、同じ Visual または光の色の値が 1.0 を超過する十分な大きさに取得されるたびに、光の色がライトのカラー チャネルのクランプため変更できます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-183">When multiple lights hit the same Visual, or whenever a light's color value gets large enough to exceed 1.0, the color of the light may change because of clamping of a lights color channel.</span></span>

### <a name="advanced-lighting-properties"></a><span data-ttu-id="22fdf-184">高度なライティング プロパティ</span><span class="sxs-lookup"><span data-stu-id="22fdf-184">Advanced Lighting Properties</span></span>

<span data-ttu-id="22fdf-185">プロパティ</span><span class="sxs-lookup"><span data-stu-id="22fdf-185">Property</span></span> | <span data-ttu-id="22fdf-186">説明</span><span class="sxs-lookup"><span data-stu-id="22fdf-186">Description</span></span>
--- | ---
**<span data-ttu-id="22fdf-187">強さ</span><span class="sxs-lookup"><span data-stu-id="22fdf-187">Intensity</span></span>** | <span data-ttu-id="22fdf-188">光の明るさを制御します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-188">Controls the brightness of the light.</span></span>
**<span data-ttu-id="22fdf-189">減衰</span><span class="sxs-lookup"><span data-stu-id="22fdf-189">Attenuation</span></span>** | <span data-ttu-id="22fdf-190">減衰は、範囲プロパティによって指定された最大距離にいたるまでに光の強さがどのように弱くなっていくかを制御します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-190">Attenuation controls how a light's intensity decreases toward the maximum distance specified by the range property.</span></span>  <span data-ttu-id="22fdf-191">定数、Quadradic と線形減衰プロパティことができます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-191">Constant, Quadradic and Linear attenuation properties can be used.</span></span>

## <a name="getting-started-with-lighting"></a><span data-ttu-id="22fdf-192">照明の概要</span><span class="sxs-lookup"><span data-stu-id="22fdf-192">Getting Started with Lighting</span></span>

<span data-ttu-id="22fdf-193">照明を追加する一般的な手順に従います。</span><span class="sxs-lookup"><span data-stu-id="22fdf-193">Follow these general steps to add lights:</span></span>

- <span data-ttu-id="22fdf-194">作成し、ライトを配置: ライトを作成し、指定された座標空間に配置します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-194">Create and place the lights: Create lights and place them in a specified coordinate space.</span></span>
- <span data-ttu-id="22fdf-195">ライトへのオブジェクトを識別する: 関連する視覚効果に光をターゲットにします。</span><span class="sxs-lookup"><span data-stu-id="22fdf-195">Identify objects to light: Target light at relevant visuals.</span></span>
- <span data-ttu-id="22fdf-196">[オプション]個々 のオブジェクトを定義ライトへの対応: 光が反射 SpriteVisual を表示するためのカスタマイズ、EffectBrush と SceneLightingEffect を使用します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-196">[Optional] Define how individual objects react to lights: Use SceneLightingEffect with an EffectBrush to customize light reflection for displaying the SpriteVisual.</span></span> <span data-ttu-id="22fdf-197">反射の既定値は、光源の CoordinateSpace の子の照明をサポートします。</span><span class="sxs-lookup"><span data-stu-id="22fdf-197">Reflection defaults support the lighting of children of a light source’s CoordinateSpace.</span></span>  <span data-ttu-id="22fdf-198">SceneLightingEffect で塗りつぶす visual は、そのビジュアルの既定の照明を上書きします。</span><span class="sxs-lookup"><span data-stu-id="22fdf-198">A visual painted with a SceneLightingEffect overwrites the default lighting for that visual.</span></span>

## <a name="scenelightingeffect"></a><span data-ttu-id="22fdf-199">SceneLightingEffect</span><span class="sxs-lookup"><span data-stu-id="22fdf-199">SceneLightingEffect</span></span>

<span data-ttu-id="22fdf-200">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)を使用して、 [CompositionLight](/uwp/api/windows.ui.composition.compositionlight)の対象となる[SpriteVisual](/uwp/api/Windows.UI.Composition.SpriteVisual)の内容に適用される既定の照明を変更できます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-200">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) is used to modify the default lighting applied to the contents of a [SpriteVisual](/uwp/api/Windows.UI.Composition.SpriteVisual) targeted by a [CompositionLight](/uwp/api/windows.ui.composition.compositionlight).</span></span>

<span data-ttu-id="22fdf-201">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)は素材の作成によく使用されます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-201">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) is frequently used for material creation.</span></span> <span data-ttu-id="22fdf-202">SceneLightingEffect は、イメージの反射プロパティを有効にするや、法線マップを使用して、奥行き感を提供するようより複雑なものを実現するために必要なときに使用する効果です。</span><span class="sxs-lookup"><span data-stu-id="22fdf-202">A SceneLightingEffect is an effect used when you want to achieve something more complex, like enabling reflective properties on an image and/or providing an illusion of depth with a normal map.</span></span> <span data-ttu-id="22fdf-203">SceneLightingEffect 反射および拡散金額などの照明のプロパティを使用して、UI をカスタマイズする機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-203">A SceneLightingEffect provides the ability to customize your UI by using the lighting properties like specular and diffuse amounts.</span></span> <span data-ttu-id="22fdf-204">個別にブレンドし、コンテンツを含むさまざまな照明反応できる効果パイプラインの残りの部分で照明効果をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-204">You can further customize lighting effects with the rest of the effects pipeline allowing you individually to blend and compose different lighting reactions with your content.</span></span>

> [!NOTE]
> <span data-ttu-id="22fdf-205">シーンの照明がシャドウを生成しません。2D レンダリングに重点を置いて効果です。</span><span class="sxs-lookup"><span data-stu-id="22fdf-205">Scene lighting does not produce shadows; it is an effect focused on 2D rendering.</span></span>  <span data-ttu-id="22fdf-206">実際の照明モデルでは、シャドウをなどが含まれている考慮 3D 照明シナリオには実行されません。</span><span class="sxs-lookup"><span data-stu-id="22fdf-206">It does not take into consideration 3D lighting scenarios that include real lighting models, including shadows.</span></span>


<span data-ttu-id="22fdf-207">プロパティ</span><span class="sxs-lookup"><span data-stu-id="22fdf-207">Property</span></span> | <span data-ttu-id="22fdf-208">説明</span><span class="sxs-lookup"><span data-stu-id="22fdf-208">Description</span></span>
--- | ---
**<span data-ttu-id="22fdf-209">通常のマップ</span><span class="sxs-lookup"><span data-stu-id="22fdf-209">Normal Map</span></span>** | <span data-ttu-id="22fdf-210">NormalMaps は、位置、光の方向に通常のポイントは明るくなりますができ、法線を指している離れた調光のテクスチャの効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-210">NormalMaps create an effect of a texture where a normal pointing towards the light will be brighter and a normal pointing away will be dimmer.</span></span> <span data-ttu-id="22fdf-211">対象となる visual NormalMap を追加するには、NormalMap アセットを読み込む LoadedImageSurface を使用して[CompositionSurfaceBrush](/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)を使用します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-211">To add a NormalMap to your targeted visual use a [CompositionSurfaceBrush](/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) using LoadedImageSurface to load a NormalMap asset.</span></span>
**<span data-ttu-id="22fdf-212">環境光</span><span class="sxs-lookup"><span data-stu-id="22fdf-212">Ambient</span></span>** | <span data-ttu-id="22fdf-213">アンビエント プロパティはほとんどの場合、全体的な色のリフレクションを制御するために使用します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-213">Ambient properties are mostly used to control the overall color reflection.</span></span>
**<span data-ttu-id="22fdf-214">反射</span><span class="sxs-lookup"><span data-stu-id="22fdf-214">Specular</span></span>** | <span data-ttu-id="22fdf-215">反射光では、オブジェクト、光沢のある表示したりすることで強調表示を作成します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-215">Specular reflection creates highlights on objects, making them appear shiny.</span></span> <span data-ttu-id="22fdf-216">反射光のレベルだけでなく輝きのレベルを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-216">You can control the level of specular reflection as well as the level of shine.</span></span>  <span data-ttu-id="22fdf-217">これらのプロパティは、光沢金属または光沢のあるホワイト ペーパーなどのマテリアルの効果を作成する操作されます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-217">These properties are manipulated to create material effects like shinny metals or glossy paper.</span></span>
**<span data-ttu-id="22fdf-218">拡散</span><span class="sxs-lookup"><span data-stu-id="22fdf-218">Diffuse</span></span>** | <span data-ttu-id="22fdf-219">拡散されたリフレクションでは、すべての方向に光を拡散します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-219">Diffused reflection scatters the light in all directions.</span></span>
**<span data-ttu-id="22fdf-220">反射率モデル</span><span class="sxs-lookup"><span data-stu-id="22fdf-220">Reflectance Model</span></span>** | <span data-ttu-id="22fdf-221">[反射率モデル](/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel)では、 [Blinn フォン](https://docs.microsoft.com/visualstudio/designers/how-to-create-a-basic-phong-shader)Blinn フォンを物理的に基づくどれかを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="22fdf-221">[Reflectance Model](/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel) allows you to choose between [Blinn Phong](https://docs.microsoft.com/visualstudio/designers/how-to-create-a-basic-phong-shader) and Physically Based Blinn Phong.</span></span>  <span data-ttu-id="22fdf-222">反射光が縮小する場合は、Blinn フォンを物理的に基づくを選択します。</span><span class="sxs-lookup"><span data-stu-id="22fdf-222">You would choose Physically Based Blinn Phong when you want to have condensed specular highlights.</span></span>

### <a name="sample-scenelightingeffect"></a><span data-ttu-id="22fdf-223">(SceneLightingEffect) のサンプル</span><span class="sxs-lookup"><span data-stu-id="22fdf-223">Sample (SceneLightingEffect)</span></span>

<span data-ttu-id="22fdf-224">次のサンプルは、SceneLightingEffect に通常マップを追加する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="22fdf-224">The sample below shows how to add a normal map to a SceneLightingEffect.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="22fdf-225">関連記事</span><span class="sxs-lookup"><span data-stu-id="22fdf-225">Related articles</span></span>

- [<span data-ttu-id="22fdf-226">ビジュアル レイヤーでの素材とライトの作成</span><span class="sxs-lookup"><span data-stu-id="22fdf-226">Creating Materials and Lights in the Visual Layer</span></span>](https://blogs.windows.com/buildingapps/2017/08/04/creating-materials-lights-visual-layer/)
- [<span data-ttu-id="22fdf-227">光源の概要</span><span class="sxs-lookup"><span data-stu-id="22fdf-227">Lighting Overview</span></span>](https://docs.microsoft.com/windows/uwp/graphics-concepts/lighting-overview)
- [<span data-ttu-id="22fdf-228">CompositionCapabilities API</span><span class="sxs-lookup"><span data-stu-id="22fdf-228">CompositionCapabilities API</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositioncapabilities)
- [<span data-ttu-id="22fdf-229">光源の計算</span><span class="sxs-lookup"><span data-stu-id="22fdf-229">Mathematics of Lighting</span></span>](https://docs.microsoft.com/windows/uwp/graphics-concepts/mathematics-of-lighting)
- [<span data-ttu-id="22fdf-230">SceneLightingEffect</span><span class="sxs-lookup"><span data-stu-id="22fdf-230">SceneLightingEffect</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffect)
- [<span data-ttu-id="22fdf-231">WindowsUIDevLabs GitHub リポジトリにあります。</span><span class="sxs-lookup"><span data-stu-id="22fdf-231">WindowsUIDevLabs GitHub Repo</span></span>](https://github.com/Microsoft/WindowsUIDevLabs)
