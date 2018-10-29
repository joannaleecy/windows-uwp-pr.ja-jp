---
title: 線リスト
description: 線リストとは、独立した直線セグメントの一覧を指します。 線リストは、3D シーンに氷雨や豪雨を追加する場合などに便利です。 アプリケーションは、頂点の配列を入力することで線リストを作成します。
ms.assetid: 42BF32A1-3535-42A3-82C5-3945CB309F2C
keywords:
- 線リスト
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 5a514fb072dd95b9de2c29e097e8387c0f1068a4
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/29/2018
ms.locfileid: "5740116"
---
# <a name="line-lists"></a><span data-ttu-id="fb04e-106">線リスト</span><span class="sxs-lookup"><span data-stu-id="fb04e-106">Line lists</span></span>


<span data-ttu-id="fb04e-107">線リストとは、独立した直線セグメントの一覧を指します。</span><span class="sxs-lookup"><span data-stu-id="fb04e-107">A line list is a list of isolated, straight line segments.</span></span> <span data-ttu-id="fb04e-108">線リストは、3D シーンに氷雨や豪雨を追加する場合などに便利です。</span><span class="sxs-lookup"><span data-stu-id="fb04e-108">Line lists are useful for such tasks as adding sleet or heavy rain to a 3D scene.</span></span> <span data-ttu-id="fb04e-109">アプリケーションは、頂点の配列を入力することで線リストを作成します。</span><span class="sxs-lookup"><span data-stu-id="fb04e-109">Applications create a line list by filling an array of vertices.</span></span> <span data-ttu-id="fb04e-110">線リストの頂点の数は、2 以上の偶数でなければならない点に注意してください。</span><span class="sxs-lookup"><span data-stu-id="fb04e-110">Note that the number of vertices in a line list must be an even number greater than or equal to two.</span></span>

-   [<span data-ttu-id="fb04e-111">例</span><span class="sxs-lookup"><span data-stu-id="fb04e-111">Example</span></span>](#example)
-   [<span data-ttu-id="fb04e-112">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fb04e-112">Related topics</span></span>](#related-topics)

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="fb04e-113"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="fb04e-113"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="fb04e-114">次の図は、レンダリングされた線リストを示しています。</span><span class="sxs-lookup"><span data-stu-id="fb04e-114">The following illustration shows a rendered line list.</span></span>

![線リストの図](images/linelst.png)

<span data-ttu-id="fb04e-116">線リストには、素材やテクスチャを適用できます。</span><span class="sxs-lookup"><span data-stu-id="fb04e-116">You can apply materials and textures to a line list.</span></span> <span data-ttu-id="fb04e-117">素材やテクスチャの色は描画された線にのみ表示され、線の間の点には表示されません。</span><span class="sxs-lookup"><span data-stu-id="fb04e-117">The colors in the material or texture appear only along the lines drawn, not at any point in between the lines.</span></span>

<span data-ttu-id="fb04e-118">次のコードは、この線リストの頂点の作成方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fb04e-118">The following code shows how to create vertices for this line list.</span></span>

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

<span data-ttu-id="fb04e-119">次のコード例は、線リストを Direct3D でレンダリングする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fb04e-119">The code example below shows how to render a line list in Direct3D.</span></span>

```
//
// It is assumed that d3dDevice is a valid
// pointer to an IDirect3DDevice interface.
//
d3dDevice->DrawPrimitive( D3DPT_LINELIST, 0, 3 );
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="fb04e-120"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="fb04e-120"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="fb04e-121">プリミティブ</span><span class="sxs-lookup"><span data-stu-id="fb04e-121">Primitives</span></span>](primitives.md)

 

 




