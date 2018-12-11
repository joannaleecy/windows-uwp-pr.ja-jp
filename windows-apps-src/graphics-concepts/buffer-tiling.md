---
title: バッファーのタイリング
description: バッファー リソースは 64 KB のタイルに分割されます。サイズが 64 KB の倍数でない場合は、最後のタイルに空きが生じます。
ms.assetid: 577DC6B0-F373-4748-AD80-2784C597C366
keywords:
- バッファーのタイリング
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: f3e5e117e05cef478ede508240a6b1d1022dea70
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8887121"
---
# <a name="buffer-tiling"></a><span data-ttu-id="489c7-104">バッファーのタイリング</span><span class="sxs-lookup"><span data-stu-id="489c7-104">Buffer tiling</span></span>


<span data-ttu-id="489c7-105">[バッファー ](introduction-to-buffers.md) リソースは 64 KB のタイルに分割されます。サイズが 64 KB の倍数でない場合は、最後のタイルに空きが生じます。</span><span class="sxs-lookup"><span data-stu-id="489c7-105">A [Buffer](introduction-to-buffers.md) resource is divided into 64KB tiles, with some empty space in the last tile if the size is not a multiple of 64KB.</span></span>

<span data-ttu-id="489c7-106">構造化バッファーでは、タイリングのストライドに制約があってはなりません。</span><span class="sxs-lookup"><span data-stu-id="489c7-106">Structured buffers must have no constraint on the stride to be tiled.</span></span> <span data-ttu-id="489c7-107">しかし、[**StructuredBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff471514) を使用するためのハードウェアで可能となるパフォーマンスの最適化が、最初にタイリングを行うことにより損なわれる場合があります。</span><span class="sxs-lookup"><span data-stu-id="489c7-107">But possible performance optimizations in hardware for using [**StructuredBuffers**](https://msdn.microsoft.com/library/windows/desktop/ff471514) can be sacrificed by making them tiled in the first place.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="489c7-108"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="489c7-108"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="489c7-109">ストリーミング リソースの領域をタイル表示する方法</span><span class="sxs-lookup"><span data-stu-id="489c7-109">How a streaming resource's area is tiled</span></span>](how-a-streaming-resource-s-area-is-tiled.md)

 

 




