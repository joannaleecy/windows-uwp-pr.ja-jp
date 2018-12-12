---
title: テッセレータ (TS) ステージ
description: テッセレータ (TS) ステージは、ジオメトリ パッチを表すドメインのサンプリング パターンを作成し、サンプルを接続する一連の小さいオブジェクト (三角形、点、または線) を生成します。
ms.assetid: 2F006F3D-5A04-4B3F-8BC7-55567EFCFA6C
keywords:
- テッセレータ (TS) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7768d63405281d3155affc6c9f09c62568761718
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8945509"
---
# <a name="tessellator-ts-stage"></a>テッセレータ (TS) ステージ


テッセレータ (TS) ステージは、ジオメトリ パッチを表すドメインのサンプリング パターンを作成し、サンプルを接続する一連の小さいオブジェクト (三角形、点、または線) を生成します。

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途


次の図は、Direct3D のグラフィックス パイプラインのステージを示しています。

![ハル シェーダー、テッセレータ、およびドメイン シェーダー ステージを示す Direct3D 11 のパイプラインの図](images/d3d11-pipeline-stages-tessellation.png)

次の図は、テッセレーション ステージのプログレッションを示しています。

![テッセレーションのプログレッションの図](images/tess-prog.png)

プログレッションは、詳細度の低いサブ サーフェスから開始します。 次に、これらのサンプルを接続する、対応するジオメトリ パッチ、ドメイン サンプル、および三角形を使用して入力パッチがハイライトされます。 最後に、これらのサンプルに対応する頂点がハイライトされます。

Direct3D ランタイムは、テッセレーションを実装する 3 ステージをサポートします。テッセレーションは、GPU 上で詳細度の低いサブディビジョン サーフェスを詳細度の高いプリミティブに変換します。 テッセレーションは、高次サーフェスをレンダリングに適した構造体にタイル化 (または分割) します。

テッセレーションの各ステージは連携して、Direct3D グラフィックス パイプライン内で、詳細なレンダリングを行うため高次のサーフェスを多数の三角形に変換しまず (これによりモデルはシンプルで効率的な状態に保たれます)。

テッセレーションは GPU を使用して、クワッド パッチ、トライアングル パッチまたは等値線から作成されたサーフェスから、より詳細なサーフェスを計算します。 高次サーフェスを概算するには、テッセレーション係数を使用して各パッチを三角形、点、線に分割します。 Direct3D グラフィックス パイプラインは、3 つのパイプライン ステージを使用してテッセレーションを実装します。

-   [ハル シェーダー (HS) ステージ](hull-shader-stage--hs-.md) - 各入力パッチ (クワッド、トライアングル、またはライン) に対応するジオメトリ パッチ (およびパッチ定数) を生成するプログラム可能なシェーダー ステージです。
-   テッセレータ (TS) ステージ - ジオメトリ パッチを表すドメインのサンプリング パターンを作成し、サンプルを接続する一連の小さいオブジェクト (三角形、点、または線) を生成する固定機能パイプライン ステージです。
-   [ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md) - 各ドメイン サンプルに対応する頂点の位置を計算するプログラム可能なシェーダー ステージです。

ハードウェアにテッセレーションを実装すると、グラフィック パイプラインは、詳細度の低い (ポリゴン数の少ない) モデルを評価して、より高い詳細度でレンダリングできます。 ソフトウェア テッセレーションも可能ですが、ハードウェアにより実装されたテッセレーションでは、モデル サイズに表示の詳細を追加したり、リフレッシュ レートを無効化しなくても、非常に精細な表示 (ディスプレースメント マッピングのサポートを含む) を実現できます。

テセレーションの利点:

-   大量のメモリーおよび帯域幅を節約します。これにより、アプリケーションがより詳細なサーフェスを低解像度モデルからレンダリングできるようになります。 Direct3D グラフィックス パイプラインに実装されているテッセレーション手法では、非常に詳細なサーフェスを実現できるディスプレースメント マッピングもサポートしています。
-   随時計算可能な連続的または表示依存の詳細レベルなどのスケーラブルなレンダリング手法をサポートします。
-   負荷の大きい計算の頻度を下げる (詳細度の低いモデルで計算を実行する) ことで、パフォーマンスを向上します。 これには、リアルなアニメーションを実現するためのブレンド形状またはモーフ ターゲットを使用したブレンディング計算、または衝突検出用や軟体力学用の物理計算があります。

Direct3D グラフィックス パイプラインは、ハードウェアでテッセレーションを実装し、CPU から GPU に処理をオフロードします。 アプリケーションが多数のモーフ ターゲットや洗練されたスキニング/変形モデルを実装している場合、パフォーマンスの大幅な向上を実現できます。

テッセレーションは、[ハル シェーダー](hull-shader-stage--hs-.md)をパイプラインにバインドすることで初期化される固定機能ステージです。 (「[How To: Initialize the Tessellator Stage](https://msdn.microsoft.com/library/windows/desktop/ff476341)」(方法: テッセレーション ステージの初期化) を参照)。 テッセレータ ステージの目的は、ドメイン (クワッド、トライアングル、またはライン) を多数のより小さいオブジェクト (三角形、点または線) に分割することです。 テッセレータは、正規のドメインを標準化された (0 ～ 1 の) 座標系でタイル化します。 たとえば、クワッド ドメインは、単位正方形にテッセレーションされます。 

### <a name="span-idphasesinthetessellatortsstagespanspan-idphasesinthetessellatortsstagespanspan-idphasesinthetessellatortsstagespanphases-in-the-tessellator-ts-stage"></a><span id="Phases_in_the_Tessellator__TS__stage"></span><span id="phases_in_the_tessellator__ts__stage"></span><span id="PHASES_IN_THE_TESSELLATOR__TS__STAGE"></span>テッセレータ (TS) ステージのフェーズ

テッセレータ (TS) ステージは次の 2 つのフェーズで動作します。

-   最初のフェーズでは、32 ビット浮動小数点演算を使用して、テッセレーション係数を処理して丸めの問題を解決した後、非常に小さい係数を処理することで係数の削減および結合を行います。
-   2 番目のフェーズでは、選択したパーティションの種類に基づいてポイント リストまたはトポロジ リストを生成します。 これはテッセレータ ステージの中核タスクで、固定小数点演算の 16 ビットの小数を使用します。 固定小数点演算により、許容範囲内の精度を維持しつつハードウェアを加速化できます。 たとえば、64 メートル幅のパッチの場合、この精度を 2mm の解像度の点にできます。

    | パーティションの種類 | 範囲                       |
    |----------------------|-----------------------------|
    | Fractional\_odd      | \[1...63\]                  |
    | Fractional\_even     | TessFactor 範囲: \[2..64\] |
    | Integer              | TessFactor 範囲: \[1..64\] |
    | Pow2                 | TessFactor 範囲: \[1..64\] |

     

テッセレーションは、[ハル シェーダー](hull-shader-stage--hs-.md)と[ドメイン シェーダー](domain-shader-stage--ds-.md)の 2 つのプログラム可能なシェーダー ステージにより実装されます。 これらのシェーダー ステージは、シェーダー モデル 5 で定義された HLSL コードでプログラムされます。 シェーダー ターゲットは hs\_5\_0 と ds\_5\_0 です。 タイトルによってシェーダーが作成され、その後、シェーダーがパイプラインにバインドされるときにランタイムに渡されるコンパイル済みのシェーダーから、ハードウェア用のコードが抽出されます。

### <a name="span-idenablingdisablingtessellationspanspan-idenablingdisablingtessellationspanspan-idenablingdisablingtessellationspanenablingdisabling-tessellation"></a><span id="Enabling_disabling_tessellation"></span><span id="enabling_disabling_tessellation"></span><span id="ENABLING_DISABLING_TESSELLATION"></span>テッセレーションの有効化/無効化

テッセレーションは、ハル シェーダーを作成し、これをハル シェーダー ステージにバインドすることによって有効にします (これにより、テッセレータ ステージが自動的にセットアップされます)。 テッセレーションされたパッチから最終的な頂点位置を生成するには、[ドメイン シェーダー](domain-shader-stage--ds-.md)を作成し、これをドメイン シェーダー ステージにバインドする必要があります。 テッセレーションが有効になると、入力アセンブラー (IA) ステージに入力するデータは、パッチ データである必要があります。 つまり、入力アセンブラー トポロジは、パッチ定数トポロジである必要があります。

テッセレーションを無効にするには、ハル シェーダーおよびドメイン シェーダーを **NULL** に設定します。 [ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)と [ストリーム出力 (SO) ステージ](stream-output-stage--so-.md)のいずれも、ハル シェーダーの出力コントロール ポイントまたはパッチ データを読み取れません。

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力


テッセレータは、ハル シェーダー ステージから渡されるテッセレーション係数 (ドメインをどの程度詳細にテッセレーションするかを指定する) およびパーティションの種類 (パッチのスライスに使用するアルゴリズムを指定する) を使用して、パッチごとに 1 回動作します。

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力


テッセレータは、uv (およびオプションとして w) 座標およびサーフェス トポロジをドメイン シェーダー ステージに出力します。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[グラフィックス パイプライン](graphics-pipeline.md)

 

 




