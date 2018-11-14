---
title: 圧縮テクスチャ リソース
description: テクスチャ マップとは、視覚的な詳細を追加するために 3 次元形状で描画された、デジタル画像です。
ms.assetid: 2DD5FF94-A029-4694-B103-26946C8DFBC1
keywords:
- 圧縮テクスチャ リソース
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e808bf0fe1f521a60aa347efd148ede96be95964
ms.sourcegitcommit: 71e8eae5c077a7740e5606298951bb78fc42b22c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6663153"
---
# <a name="compressed-texture-resources"></a><span data-ttu-id="89c34-104">圧縮テクスチャ リソース</span><span class="sxs-lookup"><span data-stu-id="89c34-104">Compressed texture resources</span></span>


<span data-ttu-id="89c34-105">テクスチャ マップとは、視覚的な詳細を追加するために 3 次元形状で描画された、デジタル画像です。</span><span class="sxs-lookup"><span data-stu-id="89c34-105">Texture maps are digitized images drawn on three-dimensional shapes to add visual detail.</span></span> <span data-ttu-id="89c34-106">テクスチャ マップは、ラスター化時に 3D の形状にマッピングされます。このプロセスではシステム バスとメモリの両方を大量に消費することがあります。</span><span class="sxs-lookup"><span data-stu-id="89c34-106">They are mapped into these shapes during rasterization, and the process can consume large amounts of both the system bus and memory.</span></span> <span data-ttu-id="89c34-107">テクスチャによって消費されるメモリ量を減らすために、Direct3D ではテクスチャ サーフェスの圧縮がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="89c34-107">To reduce the amount of memory consumed by textures, Direct3D supports the compression of texture surfaces.</span></span> <span data-ttu-id="89c34-108">Direct3D デバイスの中には、圧縮テクスチャ サーフェスを標準でサポートするものもあります。</span><span class="sxs-lookup"><span data-stu-id="89c34-108">Some Direct3D devices support compressed texture surfaces natively.</span></span> <span data-ttu-id="89c34-109">このようなデバイスでは、圧縮したサーフェスを作成し、データをロードすると、他のテクスチャ サーフェスと同様に Direct3D でそのサーフェスを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="89c34-109">On such devices, when you have created a compressed surface and loaded the data into it, the surface can be used in Direct3D like any other texture surface.</span></span> <span data-ttu-id="89c34-110">テクスチャが 3D オブジェクトにマッピングされるときに、Direct3D によって圧縮が解除されます。</span><span class="sxs-lookup"><span data-stu-id="89c34-110">Direct3D handles decompression when the texture is mapped to a 3D object.</span></span>

## <a name="span-idstorage-efficiency-and-texture-compressionspanspan-idstorage-efficiency-and-texture-compressionspanspan-idstorage-efficiency-and-texture-compressionspanstorage-efficiency-and-texture-compression"></a><span data-ttu-id="89c34-111"><span id="Storage-Efficiency-and-Texture-Compression"></span><span id="storage-efficiency-and-texture-compression"></span><span id="STORAGE-EFFICIENCY-AND-TEXTURE-COMPRESSION"></span>ストレージの効率とテクスチャ圧縮</span><span class="sxs-lookup"><span data-stu-id="89c34-111"><span id="Storage-Efficiency-and-Texture-Compression"></span><span id="storage-efficiency-and-texture-compression"></span><span id="STORAGE-EFFICIENCY-AND-TEXTURE-COMPRESSION"></span>Storage efficiency and texture compression</span></span>


<span data-ttu-id="89c34-112">テクスチャ圧縮形式はすべて 2 の累乗です。</span><span class="sxs-lookup"><span data-stu-id="89c34-112">All texture compression formats are powers of two.</span></span> <span data-ttu-id="89c34-113">これはテクスチャが必ず正方形であることを意味するのではなく、x と y の両方が 2 の累乗であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="89c34-113">While this does not mean that a texture is necessarily square, it does mean that both x and y are powers of two.</span></span> <span data-ttu-id="89c34-114">たとえば、元のテクスチャが 512 × 128 バイトであった場合、次のミップマップ処理では 256 × 64 というように、1 レベルごとに 2 の累乗ずつ小さくなります。</span><span class="sxs-lookup"><span data-stu-id="89c34-114">For example, if a texture is originally 512 by 128 bytes, the next mipmapping would be 256 by 64 and so on, with each level decreasing by a power of two.</span></span> <span data-ttu-id="89c34-115">さらにレベルを下げて、テクスチャを 16 × 2 および 8 × 1 までフィルタリングすると、圧縮ブロックは常に 4 x 4 のテクセル ブロックであるため、無駄なビットが生じます。</span><span class="sxs-lookup"><span data-stu-id="89c34-115">At lower levels, where the texture is filtered to 16 by 2 and 8 by 1, there will be wasted bits because the compression block is always a 4 by 4 block of texels.</span></span> <span data-ttu-id="89c34-116">ブロックの未使用部分はパディングされます。</span><span class="sxs-lookup"><span data-stu-id="89c34-116">Unused portions of the block are padded.</span></span>

<span data-ttu-id="89c34-117">低いレベルでは無駄なビットが出ますが、全体的なゲインは重要です。</span><span class="sxs-lookup"><span data-stu-id="89c34-117">Although there are wasted bits at the lowest levels, the overall gain is still significant.</span></span> <span data-ttu-id="89c34-118">理論的に最悪のケースは、2K × 1 (2 の 0 乗) のテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="89c34-118">The worst case is, in theory, a 2K by 1 texture (2⁰ power).</span></span> <span data-ttu-id="89c34-119">この場合、1 ブロックにつき 1 つのピクセル行しかエンコードされず、ブロックの残りの部分は使用されません。</span><span class="sxs-lookup"><span data-stu-id="89c34-119">Here, only a single row of pixels is encoded per block, while the rest of the block is unused.</span></span>

## <a name="span-idmixing-formats-within-a-single-texturespanspan-idmixing-formats-within-a-single-texturespanspan-idmixing-formats-within-a-single-texturespanmixing-formats-within-a-single-texture"></a><span data-ttu-id="89c34-120"><span id="Mixing-Formats-Within-a-Single-Texture"></span><span id="mixing-formats-within-a-single-texture"></span><span id="MIXING-FORMATS-WITHIN-A-SINGLE-TEXTURE"></span>単一テクスチャ内での形式の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="89c34-120"><span id="Mixing-Formats-Within-a-Single-Texture"></span><span id="mixing-formats-within-a-single-texture"></span><span id="MIXING-FORMATS-WITHIN-A-SINGLE-TEXTURE"></span>Mixing formats within a single texture</span></span>


<span data-ttu-id="89c34-121">個々のテクスチャはすべて、16 テクセルのグループごとにデータを 64 ビットまたは 128 ビットで格納するように指定する必要があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="89c34-121">It is important to note that any single texture must specify that its data is stored as 64 or 128 bits per group of 16 texels.</span></span> <span data-ttu-id="89c34-122">64 ビットのブロック、つまりブロック圧縮形式 BC1 をテクスチャに使用する場合、同一のテクスチャ内にブロック単位で不透明の形式と 1 ビット アルファの形式を混在させることができます。</span><span class="sxs-lookup"><span data-stu-id="89c34-122">If 64-bit blocks - that is, block compression format BC1 - are used for the texture, it is possible to mix the opaque and 1-bit alpha formats on a per-block basis within the same texture.</span></span> <span data-ttu-id="89c34-123">つまり、color\_0 と color\_1 の符号なし整数の絶対値の比較が、16 テクセルのブロックごとに独立して実行されます。</span><span class="sxs-lookup"><span data-stu-id="89c34-123">In other words, the comparison of the unsigned integer magnitude of color\_0 and color\_1 is performed uniquely for each block of 16 texels.</span></span>

<span data-ttu-id="89c34-124">128 ビット ブロックを使用する場合、テクスチャ全体にアルファ チャネルを明示的モード (BC2 形式) または補間モード (BC3 形式) で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="89c34-124">Once the 128-bit blocks are used, the alpha channel must be specified in either explicit (format BC2) or interpolated mode (format BC3) for the entire texture.</span></span> <span data-ttu-id="89c34-125">カラーの場合と同様に、補間モード (BC3 形式) を選択すると、8 つの補間アルファまたは 6 つの補間アルファのモードをブロック単位で使用することができます。</span><span class="sxs-lookup"><span data-stu-id="89c34-125">As with color, when interpolated mode (format BC3) is selected, then either eight interpolated alphas or six interpolated alphas mode can be used on a block-by-block basis.</span></span> <span data-ttu-id="89c34-126">ここでも、alpha\_0 と alpha\_1 の絶対値の比較がブロックごとに独立して実行されます。</span><span class="sxs-lookup"><span data-stu-id="89c34-126">Again the magnitude comparison of alpha\_0 and alpha\_1 is done uniquely on a block-by-block basis.</span></span>

<span data-ttu-id="89c34-127">Direct3D では、3D モデルのテクスチャに使用する、サーフェスを圧縮するためのサービスが用意されています。</span><span class="sxs-lookup"><span data-stu-id="89c34-127">Direct3D provides services to compress surfaces that are used for texturing 3D models.</span></span> <span data-ttu-id="89c34-128">ここでは、圧縮テクスチャ サーフェスのデータの作成および操作について説明します。</span><span class="sxs-lookup"><span data-stu-id="89c34-128">This section provides information about creating and manipulating the data in a compressed texture surface.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="89c34-129"><span id="in-this-section"></span>説明するトピックは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="89c34-129"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="89c34-130">トピック</span><span class="sxs-lookup"><span data-stu-id="89c34-130">Topic</span></span></th>
<th align="left"><span data-ttu-id="89c34-131">説明</span><span class="sxs-lookup"><span data-stu-id="89c34-131">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="opaque-and-1-bit-alpha-textures.md"><span data-ttu-id="89c34-132">不透明なテクスチャと 1 ビットのアルファ テクスチャ</span><span class="sxs-lookup"><span data-stu-id="89c34-132">Opaque and 1-bit alpha textures</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="89c34-133">テクスチャ形式 BC1 は、不透明または単一透明色のテクスチャに使用します。</span><span class="sxs-lookup"><span data-stu-id="89c34-133">Texture format BC1 is for textures that are opaque or have a single transparent color.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="textures-with-alpha-channels.md"><span data-ttu-id="89c34-134">アルファ チャネルを含むテクスチャ</span><span class="sxs-lookup"><span data-stu-id="89c34-134">Textures with alpha channels</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="89c34-135">複雑な透明度を表現するテクスチャ マップには 2 つのエンコード方法があります。</span><span class="sxs-lookup"><span data-stu-id="89c34-135">There are two ways to encode texture maps that exhibit more complex transparency.</span></span> <span data-ttu-id="89c34-136">いずれの場合も、既に説明した 64 ビットのブロックの前に、透明度を記述したブロックを配置します。</span><span class="sxs-lookup"><span data-stu-id="89c34-136">In each case, a block that describes the transparency precedes the 64-bit block already described.</span></span> <span data-ttu-id="89c34-137">透明度は、1 ピクセルあたり 4 ビットの 4 x 4 ビットマップ (明示的エンコード)、またはこれよりも少ないビット数およびカラー エンコードで使用されるものに類似した線形補完で表現します。</span><span class="sxs-lookup"><span data-stu-id="89c34-137">The transparency is either represented as a 4x4 bitmap with 4 bits per pixel (explicit encoding), or with fewer bits and linear interpolation that is analogous to what is used for color encoding.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="block-compression.md"><span data-ttu-id="89c34-138">ブロック圧縮</span><span class="sxs-lookup"><span data-stu-id="89c34-138">Block compression</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="89c34-139">ブロック圧縮は、テクスチャ サイズとメモリ フットプリントを減らしてパフォーマンスを向上させる、不可逆のテクスチャ圧縮技術です。</span><span class="sxs-lookup"><span data-stu-id="89c34-139">Block compression is a lossy texture-compression technique for reducing texture size and memory footprint, giving a performance increase.</span></span> <span data-ttu-id="89c34-140">ブロック圧縮テクスチャは、1 色あたり 32 ビットのテクスチャより小さくすることができます。</span><span class="sxs-lookup"><span data-stu-id="89c34-140">A block-compressed texture can be smaller than a texture with 32-bits per color.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="compressed-texture-formats.md"><span data-ttu-id="89c34-141">圧縮テクスチャ形式</span><span class="sxs-lookup"><span data-stu-id="89c34-141">Compressed texture formats</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="89c34-142">このセクションでは、圧縮テクスチャ形式の内部構造について説明します。</span><span class="sxs-lookup"><span data-stu-id="89c34-142">This section contains information about the internal organization of compressed texture formats.</span></span> <span data-ttu-id="89c34-143">圧縮形式への変換、および圧縮形式からの変換には Direct3D 関数を使用できるため、圧縮テクスチャの使用にこれらの詳細は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="89c34-143">You do not need these details to use compressed textures, because you can use Direct3D functions for conversion to and from compressed formats.</span></span> <span data-ttu-id="89c34-144">ただし、圧縮サーフェス データを直接操作する場合は、この情報が役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="89c34-144">However, this information is useful if you want to operate on compressed surface data directly.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="89c34-145"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="89c34-145"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="89c34-146">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="89c34-146">Textures</span></span>](textures.md)

 

 




