---
title: ストリーミング リソースでサポートされていないステンシルの書式
description: ステンシルを含む書式は、ストリーミング リソースではサポートされません。
ms.assetid: 90A572A4-3C76-4795-BAE9-FCC72B5F07AD
keywords:
- ストリーミング リソースでサポートされていないステンシルの書式
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1d35813a6242abd555e87329c25a413285d1d948
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57660987"
---
# <a name="stencil-formats-not-supported-with-streaming-resources"></a><span data-ttu-id="77582-104">ストリーミング リソースでサポートされていないステンシルの書式</span><span class="sxs-lookup"><span data-stu-id="77582-104">Stencil formats not supported with streaming resources</span></span>


<span data-ttu-id="77582-105">ステンシルを含む書式は、ストリーミング リソースではサポートされません。</span><span class="sxs-lookup"><span data-stu-id="77582-105">Formats that contain stencil aren't supported with streaming resources.</span></span>

<span data-ttu-id="77582-106">ステンシルが含まれている形式は、DXGI\_形式\_D24\_UNORM\_S8\_UINT (および関連 R24G8 ファミリの形式) と DXGI\_形式\_D32\_FLOAT\_S8X24\_UINT (および関連 R32G8X24 ファミリの形式)。</span><span class="sxs-lookup"><span data-stu-id="77582-106">Formats that contain stencil include DXGI\_FORMAT\_D24\_UNORM\_S8\_UINT (and related formats in the R24G8 family) and DXGI\_FORMAT\_D32\_FLOAT\_S8X24\_UINT (and related formats in the R32G8X24 family).</span></span>

<span data-ttu-id="77582-107">深度とステンシルを別々の割り当てに保存する実装もあれば、一緒に保存する実装もあります。</span><span class="sxs-lookup"><span data-stu-id="77582-107">Some implementations store depth and stencil in separate allocations while others store them together.</span></span> <span data-ttu-id="77582-108">これら 2 つのスキーマ間でタイルの管理方法を変える必要がありますが、違いを抽象化または合理化できる単一の API はありません。</span><span class="sxs-lookup"><span data-stu-id="77582-108">Tile management for the two schemes would have to be different, and no single API can abstract or rationalize the differences.</span></span> <span data-ttu-id="77582-109">今後のハードウェアでは、深度とステンシルで個別のサーフェスをサポートし、それぞれにタイルを用意することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="77582-109">We recommend for future hardware to support independent depth and stencil surfaces, each independently tiled.</span></span>

<span data-ttu-id="77582-110">32 ビットの深度には 128 x 128 のタイル、8 ビットのステンシルには 256 x 256 タイルがあります。</span><span class="sxs-lookup"><span data-stu-id="77582-110">32-bit depth would have 128x128 tiles, and 8-bit stencil would have 256x256 tiles.</span></span> <span data-ttu-id="77582-111">したがって、アプリケーションは深度とステンシル間のタイルの図形の不一致に対応する必要があります。</span><span class="sxs-lookup"><span data-stu-id="77582-111">Therefore, applications would have to live with tile shape misalignment between depth and stencil.</span></span> <span data-ttu-id="77582-112">ただし、他のレンダー ターゲット サーフェスの書式にも、これと同じ問題が既に存在します。</span><span class="sxs-lookup"><span data-stu-id="77582-112">But the same problem exists with different render target surface formats already.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="77582-113"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="77582-113"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="77582-114">ストリーミング プロセス間のリソースとデバイスの共有</span><span class="sxs-lookup"><span data-stu-id="77582-114">Streaming resource cross-process and device sharing</span></span>](streaming-resource-cross-process-and-device-sharing.md)

 

 




