---
title: 環境光
description: 環境光は、シーンに一定のライティングを付加します。
ms.assetid: C34FA65A-3634-4A4B-B183-4CDA89F4DC95
keywords:
- 環境光
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 87b5c72ef99e3802a348ddfd28951bc2865891e5
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5747648"
---
# <a name="ambient-lighting"></a><span data-ttu-id="daa5c-104">環境光</span><span class="sxs-lookup"><span data-stu-id="daa5c-104">Ambient lighting</span></span>


<span data-ttu-id="daa5c-105">環境光は、シーンに一定のライティングを付加します。</span><span class="sxs-lookup"><span data-stu-id="daa5c-105">Ambient lighting provides constant lighting for a scene.</span></span> <span data-ttu-id="daa5c-106">頂点法線、光の方向、光の位置、減衰などの他の照明要素に依存していないため、すべてのオブジェクト頂点を同じように照らします。</span><span class="sxs-lookup"><span data-stu-id="daa5c-106">It lights all object vertices the same because it is not dependent on any other lighting factors such as vertex normals, light direction, light position, range, or attenuation.</span></span> <span data-ttu-id="daa5c-107">環境光は、すべての方向において一定であり、オブジェクトのすべてのピクセルが同じように色付けされます。</span><span class="sxs-lookup"><span data-stu-id="daa5c-107">Ambient lighting is constant in all directions and it colors all pixels of an object the same.</span></span> <span data-ttu-id="daa5c-108">計算は高速ですが、オブジェクトはフラットに見え、リアル感が劣ります。</span><span class="sxs-lookup"><span data-stu-id="daa5c-108">It is fast to calculate but leaves objects looking flat and unrealistic.</span></span>

<span data-ttu-id="daa5c-109">環境光は最も短時間で実現できるライティングですが、リアル感は最も劣ります。</span><span class="sxs-lookup"><span data-stu-id="daa5c-109">Ambient lighting is the fastest type of lighting but it produces the least realistic results.</span></span> <span data-ttu-id="daa5c-110">Direct3D には、ライトを作成せずに使用できる 1 つのグローバル環境光プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="daa5c-110">Direct3D contains a single global ambient light property that you can use without creating any light.</span></span> <span data-ttu-id="daa5c-111">または、任意のライト オブジェクトを設定して、環境光を実現することもできます。</span><span class="sxs-lookup"><span data-stu-id="daa5c-111">Alternatively, you can set any light object to provide ambient lighting.</span></span>

<span data-ttu-id="daa5c-112">シーンの環境光は、次の式で表されます。</span><span class="sxs-lookup"><span data-stu-id="daa5c-112">The ambient lighting for a scene is described by the following equation.</span></span>

<span data-ttu-id="daa5c-113">Ambient Lighting = Cₐ\*\[Gₐ + sum(Atten<sub>i</sub>\*Spot<sub>i</sub>\*L<sub>ai</sub>)\]</span><span class="sxs-lookup"><span data-stu-id="daa5c-113">Ambient Lighting = Cₐ\*\[Gₐ + sum(Atten<sub>i</sub>\*Spot<sub>i</sub>\*L<sub>ai</sub>)\]</span></span>

<span data-ttu-id="daa5c-114">この場合</span><span class="sxs-lookup"><span data-stu-id="daa5c-114">Where:</span></span>

| <span data-ttu-id="daa5c-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="daa5c-115">Parameter</span></span>         | <span data-ttu-id="daa5c-116">既定値</span><span class="sxs-lookup"><span data-stu-id="daa5c-116">Default value</span></span> | <span data-ttu-id="daa5c-117">種類</span><span class="sxs-lookup"><span data-stu-id="daa5c-117">Type</span></span>          | <span data-ttu-id="daa5c-118">説明</span><span class="sxs-lookup"><span data-stu-id="daa5c-118">Description</span></span>                                                                                                       |
|-------------------|---------------|---------------|-------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="daa5c-119">Cₐ</span><span class="sxs-lookup"><span data-stu-id="daa5c-119">Cₐ</span></span>                | <span data-ttu-id="daa5c-120">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="daa5c-120">(0,0,0,0)</span></span>     | <span data-ttu-id="daa5c-121">D3DCOLORVALUE</span><span class="sxs-lookup"><span data-stu-id="daa5c-121">D3DCOLORVALUE</span></span> | <span data-ttu-id="daa5c-122">マテリアルのアンビエント色</span><span class="sxs-lookup"><span data-stu-id="daa5c-122">Material ambient color</span></span>                                                                                            |
| <span data-ttu-id="daa5c-123">Gₐ</span><span class="sxs-lookup"><span data-stu-id="daa5c-123">Gₐ</span></span>                | <span data-ttu-id="daa5c-124">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="daa5c-124">(0,0,0,0)</span></span>     | <span data-ttu-id="daa5c-125">D3DCOLORVALUE</span><span class="sxs-lookup"><span data-stu-id="daa5c-125">D3DCOLORVALUE</span></span> | <span data-ttu-id="daa5c-126">グローバル アンビエント色</span><span class="sxs-lookup"><span data-stu-id="daa5c-126">Global ambient color</span></span>                                                                                              |
| <span data-ttu-id="daa5c-127">Atten<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="daa5c-127">Atten<sub>i</sub></span></span> | <span data-ttu-id="daa5c-128">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="daa5c-128">(0,0,0,0)</span></span>     | <span data-ttu-id="daa5c-129">D3DCOLORVALUE</span><span class="sxs-lookup"><span data-stu-id="daa5c-129">D3DCOLORVALUE</span></span> | <span data-ttu-id="daa5c-130">i 番目のライトの減衰。</span><span class="sxs-lookup"><span data-stu-id="daa5c-130">Light attenuation of the ith light.</span></span> <span data-ttu-id="daa5c-131">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="daa5c-131">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span> |
| <span data-ttu-id="daa5c-132">Spot<sub>i</sub></span><span class="sxs-lookup"><span data-stu-id="daa5c-132">Spot<sub>i</sub></span></span>  | <span data-ttu-id="daa5c-133">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="daa5c-133">(0,0,0,0)</span></span>     | <span data-ttu-id="daa5c-134">D3DVECTOR</span><span class="sxs-lookup"><span data-stu-id="daa5c-134">D3DVECTOR</span></span>     | <span data-ttu-id="daa5c-135">i 番目のライトのスポットライト係数。</span><span class="sxs-lookup"><span data-stu-id="daa5c-135">Spotlight factor of the ith light.</span></span> <span data-ttu-id="daa5c-136">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="daa5c-136">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span>  |
| <span data-ttu-id="daa5c-137">sum</span><span class="sxs-lookup"><span data-stu-id="daa5c-137">sum</span></span>               | <span data-ttu-id="daa5c-138">該当なし</span><span class="sxs-lookup"><span data-stu-id="daa5c-138">N/A</span></span>           | <span data-ttu-id="daa5c-139">なし</span><span class="sxs-lookup"><span data-stu-id="daa5c-139">N/A</span></span>           | <span data-ttu-id="daa5c-140">環境光の合計</span><span class="sxs-lookup"><span data-stu-id="daa5c-140">Sum of the ambient light</span></span>                                                                                          |
| <span data-ttu-id="daa5c-141">L<sub>ai</sub></span><span class="sxs-lookup"><span data-stu-id="daa5c-141">L<sub>ai</sub></span></span>    | <span data-ttu-id="daa5c-142">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="daa5c-142">(0,0,0,0)</span></span>     | <span data-ttu-id="daa5c-143">D3DVECTOR</span><span class="sxs-lookup"><span data-stu-id="daa5c-143">D3DVECTOR</span></span>     | <span data-ttu-id="daa5c-144">i 番目のライトのアンビエント色</span><span class="sxs-lookup"><span data-stu-id="daa5c-144">Light ambient color of the ith light</span></span>                                                                              |

 

<span data-ttu-id="daa5c-145">Cₐ の値は、次のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="daa5c-145">The value for Cₐ is either:</span></span>

-   <span data-ttu-id="daa5c-146">AMBIENTMATERIALSOURCE = D3DMCS\_COLOR1 で、1 つ目の頂点色が頂点の宣言で指定されている場合は、頂点色 1。</span><span class="sxs-lookup"><span data-stu-id="daa5c-146">vertex color1, if AMBIENTMATERIALSOURCE = D3DMCS\_COLOR1, and the first vertex color is supplied in the vertex declaration.</span></span>
-   <span data-ttu-id="daa5c-147">AMBIENTMATERIALSOURCE = D3DMCS\_COLOR2 で、2 つ目の頂点色が頂点の宣言で指定されている場合は、頂点色 2。</span><span class="sxs-lookup"><span data-stu-id="daa5c-147">vertex color2, if AMBIENTMATERIALSOURCE = D3DMCS\_COLOR2, and the second vertex color is supplied in vertex declaration.</span></span>
-   <span data-ttu-id="daa5c-148">マテリアルのアンビエント色。</span><span class="sxs-lookup"><span data-stu-id="daa5c-148">material ambient color.</span></span>

<span data-ttu-id="daa5c-149">**注:** どちら AMBIENTMATERIALSOURCE オプションを使用して、頂点の色が指定されていない場合マテリアルのアンビエント色を使用します。</span><span class="sxs-lookup"><span data-stu-id="daa5c-149">**Note** If either AMBIENTMATERIALSOURCE option is used, and the vertex color is not provided, then the material ambient color is used.</span></span>

 

<span data-ttu-id="daa5c-150">マテリアルのアンビエント色を使用するには、下記のコード例に示すように、SetMaterial を使用します。</span><span class="sxs-lookup"><span data-stu-id="daa5c-150">To use the material ambient color, use SetMaterial as shown in the example code below.</span></span>

<span data-ttu-id="daa5c-151">Gₐ は、グローバル アンビエント色です。</span><span class="sxs-lookup"><span data-stu-id="daa5c-151">Gₐ is the global ambient color.</span></span> <span data-ttu-id="daa5c-152">これは SetRenderState(D3DRS\_AMBIENT) を使用して設定します。</span><span class="sxs-lookup"><span data-stu-id="daa5c-152">It is set using SetRenderState(D3DRS\_AMBIENT).</span></span> <span data-ttu-id="daa5c-153">Direct3D のシーンには、グローバル アンビエント色が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="daa5c-153">There is one global ambient color in a Direct3D scene.</span></span> <span data-ttu-id="daa5c-154">このパラメーターは、Direct3D のライト オブジェクトには対応していません。</span><span class="sxs-lookup"><span data-stu-id="daa5c-154">This parameter is not associated with a Direct3D light object.</span></span>

<span data-ttu-id="daa5c-155">L<sub>ai</sub> は、シーンの i 番目のアンビエント色です。</span><span class="sxs-lookup"><span data-stu-id="daa5c-155">L<sub>ai</sub> is the ambient color of the ith light in the scene.</span></span> <span data-ttu-id="daa5c-156">各 Direct3D のライトには一連のプロパティがあり、その 1 つがアンビエント色です。</span><span class="sxs-lookup"><span data-stu-id="daa5c-156">Each Direct3D light has a set of properties, one of which is the ambient color.</span></span> <span data-ttu-id="daa5c-157">sum(L<sub>ai</sub>) の項は、シーン内のすべてのアンビエント色の合計です。</span><span class="sxs-lookup"><span data-stu-id="daa5c-157">The term, sum(L<sub>ai</sub>) is a sum of all the ambient colors in the scene.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="daa5c-158"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="daa5c-158"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="daa5c-159">この例では、シーンの環境光とマテリアルのアンビエント色を使用してオブジェクトに色を付けています。</span><span class="sxs-lookup"><span data-stu-id="daa5c-159">In this example, the object is colored using the scene ambient light and a material ambient color.</span></span>

```
#define GRAY_COLOR  0x00bfbfbf

Ambient.r = 0.75f;
Ambient.g = 0.0f;
Ambient.b = 0.0f;
Ambient.a = 0.0f;
```

<span data-ttu-id="daa5c-160">この式では、生成されるオブジェクトの頂点の色は、マテリアルの色とライトの色の組み合わせになります。</span><span class="sxs-lookup"><span data-stu-id="daa5c-160">According to the equation, the resulting color for the object vertices is a combination of the material color and the light color.</span></span>

<span data-ttu-id="daa5c-161">次の 2 つのイメージは、マテリアルの色がグレーで、ライトの色が明るい赤であることを示しています。</span><span class="sxs-lookup"><span data-stu-id="daa5c-161">The following two illustrations show the material color, which is gray, and the light color, which is bright red.</span></span>

![グレーの球体の図](images/amb1.jpg)![赤の球体の図](images/lightred.jpg)

<span data-ttu-id="daa5c-164">結果として作成されるシーンは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="daa5c-164">The resulting scene is shown in the following illustration.</span></span> <span data-ttu-id="daa5c-165">シーン内の唯一のオブジェクトは球です。</span><span class="sxs-lookup"><span data-stu-id="daa5c-165">The only object in the scene is a sphere.</span></span> <span data-ttu-id="daa5c-166">環境光は、すべてのオブジェクトの頂点を同じ色で照らします。</span><span class="sxs-lookup"><span data-stu-id="daa5c-166">Ambient light lights all object vertices with the same color.</span></span> <span data-ttu-id="daa5c-167">頂点の法線やライトの方向には依存しません。</span><span class="sxs-lookup"><span data-stu-id="daa5c-167">It is not dependent on the vertex normal or the light direction.</span></span> <span data-ttu-id="daa5c-168">その結果、オブジェクトのサーフェスの周囲にシェーディングの差が生じないため、球体は 2D の円のように見えます。</span><span class="sxs-lookup"><span data-stu-id="daa5c-168">As a result, the sphere looks like a 2D circle because there is no difference in shading around the surface of the object.</span></span>

![環境光のある球体の図](images/lighta.jpg)

<span data-ttu-id="daa5c-170">オブジェクトをよりリアルに見せるには、環境光に加えて、ディフューズ ライティングやスペキュラ ライティングを適用します。</span><span class="sxs-lookup"><span data-stu-id="daa5c-170">To give objects a more realistic look, apply diffuse or specular lighting in addition to ambient lighting.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="daa5c-171"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="daa5c-171"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="daa5c-172">光源の計算</span><span class="sxs-lookup"><span data-stu-id="daa5c-172">Mathematics of lighting</span></span>](mathematics-of-lighting.md)

 

 




