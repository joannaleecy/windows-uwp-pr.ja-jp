---
title: 頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)
description: 頂点バッファーには、頂点のリストのデータが保持されます。
ms.assetid: 695115D2-9DA0-41F2-9416-33BFAB698129
keywords:
- 頂点バッファー ビュー (VBV)
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: cfb92c4f876d85388ce325f151408fe7b9e8d8b4
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8482922"
---
# <a name="vertex-buffer-view-vbv-and-index-buffer-view-ibv"></a><span data-ttu-id="e0822-104">頂点バッファー ビュー (VBV) とインデックス バッファー ビュー (IBV)</span><span class="sxs-lookup"><span data-stu-id="e0822-104">Vertex buffer view (VBV) and Index buffer view (IBV)</span></span>


<span data-ttu-id="e0822-105">頂点バッファーには、頂点のリストのデータが保持されます。</span><span class="sxs-lookup"><span data-stu-id="e0822-105">A vertex buffer holds data for a list of vertices.</span></span> <span data-ttu-id="e0822-106">各頂点のデータには、位置、色、法線ベクトル、テクスチャ座標などを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="e0822-106">The data for each vertex can include position, color, normal vector, texture co-ordinates, and so on.</span></span> <span data-ttu-id="e0822-107">インデックス バッファーには、頂点バッファーへの整数インデックス (オフセット) が保持されます。インデックス バッファーは、頂点の完全なリストのサブセットから成るオブジェクトを定義してレンダリングするために使われます。</span><span class="sxs-lookup"><span data-stu-id="e0822-107">An index buffer holds integer indexes (offsets) into a vertex buffer, and is used to define and render an object made up of a subset of the full list of vertices.</span></span>

<span data-ttu-id="e0822-108">多くの場合、単独の頂点の定義はアプリケーションが独自に決定できます。たとえば、次のように定義することができます。</span><span class="sxs-lookup"><span data-stu-id="e0822-108">The definition of a single vertex is often up to the application to define, such as:</span></span>

``` syntax
struct CUSTOMVERTEX { 
        FLOAT x, y, z;      // The position
        FLOAT nx, ny, nz;   // The normal
        DWORD color;        // RGBA color
        FLOAT tu, tv;       // The texture coordinates. 
}; 
```

<span data-ttu-id="e0822-109">その後、CUSTOMVERTEX の定義は、頂点バッファーの作成時にグラフィックス ドライバーに渡されます。</span><span class="sxs-lookup"><span data-stu-id="e0822-109">The definition of CUSTOMVERTEX would then be passed to the graphics driver when creating vertex buffers.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="e0822-110"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="e0822-110"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="e0822-111">ビュー</span><span class="sxs-lookup"><span data-stu-id="e0822-111">Views</span></span>](views.md)

 

 




