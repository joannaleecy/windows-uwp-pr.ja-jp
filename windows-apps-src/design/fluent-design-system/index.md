---
description: Fluent Design とアプリに組み込む方法について学習します。
title: UWP アプリ用の Fluent Design System
author: mijacobs
keywords: UWP アプリのレイアウト, ユニバーサル Windows プラットフォーム, アプリの設計, インターフェイス, Fluent Design System
ms.author: mijacobs
ms.date: 3/7/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: high
ms.openlocfilehash: 5b57dc2ddae4c6e260df663097db5649866b96aa
ms.sourcegitcommit: ef5a1e1807313a2caa9c9b35ea20b129ff7155d0
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/08/2018
ms.locfileid: "1638790"
---
# <a name="the-fluent-design-system-for-uwp-apps"></a><span data-ttu-id="2b825-104">UWP アプリ用の Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="2b825-104">The Fluent Design System for UWP apps</span></span>

## <a name="introduction"></a><span data-ttu-id="2b825-105">概要</span><span class="sxs-lookup"><span data-stu-id="2b825-105">Introduction</span></span>

<img src="images/fluentdesign-app-header.jpg" alt=" " />

<span data-ttu-id="2b825-106">ユーザー インターフェイスが進化しました。</span><span class="sxs-lookup"><span data-stu-id="2b825-106">The user interface is evolving.</span></span> <span data-ttu-id="2b825-107">2D から 3D 以上へ、キーボードとマウスから視線、ペン、タッチへ、次元とインターフェイスが新しく拡張されました。</span><span class="sxs-lookup"><span data-stu-id="2b825-107">It's expanding to include new dimensions and interfaces, from 2D to 3D and beyond, from keyboard and mouse to gaze, pen, and touch.</span></span>  

<span data-ttu-id="2b825-108">Fluent Design System は、すべての種類の Windows デバイスで適切に動作するアプリを作成するためのベスト プラクティスと組み合わされた、革新的な UWP 機能のセットです。</span><span class="sxs-lookup"><span data-stu-id="2b825-108">The Fluent Design System is a set of innovative UWP features combined with best practices for creating apps that perform beautifully on all types of Windows-powered devices.</span></span>

<span data-ttu-id="2b825-109">順応性が高く、親近感があり、優れた美しさを持つユーザー インターフェイスを作成するためのシステムです。</span><span class="sxs-lookup"><span data-stu-id="2b825-109">It's our system for creating adaptive, empathetic, and beautiful user interfaces.</span></span> 

**<span data-ttu-id="2b825-110">順応性: 各デバイスで自然な Fluent エクスペリエンスを得られる</span><span class="sxs-lookup"><span data-stu-id="2b825-110">Adaptive: Fluent experiences feel natural on each device</span></span>**

<span data-ttu-id="2b825-111">Fluent エクスペリエンスは環境に適応します。</span><span class="sxs-lookup"><span data-stu-id="2b825-111">Fluent experiences adapt to the environment.</span></span> <span data-ttu-id="2b825-112">タブレット、デスクトップ PC、Xbox で軽快な Fluent エクスペリエンスを得られます。また、Mixed Reality ヘッドセットでの動作も優れています。</span><span class="sxs-lookup"><span data-stu-id="2b825-112">A Fluent experience feels comfortable on a tablet, a desktop PC, and an Xbox&mdash;it even works great on a Mixed Reality headset.</span></span> <span data-ttu-id="2b825-113">PC の追加モニターなど、多くのハードウェアを追加しても、Fluent エクスペリエンスでそれらを活用できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-113">And when you add more hardware, like an additional monitor for your PC, a Fluent experience takes advantage of it.</span></span> 

**<span data-ttu-id="2b825-114">親近感: Fluent エクスペリエンスは直感的で、強力である</span><span class="sxs-lookup"><span data-stu-id="2b825-114">Empathetic: Fluent experiences are intuitive and powerful</span></span>**

<span data-ttu-id="2b825-115">Fluent エクスペリエンスは動作と意図を読み取ります。すなわち、必要なものを把握および予想します。</span><span class="sxs-lookup"><span data-stu-id="2b825-115">Fluent experiences adjust to behavior and intent&mdash;they understand and anticipate what’s needed.</span></span> <span data-ttu-id="2b825-116">ユーザーとアイデアが物理的に離れているかどうかに関係なく、それらを統合します。</span><span class="sxs-lookup"><span data-stu-id="2b825-116">They unite people and ideas, whether they’re on opposite sides of the globe or standing right next to each other.</span></span> 

<span data-ttu-id="2b825-117">共感を得るには、適切なタイミングで適切な処理を行います。</span><span class="sxs-lookup"><span data-stu-id="2b825-117">Demonstrating empathy is about doing the right thing at the right time.</span></span> 

<span data-ttu-id="2b825-118">Fluent エクスペリエンスは一貫性のあるコントロールとパターンを使用するため、ユーザーが学習したとおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="2b825-118">Fluent experiences use controls and patterns consistently, so they behave in ways the user has learned to expect.</span></span> <span data-ttu-id="2b825-119">Fluent エクスペリエンスでは幅広い物理的な機能を使用してユーザーにアクセスします。グローバリゼーション機能が組み込まれているため、世界中のユーザーが使用することができます。</span><span class="sxs-lookup"><span data-stu-id="2b825-119">Fluent experiences are accessible to people with a wide range of physical abilities, and incorporate globalization features so people around the world can use them.</span></span> 

**<span data-ttu-id="2b825-120">美しさ: Fluent エクスペリエンスは魅力的で、臨場感がある</span><span class="sxs-lookup"><span data-stu-id="2b825-120">Beautiful: Fluent experiences are engaging and immersive</span></span>** 

<span data-ttu-id="2b825-121">現実世界の要素を組み込むことで、Fluent エクスペリエンスでは基本的な機能を活用できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-121">By incorporating elements of the physical world, a Fluent experience taps into something fundamental.</span></span> <span data-ttu-id="2b825-122">直感的かつ本能的に情報を整理できるように、ライト、影、モーション、深度、テクスチャを使用します。</span><span class="sxs-lookup"><span data-stu-id="2b825-122">It uses light, shadow, motion, depth, and texture to organize information in a way that feels intuitive and instinctual.</span></span> 

<span data-ttu-id="2b825-123">Fluent Design に派手な効果はありません。</span><span class="sxs-lookup"><span data-stu-id="2b825-123">Fluent Design isn't about flashy effects.</span></span> <span data-ttu-id="2b825-124">脳で効率的に処理するようにプログラムされたエクスペリエンスをエミュレートするため、ユーザー エクスペリエンスを拡張する物理的な効果が組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="2b825-124">It incorporates physical effects that truly enhance the user experience, because they emulate experiences that our brains are programmed to process efficiently.</span></span> 

## <a name="applying-fluent-design-to-your-app"></a><span data-ttu-id="2b825-125">アプリへの Fluent Design の適用</span><span class="sxs-lookup"><span data-stu-id="2b825-125">Applying Fluent Design to your app</span></span>

<span data-ttu-id="2b825-126">Fluent Design 機能は UWP に組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="2b825-126">Fluent Design features are built into UWP.</span></span> <span data-ttu-id="2b825-127">これらの機能のいくつか (有効ピクセルやユニバーサル入力システムなど) は、自動的に取り込まれます。</span><span class="sxs-lookup"><span data-stu-id="2b825-127">Some of these features&mdash;such as effective pixels and the universal input system&mdash;are automatic.</span></span> <span data-ttu-id="2b825-128">これらの機能を利用するために追加のコードを記述する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="2b825-128">You don't have to write any extra code to take advantage of them.</span></span> <span data-ttu-id="2b825-129">他の機能 (アクリル効果など) はオプションであり、それらの機能をアプリに取り込むには、機能を追加するためのコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="2b825-129">Other features, like acrylic, are optional; you add them to your app by writing code to include them.</span></span> 

> <span data-ttu-id="2b825-130">すべての UWP アプリに自動的に取り込まれる基本機能について詳しくは、[UWP アプリ設計の概要に関する記事](../basics/design-and-ui-intro.md)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="2b825-130">To learn more about the basic features that are automatically included in every UWP app, see the [Intro to UWP app design article](../basics/design-and-ui-intro.md).</span></span> <span data-ttu-id="2b825-131">UWP の開発が初めての場合は、最初に [UWP の概要ページ](https://developer.microsoft.com/windows/apps/getstarted)を確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2b825-131">If you're completely new to UWP development, you might want to check out our [Get started with UWP page](https://developer.microsoft.com/windows/apps/getstarted) first.</span></span> 

<span data-ttu-id="2b825-132">Fluent Design をアプリに組み込む際に役立つ新しい機能について詳しくは、以下をお読みください。</span><span class="sxs-lookup"><span data-stu-id="2b825-132">To learn more about the new features that help you incorporate Fluent Design into your app, keep reading.</span></span>

## <a name="find-a-natural-fit"></a><span data-ttu-id="2b825-133">最適なデザインを見つける</span><span class="sxs-lookup"><span data-stu-id="2b825-133">Find a natural fit</span></span>

<span data-ttu-id="2b825-134">さまざまなデバイスでアプリを自然に操作してもらうにはどのようにすればいいですか?</span><span class="sxs-lookup"><span data-stu-id="2b825-134">How do you make an app feel natural on a variety of devices?</span></span> <span data-ttu-id="2b825-135">それぞれのデバイスに合わせて設計されたように感じさせることです。</span><span class="sxs-lookup"><span data-stu-id="2b825-135">By making it feel as though it were designed with each specific device in mind.</span></span> <span data-ttu-id="2b825-136">無駄な領域がなく (密集しない)、異なる画面サイズに対応する UI レイアウトでは、使用するデバイス用に設計されたかのような自然な使用感を得られます。</span><span class="sxs-lookup"><span data-stu-id="2b825-136">A UI layout that adapts to different screen sizes&mdash;so there's no wasted space (but no crowding either)&mdash;makes an experience feel natural, as though it were designed for that device.</span></span> 

*  **<span data-ttu-id="2b825-137">適切なブレークポイントの設計</span><span class="sxs-lookup"><span data-stu-id="2b825-137">Design for the right breakpoints</span></span>**

    <span data-ttu-id="2b825-138">それぞれの画面サイズに合わせて設計する代わりに、いくつかの主要な幅 ("ブレークポイント" とも呼ばれる) に注目すると、設計とコードが非常に簡単になり、大小の画面に対応する魅力的なアプリを作成できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-138">Instead of designing for every individual screen size, focusing on a few key widths (also called "breakpoints") can greatly simplify your designs and code while still making your app look great on small to large screens.</span></span>

    [<span data-ttu-id="2b825-139">画面のサイズとブレークポイントの詳細</span><span class="sxs-lookup"><span data-stu-id="2b825-139">Learn about screen sizes and breakpoints</span></span>](/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)

*  **<span data-ttu-id="2b825-140">レスポンシブ レイアウトの作成</span><span class="sxs-lookup"><span data-stu-id="2b825-140">Create a responsive layout</span></span>**

    <span data-ttu-id="2b825-141">アプリの自然な使用感を得るには、密集していると感じないように余分な画面領域を埋める必要があります。</span><span class="sxs-lookup"><span data-stu-id="2b825-141">For an app to feel natural, it needs to fill the available display space without seeming too crowded.</span></span> <span data-ttu-id="2b825-142">UWP には、グリッド、スタック、フローでコンテンツを配置するパネルがあり、各パネルを入れ子にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="2b825-142">UWP provides panels that arrange content in grids, stacks, and flows, and you can nest them inside each other.</span></span>

    [<span data-ttu-id="2b825-143">UWP のレイアウト パネルの詳細</span><span class="sxs-lookup"><span data-stu-id="2b825-143">Learn about UWP's layout panels</span></span>](/windows/uwp/design/layout/layout-panels)

* **<span data-ttu-id="2b825-144">多様なデバイスの設計</span><span class="sxs-lookup"><span data-stu-id="2b825-144">Design for a spectrum of devices</span></span>**

    <span data-ttu-id="2b825-145">UWP アプリはさまざまな Windows ベースのデバイスで実行できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-145">UWP apps can run on a wide variety of Windows-powered devices.</span></span> <span data-ttu-id="2b825-146">これは、利用可能なデバイス、デバイスの利用目的、デバイスの操作方法を理解するのに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="2b825-146">It's helpful to understand which devices are available, what they're made for, and how users interact with them.</span></span>

    [<span data-ttu-id="2b825-147">UWP デバイスの詳細</span><span class="sxs-lookup"><span data-stu-id="2b825-147">Learn about UWP devices</span></span>](/windows/uwp/design/devices/)

* **<span data-ttu-id="2b825-148">入力方法に合わせた最適化</span><span class="sxs-lookup"><span data-stu-id="2b825-148">Optimize for the right input</span></span>**

    <span data-ttu-id="2b825-149">UWP アプリは、一般的なマウス、キーボード、ペンを自動的にサポートします。つまり、余分な操作をする必要がありません。</span><span class="sxs-lookup"><span data-stu-id="2b825-149">UWP apps automatically support common mouse, keyboard, pen, and touch interactions&mdash;there's nothing extra you have to do.</span></span> <span data-ttu-id="2b825-150">ただし、ペンや Surface Dial など、特定の入力方法に合わせてサポートを最適化することで、アプリの機能を強化することができます。</span><span class="sxs-lookup"><span data-stu-id="2b825-150">But you can enhance your app with optimized support for specific inputs, like pen and the Surface Dial.</span></span>

    [<span data-ttu-id="2b825-151">入力方法と操作方法の詳細</span><span class="sxs-lookup"><span data-stu-id="2b825-151">Learn about inputs and interactions</span></span>](/windows/uwp/design/input/input-primer)


## <a name="make-it-intuitive-and-powerful"></a><span data-ttu-id="2b825-152">直感的で強力なものにする</span><span class="sxs-lookup"><span data-stu-id="2b825-152">Make it intuitive and powerful</span></span>

<span data-ttu-id="2b825-153">ユーザーの想像のとおりに動作するため、直観的に操作できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-153">An experience feels intuitive when it behaves that way the user expects it to.</span></span> <span data-ttu-id="2b825-154">アクセシビリティとグローバリゼーションを実現するためにコントロールとパターンを確立し、プラットフォーム サポートを活用することで、操作の手間が省け、生産性が向上します。</span><span class="sxs-lookup"><span data-stu-id="2b825-154">By using established controls and patterns and taking advantage of platform support for accessibility and globalization, you create an effortless experience that helps users be more productive.</span></span> 

* **<span data-ttu-id="2b825-155">ジョブに最適なコントロールの使用</span><span class="sxs-lookup"><span data-stu-id="2b825-155">Use the right control for the job</span></span>**

    <span data-ttu-id="2b825-156">コントロールとはユーザー インターフェイスの構成要素です。最適なコントロールを使用すると、ユーザーの想像どおりに動作するユーザー インターフェイスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-156">Controls are the building blocks of the user interface; using the right control helps you create a user interface that behaves the way users expect it to.</span></span>  <span data-ttu-id="2b825-157">UWP には、単純なボタンから強力なデータ コントロールまで、45 を超えるコントロールがあります。</span><span class="sxs-lookup"><span data-stu-id="2b825-157">UWP provides more than 45 controls, ranging from simple buttons to powerful data controls.</span></span> 

    [<span data-ttu-id="2b825-158">UWP コントロールの詳細</span><span class="sxs-lookup"><span data-stu-id="2b825-158">Learn about UWP controls</span></span>](/windows/uwp/design/controls-and-patterns/)

* **<span data-ttu-id="2b825-159">あらゆるニーズに対応</span><span class="sxs-lookup"><span data-stu-id="2b825-159">Be inclusive</span></span>** 

    <span data-ttu-id="2b825-160">適切に設計されたアプリは、障碍のある方も利用できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-160">A well-design app is accessible to people with disabilities.</span></span> <span data-ttu-id="2b825-161">いくつかのコーディングを追加すると、世界中のユーザーとアプリを共有できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-161">With some extra coding, you can share your app with people around the world.</span></span>

    [<span data-ttu-id="2b825-162">ユーザビリティの詳細</span><span class="sxs-lookup"><span data-stu-id="2b825-162">Learn about Usability</span></span>](/windows/uwp/design/usability/)


## <a name="be-engaging-and-immersive"></a><span data-ttu-id="2b825-163">魅力と臨場感を実現する</span><span class="sxs-lookup"><span data-stu-id="2b825-163">Be engaging and immersive</span></span> 

<span data-ttu-id="2b825-164">ライトやモーションなどの物理的な要素を組み込むことで、魅力的なアプリを作成します。</span><span class="sxs-lookup"><span data-stu-id="2b825-164">Make your app engaging by incorporating physical elements, like light and motion.</span></span> 

## <a name="use-light"></a><span data-ttu-id="2b825-165">ライトの使用</span><span class="sxs-lookup"><span data-stu-id="2b825-165">Use light</span></span>

<span data-ttu-id="2b825-166">ライトは、関心を集めるための方法です。</span><span class="sxs-lookup"><span data-stu-id="2b825-166">Light has a way of drawing our attention.</span></span> <span data-ttu-id="2b825-167">ライトによって、使用する場所の雰囲気や特徴が作り出されます。ライトは、情報に焦点を当てるための実用的なツールです。</span><span class="sxs-lookup"><span data-stu-id="2b825-167">It creates atmosphere and a sense of place, and it’s a practical tool to illuminate information.</span></span>
        
<span data-ttu-id="2b825-168">UWP アプリにライトを追加する</span><span class="sxs-lookup"><span data-stu-id="2b825-168">Add light to your UWP app:</span></span>
        
* <span data-ttu-id="2b825-169">[表示ハイライト](../style/reveal.md) では、ライトを使用して対話型要素を目立たせます。ライトによって、非表示の境界線が表示され、ユーザーが操作できる対話型要素が強調されます。</span><span class="sxs-lookup"><span data-stu-id="2b825-169">[Reveal highlight](../style/reveal.md) uses light to make interactive elements stand out. Light illuminates the elements the user can interact with, revealing hidden borders.</span></span> <span data-ttu-id="2b825-170">表示は、リスト ビューやグリッド ビューなど、いくつかのコントロールで自動的に有効になります。</span><span class="sxs-lookup"><span data-stu-id="2b825-170">Reveal is automatically enabled on some controls, such as list view and grid view.</span></span> <span data-ttu-id="2b825-171">定義済みの表示ハイライト スタイルを適用すると、他のコントロールでも表示を有効にできます。</span><span class="sxs-lookup"><span data-stu-id="2b825-171">You can enable it on other controls by applying our predefined Reveal highlight styles.</span></span> 

* <span data-ttu-id="2b825-172">[表示フォーカス](../style/reveal-focus.md) はライトを使用して、入力フォーカスのある要素に注意を向けます。</span><span class="sxs-lookup"><span data-stu-id="2b825-172">[Reveal focus](../style/reveal-focus.md) uses light to call attention to the element that currently has input focus.</span></span>  

## <a name="create-a-sense-of-depth"></a><span data-ttu-id="2b825-173">奥行きの作成</span><span class="sxs-lookup"><span data-stu-id="2b825-173">Create a sense of depth</span></span>

<span data-ttu-id="2b825-174">私たちは、3 次元の世界で暮らしています。</span><span class="sxs-lookup"><span data-stu-id="2b825-174">We live in a three-dimensional world.</span></span> <span data-ttu-id="2b825-175">奥行きを UI に意図的に組み込むと、視覚的な階層が作成され、フラットな 2-D インターフェイスを、より効果的に情報と概念を提示するインターフェイスに変換することができます。</span><span class="sxs-lookup"><span data-stu-id="2b825-175">By purposefully incorporating depth into the UI, we transform a flat, 2-D interface into something more&mdash;something that efficiently presents information and concepts by creating a visual hierarchy.</span></span> <span data-ttu-id="2b825-176">奥行きは、階層化された物理環境では、物事が相互にどのように関連するかを再構成します。</span><span class="sxs-lookup"><span data-stu-id="2b825-176">It reinvents how things relate to each other within a layered, physical environment</span></span>

<span data-ttu-id="2b825-177">UWP アプリに奥行きを追加する</span><span class="sxs-lookup"><span data-stu-id="2b825-177">Add depth to your UWP app:</span></span>

* <span data-ttu-id="2b825-178">"[アクリル](../style/acrylic.md)" は、ユーザーに対してコンテンツのレイヤーを表示する半透明な素材です。UI 要素の階層を確立します。</span><span class="sxs-lookup"><span data-stu-id="2b825-178">[Acrylic](../style/acrylic.md) is a translucent material that lets the user see layers of content, establishing a hierarchy of UI elements.</span></span>

* <span data-ttu-id="2b825-179">"[視差](../motion/parallax.md)" は、前景にあるアイテムを背景にあるアイテムよりも速く動くように見せて、奥行き感を作り出します。</span><span class="sxs-lookup"><span data-stu-id="2b825-179">[Parallax](../motion/parallax.md) creates the illusion of depth by making items in the foreground appear to move more quickly than items in the background.</span></span>

## <a name="incorporate-motion"></a><span data-ttu-id="2b825-180">モーションの組み込み</span><span class="sxs-lookup"><span data-stu-id="2b825-180">Incorporate motion</span></span>

<span data-ttu-id="2b825-181">モーションのデザインは映画のようなものと考えてください。</span><span class="sxs-lookup"><span data-stu-id="2b825-181">Think of motion design like a movie.</span></span> <span data-ttu-id="2b825-182">シームレスな切り替えによって、ユーザーをストーリーに注目させておき、優れたエクスペリエンスを実現することができます。</span><span class="sxs-lookup"><span data-stu-id="2b825-182">Seamless transitions keep you focused on the story, and bring experiences to life.</span></span> <span data-ttu-id="2b825-183">モーションのデザインにそのような感覚を取り込むことで、あるタスクから別のタスクへ映画のようにスムーズにユーザーを移行させることができます。</span><span class="sxs-lookup"><span data-stu-id="2b825-183">We can invite those feelings into our designs, leading people from one task to the next with cinematic ease.</span></span>

<span data-ttu-id="2b825-184">UWP アプリにモーションを追加する</span><span class="sxs-lookup"><span data-stu-id="2b825-184">Add motion to your UWP app:</span></span>

* <span data-ttu-id="2b825-185">"[接続型アニメーション](../motion/connected-animation.md)" を使用すると、ユーザーはシームレスなシーンの切り替えを作成することでコンテキストを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="2b825-185">[Connected animations](../motion/connected-animation.md) help the user maintain context by creating a seamless transition between scenes.</span></span> 

## <a name="build-it-with-the-right-material"></a><span data-ttu-id="2b825-186">適切な素材を使用して作成する</span><span class="sxs-lookup"><span data-stu-id="2b825-186">Build it with the right material</span></span>

<span data-ttu-id="2b825-187">現実の世界で私たちの周囲にあるものは、ある種の感覚と刺激を与えます。</span><span class="sxs-lookup"><span data-stu-id="2b825-187">The things that surround us in the real world are sensory and invigorating.</span></span> <span data-ttu-id="2b825-188">そういったものは、折れ曲がったり、伸びたり、弾んだり、砕かれたり、滑らかに動いたりします。</span><span class="sxs-lookup"><span data-stu-id="2b825-188">They bend, stretch, bounce, shatter, and glide.</span></span> <span data-ttu-id="2b825-189">こうした素材の質感をデジタル環境に取り込むことで、ユーザーが利用したいと思うようなデザインを実現できます。</span><span class="sxs-lookup"><span data-stu-id="2b825-189">Those material qualities translate to digital environments, making people want to reach out and touch our designs.</span></span>

<span data-ttu-id="2b825-190">UWP アプリに素材を追加する</span><span class="sxs-lookup"><span data-stu-id="2b825-190">Add material to your UWP app:</span></span> 
        
* <span data-ttu-id="2b825-191">"[アクリル](../style/acrylic.md)" は、ユーザーに対してコンテンツのレイヤーを表示する半透明な素材です。UI 要素の階層を確立します。</span><span class="sxs-lookup"><span data-stu-id="2b825-191">[Acrylic](../style/acrylic.md)  is a translucent material that lets the user see layers of content, establishing a hierarchy of UI elements.</span></span> 

## <a name="design-toolkits-and-code-samples"></a><span data-ttu-id="2b825-192">設計ツールキットとコード サンプル</span><span class="sxs-lookup"><span data-stu-id="2b825-192">Design toolkits and code samples</span></span>

<span data-ttu-id="2b825-193">Fluent Design で独自アプリの作成を始めてみませんか。</span><span class="sxs-lookup"><span data-stu-id="2b825-193">Want to get started creating your own apps with Fluent Design?</span></span> <span data-ttu-id="2b825-194">Adobe XD、Adobe Illustrator、Adobe Photoshop、Framer、Sketch 用のツールキットを使用すると、設計をすぐに始められます。また、サンプルを使用すると、コーディングの時間が短縮されます。</span><span class="sxs-lookup"><span data-stu-id="2b825-194">Our toolkits for Adobe XD, Adobe Illustrator, Adobe Photoshop, Framer, and Sketch will help jumpstart your designs, and our samples will help get you coding faster.</span></span>

* <span data-ttu-id="2b825-195">[設計ツールキットとサンプルのページ](/windows/uwp/design/downloads/)を確認してください。</span><span class="sxs-lookup"><span data-stu-id="2b825-195">Check out our [Design toolkits and samples page](/windows/uwp/design/downloads/)</span></span>

<img src="images/fluentdesign_header.png" alt=" " />








