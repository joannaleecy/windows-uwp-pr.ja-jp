---
title: 矩形
description: Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。
ms.assetid: 3B78AE66-2C1A-4191-BDCA-D737E33460BA
keywords:
- 矩形
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: cb870fa851e51773d95d23ebf9d31f76774924de
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/12/2018
ms.locfileid: "6449937"
---
# <a name="rectangles"></a><span data-ttu-id="ee371-104">矩形</span><span class="sxs-lookup"><span data-stu-id="ee371-104">Rectangles</span></span>


<span data-ttu-id="ee371-105">Direct3D および Windows のプログラミングにおいて、画面上のオブジェクトは境界矩形として示されます。</span><span class="sxs-lookup"><span data-stu-id="ee371-105">Throughout Direct3D and Windows programming, objects on the screen are referred to in terms of bounding rectangles.</span></span> <span data-ttu-id="ee371-106">境界矩形のサイドは、常に画面のサイドと平行になっています。そのため、矩形は左上隅と右下隅の 2 つのポイントで描画されます。</span><span class="sxs-lookup"><span data-stu-id="ee371-106">The sides of a bounding rectangle are always parallel to the sides of the screen, so the rectangle can be described by two points, the upper-left corner and lower-right corner.</span></span>

## <a name="span-idboundingrectanglesspanspan-idboundingrectanglesspanspan-idboundingrectanglesspanbounding-rectangles"></a><span data-ttu-id="ee371-107"><span id="Bounding_rectangles"></span><span id="bounding_rectangles"></span><span id="BOUNDING_RECTANGLES"></span>境界矩形</span><span class="sxs-lookup"><span data-stu-id="ee371-107"><span id="Bounding_rectangles"></span><span id="bounding_rectangles"></span><span id="BOUNDING_RECTANGLES"></span>Bounding rectangles</span></span>


<span data-ttu-id="ee371-108">ほとんどのアプリケーションは、画面に情報を伝えたり、ヒット検出を実行したりする場合、[**RECT**](https://msdn.microsoft.com/library/windows/desktop/dd162897) 構造体 (または typedef されているエイリアス) を使って、利用する境界矩形に関する情報を伝えます。</span><span class="sxs-lookup"><span data-stu-id="ee371-108">Most applications use the [**RECT**](https://msdn.microsoft.com/library/windows/desktop/dd162897) structure (or a typedef'd alias for it) to carry information about a bounding rectangle to use when blitting to the screen or when performing hit detection.</span></span> <span data-ttu-id="ee371-109">C++ の場合、**RECT** 構造体は次のように定義されます。</span><span class="sxs-lookup"><span data-stu-id="ee371-109">In C++, the **RECT** structure has the following definition.</span></span>

```
typedef struct tagRECT { 
    LONG    left;    // This is the upper-left corner x-coordinate.
    LONG    top;     // The upper-left corner y-coordinate.
    LONG    right;   // The lower-right corner x-coordinate.
    LONG    bottom;  // The lower-right corner y-coordinate.
} RECT, *PRECT, NEAR *NPRECT, FAR *LPRECT; 
```

<span data-ttu-id="ee371-110">上記の例では、left メンバーと top メンバーが境界矩形の左上隅における x 座標と y 座標になります。</span><span class="sxs-lookup"><span data-stu-id="ee371-110">In the preceding example, the left and top members are the x- and y-coordinates of a bounding rectangle's upper-left corner.</span></span> <span data-ttu-id="ee371-111">同様に、right メンバーと bottom メンバーが右下隅の座標を構成します。</span><span class="sxs-lookup"><span data-stu-id="ee371-111">Similarly, the right and bottom members make up the coordinates of the lower-right corner.</span></span> <span data-ttu-id="ee371-112">次の図は、これらの値を視覚化したものです。</span><span class="sxs-lookup"><span data-stu-id="ee371-112">The following illustration shows how you can visualize these values.</span></span>

![left、top、right、bottom の値で境界が設定された矩形の図](images/rect.png)

<span data-ttu-id="ee371-114">右端のピクセルの列と下端のピクセルの行は、RECT に含まれていません。</span><span class="sxs-lookup"><span data-stu-id="ee371-114">The column of pixels at the right edge and the row of pixels at the bottom edge are not included in the RECT.</span></span> <span data-ttu-id="ee371-115">たとえば、メンバー {10, 10, 138, 138} の RECT をロックすると、結果として幅と高さが 128 ピクセルのオブジェクトになります。</span><span class="sxs-lookup"><span data-stu-id="ee371-115">For example, locking a RECT with members {10, 10, 138, 138} results in an object 128 pixels in width and height.</span></span>

<span data-ttu-id="ee371-116">効率的で一貫性があり、簡単に利用できるため、すべての Direct3D の表示関数は矩形と連携します。</span><span class="sxs-lookup"><span data-stu-id="ee371-116">For efficiency, consistency, and ease of use, all Direct3D presentation functions work with rectangles.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="ee371-117"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="ee371-117"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="ee371-118">座標系とジオメトリ</span><span class="sxs-lookup"><span data-stu-id="ee371-118">Coordinate systems and geometry</span></span>](coordinate-systems-and-geometry.md)

 

 




