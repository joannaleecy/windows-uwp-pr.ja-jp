---
title: 反射ライト マップ
description: 光源から照射されると、反射率の高いマテリアルを使用している光沢のあるオブジェクトには反射光が適用されます。
ms.assetid: 9B3AC5EC-DDAA-4671-BC81-0E3C79D87A81
keywords:
- 反射ライト マップ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7d88989be04704395c056f1bae058e2aefd1a2a4
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7707590"
---
# <a name="specular-light-maps"></a><span data-ttu-id="e458e-104">反射ライト マップ</span><span class="sxs-lookup"><span data-stu-id="e458e-104">Specular light maps</span></span>


<span data-ttu-id="e458e-105">光源から照射されると、反射率の高いマテリアルを使用している光沢のあるオブジェクトには反射光が適用されます。</span><span class="sxs-lookup"><span data-stu-id="e458e-105">When illuminated by a light source, shiny objects that use highly reflective materials receive specular highlights.</span></span> <span data-ttu-id="e458e-106">照明モジュールによって生成された鏡面ハイライトを使用するのではなく、反射ライト マップをプリミティブに適用した方が、より正確なハイライトが得られる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e458e-106">Sometimes you can get more accurate highlights by applying specular light maps to primitives, rather than using the specular highlights produced by the lighting module.</span></span>

<span data-ttu-id="e458e-107">反射光のマッピングを実行するには、プリミティブのテクスチャに反射光マップを追加し、RGB ライト マップを調整 (RGB ライト マップによる結果を乗算) します。</span><span class="sxs-lookup"><span data-stu-id="e458e-107">To perform specular light mapping, add the specular light map to the primitive's texture, then modulate (multiply the result by) the RGB light map.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="e458e-108"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="e458e-108"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="e458e-109">テクスチャでのライト マッピング</span><span class="sxs-lookup"><span data-stu-id="e458e-109">Light mapping with textures</span></span>](light-mapping-with-textures.md)

 

 




