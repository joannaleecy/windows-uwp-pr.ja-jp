---
title: BC7 形式
description: BC7 形式は、RGB および RGBA データの高品質圧縮に使用される、テクスチャ圧縮形式です。
ms.assetid: 788B6E8C-9A1F-45F9-BE49-742285E8D8A6
keywords:
- BC7 形式
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 70380dd0bd07cfe0c81e8339f8606029663b47d4
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7279534"
---
# <a name="bc7-format"></a><span data-ttu-id="1f2f4-104">BC7 形式</span><span class="sxs-lookup"><span data-stu-id="1f2f4-104">BC7 format</span></span>


<span data-ttu-id="1f2f4-105">BC7 形式は、RGB および RGBA データの高品質圧縮に使用される、テクスチャ圧縮形式です。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-105">The BC7 format is a texture compression format used for high-quality compression of RGB and RGBA data.</span></span>

<span data-ttu-id="1f2f4-106">BC7 形式のブロック モードについて詳しくは、[BC7 形式モード リファレンス](https://msdn.microsoft.com/library/windows/desktop/hh308954)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-106">For info about the block modes of the BC7 format, see [BC7 Format Mode Reference](https://msdn.microsoft.com/library/windows/desktop/hh308954).</span></span>

## <a name="span-idabout-bc7-dxgi-format-bc7spanspan-idabout-bc7-dxgi-format-bc7spanspan-idabout-bc7-dxgi-format-bc7spanabout-bc7dxgiformatbc7"></a><span data-ttu-id="1f2f4-107"><span id="About-BC7-DXGI-FORMAT-BC7"></span><span id="about-bc7-dxgi-format-bc7"></span><span id="ABOUT-BC7-DXGI-FORMAT-BC7"></span>BC7/DXGI\_FORMAT\_BC7 について</span><span class="sxs-lookup"><span data-stu-id="1f2f4-107"><span id="About-BC7-DXGI-FORMAT-BC7"></span><span id="about-bc7-dxgi-format-bc7"></span><span id="ABOUT-BC7-DXGI-FORMAT-BC7"></span>About BC7/DXGI\_FORMAT\_BC7</span></span>


<span data-ttu-id="1f2f4-108">BC7 は、次の DXGI \ _FORMAT 列挙値によって指定されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-108">BC7 is specified by the following DXGI\_FORMAT enumeration values:</span></span>

-   <span data-ttu-id="1f2f4-109">**DXGI\_FORMAT\_BC7\_TYPELESS**</span><span class="sxs-lookup"><span data-stu-id="1f2f4-109">**DXGI\_FORMAT\_BC7\_TYPELESS**.</span></span>
-   <span data-ttu-id="1f2f4-110">**DXGI\_FORMAT\_BC7\_UNORM**</span><span class="sxs-lookup"><span data-stu-id="1f2f4-110">**DXGI\_FORMAT\_BC7\_UNORM**.</span></span>
-   <span data-ttu-id="1f2f4-111">**DXGI\_FORMAT\_BC7\_UNORM\_SRGB**</span><span class="sxs-lookup"><span data-stu-id="1f2f4-111">**DXGI\_FORMAT\_BC7\_UNORM\_SRGB**.</span></span>

<span data-ttu-id="1f2f4-112">BC7 形式は、[Texture2D](https://msdn.microsoft.com/library/windows/desktop/bb205277) (配列を含む)、Texture3D、または TextureCube (配列を含む) のテクスチャ リソースに使用できます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-112">The BC7 format can be used for [Texture2D](https://msdn.microsoft.com/library/windows/desktop/bb205277) (including arrays), Texture3D, or TextureCube (including arrays) texture resources.</span></span> <span data-ttu-id="1f2f4-113">同様に、この形式は、これらのリソースに関連付けられた任意のミップマップ サーフェスに適用されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-113">Similarly, this format applies to any MIP-map surfaces associated with these resources.</span></span>

<span data-ttu-id="1f2f4-114">BC7 は、16バイト (128 ビット) の固定ブロックサイズと 4 × 4 テクセルの固定タイル サイズを使用します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-114">BC7 uses a fixed block size of 16 bytes (128 bits) and a fixed tile size of 4x4 texels.</span></span> <span data-ttu-id="1f2f4-115">以前の BC 形式と同様に、サポートされるタイル サイズ (4 x 4) よりも大きなテクスチャ画像は、複数のブロックを使用して圧縮されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-115">As with previous BC formats, texture images larger than the supported tile size (4x4) are compressed by using multiple blocks.</span></span> <span data-ttu-id="1f2f4-116">このアドレス指定 ID は、3 次元画像とミップマップ、キューブマップ、テクスチャ配列にも適用されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-116">This addressing identity also applies to three-dimensional images and MIP-maps, cubemaps, and texture arrays.</span></span> <span data-ttu-id="1f2f4-117">すべての画像タイルは同じ形式でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-117">All image tiles must be of the same format.</span></span>

<span data-ttu-id="1f2f4-118">BC7 は、3 チャネル (RGB) と 4 チャネル (RGBA) の不動点データ画像を圧縮します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-118">BC7 compresses both three-channel (RGB) and four-channel (RGBA) fixed-point data images.</span></span> <span data-ttu-id="1f2f4-119">一般的に、ソース データはカラー成分 (チャネル) ごとに 8 ビットですが、この形式はカラー成分ごとに上位ビットでソース データをエンコードすることができます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-119">Typically, source data is 8 bits per color component (channel), although the format is capable of encoding source data with higher bits per color component.</span></span> <span data-ttu-id="1f2f4-120">すべての画像タイルは同じ形式でなければなりません。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-120">All image tiles must be of the same format.</span></span>

<span data-ttu-id="1f2f4-121">BC7 デコーダーは、テクスチャ フィルタリングが適用される前に圧縮解除を実行します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-121">The BC7 decoder performs decompression before texture filtering is applied.</span></span>

<span data-ttu-id="1f2f4-122">BC7 の圧縮解除ハードウェアはビットアキュレートである必要があります。つまり、ハードウェアはこのドキュメントで説明されているデコーダーによって返される結果と同一の結果を返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-122">BC7 decompression hardware must be bit accurate; that is, the hardware must return results that are identical to the results returned by the decoder described in this document.</span></span>

## <a name="span-idbc7-implementationspanspan-idbc7-implementationspanspan-idbc7-implementationspanbc7-implementation"></a><span data-ttu-id="1f2f4-123"><span id="BC7-Implementation"></span><span id="bc7-implementation"></span><span id="BC7-IMPLEMENTATION"></span>BC7 の実装</span><span class="sxs-lookup"><span data-stu-id="1f2f4-123"><span id="BC7-Implementation"></span><span id="bc7-implementation"></span><span id="BC7-IMPLEMENTATION"></span>BC7 Implementation</span></span>


<span data-ttu-id="1f2f4-124">BC7 の実装では、16 バイト (128ビット) ブロックの最下位ビットに指定されたモードで、8 つのモードのうちの 1 つを指定できます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-124">A BC7 implementation can specify one of 8 modes, with the mode specified in the least significant bit of the 16 byte (128 bit) block.</span></span> <span data-ttu-id="1f2f4-125">モードは 0 または 0 の値の後に 1 が続く複数ビットによりエンコードされます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-125">The mode is encoded by zero or more bits with a value of 0 followed by a 1.</span></span>

<span data-ttu-id="1f2f4-126">BC7 ブロックには、複数のエンドポイントのペアを含むことができます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-126">A BC7 block can contain multiple endpoint pairs.</span></span> <span data-ttu-id="1f2f4-127">エンドポイントのペアに対応するインデックスのセットは、「サブセット」と呼ばれることがあります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-127">The set of indices that correspond to an endpoint pair may be referred to as a "subset."</span></span> <span data-ttu-id="1f2f4-128">また、いくつかのブロック モードでは、エンドポイントの表現は、「RBGP」とも呼ばれる形式でエンコードされます。「P」ビットはエンドポイントのカラー成分の共有最下位ビットを表します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-128">Also, in some block modes, the endpoint representation is encoded in a form that can be referred to as "RBGP," where the "P" bit represents a shared least significant bit for the color components of the endpoint.</span></span> <span data-ttu-id="1f2f4-129">たとえば、形式のエンドポイント表現が「RGB 5.5.5.1」である場合、エンドポイントは RGB 6.6.6 の値として解釈されます。P ビットの状態は各コンポーネントの最下位ビットを定義します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-129">For example, if the endpoint representation for the format is "RGB 5.5.5.1," then the endpoint is interpreted as an RGB 6.6.6 value, where the state of the P-bit defines the least significant bit of each component.</span></span> <span data-ttu-id="1f2f4-130">同様に、アルファ チャネルを持つソース データでは、形式の表現が「RGBAP 5.5.5.5.1」である場合、エンドポイントは RGBA 6.6.6.6 と解釈されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-130">Similarly, for source data with an alpha channel, if the representation for the format is "RGBAP 5.5.5.5.1," then the endpoint is interpreted as RGBA 6.6.6.6.</span></span> <span data-ttu-id="1f2f4-131">ブロック モードに応じて、サブセットの両方のエンドポイント (サブセットごとに 2 P ビット) の共有最下位ビット、またはサブセットのエンドポイント間で共有される(サブセットごとに 1 P ビット) 最下位ビットを指定できます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-131">Depending on the block mode, you can specify the shared least significant bit for either both endpoints of a subset individually (2 P-bits per subset), or shared between endpoints of a subset (1 P-bit per subset).</span></span>

<span data-ttu-id="1f2f4-132">アルファ成分を明示的にエンコードしない BC7 ブロックの場合、BC7 ブロックはモード ビット、パーティション ビット、圧縮エンドポイント、圧縮インデックス、および P ビット (オプション) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-132">For BC7 blocks that don't explicitly encode the alpha component, a BC7 block consists of mode bits, partition bits, compressed endpoints, compressed indices, and an optional P-bit.</span></span> <span data-ttu-id="1f2f4-133">これらのブロックでは、エンドポイントは RGB のみの表現を持ち、アルファ成分はソース データ内のすべてのテクセルについて 1.0 としてデコードされます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-133">In these blocks the endpoints have an RGB-only representation and the alpha component is decoded as 1.0 for all texels in the source data.</span></span>

<span data-ttu-id="1f2f4-134">色成分とアルファ成分を組み合わせた BC7 ブロックの場合、ブロックはモードビット、圧縮エンドポイント、圧縮インデックス、およびパーティション ビットと P ビット (オプション) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-134">For BC7 blocks that have combined color and alpha components, a block consists of mode bits, compressed endpoints, compressed indices, and optional partition bits and a P-bit.</span></span> <span data-ttu-id="1f2f4-135">これらのブロックでは、エンドポイントの色は RGBA 形式で表現され、アルファ成分の値は色成分の値により補間されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-135">In these blocks, the endpoint colors are expressed in RGBA format, and alpha component values are interpolated alongside the color component values.</span></span>

<span data-ttu-id="1f2f4-136">個別の色成分とアルファ成分を持つ BC7 ブロックの場合、ブロックはモード ビット、回転ビット、圧縮エンドポイント、圧縮インデックス、およびインデックス セレクタ ビット (オプション) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-136">For BC7 blocks that have separate color and alpha components, a block consists of mode bits, rotation bits, compressed endpoints, compressed indices, and an optional index selector bit.</span></span> <span data-ttu-id="1f2f4-137">これらのブロックには、有効な RGB ベクトル \[R, G, B\] およびスカラー アルファ チャネル \[A\] が別々にエンコードされています。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-137">These blocks have an effective RGB vector \[R, G, B\] and a scalar alpha channel \[A\] separately encoded.</span></span>

<span data-ttu-id="1f2f4-138">次の表に、各ブロック タイプのコンポーネントを示します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-138">The following table lists the components of each block type.</span></span>

| <span data-ttu-id="1f2f4-139">BC7 ブロックに含まれるもの</span><span class="sxs-lookup"><span data-stu-id="1f2f4-139">BC7 block contains...</span></span>     | <span data-ttu-id="1f2f4-140">モード ビット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-140">mode bits</span></span> | <span data-ttu-id="1f2f4-141">回転ビット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-141">rotation bits</span></span> | <span data-ttu-id="1f2f4-142">インデックス セレクター ビット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-142">index selector bit</span></span> | <span data-ttu-id="1f2f4-143">パーティション ビット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-143">partition bits</span></span> | <span data-ttu-id="1f2f4-144">圧縮エンドポイント</span><span class="sxs-lookup"><span data-stu-id="1f2f4-144">compressed endpoints</span></span> | <span data-ttu-id="1f2f4-145">P ビット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-145">P-bit</span></span>    | <span data-ttu-id="1f2f4-146">圧縮インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-146">compressed indices</span></span> |
|---------------------------|-----------|---------------|--------------------|----------------|----------------------|----------|--------------------|
| <span data-ttu-id="1f2f4-147">色成分のみ</span><span class="sxs-lookup"><span data-stu-id="1f2f4-147">color components only</span></span>     | <span data-ttu-id="1f2f4-148">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-148">required</span></span>  | <span data-ttu-id="1f2f4-149">なし</span><span class="sxs-lookup"><span data-stu-id="1f2f4-149">N/A</span></span>           | <span data-ttu-id="1f2f4-150">なし</span><span class="sxs-lookup"><span data-stu-id="1f2f4-150">N/A</span></span>                | <span data-ttu-id="1f2f4-151">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-151">required</span></span>       | <span data-ttu-id="1f2f4-152">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-152">required</span></span>             | <span data-ttu-id="1f2f4-153">オプション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-153">optional</span></span> | <span data-ttu-id="1f2f4-154">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-154">required</span></span>           |
| <span data-ttu-id="1f2f4-155">色とアルファの組み合わせ</span><span class="sxs-lookup"><span data-stu-id="1f2f4-155">color + alpha combined</span></span>    | <span data-ttu-id="1f2f4-156">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-156">required</span></span>  | <span data-ttu-id="1f2f4-157">なし</span><span class="sxs-lookup"><span data-stu-id="1f2f4-157">N/A</span></span>           | <span data-ttu-id="1f2f4-158">なし</span><span class="sxs-lookup"><span data-stu-id="1f2f4-158">N/A</span></span>                | <span data-ttu-id="1f2f4-159">オプション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-159">optional</span></span>       | <span data-ttu-id="1f2f4-160">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-160">required</span></span>             | <span data-ttu-id="1f2f4-161">オプション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-161">optional</span></span> | <span data-ttu-id="1f2f4-162">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-162">required</span></span>           |
| <span data-ttu-id="1f2f4-163">色とアルファが別々</span><span class="sxs-lookup"><span data-stu-id="1f2f4-163">color and alpha separated</span></span> | <span data-ttu-id="1f2f4-164">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-164">required</span></span>  | <span data-ttu-id="1f2f4-165">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-165">required</span></span>      | <span data-ttu-id="1f2f4-166">オプション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-166">optional</span></span>           | <span data-ttu-id="1f2f4-167">なし</span><span class="sxs-lookup"><span data-stu-id="1f2f4-167">N/A</span></span>            | <span data-ttu-id="1f2f4-168">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-168">required</span></span>             | <span data-ttu-id="1f2f4-169">なし</span><span class="sxs-lookup"><span data-stu-id="1f2f4-169">N/A</span></span>      | <span data-ttu-id="1f2f4-170">必須</span><span class="sxs-lookup"><span data-stu-id="1f2f4-170">required</span></span>           |

 

<span data-ttu-id="1f2f4-171">BC7 は、2 つのエンドポイント間の近似線上に色のパレットを定義します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-171">BC7 defines a palette of colors on an approximate line between two endpoints.</span></span> <span data-ttu-id="1f2f4-172">モード値によって、ブロックごとのエンドポイント ペアの補間の数が決まります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-172">The mode value determines the number of interpolating endpoint pairs per block.</span></span> <span data-ttu-id="1f2f4-173">BC7 はテクセルごとに 1 つのパレット インデックスを格納します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-173">BC7 stores one palette index per texel.</span></span>

<span data-ttu-id="1f2f4-174">エンコーダーは、エンドポイントのペアに対応するインデックスの各サブセットについて、そのサブセットの圧縮インデックス データの 1 ビットの状態を固定します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-174">For each subset of indices that corresponds to a pair of endpoints, the encoder fixes the state of one bit of the compressed index data for that subset.</span></span> <span data-ttu-id="1f2f4-175">これは次のように行われます。まずエンドポイントの順序を選択して、指定された「修正」インデックスのためのインデックスがその最上位ビットを 0 に設定するようにします。するとそれは破棄されて、サブセットごとに 1 ビットが保存されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-175">It does so by choosing an endpoint order that allows the index for the designated "fix-up" index to set its most significant bit to 0, and which can then be discarded, saving one bit per subset.</span></span> <span data-ttu-id="1f2f4-176">単一のサブセットのみを持つブロック モードの場合、修正インデックスは常にインデックス 0 です。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-176">For block modes with only a single subset, the fix-up index is always index 0.</span></span>

## <a name="span-iddecoding-the-bc7-formatspanspan-iddecoding-the-bc7-formatspanspan-iddecoding-the-bc7-formatspandecoding-the-bc7-format"></a><span data-ttu-id="1f2f4-177"><span id="Decoding-the-BC7-Format"></span><span id="decoding-the-bc7-format"></span><span id="DECODING-THE-BC7-FORMAT"></span>BC7 形式のデコード</span><span class="sxs-lookup"><span data-stu-id="1f2f4-177"><span id="Decoding-the-BC7-Format"></span><span id="decoding-the-bc7-format"></span><span id="DECODING-THE-BC7-FORMAT"></span>Decoding the BC7 Format</span></span>


<span data-ttu-id="1f2f4-178">次の擬似コードは、16 バイトの BC7 ブロックを指定して(x, y) のピクセルを圧縮解除する手順の概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-178">The following pseudocode outlines the steps to decompress the pixel at (x,y) given the 16 byte BC7 block.</span></span>

``` syntax
decompress_bc7(x, y, block)
{
    mode = extract_mode(block);
    
    //decode partition data from explicit partition bits
    subset_index = 0;
    num_subsets = 1;
    
    if (mode.type == 0 OR == 1 OR == 2 OR == 3 OR == 7)
    {
        num_subsets = get_num_subsets(mode.type);
        partition_set_id = extract_partition_set_id(mode, block);
        subset_index = get_partition_index(num_subsets, partition_set_id, x, y);
    }
    
    //extract raw, compressed endpoint bits
    UINT8 endpoint_array[num_subsets][4] = extract_endpoints(mode, block);
    
    //decode endpoint color and alpha for each subset
    fully_decode_endpoints(endpoint_array, mode, block);
    
    //endpoints are now complete.
    UINT8 endpoint_start[4] = endpoint_array[2 * subset_index];
    UINT8 endpoint_end[4]   = endpoint_array[2 * subset_index + 1];
        
    //Determine the palette index for this pixel
    alpha_index     = get_alpha_index(block, mode, x, y);
    alpha_bitcount  = get_alpha_bitcount(block, mode);
    color_index     = get_color_index(block, mode, x, y);
    color_bitcount  = get_color_bitcount(block, mode);

    //determine output
    UINT8 output[4];
    output.rgb = interpolate(endpoint_start.rgb, endpoint_end.rgb, color_index, color_bitcount);
    output.a   = interpolate(endpoint_start.a,   endpoint_end.a,   alpha_index, alpha_bitcount);
    
    if (mode.type == 4 OR == 5)
    {
        //Decode the 2 color rotation bits as follows:
        // 00 – Block format is Scalar(A) Vector(RGB) - no swapping
        // 01 – Block format is Scalar(R) Vector(AGB) - swap A and R
        // 10 – Block format is Scalar(G) Vector(RAB) - swap A and G
        // 11 - Block format is Scalar(B) Vector(RGA) - swap A and B
        rotation = extract_rot_bits(mode, block);
        output = swap_channels(output, rotation);
    }
    
}
```

<span data-ttu-id="1f2f4-179">次の擬似コードは、16 バイトの BC7 ブロックを指定して、各サブセットのエンドポイントの色とアルファ成分を完全にデコードする手順の概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-179">The followoing pseudocode outlines the steps to fully decode endpoint color and alpha components for each subset given a 16-byte BC7 block.</span></span>

``` syntax
fully_decode_endpoints(endpoint_array, mode, block)
{
    //first handle modes that have P-bits
    if (mode.type == 0 OR == 1 OR == 3 OR == 6 OR == 7)
    {
        for each endpoint i
        {
            //component-wise left-shift
            endpoint_array[i].rgba = endpoint_array[i].rgba << 1;
        }
        
        //if P-bit is shared
        if (mode.type == 1) 
        {
            pbit_zero = extract_pbit_zero(mode, block);
            pbit_one = extract_pbit_one(mode, block);
            
            //rgb component-wise insert pbits
            endpoint_array[0].rgb |= pbit_zero;
            endpoint_array[1].rgb |= pbit_zero;
            endpoint_array[2].rgb |= pbit_one;
            endpoint_array[3].rgb |= pbit_one;  
        }
        else //unique P-bit per endpoint
        {  
            pbit_array = extract_pbit_array(mode, block);
            for each endpoint i
            {
                endpoint_array[i].rgba |= pbit_array[i];
            }
        }
    }

    for each endpoint i
    {
        // Color_component_precision & alpha_component_precision includes pbit
        // left shift endpoint components so that their MSB lies in bit 7
        endpoint_array[i].rgb = endpoint_array[i].rgb << (8 - color_component_precision(mode));
        endpoint_array[i].a = endpoint_array[i].a << (8 - alpha_component_precision(mode));

        // Replicate each component's MSB into the LSBs revealed by the left-shift operation above
        endpoint_array[i].rgb = endpoint_array[i].rgb | (endpoint_array[i].rgb >> color_component_precision(mode));
        endpoint_array[i].a = endpoint_array[i].a | (endpoint_array[i].a >> alpha_component_precision(mode));
    }
        
    //If this mode does not explicitly define the alpha component
    //set alpha equal to 1.0
    if (mode.type == 0 OR == 1 OR == 2 OR == 3)
    {
        for each endpoint i
        {
            endpoint_array[i].a = 255; //i.e. alpha = 1.0f
        }
    }
}
```

<span data-ttu-id="1f2f4-180">各サブセットの補間された各成分を生成するには、次のアルゴリズムを使用します。生成する成分を "c" とします。 "e0" をサブセットのエンドポイント 0 の成分とします。"e1" をそのサブセットのエンドポイント 1 の成分とします。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-180">To generate each interpolated component for each subset, use the following algorithm: let "c" be the component to generate; let "e0" be that component of endpoint 0 of the subset; and let "e1" be that component of endpoint 1 of the subset.</span></span>

``` syntax
UINT16 aWeight2[] = {0, 21, 43, 64};
UINT16 aWeight3[] = {0, 9, 18, 27, 37, 46, 55, 64};
UINT16 aWeight4[] = {0, 4, 9, 13, 17, 21, 26, 30, 34, 38, 43, 47, 51, 55, 60, 64};

UINT8 interpolate(UINT8 e0, UINT8 e1, UINT8 index, UINT8 indexprecision)
{
    if(indexprecision == 2)
        return (UINT8) (((64 - aWeights2[index])*UINT16(e0) + aWeights2[index]*UINT16(e1) + 32) >> 6);
    else if(indexprecision == 3)
        return (UINT8) (((64 - aWeights3[index])*UINT16(e0) + aWeights3[index]*UINT16(e1) + 32) >> 6);
    else // indexprecision == 4
        return (UINT8) (((64 - aWeights4[index])*UINT16(e0) + aWeights4[index]*UINT16(e1) + 32) >> 6);
}
```

<span data-ttu-id="1f2f4-181">次の擬似コードは、色の成分とアルファ成分のインデックスとビット数を抽出する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-181">The following pseudocode illustrates how to extract indices and bit counts for color and alpha components.</span></span> <span data-ttu-id="1f2f4-182">別の色とアルファを持つブロックには、ベクトル チャネル用とスカラー チャネル用の 2 つのインデックス データ セットもあります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-182">Blocks with separate color and alpha also have two sets of index data: one for the vector channel, and one for the scalar channel.</span></span> <span data-ttu-id="1f2f4-183">モード 4 では、これらのインデックスは異なる幅 (2 または 3 ビット) を持ち、ベクトルまたはスカラー データが 3 ビット インデックスを使用するかどうかを指定する 1 ビット セレクタがあります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-183">For Mode 4, these indices are of differing widths (2 or 3 bits), and there is a one-bit selector which specifies whether the vector or scalar data uses the 3-bit indices.</span></span> <span data-ttu-id="1f2f4-184">(アルファ ビット数の抽出は、カラー ビット数の抽出と似ていますが、**idxMode** ビットに基づく逆の動作です)。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-184">(Extracting the alpha bit count is similar to extracting color bit count but with inverse behavior based on the **idxMode** bit.)</span></span>

``` syntax
bitcount get_color_bitcount(block, mode)
{
    if (mode.type == 0 OR == 1)
        return 3;
    
    if (mode.type == 2 OR == 3 OR == 5 OR == 7)
        return 2;
    
    if (mode.type == 6)
        return 4;
        
    //The only remaining case is Mode 4 with 1-bit index selector
    idxMode = extract_idxMode(block);
    if (idxMode == 0)
        return 2;
    else
        return 3;
}
```

## <a name="span-idbc7-format-mode-referencespanspan-idbc7-format-mode-referencespanspan-idbc7-format-mode-referencespanbc7-format-mode-reference"></a><span data-ttu-id="1f2f4-185"><span id="BC7-format-mode-reference"></span><span id="bc7-format-mode-reference"></span><span id="BC7-FORMAT-MODE-REFERENCE"></span>BC7 形式モードのリファレンス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-185"><span id="BC7-format-mode-reference"></span><span id="bc7-format-mode-reference"></span><span id="BC7-FORMAT-MODE-REFERENCE"></span>BC7 format mode reference</span></span>


<span data-ttu-id="1f2f4-186">このセクションには、BC7 テクスチャ圧縮形式のブロックの 8 つのブロック モードとビット割り当てのリストが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-186">This section contains a list of the 8 block modes and bit allocations for BC7 texture compression format blocks.</span></span>

<span data-ttu-id="1f2f4-187">ブロック内の各サブセットの色は、2 つの明示的なエンドポイントの色とその間の補間された色のセットで表されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-187">The colors for each subset within a block are represented by two explicit endpoint colors and a set of interpolated colors between them.</span></span> <span data-ttu-id="1f2f4-188">ブロックのインデックスの精度に応じて、各サブセットは 4、8 または 16 の色を持つことができます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-188">Depending on the block's index precision, each subset can have 4, 8 or 16 possible colors.</span></span>

### <a name="span-idmode-0spanspan-idmode-0spanspan-idmode-0spanmode-0"></a><span data-ttu-id="1f2f4-189"><span id="Mode-0"></span><span id="mode-0"></span><span id="MODE-0"></span>モード 0</span><span class="sxs-lookup"><span data-stu-id="1f2f4-189"><span id="Mode-0"></span><span id="mode-0"></span><span id="MODE-0"></span>Mode 0</span></span>

<span data-ttu-id="1f2f4-190">BC7 モード 0 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-190">BC7 Mode 0 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-191">カラー成分のみ (アルファなし)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-191">Color components only (no alpha)</span></span>
-   <span data-ttu-id="1f2f4-192">ブロックごとに 3 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-192">3 subsets per block</span></span>
-   <span data-ttu-id="1f2f4-193">エンドポイントごとに固有の P ビットを持つ、RGBP 4.4.4.1 エンドポイント</span><span class="sxs-lookup"><span data-stu-id="1f2f4-193">RGBP 4.4.4.1 endpoints with a unique P-bit per endpoint</span></span>
-   <span data-ttu-id="1f2f4-194">3 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-194">3-bit indices</span></span>
-   <span data-ttu-id="1f2f4-195">16 パーティション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-195">16 partitions</span></span>

![モード 0 のビット レイアウト](images/bc7-mode0.png)

### <a name="span-idmode-1spanspan-idmode-1spanspan-idmode-1spanmode-1"></a><span data-ttu-id="1f2f4-197"><span id="Mode-1"></span><span id="mode-1"></span><span id="MODE-1"></span>モード 1</span><span class="sxs-lookup"><span data-stu-id="1f2f4-197"><span id="Mode-1"></span><span id="mode-1"></span><span id="MODE-1"></span>Mode 1</span></span>

<span data-ttu-id="1f2f4-198">BC7 モード 1 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-198">BC7 Mode 1 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-199">カラー成分のみ (アルファなし)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-199">Color components only (no alpha)</span></span>
-   <span data-ttu-id="1f2f4-200">ブロックごとに 2 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-200">2 subsets per block</span></span>
-   <span data-ttu-id="1f2f4-201">エンドポイントごとに 1 つの共有 P ビットを持つ、RGBP 6.6.6.1 エンドポイント)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-201">RGBP 6.6.6.1 endpoints with a shared P-bit per subset)</span></span>
-   <span data-ttu-id="1f2f4-202">3 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-202">3-bit indices</span></span>
-   <span data-ttu-id="1f2f4-203">64 パーティション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-203">64 partitions</span></span>

![モード 1 のビット レイアウト](images/bc7-mode1.png)

### <a name="span-idmode-2spanspan-idmode-2spanspan-idmode-2spanmode-2"></a><span data-ttu-id="1f2f4-205"><span id="Mode-2"></span><span id="mode-2"></span><span id="MODE-2"></span>モード 2</span><span class="sxs-lookup"><span data-stu-id="1f2f4-205"><span id="Mode-2"></span><span id="mode-2"></span><span id="MODE-2"></span>Mode 2</span></span>

<span data-ttu-id="1f2f4-206">BC7 モード 2 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-206">BC7 Mode 2 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-207">カラー成分のみ (アルファなし)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-207">Color components only (no alpha)</span></span>
-   <span data-ttu-id="1f2f4-208">ブロックごとに 3 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-208">3 subsets per block</span></span>
-   <span data-ttu-id="1f2f4-209">RGB 5.5.5 エンドポイント</span><span class="sxs-lookup"><span data-stu-id="1f2f4-209">RGB 5.5.5 endpoints</span></span>
-   <span data-ttu-id="1f2f4-210">2 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-210">2-bit indices</span></span>
-   <span data-ttu-id="1f2f4-211">64 パーティション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-211">64 partitions</span></span>

![モード 2 のビット レイアウト](images/bc7-mode2.png)

### <a name="span-idmode-3spanspan-idmode-3spanspan-idmode-3spanmode-3"></a><span data-ttu-id="1f2f4-213"><span id="Mode-3"></span><span id="mode-3"></span><span id="MODE-3"></span>モード 3</span><span class="sxs-lookup"><span data-stu-id="1f2f4-213"><span id="Mode-3"></span><span id="mode-3"></span><span id="MODE-3"></span>Mode 3</span></span>

<span data-ttu-id="1f2f4-214">BC7 モード 3 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-214">BC7 Mode 3 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-215">カラー成分のみ (アルファなし)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-215">Color components only (no alpha)</span></span>
-   <span data-ttu-id="1f2f4-216">ブロックごとに 2 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-216">2 subsets per block</span></span>
-   <span data-ttu-id="1f2f4-217">サブセットごとに固有の P ビットを持つ、RGBP 7.7.7.1 エンドポイント)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-217">RGBP 7.7.7.1 endpoints with a unique P-bit per subset)</span></span>
-   <span data-ttu-id="1f2f4-218">2 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-218">2-bit indices</span></span>
-   <span data-ttu-id="1f2f4-219">64 パーティション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-219">64 partitions</span></span>

![モード 3 のビット レイアウト](images/bc7-mode3.png)

### <a name="span-idmode-4spanspan-idmode-4spanspan-idmode-4spanmode-4"></a><span data-ttu-id="1f2f4-221"><span id="Mode-4"></span><span id="mode-4"></span><span id="MODE-4"></span>モード 4</span><span class="sxs-lookup"><span data-stu-id="1f2f4-221"><span id="Mode-4"></span><span id="mode-4"></span><span id="MODE-4"></span>Mode 4</span></span>

<span data-ttu-id="1f2f4-222">BC7 モード 4 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-222">BC7 Mode 4 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-223">別のアルファ成分を持つカラー成分</span><span class="sxs-lookup"><span data-stu-id="1f2f4-223">Color components with separate alpha component</span></span>
-   <span data-ttu-id="1f2f4-224">ブロックごとに 1 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-224">1 subset per block</span></span>
-   <span data-ttu-id="1f2f4-225">RGB 5.5.5 カラー エンドポイント</span><span class="sxs-lookup"><span data-stu-id="1f2f4-225">RGB 5.5.5 color endpoints</span></span>
-   <span data-ttu-id="1f2f4-226">6 ビットのアルファ エンドポイント</span><span class="sxs-lookup"><span data-stu-id="1f2f4-226">6-bit alpha endpoints</span></span>
-   <span data-ttu-id="1f2f4-227">16 個の 2 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-227">16 x 2-bit indices</span></span>
-   <span data-ttu-id="1f2f4-228">16 個の 3 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-228">16 x 3-bit indices</span></span>
-   <span data-ttu-id="1f2f4-229">2 ビット成分回転</span><span class="sxs-lookup"><span data-stu-id="1f2f4-229">2-bit component rotation</span></span>
-   <span data-ttu-id="1f2f4-230">1 ビットのインデックス セレクター (2 ビットまたは 3 ビットのインデックスの使用を指定する)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-230">1-bit index selector (whether the 2- or 3-bit indices are used)</span></span>

![モード 4 のビット レイアウト](images/bc7-mode4.png)

### <a name="span-idmode-5spanspan-idmode-5spanspan-idmode-5spanmode-5"></a><span data-ttu-id="1f2f4-232"><span id="Mode-5"></span><span id="mode-5"></span><span id="MODE-5"></span>モード 5</span><span class="sxs-lookup"><span data-stu-id="1f2f4-232"><span id="Mode-5"></span><span id="mode-5"></span><span id="MODE-5"></span>Mode 5</span></span>

<span data-ttu-id="1f2f4-233">BC7 モード 5 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-233">BC7 Mode 5 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-234">別のアルファ成分を持つカラー成分</span><span class="sxs-lookup"><span data-stu-id="1f2f4-234">Color components with separate alpha component</span></span>
-   <span data-ttu-id="1f2f4-235">ブロックごとに 1 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-235">1 subset per block</span></span>
-   <span data-ttu-id="1f2f4-236">RGB 7.7.7 カラー エンドポイント</span><span class="sxs-lookup"><span data-stu-id="1f2f4-236">RGB 7.7.7 color endpoints</span></span>
-   <span data-ttu-id="1f2f4-237">6 ビットのアルファ エンドポイント</span><span class="sxs-lookup"><span data-stu-id="1f2f4-237">6-bit alpha endpoints</span></span>
-   <span data-ttu-id="1f2f4-238">16 個の 2 ビット カラー インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-238">16 x 2-bit color indices</span></span>
-   <span data-ttu-id="1f2f4-239">16 個の 2 ビット アルファ インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-239">16 x 2-bit alpha indices</span></span>
-   <span data-ttu-id="1f2f4-240">2 ビット成分回転</span><span class="sxs-lookup"><span data-stu-id="1f2f4-240">2-bit component rotation</span></span>

![モード 5 のビット レイアウト](images/bc7-mode5.png)

### <a name="span-idmode-6spanspan-idmode-6spanspan-idmode-6spanmode-6"></a><span data-ttu-id="1f2f4-242"><span id="Mode-6"></span><span id="mode-6"></span><span id="MODE-6"></span>モード 6</span><span class="sxs-lookup"><span data-stu-id="1f2f4-242"><span id="Mode-6"></span><span id="mode-6"></span><span id="MODE-6"></span>Mode 6</span></span>

<span data-ttu-id="1f2f4-243">BC7 モード 6 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-243">BC7 Mode 6 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-244">色成分とアルファ成分の結合</span><span class="sxs-lookup"><span data-stu-id="1f2f4-244">Combined color and alpha components</span></span>
-   <span data-ttu-id="1f2f4-245">ブロックごとに 1 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-245">One subset per block</span></span>
-   <span data-ttu-id="1f2f4-246">RGBAP 7.7.7.7.1 カラー (およびアルファ) エンドポイント (エンドポイントごとに固有の P ビット)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-246">RGBAP 7.7.7.7.1 color (and alpha) endpoints (unique P-bit per endpoint)</span></span>
-   <span data-ttu-id="1f2f4-247">16 個の 4 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-247">16 x 4-bit indices</span></span>

![モード 6 のビット レイアウト](images/bc7-mode6.png)

### <a name="span-idmode-7spanspan-idmode-7spanspan-idmode-7spanmode-7"></a><span data-ttu-id="1f2f4-249"><span id="Mode-7"></span><span id="mode-7"></span><span id="MODE-7"></span>モード 7</span><span class="sxs-lookup"><span data-stu-id="1f2f4-249"><span id="Mode-7"></span><span id="mode-7"></span><span id="MODE-7"></span>Mode 7</span></span>

<span data-ttu-id="1f2f4-250">BC7 モード 7 には以下の特徴があります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-250">BC7 Mode 7 has the following characteristics:</span></span>

-   <span data-ttu-id="1f2f4-251">色成分とアルファ成分の結合</span><span class="sxs-lookup"><span data-stu-id="1f2f4-251">Combined color and alpha components</span></span>
-   <span data-ttu-id="1f2f4-252">ブロックごとに 2 つのサブセット</span><span class="sxs-lookup"><span data-stu-id="1f2f4-252">2 subsets per block</span></span>
-   <span data-ttu-id="1f2f4-253">RGBAP 5.5.5.5.1 カラー (およびアルファ) エンドポイント (エンドポイントごとに固有の P ビット)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-253">RGBAP 5.5.5.5.1 color (and alpha) endpoints (unique P-bit per endpoint)</span></span>
-   <span data-ttu-id="1f2f4-254">2 ビット インデックス</span><span class="sxs-lookup"><span data-stu-id="1f2f4-254">2-bit indices</span></span>
-   <span data-ttu-id="1f2f4-255">64 パーティション</span><span class="sxs-lookup"><span data-stu-id="1f2f4-255">64 partitions</span></span>

![モード 7 のビット レイアウト](images/bc7-mode7.png)

### <a name="span-idremarksspanspan-idremarksspanspan-idremarksspanremarks"></a><span data-ttu-id="1f2f4-257"><span id="Remarks"></span><span id="remarks"></span><span id="REMARKS"></span>注釈</span><span class="sxs-lookup"><span data-stu-id="1f2f4-257"><span id="Remarks"></span><span id="remarks"></span><span id="REMARKS"></span>Remarks</span></span>

<span data-ttu-id="1f2f4-258">モード 8 (最下位バイトは 0x00 に設定されます) は予約されています。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-258">Mode 8 (the least significant byte is set to 0x00) is reserved.</span></span> <span data-ttu-id="1f2f4-259">エンコーダーで使用しないでください。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-259">Don't use it in your encoder.</span></span> <span data-ttu-id="1f2f4-260">このモードをハードウェアに渡すと、すべてゼロに初期化されたブロックが返されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-260">If you pass this mode to the hardware, a block initialized to all zeroes is returned.</span></span>

<span data-ttu-id="1f2f4-261">BC7 では、次のいずれかの方法でアルファ成分をエンコードできます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-261">In BC7, you can encode the alpha component in one of the following ways:</span></span>

-   <span data-ttu-id="1f2f4-262">明示的なアルファ成分エンコーディングのないブロック タイプ。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-262">Block types without explicit alpha component encoding.</span></span> <span data-ttu-id="1f2f4-263">これらのブロックでは、カラー エンドポイントには RGB のみのエンコードがあり、アルファ成分はすべてのテクセルに対して 1.0 にデコードされます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-263">In these blocks, the color endpoints have an RGB-only encoding, with the alpha component decoded to 1.0 for all texels.</span></span>
-   <span data-ttu-id="1f2f4-264">色成分とアルファ成分を組み合わせたブロック タイプ。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-264">Block types with combined color and alpha components.</span></span> <span data-ttu-id="1f2f4-265">これらのブロックでは、エンドポイントのカラー値は RGBA 形式で指定され、アルファ成分の値は、カラー値と共に補間されます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-265">In these blocks, the endpoint color values are specified in the RGBA format, and the alpha component values are interpolated along with the color values.</span></span>
-   <span data-ttu-id="1f2f4-266">色成分とアルファ成分が分離されたブロック タイプ。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-266">Block types with separated color and alpha components.</span></span> <span data-ttu-id="1f2f4-267">これらのブロックでは、色とアルファの値が別々に指定され、それぞれ独自のインデックス セットを持ちます。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-267">In these blocks the color and alpha values are specified separately, each with their own set of indices.</span></span> <span data-ttu-id="1f2f4-268">その結果、有効なベクトルとスカラー チャネルが別々にエンコードされます。一般にベクトルはカラー チャネル \[R, G, B\] を指定し、スカラーはアルファ チャネル \[A\] を指定します。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-268">As a result, they have an effective vector and a scalar channel separately encoded, where the vector commonly specifies the color channels \[R, G, B\] and the scalar specifies the alpha channel \[A\].</span></span> <span data-ttu-id="1f2f4-269">この方法をサポートするために、別の 2 ビット フィールドがエンコードに提供されます。これにより、スカラー値として別のチャネル エンコードの指定が可能になります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-269">To support this approach, a separate 2-bit field is provided in the encoding, which permits the specification of the separate channel encoding as a scalar value.</span></span> <span data-ttu-id="1f2f4-270">その結果、ブロックは、このアルファ エンコードの次の 4 つの異なる表現のうちの 1 つを持つことができます (2 ビット フィールドによって示されます)。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-270">As a result, the block can have one of the following four different representations of this alpha encoding (as indicated by the 2-bit field):</span></span>
    -   <span data-ttu-id="1f2f4-271">RGB|A: アルファ チャネル分離</span><span class="sxs-lookup"><span data-stu-id="1f2f4-271">RGB|A: alpha channel separate</span></span>
    -   <span data-ttu-id="1f2f4-272">AGB|R: "赤" 色チャネル分離</span><span class="sxs-lookup"><span data-stu-id="1f2f4-272">AGB|R: "red" color channel separate</span></span>
    -   <span data-ttu-id="1f2f4-273">RAB|G: "緑" 色チャネル分離</span><span class="sxs-lookup"><span data-stu-id="1f2f4-273">RAB|G: "green" color channel separate</span></span>
    -   <span data-ttu-id="1f2f4-274">RGA|B: "青" 色チャネル分離</span><span class="sxs-lookup"><span data-stu-id="1f2f4-274">RGA|B: "blue" color channel separate</span></span>

    <span data-ttu-id="1f2f4-275">デコーダーは、デコード後にチャネルの順序を RGBA に戻すため、内部ブロックの形式は開発者には見えません。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-275">The decoder reorders the channel order back to RGBA after decoding, so the internal block format is invisible to the developer.</span></span> <span data-ttu-id="1f2f4-276">別の色成分とアルファ成分を持つ黒は、2 つのセットのインデックス データも持っています。1 つはベクター化されたチャネル セット用で、もう 1 つはスカラー チャネル用です。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-276">Blacks with separate color and alpha components also have two sets of index data: one for the vectored set of channels, and one for the scalar channel.</span></span> <span data-ttu-id="1f2f4-277">(モード 4 の場合、これらのインデックスの幅はそれぞれ \[2 ビットまたは 3 ビット\] と異なります。</span><span class="sxs-lookup"><span data-stu-id="1f2f4-277">(In the case of Mode 4, these indices are of differing widths \[2 or 3 bits\].</span></span> <span data-ttu-id="1f2f4-278">モード 4 には、ベクトルまたはスカラー チャネルが 3 ビット インデックスを使用するかどうかを指定する、1 ビットのセレクターも含まれています。)</span><span class="sxs-lookup"><span data-stu-id="1f2f4-278">Mode 4 also contains a 1-bit selector that specifies whether the vector or the scalar channel uses the 3-bit indices.)</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1f2f4-279"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1f2f4-279"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1f2f4-280">テクスチャのブロック圧縮</span><span class="sxs-lookup"><span data-stu-id="1f2f4-280">Texture block compression</span></span>](texture-block-compression.md)

 

 




