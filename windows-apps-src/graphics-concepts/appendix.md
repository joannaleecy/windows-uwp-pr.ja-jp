---
title: 付録
description: これらのセクションでは、技術的な詳細について説明します。
ms.assetid: 461CCE6F-BAF0-4965-90A5-FD36B511F72C
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 15e149a6381a511c66f5c337c8256e5ce5024939
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5878346"
---
# <a name="appendices"></a><span data-ttu-id="1adbd-104">付録</span><span class="sxs-lookup"><span data-stu-id="1adbd-104">Appendices</span></span>

<span data-ttu-id="1adbd-105">これらのセクションでは、技術的な詳細について説明します。</span><span class="sxs-lookup"><span data-stu-id="1adbd-105">These sections provide in-depth technical details.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="1adbd-106"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="1adbd-106"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="1adbd-107">トピック</span><span class="sxs-lookup"><span data-stu-id="1adbd-107">Topic</span></span></th>
<th align="left"><span data-ttu-id="1adbd-108">説明</span><span class="sxs-lookup"><span data-stu-id="1adbd-108">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="floating-point-rules.md"><span data-ttu-id="1adbd-109">浮動小数点の規則</span><span class="sxs-lookup"><span data-stu-id="1adbd-109">Floating-point rules</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1adbd-110">Direct3D では、いくつかの浮動小数点表現がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="1adbd-110">Direct3D supports several floating-point representations.</span></span> <span data-ttu-id="1adbd-111">すべての浮動小数点演算は、IEEE 754 32 ビット単精度浮動小数点ルールのサブセットの定義のもとで動作します。</span><span class="sxs-lookup"><span data-stu-id="1adbd-111">All floating-point computations operate under a defined subset of the IEEE 754 32-bit single precision floating-point rules.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="data-type-conversion.md"><span data-ttu-id="1adbd-112">データ型の変換</span><span class="sxs-lookup"><span data-stu-id="1adbd-112">Data type conversion</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1adbd-113">次のセクションでは、Direct3D がデータ型の間の変換を処理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="1adbd-113">The following sections describe how Direct3D handles conversions between data types.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="rasterization-rules.md"><span data-ttu-id="1adbd-114">ラスター化ルール</span><span class="sxs-lookup"><span data-stu-id="1adbd-114">Rasterization rules</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1adbd-115">ラスター化ルールは、ベクトル データをラスター データにマップする方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="1adbd-115">Rasterization rules define how vector data is mapped into raster data.</span></span> <span data-ttu-id="1adbd-116">ラスター データは、整数値の位置に配置されてからカリングおよびクリッピングされ (描画するピクセルの数を最小限にするため)、ピクセル単位の属性が (頂点単位の属性から) 補間された後、ピクセル シェーダーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="1adbd-116">The raster data is snapped to integer locations that are then culled and clipped (to draw the minimum number of pixels), and per-pixel attributes are interpolated (from per-vertex attributes) before being passed to a pixel shader.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="texture-block-compression.md"><span data-ttu-id="1adbd-117">テクスチャのブロック圧縮</span><span class="sxs-lookup"><span data-stu-id="1adbd-117">Texture block compression</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="1adbd-118">Direct3D 11 では、テクスチャのブロック圧縮 (BC) サポートが拡張され、BC6H および BC7 アルゴリズムが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="1adbd-118">Block Compression (BC) support for textures has been extended in Direct3D 11 to include the BC6H and BC7 algorithms.</span></span> <span data-ttu-id="1adbd-119">BC6H はハイ ダイナミック レンジのカラー ソース データをサポートし、BC7 は標準 RGB ソース データのアーティファクトを低減して標準よりも優れた品質の圧縮を提供します。</span><span class="sxs-lookup"><span data-stu-id="1adbd-119">BC6H supports high-dynamic range color source data, and BC7 provides better-than-average quality compression with less artifacts for standard RGB source data.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1adbd-120"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1adbd-120"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1adbd-121">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="1adbd-121">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




