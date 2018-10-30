---
title: 入力アセンブラー (IA) ステージ
description: 入力アセンブラー (IA) ステージは、三角形、線、点などのパイプラインにプリミティブ データと隣接性データを提供し (セマンティクス ID など)、まだ処理されていないプリミティブの処理を減らすことでシェーダーの効率を高めます。
ms.assetid: AF1DC611-C872-47F1-BF1A-92C68C8903E6
keywords:
- 入力アセンブラー (IA) ステージ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: def755f868c7ea30679f19877cec84b20faa44f5
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5765868"
---
# <a name="input-assembler-ia-stage"></a><span data-ttu-id="9a65f-104">入力アセンブラー (IA) ステージ</span><span class="sxs-lookup"><span data-stu-id="9a65f-104">Input Assembler (IA) stage</span></span>


<span data-ttu-id="9a65f-105">入力アセンブラー (IA) ステージは、三角形、線、点などのパイプラインにプリミティブ データと隣接性データを提供し (セマンティクス ID など)、まだ処理されていないプリミティブの処理を減らすことでシェーダーの効率を高めます。</span><span class="sxs-lookup"><span data-stu-id="9a65f-105">The Input Assembler (IA) stage supplies primitive and adjacency data to the pipeline, such as triangles, lines and points, including semantics IDs to help make shaders more efficient by reducing processing to primitives that haven't already been processed.</span></span>

## <a name="span-idpurpose-and-usesspanspan-idpurpose-and-usesspanspan-idpurpose-and-usesspanpurpose-and-uses"></a><span data-ttu-id="9a65f-106"><span id="Purpose-and-uses"></span><span id="purpose-and-uses"></span><span id="PURPOSE-AND-USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="9a65f-106"><span id="Purpose-and-uses"></span><span id="purpose-and-uses"></span><span id="PURPOSE-AND-USES"></span>Purpose and uses</span></span>


<span data-ttu-id="9a65f-107">入力アセンブラー (IA) ステージの目的は、ユーザーが入力したバッファーからプリミティブ データ (点、線、三角形) を読み取って、他のパイプライン ステージにより使われるプリミティブにデータをアセンブルし、[システムにより生成された値](https://msdn.microsoft.com/library/windows/desktop/bb509647)をアタッチしてシェーダーの効率を高めることです。</span><span class="sxs-lookup"><span data-stu-id="9a65f-107">The purpose of the Input Assembler (IA) stage is to read primitive data (points, lines and triangles) from user-filled buffers and assemble the data into primitives that will be used by the other pipeline stages, and to attach [system-generated values](https://msdn.microsoft.com/library/windows/desktop/bb509647) to help make shaders more efficient.</span></span> <span data-ttu-id="9a65f-108">システムにより生成された値は、セマンティクスとも呼ばれるテキスト文字列です。</span><span class="sxs-lookup"><span data-stu-id="9a65f-108">System-generated values are text strings that are also called semantics.</span></span> <span data-ttu-id="9a65f-109">プログラミング可能なシェーダー ステージは、システムにより生成された値 (プリミティブ ID、インスタンス ID、頂点 ID など) を使うコマンド シェーダー コアから作成されます。これにより、シェーダー ステージは、まだ処理されていないそれらのプリミティブ、インスタンス、または頂点のみに処理を減らすことができます。</span><span class="sxs-lookup"><span data-stu-id="9a65f-109">The programmable shader stages are constructed from a common shader core, which uses system-generated values (such as a primitive ID, an instance ID, or a vertex ID), so that the shader stage can reduce processing to only those primitives, instances, or vertices that have not already been processed.</span></span>

<span data-ttu-id="9a65f-110">IA ステージは、複数の異なる[プリミティブ型](primitive-topologies.md) (線の一覧、三角形のストリップ、隣接性を持つプリミティブなど) に頂点をアセンブルします。</span><span class="sxs-lookup"><span data-stu-id="9a65f-110">The IA stage can assemble vertices into several different [primitive types](primitive-topologies.md) (such as line lists, triangle strips, or primitives with adjacency).</span></span> <span data-ttu-id="9a65f-111">隣接性を持つ三角形の一覧などのプリミティブ型と、隣接性を持つ線の一覧は、[ジオメトリ シェーダー (GS) ステージ](geometry-shader-stage--gs-.md)をサポートします。</span><span class="sxs-lookup"><span data-stu-id="9a65f-111">Primitive types such as a triangle list with adjacency, and a line list with adjacency, support the [Geometry Shader (GS) stage](geometry-shader-stage--gs-.md).</span></span>

<span data-ttu-id="9a65f-112">隣接性情報は、ジオメトリ シェーダーでのみアプリケーションから見えます。</span><span class="sxs-lookup"><span data-stu-id="9a65f-112">Adjacency information is visible to an application only in a geometry shader.</span></span> <span data-ttu-id="9a65f-113">たとえば、ジオメトリ シェーダーが隣接性を含む三角形に関与していた場合、入力データには三角形ごとに 3 つの頂点と、各三角形の隣接性データに 3 つの頂点が含まれます。</span><span class="sxs-lookup"><span data-stu-id="9a65f-113">If a geometry shader were invoked with a triangle including adjacency, for instance, the input data would contain 3 vertices for each triangle and 3 vertices for adjacency data per triangle.</span></span>

<span data-ttu-id="9a65f-114">IA ステージが隣接性データを出力するよう要求された場合、入力データには隣接性データが含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="9a65f-114">When the IA stage is requested to output adjacency data, the input data must include adjacency data.</span></span> <span data-ttu-id="9a65f-115">これには、ダミーの頂点を提供する必要が生じることあります (縮退三角形を形成)。場合によっては、頂点が存在するかどうかに関係なく、頂点属性の 1 つフラグを付けることによってもできます。</span><span class="sxs-lookup"><span data-stu-id="9a65f-115">This may require providing a dummy vertex (forming a degenerate triangle), or perhaps by flagging in one of the vertex attributes whether the vertex exists or not.</span></span> <span data-ttu-id="9a65f-116">さらに、このことはジオメトリ シェーダーにより検出されて処理される必要もあります。ただし、縮退ジオメトリのカリングはラスタライザー ステージで行われます。</span><span class="sxs-lookup"><span data-stu-id="9a65f-116">This would also need to be detected and handled by a geometry shader, although culling of degenerate geometry will happen in the rasterizer stage.</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="9a65f-117"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="9a65f-117"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="9a65f-118">IA ステージは、メモリ、プリミティブ データ (点、線、三角形)、ユーザーが入力したバッファーからデータを読み取ります。</span><span class="sxs-lookup"><span data-stu-id="9a65f-118">The IA stage reads data from memory: primitive data (points, lines and/or triangles), from user-filled buffers.</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="9a65f-119"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="9a65f-119"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="9a65f-120">IA ステージは、データをプリミティブにアセンブルして、システムにより生成された値をアタッチし、[頂点シェーダー (VS) ステージ](vertex-shader-stage--vs-.md)、他のパイプライン ステージの順で使われるプリミティブとして値を出力します。</span><span class="sxs-lookup"><span data-stu-id="9a65f-120">The IA stage assembles the data into primitives and attaches system-generated values, and outputs that as primitives that will be used by the [Vertex Shader (VS) stage](vertex-shader-stage--vs-.md) and then other pipeline stages.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="9a65f-121"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="9a65f-121"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="9a65f-122">トピック</span><span class="sxs-lookup"><span data-stu-id="9a65f-122">Topic</span></span></th>
<th align="left"><span data-ttu-id="9a65f-123">説明</span><span class="sxs-lookup"><span data-stu-id="9a65f-123">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="primitive-topologies.md"><span data-ttu-id="9a65f-124">プリミティブ トポロジ</span><span class="sxs-lookup"><span data-stu-id="9a65f-124">Primitive topologies</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="9a65f-125">Direct3D では、ポイントの一覧、線の一覧、三角形ストリップなどのいくつかのプリミティブ トポロジがサポートされており、パイプラインにより頂点がどのように解釈され、レンダリングされるかを定義します。</span><span class="sxs-lookup"><span data-stu-id="9a65f-125">Direct3D supports several primitive topologies, which define how vertices are interpreted and rendered by the pipeline, such as point lists, line lists, and triangle strips.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="using-system-generated-values.md"><span data-ttu-id="9a65f-126">システムで生成される値の使用</span><span class="sxs-lookup"><span data-stu-id="9a65f-126">Using system-generated values</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="9a65f-127">システムにより生成された値は、入力アセンブラー (IA) ステージにより生成され (ユーザーが提供した入力<a href="https://msdn.microsoft.com/library/windows/desktop/bb509647">セマンティクス</a>に基づく)、シェーダー操作で一定の効率を実現します。</span><span class="sxs-lookup"><span data-stu-id="9a65f-127">System-generated values are generated by the Input Assembler (IA) stage (based on user-supplied input <a href="https://msdn.microsoft.com/library/windows/desktop/bb509647">semantics</a>) to allow certain efficiencies in shader operations.</span></span> <span data-ttu-id="9a65f-128">インスタンス ID (<a href="vertex-shader-stage--vs-.md">頂点シェーダー (VS) ステージ</a>で参照可能)、頂点 ID (VS で参照可能)、またはプリミティブ ID (<a href="geometry-shader-stage--gs-.md">ジオメトリ シェーダー (GS) ステージ</a>/<a href="pixel-shader-stage--ps-.md">ピクセル シェーダー (PS) ステージ</a>で参照可能) などのデータをアタッチするとにより、その後のシェーダー ストレージがそれらのシステム値を探して、そのステージでの処理を最適化できるようになります。</span><span class="sxs-lookup"><span data-stu-id="9a65f-128">By attaching data, such as an instance ID (visible to the <a href="vertex-shader-stage--vs-.md">Vertex Shader (VS) stage</a>), a vertex ID (visible to VS), or a primitive ID (visible to <a href="geometry-shader-stage--gs-.md">Geometry Shader (GS) stage</a>/<a href="pixel-shader-stage--ps-.md">Pixel Shader (PS) stage</a>), a subsequent shader stage may look for these system values to optimize processing in that stage.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="9a65f-129"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="9a65f-129"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="9a65f-130">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="9a65f-130">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




