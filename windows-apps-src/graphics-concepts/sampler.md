---
title: サンプラー
description: テクスチャまたはその他のリソースから入力値を読み取るプロセスをサンプリングと呼びます。 \ 0034;サンプラー\ 0034; は、リソースから読み込まれるオブジェクトです。
ms.assetid: 7ECE13BB-9FC5-44A3-B1B2-2FE163F1D627
keywords:
- サンプラー
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e80e160e1225e510ab95f52cbd9f21049c890457
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8942473"
---
# <a name="sampler"></a><span data-ttu-id="c05c0-105">サンプラー</span><span class="sxs-lookup"><span data-stu-id="c05c0-105">Sampler</span></span>


<span data-ttu-id="c05c0-106">テクスチャまたはその他のリソースから入力値を読み取るプロセスをサンプリングと呼びます。</span><span class="sxs-lookup"><span data-stu-id="c05c0-106">Sampling is the process of reading input values from a texture, or other resource.</span></span> <span data-ttu-id="c05c0-107">”サンプラー” は、リソースから読み込まれるオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="c05c0-107">A "sampler" is any object that reads from resources.</span></span>

<span data-ttu-id="c05c0-108">テクスチャからのサンプリングや画面領域へのレンダリングを行うと、多くの問題やアーティファクトが発生します。</span><span class="sxs-lookup"><span data-stu-id="c05c0-108">There are many issues and artifacts from sampling from a texture and rendering to a screen area.</span></span> <span data-ttu-id="c05c0-109">たとえば、レンダリングする領域が 50 x 50 ピクセルで、テクスチャが 16 x 16 ピクセルまたは 256 x 256 ピクセルの場合、テクスチャをかなり拡大または縮小する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c05c0-109">For example, if the area to be rendered to is 50 by 50 pixels, and the texture is 16 by 16 pixels or 256 by 256 pixels, then some considerable stretching or shrinking of the texture needs to be applied.</span></span> <span data-ttu-id="c05c0-110">このサイズの不一致が原因で不要なアーティファクトが発生します。そこで、そのようなアーティファクトを軽減するために、フィルタリング手法が使用されます。</span><span class="sxs-lookup"><span data-stu-id="c05c0-110">Because this mismatch in size leads to unwelcome artifacts, filtering techniques are used to mitigate these artifacts.</span></span> <span data-ttu-id="c05c0-111">小さいテクスチャを大きいレンダリング領域に使用する場合によく使用されるフィルタリング手法の 1 つは、"バイリニア" フィルタリングです。</span><span class="sxs-lookup"><span data-stu-id="c05c0-111">A common filtering approach to using small textures for larger rendering areas is "bilinear" filtering.</span></span>

<span data-ttu-id="c05c0-112">レンダリング領域がビューに対して鋭角の場合、別の問題が発生します (for example, a 256 by 256 texture being rendered to a area 100 pixels wide but only 5 pixels deep because of the viewing angle).</span><span class="sxs-lookup"><span data-stu-id="c05c0-112">Another issue occurs when the area being rendered to is at a very oblique angle to the view (for example, a 256 by 256 texture being rendered to a area 100 pixels wide but only 5 pixels deep because of the viewing angle).</span></span> <span data-ttu-id="c05c0-113">この場合は、しばしば "異方性" フィルタリングが適用されます。</span><span class="sxs-lookup"><span data-stu-id="c05c0-113">In this case "anisotropic" filtering is often applied.</span></span> <span data-ttu-id="c05c0-114">異方性フィルタリングでは、適度なぼかしでエイリアシング効果を取り除けるため、バイリニア フィルタリングよりも画質は優れていますが、計算の負荷は高くなります。</span><span class="sxs-lookup"><span data-stu-id="c05c0-114">Anisotropic filtering provides better image quality than bilinear filtering, as it removes aliasing effects without excessive blurring, but is more computationally expensive.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="c05c0-115"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="c05c0-115"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="c05c0-116">ビュー</span><span class="sxs-lookup"><span data-stu-id="c05c0-116">Views</span></span>](views.md)

 

 




