---
title: 深度/ステンシル機能の構成
description: ここでは、深度/ステンシル バッファーと、出力結合ステージの深度/ステンシル ステートを設定する手順について説明します。
ms.assetid: B3F6CDAA-93ED-4DC1-8E69-972C557C7920
keywords:
- 深度/ステンシル機能の構成
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 98cb6c62248fbf273a9d7ca1ef0d1d82293122eb
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8881904"
---
# <a name="span-iddirect3dconceptsconfiguringdepth-stencilfunctionalityspanconfiguring-depth-stencil-functionality"></a><span id="direct3dconcepts.configuring_depth-stencil_functionality"></span>深度/ステンシル機能の構成


ここでは、深度/ステンシル バッファーと、出力結合ステージの深度/ステンシル ステートを設定する手順について説明します。

深度/ステンシル バッファーおよび対応する深度/ステンシル ステートの使用方法を理解したら、[高度なステンシル技法](#advanced-stencil-techniques)をご覧ください。

## <a name="span-idcreatedepthstencilstatespanspan-idcreatedepthstencilstatespanspan-idcreatedepthstencilstatespancreate-depth-stencil-state"></a><span id="Create_Depth_Stencil_State"></span><span id="create_depth_stencil_state"></span><span id="CREATE_DEPTH_STENCIL_STATE"></span>深度/ステンシル ステートの作成


深度/ステンシル ステートは、出力結合ステージで、[深度/ステンシル テスト](https://msdn.microsoft.com/library/windows/desktop/bb205120)を実行する方法を指定します。 深度/ステンシル テストは、特定のピクセルを描画するかどうかを決定します。

## <a name="span-idbinddepthstenciltotheomstagespanspan-idbinddepthstenciltotheomstagespanspan-idbinddepthstenciltotheomstagespanbind-depth-stencil-data-to-the-om-stage"></a><span id="Bind_Depth_Stencil_to_the_OM_Stage"></span><span id="bind_depth_stencil_to_the_om_stage"></span><span id="BIND_DEPTH_STENCIL_TO_THE_OM_STAGE"></span>深度/ステンシル データの OM ステージへのバインド


深度/ステンシル ステートをバインドします。

ビューを使用して、深度/ステンシル リソースをバインドします。

レンダー ターゲットは、すべて同じタイプのリソースである必要があります。 マルチサンプル アンチエイリアシングを使用する場合、バインドされたすべてのレンダー ターゲットおよび深度バッファーのサンプル カウントが同じでなければなりません。

バッファーをレンダー ターゲットとして使用する場合、深度/ステンシル テストと複数のレンダー ターゲットはサポートされません。

-   最大 8 個のレンダー ターゲットを同時にバインド可能です。
-   レンダー ターゲットはすべて、すべての次元 (幅、高さ、3D の場合は奥行き、\*Array 型の場合は配列サイズ) でサイズが同じでなければなりません。
-   各レンダー ターゲットでデータ形式が異なっていてもかまいません。
-   書き込みマスクは、レンダー ターゲットに書き込まれるデータを制御します。 出力書き込みマスクは、レンダー ターゲット単位および成分レベル単位で、レンダー ターゲットに書き込まれるデータを制御します。

## <a name="span-idadvancedstenciltechniquesspanspan-idadvancedstenciltechniquesspanspan-idadvancedstenciltechniquesspanspan-idadvanced-stencil-techniquesspanadvanced-stencil-techniques"></a><span id="Advanced_Stencil_Techniques"></span><span id="advanced_stencil_techniques"></span><span id="ADVANCED_STENCIL_TECHNIQUES"></span><span id="advanced-stencil-techniques"></span>高度なステンシル技法


深度/ステンシル バッファーのステンシル部分は、合成、デカール、および輪郭処理などのレンダリング エフェクトを作成するために使用できます。

-   [合成](#compositing)
-   [デカール](#decaling)
-   [輪郭とシルエット](#outlines-and-silhouettes)
-   [2 面ステンシル](#two-sided-stencil)
-   [深度/ステンシル バッファーをテクスチャとして読み取る](#reading-the-depth-stencil-buffer-as-a-texture)

### <a name="span-idcompositingspanspan-idcompositingspanspan-idcompositingspancompositing"></a><span id="Compositing"></span><span id="compositing"></span><span id="COMPOSITING"></span>合成

ステンシル バッファーを使えば、アプリケーションは 2D または 3D 画像を 3D シーンに合成できます。 ステンシル バッファーのマスクを使って、レンダー ターゲット サーフェスの領域をオクルードします。 次に、テキストやビットマップなどの格納 2D 情報をオクルードされた領域に書き込むことができます。 別の方法として、アプリケーションでは追加 3D プリミティブをレンダー ターゲット サーフェスのステンシル マスクされた領域にレンダリングできます。 この場合、シーン全体をレンダリングすることもできます。

ゲームでは、複数の 3D シーンを合成することがよくあります。 たとえば、ドライビング ゲームでは通常バックミラーを表示します。 バックミラーには、運転者の背後の 3D シーンの表示が含まれます。 したがって、バックミラーは、本質的には運転者の前方の風景と合成された 第 2 の 3D シーンと言えます。

### <a name="span-iddecalingspanspan-iddecalingspanspan-iddecalingspandecaling"></a><span id="Decaling"></span><span id="decaling"></span><span id="DECALING"></span>デカール

Direct3D アプリケーションでは、デカールを使用して、レンダー ターゲット サーフェスに描画される特定のプリミティブ イメージのピクセルを制御します。 アプリケーションはプリミティブのイメージにデカールを適用して、同一平面上のポリゴンを適切にレンダリングできるようにします。

たとえば、道路にタイヤの跡と黄色い線を付ける場合、その跡は道路の上に直接表示する必要があります。 ただし、タイヤ跡と道路の z 値は同一です。 したがって、深度バッファーでは、これら 2 つを明確に分離できない場合があります。 背面のプリミティブの一部のピクセルが前面のプリミティブの手前にレンダリングされたり、その逆になったりする場合があります。 出力されるイメージは、フレームが変わるたびにちらついているように見えます。 この現象は、z ファイティングまたはフリマリングと呼ばれます。

この問題を解決するには、ステンシルを使用して、デカールが表示される背面プリミティブのセクションをマスクします。 z バッファリングをオフにし、レンダー ターゲット サーフェスのマスク オフされた領域に前面プリミティブのイメージをレンダリングします。

複数のテクスチャ ブレンディングを使用することで、この問題を解決できます。

### <a name="span-idoutlinesandsilhouettesspanspan-idoutlinesandsilhouettesspanspan-idoutlinesandsilhouettesspanspan-idoutlines-and-silhouettesoutlines-and-silhouettes"></a><span id="Outlines_and_Silhouettes"></span><span id="outlines_and_silhouettes"></span><span id="OUTLINES_AND_SILHOUETTES"></span><span id="outlines-and-silhouettes">輪郭とシルエット

輪郭処理やシルエット処理など、より抽象的なエフェクトにステンシル バッファーを使用することができます。

アプリケーションに 2 つのレンダリング パスがある場合、一方はステンシル マスクを生成するためのもので、もう一方はイメージにステンシル マスクを適用するためのものとすると、2 番目のパスのプリミティブが多少小さいときは、出力されるイメージがプリミティブの輪郭のみになります。 その場合、ステンシルでマスクされたイメージの領域を単色で塗りつぶすことで、プリミティブが浮き上がって見えるようにすることができます。

ステンシル マスクが、レンダリングするプリミティブと同じサイズおよび形状の場合、出力されるイメージではプリミティブの位置が穴になります。 その場合、穴を黒で塗りつぶすことで、プリミティブのシルエットを作成できます。

### <a name="span-idtwosidedstencilspanspan-idtwosidedstencilspanspan-idtwosidedstencilspantwo-sided-stencil"></a><span id="Two_Sided_Stencil"></span><span id="two_sided_stencil"></span><span id="TWO_SIDED_STENCIL"></span>2 面ステンシル

シャドウ ボリュームは、ステンシル バッファーで影を描画するために使用します。 オクルーディング ジオメトリによってキャストされたシャドウ ボリュームは、シルエットの縁を計算し、ライトと反対側の 3D ボリューム セットに押し出すことによって計算されます。 これらのボリュームはその後、ステンシル バッファーに 2 回レンダリングされます。

最初のレンダリングでは、前向きのポリゴンが描画され、ステンシル バッファーの値が増加します。 2 回目のレンダリングでは、シャドウ ボリュームの後ろ向きのポリゴンが描画され、ステンシル バッファーの値が減少します。

通常、増加したり減少のすべての値をキャンセル互いします。ただし、シーンでは、シャドウ ボリュームがレンダリングされる z バッファー テストが失敗するピクセルのいくつかの原因と通常のジオメトリでレンダリングされています。 ステンシル バッファーに残された値は、シャドウのピクセルに対応します。 ステンシル バッファーの残りの内容は、すべてを覆う大きな黒のクワッドをシーンにアルファ ブレンディングするために、マスクとして使用されます。 マスクとして機能するステンシル バッファーを使用すると、シャドウ内のピクセルが暗くなります。

これは、シャドウ ジオメトリが光源ごとに 2 回描画されることを意味するため、GPU の頂点処理のスループットに影響します。 2 面ステンシル機能は、この状況を軽減することを目的として設計されています。 この方法には、(次の) 2 組のステンシル ステートがあります。一方は前向きの三角形のそれぞれに設定され、もう一方は後ろ向きの三角形に設定されます。 このようにして、光源ごとにシャドウ ボリューム単位で 1 つのパスのみが描画されます。

### <a name="span-idreadingthedepth-stencilbufferasatexturespanspan-idreadingthedepth-stencilbufferasatexturespanspan-idreadingthedepth-stencilbufferasatexturespanspan-idreading-the-depth-stencil-buffer-as-a-texturespanreading-the-depth-stencil-buffer-as-a-texture"></a><span id="Reading_the_Depth-Stencil_Buffer_as_a_Texture"></span><span id="reading_the_depth-stencil_buffer_as_a_texture"></span><span id="READING_THE_DEPTH-STENCIL_BUFFER_AS_A_TEXTURE"></span><span id="reading-the-depth-stencil-buffer-as-a-texture"></span>深度/ステンシル バッファーをテクスチャとして読み取る

アクティブでない深度/ステンシル バッファーを、シェーダーでテクスチャとして読み取ることができます。 深度/ステンシル バッファーをテクスチャとして読み取るアプリケーションでは 2 つのパスでレンダリングします。最初のパスでは深度/ステンシル バッファーに書き込み、2 番目のパスではそのバッファーから読み取ります。 これにより、シェーダーはそれまでにバッファーに書き込んだ深度またはステンシルの値を、現在レンダリング中のピクセルの値と比較できます。 この比較の結果を使用して、シャドー マッピングやソフト パーティクルなどのエフェクトをパーティクル システムで作成できます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[出力結合 (OM) ステージ](output-merger-stage--om-.md)

[グラフィックス パイプライン](graphics-pipeline.md)

[出力結合 (OM) ステージ](https://msdn.microsoft.com/library/windows/desktop/bb205120)
