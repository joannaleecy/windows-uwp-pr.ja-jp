---
title: バイリニア テクスチャ フィルタリング
description: バイリニア フィルタリングは、サンプリング ポイントに最も近い 4 つのテクセルの加重平均を計算します。
ms.assetid: 0851AD28-8246-4547-A663-47884DDDFC3E
keywords:
- バイリニア テクスチャ フィルタリング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 48e16162a76b1a599c1a43e763243be4348810af
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6281214"
---
# <a name="bilinear-texture-filtering"></a><span data-ttu-id="5442d-104">バイリニア テクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="5442d-104">Bilinear texture filtering</span></span>


<span data-ttu-id="5442d-105">*バイリニア フィルタリング*は、サンプリング ポイントに最も近い 4 つのテクセルの加重平均を計算します。</span><span class="sxs-lookup"><span data-stu-id="5442d-105">*Bilinear filtering* calculates the weighted average of the 4 texels closest to the sampling point.</span></span> <span data-ttu-id="5442d-106">このフィルタリング手法は、最近点フィルタリングよりも正確で一般的です。</span><span class="sxs-lookup"><span data-stu-id="5442d-106">This filtering approach is more accurate and common than nearest-point filtering.</span></span> <span data-ttu-id="5442d-107">このアプローチは最新のグラフィックス ハードウェアに実装されているため、効率的です。</span><span class="sxs-lookup"><span data-stu-id="5442d-107">This approach is efficient because it is implemented in modern graphics hardware.</span></span>


## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="5442d-108"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="5442d-108"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="5442d-109">テクスチャは常に、左上隅の (0.0, 0.0) から右下隅の (1.0, 1.0) へと線形的に座標が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="5442d-109">Textures are always linearly addressed from (0.0, 0.0) at the top-left corner to (1.0, 1.0) at the bottom-right corner.</span></span> <span data-ttu-id="5442d-110">次の図は、テクスチャの線形のアドレス指定を示しています。</span><span class="sxs-lookup"><span data-stu-id="5442d-110">Linear addressing of a texture is shown in the following illustration.</span></span>

![カラーのソリッド ブロックの 4 x 4 テクスチャを示す図](images/bilinear-fig7a.png)

<span data-ttu-id="5442d-112">テクスチャは通常、単色のカラー ブロックで構成されているように表されますが、実際には、ラスター表示の概念と同様にテクスチャについても考えるとより正確です。各テクセルは、下の図のように、グリッド セルのちょうど中心で定義されます。</span><span class="sxs-lookup"><span data-stu-id="5442d-112">Textures are usually represented as if they were composed of solid blocks of color, but it's actually more correct to think of textures the same way you should think of the raster display: Each texel is defined at the exact center of a grid cell, as shown in the following illustration.</span></span>

![グリッド セルの中心にテクセルが定義された 4 x 4 テクスチャを示す図](images/bilinear-fig7b.png)

<span data-ttu-id="5442d-114">UV 座標 (0.375, 0.375) におけるこのテクスチャのカラーをテクスチャ サンプラーに要求すると、単色の赤 (255, 0, 0) を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="5442d-114">If you ask the texture sampler for this texture's color at UV coordinates (0.375, 0.375) you'll get solid red (255, 0, 0).</span></span> <span data-ttu-id="5442d-115">赤のテクセルのセルのちょうど中心は UV (0.375, 0.375) にあるので、これは問題ありません。</span><span class="sxs-lookup"><span data-stu-id="5442d-115">That makes sense because the center of the red texel cell is at UV (0.375, 0.375).</span></span> <span data-ttu-id="5442d-116">UV (0.25, 0.25) におけるテクスチャのカラーをサンプラーに要求した場合はどうでしょうか。</span><span class="sxs-lookup"><span data-stu-id="5442d-116">What if you ask the sampler for the texture's color at UV (0.25, 0.25)?</span></span> <span data-ttu-id="5442d-117">UV (0.25, 0.25) のポイントは 4 つのテクセルのちょうど隅にあるので、これはそれほど容易ではありません。</span><span class="sxs-lookup"><span data-stu-id="5442d-117">That's not as easy, because the point at UV (0.25, 0.25) lies at the exact corner of 4 texels.</span></span>

<span data-ttu-id="5442d-118">最も単純な方法は、最も近いテクセルのカラーをサンプラーが返すようにする方法です。これは点フィルタリング ([最近点サンプリング](nearest-point-sampling.md) をご覧ください) と呼ばれ、結果が粗くなったり、むらができたりするので、一般には望ましくありません。</span><span class="sxs-lookup"><span data-stu-id="5442d-118">The simplest scheme is simply to have the sampler return the color of the closest texel; this is called Point filtering (see [Nearest-point sampling](nearest-point-sampling.md)), and is usually undesirable due to grainy or blocky results.</span></span> <span data-ttu-id="5442d-119">UV (0.25, 0.25) におけるテクスチャの点サンプリングによって、最近点フィルタリングに関する別の微妙な問題が明らかになります。サンプリング ポイントから等距離のテクセルが 4 つあるので、最も近いテクセルが 1 つあるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="5442d-119">Point-sampling our texture at UV (0.25, 0.25) shows another subtle problem with nearest-point filtering: there are four texels equidistant from the sampling point, so there's no single nearest texel.</span></span> <span data-ttu-id="5442d-120">この 4 つのテクセルのいずれかが、返されるカラーとして選択されますが、選択されるテクセルは座標の丸め方によって異なり、不自然なテアリングが生じる可能性があります (SDK の最近点サンプリングに関する記事を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="5442d-120">One of those four texels will be chosen as the returned color, but the selection depends on how the coordinate is rounded, which may introduce tearing artifacts (see the Nearest-Point Sampling article in the SDK).</span></span>

<span data-ttu-id="5442d-121">もう少し正確で一般的なフィルタリング方法は、サンプリング ポイントに最も近い 4 つのテクセルの加重平均を計算する方法です。これは*バイリニア フィルタリング*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="5442d-121">A slightly more accurate and more common filtering scheme is to calculate the weighted average of the 4 texels closest to the sampling point; this is called *Bilinear filtering*.</span></span> <span data-ttu-id="5442d-122">このルーチンは最近のグラフィック ハードウェアに実装されているので、通常、増加する計算コストはごくわずかです。</span><span class="sxs-lookup"><span data-stu-id="5442d-122">The extra computational cost for Bilinear filtering is usually negligible because this routine is implemented in modern graphics hardware.</span></span> <span data-ttu-id="5442d-123">バイリニア フィルタリングを使用して、さまざまなサンプル ポイントで取得するカラーを次に示します。</span><span class="sxs-lookup"><span data-stu-id="5442d-123">Here are the colors we get at a few different sample points using bilinear filtering:</span></span>

```
UV: (0.5, 0.5)
```

<span data-ttu-id="5442d-124">このポイントは、赤、緑、青、および白の各テクセル間のちょうど境界にあります。</span><span class="sxs-lookup"><span data-stu-id="5442d-124">This point is at the exact border between red, green, blue, and white texels.</span></span> <span data-ttu-id="5442d-125">サンプラーが返すカラーは灰色です。</span><span class="sxs-lookup"><span data-stu-id="5442d-125">The color the sampler returns is gray:</span></span>

```
  0.25 * (255, 0, 0)
  0.25 * (0, 255, 0) 
  0.25 * (0, 0, 255) 
## + 0.25 * (255, 255, 255) 
------------------------
= (128, 128, 128)
```

```
UV: (0.5, 0.375)
```

<span data-ttu-id="5442d-126">このポイントは、赤と緑のテクセル間の境界の中点にあります。</span><span class="sxs-lookup"><span data-stu-id="5442d-126">This point is at the midpoint of the border between red and green texels.</span></span> <span data-ttu-id="5442d-127">サンプラーが返すカラーは黄灰色です (青と白のテクセルのコントリビューションのスケールは 0 に設定されています)。</span><span class="sxs-lookup"><span data-stu-id="5442d-127">The color the sampler returns is yellow-gray (note that the contributions of the blue and white texels are scaled to 0):</span></span>

```
  0.5 * (255, 0, 0)
  0.5 * (0, 255, 0) 
  0.0 * (0, 0, 255) 
## + 0.0 * (255, 255, 255) 
------------------------
= (128, 128, 0)
```

```
UV: (0.375, 0.375)
```

<span data-ttu-id="5442d-128">これは、返されたカラーである赤のテクセルのアドレスです (フィルタリング計算における他のすべてのテクセルの重みは 0 に設定されています)。</span><span class="sxs-lookup"><span data-stu-id="5442d-128">This is the address of the red texel, which is the returned color (all other texels in the filtering calculation are weighted to 0):</span></span>

```
  1.0 * (255, 0, 0)
  0.0 * (0, 255, 0) 
  0.0 * (0, 0, 255) 
## + 0.0 * (255, 255, 255) 
------------------------
= (255, 0, 0)
```

<span data-ttu-id="5442d-129">これらの計算を次の図と比較してみましょう。この図では、4 × 4 テクスチャ内の各テクスチャ アドレスでバイリニア フィルタリング計算を実行した場合に表示されるカラーを示しています。</span><span class="sxs-lookup"><span data-stu-id="5442d-129">Compare these calculations against the following illustration, which shows what happens if the bilinear filtering calculation is performed at every texture address across the 4x4 texture.</span></span>

![すべてのテクスチャ アドレスでバイリニア フィルタリングが実行された 4 × 4 テクスチャを示す図](images/bilinear-fig7c.jpg)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="5442d-131"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="5442d-131"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="5442d-132">テクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="5442d-132">Texture filtering</span></span>](texture-filtering.md)

 

 




