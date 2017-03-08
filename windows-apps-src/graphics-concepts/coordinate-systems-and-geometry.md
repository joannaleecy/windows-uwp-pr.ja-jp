---
title: "座標系とジオメトリ"
description: "Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。 ここでは、3D シーンを作成するための最も重要なジオメトリの概念について説明します。"
ms.assetid: E82EB0A9-0678-496B-96B3-8993BA580099
keywords:
- "座標系とジオメトリ"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 655e8587d103843bf2e040519b60f82160bc7b5d
ms.lasthandoff: 02/07/2017

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
<td align="left"><p>[座標系](coordinate-systems.md)</p></td>
<td align="left"><p>通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。 いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[プリミティブ](primitives.md)</p></td>
<td align="left"><p>3D <em>プリミティブ</em>は、単一の 3D エンティティを形成する頂点の集合です。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[面および頂点法線ベクトル](face-and-vertex-normal-vectors.md)</p></td>
<td align="left"><p>メッシュ内の各面には、垂直な単位法線ベクトルがあります。 ベクトルの方向は、頂点が定義された順序によって、また座標系が右手系であるか左手系であるかによって決まります。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[矩形](rectangles.md)</p></td>
<td align="left"><p>Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。 境界矩形のサイドは、常に画面のサイドと平行になっています。そのため、矩形は左上隅と右下隅の 2 つのポイントで描画されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[三角形の補間](triangle-interpolation.md)</p></td>
<td align="left"><p>レンダリング中、パイプラインは各三角形で頂点データを補間します。 頂点データの種類は幅広く、ディフューズ色、スペキュラ色、ディフューズ色のアルファ (三角形の不透明度)、スペキュラ色のアルファ、フォグ係数などが含まれます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[ベクトル、頂点、および四元数](vectors--vertices--and-quaternions.md)</p></td>
<td align="left"><p>Direct3D では、頂点は位置と方向を表します。 プリミティブの各頂点は、位置、色、テクスチャ座標を決定するベクトル、およびその方向を決定する法線ベクトルによって示されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[変換](transforms.md)</p></td>
<td align="left"><p>Direct3D の機能の一部で、ジオメトリを固定機能ジオメトリ パイプラインに挿入する変換エンジンです。 モデルとビューアーをワールド座標に配置し、画面に表示するための頂点を投影し、ビューポートに頂点をクリップします。 さらに変換エンジンは照明計算を実行し、各頂点における拡散成分および鏡面成分を決定します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[ビューポートとクリッピング](viewports-and-clipping.md)</p></td>
<td align="left"><p>"ビューポート<em></em>" とは、3D シーンが投影される 2 次元 (2D) の矩形です。 Direct3D の場合、この矩形は、レンダー ターゲットとして使用される Direct3D サーフェス内の座標として存在します。 プロジェクション変換は、頂点をビューポートに使用される座標系に変換します。 さらに、ビューポートはレンダー ターゲット サーフェスの深度値の範囲を指定できます。この範囲は、通常、0.0 ～ 1.0 です。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[Direct3D Graphics の学習ガイド](index.md)

 

 





