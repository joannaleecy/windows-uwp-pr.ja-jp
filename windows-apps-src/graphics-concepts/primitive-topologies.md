---
title: "プリミティブ トポロジ"
description: "Direct3D では、ポイントの一覧、線の一覧、三角形ストリップなどのいくつかのプリミティブ トポロジがサポートされており、パイプラインにより頂点がどのように解釈され、レンダリングされるかを定義します。"
ms.assetid: 7AA5A4A2-0B7C-431D-B597-684D58C02BA5
keywords:
- "プリミティブ トポロジ"
author: mtoepke
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 487de51420cd6ce747d0257920429e9015bc1864
ms.lasthandoff: 02/07/2017

---

# <a name="primitive-topologies"></a>プリミティブ トポロジ


Direct3D では、ポイントの一覧、線の一覧、三角形ストリップなどのいくつかのプリミティブ トポロジがサポートされており、パイプラインにより頂点がどのように解釈され、レンダリングされるかを定義します。

## <a name="span-idprimitivetypesspanspan-idprimitivetypesspanspan-idprimitivetypesspanbasic-primitive-topologies"></a><span id="Primitive_Types"></span><span id="primitive_types"></span><span id="PRIMITIVE_TYPES"></span>基本的なプリミティブ トポロジ


サポートされている基本的なプリミティブ トポロジ (または、プリミティブ タイプ) を以下に示します。

-   [ポイント リスト](point-lists.md)
-   [線リスト](line-lists.md)
-   [ライン ストリップ](line-strips.md)
-   [トライアングル リスト](triangle-lists.md)
-   [トライアングル ストリップ](triangle-strips.md)

各プリミティブ タイプを視覚化したものを、この後の "[ワインディング方向と先頭頂点の位置](#winding-direction-and-leading-vertex-positions)" の図で示しています。

[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)では、頂点バッファーおよびインデックス バッファーからデータを読み取り、このデータをこれらのプリミティブにアセンブルし、残りのパイプライン ステージにデータを送信します。

## <a name="span-idprimitiveadjacencyspanspan-idprimitiveadjacencyspanspan-idprimitiveadjacencyspanprimitive-adjacency"></a><span id="Primitive_Adjacency"></span><span id="primitive_adjacency"></span><span id="PRIMITIVE_ADJACENCY"></span>プリミティブの隣接性


ポイント リストを除く Direct3D のすべてのプリミティブ タイプは、隣接性を持つプリミティブ タイプと、隣接性を持たないプリミティブ タイプの 2 種類に分けられます。 隣接性を持つプリミティブには、それを取り囲む頂点がいくつか含まれますが、隣接性を持たないプリミティブに含まれるのは、ターゲット プリミティブの頂点のみです。 たとえば、線リスト プリミティブには、対応する、隣接性を含む線リスト プリミティブが存在します。

隣接プリミティブは、ジオメトリに関する追加情報の提供を目的としており、ジオメトリ シェーダーによってのみ認識されます。 隣接性は、シルエット検出やシャドウ ボリュームの押し出しなどを使用するジオメトリ シェーダーで役に立ちます。

たとえば、隣接性のあるトライアングル リストを描画するとします。 36 個の頂点を持つ隣接性のあるトライアングル リストからは 6 個の完全なプリミティブが作成されます。 ライン ストリップを除き、隣接性のあるプリミティブは、隣接性を持たない同じプリミティブのちょうど 2 倍の頂点を含んでいます。ここで、追加の頂点はそれぞれ隣接頂点です。

## <a name="span-idwindingdirectionandleadingvertexpositionsspanspan-idwindingdirectionandleadingvertexpositionsspanspan-idwindingdirectionandleadingvertexpositionsspanspan-idwinding-direction-and-leading-vertex-positionsspanwinding-direction-and-leading-vertex-positions"></a><span id="Winding_Direction_and_Leading_Vertex_Positions"></span><span id="winding_direction_and_leading_vertex_positions"></span><span id="WINDING_DIRECTION_AND_LEADING_VERTEX_POSITIONS"></span><span id="winding-direction-and-leading-vertex-positions"></span>ワインディング方向と先頭頂点の位置


下の図にあるように、先頭頂点は、プリミティブ内の最初の非隣接頂点です。 先頭頂点がそれぞれ異なるプリミティブで使用されている限り、1 つのプリミティブ タイプで複数の先頭頂点を定義することができます。

-   隣接性を持つトライアングル ストリップでは、先頭頂点は 0、2、4、6 ... となります。
-   隣接性を持つライン ストリップでは、先頭頂点は 1、2、3 ... となります。
-   一方、隣接プリミティブには先頭頂点はありません。

次の図は、入力アセンブラーで生成可能なすべてのプリミティブ タイプの頂点の順序を表しています。

![プリミティブ タイプの頂点順序の図](images/d3d10-primitive-topologies.png)

この図の記号の意味を、次の表に示します。

| 記号                                                                                   | 名前              | 説明                                                                         |
|------------------------------------------------------------------------------------------|-------------------|-------------------------------------------------------------------------------------|
| ![頂点を表す記号](images/d3d10-primitive-topologies-vertex.png)                     | 頂点            | 3D 空間内の点です。                                                                |
| ![ワインディング方向を表す記号](images/d3d10-primitive-topologies-winding-direction.png) | ワインディング方向 | プリミティブをアセンブルするときの頂点の順序です。 時計回り、または反時計回りです。 |
| ![先頭頂点を表す記号](images/d3d10-primitive-topologies-leading-vertex.png)       | 先頭頂点    | プリミティブ内で、定数ごとのデータを含む最初の非隣接頂点です。       |

 

## <a name="span-idgeneratingmultiplestripsspanspan-idgeneratingmultiplestripsspanspan-idgeneratingmultiplestripsspangenerating-multiple-strips"></a><span id="Generating_Multiple_Strips"></span><span id="generating_multiple_strips"></span><span id="GENERATING_MULTIPLE_STRIPS"></span>複数のストリップの生成


ストリップ カットによって、複数のストリップを生成することができます。 ストリップ カットを実行するには、[RestartStrip](https://msdn.microsoft.com/library/windows/desktop/bb509660) HLSL 関数を明示的に呼び出すか、インデックス バッファーに特殊なインデックス値を挿入します。 この値とは –1 で、32 ビットのインデックスは 0xffffffff、16 ビットのインデックスは 0xffff です。

-1 のインデックスは、現在のストリップの明示的な ”カット” または ”再開” を示します。 前のインデックスは前のプリミティブかストリップを完了し、次のインデックスは新しいプリミティブかストリップを開始します。

複数のストリップの生成について、詳細は「[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)」を参照してください。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連項目


[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)

[グラフィックス パイプライン](graphics-pipeline.md)

 

 





