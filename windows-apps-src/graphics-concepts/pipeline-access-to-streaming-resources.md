---
title: "ストリーミング リソースへのパイプライン アクセス"
description: "ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。"
ms.assetid: 18DA5D61-930D-4466-8EFE-0CED566EA4A6
keywords:
- "ストリーミング リソースへのパイプライン アクセス"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 5f4fd92e1519579f15b3c3d452ce80e944f0942b
ms.lasthandoff: 02/07/2017

---

# <a name="pipeline-access-to-streaming-resources"></a>ストリーミング リソースへのパイプライン アクセス


ストリーミング リソースは、シェーダー リソース ビュー (SRV)、レンダー ターゲット ビュー (RTV)、深度ステンシル ビュー (DSV)、順序指定されていないアクセス ビュー (UAV) のほか、頂点バッファー バインドなどのビューが使用されない一部のバインド ポイントで使用できます。 サポートされているバインドの一覧については、「[ストリーミング リソースの作成パラメーター](streaming-resource-creation-parameters.md)」を参照してください。 また、さまざまな D3D コピー操作もストリーミング リソース上で機能します。

1 つ以上のビュー内の複数のタイルの座標が同じメモリ位置にバインドされている場合、複数のパスから同一メモリへの読み取りと書き込みは、無作為で反復不可能な順序のメモリ アクセスで発生します。

シェーダーからのメモリ アクセス フットプリントの背後にある全タイルが一意のタイルにマップされる場合、動作はどの実装においても、同一のメモリ内容を非タイル形式で保持するサーフェスと同じになります。

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
<td align="left"><p>[マップされていないタイルでの SRV 動作](srv-behavior-with-non-mapped-tiles.md)</p></td>
<td align="left"><p>マップされていないタイルに関連するシェーダー リソース ビュー (SRV) の読み取り動作は、ハードウェア サポートのレベルによって異なります。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[マップされていないタイルでの UAV 動作](uav-behavior-with-non-mapped-tiles.md)</p></td>
<td align="left"><p>順序指定されていないアクセス ビュー (UAV) の読み取りと書き込みの動作は、ハードウェア サポートのレベルによって異なります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[マップされていないタイルでのラスタライザー動作](rasterizer-behavior-with-non-mapped-tiles.md)</p></td>
<td align="left"><p>このセクションでは、マップされていないタイルを使用したラスタライザー動作について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[重複するマッピングを含むタイルのアクセス制限](tile-access-limitations-with-duplicate-mappings.md)</p></td>
<td align="left"><p>コピー元とコピー先が重複しているストリーミング リソースをコピーする場合や、レンダー領域内で共有されるタイルをレンダリングする場合などでは、重複するマッピングを含むタイル アクセスに制限があります。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[ストリーミング リソース テクスチャ サンプリング機能](streaming-resources-texture-sampling-features.md)</p></td>
<td align="left"><p>ストリーミング リソース テクスチャ サンプリングの機能は複数あります。たとえば、マップの領域についてシェーダー状態のフィードバックを取得する機能、アクセスされている全データがリソース内にマップされたかどうか確認する機能、マップされていないことがわかっているミップマップ ストリーミング リソース内の領域をシェーダーが避けられるようにクランプする機能、テクスチャ フィルターのフットプリント全体に完全にマップされる最小の LOD を検出する機能などがあります。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[HLSL ストリーミング リソースの露出](hlsl-streaming-resources-exposure.md)</p></td>
<td align="left"><p>[シェーダー モデル 5](https://msdn.microsoft.com/library/windows/desktop/ff471356) のストリーミング リソースをサポートするには、Microsoft 上位レベル シェーダー言語 (HLSL) の特定の構文が必要です。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連項目


[ストリーミング リソース](streaming-resources.md)

 

 





