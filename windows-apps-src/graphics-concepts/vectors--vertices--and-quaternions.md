---
title: ベクター、頂点、四元数
description: Direct3D では、頂点は位置と方向を表します。 プリミティブの各頂点は、位置を決定するベクトル、色、テクスチャ座標、および方向を決定する法線ベクトルによって示されます。
ms.assetid: 94EC3D59-43FC-4509-A233-916E9FA8381E
keywords:
- ベクター、頂点、四元数
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 2373d18b51015652bc1ef3035402e1da95a54abf
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/21/2018
ms.locfileid: "7432450"
---
# <a name="vectors-vertices-and-quaternions"></a><span data-ttu-id="f1bca-105">ベクター、頂点、四元数</span><span class="sxs-lookup"><span data-stu-id="f1bca-105">Vectors, vertices, and quaternions</span></span>


<span data-ttu-id="f1bca-106">Direct3D では、頂点は位置と方向を表します。</span><span class="sxs-lookup"><span data-stu-id="f1bca-106">Throughout Direct3D, vertices describe position and orientation.</span></span> <span data-ttu-id="f1bca-107">プリミティブの各頂点は、位置を決定するベクトル、色、テクスチャ座標、および方向を決定する法線ベクトルによって示されます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-107">Each vertex in a primitive is described by a vector that gives its position, color, texture coordinates, and a normal vector that gives its orientation.</span></span>

<span data-ttu-id="f1bca-108">四元数は、3 要素のベクトルを定義する \[x, y, z\] の値に 4 つ目の要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="f1bca-108">Quaternions add a fourth element to the \[x, y, z\] values that define a three-component-vector.</span></span> <span data-ttu-id="f1bca-109">四元数は、3D 回転で一般的に使われている、行列による方法の代わりとなるものです。</span><span class="sxs-lookup"><span data-stu-id="f1bca-109">Quaternions are an alternative to the matrix methods that are typically used for 3D rotations.</span></span> <span data-ttu-id="f1bca-110">四元数は、3D 空間内の 1 つの軸と、その軸を中心とした回転を表します。</span><span class="sxs-lookup"><span data-stu-id="f1bca-110">A quaternion represents an axis in 3D space and a rotation around that axis.</span></span> <span data-ttu-id="f1bca-111">たとえば、1 つの四元数で、軸 (1,1,2) と 1 ラジアンの回転を表すことができます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-111">For example, a quaternion might represent a (1,1,2) axis and a rotation of 1 radian.</span></span> <span data-ttu-id="f1bca-112">四元数は有用な情報を伝達しますが、その真価が発揮されるのは、四元数に対して合成と補間という 2 つの操作を実行する場合です。</span><span class="sxs-lookup"><span data-stu-id="f1bca-112">Quaternions carry valuable information, but their true power comes from the two operations that you can perform on them: composition and interpolation.</span></span>

<span data-ttu-id="f1bca-113">四元数に対する合成の実行は、四元数を結合する操作と似ています。</span><span class="sxs-lookup"><span data-stu-id="f1bca-113">Performing composition on quaternions is similar to combining them.</span></span> <span data-ttu-id="f1bca-114">2 つの四元数の合成は次のように表記されます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-114">The composition of two quaternions is notated like the following illustration.</span></span>

![四元数の表記の図](images/quateq.png)

<span data-ttu-id="f1bca-116">2 つの四元数の合成を 1 つのジオメトリに適用することは、"ジオメトリを axis₂ を中心に rotation₂ だけ回転した後、axis₁ を中心に rotation₁ だけ回転する" ことを意味します。</span><span class="sxs-lookup"><span data-stu-id="f1bca-116">The composition of two quaternions applied to a geometry means "rotate the geometry around axis₂ by rotation₂, then rotate it around axis₁ by rotation₁."</span></span> <span data-ttu-id="f1bca-117">この場合 Q は、ジオメトリに q₂ を適用した後に q₁ を適用した結果となる、1 つの軸を中心とした回転を表します。</span><span class="sxs-lookup"><span data-stu-id="f1bca-117">In this case, Q represents a rotation around a single axis that is the result of applying q₂, then q₁ to the geometry.</span></span>

<span data-ttu-id="f1bca-118">四元数の補間を使うと、1 つの軸と方向から別の軸と方向への滑らかで適切なパスをアプリケーションで計算できます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-118">Using quaternion interpolation, an application can calculate a smooth and reasonable path from one axis and orientation to another.</span></span> <span data-ttu-id="f1bca-119">したがって、q₁ と q₂ の間を補完すれば、1 つの方向から別の方向へのアニメーションを簡単に実現できます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-119">Therefore, interpolation between q₁ and q₂ provides a simple way to animate from one orientation to another.</span></span>

<span data-ttu-id="f1bca-120">合成と補間を同時に使うと、複雑に見えるジオメトリの操作を簡単な方法で実行できます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-120">When you use composition and interpolation together, they provide you with a simple way to manipulate a geometry in a manner that appears complex.</span></span> <span data-ttu-id="f1bca-121">たとえば、ジオメトリを特定の方向に回転させる場合を考えます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-121">For example, imagine that you have a geometry that you want to rotate to a given orientation.</span></span> <span data-ttu-id="f1bca-122">axis₂ を中心に r₂ 度回転させた後、axis₁ を中心に r₁ 度回転させようとしていますが、最終的な四元数はわかっていません。</span><span class="sxs-lookup"><span data-stu-id="f1bca-122">You know that you want to rotate it r₂ degrees around axis₂, then rotate it r₁ degrees around axis₁, but you don't know the final quaternion.</span></span> <span data-ttu-id="f1bca-123">合成を使えば、ジオメトリに対する 2 つの回転を結合して、結果を表す単一の四元数を得ることができます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-123">By using composition, you could combine the two rotations on the geometry to get a single quaternion that is the result.</span></span> <span data-ttu-id="f1bca-124">さらに、元の四元数から合成後の四元数までを補間すると、あるジオメトリから別のジオメトリへの滑らかな遷移を実現できます。</span><span class="sxs-lookup"><span data-stu-id="f1bca-124">Then, you could interpolate from the original to the composed quaternion to achieve a smooth transition from one to the other.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="f1bca-125"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="f1bca-125"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="f1bca-126">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="f1bca-126">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




