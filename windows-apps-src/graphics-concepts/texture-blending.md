---
title: テクスチャ ブレンド
description: Direct3D では、1 つのパスでプリミティブに 8 個までのテクスチャをブレンドできます。
ms.assetid: 9AD388FA-B2B9-44A9-B73E-EDBD7357ACFB
keywords:
- テクスチャ ブレンド
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: c40c7d3bd080bd927fc52cb7f740e1dc4a6358c0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620807"
---
# <a name="texture-blending"></a><span data-ttu-id="c7283-104">テクスチャ ブレンド</span><span class="sxs-lookup"><span data-stu-id="c7283-104">Texture blending</span></span>


<span data-ttu-id="c7283-105">Direct3D では、1 つのパスでプリミティブに 8 個までのテクスチャをブレンドできます。</span><span class="sxs-lookup"><span data-stu-id="c7283-105">Direct3D can blend as many as eight textures onto primitives in a single pass.</span></span> <span data-ttu-id="c7283-106">複数のテクスチャ ブレンドを使うと、Direct3D アプリケーションのフレーム レートが大幅に増えることがあります。</span><span class="sxs-lookup"><span data-stu-id="c7283-106">The use of multiple texture blending can profoundly increase the frame rate of a Direct3D application.</span></span> <span data-ttu-id="c7283-107">アプリケーションは複数のテクスチャを使って、テクスチャ、シャドウ、鏡面反射、拡散光、およびその他の特殊効果を 1 つのパスで適用します。</span><span class="sxs-lookup"><span data-stu-id="c7283-107">An application employs multiple texture blending to apply textures, shadows, specular lighting, diffuse lighting, and other special effects in a single pass.</span></span>

<span data-ttu-id="c7283-108">テクスチャ ブレンドを使用するには、最初にアプリケーションでユーザーのハードウェアがテクスチャ ブレンドをサポートしているかどうかを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7283-108">To use texture blending, your application should first check if the user's hardware supports it.</span></span>

## <a name="span-idtexture-stages-and-the-texture-blending-cascadespanspan-idtexture-stages-and-the-texture-blending-cascadespanspan-idtexture-stages-and-the-texture-blending-cascadespantexture-stages-and-the-texture-blending-cascade"></a><span data-ttu-id="c7283-109"><span id="Texture-Stages-and-the-Texture-Blending-Cascade"></span><span id="texture-stages-and-the-texture-blending-cascade"></span><span id="TEXTURE-STAGES-AND-THE-TEXTURE-BLENDING-CASCADE"></span>テクスチャのステージおよびテクスチャのブレンド cascade</span><span class="sxs-lookup"><span data-stu-id="c7283-109"><span id="Texture-Stages-and-the-Texture-Blending-Cascade"></span><span id="texture-stages-and-the-texture-blending-cascade"></span><span id="TEXTURE-STAGES-AND-THE-TEXTURE-BLENDING-CASCADE"></span>Texture stages and the texture blending cascade</span></span>


<span data-ttu-id="c7283-110">Direct3D では、テクスチャ ステージの使用によって、単一パスでの複数のテクスチャ ブレンドがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="c7283-110">Direct3D supports single-pass multiple texture blending through the use of texture stages.</span></span> <span data-ttu-id="c7283-111">テクスチャ ステージは 2 つの引数を受け取り、それらに対してブレンド処理を実行して、その後の処理またはラスター化に結果を渡します。</span><span class="sxs-lookup"><span data-stu-id="c7283-111">A texture stage takes two arguments and performs a blending operation on them, passing on the result for further processing or for rasterization.</span></span> <span data-ttu-id="c7283-112">テクスチャ ステージを具体的に表すと、次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="c7283-112">You can visualize a texture stage as shown in the following diagram.</span></span>

![テクスチャ ステージの図](images/texstg.png)

<span data-ttu-id="c7283-114">上の図のように、テクスチャ ステージは、指定された演算子を使用して、2 つの引数をブレンドします。</span><span class="sxs-lookup"><span data-stu-id="c7283-114">As the preceding diagram shows, texture stages blend two arguments by using a specified operator.</span></span> <span data-ttu-id="c7283-115">一般的な演算には、引数のカラーまたはアルファ成分の単純な乗算や加算がありますが、実際にサポートされている演算は 24 を超えます。</span><span class="sxs-lookup"><span data-stu-id="c7283-115">Common operations include simple modulation or addition of the color or alpha components of the arguments, but more than two dozen operations are supported.</span></span> <span data-ttu-id="c7283-116">ステージの引数には、関連付けられたテクスチャ、反復処理されるカラーまたはアルファ (グーロー シェーディング時に反復処理)、任意のカラーとアルファ、以前のテクスチャ ステージの結果などがあります。</span><span class="sxs-lookup"><span data-stu-id="c7283-116">The arguments for a stage can be an associated texture, the iterated color or alpha (iterated during Gouraud shading), arbitrary color and alpha, or the result from the previous texture stage.</span></span>

<span data-ttu-id="c7283-117">**注**   Direct3D には色のアルファ ブレンドのブレンドが区別されます。</span><span class="sxs-lookup"><span data-stu-id="c7283-117">**Note**   Direct3D distinguishes color blending from alpha blending.</span></span> <span data-ttu-id="c7283-118">アプリケーションでは、カラーとアルファについて個々にブレンドの演算と引数を設定し、これらの設定の結果は互いに独立しています。</span><span class="sxs-lookup"><span data-stu-id="c7283-118">Applications set blending operations and arguments for color and alpha individually, and the results of those settings are independent of one another.</span></span>

 

<span data-ttu-id="c7283-119">複数のブレンド ステージで、引数と演算を組み合わせて使用することによって、単純なフローベースのブレンド言語を定義できます。</span><span class="sxs-lookup"><span data-stu-id="c7283-119">The combination of arguments and operations used by multiple blending stages define a simple flow-based blending language.</span></span> <span data-ttu-id="c7283-120">1 つのステージの結果は別のステージに移行し、さらにそのステージから次のステージに移行します。</span><span class="sxs-lookup"><span data-stu-id="c7283-120">The results from one stage flow down to another stage, from that stage to the next, and so on.</span></span> <span data-ttu-id="c7283-121">その後も同様に続きます。結果が、ステージからステージに渡され、最終的にポリゴンでラスター化される概念を、一般にテクスチャ ブレンディング カスケードと呼びます。</span><span class="sxs-lookup"><span data-stu-id="c7283-121">The concept of results flowing from stage to stage to eventually be rasterized on a polygon is often called the texture blending cascade.</span></span> <span data-ttu-id="c7283-122">次の図は、個々のテクスチャ ステージがテクスチャ ブレンディング カスケードを構成しているようすを示しています。</span><span class="sxs-lookup"><span data-stu-id="c7283-122">The following diagram shows how individual texture stages make up the texture blending cascade.</span></span>

![テクスチャ ブレンディング カスケードのテクスチャ ステージの図](images/tcascade.png)

<span data-ttu-id="c7283-124">デバイス内の各ステージには、ゼロから始まるインデックスがあります。</span><span class="sxs-lookup"><span data-stu-id="c7283-124">Each stage in a device has a zero-based index.</span></span> <span data-ttu-id="c7283-125">Direct3D では、最大 8 つのブレンド ステージを使用することができますが、必ずデバイスの能力をチェックして、現在のハードウェアでサポートされるステージの数を確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c7283-125">Direct3D allows up to eight blending stages, although you should always check device capabilities to determine how many stages the current hardware supports.</span></span> <span data-ttu-id="c7283-126">最初のブレンド ステージはインデックス 0 にあり、2 番目のブレンド ステージはインデックス 1 にあり、その後、インデックス 7 まで同様に続きます。</span><span class="sxs-lookup"><span data-stu-id="c7283-126">The first blending stage is at index 0, the second is at 1, and so on, up to index 7.</span></span> <span data-ttu-id="c7283-127">システムは、インデックスの昇順でステージをブレンドします。</span><span class="sxs-lookup"><span data-stu-id="c7283-127">The system blends stages in increasing index order.</span></span>

<span data-ttu-id="c7283-128">ステージは必要な数だけ使用してください。未使用のブレンド ステージは既定で無効になります。</span><span class="sxs-lookup"><span data-stu-id="c7283-128">Use only the number of stages you need; the unused blending stages are disabled by default.</span></span> <span data-ttu-id="c7283-129">つまり、アプリケーションで最初の 2 つのステージのみを使用する場合、演算と引数の設定が必要なのは、ステージ 0 と 1 のみです。</span><span class="sxs-lookup"><span data-stu-id="c7283-129">So, if your application only uses the first two stages, it need only set operations and arguments for stage 0 and 1.</span></span> <span data-ttu-id="c7283-130">システムでは 2 つのステージがブレンドされ、無効なステージは無視されます。</span><span class="sxs-lookup"><span data-stu-id="c7283-130">The system blends the two stages, and ignores the disabled stages.</span></span>

<span data-ttu-id="c7283-131">4 つのステージを使用するオブジェクトや、2 つのステージのみを使用するオブジェクトなど、状況に応じてアプリケーションで使用するステージの数が変わる場合は、以前に使用したすべてのステージを明示的に無効にする必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c7283-131">If your application varies the number of stages it uses for different situations - such as four stages for some objects, and only two for others - you don't need to explicitly disable all previously used stages.</span></span> <span data-ttu-id="c7283-132">1 つのオプションとして、最初の未使用のステージについてカラー処理を無効にすると、それよりもインデックスが大きいステージはすべて適用されなくなります。</span><span class="sxs-lookup"><span data-stu-id="c7283-132">One option is to disable the color operation for the first unused stage, then all stages with a higher index will not be applied.</span></span> <span data-ttu-id="c7283-133">別のオプションとして、最初のテクスチャ ステージ (ステージ 0) のカラー処理を無効な状態に設定すると、テクスチャ マッピングをまとめて無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="c7283-133">Another option is to disable texture mapping altogether by setting the color operation for the first texture stage (stage 0) to a disabled state.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="c7283-134"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="c7283-134"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="c7283-135">トピック</span><span class="sxs-lookup"><span data-stu-id="c7283-135">Topic</span></span></th>
<th align="left"><span data-ttu-id="c7283-136">説明</span><span class="sxs-lookup"><span data-stu-id="c7283-136">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="c7283-137"><a href="blending-stages.md">ステージのブレンド</a></span><span class="sxs-lookup"><span data-stu-id="c7283-137"><a href="blending-stages.md">Blending stages</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="c7283-138">ブレンド ステージは、テクスチャ操作のセットと、テクスチャのブレンド方法を定義する引数です。</span><span class="sxs-lookup"><span data-stu-id="c7283-138">A blending stage is a set of texture operations and their arguments that define how textures are blended.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="c7283-139"><a href="multipass-texture-blending.md">マルチパスのテクスチャのブレンド</a></span><span class="sxs-lookup"><span data-stu-id="c7283-139"><a href="multipass-texture-blending.md">Multipass texture blending</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="c7283-140">Direct3D アプリケーションでは、複数のレンダリング パスでさまざまなテクスチャを 1 つのプリミティブに適用することで、多彩な特殊効果を実現することができます。</span><span class="sxs-lookup"><span data-stu-id="c7283-140">Direct3D applications can achieve numerous special effects by applying various textures to a primitive over the course of multiple rendering passes.</span></span> <span data-ttu-id="c7283-141">これは、一般に<em>マルチパス テクスチャ ブレンド</em>と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="c7283-141">The common term for this is <em>multipass texture blending</em>.</span></span> <span data-ttu-id="c7283-142">通常、マルチパス テクスチャ ブレンドは、さまざまなテクスチャから複数のカラーを適用して、複雑なライティング モデルやシェーディング モデルの効果をエミュレートするために使用されます。</span><span class="sxs-lookup"><span data-stu-id="c7283-142">A typical use for multipass texture blending is to emulate the effects of complex lighting and shading models by applying multiple colors from several different textures.</span></span> <span data-ttu-id="c7283-143">このような適用は<em>ライト マッピング</em>と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="c7283-143">One such application is called <em>light mapping</em>.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="c7283-144"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="c7283-144"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="c7283-145">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="c7283-145">Textures</span></span>](textures.md)

 

 




