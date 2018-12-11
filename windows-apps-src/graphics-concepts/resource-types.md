---
title: リソースの種類
description: リソースの種類によって、レイアウト (またはメモリ使用量) はそれぞれ異なります。
ms.assetid: BCDDF227-1837-44DA-ABD4-E39BCFF2B8EF
keywords:
- リソースの種類
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 4138fd7275f7e1f9addb7685ff0846e756701003
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8891797"
---
# <a name="resource-types"></a>リソースの種類


リソースの種類によって、レイアウト (またはメモリ使用量) はそれぞれ異なります。 Direct3D パイプラインで使用されるリソースはすべて、2 つの基本的なリソースの種類である[バッファー](#buffer-resources)と[テクスチャ](#texture-resources)から派生したものです。 バッファーは未加工データ (要素) のコレクションで、テクスチャはテクセル (テクスチャ要素) のコレクションです。

リソースのレイアウト (またはメモリ使用量) を完全に指定する方法は次の 2 つです。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">項目</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span id="Typed"></span><span id="typed"></span><span id="TYPED"></span>型指定あり</p></td>
<td align="left"><p>リソース作成時に型を完全に指定します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><span id="Typeless"></span><span id="typeless"></span><span id="TYPELESS"></span>型指定なし</p></td>
<td align="left"><p>リソースをパイプラインにバインドするときに型を完全に指定します。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idbufferresourcesspanspan-idbufferresourcesspanspan-idbufferresourcesspanspan-idbuffer-resourcesspanbuffer-resources"></a><span id="Buffer_Resources"></span><span id="buffer_resources"></span><span id="BUFFER_RESOURCES"></span><span id="buffer-resources"></span>バッファー リソース


バッファー リソースは完全に型指定されたデータのコレクションであり、内部的にはバッファーに要素が格納されます。 要素は 1 ～ 4 つの成分で構成されます。 要素のデータ型の例としては、圧縮済みデータ (R8G8B8A8 など)、単一の 8 ビット整数、4 つの 32 ビット浮動小数点などがあります。 これらのデータ型は、位置ベクトル、法線ベクトル、頂点バッファーのテクスチャ座標、インデックス バッファーのインデックス、デバイスの状態などのデータを格納するために使用されます。

バッファーは構造化されていないリソースとして作成されます。 構造化されていないため、バッファーはミップマップ レベルを格納できず、読み取り時にフィルター処理を適用したり、マルチサンプリングを適用したりすることはできません。

### <a name="span-idbuffertypesspanspan-idbuffertypesspanspan-idbuffertypesspanbuffer-types"></a><span id="Buffer_Types"></span><span id="buffer_types"></span><span id="BUFFER_TYPES"></span>バッファーの種類

-   [頂点バッファー](#vertex-buffer)
-   [インデックス バッファー](#index-buffer)
-   [定数バッファー](#shader-constant-buffer)

### <a name="span-idvertexbufferspanspan-idvertexbufferspanspan-idvertexbufferspanspan-idvertex-bufferspanvertex-buffer"></a><span id="Vertex_Buffer"></span><span id="vertex_buffer"></span><span id="VERTEX_BUFFER"></span><span id="vertex-buffer"></span>頂点バッファー

バッファーは要素のコレクションであり、頂点バッファーには頂点単位のデータが格納されます。 頂点バッファーの最も単純な例は、位置データなど、1 種類のデータが格納されたものです。 これを視覚化すると次の図のようになります。

![位置データを格納する頂点バッファーの図](images/d3d10-resources-single-element-vb2.png)

多くの場合、頂点バッファーには 3D の頂点を完全に指定するために必要なすべてのデータが含まれます。 頂点ごとの位置座標、法線座標、およびテクスチャ座標を格納した頂点バッファーが、その一例です。 このようなデータは、次の図に示すように、頂点ごとの要素のセットとしてまとめられます。

![位置、法線、およびテクスチャのデータを含む頂点バッファーの図](images/d3d10-vertex-buffer-element.png)

この頂点バッファーには 8 つの頂点に関する頂点ごとのデータが含まれており、各頂点には 3 つの要素 (位置座標、法線座標、およびテクスチャ座標) が格納されています。 一般的に、位置座標と法線座標はそれぞれ 3 つの 32 ビット浮動小数点を使って指定され、テクスチャ座標は 2 つの 32 ビット浮動小数点を使って指定されます。

頂点バッファーのデータにアクセスするには、どの頂点にアクセスするのかという情報と、次のバッファー パラメーターの情報が必要になります。

-   *オフセット* - バッファーの先頭から最初の頂点データまでのバイト数です。
-   *BaseVertexLocation* - オフセットから、該当する描画呼び出しで使用される最初の頂点までのバイト数です。

頂点バッファーを作成する前に、入力レイアウト オブジェクトを作成してレイアウトを定義する必要があります。 入力レイアウト オブジェクトを作成したら、それを入力アセンブラー (IA) ステージにバインドします。

### <a name="span-idindexbufferspanspan-idindexbufferspanspan-idindexbufferspanspan-idindex-bufferspanindex-buffer"></a><span id="Index_Buffer"></span><span id="index_buffer"></span><span id="INDEX_BUFFER"></span><span id="index-buffer"></span>インデックス バッファー

インデックス バッファーは 16 ビットまたは 32 ビットの連続するインデックスを格納します。各インデックスは頂点バッファーの頂点を識別するのに使用されます。 インデックス バッファーと 1 つ以上の頂点バッファーを併せて使用して、IA ステージにデータを渡すことをインデックス作成と呼びます。 インデックス バッファーを視覚化すると次の図のようになります。

![インデックス バッファーの図](images/d3d10-index-buffer.png)

インデックス バッファーに格納される一連のインデックスの位置は、次のパラメーターを使用して特定します。

-   *オフセット* - バッファーの先頭から最初のインデックスまでのバイト数です。
-   *StartIndexLocation* - オフセットから、該当する描画呼び出しで使用される最初の頂点までのバイト数です。
-   *IndexCount* - レンダリングするインデックスの数です。

インデックス バッファーは、ストリップカット インデックスで区切ることによって、複数のライン ストリップまたはトライアングル ストリップ ([プリミティブ トポロジ](primitive-topologies.md)) をまとめることができます。 ストリップカット インデックスを使用すると、複数のライン ストリップまたはトライアングル ストリップを 1 つの描画呼び出しを使って描画することができます。 ストリップカット インデックスは、インデックスに使用できる最大の値のことです (16 ビット インデックスの場合は 0xffff、32 ビット インデックスの場合は 0xffffffff)。 ストリップ カット インデックスはインデックス付きプリミティブのワインディング順序をリセットします。ストリップ カット インデックスを使用すれば、縮退三角形を使用しなくても、トライアングル ストリップの適切なワインディング順序を維持できます。 次の図は、ストリップカット インデックスの例を示しています。

![ストリップカット インデックスの図](images/d3d10-ia-strips-cut-value.png)

### <a name="span-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshader-constant-bufferspanconstant-buffer"></a><span id="Shader_Constant_Buffer"></span><span id="shader_constant_buffer"></span><span id="SHADER_CONSTANT_BUFFER"></span><span id="shader-constant-buffer"></span>定数バッファー

Direct3D には、シェーダー定数バッファーまたは単に定数バッファーと呼ばれる、シェーダー定数を提供するためのバッファーがあります。 概念的には、次の図に示すように、要素が 1 つの頂点バッファーに似ています。

![シェーダー定数バッファーの図](images/d3d10-shader-resource-buffer.png)

各要素には 1 ～ 4 成分の定数が格納されます。この値は格納されるデータの形式によって決まります。

定数バッファーを使用すると、複数のシェーダー定数をグループにまとめて同時にコミットできます。それぞれのシェーダー定数を個別の呼び出しで別々にコミットすることがないので、シェーダー定数の更新に必要な帯域を削減することができます。

シェーダーは、定数バッファーに含まれていない変数を読み取る場合と同様に、変数名を使って定数バッファー内の変数を継続的に直接読み取ります。

各シェーダー ステージでは最大 15 個の定数バッファーを使用でき、各バッファーには最大 4,096 の定数を保持できます。

定数バッファーを使用して、ストリーム出力ステージの結果を保存します。

シェーダーで定数バッファーを宣言する例については、「[シェーダー定数 (DirectX HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581)」をご覧ください。

## <a name="span-idtextureresourcesspanspan-idtextureresourcesspanspan-idtextureresourcesspanspan-idtexture-resourcesspantexture-resources"></a><span id="Texture_Resources"></span><span id="texture_resources"></span><span id="TEXTURE_RESOURCES"></span><span id="texture-resources"></span>テクスチャ リソース


テクスチャ リソースは、テクセルを格納するように設計された、データの構造化されたコレクションです。 バッファーと異なり、テクスチャは、シェーダー ユニットに読み取られる際にテクスチャ サンプラーでフィルターを適用することができます。 テクスチャへのフィルター処理の適用方法はテクスチャの種類に影響されます。 テクセルは、パイプラインで読み取ったり、書き込んだりすることができるテクスチャの最小単位を表します。 各テクセルは 1 ～ 4 つの成分を含み、いずれかの DXGI 形式で配置されます (「[**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059)」をご覧ください)。

テクスチャは構造化されたリソースとして作成されるため、そのサイズがわかります。 ただし、各テクスチャはリソース作成時に型指定される場合もありますが、テクスチャをパイプラインにバインドするときにビューを使用して型を完全に指定するという条件で、リソース作成時に型指定されない場合もあります。

-   [テクスチャの種類](#texture-types)
-   [サブリソース](#subresources)
-   [強い型指定と弱い型指定](#typed)

### <a name="span-idtexturetypesspanspan-idtexturetypesspanspan-idtexturetypesspanspan-idtexture-typesspantexture-types"></a><span id="Texture_Types"></span><span id="texture_types"></span><span id="TEXTURE_TYPES"></span><span id="texture-types"></span>テクスチャの種類

テクスチャの種類には 1D、2D、および 3D があり、それぞれミップマップ付きまたはミップマップなしで作成できます。 Direct3D では、テクスチャ配列とマルチサンプリングされたテクスチャもサポートされています。

-   [1D テクスチャ](#texture1d-resource)
-   [1D テクスチャ配列](#texture1d-array-resource)
-   [2D テクスチャと 2D テクスチャ配列](#texture2d-resource)
-   [3D テクスチャ](#texture3d-resource)

### <a name="span-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1d-resourcespan1d-texture"></a><span id="Texture1D_Resource"></span><span id="texture1d_resource"></span><span id="TEXTURE1D_RESOURCE"></span><span id="texture1d-resource"></span>1D テクスチャ

最も単純な形式の 1D テクスチャには、1 つのテクスチャ座標で処理できるテクスチャ データが格納されます。これをテクセルの配列として視覚化すると次の図のようになります。

![1D テクスチャの図](images/d3d10-1d-texture.png)

各テクセルには、格納されているデータ形式に応じた色成分がいくつか含まれます。 より複雑なものになると、次の図に示すように、ミップマップ レベルを持つ 1D テクスチャを作成できます。

![ミップマップ レベルを持つ 1D テクスチャの図](images/d3d10-resource-texture1d.png)

ミップマップ レベルは、上のレベルよりも 2 の累乗だけ小さいテクスチャです。 最上位レベルが最も詳細で (大きく)、レベルが下がるほど小さくなります。1D ミップマップの最小レベルはテクセルを 1 つだけ含みます。 各レベルの識別には詳細レベル (LOD) と呼ばれるインデックスを使用します。カメラにそれほど近くないジオメトリをレンダリングする場合は、LOD を使って小さいテクスチャにアクセスできます。

### <a name="span-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1d-array-resourcespan1d-texture-array"></a><span id="Texture1D_Array_Resource"></span><span id="texture1d_array_resource"></span><span id="TEXTURE1D_ARRAY_RESOURCE"></span><span id="texture1d-array-resource"></span>1D テクスチャ配列

Direct3D 10 には、テクスチャの配列用の新しいデータ構造も用意されています。 1D テクスチャの配列は概念的に次の図のようになります。

![1D テクスチャ配列の図](images/d3d10-resource-texture1darray.png)

このテクスチャ配列には 3 つのテクスチャが含まれています。 3 つのテクスチャはそれぞれテクスチャ幅が 5 になっています (5 は最初のレイヤーの要素数)。 また、各テクスチャには 3 レイヤーのミップマップも格納されています。

Direct3D のすべてのテクスチャ配列は、テクスチャの同次配列です。つまり、1 つのテクスチャ配列内にあるテクスチャはすべて、データ形式とサイズが (テクスチャ幅とミップマップ レベル数も含めて) 同じである必要があります。 各配列に含まれるすべてのテクスチャのサイズが一致してさえいれば、さまざまなサイズのテクスチャ配列を作成できます。

### <a name="span-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2d-resourcespan2d-texture-and-2d-texture-array"></a><span id="Texture2D_Resource"></span><span id="texture2d_resource"></span><span id="TEXTURE2D_RESOURCE"></span><span id="texture2d-resource"></span>2D テクスチャと 2D テクスチャ配列

Texture2D リソースにはテクセルの 2D グリッドが 1 つ含まれています。 各テクセルは u ベクトルと v ベクトルで指定できます。 これはテクスチャ リソースであるため、ミップマップ レベルとサブリソースが格納される場合もあります。 すべてのデータが設定された 2D テクスチャ リソースは次の図のようになります。

![2D テクスチャ リソースの図](images/d3d10-resource-texture2d.png)

このテクスチャ リソースには 1 つの 3x5 テクスチャと 3 つのミップマップ レベルが格納されています。

Texture2DArray リソースは 2D テクスチャの同次配列であるため、各テクスチャのデータ形式とサイズは (ミップマップ レベルを含めて) 同じです。 このリソースは、テクスチャに 2D データが含まれていることを除けば 1D テクスチャ配列とレイアウトが似ています。したがって、次のような図になります。

![2D テクスチャ配列のリソースの図](images/d3d10-resource-texture2darray.png)

このテクスチャ配列には 3 つのテクスチャが含まれています。各テクスチャは 3x5 で、2 つのミップマップ レベルを持ちます。

### <a name="span-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanusing-a-texture2darray-as-a-texture-cube"></a><span id="Texture2DArray_Resource_as_a_Texture_Cube"></span><span id="texture2darray_resource_as_a_texture_cube"></span><span id="TEXTURE2DARRAY_RESOURCE_AS_A_TEXTURE_CUBE"></span>テクスチャ キューブとしての Texture2DArray の使用

テクスチャ キューブは、6 つのテクスチャ (キューブの各面に 1 つずつ) が含まれた 2D テクスチャ配列です。 すべてのデータが設定されたテクスチャ キューブは次の図のようになります。

![テクスチャ キューブを表す 2D テクスチャ配列のリソースの図](images/d3d10-resource-texturecube.png)

6 つのテクスチャが含まれた 2D テクスチャ配列は、キューブ テクスチャ ビューを使ってパイプラインにバインドした後に、キューブ マップ組み込み関数を使ってシェーダー内から読み取ることができます。 テクスチャ キューブは、テクスチャ キューブの中心を起点とする 3D ベクトルによってシェーダーで処理されます。

### <a name="span-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3d-resourcespan3d-texture"></a><span id="Texture3D_Resource"></span><span id="texture3d_resource"></span><span id="TEXTURE3D_RESOURCE"></span><span id="texture3d-resource"></span>3D テクスチャ

Texture3D リソース (ボリューム テクスチャとも呼ばれます) にはテクセルの 3D ボリュームが格納されます。 これはテクスチャ リソースであるため、ミップマップ レベルが含まれる場合もあります。 すべてのデータが設定された 3D テクスチャは次の図のようになります。

![3D テクスチャ リソースの図](images/d3d10-resource-texture3d.png)

3D テクスチャ ミップマップ スライスを (レンダー ターゲット ビューを使って) レンダー ターゲット出力としてバインドした場合、3D テクスチャは n 個のスライスの 2D テクスチャ配列と同じように動作します。 特定のレンダー スライスはジオメトリ シェーダー ステージで選択します。

3D テクスチャ配列という概念は存在しません。そのため、3D テクスチャのサブリソースは単一のミップマップ レベルになります。

### <a name="span-idsubresourcesspanspan-idsubresourcesspanspan-idsubresourcesspansubresources"></a><span id="Subresources"></span><span id="subresources"></span><span id="SUBRESOURCES"></span>サブリソース

Direct3D API は、リソース全体またはリソースのサブセットを参照します。 リソースの一部を指定するために、Direct3D では*サブリソース*という用語が新たに用意されています。つまり、リソースのサブセットのことです。

バッファーは単一のサブリソースと定義されます。 テクスチャはもう少し複雑です。テクスチャの種類が複数存在していて (1D、2D など)、その一部ではミップマップ レベルやテクスチャ配列がサポートされているためです。 最も単純なケースから始めると、1D テクスチャは単一のサブリソースとして定義され、次の図のようになります。

![1D テクスチャの図](images/d3d10-1d-texture.png)

つまり、1D テクスチャを構成するテクセルの配列は単一のサブリソースに含まれます。

1D テクスチャを 3 つのミップマップ レベルで拡張した場合、それを視覚化すると次のようになります。

![ミップマップ レベルを持つ 1D テクスチャの図](images/d3d10-resource-texture1d.png)

これを 3 つのサブテクスチャで構成される単一のテクスチャと考えます。 各サブテクスチャは 1 つのサブリソースとしてカウントされます。そのため、この 1D テクスチャには 3 つのサブリソースが含まれます。 サブテクスチャ (またはサブリソース) は、単一テクスチャ用の詳細レベル (LOD) を使ってインデックスを作成できます。 テクスチャの配列を使用する場合、特定のサブテクスチャにアクセスするには LOD とその特定のテクスチャの両方が必要です。 または、API によって、この 2 つの情報を以下に示すような 0 から始まる単一のサブリソース インデックスにまとめます。

![0 から始まるサブリソース インデックスの図](images/d3d10-resource-texture1darray-sub-indexing.png)

### <a name="span-idselectingsubresourcesspanspan-idselectingsubresourcesspanspan-idselectingsubresourcesspanselecting-subresources"></a><span id="Selecting_Subresources"></span><span id="selecting_subresources"></span><span id="SELECTING_SUBRESOURCES"></span>サブリソースの選択

API の中にはリソース全体にアクセスするものもあれば、リソースの一部にアクセスするものもあります。 一般的に、リソースの一部にアクセスする API は、ビュー記述を使用してアクセス対象のサブリソースを指定します。

以下の図は、テクスチャの配列にアクセスする際にビュー記述で使用される用語を表しています。

### <a name="span-idarrayslicespanspan-idarrayslicespanspan-idarrayslicespanarray-slice"></a><span id="Array_Slice"></span><span id="array_slice"></span><span id="ARRAY_SLICE"></span>配列スライス

あるテクスチャの配列で、各テクスチャにミップマップが用意されている場合、次の図に示すように、(白い長方形で表されている) 配列スライスには 1 つのテクスチャとそのすべてのサブテクスチャが含まれます。

![配列スライスの図](images/d3d10-resource-array-slice.png)

### <a name="span-idmipslicespanspan-idmipslicespanspan-idmipslicespanmip-slice"></a><span id="Mip_Slice"></span><span id="mip_slice"></span><span id="MIP_SLICE"></span>ミップ スライス

次の図に示すように、(白い長方形で表されている) ミップ スライスには配列内のすべてのテクスチャのミップマップ レベルが 1 つ含まれます。

![ミップ スライスの図](images/d3d10-resource-mip-slice.png)

### <a name="span-idselectingasinglesubresourcespanspan-idselectingasinglesubresourcespanspan-idselectingasinglesubresourcespanselecting-a-single-subresource"></a><span id="Selecting_a_Single_Subresource"></span><span id="selecting_a_single_subresource"></span><span id="SELECTING_A_SINGLE_SUBRESOURCE"></span>単一サブリソースの選択

次の図に示すように、単一のリソースを選択するには、前述の 2 種類のスライスを使用します。

![配列スライスとミップ スライスを使用してサブリソースを選択した場合の図](images/d3d10-resource-subresources-1.png)

### <a name="span-idselectingmultiplesubresourcesspanspan-idselectingmultiplesubresourcesspanspan-idselectingmultiplesubresourcesspanselecting-multiple-subresources"></a><span id="Selecting_Multiple_Subresources"></span><span id="selecting_multiple_subresources"></span><span id="SELECTING_MULTIPLE_SUBRESOURCES"></span>複数のサブリソースの選択

また、複数のサブリソースを選択するには、ミップマップ レベル数やテクスチャ数を指定して、前述の 2 種類のスライスを使用します。

![複数のサブリソースを選択した場合の図](images/d3d10-resource-subresources-2.png)

たいていの場合、使用するテクスチャの種類、ミップマップの有無、およびテクスチャ配列の有無にかかわらず、特定のサブリソースのインデックスを計算できるように用意されたヘルパー関数があります。

### <a name="span-idtypedspanspan-idtypedspanspan-idtypedspanstrong-vs-weak-typing"></a><span id="Typed"></span><span id="typed"></span><span id="TYPED"></span>強い型指定と弱い型指定

完全に型指定されたリソースを作成すると、そのリソースの形式はそのリソースを作成したときの形式に制限されます。 これによりランタイムによるアクセスが最適化されます。特に、アプリケーションでマップできないことを示すフラグを使ってリソースを作成する場合は有効です。 型を指定して作成したリソースは、ビュー機構を使って再解釈することができません。

型指定なしのリソースでは、最初にリソースを作成したときのデータ型は不明です。 アプリケーションは、型指定なしの利用可能な形式からいずれかを選択する必要があります。 また、割り当てるメモリのサイズと、ランタイムでミップマップのサブテクスチャを生成する必要があるかどうかも指定しなければなりません。

ただし、正確なデータ形式 (整数、浮動小数点値、符号なし整数などとして、メモリが解釈されるかどうか) はビューを使ってリソースがパイプラインにバインドされるまで決定されません。 テクスチャ形式はテクスチャがパイプラインにバインドされるまで柔軟性が維持されるため、このリソースは弱く型指定されたストレージと呼ばれます。 弱く型指定されたストレージには、新しい形式の成分ビットが古い形式のビット数と一致している限り、(別の形式で) 再使用または再解釈できるという利点があります。

各パイプライン ステージに、それぞれの場所での形式を完全に修飾する一意のビューがある限り、1 つのリソースを複数のパイプライン ステージにバインドすることができます。 たとえば、型指定なし形式で作成したリソースを、パイプラインの別々の場所で FLOAT 形式および UINT 形式として同時に使用することもできます。

## <a name="span-idrelated-topicsspanrelated-topics"></a><span id="related-topics"></span>関連トピック


[リソース](resources.md)
