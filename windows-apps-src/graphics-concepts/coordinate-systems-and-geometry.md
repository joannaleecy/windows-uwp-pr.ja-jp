---
title: 座標系とジオメトリ
description: Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。 このセクションでは、3D シーンを作成するための最も重要な幾何学的概念について説明します。
ms.assetid: E82EB0A9-0678-496B-96B3-8993BA580099
keywords:
- 座標系とジオメトリ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 962002d635c3e6edbf1f9581a4cbc57fbd5b1d96
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646297"
---
# <a name="coordinate-systems-and-geometry"></a><span data-ttu-id="10f9b-105">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="10f9b-105">Coordinate systems and geometry</span></span>


<span data-ttu-id="10f9b-106">Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。</span><span class="sxs-lookup"><span data-stu-id="10f9b-106">Programming Direct3D applications requires a working familiarity with 3D geometric principles.</span></span> <span data-ttu-id="10f9b-107">このセクションでは、3D シーンを作成するための最も重要な幾何学的概念について説明します。</span><span class="sxs-lookup"><span data-stu-id="10f9b-107">This section introduces the most important geometric concepts for creating 3D scenes.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="10f9b-108"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="10f9b-108"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="10f9b-109">トピック</span><span class="sxs-lookup"><span data-stu-id="10f9b-109">Topic</span></span></th>
<th align="left"><span data-ttu-id="10f9b-110">説明</span><span class="sxs-lookup"><span data-stu-id="10f9b-110">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="10f9b-111"><a href="coordinate-systems.md">座標系</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-111"><a href="coordinate-systems.md">Coordinate systems</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-112">通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。</span><span class="sxs-lookup"><span data-stu-id="10f9b-112">Typically 3D graphics applications use one of two types of Cartesian coordinate systems: left-handed or right-handed.</span></span> <span data-ttu-id="10f9b-113">いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。</span><span class="sxs-lookup"><span data-stu-id="10f9b-113">In both coordinate systems, the positive x-axis points to the right, and the positive y-axis points up.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="10f9b-114"><a href="primitives.md">プリミティブ</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-114"><a href="primitives.md">Primitives</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-115">3D <em>プリミティブ</em>は、単一の 3D エンティティを形成する頂点の集合です。</span><span class="sxs-lookup"><span data-stu-id="10f9b-115">A 3D <em>primitive</em> is a collection of vertices that form a single 3D entity.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="10f9b-116"><a href="face-and-vertex-normal-vectors.md">顔と頂点の法線ベクトル</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-116"><a href="face-and-vertex-normal-vectors.md">Face and vertex normal vectors</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-117">メッシュ内の各面には、垂直な単位法線ベクトルがあります。</span><span class="sxs-lookup"><span data-stu-id="10f9b-117">Each face in a mesh has a perpendicular unit normal vector.</span></span> <span data-ttu-id="10f9b-118">ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。</span><span class="sxs-lookup"><span data-stu-id="10f9b-118">The vector's direction is determined by the order in which the vertices are defined and by whether the coordinate system is right- or left-handed.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="10f9b-119"><a href="rectangles.md">四角形</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-119"><a href="rectangles.md">Rectangles</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-120">Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。</span><span class="sxs-lookup"><span data-stu-id="10f9b-120">Throughout Direct3D and Windows programming, objects on the screen are referred to in terms of bounding rectangles.</span></span> <span data-ttu-id="10f9b-121">境界矩形のサイドは、常に画面のサイドと平行になっています。そのため、矩形は左上隅と右下隅の 2 つのポイントで描画されます。</span><span class="sxs-lookup"><span data-stu-id="10f9b-121">The sides of a bounding rectangle are always parallel to the sides of the screen, so the rectangle can be described by two points, the upper-left corner and lower-right corner.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="10f9b-122"><a href="triangle-interpolation.md">三角形に補間</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-122"><a href="triangle-interpolation.md">Triangle interpolation</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-123">レンダリング中、パイプラインは各三角形で頂点データを補間します。</span><span class="sxs-lookup"><span data-stu-id="10f9b-123">During rendering, the pipeline interpolates vertex data across each triangle.</span></span> <span data-ttu-id="10f9b-124">頂点データにはさまざまなデータがあり、拡散色、反射色、拡散色アルファ (三角形の不透明度)、反射色アルファ、フォグ係数などを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="10f9b-124">Vertex data can be a broad variety of data and can include (but is not limited to): diffuse color, specular color, diffuse alpha (triangle opacity), specular alpha, and a fog factor.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="10f9b-125"><a href="vectors--vertices--and-quaternions.md">ベクトル、頂点、および四元数</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-125"><a href="vectors--vertices--and-quaternions.md">Vectors, vertices, and quaternions</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-126">Direct3D では、頂点は位置と方向を表します。</span><span class="sxs-lookup"><span data-stu-id="10f9b-126">Throughout Direct3D, vertices describe position and orientation.</span></span> <span data-ttu-id="10f9b-127">プリミティブの各頂点は、位置を決定するベクトル、色、テクスチャ座標、および方向を決定する法線ベクトルによって示されます。</span><span class="sxs-lookup"><span data-stu-id="10f9b-127">Each vertex in a primitive is described by a vector that gives its position, color, texture coordinates, and a normal vector that gives its orientation.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="10f9b-128"><a href="transforms.md">変換</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-128"><a href="transforms.md">Transforms</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-129">Direct3D の機能の一部で、ジオメトリを固定機能ジオメトリ パイプラインに挿入する変換エンジンです。</span><span class="sxs-lookup"><span data-stu-id="10f9b-129">The part of Direct3D that pushes geometry through the fixed function geometry pipeline is the transform engine.</span></span> <span data-ttu-id="10f9b-130">変換エンジンは、モデルとビューアーをワールド座標に配置し、画面表示のために頂点を投影し、ビューポートに頂点をクリッピングします。</span><span class="sxs-lookup"><span data-stu-id="10f9b-130">It locates the model and viewer in the world, projects vertices for display on the screen, and clips vertices to the viewport.</span></span> <span data-ttu-id="10f9b-131">さらに変換エンジンは照明計算を実行し、各頂点における拡散成分および鏡面成分を決定します。</span><span class="sxs-lookup"><span data-stu-id="10f9b-131">The transform engine also performs lighting computations to determine diffuse and specular components at each vertex.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="10f9b-132"><a href="viewports-and-clipping.md">ビューポートとクリッピング</a></span><span class="sxs-lookup"><span data-stu-id="10f9b-132"><a href="viewports-and-clipping.md">Viewports and clipping</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="10f9b-133">"<em>ビューポート</em>" とは、3D シーンが投影される 2 次元 (2D) の矩形です。</span><span class="sxs-lookup"><span data-stu-id="10f9b-133">A <em>viewport</em> is a two-dimensional (2D) rectangle into which a 3D scene is projected.</span></span> <span data-ttu-id="10f9b-134">Direct3D では、この四角形は Direct3D サーフェス内の座標として存在し、システムによってレンダー ターゲットとして使われます。</span><span class="sxs-lookup"><span data-stu-id="10f9b-134">In Direct3D, the rectangle exists as coordinates within a Direct3D surface that the system uses as a rendering target.</span></span> <span data-ttu-id="10f9b-135">射影変換は、頂点をビューポートで使われる座標系に変換します。</span><span class="sxs-lookup"><span data-stu-id="10f9b-135">The projection transformation converts vertices into the coordinate system used for the viewport.</span></span> <span data-ttu-id="10f9b-136">ビューポートは、シーンがレンダリングされるレンダー ターゲット サーフェス上の深度値の範囲 (通常は 0.0 ～ 1.0) を指定するためにも使われます。</span><span class="sxs-lookup"><span data-stu-id="10f9b-136">A viewport is also used to specify the range of depth values on a render-target surface into which a scene will be rendered (usually 0.0 to 1.0).</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="10f9b-137"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="10f9b-137"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="10f9b-138">Direct3D グラフィックス学習ガイド</span><span class="sxs-lookup"><span data-stu-id="10f9b-138">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




