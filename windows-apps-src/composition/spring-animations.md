---
title: ばねアニメーション
description: 自然な動作のばねアニメーションを使用する方法について説明します。
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10、UWP、アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 9e00aa383bcce17b7cd6b67514647c2f6137cc32
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8741353"
---
# <a name="spring-animations"></a><span data-ttu-id="71031-104">ばねアニメーション</span><span class="sxs-lookup"><span data-stu-id="71031-104">Spring animations</span></span>

<span data-ttu-id="71031-105">この記事では、ばねの NaturalMotionAnimations を使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="71031-105">The article shows how to use spring NaturalMotionAnimations.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="71031-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="71031-106">Prerequisites</span></span>

<span data-ttu-id="71031-107">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="71031-107">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="71031-108">自然な動作のアニメーション</span><span class="sxs-lookup"><span data-stu-id="71031-108">Natural motion animations</span></span>](natural-animations.md)

## <a name="why-springs"></a><span data-ttu-id="71031-109">ばねの動きを使用する理由</span><span class="sxs-lookup"><span data-stu-id="71031-109">Why springs?</span></span>

<span data-ttu-id="71031-110">ばねの動きは、生活の中で人々が経験したことがある一般的なモーション エクスペリエンスです。おもちゃのスリンキーから、ばねでつながれたブロックを使った物理の授業までさまざまなものがあります。</span><span class="sxs-lookup"><span data-stu-id="71031-110">Springs are a common motion experience we've all experienced at some point in our lives; ranging from slinky toys to Physics classroom experiences with a spring-tied block.</span></span> <span data-ttu-id="71031-111">ばねによる振動のモーションは、その動きを見ている人から楽しい感情や愉快な感情の反応を引き起こすことがあります。</span><span class="sxs-lookup"><span data-stu-id="71031-111">The oscillating motion of a spring often incites a playful and lighthearted emotional response from those who observe it.</span></span> <span data-ttu-id="71031-112">このため、ばねのモーションは、躍動感のあるモーション エクスペリエンスの作成を考えているユーザー向けのアプリケーション UI に利用することが適しています。このようなモーション エクスペリエンスは、従来の 3 次ベジエよりもエンド ユーザーに "強い印象" を与えます。</span><span class="sxs-lookup"><span data-stu-id="71031-112">As a result, the motion of a spring translates well into application UI for those who are looking to create a livelier motion experience that "pops" more to the end user than a traditional Cubic Bezier.</span></span> <span data-ttu-id="71031-113">このような場合、ばねのモーションは、躍動感のあるモーション エクスペリエンスを作成するだけでなく、アニメーション化された新しいコンテンツや現在のコンテンツに興味を惹き付ける際にも役立ちます。</span><span class="sxs-lookup"><span data-stu-id="71031-113">In these cases, spring motion not only creates a livelier motion experience, but also can help draw attention to new or currently animating content.</span></span> <span data-ttu-id="71031-114">アプリケーションのブランド化やモーションの言語によっては、振動をより目立たせ、はっきりと表現する場合がありますが、あまり目立たない表現が必要になることもあります。</span><span class="sxs-lookup"><span data-stu-id="71031-114">Depending on the application branding or motion language, the oscillation is more pronounced and visible, but in other cases it is more subtle.</span></span>

![<span data-ttu-id="71031-115">ばねアニメーションを使用したモーション](images/animation/offset-spring.gif)
![3 次ベジエを使用したモーション</span><span class="sxs-lookup"><span data-stu-id="71031-115">Motion with spring animation](images/animation/offset-spring.gif)
![Motion with Cubic Bezier animation</span></span>](images/animation/offset-cubic-bezier.gif)

## <a name="using-springs-in-your-ui"></a><span data-ttu-id="71031-116">UI でばねの動きを使用する</span><span class="sxs-lookup"><span data-stu-id="71031-116">Using springs in your UI</span></span>

<span data-ttu-id="71031-117">既に説明したように、ばねは便利なモーションです。アプリに統合することで、使いやすく楽しい UI エクスペリエンスを導入することができます。</span><span class="sxs-lookup"><span data-stu-id="71031-117">As mentioned previously, springs can be a useful motion to integrate into your app to introduce a very familiar and playful UI experience.</span></span> <span data-ttu-id="71031-118">UI でばねを使用する一般的な方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="71031-118">Common usage of springs in UI are:</span></span>

| <span data-ttu-id="71031-119">ばねの使用に関する説明</span><span class="sxs-lookup"><span data-stu-id="71031-119">Spring Usage Description</span></span> | <span data-ttu-id="71031-120">表示例</span><span class="sxs-lookup"><span data-stu-id="71031-120">Visual Example</span></span> |
| ------------------------ | -------------- |
| <span data-ttu-id="71031-121">モーション エクスペリエンスに "飛び出す" ような効果と躍動感を与える </span><span class="sxs-lookup"><span data-stu-id="71031-121">Making a motion experience "pop" and look livelier.</span></span> <span data-ttu-id="71031-122">(スケールのアニメーション化)</span><span class="sxs-lookup"><span data-stu-id="71031-122">(Animating Scale)</span></span> | ![ばねアニメーションを使用した拡大/縮小モーション](images/animation/scale-spring.gif) |
| <span data-ttu-id="71031-124">モーション エクスペリエンスで動きをさりげなく感じさせる (オフセットのアニメーション化)</span><span class="sxs-lookup"><span data-stu-id="71031-124">Making a motion experience subtly feel more energetic (Animating Offset)</span></span> | ![ばねアニメーションをオフセット モーション](images/animation/offset-spring.gif) |

<span data-ttu-id="71031-126">これらどちらの場合でも、ばねのモーションは、新しい値まで "ばねを伸ばし" その値を中心に振動すること、または現在の値を中心にして初期速度に基づいて振動することによってトリガーできます。</span><span class="sxs-lookup"><span data-stu-id="71031-126">In each of these cases, the spring motion can be triggered either by "springing to" and oscillating around a new value or oscillating around its current value with some initial velocity.</span></span>

![ばねアニメーションによる振動](images/animation/spring-animation-diagram.png)

## <a name="defining-your-spring-motion"></a><span data-ttu-id="71031-128">ばねのモーションを定義する</span><span class="sxs-lookup"><span data-stu-id="71031-128">Defining your spring motion</span></span>

<span data-ttu-id="71031-129">ばねのエクスペリエンスを作成するには、NaturalMotionAnimation API を使用します。</span><span class="sxs-lookup"><span data-stu-id="71031-129">You create a spring experience by using the NaturalMotionAnimation APIs.</span></span> <span data-ttu-id="71031-130">具体的には、コンポジターから Create\* メソッドを使用して、SpringNaturalMotionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="71031-130">Specifically, you create a SpringNaturalMotionAnimation by using the Create\* methods off the Compositor.</span></span> <span data-ttu-id="71031-131">その後で、モーションの以下のプロパティを定義することができます。</span><span class="sxs-lookup"><span data-stu-id="71031-131">You are then able to define the following properties of the motion:</span></span>

- <span data-ttu-id="71031-132">DampingRatio – アニメーションで使用されるばねのモーションに関する減衰のレベルを表します。</span><span class="sxs-lookup"><span data-stu-id="71031-132">DampingRatio – expresses the level of damping of the spring motion used in the animation.</span></span>

| <span data-ttu-id="71031-133">減衰比の値</span><span class="sxs-lookup"><span data-stu-id="71031-133">Damping Ratio Value</span></span> | <span data-ttu-id="71031-134">説明</span><span class="sxs-lookup"><span data-stu-id="71031-134">Description</span></span> |
| ------------------- | ----------- |
| <span data-ttu-id="71031-135">DampingRatio = 0</span><span class="sxs-lookup"><span data-stu-id="71031-135">DampingRatio = 0</span></span> | <span data-ttu-id="71031-136">非減衰 – ばねが長時間にわたって振動します。</span><span class="sxs-lookup"><span data-stu-id="71031-136">Undamped – the spring will oscillate for a long time</span></span> |
| <span data-ttu-id="71031-137">0 < DampingRatio < 1</span><span class="sxs-lookup"><span data-stu-id="71031-137">0 < DampingRatio < 1</span></span> | <span data-ttu-id="71031-138">不足減衰 – ばねの振動が小さいものから大きいものへと変化します。</span><span class="sxs-lookup"><span data-stu-id="71031-138">Underdamped – spring will oscillate from a little to a lot.</span></span> |
| <span data-ttu-id="71031-139">DampingRatio = 1</span><span class="sxs-lookup"><span data-stu-id="71031-139">DampingRatio = 1</span></span> | <span data-ttu-id="71031-140">臨界減衰 – ばねは振動を実行しません。</span><span class="sxs-lookup"><span data-stu-id="71031-140">Criticallydamped – the spring will perform no oscillation.</span></span> |
| <span data-ttu-id="71031-141">DampingRation > 1</span><span class="sxs-lookup"><span data-stu-id="71031-141">DampingRation > 1</span></span> | <span data-ttu-id="71031-142">過減衰 – ばねは急激に減速して、直ちにその移動先に到達します。振動はありません。</span><span class="sxs-lookup"><span data-stu-id="71031-142">Overdamped – the spring will quickly reach its destination with an abrupt deceleration and no oscillation</span></span> |

- <span data-ttu-id="71031-143">Period – ばねが単一の振動を実行する際にかかる時間です。</span><span class="sxs-lookup"><span data-stu-id="71031-143">Period – the time it takes the spring to perform a single oscillation.</span></span>
- <span data-ttu-id="71031-144">Final/Starting の値 – ばねのモーションの開始位置と終了位置を定義します (定義しない場合、開始または終了 (あるいはその両方) の値は現在の値になります)。</span><span class="sxs-lookup"><span data-stu-id="71031-144">Final / Starting Value – defined starting and ending positions of the spring motion (if not defined, starting value and/or final value will be current value).</span></span>
- <span data-ttu-id="71031-145">初期速度 – プログラムに従ったモーションの初期速度です。</span><span class="sxs-lookup"><span data-stu-id="71031-145">Initial Velocity – programmatic initial velocity for the motion.</span></span>

<span data-ttu-id="71031-146">KeyFrameAnimation と同じ、モーションの一連のプロパティを定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="71031-146">You can also define a set of properties of the motion that are the same as KeyFrameAnimations:</span></span>

- <span data-ttu-id="71031-147">DelayTime/DelayBehavior</span><span class="sxs-lookup"><span data-stu-id="71031-147">DelayTime / Delay Behavior</span></span>
- <span data-ttu-id="71031-148">StopBehavior</span><span class="sxs-lookup"><span data-stu-id="71031-148">StopBehavior</span></span>

<span data-ttu-id="71031-149">オフセットのアニメーション化、および拡大/縮小やサイズのアニメーション化を行う場合、Windows のデザイン チームでは、ばねの種類に応じて、DampingRatio や Period には一般的に以下の値を使用するよう推奨しています。</span><span class="sxs-lookup"><span data-stu-id="71031-149">In the common cases of animating Offset and Scale/Size, the following values are recommended by the Windows Design team for DampingRatio and Period for different types of springs:</span></span>

| <span data-ttu-id="71031-150">プロパティ</span><span class="sxs-lookup"><span data-stu-id="71031-150">Property</span></span> | <span data-ttu-id="71031-151">通常のばね</span><span class="sxs-lookup"><span data-stu-id="71031-151">Normal Spring</span></span> | <span data-ttu-id="71031-152">減衰するばね</span><span class="sxs-lookup"><span data-stu-id="71031-152">Dampened Spring</span></span> | <span data-ttu-id="71031-153">減衰が小さいばね</span><span class="sxs-lookup"><span data-stu-id="71031-153">Less-Dampened Spring</span></span> |
| -------- | ------------- | --------------- | -------------------- |
| <span data-ttu-id="71031-154">Offset</span><span class="sxs-lookup"><span data-stu-id="71031-154">Offset</span></span> | <span data-ttu-id="71031-155">DampingRatio = 0.8</span><span class="sxs-lookup"><span data-stu-id="71031-155">Damping Ratio = 0.8</span></span> <br/> <span data-ttu-id="71031-156">Period = 50 ms</span><span class="sxs-lookup"><span data-stu-id="71031-156">Period = 50 ms</span></span> | <span data-ttu-id="71031-157">DampingRatio = 0.85</span><span class="sxs-lookup"><span data-stu-id="71031-157">Damping Ratio = 0.85</span></span> <br/> <span data-ttu-id="71031-158">Period = 50 ms</span><span class="sxs-lookup"><span data-stu-id="71031-158">Period = 50 ms</span></span> | <span data-ttu-id="71031-159">DampingRatio = 0.65</span><span class="sxs-lookup"><span data-stu-id="71031-159">Damping Ratio = 0.65</span></span> <br/> <span data-ttu-id="71031-160">Period = 60 ms</span><span class="sxs-lookup"><span data-stu-id="71031-160">Period = 60 ms</span></span> |
| <span data-ttu-id="71031-161">Scale/Size</span><span class="sxs-lookup"><span data-stu-id="71031-161">Scale/Size</span></span> | <span data-ttu-id="71031-162">DampingRatio = 0.7</span><span class="sxs-lookup"><span data-stu-id="71031-162">Damping Ratio = 0.7</span></span> <br/> <span data-ttu-id="71031-163">Period = 50 ms</span><span class="sxs-lookup"><span data-stu-id="71031-163">Period = 50 ms</span></span> | <span data-ttu-id="71031-164">DampingRatio = 0.8</span><span class="sxs-lookup"><span data-stu-id="71031-164">Damping Ratio = 0.8</span></span> <br/> <span data-ttu-id="71031-165">Period = 50 ms</span><span class="sxs-lookup"><span data-stu-id="71031-165">Period = 50 ms</span></span> | <span data-ttu-id="71031-166">DampingRatio = 0.6</span><span class="sxs-lookup"><span data-stu-id="71031-166">Damping Ratio = 0.6</span></span> <br/> <span data-ttu-id="71031-167">Period = 60 ms</span><span class="sxs-lookup"><span data-stu-id="71031-167">Period = 60 ms</span></span> |

<span data-ttu-id="71031-168">プロパティを定義すると、ばねの NaturalMotionAnimation を CompositionObject の StartAnimation メソッド、または InteractionTracker の InertiaModifier が持つ Motion プロパティに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="71031-168">Once you have defined the properties, you can then pass in your spring NaturalMotionAnimation into the StartAnimation method of a CompositionObject or the Motion property of an InteractionTracker InertiaModifier.</span></span>

## <a name="example"></a><span data-ttu-id="71031-169">例</span><span class="sxs-lookup"><span data-stu-id="71031-169">Example</span></span>

<span data-ttu-id="71031-170">この例では、ナビゲーションとキャンバスの UI エクスペリエンスを作成します。このエクスペリエンスでは、ユーザーが展開ボタンをクリックすると、ナビゲーション ウィンドウが、ばねのような振動のモーションを使ってアニメーション化され表示されます。</span><span class="sxs-lookup"><span data-stu-id="71031-170">In this example, you create a navigation and canvas UI experience in which, when the user clicks an expand button, a navigation pane is animated out with a springy, oscillation motion.</span></span>

![クリックしたときのばねアニメーション](images/animation/spring-animation-on-click.gif)

<span data-ttu-id="71031-172">まず、ナビゲーション ウィンドウが表示されるタイミングに対応したクリック イベント内に、ばねアニメーションを定義します。</span><span class="sxs-lookup"><span data-stu-id="71031-172">Start by defining the spring animation within the clicked event for when the navigation pane appears.</span></span> <span data-ttu-id="71031-173">次に、FinalValue を定義する式を利用するための InitialValueExpression 機能を使って、アニメーションのプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="71031-173">You then define the properties of the animation, using the InitialValueExpression feature to use an Expression to define the FinalValue.</span></span> <span data-ttu-id="71031-174">また、ウィンドウが開かれているかどうかを追跡し、準備ができたら、アニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="71031-174">You also keep track of whether the pane is opened or not and, when ready, start the animation.</span></span>

```csharp
private void Button_Clicked(object sender, RoutedEventArgs e)
{
 _springAnimation = _compositor.CreateSpringScalarAnimation();
 _springAnimation.DampingRatio = 0.75f;
 _springAnimation.Period = TimeSpan.FromSeconds(0.5);

 if (!_expanded)
 {
 _expanded = true;
 _propSet.InsertBoolean("expanded", true);
 _springAnimation.InitialValueExpression[“FinalValue”] = “this.StartingValue + 250”;
 } else
 {
 _expanded = false;
 _propSet.InsertBoolean("expanded", false);
_springAnimation.InitialValueExpression[“FinalValue”] = “this.StartingValue - 250”;
 }
 _naviPane.StartAnimation("Offset.X", _springAnimation);
}
```

<span data-ttu-id="71031-175">では、このモーションを入力に関連付ける場合はどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="71031-175">Now what if you wanted to tie this motion to input?</span></span> <span data-ttu-id="71031-176">その場合、エンド ユーザーがスワイプしたときに、ウィンドウはばねのモーションで表示するのでしょうか?</span><span class="sxs-lookup"><span data-stu-id="71031-176">So if the end user swipes out, the panes come out with a Spring motion?</span></span> <span data-ttu-id="71031-177">さらに重要なのは、ユーザーが勢いよくまたはすばやくスワイプした場合、エンド ユーザーの速度に基づいてモーションが適合されるという点です。</span><span class="sxs-lookup"><span data-stu-id="71031-177">More importantly, if the user swipes harder or faster, the motion adapts based on the velocity from the end user.</span></span>

![スワイプしたときのばねアニメーション](images/animation/spring-animation-on-swipe.gif)

<span data-ttu-id="71031-179">これを行うには、上記と同じばねアニメーションを使用し、そのアニメーションを InteractionTracker を使って InertiaModifier に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="71031-179">To do this, you can take our same Spring Animation and pass it into an InertiaModifier with InteractionTracker.</span></span> <span data-ttu-id="71031-180">InputAnimations と InteractionTracker について詳しくは、「[InteractionTracker を使用したカスタム操作エクスペリエンス](interaction-tracker-manipulations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71031-180">For more information about InputAnimations and InteractionTracker, see [Custom manipulation experiences with InteractionTracker](interaction-tracker-manipulations.md).</span></span> <span data-ttu-id="71031-181">次のコード例では、InteractionTracker と VisualInteractionSource を既にセットアップしていることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="71031-181">We’ll assume for this code example, you have already setup your InteractionTracker and VisualInteractionSource.</span></span> <span data-ttu-id="71031-182">このばねの例では、NaturalMotionAnimation を受け入れる InertiaModifier の作成が重要となります。</span><span class="sxs-lookup"><span data-stu-id="71031-182">We’ll focus on creating the InertiaModifiers that will take in a NaturalMotionAnimation, in this case a spring.</span></span>

```csharp
// InteractionTracker and the VisualInteractionSource previously setup
// The open and close ScalarSpringAnimations defined earlier
private void SetupInput()
{
 // Define the InertiaModifier to manage the open motion
 var openMotionModifer = InteractionTrackerInertiaNaturalMotion.Create(compositor);

 // Condition defines to use open animation if panes in non-expanded view
 // Property set value to track if open or closed is managed in other part of code
 openMotionModifer.Condition = _compositor.CreateExpressionAnimation(
"propset.expanded == false");
 openMotionModifer.Condition.SetReferenceParameter("propSet", _propSet);
 openMotionModifer.NaturalMotion = _openSpringAnimation;

 // Define the InertiaModifer to manage the close motion
 var closeMotionModifier = InteractionTrackerInertiaNaturalMotion.Create(_compositor);

 // Condition defines to use close animation if panes in expanded view
 // Property set value to track if open or closed is managed in other part of code
 closeMotionModifier.Condition = 
_compositor.CreateExpressionAnimation("propSet.expanded == true");
 closeMotionModifier.Condition.SetReferenceParameter("propSet", _propSet);
 closeMotionModifier.NaturalMotion = _closeSpringAnimation;

 _tracker.ConfigurePositionXInertiaModifiers(new 
InteractionTrackerInertiaNaturalMotion[] { openMotionModifer, closeMotionModifier});

 // Take output of InteractionTracker and assign to the pane
 var exp = _compositor.CreateExpressionAnimation("-tracker.Position.X");
 exp.SetReferenceParameter("tracker", _tracker);
 ElementCompositionPreview.GetElementVisual(pageNavigation).
StartAnimation("Translation.X", exp);
}
```

<span data-ttu-id="71031-183">これで、プログラムに基づくばねアニメーションと入力駆動型のばねアニメーションの両方を UI で使用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="71031-183">Now you have both a programmatic and input-driven spring animation in your UI!</span></span>

<span data-ttu-id="71031-184">以上をまとめると、ばねアニメーションをアプリで使用する手順は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="71031-184">In summary, the steps to using a spring animation in your app:</span></span>

1. <span data-ttu-id="71031-185">コンポジターから SpringAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="71031-185">Create your SpringAnimation off your Compositor.</span></span>
1. <span data-ttu-id="71031-186">既定値以外が必要な場合は、SpringAnimation のプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="71031-186">Define properties of the SpringAnimation if you wanted non-default values:</span></span>
    - <span data-ttu-id="71031-187">DampingRatio</span><span class="sxs-lookup"><span data-stu-id="71031-187">DampingRatio</span></span>
    - <span data-ttu-id="71031-188">Period</span><span class="sxs-lookup"><span data-stu-id="71031-188">Period</span></span>
    - <span data-ttu-id="71031-189">Final の値</span><span class="sxs-lookup"><span data-stu-id="71031-189">Final Value</span></span>
    - <span data-ttu-id="71031-190">Initial の値</span><span class="sxs-lookup"><span data-stu-id="71031-190">Initial Value</span></span>
    - <span data-ttu-id="71031-191">初期速度</span><span class="sxs-lookup"><span data-stu-id="71031-191">Initial Velocity</span></span>
1. <span data-ttu-id="71031-192">ターゲットに割り当てます。</span><span class="sxs-lookup"><span data-stu-id="71031-192">Assign to target.</span></span>
    - <span data-ttu-id="71031-193">CompositionObject プロパティをアニメーション化する場合は、SpringAnimation をパラメーターとして StartAnimation に渡します。</span><span class="sxs-lookup"><span data-stu-id="71031-193">If you're animating a CompositionObject property, pass in SpringAnimation as parameter to StartAnimation.</span></span>
    - <span data-ttu-id="71031-194">アニメーションを入力で使用する場合は、InertiaModifier の NaturalMotion プロパティを SpringAnimation に設定します。</span><span class="sxs-lookup"><span data-stu-id="71031-194">If you want to use with input, set NaturalMotion property of an InertiaModifier to SpringAnimation.</span></span>

