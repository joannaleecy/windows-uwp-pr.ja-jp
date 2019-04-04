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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57583290"
---
# <a name="direct3d-graphics-glossary"></a><span data-ttu-id="16879-104">Direct3D グラフィックスの用語集</span><span class="sxs-lookup"><span data-stu-id="16879-104">Direct3D graphics glossary</span></span>


<span data-ttu-id="16879-105">Microsoft Direct3D グラフィックスの用語を定義します。</span><span class="sxs-lookup"><span data-stu-id="16879-105">Defines Microsoft Direct3D graphics terms.</span></span> <span data-ttu-id="16879-106">この用語集では、Direct3D のゲームおよびアプリの開発で使用されている一般的な 3D コンピューター グラフィックス用語の概要を定義します。</span><span class="sxs-lookup"><span data-stu-id="16879-106">This glossary defines, at a high level, general 3D computer graphics terms that are used in Direct3D game and app development.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="16879-107"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="16879-107"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="16879-108">トピック</span><span class="sxs-lookup"><span data-stu-id="16879-108">Topic</span></span></th>
<th align="left"><span data-ttu-id="16879-109">説明</span><span class="sxs-lookup"><span data-stu-id="16879-109">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="16879-110"><a href="coordinate-systems-and-geometry.md">座標系とジオメトリ</a></span><span class="sxs-lookup"><span data-stu-id="16879-110"><a href="coordinate-systems-and-geometry.md">Coordinate systems and geometry</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-111">Direct3D アプリケーションをプログラムするには、3D ジオメトリの原理を実務で熟知していることが必要です。</span><span class="sxs-lookup"><span data-stu-id="16879-111">Programming Direct3D applications requires a working familiarity with 3D geometric principles.</span></span> <span data-ttu-id="16879-112">このセクションでは、3D シーンを作成するための最も重要な幾何学的概念について説明します。</span><span class="sxs-lookup"><span data-stu-id="16879-112">This section introduces the most important geometric concepts for creating 3D scenes.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="16879-113"><a href="vertex-and-index-buffers.md">頂点バッファーとインデックス バッファー</a></span><span class="sxs-lookup"><span data-stu-id="16879-113"><a href="vertex-and-index-buffers.md">Vertex and index buffers</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-114"><em>"頂点バッファー"</em> は、頂点データを格納するメモリ バッファーです。頂点バッファー内の頂点は、変換、照明の適用、クリッピングを実行するために処理されます。</span><span class="sxs-lookup"><span data-stu-id="16879-114"><em>Vertex buffers</em> are memory buffers that contain vertex data; vertices in a vertex buffer are processed to perform transformation, lighting, and clipping.</span></span> <span data-ttu-id="16879-115"><em>インデックス バッファー</em>は、インデックス データを含むメモリ バッファーであり、プリミティブのレンダリングに使用される、頂点バッファーへの整数オフセットです。</span><span class="sxs-lookup"><span data-stu-id="16879-115"><em>Index buffers</em> are memory buffers that contain index data, which are integer offsets into vertex buffers, used to render primitives.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="16879-116"><a href="devices.md">デバイス</a></span><span class="sxs-lookup"><span data-stu-id="16879-116"><a href="devices.md">Devices</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-117">Direct3D デバイスは、Direct3D のレンダリング コンポーネントです。</span><span class="sxs-lookup"><span data-stu-id="16879-117">A Direct3D device is the rendering component of Direct3D.</span></span> <span data-ttu-id="16879-118">デバイスは、レンダリングの状態をカプセル化して格納します。また、変換や照明の操作、サーフェスへのイメージのラスタライズを実行します。</span><span class="sxs-lookup"><span data-stu-id="16879-118">A device encapsulates and stores the rendering state, performs transformations and lighting operations, and rasterizes an image to a surface.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="16879-119"><a href="lights-and-materials.md">照明</a></span><span class="sxs-lookup"><span data-stu-id="16879-119"><a href="lights-and-materials.md">Lighting</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-120">光源は、シーン内のオブジェクトを照射するのに使われます。</span><span class="sxs-lookup"><span data-stu-id="16879-120">Lights are used to illuminate objects in a scene.</span></span> <span data-ttu-id="16879-121">各オブジェクト頂点の色は、現在のテクスチャ マップ、頂点の色、光源に基づきます。</span><span class="sxs-lookup"><span data-stu-id="16879-121">The color of each object vertex is based on the current texture map, vertex colors, and light sources.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="16879-122"><a href="depth-and-stencil-buffers.md">深度バッファーとステンシル バッファー</a></span><span class="sxs-lookup"><span data-stu-id="16879-122"><a href="depth-and-stencil-buffers.md">Depth and stencil buffers</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-123"><em>深度バッファー</em>には、ビューから隠すのではなくレンダリングする多角形の領域を制御するための深度情報が格納されます。</span><span class="sxs-lookup"><span data-stu-id="16879-123">A <em>depth buffer</em> stores depth information to control which areas of polygons are rendered rather than hidden from view.</span></span> <span data-ttu-id="16879-124"><em>ステンシル バッファー</em>は、画像内のピクセルをマスクし、合成、デカール、ディゾルブ、フェード、スワイプ、輪郭とシルエット、両面ステンシルなどの特殊効果を生成するために使われます。</span><span class="sxs-lookup"><span data-stu-id="16879-124">A <em>stencil buffer</em> is used to mask pixels in an image, to produce special effects, including compositing; decaling; dissolves, fades, and swipes; outlines and silhouettes; and two-sided stencil.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="16879-125"><a href="textures.md">テクスチャ</a></span><span class="sxs-lookup"><span data-stu-id="16879-125"><a href="textures.md">Textures</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-126">テクスチャは、コンピューターにより生成された 3D 画像でリアルさを出すための強力なツールです。</span><span class="sxs-lookup"><span data-stu-id="16879-126">Textures are a powerful tool in creating realism in computer-generated 3D images.</span></span> <span data-ttu-id="16879-127">Direct3D は広範囲のテクスチャリング機能セットをサポートし、高度なテクスチャリング手法に簡単にアクセスできる方法を開発者に提供します。</span><span class="sxs-lookup"><span data-stu-id="16879-127">Direct3D supports an extensive texturing feature set, providing developers with easy access to advanced texturing techniques.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="16879-128"><a href="graphics-pipeline.md">グラフィックス パイプライン</a></span><span class="sxs-lookup"><span data-stu-id="16879-128"><a href="graphics-pipeline.md">Graphics pipeline</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-129">Direct3D グラフィックス パイプラインは、リアルタイム ゲーム アプリケーション用のグラフィックスを生成できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="16879-129">The Direct3D graphics pipeline is designed for generating graphics for realtime gaming applications.</span></span> <span data-ttu-id="16879-130">データは、構成可能またはプログラミング可能な各ステージを通じて、入力から出力へと流れます。</span><span class="sxs-lookup"><span data-stu-id="16879-130">Data flows from input to output through each of the configurable or programmable stages.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="16879-131"><a href="views.md">ビュー</a></span><span class="sxs-lookup"><span data-stu-id="16879-131"><a href="views.md">Views</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-132">&quot;ビュー&quot; という語は、&quot;必要な形式のデータ&quot;を意味します。</span><span class="sxs-lookup"><span data-stu-id="16879-132">The term &quot;view&quot; is used to mean &quot;data in the required format&quot;.</span></span> <span data-ttu-id="16879-133">たとえば、定数バッファー ビュー (CBV) は、適切な形式の定数バッファー データを表します。</span><span class="sxs-lookup"><span data-stu-id="16879-133">For example, a Constant Buffer View (CBV) would be constant buffer data correctly formatted.</span></span> <span data-ttu-id="16879-134">このセクションでは、最もよく使われる便利なビューについて説明します。</span><span class="sxs-lookup"><span data-stu-id="16879-134">This section describes the most common and useful views.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="16879-135"><a href="compute-pipeline.md">計算パイプライン</a></span><span class="sxs-lookup"><span data-stu-id="16879-135"><a href="compute-pipeline.md">Compute pipeline</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-136">Direct3D 計算パイプラインは、大部分がグラフィックス パイプラインと並行して実行可能な計算を処理できるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="16879-136">The Direct3D compute pipeline is designed to handle calculations that can be done mostly in parallel with the graphics pipeline.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="16879-137"><a href="resources.md">リソース</a></span><span class="sxs-lookup"><span data-stu-id="16879-137"><a href="resources.md">Resources</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-138">リソースは、Direct3D パイプラインからアクセスできるメモリ内の領域です。</span><span class="sxs-lookup"><span data-stu-id="16879-138">A resource is an area in memory that can be accessed by the Direct3D pipeline.</span></span> <span data-ttu-id="16879-139">パイプラインでメモリに効率的にアクセスするには、パイプラインに渡すデータ (入力ジオメトリ、シェーダー リソース、テクスチャなど) をリソースに格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="16879-139">In order for the pipeline to access memory efficiently, data that is provided to the pipeline (such as input geometry, shader resources, and textures) must be stored in a resource.</span></span> <span data-ttu-id="16879-140">すべての Direct3D リソースの派生元となるリソースは 2 種類あります。バッファーとテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="16879-140">There are two types of resources from which all Direct3D resources derive: a buffer or a texture.</span></span> <span data-ttu-id="16879-141">各パイプライン ステージでは最大 128 個のリソースをアクティブにできます。</span><span class="sxs-lookup"><span data-stu-id="16879-141">Up to 128 resources can be active for each pipeline stage.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="16879-142"><a href="streaming-resources.md">ストリーミング リソース</a></span><span class="sxs-lookup"><span data-stu-id="16879-142"><a href="streaming-resources.md">Streaming resources</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-143"><em>ストリーミング リソース</em>は、少量の物理メモリを使用する大規模な論理リソースです。</span><span class="sxs-lookup"><span data-stu-id="16879-143"><em>Streaming resources</em> are large logical resources that use small amounts of physical memory.</span></span> <span data-ttu-id="16879-144">大きなリソース全体を渡すのではなく、小さなリソースのパーツを必要に応じてストリーミングします。</span><span class="sxs-lookup"><span data-stu-id="16879-144">Instead of passing an entire large resource, small parts of the resource are streamed as needed.</span></span> <span data-ttu-id="16879-145">ストリーミング リソースは、以前は<em>タイル リソース</em>と呼ばれていました。</span><span class="sxs-lookup"><span data-stu-id="16879-145">Streaming resources were previously called <em>tiled resources</em>.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="16879-146"><a href="appendix.md">付録</a></span><span class="sxs-lookup"><span data-stu-id="16879-146"><a href="appendix.md">Appendices</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="16879-147">これらのセクションでは、技術的な面について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="16879-147">These sections provide in-depth technical details.</span></span></p></td>
</tr>
</tbody>
</table>

 

 

 
