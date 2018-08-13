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
# <a name="introduction-to-buffers"></a><span data-ttu-id="d474c-104">バッファーの概要</span><span class="sxs-lookup"><span data-stu-id="d474c-104">Introduction to buffers</span></span>


<span data-ttu-id="d474c-105">バッファー リソースは完全に型指定されたデータのコレクションであり、複数の要素にグループ化されます。</span><span class="sxs-lookup"><span data-stu-id="d474c-105">A buffer resource is a collection of fully typed data, grouped into elements.</span></span> <span data-ttu-id="d474c-106">バッファーには、"頂点バッファー"** 内のテクスチャ座標、"インデックス バッファー"** 内のインデックス、"定数バッファー"** 内のシェーダー定数データ、位置ベクトル、法線ベクトル、デバイスの状態などのデータが格納されます。</span><span class="sxs-lookup"><span data-stu-id="d474c-106">Buffers store data, such as texture coordinates in a *vertex buffer*, indexes in an *index buffer*, shader constants data in a *constant buffer*, position vectors, normal vectors, or device state.</span></span>

<span data-ttu-id="d474c-107">1 ~ 4 コンポーネントのバッファーの要素が構成されています。</span><span class="sxs-lookup"><span data-stu-id="d474c-107">A buffer element is made up of 1 to 4 components.</span></span> <span data-ttu-id="d474c-108">バッファー要素には、圧縮済みデータ値 (R8G8B8A8 サーフェス値)、単一の 8 ビット整数、または 4 つの 32 ビット浮動小数点値を含めることができます。</span><span class="sxs-lookup"><span data-stu-id="d474c-108">Buffer elements can include packed data values (like R8G8B8A8 surface values), single 8-bit integers, or four 32-bit floating point values.</span></span>

<span data-ttu-id="d474c-109">バッファーは構造化されていないリソースとして作成されます。</span><span class="sxs-lookup"><span data-stu-id="d474c-109">A buffer is created as an unstructured resource.</span></span> <span data-ttu-id="d474c-110">構造化されていないため、バッファー ミップマップ レベルを含めることはできません、フィルター読み込む場合、アクセスできないおよびマルチ サンプルことはできません。</span><span class="sxs-lookup"><span data-stu-id="d474c-110">Because it is unstructured, a buffer cannot contain any mipmap levels, it cannot get filtered when read, and it cannot be multisampled.</span></span>

## <a name="span-idbuffertypesspanspan-idbuffertypesspanspan-idbuffertypesspanbuffer-types"></a><span data-ttu-id="d474c-111"><span id="Buffer_Types"></span><span id="buffer_types"></span><span id="BUFFER_TYPES"></span>バッファーの種類</span><span class="sxs-lookup"><span data-stu-id="d474c-111"><span id="Buffer_Types"></span><span id="buffer_types"></span><span id="BUFFER_TYPES"></span>Buffer Types</span></span>


<span data-ttu-id="d474c-112">Direct3D 11 でサポートされているバッファー リソースの種類を次に示します。</span><span class="sxs-lookup"><span data-stu-id="d474c-112">The following are the buffer resource types supported by Direct3D 11.</span></span>

-   [<span data-ttu-id="d474c-113">頂点バッファー</span><span class="sxs-lookup"><span data-stu-id="d474c-113">Vertex Buffer</span></span>](#vertex-buffer)
-   [<span data-ttu-id="d474c-114">インデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="d474c-114">Index Buffer</span></span>](#index-buffer)
-   [<span data-ttu-id="d474c-115">一定のバッファー</span><span class="sxs-lookup"><span data-stu-id="d474c-115">Constant Buffer</span></span>](#shader-constant-buffer)

### <a name="span-idvertexbufferspanspan-idvertexbufferspanspan-idvertexbufferspanspan-idvertex-bufferspanvertex-buffer"></a><span data-ttu-id="d474c-116"><span id="Vertex_Buffer"></span><span id="vertex_buffer"></span><span id="VERTEX_BUFFER"></span><span id="vertex-buffer"></span>頂点バッファー</span><span class="sxs-lookup"><span data-stu-id="d474c-116"><span id="Vertex_Buffer"></span><span id="vertex_buffer"></span><span id="VERTEX_BUFFER"></span><span id="vertex-buffer"></span>Vertex Buffer</span></span>

<span data-ttu-id="d474c-117">頂点バッファーには、図形を定義するために使用する頂点データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d474c-117">A vertex buffer contains the vertex data used to define your geometry.</span></span> <span data-ttu-id="d474c-118">頂点データには、位置座標、色データ、テクスチャ座標データ、法線データなどが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d474c-118">Vertex data includes position coordinates, color data, texture coordinate data, normal data, and so on.</span></span>

<span data-ttu-id="d474c-119">頂点バッファーの最も簡単な例は、位置データにはのみが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d474c-119">The simplest example of a vertex buffer is one that only contains position data.</span></span> <span data-ttu-id="d474c-120">これを視覚化すると次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="d474c-120">It can be visualized like the following illustration.</span></span>

![位置データを格納する頂点バッファーの図](images/d3d10-resources-single-element-vb2.png)

<span data-ttu-id="d474c-122">多くの場合、頂点バッファーには 3D の頂点を完全に指定するために必要なすべてのデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d474c-122">More often, a vertex buffer contains all the data needed to fully specify 3D vertices.</span></span> <span data-ttu-id="d474c-123">頂点ごとの位置座標、法線座標、およびテクスチャ座標を格納した頂点バッファーが、その一例です。</span><span class="sxs-lookup"><span data-stu-id="d474c-123">An example of this could be a vertex buffer that contains per-vertex position, normal and texture coordinates.</span></span> <span data-ttu-id="d474c-124">このようなデータは、次の図に示すように、頂点ごとの要素のセットとしてまとめられます。</span><span class="sxs-lookup"><span data-stu-id="d474c-124">This data is usually organized as sets of per-vertex elements, as shown in the following illustration.</span></span>

![位置、法線、およびテクスチャのデータを含む頂点バッファーの図](images/d3d10-vertex-buffer-element.png)

<span data-ttu-id="d474c-126">この頂点バッファーには、頂点のデータが含まれます。各頂点 (位置、通常、およびテクスチャ) の 3 つの要素が格納されます。</span><span class="sxs-lookup"><span data-stu-id="d474c-126">This vertex buffer contains per-vertex data; each vertex stores three elements (position, normal, and texture coordinates).</span></span> <span data-ttu-id="d474c-127">一般的に、位置座標と法線座標はそれぞれ 3 つの 32 ビット浮動小数点を使って指定され、テクスチャ座標は 2 つの 32 ビット浮動小数点を使って指定されます。</span><span class="sxs-lookup"><span data-stu-id="d474c-127">The position and normal are each typically specified using three 32-bit floats and the texture coordinates using two 32-bit floats.</span></span>

<span data-ttu-id="d474c-128">頂点バッファーからデータにアクセスするには、アクセス権] と、次のような追加のバッファー パラメーターをどの頂点を認識する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d474c-128">To access data from a vertex buffer you need to know which vertex to access, plus the following additional buffer parameters:</span></span>

-   <span data-ttu-id="d474c-129">オフセット - バッファーの先頭から最初の頂点データまでのバイト数です。</span><span class="sxs-lookup"><span data-stu-id="d474c-129">Offset - the number of bytes from the start of the buffer to the data for the first vertex.</span></span>
-   <span data-ttu-id="d474c-130">BaseVertexLocation - オフセットから、該当する描画呼び出しで使用される最初の頂点までのバイト数です。</span><span class="sxs-lookup"><span data-stu-id="d474c-130">BaseVertexLocation - the number of bytes from the offset to the first vertex used by the appropriate draw call.</span></span>

<span data-ttu-id="d474c-131">頂点バッファーを作成する前に、レイアウトを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d474c-131">Before you create a vertex buffer, you need to define its layout.</span></span> <span data-ttu-id="d474c-132">入力レイアウト オブジェクトの作成後は、[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)にバインドします。</span><span class="sxs-lookup"><span data-stu-id="d474c-132">After the input-layout object is created, you bind it to the [Input Assembler (IA) stage](input-assembler-stage--ia-.md).</span></span>

### <a name="span-idindexbufferspanspan-idindexbufferspanspan-idindexbufferspanspan-idindex-bufferspanindex-buffer"></a><span data-ttu-id="d474c-133"><span id="Index_Buffer"></span><span id="index_buffer"></span><span id="INDEX_BUFFER"></span><span id="index-buffer"></span>インデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="d474c-133"><span id="Index_Buffer"></span><span id="index_buffer"></span><span id="INDEX_BUFFER"></span><span id="index-buffer"></span>Index Buffer</span></span>

<span data-ttu-id="d474c-134">インデックス バッファーでは、頂点バッファー整数オフセットを含む、プリミティブのレンダリングをより効率的に使用されます。</span><span class="sxs-lookup"><span data-stu-id="d474c-134">Index buffers contain integer offsets into vertex buffers and are used to render primitives more efficiently.</span></span> <span data-ttu-id="d474c-135">インデックス バッファーは 16 ビットまたは 32 ビットの連続するインデックスを格納します。各インデックスは頂点バッファーの頂点を識別するのに使用されます。</span><span class="sxs-lookup"><span data-stu-id="d474c-135">An index buffer contains a sequential set of 16-bit or 32-bit indices; each index is used to identify a vertex in a vertex buffer.</span></span> <span data-ttu-id="d474c-136">インデックス バッファーを視覚化すると次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="d474c-136">An index buffer can be visualized like the following illustration.</span></span>

![インデックス バッファーの図](images/d3d10-index-buffer.png)

<span data-ttu-id="d474c-138">インデックス バッファーに格納される一連のインデックスの位置は、次のパラメーターを使用して特定します。</span><span class="sxs-lookup"><span data-stu-id="d474c-138">The sequential indices stored in an index buffer are located with the following parameters:</span></span>

-   <span data-ttu-id="d474c-139">オフセット - インデックス バッファーのベース アドレスからバイト数。</span><span class="sxs-lookup"><span data-stu-id="d474c-139">Offset - the number of bytes from the base address of the index buffer.</span></span>
-   <span data-ttu-id="d474c-140">StartIndexLocation のベース アドレスとオフセットから最初のインデックス バッファー要素を指定します。</span><span class="sxs-lookup"><span data-stu-id="d474c-140">StartIndexLocation - specifies the first index buffer element from the base address and the offset.</span></span> <span data-ttu-id="d474c-141">開始位置を表示する最初のインデックスを表します。</span><span class="sxs-lookup"><span data-stu-id="d474c-141">The start location represents the first index to render.</span></span>
-   <span data-ttu-id="d474c-142">IndexCount - レンダリングするインデックスの数です。</span><span class="sxs-lookup"><span data-stu-id="d474c-142">IndexCount - the number of indices to render.</span></span>

<span data-ttu-id="d474c-143">インデックス バッファーの最初のインデックス バッファーのベース アドレス オフセット (バイト単位) + StartIndexLocation = \ \* ElementSize (バイト単位)。</span><span class="sxs-lookup"><span data-stu-id="d474c-143">Start of Index Buffer = Index Buffer Base Address + Offset (bytes) + StartIndexLocation \* ElementSize (bytes);</span></span>

<span data-ttu-id="d474c-144">この計算] では、ElementSize は、2 つまたは 4 バイト各インデックス バッファー要素のサイズです。</span><span class="sxs-lookup"><span data-stu-id="d474c-144">In this calculation, ElementSize is the size of each index buffer element, which is either two or four bytes.</span></span>

### <a name="span-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshaderconstantbufferspanspan-idshader-constant-bufferspanconstant-buffer"></a><span data-ttu-id="d474c-145"><span id="Shader_Constant_Buffer"></span><span id="shader_constant_buffer"></span><span id="SHADER_CONSTANT_BUFFER"></span><span id="shader-constant-buffer"></span>一定のバッファー</span><span class="sxs-lookup"><span data-stu-id="d474c-145"><span id="Shader_Constant_Buffer"></span><span id="shader_constant_buffer"></span><span id="SHADER_CONSTANT_BUFFER"></span><span id="shader-constant-buffer"></span>Constant Buffer</span></span>

<span data-ttu-id="d474c-146">定数バッファーでは、効率的にパイプラインにシェーダー定数のデータを提供することができます。</span><span class="sxs-lookup"><span data-stu-id="d474c-146">A constant buffer allows you to efficiently supply shader constants data to the pipeline.</span></span> <span data-ttu-id="d474c-147">ストリーム出力ステージの結果を格納するのに定数バッファーを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="d474c-147">You can use a constant buffer to store the results of the stream-output stage.</span></span> <span data-ttu-id="d474c-148">概念的には、定数のバッファーは、次の図に示すように、1 つの要素の頂点バッファーと同じように検索します。</span><span class="sxs-lookup"><span data-stu-id="d474c-148">Conceptually, a constant buffer looks just like a single-element vertex buffer, as shown in the following illustration.</span></span>

![シェーダー定数バッファーの図](images/d3d10-shader-resource-buffer.png)

<span data-ttu-id="d474c-150">各要素には 1 ～ 4 成分の定数が格納されます。この値は格納されるデータの形式によって決まります。</span><span class="sxs-lookup"><span data-stu-id="d474c-150">Each element stores a 1-to-4 component constant, determined by the format of the data stored.</span></span>

<span data-ttu-id="d474c-151">一定のバッファーは、他のバインド フラグと組み合わせて使用することはできませんが、1 つのバインド フラグのみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="d474c-151">A constant buffer can only use a single bind flag , which cannot be combined with any other bind flag.</span></span>

<span data-ttu-id="d474c-152">シェーダーからシェーダー定数のバッファーを読み、HLSL 読み込み関数を使用します。</span><span class="sxs-lookup"><span data-stu-id="d474c-152">To read a shader-constant buffer from a shader, use an HLSL load function.</span></span> <span data-ttu-id="d474c-153">各シェーダー ステージでは最大 15 個の定数バッファーを使用でき、各バッファーには最大 4,096 の定数を保持できます。</span><span class="sxs-lookup"><span data-stu-id="d474c-153">Each shader stage allows up to 15 shader-constant buffers; each buffer can hold up to 4096 constants.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="d474c-154"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="d474c-154"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="d474c-155">頂点バッファーとインデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="d474c-155">Vertex and index buffers</span></span>](vertex-and-index-buffers.md)

 

 




