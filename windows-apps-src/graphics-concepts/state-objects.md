---
title: 状態オブジェクト
description: デバイスの状態は状態オブジェクトを使用してグループ化されます。それにより、状態変更のコストが大幅に削減されます。 状態オブジェクトは数種類あり、それぞれ、特定のパイプライン ステージ向けに一連の状態を初期化することを目的としています。 状態オブジェクトは、Direct3D のバージョンによって異なります。
ms.assetid: D998745C-2B75-4E59-9923-AD1A17A92E05
keywords:
- 状態オブジェクト
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 3437119979073a5cec27948fc90f954e06c2fc93
ms.sourcegitcommit: 681c70f964210ab49ac5d06357ae96505bb78741
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/26/2018
ms.locfileid: "7707123"
---
# <a name="state-objects"></a><span data-ttu-id="ff3d1-106">状態オブジェクト</span><span class="sxs-lookup"><span data-stu-id="ff3d1-106">State objects</span></span>


<span data-ttu-id="ff3d1-107">デバイスの状態は状態オブジェクトを使用してグループ化されます。それにより、状態変更のコストが大幅に削減されます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-107">Device state is grouped into state objects which greatly reduce the cost of state changes.</span></span> <span data-ttu-id="ff3d1-108">状態オブジェクトは数種類あり、それぞれ、特定のパイプライン ステージ向けに一連の状態を初期化することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-108">There are several state objects, and each one is designed to initialize a set of state for a particular pipeline stage.</span></span> <span data-ttu-id="ff3d1-109">状態オブジェクトは、Direct3D のバージョンによって異なります。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-109">State objects vary by version of Direct3D.</span></span>

## <a name="span-idinputlayoutspanspan-idinputlayoutspanspan-idinputlayoutspaninput-layout-state"></a><span data-ttu-id="ff3d1-110"><span id="Input_Layout"></span><span id="input_layout"></span><span id="INPUT_LAYOUT"></span>入力レイアウトの状態</span><span class="sxs-lookup"><span data-stu-id="ff3d1-110"><span id="Input_Layout"></span><span id="input_layout"></span><span id="INPUT_LAYOUT"></span>Input-Layout State</span></span>


<span data-ttu-id="ff3d1-111">この状態のグループは、[入力アセンブラー (IA) ステージ](input-assembler-stage--ia-.md)で、入力バッファーからデータを読み取り、頂点シェーダーによって使用できるようにアセンブルする方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-111">This group of state dictates how the [Input Assembler (IA) stage](input-assembler-stage--ia-.md) reads data out of the input buffers and assembles it for use by the vertex shader.</span></span> <span data-ttu-id="ff3d1-112">これには、入力バッファー内の要素数や、入力データの署名などの状態が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-112">This includes state such as the number of elements in the input buffer and the signature of the input data.</span></span> <span data-ttu-id="ff3d1-113">入力アセンブラー (IA) ステージでは、メモリからパイプラインにプリミティブをストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-113">The Input Assembler (IA) stage streams primitives from memory into the pipeline.</span></span>

## <a name="span-idrasterizerspanspan-idrasterizerspanspan-idrasterizerspanrasterizer-state"></a><span data-ttu-id="ff3d1-114"><span id="Rasterizer"></span><span id="rasterizer"></span><span id="RASTERIZER"></span>ラスタライザーの状態</span><span class="sxs-lookup"><span data-stu-id="ff3d1-114"><span id="Rasterizer"></span><span id="rasterizer"></span><span id="RASTERIZER"></span>Rasterizer State</span></span>


<span data-ttu-id="ff3d1-115">この状態のグループは、[ラスタライザー (RS) ステージ](rasterizer-stage--rs-.md)を初期化します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-115">This group of state initializes the [Rasterizer (RS) stage](rasterizer-stage--rs-.md).</span></span> <span data-ttu-id="ff3d1-116">このオブジェクトには、塗りつぶしやカリングのモード、クリッピングでのシザリング四角形の有効化、マルチサンプル パラメーターの設定などの状態が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-116">This object includes state such as fill or cull modes, enabling a scissor rectangle for clipping, and setting multisample parameters.</span></span> <span data-ttu-id="ff3d1-117">このステージでは、プリミティブをピクセルにラスタライズし、クリッピングやプリミティブのビューポートへのマッピングなどの操作を実行します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-117">This stage rasterizes primitives into pixels, performing operations like clipping and mapping primitives to the viewport.</span></span>

## <a name="span-iddepthstencilspanspan-iddepthstencilspanspan-iddepthstencilspandepth-stencil-state"></a><span data-ttu-id="ff3d1-118"><span id="DepthStencil"></span><span id="depthstencil"></span><span id="DEPTHSTENCIL"></span>深度ステンシルの状態</span><span class="sxs-lookup"><span data-stu-id="ff3d1-118"><span id="DepthStencil"></span><span id="depthstencil"></span><span id="DEPTHSTENCIL"></span>Depth-Stencil State</span></span>


<span data-ttu-id="ff3d1-119">この状態のグループは、[出力マージャー (OM) ステージ](output-merger-stage--om-.md)の深度ステンシルの部分を初期化します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-119">This group of state initializes the depth-stencil portion of the [Output Merger (OM) stage](output-merger-stage--om-.md).</span></span> <span data-ttu-id="ff3d1-120">具体的には、このオブジェクトは、深度とステンシルのテストを初期化します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-120">More specifically, this object initializes depth and stencil testing.</span></span>

## <a name="span-idblendspanspan-idblendspanspan-idblendspanblend-state"></a><span data-ttu-id="ff3d1-121"><span id="Blend"></span><span id="blend"></span><span id="BLEND"></span>ブレンドの状態</span><span class="sxs-lookup"><span data-stu-id="ff3d1-121"><span id="Blend"></span><span id="blend"></span><span id="BLEND"></span>Blend State</span></span>


<span data-ttu-id="ff3d1-122">この状態のグループは、[出力マージャー (OM) ステージ](output-merger-stage--om-.md)のブレンドの部分を初期化します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-122">This group of state initializes the blending portion of the [Output Merger (OM) stage](output-merger-stage--om-.md).</span></span>

## <a name="span-idsamplerspanspan-idsamplerspanspan-idsamplerspansampler-state"></a><span data-ttu-id="ff3d1-123"><span id="Sampler"></span><span id="sampler"></span><span id="SAMPLER"></span>サンプラーの状態</span><span class="sxs-lookup"><span data-stu-id="ff3d1-123"><span id="Sampler"></span><span id="sampler"></span><span id="SAMPLER"></span>Sampler State</span></span>


<span data-ttu-id="ff3d1-124">この状態のグループは、サンプラー オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-124">This group of state initializes a sampler object.</span></span> <span data-ttu-id="ff3d1-125">サンプラー オブジェクトは、シェーダー ステージにおいて、メモリ内のフィルター テクスチャに対して使用されます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-125">A sampler object is used by the shader stages to filter textures in memory.</span></span>

<span data-ttu-id="ff3d1-126">Direct3D では、サンプラー オブジェクトは特定のテクスチャにはバインドされません。アタッチされているリソースがある場合に、フィルタリングを実行する方法を記述します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-126">In Direct3D, the sampler object is not bound to a specific texture, it just describes how to do filtering given any attached resource.</span></span>

## <a name="span-idperformanceconsiderationsspanspan-idperformanceconsiderationsspanspan-idperformanceconsiderationsspanperformance-considerations"></a><span data-ttu-id="ff3d1-127"><span id="Performance_Considerations"></span><span id="performance_considerations"></span><span id="PERFORMANCE_CONSIDERATIONS"></span>パフォーマンスに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="ff3d1-127"><span id="Performance_Considerations"></span><span id="performance_considerations"></span><span id="PERFORMANCE_CONSIDERATIONS"></span>Performance Considerations</span></span>


<span data-ttu-id="ff3d1-128">状態オブジェクトを使用するように API を設計すると、いくつかパフォーマンス上のメリットが得られます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-128">Designing the API to use state objects creates several performance advantages.</span></span> <span data-ttu-id="ff3d1-129">これには、オブジェクト作成時の状態の検証、ハードウェアでの状態オブジェクトのキャッシュの実現、(状態ではなく状態へのハンドルを渡すことで) 状態設定 API 呼び出し中に渡される状態の量の大幅な削減などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-129">These include validating state at object creation time, enabling caching of state objects in hardware, and greatly reducing the amount of state that is passed during a state-setting API call (by passing a handle to the state object instead of the state).</span></span>

<span data-ttu-id="ff3d1-130">このようなパフォーマンスの向上を実現するには、アプリケーションの起動時 (レンダー ループのかなり前の時点) に状態オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-130">To achieve these performance improvements, you should create your state objects when your application starts up, well before your render loop.</span></span> <span data-ttu-id="ff3d1-131">状態オブジェクトは変更できません。つまり、一度作成されると、変更できません。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-131">State objects are immutable, that is, once they are created, you cannot change them.</span></span> <span data-ttu-id="ff3d1-132">変更する場合は破棄して作成し直す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-132">Instead you must destroy and recreate them.</span></span>

<span data-ttu-id="ff3d1-133">サンプラーの状態の組み合わせを変えることで、数種類のサンプラー オブジェクトを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-133">You could create several sampler objects with various sampler-state combinations.</span></span> <span data-ttu-id="ff3d1-134">その後、適切な "Set" API を呼び出すことで、サンプラーの状態を変更します。この API によって (サンプラーの状態ではなく) ハンドルがオブジェクトに渡されます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-134">Changing the sampler state is then accomplished by calling the appropriate "Set" API which passes a handle to the object (as opposed to the sampler state).</span></span> <span data-ttu-id="ff3d1-135">これにより、呼び出しの回数とデータ量が大幅に削減されるため、状態変更のレンダー フレームごとにオーバーヘッドが大幅に削減されます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-135">This significantly reduces the amount of overhead during each render frame for changing state since the number of calls and the amount of data are greatly reduced.</span></span>

<span data-ttu-id="ff3d1-136">または、アプリケーションの状態オブジェクトの効率的な作成と破棄を自動的に管理する効果オブジェクトを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="ff3d1-136">Alternatively, you can choose to use the effect system which will automatically manage efficient creation and destruction of state objects for your application.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="ff3d1-137"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="ff3d1-137"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="ff3d1-138">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="ff3d1-138">Graphics pipeline</span></span>](graphics-pipeline.md)

[<span data-ttu-id="ff3d1-139">ビュー</span><span class="sxs-lookup"><span data-stu-id="ff3d1-139">Views</span></span>](views.md)

 

 




