---
title: プリミティブ
description: 3D プリミティブは、単一の 3D エンティティを形成する頂点の集合です。
ms.assetid: A1FE6F49-B0D4-4665-90E1-40AD98E668B1
keywords:
- プリミティブ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 8f94f859b57a0be9cfbb2d81d635ae7714129256
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1652541"
---
# <a name="primitives"></a><span data-ttu-id="4768b-104">プリミティブ</span><span class="sxs-lookup"><span data-stu-id="4768b-104">Primitives</span></span>


<span data-ttu-id="4768b-105">3D *プリミティブ*は、単一の 3D エンティティを形成する頂点の集合です。</span><span class="sxs-lookup"><span data-stu-id="4768b-105">A 3D *primitive* is a collection of vertices that form a single 3D entity.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="4768b-106"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="4768b-106"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="4768b-107">トピック</span><span class="sxs-lookup"><span data-stu-id="4768b-107">Topic</span></span></th>
<th align="left"><span data-ttu-id="4768b-108">説明</span><span class="sxs-lookup"><span data-stu-id="4768b-108">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="point-lists.md"><span data-ttu-id="4768b-109">ポイント リスト</span><span class="sxs-lookup"><span data-stu-id="4768b-109">Point lists</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4768b-110">ポイント リストとは、独立した点としてレンダリングされる頂点の集合を指します。</span><span class="sxs-lookup"><span data-stu-id="4768b-110">A point list is a collection of vertices that are rendered as isolated points.</span></span> <span data-ttu-id="4768b-111">アプリケーションは、星空の 3D シーンや、多角形の表面の点線に、ポイント リストを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="4768b-111">Your application can use point lists in 3D scenes for star fields, or dotted lines on the surface of a polygon.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="line-lists.md"><span data-ttu-id="4768b-112">線リスト</span><span class="sxs-lookup"><span data-stu-id="4768b-112">Line lists</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4768b-113">線リストとは、独立した直線セグメントの一覧を指します。</span><span class="sxs-lookup"><span data-stu-id="4768b-113">A line list is a list of isolated, straight line segments.</span></span> <span data-ttu-id="4768b-114">線リストは、3D シーンに氷雨や豪雨を追加する場合などに便利です。</span><span class="sxs-lookup"><span data-stu-id="4768b-114">Line lists are useful for such tasks as adding sleet or heavy rain to a 3D scene.</span></span> <span data-ttu-id="4768b-115">アプリケーションは、頂点の配列を入力することで行リストを作成します。</span><span class="sxs-lookup"><span data-stu-id="4768b-115">Applications create a line list by filling an array of vertices.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="line-strips.md"><span data-ttu-id="4768b-116">ライン ストリップ</span><span class="sxs-lookup"><span data-stu-id="4768b-116">Line strips</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4768b-117">ライン ストリップとは、接続された行セグメントから構成されるプリミティブを指します。</span><span class="sxs-lookup"><span data-stu-id="4768b-117">A line strip is a primitive that is composed of connected line segments.</span></span> <span data-ttu-id="4768b-118">アプリケーションは、ライン ストリップを使用して、閉じられていない多角形を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="4768b-118">Your application can use line strips for creating polygons that are not closed.</span></span> <span data-ttu-id="4768b-119">閉じられた多角形とは、最後の頂点が行セグメントによって最初の頂点に接続されている多角形を指します。</span><span class="sxs-lookup"><span data-stu-id="4768b-119">A closed polygon is a polygon whose last vertex is connected to its first vertex by a line segment.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="triangle-lists.md"><span data-ttu-id="4768b-120">トライアングル リスト</span><span class="sxs-lookup"><span data-stu-id="4768b-120">Triangle lists</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4768b-121">トライアングル リストとは、独立した三角形の一覧を指します。</span><span class="sxs-lookup"><span data-stu-id="4768b-121">A triangle list is a list of isolated triangles.</span></span> <span data-ttu-id="4768b-122">これらの独立した三角形は、距離が近い場合もそうでない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="4768b-122">The isolated triangles might or might not be near each other.</span></span> <span data-ttu-id="4768b-123">三角形の一覧には、最低 3 つの頂点が必須で、頂点の総数は 3 で割り切れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="4768b-123">A triangle list must have at least three vertices and the total number of vertices must be divisible by three.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="triangle-strips.md"><span data-ttu-id="4768b-124">トライアングル ストリップ</span><span class="sxs-lookup"><span data-stu-id="4768b-124">Triangle strips</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4768b-125">トライアングル ストリップとは、接続された一連の三角形を指します。</span><span class="sxs-lookup"><span data-stu-id="4768b-125">A triangle strip is a series of connected triangles.</span></span> <span data-ttu-id="4768b-126">三角形どうしは接続されているため、アプリケーションは三角形ごとに 3 つすべての頂点を繰り返し指定する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="4768b-126">Because the triangles are connected, the application does not need to repeatedly specify all three vertices for each triangle.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="4768b-127"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="4768b-127"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="4768b-128">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="4768b-128">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




