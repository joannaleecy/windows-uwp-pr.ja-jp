---
title: ストリーミング リソース機能の階層
description: Direct3D は、機能の 3 階層でストリーミング リソースをサポートします。
ms.assetid: 6AE7EA72-3929-4BB4-8780-F0CF26192D87
keywords:
- ストリーミング リソース機能の階層
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c872d289c67161e414671d3d509401f0539a7675
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57631447"
---
# <a name="streaming-resources-features-tiers"></a><span data-ttu-id="0e497-104">ストリーミング リソース機能の階層</span><span class="sxs-lookup"><span data-stu-id="0e497-104">Streaming resources features tiers</span></span>


<span data-ttu-id="0e497-105">Direct3D は、機能の 3 階層でストリーミング リソースをサポートします。</span><span class="sxs-lookup"><span data-stu-id="0e497-105">Direct3D supports streaming resources in three tiers of capabilities.</span></span>

<span data-ttu-id="0e497-106">階層 1 では、ストリーミング リソースの基本機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="0e497-106">Tier 1 provides basic capabilities for streaming resources.</span></span>

<span data-ttu-id="0e497-107">階層 2 では、サイズが 1 つ以上の標準タイル形状であるときのパックされないテクスチャ ミップマップの保証や、詳細レベル (LOD) をクランプするため、およびシェーダーの操作に関する状態を取得するためのシェーダー命令、サンプリングされた値をゼロとして処理する NULL マッピングされたタイルからの読み取りなど、階層 1 に含まれない機能が追加されます。</span><span class="sxs-lookup"><span data-stu-id="0e497-107">Tier 2 adds capabilities beyond Tier 1, such as guaranteeing non-packed texture mipmap when the size is at least one standard tile shape; shader instructions for clamping level-of-detail (LOD) and for obtaining status about the shader operation; also, reading from NULL-mapped tiles treat that sampled value as zero.</span></span>

<span data-ttu-id="0e497-108">階層 3 では、階層 2 で提供されない Texture3D の機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="0e497-108">Tier 3 adds Texture3D capabilities, beyond Tier 2.</span></span>

<span data-ttu-id="0e497-109">クエリ関数は Direct3D の各バージョンで利用でき、ストリーミング リソースのハードウェアとドライバーのサポートの検証や、階層レベルの確認に利用します。</span><span class="sxs-lookup"><span data-stu-id="0e497-109">Query functions are available in the versions of Direct3D, to validate hardware and driver support for streaming resources, and at what tier level.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="0e497-110"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="0e497-110"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="0e497-111">トピック</span><span class="sxs-lookup"><span data-stu-id="0e497-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="0e497-112">説明</span><span class="sxs-lookup"><span data-stu-id="0e497-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="0e497-113"><a href="tier-1.md">第 1 層</a></span><span class="sxs-lookup"><span data-stu-id="0e497-113"><a href="tier-1.md">Tier 1</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="0e497-114">このセクションでは、階層 1 のサポートについて説明します。</span><span class="sxs-lookup"><span data-stu-id="0e497-114">This section describes tier 1 support.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="0e497-115"><a href="tier-2.md">第 2 層</a></span><span class="sxs-lookup"><span data-stu-id="0e497-115"><a href="tier-2.md">Tier 2</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="0e497-116">ストリーミング リソースの階層 2 のサポートで、サイズが 1 つ以上の標準タイル形状であるときのパックされないテクスチャ ミップマップの保証や、詳細レベル (LOD) をクランプするため、およびシェーダーの操作に関する状態を取得するためのシェーダー命令、サンプリングされた値をゼロとして処理する NULL マッピングされたタイルからの読み取りなど、階層 1 に含まれない機能が追加されます。</span><span class="sxs-lookup"><span data-stu-id="0e497-116">Tier 2 support for streaming resources adds capabilities beyond Tier 1, such as guaranteeing nonpacked texture mipmap when the size is at least one standard tile shape; shader instructions for clamping level-of-detail (LOD) and for obtaining status about the shader operation; also, reading from NULL-mapped tiles treat that sampled value as zero.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="0e497-117"><a href="tier-3.md">第 3 層</a></span><span class="sxs-lookup"><span data-stu-id="0e497-117"><a href="tier-3.md">Tier 3</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="0e497-118">階層 3 では、<a href="tier-2.md">階層 2</a> の機能に加えて、ストリーミング リソース向けの Texture3D のサポートが追加されます。</span><span class="sxs-lookup"><span data-stu-id="0e497-118">Tier 3 adds support for Texture3D for streaming resources, in addition to the <a href="tier-2.md">Tier 2</a> capabilities.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="0e497-119"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="0e497-119"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="0e497-120">ストリーミング リソース</span><span class="sxs-lookup"><span data-stu-id="0e497-120">Streaming resources</span></span>](streaming-resources.md)

 

 




