---
title: トライアングル リスト
description: トライアングル リストとは、独立した三角形のリストです。 これらの独立した三角形は、距離が近い場合もそうでない場合もあります。 三角形の一覧には、最低 3 つの頂点が必須で、頂点の総数は 3 で割り切れる必要があります。
ms.assetid: BC50D532-9E9C-4AAE-B466-9E8C4AD1862A
keywords:
- トライアングル リスト
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: aae797db890c6bee141c3b4a79a6a85a55a6b512
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57653747"
---
# <a name="triangle-lists"></a><span data-ttu-id="db0c4-106">トライアングル リスト</span><span class="sxs-lookup"><span data-stu-id="db0c4-106">Triangle lists</span></span>


<span data-ttu-id="db0c4-107">トライアングル リストとは、独立した三角形のリストです。</span><span class="sxs-lookup"><span data-stu-id="db0c4-107">A triangle list is a list of isolated triangles.</span></span> <span data-ttu-id="db0c4-108">これらの独立した三角形は、距離が近い場合もそうでない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="db0c4-108">The isolated triangles might or might not be near each other.</span></span> <span data-ttu-id="db0c4-109">三角形の一覧には、最低 3 つの頂点が必須で、頂点の総数は 3 で割り切れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="db0c4-109">A triangle list must have at least three vertices and the total number of vertices must be divisible by three.</span></span>

## <a name="span-idexamplespanspan-idexamplespanspan-idexamplespanexample"></a><span data-ttu-id="db0c4-110"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>例</span><span class="sxs-lookup"><span data-stu-id="db0c4-110"><span id="Example"></span><span id="example"></span><span id="EXAMPLE"></span>Example</span></span>


<span data-ttu-id="db0c4-111">接合されていない部分から成るオブジェクトを作成するには、トライアングル リストを使います。</span><span class="sxs-lookup"><span data-stu-id="db0c4-111">Use triangle lists to create an object that is composed of disjoint pieces.</span></span> <span data-ttu-id="db0c4-112">たとえば、3D ゲームでフォース フィールドの壁を作成する 1 つの方法として、連結していない小さい三角形を大量に含むリストを指定する方法があります。</span><span class="sxs-lookup"><span data-stu-id="db0c4-112">For instance, one way to create a force-field wall in a 3D game is to specify a large list of small, unconnected triangles.</span></span> <span data-ttu-id="db0c4-113">その後、発光するように見えるマテリアルとテクスチャをトライアングル リストに適用します。</span><span class="sxs-lookup"><span data-stu-id="db0c4-113">Then apply a material and texture that appears to emit light to the triangle list.</span></span> <span data-ttu-id="db0c4-114">これにより、壁を構成する各三角形が輝いているように表示されます。</span><span class="sxs-lookup"><span data-stu-id="db0c4-114">Each triangle in the wall appears to glow.</span></span> <span data-ttu-id="db0c4-115">各三角形の隙間からは、壁の背後にあるシーンが部分的に見えるようになります。これは、プレイヤーがフォース フィールドを眺めるときに予想する光景です。</span><span class="sxs-lookup"><span data-stu-id="db0c4-115">The scene behind the wall becomes partially visible through the gaps between the triangles, as a player might expect when looking at a force field.</span></span>

<span data-ttu-id="db0c4-116">トライアングル リストは、鋭角を持ち、グーロー シェーディングで影を適用するプリミティブを作成する場合にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="db0c4-116">Triangle lists are also useful for creating primitives that have sharp edges and are shaded with Gouraud shading.</span></span> <span data-ttu-id="db0c4-117">「[面と頂点の法線ベクトル](face-and-vertex-normal-vectors.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="db0c4-117">See [Face and vertex normal vectors](face-and-vertex-normal-vectors.md).</span></span>

<span data-ttu-id="db0c4-118">次の図は、レンダリングされたトライアングル リストを示しています。</span><span class="sxs-lookup"><span data-stu-id="db0c4-118">The following illustration depicts a rendered triangle list.</span></span>

![レンダリングされたトライアングル リストの図](images/trilist.png)

<span data-ttu-id="db0c4-120">次のコードは、このトライアングル リストの頂点の作成方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="db0c4-120">The following code shows how to create vertices for this triangle list.</span></span>

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

<span data-ttu-id="db0c4-121">次のコード例は、このトライアングル リストを Direct3D でレンダリングする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="db0c4-121">The code example below shows how to render this triangle list in Direct3D.</span></span>

```
//
// It is assumed that d3dDevice is a valid
// pointer to a device interface.
//
d3dDevice->DrawPrimitive( D3DPT_TRIANGLELIST, 0, 2 );
```

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="db0c4-122"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="db0c4-122"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="db0c4-123">プリミティブ</span><span class="sxs-lookup"><span data-stu-id="db0c4-123">Primitives</span></span>](primitives.md)

 

 




