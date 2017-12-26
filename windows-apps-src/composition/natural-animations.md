---
author: jwmsft
title: "自然な動作のアニメーション"
description: 
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, アニメーション"
localizationpriority: medium
ms.openlocfilehash: 5e941d1115542130a3c1e0974de51210987feb49
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
# <a name="natural-motion-animations"></a><span data-ttu-id="58e0f-103">自然な動作のアニメーション</span><span class="sxs-lookup"><span data-stu-id="58e0f-103">Natural motion animations</span></span>

<span data-ttu-id="58e0f-104">この記事では、NaturalMotionAnimation 領域の概要ついて説明します。また、こうした種類のアニメーションを UI で使用する場合、概念的にどのように考えたらよいかについても説明します。</span><span class="sxs-lookup"><span data-stu-id="58e0f-104">This article provides a brief overview of the NaturalMotionAnimation space and how to conceptually think about using these types of animations in your UI.</span></span>

## <a name="making-motion-feel-familiar-and-natural"></a><span data-ttu-id="58e0f-105">見慣れた自然なモーションの作成</span><span class="sxs-lookup"><span data-stu-id="58e0f-105">Making motion feel familiar and natural</span></span>

<span data-ttu-id="58e0f-106">優れたアプリとは、ユーザーの興味を引き付けて離さないような操作感を実現し、作業の際にユーザーをガイドできるアプリです。</span><span class="sxs-lookup"><span data-stu-id="58e0f-106">Great apps are ones that create experiences that capture and retain user attention, and help guide users through tasks.</span></span> <span data-ttu-id="58e0f-107">モーションは、ユーザー インターフェイスをユーザー エクスペリエンスと区別する重要な差別化要因です。モーションによって、ユーザーとユーザーが操作するアプリケーションとの関係が導き出されます。</span><span class="sxs-lookup"><span data-stu-id="58e0f-107">Motion is the key differentiating factor that separates a User Interface from a User Experience – eliciting a connection between users and the application they are interacting with.</span></span> <span data-ttu-id="58e0f-108">この関係が適切であれば、エンド ユーザーのエンゲージメントと満足度を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="58e0f-108">The better the connection, the higher engagement and satisfaction from end users.</span></span>

<span data-ttu-id="58e0f-109">モーションを利用してこの関係を構築するための 1 つの方法として、ユーザーにとって親しみやすい外観を提供するエクスペリエンスの作成があります。</span><span class="sxs-lookup"><span data-stu-id="58e0f-109">One way motion can help build this connection is by creating experiences that look and feel familiar to users.</span></span> <span data-ttu-id="58e0f-110">ユーザーは、モーションが実生活での経験にどの程度基づいているかということを無意識に想定しています。</span><span class="sxs-lookup"><span data-stu-id="58e0f-110">Users have an unconscious expectation for how they perceive motion that is based on real life experiences.</span></span> <span data-ttu-id="58e0f-111">物体が床を横切って移動する動作、テーブルから落ちる動作、物体同士が跳ね返る動作、ばねによる振動などは、多くの人が理解し、想定できる動作です。</span><span class="sxs-lookup"><span data-stu-id="58e0f-111">We see how objects slide across the floor, fall off the table, bounce into one another and oscillate with a spring.</span></span> <span data-ttu-id="58e0f-112">実際の物理法則に基づいて、こうした動作の想定を活用するモーションは、目で見たときに自然な感じがします。</span><span class="sxs-lookup"><span data-stu-id="58e0f-112">Motion that leverages this expectation by being based on real-world physics looks and feels more natural in our eyes.</span></span> <span data-ttu-id="58e0f-113">モーションはより自然で対話的になりますが、さらに重要なことは、エクスペリエンス全体が覚えやすく、魅力的になるということです。</span><span class="sxs-lookup"><span data-stu-id="58e0f-113">The motion becomes more natural and interactive, but more importantly, the entire experience becomes more memorable and delightful.</span></span>

![<span data-ttu-id="58e0f-114">アニメーションを使用しない拡大/縮小モーション](images/animation/scale-no-animation.gif)
![3 次ベジエを使用した拡大/縮小モーション](images/animation/scale-cubic-bezier.gif)
![ばねアニメーションを使用した拡大/縮小モーション</span><span class="sxs-lookup"><span data-stu-id="58e0f-114">Scale motion without animation](images/animation/scale-no-animation.gif)
![Scale motion with cubic bezier](images/animation/scale-cubic-bezier.gif)
![Scale motion with spring animation</span></span>](images/animation/scale-spring.gif)

<span data-ttu-id="58e0f-115">最終的には、アプリに対するユーザー エンゲージメントとユーザーの維持率が高まります。</span><span class="sxs-lookup"><span data-stu-id="58e0f-115">The net result is higher user engagement and retention with the app.</span></span>

## <a name="balancing-control-and-dynamism"></a><span data-ttu-id="58e0f-116">制御とダイナミズムのバランス</span><span class="sxs-lookup"><span data-stu-id="58e0f-116">Balancing Control and Dynamism</span></span>

<span data-ttu-id="58e0f-117">従来の UI では、[KeyFrameAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.keyframeanimation) がモーションを記述するための主要な方法となっています。</span><span class="sxs-lookup"><span data-stu-id="58e0f-117">In traditional UI, [KeyFrameAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.keyframeanimation)s are the predominant way to describe motion.</span></span> <span data-ttu-id="58e0f-118">KeyFrame を使用すると、設計者や開発者は、開始、終了、補間の定義を完全に制御することができます。</span><span class="sxs-lookup"><span data-stu-id="58e0f-118">KeyFrames provided the utmost control to designers and developers to define the start, end, and interpolation.</span></span> <span data-ttu-id="58e0f-119">多くの場合、KeyFrame は非常に便利な方法ですが、KeyFrame アニメーションは動的な表現が弱いアニメーションです。また、モーションはアダプティブではなく、どのような状況でも同じように見えてしまいます。</span><span class="sxs-lookup"><span data-stu-id="58e0f-119">Although this is very useful in many cases, KeyFrame Animations are not very dynamic; the motion is not adaptive and looks the same under any condition.</span></span>

<span data-ttu-id="58e0f-120">これとは対照的に、ゲームや物理エンジンでよく見られるシミュレーションがあります。</span><span class="sxs-lookup"><span data-stu-id="58e0f-120">On the other end of the spectrum, there are simulations often seen in gaming and physics engines.</span></span> <span data-ttu-id="58e0f-121">多くの場合、これらのエクスペリエンスでは、ユーザーが操作するときに非常にリアルで動きのある表現が実現されます。ユーザーが現実世界で感じる雰囲気や偶然性の感覚が作り出されるのです。</span><span class="sxs-lookup"><span data-stu-id="58e0f-121">These experiences often are the most life-like and dynamic that users interact with – creating that sense of ambiance and randomness that users see every day.</span></span> <span data-ttu-id="58e0f-122">モーションはよりアクティブで動的なものとなりますが、設計者や開発者は制御できる要素が少なくなり、従来の UI に統合するのが難しくなります。</span><span class="sxs-lookup"><span data-stu-id="58e0f-122">Although this makes motion feel more alive and dynamic, designers and developers have less control, therefore making it more difficult to integrate into traditional UI.</span></span>

![制御の程度を示す図](images/animation/natural-motion-diagram.png)

<span data-ttu-id="58e0f-124">[NaturalMotionAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.naturalmotionanimation) は、このギャップを橋渡しすることができます。アニメーションの重要な要素 (開始/終了など) に対する制御のバランスを取りながら、自然で動的な表現を実現するモーションを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="58e0f-124">[NaturalMotionAnimation](https://docs.microsoft.com/uwp/api/windows.ui.composition.naturalmotionanimation)s exist to help bridge this divide – enabling a balance of control for the important elements of an animation like start/finish, but maintaining motion that looks and feels natural and dynamic.</span></span>

> [!NOTE]
> <span data-ttu-id="58e0f-125">NaturalMotionAnimations は KeyFrame アニメーションに置き換わるものではありません。Fluent Design 言語では、KeyFrame が推奨される状況がまだあります。</span><span class="sxs-lookup"><span data-stu-id="58e0f-125">NaturalMotionAnimations are not meant as a replacement for KeyFrame Animations – there are still places in the Fluent design language where KeyFrames are recommended.</span></span> <span data-ttu-id="58e0f-126">NaturalMotionAnimations は、モーションは必要であるが、KeyFrame アニメーションでは動的な表現をするのに十分ではない場合に使用されることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="58e0f-126">NaturalMotionAnimations are meant to be used in places where motion is required but KeyFrame Animations are not dynamic enough.</span></span>

## <a name="using-naturalmotionanimations"></a><span data-ttu-id="58e0f-127">NaturalMotionAnimations の使用</span><span class="sxs-lookup"><span data-stu-id="58e0f-127">Using NaturalMotionAnimations</span></span>

<span data-ttu-id="58e0f-128">Fall Creators Update 以降、新しいモーション エクスペリエンスである "**ばねアニメーション**" にアクセスできます。</span><span class="sxs-lookup"><span data-stu-id="58e0f-128">Starting with the Fall Creator's Update, you have access to a new motion experience: **spring animations**.</span></span> <span data-ttu-id="58e0f-129">ばねのモーションに関する詳しいチュートリアルについては、「[ばねアニメーション](spring-animations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="58e0f-129">See [Spring animations](spring-animations.md) for a more in depth walkthrough of springs.</span></span>

<span data-ttu-id="58e0f-130">このモーションの種類は、新しい NaturalMotionAnimation を使用して実行できます。 NaturalMotionAnimation は新しい種類のアニメーションで、制御とダイナミズムのバランスを取りながら、開発者が見慣れた自然なモーションを UI に組み込むことができるようにすることを重視しています。</span><span class="sxs-lookup"><span data-stu-id="58e0f-130">This motion type is achieved by using the new NaturalMotionAnimation – a new animation type centered on enabling developers to build more familiar and natural feeling motion into their UI, with a balance of control and dynamism.</span></span> <span data-ttu-id="58e0f-131">次のような機能を備えています。</span><span class="sxs-lookup"><span data-stu-id="58e0f-131">They expose the following capabilities:</span></span>

- <span data-ttu-id="58e0f-132">開始と終了の値を定義する。</span><span class="sxs-lookup"><span data-stu-id="58e0f-132">Define the start and end values.</span></span>
- <span data-ttu-id="58e0f-133">InitialVelocity を定義し、InteractionTracker を使用して入力に関連付ける。</span><span class="sxs-lookup"><span data-stu-id="58e0f-133">Define InitialVelocity and tie to input with InteractionTracker.</span></span>
- <span data-ttu-id="58e0f-134">モーション固有のプロパティ (ばね用の DampingRatio など) を定義する。</span><span class="sxs-lookup"><span data-stu-id="58e0f-134">Define motion specific properties (such as DampingRatio for springs.)</span></span>

<span data-ttu-id="58e0f-135">最初に作成する一般的な式:</span><span class="sxs-lookup"><span data-stu-id="58e0f-135">General Formula to get started:</span></span>

1. <span data-ttu-id="58e0f-136">**Create** メソッドのいずれかを使用して、Compositor から NaturalMotionAnimation します。</span><span class="sxs-lookup"><span data-stu-id="58e0f-136">Create the NaturalMotionAnimation off the Compositor using one of the **Create** methods.</span></span>
1. <span data-ttu-id="58e0f-137">アニメーションのプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="58e0f-137">Define the properties of the animation.</span></span>
1. <span data-ttu-id="58e0f-138">NaturalMotionAnimation を、パラメーターとして CompositionObject からの StartAnimation 呼び出しに渡します。</span><span class="sxs-lookup"><span data-stu-id="58e0f-138">Pass the NaturalMotionAnimation as a parameter to the StartAnimation call off of a CompositionObject.</span></span>
    - <span data-ttu-id="58e0f-139">または、InteractionTracker の InertiaModifier が持つ Motion プロパティに設定します。</span><span class="sxs-lookup"><span data-stu-id="58e0f-139">Or set to the Motion property of an InteractionTracker InertiaModifier.</span></span>

<span data-ttu-id="58e0f-140">ばねの NaturalMotionAnimation を使用して、新しい X オフセットの場所に "ばね" のモーションを表示する基本的な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="58e0f-140">A basic example using a spring NaturalMotionAnimation to make a Visual "spring" to a new X Offset location:</span></span>

```csharp
_springAnimation = _compositor.CreateSpringScalarAnimation();
_springAnimation.Period = TimeSpan.FromSeconds(0.07);
_springAnimation.DelayTime = TimeSpan.FromSeconds(1);
_springAnimation.EndPoint = 500f;
sectionNav.StartAnimation("Offset.X", _springAnimation);
```