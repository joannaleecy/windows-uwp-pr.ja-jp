---
title: 深度ステンシル ビュー (DSV)
description: 深度ステンシル ビューは、深度とステンシルの情報を保持するための形式とバッファーを提供します。
ms.assetid: 2E8BFF7F-76F8-408E-B8E6-A71B9DF46281
keywords:
- 深度ステンシル ビュー (DSV)
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: eee30882373513bd352777aff0ae6399f047bbec
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1044151"
---
# <a name="depth-stencil-view-dsv"></a><span data-ttu-id="d2f11-104">深度ステンシル ビュー (DSV)</span><span class="sxs-lookup"><span data-stu-id="d2f11-104">Depth stencil view (DSV)</span></span>


<span data-ttu-id="d2f11-105">深度ステンシル ビューは、深度とステンシルの情報を保持するための形式とバッファーを提供します。</span><span class="sxs-lookup"><span data-stu-id="d2f11-105">A depth stencil view provides the format and buffer for holding depth and stencil information.</span></span> <span data-ttu-id="d2f11-106">深度バッファーは、近くにあるオブジェクトによって視界から遮られる、ビューアーには見えないピクセルの描画を省くために使われます。</span><span class="sxs-lookup"><span data-stu-id="d2f11-106">The depth buffer is used to cull the drawing of pixels that would be invisible to the viewer as they are occluded from view by a closer object.</span></span> <span data-ttu-id="d2f11-107">ステンシル バッファーを使って、定義した図形以外のすべての描画をカリングすることができます。</span><span class="sxs-lookup"><span data-stu-id="d2f11-107">The stencil buffer can be used to cull all drawing outside of a defined shape.</span></span>

<span data-ttu-id="d2f11-108">レンダリング領域の定義以外に、ステンシル バッファーには高度な使用方法が数多くあります。</span><span class="sxs-lookup"><span data-stu-id="d2f11-108">There are a number of more advanced uses of stencil buffers beyond defining a rendering area.</span></span> <span data-ttu-id="d2f11-109">ステンシル バッファーの値を操作することにより、フェード、シルエット、デカール、ディゾルブ、アウトライン、シャドウ ボリュームなどの効果を提供できます。</span><span class="sxs-lookup"><span data-stu-id="d2f11-109">Stencil buffer values can be manipulated to give such effects as fades, silhouettes, decaling, dissolves, outlining, shadow volumes, and so on.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="d2f11-110"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="d2f11-110"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="d2f11-111">ビュー</span><span class="sxs-lookup"><span data-stu-id="d2f11-111">Views</span></span>](views.md)

 

 




