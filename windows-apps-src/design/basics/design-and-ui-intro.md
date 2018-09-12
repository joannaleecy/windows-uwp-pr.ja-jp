---
author: mijacobs
Description: The universal design features included in every UWP app help you build apps that scale beautifully across a range of devices.
title: ユニバーサル Windows プラットフォーム (UWP) アプリ設計の概要 (Windows アプリ)
ms.assetid: 50A5605E-3A91-41DB-800A-9180717C1E86
ms.author: mijacobs
ms.date: 05/05/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 952db87d0dabdb927a472de17f0c0d7b345bde4e
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3936379"
---
# <a name="introduction-to-uwp-app-design"></a><span data-ttu-id="6be36-103">UWP アプリ設計の概要</span><span class="sxs-lookup"><span data-stu-id="6be36-103">Introduction to UWP app design</span></span>

![サンプルの照明アプリ](images/introUWP-header.jpg)

<span data-ttu-id="6be36-105">ユニバーサル Windows プラットフォーム (UWP) の設計ガイダンスは、美しく洗練されたアプリを設計および構築するのに役立つリソースです。</span><span class="sxs-lookup"><span data-stu-id="6be36-105">The Universal Windows Platform (UWP) design guidance is a resource to help you design and build beautiful, polished apps.</span></span>

<span data-ttu-id="6be36-106">これは規範的な規則の一覧ではなく、進化する [Fluent Design System](../fluent-design-system/index.md)、およびアプリ構築コミュニティのニーズに適応するように設計された生きたドキュメントです。</span><span class="sxs-lookup"><span data-stu-id="6be36-106">It's not a list of prescriptive rules - it's a living document, designed to adapt to our evolving [Fluent Design System](../fluent-design-system/index.md) as well as the needs of our app-building community.</span></span>

<span data-ttu-id="6be36-107">この記事では、あらゆる UWP アプリに含まれているユニバーサル デザイン機能の概要を説明します。これらの機能により、さまざまなデバイス間で美しくスケーリングされるユーザー インターフェイス (UI) を構築できます。</span><span class="sxs-lookup"><span data-stu-id="6be36-107">This introduction provides an overview of the universal design features that are included in every UWP app, helping you build user interfaces (UI) that scale beautifully across a range of devices.</span></span>

## <a name="effective-pixels-and-scaling"></a><span data-ttu-id="6be36-108">有効ピクセルとスケーリング</span><span class="sxs-lookup"><span data-stu-id="6be36-108">Effective pixels and scaling</span></span>

<span data-ttu-id="6be36-109">まず、UWP アプリは、TV からタブレットまたは PC まで、すべての [Windows 10 デバイス](../devices/index.md)で実行されます。</span><span class="sxs-lookup"><span data-stu-id="6be36-109">First of all, UWP apps run on all [Windows 10 devices](../devices/index.md), from your TV to your tablet or PC.</span></span> <span data-ttu-id="6be36-110">それはアプリの UI にどのように影響するのでしょうか。</span><span class="sxs-lookup"><span data-stu-id="6be36-110">How does that affect your app's UI?</span></span>

![さまざまなデバイス上にある同じアプリ](images/universal-image-1.jpg)

<span data-ttu-id="6be36-112">幸いなことに、UWP アプリは、すべてのデバイスと画面サイズで読みやすく、操作しやすいように、UI 要素のサイズを自動的に調整します。</span><span class="sxs-lookup"><span data-stu-id="6be36-112">Well, fortunately for you, UWP apps automatically adjust the size UI elements so that they are legible and easy to interact with on all devices and screen sizes!</span></span>

<span data-ttu-id="6be36-113">デバイスでアプリを実行するとき、システムでは、UI 要素を画面に表示する方法を正規化するアルゴリズムを使います。</span><span class="sxs-lookup"><span data-stu-id="6be36-113">When your app runs on a device, the system uses an algorithm to normalize the way UI elements display on the screen.</span></span> <span data-ttu-id="6be36-114">このスケーリング アルゴリズムでは、視聴距離と画面の密度 (ピクセル/インチ) を考慮して、体感的なサイズを最適化します (物理的なサイズではありません)。</span><span class="sxs-lookup"><span data-stu-id="6be36-114">This scaling algorithm takes into account viewing distance and screen density (pixels per inch) to optimize for perceived size (rather than physical size).</span></span> <span data-ttu-id="6be36-115">スケーリング アルゴリズムによって、10 フィート離れた Surface Hub における 24 ピクセルのフォントが、数インチ離れた 5 インチ サイズの電話における 24 ピクセルのフォントと同じようにユーザーに読みやすい状態で表示されます。</span><span class="sxs-lookup"><span data-stu-id="6be36-115">The scaling algorithm ensures that a 24 px font on Surface Hub 10 feet away is just as legible to the user as a 24 px font on 5" phone that's a few inches away.</span></span>

![さまざまなデバイスの視聴距離](images/scaling-chart.png)

<span data-ttu-id="6be36-117">スケーリング システムのしくみのため、UWP アプリをデザインするときには、実際の物理ピクセルではなく、有効ピクセルでデザインすることになります。</span><span class="sxs-lookup"><span data-stu-id="6be36-117">Because of how the scaling system works, when you design your UWP app, you're designing in effective pixels, not actual physical pixels.</span></span> <span data-ttu-id="6be36-118">有効ピクセル (epx) は仮想的な測定単位で、画面の密度とは無関係にレイアウトのサイズと間隔を表すために使用されます。</span><span class="sxs-lookup"><span data-stu-id="6be36-118">Effective pixels (epx) are a virtual unit of measurement, and they're used to express layout dimensions and spacing, independent of screen density.</span></span> <span data-ttu-id="6be36-119">(ガイドラインでは、epx、ep、および px を区別しないで使用しています。)</span><span class="sxs-lookup"><span data-stu-id="6be36-119">(In our guidelines, epx, ep, and px are used interchangeably.)</span></span>

<span data-ttu-id="6be36-120">設計時には、ピクセル密度と実際の画面解像度を無視できます。</span><span class="sxs-lookup"><span data-stu-id="6be36-120">You can ignore the pixel density and the actual screen resolution when designing.</span></span> <span data-ttu-id="6be36-121">その代わり、サイズ クラスの有効な解像度 (有効ピクセル単位の解像度) が向上するように設計します (詳しくは、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="6be36-121">Instead, design for the effective resolution (the resolution in effective pixels) for a size class (for details, see the [Screen sizes and breakpoints article](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)).</span></span>

> [!TIP]
> <span data-ttu-id="6be36-122">イメージ編集プログラムで画面のモックアップを作成するときは、DPI を 72 に設定し、画像サイズを、対象のサイズ クラスで有効な解像度に設定します</span><span class="sxs-lookup"><span data-stu-id="6be36-122">When creating screen mockups in image editing programs, set the DPI to 72 and set the image dimensions to the effective resolution for the size class you're targeting.</span></span> <span data-ttu-id="6be36-123">サイズ クラスと有効な解像度の一覧については、「[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6be36-123">For a list of size classes and effective resolutions, see the [Screen sizes and breakpoints article](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

### <a name="multiples-of-four"></a><span data-ttu-id="6be36-124">4 の倍数</span><span class="sxs-lookup"><span data-stu-id="6be36-124">Multiples of four</span></span>

:::row:::
    <span data-ttu-id="6be36-125">:::column span::: サイズ、余白、および UI 要素の位置は常に、UWP アプリでは、 **4 epx の倍数**にします。</span><span class="sxs-lookup"><span data-stu-id="6be36-125">:::column span::: The sizes, margins, and positions of UI elements should always be in **multiples of 4 epx** in your UWP apps.</span></span>

        UWP scales across a range of devices with scaling plateaus of 100%, 125%, 150%, 175%, 200%, 225%, 250%, 300%, 350%, and 400%. The base unit is 4 because it's the only integer that can be scaled by non-whole numbers (e.g. 4*1.5 = 6). Using multiples of four aligns all UI elements with whole pixels and ensures UI elements have crisp, sharp edges. (Note that text doesn't have this requirement; text can have any size and position.)
    :::column-end:::
    :::column:::
        ![grid](images/4epx.svg)
    :::column-end:::
:::row-end:::

## <a name="layout"></a><span data-ttu-id="6be36-126">レイアウト</span><span class="sxs-lookup"><span data-stu-id="6be36-126">Layout</span></span>

<span data-ttu-id="6be36-127">UWP アプリは、すべてのデバイスに合わせて自動的に拡大縮小されるので、すべてのデバイスの UWP アプリの設計は同じ構造になっています。</span><span class="sxs-lookup"><span data-stu-id="6be36-127">Since UWP apps automatically scale to all devices, designing a UWP app for any device follows the same structure.</span></span> <span data-ttu-id="6be36-128">UWP アプリの UI の最初から始めましょう。</span><span class="sxs-lookup"><span data-stu-id="6be36-128">Let's start from the very beginning of your UWP app's UI.</span></span>

### <a name="windows-frames-and-pages"></a><span data-ttu-id="6be36-129">Windows、フレーム、ページ</span><span class="sxs-lookup"><span data-stu-id="6be36-129">Windows, Frames, and Pages</span></span>

:::row:::
    :::column:::
        <span data-ttu-id="6be36-130">UWP アプリを起動すると、任意の Windows 10 デバイスで、[フレーム](/uwp/api/Windows.UI.Xaml.Controls.Frame)、[ページ](/uwp/api/Windows.UI.Xaml.Controls.Page)のインスタンス間を移動できる[ウィンドウ](/uwp/api/Windows.UI.Xaml.Controls.Window)で起動します。</span><span class="sxs-lookup"><span data-stu-id="6be36-130">When a UWP app is launched on any Windows 10 device, it launches in a [Window](/uwp/api/Windows.UI.Xaml.Controls.Window) with a [Frame](/uwp/api/Windows.UI.Xaml.Controls.Frame), which can navigate between [Page](/uwp/api/Windows.UI.Xaml.Controls.Page) instances.</span></span>
    :::column-end:::
    :::column:::
        ![フレーム](images/frame.svg)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        <span data-ttu-id="6be36-132">アプリの UI は、ページのコレクションとして考えることができます。</span><span class="sxs-lookup"><span data-stu-id="6be36-132">You can think of your app's UI as a collection of pages.</span></span> <span data-ttu-id="6be36-133">各ページに配置する項目や、ページ間の関係は、開発者が自由に決めることができます。</span><span class="sxs-lookup"><span data-stu-id="6be36-133">It's up to you to decide what should go on each page, and the relationships between pages.</span></span>

        To learn how you can organize your pages, see [Navigation basics](navigation-basics.md).
    :::column-end:::
    :::column:::
        ![Frame](images/collection-pages.svg)
    :::column-end:::
:::row-end:::

### <a name="page-layout"></a><span data-ttu-id="6be36-134">ページのレイアウト</span><span class="sxs-lookup"><span data-stu-id="6be36-134">Page layout</span></span>

<span data-ttu-id="6be36-135">それらのページの外観はどのようになるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="6be36-135">What should those pages look like?</span></span> <span data-ttu-id="6be36-136">ほとんどのページでは一貫性を保つために一般的な構造に従うため、ユーザーはアプリのページ間およびページ内を簡単に移動できます。</span><span class="sxs-lookup"><span data-stu-id="6be36-136">Well, most pages follow a common structure to provide consistency, so users can easily navigate between and within pages of your app.</span></span> <span data-ttu-id="6be36-137">通常、ページには次の 3 つの種類の UI 要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="6be36-137">Pages typically contain three types of UI elements:</span></span>

- <span data-ttu-id="6be36-138">[ナビゲーション](navigation-basics.md)要素は、表示するコンテンツをユーザーが選択できるようにします。</span><span class="sxs-lookup"><span data-stu-id="6be36-138">[Navigation](navigation-basics.md) elements help users choose the content they want to display.</span></span>
- <span data-ttu-id="6be36-139">[コマンド](commanding-basics.md)要素は、操作、保存、コンテンツの共有などの操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="6be36-139">[Command](commanding-basics.md) elements initiate actions, such as manipulating, saving, or sharing content.</span></span>
- <span data-ttu-id="6be36-140">[コンテンツ](content-basics.md)要素は、アプリのコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="6be36-140">[Content](content-basics.md) elements display the app's content.</span></span>

![一般的なレイアウト パターン](../layout/images/page-components.svg)

<span data-ttu-id="6be36-142">UWP アプリの一般的なパターンを実装する方法の詳細については、「[ページのレイアウト](../layout/page-layout.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6be36-142">To learn more about how to implement common UWP app patterns, see the [Page layout](../layout/page-layout.md) article.</span></span>

<span data-ttu-id="6be36-143">Visual Studio で [Windows Template Studio](https://github.com/Microsoft/WindowsTemplateStudio/tree/master) を使用してアプリのレイアウトを使い始めることもできます。</span><span class="sxs-lookup"><span data-stu-id="6be36-143">You can also use the [Windows Template Studio](https://github.com/Microsoft/WindowsTemplateStudio/tree/master) in Visual Studio to get started with a layout for your app.</span></span>

## <a name="controls"></a><span data-ttu-id="6be36-144">コントロール</span><span class="sxs-lookup"><span data-stu-id="6be36-144">Controls</span></span>

<span data-ttu-id="6be36-145">UWP の設計プラットフォームには、すべての Windows デバイスで適切に動作することが保証されている一連のコモン コントロールが用意されており、[Fluent Design System](../fluent-design-system/index.md) の原則に従っています。</span><span class="sxs-lookup"><span data-stu-id="6be36-145">UWP's design platform provides a set of common controls that are guaranteed to work well on all Windows-powered devices, and they adhere to our [Fluent Design System](../fluent-design-system/index.md) principles.</span></span> <span data-ttu-id="6be36-146">これらのコントロールには、ボタンやテキスト要素などの単純なコントロールから、一連のデータとテンプレートからリストを生成する高度なコントロールまで、すべてのものが含まれます。</span><span class="sxs-lookup"><span data-stu-id="6be36-146">These controls include everything from simple controls, like buttons and text elements, to sophisticated controls that can generate lists from a set of data and a template.</span></span>

![UWP コントロール](../style/images/color/windows-controls.svg)

<span data-ttu-id="6be36-148">UWP コントロールとコントロールに基づいて作成できるパターンの全一覧については、「[コントロールとパターン](../controls-and-patterns/index.md)」セクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="6be36-148">For a complete list of UWP controls and the patterns you can make from them, see the [controls and patterns section](../controls-and-patterns/index.md).</span></span>

## <a name="style"></a><span data-ttu-id="6be36-149">スタイル</span><span class="sxs-lookup"><span data-stu-id="6be36-149">Style</span></span>

<span data-ttu-id="6be36-150">一般的なコントロールは、システム テーマとアクセント カラーを自動的に反映し、すべての入力の種類に対応し、すべてのデバイスに合わせて拡大縮小されます。</span><span class="sxs-lookup"><span data-stu-id="6be36-150">Common controls automatically reflect the system theme and accent color, work with all input types, and scale to all devices.</span></span> <span data-ttu-id="6be36-151">このように、Fluent Design System を反映しているため、順応性が高く、親近感があり、優れた美しさを持っています。</span><span class="sxs-lookup"><span data-stu-id="6be36-151">In that way, they reflect the Fluent Design System - they're adaptive, empathetic, and beautiful.</span></span> <span data-ttu-id="6be36-152">一般的なコントロールでは、既定のスタイルでライト、モーション、深度を使用しているため、コントロールを使用することで、アプリに Fluent Design System を組み込んでいることになります。</span><span class="sxs-lookup"><span data-stu-id="6be36-152">Common controls use light, motion, and depth in their default styles, so by using them, you're incorporating our Fluent Design System in your app.</span></span>

<span data-ttu-id="6be36-153">一般的なコントロールは高度にカスタマイズでき、コントロールの前景色を変更することも、外観を完全にカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="6be36-153">Common controls are highly customizable, too--you can change the foreground color of a control or completely customize it's appearance.</span></span> <span data-ttu-id="6be36-154">コントロールの既定のスタイルを変更するには、[軽量なスタイル設定](../controls-and-patterns/xaml-styles.md#lightweight-styling)を使用するか、XAML で[カスタム コントロール](../controls-and-patterns/control-templates.md)を作成します。</span><span class="sxs-lookup"><span data-stu-id="6be36-154">To override the default styles in controls, use [lightweight styling](../controls-and-patterns/xaml-styles.md#lightweight-styling) or create [custom controls](../controls-and-patterns/control-templates.md) in XAML.</span></span>

![アクセント カラーの gif](images/intro-style.gif)

## <a name="shell"></a><span data-ttu-id="6be36-156">シェル</span><span class="sxs-lookup"><span data-stu-id="6be36-156">Shell</span></span>

:::row:::
    :::column:::
        <span data-ttu-id="6be36-157">UWP アプリでは、Windows[シェル](../shell/tiles-and-notifications/creating-tiles.md)でタイルや通知した幅広い Windows エクスペリエンスを操作します。</span><span class="sxs-lookup"><span data-stu-id="6be36-157">Your UWP app will interact with the broader Windows experience with tiles and notifications in the Windows [Shell](../shell/tiles-and-notifications/creating-tiles.md).</span></span>

        Tiles are displayed in the Start menu and when your app launches, and they provide a glimpse of what's going on in your app. Their power comes from the content behind them, and the intelligence and craft with which they're offered up.

        UWP apps have four tile sizes (small, medium, wide, and large) that can be customized with the app's icon and identity. For guidance on designing tiles for your UWP app, see [Guidelines for tile and icon assets](../shell/tiles-and-notifications/app-assets.md).
    :::column-end:::
    :::column:::
        ![tiles on start menu](images/shell.svg)
    :::column-end:::
:::row-end:::

## <a name="inputs"></a><span data-ttu-id="6be36-158">入力</span><span class="sxs-lookup"><span data-stu-id="6be36-158">Inputs</span></span>

:::row:::
    :::column:::
        <span data-ttu-id="6be36-159">UWP アプリではスマート操作が使用されます。</span><span class="sxs-lookup"><span data-stu-id="6be36-159">UWP apps rely on smart interactions.</span></span> <span data-ttu-id="6be36-160">クリックの発生元がマウスか、スタイラスか、指によるタップかを認識または定義しなくても、クリック操作に対応したデザインを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="6be36-160">You can design around a click interaction without having to know or define whether the click comes from a mouse, a stylus, or a tap of a finger.</span></span> <span data-ttu-id="6be36-161">ただし、[特定の入力モード](../input/input-primer.md)向けにアプリを設計することもできます。</span><span class="sxs-lookup"><span data-stu-id="6be36-161">However, you can also design your apps for [specific input modes](../input/input-primer.md).</span></span>
    :::column-end:::
    :::column:::
        ![入力](images/inputs.svg)
    :::column-end:::
:::row-end:::

## <a name="devices"></a><span data-ttu-id="6be36-163">デバイス</span><span class="sxs-lookup"><span data-stu-id="6be36-163">Devices</span></span>

![デバイス](../layout/images/size-classes.svg)

<span data-ttu-id="6be36-165">同様に、UWP では、さまざまなデバイスに合わせてアプリを自動的にスケーリングしますが、[特定のデバイス向けに UWP アプリを最適化](../devices/index.md)することもできます。</span><span class="sxs-lookup"><span data-stu-id="6be36-165">Similarly, while UWP automatically scales your app to different devices, you can also [optimize your UWP app for specific devices](../devices/index.md).</span></span>

## <a name="usability"></a><span data-ttu-id="6be36-166">使いやすさ</span><span class="sxs-lookup"><span data-stu-id="6be36-166">Usability</span></span>

<img src="https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/REYaAb?ver=727c">

<span data-ttu-id="6be36-167">最後に重要な点として、ユーザビリティの目的は、アプリのエクスペリエンスをすべてのユーザーに開かれたものにすることです。</span><span class="sxs-lookup"><span data-stu-id="6be36-167">Last but not least, usability is about making your app's experience open to all users.</span></span> <span data-ttu-id="6be36-168">すべての人が、本当に包括的なユーザー エクスペリエンスの恩恵を受けます。すべてのユーザーに対してアプリを使いやすくする方法については、「[UWP アプリの操作性](../usability/index.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6be36-168">Everyone can benefit from truly inclusive user experiences - see [usability for UWP apps](../usability/index.md) to see how to make your app easy to use for everyone.</span></span>

<span data-ttu-id="6be36-169">国際的なユーザーを対象に設計している場合は、[グローバリゼーションとローカライズ](../globalizing/globalizing-portal.md)を確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="6be36-169">If you're designing for international audiences, you might want to check out [Globalization and localization](../globalizing/globalizing-portal.md).</span></span>

<span data-ttu-id="6be36-170">視覚障碍、聴覚障碍、運動障碍を持つユーザーに関して、「[アクセシビリティ機能](../accessibility/accessibility-overview.md)」も検討してください。</span><span class="sxs-lookup"><span data-stu-id="6be36-170">You might also want to consider [accessibility features](../accessibility/accessibility-overview.md) for users with limited sight, hearing, and mobility.</span></span> <span data-ttu-id="6be36-171">アクセシビリティが最初から設計に組み込まれている場合は、[アプリをアクセシビリティ対応にする](../accessibility/accessibility-in-the-store.md)ことにほとんど時間と労力がかかりません。</span><span class="sxs-lookup"><span data-stu-id="6be36-171">If accessibility is built into your design from the start, then [making your app accessible](../accessibility/accessibility-in-the-store.md) should take very little extra time and effort.</span></span>

## <a name="tools-and-design-toolkits"></a><span data-ttu-id="6be36-172">ツールと設計ツールキット</span><span class="sxs-lookup"><span data-stu-id="6be36-172">Tools and design toolkits</span></span>

<span data-ttu-id="6be36-173">基本的な設計機能がわかったので、UWP アプリの設計を開始しましょう。</span><span class="sxs-lookup"><span data-stu-id="6be36-173">Now that you know about the basic design features, how about getting started with designing your UWP app?</span></span>

<span data-ttu-id="6be36-174">設計プロセスで役立つさまざまなツールが用意されています。</span><span class="sxs-lookup"><span data-stu-id="6be36-174">We provide a variety of tools to help your design process:</span></span>

- <span data-ttu-id="6be36-175">[設計ツールキットのページ](../downloads/index.md)をご覧ください。XD、Illustrator、Photoshop、Framer、Sketch の各ツールキット、および追加の設計ツールやフォントのダウンロードが提供されています。</span><span class="sxs-lookup"><span data-stu-id="6be36-175">See our [Design toolkits page](../downloads/index.md) for XD, Illustrator, Photoshop, Framer, and Sketch toolkits, as well as additional design tools and font downloads.</span></span>

- <span data-ttu-id="6be36-176">コンピューターを設定して UWP アプリのコードを記述できるようにするには、「[作業の開始と準備](../../get-started/get-set-up.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6be36-176">To get your machine set up to write code for UWP apps, see our [Get started &gt; Get set up](../../get-started/get-set-up.md) article.</span></span>

- <span data-ttu-id="6be36-177">UWP の UI を実装する方法については、エンド ツー エンドの「[サンプル UWP アプリ](https://developer.microsoft.com/windows/samples)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6be36-177">For inspiration on how to implement UI for UWP, take a look at our end-to-end [sample UWP apps](https://developer.microsoft.com/windows/samples).</span></span>

## <a name="video-summary"></a><span data-ttu-id="6be36-178">ビデオの概要</span><span class="sxs-lookup"><span data-stu-id="6be36-178">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Designing-Universal-Windows-Platform-apps/player]

## <a name="next-fluent-design-system"></a><span data-ttu-id="6be36-179">次: Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="6be36-179">Next: Fluent Design System</span></span>

<span data-ttu-id="6be36-180">Fluent Design (Microsoft のデザイン システム) の背後にある原則や、UWP アプリに組み込むことができる多くの機能について確認する場合は、引き続き「[Fluent Design System](../fluent-design-system/index.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6be36-180">If you'd like to learn about the principles behind Fluent Design (Microsoft's design system) and see more features you can incorporate into your UWP app, continue on to [Fluent Design System](../fluent-design-system/index.md).</span></span>

## <a name="related-articles"></a><span data-ttu-id="6be36-181">関連記事</span><span class="sxs-lookup"><span data-stu-id="6be36-181">Related articles</span></span>

- [<span data-ttu-id="6be36-182">UWP アプリとは</span><span class="sxs-lookup"><span data-stu-id="6be36-182">What's a UWP app?</span></span>](../../get-started/universal-application-platform-guide.md)
- [<span data-ttu-id="6be36-183">Fluent Design System</span><span class="sxs-lookup"><span data-stu-id="6be36-183">Fluent Design System</span></span>](../fluent-design-system/index.md)
- [<span data-ttu-id="6be36-184">XAML プラットフォームの概要</span><span class="sxs-lookup"><span data-stu-id="6be36-184">XAML platform overview</span></span>](../../xaml-platform/index.md)
