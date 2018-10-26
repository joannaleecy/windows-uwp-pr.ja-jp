---
title: ワールド変換
description: ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。
ms.assetid: 767B032C-69D0-4583-8FEB-247F4C41E31D
keywords:
- ワールド変換
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 9c6ada4bd964a9430d6ef47bd46f954ca76c404a
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5565130"
---
# <a name="world-transform"></a><span data-ttu-id="a347e-104">ワールド変換</span><span class="sxs-lookup"><span data-stu-id="a347e-104">World transform</span></span>


<span data-ttu-id="a347e-105">ワールド変換は、座標系をモデル空間からワールド空間に変更します。モデル空間では、頂点はモデルのローカル原点を基準として相対的に定義されます。</span><span class="sxs-lookup"><span data-stu-id="a347e-105">A world transform changes coordinates from model space, where vertices are defined relative to a model's local origin, to world space.</span></span> <span data-ttu-id="a347e-106">ワールド空間では、頂点はシーン内のすべてのオブジェクトに共通の原点を基準として相対的に定義されます。</span><span class="sxs-lookup"><span data-stu-id="a347e-106">In world space, vertices are defined relative to an origin common to all the objects in a scene.</span></span> <span data-ttu-id="a347e-107">ワールド変換は、モデルをワールド空間に配置します。</span><span class="sxs-lookup"><span data-stu-id="a347e-107">The world transform places a model into the world.</span></span>

## <span id="What_Is_a_World_Transform"></span><span id="what_is_a_world_transform"></span><span id="WHAT_IS_A_WORLD_TRANSFORM"></span>


<span data-ttu-id="a347e-108">次の図は、ワールド座標系とモデルのローカル座標系の関係を示しています。</span><span class="sxs-lookup"><span data-stu-id="a347e-108">The following diagram shows the relationship between the world coordinate system and a model's local coordinate system.</span></span>

![ワールド座標とローカル座標の関係を示す図](images/worldcrd.png)

<span data-ttu-id="a347e-110">ワールド変換には、平行移動、回転、スケーリングを任意に組み合わせて含めることができます。</span><span class="sxs-lookup"><span data-stu-id="a347e-110">The world transform can include any combination of translations, rotations, and scalings.</span></span>

## <a name="span-idsettingupaworldmatrixxmlspansetting-up-a-world-matrix"></a><span data-ttu-id="a347e-111"><span id="SETTING_UP_A_WORLD_MATRIX.XML"></span>ワールド行列の設定</span><span class="sxs-lookup"><span data-stu-id="a347e-111"><span id="SETTING_UP_A_WORLD_MATRIX.XML"></span>Setting Up a World Matrix</span></span>


<span data-ttu-id="a347e-112">ワールド変換を作成するには、他の変換と同様に、複数の行列を組み合わせて、それらの効果をすべて含む 1 つの行列に連結します。</span><span class="sxs-lookup"><span data-stu-id="a347e-112">As with any other transform, create the world transform by concatenating a series of matrices into a single matrix that contains the sum total of their effects.</span></span> <span data-ttu-id="a347e-113">最も単純な例として、モデルがワールド原点に位置し、そのローカル座標軸がワールド空間と同じ方向であるとすると、ワールド行列は単位行列になります。</span><span class="sxs-lookup"><span data-stu-id="a347e-113">In the simplest case, when a model is at the world origin and its local coordinate axes are oriented the same as world space, the world matrix is the identity matrix.</span></span> <span data-ttu-id="a347e-114">より一般的な例でのワールド行列は、ワールド空間への平行移動と、必要に応じてモデルを回転させる 1 つ以上の回転の組み合わせになります。</span><span class="sxs-lookup"><span data-stu-id="a347e-114">More commonly, the world matrix is a combination of a translation into world space and possibly one or more rotations to turn the model as needed.</span></span>

<span data-ttu-id="a347e-115">Direct3D は、ユーザーが設定したワールド行列とビュー行列を使って、いくつかの内部データ構造を構成します。</span><span class="sxs-lookup"><span data-stu-id="a347e-115">Direct3D uses the world and view matrices that you set to configure several internal data structures.</span></span> <span data-ttu-id="a347e-116">新しいワールド行列またはビュー行列を設定するたびに、関連付けられた内部構造がシステムによって再計算されます。</span><span class="sxs-lookup"><span data-stu-id="a347e-116">Each time you set a new world or view matrix, the system recalculates the associated internal structures.</span></span> <span data-ttu-id="a347e-117">これらの行列を頻繁に、たとえばフレーム当たりに数千回という頻度で設定すると、計算に時間を要することになります。</span><span class="sxs-lookup"><span data-stu-id="a347e-117">Setting these matrices frequently-for example, thousands of times per frame-is computationally time-consuming.</span></span> <span data-ttu-id="a347e-118">必要な計算回数を最小限に抑えるには、ワールド行列とビュー行列を連結して 1 つのワールド ビュー行列を作成し、それをワールド行列として設定した後、ビュー行列を単位元に設定します。</span><span class="sxs-lookup"><span data-stu-id="a347e-118">You can minimize the number of required calculations by concatenating your world and view matrices into a world-view matrix that you set as the world matrix, and then setting the view matrix to the identity.</span></span> <span data-ttu-id="a347e-119">このとき、必要に応じてワールド行列を変更、連結、リセットできるように、個々のワールド行列とビュー行列のキャッシュ コピーを保持しておくことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a347e-119">Keep cached copies of individual world and view matrices so that you can modify, concatenate, and reset the world matrix as needed.</span></span>

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="a347e-120"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="a347e-120"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="a347e-121">変換</span><span class="sxs-lookup"><span data-stu-id="a347e-121">Transforms</span></span>](transforms.md)

 

 




