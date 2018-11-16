---
title: シェーダー リソース ビュー (SRV) と順序指定されていないアクセス ビュー (UAV)
description: シェーダー リソース ビューは、通常、シェーダーがアクセスできる形式でテクスチャをラップします。 順序指定されていないアクセス ビューも同様の機能を提供しますが、任意の順序で、テクスチャ (やその他のリソース) の読み取りや書き込みを行うことができます。
ms.assetid: 4505BCD2-0EDA-40F2-887C-EC081FE32E8F
keywords:
- シェーダー リソース ビュー (SRV)
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: e98b9942dfc14604c061a036cd3c9803abaf3915
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6836240"
---
# <a name="shader-resource-view-srv-and-unordered-access-view-uav"></a><span data-ttu-id="b1c5a-105">シェーダー リソース ビュー (SRV) と順序指定されていないアクセス ビュー (UAV)</span><span class="sxs-lookup"><span data-stu-id="b1c5a-105">Shader resource view (SRV) and Unordered Access view (UAV)</span></span>


<span data-ttu-id="b1c5a-106">シェーダー リソース ビューは、通常、シェーダーがアクセスできる形式でテクスチャをラップします。</span><span class="sxs-lookup"><span data-stu-id="b1c5a-106">Shader resource views typically wrap textures in a format that the shaders can access them.</span></span> <span data-ttu-id="b1c5a-107">順序指定されていないアクセス ビューも同様の機能を提供しますが、任意の順序で、テクスチャ (やその他のリソース) の読み取りや書き込みを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="b1c5a-107">An unordered access view provides similar functionality, but enables the reading and writing to the texture (or other resource) in any order.</span></span>

<span data-ttu-id="b1c5a-108">テクスチャを 1 つだけラップするのが、おそらく最もシンプルなシェーダー リソース ビューの形です。</span><span class="sxs-lookup"><span data-stu-id="b1c5a-108">Wrapping a single texture is probably the simplest form of shader resource view.</span></span> <span data-ttu-id="b1c5a-109">より複雑な例としては、サブリソース (ミップマップ テクスチャの個々の配列、プレーン、または色)、3D テクスチャ、1D テクスチャのグラデーションなどのコレクションがあります。</span><span class="sxs-lookup"><span data-stu-id="b1c5a-109">More complex examples would be a collection of subresources (individual arrays, planes, or colors from a mipmapped texture), 3D textures, 1D texture color gradients, and so on.</span></span>

<span data-ttu-id="b1c5a-110">順序指定されていないアクセス ビューは、パフォーマンスの面ではややコストが高くなりますが、たとえばテクスチャの読み取りと同時に書き込みをすることができます。</span><span class="sxs-lookup"><span data-stu-id="b1c5a-110">Unordered access views are slightly more costly in terms of performance, but allow, for example, a texture to be written to at the same time that it is being read from.</span></span> <span data-ttu-id="b1c5a-111">そのため、更新されたテクスチャをグラフィック パイプラインによって他の目的に再利用できます。</span><span class="sxs-lookup"><span data-stu-id="b1c5a-111">This enables the updated texture to be re-used by the graphics pipeline for some other purpose.</span></span> <span data-ttu-id="b1c5a-112">シェーダー リソース ビューは、読み取り専用です (これは、最も一般的なリソースの使い方です)。</span><span class="sxs-lookup"><span data-stu-id="b1c5a-112">Shader resource views are for read only use (which is the most common use of resources).</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="b1c5a-113"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="b1c5a-113"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="b1c5a-114">ビュー</span><span class="sxs-lookup"><span data-stu-id="b1c5a-114">Views</span></span>](views.md)

 

 




