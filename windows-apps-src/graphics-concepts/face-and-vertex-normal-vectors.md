---
title: 面と頂点の法線ベクトル
description: メッシュ内の各面には、垂直な単位法線ベクトルがあります。 ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。
ms.assetid: 02333579-9749-4612-B121-23F97898A3E0
keywords:
- 面と頂点の法線ベクトル
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 2081e8c09a6f6fd75f460af3f339902bcb80bac6
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5871259"
---
# <a name="face-and-vertex-normal-vectors"></a><span data-ttu-id="eb688-105">面と頂点の法線ベクトル</span><span class="sxs-lookup"><span data-stu-id="eb688-105">Face and vertex normal vectors</span></span>


<span data-ttu-id="eb688-106">メッシュ内の各面には、垂直な単位法線ベクトルがあります。</span><span class="sxs-lookup"><span data-stu-id="eb688-106">Each face in a mesh has a perpendicular unit normal vector.</span></span> <span data-ttu-id="eb688-107">ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。</span><span class="sxs-lookup"><span data-stu-id="eb688-107">The vector's direction is determined by the order in which the vertices are defined and by whether the coordinate system is right- or left-handed.</span></span>

## <a name="span-idperpendicularunitnormalvectorforafrontfacespanspan-idperpendicularunitnormalvectorforafrontfacespanspan-idperpendicularunitnormalvectorforafrontfacespanperpendicular-unit-normal-vector-for-a-front-face"></a><span data-ttu-id="eb688-108"><span id="Perpendicular_unit_normal_vector_for_a_front_face"></span><span id="perpendicular_unit_normal_vector_for_a_front_face"></span><span id="PERPENDICULAR_UNIT_NORMAL_VECTOR_FOR_A_FRONT_FACE"></span>前面対して垂直な単位法線ベクトル</span><span class="sxs-lookup"><span data-stu-id="eb688-108"><span id="Perpendicular_unit_normal_vector_for_a_front_face"></span><span id="perpendicular_unit_normal_vector_for_a_front_face"></span><span id="PERPENDICULAR_UNIT_NORMAL_VECTOR_FOR_A_FRONT_FACE"></span>Perpendicular unit normal vector for a front face</span></span>


<span data-ttu-id="eb688-109">メッシュ内の各面には、垂直な単位法線ベクトルがあります。</span><span class="sxs-lookup"><span data-stu-id="eb688-109">Each face in a mesh has a perpendicular unit normal vector.</span></span> <span data-ttu-id="eb688-110">ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。</span><span class="sxs-lookup"><span data-stu-id="eb688-110">The vector's direction is determined by the order in which the vertices are defined and by whether the coordinate system is right- or left-handed.</span></span> <span data-ttu-id="eb688-111">面の法線の向きは面の前面から離れる方向です。</span><span class="sxs-lookup"><span data-stu-id="eb688-111">The face normal points away from the front side of the face.</span></span> <span data-ttu-id="eb688-112">Direct3D では、面の前面のみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="eb688-112">In Direct3D, only the front of a face is visible.</span></span> <span data-ttu-id="eb688-113">前面は、頂点が時計回りの順序で定義されている面です。</span><span class="sxs-lookup"><span data-stu-id="eb688-113">A front face is one in which vertices are defined in clockwise order.</span></span>

<span data-ttu-id="eb688-114">次の図は、前面の法線ベクトルを示しています。</span><span class="sxs-lookup"><span data-stu-id="eb688-114">The following illustration shows a normal vector for a front face:</span></span>

![前面の法線ベクトル](images/nrmlvect.png)

## <a name="span-idcullingbackfacesspanspan-idcullingbackfacesspanspan-idcullingbackfacesspanculling-back-faces"></a><span data-ttu-id="eb688-116"><span id="Culling_back_faces"></span><span id="culling_back_faces"></span><span id="CULLING_BACK_FACES"></span>背面のカリング</span><span class="sxs-lookup"><span data-stu-id="eb688-116"><span id="Culling_back_faces"></span><span id="culling_back_faces"></span><span id="CULLING_BACK_FACES"></span>Culling back faces</span></span>


<span data-ttu-id="eb688-117">前面ではない面はすべて背面です。</span><span class="sxs-lookup"><span data-stu-id="eb688-117">Any face that is not a front face is a back face.</span></span> <span data-ttu-id="eb688-118">Direct3D では、背面は常にレンダリングされるわけではありません。これを、背面がカリングされているといいます。</span><span class="sxs-lookup"><span data-stu-id="eb688-118">Direct3D does not always render back faces; back faces are said to be culled.</span></span> <span data-ttu-id="eb688-119">背面のカリングは、背面がレンダリングされなくなることを意味します。</span><span class="sxs-lookup"><span data-stu-id="eb688-119">Back face culling means eliminating back faces from rendering.</span></span> <span data-ttu-id="eb688-120">必要に応じて、カリング モードを変更し、背面をレンダリングすることもできます。</span><span class="sxs-lookup"><span data-stu-id="eb688-120">You can change the culling mode to render back faces if you want.</span></span> <span data-ttu-id="eb688-121">詳細については、「[カリング ステート](https://msdn.microsoft.com/library/windows/desktop/bb204882)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="eb688-121">See [Culling State](https://msdn.microsoft.com/library/windows/desktop/bb204882) for more information.</span></span>

## <a name="span-idvertexunitnormalsspanspan-idvertexunitnormalsspanspan-idvertexunitnormalsspanvertex-unit-normals"></a><span data-ttu-id="eb688-122"><span id="Vertex_unit_normals"></span><span id="vertex_unit_normals"></span><span id="VERTEX_UNIT_NORMALS"></span>頂点の単位法線</span><span class="sxs-lookup"><span data-stu-id="eb688-122"><span id="Vertex_unit_normals"></span><span id="vertex_unit_normals"></span><span id="VERTEX_UNIT_NORMALS"></span>Vertex unit normals</span></span>


<span data-ttu-id="eb688-123">Direct3D では、グーロー シェーディング、光源、テクスチャの効果に頂点の単位法線を使用します。</span><span class="sxs-lookup"><span data-stu-id="eb688-123">Direct3D uses the vertex unit normals for Gouraud shading, lighting, and texturing effects.</span></span>

<span data-ttu-id="eb688-124">次の図は、頂点法線を示しています。</span><span class="sxs-lookup"><span data-stu-id="eb688-124">The following illustration shows vertex normals:</span></span>

![頂点法線](images/vertnrml.png)

<span data-ttu-id="eb688-126">グーロー シェーディングを多角形に適用するとき、Direct3D では、頂点法線を使用して光源とサーフェスの間の角度が計算されます。</span><span class="sxs-lookup"><span data-stu-id="eb688-126">When applying Gouraud shading to a polygon, Direct3D uses the vertex normals to calculate the angle between the light source and the surface.</span></span> <span data-ttu-id="eb688-127">頂点の色と明るさの値が計算され、プリミティブのすべてのサーフェスで、すべてのポイントが補間されます。</span><span class="sxs-lookup"><span data-stu-id="eb688-127">It calculates the color and intensity values for the vertices and interpolates them for every point across all the primitive's surfaces.</span></span> <span data-ttu-id="eb688-128">Direct3D では、角度を使用して光の強さを計算します。</span><span class="sxs-lookup"><span data-stu-id="eb688-128">Direct3D calculates the light intensity value by using the angle.</span></span> <span data-ttu-id="eb688-129">角度が大きいほど、サーフェスでの光の輝きは少なくなります。</span><span class="sxs-lookup"><span data-stu-id="eb688-129">The greater the angle, the less light is shining on the surface.</span></span>

## <a name="span-idflatsurfacesspanspan-idflatsurfacesspanspan-idflatsurfacesspanflat-surfaces"></a><span data-ttu-id="eb688-130"><span id="Flat_surfaces"></span><span id="flat_surfaces"></span><span id="FLAT_SURFACES"></span>平坦なサーフェス</span><span class="sxs-lookup"><span data-stu-id="eb688-130"><span id="Flat_surfaces"></span><span id="flat_surfaces"></span><span id="FLAT_SURFACES"></span>Flat surfaces</span></span>


<span data-ttu-id="eb688-131">平坦なオブジェクトを作成している場合は、サーフェスに対して垂線になるように頂点法線を設定します。</span><span class="sxs-lookup"><span data-stu-id="eb688-131">If you are creating an object that is flat, set the vertex normals to point perpendicular to the surface.</span></span>

<span data-ttu-id="eb688-132">次の図は、頂点法線と 2 つの三角形から成る平坦なサーフェスを示しています。</span><span class="sxs-lookup"><span data-stu-id="eb688-132">The following illustration shows a flat surface composed of two triangles with vertex normals:</span></span>

![頂点法線と 2 つの三角形から成る平坦なサーフェス](images/flatvert.png)

## <a name="span-idsmoothshadingonanon-flatobjectspanspan-idsmoothshadingonanon-flatobjectspanspan-idsmoothshadingonanon-flatobjectspansmooth-shading-on-a-non-flat-object"></a><span data-ttu-id="eb688-134"><span id="Smooth_shading_on_a_non-flat_object"></span><span id="smooth_shading_on_a_non-flat_object"></span><span id="SMOOTH_SHADING_ON_A_NON-FLAT_OBJECT"></span>平坦ではないオブジェクト上のスムーズ シェーディング</span><span class="sxs-lookup"><span data-stu-id="eb688-134"><span id="Smooth_shading_on_a_non-flat_object"></span><span id="smooth_shading_on_a_non-flat_object"></span><span id="SMOOTH_SHADING_ON_A_NON-FLAT_OBJECT"></span>Smooth shading on a non-flat object</span></span>


<span data-ttu-id="eb688-135">オブジェクトは、平坦なオブジェクトではなく、三角形ストリップで構成されており、三角形が同一平面上にないことがほとんどです。</span><span class="sxs-lookup"><span data-stu-id="eb688-135">Rather than flat object, it is more likely that your object is made up of triangle strips and the triangles are not coplanar.</span></span> <span data-ttu-id="eb688-136">ストリップ内のすべての三角形でスムーズ シェーディングを実現するための最も簡単な方法の 1 つは、まず頂点が関連付けられている多角形の面ごとにサーフェスの法線ベクトルを計算することです。</span><span class="sxs-lookup"><span data-stu-id="eb688-136">One simple way to achieve smooth shading across all the triangles in the strip is to first calculate the surface normal vector for each polygonal face with which the vertex is associated.</span></span> <span data-ttu-id="eb688-137">頂点法線は、各サーフェスの法線と等しい角度になるように設定できます。</span><span class="sxs-lookup"><span data-stu-id="eb688-137">The vertex normal can be set to make an equal angle with each surface normal.</span></span> <span data-ttu-id="eb688-138">ただし、この方法は、複雑なプリミティブには十分に効率的でないことがあります。</span><span class="sxs-lookup"><span data-stu-id="eb688-138">However, this method might not be efficient enough for complex primitives.</span></span>

<span data-ttu-id="eb688-139">この方法を次の図で説明します。この図は、上方から横向きに見た 2 つのサーフェス S1 および S2 を示しています。</span><span class="sxs-lookup"><span data-stu-id="eb688-139">This method is illustrated by the following diagram, which shows two surfaces, S1 and S2 seen edge-on from above.</span></span> <span data-ttu-id="eb688-140">S1 および S2 の法線ベクトルは青色で示されています。</span><span class="sxs-lookup"><span data-stu-id="eb688-140">The normal vectors for S1 and S2 are shown in blue.</span></span> <span data-ttu-id="eb688-141">頂点法線ベクトルは赤色で示されています。</span><span class="sxs-lookup"><span data-stu-id="eb688-141">The vertex normal vector is shown in red.</span></span> <span data-ttu-id="eb688-142">頂点法線ベクトルが S1 のサーフェス法線となす角度は、頂点法線と S2 のサーフェス法線との間の角度と同じです。</span><span class="sxs-lookup"><span data-stu-id="eb688-142">The angle that the vertex normal vector makes with the surface normal of S1 is the same as the angle between the vertex normal and the surface normal of S2.</span></span> <span data-ttu-id="eb688-143">これらの 2 つのサーフェスが、光で照らされ、グーロー シェーディングでシェーディングされると、結果として、これらのサーフェスの間のエッジは、滑らかにシェーディングされ、滑らかに丸みの付いたものになります。</span><span class="sxs-lookup"><span data-stu-id="eb688-143">When these two surfaces are lit and shaded with Gouraud shading, the result is a smoothly shaded, smoothly rounded edge between them.</span></span>

<span data-ttu-id="eb688-144">次の図は、2 つのサーフェス (S1 と S2) とその法線ベクトルおよび頂点法線ベクトルを示しています。</span><span class="sxs-lookup"><span data-stu-id="eb688-144">The following illustration shows two surfaces (S1 and S2) and their normal vectors and vertex normal vector:</span></span>

![2 つのサーフェス (s1 と s2) とその法線ベクトルおよび頂点法線ベクトル](images/gvert.png)

<span data-ttu-id="eb688-146">頂点法線が、関連付けられた面のうちの 1 つに向かって傾いている場合、光の強度は、頂点法線が光源となす角度に応じて、そのサーフェス上の点に対して増加または減少します。</span><span class="sxs-lookup"><span data-stu-id="eb688-146">If the vertex normal leans toward one of the faces with which it is associated, it causes the light intensity to increase or decrease for points on that surface, depending on the angle it makes with the light source.</span></span> <span data-ttu-id="eb688-147">次の図に例を示します。</span><span class="sxs-lookup"><span data-stu-id="eb688-147">The following diagram shows an example.</span></span> <span data-ttu-id="eb688-148">これらのサーフェスは横向きに見たものです。</span><span class="sxs-lookup"><span data-stu-id="eb688-148">These surfaces are seen edge-on.</span></span> <span data-ttu-id="eb688-149">頂点法線は S1 に向かって傾いており、頂点法線と各サーフェス法線との角度が等しい場合と比べて、光源との角度は小さくなっています。</span><span class="sxs-lookup"><span data-stu-id="eb688-149">The vertex normal leans toward S1, causing it to have a smaller angle with the light source than if the vertex normal had equal angles with the surface normals.</span></span>

<span data-ttu-id="eb688-150">次の図は、1 つの面に向かって傾いた頂点法線ベクトルを持つ 2 つのサーフェス (S1 と S2) を示しています。</span><span class="sxs-lookup"><span data-stu-id="eb688-150">The following illustration shows two surfaces (S1 and S2) with a vertex normal vector that leans toward one face:</span></span>

![1 つの面に向かって傾いた頂点法線ベクトルを持つ 2 つのサーフェス (s1 と s2)](images/gvert2.png)

## <a name="span-idsharpedgesspanspan-idsharpedgesspanspan-idsharpedgesspansharp-edges"></a><span data-ttu-id="eb688-152"><span id="Sharp_edges"></span><span id="sharp_edges"></span><span id="SHARP_EDGES"></span>鋭いエッジ</span><span class="sxs-lookup"><span data-stu-id="eb688-152"><span id="Sharp_edges"></span><span id="sharp_edges"></span><span id="SHARP_EDGES"></span>Sharp edges</span></span>


<span data-ttu-id="eb688-153">グーロー シェーディングを使用すると、3D シーンで鋭いエッジを持つオブジェクトを表示できます。</span><span class="sxs-lookup"><span data-stu-id="eb688-153">You can use Gouraud shading to display some objects in a 3D scene with sharp edges.</span></span> <span data-ttu-id="eb688-154">そのためには、鋭いエッジが必要な面の交線で頂点法線ベクトルを重複させます。</span><span class="sxs-lookup"><span data-stu-id="eb688-154">To do so, duplicate the vertex normal vectors at any intersection of faces where a sharp edge is required.</span></span>

<span data-ttu-id="eb688-155">次の図に、鋭いエッジで重複している頂点法線ベクトルを示します。</span><span class="sxs-lookup"><span data-stu-id="eb688-155">The following illustration shows duplicated vertex normal vectors at sharp edges:</span></span>

![鋭いエッジで重複している頂点法線ベクトル](images/shade1.png)

<span data-ttu-id="eb688-157">DrawPrimitive メソッドを使用してシーンをレンダリングする場合、鋭いエッジを持つオブジェクトは、三角形ストリップではなく三角形リストとして定義します。</span><span class="sxs-lookup"><span data-stu-id="eb688-157">If you use the DrawPrimitive methods to render your scene, define the object with sharp edges as a triangle list, rather than a triangle strip.</span></span> <span data-ttu-id="eb688-158">三角形ストリップとしてオブジェクトを定義すると、Direct3D では、複数の三角形面から成る単一の多角形として処理されます。</span><span class="sxs-lookup"><span data-stu-id="eb688-158">When you define an object as a triangle strip, Direct3D treats it as a single polygon composed of multiple triangular faces.</span></span> <span data-ttu-id="eb688-159">グーロー シェーディングは、多角形の各面全体と、隣接する面の間の両方に適用されます。</span><span class="sxs-lookup"><span data-stu-id="eb688-159">Gouraud shading is applied both across each face of the polygon and between adjacent faces.</span></span>

<span data-ttu-id="eb688-160">結果として、オブジェクトは面から面へと滑らかにシェーディングされます。</span><span class="sxs-lookup"><span data-stu-id="eb688-160">The result is an object that is smoothly shaded from face to face.</span></span> <span data-ttu-id="eb688-161">三角形リストは一連の結合されていない三角形面から成る多角形であるため、Direct3D では、多角形の各面にグーロー シェーディングが適用されます。</span><span class="sxs-lookup"><span data-stu-id="eb688-161">Because a triangle list is a polygon composed of a series of disjoint triangular faces, Direct3D applies Gouraud shading across each face of the polygon.</span></span> <span data-ttu-id="eb688-162">ただし、面と面の間には適用されません。</span><span class="sxs-lookup"><span data-stu-id="eb688-162">However, it is not applied from face to face.</span></span> <span data-ttu-id="eb688-163">三角形リストの 2 つ以上の三角形が隣接している場合、それらの間には鋭いエッジがあるように見えます。</span><span class="sxs-lookup"><span data-stu-id="eb688-163">If two or more triangles of a triangle list are adjacent, they appear to have a sharp edge between them.</span></span>

<span data-ttu-id="eb688-164">別の方法としては、鋭いエッジを持つオブジェクトをレンダリングする場合は、フラット シェーディングに変更することです。</span><span class="sxs-lookup"><span data-stu-id="eb688-164">Another alternative is to change to flat shading when rendering objects with sharp edges.</span></span> <span data-ttu-id="eb688-165">これは、計算上は最も効率的な方法ですが、シーンのオブジェクトは、グーロー シェーディングされたオブジェクトのようにはリアルにレンダリングされないことがあります。</span><span class="sxs-lookup"><span data-stu-id="eb688-165">This is computationally the most efficient method, but it may result in objects in the scene that are not rendered as realistically as the objects that are Gouraud-shaded.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="eb688-166"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="eb688-166"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="eb688-167">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="eb688-167">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




