---
title: リソースの種類
description: リソースの種類によって、レイアウト (またはメモリ使用量) はそれぞれ異なります。
ms.assetid: BCDDF227-1837-44DA-ABD4-E39BCFF2B8EF
keywords:
- リソースの種類
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 3c23cc07c84e9a77b36c812c6f273f518e98838e
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6027898"
---
# <a name="resource-types"></a><span data-ttu-id="66121-104">リソースの種類</span><span class="sxs-lookup"><span data-stu-id="66121-104">Resource types</span></span>


<span data-ttu-id="66121-105">リソースの種類によって、レイアウト (またはメモリ使用量) はそれぞれ異なります。</span><span class="sxs-lookup"><span data-stu-id="66121-105">Different types of resources have a distinct layout (or memory footprint).</span></span> <span data-ttu-id="66121-106">Direct3D パイプラインで使用されるリソースはすべて、2 つの基本的なリソースの種類である[バッファー](#buffer-resources)と[テクスチャ](#texture-resources)から派生したものです。</span><span class="sxs-lookup"><span data-stu-id="66121-106">All resources used by the Direct3D pipeline derive from two basic resource types: [buffers](#buffer-resources) and [textures](#texture-resources).</span></span> <span data-ttu-id="66121-107">バッファーは未加工データ (要素) のコレクションで、テクスチャはテクセル (テクスチャ要素) のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="66121-107">A buffer is a collection of raw data (elements); a texture is a collection of texels (texture elements).</span></span>

<span data-ttu-id="66121-108">リソースのレイアウト (またはメモリ使用量) を完全に指定する方法は次の 2 つです。</span><span class="sxs-lookup"><span data-stu-id="66121-108">There are two ways to fully specify the layout (or memory footprint) of a resource:</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="66121-109">項目</span><span class="sxs-lookup"><span data-stu-id="66121-109">Item</span></span></th>
<th align="left"><span data-ttu-id="66121-110">説明</span><span class="sxs-lookup"><span data-stu-id="66121-110">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="66121-111"><span id="Typed"></span><span id="typed"></span><span id="TYPED"></span>型指定あり</span><span class="sxs-lookup"><span data-stu-id="66121-111"><span id="Typed"></span><span id="typed"></span><span id="TYPED"></span>Typed</span></span></p></td>
<td align="left"><p><span data-ttu-id="66121-112">リソース作成時に型を完全に指定します。</span><span class="sxs-lookup"><span data-stu-id="66121-112">Fully specify the type when the resource is created.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="66121-113"><span id="Typeless"></span><span id="typeless"></span><span id="TYPELESS"></span>型指定なし</span><span class="sxs-lookup"><span data-stu-id="66121-113"><span id="Typeless"></span><span id="typeless"></span><span id="TYPELESS"></span>Typeless</span></span></p></td>
<td align="left"><p><span data-ttu-id="66121-114">リソースをパイプラインにバインドするときに型を完全に指定します。</span><span class="sxs-lookup"><span data-stu-id="66121-114">Fully specify the type when the resource is bound to the pipeline.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idbufferresourcesspanspan-idbufferresourcesspanspan-idbufferresourcesspanspan-idbuffer-resourcesspanbuffer-resources"></a><span data-ttu-id="66121-115"><span id="Buffer_Resources"></span><span id="buffer_resources"></span><span id="BUFFER_RESOURCES"></span><span id="buffer-resources"></span>バッファー リソース</span><span class="sxs-lookup"><span data-stu-id="66121-115"><span id="Buffer_Resources"></span><span id="buffer_resources"></span><span id="BUFFER_RESOURCES"></span><span id="buffer-resources"></span>Buffer resources</span></span>


<span data-ttu-id="66121-116">バッファー リソースは完全に型指定されたデータのコレクションであり、内部的にはバッファーに要素が格納されます。</span><span class="sxs-lookup"><span data-stu-id="66121-116">A buffer resource is a collection of fully typed data; internally, a buffer contains elements.</span></span> <span data-ttu-id="66121-117">要素は 1 ～ 4 つの成分で構成されます。</span><span class="sxs-lookup"><span data-stu-id="66121-117">An element is made up of 1 to 4 components.</span></span> <span data-ttu-id="66121-118">要素のデータ型の例としては、圧縮済みデータ (R8G8B8A8 など)、単一の 8 ビット整数、4 つの 32 ビット浮動小数点などがあります。</span><span class="sxs-lookup"><span data-stu-id="66121-118">Examples of element data types include: a packed data value (like R8G8B8A8), a single 8-bit integer, four 32-bit float values.</span></span> <span data-ttu-id="66121-119">これらのデータ型は、位置ベクトル、法線ベクトル、頂点バッファーのテクスチャ座標、インデックス バッファーのインデックス、デバイスの状態などのデータを格納するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="66121-119">These data types are used to store data, such as a position vector, a normal vector, a texture coordinate in a vertex buffer, an index in an index buffer, or device state.</span></span>

<span data-ttu-id="66121-120">バッファーは構造化されていないリソースとして作成されます。</span><span class="sxs-lookup"><span data-stu-id="66121-120">A buffer is created as an unstructured resource.</span></span> <span data-ttu-id="66121-121">構造化されていないため、バッファーはミップマップ レベルを格納できず、読み取り時にフィルター処理を適用したり、マルチサンプリングを適用したりすることはできません。</span><span class="sxs-lookup"><span data-stu-id="66121-121">Because it is unstructured, a buffer cannot contain any mipmap levels, is not filtered when read, and cannot be multisampled.</span></span>

### <a name="span-idbuffertypesspanspan-idbuffertypesspanspan-idbuffertypesspanbuffer-types"></a><span data-ttu-id="66121-122"><span id="Buffer_Types"></span><span id="buffer_types"></span><span id="BUFFER_TYPES"></span>バッファーの種類</span><span class="sxs-lookup"><span data-stu-id="66121-122"><span id="Buffer_Types"></span><span id="buffer_types"></span><span id="BUFFER_TYPES"></span>Buffer types</span></span>

-   [<span data-ttu-id="66121-123">頂点バッファー</span><span class="sxs-lookup"><span data-stu-id="66121-123">Vertex buffer</span></span>](#vertex-buffer)
-   [<span data-ttu-id="66121-124">インデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="66121-124">Index buffer</span></span>](#index-buffer)
-   [<span data-ttu-id="66121-125">定数バッファー</span><span class="sxs-lookup"><span data-stu-id="66121-125">Constant buffer</span></span>](#shader-constant-buffer)

### <a name="span-idvertexbufferspanspan-idvertexbufferspanspan-idvertexbufferspanspan-idvertex-bufferspanvertex-buffer"></a><span data-ttu-id="66121-126"><span id="Vertex_Buffer"></span><span id="vertex_buffer"></span><span id="VERTEX_BUFFER"></span><span id="vertex-buffer"></span>頂点バッファー</span><span class="sxs-lookup"><span data-stu-id="66121-126"><span id="Vertex_Buffer"></span><span id="vertex_buffer"></span><span id="VERTEX_BUFFER"></span><span id="vertex-buffer"></span>Vertex buffer</span></span>

<span data-ttu-id="66121-127">バッファーは要素のコレクションであり、頂点バッファーには頂点単位のデータが格納されます。</span><span class="sxs-lookup"><span data-stu-id="66121-127">A buffer is a collection of elements; a vertex buffer contains per-vertex data.</span></span> <span data-ttu-id="66121-128">頂点バッファーの最も単純な例は、位置データなど、1 種類のデータが格納されたものです。</span><span class="sxs-lookup"><span data-stu-id="66121-128">The simplest example is a vertex buffer that contains one type of data, such as position data.</span></span> <span data-ttu-id="66121-129">これを視覚化すると次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-129">It can be visualized like the following illustration.</span></span>

![位置データを格納する頂点バッファーの図](images/d3d10-resources-single-element-vb2.png)

<span data-ttu-id="66121-131">多くの場合、頂点バッファーには 3D の頂点を完全に指定するために必要なすべてのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="66121-131">More often, a vertex buffer contains all the data needed to fully specify 3D vertices.</span></span> <span data-ttu-id="66121-132">頂点ごとの位置座標、法線座標、およびテクスチャ座標を格納した頂点バッファーが、その一例です。</span><span class="sxs-lookup"><span data-stu-id="66121-132">An example of this could be a vertex buffer that contains per-vertex position, normal and texture coordinates.</span></span> <span data-ttu-id="66121-133">このようなデータは、次の図に示すように、頂点ごとの要素のセットとしてまとめられます。</span><span class="sxs-lookup"><span data-stu-id="66121-133">This data is usually organized as sets of per-vertex elements, as shown in the following illustration.</span></span>

![位置、法線、およびテクスチャのデータを含む頂点バッファーの図](images/d3d10-vertex-buffer-element.png)

<span data-ttu-id="66121-135">この頂点バッファーには 8 つの頂点に関する頂点ごとのデータが含まれており、各頂点には 3 つの要素 (位置座標、法線座標、およびテクスチャ座標) が格納されています。</span><span class="sxs-lookup"><span data-stu-id="66121-135">This vertex buffer contains per-vertex data for eight vertices; each vertex stores three elements (position, normal, and texture coordinates).</span></span> <span data-ttu-id="66121-136">一般的に、位置座標と法線座標はそれぞれ 3 つの 32 ビット浮動小数点を使って指定され、テクスチャ座標は 2 つの 32 ビット浮動小数点を使って指定されます。</span><span class="sxs-lookup"><span data-stu-id="66121-136">The position and normal are each typically specified using three 32-bit floats and the texture coordinates using two 32-bit floats.</span></span>

<span data-ttu-id="66121-137">頂点バッファーのデータにアクセスするには、どの頂点にアクセスするのかという情報と、次のバッファー パラメーターの情報が必要になります。</span><span class="sxs-lookup"><span data-stu-id="66121-137">To access data from a vertex buffer, you need to know which vertex to access and these other buffer parameters:</span></span>

-   <span data-ttu-id="66121-138">*オフセット* - バッファーの先頭から最初の頂点データまでのバイト数です。</span><span class="sxs-lookup"><span data-stu-id="66121-138">*Offset* - the number of bytes from the start of the buffer to the data for the first vertex.</span></span>
-   <span data-ttu-id="66121-139">*BaseVertexLocation* - オフセットから、該当する描画呼び出しで使用される最初の頂点までのバイト数です。</span><span class="sxs-lookup"><span data-stu-id="66121-139">*BaseVertexLocation* - the number of bytes from the offset to the first vertex used by the appropriate draw call.</span></span>

<span data-ttu-id="66121-140">頂点バッファーを作成する前に、入力レイアウト オブジェクトを作成してレイアウトを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="66121-140">Before you create a vertex buffer, you need to define its layout by creating an input-layout object.</span></span> <span data-ttu-id="66121-141">入力レイアウト オブジェクトを作成したら、それを入力アセンブラー (IA) ステージにバインドします。</span><span class="sxs-lookup"><span data-stu-id="66121-141">Once the input-layout object is created, bind it to the Input Assembler (IA) stage.</span></span>

### <a name="span-idindexbufferspanspan-idindexbufferspanspan-idindexbufferspanspan-idindex-bufferspanindex-buffer"></a><span data-ttu-id="66121-142"><span id="Index_Buffer"></span><span id="index_buffer"></span><span id="INDEX_BUFFER"></span><span id="index-buffer"></span>インデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="66121-142"><span id="Index_Buffer"></span><span id="index_buffer"></span><span id="INDEX_BUFFER"></span><span id="index-buffer"></span>Index buffer</span></span>

<span data-ttu-id="66121-143">インデックス バッファーは 16 ビットまたは 32 ビットの連続するインデックスを格納します。各インデックスは頂点バッファーの頂点を識別するのに使用されます。</span><span class="sxs-lookup"><span data-stu-id="66121-143">An index buffer contains a sequential set of 16-bit or 32-bit indices; each index is used to identify a vertex in a vertex buffer.</span></span> <span data-ttu-id="66121-144">インデックス バッファーと 1 つ以上の頂点バッファーを併せて使用して、IA ステージにデータを渡すことをインデックス作成と呼びます。</span><span class="sxs-lookup"><span data-stu-id="66121-144">Using an index buffer with one or more vertex buffers to supply data to the IA stage is called indexing.</span></span> <span data-ttu-id="66121-145">インデックス バッファーを視覚化すると次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-145">An index buffer can be visualized like the following illustration.</span></span>

![インデックス バッファーの図](images/d3d10-index-buffer.png)

<span data-ttu-id="66121-147">インデックス バッファーに格納される一連のインデックスの位置は、次のパラメーターを使用して特定します。</span><span class="sxs-lookup"><span data-stu-id="66121-147">The sequential indices stored in an index buffer are located with the following parameters:</span></span>

-   <span data-ttu-id="66121-148">*オフセット* - バッファーの先頭から最初のインデックスまでのバイト数です。</span><span class="sxs-lookup"><span data-stu-id="66121-148">*Offset* - the number of bytes from the start of the buffer to the first index.</span></span>
-   <span data-ttu-id="66121-149">*StartIndexLocation* - オフセットから、該当する描画呼び出しで使用される最初の頂点までのバイト数です。</span><span class="sxs-lookup"><span data-stu-id="66121-149">*StartIndexLocation* - the number of bytes from the offset to the first vertex used by the appropriate draw call.</span></span>
-   <span data-ttu-id="66121-150">*IndexCount* - レンダリングするインデックスの数です。</span><span class="sxs-lookup"><span data-stu-id="66121-150">*IndexCount* - the number of indices to render.</span></span>

<span data-ttu-id="66121-151">インデックス バッファーは、ストリップカット インデックスで区切ることによって、複数のライン ストリップまたはトライアングル ストリップ ([プリミティブ トポロジ](primitive-topologies.md)) をまとめることができます。</span><span class="sxs-lookup"><span data-stu-id="66121-151">An index buffer can stitch together multiple line or triangle strips ([primitive topologies](primitive-topologies.md)) by separating each with a strip-cut index.</span></span> <span data-ttu-id="66121-152">ストリップカット インデックスを使用すると、複数のライン ストリップまたはトライアングル ストリップを 1 つの描画呼び出しを使って描画することができます。</span><span class="sxs-lookup"><span data-stu-id="66121-152">A strip-cut index allows multiple line or triangle strips to be drawn with a single draw call.</span></span> <span data-ttu-id="66121-153">ストリップカット インデックスは、インデックスに使用できる最大の値のことです (16 ビット インデックスの場合は 0xffff、32 ビット インデックスの場合は 0xffffffff)。</span><span class="sxs-lookup"><span data-stu-id="66121-153">A strip-cut index is the maximum possible value for the index (0xffff for a 16-bit index, 0xffffffff for a 32-bit index).</span></span> <span data-ttu-id="66121-154">ストリップ カット インデックスはインデックス付きプリミティブのワインディング順序をリセットします。ストリップ カット インデックスを使用すれば、縮退三角形を使用しなくても、トライアングル ストリップの適切なワインディング順序を維持できます。</span><span class="sxs-lookup"><span data-stu-id="66121-154">The strip-cut index resets the winding order in indexed primitives and can be used to remove the need for degenerate triangles that may otherwise be required to maintain proper winding order in a triangle strip.</span></span> <span data-ttu-id="66121-155">次の図は、ストリップカット インデックスの例を示しています。</span><span class="sxs-lookup"><span data-stu-id="66121-155">The following illustration shows an example of a strip-cut index.</span></span>

![ストリップカット インデックスの図](images/d3d10-ia-strips-cut-value.png)

### <a name="span-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshader-constant-bufferspanconstant-buffer"></a><span data-ttu-id="66121-157"><span id="Shader_Constant_Buffer"></span><span id="shader_constant_buffer"></span><span id="SHADER_CONSTANT_BUFFER"></span><span id="shader-constant-buffer"></span>定数バッファー</span><span class="sxs-lookup"><span data-stu-id="66121-157"><span id="Shader_Constant_Buffer"></span><span id="shader_constant_buffer"></span><span id="SHADER_CONSTANT_BUFFER"></span><span id="shader-constant-buffer"></span>Constant buffer</span></span>

<span data-ttu-id="66121-158">Direct3D には、シェーダー定数バッファーまたは単に定数バッファーと呼ばれる、シェーダー定数を提供するためのバッファーがあります。</span><span class="sxs-lookup"><span data-stu-id="66121-158">Direct3D has a buffer for supplying shader constants called a shader-constant buffer or simply a constant buffer.</span></span> <span data-ttu-id="66121-159">概念的には、次の図に示すように、要素が 1 つの頂点バッファーに似ています。</span><span class="sxs-lookup"><span data-stu-id="66121-159">Conceptually, it looks like a single-element vertex buffer, as shown in the following illustration.</span></span>

![シェーダー定数バッファーの図](images/d3d10-shader-resource-buffer.png)

<span data-ttu-id="66121-161">各要素には 1 ～ 4 成分の定数が格納されます。この値は格納されるデータの形式によって決まります。</span><span class="sxs-lookup"><span data-stu-id="66121-161">Each element stores a 1-to-4 component constant, determined by the format of the data stored.</span></span>

<span data-ttu-id="66121-162">定数バッファーを使用すると、複数のシェーダー定数をグループにまとめて同時にコミットできます。それぞれのシェーダー定数を個別の呼び出しで別々にコミットすることがないので、シェーダー定数の更新に必要な帯域を削減することができます。</span><span class="sxs-lookup"><span data-stu-id="66121-162">Constant buffers reduce the bandwidth required to update shader constants by allowing shader constants to be grouped together and committed at the same time rather than making individual calls to commit each constant separately.</span></span>

<span data-ttu-id="66121-163">シェーダーは、定数バッファーに含まれていない変数を読み取る場合と同様に、変数名を使って定数バッファー内の変数を継続的に直接読み取ります。</span><span class="sxs-lookup"><span data-stu-id="66121-163">A shader continues to read variables in a constant buffer directly by variable name in the same manner variables that are not part of a constant buffer are read.</span></span>

<span data-ttu-id="66121-164">各シェーダー ステージでは最大 15 個の定数バッファーを使用でき、各バッファーには最大 4,096 の定数を保持できます。</span><span class="sxs-lookup"><span data-stu-id="66121-164">Each shader stage allows up to 15 shader-constant buffers; each buffer can hold up to 4096 constants.</span></span>

<span data-ttu-id="66121-165">定数バッファーを使用して、ストリーム出力ステージの結果を保存します。</span><span class="sxs-lookup"><span data-stu-id="66121-165">Use a constant buffer to store the results of the stream-output stage.</span></span>

<span data-ttu-id="66121-166">シェーダーで定数バッファーを宣言する例については、「[シェーダー定数 (DirectX HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="66121-166">See [Shader Constants (DirectX HLSL)](https://msdn.microsoft.com/library/windows/desktop/bb509581) for an example of declaring a constant buffer in a shader.</span></span>

## <a name="span-idtextureresourcesspanspan-idtextureresourcesspanspan-idtextureresourcesspanspan-idtexture-resourcesspantexture-resources"></a><span data-ttu-id="66121-167"><span id="Texture_Resources"></span><span id="texture_resources"></span><span id="TEXTURE_RESOURCES"></span><span id="texture-resources"></span>テクスチャ リソース</span><span class="sxs-lookup"><span data-stu-id="66121-167"><span id="Texture_Resources"></span><span id="texture_resources"></span><span id="TEXTURE_RESOURCES"></span><span id="texture-resources"></span>Texture resources</span></span>


<span data-ttu-id="66121-168">テクスチャ リソースは、テクセルを格納するように設計された、データの構造化されたコレクションです。</span><span class="sxs-lookup"><span data-stu-id="66121-168">A texture resource is a structured collection of data designed to store texels.</span></span> <span data-ttu-id="66121-169">バッファーと異なり、テクスチャは、シェーダー ユニットに読み取られる際にテクスチャ サンプラーでフィルターを適用することができます。</span><span class="sxs-lookup"><span data-stu-id="66121-169">Unlike buffers, textures can be filtered by texture samplers as they are read by shader units.</span></span> <span data-ttu-id="66121-170">テクスチャへのフィルター処理の適用方法はテクスチャの種類に影響されます。</span><span class="sxs-lookup"><span data-stu-id="66121-170">The type of texture impacts how the texture is filtered.</span></span> <span data-ttu-id="66121-171">テクセルは、パイプラインで読み取ったり、書き込んだりすることができるテクスチャの最小単位を表します。</span><span class="sxs-lookup"><span data-stu-id="66121-171">A texel represents the smallest unit of a texture that can be read or written to by the pipeline.</span></span> <span data-ttu-id="66121-172">各テクセルは 1 ～ 4 つの成分を含み、いずれかの DXGI 形式で配置されます (「[**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="66121-172">Each texel contains 1 to 4 components, arranged in one of the DXGI formats (see [**DXGI\_FORMAT**](https://msdn.microsoft.com/library/windows/desktop/bb173059)).</span></span>

<span data-ttu-id="66121-173">テクスチャは構造化されたリソースとして作成されるため、そのサイズがわかります。</span><span class="sxs-lookup"><span data-stu-id="66121-173">Textures are created as a structured resource so that their size is known.</span></span> <span data-ttu-id="66121-174">ただし、各テクスチャはリソース作成時に型指定される場合もありますが、テクスチャをパイプラインにバインドするときにビューを使用して型を完全に指定するという条件で、リソース作成時に型指定されない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="66121-174">However, each texture may be typed or typeless at resource-creation time, as long as the type is fully specified using a view when the texture is bound to the pipeline.</span></span>

-   [<span data-ttu-id="66121-175">テクスチャの種類</span><span class="sxs-lookup"><span data-stu-id="66121-175">Texture types</span></span>](#texture-types)
-   [<span data-ttu-id="66121-176">サブリソース</span><span class="sxs-lookup"><span data-stu-id="66121-176">Subresources</span></span>](#subresources)
-   [<span data-ttu-id="66121-177">強い型指定と弱い型指定</span><span class="sxs-lookup"><span data-stu-id="66121-177">Strong vs. Weak Typing</span></span>](#typed)

### <a name="span-idtexturetypesspanspan-idtexturetypesspanspan-idtexturetypesspanspan-idtexture-typesspantexture-types"></a><span data-ttu-id="66121-178"><span id="Texture_Types"></span><span id="texture_types"></span><span id="TEXTURE_TYPES"></span><span id="texture-types"></span>テクスチャの種類</span><span class="sxs-lookup"><span data-stu-id="66121-178"><span id="Texture_Types"></span><span id="texture_types"></span><span id="TEXTURE_TYPES"></span><span id="texture-types"></span>Texture types</span></span>

<span data-ttu-id="66121-179">テクスチャの種類には 1D、2D、および 3D があり、それぞれミップマップ付きまたはミップマップなしで作成できます。</span><span class="sxs-lookup"><span data-stu-id="66121-179">There are several types of textures: 1D, 2D, 3D, each of which can be created with or without mipmaps.</span></span> <span data-ttu-id="66121-180">Direct3D では、テクスチャ配列とマルチサンプリングされたテクスチャもサポートされています。</span><span class="sxs-lookup"><span data-stu-id="66121-180">Direct3D also supports texture arrays and multisampled textures.</span></span>

-   [<span data-ttu-id="66121-181">1D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="66121-181">1D Texture</span></span>](#texture1d-resource)
-   [<span data-ttu-id="66121-182">1D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="66121-182">1D texture array</span></span>](#texture1d-array-resource)
-   [<span data-ttu-id="66121-183">2D テクスチャと 2D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="66121-183">2D Texture and 2D Texture Array</span></span>](#texture2d-resource)
-   [<span data-ttu-id="66121-184">3D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="66121-184">3D Texture</span></span>](#texture3d-resource)

### <a name="span-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1dresourcespanspan-idtexture1d-resourcespan1d-texture"></a><span data-ttu-id="66121-185"><span id="Texture1D_Resource"></span><span id="texture1d_resource"></span><span id="TEXTURE1D_RESOURCE"></span><span id="texture1d-resource"></span>1D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="66121-185"><span id="Texture1D_Resource"></span><span id="texture1d_resource"></span><span id="TEXTURE1D_RESOURCE"></span><span id="texture1d-resource"></span>1D Texture</span></span>

<span data-ttu-id="66121-186">最も単純な形式の 1D テクスチャには、1 つのテクスチャ座標で処理できるテクスチャ データが格納されます。これをテクセルの配列として視覚化すると次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-186">A 1D texture in its simplest form contains texture data that can be addressed with a single texture coordinate; it can be visualized as an array of texels, as shown in the following illustration.</span></span>

![1D テクスチャの図](images/d3d10-1d-texture.png)

<span data-ttu-id="66121-188">各テクセルには、格納されているデータ形式に応じた色成分がいくつか含まれます。</span><span class="sxs-lookup"><span data-stu-id="66121-188">Each texel contains a number of color components depending on the format of the data stored.</span></span> <span data-ttu-id="66121-189">より複雑なものになると、次の図に示すように、ミップマップ レベルを持つ 1D テクスチャを作成できます。</span><span class="sxs-lookup"><span data-stu-id="66121-189">Adding more complexity, you can create a 1D texture with mipmap levels, as shown in the following illustration.</span></span>

![ミップマップ レベルを持つ 1D テクスチャの図](images/d3d10-resource-texture1d.png)

<span data-ttu-id="66121-191">ミップマップ レベルは、上のレベルよりも 2 の累乗だけ小さいテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="66121-191">A mipmap level is a texture that is a power-of-two smaller than the level above it.</span></span> <span data-ttu-id="66121-192">最上位レベルが最も詳細で (大きく)、レベルが下がるほど小さくなります。1D ミップマップの最小レベルはテクセルを 1 つだけ含みます。</span><span class="sxs-lookup"><span data-stu-id="66121-192">The top-most level contains the most detail, each subsequent level is smaller; for a 1D mipmap, the smallest level contains one texel.</span></span> <span data-ttu-id="66121-193">各レベルの識別には詳細レベル (LOD) と呼ばれるインデックスを使用します。カメラにそれほど近くないジオメトリをレンダリングする場合は、LOD を使って小さいテクスチャにアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="66121-193">The differing levels are identified by an index called a LOD (level-of-detail); you can use the LOD to access a smaller texture when rendering geometry that is not as close to the camera.</span></span>

### <a name="span-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1darrayresourcespanspan-idtexture1d-array-resourcespan1d-texture-array"></a><span data-ttu-id="66121-194"><span id="Texture1D_Array_Resource"></span><span id="texture1d_array_resource"></span><span id="TEXTURE1D_ARRAY_RESOURCE"></span><span id="texture1d-array-resource"></span>1D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="66121-194"><span id="Texture1D_Array_Resource"></span><span id="texture1d_array_resource"></span><span id="TEXTURE1D_ARRAY_RESOURCE"></span><span id="texture1d-array-resource"></span>1D texture array</span></span>

<span data-ttu-id="66121-195">Direct3D 10 には、テクスチャの配列用の新しいデータ構造も用意されています。</span><span class="sxs-lookup"><span data-stu-id="66121-195">Direct3D 10 also has a new data structure for an array of textures.</span></span> <span data-ttu-id="66121-196">1D テクスチャの配列は概念的に次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-196">An array of 1D textures looks conceptually like the following illustration.</span></span>

![1D テクスチャ配列の図](images/d3d10-resource-texture1darray.png)

<span data-ttu-id="66121-198">このテクスチャ配列には 3 つのテクスチャが含まれています。</span><span class="sxs-lookup"><span data-stu-id="66121-198">This texture array contains three textures.</span></span> <span data-ttu-id="66121-199">3 つのテクスチャはそれぞれテクスチャ幅が 5 になっています (5 は最初のレイヤーの要素数)。</span><span class="sxs-lookup"><span data-stu-id="66121-199">Each of the three textures has a texture width of 5 (which is the number of elements in the first layer).</span></span> <span data-ttu-id="66121-200">また、各テクスチャには 3 レイヤーのミップマップも格納されています。</span><span class="sxs-lookup"><span data-stu-id="66121-200">Each texture also contains a 3-layer mipmap.</span></span>

<span data-ttu-id="66121-201">Direct3D のすべてのテクスチャ配列は、テクスチャの同次配列です。つまり、1 つのテクスチャ配列内にあるテクスチャはすべて、データ形式とサイズが (テクスチャ幅とミップマップ レベル数も含めて) 同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="66121-201">All texture arrays in Direct3D are a homogeneous array of textures; this means that every texture in a texture array must have the same data format and size (including texture width and number of mipmap levels).</span></span> <span data-ttu-id="66121-202">各配列に含まれるすべてのテクスチャのサイズが一致してさえいれば、さまざまなサイズのテクスチャ配列を作成できます。</span><span class="sxs-lookup"><span data-stu-id="66121-202">You may create texture arrays of different sizes, as long as all the textures in each array match in size.</span></span>

### <a name="span-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2dresourcespanspan-idtexture2d-resourcespan2d-texture-and-2d-texture-array"></a><span data-ttu-id="66121-203"><span id="Texture2D_Resource"></span><span id="texture2d_resource"></span><span id="TEXTURE2D_RESOURCE"></span><span id="texture2d-resource"></span>2D テクスチャと 2D テクスチャ配列</span><span class="sxs-lookup"><span data-stu-id="66121-203"><span id="Texture2D_Resource"></span><span id="texture2d_resource"></span><span id="TEXTURE2D_RESOURCE"></span><span id="texture2d-resource"></span>2D Texture and 2D Texture Array</span></span>

<span data-ttu-id="66121-204">Texture2D リソースにはテクセルの 2D グリッドが 1 つ含まれています。</span><span class="sxs-lookup"><span data-stu-id="66121-204">A Texture2D resource contains a 2D grid of texels.</span></span> <span data-ttu-id="66121-205">各テクセルは u ベクトルと v ベクトルで指定できます。</span><span class="sxs-lookup"><span data-stu-id="66121-205">Each texel is addressable by a u, v vector.</span></span> <span data-ttu-id="66121-206">これはテクスチャ リソースであるため、ミップマップ レベルとサブリソースが格納される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="66121-206">Because it is a texture resource, it may contain mipmap levels, and subresources.</span></span> <span data-ttu-id="66121-207">すべてのデータが設定された 2D テクスチャ リソースは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-207">A fully populated 2D texture resource looks like the following illustration.</span></span>

![2D テクスチャ リソースの図](images/d3d10-resource-texture2d.png)

<span data-ttu-id="66121-209">このテクスチャ リソースには 1 つの 3x5 テクスチャと 3 つのミップマップ レベルが格納されています。</span><span class="sxs-lookup"><span data-stu-id="66121-209">This texture resource contains a single 3x5 texture with three mipmap levels.</span></span>

<span data-ttu-id="66121-210">Texture2DArray リソースは 2D テクスチャの同次配列であるため、各テクスチャのデータ形式とサイズは (ミップマップ レベルを含めて) 同じです。</span><span class="sxs-lookup"><span data-stu-id="66121-210">A Texture2DArray resource is a homogeneous array of 2D textures; that is, each texture has the same data format and dimensions (including mipmap levels).</span></span> <span data-ttu-id="66121-211">このリソースは、テクスチャに 2D データが含まれていることを除けば 1D テクスチャ配列とレイアウトが似ています。したがって、次のような図になります。</span><span class="sxs-lookup"><span data-stu-id="66121-211">It has a similar layout as the 1D texture array except that the textures now contain 2D data, and therefore looks like the following illustration.</span></span>

![2D テクスチャ配列のリソースの図](images/d3d10-resource-texture2darray.png)

<span data-ttu-id="66121-213">このテクスチャ配列には 3 つのテクスチャが含まれています。各テクスチャは 3x5 で、2 つのミップマップ レベルを持ちます。</span><span class="sxs-lookup"><span data-stu-id="66121-213">This texture array contains three textures; each texture is 3x5 with two mipmap levels.</span></span>

### <a name="span-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanspan-idtexture2darrayresourceasatexturecubespanusing-a-texture2darray-as-a-texture-cube"></a><span data-ttu-id="66121-214"><span id="Texture2DArray_Resource_as_a_Texture_Cube"></span><span id="texture2darray_resource_as_a_texture_cube"></span><span id="TEXTURE2DARRAY_RESOURCE_AS_A_TEXTURE_CUBE"></span>テクスチャ キューブとしての Texture2DArray の使用</span><span class="sxs-lookup"><span data-stu-id="66121-214"><span id="Texture2DArray_Resource_as_a_Texture_Cube"></span><span id="texture2darray_resource_as_a_texture_cube"></span><span id="TEXTURE2DARRAY_RESOURCE_AS_A_TEXTURE_CUBE"></span>Using a Texture2DArray as a Texture Cube</span></span>

<span data-ttu-id="66121-215">テクスチャ キューブは、6 つのテクスチャ (キューブの各面に 1 つずつ) が含まれた 2D テクスチャ配列です。</span><span class="sxs-lookup"><span data-stu-id="66121-215">A texture cube is a 2D texture array that contains 6 textures, one for each face of the cube.</span></span> <span data-ttu-id="66121-216">すべてのデータが設定されたテクスチャ キューブは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-216">A fully populated texture cube looks like the following illustration.</span></span>

![テクスチャ キューブを表す 2D テクスチャ配列のリソースの図](images/d3d10-resource-texturecube.png)

<span data-ttu-id="66121-218">6 つのテクスチャが含まれた 2D テクスチャ配列は、キューブ テクスチャ ビューを使ってパイプラインにバインドした後に、キューブ マップ組み込み関数を使ってシェーダー内から読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="66121-218">A 2D texture array that contains 6 textures may be read from within shaders with the cube map intrinsic functions, after they are bound to the pipeline with a cube-texture view.</span></span> <span data-ttu-id="66121-219">テクスチャ キューブは、テクスチャ キューブの中心を起点とする 3D ベクトルによってシェーダーで処理されます。</span><span class="sxs-lookup"><span data-stu-id="66121-219">Texture cubes are addressed from the shader with a 3D vector pointing out from the center of the texture cube.</span></span>

### <a name="span-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3dresourcespanspan-idtexture3d-resourcespan3d-texture"></a><span data-ttu-id="66121-220"><span id="Texture3D_Resource"></span><span id="texture3d_resource"></span><span id="TEXTURE3D_RESOURCE"></span><span id="texture3d-resource"></span>3D テクスチャ</span><span class="sxs-lookup"><span data-stu-id="66121-220"><span id="Texture3D_Resource"></span><span id="texture3d_resource"></span><span id="TEXTURE3D_RESOURCE"></span><span id="texture3d-resource"></span>3D Texture</span></span>

<span data-ttu-id="66121-221">Texture3D リソース (ボリューム テクスチャとも呼ばれます) にはテクセルの 3D ボリュームが格納されます。</span><span class="sxs-lookup"><span data-stu-id="66121-221">A Texture3D resource (also known as a volume texture) contains a 3D volume of texels.</span></span> <span data-ttu-id="66121-222">これはテクスチャ リソースであるため、ミップマップ レベルが含まれる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="66121-222">Since it is a texture resource, it may contain mipmap levels.</span></span> <span data-ttu-id="66121-223">すべてのデータが設定された 3D テクスチャは次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-223">A fully populated 3D texture looks like the following illustration.</span></span>

![3D テクスチャ リソースの図](images/d3d10-resource-texture3d.png)

<span data-ttu-id="66121-225">3D テクスチャ ミップマップ スライスを (レンダー ターゲット ビューを使って) レンダー ターゲット出力としてバインドした場合、3D テクスチャは n 個のスライスの 2D テクスチャ配列と同じように動作します。</span><span class="sxs-lookup"><span data-stu-id="66121-225">When a 3D texture mipmap slice is bound as a render target output (with a render-target view), the 3D texture behaves identically to a 2D texture array with n slices.</span></span> <span data-ttu-id="66121-226">特定のレンダー スライスはジオメトリ シェーダー ステージで選択します。</span><span class="sxs-lookup"><span data-stu-id="66121-226">The particular render slice is chosen from the geometry-shader stage.</span></span>

<span data-ttu-id="66121-227">3D テクスチャ配列という概念は存在しません。そのため、3D テクスチャのサブリソースは単一のミップマップ レベルになります。</span><span class="sxs-lookup"><span data-stu-id="66121-227">There is no concept of a 3D texture array; therefore a 3D texture subresource is a single mipmap level.</span></span>

### <a name="span-idsubresourcesspanspan-idsubresourcesspanspan-idsubresourcesspansubresources"></a><span data-ttu-id="66121-228"><span id="Subresources"></span><span id="subresources"></span><span id="SUBRESOURCES"></span>サブリソース</span><span class="sxs-lookup"><span data-stu-id="66121-228"><span id="Subresources"></span><span id="subresources"></span><span id="SUBRESOURCES"></span>Subresources</span></span>

<span data-ttu-id="66121-229">Direct3D API は、リソース全体またはリソースのサブセットを参照します。</span><span class="sxs-lookup"><span data-stu-id="66121-229">The Direct3D API references entire resources or subsets of resources.</span></span> <span data-ttu-id="66121-230">リソースの一部を指定するために、Direct3D では*サブリソース*という用語が新たに用意されています。つまり、リソースのサブセットのことです。</span><span class="sxs-lookup"><span data-stu-id="66121-230">To specify portion of resources, Direct3D has coined the term *subresources*, which means a subset of a resource.</span></span>

<span data-ttu-id="66121-231">バッファーは単一のサブリソースと定義されます。</span><span class="sxs-lookup"><span data-stu-id="66121-231">A buffer is defined as a single subresource.</span></span> <span data-ttu-id="66121-232">テクスチャはもう少し複雑です。テクスチャの種類が複数存在していて (1D、2D など)、その一部ではミップマップ レベルやテクスチャ配列がサポートされているためです。</span><span class="sxs-lookup"><span data-stu-id="66121-232">Textures are a little more complicated as there are several different texture types (1D, 2D, etc.) some of which support mipmap levels and/or texture arrays.</span></span> <span data-ttu-id="66121-233">最も単純なケースから始めると、1D テクスチャは単一のサブリソースとして定義され、次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-233">Beginning with the simplest case, a 1D texture is defined as a single subresource, as shown in the following illustration.</span></span>

![1D テクスチャの図](images/d3d10-1d-texture.png)

<span data-ttu-id="66121-235">つまり、1D テクスチャを構成するテクセルの配列は単一のサブリソースに含まれます。</span><span class="sxs-lookup"><span data-stu-id="66121-235">This means that the array of texels that make up a 1D texture are contained in a single subresource.</span></span>

<span data-ttu-id="66121-236">1D テクスチャを 3 つのミップマップ レベルで拡張した場合、それを視覚化すると次のようになります。</span><span class="sxs-lookup"><span data-stu-id="66121-236">If you expand a 1D texture with three mipmap levels, it can be visualized like this.</span></span>

![ミップマップ レベルを持つ 1D テクスチャの図](images/d3d10-resource-texture1d.png)

<span data-ttu-id="66121-238">これを 3 つのサブテクスチャで構成される単一のテクスチャと考えます。</span><span class="sxs-lookup"><span data-stu-id="66121-238">Think of this as a single texture that is made up of three subtextures.</span></span> <span data-ttu-id="66121-239">各サブテクスチャは 1 つのサブリソースとしてカウントされます。そのため、この 1D テクスチャには 3 つのサブリソースが含まれます。</span><span class="sxs-lookup"><span data-stu-id="66121-239">Each subtexture is counted as a subresource, so this 1D texture contains 3 subresources.</span></span> <span data-ttu-id="66121-240">サブテクスチャ (またはサブリソース) は、単一テクスチャ用の詳細レベル (LOD) を使ってインデックスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="66121-240">A subtexture (or subresource) can be indexed using the level-of-detail (LOD) for a single texture.</span></span> <span data-ttu-id="66121-241">テクスチャの配列を使用する場合、特定のサブテクスチャにアクセスするには LOD とその特定のテクスチャの両方が必要です。</span><span class="sxs-lookup"><span data-stu-id="66121-241">When using an array of textures, accessing a particular subtexture requires both the LOD and the particular texture.</span></span> <span data-ttu-id="66121-242">または、API によって、この 2 つの情報を以下に示すような 0 から始まる単一のサブリソース インデックスにまとめます。</span><span class="sxs-lookup"><span data-stu-id="66121-242">Alternately, the API combines these two pieces of information into a single zero-based subresource index as shown here.</span></span>

![0 から始まるサブリソース インデックスの図](images/d3d10-resource-texture1darray-sub-indexing.png)

### <a name="span-idselectingsubresourcesspanspan-idselectingsubresourcesspanspan-idselectingsubresourcesspanselecting-subresources"></a><span data-ttu-id="66121-244"><span id="Selecting_Subresources"></span><span id="selecting_subresources"></span><span id="SELECTING_SUBRESOURCES"></span>サブリソースの選択</span><span class="sxs-lookup"><span data-stu-id="66121-244"><span id="Selecting_Subresources"></span><span id="selecting_subresources"></span><span id="SELECTING_SUBRESOURCES"></span>Selecting Subresources</span></span>

<span data-ttu-id="66121-245">API の中にはリソース全体にアクセスするものもあれば、リソースの一部にアクセスするものもあります。</span><span class="sxs-lookup"><span data-stu-id="66121-245">Some APIs access an entire resource, others access a portion of a resource.</span></span> <span data-ttu-id="66121-246">一般的に、リソースの一部にアクセスする API は、ビュー記述を使用してアクセス対象のサブリソースを指定します。</span><span class="sxs-lookup"><span data-stu-id="66121-246">The APIs that access a portion of a resource generally use a view description to specify the subresources to access.</span></span>

<span data-ttu-id="66121-247">以下の図は、テクスチャの配列にアクセスする際にビュー記述で使用される用語を表しています。</span><span class="sxs-lookup"><span data-stu-id="66121-247">These figures illustrate the terms used by a view description when accessing an array of textures.</span></span>

### <a name="span-idarrayslicespanspan-idarrayslicespanspan-idarrayslicespanarray-slice"></a><span data-ttu-id="66121-248"><span id="Array_Slice"></span><span id="array_slice"></span><span id="ARRAY_SLICE"></span>配列スライス</span><span class="sxs-lookup"><span data-stu-id="66121-248"><span id="Array_Slice"></span><span id="array_slice"></span><span id="ARRAY_SLICE"></span>Array Slice</span></span>

<span data-ttu-id="66121-249">あるテクスチャの配列で、各テクスチャにミップマップが用意されている場合、次の図に示すように、(白い長方形で表されている) 配列スライスには 1 つのテクスチャとそのすべてのサブテクスチャが含まれます。</span><span class="sxs-lookup"><span data-stu-id="66121-249">Given an array of textures, each texture with mipmaps, an array slice (represented by the white rectangle) includes one texture and all of its subtextures, as shown in the following illustration.</span></span>

![配列スライスの図](images/d3d10-resource-array-slice.png)

### <a name="span-idmipslicespanspan-idmipslicespanspan-idmipslicespanmip-slice"></a><span data-ttu-id="66121-251"><span id="Mip_Slice"></span><span id="mip_slice"></span><span id="MIP_SLICE"></span>ミップ スライス</span><span class="sxs-lookup"><span data-stu-id="66121-251"><span id="Mip_Slice"></span><span id="mip_slice"></span><span id="MIP_SLICE"></span>Mip Slice</span></span>

<span data-ttu-id="66121-252">次の図に示すように、(白い長方形で表されている) ミップ スライスには配列内のすべてのテクスチャのミップマップ レベルが 1 つ含まれます。</span><span class="sxs-lookup"><span data-stu-id="66121-252">A mip slice (represented by the white rectangle) includes one mipmap level for every texture in an array, as shown in the following illustration.</span></span>

![ミップ スライスの図](images/d3d10-resource-mip-slice.png)

### <a name="span-idselectingasinglesubresourcespanspan-idselectingasinglesubresourcespanspan-idselectingasinglesubresourcespanselecting-a-single-subresource"></a><span data-ttu-id="66121-254"><span id="Selecting_a_Single_Subresource"></span><span id="selecting_a_single_subresource"></span><span id="SELECTING_A_SINGLE_SUBRESOURCE"></span>単一サブリソースの選択</span><span class="sxs-lookup"><span data-stu-id="66121-254"><span id="Selecting_a_Single_Subresource"></span><span id="selecting_a_single_subresource"></span><span id="SELECTING_A_SINGLE_SUBRESOURCE"></span>Selecting a Single Subresource</span></span>

<span data-ttu-id="66121-255">次の図に示すように、単一のリソースを選択するには、前述の 2 種類のスライスを使用します。</span><span class="sxs-lookup"><span data-stu-id="66121-255">You can use these two types of slices to choose a single subresource, as shown in the following illustration.</span></span>

![配列スライスとミップ スライスを使用してサブリソースを選択した場合の図](images/d3d10-resource-subresources-1.png)

### <a name="span-idselectingmultiplesubresourcesspanspan-idselectingmultiplesubresourcesspanspan-idselectingmultiplesubresourcesspanselecting-multiple-subresources"></a><span data-ttu-id="66121-257"><span id="Selecting_Multiple_Subresources"></span><span id="selecting_multiple_subresources"></span><span id="SELECTING_MULTIPLE_SUBRESOURCES"></span>複数のサブリソースの選択</span><span class="sxs-lookup"><span data-stu-id="66121-257"><span id="Selecting_Multiple_Subresources"></span><span id="selecting_multiple_subresources"></span><span id="SELECTING_MULTIPLE_SUBRESOURCES"></span>Selecting Multiple Subresources</span></span>

<span data-ttu-id="66121-258">また、複数のサブリソースを選択するには、ミップマップ レベル数やテクスチャ数を指定して、前述の 2 種類のスライスを使用します。</span><span class="sxs-lookup"><span data-stu-id="66121-258">Or you can use these two types of slices with the number of mipmap levels and/or number of textures, to choose multiple subresources.</span></span>

![複数のサブリソースを選択した場合の図](images/d3d10-resource-subresources-2.png)

<span data-ttu-id="66121-260">たいていの場合、使用するテクスチャの種類、ミップマップの有無、およびテクスチャ配列の有無にかかわらず、特定のサブリソースのインデックスを計算できるように用意されたヘルパー関数があります。</span><span class="sxs-lookup"><span data-stu-id="66121-260">Regardless of what texture type you are using, with or without mipmaps, with or without a texture array, there are often helper functions provided to compute the index of a particular subresource.</span></span>

### <a name="span-idtypedspanspan-idtypedspanspan-idtypedspanstrong-vs-weak-typing"></a><span data-ttu-id="66121-261"><span id="Typed"></span><span id="typed"></span><span id="TYPED"></span>強い型指定と弱い型指定</span><span class="sxs-lookup"><span data-stu-id="66121-261"><span id="Typed"></span><span id="typed"></span><span id="TYPED"></span>Strong vs. Weak Typing</span></span>

<span data-ttu-id="66121-262">完全に型指定されたリソースを作成すると、そのリソースの形式はそのリソースを作成したときの形式に制限されます。</span><span class="sxs-lookup"><span data-stu-id="66121-262">Creating a fully-typed resource restricts the resource to the format it was created with.</span></span> <span data-ttu-id="66121-263">これによりランタイムによるアクセスが最適化されます。特に、アプリケーションでマップできないことを示すフラグを使ってリソースを作成する場合は有効です。</span><span class="sxs-lookup"><span data-stu-id="66121-263">This enables the runtime to optimize access, especially if the resource is created with flags indicating that it cannot be mapped by the application.</span></span> <span data-ttu-id="66121-264">型を指定して作成したリソースは、ビュー機構を使って再解釈することができません。</span><span class="sxs-lookup"><span data-stu-id="66121-264">Resources created with a specific type cannot be reinterpreted using the view mechanism.</span></span>

<span data-ttu-id="66121-265">型指定なしのリソースでは、最初にリソースを作成したときのデータ型は不明です。</span><span class="sxs-lookup"><span data-stu-id="66121-265">In a typeless resource, the data type is unknown when the resource is first created.</span></span> <span data-ttu-id="66121-266">アプリケーションは、型指定なしの利用可能な形式からいずれかを選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="66121-266">The application must choose from the available typeless formats.</span></span> <span data-ttu-id="66121-267">また、割り当てるメモリのサイズと、ランタイムでミップマップのサブテクスチャを生成する必要があるかどうかも指定しなければなりません。</span><span class="sxs-lookup"><span data-stu-id="66121-267">You must specify the size of the memory to allocate and whether the runtime will need to generate the subtextures in a mipmap.</span></span>

<span data-ttu-id="66121-268">ただし、正確なデータ形式 (整数、浮動小数点値、符号なし整数などとして、メモリが解釈されるかどうか) はビューを使ってリソースがパイプラインにバインドされるまで決定されません。</span><span class="sxs-lookup"><span data-stu-id="66121-268">However, the exact data format (whether the memory will be interpreted as integers, floating point values, unsigned integers etc.) is not determined until the resource is bound to the pipeline with a view.</span></span> <span data-ttu-id="66121-269">テクスチャ形式はテクスチャがパイプラインにバインドされるまで柔軟性が維持されるため、このリソースは弱く型指定されたストレージと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="66121-269">As the texture format remains flexible until the texture is bound to the pipeline, the resource is referred to as weakly typed storage.</span></span> <span data-ttu-id="66121-270">弱く型指定されたストレージには、新しい形式の成分ビットが古い形式のビット数と一致している限り、(別の形式で) 再使用または再解釈できるという利点があります。</span><span class="sxs-lookup"><span data-stu-id="66121-270">Weakly typed storage has the advantage that it can be reused or reinterpreted (in another format) as long as the component bit of the new format matches the bit count of the old format.</span></span>

<span data-ttu-id="66121-271">各パイプライン ステージに、それぞれの場所での形式を完全に修飾する一意のビューがある限り、1 つのリソースを複数のパイプライン ステージにバインドすることができます。</span><span class="sxs-lookup"><span data-stu-id="66121-271">A single resource can be bound to multiple pipeline stages as long as each has a unique view, which fully qualifies the formats at each location.</span></span> <span data-ttu-id="66121-272">たとえば、型指定なし形式で作成したリソースを、パイプラインの別々の場所で FLOAT 形式および UINT 形式として同時に使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="66121-272">For example, a resource created with a typeless format could be used as a FLOAT format and a UINT format at different locations in the pipeline simultaneously.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="66121-273"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="66121-273"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="66121-274">リソース</span><span class="sxs-lookup"><span data-stu-id="66121-274">Resources</span></span>](resources.md)
