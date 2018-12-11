---
title: ストリーミング リソースの作成
description: ストリーミング リソースは、リソースを作成するときにフラグを指定することによって作成され、リソースがストリーミング リソースであることを示します。
ms.assetid: B3F3E43C-54D4-458C-9E16-E13CB382C83F
keywords:
- ストリーミング リソースの作成
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ec96f6245969d32357563c44107f539fb9043aac
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8896084"
---
# <a name="creating-streaming-resources"></a><span data-ttu-id="ac6d2-104">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="ac6d2-104">Creating streaming resources</span></span>


<span data-ttu-id="ac6d2-105">ストリーミング リソースは、リソースを作成するときにフラグを指定することによって作成され、リソースがストリーミング リソースであることを示します。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-105">Streaming resources are created by specifying a flag when you create a resource, indicating that the resource is a streaming resource.</span></span>

<span data-ttu-id="ac6d2-106">リソースをストリーミング リソースとして作成できる場合の制限については、「[ストリーミング リソース作成のパラメーター](streaming-resource-creation-parameters.md)」で説明されています。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-106">Restrictions on when you can create a resource as a streaming resource are described in [Streaming resource creation parameters](streaming-resource-creation-parameters.md).</span></span>

<span data-ttu-id="ac6d2-107">2D テクスチャの配列の割り当てなど、非ストリーミング リソースのストレージは、リソースの作成時にグラフィック システムに割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-107">A non-streaming resource's storage is allocated in the graphics system when the resource is created, such as allocation for an array of 2D textures.</span></span>

<span data-ttu-id="ac6d2-108">ストリーミング リソースが作成される場合、グラフィック システムはリソース コンテンツにはストレージを割り当てません。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-108">When a streaming resource is created, the graphics system doesn't allocate the storage for the resource contents.</span></span> <span data-ttu-id="ac6d2-109">代わりに、アプリケーションがストリーミング リソースを作成する場合には、グラフィック システムはタイル サーフェスの領域のみのアドレス空間予約を行い、タイルのマッピングをアプリケーションが制御できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-109">Instead, when an application creates a streaming resource, the graphics system makes an address space reservation for the tiled surface's area only, and then allows the mapping of the tiles to be controlled by the application.</span></span> <span data-ttu-id="ac6d2-110">タイルの「マッピング」とは、リソース内の論理タイルがポイントするメモリ内の物理的な位置 (またはマップされていないタイルの場合は**NULL**) です。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-110">The "mapping" of a tile is simply the physical location in memory that a logical tile in a resource points to (or **NULL** for an unmapped tile).</span></span>

<span data-ttu-id="ac6d2-111">この概念を、Direct3D リソースを CPU アクセス用にマッピングするという概念と混同しないでください。これは同じ名前を使用していますが、全く別のものです。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-111">Don't confuse this concept with the notion of mapping a Direct3D resource for CPU access, which despite using the same name is completely independent.</span></span> <span data-ttu-id="ac6d2-112">必要に応じて、個々のタイルのマッピングを個別に定義して変更することができます。サーフェスのすべてのタイルを一度にマップする必要がないため、使用可能なメモリ量を有効に活用できます。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-112">You will be able to define and change the mapping of each tile individually as needed, knowing that all tiles for a surface don't need to be mapped at a time, thereby making effective use of the amount of memory available.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="ac6d2-113"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="ac6d2-113"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="ac6d2-114">トピック</span><span class="sxs-lookup"><span data-stu-id="ac6d2-114">Topic</span></span></th>
<th align="left"><span data-ttu-id="ac6d2-115">説明</span><span class="sxs-lookup"><span data-stu-id="ac6d2-115">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="mappings-are-into-a-tile-pool.md"><span data-ttu-id="ac6d2-116">タイル プールにマッピングされます</span><span class="sxs-lookup"><span data-stu-id="ac6d2-116">Mappings are into a tile pool</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ac6d2-117">リソースがストリーミング リソースとして作成される場合、リソースを構成するタイルは、タイル プール内の場所をポイントすることに基づきます。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-117">When a resource is created as a streaming resource, the tiles that make up the resource come from pointing at locations in a tile pool.</span></span> <span data-ttu-id="ac6d2-118">タイル プールは、メモリのプールです (背後にある 1 つ以上の割り当てによってサポートされていますが、アプリケーションには見えません)。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-118">A tile pool is a pool of memory (backed by one or more allocations behind the scenes - unseen by the application).</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resource-creation-parameters.md"><span data-ttu-id="ac6d2-119">ストリーミング リソースの作成パラメーター</span><span class="sxs-lookup"><span data-stu-id="ac6d2-119">Streaming resource creation parameters</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ac6d2-120">ストリーミング リソースとして作成できる Direct3D リソースの種類には、いくつかの制約があります。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-120">There are some constraints on the type of Direct3D resources that you can create as a streaming resource.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="tile-pool-creation-parameters.md"><span data-ttu-id="ac6d2-121">タイル プールの作成パラメーター</span><span class="sxs-lookup"><span data-stu-id="ac6d2-121">Tile pool creation parameters</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ac6d2-122">このセクションのパラメーターを使用して、バッファーを作成するときにタイル プールを定義します。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-122">Use the parameters in this section to define tile pools when creating a buffer.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resource-cross-process-and-device-sharing.md"><span data-ttu-id="ac6d2-123">ストリーミング リソースのプロセスとデバイス間での共有</span><span class="sxs-lookup"><span data-stu-id="ac6d2-123">Streaming resource cross-process and device sharing</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ac6d2-124">タイル プールは、従来のリソースと同様に、他のプロセスと共有することができます。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-124">Tile pools can be shared with other processes just like traditional resources.</span></span> <span data-ttu-id="ac6d2-125">タイル プールを参照するストリーミング リソースは、デバイスやプロセス間で共有できません。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-125">Streaming resources that reference tile pools can't be shared across devices and processes.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="operations-available-on-streaming-resources.md"><span data-ttu-id="ac6d2-126">ストリーミング リソースで利用可能な操作</span><span class="sxs-lookup"><span data-stu-id="ac6d2-126">Operations available on streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ac6d2-127">このセクションでは、ストリーミング リソースで実行できる操作を示します。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-127">This section lists operations that you can perform on streaming resources.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="operations-available-on-tile-pools.md"><span data-ttu-id="ac6d2-128">タイル プールで利用可能な操作</span><span class="sxs-lookup"><span data-stu-id="ac6d2-128">Operations available on tile pools</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ac6d2-129">タイル プールの操作には、タイル プールのサイズ変更、リソースの提供 (タイル プール全体のためシステムに一時的にメモリを与えます)、およびリソースの再利用が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-129">Operations on tile pools include resizing a tile pool, offering resources (yielding memory temporarily to the system for the entire tile pool), and reclaiming resources.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="how-a-streaming-resource-s-area-is-tiled.md"><span data-ttu-id="ac6d2-130">ストリーミング リソースの領域をタイル表示する方法</span><span class="sxs-lookup"><span data-stu-id="ac6d2-130">How a streaming resource's area is tiled</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="ac6d2-131">ストリーミング リソースを作成するときは、次元、フォーマット要素のサイズ、およびミップマップや配列スライスの数 (該当する場合) によって、サーフェス領域全体をサポートするために必要なタイルの数が決まります。</span><span class="sxs-lookup"><span data-stu-id="ac6d2-131">When you create a streaming resource, the dimensions, format element size, and number of mipmaps and/or array slices (if applicable) determine the number of tiles that are required to back the entire surface area.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="ac6d2-132"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="ac6d2-132"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="ac6d2-133">ストリーミング リソース</span><span class="sxs-lookup"><span data-stu-id="ac6d2-133">Streaming resources</span></span>](streaming-resources.md)

 

 




