---
title: カメラの空間変換
description: カメラ空間の頂点は、オブジェクトの頂点をワールド ビュー行列で変換することによって計算します。
ms.assetid: 86EDEB95-8348-4FAA-897F-25251B32B076
keywords:
- カメラの空間変換
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9de6759fb15aef4b32a5e9022a27cab09af300f8
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5921900"
---
# <a name="camera-space-transformations"></a><span data-ttu-id="08289-104">カメラの空間変換</span><span class="sxs-lookup"><span data-stu-id="08289-104">Camera space transformations</span></span>


<span data-ttu-id="08289-105">カメラ空間の頂点は、オブジェクトの頂点をワールド ビュー行列で変換することによって計算します。</span><span class="sxs-lookup"><span data-stu-id="08289-105">Vertices in the camera space are computed by transforming the object vertices with the world view matrix.</span></span>

<span data-ttu-id="08289-106">V = V \* wvMatrix</span><span class="sxs-lookup"><span data-stu-id="08289-106">V = V \* wvMatrix</span></span>

<span data-ttu-id="08289-107">カメラ空間内の頂点の法線は、オブジェクトの法線をワールド ビュー行列の逆転置行列で変換することによって計算します。</span><span class="sxs-lookup"><span data-stu-id="08289-107">Vertex normals, in camera space, are computed by transforming the object normals with the inverse transpose of the world view matrix.</span></span> <span data-ttu-id="08289-108">ワールド ビュー行列は、正射影である場合とそうでない場合があります。</span><span class="sxs-lookup"><span data-stu-id="08289-108">The world view matrix may or may not be orthogonal.</span></span>

<span data-ttu-id="08289-109">N = N \* (wvMatrix⁻¹)<sup>T</sup></span><span class="sxs-lookup"><span data-stu-id="08289-109">N = N \* (wvMatrix⁻¹)<sup>T</sup></span></span>

<span data-ttu-id="08289-110">行列の逆変換と転置では、4 × 4 の行列を操作します。</span><span class="sxs-lookup"><span data-stu-id="08289-110">The matrix inversion and matrix transpose operate on a 4x4 matrix.</span></span> <span data-ttu-id="08289-111">乗算は、その結果得られる 4 × 4 行列の 3 × 3 部分と、法線とを結合します。</span><span class="sxs-lookup"><span data-stu-id="08289-111">The multiply combines the normal with the 3x3 portion of the resulting 4x4 matrix.</span></span>

<span data-ttu-id="08289-112">レンダリングの状態が法線の正規化に設定されている場合、頂点法線ベクトルはカメラ空間への変換の後、次のように正規化されます。</span><span class="sxs-lookup"><span data-stu-id="08289-112">If the render state is set to normalize normals, vertex normal vectors are normalized after transformation to camera space as follows:</span></span>

<span data-ttu-id="08289-113">N = norm(N)</span><span class="sxs-lookup"><span data-stu-id="08289-113">N = norm(N)</span></span>

<span data-ttu-id="08289-114">カメラ空間でのライトの位置は、光源の位置をビュー行列で変換することによって計算します。</span><span class="sxs-lookup"><span data-stu-id="08289-114">Light position in camera space is computed by transforming the light source position with the view matrix.</span></span>

<span data-ttu-id="08289-115">Lₚ = Lₚ \* vMatrix</span><span class="sxs-lookup"><span data-stu-id="08289-115">Lₚ = Lₚ \* vMatrix</span></span>

<span data-ttu-id="08289-116">指向性ライトの場合、カメラ空間でのライトへの方向は、光源の方向をビュー行列で乗算し、その結果を正規化して正負を反転することによって計算します。</span><span class="sxs-lookup"><span data-stu-id="08289-116">The direction to the light in camera space for a directional light is computed by multiplying the light source direction by the view matrix, normalizing, and negating the result.</span></span>

<span data-ttu-id="08289-117">L<sub>dir</sub> = -norm(L<sub>dir</sub> \* wvMatrix)</span><span class="sxs-lookup"><span data-stu-id="08289-117">L<sub>dir</sub> = -norm(L<sub>dir</sub> \* wvMatrix)</span></span>

<span data-ttu-id="08289-118">ポイント ライトとスポット ライトの場合は、ライトへの方向は次のように計算します。</span><span class="sxs-lookup"><span data-stu-id="08289-118">For a point light and a spotlight, the direction to light is computed as follows:</span></span>

<span data-ttu-id="08289-119">L<sub>dir</sub> = norm(V \* Lₚ) これらのパラメータの定義を次の表に示します。</span><span class="sxs-lookup"><span data-stu-id="08289-119">L<sub>dir</sub> = norm(V \* Lₚ), where the parameters are defined in the following table.</span></span>

| <span data-ttu-id="08289-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="08289-120">Parameter</span></span>       | <span data-ttu-id="08289-121">既定値</span><span class="sxs-lookup"><span data-stu-id="08289-121">Default value</span></span> | <span data-ttu-id="08289-122">種類</span><span class="sxs-lookup"><span data-stu-id="08289-122">Type</span></span>                                          | <span data-ttu-id="08289-123">説明</span><span class="sxs-lookup"><span data-stu-id="08289-123">Description</span></span>                                               |
|-----------------|---------------|-----------------------------------------------|-----------------------------------------------------------|
| <span data-ttu-id="08289-124">L<sub>dir</sub></span><span class="sxs-lookup"><span data-stu-id="08289-124">L<sub>dir</sub></span></span> | <span data-ttu-id="08289-125">該当なし</span><span class="sxs-lookup"><span data-stu-id="08289-125">N/A</span></span>           | <span data-ttu-id="08289-126">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="08289-126">3D vector (x, y, and z floating-point values)</span></span> | <span data-ttu-id="08289-127">オブジェクトの頂点からライトへの方向ベクトル</span><span class="sxs-lookup"><span data-stu-id="08289-127">Direction vector from object vertex to the light</span></span>          |
| <span data-ttu-id="08289-128">V</span><span class="sxs-lookup"><span data-stu-id="08289-128">V</span></span>               | <span data-ttu-id="08289-129">なし</span><span class="sxs-lookup"><span data-stu-id="08289-129">N/A</span></span>           | <span data-ttu-id="08289-130">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="08289-130">3D vector (x, y, and z floating-point values)</span></span> | <span data-ttu-id="08289-131">カメラ空間での頂点の位置</span><span class="sxs-lookup"><span data-stu-id="08289-131">Vertex position in camera space</span></span>                           |
| <span data-ttu-id="08289-132">wvMatrix</span><span class="sxs-lookup"><span data-stu-id="08289-132">wvMatrix</span></span>        | <span data-ttu-id="08289-133">ID</span><span class="sxs-lookup"><span data-stu-id="08289-133">Identity</span></span>      | <span data-ttu-id="08289-134">浮動小数点値の 4 x 4 マトリックス</span><span class="sxs-lookup"><span data-stu-id="08289-134">4x4 matrix of floating-point values</span></span>           | <span data-ttu-id="08289-135">ワールドとビューの変換を含む合成行列</span><span class="sxs-lookup"><span data-stu-id="08289-135">Composite matrix containing the world and view transforms</span></span> |
| <span data-ttu-id="08289-136">N</span><span class="sxs-lookup"><span data-stu-id="08289-136">N</span></span>               | <span data-ttu-id="08289-137">該当なし</span><span class="sxs-lookup"><span data-stu-id="08289-137">N/A</span></span>           | <span data-ttu-id="08289-138">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="08289-138">3D vector (x, y, and z floating-point values)</span></span> | <span data-ttu-id="08289-139">頂点法線</span><span class="sxs-lookup"><span data-stu-id="08289-139">Vertex normal</span></span>                                             |
| <span data-ttu-id="08289-140">Lₚ</span><span class="sxs-lookup"><span data-stu-id="08289-140">Lₚ</span></span>              | <span data-ttu-id="08289-141">なし</span><span class="sxs-lookup"><span data-stu-id="08289-141">N/A</span></span>           | <span data-ttu-id="08289-142">3D ベクトル (x、y、z 浮動小数点値)</span><span class="sxs-lookup"><span data-stu-id="08289-142">3D vector (x, y, and z floating-point values)</span></span> | <span data-ttu-id="08289-143">カメラ空間でのライトの位置</span><span class="sxs-lookup"><span data-stu-id="08289-143">Light position in camera space</span></span>                            |
| <span data-ttu-id="08289-144">vMatrix</span><span class="sxs-lookup"><span data-stu-id="08289-144">vMatrix</span></span>         | <span data-ttu-id="08289-145">ID</span><span class="sxs-lookup"><span data-stu-id="08289-145">Identity</span></span>      | <span data-ttu-id="08289-146">浮動小数点値の 4 x 4 マトリックス</span><span class="sxs-lookup"><span data-stu-id="08289-146">4x4 matrix of floating-point values</span></span>           | <span data-ttu-id="08289-147">ビュー変換を含む行列</span><span class="sxs-lookup"><span data-stu-id="08289-147">Matrix containing the view transform</span></span>                      |

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="08289-148"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="08289-148"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="08289-149">光源の計算</span><span class="sxs-lookup"><span data-stu-id="08289-149">Mathematics of lighting</span></span>](mathematics-of-lighting.md)

 

 




