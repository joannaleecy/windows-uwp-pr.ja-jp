---
title: 付録
description: これらのセクションでは、技術的な面について詳しく説明します。
ms.assetid: 461CCE6F-BAF0-4965-90A5-FD36B511F72C
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: f4cd2e17754dc5b5958e8bca208e30b87718cdd8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632497"
---
# <a name="appendices"></a><span data-ttu-id="3167f-104">付録</span><span class="sxs-lookup"><span data-stu-id="3167f-104">Appendices</span></span>

<span data-ttu-id="3167f-105">これらのセクションでは、技術的な面について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="3167f-105">These sections provide in-depth technical details.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="3167f-106"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="3167f-106"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="3167f-107">トピック</span><span class="sxs-lookup"><span data-stu-id="3167f-107">Topic</span></span></th>
<th align="left"><span data-ttu-id="3167f-108">説明</span><span class="sxs-lookup"><span data-stu-id="3167f-108">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="3167f-109"><a href="floating-point-rules.md">浮動小数点の規則</a></span><span class="sxs-lookup"><span data-stu-id="3167f-109"><a href="floating-point-rules.md">Floating-point rules</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="3167f-110">Direct3D は、複数の浮動小数点表現をサポートします。</span><span class="sxs-lookup"><span data-stu-id="3167f-110">Direct3D supports several floating-point representations.</span></span> <span data-ttu-id="3167f-111">すべての浮動小数点演算は、IEEE 754 32 ビット単精度浮動小数点ルールのサブセットの定義のもとで動作します。</span><span class="sxs-lookup"><span data-stu-id="3167f-111">All floating-point computations operate under a defined subset of the IEEE 754 32-bit single precision floating-point rules.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="3167f-112"><a href="data-type-conversion.md">データ型の変換</a></span><span class="sxs-lookup"><span data-stu-id="3167f-112"><a href="data-type-conversion.md">Data type conversion</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="3167f-113">次のセクションでは、Direct3D がデータ型の間の変換を処理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="3167f-113">The following sections describe how Direct3D handles conversions between data types.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="3167f-114"><a href="rasterization-rules.md">ラスタライズ ルール</a></span><span class="sxs-lookup"><span data-stu-id="3167f-114"><a href="rasterization-rules.md">Rasterization rules</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="3167f-115">ラスター化ルールは、ベクトル データをラスター データにマップする方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="3167f-115">Rasterization rules define how vector data is mapped into raster data.</span></span> <span data-ttu-id="3167f-116">ラスター データは、整数値の位置に配置されてからカリングおよびクリッピングされ (描画するピクセルの数を最小限にするため)、ピクセル単位の属性が (頂点単位の属性から) 補間された後、ピクセル シェーダーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="3167f-116">The raster data is snapped to integer locations that are then culled and clipped (to draw the minimum number of pixels), and per-pixel attributes are interpolated (from per-vertex attributes) before being passed to a pixel shader.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="3167f-117"><a href="texture-block-compression.md">テクスチャのブロック圧縮</a></span><span class="sxs-lookup"><span data-stu-id="3167f-117"><a href="texture-block-compression.md">Texture block compression</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="3167f-118">Direct3D 11 では、テクスチャのブロック圧縮 (BC) サポートが拡張され、BC6H および BC7 アルゴリズムが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="3167f-118">Block Compression (BC) support for textures has been extended in Direct3D 11 to include the BC6H and BC7 algorithms.</span></span> <span data-ttu-id="3167f-119">BC6H はハイ ダイナミック レンジのカラー ソース データをサポートし、BC7 は標準 RGB ソース データのアーティファクトを低減して標準よりも優れた品質の圧縮を提供します。</span><span class="sxs-lookup"><span data-stu-id="3167f-119">BC6H supports high-dynamic range color source data, and BC7 provides better-than-average quality compression with less artifacts for standard RGB source data.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="3167f-120"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="3167f-120"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="3167f-121">Direct3D グラフィックス学習ガイド</span><span class="sxs-lookup"><span data-stu-id="3167f-121">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




