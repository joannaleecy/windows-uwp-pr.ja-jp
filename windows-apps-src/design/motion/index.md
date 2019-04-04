---
Description: 目的がはっきりとしており、適切にデザインされたモーションは、アプリに強い印象を与え、精巧で完成度の高い操作性を感じさせます。 コンテキストの変化がわかりやすく、視覚的な切り替えがエクスペリエンスに結び付きます。
title: UWP アプリでのモーションとアニメーション
ms.assetid: 21AA1335-765E-433A-85D8-560B340AE966
label: Motion
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 2701844ccefdc5a535fa8fc20086c550cb7bc29e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57583449"
---
# <a name="motion-for-uwp-apps"></a><span data-ttu-id="42ad5-105">UWP アプリのモーション</span><span class="sxs-lookup"><span data-stu-id="42ad5-105">Motion for UWP apps</span></span>

![ヒーロー イメージ](images/header-motion2.svg)

<span data-ttu-id="42ad5-107">Fluent モーションはアプリで目的を果たします。</span><span class="sxs-lookup"><span data-stu-id="42ad5-107">Fluent motion serves a purpose in your app.</span></span> <span data-ttu-id="42ad5-108">これは、ユーザーの動作に基づいてインテリジェントなフィードバックを提供し、UI にアクティブな印象を与え、アプリ内でユーザーのナビゲーションを誘導します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-108">It gives intelligent feedback based on the user's behavior, keeps the UI feeling alive, and guides the user's navigation through your app.</span></span> <span data-ttu-id="42ad5-109">Fluent モーションは、ユーザーとそのデジタル エクスペリエンス間の感情面の結び付きを生み出します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-109">Fluent motion elicits an emotional connection between a user and their digital experience.</span></span> <span data-ttu-id="42ad5-110">マイクロソフトでは、ユーザーが既に現実世界から認識している自然な動きの基盤のうえに構築し、そこからシステムを拡張します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-110">We build on a foundation of natural movement the user already understands from the physical world, and we extend our system from there.</span></span>

## <a name="fluent-motion-principles"></a><span data-ttu-id="42ad5-111">Fluent モーションの原則</span><span class="sxs-lookup"><span data-stu-id="42ad5-111">Fluent motion principles</span></span>

### <a name="physical"></a><span data-ttu-id="42ad5-112">運動能力</span><span class="sxs-lookup"><span data-stu-id="42ad5-112">Physical</span></span>

<span data-ttu-id="42ad5-113">動作中のオブジェクトは、現実世界でのオブジェクトの動作を示します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-113">Objects in motion exhibit behaviors of objects in the real world.</span></span> <span data-ttu-id="42ad5-114">滑らかで応答性の高い動きによって、自然な操作性を感じさせるエクスペリエンスが実現され、感情面の結び付きが生みだされ、個性が追加されます。</span><span class="sxs-lookup"><span data-stu-id="42ad5-114">Fluid, responsive movement makes the experience feel natural, creating emotional connections and adding personality.</span></span>

![物理モーションの UI の例](images/Physical.gif)
> <span data-ttu-id="42ad5-116">タッチで UI を操作すると、UI の動きが、操作の速度に直接関連します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-116">When you interact with UI via touch, the movement of the UI is directly related to the velocity of the interaction.</span></span> <span data-ttu-id="42ad5-117">また、タッチは直接操作であるため、操作するオブジェクトが周囲のオブジェクトに影響します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-117">And because touch is direct manipulation, the object you interect with affects the objects around it.</span></span>

### <a name="functional"></a><span data-ttu-id="42ad5-118">機能性</span><span class="sxs-lookup"><span data-stu-id="42ad5-118">Functional</span></span>

<span data-ttu-id="42ad5-119">モーションは目的を果たし、確信があります。</span><span class="sxs-lookup"><span data-stu-id="42ad5-119">Motion serves a purpose and has conviction.</span></span> <span data-ttu-id="42ad5-120">複雑さに関してユーザーをサポートし、階層を確立する手助けをします。</span><span class="sxs-lookup"><span data-stu-id="42ad5-120">It guides the user through complexity and helps establish hierarchy.</span></span> <span data-ttu-id="42ad5-121">モーションは、パフォーマンスが向上した印象を与え、体感する待ち時間を隠蔽することでユーザー エクスペリエンスを最適化します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-121">Movement gives the impression of enhanced performance and optimizes the user experience by hiding perceived latency.</span></span>

![機能的なモーションの UI の例](images/functional.gif)
> <span data-ttu-id="42ad5-123">ページ切り替えは、目的に特化されています。</span><span class="sxs-lookup"><span data-stu-id="42ad5-123">Page transitions are purpose-built.</span></span> <span data-ttu-id="42ad5-124">ページが相互に関連する方法に関するヒントを提供します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-124">They give hints about how pages are related to each other.</span></span> <span data-ttu-id="42ad5-125">パフォーマンスが最適でない場合でも速く感じられるような方法で移動します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-125">They move in a manner that's perceived as fast even when performance is not optimal.</span></span>

### <a name="continuous"></a><span data-ttu-id="42ad5-126">継続性</span><span class="sxs-lookup"><span data-stu-id="42ad5-126">Continuous</span></span>

<span data-ttu-id="42ad5-127">ポイントからポイントへの滑らか動きは、自然に目を引きつけ、ユーザーを誘導します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-127">Fluid movement from point to point naturally draws the eye and guides the user.</span></span> <span data-ttu-id="42ad5-128">適切にユーザーのタスクをまとめて、よりコンシューマブルで親しみやすく感じられるようにします。</span><span class="sxs-lookup"><span data-stu-id="42ad5-128">It elegantly stitches together a user’s task, making it feel more consumable and friendly.</span></span>

![継続的なモーションの UI の例](images/continuous3.gif)
> <span data-ttu-id="42ad5-130">オブジェクトは、シーン間を移動したり、シーン内でモーフィングして継続性を提供し、ユーザーがコンテキストを維持できるようにします。</span><span class="sxs-lookup"><span data-stu-id="42ad5-130">Objects can travel from scene to scene or morph within a scene to provide continuity and help the user maintain context.</span></span>

### <a name="contextual"></a><span data-ttu-id="42ad5-131">状況依存</span><span class="sxs-lookup"><span data-stu-id="42ad5-131">Contextual</span></span>

<span data-ttu-id="42ad5-132">インテリジェントなモーションは、UI を操作する方法に沿った方法でユーザーにフィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="42ad5-132">Intelligent motion provides feedback to the user in a manner that's aligned with how they manipulated the UI.</span></span> <span data-ttu-id="42ad5-133">操作はユーザーを中心にしています。</span><span class="sxs-lookup"><span data-stu-id="42ad5-133">Interaction is centered around the user.</span></span> <span data-ttu-id="42ad5-134">動きはフォーム ファクターに適切であると感じられ、シナリオに基づいて設計されています。</span><span class="sxs-lookup"><span data-stu-id="42ad5-134">The movement feels appropriate to the form-factor and designed around the scenario.</span></span> <span data-ttu-id="42ad5-135">各ユーザーにとって快適である必要があります。</span><span class="sxs-lookup"><span data-stu-id="42ad5-135">It should be comfortable for each user.</span></span>

![状況依存のモーションの UI の例](images/Contextual.gif)
> <span data-ttu-id="42ad5-137">アニメーションはユーザーの操作に沿ったものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="42ad5-137">Animation should tie back to the user interaction.</span></span> <span data-ttu-id="42ad5-138">コンテキスト メニューは、ユーザーがアクティブ化したポイントから展開されます。</span><span class="sxs-lookup"><span data-stu-id="42ad5-138">A context menu is deployed from a point where the user activated it.</span></span> 

## <a name="motion-articles"></a><span data-ttu-id="42ad5-139">モーションの記事</span><span class="sxs-lookup"><span data-stu-id="42ad5-139">Motion articles</span></span>

:::row:::
    :::column:::
        ### [Timing and easing](timing-and-easing.md)
        Timing and easing are important elements that make motion feel natural for objects entering, exiting, or moving within the UI.
    :::column-end:::
    :::column:::
        ### [Directionality and gravity](directionality-and-gravity.md)
        Directional signals help provide a solid mental model of the journey a user takes across experiences. Directional movement is subject to forces like gravity, which reinforces the natural feel of the movement.
    :::column-end:::
:::row-end:::
:::row:::
    :::column:::
        ### [Page transitions](page-transitions.md)
        Page transitions navigate users between pages in an app, providing feedback about the relationship between pages. They help users understand where they are in the navigation hierarchy.
    :::column-end:::
    :::column:::
        ### [Connected animation](connected-animation.md)
        Connected animations let you create a dynamic and compelling navigation experience by animating the transition of an element between two different views.
    :::column-end:::
:::row-end:::
