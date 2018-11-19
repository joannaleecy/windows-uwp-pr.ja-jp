---
title: プリミティブ
description: 3D プリミティブは、単一の 3D エンティティを形成する頂点の集合です。
ms.assetid: A1FE6F49-B0D4-4665-90E1-40AD98E668B1
keywords:
- プリミティブ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 349d4aa4fbf35bd7dccbd48b0251f5bb9e90a779
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7287362"
---
# <a name="primitives"></a>プリミティブ


3D *プリミティブ*は、単一の 3D エンティティを形成する頂点の集合です。

## <a name="span-idin-this-sectionspanin-this-section"></a><span id="in-this-section"></span>このセクションの内容


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="point-lists.md">ポイント リスト</a></p></td>
<td align="left"><p>ポイント リストとは、独立した点としてレンダリングされる頂点の集合を指します。 アプリケーションは、星空の 3D シーンや、多角形の表面の点線に、ポイント リストを使うことができます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="line-lists.md">線リスト</a></p></td>
<td align="left"><p>線リストとは、独立した直線セグメントの一覧を指します。 線リストは、3D シーンに氷雨や豪雨を追加する場合などに便利です。 アプリケーションは、頂点の配列を入力することで行リストを作成します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="line-strips.md">ライン ストリップ</a></p></td>
<td align="left"><p>ライン ストリップとは、接続された行セグメントから構成されるプリミティブを指します。 アプリケーションは、ライン ストリップを使用して、閉じられていない多角形を作成することができます。 閉じられた多角形とは、最後の頂点が行セグメントによって最初の頂点に接続されている多角形を指します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="triangle-lists.md">トライアングル リスト</a></p></td>
<td align="left"><p>トライアングル リストとは、独立した三角形のリストです。 これらの独立した三角形は、距離が近い場合もそうでない場合もあります。 三角形の一覧には、最低 3 つの頂点が必須で、頂点の総数は 3 で割り切れる必要があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="triangle-strips.md">トライアングル ストリップ</a></p></td>
<td align="left"><p>トライアングル ストリップとは、接続された一連の三角形を指します。 三角形どうしは接続されているため、アプリケーションは三角形ごとに 3 つすべての頂点を繰り返し指定する必要がありません。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[座標系とジオメトリ](coordinate-systems-and-geometry.md)

 

 




