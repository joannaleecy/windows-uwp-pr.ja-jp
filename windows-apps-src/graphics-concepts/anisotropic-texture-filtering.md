---
title: 異方性テクスチャ フィルタ リング
description: サーフェスがスクリーンの平面に対して角度をなして配置されている 3D オブジェクトのテクセルに見られるゆがみを異方性と呼びます。 異方性プリミティブのピクセルをテクセルにマッピングすると、形状がゆがみます。
ms.assetid: 58923809-EF76-4C16-BCE7-922A66425F83
keywords:
- 異方性テクスチャ フィルタ リング
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: efac0a9454f750d4b9040577b613496d29a30bc3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57591197"
---
# <a name="anisotropic-texture-filtering"></a><span data-ttu-id="f1ffd-105">異方性テクスチャ フィルタ リング</span><span class="sxs-lookup"><span data-stu-id="f1ffd-105">Anisotropic texture filtering</span></span>


<span data-ttu-id="f1ffd-106">サーフェスがスクリーンの平面に対して角度をなして配置されている 3D オブジェクトのテクセルに見られるゆがみを*異方性*と呼びます。</span><span class="sxs-lookup"><span data-stu-id="f1ffd-106">*Anisotropy* is the distortion visible in the texels of a 3D object whose surface is oriented at an angle with respect to the plane of the screen.</span></span> <span data-ttu-id="f1ffd-107">異方性プリミティブのピクセルをテクセルにマッピングすると、形状がゆがみます。</span><span class="sxs-lookup"><span data-stu-id="f1ffd-107">When a pixel from an anisotropic primitive is mapped to texels, its shape is distorted.</span></span> <span data-ttu-id="f1ffd-108">Direct3D では、テクスチャ空間に逆マッピングされたスクリーン ピクセルの伸長度 (長さを幅で割ったもの) としてピクセルの異方性を測定します。</span><span class="sxs-lookup"><span data-stu-id="f1ffd-108">Direct3D measures the anisotropy of a pixel as the elongation - that is, length divided by width - of a screen pixel that is inverse-mapped into texture space.</span></span>

<span data-ttu-id="f1ffd-109">異方性テクスチャ フィルタリングを線形テクスチャ フィルタリングまたはミップマップ テクスチャ フィルタリングと共に使用することで、レンダリング結果を向上させることができます。</span><span class="sxs-lookup"><span data-stu-id="f1ffd-109">You can use anisotropic texture filtering in conjunction with linear texture filtering or mipmap texture filtering to improve rendering results.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="f1ffd-110"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="f1ffd-110"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="f1ffd-111">テクスチャ フィルタ リング</span><span class="sxs-lookup"><span data-stu-id="f1ffd-111">Texture filtering</span></span>](texture-filtering.md)

 

 




