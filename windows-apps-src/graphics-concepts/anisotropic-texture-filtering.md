---
title: "異方性テクスチャ フィルタ リング"
description: "サーフェスがスクリーンの平面に対して角度をなして配置されている 3D オブジェクトのテクセルに見られるゆがみを異方性と呼びます。 異方性プリミティブのピクセルをテクセルにマッピングすると、形状がゆがみます。"
ms.assetid: 58923809-EF76-4C16-BCE7-922A66425F83
keywords:
- "異方性テクスチャ フィルタ リング"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 4946281fd754f267b37ee0a069d5101f8169deff
ms.lasthandoff: 02/07/2017

---

# <a name="anisotropic-texture-filtering"></a>異方性テクスチャ フィルタ リング


サーフェスがスクリーンの平面に対して角度をなして配置されている 3D オブジェクトのテクセルに見られるゆがみを*異方性*と呼びます。 異方性プリミティブのピクセルをテクセルにマッピングすると、形状がゆがみます。 Direct3D では、テクスチャ空間に逆マッピングされたスクリーン ピクセルの伸長度 (長さを幅で割ったもの) としてピクセルの異方性を測定します。

異方性テクスチャ フィルタリングを線形テクスチャ フィルタリングまたはミップマップ テクスチャ フィルタリングと共に使用することで、レンダリング結果を向上させることができます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連項目


[テクスチャ フィルタリング](texture-filtering.md)

 

 





