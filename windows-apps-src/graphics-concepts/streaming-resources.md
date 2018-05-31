---
title: ストリーミング リソース
description: ストリーミング リソースは、少量の物理メモリを使用する大規模な論理リソースです。 大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。 ストリーミング リソースは、以前はタイル リソースと呼ばれていました。
ms.assetid: 04F0486E-4B71-4073-88DA-2AF505F4F0C1
keywords:
- ストリーミング リソース
- リソース, ストリーミング
- リソース, タイル
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: f269b352dc3d7ea7c63c04fdbfc487fae490bf1e
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1653661"
---
# <a name="streaming-resources"></a><span data-ttu-id="00c54-108">ストリーミング リソース</span><span class="sxs-lookup"><span data-stu-id="00c54-108">Streaming resources</span></span>


<span data-ttu-id="00c54-109">*ストリーミング リソース*は、少量の物理メモリを使用する大規模な論理リソースです。</span><span class="sxs-lookup"><span data-stu-id="00c54-109">*Streaming resources* are large logical resources that use small amounts of physical memory.</span></span> <span data-ttu-id="00c54-110">大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="00c54-110">Instead of passing an entire large resource, small parts of the resource are streamed as needed.</span></span> <span data-ttu-id="00c54-111">ストリーミング リソースは、以前は*タイル リソース*と呼ばれていました。</span><span class="sxs-lookup"><span data-stu-id="00c54-111">Streaming resources were previously called *tiled resources*.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="00c54-112"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="00c54-112"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="00c54-113">トピック</span><span class="sxs-lookup"><span data-stu-id="00c54-113">Topic</span></span></th>
<th align="left"><span data-ttu-id="00c54-114">説明</span><span class="sxs-lookup"><span data-stu-id="00c54-114">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="the-need-for-streaming-resources.md"><span data-ttu-id="00c54-115">ストリーミング リソースのニーズ</span><span class="sxs-lookup"><span data-stu-id="00c54-115">The need for streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="00c54-116">ストリーミング リソースは、アクセスされないサーフェスの領域を保存して GPU メモリを無駄にしないために、また、隣接するタイルをまたいでフィルター処理する方法をハードウェアに伝えるために必要です。</span><span class="sxs-lookup"><span data-stu-id="00c54-116">Streaming resources are needed so GPU memory isn't wasted storing regions of surfaces that won't be accessed, and to tell the hardware how to filter across adjacent tiles.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="creating-streaming-resources.md"><span data-ttu-id="00c54-117">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="00c54-117">Creating streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="00c54-118">ストリーミング リソースは、リソースを作成するときにフラグを指定することによって作成され、リソースがストリーミング リソースであることを示します。</span><span class="sxs-lookup"><span data-stu-id="00c54-118">Streaming resources are created by specifying a flag when you create a resource, indicating that the resource is a streaming resource.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="pipeline-access-to-streaming-resources.md"><span data-ttu-id="00c54-119">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="00c54-119">Pipeline access to streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="00c54-120">ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。</span><span class="sxs-lookup"><span data-stu-id="00c54-120">Streaming resources can be used in shader resource views (SRV), render target views (RTV), depth stencil views (DSV) and unordered access views (UAV), as well as some bind points where views aren't used, such as vertex buffer bindings.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resources-features-tiers.md"><span data-ttu-id="00c54-121">ストリーミング リソース機能の階層</span><span class="sxs-lookup"><span data-stu-id="00c54-121">Streaming resources features tiers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="00c54-122">Direct3D は、機能の 3 階層でストリーミング リソースをサポートします。</span><span class="sxs-lookup"><span data-stu-id="00c54-122">Direct3D supports streaming resources in three tiers of capabilities.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="00c54-123"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="00c54-123"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="00c54-124">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="00c54-124">Direct3D Graphics Learning Guide</span></span>](index.md)

[<span data-ttu-id="00c54-125">リソース</span><span class="sxs-lookup"><span data-stu-id="00c54-125">Resources</span></span>](resources.md)

 

 




