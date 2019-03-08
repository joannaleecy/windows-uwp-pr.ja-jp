---
title: テクスチャ
description: テクスチャは、コンピューターにより生成された 3D 画像でリアルさを出すための強力なツールです。 Direct3D は広範囲のテクスチャリング機能セットをサポートし、高度なテクスチャリング手法に簡単にアクセスできる方法を開発者に提供します。
ms.assetid: B9E85C9E-B779-4852-9166-6FA2240B7046
keywords:
- テクスチャ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 81d77b262cc77c23d859cf76227a34bc72b15b96
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593007"
---
# <a name="textures"></a>テクスチャ


テクスチャは、コンピューターにより生成された 3D 画像でリアルさを出すための強力なツールです。 Direct3D は広範囲のテクスチャリング機能セットをサポートし、高度なテクスチャリング手法に簡単にアクセスできる方法を開発者に提供します。

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
<td align="left"><p><a href="introduction-to-textures.md">テクスチャの概要</a></p></td>
<td align="left"><p>テクスチャ リソースはテクセルを保存するデータ構造で、読み書きできるテクスチャの最小単位です。 テクスチャをシェーダーで読み取るとき、テクスチャ サンプラーでフィルター処理することができます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="basic-texturing-concepts.md">テクスチャの基本的な概念</a></p></td>
<td align="left"><p>コンピューターで作成された初期の 3D 画像は、当時は高度な技術でしたが、ツルツルのプラスチックのような外観になりがちでした。 それらには、3D オブジェクトにリアルで複雑な外観を与える傷や割れ、指紋、汚れなどがありませんでした。 テクスチャは、コンピューターで作成された 3D 画像のリアルさを向上させるための一般的な手法になってきました。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="texture-addressing-modes.md">テクスチャのアドレッシング モード</a></p></td>
<td align="left"><p>Direct3D アプリケーションは、任意のプリミティブの頂点テクスチャ座標を割り当てることができます。 通常、頂点に割り当てるテクスチャ座標 (u, v) は 0.0 ～ 1.0 (両端含む) の範囲です。 ただし、その範囲外のテクスチャ座標を割り当てることで、テクスチャリングの特殊効果を作成できます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="texture-filtering.md">テクスチャ フィルタ リング</a></p></td>
<td align="left"><p>プリミティブが 3D プリミティブから 2D 画面へのマッピングによってレンダリングされるときに、テクスチャ フィルタリングによって、プリミティブの 2D レンダリングされた画像の各ピクセルの色が生成されます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="texture-resources.md">テクスチャのリソース</a></p></td>
<td align="left"><p>テクスチャは、レンダリングに使われるリソースの一種です。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="texture-wrapping.md">テクスチャのラッピング</a></p></td>
<td align="left"><p>テクスチャの折り返しによって、Direct3D が各頂点に指定されたテクスチャ座標を使って、テクスチャが適用された多角形をラスタライズする際の基本的な方法が変更されます。 多角形をラスタライズするとき、システムは多角形の各頂点のテクスチャ座標の間を補間して、多角形の各ピクセルに使うテクセルを決定します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="texture-blending.md">テクスチャのブレンド</a></p></td>
<td align="left"><p>Direct3D では、1 つのパスでプリミティブに 8 個までのテクスチャをブレンドできます。 複数のテクスチャ ブレンドを使うと、Direct3D アプリケーションのフレーム レートが大幅に増えることがあります。 アプリケーションは複数のテクスチャを使って、テクスチャ、シャドウ、鏡面反射、拡散光、およびその他の特殊効果を 1 つのパスで適用します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="light-mapping-with-textures.md">テクスチャのライトのマッピング</a></p></td>
<td align="left"><p>ライト マップは、3D シーン内の照明に関する情報を含むテクスチャまたはテクスチャのグループです。 ライト マップは、ライトおよびシャドウの領域をプリミティブにマップします。 マルチパスおよび複数テクスチャ ブレンドにより、アプリケーションがシェーディング手法より現実的な外観によってシーンをレンダリングできるようになります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="compressed-texture-resources.md">圧縮されたテクスチャのリソース</a></p></td>
<td align="left"><p>テクスチャ マップとは、視覚的な詳細を追加するために 3 次元形状で描画された、デジタル画像です。 テクスチャ マップは、ラスター化時に 3D の形状にマッピングされます。このプロセスではシステム バスとメモリの両方を大量に消費することがあります。 テクスチャによって消費されるメモリ量を減らすために、Direct3D ではテクスチャ サーフェスの圧縮がサポートされています。 Direct3D デバイスの中には、圧縮テクスチャ サーフェスを標準でサポートするものもあります。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[Direct3D グラフィックス学習ガイド](index.md)

 

 




