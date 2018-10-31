---
title: 光源の計算
description: Direct3D の照明モデルは、環境光、拡散光、反射光、放射光を扱います。 これにより、さまざまな照明の状況に十分対応することができます。 シーン内の照明の合計量は、全体照明と呼ばれます。
ms.assetid: D0521F56-050D-4EDF-9BD1-34748E94B873
keywords:
- 光源の計算
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 19734964c9b4ab087f7d5fd6ea749b57cccce26c
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5832421"
---
# <a name="mathematics-of-lighting"></a><span data-ttu-id="2d21e-106">光源の計算</span><span class="sxs-lookup"><span data-stu-id="2d21e-106">Mathematics of lighting</span></span>


<span data-ttu-id="2d21e-107">Direct3D の照明モデルは、環境光、拡散光、反射光、放射光を扱います。</span><span class="sxs-lookup"><span data-stu-id="2d21e-107">The Direct3D Light Model covers ambient, diffuse, specular, and emissive lighting.</span></span> <span data-ttu-id="2d21e-108">これにより、さまざまな照明の状況に十分対応することができます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-108">This is enough flexibility to solve a wide range of lighting situations.</span></span> <span data-ttu-id="2d21e-109">シーン内の照明の合計量は、*全体照明*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-109">The total amount of light in a scene is called the *global illumination*.</span></span>

<span data-ttu-id="2d21e-110">全体照明は次のように計算されます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-110">The global illumination is computed as follows:</span></span>

```
Global Illumination = Ambient Light + Diffuse Light + Specular Light + Emissive Light 
```

<span data-ttu-id="2d21e-111">[環境光](ambient-lighting.md)は一定の照明です。</span><span class="sxs-lookup"><span data-stu-id="2d21e-111">[Ambient lighting](ambient-lighting.md) is constant lighting.</span></span> <span data-ttu-id="2d21e-112">環境光は、すべての方向において一定であり、オブジェクトのすべてのピクセルが同じように色付けされます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-112">Ambient lighting is constant in all directions and it colors all pixels of an object the same.</span></span> <span data-ttu-id="2d21e-113">すぐに計算されますが、オブジェクトは平面的で非現実的なままです。</span><span class="sxs-lookup"><span data-stu-id="2d21e-113">It is fast to calculate but leaves objects looking flat and unrealistic.</span></span>

<span data-ttu-id="2d21e-114">[拡散光](diffuse-lighting.md)は、光の方向とオブジェクト サーフェスの法線の両方によって決まります。</span><span class="sxs-lookup"><span data-stu-id="2d21e-114">[Diffuse lighting](diffuse-lighting.md) depends on both the light direction and the object surface normal.</span></span> <span data-ttu-id="2d21e-115">光の方向を変更し、サーフェスの法線ベクトルを変更すると、拡散光がオブジェクトのサーフェス上で変化します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-115">Diffuse lighting varies across the surface of an object as a result of the changing light direction and the changing surface numeral vector.</span></span> <span data-ttu-id="2d21e-116">オブジェクト頂点ごとに変化するため、拡散光の方が計算に時間がかかりますが、オブジェクトに陰影が付き、3 次元 (3D) の奥行きが出るというメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="2d21e-116">It takes longer to calculate diffuse lighting because it changes for each object vertex, however the benefit of using it is that it shades objects and gives them three-dimensional (3D) depth.</span></span>

<span data-ttu-id="2d21e-117">[反射光](specular-lighting.md)では、光がオブジェクトの表面に当たり、カメラに向かって反射する明るい反射光を指定します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-117">[Specular lighting](specular-lighting.md) identifies the bright specular highlights that occur when light hits an object surface and reflects back toward the camera.</span></span> <span data-ttu-id="2d21e-118">反射光は拡散光よりも強い光で、オブジェクトの表面から短時間で消えます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-118">Specular lighting is more intense than diffuse light and falls off more rapidly across the object surface.</span></span> <span data-ttu-id="2d21e-119">反射光の方が拡散光よりも計算に時間がかかりますが、反射光を使用すると、表面の表現力が格段に向上します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-119">It takes longer to calculate specular lighting than diffuse lighting, however the benefit of using it is that it adds significant detail to a surface.</span></span>

<span data-ttu-id="2d21e-120">[放射光](emissive-lighting.md)は、オブジェクトにより放射される光 (輝きなど) です。</span><span class="sxs-lookup"><span data-stu-id="2d21e-120">[Emissive lighting](emissive-lighting.md) is light that is emitted by an object; for example, a glow.</span></span> <span data-ttu-id="2d21e-121">放射によって、レンダリングされるオブジェクトが自己発光しているように見えます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-121">Emission makes a rendered object appear to be self-luminous.</span></span> <span data-ttu-id="2d21e-122">放射は、オブジェクトの色に影響を与え、たとえば、暗い素材を明るくしたり、放射される色の一部を引き受けたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-122">Emission affects an object's color and can, for example, make a dark material brighter and take on part of the emitted color.</span></span>

<span data-ttu-id="2d21e-123">現実的な光は、これらの種類の光をそれぞれ 3D シーンに適用することによって実現できます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-123">Realistic lighting can be accomplished by applying each of these types of lighting to a 3D scene.</span></span> <span data-ttu-id="2d21e-124">環境、放射、および拡散コンポーネントに計算される値は、拡散頂点の色として出力されます。鏡面反射コンポーネントの値は、反射頂点の色として出力されます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-124">The values calculated for ambient, emissive, and diffuse components are output as the diffuse vertex color; the value for the specular lighting component is output as the specular vertex color.</span></span> <span data-ttu-id="2d21e-125">環境光、拡散光、反射光の値は、特定の光の減衰とスポットライト要素の影響を受けます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-125">Ambient, diffuse, and specular light values can be affected by a given light's attenuation and spotlight factor.</span></span> <span data-ttu-id="2d21e-126">「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2d21e-126">See [Attenuation and spotlight factor](attenuation-and-spotlight-factor.md).</span></span>

<span data-ttu-id="2d21e-127">より現実的な照明効果を出すため、多くの照明を追加できますが、シーンのレンダリングに時間がかかります。</span><span class="sxs-lookup"><span data-stu-id="2d21e-127">To achieve a more realistic lighting effect, you add more lights; however, the scene takes longer to render.</span></span> <span data-ttu-id="2d21e-128">デザイナーが望むすべての効果を出すため、一部のゲームでは一般に使われているより多くの CPU 能力を使っています。</span><span class="sxs-lookup"><span data-stu-id="2d21e-128">To achieve all the effects a designer wants, some games use more CPU power than is commonly available.</span></span> <span data-ttu-id="2d21e-129">この場合、テクスチャ マップを使うと同時に照明マップと環境マップを使ってシーンに照明を追加することにより、照明計算の数を最小限に減らすのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="2d21e-129">In this case, it is typical to reduce the number of lighting calculations to a minimum by using lighting maps and environment maps to add lighting to a scene while using texture maps.</span></span>

<span data-ttu-id="2d21e-130">照明は、カメラ空間で計算されます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-130">Lighting is computed in the camera space.</span></span> <span data-ttu-id="2d21e-131">「[カメラの空間変換](camera-space-transformations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2d21e-131">See [Camera space transformations](camera-space-transformations.md).</span></span> <span data-ttu-id="2d21e-132">法線ベクトルが既に正規化されていて、頂点ブレンドが必要なく、変換マトリックスが直角であるという特殊な条件が存在する場合、最適化された照明をモデル空間で計算できます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-132">Optimized lighting can be computed in model space, when special conditions exist: normal vectors are already normalized, vertex blending is not needed, and transformation matrices are orthogonal.</span></span>

<span data-ttu-id="2d21e-133">すべての照明計算は、ワールド マトリックスの逆数を使って、カメラ位置と共に光源の位置と方向をモデル空間に変換することにより、モデル空間で行われます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-133">All lighting computations are made in model space by transforming the light source's position and direction, along with the camera position, to model space using the inverse of the world matrix.</span></span> <span data-ttu-id="2d21e-134">そのため、ワールド マトリックスとビュー マトリックスに不均一なスケーリングが導入されている場合、結果として生じる照明が不正確になることがあります。</span><span class="sxs-lookup"><span data-stu-id="2d21e-134">As a result, if the world or view matrices introduce non-uniform scaling, the resultant lighting might be inaccurate.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="2d21e-135"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="2d21e-135"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="2d21e-136">トピック</span><span class="sxs-lookup"><span data-stu-id="2d21e-136">Topic</span></span></th>
<th align="left"><span data-ttu-id="2d21e-137">説明</span><span class="sxs-lookup"><span data-stu-id="2d21e-137">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="ambient-lighting.md"><span data-ttu-id="2d21e-138">環境光</span><span class="sxs-lookup"><span data-stu-id="2d21e-138">Ambient lighting</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="2d21e-139">環境光は、シーンに一定のライティングを付加します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-139">Ambient lighting provides constant lighting for a scene.</span></span> <span data-ttu-id="2d21e-140">頂点法線、光の方向、光の位置、減衰などの他の照明要素に依存していないため、すべてのオブジェクト頂点を同じように照らします。</span><span class="sxs-lookup"><span data-stu-id="2d21e-140">It lights all object vertices the same because it is not dependent on any other lighting factors such as vertex normals, light direction, light position, range, or attenuation.</span></span> <span data-ttu-id="2d21e-141">環境光は、すべての方向において一定であり、オブジェクトのすべてのピクセルが同じように色付けされます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-141">Ambient lighting is constant in all directions and it colors all pixels of an object the same.</span></span> <span data-ttu-id="2d21e-142">すぐに計算されますが、オブジェクトは平面的で非現実的なままです。</span><span class="sxs-lookup"><span data-stu-id="2d21e-142">It is fast to calculate but leaves objects looking flat and unrealistic.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="diffuse-lighting.md"><span data-ttu-id="2d21e-143">拡散光</span><span class="sxs-lookup"><span data-stu-id="2d21e-143">Diffuse lighting</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="2d21e-144"><em>拡散光</em>は、ライトの方向とオブジェクトのサーフェス法線の両方に依存します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-144"><em>Diffuse lighting</em> depends on both the light direction and the object surface normal.</span></span> <span data-ttu-id="2d21e-145">光の方向を変更し、サーフェスの法線ベクトルを変更すると、拡散光がオブジェクトのサーフェス上で変化します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-145">Diffuse lighting varies across the surface of an object as a result of the changing light direction and the changing surface numeral vector.</span></span> <span data-ttu-id="2d21e-146">オブジェクト頂点ごとに変化するため、拡散光の方が計算に時間がかかりますが、オブジェクトに陰影が付き、3 次元 (3D) の奥行きが出るというメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="2d21e-146">It takes longer to calculate diffuse lighting because it changes for each object vertex, however the benefit of using it is that it shades objects and gives them three-dimensional (3D) depth.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="specular-lighting.md"><span data-ttu-id="2d21e-147">反射光</span><span class="sxs-lookup"><span data-stu-id="2d21e-147">Specular lighting</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="2d21e-148"><em>反射光</em>では、光がオブジェクトの表面に当たり、カメラに向かって反射する明るい反射光を指定します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-148"><em>Specular lighting</em> identifies the bright specular highlights that occur when light hits an object surface and reflects back toward the camera.</span></span> <span data-ttu-id="2d21e-149">反射光は拡散光よりも強い光で、オブジェクトの表面から短時間で消えます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-149">Specular lighting is more intense than diffuse light and falls off more rapidly across the object surface.</span></span> <span data-ttu-id="2d21e-150">反射光の方が拡散光よりも計算に時間がかかりますが、反射光を使用すると、表面の表現力が格段に向上します。</span><span class="sxs-lookup"><span data-stu-id="2d21e-150">It takes longer to calculate specular lighting than diffuse lighting, however the benefit of using it is that it adds significant detail to a surface.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="emissive-lighting.md"><span data-ttu-id="2d21e-151">放射光</span><span class="sxs-lookup"><span data-stu-id="2d21e-151">Emissive lighting</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="2d21e-152"><em>放射光</em>は、白熱光などオブジェクトによって放射される光です。</span><span class="sxs-lookup"><span data-stu-id="2d21e-152"><em>Emissive lighting</em> is light that is emitted by an object; for example, a glow.</span></span> <span data-ttu-id="2d21e-153">放射によって、レンダリングされるオブジェクトが自己発光しているように見えます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-153">Emission makes a rendered object appear to be self-luminous.</span></span> <span data-ttu-id="2d21e-154">放射は、オブジェクトの色に影響を与え、たとえば、暗い素材を明るくしたり、放射される色の一部を引き受けたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-154">Emission affects an object's color and can, for example, make a dark material brighter and take on part of the emitted color.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="camera-space-transformations.md"><span data-ttu-id="2d21e-155">カメラの空間変換</span><span class="sxs-lookup"><span data-stu-id="2d21e-155">Camera space transformations</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="2d21e-156">カメラ空間内の頂点は、ワールド ビュー マトリックスによってオブジェクト頂点を変換することにより計算されます。</span><span class="sxs-lookup"><span data-stu-id="2d21e-156">Vertices in the camera space are computed by transforming the object vertices with the world view matrix.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="attenuation-and-spotlight-factor.md"><span data-ttu-id="2d21e-157">減衰とスポットライトの要素</span><span class="sxs-lookup"><span data-stu-id="2d21e-157">Attenuation and spotlight factor</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="2d21e-158">全体照明の方程式の拡散光および反射光コンポーネントには、光の減衰とスポットライト コーンを表す項が含まれています。</span><span class="sxs-lookup"><span data-stu-id="2d21e-158">The diffuse and specular lighting components of the global illumination equation contain terms that describe light attenuation and the spotlight cone.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="2d21e-159"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="2d21e-159"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="2d21e-160">照明および素材</span><span class="sxs-lookup"><span data-stu-id="2d21e-160">Lights and materials</span></span>](lights-and-materials.md)

 

 




