---
title: ストリーミング リソースの領域をタイル表示する方法
description: ストリーミング リソースを作成するときは、次元、フォーマット要素のサイズ、およびミップマップや配列スライスの数 (該当する場合) によって、サーフェス領域全体をサポートするために必要なタイルの数が決まります。
ms.assetid: 3485FD8D-2A06-4B0A-8810-ECF37736F94B
keywords:
- ストリーミング リソースの領域をタイル表示する方法
- リソースの領域, タイル表示
- サイズの一覧表, リソース, タイル表示
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 49ad096389c27fb65970424569c7c1d2ea0cb097
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5931903"
---
# <a name="how-a-streaming-resources-area-is-tiled"></a><span data-ttu-id="1e208-106">ストリーミング リソースの領域をタイル表示する方法</span><span class="sxs-lookup"><span data-stu-id="1e208-106">How a streaming resource's area is tiled</span></span>


<span data-ttu-id="1e208-107">ストリーミング リソースを作成するときは、次元、フォーマット要素のサイズ、およびミップマップや配列スライスの数 (該当する場合) によって、サーフェス領域全体をサポートするために必要なタイルの数が決まります。</span><span class="sxs-lookup"><span data-stu-id="1e208-107">When you create a streaming resource, the dimensions, format element size, and number of mipmaps and/or array slices (if applicable) determine the number of tiles that are required to back the entire surface area.</span></span> <span data-ttu-id="1e208-108">タイル内のピクセル/バイト レイアウトは、実装によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="1e208-108">The pixel/byte layout within tiles is determined by the implementation.</span></span> <span data-ttu-id="1e208-109">1 つのタイルに収まるピクセル数は、形式の要素のサイズに応じて固定され、標準スウィズルを使用するかどうかに関係なく同じです。</span><span class="sxs-lookup"><span data-stu-id="1e208-109">The number of pixels that fit in a tile, depending on the format element size, is fixed and identical whether you use a standard swizzle or not.</span></span>

<span data-ttu-id="1e208-110">指定されたサーフェスのサイズと形式要素の幅によって使用されるタイルの数は、次のセクションの表に基づいて定義されており、予測可能です。</span><span class="sxs-lookup"><span data-stu-id="1e208-110">The number of tiles that will be used by a given surface size and format element width is well defined and predictable based on the tables in the following sections.</span></span> <span data-ttu-id="1e208-111">ミップマップを含むリソースや、サーフェスのサイズがタイルに満たない場合は、いくつかの制約が存在します。「[ミップマップのパッキング](mipmap-packing.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="1e208-111">For resources that contain mipmaps or cases where surface dimensions don't fill a tile, some constraints exist; see [Mipmap packing](mipmap-packing.md).</span></span>

<span data-ttu-id="1e208-112">アプリケーションが、ある形式でのメモリへの書き込みと別の形式での読み取りの結果に依存しない限り、複数のストリーミング リソースがさまざまな形式で同一のメモリを指定できます。</span><span class="sxs-lookup"><span data-stu-id="1e208-112">Different streaming resources can point to identical memory with different formats as long as applications don't rely on the results of writing to the memory with one format and reading with another.</span></span> <span data-ttu-id="1e208-113">ただし、形式が同じ形式ファミリーである場合 (つまり、型指定なしの親の形式が同じである場合)、アプリケーションは、ある形式でのメモリへの書き込みと別の形式での読み取りの結果に依存する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1e208-113">But applications can rely on the results of writing to the memory with one format and reading with another if the formats are in the same format family (that is, they have the same typeless parent format).</span></span> <span data-ttu-id="1e208-114">たとえば、DXGI\_FORMAT\_R8G8B8A8\_UNORM と DXGI\_FORMAT\_R8G8B8A8\_UINT は互換性がありますが、DXGI\_FORMAT\_R16G16\_UNORM とは互換性がありません。</span><span class="sxs-lookup"><span data-stu-id="1e208-114">For example, DXGI\_FORMAT\_R8G8B8A8\_UNORM and DXGI\_FORMAT\_R8G8B8A8\_UINT are compatible with each other but not with DXGI\_FORMAT\_R16G16\_UNORM.</span></span>

<span data-ttu-id="1e208-115">ある形式のデータが別の形式のエイリアスとして定義されている場合は例外です。タイルのすべてのビットに 0 が含まれている場合、そのタイルは、(メモリ レイアウトに関係なく) メモリの内容が 0 であることを解釈する任意の形式で使用できます。</span><span class="sxs-lookup"><span data-stu-id="1e208-115">An exception is where bleeding data from one format aliasing to another is well defined: if a tile completely contains 0 for all its bits, that tile can be used with any format that interprets those memory contents as 0 (regardless of memory layout).</span></span> <span data-ttu-id="1e208-116">そのため、DXGI\_FORMAT\_R8\_UNORM 形式でタイルを 0x00 にクリアし、DXGI\_FORMAT\_R32G32\_FLOAT などの形式で使用でき、その内容は引き続き (0.0f,0.0f) と表示されます。</span><span class="sxs-lookup"><span data-stu-id="1e208-116">So, a tile could be cleared to 0x00 with the format DXGI\_FORMAT\_R8\_UNORM and then used with a format like DXGI\_FORMAT\_R32G32\_FLOAT and it would appear the contents are still (0.0f,0.0f).</span></span>

<span data-ttu-id="1e208-117">タイル内でのデータのレイアウトは、タイルがリソース全体に割り当てられているかどうかに依存しません。</span><span class="sxs-lookup"><span data-stu-id="1e208-117">The layout of data within a tile doesn't depend on where the tile is mapped in a resource overall.</span></span> <span data-ttu-id="1e208-118">そのため、たとえば、サーフェスの複数の場所で同時にタイルを再利用し、すべての場所で一貫性のある動作を実現できます。</span><span class="sxs-lookup"><span data-stu-id="1e208-118">So, for example, a tile can be reused in different locations of a surface at once with consistent behavior in all locations.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="1e208-119"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="1e208-119"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1e208-120">トピック</span><span class="sxs-lookup"><span data-stu-id="1e208-120">Topic</span></span></th>
<th align="left"><span data-ttu-id="1e208-121">説明</span><span class="sxs-lookup"><span data-stu-id="1e208-121">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="texture2d-and-texture2darray-subresource-tiling.md"><span data-ttu-id="1e208-122">Texture2D と Texture2DArray のサブリソースのタイル表示</span><span class="sxs-lookup"><span data-stu-id="1e208-122">Texture2D and Texture2DArray subresource tiling</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1e208-123">次の表に、<a href="https://msdn.microsoft.com/library/windows/desktop/ff471525"><strong>Texture2D</strong></a> および <a href="https://msdn.microsoft.com/library/windows/desktop/ff471526"><strong>Texture2DArray</strong></a> サブリソースがどのようにタイル表示されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="1e208-123">These tables show how <a href="https://msdn.microsoft.com/library/windows/desktop/ff471525"><strong>Texture2D</strong></a> and <a href="https://msdn.microsoft.com/library/windows/desktop/ff471526"><strong>Texture2DArray</strong></a> subresources are tiled.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="texture3d-subresource-tiling.md"><span data-ttu-id="1e208-124">Texture3D サブリソースのタイル表示</span><span class="sxs-lookup"><span data-stu-id="1e208-124">Texture3D subresource tiling</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1e208-125">次の表に、<a href="https://msdn.microsoft.com/library/windows/desktop/ff471562"><strong>Texture3D</strong></a> サブリソースがどのようにタイル表示されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="1e208-125">This table shows how <a href="https://msdn.microsoft.com/library/windows/desktop/ff471562"><strong>Texture3D</strong></a> subresources are tiled.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="buffer-tiling.md"><span data-ttu-id="1e208-126">バッファーのタイル表示</span><span class="sxs-lookup"><span data-stu-id="1e208-126">Buffer tiling</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1e208-127"><a href="introduction-to-buffers.md">バッファー </a> リソースは 64 KB のタイルに分割されます。サイズが 64 KB の倍数でない場合は、最後のタイルに空きが生じます。</span><span class="sxs-lookup"><span data-stu-id="1e208-127">A <a href="introduction-to-buffers.md">Buffer</a> resource is divided into 64KB tiles, with some empty space in the last tile if the size is not a multiple of 64KB.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="mipmap-packing.md"><span data-ttu-id="1e208-128">ミップマップのパッキング</span><span class="sxs-lookup"><span data-stu-id="1e208-128">Mipmap packing</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1e208-129">ストリーミング リソースのサイズ、形式、ミップマップの数、配列スライスに応じて、いくつかの mips (配列スライスごと) をいくつかのタイルにパッキングすることができます。</span><span class="sxs-lookup"><span data-stu-id="1e208-129">Some number of mips (per array slice) can be packed into some number of tiles, depending on a streaming resource's dimensions, format, number of mipmaps, and array slices.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1e208-130"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1e208-130"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1e208-131">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="1e208-131">Creating streaming resources</span></span>](creating-streaming-resources.md)

 

 




