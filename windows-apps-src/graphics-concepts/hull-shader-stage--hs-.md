---
title: ハル シェーダー (HS) ステージ
description: ハル シェーダー (HS) ステージは、モデルの 1 つのサーフェスを効率的に多数の三角形に分割する、テセレーション ステージの 1 つです。
ms.assetid: C62F6F15-CAD7-4C72-9735-00762E346C4C
keywords:
- ハル シェーダー (HS) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9137f7ef46da1b861976dbac680327febf315dac
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8210285"
---
# <a name="hull-shader-hs-stage"></a>ハル シェーダー (HS) ステージ


ハル シェーダー (HS) ステージは、モデルの 1 つのサーフェスを効率的に多数の三角形に分割する、テセレーション ステージの 1 つです。 ハル シェーダー (HS) ステージは、各入力パッチ (クワッド、トライアングル、またはライン) に対応するジオメトリ パッチ (およびパッチ定数) を生成します。 ハル シェーダーは、パッチごとに 1 回呼び出され、低次サーフェスを定義する入力制御点を、パッチを構成する制御点に変換します。 また、ハル シェーダーは、いくつかのパッチごとの計算を行い、データを[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)と[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)に提供します。

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途


![ハル シェーダー ステージの図](images/d3d11-hull-shader.png)

テッセレーションの 3 つのステージは連携して、グラフィックス パイプライン内で、詳細なレンダリングを行うため高次のサーフェスを多数の三角形に変換しまず (これによりモデルはシンプルで効率的な状態に保たれます)。 テセレーション ステージには、ハル シェーダー (HS) ステージ、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)、および[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)が含まれます。

ハル シェーダー (HS) ステージは、プログラム可能なシェーダー ステージです。 ハル シェーダーは、HLSL 関数を使って実装されます。

ハル シェーダーは、制御点フェーズとパッチ定数フェーズの 2 つのフェーズで動作します。これらはハードウェアによって並行して実行されます。 HLSL コンパイラは、ハル シェーダーの並列処理を抽出し、ハードウェアを駆動するバイトコードにエンコードします。

-   制御点フェーズは制御点ごとに 1 回実行され、パッチの制御点を読み取り、1 つの出力制御点 (**ControlPointID** で識別される) を生成します。
-   パッチ定数フェーズは、パッチごとに 1 回実行され、エッジ テセレーション係数とその他のパッチごとの定数を生成します。 内部的には、複数のパッチ定数フェーズが同時に実行される場合があります。 パッチ定数フェーズでは、すべての入力制御点と出力制御点に対して読み取り専用アクセスの権限があります。

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力


1 ～ 32 個の入力制御点。これらがまとまって低次サーフェスを定義します。

-   ハル シェーダーは、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)で必要な状態を宣言します。 これには、テセレーションで使用する制御点の数、パッチ面の種類、分割の種類などの情報が含まれます。 この情報は、通常、シェーダー コードの最初に宣言として表示されます。
-   テセレーション係数は、各パッチを分割する程度を決定します。

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力


1 ～ 32 個の出力制御点。これらがまとまってパッチを構成します。

-   シェーダーの出力は、テセレーション係数の数に関係なく、1 ～ 32 個の制御点です。 ハル シェーダーから出力された制御点は、ドメイン シェーダー ステージで使用できます。 パッチ定数データは、ドメイン シェーダーで使用できます。 テセレーション係数は、[テッセレータ (TS) ステージ](tessellator-stage--ts-.md)と[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)で使用できます。
-   ハル シェーダーがいずれかのエッジ テセレーション係数を ≤ 0または NaN に設定する場合、パッチをカリングする (省略する) ことができます。 その結果、テッセレータ ステージは実行される場合と実行されない場合があり、ドメイン シェーダーは実行されず、そのパッチの表示出力は生成されません。

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例


```
[patchsize(12)]
[patchconstantfunc(MyPatchConstantFunc)]
MyOutPoint main(uint Id : SV_ControlPointID,
     InputPatch<MyInPoint, 12> InPts)
{
     MyOutPoint result;
     
     ...
     
     result = TransformControlPoint( InPts[Id] );

     return result;
}
```

「[方法: ハル シェーダーの作成](https://msdn.microsoft.com/library/windows/desktop/ff476338)」を参照してください。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[グラフィックス パイプライン](graphics-pipeline.md)

 

 




