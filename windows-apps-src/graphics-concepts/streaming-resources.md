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
ms.localizationpriority: medium
ms.openlocfilehash: dac89fc678e35b1e3a39d26d836f03c18d3c4684
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5707580"
---
# <a name="streaming-resources"></a><span data-ttu-id="0e482-108">ストリーミング リソース</span><span class="sxs-lookup"><span data-stu-id="0e482-108">Streaming resources</span></span>


<span data-ttu-id="0e482-109">*ストリーミング リソース*は、少量の物理メモリを使用する大規模な論理リソースです。</span><span class="sxs-lookup"><span data-stu-id="0e482-109">*Streaming resources* are large logical resources that use small amounts of physical memory.</span></span> <span data-ttu-id="0e482-110">大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="0e482-110">Instead of passing an entire large resource, small parts of the resource are streamed as needed.</span></span> <span data-ttu-id="0e482-111">ストリーミング リソースは、以前は*タイル リソース*と呼ばれていました。</span><span class="sxs-lookup"><span data-stu-id="0e482-111">Streaming resources were previously called *tiled resources*.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="0e482-112"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="0e482-112"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="0e482-113">トピック</span><span class="sxs-lookup"><span data-stu-id="0e482-113">Topic</span></span></th>
<th align="left"><span data-ttu-id="0e482-114">説明</span><span class="sxs-lookup"><span data-stu-id="0e482-114">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="the-need-for-streaming-resources.md"><span data-ttu-id="0e482-115">ストリーミング リソースのニーズ</span><span class="sxs-lookup"><span data-stu-id="0e482-115">The need for streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="0e482-116">ストリーミング リソースは、アクセスされないサーフェスの領域を保存して GPU メモリを無駄にしないために、また、隣接するタイルをまたいでフィルター処理する方法をハードウェアに伝えるために必要です。</span><span class="sxs-lookup"><span data-stu-id="0e482-116">Streaming resources are needed so GPU memory isn't wasted storing regions of surfaces that won't be accessed, and to tell the hardware how to filter across adjacent tiles.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="creating-streaming-resources.md"><span data-ttu-id="0e482-117">ストリーミング リソースの作成</span><span class="sxs-lookup"><span data-stu-id="0e482-117">Creating streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="0e482-118">ストリーミング リソースは、リソースを作成するときにフラグを指定することによって作成され、リソースがストリーミング リソースであることを示します。</span><span class="sxs-lookup"><span data-stu-id="0e482-118">Streaming resources are created by specifying a flag when you create a resource, indicating that the resource is a streaming resource.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="pipeline-access-to-streaming-resources.md"><span data-ttu-id="0e482-119">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="0e482-119">Pipeline access to streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="0e482-120">ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。</span><span class="sxs-lookup"><span data-stu-id="0e482-120">Streaming resources can be used in shader resource views (SRV), render target views (RTV), depth stencil views (DSV) and unordered access views (UAV), as well as some bind points where views aren't used, such as vertex buffer bindings.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="streaming-resources-features-tiers.md"><span data-ttu-id="0e482-121">ストリーミング リソース機能の階層</span><span class="sxs-lookup"><span data-stu-id="0e482-121">Streaming resources features tiers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="0e482-122">Direct3D は、機能の 3 階層でストリーミング リソースをサポートします。</span><span class="sxs-lookup"><span data-stu-id="0e482-122">Direct3D supports streaming resources in three tiers of capabilities.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="0e482-123"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="0e482-123"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="0e482-124">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="0e482-124">Direct3D Graphics Learning Guide</span></span>](index.md)

[<span data-ttu-id="0e482-125">リソース</span><span class="sxs-lookup"><span data-stu-id="0e482-125">Resources</span></span>](resources.md)

 

 




