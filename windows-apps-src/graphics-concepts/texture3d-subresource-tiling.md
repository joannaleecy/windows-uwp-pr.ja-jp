---
title: Texture3D サブリソースのタイル表示
description: 次の表に、Texture3D サブリソースがどのようにタイル表示されるかを示します。
ms.assetid: 210D03E4-CF12-47E0-BA2F-C8D059B17D3E
keywords:
- Texture3D サブリソースのタイル表示
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c9c232bc60bbbb3cccc16618d82ec23452c58ee8
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8193061"
---
# <a name="texture3d-subresource-tiling"></a><span data-ttu-id="6aafc-104">Texture3D サブリソースのタイル表示</span><span class="sxs-lookup"><span data-stu-id="6aafc-104">Texture3D subresource tiling</span></span>


<span data-ttu-id="6aafc-105">次の表に、[**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562) サブリソースがどのようにタイル表示されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="6aafc-105">This table shows how [**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562) subresources are tiled.</span></span> <span data-ttu-id="6aafc-106">この表の値は、テール ミップ パッキングをカウントしていません。</span><span class="sxs-lookup"><span data-stu-id="6aafc-106">The values in this table don't count tail mip packing.</span></span>

<span data-ttu-id="6aafc-107">次の表では、[**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) のタイル表示を受け取り、x/y 次元をそれぞれ 4 で割り、16 レイヤーの深度を追加します。</span><span class="sxs-lookup"><span data-stu-id="6aafc-107">This table takes the [**Texture2D**](https://msdn.microsoft.com/library/windows/desktop/ff471525) tiling and divides the x/y dimensions by 4 each and adds 16 layers of depth.</span></span> <span data-ttu-id="6aafc-108">最初の平面 (最初の 16 レイヤーの深度を定義するタイルの 2D 平面) のすべてのタイルが、後続の平面の前に表示されます。</span><span class="sxs-lookup"><span data-stu-id="6aafc-108">All the tiles for the first plane (2D plane of tiles defining the first 16 layers of depth) appear before the subsequent planes.</span></span>

<span data-ttu-id="6aafc-109">**注:** ストリーミング リソースでの[**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562)のサポートがない、ストリーミング リソースの最初の実装で公開されているが、今後のリリースでのサポートに備えて必要なタイル形状はここに記載されています。</span><span class="sxs-lookup"><span data-stu-id="6aafc-109">**Note**[**Texture3D**](https://msdn.microsoft.com/library/windows/desktop/ff471562) support in streaming resources isn't exposed in the initial implementation of streaming resources, but the desired tile shapes are listed here for possible support in a future release.</span></span>

 

| <span data-ttu-id="6aafc-110">ビット/ピクセル (1 サンプル/ピクセル)</span><span class="sxs-lookup"><span data-stu-id="6aafc-110">Bits/Pixel (1 sample/pixel)</span></span> | <span data-ttu-id="6aafc-111">タイルの寸法 (ピクセル、W x H x D)</span><span class="sxs-lookup"><span data-stu-id="6aafc-111">Tile Dimensions (Pixels, WxHxD)</span></span> |
|-----------------------------|---------------------------------|
| <span data-ttu-id="6aafc-112">8</span><span class="sxs-lookup"><span data-stu-id="6aafc-112">8</span></span>                           | <span data-ttu-id="6aafc-113">64 x 32 x 32</span><span class="sxs-lookup"><span data-stu-id="6aafc-113">64x32x32</span></span>                        |
| <span data-ttu-id="6aafc-114">16</span><span class="sxs-lookup"><span data-stu-id="6aafc-114">16</span></span>                          | <span data-ttu-id="6aafc-115">32 x 32 x 32</span><span class="sxs-lookup"><span data-stu-id="6aafc-115">32x32x32</span></span>                        |
| <span data-ttu-id="6aafc-116">32</span><span class="sxs-lookup"><span data-stu-id="6aafc-116">32</span></span>                          | <span data-ttu-id="6aafc-117">32 x 32 x 16</span><span class="sxs-lookup"><span data-stu-id="6aafc-117">32x32x16</span></span>                        |
| <span data-ttu-id="6aafc-118">64</span><span class="sxs-lookup"><span data-stu-id="6aafc-118">64</span></span>                          | <span data-ttu-id="6aafc-119">32 x 16 x 16</span><span class="sxs-lookup"><span data-stu-id="6aafc-119">32x16x16</span></span>                        |
| <span data-ttu-id="6aafc-120">128</span><span class="sxs-lookup"><span data-stu-id="6aafc-120">128</span></span>                         | <span data-ttu-id="6aafc-121">16 x 16 x 16</span><span class="sxs-lookup"><span data-stu-id="6aafc-121">16x16x16</span></span>                        |
| <span data-ttu-id="6aafc-122">BC1、4</span><span class="sxs-lookup"><span data-stu-id="6aafc-122">BC1,4</span></span>                       | <span data-ttu-id="6aafc-123">128 x 64 x 16</span><span class="sxs-lookup"><span data-stu-id="6aafc-123">128x64x16</span></span>                       |
| <span data-ttu-id="6aafc-124">BC2、3、5、6、7</span><span class="sxs-lookup"><span data-stu-id="6aafc-124">BC2,3,5,6,7</span></span>                 | <span data-ttu-id="6aafc-125">64 x 64 x 16</span><span class="sxs-lookup"><span data-stu-id="6aafc-125">64x64x16</span></span>                        |

 

<span data-ttu-id="6aafc-126">ストリーミング リソースでサポートされない形式のビット数は、96 bpp 形式、ビデオ形式、DXGI\_FORMAT\_R1\_UNORM、DXGI\_FORMAT\_R8G8\_B8G8\_UNORM、および DXGI\_FORMAT\_R8R8\_G8B8\_UNORM です。</span><span class="sxs-lookup"><span data-stu-id="6aafc-126">Format bit counts not supported with streaming resources are 96 bpp formats, video formats, DXGI\_FORMAT\_R1\_UNORM, DXGI\_FORMAT\_R8G8\_B8G8\_UNORM, and DXGI\_FORMAT\_R8R8\_G8B8\_UNORM.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="6aafc-127"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="6aafc-127"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="6aafc-128">ストリーミング リソースの領域をタイル表示する方法</span><span class="sxs-lookup"><span data-stu-id="6aafc-128">How a streaming resource's area is tiled</span></span>](how-a-streaming-resource-s-area-is-tiled.md)

 

 




