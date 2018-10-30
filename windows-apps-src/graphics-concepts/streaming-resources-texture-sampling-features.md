---
title: ストリーミング リソース テクスチャ サンプリング機能
description: ストリーミング リソース テクスチャ サンプリングの機能は複数あります。たとえば、マップの領域についてシェーダー状態のフィードバックを取得する機能、アクセスされている全データがリソース内にマップされたかどうか確認する機能、マップされていないことがわかっているミップマップ ストリーミング リソース内の領域をシェーダーが避けられるようにクランプする機能、テクスチャ フィルターのフットプリント全体に完全にマップされる最小の LOD を検出する機能などがあります。
ms.assetid: C2B2DD69-8354-417A-894D-6235A8B48B53
keywords:
- ストリーミング リソース テクスチャ サンプリング機能
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 0066d38aaa3f5802ff5b1d380d405e60d90cad49
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5767666"
---
# <a name="streaming-resources-texture-sampling-features"></a>ストリーミング リソース テクスチャ サンプリング機能


ストリーミング リソース テクスチャ サンプリングの機能は複数あります。たとえば、マップの領域についてシェーダー状態のフィードバックを取得する機能、アクセスされている全データがリソース内にマップされたかどうか確認する機能、マップされていないことがわかっているミップマップ ストリーミング リソース内の領域をシェーダーが避けられるようにクランプする機能、テクスチャ フィルターのフットプリント全体に完全にマップされる最小の LOD を検出する機能などがあります。

## <a name="span-idrequirementsofstreamingresourcestexturesamplingfeaturesspanspan-idrequirementsofstreamingresourcestexturesamplingfeaturesspanspan-idrequirementsofstreamingresourcestexturesamplingfeaturesspanrequirements-of-streaming-resources-texture-sampling-features"></a><span id="Requirements_of_streaming_resources_texture_sampling_features"></span><span id="requirements_of_streaming_resources_texture_sampling_features"></span><span id="REQUIREMENTS_OF_STREAMING_RESOURCES_TEXTURE_SAMPLING_FEATURES"></span>ストリーミング リソース テクスチャ サンプリング機能の要件


ここで説明するテクスチャ サンプリング機能には、[階層 2](tier-2.md) レベルのストリーミング リソース サポートが必要です。

## <a name="span-idshaderstatusfeedbackaboutmappedareasspanspan-idshaderstatusfeedbackaboutmappedareasspanspan-idshaderstatusfeedbackaboutmappedareasspanshader-status-feedback-about-mapped-areas"></a><span id="Shader_status_feedback_about_mapped_areas"></span><span id="shader_status_feedback_about_mapped_areas"></span><span id="SHADER_STATUS_FEEDBACK_ABOUT_MAPPED_AREAS"></span>マップ領域についてのシェーダー状態のフィードバック


ストリーミング リソースの読み取りや書き込みをするシェーダー命令が発生すると、状態情報が記録されます。 この状態は、リソース アクセス命令が発生するたびに、省略可能な追加の戻り値として公開され、32 ビットの一時レジスタに保存されます。 この戻り値の内容は "不透明" です。 つまり、シェーダー プログラムによる直接の読み取りは認められていません。 ただし、[**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) 関数を使用して、状態情報を抽出できます。

## <a name="span-idfullymappedcheckspanspan-idfullymappedcheckspanspan-idfullymappedcheckspanfully-mapped-check"></a><span id="Fully_mapped_check"></span><span id="fully_mapped_check"></span><span id="FULLY_MAPPED_CHECK"></span>完全なマップのチェック


[**CheckAccessFullyMapped**](https://msdn.microsoft.com/library/windows/desktop/dn292083) 関数は、メモリ アクセスから返された状態を解釈し、アクセスされるすべてのデータがリソースにマップされていたかどうかを示します。 **CheckAccessFullyMapped** は、データがマップされている場合は true (0xFFFFFFFF) を、マップされていない場合は false (0x00000000) を返します。

フィルター操作中に、特定のテクセルの重み付けが 0.0 になることがあります。 例としては、テクセルの中央に直接置かれるテクスチャ座標を持つリニア サンプルです。3 つのその他のテクセル (どれが該当するかは、ハードウェアによって決まります) は、フィルターでは考慮されますが、重みは 0 です。 このような重みが 0 であるテクセルはフィルター結果にはまったく影響しないため、このようなテクセルが偶然 **NULL** タイルに適用された場合、マップされていないアクセスとしてカウントされません。 複数の mip レベルを含むテクスチャ フィルターにも、同じことが言えます。ミップマップの 1 つに適用されたテクセルがマップされていなくて、そのようなテクセルの重みが 0 の場合、それらのテクセルはマップされていないアクセスとしてカウントされません。

コンポーネント数が 4 個未満の形式 (DXGI\_FORMAT\_R8\_UNORM など) からサンプリングをする場合、結果のどのコンポーネントをシェーダーが実際に参照するかは問わず、**NULL** タイルに適用されるテクセルは、**NULL** マップ アクセスとしてレポートされます。 たとえば、シェーダーで R8\_UNORM から読み取りを行い、.gba/.yzw を使用して読み取り結果をマスクした場合、テクスチャの読み取りはまったく必要ないような結果になります。 ただし、テクセル アドレスが **NULL** マップ タイルの場合、操作はやはり **NULL** マップ アクセスとしてカウントされます。

シェーダーは状態を確認し、エラーが発生している場合は一連の対応策を実行できます。 たとえば、一連の対応策としては 'ミス' をログに記録すること (UAV 書き込みなど) であったり、より詳細度の低い、マップされていることがわかっている LOD にクランプした別の読み取りを発行することが該当します。 タイルのマップ済みセットのどの部分がアクセスされたかを把握するため、成功したアクセスもアプリケーションで追跡したい場合があります。

ログで 1 つ厄介なのは、アクセスされたと思われる一連のタイルを正確にレポートできるメカニズムが存在しないことです。 アプリケーションは、アクセスに使用した座標の知識を基に控えめに推測を行うことも、LOD 命令を使用することもできます。たとえば、[**tex2Dlod**](https://msdn.microsoft.com/library/windows/desktop/bb509680) はハードウェア LOD の計算を返します。

また、同じタイルに対して大量のアクセスが発生するため、冗長なログも大量に発生し、メモリで競合が起きる可能性があります。 タイルのアクセスについて別の場所で既にレポートされている場合は、レポートを不要にするオプションがハードウェアに用意されると便利である可能性があります。 おそらく、そのような追跡の状態は、(おそらくフレーム境界において) API からリセットできるでしょう。

## <a name="span-idper-sampleminlodclampspanspan-idper-sampleminlodclampspanspan-idper-sampleminlodclampspanper-sample-minlod-clamp"></a><span id="Per-sample_MinLOD_clamp"></span><span id="per-sample_minlod_clamp"></span><span id="PER-SAMPLE_MINLOD_CLAMP"></span>-サンプルごとの MinLOD クランプ


マップされていないことがわかっているミップマップ ストリーミング リソース内の領域をシェーダーが回避できるように、サンプラー (フィルタリング) の使用を伴うほとんどのシェーダー命令には、シェーダーが追加の float32 MinLOD クランプ パラメーターをテクスチャ サンプルに渡すことができるモードがあります。 基盤のリソースと異なり、この値はビューのミップマップ番号のスペースに保持されます。

ハードウェアは、リソースごとの MinLOD クランプが発生する LOD 計算において、同じ場所で ` max(fShaderMinLODClamp,fComputedLOD) ` を実行します。これは、[**max**](https://msdn.microsoft.com/library/windows/desktop/bb509624)() でもあります。

サンプラーに定義されているサンプルごとの LOD クランプとその他の LOD クランプを適用した結果、空のセットが返された場合、結果は、リソースごとの minLOD クランプの結果と同様に境界外アクセスになり、サーフェス形式内に存在するコンポーネントに対しては 0、欠落しているコンポーネントに対しては既定値が使用されます。

LOD 命令 ([**tex2Dlod**](https://msdn.microsoft.com/library/windows/desktop/bb509680) など) は、ここで説明しているサンプルごとの minLOD クランプよりも古く、クランプ LOD とクランプなしの LOD の両方を返します。 この LOD 命令から返されたクランプありの LOD は、リソースごとのクランプも含め、すべてのクランプを反映しますが、サンプルごとのクランプは反映されません。 サンプルごとのクランプは、いずれにせよシェーダーによって制御および認識されているため、必要に応じて、シェーダーの作成者は手動でそのクランプを LOD 命令の戻り値に適用できます。

## <a name="span-idminmaxreductionfilteringspanspan-idminmaxreductionfilteringspanspan-idminmaxreductionfilteringspanminmax-reduction-filtering"></a><span id="Min_Max_reduction_filtering"></span><span id="min_max_reduction_filtering"></span><span id="MIN_MAX_REDUCTION_FILTERING"></span>最小/最大除去フィルタリング


アプリケーションは、ストリーミング リソースのマッピングの状態を通知する独自のデータ構造を管理することもできます。 例としては、ストリーミング リソースのすべてのタイルの情報を保持するテクセルを含むサーフェスがあります。 たとえば、任意のタイルの場所でマップされている最初の LOD を保存する必要があるとします。 ストリーミング リソースをサンプリングする場合と同様の方法でこのデータ構造を慎重にサンプリングすることで、テクスチャー フィルターのフットプリント全体を完全にマップする最小の LOD はどのようになるかを知ることができます。 このプロセスを簡単にするため、Direct3D 11.2 では、最小/最大フィルタリングという新しい汎用サンプラー モードが導入されています。

LOD 追跡用の最小/最大フィルタリングのユーティリティは、おそらく深度サーフェスのフィルタリングなど、他の用途にも便利であると思われます。

最小/最大フィルタリングは、通常のテクスチャ フィルターがフェッチするのと同じテクセルのセットをフェッチするサンプラーのモードです。 ただし、値をブレンドして回答を出すのではなく、コンポーネントごとに、フェッチされたテクセルの min() または max() を返します (たとえば、すべての G 値の min とは別に、すべての R 値の min を返すなど)。

最小/最大操作は、Direct3D の演算精度のルールに従います。 比較の順序は問題になりません。

最小/最大フィルタリングではないフィルター操作中に、特定のテクセルの重み付けが 0.0 になることがあります。 例としては、テクセルの中央に直接置かれるテクスチャ座標を持つリニア サンプルです。この場合、3 つのその他のテクセル (どれが該当するかは、ハードウェアによって決まります) は、フィルターでは考慮されますが、重みは 0 です。 最小/最大フィルター以外のフィルターで重みが 0 になるテクセルの場合、最小/最大のフィルターを使用しても、このようなテクセルは結果に影響を及ぼしません (重みも最小/最大操作に影響しません)。

この機能のサポートは、ストリーミング リソースの[階層 2](tier-2.md) のサポートによって決まります。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[ストリーミング リソースへのパイプライン アクセス](pipeline-access-to-streaming-resources.md)

 

 




