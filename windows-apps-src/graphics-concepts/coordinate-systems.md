---
title: 座標系
description: 通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。 いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。
ms.assetid: 138D9B81-146F-4E9F-B742-1EDED8FBF2AE
keywords:
- 座標系
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: f85bf490bd1dd68e2d0ba31335f2fc0f89fe27b0
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8944057"
---
# <a name="coordinate-systems"></a><span data-ttu-id="41074-105">座標系</span><span class="sxs-lookup"><span data-stu-id="41074-105">Coordinate systems</span></span>


<span data-ttu-id="41074-106">通常、3D グラフィック アプリケーションでは、2 種類のデカルト座標系、つまり左手系と右手系が使用されます。</span><span class="sxs-lookup"><span data-stu-id="41074-106">Typically 3D graphics applications use one of two types of Cartesian coordinate systems: left-handed or right-handed.</span></span> <span data-ttu-id="41074-107">いずれの座標系においても、x 軸の正の向きは右を指し、y 軸の正の向きは上を指します。</span><span class="sxs-lookup"><span data-stu-id="41074-107">In both coordinate systems, the positive x-axis points to the right, and the positive y-axis points up.</span></span>

## <a name="span-idleftandrighthandedcoordinatesspanspan-idleftandrighthandedcoordinatesspanspan-idleftandrighthandedcoordinatesspanleft-and-right-handed-coordinates"></a><span data-ttu-id="41074-108"><span id="Left_and_right_handed_coordinates"></span><span id="left_and_right_handed_coordinates"></span><span id="LEFT_AND_RIGHT_HANDED_COORDINATES"></span>左手と右手の座標系</span><span class="sxs-lookup"><span data-stu-id="41074-108"><span id="Left_and_right_handed_coordinates"></span><span id="left_and_right_handed_coordinates"></span><span id="LEFT_AND_RIGHT_HANDED_COORDINATES"></span>Left and right handed coordinates</span></span>


<span data-ttu-id="41074-109">どちらの方向を z 軸の正の向きが指しているかは、左手または右手の指で x 軸の正の向きを指し、指を y 軸の正の向きに曲げることによって、思い出すことができます。</span><span class="sxs-lookup"><span data-stu-id="41074-109">You can remember which direction the positive z-axis points by pointing the fingers of either your left or right hand in the positive x-direction and curling them into the positive y-direction.</span></span> <span data-ttu-id="41074-110">親指が指している方向は、自身に向かうかまたは離れる方向のいずれかとなり、その座標系の z 軸の正の向きが指す方向となります。</span><span class="sxs-lookup"><span data-stu-id="41074-110">The direction your thumb points, either toward or away from you, is the direction that the positive z-axis points for that coordinate system.</span></span> <span data-ttu-id="41074-111">次の図は、これらの 2 つの座標系を示しています。</span><span class="sxs-lookup"><span data-stu-id="41074-111">The following illustration shows these two coordinate systems.</span></span>

![左手と右手によるデカルト座標系の図](images/leftrght.png)

<span data-ttu-id="41074-113">Direct3D は、左手座標系を使用します。</span><span class="sxs-lookup"><span data-stu-id="41074-113">Direct3D uses a left-handed coordinate system.</span></span> <span data-ttu-id="41074-114">左手および右手座標が最も一般的な座標系ですが、さまざまな他の座標系が 3D ソフトウェアで使用されています。</span><span class="sxs-lookup"><span data-stu-id="41074-114">Although left-handed and right-handed coordinates are the most common systems, there is a variety of other coordinate systems used in 3D software.</span></span> <span data-ttu-id="41074-115">たとえば、y 軸がビューアーに向かうかまたはビューアーから離れる方向を指し、かつ z 軸が上を指す座標系を使用することも、3D モデリング アプリケーションでは珍しくはありません。</span><span class="sxs-lookup"><span data-stu-id="41074-115">For example, it is not unusual for 3D modeling applications to use a coordinate system in which the y-axis points toward or away from the viewer, and the z-axis points up.</span></span>

## <a name="span-idverticesandvectorsspanspan-idverticesandvectorsspanspan-idverticesandvectorsspanvertices-and-vectors"></a><span data-ttu-id="41074-116"><span id="Vertices_and_vectors"></span><span id="vertices_and_vectors"></span><span id="VERTICES_AND_VECTORS"></span>頂点とベクトル</span><span class="sxs-lookup"><span data-stu-id="41074-116"><span id="Vertices_and_vectors"></span><span id="vertices_and_vectors"></span><span id="VERTICES_AND_VECTORS"></span>Vertices and vectors</span></span>


<span data-ttu-id="41074-117">座標系が与えられると、x、y、z 座標を使って空間の点 (「頂点」) および 3D 方向 (「ベクトル」) を定義することができます。</span><span class="sxs-lookup"><span data-stu-id="41074-117">Given the coordinate system, an x, y and z coordinate can define a point in space (a "vertex"), or a 3D direction (a "vector").</span></span>

<span data-ttu-id="41074-118">頂点の集合は、線と図形を定義するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="41074-118">A collection of vertices can be used to define lines and shapes.</span></span> <span data-ttu-id="41074-119">頂点によって定義可能な最も単純なオブジェクトは[プリミティブ](primitives.md)と呼ばれ、プリミティブのセットによって定義される、より複雑なオブジェクトは「メッシュ」と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="41074-119">The simplest objects definable by vertices are called [Primitives](primitives.md), and a more complex object defined by a set of primitives is called a "mesh."</span></span>

<span data-ttu-id="41074-120">3D 座標系で定義されたメッシュに対して実行される基本的な操作は、移動、回転、拡大縮小です。</span><span class="sxs-lookup"><span data-stu-id="41074-120">The essential operations performed on meshes defined in a 3D coordinate system are translation, rotation, and scaling.</span></span> <span data-ttu-id="41074-121">これらの基本的な変換を組み合わせて、変換マトリックスを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="41074-121">You can combine these basic transformations to create a transform matrix.</span></span> <span data-ttu-id="41074-122">詳しくは、「[変換](transforms.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="41074-122">For details, see [Transforms](transforms.md).</span></span>

<span data-ttu-id="41074-123">これらの演算を組み合わせると、結果は非可換です。行列を乗算する順序が重要です。</span><span class="sxs-lookup"><span data-stu-id="41074-123">When you combine these operations, the results are not commutative; the order in which you multiply matrices is important.</span></span>

## <a name="span-idportingfromaright-handedcoordinatesystemspanspan-idportingfromaright-handedcoordinatesystemspanspan-idportingfromaright-handedcoordinatesystemspanporting-from-a-right-handed-coordinate-system"></a><span data-ttu-id="41074-124"><span id="Porting_from_a_right-handed_coordinate_system"></span><span id="porting_from_a_right-handed_coordinate_system"></span><span id="PORTING_FROM_A_RIGHT-HANDED_COORDINATE_SYSTEM"></span>右手座標系からの移植</span><span class="sxs-lookup"><span data-stu-id="41074-124"><span id="Porting_from_a_right-handed_coordinate_system"></span><span id="porting_from_a_right-handed_coordinate_system"></span><span id="PORTING_FROM_A_RIGHT-HANDED_COORDINATE_SYSTEM"></span>Porting from a right-handed coordinate system</span></span>


<span data-ttu-id="41074-125">右手座標系に基づいたアプリケーションを移植する場合、Direct3D に渡すデータに 2 つの変更を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="41074-125">If you are porting an application that is based on a right-handed coordinate system, you must make two changes to the data passed to Direct3D:</span></span>

-   <span data-ttu-id="41074-126">三角形頂点の順序を反転させて、システムがそれらの三角形頂点を正面から時計方向にトラバースするようにします。</span><span class="sxs-lookup"><span data-stu-id="41074-126">Flip the order of triangle vertices so that the system traverses them clockwise from the front.</span></span> <span data-ttu-id="41074-127">つまり、頂点が v0、v1、v2 とすると、それらを Direct3D に v0、v2、v1 として渡します。</span><span class="sxs-lookup"><span data-stu-id="41074-127">In other words, if the vertices are v0, v1, v2, pass them to Direct3D as v0, v2, v1.</span></span>
-   <span data-ttu-id="41074-128">ビュー行列を使用し、ワールド空間で z 方向に -1 のスケーリングを適用します。</span><span class="sxs-lookup"><span data-stu-id="41074-128">Use the view matrix to scale world space by -1 in the z-direction.</span></span> <span data-ttu-id="41074-129">そのためには、ビュー行列に使用している行列構造体の \_31、\_32、\_33、\_34 メンバーの符号を反転させます。</span><span class="sxs-lookup"><span data-stu-id="41074-129">To do this, flip the sign of the \_31, \_32, \_33, and \_34 member of the matrix structure that you use for your view matrix.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="41074-130"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="41074-130"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="41074-131">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="41074-131">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




