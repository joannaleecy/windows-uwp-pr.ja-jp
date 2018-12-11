---
title: 座標系とジオメトリ
description: Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。 ここでは、3D シーンを作成するための最も重要なジオメトリの概念について説明します。
ms.assetid: E82EB0A9-0678-496B-96B3-8993BA580099
keywords:
- 座標系とジオメトリ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 962002d635c3e6edbf1f9581a4cbc57fbd5b1d96
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8877450"
---
# <a name="coordinate-systems-and-geometry"></a>座標系とジオメトリ


Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。 ここでは、3D シーンを作成するための最も重要なジオメトリの概念について説明します。

## <a name="span-idin-this-sectionspanin-this-section"></a><span id="in-this-section"></span>説明するトピックは、次のとおりです。


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
<td align="left"><p><a href="coordinate-systems.md">座標系</a></p></td>
<td align="left"><p>通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。 いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="primitives.md">プリミティブ</a></p></td>
<td align="left"><p>3D <em>プリミティブ</em>は、単一の 3D エンティティを形成する頂点の集合です。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="face-and-vertex-normal-vectors.md">面および頂点法線ベクトル</a></p></td>
<td align="left"><p>メッシュ内の各面には、垂直な単位法線ベクトルがあります。 ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="rectangles.md">矩形</a></p></td>
<td align="left"><p>Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。 境界矩形のサイドは、常に画面のサイドと平行になっています。そのため、矩形は左上隅と右下隅の 2 つのポイントで描画されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="triangle-interpolation.md">三角形の補間</a></p></td>
<td align="left"><p>レンダリング中、パイプラインは各三角形で頂点データを補間します。 頂点データの種類は幅広く、ディフューズ色、スペキュラ色、ディフューズ色のアルファ (三角形の不透明度)、スペキュラ色のアルファ、フォグ係数などが含まれます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="vectors--vertices--and-quaternions.md">ベクトル、頂点、および四元数</a></p></td>
<td align="left"><p>Direct3D では、頂点は位置と方向を表します。 プリミティブの各頂点は、位置、色、テクスチャ座標を決定するベクトル、およびその方向を決定する法線ベクトルによって示されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="transforms.md">変換</a></p></td>
<td align="left"><p>Direct3D の機能の一部で、ジオメトリを固定機能ジオメトリ パイプラインに挿入する変換エンジンです。 変換エンジンは、モデルとビューアーをワールド座標に配置し、画面表示のために頂点を投影し、ビューポートに頂点をクリッピングします。 さらに変換エンジンは照明計算を実行し、各頂点における拡散成分および鏡面成分を決定します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="viewports-and-clipping.md">ビューポートとクリッピング</a></p></td>
<td align="left"><p>"ビューポート<em></em>" とは、3D シーンが投影される 2 次元 (2D) の矩形です。 Direct3D では、この四角形は Direct3D サーフェス内の座標として存在し、システムによってレンダー ターゲットとして使われます。 射影変換は、頂点をビューポートで使われる座標系に変換します。 さらに、ビューポートはレンダー ターゲット サーフェスの深度値の範囲を指定できます。この範囲は、通常、0.0 ～ 1.0 です。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[Direct3D グラフィックスの学習ガイド](index.md)

 

 




