---
title: テクスチャでのライト マッピング
description: ライト マップは、3D シーン内の照明に関する情報を含むテクスチャまたはテクスチャのグループです。
ms.assetid: 5C7518D2-AC92-4A97-B7AF-4469D213D7BD
keywords:
- テクスチャでのライト マッピング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9bbb723cc039d6ecca8a5ebcd30ef03559076934
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5831319"
---
# <a name="light-mapping-with-textures"></a><span data-ttu-id="e9014-104">テクスチャでのライト マッピング</span><span class="sxs-lookup"><span data-stu-id="e9014-104">Light mapping with textures</span></span>


<span data-ttu-id="e9014-105">ライト マップは、3D シーンの照明に関する情報が含まれるテクスチャまたはテクスチャのグループです。</span><span class="sxs-lookup"><span data-stu-id="e9014-105">A light map is a texture or group of textures that contains information about lighting in a 3D scene.</span></span> <span data-ttu-id="e9014-106">ライト マップは、ライトおよびシャドウの領域をプリミティブにマップします。</span><span class="sxs-lookup"><span data-stu-id="e9014-106">Light maps map areas of light and shadow onto primitives.</span></span> <span data-ttu-id="e9014-107">マルチパスおよび複数テクスチャ ブレンドにより、アプリケーションがシェーディング手法より現実的な外観によってシーンをレンダリングできるようになります。</span><span class="sxs-lookup"><span data-stu-id="e9014-107">Multipass and multiple texture blending enable your application to render scenes with a more realistic appearance than shading techniques.</span></span>

<span data-ttu-id="e9014-108">アプリケーションが 3D シーンを現実的にレンダリングするには、光源がシーンの外観に与える効果を考慮に入れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9014-108">For an application to realistically render a 3D scene, it must take into account the effect that light sources have on the appearance of the scene.</span></span> <span data-ttu-id="e9014-109">フラットおよびグロー シェーディングなどの手法は、この点においては貴重なツールですが、ニーズを満たすのには不十分な可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e9014-109">Although techniques such as flat and Gouraud shading are valuable tools in this respect, they can be insufficient for your needs.</span></span> <span data-ttu-id="e9014-110">Direct3D は、マルチパスおよび複数テクスチャ ブレンドをサポートします。</span><span class="sxs-lookup"><span data-stu-id="e9014-110">Direct3D supports multipass and multiple texture blending.</span></span> <span data-ttu-id="e9014-111">これらの機能により、アプリケーションがシェーディング手法だけを使ってレンダリングされたシーンより現実的な外観によってシーンをレンダリングできるようになります。</span><span class="sxs-lookup"><span data-stu-id="e9014-111">These capabilities enable your application to render scenes with a more realistic appearance than scenes rendered with shading techniques alone.</span></span> <span data-ttu-id="e9014-112">1 つ以上のライト マップを適用することにより、アプリケーションは光と影の領域をそのプリミティブにマップできます。</span><span class="sxs-lookup"><span data-stu-id="e9014-112">By applying one or more light maps, your application can map areas of light and shadow onto its primitives.</span></span>

<span data-ttu-id="e9014-113">ライト マップは、3D シーン内の照明に関する情報を含むテクスチャまたはテクスチャのグループです。</span><span class="sxs-lookup"><span data-stu-id="e9014-113">A light map is a texture or group of textures that contains information about lighting in a 3D scene.</span></span> <span data-ttu-id="e9014-114">照明情報は、ライト マップのアルファ値、色値、またはその両方に格納できます。</span><span class="sxs-lookup"><span data-stu-id="e9014-114">You can store the lighting information in the alpha values of the light map, in the color values, or in both.</span></span>

<span data-ttu-id="e9014-115">マルチパス テクスチャ ブレンドを使ってライト マップを実装した場合、アプリケーションはライト マップを最初のパスのプリミティブにマップします。</span><span class="sxs-lookup"><span data-stu-id="e9014-115">If you implement light mapping using multipass texture blending, your application should render the light map onto its primitives on the first pass.</span></span> <span data-ttu-id="e9014-116">また、基本テクスチャのレンダリングには 2 つ目のパスを使います。</span><span class="sxs-lookup"><span data-stu-id="e9014-116">It should use a second pass to render the base texture.</span></span> <span data-ttu-id="e9014-117">例外は反射光マップです。</span><span class="sxs-lookup"><span data-stu-id="e9014-117">The exception to this is specular light mapping.</span></span> <span data-ttu-id="e9014-118">その場合、まず基本テクスチャをレンダリングしてから、ライト マップを追加してください。</span><span class="sxs-lookup"><span data-stu-id="e9014-118">In that case, render the base texture first; then add the light map.</span></span>

<span data-ttu-id="e9014-119">複数テクスチャ ブレンドにより、アプリケーションがライト マップと基本テクスチャを 1 つのパスでレンダリングできるようになります。</span><span class="sxs-lookup"><span data-stu-id="e9014-119">Multiple texture blending enables your application to render the light map and the base texture in one pass.</span></span> <span data-ttu-id="e9014-120">複数テクスチャ ブレンド用のユーザーのハードウェアがある場合、アプリケーションはライト マップを実行する際にそれを利用します。</span><span class="sxs-lookup"><span data-stu-id="e9014-120">If the user's hardware provides for multiple texture blending, your application should take advantage of it when performing light mapping.</span></span> <span data-ttu-id="e9014-121">これにより、アプリケーションのパフォーマンスが大幅に向上します。</span><span class="sxs-lookup"><span data-stu-id="e9014-121">This significantly improves your application's performance.</span></span>

<span data-ttu-id="e9014-122">ライト マップを使って、Direct3D アプリケーションはプリミティブのレンダリング時にさまざまな照明効果を実現します。</span><span class="sxs-lookup"><span data-stu-id="e9014-122">Using light maps, a Direct3D application can achieve a variety of lighting effects when it renders primitives.</span></span> <span data-ttu-id="e9014-123">シーン内のモノクロとカラーの照明をマップできるだけでなく、鏡面ハイライトや拡散光などのディテールも追加できます。</span><span class="sxs-lookup"><span data-stu-id="e9014-123">It can map not only monochrome and colored lights in a scene, but it can also add details such as specular highlights and diffuse lighting.</span></span>

<span data-ttu-id="e9014-124">Direct3D のテクスチャ ブレンドを使ってライト マップを実行する方法については、以下のトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9014-124">Information on using Direct3D texture blending to perform light mapping is presented in the following topics.</span></span>

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="e9014-125"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="e9014-125"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="e9014-126">トピック</span><span class="sxs-lookup"><span data-stu-id="e9014-126">Topic</span></span></th>
<th align="left"><span data-ttu-id="e9014-127">説明</span><span class="sxs-lookup"><span data-stu-id="e9014-127">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="monochrome-light-maps.md"><span data-ttu-id="e9014-128">モノクロ ライト マップ</span><span class="sxs-lookup"><span data-stu-id="e9014-128">Monochrome light maps</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e9014-129">モノクロ ライト マップを使うと、古い 3D アクセラレータ ボードが宛先ピクセルのアルファ値を使ったテクスチャ ブレンドをサポートしていない場合に、古いアダプターでもマルチパス テクスチャ ブレンドを実行できます。</span><span class="sxs-lookup"><span data-stu-id="e9014-129">Monochrome light mapping enables older adapters to perform multipass texture blending, when an older 3D accelerator board doesn't support texture blending using the alpha value of the destination pixel.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="color-light-maps.md"><span data-ttu-id="e9014-130">カラー ライト マップ</span><span class="sxs-lookup"><span data-stu-id="e9014-130">Color light maps</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e9014-131">色の付いたライト マップは、そのライト情報にライト マップの RGB データを使用します。</span><span class="sxs-lookup"><span data-stu-id="e9014-131">A colored light map uses the RGB data in the light map for its lighting information.</span></span> <span data-ttu-id="e9014-132">アプリケーションは通常、カラー ライト マップを使う場合の方が現実的に 3D シーンをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="e9014-132">An application usually renders 3D scenes more realistically if it uses colored light maps.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="specular-light-maps.md"><span data-ttu-id="e9014-133">反射ライト マップ</span><span class="sxs-lookup"><span data-stu-id="e9014-133">Specular light maps</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e9014-134">光源から照射されると、反射率の高いマテリアルを使用している光沢のあるオブジェクトには反射光が適用されます。</span><span class="sxs-lookup"><span data-stu-id="e9014-134">When illuminated by a light source, shiny objects that use highly reflective materials receive specular highlights.</span></span> <span data-ttu-id="e9014-135">照明モジュールによって生成された鏡面ハイライトを使用するのではなく、反射ライト マップをプリミティブに適用した方が、より正確なハイライトが得られる場合があります。</span><span class="sxs-lookup"><span data-stu-id="e9014-135">Sometimes you can get more accurate highlights by applying specular light maps to primitives, rather than using the specular highlights produced by the lighting module.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="diffuse-light-maps.md"><span data-ttu-id="e9014-136">拡散ライト マップ</span><span class="sxs-lookup"><span data-stu-id="e9014-136">Diffuse light maps</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="e9014-137">マット サーフェスには、拡散光の反射があります。</span><span class="sxs-lookup"><span data-stu-id="e9014-137">Matte surfaces have diffuse light reflection.</span></span> <span data-ttu-id="e9014-138">拡散光の明るさは、光源からの距離と、サーフェスの法線および光源方向ベクトルの角度によって決まります。</span><span class="sxs-lookup"><span data-stu-id="e9014-138">The brightness of diffuse light depends on the distance from the light source and the angle between the surface normal and the light source direction vector.</span></span> <span data-ttu-id="e9014-139">テクスチャ ライト マップは、複雑な拡散光をシミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="e9014-139">Texture light maps can simulate complex diffuse lighting.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="e9014-140"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="e9014-140"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="e9014-141">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="e9014-141">Textures</span></span>](textures.md)

 

 




