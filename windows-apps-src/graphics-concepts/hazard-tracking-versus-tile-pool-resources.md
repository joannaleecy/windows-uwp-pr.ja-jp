---
title: ハザード追跡対タイル プール リソース
description: 非ストリーミング リソースでは、Direct3D は、レンダリング中に特定のハザード条件を防ぐことができますが、ストリーミング リソースの場合、ハザード追跡はタイル レベルで行われるため、ストリーミング リソースのレンダリング時のハザード条件の追跡はコストがかかりすぎます。
ms.assetid: 8B0C73D3-3F77-41E8-B17D-C595DEE39E49
keywords:
- ハザード追跡対タイル プール リソース
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e2ff4e2ff079e15c0af41e3232c4b70c582a6a25
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7558470"
---
# <a name="hazard-tracking-versus-tile-pool-resources"></a><span data-ttu-id="1297a-104">ハザード追跡対タイル プール リソース</span><span class="sxs-lookup"><span data-stu-id="1297a-104">Hazard tracking versus tile pool resources</span></span>


<span data-ttu-id="1297a-105">非ストリーミング リソースでは、Direct3D は、レンダリング中に特定のハザード条件を防ぐことができますが、ストリーミング リソースの場合、ハザード追跡はタイル レベルで行われるため、ストリーミング リソースのレンダリング時のハザード条件の追跡はコストがかかりすぎます。</span><span class="sxs-lookup"><span data-stu-id="1297a-105">For non-streaming resources, Direct3D can prevent certain hazard conditions during rendering, but because hazard tracking would be at a tile level for streaming resources, tracking hazard conditions during rendering of streaming resources might be too expensive.</span></span>

<span data-ttu-id="1297a-106">たとえば、非ストリーミング リソースでは、ランタイムが特定の SubResource を同時に入力 (シェーダー リソース ビューなど) および出力 (レンダー ターゲット ビュー) としてバインドすることはできません。このようなケースが発生すると、ランタイムは入力をバインド解除します。</span><span class="sxs-lookup"><span data-stu-id="1297a-106">For example, for non-streaming resources, the runtime doesn't allow any given SubResource to be bound as an input (such as a Shader Resource View) and as an output (such as a Render Target View) at the same time If such a case is encountered, the runtime unbinds the input.</span></span> <span data-ttu-id="1297a-107">ランタイムでのこの追跡のオーバーヘッドはコストが安く、サブリソース レベルで実行されます。</span><span class="sxs-lookup"><span data-stu-id="1297a-107">This tracking overhead in the runtime is cheap and is done at the subresource level.</span></span> <span data-ttu-id="1297a-108">この追跡オーバーヘッドの利点の 1 つは、アプリケーションが誤ってハードウェア シェーダーの実行順序に依存する可能性を最小限に抑えられることです。</span><span class="sxs-lookup"><span data-stu-id="1297a-108">One of the benefits of this tracking overhead is to minimize the chances of applications accidentally depending on hardware shader execution order.</span></span> <span data-ttu-id="1297a-109">ハードウェア シェーダーの実行順序は、特定のグラフィックス処理装置 (GPU) 上でなければ変化する可能性があり、異なる GPU では確実に異なります。</span><span class="sxs-lookup"><span data-stu-id="1297a-109">Hardware shader execution order can vary if not on a given graphics processing unit (GPU), then certainly across different GPUs.</span></span>

<span data-ttu-id="1297a-110">ストリーミング リソースの場合、リソースのバインド方法を追跡することは、タイル レベルでの追跡となるため、コストが高くなりすぎる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1297a-110">Tracking how resources are bound might be too expensive for streaming resources because tracking is at a tile level.</span></span> <span data-ttu-id="1297a-111">1 つのタイルがサーフェスの複数の領域に同時にマップされている場合、レンダー ターゲット ビューへのレンダリングの試行の検証など、新しい問題が発生します。</span><span class="sxs-lookup"><span data-stu-id="1297a-111">New issues arise such as possibly validating away attempts to render to a Render Target View with one tile mapped to multiple areas in the surface simultaneously.</span></span> <span data-ttu-id="1297a-112">ランタイムでこのタイルごとのハザード追跡のコストが高すぎる場合、少なくともこれをデバッグ レイヤーでのオプションにすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1297a-112">If it turns out this per-tile hazard tracking is too expensive for the runtime, ideally this would at least be an option in the debug layer.</span></span>

<span data-ttu-id="1297a-113">アプリケーションは、タイル プール メモリを参照するストリーミング リソースに対する書き込みまたは読み取り操作を発行したときに、そのタイル プール メモリが、次に発生する読み取りまたは書き込み操作で別のストリーミング リソースによって参照される場合、後続の操作を開始する前に最初の操作が完了することを想定していることをディスプレイ ドライバーに通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1297a-113">An application must inform the display driver when it has issued a write or read operation to a streaming resource that references tile pool memory that will also be referenced by separate streaming resources in upcoming read or write operations that it is expecting the first operation to complete before the following operations can begin.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1297a-114"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1297a-114"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1297a-115">タイル プールにマッピングされます</span><span class="sxs-lookup"><span data-stu-id="1297a-115">Mappings are into a tile pool</span></span>](mappings-are-into-a-tile-pool.md)

 

 




