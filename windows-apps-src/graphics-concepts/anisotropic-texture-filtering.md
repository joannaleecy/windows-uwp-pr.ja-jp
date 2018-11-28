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
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7971604"
---
# <a name="anisotropic-texture-filtering"></a>異方性テクスチャ フィルタ リング


サーフェスがスクリーンの平面に対して角度をなして配置されている 3D オブジェクトのテクセルに見られるゆがみを*異方性*と呼びます。 異方性プリミティブのピクセルをテクセルにマッピングすると、形状がゆがみます。 Direct3D では、テクスチャ空間に逆マッピングされたスクリーン ピクセルの伸長度 (長さを幅で割ったもの) としてピクセルの異方性を測定します。

異方性テクスチャ フィルタリングを線形テクスチャ フィルタリングまたはミップマップ テクスチャ フィルタリングと共に使用することで、レンダリング結果を向上させることができます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャ フィルタリング](texture-filtering.md)

 

 




