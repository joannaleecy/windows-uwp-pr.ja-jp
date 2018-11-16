---
title: ビューポートとクリッピング
description: ビューポートとは、3D シーンが投影される 2 次元 (2D) の四角形です。
ms.assetid: D0DD646E-13AE-452A-AD22-8C35000D0BA9
keywords:
- ビューポートとクリッピング
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 4dd319c686bebf2a30431017f399f48b08618cb6
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6850690"
---
# <a name="viewports-and-clipping"></a><span data-ttu-id="bd8f7-104">ビューポートとクリッピング</span><span class="sxs-lookup"><span data-stu-id="bd8f7-104">Viewports and clipping</span></span>


<span data-ttu-id="bd8f7-105">"ビューポート\*\*" とは、3D シーンが投影される 2 次元 (2D) の矩形です。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-105">A *viewport* is a two-dimensional (2D) rectangle into which a 3D scene is projected.</span></span> <span data-ttu-id="bd8f7-106">Direct3D では、この四角形は Direct3D サーフェス内の座標として存在し、システムによってレンダー ターゲットとして使われます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-106">In Direct3D, the rectangle exists as coordinates within a Direct3D surface that the system uses as a rendering target.</span></span> <span data-ttu-id="bd8f7-107">射影変換は、頂点をビューポートで使われる座標系に変換します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-107">The projection transformation converts vertices into the coordinate system used for the viewport.</span></span> <span data-ttu-id="bd8f7-108">ビューポートは、シーンがレンダリングされるレンダー ターゲット サーフェス上の深度値の範囲 (通常は 0.0 ～ 1.0) を指定するためにも使われます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-108">A viewport is also used to specify the range of depth values on a render-target surface into which a scene will be rendered (usually 0.0 to 1.0).</span></span>

## <a name="span-idtheviewingfrustumspanspan-idtheviewingfrustumspanspan-idtheviewingfrustumspanthe-viewing-frustum"></a><span data-ttu-id="bd8f7-109"><span id="The_Viewing_Frustum"></span><span id="the_viewing_frustum"></span><span id="THE_VIEWING_FRUSTUM"></span>視錐台</span><span class="sxs-lookup"><span data-stu-id="bd8f7-109"><span id="The_Viewing_Frustum"></span><span id="the_viewing_frustum"></span><span id="THE_VIEWING_FRUSTUM"></span>The Viewing Frustum</span></span>


<span data-ttu-id="bd8f7-110">視錐台とは、ビューポートのカメラに対して相対的に配置された、シーン内の 3D ボリュームです。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-110">A viewing frustum is 3D volume in a scene positioned relative to the viewport's camera.</span></span> <span data-ttu-id="bd8f7-111">カメラ空間から画面にモデルがどのように投影されるかは、このボリュームの形に影響されます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-111">The shape of the volume affects how models are projected from camera space onto the screen.</span></span> <span data-ttu-id="bd8f7-112">最も一般的な種類の投影である透視投影では、カメラの近くにあるオブジェクトを、離れた位置のオブジェクトよりも大きく表示します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-112">The most common type of projection, a perspective projection, is responsible for making objects near the camera appear bigger than objects in the distance.</span></span> <span data-ttu-id="bd8f7-113">透視ビューの場合、視錐台は先端にカメラのある四角錐と考えることができます。これを図で表すと次のようになります。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-113">For perspective viewing, the viewing frustum can be visualized as a pyramid, with the camera positioned at the tip as shown in the following illustration.</span></span> <span data-ttu-id="bd8f7-114">この四角錐は、前方および後方のクリッピング面と交差します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-114">This pyramid is intersected by a front and back clipping plane.</span></span> <span data-ttu-id="bd8f7-115">四角錐を前方と後方のクリッピング面で切り取ったボリュームが、視錐台です。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-115">The volume within the pyramid between the front and back clipping planes is the viewing frustum.</span></span> <span data-ttu-id="bd8f7-116">オブジェクトは、このボリュームの内部にある場合にのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-116">Objects are visible only when they are in this volume.</span></span>

![視錐台と前方および後方のクリッピング面を表した図](images/frustum.png)

<span data-ttu-id="bd8f7-118">暗い部屋に立って正方形の窓から外を眺めたところを想像すると、視錐台のイメージがよくわかります。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-118">If you imagine that you are standing in a dark room and looking through a square window, you are visualizing a viewing frustum.</span></span> <span data-ttu-id="bd8f7-119">この例では、前方のクリッピング面は窓であり、後方のクリッピング面は視界を最終的に遮るものになります。たとえば、道路の向こうにある高層ビルや、遠くに見える山並みの場合もあれば、何もない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-119">In this analogy, the near clipping plane is the window, and the back clipping plane is whatever finally interrupts your view - the skyscraper across the street, the mountains in the distance, or nothing at all.</span></span> <span data-ttu-id="bd8f7-120">四角錐の窓から視界を遮るものまでの間を切り取った内部はすべて見渡すことができ、それ以外の部分は何も見えません。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-120">You can see everything inside the truncated pyramid that starts at the window and ends with whatever interrupts your view, and you can see nothing else.</span></span>

<span data-ttu-id="bd8f7-121">視錐台は、fov (視野) と、z 座標で指定される前方クリッピング面と後方クリッピング面の間の距離によって定義されます。これを次の図に示します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-121">The viewing frustum is defined by fov (field of view) and by the distances of the front and back clipping planes, specified in z-coordinates, as shown in the following diagram.</span></span>

![視錐台の図](images/fovdiag.png)

<span data-ttu-id="bd8f7-123">この図において変数 D は、カメラから、ジオメトリ パイプラインの直前の部分 (ビュー変換) で定義された空間の原点までの距離を表します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-123">In this diagram, the variable D is the distance from the camera to the origin of the space that was defined in the last part of the geometry pipeline - the viewing transformation.</span></span> <span data-ttu-id="bd8f7-124">この空間の周りに視錐台の限界を設定します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-124">This is the space around which you arrange the limits of your viewing frustum.</span></span> <span data-ttu-id="bd8f7-125">この変数 D が射影行列の構築時にどのように使われるかについては、「[射影変換](projection-transform.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-125">For information about how this D variable is used to build the projection matrix, see the [Projection transform](projection-transform.md)</span></span>

## <a name="span-idviewportrectanglespanspan-idviewportrectanglespanspan-idviewportrectanglespanviewport-rectangle"></a><span data-ttu-id="bd8f7-126"><span id="Viewport_Rectangle"></span><span id="viewport_rectangle"></span><span id="VIEWPORT_RECTANGLE"></span>ビューポート矩形</span><span class="sxs-lookup"><span data-stu-id="bd8f7-126"><span id="Viewport_Rectangle"></span><span id="viewport_rectangle"></span><span id="VIEWPORT_RECTANGLE"></span>Viewport Rectangle</span></span>


<span data-ttu-id="bd8f7-127">ビューポート構造体には、シーンのレンダリング先となるレンダー ターゲット サーフェスの領域を定義する 4 つのメンバー (X、Y、Width、Height) が含まれています。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-127">A viewport struct contains four members (X, Y, Width, Height) that define the area of the render-target surface into which a scene will be rendered.</span></span> <span data-ttu-id="bd8f7-128">これらの値は、次の図に示すように、出力先の四角形、つまりビューポート矩形に対応します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-128">These values correspond to the destination rectangle, or viewport rectangle, as shown in the following diagram.</span></span>

![ビューポート矩形の図](images/destrect.png)

<span data-ttu-id="bd8f7-130">X、Y、Width、Height の各メンバーに指定する値は、レンダー ターゲット サーフェスの左上隅を基準とした相対的なスクリーン座標です。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-130">The values you specify for the X, Y, Width, Height members are screen coordinates relative to the upper-left corner of the render-target surface.</span></span> <span data-ttu-id="bd8f7-131">構造体には他に、シーンがレンダリングされる深度範囲を示す 2 つのメンバー (MinZ と MaxZ) も定義されています。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-131">The structure defines two additional members (MinZ and MaxZ) that indicate the depth-ranges into which the scene will be rendered.</span></span>

<span data-ttu-id="bd8f7-132">Direct3D では、ビューポートのクリッピング ボリュームの範囲として、X は -1.0 ～ 1.0、Y は 1.0 ～ -1.0 を想定しています。これらは、過去のアプリケーションで最もよく使われた設定です。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-132">Direct3D assumes that the viewport clipping volume ranges from -1.0 to 1.0 in X, and from 1.0 to -1.0 in Y. These were the settings used most often by applications in the past.</span></span> <span data-ttu-id="bd8f7-133">クリッピングの前に[射影変換](projection-transform.md)を使うことで、ビューポートの縦横比を調整できます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-133">You can adjust the viewport aspect ratio before clipping using the [projection transform](projection-transform.md).</span></span>

<span data-ttu-id="bd8f7-134">**注:**  MinZ と MaxZ にシーンがレンダリングされる深度範囲を示すし、クリッピングは使われません。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-134">**Note** MinZ and MaxZ indicate the depth-ranges into which the scene will be rendered and are not used for clipping.</span></span> <span data-ttu-id="bd8f7-135">ほとんどのアプリケーションでは、システムが深度バッファー内の深度値の範囲全体をレンダリングできるように、これらの値を 0.0 と 1.0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-135">Most applications will set these values to 0.0 and 1.0, to enable the system to render to the entire range of depth values in the depth buffer.</span></span> <span data-ttu-id="bd8f7-136">場合によっては、他の深度範囲を使って特殊効果を実現することもできます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-136">In some cases, you can achieve special effects by using other depth ranges.</span></span> <span data-ttu-id="bd8f7-137">たとえば、ゲームのヘッドアップ ディスプレイをレンダリングする場合、両方の値を 0.0 に設定すると、シーン内のオブジェクトを強制的に前面にレンダリングできます。または、両方を 1.0 に設定すると、常に背面に置く必要のあるオブジェクトをレンダリングできます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-137">For instance, to render a heads-up display in a game, you can set both values to 0.0 to force the system to render objects in a scene in the foreground, or you might set them both to 1.0 to render an object that should always be in the background.</span></span>

 

<span data-ttu-id="bd8f7-138">ビューポート構造体の X、Y、Width、Height の各メンバーで使われる寸法は、レンダー ターゲット サーフェス上のビューポートの位置とサイズを定義します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-138">The dimensions used in the X, Y, Width, Height members of a viewport struct define the location and dimensions of the viewport on the render-target surface.</span></span> <span data-ttu-id="bd8f7-139">これらの値は、サーフェスの左上隅を基準とした相対的なスクリーン座標を示します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-139">These values are in screen coordinates, relative to the upper-left corner of the surface.</span></span>

<span data-ttu-id="bd8f7-140">Direct3D は、ビューポートの位置とサイズを使って頂点をスケーリングし、レンダリングするシーンをターゲット サーフェス上の適切な位置に配置します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-140">Direct3D uses the viewport location and dimensions to scale the vertices to fit a rendered scene into the appropriate location on the target surface.</span></span> <span data-ttu-id="bd8f7-141">Direct3D の内部では、これらの値が次の行列に挿入され、各頂点に適用されます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-141">Internally, Direct3D inserts these values into the following matrix that is applied to each vertex.</span></span>

![各頂点に適用される行列](images/vpscale.png)

<span data-ttu-id="bd8f7-143">この行列は、ビューポートのサイズと指定の深度範囲に従って頂点をスケーリングし、レンダー ターゲット サーフェスの適切な位置に平行移動します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-143">This matrix scales vertices according to the viewport dimensions and desired depth range and translates them to the appropriate location on the render-target surface.</span></span> <span data-ttu-id="bd8f7-144">また、この行列は、左上隅のスクリーン原点から y を下方へ増やした位置を反映するように y 軸を反転します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-144">The matrix also flips the y-coordinate to reflect a screen origin at the top-left corner with y increasing downward.</span></span> <span data-ttu-id="bd8f7-145">この行列が適用された後も、頂点は同次です。つまり、各頂点は引き続き \[x,y,z,w\] 頂点として存在するため、ラスタライザーに送信する前に非同次の座標に変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-145">After this matrix is applied, vertices are still homogeneous - that is, they still exist as \[x,y,z,w\] vertices - and they must be converted to non-homogeneous coordinates before being sent to the rasterizer.</span></span>

<span data-ttu-id="bd8f7-146">**注:** アプリケーション通常 MinZ と MaxZ を設定 0.0 と 1.0 それぞれに、システムに深度範囲全体をレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-146">**Note** Applications typically set MinZ and MaxZ to 0.0 and 1.0 respectively to cause the system to render to the entire depth range.</span></span> <span data-ttu-id="bd8f7-147">ただし、他の値を使って特定の効果を得ることもできます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-147">However, you can use other values to achieve certain affects.</span></span> <span data-ttu-id="bd8f7-148">たとえば、両方の値を 0.0 に設定してすべてのオブジェクトを強制的に前面に配置したり、両方を 1.0 に設定してすべてのオブジェクトを背面にレンダリングしたりできます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-148">For example, you might set both values to 0.0 to force all objects into the foreground, or set both to 1.0 to render all objects into the background.</span></span>

 

## <a name="span-idclearingaviewportspanspan-idclearingaviewportspanspan-idclearingaviewportspanclearing-a-viewport"></a><span data-ttu-id="bd8f7-149"><span id="Clearing_a_Viewport"></span><span id="clearing_a_viewport"></span><span id="CLEARING_A_VIEWPORT"></span>ビューポートのクリア</span><span class="sxs-lookup"><span data-stu-id="bd8f7-149"><span id="Clearing_a_Viewport"></span><span id="clearing_a_viewport"></span><span id="CLEARING_A_VIEWPORT"></span>Clearing a Viewport</span></span>


<span data-ttu-id="bd8f7-150">ビューポートをクリアすると、レンダー ターゲット サーフェス上のビューポート矩形の内容がリセットされます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-150">Clearing the viewport resets the contents of the viewport rectangle on the render-target surface.</span></span> <span data-ttu-id="bd8f7-151">さらに、深度バッファー サーフェスとステンシル バッファー サーフェスの矩形もクリアできます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-151">It can also clear the rectangle in the depth and stencil buffer surfaces.</span></span>

## <a name="span-idsetuptheviewportforclippingspanspan-idsetuptheviewportforclippingspanspan-idsetuptheviewportforclippingspanset-up-the-viewport-for-clipping"></a><span data-ttu-id="bd8f7-152"><span id="Set_Up_the_Viewport_for_Clipping"></span><span id="set_up_the_viewport_for_clipping"></span><span id="SET_UP_THE_VIEWPORT_FOR_CLIPPING"></span>ビューポートのクリッピングの設定</span><span class="sxs-lookup"><span data-stu-id="bd8f7-152"><span id="Set_Up_the_Viewport_for_Clipping"></span><span id="set_up_the_viewport_for_clipping"></span><span id="SET_UP_THE_VIEWPORT_FOR_CLIPPING"></span>Set Up the Viewport for Clipping</span></span>


<span data-ttu-id="bd8f7-153">射影行列の結果によって、次のように射影空間のクリッピング ボリュームが決まります。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-153">The results of the projection matrix determine the clipping volume in projection space as:</span></span>

<span data-ttu-id="bd8f7-154">-w<sub>c</sub>&lt;= x<sub>c</sub>&lt;= w<sub>c</sub></span><span class="sxs-lookup"><span data-stu-id="bd8f7-154">-w<sub>c</sub>&lt;= x<sub>c</sub>&lt;= w<sub>c</sub></span></span>

<span data-ttu-id="bd8f7-155">-w<sub>c</sub>&lt;= y<sub>c</sub>&lt;= w<sub>c</sub></span><span class="sxs-lookup"><span data-stu-id="bd8f7-155">-w<sub>c</sub>&lt;= y<sub>c</sub>&lt;= w<sub>c</sub></span></span>

<span data-ttu-id="bd8f7-156">0 &lt;= z<sub>c</sub>&lt;= w<sub>c</sub></span><span class="sxs-lookup"><span data-stu-id="bd8f7-156">0 &lt;= z<sub>c</sub>&lt;= w<sub>c</sub></span></span>

<span data-ttu-id="bd8f7-157">x、y、z、w は、射影変換が適用された後の頂点の座標を表します。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-157">Where: x, y, z, and w represent the vertex coordinates after the projection transformation is applied.</span></span> <span data-ttu-id="bd8f7-158">クリッピングが有効な場合 (既定の動作)、x、y、z の各要素がこれらの範囲外にある頂点はすべてクリッピングされます。</span><span class="sxs-lookup"><span data-stu-id="bd8f7-158">Any vertices that have an x-, y-, or z-component outside these ranges are clipped, if clipping is enabled (the default behavior).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="bd8f7-159"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="bd8f7-159"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="bd8f7-160">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="bd8f7-160">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




