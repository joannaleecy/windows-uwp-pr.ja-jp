---
title: タイル プールの作成
description: アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。 各タイル プールの合計サイズは、グラフィックス処理装置 (GPU) メモリの 1/4 ではほぼ Direct3D11 のリソース サイズ制限に制限されます。
ms.assetid: BD51EDD3-4AD3-4733-B014-DD77B9D743BB
keywords:
- タイル プールの作成
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: cbb8b61c8eeef1a842a7c6b61d09670f056bb409
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5834045"
---
# <a name="tile-pool-creation"></a><span data-ttu-id="df898-105">タイル プールの作成</span><span class="sxs-lookup"><span data-stu-id="df898-105">Tile pool creation</span></span>


<span data-ttu-id="df898-106">アプリケーションは、Direct3D デバイスごとに 1 つ以上のタイル プールを作成できます。</span><span class="sxs-lookup"><span data-stu-id="df898-106">Applications can create one or more tile pools per Direct3D device.</span></span> <span data-ttu-id="df898-107">各タイル プールの合計サイズは、グラフィックス処理装置 (GPU) メモリの 1/4 ではほぼ Direct3D11 のリソース サイズ制限に制限されます。</span><span class="sxs-lookup"><span data-stu-id="df898-107">The total size of each tile pool is restricted to Direct3D11's resource size limit, which is roughly 1/4 of graphics processing unit (GPU) RAM.</span></span>

<span data-ttu-id="df898-108">タイル プールは 64 KB のタイルで構成されますが、舞台裏ではオペレーティング システム (ディスプレイ ドライバー) が 1 つ以上の割り当てとしてプール全体を管理します。処理の詳細はアプリケーションには見えません。</span><span class="sxs-lookup"><span data-stu-id="df898-108">A tile pool is made of 64KB tiles, but the operating system (display driver) manages the entire pool as one or more allocations behind the scenes—the breakdown is not visible to applications.</span></span> <span data-ttu-id="df898-109">ストリーミング リソースは、タイル プール内のタイルをポイントしてコンテンツを定義します。</span><span class="sxs-lookup"><span data-stu-id="df898-109">Streaming resources define content by pointing at tiles within a tile pool.</span></span> <span data-ttu-id="df898-110">ストリーミング リソースからのタイルのマッピング解除は、タイルに **NULL** を指させることで行われます。</span><span class="sxs-lookup"><span data-stu-id="df898-110">Unmapping a tile from a streaming resource is done by pointing the tile to **NULL**.</span></span> <span data-ttu-id="df898-111">このようなマップされていないタイルには、読み書きの動作に関する規則があります。詳しくは、「[ハザード追跡対タイル プール リソース](hazard-tracking-versus-tile-pool-resources.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="df898-111">Such unmapped tiles have rules about the behavior of reads or writes; see [Hazard tracking versus tile pool resources](hazard-tracking-versus-tile-pool-resources.md).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="df898-112"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="df898-112"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="df898-113">タイル プールにマッピングされます</span><span class="sxs-lookup"><span data-stu-id="df898-113">Mappings are into a tile pool</span></span>](mappings-are-into-a-tile-pool.md)

 

 




