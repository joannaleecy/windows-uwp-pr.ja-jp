---
title: "バッファーの概要"
description: "バッファー リソースは完全に型指定されたデータのコレクションであり、要素にグループ化されます。"
ms.assetid: 494FDF57-0FBE-434C-B568-06F977B40263
keywords:
- "バッファーの概要"
author: mtoepke
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: ec2d181daca8f9ece8e1d364cd58234feb85977a
ms.lasthandoff: 02/07/2017

---

# <a name="introduction-to-buffers"></a>バッファーの概要


バッファー リソースは完全に型指定されたデータのコレクションであり、要素にグループ化されます。 バッファーには、*頂点バッファー* 内のテクスチャ座標、*インデックス バッファー*内のインデックス、*定数バッファー*内のシェーダー定数データ、位置ベクトル、法線ベクトル、デバイスの状態などのデータが格納されます。

バッファー要素は 1 ～ 4 つの成分で構成されます。 バッファー要素には、圧縮済みデータ値 (R8G8B8A8 サーフェス値)、単一の 8 ビット整数、または 4 つの 32 ビット浮動小数点値を含めることができます。

バッファーは構造化されていないリソースとして作成されます。 構造化されていないため、バッファーはミップマップ レベルを格納できず、読み取り時にフィルター処理を適用したり、マルチサンプリングを適用したりすることはできません。

## <a name="span-idbuffertypesspanspan-idbuffertypesspanspan-idbuffertypesspanbuffer-types"></a><span id="Buffer_Types"></span><span id="buffer_types"></span><span id="BUFFER_TYPES"></span>バッファーの種類


Direct3D 11 によりサポートされるバッファー リソースの種類は次のとおりです。

-   [頂点バッファー](#vertex-buffer)
-   [インデックス バッファー](#index-buffer)
-   [定数バッファー](#shader-constant-buffer)

### <a name="span-idvertexbufferspanspan-idvertexbufferspanspan-idvertexbufferspanspan-idvertex-bufferspanvertex-buffer"></a><span id="Vertex_Buffer"></span><span id="vertex_buffer"></span><span id="VERTEX_BUFFER"></span><span id="vertex-buffer"></span>頂点バッファー

頂点バッファーには、ジオメトリの定義に使われる頂点データが格納されます。 頂点データには、位置座標、色データ、テクスチャ座標データ、法線データなどが格納されます。

頂点バッファーの最も単純な例は、位置データのみが格納されたものです。 これを視覚化すると次の図のようになります。

![位置データを格納する頂点バッファーの図](images/d3d10-resources-single-element-vb2.png)

多くの場合、頂点バッファーには 3D の頂点を完全に指定するために必要なすべてのデータが含まれます。 頂点ごとの位置座標、法線座標、およびテクスチャ座標を格納した頂点バッファーが、その一例です。 このようなデータは、次の図に示すように、頂点ごとの要素のセットとしてまとめられます。

![位置、法線、およびテクスチャのデータを含む頂点バッファーの図](images/d3d10-vertex-buffer-element.png)

この頂点バッファーには、頂点ごとのデータが格納されており、各頂点には 3 つの要素 (位置座標、法線座標、およびテクスチャ座標) が格納されています。 一般的に、位置座標と法線座標はそれぞれ 3 つの 32 ビット浮動小数点を使って指定され、テクスチャ座標は 2 つの 32 ビット浮動小数点を使って指定されます。

頂点バッファーのデータにアクセスするには、どの頂点にアクセスするのかという情報と、次の追加のバッファー パラメーターの情報が必要になります。

-   オフセット - バッファーの先頭から最初の頂点データまでのバイト数です。
-   BaseVertexLocation - オフセットから、該当する描画呼び出しで使用される最初の頂点までのバイト数です。

頂点バッファーを作成する前に、レイアウトを定義する必要があります。 入力レイアウト オブジェクトを作成したら、それを[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)にバインドします。

### <a name="span-idindexbufferspanspan-idindexbufferspanspan-idindexbufferspanspan-idindex-bufferspanindex-buffer"></a><span id="Index_Buffer"></span><span id="index_buffer"></span><span id="INDEX_BUFFER"></span><span id="index-buffer"></span>インデックス バッファー

インデックス バッファーには、頂点バッファーへの整数オフセットが格納されます。このバッファーは、より効率的なプリミティブのレンダリングに使われます。 インデックス バッファーは 16 ビットまたは 32 ビットの連続するインデックスを格納します。各インデックスは頂点バッファーの頂点を識別するのに使用されます。 インデックス バッファーを視覚化すると次の図のようになります。

![インデックス バッファーの図](images/d3d10-index-buffer.png)

インデックス バッファーに格納される一連のインデックスの位置は、次のパラメーターを使用して特定します。

-   オフセット - インデックス バッファーのベース アドレスからのバイト数です。
-   StartIndexLocation - ベース アドレスからの最初のインデックス バッファー要素とオフセットを指定します。 開始位置は、最初にレンダリングするインデックスを表します。
-   IndexCount - レンダリングするインデックスの数です。

インデックス バッファーの開始 = インデックス バッファーのベース アドレス + オフセット (バイト) + StartIndexLocation \* ElementSize (バイト)。

この計算では、ElementSize は各インデックス バッファー要素のサイズ (2 または 4 バイト) です。

### <a name="span-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshader-constant-bufferspanconstant-buffer"></a><span id="Shader_Constant_Buffer"></span><span id="shader_constant_buffer"></span><span id="SHADER_CONSTANT_BUFFER"></span><span id="shader-constant-buffer"></span>定数バッファー

定数バッファーを使うと、シェーダー定数データをパイプラインに効率的に提供できます。 定数バッファーを使用して、ストリーム出力ステージの結果を格納できます。 次の図に示すように、定数バッファーは、概念的には要素が 1 つの頂点バッファーに似ています。

![シェーダー定数バッファーの図](images/d3d10-shader-resource-buffer.png)

各要素には 1 ～ 4 成分の定数が格納されます。この値は格納されるデータの形式によって決まります。

定数バッファーは、単一のバインド フラグのみ使うことができ、他のバインド フラグと組み合わせることはできません。

シェーダーからシェーダー定数バッファーを読み取るには、HLSL 読み込み関数を使います。 各シェーダー ステージでは最大 15 個の定数バッファーを使用でき、各バッファーには最大 4,096 の定数を保持できます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[頂点バッファーとインデックス バッファー](vertex-and-index-buffers.md)

 

 





