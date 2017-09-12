---
author: Jwmsft
Description: "画面領域を節約しながら、トップレベルのナビゲーションをレイアウトするコントロール"
title: "ナビゲーション ビュー"
ms.assetid: 
label: Navigation view
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: tpaine
doc-status: Published
ms.openlocfilehash: 98ab8a95288e5a0225a2185f7ce037e16209d173
ms.sourcegitcommit: ba0d20f6fad75ce98c25ceead78aab6661250571
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/24/2017
---
# <a name="navigation-view"></a><span data-ttu-id="1f2dc-104">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="1f2dc-104">Navigation view</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

> [!IMPORTANT]
> <span data-ttu-id="1f2dc-105">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-105">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="1f2dc-106">ここに記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-106">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="1f2dc-107">ナビゲーション ビュー コントロールは、折りたたみ可能なナビゲーション メニューを利用して、よくある縦方向のレイアウトをアプリのトップレベルの領域に提供します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-107">The navigation view control provides a common vertical layout for top-level areas of your app via a collapsible navigation menu.</span></span> <span data-ttu-id="1f2dc-108">このコントロールは、ナビゲーション ウィンドウ (またはハンバーガー メニュー) パターンを実装するために設計されていて、レイアウトをさまざまなウィンドウ サイズに自動的に合わせます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-108">This control is designed to implement the nav pane, or hamburger menu, pattern and automatically adapts its layout to different window sizes.</span></span>

> <span data-ttu-id="1f2dc-109">**重要な API**: [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)、[NavigationViewItem クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)、[NavigationViewDisplayMode 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)</span><span class="sxs-lookup"><span data-stu-id="1f2dc-109">**Important APIs**: [NavigationView class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview), [NavigationViewItem class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem), [NavigationViewDisplayMode enumeration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)</span></span>

![NavigationView の例](images/navview_wireframe.png)


## <a name="is-this-the-right-control"></a><span data-ttu-id="1f2dc-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="1f2dc-111">Is this the right control?</span></span>

<span data-ttu-id="1f2dc-112">NavigationView は、次の場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-112">NavigationView works well for:</span></span>

-  <span data-ttu-id="1f2dc-113">同じような種類のトップレベルのナビゲーション項目が多数あるアプリ。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-113">Apps with many top-level navigation items that are of similar type.</span></span> <span data-ttu-id="1f2dc-114">たとえば、フットボール、野球、バスケットボール、サッカーといったカテゴリがあるスポーツ アプリなどです。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-114">For example, a sports app with categories like Football, Baseball, Basketball, Soccer, and so on.</span></span>
-  <span data-ttu-id="1f2dc-115">アプリ間で一貫性のあるナビゲーション エクスペリエンスを提供する場合。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-115">Providing a consistent navigational experience across apps.</span></span> <span data-ttu-id="1f2dc-116">このウィンドウにはナビゲーション要素のみを含める必要があります。アクションは含めません。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-116">The pane should include only navigational elements, not actions.</span></span>
-  <span data-ttu-id="1f2dc-117">トップレベルのナビゲーションのカテゴリの数が中程度から多い (5 ～ 10 個の) 場合。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-117">A medium-to-high number (5-10) of top-level navigational categories.</span></span>
-  <span data-ttu-id="1f2dc-118">小さいウィンドウの画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-118">Preserving screen real estate of smaller windows.</span></span>

<span data-ttu-id="1f2dc-119">ナビゲーション ビューは、いくつかある利用可能なナビゲーション要素の 1 つです。ナビゲーション パターンと他のナビゲーション要素について詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーション デザインの基本](../layout/navigation-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-119">Navigation view is just one of several navigation elements you can use; to learn more about navigation patterns and other navigation elements, see the [Navigation design basics for Universal Windows Platform (UWP) apps](../layout/navigation-basics.md).</span></span>

<span data-ttu-id="1f2dc-120">SplitView と ListView を使用してナビゲーション ウィンドウ パターンを構築する方法のコード サンプルについては、GitHub から [XAML ナビゲーション ソリューション](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/XamlNavigation)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-120">For a code sample of how to build the nav pane pattern using SplitView and ListView, download the [XAML Navigation solution](https://github.com/Microsoft/Windows-universal-samples/tree/dev/Samples/XamlNavigation) from GitHub.</span></span>

## <a name="navigationview-parts"></a><span data-ttu-id="1f2dc-121">NavigationView パーツ</span><span class="sxs-lookup"><span data-stu-id="1f2dc-121">NavigationView parts</span></span>
<span data-ttu-id="1f2dc-122">このコントロールは大まかに 3 つのセクションに分けられます。左側のナビゲーション用ウィンドウと、右側のヘッダー領域およびコンテンツ領域です。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-122">The control is broadly subdivided into three sections - a pane for navigation on the left, and header and content areas on the right.</span></span>

![NavigationView セクション](images/navview_sections.png)

### <a name="pane"></a><span data-ttu-id="1f2dc-124">ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="1f2dc-124">Pane</span></span>

<span data-ttu-id="1f2dc-125">ナビゲーション ウィンドウには以下が含まれる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-125">The navigation pane can contain:</span></span>

- <span data-ttu-id="1f2dc-126">特定のページに移動するための、[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem) という形式のナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="1f2dc-126">Navigation items, in the form of [NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem), for navigating to specific pages</span></span>
- <span data-ttu-id="1f2dc-127">ナビゲーション項目をグループ化するための、[NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator) という形式の区切り</span><span class="sxs-lookup"><span data-stu-id="1f2dc-127">Separators, in the form of [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator), for grouping navigation items</span></span>
- <span data-ttu-id="1f2dc-128">項目のグループにラベルを付けるための、[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader) という形式のヘッダー</span><span class="sxs-lookup"><span data-stu-id="1f2dc-128">Headers, in the form of [NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader), for labeling groups of items</span></span>
- <span data-ttu-id="1f2dc-129">[アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-129">An optional entry point for [app settings](../app-settings/app-settings-and-data.md).</span></span> <span data-ttu-id="1f2dc-130">設定項目を非表示にするには、[IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_IsSettingsVisible) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-130">To hide the settings item, use the [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_IsSettingsVisible) property</span></span>
- <span data-ttu-id="1f2dc-131">[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-131">Free-form content in the pane’s footer, when added to the [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_PaneFooter) property</span></span>

<span data-ttu-id="1f2dc-132">組み込みのナビゲーション ("ハンバーガー") ボタンを使用して、ユーザーはウィンドウを開いたり閉じたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-132">The built-in navigation ("hamburger") button lets users open and close the pane.</span></span> <span data-ttu-id="1f2dc-133">[IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-133">On larger app windows when the pane is open, you may choose to hide this button using the [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_IsPaneToggleButtonVisible) property.</span></span>

### <a name="header"></a><span data-ttu-id="1f2dc-134">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1f2dc-134">Header</span></span>

<span data-ttu-id="1f2dc-135">ヘッダー領域は、ナビゲーション ボタンと垂直に揃えられていて、高さが固定されています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-135">The header area is vertically aligned with the navigation button and has a fixed height.</span></span> <span data-ttu-id="1f2dc-136">これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-136">Its purpose is to hold the page title of the selected nav category.</span></span> <span data-ttu-id="1f2dc-137">ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-137">The header is docked to the top of the page and acts as a scroll clipping point for the content area.</span></span>

<span data-ttu-id="1f2dc-138">NavigationView が最小モードの場合は、ヘッダーが表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-138">The header must be visible when NavigationView is in Minimal mode.</span></span> <span data-ttu-id="1f2dc-139">ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-139">You may choose to hide the header in other modes, which are used on larger window widths.</span></span> <span data-ttu-id="1f2dc-140">これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_AlwaysShowHeader) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-140">To do so, set the [AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_AlwaysShowHeader) property to **false**.</span></span>

### <a name="content"></a><span data-ttu-id="1f2dc-141">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="1f2dc-141">Content</span></span>

<span data-ttu-id="1f2dc-142">コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-142">The content area is where most of the information for the selected nav category is displayed.</span></span> <span data-ttu-id="1f2dc-143">1 つ以上の要素を含めることができ、[ピボット](tabs-pivot.md)など、サブレベル ナビゲーションを追加するのに適切な領域です。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-143">It can contain one or more elements and is a good area for additional sub-level navigation such as [Pivot](tabs-pivot.md).</span></span>

<span data-ttu-id="1f2dc-144">NavigationView が最小モードの場合はコンテンツの両側に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-144">We recommend 12px margins on your content’s sides when NavigationView is in Minimal mode and 24px margins otherwise.</span></span>

## <a name="visual-style"></a><span data-ttu-id="1f2dc-145">視覚スタイル</span><span class="sxs-lookup"><span data-stu-id="1f2dc-145">Visual style</span></span>

<div class="microsoft-internal-note">
<span data-ttu-id="1f2dc-146">このコントロールの赤線は [UNI](http://uni/DesignDepot.FrontEnd/#/ProductNav?t=Fluent%20Design%20System%7CControls%20%26%20Patterns%7CNavigationView) で提供されています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-146">Redlines for this control are available on [UNI](http://uni/DesignDepot.FrontEnd/#/ProductNav?t=Fluent%20Design%20System%7CControls%20%26%20Patterns%7CNavigationView).</span></span><br/><br/>
</div>

<span data-ttu-id="1f2dc-147">ナビゲーション項目は、選択、無効化、ホバー、押下、およびフォーカスされた表示状態に対応しています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-147">Navigation items have support for selected, disabled, pointer over, pressed, and focused visual states.</span></span>

![NavigationView 項目の状態: 無効化、ホバー、押下、フォーカス](images/navview_item-states.png)

<span data-ttu-id="1f2dc-149">ハードウェアとソフトウェアの要件が満たされている場合、NavigationView によって新しい[アクリル素材](../style/acrylic.md)と[表示ハイライト](../style/reveal.md)が自動的にウィンドウで使用されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-149">When hardware and software requirements are met, NavigationView automatically uses the new [Acrylic material](../style/acrylic.md) and [Reveal highlight](../style/reveal.md) in its pane.</span></span>


## <a name="navigationview-modes"></a><span data-ttu-id="1f2dc-150">NavigationView モード</span><span class="sxs-lookup"><span data-stu-id="1f2dc-150">NavigationView modes</span></span>
<span data-ttu-id="1f2dc-151">NavigationView ウィンドウは開いたり閉じたりすることができます。次の 3 つの表示モード オプションがあります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-151">The NavigationView pane can be open or closed, and has three display mode options:</span></span>
-  <span data-ttu-id="1f2dc-152">**最小**: ハンバーガー ボタンのみが固定され、必要に応じてウィンドウが表示されたり、非表示になったりします。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-152">**Minimal** Only the hamburger button remains fixed while the pane shows and hides as needed.</span></span>
-  <span data-ttu-id="1f2dc-153">**コンパクト**: ウィンドウは細長い小片として常に表示され、このウィンドウは幅全体まで開くことができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-153">**Compact** The pane always shows as a narrow sliver which can be opened to full width.</span></span>
-  <span data-ttu-id="1f2dc-154">**展開**: ウィンドウはコンテンツと共に開いています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-154">**Expanded** The pane is open alongside the content.</span></span> <span data-ttu-id="1f2dc-155">ハンバーガー ボタンを使って閉じると、ウィンドウの幅が細長い小片になります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-155">When closed by activating the hamburger button, the pane's width becomes a narrow sliver.</span></span>

<span data-ttu-id="1f2dc-156">既定では、コントロールで利用できる画面領域の大きさに基づいて、システムによって最適な表示モードが自動的に選択されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-156">By default, the system automatically selects the optimal display mode based on the amount of screen space available to the control.</span></span> <span data-ttu-id="1f2dc-157">(この設定はオーバーライドすることができます。詳しくは、次のセクションをご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-157">(You can override this setting — see the next section for details.)</span></span>

### <a name="minimal"></a><span data-ttu-id="1f2dc-158">最小</span><span class="sxs-lookup"><span data-stu-id="1f2dc-158">Minimal</span></span>

![閉じたウィンドウと開いたウィンドウを表示している、最小モードの NavigationView](images/navview_minimal.png)

-  <span data-ttu-id="1f2dc-160">閉じている場合、既定ではウィンドウが非表示になり、ナビゲーション ボタンのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-160">When closed, the pane is hidden by default, with only the nav button visible.</span></span>
-  <span data-ttu-id="1f2dc-161">画面領域を節約するオンデマンドのナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-161">Provides on-demand navigation that conserves screen real estate.</span></span> <span data-ttu-id="1f2dc-162">携帯電話やファブレット上のアプリに最適です。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-162">Ideal for apps on phones and phablets.</span></span>
-  <span data-ttu-id="1f2dc-163">ナビゲーション ボタンを押すことでウィンドウが開閉します。ウィンドウは、ヘッダーおよびコンテンツ上でオーバーレイとして描画されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-163">Pressing the nav button opens and closes the pane, which draws as an overlay above the header and content.</span></span> <span data-ttu-id="1f2dc-164">コンテンツは再配置されません。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-164">Content does not reflow.</span></span>
-  <span data-ttu-id="1f2dc-165">開いている場合、ウィンドウの表示は一時的なもので、選択したり、戻るボタンを押したり、ウィンドウの外側をタップしたりするなど、簡易非表示ジェスチャで閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-165">When open, the pane is transient and can be closed with a light dismiss gesture such as making a selection, pressing the back button, or tapping outside the pane.</span></span>
-  <span data-ttu-id="1f2dc-166">ウィンドウのオーバーレイが開いている場合は、選択した項目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-166">The selected item becomes visible when the pane’s overlay opens.</span></span>
-  <span data-ttu-id="1f2dc-167">要件が満たされていると、開いているウィンドウの背景が[アプリ内アクリル](../style/acrylic.md#acrylic-blend-types)になります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-167">When requirements are met, the open pane’s background is [in-app acrylic](../style/acrylic.md#acrylic-blend-types).</span></span>
-  <span data-ttu-id="1f2dc-168">既定では、全体の幅が 640 ピクセル以下の場合、NavigationView は最小モードになります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-168">By default, NavigationView is in Minimal mode when its overall width is less than or equal to 640px.</span></span>

### <a name="compact"></a><span data-ttu-id="1f2dc-169">コンパクト</span><span class="sxs-lookup"><span data-stu-id="1f2dc-169">Compact</span></span>

![閉じたウィンドウと開いたウィンドウを表示している、コンパクト モードの NavigationView](images/navview_compact.png)

-  <span data-ttu-id="1f2dc-171">閉じている場合、アイコンとナビゲーション ボタンだけを表示した垂直方向のウィンドウの小片が表示されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-171">When closed, a vertical sliver of the pane showing only icons and the nav button is visible.</span></span>
-  <span data-ttu-id="1f2dc-172">わずかな画面領域を使用して、選択された場所を示します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-172">Provides some indication of the selected location while using a small amount of screen real-estate.</span></span>
-  <span data-ttu-id="1f2dc-173">このモードは、タブレットや [10 フィート エクスペリエンス](../input-and-devices/designing-for-tv.md)などの普通サイズの画面に適しています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-173">This mode is better suited for medium screens like tablets and [10-foot experiences](../input-and-devices/designing-for-tv.md).</span></span>
-  <span data-ttu-id="1f2dc-174">ナビゲーション ボタンを押すことでウィンドウが開閉します。ウィンドウは、ヘッダーおよびコンテンツ上でオーバーレイとして描画されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-174">Pressing the nav button opens and closes the pane, which draws as an overlay above the header and content.</span></span> <span data-ttu-id="1f2dc-175">コンテンツは再配置されません。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-175">Content does not reflow.</span></span>
-  <span data-ttu-id="1f2dc-176">ヘッダーは必須ではなく、非表示にしてコンテンツの垂直方向の領域を広げることができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-176">The Header is not required and can be hidden to give Content more vertical space.</span></span>
-  <span data-ttu-id="1f2dc-177">選択した項目に視覚インジゲータが表示され、ナビゲーション ツリー内のユーザーの位置が強調されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-177">The selected item shows a visual indicator to highlight where the user is in the navigation tree.</span></span>
-  <span data-ttu-id="1f2dc-178">要件が満たされていると、ウィンドウの背景が[アプリ内アクリル](../style/acrylic.md#acrylic-blend-types)になります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-178">When requirements are met, the pane’s background is [in-app acrylic](../style/acrylic.md#acrylic-blend-types).</span></span>
-  <span data-ttu-id="1f2dc-179">既定では、全体の幅が 641 ～ 1007 ピクセルの場合、NavigationView はコンパクト モードになります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-179">By default, NavigationView is in Compact mode when its overall width is between 641px and 1007px.</span></span>

### <a name="expanded"></a><span data-ttu-id="1f2dc-180">展開</span><span class="sxs-lookup"><span data-stu-id="1f2dc-180">Expanded</span></span>

![開いているウィンドウを表示している、展開モードの NavigationView](images/navview_expanded.png)

-  <span data-ttu-id="1f2dc-182">既定では、ウィンドウは開いたままです。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-182">By default, the pane remains open.</span></span> <span data-ttu-id="1f2dc-183">このモードは、大きな画面に適しています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-183">This mode is better suited for larger screens.</span></span>
-  <span data-ttu-id="1f2dc-184">ウィンドウと、ヘッダーおよびコンテンツが左右に並べて描画され、利用可能な領域内でコンテンツが再配置されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-184">The pane draws side-by-side with the header and content, which reflows within its available space.</span></span>
-  <span data-ttu-id="1f2dc-185">ナビゲーション ボタンを使用してウィンドウを閉じると、ウィンドウはヘッダーとコンテンツと並んで細長い小片として表示されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-185">When the pane is closed using the nav button, the pane shows as a narrow sliver side-by-side with the header and content.</span></span>
-  <span data-ttu-id="1f2dc-186">ヘッダーは必須ではなく、非表示にしてコンテンツの垂直方向の領域を広げることができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-186">The Header is not required and can be hidden to give Content more vertical space.</span></span>
-  <span data-ttu-id="1f2dc-187">選択した項目に視覚インジゲータが表示され、ナビゲーション ツリー内のユーザーの位置が強調されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-187">The selected item shows a visual indicator to highlight where the user is in the navigation tree.</span></span>
-  <span data-ttu-id="1f2dc-188">要件が満たされている場合は、ウィンドウの背景が[背景アクリル](../style/acrylic.md#acrylic-blend-types)を使って描画されます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-188">When requirements are met, the pane’s background is painted using [background acrylic](../style/acrylic.md#acrylic-blend-types).</span></span>
-  <span data-ttu-id="1f2dc-189">既定では、全体の幅が 1007 ピクセルを超える場合、NavigationView は展開モードになります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-189">By default, NavigationView is in Expanded mode when its overall width is greater than 1007px.</span></span>

## <a name="overriding-the-default-adaptive-behavior"></a><span data-ttu-id="1f2dc-190">既定のアダプティブ動作のオーバーライド</span><span class="sxs-lookup"><span data-stu-id="1f2dc-190">Overriding the default adaptive behavior</span></span>

<span data-ttu-id="1f2dc-191">ナビゲーション ビューは、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-191">The navigation view automatically changes its display mode based on the amount of screen space available to it.</span></span>
[!NOTE] <span data-ttu-id="1f2dc-192">NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-192">NavigationView should serve as the root container of your app, this control is designed to span the full width and height of the app window.</span></span>
<span data-ttu-id="1f2dc-193">[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_CompactModeThresholdWidth) および ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_ExpandedModeThresholdWidth) プロパティを使って、ナビゲーション ビューの表示モードが変化する幅を上書きすることができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-193">You can override the widths at which the navigation view changes display modes by using the [CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_CompactModeThresholdWidth) and ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_ExpandedModeThresholdWidth) properties.</span></span> <span data-ttu-id="1f2dc-194">表示モードの動作をカスタマイズする場合を示した次のシナリオを考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-194">Consider the following scenarios that illustrate when you might want to customize the display mode behavior.</span></span>

-  <span data-ttu-id="1f2dc-195">**移動が頻繁**: ユーザーがアプリ領域間を多少頻繁に移動することが予想される場合は、ウィンドウ幅を狭くしたウィンドウを表示し続けることを検討します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-195">**Frequent navigation** If you expect users to navigate between app areas somewhat frequently, consider keeping the pane in view at narrower window widths.</span></span> <span data-ttu-id="1f2dc-196">曲、アルバム、およびアーティストのナビゲーション領域がある音楽アプリでは、280 ピクセルのウィンドウ幅を選び、アプリ ウィンドウの幅が 560 ピクセルよりも広い場合に展開モードを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-196">A music app with Songs / Albums / Artists navigation areas may opt for a 280px pane width and remain in Expanded mode while the app window is wider than 560px.</span></span>
```xaml
<NavigationView OpenPaneLength=”280” CompactModeThresholdWidth="560" ExpandedModeThresholdWidth=”560”/>
```
-    <span data-ttu-id="1f2dc-197">**移動がほとんどない** ユーザーがアプリ領域間をほとんど移動しないことが予想されるなら、ウィンドウ幅が広がってもウィンドウの非表示を維持することを検討します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-197">**Rare navigation** If you expect users to navigate between app areas very infrequently, consider keeping the pane hidden at wider window widths.</span></span> <span data-ttu-id="1f2dc-198">複数のレイアウトを使用する電卓アプリでは、1080p ディスプレイでアプリが最大化されている場合でも、最小モードを維持できます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-198">A calculator app with multiple layouts may opt to remain in Minimal mode even when the app is maximized on a 1080p display.</span></span>
```xaml
<NavigationView CompactModeThresholdWidth=”1920” ExpandedModeThresholdWidth=”1920”/>
```
-    <span data-ttu-id="1f2dc-199">**アイコンの不明瞭解消** アプリのナビゲーション領域が、わかりやすいアイコンに向いていない場合は、コンパクトモードの使用を避けます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-199">**Icon disambiguation** If your app’s navigation areas don’t lend themselves to meaningful icons, avoid using Compact mode.</span></span> <span data-ttu-id="1f2dc-200">コレクション、アルバム、およびフォルダーのナビゲーション領域のある画像表示アプリでは、幅が狭いときや中間のときは NavigationView を最小モードで表示し、幅が広いときは展開モードで表示することができます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-200">An image viewing app with Collections / Albums / Folders navigation areas may opt for showing NavigationView in Minimal mode at narrow and medium widths, and in Expanded mode at wide width.</span></span>
```xaml
<NavigationView CompactModeThresholdWidth=”1008”/>
```

## <a name="interaction"></a><span data-ttu-id="1f2dc-201">操作</span><span class="sxs-lookup"><span data-stu-id="1f2dc-201">Interaction</span></span>

<span data-ttu-id="1f2dc-202">ウィンドウのナビゲーション カテゴリをユーザーがタップすると、選択された項目が NavigationView によって表示されて、[ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_ItemInvoked) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-202">When users tap on a navigation category in the Pane, NavigationView will show that item as selected and will raise an [ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_ItemInvoked) event.</span></span> <span data-ttu-id="1f2dc-203">タップにより新しいアイテムが選択されると、NavigationView でさらに [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_SelectionChanged) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-203">If the tap results in a new item being selected, NavigationView will also raise a [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview#Windows_UI_Xaml_Controls_NavigationView_SelectionChanged) event.</span></span> <span data-ttu-id="1f2dc-204">アプリは、このユーザー操作に応じてヘッダーとコンテンツを適切な情報で更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-204">Your app is responsible for updating the Header and Content with appropriate information in response to this user interaction.</span></span> <span data-ttu-id="1f2dc-205">また、プログラムによってナビゲーション項目からコンテンツにフォーカスを移動することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-205">In addition, we recommend programmatically moving focus from the navigation item to the content.</span></span> <span data-ttu-id="1f2dc-206">読み込み時に最初のフォーカスを設定することで、ユーザー フローが合理化され、予測されるキーボード フォーカスの移動回数が最小限に抑えられます。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-206">By setting initial focus on load, you streamline the user flow and minimize the expected number of keyboard focus moves.</span></span>

## <a name="how-to-use-navigationview"></a><span data-ttu-id="1f2dc-207">NavigationView の使用方法</span><span class="sxs-lookup"><span data-stu-id="1f2dc-207">How to use NavigationView</span></span>

<span data-ttu-id="1f2dc-208">NavigationView をアプリに組み込む方法の簡単な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-208">The following is a simple example of how you can incorporate NavigationView into your app.</span></span>

```xaml
<Page
    x:Class="NavigationViewSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:NavigationViewSample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <NavigationView x:Name="NavView"
                    ItemInvoked="NavView_ItemInvoked"
                    Loaded="NavView_Loaded">
    <!-- Load NavigationViewItems in NavView_Loaded. -->

        <NavigationView.HeaderTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Style="{StaticResource TitleTextBlockStyle}"
                           FontSize="28"
                           VerticalAlignment="Center"
                           Margin="12,0"
                           Text="Welcome"/>
                    <CommandBar Grid.Column="1"
                            HorizontalAlignment="Right"
                            DefaultLabelPosition="Right"
                            Background="{ThemeResource SystemControlBackgroundAltHighBrush}">
                        <AppBarButton Label="Refresh" Icon="Refresh"/>
                        <AppBarButton Label="Import" Icon="Import"/>
                    </CommandBar>
                </Grid>
            </DataTemplate>
        </NavigationView.HeaderTemplate>

        <NavigationView.PaneFooter>
            <HyperlinkButton x:Name="MoreInfoBtn"
                             Content="More info"
                             Click="More_Click"
                             Margin="12,0"/>
        </NavigationView.PaneFooter>

        <Frame x:Name="ContentFrame">
            <Frame.ContentTransitions>
                <TransitionCollection>
                    <NavigationThemeTransition/>
                </TransitionCollection>
            </Frame.ContentTransitions>
        </Frame>

    </NavigationView>
</Page>
```

```csharp
private void NavView_Loaded(object sender, RoutedEventArgs e)
{
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "Apps", Icon = new SymbolIcon(Symbol.AllApps), Tag = "apps" });
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "Games", Icon = new SymbolIcon(Symbol.Video), Tag = "games" });
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "Music", Icon = new SymbolIcon(Symbol.Audio), Tag = "music" });
    NavView.MenuItems.Add(new NavigationViewItemSeparator());
    NavView.MenuItems.Add(new NavigationViewItem()
        { Text = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

    foreach (NavigationViewItem item in NavView.MenuItems)
    {
        if (item.Tag.ToString() == "play")
        {
            NavView.SelectedItem = item;
            break;
        }
    }
}

private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{
    if (args.IsSettingsInvoked == true)
    {
        ContentFrame.Navigate(typeof(SettingsPage));
    }
    else
    {
        switch ((args.InvokedItem as NavigationViewItem).Tag)
        {
          case "apps":
              ContentFrame.Navigate(typeof(AppsPage));
              break;

          case "games":
              ContentFrame.Navigate(typeof(GamesPage));
              break;

          case "music":
              ContentFrame.Navigate(typeof(MusicPage));
              break;

          case "content":
              ContentFrame.Navigate(typeof(MyContentPage));
              break;
        }
    }
}
```

## <a name="navigation"></a><span data-ttu-id="1f2dc-209">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="1f2dc-209">Navigation</span></span>

<span data-ttu-id="1f2dc-210">NavigationView によって自動的にアプリのタイトル バーに戻るボタンが表示されたり、バック スタックにコンテンツが追加されたりすることはありません。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-210">NavigationView does not automatically show the back button in your app’s title bar nor add content to the back stack.</span></span> <span data-ttu-id="1f2dc-211">ソフトウェアまたはハードウェアの戻るボタンが押されたときに、このコントロールが自動的に応答することもありません。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-211">The control does not automatically respond to software or hardware back button presses.</span></span> <span data-ttu-id="1f2dc-212">このトピックと、ナビゲーションのサポートをアプリに追加する方法について詳しくは、「[履歴と前に戻る移動](../layout/navigation-history-and-backwards-navigation.md)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="1f2dc-212">Please see the [history and backwards navigation](../layout/navigation-history-and-backwards-navigation.md) section for more information about this topic and how to add support for navigation to your app.</span></span>


## <a name="related-topics"></a><span data-ttu-id="1f2dc-213">関連トピック</span><span class="sxs-lookup"><span data-stu-id="1f2dc-213">Related topics</span></span>

* [<span data-ttu-id="1f2dc-214">NavigationView クラス</span><span class="sxs-lookup"><span data-stu-id="1f2dc-214">NavigationView class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
* [<span data-ttu-id="1f2dc-215">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="1f2dc-215">Master/details</span></span>](master-details.md)
* [<span data-ttu-id="1f2dc-216">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="1f2dc-216">Pivot control</span></span>](tabs-pivot.md)
* [<span data-ttu-id="1f2dc-217">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="1f2dc-217">Navigation basics</span></span>](../layout/navigation-basics.md)
 

 
