---
title: "変換"
description: "Direct3D の処理の中で、ジオメトリを固定機能ジオメトリ パイプラインに通す部分を担うのが変換エンジンです。"
ms.assetid: 0DF2A99A-335C-4D14-9720-6D7996DD635A
keywords: "変換"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: 342dd40bd6cc69ebf1faf93753b91096e7ecfbe9
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="transforms"></a>変換


Direct3D の処理の中で、ジオメトリを固定機能ジオメトリ パイプラインに通す部分を担うのが変換エンジンです。 変換エンジンは、モデルとビューアーをワールド座標に配置し、画面表示のために頂点を投影し、ビューポートに頂点をクリッピングします。 また、照明の計算を実行し、各頂点での拡散要素と反射要素を決定します。

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
<td align="left"><p>[変換の概要](transform-overview.md)</p></td>
<td align="left"><p>3D グラフィックスの多くの低レベル数学演算は、行列変換によって処理されます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[ワールド変換](world-transform.md)</p></td>
<td align="left"><p>ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。 ワールド空間では、頂点はシーン内のすべてのオブジェクトに共通の原点を基準として相対的に定義されます。 ワールド変換は、モデルをワールド空間に配置します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[ビュー変換](view-transform.md)</p></td>
<td align="left"><p>"ビュー変換"<em></em> は、ビューアーをワールド空間に配置し、頂点をカメラ空間に変換します。 カメラ空間では、カメラつまりビューアーは原点に位置し、Z 軸の正方向を向いています。 ビュー行列は、ワールド内のオブジェクトを、カメラの位置 (カメラ空間の原点) と方向を中心として再配置します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[射影変換](projection-transform.md)</p></td>
<td align="left"><p>"射影変換"<em></em> はカメラの内部を制御します。これは、カメラのレンズを選択することと似ています。 この変換は、3 種類の変換の中で最も複雑です。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[座標系とジオメトリ](coordinate-systems-and-geometry.md)

 

 




