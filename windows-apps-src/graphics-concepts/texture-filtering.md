---
title: テクスチャ フィルタリング
description: プリミティブが 3D プリミティブから 2D 画面へのマッピングによってレンダリングされるときに、テクスチャ フィルタリングによって、プリミティブの 2D レンダリングされた画像の各ピクセルの色が生成されます。
ms.assetid: 1CCF4138-5D48-4B07-9490-996844F994D8
keywords:
- テクスチャ フィルタリング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ce80bc0f64e1aba8328880203f22ea3909fdb3e3
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6842255"
---
# <a name="texture-filtering"></a><span data-ttu-id="06b43-104">テクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="06b43-104">Texture filtering</span></span>


<span data-ttu-id="06b43-105">プリミティブが 3D プリミティブから 2D 画面へのマッピングによってレンダリングされるときに、テクスチャ フィルタリングによって、プリミティブの 2D レンダリングされた画像の各ピクセルの色が生成されます。</span><span class="sxs-lookup"><span data-stu-id="06b43-105">Texture filtering produces a color for each pixel in the primitive's 2D rendered image when a primitive is rendered by mapping a 3D primitive onto a 2D screen.</span></span>

<span data-ttu-id="06b43-106">Direct3D では、プリミティブをレンダリングするとき、3D プリミティブを 2D 画面にマッピングします。</span><span class="sxs-lookup"><span data-stu-id="06b43-106">When Direct3D renders a primitive, it maps the 3D primitive onto a 2D screen.</span></span> <span data-ttu-id="06b43-107">プリミティブにテクスチャがある場合、Direct3D はそのテクスチャを必ず使用して、プリミティブの 2D レンダリングされた画像の各ピクセルのカラーを生成します。</span><span class="sxs-lookup"><span data-stu-id="06b43-107">If the primitive has a texture, Direct3D must use that texture to produce a color for each pixel in the primitive's 2D rendered image.</span></span> <span data-ttu-id="06b43-108">プリミティブの画面上の画像のピクセルごとに、テクスチャからカラー値を取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="06b43-108">For every pixel in the primitive's on-screen image, it must obtain a color value from the texture.</span></span> <span data-ttu-id="06b43-109">このプロセスは、*テクスチャフィルタリング*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="06b43-109">This process is called *texture filtering*.</span></span>

<span data-ttu-id="06b43-110">テクスチャ フィルタリング処理が実行されるとき、使用されるテクスチャは通常、拡大または縮小されます。</span><span class="sxs-lookup"><span data-stu-id="06b43-110">When a texture filter operation is performed, the texture being used is typically also being magnified or minified.</span></span> <span data-ttu-id="06b43-111">つまり、テクスチャは、それ自体よりも大きいまたは小さいプリミティブ イメージにマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="06b43-111">In other words, it is being mapped into a primitive image that is larger or smaller than itself.</span></span> <span data-ttu-id="06b43-112">テクスチャの拡大では、多数のピクセルが 1 つのテクセルにマッピングされることがあります。</span><span class="sxs-lookup"><span data-stu-id="06b43-112">Magnification of a texture can result in many pixels being mapped to one texel.</span></span> <span data-ttu-id="06b43-113">その結果、外観が粗くなる場合があります。</span><span class="sxs-lookup"><span data-stu-id="06b43-113">The result can be a chunky appearance.</span></span> <span data-ttu-id="06b43-114">テクスチャが縮小されると、多くの場合、1 つのピクセルが多数のテクセルにマッピングされます。</span><span class="sxs-lookup"><span data-stu-id="06b43-114">Minification of a texture often means that a single pixel is mapped to many texels.</span></span> <span data-ttu-id="06b43-115">その結果、イメージが不鮮明になったり、輪郭がギザギザになったりすることがあります。</span><span class="sxs-lookup"><span data-stu-id="06b43-115">The resulting image can be blurry or aliased.</span></span> <span data-ttu-id="06b43-116">このような問題を解決するには、ピクセルに適したカラーになるようにテクセルのカラーになんらかのブレンドを実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="06b43-116">To resolve these problems, some blending of the texel colors must be performed to arrive at a color for the pixel.</span></span>

<span data-ttu-id="06b43-117">Direct3D によって、テクスチャ フィルタリングの複雑なプロセスが単純化されます。</span><span class="sxs-lookup"><span data-stu-id="06b43-117">Direct3D simplifies the complex process of texture filtering.</span></span> <span data-ttu-id="06b43-118">Direct3D には、線形フィルタリング、異方性フィルタリング、およびミップマップ フィルタリングという 3 種類のテクスチャ フィルタリングが用意されています。</span><span class="sxs-lookup"><span data-stu-id="06b43-118">It provides you with three types of texture filtering - linear filtering, anisotropic filtering, and mipmap filtering.</span></span> <span data-ttu-id="06b43-119">テクスチャ フィルタリングを選択しなかった場合、Direct3D では最近点サンプリングという手法が使用されます。</span><span class="sxs-lookup"><span data-stu-id="06b43-119">If you select no texture filtering, Direct3D uses a technique called nearest-point sampling.</span></span>

<span data-ttu-id="06b43-120">それぞれのテクスチャ フィルタリングには、長所と短所があります。</span><span class="sxs-lookup"><span data-stu-id="06b43-120">Each type of texture filtering has advantages and disadvantages.</span></span> <span data-ttu-id="06b43-121">たとえば、線形テクスチャ フィルタリングでは、最終イメージでエッジがギザギザになったり、外観が粗くなったりすることがあります。</span><span class="sxs-lookup"><span data-stu-id="06b43-121">For instance, linear texture filtering can produce jagged edges or a chunky appearance in the final image.</span></span> <span data-ttu-id="06b43-122">ただし、このテクスチャ フィルタリングは計算処理のオーバーヘッドが少ない方法です。</span><span class="sxs-lookup"><span data-stu-id="06b43-122">However, it is a computationally low-overhead method of texture filtering.</span></span> <span data-ttu-id="06b43-123">ミップマップによるフィルタリングでは、通常、適切な結果が生成されます。特に、異方性フィルタリングと組み合わせた場合に結果がよくなります。</span><span class="sxs-lookup"><span data-stu-id="06b43-123">Filtering with mipmaps usually produces the best results, especially when combined with anisotropic filtering.</span></span> <span data-ttu-id="06b43-124">ただし、Direct3D でサポートされる方法の中で最も多くのメモリを必要とします。</span><span class="sxs-lookup"><span data-stu-id="06b43-124">However, it requires the most memory of the techniques that Direct3D supports.</span></span>

## <a name="span-idtypes-of-texture-filteringspanspan-idtypes-of-texture-filteringspanspan-idtypes-of-texture-filteringspantypes-of-texture-filtering"></a><span data-ttu-id="06b43-125"><span id="Types-of-texture-filtering"></span><span id="types-of-texture-filtering"></span><span id="TYPES-OF-TEXTURE-FILTERING"></span>テクスチャ フィルタリングの種類</span><span class="sxs-lookup"><span data-stu-id="06b43-125"><span id="Types-of-texture-filtering"></span><span id="types-of-texture-filtering"></span><span id="TYPES-OF-TEXTURE-FILTERING"></span>Types of texture filtering</span></span>


<span data-ttu-id="06b43-126">Direct3D は、次のテクスチャ フィルタリング手法をサポートします。</span><span class="sxs-lookup"><span data-stu-id="06b43-126">Direct3D supports the following texture filtering approaches.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="06b43-127"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="06b43-127"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="06b43-128">トピック</span><span class="sxs-lookup"><span data-stu-id="06b43-128">Topic</span></span></th>
<th align="left"><span data-ttu-id="06b43-129">説明</span><span class="sxs-lookup"><span data-stu-id="06b43-129">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="nearest-point-sampling.md"><span data-ttu-id="06b43-130">最近点サンプリング</span><span class="sxs-lookup"><span data-stu-id="06b43-130">Nearest-point sampling</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06b43-131">アプリケーションでは、必ずしもテクスチャ フィルタリングを使用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="06b43-131">Applications are not required to use texture filtering.</span></span> <span data-ttu-id="06b43-132">Direct3D の設定により、テクセル アドレスを計算したり (これは多くの場合、整数として評価されません)、最も近い整数アドレスを持つテクセルのカラーをコピーさせたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="06b43-132">Direct3D can be set so that it computes the texel address, which often does not evaluate to integers, and copies the color of the texel with the closest integer address.</span></span> <span data-ttu-id="06b43-133">このプロセスは、<em>最近点サンプリング</em>と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="06b43-133">This process is called <em>nearest-point sampling</em>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="bilinear-texture-filtering.md"><span data-ttu-id="06b43-134">バイリニア テクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="06b43-134">Bilinear texture filtering</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06b43-135"><em>バイリニア フィルタリング</em>は、サンプリング ポイントに最も近い 4 つのテクセルの加重平均を計算します。</span><span class="sxs-lookup"><span data-stu-id="06b43-135"><em>Bilinear filtering</em> calculates the weighted average of the 4 texels closest to the sampling point.</span></span> <span data-ttu-id="06b43-136">このフィルタリング手法は、最近点フィルタリングよりも正確で一般的です。</span><span class="sxs-lookup"><span data-stu-id="06b43-136">This filtering approach is more accurate and common than nearest-point filtering.</span></span> <span data-ttu-id="06b43-137">このアプローチは最新のグラフィックス ハードウェアに実装されているため、効率的です。</span><span class="sxs-lookup"><span data-stu-id="06b43-137">This approach is efficient because it is implemented in modern graphics hardware.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="anisotropic-texture-filtering.md"><span data-ttu-id="06b43-138">異方性テクスチャ フィルタ リング</span><span class="sxs-lookup"><span data-stu-id="06b43-138">Anisotropic texture filtering</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06b43-139">サーフェスがスクリーンの平面に対して角度をなして配置されている 3D オブジェクトのテクセルに見られるゆがみを<em>異方性</em>と呼びます。</span><span class="sxs-lookup"><span data-stu-id="06b43-139"><em>Anisotropy</em> is the distortion visible in the texels of a 3D object whose surface is oriented at an angle with respect to the plane of the screen.</span></span> <span data-ttu-id="06b43-140">異方性プリミティブのピクセルをテクセルにマッピングすると、形状がゆがみます。</span><span class="sxs-lookup"><span data-stu-id="06b43-140">When a pixel from an anisotropic primitive is mapped to texels, its shape is distorted.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="texture-filtering-with-mipmaps.md"><span data-ttu-id="06b43-141">ミップマップでのテクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="06b43-141">Texture filtering with mipmaps</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="06b43-142"><em>ミップマップ</em>は連続したテクスチャで、各テクスチャは同じイメージを徐々に低い解像度で表したものです。</span><span class="sxs-lookup"><span data-stu-id="06b43-142">A <em>mipmap</em> is a sequence of textures, each of which is a progressively lower resolution representation of the same image.</span></span> <span data-ttu-id="06b43-143">ミップマップでの各イメージの高さと幅、つまりレベルは、直前のレベルを 2 の累乗で割った値になります。</span><span class="sxs-lookup"><span data-stu-id="06b43-143">The height and width of each image, or level, in the mipmap is a power-of-two smaller than the previous level.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="06b43-144"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="06b43-144"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="06b43-145">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="06b43-145">Textures</span></span>](textures.md)

 

 




