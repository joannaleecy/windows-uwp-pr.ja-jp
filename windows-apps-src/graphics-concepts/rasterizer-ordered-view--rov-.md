---
title: ラスタライザー順序指定ビュー (ROV)
description: ラスタライザー順序指定ビューを使うと、深度バッファーの一部の制約に対処できます。特に、透明度が含まれた複数のテクスチャがあって、それらがすべて同じピクセルに適用される場合に有効です。
ms.assetid: BCB1EE0D-4C1D-4E17-BDB7-173F448E0A7B
keywords:
- ラスタライザー順序指定ビュー (ROV)
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: ed49ba81c44a799e4d827d636f601c77d01333b3
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8745822"
---
# <a name="rasterizer-ordered-view-rov"></a><span data-ttu-id="42d51-104">ラスタライザー順序指定ビュー (ROV)</span><span class="sxs-lookup"><span data-stu-id="42d51-104">Rasterizer ordered view (ROV)</span></span>


<span data-ttu-id="42d51-105">ラスタライザー順序指定ビューを使うと、深度バッファーの一部の制約に対処できます。特に、透明度が含まれた複数のテクスチャがあって、それらがすべて同じピクセルに適用される場合に有効です。</span><span class="sxs-lookup"><span data-stu-id="42d51-105">Rasterizer ordered views enable some of the limitations of a depth buffer to be addressed, in particular having multiple textures containing transparency all applying to the same pixels.</span></span>

<span data-ttu-id="42d51-106">ラスタライザー順序指定ビューは、"描画順序に依存しない透明化" (OIT) アルゴリズムをピクセルのレンダリングに適用できるようにします。</span><span class="sxs-lookup"><span data-stu-id="42d51-106">Rasterizer ordered views enable "Order Independent Transparency" (OIT) algorithms to be applied to the rendering of pixels.</span></span> <span data-ttu-id="42d51-107">深度バッファーではピクセルを描画するか、隠すことしかできず、透明度を利用して中途半端に見えなくするという概念はありません。</span><span class="sxs-lookup"><span data-stu-id="42d51-107">A depth buffer only enables a pixel to be drawn or occluded, there is no concept of partial occlusion through transparency.</span></span> <span data-ttu-id="42d51-108">OIT アルゴリズムは、透明なテクスチャを正しい順序で適用します。そのため、たとえばですが、透明なガラス オブジェクトをガラス窓の後ろに表示し、そのガラス窓の手前には透明なテクスチャを使用した何らかの植物を表示した場合に、最終的な結果が予想通りに正しく描画されます。</span><span class="sxs-lookup"><span data-stu-id="42d51-108">OIT algorithms apply transparent textures in the correct order, so if, for example, a transparent glass object should appear behind a glass window that is behind some vegetation that uses transparent textures, then the final result is drawn predictably correct.</span></span> <span data-ttu-id="42d51-109">ROV と OIT アルゴリズムがなければ、こうした透明なオブジェクトの描画順序が予想できなくなるため、レンダリングされるシーンが複雑で誤ったものになる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="42d51-109">Without ROVs and OIT algorithms, the order these transparent objects would be drawn was unpredictable and the rendered scene could simply be confusing and wrong.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="42d51-110"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="42d51-110"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="42d51-111">ビュー</span><span class="sxs-lookup"><span data-stu-id="42d51-111">Views</span></span>](views.md)

 

 




