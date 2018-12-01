---
title: 光源のプロパティ
description: 光源のプロパティは、光源の種類 (ポイント、指向性、スポットライト)、減衰、色、方向、位置、範囲を表します。
ms.assetid: E832C3FD-9921-41C4-87B8-056E16B61B77
keywords:
- 光源のプロパティ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 86b8627461251a5d43762facc18c8a414a117fc9
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8339371"
---
# <a name="light-properties"></a><span data-ttu-id="2b682-104">光源のプロパティ</span><span class="sxs-lookup"><span data-stu-id="2b682-104">Light properties</span></span>


<span data-ttu-id="2b682-105">光源のプロパティは、光源の種類 (ポイント、指向性、スポットライト)、減衰、色、方向、位置、範囲を表します。</span><span class="sxs-lookup"><span data-stu-id="2b682-105">Light properties describe a light source's type (point, directional, spotlight), attenuation, color, direction, position, and range.</span></span> <span data-ttu-id="2b682-106">使う光源の種類に応じて、光源には減衰および範囲のプロパティや、スポットライト効果のプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="2b682-106">Depending on the type of light being used, a light can have properties for attenuation and range, or for spotlight effects.</span></span> <span data-ttu-id="2b682-107">すべての種類の光源がすべてのプロパティを使うわけではありません。</span><span class="sxs-lookup"><span data-stu-id="2b682-107">Not all types of lights use all properties.</span></span>

<span data-ttu-id="2b682-108">位置、範囲、および減衰プロパティは、ワールド空間における光源の位置と放射された光が遠くまで届くとどうなるかを定義します。</span><span class="sxs-lookup"><span data-stu-id="2b682-108">The position, range, and attenuation properties define a light's location in world space and how the light it emits behaves over distance.</span></span>

## <a name="span-idlightattenuationspanspan-idlightattenuationspanspan-idlightattenuationspanlight-attenuation"></a><span data-ttu-id="2b682-109"><span id="Light_Attenuation"></span><span id="light_attenuation"></span><span id="LIGHT_ATTENUATION"></span>光の減衰</span><span class="sxs-lookup"><span data-stu-id="2b682-109"><span id="Light_Attenuation"></span><span id="light_attenuation"></span><span id="LIGHT_ATTENUATION"></span>Light Attenuation</span></span>


<span data-ttu-id="2b682-110">減衰は、範囲プロパティによって指定された最大距離にいたるまでに光の強さがどのように弱くなっていくかを制御します。</span><span class="sxs-lookup"><span data-stu-id="2b682-110">Attenuation controls how a light's intensity decreases toward the maximum distance specified by the range property.</span></span> <span data-ttu-id="2b682-111">光の減衰を表すために、浮動小数点値 Attenuation0、Attenuation1、Attenuation2 が使われることがあります。</span><span class="sxs-lookup"><span data-stu-id="2b682-111">Three floating point values are sometimes used to represent light attenuation: Attenuation0, Attenuation1, and Attenuation2.</span></span> <span data-ttu-id="2b682-112">これらの浮動小数点値の範囲は 0.0 ～無限であり、光の減衰を制御します。</span><span class="sxs-lookup"><span data-stu-id="2b682-112">These floating-point values ranging from 0.0 through infinity, controlling a light's attenuation.</span></span> <span data-ttu-id="2b682-113">あるアプリケーションが Attenuation1 要素を 1.0 に設定し、他のアプリケーションが 0.0 に設定すると、光の強さは 1 / D に従って変化します。D は、光源から頂点までの距離です。</span><span class="sxs-lookup"><span data-stu-id="2b682-113">Some applications set the Attenuation1 member to 1.0 and the others to 0.0, resulting in light intensity that changes as 1 / D, where D is the distance from the light source to the vertex.</span></span> <span data-ttu-id="2b682-114">光が最も強いのは光源で、光の範囲において 1 / (光の範囲) に従って弱くなります。</span><span class="sxs-lookup"><span data-stu-id="2b682-114">The maximum light intensity is at the source, decreasing to 1 / (Light Range) at the light's range.</span></span>

<span data-ttu-id="2b682-115">通常、アプリケーションは Attenuation0 を 0.0 に、Attenuation1 を定数値に、Attenuation2 を 0.0 に設定しますが、これを変更することでさまざまな光の効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="2b682-115">Though typically, an application sets Attenuation0 to 0.0, Attenuation1 to a constant value, and Attenuation2 to 0.0, varying light effects can be achieved by changing this.</span></span> <span data-ttu-id="2b682-116">減衰値を組み合わせて、さらに複雑な減衰効果を出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="2b682-116">You can combine attenuation values to get more complex attenuation effects.</span></span> <span data-ttu-id="2b682-117">または、通常範囲外の値に設定し、さらに強い減衰効果を作り出すこともできます。</span><span class="sxs-lookup"><span data-stu-id="2b682-117">Or, you might set them to values outside the normal range to create even stranger attenuation effects.</span></span> <span data-ttu-id="2b682-118">ただし、負の減衰値は使うことができません。</span><span class="sxs-lookup"><span data-stu-id="2b682-118">Negative attenuation values, however, are not allowed.</span></span> <span data-ttu-id="2b682-119">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2b682-119">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span>

## <a name="span-idlightcolorspanspan-idlightcolorspanspan-idlightcolorspanlight-color"></a><span data-ttu-id="2b682-120"><span id="Light_Color"></span><span id="light_color"></span><span id="LIGHT_COLOR"></span>光の色</span><span class="sxs-lookup"><span data-stu-id="2b682-120"><span id="Light_Color"></span><span id="light_color"></span><span id="LIGHT_COLOR"></span>Light Color</span></span>


<span data-ttu-id="2b682-121">Direct3D の光源は、システムの照明計算で独立して使われる 3 つの色 (拡散色、環境色、反射色) を放射します。</span><span class="sxs-lookup"><span data-stu-id="2b682-121">Lights in Direct3D emit three colors that are used independently in the system's lighting computations: a diffuse color, an ambient color, and a specular color.</span></span> <span data-ttu-id="2b682-122">それぞれ Direct3D 照明モジュールに組み込まれており、現在の素材の対応部分と相互作用して、レンダリングに使われる最終的な色を生成します。</span><span class="sxs-lookup"><span data-stu-id="2b682-122">Each is incorporated by the Direct3D lighting module, interacting with a counterpart from the current material, to produce a final color used in rendering.</span></span> <span data-ttu-id="2b682-123">拡散色は、現在の素材の拡散反射率プロパティ、素材の鏡面反射率プロパティによる反射色などと相互作用します。</span><span class="sxs-lookup"><span data-stu-id="2b682-123">The diffuse color interacts with the diffuse reflectance property of the current material, the specular color with the material's specular reflectance property, and so on.</span></span> <span data-ttu-id="2b682-124">Direct3D がこれらの色を適用する方法に関する具体的な情報については、「[光源の計算](mathematics-of-lighting.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2b682-124">For specifics about how Direct3D applies these colors, see [Mathematics of lighting](mathematics-of-lighting.md).</span></span>

<span data-ttu-id="2b682-125">Direct3D アプリケーションでは、通常は放射される色を定義する 3 つの色値 (拡散、環境、反射) があります。</span><span class="sxs-lookup"><span data-stu-id="2b682-125">In a Direct3D application, typically there are three color values - Diffuse, Ambient, and Specular that defines the color being emitted.</span></span>

<span data-ttu-id="2b682-126">システムの計算に最も大きい影響を与える色の種類は、拡散色です。</span><span class="sxs-lookup"><span data-stu-id="2b682-126">The type of color that applies most heavily to the system's computations is the diffuse color.</span></span> <span data-ttu-id="2b682-127">最も一般的な拡散色は白 (R:1.0 G:1.0 B:1.0) ですが、必要に応じて色を作成して必要な効果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="2b682-127">The most common diffuse color is white (R:1.0 G:1.0 B:1.0), but you can create colors as needed to achieve desired effects.</span></span> <span data-ttu-id="2b682-128">たとえば、暖炉に赤い光を使ったり、信号を "進め" に設定するために緑の光を使ったりすることができます。</span><span class="sxs-lookup"><span data-stu-id="2b682-128">For example, you could use red light for a fireplace, or you could use green light for a traffic signal set to "Go."</span></span>

<span data-ttu-id="2b682-129">一般に、光の色コンポーネントは 0.0 ～ 1.0 (両端の値を含む) の値に設定しますが、必須ではありません。</span><span class="sxs-lookup"><span data-stu-id="2b682-129">Generally, you set the light color components to values between 0.0 and 1.0, inclusive, but this isn't a requirement.</span></span> <span data-ttu-id="2b682-130">たとえば、すべてのコンポーネントを 2.0 に設定し、"白より明るい" 色を作ることができます。</span><span class="sxs-lookup"><span data-stu-id="2b682-130">For example, you might set all the components to 2.0, creating a light that is "brighter than white."</span></span> <span data-ttu-id="2b682-131">この種類の設定は、特に定数以外の減衰設定を使う場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="2b682-131">This type of setting can be especially useful when you use attenuation settings other than constant.</span></span>

<span data-ttu-id="2b682-132">Direct3D は光に RGBA 値を使いますが、アルファ色コンポーネントは使いません。</span><span class="sxs-lookup"><span data-stu-id="2b682-132">Although Direct3D uses RGBA values for lights, the alpha color component is not used.</span></span>

<span data-ttu-id="2b682-133">通常、光には素材の色が使われます。</span><span class="sxs-lookup"><span data-stu-id="2b682-133">Usually material colors are used for lighting.</span></span> <span data-ttu-id="2b682-134">ただし、素材の色 (放射、環境、拡散、反射) が拡散または反射頂点色により上書きされることを指定できます。</span><span class="sxs-lookup"><span data-stu-id="2b682-134">However, you can specify that material colors-emissive, ambient, diffuse, and specular-are to be overridden by diffuse or specular vertex colors.</span></span>

<span data-ttu-id="2b682-135">アルファ/透明度の値は、常に拡散色のアルファ チャネルからのみ取得されます。</span><span class="sxs-lookup"><span data-stu-id="2b682-135">The alpha/transparency value always comes only from the diffuse color's alpha channel.</span></span>

<span data-ttu-id="2b682-136">霧の値は、常に反射色のアルファ チャネルからのみ取得されます。</span><span class="sxs-lookup"><span data-stu-id="2b682-136">The fog value always comes only from the specular color's alpha channel.</span></span>

## <a name="span-idlightdirectionspanspan-idlightdirectionspanspan-idlightdirectionspanlight-direction"></a><span data-ttu-id="2b682-137"><span id="Light_Direction"></span><span id="light_direction"></span><span id="LIGHT_DIRECTION"></span>光の方向</span><span class="sxs-lookup"><span data-stu-id="2b682-137"><span id="Light_Direction"></span><span id="light_direction"></span><span id="LIGHT_DIRECTION"></span>Light Direction</span></span>


<span data-ttu-id="2b682-138">光の方向プロパティは、ワールド空間においてオブジェクトの移動により光が放射される方向を決定します。</span><span class="sxs-lookup"><span data-stu-id="2b682-138">A light's direction property determines the direction that the light emitted by the object travels, in world space.</span></span> <span data-ttu-id="2b682-139">方向は、指向性ライトやスポットライトによってのみ使われ、ベクトルによって表現されます。</span><span class="sxs-lookup"><span data-stu-id="2b682-139">Direction is used only by directional lights and spotlights, and is described with a vector.</span></span>

<span data-ttu-id="2b682-140">光の方向はベクトルで設定します。</span><span class="sxs-lookup"><span data-stu-id="2b682-140">Set the light direction as a vector.</span></span> <span data-ttu-id="2b682-141">方向ベクトルは、シーン内の光源に位置に関係なく、論理的な原点からの距離として表現されます。</span><span class="sxs-lookup"><span data-stu-id="2b682-141">Direction vectors are described as distances from a logical origin, regardless of the light's position in a scene.</span></span> <span data-ttu-id="2b682-142">したがって、シーンをまっすぐポイントする (正の z 軸に沿って) スポットライトの方向ベクトルは、その位置の定義に関係なく &lt;0,0,1&gt; になります。</span><span class="sxs-lookup"><span data-stu-id="2b682-142">Therefore, a spotlight that points straight into a scene - along the positive z-axis - has a direction vector of &lt;0,0,1&gt; no matter where its position is defined to be.</span></span> <span data-ttu-id="2b682-143">同様に、シーンを直接照らす日光は、方向が &lt;0,-1,0&gt; の指向性ライトを使ってシミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="2b682-143">Similarly, you can simulate sunlight shining directly on a scene by using a directional light whose direction is &lt;0,-1,0&gt;.</span></span> <span data-ttu-id="2b682-144">座標軸に沿って照らす光を作る必要はありません。値をうまく組み合わせて、より興味深い角度で照らす光を作り出すことができます。</span><span class="sxs-lookup"><span data-stu-id="2b682-144">You don't have to create lights that shine along the coordinate axes; you can mix and match values to create lights that shine at more interesting angles.</span></span>

<span data-ttu-id="2b682-145">光の方向ベクトルを正規化する必要はありませんが、常に大きさを設定してください。</span><span class="sxs-lookup"><span data-stu-id="2b682-145">Although you don't need to normalize a light's direction vector, always be sure that it has magnitude.</span></span> <span data-ttu-id="2b682-146">言い換えると、方向ベクトル &lt;0,0,0&gt; は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="2b682-146">In other words, don't use a &lt;0,0,0&gt; direction vector.</span></span>

## <a name="span-idlightpositionspanspan-idlightpositionspanspan-idlightpositionspanlight-position"></a><span data-ttu-id="2b682-147"><span id="Light_Position"></span><span id="light_position"></span><span id="LIGHT_POSITION"></span>光の位置</span><span class="sxs-lookup"><span data-stu-id="2b682-147"><span id="Light_Position"></span><span id="light_position"></span><span id="LIGHT_POSITION"></span>Light Position</span></span>


<span data-ttu-id="2b682-148">光の位置は、ベクトル構造を使って表されます。</span><span class="sxs-lookup"><span data-stu-id="2b682-148">Light position is described using a vector structure.</span></span> <span data-ttu-id="2b682-149">x、y、z 座標がワールド空間にあるという前提です。</span><span class="sxs-lookup"><span data-stu-id="2b682-149">The x, y, and z coordinates are assumed to be in world space.</span></span> <span data-ttu-id="2b682-150">位置プロパティを使わない光の種類は、指向性ライトだけです。</span><span class="sxs-lookup"><span data-stu-id="2b682-150">Directional lights are the only type of light that don't use the position property.</span></span>

## <a name="span-idlightrangespanspan-idlightrangespanspan-idlightrangespanlight-range"></a><span data-ttu-id="2b682-151"><span id="Light_Range"></span><span id="light_range"></span><span id="LIGHT_RANGE"></span>光の範囲</span><span class="sxs-lookup"><span data-stu-id="2b682-151"><span id="Light_Range"></span><span id="light_range"></span><span id="LIGHT_RANGE"></span>Light Range</span></span>


<span data-ttu-id="2b682-152">光の範囲プロパティは、シーン内のメッシュがそのオブジェクトにより放射された光を受け取らなくなる、ワールド空間における距離を決定します。</span><span class="sxs-lookup"><span data-stu-id="2b682-152">A light's range property determines the distance, in world space, at which meshes in a scene no longer receive light emitted by that object.</span></span> <span data-ttu-id="2b682-153">指向性ライトは範囲プロパティを使いません。</span><span class="sxs-lookup"><span data-stu-id="2b682-153">Directional lights don't use the range property.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="2b682-154"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="2b682-154"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="2b682-155">照明および素材</span><span class="sxs-lookup"><span data-stu-id="2b682-155">Lights and materials</span></span>](lights-and-materials.md)

 

 




