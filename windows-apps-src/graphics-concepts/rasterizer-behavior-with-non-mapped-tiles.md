---
title: マップされていないタイルでのラスタライザー動作
description: このセクションでは、マップされていないタイルを使用したラスタライザー動作について説明します。
ms.assetid: AC7B818D-E52B-4727-AEA2-39CFDC279CE7
keywords:
- マップされていないタイルでのラスタライザー動作
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e3089444820f990644526eaafb7f2ef9007fa70a
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8345040"
---
# <a name="span-iddirect3dconceptsrasterizerbehaviorwithnon-mappedtilesspanrasterizer-behavior-with-non-mapped-tiles"></a><span data-ttu-id="8dcde-104"><span id="direct3dconcepts.rasterizer_behavior_with_non-mapped_tiles"></span>マップされていないタイルでのラスタライザー動作</span><span class="sxs-lookup"><span data-stu-id="8dcde-104"><span id="direct3dconcepts.rasterizer_behavior_with_non-mapped_tiles"></span>Rasterizer behavior with non-mapped tiles</span></span>


<span data-ttu-id="8dcde-105">このセクションでは、マップされていないタイルを使用したラスタライザー動作について説明します。</span><span class="sxs-lookup"><span data-stu-id="8dcde-105">This section describes rasterizer behavior with non-mapped tiles.</span></span>

## <a name="span-iddepthstencilviewspanspan-iddepthstencilviewspanspan-iddepthstencilviewspandepthstencilview"></a><span data-ttu-id="8dcde-106"><span id="DepthStencilView"></span><span id="depthstencilview"></span><span id="DEPTHSTENCILVIEW"></span>DepthStencilView</span><span class="sxs-lookup"><span data-stu-id="8dcde-106"><span id="DepthStencilView"></span><span id="depthstencilview"></span><span id="DEPTHSTENCILVIEW"></span>DepthStencilView</span></span>


<span data-ttu-id="8dcde-107">深度ステンシル ビュー (DSV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="8dcde-107">Behavior of depth stencil view (DSV) reads and writes depends on the level of hardware support.</span></span> <span data-ttu-id="8dcde-108">要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の全体の読み取りと書き込みの動作をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8dcde-108">For a breakdown of requirements, see overall read and write behavior for [Streaming resources features tiers](streaming-resources-features-tiers.md).</span></span>

<span data-ttu-id="8dcde-109">最適な動作を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8dcde-109">Here is the ideal behavior:</span></span>

<span data-ttu-id="8dcde-110">DepthStencilView でタイルがマップされていない場合、深度の読み取りによる戻り値は 0 です。その後、この値が、深度の読み取り値に対して構成されたすべての処理に渡されます。</span><span class="sxs-lookup"><span data-stu-id="8dcde-110">If a tile isn't mapped in the DepthStencilView, the return value from reading depth is 0, which is then fed into whatever operations are configured for the depth read value.</span></span> <span data-ttu-id="8dcde-111">存在しない深度タイルへの書き込みは破棄されます。</span><span class="sxs-lookup"><span data-stu-id="8dcde-111">Writes to the missing depth tile are dropped.</span></span> <span data-ttu-id="8dcde-112">書き込み処理について、このような最適な定義は[階層 2](tier-2.md) では必要ありません。マップされていないタイルへの書き込みは最終的にキャッシュに格納され、その後の読み取りではこのキャッシュが取得される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8dcde-112">This ideal definition for write handling is not required by [Tier 2](tier-2.md); writes to non-mapped tiles can end up in a cache that subsequent reads could pick up.</span></span>

## <a name="span-idrendertargetviewspanspan-idrendertargetviewspanspan-idrendertargetviewspanrendertargetview"></a><span data-ttu-id="8dcde-113"><span id="RenderTargetView"></span><span id="rendertargetview"></span><span id="RENDERTARGETVIEW"></span>RenderTargetView</span><span class="sxs-lookup"><span data-stu-id="8dcde-113"><span id="RenderTargetView"></span><span id="rendertargetview"></span><span id="RENDERTARGETVIEW"></span>RenderTargetView</span></span>


<span data-ttu-id="8dcde-114">レンダー ターゲット ビュー (RTV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="8dcde-114">Behavior of render target view (RTV) reads and writes depends on the level of hardware support.</span></span> <span data-ttu-id="8dcde-115">要件について詳しくは、「[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)」の全体の読み取りと書き込みの動作をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8dcde-115">For a breakdown of requirements, see overall read and write behavior for [Streaming resources features tiers](streaming-resources-features-tiers.md).</span></span>

<span data-ttu-id="8dcde-116">すべての実装において、異なる RTV (および DSV) が同時にバインドされると、さまざまな領域でマップされた領域とマップされていない領域が発生し、さまざまなサイズのサーフェス形式 (つまり、さまざまなタイルの形状) が生じる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8dcde-116">On all implementations, different RTVs (and DSV) bound simultaneously can have different areas mapped versus non-mapped and can have different sized surface formats (which means different tile shapes).</span></span>

<span data-ttu-id="8dcde-117">最適な動作を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8dcde-117">Here is the ideal behavior:</span></span>

<span data-ttu-id="8dcde-118">RTV からの読み取りでは、存在しないタイルにおいては 0 が返され、書き込みが破棄されます。</span><span class="sxs-lookup"><span data-stu-id="8dcde-118">Reads from RTVs return 0 in missing tiles and writes are dropped.</span></span> <span data-ttu-id="8dcde-119">書き込み処理について、このような最適な定義は[階層 2](tier-2.md) では必要ありません。マップされていないタイルへの書き込みは最終的にキャッシュに格納され、その後の読み取りではこのキャッシュが取得される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8dcde-119">This ideal definition for write handling is not required by [Tier 2](tier-2.md); writes to non-mapped tiles can end up in a cache that subsequent reads could pick up.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="8dcde-120"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="8dcde-120"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="8dcde-121">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="8dcde-121">Pipeline access to streaming resources</span></span>](pipeline-access-to-streaming-resources.md)

 

 




