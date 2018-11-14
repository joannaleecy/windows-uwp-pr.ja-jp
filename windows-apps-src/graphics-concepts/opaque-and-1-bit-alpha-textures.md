---
title: 不透明なテクスチャと 1 ビットのアルファ テクスチャ
description: テクスチャ形式 BC1 は、不透明なテクスチャや単一の透明色を持つテクスチャに使います。
ms.assetid: 8C53ACDD-72ED-4307-B4F3-2FCF9A9F53EC
keywords:
- 不透明なテクスチャと 1 ビットのアルファ テクスチャ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 672d7b2ddc913ea3a966fbd0a095367521a27d7c
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6189675"
---
# <a name="span-iddirect3dconceptsopaqueand1-bitalphatexturesspanopaque-and-1-bit-alpha-textures"></a><span data-ttu-id="9522f-104"><span id="direct3dconcepts.opaque_and_1-bit_alpha_textures"></span>不透明なテクスチャと 1 ビットのアルファ テクスチャ</span><span class="sxs-lookup"><span data-stu-id="9522f-104"><span id="direct3dconcepts.opaque_and_1-bit_alpha_textures"></span>Opaque and 1-bit alpha textures</span></span>


<span data-ttu-id="9522f-105">テクスチャ形式 BC1 は、不透明なテクスチャや単一の透明色を持つテクスチャに使います。</span><span class="sxs-lookup"><span data-stu-id="9522f-105">Texture format BC1 is for textures that are opaque or have a single transparent color.</span></span>

<span data-ttu-id="9522f-106">不透明ブロックまたは 1 ビットのアルファ ブロックごとに、16 ビット値 (RGB 5:6:5 形式) が 2 つと 2 ビット/ピクセルの 4x4 ビットマップが 1 つ格納されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-106">For each opaque or 1-bit alpha block, two 16-bit values (RGB 5:6:5 format) and a 4x4 bitmap with 2 bits per pixel are stored.</span></span> <span data-ttu-id="9522f-107">これは、16 テクセルで合計 64 ビット、つまりテクセルあたり 4 ビットとなります。</span><span class="sxs-lookup"><span data-stu-id="9522f-107">This totals 64 bits for 16 texels, or four bits per texel.</span></span> <span data-ttu-id="9522f-108">ブロック ビットマップには 2 ビット/ピクセルがあり、4 つの色から選択できます。4 つの色のうち 2 つは、エンコードされたデータに格納されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-108">In the block bitmap, there are 2 bits per texel to select between the four colors, two of which are stored in the encoded data.</span></span> <span data-ttu-id="9522f-109">他の 2 つの色は、線形補間によって、格納されたこれらの色から派生します。</span><span class="sxs-lookup"><span data-stu-id="9522f-109">The other two colors are derived from these stored colors by linear interpolation.</span></span> <span data-ttu-id="9522f-110">レイアウトは次の図をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9522f-110">This layout is shown in the following diagram.</span></span>

![ビットマップ レイアウトの図](images/colors1.png)

<span data-ttu-id="9522f-112">1 ビットのアルファ形式は、ブロックに格納された 2 つの 16 ビット色値を比較することにより、不透明な形式から区別されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-112">The 1-bit alpha format is distinguished from the opaque format by comparing the two 16-bit color values stored in the block.</span></span> <span data-ttu-id="9522f-113">これらは、符号なし整数として扱われます。</span><span class="sxs-lookup"><span data-stu-id="9522f-113">They are treated as unsigned integers.</span></span> <span data-ttu-id="9522f-114">最初の色が 2 番目の色より大きい場合、不透明な色だけが定義されていることを示しています。</span><span class="sxs-lookup"><span data-stu-id="9522f-114">If the first color is greater than the second, it implies that only opaque texels are defined.</span></span> <span data-ttu-id="9522f-115">これは、テクセルを表すために 4 つの色が使われることを意味します。</span><span class="sxs-lookup"><span data-stu-id="9522f-115">This means four colors are used to represent the texels.</span></span> <span data-ttu-id="9522f-116">4 色のエンコードでは、派生した色が 2 つあり、RGB 色空間で 4 つの色すべてが均等に分散されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-116">In four-color encoding, there are two derived colors and all four colors are equally distributed in RGB color space.</span></span> <span data-ttu-id="9522f-117">この形式は、RGB 5:6:5 形式に似ています。</span><span class="sxs-lookup"><span data-stu-id="9522f-117">This format is analogous to RGB 5:6:5 format.</span></span> <span data-ttu-id="9522f-118">それ以外の場合、1 ビットのアルファ透明度では、3 つの色が使われ、4 つ目の色は透明なテクセルを表現するために予約されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-118">Otherwise, for 1-bit alpha transparency, three colors are used and the fourth is reserved to represent transparent texels.</span></span>

<span data-ttu-id="9522f-119">3 色のエンコードでは、派生した色が 1 つあり、4 つ目の 2 ビット コードは透明なテクセルを示すために予約されます (アルファ情報)。</span><span class="sxs-lookup"><span data-stu-id="9522f-119">In three-color encoding, there is one derived color and the fourth 2-bit code is reserved to indicate a transparent texel (alpha information).</span></span> <span data-ttu-id="9522f-120">この形式は、最終ビットがアルファ マスクのエンコードに使われる RGBA 5:5:5:1 に似ています。</span><span class="sxs-lookup"><span data-stu-id="9522f-120">This format is analogous to RGBA 5:5:5:1, where the final bit is used for encoding the alpha mask.</span></span>

<span data-ttu-id="9522f-121">次のコード例は、3 色のエンコードと 4 色のエンコードのどちらが選択されているかを判断するためのアルゴリズムを示しています。</span><span class="sxs-lookup"><span data-stu-id="9522f-121">The following code example illustrates the algorithm for deciding whether three- or four-color encoding is selected:</span></span>

```
if (color_0 > color_1) 
{
    // Four-color block: derive the other two colors. 
    
    // 00 = color_0, 01 = color_1, 10 = color_2, 11 = color_3
    // These 2-bit codes correspond to the 2-bit fields 
    // stored in the 64-bit block.
    color_2 = (2 * color_0 + color_1 + 1) / 3;
    color_3 = (color_0 + 2 * color_1 + 1) / 3;
}    
else
{ 
    // Three-color block: derive the other color.
    // 00 = color_0,  01 = color_1,  10 = color_2,  
    // 11 = transparent.
    // These 2-bit codes correspond to the 2-bit fields 
    // stored in the 64-bit block. 
    color_2 = (color_0 + color_1) / 2;    
    color_3 = transparent;    

}
```

<span data-ttu-id="9522f-122">ブレンド前に、透明度ピクセルの RGBA コンポーネントを 0 に設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9522f-122">It is recommended that you set the RGBA components of the transparency pixel to zero before blending.</span></span>

<span data-ttu-id="9522f-123">次の表は、8 バイト ブロックのメモリ レイアウトを示しています。</span><span class="sxs-lookup"><span data-stu-id="9522f-123">The following tables show the memory layout for the 8-byte block.</span></span> <span data-ttu-id="9522f-124">最初のインデックスが y 座標に対応しており、2 つ目が x 座標に対応していることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="9522f-124">It is assumed that the first index corresponds to the y-coordinate and the second corresponds to the x-coordinate.</span></span> <span data-ttu-id="9522f-125">たとえば、Texel\[1\]\[2\] は (x,y) = (2,1) にあるテクスチャ マップ ピクセルを示しています。</span><span class="sxs-lookup"><span data-stu-id="9522f-125">For example, Texel\[1\]\[2\] refers to the texture map pixel at (x,y) = (2,1).</span></span>

<span data-ttu-id="9522f-126">8 バイト (64 ビット) ブロックのメモリ レイアウトを次に示します。</span><span class="sxs-lookup"><span data-stu-id="9522f-126">The following is the memory layout for the 8-byte (64-bit) block:</span></span>

| <span data-ttu-id="9522f-127">ワード アドレス</span><span class="sxs-lookup"><span data-stu-id="9522f-127">Word address</span></span> | <span data-ttu-id="9522f-128">16 ビットのワード</span><span class="sxs-lookup"><span data-stu-id="9522f-128">16-bit word</span></span>    |
|--------------|----------------|
| <span data-ttu-id="9522f-129">0</span><span class="sxs-lookup"><span data-stu-id="9522f-129">0</span></span>            | <span data-ttu-id="9522f-130">Color\_0</span><span class="sxs-lookup"><span data-stu-id="9522f-130">Color\_0</span></span>       |
| <span data-ttu-id="9522f-131">1</span><span class="sxs-lookup"><span data-stu-id="9522f-131">1</span></span>            | <span data-ttu-id="9522f-132">Color\_1</span><span class="sxs-lookup"><span data-stu-id="9522f-132">Color\_1</span></span>       |
| <span data-ttu-id="9522f-133">2</span><span class="sxs-lookup"><span data-stu-id="9522f-133">2</span></span>            | <span data-ttu-id="9522f-134">Bitmap Word\_0</span><span class="sxs-lookup"><span data-stu-id="9522f-134">Bitmap Word\_0</span></span> |
| <span data-ttu-id="9522f-135">3</span><span class="sxs-lookup"><span data-stu-id="9522f-135">3</span></span>            | <span data-ttu-id="9522f-136">Bitmap Word\_1</span><span class="sxs-lookup"><span data-stu-id="9522f-136">Bitmap Word\_1</span></span> |

 

<span data-ttu-id="9522f-137">Color\_0 および Color\_1 (2 つの極端な色) は、次のようなレイアウトになります。</span><span class="sxs-lookup"><span data-stu-id="9522f-137">Color\_0 and Color\_1, the colors at the two extremes, are laid out as follows:</span></span>

| <span data-ttu-id="9522f-138">ビット</span><span class="sxs-lookup"><span data-stu-id="9522f-138">Bits</span></span>        | <span data-ttu-id="9522f-139">色</span><span class="sxs-lookup"><span data-stu-id="9522f-139">Color</span></span>                 |
|-------------|-----------------------|
| <span data-ttu-id="9522f-140">4:0 (LSB\*)</span><span class="sxs-lookup"><span data-stu-id="9522f-140">4:0 (LSB\*)</span></span> | <span data-ttu-id="9522f-141">青のカラー コンポーネント</span><span class="sxs-lookup"><span data-stu-id="9522f-141">Blue color component</span></span>  |
| <span data-ttu-id="9522f-142">10:5</span><span class="sxs-lookup"><span data-stu-id="9522f-142">10:5</span></span>        | <span data-ttu-id="9522f-143">緑のカラー コンポーネント</span><span class="sxs-lookup"><span data-stu-id="9522f-143">Green color component</span></span> |
| <span data-ttu-id="9522f-144">15:11</span><span class="sxs-lookup"><span data-stu-id="9522f-144">15:11</span></span>       | <span data-ttu-id="9522f-145">赤のカラー コンポーネント</span><span class="sxs-lookup"><span data-stu-id="9522f-145">Red color component</span></span>   |

 

<span data-ttu-id="9522f-146">\*最下位ビット</span><span class="sxs-lookup"><span data-stu-id="9522f-146">\*least-significant bit</span></span>

<span data-ttu-id="9522f-147">Bitmap Word\_0 のレイアウトは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="9522f-147">Bitmap Word\_0 is laid out as follows:</span></span>

| <span data-ttu-id="9522f-148">ビット</span><span class="sxs-lookup"><span data-stu-id="9522f-148">Bits</span></span>          | <span data-ttu-id="9522f-149">テクセル</span><span class="sxs-lookup"><span data-stu-id="9522f-149">Texel</span></span>           |
|---------------|-----------------|
| <span data-ttu-id="9522f-150">1:0 (LSB)</span><span class="sxs-lookup"><span data-stu-id="9522f-150">1:0 (LSB)</span></span>     | <span data-ttu-id="9522f-151">Texel\[0\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="9522f-151">Texel\[0\]\[0\]</span></span> |
| <span data-ttu-id="9522f-152">3:2</span><span class="sxs-lookup"><span data-stu-id="9522f-152">3:2</span></span>           | <span data-ttu-id="9522f-153">Texel\[0\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="9522f-153">Texel\[0\]\[1\]</span></span> |
| <span data-ttu-id="9522f-154">5:4</span><span class="sxs-lookup"><span data-stu-id="9522f-154">5:4</span></span>           | <span data-ttu-id="9522f-155">Texel\[0\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="9522f-155">Texel\[0\]\[2\]</span></span> |
| <span data-ttu-id="9522f-156">7:6</span><span class="sxs-lookup"><span data-stu-id="9522f-156">7:6</span></span>           | <span data-ttu-id="9522f-157">Texel\[0\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="9522f-157">Texel\[0\]\[3\]</span></span> |
| <span data-ttu-id="9522f-158">9:8</span><span class="sxs-lookup"><span data-stu-id="9522f-158">9:8</span></span>           | <span data-ttu-id="9522f-159">Texel\[1\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="9522f-159">Texel\[1\]\[0\]</span></span> |
| <span data-ttu-id="9522f-160">11:10</span><span class="sxs-lookup"><span data-stu-id="9522f-160">11:10</span></span>         | <span data-ttu-id="9522f-161">Texel\[1\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="9522f-161">Texel\[1\]\[1\]</span></span> |
| <span data-ttu-id="9522f-162">13:12</span><span class="sxs-lookup"><span data-stu-id="9522f-162">13:12</span></span>         | <span data-ttu-id="9522f-163">Texel\[1\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="9522f-163">Texel\[1\]\[2\]</span></span> |
| <span data-ttu-id="9522f-164">15:14 (MSB\*)</span><span class="sxs-lookup"><span data-stu-id="9522f-164">15:14 (MSB\*)</span></span> | <span data-ttu-id="9522f-165">Texel\[1\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="9522f-165">Texel\[1\]\[3\]</span></span> |

 

<span data-ttu-id="9522f-166">\*最上位ビット (MSB)</span><span class="sxs-lookup"><span data-stu-id="9522f-166">\*most significant bit (MSB)</span></span>

<span data-ttu-id="9522f-167">Bitmap Word\_1 のレイアウトは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="9522f-167">Bitmap Word\_1 is laid out as follows:</span></span>

| <span data-ttu-id="9522f-168">ビット</span><span class="sxs-lookup"><span data-stu-id="9522f-168">Bits</span></span>        | <span data-ttu-id="9522f-169">テクセル</span><span class="sxs-lookup"><span data-stu-id="9522f-169">Texel</span></span>           |
|-------------|-----------------|
| <span data-ttu-id="9522f-170">1:0 (LSB)</span><span class="sxs-lookup"><span data-stu-id="9522f-170">1:0 (LSB)</span></span>   | <span data-ttu-id="9522f-171">Texel\[2\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="9522f-171">Texel\[2\]\[0\]</span></span> |
| <span data-ttu-id="9522f-172">3:2</span><span class="sxs-lookup"><span data-stu-id="9522f-172">3:2</span></span>         | <span data-ttu-id="9522f-173">Texel\[2\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="9522f-173">Texel\[2\]\[1\]</span></span> |
| <span data-ttu-id="9522f-174">5:4</span><span class="sxs-lookup"><span data-stu-id="9522f-174">5:4</span></span>         | <span data-ttu-id="9522f-175">Texel\[2\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="9522f-175">Texel\[2\]\[2\]</span></span> |
| <span data-ttu-id="9522f-176">7:6</span><span class="sxs-lookup"><span data-stu-id="9522f-176">7:6</span></span>         | <span data-ttu-id="9522f-177">Texel\[2\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="9522f-177">Texel\[2\]\[3\]</span></span> |
| <span data-ttu-id="9522f-178">9:8</span><span class="sxs-lookup"><span data-stu-id="9522f-178">9:8</span></span>         | <span data-ttu-id="9522f-179">Texel\[3\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="9522f-179">Texel\[3\]\[0\]</span></span> |
| <span data-ttu-id="9522f-180">11:10</span><span class="sxs-lookup"><span data-stu-id="9522f-180">11:10</span></span>       | <span data-ttu-id="9522f-181">Texel\[3\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="9522f-181">Texel\[3\]\[1\]</span></span> |
| <span data-ttu-id="9522f-182">13:12</span><span class="sxs-lookup"><span data-stu-id="9522f-182">13:12</span></span>       | <span data-ttu-id="9522f-183">Texel\[3\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="9522f-183">Texel\[3\]\[2\]</span></span> |
| <span data-ttu-id="9522f-184">15:14 (MSB)</span><span class="sxs-lookup"><span data-stu-id="9522f-184">15:14 (MSB)</span></span> | <span data-ttu-id="9522f-185">Texel\[3\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="9522f-185">Texel\[3\]\[3\]</span></span> |

 

## <a name="span-idexampleofopaquecolorencodingspanspan-idexampleofopaquecolorencodingspanspan-idexampleofopaquecolorencodingspanexample-of-opaque-color-encoding"></a><span data-ttu-id="9522f-186"><span id="Example_of_Opaque_Color_Encoding"></span><span id="example_of_opaque_color_encoding"></span><span id="EXAMPLE_OF_OPAQUE_COLOR_ENCODING"></span>不透明な色のエンコードの例</span><span class="sxs-lookup"><span data-stu-id="9522f-186"><span id="Example_of_Opaque_Color_Encoding"></span><span id="example_of_opaque_color_encoding"></span><span id="EXAMPLE_OF_OPAQUE_COLOR_ENCODING"></span>Example of opaque color encoding</span></span>


<span data-ttu-id="9522f-187">不透明なエンコードの例として、赤と黒の色が極端であるとします。</span><span class="sxs-lookup"><span data-stu-id="9522f-187">As an example of opaque encoding, assume that the colors red and black are at the extremes.</span></span> <span data-ttu-id="9522f-188">赤は color\_0 であり、黒は color\_1 です。</span><span class="sxs-lookup"><span data-stu-id="9522f-188">Red is color\_0, and black is color\_1.</span></span> <span data-ttu-id="9522f-189">それらの色の間で均一に分散したグラデーションを形成する 4 つの補間色があります。</span><span class="sxs-lookup"><span data-stu-id="9522f-189">There are four interpolated colors that form the uniformly distributed gradient between them.</span></span> <span data-ttu-id="9522f-190">4x4 ビットマップの値を調べるには、次の計算を使います。</span><span class="sxs-lookup"><span data-stu-id="9522f-190">To determine the values for the 4x4 bitmap, the following calculations are used:</span></span>

```
00 ? color_0
01 ? color_1
10 ? 2/3 color_0 + 1/3 color_1
11 ? 1/3 color_0 + 2/3 color_1
```

<span data-ttu-id="9522f-191">この場合、ビットマップは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="9522f-191">The bitmap then looks like the following diagram.</span></span>

![拡大したビットマップ レイアウトの図](images/colors2.png)

<span data-ttu-id="9522f-193">これは、図に示された次の一連の色のようになります。</span><span class="sxs-lookup"><span data-stu-id="9522f-193">This looks like the following illustrated series of colors.</span></span>

<span data-ttu-id="9522f-194">**注:** 左上に、イメージのピクセル (0, 0) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-194">**Note** In an image, pixel (0,0) appears on the top left.</span></span>

 

![エンコードされた不透明なグラデーションの図](images/redsquares.png)

## <a name="span-idexampleof1bitalphaencodingspanspan-idexampleof1bitalphaencodingspanspan-idexampleof1bitalphaencodingspanexample-of-1-bit-alpha-encoding"></a><span data-ttu-id="9522f-196"><span id="Example_of_1_Bit_Alpha_Encoding"></span><span id="example_of_1_bit_alpha_encoding"></span><span id="EXAMPLE_OF_1_BIT_ALPHA_ENCODING"></span>1 ビットのアルファ エンコードの例</span><span class="sxs-lookup"><span data-stu-id="9522f-196"><span id="Example_of_1_Bit_Alpha_Encoding"></span><span id="example_of_1_bit_alpha_encoding"></span><span id="EXAMPLE_OF_1_BIT_ALPHA_ENCODING"></span>Example of 1-bit alpha encoding</span></span>


<span data-ttu-id="9522f-197">この形式は、符号なし 16 ビット整数 color\_0 が符号なし 16 ビット整数 color\_1 より小さい場合に選択されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-197">This format is selected when the unsigned 16-bit integer, color\_0, is less than the unsigned 16-bit integer, color\_1.</span></span> <span data-ttu-id="9522f-198">この形式を使うことができる例は、青い空に映る木の葉などです。</span><span class="sxs-lookup"><span data-stu-id="9522f-198">An example of where this format can be used is leaves on a tree, shown against a blue sky.</span></span> <span data-ttu-id="9522f-199">一部のテクセルは透明とマークできますが、その場合も葉には緑の 3 つの色調を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="9522f-199">Some texels can be marked as transparent while three shades of green are still available for the leaves.</span></span> <span data-ttu-id="9522f-200">2 つの色により極端な色が修正され、3 つ目は補間色になります。</span><span class="sxs-lookup"><span data-stu-id="9522f-200">Two colors fix the extremes, and the third is an interpolated color.</span></span>

<span data-ttu-id="9522f-201">そのような絵の例を、次の図に示します。</span><span class="sxs-lookup"><span data-stu-id="9522f-201">The following illustration is an example of such a picture.</span></span>

![1 ビットのアルファ エンコードの図](images/greenthing.png)

<span data-ttu-id="9522f-203">イメージが白で表示される場合、テクセルは透明でエンコードされます。</span><span class="sxs-lookup"><span data-stu-id="9522f-203">Where the image is shown as white, the texel would be encoded as transparent.</span></span> <span data-ttu-id="9522f-204">透明テクセルの RGBA コンポーネントは、ブレンド前に 0 に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9522f-204">The RGBA components of the transparent texels should be set to zero before blending.</span></span>

<span data-ttu-id="9522f-205">色と透明度のビットマップ エンコードは、次の計算を使って決定されます。</span><span class="sxs-lookup"><span data-stu-id="9522f-205">The bitmap encoding for the colors and the transparency is determined using the following calculations.</span></span>

```
00 ? color_0
01 ? color_1
10 ? 1/2 color_0 + 1/2 color_1
11   ?   Transparent
```

<span data-ttu-id="9522f-206">この場合、ビットマップは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="9522f-206">The bitmap then looks like the following diagram.</span></span>

![拡大したビットマップ レイアウトの図](images/colors3.png)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="9522f-208"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="9522f-208"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="9522f-209">圧縮テクスチャ リソース</span><span class="sxs-lookup"><span data-stu-id="9522f-209">Compressed texture resources</span></span>](compressed-texture-resources.md)

 

 




