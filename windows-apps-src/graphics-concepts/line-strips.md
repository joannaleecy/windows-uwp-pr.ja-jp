---
title: ライン ストリップ
description: ライン ストリップとは、接続された行セグメントから構成されるプリミティブを指します。 アプリケーションは、ライン ストリップを使用して、閉じられていない多角形を作成することができます。 閉じられた多角形とは、最後の頂点が行セグメントによって最初の頂点に接続されている多角形を指します。
ms.assetid: 6E8C58E1-B463-44FD-A69F-81CCBF25D856
keywords:
- ライン ストリップ
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: a5fbf4d7fd4f82e6bc44795d64e6b98b6c732f49
ms.sourcegitcommit: cbe7cf620622a5e4df7414f9e38dfecec1cfca99
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/20/2018
ms.locfileid: "7427674"
---
# <a name="line-strips"></a><span data-ttu-id="640fe-106">ライン ストリップ</span><span class="sxs-lookup"><span data-stu-id="640fe-106">Line strips</span></span>


<span data-ttu-id="640fe-107">ライン ストリップとは、接続された行セグメントから構成されるプリミティブを指します。</span><span class="sxs-lookup"><span data-stu-id="640fe-107">A line strip is a primitive that is composed of connected line segments.</span></span> <span data-ttu-id="640fe-108">アプリケーションは、ライン ストリップを使用して、閉じられていない多角形を作成することができます。</span><span class="sxs-lookup"><span data-stu-id="640fe-108">Your application can use line strips for creating polygons that are not closed.</span></span> <span data-ttu-id="640fe-109">閉じられた多角形とは、最後の頂点が行セグメントによって最初の頂点に接続されている多角形を指します。</span><span class="sxs-lookup"><span data-stu-id="640fe-109">A closed polygon is a polygon whose last vertex is connected to its first vertex by a line segment.</span></span> <span data-ttu-id="640fe-110">アプリケーションがライン ストリップに基づいて多角形を作成する場合、頂点が同一平面上にあることは保証されません。</span><span class="sxs-lookup"><span data-stu-id="640fe-110">If your application makes polygons based on line strips, the vertices are not guaranteed to be coplanar.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="640fe-111"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="640fe-111"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="640fe-112">次の図は、レンダリングされたライン ストリップを示しています。</span><span class="sxs-lookup"><span data-stu-id="640fe-112">The following illustration shows a rendered line strip.</span></span>

![ライン ストリップの図](images/linstrip.gif)

<span data-ttu-id="640fe-114">次のコードは、このライン ストリップの頂点の作成方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="640fe-114">The following code shows how to create vertices for this line strip.</span></span>

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

<span data-ttu-id="640fe-115">次のコード例は、ライン ストリップを Direct3D でレンダリングする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="640fe-115">The code example below shows how to render a line strip in Direct3D.</span></span>

```
//
// It is assumed that d3dDevice is a valid
// pointer to an IDirect3DDevice interface.
//
d3dDevice->DrawPrimitive( D3DPT_LINESTRIP, 0, 5 );
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="640fe-116"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="640fe-116"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="640fe-117">プリミティブ</span><span class="sxs-lookup"><span data-stu-id="640fe-117">Primitives</span></span>](primitives.md)

 

 




