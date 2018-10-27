---
title: 圧縮テクスチャ形式
description: このセクションでは、圧縮テクスチャ形式の内部構造について説明します。
ms.assetid: 24D17B9F-8CA7-4006-9E0F-178C6B3CAEC9
keywords:
- 圧縮テクスチャ形式
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 4dd0ff85198107263fba458bd97c0323a7049d20
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/27/2018
ms.locfileid: "5695501"
---
# <a name="compressed-texture-formats"></a><span data-ttu-id="e80bd-104">圧縮テクスチャ形式</span><span class="sxs-lookup"><span data-stu-id="e80bd-104">Compressed texture formats</span></span>


<span data-ttu-id="e80bd-105">このセクションでは、圧縮テクスチャ形式の内部構造について説明します。</span><span class="sxs-lookup"><span data-stu-id="e80bd-105">This section contains information about the internal organization of compressed texture formats.</span></span> <span data-ttu-id="e80bd-106">圧縮形式への変換、および圧縮形式からの変換には Direct3D 関数を使用できるため、圧縮テクスチャの使用にこれらの詳細は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="e80bd-106">You do not need these details to use compressed textures, because you can use Direct3D functions for conversion to and from compressed formats.</span></span> <span data-ttu-id="e80bd-107">ただし、圧縮サーフェス データを直接操作する場合は、この情報が役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-107">However, this information is useful if you want to operate on compressed surface data directly.</span></span>

<span data-ttu-id="e80bd-108">Direct3D では、テクスチャ マップを 4 x 4 のテクセル ブロックに分割する圧縮形式が使用されます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-108">Direct3D uses a compression format that divides texture maps into 4x4 texel blocks.</span></span> <span data-ttu-id="e80bd-109">テクスチャに透明度がない場合、つまりテクスチャが不透明な場合、または透明度が 1 ビット アルファで指定されている場合、8 バイトのブロックでテクスチャ マップ ブロックが表現されます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-109">If the texture contains no transparency - is opaque - or if the transparency is specified by a 1-bit alpha, an 8-byte block represents the texture map block.</span></span> <span data-ttu-id="e80bd-110">テクスチャ マップに透明なテクセルが含まれており、アルファ チャネルが使用されている場合は、16 バイトのブロックでテクスチャ マップ ブロックが表されます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-110">If the texture map does contain transparent texels, using an alpha channel, a 16-byte block represents it.</span></span>

<span data-ttu-id="e80bd-111">単一のテクスチャはすべて、16 テクセルのグループごとにデータを 64 ビットまたは 128 ビットで格納するように指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e80bd-111">Any single texture must specify that its data is stored as 64 or 128 bits per group of 16 texels.</span></span> <span data-ttu-id="e80bd-112">64 ビットのブロック、つまり BC1 形式をテクスチャに使用する場合、同一のテクスチャ内にブロック単位で不透明の形式と 1 ビット アルファの形式を混在させることができます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-112">If 64-bit blocks - that is, format BC1 - are used for the texture, it is possible to mix the opaque and 1-bit alpha formats on a per-block basis within the same texture.</span></span> <span data-ttu-id="e80bd-113">つまり、color\_0 と color\_1 の符号なし整数の絶対値の比較が、16 テクセルのブロックごとに独立して実行されます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-113">In other words, the comparison of the unsigned integer magnitude of color\_0 and color\_1 is performed uniquely for each block of 16 texels.</span></span>

<span data-ttu-id="e80bd-114">128 ビット ブロックを使用する場合、テクスチャ全体にアルファ チャネルを明示的モード (BC2 形式) または補間モード (BC3 形式) で指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e80bd-114">When 128-bit blocks are used, the alpha channel must be specified in either explicit (format BC2) or interpolated mode (format BC3) for the entire texture.</span></span> <span data-ttu-id="e80bd-115">カラーの場合と同様に、補間モードを選択すると、8 つの補間アルファまたは 6 つの補間アルファのモードをブロック単位で使用することができます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-115">As with color, when interpolated mode is selected, either eight interpolated alphas or six interpolated alphas mode can be used on a block-by-block basis.</span></span> <span data-ttu-id="e80bd-116">ここでも、alpha\_0 と alpha\_1 の絶対値の比較がブロックごとに独立して実行されます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-116">Again the magnitude comparison of alpha\_0 and alpha\_1 is done uniquely on a block-by-block basis.</span></span>

<span data-ttu-id="e80bd-117">BCn 形式のピッチは、ブロック単位ではなくバイト単位で測定されます。</span><span class="sxs-lookup"><span data-stu-id="e80bd-117">The pitch for BCn formats is measured in bytes (not blocks).</span></span> <span data-ttu-id="e80bd-118">たとえば、幅が 16 である場合、1 ピッチは 4 ブロックになります (BC1 の場合は 4\*8、BC2 または BC3 の場合は 4\*16)。</span><span class="sxs-lookup"><span data-stu-id="e80bd-118">For example, if you have a width of 16, then you will have a pitch of four blocks (4\*8 for BC1, 4\*16 for BC2 or BC3).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="e80bd-119"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="e80bd-119"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="e80bd-120">圧縮テクスチャ リソース</span><span class="sxs-lookup"><span data-stu-id="e80bd-120">Compressed texture resources</span></span>](compressed-texture-resources.md)

 

 




