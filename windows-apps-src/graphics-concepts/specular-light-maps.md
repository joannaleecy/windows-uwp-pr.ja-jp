---
title: 反射ライト マップ
description: 光源から照射されると、反射率の高いマテリアルを使用している光沢のあるオブジェクトには反射光が適用されます。
ms.assetid: 9B3AC5EC-DDAA-4671-BC81-0E3C79D87A81
keywords:
- 反射ライト マップ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 6bd9db0afa914ef7a56dbd55c938129b86a43743
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5755323"
---
# <a name="specular-light-maps"></a><span data-ttu-id="70204-104">反射ライト マップ</span><span class="sxs-lookup"><span data-stu-id="70204-104">Specular light maps</span></span>


<span data-ttu-id="70204-105">光源から照射されると、反射率の高いマテリアルを使用している光沢のあるオブジェクトには反射光が適用されます。</span><span class="sxs-lookup"><span data-stu-id="70204-105">When illuminated by a light source, shiny objects that use highly reflective materials receive specular highlights.</span></span> <span data-ttu-id="70204-106">照明モジュールによって生成された鏡面ハイライトを使用するのではなく、反射ライト マップをプリミティブに適用した方が、より正確なハイライトが得られる場合があります。</span><span class="sxs-lookup"><span data-stu-id="70204-106">Sometimes you can get more accurate highlights by applying specular light maps to primitives, rather than using the specular highlights produced by the lighting module.</span></span>

<span data-ttu-id="70204-107">反射光のマッピングを実行するには、プリミティブのテクスチャに反射光マップを追加し、RGB ライト マップを調整 (RGB ライト マップによる結果を乗算) します。</span><span class="sxs-lookup"><span data-stu-id="70204-107">To perform specular light mapping, add the specular light map to the primitive's texture, then modulate (multiply the result by) the RGB light map.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="70204-108"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="70204-108"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="70204-109">テクスチャでのライト マッピング</span><span class="sxs-lookup"><span data-stu-id="70204-109">Light mapping with textures</span></span>](light-mapping-with-textures.md)

 

 




