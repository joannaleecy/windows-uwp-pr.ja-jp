---
title: 光源
description: 光源は、シーン内のオブジェクトを照射するのに使われます。 各オブジェクト頂点の色は、現在のテクスチャ マップ、頂点の色、光源に基づきます。
ms.assetid: AB16CF5B-47CE-455C-A8BD-36305E54BEA9
keywords:
- 光源
author: michaelfromredmond
ms.author: mithom
ms.date: 02/08/2017
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 6f690e08d211692b05f0a80722aa4a3e3a06b39f
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7168537"
---
# <a name="lighting"></a><span data-ttu-id="49ccb-105">光源</span><span class="sxs-lookup"><span data-stu-id="49ccb-105">Lighting</span></span>


<span data-ttu-id="49ccb-106">光源は、シーン内のオブジェクトを照射するのに使われます。</span><span class="sxs-lookup"><span data-stu-id="49ccb-106">Lights are used to illuminate objects in a scene.</span></span> <span data-ttu-id="49ccb-107">各オブジェクト頂点の色は、現在のテクスチャ マップ、頂点の色、光源に基づきます。</span><span class="sxs-lookup"><span data-stu-id="49ccb-107">The color of each object vertex is based on the current texture map, vertex colors, and light sources.</span></span>

<span data-ttu-id="49ccb-108">**注:** このセクションは、固定関数パイプラインのみです。</span><span class="sxs-lookup"><span data-stu-id="49ccb-108">**Note** This section is only for the fixed-function pipeline.</span></span> <span data-ttu-id="49ccb-109">プログラム可能なシェーダーは、すべての光源を明示的に実行します。</span><span class="sxs-lookup"><span data-stu-id="49ccb-109">Programmable shaders perform all lighting explicitly.</span></span>

 

## <a name="span-idin-this-sectionspanin-this-section"></a><span data-ttu-id="49ccb-110"><span id="in-this-section"></span>このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="49ccb-110"><span id="in-this-section"></span>In this section</span></span>


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="49ccb-111">トピック</span><span class="sxs-lookup"><span data-stu-id="49ccb-111">Topic</span></span></th>
<th align="left"><span data-ttu-id="49ccb-112">説明</span><span class="sxs-lookup"><span data-stu-id="49ccb-112">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="lighting-overview.md"><span data-ttu-id="49ccb-113">光源の概要</span><span class="sxs-lookup"><span data-stu-id="49ccb-113">Lighting overview</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="49ccb-114">Direct3D の光源を使うときは、Direct3D が照明のディテールを自動的に処理できるようにします。</span><span class="sxs-lookup"><span data-stu-id="49ccb-114">When you use Direct3D lighting, you allow Direct3D to handle the details of illumination for you.</span></span> <span data-ttu-id="49ccb-115">詳しい知識のあるユーザーは、必要に応じて自分で光源を実行することもできます。</span><span class="sxs-lookup"><span data-stu-id="49ccb-115">Advanced users can perform lighting on their own, if desired.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="light-types.md"><span data-ttu-id="49ccb-116">光源の種類</span><span class="sxs-lookup"><span data-stu-id="49ccb-116">Light types</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="49ccb-117">光源の種類プロパティは、使う光源の種類を定義します。</span><span class="sxs-lookup"><span data-stu-id="49ccb-117">The light type property defines which type of light source you're using.</span></span> <span data-ttu-id="49ccb-118">Direct3D には 3 種類の光源 (ポイント ライト、スポットライト、指向性ライト) があります。</span><span class="sxs-lookup"><span data-stu-id="49ccb-118">There are three types of lights in Direct3D - point lights, spotlights, and directional lights.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="light-properties.md"><span data-ttu-id="49ccb-119">光源のプロパティ</span><span class="sxs-lookup"><span data-stu-id="49ccb-119">Light properties</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="49ccb-120">光源のプロパティは、光源の種類 (ポイント、指向性、スポットライト)、減衰、色、方向、位置、範囲を表します。</span><span class="sxs-lookup"><span data-stu-id="49ccb-120">Light properties describe a light source's type (point, directional, spotlight), attenuation, color, direction, position, and range.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="mathematics-of-lighting.md"><span data-ttu-id="49ccb-121">光源の計算</span><span class="sxs-lookup"><span data-stu-id="49ccb-121">Mathematics of lighting</span></span></a></p></td>
<td align="left"><p><span data-ttu-id="49ccb-122">Direct3D の照明モデルは、環境光、拡散光、反射光、放射光を扱います。</span><span class="sxs-lookup"><span data-stu-id="49ccb-122">The Direct3D Light Model covers ambient, diffuse, specular, and emissive lighting.</span></span> <span data-ttu-id="49ccb-123">これにより、さまざまな照明の状況に十分対応することができます。</span><span class="sxs-lookup"><span data-stu-id="49ccb-123">This is enough flexibility to solve a wide range of lighting situations.</span></span> <span data-ttu-id="49ccb-124">シーン内の照明の合計量は、<em>全体照明</em>と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="49ccb-124">The total amount of light in a scene is called the <em>global illumination</em>.</span></span></p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idrelated-topicsspanrelated-topics"></a><span data-ttu-id="49ccb-125"><span id="related-topics"></span>関連トピック</span><span class="sxs-lookup"><span data-stu-id="49ccb-125"><span id="related-topics"></span>Related topics</span></span>


[<span data-ttu-id="49ccb-126">Direct3D グラフィックスの学習ガイド</span><span class="sxs-lookup"><span data-stu-id="49ccb-126">Direct3D Graphics Learning Guide</span></span>](index.md)

 

 




