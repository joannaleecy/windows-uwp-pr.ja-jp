---
title: 反射光
description: 反射光では、光がオブジェクトの表面に当たり、カメラに向かって反射する明るい反射光を指定します。
ms.assetid: 71F87137-B00F-48CE-8E6A-F98A139A742A
keywords:
- 反射光
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 283ea63d118f9a61fe745dd3eb60b68594c32279
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7570648"
---
# <a name="specular-lighting"></a><span data-ttu-id="a87b5-104">反射光</span><span class="sxs-lookup"><span data-stu-id="a87b5-104">Specular lighting</span></span>


<span data-ttu-id="a87b5-105">*反射光*では、光がオブジェクトの表面に当たり、カメラに向かって反射する明るい反射光を指定します。</span><span class="sxs-lookup"><span data-stu-id="a87b5-105">*Specular lighting* identifies the bright specular highlights that occur when light hits an object surface and reflects back toward the camera.</span></span> <span data-ttu-id="a87b5-106">反射光は拡散光よりも強い光で、オブジェクトの表面から短時間で消えます。</span><span class="sxs-lookup"><span data-stu-id="a87b5-106">Specular lighting is more intense than diffuse light and falls off more rapidly across the object surface.</span></span> <span data-ttu-id="a87b5-107">反射光の方が拡散光よりも計算に時間がかかりますが、反射光を使用すると、表面の表現力が格段に向上します。</span><span class="sxs-lookup"><span data-stu-id="a87b5-107">It takes longer to calculate specular lighting than diffuse lighting, however the benefit of using it is that it adds significant detail to a surface.</span></span>

<span data-ttu-id="a87b5-108">反射光のモデリングでは、光が進む方向と、見る人の目の方向をシステムが認識している必要があります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-108">Modeling specular reflection requires that the system know in what direction light is traveling and the direction to the viewer's eye.</span></span> <span data-ttu-id="a87b5-109">システムはフォン反射光モデルの簡易版を使用します。これは、中間ベクトルを使用して、反射光のおおよその強さを計算します。</span><span class="sxs-lookup"><span data-stu-id="a87b5-109">The system uses a simplified version of the Phong specular-reflection model, which employs a halfway vector to approximate the intensity of specular reflection.</span></span>

<span data-ttu-id="a87b5-110">既定の光源の状態では、反射光は計算されません。</span><span class="sxs-lookup"><span data-stu-id="a87b5-110">The default lighting state does not calculate specular highlights.</span></span>

## <a name="span-idspecularlightingequationspanspan-idspecularlightingequationspanspan-idspecularlightingequationspanspecular-lighting-equation"></a><span data-ttu-id="a87b5-111"><span id="Specular_Lighting_Equation"></span><span id="specular_lighting_equation"></span><span id="SPECULAR_LIGHTING_EQUATION"></span>反射光の方程式</span><span class="sxs-lookup"><span data-stu-id="a87b5-111"><span id="Specular_Lighting_Equation"></span><span id="specular_lighting_equation"></span><span id="SPECULAR_LIGHTING_EQUATION"></span>Specular Lighting Equation</span></span>


<span data-ttu-id="a87b5-112">反射光は次の方程式で表されます。</span><span class="sxs-lookup"><span data-stu-id="a87b5-112">Specular Lighting is described by the following equation.</span></span>

|                                                                             |
|-----------------------------------------------------------------------------|
| <span data-ttu-id="a87b5-113">反射光 = Cₛ \* sum\[Lₛ \* (N · H)<sup>P</sup> \* Atten \* Spot\]</span><span class="sxs-lookup"><span data-stu-id="a87b5-113">Specular Lighting = Cₛ \* sum\[Lₛ \* (N · H)<sup>P</sup> \* Atten \* Spot\]</span></span> |

 

<span data-ttu-id="a87b5-114">変数とその型および範囲は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a87b5-114">The variables, their types, and their ranges are as follows:</span></span>

| <span data-ttu-id="a87b5-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87b5-115">Parameter</span></span>    | <span data-ttu-id="a87b5-116">既定値</span><span class="sxs-lookup"><span data-stu-id="a87b5-116">Default value</span></span> | <span data-ttu-id="a87b5-117">種類</span><span class="sxs-lookup"><span data-stu-id="a87b5-117">Type</span></span>                                                             | <span data-ttu-id="a87b5-118">説明</span><span class="sxs-lookup"><span data-stu-id="a87b5-118">Description</span></span>                                                                                            |
|--------------|---------------|------------------------------------------------------------------|--------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="a87b5-119">Cₛ</span><span class="sxs-lookup"><span data-stu-id="a87b5-119">Cₛ</span></span>           | <span data-ttu-id="a87b5-120">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="a87b5-120">(0,0,0,0)</span></span>     | <span data-ttu-id="a87b5-121">赤、緑、青、およびアルファ透明度 (浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a87b5-121">Red, green, blue, and alpha transparency (floating-point values)</span></span> | <span data-ttu-id="a87b5-122">反射の色。</span><span class="sxs-lookup"><span data-stu-id="a87b5-122">Specular color.</span></span>                                                                                        |
| <span data-ttu-id="a87b5-123">sum</span><span class="sxs-lookup"><span data-stu-id="a87b5-123">sum</span></span>          | <span data-ttu-id="a87b5-124">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-124">N/A</span></span>           | <span data-ttu-id="a87b5-125">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-125">N/A</span></span>                                                              | <span data-ttu-id="a87b5-126">各ライトの鏡面コンポーネントの総和。</span><span class="sxs-lookup"><span data-stu-id="a87b5-126">Summation of each light's specular component.</span></span>                                                          |
| <span data-ttu-id="a87b5-127">N</span><span class="sxs-lookup"><span data-stu-id="a87b5-127">N</span></span>            | <span data-ttu-id="a87b5-128">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-128">N/A</span></span>           | <span data-ttu-id="a87b5-129">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a87b5-129">3D vector (x, y, and z floating-point values)</span></span>                    | <span data-ttu-id="a87b5-130">頂点法線。</span><span class="sxs-lookup"><span data-stu-id="a87b5-130">Vertex normal.</span></span>                                                                                         |
| <span data-ttu-id="a87b5-131">H</span><span class="sxs-lookup"><span data-stu-id="a87b5-131">H</span></span>            | <span data-ttu-id="a87b5-132">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-132">N/A</span></span>           | <span data-ttu-id="a87b5-133">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a87b5-133">3D vector (x, y, and z floating-point values)</span></span>                    | <span data-ttu-id="a87b5-134">中間ベクトル。</span><span class="sxs-lookup"><span data-stu-id="a87b5-134">Half way vector.</span></span> <span data-ttu-id="a87b5-135">中間ベクトルのセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="a87b5-135">See the section on the halfway vector.</span></span>                                                |
| <sup><span data-ttu-id="a87b5-136">P</span><span class="sxs-lookup"><span data-stu-id="a87b5-136">P</span></span></sup> | <span data-ttu-id="a87b5-137">0.0</span><span class="sxs-lookup"><span data-stu-id="a87b5-137">0.0</span></span>           | <span data-ttu-id="a87b5-138">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a87b5-138">Floating point</span></span>                                                   | <span data-ttu-id="a87b5-139">鏡面反射の係数。</span><span class="sxs-lookup"><span data-stu-id="a87b5-139">Specular reflection power.</span></span> <span data-ttu-id="a87b5-140">範囲は 0 から +infinity です。</span><span class="sxs-lookup"><span data-stu-id="a87b5-140">Range is 0 to +infinity</span></span>                                                     |
| <span data-ttu-id="a87b5-141">Lₚ</span><span class="sxs-lookup"><span data-stu-id="a87b5-141">Lₛ</span></span>           | <span data-ttu-id="a87b5-142">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="a87b5-142">(0,0,0,0)</span></span>     | <span data-ttu-id="a87b5-143">赤、緑、青、およびアルファ透明度 (浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a87b5-143">Red, green, blue, and alpha transparency (floating-point values)</span></span> | <span data-ttu-id="a87b5-144">明るい鏡面色。</span><span class="sxs-lookup"><span data-stu-id="a87b5-144">Light specular color.</span></span>                                                                                  |
| <span data-ttu-id="a87b5-145">Atten</span><span class="sxs-lookup"><span data-stu-id="a87b5-145">Atten</span></span>        | <span data-ttu-id="a87b5-146">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-146">N/A</span></span>           | <span data-ttu-id="a87b5-147">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a87b5-147">Floating point</span></span>                                                   | <span data-ttu-id="a87b5-148">光の減衰値。</span><span class="sxs-lookup"><span data-stu-id="a87b5-148">Light attenuation value.</span></span> <span data-ttu-id="a87b5-149">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a87b5-149">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span> |
| <span data-ttu-id="a87b5-150">Spot</span><span class="sxs-lookup"><span data-stu-id="a87b5-150">Spot</span></span>         | <span data-ttu-id="a87b5-151">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-151">N/A</span></span>           | <span data-ttu-id="a87b5-152">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a87b5-152">Floating point</span></span>                                                   | <span data-ttu-id="a87b5-153">スポットライト係数。</span><span class="sxs-lookup"><span data-stu-id="a87b5-153">Spotlight factor.</span></span> <span data-ttu-id="a87b5-154">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a87b5-154">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span>        |

 

<span data-ttu-id="a87b5-155">Cₛ の値は以下のどちらかになります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-155">The value for Cₛ is either:</span></span>

-   <span data-ttu-id="a87b5-156">頂点の色 1。鏡面マテリアル ソースが拡散の頂点の色であり、最初の頂点の色が頂点の宣言において指定されている場合。</span><span class="sxs-lookup"><span data-stu-id="a87b5-156">vertex color 1, if the specular material source is the diffuse vertex color, and the first vertex color is supplied in the vertex declaration.</span></span>
-   <span data-ttu-id="a87b5-157">頂点の色 2。鏡面マテリアル ソースが反射の頂点の色であり、2 番目の頂点の色が頂点の宣言において指定されている場合。</span><span class="sxs-lookup"><span data-stu-id="a87b5-157">vertex color 2, if specular material source is the specular vertex color, and the second vertex color is supplied in the vertex declaration.</span></span>
-   <span data-ttu-id="a87b5-158">マテリアルの反射色</span><span class="sxs-lookup"><span data-stu-id="a87b5-158">material specular color</span></span>

<span data-ttu-id="a87b5-159">**注:** かどうかは、いずれかの鏡面マテリアル ソース オプションが使用されると、頂点の色が指定されていないマテリアルの反射色を使用します。</span><span class="sxs-lookup"><span data-stu-id="a87b5-159">**Note** If either specular material source option is used and the vertex color is not provided, then the material specular color is used.</span></span>

 

<span data-ttu-id="a87b5-160">反射コンポーネントは、すべての光が個別に処理されて補間されると、0 ～ 255 になるようにクランプされます。</span><span class="sxs-lookup"><span data-stu-id="a87b5-160">Specular components are clamped to be from 0 to 255, after all lights are processed and interpolated separately.</span></span>

## <a name="span-idthehalfwayvectorspanspan-idthehalfwayvectorspanspan-idthehalfwayvectorspanthe-halfway-vector"></a><span data-ttu-id="a87b5-161"><span id="The_Halfway_Vector"></span><span id="the_halfway_vector"></span><span id="THE_HALFWAY_VECTOR"></span>中間ベクトル</span><span class="sxs-lookup"><span data-stu-id="a87b5-161"><span id="The_Halfway_Vector"></span><span id="the_halfway_vector"></span><span id="THE_HALFWAY_VECTOR"></span>The Halfway Vector</span></span>


<span data-ttu-id="a87b5-162">中間ベクトル (H) は、オブジェクトの頂点から光源までのベクトルと、オブジェクトの頂点からカメラの市場でのベクトルの 2 つのベクトルの中間に存在しています。</span><span class="sxs-lookup"><span data-stu-id="a87b5-162">The halfway vector (H) exists midway between two vectors: the vector from an object vertex to the light source, and the vector from an object vertex to the camera position.</span></span> <span data-ttu-id="a87b5-163">Direct3D では、中間ベクトルの計算に 2 通りの方法を用意しています。</span><span class="sxs-lookup"><span data-stu-id="a87b5-163">Direct3D provides two ways to compute the halfway vector.</span></span> <span data-ttu-id="a87b5-164">(直角の反射光ではなく) カメラと相対的な反射光が有効な場合、カメラの位置と頂点の位置の他、光の方向ベクトルを併せて使用して、中間ベクトルを計算します。</span><span class="sxs-lookup"><span data-stu-id="a87b5-164">When camera-relative specular highlights is enabled (instead of orthogonal specular highlights), the system calculates the halfway vector using the position of the camera and the position of the vertex, along with the light's direction vector.</span></span> <span data-ttu-id="a87b5-165">これは次の数式で表されます。</span><span class="sxs-lookup"><span data-stu-id="a87b5-165">The following formula illustrates this.</span></span>

|                                           |
|-------------------------------------------|
| <span data-ttu-id="a87b5-166">H = norm(norm(Cₚ - Vₚ) + L<sub>dir</sub>)</span><span class="sxs-lookup"><span data-stu-id="a87b5-166">H = norm(norm(Cₚ - Vₚ) + L<sub>dir</sub>)</span></span> |

 

| <span data-ttu-id="a87b5-167">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a87b5-167">Parameter</span></span>       | <span data-ttu-id="a87b5-168">既定値</span><span class="sxs-lookup"><span data-stu-id="a87b5-168">Default value</span></span> | <span data-ttu-id="a87b5-169">種類</span><span class="sxs-lookup"><span data-stu-id="a87b5-169">Type</span></span>                                          | <span data-ttu-id="a87b5-170">説明</span><span class="sxs-lookup"><span data-stu-id="a87b5-170">Description</span></span>                                                  |
|-----------------|---------------|-----------------------------------------------|--------------------------------------------------------------|
| <span data-ttu-id="a87b5-171">Cₚ</span><span class="sxs-lookup"><span data-stu-id="a87b5-171">Cₚ</span></span>              | <span data-ttu-id="a87b5-172">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-172">N/A</span></span>           | <span data-ttu-id="a87b5-173">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a87b5-173">3D vector (x, y, and z floating-point values)</span></span> | <span data-ttu-id="a87b5-174">カメラの位置。</span><span class="sxs-lookup"><span data-stu-id="a87b5-174">Camera position.</span></span>                                             |
| <span data-ttu-id="a87b5-175">Vₚ</span><span class="sxs-lookup"><span data-stu-id="a87b5-175">Vₚ</span></span>              | <span data-ttu-id="a87b5-176">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-176">N/A</span></span>           | <span data-ttu-id="a87b5-177">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a87b5-177">3D vector (x, y, and z floating-point values)</span></span> | <span data-ttu-id="a87b5-178">頂点の位置。</span><span class="sxs-lookup"><span data-stu-id="a87b5-178">Vertex position.</span></span>                                             |
| <span data-ttu-id="a87b5-179">L<sub>dir</sub></span><span class="sxs-lookup"><span data-stu-id="a87b5-179">L<sub>dir</sub></span></span> | <span data-ttu-id="a87b5-180">該当なし</span><span class="sxs-lookup"><span data-stu-id="a87b5-180">N/A</span></span>           | <span data-ttu-id="a87b5-181">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a87b5-181">3D vector (x, y, and z floating-point values)</span></span> | <span data-ttu-id="a87b5-182">頂点の位置からライトの位置への方向ベクトル。</span><span class="sxs-lookup"><span data-stu-id="a87b5-182">Direction vector from vertex position to the light position.</span></span> |

 

<span data-ttu-id="a87b5-183">この方法で中間ベクトルを決定すると、計算の負荷が高くなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-183">Determining the halfway vector in this manner can be computationally intensive.</span></span> <span data-ttu-id="a87b5-184">または、(カメラと相対的な反射光ではなく) 直角反射光を使用する場合は、視点までの z 軸上の距離が無限であるものとして扱われます。</span><span class="sxs-lookup"><span data-stu-id="a87b5-184">As an alternative, using orthogonal specular highlights (instead of camera-relative specular highlights) instructs the system to act as though the viewpoint is infinitely distant on the z-axis.</span></span> <span data-ttu-id="a87b5-185">この式は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-185">This is reflected in the following formula.</span></span>

|                                     |
|-------------------------------------|
| <span data-ttu-id="a87b5-186">H = norm((0,0,1) + L<sub>dir</sub>)</span><span class="sxs-lookup"><span data-stu-id="a87b5-186">H = norm((0,0,1) + L<sub>dir</sub>)</span></span> |

 

<span data-ttu-id="a87b5-187">この設定は計算の負荷は低くなりますが、精度も落ちるため、正投影を使用するアプリケーションでの使用が最適です。</span><span class="sxs-lookup"><span data-stu-id="a87b5-187">This setting is less computationally intensive, but much less accurate, so it is best used by applications that use orthogonal projection.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="a87b5-188"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="a87b5-188"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="a87b5-189">この例では、オブジェクトの色は、シーンの反射光の色とマテリアルの反射色を使用しています。</span><span class="sxs-lookup"><span data-stu-id="a87b5-189">In this example, the object is colored using the scene specular light color and a material specular color.</span></span>

<span data-ttu-id="a87b5-190">この方程式では、生成されるオブジェクトの頂点の色は、マテリアルの色と光の色の組み合わせになります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-190">According to the equation, the resulting color for the object vertices is a combination of the material color and the light color.</span></span>

<span data-ttu-id="a87b5-191">次の 2 つの図は、鏡面マテリアルの色 (灰色) と、反射光の色 (白) を表しています。</span><span class="sxs-lookup"><span data-stu-id="a87b5-191">The following two illustration show the specular material color, which is gray, and the specular light color, which is white.</span></span>

![灰色の球体の図](images/amb1.jpg)![白の球体の図](images/lightwhite.jpg)

<span data-ttu-id="a87b5-194">生成された反射光は、次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-194">The resulting specular highlight is shown in the following illustration.</span></span>

![反射光の図](images/lights.jpg)

<span data-ttu-id="a87b5-196">反射光に環境光と拡散光を追加すると、次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-196">Combining the specular highlight with the ambient and diffuse lighting produces the following illustration.</span></span> <span data-ttu-id="a87b5-197">これら 3 種類の光をすべて使用すると、本物のオブジェクトにより近い表現ができます。</span><span class="sxs-lookup"><span data-stu-id="a87b5-197">With all three types of lighting applied, this more clearly resembles a realistic object.</span></span>

![反射光、環境光、拡散光を組み合わせた結果の図](images/lightads.jpg)

<span data-ttu-id="a87b5-199">反射光は、拡散光よりも計算の負荷が高くなります。</span><span class="sxs-lookup"><span data-stu-id="a87b5-199">Specular lighting is more intensive to calculate than diffuse lighting.</span></span> <span data-ttu-id="a87b5-200">これは通常、表面の材質についての視覚的な手がかりを提供するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="a87b5-200">It is typically used to provide visual clues about the surface material.</span></span> <span data-ttu-id="a87b5-201">反射光は表面のマテリアルのサイズと色によって変化します。</span><span class="sxs-lookup"><span data-stu-id="a87b5-201">The specular highlight varies in size and color with the material of the surface.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="a87b5-202"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="a87b5-202"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="a87b5-203">光源の計算</span><span class="sxs-lookup"><span data-stu-id="a87b5-203">Mathematics of lighting</span></span>](mathematics-of-lighting.md)

 

 




