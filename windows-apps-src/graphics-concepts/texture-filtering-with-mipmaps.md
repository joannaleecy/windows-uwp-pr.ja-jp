---
title: ミップマップでのテクスチャ フィルタリング
description: ミップマップは連続したテクスチャで、各テクスチャは同じイメージを徐々に低い解像度で表したものです。 ミップマップでの各イメージの高さと幅、つまりレベルは、直前のレベルを 2 の累乗で割った値になります。
ms.assetid: 28E863A2-C776-40E4-8551-9851DF7EC93E
keywords:
- ミップマップでのテクスチャ フィルタリング
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 474f97f32439c389be8283bb10e0c0ed716b3f69
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7691683"
---
# <a name="texture-filtering-with-mipmaps"></a><span data-ttu-id="2033f-105">ミップマップでのテクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="2033f-105">Texture filtering with mipmaps</span></span>


<span data-ttu-id="2033f-106">*ミップマップ*は連続したテクスチャで、各テクスチャは同じイメージを徐々に低い解像度で表したものです。</span><span class="sxs-lookup"><span data-stu-id="2033f-106">A *mipmap* is a sequence of textures, each of which is a progressively lower resolution representation of the same image.</span></span> <span data-ttu-id="2033f-107">ミップマップでの各イメージの高さと幅、つまりレベルは、直前のレベルを 2 の累乗で割った値になります。</span><span class="sxs-lookup"><span data-stu-id="2033f-107">The height and width of each image, or level, in the mipmap is a power-of-two smaller than the previous level.</span></span> <span data-ttu-id="2033f-108">ミップマップは正方形である必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2033f-108">Mipmaps do not have to be square.</span></span>

<span data-ttu-id="2033f-109">ユーザーに近いオブジェクトには、解像度の高いミップマップ イメージが使用されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-109">A high-resolution mipmap image is used for objects that are close to the user.</span></span> <span data-ttu-id="2033f-110">オブジェクトが遠くに表示されるにつれて、より低い解像度のイメージが使用されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-110">Lower-resolution images are used as the object appears farther away.</span></span> <span data-ttu-id="2033f-111">ミップマップ処理によってレンダリングしたテクスチャの品質は向上しますが、使用するメモリは増加します。</span><span class="sxs-lookup"><span data-stu-id="2033f-111">Mipmapping improves the quality of rendered textures at the expense of using more memory.</span></span>

<span data-ttu-id="2033f-112">Direct3D では、付属サーフェスのチェーンとしてミップマップが表現されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-112">Direct3D represents mipmaps as a chain of attached surfaces.</span></span> <span data-ttu-id="2033f-113">解像度が最も高いテクスチャはチェーンの先頭にあり、次のレベルのミップマップを添付データとして保有します。</span><span class="sxs-lookup"><span data-stu-id="2033f-113">The highest resolution texture is at the head of the chain and has the next level of the mipmap as an attachment.</span></span> <span data-ttu-id="2033f-114">さらに、そのレベルではミップマップ内の次のレベルの添付データを保有し、解像度が最も低いミップマップに至るまで続きます。</span><span class="sxs-lookup"><span data-stu-id="2033f-114">In turn, that level has an attachment that is the next level in the mipmap, and so on, down to the lowest resolution level of the mipmap.</span></span>

<span data-ttu-id="2033f-115">以下の各図は、これらのレベルの例を示したものです。</span><span class="sxs-lookup"><span data-stu-id="2033f-115">The following illustrations shows an example of these levels.</span></span> <span data-ttu-id="2033f-116">このビットマップ テクスチャは、主観視点の 3D ゲームにおけるコンテナーの警告表示を表しています。</span><span class="sxs-lookup"><span data-stu-id="2033f-116">The bitmap textures represent a sign on a container in a 3D first-person game.</span></span> <span data-ttu-id="2033f-117">ミップマップとして作成すると、解像度が最も高いテクスチャが先頭になります。</span><span class="sxs-lookup"><span data-stu-id="2033f-117">When created as a mipmap, the highest resolution texture is first in the set.</span></span> <span data-ttu-id="2033f-118">ミップマップ セット内のその後に続く各テクスチャの高さと幅は 2 の累乗ずつ小さくなります。</span><span class="sxs-lookup"><span data-stu-id="2033f-118">Each succeeding texture in the mipmap set is smaller in height and width by a power of 2.</span></span> <span data-ttu-id="2033f-119">この場合、解像度が最も高いミップマップは 256 × 256 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="2033f-119">In this case, the maximum-resolution mipmap is 256 pixels by 256 pixels.</span></span> <span data-ttu-id="2033f-120">次のテクスチャは 128 × 128 です。</span><span class="sxs-lookup"><span data-stu-id="2033f-120">The next, texture is 128x128.</span></span> <span data-ttu-id="2033f-121">チェーン内の最後のテクスチャは 64 × 64 です。</span><span class="sxs-lookup"><span data-stu-id="2033f-121">The last texture in the chain is 64x64.</span></span>

<span data-ttu-id="2033f-122">この表示は、可視範囲から最大の距離にあります。</span><span class="sxs-lookup"><span data-stu-id="2033f-122">This sign has a maximum distance from which it is visible.</span></span> <span data-ttu-id="2033f-123">ユーザーがこの表示から遠く離れたところからゲームを始めた場合、ミップマップ チェーン内の最小のテクスチャ (この場合は 64 x 64 のテクスチャ) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-123">If the user begins far away from the sign, the game displays the smallest texture in the mipmap chain, which in this case the 64x64 texture.</span></span>

![警告表示の 64 x 64 のテクスチャの図](images/mip1.jpg)

<span data-ttu-id="2033f-125">ユーザーが視点を警告表示に近づけるにつれて、徐々にミップマップ チェーン内の解像度が高いテクスチャが使用されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-125">As the user moves the point of view closer to the sign, progressively higher-resolution textures in the mipmap chain are used.</span></span> <span data-ttu-id="2033f-126">次の図の解像度は 128 x 128 です。</span><span class="sxs-lookup"><span data-stu-id="2033f-126">The resolution in the following illustration is 128x128.</span></span>

![警告表示の 128 x 128 のテクスチャの図](images/mip2.jpg)

<span data-ttu-id="2033f-128">次の図に示すように、ユーザーの視点が警告表示からの許容最短距離にあるとき、解像度が最も高いテクスチャが使用されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-128">The highest resolution texture is used when the user's point of view is at the minimum allowable distance from the sign, as shown in the following illustration.</span></span>

![警告表示の 256 x 256 のテクスチャの図](images/mip3.jpg)

<span data-ttu-id="2033f-130">これは、テクスチャの遠近の見え方をシミュレートする際の効率的な方法です。</span><span class="sxs-lookup"><span data-stu-id="2033f-130">This is a more efficient way of simulating perspective for textures.</span></span> <span data-ttu-id="2033f-131">1 つのテクスチャを多くの解像度でレンダリングするよりも、複数のテクスチャを各解像度で使用する方が時間がかかりません。</span><span class="sxs-lookup"><span data-stu-id="2033f-131">Rather than render a single texture at many resolutions, it is faster to use multiple textures at varying resolutions.</span></span>

<span data-ttu-id="2033f-132">Direct3D では、ミップマップ セット内のどのテクスチャが目的とする出力に最も近い解像度であるかを評価し、そのテクセル空間にピクセルをマッピングすることができます。</span><span class="sxs-lookup"><span data-stu-id="2033f-132">Direct3D can assess which texture in a mipmap set is the closest resolution to the desired output, and it can map pixels into its texel space.</span></span> <span data-ttu-id="2033f-133">最終画像の解像度がミップマップ セット内の複数のテクスチャ解像度の間にある場合、Direct3D では、両方のミップマップのテクセルを調べて、そのカラー値をブレンドします。</span><span class="sxs-lookup"><span data-stu-id="2033f-133">If the resolution of the final image is between the resolutions of the textures in the mipmap set, Direct3D can examine texels in both mipmaps and blend their color values together.</span></span>

<span data-ttu-id="2033f-134">ミップマップを使用するには、アプリケーションでミップマップのセットを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2033f-134">To use mipmaps, your application must build a set of mipmaps.</span></span> <span data-ttu-id="2033f-135">アプリケーションでは、ミップマップ セットを現在のテクスチャ セットの最初のテクスチャとして選択することによって、ミップマップを適用します。</span><span class="sxs-lookup"><span data-stu-id="2033f-135">Applications apply mipmaps by selecting the mipmap set as the first texture in the set of current textures.</span></span> <span data-ttu-id="2033f-136">「[テクスチャ ブレンド](texture-blending.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2033f-136">See [Texture blending](texture-blending.md).</span></span>

<span data-ttu-id="2033f-137">次に、Direct3D でテクセルのサンプリングに使用するフィルタリング方法を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2033f-137">Next, your application must set the filtering method that Direct3D uses to sample texels.</span></span> <span data-ttu-id="2033f-138">最も時間がかからないミップマップ フィルタリング方法は、Direct3D で最も近いテクセルを選択する方法です。</span><span class="sxs-lookup"><span data-stu-id="2033f-138">The fastest method of mipmap filtering is to have Direct3D select the nearest texel.</span></span> <span data-ttu-id="2033f-139">これを選択するには、D3DTEXF\_POINT 列挙値を使用します。</span><span class="sxs-lookup"><span data-stu-id="2033f-139">Use the D3DTEXF\_POINT enumerated value to select this.</span></span> <span data-ttu-id="2033f-140">Direct3D では、D3DTEXF\_LINEAR 列挙値を使用すると、より適切なフィルタリング結果を生成することができます。</span><span class="sxs-lookup"><span data-stu-id="2033f-140">Direct3D can produce better filtering results if your application uses the D3DTEXF\_LINEAR enumerated value.</span></span> <span data-ttu-id="2033f-141">これによって最も近いミップマップが選択され、テクスチャ内の現在のピクセルがマッピングされる位置の周辺で、テクセルの加重平均が計算されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-141">This selects the nearest mipmap, and then computes a weighted average of the texels surrounding the location in the texture to which the current pixel maps.</span></span>

<span data-ttu-id="2033f-142">ミップマップ テクスチャは 3D シーンで使用され、シーンのレンダリングに必要な時間が短縮されます。</span><span class="sxs-lookup"><span data-stu-id="2033f-142">Mipmap textures are used in 3D scenes to decrease the time required to render a scene.</span></span> <span data-ttu-id="2033f-143">また、シーンのリアリティも増します。</span><span class="sxs-lookup"><span data-stu-id="2033f-143">They also improve the scene's realism.</span></span> <span data-ttu-id="2033f-144">ただし、多くの場合、大量のメモリを必要とします。</span><span class="sxs-lookup"><span data-stu-id="2033f-144">However, they often require large amounts of memory.</span></span>

<span data-ttu-id="2033f-145">**注:** ミップマップ チェーン内の各サーフェスがサイズは、チェーン内の以前のサーフェスの半分です。</span><span class="sxs-lookup"><span data-stu-id="2033f-145">**Note** Each surface in a mipmap chain has dimensions that are one-half that of the previous surface in the chain.</span></span> <span data-ttu-id="2033f-146">最上位のミップマップのサイズが 256 x 128 である場合、第 2 レベルのミップマップのサイズは 128 x 64、第 3 レベルは 64 x 32 というように小さくなり、最終的には 1 x 1 になります。</span><span class="sxs-lookup"><span data-stu-id="2033f-146">If the top-level mipmap has dimensions of 256x128, the dimensions of the second-level mipmap are 128x64, the third-level are 64x32, and so on, down to 1x1.</span></span> <span data-ttu-id="2033f-147">Levels では、チェーン内のミップマップの幅または高さが 1 より小さくなるようなミップマップ レベルを指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="2033f-147">You cannot request a number of mipmap levels in Levels that would cause either the width or height of any mipmap in the chain to be smaller than 1.</span></span> <span data-ttu-id="2033f-148">最上位のミップマップ サーフェスが 4 × 2 の単純な場合、Levels の有効最大値は 3 です。</span><span class="sxs-lookup"><span data-stu-id="2033f-148">In the simple case of a 4x2 top-level mipmap surface, the maximum value allowed for Levels is three.</span></span> <span data-ttu-id="2033f-149">最上位のサイズが 4 × 2 である場合、第 2 レベルのサイズは 2 × 1、第 3 レベルのサイズは 1 × 1 になります。</span><span class="sxs-lookup"><span data-stu-id="2033f-149">The top-level dimensions are 4x2, the second-level dimensions are 2x1, and the dimensions for the third level are 1x1.</span></span> <span data-ttu-id="2033f-150">Levels の値が 3 よりも大きい場合、第 2 レベルのミップマップの高さが小数値になるので、許可されません。</span><span class="sxs-lookup"><span data-stu-id="2033f-150">A value larger than 3 in Levels results in a fractional value in the height of the second-level mipmap, and is therefore disallowed.</span></span>

 

<span data-ttu-id="2033f-151">Direct3D は、ミップマップのテクスチャ フィルタ リングを自動的に実行できます。</span><span class="sxs-lookup"><span data-stu-id="2033f-151">Direct3D can automatically perform mipmap texture filtering.</span></span> <span data-ttu-id="2033f-152">アプリケーションでは、ミップマップ チェーン内を手動で移動して、チェーン内の各サーフェスにビットマップ データをロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2033f-152">Applications can manually traverse a mipmap chain to load bitmap data into each surface in the chain.</span></span> <span data-ttu-id="2033f-153">通常は、この目的のみにチェーン内を移動します。</span><span class="sxs-lookup"><span data-stu-id="2033f-153">This is often the only reason to traverse the chain.</span></span> <span data-ttu-id="2033f-154">テクスチャの作成時にミップマップを自動的に生成すると、ミップマップはビデオ メモリに格納されるため、ハードウェア フィルタリングを利用できます。</span><span class="sxs-lookup"><span data-stu-id="2033f-154">Automatically generating mipmaps at texture creation time takes advantage of hardware filtering because the mipmap resides in video memory.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="2033f-155"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="2033f-155"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="2033f-156">テクスチャ フィルタリング</span><span class="sxs-lookup"><span data-stu-id="2033f-156">Texture filtering</span></span>](texture-filtering.md)

 

 




