---
title: 放射光
description: 放射光は、白熱光などオブジェクトによって放射される光です。
ms.assetid: 262EB9E2-DF96-401F-93D6-51A7BB60074B
keywords:
- 放射光
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ba112e04518d3e1ee05e7ee8e23e633d4cf59748
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8936862"
---
# <a name="emissive-lighting"></a><span data-ttu-id="c61e8-104">放射光</span><span class="sxs-lookup"><span data-stu-id="c61e8-104">Emissive lighting</span></span>


<span data-ttu-id="c61e8-105">*放射光*は、白熱光などオブジェクトによって放射される光です。</span><span class="sxs-lookup"><span data-stu-id="c61e8-105">*Emissive lighting* is light that is emitted by an object; for example, a glow.</span></span> <span data-ttu-id="c61e8-106">放射によって、レンダリングされるオブジェクトが自己発光しているように見えます。</span><span class="sxs-lookup"><span data-stu-id="c61e8-106">Emission makes a rendered object appear to be self-luminous.</span></span> <span data-ttu-id="c61e8-107">放射はオブジェクトの色に影響し、暗いマテリアルが明るくなったり、部分的に放射される光の色になったりする場合があります。</span><span class="sxs-lookup"><span data-stu-id="c61e8-107">Emission affects an object's color and can, for example, make a dark material brighter and take on part of the emitted color.</span></span>

<span data-ttu-id="c61e8-108">放射光は単一の項で表されます。</span><span class="sxs-lookup"><span data-stu-id="c61e8-108">Emissive lighting is described by a single term.</span></span>

<span data-ttu-id="c61e8-109">放射光 = Cₑ</span><span class="sxs-lookup"><span data-stu-id="c61e8-109">Emissive Lighting = Cₑ</span></span>

<span data-ttu-id="c61e8-110">この場合</span><span class="sxs-lookup"><span data-stu-id="c61e8-110">where:</span></span>

| <span data-ttu-id="c61e8-111">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c61e8-111">Parameter</span></span> | <span data-ttu-id="c61e8-112">既定値</span><span class="sxs-lookup"><span data-stu-id="c61e8-112">Default value</span></span> | <span data-ttu-id="c61e8-113">種類</span><span class="sxs-lookup"><span data-stu-id="c61e8-113">Type</span></span>                                                                 | <span data-ttu-id="c61e8-114">説明</span><span class="sxs-lookup"><span data-stu-id="c61e8-114">Description</span></span>     |
|-----------|---------------|----------------------------------------------------------------------|-----------------|
| <span data-ttu-id="c61e8-115">Cₑ</span><span class="sxs-lookup"><span data-stu-id="c61e8-115">Cₑ</span></span>        | <span data-ttu-id="c61e8-116">(0,0,0,0)</span><span class="sxs-lookup"><span data-stu-id="c61e8-116">(0,0,0,0)</span></span>     | <span data-ttu-id="c61e8-117">赤、緑、青、およびアルファ透明度 (すべての浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="c61e8-117">Red, green, blue, and alpha transparency (all floating-point values)</span></span> | <span data-ttu-id="c61e8-118">放射色。</span><span class="sxs-lookup"><span data-stu-id="c61e8-118">Emissive color.</span></span> |

 

<span data-ttu-id="c61e8-119">Cₑ の値は、color 1 または color 2 です。</span><span class="sxs-lookup"><span data-stu-id="c61e8-119">The value for Cₑ is either color 1 or color 2.</span></span> <span data-ttu-id="c61e8-120">頂点の色が指定されていない場合は、素材の放射色が使用されます。</span><span class="sxs-lookup"><span data-stu-id="c61e8-120">If the vertex color is not provided, the material emissive color is used.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="c61e8-121"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="c61e8-121"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="c61e8-122">この例では、オブジェクトの色は、シーンの環境光と素材のアンビエント色を使用しています。</span><span class="sxs-lookup"><span data-stu-id="c61e8-122">In this example, the object is colored using the scene ambient light and a material ambient color.</span></span>

<span data-ttu-id="c61e8-123">方程式に従って、生成されるオブジェクトの頂点の色は素材色です。</span><span class="sxs-lookup"><span data-stu-id="c61e8-123">According to the equation, the resulting color for the object vertices is the material color.</span></span>

<span data-ttu-id="c61e8-124">次の図は、素材色 (緑) を示しています。</span><span class="sxs-lookup"><span data-stu-id="c61e8-124">The following illustration shows the material color, which is green.</span></span> <span data-ttu-id="c61e8-125">放射光は、すべてのオブジェクトの頂点を同じ色で照らします。</span><span class="sxs-lookup"><span data-stu-id="c61e8-125">Emissive light lights all object vertices with the same color.</span></span> <span data-ttu-id="c61e8-126">頂点の法線やライトの方向には依存しません。</span><span class="sxs-lookup"><span data-stu-id="c61e8-126">It is not dependent on the vertex normal or the light direction.</span></span> <span data-ttu-id="c61e8-127">その結果、オブジェクトのサーフェスの周囲にシェーディングの差が生じないため、球体は 2D の円のように見えます。</span><span class="sxs-lookup"><span data-stu-id="c61e8-127">As a result, the sphere looks like a 2D circle because there is no difference in shading around the surface of the object.</span></span>

![緑色の球体の図](images/lighte.jpg)

<span data-ttu-id="c61e8-129">次の図は、放射光を他の 3 種類のライトとブレンドする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c61e8-129">The following illustration shows how the emissive light blends with the other three types of lights.</span></span> <span data-ttu-id="c61e8-130">球体の右側では、緑色の放射光と赤色の環境光がブレンドされています。</span><span class="sxs-lookup"><span data-stu-id="c61e8-130">On the right side of the sphere, there is a blend of the green emissive and the red ambient light.</span></span> <span data-ttu-id="c61e8-131">球体の左側では、緑色の放射光が赤色の環境光および拡散光とブレンドされ、赤色のグラデーションが生成されています。</span><span class="sxs-lookup"><span data-stu-id="c61e8-131">On the left side of the sphere, the green emissive light blends with red ambient and diffuse light producing a red gradient.</span></span> <span data-ttu-id="c61e8-132">鏡面ハイライトの中央は白色ですが、環境光、拡散光、放射光の値のブレンドによって黄色が作成されている状態のまま、反射光の値が急激に低下するため、黄色の輪が作成されています。</span><span class="sxs-lookup"><span data-stu-id="c61e8-132">The specular highlight is white in the center and creates a yellow ring as the specular light value falls off sharply leaving the ambient, diffuse and emissive light values which blend together to make yellow.</span></span>

![放射光による緑色の球体の図](images/lightadse.jpg)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="c61e8-134"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="c61e8-134"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="c61e8-135">光源の計算</span><span class="sxs-lookup"><span data-stu-id="c61e8-135">Mathematics of lighting</span></span>](mathematics-of-lighting.md)

 

 




