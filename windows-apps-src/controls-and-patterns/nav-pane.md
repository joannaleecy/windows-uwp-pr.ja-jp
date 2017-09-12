---
author: Jwmsft
redirect_url: https://msdn.microsoft.com/windows/uwp/controls-and-patterns/navigationview
Description: "トップ レベルのナビゲーションを提供して、画面領域を節約します。"
title: "ナビゲーション ウィンドウのガイドライン"
ms.assetid: 8FB52F5E-8E72-4604-9222-0B0EC6A97541
label: Nav pane
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
ms.openlocfilehash: d5c838675eb8cb568f0dabd1c6b776a8a53d3bf4
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="nav-panes"></a><span data-ttu-id="082b8-104">ナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="082b8-104">Nav panes</span></span>

<span data-ttu-id="082b8-105">この記事は、「[ナビゲーション ビュー](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/navigationview)」に移動されました。</span><span class="sxs-lookup"><span data-stu-id="082b8-105">This article has moved here: [Navigation view](https://msdn.microsoft.com/windows/uwp/controls-and-patterns/navigationview).</span></span>

<span data-ttu-id="082b8-106">ナビゲーション ウィンドウは、さまざまなトップ レベルのナビゲーション項目を使うことができるパターンです。これにより、画面領域を節約することができます。</span><span class="sxs-lookup"><span data-stu-id="082b8-106">A navigation pane (or just "nav" pane) is a pattern that allows for many top-level navigation items while conserving screen real estate.</span></span> <span data-ttu-id="082b8-107">ナビゲーション ウィンドウはモバイル アプリに広く使われていますが、大きい画面でも適切に機能します。</span><span class="sxs-lookup"><span data-stu-id="082b8-107">The nav pane is widely used for mobile apps, but also works well on larger screens.</span></span> <span data-ttu-id="082b8-108">オーバーレイとして使うと、ユーザーがボタンを押すまでウィンドウは折りたたまれたままで邪魔にならないため、小さい画面で便利です。</span><span class="sxs-lookup"><span data-stu-id="082b8-108">When used as an overlay, the pane remains collapsed and out-of-the way until the user presses the button, which is handy for smaller screens.</span></span> <span data-ttu-id="082b8-109">固定モードで使うと、ウィンドウは開いたままであるため、十分な画面領域がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="082b8-109">When used in its docked mode, the pane remains open, which allows greater utility if there's enough screen real estate.</span></span>

![ナビゲーション ウィンドウの例](images/navHero.png)


**<span data-ttu-id="082b8-111">重要な API</span><span class="sxs-lookup"><span data-stu-id="082b8-111">Important APIs</span></span>**

* [<span data-ttu-id="082b8-112">SplitView クラス</span><span class="sxs-lookup"><span data-stu-id="082b8-112">SplitView class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn864360)

## <a name="is-this-the-right-pattern"></a><span data-ttu-id="082b8-113">適切なパターンの選択</span><span class="sxs-lookup"><span data-stu-id="082b8-113">Is this the right pattern?</span></span>

<span data-ttu-id="082b8-114">ナビゲーション ウィンドウは、次の場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="082b8-114">The nav pane works well for:</span></span>

-   <span data-ttu-id="082b8-115">同じような種類のトップレベルのナビゲーション項目が多数あるアプリ。</span><span class="sxs-lookup"><span data-stu-id="082b8-115">Apps with many top-level navigation items that are of similar type.</span></span> <span data-ttu-id="082b8-116">たとえば、フットボール、野球、バスケットボール、サッカーといったカテゴリがあるスポーツ アプリなどです。</span><span class="sxs-lookup"><span data-stu-id="082b8-116">For example, a sports app with categories like Football, Baseball, Basketball, Soccer, and so on.</span></span>
-   <span data-ttu-id="082b8-117">アプリ間で一貫性のあるナビゲーション エクスペリエンスを提供する場合。</span><span class="sxs-lookup"><span data-stu-id="082b8-117">Providing a consistent navigational experience across apps.</span></span> <span data-ttu-id="082b8-118">ナビゲーション ウィンドウにはナビゲーション要素のみを含める必要があります。アクションは含めません。</span><span class="sxs-lookup"><span data-stu-id="082b8-118">Nav pane should include only navigational elements, not actions.</span></span>
-   <span data-ttu-id="082b8-119">トップレベルのナビゲーションのカテゴリの数が中程度から多い (5 ～ 10 以上) 場合。</span><span class="sxs-lookup"><span data-stu-id="082b8-119">A medium-to-high number (5-10+) of top-level navigational categories.</span></span>
-   <span data-ttu-id="082b8-120">画面領域を節約する場合 (オーバーレイとして)。</span><span class="sxs-lookup"><span data-stu-id="082b8-120">Preserving screen real estate (as an overlay).</span></span>
-   <span data-ttu-id="082b8-121">ナビゲーション項目のアクセス頻度が低い場合</span><span class="sxs-lookup"><span data-stu-id="082b8-121">Navigation items that are infrequently accessed.</span></span> <span data-ttu-id="082b8-122">(オーバーレイとして)。</span><span class="sxs-lookup"><span data-stu-id="082b8-122">(as an overlay).</span></span>

## <a name="building-a-nav-pane"></a><span data-ttu-id="082b8-123">ナビゲーション ウィンドウの構築</span><span class="sxs-lookup"><span data-stu-id="082b8-123">Building a nav pane</span></span>

<span data-ttu-id="082b8-124">ナビゲーション ウィンドウ パターンは、ナビゲーションのカテゴリ用のウィンドウ、コンテンツ領域、ウインドウを開閉するためのオプション ボタンで構成されます。</span><span class="sxs-lookup"><span data-stu-id="082b8-124">The nav pane pattern consists of a pane for navigation categories, a content area, and an optional button to open or close the pane.</span></span> <span data-ttu-id="082b8-125">ナビゲーション ウィンドウを構築する最も簡単な方法は、[分割ビュー コントロール](split-view.md)を使う方法です。このコントロールには、空のウィンドウとコンテンツ領域 (常に表示) が用意されています。</span><span class="sxs-lookup"><span data-stu-id="082b8-125">The easiest way to build a nav pane is with a [split view control](split-view.md), which comes with an empty pane and a content area that's always visible.</span></span>

<span data-ttu-id="082b8-126">このパターンのコードの実装をテストする場合は、GitHub から [XAML ナビゲーションのソリューション](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlNavigation)をダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="082b8-126">To try out code implementing this pattern, download the [XAML Navigation solution](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlNavigation) from GitHub.</span></span>


### <a name="pane"></a><span data-ttu-id="082b8-127">ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="082b8-127">Pane</span></span>

<span data-ttu-id="082b8-128">ナビゲーションのカテゴリのヘッダーがウィンドウに移動します。</span><span class="sxs-lookup"><span data-stu-id="082b8-128">Headers for navigational categories go in the pane.</span></span> <span data-ttu-id="082b8-129">アプリ設定とアカウント管理へのエントリ ポイント (該当する場合) もウィンドウに移動します。</span><span class="sxs-lookup"><span data-stu-id="082b8-129">Entry points to app settings and account management, if applicable, also go in the pane.</span></span> <span data-ttu-id="082b8-130">通常、ナビゲーションのヘッダーは項目の一覧で、そこからユーザーが選びます。</span><span class="sxs-lookup"><span data-stu-id="082b8-130">Navigation headers are usually a list of items for the user to choose from.</span></span>

![ナビゲーション ウィンドウのウィンドウの例](images/nav_pane_expanded.png)

### <a name="content-area"></a><span data-ttu-id="082b8-132">コンテンツ領域</span><span class="sxs-lookup"><span data-stu-id="082b8-132">Content area</span></span>

<span data-ttu-id="082b8-133">コンテンツ領域は、選んだナビゲーション位置の情報が表示される場所です。</span><span class="sxs-lookup"><span data-stu-id="082b8-133">The content area is where information for the selected nav location is displayed.</span></span> <span data-ttu-id="082b8-134">個々の要素やその他のサブレベル ナビゲーションを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="082b8-134">It can contain individual elements or other sub-level navigation.</span></span>

### <a name="button"></a><span data-ttu-id="082b8-135">ボタン</span><span class="sxs-lookup"><span data-stu-id="082b8-135">Button</span></span>

<span data-ttu-id="082b8-136">ボタンが表示されている場合、ユーザーはこのボタンでウィンドウを開閉できます。</span><span class="sxs-lookup"><span data-stu-id="082b8-136">When present, the button allows users to open and close the pane.</span></span> <span data-ttu-id="082b8-137">ボタンが表示される位置は固定で、ウィンドウと共に移動はしません。</span><span class="sxs-lookup"><span data-stu-id="082b8-137">The button remains visible in a fixed position and does not move with the pane.</span></span> <span data-ttu-id="082b8-138">ナビゲーション ウィンドウのボタンはアプリの左上隅に配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082b8-138">We recommend placing the button in the upper-left corner of your app.</span></span> <span data-ttu-id="082b8-139">ナビゲーション ウィンドウのボタンは積み重ねられた 3 本の横線として表示されます。このボタンは、一般的には "ハンバーガー" ボタンと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="082b8-139">The nav pane button is visualized as three stacked horizontal lines and is commonly referred to as the "hamburger" button.</span></span>

![ナビゲーション ウィンドウ ボタンの例](images/nav_button.png)

<span data-ttu-id="082b8-141">通常、ナビゲーション ウィンドウのボタンはテキスト文字列に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="082b8-141">The button is usually associated with a text string.</span></span> <span data-ttu-id="082b8-142">アプリの最上部では、ナビゲーション ウィンドウのボタンの横にアプリのタイトルを表示できます。</span><span class="sxs-lookup"><span data-stu-id="082b8-142">At the top level of the app, the app title can be displayed next to the button.</span></span> <span data-ttu-id="082b8-143">アプリの下部では、ユーザーが現在表示しているページのタイトルのテキスト文字列を表示できます。</span><span class="sxs-lookup"><span data-stu-id="082b8-143">At lower levels of the app, the text string may be the title of the page that the user is currently on.</span></span>

## <a name="nav-pane-variations"></a><span data-ttu-id="082b8-144">ナビゲーション ウィンドウのバリエーション</span><span class="sxs-lookup"><span data-stu-id="082b8-144">Nav pane variations</span></span>

<span data-ttu-id="082b8-145">ナビゲーション ウィンドウには、オーバーレイ、コンパクト、インラインの 3 つのモードがあります。</span><span class="sxs-lookup"><span data-stu-id="082b8-145">The nav pane has three modes: overlay, compact and inline.</span></span> <span data-ttu-id="082b8-146">オーバーレイは必要に応じて折りたたまれたり展開されたりします。</span><span class="sxs-lookup"><span data-stu-id="082b8-146">An overlay collapses and expands as needed.</span></span> <span data-ttu-id="082b8-147">コンパクトの場合は、ウィンドウは細長い小片として常に表示され、展開することもできます。</span><span class="sxs-lookup"><span data-stu-id="082b8-147">When compact, the pane always shows as a narrow sliver which can be expanded.</span></span> <span data-ttu-id="082b8-148">インライン ウィンドウは既定で開いたままです。</span><span class="sxs-lookup"><span data-stu-id="082b8-148">An inline pane remains open by default.</span></span>

### <a name="overlay"></a><span data-ttu-id="082b8-149">オーバーレイ</span><span class="sxs-lookup"><span data-stu-id="082b8-149">Overlay</span></span>

-   <span data-ttu-id="082b8-150">オーバーレイは、画面サイズに関係なく、縦方向でも横方向でも使うことができます。</span><span class="sxs-lookup"><span data-stu-id="082b8-150">An overlay can be used on any screen size and in either portrait or landscape orientation.</span></span> <span data-ttu-id="082b8-151">既定の (折りたたまれた) 状態では、オーバーレイは領域を消費せず、ボタンだけが表示されます。</span><span class="sxs-lookup"><span data-stu-id="082b8-151">In its default (collapsed) state, the overlay takes up no real-estate, with only the button shown.</span></span>
-   <span data-ttu-id="082b8-152">画面領域を節約するオンデマンドのナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="082b8-152">Provides on-demand navigation that conserves screen real estate.</span></span> <span data-ttu-id="082b8-153">携帯電話やファブレット上のアプリに最適です。</span><span class="sxs-lookup"><span data-stu-id="082b8-153">Ideal for apps on phones and phablets.</span></span>
-   <span data-ttu-id="082b8-154">ウィンドウは既定で非表示になり、ボタンだけが表示されます。</span><span class="sxs-lookup"><span data-stu-id="082b8-154">The pane is hidden by default, with only the button visible.</span></span>
-   <span data-ttu-id="082b8-155">ナビゲーション ウィンドウのボタンを押すと、オーバーレイの開閉を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="082b8-155">Pressing the nav pane button opens and closes the overlay.</span></span>
-   <span data-ttu-id="082b8-156">展開された状態は一時的なものであるため、選択が行った場合、[戻る] ボタンを使った場合、またはユーザーがウィンドウの外部でタップした場合に消滅します。</span><span class="sxs-lookup"><span data-stu-id="082b8-156">The expanded state is transient and is dismissed when a selection is made, when the back button is used, or when the user taps outside of the pane.</span></span>
-   <span data-ttu-id="082b8-157">オーバーレイは、コンテンツの上に描画されます。コンテンツを再配置するわけではありません。</span><span class="sxs-lookup"><span data-stu-id="082b8-157">The overlay draws over the top of content and does not reflow content.</span></span>

### <a name="compact"></a><span data-ttu-id="082b8-158">コンパクト</span><span class="sxs-lookup"><span data-stu-id="082b8-158">Compact</span></span>

-   <span data-ttu-id="082b8-159">コンパクト モードは、開いたときにコンテンツをオーバーレイする `CompactOverlay`、またはコンテンツを押し出す `CompactInline` として指定できます。</span><span class="sxs-lookup"><span data-stu-id="082b8-159">Compact mode can be specified as `CompactOverlay`, which overlays content when opened, or `CompactInline`, which pushes content out of its way.</span></span> <span data-ttu-id="082b8-160">CompactOverlay を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082b8-160">We recommend using CompactOverlay.</span></span>
-   <span data-ttu-id="082b8-161">コンパクト ウィンドウは、わずかな画面領域を使用して、選択された場所を示します。</span><span class="sxs-lookup"><span data-stu-id="082b8-161">Compact panes provide some indication of the selected location while using a small amount of screen real-estate.</span></span>
-   <span data-ttu-id="082b8-162">このモードは、タブレットなどの普通サイズの画面に適しています。</span><span class="sxs-lookup"><span data-stu-id="082b8-162">This mode is better suited for medium screens like tablets.</span></span>
-   <span data-ttu-id="082b8-163">既定では、ウィンドウは閉じていて、ナビゲーション アイコンとボタンのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="082b8-163">By default, the pane is closed with only navigation icons and the button visible.</span></span>
-   <span data-ttu-id="082b8-164">ナビゲーション ウィンドウのボタンを押すとウィンドウが開閉します。指定した表示モードに応じて、オーバーレイまたはインラインのように動作します。</span><span class="sxs-lookup"><span data-stu-id="082b8-164">Pressing the nav pane button opens and closes the pane, which behaves like overlay or inline depending on the specified display mode.</span></span>
-   <span data-ttu-id="082b8-165">ナビゲーション ツリーにおけるユーザーの位置を強調表示するため、選択内容を一覧のアイコンに表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="082b8-165">The selection should be shown on the list icons to highlight where the user is in the navigation tree.</span></span>

### <a name="inline"></a><span data-ttu-id="082b8-166">インライン</span><span class="sxs-lookup"><span data-stu-id="082b8-166">Inline</span></span>

-   <span data-ttu-id="082b8-167">ナビゲーション ウィンドウは開いたままです。</span><span class="sxs-lookup"><span data-stu-id="082b8-167">The navigation pane remains open.</span></span> <span data-ttu-id="082b8-168">このモードは、大きな画面に適しています。</span><span class="sxs-lookup"><span data-stu-id="082b8-168">This mode is better suited for larger screens.</span></span>
-   <span data-ttu-id="082b8-169">ウィンドウ間でのドラッグ アンド ドロップ シナリオがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="082b8-169">Supports drag-and-drop scenarios to and from the pane.</span></span>
-   <span data-ttu-id="082b8-170">ナビゲーション ウィンドウのボタンは、この状態には必要ありません。</span><span class="sxs-lookup"><span data-stu-id="082b8-170">The nav pane button is not required for this state.</span></span> <span data-ttu-id="082b8-171">ボタンを使った場合、コンテンツ領域が押し出され、その領域内のコンテンツが再配置されます。</span><span class="sxs-lookup"><span data-stu-id="082b8-171">If the button is used, then the content area is pushed out and the content within that area will reflow.</span></span>
-   <span data-ttu-id="082b8-172">ナビゲーション ツリーにおけるユーザーの位置を強調表示するため、選択内容を一覧の項目に表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="082b8-172">The selection should be shown on the list items to highlight where the user is in the navigation tree.</span></span>

## <a name="adaptability"></a><span data-ttu-id="082b8-173">適応性</span><span class="sxs-lookup"><span data-stu-id="082b8-173">Adaptability</span></span>

<span data-ttu-id="082b8-174">さまざまなデバイスでの操作性を最大限に高めるため、[ブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を利用し、アプリ ウィンドウの幅に基づいてナビゲーション ウィンドウのモードを調整することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="082b8-174">To maximize usability on a variety of devices, we recommend utilizing [break points](../layout/screen-sizes-and-breakpoints-for-responsive-design.md) and adjusting nav pane's mode based on the width of its app window.</span></span>
-   <span data-ttu-id="082b8-175">小さいウィンドウ</span><span class="sxs-lookup"><span data-stu-id="082b8-175">Small window</span></span>
   -   <span data-ttu-id="082b8-176">幅が 640 px 以下の場合。</span><span class="sxs-lookup"><span data-stu-id="082b8-176">Less than or equal to 640px wide.</span></span>
   -   <span data-ttu-id="082b8-177">ナビゲーション ウィンドウはオーバーレイ モードで、既定では閉じている必要があります。</span><span class="sxs-lookup"><span data-stu-id="082b8-177">Nav pane should be in overlay mode, closed by default.</span></span>
-   <span data-ttu-id="082b8-178">普通サイズのウィンドウ</span><span class="sxs-lookup"><span data-stu-id="082b8-178">Medium window</span></span>
   -   <span data-ttu-id="082b8-179">幅が 640 px よりも大きく、1007 px 以下である場合。</span><span class="sxs-lookup"><span data-stu-id="082b8-179">Greater than 640px and less than or equal to 1007px wide.</span></span>
   -   <span data-ttu-id="082b8-180">ナビゲーション ウィンドウは小片モードで、既定では閉じている必要があります。</span><span class="sxs-lookup"><span data-stu-id="082b8-180">Nav pane should be in sliver mode, closed by default.</span></span>
-   <span data-ttu-id="082b8-181">大きなウィンドウ</span><span class="sxs-lookup"><span data-stu-id="082b8-181">Large window</span></span>
   -   <span data-ttu-id="082b8-182">幅が 1007 px よりも大きい場合。</span><span class="sxs-lookup"><span data-stu-id="082b8-182">Greater than 1007px wide.</span></span>
   -   <span data-ttu-id="082b8-183">ナビゲーション ウィンドウは固定モードで、既定では開いている必要があります。</span><span class="sxs-lookup"><span data-stu-id="082b8-183">Nav pane should be in docked mode, opened by default.</span></span>

## <a name="tailoring"></a><span data-ttu-id="082b8-184">調整</span><span class="sxs-lookup"><span data-stu-id="082b8-184">Tailoring</span></span>

<span data-ttu-id="082b8-185">アプリの [10 フィート エクスペリエンス](http://go.microsoft.com/fwlink/?LinkId=760736)を最適化するには、ナビゲーション要素の外観を変更してナビゲーション ウィンドウを調整することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="082b8-185">To optimize your app's [10ft experience](http://go.microsoft.com/fwlink/?LinkId=760736), consider tailoring nav pane by altering the visual appearance of its navigational elements.</span></span> <span data-ttu-id="082b8-186">操作のコンテキストによっては、選択されているナビゲーション項目やフォーカスされているナビゲーション項目にユーザーの注意を引きつけることがより重要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="082b8-186">Depending on the interaction context, it may be more important to call the user's attention to either the selected nav item or to the focused nav item.</span></span> <span data-ttu-id="082b8-187">10 フィート エクスペリエンスの場合は、ゲームパッドが最も一般的な入力デバイスであり、画面上で現在フォーカスされている項目の場所をユーザーが容易に追跡できるようにすることが特に重要です。</span><span class="sxs-lookup"><span data-stu-id="082b8-187">For 10ft experience, where gamepad is the most common input device, ensuring that the user can easily keep track of the currently focused item's location on screen is particularly important.</span></span>

![ナビゲーション ウィンドウの項目のカスタマイズの例](images/nav_item_states.png)

## <a name="related-topics"></a><span data-ttu-id="082b8-189">関連トピック</span><span class="sxs-lookup"><span data-stu-id="082b8-189">Related topics</span></span>

* [<span data-ttu-id="082b8-190">分割ビュー コントロール</span><span class="sxs-lookup"><span data-stu-id="082b8-190">Split view control</span></span>](split-view.md)
* [<span data-ttu-id="082b8-191">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="082b8-191">Master/details</span></span>](master-details.md)
* [<span data-ttu-id="082b8-192">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="082b8-192">Navigation basics</span></span>](https://msdn.microsoft.com/library/windows/apps/dn958438)