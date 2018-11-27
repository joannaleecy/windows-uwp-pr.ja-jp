---
title: マップされていないタイルでの UAV 動作
description: 順序指定されていないアクセス ビュー (UAV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。
ms.assetid: CDB224E2-CC07-4568-9AAC-C8DC74536561
keywords:
- マップされていないタイルでの UAV 動作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c72931d2f6bf1e892e174bc409f20a042d5e4c92
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7704330"
---
# <a name="span-iddirect3dconceptsuavbehaviorwithnon-mappedtilesspanuav-behavior-with-non-mapped-tiles"></a><span data-ttu-id="96487-104"><span id="direct3dconcepts.uav_behavior_with_non-mapped_tiles"></span>マップされていないタイルでの UAV 動作</span><span class="sxs-lookup"><span data-stu-id="96487-104"><span id="direct3dconcepts.uav_behavior_with_non-mapped_tiles"></span>UAV behavior with non-mapped tiles</span></span>


<span data-ttu-id="96487-105">順序指定されていないアクセス ビュー (UAV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="96487-105">Behavior of unordered access view (UAV) reads and writes depends on the level of hardware support.</span></span> <span data-ttu-id="96487-106">要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の全体の読み取りと書き込みの動作をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96487-106">For a breakdown of requirements, see overall read and write behavior for [Streaming resources features tiers](streaming-resources-features-tiers.md).</span></span> <span data-ttu-id="96487-107">このセクションでは、望ましい動作について概説します。</span><span class="sxs-lookup"><span data-stu-id="96487-107">This section summarizes the ideal behavior.</span></span>

<span data-ttu-id="96487-108">UAV 内のマップされていないタイルから読み取りを行うシェーダー操作は、形式の欠落していないすべてのコンポーネントでは 0 を返し、欠落しているコンポーネントでは既定値を返します。</span><span class="sxs-lookup"><span data-stu-id="96487-108">Shader operations that read from a non-mapped tile in a UAV return 0 in all non-missing components of the format, and the default for missing components.</span></span>

<span data-ttu-id="96487-109">マップされていないタイルへの書き込みを試みるシェーダー操作では、マップされていない領域には何も書き込みません (マップされた領域への書き込みは続行されます)。</span><span class="sxs-lookup"><span data-stu-id="96487-109">Shader operations that attempt to write to a non-mapped tile cause nothing to be written to the non-mapped area (while writes to a mapped area proceed).</span></span> <span data-ttu-id="96487-110">書き込み処理に関するこの理想的な定義は、[階層 2](tier-2.md) では求められません。マップされていないタイルへの書き込みは最終的にキャッシュに格納され、その後の読み取りで取得される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="96487-110">This ideal definition for write handling is not required by [Tier 2](tier-2.md); writes to non-mapped tiles can end up in a cache that subsequent reads could pick up.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="96487-111"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="96487-111"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="96487-112">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="96487-112">Pipeline access to streaming resources</span></span>](pipeline-access-to-streaming-resources.md)

 

 




