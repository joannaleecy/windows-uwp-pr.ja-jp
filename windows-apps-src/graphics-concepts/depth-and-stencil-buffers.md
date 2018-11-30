---
title: 深度バッファーとステンシル バッファー
description: 深度バッファーは、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。
ms.assetid: 98B9D73A-04A7-4758-AC27-33CD4CB24216
keywords:
- 深度バッファーとステンシル バッファー
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0336054b99e5aae6739e22afd29ee344aad3d42c
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8208838"
---
# <a name="depth-and-stencil-buffers"></a><span data-ttu-id="4be08-104">深度バッファーとステンシル バッファー</span><span class="sxs-lookup"><span data-stu-id="4be08-104">Depth and stencil buffers</span></span>


<span data-ttu-id="4be08-105">*深度バッファー*は、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。</span><span class="sxs-lookup"><span data-stu-id="4be08-105">A *depth buffer* stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span> <span data-ttu-id="4be08-106">*ステンシル バッファー*は、画像内のピクセルをマスクするために使用されます。これにより、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどの特殊効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4be08-106">A *stencil buffer* is used to mask pixels in an image, to produce special effects, including compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="4be08-107"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="4be08-107"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="4be08-108">トピック</span><span class="sxs-lookup"><span data-stu-id="4be08-108">Topic</span></span></th>
<th align="left"><span data-ttu-id="4be08-109">説明</span><span class="sxs-lookup"><span data-stu-id="4be08-109">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="depth-buffers.md"><span data-ttu-id="4be08-110">深度バッファー</span><span class="sxs-lookup"><span data-stu-id="4be08-110">Depth buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4be08-111"><em>深度バッファー</em> (<em>z バッファー</em>) は、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。</span><span class="sxs-lookup"><span data-stu-id="4be08-111">A <em>depth buffer</em>, or <em>z-buffer</em>, stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="stencil-buffers.md"><span data-ttu-id="4be08-112">ステンシル バッファー</span><span class="sxs-lookup"><span data-stu-id="4be08-112">Stencil buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4be08-113"><em>ステンシル バッファー</em>は、画像内のピクセルをマスクし、特殊効果を生成するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="4be08-113">A <em>stencil buffer</em> is used to mask pixels in an image, to produce special effects.</span></span> <span data-ttu-id="4be08-114">このマスクは、ピクセルを描画するかどうかを制御します。</span><span class="sxs-lookup"><span data-stu-id="4be08-114">The mask controls whether the pixel is drawn or not.</span></span> <span data-ttu-id="4be08-115">このような特殊効果には、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどがあります。</span><span class="sxs-lookup"><span data-stu-id="4be08-115">These special effects include compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="4be08-116"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="4be08-116"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="4be08-117">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="4be08-117">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




