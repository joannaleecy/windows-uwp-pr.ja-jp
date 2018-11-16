---
title: 射影トランスフォーム
description: 射影トランスフォームは、カメラの内部を制御します。つまり、カメラのレンズを選ぶことと似ています。 このトランスフォームは、3 種類のトランスフォームの中で最も複雑です。
ms.assetid: 378F205D-3800-4477-9820-5EBE6528B14A
keywords:
- 射影トランスフォーム
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 01a410e0e2759dcdfd6adff9c25238447fe4138b
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6838270"
---
# <a name="projection-transform"></a><span data-ttu-id="318b9-105">射影トランスフォーム</span><span class="sxs-lookup"><span data-stu-id="318b9-105">Projection transform</span></span>


<span data-ttu-id="318b9-106">"射影変換"\*\* はカメラの内部を制御します。これは、カメラのレンズを選択することと似ています。</span><span class="sxs-lookup"><span data-stu-id="318b9-106">A *projection transformation* controls the camera's internals, like choosing a lens for a camera.</span></span> <span data-ttu-id="318b9-107">このトランスフォームは、3 種類のトランスフォームの中で最も複雑です。</span><span class="sxs-lookup"><span data-stu-id="318b9-107">This is the most complicated of the three transformation types.</span></span>

<span data-ttu-id="318b9-108">射影行列とは、通常、スケーリングおよび遠近法による射影です。</span><span class="sxs-lookup"><span data-stu-id="318b9-108">The projection matrix is typically a scale and perspective projection.</span></span> <span data-ttu-id="318b9-109">射影トランスフォームでは、視錐台を立方体に変換します。</span><span class="sxs-lookup"><span data-stu-id="318b9-109">The projection transformation converts the viewing frustum into a cuboid shape.</span></span> <span data-ttu-id="318b9-110">視錐台の近くの端は遠くの端よりも小さいので、このトランスフォームにはカメラの近くのオブジェクトを拡大するという効果があり、これによってシーンに遠近感が生まれます。</span><span class="sxs-lookup"><span data-stu-id="318b9-110">Because the near end of the viewing frustum is smaller than the far end, this has the effect of expanding objects that are near to the camera; this is how perspective is applied to the scene.</span></span>

<span data-ttu-id="318b9-111">[視錘台](viewports-and-clipping.md)では、ビュー トランスフォーム空間の原点とカメラの間の距離が任意の値 D として定義され、射影行列は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="318b9-111">In [the viewing frustum](viewports-and-clipping.md), the distance between the camera and the origin of the viewing transform space is defined arbitrarily as D, so the projection matrix looks like the following illustration.</span></span>

![射影行列の図](images/projmat1.png)

<span data-ttu-id="318b9-113">ビュー行列は、z 方向に - D だけ平行移動することによって、カメラを原点に平行移動します。平行移動行列は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="318b9-113">The viewing matrix translates the camera to the origin by translating in the z direction by - D. The translation matrix is like the following illustration.</span></span>

![平行移動行列の図](images/projmat2.png)

<span data-ttu-id="318b9-115">平行移動行列に射影行列を乗算 (T\*P) すると、それらを合成した射影行列ができます。これは、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="318b9-115">Multiplying the translation matrix by the projection matrix (T\*P) gives the composite projection matrix, as shown in the following illustration.</span></span>

![合成した射影行列の図](images/projmat3.png)

<span data-ttu-id="318b9-117">次の図は、パースペクティブ (遠近投影) トランスフォームで視錐台を新しい座標空間に変換する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="318b9-117">The perspective transform converts a viewing frustum into a new coordinate space.</span></span> <span data-ttu-id="318b9-118">視錐台が立方体になること、およびシーンの右上角にあった原点が中心に移動することに注目してください。</span><span class="sxs-lookup"><span data-stu-id="318b9-118">Notice that the frustum becomes cuboid and also that the origin moves from the upper-right corner of the scene to the center, as shown in the following diagram.</span></span>

![パースペクティブ トランスフォームで視錐台を新しい座標空間に変更する方法の図](images/cuboid.png)

<span data-ttu-id="318b9-120">パースペクティブ トランスフォームでは、x 方向と y 方向の限界は -1 と 1 です。</span><span class="sxs-lookup"><span data-stu-id="318b9-120">In the perspective transform, the limits of the x- and y-directions are -1 and 1.</span></span> <span data-ttu-id="318b9-121">z 方向の限界は、前方面については 0 で、後方面については 1 です。</span><span class="sxs-lookup"><span data-stu-id="318b9-121">The limits of the z-direction are 0 for the front plane and 1 for the back plane.</span></span>

<span data-ttu-id="318b9-122">この行列は、カメラから付近のクリップ面まで、指定された距離に基づいてオブジェクトを平行移動およびスケーリングします。しかし、この行列は視野 (fov) を考慮せず、遠くのオブジェクトに対して生成する z 値はほとんど同じになる可能性があるので、深度比較が困難になります。</span><span class="sxs-lookup"><span data-stu-id="318b9-122">This matrix translates and scales objects based on a specified distance from the camera to the near clipping plane, but it doesn't consider the field of view (fov), and the z-values that it produces for objects in the distance can be nearly identical, making depth comparisons difficult.</span></span> <span data-ttu-id="318b9-123">この問題を解決するために、次の行列は、ビューポートのアスペクト比を考慮して頂点を調整し、アスペクト比をパースペクティブ射影に合わせます。</span><span class="sxs-lookup"><span data-stu-id="318b9-123">The following matrix addresses these issues, and it adjusts vertices to account for the aspect ratio of the viewport, making it a good choice for the perspective projection.</span></span>

![パースペクティブ射影の行列の図](images/prjmatx1.png)

<span data-ttu-id="318b9-125">この行列では、Zₙ は付近のクリップ面の z 値です。</span><span class="sxs-lookup"><span data-stu-id="318b9-125">In this matrix, Zₙ is the z-value of the near clipping plane.</span></span> <span data-ttu-id="318b9-126">変数 w、h、および Q には、次のような意味があります。</span><span class="sxs-lookup"><span data-stu-id="318b9-126">The variables w, h, and Q have the following meanings.</span></span> <span data-ttu-id="318b9-127">fov<sub>w</sub> および fovₖ は、ビューポートの水平方向および垂直方向の視野を表します (ラジアン単位)。</span><span class="sxs-lookup"><span data-stu-id="318b9-127">Note that fov<sub>w</sub> and fovₖ represent the viewport's horizontal and vertical fields of view, in radians.</span></span>

![変数の意味の公式](images/prjmatx2.png)

<span data-ttu-id="318b9-129">アプリケーションでは、視野角度を使って x と y のスケール係数を定義することは、ビューポートの水平寸法と垂直寸法 (カメラ空間の) を使用するのに比べて不便な場合があります。</span><span class="sxs-lookup"><span data-stu-id="318b9-129">For your application, using field-of-view angles to define the x- and y-scaling coefficients might not be as convenient as using the viewport's horizontal and vertical dimensions (in camera space).</span></span> <span data-ttu-id="318b9-130">数値演算として、次に示す w と h の 2 つの式ではビューポートの寸法を使用します。これらの式は上の公式と同等です。</span><span class="sxs-lookup"><span data-stu-id="318b9-130">As the math works out, the following two equations for w and h use the viewport's dimensions, and are equivalent to the preceding equations.</span></span>

![w および h 変数の意味の公式](images/prjmatx3.png)

<span data-ttu-id="318b9-132">これらの式では、Zₙ は付近のクリップ面の位置を表し、変数 V<sub>w</sub> と Vₕ はカメラ空間でのビューポートの幅と高さを表しています。</span><span class="sxs-lookup"><span data-stu-id="318b9-132">In these formulas, Zₙ represents the position of the near clipping plane, and the V<sub>w</sub> and Vₕ variables represent the width and height of the viewport, in camera space.</span></span>

<span data-ttu-id="318b9-133">どの式を使用する場合でも、必ず、Zₙ をできるだけ大きな値に設定します。カメラに極端に近い z 値は大幅には変化しないからです。</span><span class="sxs-lookup"><span data-stu-id="318b9-133">Whatever formula you decide to use, be sure to set Zₙ to as large a value as possible, because z-values extremely close to the camera don't vary by much.</span></span> <span data-ttu-id="318b9-134">これにより、16 ビットの z バッファーを使う深度比較は多少複雑になります。</span><span class="sxs-lookup"><span data-stu-id="318b9-134">This makes depth comparisons using 16-bit z-buffers somewhat complicated.</span></span>

## <a name="span-idawfriendlyprojectionmatrixspanspan-idawfriendlyprojectionmatrixspanspan-idawfriendlyprojectionmatrixspana-w-friendly-projection-matrix"></a><span data-ttu-id="318b9-135"><span id="A_W_Friendly_Projection_Matrix"></span><span id="a_w_friendly_projection_matrix"></span><span id="A_W_FRIENDLY_PROJECTION_MATRIX"></span>w バッファーに有効な射影行列</span><span class="sxs-lookup"><span data-stu-id="318b9-135"><span id="A_W_Friendly_Projection_Matrix"></span><span id="a_w_friendly_projection_matrix"></span><span id="A_W_FRIENDLY_PROJECTION_MATRIX"></span>A w-friendly projection matrix</span></span>


<span data-ttu-id="318b9-136">Direct3D では、ワールド行列、ビュー行列、および射影行列によって変換された頂点の ｗ 成分を利用して、深度バッファーまたはフォグ エフェクトの計算を深度をベースに実行できます。</span><span class="sxs-lookup"><span data-stu-id="318b9-136">Direct3D can use the w-component of a vertex that has been transformed by the world, view, and projection matrices to perform depth-based calculations in depth-buffer or fog effects.</span></span> <span data-ttu-id="318b9-137">このような計算では、射影行列で w を正規化して、ワールド空間の z と等価にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="318b9-137">Computations such as these require that your projection matrix normalize w to be equivalent to world-space z.</span></span> <span data-ttu-id="318b9-138">つまり、射影行列に 1 ではない (3,4) 係数が含まれる場合、(3,4) 係数の逆数を使ってすべての係数をスケーリングすることで、適切な行列を作成しなければなりません。</span><span class="sxs-lookup"><span data-stu-id="318b9-138">In short, if your projection matrix includes a (3,4) coefficient that is not 1, you must scale all the coefficients by the inverse of the (3,4) coefficient to make a proper matrix.</span></span> <span data-ttu-id="318b9-139">対応していない行列を使用すると、フォグ エフェクトと深度バッファーが正しく適用されません。</span><span class="sxs-lookup"><span data-stu-id="318b9-139">If you don't provide a compliant matrix, fog effects and depth buffering are not applied correctly.</span></span>

<span data-ttu-id="318b9-140">次の図は、対応していない射影行列、および同じ行列をスケーリングして視点との相対フォグが有効になるようにした行列を示しています。</span><span class="sxs-lookup"><span data-stu-id="318b9-140">The following illustration shows a noncompliant projection matrix, and the same matrix scaled so that eye-relative fog will be enabled.</span></span>

![対応していない射影行列、および視点との相対フォグが有効になっている行列の図](images/eyerlmx.png)

<span data-ttu-id="318b9-142">上の図では、すべての変数がゼロ以外の値であるとします。</span><span class="sxs-lookup"><span data-stu-id="318b9-142">In the preceding matrices, all variables are assumed to be nonzero.</span></span> <span data-ttu-id="318b9-143">w ベースの深度バッファリングについて詳しくは、「[深度バッファー](depth-buffers.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="318b9-143">For information about w-based depth buffering, see [Depth buffers](depth-buffers.md).</span></span>

<span data-ttu-id="318b9-144">Direct3D では、現在設定されている射影行列を使って w ベース深度の計算を実行します。</span><span class="sxs-lookup"><span data-stu-id="318b9-144">Direct3D uses the currently set projection matrix in its w-based depth calculations.</span></span> <span data-ttu-id="318b9-145">したがって、トランスフォームで Direct3D を使用しない場合であっても、アプリケーションでは、目的の w ベース機能を取得するために適切な射影行列を設定しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="318b9-145">As a result, applications must set a compliant projection matrix to receive the desired w-based features, even if they do not use Direct3D for transforms.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="318b9-146"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="318b9-146"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="318b9-147">変換</span><span class="sxs-lookup"><span data-stu-id="318b9-147">Transforms</span></span>](transforms.md)

 

 




