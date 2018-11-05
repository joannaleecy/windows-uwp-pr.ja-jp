---
title: 変換の概要
description: 3D グラフィックスの多くの低レベル数学演算は、行列変換によって処理されます。
ms.assetid: B5220EE8-2533-4B55-BF58-A3F9F612B977
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 32f55b0a387221b792e37072f129edddf285195b
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6027988"
---
# <a name="transform-overview"></a><span data-ttu-id="34c21-104">変換の概要</span><span class="sxs-lookup"><span data-stu-id="34c21-104">Transform overview</span></span>


<span data-ttu-id="34c21-105">3D グラフィックスの多くの低レベル数学演算は、行列変換によって処理されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-105">Matrix transformations handle a lot of the low level math of 3D graphics.</span></span>

<span data-ttu-id="34c21-106">ジオメトリ パイプラインは、頂点を入力として受け取ります。</span><span class="sxs-lookup"><span data-stu-id="34c21-106">The geometry pipeline takes vertices as input.</span></span> <span data-ttu-id="34c21-107">変換エンジンは、ワールド変換、ビュー変換、射影変換を頂点に適用し、結果をクリッピングして、すべてをラスタライザーに渡します。</span><span class="sxs-lookup"><span data-stu-id="34c21-107">The transform engine applies the world, view, and projection transforms to the vertices, clips the result, and passes everything to the rasterizer.</span></span>

| <span data-ttu-id="34c21-108">変換と空間</span><span class="sxs-lookup"><span data-stu-id="34c21-108">Transform and space</span></span>                           | <span data-ttu-id="34c21-109">説明</span><span class="sxs-lookup"><span data-stu-id="34c21-109">Description</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |
|-----------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="34c21-110">モデル空間内のモデル座標</span><span class="sxs-lookup"><span data-stu-id="34c21-110">Model coordinates in model space</span></span>              | <span data-ttu-id="34c21-111">パイプラインの最初の処理では、モデルの頂点はローカル座標系を基準として相対的に宣言されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-111">At the head of the pipeline, a model's vertices are declared relative to a local coordinate system.</span></span> <span data-ttu-id="34c21-112">これはローカルの原点と方向です。</span><span class="sxs-lookup"><span data-stu-id="34c21-112">This is a local origin and an orientation.</span></span> <span data-ttu-id="34c21-113">この座標の方向は、一般に "モデル空間"\*\* と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="34c21-113">This orientation of coordinates is often referred to as *model space*.</span></span> <span data-ttu-id="34c21-114">個々の座標は "モデル座標"\*\* と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="34c21-114">Individual coordinates are called *model coordinates*.</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                      |
| <span data-ttu-id="34c21-115">ワールド空間へのワールド変換</span><span class="sxs-lookup"><span data-stu-id="34c21-115">World transform into world space</span></span>              | <span data-ttu-id="34c21-116">ジオメトリ パイプラインの最初のステージでは、モデルの頂点が、ローカル座標系からシーン内のすべてのオブジェクトで使われる座標系に変換されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-116">The first stage of the geometry pipeline transforms a model's vertices from their local coordinate system to a coordinate system that is used by all the objects in a scene.</span></span> <span data-ttu-id="34c21-117">頂点の方向を再設定する処理は[ワールド変換](world-transform.md)と呼ばれ、モデル空間から "ワールド空間"\*\* という新しい方向への変換が行われます。</span><span class="sxs-lookup"><span data-stu-id="34c21-117">The process of reorienting the vertices is called the [World transform](world-transform.md), which converts from model space to a new orientation called *world space*.</span></span> <span data-ttu-id="34c21-118">ワールド空間内の各頂点は、"ワールド座標"\*\* を使って宣言されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-118">Each vertex in world space is declared using *world coordinates*.</span></span>                                                                                                                                                                                                                                                                                                                           |
| <span data-ttu-id="34c21-119">ビュー空間 (カメラ空間) へのビュー変換</span><span class="sxs-lookup"><span data-stu-id="34c21-119">View transform into view space (camera space)</span></span> | <span data-ttu-id="34c21-120">次のステージでは、3D ワールドを記述する頂点が、カメラを基準とする方向に変換されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-120">In the next stage, the vertices that describe your 3D world are oriented with respect to a camera.</span></span> <span data-ttu-id="34c21-121">つまり、アプリケーションでシーンの視点を選択すると、ワールド空間座標が再配置されてカメラの視点を中心に回転し、ワールド空間から "ビュー空間"\*\* ("カメラ空間"\*\* とも呼ばれます) に切り替わります。</span><span class="sxs-lookup"><span data-stu-id="34c21-121">That is, your application chooses a point-of-view for the scene, and world space coordinates are relocated and rotated around the camera's view, turning world space into *view space* (also known as *camera space*).</span></span> <span data-ttu-id="34c21-122">これが、ワールド空間からビュー空間に変換する[ビュー変換](view-transform.md)です。</span><span class="sxs-lookup"><span data-stu-id="34c21-122">This is the [View transform](view-transform.md), which converts from world space to view space.</span></span>                                                                                                                                                                                                                                                                                                                        |
| <span data-ttu-id="34c21-123">射影空間への射影変換</span><span class="sxs-lookup"><span data-stu-id="34c21-123">Projection transform into projection space</span></span>    | <span data-ttu-id="34c21-124">次のステージは[射影変換](projection-transform.md)です。これにより、ビュー空間から射影空間への変換が行われます。</span><span class="sxs-lookup"><span data-stu-id="34c21-124">The next stage is the [Projection transform](projection-transform.md), which converts from view space to projection space.</span></span> <span data-ttu-id="34c21-125">パイプラインのこの部分では、シーンに奥行き感を与えるために、オブジェクトが通常はビューアーからの距離に基づいてスケーリングされます。つまり、近くのオブジェクトは遠くのオブジェクトよりも大きく見えるように調整されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-125">In this part of the pipeline, objects are usually scaled with relation to their distance from the viewer in order to give the illusion of depth to a scene; close objects are made to appear larger than distant objects.</span></span> <span data-ttu-id="34c21-126">わかりやすくするために、このドキュメントでは、射影変換後に頂点が存在する空間を "射影空間"\*\* と呼びます。</span><span class="sxs-lookup"><span data-stu-id="34c21-126">For simplicity, this documentation refers to the space in which vertices exist after the projection transform as *projection space*.</span></span> <span data-ttu-id="34c21-127">グラフィックスの解説書によっては、射影空間を "透視射影変換後の同次空間"\*\* と呼ぶ場合もあります。</span><span class="sxs-lookup"><span data-stu-id="34c21-127">Some graphics books might refer to projection space as *post-perspective homogeneous space*.</span></span> <span data-ttu-id="34c21-128">すべての射影変換でシーン内のオブジェクトのサイズが変更されるとは限りません。</span><span class="sxs-lookup"><span data-stu-id="34c21-128">Not all projection transforms scale the size of objects in a scene.</span></span> <span data-ttu-id="34c21-129">このような射影は、"アフィン変換"\*\* や "直行変換"\*\* と呼ばれることがあります。</span><span class="sxs-lookup"><span data-stu-id="34c21-129">A projection such as this is sometimes called an *affine* or *orthogonal projection*.</span></span> |
| <span data-ttu-id="34c21-130">スクリーン空間でのクリッピング</span><span class="sxs-lookup"><span data-stu-id="34c21-130">Clipping in screen space</span></span>                      | <span data-ttu-id="34c21-131">パイプラインの最後の部分では、画面に表示されない頂点がすべて削除されます。これにより、表示されないオブジェクトの色や影の計算にラスタライザーが時間を費やすことはなくなります。</span><span class="sxs-lookup"><span data-stu-id="34c21-131">In the final part of the pipeline, any vertices that will not be visible on the screen are removed, so that the rasterizer doesn't take the time to calculate the colors and shading for something that will never be seen.</span></span> <span data-ttu-id="34c21-132">このプロセスを "クリッピング"\*\* と呼びます。</span><span class="sxs-lookup"><span data-stu-id="34c21-132">This process is called *clipping*.</span></span> <span data-ttu-id="34c21-133">クリッピング後、残りの頂点はビューポート パラメーターに従ってスケーリングされ、スクリーン座標に変換されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-133">After clipping, the remaining vertices are scaled according to the viewport parameters and converted into screen coordinates.</span></span> <span data-ttu-id="34c21-134">結果として得られる頂点は "スクリーン空間"\*\* に存在し、シーンがラスタライズされるときに画面に表示されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-134">The resulting vertices, seen on the screen when the scene is rasterized, exist in *screen space*.</span></span>                                                                                                                                                                                                                                                    |

 

<span data-ttu-id="34c21-135">変換は、オブジェクト ジオメトリをある座標空間から別の座標空間に変換するために使われます。</span><span class="sxs-lookup"><span data-stu-id="34c21-135">Transforms are used to convert object geometry from one coordinate space to another.</span></span> <span data-ttu-id="34c21-136">Direct3D では、行列を使って 3D 変換を実行します。</span><span class="sxs-lookup"><span data-stu-id="34c21-136">Direct3D uses matrices to perform 3D transforms.</span></span> <span data-ttu-id="34c21-137">行列は 3D 変換を作成します。</span><span class="sxs-lookup"><span data-stu-id="34c21-137">Matrices create 3D transforms.</span></span> <span data-ttu-id="34c21-138">複数の行列を結合することで、複数の変換を含む 1 つの行列を作成できます。</span><span class="sxs-lookup"><span data-stu-id="34c21-138">You can combine matrices to produce a single matrix that encompasses multiple transforms.</span></span>

<span data-ttu-id="34c21-139">モデル空間、ワールド空間、ビュー空間の間で座標を変換することができます。</span><span class="sxs-lookup"><span data-stu-id="34c21-139">You can transform coordinates between model space, world space, and view space.</span></span>

-   <span data-ttu-id="34c21-140">[ワールド変換](world-transform.md) - モデル空間からワールド空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="34c21-140">[World transform](world-transform.md) - Converts from model space to world space.</span></span>
-   <span data-ttu-id="34c21-141">[ビュー変換](view-transform.md) - ワールド空間からビュー空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="34c21-141">[View transform](view-transform.md) - Converts from world space to view space.</span></span>
-   <span data-ttu-id="34c21-142">[射影変換](projection-transform.md) - ビュー空間から射影空間に変換します。</span><span class="sxs-lookup"><span data-stu-id="34c21-142">[Projection transform](projection-transform.md) - Converts from view space to projection space.</span></span>

## <a name="span-idmatrixtransformsspanspan-idmatrixtransformsspanspan-idmatrixtransformsspanmatrix-transforms"></a><span data-ttu-id="34c21-143"><span id="Matrix_Transforms"></span><span id="matrix_transforms"></span><span id="MATRIX_TRANSFORMS"></span>行列変換</span><span class="sxs-lookup"><span data-stu-id="34c21-143"><span id="Matrix_Transforms"></span><span id="matrix_transforms"></span><span id="MATRIX_TRANSFORMS"></span>Matrix Transforms</span></span>


<span data-ttu-id="34c21-144">3D グラフィックスを使用するアプリケーションでは、幾何学変換を使って次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="34c21-144">In applications that work with 3D graphics, you can use geometrical transforms to do the following:</span></span>

-   <span data-ttu-id="34c21-145">オブジェクトの位置を、別のオブジェクトからの相対的な位置で表現する。</span><span class="sxs-lookup"><span data-stu-id="34c21-145">Express the location of an object relative to another object.</span></span>
-   <span data-ttu-id="34c21-146">オブジェクトを回転し、サイズを変更する。</span><span class="sxs-lookup"><span data-stu-id="34c21-146">Rotate and size objects.</span></span>
-   <span data-ttu-id="34c21-147">視点、向き、奥行きを変更する。</span><span class="sxs-lookup"><span data-stu-id="34c21-147">Change viewing positions, directions, and perspectives.</span></span>

<span data-ttu-id="34c21-148">次の方程式に示すように、4x4 行列を使うことで任意の点 (x,y,z) を別の点 (x', y', z') に変換できます。</span><span class="sxs-lookup"><span data-stu-id="34c21-148">You can transform any point (x,y,z) into another point (x', y', z') by using a 4x4 matrix, as shown in the following equation.</span></span>

![任意の点を別の点に変換する方程式](images/matmult.png)

<span data-ttu-id="34c21-150">(x, y, z) と行列に対して次の方程式を実行すると、点 (x', y', z') が生成されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-150">Perform the following equations on (x, y, z) and the matrix to produce the point (x', y', z').</span></span>

![新しい点を求める方程式](images/matexpnd.png)

<span data-ttu-id="34c21-152">最も一般的な変換は、平行移動、回転、スケーリングです。</span><span class="sxs-lookup"><span data-stu-id="34c21-152">The most common transforms are translation, rotation, and scaling.</span></span> <span data-ttu-id="34c21-153">これらの効果を生成する行列を結合して 1 つの行列にすると、複数の変換を一度に計算できます。</span><span class="sxs-lookup"><span data-stu-id="34c21-153">You can combine the matrices that produce these effects into a single matrix to calculate several transforms at once.</span></span> <span data-ttu-id="34c21-154">たとえば、一連の点に平行移動と回転を適用する 1 つの行列を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="34c21-154">For example, you can build a single matrix to translate and rotate a series of points.</span></span>

<span data-ttu-id="34c21-155">行列は、行、列の順番に記述されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-155">Matrices are written in row-column order.</span></span> <span data-ttu-id="34c21-156">各軸に対して頂点を均等にスケーリングする処理は均等スケーリングと呼ばれ、これを実行する行列は数学的に次のように表記されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-156">A matrix that evenly scales vertices along each axis, known as uniform scaling, is represented by the following matrix using mathematical notation.</span></span>

![均等スケーリングの行列を表す式](images/matrix.png)

<span data-ttu-id="34c21-158">C++ の場合、Direct3D は行列構造体を使って、行列を 2 次元配列として宣言します。</span><span class="sxs-lookup"><span data-stu-id="34c21-158">In C++, Direct3D declares matrices as a two-dimensional array, using a matrix struct.</span></span> <span data-ttu-id="34c21-159">次の例は、[**D3DMATRIX**](https://msdn.microsoft.com/library/windows/desktop/bb172573) 構造体を初期化して、均等スケーリング行列 (スケール ファクター "s") として動作するように設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="34c21-159">The following example shows how to initialize a [**D3DMATRIX**](https://msdn.microsoft.com/library/windows/desktop/bb172573) structure to act as a uniform scaling matrix (scale factor "s").</span></span>

```
D3DMATRIX scale = {
    5.0f,            0.0f,            0.0f,            0.0f,
    0.0f,            5.0f,            0.0f,            0.0f,
    0.0f,            0.0f,            5.0f,            0.0f,
    0.0f,            0.0f,            0.0f,            1.0f
};
```

## <a name="span-idtranslatespanspan-idtranslatespanspan-idtranslatespantranslate"></a><span data-ttu-id="34c21-160"><span id="Translate"></span><span id="translate"></span><span id="TRANSLATE"></span>平行移動</span><span class="sxs-lookup"><span data-stu-id="34c21-160"><span id="Translate"></span><span id="translate"></span><span id="TRANSLATE"></span>Translate</span></span>


<span data-ttu-id="34c21-161">次の方程式は、点 (x, y, z) を新しい点 (x', y', z') に平行移動します。</span><span class="sxs-lookup"><span data-stu-id="34c21-161">The following equation translates the point (x, y, z) to a new point (x', y', z').</span></span>

![新しい点を求める平行移動行列の方程式](images/transl8.png)

<span data-ttu-id="34c21-163">C++ では、平行移動行列を手動で作成することができます。</span><span class="sxs-lookup"><span data-stu-id="34c21-163">You can manually create a translation matrix in C++.</span></span> <span data-ttu-id="34c21-164">次の例は、頂点を平行移動する行列を作成する関数のソース コードを示しています。</span><span class="sxs-lookup"><span data-stu-id="34c21-164">The following example shows the source code for a function that creates a matrix to translate vertices.</span></span>

```
D3DXMATRIX Translate(const float dx, const float dy, const float dz) {
    D3DXMATRIX ret;

    D3DXMatrixIdentity(&ret);
    ret(3, 0) = dx;
    ret(3, 1) = dy;
    ret(3, 2) = dz;
    return ret;
}    // End of Translate
```

## <a name="span-idscalespanspan-idscalespanspan-idscalespanscale"></a><span data-ttu-id="34c21-165"><span id="Scale"></span><span id="scale"></span><span id="SCALE"></span>スケーリング</span><span class="sxs-lookup"><span data-stu-id="34c21-165"><span id="Scale"></span><span id="scale"></span><span id="SCALE"></span>Scale</span></span>


<span data-ttu-id="34c21-166">次の方程式は、点 (x, y, z) を x 方向、y 方向、z 方向に任意の値でスケーリングして、新しい点 (x', y', z') を求めます。</span><span class="sxs-lookup"><span data-stu-id="34c21-166">The following equation scales the point (x, y, z) by arbitrary values in the x-, y-, and z-directions to a new point (x', y', z').</span></span>

![新しい点を求めるスケーリング行列の方程式](images/matscale.png)

## <a name="span-idrotatespanspan-idrotatespanspan-idrotatespanrotate"></a><span data-ttu-id="34c21-168"><span id="Rotate"></span><span id="rotate"></span><span id="ROTATE"></span>回転</span><span class="sxs-lookup"><span data-stu-id="34c21-168"><span id="Rotate"></span><span id="rotate"></span><span id="ROTATE"></span>Rotate</span></span>


<span data-ttu-id="34c21-169">ここで説明する変換は左手座標系を想定しているため、他の場所に記述されている変換行列とは異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="34c21-169">The transforms described here are for left-handed coordinate systems, and so may be different from transform matrices that you have seen elsewhere.</span></span>

<span data-ttu-id="34c21-170">次の方程式は、x 軸を中心に点 (x, y, z) を回転し、新しい点 (x', y', z') を求めます。</span><span class="sxs-lookup"><span data-stu-id="34c21-170">The following equation rotates the point (x, y, z) around the x-axis, producing a new point (x', y', z').</span></span>

![新しい点を求める x 軸回転行列の方程式](images/matxrot.png)

<span data-ttu-id="34c21-172">次の方程式は、y 軸を中心に点を回転します。</span><span class="sxs-lookup"><span data-stu-id="34c21-172">The following equation rotates the point around the y-axis.</span></span>

![新しい点を求める y 軸回転行列の方程式](images/matyrot.png)

<span data-ttu-id="34c21-174">次の方程式は、z 軸を中心に点を回転します。</span><span class="sxs-lookup"><span data-stu-id="34c21-174">The following equation rotates the point around the z-axis.</span></span>

![新しい点を求める z 軸回転行列の方程式](images/matzrot.png)

<span data-ttu-id="34c21-176">これらの行列の例において、ギリシャ文字シータはラジアン単位の回転角度を表しています。</span><span class="sxs-lookup"><span data-stu-id="34c21-176">In these example matrices, the Greek letter theta stands for the angle of rotation, in radians.</span></span> <span data-ttu-id="34c21-177">角度は、回転軸に沿って原点を見た状態で時計回りに測定されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-177">Angles are measured clockwise when looking along the rotation axis toward the origin.</span></span>

<span data-ttu-id="34c21-178">次のコードは、X 軸周りの回転を処理する関数を示しています。</span><span class="sxs-lookup"><span data-stu-id="34c21-178">The following code shows a function to handle rotation about the X axis.</span></span>

```
    // Inputs are a pointer to a matrix (pOut) and an angle in radians.
    float sin, cos;
    sincosf(angle, &sin, &cos);  // Determine sin and cos of angle

    pOut->_11 = 1.0f; pOut->_12 =  0.0f;   pOut->_13 = 0.0f; pOut->_14 = 0.0f;
    pOut->_21 = 0.0f; pOut->_22 =  cos;    pOut->_23 = sin;  pOut->_24 = 0.0f;
    pOut->_31 = 0.0f; pOut->_32 = -sin;    pOut->_33 = cos;  pOut->_34 = 0.0f;
    pOut->_41 = 0.0f; pOut->_42 =  0.0f;   pOut->_43 = 0.0f; pOut->_44 = 1.0f;

    return pOut;
}
```

## <a name="span-idconcatenatingmatricesspanspan-idconcatenatingmatricesspanspan-idconcatenatingmatricesspanconcatenating-matrices"></a><span data-ttu-id="34c21-179"><span id="Concatenating_Matrices"></span><span id="concatenating_matrices"></span><span id="CONCATENATING_MATRICES"></span>行列の連結</span><span class="sxs-lookup"><span data-stu-id="34c21-179"><span id="Concatenating_Matrices"></span><span id="concatenating_matrices"></span><span id="CONCATENATING_MATRICES"></span>Concatenating Matrices</span></span>


<span data-ttu-id="34c21-180">行列を使う利点の 1 つは、2 つ以上の行列を掛け合わせて、それらの効果を組み合わせることができる点にあります。</span><span class="sxs-lookup"><span data-stu-id="34c21-180">One advantage of using matrices is that you can combine the effects of two or more matrices by multiplying them.</span></span> <span data-ttu-id="34c21-181">つまり、モデルを回転した後で別の場所へ平行移動する場合でも、2 つの行列を適用する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="34c21-181">This means that, to rotate a model and then translate it to some location, you don't need to apply two matrices.</span></span> <span data-ttu-id="34c21-182">代わりに、回転行列と平行移動行列を掛け合わせて、両方の効果を含む合成行列を生成します。</span><span class="sxs-lookup"><span data-stu-id="34c21-182">Instead, you multiply the rotation and translation matrices to produce a composite matrix that contains all their effects.</span></span> <span data-ttu-id="34c21-183">このプロセスは行列の連結と呼ばれ、次の方程式によって記述できます。</span><span class="sxs-lookup"><span data-stu-id="34c21-183">This process, called matrix concatenation, can be written with the following equation.</span></span>

![行列の連結の方程式](images/matrxcat.png)

<span data-ttu-id="34c21-185">この方程式では、C は作成される合成行列を表し、M ～ Mₙ は個々の行列を表します。</span><span class="sxs-lookup"><span data-stu-id="34c21-185">In this equation, C is the composite matrix being created, and M₁ through Mₙ are the individual matrices.</span></span> <span data-ttu-id="34c21-186">ほとんどの場合、連結される行列は 2 ～ 3 個だけですが、数に制限はありません。</span><span class="sxs-lookup"><span data-stu-id="34c21-186">In most cases, only two or three matrices are concatenated, but there is no limit.</span></span>

<span data-ttu-id="34c21-187">行列の乗算を実行する順序は非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="34c21-187">The order in which the matrix multiplication is performed is crucial.</span></span> <span data-ttu-id="34c21-188">上の式は、行列が左から右へ連結されることを示しています。</span><span class="sxs-lookup"><span data-stu-id="34c21-188">The preceding formula reflects the left-to-right rule of matrix concatenation.</span></span> <span data-ttu-id="34c21-189">つまり、合成行列の作成に使われる各行列の視覚効果は、左から右へ順番に適用されます。</span><span class="sxs-lookup"><span data-stu-id="34c21-189">That is, the visible effects of the matrices that you use to create a composite matrix occur in left-to-right order.</span></span> <span data-ttu-id="34c21-190">ここで、典型的なワールド行列の例を考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="34c21-190">A typical world matrix is shown in the following example.</span></span> <span data-ttu-id="34c21-191">たとえば、よくある空飛ぶ円盤を表すワールド行列を作成するとします。</span><span class="sxs-lookup"><span data-stu-id="34c21-191">Imagine that you are creating the world matrix for a stereotypical flying saucer.</span></span> <span data-ttu-id="34c21-192">空飛ぶ円盤に期待されるのは、その中心点 (モデル空間の y 軸) で回転しながら、シーン内の別の場所に平行移動するという動作です。</span><span class="sxs-lookup"><span data-stu-id="34c21-192">You would probably want to spin the flying saucer around its center - the y-axis of model space - and translate it to some other location in your scene.</span></span> <span data-ttu-id="34c21-193">この効果を実現するには、まず回転行列を作成し、それに平行移動行列を掛け合わせます。この方程式を次に示します。</span><span class="sxs-lookup"><span data-stu-id="34c21-193">To accomplish this effect, you first create a rotation matrix, and then multiply it by a translation matrix, as shown in the following equation.</span></span>

![回転行列と平行移動行列に基づく回転の方程式](images/wrldexpl.png)

<span data-ttu-id="34c21-195">この式では、R<sub>y</sub> は y 軸周りの回転行列を表し、T<sub>w</sub> はワールド座標の別の場所への平行移動を表します。</span><span class="sxs-lookup"><span data-stu-id="34c21-195">In this formula, R<sub>y</sub> is a matrix for rotation about the y-axis, and T<sub>w</sub> is a translation to some position in world coordinates.</span></span>

<span data-ttu-id="34c21-196">2 つのスカラー値を乗算する場合とは異なり、行列の乗算は非可換であるため、行列を乗算する順序には重要な意味があります。</span><span class="sxs-lookup"><span data-stu-id="34c21-196">The order in which you multiply the matrices is important because, unlike multiplying two scalar values, matrix multiplication is not commutative.</span></span> <span data-ttu-id="34c21-197">行列を逆の順序で乗算すると、空飛ぶ円盤をワールド空間の場所へ平行移動させてから、ワールド原点を中心に回転させるという視覚効果になります。</span><span class="sxs-lookup"><span data-stu-id="34c21-197">Multiplying the matrices in the opposite order has the visual effect of translating the flying saucer to its world space position, and then rotating it around the world origin.</span></span>

<span data-ttu-id="34c21-198">どのような種類の行列を作成する場合でも、期待どおりの効果を得るためには、左から右という規則を覚えておくことが重要です。</span><span class="sxs-lookup"><span data-stu-id="34c21-198">No matter what type of matrix you are creating, remember the left-to-right rule to ensure that you achieve the expected effects.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="34c21-199"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="34c21-199"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="34c21-200">変換</span><span class="sxs-lookup"><span data-stu-id="34c21-200">Transforms</span></span>](transforms.md)

 

 




