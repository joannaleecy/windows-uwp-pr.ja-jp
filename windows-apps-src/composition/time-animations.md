---
author: jwmsft
title: "時間ベース アニメーション"
description: "KeyFrameAnimation クラスを使用すると、時間の経過と共に UI を変更できます。"
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, アニメーション"
localizationpriority: medium
ms.openlocfilehash: f080e0c4409cb4f0199840e0382e54b988f1bbb1
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
# <a name="time-based-animations"></a><span data-ttu-id="9ad9b-104">時間ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="9ad9b-104">Time based animations</span></span>

<span data-ttu-id="9ad9b-105">コンポーネントが使用中である場合や、ユーザー エクスペリエンス全体が変更される場合、こうした状況はエンド ユーザーに対して 2 つの方法で提示されることがあります。1 つは時間の経過と共に提示する方法、もう一つは即座に提示する方法です。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-105">When a component in, or an entire user experience changes, end users often observe it in two ways: over time or instantaneously.</span></span> <span data-ttu-id="9ad9b-106">Windows プラットフォームでは、前者の方法が後者の方法よりも優先されます。ユーザー エクスペリエンスが即座に変更された場合、エンド ユーザーは混乱し、予期しない動作であると感じてしまう可能性があります。これは、こうした変更にユーザーが対処できないためです。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-106">On the Windows platform, the former is preferred over the latter -  user experiences that instantly change often confuse and surprise end users because they are not able to follow what happened.</span></span> <span data-ttu-id="9ad9b-107">このような場合、エンド ユーザーはエクスペリエンスを不快でありと不自然なものとして認識します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-107">The end user then perceives the experience as jarring and unnatural.</span></span>

<span data-ttu-id="9ad9b-108">ユーザー エクスペリエンスを即座に変更するのではなく、時間の経過と共に UI を変更してエンド ユーザーをガイドしたり、エクスペリエンスの変更をエンド ユーザーに通知したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-108">Instead, you can change your UI over time to guide the end user through, or notify them of changes to the experience.</span></span> <span data-ttu-id="9ad9b-109">Windows プラットフォームでは、これを時間ベース アニメーション (KeyFrameAnimation とも呼ばれます) を使用して行います。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-109">On the Windows platform, this is done by using time-based animations, also known as KeyFrameAnimations.</span></span> <span data-ttu-id="9ad9b-110">KeyFrameAnimation を使用すると、時間の経過と共に UI を変更し、アニメーションの各側面 (アニメーションの開始方法や開始のタイミング、アニメーションがどのようにして終了状態になるかなど) を制御することができます。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-110">KeyFrameAnimations let you change a UI over time and control each aspect of the animation, including how and when it starts, and how it reaches its end state.</span></span> <span data-ttu-id="9ad9b-111">たとえば、オブジェクトが新しい位置に 300 ミリ秒かけて移動するアニメーションは、即座にその位置に "テレポート" する方法よりも快適なエクスペリエンスとなります。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-111">For example, animating an object to a new position over 300 milliseconds is more pleasant than instantly "teleporting" it there.</span></span> <span data-ttu-id="9ad9b-112">即座に変更するのではなく、アニメーションを使用すると、最終的にはより快適で魅力的なエクスペリエンスが実現されます。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-112">When using animations instead of instantaneous changes, the net result is a more pleasant and appealing experience.</span></span>

## <a name="types-of-time-based-animations"></a><span data-ttu-id="9ad9b-113">時間ベース アニメーションの種類</span><span class="sxs-lookup"><span data-stu-id="9ad9b-113">Types of time based Animations</span></span>

<span data-ttu-id="9ad9b-114">Windows で優れたユーザー エクスペリエンスを作成する際に使用できる時間ベース アニメーションには、2 つのカテゴリがあります。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-114">There are two categories of time-based animations you can use to build beautiful user experiences on Windows:</span></span>

<span data-ttu-id="9ad9b-115">**明示的なアニメーション** – その名前が示すように、アニメーションを明示的に開始して更新を実行します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-115">**Explicit Animations** – as the name signifies, you explicitly start the animation to make updates.</span></span>
<span data-ttu-id="9ad9b-116">**暗黙的なアニメーション** – これらのアニメーションは、条件が満たされたときにシステムが自動的に開始します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-116">**Implicit Animations** – these animations are kicked off by the system on your behalf when a condition is met.</span></span>

<span data-ttu-id="9ad9b-117">この記事では、KeyFrameAnimation を使って_明示的な_時間ベース アニメーションを作成し使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-117">For this article, we will discuss how to create and use _explicit_ time-based animations with KeyFrameAnimations.</span></span>

<span data-ttu-id="9ad9b-118">明示的な時間ベース アニメーションおよび暗黙的な時間ベース アニメーションのどちらについても、アニメーション化できる CompositionObject のさまざまなプロパティに対応した多様な種類のアニメーションがあります。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-118">For both explicit and implicit time based animations, there are different types, corresponding to the different types of properties of CompositionObjects you can animate.</span></span>

- <span data-ttu-id="9ad9b-119">ColorKeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="9ad9b-119">ColorKeyFrameAnimation</span></span>
- <span data-ttu-id="9ad9b-120">QuaternionKeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="9ad9b-120">QuaternionKeyFrameAnimation</span></span>
- <span data-ttu-id="9ad9b-121">ScalarKeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="9ad9b-121">ScalarKeyFrameAnimation</span></span>
- <span data-ttu-id="9ad9b-122">Vector2KeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="9ad9b-122">Vector2KeyFrameAnimation</span></span>
- <span data-ttu-id="9ad9b-123">Vector3KeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="9ad9b-123">Vector3KeyFrameAnimation</span></span>
- <span data-ttu-id="9ad9b-124">Vector4KeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="9ad9b-124">Vector4KeyFrameAnimation</span></span>

## <a name="create-time-based-animations-with-keyframeanimations"></a><span data-ttu-id="9ad9b-125">KeyFrameAnimation を使用して時間ベース アニメーションを作成する</span><span class="sxs-lookup"><span data-stu-id="9ad9b-125">Create time based animations with KeyFrameAnimations</span></span>

<span data-ttu-id="9ad9b-126">KeyFrameAnimation を使用した明示的な時間ベース アニメーションの作成方法を説明する前に、概念についていくつか説明します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-126">Before describing how to create explicit time-based animations with KeyFrameAnimations, let’s go over a few concepts.</span></span>

- <span data-ttu-id="9ad9b-127">KeyFrame – KeyFrame とは、アニメーション化によってアニメーションが動作するための独立した "スナップショット" です。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-127">KeyFrames – These are the individual "snapshots" that an animation will animate through.</span></span>
  - <span data-ttu-id="9ad9b-128">キーと値のペアとして定義されます。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-128">Defined as key & value pairs.</span></span> <span data-ttu-id="9ad9b-129">キーは 0 ~ 1 の値で進行状況を表します。つまり、この "スナップショット" が実行されるアニメーションの有効期間を表します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-129">The key represents the progress between 0 and 1, aka where in the animation lifetime this “snapshot” takes places.</span></span> <span data-ttu-id="9ad9b-130">他のパラメーターは、現時点におけるプロパティ値を表します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-130">The other parameter represents the property value at this time.</span></span>
- <span data-ttu-id="9ad9b-131">KeyFrameAnimation プロパティ – UI の要件を満たすために適用できるカスタマイズ オプションです。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-131">KeyFrameAnimation Properties – customization options you can apply to meet the needs of the UI.</span></span>
  - <span data-ttu-id="9ad9b-132">DelayTime – StartAnimation が呼び出されてからアニメーションが開始されるまでの時間。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-132">DelayTime – time before an animation starts after StartAnimation is called.</span></span>
  - <span data-ttu-id="9ad9b-133">Duration: アニメーションの継続時間。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-133">Duration – duration of the animation.</span></span>
  - <span data-ttu-id="9ad9b-134">IterationBehavior – アニメーションの繰り返し動作の回数または無制限。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-134">IterationBehavior – count or infinite repeat behavior for an animation.</span></span>
  - <span data-ttu-id="9ad9b-135">IterationCount – キー フレーム アニメーションが繰り返される有限の回数。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-135">IterationCount – number of finite times a KeyFrame Animation will repeat.</span></span>
  - <span data-ttu-id="9ad9b-136">KeyFrame Count – 特定のキー フレーム アニメーションのキー フレームの数。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-136">KeyFrame Count – read of how many KeyFrames in a particular KeyFrame Animation.</span></span>
  - <span data-ttu-id="9ad9b-137">StopBehavior – StopAnimation が呼び出されたときのアニメーションのプロパティ値の動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-137">StopBehavior – specifies the behavior of an animating property value when StopAnimation is called.</span></span>
  - <span data-ttu-id="9ad9b-138">Direction – アニメーションの再生方向を指定します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-138">Direction – specifies the direction of the animation for playback.</span></span>
- <span data-ttu-id="9ad9b-139">アニメーション グループ – 同時に複数のアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-139">Animation Group – starting multiple animations at the same time.</span></span>
  - <span data-ttu-id="9ad9b-140">多くの場合、複数のプロパティを同時にアニメーション化するときに使用します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-140">Often used when wanting to animate multiple properties at the same time.</span></span>

<span data-ttu-id="9ad9b-141">詳しくは、「[CompositionAnimationGroup](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanimationgroup)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-141">For more info, see [CompositionAnimationGroup](https://docs.microsoft.com/uwp/api/windows.ui.composition.compositionanimationgroup).</span></span>

<span data-ttu-id="9ad9b-142">以上の概念を踏まえて、KeyFrameAnimation を構築するための一般的な式を説明します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-142">With these concepts in mind, let’s talk through the general formula for constructing a KeyFrameAnimation:</span></span>

1. <span data-ttu-id="9ad9b-143">CompositionObject とアニメーション化する必要がある各プロパティを特定します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-143">Identify the CompositionObject and its respective property that you need to animate.</span></span>
1. <span data-ttu-id="9ad9b-144">アニメーション化するプロパティの型と一致するコンポジターの KeyFrameAnimation タイプ テンプレートを作成します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-144">Create a KeyFrameAnimation Type template of the compositor that matches the type of property you want to animate.</span></span>
1. <span data-ttu-id="9ad9b-145">アニメーション テンプレートを使用して、KeyFrame の追加とアニメーションのプロパティの定義を開始します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-145">Using the animation template, start adding KeyFrames and defining properties of the animation.</span></span>
    - <span data-ttu-id="9ad9b-146">1 つ以上の KeyFrame が必要です (100% または 1f KeyFrame)。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-146">At least one KeyFrame is required (the 100% or 1f keyframe).</span></span>
    - <span data-ttu-id="9ad9b-147">また、継続時間を定義することもお勧めします。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-147">It is recommended to define a duration as well.</span></span>
1. <span data-ttu-id="9ad9b-148">このアニメーションを実行する準備ができたら、アニメーション化するプロパティをターゲットとして、CompositionObject で StartAnimation(…) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-148">Once you are ready to run this animation then call StartAnimation(…) on the CompositionObject, targeting the property which you want to animate.</span></span> <span data-ttu-id="9ad9b-149">具体的には、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-149">Specifically:</span></span>
    - `Visual.StartAnimation("targetProperty", CompositionAnimation animation);`
    - `Visual.StartAnimationGroup(AnimationGroup animationGroup);`
1. <span data-ttu-id="9ad9b-150">実行中のアニメーションがあり、アニメーションまたはアニメーション グループを停止する場合は、以下の API を使用できます。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-150">If you have a running animation and you will like to stop the Animation or Animation Group you can use these APIs:</span></span>
    - `Visual.StopAnimation("targetProperty");`
    - `Visual.StopAnimationGroup(AnimationGroup AnimationGroup);`

<span data-ttu-id="9ad9b-151">式の実際の動作例を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-151">Let’s take a look an example to see this formula in action.</span></span>

## <a name="example"></a><span data-ttu-id="9ad9b-152">例</span><span class="sxs-lookup"><span data-stu-id="9ad9b-152">Example</span></span>

<span data-ttu-id="9ad9b-153">この例では、<0,0,0> ～ <20,20,20> のビジュアルのオフセットを 1 秒間アニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-153">In this example, you want to animate the offset of a visual from <0,0,0> to <20,20,20> over 1 seconds.</span></span> <span data-ttu-id="9ad9b-154">また、ビジュアルがこれらの位置の間を 10 回アニメーション化されるようにします。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-154">In addition, you want to see the visual animate between these positions 10 times.</span></span>

![キーフレーム アニメーション](images/animation/animated-rectangle.gif)

<span data-ttu-id="9ad9b-156">最初に、CompositionObject とアニメーション化するプロパティを特定します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-156">You first start by identifying the CompositionObject and property you want to animate.</span></span> <span data-ttu-id="9ad9b-157">この場合、赤色の正方形は、`redSquare` という Composition の Visual で表されています。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-157">In this case, the red square is represented by a Composition Visual named `redSquare`.</span></span> <span data-ttu-id="9ad9b-158">このオブジェクトからアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-158">You start your animation from this object.</span></span>

<span data-ttu-id="9ad9b-159">次に、Offset プロパティをアニメーション化するため、Vector3KeyFrameAnimation を作成する必要があります (Offset の種類は Vector3)。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-159">Next, because you want to animate the Offset property, you need to create a Vector3KeyFrameAnimation (Offset is of type Vector3).</span></span> <span data-ttu-id="9ad9b-160">また、対応する KeyFrameAnimation の KeyFrame も定義します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-160">You also define the corresponding KeyFrames for the KeyFrameAnimation.</span></span>

```csharp
    Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
    animation.InsertKeyFrame(1f, new Vector3(200f, 0f, 0f));
```

<span data-ttu-id="9ad9b-161">その後で、KeyFrameAnimation のプロパティを定義して、2 つの位置 (現在の位置と <200,0,0>) の間で 10 回アニメーション化される動作と共に継続時間を記述します。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-161">Then we will define the properties of the KeyFrameAnimation to describe it’s duration along with the behavior to animate between the two positions (current and <200,0,0>) 10 times.</span></span>

```csharp
    animation.Duration = TimeSpan.FromSeconds(2);
    animation.Direction = Windows.UI.Composition.AnimationDirection.Alternate;
    // Run animation for 10 times
    animation.IterationCount = 10;
```

<span data-ttu-id="9ad9b-162">最後に、アニメーションを実行するために、CompositionObject のプロパティでアニメーションを開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-162">Finally, in order to run an animation, you need to start it on a property of a CompositionObject.</span></span>

```csharp
redVisual.StartAnimation("Translation", animation);
```

<span data-ttu-id="9ad9b-163">完全なコードは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="9ad9b-163">Here's the full code.</span></span>

```csharp
private void AnimateSquare(Compositor compositor, SpriteVisual redSquare)
{ 
    Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
    animation.InsertKeyFrame(1f, new Vector3(200f, 0f, 0f));
    animation.Duration = TimeSpan.FromSeconds(2);
    animation.Direction = Windows.UI.Composition.AnimationDirection.Alternate;
    // Run animation for 10 times
    animation.IterationCount = 10;
    visual.StartAnimation("Translation", animation);
} 
```