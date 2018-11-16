---
title: ストリーミング リソースで利用可能な操作
description: このセクションでは、ストリーミング リソースで実行できる操作を示します。
ms.assetid: 700D8C54-0E20-4B2B-BEA3-20F6F72B8E24
keywords:
- ストリーミング リソースで利用可能な操作
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1289b01e7ffb780c7e3faa52585eb5f002cf519c
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6848659"
---
# <a name="operations-available-on-streaming-resources"></a><span data-ttu-id="9fef5-104">ストリーミング リソースで利用可能な操作</span><span class="sxs-lookup"><span data-stu-id="9fef5-104">Operations available on streaming resources</span></span>


<span data-ttu-id="9fef5-105">このセクションでは、ストリーミング リソースで実行できる操作を示します。</span><span class="sxs-lookup"><span data-stu-id="9fef5-105">This section lists operations that you can perform on streaming resources.</span></span>

-   <span data-ttu-id="9fef5-106">void を返すタイル マッピングの更新操作、および void を返すタイル マッピングのコピー操作 - これらの操作は、ストリーミング リソース内のタイル位置をタイル プール内の位置、NULL、またはその両方にポイントします。</span><span class="sxs-lookup"><span data-stu-id="9fef5-106">Update Tile Mappings operations that return void, and Copy Tile Mappings operations that return void - These operations point tile locations in a streaming resource to locations in tile pools, or to NULL, or to both.</span></span> <span data-ttu-id="9fef5-107">これらの操作では、タイル ポインターの分離したサブセットを更新できます。</span><span class="sxs-lookup"><span data-stu-id="9fef5-107">These operations can update a disjoint subset of the tile pointers.</span></span>
-   <span data-ttu-id="9fef5-108">コピーおよび更新操作 - 既定のプール サーフェスとの間でデータをコピーできるすべての API は、ストリーミング リソースで機能します。</span><span class="sxs-lookup"><span data-stu-id="9fef5-108">Copy and Update operations - All the APIs that can copy data to and from a default pool surface work for streaming resources.</span></span> <span data-ttu-id="9fef5-109">マップされていないタイルからの読み取りは 0 を生成し、マップされていないタイルへの書き込みは破棄されます。</span><span class="sxs-lookup"><span data-stu-id="9fef5-109">Reading from unmapped tiles produces 0 and writes to unmapped tiles are dropped.</span></span>
-   <span data-ttu-id="9fef5-110">タイルのコピーおよびタイルの更新操作 - これらの操作は、正規メモリ レイアウト内のストリーミング リソースおよびバッファー リソースとの間で、64 KB の精度でタイルをコピーするために存在します。</span><span class="sxs-lookup"><span data-stu-id="9fef5-110">Copy Tiles and Update Tiles operations - These operations exist for copying tiles at 64KB granularity to and from any streaming resource and a buffer resource in a canonical memory layout.</span></span> <span data-ttu-id="9fef5-111">ディスプレイ ドライバーとハードウェアは、ストリーミング リソースに必要なメモリ "スウィズル" を実行します。</span><span class="sxs-lookup"><span data-stu-id="9fef5-111">The display driver and hardware perform any memory "swizzling" necessary for the streaming resource.</span></span>
-   <span data-ttu-id="9fef5-112">非ストリーミング リソースで機能する Direct3D パイプライン バインドとビューの作成/バインドは、ストリーミング リソースでも機能します。</span><span class="sxs-lookup"><span data-stu-id="9fef5-112">Direct3D pipeline bindings and view creations / bindings that would work on non-streaming resources work on streaming resources as well.</span></span>

<span data-ttu-id="9fef5-113">タイル コントロールは、イミディエイト コンテキストまたは遅延コンテキストで使うことができ (一般的なリソースの更新と同様)、実行するとタイルへのその後のアクセス (以前に送信された操作ではなく) に影響が及びます。</span><span class="sxs-lookup"><span data-stu-id="9fef5-113">Tile controls are available on immediate or deferred contexts (just like updates to typical resources) and upon execution impact subsequent accesses to the tiles (not previously submitted operations).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="9fef5-114"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="9fef5-114"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="9fef5-115">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="9fef5-115">Creating streaming resources</span></span>](creating-streaming-resources.md)

 

 




