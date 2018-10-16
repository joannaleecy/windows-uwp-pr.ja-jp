---
author: jwmsft
description: Sets UI で最適なエクスペリエンスを提供するためにアプリを最適化する方法について説明します。
title: Sets の設計
template: detail.hbs
ms.author: jimwalk
ms.date: 05/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, タイトル バー
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 7c3e0e6ec7331e860c9153e2a2e29a51fb5848bd
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4618478"
---
# <a name="designing-for-sets"></a><span data-ttu-id="23c3a-104">Sets の設計</span><span class="sxs-lookup"><span data-stu-id="23c3a-104">Designing for Sets</span></span>

> [!IMPORTANT]
> <span data-ttu-id="23c3a-105">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-105">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="23c3a-106">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="23c3a-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="23c3a-107">Windows Insider Preview 以降では、Sets 機能をアプリのユーザーが利用できます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-107">Starting with the Windows Insider Preview, the Sets feature is available to your app's users.</span></span> <span data-ttu-id="23c3a-108">Sets を使用すると、他のアプリと共有される可能性があるウィンドウにアプリが表示され、各アプリでタイトル バーに専用のタブが表示されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-108">With Sets, your app is drawn in a window that might be shared with other apps, and each app gets its own tab in the title bar.</span></span>

<span data-ttu-id="23c3a-109">この記事では、Sets UI で最適なエクスペリエンスを提供するためにアプリを最適化する必要がある領域について説明します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-109">In this article, we go over the areas where you might want to optimize your app to provide the best experience in the Sets UI.</span></span>

> [!TIP]
> <span data-ttu-id="23c3a-110">Sets の詳細については、[Sets の概要](https://insider.windows.com/en-us/articles/introducing-sets/)に関するブログ記事と[Sets の開発](https://developer.microsoft.com/events/build/content/developing-for-sets-on-windows-10)に関する Microsoft Build 2018 での講演を参照してください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-110">For more info about Sets, see the [Introducing Sets](https://insider.windows.com/en-us/articles/introducing-sets/) blog post and the [Developing for Sets](https://developer.microsoft.com/events/build/content/developing-for-sets-on-windows-10) talk from Microsoft Build 2018.</span></span>

## <a name="customizing-tab-visuals"></a><span data-ttu-id="23c3a-111">タブの視覚効果のカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="23c3a-111">Customizing tab visuals</span></span>

<span data-ttu-id="23c3a-112">既定では、システムはアプリのタブがアクティブであるときにタブのテキストとアイコンの適切な色を選択するよう試みます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-112">By default, the system attempts to select appropriate text and icon colors for your app's tab when it is active.</span></span> <span data-ttu-id="23c3a-113">これにより、アプリのタブは開発者側で最小限の労力で、または Sets の最適化を行わない場合でも適切に表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-113">This ensures that your app's tab will look good with minimal effort on your part, or even if you don't do any optimization for Sets.</span></span>

<span data-ttu-id="23c3a-114">ただし、アプリのタブの色をカスタマイズすることが最適である場合もあります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-114">However, there may be cases where it's best to customize the tab color for your app.</span></span> <span data-ttu-id="23c3a-115">このセクションでは、既定のタブの動作について説明し、アプリのタブを変更する必要がある場合と必要がない場合について説明します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-115">In this section, we explain the default tab behaviors, and discuss when you should or shouldn't modify them for your app.</span></span>

### <a name="tab-states"></a><span data-ttu-id="23c3a-116">タブの状態</span><span class="sxs-lookup"><span data-stu-id="23c3a-116">Tab states</span></span>

<span data-ttu-id="23c3a-117">アプリが Set 内にある場合は、アプリのタブは、選択済みでアクティブ、選択済みで非アクティブ、または未選択で非アクティブの 3 つの状態のいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-117">When your app is in a Set, its tab can be in one of three states: selected and active, selected and inactive, or unselected and inactive.</span></span>

- <span data-ttu-id="23c3a-118">**Selected-Active (選択済みでアクティブ)**: グループ化されたウィンドウのセット内から選択され、アクティブなフォアグラウンド ウィンドウ内にあるタブ。</span><span class="sxs-lookup"><span data-stu-id="23c3a-118">**Selected-Active**: A tab that is selected from within a set of grouped windows, and is in the active foreground window.</span></span>

    <span data-ttu-id="23c3a-119">(このドキュメントでは、_アクティブな_タブとはタブが選択済みでアクティブという意味です。)</span><span class="sxs-lookup"><span data-stu-id="23c3a-119">(In this document, any discussion of modifying the _active_ tab means the tab is Selected-Active.)</span></span>
- <span data-ttu-id="23c3a-120">**Selected-Inactive (選択済みで非アクティブ)**: グループ化されたウィンドウのセット内から選択され、アクティブなフォアグラウンド ウィンドウ内にないタブ。</span><span class="sxs-lookup"><span data-stu-id="23c3a-120">**Selected-Inactive**: A tab that is selected from within a set of grouped windows, but is not in the active foreground window.</span></span>
- <span data-ttu-id="23c3a-121">**Unselected-Inactive (未選択で非アクティブ)**: グループ化されたウィンドウのセット内から選択されていないタブ。</span><span class="sxs-lookup"><span data-stu-id="23c3a-121">**Unselected-Inactive**: A tab that is not selected from within a set of grouped windows.</span></span>

<span data-ttu-id="23c3a-122">非アクティブなタブの色がシステムのテーマに基づいて、システムによって更新および維持されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-122">The color of any inactive tabs is updated and maintained by the system based on system theme.</span></span> <span data-ttu-id="23c3a-123">アプリから影響を与えることはできません。</span><span class="sxs-lookup"><span data-stu-id="23c3a-123">There is no way to influence it from your app.</span></span>

<span data-ttu-id="23c3a-124">既定では、選択されたアクティブなタブでは Windows の設定でユーザーが指定したシステム テーマ カラーが適用されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-124">By default, the selected and active tab respects the system theme color specified by the user in Windows Settings.</span></span> <span data-ttu-id="23c3a-125">タブがアクティブな場合にのみ、アプリのタブの色をカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-125">You can customize tab color for your app only when the tab is active.</span></span>

![Sets のタブの状態](images/sets-tab-states.jpg)

### <a name="coloring-of-active-tabs"></a><span data-ttu-id="23c3a-127">アクティブなタブの色</span><span class="sxs-lookup"><span data-stu-id="23c3a-127">Coloring of active tabs</span></span>

<span data-ttu-id="23c3a-128">アクティブなタブの色は、アプリで設定した値によって、またはシステム設定によって決まります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-128">The color of the active tab is determined by values you set in your app or by system settings.</span></span> <span data-ttu-id="23c3a-129">アプリがアクティブなときに使用されるタブの色は、次のように決定されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-129">The tab color used when your app is active is determined as follows:</span></span>

- <span data-ttu-id="23c3a-130">アプリでタブの色を指定すると、その色の優先順位が最も高くなります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-130">If you specify a tab color in your app, it has highest priority.</span></span> <span data-ttu-id="23c3a-131">アプリで指定したタブの色は、システム設定に関係なくアプリがアクティブなときに使用されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-131">The tab color you specify in your app is used when your app is active regardless of system settings.</span></span>
- <span data-ttu-id="23c3a-132">それ以外の場合、タイトル バーにアクセント カラーを表示するためにユーザーが Windows の設定でオプションを選択すると、システムのアクセント カラーが使用されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-132">Otherwise, if the user selects the option in Windows Settings to show the accent color on title bars, the system accent color is used.</span></span>
  - <span data-ttu-id="23c3a-133">この設定は、Windows 設定アプリの [パーソナル設定] > [色] > [以下の場所にアクセント カラーを表示します] の [タイトル バー] にあります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-133">This setting is found in the Windows Settings app under Personalization > Colors > Show accent color on the following surfaces: Title bars.</span></span>
- <span data-ttu-id="23c3a-134">最後に、アプリまたはユーザーの設定が適用されていない場合、タブは、現在のシステム テーマの色を使用します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-134">Finally, if no app or user settings are applied, the tab uses the current system theme color.</span></span>

### <a name="considerations-when-you-modify-tab-colors"></a><span data-ttu-id="23c3a-135">タブの色を変更する場合の考慮事項</span><span class="sxs-lookup"><span data-stu-id="23c3a-135">Considerations when you modify tab colors</span></span>

<span data-ttu-id="23c3a-136">ここでは、アプリのタブの色を変更する可能性がある状況、およびそのような場合に考慮する必要がある事項について説明します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-136">Here, we discuss situations where you might want to modify the tab color for your app, and things you should consider in those cases.</span></span> <span data-ttu-id="23c3a-137">タブの色を変更しないことをお勧めする状況についても説明しますが、それはシステムで管理するようにします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-137">We also discuss some situations where we recommend that you not modify the tab color, but let the system manage it.</span></span>

#### <a name="match-your-brand-colors"></a><span data-ttu-id="23c3a-138">ブランドの色を一致させる</span><span class="sxs-lookup"><span data-stu-id="23c3a-138">Match your brand colors</span></span>

<span data-ttu-id="23c3a-139">通常、タブの色を変更するかどうかを決定する最も重要な要素は、ブランドの色と一致させたいという要望です。</span><span class="sxs-lookup"><span data-stu-id="23c3a-139">Typically, the overriding factor that determines whether you modify the tab color is the desire to match your brand color.</span></span> <span data-ttu-id="23c3a-140">ブランドの色と一致するようにアプリのタブを変更する場合、アプリのレイアウトや異なるシステム テーマの色など、このセクションで説明されているその他の考慮事項を踏まえて外観をテストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-140">When you modify your app tab to match your brand color, you should test how it looks in light of the other considerations outlined in this section, such as your app layout, or different system theme colors.</span></span>

#### <a name="horizontal-layout"></a><span data-ttu-id="23c3a-141">水平方向のレイアウト</span><span class="sxs-lookup"><span data-stu-id="23c3a-141">Horizontal layout</span></span>

<span data-ttu-id="23c3a-142">アプリのレイアウトに、上部で水平方向に伸びる単色 (アクリル以外) のブランド色が含まれる場合、通常、一致する色を使用して、アプリをタブとつなげるのが適切です。</span><span class="sxs-lookup"><span data-stu-id="23c3a-142">If your app layout includes a solid (non-Acrylic) band of color that runs horizontally across the top, it typically works well to connect your app with its tab by using a matching color.</span></span> <span data-ttu-id="23c3a-143">できればアプリの上部で使用されている色につながりをもたせることで、アプリと関係があると感じられる単色をタブに選択します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-143">Choose a solid color for your tab that feels connected to your app, ideally by providing some continuity to the color used at the top of your app.</span></span>

#### <a name="horizontal-layout-with-acrylic"></a><span data-ttu-id="23c3a-144">アクリルを使用した横長のレイアウト</span><span class="sxs-lookup"><span data-stu-id="23c3a-144">Horizontal layout with Acrylic</span></span>

<span data-ttu-id="23c3a-145">アプリで、上部で水平方向に伸びるアクリル素材のブランドが使用されている場合、システムにタブの色を決定させることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-145">If your app uses a band of Acrylic material that runs horizontally across the top, we recommend that you let the system determine the tab color.</span></span>

<span data-ttu-id="23c3a-146">また、背景アクリルではなく、アプリ内アクリルをここで使用することをお勧めします。これにより、このブランドの背後でアプリケーションまたはデスクトップを通じて表示される縞模様の効果を作成するのではなく、アプリケーション バックグラウンドがこの領域に流れるようにします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-146">We also recommend using in-app Acrylic here rather than using background Acrylic to let your application background flow to this area rather than creating a banding effect showing through the application or desktop behind this band.</span></span>

<span data-ttu-id="23c3a-147">この場合、ユーザーはこれらのタブを設定してアクセント カラーを使用し、タブが淡色/濃色のテーマまたはアクセント カラーで表示されるようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-147">Please note that user is able to set these tabs to use accent color in this case so they could appear either light/dark theme or accent color.</span></span>

#### <a name="vertical-layout"></a><span data-ttu-id="23c3a-148">縦方向のレイアウト</span><span class="sxs-lookup"><span data-stu-id="23c3a-148">Vertical layout</span></span>

<span data-ttu-id="23c3a-149">垂直方向に伸びる単色の縦のウィンドウがアプリ レイアウトに含まれる場合は、タブの色をカスタマイズしないことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-149">If your app layout includes a vertical pane of solid color that run vertically, we recommend that you not customize the tab colors.</span></span> <span data-ttu-id="23c3a-150">アプリ上のタブの位置はユーザーがいつでも変更できるため、アプリの上部とタブの間の色の連続性を利用することはできません。システムでは、タブをアプリとつなげるために、影などのその他の視覚的な合図を使用します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-150">The position of the tab above your app can be changed at any time by the user, so you can't count on color continuity between the top part of your app and the tab. The system uses other visual cues, like shadows, to connect the tab with your app.</span></span>

### <a name="how-to-modify-tab-colors"></a><span data-ttu-id="23c3a-151">タブの色を変更する方法</span><span class="sxs-lookup"><span data-stu-id="23c3a-151">How to modify tab colors</span></span>

<span data-ttu-id="23c3a-152">アクティブなタブの色は、既存のタイトル バーのカスタマイズ用 API を使用します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-152">The active tab color uses the existing title bar customization APIs.</span></span> <span data-ttu-id="23c3a-153">既にアプリのタイトル バーの色をカスタマイズした場合は、アプリが Set 内にあるときにその変更がアプリのタブにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-153">If you've already customized the title bar color for your app, the change also applies to the app tab when your app is in a Set.</span></span>

<span data-ttu-id="23c3a-154">タブの色を変更するには、[ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) プロパティを設定して次の内容を指定します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-154">To modify tab colors, set [ApplicationViewTitleBar](https://docs.microsoft.com/uwp/api/windows.ui.viewmanagement.applicationviewtitlebar) properties to specify:</span></span>

- <span data-ttu-id="23c3a-155">タブに対する単色の背景色。</span><span class="sxs-lookup"><span data-stu-id="23c3a-155">A solid background color to your tab.</span></span>
- <span data-ttu-id="23c3a-156">タブのテキストに対する単色の前景色。</span><span class="sxs-lookup"><span data-stu-id="23c3a-156">A solid foreground color to your tab text.</span></span>

<span data-ttu-id="23c3a-157">この例では、ApplicationViewTitleBar のインスタンスを取得し、色のプロパティを設定する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="23c3a-157">This example shows how to get an instance of ApplicationViewTitleBar and set its color properties.</span></span>

```csharp
// using Windows.UI.ViewManagement;
var titleBar = ApplicationView.GetForCurrentView().TitleBar;

// Set active window colors
titleBar.ForegroundColor = Windows.UI.Colors.White;
titleBar.BackgroundColor = Windows.UI.Colors.Green;
```

<span data-ttu-id="23c3a-158">詳細については、「[タイトル バーのカスタマイズ](title-bar.md#simple-color-customization)」の記事と「[タイトル バーのカスタマイズのサンプル](http://go.microsoft.com/fwlink/p/?LinkId=620613)」の「_単純な色のカスタマイズ_」のセクションを参照してください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-158">For more info, see the _Simple color customization_ section of the [Title bar customization](title-bar.md#simple-color-customization) article and the [Title bar customization sample](http://go.microsoft.com/fwlink/p/?LinkId=620613).</span></span>

### <a name="considerations-for-full-title-bar-customization"></a><span data-ttu-id="23c3a-159">タイトル バーの全面的なカスタマイズに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="23c3a-159">Considerations for full title bar customization</span></span>

<span data-ttu-id="23c3a-160">「[タイトル バーのカスタマイズ](title-bar.md#full-customization)」の記事の「_全面的なカスタマイズ_」のセクションに示されているように、アプリのタイトル バーを完全にカスタマイズすることもできます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-160">You can also fully customize your app's title bar, as described in the _Full customization_ section of the [Title bar customization](title-bar.md#full-customization) article.</span></span> <span data-ttu-id="23c3a-161">通常これは、[アクリルをタイトル バーに拡張する](../style/acrylic.md#extend-acrylic-into-the-title-bar)か、またはカスタム コンテンツをタイトル バーに配置するために行います。</span><span class="sxs-lookup"><span data-stu-id="23c3a-161">You typically do this to [extend Acrylic into the title bar](../style/acrylic.md#extend-acrylic-into-the-title-bar), or to place custom content in the title bar.</span></span> <span data-ttu-id="23c3a-162">これを行う場合は、必ず全画面表示とタブレット モードのガイダンスに従い、[CoreApplicationViewTitleBar.IsVisible](/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.isvisible) が **true** の場合は、カスタム タイトル バーのコンテンツのみ表示するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-162">If you do this, be sure to follow the guidance for full-screen and tablet mode, and only show your custom title bar content when [CoreApplicationViewTitleBar.IsVisible](/uwp/api/windows.applicationmodel.core.coreapplicationviewtitlebar.isvisible) is **true**.</span></span>

<span data-ttu-id="23c3a-163">アプリが Set で実行され、CoreApplicationViewTitleBar.IsVisible が **false** の場合は、タイトル バーのコンテンツが表示されないようにします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-163">When your app runs in a Set, CoreApplicationViewTitleBar.IsVisible is **false**, and the title bar content should not be shown.</span></span> <span data-ttu-id="23c3a-164">ただし、このガイダンスに従ってカスタム タイトル バーのコンテンツを非表示にしない場合は、カスタム タイトル バーはタイトル バー領域ではなくアプリのタブの下に表示されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-164">However, if you don't follow this guidance to hide your custom title bar content, it's shown below your app's tab, and not in the title bar area.</span></span>

<span data-ttu-id="23c3a-165">カスタム タイトル バーの UI にコンテンツや機能を配置した場合は、アプリの別の UI サーフェスでそれが利用できるようにすることを考慮してください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-165">If you've placed content or functionality in your custom title bar UI, consider making it available in another UI surface in your app.</span></span>

### <a name="how-to-modify-the-tab-icon"></a><span data-ttu-id="23c3a-166">タブのアイコンを変更する方法</span><span class="sxs-lookup"><span data-stu-id="23c3a-166">How to modify the tab icon</span></span>

<span data-ttu-id="23c3a-167">アプリ アイコンが Set 内で最適に表示されるようにするには、アプリの代替のプレートなしのアイコンを指定する必要があります </span><span class="sxs-lookup"><span data-stu-id="23c3a-167">To make sure your app icon looks its best in a Set, you should provide an alternate, unplated icon for your app.</span></span> <span data-ttu-id="23c3a-168">(アプリのタブで使用されるアプリ アイコンは、タスク バーで使用されるのと同じアイコンです)。代替のアイコンの目的は、任意の背景色に対して最適に表示されることです。</span><span class="sxs-lookup"><span data-stu-id="23c3a-168">(The app icon used in your app's tab is the same icon used in the taskbar.) The purpose of the alternate icon is to look good against any background color.</span></span> <span data-ttu-id="23c3a-169">代替のアイコンは、利用可能な場合に使用されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-169">The alternate icon will be used if available.</span></span>

<span data-ttu-id="23c3a-170">アプリ マニフェストでは、通常のアイコンだけでなく、代替フォームのプレートなしのアイコンを指定します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-170">In you app manifest, specify an alternate-form unplated icon in addition to your regular icon.</span></span> <span data-ttu-id="23c3a-171">詳細については、[アプリのアイコンとロゴ](/windows/uwp/design/style/app-icons-and-logos)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-171">For more information, see [App icons and logos](/windows/uwp/design/style/app-icons-and-logos).</span></span> <span data-ttu-id="23c3a-172">指定するアイコンは、「プレートなしのターゲット サイズの一覧のアセット」として」の記事の[アプリ アイコン アセットの詳細](/windows/uwp/design/style/app-icons-and-logos#more-about-app-icon-assets)セクションに記載されています。</span><span class="sxs-lookup"><span data-stu-id="23c3a-172">The icon to specify is documented as "Target-size list assets without plate" in the [More about app icon assets](/windows/uwp/design/style/app-icons-and-logos#more-about-app-icon-assets) section of the article.</span></span>

<span data-ttu-id="23c3a-173">アプリ マニフェストで代替のアイコンを指定しない場合、システムはタイル アイコンをタブの色で再プレートし、それを使用します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-173">If you don't specify an alternate icon in the app manifest, the system will re-plate your the tile icon with the tab color and use that.</span></span>

![Sets で使用されるアイコン](images/sets-icons.png)

> <span data-ttu-id="23c3a-175">タスク バーとアプリ タブで、同じアイコンが使用されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-175">The same icon is used in the task bar and in the app tab.</span></span>

## <a name="restore-previous-sets-with-user-activities"></a><span data-ttu-id="23c3a-176">ユーザー アクティビティによる前の Sets の復元</span><span class="sxs-lookup"><span data-stu-id="23c3a-176">Restore previous Sets with user activities</span></span>

<span data-ttu-id="23c3a-177">Sets の利点は、ユーザーがアプリを起動したときやドキュメントを開いたときに、アプリや Web コンテンツの以前に開いたタブを復元できることです </span><span class="sxs-lookup"><span data-stu-id="23c3a-177">A benefit of Sets is that it lets your users restore previously open tabs for apps and web content when they launch an app or open a document.</span></span> <span data-ttu-id="23c3a-178">(詳細については、[Sets の概要](https://insider.windows.com/en-us/articles/introducing-sets/)に関するブログ記事にあるビデオを参照してください)。これは、_ユーザー アクティビティ_によって有効になります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-178">(See the video in the [Introducing Sets](https://insider.windows.com/en-us/articles/introducing-sets/) blog post for more info.) This is enabled through _user activities_.</span></span>

<span data-ttu-id="23c3a-179">既定では、システムはアプリの代わりにユーザー アクティビティを作成します。これによりユーザーがアプリを起動したときやドキュメントを開いたときにアプリがタブに復元されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-179">By default, the system creates user activities on behalf of your app, which lets your app be restored to a tab when a user launches an app or opens a document.</span></span> <span data-ttu-id="23c3a-180">ただし、システムによって作成された既定のユーザー アクティビティでは、既定の状態でのみアプリを起動できます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-180">However, the default user activities created by the system can only launch your app in its default state.</span></span> <span data-ttu-id="23c3a-181">Set の一部として以前の状態にアプリを復元することはできません。</span><span class="sxs-lookup"><span data-stu-id="23c3a-181">It can’t restore your app to the state it was in previously as part of the Set.</span></span>

<span data-ttu-id="23c3a-182">カスタム ユーザー アクティビティを提供することで、Sets のアプリを最適化できます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-182">You can optimize your app for Sets by providing custom user activities.</span></span> <span data-ttu-id="23c3a-183">指定するユーザー アクティビティはアプリにディープ リンクし、復元されている Set の一部として前回の状態にアプリを復元します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-183">The user activity you provide deep-links into your app to restore it to the state it was last in as part of the Set being restored.</span></span>

<span data-ttu-id="23c3a-184">カスタム ユーザー アクティビティを指定するには:</span><span class="sxs-lookup"><span data-stu-id="23c3a-184">To provide a custom user activity:</span></span>

- <span data-ttu-id="23c3a-185">OS により開始された [UserActivityRequest](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequest) に適切な [UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity) で応答します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-185">Respond to an OS initiated [UserActivityRequest](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequest) with an appropriate [UserActivity](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivity).</span></span>
- <span data-ttu-id="23c3a-186">UserActivity には、システムが特定のコンテキストでアプリを起動するために使用するアクティブ化のディープ リンク URI が含まれます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-186">The UserActivity contains an activation deep link URI that the system uses to launch your app with a specific context.</span></span>

<span data-ttu-id="23c3a-187">詳細については、「[UserActivityRequestManager.UserActivityRequested イベント](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequestmanager.useractivityrequested)」、「[URI のアクティブ化の処理](https://docs.microsoft.com/windows/uwp/launch-resume/handle-uri-activation)」、「[デバイス間でもユーザーのアクティビティを継続する](https://docs.microsoft.com/windows/uwp/launch-resume/useractivities)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-187">For more info, see [UserActivityRequestManager.UserActivityRequested Event](https://docs.microsoft.com/uwp/api/windows.applicationmodel.useractivities.useractivityrequestmanager.useractivityrequested), [Handle URI activation](https://docs.microsoft.com/windows/uwp/launch-resume/handle-uri-activation), and [Continue user activity, even across devices](https://docs.microsoft.com/windows/uwp/launch-resume/useractivities).</span></span>

## <a name="enable-multi-instance-for-uwp-apps"></a><span data-ttu-id="23c3a-188">UWP アプリ用のマルチインスタンスを有効にします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-188">Enable multi-instance for UWP apps</span></span>

<span data-ttu-id="23c3a-189">Windows 10 Version 1803 以降、UWP アプリはマルチインスタンスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-189">Starting in Windows 10, version 1803, UWP apps support multi-instancing.</span></span> <span data-ttu-id="23c3a-190">UWP は既定でまだ単一インスタンスであり、マルチインスタンス化する各アプリを明示的に選択する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-190">UWP are still single-instance by default, and you have to explicitly opt in each app that you want to be multi-instanced.</span></span>

<span data-ttu-id="23c3a-191">アプリをマルチインスタンスにする場合は、ユーザーが一度に複数の Set でアプリを実行するようにできるメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-191">If you make your app multi-instance, it provides the benefit of letting you users run your app in more than one Set at a time.</span></span> <span data-ttu-id="23c3a-192">単一インスタンスのアプリは一度に 1 つの Set でしか実行できません。</span><span class="sxs-lookup"><span data-stu-id="23c3a-192">A single-instance app can only run in one Set at a time.</span></span>

<span data-ttu-id="23c3a-193">UWP アプリのマルチインスタンスを有効にする方法の詳細については、「[マルチインスタンスのユニバーサル Windows アプリの作成](https://docs.microsoft.com/windows/uwp/launch-resume/multi-instance-uwp)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-193">For more info about how to enable multi-instance for your UWP app, see [Create a multi-instance Universal Windows App](https://docs.microsoft.com/windows/uwp/launch-resume/multi-instance-uwp).</span></span>

## <a name="use-an-in-app-back-button"></a><span data-ttu-id="23c3a-194">アプリ内の戻るボタンの使用</span><span class="sxs-lookup"><span data-stu-id="23c3a-194">Use an in-app back button</span></span>

<span data-ttu-id="23c3a-195">アプリに前に戻る移動を実装するには、「[戻るボタンのガイダンス](../basics/navigation-history-and-backwards-navigation.md)」に従って、アプリの UI に戻るボタンを配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-195">To implement backwards navigation in your app, we recommend that you place a back button in your app's UI according to the [back button guidance](../basics/navigation-history-and-backwards-navigation.md).</span></span> <span data-ttu-id="23c3a-196">アプリで NavigationView コントロールを使用する場合は、NavigationView の組み込みの戻るボタンを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-196">If your app uses the NavigationView control, then you should use NavigationView's built-in back button.</span></span>

<span data-ttu-id="23c3a-197">アプリでシステムの戻るボタンを使用している場合は、代わりにアプリ内の戻るボタンで置き換える必要があります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-197">If your app uses the system back button, you should replace it with an in-app back button instead.</span></span> <span data-ttu-id="23c3a-198">これにより、アプリが Set で実行されているかどうかにかかわらず、ユーザーに一貫性のある戻るボタンのエクスペリエンスが提供されます。また、アプリ間で戻るボタンの視覚効果の一貫性が維持されるようになります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-198">This ensures that users have a consistent back button experience whether or not the app runs in a Set, and also ensures that back button visuals remain consistent across apps.</span></span>

<span data-ttu-id="23c3a-199">アプリ内の戻るボタンの統合に関する詳細なガイダンスについては、「[ナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="23c3a-199">For detailed guidance about integrating an in-app back button, see [Navigation history and backwards navigation](../basics/navigation-history-and-backwards-navigation.md).</span></span>

### <a name="support-for-the-system-back-button-in-sets"></a><span data-ttu-id="23c3a-200">Sets 内のシステムの戻るボタンのサポート</span><span class="sxs-lookup"><span data-stu-id="23c3a-200">Support for the system back button in Sets</span></span>

<span data-ttu-id="23c3a-201">アプリでアプリ内ボタンではなくシステムの戻るボタンを使用している場合、下位互換性を確保するためにシステム UI には引き続きシステムの戻るボタンがレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-201">If your app uses the system back button rather than an in-app button, the system UI will still render the system back button to ensure backward compatibility</span></span>

- <span data-ttu-id="23c3a-202">アプリが Set 内にない場合は、戻るボタンはタイトル バーの内部にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-202">If your app is not in a Set, then the back button is rendered inside the title bar.</span></span> <span data-ttu-id="23c3a-203">戻るボタンの視覚エクスペリエンスとユーザー操作は変更されません。</span><span class="sxs-lookup"><span data-stu-id="23c3a-203">The visual experience and user interactions for the back button are unchanged.</span></span>
- <span data-ttu-id="23c3a-204">アプリが Set 内にある場合は、戻るボタンはシステムの戻るバーの内部にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-204">If your app is in a Set, then the back button is rendered inside the system back bar.</span></span>

<span data-ttu-id="23c3a-205">システムの戻るバーは、タブ バンドとアプリのコンテンツ領域の間に挿入されている "バンド" です。</span><span class="sxs-lookup"><span data-stu-id="23c3a-205">The system back bar is a "band" that is inserted between the tab band and the app's content area.</span></span> <span data-ttu-id="23c3a-206">バンドは、アプリの幅に沿って表示され、左端に戻るボタンが配置されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-206">The band goes across the width of the app, with the back button on the left edge.</span></span> <span data-ttu-id="23c3a-207">バンドには、戻るボタンの適切なタッチ ターゲットのサイズを確保するために十分な高さがあります。</span><span class="sxs-lookup"><span data-stu-id="23c3a-207">The band has a vertical height that is large enough to ensure adequate touch target size for the back button.</span></span>

![Sets 内のシステムの戻るバー](images/sets-system-back-bar.png)

> <span data-ttu-id="23c3a-209">アプリに表示されたシステムの戻るバー。</span><span class="sxs-lookup"><span data-stu-id="23c3a-209">The system back bar shown in an app.</span></span>

<span data-ttu-id="23c3a-210">システムの戻るバーは、戻るボタンの可視性に基づいて動的に表示されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-210">The system back bar is displayed dynamically, based on back button visibility.</span></span> <span data-ttu-id="23c3a-211">戻るボタンが表示されている場合、システムの戻るバーが挿入され、アプリのコンテンツがタブ バンドの下に移動します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-211">When the back button is visible, the system back bar is inserted, shifting app content down below the tab band.</span></span> <span data-ttu-id="23c3a-212">戻るボタンが非表示の場合、システムの戻るバーは動的に削除され、アプリのコンテンツがタブ バンドに合うように移動します。</span><span class="sxs-lookup"><span data-stu-id="23c3a-212">When the back button is hidden, the system back bar is dynamically removed, shifting app content up to meet the tab band.</span></span>

<span data-ttu-id="23c3a-213">アプリの UI が上下に移動するのを避けるために、システムの戻るボタンの代わりに、アプリ内の戻るボタンを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="23c3a-213">To avoid having your app's UI shift up or down, we recommend using an in-app back button instead of the system back button.</span></span>

<span data-ttu-id="23c3a-214">タイトル バーのカスタマイズは、アプリ タブとシステムの戻るバーの両方に引き継がれます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-214">Title bar customizations carry over to both the app tab and the system back bar.</span></span> <span data-ttu-id="23c3a-215">ApplicationViewTitleBar API を使用して背景色と前景色のプロパティを指定する場合は、色がタブとシステムの戻るバーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="23c3a-215">If you use ApplicationViewTitleBar APIs to specify background and foreground color properties, the colors are applied to the tab and system back bar.</span></span>

## <a name="related-articles"></a><span data-ttu-id="23c3a-216">関連記事</span><span class="sxs-lookup"><span data-stu-id="23c3a-216">Related articles</span></span>

- [<span data-ttu-id="23c3a-217">タイトル バーのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="23c3a-217">Title bar customization</span></span>](title-bar.md)
- [<span data-ttu-id="23c3a-218">ナビゲーション履歴と前に戻る移動</span><span class="sxs-lookup"><span data-stu-id="23c3a-218">Navigation history and backwards navigation</span></span>](../basics/navigation-history-and-backwards-navigation.md)
- [<span data-ttu-id="23c3a-219">色</span><span class="sxs-lookup"><span data-stu-id="23c3a-219">Color</span></span>](../style/color.md)
