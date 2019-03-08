---
title: ラスター化規則の概要
description: 多くの場合、頂点として指定される点は、画面上のピクセルと正確には一致しません。 この場合、Direct3D は三角形のラスター化ルールを適用し、指定された三角形に適用するピクセルを決定します。
ms.assetid: 4232CDBA-F669-4417-9378-F9013E83462C
keywords:
- ラスター化規則の概要
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 1d1907be029254d99be9e6158c93c179baea1fb0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641087"
---
# <a name="introduction-to-rasterization-rules"></a><span data-ttu-id="3f498-105">ラスター化規則の概要</span><span class="sxs-lookup"><span data-stu-id="3f498-105">Introduction to rasterization rules</span></span>


<span data-ttu-id="3f498-106">多くの場合、頂点として指定される点は、画面上のピクセルと正確には一致しません。</span><span class="sxs-lookup"><span data-stu-id="3f498-106">Often, the points specified for vertices do not precisely match the pixels on the screen.</span></span> <span data-ttu-id="3f498-107">この場合、Direct3D は三角形のラスター化ルールを適用し、指定された三角形に適用するピクセルを決定します。</span><span class="sxs-lookup"><span data-stu-id="3f498-107">When this happens, Direct3D applies triangle rasterization rules to decide which pixels apply to a given triangle.</span></span>

<span data-ttu-id="3f498-108">これは、ラスター化規則の簡単な説明です。</span><span class="sxs-lookup"><span data-stu-id="3f498-108">This is a simplified introduction to rasterization rules.</span></span> <span data-ttu-id="3f498-109">詳しくは、「[ラスター化ルール](rasterization-rules.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f498-109">For more details, see [Rasterization rules](rasterization-rules.md).</span></span> <span data-ttu-id="3f498-110">「[ラスタライザー (RS) ステージ](rasterizer-stage--rs-.md)」もご覧ください。</span><span class="sxs-lookup"><span data-stu-id="3f498-110">See also [Rasterizer (RS) stage](rasterizer-stage--rs-.md).</span></span>

## <a name="span-idtrianglerasterizationrulesspanspan-idtrianglerasterizationrulesspanspan-idtrianglerasterizationrulesspantriangle-rasterization-rules"></a><span data-ttu-id="3f498-111"><span id="Triangle_Rasterization_Rules"></span><span id="triangle_rasterization_rules"></span><span id="TRIANGLE_RASTERIZATION_RULES"></span>三角形のラスタライズ ルール</span><span class="sxs-lookup"><span data-stu-id="3f498-111"><span id="Triangle_Rasterization_Rules"></span><span id="triangle_rasterization_rules"></span><span id="TRIANGLE_RASTERIZATION_RULES"></span>Triangle Rasterization Rules</span></span>


<span data-ttu-id="3f498-112">Direct3D は、塗りつぶしジオメトリに左上の塗りつぶし規則を使います。</span><span class="sxs-lookup"><span data-stu-id="3f498-112">Direct3D uses a top-left filling convention for filling geometry.</span></span> <span data-ttu-id="3f498-113">これは、GDI と OpenGL の長方形に使われているのと同じ規則です。</span><span class="sxs-lookup"><span data-stu-id="3f498-113">This is the same convention that is used for rectangles in GDI and OpenGL.</span></span> <span data-ttu-id="3f498-114">Direct3D では、ピクセルの中心が決定的な点となります。</span><span class="sxs-lookup"><span data-stu-id="3f498-114">In Direct3D, the center of the pixel is the decisive point.</span></span> <span data-ttu-id="3f498-115">中心が三角形の中の場合、ピクセルは三角形の一部です。</span><span class="sxs-lookup"><span data-stu-id="3f498-115">If the center is inside a triangle, the pixel is part of the triangle.</span></span> <span data-ttu-id="3f498-116">ピクセルの中心は、整数座標上にあります。</span><span class="sxs-lookup"><span data-stu-id="3f498-116">Pixel centers are at integer coordinates.</span></span>

<span data-ttu-id="3f498-117">Direct3D により使われる三角形のラスター化ルールのこの説明は、必ずしも使用可能なすべてのハードウェアに当てはまるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="3f498-117">This description of triangle-rasterization rules used by Direct3D does not necessarily apply to all available hardware.</span></span> <span data-ttu-id="3f498-118">テストの結果、これらのルールの実装が少し異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="3f498-118">Your testing may uncover minor variations in the implementation of these rules.</span></span>

<span data-ttu-id="3f498-119">次の図は、左上隅が (0, 0) で右下隅が (5, 5) の長方形を示しています。</span><span class="sxs-lookup"><span data-stu-id="3f498-119">The following illustration shows a rectangle whose upper-left corner is at (0, 0) and whose lower-right corner is at (5, 5).</span></span> <span data-ttu-id="3f498-120">この長方形は、予想されるとおり 25 ピクセルを塗りつぶします。</span><span class="sxs-lookup"><span data-stu-id="3f498-120">This rectangle fills 25 pixels, just as you would expect.</span></span> <span data-ttu-id="3f498-121">長方形の幅は右から左を減算した値と定義されます。</span><span class="sxs-lookup"><span data-stu-id="3f498-121">The width of the rectangle is defined as right minus left.</span></span> <span data-ttu-id="3f498-122">高さは下から上を減算した値と定義されます。</span><span class="sxs-lookup"><span data-stu-id="3f498-122">The height is defined as bottom minus top.</span></span>

![5 つの行と列に分割された番号付きの正方形](images/pixmap.png)

<span data-ttu-id="3f498-124">左上の塗りつぶし規則では、*上*とは水平スパンにおける垂直方法の位置を示し、*左*はスパン内におけるピクセルの水平方向の位置を示します。</span><span class="sxs-lookup"><span data-stu-id="3f498-124">In the top-left filling convention, *top* refers to the vertical location of horizontal spans, and *left* refers to the horizontal location of pixels within a span.</span></span> <span data-ttu-id="3f498-125">エッジは、水平方向でない限り上エッジとすることはできません。</span><span class="sxs-lookup"><span data-stu-id="3f498-125">An edge cannot be a top edge unless it is horizontal.</span></span> <span data-ttu-id="3f498-126">通常、ほとんどの三角形には左エッジと右エッジのみあります。</span><span class="sxs-lookup"><span data-stu-id="3f498-126">In general, most triangles have only left and right edges.</span></span> <span data-ttu-id="3f498-127">次の図は、上エッジと右エッジを示しています。</span><span class="sxs-lookup"><span data-stu-id="3f498-127">The following illustration shows a top edge and a right edge.</span></span>

![2 つの三角形を含む番号付きの正方形](images/triedge.png)

<span data-ttu-id="3f498-129">左上の塗りつぶし規則により、三角形がピクセルの中心を通過するときに Direct3D が実行する操作が決まります。</span><span class="sxs-lookup"><span data-stu-id="3f498-129">The top-left filling convention determines the action taken by Direct3D when a triangle passes through the center of a pixel.</span></span> <span data-ttu-id="3f498-130">次の図は、2 つの三角形を示しています。1 つは (0, 0)、(5, 0)、(5, 5) にあり、もう 1 つは (0, 5)、(0, 0)、(5, 5) にあります。</span><span class="sxs-lookup"><span data-stu-id="3f498-130">The following illustration shows two triangles, one at (0, 0), (5, 0), and (5, 5), and the other at (0, 5), (0, 0), and (5, 5).</span></span> <span data-ttu-id="3f498-131">このケースの 1 つ目の三角形は 15 ピクセル (黒で表示) を取得しますが、2 つ目の三角形が取得するのは 10 ピクセル (灰色で表示) だけです。共有されるエッジが 1 つ目の三角形の左エッジのためです。</span><span class="sxs-lookup"><span data-stu-id="3f498-131">The first triangle in this case gets 15 pixels (shown in black), whereas the second gets only 10 pixels (shown in gray) because the shared edge is the left edge of the first triangle.</span></span>

![2 つの三角形を示す番号付きの正方形](images/twotris.png)

<span data-ttu-id="3f498-133">左上隅 (0.5, 0.5) と右下隅 (2.5, 4.5) で三角形を定義した場合、この三角形の中心点は (1.5, 2.5) になります。</span><span class="sxs-lookup"><span data-stu-id="3f498-133">If you define a rectangle with its upper-left corner at (0.5, 0.5) and its lower-right corner at (2.5, 4.5), the center point of this rectangle is at (1.5, 2.5).</span></span> <span data-ttu-id="3f498-134">Direct3D ラスタライザーによりこの三角形がテッセレーションされた場合、各ピクセルの中心は明確に 4 つの各三角形の中に収まり、左上の塗りつぶし規則は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="3f498-134">When the Direct3D rasterizer tessellates this rectangle, the center of each pixel is unambiguously inside each of the four triangles, and the top-left filling convention is not needed.</span></span> <span data-ttu-id="3f498-135">次の図にこれを示します。</span><span class="sxs-lookup"><span data-stu-id="3f498-135">The following illustration shows this.</span></span> <span data-ttu-id="3f498-136">三角形内のピクセルには、Direct3D がピクセルを含める三角形に基づいてラベルが付けられます。</span><span class="sxs-lookup"><span data-stu-id="3f498-136">The pixels in the rectangle are labeled according to the triangle in which Direct3D includes them.</span></span>

![4 つの三角形に分割された長方形を含む番号付きの正方形](images/noambig.png)

<span data-ttu-id="3f498-138">その左上隅が (1.0, 1.0)、右下隅が (3.0, 5.0)、中心点が (2.0, 3.0) となるように前の図の長方形を移動した場合、Direct3D は左上の塗りつぶし規則を適用します。</span><span class="sxs-lookup"><span data-stu-id="3f498-138">If you move the rectangle in the preceding illustration so that its upper-left corner is at (1.0, 1.0), its lower-right corner at (3.0, 5.0), and its center point at (2.0, 3.0), Direct3D applies the top-left filling convention.</span></span> <span data-ttu-id="3f498-139">次の図が示すように、この長方形内のほとんどのピクセルは複数の三角形の境界をまたいでいます。</span><span class="sxs-lookup"><span data-stu-id="3f498-139">Most pixels in this rectangle straddle the border between two or more triangles, as the following illustration shows.</span></span>

![4 つの三角形に分割された長方形を含む番号付きの正方形](images/fillrule.png)

<span data-ttu-id="3f498-141">どちらの長方形でも、次の図に示すように同じピクセルが影響を受けています。</span><span class="sxs-lookup"><span data-stu-id="3f498-141">For both rectangles, the same pixels are affected, as shown in the following illustration.</span></span>

![前の 2 つの番号付きの正方形の影響を受けているピクセル](images/samepix.png)

## <a name="span-idpointandlinerulesspanspan-idpointandlinerulesspanspan-idpointandlinerulesspanpoint-and-line-rules"></a><span data-ttu-id="3f498-143"><span id="Point_and_Line_Rules"></span><span id="point_and_line_rules"></span><span id="POINT_AND_LINE_RULES"></span>ポイント、線ルール</span><span class="sxs-lookup"><span data-stu-id="3f498-143"><span id="Point_and_Line_Rules"></span><span id="point_and_line_rules"></span><span id="POINT_AND_LINE_RULES"></span>Point and Line Rules</span></span>


<span data-ttu-id="3f498-144">点は、ポイント スプライトと同じようにレンダリングされます。どちらも画面に沿った四角形としてレンダリングされるため、多角形のレンダリングと同じルールに従います。</span><span class="sxs-lookup"><span data-stu-id="3f498-144">Points are rendered the same as point sprites, which are both rendered as screen-aligned quadrilaterals and thus adhere to the same rules as polygon rendering.</span></span>

<span data-ttu-id="3f498-145">アンチエイリアスが適用されていない線のレンダリング ルールは、[GDI の線](https://msdn.microsoft.com/library/windows/desktop/dd145027)のルールとまったく同じです。</span><span class="sxs-lookup"><span data-stu-id="3f498-145">Non-antialiased line rendering rules are exactly the same as those for [GDI lines](https://msdn.microsoft.com/library/windows/desktop/dd145027).</span></span>

## <a name="span-idpointspriterulesspanspan-idpointspriterulesspanspan-idpointspriterulesspanpoint-sprite-rules"></a><span data-ttu-id="3f498-146"><span id="Point_Sprite_Rules"></span><span id="point_sprite_rules"></span><span id="POINT_SPRITE_RULES"></span>ポイントのスプライトの規則</span><span class="sxs-lookup"><span data-stu-id="3f498-146"><span id="Point_Sprite_Rules"></span><span id="point_sprite_rules"></span><span id="POINT_SPRITE_RULES"></span>Point Sprite Rules</span></span>


<span data-ttu-id="3f498-147">ポイント スプライトとパッチ プリミティブは、プリミティブが最初に三角形にテッセレーションされた後、その三角形がラスター化されたかのようにラスター化されます。</span><span class="sxs-lookup"><span data-stu-id="3f498-147">Point sprites and patch primitives are rasterized as if the primitives were first tessellated into triangles and the resulting triangles rasterized.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="3f498-148"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="3f498-148"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="3f498-149">デバイス</span><span class="sxs-lookup"><span data-stu-id="3f498-149">Devices</span></span>](devices.md)

[<span data-ttu-id="3f498-150">ラスタライザー (RS) のステージ</span><span class="sxs-lookup"><span data-stu-id="3f498-150">Rasterizer (RS) stage</span></span>](rasterizer-stage--rs-.md)

[<span data-ttu-id="3f498-151">ラスタライズ ルール</span><span class="sxs-lookup"><span data-stu-id="3f498-151">Rasterization rules</span></span>](rasterization-rules.md)

 

 




