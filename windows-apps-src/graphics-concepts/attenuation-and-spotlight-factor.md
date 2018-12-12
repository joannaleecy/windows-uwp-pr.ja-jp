---
title: 減衰とスポットライト係数
description: グローバル照明の計算式に含まれるディフューズ ライティングとスペキュラ ライティングの成分には、ライトの減衰とスポットライト コーンを記述する項があります。
ms.assetid: F61D4ACB-09AB-4087-9E2D-224E472D6196
keywords:
- 減衰とスポットライト係数
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 8126ac8fa738a2b8a9680d215179fe23f77c5d44
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8937846"
---
# <a name="attenuation-and-spotlight-factor"></a><span data-ttu-id="09b4f-104">減衰とスポットライト係数</span><span class="sxs-lookup"><span data-stu-id="09b4f-104">Attenuation and spotlight factor</span></span>


<span data-ttu-id="09b4f-105">グローバル照明の計算式に含まれるディフューズ ライティングとスペキュラ ライティングの成分には、ライトの減衰とスポットライト コーンを記述する項があります。</span><span class="sxs-lookup"><span data-stu-id="09b4f-105">The diffuse and specular lighting components of the global illumination equation contain terms that describe light attenuation and the spotlight cone.</span></span> <span data-ttu-id="09b4f-106">ここでは、これらの項について説明します。</span><span class="sxs-lookup"><span data-stu-id="09b4f-106">These terms are described below.</span></span>

## <a name="span-idattenuationspanspan-idattenuationspanspan-idattenuationspanattenuation"></a><span data-ttu-id="09b4f-107"><span id="Attenuation"></span><span id="attenuation"></span><span id="ATTENUATION"></span>減衰</span><span class="sxs-lookup"><span data-stu-id="09b4f-107"><span id="Attenuation"></span><span id="attenuation"></span><span id="ATTENUATION"></span>Attenuation</span></span>


<span data-ttu-id="09b4f-108">ライトの減衰は、ライトの種類、およびライトと頂点間の距離に依存します。</span><span class="sxs-lookup"><span data-stu-id="09b4f-108">The attenuation of a light depends on the type of light and the distance between the light and the vertex position.</span></span> <span data-ttu-id="09b4f-109">減衰を計算するには、次の式のいずれかを使用します。</span><span class="sxs-lookup"><span data-stu-id="09b4f-109">To calculate attenuation, use one of the following equations.</span></span>

<span data-ttu-id="09b4f-110">Atten = 1/( att0<sub>i</sub> + att1<sub>i</sub> \* d + att2<sub>i</sub> \* d²)</span><span class="sxs-lookup"><span data-stu-id="09b4f-110">Atten = 1/( att0<sub>i</sub> + att1<sub>i</sub> \* d + att2<sub>i</sub> \* d²)</span></span>

<span data-ttu-id="09b4f-111">この場合</span><span class="sxs-lookup"><span data-stu-id="09b4f-111">Where:</span></span>

| <span data-ttu-id="09b4f-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09b4f-112">Parameter</span></span>        | <span data-ttu-id="09b4f-113">既定値</span><span class="sxs-lookup"><span data-stu-id="09b4f-113">Default value</span></span> | <span data-ttu-id="09b4f-114">種類</span><span class="sxs-lookup"><span data-stu-id="09b4f-114">Type</span></span>           | <span data-ttu-id="09b4f-115">説明</span><span class="sxs-lookup"><span data-stu-id="09b4f-115">Description</span></span>                                     | <span data-ttu-id="09b4f-116">範囲</span><span class="sxs-lookup"><span data-stu-id="09b4f-116">Range</span></span>          |
|------------------|---------------|----------------|-------------------------------------------------|----------------|
| <span data-ttu-id="09b4f-117">att0<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-117">att0<sub>i</sub></span></span> | <span data-ttu-id="09b4f-118">0.0</span><span class="sxs-lookup"><span data-stu-id="09b4f-118">0.0</span></span>           | <span data-ttu-id="09b4f-119">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-119">Floating point</span></span> | <span data-ttu-id="09b4f-120">一定減衰係数</span><span class="sxs-lookup"><span data-stu-id="09b4f-120">Constant attenuation factor</span></span>                     | <span data-ttu-id="09b4f-121">0 ～正の無限大</span><span class="sxs-lookup"><span data-stu-id="09b4f-121">0 to +infinity</span></span> |
| <span data-ttu-id="09b4f-122">att1<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-122">att1<sub>i</sub></span></span> | <span data-ttu-id="09b4f-123">0.0</span><span class="sxs-lookup"><span data-stu-id="09b4f-123">0.0</span></span>           | <span data-ttu-id="09b4f-124">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-124">Floating point</span></span> | <span data-ttu-id="09b4f-125">線形減衰係数</span><span class="sxs-lookup"><span data-stu-id="09b4f-125">Linear attenuation factor</span></span>                       | <span data-ttu-id="09b4f-126">0 ～正の無限大</span><span class="sxs-lookup"><span data-stu-id="09b4f-126">0 to +infinity</span></span> |
| <span data-ttu-id="09b4f-127">att2<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-127">att2<sub>i</sub></span></span> | <span data-ttu-id="09b4f-128">0.0</span><span class="sxs-lookup"><span data-stu-id="09b4f-128">0.0</span></span>           | <span data-ttu-id="09b4f-129">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-129">Floating point</span></span> | <span data-ttu-id="09b4f-130">2 次減衰係数</span><span class="sxs-lookup"><span data-stu-id="09b4f-130">Quadratic attenuation factor</span></span>                    | <span data-ttu-id="09b4f-131">0 ～正の無限大</span><span class="sxs-lookup"><span data-stu-id="09b4f-131">0 to +infinity</span></span> |
| <span data-ttu-id="09b4f-132">d</span><span class="sxs-lookup"><span data-stu-id="09b4f-132">d</span></span>                | <span data-ttu-id="09b4f-133">なし</span><span class="sxs-lookup"><span data-stu-id="09b4f-133">N/A</span></span>           | <span data-ttu-id="09b4f-134">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-134">Floating point</span></span> | <span data-ttu-id="09b4f-135">頂点の位置からライトの位置までの距離</span><span class="sxs-lookup"><span data-stu-id="09b4f-135">Distance from vertex position to light position</span></span> | <span data-ttu-id="09b4f-136">なし</span><span class="sxs-lookup"><span data-stu-id="09b4f-136">N/A</span></span>            |

 

-   <span data-ttu-id="09b4f-137">Atten = 1 (指向性ライトの場合)</span><span class="sxs-lookup"><span data-stu-id="09b4f-137">Atten = 1, if the light is a directional light.</span></span>
-   <span data-ttu-id="09b4f-138">Atten = 0 (ライトと頂点との距離がライトの範囲を超えている場合)</span><span class="sxs-lookup"><span data-stu-id="09b4f-138">Atten = 0, if the distance between the light and the vertex exceeds the light's range.</span></span>

<span data-ttu-id="09b4f-139">ライトと頂点との距離は常に正の値になります。</span><span class="sxs-lookup"><span data-stu-id="09b4f-139">The distance between the light and the vertex position is always positive.</span></span>

<span data-ttu-id="09b4f-140">d = |L<sub>dir</sub> |</span><span class="sxs-lookup"><span data-stu-id="09b4f-140">d = | L<sub>dir</sub> |</span></span>

<span data-ttu-id="09b4f-141">この場合</span><span class="sxs-lookup"><span data-stu-id="09b4f-141">Where:</span></span>

| <span data-ttu-id="09b4f-142">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09b4f-142">Parameter</span></span>       | <span data-ttu-id="09b4f-143">既定値</span><span class="sxs-lookup"><span data-stu-id="09b4f-143">Default value</span></span> | <span data-ttu-id="09b4f-144">種類</span><span class="sxs-lookup"><span data-stu-id="09b4f-144">Type</span></span>                                             | <span data-ttu-id="09b4f-145">説明</span><span class="sxs-lookup"><span data-stu-id="09b4f-145">Description</span></span>                                                 |
|-----------------|---------------|--------------------------------------------------|-------------------------------------------------------------|
| <span data-ttu-id="09b4f-146">L<sub>dir</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-146">L<sub>dir</sub></span></span> | <span data-ttu-id="09b4f-147">なし</span><span class="sxs-lookup"><span data-stu-id="09b4f-147">N/A</span></span>           | <span data-ttu-id="09b4f-148">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="09b4f-148">3D vector with x, y, and z floating-point values</span></span> | <span data-ttu-id="09b4f-149">頂点の位置からライトの位置への方向ベクトル</span><span class="sxs-lookup"><span data-stu-id="09b4f-149">Direction vector from vertex position to the light position</span></span> |

 

<span data-ttu-id="09b4f-150">d がライトの範囲を超えると、Direct3D はそれ以上減衰を計算せず、ライトから頂点へのエフェクトも適用しなくなります。</span><span class="sxs-lookup"><span data-stu-id="09b4f-150">If d is greater than the light's range, Direct3D makes no further attenuation calculations and applies no effects from the light to the vertex.</span></span>

<span data-ttu-id="09b4f-151">減衰定数は、式の中では係数として機能します。これらに簡単な調整を加えることで、さまざまな減衰カーブを生成できます。</span><span class="sxs-lookup"><span data-stu-id="09b4f-151">The attenuation constants act as coefficients in the formula - you can produce a variety of attenuation curves by making simple adjustments to them.</span></span> <span data-ttu-id="09b4f-152">Attenuation1 を 1.0 に設定すると、範囲によって制限されたまま、減衰しないライトを作成できます。いろいろな値を試して、さまざまな減衰エフェクトを生成してください。</span><span class="sxs-lookup"><span data-stu-id="09b4f-152">You can set Attenuation1 to 1.0 to create a light that doesn't attenuate but is still limited by range, or you can experiment with different values to achieve various attenuation effects.</span></span>

<span data-ttu-id="09b4f-153">ライトの最大範囲における減衰は、0.0 ではありません。</span><span class="sxs-lookup"><span data-stu-id="09b4f-153">The attenuation at the maximum range of the light is not 0.0.</span></span> <span data-ttu-id="09b4f-154">ライトがライトの範囲内になったときに突然表示されるのを防ぐために、アプリケーションでライトの範囲を増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="09b4f-154">To prevent lights from suddenly appearing when they are at the light range, an application can increase the light range.</span></span> <span data-ttu-id="09b4f-155">また、ライトの範囲で減衰係数が 0.0 に近づくように、アプリケーションで減衰定数を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="09b4f-155">Or, the application can set up attenuation constants so that the attenuation factor is close to 0.0 at the light range.</span></span> <span data-ttu-id="09b4f-156">減衰値をライトの色の赤、緑、および青の成分で乗算することにより、ライトの強度は、ライトが頂点まで移動する距離の係数として増減されます。</span><span class="sxs-lookup"><span data-stu-id="09b4f-156">The attenuation value is multiplied by the red, green, and blue components of the light's color to scale the light's intensity as a factor of the distance light travels to a vertex.</span></span>

## <a name="span-idspotlight-factorspanspan-idspotlight-factorspanspan-idspotlight-factorspanspotlight-factor"></a><span data-ttu-id="09b4f-157"><span id="Spotlight-Factor"></span><span id="spotlight-factor"></span><span id="SPOTLIGHT-FACTOR"></span>スポットライト係数</span><span class="sxs-lookup"><span data-stu-id="09b4f-157"><span id="Spotlight-Factor"></span><span id="spotlight-factor"></span><span id="SPOTLIGHT-FACTOR"></span>Spotlight Factor</span></span>


<span data-ttu-id="09b4f-158">次の式は、スポット ライト係数を指定します。</span><span class="sxs-lookup"><span data-stu-id="09b4f-158">The following equation specifies the spotlight factor.</span></span>

![スポットライト係数の式](images/dx8light9.png)

| <span data-ttu-id="09b4f-160">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09b4f-160">Parameter</span></span>         | <span data-ttu-id="09b4f-161">既定値</span><span class="sxs-lookup"><span data-stu-id="09b4f-161">Default value</span></span> | <span data-ttu-id="09b4f-162">種類</span><span class="sxs-lookup"><span data-stu-id="09b4f-162">Type</span></span>           | <span data-ttu-id="09b4f-163">説明</span><span class="sxs-lookup"><span data-stu-id="09b4f-163">Description</span></span>                              | <span data-ttu-id="09b4f-164">範囲</span><span class="sxs-lookup"><span data-stu-id="09b4f-164">Range</span></span>                    |
|-------------------|---------------|----------------|------------------------------------------|--------------------------|
| <span data-ttu-id="09b4f-165">rho<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-165">rho<sub>i</sub></span></span>   | <span data-ttu-id="09b4f-166">なし</span><span class="sxs-lookup"><span data-stu-id="09b4f-166">N/A</span></span>           | <span data-ttu-id="09b4f-167">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-167">Floating point</span></span> | <span data-ttu-id="09b4f-168">スポットライト i のコサイン (角度)</span><span class="sxs-lookup"><span data-stu-id="09b4f-168">cosine(angle) for spotlight i</span></span>            | <span data-ttu-id="09b4f-169">なし</span><span class="sxs-lookup"><span data-stu-id="09b4f-169">N/A</span></span>                      |
| <span data-ttu-id="09b4f-170">phi<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-170">phi<sub>i</sub></span></span>   | <span data-ttu-id="09b4f-171">0.0</span><span class="sxs-lookup"><span data-stu-id="09b4f-171">0.0</span></span>           | <span data-ttu-id="09b4f-172">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-172">Floating point</span></span> | <span data-ttu-id="09b4f-173">スポットライトの半影の角度 (ラジアン)</span><span class="sxs-lookup"><span data-stu-id="09b4f-173">Penumbra angle of spotlight i in radians</span></span> | <span data-ttu-id="09b4f-174">\[theta<sub>i</sub>, pi)</span><span class="sxs-lookup"><span data-stu-id="09b4f-174">\[theta<sub>i</sub>, pi)</span></span> |
| <span data-ttu-id="09b4f-175">theta<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-175">theta<sub>i</sub></span></span> | <span data-ttu-id="09b4f-176">0.0</span><span class="sxs-lookup"><span data-stu-id="09b4f-176">0.0</span></span>           | <span data-ttu-id="09b4f-177">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-177">Floating point</span></span> | <span data-ttu-id="09b4f-178">スポットライトの本影の角度 (ラジアン)</span><span class="sxs-lookup"><span data-stu-id="09b4f-178">Umbra angle of spotlight i in radians</span></span>    | <span data-ttu-id="09b4f-179">\[0, pi)</span><span class="sxs-lookup"><span data-stu-id="09b4f-179">\[0, pi)</span></span>                 |
| <span data-ttu-id="09b4f-180">falloff</span><span class="sxs-lookup"><span data-stu-id="09b4f-180">falloff</span></span>           | <span data-ttu-id="09b4f-181">0.0</span><span class="sxs-lookup"><span data-stu-id="09b4f-181">0.0</span></span>           | <span data-ttu-id="09b4f-182">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="09b4f-182">Floating point</span></span> | <span data-ttu-id="09b4f-183">減衰係数</span><span class="sxs-lookup"><span data-stu-id="09b4f-183">Falloff factor</span></span>                           | <span data-ttu-id="09b4f-184">(-infinity, +infinity)</span><span class="sxs-lookup"><span data-stu-id="09b4f-184">(-infinity, +infinity)</span></span>   |

 

<span data-ttu-id="09b4f-185">この場合</span><span class="sxs-lookup"><span data-stu-id="09b4f-185">Where:</span></span>

<span data-ttu-id="09b4f-186">rho = norm(L<sub>dcs</sub>)<sup>.</sup>norm(L<sub>dir</sub>)</span><span class="sxs-lookup"><span data-stu-id="09b4f-186">rho = norm(L<sub>dcs</sub>)<sup>.</sup>norm(L<sub>dir</sub>)</span></span>

<span data-ttu-id="09b4f-187">パラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="09b4f-187">and:</span></span>

| <span data-ttu-id="09b4f-188">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09b4f-188">Parameter</span></span>       | <span data-ttu-id="09b4f-189">既定値</span><span class="sxs-lookup"><span data-stu-id="09b4f-189">Default value</span></span> | <span data-ttu-id="09b4f-190">種類</span><span class="sxs-lookup"><span data-stu-id="09b4f-190">Type</span></span>                                             | <span data-ttu-id="09b4f-191">説明</span><span class="sxs-lookup"><span data-stu-id="09b4f-191">Description</span></span>                                                 |
|-----------------|---------------|--------------------------------------------------|-------------------------------------------------------------|
| <span data-ttu-id="09b4f-192">L<sub>dcs</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-192">L<sub>dcs</sub></span></span> | <span data-ttu-id="09b4f-193">なし</span><span class="sxs-lookup"><span data-stu-id="09b4f-193">N/A</span></span>           | <span data-ttu-id="09b4f-194">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="09b4f-194">3D vector with x, y, and z floating-point values</span></span> | <span data-ttu-id="09b4f-195">カメラ空間でのライトの負の方向</span><span class="sxs-lookup"><span data-stu-id="09b4f-195">The negative of the light direction in camera space</span></span>         |
| <span data-ttu-id="09b4f-196">L<sub>dir</sub></span><span class="sxs-lookup"><span data-stu-id="09b4f-196">L<sub>dir</sub></span></span> | <span data-ttu-id="09b4f-197">なし</span><span class="sxs-lookup"><span data-stu-id="09b4f-197">N/A</span></span>           | <span data-ttu-id="09b4f-198">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="09b4f-198">3D vector with x, y, and z floating-point values</span></span> | <span data-ttu-id="09b4f-199">頂点の位置からライトの位置への方向ベクトル</span><span class="sxs-lookup"><span data-stu-id="09b4f-199">Direction vector from vertex position to the light position</span></span> |

 

<span data-ttu-id="09b4f-200">ライトの減衰を計算した後、Direct3D は、スポットライトのエフェクト (適用可能な場合)、サーフェスからのライトの反射角度、および現在のマテリアルの反射率も考慮して、頂点のディフューズ成分とスペキュラ成分を計算します。</span><span class="sxs-lookup"><span data-stu-id="09b4f-200">After computing the light attenuation, to calculate the diffuse and specular components for the vertex, Direct3D also considers spotlight effects if applicable, the angle that the light reflects from a surface, and the reflectance of the current material.</span></span> <span data-ttu-id="09b4f-201">詳しくは、「[ライトの種類](light-types.md)」の「スポットライト」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="09b4f-201">In [Light types](light-types.md), see "Spotlight".</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="09b4f-202"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="09b4f-202"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="09b4f-203">光源の計算</span><span class="sxs-lookup"><span data-stu-id="09b4f-203">Mathematics of lighting</span></span>](mathematics-of-lighting.md)

 

 




