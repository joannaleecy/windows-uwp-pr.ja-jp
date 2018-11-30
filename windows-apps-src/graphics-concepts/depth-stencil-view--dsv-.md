---
title: 深度ステンシル ビュー (DSV)
description: 深度ステンシル ビューは、深度とステンシルの情報を保持するための形式とバッファーを提供します。
ms.assetid: 2E8BFF7F-76F8-408E-B8E6-A71B9DF46281
keywords:
- 深度ステンシル ビュー (DSV)
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 69e726291cc9bd79cb96b1b1460c4027aee9c0b7
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8326194"
---
# <a name="depth-stencil-view-dsv"></a><span data-ttu-id="7cb34-104">深度ステンシル ビュー (DSV)</span><span class="sxs-lookup"><span data-stu-id="7cb34-104">Depth stencil view (DSV)</span></span>


<span data-ttu-id="7cb34-105">深度ステンシル ビューは、深度とステンシルの情報を保持するための形式とバッファーを提供します。</span><span class="sxs-lookup"><span data-stu-id="7cb34-105">A depth stencil view provides the format and buffer for holding depth and stencil information.</span></span> <span data-ttu-id="7cb34-106">深度バッファーは、近くにあるオブジェクトによって視界から遮られる、ビューアーには見えないピクセルの描画を省くために使われます。</span><span class="sxs-lookup"><span data-stu-id="7cb34-106">The depth buffer is used to cull the drawing of pixels that would be invisible to the viewer as they are occluded from view by a closer object.</span></span> <span data-ttu-id="7cb34-107">ステンシル バッファーを使って、定義した図形以外のすべての描画をカリングすることができます。</span><span class="sxs-lookup"><span data-stu-id="7cb34-107">The stencil buffer can be used to cull all drawing outside of a defined shape.</span></span>

<span data-ttu-id="7cb34-108">レンダリング領域の定義以外に、ステンシル バッファーには高度な使用方法が数多くあります。</span><span class="sxs-lookup"><span data-stu-id="7cb34-108">There are a number of more advanced uses of stencil buffers beyond defining a rendering area.</span></span> <span data-ttu-id="7cb34-109">ステンシル バッファーの値を操作することにより、フェード、シルエット、デカール、ディゾルブ、アウトライン、シャドウ ボリュームなどの効果を提供できます。</span><span class="sxs-lookup"><span data-stu-id="7cb34-109">Stencil buffer values can be manipulated to give such effects as fades, silhouettes, decaling, dissolves, outlining, shadow volumes, and so on.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="7cb34-110"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="7cb34-110"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="7cb34-111">ビュー</span><span class="sxs-lookup"><span data-stu-id="7cb34-111">Views</span></span>](views.md)

 

 




