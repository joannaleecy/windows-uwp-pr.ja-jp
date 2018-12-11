---
title: タイル プールのサイズ変更
description: アプリケーションに、ストリーミング リソースのマッピング先のワーキング セットがさらに必要になった場合にタイル プールを拡大したり、必要な容量が少なくなった場合にタイル プールを縮小したりするためにタイル プールのサイズを変更します。
ms.assetid: A54A06DC-BDDB-42DC-85E8-C64241100ED5
keywords:
- タイル プールのサイズ変更
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7e08447c575e99178e503e99eb651cd5e225a898
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8886636"
---
# <a name="tile-pool-resizing"></a><span data-ttu-id="0bac6-104">タイル プールのサイズ変更</span><span class="sxs-lookup"><span data-stu-id="0bac6-104">Tile pool resizing</span></span>


<span data-ttu-id="0bac6-105">アプリケーションに、ストリーミング リソースのマッピング先のワーキング セットがさらに必要になった場合にタイル プールを拡大したり、必要な容量が少なくなった場合にタイル プールを縮小したりするためにタイル プールのサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="0bac6-105">Resize a tile pool to grow a tile pool if the application needs more working set for the streaming resources mapping into it, or to shrink if less space is needed.</span></span> <span data-ttu-id="0bac6-106">アプリケーションの別のオプションとして、新しいストリーミング リソース用に追加のタイル プールを割り当てることもできます。</span><span class="sxs-lookup"><span data-stu-id="0bac6-106">Another option for applications is to allocate additional tile pools for new streaming resources.</span></span> <span data-ttu-id="0bac6-107">1 つのストリーミング リソースが、そのリソースのタイル プールで最初に利用できる容量より多くの容量を必要とする場合は、タイル プールを拡大することが適切です。</span><span class="sxs-lookup"><span data-stu-id="0bac6-107">But if any single streaming resource needs more space than initially available in its tile pool, growing the tile pool is a good option.</span></span> <span data-ttu-id="0bac6-108">ストリーミング リソースに、同時に複数のタイル プールへのマッピングを含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="0bac6-108">A streaming resource can't have mappings into multiple tile pools at the same time.</span></span>

<span data-ttu-id="0bac6-109">タイル プールが拡大されると、ディスプレイ ドライバーによって、1 つ以上の新しい割り当てを介してプールの最後にタイルが追加されます。</span><span class="sxs-lookup"><span data-stu-id="0bac6-109">When a tile pool is grown, additional tiles are added to the end via one or more new allocations by the display driver.</span></span> <span data-ttu-id="0bac6-110">この割り当ての詳細はアプリケーションには見えません。</span><span class="sxs-lookup"><span data-stu-id="0bac6-110">This breakdown into allocations isn't visible to the application.</span></span> <span data-ttu-id="0bac6-111">タイル プール内の既存のメモリはそのまま残り、そのメモリへの既存のストリーミング リソース マッピングもそのまま残ります。</span><span class="sxs-lookup"><span data-stu-id="0bac6-111">Existing memory in the tile pool is left untouched, and existing streaming resource mappings into that memory remain intact.</span></span>

<span data-ttu-id="0bac6-112">タイル プールが縮小されると、プールの最後からタイルが削除されます。</span><span class="sxs-lookup"><span data-stu-id="0bac6-112">When a tile pool is shrunk, tiles are removed from the end.</span></span> <span data-ttu-id="0bac6-113">タイルは初期割り当てサイズより少なくなっても 0 まで削除されます。つまり、新しいサイズを超えて新しいマッピングを行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="0bac6-113">Tiles are removed even below the initial allocation size, down to 0, which means new mappings can't be made past the new size.</span></span> <span data-ttu-id="0bac6-114">ただし、新しいサイズの最後を超える既存のマッピングはそのまま残り、使用できます。</span><span class="sxs-lookup"><span data-stu-id="0bac6-114">But, existing mappings past the end of the new size remain intact and useable.</span></span> <span data-ttu-id="0bac6-115">ディスプレイ ドライバーは、ドライバーがタイル プールのメモリのために使用する割り当ての一部へのマッピングが残っている限り、メモリを維持し続けます。</span><span class="sxs-lookup"><span data-stu-id="0bac6-115">The display driver will keep the memory around as long as mappings to any part of the allocations that the driver uses for the tile pool memory remains.</span></span> <span data-ttu-id="0bac6-116">縮小後、タイルのマッピングが指していたために一部のメモリが有効に保たれていた場合、タイル プールが再び拡大されると (任意の量)、拡大するサイズに対応するために追加の割り当てが行われる前に、まず既存のメモリが再利用されます。</span><span class="sxs-lookup"><span data-stu-id="0bac6-116">If after shrinking some memory has been kept alive because tile mappings are pointing to it and then the tile pool is regrown again (by any amount), the existing memory is reused first before any additional allocations occur to service the size of the grow operation.</span></span>

<span data-ttu-id="0bac6-117">メモリを節約するために、アプリケーションはタイル プールを縮小するだけでなく、縮小された新しいタイル プールのサイズの最後を超える既存のマッピングを削除/再マッピングする必要もあります。</span><span class="sxs-lookup"><span data-stu-id="0bac6-117">To be able to save memory, an application has to not only shrink a tile pool but also remove/remap existing mappings past the end of the new smaller tile pool size.</span></span>

<span data-ttu-id="0bac6-118">縮小 (およびマッピングの削除) しても、ただちにメモリの節約が行われるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="0bac6-118">The act of shrinking (and removing mappings) doesn't necessarily produce immediate memory savings.</span></span> <span data-ttu-id="0bac6-119">どのようにメモリを解放するかは、ディスプレイ ドライバーによるタイル プールの基になる割り当ての細かさによって異なります。</span><span class="sxs-lookup"><span data-stu-id="0bac6-119">Freeing of memory depends on how granular the display driver's underlying allocations for the tile pool are.</span></span> <span data-ttu-id="0bac6-120">ディスプレイ ドライバーによる割り当てを未使用にできるほど縮小された場合、ディスプレイ ドライバーは割り当てを解放できます。</span><span class="sxs-lookup"><span data-stu-id="0bac6-120">When shrinking happens to be enough to make a display driver allocation unused, the display driver can free it.</span></span> <span data-ttu-id="0bac6-121">タイル プールが拡大された場合、以前のサイズに縮小 (および、それに応じてタイル マッピングを削除/再マッピング) すると、メモリの節約が行われる可能性が高いですが、サイズがディスプレイ ドライバーによって選択された基になる割り当てサイズと完全に一致していない場合は節約されるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="0bac6-121">If a tile pool was grown, shrinking to previous sizes (and removing/remapping tile mappings correspondingly) is most likely to yield memory savings, though not guaranteed in the case that the sizes don't exactly align with the underlying allocation sizes chosen by the display driver.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="0bac6-122"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="0bac6-122"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="0bac6-123">タイル プールにマッピングされます</span><span class="sxs-lookup"><span data-stu-id="0bac6-123">Mappings are into a tile pool</span></span>](mappings-are-into-a-tile-pool.md)

 

 




