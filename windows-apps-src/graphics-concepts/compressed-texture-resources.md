---
title: 圧縮テクスチャ リソース
description: テクスチャ マップとは、視覚的な詳細を追加するために 3 次元形状で描画された、デジタル画像です。
ms.assetid: 2DD5FF94-A029-4694-B103-26946C8DFBC1
keywords:
- 圧縮テクスチャ リソース
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e808bf0fe1f521a60aa347efd148ede96be95964
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6465195"
---
# <a name="compressed-texture-resources"></a>圧縮テクスチャ リソース


テクスチャ マップとは、視覚的な詳細を追加するために 3 次元形状で描画された、デジタル画像です。 テクスチャ マップは、ラスター化時に 3D の形状にマッピングされます。このプロセスではシステム バスとメモリの両方を大量に消費することがあります。 テクスチャによって消費されるメモリ量を減らすために、Direct3D ではテクスチャ サーフェスの圧縮がサポートされています。 Direct3D デバイスの中には、圧縮テクスチャ サーフェスを標準でサポートするものもあります。 このようなデバイスでは、圧縮したサーフェスを作成し、データをロードすると、他のテクスチャ サーフェスと同様に Direct3D でそのサーフェスを使用することができます。 テクスチャが 3D オブジェクトにマッピングされるときに、Direct3D によって圧縮が解除されます。

## <a name="span-idstorage-efficiency-and-texture-compressionspanspan-idstorage-efficiency-and-texture-compressionspanspan-idstorage-efficiency-and-texture-compressionspanstorage-efficiency-and-texture-compression"></a><span id="Storage-Efficiency-and-Texture-Compression"></span><span id="storage-efficiency-and-texture-compression"></span><span id="STORAGE-EFFICIENCY-AND-TEXTURE-COMPRESSION"></span>ストレージの効率とテクスチャ圧縮


テクスチャ圧縮形式はすべて 2 の累乗です。 これはテクスチャが必ず正方形であることを意味するのではなく、x と y の両方が 2 の累乗であることを意味します。 たとえば、元のテクスチャが 512 × 128 バイトであった場合、次のミップマップ処理では 256 × 64 というように、1 レベルごとに 2 の累乗ずつ小さくなります。 さらにレベルを下げて、テクスチャを 16 × 2 および 8 × 1 までフィルタリングすると、圧縮ブロックは常に 4 x 4 のテクセル ブロックであるため、無駄なビットが生じます。 ブロックの未使用部分はパディングされます。

低いレベルでは無駄なビットが出ますが、全体的なゲインは重要です。 理論的に最悪のケースは、2K × 1 (2 の 0 乗) のテクスチャです。 この場合、1 ブロックにつき 1 つのピクセル行しかエンコードされず、ブロックの残りの部分は使用されません。

## <a name="span-idmixing-formats-within-a-single-texturespanspan-idmixing-formats-within-a-single-texturespanspan-idmixing-formats-within-a-single-texturespanmixing-formats-within-a-single-texture"></a><span id="Mixing-Formats-Within-a-Single-Texture"></span><span id="mixing-formats-within-a-single-texture"></span><span id="MIXING-FORMATS-WITHIN-A-SINGLE-TEXTURE"></span>単一テクスチャ内での形式の組み合わせ


個々のテクスチャはすべて、16 テクセルのグループごとにデータを 64 ビットまたは 128 ビットで格納するように指定する必要があることに注意してください。 64 ビットのブロック、つまりブロック圧縮形式 BC1 をテクスチャに使用する場合、同一のテクスチャ内にブロック単位で不透明の形式と 1 ビット アルファの形式を混在させることができます。 つまり、color\_0 と color\_1 の符号なし整数の絶対値の比較が、16 テクセルのブロックごとに独立して実行されます。

128 ビット ブロックを使用する場合、テクスチャ全体にアルファ チャネルを明示的モード (BC2 形式) または補間モード (BC3 形式) で指定する必要があります。 カラーの場合と同様に、補間モード (BC3 形式) を選択すると、8 つの補間アルファまたは 6 つの補間アルファのモードをブロック単位で使用することができます。 ここでも、alpha\_0 と alpha\_1 の絶対値の比較がブロックごとに独立して実行されます。

Direct3D では、3D モデルのテクスチャに使用する、サーフェスを圧縮するためのサービスが用意されています。 ここでは、圧縮テクスチャ サーフェスのデータの作成および操作について説明します。

## <a name="span-idin-this-sectionspanin-this-section"></a><span id="in-this-section"></span>説明するトピックは次のとおりです。


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
<td align="left"><p><a href="opaque-and-1-bit-alpha-textures.md">不透明なテクスチャと 1 ビットのアルファ テクスチャ</a></p></td>
<td align="left"><p>テクスチャ形式 BC1 は、不透明または単一透明色のテクスチャに使用します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="textures-with-alpha-channels.md">アルファ チャネルを含むテクスチャ</a></p></td>
<td align="left"><p>複雑な透明度を表現するテクスチャ マップには 2 つのエンコード方法があります。 いずれの場合も、既に説明した 64 ビットのブロックの前に、透明度を記述したブロックを配置します。 透明度は、1 ピクセルあたり 4 ビットの 4 x 4 ビットマップ (明示的エンコード)、またはこれよりも少ないビット数およびカラー エンコードで使用されるものに類似した線形補完で表現します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="block-compression.md">ブロック圧縮</a></p></td>
<td align="left"><p>ブロック圧縮は、テクスチャ サイズとメモリ フットプリントを減らしてパフォーマンスを向上させる、不可逆のテクスチャ圧縮技術です。 ブロック圧縮テクスチャは、1 色あたり 32 ビットのテクスチャより小さくすることができます。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="compressed-texture-formats.md">圧縮テクスチャ形式</a></p></td>
<td align="left"><p>このセクションでは、圧縮テクスチャ形式の内部構造について説明します。 圧縮形式への変換、および圧縮形式からの変換には Direct3D 関数を使用できるため、圧縮テクスチャの使用にこれらの詳細は必要ありません。 ただし、圧縮サーフェス データを直接操作する場合は、この情報が役に立ちます。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[テクスチャ](textures.md)

 

 




