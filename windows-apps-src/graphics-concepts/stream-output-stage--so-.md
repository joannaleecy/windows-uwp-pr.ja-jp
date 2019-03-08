---
title: ストリーム出力 (SO) ステージ
description: ストリーム出力 (SO) ステージでは、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。 メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。
ms.assetid: DE89E99F-39BC-4B34-B80F-A7D373AA7C0A
keywords:
- ストリーム出力 (SO) ステージ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 87eb6562c6ee66ca1d409d3748e688861d5f3920
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57605047"
---
# <a name="stream-output-so-stage"></a><span data-ttu-id="19f8c-105">ストリーム出力 (SO) ステージ</span><span class="sxs-lookup"><span data-stu-id="19f8c-105">Stream Output (SO) stage</span></span>


<span data-ttu-id="19f8c-106">ストリーム出力 (SO) ステージでは、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。</span><span class="sxs-lookup"><span data-stu-id="19f8c-106">The Stream Output (SO) stage continuously outputs (or streams) vertex data from the previous active stage to one or more buffers in memory.</span></span> <span data-ttu-id="19f8c-107">メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。</span><span class="sxs-lookup"><span data-stu-id="19f8c-107">Data streamed out to memory can be re-circulated back into the pipeline as input data, or read-back from the CPU.</span></span>

## <a name="span-idpurposeandusesspanspan-idpurposeandusesspanspan-idpurposeandusesspanpurpose-and-uses"></a><span data-ttu-id="19f8c-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>目的と使用</span><span class="sxs-lookup"><span data-stu-id="19f8c-108"><span id="Purpose_and_uses"></span><span id="purpose_and_uses"></span><span id="PURPOSE_AND_USES"></span>Purpose and uses</span></span>


![パイプライン内のストリーム出力ステージの場所を示す図](images/d3d10-pipeline-stages-so.png)

<span data-ttu-id="19f8c-110">ストリーム出力ステージでは、パイプラインからラスタライザーへの途中でメモリにプリミティブ データをストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="19f8c-110">The stream-output stage streams primitive data from the pipeline to memory on its way to the rasterizer.</span></span> <span data-ttu-id="19f8c-111">前のステージのデータをメモリにストリーミングするか、ラスタライザーに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="19f8c-111">Data from the previous stage can be streamed out to memory, and/or passed into the rasterizer.</span></span> <span data-ttu-id="19f8c-112">メモリにストリーミングされたデータは、CPU からの入力データまたはリード バックとして、パイプラインに再循環させることができます。</span><span class="sxs-lookup"><span data-stu-id="19f8c-112">Data streamed out to memory can be re-circulated back into the pipeline as input data, or read-back from the CPU.</span></span>

<span data-ttu-id="19f8c-113">メモリにストリーミングされたデータは、後続のレンダリング パスでパイプラインに読み戻すか、ステージング リソースにコピーできます (CPU によって読み取られるようにするため)。</span><span class="sxs-lookup"><span data-stu-id="19f8c-113">Data streamed out to memory can be read back into the pipeline in a subsequent rendering pass, or can be copied to a staging resource (so it can be read by the CPU).</span></span> <span data-ttu-id="19f8c-114">ストリーム出力されるデータの量は一定ではありません。Direct3D は、書き込まれるデータの量について (GPU に) 照会しなくてもデータを処理できるように設計されています。&gt;</span><span class="sxs-lookup"><span data-stu-id="19f8c-114">The amount of data streamed out can vary; Direct3D is designed to handle the data without the need to query (the GPU) about the amount of data written.--&gt;</span></span>

<span data-ttu-id="19f8c-115">ストリーム出力データをパイプラインに送る方法は 2 とおりあります。</span><span class="sxs-lookup"><span data-stu-id="19f8c-115">There are two ways to feed stream-output data into the pipeline:</span></span>

-   <span data-ttu-id="19f8c-116">ストリーム出力データは、入力アセンブラー (IA) ステージに戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="19f8c-116">Stream-output data can be fed back into the Input Assembler (IA) stage.</span></span>
-   <span data-ttu-id="19f8c-117">ストリーム出力データは、ロード関数 ([Load](https://msdn.microsoft.com/library/windows/desktop/bb509694) など) を使用して、プログラム可能なシェーダーで読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="19f8c-117">Stream-output data can be read by programmable shaders using [Load](https://msdn.microsoft.com/library/windows/desktop/bb509694) functions.</span></span>

## <a name="span-idinputspanspan-idinputspanspan-idinputspaninput"></a><span data-ttu-id="19f8c-118"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>入力</span><span class="sxs-lookup"><span data-stu-id="19f8c-118"><span id="Input"></span><span id="input"></span><span id="INPUT"></span>Input</span></span>


<span data-ttu-id="19f8c-119">前のシェーダー ステージの頂点データです。</span><span class="sxs-lookup"><span data-stu-id="19f8c-119">Vertex data from a previous shader stage.</span></span>

## <a name="span-idoutputspanspan-idoutputspanspan-idoutputspanoutput"></a><span data-ttu-id="19f8c-120"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>出力</span><span class="sxs-lookup"><span data-stu-id="19f8c-120"><span id="Output"></span><span id="output"></span><span id="OUTPUT"></span>Output</span></span>


<span data-ttu-id="19f8c-121">ストリーム出力 (SO) ステージでは、ジオメトリ シェーダー (GS) ステージなど、直前のアクティブなステージからメモリ内の 1 つ以上のバッファーに、頂点データを連続して出力 (ストリーミング) します。</span><span class="sxs-lookup"><span data-stu-id="19f8c-121">The Stream Output (SO) stage continuously outputs (or streams) vertex data from the previous active stage, such as the Geometry Shader (GS) stage, to one or more buffers in memory.</span></span> <span data-ttu-id="19f8c-122">ジオメトリ シェーダー (GS) のステージがアクティブでない場合、Stream 出力 (SO) 段階は継続的にメモリ (または、DS でないかどうかも、頂点シェーダー (VS) ステージからのアクティブな) 内のバッファーに、ドメイン シェーダー (DS) のステージから頂点データを出力します。</span><span class="sxs-lookup"><span data-stu-id="19f8c-122">If the Geometry Shader (GS) stage is inactive, the Stream Output (SO) stage continuously outputs vertex data from the Domain Shader (DS) stage to buffers in memory (or if DS is also inactive, from the Vertex Shader (VS) stage).</span></span>

<span data-ttu-id="19f8c-123">三角形ストリップまたはライン ストリップが入力アセンブラー (IA) ステージにバインドされているときには、各ストリップがリストに変換されてからストリーム出力されます。頂点は、常に、完全なプリミティブとして書き出されます (たとえば、三角形の場合は 3 つの頂点が一度に出力されます)。不完全なプリミティブがストリーム出力されることはありません。隣接性のあるプリミティブ タイプの場合、データがストリーム出力される前に隣接性データが破棄されます。</span><span class="sxs-lookup"><span data-stu-id="19f8c-123">When a triangle or line strip is bound to the Input Assembler (IA) stage, each strip is converted into a list before they are streamed out. Vertices are always written out as complete primitives (for example, 3 vertices at a time for triangles); incomplete primitives are never streamed out. Primitive types with adjacency discard the adjacency data before streaming data out.</span></span>

<span data-ttu-id="19f8c-124">ストリーム出力ステージでは、同時に最大 4 つのバッファーまでサポートします。</span><span class="sxs-lookup"><span data-stu-id="19f8c-124">The stream-output stage supports up to 4 buffers simultaneously.</span></span>

-   <span data-ttu-id="19f8c-125">複数のバッファーにデータをストリームする場合、各バッファーは頂点単位のデータの 1 つの要素 (最大 4 コンポーネント) のみを取得でき、出力されるデータは、各バッファーの要素幅と等しくなるようにストライドされます (単一要素バッファーをシェーダー ステージへの入力のためにバインドする方法に対応しています)。さらに、各バッファーのサイズが異なる場合、バッファーのいずれかがいっぱいになるとすぐに書き込みが停止します。</span><span class="sxs-lookup"><span data-stu-id="19f8c-125">If you are streaming data into multiple buffers, each buffer can only capture a single element (up to 4 components) of per-vertex data, with an implied data stride equal to the element width in each buffer (compatible with the way single element buffers can be bound for input into shader stages).</span></span> <span data-ttu-id="19f8c-126">さらに、各バッファーのサイズが異なる場合、バッファーのいずれかがいっぱいになるとすぐに書き込みが停止します。</span><span class="sxs-lookup"><span data-stu-id="19f8c-126">Furthermore, if the buffers have different sizes, writing stops as soon as any one of the buffers is full.</span></span>
-   <span data-ttu-id="19f8c-127">1 つのバッファーにデータをストリームする場合、そのバッファーでは、頂点単位のデータ (256 バイト以下) のスカラーコンポーネントを 64 個まで取得できます。また、頂点を 2048 バイトまでストライドできます。</span><span class="sxs-lookup"><span data-stu-id="19f8c-127">If you are streaming data into a single buffer, the buffer can capture up to 64 scalar components of per-vertex data (256 bytes or less) or the vertex stride can be up to 2048 bytes.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="19f8c-128"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="19f8c-128"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="19f8c-129">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="19f8c-129">Graphics pipeline</span></span>](graphics-pipeline.md)

 

 




