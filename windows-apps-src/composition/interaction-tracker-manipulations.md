---
author: jwmsft
title: InteractionTracker を使用したカスタム操作
description: InteractionTracker API を使用して、カスタム操作エクスペリエンスを作成します。
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 49c9e034219b22dd17b03e2b9e8396a5edc38667
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
ms.locfileid: "1393201"
---
# <a name="custom-manipulation-experiences-with-interactiontracker"></a><span data-ttu-id="492cf-104">InteractionTracker を使用したカスタム操作エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="492cf-104">Custom manipulation experiences with InteractionTracker</span></span>

<span data-ttu-id="492cf-105">この記事では、InteractionTracker API を使用して、カスタム操作エクスペリエンスを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="492cf-105">In this article, we show how to use InteractionTracker to create custom manipulation experiences.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="492cf-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="492cf-106">Prerequisites</span></span>

<span data-ttu-id="492cf-107">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="492cf-107">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="492cf-108">入力駆動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="492cf-108">Input-driven animations</span></span>](input-driven-animations.md)
- [<span data-ttu-id="492cf-109">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="492cf-109">Relation based animations</span></span>](relation-animations.md)

## <a name="why-create-custom-manipulation-experiences"></a><span data-ttu-id="492cf-110">カスタム操作エクスペリエンスを作成する理由</span><span class="sxs-lookup"><span data-stu-id="492cf-110">Why create custom manipulation experiences?</span></span>

<span data-ttu-id="492cf-111">ほとんどの場合、UI エクスペリエンスを作成するには、事前に作成した操作のコントロールを利用するだけで十分です。</span><span class="sxs-lookup"><span data-stu-id="492cf-111">In most cases, utilizing the pre-built manipulation controls are good enough to create UI experiences.</span></span> <span data-ttu-id="492cf-112">ただし、一般的なコントロールと区別する必要がある場合はどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="492cf-112">But what if you wanted to differentiate from the common controls?</span></span> <span data-ttu-id="492cf-113">また、入力によって動作する特別なエクスペリエンスを作成する必要がある場合や、従来の操作のモーションでは不十分な UI がある場合はどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="492cf-113">What if you wanted to create a specific experience driven by input or have a UI where a traditional manipulation motion is not sufficient?</span></span> <span data-ttu-id="492cf-114">こうした状況に対応するために、カスタム エクスペリエンスが必要となるのです。</span><span class="sxs-lookup"><span data-stu-id="492cf-114">This is where creating custom experiences comes in.</span></span> <span data-ttu-id="492cf-115">カスタム エクスペリエンスによって、アプリの開発者やデザイナーの創造力を高めることができます。ブランドやカスタムのデザイン言語をより適切に表すモーション エクスペリエンスを生み出すことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="492cf-115">They enable app developers and designers to be more creative – bring to life motion experiences that better exemplify their branding and custom design language.</span></span> <span data-ttu-id="492cf-116">操作エクスペリエンスを完全にカスタマイズする際に必要となる適切な構成要素のセットは、基本部分から利用することができます。たとえば、指を画面に触れたり画面から離したりした場合の、スナップ位置や入力チェーンに対するモーションの反応などを構成できます。</span><span class="sxs-lookup"><span data-stu-id="492cf-116">From the ground up, you are given access to the right set of building blocks to completely customize a manipulation experience – from how motion should respond with the finger on and off the screen to snap points and input chaining.</span></span>

<span data-ttu-id="492cf-117">次に、カスタム操作エクスペリエンスの作成に関する一般的な例をいくつか示します。</span><span class="sxs-lookup"><span data-stu-id="492cf-117">Below are some common examples of when you’d create a custom manipulation experience:</span></span>

- <span data-ttu-id="492cf-118">カスタムのスワイプを追加して、動作の削除/非表示を行う</span><span class="sxs-lookup"><span data-stu-id="492cf-118">Adding a custom swipe, delete/dismiss behavior</span></span>
- <span data-ttu-id="492cf-119">入力によって動作する効果 (コンテンツをぼかすためのパン)</span><span class="sxs-lookup"><span data-stu-id="492cf-119">Input driven effects (panning causes content to blur)</span></span>
- <span data-ttu-id="492cf-120">調整された操作のモーションを使用したカスタム コントロール (カスタムの ListView や ScrollViewer など)</span><span class="sxs-lookup"><span data-stu-id="492cf-120">Custom Controls with tailored manipulation motions (custom ListView, ScrollViewer, etc.)</span></span>

![スワイプによるスクロールの例](images/animation/swipe-scroller.gif)

![引き出されるようなアニメーション化の例](images/animation/pull-to-animate.gif)

## <a name="why-use-interactiontracker"></a><span data-ttu-id="492cf-123">InteractionTracker を使用する理由</span><span class="sxs-lookup"><span data-stu-id="492cf-123">Why use InteractionTracker?</span></span>

<span data-ttu-id="492cf-124">InteractionTracker は、SDK バージョン 10586 で Windows.UI.Composition.Interactions 名前空間に導入されました。</span><span class="sxs-lookup"><span data-stu-id="492cf-124">InteractionTracker was introduced to the Windows.UI.Composition.Interactions namespace in the 10586 SDK version.</span></span> <span data-ttu-id="492cf-125">InteractionTracker では次のことを実行できます。</span><span class="sxs-lookup"><span data-stu-id="492cf-125">InteractionTracker enables:</span></span>

- <span data-ttu-id="492cf-126">**完全な柔軟性** – 操作エクスペリエンスのすべての側面をカスタマイズし調整することができます。具体的には、入力時または入力に反応して発生するモーションを正確にカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="492cf-126">**Complete Flexibility** – we want you to be able to customize and tailor every aspect of a manipulation experience; specifically, the exact motions that occur during, or in response to, input.</span></span> <span data-ttu-id="492cf-127">InteractionTracker を使用してカスタム操作エクスペリエンスを作成するとき、必要なすべての素材は自由に利用できます。</span><span class="sxs-lookup"><span data-stu-id="492cf-127">When building a custom manipulation experience with InteractionTracker, all the knobs you need are at your disposal.</span></span>
- <span data-ttu-id="492cf-128">**スムーズなパフォーマンス** – 操作エクスペリエンスの課題の 1 つは、そのパフォーマンスが UI スレッドに依存していることです。</span><span class="sxs-lookup"><span data-stu-id="492cf-128">**Smooth Performance** – one of the challenges with manipulation experiences is that their performance is dependent on the UI thread.</span></span> <span data-ttu-id="492cf-129">このことは、UI がビジー状態の場合に、すべての操作エクスペリエンスに悪影響を及ぼす可能性があります。</span><span class="sxs-lookup"><span data-stu-id="492cf-129">This can negatively impact any manipulation experience when the UI is busy.</span></span> <span data-ttu-id="492cf-130">InteractionTracker は、独立したスレッド上で 60 FPS で動作し、滑らかな動きを実現する新しいアニメーション エンジンを利用するために作成されました。</span><span class="sxs-lookup"><span data-stu-id="492cf-130">InteractionTracker was built to utilize the new Animation engine that operates on an independent thread at 60 FPS,resulting in smooth motion.</span></span>

## <a name="overview-interactiontracker"></a><span data-ttu-id="492cf-131">概要: InteractionTracker</span><span class="sxs-lookup"><span data-stu-id="492cf-131">Overview: InteractionTracker</span></span>

<span data-ttu-id="492cf-132">カスタム操作エクスペリエンスを作成するとき、2 つの主要なコンポーネントを操作できます。</span><span class="sxs-lookup"><span data-stu-id="492cf-132">When creating custom manipulation experiences, there are two primary components you interact with.</span></span> <span data-ttu-id="492cf-133">最初にこれらのコンポーネントについて説明します。</span><span class="sxs-lookup"><span data-stu-id="492cf-133">We’ll discuss these first:</span></span>

- <span data-ttu-id="492cf-134">[InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker) – アクティブなユーザー入力、直接的な更新、および直接的なアニメーションによって動作するプロパティを持つステート マシンを管理するコア オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="492cf-134">[InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker) – the core object maintaining a state machine whose properties are driven by active user input or direct updates and animations.</span></span> <span data-ttu-id="492cf-135">このオブジェクトは、CompositionAnimation と関連付けて、カスタム操作のモーションを作成することを目的としています。</span><span class="sxs-lookup"><span data-stu-id="492cf-135">It is intended to then tie to a CompositionAnimation to create the custom manipulation motion.</span></span>
- <span data-ttu-id="492cf-136">[VisualInteractionSource](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.visualinteractionsource) – 入力が InteractionTracker に送信されるタイミングや条件を定義する補完オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="492cf-136">[VisualInteractionSource](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.visualinteractionsource) – a complement object that defines when and under what conditions input gets sent to InteractionTracker.</span></span> <span data-ttu-id="492cf-137">ヒット テストや他の入力構成プロパティで使用される CompositionVisual を定義します。</span><span class="sxs-lookup"><span data-stu-id="492cf-137">It defines both the CompositionVisual used for Hit-testing as well as other input configuration properties.</span></span>

<span data-ttu-id="492cf-138">ステート マシンとして、InteractionTracker のプロパティは次のいずれかによって動作します。</span><span class="sxs-lookup"><span data-stu-id="492cf-138">As a state machine, properties of InteractionTracker can be driven by any of the following:</span></span>

- <span data-ttu-id="492cf-139">直接的なユーザー操作 – エンド ユーザーは、VisualInteractionSource ヒット テスト領域内で直接操作を行います。</span><span class="sxs-lookup"><span data-stu-id="492cf-139">Direct User Interaction – the end user is directly manipulating within the VisualInteractionSource hit-test region</span></span>
- <span data-ttu-id="492cf-140">慣性 – プログラムに従った速度やユーザーのジェスチャによって、InteractionTracker のプロパティが慣性曲線に基づいてアニメーション化されます。</span><span class="sxs-lookup"><span data-stu-id="492cf-140">Inertia – either from programmatic velocity or a user gesture, properties of InteractionTracker animate under an inertia curve</span></span>
- <span data-ttu-id="492cf-141">CustomAnimation – InteractionTracker のプロパティを直接ターゲットとするカスタム アニメーションです。</span><span class="sxs-lookup"><span data-stu-id="492cf-141">CustomAnimation – a custom animation directly targeting a property of InteractionTracker</span></span>

### <a name="interactiontracker-state-machine"></a><span data-ttu-id="492cf-142">InteractionTracker ステート マシン</span><span class="sxs-lookup"><span data-stu-id="492cf-142">InteractionTracker State Machine</span></span>

<span data-ttu-id="492cf-143">既に説明したように、InteractionTracker は 4 つの状態を持つステート マシンです。各状態は他のいずれの状態にも遷移することができます </span><span class="sxs-lookup"><span data-stu-id="492cf-143">As mentioned previously, InteractionTracker is a state machine with 4 states – each of which can transition to any of the other four states.</span></span> <span data-ttu-id="492cf-144">(InteractionTracker でこれらの状態がどのように遷移するかについて詳しくは、[InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker) クラスのドキュメントをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="492cf-144">(For more info about how InteractionTracker transitions between these states, see the [InteractionTracker](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.interactiontracker) class documentation.)</span></span>

| <span data-ttu-id="492cf-145">状態</span><span class="sxs-lookup"><span data-stu-id="492cf-145">State</span></span> | <span data-ttu-id="492cf-146">説明</span><span class="sxs-lookup"><span data-stu-id="492cf-146">Description</span></span> |
|-------|-------------|
| <span data-ttu-id="492cf-147">アイドル</span><span class="sxs-lookup"><span data-stu-id="492cf-147">Idle</span></span> | <span data-ttu-id="492cf-148">アクティブになっていません。モーションを発生させる入力やアニメーションがありません。</span><span class="sxs-lookup"><span data-stu-id="492cf-148">No active, driving inputs or animations</span></span> |
| <span data-ttu-id="492cf-149">操作中</span><span class="sxs-lookup"><span data-stu-id="492cf-149">Interacting</span></span> | <span data-ttu-id="492cf-150">アクティブなユーザー入力が検出されました。</span><span class="sxs-lookup"><span data-stu-id="492cf-150">Active user input detected</span></span> |
| <span data-ttu-id="492cf-151">慣性</span><span class="sxs-lookup"><span data-stu-id="492cf-151">Inertia</span></span> | <span data-ttu-id="492cf-152">アクティブな入力やプログラムに従った速度によって、アクティブなモーションが発生しました。</span><span class="sxs-lookup"><span data-stu-id="492cf-152">Active motion resulting from active input or programmatic velocity</span></span> |
| <span data-ttu-id="492cf-153">CustomAnimation</span><span class="sxs-lookup"><span data-stu-id="492cf-153">CustomAnimation</span></span> | <span data-ttu-id="492cf-154">カスタム アニメーションによって、アクティブなモーションが発生しました。</span><span class="sxs-lookup"><span data-stu-id="492cf-154">Active motion resulting from a custom animation</span></span> |

<span data-ttu-id="492cf-155">InteractionTracker での状態遷移の各状況では、リッスンすることができイベント (またはコールバック) が生成されます。</span><span class="sxs-lookup"><span data-stu-id="492cf-155">In each of the cases where the state of InteractionTracker changes, an event (or callback) is generated that you can listen for.</span></span> <span data-ttu-id="492cf-156">これらのイベントをリッスンするには、[IInteractionTrackerOwner](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.iinteractiontrackerowner) インターフェイスを実装し、CreateWithOwner メソッドを使用して、InteractionTracker オブジェクトを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="492cf-156">In order for you to listen for these events, they must implement the [IInteractionTrackerOwner](https://docs.microsoft.com/uwp/api/windows.ui.composition.interactions.iinteractiontrackerowner) interface and create their InteractionTracker object with the CreateWithOwner method.</span></span> <span data-ttu-id="492cf-157">次の図は、さまざまなイベントがトリガーされるタイミングの概要を示しています。</span><span class="sxs-lookup"><span data-stu-id="492cf-157">The following diagram also outlines when the different events get triggered.</span></span>

![InteractionTracker ステート マシン](images/animation/interaction-tracker-diagram.png)

## <a name="using-the-visualinteractionsource"></a><span data-ttu-id="492cf-159">VisualInteractionSource の使用</span><span class="sxs-lookup"><span data-stu-id="492cf-159">Using the VisualInteractionSource</span></span>

<span data-ttu-id="492cf-160">InteractionTracker を入力によって動作させるには、VisualInteractionSource (VIS) を InteractionTracker に関連付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="492cf-160">For InteractionTracker to be driven by Input, you need to connect a VisualInteractionSource (VIS) to it.</span></span> <span data-ttu-id="492cf-161">VIS は補完オブジェクトとして作成され、CompositionVisual を使用して次のことを定義します。</span><span class="sxs-lookup"><span data-stu-id="492cf-161">The VIS is created as a complement object using a CompositionVisual to define:</span></span>

1. <span data-ttu-id="492cf-162">入力が追跡され、座標空間のジェスチャが検出されるヒット テスト領域。</span><span class="sxs-lookup"><span data-stu-id="492cf-162">The hit-test region that input will be tracked, and the coordinate space gestures are detected in</span></span>
1. <span data-ttu-id="492cf-163">検出されルーティングされる入力の構成。次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="492cf-163">The configurations of input that will get detected and routed, a few include:</span></span>
    - <span data-ttu-id="492cf-164">検出可能なジェスチャー: 位置 X および Y (水平方向および垂直方向のパン)、拡大/縮小 (ピンチ)</span><span class="sxs-lookup"><span data-stu-id="492cf-164">Detectable gestures: Position X and Y (horizontal and vertical panning), Scale (pinch)</span></span>
    - <span data-ttu-id="492cf-165">慣性</span><span class="sxs-lookup"><span data-stu-id="492cf-165">Inertia</span></span>
    - <span data-ttu-id="492cf-166">レールとチェーン</span><span class="sxs-lookup"><span data-stu-id="492cf-166">Rails & Chaining</span></span>
    - <span data-ttu-id="492cf-167">リダイレクト モード: InteractionTracker に自動的にリダイレクトされる入力データの種類</span><span class="sxs-lookup"><span data-stu-id="492cf-167">Redirection Modes: what input data is redirected automatically to InteractionTracker</span></span>

> [!NOTE]
> <span data-ttu-id="492cf-168">VisualInteractionSource は、ヒット テストの位置と Visual の座標空間に基づいて作成されるので、動作を表したり、位置を変更する Visual は使用しないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="492cf-168">Because the VisualInteractionSource is created based off the hit-test position and coordinate space of a Visual, it recommended not to use a Visual that will be in motion or changing position.</span></span>

> [!NOTE]
> <span data-ttu-id="492cf-169">複数のヒット テスト領域がある場合は、同じ InteractionTracker で複数の VisualInteractionSource インスタンスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="492cf-169">You can use multiple VisualInteractionSource instances with the same InteractionTracker if there are multiple hit-test regions.</span></span> <span data-ttu-id="492cf-170">ただし、VIS は 1 つだけ使用するのが最も一般的な方法です。</span><span class="sxs-lookup"><span data-stu-id="492cf-170">However, the most common case is to use only one VIS.</span></span>

<span data-ttu-id="492cf-171">また、VisualInteractionSource では、さまざまな入力方式 (タッチ、PTP、ペン) からの入力データを InteractionTracker にルーティングするタイミングを管理することもできます。</span><span class="sxs-lookup"><span data-stu-id="492cf-171">The VisualInteractionSource is also responsible for managing when input data from different modalities (touch, PTP, Pen) get routed to InteractionTracker.</span></span> <span data-ttu-id="492cf-172">この動作は、ManipulationRedirectionMode プロパティによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="492cf-172">This behavior is defined by the ManipulationRedirectionMode property.</span></span> <span data-ttu-id="492cf-173">既定では、すべてのポインター入力は UI スレッドに送信され、高精度タッチパッドの入力は VisualInteractionSource と InteractionTracker に送信されます。</span><span class="sxs-lookup"><span data-stu-id="492cf-173">By default, all Pointer input is sent to the UI thread and Precision Touchpad input goes to the VisualInteractionSource and InteractionTracker.</span></span>

<span data-ttu-id="492cf-174">このため、タッチとペン (Creators Update) で VisualInteractionSource と InteractionTracker を利用して操作を実行する場合は、VisualInteractionSource.TryRedirectForManipulation メソッドを呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="492cf-174">Thus, if you want to have Touch and Pen (Creators Update) to drive a manipulation through a VisualInteractionSource and InteractionTracker, you must call the VisualInteractionSource.TryRedirectForManipulation method.</span></span> <span data-ttu-id="492cf-175">以下の XAML アプリの短いスニペットでは、タッチ入力イベントが最上位の UIElement グリッドで発生したときに、メソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="492cf-175">In the short snippet below from a XAML app, the method is called when a touch pressed event occurs at the top most UIElement Grid:</span></span>

```csharp
private void root_PointerPressed(object sender, PointerRoutedEventArgs e)
{
    if (e.Pointer.PointerDeviceType == Windows.Devices.Input.PointerDeviceType.Touch)
    {
        _source.TryRedirectForManipulation(e.GetCurrentPoint(root));
    }
}
```

## <a name="tie-in-with-expressionanimations"></a><span data-ttu-id="492cf-176">ExpressionAnimations との関連付け</span><span class="sxs-lookup"><span data-stu-id="492cf-176">Tie-in with ExpressionAnimations</span></span>

<span data-ttu-id="492cf-177">InteractionTracker を利用して操作エクスペリエンスを実行するとき、主に Scale プロパティと Position プロパティとやり取ります。</span><span class="sxs-lookup"><span data-stu-id="492cf-177">When utilizing InteractionTracker to drive a manipulation experience, you interact primarily with the Scale and Position properties.</span></span> <span data-ttu-id="492cf-178">他の CompositionObject プロパティと同様に、これらのプロパティは、CompositionAnimation (多くの場合は ExpressionAnimations) でターゲットにされたり、参照されたりする場合があります。</span><span class="sxs-lookup"><span data-stu-id="492cf-178">Like other CompositionObject properties, these properties can be both the target and referenced in a CompositionAnimation, most commonly ExpressionAnimations.</span></span>

<span data-ttu-id="492cf-179">式で InteractionTracker を使用するには、次の例のように、トラッカーの Position (または Scale) プロパティを参照します。</span><span class="sxs-lookup"><span data-stu-id="492cf-179">To use InteractionTracker within an Expression, reference the tracker’s Position (or Scale) property like in the example below.</span></span> <span data-ttu-id="492cf-180">InteractionTracker のプロパティは前に説明した状態に応じて変更されるため、式の出力も変わります。</span><span class="sxs-lookup"><span data-stu-id="492cf-180">As the property of InteractionTracker is modified due to any of the conditions described earlier, the output of the Expression changes as well.</span></span>

```csharp
// With Strings
var opacityExp = _compositor.CreateExpressionAnimation("-tracker.Position");
opacityExp.SetReferenceParameter("tracker", _tracker);

// With ExpressionBuilder
var opacityExp = -_tracker.GetReference().Position;
```

> [!NOTE]
> <span data-ttu-id="492cf-181">式で InteractionTracker の位置を参照する場合は、最終的に生成される式で適切な方向への移動を行うための値を無効にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="492cf-181">When referencing InteractionTracker’s position in an Expression, you must negate the value for the resulting Expression to move in the correct direction.</span></span> <span data-ttu-id="492cf-182">その理由は、InteractionTracker ではグラフの原点から一方向への移動が行われるためです。また、ユーザーが "現実世界" の座標における InteractionTracker の一方向への移動 (原点からの距離など) を考慮することができるためです。</span><span class="sxs-lookup"><span data-stu-id="492cf-182">This is because InteractionTracker’s progression from origin on a graph and allow you to think about InteractionTracker’s progression in "real world" coordinates, such as distance from its origin.</span></span>

## <a name="get-started"></a><span data-ttu-id="492cf-183">作業の開始</span><span class="sxs-lookup"><span data-stu-id="492cf-183">Get Started</span></span>

<span data-ttu-id="492cf-184">InteractionTracker を使用して、カスタム操作エクスペリエンスの作成を開始するには:</span><span class="sxs-lookup"><span data-stu-id="492cf-184">To get started with using InteractionTracker to create custom manipulation experiences:</span></span>

1. <span data-ttu-id="492cf-185">InteractionTracker.Create または InteractionTracker.CreateWithOwner を使用して、InteractionTracker オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="492cf-185">Create your InteractionTracker object using InteractionTracker.Create or InteractionTracker.CreateWithOwner.</span></span>
    - <span data-ttu-id="492cf-186">(CreateWithOwner を使用する場合は、IInteractionTrackerOwner インターフェイスを必ず実装してください)</span><span class="sxs-lookup"><span data-stu-id="492cf-186">(If you use CreateWithOwner, ensure you implement the IInteractionTrackerOwner interface.)</span></span>
1. <span data-ttu-id="492cf-187">新しく作成する InteractionTracker の最小位置と最大位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="492cf-187">Set the Min and Max position of your newly created InteractionTracker.</span></span>
1. <span data-ttu-id="492cf-188">CompositionVisual を使用して VisualInteractionSource を作成します。</span><span class="sxs-lookup"><span data-stu-id="492cf-188">Create your VisualInteractionSource with a CompositionVisual.</span></span>
    - <span data-ttu-id="492cf-189">渡す Visual のサイズが 0 ではないことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="492cf-189">Ensure the visual you pass in has a non-zero size.</span></span> <span data-ttu-id="492cf-190">0 である場合、ヒット テストが正しく実行されません。</span><span class="sxs-lookup"><span data-stu-id="492cf-190">Otherwise, it will not get hit-tested correctly.</span></span>
1. <span data-ttu-id="492cf-191">VisualInteractionSource のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="492cf-191">Set the properties of the VisualInteractionSource.</span></span>
    - <span data-ttu-id="492cf-192">VisualInteractionSourceRedirectionMode</span><span class="sxs-lookup"><span data-stu-id="492cf-192">VisualInteractionSourceRedirectionMode</span></span>
    - <span data-ttu-id="492cf-193">PositionXSourceMode、PositionYSourceMode、ScaleSourceMode</span><span class="sxs-lookup"><span data-stu-id="492cf-193">PositionXSourceMode, PositionYSourceMode, ScaleSourceMode</span></span>
    - <span data-ttu-id="492cf-194">レールとチェーン</span><span class="sxs-lookup"><span data-stu-id="492cf-194">Rails & Chaining</span></span>
1. <span data-ttu-id="492cf-195">InteractionTracker.InteractionSources.Add を使用して、VisualInteractionSource を InteractionTracker に追加します。</span><span class="sxs-lookup"><span data-stu-id="492cf-195">Add the VisualInteractionSource to InteractionTracker using InteractionTracker.InteractionSources.Add.</span></span>
1. <span data-ttu-id="492cf-196">タッチとペンによる入力が検出された場合に備えて、TryRedirectForManipulation をセットアップします。</span><span class="sxs-lookup"><span data-stu-id="492cf-196">Setup TryRedirectForManipulation for when Touch and Pen input is detected.</span></span>
    - <span data-ttu-id="492cf-197">通常 XAML では、これは UIElement の PointerPressed イベントで行われます。</span><span class="sxs-lookup"><span data-stu-id="492cf-197">For XAML, this is typically done on the UIElement’s PointerPressed event.</span></span>
1. <span data-ttu-id="492cf-198">InteractionTracker の位置を参照し、CompositionObject のプロパティをターゲットにする ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="492cf-198">Create an ExpressionAnimation that references InteractionTracker’s position and target a CompositionObject’s property.</span></span>

<span data-ttu-id="492cf-199">手順 1. ~ 5. の実行を表す短いコード スニペットを次に示します。</span><span class="sxs-lookup"><span data-stu-id="492cf-199">Here is a short code snippet that shows #1 – 5 in action:</span></span>

```csharp
private void InteractionTrackerSetup(Compositor compositor, Visual hitTestRoot)
{ 
    // #1 Create InteractionTracker object
    var tracker = InteractionTracker.Create(compositor);

    // #2 Set Min and Max positions
    tracker.MinPosition = new Vector3(-1000f);
    tracker.MaxPosition = new Vector3(1000f);

    // #3 Setup the VisualInteractionSourc
    var source = VisualInteractionSource.Create(hitTestRoot);

    // #4 Set the properties for the VisualInteractionSource
    source.ManipulationRedirectionMode =
        VisualInteractionSourceRedirectionMode.CapableTouchpadOnly;
    source.PositionXSourceMode = InteractionSourceMode.EnabledWithInertia;
    source.PositionYSourceMode = InteractionSourceMode.EnabledWithInertia;

    // #5 Add the VisualInteractionSource to InteractionTracker
    tracker.InteractionSources.Add(source);
}
```

<span data-ttu-id="492cf-200">InteractionTracker の高度な使用法について詳しくは、次の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="492cf-200">For more advanced usages of InteractionTracker, see the following articles:</span></span>

- [<span data-ttu-id="492cf-201">InertiaModifiers を使用したスナップ位置の作成</span><span class="sxs-lookup"><span data-stu-id="492cf-201">Create snap points with InertiaModifiers</span></span>](inertia-modifiers.md)
- [<span data-ttu-id="492cf-202">SourceModifiers を使用した引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="492cf-202">Pull-to-refresh with SourceModifiers</span></span>](source-modifiers.md)
