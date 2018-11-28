---
title: 入力アセンブラー (IA) ステージ
description: 入力アセンブラー (IA) ステージは、三角形、線、点などのパイプラインにプリミティブ データと隣接性データを提供し (セマンティクス ID など)、まだ処理されていないプリミティブの処理を減らすことでシェーダーの効率を高めます。
ms.assetid: AF1DC611-C872-47F1-BF1A-92C68C8903E6
keywords:
- 入力アセンブラー (IA) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 8c5e1c294da2b4ef24ff8f62b686890cb8c69c06
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7830795"
---
# <a name="input-assembler-ia-stage"></a>入力アセンブラー (IA) ステージ


入力アセンブラー (IA) ステージは、三角形、線、点などのパイプラインにプリミティブ データと隣接性データを提供し (セマンティクス ID など)、まだ処理されていないプリミティブの処理を減らすことでシェーダーの効率を高めます。

## <a name="span-idpurpose-and-usesspanspan-idpurpose-and-usesspanspan-idpurpose-and-usesspanpurpose-and-uses"></a><span id="Purpose-and-uses"></span><span id="purpose-and-uses"></span><span id="PURPOSE-AND-USES"></span>目的と用途


入力アセンブラー (IA) ステージの目的は、ユーザーが入力したバッファーからプリミティブ データ (点、線、三角形) を読み取って、他のパイプライン ステージにより使われるプリミティブにデータをアセンブルし、[システムにより生成された値](https://msdn.microsoft.com/library/windows/desktop/bb509647)をアタッチしてシェーダーの効率を高めることです。 システムにより生成された値は、セマンティクスとも呼ばれるテキスト文字列です。 プログラミング可能なシェーダー ステージは、システムにより生成された値 (プリミティブ ID、インスタンス ID、頂点 ID など) を使うコマンド シェーダー コアから作成されます。これにより、シェーダー ステージは、まだ処理されていないそれらのプリミティブ、インスタンス、または頂点のみに処理を減らすことができます。

IA ステージは、複数の異なる[プリミティブ型](primitive-topologies.md) (線の一覧、三角形のストリップ、隣接性を持つプリミティブなど) に頂点をアセンブルします。 隣接性を持つ三角形の一覧などのプリミティブ型と、隣接性を持つ線の一覧は、[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)をサポートします。

隣接性情報は、ジオメトリ シェーダーでのみアプリケーションから見えます。 たとえば、ジオメトリ シェーダーが隣接性を含む三角形に関与していた場合、入力データには三角形ごとに 3 つの頂点と、各三角形の隣接性データに 3 つの頂点が含まれます。

IA ステージが隣接性データを出力するよう要求された場合、入力データには隣接性データが含まれている必要があります。 これには、ダミーの頂点を提供する必要が生じることあります (縮退三角形を形成)。場合によっては、頂点が存在するかどうかに関係なく、頂点属性の 1 つフラグを付けることによってもできます。 さらに、このことはジオメトリ シェーダーにより検出されて処理される必要もあります。ただし、縮退ジオメトリのカリングはラスタライザー ステージで行われます。

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力


IA ステージは、メモリ、プリミティブ データ (点、線、三角形)、ユーザーが入力したバッファーからデータを読み取ります。

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力


IA ステージは、データをプリミティブにアセンブルして、システムにより生成された値をアタッチし、[頂点シェーダー (VS) ステージ](vertex-shader-stage--vs-.md)、他のパイプライン ステージの順で使われるプリミティブとして値を出力します。

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
<td align="left"><p><a href="primitive-topologies.md">プリミティブ トポロジ</a></p></td>
<td align="left"><p>Direct3D では、ポイントの一覧、線の一覧、三角形ストリップなどのいくつかのプリミティブ トポロジがサポートされており、パイプラインにより頂点がどのように解釈され、レンダリングされるかを定義します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="using-system-generated-values.md">システムで生成される値の使用</a></p></td>
<td align="left"><p>システムにより生成された値は、入力アセンブラー (IA) ステージにより生成され (ユーザーが提供した入力<a href="https://msdn.microsoft.com/library/windows/desktop/bb509647">セマンティクス</a>に基づく)、シェーダー操作で一定の効率を実現します。 インスタンス ID (<a href="vertex-shader-stage--vs-.md">頂点シェーダー (VS) ステージ</a>で参照可能)、頂点 ID (VS で参照可能)、またはプリミティブ ID (<a href="geometry-shader-stage--gs-.md">ジオメトリ シェーダー (GS) ステージ</a>/<a href="pixel-shader-stage--ps-.md">ピクセル シェーダー (PS) ステージ</a>で参照可能) などのデータをアタッチするとにより、その後のシェーダー ストレージがそれらのシステム値を探して、そのステージでの処理を最適化できるようになります。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[グラフィックス パイプライン](graphics-pipeline.md)

 

 




