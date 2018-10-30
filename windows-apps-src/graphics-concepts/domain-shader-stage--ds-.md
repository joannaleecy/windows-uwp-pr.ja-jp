---
title: ドメイン シェーダー (DS) ステージ
description: ドメイン シェーダー (DS) ステージでは、パッチ内の細分化されたポイントの頂点の位置を計算します。つまり、各ドメイン サンプルに対応する頂点の位置を計算します。
ms.assetid: 673CC04A-A74F-495F-AFB7-49157538749C
keywords:
- ドメイン シェーダー (DS) ステージ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 3bcad4a5e22249d4d7faed08fe9cc9af4c3fb338
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5753285"
---
# <a name="domain-shader-ds-stage"></a>ドメイン シェーダー (DS) ステージ


ドメイン シェーダー (DS) ステージでは、パッチ内の細分化されたポイントの頂点の位置を計算します。つまり、各ドメイン サンプルに対応する頂点の位置を計算します。 ドメイン シェーダーは、テッセレータ ステージの出力ポイントごとに 1 回実行され、ハル シェーダーの出力パッチや出力パッチ定数、およびテッセレータ ステージの出力 UV 座標への読み取り専用アクセスが可能です。

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途


ドメイン シェーダー (DS) ステージは、[ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md)と[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)からの入力に基づいて、出力パッチ内の細分化されたポイントの頂点の位置を出力します。

![ドメイン シェーダー ステージの図](images/d3d11-domain-shader.png)

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力


-   ドメイン シェーダーは、[ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md)からの出力の制御点を利用します。 ハル シェーダーの出力には次の項目が含まれます。
    -   制御点。
    -   パッチ定数データ。
    -   テセレーション係数。 テセレーション係数には、未処理の値 (整数テセレーションによる丸めの前など) と共に、固定機能テッセレータで使われる値を含めることができます。
-   ドメイン シェーダーは、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)からの出力座標ごとに 1 回呼び出されます。

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力


-   ドメイン シェーダー (DS) ステージでは、出力パッチ内の細分化されたポイントの頂点の位置を出力します。

ドメイン シェーダーが完了すると、テセレーションは終了し、パイプライン データは、[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)や[ピクセル シェーダー (PS) ステージ](pixel-shader-stage--ps-.md)など、次のパイプライン ステージで処理が続行されます。 隣接性を持つプリミティブ (三角形ごとに 6 個の頂点など) を想定するジオメトリ シェーダーは、テセレーションがアクティブな場合には有効ではありません (これは未定義の動作となり、デバッグ レイヤーで問題が検出されます)。

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例


```
void main( out    MyDSOutput result, 
           float2 myInputUV : SV_DomainPoint, 
           MyDSInput DSInputs,
           OutputPatch<MyOutPoint, 12> ControlPts, 
           MyTessFactors tessFactors)
{
     ...

     result.Position = EvaluateSurfaceUV(ControlPoints, myInputUV);
}
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[グラフィックス パイプライン](graphics-pipeline.md)

 

 




