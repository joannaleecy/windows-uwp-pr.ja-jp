---
author: Jwmsft
Description: "XAML では、応答性の高い UI を作成できる柔軟なレイアウト システムが提供されます。"
title: "XAML を使ったレイアウトの定義"
ms.assetid: 8D4E4162-1C9C-48F4-8A94-34976FB17079
label: Page layouts with XAML
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: a491a13264a19c50affdbacded69c7ff73e99afa
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="define-page-layouts-with-xaml"></a><span data-ttu-id="f5098-104">XAML を使ったページ レイアウトの定義</span><span class="sxs-lookup"><span data-stu-id="f5098-104">Define page layouts with XAML</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="f5098-105">XAML では、自動サイズ変更、レイアウト パネル、表示状態、独立した UI 定義を使って応答性の高い UI を作成できる、柔軟なレイアウト システムが提供されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-105">XAML gives you a flexible layout system that lets you use automatic sizing, layout panels, visual states, and even separate UI definitions to create a responsive UI.</span></span> <span data-ttu-id="f5098-106">柔軟な設計を施すと、サイズ、解像度、ピクセル密度、向きがさまざまに異なるアプリのウィンドウを画面で適切に表示できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-106">With a flexible design, you can make your app look great on screens with different app window sizes, resolutions, pixel densities, and orientations.</span></span>

<span data-ttu-id="f5098-107">ここでは、XAML プロパティとレイアウト パネルを使って、アプリの応答性と適応性を高める方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="f5098-107">Here, we discuss how to use XAML properties and layout panels to make your app responsive and adaptive.</span></span> <span data-ttu-id="f5098-108">「[UWP アプリ設計の概要](../layout/design-and-ui-intro.md)」に示されている、応答性の高い UI のデザインと手法に関する重要な情報に基づいて解説しています。</span><span class="sxs-lookup"><span data-stu-id="f5098-108">We build on important info about responsive UI design and techniques found in [Introduction to UWP app design](../layout/design-and-ui-intro.md).</span></span> <span data-ttu-id="f5098-109">有効ピクセルの意味を理解し、レスポンシブ デザインの各手法 (位置変更、サイズ変更、再配置、表示、置換、再構築) について理解しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-109">You should understand what effective pixels are and understand each of the responsive design techniques: Reposition, Resize, Reflow, Reveal, Replace, and Re-architect.</span></span>

> [!NOTE]
> <span data-ttu-id="f5098-110">アプリのレイアウトは、ナビゲーション モデルを選ぶことから始まります。["タブとピボット"](../controls-and-patterns/tabs-pivot.md) モデルの [**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) と、["ナビゲーション ウィンドウ"](../controls-and-patterns/navigationview.md) モデルの [**SplitView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) のどちらを使うかなどです。</span><span class="sxs-lookup"><span data-stu-id="f5098-110">Your app layout begins with the navigation model you choose, like whether to use a [**Pivot**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.pivot.aspx) with the [‘tabs and pivot’](../controls-and-patterns/tabs-pivot.md) model or [**SplitView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) with the [‘nav pane’](../controls-and-patterns/navigationview.md) model.</span></span> <span data-ttu-id="f5098-111">詳しくは、「[UWP アプリのナビゲーション デザインの基本](../layout/navigation-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-111">For more info about that, see [Navigation design basics for UWP apps](../layout/navigation-basics.md).</span></span> <span data-ttu-id="f5098-112">ここでは、1 つのページまたは要素のグループのレイアウトの応答性を高める手法について説明します。</span><span class="sxs-lookup"><span data-stu-id="f5098-112">Here, we talk about techniques to make the layout of a single page or group of elements responsive.</span></span> <span data-ttu-id="f5098-113">この情報は、アプリについて選択したナビゲーション モデルにかかわらず適用されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-113">This info is applicable regardless of which navigation model you choose for your app.</span></span>

<span data-ttu-id="f5098-114">XAML フレームワークには、応答性に優れた UI の作成に使うことができる複数レベルの最適化が用意されています。</span><span class="sxs-lookup"><span data-stu-id="f5098-114">The XAML framework provides several levels of optimization you can use to create a responsive UI.</span></span>
- <span data-ttu-id="f5098-115">**柔軟なレイアウト**
    レイアウト プロパティとパネルを使って、既定の UI の柔軟性を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-115">**Fluid layout**
  Use layout properties and panels to make your default UI fluid.</span></span>

    <span data-ttu-id="f5098-116">レスポンシブ レイアウトの基盤は、レイアウト プロパティとパネルを適切に使用することにより、コンテンツの位置変更、サイズ変更、再配置を行うことです。</span><span class="sxs-lookup"><span data-stu-id="f5098-116">The foundation of a responsive layout is the appropriate use of layout properties and panels to reposition, resize, and reflow content.</span></span> <span data-ttu-id="f5098-117">要素で固定サイズを設定したり、自動サイズ変更を使って親レイアウト パネルに合わせてサイズを変更したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-117">You can set a fixed size on an element, or use automatic sizing to let the parent layout panel size it.</span></span> <span data-ttu-id="f5098-118">さまざまな [**Panel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.panel.aspx) クラス ([**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)、[**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) など) で、子のサイズ変更や配置のさまざまな方法が提供されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-118">The various [**Panel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.panel.aspx) classes, such as [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx), [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx), [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) and [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx), provide different ways to size and position their children.</span></span>

- <span data-ttu-id="f5098-119">**アダプティブ レイアウト**
    ウィンドウのサイズまたはその他の変更に基づいて、UI に大幅な変更を行うには、表示状態を使用します。</span><span class="sxs-lookup"><span data-stu-id="f5098-119">**Adaptive layout**
  Use visual states to make significant alterations to your UI based on window size or other changes.</span></span>

    <span data-ttu-id="f5098-120">アプリ ウィンドウを一定量を超えて拡大/縮小するときに、レイアウト プロパティを変更して、UI のセクションの位置変更、サイズ変更、再配置、表示、置換を行うことが必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-120">When your app window grows or shrinks beyond a certain amount, you might want to alter layout properties to reposition, resize, reflow, reveal, or replace sections of your UI.</span></span> <span data-ttu-id="f5098-121">UI のさまざまな表示状態を定義し、ウィンドウの幅や高さが指定したしきい値を超えたときに適用できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-121">You can define different visual states for your UI, and apply them when the window width or window height crosses a specified threshold.</span></span> <span data-ttu-id="f5098-122">[**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) を使うと、状態を適用するしきい値 ("ブレークポイント" とも呼ばれます) を簡単に設定できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-122">An [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) provides an easy way to set the threshold (also called 'breakpoint') where a state is applied.</span></span>

- <span data-ttu-id="f5098-123">**カスタマイズされたレイアウト**
    カスタマイズされたレイアウトは、特定のデバイス ファミリやさまざまな画面サイズに最適化されています。</span><span class="sxs-lookup"><span data-stu-id="f5098-123">**Tailored layout**
  A tailored layout is optimized for a specific device family or range of screen sizes.</span></span> <span data-ttu-id="f5098-124">デバイス ファミリ内でも、レイアウトはサポートされているウィンドウ サイズの範囲内での変更に応答して対応する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-124">Within the device family, the layout should still respond and adapt to changes within the range of supported window sizes.</span></span>
    > <span data-ttu-id="f5098-125">**注**&nbsp;&nbsp; [電話用の Continuum](http://go.microsoft.com/fwlink/p/?LinkID=699431) を使用すると、ユーザーは電話をモニター、マウス、キーボードに接続できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-125">**Note**&nbsp;&nbsp; With [Continuum for Phones](http://go.microsoft.com/fwlink/p/?LinkID=699431), users can connect their phones to a monitor, mouse, and keyboard.</span></span> <span data-ttu-id="f5098-126">この機能は、電話とデスクトップ デバイス ファミリ間の境界線を曖昧します。</span><span class="sxs-lookup"><span data-stu-id="f5098-126">This capability blurs the lines between phone and desktop device families.</span></span>

    <span data-ttu-id="f5098-127">カスタマイズする方法には、次の手法が含まれます。</span><span class="sxs-lookup"><span data-stu-id="f5098-127">Approaches to tailoring include</span></span>
    - <span data-ttu-id="f5098-128">カスタム トリガーを作成します。</span><span class="sxs-lookup"><span data-stu-id="f5098-128">Create custom trigger</span></span>

    <span data-ttu-id="f5098-129">アダプティブ トリガーの場合と同じように、デバイス ファミリ トリガーを作成して、その setter に変更を加えることができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-129">You can create a device family trigger and modify its setters, as for adaptive triggers.</span></span>

    - <span data-ttu-id="f5098-130">各デバイス ファミリの個々のビューを定義するには、個別の XAML ファイルを使用します。</span><span class="sxs-lookup"><span data-stu-id="f5098-130">Use separate XAML files to define distinct views for each device family.</span></span>

    <span data-ttu-id="f5098-131">個別の XAML ファイルと同じコード ファイルを使って、デバイス ファミリごとの UI のビューを定義できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-131">You can use separate XAML files with the same code file to define per-device family views of the UI.</span></span>

    - <span data-ttu-id="f5098-132">各デバイス ファミリに異なる実装を提供するには、個別の XAML とコードを使います。</span><span class="sxs-lookup"><span data-stu-id="f5098-132">Use separate XAML and code to provide different implementations for each device family.</span></span>

    <span data-ttu-id="f5098-133">ページのさまざまな実装 (XAML とコード) を提供し、デバイス ファミリ、画面サイズ、その他の要因に基づいて特定の実装に移動することができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-133">You can provide different implementations of a page (XAML and code), then navigate to a particular implementation based on the device family, screen size, or other factors.</span></span>

## <a name="layout-properties-and-panels"></a><span data-ttu-id="f5098-134">レイアウト プロパティとパネル</span><span class="sxs-lookup"><span data-stu-id="f5098-134">Layout properties and panels</span></span>

<span data-ttu-id="f5098-135">レイアウトは、UI のオブジェクトのサイズ変更と配置を行うプロセスです。</span><span class="sxs-lookup"><span data-stu-id="f5098-135">Layout is the process of sizing and positioning objects in your UI.</span></span> <span data-ttu-id="f5098-136">ビジュアル オブジェクトを配置するには、パネルなどのコンテナー オブジェクトにビジュアル オブジェクトを配置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-136">To position visual objects, you must put them in a panel or other container object.</span></span> <span data-ttu-id="f5098-137">XAML フレームワークには、UI 要素を内部に配置できるコンテナーとしての役割を持つさまざまなパネル クラス ([**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx)、[**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx)、[**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx)、[**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) など) が用意されています。</span><span class="sxs-lookup"><span data-stu-id="f5098-137">The XAML framework provides various panel classes, such as [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx), [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx), [**RelativePanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) and [**StackPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx), which serve as containers and enable you to position and arrange the UI elements within them.</span></span>

<span data-ttu-id="f5098-138">XAML レイアウト システムでは、静的レイアウトと柔軟なレイアウトの両方がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="f5098-138">The XAML layout system supports both static and fluid layouts.</span></span> <span data-ttu-id="f5098-139">静的レイアウトでは、コントロールのピクセル サイズと位置を明示的に指定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-139">In a static layout, you give controls explicit pixel sizes and positions.</span></span> <span data-ttu-id="f5098-140">ユーザーがデバイスの解像度や向きを変えても、UI は変更されません。</span><span class="sxs-lookup"><span data-stu-id="f5098-140">When the user changes the resolution or orientation of their device, the UI doesn't change.</span></span> <span data-ttu-id="f5098-141">静的レイアウトは、フォーム ファクターやディスプレイ サイズが変わると、不適切にはみ出すことがあります。</span><span class="sxs-lookup"><span data-stu-id="f5098-141">Static layouts can become clipped across different form factors and display sizes.</span></span>

<span data-ttu-id="f5098-142">柔軟なレイアウトは、デバイス上で使用できる表示領域に合わせて縮小、拡大、再配置されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-142">Fluid layouts shrink, grow, and reflow to respond to the visual space available on a device.</span></span> <span data-ttu-id="f5098-143">柔軟なレイアウトを作成するには、要素の自動または比例サイズ設定、配置、余白、パディングを使用し、必要に応じて、レイアウト パネルで子を配置できるようにします。</span><span class="sxs-lookup"><span data-stu-id="f5098-143">To create a fluid layout, use automatic or proportional sizing for elements, alignment, margins, and padding, and let layout panels position their children as needed.</span></span> <span data-ttu-id="f5098-144">子要素を配置するには、互いの関係に応じてどのように配置し、子要素のコンテンツ、親要素、またはその両方を基準としてどのようにサイズ変更するかを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-144">You arrange child elements by specifying how they should be arranged in relationship to each other, and how they should be sized relative to their content and/or their parent.</span></span>

<span data-ttu-id="f5098-145">実際には、静的要素と柔軟な要素の組み合わせを使って UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="f5098-145">In practice, you use a combination of static and fluid elements to create your UI.</span></span> <span data-ttu-id="f5098-146">場所によっては静的な要素と値を使うこともありますが、UI 全体の応答性を高くし、さまざまな解像度、レイアウト、ビューに対応させる必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-146">You still use static elements and values in some places, but make sure that the overall UI is responsive and adapts to different resolutions, layouts, and views.</span></span>

### <a name="layout-properties"></a><span data-ttu-id="f5098-147">レイアウト プロパティ</span><span class="sxs-lookup"><span data-stu-id="f5098-147">Layout properties</span></span>

<span data-ttu-id="f5098-148">要素のサイズと位置を制御するには、レイアウト プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-148">To control the size and position of an element, you set its layout properties.</span></span> <span data-ttu-id="f5098-149">一般的なレイアウト プロパティとその効果を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-149">Here are some common layout properties and their effect.</span></span>

**<span data-ttu-id="f5098-150">高さと幅</span><span class="sxs-lookup"><span data-stu-id="f5098-150">Height and Width</span></span>**

<span data-ttu-id="f5098-151">要素のサイズを変更するには、[**Height**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) プロパティと [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-151">Set the [**Height**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) and [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) properties to specify the size of an element.</span></span> <span data-ttu-id="f5098-152">有効ピクセル単位で測定された固定値を使うことも、自動サイズ変更または比例サイズ変更を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="f5098-152">You can use fixed values measured in effective pixels, or you can use auto or proportional sizing.</span></span> <span data-ttu-id="f5098-153">実行時に要素のサイズを取得するには、Height と Width の代わりに、[**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualheight.aspx) プロパティと [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualwidth.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f5098-153">To get the size of an element at runtime, use the [**ActualHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualheight.aspx) and [**ActualWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.actualwidth.aspx) properties instead of Height and Width.</span></span>

<span data-ttu-id="f5098-154">UI 要素がコンテンツや親コンテナーに合わせてサイズ変更できるようにするには、自動サイズ変更を使います。</span><span class="sxs-lookup"><span data-stu-id="f5098-154">You use auto sizing to let UI elements resize to fit their content or parent container.</span></span> <span data-ttu-id="f5098-155">グリッドの行と列を使って、自動サイズ変更を行うこともできます。</span><span class="sxs-lookup"><span data-stu-id="f5098-155">You can also use auto sizing with the rows and columns of a grid.</span></span> <span data-ttu-id="f5098-156">自動サイズ変更を使うには、UI 要素の Height や Width を **Auto** に設定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-156">To use auto sizing, set the Height and/or Width of UI elements to **Auto**.</span></span>

> [!NOTE]
> <span data-ttu-id="f5098-157">コンテンツやコンテナーに合わせて要素のサイズが変更されるかどうかは、[**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) プロパティと [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) プロパティの値、および親コンテナーで子のサイズ変更を処理する方法によって決まります。</span><span class="sxs-lookup"><span data-stu-id="f5098-157">Whether an element resizes to its content or its container depends on the value of its [**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) and [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) properties, and how the parent container handles sizing of its children.</span></span> <span data-ttu-id="f5098-158">詳しくは、この記事の「[配置]()」と「[レイアウト パネル]()」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-158">For more info, see [Alignment]() and [Layout panels]() later in this article.</span></span>

<span data-ttu-id="f5098-159">比例サイズ変更 (*スター サイズ指定*とも呼ばれる) を使うと、使用可能なスペースが加重比率によりグリッドの行と列の間で分散されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-159">You use proportional sizing, also called *star sizing*, to distribute available space among the rows and columns of a grid by weighted proportions.</span></span> <span data-ttu-id="f5098-160">XAML では、スター値は \* (重み付きのスター サイズ指定の場合は *n*\*) として表されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-160">In XAML, star values are expressed as \* (or *n*\* for weighted star sizing).</span></span> <span data-ttu-id="f5098-161">たとえば、2 段組レイアウトで 1 つの列と、幅が 5 倍の列とを指定するには、[**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.aspx) 要素の [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.width.aspx) プロパティで "5\*" と "\*" を使います。</span><span class="sxs-lookup"><span data-stu-id="f5098-161">For example, to specify that one column is 5 times wider than the second column in a 2-column layout, use "5\*" and "\*" for the [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.width.aspx) properties in the [**ColumnDefinition**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.columndefinition.aspx) elements.</span></span>

<span data-ttu-id="f5098-162">次の例では、4 つの列を含む [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) で、固定、自動、比例サイズ指定を組み合わせています。</span><span class="sxs-lookup"><span data-stu-id="f5098-162">This example combines fixed, auto, and proportional sizing in a [**Grid**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) with 4 columns.</span></span>

&nbsp;|&nbsp;|&nbsp;
------|------|------
<span data-ttu-id="f5098-163">Column_1</span><span class="sxs-lookup"><span data-stu-id="f5098-163">Column_1</span></span> | **<span data-ttu-id="f5098-164">Auto</span><span class="sxs-lookup"><span data-stu-id="f5098-164">Auto</span></span>** | <span data-ttu-id="f5098-165">列は、コンテンツが収まるようにサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-165">The column will size to fit its content.</span></span>
<span data-ttu-id="f5098-166">Column_2</span><span class="sxs-lookup"><span data-stu-id="f5098-166">Column_2</span></span> | * | <span data-ttu-id="f5098-167">[自動] 列の計算後、この列は残りの幅の一部を取得します。</span><span class="sxs-lookup"><span data-stu-id="f5098-167">After the Auto columns are calculated, the column gets part of the remaining width.</span></span> <span data-ttu-id="f5098-168">Column_2 の幅は Column_4 の半分になります。</span><span class="sxs-lookup"><span data-stu-id="f5098-168">Column_2 will be one-half as wide as Column_4.</span></span>
<span data-ttu-id="f5098-169">Column_3</span><span class="sxs-lookup"><span data-stu-id="f5098-169">Column_3</span></span> | **<span data-ttu-id="f5098-170">44</span><span class="sxs-lookup"><span data-stu-id="f5098-170">44</span></span>** | <span data-ttu-id="f5098-171">列の幅は 44 ピクセルに設定されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-171">The column will be 44 pixels wide.</span></span>
<span data-ttu-id="f5098-172">Column_4</span><span class="sxs-lookup"><span data-stu-id="f5098-172">Column_4</span></span> | **<span data-ttu-id="f5098-173">2</span><span class="sxs-lookup"><span data-stu-id="f5098-173">2</span></span>**\* | <span data-ttu-id="f5098-174">[自動] 列の計算後、この列は残りの幅の一部を取得します。</span><span class="sxs-lookup"><span data-stu-id="f5098-174">After the Auto columns are calculated, the column gets part of the remaining width.</span></span> <span data-ttu-id="f5098-175">Column_4 の幅は Column_2 の 2 倍になります。</span><span class="sxs-lookup"><span data-stu-id="f5098-175">Column_4 will be twice as wide as Column_2.</span></span>

<span data-ttu-id="f5098-176">既定の列の幅は "*" であるため、2 つ目の列については、この値を明示的に設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f5098-176">The default column width is "*", so you don't need to explicitly set this value for the second column.</span></span>

```xaml
<Grid>
    <Grid.ColumnDefinitions>
        <ColumnDefinition Width="Auto"/>
        <ColumnDefinition/>
        <ColumnDefinition Width="44"/>
        <ColumnDefinition Width="2*"/>
    </Grid.ColumnDefinitions>
    <TextBlock Text="Column 1 sizes to its conent." FontSize="24"/>
</Grid>
```

<span data-ttu-id="f5098-177">Visual Studio の XAML デザイナーでは、結果は次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-177">In the Visual Studio XAML designer, the result looks like this.</span></span>

![Visual Studio デザイナーでの 4 列のグリッド](images/xaml-layout-grid-in-designer.png)

**<span data-ttu-id="f5098-179">サイズの制約</span><span class="sxs-lookup"><span data-stu-id="f5098-179">Size constraints</span></span>**

<span data-ttu-id="f5098-180">UI で自動サイズ変更を使用する場合でも、要素のサイズに制約を設けることが必要になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-180">When you use auto sizing in your UI, you might still need to place constraints on the size of an element.</span></span> <span data-ttu-id="f5098-181">[**MinWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minwidth.aspx)/[**MaxWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxwidth.aspx) と [**MinHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minheight.aspx)/[**MaxHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxheight.aspx) の各プロパティを設定することによって、柔軟なサイズ変更を許可しながら、要素のサイズを制約する値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-181">You can set the [**MinWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minwidth.aspx)/[**MaxWidth**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxwidth.aspx) and [**MinHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.minheight.aspx)/[**MaxHeight**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.maxheight.aspx) properties to specify values that constrain the size of an element while allowing fluid resizing.</span></span>

<span data-ttu-id="f5098-182">また、Grid では、MinWidth/MaxWidth を列定義と共に使用でき、MinHeight/MaxHeight を行定義と共に使用できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-182">In a Grid, MinWidth/MaxWidth can also be used with column definitions, and MinHeight/MaxHeight can be used with row definitions.</span></span>

**<span data-ttu-id="f5098-183">配置</span><span class="sxs-lookup"><span data-stu-id="f5098-183">Alignment</span></span>**

<span data-ttu-id="f5098-184">親コンテナー内の要素の配置方法を指定するには、[**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) プロパティと [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f5098-184">Use the [**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) and [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) properties to specify how an element should be positioned within its parent container.</span></span>
- <span data-ttu-id="f5098-185">**HorizontalAlignment** の値は、**Left**、**Center**、**Right**、**Stretch** です。</span><span class="sxs-lookup"><span data-stu-id="f5098-185">The values for **HorizontalAlignment** are **Left**, **Center**, **Right**, and **Stretch**.</span></span>
- <span data-ttu-id="f5098-186">**VerticalAlignment** の値は、**Top**、**Center**、**Bottom**、**Stretch** です。</span><span class="sxs-lookup"><span data-stu-id="f5098-186">The values for **VerticalAlignment** are **Top**, **Center**, **Bottom**, and **Stretch**.</span></span>

<span data-ttu-id="f5098-187">**Stretch** 配置にすると、要素は、親コンテナーで提供されたスペース全体に配置されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-187">With the **Stretch** alignment, elements fill all the space they're provided in the parent container.</span></span> <span data-ttu-id="f5098-188">Stretch は、両方の配置プロパティの既定値です。</span><span class="sxs-lookup"><span data-stu-id="f5098-188">Stretch is the default for both alignment properties.</span></span> <span data-ttu-id="f5098-189">ただし、[**Button**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx) などの一部のコントロールでは、その既定のスタイルでこの値がオーバーライドされます。</span><span class="sxs-lookup"><span data-stu-id="f5098-189">However, some controls, like [**Button**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.button.aspx), override this value in their default style.</span></span>
<span data-ttu-id="f5098-190">子要素を持つことができるすべての要素で、HorizontalAlignment プロパティと VerticalAlignment プロパティの Stretch 値を一意に処理することができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-190">Any element that can have child elements can treat the Stretch value for HorizontalAlignment and VerticalAlignment properties uniquely.</span></span> <span data-ttu-id="f5098-191">たとえば、既定の Stretch 値を使用する要素が Grid に配置された場合、要素はその要素を含むセルいっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-191">For example, an element using the default Stretch values placed in a Grid stretches to fill the cell that contains it.</span></span> <span data-ttu-id="f5098-192">同じ要素が Canvas に配置された場合は、そのコンテンツに合わせてサイズが変更されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-192">The same element placed in a Canvas sizes to its content.</span></span> <span data-ttu-id="f5098-193">各パネルでの Stretch 値の処理方法について詳しくは、「[レイアウト パネル](layout-panels.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-193">For more info about how each panel handles the Stretch value, see the [Layout panels](layout-panels.md) article.</span></span>

<span data-ttu-id="f5098-194">詳しくは、「[配置、余白、およびパディング](alignment-margin-padding.md)」や、[**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) と [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-194">For more info, see the [Alignment, margin, and padding](alignment-margin-padding.md) article, and the [**HorizontalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.horizontalalignment.aspx) and [**VerticalAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.verticalalignment.aspx) reference pages.</span></span>

<span data-ttu-id="f5098-195">コントロールには、コンテンツの配置を指定するために使用する、[**HorizontalContentAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.horizontalcontentalignment.aspx) プロパティと [**VerticalContentAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.verticalcontentalignment.aspx) プロパティもあります。</span><span class="sxs-lookup"><span data-stu-id="f5098-195">Controls also have [**HorizontalContentAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.horizontalcontentalignment.aspx) and [**VerticalContentAlignment**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.verticalcontentalignment.aspx) properties that you use to specify how they position their content.</span></span> <span data-ttu-id="f5098-196">すべてのコントロールでこれらのプロパティを利用できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="f5098-196">Not all controls make use of these properties.</span></span> <span data-ttu-id="f5098-197">これらのプロパティは、コントロール テンプレートが、プレゼンターまたはコントロール内のコンテンツ領域の HorizontalAlignment/VerticalAlignment 値のソースとしてこれらのプロパティを使用している場合に、コントロールのレイアウト動作にのみ影響します。</span><span class="sxs-lookup"><span data-stu-id="f5098-197">They only affect layout behavior for a control when its template uses the properties as the source of a HorizontalAlignment/VerticalAlignment value for presenters or content areas within it.</span></span>

<span data-ttu-id="f5098-198">[TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx)、[TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx)、[RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx) の場合、**TextAlignment** プロパティを使用して、コントロール内のテキストの配置を制御します。</span><span class="sxs-lookup"><span data-stu-id="f5098-198">For [TextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textblock.aspx), [TextBox](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.textbox.aspx), and [RichTextBlock](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.richtextblock.aspx), use the **TextAlignment** property to control the alignment of text in the control.</span></span>

**<span data-ttu-id="f5098-199">余白とパディング</span><span class="sxs-lookup"><span data-stu-id="f5098-199">Margins and padding</span></span>**

<span data-ttu-id="f5098-200">要素を囲む空白のスペースの量を制御するには、[**Margin**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.margin.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-200">Set the [**Margin**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.margin.aspx) property to control the amount of empty space around an element.</span></span> <span data-ttu-id="f5098-201">Margin は、ActualHeight と ActualWidth にピクセルを追加せず、入力イベントのヒット テストとソースの目的のために要素の一部と見なされることもありません。</span><span class="sxs-lookup"><span data-stu-id="f5098-201">Margin does not add pixels to the ActualHeight and ActualWidth, and is also not considered part of the element for purposes of hit testing and sourcing input events.</span></span>

<span data-ttu-id="f5098-202">要素の内側の境界線とそのコンテンツの間のスペースの量を制御するには、[**Padding**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.padding.aspx) プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-202">Set the [**Padding**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.padding.aspx) property to control the amount of space between the inner border of an element and its content.</span></span> <span data-ttu-id="f5098-203">正の Padding 値は、要素のコンテンツ領域が小さくなります。</span><span class="sxs-lookup"><span data-stu-id="f5098-203">A positive Padding value decreases the content area of the element.</span></span>

<span data-ttu-id="f5098-204">次の図は、要素に余白やパディングを適用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-204">This diagram shows how Margin and Padding are applied to an element.</span></span>

![余白とパディング](images/xaml-layout-margins-padding.png)

<span data-ttu-id="f5098-206">Margin と Padding の左、右、上、下の値は、対称である必要はなく、負の値に設定できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-206">The left, right, top, and bottom values for Margin and Padding do not need to be symmetrical, and they can be set to negative values.</span></span> <span data-ttu-id="f5098-207">詳しくは、「[配置、余白、およびパディング](alignment-margin-padding.md)」や、[**Margin**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.margin.aspx) と [**Padding**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.padding.aspx) のリファレンス ページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-207">For more info, see [Alignment, margin, and padding](alignment-margin-padding.md), and the [**Margin**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.margin.aspx) or [**Padding**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.padding.aspx) reference pages.</span></span>

<span data-ttu-id="f5098-208">実際のコントロールで、Margin と Padding の効果を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f5098-208">Let's look at the effects of Margin and Padding on real controls.</span></span> <span data-ttu-id="f5098-209">Margin と Padding が既定値の 0 である、Grid 内の TextBox を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-209">Here’s a TextBox inside of a Grid with the default Margin and Padding values of 0.</span></span>

![余白とパディングが 0 である TextBox](images/xaml-layout-textbox-no-margins-padding.png)

<span data-ttu-id="f5098-211">同じ TextBox と Grid で、TextBox の Margin と Padding の値を、この XAML で示されているように設定した場合を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-211">Here’s the same TextBox and Grid with Margin and Padding values on the TextBox as shown in this XAML.</span></span>

```xaml
<Grid BorderBrush="Blue" BorderThickness="4" Width="200">
    <TextBox Text="This is text in a TextBox." Margin="20" Padding="24,16"/>
</Grid>
```

![余白とパディングを正の値に設定した TextBox](images/xaml-layout-textbox-with-margins-padding.png)

**<span data-ttu-id="f5098-213">表示</span><span class="sxs-lookup"><span data-stu-id="f5098-213">Visibility</span></span>**

<span data-ttu-id="f5098-214">[**Visibility**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.visibility.aspx) プロパティを [**Visibility** 列挙値](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visibility.aspx)のいずれか (**Visible** または **Collapsed**) に設定することによって、要素の表示と非表示を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-214">You can reveal or hide an element by setting its [**Visibility**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.visibility.aspx) property to one of the [**Visibility** enumeration](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visibility.aspx) values: **Visible** or **Collapsed**.</span></span> <span data-ttu-id="f5098-215">要素が Collapsed である場合、UI レイアウト内の領域は使用されません。</span><span class="sxs-lookup"><span data-stu-id="f5098-215">When an element is Collapsed, it doesn't take up any space in the UI layout.</span></span>

<span data-ttu-id="f5098-216">コードまたは表示状態で、要素の Visibility プロパティを変更できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-216">You can change an element's Visibility property in code or in a visual state.</span></span> <span data-ttu-id="f5098-217">要素の Visibility が変更されると、そのすべての子要素も変更されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-217">When the Visibility of an element is changed, all of its child elements are also changed.</span></span> <span data-ttu-id="f5098-218">1 つのパネルを表示して別のパネルを折りたたむことによって、UI のセクションを置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-218">You can replace sections of your UI by revealing one panel while collapsing another.</span></span>

> <span data-ttu-id="f5098-219">**ヒント**&nbsp;&nbsp;UI に既定で **Collapsed** である要素がある場合、要素が表示されていなくても、オブジェクトは起動時に作成されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-219">**Tip**&nbsp;&nbsp;When you have elements in your UI that are **Collapsed** by default, the objects are still created at startup, even though they aren't visible.</span></span> <span data-ttu-id="f5098-220">これらの要素の読み込みを表示されたときまで遅延するには、**x:DeferLoadStrategy 属性**を "Lazy" に設定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-220">You can defer loading these elements until they are shown by setting the **x:DeferLoadStrategy attribute** to "Lazy".</span></span> <span data-ttu-id="f5098-221">これにより起動時のパフォーマンスが向上することがあります。</span><span class="sxs-lookup"><span data-stu-id="f5098-221">This can improve startup performance.</span></span> <span data-ttu-id="f5098-222">詳しくは、「[x:DeferLoadStrategy 属性](../xaml-platform/x-deferloadstrategy-attribute.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-222">For more info, see [x:DeferLoadStrategy attribute](../xaml-platform/x-deferloadstrategy-attribute.md).</span></span>

### <a name="style-resources"></a><span data-ttu-id="f5098-223">スタイル リソース</span><span class="sxs-lookup"><span data-stu-id="f5098-223">Style resources</span></span>

<span data-ttu-id="f5098-224">コントロールに対して各プロパティ値を個別に設定する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f5098-224">You don't have to set each property value individually on a control.</span></span> <span data-ttu-id="f5098-225">通常、プロパティ値を [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) リソースとしてグループ化し、Style をコントロールに適用する方が効率的です。</span><span class="sxs-lookup"><span data-stu-id="f5098-225">It's typically more efficient to group property values into a [**Style**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.style.aspx) resource and apply the Style to a control.</span></span> <span data-ttu-id="f5098-226">これは、特に、同じプロパティ値を多くのコントロールに適用する必要がある場合に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="f5098-226">This is especially true when you need to apply the same property values to many controls.</span></span> <span data-ttu-id="f5098-227">スタイルの使用について詳しくは、「[コントロールのスタイル](../controls-and-patterns/styling-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-227">For more info about using styles, see [Styling controls](../controls-and-patterns/styling-controls.md).</span></span>

### <a name="layout-panels"></a><span data-ttu-id="f5098-228">レイアウト パネル</span><span class="sxs-lookup"><span data-stu-id="f5098-228">Layout panels</span></span>

<span data-ttu-id="f5098-229">ほとんどのアプリ コンテンツは、特定の形式のグループまたは階層にまとめることができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-229">Most app content can be organized into some form of groupings or hierarchies.</span></span> <span data-ttu-id="f5098-230">レイアウト パネルを使って、アプリの UI 要素をグループ化し、配置します。</span><span class="sxs-lookup"><span data-stu-id="f5098-230">You use layout panels to group and arrange UI elements in your app.</span></span> <span data-ttu-id="f5098-231">レイアウト パネルを選ぶ際に主に考慮が必要なのは、パネルでの子要素の配置とサイズです。</span><span class="sxs-lookup"><span data-stu-id="f5098-231">The main thing to consider when choosing a layout panel is how the panel positions and sizes its child elements.</span></span> <span data-ttu-id="f5098-232">重複する子要素をお互いに重ねる方法を検討する必要があることもあります。</span><span class="sxs-lookup"><span data-stu-id="f5098-232">You might also need to consider how overlapping child elements are layered on top of each other.</span></span>

<span data-ttu-id="f5098-233">XAML フレームワークで提供されるパネル コントロールの主な機能の比較を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-233">Here's a comparison of the main features of the panel controls provided in the XAML framework.</span></span>

<span data-ttu-id="f5098-234">パネル コントロール</span><span class="sxs-lookup"><span data-stu-id="f5098-234">Panel Control</span></span> | <span data-ttu-id="f5098-235">説明</span><span class="sxs-lookup"><span data-stu-id="f5098-235">Description</span></span>
--------------|------------
[**<span data-ttu-id="f5098-236">Canvas</span><span class="sxs-lookup"><span data-stu-id="f5098-236">Canvas</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) | <span data-ttu-id="f5098-237">**Canvas** は柔軟な UI をサポートしていません。子要素の配置とサイズに関するすべての側面を制御します。</span><span class="sxs-lookup"><span data-stu-id="f5098-237">**Canvas** doesn’t support fluid UI; you control all aspects of positioning and sizing child elements.</span></span> <span data-ttu-id="f5098-238">通常、グラフィックスの作成などの特殊な場合や、大規模なアダプティブ UI の小さな静的領域を定義するために使用します。</span><span class="sxs-lookup"><span data-stu-id="f5098-238">You typically use it for special cases like creating graphics or to define small static areas of a larger adaptive UI.</span></span> <span data-ttu-id="f5098-239">コードまたは表示状態を使って、実行時に要素の位置を変更できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-239">You can use code or visual states to reposition elements at runtime.</span></span><li><span data-ttu-id="f5098-240">Canvas.Top 添付プロパティと Canvas.Left 添付プロパティを使って、要素を絶対的に配置します。</span><span class="sxs-lookup"><span data-stu-id="f5098-240">Elements are positioned absolutely using Canvas.Top and Canvas.Left attached properties.</span></span></li><li><span data-ttu-id="f5098-241">Canvas.ZIndex 添付プロパティを使って、重なりを明示的に指定することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5098-241">Layering can be explicitly specified using the Canvas.ZIndex attached property.</span></span></li><li><span data-ttu-id="f5098-242">HorizontalAlignment/VerticalAlignment の Stretch の値は無視されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-242">Stretch values for HorizontalAlignment/VerticalAlignment are ignored.</span></span> <span data-ttu-id="f5098-243">要素のサイズが明示的に設定されていない場合は、そのコンテンツに合わせてサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-243">If an element's size is not set explicitly, it sizes to its content.</span></span></li><li><span data-ttu-id="f5098-244">パネルより大きい場合、子のコンテンツは視覚上クリップされません。</span><span class="sxs-lookup"><span data-stu-id="f5098-244">Child content is not visually clipped if larger than the panel.</span></span> </li><li><span data-ttu-id="f5098-245">子のコンテンツはパネルの境界によって制約されません。</span><span class="sxs-lookup"><span data-stu-id="f5098-245">Child content is not constrained by the bounds of the panel.</span></span></li>
[**<span data-ttu-id="f5098-246">Grid</span><span class="sxs-lookup"><span data-stu-id="f5098-246">Grid</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.grid.aspx) | <span data-ttu-id="f5098-247">**Grid** は、子要素の柔軟なサイズ変更をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="f5098-247">**Grid** supports fluid resizing of child elements.</span></span> <span data-ttu-id="f5098-248">コードまたは表示状態を使って、要素の位置の変更や再配置を実行できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-248">You can use code or visual states to reposition and reflow elements.</span></span><li><span data-ttu-id="f5098-249">Grid.Row 添付プロパティと Grid.Column 添付プロパティを使って、要素は行と列に配置されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-249">Elements are arranged in rows and columns using Grid.Row and Grid.Column attached properties.</span></span></li><li><span data-ttu-id="f5098-250">行や列をまたいで要素を表示するには、Grid.RowSpan 添付プロパティと Grid.ColumnSpan 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f5098-250">Elements can span multiple rows and columns using Grid.RowSpan and Grid.ColumnSpan attached properties.</span></span></li><li><span data-ttu-id="f5098-251">HorizontalAlignment/VerticalAlignment の Stretch の値は考慮されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-251">Stretch values for HorizontalAlignment/VerticalAlignment are respected.</span></span> <span data-ttu-id="f5098-252">要素のサイズを明示的に設定しないと、グリッド セルの利用可能な領域いっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-252">If an element's size is not set explicitly, it stretches to fill the available space in the grid cell.</span></span></li><li><span data-ttu-id="f5098-253">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="f5098-253">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="f5098-254">コンテンツのサイズはパネルの境界によって制約されるため、スクロール可能なコンテンツでは必要に応じてスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-254">Content size is constrained by the bounds of the panel, so scrollable content shows scroll bars if needed.</span></span></li>
[**<span data-ttu-id="f5098-255">RelativePanel</span><span class="sxs-lookup"><span data-stu-id="f5098-255">RelativePanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.aspx) | <li><span data-ttu-id="f5098-256">要素は、パネルの端または中央を基準として、および互いを基準として配置されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-256">Elements are arranged in relation to the edge or center of the panel, and in relation to each other.</span></span></li><li><span data-ttu-id="f5098-257">要素は、パネルの配置、兄弟の配置、兄弟の位置を制御するさまざまな添付プロパティを使用して配置されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-257">Elements are positioned using a variety of attached properties that control panel alignment, sibling alignment, and sibling position.</span></span> </li><li><span data-ttu-id="f5098-258">HorizontalAlignment/VerticalAlignment の Stretch 値は、配置の RelativePanel 添付プロパティが拡大の原因である場合 (要素がパネルの右端と左端の両方に整列される場合など) を除き、無視されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-258">Stretch values for HorizontalAlignment/VerticalAlignment are ignored unless RelativePanel attached properties for alignment cause stretching (for example, an element is aligned to both the right and left edges of the panel).</span></span> <span data-ttu-id="f5098-259">要素のサイズが明示的に設定されておらず、要素が拡大されていない場合、要素はそのコンテンツに合わせてサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-259">If an element's size is not set explicitly and it's not stretched, it sizes to its content.</span></span></li><li><span data-ttu-id="f5098-260">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="f5098-260">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="f5098-261">コンテンツのサイズはパネルの境界によって制約されるため、スクロール可能なコンテンツでは必要に応じてスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-261">Content size is constrained by the bounds of the panel, so scrollable content shows scroll bars if needed.</span></span></li>
[**<span data-ttu-id="f5098-262">StackPanel</span><span class="sxs-lookup"><span data-stu-id="f5098-262">StackPanel</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.stackpanel.aspx) |<li><span data-ttu-id="f5098-263">要素は、水平方向または垂直方向に 1 列に並べて表示されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-263">Elements are stacked in a single line either vertically or horizontally.</span></span></li><li><span data-ttu-id="f5098-264">HorizontalAlignment/VerticalAlignment の Stretch 値は、Orientation プロパティとは逆の方向で考慮されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-264">Stretch values for HorizontalAlignment/VerticalAlignment are respected in the direction opposite the Orientation property.</span></span> <span data-ttu-id="f5098-265">要素のサイズが明示的に設定されていない場合、利用可能な幅 (Orientation が Horizontal の場合は高さ) いっぱいに拡大されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-265">If an element's size is not set explicitly, it stretches to fill the available width (or height if the Orientation is Horizontal).</span></span> <span data-ttu-id="f5098-266">要素は、Orientation プロパティで指定された方向に、そのコンテンツに合わせてサイズ変更されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-266">In the direction specified by the Orientation property, an element sizes to its content.</span></span></li><li><span data-ttu-id="f5098-267">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="f5098-267">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="f5098-268">コンテンツのサイズは、Orientation プロパティで指定された方向では、パネルの境界によって制約されないため、スクロール可能なコンテンツはパネルの境界を越えて拡大され、スクロール バーは表示されません。</span><span class="sxs-lookup"><span data-stu-id="f5098-268">Content size is not constrained by the bounds of the panel in the direction specified by the Orientation property, so scrollable content stretches beyond the panel bounds and doesn't show scrollbars.</span></span> <span data-ttu-id="f5098-269">スクロール バーを表示するには、子のコンテンツの高さ (または幅) を明示的に制約する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-269">You must explicitly constrain the height (or width) of the child content to make its scrollbars show.</span></span></li>
[**<span data-ttu-id="f5098-270">VariableSizedWrapGrid</span><span class="sxs-lookup"><span data-stu-id="f5098-270">VariableSizedWrapGrid</span></span>**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.variablesizedwrapgrid.aspx) |<li><span data-ttu-id="f5098-271">要素は、複数行、複数列に配置され、MaximumRowsOrColumns 値に達すると新しい行または列に自動的に折り返して配置されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-271">Elements are arranged in rows or columns that automatically wrap to a new row or column when the MaximumRowsOrColumns value is reached.</span></span></li><li><span data-ttu-id="f5098-272">要素を行と列のどちらの形式で配置するかは、Orientation プロパティで指定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-272">Whether elements are arranged in rows or columns is specified by the Orientation property.</span></span></li><li><span data-ttu-id="f5098-273">行や列をまたいで要素を表示するには、VariableSizedWrapGrid.RowSpan 添付プロパティと VariableSizedWrapGrid.ColumnSpan 添付プロパティを使います。</span><span class="sxs-lookup"><span data-stu-id="f5098-273">Elements can span multiple rows and columns using VariableSizedWrapGrid.RowSpan and VariableSizedWrapGrid.ColumnSpan attached properties.</span></span></li><li><span data-ttu-id="f5098-274">HorizontalAlignment/VerticalAlignment の Stretch の値は無視されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-274">Stretch values for HorizontalAlignment/VerticalAlignment are ignored.</span></span> <span data-ttu-id="f5098-275">ItemHeight プロパティと ItemWidth プロパティを指定すると、要素のサイズが変更されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-275">Elements are sized as specified by the ItemHeight and ItemWidth properties.</span></span> <span data-ttu-id="f5098-276">これらのプロパティが設定されていない場合、最初のセルの項目はそのコンテンツに合わせてサイズ変更され、その他のすべてのセルはこのサイズを継承します。</span><span class="sxs-lookup"><span data-stu-id="f5098-276">If these properties are not set, the item in the first cell sizes to its content, and all other cells inherit this size.</span></span></li><li><span data-ttu-id="f5098-277">パネルより大きい場合、子のコンテンツは視覚上クリップされます。</span><span class="sxs-lookup"><span data-stu-id="f5098-277">Child content is visually clipped if larger than the panel.</span></span></li><li><span data-ttu-id="f5098-278">コンテンツのサイズはパネルの境界によって制約されるため、スクロール可能なコンテンツでは必要に応じてスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-278">Content size is constrained by the bounds of the panel, so scrollable content shows scroll bars if needed.</span></span></li>

<span data-ttu-id="f5098-279">これらのパネルの例および詳細情報については、「[レイアウト パネル](layout-panels.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-279">For detailed information and examples of these panels, see [Layout panels](layout-panels.md).</span></span> <span data-ttu-id="f5098-280">[レスポンシブな手法のサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620024)に関するページもご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-280">Also, see the [Responsive techniques sample](http://go.microsoft.com/fwlink/p/?LinkId=620024).</span></span>

<span data-ttu-id="f5098-281">レイアウト パネルでは、コントロールの論理グループに UI を整理することができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-281">Layout panels let you organize your UI into logical groups of controls.</span></span> <span data-ttu-id="f5098-282">適切なプロパティの設定で使用する場合、UI 要素の自動サイズ変更、位置変更、再配置などのサポートを取得します。</span><span class="sxs-lookup"><span data-stu-id="f5098-282">When you use them with appropriate property settings, you get some support for automatic resizing, repositioning, and reflowing of UI elements.</span></span> <span data-ttu-id="f5098-283">ただし、ほとんどの UI レイアウトでは、ウィンドウのサイズに大幅な変更がある場合、さらに変更が必要です。</span><span class="sxs-lookup"><span data-stu-id="f5098-283">However, most UI layouts need further modification when there are significant changes to the window size.</span></span> <span data-ttu-id="f5098-284">これには、表示状態を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-284">For this, you can use visual states.</span></span>

## <a name="visual-states-and-state-triggers"></a><span data-ttu-id="f5098-285">表示状態と状態トリガー</span><span class="sxs-lookup"><span data-stu-id="f5098-285">Visual states and state triggers</span></span>

<span data-ttu-id="f5098-286">画面サイズまたはその他の要因に基づいて、UI のセクションの位置の変更、サイズ変更、再配置、表示、または置換を行うには、表示状態を使用します。</span><span class="sxs-lookup"><span data-stu-id="f5098-286">Use visual states to reposition, resize, reflow, reveal, or replace sections of your UI based on screen size or other factors.</span></span> <span data-ttu-id="f5098-287">[**VisualState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstate.aspx) は、要素が特定の状態にあるときに、要素に適用されるプロパティ値を定義します。</span><span class="sxs-lookup"><span data-stu-id="f5098-287">A [**VisualState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstate.aspx) defines property values that are applied to an element when it’s in a particular state.</span></span> <span data-ttu-id="f5098-288">指定された条件が満たされたときに適切な VisualState を適用する [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) で表示状態をグループ化します。</span><span class="sxs-lookup"><span data-stu-id="f5098-288">You group visual states in a [**VisualStateManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.aspx) that applies the appropriate VisualState when the specified conditions are met.</span></span>

### <a name="set-visual-states-in-code"></a><span data-ttu-id="f5098-289">コードでの表示状態の設定</span><span class="sxs-lookup"><span data-stu-id="f5098-289">Set visual states in code</span></span>

<span data-ttu-id="f5098-290">コードで表示状態を適用するには、[**VisualStateManager.GoToState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.gotostate.aspx) メソッドを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f5098-290">To apply a visual state from code, you call the [**VisualStateManager.GoToState**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstatemanager.gotostate.aspx) method.</span></span> <span data-ttu-id="f5098-291">たとえば、アプリ ウィンドウが特定のサイズであるときに状態を適用するには、[**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.window.sizechanged.aspx) イベントを処理し、**GoToState** を呼び出して適切な状態を適用します。</span><span class="sxs-lookup"><span data-stu-id="f5098-291">For example, to apply a state when the app window is a particular size, handle the [**SizeChanged**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.window.sizechanged.aspx) event and call **GoToState** to apply the appropriate state.</span></span>

<span data-ttu-id="f5098-292">ここでは、[**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstategroup.aspx) に 2 つの VisualState の定義が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f5098-292">Here, a [**VisualStateGroup**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.visualstategroup.aspx) contains 2 VisualState definitions.</span></span> <span data-ttu-id="f5098-293">最初の `DefaultState` は空です。</span><span class="sxs-lookup"><span data-stu-id="f5098-293">The first, `DefaultState`, is empty.</span></span> <span data-ttu-id="f5098-294">これが適用される場合、XAML ページで定義されている値が適用されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-294">When it's applied, the values defined in the XAML page are applied.</span></span> <span data-ttu-id="f5098-295">2 番目の `WideState` は、[**SplitView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) の [**DisplayMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.displaymode.aspx) プロパティを **Inline** に変更し、ウィンドウを開きます。</span><span class="sxs-lookup"><span data-stu-id="f5098-295">The second, `WideState`, changes the [**DisplayMode**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.displaymode.aspx) property of the [**SplitView**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.splitview.aspx) to **Inline** and opens the pane.</span></span> <span data-ttu-id="f5098-296">この状態は、ウィンドウの幅が 720 有効ピクセル以上である場合に、SizeChanged イベント ハンドラーで適用されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-296">This state is applied in the SizeChanged event handler if the window width is 720 effective pixels or greater.</span></span>

```xaml
<Page ...>
    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState x:Name="DefaultState">
                        <Storyboard>
                        </Storyboard>
                    </VisualState>

                <VisualState x:Name="WideState">
                    <Storyboard>
                        <ObjectAnimationUsingKeyFrames
                            Storyboard.TargetProperty="SplitView.DisplayMode"
                            Storyboard.TargetName="mySplitView">
                            <DiscreteObjectKeyFrame KeyTime="0">
                                <DiscreteObjectKeyFrame.Value>
                                    <SplitViewDisplayMode>Inline</SplitViewDisplayMode>
                                </DiscreteObjectKeyFrame.Value>
                            </DiscreteObjectKeyFrame>
                        </ObjectAnimationUsingKeyFrames>
                        <ObjectAnimationUsingKeyFrames
                            Storyboard.TargetProperty="SplitView.IsPaneOpen"
                            Storyboard.TargetName="mySplitView">
                            <DiscreteObjectKeyFrame KeyTime="0" Value="True"/>
                        </ObjectAnimationUsingKeyFrames>
                    </Storyboard>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <SplitView x:Name="mySplitView" DisplayMode="CompactInline"
                   IsPaneOpen="False" CompactPaneLength="20">
            <!-- SplitView content -->

            <SplitView.Pane>
                <!-- Pane content -->
            </SplitView.Pane>
        </SplitView>
    </Grid>
</Page>
```

```csharp
private void CurrentWindow_SizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
{
    if (e.Size.Width >= 720)
        VisualStateManager.GoToState(this, "WideState", false);
    else
        VisualStateManager.GoToState(this, "DefaultState", false);
}
```

### <a name="set-visual-states-in-xaml-markup"></a><span data-ttu-id="f5098-297">XAML マークアップでの表示状態の設定</span><span class="sxs-lookup"><span data-stu-id="f5098-297">Set visual states in XAML markup</span></span>

<span data-ttu-id="f5098-298">Windows 10 より前のバージョンでは、VisualState の定義にプロパティ変更のための [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.storyboard.aspx) オブジェクトが必要であり、コードで **GoToState** を呼び出して状態を適用する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="f5098-298">Prior to Windows 10, VisualState definitions required [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.storyboard.aspx) objects for property changes, and you had to call **GoToState** in code to apply the state.</span></span> <span data-ttu-id="f5098-299">これは前の例に示されています。</span><span class="sxs-lookup"><span data-stu-id="f5098-299">This is shown in the previous example.</span></span> <span data-ttu-id="f5098-300">この構文はまだ多くの例で使用されており、この構文を使用する既存のコードがある可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="f5098-300">You will still see many examples that use this syntax, or you might have existing code that uses it.</span></span>

<span data-ttu-id="f5098-301">Windows 10 以降では、ここで示す簡素化された [**Setter**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.setter.aspx) 構文を使うことができ、XAML マークアップで [**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) を使って状態を適用できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-301">Starting in Windows 10, you can use the simplified [**Setter**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.setter.aspx) syntax shown here, and you can use a [**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) in your XAML markup to apply the state.</span></span> <span data-ttu-id="f5098-302">状態トリガーを使って、アプリのイベントに応答して自動的に表示状態の変更をトリガーする単純な規則を作成します。</span><span class="sxs-lookup"><span data-stu-id="f5098-302">You use state triggers to create simple rules that automatically trigger visual state changes in response to an app event.</span></span>

<span data-ttu-id="f5098-303">この例は前の例と同じですが、プロパティの変更を定義する Storyboard の代わりに、簡素化された **Setter** 構文を使用しています。</span><span class="sxs-lookup"><span data-stu-id="f5098-303">This example does the same thing as the previous example, but uses the simplified **Setter** syntax instead of a Storyboard to define property changes.</span></span> <span data-ttu-id="f5098-304">また、GoToState を呼び出す代わりに、組み込みの [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) 状態トリガーを使って状態を適用しています。</span><span class="sxs-lookup"><span data-stu-id="f5098-304">And instead of calling GoToState, it uses the built in [**AdaptiveTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.adaptivetrigger.aspx) state trigger to apply the state.</span></span> <span data-ttu-id="f5098-305">状態トリガーを使う場合、空の `DefaultState` を定義する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f5098-305">When you use state triggers, you don't need to define an empty `DefaultState`.</span></span> <span data-ttu-id="f5098-306">状態トリガーの条件が満たされなくなったときには、既定の設定が自動的に再適用されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-306">The default settings are reapplied automatically when the conditions of the state trigger are no longer met.</span></span>

```xaml
<Page ...>
    <Grid>
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <!-- VisualState to be triggered when the
                             window width is >=720 effective pixels. -->
                        <AdaptiveTrigger MinWindowWidth="720" />
                    </VisualState.StateTriggers>

                    <VisualState.Setters>
                        <Setter Target="mySplitView.DisplayMode" Value="Inline"/>
                        <Setter Target="mySplitView.IsPaneOpen" Value="True"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <SplitView x:Name="mySplitView" DisplayMode="CompactInline"
                   IsPaneOpen="False" CompactPaneLength="20">
            <!-- SplitView content -->

            <SplitView.Pane>
                <!-- Pane content -->
            </SplitView.Pane>
        </SplitView>
    </Grid>
</Page>
```

> <span data-ttu-id="f5098-307">**重要**&nbsp;&nbsp;前の例では、**Grid** 要素に対して VisualStateManager.VisualStateGroups 添付プロパティが設定されています。</span><span class="sxs-lookup"><span data-stu-id="f5098-307">**Important**&nbsp;&nbsp;In the previous example, the VisualStateManager.VisualStateGroups attached property is set on the **Grid** element.</span></span> <span data-ttu-id="f5098-308">StateTriggers を使う場合は、トリガーを自動的に有効にするために、常にルートの最初の子に VisualStateGroups が添付されていることを確認します </span><span class="sxs-lookup"><span data-stu-id="f5098-308">When you use StateTriggers, always ensure that VisualStateGroups is attached to the first child of the root in order for the triggers to take effect automatically.</span></span> <span data-ttu-id="f5098-309">(ここでは、**Grid** がルートの **Page** 要素の最初の子です)。</span><span class="sxs-lookup"><span data-stu-id="f5098-309">(Here, **Grid** is the first child of the root **Page** element.)</span></span>

### <a name="attached-property-syntax"></a><span data-ttu-id="f5098-310">添付プロパティの構文</span><span class="sxs-lookup"><span data-stu-id="f5098-310">Attached property syntax</span></span>

<span data-ttu-id="f5098-311">VisualState では、通常、コントロールのプロパティの値、つまりコントロールを含むパネルのいずれかの添付プロパティの値を設定します。</span><span class="sxs-lookup"><span data-stu-id="f5098-311">In a VisualState, you typically set a value for a control property, or for one of the attached properties of the panel that contains the control.</span></span> <span data-ttu-id="f5098-312">添付プロパティを設定するときは、添付プロパティ名をかっこで囲みます。</span><span class="sxs-lookup"><span data-stu-id="f5098-312">When you set an attached property, use parentheses around the attached property name.</span></span>

<span data-ttu-id="f5098-313">この例では、`myTextBox` という名前の TextBox に対して、[**RelativePanel.AlignHorizontalCenterWithPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwithpanel.aspx) 添付プロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f5098-313">This example shows how to set the [**RelativePanel.AlignHorizontalCenterWithPanel**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.relativepanel.alignhorizontalcenterwithpanel.aspx) attached property on a TextBox named `myTextBox`.</span></span> <span data-ttu-id="f5098-314">最初の XAML では [**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.objectanimationusingkeyframes.aspx) 構文を使用し、2 つ目の XAML では **Setter** 構文を使用しています。</span><span class="sxs-lookup"><span data-stu-id="f5098-314">The first XAML uses [**ObjectAnimationUsingKeyFrames**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.animation.objectanimationusingkeyframes.aspx) syntax and the second uses **Setter** syntax.</span></span>

```xaml
<!-- Set an attached property using ObjectAnimationUsingKeyFrames. -->
<ObjectAnimationUsingKeyFrames
    Storyboard.TargetProperty="(RelativePanel.AlignHorizontalCenterWithPanel)"
    Storyboard.TargetName="myTextBox">
    <DiscreteObjectKeyFrame KeyTime="0" Value="True"/>
</ObjectAnimationUsingKeyFrames>

<!-- Set an attached property using Setter. -->
<Setter Target="myTextBox.(RelativePanel.AlignHorizontalCenterWithPanel)" Value="True"/>
```

### <a name="custom-state-triggers"></a><span data-ttu-id="f5098-315">カスタム状態トリガー</span><span class="sxs-lookup"><span data-stu-id="f5098-315">Custom state triggers</span></span>

<span data-ttu-id="f5098-316">[**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) クラスを拡張して、さまざまなシナリオに対するカスタム トリガーを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-316">You can extend the [**StateTrigger**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.statetrigger.aspx) class to create custom triggers for a wide range of scenarios.</span></span> <span data-ttu-id="f5098-317">たとえば、入力の種類に基づいてさまざまな状態をトリガーする StateTrigger を作成して、入力の種類がタッチである場合はコントロールの周囲の余白を増やすことができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-317">For example, you can create a StateTrigger to trigger different states based on input type, then increase the margins around a control when the input type is touch.</span></span> <span data-ttu-id="f5098-318">また、アプリが実行されるデバイス ファミリに基づいてさまざまな状態を適用する StateTrigger を作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5098-318">Or create a StateTrigger to apply different states based on the device family the app is run on.</span></span> <span data-ttu-id="f5098-319">カスタム トリガーを作成し、それらを使用して単一の XAML ビュー内から最適化された UI エクスペリエンスを作成する方法の例については、[状態トリガーのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620025)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-319">For examples of how to build custom triggers and use them to create optimized UI experiences from within a single XAML view, see the [State triggers sample](http://go.microsoft.com/fwlink/p/?LinkId=620025).</span></span>

### <a name="visual-states-and-styles"></a><span data-ttu-id="f5098-320">表示状態とスタイル</span><span class="sxs-lookup"><span data-stu-id="f5098-320">Visual states and styles</span></span>

<span data-ttu-id="f5098-321">表示状態で Style リソースを使って、一連のプロパティの変更を複数のコントロールに適用できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-321">You can use Style resources in visual states to apply a set of property changes to multiple controls.</span></span> <span data-ttu-id="f5098-322">スタイルの使用について詳しくは、「[コントロールのスタイル](../controls-and-patterns/styling-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-322">For more info about using styles, see [Styling controls](../controls-and-patterns/styling-controls.md).</span></span>

<span data-ttu-id="f5098-323">状態トリガーのサンプルに関するページから引用したこの簡略化された XAML では、Style リソースを Button に適用して、マウスまたはタッチ入力の場合にサイズと余白を調整しています。</span><span class="sxs-lookup"><span data-stu-id="f5098-323">In this simplified XAML from the State triggers sample, a Style resource is applied to a Button to adjust the size and margins for mouse or touch input.</span></span> <span data-ttu-id="f5098-324">このカスタム状態トリガーの完全なコードおよび定義については、[状態トリガーのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620025)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-324">For the complete code and the definition of the custom state trigger, see the [State triggers sample](http://go.microsoft.com/fwlink/p/?LinkId=620025).</span></span>

```xaml
<Page ... >
    <Page.Resources>
        <!-- Styles to be used for mouse vs. touch/pen hit targets -->
        <Style x:Key="MouseStyle" TargetType="Rectangle">
            <Setter Property="Margin" Value="5" />
            <Setter Property="Height" Value="20" />
            <Setter Property="Width" Value="20" />
        </Style>
        <Style x:Key="TouchPenStyle" TargetType="Rectangle">
            <Setter Property="Margin" Value="15" />
            <Setter Property="Height" Value="40" />
            <Setter Property="Width" Value="40" />
        </Style>
    </Page.Resources>

    <RelativePanel>
        <!-- ... -->
        <Button Content="Color Palette Button" x:Name="MenuButton">
            <Button.Flyout>
                <Flyout Placement="Bottom">
                    <RelativePanel>
                        <Rectangle Name="BlueRect" Fill="Blue"/>
                        <Rectangle Name="GreenRect" Fill="Green" RelativePanel.RightOf="BlueRect" />
                        <!-- ... -->
                    </RelativePanel>
                </Flyout>
            </Button.Flyout>
        </Button>
        <!-- ... -->
    </RelativePanel>
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup x:Name="InputTypeStates">
            <!-- Second set of VisualStates for building responsive UI optimized for input type.
                 Take a look at InputTypeTrigger.cs class in CustomTriggers folder to see how this is implemented. -->
            <VisualState>
                <VisualState.StateTriggers>
                    <!-- This trigger indicates that this VisualState is to be applied when MenuButton is invoked using a mouse. -->
                    <triggers:InputTypeTrigger TargetElement="{x:Bind MenuButton}" PointerType="Mouse" />
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="BlueRect.Style" Value="{StaticResource MouseStyle}" />
                    <Setter Target="GreenRect.Style" Value="{StaticResource MouseStyle}" />
                    <!-- ... -->
                </VisualState.Setters>
            </VisualState>
            <VisualState>
                <VisualState.StateTriggers>
                    <!-- Multiple trigger statements can be declared in the following way to imply OR usage.
                         For example, the following statements indicate that this VisualState is to be applied when MenuButton is invoked using Touch OR Pen.-->
                    <triggers:InputTypeTrigger TargetElement="{x:Bind MenuButton}" PointerType="Touch" />
                    <triggers:InputTypeTrigger TargetElement="{x:Bind MenuButton}" PointerType="Pen" />
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <Setter Target="BlueRect.Style" Value="{StaticResource TouchPenStyle}" />
                    <Setter Target="GreenRect.Style" Value="{StaticResource TouchPenStyle}" />
                    <!-- ... -->
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Page>
```

## <a name="tailored-layouts"></a><span data-ttu-id="f5098-325">カスタマイズされたレイアウト</span><span class="sxs-lookup"><span data-stu-id="f5098-325">Tailored layouts</span></span>

<span data-ttu-id="f5098-326">さまざまなデバイスで UI のレイアウトに大幅な変更を加えるときは、1 つの UI を適合させるのではなく、デバイスに合わせてカスタマイズされたレイアウトを含む個別の UI ファイルを定義すると便利な場合があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-326">When you make significant changes to your UI layout on different devices, you might find it more convenient to define a separate UI file with a layout tailored to the device, rather than adapting a single UI.</span></span> <span data-ttu-id="f5098-327">複数のデバイス間で機能が同じである場合は、同じコード ファイルを共有する個別の XAML ビューを定義できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-327">If the functionality is the same across devices, you can define separate XAML views that share the same code file.</span></span> <span data-ttu-id="f5098-328">ビューと機能の両方がデバイス間で大幅に異なる場合は、個別の Page を定義し、アプリの読み込み時に移動する Page を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-328">If both the view and the functionality differ significantly across devices, you can define separate Pages, and choose which Page to navigate to when the app is loaded.</span></span>

### <a name="separate-xaml-views-per-device-family"></a><span data-ttu-id="f5098-329">デバイス ファミリごとの個別の XAML ビュー</span><span class="sxs-lookup"><span data-stu-id="f5098-329">Separate XAML views per device family</span></span>

<span data-ttu-id="f5098-330">同じ分離コードを共有する複数の UI 定義を作成するには、XAML ビューを使用します。</span><span class="sxs-lookup"><span data-stu-id="f5098-330">Use XAML views to create different UI definitions that share the same code-behind.</span></span> <span data-ttu-id="f5098-331">デバイス ファミリごとに固有の UI 定義を提供できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-331">You can provide a unique UI definition for each device family.</span></span> <span data-ttu-id="f5098-332">次の手順に従って、アプリに XAML ビューを追加します。</span><span class="sxs-lookup"><span data-stu-id="f5098-332">Follow these steps to add a XAML view to your app.</span></span>

**<span data-ttu-id="f5098-333">アプリに XAML ビューを追加するには</span><span class="sxs-lookup"><span data-stu-id="f5098-333">To add a XAML view to an app</span></span>**
1. <span data-ttu-id="f5098-334">[プロジェクト] の [新しい項目の追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f5098-334">Select Project > Add New Item.</span></span> <span data-ttu-id="f5098-335">[新しい項目の追加] ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="f5098-335">The Add New Item dialog box opens.</span></span>
    > <span data-ttu-id="f5098-336">**ヒント**&nbsp;&nbsp;ソリューション エクスプローラーで、ソリューションではなく、フォルダーまたはプロジェクトが選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f5098-336">**Tip**&nbsp;&nbsp;Make sure a folder or the project, and not the solution, is selected in Solution Explorer.</span></span>
2. <span data-ttu-id="f5098-337">左側のウィンドウの [Visual C#] または [Visual Basic] の下で、テンプレートの種類として [XAML] を選びます。</span><span class="sxs-lookup"><span data-stu-id="f5098-337">Under Visual C# or Visual Basic in the left pane, pick the XAML template type.</span></span>
3. <span data-ttu-id="f5098-338">中央のウィンドウで、[XAML ビュー] を選びます。</span><span class="sxs-lookup"><span data-stu-id="f5098-338">In the center pane, pick XAML View.</span></span>
4. <span data-ttu-id="f5098-339">ビューの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="f5098-339">Enter the name for the view.</span></span> <span data-ttu-id="f5098-340">ビューには、正しく名前を付ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5098-340">The view must be named correctly.</span></span> <span data-ttu-id="f5098-341">命名方法について詳しくは、このセクションの後半をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f5098-341">For more info on naming, see the remainder of this section.</span></span>
5. <span data-ttu-id="f5098-342">[追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f5098-342">Click Add.</span></span> <span data-ttu-id="f5098-343">ファイルがプロジェクトに追加されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-343">The file is added to the project.</span></span>

<span data-ttu-id="f5098-344">前の手順では、XAML ファイルのみを作成し、関連付けられた分離コード ファイルは作成していません。</span><span class="sxs-lookup"><span data-stu-id="f5098-344">The previous steps create only a XAML file, but not an associated code-behind file.</span></span> <span data-ttu-id="f5098-345">代わりに、ファイル名やフォルダー名の一部である "DeviceName" 修飾子を使って、XAML ビューが既存の分離コード ファイルに関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="f5098-345">Instead, the XAML view is associated with an existing code-behind file using a "DeviceName" qualifier that's part of the file or folder name.</span></span> <span data-ttu-id="f5098-346">この修飾子名は、アプリが現在実行されているデバイスのデバイス ファミリを表す文字列値 ("Desktop"、"Mobile"、およびその他のデバイス ファミリの名前) にマップすることができます (「[**ResourceContext.QualifierValues**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.resources.core.resourcecontext.qualifiervalues.aspx)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="f5098-346">This qualifier name can be mapped to a string value that represents the device family of the device that your app is currently running on, such as, "Desktop", "Mobile", and the names of the other device families (see [**ResourceContext.QualifierValues**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.resources.core.resourcecontext.qualifiervalues.aspx)).</span></span>

<span data-ttu-id="f5098-347">ファイル名に修飾子を追加することや、修飾子名を持つフォルダーにファイルを追加することができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-347">You can add the qualifier to the file name, or add the file to a folder that has the qualifier name.</span></span>

**<span data-ttu-id="f5098-348">ファイル名の使用</span><span class="sxs-lookup"><span data-stu-id="f5098-348">Use file name</span></span>**

<span data-ttu-id="f5098-349">ファイルに修飾子名を使用するには、*[pageName]*.DeviceFamily-*[qualifierString]*.xaml という形式を使用します。</span><span class="sxs-lookup"><span data-stu-id="f5098-349">To use the qualifier name with the file, use this format: *[pageName]*.DeviceFamily-*[qualifierString]*.xaml.</span></span>

<span data-ttu-id="f5098-350">MainPage.xaml という名前のファイルの例を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="f5098-350">Let's look at an example for a file named MainPage.xaml.</span></span> <span data-ttu-id="f5098-351">モバイル デバイス用のビューを作成するには、XAML ビューに MainPage.DeviceFamily-Mobile.xaml という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="f5098-351">To create a view for mobile devices, name the XAML view MainPage.DeviceFamily-Mobile.xaml.</span></span> <span data-ttu-id="f5098-352">PC デバイス用のビューを作成するには、ビューに MainPage.DeviceFamily-Desktop.xaml という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="f5098-352">To create a view for PC devices, name the view MainPage.DeviceFamily-Desktop.xaml.</span></span> <span data-ttu-id="f5098-353">Microsoft Visual Studio で、ソリューションがどのように表示されるかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-353">Here's what the solution looks like in Microsoft Visual Studio.</span></span>

![修飾ファイル名を持つ XAML ビュー](images/xaml-layout-view-ex-1.png)

**<span data-ttu-id="f5098-355">フォルダー名の使用</span><span class="sxs-lookup"><span data-stu-id="f5098-355">Use folder name</span></span>**

<span data-ttu-id="f5098-356">フォルダーを使用して Visual Studio プロジェクト内のビューを整理するには、フォルダーで修飾子名を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-356">To organize the views in your Visual Studio project using folders, you can use the qualifier name with the folder.</span></span> <span data-ttu-id="f5098-357">そのためには、フォルダーに DeviceFamily-*[qualifierString]* のように名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="f5098-357">To do so, name your folder like this: DeviceFamily-*[qualifierString]*.</span></span> <span data-ttu-id="f5098-358">この場合は、各 XAML ファイルの名前は同じになります。</span><span class="sxs-lookup"><span data-stu-id="f5098-358">In this case, each XAML view file has the same name.</span></span> <span data-ttu-id="f5098-359">ファイル名に修飾子を含めないでください。</span><span class="sxs-lookup"><span data-stu-id="f5098-359">Don't include the qualifier in the file name.</span></span>

<span data-ttu-id="f5098-360">MainPage.xaml という名前のファイルの例を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-360">Here's an example, again for a file named MainPage.xaml.</span></span> <span data-ttu-id="f5098-361">モバイル デバイス用のビューを作成するには、"DeviceFamily-Mobile" という名前のフォルダーを作成し、このフォルダーに MainPage.xaml という名前の XAML ビューを配置します。</span><span class="sxs-lookup"><span data-stu-id="f5098-361">To create a view for mobile devices, create a folder named "DeviceFamily-Mobile", and place a XAML view named MainPage.xaml into it.</span></span> <span data-ttu-id="f5098-362">PC デバイス用のビューを作成するには、"DeviceFamily-Desktop" という名前のフォルダーを作成し、このフォルダーに MainPage.xaml という名前の別の XAML ビューを配置します。</span><span class="sxs-lookup"><span data-stu-id="f5098-362">To create a view for PC devices, create a folder named "DeviceFamily-Desktop", and place another XAML view named MainPage.xaml into it.</span></span> <span data-ttu-id="f5098-363">Visual Studio で、ソリューションがどのように表示されるかを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f5098-363">Here's what the solution looks like in Visual Studio.</span></span>

![フォルダー内の XAML ビュー](images/xaml-layout-view-ex-2.png)

<span data-ttu-id="f5098-365">どちらの場合も、モバイル デバイスと PC デバイス用に固有のビューが使用されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-365">In both cases, a unique view is used for mobile and PC devices.</span></span> <span data-ttu-id="f5098-366">既定の MainPage.xaml ファイルは、実行されているデバイスがデバイス ファミリ固有のビューのいずれにも一致しない場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-366">The default MainPage.xaml file is used if the device it's running on doesn't match any of the device family specific views.</span></span>

### <a name="separate-xaml-pages-per-device-family"></a><span data-ttu-id="f5098-367">デバイス ファミリごとの個別の XAML ページ</span><span class="sxs-lookup"><span data-stu-id="f5098-367">Separate XAML pages per device family</span></span>

<span data-ttu-id="f5098-368">固有のビューと機能を提供するために、個別の Page ファイル (XAML とコード) を作成し、ページが必要になったときに適切なページに移動することができます。</span><span class="sxs-lookup"><span data-stu-id="f5098-368">To provide unique views and functionality, you can create separate Page files (XAML and code), and then navigate to the appropriate page when the page is needed.</span></span>

**<span data-ttu-id="f5098-369">アプリに XAML ページを追加するには</span><span class="sxs-lookup"><span data-stu-id="f5098-369">To add a XAML page to an app</span></span>**
1. <span data-ttu-id="f5098-370">[プロジェクト] の [新しい項目の追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f5098-370">Select Project > Add New Item.</span></span> <span data-ttu-id="f5098-371">[新しい項目の追加] ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="f5098-371">The Add New Item dialog box opens.</span></span>
    > <span data-ttu-id="f5098-372">**ヒント**&nbsp;&nbsp;ソリューション エクスプローラーで、ソリューションではなく、プロジェクトが選択されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="f5098-372">**Tip**&nbsp;&nbsp;Make sure the project, and not the solution, is selected in Solution Explorer.</span></span>
2. <span data-ttu-id="f5098-373">左側のウィンドウの [Visual C#] または [Visual Basic] の下で、テンプレートの種類として [XAML] を選びます。</span><span class="sxs-lookup"><span data-stu-id="f5098-373">Under Visual C# or Visual Basic in the left pane, pick the XAML template type.</span></span>
3. <span data-ttu-id="f5098-374">中央のウィンドウで、[空白のページ] を選びます。</span><span class="sxs-lookup"><span data-stu-id="f5098-374">In the center pane, pick Blank page.</span></span>
4. <span data-ttu-id="f5098-375">ページの名前を入力します。</span><span class="sxs-lookup"><span data-stu-id="f5098-375">Enter the name for the page.</span></span> <span data-ttu-id="f5098-376">たとえば、"MainPage_Mobile" と入力します。</span><span class="sxs-lookup"><span data-stu-id="f5098-376">For example, "MainPage_Mobile".</span></span> <span data-ttu-id="f5098-377">MainPage_Mobile.xaml と MainPage_Mobile.xaml.cs/vb/cpp コード ファイルの両方が作成されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-377">Both a MainPage_Mobile.xaml and MainPage_Mobile.xaml.cs/vb/cpp code file are created.</span></span>
5. <span data-ttu-id="f5098-378">[追加] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="f5098-378">Click Add.</span></span> <span data-ttu-id="f5098-379">ファイルがプロジェクトに追加されます。</span><span class="sxs-lookup"><span data-stu-id="f5098-379">The file is added to the project.</span></span>

<span data-ttu-id="f5098-380">実行時に、アプリが実行されているデバイス ファミリを確認し、次のように適切なページに移動します。</span><span class="sxs-lookup"><span data-stu-id="f5098-380">At runtime, check the device family that the app is running on, and navigate to the correct page like this.</span></span>

```csharp
if (Windows.System.Profile.AnalyticsInfo.VersionInfo.DeviceFamily == "Windows.Mobile")
{
    rootFrame.Navigate(typeof(MainPage_Mobile), e.Arguments);
}
else
{
    rootFrame.Navigate(typeof(MainPage), e.Arguments);
}
```

<span data-ttu-id="f5098-381">さまざまな条件に従って移動先のページを決定することもできます。</span><span class="sxs-lookup"><span data-stu-id="f5098-381">You can also use different criteria to determine which page to navigate to.</span></span> <span data-ttu-id="f5098-382">他の例については、[カスタマイズされた複数のビューのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620636)に関するページをご覧ください。このサンプルでは、[**GetIntegratedDisplaySize**](https://msdn.microsoft.com/library/windows/apps/xaml/dn904185.aspx) 関数を使って、統合ディスプレイの物理サイズを確認しています。</span><span class="sxs-lookup"><span data-stu-id="f5098-382">For more examples, see the [Tailored multiple views sample](http://go.microsoft.com/fwlink/p/?LinkId=620636), which uses the [**GetIntegratedDisplaySize**](https://msdn.microsoft.com/library/windows/apps/xaml/dn904185.aspx) function to check the physical size of an integrated display.</span></span>

## <a name="sample-code"></a><span data-ttu-id="f5098-383">サンプル コード</span><span class="sxs-lookup"><span data-stu-id="f5098-383">Sample code</span></span>
*   [<span data-ttu-id="f5098-384">XAML UI の基本のサンプル</span><span class="sxs-lookup"><span data-stu-id="f5098-384">XAML UI basics sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/blob/master/Samples/XamlUIBasics)<br/>
    <span data-ttu-id="f5098-385">インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="f5098-385">See all of the XAML controls in an interactive format.</span></span>