---
title: ポイント リスト
description: ポイント リストとは、独立した点としてレンダリングされる頂点の集合を指します。 アプリケーションは、星空の 3D シーンや、多角形の表面の点線に、ポイント リストを使うことができます。
ms.assetid: 332954AE-019F-4A91-B773-E3A7C92F3297
keywords:
- ポイント リスト
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 84a08d480070e4a23147679dd9b5dda1f8c9cca1
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8785979"
---
# <a name="point-lists"></a><span data-ttu-id="c4e1e-105">ポイント リスト</span><span class="sxs-lookup"><span data-stu-id="c4e1e-105">Point lists</span></span>


<span data-ttu-id="c4e1e-106">ポイント リストとは、独立した点としてレンダリングされる頂点の集合を指します。</span><span class="sxs-lookup"><span data-stu-id="c4e1e-106">A point list is a collection of vertices that are rendered as isolated points.</span></span> <span data-ttu-id="c4e1e-107">アプリケーションは、星空の 3D シーンや、多角形の表面の点線に、ポイント リストを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="c4e1e-107">Your application can use point lists in 3D scenes for star fields, or dotted lines on the surface of a polygon.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="c4e1e-108"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="c4e1e-108"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="c4e1e-109">次の図は、レンダリングされたポイント リストを示しています。</span><span class="sxs-lookup"><span data-stu-id="c4e1e-109">The following illustration depicts a rendered point list.</span></span>

![ポイント リストの図](images/pointlst.png)

<span data-ttu-id="c4e1e-111">アプリケーションでは、ポイント リストにマテリアルやテクスチャを適用できます。</span><span class="sxs-lookup"><span data-stu-id="c4e1e-111">Your application can apply materials and textures to a point list.</span></span> <span data-ttu-id="c4e1e-112">マテリアルやテクスチャの色は描画された点にのみ表示され、点どうしの間には表示されません。</span><span class="sxs-lookup"><span data-stu-id="c4e1e-112">The colors in the material or texture appear only at the points drawn, and not anywhere between the points.</span></span>

<span data-ttu-id="c4e1e-113">次のコードは、このポイント リストの頂点の作成方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c4e1e-113">The following code shows how to create vertices for this point list.</span></span>

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

<span data-ttu-id="c4e1e-114">次のコード例は、このポイント リストを Direct3D でレンダリングする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="c4e1e-114">The code example below shows how to render this point list in Direct3D.</span></span>

```
//
// It is assumed that d3dDevice is a valid
// pointer to an IDirect3DDevice interface.
//
d3dDevice->DrawPrimitive( D3DPT_POINTLIST, 0, 6 );
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="c4e1e-115"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="c4e1e-115"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="c4e1e-116">プリミティブ</span><span class="sxs-lookup"><span data-stu-id="c4e1e-116">Primitives</span></span>](primitives.md)

 

 




