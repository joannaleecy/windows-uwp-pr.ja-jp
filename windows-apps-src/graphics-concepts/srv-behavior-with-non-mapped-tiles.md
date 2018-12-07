---
title: マップされていないタイルでの SRV 動作
description: マップされていないタイルに関連するシェーダー リソース ビュー (SRV) の読み取り動作は、ハードウェア サポートのレベルによって異なります。
ms.assetid: 0E1D64BE-EB09-4F9D-9800-BD23A3B374EE
keywords:
- マップされていないタイルでの SRV 動作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: d62a1d3158e13187f89277a1ba009bd56fc2b39a
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8785861"
---
# <a name="span-iddirect3dconceptssrvbehaviorwithnon-mappedtilesspansrv-behavior-with-non-mapped-tiles"></a><span data-ttu-id="6bbba-104"><span id="direct3dconcepts.srv_behavior_with_non-mapped_tiles"></span>マップされていないタイルでの SRV 動作</span><span class="sxs-lookup"><span data-stu-id="6bbba-104"><span id="direct3dconcepts.srv_behavior_with_non-mapped_tiles"></span>SRV behavior with non-mapped tiles</span></span>


<span data-ttu-id="6bbba-105">マップされていないタイルに関連するシェーダー リソース ビュー (SRV) の読み取り動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="6bbba-105">Behavior of shader resource view (SRV) reads that involve non-mapped tiles depends on the level of hardware support.</span></span> <span data-ttu-id="6bbba-106">要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の読み取りの動作をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6bbba-106">For a breakdown of requirements, see read behavior for [Streaming resources features tiers](streaming-resources-features-tiers.md).</span></span> <span data-ttu-id="6bbba-107">このセクションでは、[階層 2](tier-2.md) に必要な望ましい動作について概説します。</span><span class="sxs-lookup"><span data-stu-id="6bbba-107">This section summarizes the ideal behavior, which [Tier 2](tier-2.md) requires.</span></span>

<span data-ttu-id="6bbba-108">SRV 内の一連のテクセルから読み取るテクスチャ フィルター操作について考えます。</span><span class="sxs-lookup"><span data-stu-id="6bbba-108">Consider a texture filter operation that reads from a set of texels in an SRV.</span></span> <span data-ttu-id="6bbba-109">マップされているテクセルからの値の他、マップされていないタイルに適用されるテクセルからは、全体的なフィルター操作に対して、形式のコンポーネントのうち欠落していないものには 0 (欠落しているものには既定値) を返します。</span><span class="sxs-lookup"><span data-stu-id="6bbba-109">Texels that fall on non-mapped tiles contribute 0 in all non-missing components of the format (and the default for missing components) into the overall filter operation alongside contributions from mapped texels.</span></span> <span data-ttu-id="6bbba-110">データの提供元のタイルがマップされているかどうかを問わず、すべてのテクセルに重みが付けられ、組み合わされます。</span><span class="sxs-lookup"><span data-stu-id="6bbba-110">The texels are all weighted and combined together independent of whether the data came from mapped or non-mapped tiles.</span></span>

<span data-ttu-id="6bbba-111">一部の第一世代の[階層 2](tier-2.md) レベルのハードウェアはこの仕様要件を満たしていないため、いずれかのテクセル (0 以外の重み付き) がマップされていないタイルに適用される場合、全体のフィルター処理の結果として事前に記述されている既定値と併せて 0 を返します。</span><span class="sxs-lookup"><span data-stu-id="6bbba-111">Some first-generation [Tier 2](tier-2.md) level hardware does not meet this spec requirement, and returns the 0 with defaults described preceding as the overall filter result if any texels (with nonzero weight) fall on non-mapped tiles.</span></span> <span data-ttu-id="6bbba-112">その他のハードウェアでは、すべての (0 以外の重み付きの) テクセルをフィルターに含めるには、必ず要件を満たす必要があります。</span><span class="sxs-lookup"><span data-stu-id="6bbba-112">No other hardware will be allowed to miss the requirement to include all (nonzero weight) texels in the filter.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="6bbba-113"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="6bbba-113"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="6bbba-114">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="6bbba-114">Pipeline access to streaming resources</span></span>](pipeline-access-to-streaming-resources.md)

 

 




