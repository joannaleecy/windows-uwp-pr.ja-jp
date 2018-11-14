---
title: 座標系とジオメトリ
description: Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。 ここでは、3D シーンを作成するための最も重要なジオメトリの概念について説明します。
ms.assetid: E82EB0A9-0678-496B-96B3-8993BA580099
keywords:
- 座標系とジオメトリ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ce3b1ebfc2f18a06ff4fa960c91749f61f5011d9
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6258701"
---
# <a name="coordinate-systems-and-geometry"></a><span data-ttu-id="84947-105">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="84947-105">Coordinate systems and geometry</span></span>


<span data-ttu-id="84947-106">Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。</span><span class="sxs-lookup"><span data-stu-id="84947-106">Programming Direct3D applications requires a working familiarity with 3D geometric principles.</span></span> <span data-ttu-id="84947-107">ここでは、3D シーンを作成するための最も重要なジオメトリの概念について説明します。</span><span class="sxs-lookup"><span data-stu-id="84947-107">This section introduces the most important geometric concepts for creating 3D scenes.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="84947-108"><span id="in-this-section"></span>説明するトピックは、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="84947-108"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="84947-109">トピック</span><span class="sxs-lookup"><span data-stu-id="84947-109">Topic</span></span></th>
<th align="left"><span data-ttu-id="84947-110">説明</span><span class="sxs-lookup"><span data-stu-id="84947-110">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="coordinate-systems.md"><span data-ttu-id="84947-111">座標系</span><span class="sxs-lookup"><span data-stu-id="84947-111">Coordinate systems</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-112">通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。</span><span class="sxs-lookup"><span data-stu-id="84947-112">Typically 3D graphics applications use one of two types of Cartesian coordinate systems: left-handed or right-handed.</span></span> <span data-ttu-id="84947-113">いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。</span><span class="sxs-lookup"><span data-stu-id="84947-113">In both coordinate systems, the positive x-axis points to the right, and the positive y-axis points up.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="primitives.md"><span data-ttu-id="84947-114">プリミティブ</span><span class="sxs-lookup"><span data-stu-id="84947-114">Primitives</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-115">3D <em>プリミティブ</em>は、単一の 3D エンティティを形成する頂点の集合です。</span><span class="sxs-lookup"><span data-stu-id="84947-115">A 3D <em>primitive</em> is a collection of vertices that form a single 3D entity.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="face-and-vertex-normal-vectors.md"><span data-ttu-id="84947-116">面および頂点法線ベクトル</span><span class="sxs-lookup"><span data-stu-id="84947-116">Face and vertex normal vectors</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-117">メッシュ内の各面には、垂直な単位法線ベクトルがあります。</span><span class="sxs-lookup"><span data-stu-id="84947-117">Each face in a mesh has a perpendicular unit normal vector.</span></span> <span data-ttu-id="84947-118">ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。</span><span class="sxs-lookup"><span data-stu-id="84947-118">The vector's direction is determined by the order in which the vertices are defined and by whether the coordinate system is right- or left-handed.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="rectangles.md"><span data-ttu-id="84947-119">矩形</span><span class="sxs-lookup"><span data-stu-id="84947-119">Rectangles</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-120">Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。</span><span class="sxs-lookup"><span data-stu-id="84947-120">Throughout Direct3D and Windows programming, objects on the screen are referred to in terms of bounding rectangles.</span></span> <span data-ttu-id="84947-121">境界矩形のサイドは、常に画面のサイドと平行になっています。そのため、矩形は左上隅と右下隅の 2 つのポイントで描画されます。</span><span class="sxs-lookup"><span data-stu-id="84947-121">The sides of a bounding rectangle are always parallel to the sides of the screen, so the rectangle can be described by two points, the upper-left corner and lower-right corner.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="triangle-interpolation.md"><span data-ttu-id="84947-122">三角形の補間</span><span class="sxs-lookup"><span data-stu-id="84947-122">Triangle interpolation</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-123">レンダリング中、パイプラインは各三角形で頂点データを補間します。</span><span class="sxs-lookup"><span data-stu-id="84947-123">During rendering, the pipeline interpolates vertex data across each triangle.</span></span> <span data-ttu-id="84947-124">頂点データの種類は幅広く、ディフューズ色、スペキュラ色、ディフューズ色のアルファ (三角形の不透明度)、スペキュラ色のアルファ、フォグ係数などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="84947-124">Vertex data can be a broad variety of data and can include (but is not limited to): diffuse color, specular color, diffuse alpha (triangle opacity), specular alpha, and a fog factor.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="vectors--vertices--and-quaternions.md"><span data-ttu-id="84947-125">ベクトル、頂点、および四元数</span><span class="sxs-lookup"><span data-stu-id="84947-125">Vectors, vertices, and quaternions</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-126">Direct3D では、頂点は位置と方向を表します。</span><span class="sxs-lookup"><span data-stu-id="84947-126">Throughout Direct3D, vertices describe position and orientation.</span></span> <span data-ttu-id="84947-127">プリミティブの各頂点は、位置、色、テクスチャ座標を決定するベクトル、およびその方向を決定する法線ベクトルによって示されます。</span><span class="sxs-lookup"><span data-stu-id="84947-127">Each vertex in a primitive is described by a vector that gives its position, color, texture coordinates, and a normal vector that gives its orientation.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="transforms.md"><span data-ttu-id="84947-128">変換</span><span class="sxs-lookup"><span data-stu-id="84947-128">Transforms</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-129">Direct3D の機能の一部で、ジオメトリを固定機能ジオメトリ パイプラインに挿入する変換エンジンです。</span><span class="sxs-lookup"><span data-stu-id="84947-129">The part of Direct3D that pushes geometry through the fixed function geometry pipeline is the transform engine.</span></span> <span data-ttu-id="84947-130">変換エンジンは、モデルとビューアーをワールド座標に配置し、画面表示のために頂点を投影し、ビューポートに頂点をクリッピングします。</span><span class="sxs-lookup"><span data-stu-id="84947-130">It locates the model and viewer in the world, projects vertices for display on the screen, and clips vertices to the viewport.</span></span> <span data-ttu-id="84947-131">さらに変換エンジンは照明計算を実行し、各頂点における拡散成分および鏡面成分を決定します。</span><span class="sxs-lookup"><span data-stu-id="84947-131">The transform engine also performs lighting computations to determine diffuse and specular components at each vertex.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="viewports-and-clipping.md"><span data-ttu-id="84947-132">ビューポートとクリッピング</span><span class="sxs-lookup"><span data-stu-id="84947-132">Viewports and clipping</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="84947-133">"ビューポート<em></em>" とは、3D シーンが投影される 2 次元 (2D) の矩形です。</span><span class="sxs-lookup"><span data-stu-id="84947-133">A <em>viewport</em> is a two-dimensional (2D) rectangle into which a 3D scene is projected.</span></span> <span data-ttu-id="84947-134">Direct3D では、この四角形は Direct3D サーフェス内の座標として存在し、システムによってレンダー ターゲットとして使われます。</span><span class="sxs-lookup"><span data-stu-id="84947-134">In Direct3D, the rectangle exists as coordinates within a Direct3D surface that the system uses as a rendering target.</span></span> <span data-ttu-id="84947-135">射影変換は、頂点をビューポートで使われる座標系に変換します。</span><span class="sxs-lookup"><span data-stu-id="84947-135">The projection transformation converts vertices into the coordinate system used for the viewport.</span></span> <span data-ttu-id="84947-136">さらに、ビューポートはレンダー ターゲット サーフェスの深度値の範囲を指定できます。この範囲は、通常、0.0 ～ 1.0 です。</span><span class="sxs-lookup"><span data-stu-id="84947-136">A viewport is also used to specify the range of depth values on a render-target surface into which a scene will be rendered (usually 0.0 to 1.0).</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="84947-137"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="84947-137"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="84947-138">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="84947-138">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




