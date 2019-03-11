---
title: 変換
description: Direct3D の機能の一部で、ジオメトリを固定機能ジオメトリ パイプラインに挿入する変換エンジンです。
ms.assetid: 0DF2A99A-335C-4D14-9720-6D7996DD635A
keywords:
- 変換
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a29d42a9254ca47402a38ea71c8c1ef69de5c6c7
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57639647"
---
# <a name="transforms"></a><span data-ttu-id="683c5-104">変換</span><span class="sxs-lookup"><span data-stu-id="683c5-104">Transforms</span></span>


<span data-ttu-id="683c5-105">Direct3D の機能の一部で、ジオメトリを固定機能ジオメトリ パイプラインに挿入する変換エンジンです。</span><span class="sxs-lookup"><span data-stu-id="683c5-105">The part of Direct3D that pushes geometry through the fixed function geometry pipeline is the transform engine.</span></span> <span data-ttu-id="683c5-106">変換エンジンは、モデルとビューアーをワールド座標に配置し、画面表示のために頂点を投影し、ビューポートに頂点をクリッピングします。</span><span class="sxs-lookup"><span data-stu-id="683c5-106">It locates the model and viewer in the world, projects vertices for display on the screen, and clips vertices to the viewport.</span></span> <span data-ttu-id="683c5-107">さらに変換エンジンは照明計算を実行し、各頂点における拡散成分および鏡面成分を決定します。</span><span class="sxs-lookup"><span data-stu-id="683c5-107">The transform engine also performs lighting computations to determine diffuse and specular components at each vertex.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="683c5-108"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="683c5-108"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="683c5-109">トピック</span><span class="sxs-lookup"><span data-stu-id="683c5-109">Topic</span></span></th>
<th align="left"><span data-ttu-id="683c5-110">説明</span><span class="sxs-lookup"><span data-stu-id="683c5-110">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="683c5-111"><a href="transform-overview.md">変換の概要</a></span><span class="sxs-lookup"><span data-stu-id="683c5-111"><a href="transform-overview.md">Transform overview</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="683c5-112">3D グラフィックスの多くの低レベル数学演算は、行列変換によって処理されます。</span><span class="sxs-lookup"><span data-stu-id="683c5-112">Matrix transformations handle a lot of the low level math of 3D graphics.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="683c5-113"><a href="world-transform.md">ワールド変換</a></span><span class="sxs-lookup"><span data-stu-id="683c5-113"><a href="world-transform.md">World transform</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="683c5-114">ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。</span><span class="sxs-lookup"><span data-stu-id="683c5-114">A world transform changes coordinates from model space, where vertices are defined relative to a model's local origin, to world space.</span></span> <span data-ttu-id="683c5-115">ワールド空間では、頂点はシーン内のすべてのオブジェクトに共通の原点を基準として相対的に定義されます。</span><span class="sxs-lookup"><span data-stu-id="683c5-115">In world space, vertices are defined relative to an origin common to all the objects in a scene.</span></span> <span data-ttu-id="683c5-116">ワールド変換は、モデルをワールド空間に配置します。</span><span class="sxs-lookup"><span data-stu-id="683c5-116">The world transform places a model into the world.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="683c5-117"><a href="view-transform.md">ビューの変換</a></span><span class="sxs-lookup"><span data-stu-id="683c5-117"><a href="view-transform.md">View transform</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="683c5-118"><em>"ビュー変換"</em> は、ビューアーをワールド空間に配置し、頂点をカメラ空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="683c5-118">A <em>view transform</em> locates the viewer in world space, transforming vertices into camera space.</span></span> <span data-ttu-id="683c5-119">カメラ空間では、カメラつまりビューアーは原点に位置し、Z 軸の正方向を向いています。</span><span class="sxs-lookup"><span data-stu-id="683c5-119">In camera space, the camera, or viewer, is at the origin, looking in the positive z-direction.</span></span> <span data-ttu-id="683c5-120">ビュー行列は、ワールド内のオブジェクトを、カメラの位置 (カメラ空間の原点) と方向を中心として再配置します。</span><span class="sxs-lookup"><span data-stu-id="683c5-120">The view matrix relocates the objects in the world around a camera's position - the origin of camera space - and orientation.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="683c5-121"><a href="projection-transform.md">Projection 変換</a></span><span class="sxs-lookup"><span data-stu-id="683c5-121"><a href="projection-transform.md">Projection transform</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="683c5-122"><em>"射影変換"</em> はカメラの内部を制御します。これは、カメラのレンズを選択することと似ています。</span><span class="sxs-lookup"><span data-stu-id="683c5-122">A <em>projection transformation</em> controls the camera's internals, like choosing a lens for a camera.</span></span> <span data-ttu-id="683c5-123">このトランスフォームは、3 種類のトランスフォームの中で最も複雑です。</span><span class="sxs-lookup"><span data-stu-id="683c5-123">This is the most complicated of the three transformation types.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="683c5-124"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="683c5-124"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="683c5-125">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="683c5-125">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




