---
title: ストリーミング リソースのプロセスとデバイス間での共有
description: タイル プールは、従来のリソースと同様に、他のプロセスと共有することができます。 タイル プールを参照するストリーミング リソースは、デバイスやプロセス間で共有できません。
ms.assetid: D035AF4B-D71B-4F20-9A98-7C360BF9B285
keywords:
- ストリーミング リソースのプロセスとデバイス間での共有
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a0bff43cfd26c43bb5f75f37a66c55e556429470
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593667"
---
# <a name="span-iddirect3dconceptsstreaming-resource-cross-process-and-device-sharingspanstreaming-resource-cross-process-and-device-sharing"></a><span data-ttu-id="0933e-105"><span id="direct3dconcepts.streaming-resource-cross-process-and-device-sharing"></span>ストリーミング プロセス間のリソースとデバイスの共有</span><span class="sxs-lookup"><span data-stu-id="0933e-105"><span id="direct3dconcepts.streaming-resource-cross-process-and-device-sharing"></span>Streaming resource cross-process and device sharing</span></span>


<span data-ttu-id="0933e-106">タイル プールは、従来のリソースと同様に、他のプロセスと共有することができます。</span><span class="sxs-lookup"><span data-stu-id="0933e-106">Tile pools can be shared with other processes just like traditional resources.</span></span> <span data-ttu-id="0933e-107">タイル プールを参照するストリーミング リソースは、デバイスやプロセス間で共有できません。</span><span class="sxs-lookup"><span data-stu-id="0933e-107">Streaming resources that reference tile pools can't be shared across devices and processes.</span></span> <span data-ttu-id="0933e-108">ただし、個々のプロセスで独自のストリーミング リソースを作成し、これらのストリーミング リソース間で共有されるタイル プールにマップできます。</span><span class="sxs-lookup"><span data-stu-id="0933e-108">But separate processes can create their own streaming resources that map to tile pools that are shared between those streaming resources.</span></span>

<span data-ttu-id="0933e-109">共有タイル プールのサイズは変更できません。</span><span class="sxs-lookup"><span data-stu-id="0933e-109">Shared tile pools can't be resized.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="0933e-110"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="0933e-110"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="0933e-111">トピック</span><span class="sxs-lookup"><span data-stu-id="0933e-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="0933e-112">説明</span><span class="sxs-lookup"><span data-stu-id="0933e-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="0933e-113"><a href="stencil-formats-not-supported-with-streaming-resources.md">ステンシル形式のストリームのリソースではサポートされていません</a></span><span class="sxs-lookup"><span data-stu-id="0933e-113"><a href="stencil-formats-not-supported-with-streaming-resources.md">Stencil formats not supported with streaming resources</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="0933e-114">ステンシルを含む書式は、ストリーミング リソースではサポートされません。</span><span class="sxs-lookup"><span data-stu-id="0933e-114">Formats that contain stencil aren't supported with streaming resources.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="0933e-115"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="0933e-115"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="0933e-116">ストリーミングのリソースを作成します。</span><span class="sxs-lookup"><span data-stu-id="0933e-116">Creating streaming resources</span></span>](creating-streaming-resources.md)

 

 




