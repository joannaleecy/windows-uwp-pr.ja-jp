---
title: ビュー変換
description: ビュー変換は、ビューアーをワールド空間に配置し、頂点をカメラ空間に変換します。
ms.assetid: DA4C2051-4C28-4ABF-8C06-241C8CB87F2F
keywords:
- ビュー変換
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 63660883f327547a82eac4a3accec475995a651a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593587"
---
# <a name="view-transform"></a><span data-ttu-id="ea63e-104">ビュー変換</span><span class="sxs-lookup"><span data-stu-id="ea63e-104">View transform</span></span>


<span data-ttu-id="ea63e-105">"*ビュー変換*" は、ビューアーをワールド空間に配置し、頂点をカメラ空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-105">A *view transform* locates the viewer in world space, transforming vertices into camera space.</span></span> <span data-ttu-id="ea63e-106">カメラ空間では、カメラつまりビューアーは原点に位置し、Z 軸の正方向を向いています。</span><span class="sxs-lookup"><span data-stu-id="ea63e-106">In camera space, the camera, or viewer, is at the origin, looking in the positive z-direction.</span></span> <span data-ttu-id="ea63e-107">ビュー行列は、ワールド内のオブジェクトを、カメラの位置 (カメラ空間の原点) と方向を中心として再配置します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-107">The view matrix relocates the objects in the world around a camera's position - the origin of camera space - and orientation.</span></span> <span data-ttu-id="ea63e-108">Direct3D では左手座標系が使われるため、z はシーンの奥へ向かうのが正方向となります。</span><span class="sxs-lookup"><span data-stu-id="ea63e-108">Direct3D uses a left-handed coordinate system, so z is positive into a scene.</span></span>

<span data-ttu-id="ea63e-109">ビュー行列を作成する方法は数多くあります。</span><span class="sxs-lookup"><span data-stu-id="ea63e-109">There are many ways to create a view matrix.</span></span> <span data-ttu-id="ea63e-110">どの場合も、カメラにはワールド空間での論理的な位置と方向があり、シーン内のモデルに適用されるビュー行列を作成する開始点として使われます。</span><span class="sxs-lookup"><span data-stu-id="ea63e-110">In all cases, the camera has some logical position and orientation in world space that is used as a starting point to create a view matrix that will be applied to the models in a scene.</span></span> <span data-ttu-id="ea63e-111">ビュー行列は、オブジェクトに平行移動と回転を適用し、カメラを原点とするカメラ空間に配置します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-111">The view matrix translates and rotates objects to place them in camera space, where the camera is at the origin.</span></span> <span data-ttu-id="ea63e-112">ビュー行列を作成する方法の 1 つとして、平行移動行列と各軸に対する回転行列を結合する方法があります。</span><span class="sxs-lookup"><span data-stu-id="ea63e-112">One way to create a view matrix is to combine a translation matrix with rotation matrices for each axis.</span></span> <span data-ttu-id="ea63e-113">この方法では、次の一般的な行列方程式が適用されます。</span><span class="sxs-lookup"><span data-stu-id="ea63e-113">In this approach, the following general matrix equation applies.</span></span>

![ビュー変換の方程式](images/viewtran.png)

<span data-ttu-id="ea63e-115">この式では、V は作成されるビュー行列、T はワールド内のオブジェクトを再配置する平行移動行列、Rₓ ～ R<sub>z</sub> はオブジェクトを x 軸、y 軸、z 軸周りに回転させる回転行列を表します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-115">In this formula, V is the view matrix being created, T is a translation matrix that repositions objects in the world, and Rₓ through R<sub>z</sub> are rotation matrices that rotate objects along the x-, y-, and z-axis.</span></span> <span data-ttu-id="ea63e-116">平行移動行列と回転行列は、ワールド空間でのカメラの論理的な位置と方向に基づきます。</span><span class="sxs-lookup"><span data-stu-id="ea63e-116">The translation and rotation matrices are based on the camera's logical position and orientation in world space.</span></span> <span data-ttu-id="ea63e-117">つまり、ワールド内でのカメラの論理的な位置を &lt;10,20,100&gt; とすると、平行移動行列の目的は、オブジェクトを x 軸に沿って -10 単位、y 軸に沿って -20 単位、z 軸に沿って -100 単位移動させることになります。</span><span class="sxs-lookup"><span data-stu-id="ea63e-117">So, if the camera's logical position in the world is &lt;10,20,100&gt;, the aim of the translation matrix is to move objects -10 units along the x-axis, -20 units along the y-axis, and -100 units along the z-axis.</span></span> <span data-ttu-id="ea63e-118">この式の回転行列は、カメラの方向を基準として、カメラ空間の軸がワールド空間からどの程度ずれた角度に回転されるかを表します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-118">The rotation matrices in the formula are based on the camera's orientation, in terms of how much the axes of camera space are rotated out of alignment with world space.</span></span> <span data-ttu-id="ea63e-119">たとえば、先ほどのカメラが真下を向いているとすると、次の図に示すように、その z 軸はワールド空間の z 軸から 90 度 (π/2 ラジアン) ずれることになります。</span><span class="sxs-lookup"><span data-stu-id="ea63e-119">For example, if the camera mentioned earlier is pointing straight down, its z-axis is 90 degrees (pi/2 radians) out of alignment with the z-axis of world space, as shown in the following illustration.</span></span>

![カメラのビュー空間をワールド空間と比較した図](images/camtop.png)

<span data-ttu-id="ea63e-121">回転行列は、大きさが同じで方向が逆の回転をシーン内のモデルに適用します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-121">The rotation matrices apply rotations of equal, but opposite, magnitude to the models in the scene.</span></span> <span data-ttu-id="ea63e-122">このカメラのビュー行列には、x 軸を中心とした -90 度の回転が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ea63e-122">The view matrix for this camera includes a rotation of -90 degrees around the x-axis.</span></span> <span data-ttu-id="ea63e-123">回転行列は平行移動行列と結合され、シーン内のオブジェクトの上部がカメラに面するように、オブジェクトの位置と方向を調整するビュー行列が作成されます。これにより、カメラがモデルを上から見下ろすような構図が作り出されます。</span><span class="sxs-lookup"><span data-stu-id="ea63e-123">The rotation matrix is combined with the translation matrix to create a view matrix that adjusts the position and orientation of the objects in the scene so that their top is facing the camera, giving the appearance that the camera is above the model.</span></span>

## <a name="span-idsettingupaviewmatrixspanspan-idsettingupaviewmatrixspanspan-idsettingupaviewmatrixspansetting-up-a-view-matrix"></a><span data-ttu-id="ea63e-124"><span id="Setting_Up_a_View_Matrix"></span><span id="setting_up_a_view_matrix"></span><span id="SETTING_UP_A_VIEW_MATRIX"></span>ビュー行列の設定</span><span class="sxs-lookup"><span data-stu-id="ea63e-124"><span id="Setting_Up_a_View_Matrix"></span><span id="setting_up_a_view_matrix"></span><span id="SETTING_UP_A_VIEW_MATRIX"></span>Setting Up a View Matrix</span></span>


<span data-ttu-id="ea63e-125">Direct3D は、ワールド行列とビュー行列を使っていくつかの内部データ構造を構成します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-125">Direct3D uses the world and view matrices to configure several internal data structures.</span></span> <span data-ttu-id="ea63e-126">新しいワールド行列またはビュー行列を設定するたびに、関連付けられた内部構造がシステムによって再計算されます。</span><span class="sxs-lookup"><span data-stu-id="ea63e-126">Each time you set a new world or view matrix, the system recalculates the associated internal structures.</span></span> <span data-ttu-id="ea63e-127">これらの行列を頻繁に設定すると、計算に時間を要することになります。</span><span class="sxs-lookup"><span data-stu-id="ea63e-127">Setting these matrices frequently is computationally time-consuming.</span></span> <span data-ttu-id="ea63e-128">必要な計算回数を最小限に抑えるには、ワールド行列とビュー行列を連結して 1 つのワールド ビュー行列を作成し、それをワールド行列として設定した後、ビュー行列を単位元に設定します。</span><span class="sxs-lookup"><span data-stu-id="ea63e-128">You can minimize the number of required calculations by concatenating your world and view matrices into a world-view matrix that you set as the world matrix, and then setting the view matrix to the identity.</span></span> <span data-ttu-id="ea63e-129">このとき、必要に応じてワールド行列を変更、連結、リセットできるように、個々のワールド行列とビュー行列のキャッシュ コピーを保持しておくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ea63e-129">Keep cached copies of individual world and view matrices that you can modify, concatenate, and reset the world matrix as needed.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="ea63e-130"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="ea63e-130"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="ea63e-131">変換</span><span class="sxs-lookup"><span data-stu-id="ea63e-131">Transforms</span></span>](transforms.md)

 

 




