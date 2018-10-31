---
title: 深度バッファーとステンシル バッファー
description: 深度バッファーは、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。
ms.assetid: 98B9D73A-04A7-4758-AC27-33CD4CB24216
keywords:
- 深度バッファーとステンシル バッファー
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e292e0c992edb26da2a92885e1f949d254d75da6
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5826707"
---
# <a name="depth-and-stencil-buffers"></a><span data-ttu-id="d07cd-104">深度バッファーとステンシル バッファー</span><span class="sxs-lookup"><span data-stu-id="d07cd-104">Depth and stencil buffers</span></span>


<span data-ttu-id="d07cd-105">*深度バッファー*は、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。</span><span class="sxs-lookup"><span data-stu-id="d07cd-105">A *depth buffer* stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span> <span data-ttu-id="d07cd-106">*ステンシル バッファー*は、画像内のピクセルをマスクするために使用されます。これにより、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどの特殊効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="d07cd-106">A *stencil buffer* is used to mask pixels in an image, to produce special effects, including compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="d07cd-107"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="d07cd-107"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="d07cd-108">トピック</span><span class="sxs-lookup"><span data-stu-id="d07cd-108">Topic</span></span></th>
<th align="left"><span data-ttu-id="d07cd-109">説明</span><span class="sxs-lookup"><span data-stu-id="d07cd-109">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="depth-buffers.md"><span data-ttu-id="d07cd-110">深度バッファー</span><span class="sxs-lookup"><span data-stu-id="d07cd-110">Depth buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d07cd-111"><em>深度バッファー</em> (<em>z バッファー</em>) は、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。</span><span class="sxs-lookup"><span data-stu-id="d07cd-111">A <em>depth buffer</em>, or <em>z-buffer</em>, stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="stencil-buffers.md"><span data-ttu-id="d07cd-112">ステンシル バッファー</span><span class="sxs-lookup"><span data-stu-id="d07cd-112">Stencil buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d07cd-113"><em>ステンシル バッファー</em>は、画像内のピクセルをマスクし、特殊効果を生成するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="d07cd-113">A <em>stencil buffer</em> is used to mask pixels in an image, to produce special effects.</span></span> <span data-ttu-id="d07cd-114">このマスクは、ピクセルを描画するかどうかを制御します。</span><span class="sxs-lookup"><span data-stu-id="d07cd-114">The mask controls whether the pixel is drawn or not.</span></span> <span data-ttu-id="d07cd-115">このような特殊効果には、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどがあります。</span><span class="sxs-lookup"><span data-stu-id="d07cd-115">These special effects include compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="d07cd-116"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="d07cd-116"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="d07cd-117">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="d07cd-117">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




