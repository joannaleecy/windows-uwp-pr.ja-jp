---
title: ライン ストリップ
description: ライン ストリップとは、接続された行セグメントから構成されるプリミティブを指します。 アプリケーションは、ライン ストリップを使用して、閉じられていない多角形を作成することができます。 閉じられた多角形とは、最後の頂点が行セグメントによって最初の頂点に接続されている多角形を指します。
ms.assetid: 6E8C58E1-B463-44FD-A69F-81CCBF25D856
keywords:
- ライン ストリップ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a5fbf4d7fd4f82e6bc44795d64e6b98b6c732f49
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5642437"
---
# <a name="line-strips"></a>ライン ストリップ


ライン ストリップとは、接続された行セグメントから構成されるプリミティブを指します。 アプリケーションは、ライン ストリップを使用して、閉じられていない多角形を作成することができます。 閉じられた多角形とは、最後の頂点が行セグメントによって最初の頂点に接続されている多角形を指します。 アプリケーションがライン ストリップに基づいて多角形を作成する場合、頂点が同一平面上にあることは保証されません。

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例


次の図は、レンダリングされたライン ストリップを示しています。

![ライン ストリップの図](images/linstrip.gif)

次のコードは、このライン ストリップの頂点の作成方法を示しています。

```
struct CUSTOMVERTEX
{
    float x,y,z;
};

CUSTOMVERTEX Vertices[] = 
{
    {-5.0, -5.0, 0.0},
    { 0.0,  5.0, 0.0},
    { 5.0, -5.0, 0.0},
    {10.0,  5.0, 0.0},
    {15.0, -5.0, 0.0},
    {20.0,  5.0, 0.0}
};
```

次のコード例は、ライン ストリップを Direct3D でレンダリングする方法を示しています。

```
//
// It is assumed that d3dDevice is a valid
// pointer to an IDirect3DDevice interface.
//
d3dDevice->DrawPrimitive( D3DPT_LINESTRIP, 0, 5 );
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[プリミティブ](primitives.md)

 

 




