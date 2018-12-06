---
title: テクスチャ フィルタリング
description: プリミティブが 3D プリミティブから 2D 画面へのマッピングによってレンダリングされるときに、テクスチャ フィルタリングによって、プリミティブの 2D レンダリングされた画像の各ピクセルの色が生成されます。
ms.assetid: 1CCF4138-5D48-4B07-9490-996844F994D8
keywords:
- テクスチャ フィルタリング
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 449a31d92235efc50119bcd0db11b3532f523cd2
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8757708"
---
# <a name="texture-filtering"></a>テクスチャ フィルタリング


プリミティブが 3D プリミティブから 2D 画面へのマッピングによってレンダリングされるときに、テクスチャ フィルタリングによって、プリミティブの 2D レンダリングされた画像の各ピクセルの色が生成されます。

Direct3D では、プリミティブをレンダリングするとき、3D プリミティブを 2D 画面にマッピングします。 プリミティブにテクスチャがある場合、Direct3D はそのテクスチャを必ず使用して、プリミティブの 2D レンダリングされた画像の各ピクセルのカラーを生成します。 プリミティブの画面上の画像のピクセルごとに、テクスチャからカラー値を取得する必要があります。 このプロセスは、*テクスチャフィルタリング*と呼ばれます。

テクスチャ フィルタリング処理が実行されるとき、使用されるテクスチャは通常、拡大または縮小されます。 つまり、テクスチャは、それ自体よりも大きいまたは小さいプリミティブ イメージにマッピングされます。 テクスチャの拡大では、多数のピクセルが 1 つのテクセルにマッピングされることがあります。 その結果、外観が粗くなる場合があります。 テクスチャが縮小されると、多くの場合、1 つのピクセルが多数のテクセルにマッピングされます。 その結果、イメージが不鮮明になったり、輪郭がギザギザになったりすることがあります。 このような問題を解決するには、ピクセルに適したカラーになるようにテクセルのカラーになんらかのブレンドを実行する必要があります。

Direct3D によって、テクスチャ フィルタリングの複雑なプロセスが単純化されます。 Direct3D には、線形フィルタリング、異方性フィルタリング、およびミップマップ フィルタリングという 3 種類のテクスチャ フィルタリングが用意されています。 テクスチャ フィルタリングを選択しなかった場合、Direct3D では最近点サンプリングという手法が使用されます。

それぞれのテクスチャ フィルタリングには、長所と短所があります。 たとえば、線形テクスチャ フィルタリングでは、最終イメージでエッジがギザギザになったり、外観が粗くなったりすることがあります。 ただし、このテクスチャ フィルタリングは計算処理のオーバーヘッドが少ない方法です。 ミップマップによるフィルタリングでは、通常、適切な結果が生成されます。特に、異方性フィルタリングと組み合わせた場合に結果がよくなります。 ただし、Direct3D でサポートされる方法の中で最も多くのメモリを必要とします。

## <a name="span-idtypes-of-texture-filteringspanspan-idtypes-of-texture-filteringspanspan-idtypes-of-texture-filteringspantypes-of-texture-filtering"></a><span id="Types-of-texture-filtering"></span><span id="types-of-texture-filtering"></span><span id="TYPES-OF-TEXTURE-FILTERING"></span>テクスチャ フィルタリングの種類


Direct3D は、次のテクスチャ フィルタリング手法をサポートします。

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
<td align="left"><p><a href="nearest-point-sampling.md">最近点サンプリング</a></p></td>
<td align="left"><p>アプリケーションでは、必ずしもテクスチャ フィルタリングを使用する必要はありません。 Direct3D の設定により、テクセル アドレスを計算したり (これは多くの場合、整数として評価されません)、最も近い整数アドレスを持つテクセルのカラーをコピーさせたりすることができます。 このプロセスは、<em>最近点サンプリング</em>と呼ばれます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="bilinear-texture-filtering.md">バイリニア テクスチャ フィルタリング</a></p></td>
<td align="left"><p><em>バイリニア フィルタリング</em>は、サンプリング ポイントに最も近い 4 つのテクセルの加重平均を計算します。 このフィルタリング手法は、最近点フィルタリングよりも正確で一般的です。 このアプローチは最新のグラフィックス ハードウェアに実装されているため、効率的です。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="anisotropic-texture-filtering.md">異方性テクスチャ フィルタ リング</a></p></td>
<td align="left"><p>サーフェスがスクリーンの平面に対して角度をなして配置されている 3D オブジェクトのテクセルに見られるゆがみを<em>異方性</em>と呼びます。 異方性プリミティブのピクセルをテクセルにマッピングすると、形状がゆがみます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="texture-filtering-with-mipmaps.md">ミップマップでのテクスチャ フィルタリング</a></p></td>
<td align="left"><p><em>ミップマップ</em>は連続したテクスチャで、各テクスチャは同じイメージを徐々に低い解像度で表したものです。 ミップマップでの各イメージの高さと幅、つまりレベルは、直前のレベルを 2 の累乗で割った値になります。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャ](textures.md)

 

 




