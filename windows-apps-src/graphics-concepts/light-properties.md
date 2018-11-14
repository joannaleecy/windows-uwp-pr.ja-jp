---
title: 光源のプロパティ
description: 光源のプロパティは、光源の種類 (ポイント、指向性、スポットライト)、減衰、色、方向、位置、範囲を表します。
ms.assetid: E832C3FD-9921-41C4-87B8-056E16B61B77
keywords:
- 光源のプロパティ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 07a465d8fdcd1d425ed62e8d83cadd261f316da2
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6255402"
---
# <a name="light-properties"></a>光源のプロパティ


光源のプロパティは、光源の種類 (ポイント、指向性、スポットライト)、減衰、色、方向、位置、範囲を表します。 使う光源の種類に応じて、光源には減衰および範囲のプロパティや、スポットライト効果のプロパティがあります。 すべての種類の光源がすべてのプロパティを使うわけではありません。

位置、範囲、および減衰プロパティは、ワールド空間における光源の位置と放射された光が遠くまで届くとどうなるかを定義します。

## <a name="span-idlightattenuationspanspan-idlightattenuationspanspan-idlightattenuationspanlight-attenuation"></a><span id="Light_Attenuation"></span><span id="light_attenuation"></span><span id="LIGHT_ATTENUATION"></span>光の減衰


減衰は、範囲プロパティによって指定された最大距離にいたるまでに光の強さがどのように弱くなっていくかを制御します。 光の減衰を表すために、浮動小数点値 Attenuation0、Attenuation1、Attenuation2 が使われることがあります。 これらの浮動小数点値の範囲は 0.0 ～無限であり、光の減衰を制御します。 あるアプリケーションが Attenuation1 要素を 1.0 に設定し、他のアプリケーションが 0.0 に設定すると、光の強さは 1 / D に従って変化します。D は、光源から頂点までの距離です。 光が最も強いのは光源で、光の範囲において 1 / (光の範囲) に従って弱くなります。

通常、アプリケーションは Attenuation0 を 0.0 に、Attenuation1 を定数値に、Attenuation2 を 0.0 に設定しますが、これを変更することでさまざまな光の効果を実現できます。 減衰値を組み合わせて、さらに複雑な減衰効果を出すこともできます。 または、通常範囲外の値に設定し、さらに強い減衰効果を作り出すこともできます。 ただし、負の減衰値は使うことができません。 「[減衰とスポットライト係数](attenuation-and-spotlight-factor.md)」を参照してください。

## <a name="span-idlightcolorspanspan-idlightcolorspanspan-idlightcolorspanlight-color"></a><span id="Light_Color"></span><span id="light_color"></span><span id="LIGHT_COLOR"></span>光の色


Direct3D の光源は、システムの照明計算で独立して使われる 3 つの色 (拡散色、環境色、反射色) を放射します。 それぞれ Direct3D 照明モジュールに組み込まれており、現在の素材の対応部分と相互作用して、レンダリングに使われる最終的な色を生成します。 拡散色は、現在の素材の拡散反射率プロパティ、素材の鏡面反射率プロパティによる反射色などと相互作用します。 Direct3D がこれらの色を適用する方法に関する具体的な情報については、「[光源の計算](mathematics-of-lighting.md)」をご覧ください。

Direct3D アプリケーションでは、通常は放射される色を定義する 3 つの色値 (拡散、環境、反射) があります。

システムの計算に最も大きい影響を与える色の種類は、拡散色です。 最も一般的な拡散色は白 (R:1.0 G:1.0 B:1.0) ですが、必要に応じて色を作成して必要な効果を実現できます。 たとえば、暖炉に赤い光を使ったり、信号を "進め" に設定するために緑の光を使ったりすることができます。

一般に、光の色コンポーネントは 0.0 ～ 1.0 (両端の値を含む) の値に設定しますが、必須ではありません。 たとえば、すべてのコンポーネントを 2.0 に設定し、"白より明るい" 色を作ることができます。 この種類の設定は、特に定数以外の減衰設定を使う場合に役立ちます。

Direct3D は光に RGBA 値を使いますが、アルファ色コンポーネントは使いません。

通常、光には素材の色が使われます。 ただし、素材の色 (放射、環境、拡散、反射) が拡散または反射頂点色により上書きされることを指定できます。

アルファ/透明度の値は、常に拡散色のアルファ チャネルからのみ取得されます。

霧の値は、常に反射色のアルファ チャネルからのみ取得されます。

## <a name="span-idlightdirectionspanspan-idlightdirectionspanspan-idlightdirectionspanlight-direction"></a><span id="Light_Direction"></span><span id="light_direction"></span><span id="LIGHT_DIRECTION"></span>光の方向


光の方向プロパティは、ワールド空間においてオブジェクトの移動により光が放射される方向を決定します。 方向は、指向性ライトやスポットライトによってのみ使われ、ベクトルによって表現されます。

光の方向はベクトルで設定します。 方向ベクトルは、シーン内の光源に位置に関係なく、論理的な原点からの距離として表現されます。 したがって、シーンをまっすぐポイントする (正の z 軸に沿って) スポットライトの方向ベクトルは、その位置の定義に関係なく &lt;0,0,1&gt; になります。 同様に、シーンを直接照らす日光は、方向が &lt;0,-1,0&gt; の指向性ライトを使ってシミュレートできます。 座標軸に沿って照らす光を作る必要はありません。値をうまく組み合わせて、より興味深い角度で照らす光を作り出すことができます。

光の方向ベクトルを正規化する必要はありませんが、常に大きさを設定してください。 言い換えると、方向ベクトル &lt;0,0,0&gt; は使わないでください。

## <a name="span-idlightpositionspanspan-idlightpositionspanspan-idlightpositionspanlight-position"></a><span id="Light_Position"></span><span id="light_position"></span><span id="LIGHT_POSITION"></span>光の位置


光の位置は、ベクトル構造を使って表されます。 x、y、z 座標がワールド空間にあるという前提です。 位置プロパティを使わない光の種類は、指向性ライトだけです。

## <a name="span-idlightrangespanspan-idlightrangespanspan-idlightrangespanlight-range"></a><span id="Light_Range"></span><span id="light_range"></span><span id="LIGHT_RANGE"></span>光の範囲


光の範囲プロパティは、シーン内のメッシュがそのオブジェクトにより放射された光を受け取らなくなる、ワールド空間における距離を決定します。 指向性ライトは範囲プロパティを使いません。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[照明および素材](lights-and-materials.md)

 

 




