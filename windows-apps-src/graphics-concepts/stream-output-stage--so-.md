---
title: ストリーム出力 (SO) ステージ
description: ストリーム出力 (SO) ステージでは、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。 メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。
ms.assetid: DE89E99F-39BC-4B34-B80F-A7D373AA7C0A
keywords:
- ストリーム出力 (SO) ステージ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a86aa5a78bc4df9deaeea239356345c33736d942
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5865032"
---
# <a name="stream-output-so-stage"></a><span data-ttu-id="c9ff2-105">ストリーム出力 (SO) ステージ</span><span class="sxs-lookup"><span data-stu-id="c9ff2-105">Stream Output (SO) stage</span></span>


<span data-ttu-id="c9ff2-106">ストリーム出力 (SO) ステージでは、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-106">The Stream Output (SO) stage continuously outputs (or streams) vertex data from the previous active stage to one or more buffers in memory.</span></span> <span data-ttu-id="c9ff2-107">メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-107">Data streamed out to memory can be re-circulated back into the pipeline as input data, or read-back from the CPU.</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="c9ff2-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と用途</span><span class="sxs-lookup"><span data-stu-id="c9ff2-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


![パイプライン内のストリーム出力ステージの場所を示す図](images/d3d10-pipeline-stages-so.png)

<span data-ttu-id="c9ff2-110">ストリーム出力ステージでは、パイプラインからラスタライザーへの途中でメモリにプリミティブ データをストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-110">The stream-output stage streams primitive data from the pipeline to memory on its way to the rasterizer.</span></span> <span data-ttu-id="c9ff2-111">前のステージのデータをメモリにストリーミングするか、ラスタライザーに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-111">Data from the previous stage can be streamed out to memory, and/or passed into the rasterizer.</span></span> <span data-ttu-id="c9ff2-112">メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-112">Data streamed out to memory can be re-circulated back into the pipeline as input data, or read-back from the CPU.</span></span>

<span data-ttu-id="c9ff2-113">メモリにストリーミングされたデータは、後続のレンダリング パスでパイプラインに読み戻すか、ステージング リソースにコピーできます (CPU によって読み取られるようにするため)。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-113">Data streamed out to memory can be read back into the pipeline in a subsequent rendering pass, or can be copied to a staging resource (so it can be read by the CPU).</span></span> <span data-ttu-id="c9ff2-114">ストリーム出力されるデータの量は一定ではありません。Direct3D は、書き込まれるデータの量について (GPU に) 照会しなくてもデータを処理できるように設計されています。&gt;</span><span class="sxs-lookup"><span data-stu-id="c9ff2-114">The amount of data streamed out can vary; Direct3D is designed to handle the data without the need to query (the GPU) about the amount of data written.--&gt;</span></span>

<span data-ttu-id="c9ff2-115">ストリーム出力データをパイプラインに送る方法は 2 とおりあります。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-115">There are two ways to feed stream-output data into the pipeline:</span></span>

-   <span data-ttu-id="c9ff2-116">ストリーム出力データは、入力アセンブラー (IA) ステージに戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-116">Stream-output data can be fed back into the Input Assembler (IA) stage.</span></span>
-   <span data-ttu-id="c9ff2-117">ストリーム出力データは、ロード関数 ([Load](https://msdn.microsoft.com/library/windows/desktop/bb509694) など) を使用して、プログラム可能なシェーダーで読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-117">Stream-output data can be read by programmable shaders using [Load](https://msdn.microsoft.com/library/windows/desktop/bb509694) functions.</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="c9ff2-118"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="c9ff2-118"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="c9ff2-119">前のシェーダー ステージの頂点データです。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-119">Vertex data from a previous shader stage.</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="c9ff2-120"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="c9ff2-120"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="c9ff2-121">ストリーム出力 (SO) ステージでは、ジオメトリ シェーダー (GS) ステージなど、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-121">The Stream Ouput (SO) stage continuously outputs (or streams) vertex data from the previous active stage, such as the Geometry Shader (GS) stage, to one or more buffers in memory.</span></span> <span data-ttu-id="c9ff2-122">ジオメトリ シェーダー (GS) ステージがアクティブでない場合、ストリーム出力 (SO) ステージでは、ドメイン シェーダー (DS) ステージから (DS もアクティブでない場合は、頂点シェーダー (VS) ステージから) メモリ内のバッファーに頂点データを継続して出力します。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-122">If the Geometry Shader (GS) stage is inactive, the Stream Ouput (SO) stage continuously outputs vertex data from the Domain Shader (DS) stage to buffers in memory (or if DS is also inactive, from the Vertex Shader (VS) stage).</span></span>

<span data-ttu-id="c9ff2-123">三角形ストリップまたはライン ストリップが入力アセンブラー (IA) ステージにバインドされている場合、ストリーム アウトする前に、各ストリップがリストに変換されます。頂点が常に (たとえば、3 つの頂点の三角形、一度に); の完全なプリミティブとして書き出さ不完全なプリミティブがストリーム出力されることはありません。隣接性を持つプリミティブ型は、アウト データをストリーミングする前に隣接性データを破棄します。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-123">When a triangle or line strip is bound to the Input Assembler (IA) stage, each strip is converted into a list before they are streamed out. Vertices are always written out as complete primitives (for example, 3 vertices at a time for triangles); incomplete primitives are never streamed out. Primitive types with adjacency discard the adjacency data before streaming data out.</span></span>

<span data-ttu-id="c9ff2-124">ストリーム出力ステージでは、同時に最大 4 つのバッファーまでサポートします。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-124">The stream-output stage supports up to 4 buffers simultaneously.</span></span>

-   <span data-ttu-id="c9ff2-125">複数のバッファーにデータをストリームする場合、各バッファーは頂点単位のデータの 1 つの要素 (最大 4 コンポーネント) のみを取得でき、出力されるデータは、各バッファーの要素幅と等しくなるようにストライドされます (単一要素バッファーをシェーダー ステージへの入力のためにバインドする方法に対応しています)。さらに、各バッファーのサイズが異なる場合、バッファーのいずれかがいっぱいになるとすぐに書き込みが停止します。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-125">If you are streaming data into multiple buffers, each buffer can only capture a single element (up to 4 components) of per-vertex data, with an implied data stride equal to the element width in each buffer (compatible with the way single element buffers can be bound for input into shader stages).</span></span> <span data-ttu-id="c9ff2-126">さらに、各バッファーのサイズが異なる場合、バッファーのいずれかがいっぱいになるとすぐに書き込みが停止します。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-126">Furthermore, if the buffers have different sizes, writing stops as soon as any one of the buffers is full.</span></span>
-   <span data-ttu-id="c9ff2-127">1 つのバッファーにデータをストリームする場合、そのバッファーでは、頂点単位のデータ (256 バイト以下) のスカラーコンポーネントを 64 個まで取得できます。また、頂点を 2048 バイトまでストライドできます。</span><span class="sxs-lookup"><span data-stu-id="c9ff2-127">If you are streaming data into a single buffer, the buffer can capture up to 64 scalar components of per-vertex data (256 bytes or less) or the vertex stride can be up to 2048 bytes.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="c9ff2-128"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="c9ff2-128"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="c9ff2-129">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="c9ff2-129">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




