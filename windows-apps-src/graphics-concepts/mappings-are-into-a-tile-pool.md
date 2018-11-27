---
title: タイル プールにマッピングされます
description: リソースがストリーミング リソースとして作成される場合、リソースを構成するタイルは、タイル プール内の場所をポイントすることに基づきます。 タイル プールは、メモリのプールです (バックグラウンドでの 1 つ以上の割り当てによってサポートされます。アプリケーションからは見えません)。
ms.assetid: 58B8DBD5-62F5-4B94-8DD1-C7D57A812185
keywords:
- タイル プールにマッピングされます
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a0474345e21161e76fbfeebe0086e5d433b2d219
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7713456"
---
# <a name="mappings-are-into-a-tile-pool"></a><span data-ttu-id="52895-105">タイル プールにマッピングされます</span><span class="sxs-lookup"><span data-stu-id="52895-105">Mappings are into a tile pool</span></span>


<span data-ttu-id="52895-106">リソースがストリーミング リソースとして作成される場合、リソースを構成するタイルは、タイル プール内の場所をポイントすることに基づきます。</span><span class="sxs-lookup"><span data-stu-id="52895-106">When a resource is created as a streaming resource, the tiles that make up the resource come from pointing at locations in a tile pool.</span></span> <span data-ttu-id="52895-107">タイル プールは、メモリのプールです (バックグラウンドでの 1 つ以上の割り当てによってサポートされます。アプリケーションからは見えません)。</span><span class="sxs-lookup"><span data-stu-id="52895-107">A tile pool is a pool of memory (backed by one or more allocations behind the scenes - unseen by the application).</span></span> <span data-ttu-id="52895-108">オペレーティング システムとディスプレイ ドライバーがメモリのこのプールを管理し、メモリ使用量はアプリケーションが簡単に理解することができます。</span><span class="sxs-lookup"><span data-stu-id="52895-108">The operating system and display driver manage this pool of memory, and the memory footprint is easily understood by an application.</span></span> <span data-ttu-id="52895-109">ストリーミング リソースは、タイル プール内の位置をポイントすることで 64KB の領域をマッピングします。</span><span class="sxs-lookup"><span data-stu-id="52895-109">Streaming resources map 64KB regions by pointing to locations in a tile pool.</span></span> <span data-ttu-id="52895-110">この設定の 1 つの副産物として、複数のリソースが同じタイルを共有して再利用することができ、必要な場合はリソース内の異なる位置で同じタイルを再利用することもできます。</span><span class="sxs-lookup"><span data-stu-id="52895-110">One fallout of this setup is it allows multiple resources to share and reuse the same tiles, and also for the same tiles to be reused at different locations within a resource if desired.</span></span>

<span data-ttu-id="52895-111">タイル プール外のリソースがタイルを柔軟に利用できる代わりに、リソースは、タイル プール内のどのタイルがリソースに必要なタイルを表しているかというマッピングを定義し、維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="52895-111">The cost for the flexibility of populating the tiles for a resource out of a tile pool is that the resource has to do the work of defining and maintaining the mapping of which tiles in the tile pool represent the tiles needed for the resource.</span></span> <span data-ttu-id="52895-112">タイル マッピングは変更することができます。</span><span class="sxs-lookup"><span data-stu-id="52895-112">Tile mappings can be changed.</span></span> <span data-ttu-id="52895-113">さらに、リソース内のすべてのタイルを一度にマッピングする必要はありません。リソースのマッピングを **NULL** にすることができます。</span><span class="sxs-lookup"><span data-stu-id="52895-113">Also, not all tiles in a resource need to be mapped at a time; a resource can have **NULL** mappings.</span></span> <span data-ttu-id="52895-114">**NULL** マッピングは、タイルを、タイルにアクセスするリソースの観点から利用不可と定義します。</span><span class="sxs-lookup"><span data-stu-id="52895-114">A **NULL** mapping defines a tile as not being available from the point of view of the resource accessing it.</span></span>

<span data-ttu-id="52895-115">タイル プールは複数作成することができ、一度に任意の数のストリーミング リソースを特定のタイル プールにマッピングできます。</span><span class="sxs-lookup"><span data-stu-id="52895-115">Multiple tile pools can be created, and any number of streaming resources can map into any given tile pool at the same time.</span></span> <span data-ttu-id="52895-116">タイル プールは、拡大したり縮小したりすることもできます。</span><span class="sxs-lookup"><span data-stu-id="52895-116">Tile pools can also be grown or shrunk.</span></span> <span data-ttu-id="52895-117">詳しくは、「[タイル プールのサイズ変更](tile-pool-resizing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="52895-117">For more info, see [Tile pool resizing](tile-pool-resizing.md).</span></span> <span data-ttu-id="52895-118">ディスプレイ ドライバーとランタイムの実装を簡略化するために存在する 1 つの制約として、特定のストリーミング リソースが一度にマッピングできるタイル プールは最大で 1 つだけです (複数のタイル プールへの同時マッピングとは対照的です)。</span><span class="sxs-lookup"><span data-stu-id="52895-118">One constraint that exists to simplify display driver and runtime implementation is that a given streaming resource can only have mappings into at most one tile pool at a time (as opposed to having simultaneous mapping to multiple tile pools).</span></span>

<span data-ttu-id="52895-119">ストリーミング リソース自体 (つまり、独立したタイル プール メモリ) に関連付けられるストレージの量は、任意の時点でプールに実際にマッピングされているタイルの数にほぼ比例しています。</span><span class="sxs-lookup"><span data-stu-id="52895-119">The amount of storage that is associated with a streaming resource itself (that is, independent tile-pool memory) is roughly proportional to the number of tiles actually mapped to the pool at any given time.</span></span> <span data-ttu-id="52895-120">ハードウェアでは、この事実はつまり、ページ テーブル ストレージのメモリ使用量は、マッピングされるタイルの量にほぼ対応することになります (たとえば、必要に応じて複数レベルのページ テーブル スキームを使用)。</span><span class="sxs-lookup"><span data-stu-id="52895-120">In hardware, this fact boils down to scaling the memory footprint for page table storage roughly with the amount of tiles that are mapped (for example, using a multilevel page table scheme as appropriate).</span></span>

<span data-ttu-id="52895-121">タイル プールは、Direct3D アプリケーションが低レベルの実装の詳細を認識していなくても (またはポインター アドレスを直接処理しなくても) グラフィックス処理装置 (GPU) でページ テーブルを効果的にプログラミングできるようにする、完全なソフトウェア抽象と考えることができます。</span><span class="sxs-lookup"><span data-stu-id="52895-121">The tile pool can be thought of as an entirely software abstraction that enables Direct3D applications to effectively be able to program the page tables on the graphics processing unit (GPU) without having to know the low level implementation details (or deal with pointer addresses directly).</span></span> <span data-ttu-id="52895-122">タイル プールは、ハードウェアに追加レベルの間接参照を適用しません。</span><span class="sxs-lookup"><span data-stu-id="52895-122">Tile pools don't apply any additional levels of indirection in hardware.</span></span> <span data-ttu-id="52895-123">ページ ディレクトリのようなコンストラクトを使った単一レベルのページ テーブルの最適化は、タイル プールの概念とは無関係です。</span><span class="sxs-lookup"><span data-stu-id="52895-123">Optimizations of a single level page table using constructs like page directories are independent of the tile pool concept.</span></span>

<span data-ttu-id="52895-124">最悪のケースでページ テーブル自体に必要となるストレージについて考えてみましょう (ただし、実際の実装で必要となるストレージは、マッピングされる量にほぼ比例します)。</span><span class="sxs-lookup"><span data-stu-id="52895-124">Let us explore what storage the page table itself could require in the worst case (though in practice implementations only require storage roughly proportional to what is mapped).</span></span>

<span data-ttu-id="52895-125">各ページ テーブルのエントリが 64 ビットであるとします。</span><span class="sxs-lookup"><span data-stu-id="52895-125">Suppose each page table entry is 64 bits.</span></span>

<span data-ttu-id="52895-126">における最悪のケースのページ テーブル サイズ ヒットの 1 つのサーフェス、ストリーミング リソースが作成されると仮定 (たとえば、RGBA の浮動小数点)、128 ビット/要素の形式で、64 KB のタイル、Direct3D11 のリソース制限を指定した場合にのみ 4096 ピクセルが含まれています。</span><span class="sxs-lookup"><span data-stu-id="52895-126">For the worst-case page table size hit for a single surface, given the resource limits in Direct3D11, suppose a streaming resource is created with a 128 bit-per-element format (for example, a RGBA float), so a 64KB tile contains only 4096 pixels.</span></span> <span data-ttu-id="52895-127">[**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) のサポートされる最大サイズ 16384\*16384\*2048 (ただし、単一のミットマップのみ使用) に必要なストレージは、64 ビットのテーブル エントリを使って完全に書き込まれた場合 (ミップマップは含まない) は約 1 GB です。</span><span class="sxs-lookup"><span data-stu-id="52895-127">The maximum supported [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) size of 16384\*16384\*2048 (but with only a single mipmap) would require about 1GB of storage in the page table if fully populated (not including mipmaps) using 64 bit table entries.</span></span> <span data-ttu-id="52895-128">ミップマップを追加すると、完全にマッピングされた (最悪のケース) ページ テーブル ストレージが約 3 分の 1 増加し、約 1.3 GB になります。</span><span class="sxs-lookup"><span data-stu-id="52895-128">Adding mipmaps would grow the fully-mapped (worst case) page table storage by about a third, to about 1.3GB.</span></span>

<span data-ttu-id="52895-129">このケースでは、約 10.6 TB のアドレス可能メモリにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="52895-129">This case would give access to about 10.6 terabytes of addressable memory.</span></span> <span data-ttu-id="52895-130">ただし、アドレス可能メモリの量に制限が存在することがあり、その場合これらの量は 1 TB 前後の範囲に減少する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="52895-130">There might be a limit on the amount of addressable memory however, which would reduce these amounts, perhaps to around the terabyte range.</span></span>

<span data-ttu-id="52895-131">考慮できる別のケースは、32 ビット/要素の形式になっている 16384\*16384 の単一の [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) ストリーミング リソースです (ミップマップを含む)。</span><span class="sxs-lookup"><span data-stu-id="52895-131">Another case to consider is a single [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) streaming resource of 16384\*16384 with a 32 bit-per-element format, including mipmaps.</span></span> <span data-ttu-id="52895-132">完全に書き込まれたページ テーブルに必要な領域は、64 ビットのテーブル エントリで約 170 KB です。</span><span class="sxs-lookup"><span data-stu-id="52895-132">The space needed in a fully populated page table would be roughly 170KB with 64 bit table entries.</span></span>

<span data-ttu-id="52895-133">最後に、BC 形式を使った例について考えます。たとえば、128 ビット/タイルが 4x4 ピクセル存在する BC7 であるとします。</span><span class="sxs-lookup"><span data-stu-id="52895-133">Finally, consider an example using a BC format, say BC7 with 128 bits per tile of 4x4 pixels.</span></span> <span data-ttu-id="52895-134">これは、ピクセルあたり 1 バイトです。</span><span class="sxs-lookup"><span data-stu-id="52895-134">That is one byte per pixel.</span></span> <span data-ttu-id="52895-135">ミップマップを含めて 16384\*16384\*2048 の [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) の場合、ページ テーブル内のこのメモリに完全に書き込むには約 85 MB 必要です。</span><span class="sxs-lookup"><span data-stu-id="52895-135">A [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) of 16384\*16384\*2048 including mipmaps would require roughly 85MB to fully populate this memory in a page table.</span></span> <span data-ttu-id="52895-136">1 つのストリーミング リソースが 550 ギガピクセル (この場合は 512 GB のメモリ) に対応できることを考えると、これは悪くありません。</span><span class="sxs-lookup"><span data-stu-id="52895-136">That is not bad considering this allows one streaming resource to span 550 gigapixels (512 GB of memory in this case).</span></span>

<span data-ttu-id="52895-137">実際には、これほどの量を一度にマッピングしたり参照したりできる量の物理メモリが存在することはないため、このようなほぼフル マッピングは定義されません。</span><span class="sxs-lookup"><span data-stu-id="52895-137">In practice, nowhere near these full mappings would be defined given that the amount of physical memory available wouldn't allow anywhere near that much to be mapped and referenced at a time.</span></span> <span data-ttu-id="52895-138">しかし、タイル プールでは、アプリケーションがタイルの再利用を選択することがあり (シンプルな例としては、イメージ内の大きい黒色の領域に "黒" のカラー タイルを再利用)、事実上タイル プール (つまり、ページ テーブル マッピング) をメモリ圧縮のツールとして使っていることになります。</span><span class="sxs-lookup"><span data-stu-id="52895-138">But with a tile pool, applications could choose to reuse tiles (as a simple example, reusing a "black" colored tile for large black regions in an image) - effectively using the tile pool (that is, page table mappings) as a tool for memory compression.</span></span>

<span data-ttu-id="52895-139">ページ テーブルの初期コンテンツは、すべてのエントリで **NULL** です。</span><span class="sxs-lookup"><span data-stu-id="52895-139">The initial contents of the page table are **NULL** for all entries.</span></span> <span data-ttu-id="52895-140">さらに、アプリケーションはサーフェスのメモリ コンテンツに初期データを渡しません。最初はメモリのサポートがないためです。</span><span class="sxs-lookup"><span data-stu-id="52895-140">Applications also can't pass initial data for the memory contents of the surface since it starts off with no memory backing.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="52895-141"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="52895-141"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="52895-142">トピック</span><span class="sxs-lookup"><span data-stu-id="52895-142">Topic</span></span></th>
<th align="left"><span data-ttu-id="52895-143">説明</span><span class="sxs-lookup"><span data-stu-id="52895-143">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="tile-pool-creation.md"><span data-ttu-id="52895-144">タイル プールの作成</span><span class="sxs-lookup"><span data-stu-id="52895-144">Tile pool creation</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="52895-145">アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。</span><span class="sxs-lookup"><span data-stu-id="52895-145">Applications can create one or more tile pools per Direct3D device.</span></span> <span data-ttu-id="52895-146">各タイル プールの合計サイズは、GPU RAM の 1/4 では約 Direct3D11 のリソース サイズ制限に制限されます。</span><span class="sxs-lookup"><span data-stu-id="52895-146">The total size of each tile pool is restricted to Direct3D11's resource size limit, which is roughly 1/4 of GPU RAM.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="tile-pool-resizing.md"><span data-ttu-id="52895-147">タイル プールのサイズ変更</span><span class="sxs-lookup"><span data-stu-id="52895-147">Tile pool resizing</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="52895-148">アプリケーションがマッピングされるストリーミング リソースのワーキング セットを多く必要とする場合は、タイル プールのサイズを変更してタイル プールを拡大し、必要な領域が少ない場合は縮小します。</span><span class="sxs-lookup"><span data-stu-id="52895-148">Resize a tile pool to grow a tile pool if the application needs more working set for the streaming resources mapping into it, or to shrink if less space is needed.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="hazard-tracking-versus-tile-pool-resources.md"><span data-ttu-id="52895-149">ハザード追跡対タイル プール リソース</span><span class="sxs-lookup"><span data-stu-id="52895-149">Hazard tracking versus tile pool resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="52895-150">非ストリーミング リソースの場合、Direct3D はレンダリング時に特定のハザード条件を防止できますが、ハザード追跡はストリーミング リソースのタイル レベルで行われるため、ストリーミング リソースのレンダリング時のハザード追跡にはかなりコストがかかる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="52895-150">For non-streaming resources, Direct3D can prevent certain hazard conditions during rendering, but because hazard tracking would be at a tile level for streaming resources, tracking hazard conditions during rendering of streaming resources might be too expensive.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="52895-151"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="52895-151"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="52895-152">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="52895-152">Creating streaming resources</span></span>](creating-streaming-resources.md)

 

 




