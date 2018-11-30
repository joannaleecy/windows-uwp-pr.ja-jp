---
title: 出力マージャー (OM) ステージ
description: 出力マージャー (OM) ステージでは、各種出力データ (ピクセル シェーダー値、深度とステンシルの情報) をレンダー ターゲットおよび深度/ステンシル バッファーの内容と結合し、最終的なパイプラインの結果を生成します。
ms.assetid: ED2DC4A0-2B92-47AF-884A-BFC2183C78B8
keywords:
- 出力マージャー (OM) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 63a77048bed3ad27f2040a672d93380d0250f9aa
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8211820"
---
# <a name="output-merger-om-stage"></a>出力マージャー (OM) ステージ


出力マージャー (OM) ステージでは、各種出力データ (ピクセル シェーダー値、深度とステンシルの情報) をレンダー ターゲットおよび深度/ステンシル バッファーの内容と結合し、最終的なパイプラインの結果を生成します。

## <a name="span-idpurpose-and-usesspanspan-idpurpose-and-usesspanspan-idpurpose-and-usesspanpurpose-and-uses"></a><span id="Purpose-and-uses"></span><span id="purpose-and-uses"></span><span id="PURPOSE-AND-USES"></span>目的と用途


出力マージャー (OM) ステージは、表示するピクセルの決定 (深度ステンシル テストによる) と最終的なピクセル カラーのブレンディングを行うための最後のステップです。

OM ステージでは、次のものを組み合わせて使用することで、レンダリングされる最終的なピクセル カラーを生成します。

-   パイプライン ステート
-   ピクセル シェーダーによって生成されたピクセル データ
-   レンダー ターゲットの内容
-   深度/ステンシル バッファーの内容

### <a name="span-idblending-overviewspanspan-idblending-overviewspanspan-idblending-overviewspanblending-overview"></a><span id="Blending-overview"></span><span id="blending-overview"></span><span id="BLENDING-OVERVIEW"></span>ブレンディングの概要

ブレンディングは、1 つまたは複数のピクセル値を結合して、最終的なピクセル カラーを作成します。 次の図は、ピクセル データのブレンディングに関連するプロセスを示したものです。

![データのブレンディングのしくみ](images/d3d10-blend-state.png)

概念的には、このフロー チャートが出力マージャー ステージで 2 回実行されると考えることができます。RGB データのブレンディングと、それと並行して実行されるアルファ データのブレンディングです。 API を使用してブレンディング ステートを作成および設定する方法については「[ブレンド機能の構成](https://msdn.microsoft.com/library/windows/desktop/bb205072)」を参照してください。

固定機能ブレンディングは、レンダー ターゲットごとに個別に有効にすることができます。 ただし、ブレンディング制御は 1 組しかないため、ブレンディングが有効なすべての RenderTargets に同じブレンディングが適用されます。 ブレンディング値 (BlendFactor を含む) は常に、ブレンディング前にレンダー ターゲット フォーマットの範囲にクランプされます。 クランプは、レンダー ターゲット タイプを考慮して、レンダー ターゲットごとに実行されます。 ただし、クランプされない float16、float11、および float10 フォーマットは例外で、これらのフォーマットのブレンディング処理は、少なくとも出力フォーマットと同じ精度/範囲で実行できます。 NaN および符号付きのゼロは、すべての場合について伝搬されます (0.0 のブレンドの重みを含みます)。

sRGB レンダー ターゲットを使用する際、ランタイムはブレンディングを実行する前にレンダー ターゲットの色を線形空間に変換します。 ランタイムは、レンダー ターゲットに値を保存する前に、最終的なブレンドされた値をsRGB 空間に変換します。

### <a name="span-iddual-source-color-blendingspanspan-iddual-source-color-blendingspanspan-iddual-source-color-blendingspandual-source-color-blending"></a><span id="Dual-source-color-blending"></span><span id="dual-source-color-blending"></span><span id="DUAL-SOURCE-COLOR-BLENDING"></span>デュアルソースのカラー ブレンディング

この機能を使用すると、出力マージャーステージで、スロット 0 の 1 つのレンダー ターゲットを使用するブレンディング処理の入力として両方のピクセル シェーダー出力 (o0 および o1) を同時に使用することができます。 有効なブレンディング処理には、加算、減算、および逆減算があります。 ブレンドの式および出力書き込みマスクによって、ピクセル シェーダーが出力する成分が指定されます。 それ以外の成分は無視されます。

他のピクセル シェーダー出力 (o2、o3 など) への書き込みは定義されていません。スロット 0 にバインドされていない場合、レンダー ターゲットに書き込むことはできません。 デュアル ソースのカラー ブレンディング時には、oDepth の書き込みは有効です。

### <a name="span-iddepth-stencil-testspanspan-iddepth-stencil-testspanspan-iddepth-stencil-testspandepth-stencil-testing-overview"></a><span id="Depth-Stencil-Test"></span><span id="depth-stencil-test"></span><span id="DEPTH-STENCIL-TEST"></span>深度/ステンシル テストの概要

テクスチャ リソースとして作成される深度/ステンシル バッファーは、深度データとステンシル データの両方を格納できます。 深度データは、カメラに最も近い位置に配置されたピクセルを特定するために使用され、ステンシル データは、更新可能なピクセルをマスクするために使用されます。 最終的には、深度値とステンシル値のデータの両方が、ピクセルを描画する必要があるかどうかを決定するために出力マージャー ステージで使用されます。 次の図は、深度/ステンシル テストがどのように実行されるかを概念的に示したものです。

![深度/ステンシル テストのしくみ](images/d3d10-depth-stencil-test.png)

深度/ステンシル テストを構成する方法については、「[深度/ステンシル機能の構成](configuring-depth-stencil-functionality.md)」を参照してください。 深度/ステンシル オブジェクトは、深度/ステンシル ステートをカプセル化します。 アプリケーションでは深度/ステンシル ステートを指定することができ、指定しない場合は、OM ステージでデフォルト値が使用されます。 マルチサンプリングが無効な場合は、ピクセル単位でブレンディング処理が実行されます。 マルチサンプリングが有効な場合は、マルチサンプル単位でブレンディングが実行されます。

深度バッファーを使用して描画するピクセルを決定する処理は、深度バッファーリングと呼ばれます。また、z バッファーリングと呼ばれることもあります。

(補間とピクセル シェーダーのどちらから送信されたかに関係なく) 深度値が出力マージャー ステージに到達すると、常に、浮動小数点ルールを使用して、深度バッファーのフォーマット/精度に従って z = min(Viewport.MaxDepth,max(Viewport.MinDepth,z)) にクランプされます。 クランプ後、深度値は、DepthFunc を使用して既存の深度バッファー値と比較されます。 深度バッファーがバインドされていない場合は、常に深度テストに合格します。

深度バッファー フォーマットにステンシル成分がない場合、または深度バッファーがバインドされていない場合は、常にステンシル テストに合格します。

一度にアクティブにすることができる深度/ステンシル バッファーは 1 つだけです。バインドされたリソース ビューは、深度/ステンシル ビューと一致していなければなりません (サイズと次元が同じでなければなりません)。 これは、リソース サイズが一致していなければならないことを意味するものではなく、ビュー サイズが一致していればよいことを意味します。

### <a name="span-idsample-maskspanspan-idsample-maskspanspan-idsample-maskspansample-mask-overview"></a><span id="Sample-Mask"></span><span id="sample-mask"></span><span id="SAMPLE-MASK"></span>サンプル マスクの概要

サンプル マスクは、アクティブなレンダー ターゲットで更新されるサンプルを決定する 32 ビットのマルチサンプリング カバレッジ マスクです。 サンプル マスクは 1 つだけ使用できます。 サンプル マスク内のビットからリソース内のサンプルへのマッピングは、ユーザーが定義します。 n サンプル レンダリングの場合、サンプル マスクの (LSB から) 最初の n ビットが使用されます (最大ビット数は 32 ビットです)。

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力


出力マージャー (OM) ステージでは、次のものを組み合わせて使用することで、レンダリングされる最終的なピクセル カラーを生成します。

-   パイプライン ステート
-   ピクセル シェーダーによって生成されたピクセル データ
-   レンダー ターゲットの内容
-   深度/ステンシル バッファーの内容

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力


### <a name="span-idoutput-write-mask-overviewspanspan-idoutput-write-mask-overviewspanspan-idoutput-write-mask-overviewspanoutput-write-mask-overview"></a><span id="Output-write-mask-overview"></span><span id="output-write-mask-overview"></span><span id="OUTPUT-WRITE-MASK-OVERVIEW"></span>出力書き込みマスクの概要

出力書き込みマスクは、レンダー ターゲットに書き込むことができるデータを (成分ごとに) 制御するために使用します。

### <a name="span-idmultiple-render-targets-overviewspanspan-idmultiple-render-targets-overviewspanspan-idmultiple-render-targets-overviewspanmultiple-render-targets-overview"></a><span id="Multiple-render-targets-overview"></span><span id="multiple-render-targets-overview"></span><span id="MULTIPLE-RENDER-TARGETS-OVERVIEW"></span>複数のレンダー ターゲットの概要

1 つのピクセル シェーダーを使用して、少なくとも 8 つの別個のレンダー ターゲットにレンダリングすることができます。これらはすべて、同じタイプでなければなりません (バッファー、Texture1D、Texture1DArray など)。 さらに、レンダー ターゲットはすべて、すべての次元 (幅、高さ、奥行き、配列のサイズ、サンプル カウント) でサイズが同じでなければなりません。 各レンダー ターゲットでデータ フォーマットが異なっていてもかまいません。

レンダー ターゲット スロット (最大 8 つ) を任意の組み合わせで使用することができます。 ただし、リソース ビューを複数のレンダー ターゲット スロットに同時にバインドすることはできません。 複数のリソースが同時に使用されていない限り、ビューは再利用することができます。

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
<td align="left"><p><a href="configuring-depth-stencil-functionality.md">深度/ステンシル機能の構成</a></p></td>
<td align="left"><p>ここでは、出力マージャー ステージの深度/ステンシル バッファーと深度/ステンシル ステートを設定する手順について説明します。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[グラフィックス パイプライン](graphics-pipeline.md)

 

 




