---
title: コンポジション照明
description: 動的な 3D ライティングをアプリケーションに追加する合成照明の Api を使用できます。
ms.date: 07/16/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 733ce75942a05482ade88c1510e788f1cbd515d4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602207"
---
# <a name="using-lights-in-windows-ui"></a><span data-ttu-id="ca779-104">Windows の UI でのライトの使用</span><span class="sxs-lookup"><span data-stu-id="ca779-104">Using lights in Windows UI</span></span>

<span data-ttu-id="ca779-105">Windows.UI.Composition Api を使用すると、リアルタイムのアニメーションや効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="ca779-105">The Windows.UI.Composition APIs enable you to create real-time animations and effects.</span></span> <span data-ttu-id="ca779-106">コンポジション照明は、2 D のアプリケーションで 3D ライティングを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ca779-106">Composition Lighting enables 3D lighting in 2D applications.</span></span> <span data-ttu-id="ca779-107">この概要では、コンポジションのライトのセットアップ、各ライトを受信するビジュアルを識別し、効果を使用して、コンテンツの素材を定義する方法の機能を使用して実行します。</span><span class="sxs-lookup"><span data-stu-id="ca779-107">In this overview, we will run through the functionality of how to setup composition lights, identify visuals to receive each light, and use effects to define materials for your content.</span></span>

> [!NOTE]
> <span data-ttu-id="ca779-108">読み取り方法を[XamlLight](/uwp/api/windows.ui.xaml.media.xamllight)オブジェクトを適用[CompositionLights](/uwp/api/Windows.UI.Composition.CompositionLight) XAML Uielement を明らかに、次を参照してください。 [XAML 照明](xaml-lighting.md)します。</span><span class="sxs-lookup"><span data-stu-id="ca779-108">To read how [XamlLight](/uwp/api/windows.ui.xaml.media.xamllight) objects apply [CompositionLights](/uwp/api/Windows.UI.Composition.CompositionLight) to illuminate XAML UIElements, see [XAML lighting](xaml-lighting.md).</span></span>

<span data-ttu-id="ca779-109">コンポジション照明を使用して、UI を許可することで興味深いを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ca779-109">Composition lighting lets you create interesting UI by allowing:</span></span>

- <span data-ttu-id="ca779-110">音楽の再生のシーンなどの没入型のシナリオを有効にするシーン内の他のオブジェクトのライトに依存しない変換します。</span><span class="sxs-lookup"><span data-stu-id="ca779-110">Transformation of a light independent of other objects in the scene to enable immersive scenarios like music playback scenes.</span></span>
- <span data-ttu-id="ca779-111">一緒に移動できるように、ライトを持つオブジェクトをペアリングする機能 Fluent のようなシナリオを有効にするシーンの残りの部分の独立した[表示](/windows/uwp/design/style/reveal)を強調表示します。</span><span class="sxs-lookup"><span data-stu-id="ca779-111">The ability to pair an object with a light so they move together independent of the rest of the scene to enable scenarios like Fluent [Reveal](/windows/uwp/design/style/reveal) highlight.</span></span>
- <span data-ttu-id="ca779-112">素材と深さを作成するグループとして光とシーン全体の変換です。</span><span class="sxs-lookup"><span data-stu-id="ca779-112">Transformation of the light and entire scene as a group to create materials and depth.</span></span>

<span data-ttu-id="ca779-113">コンポジション照明は、次の 3 つの主要な概念をサポートしています。**Light**、**ターゲット**、および**SceneLightingEffect**します。</span><span class="sxs-lookup"><span data-stu-id="ca779-113">Composition lighting supports three key concepts: **Light**, **Targets**, and **SceneLightingEffect**.</span></span>

## <a name="light"></a><span data-ttu-id="ca779-114">明るい</span><span class="sxs-lookup"><span data-stu-id="ca779-114">Light</span></span>

<span data-ttu-id="ca779-115">[CompositionLight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight)さまざまなライトを作成して、座標空間内に配置することができます。</span><span class="sxs-lookup"><span data-stu-id="ca779-115">[CompositionLight](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionlight) allows you to create various lights and place them in coordinate space.</span></span> <span data-ttu-id="ca779-116">これらのライトはターゲットがライトによって照らさとして識別するビジュアルです。</span><span class="sxs-lookup"><span data-stu-id="ca779-116">These lights target visuals that you wish to identify as lit by the light.</span></span>

### <a name="light-types"></a><span data-ttu-id="ca779-117">ライトの種類</span><span class="sxs-lookup"><span data-stu-id="ca779-117">Light Types</span></span>

| <span data-ttu-id="ca779-118">種類</span><span class="sxs-lookup"><span data-stu-id="ca779-118">Type</span></span> | <span data-ttu-id="ca779-119">説明</span><span class="sxs-lookup"><span data-stu-id="ca779-119">Description</span></span> |
| --- | --- |
| [<span data-ttu-id="ca779-120">Ambientlight を組み合わせます</span><span class="sxs-lookup"><span data-stu-id="ca779-120">AmbientLight</span></span>](/uwp/api/windows.ui.composition.ambientlight) | <span data-ttu-id="ca779-121">シーン内のすべてが表示される方向性のない光を放射光源が反映されます。</span><span class="sxs-lookup"><span data-stu-id="ca779-121">A light source that emits non-directional light that appears reflected by everything in the scene.</span></span> |
| [<span data-ttu-id="ca779-122">DistantLight</span><span class="sxs-lookup"><span data-stu-id="ca779-122">DistantLight</span></span>](/uwp/api/windows.ui.composition.distantlight) | <span data-ttu-id="ca779-123">無限に大規模な光源を 1 つの方向に光を出力します。</span><span class="sxs-lookup"><span data-stu-id="ca779-123">An infinitely large distant light source that emits light in a single direction.</span></span> <span data-ttu-id="ca779-124">太陽の。</span><span class="sxs-lookup"><span data-stu-id="ca779-124">Like the sun.</span></span> |
| [<span data-ttu-id="ca779-125">PointLight</span><span class="sxs-lookup"><span data-stu-id="ca779-125">PointLight</span></span>](/uwp/api/windows.ui.composition.pointlight) | <span data-ttu-id="ca779-126">すべての方向に光が放射される光のポイントのソース。</span><span class="sxs-lookup"><span data-stu-id="ca779-126">A point source of light that emits light in all directions.</span></span> <span data-ttu-id="ca779-127">電球など。</span><span class="sxs-lookup"><span data-stu-id="ca779-127">Like a lightbulb.</span></span> |
| [<span data-ttu-id="ca779-128">スポット ライト</span><span class="sxs-lookup"><span data-stu-id="ca779-128">SpotLight</span></span>](/uwp/api/windows.ui.composition.spotlight) | <span data-ttu-id="ca779-129">光の内側と外側の円錐を出力する光源を使用します。</span><span class="sxs-lookup"><span data-stu-id="ca779-129">A light source that emits inner and outer cones of light.</span></span> <span data-ttu-id="ca779-130">懐中電灯など。</span><span class="sxs-lookup"><span data-stu-id="ca779-130">Like a flashlight.</span></span> |

## <a name="targets"></a><span data-ttu-id="ca779-131">ターゲット</span><span class="sxs-lookup"><span data-stu-id="ca779-131">Targets</span></span>

<span data-ttu-id="ca779-132">ライトがビジュアルを対象する場合 (に追加[ターゲット](/uwp/api/windows.ui.composition.compositionlight.targets)一覧)、ビジュアルとそのすべての子孫が認識して、この光源に応答します。</span><span class="sxs-lookup"><span data-stu-id="ca779-132">When lights target a Visual (add to [Targets](/uwp/api/windows.ui.composition.compositionlight.targets) list), the Visual and all its descendants are aware of and respond to this light source.</span></span> <span data-ttu-id="ca779-133">これは、ポイント ライトの方向をアニメーションに対応する以下のすべてのビジュアル ツリーのルートにある PointLight ソース設定と同じくらい単純ことができます。</span><span class="sxs-lookup"><span data-stu-id="ca779-133">This can be something as simple as a setting a PointLight source at the root of a tree and all visuals below react to the animation of the point lights direction.</span></span>

<span data-ttu-id="ca779-134">**ExclusionsFromTargets**ターゲットを追加すると同様の方法でビジュアルの場合、またはビジュアルのサブツリーの照明を削除する機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="ca779-134">**ExclusionsFromTargets** gives you the ability to remove the lighting of a visual or of a subtree of visuals in a similar manner as adding targets.</span></span> <span data-ttu-id="ca779-135">除外されているビジュアルで root 化されているツリー内の子が結果として、点灯していません。</span><span class="sxs-lookup"><span data-stu-id="ca779-135">Children in the tree rooted by the visual that's excluded are not lit as a result.</span></span>

### <a name="sample-targets"></a><span data-ttu-id="ca779-136">サンプル (ターゲット)</span><span class="sxs-lookup"><span data-stu-id="ca779-136">Sample (Targets)</span></span>

<span data-ttu-id="ca779-137">次の例では、XAML の TextBlock を対象に、CompositionPointLight を使用します。</span><span class="sxs-lookup"><span data-stu-id="ca779-137">In the sample below, we use a CompositionPointLight to target a XAML TextBlock.</span></span>

```cs
    _pointLight = _compositor.CreatePointLight();
    _pointLight.Color = Colors.White;
    _pointLight.CoordinateSpace = text; //set up co-ordinate space for offset
    _pointLight.Targets.Add(text); //target XAML TextBlock
```

<span data-ttu-id="ca779-138">ポイント ライトのオフセットにアニメーションを追加することで、光る効果を簡単に行います。</span><span class="sxs-lookup"><span data-stu-id="ca779-138">By adding animation to the offset of the point light, a shimmering effect is easily achieved.</span></span>

```cs
_pointLight.Offset = new Vector3(-(float)TextBlock.ActualWidth, (float)TextBlock.ActualHeight / 2, (float)TextBlock.FontSize);
```

<span data-ttu-id="ca779-139">参照してください[テキスト シマー](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/TextShimmer)詳しく WindowUIDevLabs サンプル ギャラリーにあるサンプル。</span><span class="sxs-lookup"><span data-stu-id="ca779-139">See the complete [Text Shimmer](https://github.com/Microsoft/WindowsUIDevLabs/tree/master/SampleGallery/Samples/SDK%2014393/TextShimmer) sample at the WindowUIDevLabs Sample Galley to learn more.</span></span>

## <a name="restrictions"></a><span data-ttu-id="ca779-140">制限</span><span class="sxs-lookup"><span data-stu-id="ca779-140">Restrictions</span></span>

<span data-ttu-id="ca779-141">CompositionLight で点灯するコンテンツを決定する際に考慮するいくつかの要素があります。</span><span class="sxs-lookup"><span data-stu-id="ca779-141">There are several factors to consider when determining which content will be lit by CompositionLight.</span></span>

<span data-ttu-id="ca779-142">概念</span><span class="sxs-lookup"><span data-stu-id="ca779-142">Concept</span></span> | <span data-ttu-id="ca779-143">詳細</span><span class="sxs-lookup"><span data-stu-id="ca779-143">Details</span></span>
--- | ---
<span data-ttu-id="ca779-144">**アンビエント ライト**</span><span class="sxs-lookup"><span data-stu-id="ca779-144">**Ambient Light**</span></span> | <span data-ttu-id="ca779-145">シーンに非アンビエント ライトを追加すると、既存のライトがすべてオフになります。</span><span class="sxs-lookup"><span data-stu-id="ca779-145">Adding a non-ambient light to your scene will turn off all existing light.</span></span>  <span data-ttu-id="ca779-146">対象非アンビエント ライトでもないアイテムは、黒で表示されます。</span><span class="sxs-lookup"><span data-stu-id="ca779-146">Items not targeted by a non-ambient light will appear black.</span></span>  <span data-ttu-id="ca779-147">自然な方法でライトによって発信周囲のビジュアルを点灯するには、他のライトと組み合わせて、アンビエント ライトを使用します。</span><span class="sxs-lookup"><span data-stu-id="ca779-147">To illuminate surrounding visuals not targeted by the light in a natural way, use an ambient light in conjunction with other lights.</span></span>
<span data-ttu-id="ca779-148">**ライトの数**</span><span class="sxs-lookup"><span data-stu-id="ca779-148">**Number of Lights**</span></span> | <span data-ttu-id="ca779-149">UI を対象とするのに任意の組み合わせで、2 つの非アンビエント コンポジション ライトを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ca779-149">You may use any two non-ambient composition lights in any combination to target your UI.</span></span> <span data-ttu-id="ca779-150">アンビエント ライトではありません。スポット、ポイント、および離れたライトです。</span><span class="sxs-lookup"><span data-stu-id="ca779-150">Ambient lights are not restricted; spot, point, and distant lights are.</span></span>
<span data-ttu-id="ca779-151">**有効期間**</span><span class="sxs-lookup"><span data-stu-id="ca779-151">**Lifetime**</span></span> | <span data-ttu-id="ca779-152">CompositionLight 有効期間の条件が発生する可能性があります (例: される前に、ガベージ コレクターは軽量のオブジェクトをリサイクル可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="ca779-152">CompositionLight may experience lifetime conditions (example: the garbage collector may recycle the light object before it is used).</span></span>  <span data-ttu-id="ca779-153">アプリケーションの有効期間の管理に役立つメンバーとして、ライトを追加することで、ライトへの参照を維持することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ca779-153">We recommended keeping a reference to your lights by adding lights as a member to help the application manage lifetime.</span></span>
<span data-ttu-id="ca779-154">**変換**</span><span class="sxs-lookup"><span data-stu-id="ca779-154">**Transforms**</span></span> | <span data-ttu-id="ca779-155">ライトをなどの効果を使用する UI 上のノードに配置する必要があります[パースペクティブ変換](/windows/uwp/design/layout/3-d-perspective-effects)で、視覚的な構造が適切に描画されます。</span><span class="sxs-lookup"><span data-stu-id="ca779-155">Lights must be placed in a node above UI that uses effects like [perspective transforms](/windows/uwp/design/layout/3-d-perspective-effects) in your visual structure to be drawn properly.</span></span>
<span data-ttu-id="ca779-156">**ターゲットと座標空間**</span><span class="sxs-lookup"><span data-stu-id="ca779-156">**Targets and Coordinate Space**</span></span> | <span data-ttu-id="ca779-157">CoordinateSpace は、visual の領域のすべてのライトのプロパティを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ca779-157">CoordinateSpace is the visual space in which all the lights properties must be set.</span></span> <span data-ttu-id="ca779-158">CompositionLight.Targets は CoordinateSpace ツリー内である必要があります。</span><span class="sxs-lookup"><span data-stu-id="ca779-158">CompositionLight.Targets must be within the CoordinateSpace tree.</span></span>

## <a name="lighting-properties"></a><span data-ttu-id="ca779-159">照明プロパティ</span><span class="sxs-lookup"><span data-stu-id="ca779-159">Lighting Properties</span></span>

<span data-ttu-id="ca779-160">、使用するライトの種類に応じて、光の減衰と領域のプロパティことができます。</span><span class="sxs-lookup"><span data-stu-id="ca779-160">Depending on the type of light used, a light can have properties for attenuation and space.</span></span> <span data-ttu-id="ca779-161">すべての種類の光源がすべてのプロパティを使うわけではありません。</span><span class="sxs-lookup"><span data-stu-id="ca779-161">Not all types of lights use all properties.</span></span>

<span data-ttu-id="ca779-162">プロパティ</span><span class="sxs-lookup"><span data-stu-id="ca779-162">Property</span></span> | <span data-ttu-id="ca779-163">説明</span><span class="sxs-lookup"><span data-stu-id="ca779-163">Description</span></span>
--- | ---
<span data-ttu-id="ca779-164">**色**</span><span class="sxs-lookup"><span data-stu-id="ca779-164">**Color**</span></span> | <span data-ttu-id="ca779-165">[色](/uwp/api/windows.ui.color)光の。</span><span class="sxs-lookup"><span data-stu-id="ca779-165">The [Color](/uwp/api/windows.ui.color) of the light.</span></span> <span data-ttu-id="ca779-166">光の色の値がによって定義されている[D3D](https://docs.microsoft.com/windows/uwp/graphics-concepts/light-properties)拡散、アンビエント、および反射出力される色を定義します。</span><span class="sxs-lookup"><span data-stu-id="ca779-166">Lighting color values are defined by [D3D](https://docs.microsoft.com/windows/uwp/graphics-concepts/light-properties) Diffuse, Ambient, and Specular that defines the color being emitted.</span></span> <span data-ttu-id="ca779-167">照明ライト; RGBA 値が使用されます。色のアルファ コンポーネントは使用されません。</span><span class="sxs-lookup"><span data-stu-id="ca779-167">Lighting uses RGBA values for lights; the alpha color component is not used.</span></span>
<span data-ttu-id="ca779-168">**方向**</span><span class="sxs-lookup"><span data-stu-id="ca779-168">**Direction**</span></span> | <span data-ttu-id="ca779-169">光の方向です。</span><span class="sxs-lookup"><span data-stu-id="ca779-169">The direction of light.</span></span> <span data-ttu-id="ca779-170">に対して相対的な光が指している方向が指定されたその[CoordinateSpace](/uwp/api/windows.ui.composition.distantlight.coordinatespace)ビジュアル。</span><span class="sxs-lookup"><span data-stu-id="ca779-170">The direction in which the light is pointing is specified relative to its [CoordinateSpace](/uwp/api/windows.ui.composition.distantlight.coordinatespace) Visual.</span></span>
<span data-ttu-id="ca779-171">**座標空間**</span><span class="sxs-lookup"><span data-stu-id="ca779-171">**Coordinate Space**</span></span> | <span data-ttu-id="ca779-172">すべてのビジュアルでは、暗黙の 3D 座標空間は。</span><span class="sxs-lookup"><span data-stu-id="ca779-172">Every Visual has an implicit 3D coordinate space.</span></span> <span data-ttu-id="ca779-173">X 方向は、左から右です。</span><span class="sxs-lookup"><span data-stu-id="ca779-173">X direction is from left to right.</span></span> <span data-ttu-id="ca779-174">Y 方向は、上から下です。</span><span class="sxs-lookup"><span data-stu-id="ca779-174">Y direction is from top to bottom.</span></span> <span data-ttu-id="ca779-175">Z 方向は、平面からポイントです。</span><span class="sxs-lookup"><span data-stu-id="ca779-175">Z direction is a point out of the plane.</span></span> <span data-ttu-id="ca779-176">この座標の元のポイントは、ビジュアルの左上隅にあると、単位はデバイス独立ピクセル (DIP)。</span><span class="sxs-lookup"><span data-stu-id="ca779-176">The original point of this coordinate is the upper-left corner of the visual, and the unit is Device Independent Pixel (DIP).</span></span> <span data-ttu-id="ca779-177">この座標で定義されている光のオフセット。</span><span class="sxs-lookup"><span data-stu-id="ca779-177">A light's offset defined in this coordinate.</span></span>
<span data-ttu-id="ca779-178">**内側と外側の円錐**</span><span class="sxs-lookup"><span data-stu-id="ca779-178">**Inner and Outer Cones**</span></span> | <span data-ttu-id="ca779-179">スポットライトは、明るい内部コーンと外部コーンの 2 つの部分を持つ光のコーンを放射します。</span><span class="sxs-lookup"><span data-stu-id="ca779-179">Spotlights emit a cone of light that has two parts: a bright inner cone and an outer cone.</span></span> <span data-ttu-id="ca779-180">コンポジションは、内側と外側の円錐の角度と色を制御できます。</span><span class="sxs-lookup"><span data-stu-id="ca779-180">Composition allows you control over inner and outer cone angles and color.</span></span>
<span data-ttu-id="ca779-181">**オフセット**</span><span class="sxs-lookup"><span data-stu-id="ca779-181">**Offset**</span></span> | <span data-ttu-id="ca779-182">座標空間 Visual 基準とした光の光源のオフセット。</span><span class="sxs-lookup"><span data-stu-id="ca779-182">Offset of the light source relative to its coordinate space Visual.</span></span>

> [!NOTE]
> <span data-ttu-id="ca779-183">複数のライトが同じのビジュアルをヒットしたときに、または 1.0 を超える大きさ光の色の値を取得するたびに、光の色をクランプ ライトの色チャネルのため変更可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ca779-183">When multiple lights hit the same Visual, or whenever a light's color value gets large enough to exceed 1.0, the color of the light may change because of clamping of a lights color channel.</span></span>

### <a name="advanced-lighting-properties"></a><span data-ttu-id="ca779-184">高度なライティング プロパティ</span><span class="sxs-lookup"><span data-stu-id="ca779-184">Advanced Lighting Properties</span></span>

<span data-ttu-id="ca779-185">プロパティ</span><span class="sxs-lookup"><span data-stu-id="ca779-185">Property</span></span> | <span data-ttu-id="ca779-186">説明</span><span class="sxs-lookup"><span data-stu-id="ca779-186">Description</span></span>
--- | ---
<span data-ttu-id="ca779-187">**輝度**</span><span class="sxs-lookup"><span data-stu-id="ca779-187">**Intensity**</span></span> | <span data-ttu-id="ca779-188">光源の輝度を制御します。</span><span class="sxs-lookup"><span data-stu-id="ca779-188">Controls the brightness of the light.</span></span>
<span data-ttu-id="ca779-189">**減衰**</span><span class="sxs-lookup"><span data-stu-id="ca779-189">**Attenuation**</span></span> | <span data-ttu-id="ca779-190">減衰は、範囲プロパティによって指定された最大距離にいたるまでに光の強さがどのように弱くなっていくかを制御します。</span><span class="sxs-lookup"><span data-stu-id="ca779-190">Attenuation controls how a light's intensity decreases toward the maximum distance specified by the range property.</span></span>  <span data-ttu-id="ca779-191">定数、Quadradic と線形 attenuation プロパティができます。</span><span class="sxs-lookup"><span data-stu-id="ca779-191">Constant, Quadradic and Linear attenuation properties can be used.</span></span>

## <a name="getting-started-with-lighting"></a><span data-ttu-id="ca779-192">照明の概要</span><span class="sxs-lookup"><span data-stu-id="ca779-192">Getting Started with Lighting</span></span>

<span data-ttu-id="ca779-193">ライトを追加する一般的な手順に従います。</span><span class="sxs-lookup"><span data-stu-id="ca779-193">Follow these general steps to add lights:</span></span>

- <span data-ttu-id="ca779-194">作成し、ライトを配置します。ライトを作成し、指定された座標空間内に配置します。</span><span class="sxs-lookup"><span data-stu-id="ca779-194">Create and place the lights: Create lights and place them in a specified coordinate space.</span></span>
- <span data-ttu-id="ca779-195">ライトをオブジェクトを識別します。関連するビジュアルのライトを対象します。</span><span class="sxs-lookup"><span data-stu-id="ca779-195">Identify objects to light: Target light at relevant visuals.</span></span>
- <span data-ttu-id="ca779-196">[省略可能]どのように個々 のオブジェクトを定義ライトに対応します。EffectBrush SceneLightingEffect を使用すると、SpriteVisual を表示するためのライトの反射をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="ca779-196">[Optional] Define how individual objects react to lights: Use SceneLightingEffect with an EffectBrush to customize light reflection for displaying the SpriteVisual.</span></span> <span data-ttu-id="ca779-197">リフレクションの既定値は、光源の CoordinateSpace の子の照明をサポートします。</span><span class="sxs-lookup"><span data-stu-id="ca779-197">Reflection defaults support the lighting of children of a light source’s CoordinateSpace.</span></span>  <span data-ttu-id="ca779-198">SceneLightingEffect と描画ビジュアルには、そのビジュアルの既定の照明が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="ca779-198">A visual painted with a SceneLightingEffect overwrites the default lighting for that visual.</span></span>

## <a name="scenelightingeffect"></a><span data-ttu-id="ca779-199">SceneLightingEffect</span><span class="sxs-lookup"><span data-stu-id="ca779-199">SceneLightingEffect</span></span>

<span data-ttu-id="ca779-200">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)の内容に適用される既定の光源を変更するために使用する[SpriteVisual](/uwp/api/Windows.UI.Composition.SpriteVisual)の対象となる、 [CompositionLight](/uwp/api/windows.ui.composition.compositionlight)します。</span><span class="sxs-lookup"><span data-stu-id="ca779-200">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) is used to modify the default lighting applied to the contents of a [SpriteVisual](/uwp/api/Windows.UI.Composition.SpriteVisual) targeted by a [CompositionLight](/uwp/api/windows.ui.composition.compositionlight).</span></span>

<span data-ttu-id="ca779-201">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect)の素材の作成に頻繁に使用します。</span><span class="sxs-lookup"><span data-stu-id="ca779-201">[SceneLightingEffect](/uwp/api/Windows.UI.Composition.Effects.SceneLightingEffect) is frequently used for material creation.</span></span> <span data-ttu-id="ca779-202">SceneLightingEffect は、イメージの反射プロパティの有効化や法線マップで、奥行を提供するようより複雑なものを実現するときに使われる効果です。</span><span class="sxs-lookup"><span data-stu-id="ca779-202">A SceneLightingEffect is an effect used when you want to achieve something more complex, like enabling reflective properties on an image and/or providing an illusion of depth with a normal map.</span></span> <span data-ttu-id="ca779-203">SceneLightingEffect スペキュラ、拡散の金額のように照明プロパティを使用して、UI をカスタマイズする機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="ca779-203">A SceneLightingEffect provides the ability to customize your UI by using the lighting properties like specular and diffuse amounts.</span></span> <span data-ttu-id="ca779-204">さらに、blend し、compose のコンテンツとのさまざまな照明反応に個別に使用できる効果のパイプラインの残りの部分と光源の効果をカスタマイズすることができます。</span><span class="sxs-lookup"><span data-stu-id="ca779-204">You can further customize lighting effects with the rest of the effects pipeline allowing you individually to blend and compose different lighting reactions with your content.</span></span>

> [!NOTE]
> <span data-ttu-id="ca779-205">シーンの照明が shadows; を作成できません。2D レンダリングに重点を置いて効果になります。</span><span class="sxs-lookup"><span data-stu-id="ca779-205">Scene lighting does not produce shadows; it is an effect focused on 2D rendering.</span></span>  <span data-ttu-id="ca779-206">影をなど、実際の照明モデルを含む考慮対象として 3D ライティング シナリオにはなりません。</span><span class="sxs-lookup"><span data-stu-id="ca779-206">It does not take into consideration 3D lighting scenarios that include real lighting models, including shadows.</span></span>


<span data-ttu-id="ca779-207">プロパティ</span><span class="sxs-lookup"><span data-stu-id="ca779-207">Property</span></span> | <span data-ttu-id="ca779-208">説明</span><span class="sxs-lookup"><span data-stu-id="ca779-208">Description</span></span>
--- | ---
<span data-ttu-id="ca779-209">**法線マップ**</span><span class="sxs-lookup"><span data-stu-id="ca779-209">**Normal Map**</span></span> | <span data-ttu-id="ca779-210">NormalMaps では、テクスチャ、明るい光の方向に通常のポイントになりますであり通常を指しているすぐ調光の効果を作成します。</span><span class="sxs-lookup"><span data-stu-id="ca779-210">NormalMaps create an effect of a texture where a normal pointing towards the light will be brighter and a normal pointing away will be dimmer.</span></span> <span data-ttu-id="ca779-211">対象となる visual 使用時に、NormalMap を追加する、 [compositionsurfacebrush クラス](/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush)NormalMap 資産を読み込む LoadedImageSurface を使用します。</span><span class="sxs-lookup"><span data-stu-id="ca779-211">To add a NormalMap to your targeted visual use a [CompositionSurfaceBrush](/uwp/api/Windows.UI.Composition.CompositionSurfaceBrush) using LoadedImageSurface to load a NormalMap asset.</span></span>
<span data-ttu-id="ca779-212">**アンビエント**</span><span class="sxs-lookup"><span data-stu-id="ca779-212">**Ambient**</span></span> | <span data-ttu-id="ca779-213">アンビエント プロパティはほとんどの場合、全体的な色の反射を制御するために使用します。</span><span class="sxs-lookup"><span data-stu-id="ca779-213">Ambient properties are mostly used to control the overall color reflection.</span></span>
<span data-ttu-id="ca779-214">**反射**</span><span class="sxs-lookup"><span data-stu-id="ca779-214">**Specular**</span></span> | <span data-ttu-id="ca779-215">スペキュラ反射は、オブジェクト、光沢のある表示したりすることで、強調表示を作成します。</span><span class="sxs-lookup"><span data-stu-id="ca779-215">Specular reflection creates highlights on objects, making them appear shiny.</span></span> <span data-ttu-id="ca779-216">スペキュラ反射のレベルと光沢のレベルを制御できます。</span><span class="sxs-lookup"><span data-stu-id="ca779-216">You can control the level of specular reflection as well as the level of shine.</span></span>  <span data-ttu-id="ca779-217">これらのプロパティでは光沢金属など光沢紙の素材の効果を作成する操作します。</span><span class="sxs-lookup"><span data-stu-id="ca779-217">These properties are manipulated to create material effects like shinny metals or glossy paper.</span></span>
<span data-ttu-id="ca779-218">**拡散**</span><span class="sxs-lookup"><span data-stu-id="ca779-218">**Diffuse**</span></span> | <span data-ttu-id="ca779-219">拡散型のリフレクションでは、すべての方向に光を拡散します。</span><span class="sxs-lookup"><span data-stu-id="ca779-219">Diffused reflection scatters the light in all directions.</span></span>
<span data-ttu-id="ca779-220">**反射のモデル**</span><span class="sxs-lookup"><span data-stu-id="ca779-220">**Reflectance Model**</span></span> | <span data-ttu-id="ca779-221">[反射モデル](/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel)間を選択することができます[Blinn フォン](https://docs.microsoft.com/visualstudio/designers/how-to-create-a-basic-phong-shader)と Blinn フォンを物理的に基づきます。</span><span class="sxs-lookup"><span data-stu-id="ca779-221">[Reflectance Model](/uwp/api/windows.ui.composition.effects.scenelightingeffectreflectancemodel) allows you to choose between [Blinn Phong](https://docs.microsoft.com/visualstudio/designers/how-to-create-a-basic-phong-shader) and Physically Based Blinn Phong.</span></span>  <span data-ttu-id="ca779-222">反射の光源が狭い場合は、Blinn フォンを物理的にベースを選択します。</span><span class="sxs-lookup"><span data-stu-id="ca779-222">You would choose Physically Based Blinn Phong when you want to have condensed specular highlights.</span></span>

### <a name="sample-scenelightingeffect"></a><span data-ttu-id="ca779-223">サンプル (SceneLightingEffect)</span><span class="sxs-lookup"><span data-stu-id="ca779-223">Sample (SceneLightingEffect)</span></span>

<span data-ttu-id="ca779-224">以下のサンプルでは、通常のマップを SceneLightingEffect を追加する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="ca779-224">The sample below shows how to add a normal map to a SceneLightingEffect.</span></span>

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

## <a name="related-articles"></a><span data-ttu-id="ca779-225">関連記事</span><span class="sxs-lookup"><span data-stu-id="ca779-225">Related articles</span></span>

- [<span data-ttu-id="ca779-226">ビジュアル層で素材と光源を作成します。</span><span class="sxs-lookup"><span data-stu-id="ca779-226">Creating Materials and Lights in the Visual Layer</span></span>](https://blogs.windows.com/buildingapps/2017/08/04/creating-materials-lights-visual-layer/)
- [<span data-ttu-id="ca779-227">照明の概要</span><span class="sxs-lookup"><span data-stu-id="ca779-227">Lighting Overview</span></span>](https://docs.microsoft.com/windows/uwp/graphics-concepts/lighting-overview)
- [<span data-ttu-id="ca779-228">CompositionCapabilities API</span><span class="sxs-lookup"><span data-stu-id="ca779-228">CompositionCapabilities API</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositioncapabilities)
- [<span data-ttu-id="ca779-229">照明の計算</span><span class="sxs-lookup"><span data-stu-id="ca779-229">Mathematics of Lighting</span></span>](https://docs.microsoft.com/windows/uwp/graphics-concepts/mathematics-of-lighting)
- [<span data-ttu-id="ca779-230">SceneLightingEffect</span><span class="sxs-lookup"><span data-stu-id="ca779-230">SceneLightingEffect</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.composition.effects.scenelightingeffect)
- [<span data-ttu-id="ca779-231">WindowsUIDevLabs GitHub リポジトリ</span><span class="sxs-lookup"><span data-stu-id="ca779-231">WindowsUIDevLabs GitHub Repo</span></span>](https://github.com/Microsoft/WindowsUIDevLabs)
