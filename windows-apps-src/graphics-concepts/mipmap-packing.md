---
title: ミップマップのパッキング
description: ストリーミング リソースの大きさ、形式、ミップマップの数、配列スライスに応じて、一定の数のミップ (配列スライスごとに) を一定の数のタイルにパッキングできます。
ms.assetid: 906C3CAC-4E84-4947-B508-06788551BE85
keywords:
- ミップマップのパッキング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ec3d091d7cc5aca82aeef9a3e7f29a8d363705a3
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7571824"
---
# <a name="mipmap-packing"></a><span data-ttu-id="6ea2c-104">ミップマップのパッキング</span><span class="sxs-lookup"><span data-stu-id="6ea2c-104">Mipmap packing</span></span>


<span data-ttu-id="6ea2c-105">ストリーミング リソースの大きさ、形式、ミップマップの数、配列スライスに応じて、一定の数のミップ (配列スライスごとに) を一定の数のタイルにパッキングできます。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-105">Some number of mips (per array slice) can be packed into some number of tiles, depending on a streaming resource's dimensions, format, number of mipmaps, and array slices.</span></span>

<span data-ttu-id="6ea2c-106">ストリーミング リソース サポートの[階層](streaming-resources-features-tiers.md)によっては、一定の大きさのミップマップは標準タイルの形状に従わないため、アプリケーションにとって不透明な方法ですべてまとめてパッキングされると考えられます。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-106">Depending on the [tier](streaming-resources-features-tiers.md) of streaming resources support, mipmaps with certain dimensions don't follow the standard tile shapes and are considered to all be packed together with one another in a manner that is opaque to the application.</span></span> <span data-ttu-id="6ea2c-107">サポートの階層が高い方が、標準タイルの形状に収まるサーフェスの大きさの種類を広く保証します (したがって、アプリケーションが個別にマッピングできます)。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-107">Higher tiers of support have broader guarantees about what types of surface dimensions fit in the standard tile shapes (and can therefore be individually mapped by applications).</span></span>

<span data-ttu-id="6ea2c-108">(ストリーミング リソースの大きさ、形式、ミップマップの数、配列スライスを考えると) 実装間で異なる可能性があるのは、N 個のタイルにパッキングできるミップの数 M (配列スライスごと) です。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-108">What can vary between implementations is that—given a streaming resource's dimensions, format, number of mipmaps, and array slices—some number M of mips (per array slice) can be packed into some number N tiles.</span></span> <span data-ttu-id="6ea2c-109">デバイスのリソース タイル情報を取得すると、ドライバーが (ハードウェア ベンダーごとに変化しない標準値である、サーフェスについての他の詳細と共に) M と N の値をアプリケーションに報告します。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-109">When you get the resource tiling information for a device, the driver reports to the application what M and N are (among other details about the surface that are standard and don't vary by hardware vendor).</span></span> <span data-ttu-id="6ea2c-110">マッピングされたミップのタイル セットは引き続き 64 KB であるため、タイル プール内の異なる位置に別個にマッピングできます。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-110">The set of tiles for the packed mips are still 64KB and can be individually mapped into disparate locations in a tile pool.</span></span>

<span data-ttu-id="6ea2c-111">ただし、タイルのピクセルの形状とミップマップがタイル セットにどのように収まるかは、ハードウェア ベンダーによって異なるため、複雑すぎて説明することができません。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-111">But the pixel shape of the tiles and how the mipmaps fit across the set of tiles is specific to a hardware vendor and too complex to expose.</span></span> <span data-ttu-id="6ea2c-112">したがって、アプリケーションはパッキング対象として指定されたすべてのタイルを一度にマッピングするか、何もマッピングしないかのどちらかの処理を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-112">So, applications are required to either map all of the tiles that are designated as packed, or none of them, at a time.</span></span> <span data-ttu-id="6ea2c-113">それ以外の場合のストリーミング リソースへのアクセス動作は定義されていません。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-113">Otherwise, the behavior for accessing the streaming resource is undefined.</span></span>

<span data-ttu-id="6ea2c-114">配列になったサーフェスの場合、パッキングされたミップのセットと、それらのミップを格納するマッピングされたタイルの数 (前述の M と N) は、配列スライスごとに別個に適用されます。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-114">For arrayed surfaces, the set of packed mips and the number of packed tiles storing those mips (M and N described preceding) applies individually for each array slice.</span></span>

<span data-ttu-id="6ea2c-115">タイルをコピーする専用の API は、パッキングされたミップにアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-115">Dedicated APIs for copying tiles can't access packed mips.</span></span> <span data-ttu-id="6ea2c-116">パッキングされたミップとの間でデータをコピーする必要があるアプリケーションは、サーフェスにコピーおよびレンダリングするための非ストリーミング リソース固有の API をすべて使ってコピーを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="6ea2c-116">Applications that want to copy data to and from packed mips can do so using all the non-streaming resource-specific APIs for copying and rendering to surfaces.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="6ea2c-117"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="6ea2c-117"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="6ea2c-118">ストリーミング リソースの領域をタイル表示する方法</span><span class="sxs-lookup"><span data-stu-id="6ea2c-118">How a streaming resource's area is tiled</span></span>](how-a-streaming-resource-s-area-is-tiled.md)

 

 




