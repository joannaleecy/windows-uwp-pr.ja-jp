---
author: mijacobs
Description: The universal design features included in every UWP app help you build apps that scale beautifully across a range of devices.
title: ユニバーサル Windows プラットフォーム (UWP) アプリ設計の概要 (Windows アプリ)
ms.assetid: 50A5605E-3A91-41DB-800A-9180717C1E86
ms.author: mijacobs
ms.date: 05/05/2018
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 422a6b40c86a84367054a20cabe1a0b0a32cb89d
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6189715"
---
# <a name="introduction-to-uwp-app-design"></a><span data-ttu-id="48077-103">UWP アプリ設計の概要</span><span class="sxs-lookup"><span data-stu-id="48077-103">Introduction to UWP app design</span></span>

![サンプルの照明アプリ](images/introUWP-header.jpg)

<span data-ttu-id="48077-105">ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリを設計および構築するのに役立つリソースです。</span><span class="sxs-lookup"><span data-stu-id="48077-105">The Universal Windows Platform (UWP) design guidance is a resource to help you design and build beautiful, polished apps.</span></span>

<span data-ttu-id="48077-106">これは規範的な規則の一覧ではなく、進化する [Fluent Design System](../fluent-design-system/index.md)、およびアプリ構築コミュニティのニーズに適応するように設計された生きたドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="48077-106">It's not a list of prescriptive rules - it's a living document, designed to adapt to our evolving [Fluent Design System](../fluent-design-system/index.md) as well as the needs of our app-building community.</span></span>

<span data-ttu-id="48077-107">この記事では、あらゆる UWP アプリに含まれているユニバーサル デザイン機能の概要を説明します。これらの機能により、さまざまなデバイス間で美しくスケーリングされるユーザー インターフェイス (UI) を構築できます。</span><span class="sxs-lookup"><span data-stu-id="48077-107">This introduction provides an overview of the universal design features that are included in every UWP app, helping you build user interfaces (UI) that scale beautifully across a range of devices.</span></span>

## <a name="effective-pixels-and-scaling"></a><span data-ttu-id="48077-108">有効ピクセルとスケーリング</span><span class="sxs-lookup"><span data-stu-id="48077-108">Effective pixels and scaling</span></span>

<span data-ttu-id="48077-109">UWP アプリでは、タブレット、PC、TV からすべての[Windows 10 デバイス](../devices/index.md)で実行します。</span><span class="sxs-lookup"><span data-stu-id="48077-109">UWP apps run on all [Windows 10 devices](../devices/index.md), from your TV to your tablet or PC.</span></span> <span data-ttu-id="48077-110">さまざまなデバイスや画面サイズで適切に表示される UI を設計するには、どのように行うかどうか。</span><span class="sxs-lookup"><span data-stu-id="48077-110">So how do you design a UI that looks good on a wide variety of devices and screen sizes?</span></span>

![さまざまなデバイス上にある同じアプリ](images/universal-image-1.jpg)

<span data-ttu-id="48077-112">UWP は、読みやすく操作し、やすいですべてのデバイスや画面サイズになるように UI 要素を自動的に調整することで役立ちます。</span><span class="sxs-lookup"><span data-stu-id="48077-112">UWP helps by automatically adjusting UI elements so that they're legible and easy to interact with on all devices and screen sizes.</span></span>

<span data-ttu-id="48077-113">デバイスでアプリを実行するとき、システムでは、UI 要素を画面に表示する方法を正規化するアルゴリズムを使います。</span><span class="sxs-lookup"><span data-stu-id="48077-113">When your app runs on a device, the system uses an algorithm to normalize the way UI elements display on the screen.</span></span> <span data-ttu-id="48077-114">このスケーリング アルゴリズムでは、視聴距離と画面の密度 (ピクセル/インチ) を考慮して、体感的なサイズを最適化します (物理的なサイズではありません)。</span><span class="sxs-lookup"><span data-stu-id="48077-114">This scaling algorithm takes into account viewing distance and screen density (pixels per inch) to optimize for perceived size (rather than physical size).</span></span> <span data-ttu-id="48077-115">スケーリング アルゴリズムによって、10 フィート離れた Surface Hub における 24 ピクセルのフォントが、数インチ離れた 5 インチ サイズの電話における 24 ピクセルのフォントと同じようにユーザーに読みやすい状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="48077-115">The scaling algorithm ensures that a 24 px font on Surface Hub 10 feet away is just as legible to the user as a 24 px font on 5" phone that's a few inches away.</span></span>

![さまざまなデバイスの視聴距離](images/scaling-chart.png)

<span data-ttu-id="48077-117">スケーリング システムのしくみのため、UWP アプリをデザインするときには、実際の物理ピクセルではなく、有効ピクセルでデザインすることになります。</span><span class="sxs-lookup"><span data-stu-id="48077-117">Because of how the scaling system works, when you design your UWP app, you're designing in effective pixels, not actual physical pixels.</span></span> <span data-ttu-id="48077-118">有効ピクセル (epx) は仮想的な測定単位で、画面の密度とは無関係にレイアウトのサイズと間隔を表すために使用されます。</span><span class="sxs-lookup"><span data-stu-id="48077-118">Effective pixels (epx) are a virtual unit of measurement, and they're used to express layout dimensions and spacing, independent of screen density.</span></span> <span data-ttu-id="48077-119">(ガイドラインでは、epx、ep、および px を区別しないで使用しています。)</span><span class="sxs-lookup"><span data-stu-id="48077-119">(In our guidelines, epx, ep, and px are used interchangeably.)</span></span>

<span data-ttu-id="48077-120">設計時には、ピクセル密度と実際の画面解像度を無視できます。</span><span class="sxs-lookup"><span data-stu-id="48077-120">You can ignore the pixel density and the actual screen resolution when designing.</span></span> <span data-ttu-id="48077-121">その代わり、サイズ クラスの有効な解像度 (有効ピクセル単位の解像度) が向上するように設計します (詳しくは、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="48077-121">Instead, design for the effective resolution (the resolution in effective pixels) for a size class (for details, see the [Screen sizes and breakpoints article](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)).</span></span>

> [!TIP]
> <span data-ttu-id="48077-122">イメージ編集プログラムで画面のモックアップを作成するときは、DPI を 72 に設定し、画像サイズを、対象のサイズ クラスで有効な解像度に設定します</span><span class="sxs-lookup"><span data-stu-id="48077-122">When creating screen mockups in image editing programs, set the DPI to 72 and set the image dimensions to the effective resolution for the size class you're targeting.</span></span> <span data-ttu-id="48077-123">サイズ クラスと有効な解像度の一覧については、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="48077-123">For a list of size classes and effective resolutions, see the [Screen sizes and breakpoints article](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

### <a name="multiples-of-four"></a><span data-ttu-id="48077-124">4 の倍数</span><span class="sxs-lookup"><span data-stu-id="48077-124">Multiples of four</span></span>

:::row:::
    :::column span:::
        The sizes, margins, and positions of UI elements should always be in **multiples of 4 epx** in your UWP apps.

        UWP scales across a range of devices with scaling plateaus of 100%, 125%, 150%, 175%, 200%, 225%, 250%, 300%, 350%, and 400%. The base unit is 4 because it's the only integer that can be scaled by non-whole numbers (e.g. 4*1.5 = 6). Using multiples of four aligns all UI elements with whole pixels and ensures UI elements have crisp, sharp edges. (Note that text doesn't have this requirement; text can have any size and position.)
    :::column-end:::
    :::column:::
        ![grid](images/4epx.svg)
    :::column-end:::
:::row-end:::

## <a name="layout"></a><span data-ttu-id="48077-125">レイアウト</span><span class="sxs-lookup"><span data-stu-id="48077-125">Layout</span></span>

<span data-ttu-id="48077-126">UWP アプリは、すべてのデバイスに合わせて自動的に拡大縮小されるので、すべてのデバイスの UWP アプリの設計は同じ構造になっています。</span><span class="sxs-lookup"><span data-stu-id="48077-126">Since UWP apps automatically scale to all devices, designing a UWP app for any device follows the same structure.</span></span> <span data-ttu-id="48077-127">UWP アプリの UI の最初から始めましょう。</span><span class="sxs-lookup"><span data-stu-id="48077-127">Let's start from the very beginning of your UWP app's UI.</span></span>

### <a name="windows-frames-and-pages"></a><span data-ttu-id="48077-128">Windows、フレーム、ページ</span><span class="sxs-lookup"><span data-stu-id="48077-128">Windows, Frames, and Pages</span></span>

:::row:::
    :::column:::
        When a UWP app is launched on any Windows 10 device, it launches in a [Window](/uwp/api/Windows.UI.Xaml.Controls.Window) with a [Frame](/uwp/api/Windows.UI.Xaml.Controls.Frame), which can navigate between [Page](/uwp/api/Windows.UI.Xaml.Controls.Page) instances.
    :::column-end:::
    :::column:::
        ![Frame](images/frame.svg)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        You can think of your app's UI as a collection of pages. It's up to you to decide what should go on each page, and the relationships between pages.

        To learn how you can organize your pages, see [Navigation basics](navigation-basics.md).
    :::column-end:::
    :::column:::
        ![Frame](images/collection-pages.svg)
    :::column-end:::
:::row-end:::

### <a name="page-layout"></a><span data-ttu-id="48077-129">ページのレイアウト</span><span class="sxs-lookup"><span data-stu-id="48077-129">Page layout</span></span>

<span data-ttu-id="48077-130">それらのページの外観はどのようになるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="48077-130">What should those pages look like?</span></span> <span data-ttu-id="48077-131">ほとんどのページでは一貫性を保つために一般的な構造に従うため、ユーザーはアプリのページ間およびページ内を簡単に移動できます。</span><span class="sxs-lookup"><span data-stu-id="48077-131">Well, most pages follow a common structure to provide consistency, so users can easily navigate between and within pages of your app.</span></span> <span data-ttu-id="48077-132">通常、ページには次の 3 つの種類の UI 要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="48077-132">Pages typically contain three types of UI elements:</span></span>

- <span data-ttu-id="48077-133">[ナビゲーション](navigation-basics.md)要素は、表示するコンテンツをユーザーが選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="48077-133">[Navigation](navigation-basics.md) elements help users choose the content they want to display.</span></span>
- <span data-ttu-id="48077-134">[コマンド](commanding-basics.md)要素は、操作、保存、コンテンツの共有などの操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="48077-134">[Command](commanding-basics.md) elements initiate actions, such as manipulating, saving, or sharing content.</span></span>
- <span data-ttu-id="48077-135">[コンテンツ](content-basics.md)要素は、アプリのコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="48077-135">[Content](content-basics.md) elements display the app's content.</span></span>

![一般的なレイアウト パターン](../layout/images/page-components.svg)

<span data-ttu-id="48077-137">UWP アプリの一般的なパターンを実装する方法の詳細については、「[ページのレイアウト](../layout/page-layout.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="48077-137">To learn more about how to implement common UWP app patterns, see the [Page layout](../layout/page-layout.md) article.</span></span>

<span data-ttu-id="48077-138">Visual Studio で [Windows Template Studio](https://github.com/Microsoft/WindowsTemplateStudio/tree/master) を使用してアプリのレイアウトを使い始めることもできます。</span><span class="sxs-lookup"><span data-stu-id="48077-138">You can also use the [Windows Template Studio](https://github.com/Microsoft/WindowsTemplateStudio/tree/master) in Visual Studio to get started with a layout for your app.</span></span>

## <a name="controls"></a><span data-ttu-id="48077-139">コントロール</span><span class="sxs-lookup"><span data-stu-id="48077-139">Controls</span></span>

<span data-ttu-id="48077-140">UWP の設計プラットフォームには、すべての Windows デバイスで適切に動作することが保証されている一連のコモン コントロールが用意されており、[Fluent Design System](../fluent-design-system/index.md) の原則に従っています。</span><span class="sxs-lookup"><span data-stu-id="48077-140">UWP's design platform provides a set of common controls that are guaranteed to work well on all Windows-powered devices, and they adhere to our [Fluent Design System](../fluent-design-system/index.md) principles.</span></span> <span data-ttu-id="48077-141">これらのコントロールには、ボタンやテキスト要素などの単純なコントロールから、一連のデータとテンプレートからリストを生成する高度なコントロールまで、すべてのものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="48077-141">These controls include everything from simple controls, like buttons and text elements, to sophisticated controls that can generate lists from a set of data and a template.</span></span>

![UWP コントロール](../style/images/color/windows-controls.svg)

<span data-ttu-id="48077-143">UWP コントロールとコントロールに基づいて作成できるパターンの全一覧については、「[コントロールとパターン](../controls-and-patterns/index.md)」セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="48077-143">For a complete list of UWP controls and the patterns you can make from them, see the [controls and patterns section](../controls-and-patterns/index.md).</span></span>

## <a name="style"></a><span data-ttu-id="48077-144">スタイル</span><span class="sxs-lookup"><span data-stu-id="48077-144">Style</span></span>

<span data-ttu-id="48077-145">一般的なコントロールは、システム テーマとアクセント カラーを自動的に反映し、すべての入力の種類に対応し、すべてのデバイスに合わせて拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="48077-145">Common controls automatically reflect the system theme and accent color, work with all input types, and scale to all devices.</span></span> <span data-ttu-id="48077-146">このように、Fluent Design System を反映しているため、順応性が高く、親近感があり、優れた美しさを持っています。</span><span class="sxs-lookup"><span data-stu-id="48077-146">In that way, they reflect the Fluent Design System - they're adaptive, empathetic, and beautiful.</span></span> <span data-ttu-id="48077-147">一般的なコントロールでは、既定のスタイルでライト、モーション、深度を使用しているため、コントロールを使用することで、アプリに Fluent Design System を組み込んでいることになります。</span><span class="sxs-lookup"><span data-stu-id="48077-147">Common controls use light, motion, and depth in their default styles, so by using them, you're incorporating our Fluent Design System in your app.</span></span>

<span data-ttu-id="48077-148">一般的なコントロールは高度にカスタマイズでき、コントロールの前景色を変更することも、外観を完全にカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="48077-148">Common controls are highly customizable, too--you can change the foreground color of a control or completely customize it's appearance.</span></span> <span data-ttu-id="48077-149">コントロールの既定のスタイルを変更するには、[軽量なスタイル設定](../controls-and-patterns/xaml-styles.md#lightweight-styling)を使用するか、XAML で[カスタム コントロール](../controls-and-patterns/control-templates.md)を作成します。</span><span class="sxs-lookup"><span data-stu-id="48077-149">To override the default styles in controls, use [lightweight styling](../controls-and-patterns/xaml-styles.md#lightweight-styling) or create [custom controls](../controls-and-patterns/control-templates.md) in XAML.</span></span>

![アクセント カラーの gif](images/intro-style.gif)

## <a name="shell"></a><span data-ttu-id="48077-151">Shell</span><span class="sxs-lookup"><span data-stu-id="48077-151">Shell</span></span>

:::row:::
    :::column:::
        Your UWP app will interact with the broader Windows experience with tiles and notifications in the Windows [Shell](../shell/tiles-and-notifications/creating-tiles.md).

        Tiles are displayed in the Start menu and when your app launches, and they provide a glimpse of what's going on in your app. Their power comes from the content behind them, and the intelligence and craft with which they're offered up.

        UWP apps have four tile sizes (small, medium, wide, and large) that can be customized with the app's icon and identity. For guidance on designing tiles for your UWP app, see [Guidelines for tile and icon assets](../shell/tiles-and-notifications/app-assets.md).
    :::column-end:::
    :::column:::
        ![tiles on start menu](images/shell.svg)
    :::column-end:::
:::row-end:::

## <a name="inputs"></a><span data-ttu-id="48077-152">入力</span><span class="sxs-lookup"><span data-stu-id="48077-152">Inputs</span></span>

:::row:::
    :::column:::
        UWP apps rely on smart interactions. You can design around a click interaction without having to know or define whether the click comes from a mouse, a stylus, or a tap of a finger. However, you can also design your apps for [specific input modes](../input/input-primer.md).
    :::column-end:::
    :::column:::
        ![inputs](images/inputs.svg)
    :::column-end:::
:::row-end:::

## <a name="devices"></a><span data-ttu-id="48077-153">デバイス</span><span class="sxs-lookup"><span data-stu-id="48077-153">Devices</span></span>

![デバイス](../layout/images/size-classes.svg)

<span data-ttu-id="48077-155">同様に、UWP では、さまざまなデバイスに合わせてアプリを自動的にスケーリングしますが、[特定のデバイス向けに UWP アプリを最適化](../devices/index.md)することもできます。</span><span class="sxs-lookup"><span data-stu-id="48077-155">Similarly, while UWP automatically scales your app to different devices, you can also [optimize your UWP app for specific devices](../devices/index.md).</span></span>

## <a name="usability"></a><span data-ttu-id="48077-156">使いやすさ</span><span class="sxs-lookup"><span data-stu-id="48077-156">Usability</span></span>

<img src="https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/REYaAb?ver=727c">

<span data-ttu-id="48077-157">最後に重要な点として、ユーザビリティの目的は、アプリのエクスペリエンスをすべてのユーザーに開かれたものにすることです。</span><span class="sxs-lookup"><span data-stu-id="48077-157">Last but not least, usability is about making your app's experience open to all users.</span></span> <span data-ttu-id="48077-158">すべての人が、本当に包括的なユーザー エクスペリエンスの恩恵を受けます。すべてのユーザーに対してアプリを使いやすくする方法については、「[UWP アプリの操作性](../usability/index.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="48077-158">Everyone can benefit from truly inclusive user experiences - see [usability for UWP apps](../usability/index.md) to see how to make your app easy to use for everyone.</span></span>

<span data-ttu-id="48077-159">国際的なユーザーを対象に設計している場合は、[グローバリゼーションとローカライズ](../globalizing/globalizing-portal.md)を確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="48077-159">If you're designing for international audiences, you might want to check out [Globalization and localization](../globalizing/globalizing-portal.md).</span></span>

<span data-ttu-id="48077-160">視覚障碍、聴覚障碍、運動障碍を持つユーザーに関して、「[アクセシビリティ機能](../accessibility/accessibility-overview.md)」も検討してください。</span><span class="sxs-lookup"><span data-stu-id="48077-160">You might also want to consider [accessibility features](../accessibility/accessibility-overview.md) for users with limited sight, hearing, and mobility.</span></span> <span data-ttu-id="48077-161">アクセシビリティが最初から設計に組み込まれている場合は、[アプリをアクセシビリティ対応にする](../accessibility/accessibility-in-the-store.md)ことにほとんど時間と労力がかかりません。</span><span class="sxs-lookup"><span data-stu-id="48077-161">If accessibility is built into your design from the start, then [making your app accessible](../accessibility/accessibility-in-the-store.md) should take very little extra time and effort.</span></span>

## <a name="tools-and-design-toolkits"></a><span data-ttu-id="48077-162">ツールと設計ツールキット</span><span class="sxs-lookup"><span data-stu-id="48077-162">Tools and design toolkits</span></span>

<span data-ttu-id="48077-163">基本的な設計機能がわかったので、UWP アプリの設計を開始しましょう。</span><span class="sxs-lookup"><span data-stu-id="48077-163">Now that you know about the basic design features, how about getting started with designing your UWP app?</span></span>

<span data-ttu-id="48077-164">設計プロセスで役立つさまざまなツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="48077-164">We provide a variety of tools to help your design process:</span></span>

- <span data-ttu-id="48077-165">[設計ツールキットのページ](../downloads/index.md)をご覧ください。XD、Illustrator、Photoshop、Framer、Sketch の各ツールキット、および追加の設計ツールやフォントのダウンロードが提供されています。</span><span class="sxs-lookup"><span data-stu-id="48077-165">See our [Design toolkits page](../downloads/index.md) for XD, Illustrator, Photoshop, Framer, and Sketch toolkits, as well as additional design tools and font downloads.</span></span>

- <span data-ttu-id="48077-166">コンピューターを設定して UWP アプリのコードを記述できるようにするには、「[作業の開始と準備](../../get-started/get-set-up.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="48077-166">To get your machine set up to write code for UWP apps, see our [Get started &gt; Get set up](../../get-started/get-set-up.md) article.</span></span>

- <span data-ttu-id="48077-167">UWP の UI を実装する方法については、エンド ツー エンドの「[サンプル UWP アプリ](https://developer.microsoft.com/windows/samples)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="48077-167">For inspiration on how to implement UI for UWP, take a look at our end-to-end [sample UWP apps](https://developer.microsoft.com/windows/samples).</span></span>

## <a name="video-summary"></a><span data-ttu-id="48077-168">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="48077-168">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Designing-Universal-Windows-Platform-apps/player]

## <a name="next-fluent-design-system"></a><span data-ttu-id="48077-169">次: Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="48077-169">Next: Fluent Design System</span></span>

<span data-ttu-id="48077-170">Fluent Design (Microsoft のデザイン システム) の背後にある原則や、UWP アプリに組み込むことができる多くの機能について確認する場合は、引き続き「[Fluent Design System](../fluent-design-system/index.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="48077-170">If you'd like to learn about the principles behind Fluent Design (Microsoft's design system) and see more features you can incorporate into your UWP app, continue on to [Fluent Design System](../fluent-design-system/index.md).</span></span>

## <a name="related-articles"></a><span data-ttu-id="48077-171">関連記事</span><span class="sxs-lookup"><span data-stu-id="48077-171">Related articles</span></span>

- [<span data-ttu-id="48077-172">UWP アプリとは</span><span class="sxs-lookup"><span data-stu-id="48077-172">What's a UWP app?</span></span>](../../get-started/universal-application-platform-guide.md)
- [<span data-ttu-id="48077-173">Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="48077-173">Fluent Design System</span></span>](../fluent-design-system/index.md)
- [<span data-ttu-id="48077-174">XAML プラットフォームの概要</span><span class="sxs-lookup"><span data-stu-id="48077-174">XAML platform overview</span></span>](../../xaml-platform/index.md)
