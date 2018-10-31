---
title: BC6H 形式
description: BC6H 形式は、ソース データのハイ ダイナミック レンジ (HDR) 色空間をサポートするように設計されたテクスチャ圧縮形式です。
ms.assetid: 6781D967-9262-4EE7-B354-7A6D0EA0498E
keywords:
- BC6H 形式
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: be88f06cd5893f2f67697a54754826440bdf7d18
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5814102"
---
# <a name="bc6h-format"></a><span data-ttu-id="01ec1-104">BC6H 形式</span><span class="sxs-lookup"><span data-stu-id="01ec1-104">BC6H format</span></span>


<span data-ttu-id="01ec1-105">BC6H 形式は、ソース データのハイ ダイナミック レンジ (HDR) 色空間をサポートするように設計されたテクスチャ圧縮形式です。</span><span class="sxs-lookup"><span data-stu-id="01ec1-105">The BC6H format is a texture compression format designed to support high-dynamic range (HDR) color spaces in source data.</span></span>

## <a name="span-idabout-bc6h-dxgi-format-bc6hspanspan-idabout-bc6h-dxgi-format-bc6hspanspan-idabout-bc6h-dxgi-format-bc6hspanabout-bc6hdxgiformatbc6h"></a><span data-ttu-id="01ec1-106"><span id="About-BC6H-DXGI-FORMAT-BC6H"></span><span id="about-bc6h-dxgi-format-bc6h"></span><span id="ABOUT-BC6H-DXGI-FORMAT-BC6H"></span>BC6H/DXGI\_FORMAT\_BC6H について</span><span class="sxs-lookup"><span data-stu-id="01ec1-106"><span id="About-BC6H-DXGI-FORMAT-BC6H"></span><span id="about-bc6h-dxgi-format-bc6h"></span><span id="ABOUT-BC6H-DXGI-FORMAT-BC6H"></span>About BC6H/DXGI\_FORMAT\_BC6H</span></span>


<span data-ttu-id="01ec1-107">BC6H 形式は、3 つの HDR カラー チャネルを使用した画像に、高品質の圧縮を提供します。各カラー チャネルに (16:16:16) の 16 ビット値を使用します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-107">The BC6H format provides high-quality compression for images that use three HDR color channels, with a 16-bit value for each color channel of the value (16:16:16).</span></span> <span data-ttu-id="01ec1-108">アルファ チャネルはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="01ec1-108">There is no support for an alpha channel.</span></span>

<span data-ttu-id="01ec1-109">BC6H は、次の DXGI \ _FORMAT 列挙値によって指定されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-109">BC6H is specified by the following DXGI\_FORMAT enumeration values:</span></span>

-   <span data-ttu-id="01ec1-110">**DXGI\_FORMAT\_BC6H\_TYPELESS**。</span><span class="sxs-lookup"><span data-stu-id="01ec1-110">**DXGI\_FORMAT\_BC6H\_TYPELESS**.</span></span>
-   <span data-ttu-id="01ec1-111">**DXGI\_FORMAT\_BC6H\_UF16**。</span><span class="sxs-lookup"><span data-stu-id="01ec1-111">**DXGI\_FORMAT\_BC6H\_UF16**.</span></span> <span data-ttu-id="01ec1-112">この BC6H 形式は、16 ビット浮動小数点カラー チャネル値の符号ビットを使用しません。</span><span class="sxs-lookup"><span data-stu-id="01ec1-112">This BC6H format does not use a sign bit in the 16-bit floating point color channel values.</span></span>
-   <span data-ttu-id="01ec1-113">**DXGI\_FORMAT\_BC6H\_SF16**。</span><span class="sxs-lookup"><span data-stu-id="01ec1-113">**DXGI\_FORMAT\_BC6H\_SF16**.</span></span> <span data-ttu-id="01ec1-114">この BC6H 形式は、16 ビット浮動小数点カラー チャネル値の符号ビットを使用します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-114">This BC6H format uses a sign bit in the 16-bit floating point color channel values.</span></span>

<span data-ttu-id="01ec1-115">**注:**  16 ビット浮動小数点形式のカラー チャネルは、多くの場合と呼ばれます「半」浮動小数点形式です。</span><span class="sxs-lookup"><span data-stu-id="01ec1-115">**Note** The 16 bit floating point format for color channels is often referred to as a "half" floating point format.</span></span> <span data-ttu-id="01ec1-116">この形式には、次のビット レイアウトがあります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-116">This format has the following bit layout:</span></span>
|                       |                                                 |
|-----------------------|-------------------------------------------------|
| <span data-ttu-id="01ec1-117">UF16 (符号なし浮動小数点)</span><span class="sxs-lookup"><span data-stu-id="01ec1-117">UF16 (unsigned float)</span></span> | <span data-ttu-id="01ec1-118">5 指数ビット + 11 仮数ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-118">5 exponent bits + 11 mantissa bits</span></span>              |
| <span data-ttu-id="01ec1-119">SF16 (符号付き浮動小数点)</span><span class="sxs-lookup"><span data-stu-id="01ec1-119">SF16 (signed float)</span></span>   | <span data-ttu-id="01ec1-120">1 符号ビット + 5 指数ビット + 10 仮数ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-120">1 sign bit + 5 exponent bits + 10 mantissa bits</span></span> |

 

 

<span data-ttu-id="01ec1-121">BC6H 形式は、[Texture2D](https://msdn.microsoft.com/library/windows/desktop/bb205277) (配列を含む)、Texture3D、または TextureCube (配列を含む) のテクスチャ リソースに使用できます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-121">The BC6H format can be used for [Texture2D](https://msdn.microsoft.com/library/windows/desktop/bb205277) (including arrays), Texture3D, or TextureCube (including arrays) texture resources.</span></span> <span data-ttu-id="01ec1-122">同様に、この形式は、これらのリソースに関連付けられた任意のミップマップ サーフェスに適用されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-122">Similarly, this format applies to any MIP-map surfaces associated with these resources.</span></span>

<span data-ttu-id="01ec1-123">BC6H は、16バイト (128 ビット) の固定ブロックサイズと 4 × 4 テクセルの固定タイル サイズを使用します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-123">BC6H uses a fixed block size of 16 bytes (128 bits) and a fixed tile size of 4x4 texels.</span></span> <span data-ttu-id="01ec1-124">以前の BC 形式と同様に、サポートされるタイル サイズ (4 x 4) よりも大きなテクスチャ画像は、複数のブロックを使用して圧縮されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-124">As with previous BC formats, texture images larger than the supported tile size (4x4) are compressed by using multiple blocks.</span></span> <span data-ttu-id="01ec1-125">このアドレス指定 ID は、3 次元画像とミップマップ、キューブマップ、テクスチャ配列にも適用されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-125">This addressing identity applies also to three-dimensional images, MIP-maps, cube maps, and texture arrays.</span></span> <span data-ttu-id="01ec1-126">すべての画像タイルは同じ形式でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="01ec1-126">All image tiles must be of the same format.</span></span>

<span data-ttu-id="01ec1-127">BC6H 形式の注意事項:</span><span class="sxs-lookup"><span data-stu-id="01ec1-127">Caveats with the BC6H format:</span></span>

-   <span data-ttu-id="01ec1-128">BC6H は浮動小数点非正規化数をサポートしていますが、INF (無限大) と NaN (非数) をサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="01ec1-128">BC6H supports floating point denormalization, but does not support INF (infinity) and NaN (not a number).</span></span> <span data-ttu-id="01ec1-129">ただし、BC6H の符号付きモード (DXGI \ _FORMAT \ _BC6H \ _SF16) は例外で、-INF (負の無限大) をサポートします。</span><span class="sxs-lookup"><span data-stu-id="01ec1-129">The exception is the signed mode of BC6H (DXGI\_FORMAT\_BC6H\_SF16), which supports -INF (negative infinity).</span></span> <span data-ttu-id="01ec1-130">この -INF のサポートは、形式そのものの結果に過ぎず、この形式のエンコーダーでは特にサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="01ec1-130">This support for -INF is merely an artifact of the format itself, and is not specifically supported by encoders for this format.</span></span> <span data-ttu-id="01ec1-131">一般に、エンコーダーが INF (正または負) または NaN 入力データを検出する場合には、圧縮前にそのデータを最大許容非 INF 表現値に変換したり、NaN を 0 にマッピングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-131">In general, when an encoder encounters INF (positive or negative) or NaN input data, the encoder should convert that data to the maximum allowable non-INF representation value, and map NaN to 0 prior to compression.</span></span>
-   <span data-ttu-id="01ec1-132">BC6H はアルファ チャネルをサポートしません。</span><span class="sxs-lookup"><span data-stu-id="01ec1-132">BC6H does not support an alpha channel.</span></span>
-   <span data-ttu-id="01ec1-133">BC6H デコーダーは、テクスチャ フィルタリングを実行する前に、圧縮解除を実行します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-133">The BC6H decoder performs decompression before it performs texture filtering.</span></span>
-   <span data-ttu-id="01ec1-134">BC6H の圧縮解除はビットアキュレートである必要があります。ハードウェアは、このドキュメントで説明されているデコーダーと同じ結果を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-134">BC6H decompression must be bit-accurate; that is, the hardware must return results that are identical to the decoder described in this documentation.</span></span>

## <a name="span-idbc6h-implementationspanspan-idbc6h-implementationspanspan-idbc6h-implementationspanbc6h-implementation"></a><span data-ttu-id="01ec1-135"><span id="BC6H-implementation"></span><span id="bc6h-implementation"></span><span id="BC6H-IMPLEMENTATION"></span>BC6H の実装</span><span class="sxs-lookup"><span data-stu-id="01ec1-135"><span id="BC6H-implementation"></span><span id="bc6h-implementation"></span><span id="BC6H-IMPLEMENTATION"></span>BC6H implementation</span></span>


<span data-ttu-id="01ec1-136">BC6H ブロックは、モードビット、圧縮エンドポイント、圧縮インデックス、パーティション インデックス (オプション) で構成されています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-136">A BC6H block consists of mode bits, compressed endpoints, compressed indices, and an optional partition index.</span></span> <span data-ttu-id="01ec1-137">この形式は、14 の異なるモードを指定します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-137">This format specifies 14 different modes.</span></span>

<span data-ttu-id="01ec1-138">エンドポイント カラーは RGB トリプレットとして保存されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-138">An endpoint color is stored as an RGB triplet.</span></span> <span data-ttu-id="01ec1-139">BC6H は、いくつかの定義されたカラー エンドポイントを横切る近似線上に色のパレットを定義します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-139">BC6H defines a palette of colors on an approximate line across a number of defined color endpoints.</span></span> <span data-ttu-id="01ec1-140">また、モードによっては、タイルを 2 つの領域に分割したり、1 つの領域として扱うこともできます。2 つの領域を持つタイルには、各領域にカラー エンドポイントが別々に設定されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-140">Also, depending on the mode, a tile can be divided into two regions or treated as a single region, where a two-region tile has a separate set of color endpoints for each region.</span></span> <span data-ttu-id="01ec1-141">BC6H はテクセルごとに 1 つのパレット インデックスを格納します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-141">BC6H stores one palette index per texel.</span></span>

<span data-ttu-id="01ec1-142">2 つの領域の場合、可能なパーティションは 32 です。</span><span class="sxs-lookup"><span data-stu-id="01ec1-142">In the two-region case, there are 32 possible partitions.</span></span>

## <a name="span-iddecoding-the-bc6h-formatspanspan-iddecoding-the-bc6h-formatspanspan-iddecoding-the-bc6h-formatspandecoding-the-bc6h-format"></a><span data-ttu-id="01ec1-143"><span id="Decoding-the-BC6H-format"></span><span id="decoding-the-bc6h-format"></span><span id="DECODING-THE-BC6H-FORMAT"></span>BC6H 形式のデコード</span><span class="sxs-lookup"><span data-stu-id="01ec1-143"><span id="Decoding-the-BC6H-format"></span><span id="decoding-the-bc6h-format"></span><span id="DECODING-THE-BC6H-FORMAT"></span>Decoding the BC6H format</span></span>


<span data-ttu-id="01ec1-144">次の擬似コードは、16 バイトの BC6H ブロックを指定して(x, y) のピクセルを圧縮解除する手順の概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-144">The pseudocode below shows the steps to decompress the pixel at (x,y) given the 16 byte BC6H block.</span></span>

``` syntax
decompress_bc6h(x, y, block)
{
    mode = extract_mode(block);
    endpoints;
    index;
    
    if(mode.type == ONE)
    {
        endpoints = extract_compressed_endpoints(mode, block);
        index = extract_index_ONE(x, y, block);
    }
    else //mode.type == TWO
    {
        partition = extract_partition(block);
        region = get_region(partition, x, y);
        endpoints = extract_compressed_endpoints(mode, region, block);
        index = extract_index_TWO(x, y, partition, block);
    }
    
    unquantize(endpoints);
    color = interpolate(index, endpoints);
    finish_unquantize(color);
}
```

<span data-ttu-id="01ec1-145">次の表に、BC6H ブロックで使用可能な 14 の形式のビット数と値を示します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-145">The following table contains the bit count and values for each of the 14 possible formats for BC6H blocks.</span></span>

| <span data-ttu-id="01ec1-146">モード</span><span class="sxs-lookup"><span data-stu-id="01ec1-146">Mode</span></span> | <span data-ttu-id="01ec1-147">パーティション インデックス</span><span class="sxs-lookup"><span data-stu-id="01ec1-147">Partition Indices</span></span> | <span data-ttu-id="01ec1-148">パーティション</span><span class="sxs-lookup"><span data-stu-id="01ec1-148">Partition</span></span> | <span data-ttu-id="01ec1-149">カラー エンドポイント</span><span class="sxs-lookup"><span data-stu-id="01ec1-149">Color Endpoints</span></span>                  | <span data-ttu-id="01ec1-150">モード ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-150">Mode Bits</span></span>      |
|------|-------------------|-----------|----------------------------------|----------------|
| <span data-ttu-id="01ec1-151">1</span><span class="sxs-lookup"><span data-stu-id="01ec1-151">1</span></span>    | <span data-ttu-id="01ec1-152">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-152">46 bits</span></span>           | <span data-ttu-id="01ec1-153">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-153">5 bits</span></span>    | <span data-ttu-id="01ec1-154">75 ビット (10.555, 10.555, 10.555)</span><span class="sxs-lookup"><span data-stu-id="01ec1-154">75 bits (10.555, 10.555, 10.555)</span></span> | <span data-ttu-id="01ec1-155">2 ビット (00)</span><span class="sxs-lookup"><span data-stu-id="01ec1-155">2 bits (00)</span></span>    |
| <span data-ttu-id="01ec1-156">2</span><span class="sxs-lookup"><span data-stu-id="01ec1-156">2</span></span>    | <span data-ttu-id="01ec1-157">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-157">46 bits</span></span>           | <span data-ttu-id="01ec1-158">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-158">5 bits</span></span>    | <span data-ttu-id="01ec1-159">75 ビット (7666, 7666, 7666)</span><span class="sxs-lookup"><span data-stu-id="01ec1-159">75 bits (7666, 7666, 7666)</span></span>       | <span data-ttu-id="01ec1-160">2 ビット (01)</span><span class="sxs-lookup"><span data-stu-id="01ec1-160">2 bits (01)</span></span>    |
| <span data-ttu-id="01ec1-161">3</span><span class="sxs-lookup"><span data-stu-id="01ec1-161">3</span></span>    | <span data-ttu-id="01ec1-162">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-162">46 bits</span></span>           | <span data-ttu-id="01ec1-163">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-163">5 bits</span></span>    | <span data-ttu-id="01ec1-164">72 ビット (11.555, 11.444, 11.444)</span><span class="sxs-lookup"><span data-stu-id="01ec1-164">72 bits (11.555, 11.444, 11.444)</span></span> | <span data-ttu-id="01ec1-165">5 ビット (00010)</span><span class="sxs-lookup"><span data-stu-id="01ec1-165">5 bits (00010)</span></span> |
| <span data-ttu-id="01ec1-166">4</span><span class="sxs-lookup"><span data-stu-id="01ec1-166">4</span></span>    | <span data-ttu-id="01ec1-167">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-167">46 bits</span></span>           | <span data-ttu-id="01ec1-168">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-168">5 bits</span></span>    | <span data-ttu-id="01ec1-169">72 ビット (11.444, 11.555, 11.444)</span><span class="sxs-lookup"><span data-stu-id="01ec1-169">72 bits (11.444, 11.555, 11.444)</span></span> | <span data-ttu-id="01ec1-170">5 ビット (00110)</span><span class="sxs-lookup"><span data-stu-id="01ec1-170">5 bits (00110)</span></span> |
| <span data-ttu-id="01ec1-171">5</span><span class="sxs-lookup"><span data-stu-id="01ec1-171">5</span></span>    | <span data-ttu-id="01ec1-172">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-172">46 bits</span></span>           | <span data-ttu-id="01ec1-173">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-173">5 bits</span></span>    | <span data-ttu-id="01ec1-174">72 ビット (11.444, 11.444, 11.555)</span><span class="sxs-lookup"><span data-stu-id="01ec1-174">72 bits (11.444, 11.444, 11.555)</span></span> | <span data-ttu-id="01ec1-175">5 ビット (01010)</span><span class="sxs-lookup"><span data-stu-id="01ec1-175">5 bits (01010)</span></span> |
| <span data-ttu-id="01ec1-176">6</span><span class="sxs-lookup"><span data-stu-id="01ec1-176">6</span></span>    | <span data-ttu-id="01ec1-177">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-177">46 bits</span></span>           | <span data-ttu-id="01ec1-178">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-178">5 bits</span></span>    | <span data-ttu-id="01ec1-179">72 ビット (9555, 9555, 9555)</span><span class="sxs-lookup"><span data-stu-id="01ec1-179">72 bits (9555, 9555, 9555)</span></span>       | <span data-ttu-id="01ec1-180">5 ビット (01110)</span><span class="sxs-lookup"><span data-stu-id="01ec1-180">5 bits (01110)</span></span> |
| <span data-ttu-id="01ec1-181">7</span><span class="sxs-lookup"><span data-stu-id="01ec1-181">7</span></span>    | <span data-ttu-id="01ec1-182">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-182">46 bits</span></span>           | <span data-ttu-id="01ec1-183">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-183">5 bits</span></span>    | <span data-ttu-id="01ec1-184">72 ビット (8666, 8555, 8555)</span><span class="sxs-lookup"><span data-stu-id="01ec1-184">72 bits (8666, 8555, 8555)</span></span>       | <span data-ttu-id="01ec1-185">5 ビット (10010)</span><span class="sxs-lookup"><span data-stu-id="01ec1-185">5 bits (10010)</span></span> |
| <span data-ttu-id="01ec1-186">8</span><span class="sxs-lookup"><span data-stu-id="01ec1-186">8</span></span>    | <span data-ttu-id="01ec1-187">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-187">46 bits</span></span>           | <span data-ttu-id="01ec1-188">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-188">5 bits</span></span>    | <span data-ttu-id="01ec1-189">72 ビット (8555, 8666, 8555)</span><span class="sxs-lookup"><span data-stu-id="01ec1-189">72 bits (8555, 8666, 8555)</span></span>       | <span data-ttu-id="01ec1-190">5 ビット (10110)</span><span class="sxs-lookup"><span data-stu-id="01ec1-190">5 bits (10110)</span></span> |
| <span data-ttu-id="01ec1-191">9</span><span class="sxs-lookup"><span data-stu-id="01ec1-191">9</span></span>    | <span data-ttu-id="01ec1-192">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-192">46 bits</span></span>           | <span data-ttu-id="01ec1-193">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-193">5 bits</span></span>    | <span data-ttu-id="01ec1-194">72 ビット (8555, 8555, 8666)</span><span class="sxs-lookup"><span data-stu-id="01ec1-194">72 bits (8555, 8555, 8666)</span></span>       | <span data-ttu-id="01ec1-195">5 ビット (11010)</span><span class="sxs-lookup"><span data-stu-id="01ec1-195">5 bits (11010)</span></span> |
| <span data-ttu-id="01ec1-196">10</span><span class="sxs-lookup"><span data-stu-id="01ec1-196">10</span></span>   | <span data-ttu-id="01ec1-197">46 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-197">46 bits</span></span>           | <span data-ttu-id="01ec1-198">5 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-198">5 bits</span></span>    | <span data-ttu-id="01ec1-199">72 ビット (6666, 6666, 6666)</span><span class="sxs-lookup"><span data-stu-id="01ec1-199">72 bits (6666, 6666, 6666)</span></span>       | <span data-ttu-id="01ec1-200">5 ビット (11110)</span><span class="sxs-lookup"><span data-stu-id="01ec1-200">5 bits (11110)</span></span> |
| <span data-ttu-id="01ec1-201">11</span><span class="sxs-lookup"><span data-stu-id="01ec1-201">11</span></span>   | <span data-ttu-id="01ec1-202">63 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-202">63 bits</span></span>           | <span data-ttu-id="01ec1-203">0 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-203">0 bits</span></span>    | <span data-ttu-id="01ec1-204">60 ビット (10.10, 10.10, 10.10)</span><span class="sxs-lookup"><span data-stu-id="01ec1-204">60 bits (10.10, 10.10, 10.10)</span></span>    | <span data-ttu-id="01ec1-205">5 ビット (00011)</span><span class="sxs-lookup"><span data-stu-id="01ec1-205">5 bits (00011)</span></span> |
| <span data-ttu-id="01ec1-206">12</span><span class="sxs-lookup"><span data-stu-id="01ec1-206">12</span></span>   | <span data-ttu-id="01ec1-207">63 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-207">63 bits</span></span>           | <span data-ttu-id="01ec1-208">0 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-208">0 bits</span></span>    | <span data-ttu-id="01ec1-209">60 ビット (11.9, 11.9, 11.9)</span><span class="sxs-lookup"><span data-stu-id="01ec1-209">60 bits (11.9, 11.9, 11.9)</span></span>       | <span data-ttu-id="01ec1-210">5 ビット (00111)</span><span class="sxs-lookup"><span data-stu-id="01ec1-210">5 bits (00111)</span></span> |
| <span data-ttu-id="01ec1-211">13</span><span class="sxs-lookup"><span data-stu-id="01ec1-211">13</span></span>   | <span data-ttu-id="01ec1-212">63 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-212">63 bits</span></span>           | <span data-ttu-id="01ec1-213">0 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-213">0 bits</span></span>    | <span data-ttu-id="01ec1-214">60 ビット (12.8, 12.8, 12.8)</span><span class="sxs-lookup"><span data-stu-id="01ec1-214">60 bits (12.8, 12.8, 12.8)</span></span>       | <span data-ttu-id="01ec1-215">5 ビット (01011)</span><span class="sxs-lookup"><span data-stu-id="01ec1-215">5 bits (01011)</span></span> |
| <span data-ttu-id="01ec1-216">14</span><span class="sxs-lookup"><span data-stu-id="01ec1-216">14</span></span>   | <span data-ttu-id="01ec1-217">63 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-217">63 bits</span></span>           | <span data-ttu-id="01ec1-218">0 ビット</span><span class="sxs-lookup"><span data-stu-id="01ec1-218">0 bits</span></span>    | <span data-ttu-id="01ec1-219">60 ビット (16.4, 16.4, 16.4)</span><span class="sxs-lookup"><span data-stu-id="01ec1-219">60 bits (16.4, 16.4, 16.4)</span></span>       | <span data-ttu-id="01ec1-220">5 ビット (01111)</span><span class="sxs-lookup"><span data-stu-id="01ec1-220">5 bits (01111)</span></span> |

 

<span data-ttu-id="01ec1-221">この表の各形式は、モード ビットによって一意に識別できます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-221">Each format in this table can be uniquely identified by the mode bits.</span></span> <span data-ttu-id="01ec1-222">最初の 10 個のモードは 2 領域のタイルに使用され、モード ビット フィールドは 2 または 5 ビット長とすることができます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-222">The first ten modes are used for two-region tiles, and the mode bit field can be either two or five bits long.</span></span> <span data-ttu-id="01ec1-223">これらのブロックには、圧縮されたカラー エンドポイント (72 または 75 ビット)、パーティション (5ビット)、およびパーティション インデックス (46ビット) のフィールドもあります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-223">These blocks also have fields for the compressed color endpoints (72 or 75 bits), the partition (5 bits), and the partition indices (46 bits).</span></span>

<span data-ttu-id="01ec1-224">圧縮されたカラー エンドポイントの場合、上記の表の値は、保存された RGB エンドポイントの精度と、各カラー値に使用されるビット数を示します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-224">For the compressed color endpoints, the values in the preceding table note the precision of the stored RGB endpoints, and the number of bits used for each color value.</span></span> <span data-ttu-id="01ec1-225">たとえば、モード 3 では、カラー エンドポイントの精度レベル 11 と、赤、青、緑の色の変換されたエンドポイントのデルタ値を保存するために使用するビット数 (それぞれ 5、4、4) を指定します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-225">For example, mode 3 specifies a color endpoint precision level of 11, and the number of bits used to store the delta values of the transformed endpoints for the red, blue and green colors (5, 4, and 4 respectively).</span></span> <span data-ttu-id="01ec1-226">モード 10 はデルタ圧縮を使用せず、4 つのカラー エンドポイントをすべて明示的に保存します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-226">Mode 10 does not use delta compression, and instead stores all four color endpoints explicitly.</span></span>

<span data-ttu-id="01ec1-227">最後の 4 つのブロック モードは 1 領域タイルに使用され、モード フィールドは 5 ビットです。</span><span class="sxs-lookup"><span data-stu-id="01ec1-227">The last four block modes are used for one-region tiles, where the mode field is 5 bits.</span></span> <span data-ttu-id="01ec1-228">これらのブロックには、エンドポイント (60 ビット) と圧縮インデックス (63 ビット) のフィールドがあります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-228">These blocks have fields for the endpoints (60 bits) and the compressed indices (63 bits).</span></span> <span data-ttu-id="01ec1-229">モード 11 ではモード 10 と同様にデルタ圧縮を使用せず、その代わりに両方のカラー エンドポイントを明示的に保存します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-229">Mode 11 (like Mode 10) does not use delta compression, and instead stores both color endpoints explicitly.</span></span>

<span data-ttu-id="01ec1-230">モード 10011、10111、11011、および11111 (示されていません) は予約されています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-230">Modes 10011, 10111, 11011, and 11111 (not shown) are reserved.</span></span> <span data-ttu-id="01ec1-231">これらをエンコーダーで使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="01ec1-231">Do not use these in your encoder.</span></span> <span data-ttu-id="01ec1-232">これらのモードの1 つを指定してハードウェアにブロックが渡された場合、その結果の圧縮解除されたブロックは、アルファ チャネルを除くすべてのチャネルにゼロを含む必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-232">If the hardware is passed blocks with one of these modes specified, the resulting decompressed block must contain all zeroes in all channels except for the alpha channel.</span></span>

<span data-ttu-id="01ec1-233">BC6H では、アルファ チャネルはモードに関係なく常に 1.0 を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-233">For BC6H, the alpha channel must always return 1.0 regardless of the mode.</span></span>

### <a name="span-idbc6h-partition-setspanspan-idbc6h-partition-setspanspan-idbc6h-partition-setspanbc6h-partition-set"></a><span data-ttu-id="01ec1-234"><span id="BC6H-partition-set"></span><span id="bc6h-partition-set"></span><span id="BC6H-PARTITION-SET"></span>BC6H パーティション セット</span><span class="sxs-lookup"><span data-stu-id="01ec1-234"><span id="BC6H-partition-set"></span><span id="bc6h-partition-set"></span><span id="BC6H-PARTITION-SET"></span>BC6H partition set</span></span>

<span data-ttu-id="01ec1-235">2 領域のタイルでは 32 のパーティション セットが使用可能で、それらは下の表で定義されています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-235">There are 32 possible partition sets for a two-region tile, and which are defined in the table below.</span></span> <span data-ttu-id="01ec1-236">各 4 x 4 ブロックは単一の形状を表しています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-236">Each 4x4 block represents a single shape.</span></span>

![BC6H パーティション セットの表](images/bc6h-partition-sets.png)

<span data-ttu-id="01ec1-238">このパーティション・セットの表では、太字の下線付きの項目は、サブセット 1 の修正インデックスの位置です (1 つ少ないビットで指定されます)。</span><span class="sxs-lookup"><span data-stu-id="01ec1-238">In this table of partition sets, the bolded and underlined entry is the location of the fix-up index for subset 1 (which is specified with one less bit).</span></span> <span data-ttu-id="01ec1-239">パーティションは常にインデックス 0 がサブセット 0 になるように配置されるため、サブセット 0 の修正インデックスは常にインデックス 0 です。</span><span class="sxs-lookup"><span data-stu-id="01ec1-239">The fix-up index for subset 0 is always index 0, as the partitioning is always arranged such that index 0 is always in subset 0.</span></span> <span data-ttu-id="01ec1-240">パーティションの順序は、左上から右下、つまり左から右へ、上から下へとなります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-240">Partition order goes from top-left to bottom-right, moving left to right and then top to bottom.</span></span>

## <a name="span-idbc6h-compressed-endpoint-formatspanspan-idbc6h-compressed-endpoint-formatspanspan-idbc6h-compressed-endpoint-formatspanbc6h-compressed-endpoint-format"></a><span data-ttu-id="01ec1-241"><span id="BC6H-compressed-endpoint-format"></span><span id="bc6h-compressed-endpoint-format"></span><span id="BC6H-COMPRESSED-ENDPOINT-FORMAT"></span>BC6H 圧縮エンドポイント形式</span><span class="sxs-lookup"><span data-stu-id="01ec1-241"><span id="BC6H-compressed-endpoint-format"></span><span id="bc6h-compressed-endpoint-format"></span><span id="BC6H-COMPRESSED-ENDPOINT-FORMAT"></span>BC6H compressed endpoint format</span></span>


![BC6H 圧縮エンドポイント形式のビット フィールド](images/bc6h-headers-med.png)

<span data-ttu-id="01ec1-243">この表は、圧縮エンドポイントのビット フィールドを、エンドポイント形式の関数として示しています。各列がエンコードを示し、各行がビット フィールドを示しています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-243">This table shows the bit fields for the compressed endpoints as a function of the endpoint format, with each column specifying an encoding and each row specifying a bit field.</span></span> <span data-ttu-id="01ec1-244">この方法では、2 領域タイルで 82 ビット、1 領域タイルで 65 ビットを使用します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-244">This approach takes up 82 bits for two-region tiles and 65 bits for one-region tiles.</span></span> <span data-ttu-id="01ec1-245">たとえば、上記で、1 領域 \[16 4\] のエンコーディング (特に右端の列) の最初の 5 ビットは m\[4:0\] となります。次の 10 ビットは rw\[9:0\] であり、同様に最後の 6 ビット は bw\[10:15\] です。</span><span class="sxs-lookup"><span data-stu-id="01ec1-245">As an example, the first 5 bits for the one-region \[16 4\] encoding above (specifically the right-most column) are bits m\[4:0\], the next 10 bits are bits rw\[9:0\], and so on with the last 6 bits containing bw\[10:15\].</span></span>

<span data-ttu-id="01ec1-246">上記の表のフィールド名は、次のように定義されています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-246">The field names in the table above are defined as follows:</span></span>

| <span data-ttu-id="01ec1-247">フィールド</span><span class="sxs-lookup"><span data-stu-id="01ec1-247">Field</span></span> | <span data-ttu-id="01ec1-248">変数</span><span class="sxs-lookup"><span data-stu-id="01ec1-248">Variable</span></span>          |
|-------|-------------------|
| <span data-ttu-id="01ec1-249">m</span><span class="sxs-lookup"><span data-stu-id="01ec1-249">m</span></span>     | <span data-ttu-id="01ec1-250">mode</span><span class="sxs-lookup"><span data-stu-id="01ec1-250">mode</span></span>              |
| <span data-ttu-id="01ec1-251">d</span><span class="sxs-lookup"><span data-stu-id="01ec1-251">d</span></span>     | <span data-ttu-id="01ec1-252">shape index</span><span class="sxs-lookup"><span data-stu-id="01ec1-252">shape index</span></span>       |
| <span data-ttu-id="01ec1-253">rw</span><span class="sxs-lookup"><span data-stu-id="01ec1-253">rw</span></span>    | <span data-ttu-id="01ec1-254">endpt\[0\].A\[0\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-254">endpt\[0\].A\[0\]</span></span> |
| <span data-ttu-id="01ec1-255">rx</span><span class="sxs-lookup"><span data-stu-id="01ec1-255">rx</span></span>    | <span data-ttu-id="01ec1-256">endpt\[0\].B\[0\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-256">endpt\[0\].B\[0\]</span></span> |
| <span data-ttu-id="01ec1-257">ry</span><span class="sxs-lookup"><span data-stu-id="01ec1-257">ry</span></span>    | <span data-ttu-id="01ec1-258">endpt\[1\].A\[0\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-258">endpt\[1\].A\[0\]</span></span> |
| <span data-ttu-id="01ec1-259">rz</span><span class="sxs-lookup"><span data-stu-id="01ec1-259">rz</span></span>    | <span data-ttu-id="01ec1-260">endpt\[1\].B\[0\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-260">endpt\[1\].B\[0\]</span></span> |
| <span data-ttu-id="01ec1-261">gw</span><span class="sxs-lookup"><span data-stu-id="01ec1-261">gw</span></span>    | <span data-ttu-id="01ec1-262">endpt\[0\].A\[1\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-262">endpt\[0\].A\[1\]</span></span> |
| <span data-ttu-id="01ec1-263">gx</span><span class="sxs-lookup"><span data-stu-id="01ec1-263">gx</span></span>    | <span data-ttu-id="01ec1-264">endpt\[0\].B\[1\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-264">endpt\[0\].B\[1\]</span></span> |
| <span data-ttu-id="01ec1-265">gy</span><span class="sxs-lookup"><span data-stu-id="01ec1-265">gy</span></span>    | <span data-ttu-id="01ec1-266">endpt\[1\].A\[1\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-266">endpt\[1\].A\[1\]</span></span> |
| <span data-ttu-id="01ec1-267">gz</span><span class="sxs-lookup"><span data-stu-id="01ec1-267">gz</span></span>    | <span data-ttu-id="01ec1-268">endpt\[1\].B\[1\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-268">endpt\[1\].B\[1\]</span></span> |
| <span data-ttu-id="01ec1-269">bw</span><span class="sxs-lookup"><span data-stu-id="01ec1-269">bw</span></span>    | <span data-ttu-id="01ec1-270">endpt\[0\].A\[2\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-270">endpt\[0\].A\[2\]</span></span> |
| <span data-ttu-id="01ec1-271">bx</span><span class="sxs-lookup"><span data-stu-id="01ec1-271">bx</span></span>    | <span data-ttu-id="01ec1-272">endpt\[0\].B\[2\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-272">endpt\[0\].B\[2\]</span></span> |
| <span data-ttu-id="01ec1-273">by</span><span class="sxs-lookup"><span data-stu-id="01ec1-273">by</span></span>    | <span data-ttu-id="01ec1-274">endpt\[1\].A\[2\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-274">endpt\[1\].A\[2\]</span></span> |
| <span data-ttu-id="01ec1-275">bz</span><span class="sxs-lookup"><span data-stu-id="01ec1-275">bz</span></span>    | <span data-ttu-id="01ec1-276">endpt\[1\].B\[2\]</span><span class="sxs-lookup"><span data-stu-id="01ec1-276">endpt\[1\].B\[2\]</span></span> |

 

<span data-ttu-id="01ec1-277">Endpt\[i\] (i は 0 または 1) は、それぞれ 0 番目または 1 番目のエンドポイントを示します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-277">Endpt\[i\], where i is either 0 or 1, refers to the 0th or 1st set of endpoints respectively.</span></span>
## <a name="span-idsign-extension-for-endpoint-valuesspanspan-idsign-extension-for-endpoint-valuesspanspan-idsign-extension-for-endpoint-valuesspansign-extension-for-endpoint-values"></a><span data-ttu-id="01ec1-278"><span id="Sign-extension-for-endpoint-values"></span><span id="sign-extension-for-endpoint-values"></span><span id="SIGN-EXTENSION-FOR-ENDPOINT-VALUES"></span>エンドポイント値の符号拡張</span><span class="sxs-lookup"><span data-stu-id="01ec1-278"><span id="Sign-extension-for-endpoint-values"></span><span id="sign-extension-for-endpoint-values"></span><span id="SIGN-EXTENSION-FOR-ENDPOINT-VALUES"></span>Sign extension for endpoint values</span></span>


<span data-ttu-id="01ec1-279">2 領域タイルでは、符号拡張が可能な 4 つのエンドポイント値があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-279">For two-region tiles, there are four endpoint values that can be sign extended.</span></span> <span data-ttu-id="01ec1-280">Endpt\[0\].A は、形式が符号付き形式の場合にのみ符号付きとなります。他のエンドポイントは、エンドポイントが変換された場合、または形式が符号付き形式である場合にのみ、符号付きとなります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-280">Endpt\[0\].A is signed only if the format is a signed format; the other endpoints are signed only if the endpoint was transformed, or if the format is a signed format.</span></span> <span data-ttu-id="01ec1-281">以下のコードは、2 領域のエンドポイント値の符号を拡張するアルゴリズムを示しています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-281">The code below demonstrates the algorithm for extending the sign of two-region endpoint values.</span></span>

``` syntax
static void sign_extend_two_region(Pattern &p, IntEndpts endpts[NREGIONS_TWO])
{
    for (int i=0; i<NCHANNELS; ++i)
    {
      if (BC6H::FORMAT == SIGNED_F16)
        endpts[0].A[i] = SIGN_EXTEND(endpts[0].A[i], p.chan[i].prec);
      if (p.transformed || BC6H::FORMAT == SIGNED_F16)
      {
        endpts[0].B[i] = SIGN_EXTEND(endpts[0].B[i], p.chan[i].delta[0]);
        endpts[1].A[i] = SIGN_EXTEND(endpts[1].A[i], p.chan[i].delta[1]);
        endpts[1].B[i] = SIGN_EXTEND(endpts[1].B[i], p.chan[i].delta[2]);
      }
    }
}
```

<span data-ttu-id="01ec1-282">1 領域のタイルでは、動作は同じですが、endpt\[1\] のみが削除されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-282">For one-region tiles, the behavior is the same, only with endpt\[1\] removed.</span></span>

``` syntax
static void sign_extend_one_region(Pattern &p, IntEndpts endpts[NREGIONS_ONE])
{
    for (int i=0; i<NCHANNELS; ++i)
    {
    if (BC6H::FORMAT == SIGNED_F16)
        endpts[0].A[i] = SIGN_EXTEND(endpts[0].A[i], p.chan[i].prec);
    if (p.transformed || BC6H::FORMAT == SIGNED_F16) 
        endpts[0].B[i] = SIGN_EXTEND(endpts[0].B[i], p.chan[i].delta[0]);
    }
}
```

## <a name="span-idtransform-inversion-for-endpoint-valuesspanspan-idtransform-inversion-for-endpoint-valuesspanspan-idtransform-inversion-for-endpoint-valuesspantransform-inversion-for-endpoint-values"></a><span data-ttu-id="01ec1-283"><span id="Transform-inversion-for-endpoint-values"></span><span id="transform-inversion-for-endpoint-values"></span><span id="TRANSFORM-INVERSION-FOR-ENDPOINT-VALUES"></span>エンドポイント値の変換の反転</span><span class="sxs-lookup"><span data-stu-id="01ec1-283"><span id="Transform-inversion-for-endpoint-values"></span><span id="transform-inversion-for-endpoint-values"></span><span id="TRANSFORM-INVERSION-FOR-ENDPOINT-VALUES"></span>Transform inversion for endpoint values</span></span>


<span data-ttu-id="01ec1-284">2 領域タイルでは、変換は差分エンコーディングの逆数を適用し、endpt\[0\].A の基本値を他の 3 つのエントリに加算し、合計 9 回の加算演算を行います。</span><span class="sxs-lookup"><span data-stu-id="01ec1-284">For two-region tiles, the transform applies the inverse of the difference encoding, adding the base value at endpt\[0\].A to the three other entries for a total of 9 add operations.</span></span> <span data-ttu-id="01ec1-285">下の画像では、基本値は「A0」として表され、最も高い浮動小数点精度を持ちます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-285">In the image below, the base value is represented as "A0" and has the highest floating point precision.</span></span> <span data-ttu-id="01ec1-286">「A1」「B0」「B1」は全てアンカー値から算出されたデルタであり、これらのデルタ値は、より低い精度で表されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-286">"A1," "B0," and "B1" are all deltas calculated from the anchor value, and these delta values are represented with lower precision.</span></span> <span data-ttu-id="01ec1-287">(A0 は endpt\[0\].A に、B0 は endpt\[0\].Bに、A1 は endpt\[1\].A に、B1 は endpt\[1\].B に対応します。)</span><span class="sxs-lookup"><span data-stu-id="01ec1-287">(A0 corresponds to endpt\[0\].A, B0 corresponds to endpt\[0\].B, A1 corresponds to endpt\[1\].A, and B1 corresponds to endpt\[1\].B.)</span></span>

![変換の反転のエンドポイント値の計算](images/bc6h-transform-inverse.png)

<span data-ttu-id="01ec1-289">1 領域のタイルでは、デルタ オフセットは 1 つだけであるため、3 つの加算演算のみとなります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-289">For one-region tiles there is only one delta offset, and therefore only 3 add operations.</span></span>

<span data-ttu-id="01ec1-290">圧縮解除プログラムは、反転の結果が endpt\[0\].a の精度をオーバーフローしないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-290">The decompressor must ensure that that the results of the inverse transform will not overflow the precision of endpt\[0\].a.</span></span> <span data-ttu-id="01ec1-291">オーバーフローの場合には、反転から生じる値は、同じビット数内でラップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-291">In the case of an overflow, the values resulting from the inverse transform must wrap within the same number of bits.</span></span> <span data-ttu-id="01ec1-292">A0 の精度が「p」ビットの場合、変換アルゴリズムは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-292">If the precision of A0 is "p" bits, then the transform algorithm is:</span></span>

`B0 = (B0 + A0) & ((1 << p) - 1)`

<span data-ttu-id="01ec1-293">符号付き形式の場合、デルタ計算の結果も符号拡張される必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-293">For signed formats, the results of the delta calculation must be sign extended as well.</span></span> <span data-ttu-id="01ec1-294">符号拡張演算が両方の符号を拡張することを考慮する場合には、0 が正、1 が負であり、0 の符号拡張がこのクランプの処理を行います。</span><span class="sxs-lookup"><span data-stu-id="01ec1-294">If the sign extension operation considers extending both signs, where 0 is positive and 1 is negative, then the sign extension of 0 takes care of the clamp above.</span></span> <span data-ttu-id="01ec1-295">同様に、このクランプ後に、値 1 (負) のみ符号拡張する必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-295">Equivalently, after the clamp above, only a value of 1 (negative) needs to be sign extended.</span></span>

## <a name="span-idunquantization-of-color-endpointsspanspan-idunquantization-of-color-endpointsspanspan-idunquantization-of-color-endpointsspanunquantization-of-color-endpoints"></a><span data-ttu-id="01ec1-296"><span id="Unquantization-of-color-endpoints"></span><span id="unquantization-of-color-endpoints"></span><span id="UNQUANTIZATION-OF-COLOR-ENDPOINTS"></span>カラー エンドポイントの非量子化</span><span class="sxs-lookup"><span data-stu-id="01ec1-296"><span id="Unquantization-of-color-endpoints"></span><span id="unquantization-of-color-endpoints"></span><span id="UNQUANTIZATION-OF-COLOR-ENDPOINTS"></span>Unquantization of color endpoints</span></span>


<span data-ttu-id="01ec1-297">圧縮されていないエンドポイントでは、次のステップはカラー エンドポイントの最初の非量子化を実行することです。</span><span class="sxs-lookup"><span data-stu-id="01ec1-297">Given the uncompressed endpoints, the next step is to perform an initial unquantization of the color endpoints.</span></span> <span data-ttu-id="01ec1-298">これには次の 3 つのステップがあります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-298">This involves three steps:</span></span>

-   <span data-ttu-id="01ec1-299">カラー パレットの非量子化</span><span class="sxs-lookup"><span data-stu-id="01ec1-299">An unquantization of the color palettes</span></span>
-   <span data-ttu-id="01ec1-300">パレットの補間</span><span class="sxs-lookup"><span data-stu-id="01ec1-300">Interpolation of the palettes</span></span>
-   <span data-ttu-id="01ec1-301">非量子化の最終化</span><span class="sxs-lookup"><span data-stu-id="01ec1-301">Unquantization finalization</span></span>

<span data-ttu-id="01ec1-302">非量子化プロセスを 2 つの部分 (補間前のカラー パレットの非量子化と、補間後の最終の非量子化) に分離することにより、パレット補間前の完全非量子化プロセスと比較して必要な乗算演算の数が減少します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-302">Separating the unquantization process into two parts (color palette unquantization before interpolation and final unquantization after interpolation) reduces the number of multiplication operations required when compared to a full unquantization process before palette interpolation.</span></span>

<span data-ttu-id="01ec1-303">下のコードは、元の 16 ビット カラー値の見積もりを取得し、提供されたウェイト値を使用して 6 つの追加のカラー値をパレットに追加するプロセスを示しています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-303">The code below illustrates the process for retrieving estimates of the original 16-bit color values, and then using the supplied weight values to add 6 additional color values to the palette.</span></span> <span data-ttu-id="01ec1-304">同じ操作が各チャネルで実行されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-304">The same operation is performed on each channel.</span></span>

``` syntax
int aWeight3[] = {0, 9, 18, 27, 37, 46, 55, 64};
int aWeight4[] = {0, 4, 9, 13, 17, 21, 26, 30, 34, 38, 43, 47, 51, 55, 60, 64};

// c1, c2: endpoints of a component
void generate_palette_unquantized(UINT8 uNumIndices, int c1, int c2, int prec, UINT16 palette[NINDICES])
{
    int* aWeights;
    if(uNumIndices == 8)
        aWeights = aWeight3;
    else  // uNumIndices == 16
        aWeights = aWeight4;

    int a = unquantize(c1, prec); 
    int b = unquantize(c2, prec);

    // interpolate
    for(int i = 0; i < uNumIndices; ++i)
        palette[i] = finish_unquantize((a * (64 - aWeights[i]) + b * aWeights[i] + 32) >> 6);
}
```

<span data-ttu-id="01ec1-305">次のコード サンプルでは、補間のプロセスを示しています。次のようなことがわかります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-305">The next code sample demonstrates the interpolation process, with the following observations:</span></span>

-   <span data-ttu-id="01ec1-306">**非量子化**関数 (下記) のカラー値の有効な範囲は -32768 〜 65535 であるため、インターポレーターは 17 ビット符号付き算術演算を使って実装されています。</span><span class="sxs-lookup"><span data-stu-id="01ec1-306">Since the full range of color values for the **unquantize** function (below) are from -32768 to 65535, the interpolator is implemented using 17-bit signed arithmetic.</span></span>
-   <span data-ttu-id="01ec1-307">補間後、値は **finish\_unquantize** 関数 (このセクションの 3 番目のサンプルで説明しています) に渡され、最終的なスケーリングが適用されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-307">After interpolation, the values are passed to the **finish\_unquantize** function (described in the third sample in this section), which applies the final scaling.</span></span>
-   <span data-ttu-id="01ec1-308">すべてのハードウェアの圧縮解除プログラムは、これらの関数でビットアキュレートの結果を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="01ec1-308">All hardware decompressors are required to return bit-accurate results with these functions.</span></span>

``` syntax
int unquantize(int comp, int uBitsPerComp)
{
    int unq, s = 0;
    switch(BC6H::FORMAT)
    {
    case UNSIGNED_F16:
        if(uBitsPerComp >= 15)
            unq = comp;
        else if(comp == 0)
            unq = 0;
        else if(comp == ((1 << uBitsPerComp) - 1))
            unq = 0xFFFF;
        else
            unq = ((comp << 16) + 0x8000) >> uBitsPerComp;
        break;

    case SIGNED_F16:
        if(uBitsPerComp >= 16)
            unq = comp;
        else
        {
            if(comp < 0)
            {
                s = 1;
                comp = -comp;
            }

            if(comp == 0)
                unq = 0;
            else if(comp >= ((1 << (uBitsPerComp - 1)) - 1))
                unq = 0x7FFF;
            else
                unq = ((comp << 15) + 0x4000) >> (uBitsPerComp-1);

            if(s)
                unq = -unq;
        }
        break;
    }
    return unq;
}
```

<span data-ttu-id="01ec1-309">**finish\_unquantize** はパレット補間後に呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-309">**finish\_unquantize** is called after palette interpolation.</span></span> <span data-ttu-id="01ec1-310">**Unquantize** 関数は、符号付きの場合は 31/32、符号なしの場合は 31/64 で、スケーリングを延期します。</span><span class="sxs-lookup"><span data-stu-id="01ec1-310">The **unquantize** function postpones the scaling by 31/32 for signed, 31/64 for unsigned.</span></span> <span data-ttu-id="01ec1-311">この動作は、パレット補間の完了後の最終値を有効な半範囲 (-0x7BFF〜0x7BFF) にして、必要な乗算の数を減らすために必要です。</span><span class="sxs-lookup"><span data-stu-id="01ec1-311">This behavior is required to get the final value into valid half range(-0x7BFF ~ 0x7BFF) after the palette interpolation is completed in order to reduce the number of necessary multiplications.</span></span> <span data-ttu-id="01ec1-312">**finish\_unquantize**は最終的なスケーリングを適用して、**unsigned short** 値を返し、それが **half** に再解釈されます。</span><span class="sxs-lookup"><span data-stu-id="01ec1-312">**finish\_unquantize** applies the final scaling and returns an **unsigned short** value that gets reinterpreted into **half**.</span></span>

``` syntax
unsigned short finish_unquantize(int comp)
{
    if(BC6H::FORMAT == UNSIGNED_F16)
    {
        comp = (comp * 31) >> 6;                                         // scale the magnitude by 31/64
        return (unsigned short) comp;
    }
    else // (BC6H::FORMAT == SIGNED_F16)
    {
        comp = (comp < 0) ? -(((-comp) * 31) >> 5) : (comp * 31) >> 5;   // scale the magnitude by 31/32
        int s = 0;
        if(comp < 0)
        {
            s = 0x8000;
            comp = -comp;
        }
        return (unsigned short) (s | comp);
    }
}
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="01ec1-313"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="01ec1-313"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="01ec1-314">テクスチャのブロック圧縮</span><span class="sxs-lookup"><span data-stu-id="01ec1-314">Texture block compression</span></span>](texture-block-compression.md)

 

 




