---
author: jwmsft
title: 入力駆動型アニメーション
description: アプリの UI で入力アニメーションを使用する方法について説明します。
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
keywords: Windows 10, UWP, アニメーション
ms.localizationpriority: medium
ms.openlocfilehash: 04eabb4c70143a08f5b850e6444f7f3d21a9dd4a
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7576596"
---
# <a name="input-driven-animations"></a><span data-ttu-id="b13b8-104">入力駆動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="b13b8-104">Input-driven animations</span></span>

<span data-ttu-id="b13b8-105">この記事では、InputAnimation API について簡単に説明し、UI でこれらの種類のアニメーションを使用するための推奨方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-105">This article provides an introduction to the InputAnimation API, and recommends how to use these types of animations in your UI.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="b13b8-106">前提条件</span><span class="sxs-lookup"><span data-stu-id="b13b8-106">Prerequisites</span></span>

<span data-ttu-id="b13b8-107">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="b13b8-107">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="b13b8-108">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="b13b8-108">Relation based animations</span></span>](relation-animations.md)

## <a name="smooth-motion-driven-from-user-interactions"></a><span data-ttu-id="b13b8-109">ユーザーの操作で駆動するスムーズなモーション</span><span class="sxs-lookup"><span data-stu-id="b13b8-109">Smooth motion driven from user interactions</span></span>

<span data-ttu-id="b13b8-110">Fluent Design 言語では、エンド ユーザーとアプリの間で行われる操作は最も重要なことです。</span><span class="sxs-lookup"><span data-stu-id="b13b8-110">In the Fluent Design language, interaction between end users and apps is of the utmost importance.</span></span> <span data-ttu-id="b13b8-111">アプリは操作の一部に注目していればよいわけではありません。アプリを操作するユーザーに対して、自然で動的な反応をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-111">Apps not only have to look the part, but also respond naturally and dynamically to the users that interact with them.</span></span> <span data-ttu-id="b13b8-112">つまり、指が画面上に置かれた場合、UI は入力の変更の程度に応じて適切に対応する必要があります。スクロールはスムーズに実行し、画面をパンする指を追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-112">This means when a finger is placed on the screen, the UI should gracefully react to changing degrees of input; scrolling should feel smooth, and stick to a finger panning across the screen.</span></span>

<span data-ttu-id="b13b8-113">ユーザー入力に対して動的で滑らかな反応を構築することで、ユーザー エンゲージメントを向上させることができます。現代では、モーションは見栄えが良いだけでなく、ユーザーがさまざまな UI エクスペリエンスを操作する場合に、自然で適切な操作感を実現することが求められます。</span><span class="sxs-lookup"><span data-stu-id="b13b8-113">Building UI that dynamically and fluidly responds to user input results in higher user engagement - Motion now not only looks good, but feels good and natural when users interact with your different UI experiences.</span></span> <span data-ttu-id="b13b8-114">これにより、エンド ユーザーはアプリケーションを簡単に利用できるようになり、エクスペリエンスはより覚えやすく魅力的なものになります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-114">This enables end users to more easily connect with your application, making the experience more memorable and delightful.</span></span>

## <a name="expanding-past-just-touch"></a><span data-ttu-id="b13b8-115">従来のタッチ操作からの拡張</span><span class="sxs-lookup"><span data-stu-id="b13b8-115">Expanding past just touch</span></span>

<span data-ttu-id="b13b8-116">タッチは、エンド ユーザーが UI コンテンツを操作する際に利用する一般的なインターフェイスの 1 つですが、マウスやペンなど他のさまざまな入力方式も使用されます。</span><span class="sxs-lookup"><span data-stu-id="b13b8-116">Although touch is one of the more common interfaces end users use to manipulate UI content, they will also use various other input modalities such mouse and pen.</span></span> <span data-ttu-id="b13b8-117">こうした状況では、使用される入力方式に関係なく、UI が入力に対して動的に反応することをエンド ユーザーが認識できるようにすることが重要となります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-117">In these cases, it is important that end users perceive that your UI responds dynamically to their input, regardless of what input modality they choose to use.</span></span> <span data-ttu-id="b13b8-118">入力駆動型のモーション エクスペリエンスを設計する場合は、さまざまな入力方式を理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-118">You should be cognizant of the different input modalities when designing input-driven motion experiences.</span></span>

## <a name="different-input-driven-motion-experiences"></a><span data-ttu-id="b13b8-119">さまざまな入力駆動型のモーション エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="b13b8-119">Different Input-Driven Motion Experiences</span></span>

<span data-ttu-id="b13b8-120">InputAnimation 領域によって、動的な反応を示すモーションを作成するためさまざまなエクスペリエンスが提供されます。</span><span class="sxs-lookup"><span data-stu-id="b13b8-120">The InputAnimation space provides several different experiences for you to create dynamically responding motion.</span></span> <span data-ttu-id="b13b8-121">他の Windows UI アニメーション システムと同様に、これらの入力駆動型アニメーションは、動的なモーション エクスペリエンスの作成に役立つ独立したスレッド上で動作します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-121">Like the rest of the Windows UI Animation system, these input-driven animations operate on an independent thread, which helps contribute to the dynamic motion experience.</span></span> <span data-ttu-id="b13b8-122">ただし、エクスペリエンスが既存の XAML コントロールとコンポーネントを利用する場合は、それらのエクスペリエンスの構成要素が UI スレッドによって制約を受けます。</span><span class="sxs-lookup"><span data-stu-id="b13b8-122">However, in some cases where the experience leverages existing XAML controls and components, parts of those experiences are still UI thread bound.</span></span>

<span data-ttu-id="b13b8-123">動的な入力駆動型のモーションを示すアニメーションを構築するときに作成する、3 つの主要なエクスペリエンスがあります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-123">There are three core experiences that you create when building dynamic input-driven motion animations:</span></span>

1. <span data-ttu-id="b13b8-124">既存の ScrollView を強化したエクスペリエンス – XAML ScrollViewer の位置によって動的なアニメーション エクスペリエンスを駆動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="b13b8-124">Enhancing Existing ScrollView Experiences – enable the position of a XAML ScrollViewer to drive dynamic animation experiences.</span></span>
1. <span data-ttu-id="b13b8-125">ポインターの位置で駆動するエクスペリエンス – ヒット テストが行われた UIElement 上のカーソル位置を利用して、動的なアニメーション エクスペリエンスを駆動します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-125">Pointer Position-driven Experiences – utilize the position of a cursor on a hit tested UIElement to drive dynamic animation experiences.</span></span>
1. <span data-ttu-id="b13b8-126">InteractionTracker を使用したカスタム操作エクスペリエンス – InteractionTracker を使用して、完全にカスタマイズされた、オフスレッドの操作エクスペリエンスを作成します (スクロールやズームが可能なキャンバスなど)。</span><span class="sxs-lookup"><span data-stu-id="b13b8-126">Custom Manipulation experiences with InteractionTracker – create a fully customized, off-thread manipulation experiences with InteractionTracker (such as a scrolling/zooming canvas).</span></span>

## <a name="enhancing-existing-scrollviewer-experiences"></a><span data-ttu-id="b13b8-127">既存の ScrollViewer を強化したエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="b13b8-127">Enhancing Existing ScrollViewer Experiences</span></span>

<span data-ttu-id="b13b8-128">より動的なエクスペリエンスを作成するための一般的な方法の 1 つとして、既存の XAML ScrollViewer コントロールの最上位に構築する方法があります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-128">One of the common ways to create more dynamic experiences is to build on top of an existing XAML ScrollViewer control.</span></span> <span data-ttu-id="b13b8-129">このような方法では、ScrollViewer のスクロール位置を利用して、単純なスクロール エクスペリエンスをより動的なものにする追加の UI コンポーネントを作成します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-129">In these situations, you leverage the scroll position of a ScrollViewer to create additional UI components that make a simple scrolling experience more dynamic.</span></span> <span data-ttu-id="b13b8-130">これらのエクスペリエンスの例として、固定ヘッダー/シャイ ヘッダー、視差などがあります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-130">Some examples include Sticky/Shy Headers and Parallax.</span></span>

![視差を利用したリスト ビュー](images/animation/parallax.gif)

![シャイ ヘッダー](images/animation/shy-header.gif)

<span data-ttu-id="b13b8-133">このような種類のエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。</span><span class="sxs-lookup"><span data-stu-id="b13b8-133">When creating these types of experiences, there is a general formula to follow:</span></span>

1. <span data-ttu-id="b13b8-134">アニメーションを駆動する XAML ScrollViewer から ScrollManipulationPropertySet にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b13b8-134">Access the ScrollManipulationPropertySet off of the XAML ScrollViewer you wish to drive an animation.</span></span>
    - <span data-ttu-id="b13b8-135">ElementCompositionPreview.GetScrollViewerManipulationPropertySet(UIElement 要素) API を使用してアクセスします</span><span class="sxs-lookup"><span data-stu-id="b13b8-135">Done via the ElementCompositionPreview.GetScrollViewerManipulationPropertySet(UIElement element) API</span></span>
    - <span data-ttu-id="b13b8-136">**Translation** と呼ばれるプロパティを含んでいる CompositionPropertySet が返されます</span><span class="sxs-lookup"><span data-stu-id="b13b8-136">Returns a CompositionPropertySet containing a property called **Translation**</span></span>
1. <span data-ttu-id="b13b8-137">Translation プロパティを参照する式を使用して、Composition の ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-137">Create a Composition ExpressionAnimation with an equation that references the Translation property.</span></span>
1. <span data-ttu-id="b13b8-138">CompositionObject のプロパティでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-138">Start the animation on a CompositionObject’s property.</span></span>

<span data-ttu-id="b13b8-139">これらのエクスペリエンスの作成方法について詳しくは、「[既存の ScrollViewer エクスペリエンスを強化する](scroll-input-animations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b13b8-139">For more info on building these experiences, see [Enhance existing ScrollViewer experiences](scroll-input-animations.md).</span></span>

## <a name="pointer-position-driven-experiences"></a><span data-ttu-id="b13b8-140">ポインターの位置で駆動するエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="b13b8-140">Pointer Position-driven experiences</span></span>

<span data-ttu-id="b13b8-141">よく利用される動的なエクスペリエンスの 1 つです。入力を使用し、マウス カーソルなどのポインターの位置に基づいてアニメーションを駆動します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-141">Another common dynamic experience involving input is to drive an animation based on the position of a pointer such as a Mouse cursor.</span></span> <span data-ttu-id="b13b8-142">このようなエクスペリエンスでは、開発者は、スポットライト表示のようなエクスペリエンスの作成を可能にする XAML UIElement でヒット テストが行われたときのカーソルの位置を利用します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-142">In these situations, developers leverage the location of a cursor when hit tested within a XAML UIElement that makes experiences like Spotlight Reveal possible to create.</span></span>

![ポインター スポットライトの例](images/animation/spotlight-reveal.gif)

![ポインターに基づく回転の例](images/animation/pointer-rotate.gif)

<span data-ttu-id="b13b8-145">このような種類のエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。</span><span class="sxs-lookup"><span data-stu-id="b13b8-145">When creating these types of experiences, there is a general formula to follow:</span></span>

1. <span data-ttu-id="b13b8-146">ヒット テストが行われたときにカーソルの位置を把握するための XAML UIElement から PointerPositionPropertySet にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="b13b8-146">Access the PointerPositionPropertySet off a XAML UIElement that you wish to know the cursor position when hit tested.</span></span>
    - <span data-ttu-id="b13b8-147">ElementCompositionPreview.GetPointerPositionPropertySet(UIElement 要素) API を使用してアクセスします</span><span class="sxs-lookup"><span data-stu-id="b13b8-147">Done via the ElementCompositionPreview.GetPointerPositionPropertySet(UIElement element) API</span></span>
    - <span data-ttu-id="b13b8-148">**Position** と呼ばれるプロパティを含んでいる CompositionPropertySet が返されます</span><span class="sxs-lookup"><span data-stu-id="b13b8-148">Returns a CompositionPropertySet containing a property called **Position**</span></span>
1. <span data-ttu-id="b13b8-149">Position プロパティを参照する式を使用して、CompositionExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-149">Create a CompositionExpressionAnimation with an equation that references the Position property.</span></span>
1. <span data-ttu-id="b13b8-150">CompositionObject のプロパティでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-150">Start the animation on a CompositionObject’s property.</span></span>

## <a name="custom-manipulation-experiences-with-interactiontracker"></a><span data-ttu-id="b13b8-151">InteractionTracker を使用したカスタム操作エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="b13b8-151">Custom manipulation experiences with InteractionTracker</span></span>

<span data-ttu-id="b13b8-152">XAML ScrollViewer を利用する際の問題の 1 つは、UI スレッドによって制約を受けるということです。</span><span class="sxs-lookup"><span data-stu-id="b13b8-152">One of the challenges with utilizing a XAML ScrollViewer is that it is bound to the UI thread.</span></span> <span data-ttu-id="b13b8-153">そのため、UI スレッドがビジー状態になると、スクロールやズームのエクスペリエンスで遅延やジッターが発生する場合があり、その結果、ユーザーの興味を引かないエクスペリエンスとなってしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b13b8-153">As a result, the scrolling and zooming experience can often lag and jitter if the UI thread becomes busy and results in an unappealing experience.</span></span> <span data-ttu-id="b13b8-154">また、ScrollViewer エクスペリエンスの多くの側面はカスタマイズすることができません。</span><span class="sxs-lookup"><span data-stu-id="b13b8-154">In addition, it is not possible to customize many aspects of the ScrollViewer experience.</span></span> <span data-ttu-id="b13b8-155">InteractionTracker は、これらの問題を解決するために作成されました。そのために、独立したスレッド上で実行されるカスタム操作エクスペリエンスを作成するための構成要素のセットが提供されます。</span><span class="sxs-lookup"><span data-stu-id="b13b8-155">InteractionTracker was created to solve both issues by providing a set of building blocks to create custom manipulation experiences that are run on an independent thread.</span></span>

![3D 操作の例](images/animation/interactions-3d.gif)

![引き出されるようなアニメーション化の例](images/animation/pull-to-animate.gif)

<span data-ttu-id="b13b8-158">InteractionTracker を使用してエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。</span><span class="sxs-lookup"><span data-stu-id="b13b8-158">When creating experiences with InteractionTracker, there is a general formula to follow:</span></span>

1. <span data-ttu-id="b13b8-159">InteractionTracker オブジェクトを作成し、そのプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-159">Create your InteractionTracker object and define its properties.</span></span>
1. <span data-ttu-id="b13b8-160">InteractionTracker で使用される入力をキャプチャする CompositionVisual 用の VisualInteractionSources を作成します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-160">Create VisualInteractionSources for any CompositionVisual that should capture input for InteractionTracker to consume.</span></span>
1. <span data-ttu-id="b13b8-161">InteractionTracker の Position プロパティを参照する式を使用して、Composition の ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-161">Create a Composition ExpressionAnimation with an equation that references the Position property of InteractionTracker.</span></span>
1. <span data-ttu-id="b13b8-162">InteractionTracker で駆動される、Composition の Visual のプロパティでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="b13b8-162">Start the animation on a Composition Visual’s property that you wish to be driven by InteractionTracker.</span></span>
