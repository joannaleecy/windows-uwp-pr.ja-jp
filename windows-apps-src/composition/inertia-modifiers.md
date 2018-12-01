---
title: 慣性修飾子を使用したスナップ位置の作成
description: InteractionTracker の InertiaModifier 機能を使用して、指定した位置にスナップされるモーション エクスペリエンスを作成する方法について説明します。
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: f99ebc4b98c87a4bc6d77fd2c626f481563e50c5
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8339361"
---
# <a name="create-snap-points-with-inertia-modifiers"></a><span data-ttu-id="e7899-104">慣性修飾子を使用したスナップ位置の作成</span><span class="sxs-lookup"><span data-stu-id="e7899-104">Create snap points with inertia modifiers</span></span>

<span data-ttu-id="e7899-105">この記事では、InteractionTracker の InertiaModifier 機能を使用して、指定した位置にスナップされるモーション エクスペリエンスを作成する方法について詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="e7899-105">In this article, we take a deeper dive into how to use an InteractionTracker’s InertiaModifier feature to create motion experiences that snap to a specified point.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="e7899-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="e7899-106">Prerequisites</span></span>

<span data-ttu-id="e7899-107">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="e7899-107">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="e7899-108">入力駆動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="e7899-108">Input-driven animations</span></span>](input-driven-animations.md)
- [<span data-ttu-id="e7899-109">InteractionTracker を使用したカスタム操作エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="e7899-109">Custom manipulation experiences with InteractionTracker</span></span>](interaction-tracker-manipulations.md)
- [<span data-ttu-id="e7899-110">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="e7899-110">Relation based animations</span></span>](relation-animations.md)

## <a name="what-are-snap-points-and-why-are-they-useful"></a><span data-ttu-id="e7899-111">スナップ位置の説明、およびスナップ位置が便利である理由</span><span class="sxs-lookup"><span data-stu-id="e7899-111">What are snap points and why are they useful?</span></span>

<span data-ttu-id="e7899-112">カスタム操作エクスペリエンスを作成するとき、スクロール可能またはズーム可能なキャンバスに特殊な_位置ポイント_を作成すると役立つ場合があります。InteractionTracker は常にその位置で動作を停止するようになります。</span><span class="sxs-lookup"><span data-stu-id="e7899-112">When building custom manipulation experiences, sometimes it is helpful to create specialized _position points_ within the scrollable/zoomable canvas that InteractionTracker will always come to rest at.</span></span> <span data-ttu-id="e7899-113">多くの場合、このような位置ポイントは_スナップ位置_と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="e7899-113">These are often called _snap points_.</span></span>

<span data-ttu-id="e7899-114">次の例では、さまざまな画像間をスクロールしたときに、見づらい位置に UI が配置されてしまう状況を確認してください。</span><span class="sxs-lookup"><span data-stu-id="e7899-114">Notice in the following example how the scrolling can leave the UI in an awkward position between the different images:</span></span>

![スナップ位置を使用しないスクロール](images/animation/snap-points-none.gif)

<span data-ttu-id="e7899-116">スナップ位置を追加すると、画像間のスクロールを停止したとき、画像が指定した位置に "スナップ" されます。</span><span class="sxs-lookup"><span data-stu-id="e7899-116">If you add snap points, when you stop scrolling between the images, they "snap" to a specified position.</span></span> <span data-ttu-id="e7899-117">スナップ位置を利用することで、画像をスクロールするときのエクスペリエンスがより見やすくなり、応答性も高くなります。</span><span class="sxs-lookup"><span data-stu-id="e7899-117">With snap points, it makes the experience of scrolling through images much cleaner and more responsive.</span></span>

![1 つのスナップ位置を使用したスクロール](images/animation/snap-points-single.gif)

## <a name="interactiontracker-and-inertiamodifiers"></a><span data-ttu-id="e7899-119">InteractionTracker と InertiaModifier</span><span class="sxs-lookup"><span data-stu-id="e7899-119">InteractionTracker and InertiaModifiers</span></span>

<span data-ttu-id="e7899-120">InteractionTracker を使用してカスタマイズした操作エクスペリエンスを作成するとき、InertiaModifier を利用することによって、スナップ位置のモーション エクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="e7899-120">When building customized manipulation experiences with InteractionTracker, you can create snap point motion experiences by utilizing InertiaModifiers.</span></span> <span data-ttu-id="e7899-121">基本的に、InertiaModifier は、慣性状態に移行したときに InteractionTracker が移動先に到達する際の場所や方法を定義するための手法です</span><span class="sxs-lookup"><span data-stu-id="e7899-121">InertiaModifiers are essentially a way for you to define where or how InteractionTracker reaches its destination when entering the Inertia state.</span></span> <span data-ttu-id="e7899-122">InertiaModifier を適用すると、X 位置や Y 位置、または InteractionTracker の Scale プロパティを制御することができます。</span><span class="sxs-lookup"><span data-stu-id="e7899-122">You can apply InertiaModifiers to impact the X or Y position or Scale properties of InteractionTracker.</span></span>

<span data-ttu-id="e7899-123">InertiaModifier には、次の 3 種類があります。</span><span class="sxs-lookup"><span data-stu-id="e7899-123">There are 3 types of InertiaModifiers:</span></span>

- <span data-ttu-id="e7899-124">InteractionTrackerInertiaRestingValue – 操作やプログラムに従った速度での動作が終了した後の、最終的な静止位置を定義する方法。</span><span class="sxs-lookup"><span data-stu-id="e7899-124">InteractionTrackerInertiaRestingValue – a way to modify the final resting position after an interaction or programmatic velocity.</span></span> <span data-ttu-id="e7899-125">定義済みのモーションでは、その位置まで InteractionTracker を移動します。</span><span class="sxs-lookup"><span data-stu-id="e7899-125">A predefined motion will take InteractionTracker to that position.</span></span>
- <span data-ttu-id="e7899-126">InteractionTrackerInertiaMotion – 操作やプログラムに従った速度での動作が終了した後で InteractionTracker が実行する特定のモーションを定義する方法。</span><span class="sxs-lookup"><span data-stu-id="e7899-126">InteractionTrackerInertiaMotion – a way to define a specific motion InteractionTracker will perform after an interaction or programmatic velocity.</span></span> <span data-ttu-id="e7899-127">最終的な位置はこのモーションから派生します。</span><span class="sxs-lookup"><span data-stu-id="e7899-127">The final position will be derived from this motion.</span></span>
- <span data-ttu-id="e7899-128">InteractionTrackerInertiaNaturalMotion – 操作やプログラムに従った速度での動作が終了した後の、最終的な静止位置を定義する方法ですが、物理学ベースのアニメーションが使用されます (NaturalMotionAnimation)。</span><span class="sxs-lookup"><span data-stu-id="e7899-128">InteractionTrackerInertiaNaturalMotion – a way to define the final resting position after an interaction or programmatic velocity but with a physics based animation (NaturalMotionAnimation).</span></span>

<span data-ttu-id="e7899-129">慣性状態に移行すると、InteractionTracker では、割り当てられている各 InertiaModifier を評価し、それらのいずれが適合するかを判別します。</span><span class="sxs-lookup"><span data-stu-id="e7899-129">When entering Inertia, InteractionTracker evaluates each of the InertiaModifiers assigned to it and determines if any of them apply.</span></span> <span data-ttu-id="e7899-130">つまり、1 つの InteractionTracker に対して複数の InertiaModifier を作成し割り当てることができます。ただし、各 InertiaModifier を定義するときは、次の手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="e7899-130">This means you can create and assign multiple InertiaModifiers to an InteractionTracker, But, when defining each, you need to do the following:</span></span>

1. <span data-ttu-id="e7899-131">条件の定義 – この特定の InertiaModifier を実行するタイミングを指定する条件付きステートメントを定義する式を使用します。</span><span class="sxs-lookup"><span data-stu-id="e7899-131">Define the Condition – an Expression that defines the conditional statement when this specific InertiaModifier should take place.</span></span> <span data-ttu-id="e7899-132">多くの場合、この式では、InteractionTracker の NaturalRestingPosition (既定の慣性が指定された移動先) を参照する必要がります。</span><span class="sxs-lookup"><span data-stu-id="e7899-132">This often requires looking at InteractionTracker’s NaturalRestingPosition (destination given default Inertia).</span></span>
1. <span data-ttu-id="e7899-133">RestingValue/Motion/NaturalMotion の定義 – 条件が満たされたときに実行される、実際の静止値の式、モーションの式、NaturalMotionAnimation を定義します。</span><span class="sxs-lookup"><span data-stu-id="e7899-133">Define the RestingValue/Motion/NaturalMotion – define the actual Resting Value Expression, Motion Expression or NaturalMotionAnimation that takes place when the condition is met.</span></span>

> [!NOTE]
> <span data-ttu-id="e7899-134">InteractionTracker が慣性状態に移行すると、InertiaModifier の条件部分のみが評価されます。</span><span class="sxs-lookup"><span data-stu-id="e7899-134">The condition aspect of the InertiaModifiers are only evaluated once when InteractionTracker enters Inertia.</span></span> <span data-ttu-id="e7899-135">ただし InertiaMotion の場合のみ、モーションの式は、条件が true となる修飾子のフレームごとに評価されます。</span><span class="sxs-lookup"><span data-stu-id="e7899-135">However, only for InertiaMotion, the motion Expression is evaluated every frame for the modifier whose condition is true.</span></span>

## <a name="example"></a><span data-ttu-id="e7899-136">例</span><span class="sxs-lookup"><span data-stu-id="e7899-136">Example</span></span>

<span data-ttu-id="e7899-137">次に、InertiaModifier を使用して、スナップ位置のエクスペリエンスをいくつか作成し、画像のスクロール キャンバスを再作成する方法を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="e7899-137">Now let’s look at how you can use InertiaModifiers to create some snap point experiences to recreate the scrolling canvas of images.</span></span> <span data-ttu-id="e7899-138">この例では、各操作を行うと 1 つの画像上を移動することが前提となっています。こうした動作は "Single Mandatory Snap Points" (シングル必須スナップ位置) と呼ばれることがあります。</span><span class="sxs-lookup"><span data-stu-id="e7899-138">In this example, each manipulation is meant to potentially move through a single image – this is often referred to as Single Mandatory Snap Points.</span></span>

<span data-ttu-id="e7899-139">まず、InteractionTracker、VisualInteractionSource、および InteractionTracker の位置を活用する式をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="e7899-139">Let’s start by setting up InteractionTracker, the VisualInteractionSource and the Expression that will leverage the position of InteractionTracker.</span></span>

```csharp
private void SetupInput()
{
    _tracker = InteractionTracker.Create(_compositor);
    _tracker.MinPosition = new Vector3(0f);
    _tracker.MaxPosition = new Vector3(3000f);

    _source = VisualInteractionSource.Create(_root);
    _source.ManipulationRedirectionMode =
        VisualInteractionSourceRedirectionMode.CapableTouchpadOnly;
    _source.PositionYSourceMode = InteractionSourceMode.EnabledWithInertia;
    _tracker.InteractionSources.Add(_source);

    var scrollExp = _compositor.CreateExpressionAnimation("-tracker.Position.Y");
    scrollExp.SetReferenceParameter("tracker", _tracker);
    ElementCompositionPreview.GetElementVisual(scrollPanel).StartAnimation("Offset.Y", scrollExp);
}
```

<span data-ttu-id="e7899-140">Single Mandatory Snap Point の動作によってコンテンツが上または下へ移動するため、次に、2 つの異なる慣性修飾子が必要になります。1 つはスクロール可能なコンテンツを上へ移動し、もう 1 つは下へ移動します。</span><span class="sxs-lookup"><span data-stu-id="e7899-140">Next, because a Single Mandatory Snap Point behavior either will move the content up or down, you will need two different inertia modifiers: one that moves the Scrollable content up, and one that moves it down.</span></span>

```csharp
// Snap-Point to move the content up
var snapUpModifier = InteractionTrackerInertiaRestingValue.Create(_compositor);
// Snap-Point to move the content down
var snapDownModifier = InteractionTrackerInertiaRestingValue.Create(_compositor);
```

<span data-ttu-id="e7899-141">スナップの方向が上であるか下であるかは、InteractionTracker がスナップの距離 (スナップ位置間の距離) の範囲内で自然に停止した相対的な位置に基づいて決定されます。</span><span class="sxs-lookup"><span data-stu-id="e7899-141">Whether to snap up or down is determined based on where InteractionTracker naturally would land within relative to the snap distance – the distance between the snap locations.</span></span> <span data-ttu-id="e7899-142">中間点を越えた場合は下方向のスナップ、それ以外の場合は上方向のスナップです </span><span class="sxs-lookup"><span data-stu-id="e7899-142">If past the halfway point, then snap down, otherwise snap up.</span></span> <span data-ttu-id="e7899-143">(この例では、スナップの距離は PropertySet に保存されます)。</span><span class="sxs-lookup"><span data-stu-id="e7899-143">(In this example, you store the snap distance in a PropertySet)</span></span>

```csharp
// Is NaturalRestingPosition less than the halfway point between Snap Points?
snapUpModifier.Condition = _compositor.CreateExpressionAnimation(
"this.Target.NaturalRestingPosition.y < (this.StartingValue – ” + “mod(this.StartingValue, prop.snapDistance) + prop.snapDistance / 2)");
snapUpModifier.Condition.SetReferenceParameter("prop", _propSet);
// Is NaturalRestingPosition greater than the halfway point between Snap Points?
snapDownModifier.Condition = _compositor.CreateExpressionAnimation(
"this.Target.NaturalRestingPosition.y >= (this.StartingValue – ” + “mod(this.StartingValue, prop.snapDistance) + prop.snapDistance / 2)");
snapDownModifier.Condition.SetReferenceParameter("prop", _propSet);
```

<span data-ttu-id="e7899-144">次の図は、実施されるロジックを説明したものです。</span><span class="sxs-lookup"><span data-stu-id="e7899-144">This diagram gives a visual description to the logic that is happening:</span></span>

![慣性修飾子の図](images/animation/inertia-modifier-diagram.png)

<span data-ttu-id="e7899-146">ここで、各 InertiaModifier の静止値を定義する必要があります。InteractionTracker の位置を前のスナップ位置に移動するか、次のスナップ位置に移動するかを指定します。</span><span class="sxs-lookup"><span data-stu-id="e7899-146">Now you just need to define the Resting Values for each InertiaModifier: either move the position of InteractionTracker to the previous snap position or the next one.</span></span>

```csharp
snapUpModifier.RestingValue = _compositor.CreateExpressionAnimation(
"this.StartingValue - mod(this.StartingValue, prop.snapDistance)");
snapUpModifier.RestingValue.SetReferenceParameter("prop", _propSet);
snapForwardModifier.RestingValue = _compositor.CreateExpressionAnimation(
"this.StartingValue + prop.snapDistance - mod(this.StartingValue, ” + “prop.snapDistance)");
snapForwardModifier.RestingValue.SetReferenceParameter("prop", _propSet);
```

<span data-ttu-id="e7899-147">最後に、InertiaModifier を InteractionTracker に追加します。</span><span class="sxs-lookup"><span data-stu-id="e7899-147">Finally, add the InertiaModifiers to InteractionTracker.</span></span> <span data-ttu-id="e7899-148">以上で、InteractionTracker が InertiaState に移行すると、InertiaModifier の条件が評価され、位置を変更する必要があるかどうかが判断されます。</span><span class="sxs-lookup"><span data-stu-id="e7899-148">Now when InteractionTracker enters it’s InertiaState, it will check the conditions of your InertiaModifiers to see if its position should be modified.</span></span>

```csharp
var modifiers = new InteractionTrackerInertiaRestingValue[] { 
snapUpModifier, snapDownModifier };
_tracker.ConfigurePositionYInertiaModifiers(modifiers);
```