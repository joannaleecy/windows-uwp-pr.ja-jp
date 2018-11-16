---
title: 頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)
description: 頂点バッファーには、頂点のリストのデータが保持されます。
ms.assetid: 695115D2-9DA0-41F2-9416-33BFAB698129
keywords:
- 頂点バッファー ビュー (VBV)
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7956c7a03256da04e98a5b8f9a33951d7e0216d3
ms.sourcegitcommit: 9f8010fe67bb3372db1840de9f0be36097ed6258
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7118816"
---
# <a name="vertex-buffer-view-vbv-and-index-buffer-view-ibv"></a>頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)


頂点バッファーには、頂点のリストのデータが保持されます。 各頂点のデータには、位置、色、法線ベクトル、テクスチャ座標などを含めることができます。 インデックス バッファーには、頂点バッファーへの整数インデックス (オフセット) が保持されます。インデックス バッファーは、頂点の完全なリストのサブセットから成るオブジェクトを定義してレンダリングするために使われます。

多くの場合、単独の頂点の定義はアプリケーションが独自に決定できます。たとえば、次のように定義することができます。

``` syntax
struct CUSTOMVERTEX { 
        FLOAT x, y, z;      // The position
        FLOAT nx, ny, nz;   // The normal
        DWORD color;        // RGBA color
        FLOAT tu, tv;       // The texture coordinates. 
}; 
```

その後、CUSTOMVERTEX の定義は、頂点バッファーの作成時にグラフィックス ドライバーに渡されます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ビュー](views.md)

 

 




