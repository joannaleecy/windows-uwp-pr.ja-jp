---
title: タイル プールの作成
description: アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、Direct3D 11 のリソース サイズの上限に制限されます。上限はグラフィックス処理装置 (GPU) の RAM の約 1/4 です。
ms.assetid: BD51EDD3-4AD3-4733-B014-DD77B9D743BB
keywords:
- タイル プールの作成
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 4336d38bca354da3c30cfe2d7e4b092cff15af83
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1043591"
---
# <a name="tile-pool-creation"></a><span data-ttu-id="dfd91-105">タイル プールの作成</span><span class="sxs-lookup"><span data-stu-id="dfd91-105">Tile pool creation</span></span>


<span data-ttu-id="dfd91-106">アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。</span><span class="sxs-lookup"><span data-stu-id="dfd91-106">Applications can create one or more tile pools per Direct3D device.</span></span> <span data-ttu-id="dfd91-107">各タイル プールの合計サイズは、Direct3D 11 のリソース サイズの上限に制限されます。上限はグラフィックス処理装置 (GPU) の RAM の約 1/4 です。</span><span class="sxs-lookup"><span data-stu-id="dfd91-107">The total size of each tile pool is restricted to Direct3D 11's resource size limit, which is roughly 1/4 of graphics processing unit (GPU) RAM.</span></span>

<span data-ttu-id="dfd91-108">タイル プールは 64 KB のタイルで構成されますが、舞台裏ではオペレーティング システム (ディスプレイ ドライバー) が 1 つ以上の割り当てとしてプール全体を管理します。処理の詳細はアプリケーションには見えません。</span><span class="sxs-lookup"><span data-stu-id="dfd91-108">A tile pool is made of 64KB tiles, but the operating system (display driver) manages the entire pool as one or more allocations behind the scenes—the breakdown is not visible to applications.</span></span> <span data-ttu-id="dfd91-109">ストリーミング リソースは、タイル プール内のタイルをポイントしてコンテンツを定義します。</span><span class="sxs-lookup"><span data-stu-id="dfd91-109">Streaming resources define content by pointing at tiles within a tile pool.</span></span> <span data-ttu-id="dfd91-110">ストリーミング リソースからのタイルのマッピング解除は、タイルに **NULL** を指させることで行われます。</span><span class="sxs-lookup"><span data-stu-id="dfd91-110">Unmapping a tile from a streaming resource is done by pointing the tile to **NULL**.</span></span> <span data-ttu-id="dfd91-111">このようなマップされていないタイルには、読み書きの動作に関する規則があります。詳しくは、「[ハザード追跡対タイル プール リソース](hazard-tracking-versus-tile-pool-resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="dfd91-111">Such unmapped tiles have rules about the behavior of reads or writes; see [Hazard tracking versus tile pool resources](hazard-tracking-versus-tile-pool-resources.md).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="dfd91-112"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="dfd91-112"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="dfd91-113">タイル プールにマッピングされます</span><span class="sxs-lookup"><span data-stu-id="dfd91-113">Mappings are into a tile pool</span></span>](mappings-are-into-a-tile-pool.md)

 

 




