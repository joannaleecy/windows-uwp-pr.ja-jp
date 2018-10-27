---
title: バッファーのタイリング
description: バッファー リソースは 64 KB のタイルに分割されます。サイズが 64 KB の倍数でない場合は、最後のタイルに空きが生じます。
ms.assetid: 577DC6B0-F373-4748-AD80-2784C597C366
keywords:
- バッファーのタイリング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1817f501962ccae4cfaf9c0ce075724abd5e7672
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5682093"
---
# <a name="buffer-tiling"></a><span data-ttu-id="96b08-104">バッファーのタイリング</span><span class="sxs-lookup"><span data-stu-id="96b08-104">Buffer tiling</span></span>


<span data-ttu-id="96b08-105">[バッファー ](introduction-to-buffers.md) リソースは 64 KB のタイルに分割されます。サイズが 64 KB の倍数でない場合は、最後のタイルに空きが生じます。</span><span class="sxs-lookup"><span data-stu-id="96b08-105">A [Buffer](introduction-to-buffers.md) resource is divided into 64KB tiles, with some empty space in the last tile if the size is not a multiple of 64KB.</span></span>

<span data-ttu-id="96b08-106">構造化バッファーでは、タイリングのストライドに制約があってはなりません。</span><span class="sxs-lookup"><span data-stu-id="96b08-106">Structured buffers must have no constraint on the stride to be tiled.</span></span> <span data-ttu-id="96b08-107">しかし、[**StructuredBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff471514) を使用するためのハードウェアで可能となるパフォーマンスの最適化が、最初にタイリングを行うことにより損なわれる場合があります。</span><span class="sxs-lookup"><span data-stu-id="96b08-107">But possible performance optimizations in hardware for using [**StructuredBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff471514) can be sacrificed by making them tiled in the first place.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="96b08-108"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="96b08-108"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="96b08-109">ストリーミング リソースの領域をタイル表示する方法</span><span class="sxs-lookup"><span data-stu-id="96b08-109">How a streaming resource's area is tiled</span></span>](how-a-streaming-resource-s-area-is-tiled.md)

 

 




