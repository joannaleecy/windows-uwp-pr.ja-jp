---
title: プリミティブ トポロジ
description: Direct3D では、ポイントの一覧、線の一覧、三角形ストリップなどのいくつかのプリミティブ トポロジがサポートされており、パイプラインにより頂点がどのように解釈され、レンダリングされるかを定義します。
ms.assetid: 7AA5A4A2-0B7C-431D-B597-684D58C02BA5
keywords:
- プリミティブ トポロジ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 85d1c41fc10f509f3872fb1e4a0af5fa1e1e7c30
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7967669"
---
# <a name="primitive-topologies"></a><span data-ttu-id="6f900-104">プリミティブ トポロジ</span><span class="sxs-lookup"><span data-stu-id="6f900-104">Primitive topologies</span></span>


<span data-ttu-id="6f900-105">Direct3D では、ポイントの一覧、線の一覧、三角形ストリップなどのいくつかのプリミティブ トポロジがサポートされており、パイプラインにより頂点がどのように解釈され、レンダリングされるかを定義します。</span><span class="sxs-lookup"><span data-stu-id="6f900-105">Direct3D supports several primitive topologies, which define how vertices are interpreted and rendered by the pipeline, such as point lists, line lists, and triangle strips.</span></span>

## <a name="span-idprimitivetypesspanspan-idprimitivetypesspanspan-idprimitivetypesspanbasic-primitive-topologies"></a><span data-ttu-id="6f900-106"><span id="Primitive_Types"></span><span id="primitive_types"></span><span id="PRIMITIVE_TYPES"></span>基本的なプリミティブ トポロジ</span><span class="sxs-lookup"><span data-stu-id="6f900-106"><span id="Primitive_Types"></span><span id="primitive_types"></span><span id="PRIMITIVE_TYPES"></span>Basic primitive topologies</span></span>


<span data-ttu-id="6f900-107">サポートされている基本的なプリミティブ トポロジ (または、プリミティブ タイプ) を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="6f900-107">The following basic primitive topologies (or primitive types) are supported:</span></span>

-   [<span data-ttu-id="6f900-108">ポイント リスト</span><span class="sxs-lookup"><span data-stu-id="6f900-108">Point lists</span></span>](point-lists.md)
-   [<span data-ttu-id="6f900-109">線リスト</span><span class="sxs-lookup"><span data-stu-id="6f900-109">Line lists</span></span>](line-lists.md)
-   [<span data-ttu-id="6f900-110">ライン ストリップ</span><span class="sxs-lookup"><span data-stu-id="6f900-110">Line strips</span></span>](line-strips.md)
-   [<span data-ttu-id="6f900-111">トライアングル リスト</span><span class="sxs-lookup"><span data-stu-id="6f900-111">Triangle lists</span></span>](triangle-lists.md)
-   [<span data-ttu-id="6f900-112">トライアングル ストリップ</span><span class="sxs-lookup"><span data-stu-id="6f900-112">Triangle strips</span></span>](triangle-strips.md)

<span data-ttu-id="6f900-113">各プリミティブ タイプを視覚化したものを、この後の "[ワインディング方向と先頭頂点の位置](#winding-direction-and-leading-vertex-positions)" の図で示しています。</span><span class="sxs-lookup"><span data-stu-id="6f900-113">For a visualization of each primitive type, see the diagram later in this topic in [Winding direction and leading vertex positions](#winding-direction-and-leading-vertex-positions).</span></span>

<span data-ttu-id="6f900-114">[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)では、頂点バッファーおよびインデックス バッファーからデータを読み取り、このデータをこれらのプリミティブにアセンブルし、残りのパイプライン ステージにデータを送信します。</span><span class="sxs-lookup"><span data-stu-id="6f900-114">The [Input Assembler (IA) stage](input-assembler-stage--ia-.md) reads data from vertex and index buffers, assembles the data into these primitives, and then sends the data to the remaining pipeline stages.</span></span>

## <a name="span-idprimitiveadjacencyspanspan-idprimitiveadjacencyspanspan-idprimitiveadjacencyspanprimitive-adjacency"></a><span data-ttu-id="6f900-115"><span id="Primitive_Adjacency"></span><span id="primitive_adjacency"></span><span id="PRIMITIVE_ADJACENCY"></span>プリミティブの隣接性</span><span class="sxs-lookup"><span data-stu-id="6f900-115"><span id="Primitive_Adjacency"></span><span id="primitive_adjacency"></span><span id="PRIMITIVE_ADJACENCY"></span>Primitive adjacency</span></span>


<span data-ttu-id="6f900-116">ポイント リストを除く Direct3D のすべてのプリミティブ タイプは、隣接性を持つプリミティブ タイプと、隣接性を持たないプリミティブ タイプの 2 種類に分けられます。</span><span class="sxs-lookup"><span data-stu-id="6f900-116">All Direct3D primitive types (except the point list) are available in two versions: one primitive type with adjacency and one primitive type without adjacency.</span></span> <span data-ttu-id="6f900-117">隣接性を持つプリミティブには、それを取り囲む頂点がいくつか含まれますが、隣接性を持たないプリミティブに含まれるのは、ターゲット プリミティブの頂点のみです。</span><span class="sxs-lookup"><span data-stu-id="6f900-117">Primitives with adjacency contain some of the surrounding vertices, while primitives without adjacency contain only the vertices of the target primitive.</span></span> <span data-ttu-id="6f900-118">たとえば、線リスト プリミティブには、対応する、隣接性を含む線リスト プリミティブが存在します。</span><span class="sxs-lookup"><span data-stu-id="6f900-118">For example, the line list primitive has a corresponding line list primitive that includes adjacency.</span></span>

<span data-ttu-id="6f900-119">隣接プリミティブは、ジオメトリに関する追加情報の提供を目的としており、ジオメトリ シェーダーによってのみ認識されます。</span><span class="sxs-lookup"><span data-stu-id="6f900-119">Adjacent primitives are intended to provide more information about your geometry and are only visible through a geometry shader.</span></span> <span data-ttu-id="6f900-120">隣接性は、シルエット検出やシャドウ ボリュームの押し出しなどを使用するジオメトリ シェーダーで役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="6f900-120">Adjacency is useful for geometry shaders that use silhouette detection, shadow volume extrusion, and so on.</span></span>

<span data-ttu-id="6f900-121">たとえば、隣接性のあるトライアングル リストを描画するとします。</span><span class="sxs-lookup"><span data-stu-id="6f900-121">For example, suppose you want to draw a triangle list with adjacency.</span></span> <span data-ttu-id="6f900-122">36 個の頂点を持つ隣接性のあるトライアングル リストからは 6 個の完全なプリミティブが作成されます。</span><span class="sxs-lookup"><span data-stu-id="6f900-122">A triangle list that contains 36 vertices (with adjacency) will yield 6 completed primitives.</span></span> <span data-ttu-id="6f900-123">ライン ストリップを除き、隣接性のあるプリミティブは、隣接性を持たない同じプリミティブのちょうど 2 倍の頂点を含んでいます。ここで、追加の頂点はそれぞれ隣接頂点です。</span><span class="sxs-lookup"><span data-stu-id="6f900-123">Primitives with adjacency (except line strips) contain exactly twice as many vertices as the equivalent primitive without adjacency, where each additional vertex is an adjacent vertex.</span></span>

## <a name="span-idwindingdirectionandleadingvertexpositionsspanspan-idwindingdirectionandleadingvertexpositionsspanspan-idwindingdirectionandleadingvertexpositionsspanspan-idwinding-direction-and-leading-vertex-positionsspanwinding-direction-and-leading-vertex-positions"></a><span data-ttu-id="6f900-124"><span id="Winding_Direction_and_Leading_Vertex_Positions"></span><span id="winding_direction_and_leading_vertex_positions"></span><span id="WINDING_DIRECTION_AND_LEADING_VERTEX_POSITIONS"></span><span id="winding-direction-and-leading-vertex-positions"></span>ワインディング方向と先頭頂点の位置</span><span class="sxs-lookup"><span data-stu-id="6f900-124"><span id="Winding_Direction_and_Leading_Vertex_Positions"></span><span id="winding_direction_and_leading_vertex_positions"></span><span id="WINDING_DIRECTION_AND_LEADING_VERTEX_POSITIONS"></span><span id="winding-direction-and-leading-vertex-positions"></span>Winding direction and leading vertex positions</span></span>


<span data-ttu-id="6f900-125">下の図にあるように、先頭頂点は、プリミティブ内の最初の非隣接頂点です。</span><span class="sxs-lookup"><span data-stu-id="6f900-125">As shown in the following illustration, a leading vertex is the first non-adjacent vertex in a primitive.</span></span> <span data-ttu-id="6f900-126">先頭頂点がそれぞれ異なるプリミティブで使用されている限り、1 つのプリミティブ タイプで複数の先頭頂点を定義することができます。</span><span class="sxs-lookup"><span data-stu-id="6f900-126">A primitive type can have multiple leading vertices defined, as long as each one is used for a different primitive.</span></span>

-   <span data-ttu-id="6f900-127">隣接性を持つトライアングル ストリップでは、先頭頂点は 0、2、4、6 ... となります。</span><span class="sxs-lookup"><span data-stu-id="6f900-127">For a triangle strip with adjacency, the leading vertices are 0, 2, 4, 6, and so on.</span></span>
-   <span data-ttu-id="6f900-128">隣接性を持つライン ストリップでは、先頭頂点は 1、2、3 ... となります。</span><span class="sxs-lookup"><span data-stu-id="6f900-128">For a line strip with adjacency, the leading vertices are 1, 2, 3, and so on.</span></span>
-   <span data-ttu-id="6f900-129">一方、隣接プリミティブには先頭頂点はありません。</span><span class="sxs-lookup"><span data-stu-id="6f900-129">An adjacent primitive, on the other hand, has no leading vertex.</span></span>

<span data-ttu-id="6f900-130">次の図は、入力アセンブラーで生成可能なすべてのプリミティブ タイプの頂点の順序を表しています。</span><span class="sxs-lookup"><span data-stu-id="6f900-130">The following illustration shows the vertex ordering for all of the primitive types that the input assembler can produce.</span></span>

![プリミティブ タイプの頂点順序の図](images/d3d10-primitive-topologies.png)

<span data-ttu-id="6f900-132">この図の記号の意味を、次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="6f900-132">The symbols in the preceding illustration are described in the following table.</span></span>

| <span data-ttu-id="6f900-133">記号</span><span class="sxs-lookup"><span data-stu-id="6f900-133">Symbol</span></span>                                                                                   | <span data-ttu-id="6f900-134">名前</span><span class="sxs-lookup"><span data-stu-id="6f900-134">Name</span></span>              | <span data-ttu-id="6f900-135">説明</span><span class="sxs-lookup"><span data-stu-id="6f900-135">Description</span></span>                                                                         |
|------------------------------------------------------------------------------------------|-------------------|-------------------------------------------------------------------------------------|
| ![頂点を表す記号](images/d3d10-primitive-topologies-vertex.png)                     | <span data-ttu-id="6f900-137">頂点</span><span class="sxs-lookup"><span data-stu-id="6f900-137">Vertex</span></span>            | <span data-ttu-id="6f900-138">3D 空間内の点です。</span><span class="sxs-lookup"><span data-stu-id="6f900-138">A point in 3D space.</span></span>                                                                |
| ![ワインディング方向を表す記号](images/d3d10-primitive-topologies-winding-direction.png) | <span data-ttu-id="6f900-140">ワインディング方向</span><span class="sxs-lookup"><span data-stu-id="6f900-140">Winding Direction</span></span> | <span data-ttu-id="6f900-141">プリミティブをアセンブルするときの頂点の順序です。</span><span class="sxs-lookup"><span data-stu-id="6f900-141">The vertex order when assembling a primitive.</span></span> <span data-ttu-id="6f900-142">時計回り、または反時計回りです。</span><span class="sxs-lookup"><span data-stu-id="6f900-142">Can be clockwise or counterclockwise.</span></span> |
| ![先頭頂点を表す記号](images/d3d10-primitive-topologies-leading-vertex.png)       | <span data-ttu-id="6f900-144">先頭頂点</span><span class="sxs-lookup"><span data-stu-id="6f900-144">Leading Vertex</span></span>    | <span data-ttu-id="6f900-145">プリミティブ内で、定数ごとのデータを含む最初の非隣接頂点です。</span><span class="sxs-lookup"><span data-stu-id="6f900-145">The first non-adjacent vertex in a primitive that contains per-constant data.</span></span>       |

 

## <a name="span-idgeneratingmultiplestripsspanspan-idgeneratingmultiplestripsspanspan-idgeneratingmultiplestripsspangenerating-multiple-strips"></a><span data-ttu-id="6f900-146"><span id="Generating_Multiple_Strips"></span><span id="generating_multiple_strips"></span><span id="GENERATING_MULTIPLE_STRIPS"></span>複数のストリップの生成</span><span class="sxs-lookup"><span data-stu-id="6f900-146"><span id="Generating_Multiple_Strips"></span><span id="generating_multiple_strips"></span><span id="GENERATING_MULTIPLE_STRIPS"></span>Generating multiple strips</span></span>


<span data-ttu-id="6f900-147">ストリップ カットによって、複数のストリップを生成することができます。</span><span class="sxs-lookup"><span data-stu-id="6f900-147">You can generate multiple strips through strip cutting.</span></span> <span data-ttu-id="6f900-148">ストリップ カットを実行するには、[RestartStrip](https://msdn.microsoft.com/library/windows/desktop/bb509660) HLSL 関数を明示的に呼び出すか、インデックス バッファーに特殊なインデックス値を挿入します。</span><span class="sxs-lookup"><span data-stu-id="6f900-148">You can perform a strip cut by explicitly calling the [RestartStrip](https://msdn.microsoft.com/library/windows/desktop/bb509660) HLSL function, or by inserting a special index value into the index buffer.</span></span> <span data-ttu-id="6f900-149">この値とは –1 で、32 ビットのインデックスは 0xffffffff、16 ビットのインデックスは 0xffff です。</span><span class="sxs-lookup"><span data-stu-id="6f900-149">This value is –1, which is 0xffffffff for 32-bit indices or 0xffff for 16-bit indices.</span></span>

<span data-ttu-id="6f900-150">-1 のインデックスは、現在のストリップの明示的な ”カット” または ”再開” を示します。</span><span class="sxs-lookup"><span data-stu-id="6f900-150">An index of –1 indicates an explicit 'cut' or 'restart' of the current strip.</span></span> <span data-ttu-id="6f900-151">前のインデックスは前のプリミティブかストリップを完了し、次のインデックスは新しいプリミティブかストリップを開始します。</span><span class="sxs-lookup"><span data-stu-id="6f900-151">The previous index completes the previous primitive or strip and the next index starts a new primitive or strip.</span></span>

<span data-ttu-id="6f900-152">複数のストリップの生成について、詳細は「[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6f900-152">For more info about generating multiple strips, see [Geometry Shader (GS) stage](geometry-shader-stage--gs-.md).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="6f900-153"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="6f900-153"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="6f900-154">入力アセンブラー (IA) ステージ</span><span class="sxs-lookup"><span data-stu-id="6f900-154">Input-Assembler (IA) stage</span></span>](input-assembler-stage--ia-.md)

[<span data-ttu-id="6f900-155">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="6f900-155">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




