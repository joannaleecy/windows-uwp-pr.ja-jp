---
title: ビュー
description: "\"ビュー\" という用語は、\"要求された形式のデータ\" という意味で使われます。 たとえば、定数バッファー ビュー (CBV) は、適切な形式の定数バッファー データを表します。 このセクションでは、最もよく使われる便利なビューについて説明します。"
ms.assetid: 0C7FB99F-7391-472F-BA53-576888DFC171
keywords:
- ビュー
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: df106a400a7ba8c8f94aa6dd35325aabacd36eca
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8194781"
---
# <a name="views"></a><span data-ttu-id="d6f29-106">ビュー</span><span class="sxs-lookup"><span data-stu-id="d6f29-106">Views</span></span>


<span data-ttu-id="d6f29-107">"ビュー" という用語は、"要求された形式のデータ" という意味で使われます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-107">The term "view" is used to mean "data in the required format".</span></span> <span data-ttu-id="d6f29-108">たとえば、定数バッファー ビュー (CBV) は、適切な形式の定数バッファー データを表します。</span><span class="sxs-lookup"><span data-stu-id="d6f29-108">For example, a Constant Buffer View (CBV) would be constant buffer data correctly formatted.</span></span> <span data-ttu-id="d6f29-109">このセクションでは、最もよく使われる便利なビューについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d6f29-109">This section describes the most common and useful views.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="d6f29-110"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="d6f29-110"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="d6f29-111">トピック</span><span class="sxs-lookup"><span data-stu-id="d6f29-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="d6f29-112">説明</span><span class="sxs-lookup"><span data-stu-id="d6f29-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="constant-buffer-view--cbv-.md"><span data-ttu-id="d6f29-113">定数バッファー ビュー (CBV)</span><span class="sxs-lookup"><span data-stu-id="d6f29-113">Constant buffer view (CBV)</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-114">定数バッファーには、シェーダーの定数データが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-114">Constant buffers contain shader constant data.</span></span> <span data-ttu-id="d6f29-115">これらの価値は、データを変更する必要があるまでデータが存続し、任意の GPU シェーダーからアクセスできることにあります。</span><span class="sxs-lookup"><span data-stu-id="d6f29-115">The value of them is that the data persists, and can be accessed by any GPU shader, until it is necessary to change the data.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="vertex-buffer-view--vbv-.md"><span data-ttu-id="d6f29-116">頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)</span><span class="sxs-lookup"><span data-stu-id="d6f29-116">Vertex buffer view (VBV) and Index buffer view (IBV)</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-117">頂点バッファーには、頂点のリストのデータが保持されます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-117">A vertex buffer holds data for a list of vertices.</span></span> <span data-ttu-id="d6f29-118">各頂点のデータには、位置、色、法線ベクトル、テクスチャ座標などを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-118">The data for each vertex can include position, color, normal vector, texture co-ordinates, and so on.</span></span> <span data-ttu-id="d6f29-119">インデックス バッファーには、頂点バッファーへの整数インデックス (オフセット) が保持されます。インデックス バッファーは、頂点の完全なリストのサブセットから成るオブジェクトを定義してレンダリングするために使われます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-119">An index buffer holds integer indexes (offsets) into a vertex buffer, and is used to define and render an object made up of a subset of the full list of vertices.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="shader-resource-view--srv-.md"><span data-ttu-id="d6f29-120">シェーダー リソース ビュー (SRV) と順序指定されていないアクセス ビュー (UAV)</span><span class="sxs-lookup"><span data-stu-id="d6f29-120">Shader resource view (SRV) and Unordered Access view (UAV)</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-121">シェーダー リソース ビューは、通常、シェーダーがアクセスできる形式でテクスチャをラップします。</span><span class="sxs-lookup"><span data-stu-id="d6f29-121">Shader resource views typically wrap textures in a format that the shaders can access them.</span></span> <span data-ttu-id="d6f29-122">順序指定されていないアクセス ビューも同様の機能を提供しますが、任意の順序でテクスチャ (またはその他のリソース) の読み取りや書き込みを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-122">An unordered access view provides similar functionality, but enables the reading and writing to the texture (or other resource) in any order.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="sampler.md"><span data-ttu-id="d6f29-123">サンプラー</span><span class="sxs-lookup"><span data-stu-id="d6f29-123">Sampler</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-124">テクスチャまたはその他のリソースから入力値を読み取るプロセスをサンプリングと呼びます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-124">Sampling is the process of reading input values from a texture, or other resource.</span></span> <span data-ttu-id="d6f29-125">&quot;サンプラー&quot; は、リソースからの読み取りを行う任意のオブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="d6f29-125">A &quot;sampler&quot; is any object that reads from resources.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="render-target-view--rtv-.md"><span data-ttu-id="d6f29-126">レンダー ターゲット ビュー (RTV)</span><span class="sxs-lookup"><span data-stu-id="d6f29-126">Render target view (RTV)</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-127">レンダー ターゲットは、画面にレンダリングされるバック バッファーではなく、一時的な中間バッファーにシーンがレンダリングできるようにします。</span><span class="sxs-lookup"><span data-stu-id="d6f29-127">Render targets enable a scene to be rendered to a temporary intermediate buffer, rather than to the back buffer to be rendered to the screen.</span></span> <span data-ttu-id="d6f29-128">この機能を使うと複雑なシーンを実現できます。たとえば、グラフィックス パイプライン内で反射テクスチャなどの用途に使われるシーンをレンダリングしたり、レンダリング前にシーンにピクセル シェーダー効果を追加したりできます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-128">This feature enables use of the complex scene that might be rendered, perhaps as a reflection texture or other purpose within the graphics pipeline, or perhaps to add additional pixel shader effects to the scene before rendering.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="depth-stencil-view--dsv-.md"><span data-ttu-id="d6f29-129">深度ステンシル ビュー (DSV)</span><span class="sxs-lookup"><span data-stu-id="d6f29-129">Depth stencil view (DSV)</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-130">深度ステンシル ビューは、深度とステンシルの情報を保持するための形式とバッファーを提供します。</span><span class="sxs-lookup"><span data-stu-id="d6f29-130">A depth stencil view provides the format and buffer for holding depth and stencil information.</span></span> <span data-ttu-id="d6f29-131">深度バッファーは、近くにあるオブジェクトによって視界から遮られる、ビューアーには見えないピクセルの描画を省くために使われます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-131">The depth buffer is used to cull the drawing of pixels that would be invisible to the viewer as they are occluded from view by a closer object.</span></span> <span data-ttu-id="d6f29-132">ステンシル バッファーを使うと、定義された図形以外のすべての描画を省略することができます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-132">The stencil buffer can be used to cull all drawing outside of a defined shape.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="stream-output-view--sov-.md"><span data-ttu-id="d6f29-133">ストリーム出力ビュー (SOV)</span><span class="sxs-lookup"><span data-stu-id="d6f29-133">Stream output view (SOV)</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-134">ストリーム出力ビューを使うと、頂点、テセレーション、ジオメトリ シェーダーによって生成された頂点情報を、後で利用できるようにアプリケーションに戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-134">Stream output views enable the vertex information that the vertex, tessellation and geometry shaders have come up with to be streamed back out to the application for further use.</span></span> <span data-ttu-id="d6f29-135">たとえば、これらのシェーダーによってゆがめられたオブジェクトをアプリケーションに書き戻して、より正確な入力を物理エンジンや他のエンジンに提供できます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-135">For example, an object that has been distorted by these shaders could be written back to the application to provide more accurate input to a physics or other engine.</span></span> <span data-ttu-id="d6f29-136">ただし実際には、ストリーム出力ビューは、グラフィックス パイプラインの機能の中でも使われることが少ない機能です。</span><span class="sxs-lookup"><span data-stu-id="d6f29-136">In practice though, stream output views are an infrequently used feature of the graphics pipeline.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="rasterizer-ordered-view--rov-.md"><span data-ttu-id="d6f29-137">ラスタライザー順序指定ビュー (ROV)</span><span class="sxs-lookup"><span data-stu-id="d6f29-137">Rasterizer ordered view (ROV)</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="d6f29-138">ラスタライザー順序指定ビューを使うと、深度バッファーの一部の制約に対処できます。特に、透明度を含む複数のテクスチャがあり、それらのすべてを同じピクセルに適用する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="d6f29-138">Rasterizer ordered views enable some of the limitations of a depth buffer to be addressed, in particular having multiple textures containing transparency all applying to the same pixels.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="d6f29-139"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="d6f29-139"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="d6f29-140">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="d6f29-140">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




