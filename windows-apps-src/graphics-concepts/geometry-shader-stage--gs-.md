---
title: ジオメトリ シェーダー (GS) ステージ
description: ジオメトリ シェーダー (GS) ステージでは、プリミティブの全体の三角形、線、点が、隣接する頂点と共に処理されます。
ms.assetid: 8A1350DD-B006-488F-9DAF-14CD2483BA4E
keywords:
- ジオメトリ シェーダー (GS) ステージ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c4659ee4200915a7cc82f46c90f0e53965f322d5
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6024777"
---
# <a name="geometry-shader-gs-stage"></a><span data-ttu-id="4a8bc-104">ジオメトリ シェーダー (GS) ステージ</span><span class="sxs-lookup"><span data-stu-id="4a8bc-104">Geometry Shader (GS) stage</span></span>


<span data-ttu-id="4a8bc-105">ジオメトリ シェーダー (GS) ステージでは、プリミティブの全体の三角形、線、点が、隣接する頂点と共に処理されます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-105">The Geometry Shader (GS) stage processes entire primitives: triangles, lines, and points, along with their adjacent vertices.</span></span> <span data-ttu-id="4a8bc-106">これは、ポイント スプライト拡張、動的パーティクル システム、シャドウ ボリュームの生成などのアルゴリズムで便利です。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-106">It is useful for algorithms including Point Sprite Expansion, Dynamic Particle Systems, and Shadow Volume Generation.</span></span> <span data-ttu-id="4a8bc-107">これは、ジオメトリ増幅と減幅をサポートします。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-107">It supports geometry amplification and de-amplification.</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="4a8bc-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="4a8bc-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


<span data-ttu-id="4a8bc-109">ジオメトリ シェーダー ステージでは、プリミティブの全体、つまり三角形 (3 つの頂点と最大 3 つの隣接頂点)、線 (2 つの頂点と最大 2 つの隣接頂点)、点 (1 つの頂点) を処理します。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-109">The Geometry Shader stage processes entire primitives: triangles (3 vertices with up to 3 adjacent vertices), lines (2 vertices with up to 2 adjacent vertices), and points (1 vertex).</span></span>

![隣接頂点を持つ三角形と線の図](images/d3d10-gs.png)

<span data-ttu-id="4a8bc-111">ジオメトリ シェーダーは、限定的なジオメトリの増幅と減幅もサポートしています。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-111">The Geometry Shader also supports limited geometry amplification and de-amplification.</span></span> <span data-ttu-id="4a8bc-112">ジオメトリ シェーダーは、入力プリミティブに対して、プリミティブを破棄することも、1つまたは複数の新しいプリミティブを出力することもできます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-112">Given an input primitive, the Geometry Shader can discard the primitive, or emit one or more new primitives.</span></span>

<span data-ttu-id="4a8bc-113">ジオメトリ シェーダー (GS) ステージはプログラム可能なシェーダー ステージです。[グラフィックス パイプライン](graphics-pipeline.md)の図では角丸ブロックとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-113">The Geometry Shader (GS) stage is a programmable-shader stage; it is shown as a rounded block in the [graphics pipeline](graphics-pipeline.md) diagram.</span></span> <span data-ttu-id="4a8bc-114">このシェーダー ステージは、シェーダー モデル (「[共通シェーダー コア](https://msdn.microsoft.com/library/windows/desktop/bb509580)」を参照) に基づいて構築された、独自の機能を公開します。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-114">This shader stage exposes its own unique functionality, built on the shader models (see [common-shader core](https://msdn.microsoft.com/library/windows/desktop/bb509580)).</span></span>

<span data-ttu-id="4a8bc-115">ジオメトリ シェーダー ステージは、次のようなアルゴリズムに最適です。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-115">The Geometry Shader stage is well-suited for algorithms including:</span></span>

-   <span data-ttu-id="4a8bc-116">ポイント スプライト拡張</span><span class="sxs-lookup"><span data-stu-id="4a8bc-116">Point Sprite Expansion</span></span>
-   <span data-ttu-id="4a8bc-117">動的パーティクル システム</span><span class="sxs-lookup"><span data-stu-id="4a8bc-117">Dynamic Particle Systems</span></span>
-   <span data-ttu-id="4a8bc-118">Fur/Fin の生成</span><span class="sxs-lookup"><span data-stu-id="4a8bc-118">Fur/Fin Generation</span></span>
-   <span data-ttu-id="4a8bc-119">シャドウ ボリュームの生成</span><span class="sxs-lookup"><span data-stu-id="4a8bc-119">Shadow Volume Generation</span></span>
-   <span data-ttu-id="4a8bc-120">単一パスでのキューブマップへのレンダリング</span><span class="sxs-lookup"><span data-stu-id="4a8bc-120">Single Pass Render-to-Cubemap</span></span>
-   <span data-ttu-id="4a8bc-121">プリミティブ単位のマテリアル スワップ</span><span class="sxs-lookup"><span data-stu-id="4a8bc-121">Per-Primitive Material Swapping</span></span>
-   <span data-ttu-id="4a8bc-122">プリミティブ単位のマテリアル セットアップ: この機能にはプリミティブ データとしての重心座標の生成も含まれています。これにより、ピクセル シェーダーはカスタム属性補間を実行できます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-122">Per-Primitive Material Setup - This capability includes generation of barycentric coordinates as primitive data so that a pixel shader can perform custom attribute interpolation.</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="4a8bc-123"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="4a8bc-123"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="4a8bc-124">ジオメトリ シェーダー ステージでは、アプリケーション指定のシェーダー コードが、プリミティブ全体を入力として実行され、出力では頂点を生成することができます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-124">The Geometry Shader stage runs application-specified shader code with entire primitives as input and the ability to generate vertices on output.</span></span> <span data-ttu-id="4a8bc-125">1 つの頂点を処理する頂点シェーダーとは異なり、ジオメトリ シェーダーの入力はプリミティブ全体 (三角形の 3 つの頂点、線の 2 つの頂点、点の 1 つの頂点など) の頂点です。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-125">Unlike vertex shaders, which operate on a single vertex, the geometry shader's inputs are the vertices for a full primitive (three vertices for triangles, two vertices for lines, or single vertex for point).</span></span> <span data-ttu-id="4a8bc-126">また、ジオメトリ シェーダーでは、エッジ隣接プリミティブの頂点データを入力として受け取ることができます (三角形の場合は追加の 3 つの頂点、線の場合は追加の 2 つの頂点)。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-126">Geometry shaders can also bring in the vertex data for the edge-adjacent primitives as input (an additional three for a triangle, an additional two vertices for a line).</span></span>

<span data-ttu-id="4a8bc-127">ジオメトリ シェーダー ステージでは、[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)によって自動的に生成されたシステム生成値である **SV\_PrimitiveID** を使用できます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-127">The Geometry Shader stage can consume the **SV\_PrimitiveID** system-generated value that is auto-generated by the [Input Assembler (IA) stage](input-assembler-stage--ia-.md).</span></span> <span data-ttu-id="4a8bc-128">これにより、必要に応じて、プリミティブ単位のデータをフェッチまたは計算することができます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-128">This allows per-primitive data to be fetched or computed if desired.</span></span>

<span data-ttu-id="4a8bc-129">ジオメトリ シェーダーがアクティブである場合、前にパイプラインで渡された、または生成されたすべてのプリミティブについて 1 回呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-129">When a geometry shader is active, it is invoked once for every primitive passed down or generated earlier in the pipeline.</span></span> <span data-ttu-id="4a8bc-130">ジオメトリ シェーダーの呼び出しのたびに、入力となるプリミティブのデータが 1 つの点、1 つの線、または 1 つの三角形のいずれになるか確認されます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-130">Each invocation of the geometry shader sees as input the data for the invoking primitive, whether that is a single point, a single line, or a single triangle.</span></span> <span data-ttu-id="4a8bc-131">前にパイプラインで生成された三角形ストリップでは、ストリップ内の三角形ごとにジオメトリ シェーダーが呼び出されます (ストリップが三角形リストに展開されている場合と同様になります)。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-131">A triangle strip from earlier in the pipeline would result in an invocation of the geometry shader for each individual triangle in the strip (as if the strip were expanded out into a triangle list).</span></span> <span data-ttu-id="4a8bc-132">個々のプリミティブ内の各頂点のすべての入力データが利用可能なほか (三角形の場合は 3 つの頂点)、隣接頂点のデータも利用可能です (該当し、利用可能な場合)。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-132">All the input data for each vertex in the individual primitive is available (that is, 3 vertices for a triangle), plus adjacent vertex data if applicable and available.</span></span>

<span data-ttu-id="4a8bc-133">一般的な頂点の略語:</span><span class="sxs-lookup"><span data-stu-id="4a8bc-133">Common vertex abbreviations:</span></span>

|     |                 |
|-----|-----------------|
| <span data-ttu-id="4a8bc-134">TV</span><span class="sxs-lookup"><span data-stu-id="4a8bc-134">TV</span></span>  | <span data-ttu-id="4a8bc-135">三角形頂点</span><span class="sxs-lookup"><span data-stu-id="4a8bc-135">Triangle vertex</span></span> |
| <span data-ttu-id="4a8bc-136">LV</span><span class="sxs-lookup"><span data-stu-id="4a8bc-136">LV</span></span>  | <span data-ttu-id="4a8bc-137">線頂点</span><span class="sxs-lookup"><span data-stu-id="4a8bc-137">Line vertex</span></span>     |
| <span data-ttu-id="4a8bc-138">AV</span><span class="sxs-lookup"><span data-stu-id="4a8bc-138">AV</span></span>  | <span data-ttu-id="4a8bc-139">隣接頂点</span><span class="sxs-lookup"><span data-stu-id="4a8bc-139">Adjacent vertex</span></span> |

 

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="4a8bc-140"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="4a8bc-140"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="4a8bc-141">ジオメトリ シェーダー (GS) ステージでは、1 つの選択したトポロジを形成する複数の頂点を出力することができます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-141">The Geometry Shader (GS) stage is capable of outputting multiple vertices forming a single selected topology.</span></span> <span data-ttu-id="4a8bc-142">利用可能なジオメトリ シェーダーの出力トポロジには、**tristrip**、**linestrip**、および**pointlist** があります。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-142">Available geometry shader output topologies are **tristrip**, **linestrip**, and **pointlist**.</span></span> <span data-ttu-id="4a8bc-143">生成されるプリミティブの数は、ジオメトリ シェーダーの呼び出し内で自由に変えることができますが、生成可能な頂点の最大数は、静的に宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-143">The number of primitives emitted can vary freely within any invocation of the geometry shader, though the maximum number of vertices that could be emitted must be declared statically.</span></span> <span data-ttu-id="4a8bc-144">ジオメトリ シェーダーの呼び出しから生成されるストリップの長さは任意で、新しいストリップは [RestartStrip](https://msdn.microsoft.com/library/windows/desktop/bb509660) HLSL 組み込み関数を使用して作成できます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-144">Strip lengths emitted from a geometry shader invocation can be arbitrary, and new strips can be created via the [RestartStrip](https://msdn.microsoft.com/library/windows/desktop/bb509660) HLSL function.</span></span>

<span data-ttu-id="4a8bc-145">ジオメトリ シェーダー インスタンスの実行は、ストリームに追加されるデータがシリアルであることを除き、他の呼び出しからアトミックです。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-145">Execution of a geometry shader instance is atomic from other invocations, except that data added to the streams is serial.</span></span> <span data-ttu-id="4a8bc-146">ジオメトリ シェーダーの特定の呼び出しの出力は、他の呼び出しから独立しています (ただし、順序は考慮されます)。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-146">The outputs of a given invocation of a geometry shader are independent of other invocations (though ordering is respected).</span></span> <span data-ttu-id="4a8bc-147">三角形ストリップを生成するジオメトリ シェーダーは、すべての呼び出しで新しいストリップを開始します。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-147">A geometry shader generating triangle strips will start a new strip on every invocation.</span></span>

<span data-ttu-id="4a8bc-148">ジオメトリ シェーダーの出力は、ラスタライザー ステージに渡すか、ストリーム出力ステージでメモリー内の頂点バッファーに渡すか、またはこれら両方に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-148">Geometry shader output may be fed to the rasterizer stage and/or to a vertex buffer in memory via the stream output stage.</span></span> <span data-ttu-id="4a8bc-149">メモリーに渡された出力は、個別の点/線/三角形のリストに展開されます (ラスタライザーに渡されるときとまったく同じように展開されます)。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-149">Output fed to memory is expanded to individual point/line/triangle lists (exactly as they would be passed to the rasterizer).</span></span>

<span data-ttu-id="4a8bc-150">ジオメトリ シェーダーは、頂点を出力ストリーム オブジェクトに追加することで 1 つの頂点ごとにデータを出力します。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-150">A geometry shader outputs data one vertex at a time by appending vertices to an output stream object.</span></span> <span data-ttu-id="4a8bc-151">ストリームのトポロジは、固定された宣言によって決定され、GS ステージの出力として **TriangleStream**、**LineStream**、**PointStream** のいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-151">The topology of the streams is determined by a fixed declaration, choosing a **TriangleStream**, **LineStream** and **PointStream** as the output for the GS stage.</span></span>

<span data-ttu-id="4a8bc-152">利用可能なストリーム オブジェクトには **TriangleStream**、**LineStream**、**PointStream** の 3 種類があり、これらはすべてテンプレート化されたオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-152">There are three types of stream objects available: **TriangleStream**, **LineStream** and **PointStream**, which are all templated objects.</span></span> <span data-ttu-id="4a8bc-153">出力のトポロジはそれぞれのオブジェクトの種類によって決定され、ストリームに追加される頂点のフォーマットはテンプレートの種類によって決定されます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-153">The topology of the output is determined by their respective object type, while the format of the vertices appended to the stream is determined by the template type.</span></span>

<span data-ttu-id="4a8bc-154">ジオメトリ シェーダー出力が、システム解釈値 (たとえば、**SV\_RenderTargetArrayIndex** や **SV\_Position**) として識別されると、ハードウェアは、データ自体を次のシェーダー ステージに入力として渡すほか、このデータを参照し、その値に応じて特定の動作を実行します。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-154">When a geometry shader output is identified as a System Interpreted Value (for example, **SV\_RenderTargetArrayIndex** or **SV\_Position**), hardware looks at this data and performs some behavior dependent on the value, in addition to being able to pass the data itself to the next shader stage for input.</span></span> <span data-ttu-id="4a8bc-155">ジオメトリ シェーダーから出力されたこのようなデータが、頂点単位ではなく (**SV\_ClipDistance\[n\]** や **SV\_Position** など)、プリミティブ単位で (**SV\_RenderTargetArrayIndex** や **SV\_ViewportArrayIndex** など) ハードウェアに対して有意な場合、プリミティブに対して生成された最初の頂点からプリミティブ単位のデータが取得されます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-155">When such data output from the geometry shader has meaning to the hardware on a per-primitive basis (such as **SV\_RenderTargetArrayIndex** or **SV\_ViewportArrayIndex**), rather than on a per-vertex basis (such as **SV\_ClipDistance\[n\]** or **SV\_Position**), the per-primitive data is taken from the leading vertex emitted for the primitive.</span></span>

<span data-ttu-id="4a8bc-156">ジオメトリ シェーダーが終了し、プリミティブが不完全な場合、部分的に終了したプリミティブをジオメトリ シェーダーによって生成することができます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-156">Partially completed primitives could be generated by the geometry shader if the geometry shader ends and the primitive is incomplete.</span></span> <span data-ttu-id="4a8bc-157">不完全なプリミティブは自動的に破棄されます。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-157">Incomplete primitives are silently discarded.</span></span> <span data-ttu-id="4a8bc-158">これは、部分的に終了したプリミティブを IA が処理する方法に似ています。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-158">This is similar to the way the IA treats partially completed primitives.</span></span>

<span data-ttu-id="4a8bc-159">ジオメトリ シェーダーは、スクリーン空間の微分を必要としないロードおよびテクスチャー サンプリング処理を実行できます (**samplelevel**、**samplecmplevelzero**、**samplegrad**)。</span><span class="sxs-lookup"><span data-stu-id="4a8bc-159">The geometry shader can perform load and texture sampling operations where screen-space derivatives are not required (**samplelevel**, **samplecmplevelzero**, **samplegrad**).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="4a8bc-160"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="4a8bc-160"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="4a8bc-161">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="4a8bc-161">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




