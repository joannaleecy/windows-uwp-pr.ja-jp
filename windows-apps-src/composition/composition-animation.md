---
author: jwmsft
ms.assetid: 386faf59-8f22-2e7c-abc9-d04216e78894
title: コンポジションのアニメーション
description: コンポジション オブジェクトと効果の多くのプロパティは、キー フレーム アニメーションや数式アニメーションを使って、時間の経過や計算に基づいて UI 要素のプロパティを変更することによりアニメーション化できます。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.openlocfilehash: e7d0f5c3fc0d1414dc1b4f714683494fcffd4f51
ms.sourcegitcommit: b42d14c775efbf449a544ddb881abd1c65c1ee86
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/20/2017
ms.locfileid: "839534"
---
# <a name="composition-animations"></a><span data-ttu-id="ab10c-104">コンポジションのアニメーション</span><span class="sxs-lookup"><span data-stu-id="ab10c-104">Composition animations</span></span>

<span data-ttu-id="ab10c-105">Windows.UI.Composition API によって、統合された API レイヤーでコンポジター オブジェクトを作成、アニメーション化、変換、操作することができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-105">The Windows.UI.Composition APIs allows you to create, animate, transform and manipulate compositor objects in a unified API layer.</span></span> <span data-ttu-id="ab10c-106">コンポジションのアニメーションは、アプリケーションの UI でアニメーションを実行するための強力で効率的な手段を提供します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-106">Composition animations provide a powerful and efficient way to run animations in your application UI.</span></span> <span data-ttu-id="ab10c-107">コンポジション アニメーションは、アニメーションが UI スレッドから独立して 60 FPS で実行され、時間だけでなく、入力やその他のプロパティを使ってアニメーションを駆動する驚くようなエクスペリエンスを柔軟に構築できるように、一から設計されています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-107">They have been designed from the ground up to ensure that your animations run at 60 FPS independent of the UI thread and to give you the flexibility to build amazing experiences using not only time, but input and other properties, to drive animations.</span></span>

<span data-ttu-id="ab10c-108">この記事では、コンポジション オブジェクトのプロパティのアニメーション化で使用できる機能の概要を説明します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-108">This article provides an overview of the functionality available that allows you to animate properties of the Composition object.</span></span> <span data-ttu-id="ab10c-109">ここでは、ビジュアル レイヤーの構造の基礎を理解していることを前提としています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-109">We assume you are familiar with the basics of the Visual Layer structure.</span></span> <span data-ttu-id="ab10c-110">詳しくは、[コンポジションのビジュアル](./composition-visual-tree.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-110">For more information, see [Composition visual](./composition-visual-tree.md).</span></span>

<span data-ttu-id="ab10c-111">コンポジション アニメーションには、**キー フレーム アニメーション**と**数式アニメーション**の 2 つの種類があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-111">There are two types of Composition Animations: **KeyFrame Animations** and **Expression Animations**.</span></span>

![アニメーション型](./images/composition-animation-types.png)

## <a name="types-of-composition-animations"></a><span data-ttu-id="ab10c-113">コンポジション アニメーションの種類</span><span class="sxs-lookup"><span data-stu-id="ab10c-113">Types of Composition Animations</span></span>

<span data-ttu-id="ab10c-114">**キー フレーム アニメーション**は、従来の時間に基づく*フレーム単位の*アニメーション エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-114">**KeyFrame Animations** provide your traditional time-driven, *frame-by-frame* animation experiences.</span></span> <span data-ttu-id="ab10c-115">アニメーション タイムラインの特定の時点におけるアニメーション化プロパティの値を指定する*制御点*を明示的に定義できます</span><span class="sxs-lookup"><span data-stu-id="ab10c-115">You can explicitly define *control points* that describe values an animating property needs to be at specific points in the animation timeline.</span></span> <span data-ttu-id="ab10c-116">さらに重要なのは、イージング関数 (インターポレーターとも呼ばれる) を使って、これらの制御点の間を遷移する方法を指定できる点です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-116">More importantly you are able to use Easing Functions (otherwise called Interpolators) to describe how to transition between these control points.</span></span>

<span data-ttu-id="ab10c-117">**暗黙的なアニメーション**は、アプリのコア ロジックとは別に、再利用可能な個々のアニメーションまたは一連のアニメーションを定義できるようにする、一種のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-117">**Implicit Animations** are a type of animation that let you define reusable individual animations or a series of animations separately from the core app logic.</span></span> <span data-ttu-id="ab10c-118">暗黙的なアニメーションを使用すると、*テンプレート*を作成し、そのテンプレートをトリガーでフックできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-118">Implicit animations let you create animation *templates* and hook them up with triggers.</span></span> <span data-ttu-id="ab10c-119">これらのトリガーはプロパティの変更であり、明示的な割り当てによって発生します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-119">These triggers are property changes that result from explicit assignments.</span></span> <span data-ttu-id="ab10c-120">テンプレートは 1 つのアニメーションまたはアニメーション グループとして定義できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-120">You can define a template as a single animation or an animation group.</span></span> <span data-ttu-id="ab10c-121">アニメーション グループは、アニメーション テンプレートのコレクションで、明示的に、またはトリガーによって、まとめて開始することができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-121">Animation groups are a collection of animation templates that can be started together either explicitly or with a trigger.</span></span> <span data-ttu-id="ab10c-122">暗黙的なアニメーションを使用すると、プロパティ値の変更とアニメーション化が必要になるたびに、明示的な KeyFrameAnimations を作成しなくてもよくなります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-122">Implicit animations remove the need for you to create explicit KeyFrameAnimations every time you want to change the value of a property and see it animate.</span></span>

<span data-ttu-id="ab10c-123">**数式アニメーション**は、Windows 10 の 11 月の更新プログラム (ビルド 10586) のビジュアル レイヤーで導入されたアニメーションの種類です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-123">**Expression Animations** are a type of animation introduced in the Visual Layer with the Windows 10 November Update (Build 10586).</span></span>
<span data-ttu-id="ab10c-124">数式アニメーションの背景にあるのは、[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) プロパティと、フレームごとに評価および更新される個別の値の間に数学的な関係を構築できるようにするという考え方です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-124">The idea behind expression animations is that you can create mathematical relationships between [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) properties and discrete values that will get evaluated and updated every frame.</span></span> <span data-ttu-id="ab10c-125">コンポジション オブジェクトのプロパティやプロパティ セットを参照したり、数学関数ヘルパーを使用したり、入力を参照したりすることで、これらの数学的な関係を導き出します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-125">You can reference properties on Composition objects or property sets, use mathematical function helpers, and even reference input to derive these mathematical relationships.</span></span> <span data-ttu-id="ab10c-126">数式によって、Windows プラットフォームで、視差や固定ヘッダーなどのエクスペリエンスが実現され、スムーズに処理できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-126">Expressions make experiences like parallax and sticky headers possible and smooth on the Windows platform.</span></span>

## <a name="why-composition-animations"></a><span data-ttu-id="ab10c-127">コンポジション アニメーションを使う理由</span><span class="sxs-lookup"><span data-stu-id="ab10c-127">Why Composition Animations?</span></span>

<span data-ttu-id="ab10c-128">**パフォーマンス** ユニバーサル Windows アプリケーションを構築する場合、ほとんどのコードは UI スレッドで実行されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-128">**Performance** When building Universal Windows applications, most of your code runs on the UI thread.</span></span>
<span data-ttu-id="ab10c-129">アニメーションがさまざまなデバイス カテゴリでスムーズに実行されるように、システムはアニメーションの計算を実行し、60 FPS を維持するために独立したスレッドで処理します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-129">To ensure that the animations run smoothly across the different device categories, the system performs the animation calculations and work on an independent thread in order to maintain 60 FPS.</span></span>
<span data-ttu-id="ab10c-130">つまり、スムーズなアニメーションの提供をシステムに任せて、アプリケーションでは、高度なユーザー エクスペリエンスを実現する他の複雑な処理を実行できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-130">This means you can count on the system to provide smooth animations while your applications perform other complex operations for advanced user experiences.</span></span>

<span data-ttu-id="ab10c-131">**可能性** ビジュアル レイヤーのコンポジション アニメーションの目標は、美しい UI の作成を簡単にすることです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-131">**Possibilities** The goal for composition animations in the Visual Layer is to make it easy to create beautiful UIs.</span></span> <span data-ttu-id="ab10c-132">マイクロソフトでは、すばらしいアイデアを容易に構築できるように、さまざまな種類のアニメーションを提供したいと考えています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-132">We want to provide you with different types of animations that make it easy to build your amazing ideas.</span></span>

<span data-ttu-id="ab10c-133">**テンプレート化** ビジュアル レイヤーのすべてのコンポジション アニメーションがテンプレートです。つまり、別のアニメーションを作る必要なく、複数のオブジェクトで 1 つのアニメーションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-133">**Templating** All composition animations in the Visual Layer are templates – this means that you can use an animation on multiple objects without the need to create separate animations.</span></span>
<span data-ttu-id="ab10c-134">これにより、同じアニメーションを使用し、プロパティやパラメーターを調整することで、以前の用途に影響を及ぼすことを心配せずに、他のニーズを満たすことができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-134">This lets you use the same animation and tweak properties or parameters to meet some other needs without the worry of obstructing the previous uses.</span></span>

<span data-ttu-id="ab10c-135">//Build で、[数式アニメーション](https://channel9.msdn.com/events/Build/2016/P486)、[対話型エクスペリエンス](https://channel9.msdn.com/Events/Build/2016/P405)、[暗黙的なアニメーション](https://channel9.msdn.com/events/Build/2016/P484)、[接続型アニメーション](https://channel9.msdn.com/events/Build/2016/P485)の使用例をいくつかご確認ください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-135">You can check out our //BUILD talks for [Expression Animations](https://channel9.msdn.com/events/Build/2016/P486), [Interactive Experiences](https://channel9.msdn.com/Events/Build/2016/P405), [Implicit Animations](https://channel9.msdn.com/events/Build/2016/P484), and [Connected Animations](https://channel9.msdn.com/events/Build/2016/P485) to see some examples of what is possible.</span></span>

<span data-ttu-id="ab10c-136">また、[コンポジションに関する GitHub のページ](http://go.microsoft.com/fwlink/?LinkID=789439)で、API の使い方についてのサンプルや、動作している API の高品質のサンプルもご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-136">You can also check out the [Composition GitHub](http://go.microsoft.com/fwlink/?LinkID=789439) for samples on how to use the APIs and high fidelity samples of the APIs in action.</span></span>

## <a name="what-can-you-animate-with-composition-animations"></a><span data-ttu-id="ab10c-137">コンポジション アニメーションでアニメーション化できる対象</span><span class="sxs-lookup"><span data-stu-id="ab10c-137">What can you animate with Composition Animations?</span></span>

<span data-ttu-id="ab10c-138">コンポジション アニメーションは、[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) や **InsetClip** など、コンポジション オブジェクトの多くのプロパティに適用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-138">Composition animations can be applied to most properties of composition objects such as [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx), and **InsetClip**.</span></span>
<span data-ttu-id="ab10c-139">コンポジション アニメーションは、コンポジション効果やプロパティ セットに適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-139">You can also apply composition animations to composition effects and property sets.</span></span> **<span data-ttu-id="ab10c-140">アニメーション化する対象を選択するときは、その型に注意します。その型を使って、構築するキー フレーム アニメーションの型や、数式を解決する必要がある型を決定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-140">When choosing what to animate, take note of the type – use this to determine what type of KeyFrame animation you construct or what type your expression must resolve to.</span></span>**

### <a name="visual"></a><span data-ttu-id="ab10c-141">Visual</span><span class="sxs-lookup"><span data-stu-id="ab10c-141">Visual</span></span>

|<span data-ttu-id="ab10c-142">アニメーション化が可能な Visual プロパティ</span><span class="sxs-lookup"><span data-stu-id="ab10c-142">Animatable Visual Properties</span></span>|<span data-ttu-id="ab10c-143">型</span><span class="sxs-lookup"><span data-stu-id="ab10c-143">Type</span></span>|
|------|------|
|<span data-ttu-id="ab10c-144">AnchorPoint</span><span class="sxs-lookup"><span data-stu-id="ab10c-144">AnchorPoint</span></span>|<span data-ttu-id="ab10c-145">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-145">Vector2</span></span>|
|<span data-ttu-id="ab10c-146">CenterPoint</span><span class="sxs-lookup"><span data-stu-id="ab10c-146">CenterPoint</span></span>|<span data-ttu-id="ab10c-147">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-147">Vector3</span></span>|
|<span data-ttu-id="ab10c-148">Offset</span><span class="sxs-lookup"><span data-stu-id="ab10c-148">Offset</span></span>|<span data-ttu-id="ab10c-149">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-149">Vector3</span></span>|
|<span data-ttu-id="ab10c-150">Opacity</span><span class="sxs-lookup"><span data-stu-id="ab10c-150">Opacity</span></span>|<span data-ttu-id="ab10c-151">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-151">Scalar</span></span>|
|<span data-ttu-id="ab10c-152">Orientation</span><span class="sxs-lookup"><span data-stu-id="ab10c-152">Orientation</span></span>|<span data-ttu-id="ab10c-153">Quaternion</span><span class="sxs-lookup"><span data-stu-id="ab10c-153">Quaternion</span></span>|
|<span data-ttu-id="ab10c-154">RotationAngle</span><span class="sxs-lookup"><span data-stu-id="ab10c-154">RotationAngle</span></span>|<span data-ttu-id="ab10c-155">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-155">Scalar</span></span>|
|<span data-ttu-id="ab10c-156">RotationAngleInDegrees</span><span class="sxs-lookup"><span data-stu-id="ab10c-156">RotationAngleInDegrees</span></span>|<span data-ttu-id="ab10c-157">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-157">Scalar</span></span>|
|<span data-ttu-id="ab10c-158">RotationAxis</span><span class="sxs-lookup"><span data-stu-id="ab10c-158">RotationAxis</span></span>|<span data-ttu-id="ab10c-159">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-159">Vector3</span></span>|
|<span data-ttu-id="ab10c-160">Scale</span><span class="sxs-lookup"><span data-stu-id="ab10c-160">Scale</span></span>|<span data-ttu-id="ab10c-161">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-161">Vector3</span></span>|
|<span data-ttu-id="ab10c-162">Size</span><span class="sxs-lookup"><span data-stu-id="ab10c-162">Size</span></span>|<span data-ttu-id="ab10c-163">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-163">Vector2</span></span>|
|<span data-ttu-id="ab10c-164">TransformMatrix\*</span><span class="sxs-lookup"><span data-stu-id="ab10c-164">TransformMatrix\*</span></span>|<span data-ttu-id="ab10c-165">Matrix4x4</span><span class="sxs-lookup"><span data-stu-id="ab10c-165">Matrix4x4</span></span>|
<span data-ttu-id="ab10c-166">\*TransformMatrix プロパティ全体を Matrix4x4 としてアニメーション化する場合は、ExpressionAnimation を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-166">\*If you want to animate the entire TransformMatrix property as a Matrix4x4, you need to use an ExpressionAnimation to do so.</span></span>
<span data-ttu-id="ab10c-167">それ以外の場合は、マトリックスの個々のセルをターゲットにして、KeyFrame または ExpressionAnimation を使用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-167">Otherwise, you can target individual cells of the matrix and can use either a KeyFrame or ExpressionAnimation there.</span></span>

### <a name="insetclip"></a><span data-ttu-id="ab10c-168">InsetClip</span><span class="sxs-lookup"><span data-stu-id="ab10c-168">InsetClip</span></span>

|<span data-ttu-id="ab10c-169">アニメーション化が可能な InsetClip プロパティ</span><span class="sxs-lookup"><span data-stu-id="ab10c-169">Animatable InsetClip Properties</span></span>|<span data-ttu-id="ab10c-170">型</span><span class="sxs-lookup"><span data-stu-id="ab10c-170">Type</span></span>|
|-------------------------------|-------|
|<span data-ttu-id="ab10c-171">BottomInset</span><span class="sxs-lookup"><span data-stu-id="ab10c-171">BottomInset</span></span>|<span data-ttu-id="ab10c-172">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-172">Scalar</span></span>|
|<span data-ttu-id="ab10c-173">LeftInset</span><span class="sxs-lookup"><span data-stu-id="ab10c-173">LeftInset</span></span>|<span data-ttu-id="ab10c-174">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-174">Scalar</span></span>|
|<span data-ttu-id="ab10c-175">RightInset</span><span class="sxs-lookup"><span data-stu-id="ab10c-175">RightInset</span></span>|<span data-ttu-id="ab10c-176">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-176">Scalar</span></span>|
|<span data-ttu-id="ab10c-177">TopInset</span><span class="sxs-lookup"><span data-stu-id="ab10c-177">TopInset</span></span>|<span data-ttu-id="ab10c-178">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-178">Scalar</span></span>|

## <a name="visual-sub-channel-properties"></a><span data-ttu-id="ab10c-179">Visual サブ チャネルのプロパティ</span><span class="sxs-lookup"><span data-stu-id="ab10c-179">Visual Sub Channel Properties</span></span>

<span data-ttu-id="ab10c-180">[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) のプロパティをアニメーション化できるほか、これらのプロパティの*サブ チャネル* コンポーネントもアニメーション化のターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-180">In addition to being able to animate properties of [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx), you are also able to target the *sub channel* components of these properties for animations as well.</span></span>
<span data-ttu-id="ab10c-181">たとえば、オフセット全体ではなく、[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) の X オフセットだけをアニメーション化できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-181">For example, say you simply want to animate the X Offset of a [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) rather than the entire Offset.</span></span>
<span data-ttu-id="ab10c-182">アニメーション化では、Vector3 Offset プロパティか、Offset プロパティの Scalar X コンポーネントをターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-182">The animation can either target the Vector3 Offset property, or the Scalar X component of the Offset property.</span></span>
<span data-ttu-id="ab10c-183">プロパティの個々のサブ チャネル コンポーネントをターゲットにできるほか、複数のコンポーネントをターゲットにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-183">In addition to being able to target an individual sub channel component of a property, you are also able to target multiple components.</span></span>
<span data-ttu-id="ab10c-184">たとえば、Scale の X および Y コンポーネントをターゲットにすることができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-184">For example, you can target the X and Y component of Scale.</span></span>

|<span data-ttu-id="ab10c-185">アニメーション化が可能な Visual サブ チャネルのプロパティ</span><span class="sxs-lookup"><span data-stu-id="ab10c-185">Animatable Visual Sub Channel Properties</span></span>|<span data-ttu-id="ab10c-186">型</span><span class="sxs-lookup"><span data-stu-id="ab10c-186">Type</span></span>|
|----------------------------------------|------|
|<span data-ttu-id="ab10c-187">AnchorPoint.x、y</span><span class="sxs-lookup"><span data-stu-id="ab10c-187">AnchorPoint.x, y</span></span>|<span data-ttu-id="ab10c-188">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-188">Scalar</span></span>|
|<span data-ttu-id="ab10c-189">AnchorPoint.xy</span><span class="sxs-lookup"><span data-stu-id="ab10c-189">AnchorPoint.xy</span></span>|<span data-ttu-id="ab10c-190">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-190">Vector2</span></span>|
|<span data-ttu-id="ab10c-191">CenterPoint.x、y、z</span><span class="sxs-lookup"><span data-stu-id="ab10c-191">CenterPoint.x, y, z</span></span>|<span data-ttu-id="ab10c-192">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-192">Scalar</span></span>|
|<span data-ttu-id="ab10c-193">CenterPoint.xy、xz、yz</span><span class="sxs-lookup"><span data-stu-id="ab10c-193">CenterPoint.xy, xz, yz</span></span>|<span data-ttu-id="ab10c-194">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-194">Vector2</span></span>|
|<span data-ttu-id="ab10c-195">Offset.x、y、z</span><span class="sxs-lookup"><span data-stu-id="ab10c-195">Offset.x, y, z</span></span>|<span data-ttu-id="ab10c-196">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-196">Scalar</span></span>|
|<span data-ttu-id="ab10c-197">Offset.xy、xz、yz</span><span class="sxs-lookup"><span data-stu-id="ab10c-197">Offset.xy, xz, yz</span></span>|<span data-ttu-id="ab10c-198">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-198">Vector2</span></span>|
|<span data-ttu-id="ab10c-199">RotationAxis.x、y、z</span><span class="sxs-lookup"><span data-stu-id="ab10c-199">RotationAxis.x, y, z</span></span>|<span data-ttu-id="ab10c-200">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-200">Scalar</span></span>|
|<span data-ttu-id="ab10c-201">RotationAxis.xy、xz、yz</span><span class="sxs-lookup"><span data-stu-id="ab10c-201">RotationAxis.xy, xz, yz</span></span>|<span data-ttu-id="ab10c-202">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-202">Vector2</span></span>|
|<span data-ttu-id="ab10c-203">Scale.x、y、z</span><span class="sxs-lookup"><span data-stu-id="ab10c-203">Scale.x, y, z</span></span>|<span data-ttu-id="ab10c-204">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-204">Scalar</span></span>|
|<span data-ttu-id="ab10c-205">Scale.xy、xz、yz</span><span class="sxs-lookup"><span data-stu-id="ab10c-205">Scale.xy, xz, yz</span></span>|<span data-ttu-id="ab10c-206">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-206">Vector2</span></span>|
|<span data-ttu-id="ab10c-207">Size.x、y</span><span class="sxs-lookup"><span data-stu-id="ab10c-207">Size.x, y</span></span>|<span data-ttu-id="ab10c-208">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-208">Scalar</span></span>|
|<span data-ttu-id="ab10c-209">Size.xy</span><span class="sxs-lookup"><span data-stu-id="ab10c-209">Size.xy</span></span>|<span data-ttu-id="ab10c-210">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-210">Vector2</span></span>|
|<span data-ttu-id="ab10c-211">TransformMatrix._11.TransformMatrix._NN、</span><span class="sxs-lookup"><span data-stu-id="ab10c-211">TransformMatrix._11 ... TransformMatrix._NN,</span></span>|<span data-ttu-id="ab10c-212">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-212">Scalar</span></span>|
|<span data-ttu-id="ab10c-213">TransformMatrix._11_12 ... TransformMatrix._NN_NN</span><span class="sxs-lookup"><span data-stu-id="ab10c-213">TransformMatrix._11_12 ... TransformMatrix._NN_NN</span></span>|<span data-ttu-id="ab10c-214">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-214">Vector2</span></span>|
|<span data-ttu-id="ab10c-215">TransformMatrix._11_12_13 ... TransformMatrix._NN_NN_NN</span><span class="sxs-lookup"><span data-stu-id="ab10c-215">TransformMatrix._11_12_13 ... TransformMatrix._NN_NN_NN</span></span>|<span data-ttu-id="ab10c-216">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-216">Vector3</span></span>|
|<span data-ttu-id="ab10c-217">TransformMatrix._11_12_13_14</span><span class="sxs-lookup"><span data-stu-id="ab10c-217">TransformMatrix._11_12_13_14</span></span>|<span data-ttu-id="ab10c-218">Vector4</span><span class="sxs-lookup"><span data-stu-id="ab10c-218">Vector4</span></span>|
|<span data-ttu-id="ab10c-219">Color\*</span><span class="sxs-lookup"><span data-stu-id="ab10c-219">Color\*</span></span>|<span data-ttu-id="ab10c-220">Colors (Windows.UI)</span><span class="sxs-lookup"><span data-stu-id="ab10c-220">Colors (Windows.UI)</span></span>|

<span data-ttu-id="ab10c-221">\*Brush プロパティの Color サブチャネルのアニメーション化は少し異なります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-221">\*Animating the Color subchannel of the Brush property is a bit different.</span></span> <span data-ttu-id="ab10c-222">StartAnimation() を Visual.Brush にアタッチし、アニメーション化するプロパティをパラメーターで "Color" として宣言します </span><span class="sxs-lookup"><span data-stu-id="ab10c-222">You attach StartAnimation() to the Visual.Brush, and declare the property to animate in the parameter as "Color".</span></span>
<span data-ttu-id="ab10c-223">(色のアニメーション化については後で詳しく説明します)</span><span class="sxs-lookup"><span data-stu-id="ab10c-223">(More details about animating color discussed later)</span></span>

## <a name="property-sets-and-effects"></a><span data-ttu-id="ab10c-224">プロパティ セットと効果</span><span class="sxs-lookup"><span data-stu-id="ab10c-224">Property Sets and Effects</span></span>

<span data-ttu-id="ab10c-225">[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) と InsetClip のプロパティをアニメーション化するだけでなく、PropertySet や Effect のプロパティをアニメーション化することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-225">In addition to animating properties of [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) and InsetClip, you are also able to animate properties in a PropertySet or an Effect.</span></span>
<span data-ttu-id="ab10c-226">プロパティ セットの場合は、プロパティを定義し、コンポジションのプロパティ セットに格納します。このプロパティは、後でアニメーションのターゲットにすることができます (同時に別のアニメーションで参照することもできます)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-226">For property sets, you define a property and store it in a Composition Property Set – that property can later be the target of an animation (and also be referenced simultaneously in another).</span></span> <span data-ttu-id="ab10c-227">これについては、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-227">This will be discussed in more detail in the following sections.</span></span>

<span data-ttu-id="ab10c-228">効果の場合は、コンポジション効果 API を使ってグラフィック効果を定義できます (詳しくは、「[効果の概要](./composition-effects.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-228">For Effects, you are able to define graphical effects using the Composition Effects APIs (See here for the [Effects Overview](./composition-effects.md).</span></span>
<span data-ttu-id="ab10c-229">効果をできることに加えて、効果のプロパティ値をアニメーション化することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-229">In addition to defining Effects, you are also able to animate the property values of the Effect.</span></span>
<span data-ttu-id="ab10c-230">これを行うには、スプライト ビジュアルの Brush プロパティのプロパティ コンポーネントをターゲットに設定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-230">This is done by targeting the properties component of the Brush property on Sprite Visuals.</span></span>

## <a name="quick-formula-getting-started-with-composition-animations"></a><span data-ttu-id="ab10c-231">早わかり: コンポジション アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="ab10c-231">Quick Formula: Getting Started with Composition Animations</span></span>

<span data-ttu-id="ab10c-232">さまざまな種類のアニメーションを作成および使用する方法について詳しい説明に入る前に、コンポジション アニメーションを作成する方法について簡単な概要を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-232">Before diving into the details on how to construct and use the different types of animations, below is a quick, high level formula for how to put together Composition Animations.</span></span>

1. <span data-ttu-id="ab10c-233">コンポジターを取得します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-233">Get the compositor.</span></span> <span data-ttu-id="ab10c-234">これは、ページまたはアニメーション化する FrameworkElement から取得できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-234">This can be either from the page or the FrameworkElement you are animating on.</span></span>
1. <span data-ttu-id="ab10c-235">アニメーションのための新しいオブジェクトを作成します。これは、キー フレーム アニメーションまたは数式アニメーションです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-235">Create a new object for your animation – this will either be a KeyFrame or Expression Animation.</span></span>
    * <span data-ttu-id="ab10c-236">キー フレーム アニメーションの場合は、アニメーション化するプロパティの型と一致する型のキー フレーム アニメーションを作成していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-236">For KeyFrame animations, make sure you create a KeyFrame Animation type that matches the type of property you want to animate.</span></span>
    * <span data-ttu-id="ab10c-237">数式アニメーションの型は 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-237">There is only a single type of Expression Animation.</span></span>
1. <span data-ttu-id="ab10c-238">アニメーションのコンテンツを定義します。キー フレームを挿入するか、または数式の文字列を定義します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-238">Define the content for animation – Insert your Keyframes or define the Expression string</span></span>
    * <span data-ttu-id="ab10c-239">キー フレーム アニメーションでは、キー フレームの値が、アニメーション化するプロパティと同じ型であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-239">For KeyFrame animations, make sure the value of your KeyFrames are the same type as the property you want to animate.</span></span>
    * <span data-ttu-id="ab10c-240">数式アニメーションでは、数式の文字列が、アニメーション化するプロパティと同じ型に解決されることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-240">For Expression animations, make sure your Expression string will resolve to the same type as the property you want to animate.</span></span>
1. <span data-ttu-id="ab10c-241">アニメーション化するプロパティを持つ [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) でアニメーションを開始します。StartAnimation を呼び出して、アニメーション化するプロパティの名前 (文字列形式) とアニメーションのオブジェクトをパラメーターとして含めます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-241">Start your animation on the [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) whose property you want to animate – call StartAnimation and include as parameters:   the name of the property you want to animate (in string form) and the object for your animation.</span></span>

```cs
// KeyFrame Animation Example to target Opacity property
// Step 1 - Get the compositor
_compositor = ElementCompositionPreview.GetElementVisual(this).Compositor;

// Step 2 - Create your animation object
var animation = _compositor.CreateScalarKeyFrameAnimation();

// Step 3 - Define Content
animation.Duration = TimeSpan.FromSeconds(1);
animation.InsertKeyFrame(1f, 0.2f);

// Step 4 - Attach animation to Visual property and start animation
_targetVisual.StartAnimation(nameof(Visual.Opacity), animation);

// Expression Animation Example to target Opacity property
// Step 2 - Create your animation object
var expression = _compositor.CreateExpressionAnimation();
// Step 3 - Define Content (you can also define the string as part of the expression object
// declaration)
expression.Expression = "targetVisual.Offset.X / windowWidth";
expression.SetReferenceParameter("targetVisual", _target);
expression.SetScalarParameter("windowWidth", _xSizeWindow);
// Step 4 - Attach animation to Visual property and start animation
_targetVisual.StartAnimation("Opacity", expression);

```

## <a name="using-keyframe-animations"></a><span data-ttu-id="ab10c-242">キー フレーム アニメーションの使用</span><span class="sxs-lookup"><span data-stu-id="ab10c-242">Using KeyFrame Animations</span></span>

<span data-ttu-id="ab10c-243">キー フレーム アニメーションは時間に基づくアニメーションで、1 つまたは複数のキー フレームを使って時間の経過と共にアニメーション化された値を変更する方法を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-243">KeyFrame Animations are time-based animations that use one or more key frames to specify how the animated value should change over time.</span></span>
<span data-ttu-id="ab10c-244">フレームはマーカーまたは制御点を表し、アニメーション化された値が特定の時点でどのようになるかを定義できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-244">The frames represent markers or control points, allowing you to define what the animated value should be at a specific time.</span></span>

### <a name="creating-your-animation-and-defining-keyframes"></a><span data-ttu-id="ab10c-245">アニメーションの作成とキー フレームの定義</span><span class="sxs-lookup"><span data-stu-id="ab10c-245">Creating your animation and defining KeyFrames</span></span>

<span data-ttu-id="ab10c-246">キー フレーム アニメーションを作成するには、アニメーション化するプロパティの型に関連付けられたコンポジター オブジェクトのコンストラクター メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="ab10c-246">To construct a KeyFrame Animation, use the constructor method of your Compositor object that correlates to the type of the property you wish to animate.</span></span>
<span data-ttu-id="ab10c-247">キー フレーム アニメーションには、次のようなさまざまな型があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-247">The different types of KeyFrame Animation are:</span></span>

* <span data-ttu-id="ab10c-248">ColorKeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="ab10c-248">ColorKeyFrameAnimation</span></span>
* <span data-ttu-id="ab10c-249">QuaternionKeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="ab10c-249">QuaternionKeyFrameAnimation</span></span>
* <span data-ttu-id="ab10c-250">ScalarKeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="ab10c-250">ScalarKeyFrameAnimation</span></span>
* <span data-ttu-id="ab10c-251">Vector2KeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="ab10c-251">Vector2KeyFrameAnimation</span></span>
* <span data-ttu-id="ab10c-252">Vector3KeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="ab10c-252">Vector3KeyFrameAnimation</span></span>
* <span data-ttu-id="ab10c-253">Vector4KeyFrameAnimation</span><span class="sxs-lookup"><span data-stu-id="ab10c-253">Vector4KeyFrameAnimation</span></span>

<span data-ttu-id="ab10c-254">Vector3 キー フレーム アニメーションを作成する例:</span><span class="sxs-lookup"><span data-stu-id="ab10c-254">An example that creates a Vector3 KeyFrame Animation:</span></span>

```cs
var animation = _compositor.CreateVector3KeyFrameAnimation();
```

<span data-ttu-id="ab10c-255">各キー フレーム アニメーションは、2 つのコンポーネント (オプションで第 3 のコンポーネント) を定義する個々のキー フレーム セグメントを挿入することによって作成されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-255">Each KeyFrame animation is constructed by inserting individual KeyFrame segments that define two components (with an optional third)</span></span>

* <span data-ttu-id="ab10c-256">時間: 正規化されたキー フレームの進行状況 (0.0 ～ 1.0)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-256">Time: normalized progress state of the KeyFrame between 0.0 – 1.0.</span></span>
* <span data-ttu-id="ab10c-257">値: 特定の時間状態でのアニメーション化する値の特定の値。</span><span class="sxs-lookup"><span data-stu-id="ab10c-257">Value: specific value of the animating value at the time state.</span></span>
* <span data-ttu-id="ab10c-258">(省略可能) イージング関数: 前のキー フレームと現在のキー フレームの間の補間を記述する関数 (このトピックで後で説明します)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-258">(Optional) Easing function: function to describe interpolation between previous and current KeyFrame (discussed later in this topic).</span></span>

<span data-ttu-id="ab10c-259">アニメーションの中間点にキー フレームを挿入する例:</span><span class="sxs-lookup"><span data-stu-id="ab10c-259">An example that inserts a KeyFrame at the halfway point of the animation:</span></span>

```cs
animation.InsertKeyFrame(0.5f, new Vector3(50.0f, 80.0f, 0.0f));
```

<span data-ttu-id="ab10c-260">**注:** キー フレーム アニメーションを使って色をアニメーション化する場合は、さらにいくつかの事項に注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-260">**Note:** When animating color with KeyFrame Animations, there are a few additional things to keep in mind:</span></span>

1. <span data-ttu-id="ab10c-261">StartAnimation を [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) ではなく Visual.Brush にアタッチし、アニメーション化するプロパティのパラメーターとして **Color** を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-261">You attach StartAnimation to the Visual.Brush, instead of [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx), with **Color** as the property parameter you wish to animate.</span></span>
1. <span data-ttu-id="ab10c-262">キー フレームの "値" コンポーネントは、Windows.UI 名前空間の Colors オブジェクトによって定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-262">The "value" component of the KeyFrame is defined by the Colors object off of the Windows.UI namespace.</span></span>
1. <span data-ttu-id="ab10c-263">InterpolationColorSpace プロパティを設定することによって、補間を行う色空間を定義できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-263">You have the option to define the color space that the interpolation will go through by setting the InterpolationColorSpace property.</span></span> <span data-ttu-id="ab10c-264">表示される値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-264">Possible values include:</span></span>
    * <span data-ttu-id="ab10c-265">CompositionColorSpace.Rgb</span><span class="sxs-lookup"><span data-stu-id="ab10c-265">CompositionColorSpace.Rgb</span></span>
    * <span data-ttu-id="ab10c-266">CompositionColorSpace.Hsl</span><span class="sxs-lookup"><span data-stu-id="ab10c-266">CompositionColorSpace.Hsl</span></span>

## <a name="keyframe-animation-properties"></a><span data-ttu-id="ab10c-267">キー フレーム アニメーションのプロパティ</span><span class="sxs-lookup"><span data-stu-id="ab10c-267">KeyFrame Animation Properties</span></span>

<span data-ttu-id="ab10c-268">キー フレーム アニメーションと個々のキー フレームを定義すると、アニメーションの複数のプロパティを定義できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-268">Once you've defined your KeyFrame Animation and the individual KeyFrames, you are able to define multiple properties off of your animation:</span></span>

* <span data-ttu-id="ab10c-269">DelayTime: StartAnimation() が呼び出されてからアニメーションが開始されるまでの時間。</span><span class="sxs-lookup"><span data-stu-id="ab10c-269">DelayTime – time before an animation starts after StartAnimation() is called.</span></span>
* <span data-ttu-id="ab10c-270">Duration: アニメーションの継続時間。</span><span class="sxs-lookup"><span data-stu-id="ab10c-270">Duration – duration of the animation.</span></span>
* <span data-ttu-id="ab10c-271">IterationBehavior: アニメーションの繰り返し動作の回数または無制限。</span><span class="sxs-lookup"><span data-stu-id="ab10c-271">IterationBehavior – count or infinite repeat behavior for an animation.</span></span>
* <span data-ttu-id="ab10c-272">IterationCount: キー フレーム アニメーションが繰り返される有限の回数。</span><span class="sxs-lookup"><span data-stu-id="ab10c-272">IterationCount – number of finite times a KeyFrame Animation will repeat.</span></span>
* <span data-ttu-id="ab10c-273">KeyFrame Count: 特定のキー フレーム アニメーションのキー フレームの数。</span><span class="sxs-lookup"><span data-stu-id="ab10c-273">KeyFrame Count – read of how many KeyFrames in a particular KeyFrame Animation.</span></span>
* <span data-ttu-id="ab10c-274">StopBehavior: StopAnimation が呼び出されたときのアニメーションのプロパティ値の動作を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-274">StopBehavior – specifies the behavior of an animating property value when StopAnimation is called.</span></span>
* <span data-ttu-id="ab10c-275">Direction: アニメーションの再生方向を指定する。</span><span class="sxs-lookup"><span data-stu-id="ab10c-275">Direction – specifies the direction of the animation for playback.</span></span>

<span data-ttu-id="ab10c-276">アニメーションの継続時間を 5 秒間に設定する例:</span><span class="sxs-lookup"><span data-stu-id="ab10c-276">An example that sets the Duration of the animation to 5 seconds:</span></span>

```cs
animation.Duration = TimeSpan.FromSeconds(5);
```

## <a name="easing-functions"></a><span data-ttu-id="ab10c-277">イージング関数</span><span class="sxs-lookup"><span data-stu-id="ab10c-277">Easing Functions</span></span>

<span data-ttu-id="ab10c-278">イージング関数 (CompositionEasingFunction) は、前のキー フレーム値から現在のキー フレーム値への中間値の進行状況を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-278">Easing functions (CompositionEasingFunction) indicate how intermediate values progress from the previous key frame value to the current key frame value.</span></span> <span data-ttu-id="ab10c-279">キーフレームのイージング関数を指定しない場合、既定の曲線が使用されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-279">If you do not provide an easing function for the KeyFrame, a default curve will be used.</span></span>

<span data-ttu-id="ab10c-280">3 種類のイージング関数がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-280">Three kinds of easing functions are supported:</span></span>

* <span data-ttu-id="ab10c-281">線形</span><span class="sxs-lookup"><span data-stu-id="ab10c-281">Linear</span></span>
* <span data-ttu-id="ab10c-282">3 次ベジエ</span><span class="sxs-lookup"><span data-stu-id="ab10c-282">Cubic Bezier</span></span>
* <span data-ttu-id="ab10c-283">手順</span><span class="sxs-lookup"><span data-stu-id="ab10c-283">Step</span></span>

<span data-ttu-id="ab10c-284">3 次ベジエは、拡大/縮小が可能な滑らかな曲線を記述するためによく使用されるパラメトリック関数です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-284">Cubic Beziers are a parametric function frequently used to describe smooth curves that can be scaled.</span></span> <span data-ttu-id="ab10c-285">コンポジション キー フレーム アニメーションで使う場合は、Vector2 オブジェクトである 2 つの制御点を定義します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-285">When using with Composition KeyFrame Animations, you define two control points that are Vector2 objects.</span></span> <span data-ttu-id="ab10c-286">これらの制御点は、曲線の形状を定義するために使用されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-286">These control points are used to define the shape of the curve.</span></span> <span data-ttu-id="ab10c-287">[こちらのサイト](http://cubic-bezier.com/#0,-0.01,.48,.99)などのサイトで、次の 2 つの制御点で 3 次ベジエ曲線を作成する方法を視覚化してみることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-287">It is recommended to use similar sites such as [this](http://cubic-bezier.com/#0,-0.01,.48,.99) to visualize how the two control points construct the curve for a Cubic Bezier.</span></span>

<span data-ttu-id="ab10c-288">イージング関数を作成するには、Compositor オブジェクトのコンストラクター メソッドを利用します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-288">To create an easing function, utilize the constructor method off your Compositor object.</span></span> <span data-ttu-id="ab10c-289">次の 2 つの例では、線形イージング関数と基本的な 3 次ベジエ イージング関数を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-289">Two examples below that create a Linear easing function and a basic Cubic Bezier easing function.</span></span>

```cs
var linear = _compositor.CreateLinearEasingFunction();
var easeIn = _compositor.CreateCubicBezierEasingFunction(new Vector2(0.5f, 0.0f), new Vector2(1.0f, 1.0f));
var step = _compositor.CreateStepEasingFunction();
```

<span data-ttu-id="ab10c-290">イージング関数をキー フレームに追加するには、アニメーションにキー フレームを挿入するときに、3 番目のパラメーターを追加するだけです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-290">To add your easing function into your KeyFrame, simply add in the third parameter to the KeyFrame when inserting into the Animation.</span></span>

<span data-ttu-id="ab10c-291">キー フレームで easeIn イージング関数を追加する例:</span><span class="sxs-lookup"><span data-stu-id="ab10c-291">An example that adds in a easeIn easing function with the KeyFrame:</span></span>

```cs
animation.InsertKeyFrame(0.5f, new Vector3(50.0f, 80.0f, 0.0f), easeIn);
```

## <a name="starting-and-stopping-keyframe-animations"></a><span data-ttu-id="ab10c-292">キー フレーム アニメーションの開始と停止</span><span class="sxs-lookup"><span data-stu-id="ab10c-292">Starting and Stopping KeyFrame Animations</span></span>

<span data-ttu-id="ab10c-293">アニメーションとキー フレームを定義したら、アニメーションを接続できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-293">After you have defined your animation and KeyFrames, you are ready to hook up your animation.</span></span> <span data-ttu-id="ab10c-294">アニメーションを開始する場合、アニメーション化する [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx)、アニメーション化するターゲット プロパティ、アニメーションへの参照を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-294">When starting your animation, you specify the [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) to be animated, the target property to be animated and a reference to the animation.</span></span>
<span data-ttu-id="ab10c-295">これを行うには、StartAnimation() 関数を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-295">You do so by calling the StartAnimation() function.</span></span> <span data-ttu-id="ab10c-296">プロパティで StartAnimation() を呼び出すと、以前に実行されていたアニメーションは切断されて削除されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-296">Remember that calling StartAnimation() on a property will disconnect and remove any previously running animations.</span></span>
<span data-ttu-id="ab10c-297">**注:** アニメーション化するために選択したプロパティへの参照は、文字列の形式です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-297">**Note:** The reference to the property you choose to animate is in the form of a string.</span></span>

<span data-ttu-id="ab10c-298">[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) の Offset プロパティでアニメーションを設定して開始する例:</span><span class="sxs-lookup"><span data-stu-id="ab10c-298">An example that sets and starts an animation on the [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx)’s Offset property:</span></span>

```cs
targetVisual.StartAnimation("Offset", animation);
```

<span data-ttu-id="ab10c-299">サブ チャネル プロパティをターゲットにする場合は、アニメーション化するプロパティを定義する文字列にサブ チャネルを追加します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-299">If you want to target a sub channel property, you add the subchannel into the string defining the property you want to animate.</span></span>
<span data-ttu-id="ab10c-300">上記の例では、構文は StartAnimation ("Offset.X, animation2) に変換されます。ここで、animation2 は ScalarKeyFrameAnimation です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-300">In the examples above, the syntax would change to StartAnimation("Offset.X, animation2), where animation2 is a ScalarKeyFrameAnimation.</span></span>

<span data-ttu-id="ab10c-301">アニメーションを開始した後、アニメーションが終了する前に停止することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-301">After starting your animation, you also have the ability to stop it before it finishes.</span></span> <span data-ttu-id="ab10c-302">これを行うには、StopAnimation() 関数を使います。</span><span class="sxs-lookup"><span data-stu-id="ab10c-302">This is done by using the StopAnimation() function.</span></span>
<span data-ttu-id="ab10c-303">[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) の Offset プロパティでアニメーションを停止する例:</span><span class="sxs-lookup"><span data-stu-id="ab10c-303">An example that stops an animation on the [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx)’s Offset property:</span></span>

```cs
targetVisual.StopAnimation("Offset");
```

<span data-ttu-id="ab10c-304">明示的に停止されたときのアニメーションの動作を定義することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-304">You also have the ability to define the behavior of the animation when it is explicitly stopped.</span></span> <span data-ttu-id="ab10c-305">そのためには、アニメーションの StopBehavior プロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-305">To do so, you define the Stop Behavior property off your animation.</span></span> <span data-ttu-id="ab10c-306">次の 3 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-306">There are three options:</span></span>

* <span data-ttu-id="ab10c-307">LeaveCurrentValue: アニメーションは、アニメーション化されたプロパティの値をアニメーションの最後に計算された値としてマークします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-307">LeaveCurrentValue: The animation will mark the value of the animated property to be the last calculated value of the animation.</span></span>
* <span data-ttu-id="ab10c-308">SetToFinalValue: アニメーションは、アニメーション化されたプロパティの値を最後のキー フレームの値としてマークします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-308">SetToFinalValue: The animation will mark the value of the animated property to be the value of the final keyframe.</span></span>
* <span data-ttu-id="ab10c-309">SetToInitialValue: アニメーションは、アニメーション化されたプロパティの値を最初のキー フレームの値としてマークします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-309">SetToInitialValue: The animation will mark the value of the animated property to be the value of the first keyframe.</span></span>

<span data-ttu-id="ab10c-310">キー フレーム アニメーションの StopBehavior プロパティを設定する例:</span><span class="sxs-lookup"><span data-stu-id="ab10c-310">An example that sets the StopBehavior property for a KeyFrame Animation:</span></span>

```cs
animation.StopBehavior = AnimationStopBehavior.LeaveCurrentValue;
```

## <a name="animation-completion-events"></a><span data-ttu-id="ab10c-311">アニメーション完了イベント</span><span class="sxs-lookup"><span data-stu-id="ab10c-311">Animation Completion Events</span></span>

<span data-ttu-id="ab10c-312">キー フレーム アニメーションでは、アニメーションのバッチを使って、選択したアニメーション (またはアニメーションのグループ) の完了時点を集計できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-312">With KeyFrame Animations, you can use Animation Batches to aggregate when a select animation (or group of animations) have completed.</span></span>
<span data-ttu-id="ab10c-313">キー フレーム アニメーションの完了イベントのみを一括処理できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-313">Only KeyFrame animation completion events can be batched.</span></span> <span data-ttu-id="ab10c-314">数式アニメーションには、明確な終わりがないため、完了イベントは発生しません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-314">Expressions do not have a definite end so they do not fire a completion event.</span></span>
<span data-ttu-id="ab10c-315">バッチ内の数式アニメーションが開始された場合、アニメーションは期待どおりに実行され、バッチが実行されるタイミングには影響しません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-315">If an Expression animation is started within a batch, the animation will execute as expected and it will not affect when the batch fires.</span></span>

<span data-ttu-id="ab10c-316">バッチ完了イベントは、バッチ内のすべてのアニメーションが完了したときに発生します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-316">A batch completion event fires when all animations within the batch have completed.</span></span>
<span data-ttu-id="ab10c-317">バッチのイベントが発生するまでの時間は、バッチ内の最も長い、または最も遅延したアニメーションに依存します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-317">The time it takes for a batch’s event to fire depends on the longest or most delayed animation in the batch.</span></span>
<span data-ttu-id="ab10c-318">終了状態の集計は、他の作業をスケジュールするために、選択したアニメーションのグループが完了するタイミングを把握する必要がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-318">Aggregating end states is useful when you need to know when groups of select animations complete in order to schedule some other work.</span></span>

<span data-ttu-id="ab10c-319">完了イベントが発生すると、バッチは破棄されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-319">Batches will dispose once the completion event is fired.</span></span> <span data-ttu-id="ab10c-320">また、いつでも Dispose() を呼び出して、早期にリソースを解放することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-320">You can also call Dispose() at any time to release the resource early.</span></span>
<span data-ttu-id="ab10c-321">バッチ アニメーションが早期に終了し、完了イベントを取得する必要がない場合は、手動でバッチ オブジェクトを破棄することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-321">You may want to manually dispose the batch object if a batched animation is ended early and you do not wish to pick up the completion event.</span></span>
<span data-ttu-id="ab10c-322">アニメーションが中断または取り消された場合、完了イベントを発生し、設定されているバッチにカウントされます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-322">If an animation is interrupted or canceled the completion event will fire and count towards the batch it was set in.</span></span>
<span data-ttu-id="ab10c-323">詳しくは、[Windows/コンポジションに関する GitHub](http://go.microsoft.com/fwlink/p/?LinkId=789439) にある Animation_Batch SDK サンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-323">This is demonstrated in the Animation_Batch SDK sample on the [Windows/Composition GitHub](http://go.microsoft.com/fwlink/p/?LinkId=789439).</span></span>

## <a name="scoped-batches"></a><span data-ttu-id="ab10c-324">スコープ指定されたバッチ</span><span class="sxs-lookup"><span data-stu-id="ab10c-324">Scoped batches</span></span>

<span data-ttu-id="ab10c-325">アニメーションの特定のグループを集計したり、1 つのアニメーションの完了イベントをターゲットとするには、スコープ指定されたバッチを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-325">To aggregate a specific group of animations or target a single animation’s completion event, you create a Scoped batch.</span></span>

```cs
CompositionScopedBatch myScopedBatch = _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
```

<span data-ttu-id="ab10c-326">スコープ指定されたバッチを作成した後、開始されたすべてのアニメーションは、Suspend または End 関数を使って、明示的に中断または停止されるまで集計されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-326">After creating a Scoped batch, all started animations aggregate until the batch is explicitly suspended or ended using the Suspend or End function.</span></span>

<span data-ttu-id="ab10c-327">Suspend 関数を呼び出すと、Resume が呼び出されるまで、アニメーションの終了状態の集計は停止します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-327">Calling the Suspend function stops aggregating animates end states until Resume is called.</span></span> <span data-ttu-id="ab10c-328">これにより、特定のバッチから明示的にコンテンツを除外することができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-328">This allows you to explicitly exclude content from a given batch.</span></span>

<span data-ttu-id="ab10c-329">次の例では、VisualA の Offset プロパティをターゲットとするアニメーションは、バッチに含まれていません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-329">In the example below, the animation targeting the Offset property of VisualA will not be included in the batch:</span></span>

```cs
myScopedBatch.Suspend();
VisualA.StartAnimation("Offset", myAnimation);
myScopeBatch.Resume();
```

<span data-ttu-id="ab10c-330">バッチを完了するには、End() を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-330">In order to complete your batch you must call End().</span></span> <span data-ttu-id="ab10c-331">End を呼び出さない場合、バッチは開いたまま、オブジェクトの収集を継続します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-331">Without an End call, the batch will remain open forever-collecting objects.</span></span>

<span data-ttu-id="ab10c-332">次のコード スニペットと図は、バッチで終了状態を追跡するためにアニメーションを集計する例を示しています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-332">The following code snippet and diagram below shows an example of how the Batch will aggregate animations to track end states.</span></span>
<span data-ttu-id="ab10c-333">この例では、アニメーション 1、3、4 はこのバッチにより終了状態が追跡されますが、アニメーション 2 の終了状態は追跡されません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-333">Note that in this example, Animations 1, 3, and 4 will have end states tracked by this Batch, but Animation 2 will not.</span></span>

```cs
myScopedBatch.End();
CompositionScopedBatch myScopedBatch =  _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
// Start Animation1
[…]
myScopedBatch.Suspend();
// Start Animation2
[…]
myScopedBatch.Resume();
// Start Animation3
[…]
// Start Animation4
[…]
myScopedBatch.End();
```

![スコープ指定されたバッチにはアニメーション 1、アニメーション 3、アニメーション 4 が含まれ、アニメーション 2 はスコープ指定されたバッチから除外されます。](./images/composition-scopedbatch.png)

## <a name="batching-a-single-animations-completion-event"></a><span data-ttu-id="ab10c-335">1 つのアニメーションの完了イベントを一括処理</span><span class="sxs-lookup"><span data-stu-id="ab10c-335">Batching a single animation's completion event</span></span>

<span data-ttu-id="ab10c-336">1 つのアニメーションが終了するタイミングを判断する場合、ターゲットのアニメーションのみを含むスコープ指定されたバッチを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-336">If you want to know when a single animation ends, you need to create a Scoped batch that will include just the animation you are targeting.</span></span> <span data-ttu-id="ab10c-337">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-337">For example:</span></span>

```cs
CompositionScopedBatch myScopedBatch =  _compositor.CreateScopedBatch(CompositionBatchTypes.Animation);
Visual.StartAnimation("Opacity", myAnimation);
myScopedBatch.End();
```

## <a name="retrieving-a-batchs-completion-event"></a><span data-ttu-id="ab10c-338">バッチの完了イベントの取得</span><span class="sxs-lookup"><span data-stu-id="ab10c-338">Retrieving a batch's completion event</span></span>

<span data-ttu-id="ab10c-339">アニメーションまたは複数のアニメーションを一括処理する場合、バッチの完了イベントは同様に取得されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-339">When batching an animation or multiple animations, you will retrieve the batch’s completion event the same way.</span></span>
<span data-ttu-id="ab10c-340">ターゲットのバッチの Completed イベントのイベント処理メソッドを登録します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-340">You register the event-handling method for the Completed event of the targeted batch.</span></span>

```cs
myScopedBatch.Completed += OnBatchCompleted;
```

## <a name="batch-states"></a><span data-ttu-id="ab10c-341">バッチの状態</span><span class="sxs-lookup"><span data-stu-id="ab10c-341">Batch states</span></span>

<span data-ttu-id="ab10c-342">既存のバッチの状態を判断するには、IsActive と IsEnded の 2 つのプロパティを使用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-342">There are two properties you can use to determine the state of an existing batch; IsActive and IsEnded.</span></span>

<span data-ttu-id="ab10c-343">IsActive プロパティは、ターゲットのバッチが開いており、アニメーションを集計している場合、true を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-343">The IsActive property returns true if a targeted batch is open to aggregating animations.</span></span> <span data-ttu-id="ab10c-344">バッチが中断または終了している場合、IsActive は false を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-344">IsActive will return false when a batch is suspended or ended.</span></span>

<span data-ttu-id="ab10c-345">IsEnded プロパティは、特定のバッチにアニメーションを追加できない場合に true を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-345">The IsEnded property returns true when you cannot add an animation to that specific batch.</span></span> <span data-ttu-id="ab10c-346">特定のバッチについて End() を明示的に呼び出すと、バッチは終了します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-346">A batch will be ended when you call explicitly call End() for a specific batch.</span></span>

## <a name="using-expression-animations"></a><span data-ttu-id="ab10c-347">数式アニメーションの使用</span><span class="sxs-lookup"><span data-stu-id="ab10c-347">Using Expression Animations</span></span>

<span data-ttu-id="ab10c-348">数式アニメーションは、Windows 10 の 11 月の更新プログラム (10586) で導入された新しい種類のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-348">Expression Animations are a new type of animation introduced with the Windows 10 November Update (10586).</span></span>
<span data-ttu-id="ab10c-349">大まかに言うと、数式アニメーションは、離散値と他のコンポジション オブジェクトのプロパティとの数学的な方程式/関係に基づいています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-349">At a high level, Expression Animations are based on a mathematical equation/relationship between discrete values and references to other Composition object properties.</span></span>
<span data-ttu-id="ab10c-350">補間関数 (3 次ベジエ、4 次、5 次など) を使用して時間の経過と共に変化する値を指定するキー フレーム アニメーションとは対照的に、数式アニメーションでは、数学方程式を使用して、各フレームでアニメーション化される値の計算方法を定義します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-350">In contrast to KeyFrame Animations that use an interpolator function (Cubic Bezier, Quad, Quintic, etc.) to describe how the value changes over time, Expression Animations use a mathematical equation to define how the animated value is calculated each frame.</span></span>
<span data-ttu-id="ab10c-351">重要な点は、数式アニメーションでは期間が定義されないことです。数式アニメーションが開始されると、明示的に停止されるまで、数学方程式によってアニメーション化されるプロパティの値を決定して実行されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-351">It’s important to point out that Expression Animations do not have a defined duration – once started, they will run and use the mathematical equation to determine the value of the animating property until they are explicitly stopped.</span></span>

**<span data-ttu-id="ab10c-352">それでは、数式アニメーションはどのような場合に役立つのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="ab10c-352">So why are Expression Animations useful?</span></span>**

<span data-ttu-id="ab10c-353">数式アニメーションの真価は、他のオブジェクトのパラメーターやプロパティへの参照を含む数学的な関係を作成できることにあります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-353">The real power of Expression Animations comes from their ability to create a mathematical relationship that includes references to parameters or properties on other objects.</span></span>
<span data-ttu-id="ab10c-354">つまり、他のコンポジション オブジェクトのプロパティの値、ローカル変数、コンポジション プロパティ セットの共有値を参照する方程式を使用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-354">This means you can have an equation referencing values of properties on other Composition objects, local variables, or even shared values in Composition Property Sets.</span></span>
<span data-ttu-id="ab10c-355">この参照モデルと、方程式が各フレームで評価されることにより、方程式を定義する値が変化すると、方程式の出力も変化します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-355">Because of this reference model, and that the equation is evaluated every frame, if the values that define an equation change, so will the output of the equation.</span></span>
<span data-ttu-id="ab10c-356">これは、値が不連続で定義済みである従来のキー フレーム アニメーションに比べて大きな可能性をもたらします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-356">This opens up bigger possibilities beyond traditional KeyFrame Animations where values must be discrete and pre-defined.</span></span>
<span data-ttu-id="ab10c-357">たとえば、数式アニメーションを使うと、固定ヘッダーや視差などのエクスペリエンスを簡単に記述できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-357">For example, experiences like Sticky Headers and Parallax can be easily described using Expression Animations.</span></span>

<span data-ttu-id="ab10c-358">**注:** "数式" や "数式文字列" という用語は、数式アニメーション オブジェクトを定義する数学方程式を指す用語として使用されています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-358">**Note:** We use the terms "Expression" or "Expression String" as reference to your mathematical equation that defines your Expression Animation object.</span></span>

## <a name="creating-and-attaching-your-expression-animation"></a><span data-ttu-id="ab10c-359">数式アニメーションの作成とアタッチ</span><span class="sxs-lookup"><span data-stu-id="ab10c-359">Creating and Attaching your Expression Animation</span></span>

<span data-ttu-id="ab10c-360">数式アニメーションを作成するための構文について説明する前に、いくつかの基本原則を示します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-360">Before we jump into the syntax of creating Expression Animations, there are a few core principles to mention:</span></span>

* <span data-ttu-id="ab10c-361">数式アニメーションでは、定義済みの数学方程式を使って、各フレームでアニメーション化するプロパティの値を決定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-361">Expression Animations use a defined mathematical equation to determine the value of the animating property every frame.</span></span>
* <span data-ttu-id="ab10c-362">数学方程式は文字列として数式に入力されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-362">The mathematical equation is inputted into the Expression as a string.</span></span>
* <span data-ttu-id="ab10c-363">数学方程式の出力は、アニメーション化するプロパティと同じ型に解決される必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-363">The output of the mathematical equation must resolve to the same type as the property you plan to animate.</span></span> <span data-ttu-id="ab10c-364">型が一致しない場合、数式を計算するときにエラーが出力されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-364">If they don't match, you will get an error when the Expression gets calculated.</span></span> <span data-ttu-id="ab10c-365">方程式が NaN (数値/0) に解決される場合、システムでは前回計算された値が使用されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-365">If your equation resolves to Nan (number/0), the system will use the last previously calculated value.</span></span>
* <span data-ttu-id="ab10c-366">数式アニメーションの*有効期間は無期限*であるため、停止するまで継続して実行されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-366">Expression Animations have an *infinite lifetime* – they will continue to run until they are stopped.</span></span>

<span data-ttu-id="ab10c-367">数式アニメーションを作成するには、コンポジション オブジェクトのコンストラクターを使って、数学的な式を指定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-367">To create your Expression Animation, simply use the constructor off your Composition object, where you define your Mathematical expression.</span></span>

<span data-ttu-id="ab10c-368">2 つのスカラー値を合計する非常に基本的な数式が定義されているコンストラクターの例を以下に示します (次のセクションでは、より複雑な数式について説明します)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-368">An example of the constructor where a very basic expression is defined that sums two Scalar values together (We will dive into more complicated expressions in the next section):</span></span>

```cs
var expression = _compositor.CreateExpressionAnimation("0.2 + 0.3");
```

<span data-ttu-id="ab10c-369">アニメーションを実行するには、キー フレーム アニメーションと同様に、数式アニメーション定義した後、アニメーションを Visual にアタッチし、アニメーション化するプロパティを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-369">Similar to KeyFrame Animations, once you have defined your Expression Animation, you need to attach it to the Visual and declare the property you wish the animation to animate.</span></span>
<span data-ttu-id="ab10c-370">ここでは、引き続き前の例を使って、数式アニメーションを [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) の Opacity プロパティ (Scalar 型) にアタッチします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-370">Below, we continue with the above example and attach our Expression Animation to the [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx)’s Opacity property (A Scalar type):</span></span>

```cs
targetVisual.StartAnimation("Opacity", expression);
```

## <a name="components-of-your-expression-string"></a><span data-ttu-id="ab10c-371">数式文字列の構成要素</span><span class="sxs-lookup"><span data-stu-id="ab10c-371">Components of your Expression String</span></span>

<span data-ttu-id="ab10c-372">前のセクションの例では、2 つの単純なスカラー値を合計しています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-372">The example in the previous section demonstrated two simple Scalar values being added together.</span></span>
<span data-ttu-id="ab10c-373">これは有効な数式の例ですが、数式を使ってできる処理の潜在的な可能性をすべて示しているとはいえません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-373">Although this is a valid example of Expressions, it does not fully demonstrate the potential of what you can do with Expressions.</span></span>
<span data-ttu-id="ab10c-374">前の例で注意すべき点の 1 つは、これらは離散値であるため、すべてのフレームでこの方程式は 0.5 に解決され、アニメーションの有効期間を通して変化しないということです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-374">One thing to note about the example above is that because these are discrete values, every frame the equation will resolve to 0.5 and never change throughout the lifetime of the animation.</span></span>
<span data-ttu-id="ab10c-375">数式の真価は、値が定期的または常時変化する数学的な関係を定義できることにあります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-375">The real potential of Expressions comes from defining a mathematical relationship in which the values could change periodically or all the time.</span></span>

<span data-ttu-id="ab10c-376">ここでは、このような種類の数式を構成する要素について説明します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-376">Let’s walk through the different pieces that can make up these types of Expressions.</span></span>

### <a name="operators-precedence-and-associativity"></a><span data-ttu-id="ab10c-377">演算子、優先順位、結合性</span><span class="sxs-lookup"><span data-stu-id="ab10c-377">Operators, Precedence and Associativity</span></span>

<span data-ttu-id="ab10c-378">数式文字列では、方程式のさまざまな構成要素間の数学的な関係を記述するために使用される標準的な演算子の使用がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-378">The Expression string supports usage of typical operators you would expect to describe mathematical relationships between different components of the equation:</span></span>

|<span data-ttu-id="ab10c-379">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="ab10c-379">Category</span></span>| <span data-ttu-id="ab10c-380">演算子</span><span class="sxs-lookup"><span data-stu-id="ab10c-380">Operators</span></span>|
|--------|-----------|
|<span data-ttu-id="ab10c-381">単項</span><span class="sxs-lookup"><span data-stu-id="ab10c-381">Unary</span></span>| -|
|<span data-ttu-id="ab10c-382">乗算</span><span class="sxs-lookup"><span data-stu-id="ab10c-382">Multiplicative</span></span>|<span data-ttu-id="ab10c-383">\* /</span><span class="sxs-lookup"><span data-stu-id="ab10c-383">\* /</span></span>|
|<span data-ttu-id="ab10c-384">加算</span><span class="sxs-lookup"><span data-stu-id="ab10c-384">Additive</span></span>|<span data-ttu-id="ab10c-385">+ -</span><span class="sxs-lookup"><span data-stu-id="ab10c-385">+ -</span></span>|
|<span data-ttu-id="ab10c-386">剰余</span><span class="sxs-lookup"><span data-stu-id="ab10c-386">Mod</span></span>| %|

<span data-ttu-id="ab10c-387">同様に、式を評価するときには、C# 言語の仕様で定義されている演算子の優先順位と結合性に準拠します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-387">Similarly, when the Expression is evaluated, it will adhere to operator precedence and associativity as defined in the C# Language specification.</span></span>
<span data-ttu-id="ab10c-388">言い換えると、演算子の基本的な順序に準拠します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-388">Put another way, it will adhere to basic order of operations.</span></span>

<span data-ttu-id="ab10c-389">次の例では、評価する場合、丸かっこが最初に解決された後、演算子の優先順位に基づいて方程式の残りの部分が解決されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-389">In the example below, when evaluated, the parentheses will be resolved first before resolving the rest of the equation based on order of operations:</span></span>

```cs
"(5.0 * (72.4 – 36.0) + 5.0" // (5.0 * 36.4 + 5) -> (182 + 5) -> 187
```

### <a name="property-parameters"></a><span data-ttu-id="ab10c-390">プロパティのパラメーター</span><span class="sxs-lookup"><span data-stu-id="ab10c-390">Property Parameters</span></span>

<span data-ttu-id="ab10c-391">プロパティのパラメーターは、数式アニメーションの最も強力な構成要素の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-391">Property parameters are one of the most powerful components of Expression Animations.</span></span>
<span data-ttu-id="ab10c-392">数式文字列では、[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx)、コンポジション プロパティ セット、他の C# オブジェクトなど、他のオブジェクトのプロパティ値を参照できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-392">In the expression string, you can reference values of properties from other objects such as [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx), Composition Property Set or other C# objects.</span></span>

<span data-ttu-id="ab10c-393">数式文字列でこれらを使用するには、数式アニメーションに対するパラメーターとして、参照を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-393">To use these in an Expression string, you simply need to define the references as parameters to the Expression Animation.</span></span>
<span data-ttu-id="ab10c-394">そのためには、数式で使用される文字列を実際のオブジェクトにマッピングします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-394">This is done by mapping the string used in the Expression to the actual object.</span></span> <span data-ttu-id="ab10c-395">これにより、数式を評価するときに、値を計算するために検査する対象がシステムで認識されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-395">This allows the system when evaluating the equation to know what to inspect to calculate the value.</span></span>
<span data-ttu-id="ab10c-396">数式に含めるオブジェクトの型と相互に関連するさまざまな型のパラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-396">There are different types of parameters that correlate to the type of the object you wish to include in the equation:</span></span>

|<span data-ttu-id="ab10c-397">型</span><span class="sxs-lookup"><span data-stu-id="ab10c-397">Type</span></span>|<span data-ttu-id="ab10c-398">パラメーターを作成する関数</span><span class="sxs-lookup"><span data-stu-id="ab10c-398">Function to create parameter</span></span>|
|----|------------------------------|
|<span data-ttu-id="ab10c-399">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-399">Scalar</span></span>|<span data-ttu-id="ab10c-400">SetScalarParameter(String ref, Scalar obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-400">SetScalarParameter(String ref, Scalar obj)</span></span>|
|<span data-ttu-id="ab10c-401">Vector</span><span class="sxs-lookup"><span data-stu-id="ab10c-401">Vector</span></span>|<span data-ttu-id="ab10c-402">SetVector2Parameter(String ref, Vector2 obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-402">SetVector2Parameter(String ref, Vector2 obj)</span></span><br/><span data-ttu-id="ab10c-403">SetVector3Parameter(String ref, Vector3 obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-403">SetVector3Parameter(String ref, Vector3 obj)</span></span><br/><span data-ttu-id="ab10c-404">SetVector4Parameter(String ref, Vector4 obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-404">SetVector4Parameter(String ref, Vector4 obj)</span></span>|
|<span data-ttu-id="ab10c-405">Matrix</span><span class="sxs-lookup"><span data-stu-id="ab10c-405">Matrix</span></span>|<span data-ttu-id="ab10c-406">SetMatrix3x2Parameter(String ref, Matrix3x2 obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-406">SetMatrix3x2Parameter(String ref, Matrix3x2 obj)</span></span><br/><span data-ttu-id="ab10c-407">SetMatrix4x4Parameter(String ref, Matrix4x4 obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-407">SetMatrix4x4Parameter(String ref, Matrix4x4 obj)</span></span>|
|<span data-ttu-id="ab10c-408">Quaternion</span><span class="sxs-lookup"><span data-stu-id="ab10c-408">Quaternion</span></span>|<span data-ttu-id="ab10c-409">SetQuaternionParameter(String ref, Quaternion obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-409">SetQuaternionParameter(String ref, Quaternion obj)</span></span>|
|<span data-ttu-id="ab10c-410">Color</span><span class="sxs-lookup"><span data-stu-id="ab10c-410">Color</span></span>|<span data-ttu-id="ab10c-411">SetColorParameter(String ref, Color obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-411">SetColorParameter(String ref, Color obj)</span></span>|
|<span data-ttu-id="ab10c-412">CompositionObject</span><span class="sxs-lookup"><span data-stu-id="ab10c-412">CompositionObject</span></span>|<span data-ttu-id="ab10c-413">SetReferenceParameter(String ref, Composition object obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-413">SetReferenceParameter(String ref, Composition object obj)</span></span>|
|<span data-ttu-id="ab10c-414">Boolean</span><span class="sxs-lookup"><span data-stu-id="ab10c-414">Boolean</span></span>| <span data-ttu-id="ab10c-415">SetBooleanParameter(String ref, Boolean obj)</span><span class="sxs-lookup"><span data-stu-id="ab10c-415">SetBooleanParameter(String ref, Boolean obj)</span></span>|

<span data-ttu-id="ab10c-416">次の例では、他の 2 つのコンポジションの [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) と基本的な System.Numerics Vector3 オブジェクトのオフセットを参照する数式アニメーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-416">In the example below, we create an Expression Animation that will reference the Offset of two other Composition [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx)s and a basic System.Numerics Vector3 object.</span></span>

```cs
var commonOffset = new Vector3(25.0, 17.0, 10.0);
var expression = _compositor.CreateExpressionAnimation("SomeOffset / ParentOffset + additionalOffset");
expression.SetVector3Parameter("SomeOffset", childVisual.Offset);
expression.SetVector3Parameter("ParentOffset", parentVisual.Offset);
expression.SetVector3Parameter("additionalOffset", commonOffset);
```

<span data-ttu-id="ab10c-417">さらに、前の説明と同じモデルを使用して、数式からプロパティ セット内の値を参照できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-417">Additionally, you can reference a value in a Property Set from an expression using the same model described above.</span></span>
<span data-ttu-id="ab10c-418">コンポジション プロパティ セットは、アニメーションで使用されるデータを格納するための便利な方法であり、他のコンポジション オブジェクトの有効期間に関連付けられていない、共有可能で再利用可能なデータを作成するのに便利です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-418">Composition Property Sets are a useful way to store data used by animations, and are useful for creating sharable, reusable data that isn’t tied to the lifetime of any other Composition objects.</span></span>
<span data-ttu-id="ab10c-419">プロパティ セットの値は、他のプロパティの参照に似た数式で参照できます </span><span class="sxs-lookup"><span data-stu-id="ab10c-419">Property Set values can be referenced in an expression similar to other property references.</span></span> <span data-ttu-id="ab10c-420">(プロパティ セットについては、後のセクションで詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-420">(Property Sets are discussed in more detail in a later section)</span></span>

<span data-ttu-id="ab10c-421">前の例を、ローカル変数ではなく、プロパティ セットを使用して commonOffset が定義されるように変更できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-421">We can modify the example directly above, such that a property set is used to define the commonOffset instead of a local variable:</span></span>

```cs
_sharedProperties = _compositor.CreatePropertySet();
_sharedProperties.InsertVector3("commonOffset", offset);
var expression = _compositor.CreateExpressionAnimation("SomeOffset / ParentOffset + sharedProperties.commonOffset");
expression.SetVector3Parameter("SomeOffset", childVisual.Offset);
expression.SetVector3Parameter("ParentOffset", parentVisual.Offset);
expression.SetReferenceParameter("sharedProperties", _sharedProperties);
```

<span data-ttu-id="ab10c-422">最後に、他のオブジェクトのプロパティを参照する場合、数式文字列で、または参照パラメーターの一部として、サブチャネル プロパティを参照することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-422">Finally, when referencing properties of other objects, it also possible to reference the subchannel properties either in the Expression string or as part of the reference parameter.</span></span>

<span data-ttu-id="ab10c-423">次の例では、2 つの [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) から Offset プロパティの x サブチャネルを参照します。まず数式文字列自体で参照し、次にパラメーター参照を作成するときに参照します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-423">In the example below, we reference the x subchannel of Offset properties from two [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx)s – one in the Expression string itself and the other when creating the parameter reference.</span></span>
<span data-ttu-id="ab10c-424">Offset の X コンポーネントを参照する場合、パラメーターの型を前の例のような Vector3 ではなく、Scalar パラメーターに変更していることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-424">Notice that when referencing the X component of Offset, we change our parameter type to a Scalar Parameter instead of a Vector3 like in the previous example:</span></span>

```cs
var expression = _compositor.CreateExpressionAnimation("xOffset/ ParentOffset.X");
expression.SetScalarParameter("xOffset", childVisual.Offset.X);
expression.SetVector3Parameter("ParentOffset", parentVisual.Offset);
```

### <a name="expression-helper-functions-and-constructors"></a><span data-ttu-id="ab10c-425">数式ヘルパー関数とコンストラクター</span><span class="sxs-lookup"><span data-stu-id="ab10c-425">Expression Helper Functions and Constructors</span></span>

<span data-ttu-id="ab10c-426">演算子やプロパティ パラメーターを使用できることに加えて、数学関数のリストを数式で使用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-426">In addition to having access to Operators and Property Parameters, you can leverage a list of mathematical functions to use in their expressions.</span></span>
<span data-ttu-id="ab10c-427">これらの関数は、System.Numerics オブジェクトを処理する場合と同様に、さまざまな型に対して計算や演算を実行するために用意されています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-427">These functions are provided to perform calculations and operations on different types that you would similarly do with System.Numerics objects.</span></span>

<span data-ttu-id="ab10c-428">次の例では、スカラーを対象として、Clamp ヘルパー関数を活用するための数式を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-428">An example below creates an Expression targeted towards Scalars that takes advantage of the Clamp helper function:</span></span>

```cs
var expression = _compositor.CreateExpressionAnimation("Clamp((scroller.Offset.y * -1.0) – container.Offset.y, 0, container.Size.y – header.Size.y)"
```

<span data-ttu-id="ab10c-429">ヘルパー関数の一覧に加えて、指定されたパラメーターに基づく型のインスタンスを生成する、組み込みのコンストラクター メソッドを数式文字列内で使用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-429">In addition to a list of Helper functions, you are also able to use built-in Constructor methods inside an Expression string that will generate an instance of that type based on the provided parameters.</span></span>

<span data-ttu-id="ab10c-430">次の例では、数式文字列で新しい Vector3 を定義する数式を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-430">An example below creates an Expression that defines a new Vector3 in the Expression string:</span></span>

```cs
var expression = _compositor.CreateExpressionAnimation("Offset / Vector3(targetX, targetY, targetZ");
```

<span data-ttu-id="ab10c-431">ヘルパー関数やコンストラクターの詳しい一覧については、「付録」セクションまたは次の一覧から各型の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-431">You can find the full extensive list of helper functions and constructors in the Appendix section, or for each type in the list below:</span></span>

* [<span data-ttu-id="ab10c-432">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-432">Scalar</span></span>](#scalar)
* [<span data-ttu-id="ab10c-433">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-433">Vector2</span></span>](#vector2)
* [<span data-ttu-id="ab10c-434">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-434">Vector3</span></span>](#vector3)
* [<span data-ttu-id="ab10c-435">Matrix3x2</span><span class="sxs-lookup"><span data-stu-id="ab10c-435">Matrix3x2</span></span>](#matrix3x2)
* [<span data-ttu-id="ab10c-436">Matrix4x4</span><span class="sxs-lookup"><span data-stu-id="ab10c-436">Matrix4x4</span></span>](#matrix4x4)
* [<span data-ttu-id="ab10c-437">Quaternion</span><span class="sxs-lookup"><span data-stu-id="ab10c-437">Quaternion</span></span>](#quaternion)
* [<span data-ttu-id="ab10c-438">Color</span><span class="sxs-lookup"><span data-stu-id="ab10c-438">Color</span></span>](#color)

### <a name="expression-keywords"></a><span data-ttu-id="ab10c-439">数式のキーワード</span><span class="sxs-lookup"><span data-stu-id="ab10c-439">Expression Keywords</span></span>

<span data-ttu-id="ab10c-440">数式文字列を評価するときに異なる方法で処理される、特殊な "キーワード" を利用できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-440">You can take advantage of special "keywords" that are treated differently when the Expression string is evaluated.</span></span>
<span data-ttu-id="ab10c-441">これらは "キーワード" と見なされるため、プロパティ参照の文字列パラメーターとしては使用できません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-441">Because they are considered "keywords" they can’t be used as the string parameter portion of their Property references.</span></span>

|<span data-ttu-id="ab10c-442">キーワード</span><span class="sxs-lookup"><span data-stu-id="ab10c-442">Keyword</span></span>|<span data-ttu-id="ab10c-443">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-443">Description</span></span>|
|-------|--------------|
|<span data-ttu-id="ab10c-444">this.StartingValue</span><span class="sxs-lookup"><span data-stu-id="ab10c-444">This.StartingValue</span></span>| <span data-ttu-id="ab10c-445">アニメーション化されるプロパティの開始値への参照を提供します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-445">Provides a reference to the original starting value of the property that is being animated.</span></span>|
|<span data-ttu-id="ab10c-446">this.CurrentValue</span><span class="sxs-lookup"><span data-stu-id="ab10c-446">This.CurrentValue</span></span>|<span data-ttu-id="ab10c-447">プロパティの現在の "既知" の値への参照を提供します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-447">Provides a reference to the currently "known" value of the property</span></span>|
|<span data-ttu-id="ab10c-448">Pi</span><span class="sxs-lookup"><span data-stu-id="ab10c-448">Pi</span></span>| <span data-ttu-id="ab10c-449">円周率の値を参照するキーワードです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-449">Provides a keyword reference to the value of PI</span></span>|

<span data-ttu-id="ab10c-450">次の例では、this.StartingValue キーワードの使い方を示しています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-450">An example below that demonstrates using the this.StartingValue keyword:</span></span>

```cs
var expression = _compositor.CreateExpressionAnimation("this.StartingValue + delta");
```

### <a name="expressions-with-conditionals"></a><span data-ttu-id="ab10c-451">条件を含む数式</span><span class="sxs-lookup"><span data-stu-id="ab10c-451">Expressions with Conditionals</span></span>

<span data-ttu-id="ab10c-452">演算し、プロパティ参照、関数、コンストラクターを使った数学的な関係のサポートに加えて、3 項演算子を含む式を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-452">In addition to supporting mathematical relationships using operators, property references, and functions and constructors, you can also create an expression that contains a ternary operator:</span></span>

```cs
(condition ? ifTrue_expression : ifFalse_expression)
```

<span data-ttu-id="ab10c-453">条件ステートメントによって、特定の条件に基づいて、異なる数学的な関係を使ってアニメーション化するプロパティの値を計算するような数式を作成できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-453">Conditional statements enable you to write expressions such that based on a particular condition, different mathematical relationships will be used by the system to calculate the value of the animating property.</span></span>
<span data-ttu-id="ab10c-454">true または false のステートメントの式として、3 項演算子は入れ子にできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-454">Ternary operators can be nested as the expressions for the true or false statements.</span></span>

<span data-ttu-id="ab10c-455">条件ステートメントでは、次の条件演算子がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-455">The following conditional operators are supported in the condition statement:</span></span>

* <span data-ttu-id="ab10c-456">等しい (==)</span><span class="sxs-lookup"><span data-stu-id="ab10c-456">Equals (==)</span></span>
* <span data-ttu-id="ab10c-457">等しくない (!=)</span><span class="sxs-lookup"><span data-stu-id="ab10c-457">Not Equals (!=)</span></span>
* <span data-ttu-id="ab10c-458">より小さい (<)</span><span class="sxs-lookup"><span data-stu-id="ab10c-458">Less than (<)</span></span>
* <span data-ttu-id="ab10c-459">以下 (<=)</span><span class="sxs-lookup"><span data-stu-id="ab10c-459">Less than or equal to (<=)</span></span>
* <span data-ttu-id="ab10c-460">より大きい (>)</span><span class="sxs-lookup"><span data-stu-id="ab10c-460">Great than (>)</span></span>
* <span data-ttu-id="ab10c-461">以上 (>=)</span><span class="sxs-lookup"><span data-stu-id="ab10c-461">Great than or equal to (>=)</span></span>

<span data-ttu-id="ab10c-462">条件ステートメント内の演算子や関数として次の要素がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ab10c-462">The following conjunctions are supported as operators or functions in the condition statement:</span></span>

* <span data-ttu-id="ab10c-463">Not: !</span><span class="sxs-lookup"><span data-stu-id="ab10c-463">Not: !</span></span> <span data-ttu-id="ab10c-464">/ Not(bool1)</span><span class="sxs-lookup"><span data-stu-id="ab10c-464">/ Not(bool1)</span></span>
* <span data-ttu-id="ab10c-465">And: && / And(bool1, bool2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-465">And: && / And(bool1, bool2)</span></span>
* <span data-ttu-id="ab10c-466">Or: || / Or(bool1, bool2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-466">Or: || / Or(bool1, bool2)</span></span>

<span data-ttu-id="ab10c-467">条件を使用する数式アニメーションの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-467">Below is an example of an Expression Animation using a conditional.</span></span>

```cs
var expression = _compositor.CreateExpressionAnimation("target.Offset.x > 50 ? 0.0f + (target.Offset.x / parent.Offset.x) : 1.0f");
```

## <a name="expression-keyframes"></a><span data-ttu-id="ab10c-468">数式キー フレーム</span><span class="sxs-lookup"><span data-stu-id="ab10c-468">Expression KeyFrames</span></span>

<span data-ttu-id="ab10c-469">既にこのドキュメントで、キー フレーム アニメーションを作成する方法を説明し、数式アニメーションと数式文字列を構成するさまざまな要素を紹介しました。</span><span class="sxs-lookup"><span data-stu-id="ab10c-469">Earlier in this document, we described how you create KeyFrame Animations and introduced you to Expression Animations and all the different pieces that you can use to make up the Expression string.</span></span> <span data-ttu-id="ab10c-470">数式アニメーションの利点を活用しながら、キー フレーム アニメーションによる時間の補間も必要な場合はどうすればよいでしょうか。</span><span class="sxs-lookup"><span data-stu-id="ab10c-470">What if you wanted the power from Expressions Animations but wanted time interpolation provided by KeyFrame Animations?</span></span>
<span data-ttu-id="ab10c-471">その答えは数式キー フレームです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-471">The answer is Expression KeyFrames!</span></span>

<span data-ttu-id="ab10c-472">キー フレーム アニメーションの各制御点として離散値を定義する代わりに、値として数式文字列を指定できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-472">Instead of defining a discrete value for each control points in the KeyFrame Animation, you can have the value be an Expression string.</span></span>
<span data-ttu-id="ab10c-473">この場合、タイムラインの特定の時点でのアニメーション化するプロパティの値を計算するために数式文字列が使用されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-473">In this situation, the system will use the expression string to calculate what the value of the animating property should be at the given point in the timeline.</span></span>
<span data-ttu-id="ab10c-474">システムは、通常のキー フレーム アニメーションの場合と同様に、単にこの値を補間します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-474">The system will then simply interpolate to this value like in a normal keyframe animation.</span></span>

<span data-ttu-id="ab10c-475">数式キー フレームを使用するために特殊なアニメーションを作成する必要はありません。標準のキー フレーム アニメーションに ExpressionKeyFrame を挿入し、値として時間と数式文字列を指定するだけです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-475">You don’t need to create special animations to use Expression KeyFrames – just insert an ExpressionKeyFrame into your standard KeyFrame animation, provide the time and your expression string as the value.</span></span> <span data-ttu-id="ab10c-476">次の例では、キー フレームの 1 つの値として数式文字列を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-476">The example below demonstrates this, using an Expression string as the value for one of the KeyFrames:</span></span>

```cs
var animation = _compositor.CreateScalarKeyFrameAnimation();
animation.InsertExpressionKeyFrame(0.25, "VisualBOffset.X / VisualAOffset.Y");
animation.InsertKeyFrame(1.00f, 0.8f);
```

## <a name="expression-sample"></a><span data-ttu-id="ab10c-477">数式のサンプル</span><span class="sxs-lookup"><span data-stu-id="ab10c-477">Expression Sample</span></span>

<span data-ttu-id="ab10c-478">次のコードでは、スクロール ビューアーから入力値を取得する、基本的な視差エクスペリエンスの数式アニメーションを設定する例を示します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-478">The code below shows an example of setting up an expression animation for a basic Parallax experience that pulls input values from the Scroll Viewer.</span></span>

```cs
// Get scrollviewer
ScrollViewer myScrollViewer = ThumbnailList.GetFirstDescendantOfType<ScrollViewer>();
_scrollProperties = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(myScrollViewer);

// Setup the expression
_parallaxExpression = compositor.CreateExpressionAnimation();
_parallaxExpression.SetScalarParameter("StartOffset", 0.0f);
_parallaxExpression.SetScalarParameter("ParallaxValue", 0.5f);
_parallaxExpression.SetScalarParameter("ItemHeight", 0.0f);
_parallaxExpression.SetReferenceParameter("ScrollManipulation", _scrollProperties);
_parallaxExpression.Expression = "(ScrollManipulation.Translation.Y + StartOffset - (0.5 *  ItemHeight)) * ParallaxValue - (ScrollManipulation.Translation.Y + StartOffset - (0.5   * ItemHeight))";
```

## <a name="animating-with-property-sets"></a><span data-ttu-id="ab10c-479">プロパティ セットを使ったアニメーション化</span><span class="sxs-lookup"><span data-stu-id="ab10c-479">Animating With Property Sets</span></span>

<span data-ttu-id="ab10c-480">コンポジション プロパティ セットを使用すると、複数のアニメーション間で共有でき、別のコンポジション オブジェクトの有効期間に関連付けられていない値を格納することができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-480">Composition Property Sets provide you with the ability to store values that can be shared across multiple animations and are not tied to the lifetime of another Composition object.</span></span>
<span data-ttu-id="ab10c-481">プロパティ セットは、よく使用される値を格納するのに非常に便利であり、後でアニメーション内で簡単に参照できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-481">Property Sets are extremely useful to store common values and then easily reference them later on in animations.</span></span>
<span data-ttu-id="ab10c-482">また、プロパティ セットを使って、数式を使用するアプリケーション ロジックに基づいてデータを格納することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-482">You can also use Property Sets to store data based on application logic to drive an expression.</span></span>

<span data-ttu-id="ab10c-483">プロパティ セットを作成するには、コンポジター オブジェクトのコンストラクター メソッドを使います。</span><span class="sxs-lookup"><span data-stu-id="ab10c-483">To create a property set, use the constructor method off your Compositor object:</span></span>

```cs
_sharedProperties = _compositor.CreatePropertySet();
```

<span data-ttu-id="ab10c-484">プロパティ セットを作成したら、プロパティ セットにプロパティと値を追加できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-484">Once you’ve created your Property Set, you can add a property and value to it:</span></span>

```cs
_sharedProperties.InsertVector3("NewOffset", offset);
```

<span data-ttu-id="ab10c-485">既に説明したように、このプロパティ セットの値は数式アニメーションで参照できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-485">Similar to what we’ve seen earlier, we can reference this property set value in an Expression Animation:</span></span>

```cs
var expression = _compositor.CreateExpressionAnimation("this.target.Offset + sharedProperties.NewOffset");
expression.SetReferenceParameter("sharedProperties", _sharedProperties);
targetVisual.StartAnimation("Offset", expression);
```

<span data-ttu-id="ab10c-486">プロパティ セットの値をアニメーション化することもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-486">Property set values can also be animated.</span></span> <span data-ttu-id="ab10c-487">この処理を実行するには、アニメーションを PropertySet オブジェクトにアタッチし、文字列でプロパティ名を参照します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-487">This is done by attaching the animation to the PropertySet object, and then referring to the property name in the string.</span></span>
<span data-ttu-id="ab10c-488">ここでは、キー フレーム アニメーションを使って、プロパティ セット内の NewOffset プロパティをアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-488">Below, we animate the NewOffset property in the property set using a KeyFrame Animation.</span></span>

```cs
var keyFrameAnimation = _compositor.CreateVector3KeyFrameAnimation()
keyFrameAnimation.InsertKeyFrame(0.5f, new Vector3(25.0f, 68.0f, 0.0f);
keyFrameAnimation.InsertKeyFrame(1.0f, new Vector3(89.0f, 125.0f, 0.0f);
_sharedProperties.StartAnimation("NewOffset", keyFrameAnimation);
```

<span data-ttu-id="ab10c-489">アプリでこのコードを実行した場合、数式アニメーションがアタッチされている、アニメーション化されたプロパティ値がどのようになるか疑問に感じるかもしれません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-489">You might be wondering if this code executed in an app, what happens to the animated property value the Expression Animation is attached to.</span></span>
<span data-ttu-id="ab10c-490">この場合、数式によって最初は値が出力されますが、キー フレーム アニメーションがプロパティ セット内のプロパティのアニメーション化を開始すると、各フレームで方程式が計算されるため、数式の値も更新されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-490">In this situation, the expression would initially output to a value, however, once the KeyFrame Animation begins to animate the Property in the Property Set, the Expression value will update as well, since the equation is calculated every frame.</span></span> <span data-ttu-id="ab10c-491">これが、数式およびキー フレーム アニメーションでプロパティ セットを使う利点です。</span><span class="sxs-lookup"><span data-stu-id="ab10c-491">This is the beauty of Property Sets with Expression and KeyFrame Animations!</span></span>

## <a name="manipulationpropertyset"></a><span data-ttu-id="ab10c-492">ManipulationPropertySet</span><span class="sxs-lookup"><span data-stu-id="ab10c-492">ManipulationPropertySet</span></span>

<span data-ttu-id="ab10c-493">開発者は、コンポジション プロパティ セットを使用することに加えて、XAML ScrollViewer のプロパティへのアクセスを許可する ManipulationPropertySet にアクセスすることもできます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-493">In addition to utilizing Composition Property Sets, a developer is also able to gain access to the ManipulationPropertySet that allows access to properties off of a XAML ScrollViewer.</span></span> <span data-ttu-id="ab10c-494">これらのプロパティを数式アニメーションで使用および参照することによって、視差や固定ヘッダーなどのエクスペリエンスを強化することができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-494">These properties can then be used and referenced in an Expression Animation to power experiences like Parallax and Sticky Headers.</span></span> <span data-ttu-id="ab10c-495">注: スクロール可能なコンテンツを含む任意の XAML コントロール (ListView、GridView など) の ScrollViewer を取得し、その ScrollViewer を使用してそれらのスクロール可能なコントロールの ManipulationPropertySet を取得します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-495">Note: You can grab the ScrollViewer of any XAML control (ListView, GridView, etc.) that has scrollable content and use that ScrollViewer to get the ManipulationPropertySet for those scrollable controls.</span></span>

<span data-ttu-id="ab10c-496">数式では、スクロール ビューアーの次のプロパティを参照できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-496">In your Expression, you are able to reference the following properties of the Scroll Viewer:</span></span>

|<span data-ttu-id="ab10c-497">プロパティ</span><span class="sxs-lookup"><span data-stu-id="ab10c-497">Property</span></span>| <span data-ttu-id="ab10c-498">型</span><span class="sxs-lookup"><span data-stu-id="ab10c-498">Type</span></span>|
|--------|-----|
|<span data-ttu-id="ab10c-499">Translation</span><span class="sxs-lookup"><span data-stu-id="ab10c-499">Translation</span></span>| <span data-ttu-id="ab10c-500">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-500">Vector3</span></span>|
|<span data-ttu-id="ab10c-501">Pan</span><span class="sxs-lookup"><span data-stu-id="ab10c-501">Pan</span></span>| <span data-ttu-id="ab10c-502">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-502">Vector3</span></span>|
|<span data-ttu-id="ab10c-503">Scale</span><span class="sxs-lookup"><span data-stu-id="ab10c-503">Scale</span></span>| <span data-ttu-id="ab10c-504">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-504">Vector3</span></span>|
|<span data-ttu-id="ab10c-505">CenterPoint</span><span class="sxs-lookup"><span data-stu-id="ab10c-505">CenterPoint</span></span>| <span data-ttu-id="ab10c-506">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-506">Vector3</span></span>|
|<span data-ttu-id="ab10c-507">Matrix</span><span class="sxs-lookup"><span data-stu-id="ab10c-507">Matrix</span></span>| <span data-ttu-id="ab10c-508">Matrix4x4</span><span class="sxs-lookup"><span data-stu-id="ab10c-508">Matrix4x4</span></span>|

<span data-ttu-id="ab10c-509">ManipulationPropertySet への参照を取得するには、ElementCompositionPreview の GetScrollViewerManipulationPropertySet メソッドを利用します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-509">To get a reference to the ManipulationPropertySet, utilize the GetScrollViewerManipulationPropertySet method of ElementCompositionPreview.</span></span>

```csharp
CompositionPropertySet manipPropSet = ElementCompositionPreview.GetScrollViewerManipulationPropertySet(myScroller);
```

<span data-ttu-id="ab10c-510">このプロパティ セットへの参照がある場合、プロパティ セットに含まれるスクロール ビューアーのプロパティを参照できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-510">Once you have a reference to this property set, you can reference properties of the Scroll Viewer that are found in the property set.</span></span> <span data-ttu-id="ab10c-511">まず、参照パラメーターを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-511">First step is to create the reference parameter.</span></span>

```csharp
ExpressionAnimation exp = compositor.CreateExpressionAnimation();
exp.SetReferenceParameter("ScrollManipulation", manipPropSet);
```

<span data-ttu-id="ab10c-512">参照パラメーターを設定すると、数式で ManipulationPropertySet プロパティを参照できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-512">After setting up the reference parameter, you can reference the ManipulationPropertySet properties in the Expression.</span></span>

```csharp
exp.Expression = “ScrollManipulation.Translation.Y / ScrollBounds”;
_target.StartAnimation(“Opacity”, exp);
```

## <a name="using-implicit-animations"></a><span data-ttu-id="ab10c-513">暗黙的なアニメーションの使用</span><span class="sxs-lookup"><span data-stu-id="ab10c-513">Using Implicit Animations</span></span>

<span data-ttu-id="ab10c-514">アニメーションでは、ユーザーに対する動作を効果的に表すことができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-514">Animations are a great way for you to describe a behavior to your users.</span></span> <span data-ttu-id="ab10c-515">コンテンツをアニメーション化する方法は複数ありますが、これまでに説明した方法はすべて、明示的にアニメーションを*開始*する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-515">There are multiple ways you can animate your content, but all of the methods discussed so far require you to explicitly *Start* your animation.</span></span> <span data-ttu-id="ab10c-516">この方法では、アニメーションを開始するタイミングの定義は完全に制御できますが、プロパティ値が変更されるたびにアニメーションが必要になる場合の管理は難しくなります。</span><span class="sxs-lookup"><span data-stu-id="ab10c-516">Although this allows you to have complete control to define when an animation will begin, it becomes difficult to manage when an animation is needed every time a property value will be changed.</span></span> <span data-ttu-id="ab10c-517">この状況は、アニメーションを定義するアプリの "パーソナリティ" が、アプリのコア コンポーネントとインフラストラクチャを定義するアプリの "ロジック" から分離されている場合によく発生します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-517">This occurs quite often when applications have separated the app “personality” that defines the animations from the app “logic” that defines core components and infrastructure of the app.</span></span> <span data-ttu-id="ab10c-518">暗黙的なアニメーションにより、簡単かつ明確に、アニメーションをアプリのコア ロジックから切り離して定義することができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-518">Implicit animations provide an easier and cleaner way to define the animation separately from the core app logic.</span></span> <span data-ttu-id="ab10c-519">このようなアニメーションは、フックして、特定のプロパティ変更トリガーで実行できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-519">You can hook these animations up to run with specific property change triggers.</span></span>

### <a name="setting-up-your-implicitanimationcollection"></a><span data-ttu-id="ab10c-520">ImplicitAnimationCollection の設定</span><span class="sxs-lookup"><span data-stu-id="ab10c-520">Setting up your ImplicitAnimationCollection</span></span>

<span data-ttu-id="ab10c-521">暗黙的なアニメーションは、その他の **CompositionAnimation** オブジェクト (**KeyFrameAnimation** または **ExpressionAnimation**) によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-521">Implicit animations are defined by other **CompositionAnimation** objects (**KeyFrameAnimation** or **ExpressionAnimation**).</span></span> <span data-ttu-id="ab10c-522">**ImplicitAnimationCollection** は、プロパティ変更*トリガー"* が満たされたときに開始される **CompositionAnimation** オブジェクトのセットを表します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-522">The **ImplicitAnimationCollection** represents the  set of **CompositionAnimation** objects that will start when the property change *trigger* is met.</span></span> <span data-ttu-id="ab10c-523">アニメーションを定義するときは、必ず **Target** プロパティを設定してください。これにより、開始時にアニメーションのターゲットとなる [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) プロパティが定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-523">Note when defining animations, make sure to set the **Target** property, this defines the [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) property the animation will target when it is started.</span></span> <span data-ttu-id="ab10c-524">**Target** のプロパティとして使用できるのは、アニメーション化可能な [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) プロパティだけです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-524">The property of **Target** can only be a [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) property that is animatable.</span></span>
<span data-ttu-id="ab10c-525">以下のコード スニペットでは、**Vector3KeyFrameAnimation** が 1 つ作成され、**ImplicitAnimationCollection** の一部として定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-525">In the code snippet below, a single **Vector3KeyFrameAnimation** is created and defined as part of the **ImplicitAnimationCollection**.</span></span> <span data-ttu-id="ab10c-526">その後、**ImplicitAnimationCollection** は、[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) の **ImplicitAnimation** プロパティに接続されるため、トリガーが満たされると、アニメーションが開始されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-526">The **ImplicitAnimationCollection** is then attached to the **ImplicitAnimation** property of [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx), such that when the trigger is met, the animation will start.</span></span>

```csharp
Vector3KeyFrameAnimation animation = _compositor.CreateVector3KeyFrameAnimation();
animation.DelayTime =  TimeSpan.FromMilliseconds(index);
animation.InsertExpressionKeyFrame(1.0f, "this.FinalValue");
animation.Target = "Offset";
ImplicitAnimationCollection implicitAnimationCollection = compositor.CreateImplicitAnimationCollection();

visual.ImplicitAnimations = implicitAnimationCollection;
```

### <a name="triggering-when-the-implicitanimation-starts"></a><span data-ttu-id="ab10c-527">ImplicitAnimation 開始時のトリガー</span><span class="sxs-lookup"><span data-stu-id="ab10c-527">Triggering when the ImplicitAnimation starts</span></span>

<span data-ttu-id="ab10c-528">トリガーという言葉は、アニメーションが暗黙的に開始されるタイミングを説明するときに使用されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-528">Trigger is the term used to describe when animations will start implicitly.</span></span> <span data-ttu-id="ab10c-529">現在、トリガーは、[Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) でアニメーション化可能なプロパティのいずれかに対する変更として定義されています。この変更は、プロパティの明示的な設定を通じて発生します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-529">Currently triggers are defined as changes to any of the animatable properties on [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) – these changes occur through explicit sets on the property.</span></span> <span data-ttu-id="ab10c-530">たとえば、**Offset** トリガーを **ImplicitAnimationCollection** に配置し、アニメーションを関連付けると、ターゲット [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) の **Offset** に対する更新が、コレクション内のアニメーションを使用して新しい値に変化します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-530">For example, by placing an **Offset** trigger on an **ImplicitAnimationCollection**, and associating an animation with it, updates to the **Offset** of the targeted [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) will animate to its new value using the animation in the collection.</span></span>
<span data-ttu-id="ab10c-531">ここでは、この追加行を挿入して、トリガーをターゲット [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) の **Offset** プロパティに設定します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-531">From the example above, we add this additional line to set the trigger to the **Offset** property of the target [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx).</span></span>

```csharp
implicitAnimationCollection["Offset"] = animation;
```

<span data-ttu-id="ab10c-532">**ImplicitAnimationCollection** には、複数のトリガーを指定できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-532">Note that an **ImplicitAnimationCollection** can have multiple triggers.</span></span> <span data-ttu-id="ab10c-533">つまり、暗黙的なアニメーションまたはアニメーションのグループは、さまざまなプロパティへの変更に応じて開始することができます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-533">This means that the implicit animation or group of animations can get started for changes to different properties.</span></span> <span data-ttu-id="ab10c-534">上記の例では、開発者は、Opacity などの他のプロパティのトリガーを追加できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-534">In the example above, the developer can potentially add a trigger for other properties such as Opacity.</span></span>

### <a name="thisfinalvalue"></a><span data-ttu-id="ab10c-535">this.FinalValue</span><span class="sxs-lookup"><span data-stu-id="ab10c-535">this.FinalValue</span></span>

<span data-ttu-id="ab10c-536">最初の暗黙的なアニメーションの例では、"1.0" キー フレームの ExpressionKeyFrame を使用し、**this.FinalValue** の式を割り当てました。</span><span class="sxs-lookup"><span data-stu-id="ab10c-536">In the first implicit example, we used an ExpressionKeyFrame for the “1.0” KeyFrame and assigned the expression of **this.FinalValue** to it.</span></span> <span data-ttu-id="ab10c-537">**this.FinalValue** は、暗黙的なアニメーションの特徴的な動作を提供する、式言語で予約されたキーワードです。</span><span class="sxs-lookup"><span data-stu-id="ab10c-537">**this.FinalValue** is a reserved keyword in the expression language that provides differentiating behavior for implicit animations.</span></span> <span data-ttu-id="ab10c-538">**this.FinalValue** は、API プロパティの値セットをアニメーションにバインドします。</span><span class="sxs-lookup"><span data-stu-id="ab10c-538">**this.FinalValue** binds the value set on the API property to the animation.</span></span> <span data-ttu-id="ab10c-539">これは、本当の意味でのテンプレートを作成するうえで役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-539">This helps in creating true templates.</span></span> <span data-ttu-id="ab10c-540">**this.FinalValue** は、明示的なアニメーションでは役に立ちません。API プロパティが即座に設定されるためです。それに対し、暗黙的なアニメーションの場合、このプロパティはすぐには設定されません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-540">**this.FinalValue** is not useful in explicit animations, as the API property is set instantly, whereas in case of implicit animations it is deferred.</span></span>

## <a name="using-animation-groups"></a><span data-ttu-id="ab10c-541">アニメーション グループの使用</span><span class="sxs-lookup"><span data-stu-id="ab10c-541">Using Animation Groups</span></span>

<span data-ttu-id="ab10c-542">**CompositionAnimationGroup** を使用すると、暗黙的または明示的なアニメーションで使用できるアニメーションの一覧を容易にグループ化できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-542">**CompositionAnimationGroup** provides an easy way for you to group a list of animations that can be be used with implicit or explicit animations.</span></span>

### <a name="creating-and-populating-animation-groups"></a><span data-ttu-id="ab10c-543">アニメーション グループの作成と設定</span><span class="sxs-lookup"><span data-stu-id="ab10c-543">Creating and Populating Animation Groups</span></span>

<span data-ttu-id="ab10c-544">Compositor オブジェクトの **CreateAnimationGroup** メソッドを使用すると、アニメーション グループを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-544">The **CreateAnimationGroup** method of the of the Compositor object lets you create an Animation Group:</span></span>

```sharp
CompositionAnimationGroup animationGroup = _compositor.CreateAnimationGroup();
animationGroup.Add(animationA);
animationGroup.Add(animationB);
```

<span data-ttu-id="ab10c-545">グループが作成されたら、個々のアニメーションをアニメーション グループに追加できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-545">Once the group is created, individual animations can be added to the animation group.</span></span> <span data-ttu-id="ab10c-546">個々のアニメーションを明示的に開始する必要はありません。これらはすべて、**StartAnimationGroup** が呼び出されたとき (明示的なシナリオの場合) またはトリガーが満たされたとき (暗黙的なシナリオの場合) に開始されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-546">Remember, that you do not need to explicitly start the individual animations – these will all get started when either **StartAnimationGroup** is called for the explicit scenario or when the trigger is met for the implicit one.</span></span>
<span data-ttu-id="ab10c-547">グループに追加されたアニメーションで、**Target** プロパティが定義されていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-547">Note, ensure that the animations that are added to the group have their **Target** property defined.</span></span> <span data-ttu-id="ab10c-548">これにより、ターゲット [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) のどのプロパティがアニメーション化されるかが定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-548">This will define what property of the target [Visual](https://msdn.microsoft.com/library/windows/apps/windows.ui.composition.visual.aspx) they will animate.</span></span>

### <a name="using-animation-groups-with-implicit-animations"></a><span data-ttu-id="ab10c-549">暗黙的なアニメーションでのアニメーション グループの使用</span><span class="sxs-lookup"><span data-stu-id="ab10c-549">Using Animation Groups with Implicit Animations</span></span>

<span data-ttu-id="ab10c-550">トリガーが満たされたときにアニメーション グループ形式の一連のアニメーションが開始されるような、暗黙的なアニメーションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-550">You can create implicit animations such that when a trigger is met, a set of animations in the form of an animation group are started.</span></span> <span data-ttu-id="ab10c-551">この場合、トリガーが満たされた時点で開始されるアニメーションのセットとしてアニメーション グループを定義します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-551">In this case, define the animation group as the set of animations that start when the trigger is met.</span></span>

```csharp
implicitAnimationCollection["Offset"] = animationGroup;
```

### <a name="using-animation-groups-with-explicit-animations"></a><span data-ttu-id="ab10c-552">明示的なアニメーションでのアニメーション グループの使用</span><span class="sxs-lookup"><span data-stu-id="ab10c-552">Using Animation Groups with Explicit Animations</span></span>

<span data-ttu-id="ab10c-553">**StartAnimationGroup** が呼び出されると、追加された個々のアニメーションが開始されるような、明示的なアニメーションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ab10c-553">You can create explicit animations such that the individual animations added will start when **StartAnimationGroup** is called.</span></span> <span data-ttu-id="ab10c-554">この **StartAnimation** の呼び出しでは、個々のアニメーションがさまざまなプロパティをターゲットとしている可能性があるため、グループを対象としたプロパティはありません。</span><span class="sxs-lookup"><span data-stu-id="ab10c-554">Note, that in this **StartAnimation** call, there is no targeted property for the group as individual animations could be targeting different properties.</span></span> <span data-ttu-id="ab10c-555">各アニメーションのターゲット プロパティが設定されていることを確認してください。</span><span class="sxs-lookup"><span data-stu-id="ab10c-555">Ensure that the target property for each animation is set.</span></span>

```csharp
visual.StartAnimationGroup(AnimationGroup);
```

### <a name="e2e-sample"></a><span data-ttu-id="ab10c-556">E2E サンプル</span><span class="sxs-lookup"><span data-stu-id="ab10c-556">E2E sample</span></span>

<span data-ttu-id="ab10c-557">この例では、新しい値が設定されたときに Offset プロパティを暗黙的にアニメーション化することを示します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-557">This example shows animating the Offset property implicitly when a new value is set.</span></span>

```csharp
class PropertyAnimation
{
    PropertyAnimation(Compositor compositor, SpriteVisual heroVisual, SpriteVisual listVisual)
    {
      // Define ImplicitAnimationCollection
        ImplicitAnimationCollection implicitAnimations =
        compositor.CreateImplicitAnimationCollection();

        // Trigger animation when the “Offset” property changes.
        implicitAnimations["Offset"] = CreateAnimation(compositor);

        // Assign ImplicitAnimations to a visual. Unlike Visual.Children,
        // ImplicitAnimations can be shared by multiple visuals so that they
        // share the same implicit animation behavior (same as Visual.Clip).
        heroVisual.ImplicitAnimations = implicitAnimations;

        // ImplicitAnimations can be shared among visuals
        listVisual.ImplicitAnimations = implicitAnimations;

        listVisual.Offset = new Vector3(20f, 20f, 20f);
    }

    Vector3KeyFrameAnimation CreateAnimation(Compositor compositor)
    {
        Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
        animation.InsertExpressionKeyFrame(0f, "this.StartingValue");
        animation.InsertExpressionKeyFrame(1f, "this.FinalValue");
        animation.Target = “Offset”;
        animation.Duration = TimeSpan.FromSeconds(0.25);
        return animation;
    }
}
```

## <a name="appendix"></a><span data-ttu-id="ab10c-558">付録</span><span class="sxs-lookup"><span data-stu-id="ab10c-558">Appendix</span></span>

### <a name="expression-functions-by-structure-type"></a><span data-ttu-id="ab10c-559">構造体の型ごとの式関数</span><span class="sxs-lookup"><span data-stu-id="ab10c-559">Expression Functions by Structure Type</span></span>

### <a name="scalar"></a><span data-ttu-id="ab10c-560">Scalar</span><span class="sxs-lookup"><span data-stu-id="ab10c-560">Scalar</span></span>

|<span data-ttu-id="ab10c-561">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-561">Function and Constructor Operations</span></span>| <span data-ttu-id="ab10c-562">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-562">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-563">Abs(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-563">Abs(Float value)</span></span>| <span data-ttu-id="ab10c-564">Float パラメーターの絶対値を表す浮動小数点数を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-564">Returns a Float representing the absolute value of the float parameter</span></span>|
|<span data-ttu-id="ab10c-565">Clamp(Float value, Float min, Float max)</span><span class="sxs-lookup"><span data-stu-id="ab10c-565">Clamp(Float value, Float min, Float max)</span></span>| <span data-ttu-id="ab10c-566">値が最小値よりも大きく最大値よりも小さい場合はその値、値が最小値よりも小さい場合は最小値、値が最大値よりも大きい場合は最大値を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-566">Returns a  float value that is either greater than min and less than max or min if the value is less than min or max if the value is greater than max</span></span>|
|<span data-ttu-id="ab10c-567">Max (Float value1, Float value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-567">Max (Float value1, Float value2)</span></span>| <span data-ttu-id="ab10c-568">value1 と value2 で大きい方の浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-568">Returns the greater float between value1 and value2.</span></span>|
|<span data-ttu-id="ab10c-569">Min (Float value1, Float value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-569">Min (Float value1, Float value2)</span></span>| <span data-ttu-id="ab10c-570">value1 と value2 で小さい方の浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-570">Returns the lesser float between value1 and value2.</span></span>|
|<span data-ttu-id="ab10c-571">Lerp(Float value1, Float value2, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-571">Lerp(Float value1, Float value2, Float progress)</span></span>| <span data-ttu-id="ab10c-572">進行状況に基づいて 2 つのスカラー値の線形補間によって計算された結果を表す浮動小数点数値を返します (注: 進行状況は 0.0 ～ 1.0 です)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-572">Returns a float that represents the calculated linear interpolation calculation between the two Scalar values based on the progress (Note: Progress is between 0.0 and 1.0)</span></span>|
|<span data-ttu-id="ab10c-573">Slerp(Float value1, Float value2, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-573">Slerp(Float value1, Float value2, Float progress)</span></span>| <span data-ttu-id="ab10c-574">進行状況に基づいて 2 つの浮動小数点数値の球面補間によって計算された結果を表す浮動小数点数値を返します (注: 進行状況は 0.0 ～ 1.0 です)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-574">Returns a Float that represents the calculated spherical interpolation between the two Float values based on the progress (Note: progress is between 0.0 and 1.0)</span></span>|
|<span data-ttu-id="ab10c-575">Mod(Float value1, Float value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-575">Mod(Float value1, Float value2)</span></span>| <span data-ttu-id="ab10c-576">value1 を value2 で除算した結果の余りの浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-576">Returns the Float remainder resulting from the division of value1 and value2</span></span>|
|<span data-ttu-id="ab10c-577">Ceil(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-577">Ceil(Float value)</span></span>| <span data-ttu-id="ab10c-578">次に大きい整数に丸められた Float パラメーターを返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-578">Returns the Float parameter rounded to next greater whole number</span></span>|
|<span data-ttu-id="ab10c-579">Floor(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-579">Floor(Float value)</span></span>| <span data-ttu-id="ab10c-580">次に小さい整数に丸められた Float パラメーターを返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-580">Returns the Float parameter to the next lesser whole number</span></span>|
|<span data-ttu-id="ab10c-581">Sqrt(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-581">Sqrt(Float value)</span></span>| <span data-ttu-id="ab10c-582">Float パラメーターの平方根を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-582">Returns the square root of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-583">Square(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-583">Square(Float value)</span></span>| <span data-ttu-id="ab10c-584">Float パラメーターの 2 乗を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-584">Returns the square of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-585">Sin(Float value1)</span><span class="sxs-lookup"><span data-stu-id="ab10c-585">Sin(Float value1)</span></span>| <span data-ttu-id="ab10c-586">Float パラメーターの正弦を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-586">Returns the Sin of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-587">Asin(Float value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-587">Asin(Float value2)</span></span>| <span data-ttu-id="ab10c-588">Float パラメーターの逆正弦を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-588">Returns the ArcSin of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-589">Cos(Float value1)</span><span class="sxs-lookup"><span data-stu-id="ab10c-589">Cos(Float value1)</span></span>| <span data-ttu-id="ab10c-590">Float パラメーターの余弦を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-590">Returns the Cos of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-591">ACos(Float value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-591">ACos(Float value2)</span></span>| <span data-ttu-id="ab10c-592">Float パラメーターの逆余弦を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-592">Returns the ArcCos of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-593">Tan(Float value1)</span><span class="sxs-lookup"><span data-stu-id="ab10c-593">Tan(Float value1)</span></span>| <span data-ttu-id="ab10c-594">Float パラメーターの正接を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-594">Returns the Tan of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-595">ATan(Float value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-595">ATan(Float value2)</span></span>| <span data-ttu-id="ab10c-596">Float パラメーターの逆正接を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-596">Returns the ArcTan of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-597">Round(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-597">Round(Float value)</span></span>| <span data-ttu-id="ab10c-598">最も近い整数に丸められた Float パラメーターを返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-598">Returns the Float parameter rounded to the nearest whole number</span></span>|
|<span data-ttu-id="ab10c-599">Log10(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-599">Log10(Float value)</span></span>| <span data-ttu-id="ab10c-600">Float パラメーターの対数 (底 10) を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-600">Returns the Log (base 10) result of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-601">Ln(Float value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-601">Ln(Float value)</span></span>| <span data-ttu-id="ab10c-602">Float パラメーターの自然対数を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-602">Returns the Natural Log result of the Float parameter</span></span>|
|<span data-ttu-id="ab10c-603">Pow(Float value, Float power)</span><span class="sxs-lookup"><span data-stu-id="ab10c-603">Pow(Float value, Float power)</span></span>| <span data-ttu-id="ab10c-604">Float パラメーターの指定されたべき乗の結果を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-604">Returns the result of the Float parameter raised to a particular power</span></span>|
|<span data-ttu-id="ab10c-605">ToDegrees(Float radians)</span><span class="sxs-lookup"><span data-stu-id="ab10c-605">ToDegrees(Float radians)</span></span>| <span data-ttu-id="ab10c-606">度に変換された Float パラメーターを返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-606">Returns the Float parameter converted into Degrees</span></span>|
|<span data-ttu-id="ab10c-607">ToRadians(Float degrees)</span><span class="sxs-lookup"><span data-stu-id="ab10c-607">ToRadians(Float degrees)</span></span>| <span data-ttu-id="ab10c-608">ラジアンに変換された Float パラメーターを返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-608">Returns the Float parameter converted into Radians</span></span>|

### <a name="vector2"></a><span data-ttu-id="ab10c-609">Vector2</span><span class="sxs-lookup"><span data-stu-id="ab10c-609">Vector2</span></span>

|<span data-ttu-id="ab10c-610">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-610">Function and Constructor Operations</span></span>|<span data-ttu-id="ab10c-611">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-611">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-612">Abs (Vector2 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-612">Abs (Vector2 value)</span></span>|<span data-ttu-id="ab10c-613">各コンポーネントに適用された絶対値を含む Vector2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-613">Returns a Vector2 with absolute value applied to each component</span></span>|
|<span data-ttu-id="ab10c-614">Clamp (Vector2 value1, Vector2 min, Vector2 max)</span><span class="sxs-lookup"><span data-stu-id="ab10c-614">Clamp (Vector2 value1, Vector2 min, Vector2 max)</span></span>|<span data-ttu-id="ab10c-615">各コンポーネントのクランプされた値を格納する Vector2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-615">Returns a Vector2 that contains the clamped values for each respective component</span></span>|
|<span data-ttu-id="ab10c-616">Max (Vector2 value1, Vector2 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-616">Max (Vector2 value1, Vector2 value2)</span></span>|<span data-ttu-id="ab10c-617">value1 および value2 の対応する各コンポーネントに Max を実行した Vector2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-617">Returns a Vector2 that has performed a Max on each of the corresponding components from value1 and value2</span></span>|
|<span data-ttu-id="ab10c-618">Min (Vector2 value1, Vector2 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-618">Min (Vector2 value1, Vector2 value2)</span></span>|<span data-ttu-id="ab10c-619">value1 および value2 の対応する各コンポーネントに Min を実行した Vector2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-619">Returns a Vector2 that has performed a Min on each of the corresponding components from value1 and value2</span></span>|
|<span data-ttu-id="ab10c-620">Scale(Vector2 value, Float factor)</span><span class="sxs-lookup"><span data-stu-id="ab10c-620">Scale(Vector2 value, Float factor)</span></span>|<span data-ttu-id="ab10c-621">ベクターの各コンポーネントにスケール ファクターを乗算した Vector2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-621">Returns a Vector2 with each component of the vector multiplied by the scaling factor.</span></span>|
|<span data-ttu-id="ab10c-622">Transform(Vector2 value, Matrix3x2 matrix)</span><span class="sxs-lookup"><span data-stu-id="ab10c-622">Transform(Vector2 value, Matrix3x2 matrix)</span></span>|<span data-ttu-id="ab10c-623">Vector2 と Matrix3x2 の間で線形変換を実行した (ベクターとマトリックスを乗算した) 結果の Vector2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-623">Returns a Vector2 resulting from the linear transformation between a Vector2 and a Matrix3x2 (aka multiplying a vector by a matrix).</span></span>|
|<span data-ttu-id="ab10c-624">Lerp(Vector2 value1, Vector2 value2, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-624">Lerp(Vector2 value1, Vector2 value2, Float progress)</span></span>|<span data-ttu-id="ab10c-625">進行状況に基づいて 2 つの Vector2 値の線形補間によって計算された結果を表す Vector2 を返します (注: 進行状況は 0.0 ～ 1.0 です)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-625">Returns a Vector2 that represents the calculated linear interpolation calculation between the two Vector2 values based on the progress (Note: Progress is between 0.0 and 1.0)</span></span>|
|<span data-ttu-id="ab10c-626">Length(Vector2 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-626">Length(Vector2 value)</span></span>|<span data-ttu-id="ab10c-627">Vector2 の長さ/大きさを表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-627">Returns a Float value representing the length/magnitude of the Vector2</span></span>|
|<span data-ttu-id="ab10c-628">LengthSquared(Vector2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-628">LengthSquared(Vector2)</span></span>|<span data-ttu-id="ab10c-629">Vector2 の長さ/大きさの 2 乗を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-629">Returns a Float value representing the square of the length/magnitude of a Vector2</span></span>|
|<span data-ttu-id="ab10c-630">Distance(Vector2 value1, Vector2 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-630">Distance(Vector2 value1, Vector2 value2)</span></span>|<span data-ttu-id="ab10c-631">2 つの Vector2 値の間の距離を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-631">Returns a Float value representing the distance between two Vector2 values</span></span>|
|<span data-ttu-id="ab10c-632">DistanceSquared(Vector2 value1, Vector2 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-632">DistanceSquared(Vector2 value1, Vector2 value2)</span></span>|<span data-ttu-id="ab10c-633">2 つの Vector2 値の間の距離の 2 乗を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-633">Returns a Float value representing the square of the distance between two Vector2 values</span></span>|
|<span data-ttu-id="ab10c-634">Normalize(Vector2 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-634">Normalize(Vector2 value)</span></span>|<span data-ttu-id="ab10c-635">すべてのコンポーネントが正規化されているパラメーターの単位ベクトルを表す Vector2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-635">Returns a Vector2 representing the unit vector of the parameter where all components have been normalized</span></span>|
|<span data-ttu-id="ab10c-636">Vector2(Float x, Float y)</span><span class="sxs-lookup"><span data-stu-id="ab10c-636">Vector2(Float x, Float y)</span></span>|<span data-ttu-id="ab10c-637">2 つの Float パラメーターを使用して Vector2 を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-637">Constructs a Vector2 using two Float parameters</span></span>|

### <a name="vector3"></a><span data-ttu-id="ab10c-638">Vector3</span><span class="sxs-lookup"><span data-stu-id="ab10c-638">Vector3</span></span>

|<span data-ttu-id="ab10c-639">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-639">Function and Constructor Operations</span></span>|<span data-ttu-id="ab10c-640">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-640">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-641">Abs (Vector3 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-641">Abs (Vector3 value)</span></span>|<span data-ttu-id="ab10c-642">各コンポーネントに適用された絶対値を含む Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-642">Returns a Vector3 with absolute value applied to each component</span></span>|
|<span data-ttu-id="ab10c-643">Clamp (Vector3 value1, Vector3 min, Vector3 max)</span><span class="sxs-lookup"><span data-stu-id="ab10c-643">Clamp (Vector3 value1, Vector3 min, Vector3 max)</span></span>|<span data-ttu-id="ab10c-644">各コンポーネントのクランプされた値を格納する Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-644">Returns a Vector3 that contains the clamped values for each respective component</span></span>|
|<span data-ttu-id="ab10c-645">Max (Vector3 value1, Vector3 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-645">Max (Vector3 value1, Vector3 value2)</span></span>|<span data-ttu-id="ab10c-646">value1 および value2 の対応する各コンポーネントに Max を実行した Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-646">Returns a Vector3 that has performed a Max on each of the corresponding components from value1 and value2</span></span>|
|<span data-ttu-id="ab10c-647">Min (Vector3 value1, Vector3 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-647">Min (Vector3 value1, Vector3 value2)</span></span>|<span data-ttu-id="ab10c-648">value1 および value2 の対応する各コンポーネントに Min を実行した Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-648">Returns a Vector3 that has performed a Min on each of the corresponding components from value1 and value2</span></span>|
|<span data-ttu-id="ab10c-649">Scale(Vector3 value, Float factor)</span><span class="sxs-lookup"><span data-stu-id="ab10c-649">Scale(Vector3 value, Float factor)</span></span>|<span data-ttu-id="ab10c-650">ベクターの各コンポーネントにスケール ファクターを乗算した Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-650">Returns a Vector3 with each component of the vector multiplied by the scaling factor.</span></span>|
|<span data-ttu-id="ab10c-651">Lerp(Vector3 value1, Vector3 value2, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-651">Lerp(Vector3 value1, Vector3 value2, Float progress)</span></span>|<span data-ttu-id="ab10c-652">進行状況に基づいて 2 つの Vector3 値の線形補間によって計算された結果を表す Vector3 を返します (注: 進行状況は 0.0 ～ 1.0 です)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-652">Returns a Vector3 that represents the calculated linear interpolation calculation between the two Vector3 values based on the progress (Note: Progress is between 0.0 and 1.0)</span></span>|
|<span data-ttu-id="ab10c-653">Length(Vector3 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-653">Length(Vector3 value)</span></span>|<span data-ttu-id="ab10c-654">Vector3 の長さ/大きさを表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-654">Returns a Float value representing the length/magnitude of the Vector3</span></span>|
|<span data-ttu-id="ab10c-655">LengthSquared(Vector3)</span><span class="sxs-lookup"><span data-stu-id="ab10c-655">LengthSquared(Vector3)</span></span>|<span data-ttu-id="ab10c-656">Vector3 の長さ/大きさの 2 乗を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-656">Returns a Float value representing the square of the length/magnitude of a Vector3</span></span>|
|<span data-ttu-id="ab10c-657">Distance(Vector3 value1, Vector3 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-657">Distance(Vector3 value1, Vector3 value2)</span></span>|<span data-ttu-id="ab10c-658">2 つの Vector3 値の間の距離を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-658">Returns a Float value representing the distance between two Vector3 values</span></span>|
|<span data-ttu-id="ab10c-659">DistanceSquared(Vector3 value1, Vector3 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-659">DistanceSquared(Vector3 value1, Vector3 value2)</span></span>|<span data-ttu-id="ab10c-660">2 つの Vector3 値の間の距離の 2 乗を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-660">Returns a Float value representing the square of the distance between two Vector3 values</span></span>|
|<span data-ttu-id="ab10c-661">Normalize(Vector3 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-661">Normalize(Vector3 value)</span></span>|<span data-ttu-id="ab10c-662">すべてのコンポーネントが正規化されているパラメーターの単位ベクトルを表す Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-662">Returns a Vector3 representing the unit vector of the parameter where all components have been normalized</span></span>|
|<span data-ttu-id="ab10c-663">Vector3(Float x, Float y, Float z)</span><span class="sxs-lookup"><span data-stu-id="ab10c-663">Vector3(Float x, Float y, Float z)</span></span>|<span data-ttu-id="ab10c-664">3 つの Float パラメーターを使用して Vector3 を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-664">Constructs a Vector3 using three Float parameters</span></span>|

### <a name="vector4"></a><span data-ttu-id="ab10c-665">Vector4</span><span class="sxs-lookup"><span data-stu-id="ab10c-665">Vector4</span></span>

|<span data-ttu-id="ab10c-666">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-666">Function and Constructor Operations</span></span>|<span data-ttu-id="ab10c-667">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-667">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-668">Abs (Vector4 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-668">Abs (Vector4 value)</span></span>|<span data-ttu-id="ab10c-669">各コンポーネントに適用された絶対値を含む Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-669">Returns a Vector3 with absolute value applied to each component</span></span>|
|<span data-ttu-id="ab10c-670">Clamp (Vector4 value1, Vector4 min, Vector4 max)</span><span class="sxs-lookup"><span data-stu-id="ab10c-670">Clamp (Vector4 value1, Vector4 min, Vector4 max)</span></span>|<span data-ttu-id="ab10c-671">各コンポーネントのクランプされた値を格納する Vector4 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-671">Returns a Vector4 that contains the clamped values for each respective component</span></span>|
|<span data-ttu-id="ab10c-672">Max (Vector4 value1 Vector4 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-672">Max (Vector4 value1 Vector4 value2)</span></span>|<span data-ttu-id="ab10c-673">value1 および value2 の対応する各コンポーネントに Max を実行した Vector4 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-673">Returns a Vector4 that has performed a Max on each of the corresponding components from value1 and value2</span></span>|
|<span data-ttu-id="ab10c-674">Min (Vector4 value1 Vector4 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-674">Min (Vector4 value1 Vector4 value2)</span></span>|<span data-ttu-id="ab10c-675">value1 および value2 の対応する各コンポーネントに Min を実行した Vector4 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-675">Returns a Vector4 that has performed a Min on each of the corresponding components from value1 and value2</span></span>|
|<span data-ttu-id="ab10c-676">Scale(Vector3 value, Float factor)</span><span class="sxs-lookup"><span data-stu-id="ab10c-676">Scale(Vector3 value, Float factor)</span></span>|<span data-ttu-id="ab10c-677">ベクターの各コンポーネントにスケール ファクターを乗算した Vector3 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-677">Returns a Vector3 with each component of the vector multiplied by the scaling factor.</span></span>|
|<span data-ttu-id="ab10c-678">Transform(Vector4 value, Matrix4x4 matrix)</span><span class="sxs-lookup"><span data-stu-id="ab10c-678">Transform(Vector4 value, Matrix4x4 matrix)</span></span>|<span data-ttu-id="ab10c-679">Vector4 と Matrix4x4 の間で線形変換を実行した (ベクターとマトリックスを乗算した) 結果の Vector4 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-679">Returns a Vector4 resulting from the linear transformation between a Vector4 and a Matrix4x4 (aka multiplying a vector by a matrix).</span></span>|
|<span data-ttu-id="ab10c-680">Lerp(Vector4 value1, Vector4 value2, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-680">Lerp(Vector4 value1, Vector4 value2, Float progress)</span></span>|<span data-ttu-id="ab10c-681">進行状況に基づいて 2 つの Vector4 値の線形補間によって計算された結果を表す Vector4 を返します (注: 進行状況は 0.0 ～ 1.0 です)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-681">Returns a Vector4 that represents the calculated linear interpolation calculation between the two Vector4 values based on the progress (Note: progress is between 0.0 and 1.0)</span></span>|
|<span data-ttu-id="ab10c-682">Length(Vector4 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-682">Length(Vector4 value)</span></span>|<span data-ttu-id="ab10c-683">Vector4 の長さ/大きさを表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-683">Returns a Float value representing the length/magnitude of the Vector4</span></span>|
|<span data-ttu-id="ab10c-684">LengthSquared(Vector4)</span><span class="sxs-lookup"><span data-stu-id="ab10c-684">LengthSquared(Vector4)</span></span>|<span data-ttu-id="ab10c-685">Vector4 の長さ/大きさの 2 乗を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-685">Returns a Float value representing the square of the length/magnitude of a Vector4</span></span>|
|<span data-ttu-id="ab10c-686">Distance(Vector4 value1, Vector4 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-686">Distance(Vector4 value1, Vector4 value2)</span></span>|<span data-ttu-id="ab10c-687">2 つの Vector4 値の間の距離を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-687">Returns a Float value representing the distance between two Vector4 values</span></span>|
|<span data-ttu-id="ab10c-688">DistanceSquared(Vector4 value1, Vector4 value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-688">DistanceSquared(Vector4 value1, Vector4 value2)</span></span>|<span data-ttu-id="ab10c-689">2 つの Vector4 値の間の距離の 2 乗を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-689">Returns a Float value representing the square of the distance between two Vector4 values</span></span>|
|<span data-ttu-id="ab10c-690">Normalize(Vector4 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-690">Normalize(Vector4 value)</span></span>|<span data-ttu-id="ab10c-691">すべてのコンポーネントが正規化されているパラメーターの単位ベクトルを表す Vector4 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-691">Returns a Vector4 representing the unit vector of the parameter where all components have been normalized</span></span>|
|<span data-ttu-id="ab10c-692">Vector4(Float x, Float y, Float z, Float w)</span><span class="sxs-lookup"><span data-stu-id="ab10c-692">Vector4(Float x, Float y, Float z, Float w)</span></span>|<span data-ttu-id="ab10c-693">4 つの Float パラメーターを使用して Vector4 を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-693">Constructs a Vector4 using four Float parameters</span></span>|

### <a name="matrix3x2"></a><span data-ttu-id="ab10c-694">Matrix3x2</span><span class="sxs-lookup"><span data-stu-id="ab10c-694">Matrix3x2</span></span>

|<span data-ttu-id="ab10c-695">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-695">Function and Constructor Operations</span></span>|   <span data-ttu-id="ab10c-696">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-696">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-697">Scale(Matrix3x2 value, Float factor)</span><span class="sxs-lookup"><span data-stu-id="ab10c-697">Scale(Matrix3x2 value, Float factor)</span></span>|  <span data-ttu-id="ab10c-698">マトリックスの各コンポーネントにスケール ファクターを乗算した Matrix3x2 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-698">Returns a Matrix3x2 with each component of the matrix multiplied by the scaling factor.</span></span>|
|<span data-ttu-id="ab10c-699">Inverse(Matrix 3x2 value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-699">Inverse(Matrix 3x2 value)</span></span>| <span data-ttu-id="ab10c-700">逆マトリックスを表す Matrix3x2 オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-700">Returns a Matrix3x2 object that represents the reciprocal matrix</span></span>|
|<span data-ttu-id="ab10c-701">Matrix3x2(Float M11, Float M12, Float M21, Float M22, Float M31, Float M32)</span><span class="sxs-lookup"><span data-stu-id="ab10c-701">Matrix3x2(Float M11, Float M12, Float M21, Float M22, Float M31, Float M32)</span></span>|   <span data-ttu-id="ab10c-702">6 つの Float パラメーターを使用して Matrix3x2 を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-702">Constructs a Matrix3x2 using 6 Float parameters</span></span>|
|<span data-ttu-id="ab10c-703">Matrix3x2.CreateFromScale(Vector2 scale)</span><span class="sxs-lookup"><span data-stu-id="ab10c-703">Matrix3x2.CreateFromScale(Vector2 scale)</span></span>|  <span data-ttu-id="ab10c-704">スケールを表す Vector2 から Matrix3x2 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-704">Constructs a Matrix3x2 from a Vector2   representing scale</span></span><br/><span data-ttu-id="ab10c-705">\[scale.X, 0.0</span><span class="sxs-lookup"><span data-stu-id="ab10c-705">\[scale.X, 0.0</span></span><br/> <span data-ttu-id="ab10c-706">0.0, scale.Y</span><span class="sxs-lookup"><span data-stu-id="ab10c-706">0.0, scale.Y</span></span><br/> <span data-ttu-id="ab10c-707">0.0, 0.0 \]</span><span class="sxs-lookup"><span data-stu-id="ab10c-707">0.0, 0.0 \]</span></span>|
|<span data-ttu-id="ab10c-708">Matrix3x2.CreateFromTranslation(Vector2 translation)</span><span class="sxs-lookup"><span data-stu-id="ab10c-708">Matrix3x2.CreateFromTranslation(Vector2 translation)</span></span>|  <span data-ttu-id="ab10c-709">平行移動を表す Vector2 から Matrix3x2 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-709">Constructs a Matrix3x2 from a Vector2 representing translation</span></span><br/><span data-ttu-id="ab10c-710">\[1.0, 0.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-710">\[1.0, 0.0,</span></span><br/> <span data-ttu-id="ab10c-711">0.0, 1.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-711">0.0, 1.0,</span></span><br/> <span data-ttu-id="ab10c-712">translation.X, translation.Y\]</span><span class="sxs-lookup"><span data-stu-id="ab10c-712">translation.X, translation.Y\]</span></span>|
|<span data-ttu-id="ab10c-713">Matrix3x2.CreateSkew(Float x, Float y, Vector2 centerpoint)</span><span class="sxs-lookup"><span data-stu-id="ab10c-713">Matrix3x2.CreateSkew(Float x, Float y, Vector2 centerpoint)</span></span>| <span data-ttu-id="ab10c-714">スキューを表す 2 つの浮動小数点数値と Vector2 から Matrix3x2 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-714">Constructs a Matrix3x2 from two Float and a Vector2 representing skew</span></span><br/><span data-ttu-id="ab10c-715">\[1.0, Tan(y),</span><span class="sxs-lookup"><span data-stu-id="ab10c-715">\[1.0, Tan(y),</span></span><br/><span data-ttu-id="ab10c-716">Tan(x), 1.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-716">Tan(x), 1.0,</span></span><br/><span data-ttu-id="ab10c-717">-centerpoint.Y * Tan(x), -centerpoint.X * Tan(y)\]</span><span class="sxs-lookup"><span data-stu-id="ab10c-717">-centerpoint.Y * Tan(x), -centerpoint.X * Tan(y)\]</span></span>|
|<span data-ttu-id="ab10c-718">Matrix3x2.CreateRotation(Float radians)</span><span class="sxs-lookup"><span data-stu-id="ab10c-718">Matrix3x2.CreateRotation(Float radians)</span></span>| <span data-ttu-id="ab10c-719">回転 (ラジアン単位) から Matrix3x2 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-719">Constructs a Matrix3x2 from a rotation in radians</span></span><br/><span data-ttu-id="ab10c-720">\[Cos(radians), Sin(radians),</span><span class="sxs-lookup"><span data-stu-id="ab10c-720">\[Cos(radians), Sin(radians),</span></span><br/><span data-ttu-id="ab10c-721">-Sin(radians), Cos(radians),</span><span class="sxs-lookup"><span data-stu-id="ab10c-721">-Sin(radians), Cos(radians),</span></span><br/><span data-ttu-id="ab10c-722">0.0, 0.0 \]</span><span class="sxs-lookup"><span data-stu-id="ab10c-722">0.0, 0.0 \]</span></span>|
|<span data-ttu-id="ab10c-723">Matrix3x2.CreateTranslation(Vector2 translation)</span><span class="sxs-lookup"><span data-stu-id="ab10c-723">Matrix3x2.CreateTranslation(Vector2 translation)</span></span>| <span data-ttu-id="ab10c-724">CreateFromTranslation と同じ。</span><span class="sxs-lookup"><span data-stu-id="ab10c-724">Same as CreateFromTranslation</span></span>|
|<span data-ttu-id="ab10c-725">Matrix3x2.CreateScale(Vector2 scale)</span><span class="sxs-lookup"><span data-stu-id="ab10c-725">Matrix3x2.CreateScale(Vector2 scale)</span></span>| <span data-ttu-id="ab10c-726">CreateFromScale と同じ。</span><span class="sxs-lookup"><span data-stu-id="ab10c-726">Same as CreateFromScale</span></span>|


### <a name="matrix4x4"></a><span data-ttu-id="ab10c-727">Matrix4x4</span><span class="sxs-lookup"><span data-stu-id="ab10c-727">Matrix4x4</span></span>

|<span data-ttu-id="ab10c-728">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-728">Function and Constructor Operations</span></span>|   <span data-ttu-id="ab10c-729">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-729">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-730">Scale(Matrix4x4 value, Float factor)</span><span class="sxs-lookup"><span data-stu-id="ab10c-730">Scale(Matrix4x4 value, Float factor)</span></span>|  <span data-ttu-id="ab10c-731">マトリックスの各コンポーネントにスケール ファクターを乗算した Matrix4x4 を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-731">Returns a Matrix 4x4 with each component of the matrix multiplied by the scaling factor.</span></span>|
|<span data-ttu-id="ab10c-732">Inverse(Matrix4x4)</span><span class="sxs-lookup"><span data-stu-id="ab10c-732">Inverse(Matrix4x4)</span></span>|    <span data-ttu-id="ab10c-733">逆マトリックスを表す Matrix4x4 オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-733">Returns a Matrix4x4 object that represents the reciprocal matrix</span></span>|
|<span data-ttu-id="ab10c-734">Matrix4x4(Float M11, Float M12, Float M13, Float M14,</span><span class="sxs-lookup"><span data-stu-id="ab10c-734">Matrix4x4(Float M11, Float M12, Float M13, Float M14,</span></span><br/><span data-ttu-id="ab10c-735">Float M21, Float M22, Float M23, Float M24,</span><span class="sxs-lookup"><span data-stu-id="ab10c-735">Float M21, Float M22, Float M23, Float M24,</span></span><br/>    <span data-ttu-id="ab10c-736">Float M31, Float M32, Float M33, Float M34,</span><span class="sxs-lookup"><span data-stu-id="ab10c-736">Float M31, Float M32, Float M33, Float M34,</span></span><br/>    <span data-ttu-id="ab10c-737">Float M41, Float M42, Float M43, Float M44)</span><span class="sxs-lookup"><span data-stu-id="ab10c-737">Float M41, Float M42, Float M43, Float M44)</span></span>| <span data-ttu-id="ab10c-738">16 個の Float パラメーターを使用して Matrix4x4 を作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-738">Constructs a Matrix4x4 using 16 Float parameters</span></span>|
|<span data-ttu-id="ab10c-739">Matrix4x4.CreateFromScale(Vector3 scale)</span><span class="sxs-lookup"><span data-stu-id="ab10c-739">Matrix4x4.CreateFromScale(Vector3 scale)</span></span>|  <span data-ttu-id="ab10c-740">スケールを表す Vector3 から Matrix4x4 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-740">Constructs a Matrix4x4 from a Vector3 representing scale</span></span><br/><span data-ttu-id="ab10c-741">\[scale.X, 0.0, 0.0, 0.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-741">\[scale.X, 0.0, 0.0, 0.0,</span></span><br/> <span data-ttu-id="ab10c-742">0.0, scale.Y, 0.0, 0.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-742">0.0, scale.Y, 0.0, 0.0,</span></span><br/> <span data-ttu-id="ab10c-743">0.0, 0.0, scale.Z, 0.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-743">0.0, 0.0, scale.Z, 0.0,</span></span><br/> <span data-ttu-id="ab10c-744">0.0, 0.0, 0.0, 1.0\]</span><span class="sxs-lookup"><span data-stu-id="ab10c-744">0.0, 0.0, 0.0, 1.0\]</span></span>|
|<span data-ttu-id="ab10c-745">Matrix4x4.CreateFromTranslation(Vector3 translation)</span><span class="sxs-lookup"><span data-stu-id="ab10c-745">Matrix4x4.CreateFromTranslation(Vector3 translation)</span></span>|  <span data-ttu-id="ab10c-746">平行移動を表す Vector3 から Matrix4x4 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-746">Constructs a Matrix4x4 from a Vector3 representing translation</span></span><br/><span data-ttu-id="ab10c-747">\[1.0, 0.0, 0.0, 0.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-747">\[1.0, 0.0, 0.0, 0.0,</span></span><br/> <span data-ttu-id="ab10c-748">0.0, 1.0, 0.0, 0.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-748">0.0, 1.0, 0.0, 0.0,</span></span><br/> <span data-ttu-id="ab10c-749">0.0, 0.0, 1.0, 0.0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-749">0.0, 0.0, 1.0, 0.0,</span></span><br/> <span data-ttu-id="ab10c-750">translation.X, translation.Y, translation.Z, 1.0\]</span><span class="sxs-lookup"><span data-stu-id="ab10c-750">translation.X, translation.Y, translation.Z, 1.0\]</span></span>|
|<span data-ttu-id="ab10c-751">Matrix4x4.CreateFromAxisAngle(Vector3 axis, Float angle)</span><span class="sxs-lookup"><span data-stu-id="ab10c-751">Matrix4x4.CreateFromAxisAngle(Vector3 axis, Float angle)</span></span>|  <span data-ttu-id="ab10c-752">Vector3 軸と角度を表す浮動小数点数値から Matrix4x4 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-752">Constructs a Matrix4x4 from a Vector3 axis and a Float representing an angle</span></span>|
|<span data-ttu-id="ab10c-753">Matrix4x4(Matrix3x2 matrix)</span><span class="sxs-lookup"><span data-stu-id="ab10c-753">Matrix4x4(Matrix3x2 matrix)</span></span>| <span data-ttu-id="ab10c-754">Matrix3x2 を使用して Matrix4x4 を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-754">Constructs a Matrix4x4 using a Matrix3x2</span></span><br/><span data-ttu-id="ab10c-755">\[matrix.11, matrix.12, 0, 0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-755">\[matrix.11, matrix.12, 0, 0,</span></span><br/><span data-ttu-id="ab10c-756">matrix.21, matrix.22, 0, 0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-756">matrix.21, matrix.22, 0, 0,</span></span><br/><span data-ttu-id="ab10c-757">0, 0, 1, 0,</span><span class="sxs-lookup"><span data-stu-id="ab10c-757">0, 0, 1, 0,</span></span><br/><span data-ttu-id="ab10c-758">matrix.31, matrix.32, 0, 1\]</span><span class="sxs-lookup"><span data-stu-id="ab10c-758">matrix.31, matrix.32, 0, 1\]</span></span>|
|<span data-ttu-id="ab10c-759">Matrix4x4.CreateTranslation(Vector3 translation)</span><span class="sxs-lookup"><span data-stu-id="ab10c-759">Matrix4x4.CreateTranslation(Vector3 translation)</span></span>| <span data-ttu-id="ab10c-760">CreateFromTranslation と同じ。</span><span class="sxs-lookup"><span data-stu-id="ab10c-760">Same as CreateFromTranslation</span></span>|
|<span data-ttu-id="ab10c-761">Matrix4x4.CreateScale(Vector3 scale)</span><span class="sxs-lookup"><span data-stu-id="ab10c-761">Matrix4x4.CreateScale(Vector3 scale)</span></span>| <span data-ttu-id="ab10c-762">CreateFromScale と同じ。</span><span class="sxs-lookup"><span data-stu-id="ab10c-762">Same as CreateFromScale</span></span>|


### <a name="quaternion"></a><span data-ttu-id="ab10c-763">Quaternion</span><span class="sxs-lookup"><span data-stu-id="ab10c-763">Quaternion</span></span>

|<span data-ttu-id="ab10c-764">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-764">Function and Constructor Operations</span></span>|   <span data-ttu-id="ab10c-765">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-765">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-766">Slerp(Quaternion value1, Quaternion value2, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-766">Slerp(Quaternion value1, Quaternion value2, Float progress)</span></span>|   <span data-ttu-id="ab10c-767">進行状況に基づいて 2 つの Quaternion の球面補間によって計算された結果を表す Quaternion を返します (注: 進行状況は 0.0 ～ 1.0 です)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-767">Returns a Quaternion that represents the calculated spherical interpolation between the two Quaternion values based on the progress (Note: progress is between 0.0 and 1.0)</span></span>|
|<span data-ttu-id="ab10c-768">Concatenate(Quaternion value1 Quaternion value2)</span><span class="sxs-lookup"><span data-stu-id="ab10c-768">Concatenate(Quaternion value1 Quaternion value2)</span></span>|  <span data-ttu-id="ab10c-769">2 つの Quaternion の連結を表す Quaternion (結合された 2 つの個別の回転を表す Quaternion) を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-769">Returns a Quaternion representing a concatenation of two Quaternions (aka a Quaternion that represents a combined two individual rotations)</span></span>|
|<span data-ttu-id="ab10c-770">Length(Quaternion value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-770">Length(Quaternion value)</span></span>|  <span data-ttu-id="ab10c-771">Quaternion の長さ/大きさを表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-771">Returns a Float value representing the length/magnitude of the Quaternion.</span></span>|
|<span data-ttu-id="ab10c-772">LengthSquared(Quaternion)</span><span class="sxs-lookup"><span data-stu-id="ab10c-772">LengthSquared(Quaternion)</span></span>| <span data-ttu-id="ab10c-773">Quaternion の長さ/大きさの 2 乗を表す浮動小数点数値を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-773">Returns a Float value representing the square of the length/magnitude of a Quaternion</span></span>|
|<span data-ttu-id="ab10c-774">Normalize(Quaternion value)</span><span class="sxs-lookup"><span data-stu-id="ab10c-774">Normalize(Quaternion value)</span></span>|   <span data-ttu-id="ab10c-775">コンポーネントが正規化された Quaternion を返します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-775">Returns a Quaternion whose components have been normalized</span></span>|
|<span data-ttu-id="ab10c-776">Quaternion.CreateFromAxisAngle(Vector3 axis, Scalar angle)</span><span class="sxs-lookup"><span data-stu-id="ab10c-776">Quaternion.CreateFromAxisAngle(Vector3 axis, Scalar angle)</span></span>|    <span data-ttu-id="ab10c-777">Vector3 軸と角度を表すスカラーから Quaternion を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-777">Constructs a Quaternion from a Vector3 axis and a Scalar representing an angle</span></span>|
|<span data-ttu-id="ab10c-778">Quaternion(Float x, Float y, Float z, Float w)</span><span class="sxs-lookup"><span data-stu-id="ab10c-778">Quaternion(Float x, Float y, Float z, Float w)</span></span>|    <span data-ttu-id="ab10c-779">4 つの浮動小数点数値から Quaternion を構築します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-779">Constructs a Quaternion from four Float values</span></span>|

### <a name="color"></a><span data-ttu-id="ab10c-780">Color</span><span class="sxs-lookup"><span data-stu-id="ab10c-780">Color</span></span>

|<span data-ttu-id="ab10c-781">関数とコンストラクターの演算</span><span class="sxs-lookup"><span data-stu-id="ab10c-781">Function and Constructor Operations</span></span>|   <span data-ttu-id="ab10c-782">説明</span><span class="sxs-lookup"><span data-stu-id="ab10c-782">Description</span></span>|
|-----------------------------------|--------------|
|<span data-ttu-id="ab10c-783">ColorLerp(Color colorTo, Color colorFrom, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-783">ColorLerp(Color colorTo, Color colorFrom, Float progress)</span></span>| <span data-ttu-id="ab10c-784">特定の進行状況に基づいて 2 つの Color オブジェクト間で計算された線形補間値を表す Color オブジェクトを返します </span><span class="sxs-lookup"><span data-stu-id="ab10c-784">Returns a Color object that represents the calculated linear interpolation value between two color objects based on a given progress.</span></span> <span data-ttu-id="ab10c-785">(注: 進行状況は 0.0 ～ 1.0 です)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-785">(Note: Progress is between 0.0 and 1.0)</span></span>|
|<span data-ttu-id="ab10c-786">ColorLerpRGB(Color colorTo, Color colorFrom, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-786">ColorLerpRGB(Color colorTo, Color colorFrom, Float progress)</span></span>|  <span data-ttu-id="ab10c-787">特定の進行状況に基づいて、RGB 色空間の 2 つのオブジェクト間で計算された線形補間値を表す Color オブジェクトを返します </span><span class="sxs-lookup"><span data-stu-id="ab10c-787">Returns a Color object that represents the calculated linear interpolation value between two objects based on a given progress in the RGB color space.</span></span>|
|<span data-ttu-id="ab10c-788">ColorLerpHSL(Color colorTo, Color colorFrom, Float progress)</span><span class="sxs-lookup"><span data-stu-id="ab10c-788">ColorLerpHSL(Color colorTo, Color colorFrom, Float progress)</span></span>|  <span data-ttu-id="ab10c-789">特定の進行状況に基づいて、HSL 色空間の 2 つのオブジェクト間で計算された線形補間値を表す Color オブジェクトを返します </span><span class="sxs-lookup"><span data-stu-id="ab10c-789">Returns a Color object that represents the calculated linear interpolation value between two objects based on a given progress in the HSL color space.</span></span>|
|<span data-ttu-id="ab10c-790">ColorArgb(Float a, Float r, Float g, Float b)</span><span class="sxs-lookup"><span data-stu-id="ab10c-790">ColorArgb(Float a, Float r, Float g, Float b)</span></span>| <span data-ttu-id="ab10c-791">ARGB コンポーネントで定義される Color を表すオブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab10c-791">Constructs an object representing Color defined by ARGB components</span></span>|
|<span data-ttu-id="ab10c-792">ColorHsl(Float h, Float s, Float l)</span><span class="sxs-lookup"><span data-stu-id="ab10c-792">ColorHsl(Float h, Float s, Float l)</span></span>|   <span data-ttu-id="ab10c-793">HSL コンポーネントで定義される Color を表すオブジェクトを作成します (注: 色相は 0 ～ 2pi で定義されます)。</span><span class="sxs-lookup"><span data-stu-id="ab10c-793">Constructs an object representing Color defined by HSL components (Note: Hue is defined from 0 and 2pi)</span></span>|

