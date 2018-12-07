---
title: 頂点シェーダー (VS) ステージ
description: 頂点シェーダー (VS) ステージでは、頂点を処理し、多くの場合は変換、スキン、照明の適用などの操作を実行します。 頂点シェーダーは 1 つの入力頂点を受け取り、1 つの出力頂点を生成します。
ms.assetid: 5133C4BB-B4E6-4697-9276-F718AD44869C
keywords:
- 頂点シェーダー (VS) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ca3b5e230270b46b7cb2709d4bfa06c4c51d0224
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8800347"
---
# <a name="vertex-shader-vs-stage"></a><span data-ttu-id="554ac-105">頂点シェーダー (VS) ステージ</span><span class="sxs-lookup"><span data-stu-id="554ac-105">Vertex Shader (VS) stage</span></span>


<span data-ttu-id="554ac-106">頂点シェーダー (VS) ステージでは、頂点を処理し、多くの場合は変換、スキン、照明の適用などの操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="554ac-106">The Vertex Shader (VS) stage processes vertices, typically performing operations such as transformations, skinning, and lighting.</span></span> <span data-ttu-id="554ac-107">頂点シェーダーは 1 つの入力頂点を受け取り、1 つの出力頂点を生成します。</span><span class="sxs-lookup"><span data-stu-id="554ac-107">A vertex shader takes a single input vertex and produces a single output vertex.</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="554ac-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="554ac-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


<span data-ttu-id="554ac-109">頂点シェーダー (VS) ステージは、頂点ごとに次のような個別の処理を実行するために使われます。</span><span class="sxs-lookup"><span data-stu-id="554ac-109">The Vertex Shader (VS) stage is used for individual per-vertex processing such as:</span></span>

-   <span data-ttu-id="554ac-110">変換</span><span class="sxs-lookup"><span data-stu-id="554ac-110">Transformations</span></span>
-   <span data-ttu-id="554ac-111">スキン適用</span><span class="sxs-lookup"><span data-stu-id="554ac-111">Skinning</span></span>
-   <span data-ttu-id="554ac-112">モーフィング</span><span class="sxs-lookup"><span data-stu-id="554ac-112">Morphing</span></span>
-   <span data-ttu-id="554ac-113">頂点ごとの照明の適用</span><span class="sxs-lookup"><span data-stu-id="554ac-113">Per-vertex lighting</span></span>

<span data-ttu-id="554ac-114">頂点シェーダー ステージはプログラム可能なシェーダー ステージであり、[グラフィックス パイプライン](graphics-pipeline.md)の図では角丸ブロックとして示されています。</span><span class="sxs-lookup"><span data-stu-id="554ac-114">The Vertex Shader stage is a programmable-shader stage; it is shown as a rounded block in the [graphics pipeline](graphics-pipeline.md) diagram.</span></span> <span data-ttu-id="554ac-115">このシェーダー ステージではシェーダー モデル 4.0 の[共通シェーダー コア](https://msdn.microsoft.com/library/windows/desktop/bb509580)が使われます。</span><span class="sxs-lookup"><span data-stu-id="554ac-115">This shader stage uses shader model 4.0 [common-shader core](https://msdn.microsoft.com/library/windows/desktop/bb509580).</span></span>

<span data-ttu-id="554ac-116">頂点シェーダー (VS) ステージは、入力アセンブラーから頂点を受け取って処理します。</span><span class="sxs-lookup"><span data-stu-id="554ac-116">The vertex-shader (VS) stage processes vertices from the input assembler.</span></span> <span data-ttu-id="554ac-117">頂点シェーダーは常に、1 つの入力頂点を処理して 1 つの出力頂点を生成します。</span><span class="sxs-lookup"><span data-stu-id="554ac-117">Vertex shaders always operate on a single input vertex and produce a single output vertex.</span></span> <span data-ttu-id="554ac-118">パイプラインを実行するには、頂点シェーダー ステージが常にアクティブになっている必要があります。</span><span class="sxs-lookup"><span data-stu-id="554ac-118">The vertex shader stage must always be active for the pipeline to execute.</span></span> <span data-ttu-id="554ac-119">頂点の変更や変換が必要ない場合は、パススルー頂点シェーダーを作成してパイプラインに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="554ac-119">If no vertex modification or transformation is required, a pass-through vertex shader must be created and set to the pipeline.</span></span>

<span data-ttu-id="554ac-120">頂点シェーダーの各入力頂点は、最大 16 個の 32 ビット ベクトル (それぞれ最大 4 要素) で構成できます。</span><span class="sxs-lookup"><span data-stu-id="554ac-120">Each vertex shader input vertex can be comprised of up to 16 32-bit vectors (up to 4 components each).</span></span> <span data-ttu-id="554ac-121">各出力頂点も、最大 16 個の 32 ビット 4 要素ベクトルで構成できます。</span><span class="sxs-lookup"><span data-stu-id="554ac-121">Each output vertex can be comprised of as many as 16 32-bit 4-component vectors.</span></span> <span data-ttu-id="554ac-122">すべての頂点シェーダーには、少なくとも 1 つの入力と 1 つの出力が必要です。それぞれは 1 つのスカラー値でもかまいません。</span><span class="sxs-lookup"><span data-stu-id="554ac-122">All vertex shaders must have a minimum of one input and one output, which can be as little as one scalar value.</span></span>

<span data-ttu-id="554ac-123">頂点シェーダー ステージでは、入力アセンブラーから、VertexID と InstanceID の 2 つのシステム生成値を使うことができます (システム値とセマンティクスに関する説明をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="554ac-123">The vertex-shader stage can consume two system-generated values from the input assembler: VertexID and InstanceID (see System Values and Semantics).</span></span> <span data-ttu-id="554ac-124">VertexID と InstanceID はどちらも頂点レベルで有意であり、ハードウェアによって生成された ID を渡すことができるのは、それらを認識する最初のステージだけです。このため、これらの ID は頂点シェーダー ステージにしか渡すことができません。</span><span class="sxs-lookup"><span data-stu-id="554ac-124">Since VertexID and InstanceID are both meaningful at a vertex level, and IDs generated by hardware can only be fed into the first stage that understands them, these ID values can only be fed into the vertex-shader stage.</span></span>

<span data-ttu-id="554ac-125">頂点シェーダーは常にすべての頂点に対して実行され、これには隣接性を持つ入力プリミティブ トポロジ内の隣接頂点も含まれます。</span><span class="sxs-lookup"><span data-stu-id="554ac-125">Vertex shaders are always run on all vertices, including adjacent vertices in input primitive topologies with adjacency.</span></span> <span data-ttu-id="554ac-126">頂点シェーダーが実行された回数は、CPU から VSInvocations パイプライン統計を使って照会できます。</span><span class="sxs-lookup"><span data-stu-id="554ac-126">The number of times that the vertex shader has been executed can be queried from the CPU using the VSInvocations pipeline statistic.</span></span>

<span data-ttu-id="554ac-127">頂点シェーダーでは、スクリーン空間の微分を必要としない読み込み操作とテクスチャのサンプリング操作を実行できます (HLSL 組み込み関数の [Sample (DirectX HLSL テクスチャ オブジェクト)](https://msdn.microsoft.com/library/windows/desktop/bb509695)、[SampleCmpLevelZero (DirectX HLSL テクスチャ オブジェクト)](https://msdn.microsoft.com/library/windows/desktop/bb509697)、[SampleGrad (DirectX HLSL テクスチャ オブジェクト)](https://msdn.microsoft.com/library/windows/desktop/bb509698) が使われます)。</span><span class="sxs-lookup"><span data-stu-id="554ac-127">A vertex shader can perform load and texture sampling operations where screen-space derivatives are not required (using HLSL intrinsic functions: [Sample (DirectX HLSL Texture Object)](https://msdn.microsoft.com/library/windows/desktop/bb509695), [SampleCmpLevelZero (DirectX HLSL Texture Object)](https://msdn.microsoft.com/library/windows/desktop/bb509697), and [SampleGrad (DirectX HLSL Texture Object)](https://msdn.microsoft.com/library/windows/desktop/bb509698)).</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="554ac-128"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="554ac-128"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="554ac-129">システム生成値 VertexID と InstanceID を持つ単一の頂点。</span><span class="sxs-lookup"><span data-stu-id="554ac-129">A single vertex, with VertexID and InstanceID system-generated values.</span></span> <span data-ttu-id="554ac-130">頂点シェーダーの各入力頂点は、最大 16 個の 32 ビット ベクトル (それぞれ最大 4 要素) で構成できます。</span><span class="sxs-lookup"><span data-stu-id="554ac-130">Each vertex shader input vertex can be comprised of up to 16 32-bit vectors (up to 4 components each).</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="554ac-131"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="554ac-131"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="554ac-132">単一の頂点。</span><span class="sxs-lookup"><span data-stu-id="554ac-132">A single vertex.</span></span> <span data-ttu-id="554ac-133">各出力頂点も、最大 16 個の 32 ビット 4 要素ベクトルで構成できます。</span><span class="sxs-lookup"><span data-stu-id="554ac-133">Each output vertex can be comprised of as many as 16 32-bit 4-component vectors.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="554ac-134"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="554ac-134"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="554ac-135">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="554ac-135">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




