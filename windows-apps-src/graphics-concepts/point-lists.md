---
title: "ポイント リスト"
description: "ポイント リストとは、独立した点としてレンダリングされる頂点の集合を指します。 アプリケーションは、星空の 3D シーンや、多角形の表面の点線に、ポイント リストを使うことができます。"
ms.assetid: 332954AE-019F-4A91-B773-E3A7C92F3297
keywords: "ポイント リスト"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: d5f2ee1c9a42a0d2f380f4f9a98c204088b1379a
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="point-lists"></a>ポイント リスト


ポイント リストとは、独立した点としてレンダリングされる頂点の集合を指します。 アプリケーションは、星空の 3D シーンや、多角形の表面の点線に、ポイント リストを使うことができます。

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例


次の図は、レンダリングされたポイント リストを示しています。

![ポイント リストの図](images/pointlst.png)

アプリケーションでは、ポイント リストにマテリアルやテクスチャを適用できます。 マテリアルやテクスチャの色は描画された点にのみ表示され、点どうしの間には表示されません。

次のコードは、このポイント リストの頂点の作成方法を示しています。

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

次のコード例は、このポイント リストを Direct3D でレンダリングする方法を示しています。

```
//
// It is assumed that d3dDevice is a valid
// pointer to an IDirect3DDevice interface.
//
d3dDevice->DrawPrimitive( D3DPT_POINTLIST, 0, 6 );
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[プリミティブ](primitives.md)

 

 




