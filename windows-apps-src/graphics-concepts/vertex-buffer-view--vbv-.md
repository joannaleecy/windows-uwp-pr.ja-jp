---
title: 頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)
description: 頂点バッファーには、頂点のリストのデータが保持されます。
ms.assetid: 695115D2-9DA0-41F2-9416-33BFAB698129
keywords:
- 頂点バッファー ビュー (VBV)
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 7956c7a03256da04e98a5b8f9a33951d7e0216d3
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6203957"
---
# <a name="vertex-buffer-view-vbv-and-index-buffer-view-ibv"></a><span data-ttu-id="2cafb-104">頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)</span><span class="sxs-lookup"><span data-stu-id="2cafb-104">Vertex buffer view (VBV) and Index buffer view (IBV)</span></span>


<span data-ttu-id="2cafb-105">頂点バッファーには、頂点のリストのデータが保持されます。</span><span class="sxs-lookup"><span data-stu-id="2cafb-105">A vertex buffer holds data for a list of vertices.</span></span> <span data-ttu-id="2cafb-106">各頂点のデータには、位置、色、法線ベクトル、テクスチャ座標などを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="2cafb-106">The data for each vertex can include position, color, normal vector, texture co-ordinates, and so on.</span></span> <span data-ttu-id="2cafb-107">インデックス バッファーには、頂点バッファーへの整数インデックス (オフセット) が保持されます。インデックス バッファーは、頂点の完全なリストのサブセットから成るオブジェクトを定義してレンダリングするために使われます。</span><span class="sxs-lookup"><span data-stu-id="2cafb-107">An index buffer holds integer indexes (offsets) into a vertex buffer, and is used to define and render an object made up of a subset of the full list of vertices.</span></span>

<span data-ttu-id="2cafb-108">多くの場合、単独の頂点の定義はアプリケーションが独自に決定できます。たとえば、次のように定義することができます。</span><span class="sxs-lookup"><span data-stu-id="2cafb-108">The definition of a single vertex is often up to the application to define, such as:</span></span>

``` syntax
struct CUSTOMVERTEX { 
        FLOAT x, y, z;      // The position
        FLOAT nx, ny, nz;   // The normal
        DWORD color;        // RGBA color
        FLOAT tu, tv;       // The texture coordinates. 
}; 
```

<span data-ttu-id="2cafb-109">その後、CUSTOMVERTEX の定義は、頂点バッファーの作成時にグラフィックス ドライバーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="2cafb-109">The definition of CUSTOMVERTEX would then be passed to the graphics driver when creating vertex buffers.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="2cafb-110"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="2cafb-110"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="2cafb-111">ビュー</span><span class="sxs-lookup"><span data-stu-id="2cafb-111">Views</span></span>](views.md)

 

 




