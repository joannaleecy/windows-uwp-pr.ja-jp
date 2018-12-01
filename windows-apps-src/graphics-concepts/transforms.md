---
title: 変換
description: Direct3D の処理の中で、ジオメトリを固定機能ジオメトリ パイプラインに通す部分を担うのが変換エンジンです。
ms.assetid: 0DF2A99A-335C-4D14-9720-6D7996DD635A
keywords:
- 変換
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a29d42a9254ca47402a38ea71c8c1ef69de5c6c7
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8344362"
---
# <a name="transforms"></a><span data-ttu-id="fe6c1-104">変換</span><span class="sxs-lookup"><span data-stu-id="fe6c1-104">Transforms</span></span>


<span data-ttu-id="fe6c1-105">Direct3D の機能の一部で、ジオメトリを固定機能ジオメトリ パイプラインに挿入する変換エンジンです。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-105">The part of Direct3D that pushes geometry through the fixed function geometry pipeline is the transform engine.</span></span> <span data-ttu-id="fe6c1-106">変換エンジンは、モデルとビューアーをワールド座標に配置し、画面表示のために頂点を投影し、ビューポートに頂点をクリッピングします。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-106">It locates the model and viewer in the world, projects vertices for display on the screen, and clips vertices to the viewport.</span></span> <span data-ttu-id="fe6c1-107">また、照明の計算を実行し、各頂点での拡散要素と反射要素を決定します。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-107">The transform engine also performs lighting computations to determine diffuse and specular components at each vertex.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="fe6c1-108"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="fe6c1-108"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="fe6c1-109">トピック</span><span class="sxs-lookup"><span data-stu-id="fe6c1-109">Topic</span></span></th>
<th align="left"><span data-ttu-id="fe6c1-110">説明</span><span class="sxs-lookup"><span data-stu-id="fe6c1-110">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="transform-overview.md"><span data-ttu-id="fe6c1-111">変換の概要</span><span class="sxs-lookup"><span data-stu-id="fe6c1-111">Transform overview</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="fe6c1-112">3D グラフィックスの多くの低レベル数学演算は、行列変換によって処理されます。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-112">Matrix transformations handle a lot of the low level math of 3D graphics.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="world-transform.md"><span data-ttu-id="fe6c1-113">ワールド変換</span><span class="sxs-lookup"><span data-stu-id="fe6c1-113">World transform</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="fe6c1-114">ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-114">A world transform changes coordinates from model space, where vertices are defined relative to a model's local origin, to world space.</span></span> <span data-ttu-id="fe6c1-115">ワールド空間では、頂点はシーン内のすべてのオブジェクトに共通の原点を基準として相対的に定義されます。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-115">In world space, vertices are defined relative to an origin common to all the objects in a scene.</span></span> <span data-ttu-id="fe6c1-116">ワールド変換は、モデルをワールド空間に配置します。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-116">The world transform places a model into the world.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="view-transform.md"><span data-ttu-id="fe6c1-117">ビュー変換</span><span class="sxs-lookup"><span data-stu-id="fe6c1-117">View transform</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="fe6c1-118">"ビュー変換"<em></em> は、ビューアーをワールド空間に配置し、頂点をカメラ空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-118">A <em>view transform</em> locates the viewer in world space, transforming vertices into camera space.</span></span> <span data-ttu-id="fe6c1-119">カメラ空間では、カメラつまりビューアーは原点に位置し、Z 軸の正方向を向いています。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-119">In camera space, the camera, or viewer, is at the origin, looking in the positive z-direction.</span></span> <span data-ttu-id="fe6c1-120">ビュー行列は、ワールド内のオブジェクトを、カメラの位置 (カメラ空間の原点) と方向を中心として再配置します。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-120">The view matrix relocates the objects in the world around a camera's position - the origin of camera space - and orientation.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="projection-transform.md"><span data-ttu-id="fe6c1-121">射影変換</span><span class="sxs-lookup"><span data-stu-id="fe6c1-121">Projection transform</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="fe6c1-122">"射影変換"<em></em> はカメラの内部を制御します。これは、カメラのレンズを選択することと似ています。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-122">A <em>projection transformation</em> controls the camera's internals, like choosing a lens for a camera.</span></span> <span data-ttu-id="fe6c1-123">この変換は、3 種類の変換の中で最も複雑です。</span><span class="sxs-lookup"><span data-stu-id="fe6c1-123">This is the most complicated of the three transformation types.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="fe6c1-124"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="fe6c1-124"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="fe6c1-125">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="fe6c1-125">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




