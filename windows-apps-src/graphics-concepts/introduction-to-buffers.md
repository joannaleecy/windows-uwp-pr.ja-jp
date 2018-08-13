---
title: バッファーの概要
description: バッファー リソースは完全に型指定されたデータのコレクションであり、複数の要素にグループ化されます。
ms.assetid: 494FDF57-0FBE-434C-B568-06F977B40263
keywords:
- バッファーの概要
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 677eea4757220320bc364fef20bf5a5c8d4daaa2
ms.sourcegitcommit: 897a111e8fc5d38d483800288ad01c523e924ef4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/13/2018
ms.locfileid: "1044341"
---
# <a name="introduction-to-buffers"></a>バッファーの概要


バッファー リソースは完全に型指定されたデータのコレクションであり、複数の要素にグループ化されます。 バッファーには、"頂点バッファー"** 内のテクスチャ座標、"インデックス バッファー"** 内のインデックス、"定数バッファー"** 内のシェーダー定数データ、位置ベクトル、法線ベクトル、デバイスの状態などのデータが格納されます。

1 ~ 4 コンポーネントのバッファーの要素が構成されています。 バッファー要素には、圧縮済みデータ値 (R8G8B8A8 サーフェス値)、単一の 8 ビット整数、または 4 つの 32 ビット浮動小数点値を含めることができます。

バッファーは構造化されていないリソースとして作成されます。 構造化されていないため、バッファー ミップマップ レベルを含めることはできません、フィルター読み込む場合、アクセスできないおよびマルチ サンプルことはできません。

## <a name="span-idbuffertypesspanspan-idbuffertypesspanspan-idbuffertypesspanbuffer-types"></a><span id="Buffer_Types"></span><span id="buffer_types"></span><span id="BUFFER_TYPES"></span>バッファーの種類


Direct3D 11 でサポートされているバッファー リソースの種類を次に示します。

-   [頂点バッファー](#vertex-buffer)
-   [インデックス バッファー](#index-buffer)
-   [一定のバッファー](#shader-constant-buffer)

### <a name="span-idvertexbufferspanspan-idvertexbufferspanspan-idvertexbufferspanspan-idvertex-bufferspanvertex-buffer"></a><span id="Vertex_Buffer"></span><span id="vertex_buffer"></span><span id="VERTEX_BUFFER"></span><span id="vertex-buffer"></span>頂点バッファー

頂点バッファーには、図形を定義するために使用する頂点データが含まれています。 頂点データには、位置座標、色データ、テクスチャ座標データ、法線データなどが含まれます。

頂点バッファーの最も簡単な例は、位置データにはのみが含まれています。 これを視覚化すると次の図のようになります。

![位置データを格納する頂点バッファーの図](images/d3d10-resources-single-element-vb2.png)

多くの場合、頂点バッファーには 3D の頂点を完全に指定するために必要なすべてのデータが含まれます。 頂点ごとの位置座標、法線座標、およびテクスチャ座標を格納した頂点バッファーが、その一例です。 このようなデータは、次の図に示すように、頂点ごとの要素のセットとしてまとめられます。

![位置、法線、およびテクスチャのデータを含む頂点バッファーの図](images/d3d10-vertex-buffer-element.png)

この頂点バッファーには、頂点のデータが含まれます。各頂点 (位置、通常、およびテクスチャ) の 3 つの要素が格納されます。 一般的に、位置座標と法線座標はそれぞれ 3 つの 32 ビット浮動小数点を使って指定され、テクスチャ座標は 2 つの 32 ビット浮動小数点を使って指定されます。

頂点バッファーからデータにアクセスするには、アクセス権] と、次のような追加のバッファー パラメーターをどの頂点を認識する必要があります。

-   オフセット - バッファーの先頭から最初の頂点データまでのバイト数です。
-   BaseVertexLocation - オフセットから、該当する描画呼び出しで使用される最初の頂点までのバイト数です。

頂点バッファーを作成する前に、レイアウトを定義する必要があります。 入力レイアウト オブジェクトの作成後は、[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)にバインドします。

### <a name="span-idindexbufferspanspan-idindexbufferspanspan-idindexbufferspanspan-idindex-bufferspanindex-buffer"></a><span id="Index_Buffer"></span><span id="index_buffer"></span><span id="INDEX_BUFFER"></span><span id="index-buffer"></span>インデックス バッファー

インデックス バッファーでは、頂点バッファー整数オフセットを含む、プリミティブのレンダリングをより効率的に使用されます。 インデックス バッファーは 16 ビットまたは 32 ビットの連続するインデックスを格納します。各インデックスは頂点バッファーの頂点を識別するのに使用されます。 インデックス バッファーを視覚化すると次の図のようになります。

![インデックス バッファーの図](images/d3d10-index-buffer.png)

インデックス バッファーに格納される一連のインデックスの位置は、次のパラメーターを使用して特定します。

-   オフセット - インデックス バッファーのベース アドレスからバイト数。
-   StartIndexLocation のベース アドレスとオフセットから最初のインデックス バッファー要素を指定します。 開始位置を表示する最初のインデックスを表します。
-   IndexCount - レンダリングするインデックスの数です。

インデックス バッファーの最初のインデックス バッファーのベース アドレス オフセット (バイト単位) + StartIndexLocation = \ * ElementSize (バイト単位)。

この計算] では、ElementSize は、2 つまたは 4 バイト各インデックス バッファー要素のサイズです。

### <a name="span-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshader-constant-bufferspanconstant-buffer"></a><span id="Shader_Constant_Buffer"></span><span id="shader_constant_buffer"></span><span id="SHADER_CONSTANT_BUFFER"></span><span id="shader-constant-buffer"></span>一定のバッファー

定数バッファーでは、効率的にパイプラインにシェーダー定数のデータを提供することができます。 ストリーム出力ステージの結果を格納するのに定数バッファーを使用することができます。 概念的には、定数のバッファーは、次の図に示すように、1 つの要素の頂点バッファーと同じように検索します。

![シェーダー定数バッファーの図](images/d3d10-shader-resource-buffer.png)

各要素には 1 ～ 4 成分の定数が格納されます。この値は格納されるデータの形式によって決まります。

一定のバッファーは、他のバインド フラグと組み合わせて使用することはできませんが、1 つのバインド フラグのみ使用できます。

シェーダーからシェーダー定数のバッファーを読み、HLSL 読み込み関数を使用します。 各シェーダー ステージでは最大 15 個の定数バッファーを使用でき、各バッファーには最大 4,096 の定数を保持できます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[頂点バッファーとインデックス バッファー](vertex-and-index-buffers.md)

 

 




