---
description: Fluent Design とアプリに組み込む方法について学習します。
title: Windows 用の fluent Design System
author: mijacobs
keywords: UWP アプリのレイアウト, ユニバーサル Windows プラットフォーム, アプリの設計, インターフェイス, Fluent Design System
ms.author: mijacobs
ms.date: 3/7/2018
ms.topic: article
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: c61eb71a82234a1339295536140121d80f83a033
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7166566"
---
# <a name="the-fluent-design-system-for-windows-app-creators"></a><span data-ttu-id="08897-104">Fluent Design System の Windows アプリの作成者</span><span class="sxs-lookup"><span data-stu-id="08897-104">The Fluent Design System for Windows app creators</span></span>

![Fluent Design ヘッダー](images/fluentdesign-app-header.jpg)

## <a name="introduction"></a><span data-ttu-id="08897-106">はじめに</span><span class="sxs-lookup"><span data-stu-id="08897-106">Introduction</span></span>

<span data-ttu-id="08897-107">Fluent Design System では、システムの作成アダプティブ、親近感、優れた美しさを持つユーザー インターフェイスです。</span><span class="sxs-lookup"><span data-stu-id="08897-107">The Fluent Design System is our system for creating adaptive, empathetic, and beautiful user interfaces.</span></span>

## <a name="principles"></a><span data-ttu-id="08897-108">原則</span><span class="sxs-lookup"><span data-stu-id="08897-108">Principles</span></span>

**<span data-ttu-id="08897-109">順応性: 各デバイスで自然な Fluent エクスペリエンスを得られる</span><span class="sxs-lookup"><span data-stu-id="08897-109">Adaptive: Fluent experiences feel natural on each device</span></span>**

<span data-ttu-id="08897-110">Fluent エクスペリエンスは環境に適応します。</span><span class="sxs-lookup"><span data-stu-id="08897-110">Fluent experiences adapt to the environment.</span></span> <span data-ttu-id="08897-111">Fluent エクスペリエンスは、タブレット、デスクトップ PC、Xbox で快適な感じられ、その動作も優れています、Mixed Reality ヘッドセットでします。</span><span class="sxs-lookup"><span data-stu-id="08897-111">A Fluent experience feels comfortable on a tablet, a desktop PC, and an Xbox—it even works great on a Mixed Reality headset.</span></span> <span data-ttu-id="08897-112">PC の追加モニターなど、多くのハードウェアを追加しても、Fluent エクスペリエンスでそれらを活用できます。</span><span class="sxs-lookup"><span data-stu-id="08897-112">And when you add more hardware, like an additional monitor for your PC, a Fluent experience takes advantage of it.</span></span>

**<span data-ttu-id="08897-113">親近感: Fluent エクスペリエンスは直感的で、強力である</span><span class="sxs-lookup"><span data-stu-id="08897-113">Empathetic: Fluent experiences are intuitive and powerful</span></span>**

<span data-ttu-id="08897-114">Fluent エクスペリエンスは動作と意図を読み取ります。すなわち、必要なものを把握および予想します。</span><span class="sxs-lookup"><span data-stu-id="08897-114">Fluent experiences adjust to behavior and intent&mdash;they understand and anticipate what’s needed.</span></span> <span data-ttu-id="08897-115">ユーザーとアイデアが物理的に離れているかどうかに関係なく、それらを統合します。</span><span class="sxs-lookup"><span data-stu-id="08897-115">They unite people and ideas, whether they’re on opposite sides of the globe or standing right next to each other.</span></span>

**<span data-ttu-id="08897-116">美しさ: Fluent エクスペリエンスは魅力的で、臨場感がある</span><span class="sxs-lookup"><span data-stu-id="08897-116">Beautiful: Fluent experiences are engaging and immersive</span></span>**

<span data-ttu-id="08897-117">現実世界の要素を組み込むことで、Fluent エクスペリエンスでは基本的な機能を活用できます。</span><span class="sxs-lookup"><span data-stu-id="08897-117">By incorporating elements of the physical world, a Fluent experience taps into something fundamental.</span></span> <span data-ttu-id="08897-118">直感的かつ本能的に情報を整理できるように、ライト、影、モーション、深度、テクスチャを使用します。</span><span class="sxs-lookup"><span data-stu-id="08897-118">It uses light, shadow, motion, depth, and texture to organize information in a way that feels intuitive and instinctual.</span></span>


## <a name="applying-fluent-design-to-your-app-with-uwp"></a><span data-ttu-id="08897-119">Uwp アプリに Fluent Design の適用</span><span class="sxs-lookup"><span data-stu-id="08897-119">Applying Fluent Design to your app with UWP</span></span>

![Fluent design のロゴ](images/fluentdesign_header.png)

<span data-ttu-id="08897-121">設計ガイドラインでは、アプリに Fluent Design の原則を適用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="08897-121">Our design guidelines explain how to apply Fluent Design principles to apps.</span></span> <span data-ttu-id="08897-122">どのようなアプリかどうか。</span><span class="sxs-lookup"><span data-stu-id="08897-122">What type of apps?</span></span> <span data-ttu-id="08897-123">ガイドラインの多くは、すべてのプラットフォームに適用できる、UWP (ユニバーサル Windows プラットフォーム) Fluent Design をサポートするためには作成します。</span><span class="sxs-lookup"><span data-stu-id="08897-123">While many of our guidelines can be applied to any platform, we created UWP (the Universal Windows Platform) to support Fluent Design.</span></span>

<span data-ttu-id="08897-124">Fluent Design 機能は UWP に組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="08897-124">Fluent Design features are built into UWP.</span></span> <span data-ttu-id="08897-125">これらの機能のいくつか (有効ピクセルやユニバーサル入力システムなど) は、自動的に取り込まれます。</span><span class="sxs-lookup"><span data-stu-id="08897-125">Some of these features&mdash;such as effective pixels and the universal input system&mdash;are automatic.</span></span> <span data-ttu-id="08897-126">これらの機能を利用するために追加のコードを記述する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="08897-126">You don't have to write any extra code to take advantage of them.</span></span> <span data-ttu-id="08897-127">他の機能 (アクリル効果など) はオプションであり、それらの機能をアプリに取り込むには、機能を追加するためのコードを記述します。</span><span class="sxs-lookup"><span data-stu-id="08897-127">Other features, like acrylic, are optional; you add them to your app by writing code to include them.</span></span>

> <span data-ttu-id="08897-128">Fluent Design 機能を使用して既存の WPF または Windows アプリケーションの外観や機能を高めることができるように、UWP コントロールをデスクトップに追加しています。</span><span class="sxs-lookup"><span data-stu-id="08897-128">We're bringing UWP controls to the desktop so that you can enhance the look, feel, and functionality of your existing WPF or Windows applications with Fluent Design features.</span></span> <span data-ttu-id="08897-129">詳細についてはを[WPF および Windows フォーム アプリケーションでホスト UWP コントロール](/windows/uwp/xaml-platform/xaml-host-controls)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="08897-129">To learn more, see [Host UWP controls in WPF and Windows Forms applications](/windows/uwp/xaml-platform/xaml-host-controls).</span></span>

<!-- To apply Fluent Design to your app, follow our guidelines and use UWP (Universal Windows Platform) you can use UWP UI features combined with best practices for creating apps that perform beautifully on all types of Windows-powered devices. -->

<span data-ttu-id="08897-130">だけでなく設計ガイダンスについては、Fluent Design の記事も示します発生する、デザインを行うコードを記述する方法。</span><span class="sxs-lookup"><span data-stu-id="08897-130">In addition to design guidance, our Fluent Design articles also show you how to write the code that makes your designs happen.</span></span> <span data-ttu-id="08897-131">UWP では、XAML では、ユーザー インターフェイスを作成しやすくマークアップ ベースの言語を使用します。</span><span class="sxs-lookup"><span data-stu-id="08897-131">UWP uses XAML, a markup-based language that makes it easier to create user interfaces.</span></span> <span data-ttu-id="08897-132">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="08897-132">Here's an example:</span></span>

```xaml
<Grid BorderBrush="Blue" BorderThickness="4">
    <TextBox Text="Design with XAML" Margin="20" Padding="24,16"/>
</Grid>
```

![](images/xaml-example.png)


> <span data-ttu-id="08897-133">UWP 開発の初めての場合、 [UWP のページを使ってみる](https://developer.microsoft.com/windows/apps/getstarted)ご覧ください。</span><span class="sxs-lookup"><span data-stu-id="08897-133">If you're new to UWP development, check out our [Get started with UWP page](https://developer.microsoft.com/windows/apps/getstarted).</span></span>

## <a name="find-a-natural-fit"></a><span data-ttu-id="08897-134">最適なデザインを見つける</span><span class="sxs-lookup"><span data-stu-id="08897-134">Find a natural fit</span></span>

<span data-ttu-id="08897-135">さまざまなデバイスでアプリを自然に操作してもらうにはどのようにすればいいですか?</span><span class="sxs-lookup"><span data-stu-id="08897-135">How do you make an app feel natural on a variety of devices?</span></span> <span data-ttu-id="08897-136">それぞれのデバイスに合わせて設計されたように感じさせることです。</span><span class="sxs-lookup"><span data-stu-id="08897-136">By making it feel as though it were designed with each specific device in mind.</span></span> <span data-ttu-id="08897-137">無駄な領域がなく (密集しない)、異なる画面サイズに対応する UI レイアウトでは、使用するデバイス用に設計されたかのような自然な使用感を得られます。</span><span class="sxs-lookup"><span data-stu-id="08897-137">A UI layout that adapts to different screen sizes&mdash;so there's no wasted space (but no crowding either)&mdash;makes an experience feel natural, as though it were designed for that device.</span></span>

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-size-classes.jpg)
    :::column-end:::
    :::column span="2":::
        **Design for the right breakpoints**

        Instead of designing for every individual screen size, focusing on a few key widths (also called "breakpoints") can greatly simplify your designs and code while still making your app look great on small to large screens.

        [Learn about screen sizes and breakpoints](/windows/uwp/design/layout/screen-sizes-and-breakpoints-for-responsive-design)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/rspd-resize.gif)
    :::column-end:::
    :::column span="2":::
        **Create a responsive layout**

        For an app to feel natural, it should adapt its layout to different screen sizes and devices. You can use automatic sizing, layout panels, visual states, and even separate UI definitions in XAML to create a responsive UI.

        [Learn about responsive design](/windows/uwp/design/layout/responsive-design)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/devices.jpg)
    :::column-end:::
    :::column span="2":::
        **Design for a spectrum of devices**

        UWP apps can run on a wide variety of Windows-powered devices. It's helpful to understand which devices are available, what they're made for, and how users interact with them.

        [Learn about UWP devices](/windows/uwp/design/devices/)
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/keyboard-shortcuts.jpg)
    :::column-end:::
    :::column span="2":::
        **Optimize for the right input**

        UWP apps automatically support common mouse, keyboard, pen, and touch interactions&mdash;there's nothing extra you have to do. But you can enhance your app with optimized support for specific inputs, like pen and the Surface Dial.

        [Learn about inputs and interactions](/windows/uwp/design/input/input-primer)
:::row-end:::

## <a name="make-it-intuitive"></a><span data-ttu-id="08897-138">直感的なこと</span><span class="sxs-lookup"><span data-stu-id="08897-138">Make it intuitive</span></span>

<span data-ttu-id="08897-139">ユーザーの期待に動作するとき、エクスペリエンスは直観操作できます。</span><span class="sxs-lookup"><span data-stu-id="08897-139">An experience feels intuitive when it behaves the way the user expects it to.</span></span> <span data-ttu-id="08897-140">アクセシビリティとグローバリゼーションを実現するためにコントロールとパターンを確立し、プラットフォーム サポートを活用することで、操作の手間が省け、生産性が向上します。</span><span class="sxs-lookup"><span data-stu-id="08897-140">By using established controls and patterns and taking advantage of platform support for accessibility and globalization, you create an effortless experience that helps users be more productive.</span></span>

<span data-ttu-id="08897-141">共感を得るには、適切なタイミングで適切な処理を行います。</span><span class="sxs-lookup"><span data-stu-id="08897-141">Demonstrating empathy is about doing the right thing at the right time.</span></span>

<span data-ttu-id="08897-142">Fluent エクスペリエンスは一貫性のあるコントロールとパターンを使用するため、ユーザーが学習したとおりに動作します。</span><span class="sxs-lookup"><span data-stu-id="08897-142">Fluent experiences use controls and patterns consistently, so they behave in ways the user has learned to expect.</span></span> <span data-ttu-id="08897-143">Fluent エクスペリエンスでは幅広い物理的な機能を使用してユーザーにアクセスします。グローバリゼーション機能が組み込まれているため、世界中のユーザーが使用することができます。</span><span class="sxs-lookup"><span data-stu-id="08897-143">Fluent experiences are accessible to people with a wide range of physical abilities, and incorporate globalization features so people around the world can use them.</span></span>

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-navview.png)
    :::column-end:::
    :::column span="2":::
        **Provide the right navigation**

        Create an effortless experience by using the right app structure and navigation components.

        [Learn about navigation](/windows/uwp/design/basics/navigation-basics/)
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-commanding.png)
    :::column-end:::
    :::column span="2":::
        **Be interactive**

        Buttons, command bars, keyboard shortcuts, and context menus enable users to interact with your app; they're the tools that change a static experience into something dynamic.

        [Learn about commanding](/windows/uwp/design/basics/commanding-basics/)
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-controls-2.jpg)
    :::column-end:::
    :::column span="2":::
        **Use the right control for the job**

        Controls are the building blocks of the user interface; using the right control helps you create a user interface that behaves the way users expect it to.  UWP provides more than 45 controls,ranging from simple buttons to powerful data controls.

        [Learn about UWP controls](/windows/uwp/design/controls-and-patterns/)
:::row-end:::

:::row:::
    :::column:::
        ![inclusive image](images/thumbnail-inclusive.png)
    :::column-end:::
    :::column span="2":::
        **Be inclusive**
        A well-design app is accessible to people with disabilities. With some extra coding, you can share your app with people around the world.

        [Learn about Usability](/windows/uwp/design/usability/)
:::row-end:::

## <a name="be-engaging-and-immersive"></a><span data-ttu-id="08897-144">魅力と臨場感を実現する</span><span class="sxs-lookup"><span data-stu-id="08897-144">Be engaging and immersive</span></span>

<span data-ttu-id="08897-145">Fluent Design に派手な効果はありません。</span><span class="sxs-lookup"><span data-stu-id="08897-145">Fluent Design isn't about flashy effects.</span></span> <span data-ttu-id="08897-146">脳で効率的に処理するようにプログラムされたエクスペリエンスをエミュレートするため、ユーザー エクスペリエンスを拡張する物理的な効果が組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="08897-146">It incorporates physical effects that truly enhance the user experience, because they emulate experiences that our brains are programmed to process efficiently.</span></span>

## <a name="use-light"></a><span data-ttu-id="08897-147">ライトの使用</span><span class="sxs-lookup"><span data-stu-id="08897-147">Use light</span></span>

<span data-ttu-id="08897-148">ライトは、関心を集めるための方法です。</span><span class="sxs-lookup"><span data-stu-id="08897-148">Light has a way of drawing our attention.</span></span> <span data-ttu-id="08897-149">ライトによって、使用する場所の雰囲気や特徴が作り出されます。ライトは、情報に焦点を当てるための実用的なツールです。</span><span class="sxs-lookup"><span data-stu-id="08897-149">It creates atmosphere and a sense of place, and it’s a practical tool to illuminate information.</span></span>

<span data-ttu-id="08897-150">UWP アプリにライトを追加する</span><span class="sxs-lookup"><span data-stu-id="08897-150">Add light to your UWP app:</span></span>

:::row:::
    :::column:::
        ![fpo image](../style/images/Nav_Reveal_Animation.gif)
    :::column-end:::
    :::column span="2":::
        **Reveal highlight**

        [Reveal highlight](../style/reveal.md) uses light to make interactive elements stand out. Light illuminates the elements the user can interact with, revealing hidden borders. Reveal is automatically enabled on some controls, such as list view and grid view. You can enable it on other controls by applying our predefined Reveal highlight styles.
:::row-end:::

:::row:::
    :::column:::
        ![fpo image](../style/images/traveling-focus-fullscreen-light-rf.gif)
    :::column-end:::
    :::column span="2":::
        **Reveal focus**

        [Reveal focus](../style/reveal-focus.md) uses light to call attention to the element that currently has input focus.
:::row-end:::

## <a name="create-a-sense-of-depth"></a><span data-ttu-id="08897-151">奥行きの作成</span><span class="sxs-lookup"><span data-stu-id="08897-151">Create a sense of depth</span></span>

<span data-ttu-id="08897-152">私たちは、3 次元の世界で暮らしています。</span><span class="sxs-lookup"><span data-stu-id="08897-152">We live in a three-dimensional world.</span></span> <span data-ttu-id="08897-153">奥行きを UI に意図的に組み込むと、視覚的な階層が作成され、フラットな 2-D インターフェイスを、より効果的に情報と概念を提示するインターフェイスに変換することができます。</span><span class="sxs-lookup"><span data-stu-id="08897-153">By purposefully incorporating depth into the UI, we transform a flat, 2-D interface into something more&mdash;something that efficiently presents information and concepts by creating a visual hierarchy.</span></span> <span data-ttu-id="08897-154">奥行きは、階層化された物理環境では、物事が相互にどのように関連するかを再構成します。</span><span class="sxs-lookup"><span data-stu-id="08897-154">It reinvents how things relate to each other within a layered, physical environment</span></span>

<span data-ttu-id="08897-155">UWP アプリに奥行きを追加する</span><span class="sxs-lookup"><span data-stu-id="08897-155">Add depth to your UWP app:</span></span>

:::row:::
    :::column:::
        ![fpo image](../motion/images/_parallax_v2.gif)
    :::column-end:::
    :::column span="2":::
        **Parallax**

        [Parallax](../motion/parallax.md) creates the illusion of depth by making items in the foreground appear to move more quickly than items in the background.
:::row-end:::

## <a name="incorporate-motion"></a><span data-ttu-id="08897-156">モーションの組み込み</span><span class="sxs-lookup"><span data-stu-id="08897-156">Incorporate motion</span></span>

<span data-ttu-id="08897-157">モーションのデザインは映画のようなものと考えてください。</span><span class="sxs-lookup"><span data-stu-id="08897-157">Think of motion design like a movie.</span></span> <span data-ttu-id="08897-158">シームレスな切り替えによって、ユーザーをストーリーに注目させておき、優れたエクスペリエンスを実現することができます。</span><span class="sxs-lookup"><span data-stu-id="08897-158">Seamless transitions keep you focused on the story, and bring experiences to life.</span></span> <span data-ttu-id="08897-159">モーションのデザインにそのような感覚を取り込むことで、あるタスクから別のタスクへ映画のようにスムーズにユーザーを移行させることができます。</span><span class="sxs-lookup"><span data-stu-id="08897-159">We can invite those feelings into our designs, leading people from one task to the next with cinematic ease.</span></span>

<span data-ttu-id="08897-160">UWP アプリにモーションを追加する</span><span class="sxs-lookup"><span data-stu-id="08897-160">Add motion to your UWP app:</span></span>

:::row:::
    :::column:::
        ![continuity gif](images/continuityXbox.gif)
    :::column-end:::
    :::column span="2":::
        **Connected animations**

        [Connected animations](../motion/connected-animation.md) help the user maintain context by creating a seamless transition between scenes.
:::row-end:::

## <a name="build-it-with-the-right-material"></a><span data-ttu-id="08897-161">適切な素材を使用して作成する</span><span class="sxs-lookup"><span data-stu-id="08897-161">Build it with the right material</span></span>

<span data-ttu-id="08897-162">現実の世界で私たちの周囲にあるものは、ある種の感覚と刺激を与えます。</span><span class="sxs-lookup"><span data-stu-id="08897-162">The things that surround us in the real world are sensory and invigorating.</span></span> <span data-ttu-id="08897-163">そういったものは、折れ曲がったり、伸びたり、弾んだり、砕かれたり、滑らかに動いたりします。</span><span class="sxs-lookup"><span data-stu-id="08897-163">They bend, stretch, bounce, shatter, and glide.</span></span> <span data-ttu-id="08897-164">こうした素材の質感をデジタル環境に取り込むことで、ユーザーが利用したいと思うようなデザインを実現できます。</span><span class="sxs-lookup"><span data-stu-id="08897-164">Those material qualities translate to digital environments, making people want to reach out and touch our designs.</span></span>

<span data-ttu-id="08897-165">UWP アプリに素材を追加する</span><span class="sxs-lookup"><span data-stu-id="08897-165">Add material to your UWP app:</span></span>

:::row:::
    :::column:::
        ![fpo image](../style/images/acrylic_lighttheme_base.png)
    :::column-end:::
    :::column span="2":::
        **Acrylic**

        [Acrylic](../style/acrylic.md) is a translucent material that lets the user see layers of content, establishing a hierarchy of UI elements.
:::row-end:::

## <a name="design-toolkits-and-code-samples"></a><span data-ttu-id="08897-166">設計ツールキットとコード サンプル</span><span class="sxs-lookup"><span data-stu-id="08897-166">Design toolkits and code samples</span></span>

<span data-ttu-id="08897-167">Fluent Design で独自アプリの作成を始めてみませんか。</span><span class="sxs-lookup"><span data-stu-id="08897-167">Want to get started creating your own apps with Fluent Design?</span></span> <span data-ttu-id="08897-168">Adobe XD、Adobe Illustrator、Adobe Photoshop、Framer、Sketch 用のツールキットを使用すると、設計をすぐに始められます。また、サンプルを使用すると、コーディングの時間が短縮されます。</span><span class="sxs-lookup"><span data-stu-id="08897-168">Our toolkits for Adobe XD, Adobe Illustrator, Adobe Photoshop, Framer, and Sketch will help jumpstart your designs, and our samples will help get you coding faster.</span></span>

:::row:::
    :::column:::
        ![fpo image](images/thumbnail-toolkits.jpg)
    :::column-end:::
    :::column span="2":::
        **Design toolkits and samples page**

        Check out our [Design toolkits and samples page](/windows/uwp/design/downloads/)
:::row-end:::









