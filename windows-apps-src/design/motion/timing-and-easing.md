---
author: jwmsft
Description: Learn how Fluent motion uses timing and easing functions.
title: タイミングとイージング - UWP アプリでのアニメーション
label: Timing and easing
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 9983c62804dad4f0202fc83e3f9b5f23714352d2
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6466391"
---
# <a name="timing-and-easing"></a><span data-ttu-id="21aa7-103">タイミングとイージング</span><span class="sxs-lookup"><span data-stu-id="21aa7-103">Timing and easing</span></span>

<span data-ttu-id="21aa7-104">モーションが現実世界に基づいている場合、私たちは速度とパフォーマンスへの期待を伴うデジタル メディアでもあります。</span><span class="sxs-lookup"><span data-stu-id="21aa7-104">While motion is based in the real world, we are also a digital medium, which comes with an expectation of speed and performance.</span></span> 

## <a name="how-fluent-motion-uses-time"></a><span data-ttu-id="21aa7-105">Fluent モーションが時間を使用する方法</span><span class="sxs-lookup"><span data-stu-id="21aa7-105">How Fluent motion uses time</span></span>

<span data-ttu-id="21aa7-106">タイミングは、UI 内で出入りしたり、移動したりするオブジェクトのモーションを自然に感じさせる重要な要素です。</span><span class="sxs-lookup"><span data-stu-id="21aa7-106">Timing is an important element to making motion feel natural for objects entering, exiting, or moving within the UI.</span></span>

1. <span data-ttu-id="21aa7-107">ビューに入るオブジェクトまたはシーンはあっという間ですが、美しく彩ります。</span><span class="sxs-lookup"><span data-stu-id="21aa7-107">Objects or scenes entering the view are quick, but celebrated.</span></span> <span data-ttu-id="21aa7-108">これらのアニメーションは、通常、シーンの階層的なビルドアップを可能にするために、シーンから出るときより継続時間が長くなります。</span><span class="sxs-lookup"><span data-stu-id="21aa7-108">These animations are typically longer in duration than exits to allow for hierarchical build-up of a scene.</span></span>
1. <span data-ttu-id="21aa7-109">ビューを出るオブジェクトまたはシーンは、非常にあっという間です。</span><span class="sxs-lookup"><span data-stu-id="21aa7-109">Objects or scenes exiting the view are very quick.</span></span> <span data-ttu-id="21aa7-110">ユーザーは、UI がどこに行ったかを理解できる必要があります。</span><span class="sxs-lookup"><span data-stu-id="21aa7-110">The user should be able to understand where the UI went.</span></span> <span data-ttu-id="21aa7-111">ただし、UI が閉じたら、それが邪魔にならないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="21aa7-111">However, once the UI is dismissed, it should get out of the way.</span></span>
1. <span data-ttu-id="21aa7-112">シーンを移動するオブジェクトは、移動距離に適した時間が必要です。</span><span class="sxs-lookup"><span data-stu-id="21aa7-112">Objects translating across a scene should have a duration appropriate to the amount of distance they travel.</span></span>

## <a name="timing-in-fluent-motion"></a><span data-ttu-id="21aa7-113">Fluent モーションのタイミング</span><span class="sxs-lookup"><span data-stu-id="21aa7-113">Timing in Fluent motion</span></span>

<span data-ttu-id="21aa7-114">Fluent のモーションのタイミングでは、ベースラインとして 500 ミリ秒 (0.5 秒) を使用します。これはユーザーが瞬間に認識する最長時間です。</span><span class="sxs-lookup"><span data-stu-id="21aa7-114">The timing of motion in Fluent uses 500ms (or one-half second) as a baseline because this is the maximum amount of time that a user perceives as instant.</span></span>

![ヒーロー イメージ](images/time.gif)

### <a name="150ms-exit"></a><span data-ttu-id="21aa7-116">**150ミリ秒** (終了)</span><span class="sxs-lookup"><span data-stu-id="21aa7-116">**150ms** (Exit)</span></span>

:::row:::
    :::column:::
        Use for objects or pages that are exiting the scene or closing.
        Allows for very quick directional feedback of exiting UI where timing does not impede upon framerate to achieve a smooth animation.
    :::column-end:::
    :::column:::
        ![150ms motion](images/150msAlt.gif)
    :::column-end:::
:::row-end:::

### <a name="300ms-enter"></a><span data-ttu-id="21aa7-117">**300 ミリ秒** (入力)</span><span class="sxs-lookup"><span data-stu-id="21aa7-117">**300ms** (Enter)</span></span>

:::row:::
    :::column:::
        Use for objects or pages that are entering the scene or opening.
        Allows a reasonable amount of time to celebrate content as it enters the scene.
    :::column-end:::
    :::column:::
        ![300ms motion](images/300ms.gif)
    :::column-end:::
:::row-end:::

### <a name="500ms-move"></a><span data-ttu-id="21aa7-118">**≤500 ミリ秒** (移動)</span><span class="sxs-lookup"><span data-stu-id="21aa7-118">**≤500ms** (Move)</span></span>

:::row:::
    :::column:::
        Use for objects which are translating across a single scene or multiple scenes. 
    :::column-end:::
    :::column:::
        ![500ms motion](images/500ms.gif)
    :::column-end:::
:::row-end:::

## <a name="easing-in-fluent-motion"></a><span data-ttu-id="21aa7-119">Fluent モーションのイージング</span><span class="sxs-lookup"><span data-stu-id="21aa7-119">Easing in Fluent motion</span></span>

<span data-ttu-id="21aa7-120">イージングは、移動時のオブジェクトの速度を操作する方法です。</span><span class="sxs-lookup"><span data-stu-id="21aa7-120">Easing is a way to manipulate the velocity of an object as it travels.</span></span> <span data-ttu-id="21aa7-121">Fluent モーションのすべてのエクスペリエンスを結び付ける接着剤です。</span><span class="sxs-lookup"><span data-stu-id="21aa7-121">It's the glue that ties together all the Fluent motion experiences.</span></span> <span data-ttu-id="21aa7-122">極端ですが、システムで使用されるイージングは、システム内で移動するオブジェクトの物理的な操作感を統合することができます。</span><span class="sxs-lookup"><span data-stu-id="21aa7-122">While extreme, the easing used in the system helps unify the physical feel of objects moving throughout the system.</span></span> <span data-ttu-id="21aa7-123">これは、現実世界を模倣し、移動中のオブジェクトがその環境に属しているように感じさせる 1 つの方法です。</span><span class="sxs-lookup"><span data-stu-id="21aa7-123">This is one way to mimic the real world, and make objects in motion feel like they belong in their environment.</span></span>

![ヒーロー イメージ](images/easing.gif)

## <a name="apply-easing-to-motion"></a><span data-ttu-id="21aa7-125">モーションへのイージングの適用</span><span class="sxs-lookup"><span data-stu-id="21aa7-125">Apply easing to motion</span></span>

<span data-ttu-id="21aa7-126">これらのイージングは、より自然な操作感を得るのに役立ち、Fluent モーションのために使用するベースラインとなります。</span><span class="sxs-lookup"><span data-stu-id="21aa7-126">These easings will help you achieve a more natural feel, and are the baseline we use for Fluent motion.</span></span>

<span data-ttu-id="21aa7-127">コード例では、推奨されるイージング値を Storyboard アニメーション (XAML) または Composition アニメーション (C#) に適用する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="21aa7-127">The code examples show how to apply recommended easing values to Storyboard animations (XAML) or Composition animations (C#).</span></span>

### <a name="accelerate-exit"></a><span data-ttu-id="21aa7-128">**高速化**(終了)</span><span class="sxs-lookup"><span data-stu-id="21aa7-128">**Accelerate** (Exit)</span></span>

:::row:::
    :::column:::
        Use for UI or objects that are exiting the scene.

        Objects become powered and gain momentum until they reach escape velocity.
        The resulting feel is that the object is trying its hardest to get out of the user's way and make room for new content to come in.
    :::column-end:::
    :::column:::
        ![accelerate easing](images/accelEase.gif)
    :::column-end:::
:::row-end:::

```
cubic-bezier(0.7 , 0 , 1 , 0.5)
```

```xaml
<!-- Use for XAML Storyboard animations. -->
<Storyboard x:Name="Storyboard">
    <DoubleAnimation Storyboard.TargetName="Translation" Storyboard.TargetProperty="X" From="0" To="200" Duration="0:0:0.15">
        <DoubleAnimation.EasingFunction>
            <ExponentialEase Exponent="4.5" EasingMode="EaseIn" />
        </DoubleAnimation.EasingFunction>
    </DoubleAnimation>
</Storyboard>
```

```csharp
// Use for Composition animations.
CubicBezierEasingFunction accelerate =
    _compositor.CreateCubicBezierEasingFunction(new Vector2(0.7f, 0.0f), new Vector2(1.0f, 0.5f));
_exitAnimation = _compositor.CreateScalarKeyFrameAnimation();
_exitAnimation.InsertKeyFrame(0.0f, _startValue);
_exitAnimation.InsertKeyFrame(1.0f, _endValue, accelerate);
_exitAnimation.Duration = TimeSpan.FromMilliseconds(150);
```

### <a name="decelerate-enter"></a><span data-ttu-id="21aa7-129">**減速**(入力)</span><span class="sxs-lookup"><span data-stu-id="21aa7-129">**Decelerate** (Enter)</span></span>

:::row:::
    :::column:::
        Use for objects or UI entering the scene, either navigating or spawning.

        Once on-scene, the object is met with extreme friction, which slows the object to rest.
        The resulting feel is that the object traveled from a long distance away and entered at an extreme velocity, or is quickly returning to a rest state.

        Even if it's preceded by a moment of unresponsiveness, the velocity of the incoming object has the effect of feeling fast and responsive.
    :::column-end:::
    :::column:::
        ![decelerate easing](images/decelEase.gif)
    :::column-end:::
:::row-end:::

```
cubic-bezier(0.1 , 0.9 , 0.2 , 1)
```

```xaml
<!-- Use for XAML Storyboard animations. -->
<Storyboard x:Name="Storyboard">
    <DoubleAnimation Storyboard.TargetName="Translation" Storyboard.TargetProperty="X" From="0" To="200" Duration="0:0:0.3">
        <DoubleAnimation.EasingFunction>
            <ExponentialEase Exponent="7" EasingMode="EaseOut" />
        </DoubleAnimation.EasingFunction>
    </DoubleAnimation>
</Storyboard>
```

```csharp
// Use for Composition animations.
CubicBezierEasingFunction decelerate =
    _compositor.CreateCubicBezierEasingFunction(new Vector2(0.1f, 0.9f), new Vector2(0.2f, 1.0f));
_enterAnimation = _compositor.CreateScalarKeyFrameAnimation();
_enterAnimation.InsertKeyFrame(0.0f, _startValue);
_enterAnimation.InsertKeyFrame(1.0f, _endValue, decelerate);
_enterAnimation.Duration = TimeSpan.FromMilliseconds(300);
```

### <a name="standard-easing-move"></a><span data-ttu-id="21aa7-130">**標準的なイージング**(移動)</span><span class="sxs-lookup"><span data-stu-id="21aa7-130">**Standard Easing** (Move)</span></span>

:::row:::
    :::column:::
        This is the baseline easing for any animated parameter change inside of the system.
        Use standard easing for objects that change from state to state on-screen, such as a simple position change. Also, use it for objects morphing in-scene, like an object that grows.

        The resulting feel is that objects changing state from A to B are overcoming, and taken over by, natural forces.
    :::column-end:::
    :::column:::
        ![standard easing](images/standardEase.gif)
    :::column-end:::
:::row-end:::

```
cubic-bezier(0.8 , 0 , 0.2 , 1)
```

```xaml
<!-- Use for XAML Storyboard animations. -->
<Storyboard x:Name="Storyboard">
    <DoubleAnimation Storyboard.TargetName="Translation" Storyboard.TargetProperty="X" From="0" To="200" Duration="0:0:0.5">
        <DoubleAnimation.EasingFunction>
            <CircleEase EasingMode="EaseInOut" />
        </DoubleAnimation.EasingFunction>
    </DoubleAnimation>
</Storyboard>
```

```csharp
// Use for Composition animations.
CubicBezierEasingFunction standard =
    _compositor.CreateCubicBezierEasingFunction(new Vector2(0.8f, 0.0f), new Vector2(0.2f, 1.0f));
 _moveAnimation = _compositor.CreateScalarKeyFrameAnimation();
 _moveAnimation.InsertKeyFrame(0.0f, _startValue);
 _moveAnimation.InsertKeyFrame(1.0f, _endValue, standard);
 _moveAnimation.Duration = TimeSpan.FromMilliseconds(500);
```

## <a name="related-articles"></a><span data-ttu-id="21aa7-131">関連記事</span><span class="sxs-lookup"><span data-stu-id="21aa7-131">Related articles</span></span>

- [<span data-ttu-id="21aa7-132">モーションの概要</span><span class="sxs-lookup"><span data-stu-id="21aa7-132">Motion overview</span></span>](index.md)
- [<span data-ttu-id="21aa7-133">方向性と重力</span><span class="sxs-lookup"><span data-stu-id="21aa7-133">Directionality and gravity</span></span>](directionality-and-gravity.md)