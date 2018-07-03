---
author: serenaz
Description: Control that provides top-level app navigation with an automatically adapting, collapsible left navigation menu
title: ナビゲーション ビュー
ms.assetid: ''
label: Navigation view
template: detail.hbs
ms.author: sezhen
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: vasriram
design-contact: kimsea
dev-contact: mitra
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: c7817bf7ff60a52ea48c988bdebd6d4d2eeacdb7
ms.sourcegitcommit: 618741673a26bd718962d4b8f859e632879f9d61
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 06/08/2018
ms.locfileid: "1992151"
---
# <a name="navigation-view"></a><span data-ttu-id="a9293-103">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="a9293-103">Navigation view</span></span>

<span data-ttu-id="a9293-104">ナビゲーション ビュー コントロールでは、アプリ内でトップレベルのナビゲーションを行うための折りたたみ可能なナビゲーション メニューを提供します。</span><span class="sxs-lookup"><span data-stu-id="a9293-104">The navigation view control provides a collapsible navigation menu for top-level navigation in your app.</span></span> <span data-ttu-id="a9293-105">このコントロールは、ナビゲーション ウィンドウ (またはハンバーガー メニュー) パターンを実装し、ウィンドウの表示モードをさまざまなウィンドウ サイズに自動的に合わせます。</span><span class="sxs-lookup"><span data-stu-id="a9293-105">This control implements the nav pane, or hamburger menu, pattern and automatically adapts the pane's display mode to different window sizes.</span></span>

> <span data-ttu-id="a9293-106">**重要な API**: [NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)、[NavigationViewItem クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)、[NavigationViewDisplayMode 列挙値](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)</span><span class="sxs-lookup"><span data-stu-id="a9293-106">**Important APIs**: [NavigationView class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview), [NavigationViewItem class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem), [NavigationViewDisplayMode enumeration](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewdisplaymode)</span></span>

![NavigationView の例](images/navview_wireframe.png)

## <a name="video-summary"></a><span data-ttu-id="a9293-108">概要 (ビデオ)</span><span class="sxs-lookup"><span data-stu-id="a9293-108">Video summary</span></span>

> [!VIDEO https://channel9.msdn.com/Events/Windows/Windows-Developer-Day-Fall-Creators-Update/WinDev010/player]

## <a name="is-this-the-right-control"></a><span data-ttu-id="a9293-109">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="a9293-109">Is this the right control?</span></span>

<span data-ttu-id="a9293-110">NavigationView は、次の場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="a9293-110">NavigationView works well for:</span></span>

-  <span data-ttu-id="a9293-111">同じような種類のさまざまなトップレベルのナビゲーション項目。</span><span class="sxs-lookup"><span data-stu-id="a9293-111">Many top-level navigation items of a similar type.</span></span> <span data-ttu-id="a9293-112">(たとえば、フットボール、野球、バスケットボール、サッカーといったカテゴリがあるスポーツ アプリなどです。)</span><span class="sxs-lookup"><span data-stu-id="a9293-112">(For example, a sports app with categories like Football, Baseball, Basketball, Soccer, and so on.)</span></span>
-  <span data-ttu-id="a9293-113">トップレベルのナビゲーションのカテゴリの数が中程度から多い (5 ～ 10 個の) 場合。</span><span class="sxs-lookup"><span data-stu-id="a9293-113">A medium-to-high number (5-10) of top-level navigational categories.</span></span>
-  <span data-ttu-id="a9293-114">一貫性のあるナビゲーション エクスペリエンスを提供する場合。</span><span class="sxs-lookup"><span data-stu-id="a9293-114">Providing a consistent navigational experience.</span></span> <span data-ttu-id="a9293-115">このウィンドウにはナビゲーション要素のみを含める必要があります。アクションは含めません。</span><span class="sxs-lookup"><span data-stu-id="a9293-115">The pane should include only navigational elements, not actions.</span></span>
-  <span data-ttu-id="a9293-116">小さいウィンドウの画面領域を節約します。</span><span class="sxs-lookup"><span data-stu-id="a9293-116">Preserving screen real estate of smaller windows.</span></span>

<span data-ttu-id="a9293-117">NavigationView は、いくつかある利用可能なナビゲーション要素の 1 つです。</span><span class="sxs-lookup"><span data-stu-id="a9293-117">NavigationView is just one of several navigation elements you can use.</span></span> <span data-ttu-id="a9293-118">他のナビゲーション パターンと要素について詳しくは、「[ナビゲーション デザインの基本](../basics/navigation-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9293-118">To learn more about other navigation patterns and elements, see [Navigation design basics](../basics/navigation-basics.md).</span></span>

<span data-ttu-id="a9293-119">NavigationView コントロールには、単純なナビゲーション ウィンドウ パターンを実装する多くの組み込みの動作があります。</span><span class="sxs-lookup"><span data-stu-id="a9293-119">The NavigationView control has many built-in behaviors that implement the simple nav pane pattern.</span></span> <span data-ttu-id="a9293-120">ナビゲーションで NavigationView でサポートされていないより複雑な動作が必要な場合、[マスター/詳細](master-details.md) パターンを代わりに検討することもできます。</span><span class="sxs-lookup"><span data-stu-id="a9293-120">If your navigation requires more complex behavior that is not supported by NavigationView, then you might want to consider the [Master/details](master-details.md) pattern instead.</span></span>

## <a name="examples"></a><span data-ttu-id="a9293-121">例</span><span class="sxs-lookup"><span data-stu-id="a9293-121">Examples</span></span>
<table>
<th align="left"><span data-ttu-id="a9293-122">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="a9293-122">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="a9293-123"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">アプリを開き、NavigationView の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="a9293-123">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/NavigationView">open the app and see the NavigationView in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="a9293-124">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="a9293-124">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="a9293-125">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="a9293-125">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="navigationview-sections"></a><span data-ttu-id="a9293-126">NavigationView セクション</span><span class="sxs-lookup"><span data-stu-id="a9293-126">NavigationView sections</span></span>

![NavigationView セクション](images/navview_sections.png)

### <a name="pane"></a><span data-ttu-id="a9293-128">ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="a9293-128">Pane</span></span>

<span data-ttu-id="a9293-129">組み込みのナビゲーション ("ハンバーガー") ボタンを使用して、ユーザーはウィンドウを開いたり閉じたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-129">The built-in navigation ("hamburger") button lets users open and close the pane.</span></span> <span data-ttu-id="a9293-130">[IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="a9293-130">On larger app windows when the pane is open, you may choose to hide this button using the [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) property.</span></span> <span data-ttu-id="a9293-131">ハンバーガーの横に表示されるテキスト ラベルは、[PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle) プロパティです。</span><span class="sxs-lookup"><span data-stu-id="a9293-131">The text label adjacent to the hamburger is the [PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle) property.</span></span>

<span data-ttu-id="a9293-132">組み込みの戻るボタンは、ウィンドウの左上隅に表示されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-132">The built-in back button appears in the top left-hand corner in the pane.</span></span> <span data-ttu-id="a9293-133">NavigationView コントロールによって自動的にバック スタックにコンテンツが追加されたりすることはありませんが、前に戻る移動を有効にするには、[前に戻る移動](#backwards-navigation) セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9293-133">The NavigationView control does not automatically add content to the back stack, but to enable backwards navigation, see the [backwards navigation](#backwards-navigation) section.</span></span>

<span data-ttu-id="a9293-134">NavigationView ウィンドウには以下が含まれる可能性もあります。</span><span class="sxs-lookup"><span data-stu-id="a9293-134">The NavigationView pane also can contain:</span></span>

- <span data-ttu-id="a9293-135">特定のページに移動するための、[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem) という形式のナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="a9293-135">Navigation items, in the form of [NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem), for navigating to specific pages</span></span>
- <span data-ttu-id="a9293-136">ナビゲーション項目をグループ化するための、[NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator) という形式の区切り</span><span class="sxs-lookup"><span data-stu-id="a9293-136">Separators, in the form of [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator), for grouping navigation items</span></span>
- <span data-ttu-id="a9293-137">項目のグループにラベルを付けるための、[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader) という形式のヘッダー</span><span class="sxs-lookup"><span data-stu-id="a9293-137">Headers, in the form of [NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader), for labeling groups of items</span></span>
- <span data-ttu-id="a9293-138">アプリ レベルの検索を可能にする [AutoSuggestBox](auto-suggest-box.md) (オプション)</span><span class="sxs-lookup"><span data-stu-id="a9293-138">An optional [AutoSuggestBox](auto-suggest-box.md) to allow for app-level search</span></span>
- <span data-ttu-id="a9293-139">[アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)</span><span class="sxs-lookup"><span data-stu-id="a9293-139">An optional entry point for [app settings](../app-settings/app-settings-and-data.md).</span></span> <span data-ttu-id="a9293-140">設定項目を非表示にするには、[IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible) プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="a9293-140">To hide the settings item, use the [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible) property</span></span>
- <span data-ttu-id="a9293-141">[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="a9293-141">Free-form content in the pane’s footer, when added to the [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) property</span></span>

#### <a name="visual-style"></a><span data-ttu-id="a9293-142">視覚スタイル</span><span class="sxs-lookup"><span data-stu-id="a9293-142">Visual style</span></span>

<span data-ttu-id="a9293-143">NavigationView 項目は、選択、無効化、ホバー、押下、およびフォーカスされた表示状態に対応しています。</span><span class="sxs-lookup"><span data-stu-id="a9293-143">NavigationView items have support for selected, disabled, pointer over, pressed, and focused visual states.</span></span>

![NavigationView 項目の状態: 無効化、ホバー、押下、フォーカス](images/navview_item-states.png)

<span data-ttu-id="a9293-145">ハードウェアとソフトウェアの要件が満たされている場合、NavigationView によって新しい[アクリル素材](../style/acrylic.md)と[表示ハイライト](../style/reveal.md)が自動的にウィンドウで使用されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-145">When hardware and software requirements are met, NavigationView automatically uses the new [Acrylic material](../style/acrylic.md) and [Reveal highlight](../style/reveal.md) in its pane.</span></span>

### <a name="header"></a><span data-ttu-id="a9293-146">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a9293-146">Header</span></span>

<span data-ttu-id="a9293-147">ヘッダー領域は、ナビゲーション ボタンと垂直に揃えられていて、高さが 52 ピクセルに固定されています。</span><span class="sxs-lookup"><span data-stu-id="a9293-147">The header area is vertically aligned with the navigation button and has a fixed height of 52 px.</span></span> <span data-ttu-id="a9293-148">これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。</span><span class="sxs-lookup"><span data-stu-id="a9293-148">Its purpose is to hold the page title of the selected nav category.</span></span> <span data-ttu-id="a9293-149">ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。</span><span class="sxs-lookup"><span data-stu-id="a9293-149">The header is docked to the top of the page and acts as a scroll clipping point for the content area.</span></span>

<span data-ttu-id="a9293-150">NavigationView が最小モードの場合は、ヘッダーが表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9293-150">The header must be visible when NavigationView is in Minimal mode.</span></span> <span data-ttu-id="a9293-151">ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a9293-151">You may choose to hide the header in other modes, which are used on larger window widths.</span></span> <span data-ttu-id="a9293-152">これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="a9293-152">To do so, set the [AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) property to **false**.</span></span>

### <a name="content"></a><span data-ttu-id="a9293-153">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="a9293-153">Content</span></span>

<span data-ttu-id="a9293-154">コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-154">The content area is where most of the information for the selected nav category is displayed.</span></span> 

<span data-ttu-id="a9293-155">NavigationView が最小モードの場合はコンテンツ領域に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a9293-155">We recommend 12px margins for your content area when NavigationView is in Minimal mode and 24px margins otherwise.</span></span>

## <a name="navigationview-display-modes"></a><span data-ttu-id="a9293-156">NavigationView 表示モード</span><span class="sxs-lookup"><span data-stu-id="a9293-156">NavigationView display modes</span></span>
<span data-ttu-id="a9293-157">NavigationView ウィンドウは開いたり閉じたりすることができます。次の 3 つの表示モード オプションがあります。</span><span class="sxs-lookup"><span data-stu-id="a9293-157">The NavigationView pane can be open or closed, and has three display mode options:</span></span>
-  <span data-ttu-id="a9293-158">**最小**: ハンバーガー ボタンのみが固定され、必要に応じてウィンドウが表示されたり、非表示になったりします。</span><span class="sxs-lookup"><span data-stu-id="a9293-158">**Minimal** Only the hamburger button remains fixed while the pane shows and hides as needed.</span></span>
-  <span data-ttu-id="a9293-159">**コンパクト**: ウィンドウは細長い小片として常に表示され、このウィンドウは幅全体まで開くことができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-159">**Compact** The pane always shows as a narrow sliver which can be opened to full width.</span></span>
-  <span data-ttu-id="a9293-160">**展開**: ウィンドウはコンテンツと共に開いています。</span><span class="sxs-lookup"><span data-stu-id="a9293-160">**Expanded** The pane is open alongside the content.</span></span> <span data-ttu-id="a9293-161">ハンバーガー ボタンを使って閉じると、ウィンドウの幅が細長い小片になります。</span><span class="sxs-lookup"><span data-stu-id="a9293-161">When closed by activating the hamburger button, the pane's width becomes a narrow sliver.</span></span>

<span data-ttu-id="a9293-162">既定では、コントロールで利用できる画面領域の大きさに基づいて、システムによって最適な表示モードが自動的に選択されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-162">By default, the system automatically selects the optimal display mode based on the amount of screen space available to the control.</span></span> <span data-ttu-id="a9293-163">(この設定を[無効](#overriding-the-default-adaptive-behavior) にすることができます。)</span><span class="sxs-lookup"><span data-stu-id="a9293-163">(You can [override](#overriding-the-default-adaptive-behavior) this setting.)</span></span>

### <a name="minimal"></a><span data-ttu-id="a9293-164">最小</span><span class="sxs-lookup"><span data-stu-id="a9293-164">Minimal</span></span>

![閉じたウィンドウと開いたウィンドウを表示している、最小モードの NavigationView](images/navview_minimal.png)

-  <span data-ttu-id="a9293-166">閉じている場合、既定ではウィンドウが非表示になり、ナビゲーション ボタンのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-166">When closed, the pane is hidden by default, with only the nav button visible.</span></span>
-  <span data-ttu-id="a9293-167">画面領域を節約するオンデマンドのナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="a9293-167">Provides on-demand navigation that conserves screen real estate.</span></span> <span data-ttu-id="a9293-168">携帯電話やファブレット上のアプリに最適です。</span><span class="sxs-lookup"><span data-stu-id="a9293-168">Ideal for apps on phones and phablets.</span></span>
-  <span data-ttu-id="a9293-169">ナビゲーション ボタンを押すことでウィンドウが開閉します。ウィンドウは、ヘッダーおよびコンテンツ上でオーバーレイとして描画されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-169">Pressing the nav button opens and closes the pane, which draws as an overlay above the header and content.</span></span> <span data-ttu-id="a9293-170">コンテンツは再配置されません。</span><span class="sxs-lookup"><span data-stu-id="a9293-170">Content does not reflow.</span></span>
-  <span data-ttu-id="a9293-171">開いている場合、ウィンドウの表示は一時的なもので、選択したり、戻るボタンを押したり、ウィンドウの外側をタップしたりするなど、簡易非表示ジェスチャで閉じることができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-171">When open, the pane is transient and can be closed with a light dismiss gesture such as making a selection, pressing the back button, or tapping outside the pane.</span></span>
-  <span data-ttu-id="a9293-172">ウィンドウのオーバーレイが開いている場合は、選択した項目が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-172">The selected item becomes visible when the pane’s overlay opens.</span></span>
-  <span data-ttu-id="a9293-173">要件が満たされていると、開いているウィンドウの背景が[アプリ内アクリル](../style/acrylic.md#acrylic-blend-types)になります。</span><span class="sxs-lookup"><span data-stu-id="a9293-173">When requirements are met, the open pane’s background is [in-app acrylic](../style/acrylic.md#acrylic-blend-types).</span></span>
-  <span data-ttu-id="a9293-174">既定では、全体の幅が 640 ピクセル以下の場合、NavigationView は最小モードになります。</span><span class="sxs-lookup"><span data-stu-id="a9293-174">By default, NavigationView is in Minimal mode when its overall width is less than or equal to 640px.</span></span>

### <a name="compact"></a><span data-ttu-id="a9293-175">コンパクト</span><span class="sxs-lookup"><span data-stu-id="a9293-175">Compact</span></span>

![閉じたウィンドウと開いたウィンドウを表示している、コンパクト モードの NavigationView](images/navview_compact.png)

-  <span data-ttu-id="a9293-177">閉じている場合、アイコンとナビゲーション ボタンだけを表示した垂直方向のウィンドウの小片が表示されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-177">When closed, a vertical sliver of the pane showing only icons and the nav button is visible.</span></span>
-  <span data-ttu-id="a9293-178">わずかな画面領域を使用して、選択された場所を示します。</span><span class="sxs-lookup"><span data-stu-id="a9293-178">Provides some indication of the selected location while using a small amount of screen real estate.</span></span>
-  <span data-ttu-id="a9293-179">このモードは、タブレットや [10 フィート エクスペリエンス](../devices/designing-for-tv.md)などの普通サイズの画面に適しています。</span><span class="sxs-lookup"><span data-stu-id="a9293-179">This mode is better suited for medium screens like tablets and [10-foot experiences](../devices/designing-for-tv.md).</span></span>
-  <span data-ttu-id="a9293-180">ナビゲーション ボタンを押すことでウィンドウが開閉します。ウィンドウは、ヘッダーおよびコンテンツ上でオーバーレイとして描画されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-180">Pressing the nav button opens and closes the pane, which draws as an overlay above the header and content.</span></span> <span data-ttu-id="a9293-181">コンテンツは再配置されません。</span><span class="sxs-lookup"><span data-stu-id="a9293-181">Content does not reflow.</span></span>
-  <span data-ttu-id="a9293-182">ヘッダーは必須ではなく、非表示にしてコンテンツの垂直方向の領域を広げることができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-182">The Header is not required and can be hidden to give Content more vertical space.</span></span>
-  <span data-ttu-id="a9293-183">選択した項目に視覚インジゲータが表示され、ナビゲーション ツリー内のユーザーの位置が強調されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-183">The selected item shows a visual indicator to highlight where the user is in the navigation tree.</span></span>
-  <span data-ttu-id="a9293-184">要件が満たされていると、ウィンドウの背景が[アプリ内アクリル](../style/acrylic.md#acrylic-blend-types)になります。</span><span class="sxs-lookup"><span data-stu-id="a9293-184">When requirements are met, the pane’s background is [in-app acrylic](../style/acrylic.md#acrylic-blend-types).</span></span>
-  <span data-ttu-id="a9293-185">既定では、全体の幅が 641 ～ 1007 ピクセルの場合、NavigationView はコンパクト モードになります。</span><span class="sxs-lookup"><span data-stu-id="a9293-185">By default, NavigationView is in Compact mode when its overall width is between 641px and 1007px.</span></span>

### <a name="expanded"></a><span data-ttu-id="a9293-186">展開</span><span class="sxs-lookup"><span data-stu-id="a9293-186">Expanded</span></span>

![開いているウィンドウを表示している、展開モードの NavigationView](images/navview_expanded.png)

-  <span data-ttu-id="a9293-188">既定では、ウィンドウは開いたままです。</span><span class="sxs-lookup"><span data-stu-id="a9293-188">By default, the pane remains open.</span></span> <span data-ttu-id="a9293-189">このモードは、大きな画面に適しています。</span><span class="sxs-lookup"><span data-stu-id="a9293-189">This mode is better suited for larger screens.</span></span>
-  <span data-ttu-id="a9293-190">ウィンドウと、ヘッダーおよびコンテンツが左右に並べて描画され、利用可能な領域内でコンテンツが再配置されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-190">The pane draws side-by-side with the header and content, which reflows within its available space.</span></span>
-  <span data-ttu-id="a9293-191">ナビゲーション ボタンを使用してウィンドウを閉じると、ウィンドウはヘッダーとコンテンツと並んで細長い小片として表示されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-191">When the pane is closed using the nav button, the pane shows as a narrow sliver side-by-side with the header and content.</span></span>
-  <span data-ttu-id="a9293-192">ヘッダーは必須ではなく、非表示にしてコンテンツの垂直方向の領域を広げることができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-192">The Header is not required and can be hidden to give Content more vertical space.</span></span>
-  <span data-ttu-id="a9293-193">選択した項目に視覚インジゲータが表示され、ナビゲーション ツリー内のユーザーの位置が強調されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-193">The selected item shows a visual indicator to highlight where the user is in the navigation tree.</span></span>
-  <span data-ttu-id="a9293-194">要件が満たされている場合は、ウィンドウの背景が[背景アクリル](../style/acrylic.md#acrylic-blend-types)を使って描画されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-194">When requirements are met, the pane’s background is painted using [background acrylic](../style/acrylic.md#acrylic-blend-types).</span></span>
-  <span data-ttu-id="a9293-195">既定では、全体の幅が 1007 ピクセルを超える場合、NavigationView は展開モードになります。</span><span class="sxs-lookup"><span data-stu-id="a9293-195">By default, NavigationView is in Expanded mode when its overall width is greater than 1007px.</span></span>

### <a name="overriding-the-default-adaptive-behavior"></a><span data-ttu-id="a9293-196">既定のアダプティブ動作のオーバーライド</span><span class="sxs-lookup"><span data-stu-id="a9293-196">Overriding the default adaptive behavior</span></span>

<span data-ttu-id="a9293-197">NavigationView は、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。</span><span class="sxs-lookup"><span data-stu-id="a9293-197">NavigationView automatically changes its display mode based on the amount of screen space available to it.</span></span>

> [!NOTE]
> <span data-ttu-id="a9293-198">NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="a9293-198">NavigationView should serve as the root container of your app, as this control is designed to span the full width and height of the app window.</span></span>
<span data-ttu-id="a9293-199">その動作を変更する必要がある場合は、[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) プロパティと [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) プロパティを使用して、ナビゲーション ビューで表示モードが変わる幅をオーバーライドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="a9293-199">You can override the widths at which the navigation view changes display modes by using the [CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) and [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) properties.</span></span>

<span data-ttu-id="a9293-200">表示モードの動作をカスタマイズする場合を示した次のシナリオを考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="a9293-200">Consider the following scenarios that illustrate when you might want to customize the display mode behavior.</span></span>

- <span data-ttu-id="a9293-201">**移動が頻繁**: ユーザーがアプリ領域間を多少頻繁に移動することが予想される場合は、ウィンドウ幅を狭くしたウィンドウを表示し続けることを検討します。</span><span class="sxs-lookup"><span data-stu-id="a9293-201">**Frequent navigation** If you expect users to navigate between app areas somewhat frequently, consider keeping the pane in view at narrower window widths.</span></span> <span data-ttu-id="a9293-202">曲、アルバム、およびアーティストのナビゲーション領域がある音楽アプリでは、280 ピクセルのウィンドウ幅を選び、アプリ ウィンドウの幅が 560 ピクセルよりも広い場合に展開モードを維持することができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-202">A music app with Songs / Albums / Artists navigation areas may opt for a 280px pane width and remain in Expanded mode while the app window is wider than 560px.</span></span>
```xaml
<NavigationView OpenPaneLength="280" CompactModeThresholdWidth="560" ExpandedModeThresholdWidth="560"/>
```

- <span data-ttu-id="a9293-203">**移動がほとんどない** ユーザーがアプリ領域間をほとんど移動しないことが予想されるなら、ウィンドウ幅が広がってもウィンドウの非表示を維持することを検討します。</span><span class="sxs-lookup"><span data-stu-id="a9293-203">**Rare navigation** If you expect users to navigate between app areas very infrequently, consider keeping the pane hidden at wider window widths.</span></span> <span data-ttu-id="a9293-204">複数のレイアウトを使用する電卓アプリでは、1080p ディスプレイでアプリが最大化されている場合でも、最小モードを維持できます。</span><span class="sxs-lookup"><span data-stu-id="a9293-204">A calculator app with multiple layouts may opt to remain in Minimal mode even when the app is maximized on a 1080p display.</span></span>
```xaml
<NavigationView CompactModeThresholdWidth="1920" ExpandedModeThresholdWidth="1920"/>
```

- <span data-ttu-id="a9293-205">**アイコンの不明瞭解消** アプリのナビゲーション領域が、わかりやすいアイコンに向いていない場合は、コンパクトモードの使用を避けます。</span><span class="sxs-lookup"><span data-stu-id="a9293-205">**Icon disambiguation** If your app’s navigation areas don’t lend themselves to meaningful icons, avoid using Compact mode.</span></span> <span data-ttu-id="a9293-206">コレクション、アルバム、およびフォルダーのナビゲーション領域のある画像表示アプリでは、幅が狭いときや中間のときは NavigationView を最小モードで表示し、幅が広いときは展開モードで表示することができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-206">An image viewing app with Collections / Albums / Folders navigation areas may opt for showing NavigationView in Minimal mode at narrow and medium widths, and in Expanded mode at wide width.</span></span>
```xaml
<NavigationView CompactModeThresholdWidth="1008"/>
```

## <a name="interaction"></a><span data-ttu-id="a9293-207">操作</span><span class="sxs-lookup"><span data-stu-id="a9293-207">Interaction</span></span>

<span data-ttu-id="a9293-208">ウィンドウのナビゲーション項目をユーザーがタップすると、選択された項目が NavigationView によって表示されて、[ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="a9293-208">When users tap on a navigation item in the Pane, NavigationView will show that item as selected and will raise an [ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) event.</span></span> <span data-ttu-id="a9293-209">タップにより新しいアイテムが選択されると、NavigationView でさらに [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="a9293-209">If the tap results in a new item being selected, NavigationView will also raise a [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) event.</span></span> 

<span data-ttu-id="a9293-210">アプリは、このユーザー操作に応じてヘッダーとコンテンツを適切な情報で更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9293-210">Your app is responsible for updating the Header and Content with appropriate information in response to this user interaction.</span></span> <span data-ttu-id="a9293-211">また、プログラムによってナビゲーション項目からコンテンツに[フォーカス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control.FocusState) を移動することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a9293-211">In addition, we recommend programmatically moving [focus](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.control.FocusState) from the navigation item to the content.</span></span> <span data-ttu-id="a9293-212">読み込み時に最初のフォーカスを設定することで、ユーザー フローが合理化され、予測されるキーボード フォーカスの移動回数が最小限に抑えられます。</span><span class="sxs-lookup"><span data-stu-id="a9293-212">By setting initial focus on load, you streamline the user flow and minimize the expected number of keyboard focus moves.</span></span>

## <a name="backwards-navigation"></a><span data-ttu-id="a9293-213">逆方向のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="a9293-213">Backwards navigation</span></span>
<span data-ttu-id="a9293-214">NavigationView には組み込みの [戻る] ボタンがあります。これは、次のプロパティで有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-214">NavigationView has a built-in back button, which can be enabled with the following properties:</span></span>
- <span data-ttu-id="a9293-215">[**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) は既定で NavigationViewBackButtonVisible 列挙と「自動」になっています。</span><span class="sxs-lookup"><span data-stu-id="a9293-215">[**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) is a NavigationViewBackButtonVisible enum and "Auto" by default.</span></span> <span data-ttu-id="a9293-216">[戻る] ボタンの表示/非表示を切り替えるために使用します。</span><span class="sxs-lookup"><span data-stu-id="a9293-216">It is used to show/hide the back button.</span></span> <span data-ttu-id="a9293-217">ボタンが表示されていない場合は、[戻る] ボタンを描画するための領域は折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="a9293-217">When the button is not visible, the space for drawing the back button will be collapsed.</span></span>
- <span data-ttu-id="a9293-218">[**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) は既定では false に設定されており、[戻る] ボタンの状態を切り替えるために使用できます。</span><span class="sxs-lookup"><span data-stu-id="a9293-218">[**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) is false by default and can be used to toggle the back button states.</span></span>
- <span data-ttu-id="a9293-219">[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) はユーザーが [戻る] ボタンをクリックした場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="a9293-219">[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) is fired when a user clicks on the back button.</span></span>
    - <span data-ttu-id="a9293-220">最小/コンパクト モードで NavigationView.Pane がポップアップとして開いているときに [戻る] ボタンをクリックすると、ウィンドウが閉じ、代わりに **PaneClosing** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="a9293-220">In Minimal/Compact mode, when the NavigationView.Pane is open as a flyout, clicking the back button will close the Pane and fire **PaneClosing** event instead.</span></span>
    - <span data-ttu-id="a9293-221">IsBackEnabled が false の場合は発生しません。</span><span class="sxs-lookup"><span data-stu-id="a9293-221">Not fired if IsBackEnabled is false.</span></span>

![NavigationView の [戻る] ボタン](../basics/images/back-nav/NavView.png)

## <a name="code-example"></a><span data-ttu-id="a9293-223">コードの例</span><span class="sxs-lookup"><span data-stu-id="a9293-223">Code example</span></span>

<span data-ttu-id="a9293-224">NavigationView をアプリに組み込む方法の簡単な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="a9293-224">The following is a simple example of how you can incorporate NavigationView into your app.</span></span> 

<span data-ttu-id="a9293-225">NavigationView の [戻る] ボタンを使用して前に戻る移動を実装する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="a9293-225">We demonstrate how to implement backwards navigation with NavigationView's back button.</span></span> <span data-ttu-id="a9293-226">NavigationView の "戻る" ナビゲーション プロパティを使用するには、[Windows 10 Insider Preview (導入された v10.0.17110.0)](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) が必要です。</span><span class="sxs-lookup"><span data-stu-id="a9293-226">Note that to use NavigationView's back navigation properties, you'll need the [Windows 10 Insider Preview (introduced v10.0.17110.0)](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK).</span></span>

<span data-ttu-id="a9293-227">`x:Uid` を使用してナビゲーション項目コンテンツ文字列のローカライズについても説明します。</span><span class="sxs-lookup"><span data-stu-id="a9293-227">We also demonstrate localization of nav item content strings with `x:Uid`.</span></span> <span data-ttu-id="a9293-228">ローカライズの使用について詳しくは、[UI 内の文字列のローカライズ](../../app-resources/localize-strings-ui-manifest.md)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9293-228">For more information on localization, see [Localize strings in your UI](../../app-resources/localize-strings-ui-manifest.md).</span></span>

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
                    Loaded="NavView_Loaded"
                    BackRequested="NavView_BackRequested">

        <NavigationView.MenuItems>
            <NavigationViewItem x:Uid="HomeNavItem" Content="Home" Tag="home">
                <NavigationViewItem.Icon>
                    <FontIcon Glyph="&#xE10F;"/>
                </NavigationViewItem.Icon>
            </NavigationViewItem>
            <NavigationViewItemSeparator/>
            <NavigationViewItemHeader Content="Main pages"/>
            <NavigationViewItem x:Uid="AppsNavItem" Icon="AllApps" Content="Apps" Tag="apps"/>
            <NavigationViewItem x:Uid="GamesNavItem" Icon="Video" Content="Games" Tag="games"/>
            <NavigationViewItem x:Uid="MusicNavItem" Icon="Audio" Content="Music" Tag="music"/>
        </NavigationView.MenuItems>

        <NavigationView.AutoSuggestBox>
            <AutoSuggestBox x:Name="ASB" QueryIcon="Find"/>
        </NavigationView.AutoSuggestBox>

        <NavigationView.HeaderTemplate>
            <DataTemplate>
                <Grid Margin="24,10,0,0">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Style="{StaticResource TitleTextBlockStyle}"
                           FontSize="28"
                           VerticalAlignment="Center"
                           Text="Welcome"/>
                    <CommandBar Grid.Column="1"
                            HorizontalAlignment="Right"
                            VerticalAlignment="Top"
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

        <Frame x:Name="ContentFrame" Margin="24">
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
    // you can also add items in code behind
    NavView.MenuItems.Add(new NavigationViewItemSeparator());
    NavView.MenuItems.Add(new NavigationViewItem()
    { Content = "My content", Icon = new SymbolIcon(Symbol.Folder), Tag = "content" });

    // set the initial SelectedItem 
    foreach (NavigationViewItemBase item in NavView.MenuItems)
    {
        if (item is NavigationViewItem && item.Tag.ToString() == "home")
        {
            NavView.SelectedItem = item;
            break;
        }
    }
            
    ContentFrame.Navigated += On_Navigated;

    // add keyboard accelerators for backwards navigation
    KeyboardAccelerator GoBack = new KeyboardAccelerator();
    GoBack.Key = VirtualKey.GoBack;
    GoBack.Invoked += BackInvoked;
    KeyboardAccelerator AltLeft = new KeyboardAccelerator();
    AltLeft.Key = VirtualKey.Left;
    AltLeft.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(GoBack);
    this.KeyboardAccelerators.Add(AltLeft);
    // ALT routes here
    AltLeft.Modifiers = VirtualKeyModifiers.Menu;
    
}

private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{  
    if (args.IsSettingsInvoked)
    {
        ContentFrame.Navigate(typeof(SettingsPage));
    }
    else
    {
        // find NavigationViewItem with Content that equals InvokedItem
        var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
        NavView_Navigate(item as NavigationViewItem);
    }
}

private void NavView_Navigate(NavigationViewItem item)
{
    switch (item.Tag)
    {
        case "home":
            ContentFrame.Navigate(typeof(HomePage));
            break;

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

private void NavView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
{
    On_BackRequested();
}

private void BackInvoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
{
    On_BackRequested();
    args.Handled = true;
}

private bool On_BackRequested()
{
    bool navigated = false;

    // don't go back if the nav pane is overlayed
    if (NavView.IsPaneOpen && (NavView.DisplayMode == NavigationViewDisplayMode.Compact || NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
    {
        return false;
    }
    else
    {
        if (ContentFrame.CanGoBack)
        {
            ContentFrame.GoBack();
            navigated = true;
        }
    }
    return navigated;
}

private void On_Navigated(object sender, NavigationEventArgs e)
{
    NavView.IsBackEnabled = ContentFrame.CanGoBack;

    if (ContentFrame.SourcePageType == typeof(SettingsPage))
    {
        NavView.SelectedItem = NavView.SettingsItem as NavigationViewItem;
    }
    else 
    {
        Dictionary<Type, string> lookup = new Dictionary<Type, string>()
        {
            {typeof(HomePage), "home"},
            {typeof(AppsPage), "apps"},
            {typeof(GamesPage), "games"},
            {typeof(MusicPage), "music"},
            {typeof(MyContentPage), "content"}    
        };

        String stringTag = lookup[ContentFrame.SourcePageType];

        // set the new SelectedItem  
        foreach (NavigationViewItemBase item in NavView.MenuItems)
        {
            if (item is NavigationViewItem && item.Tag.Equals(stringTag))
            {
                item.IsSelected = true;
                break;
            }
        }        
    }
}
```

## <a name="customizing-backgrounds"></a><span data-ttu-id="a9293-229">背景をカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="a9293-229">Customizing backgrounds</span></span>

<span data-ttu-id="a9293-230">NavigationView のメイン領域の背景を変更するには、その `Background` プロパティを目的のブラシに設定します。</span><span class="sxs-lookup"><span data-stu-id="a9293-230">To change the background of NavigationView's main area, set its `Background` property to your preferred brush.</span></span>

<span data-ttu-id="a9293-231">NavigationView が最小モードまたはコンパクト モードである場合、ウィンドウの背景にはアプリ内アクリルが表示され、展開モードのときには背景アクリルが表示されます。</span><span class="sxs-lookup"><span data-stu-id="a9293-231">The Pane's background shows in-app acrylic when NavigationView is in Minimal or Compact mode, and background acrylic in Expanded mode.</span></span> <span data-ttu-id="a9293-232">この動作を更新したり、ウィンドウのアクリルの外観をカスタマイズしたりするには、App.xaml で上書きすることで、2 つのテーマ リソースを変更します。</span><span class="sxs-lookup"><span data-stu-id="a9293-232">To update this behavior or customize the appearance of your Pane's acrylic, modify the two theme resources by overwriting them in your App.xaml.</span></span>

```xaml
<Application.Resources>
    <ResourceDictionary>
        <AcrylicBrush x:Key="NavigationViewDefaultPaneBackground"
        BackgroundSource="Backdrop" TintColor="Yellow" TintOpacity=".6"/>
        <AcrylicBrush x:Key="NavigationViewExpandedPaneBackground"
        BackgroundSource="HostBackdrop" TintColor="Orange" TintOpacity=".8"/>
    </ResourceDictionary>
</Application.Resources>
```

## <a name="extending-your-app-into-the-title-bar"></a><span data-ttu-id="a9293-233">アプリをタイトル バーに拡張する</span><span class="sxs-lookup"><span data-stu-id="a9293-233">Extending your app into the title bar</span></span>

<span data-ttu-id="a9293-234">アプリのウィンドウ内でシームレスで滑らかな表示を実現するには、NavigationView とそのアクリル ウィンドウをアプリのタイトル バー領域に拡張することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a9293-234">For a seamless, flowing look within your app's window, we recommend extending NavigationView and its acrylic pane up into your app's title bar area.</span></span> <span data-ttu-id="a9293-235">これにより、タイトル バー、単色の NavigationView コンテンツ、および NavigationView ウィンドウのアクリルで作成した図形が、視覚的に見栄えが悪くならないようにすることができます。</span><span class="sxs-lookup"><span data-stu-id="a9293-235">This avoids the visually unattractive shape created by the title bar, the solid-colored NavigationView Content, and the acrylic of NavigationView's pane.</span></span>

<span data-ttu-id="a9293-236">そのためには、次のコードを App.xaml.cs に追加します。</span><span class="sxs-lookup"><span data-stu-id="a9293-236">To do so, add the following code to your App.xaml.cs.</span></span>

```csharp
//draw into the title bar
var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
coreTitleBar.ExtendViewIntoTitleBar = true;

//remove the solid-colored backgrounds behind the caption controls and system back button
var viewTitleBar = ApplicationView.GetForCurrentView().TitleBar;
viewTitleBar.ButtonBackgroundColor = Colors.Transparent;
viewTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
viewTitleBar.ButtonForegroundColor = (Color)Resources["SystemBaseHighColor"];
```

<span data-ttu-id="a9293-237">タイトル バーへの描画には、アプリのタイトルを非表示にすることによる副作用です。</span><span class="sxs-lookup"><span data-stu-id="a9293-237">Drawing into the title bar has the side-effect of hiding your app's title.</span></span> <span data-ttu-id="a9293-238">ユーザーのため、独自の TextBlock を追加することでタイトルを復元します。</span><span class="sxs-lookup"><span data-stu-id="a9293-238">To help users, restore the title by adding your own TextBlock.</span></span> <span data-ttu-id="a9293-239">NavigationView が含まれているルート ページに次のマークアップを追加します。</span><span class="sxs-lookup"><span data-stu-id="a9293-239">Add the following markup to the root page containing your NavigationView.</span></span>

```xaml
<Grid>
    <TextBlock x:Name="AppTitle"
        xmlns:appmodel="using:Windows.ApplicationModel"
        Text="{x:Bind appmodel:Package.Current.DisplayName}"
        Style="{StaticResource CaptionTextBlockStyle}"
        IsHitTestVisible="False"
        Canvas.ZIndex="1"/>
    

    <NavigationView Canvas.ZIndex="0" ... />

</Grid>
```

<span data-ttu-id="a9293-240">また、[戻る] ボタンの可視性によっては AppTitle の余白を調整する必要もあります。</span><span class="sxs-lookup"><span data-stu-id="a9293-240">You'll also need to adjust AppTitle's margins depending on back button's visibility.</span></span> <span data-ttu-id="a9293-241">さらに、アプリが FullScreenMode になっている場合、TitleBar が領域を確保している場合でも、戻る矢印の間隔を削除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9293-241">And, when the app is in FullScreenMode, you'll need to remove the spacing for the back arrow, even if the TitleBar reserves space for it.</span></span>

```csharp
var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
Window.Current.SetTitleBar(AppTitle);
coreTitleBar.ExtendViewIntoTitleBar = true;

void UpdateAppTitle()
{
    var full = (ApplicationView.GetForCurrentView().IsFullScreenMode);
    var left = 12 + (full ? 0 : CoreApplication.GetCurrentView().TitleBar.SystemOverlayLeftInset);
    AppTitle.Margin = new Thickness(left, 8, 0, 0);
}

Window.Current.CoreWindow.SizeChanged += (s, e) => UpdateAppTitle();
coreTitleBar.LayoutMetricsChanged += (s, e) => UpdateAppTitle();
```

<span data-ttu-id="a9293-242">タイトル バーのカスタマイズの詳細については、[タイトル バーのカスタマイズ](../shell/title-bar.md) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9293-242">For more information about customizing title bars, see [title bar customization](../shell/title-bar.md).</span></span>

## <a name="related-topics"></a><span data-ttu-id="a9293-243">関連トピック</span><span class="sxs-lookup"><span data-stu-id="a9293-243">Related topics</span></span>

- [<span data-ttu-id="a9293-244">NavigationView クラス</span><span class="sxs-lookup"><span data-stu-id="a9293-244">NavigationView class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [<span data-ttu-id="a9293-245">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="a9293-245">Master/details</span></span>](master-details.md)
- [<span data-ttu-id="a9293-246">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="a9293-246">Pivot control</span></span>](tabs-pivot.md)
- [<span data-ttu-id="a9293-247">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="a9293-247">Navigation basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="a9293-248">UWP 用 Fluent Design の概要</span><span class="sxs-lookup"><span data-stu-id="a9293-248">Fluent Design for UWP overview</span></span>](../fluent-design-system/index.md)

