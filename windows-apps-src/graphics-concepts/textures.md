---
title: "テクスチャ"
description: "テクスチャは、コンピュータで作成した 3D 画像にリアルさを加えるための強力なツールです。 Direct3D は広範囲のテクスチャリング機能セットをサポートし、高度なテクスチャリング手法に簡単にアクセスできる方法を開発者に提供します。"
ms.assetid: B9E85C9E-B779-4852-9166-6FA2240B7046
keywords: "テクスチャ"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: ef5c72f3c667c63cb48c469349ae26c364050c19
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="textures"></a>テクスチャ


テクスチャは、コンピュータで作成した 3D 画像にリアルさを加えるための強力なツールです。 Direct3D は広範囲のテクスチャリング機能セットをサポートし、高度なテクスチャリング手法に簡単にアクセスできる方法を開発者に提供します。

パフォーマンス向上のために、動的テクスチャの使用を検討してください。 動的テクスチャは、各フレームでロックしたり、書き込んだり、ロックを解除したりできます。

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
<td align="left"><p>[テクスチャの概要](introduction-to-textures.md)</p></td>
<td align="left"><p>テクスチャ リソースはテクセルを保存するデータ構造で、読み書きできるテクスチャの最小単位です。 テクスチャをシェーダーで読み取るとき、テクスチャ サンプラーでフィルター処理することができます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[テクスチャリングの基本概念](basic-texturing-concepts.md)</p></td>
<td align="left"><p>コンピューターで作成された初期の 3D 画像は、当時は高度な技術でしたが、ツルツルのプラスチックのような外観になりがちでした。 それらには、3D オブジェクトにリアルで複雑な外観を与える傷や割れ、指紋、汚れなどがありませんでした。 テクスチャは、コンピューターで作成された 3D 画像のリアルさを向上させるための一般的な手法になってきました。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[テクスチャのアドレス指定モード](texture-addressing-modes.md)</p></td>
<td align="left"><p>Direct3D アプリケーションは、任意のプリミティブの頂点テクスチャ座標を割り当てることができます。 通常、頂点に割り当てるテクスチャ座標 (u, v) は 0.0 ～ 1.0 (両端含む) の範囲です。 ただし、その範囲外のテクスチャ座標を割り当てることで、テクスチャリングの特殊効果を作成できます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[テクスチャ フィルタリング](texture-filtering.md)</p></td>
<td align="left"><p>プリミティブが 3D プリミティブから 2D 画面へのマッピングによってレンダリングされるときに、テクスチャ フィルタリングによって、プリミティブの 2D レンダリングされた画像の各ピクセルの色が生成されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[テクスチャ リソース](texture-resources.md)</p></td>
<td align="left"><p>テクスチャは、レンダリングに使われるリソースの一種です。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[テクスチャの折り返し](texture-wrapping.md)</p></td>
<td align="left"><p>テクスチャの折り返しによって、Direct3D が各頂点に指定されたテクスチャ座標を使って、テクスチャが適用された多角形をラスタライズする際の基本的な方法が変更されます。 多角形をラスタライズするとき、システムは多角形の各頂点のテクスチャ座標の間を補間して、多角形の各ピクセルに使うテクセルを決定します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[テクスチャ ブレンド](texture-blending.md)</p></td>
<td align="left"><p>Direct3D では、1 つのパスでプリミティブに 8 個までのテクスチャをブレンドできます。 複数のテクスチャ ブレンドを使うと、Direct3D アプリケーションのフレーム レートが大幅に増えることがあります。 アプリケーションは複数のテクスチャを使って、テクスチャ、シャドウ、鏡面反射、拡散光、およびその他の特殊効果を 1 つのパスで適用します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[テクスチャでのライト マッピング](light-mapping-with-textures.md)</p></td>
<td align="left"><p>ライト マップは、3D シーンの照明に関する情報が含まれるテクスチャまたはテクスチャのグループです。 ライト マップは、ライトおよびシャドウの領域をプリミティブにマップします。 マルチパスおよび複数のテクスチャ ブレンドによって、アプリケーションはシェーディング手法よりリアルな外観のシーンをレンダリングすることができます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[圧縮テクスチャ リソース](compressed-texture-resources.md)</p></td>
<td align="left"><p>テクスチャ マップとは、視覚的な詳細を追加するために 3 次元形状で描画された、デジタル画像です。 テクスチャ マップは、ラスター化時に 3D の形状にマッピングされます。このプロセスではシステム バスとメモリの両方を大量に消費することがあります。 テクスチャによって消費されるメモリ量を減らすために、Direct3D ではテクスチャ サーフェスの圧縮がサポートされています。 Direct3D デバイスの中には、圧縮テクスチャ サーフェスを標準でサポートするものもあります。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[Direct3D グラフィックスの学習ガイド](index.md)

 

 




