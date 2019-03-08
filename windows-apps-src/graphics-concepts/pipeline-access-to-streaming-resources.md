---
title: ストリーミング リソースへのパイプライン アクセス
description: ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。
ms.assetid: 18DA5D61-930D-4466-8EFE-0CED566EA4A6
keywords:
- ストリーミング リソースへのパイプライン アクセス
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 6d95ffc14e9ae6d4ea59a4b3bdc33fd215cb61be
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57616377"
---
# <a name="pipeline-access-to-streaming-resources"></a><span data-ttu-id="64506-104">ストリーミング リソースへのパイプライン アクセス</span><span class="sxs-lookup"><span data-stu-id="64506-104">Pipeline access to streaming resources</span></span>


<span data-ttu-id="64506-105">ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。</span><span class="sxs-lookup"><span data-stu-id="64506-105">Streaming resources can be used in shader resource views (SRV), render target views (RTV), depth stencil views (DSV) and unordered access views (UAV), as well as some bind points where views aren't used, such as vertex buffer bindings.</span></span> <span data-ttu-id="64506-106">サポートされているバインドの一覧については、「[ストリーミング リソースの作成パラメーター](streaming-resource-creation-parameters.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="64506-106">For the list of supported bindings, see [Streaming resource creation parameters](streaming-resource-creation-parameters.md).</span></span> <span data-ttu-id="64506-107">また、さまざまな D3D コピー操作もストリーミング リソース上で機能します。</span><span class="sxs-lookup"><span data-stu-id="64506-107">The various D3D Copy operations also work on streaming resources.</span></span>

<span data-ttu-id="64506-108">1 つ以上のビュー内の複数のタイルの座標が同じメモリ位置にバインドされている場合、複数のパスから同一メモリへの読み取りと書き込みは、無作為で反復不可能な順序のメモリ アクセスで発生します。</span><span class="sxs-lookup"><span data-stu-id="64506-108">If multiple tile coordinates in one or more views is bound to the same memory location, reads and writes from different paths to the same memory will occur in a non-deterministic and non-repeatable order of memory accesses.</span></span>

<span data-ttu-id="64506-109">シェーダーからのメモリ アクセス フットプリントの背後にある全タイルが一意のタイルにマップされる場合、動作はどの実装においても、同一のメモリ内容を非タイル形式で保持するサーフェスと同じになります。</span><span class="sxs-lookup"><span data-stu-id="64506-109">If all tiles behind a memory access footprint from a shader are mapped to unique tiles, behavior is identical on all implementations to the surface having the same memory contents in a non-tiled fashion.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="64506-110"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="64506-110"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="64506-111">トピック</span><span class="sxs-lookup"><span data-stu-id="64506-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="64506-112">説明</span><span class="sxs-lookup"><span data-stu-id="64506-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="64506-113"><a href="srv-behavior-with-non-mapped-tiles.md">タイルが、マップされていない SRV 動作</a></span><span class="sxs-lookup"><span data-stu-id="64506-113"><a href="srv-behavior-with-non-mapped-tiles.md">SRV behavior with non-mapped tiles</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64506-114">マップされていないタイルに関連するシェーダー リソース ビュー (SRV) の読み取り動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="64506-114">Behavior of shader resource view (SRV) reads that involve non-mapped tiles depends on the level of hardware support.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="64506-115"><a href="uav-behavior-with-non-mapped-tiles.md">タイルが、マップされていない UAV 動作</a></span><span class="sxs-lookup"><span data-stu-id="64506-115"><a href="uav-behavior-with-non-mapped-tiles.md">UAV behavior with non-mapped tiles</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64506-116">順序指定されていないアクセス ビュー (UAV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。</span><span class="sxs-lookup"><span data-stu-id="64506-116">Behavior of unordered access view (UAV) reads and writes depends on the level of hardware support.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="64506-117"><a href="rasterizer-behavior-with-non-mapped-tiles.md">タイルが、マップされていないラスタライザーの動作</a></span><span class="sxs-lookup"><span data-stu-id="64506-117"><a href="rasterizer-behavior-with-non-mapped-tiles.md">Rasterizer behavior with non-mapped tiles</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64506-118">このセクションでは、マップされていないタイルを使用したラスタライザー動作について説明します。</span><span class="sxs-lookup"><span data-stu-id="64506-118">This section describes rasterizer behavior with non-mapped tiles.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="64506-119"><a href="tile-access-limitations-with-duplicate-mappings.md">重複するマッピングでは、タイルへのアクセスの制限事項</a></span><span class="sxs-lookup"><span data-stu-id="64506-119"><a href="tile-access-limitations-with-duplicate-mappings.md">Tile access limitations with duplicate mappings</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64506-120">コピー元とコピー先が重複しているストリーミング リソースをコピーする場合や、レンダー領域内で共有されるタイルにレンダリングする場合などでは、重複するマッピングを含むタイル アクセスに制限があります。</span><span class="sxs-lookup"><span data-stu-id="64506-120">There are limitations on tile access with duplicate mappings, such as when copying streaming resources with overlapping source and destination, or when rendering to tiles shared within the render area.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="64506-121"><a href="streaming-resources-texture-sampling-features.md">テクスチャ サンプリング機能のストリーミングのリソース</a></span><span class="sxs-lookup"><span data-stu-id="64506-121"><a href="streaming-resources-texture-sampling-features.md">Streaming resources texture sampling features</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64506-122">ストリーミング リソース テクスチャ サンプリングの機能は複数あります。たとえば、マップの領域についてシェーダー状態のフィードバックを取得する機能、アクセスされている全データがリソース内にマップされたかどうか確認する機能、マップされていないことがわかっているミップマップ ストリーミング リソース内の領域をシェーダーが避けられるようにクランプする機能、テクスチャ フィルターのフットプリント全体に完全にマップされる最小の LOD を検出する機能などがあります。</span><span class="sxs-lookup"><span data-stu-id="64506-122">Streaming resources texture sampling features include getting shader status feedback about mapped areas, checking whether all data being accessed was mapped in the resource, clamping to help shaders avoid areas in mipmapped streaming resources that are known to be non-mapped, and discovering what the minimum LOD that is fully mapped for an entire texture filter footprint will be.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="64506-123"><a href="hlsl-streaming-resources-exposure.md">HLSL ストリーミング リソース リスク</a></span><span class="sxs-lookup"><span data-stu-id="64506-123"><a href="hlsl-streaming-resources-exposure.md">HLSL streaming resources exposure</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="64506-124"><a href="https://msdn.microsoft.com/library/windows/desktop/ff471356">シェーダー モデル 5</a> のストリーミング リソースをサポートするには、Microsoft 上位レベル シェーダー言語 (HLSL) の特定の構文が必要です。</span><span class="sxs-lookup"><span data-stu-id="64506-124">A specific Microsoft High Level Shader Language (HLSL) syntax is required to support streaming resources in <a href="https://msdn.microsoft.com/library/windows/desktop/ff471356">Shader Model 5</a>.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="64506-125"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="64506-125"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="64506-126">リソースのストリーミング</span><span class="sxs-lookup"><span data-stu-id="64506-126">Streaming resources</span></span>](streaming-resources.md)

 

 




