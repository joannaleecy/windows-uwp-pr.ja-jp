---
title: Direct3D グラフィックスの用語集
description: Microsoft Direct3D で使用されるグラフィックス用語を定義します。
ms.assetid: c3850a92-4d05-4f72-bf0f-6a0c79e841eb
keywords:
- Direct3D グラフィックスの用語集
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 3cb6a2466ea201c9b5047f7eb159477a0d584429
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8193184"
---
# <a name="direct3d-graphics-glossary"></a><span data-ttu-id="4f9be-104">Direct3D グラフィックスの用語集</span><span class="sxs-lookup"><span data-stu-id="4f9be-104">Direct3D graphics glossary</span></span>


<span data-ttu-id="4f9be-105">Microsoft Direct3D グラフィックスの用語を定義します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-105">Defines Microsoft Direct3D graphics terms.</span></span> <span data-ttu-id="4f9be-106">Direct3D ゲームとアプリの開発で使用される高レベル、一般的な 3D コンピューター グラフィックスの条件で、この用語集定義します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-106">This glossary defines, at a high level, general 3D computer graphics terms that are used in Direct3D game and app development.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="4f9be-107"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="4f9be-107"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="4f9be-108">トピック</span><span class="sxs-lookup"><span data-stu-id="4f9be-108">Topic</span></span></th>
<th align="left"><span data-ttu-id="4f9be-109">説明</span><span class="sxs-lookup"><span data-stu-id="4f9be-109">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="coordinate-systems-and-geometry.md"><span data-ttu-id="4f9be-110">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="4f9be-110">Coordinate systems and geometry</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-111">Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。</span><span class="sxs-lookup"><span data-stu-id="4f9be-111">Programming Direct3D applications requires a working familiarity with 3D geometric principles.</span></span> <span data-ttu-id="4f9be-112">このセクションでは、3D シーンを作成するための最も重要な幾何学的概念について説明します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-112">This section introduces the most important geometric concepts for creating 3D scenes.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="vertex-and-index-buffers.md"><span data-ttu-id="4f9be-113">頂点バッファーとインデックス バッファー</span><span class="sxs-lookup"><span data-stu-id="4f9be-113">Vertex and index buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-114">"頂点バッファー"<em></em> は、頂点データを格納するメモリ バッファーです。頂点バッファー内の頂点は、変換、照明の適用、クリッピングを実行するために処理されます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-114"><em>Vertex buffers</em> are memory buffers that contain vertex data; vertices in a vertex buffer are processed to perform transformation, lighting, and clipping.</span></span> <span data-ttu-id="4f9be-115"><em>インデックス バッファー</em>は、インデックス データを格納するメモリ バッファーです。インデックス データは頂点バッファーへの整数オフセットで、プリミティブのレンダリングに使われます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-115"><em>Index buffers</em> are memory buffers that contain index data, which are integer offsets into vertex buffers, used to render primitives.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="devices.md"><span data-ttu-id="4f9be-116">デバイス</span><span class="sxs-lookup"><span data-stu-id="4f9be-116">Devices</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-117">Direct3D デバイスは、Direct3D のレンダリング コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="4f9be-117">A Direct3D device is the rendering component of Direct3D.</span></span> <span data-ttu-id="4f9be-118">デバイスは、レンダリングの状態をカプセル化して格納します。また、変換や照明の操作、サーフェスへのイメージのラスタライズを実行します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-118">A device encapsulates and stores the rendering state, performs transformations and lighting operations, and rasterizes an image to a surface.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="lights-and-materials.md"><span data-ttu-id="4f9be-119">光源</span><span class="sxs-lookup"><span data-stu-id="4f9be-119">Lighting</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-120">光源は、シーン内のオブジェクトを照射するのに使われます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-120">Lights are used to illuminate objects in a scene.</span></span> <span data-ttu-id="4f9be-121">各オブジェクト頂点の色は、現在のテクスチャ マップ、頂点の色、光源に基づきます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-121">The color of each object vertex is based on the current texture map, vertex colors, and light sources.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="depth-and-stencil-buffers.md"><span data-ttu-id="4f9be-122">深度バッファーとステンシル バッファー</span><span class="sxs-lookup"><span data-stu-id="4f9be-122">Depth and stencil buffers</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-123"><em>深度バッファー</em>は、ビューから隠される多角形の領域ではなく、レンダリングされるポリゴンの領域を制御する深度情報を格納します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-123">A <em>depth buffer</em> stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span> <span data-ttu-id="4f9be-124"><em>ステンシル バッファー</em>は、画像内のピクセルをマスクするために使用されます。これにより、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどの特殊効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-124">A <em>stencil buffer</em> is used to mask pixels in an image, to produce special effects, including compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="textures.md"><span data-ttu-id="4f9be-125">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="4f9be-125">Textures</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-126">テクスチャは、コンピュータで作成した 3D 画像にリアルさを加えるための強力なツールです。</span><span class="sxs-lookup"><span data-stu-id="4f9be-126">Textures are a powerful tool in creating realism in computer-generated 3D images.</span></span> <span data-ttu-id="4f9be-127">Direct3D では、開発者が高度なテクスチャ手法に簡単にアクセスできれば、広範なテクスチャ機能セットがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-127">Direct3D supports an extensive texturing feature set, providing developers with easy access to advanced texturing techniques.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="graphics-pipeline.md"><span data-ttu-id="4f9be-128">グラフィックス パイプライン</span><span class="sxs-lookup"><span data-stu-id="4f9be-128">Graphics pipeline</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-129">Direct3D グラフィックス パイプラインは、リアルタイム ゲーム アプリケーション用のグラフィックスを生成できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="4f9be-129">The Direct3D graphics pipeline is designed for generating graphics for realtime gaming applications.</span></span> <span data-ttu-id="4f9be-130">データは、構成可能またはプログラミング可能な各ステージを通じて、入力から出力へと流れます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-130">Data flows from input to output through each of the configurable or programmable stages.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="views.md"><span data-ttu-id="4f9be-131">ビュー</span><span class="sxs-lookup"><span data-stu-id="4f9be-131">Views</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-132">&quot;ビュー&quot; という語は、&quot;必要な形式のデータ&quot;を意味します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-132">The term &quot;view&quot; is used to mean &quot;data in the required format&quot;.</span></span> <span data-ttu-id="4f9be-133">たとえば、定数バッファー ビュー (CBV) は、適切な形式の定数バッファー データです。</span><span class="sxs-lookup"><span data-stu-id="4f9be-133">For example, a Constant Buffer View (CBV) would be constant buffer data correctly formatted.</span></span> <span data-ttu-id="4f9be-134">ここでは、最も一般的で役に立つビューについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-134">This section describes the most common and useful views.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="compute-pipeline.md"><span data-ttu-id="4f9be-135">計算パイプライン</span><span class="sxs-lookup"><span data-stu-id="4f9be-135">Compute pipeline</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-136">Direct3D 計算パイプラインは、大部分がグラフィックス パイプラインと並行して実行可能な計算を処理できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="4f9be-136">The Direct3D compute pipeline is designed to handle calculations that can be done mostly in parallel with the graphics pipeline.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="resources.md"><span data-ttu-id="4f9be-137">リソース</span><span class="sxs-lookup"><span data-stu-id="4f9be-137">Resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-138">リソースは、Direct3D パイプラインからアクセスできるメモリ内の領域です。</span><span class="sxs-lookup"><span data-stu-id="4f9be-138">A resource is an area in memory that can be accessed by the Direct3D pipeline.</span></span> <span data-ttu-id="4f9be-139">パイプラインでメモリに効率的にアクセスするには、パイプラインに渡すデータ (入力ジオメトリ、シェーダー リソース、テクスチャなど) をリソースに格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4f9be-139">In order for the pipeline to access memory efficiently, data that is provided to the pipeline (such as input geometry, shader resources, and textures) must be stored in a resource.</span></span> <span data-ttu-id="4f9be-140">すべての Direct3D リソースの派生元となるリソースは 2 種類あります。バッファーとテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="4f9be-140">There are two types of resources from which all Direct3D resources derive: a buffer or a texture.</span></span> <span data-ttu-id="4f9be-141">各パイプライン ステージでは最大 128 個のリソースをアクティブにできます。</span><span class="sxs-lookup"><span data-stu-id="4f9be-141">Up to 128 resources can be active for each pipeline stage.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="streaming-resources.md"><span data-ttu-id="4f9be-142">ストリーミング リソース</span><span class="sxs-lookup"><span data-stu-id="4f9be-142">Streaming resources</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-143"><em>ストリーミング リソース</em>は、少量の物理メモリを使用する大規模な論理リソースです。</span><span class="sxs-lookup"><span data-stu-id="4f9be-143"><em>Streaming resources</em> are large logical resources that use small amounts of physical memory.</span></span> <span data-ttu-id="4f9be-144">大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="4f9be-144">Instead of passing an entire large resource, small parts of the resource are streamed as needed.</span></span> <span data-ttu-id="4f9be-145">ストリーミング リソースは、以前は<em>タイル リソース</em>と呼ばれていました。</span><span class="sxs-lookup"><span data-stu-id="4f9be-145">Streaming resources were previously called <em>tiled resources</em>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="appendix.md"><span data-ttu-id="4f9be-146">付録</span><span class="sxs-lookup"><span data-stu-id="4f9be-146">Appendices</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4f9be-147">これらのセクションでは、技術的な面について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="4f9be-147">These sections provide in-depth technical details.</span></span></p></td>
</tr>
</tbody>
</table>

 

 

 
