---
title: 減衰とスポットライト係数
description: 全体照明の方程式の拡散光および反射光コンポーネントには、光の減衰とスポットライト コーンを表す項が含まれています。
ms.assetid: F61D4ACB-09AB-4087-9E2D-224E472D6196
keywords:
- 減衰とスポットライト係数
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 8126ac8fa738a2b8a9680d215179fe23f77c5d44
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659297"
---
# <a name="attenuation-and-spotlight-factor"></a><span data-ttu-id="a2234-104">減衰とスポットライト係数</span><span class="sxs-lookup"><span data-stu-id="a2234-104">Attenuation and spotlight factor</span></span>


<span data-ttu-id="a2234-105">全体照明の方程式の拡散光および反射光コンポーネントには、光の減衰とスポットライト コーンを表す項が含まれています。</span><span class="sxs-lookup"><span data-stu-id="a2234-105">The diffuse and specular lighting components of the global illumination equation contain terms that describe light attenuation and the spotlight cone.</span></span> <span data-ttu-id="a2234-106">ここでは、これらの項について説明します。</span><span class="sxs-lookup"><span data-stu-id="a2234-106">These terms are described below.</span></span>

## <a name="span-idattenuationspanspan-idattenuationspanspan-idattenuationspanattenuation"></a><span data-ttu-id="a2234-107"><span id="Attenuation"></span><span id="attenuation"></span><span id="ATTENUATION"></span>減衰</span><span class="sxs-lookup"><span data-stu-id="a2234-107"><span id="Attenuation"></span><span id="attenuation"></span><span id="ATTENUATION"></span>Attenuation</span></span>


<span data-ttu-id="a2234-108">ライトの減衰は、ライトの種類、およびライトと頂点間の距離に依存します。</span><span class="sxs-lookup"><span data-stu-id="a2234-108">The attenuation of a light depends on the type of light and the distance between the light and the vertex position.</span></span> <span data-ttu-id="a2234-109">減衰を計算するには、次の式のいずれかを使用します。</span><span class="sxs-lookup"><span data-stu-id="a2234-109">To calculate attenuation, use one of the following equations.</span></span>

<span data-ttu-id="a2234-110">Atten = 1/(att0<sub>は</sub>+ att1<sub>は</sub> \* d + att2<sub>は</sub> \* d²)</span><span class="sxs-lookup"><span data-stu-id="a2234-110">Atten = 1/( att0<sub>i</sub> + att1<sub>i</sub> \* d + att2<sub>i</sub> \* d²)</span></span>

<span data-ttu-id="a2234-111">各項目の意味は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a2234-111">Where:</span></span>

| <span data-ttu-id="a2234-112">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a2234-112">Parameter</span></span>        | <span data-ttu-id="a2234-113">既定値</span><span class="sxs-lookup"><span data-stu-id="a2234-113">Default value</span></span> | <span data-ttu-id="a2234-114">種類</span><span class="sxs-lookup"><span data-stu-id="a2234-114">Type</span></span>           | <span data-ttu-id="a2234-115">説明</span><span class="sxs-lookup"><span data-stu-id="a2234-115">Description</span></span>                                     | <span data-ttu-id="a2234-116">範囲</span><span class="sxs-lookup"><span data-stu-id="a2234-116">Range</span></span>          |
|------------------|---------------|----------------|-------------------------------------------------|----------------|
| <span data-ttu-id="a2234-117">att0<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-117">att0<sub>i</sub></span></span> | <span data-ttu-id="a2234-118">0.0</span><span class="sxs-lookup"><span data-stu-id="a2234-118">0.0</span></span>           | <span data-ttu-id="a2234-119">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-119">Floating point</span></span> | <span data-ttu-id="a2234-120">一定減衰係数</span><span class="sxs-lookup"><span data-stu-id="a2234-120">Constant attenuation factor</span></span>                     | <span data-ttu-id="a2234-121">0 ～正の無限大</span><span class="sxs-lookup"><span data-stu-id="a2234-121">0 to +infinity</span></span> |
| <span data-ttu-id="a2234-122">att1<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-122">att1<sub>i</sub></span></span> | <span data-ttu-id="a2234-123">0.0</span><span class="sxs-lookup"><span data-stu-id="a2234-123">0.0</span></span>           | <span data-ttu-id="a2234-124">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-124">Floating point</span></span> | <span data-ttu-id="a2234-125">線形減衰係数</span><span class="sxs-lookup"><span data-stu-id="a2234-125">Linear attenuation factor</span></span>                       | <span data-ttu-id="a2234-126">0 ～正の無限大</span><span class="sxs-lookup"><span data-stu-id="a2234-126">0 to +infinity</span></span> |
| <span data-ttu-id="a2234-127">att2<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-127">att2<sub>i</sub></span></span> | <span data-ttu-id="a2234-128">0.0</span><span class="sxs-lookup"><span data-stu-id="a2234-128">0.0</span></span>           | <span data-ttu-id="a2234-129">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-129">Floating point</span></span> | <span data-ttu-id="a2234-130">2 次減衰係数</span><span class="sxs-lookup"><span data-stu-id="a2234-130">Quadratic attenuation factor</span></span>                    | <span data-ttu-id="a2234-131">0 ～正の無限大</span><span class="sxs-lookup"><span data-stu-id="a2234-131">0 to +infinity</span></span> |
| <span data-ttu-id="a2234-132">d</span><span class="sxs-lookup"><span data-stu-id="a2234-132">d</span></span>                | <span data-ttu-id="a2234-133">なし</span><span class="sxs-lookup"><span data-stu-id="a2234-133">N/A</span></span>           | <span data-ttu-id="a2234-134">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-134">Floating point</span></span> | <span data-ttu-id="a2234-135">頂点の位置からライトの位置までの距離</span><span class="sxs-lookup"><span data-stu-id="a2234-135">Distance from vertex position to light position</span></span> | <span data-ttu-id="a2234-136">なし</span><span class="sxs-lookup"><span data-stu-id="a2234-136">N/A</span></span>            |

 

-   <span data-ttu-id="a2234-137">Atten = 1 (指向性ライトの場合)</span><span class="sxs-lookup"><span data-stu-id="a2234-137">Atten = 1, if the light is a directional light.</span></span>
-   <span data-ttu-id="a2234-138">Atten = 0 (ライトと頂点との距離がライトの範囲を超えている場合)</span><span class="sxs-lookup"><span data-stu-id="a2234-138">Atten = 0, if the distance between the light and the vertex exceeds the light's range.</span></span>

<span data-ttu-id="a2234-139">ライトと頂点との距離は常に正の値になります。</span><span class="sxs-lookup"><span data-stu-id="a2234-139">The distance between the light and the vertex position is always positive.</span></span>

<span data-ttu-id="a2234-140">d = | L<sub>dir</sub> |</span><span class="sxs-lookup"><span data-stu-id="a2234-140">d = | L<sub>dir</sub> |</span></span>

<span data-ttu-id="a2234-141">各項目の意味は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a2234-141">Where:</span></span>

| <span data-ttu-id="a2234-142">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a2234-142">Parameter</span></span>       | <span data-ttu-id="a2234-143">既定値</span><span class="sxs-lookup"><span data-stu-id="a2234-143">Default value</span></span> | <span data-ttu-id="a2234-144">種類</span><span class="sxs-lookup"><span data-stu-id="a2234-144">Type</span></span>                                             | <span data-ttu-id="a2234-145">説明</span><span class="sxs-lookup"><span data-stu-id="a2234-145">Description</span></span>                                                 |
|-----------------|---------------|--------------------------------------------------|-------------------------------------------------------------|
| <span data-ttu-id="a2234-146">L<sub>dir</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-146">L<sub>dir</sub></span></span> | <span data-ttu-id="a2234-147">なし</span><span class="sxs-lookup"><span data-stu-id="a2234-147">N/A</span></span>           | <span data-ttu-id="a2234-148">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a2234-148">3D vector with x, y, and z floating-point values</span></span> | <span data-ttu-id="a2234-149">頂点の位置からライトの位置への方向ベクトル</span><span class="sxs-lookup"><span data-stu-id="a2234-149">Direction vector from vertex position to the light position</span></span> |

 

<span data-ttu-id="a2234-150">d がライトの範囲を超えると、Direct3D はそれ以上減衰を計算せず、ライトから頂点へのエフェクトも適用しなくなります。</span><span class="sxs-lookup"><span data-stu-id="a2234-150">If d is greater than the light's range, Direct3D makes no further attenuation calculations and applies no effects from the light to the vertex.</span></span>

<span data-ttu-id="a2234-151">減衰定数は、式の中では係数として機能します。これらに簡単な調整を加えることで、さまざまな減衰カーブを生成できます。</span><span class="sxs-lookup"><span data-stu-id="a2234-151">The attenuation constants act as coefficients in the formula - you can produce a variety of attenuation curves by making simple adjustments to them.</span></span> <span data-ttu-id="a2234-152">Attenuation1 を 1.0 に設定すると、範囲によって制限されたまま、減衰しないライトを作成できます。いろいろな値を試して、さまざまな減衰エフェクトを生成してください。</span><span class="sxs-lookup"><span data-stu-id="a2234-152">You can set Attenuation1 to 1.0 to create a light that doesn't attenuate but is still limited by range, or you can experiment with different values to achieve various attenuation effects.</span></span>

<span data-ttu-id="a2234-153">ライトの最大範囲における減衰は、0.0 ではありません。</span><span class="sxs-lookup"><span data-stu-id="a2234-153">The attenuation at the maximum range of the light is not 0.0.</span></span> <span data-ttu-id="a2234-154">ライトがライトの範囲内になったときに突然表示されるのを防ぐために、アプリケーションでライトの範囲を増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="a2234-154">To prevent lights from suddenly appearing when they are at the light range, an application can increase the light range.</span></span> <span data-ttu-id="a2234-155">また、ライトの範囲で減衰係数が 0.0 に近づくように、アプリケーションで減衰定数を設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="a2234-155">Or, the application can set up attenuation constants so that the attenuation factor is close to 0.0 at the light range.</span></span> <span data-ttu-id="a2234-156">減衰値をライトの色の赤、緑、および青の成分で乗算することにより、ライトの強度は、ライトが頂点まで移動する距離の係数として増減されます。</span><span class="sxs-lookup"><span data-stu-id="a2234-156">The attenuation value is multiplied by the red, green, and blue components of the light's color to scale the light's intensity as a factor of the distance light travels to a vertex.</span></span>

## <a name="span-idspotlight-factorspanspan-idspotlight-factorspanspan-idspotlight-factorspanspotlight-factor"></a><span data-ttu-id="a2234-157"><span id="Spotlight-Factor"></span><span id="spotlight-factor"></span><span id="SPOTLIGHT-FACTOR"></span>スポット ライト要素</span><span class="sxs-lookup"><span data-stu-id="a2234-157"><span id="Spotlight-Factor"></span><span id="spotlight-factor"></span><span id="SPOTLIGHT-FACTOR"></span>Spotlight Factor</span></span>


<span data-ttu-id="a2234-158">次の式は、スポット ライト係数を指定します。</span><span class="sxs-lookup"><span data-stu-id="a2234-158">The following equation specifies the spotlight factor.</span></span>

![スポットライト係数の式](images/dx8light9.png)

| <span data-ttu-id="a2234-160">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a2234-160">Parameter</span></span>         | <span data-ttu-id="a2234-161">既定値</span><span class="sxs-lookup"><span data-stu-id="a2234-161">Default value</span></span> | <span data-ttu-id="a2234-162">種類</span><span class="sxs-lookup"><span data-stu-id="a2234-162">Type</span></span>           | <span data-ttu-id="a2234-163">説明</span><span class="sxs-lookup"><span data-stu-id="a2234-163">Description</span></span>                              | <span data-ttu-id="a2234-164">範囲</span><span class="sxs-lookup"><span data-stu-id="a2234-164">Range</span></span>                    |
|-------------------|---------------|----------------|------------------------------------------|--------------------------|
| <span data-ttu-id="a2234-165">rho<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-165">rho<sub>i</sub></span></span>   | <span data-ttu-id="a2234-166">なし</span><span class="sxs-lookup"><span data-stu-id="a2234-166">N/A</span></span>           | <span data-ttu-id="a2234-167">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-167">Floating point</span></span> | <span data-ttu-id="a2234-168">スポットライト i のコサイン (角度)</span><span class="sxs-lookup"><span data-stu-id="a2234-168">cosine(angle) for spotlight i</span></span>            | <span data-ttu-id="a2234-169">なし</span><span class="sxs-lookup"><span data-stu-id="a2234-169">N/A</span></span>                      |
| <span data-ttu-id="a2234-170">phi<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-170">phi<sub>i</sub></span></span>   | <span data-ttu-id="a2234-171">0.0</span><span class="sxs-lookup"><span data-stu-id="a2234-171">0.0</span></span>           | <span data-ttu-id="a2234-172">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-172">Floating point</span></span> | <span data-ttu-id="a2234-173">スポットライトの半影の角度 (ラジアン)</span><span class="sxs-lookup"><span data-stu-id="a2234-173">Penumbra angle of spotlight i in radians</span></span> | <span data-ttu-id="a2234-174">\[シータ<sub>は</sub>pi)</span><span class="sxs-lookup"><span data-stu-id="a2234-174">\[theta<sub>i</sub>, pi)</span></span> |
| <span data-ttu-id="a2234-175">theta<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-175">theta<sub>i</sub></span></span> | <span data-ttu-id="a2234-176">0.0</span><span class="sxs-lookup"><span data-stu-id="a2234-176">0.0</span></span>           | <span data-ttu-id="a2234-177">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-177">Floating point</span></span> | <span data-ttu-id="a2234-178">スポットライトの本影の角度 (ラジアン)</span><span class="sxs-lookup"><span data-stu-id="a2234-178">Umbra angle of spotlight i in radians</span></span>    | <span data-ttu-id="a2234-179">\[0 の場合、円周率)</span><span class="sxs-lookup"><span data-stu-id="a2234-179">\[0, pi)</span></span>                 |
| <span data-ttu-id="a2234-180">falloff</span><span class="sxs-lookup"><span data-stu-id="a2234-180">falloff</span></span>           | <span data-ttu-id="a2234-181">0.0</span><span class="sxs-lookup"><span data-stu-id="a2234-181">0.0</span></span>           | <span data-ttu-id="a2234-182">浮動小数点</span><span class="sxs-lookup"><span data-stu-id="a2234-182">Floating point</span></span> | <span data-ttu-id="a2234-183">減衰係数</span><span class="sxs-lookup"><span data-stu-id="a2234-183">Falloff factor</span></span>                           | <span data-ttu-id="a2234-184">(-infinity, +infinity)</span><span class="sxs-lookup"><span data-stu-id="a2234-184">(-infinity, +infinity)</span></span>   |

 

<span data-ttu-id="a2234-185">各項目の意味は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a2234-185">Where:</span></span>

<span data-ttu-id="a2234-186">rho = norm(L<sub>dcs</sub>)<sup>.</sup>norm(L<sub>dir</sub>)</span><span class="sxs-lookup"><span data-stu-id="a2234-186">rho = norm(L<sub>dcs</sub>)<sup>.</sup>norm(L<sub>dir</sub>)</span></span>

<span data-ttu-id="a2234-187">パラメーターは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a2234-187">and:</span></span>

| <span data-ttu-id="a2234-188">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a2234-188">Parameter</span></span>       | <span data-ttu-id="a2234-189">既定値</span><span class="sxs-lookup"><span data-stu-id="a2234-189">Default value</span></span> | <span data-ttu-id="a2234-190">種類</span><span class="sxs-lookup"><span data-stu-id="a2234-190">Type</span></span>                                             | <span data-ttu-id="a2234-191">説明</span><span class="sxs-lookup"><span data-stu-id="a2234-191">Description</span></span>                                                 |
|-----------------|---------------|--------------------------------------------------|-------------------------------------------------------------|
| <span data-ttu-id="a2234-192">L<sub>dcs</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-192">L<sub>dcs</sub></span></span> | <span data-ttu-id="a2234-193">なし</span><span class="sxs-lookup"><span data-stu-id="a2234-193">N/A</span></span>           | <span data-ttu-id="a2234-194">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a2234-194">3D vector with x, y, and z floating-point values</span></span> | <span data-ttu-id="a2234-195">カメラ空間でのライトの負の方向</span><span class="sxs-lookup"><span data-stu-id="a2234-195">The negative of the light direction in camera space</span></span>         |
| <span data-ttu-id="a2234-196">L<sub>dir</sub></span><span class="sxs-lookup"><span data-stu-id="a2234-196">L<sub>dir</sub></span></span> | <span data-ttu-id="a2234-197">なし</span><span class="sxs-lookup"><span data-stu-id="a2234-197">N/A</span></span>           | <span data-ttu-id="a2234-198">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="a2234-198">3D vector with x, y, and z floating-point values</span></span> | <span data-ttu-id="a2234-199">頂点の位置からライトの位置への方向ベクトル</span><span class="sxs-lookup"><span data-stu-id="a2234-199">Direction vector from vertex position to the light position</span></span> |

 

<span data-ttu-id="a2234-200">ライトの減衰を計算した後、Direct3D は、スポットライトのエフェクト (適用可能な場合)、サーフェスからのライトの反射角度、および現在のマテリアルの反射率も考慮して、頂点のディフューズ成分とスペキュラ成分を計算します。</span><span class="sxs-lookup"><span data-stu-id="a2234-200">After computing the light attenuation, to calculate the diffuse and specular components for the vertex, Direct3D also considers spotlight effects if applicable, the angle that the light reflects from a surface, and the reflectance of the current material.</span></span> <span data-ttu-id="a2234-201">詳しくは、「[ライトの種類](light-types.md)」の「スポットライト」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a2234-201">In [Light types](light-types.md), see "Spotlight".</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="a2234-202"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="a2234-202"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="a2234-203">照明の計算</span><span class="sxs-lookup"><span data-stu-id="a2234-203">Mathematics of lighting</span></span>](mathematics-of-lighting.md)

 

 




