---
title: ストリーミング リソースへのパイプライン アクセス
description: ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。
ms.assetid: 18DA5D61-930D-4466-8EFE-0CED566EA4A6
keywords:
- ストリーミング リソースへのパイプライン アクセス
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: f6f777669959721405fc5c77ef134e3726291b9c
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7572388"
---
# <a name="pipeline-access-to-streaming-resources"></a><span data-ttu-id="f0eb2-104">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="f0eb2-104">Pipeline access to streaming resources</span></span>


<span data-ttu-id="f0eb2-105">ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-105">Streaming resources can be used in shader resource views (SRV), render target views (RTV), depth stencil views (DSV) and unordered access views (UAV), as well as some bind points where views aren't used, such as vertex buffer bindings.</span></span> <span data-ttu-id="f0eb2-106">サポートされているバインドの一覧については、「[ストリーミング リソースの作成パラメーター](streaming-resource-creation-parameters.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-106">For the list of supported bindings, see [Streaming resource creation parameters](streaming-resource-creation-parameters.md).</span></span> <span data-ttu-id="f0eb2-107">また、さまざまな D3D コピー操作もストリーミング リソース上で機能します。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-107">The various D3D Copy operations also work on streaming resources.</span></span>

<span data-ttu-id="f0eb2-108">1 つ以上のビュー内の複数のタイルの座標が同じメモリ位置にバインドされている場合、複数のパスから同一メモリへの読み取りと書き込みは、無作為で反復不可能な順序のメモリ アクセスで発生します。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-108">If multiple tile coordinates in one or more views is bound to the same memory location, reads and writes from different paths to the same memory will occur in a non-deterministic and non-repeatable order of memory accesses.</span></span>

<span data-ttu-id="f0eb2-109">シェーダーからのメモリ アクセス フットプリントの背後にある全タイルが一意のタイルにマップされる場合、動作はどの実装においても、同一のメモリ内容を非タイル形式で保持するサーフェスと同じになります。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-109">If all tiles behind a memory access footprint from a shader are mapped to unique tiles, behavior is identical on all implementations to the surface having the same memory contents in a non-tiled fashion.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="f0eb2-110"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="f0eb2-110"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f0eb2-111">トピック</span><span class="sxs-lookup"><span data-stu-id="f0eb2-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="f0eb2-112">説明</span><span class="sxs-lookup"><span data-stu-id="f0eb2-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="srv-behavior-with-non-mapped-tiles.md"><span data-ttu-id="f0eb2-113">マップされていないタイルでの SRV 動作</span><span class="sxs-lookup"><span data-stu-id="f0eb2-113">SRV behavior with non-mapped tiles</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f0eb2-114">マップされていないタイルに関連するシェーダー リソース ビュー (SRV) の読み取り動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-114">Behavior of shader resource view (SRV) reads that involve non-mapped tiles depends on the level of hardware support.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="uav-behavior-with-non-mapped-tiles.md"><span data-ttu-id="f0eb2-115">マップされていないタイルでの UAV 動作</span><span class="sxs-lookup"><span data-stu-id="f0eb2-115">UAV behavior with non-mapped tiles</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f0eb2-116">順序指定されていないアクセス ビュー (UAV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-116">Behavior of unordered access view (UAV) reads and writes depends on the level of hardware support.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="rasterizer-behavior-with-non-mapped-tiles.md"><span data-ttu-id="f0eb2-117">マップされていないタイルでのラスタライザー動作</span><span class="sxs-lookup"><span data-stu-id="f0eb2-117">Rasterizer behavior with non-mapped tiles</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f0eb2-118">このセクションでは、マップされていないタイルを使用したラスタライザー動作について説明します。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-118">This section describes rasterizer behavior with non-mapped tiles.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="tile-access-limitations-with-duplicate-mappings.md"><span data-ttu-id="f0eb2-119">重複するマッピングを含むタイルのアクセス制限</span><span class="sxs-lookup"><span data-stu-id="f0eb2-119">Tile access limitations with duplicate mappings</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f0eb2-120">コピー元とコピー先が重複しているストリーミング リソースをコピーする場合や、レンダー領域内で共有されるタイルをレンダリングする場合などでは、重複するマッピングを含むタイル アクセスに制限があります。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-120">There are limitations on tile access with duplicate mappings, such as when copying streaming resources with overlapping source and destination, or when rendering to tiles shared within the render area.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="streaming-resources-texture-sampling-features.md"><span data-ttu-id="f0eb2-121">ストリーミング リソース テクスチャ サンプリング機能</span><span class="sxs-lookup"><span data-stu-id="f0eb2-121">Streaming resources texture sampling features</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f0eb2-122">ストリーミング リソース テクスチャ サンプリングの機能は複数あります。たとえば、マップの領域についてシェーダー状態のフィードバックを取得する機能、アクセスされている全データがリソース内にマップされたかどうか確認する機能、マップされていないことがわかっているミップマップ ストリーミング リソース内の領域をシェーダーが避けられるようにクランプする機能、テクスチャ フィルターのフットプリント全体に完全にマップされる最小の LOD を検出する機能などがあります。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-122">Streaming resources texture sampling features include getting shader status feedback about mapped areas, checking whether all data being accessed was mapped in the resource, clamping to help shaders avoid areas in mipmapped streaming resources that are known to be non-mapped, and discovering what the minimum LOD that is fully mapped for an entire texture filter footprint will be.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="hlsl-streaming-resources-exposure.md"><span data-ttu-id="f0eb2-123">HLSL ストリーミング リソースの露出</span><span class="sxs-lookup"><span data-stu-id="f0eb2-123">HLSL streaming resources exposure</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="f0eb2-124"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471356">シェーダー モデル 5</a> のストリーミング リソースをサポートするには、Microsoft 上位レベル シェーダー言語 (HLSL) の特定の構文が必要です。</span><span class="sxs-lookup"><span data-stu-id="f0eb2-124">A specific Microsoft High Level Shader Language (HLSL) syntax is required to support streaming resources in <a href="https://msdn.microsoft.com/library/windows/desktop/ff471356">Shader Model 5</a>.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="f0eb2-125"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="f0eb2-125"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="f0eb2-126">ストリーミング リソース</span><span class="sxs-lookup"><span data-stu-id="f0eb2-126">Streaming resources</span></span>](streaming-resources.md)

 

 




