---
title: 状態オブジェクト
description: デバイスの状態は状態オブジェクトを使用してグループ化されます。それにより、状態変更のコストが大幅に削減されます。 状態オブジェクトは数種類あり、それぞれ、特定のパイプライン ステージ向けに一連の状態を初期化することを目的としています。 状態オブジェクトは、Direct3D のバージョンによって異なります。
ms.assetid: D998745C-2B75-4E59-9923-AD1A17A92E05
keywords:
- 状態オブジェクト
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 3437119979073a5cec27948fc90f954e06c2fc93
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8202810"
---
# <a name="state-objects"></a>状態オブジェクト


デバイスの状態は状態オブジェクトを使用してグループ化されます。それにより、状態変更のコストが大幅に削減されます。 状態オブジェクトは数種類あり、それぞれ、特定のパイプライン ステージ向けに一連の状態を初期化することを目的としています。 状態オブジェクトは、Direct3D のバージョンによって異なります。

## <a name="span-idinputlayoutspanspan-idinputlayoutspanspan-idinputlayoutspaninput-layout-state"></a><span id="Input_Layout"></span><span id="input_layout"></span><span id="INPUT_LAYOUT"></span>入力レイアウトの状態


この状態のグループは、[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)で、入力バッファーからデータを読み取り、頂点シェーダーによって使用できるようにアセンブルする方法を指定します。 これには、入力バッファー内の要素数や、入力データの署名などの状態が含まれます。 入力アセンブラー (IA) ステージでは、メモリからパイプラインにプリミティブをストリーミングします。

## <a name="span-idrasterizerspanspan-idrasterizerspanspan-idrasterizerspanrasterizer-state"></a><span id="Rasterizer"></span><span id="rasterizer"></span><span id="RASTERIZER"></span>ラスタライザーの状態


この状態のグループは、[ラスタライザー (RS) ステージ](rasterizer-stage--rs-.md)を初期化します。 このオブジェクトには、塗りつぶしやカリングのモード、クリッピングでのシザリング四角形の有効化、マルチサンプル パラメーターの設定などの状態が含まれます。 このステージでは、プリミティブをピクセルにラスタライズし、クリッピングやプリミティブのビューポートへのマッピングなどの操作を実行します。

## <a name="span-iddepthstencilspanspan-iddepthstencilspanspan-iddepthstencilspandepth-stencil-state"></a><span id="DepthStencil"></span><span id="depthstencil"></span><span id="DEPTHSTENCIL"></span>深度ステンシルの状態


この状態のグループは、[出力マージャー (OM) ステージ](output-merger-stage--om-.md)の深度ステンシルの部分を初期化します。 具体的には、このオブジェクトは、深度とステンシルのテストを初期化します。

## <a name="span-idblendspanspan-idblendspanspan-idblendspanblend-state"></a><span id="Blend"></span><span id="blend"></span><span id="BLEND"></span>ブレンドの状態


この状態のグループは、[出力マージャー (OM) ステージ](output-merger-stage--om-.md)のブレンドの部分を初期化します。

## <a name="span-idsamplerspanspan-idsamplerspanspan-idsamplerspansampler-state"></a><span id="Sampler"></span><span id="sampler"></span><span id="SAMPLER"></span>サンプラーの状態


この状態のグループは、サンプラー オブジェクトを初期化します。 サンプラー オブジェクトは、シェーダー ステージにおいて、メモリ内のフィルター テクスチャに対して使用されます。

Direct3D では、サンプラー オブジェクトは特定のテクスチャにはバインドされません。アタッチされているリソースがある場合に、フィルタリングを実行する方法を記述します。

## <a name="span-idperformanceconsiderationsspanspan-idperformanceconsiderationsspanspan-idperformanceconsiderationsspanperformance-considerations"></a><span id="Performance_Considerations"></span><span id="performance_considerations"></span><span id="PERFORMANCE_CONSIDERATIONS"></span>パフォーマンスに関する考慮事項


状態オブジェクトを使用するように API を設計すると、いくつかパフォーマンス上のメリットが得られます。 これには、オブジェクト作成時の状態の検証、ハードウェアでの状態オブジェクトのキャッシュの実現、(状態ではなく状態へのハンドルを渡すことで) 状態設定 API 呼び出し中に渡される状態の量の大幅な削減などが含まれます。

このようなパフォーマンスの向上を実現するには、アプリケーションの起動時 (レンダー ループのかなり前の時点) に状態オブジェクトを作成します。 状態オブジェクトは変更できません。つまり、一度作成されると、変更できません。 変更する場合は破棄して作成し直す必要があります。

サンプラーの状態の組み合わせを変えることで、数種類のサンプラー オブジェクトを作成できます。 その後、適切な "Set" API を呼び出すことで、サンプラーの状態を変更します。この API によって (サンプラーの状態ではなく) ハンドルがオブジェクトに渡されます。 これにより、呼び出しの回数とデータ量が大幅に削減されるため、状態変更のレンダー フレームごとにオーバーヘッドが大幅に削減されます。

または、アプリケーションの状態オブジェクトの効率的な作成と破棄を自動的に管理する効果オブジェクトを使用することもできます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[グラフィックス パイプライン](graphics-pipeline.md)

[ビュー](views.md)

 

 




