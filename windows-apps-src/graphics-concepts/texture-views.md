---
title: テクスチャ ビュー
description: Direct3D では、ビューを使ってテクスチャ リソースにアクセスします。ビューは、メモリ内のリソースをハードウェアで解釈するためのメカニズムです。
ms.assetid: 18DABFCE-8A36-4C4E-B08E-10428B05D701
keywords:
- テクスチャ ビュー
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e9167db4648dd193acaff0a224f3378486d171ad
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8750783"
---
# <a name="texture-views"></a><span data-ttu-id="10ca9-104">テクスチャ ビュー</span><span class="sxs-lookup"><span data-stu-id="10ca9-104">Texture views</span></span>


<span data-ttu-id="10ca9-105">Direct3D では、ビューを使ってテクスチャ リソースにアクセスします。ビューは、メモリ内のリソースをハードウェアで解釈するためのメカニズムです。</span><span class="sxs-lookup"><span data-stu-id="10ca9-105">In Direct3D, texture resources are accessed with a view, which is a mechanism for hardware interpretation of a resource in memory.</span></span> <span data-ttu-id="10ca9-106">ビューを使うと、アプリケーションで要求される表現で、特定のパイプライン ステージから必要な[サブリソース](resource-types.md)だけにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="10ca9-106">A view allows a particular pipeline stage to access only the [subresources](resource-types.md) it needs, in the representation desired by the application.</span></span>

<span data-ttu-id="10ca9-107">ビューは、型指定なしのリソースの概念をサポートします。</span><span class="sxs-lookup"><span data-stu-id="10ca9-107">A view supports the notion of a typeless resource.</span></span> <span data-ttu-id="10ca9-108">型指定なしのリソースは、特定のサイズで作成され、特定のデータ型ではないリソースです。</span><span class="sxs-lookup"><span data-stu-id="10ca9-108">A typeless resource is a resource created with a specific size but not a specific data type.</span></span> <span data-ttu-id="10ca9-109">データは、パイプラインにバインドされるときに動的に解釈されます。</span><span class="sxs-lookup"><span data-stu-id="10ca9-109">The data is interpreted dynamically when it is bound to the pipeline.</span></span>

<span data-ttu-id="10ca9-110">次の図は、2D テクスチャ配列のシェーダー リソース ビューを作成することで、その配列をシェーダー リソースとして 6 つのテクスチャとバインドする例を示しています。</span><span class="sxs-lookup"><span data-stu-id="10ca9-110">The following illustration shows an example of binding a 2D texture array with 6 textures as a shader resource by creating a shader resource view for it.</span></span> <span data-ttu-id="10ca9-111">その後、リソースはテクスチャの配列として扱われます。</span><span class="sxs-lookup"><span data-stu-id="10ca9-111">The resource is then addressed as an array of textures.</span></span> <span data-ttu-id="10ca9-112">(注: サブリソースを入力および出力の両方で、パイプラインに同時にバインドすることはできません)。</span><span class="sxs-lookup"><span data-stu-id="10ca9-112">(Note: a subresource cannot be bound as both input and output to the pipeline simultaneously.)</span></span>

![6 つのテクスチャを含むテクスチャ配列の図](images/d3d10-cube-texture-faces.png)

<span data-ttu-id="10ca9-114">レンダー ターゲットとしてを 2D テクスチャ配列を使うと、リソースは複数のミップマップ レベル (この例では 3 レベル) の 2D テクスチャ (この例では 6 個) の配列として表示することができます。</span><span class="sxs-lookup"><span data-stu-id="10ca9-114">When using a 2D texture array as a render target, the resource can be viewed as an array of 2D textures (6 in this example) with mipmap levels (3 in this example).</span></span>

<span data-ttu-id="10ca9-115">CreateRenderTargetView を呼び出して、レンダー ターゲットのビュー オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="10ca9-115">Create a view object for a render target by calling CreateRenderTargetView.</span></span> <span data-ttu-id="10ca9-116">そして、OMSetRenderTargets を呼び出して、レンダー ターゲット ビューをパイプラインに設定します。</span><span class="sxs-lookup"><span data-stu-id="10ca9-116">Then call OMSetRenderTargets to set the render target view to the pipeline.</span></span> <span data-ttu-id="10ca9-117">Draw を呼び出し、RenderTargetArrayIndex を使用して配列内の適切なテクスチャへのインデックスを設定することで、レンダー ターゲットにレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="10ca9-117">Render into the render targets by calling Draw and using the RenderTargetArrayIndex to index into the proper texture in the array.</span></span> <span data-ttu-id="10ca9-118">サブリソース (ミップマップ レベル、配列インデックスの組み合わせ) を使用して、サブリソースの任意の配列にバインドできます。</span><span class="sxs-lookup"><span data-stu-id="10ca9-118">You can use a subresource (a mipmap level, array index combination) to bind to any array of subresources.</span></span> <span data-ttu-id="10ca9-119">次の図に示すように、2 番目のミップマップ レベルにバインドし、その特定のミップマップ レベルだけを更新することもできます。</span><span class="sxs-lookup"><span data-stu-id="10ca9-119">So you could bind to the second mipmap level and only update this particular mipmap level if you wanted, as in the following illustration.</span></span>

![テクスチャ配列の 2 番目のミップマップ レベルにのみバインドしている図](images/d3d10-cube-texture-faces-subresource.png)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="10ca9-121"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="10ca9-121"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="10ca9-122">リソース</span><span class="sxs-lookup"><span data-stu-id="10ca9-122">Resources</span></span>](resources.md)

 

 




