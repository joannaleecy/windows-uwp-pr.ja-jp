---
title: 計算パイプライン
description: Direct3D 計算パイプラインは、大部分がグラフィックス パイプラインと並行して実行可能な計算を処理できるように設計されています。
ms.assetid: 355B66C6-C0DF-47BA-A9C9-7AFA50B5B614
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 911546f1c2973a79aea4b597a47352149a4e4210
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651117"
---
# <a name="compute-pipeline"></a>計算パイプライン


\[いくつかの情報は、リリース版の発売までに著しく変更される可能性がありますが、リリース前の製品に関連します。 Microsoft では、一切の保証、明示または黙示にかかわらず、ここで提供される情報はありません。\]


Direct3D 計算パイプラインは、大部分がグラフィックス パイプラインと並行して実行可能な計算を処理できるように設計されています。 計算パイプラインには、プログラム可能な計算シェーダー ステージを介して入力から出力へデータが流れる、わずかなステップしかありません。

| | |
|-|-|
|目的|他のプログラム可能なシェーダーと同様に、[計算シェーダー (CS) ステージ](compute-shader-stage--cs-.md)は、HLSL を使って設計され、実装されています。 計算シェーダーは、高速な汎用コンピューティングを提供し、グラフィックス処理装置 (GPU) 上の多数の並列プロセッサを利用します。 計算シェーダーは、メモリ共有とスレッド同期機能を提供し、より効果的な並列プログラミング手法を可能にします。|
|入力|他のプログラム可能なシェーダーとは異なり、入力は抽象定義です。 入力は、1 次元、2 次元または 3 次元とすることができ、実行する計算シェーダーの呼び出し回数を決定します。 1 セットの読み込み呼び出しのために、共有データを定義することができます。|
|出力|計算シェーダーからの出力データは、大幅に変化する場合がありますが、計算データが必要な場合には、グラフィックス レンダリング パイプラインと同期させることができます。|
| | |




<!---
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<tbody>
<tr class="odd">
<td align="left">Purpose</td>
<td align="left">Like other programmable shaders, <a href="#compute-shader-stage--cs-.md">Compute Shader (CS) stage</a> is designed and implemented with HLSL. A compute shader provides high-speed general purpose computing and takes advantage of the large numbers of parallel processors on the graphics processing unit (GPU). The compute shader provides memory sharing and thread synchronization features to allow more effective parallel programming methods.</td>
</tr>
<tr class="even">
<td align="left">Input</td>
<td align="left">Unlike other programmable shaders, the definition of input is abstract. The input can be one, two or three-dimensional in nature, determining the number of invocations of the compute shader to execute. It is possible to define shared data for one set of invocations to read.</td>
</tr>
<tr class="odd">
<td align="left">Output</td>
<td align="left">Output data from the compute shader, which can be highly varied, can be synchronized with the graphics rendering pipeline when the computed data is required.</td>
</tr>
</tbody>
</table>
-->

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[Direct3D グラフィックス学習ガイド](index.md)

 

 
