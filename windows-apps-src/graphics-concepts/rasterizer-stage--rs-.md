---
title: ラスタライザー (RS) ステージ
description: ラスタライザーは、表示されないプリミティブをトリミングし、ピクセル シェーダー (PS) ステージ用にプリミティブを準備して、ピクセル シェーダーを呼び出す方法を決定します。
ms.assetid: 7E80724B-5696-4A99-91AF-49744B5CD3A9
keywords:
- ラスタライザー (RS) ステージ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 17d58a05a57fa833003b7c229db91473f6cde3d4
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/25/2018
ms.locfileid: "5545723"
---
# <a name="rasterizer-rs-stage"></a>ラスタライザー (RS) ステージ


ラスタライザーは、表示されないプリミティブをトリミングし、[ピクセル シェーダー (PS) ステージ](pixel-shader-stage--ps-.md)用にプリミティブを準備して、ピクセル シェーダーを呼び出す方法を決定します。 ラスター化ステージは、リアルタイム 3D グラフィックスを表示するために、(図形やプリミティブで構成された) ベクター情報を (ピクセルで構成された) ラスター画像に変換します。

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途


ラスター化時には、各プリミティブがピクセルに変換され、各プリミティブでは頂点単位の値が補間されます。 ラスター化では、視錘台に対する頂点のクリッピング、パースペクティブを求めるための z での除算、2D ビューポートへのプリミティブのマッピング、およびピクセル シェーダーの呼び出し方法の決定などが行われます。 ピクセル シェーダーの使用は省略できますが、ラスタライザー ステージでは常に、クリッピング、点を同次空間に変換するための透視除算、およびビューポートへの頂点のマッピングが実行されます。

ラスター化を無効にするには、ピクセル シェーダーが存在しないことをパイプラインに通知します ([ピクセル シェーダー ステージ (PS)](pixel-shader-stage--ps-.md) を **NULL** に設定して、深度およびステンシル テストを無効にします)。 無効になっている間、ラスター化関連のパイプライン カウンターは更新されません。

階層型 Z バッファー最適化を実装しているハードウェアでは、深度およびステンシル テストを有効にしたままピクセル シェーダー (PS) ステージを **NULL** に設定することで、Z バッファーを事前に読み込むことができます。

「[ラスター化ルール](rasterization-rules.md)」もご覧ください。

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力


ラスタライザー ステージに渡される頂点 (x、y、z、w) は同次クリップ空間と見なされます。 この座標空間では、X 軸は右向き、Y 軸は上向き、Z 軸はカメラから遠ざかる方向を向きます。

固定関数のラスタライザー (RS) ステージは、ストリーム出力 (SO) ステージや、[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)などの前のパイプライン ステージから入力を受け取ります。 GS が使用されていない場合、RS は[ドメイン シェーダー (DS) ステージ](domain-shader-stage--ds-.md)から入力を受け取ります。 DS も使用されていない場合、RS は[頂点シェーダー (VS) ステージ](vertex-shader-stage--vs-.md)から入力を受け取ります。

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力


ピクセル シェーダー (PS) ステージの使用は省略できます。代わりに、ラスタライザー ステージから[出力結合 (OM) ステージ](output-merger-stage--om-.md)に直接出力することができます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ラスター化ルール](rasterization-rules.md)

[グラフィックス パイプライン](graphics-pipeline.md)

 

 




