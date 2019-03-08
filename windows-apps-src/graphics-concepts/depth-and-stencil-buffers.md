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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662127"
---
# <a name="depth-and-stencil-buffers"></a><span data-ttu-id="bdb0a-104">深度バッファーとステンシル バッファー</span><span class="sxs-lookup"><span data-stu-id="bdb0a-104">Depth and stencil buffers</span></span>


<span data-ttu-id="bdb0a-105">*深度バッファー*には、ビューから隠すのではなくレンダリングする多角形の領域を制御するための深度情報が格納されます。</span><span class="sxs-lookup"><span data-stu-id="bdb0a-105">A *depth buffer* stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span> <span data-ttu-id="bdb0a-106">*ステンシル バッファー*は、画像内のピクセルをマスクし、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどの特殊効果を生成するために使われます。</span><span class="sxs-lookup"><span data-stu-id="bdb0a-106">A *stencil buffer* is used to mask pixels in an image, to produce special effects, including compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="bdb0a-107"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="bdb0a-107"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="bdb0a-108">トピック</span><span class="sxs-lookup"><span data-stu-id="bdb0a-108">Topic</span></span></th>
<th align="left"><span data-ttu-id="bdb0a-109">説明</span><span class="sxs-lookup"><span data-stu-id="bdb0a-109">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="bdb0a-110"><a href="depth-buffers.md">深度バッファー</a></span><span class="sxs-lookup"><span data-stu-id="bdb0a-110"><a href="depth-buffers.md">Depth buffers</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="bdb0a-111"><em>深度バッファー</em> (<em>z バッファー</em>) は、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。</span><span class="sxs-lookup"><span data-stu-id="bdb0a-111">A <em>depth buffer</em>, or <em>z-buffer</em>, stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="bdb0a-112"><a href="stencil-buffers.md">ステンシル バッファー</a></span><span class="sxs-lookup"><span data-stu-id="bdb0a-112"><a href="stencil-buffers.md">Stencil buffers</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="bdb0a-113"><em>ステンシル バッファー</em>は、画像内のピクセルをマスクし、特殊効果を生成するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="bdb0a-113">A <em>stencil buffer</em> is used to mask pixels in an image, to produce special effects.</span></span> <span data-ttu-id="bdb0a-114">このマスクは、ピクセルを描画するかどうかを制御します。</span><span class="sxs-lookup"><span data-stu-id="bdb0a-114">The mask controls whether the pixel is drawn or not.</span></span> <span data-ttu-id="bdb0a-115">このような特殊効果には、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどがあります。</span><span class="sxs-lookup"><span data-stu-id="bdb0a-115">These special effects include compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="bdb0a-116"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="bdb0a-116"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="bdb0a-117">Direct3D グラフィックス学習ガイド</span><span class="sxs-lookup"><span data-stu-id="bdb0a-117">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




