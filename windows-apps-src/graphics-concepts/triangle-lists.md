---
title: トライアングル リスト
description: トライアングル リストとは、独立した三角形のリストです。 これらの独立した三角形は、距離が近い場合もそうでない場合もあります。 トライアングル リストには 3 つ以上の頂点が必須であり、頂点の総数は 3 で割り切れなければなりません。
ms.assetid: BC50D532-9E9C-4AAE-B466-9E8C4AD1862A
keywords:
- トライアングル リスト
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: aae797db890c6bee141c3b4a79a6a85a55a6b512
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8210766"
---
# <a name="triangle-lists"></a>トライアングル リスト


トライアングル リストとは、独立した三角形のリストです。 これらの独立した三角形は、距離が近い場合もそうでない場合もあります。 トライアングル リストには 3 つ以上の頂点が必須であり、頂点の総数は 3 で割り切れなければなりません。

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例


接合されていない部分から成るオブジェクトを作成するには、トライアングル リストを使います。 たとえば、3D ゲームでフォース フィールドの壁を作成する 1 つの方法として、連結していない小さい三角形を大量に含むリストを指定する方法があります。 その後、発光するように見えるマテリアルとテクスチャをトライアングル リストに適用します。 これにより、壁を構成する各三角形が輝いているように表示されます。 各三角形の隙間からは、壁の背後にあるシーンが部分的に見えるようになります。これは、プレイヤーがフォース フィールドを眺めるときに予想する光景です。

トライアングル リストは、鋭角を持ち、グーロー シェーディングで影を適用するプリミティブを作成する場合にも役立ちます。 「[面と頂点の法線ベクトル](face-and-vertex-normal-vectors.md)」をご覧ください。

次の図は、レンダリングされたトライアングル リストを示しています。

![レンダリングされたトライアングル リストの図](images/trilist.png)

次のコードは、このトライアングル リストの頂点の作成方法を示しています。

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

次のコード例は、このトライアングル リストを Direct3D でレンダリングする方法を示しています。

```
//
// It is assumed that d3dDevice is a valid
// pointer to a device interface.
//
d3dDevice->DrawPrimitive( D3DPT_TRIANGLELIST, 0, 2 );
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[プリミティブ](primitives.md)

 

 




