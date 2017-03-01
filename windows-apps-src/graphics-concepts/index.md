---
title: "Direct3D Graphics の学習ガイド"
description: "Microsoft Direct3D の構築に使われているグラフィックスの概念について説明します。"
ms.assetid: c3850a92-4d05-4f72-bf0f-6a0c79e841eb
keywords:
- "Direct3D Graphics の学習ガイド"
author: PeterTurcan
ms.author: pettur
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: e62f9cfde35580dd384ef69fe6e5658d927ce3d8
ms.lasthandoff: 02/07/2017

---

# <a name="direct3d-graphics-learning-guide"></a>Direct3D Graphics の学習ガイド


Microsoft Direct3D の構築に使われているグラフィックスの概念について説明します。 このドキュメント セットの大部分は、Direct3D のバージョンには依存しておらず、バージョン固有の API ドキュメントで説明されているバックグラウンド情報をさらに必要とするグラフィックス開発者向けに用意されています。

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
<td align="left"><p>[座標系とジオメトリ](coordinate-systems-and-geometry.md)</p></td>
<td align="left"><p>Direct3D アプリケーションをプログラミングするには、3D の幾何学的原理を使い慣れている必要があります。 このセクションでは、3D シーンを作成するための最も重要な幾何学的概念について説明します。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[頂点バッファーとインデックス バッファー](vertex-and-index-buffers.md)</p></td>
<td align="left"><p><em>頂点バッファー</em>は、頂点データを含むメモリ バッファーです。頂点バッファー内の頂点は、変形、照射、クリッピングを実行するために処理されます。 <em>インデックス バッファー</em>は、インデックス データを含むメモリ バッファーであり、プリミティブのレンダリングに使用される、頂点バッファーへの整数オフセットです。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[デバイス](devices.md)</p></td>
<td align="left"><p>Direct3D デバイスは、Direct3D のレンダリング コンポーネントです。 デバイスは、レンダリング状態をカプセル化して格納し、変形および照射操作を実行して、画像をサーフェスにラスタライズします。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[光源](lights-and-materials.md)</p></td>
<td align="left"><p>光源は、シーン内のオブジェクトを照射するのに使われます。 各オブジェクト頂点の色は、現在のテクスチャ マップ、頂点の色、光源に基づきます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[深度バッファーとステンシル バッファー](depth-and-stencil-buffers.md)</p></td>
<td align="left"><p><em>深度バッファー</em>には、ビューから隠すのではなくレンダリングする多角形の領域を制御するための深度情報が格納されます。 <em>ステンシル バッファー</em>は、画像内のピクセルをマスクし、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどの特殊効果を生成するために使われます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[テクスチャ](textures.md)</p></td>
<td align="left"><p>テクスチャは、コンピューターにより生成された 3D 画像でリアルさを出すための強力なツールです。 Direct3D では、開発者が高度なテクスチャ手法に簡単にアクセスできれば、広範なテクスチャ機能セットがサポートされます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[グラフィックス パイプライン](graphics-pipeline.md)</p></td>
<td align="left"><p>Direct3D グラフィックス パイプラインは、リアルタイム ゲーム アプリケーション用のグラフィックスを生成できるように設計されています。 データは、構成可能またはプログラミング可能な各ステージを通じて、入力から出力へと流れます。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[ビュー](views.md)</p></td>
<td align="left"><p>&quot;ビュー&quot; という語は、&quot;必要な形式のデータ&quot;を意味します。 たとえば、定数バッファー ビュー (CBV) は、適切な形式の定数バッファー データです。 ここでは、最も一般的で役に立つビューについて説明します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[計算パイプライン](compute-pipeline.md)</p></td>
<td align="left"><p>Direct3D 計算パイプラインは、大部分がグラフィックス パイプラインと並行して実行可能な計算を処理できるように設計されています。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[リソース](resources.md)</p></td>
<td align="left"><p>リソースは、Direct3D パイプラインからアクセスできるメモリ内の領域です。 パイプラインでメモリに効率的にアクセスするには、パイプラインに渡すデータ (入力ジオメトリ、シェーダー リソース、テクスチャなど) をリソースに格納する必要があります。 すべての Direct3D リソースの派生元となるリソースは 2 種類あります。バッファーとテクスチャです。 各パイプライン ステージでは最大 128 個のリソースをアクティブにできます。</p></td>
</tr>
<tr class="odd">
<td align="left"><p>[ストリーミング リソース](streaming-resources.md)</p></td>
<td align="left"><p><em>ストリーミング リソース</em>は、少量の物理メモリを使用する大規模な論理リソースです。 大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。 ストリーミング リソースは、以前は<em>タイル リソース</em>と呼ばれていました。</p></td>
</tr>
<tr class="even">
<td align="left"><p>[付録](appendix.md)</p></td>
<td align="left"><p>これらのセクションでは、技術的な面について詳しく説明します。</p></td>
</tr>
</tbody>
</table>

 

 

 

