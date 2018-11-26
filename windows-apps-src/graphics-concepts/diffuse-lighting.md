---
title: 拡散光
description: 拡散光は、ライトの方向とオブジェクトのサーフェス法線の両方に依存します。
ms.assetid: 8AF78742-76B1-4BBB-86E3-94AE6F48B847
keywords:
- 拡散光
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1785b06aa2217e8ec15aeaa560bd98a65522df2e
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7706826"
---
# <a name="diffuse-lighting"></a><span data-ttu-id="92efb-104">拡散光</span><span class="sxs-lookup"><span data-stu-id="92efb-104">Diffuse lighting</span></span>


<span data-ttu-id="92efb-105">*拡散光*は、ライトの方向とオブジェクトのサーフェス法線の両方に依存します。</span><span class="sxs-lookup"><span data-stu-id="92efb-105">*Diffuse lighting* depends on both the light direction and the object surface normal.</span></span> <span data-ttu-id="92efb-106">光の方向を変更し、サーフェスの法線ベクトルを変更すると、拡散光がオブジェクトのサーフェス上で変化します。</span><span class="sxs-lookup"><span data-stu-id="92efb-106">Diffuse lighting varies across the surface of an object as a result of the changing light direction and the changing surface numeral vector.</span></span> <span data-ttu-id="92efb-107">拡散光は、オブジェクトの頂点ごとに変化するため、その計算には時間がかかりますが、オブジェクトにシェーディングが適用され、3 次元 (3D) の奥行を与えるという利点があります。</span><span class="sxs-lookup"><span data-stu-id="92efb-107">It takes longer to calculate diffuse lighting because it changes for each object vertex, however the benefit of using it is that it shades objects and gives them three-dimensional (3D) depth.</span></span>

<span data-ttu-id="92efb-108">任意の減衰効果について光の強さを調整した後、照明エンジンは、頂点法線の角度および入射光の方向から、頂点から反射する残りの光量を計算します。</span><span class="sxs-lookup"><span data-stu-id="92efb-108">After adjusting the light intensity for any attenuation effects, the lighting engine computes how much of the remaining light reflects from a vertex, given the angle of the vertex normal and the direction of the incident light.</span></span> <span data-ttu-id="92efb-109">照明エンジンは、指向性ライトについては、距離による減衰がないためこの手順をスキップします。</span><span class="sxs-lookup"><span data-stu-id="92efb-109">The lighting engine skips to this step for directional lights because they do not attenuate over distance.</span></span> <span data-ttu-id="92efb-110">システムでは、拡散と鏡面の 2 種類の反射を考慮し、異なる指揮を使用してそれぞれの反射する光量を決定します。</span><span class="sxs-lookup"><span data-stu-id="92efb-110">The system considers two reflection types, diffuse and specular, and uses a different formula to determine how much light is reflected for each.</span></span>

<span data-ttu-id="92efb-111">反射の光量を計算した後、Direct3D は、現在のマテリアルの拡散および鏡面反射率プロパティにこれらの新しい値を適用します。</span><span class="sxs-lookup"><span data-stu-id="92efb-111">After calculating the amounts of light reflected, Direct3D applies these new values to the diffuse and specular reflectance properties of the current material.</span></span> <span data-ttu-id="92efb-112">結果として得られる色の値は、ラスタライザーはグーロー シェーディングと鏡面ハイライトを生成するために使用する拡散および鏡面コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="92efb-112">The resulting color values are the diffuse and specular components that the rasterizer uses to produce Gouraud shading and specular highlighting.</span></span>

<span data-ttu-id="92efb-113">拡散光は次の方程式で表されます。</span><span class="sxs-lookup"><span data-stu-id="92efb-113">Diffuse lighting is described by the following equation.</span></span>

<span data-ttu-id="92efb-114">拡散光 = sum\[C<sub>d</sub>\*L<sub>d</sub>\*(N<sup>.</sup>L<sub>dir</sub>)\*Atten\*Spot\]</span><span class="sxs-lookup"><span data-stu-id="92efb-114">Diffuse Lighting = sum\[C<sub>d</sub>\*L<sub>d</sub>\*(N<sup>.</sup>L<sub>dir</sub>)\*Atten\*Spot\]</span></span>

| <span data-ttu-id="92efb-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="92efb-115">Parameter</span></span>       | <span data-ttu-id="92efb-116">既定値</span><span class="sxs-lookup"><span data-stu-id="92efb-116">Default value</span></span> | <span data-ttu-id="92efb-117">種類</span><span class="sxs-lookup"><span data-stu-id="92efb-117">Type</span></span>          | <span data-ttu-id="92efb-118">説明</span><span class="sxs-lookup"><span data-stu-id="92efb-118">Description</span></span>                                                                                      |
|-----------------|---------------|---------------|--------------------------------------------------------------------------------------------------|
| <span data-ttu-id="92efb-119">sum</span><span class="sxs-lookup"><span data-stu-id="92efb-119">sum</span></span>             | <span data-ttu-id="92efb-120">なし</span><span class="sxs-lookup"><span data-stu-id="92efb-120">N/A</span></span>           | <span data-ttu-id="92efb-121">なし</span><span class="sxs-lookup"><span data-stu-id="92efb-121">N/A</span></span>           | <span data-ttu-id="92efb-122">各ライトの拡散コンポーネントの総和。</span><span class="sxs-lookup"><span data-stu-id="92efb-122">Summation of each light's diffuse component.</span></span>                                                     |
| <span data-ttu-id="92efb-123">C<sub>d</sub></span><span class="sxs-lookup"><span data-stu-id="92efb-123">C<sub>d</sub></span></span>   | <span data-ttu-id="92efb-124">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="92efb-124">(0,0,0,0)</span></span>     | <span data-ttu-id="92efb-125">D3DCOLORVALUE</span><span class="sxs-lookup"><span data-stu-id="92efb-125">D3DCOLORVALUE</span></span> | <span data-ttu-id="92efb-126">拡散色。</span><span class="sxs-lookup"><span data-stu-id="92efb-126">Diffuse color.</span></span>                                                                                   |
| <span data-ttu-id="92efb-127">L<sub>d</sub></span><span class="sxs-lookup"><span data-stu-id="92efb-127">L<sub>d</sub></span></span>   | <span data-ttu-id="92efb-128">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="92efb-128">(0,0,0,0)</span></span>     | <span data-ttu-id="92efb-129">D3DCOLORVALUE</span><span class="sxs-lookup"><span data-stu-id="92efb-129">D3DCOLORVALUE</span></span> | <span data-ttu-id="92efb-130">明るい拡散色。</span><span class="sxs-lookup"><span data-stu-id="92efb-130">Light diffuse color.</span></span>                                                                             |
| <span data-ttu-id="92efb-131">N</span><span class="sxs-lookup"><span data-stu-id="92efb-131">N</span></span>               | <span data-ttu-id="92efb-132">なし</span><span class="sxs-lookup"><span data-stu-id="92efb-132">N/A</span></span>           | <span data-ttu-id="92efb-133">D3DVECTOR</span><span class="sxs-lookup"><span data-stu-id="92efb-133">D3DVECTOR</span></span>     | <span data-ttu-id="92efb-134">頂点法線</span><span class="sxs-lookup"><span data-stu-id="92efb-134">Vertex normal</span></span>                                                                                    |
| <span data-ttu-id="92efb-135">L<sub>dir</sub></span><span class="sxs-lookup"><span data-stu-id="92efb-135">L<sub>dir</sub></span></span> | <span data-ttu-id="92efb-136">なし</span><span class="sxs-lookup"><span data-stu-id="92efb-136">N/A</span></span>           | <span data-ttu-id="92efb-137">D3DVECTOR</span><span class="sxs-lookup"><span data-stu-id="92efb-137">D3DVECTOR</span></span>     | <span data-ttu-id="92efb-138">オブジェクトの頂点からライトへの方向ベクトル。</span><span class="sxs-lookup"><span data-stu-id="92efb-138">Direction vector from object vertex to the light.</span></span>                                                |
| <span data-ttu-id="92efb-139">Atten</span><span class="sxs-lookup"><span data-stu-id="92efb-139">Atten</span></span>           | <span data-ttu-id="92efb-140">なし</span><span class="sxs-lookup"><span data-stu-id="92efb-140">N/A</span></span>           | <span data-ttu-id="92efb-141">FLOAT</span><span class="sxs-lookup"><span data-stu-id="92efb-141">FLOAT</span></span>         | <span data-ttu-id="92efb-142">光の減衰。</span><span class="sxs-lookup"><span data-stu-id="92efb-142">Light attenuation.</span></span> <span data-ttu-id="92efb-143">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="92efb-143">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span> |
| <span data-ttu-id="92efb-144">Spot</span><span class="sxs-lookup"><span data-stu-id="92efb-144">Spot</span></span>            | <span data-ttu-id="92efb-145">なし</span><span class="sxs-lookup"><span data-stu-id="92efb-145">N/A</span></span>           | <span data-ttu-id="92efb-146">FLOAT</span><span class="sxs-lookup"><span data-stu-id="92efb-146">FLOAT</span></span>         | <span data-ttu-id="92efb-147">スポットライト係数。</span><span class="sxs-lookup"><span data-stu-id="92efb-147">Spotlight factor.</span></span> <span data-ttu-id="92efb-148">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="92efb-148">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span>  |

 

<span data-ttu-id="92efb-149">減衰 (Atten) またはスポット ライトの特性 (Spot) を計算するには、「[減衰とスポット ライトの係数](attenuation-and-spotlight-factor.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="92efb-149">To calculate the attenuation (Atten) or the spotlight characteristics (Spot), see [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span>

<span data-ttu-id="92efb-150">拡散コンポーネントは、すべての光が個別に処理されて補間されると、0 ～ 255 になるようにクランプされます。</span><span class="sxs-lookup"><span data-stu-id="92efb-150">Diffuse components are clamped to be from 0 to 255, after all lights are processed and interpolated separately.</span></span> <span data-ttu-id="92efb-151">生成された拡散照明値は、環境光、拡散光、放射光の値の組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="92efb-151">The resulting diffuse lighting value is a combination of the ambient, diffuse and emissive light values.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="92efb-152"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="92efb-152"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="92efb-153">この例では、オブジェクトの色は、ライトの拡散色とマテリアルの拡散色を使用しています。</span><span class="sxs-lookup"><span data-stu-id="92efb-153">In this example, the object is colored using the light diffuse color and a material diffuse color.</span></span>

<span data-ttu-id="92efb-154">この方程式では、生成されるオブジェクトの頂点の色は、マテリアルの色と光の色の組み合わせになります。</span><span class="sxs-lookup"><span data-stu-id="92efb-154">According to the equation, the resulting color for the object vertices is a combination of the material color and the light color.</span></span>

<span data-ttu-id="92efb-155">次の 2 つのイメージは、マテリアルの色がグレーで、ライトの色が明るい赤であることを示しています。</span><span class="sxs-lookup"><span data-stu-id="92efb-155">The following two illustrations show the material color, which is gray, and the light color, which is bright red.</span></span>

![グレーの球体の図](images/amb1.jpg)![赤の球体の図](images/lightred.jpg)

<span data-ttu-id="92efb-158">結果として作成されるシーンは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="92efb-158">The resulting scene is shown in the following illustration.</span></span> <span data-ttu-id="92efb-159">シーン内の唯一のオブジェクトは球です。</span><span class="sxs-lookup"><span data-stu-id="92efb-159">The only object in the scene is a sphere.</span></span> <span data-ttu-id="92efb-160">拡散照明の計算では、マテリアルとライトの拡散色を取得した後、内積を使用して、ライトの方向と頂点法線の間の角度からその値を修正します。</span><span class="sxs-lookup"><span data-stu-id="92efb-160">The diffuse lighting calculation takes the material and light diffuse color and modifies it by the angle between the light direction and the vertex normal using the dot product.</span></span> <span data-ttu-id="92efb-161">その結果、球の背面は、球のサーフェスがカーブしながらライトから遠ざかるに従い暗くなります。</span><span class="sxs-lookup"><span data-stu-id="92efb-161">As a result, the backside of the sphere gets darker as the surface of the sphere curves away from the light.</span></span>

![拡散光のある球体の図](images/lightd.jpg)

<span data-ttu-id="92efb-163">拡散光と前の例の環境光を組み合わせると、オブジェクトのサーフェス全体に影が付けられます。</span><span class="sxs-lookup"><span data-stu-id="92efb-163">Combining the diffuse lighting with the ambient lighting from the previous example shades the entire surface of the object.</span></span> <span data-ttu-id="92efb-164">次の図に示すように、環境光はサーフェス全体に影を付け、拡散光はオブジェクトの 3D 形状を表現するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="92efb-164">The ambient light shades the entire surface and the diffuse light helps reveal the object's 3D shape, as shown in the following illustration.</span></span>

![拡散光と環境光のある球体の図](images/lightad.jpg)

<span data-ttu-id="92efb-166">拡散光は、環境光よりも計算の負荷が高くなります。</span><span class="sxs-lookup"><span data-stu-id="92efb-166">Diffuse lighting is more intensive to calculate than ambient lighting.</span></span> <span data-ttu-id="92efb-167">頂点法線とライトの方向に依存しているため、オブジェクトのジオメトリを 3D 空間で表現でき、環境光よりリアルな照明を生成できます。</span><span class="sxs-lookup"><span data-stu-id="92efb-167">Because it depends on the vertex normals and light direction, you can see the objects geometry in 3D space, which produces a more realistic lighting than ambient lighting.</span></span> <span data-ttu-id="92efb-168">鏡面ハイライトを使用すると、さらにリアルな外観を表現できます。</span><span class="sxs-lookup"><span data-stu-id="92efb-168">You can use specular highlights to achieve a more realistic look.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="92efb-169"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="92efb-169"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="92efb-170">光源の計算</span><span class="sxs-lookup"><span data-stu-id="92efb-170">Mathematics of lighting</span></span>](mathematics-of-lighting.md)

 

 




