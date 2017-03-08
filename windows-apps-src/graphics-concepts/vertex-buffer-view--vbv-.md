---
title: "頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)"
description: "頂点バッファーには、頂点のリストのデータが保持されます。"
ms.assetid: 695115D2-9DA0-41F2-9416-33BFAB698129
keywords:
- "頂点バッファー ビュー (VBV)"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: f32684b167b7582a646a7cfd47c606a9f382a4c4
ms.lasthandoff: 02/07/2017

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

 

 





