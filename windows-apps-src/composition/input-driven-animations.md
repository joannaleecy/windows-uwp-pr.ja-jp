---
author: jwmsft
title: "入力駆動型アニメーション"
description: 
ms.author: jimwalk
ms.date: 10/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, アニメーション"
ms.localizationpriority: medium
ms.openlocfilehash: 24e5378d27ea5ce80f317ab951f1a19aa5f87b9b
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
---
# <a name="input-driven-animations"></a><span data-ttu-id="d7afb-103">入力駆動型アニメーション</span><span class="sxs-lookup"><span data-stu-id="d7afb-103">Input-driven animations</span></span>

<span data-ttu-id="d7afb-104">この記事では、InputAnimation API について簡単に説明し、UI でこれらの種類のアニメーションを使用するための推奨方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-104">This article provides an introduction to the InputAnimation API, and recommends how to use these types of animations in your UI.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="d7afb-105">前提条件</span><span class="sxs-lookup"><span data-stu-id="d7afb-105">Prerequisites</span></span>

<span data-ttu-id="d7afb-106">ここでは、以下の記事で説明されている概念を理解していることを前提とします。</span><span class="sxs-lookup"><span data-stu-id="d7afb-106">Here, we assume that you're familiar with the concepts discussed in these articles:</span></span>

- [<span data-ttu-id="d7afb-107">関係ベース アニメーション</span><span class="sxs-lookup"><span data-stu-id="d7afb-107">Relation based animations</span></span>](relation-animations.md)

## <a name="smooth-motion-driven-from-user-interactions"></a><span data-ttu-id="d7afb-108">ユーザーの操作で駆動するスムーズなモーション</span><span class="sxs-lookup"><span data-stu-id="d7afb-108">Smooth motion driven from user interactions</span></span>

<span data-ttu-id="d7afb-109">Fluent Design 言語では、エンド ユーザーとアプリの間で行われる操作は最も重要なことです。</span><span class="sxs-lookup"><span data-stu-id="d7afb-109">In the Fluent Design language, interaction between end users and apps is of the utmost importance.</span></span> <span data-ttu-id="d7afb-110">アプリは操作の一部に注目していればよいわけではありません。アプリを操作するユーザーに対して、自然で動的な反応をする必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-110">Apps not only have to look the part, but also respond naturally and dynamically to the users that interact with them.</span></span> <span data-ttu-id="d7afb-111">つまり、指が画面上に置かれた場合、UI は入力の変更の程度に応じて適切に対応する必要があります。スクロールはスムーズに実行し、画面をパンする指を追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-111">This means when a finger is placed on the screen, the UI should gracefully react to changing degrees of input; scrolling should feel smooth, and stick to a finger panning across the screen.</span></span>

<span data-ttu-id="d7afb-112">ユーザー入力に対して動的で滑らかな反応を構築することで、ユーザー エンゲージメントを向上させることができます。現代では、モーションは見栄えが良いだけでなく、ユーザーがさまざまな UI エクスペリエンスを操作する場合に、自然で適切な操作感を実現することが求められます。</span><span class="sxs-lookup"><span data-stu-id="d7afb-112">Building UI that dynamically and fluidly responds to user input results in higher user engagement - Motion now not only looks good, but feels good and natural when users interact with your different UI experiences.</span></span> <span data-ttu-id="d7afb-113">これにより、エンド ユーザーはアプリケーションを簡単に利用できるようになり、エクスペリエンスはより覚えやすく魅力的なものになります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-113">This enables end users to more easily connect with your application, making the experience more memorable and delightful.</span></span>

## <a name="expanding-past-just-touch"></a><span data-ttu-id="d7afb-114">従来のタッチ操作からの拡張</span><span class="sxs-lookup"><span data-stu-id="d7afb-114">Expanding past just touch</span></span>

<span data-ttu-id="d7afb-115">タッチは、エンド ユーザーが UI コンテンツを操作する際に利用する一般的なインターフェイスの 1 つですが、マウスやペンなど他のさまざまな入力方式も使用されます。</span><span class="sxs-lookup"><span data-stu-id="d7afb-115">Although touch is one of the more common interfaces end users use to manipulate UI content, they will also use various other input modalities such mouse and pen.</span></span> <span data-ttu-id="d7afb-116">こうした状況では、使用される入力方式に関係なく、UI が入力に対して動的に反応することをエンド ユーザーが認識できるようにすることが重要となります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-116">In these cases, it is important that end users perceive that your UI responds dynamically to their input, regardless of what input modality they choose to use.</span></span> <span data-ttu-id="d7afb-117">入力駆動型のモーション エクスペリエンスを設計する場合は、さまざまな入力方式を理解している必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-117">You should be cognizant of the different input modalities when designing input-driven motion experiences.</span></span>

## <a name="different-input-driven-motion-experiences"></a><span data-ttu-id="d7afb-118">さまざまな入力駆動型のモーション エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="d7afb-118">Different Input-Driven Motion Experiences</span></span>

<span data-ttu-id="d7afb-119">InputAnimation 領域によって、動的な反応を示すモーションを作成するためさまざまなエクスペリエンスが提供されます。</span><span class="sxs-lookup"><span data-stu-id="d7afb-119">The InputAnimation space provides several different experiences for you to create dynamically responding motion.</span></span> <span data-ttu-id="d7afb-120">他の Windows UI アニメーション システムと同様に、これらの入力駆動型アニメーションは、動的なモーション エクスペリエンスの作成に役立つ独立したスレッド上で動作します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-120">Like the rest of the Windows UI Animation system, these input-driven animations operate on an independent thread, which helps contribute to the dynamic motion experience.</span></span> <span data-ttu-id="d7afb-121">ただし、エクスペリエンスが既存の XAML コントロールとコンポーネントを利用する場合は、それらのエクスペリエンスの構成要素が UI スレッドによって制約を受けます。</span><span class="sxs-lookup"><span data-stu-id="d7afb-121">However, in some cases where the experience leverages existing XAML controls and components, parts of those experiences are still UI thread bound.</span></span>

<span data-ttu-id="d7afb-122">動的な入力駆動型のモーションを示すアニメーションを構築するときに作成する、3 つの主要なエクスペリエンスがあります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-122">There are three core experiences that you create when building dynamic input-driven motion animations:</span></span>

1. <span data-ttu-id="d7afb-123">既存の ScrollView を強化したエクスペリエンス – XAML ScrollViewer の位置によって動的なアニメーション エクスペリエンスを駆動できるようにします。</span><span class="sxs-lookup"><span data-stu-id="d7afb-123">Enhancing Existing ScrollView Experiences – enable the position of a XAML ScrollViewer to drive dynamic animation experiences.</span></span>
1. <span data-ttu-id="d7afb-124">ポインターの位置で駆動するエクスペリエンス – ヒット テストが行われた UIElement 上のカーソル位置を利用して、動的なアニメーション エクスペリエンスを駆動します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-124">Pointer Position-driven Experiences – utilize the position of a cursor on a hit tested UIElement to drive dynamic animation experiences.</span></span>
1. <span data-ttu-id="d7afb-125">InteractionTracker を使用したカスタム操作エクスペリエンス – InteractionTracker を使用して、完全にカスタマイズされた、オフスレッドの操作エクスペリエンスを作成します (スクロールやズームが可能なキャンバスなど)。</span><span class="sxs-lookup"><span data-stu-id="d7afb-125">Custom Manipulation experiences with InteractionTracker – create a fully customized, off-thread manipulation experiences with InteractionTracker (such as a scrolling/zooming canvas).</span></span>

## <a name="enhancing-existing-scrollviewer-experiences"></a><span data-ttu-id="d7afb-126">既存の ScrollViewer を強化したエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="d7afb-126">Enhancing Existing ScrollViewer Experiences</span></span>

<span data-ttu-id="d7afb-127">より動的なエクスペリエンスを作成するための一般的な方法の 1 つとして、既存の XAML ScrollViewer コントロールの最上位に構築する方法があります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-127">One of the common ways to create more dynamic experiences is to build on top of an existing XAML ScrollViewer control.</span></span> <span data-ttu-id="d7afb-128">このような方法では、ScrollViewer のスクロール位置を利用して、単純なスクロール エクスペリエンスをより動的なものにする追加の UI コンポーネントを作成します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-128">In these situations, you leverage the scroll position of a ScrollViewer to create additional UI components that make a simple scrolling experience more dynamic.</span></span> <span data-ttu-id="d7afb-129">これらのエクスペリエンスの例として、固定ヘッダー/シャイ ヘッダー、視差などがあります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-129">Some examples include Sticky/Shy Headers and Parallax.</span></span>

![視差を利用したリスト ビュー](images/animation/parallax.gif)

![シャイ ヘッダー](images/animation/shy-header.gif)

<span data-ttu-id="d7afb-132">このような種類のエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。</span><span class="sxs-lookup"><span data-stu-id="d7afb-132">When creating these types of experiences, there is a general formula to follow:</span></span>

1. <span data-ttu-id="d7afb-133">アニメーションを駆動する XAML ScrollViewer から ScrollManipulationPropertySet にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d7afb-133">Access the ScrollManipulationPropertySet off of the XAML ScrollViewer you wish to drive an animation.</span></span>
    - <span data-ttu-id="d7afb-134">ElementCompositionPreview.GetScrollViewerManipulationPropertySet(UIElement 要素) API を使用してアクセスします</span><span class="sxs-lookup"><span data-stu-id="d7afb-134">Done via the ElementCompositionPreview.GetScrollViewerManipulationPropertySet(UIElement element) API</span></span>
    - <span data-ttu-id="d7afb-135">**Translation** と呼ばれるプロパティを含んでいる CompositionPropertySet が返されます</span><span class="sxs-lookup"><span data-stu-id="d7afb-135">Returns a CompositionPropertySet containing a property called **Translation**</span></span>
1. <span data-ttu-id="d7afb-136">Translation プロパティを参照する式を使用して、Composition の ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-136">Create a Composition ExpressionAnimation with an equation that references the Translation property.</span></span>
1. <span data-ttu-id="d7afb-137">CompositionObject のプロパティでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-137">Start the animation on a CompositionObject’s property.</span></span>

<span data-ttu-id="d7afb-138">これらのエクスペリエンスの作成方法について詳しくは、「[既存の ScrollViewer エクスペリエンスを強化する](scroll-input-animations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d7afb-138">For more info on building these experiences, see [Enhance existing ScrollViewer experiences](scroll-input-animations.md).</span></span>

## <a name="pointer-position-driven-experiences"></a><span data-ttu-id="d7afb-139">ポインターの位置で駆動するエクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="d7afb-139">Pointer Position-driven experiences</span></span>

<span data-ttu-id="d7afb-140">よく利用される動的なエクスペリエンスの 1 つです。入力を使用し、マウス カーソルなどのポインターの位置に基づいてアニメーションを駆動します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-140">Another common dynamic experience involving input is to drive an animation based on the position of a pointer such as a Mouse cursor.</span></span> <span data-ttu-id="d7afb-141">このようなエクスペリエンスでは、開発者は、スポットライト表示のようなエクスペリエンスの作成を可能にする XAML UIElement でヒット テストが行われたときのカーソルの位置を利用します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-141">In these situations, developers leverage the location of a cursor when hit tested within a XAML UIElement that makes experiences like Spotlight Reveal possible to create.</span></span>

![ポインター スポットライトの例](images/animation/spotlight-reveal.gif)

![ポインターに基づく回転の例](images/animation/pointer-rotate.gif)

<span data-ttu-id="d7afb-144">このような種類のエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。</span><span class="sxs-lookup"><span data-stu-id="d7afb-144">When creating these types of experiences, there is a general formula to follow:</span></span>

1. <span data-ttu-id="d7afb-145">ヒット テストが行われたときにカーソルの位置を把握するための XAML UIElement から PointerPositionPropertySet にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="d7afb-145">Access the PointerPositionPropertySet off a XAML UIElement that you wish to know the cursor position when hit tested.</span></span>
    - <span data-ttu-id="d7afb-146">ElementCompositionPreview.GetPointerPositionPropertySet(UIElement 要素) API を使用してアクセスします</span><span class="sxs-lookup"><span data-stu-id="d7afb-146">Done via the ElementCompositionPreview.GetPointerPositionPropertySet(UIElement element) API</span></span>
    - <span data-ttu-id="d7afb-147">**Position** と呼ばれるプロパティを含んでいる CompositionPropertySet が返されます</span><span class="sxs-lookup"><span data-stu-id="d7afb-147">Returns a CompositionPropertySet containing a property called **Position**</span></span>
1. <span data-ttu-id="d7afb-148">Position プロパティを参照する式を使用して、CompositionExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-148">Create a CompositionExpressionAnimation with an equation that references the Position property.</span></span>
1. <span data-ttu-id="d7afb-149">CompositionObject のプロパティでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-149">Start the animation on a CompositionObject’s property.</span></span>

## <a name="custom-manipulation-experiences-with-interactiontracker"></a><span data-ttu-id="d7afb-150">InteractionTracker を使用したカスタム操作エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="d7afb-150">Custom manipulation experiences with InteractionTracker</span></span>

<span data-ttu-id="d7afb-151">XAML ScrollViewer を利用する際の問題の 1 つは、UI スレッドによって制約を受けるということです。</span><span class="sxs-lookup"><span data-stu-id="d7afb-151">One of the challenges with utilizing a XAML ScrollViewer is that it is bound to the UI thread.</span></span> <span data-ttu-id="d7afb-152">そのため、UI スレッドがビジー状態になると、スクロールやズームのエクスペリエンスで遅延やジッターが発生する場合があり、その結果、ユーザーの興味を引かないエクスペリエンスとなってしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d7afb-152">As a result, the scrolling and zooming experience can often lag and jitter if the UI thread becomes busy and results in an unappealing experience.</span></span> <span data-ttu-id="d7afb-153">また、ScrollViewer エクスペリエンスの多くの側面はカスタマイズすることができません。</span><span class="sxs-lookup"><span data-stu-id="d7afb-153">In addition, it is not possible to customize many aspects of the ScrollViewer experience.</span></span> <span data-ttu-id="d7afb-154">InteractionTracker は、これらの問題を解決するために作成されました。そのために、独立したスレッド上で実行されるカスタム操作エクスペリエンスを作成するための構成要素のセットが提供されます。</span><span class="sxs-lookup"><span data-stu-id="d7afb-154">InteractionTracker was created to solve both issues by providing a set of building blocks to create custom manipulation experiences that are run on an independent thread.</span></span>

![3D 操作の例](images/animation/interactions-3d.gif)

![引き出されるようなアニメーション化の例](images/animation/pull-to-animate.gif)

<span data-ttu-id="d7afb-157">InteractionTracker を使用してエクスペリエンスを作成するときは、以下の一般的な方法に従ってください。</span><span class="sxs-lookup"><span data-stu-id="d7afb-157">When creating experiences with InteractionTracker, there is a general formula to follow:</span></span>

1. <span data-ttu-id="d7afb-158">InteractionTracker オブジェクトを作成し、そのプロパティを定義します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-158">Create your InteractionTracker object and define its properties.</span></span>
1. <span data-ttu-id="d7afb-159">InteractionTracker で使用される入力をキャプチャする CompositionVisual 用の VisualInteractionSources を作成します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-159">Create VisualInteractionSources for any CompositionVisual that should capture input for InteractionTracker to consume.</span></span>
1. <span data-ttu-id="d7afb-160">InteractionTracker の Position プロパティを参照する式を使用して、Composition の ExpressionAnimation を作成します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-160">Create a Composition ExpressionAnimation with an equation that references the Position property of InteractionTracker.</span></span>
1. <span data-ttu-id="d7afb-161">InteractionTracker で駆動される、Composition の Visual のプロパティでアニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="d7afb-161">Start the animation on a Composition Visual’s property that you wish to be driven by InteractionTracker.</span></span>
