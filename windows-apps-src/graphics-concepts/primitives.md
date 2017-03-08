---
title: "プリミティブ"
description: "3D プリミティブは、単一の 3D エンティティを形成する頂点の集合です。"
ms.assetid: A1FE6F49-B0D4-4665-90E1-40AD98E668B1
keywords:
- "プリミティブ"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: e6734ff8534302d3866374adba45c34d70ae440a
ms.lasthandoff: 02/07/2017

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
<td align="left"><p>[ポイント リスト](point-lists.md)</p></td>
<td align="left"><p>ポイント リストとは、独立した点としてレンダリングされる頂点の集合を指します。 アプリケーションは、星空の 3D シーンや、多角形の表面の点線に、ポイント リストを使うことができます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[線リスト](line-lists.md)</p></td>
<td align="left"><p>線リストとは、独立した直線セグメントの一覧を指します。 線リストは、3D シーンに氷雨や豪雨を追加する場合などに便利です。 アプリケーションは、頂点の配列を入力することで行リストを作成します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[ライン ストリップ](line-strips.md)</p></td>
<td align="left"><p>ライン ストリップとは、接続された行セグメントから構成されるプリミティブを指します。 アプリケーションは、ライン ストリップを使用して、閉じられていない多角形を作成することができます。 閉じられた多角形とは、最後の頂点が行セグメントによって最初の頂点に接続されている多角形を指します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[トライアングル リスト](triangle-lists.md)</p></td>
<td align="left"><p>トライアングル リストとは、独立した三角形の一覧を指します。 これらの独立した三角形は、距離が近い場合もそうでない場合もあります。 三角形の一覧には、最低 3 つの頂点が必須で、頂点の総数は 3 で割り切れる必要があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[トライアングル ストリップ](triangle-strips.md)</p></td>
<td align="left"><p>トライアングル ストリップとは、接続された一連の三角形を指します。 三角形どうしは接続されているため、アプリケーションは三角形ごとに 3 つすべての頂点を繰り返し指定する必要がありません。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[座標系とジオメトリ](coordinate-systems-and-geometry.md)

 

 





