---
title: Texture2D と Texture2DArray のサブリソースのタイル表示
description: 以下の表に、Texture2D および Texture2DArray サブリソースがどのようにタイル表示されるかを示します。
ms.assetid: 2DC14DFC-5299-44D9-895F-5A223D3FD530
keywords:
- Texture2D と Texture2DArray のサブリソースのタイル表示
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 2175ce19824068a850ff70340b467f09e5c76540
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8788729"
---
# <a name="texture2d-and-texture2darray-subresource-tiling"></a><span data-ttu-id="987cd-104">Texture2D と Texture2DArray のサブリソースのタイル表示</span><span class="sxs-lookup"><span data-stu-id="987cd-104">Texture2D and Texture2DArray subresource tiling</span></span>


<span data-ttu-id="987cd-105">次の表に、[**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) および [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) サブリソースがどのようにタイル表示されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="987cd-105">These tables show how [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) and [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) subresources are tiled.</span></span> <span data-ttu-id="987cd-106">これらの表の値は、テール ミップ パッキングをカウントしていません。</span><span class="sxs-lookup"><span data-stu-id="987cd-106">The values in these tables don't count tail mip packing.</span></span>

## <a name="span-idsubresources-with-multisample-counts-of-1spanspan-idsubresources-with-multisample-counts-of-1spanspan-idsubresources-with-multisample-counts-of-1spansubresources-with-multisample-counts-of-1"></a><span data-ttu-id="987cd-107"><span id="Subresources-with-multisample-counts-of-1"></span><span id="subresources-with-multisample-counts-of-1"></span><span id="SUBRESOURCES-WITH-MULTISAMPLE-COUNTS-OF-1"></span>マルチサンプル数が 1 のサブリソース</span><span class="sxs-lookup"><span data-stu-id="987cd-107"><span id="Subresources-with-multisample-counts-of-1"></span><span id="subresources-with-multisample-counts-of-1"></span><span id="SUBRESOURCES-WITH-MULTISAMPLE-COUNTS-OF-1"></span>Subresources with multisample counts of 1</span></span>


<span data-ttu-id="987cd-108">次の表に、マルチサンプル数が 1 の [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) および [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) サブリソースがどのようにタイル表示されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="987cd-108">This table shows how [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) and [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) subresources with multisample counts of 1 are tiled.</span></span>

| <span data-ttu-id="987cd-109">ビット/ピクセル (1 サンプル/ピクセル)</span><span class="sxs-lookup"><span data-stu-id="987cd-109">Bits/Pixel (1 sample/pixel)</span></span> | <span data-ttu-id="987cd-110">タイルの寸法 (ピクセル、W x H)</span><span class="sxs-lookup"><span data-stu-id="987cd-110">Tile Dimensions (Pixels, WxH)</span></span> |
|-----------------------------|-------------------------------|
| <span data-ttu-id="987cd-111">8</span><span class="sxs-lookup"><span data-stu-id="987cd-111">8</span></span>                           | <span data-ttu-id="987cd-112">256 x 256</span><span class="sxs-lookup"><span data-stu-id="987cd-112">256x256</span></span>                       |
| <span data-ttu-id="987cd-113">16</span><span class="sxs-lookup"><span data-stu-id="987cd-113">16</span></span>                          | <span data-ttu-id="987cd-114">256 x 128</span><span class="sxs-lookup"><span data-stu-id="987cd-114">256x128</span></span>                       |
| <span data-ttu-id="987cd-115">32</span><span class="sxs-lookup"><span data-stu-id="987cd-115">32</span></span>                          | <span data-ttu-id="987cd-116">128 x 128</span><span class="sxs-lookup"><span data-stu-id="987cd-116">128x128</span></span>                       |
| <span data-ttu-id="987cd-117">64</span><span class="sxs-lookup"><span data-stu-id="987cd-117">64</span></span>                          | <span data-ttu-id="987cd-118">128 x 64</span><span class="sxs-lookup"><span data-stu-id="987cd-118">128x64</span></span>                        |
| <span data-ttu-id="987cd-119">128</span><span class="sxs-lookup"><span data-stu-id="987cd-119">128</span></span>                         | <span data-ttu-id="987cd-120">64 x 64</span><span class="sxs-lookup"><span data-stu-id="987cd-120">64x64</span></span>                         |
| <span data-ttu-id="987cd-121">BC1、4</span><span class="sxs-lookup"><span data-stu-id="987cd-121">BC1,4</span></span>                       | <span data-ttu-id="987cd-122">512 x 256</span><span class="sxs-lookup"><span data-stu-id="987cd-122">512x256</span></span>                       |
| <span data-ttu-id="987cd-123">BC2、3、5、6、7</span><span class="sxs-lookup"><span data-stu-id="987cd-123">BC2,3,5,6,7</span></span>                 | <span data-ttu-id="987cd-124">256 x 256</span><span class="sxs-lookup"><span data-stu-id="987cd-124">256x256</span></span>                       |

 

<span data-ttu-id="987cd-125">ストリーミング リソースでサポートされない形式のビット数は、96 bpp 形式、ビデオ形式、DXGI\_FORMAT\_R1\_UNORM、DXGI\_FORMAT\_R8G8\_B8G8\_UNORM、および DXGI\_FORMAT\_R8R8\_G8B8\_UNORM です。</span><span class="sxs-lookup"><span data-stu-id="987cd-125">Format bit counts not supported with streaming resources are 96 bpp formats, video formats, DXGI\_FORMAT\_R1\_UNORM, DXGI\_FORMAT\_R8G8\_B8G8\_UNORM, and DXGI\_FORMAT\_R8R8\_G8B8\_UNORM.</span></span>

## <a name="span-idsubresources-with-various-multisample-countsspanspan-idsubresources-with-various-multisample-countsspanspan-idsubresources-with-various-multisample-countsspansubresources-with-various-multisample-counts"></a><span data-ttu-id="987cd-126"><span id="Subresources-with-various-multisample-counts"></span><span id="subresources-with-various-multisample-counts"></span><span id="SUBRESOURCES-WITH-VARIOUS-MULTISAMPLE-COUNTS"></span>さまざまなマルチサンプル数のサブリソース</span><span class="sxs-lookup"><span data-stu-id="987cd-126"><span id="Subresources-with-various-multisample-counts"></span><span id="subresources-with-various-multisample-counts"></span><span id="SUBRESOURCES-WITH-VARIOUS-MULTISAMPLE-COUNTS"></span>Subresources with various multisample counts</span></span>


<span data-ttu-id="987cd-127">次の表に、さまざまなマルチサンプル数の [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) および [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) サブリソースがどのようにタイル表示されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="987cd-127">This table shows how [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) and [**Texture2DArray**](https://msdn.microsoft.com/library/windows/desktop/ff471526) subresources with various multisample counts are tiled.</span></span>

| <span data-ttu-id="987cd-128">ビット/ピクセル (1 サンプル/ピクセル)</span><span class="sxs-lookup"><span data-stu-id="987cd-128">Bits/Pixel (1 sample/pixel)</span></span> | <span data-ttu-id="987cd-129">タイルの寸法 (ピクセル、W x H)</span><span class="sxs-lookup"><span data-stu-id="987cd-129">Tile Dimensions (Pixels, WxH)</span></span> |
|-----------------------------|-------------------------------|
| <span data-ttu-id="987cd-130">1</span><span class="sxs-lookup"><span data-stu-id="987cd-130">1</span></span>                           | <span data-ttu-id="987cd-131">1 x 1</span><span class="sxs-lookup"><span data-stu-id="987cd-131">1x1</span></span>                           |
| <span data-ttu-id="987cd-132">2</span><span class="sxs-lookup"><span data-stu-id="987cd-132">2</span></span>                           | <span data-ttu-id="987cd-133">2 x 1</span><span class="sxs-lookup"><span data-stu-id="987cd-133">2x1</span></span>                           |
| <span data-ttu-id="987cd-134">4</span><span class="sxs-lookup"><span data-stu-id="987cd-134">4</span></span>                           | <span data-ttu-id="987cd-135">2 x 2</span><span class="sxs-lookup"><span data-stu-id="987cd-135">2x2</span></span>                           |
| <span data-ttu-id="987cd-136">8</span><span class="sxs-lookup"><span data-stu-id="987cd-136">8</span></span>                           | <span data-ttu-id="987cd-137">4 x 2</span><span class="sxs-lookup"><span data-stu-id="987cd-137">4x2</span></span>                           |
| <span data-ttu-id="987cd-138">16</span><span class="sxs-lookup"><span data-stu-id="987cd-138">16</span></span>                          | <span data-ttu-id="987cd-139">4 x 4</span><span class="sxs-lookup"><span data-stu-id="987cd-139">4x4</span></span>                           |

 

<span data-ttu-id="987cd-140">サンプル数 1 および 4 だけが、ストリーミング リソースにサポート (および許可) される必要があります。</span><span class="sxs-lookup"><span data-stu-id="987cd-140">Only sample counts 1 and 4 are required (and allowed) to be supported with streaming resources.</span></span> <span data-ttu-id="987cd-141">ストリーミング リソースは現在、2、8、および 16 をサポートしていません (表示されていますが)。</span><span class="sxs-lookup"><span data-stu-id="987cd-141">Streaming resources don't currently support 2, 8, and 16 even though they are shown.</span></span>

<span data-ttu-id="987cd-142">実装では、ストリーミング リソースでサポートされていない場合でも、非ストリーミング リソースで 2、8、または 16 サンプルのマルチサンプル アンチエイリアシング (MSAA) モードをサポートすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="987cd-142">Implementations can choose to support 2, 8, and/or 16 sample multisample antialiasing (MSAA) mode for non-streaming resources even though streaming resource don't support them.</span></span>

<span data-ttu-id="987cd-143">サンプル数が 1 より大きいストリーミング リソースは、128 bpp 形式を使うことはできません。</span><span class="sxs-lookup"><span data-stu-id="987cd-143">Streaming resources with sample counts larger than 1 can't use 128 bpp formats.</span></span>

<span data-ttu-id="987cd-144">サポートされているサンプルの数と形式に関する制約は、仕様とハードウェアの不一致が原因です。</span><span class="sxs-lookup"><span data-stu-id="987cd-144">The constraints on supported sample counts and formats are due to hardware inconsistencies from the specification.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="987cd-145"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="987cd-145"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="987cd-146">ストリーミング リソースの領域をタイル表示する方法</span><span class="sxs-lookup"><span data-stu-id="987cd-146">How a streaming resource's area is tiled</span></span>](how-a-streaming-resource-s-area-is-tiled.md)

 

 




