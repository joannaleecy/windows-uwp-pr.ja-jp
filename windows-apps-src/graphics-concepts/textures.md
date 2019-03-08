---
title: テクスチャ
description: テクスチャは、コンピューターにより生成された 3D 画像でリアルさを出すための強力なツールです。 Direct3D は広範囲のテクスチャリング機能セットをサポートし、高度なテクスチャリング手法に簡単にアクセスできる方法を開発者に提供します。
ms.assetid: B9E85C9E-B779-4852-9166-6FA2240B7046
keywords:
- テクスチャ
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 81d77b262cc77c23d859cf76227a34bc72b15b96
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593007"
---
# <a name="textures"></a><span data-ttu-id="f2b4c-105">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="f2b4c-105">Textures</span></span>


<span data-ttu-id="f2b4c-106">テクスチャは、コンピューターにより生成された 3D 画像でリアルさを出すための強力なツールです。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-106">Textures are a powerful tool in creating realism in computer-generated 3D images.</span></span> <span data-ttu-id="f2b4c-107">Direct3D は広範囲のテクスチャリング機能セットをサポートし、高度なテクスチャリング手法に簡単にアクセスできる方法を開発者に提供します。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-107">Direct3D supports an extensive texturing feature set, providing developers with easy access to advanced texturing techniques.</span></span>

<span data-ttu-id="f2b4c-108">パフォーマンス向上のために、動的テクスチャの使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-108">For improved performance, consider using dynamic textures.</span></span> <span data-ttu-id="f2b4c-109">動的テクスチャは、各フレームでロックしたり、書き込んだり、ロックを解除したりできます。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-109">A dynamic texture can be locked, written to, and unlocked each frame.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="f2b4c-110"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="f2b4c-110"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="f2b4c-111">トピック</span><span class="sxs-lookup"><span data-stu-id="f2b4c-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="f2b4c-112">説明</span><span class="sxs-lookup"><span data-stu-id="f2b4c-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f2b4c-113"><a href="introduction-to-textures.md">テクスチャの概要</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-113"><a href="introduction-to-textures.md">Introduction to textures</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-114">テクスチャ リソースはテクセルを保存するデータ構造で、読み書きできるテクスチャの最小単位です。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-114">A texture resource is a data structure to store texels, which are the smallest unit of a texture that can be read or written to.</span></span> <span data-ttu-id="f2b4c-115">テクスチャをシェーダーで読み取るとき、テクスチャ サンプラーでフィルター処理することができます。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-115">When the texture is read by a shader, it can be filtered by texture samplers.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f2b4c-116"><a href="basic-texturing-concepts.md">テクスチャの基本的な概念</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-116"><a href="basic-texturing-concepts.md">Basic texturing concepts</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-117">コンピューターで作成された初期の 3D 画像は、当時は高度な技術でしたが、ツルツルのプラスチックのような外観になりがちでした。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-117">Early computer-generated 3D images, although generally advanced for their time, tended to have a shiny plastic look.</span></span> <span data-ttu-id="f2b4c-118">それらには、3D オブジェクトにリアルで複雑な外観を与える傷や割れ、指紋、汚れなどがありませんでした。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-118">They lacked the types of markings-such as scuffs, cracks, fingerprints, and smudges-that give 3D objects realistic visual complexity.</span></span> <span data-ttu-id="f2b4c-119">テクスチャは、コンピューターで作成された 3D 画像のリアルさを向上させるための一般的な手法になってきました。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-119">Textures have become popular for enhancing the realism of computer-generated 3D images.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f2b4c-120"><a href="texture-addressing-modes.md">テクスチャのアドレッシング モード</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-120"><a href="texture-addressing-modes.md">Texture addressing modes</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-121">Direct3D アプリケーションは、任意のプリミティブの頂点テクスチャ座標を割り当てることができます。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-121">Your Direct3D application can assign texture coordinates to any vertex of any primitive.</span></span> <span data-ttu-id="f2b4c-122">通常、頂点に割り当てるテクスチャ座標 (u, v) は 0.0 ～ 1.0 (両端含む) の範囲です。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-122">Typically, the u- and v-texture coordinates that you assign to a vertex are in the range of 0.0 to 1.0 inclusive.</span></span> <span data-ttu-id="f2b4c-123">ただし、その範囲外のテクスチャ座標を割り当てることで、テクスチャリングの特殊効果を作成できます。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-123">However, by assigning texture coordinates outside that range, you can create certain special texturing effects.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f2b4c-124"><a href="texture-filtering.md">テクスチャ フィルタ リング</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-124"><a href="texture-filtering.md">Texture filtering</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-125">プリミティブが 3D プリミティブから 2D 画面へのマッピングによってレンダリングされるときに、テクスチャ フィルタリングによって、プリミティブの 2D レンダリングされた画像の各ピクセルの色が生成されます。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-125">Texture filtering produces a color for each pixel in the primitive's 2D rendered image when a primitive is rendered by mapping a 3D primitive onto a 2D screen.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f2b4c-126"><a href="texture-resources.md">テクスチャのリソース</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-126"><a href="texture-resources.md">Texture resources</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-127">テクスチャは、レンダリングに使われるリソースの一種です。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-127">Textures are a type of resource used for rendering.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f2b4c-128"><a href="texture-wrapping.md">テクスチャのラッピング</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-128"><a href="texture-wrapping.md">Texture wrapping</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-129">テクスチャの折り返しによって、Direct3D が各頂点に指定されたテクスチャ座標を使って、テクスチャが適用された多角形をラスタライズする際の基本的な方法が変更されます。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-129">Texture wrapping changes the basic way that Direct3D rasterizes textured polygons using the texture coordinates specified for each vertex.</span></span> <span data-ttu-id="f2b4c-130">多角形をラスタライズするとき、システムは多角形の各頂点のテクスチャ座標の間を補間して、多角形の各ピクセルに使うテクセルを決定します。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-130">While rasterizing a polygon, the system interpolates between the texture coordinates at each of the polygon's vertices to determine the texels that should be used for every pixel of the polygon.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f2b4c-131"><a href="texture-blending.md">テクスチャのブレンド</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-131"><a href="texture-blending.md">Texture blending</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-132">Direct3D では、1 つのパスでプリミティブに 8 個までのテクスチャをブレンドできます。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-132">Direct3D can blend as many as eight textures onto primitives in a single pass.</span></span> <span data-ttu-id="f2b4c-133">複数のテクスチャ ブレンドを使うと、Direct3D アプリケーションのフレーム レートが大幅に増えることがあります。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-133">The use of multiple texture blending can profoundly increase the frame rate of a Direct3D application.</span></span> <span data-ttu-id="f2b4c-134">アプリケーションは複数のテクスチャを使って、テクスチャ、シャドウ、鏡面反射、拡散光、およびその他の特殊効果を 1 つのパスで適用します。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-134">An application employs multiple texture blending to apply textures, shadows, specular lighting, diffuse lighting, and other special effects in a single pass.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="f2b4c-135"><a href="light-mapping-with-textures.md">テクスチャのライトのマッピング</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-135"><a href="light-mapping-with-textures.md">Light mapping with textures</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-136">ライト マップは、3D シーン内の照明に関する情報を含むテクスチャまたはテクスチャのグループです。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-136">A light map is a texture or group of textures that contains information about lighting in a 3D scene.</span></span> <span data-ttu-id="f2b4c-137">ライト マップは、ライトおよびシャドウの領域をプリミティブにマップします。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-137">Light maps map areas of light and shadow onto primitives.</span></span> <span data-ttu-id="f2b4c-138">マルチパスおよび複数テクスチャ ブレンドにより、アプリケーションがシェーディング手法より現実的な外観によってシーンをレンダリングできるようになります。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-138">Multipass and multiple texture blending enable your application to render scenes with a more realistic appearance than shading techniques.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="f2b4c-139"><a href="compressed-texture-resources.md">圧縮されたテクスチャのリソース</a></span><span class="sxs-lookup"><span data-stu-id="f2b4c-139"><a href="compressed-texture-resources.md">Compressed texture resources</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="f2b4c-140">テクスチャ マップとは、視覚的な詳細を追加するために 3 次元形状で描画された、デジタル画像です。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-140">Texture maps are digitized images drawn on three-dimensional shapes to add visual detail.</span></span> <span data-ttu-id="f2b4c-141">テクスチャ マップは、ラスター化時に 3D の形状にマッピングされます。このプロセスではシステム バスとメモリの両方を大量に消費することがあります。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-141">They are mapped into these shapes during rasterization, and the process can consume large amounts of both the system bus and memory.</span></span> <span data-ttu-id="f2b4c-142">テクスチャによって消費されるメモリ量を減らすために、Direct3D ではテクスチャ サーフェスの圧縮がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-142">To reduce the amount of memory consumed by textures, Direct3D supports the compression of texture surfaces.</span></span> <span data-ttu-id="f2b4c-143">Direct3D デバイスの中には、圧縮テクスチャ サーフェスを標準でサポートするものもあります。</span><span class="sxs-lookup"><span data-stu-id="f2b4c-143">Some Direct3D devices support compressed texture surfaces natively.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="f2b4c-144"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="f2b4c-144"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="f2b4c-145">Direct3D グラフィックス学習ガイド</span><span class="sxs-lookup"><span data-stu-id="f2b4c-145">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




