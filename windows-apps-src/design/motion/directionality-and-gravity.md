---
author: jwmsft
Description: Learn how Fluent motion uses directionality and gravity.
title: 方向性と重力 - UWP アプリでのアニメーション
label: Directionality and gravity
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: a5216e81bc556a2e761e88b071e988bf6e4f457e
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843866"
---
# <a name="directionality-and-gravity"></a><span data-ttu-id="87266-103">方向性と重力</span><span class="sxs-lookup"><span data-stu-id="87266-103">Directionality and gravity</span></span>

> [!IMPORTANT]
> <span data-ttu-id="87266-104">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="87266-104">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="87266-105">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="87266-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="87266-106">方向指示は、ユーザーがエクスペリエンス全体を通じて行う取り組みの概念的モデルを強固にするために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="87266-106">Directional signals help to solidify the mental model of the journey a user takes across experiences.</span></span> <span data-ttu-id="87266-107">任意の動きの方向は、空間の連続性だけでなく、空間内のオブジェクトの整合性もサポートすることが重要です。</span><span class="sxs-lookup"><span data-stu-id="87266-107">It is important that the direction of any motion support both the continuity of the space as well as the integrity of the objects in the space.</span></span>

<span data-ttu-id="87266-108">方向性は重力のような力を受けます。</span><span class="sxs-lookup"><span data-stu-id="87266-108">Directional movement is subject to forces like gravity.</span></span> <span data-ttu-id="87266-109">動きに力を加えるとモーションの自然な操作感が強化されます。</span><span class="sxs-lookup"><span data-stu-id="87266-109">Applying forces to movement reinforces the natural feel of the motion.</span></span>

## <a name="direction-of-movement"></a><span data-ttu-id="87266-110">動きの方向</span><span class="sxs-lookup"><span data-stu-id="87266-110">Direction of movement</span></span>

<span data-ttu-id="87266-111">:::row::: :::column::: 動きの方向は物理的なモーションに対応します。</span><span class="sxs-lookup"><span data-stu-id="87266-111">:::row::: :::column::: Direction of movement corresponds to physical motion.</span></span> <span data-ttu-id="87266-112">自然界と同じように、オブジェクトは任意の x 軸、y 軸、z 軸で移動します。</span><span class="sxs-lookup"><span data-stu-id="87266-112">Just like in nature, objects can move in any world axis - X,Y,Z.</span></span> <span data-ttu-id="87266-113">このようにして、私たちは画面上のオブジェクトの動きを考えます。</span><span class="sxs-lookup"><span data-stu-id="87266-113">This is how we think of the movement of objects on the screen.</span></span>

        When you move objects, avoid unnatural collisions. Keep in mind where objects come from and go to, and alway support higher level constructs that may be used in the scene, such as scroll direction or layout hierarchy.
    :::column-end:::
    :::column:::
        ![direction backward in](images/Direction.gif)
    :::column-end:::
<span data-ttu-id="87266-114">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="87266-114">:::row-end:::</span></span>

## <a name="direction-of-navigation"></a><span data-ttu-id="87266-115">ナビゲーションの方向</span><span class="sxs-lookup"><span data-stu-id="87266-115">Direction of navigation</span></span>

<span data-ttu-id="87266-116">アプリ内のシーン間のナビゲーションの方向は、概念的なものです。</span><span class="sxs-lookup"><span data-stu-id="87266-116">The direction of navigation between scenes in your app is conceptual.</span></span> <span data-ttu-id="87266-117">ユーザーは前後に移動します。</span><span class="sxs-lookup"><span data-stu-id="87266-117">Users navigate forward and back.</span></span> <span data-ttu-id="87266-118">シーンはビューの内外に移動します。</span><span class="sxs-lookup"><span data-stu-id="87266-118">Scenes move in and out of view.</span></span> <span data-ttu-id="87266-119">これらの概念は物理的な動きと連携してユーザーを誘導します。</span><span class="sxs-lookup"><span data-stu-id="87266-119">These concepts combine with physical movement to guide the user.</span></span>

<span data-ttu-id="87266-120">ナビゲーションによりオブジェクトが前のシーンから新しいシーンに移動する場合、オブジェクトは画面上で A から B の単純な移動を行います。</span><span class="sxs-lookup"><span data-stu-id="87266-120">When navigation causes an object to travel from the previous scene to the new scene, the object makes a simple A-to-B move on the screen.</span></span> <span data-ttu-id="87266-121">動きがより物理的に感じられるようにするために、標準的なイージングに加えて、重力の感覚が追加されます。</span><span class="sxs-lookup"><span data-stu-id="87266-121">To ensure that the movement feels more physical, the standard easing is added, as well as the feeling of gravity.</span></span>

<span data-ttu-id="87266-122">"戻る" ナビゲーションでは、動きが逆になります (B から A)。</span><span class="sxs-lookup"><span data-stu-id="87266-122">For back navigation, the move is reversed (B-to-A).</span></span> <span data-ttu-id="87266-123">ユーザーは戻る移動をしたときに、できるだけ早く以前の状態に戻ることを期待します。</span><span class="sxs-lookup"><span data-stu-id="87266-123">When the user navigates back, they have an expectation to be returned to the previous state as soon as possible.</span></span> <span data-ttu-id="87266-124">タイミングはより迅速で直接的であり、減速のイージングを使用します。</span><span class="sxs-lookup"><span data-stu-id="87266-124">The timing is quicker, more direct, and uses the decelerate easing.</span></span>

<span data-ttu-id="87266-125">ここでは、前後のナビゲーション中に選択された項目が画面上に表示されたままになるため、これらの原則が適用されます。</span><span class="sxs-lookup"><span data-stu-id="87266-125">Here, these priciples are applied as the selected item stays on screen during forward and back navigation.</span></span>

![継続的なモーションの UI の例](images/continuous3.gif)

<span data-ttu-id="87266-127">ナビゲーションにより画面上の項目が置き換えられると、既存のシーンの移動先と、新しいシーンの移動元を示すことが重要です。</span><span class="sxs-lookup"><span data-stu-id="87266-127">When navigation causes items on the screen to be replaced, its important to show where the exiting scene went to, and where the new scene is coming from.</span></span>

<span data-ttu-id="87266-128">これには次のようないくつかの利点があります。</span><span class="sxs-lookup"><span data-stu-id="87266-128">This has several benefits:</span></span>

- <span data-ttu-id="87266-129">空間に対するユーザーの概念的モデルが確立されます。</span><span class="sxs-lookup"><span data-stu-id="87266-129">It solidifies the user's mental model of the space.</span></span>
- <span data-ttu-id="87266-130">既存のシーンの継続時間により、後続のシーンに対してコンテンツをアニメーション化する準備をするためのより長い時間が提供されます。</span><span class="sxs-lookup"><span data-stu-id="87266-130">The duration of the exiting scene provides more time to prepare content to be animated in for the incoming scene.</span></span>
- <span data-ttu-id="87266-131">これにより、アプリの体感的なパフォーマンスが向上します。</span><span class="sxs-lookup"><span data-stu-id="87266-131">It improves the perceived performance of the app.</span></span>

<span data-ttu-id="87266-132">ナビゲーションに関して考慮すべき目立たない 4 つの方向があります。</span><span class="sxs-lookup"><span data-stu-id="87266-132">There are 4 discreet directions of navigation to consider.</span></span>

<span data-ttu-id="87266-133">:::row::: :::column::: **前方イン**</span><span class="sxs-lookup"><span data-stu-id="87266-133">:::row::: :::column::: **Forward-In**</span></span>

        Celebrate content entering the scene in a manner that does not collide with outgoing content. Content decelerates into the scene.
    :::column-end:::
    :::column:::
        ![direction forward in](images/forwardIN.gif)
    :::column-end:::
<span data-ttu-id="87266-134">:::row-end::: :::row::: :::column::: **前方アウト**</span><span class="sxs-lookup"><span data-stu-id="87266-134">:::row-end::: :::row::: :::column::: **Forward-Out**</span></span>

        Content exits quickly. Objects accelerate off screen.
    :::column-end:::
    :::column:::
        ![direction forward out](images/forwardOUT.gif)
    :::column-end:::
<span data-ttu-id="87266-135">:::row-end::: :::row::: :::column::: **後方イン**</span><span class="sxs-lookup"><span data-stu-id="87266-135">:::row-end::: :::row::: :::column::: **Backward-In**</span></span>

        Same as Forward-In, but reversed.
    :::column-end:::
    :::column:::
        ![direction backward in](images/backwardIN.gif)
    :::column-end:::
<span data-ttu-id="87266-136">:::row-end::: :::row::: :::column::: **後方アウト**</span><span class="sxs-lookup"><span data-stu-id="87266-136">:::row-end::: :::row::: :::column::: **Backward-Out**</span></span>

        Same as Forward-Out, but reversed.
    :::column-end:::
    :::column:::
        ![direction backward out](images/backwardOUT.gif)
    :::column-end:::
<span data-ttu-id="87266-137">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="87266-137">:::row-end:::</span></span>

## <a name="gravity"></a><span data-ttu-id="87266-138">重力</span><span class="sxs-lookup"><span data-stu-id="87266-138">Gravity</span></span>

<span data-ttu-id="87266-139">重力によりエクスペリエンスがより自然に感じられるようになります。</span><span class="sxs-lookup"><span data-stu-id="87266-139">Gravity makes your experiences feel more natural.</span></span> <span data-ttu-id="87266-140">z 軸上を移動し、画面上のアフォー ダンスでシーンに固定されていないオブジェクトは、重力の影響を受ける可能性があります。</span><span class="sxs-lookup"><span data-stu-id="87266-140">Objects that move on the Z-axis and are not anchored to the scene by an onscreen affordance have the potential to be affected by gravity.</span></span> <span data-ttu-id="87266-141">オブジェクトがシーンから開放され、脱出速度に到達する前に、重力がオブジェクトを引き下げ、オブジェクトの移動に伴い軌跡のより自然なカーブが生み出されます。</span><span class="sxs-lookup"><span data-stu-id="87266-141">As an object breaks free of the scene and before it reaches escape velocity, gravity pulls down on the object, creating a more natural curve of the object trajectory as it moves.</span></span>

<span data-ttu-id="87266-142">通常、オブジェクトがあるシーンから別のシーンに移動する必要があるときに、重力が生じます。</span><span class="sxs-lookup"><span data-stu-id="87266-142">Gravity typically manifests when an object must jump from one scene to another.</span></span> <span data-ttu-id="87266-143">このため、接続型アニメーションには重力の概念が使用されます。</span><span class="sxs-lookup"><span data-stu-id="87266-143">Because of this, connected animation uses the concept of gravity.</span></span>

<span data-ttu-id="87266-144">ここでは、グリッドの先頭行にある要素が重力の影響を受け、要素がその場所を離れて前方に移動するときに若干下がります。</span><span class="sxs-lookup"><span data-stu-id="87266-144">Here, an element in the top row of the grid is affected by gravity, causing it to drop slightly as it leaves its place and moves to the front.</span></span>

![逆方向へのイン](images/continuity-photos.gif)

## <a name="related-articles"></a><span data-ttu-id="87266-146">関連記事</span><span class="sxs-lookup"><span data-stu-id="87266-146">Related articles</span></span>

- [<span data-ttu-id="87266-147">モーションの概要</span><span class="sxs-lookup"><span data-stu-id="87266-147">Motion overview</span></span>](index.md)
- [<span data-ttu-id="87266-148">タイミングとイージング</span><span class="sxs-lookup"><span data-stu-id="87266-148">Timing and easing</span></span>](timing-and-easing.md)