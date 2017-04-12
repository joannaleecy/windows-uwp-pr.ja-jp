---
title: "ストリーミング リソース"
description: "ストリーミング リソースは、少量の物理メモリを使用する大規模な論理リソースです。 大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。 ストリーミング リソースは、以前はタイル リソースと呼ばれていました。"
ms.assetid: 04F0486E-4B71-4073-88DA-2AF505F4F0C1
keywords:
- "ストリーミング リソース"
- "リソース, ストリーミング"
- "リソース, タイル"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.openlocfilehash: f45c1d955d901366b0160d148cef88ce015aeaa2
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="streaming-resources"></a>ストリーミング リソース


*ストリーミング リソース*は、少量の物理メモリを使用する大規模な論理リソースです。 大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。 ストリーミング リソースは、以前は*タイル リソース*と呼ばれていました。

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
<td align="left"><p>[ストリーミング リソースのニーズ](the-need-for-streaming-resources.md)</p></td>
<td align="left"><p>ストリーミング リソースは、アクセスされないサーフェスの領域を保存して GPU メモリを無駄にしないために、また、隣接するタイルをまたいでフィルター処理する方法をハードウェアに伝えるために必要です。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[ストリーミング リソースの作成](creating-streaming-resources.md)</p></td>
<td align="left"><p>ストリーミング リソースは、リソースを作成するときにフラグを指定することによって作成され、リソースがストリーミング リソースであることを示します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[ストリーミング リソースへのパイプライン アクセス](pipeline-access-to-streaming-resources.md)</p></td>
<td align="left"><p>ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[ストリーミング リソース機能の階層](streaming-resources-features-tiers.md)</p></td>
<td align="left"><p>Direct3D は、機能の 3 階層でストリーミング リソースをサポートします。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[Direct3D グラフィックスの学習ガイド](index.md)

[リソース](resources.md)

 

 




