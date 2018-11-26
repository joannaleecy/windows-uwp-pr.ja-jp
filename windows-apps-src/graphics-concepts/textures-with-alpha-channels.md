---
title: アルファ チャネルを含むテクスチャ
description: 複雑な透明度を表現するテクスチャ マップには 2 つのエンコード方法があります。
ms.assetid: 768A774A-4F21-4DDE-B863-14211DA92926
keywords:
- アルファ チャネルを含むテクスチャ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 88d150383d2be219e7f382e0e690771acbc9d2ee
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7719521"
---
# <a name="textures-with-alpha-channels"></a><span data-ttu-id="e606d-104">アルファ チャネルを含むテクスチャ</span><span class="sxs-lookup"><span data-stu-id="e606d-104">Textures with alpha channels</span></span>


<span data-ttu-id="e606d-105">複雑な透明度を表現するテクスチャ マップには 2 つのエンコード方法があります。</span><span class="sxs-lookup"><span data-stu-id="e606d-105">There are two ways to encode texture maps that exhibit more complex transparency.</span></span> <span data-ttu-id="e606d-106">いずれの場合も、既に説明した 64 ビットのブロックの前に、透明度を記述したブロックを配置します。</span><span class="sxs-lookup"><span data-stu-id="e606d-106">In each case, a block that describes the transparency precedes the 64-bit block already described.</span></span> <span data-ttu-id="e606d-107">透明度は、1 ピクセルあたり 4 ビットの 4 x 4 ビットマップ (明示的エンコード)、またはこれよりも少ないビット数およびカラー エンコードで使用されるものに類似した線形補間で表現されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-107">The transparency is either represented as a 4x4 bitmap with 4 bits per pixel (explicit encoding), or with fewer bits and linear interpolation that is analogous to what is used for color encoding.</span></span>

<span data-ttu-id="e606d-108">透明度ブロックと色ブロックは、次の表に示すように配置されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-108">The transparency block and the color block are arranged as shown in the following table.</span></span>

| <span data-ttu-id="e606d-109">ワード アドレス</span><span class="sxs-lookup"><span data-stu-id="e606d-109">Word address</span></span> | <span data-ttu-id="e606d-110">64 ビットのブロック</span><span class="sxs-lookup"><span data-stu-id="e606d-110">64-bit block</span></span>                      |
|--------------|-----------------------------------|
| <span data-ttu-id="e606d-111">3:0</span><span class="sxs-lookup"><span data-stu-id="e606d-111">3:0</span></span>          | <span data-ttu-id="e606d-112">透明度ブロック</span><span class="sxs-lookup"><span data-stu-id="e606d-112">Transparency block</span></span>                |
| <span data-ttu-id="e606d-113">7:4</span><span class="sxs-lookup"><span data-stu-id="e606d-113">7:4</span></span>          | <span data-ttu-id="e606d-114">既に説明した 64 ビットのブロック</span><span class="sxs-lookup"><span data-stu-id="e606d-114">Previously described 64-bit block</span></span> |

 

## <a name="span-idexplicit-texture-encodingspanspan-idexplicit-texture-encodingspanspan-idexplicit-texture-encodingspanexplicit-texture-encoding"></a><span data-ttu-id="e606d-115"><span id="Explicit-Texture-Encoding"></span><span id="explicit-texture-encoding"></span><span id="EXPLICIT-TEXTURE-ENCODING"></span>明示的なテクスチャ エンコード</span><span class="sxs-lookup"><span data-stu-id="e606d-115"><span id="Explicit-Texture-Encoding"></span><span id="explicit-texture-encoding"></span><span id="EXPLICIT-TEXTURE-ENCODING"></span>Explicit texture encoding</span></span>


<span data-ttu-id="e606d-116">明示的なテクスチャ エンコード (BC2 形式) の場合、透明度を記述するテクセルのアルファ成分は、テクセルあたり 4 ビットの 4 x 4 のビットマップでエンコードされます。</span><span class="sxs-lookup"><span data-stu-id="e606d-116">For explicit texture encoding (BC2 format), the alpha components of the texels that describe transparency are encoded in a 4x4 bitmap with 4 bits per texel.</span></span> <span data-ttu-id="e606d-117">これらの 4 ビットは、ディザリングなどのさまざまな手法によるか、アルファ データの 4 つの最上位ビットを使用して取得できます。</span><span class="sxs-lookup"><span data-stu-id="e606d-117">These four bits can be achieved through a variety of means such as dithering or by using the four most significant bits of the alpha data.</span></span> <span data-ttu-id="e606d-118">ただし、これらは生成されると、どのような補間もされずに、そのままの状態で使用されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-118">However they are produced, they are used just as they are, without any form of interpolation.</span></span>

<span data-ttu-id="e606d-119">次の図に、64 ビットの透明度ブロックを示します。</span><span class="sxs-lookup"><span data-stu-id="e606d-119">The following diagram shows a 64-bit transparency block.</span></span>

![64 ビットの透明度ブロックの図](images/colors4.png)

<span data-ttu-id="e606d-121">**注:**  Direct3D の圧縮方法で、4 つの最上位ビットを使用します。</span><span class="sxs-lookup"><span data-stu-id="e606d-121">**Note** The compression method of Direct3D uses the four most significant bits.</span></span>

 

<span data-ttu-id="e606d-122">次の表に、16 ビット ワードごとにメモリ内のアルファ情報のレイアウト方法を示します。</span><span class="sxs-lookup"><span data-stu-id="e606d-122">The following tables illustrate how the alpha information is laid out in memory, for each 16-bit word.</span></span>

<span data-ttu-id="e606d-123">ワード 0 のレイアウト:</span><span class="sxs-lookup"><span data-stu-id="e606d-123">Layout for word 0:</span></span>

| <span data-ttu-id="e606d-124">ビット</span><span class="sxs-lookup"><span data-stu-id="e606d-124">Bits</span></span>          | <span data-ttu-id="e606d-125">アルファ</span><span class="sxs-lookup"><span data-stu-id="e606d-125">Alpha</span></span>      |
|---------------|------------|
| <span data-ttu-id="e606d-126">3:0 (LSB\*)</span><span class="sxs-lookup"><span data-stu-id="e606d-126">3:0 (LSB\*)</span></span>   | <span data-ttu-id="e606d-127">\[0\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="e606d-127">\[0\]\[0\]</span></span> |
| <span data-ttu-id="e606d-128">7:4</span><span class="sxs-lookup"><span data-stu-id="e606d-128">7:4</span></span>           | <span data-ttu-id="e606d-129">\[0\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="e606d-129">\[0\]\[1\]</span></span> |
| <span data-ttu-id="e606d-130">11:8</span><span class="sxs-lookup"><span data-stu-id="e606d-130">11:8</span></span>          | <span data-ttu-id="e606d-131">\[0\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="e606d-131">\[0\]\[2\]</span></span> |
| <span data-ttu-id="e606d-132">15:12 (MSB\*)</span><span class="sxs-lookup"><span data-stu-id="e606d-132">15:12 (MSB\*)</span></span> | <span data-ttu-id="e606d-133">\[0\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="e606d-133">\[0\]\[3\]</span></span> |

 

<span data-ttu-id="e606d-134">\*最下位ビット、最上位ビット (MSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-134">\*least-significant bit, most significant bit (MSB)</span></span>

<span data-ttu-id="e606d-135">ワード 1 のレイアウト:</span><span class="sxs-lookup"><span data-stu-id="e606d-135">Layout for word 1:</span></span>

| <span data-ttu-id="e606d-136">ビット</span><span class="sxs-lookup"><span data-stu-id="e606d-136">Bits</span></span>        | <span data-ttu-id="e606d-137">アルファ</span><span class="sxs-lookup"><span data-stu-id="e606d-137">Alpha</span></span>      |
|-------------|------------|
| <span data-ttu-id="e606d-138">3:0 (LSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-138">3:0 (LSB)</span></span>   | <span data-ttu-id="e606d-139">\[1\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="e606d-139">\[1\]\[0\]</span></span> |
| <span data-ttu-id="e606d-140">7:4</span><span class="sxs-lookup"><span data-stu-id="e606d-140">7:4</span></span>         | <span data-ttu-id="e606d-141">\[1\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="e606d-141">\[1\]\[1\]</span></span> |
| <span data-ttu-id="e606d-142">11:8</span><span class="sxs-lookup"><span data-stu-id="e606d-142">11:8</span></span>        | <span data-ttu-id="e606d-143">\[1\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="e606d-143">\[1\]\[2\]</span></span> |
| <span data-ttu-id="e606d-144">15:12 (MSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-144">15:12 (MSB)</span></span> | <span data-ttu-id="e606d-145">\[1\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="e606d-145">\[1\]\[3\]</span></span> |

 

<span data-ttu-id="e606d-146">ワード 2 のレイアウト:</span><span class="sxs-lookup"><span data-stu-id="e606d-146">Layout for word 2:</span></span>

| <span data-ttu-id="e606d-147">ビット</span><span class="sxs-lookup"><span data-stu-id="e606d-147">Bits</span></span>        | <span data-ttu-id="e606d-148">アルファ</span><span class="sxs-lookup"><span data-stu-id="e606d-148">Alpha</span></span>      |
|-------------|------------|
| <span data-ttu-id="e606d-149">3:0 (LSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-149">3:0 (LSB)</span></span>   | <span data-ttu-id="e606d-150">\[2\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="e606d-150">\[2\]\[0\]</span></span> |
| <span data-ttu-id="e606d-151">7:4</span><span class="sxs-lookup"><span data-stu-id="e606d-151">7:4</span></span>         | <span data-ttu-id="e606d-152">\[2\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="e606d-152">\[2\]\[1\]</span></span> |
| <span data-ttu-id="e606d-153">11:8</span><span class="sxs-lookup"><span data-stu-id="e606d-153">11:8</span></span>        | <span data-ttu-id="e606d-154">\[2\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="e606d-154">\[2\]\[2\]</span></span> |
| <span data-ttu-id="e606d-155">15:12 (MSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-155">15:12 (MSB)</span></span> | <span data-ttu-id="e606d-156">\[2\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="e606d-156">\[2\]\[3\]</span></span> |

 

<span data-ttu-id="e606d-157">ワード 3 のレイアウト:</span><span class="sxs-lookup"><span data-stu-id="e606d-157">Layout for word 3:</span></span>

| <span data-ttu-id="e606d-158">ビット</span><span class="sxs-lookup"><span data-stu-id="e606d-158">Bits</span></span>        | <span data-ttu-id="e606d-159">アルファ</span><span class="sxs-lookup"><span data-stu-id="e606d-159">Alpha</span></span>      |
|-------------|------------|
| <span data-ttu-id="e606d-160">3:0 (LSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-160">3:0 (LSB)</span></span>   | <span data-ttu-id="e606d-161">\[3\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="e606d-161">\[3\]\[0\]</span></span> |
| <span data-ttu-id="e606d-162">7:4</span><span class="sxs-lookup"><span data-stu-id="e606d-162">7:4</span></span>         | <span data-ttu-id="e606d-163">\[3\]\[1\]</span><span class="sxs-lookup"><span data-stu-id="e606d-163">\[3\]\[1\]</span></span> |
| <span data-ttu-id="e606d-164">11:8</span><span class="sxs-lookup"><span data-stu-id="e606d-164">11:8</span></span>        | <span data-ttu-id="e606d-165">\[3\]\[2\]</span><span class="sxs-lookup"><span data-stu-id="e606d-165">\[3\]\[2\]</span></span> |
| <span data-ttu-id="e606d-166">15:12 (MSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-166">15:12 (MSB)</span></span> | <span data-ttu-id="e606d-167">\[3\]\[3\]</span><span class="sxs-lookup"><span data-stu-id="e606d-167">\[3\]\[3\]</span></span> |

 

<span data-ttu-id="e606d-168">BC1 でテクセルが透明かどうかを判断するために使われる色比較は、この形式では使われません。</span><span class="sxs-lookup"><span data-stu-id="e606d-168">The color compare used in BC1 to determine if the texel is transparent is not used in this format.</span></span> <span data-ttu-id="e606d-169">色比較を行わない場合、色データは常に 4 カラー モードであるものとして処理されると仮定されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-169">It is assumed that without the color compare the color data is always treated as if in 4-color mode.</span></span>

## <a name="span-idthree-bit-linear-alpha-interpolationspanspan-idthree-bit-linear-alpha-interpolationspanspan-idthree-bit-linear-alpha-interpolationspanthree-bit-linear-alpha-interpolation"></a><span data-ttu-id="e606d-170"><span id="Three-Bit-Linear-Alpha-Interpolation"></span><span id="three-bit-linear-alpha-interpolation"></span><span id="THREE-BIT-LINEAR-ALPHA-INTERPOLATION"></span>3 ビット線形アルファ補間</span><span class="sxs-lookup"><span data-stu-id="e606d-170"><span id="Three-Bit-Linear-Alpha-Interpolation"></span><span id="three-bit-linear-alpha-interpolation"></span><span id="THREE-BIT-LINEAR-ALPHA-INTERPOLATION"></span>Three-bit linear alpha interpolation</span></span>


<span data-ttu-id="e606d-171">BC3 形式での透明度のエンコーディングは、色に使用される線形エンコーディングと同様の概念に基づいています。</span><span class="sxs-lookup"><span data-stu-id="e606d-171">The encoding of transparency for the BC3 format is based on a concept similar to the linear encoding used for color.</span></span> <span data-ttu-id="e606d-172">2 つの 8 ビット アルファ値、およびピクセルあたり 3 ビットの 4 x 4 ビットマップが、ブロックの最初の 8 バイトに格納されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-172">Two 8-bit alpha values and a 4x4 bitmap with three bits per pixel are stored in the first eight bytes of the block.</span></span> <span data-ttu-id="e606d-173">代表的なアルファ値を使用して、中間アルファ値が補間されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-173">The representative alpha values are used to interpolate intermediate alpha values.</span></span> <span data-ttu-id="e606d-174">追加の情報は、2 つのアルファ値を格納する方法で利用できます。</span><span class="sxs-lookup"><span data-stu-id="e606d-174">Additional information is available in the way the two alpha values are stored.</span></span> <span data-ttu-id="e606d-175">alpha\_0 が alpha\_1 より大きい場合は、6 つの中間アルファ値が補間によって作成されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-175">If alpha\_0 is greater than alpha\_1, then six intermediate alpha values are created by the interpolation.</span></span> <span data-ttu-id="e606d-176">それ以外の場合、4 つの中間アルファ値が指定したアルファの極値の間で補間されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-176">Otherwise, four intermediate alpha values are interpolated between the specified alpha extremes.</span></span> <span data-ttu-id="e606d-177">その他 2 つの暗黙のアルファ値は、0 (完全に透明) と 255 (完全に不透明) です。</span><span class="sxs-lookup"><span data-stu-id="e606d-177">The two additional implicit alpha values are 0 (fully transparent) and 255 (fully opaque).</span></span>

<span data-ttu-id="e606d-178">次のコード例に、このアルゴリズムを示します。</span><span class="sxs-lookup"><span data-stu-id="e606d-178">The following code example illustrates this algorithm.</span></span>

```
// 8-alpha or 6-alpha block?    
if (alpha_0 > alpha_1) {    
    // 8-alpha block:  derive the other six alphas.    
    // Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.
    alpha_2 = (6 * alpha_0 + 1 * alpha_1 + 3) / 7;    // bit code 010
    alpha_3 = (5 * alpha_0 + 2 * alpha_1 + 3) / 7;    // bit code 011
    alpha_4 = (4 * alpha_0 + 3 * alpha_1 + 3) / 7;    // bit code 100
    alpha_5 = (3 * alpha_0 + 4 * alpha_1 + 3) / 7;    // bit code 101
    alpha_6 = (2 * alpha_0 + 5 * alpha_1 + 3) / 7;    // bit code 110
    alpha_7 = (1 * alpha_0 + 6 * alpha_1 + 3) / 7;    // bit code 111  
}    
else {  
    // 6-alpha block.    
    // Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.
    alpha_2 = (4 * alpha_0 + 1 * alpha_1 + 2) / 5;    // Bit code 010
    alpha_3 = (3 * alpha_0 + 2 * alpha_1 + 2) / 5;    // Bit code 011
    alpha_4 = (2 * alpha_0 + 3 * alpha_1 + 2) / 5;    // Bit code 100
    alpha_5 = (1 * alpha_0 + 4 * alpha_1 + 2) / 5;    // Bit code 101
    alpha_6 = 0;                                      // Bit code 110
    alpha_7 = 255;                                    // Bit code 111
}
```

<span data-ttu-id="e606d-179">アルファ ブロックのメモリ レイアウトは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="e606d-179">The memory layout of the alpha block is as follows:</span></span>

| <span data-ttu-id="e606d-180">バイト</span><span class="sxs-lookup"><span data-stu-id="e606d-180">Byte</span></span> | <span data-ttu-id="e606d-181">アルファ</span><span class="sxs-lookup"><span data-stu-id="e606d-181">Alpha</span></span>                                                          |
|------|----------------------------------------------------------------|
| <span data-ttu-id="e606d-182">0</span><span class="sxs-lookup"><span data-stu-id="e606d-182">0</span></span>    | <span data-ttu-id="e606d-183">Alpha\_0</span><span class="sxs-lookup"><span data-stu-id="e606d-183">Alpha\_0</span></span>                                                       |
| <span data-ttu-id="e606d-184">1</span><span class="sxs-lookup"><span data-stu-id="e606d-184">1</span></span>    | <span data-ttu-id="e606d-185">Alpha\_1</span><span class="sxs-lookup"><span data-stu-id="e606d-185">Alpha\_1</span></span>                                                       |
| <span data-ttu-id="e606d-186">2</span><span class="sxs-lookup"><span data-stu-id="e606d-186">2</span></span>    | <span data-ttu-id="e606d-187">\[0\]\[2\] (2 つの MSB)、\[0\]\[1\]、\[0\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="e606d-187">\[0\]\[2\] (2 MSBs), \[0\]\[1\], \[0\]\[0\]</span></span>                    |
| <span data-ttu-id="e606d-188">3</span><span class="sxs-lookup"><span data-stu-id="e606d-188">3</span></span>    | <span data-ttu-id="e606d-189">\[1\]\[1\] (1 つの MSB)、\[1\]\[0\]、\[0\]\[3\]、\[0\]\[2\] (1 つの LSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-189">\[1\]\[1\] (1 MSB), \[1\]\[0\], \[0\]\[3\], \[0\]\[2\] (1 LSB)</span></span> |
| <span data-ttu-id="e606d-190">4</span><span class="sxs-lookup"><span data-stu-id="e606d-190">4</span></span>    | <span data-ttu-id="e606d-191">\[1\]\[3\]、\[1\]\[2\]、\[1\]\[1\] (2 つの LSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-191">\[1\]\[3\], \[1\]\[2\], \[1\]\[1\] (2 LSBs)</span></span>                    |
| <span data-ttu-id="e606d-192">5</span><span class="sxs-lookup"><span data-stu-id="e606d-192">5</span></span>    | <span data-ttu-id="e606d-193">\[2\]\[2\] (2 つの MSB)、\[2\]\[1\]、\[2\]\[0\]</span><span class="sxs-lookup"><span data-stu-id="e606d-193">\[2\]\[2\] (2 MSBs), \[2\]\[1\], \[2\]\[0\]</span></span>                    |
| <span data-ttu-id="e606d-194">6</span><span class="sxs-lookup"><span data-stu-id="e606d-194">6</span></span>    | <span data-ttu-id="e606d-195">\[3\]\[1\] (1 つの MSB)、\[3\]\[0\]、\[2\]\[3\]、\[2\]\[2\] (1 つの LSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-195">\[3\]\[1\] (1 MSB), \[3\]\[0\], \[2\]\[3\], \[2\]\[2\] (1 LSB)</span></span> |
| <span data-ttu-id="e606d-196">7</span><span class="sxs-lookup"><span data-stu-id="e606d-196">7</span></span>    | <span data-ttu-id="e606d-197">\[3\]\[3\]、\[3\]\[2\]、\[3\]\[1\] (2 つの LSB)</span><span class="sxs-lookup"><span data-stu-id="e606d-197">\[3\]\[3\], \[3\]\[2\], \[3\]\[1\] (2 LSBs)</span></span>                    |

 

<span data-ttu-id="e606d-198">BC1 でテクセルが透明かどうかを判断するために使われる色比較は、これらの形式では使われません。</span><span class="sxs-lookup"><span data-stu-id="e606d-198">The color compare used in BC1 to determine if the texel is transparent is not used with these formats.</span></span> <span data-ttu-id="e606d-199">色比較を行わない場合、色データは常に 4 カラー モードであるものとして処理されると仮定されます。</span><span class="sxs-lookup"><span data-stu-id="e606d-199">It is assumed that without the color compare the color data is always treated as if in 4-color mode.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="e606d-200"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="e606d-200"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="e606d-201">圧縮テクスチャ リソース</span><span class="sxs-lookup"><span data-stu-id="e606d-201">Compressed texture resources</span></span>](compressed-texture-resources.md)

 

 




