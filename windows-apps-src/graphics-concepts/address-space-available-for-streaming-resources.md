---
title: ストリーミング リソースに利用可能なアドレス空間
description: このセクションでは、リソースのストリーミングに利用できる仮想アドレス空間を指定します。
ms.assetid: 145EB4A3-3910-4126-BC7E-A4CF53E2A098
keywords:
- ストリーミング リソースに利用可能なアドレス空間
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 35a591d805870df97ee03169b20e664316e094a7
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8732997"
---
# <a name="address-space-available-for-streaming-resources"></a><span data-ttu-id="45bb0-104">ストリーミング リソースに利用可能なアドレス空間</span><span class="sxs-lookup"><span data-stu-id="45bb0-104">Address space available for streaming resources</span></span>


<span data-ttu-id="45bb0-105">このセクションでは、リソースのストリーミングに利用できる仮想アドレス空間を指定します。</span><span class="sxs-lookup"><span data-stu-id="45bb0-105">This section specifies the virtual address space that is available for streaming resources.</span></span>

<span data-ttu-id="45bb0-106">64 ビット オペレーティング システムでは、少なくとも 40 ビットの仮想アドレス空間 (1テラバイト) が利用可能です。</span><span class="sxs-lookup"><span data-stu-id="45bb0-106">On 64-bit operating systems, at least 40 bits of virtual address space (1 Terabyte) is available.</span></span>

<span data-ttu-id="45bb0-107">32 ビット オペレーティング システムの場合、アドレス空間は 32 ビット (4 GB) です。</span><span class="sxs-lookup"><span data-stu-id="45bb0-107">For 32-bit operating systems, the address space is 32 bit (4 GB).</span></span> <span data-ttu-id="45bb0-108">32 ビット ARM システムでは、27 ビットを超えるアドレス空間 (128 MB) を割り当てで使用すると、個々のストリーミング リソースの作成が失敗する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="45bb0-108">For 32-bit ARM systems, individual streaming resource creation can fail if the allocation would use more than 27 bits of address space (128 MB).</span></span> <span data-ttu-id="45bb0-109">これには、ミップマップ、パッキングされたタイル パディング、または 2 の累乗のパディング サーフェス ディメンションなどのために、ハードウェアが使用する可能性がある、アドレス空間内の隠れたパディングが含まれます。</span><span class="sxs-lookup"><span data-stu-id="45bb0-109">This includes any hidden padding in the address space the hardware may use for mipmaps, packed tile padding, and possibly padding surface dimensions to powers of 2.</span></span>

<span data-ttu-id="45bb0-110">グラフィックス処理装置 (GPU) のための別個のページ テーブルを持つグラフィックス システムでは、このアドレス空間の大部分はアプリケーションによって作られた GPU リソースに対して利用可能となりますが、ディスプレイ ドライバーによって行われる GPU 割り当ては同じ空間に収まります。</span><span class="sxs-lookup"><span data-stu-id="45bb0-110">On graphics systems with a separate page table for the graphics processing unit (GPU), most of this address space will be available to GPU resources made by the application, though GPU allocations made by the display driver fit in the same space.</span></span>

<span data-ttu-id="45bb0-111">CPU と GPU の間で共有されるページ テーブルを持つ将来のシステムでは、使用可能なアドレス空間は、プロセス内のすべての CPU と GPU 割り当ての間で共有されます。</span><span class="sxs-lookup"><span data-stu-id="45bb0-111">On future systems with a page table shared between the CPU and GPU, the available address space is shared between all CPU and GPU allocations in a process.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="45bb0-112"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="45bb0-112"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="45bb0-113">ストリーミング リソースの作成パラメーター</span><span class="sxs-lookup"><span data-stu-id="45bb0-113">Streaming resource creation parameters</span></span>](streaming-resource-creation-parameters.md)

 

 




