---
title: テクスチャの折り返し
description: テクスチャの折り返しによって、Direct3D が各頂点に指定されたテクスチャ座標を使って、テクスチャが適用された多角形をラスタライズする際の基本的な方法が変更されます。
ms.assetid: C28FB369-9A91-4D57-A96D-4A5D36484B35
keywords:
- テクスチャの折り返し
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 28dcb134b87ac136b341d5b1f349ac9d656ef642
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7553456"
---
# <a name="texture-wrapping"></a><span data-ttu-id="1cdd5-104">テクスチャの折り返し</span><span class="sxs-lookup"><span data-stu-id="1cdd5-104">Texture wrapping</span></span>


<span data-ttu-id="1cdd5-105">テクスチャの折り返しによって、Direct3D が各頂点に指定されたテクスチャ座標を使って、テクスチャが適用された多角形をラスタライズする際の基本的な方法が変更されます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-105">Texture wrapping changes the basic way that Direct3D rasterizes textured polygons using the texture coordinates specified for each vertex.</span></span> <span data-ttu-id="1cdd5-106">多角形をラスタライズするとき、システムは多角形の各頂点のテクスチャ座標の間を補間して、多角形の各ピクセルに使うテクセルを決定します。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-106">While rasterizing a polygon, the system interpolates between the texture coordinates at each of the polygon's vertices to determine the texels that should be used for every pixel of the polygon.</span></span> <span data-ttu-id="1cdd5-107">通常、システムはテクスチャを 2D 平面として扱い、テクスチャ内の点 A から点 B までの最短経路を取ることによって新しいテクセルを補間します。点 A が u, v 位置 (0.8, 0.1) にあり、点 B が (0.1, 0.1) にある場合、補間の線は次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-107">Normally, the system treats the texture as a 2D plane, interpolating new texels by taking the shortest route from point A within a texture to point B. If point A represents the u, v position (0.8, 0.1), and point B is at (0.1,0.1), the line of interpolation looks like the following diagram.</span></span>

![2 点間の補間の線の図](images/interp1.png)

<span data-ttu-id="1cdd5-109">この図では、A と B の間の最短距離がテクスチャのほぼ中央を通っています。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-109">Note that the shortest distance between A and B in this illustration runs roughly through the middle of the texture.</span></span> <span data-ttu-id="1cdd5-110">u または v のテクスチャ座標の折り返しを有効にした場合、Direct3D で u 方向および v 方向のテクスチャ座標間の最短経路を判定する方法が変わります。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-110">Enabling u-texture or v-texture coordinate wrapping changes how Direct3D perceives the shortest route between texture coordinates in the u-direction and v-direction.</span></span> <span data-ttu-id="1cdd5-111">定義では、テクスチャの折り返しによって 0.0 と 1.0 が同じ位置になると仮定され、ラスタライザーがテクスチャ座標間の最短経路を決定します。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-111">By definition, texture wrapping causes the rasterizer to take the shortest route between texture coordinate sets, assuming that 0.0 and 1.0 are coincident.</span></span> <span data-ttu-id="1cdd5-112">これは理解が難しい部分です。次のように考えてみましょう。一方向のテクスチャの折り返しを有効にすると、システムは円柱の周囲に巻き付いているかのようにテクスチャを扱います。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-112">The last bit is the tricky part: You can imagine that enabling texture wrapping in one direction causes the system to treat a texture as though it were wrapped around a cylinder.</span></span> <span data-ttu-id="1cdd5-113">たとえば、次のような図を考えます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-113">For example, consider the following diagram.</span></span>

![円柱の周りに巻き付いたテクスチャと 2 つの点の図](images/interp2.png)

<span data-ttu-id="1cdd5-115">この図は、u 方向の折り返しによって、テクスチャ座標の補間がどのように影響を受けるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-115">The preceding illustration shows how wrapping in the u - direction affects how the system interpolates texture coordinates.</span></span> <span data-ttu-id="1cdd5-116">折り返されていない通常のテクスチャの例と同じ点を使用すると、点 A と点 B 間の最短経路がテクスチャの中央を通っていないことがわかります。この場合は、0.0 と 1.0 が重なっている境界線を横切っています。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-116">Using the same points as in the example for normal, or nonwrapped, textures, you can see that the shortest route between points A and B is no longer across the middle of the texture; it's now across the border where 0.0 and 1.0 exist together.</span></span> <span data-ttu-id="1cdd5-117">v 方向の折り返しも同様ですが、横置きになった円柱の周囲にテクスチャが巻き付けられます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-117">Wrapping in the v-direction is similar, except that it wraps the texture around a cylinder that is lying on its side.</span></span> <span data-ttu-id="1cdd5-118">u 方向と v 方向両方の折り返しはさらに複雑です。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-118">Wrapping in both the u-direction and v-direction is more complex.</span></span> <span data-ttu-id="1cdd5-119">この場合は、円環面、つまりドーナツ状のテクスチャを想像してください。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-119">In this situation, you can envision the texture as a torus, or doughnut.</span></span>

<span data-ttu-id="1cdd5-120">テクスチャの折り返しを実際に使用した最も一般的なアプリケーションは、環境マッピングの実行です。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-120">The most common practical application for texture wrapping is to perform environment mapping.</span></span> <span data-ttu-id="1cdd5-121">通常、環境マップでテクスチャ処理したオブジェクトは非常に反射しやすく、オブジェクトの周囲のミラー イメージがシーンに表示されます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-121">Usually, an object textured with an environment map appears very reflective, showing a mirrored image of the object's surroundings in the scene.</span></span> <span data-ttu-id="1cdd5-122">これを説明するために、4 つの壁に囲まれた部屋を考えてみましょう。壁にはそれぞれ R、G、B、Y という文字が描かれており、それぞれに対応する赤、緑、青、および黄色のカラーが塗られています。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-122">For the sake of this discussion, picture a room with four walls, each one painted with a letter R, G, B, Y and the corresponding colors: red, green, blue, and yellow.</span></span> <span data-ttu-id="1cdd5-123">このような単純な部屋の環境マップは、次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-123">The environment map for such a simple room might look like the following illustration.</span></span>

![赤、緑、青、黄の垂直方向ストライプの図](images/envmap.png)

<span data-ttu-id="1cdd5-125">この部屋の天井が、完全に反射する、4 面から成る 1 本の柱で支えられているとします。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-125">Imagine that the room's ceiling is held up by a perfectly reflective, four-sided, pillar.</span></span> <span data-ttu-id="1cdd5-126">この柱に環境マップ テクスチャをマッピングするのは簡単ですが、文字とカラーが柱に反射しているように見せるのは容易ではありません。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-126">Mapping the environment map texture to the pillar is simple; making the pillar look as though it is reflecting the letters and colors is not as easy.</span></span> <span data-ttu-id="1cdd5-127">次の図は、上部の頂点付近に該当するテクスチャ座標を記載した、柱のワイヤー フレームを示したものです。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-127">The following diagram shows a wire frame of the pillar with the applicable texture coordinates listed near the top vertices.</span></span> <span data-ttu-id="1cdd5-128">折り返しがテクスチャのエッジを横切る継ぎ目は、点線で示しています。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-128">The seam where wrapping will cross the edges of the texture is shown with a dotted line.</span></span>

![二等分する点線が描かれた四角形の図](images/seam.png)

<span data-ttu-id="1cdd5-130">u 方向で折り返しが有効になっているので、テクスチャ処理した柱には、環境マップのカラーとシンボルが適切に表示されており、テクスチャの前面の継ぎ目では、ラスタライザーによって、テクスチャ座標間の最短経路が正しく選択されています。この場合、u 座標の 0.0 と 1.0 が重なっていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-130">With wrapping enabled in the u-direction, the textured pillar shows the colors and symbols from the environment map appropriately and, at the seam in the front of the texture, the rasterizer properly chooses the shortest route between the texture coordinates, assuming that u-coordinates 0.0 and 1.0 share the same location.</span></span> <span data-ttu-id="1cdd5-131">テクスチャ処理した柱は、次の図のようになります。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-131">The textured pillar looks like the following illustration.</span></span>

![赤、緑、青、および黄の 4 つの領域で構成された柱の図](images/tex-seam.png)

<span data-ttu-id="1cdd5-133">テクスチャの折り返しが有効でない場合、ラスタライザーは期待される反射イメージの生成に必要な方向には補間しません。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-133">If texture wrapping isn't enabled, the rasterizer does not interpolate in the direction needed to generate a believable, reflected image.</span></span> <span data-ttu-id="1cdd5-134">u 座標 0.175 と 0.875 の間のテクセルはテクスチャの中心を通るため、柱の前面の領域には水平方向に圧縮されたテクセルが含まれます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-134">Rather, the area at the front of the pillar contains a horizontally compressed version of the texels between u-coordinates 0.175 and 0.875, as they pass through the center of the texture.</span></span> <span data-ttu-id="1cdd5-135">折り返しの効果は適用されていません。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-135">The wrap effect is ruined.</span></span>

<span data-ttu-id="1cdd5-136">テクスチャの折り返しを、類似する名前のテクスチャのアドレス指定モードと混同しないでください。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-136">Do not confuse texture wrapping with the similarly named texture addressing modes.</span></span> <span data-ttu-id="1cdd5-137">テクスチャの折り返しは、テクスチャのアドレス指定の前に行われます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-137">Texture wrapping is performed before texture addressing.</span></span> <span data-ttu-id="1cdd5-138">テクスチャの折り返しデータに、\[0.0, 1.0\] の範囲外のテクスチャ座標が含まれないようにしてください。このような座標が含まれている場合、定義されていない結果になります。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-138">Be sure the texture wrapping data does not contain any texture coordinates outside of the range of \[0.0, 1.0\] because this will produce undefined results.</span></span> <span data-ttu-id="1cdd5-139">テクスチャの折り返しについて詳しくは、「[テクスチャのアドレス指定モード](texture-addressing-modes.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-139">For more information about texture addressing, see [Texture addressing modes](texture-addressing-modes.md).</span></span>

## <a name="span-iddisplacementmapwrappingspanspan-iddisplacementmapwrappingspanspan-iddisplacementmapwrappingspandisplacement-map-wrapping"></a><span data-ttu-id="1cdd5-140"><span id="Displacement_Map_Wrapping"></span><span id="displacement_map_wrapping"></span><span id="DISPLACEMENT_MAP_WRAPPING"></span>ディスプレースメント マップの折り返し</span><span class="sxs-lookup"><span data-stu-id="1cdd5-140"><span id="Displacement_Map_Wrapping"></span><span id="displacement_map_wrapping"></span><span id="DISPLACEMENT_MAP_WRAPPING"></span>Displacement map wrapping</span></span>


<span data-ttu-id="1cdd5-141">ディスプレースメント マップは、テセレーション エンジンによって補間されます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-141">Displacement maps are interpolated by the tesselation engine.</span></span> <span data-ttu-id="1cdd5-142">テセレーション エンジンには折り返しモードを指定できないため、ディスプレースメント マップを使ってテクスチャの折り返しを行うことはできません。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-142">Because the wrap mode cannot be specified for the tessellation engine, texture wrapping cannot be performed with displacement maps.</span></span> <span data-ttu-id="1cdd5-143">アプリケーションは、強制的に補間を行う頂点を使って、任意の方向に折り返すことができます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-143">An application is able to use a set of vertices that forces the interpolation to wrap in any direction.</span></span> <span data-ttu-id="1cdd5-144">また、補間を単純な線形補間として行うように指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="1cdd5-144">The application can also specify the interpolation to be done as a simple linear interpolation.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="1cdd5-145"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="1cdd5-145"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="1cdd5-146">テクスチャ</span><span class="sxs-lookup"><span data-stu-id="1cdd5-146">Textures</span></span>](textures.md)

 

 




