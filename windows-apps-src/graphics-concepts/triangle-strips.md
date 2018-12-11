---
title: トライアングル ストリップ
description: トライアングル ストリップとは、接続された一連の三角形を指します。 三角形どうしがつながっているため、アプリケーションでは、各三角形の 3 つの頂点すべてを繰り返し指定する必要がありません。
ms.assetid: BACC74C5-14E5-4ECC-9139-C2FD1808DB82
keywords:
- トライアングル ストリップ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9a420ed5ed8f498eb9c900cbacb1b766c4a01214
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8881030"
---
# <a name="triangle-strips"></a>トライアングル ストリップ


トライアングル ストリップとは、接続された一連の三角形を指します。 三角形どうしがつながっているため、アプリケーションでは、各三角形の 3 つの頂点すべてを繰り返し指定する必要がありません。 たとえば、次のトライアングル ストリップの定義に必要な頂点は 7 個だけです。

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例


![7 個の頂点を持つトライアングル ストリップの図](images/tristrip.png)

システムは、頂点 v1、v2、v3 を使って最初の三角形を描画し、v2、v4、v3 を使って 2 つ目の三角形を描画します。さらに、v3、v4、v5 を使って 3 つ目を、v4、v6、v5 を使って 4 つ目を描画し、以降も同様に続きます。 2 つ目と 4 つ目の三角形の頂点の順序は番号順でないことに注意してください。これは、すべての三角形を時計回りの方向に描画する必要があるためです。

3D シーンのほとんどのオブジェクトは、トライアングル ストリップで構成されます。 これは、トライアングル ストリップを使うと、メモリと処理時間を効率的に利用する形で複雑なオブジェクトを指定できるためです。

次の図は、レンダリングされたトライアングル ストリップを示しています。

![レンダリングされたトライアングル ストリップの図](images/tstrip2.png)

次のコードは、このトライアングル ストリップの頂点を作成する方法を示しています。

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

次のコード例は、このトライアングル ストリップを Direct3D でレンダリングする方法を示しています。

```
//
// It is assumed that d3dDevice is a valid
// pointer to a device interface.
//
d3dDevice->DrawPrimitive( D3DPT_TRIANGLESTRIP, 0, 4);
```

## <a name="span-idpolygonsspanspan-idpolygonsspanspan-idpolygonsspanpolygons"></a><span id="Polygons"></span><span id="polygons"></span><span id="POLYGONS"></span>ポリゴン


多くの場合、トライアングル ストリップはポリゴンの構築に使われます。 ポリゴンとは、3 つ以上の頂点を結んで描かれる閉じた 3D 図形です。 最も単純なポリゴンは三角形です。 三角形の 3 つの頂点はすべて同一平面にあることが保障されるため、Microsoft Direct3D では、ほとんどのポリゴンが三角形を使って構成されます。 非平面の頂点のレンダリングは効率的ではありません。 複数の三角形を結合することで、大きい複雑なポリゴンやメッシュを形成できます。

次の図は立方体を示しています。 立方体の各面は 2 つの三角形で形成されます。 これらの三角形のセット全体が、1 つの立方体プリミティブを形成します。 プリミティブのサーフェスにテクスチャを適用すると、単一の固形のように表示できます。 詳しくは、「[テクスチャ](textures.md)」をご覧ください。

![各面が 2 つの三角形で形成された立方体の図](images/cube3d.png)

三角形を使うと、サーフェスが滑らかな曲面に見えるプリミティブを作成することもできます。 次の図は、三角形で球体をシミュレートする方法を示しています。 マテリアルの適用後にレンダリングすると、曲面のように見える球体を表示できます。

![三角形を使ってシミュレートされた球体の図](images/sphere3d.png)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[プリミティブ](primitives.md)

 

 




