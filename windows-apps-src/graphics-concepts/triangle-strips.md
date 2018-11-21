---
title: トライアングル ストリップ
description: トライアングル ストリップとは、接続された一連の三角形を指します。 三角形どうしがつながっているため、アプリケーションでは、各三角形の 3 つの頂点すべてを繰り返し指定する必要がありません。
ms.assetid: BACC74C5-14E5-4ECC-9139-C2FD1808DB82
keywords:
- トライアングル ストリップ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: f60f0f65868d4dec67bf77a329d4b952c20ec44a
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7423078"
---
# <a name="triangle-strips"></a><span data-ttu-id="6dc81-105">トライアングル ストリップ</span><span class="sxs-lookup"><span data-stu-id="6dc81-105">Triangle strips</span></span>


<span data-ttu-id="6dc81-106">トライアングル ストリップとは、接続された一連の三角形を指します。</span><span class="sxs-lookup"><span data-stu-id="6dc81-106">A triangle strip is a series of connected triangles.</span></span> <span data-ttu-id="6dc81-107">三角形どうしがつながっているため、アプリケーションでは、各三角形の 3 つの頂点すべてを繰り返し指定する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="6dc81-107">Because the triangles are connected, the application does not need to repeatedly specify all three vertices for each triangle.</span></span> <span data-ttu-id="6dc81-108">たとえば、次のトライアングル ストリップの定義に必要な頂点は 7 個だけです。</span><span class="sxs-lookup"><span data-stu-id="6dc81-108">For example, you need only seven vertices to define the following triangle strip.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="6dc81-109"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="6dc81-109"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


![7 個の頂点を持つトライアングル ストリップの図](images/tristrip.png)

<span data-ttu-id="6dc81-111">システムは、頂点 v1、v2、v3 を使って最初の三角形を描画し、v2、v4、v3 を使って 2 つ目の三角形を描画します。さらに、v3、v4、v5 を使って 3 つ目を、v4、v6、v5 を使って 4 つ目を描画し、以降も同様に続きます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-111">The system uses vertices v1, v2, and v3 to draw the first triangle; v2, v4, and v3 to draw the second triangle; v3, v4, and v5 to draw the third; v4, v6, and v5 to draw the fourth; and so on.</span></span> <span data-ttu-id="6dc81-112">2 つ目と 4 つ目の三角形の頂点の順序は番号順でないことに注意してください。これは、すべての三角形を時計回りの方向に描画する必要があるためです。</span><span class="sxs-lookup"><span data-stu-id="6dc81-112">Notice that the vertices of the second and fourth triangles are out of order; this is required to make sure that all the triangles are drawn in a clockwise orientation.</span></span>

<span data-ttu-id="6dc81-113">3D シーンのほとんどのオブジェクトは、トライアングル ストリップで構成されます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-113">Most objects in 3D scenes are composed of triangle strips.</span></span> <span data-ttu-id="6dc81-114">これは、トライアングル ストリップを使うと、メモリと処理時間を効率的に利用する形で複雑なオブジェクトを指定できるためです。</span><span class="sxs-lookup"><span data-stu-id="6dc81-114">This is because triangle strips can be used to specify complex objects in a way that makes efficient use of memory and processing time.</span></span>

<span data-ttu-id="6dc81-115">次の図は、レンダリングされたトライアングル ストリップを示しています。</span><span class="sxs-lookup"><span data-stu-id="6dc81-115">The following illustration depicts a rendered triangle strip.</span></span>

![レンダリングされたトライアングル ストリップの図](images/tstrip2.png)

<span data-ttu-id="6dc81-117">次のコードは、このトライアングル ストリップの頂点を作成する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6dc81-117">The following code shows how to create vertices for this triangle strip.</span></span>

```
struct CUSTOMVERTEX
{
float x,y,z;
};

CUSTOMVERTEX Vertices[] = 
{
    {-5.0, -5.0, 0.0},
    { 0.0,  5.0, 0.0},
    { 5.0, -5.0, 0.0},
    {10.0,  5.0, 0.0},
    {15.0, -5.0, 0.0},
    {20.0,  5.0, 0.0}
};
```

<span data-ttu-id="6dc81-118">次のコード例は、このトライアングル ストリップを Direct3D でレンダリングする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6dc81-118">The code example below shows how to render this triangle strip in Direct3D.</span></span>

```
//
// It is assumed that d3dDevice is a valid
// pointer to a device interface.
//
d3dDevice->DrawPrimitive( D3DPT_TRIANGLESTRIP, 0, 4);
```

## <a name="span-idpolygonsspanspan-idpolygonsspanspan-idpolygonsspanpolygons"></a><span data-ttu-id="6dc81-119"><span id="Polygons"></span><span id="polygons"></span><span id="POLYGONS"></span>ポリゴン</span><span class="sxs-lookup"><span data-stu-id="6dc81-119"><span id="Polygons"></span><span id="polygons"></span><span id="POLYGONS"></span>Polygons</span></span>


<span data-ttu-id="6dc81-120">多くの場合、トライアングル ストリップはポリゴンの構築に使われます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-120">Often, triangle strips are used to build polygons.</span></span> <span data-ttu-id="6dc81-121">ポリゴンとは、3 つ以上の頂点を結んで描かれる閉じた 3D 図形です。</span><span class="sxs-lookup"><span data-stu-id="6dc81-121">A polygon is a closed 3D figure delineated by at least three vertices.</span></span> <span data-ttu-id="6dc81-122">最も単純なポリゴンは三角形です。</span><span class="sxs-lookup"><span data-stu-id="6dc81-122">The simplest polygon is a triangle.</span></span> <span data-ttu-id="6dc81-123">三角形の 3 つの頂点はすべて同一平面にあることが保障されるため、Microsoft Direct3D では、ほとんどのポリゴンが三角形を使って構成されます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-123">Microsoft Direct3D uses triangles to compose most of its polygons because all three vertices in a triangle are guaranteed to be coplanar.</span></span> <span data-ttu-id="6dc81-124">非平面の頂点のレンダリングは効率的ではありません。</span><span class="sxs-lookup"><span data-stu-id="6dc81-124">Rendering nonplanar vertices is inefficient.</span></span> <span data-ttu-id="6dc81-125">複数の三角形を結合することで、大きい複雑なポリゴンやメッシュを形成できます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-125">You can combine triangles to form large, complex polygons and meshes.</span></span>

<span data-ttu-id="6dc81-126">次の図は立方体を示しています。</span><span class="sxs-lookup"><span data-stu-id="6dc81-126">The following illustration shows a cube.</span></span> <span data-ttu-id="6dc81-127">立方体の各面は 2 つの三角形で形成されます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-127">Two triangles form each face of the cube.</span></span> <span data-ttu-id="6dc81-128">これらの三角形のセット全体が、1 つの立方体プリミティブを形成します。</span><span class="sxs-lookup"><span data-stu-id="6dc81-128">The entire set of triangles forms one cubic primitive.</span></span> <span data-ttu-id="6dc81-129">プリミティブのサーフェスにテクスチャを適用すると、単一の固形のように表示できます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-129">You can apply textures to the surfaces of primitives to make them appear to be a single solid form.</span></span> <span data-ttu-id="6dc81-130">詳しくは、「[テクスチャ](textures.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6dc81-130">For details, see [Textures](textures.md).</span></span>

![各面が 2 つの三角形で形成された立方体の図](images/cube3d.png)

<span data-ttu-id="6dc81-132">三角形を使うと、サーフェスが滑らかな曲面に見えるプリミティブを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-132">You can also use triangles to create primitives whose surfaces appear to be smooth curves.</span></span> <span data-ttu-id="6dc81-133">次の図は、三角形で球体をシミュレートする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="6dc81-133">The following illustration shows how a sphere can be simulated with triangles.</span></span> <span data-ttu-id="6dc81-134">マテリアルの適用後にレンダリングすると、曲面のように見える球体を表示できます。</span><span class="sxs-lookup"><span data-stu-id="6dc81-134">After a material is applied, the sphere can be made to look curved when it is rendered.</span></span>

![三角形を使ってシミュレートされた球体の図](images/sphere3d.png)

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="6dc81-136"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="6dc81-136"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="6dc81-137">プリミティブ</span><span class="sxs-lookup"><span data-stu-id="6dc81-137">Primitives</span></span>](primitives.md)

 

 




