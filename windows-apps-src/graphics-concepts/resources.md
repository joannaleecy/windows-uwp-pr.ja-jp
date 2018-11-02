---
title: リソース
description: リソースは、Direct3D パイプラインからアクセスできるメモリ内の領域です。
ms.assetid: 2E68E5A8-83DA-4DC8-B7F3-B8988CF8090C
keywords:
- リソース
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a56b03de29e110a2768ebe71f4e61d8099ca1cf8
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5936933"
---
# <a name="resources"></a><span data-ttu-id="4e188-104">リソース</span><span class="sxs-lookup"><span data-stu-id="4e188-104">Resources</span></span>


<span data-ttu-id="4e188-105">リソースは、Direct3D パイプラインからアクセスできるメモリ内の領域です。</span><span class="sxs-lookup"><span data-stu-id="4e188-105">A resource is an area in memory that can be accessed by the Direct3D pipeline.</span></span> <span data-ttu-id="4e188-106">パイプラインでメモリに効率的にアクセスするには、パイプラインに渡すデータ (入力ジオメトリ、シェーダー リソース、テクスチャなど) をリソースに格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="4e188-106">In order for the pipeline to access memory efficiently, data that is provided to the pipeline (such as input geometry, shader resources, and textures) must be stored in a resource.</span></span> <span data-ttu-id="4e188-107">すべての Direct3D リソースの派生元となるリソースは 2 種類あります。バッファーとテクスチャです。</span><span class="sxs-lookup"><span data-stu-id="4e188-107">There are two types of resources from which all Direct3D resources derive: a buffer or a texture.</span></span> <span data-ttu-id="4e188-108">各パイプライン ステージでは最大 128 個のリソースをアクティブにできます。</span><span class="sxs-lookup"><span data-stu-id="4e188-108">Up to 128 resources can be active for each pipeline stage.</span></span>

<span data-ttu-id="4e188-109">通常、アプリケーションごとに多数のリソースが作成されます。</span><span class="sxs-lookup"><span data-stu-id="4e188-109">Each application will typically create many resources.</span></span> <span data-ttu-id="4e188-110">リソースの例として、頂点バッファー、インデックス バッファー、定数バッファー、テクスチャ、シェーダー リソースなどがあります。</span><span class="sxs-lookup"><span data-stu-id="4e188-110">Examples of resource include: vertex buffers, index buffer, constant buffer, textures, and shader resources.</span></span> <span data-ttu-id="4e188-111">リソースの使用方法を決めるオプションはいくつか存在します。</span><span class="sxs-lookup"><span data-stu-id="4e188-111">There are several options that determine how resources can be used.</span></span> <span data-ttu-id="4e188-112">厳密に型指定されたリソースを作成するか、型指定のないリソースを作成することができます。また、リソースで読み取りアクセスと書き込みアクセスの両方を可能にするかどうかも制御できます。さらに、CPU のみ、GPU のみ、またはその両方からリソースにアクセスできるようにすることも可能です。</span><span class="sxs-lookup"><span data-stu-id="4e188-112">You can create resources that are strongly typed or type less; you can control whether resources have both read and write access; you can make resources accessible to only the CPU, GPU, or both.</span></span> <span data-ttu-id="4e188-113">当然ながら、速度と機能はトレードオフの関係にあります。つまり、多くの機能をリソースに許可するほど、予想されるパフォーマンスが低下します。</span><span class="sxs-lookup"><span data-stu-id="4e188-113">Naturally, there will be speed vs. functionality tradeoff - the more functionality you allow a resource to have, the less performance you should expect.</span></span>

<span data-ttu-id="4e188-114">アプリケーションでは多数のテクスチャを使用することが多いので、Direct3D にはテクスチャ管理を簡略化するテクスチャ配列という概念も用意されています。</span><span class="sxs-lookup"><span data-stu-id="4e188-114">Since an application often uses many textures, Direct3D also has the concept of a texture array to simplify texture management.</span></span> <span data-ttu-id="4e188-115">テクスチャ配列には (型とサイズがすべて同じである) 1 つ以上のテクスチャが格納されており、アプリケーション内から、またはシェーダーでインデックスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="4e188-115">A texture array contains one or more textures (all of the same type and dimensions) that can be indexed from within an application or by shaders.</span></span> <span data-ttu-id="4e188-116">テクスチャ配列により、複数のインデックスを持つ 1 つのインターフェイスを使用して多数のテクスチャにアクセスすることができます。</span><span class="sxs-lookup"><span data-stu-id="4e188-116">Texture arrays allow you to use a single interface with multiple indexes to access many textures.</span></span> <span data-ttu-id="4e188-117">さまざまなテクスチャの種類を管理するために、テクスチャ配列は必要なだけ作成可能です。</span><span class="sxs-lookup"><span data-stu-id="4e188-117">You can create as many texture arrays to manage different texture types as you need.</span></span>

<span data-ttu-id="4e188-118">アプリケーションで使用するリソースを作成したら、それらを使用するパイプライン ステージに各リソースを接続またはバインドします。</span><span class="sxs-lookup"><span data-stu-id="4e188-118">Once you have created the resources that your application will use, you connect or bind each resource to the pipeline stages that will use them.</span></span> <span data-ttu-id="4e188-119">これは、リソースへのポインターを受け取るバインド API を呼び出すことで実行します。</span><span class="sxs-lookup"><span data-stu-id="4e188-119">This is accomplished by calling a bind API, which takes a pointer to the resource.</span></span> <span data-ttu-id="4e188-120">複数のパイプライン ステージで同じリソースにアクセスしなければならない場合があるため、Direct3D にはリソース ビューという概念が用意されています。</span><span class="sxs-lookup"><span data-stu-id="4e188-120">Since more than one pipeline stage may need access to the same resource, Direct3D has the concept of a resource view.</span></span> <span data-ttu-id="4e188-121">ビューは、リソースのうち、アクセス可能な部分を識別します。</span><span class="sxs-lookup"><span data-stu-id="4e188-121">A view identifies the portion of a resource that can be accessed.</span></span> <span data-ttu-id="4e188-122">*m* 個のビューまたは 1 つのリソースを作成して、*n* 個のパイプライン ステージにバインドすることができます。この際、共有リソースのバインド規則に従うことが前提となります (従わなければコンパイル時にランタイムでエラーが発生します)。</span><span class="sxs-lookup"><span data-stu-id="4e188-122">You can create *m* views or a resource and bind them to *n* pipeline stages, assuming you follow binding rules for shared resource (the runtime will generate errors at compile time if you don't).</span></span>

<span data-ttu-id="4e188-123">リソース ビューは、リソース (テクスチャやバッファーなど) にアクセスするための一般的なモデルです。</span><span class="sxs-lookup"><span data-stu-id="4e188-123">A resource view provides a general model for access to a resource (such as textures or buffers).</span></span> <span data-ttu-id="4e188-124">ビューを使用すると、アクセスするデータやデータへのアクセス方法をランタイムに対して指示できます。そのため、リソース ビューを使うことで、型指定なしのリソースを作成できるようになります。</span><span class="sxs-lookup"><span data-stu-id="4e188-124">Because you can use a view to tell the runtime what data to access and how to access it, resource views allow you create type less resources.</span></span> <span data-ttu-id="4e188-125">つまり、コンパイル時に特定のサイズのリソースを作成し、その後、リソースがパイプラインにバインドされるときにリソース内でデータ型を宣言できます。</span><span class="sxs-lookup"><span data-stu-id="4e188-125">That is, you can create resources for a given size at compile time, and then declare the data type within the resource when the resource gets bound to the pipeline.</span></span> <span data-ttu-id="4e188-126">ビューは、リソースを使用するための多数の機能を公開します。たとえば、シェーダーで深度/ステンシル サーフェスを読み返して、1 つのパスで動的なキューブマップを生成し、ボリュームの複数のスライスに同時にレンダリングすることができます。</span><span class="sxs-lookup"><span data-stu-id="4e188-126">Views expose many capabilities for using resources, such as the ability to read back depth/stencil surfaces in the shader, generating dynamic cubemaps in a single pass, and rendering simultaneously to multiple slices of a volume.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="4e188-127"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="4e188-127"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="4e188-128">トピック</span><span class="sxs-lookup"><span data-stu-id="4e188-128">Topic</span></span></th>
<th align="left"><span data-ttu-id="4e188-129">説明</span><span class="sxs-lookup"><span data-stu-id="4e188-129">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="resource-types.md"><span data-ttu-id="4e188-130">リソースの種類</span><span class="sxs-lookup"><span data-stu-id="4e188-130">Resource types</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4e188-131">リソースの種類によって、レイアウト (またはメモリ使用量) はそれぞれ異なります。</span><span class="sxs-lookup"><span data-stu-id="4e188-131">Different types of resources have a distinct layout (or memory footprint).</span></span> <span data-ttu-id="4e188-132">Direct3D パイプラインで使用されるリソースはすべて、2 つの基本的なリソースの種類である<a href="resource-types.md#buffer-resources">バッファー</a>と<a href="resource-types.md#texture-resources">テクスチャ</a>から派生したものです。</span><span class="sxs-lookup"><span data-stu-id="4e188-132">All resources used by the Direct3D pipeline derive from two basic resource types: <a href="resource-types.md#buffer-resources">buffers</a> and <a href="resource-types.md#texture-resources">textures</a>.</span></span> <span data-ttu-id="4e188-133">バッファーは未加工データ (要素) のコレクションで、テクスチャはテクセル (テクスチャ要素) のコレクションです。</span><span class="sxs-lookup"><span data-stu-id="4e188-133">A buffer is a collection of raw data (elements); a texture is a collection of texels (texture elements).</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="choosing-a-resource.md"><span data-ttu-id="4e188-134">リソースの選択</span><span class="sxs-lookup"><span data-stu-id="4e188-134">Choosing a resource</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4e188-135">リソースは、3D パイプラインで使用されるデータのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="4e188-135">A resource is a collection of data that is used by the 3D pipeline.</span></span> <span data-ttu-id="4e188-136">リソースを作成してその動作を定義することが、アプリケーションをプログラミングするための第一歩になります。</span><span class="sxs-lookup"><span data-stu-id="4e188-136">Creating resources and defining their behavior is the first step toward programming your application.</span></span> <span data-ttu-id="4e188-137">このガイドでは、アプリケーションで必要なリソースの選択に関する基本的なトピックについて説明します。</span><span class="sxs-lookup"><span data-stu-id="4e188-137">This guide covers basic topics for choosing the resources required by your application.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="copying-and-accessing-resource-data.md"><span data-ttu-id="4e188-138">リソース データのコピーとアクセス</span><span class="sxs-lookup"><span data-stu-id="4e188-138">Copying and accessing resource data</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4e188-139">使用法フラグは、アプリケーションがリソース データをどのように使用するかを示し、リソースを可能な限りメモリのパフォーマンスの高い領域に配置します。</span><span class="sxs-lookup"><span data-stu-id="4e188-139">Usage flags indicate how the application intends to use the resource data, to place resources in the most performant area of memory possible.</span></span> <span data-ttu-id="4e188-140">リソース データはリソース間でコピーされ、CPU または GPU がパフォーマンスに影響を与えることなくリソースにアクセスできるようにします。</span><span class="sxs-lookup"><span data-stu-id="4e188-140">Resource data is copied across resources so that the CPU or GPU can access it without impacting performance.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="texture-views.md"><span data-ttu-id="4e188-141">テクスチャ ビュー</span><span class="sxs-lookup"><span data-stu-id="4e188-141">Texture views</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="4e188-142">Direct3D では、ビューを使ってテクスチャ リソースにアクセスします。ビューは、メモリ内のリソースをハードウェアで解釈するためのメカニズムです。</span><span class="sxs-lookup"><span data-stu-id="4e188-142">In Direct3D, texture resources are accessed with a view, which is a mechanism for hardware interpretation of a resource in memory.</span></span> <span data-ttu-id="4e188-143">ビューを使うと、アプリケーションで要求される表現で、特定のパイプライン ステージから必要な<a href="resource-types.md">サブリソース</a>だけにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="4e188-143">A view allows a particular pipeline stage to access only the <a href="resource-types.md">subresources</a> it needs, in the representation desired by the application.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="4e188-144"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="4e188-144"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="4e188-145">座標系</span><span class="sxs-lookup"><span data-stu-id="4e188-145">Coordinate systems</span></span>](coordinate-systems.md)

[<span data-ttu-id="4e188-146">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="4e188-146">Direct3D Graphics Learning Guide</span></span>](index.md)

[<span data-ttu-id="4e188-147">浮動小数点の規則</span><span class="sxs-lookup"><span data-stu-id="4e188-147">Floating-point rules</span></span>](floating-point-rules.md)

[<span data-ttu-id="4e188-148">データ型の変換</span><span class="sxs-lookup"><span data-stu-id="4e188-148">Data type conversion</span></span>](data-type-conversion.md)
