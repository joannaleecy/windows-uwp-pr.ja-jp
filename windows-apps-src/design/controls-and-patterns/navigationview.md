---
Description: NavigationView は、アプリの最上位レベルのナビゲーション パターンを実装するアダプティブ コントロールです。
title: ナビゲーション ビュー
template: detail.hbs
ms.date: 10/02/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 4ba3a45701d82ad0b43591469bf390190ec18db0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57642227"
---
# <a name="navigation-view"></a><span data-ttu-id="f9c44-104">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="f9c44-104">Navigation view</span></span>

<span data-ttu-id="f9c44-105">NavigationView コントロールは、アプリの最上位レベルのナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-105">The NavigationView control provides top-level navigation for your app.</span></span> <span data-ttu-id="f9c44-106">両方をサポートし、さまざまな画面サイズに適応_上部_と_左_ナビゲーション スタイル。</span><span class="sxs-lookup"><span data-stu-id="f9c44-106">It adapts to a variety of screen sizes and supports both _top_ and _left_ navigation styles.</span></span>

<span data-ttu-id="f9c44-107">![上部のナビゲーション](images/nav-view-header.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-107">![top navigation](images/nav-view-header.png)</span></span><br/>
<span data-ttu-id="f9c44-108">_ナビゲーション ビューには、上部と左側のナビゲーション ウィンドウまたはメニューの両方がサポートしています_</span><span class="sxs-lookup"><span data-stu-id="f9c44-108">_Navigation view supports both top and left navigation pane or menu_</span></span>

> <span data-ttu-id="f9c44-109">**プラットフォーム Api**:[Windows.UI.Xaml.Controls.NavigationView クラス](/uwp/api/windows.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="f9c44-109">**Platform APIs**: [Windows.UI.Xaml.Controls.NavigationView class](/uwp/api/windows.ui.xaml.controls.navigationview)</span></span>
>
> <span data-ttu-id="f9c44-110">**Windows UI ライブラリ Api**:[Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="f9c44-110">**Windows UI Library APIs**: [Microsoft.UI.Xaml.Controls.NavigationView class](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span></span>
>
> <span data-ttu-id="f9c44-111">NavigationView の一部の機能など_上部_ナビゲーション、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-111">Some features of NavigationView, such as _top_ navigation, require Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="f9c44-112">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="f9c44-112">Is this the right control?</span></span>

<span data-ttu-id="f9c44-113">NavigationView は適しているアダプティブ ナビゲーション コントロールを示します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-113">NavigationView is an adaptive navigation control that works well for:</span></span>

- <span data-ttu-id="f9c44-114">アプリ全体で一貫性のあるナビゲーション エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-114">Providing a consistent navigational experience throughout your app.</span></span>
- <span data-ttu-id="f9c44-115">小さい windows の実際の画面を保持します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-115">Preserving screen real estate on smaller windows.</span></span>
- <span data-ttu-id="f9c44-116">多くのナビゲーション カテゴリへのアクセスを整理します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-116">Organizing access to many navigation categories.</span></span>

<span data-ttu-id="f9c44-117">その他のナビゲーション パターンを参照してください。[ナビゲーション設計の基本](../basics/navigation-basics.md)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-117">For other navigation patterns, see [Navigation design basics](../basics/navigation-basics.md).</span></span>

## <a name="examples"></a><span data-ttu-id="f9c44-118">例</span><span class="sxs-lookup"><span data-stu-id="f9c44-118">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="f9c44-119">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="f9c44-119">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/XAML-controls-gallery-app-icon.png" alt="XAML controls gallery" width="168"></img></td>
<td>
    <p><span data-ttu-id="f9c44-120"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">アプリを開き、NavigationView の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="f9c44-120">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/NavigationView">open the app and see the NavigationView in action</a>.</span></span></p>
    <ul>
    <li><span data-ttu-id="f9c44-121"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">XAML コントロール ギャラリー アプリ (Microsoft Store) を入手します。</a></span><span class="sxs-lookup"><span data-stu-id="f9c44-121"><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a></span></span></li>
    <li><span data-ttu-id="f9c44-122"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">ソース コード (GitHub) を取得します。</a></span><span class="sxs-lookup"><span data-stu-id="f9c44-122"><a href="https://github.com/Microsoft/Xaml-Controls-Gallery">Get the source code (GitHub)</a></span></span></li>
    </ul>
</td>
</tr>
</table>

## <a name="display-modes"></a><span data-ttu-id="f9c44-123">表示モード</span><span class="sxs-lookup"><span data-stu-id="f9c44-123">Display modes</span></span>

> <span data-ttu-id="f9c44-124">PaneDisplayMode プロパティには、Windows 10、バージョンは 1809 が必要です ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-124">The PaneDisplayMode property requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="f9c44-125">PaneDisplayMode プロパティを使用して、さまざまなナビゲーション スタイルを構成したり、NavigationView のモードを表示できます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-125">You can use the PaneDisplayMode property to configure different navigation styles, or display modes, for the NavigationView.</span></span>

:::row:::
    :::column:::
    ### <a name="top"></a><span data-ttu-id="f9c44-126">Top</span><span class="sxs-lookup"><span data-stu-id="f9c44-126">Top</span></span>
    <span data-ttu-id="f9c44-127">ウィンドウは、コンテンツ上に配置されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-127">The pane is positioned above the content.</span></span></br>
    `PaneDisplayMode="Top"`
    :::column-end:::
    :::column span="2":::
    ![上部のナビゲーションの例](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="f9c44-129">お勧め_上部_ナビゲーションとき。</span><span class="sxs-lookup"><span data-stu-id="f9c44-129">We recommend _top_ navigation when:</span></span>

- <span data-ttu-id="f9c44-130">5 または同様に重要な少なくの最上位レベルのナビゲーション カテゴリとカテゴリをドロップダウン リストのオーバーフロー メニューに最終的には重要度の低いと見なされます追加最上位レベルのナビゲーションであります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-130">You have 5 or fewer top-level navigation categories that are equally important, and any additional top-level navigation categories that end up in the dropdown overflow menu are considered less important.</span></span>
- <span data-ttu-id="f9c44-131">画面上のすべてのナビゲーション オプションを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-131">You need to show all navigation options on screen.</span></span>
- <span data-ttu-id="f9c44-132">アプリのコンテンツのスペースを追加するとします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-132">You want more space for your app content.</span></span>
- <span data-ttu-id="f9c44-133">アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。</span><span class="sxs-lookup"><span data-stu-id="f9c44-133">Icons cannot clearly describe your app's navigation categories.</span></span>

:::row:::
    :::column:::
    ### <a name="left"></a><span data-ttu-id="f9c44-134">Left</span><span class="sxs-lookup"><span data-stu-id="f9c44-134">Left</span></span>
    <span data-ttu-id="f9c44-135">ウィンドウが展開され、コンテンツの左に配置します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-135">The pane is expanded and positioned to the left of the content.</span></span></br>
    `PaneDisplayMode="Left"`
    :::column-end:::
    :::column span="2":::
    ![展開の左側のナビゲーション ウィンドウの例](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="f9c44-137">お勧め_左_ナビゲーションとき。</span><span class="sxs-lookup"><span data-stu-id="f9c44-137">We recommend _left_ navigation when:</span></span>

- <span data-ttu-id="f9c44-138">5 ~ 10 同じくらい重要な最上位レベルのナビゲーションのカテゴリがあります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-138">You have 5-10 equally important top-level navigation categories.</span></span>
- <span data-ttu-id="f9c44-139">ナビゲーション項目の他のアプリのコンテンツの領域が少なく、非常に目立つをします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-139">You want navigation categories to be very prominent, with less space for other app content.</span></span>

:::row:::
    :::column:::
    ### <a name="leftcompact"></a><span data-ttu-id="f9c44-140">LeftCompact</span><span class="sxs-lookup"><span data-stu-id="f9c44-140">LeftCompact</span></span>
    <span data-ttu-id="f9c44-141">ウィンドウには、開かれ、コンテンツの左側に配置されるまでにアイコンのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-141">The pane shows only icons until opened and is positioned to the left of the content.</span></span></br>
    `PaneDisplayMode="LeftCompact"`
    :::column-end:::
    :::column span="2":::
    ![Compact の左側のナビゲーション ウィンドウの例](images/displaymode-leftcompact.png)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
    ### <a name="leftminimal"></a><span data-ttu-id="f9c44-143">LeftMinimal</span><span class="sxs-lookup"><span data-stu-id="f9c44-143">LeftMinimal</span></span>
    <span data-ttu-id="f9c44-144">ウィンドウが開かれるまで、メニュー ボタンのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-144">Only the menu button is shown until the pane is opened.</span></span> <span data-ttu-id="f9c44-145">開かれると、コンテンツの左側に配置されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-145">When opened, it's positioned to the left of the content.</span></span></br>
    `PaneDisplayMode="LeftMinimal"`
    :::column-end:::
    :::column span="2":::
    ![最小限の左側のナビゲーション ウィンドウの例](images/displaymode-leftminimal.png)
    :::column-end:::
:::row-end:::

### <a name="auto"></a><span data-ttu-id="f9c44-147">Auto</span><span class="sxs-lookup"><span data-stu-id="f9c44-147">Auto</span></span>

<span data-ttu-id="f9c44-148">既定では、PaneDisplayMode が自動に設定されます。自動モードでは、ナビゲーション ビューは LeftMinimal、ウィンドウの幅が狭い LeftCompact、するときの間で適応し、左のウィンドウが広くなるよう。</span><span class="sxs-lookup"><span data-stu-id="f9c44-148">By default, PaneDisplayMode is set to Auto. In Auto mode, the navigation view adapts between LeftMinimal when the window is narrow, to LeftCompact, and then Left as the window gets wider.</span></span> <span data-ttu-id="f9c44-149">詳細については、次を参照してください。、[アダプティブ動作](#adaptive-behavior)セクション。</span><span class="sxs-lookup"><span data-stu-id="f9c44-149">For more info, see the [adaptive behavior](#adaptive-behavior) section.</span></span>

<span data-ttu-id="f9c44-150">![左側のナビゲーション アダプティブの既定の動作](images/displaymode-auto.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-150">![Left navigation default adaptive behavior](images/displaymode-auto.png)</span></span><br/>
<span data-ttu-id="f9c44-151">_ナビゲーション ビューの既定のアダプティブ動作_</span><span class="sxs-lookup"><span data-stu-id="f9c44-151">_Navigation view default adaptive behavior_</span></span>

## <a name="anatomy"></a><span data-ttu-id="f9c44-152">構造</span><span class="sxs-lookup"><span data-stu-id="f9c44-152">Anatomy</span></span>

<span data-ttu-id="f9c44-153">これらのイメージの表示ウィンドウで、ヘッダー、および構成されている場合、コントロールのコンテンツ領域のレイアウト_上部_または_左_ナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="f9c44-153">These images show the layout of the pane, header, and content areas of the control when configured for _top_ or _left_ navigation.</span></span>

<span data-ttu-id="f9c44-154">![上部のナビゲーション ビューのレイアウト](images/topnav-anatomy.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-154">![Top navigation view layout](images/topnav-anatomy.png)</span></span><br/>
<span data-ttu-id="f9c44-155">_上部のナビゲーション レイアウト_</span><span class="sxs-lookup"><span data-stu-id="f9c44-155">_Top navigation layout_</span></span>

<span data-ttu-id="f9c44-156">![左側のナビゲーション ビューのレイアウト](images/leftnav-anatomy.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-156">![Left navigation view layout](images/leftnav-anatomy.png)</span></span><br/>
<span data-ttu-id="f9c44-157">_左側のナビゲーション レイアウト_</span><span class="sxs-lookup"><span data-stu-id="f9c44-157">_Left navigation layout_</span></span>

### <a name="pane"></a><span data-ttu-id="f9c44-158">ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="f9c44-158">Pane</span></span>

<span data-ttu-id="f9c44-159">PaneDisplayMode プロパティを使用すると、コンテンツの上またはコンテンツの左側のウィンドウを移動します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-159">You can use the PaneDisplayMode property to position the pane above the content or to the left of the content.</span></span>

<span data-ttu-id="f9c44-160">NavigationView のペインに含めることができます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-160">The NavigationView pane can contain:</span></span>

- <span data-ttu-id="f9c44-161">[NavigationViewItem](/uwp/api/windows.ui.xaml.controls.navigationviewitem)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f9c44-161">[NavigationViewItem](/uwp/api/windows.ui.xaml.controls.navigationviewitem) objects.</span></span> <span data-ttu-id="f9c44-162">特定のページに移動するためのナビゲーション項目。</span><span class="sxs-lookup"><span data-stu-id="f9c44-162">Navigation items for navigating to specific pages.</span></span>
- <span data-ttu-id="f9c44-163">[NavigationViewItemSeparator](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f9c44-163">[NavigationViewItemSeparator](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator) objects.</span></span> <span data-ttu-id="f9c44-164">ナビゲーション項目をグループ化するための区切り記号。</span><span class="sxs-lookup"><span data-stu-id="f9c44-164">Separators for grouping navigation items.</span></span> <span data-ttu-id="f9c44-165">設定、[不透明度](/uwp/api/windows.ui.xaml.uielement.opacity)プロパティを空白として区切り記号を表示するために 0 にします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-165">Set the [Opacity](/uwp/api/windows.ui.xaml.uielement.opacity) property to 0 to render the separator as space.</span></span>
- <span data-ttu-id="f9c44-166">[NavigationViewItemHeader](/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f9c44-166">[NavigationViewItemHeader](/uwp/api/windows.ui.xaml.controls.navigationviewitemheader) objects.</span></span> <span data-ttu-id="f9c44-167">アイテムのグループのラベル付けのヘッダー。</span><span class="sxs-lookup"><span data-stu-id="f9c44-167">Headers for labeling groups of items.</span></span>
- <span data-ttu-id="f9c44-168">省略可能な[AutoSuggestBox](auto-suggest-box.md)アプリ レベルの検索を許可するコントロール。</span><span class="sxs-lookup"><span data-stu-id="f9c44-168">An optional [AutoSuggestBox](auto-suggest-box.md) control to allow for app-level search.</span></span> <span data-ttu-id="f9c44-169">コントロールを割り当てる、 [NavigationView.AutoSuggestBox](/uwp/api/windows.ui.xaml.controls.navigationview.autosuggestbox)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-169">Assign the control to the [NavigationView.AutoSuggestBox](/uwp/api/windows.ui.xaml.controls.navigationview.autosuggestbox) property.</span></span>
- <span data-ttu-id="f9c44-170">[アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)。</span><span class="sxs-lookup"><span data-stu-id="f9c44-170">An optional entry point for [app settings](../app-settings/app-settings-and-data.md).</span></span> <span data-ttu-id="f9c44-171">設定項目を非表示、 [IsSettingsVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを**false**します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-171">To hide the settings item, set the [IsSettingsVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible) property to **false**.</span></span>

<span data-ttu-id="f9c44-172">左側のウィンドウも含まれています。</span><span class="sxs-lookup"><span data-stu-id="f9c44-172">The left pane also contains:</span></span>

- <span data-ttu-id="f9c44-173">開き、終了、ウィンドウを切り替えるメニュー ボタン。</span><span class="sxs-lookup"><span data-stu-id="f9c44-173">A menu button to toggle the pane opened and closed.</span></span> <span data-ttu-id="f9c44-174">[IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-174">On larger app windows when the pane is open, you may choose to hide this button using the [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) property.</span></span>

<span data-ttu-id="f9c44-175">ナビゲーション ビューには、ウィンドウの左上隅に配置される戻るボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-175">The navigation view has a back button that is placed in the top left-hand corner of the pane.</span></span> <span data-ttu-id="f9c44-176">ただし、自動的に下位のナビゲーションを処理し、戻るスタックにコンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-176">However, it does not automatically handle backwards navigation and add content to the back stack.</span></span> <span data-ttu-id="f9c44-177">下位ナビゲーションを有効にするを参照してください、[下位ナビゲーション](#backwards-navigation)セクション。</span><span class="sxs-lookup"><span data-stu-id="f9c44-177">To enable backwards navigation, see the [backwards navigation](#backwards-navigation) section.</span></span>

<span data-ttu-id="f9c44-178">上および左のウィンドウの位置に対して詳細な ペインの構造を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-178">Here is the detailed pane anatomy for the top and left pane positions.</span></span>

#### <a name="top-navigation-pane"></a><span data-ttu-id="f9c44-179">上部のナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="f9c44-179">Top navigation pane</span></span>

![ナビゲーション ビューの上部ペインの構造](images/navview-pane-anatomy-horizontal.png)

1. <span data-ttu-id="f9c44-181">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9c44-181">Headers</span></span>
1. <span data-ttu-id="f9c44-182">ナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="f9c44-182">Navigation items</span></span>
1. <span data-ttu-id="f9c44-183">区切り記号</span><span class="sxs-lookup"><span data-stu-id="f9c44-183">Separators</span></span>
1. <span data-ttu-id="f9c44-184">AutoSuggestBox (省略可能)</span><span class="sxs-lookup"><span data-stu-id="f9c44-184">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="f9c44-185">(省略可能) の設定 ボタン</span><span class="sxs-lookup"><span data-stu-id="f9c44-185">Settings button (optional)</span></span>

#### <a name="left-navigation-pane"></a><span data-ttu-id="f9c44-186">左側のナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="f9c44-186">Left navigation pane</span></span>

![ナビゲーション ビューの左ペインの構造](images/navview-pane-anatomy-vertical.png)

1. <span data-ttu-id="f9c44-188">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="f9c44-188">Menu button</span></span>
1. <span data-ttu-id="f9c44-189">ナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="f9c44-189">Navigation items</span></span>
1. <span data-ttu-id="f9c44-190">区切り記号</span><span class="sxs-lookup"><span data-stu-id="f9c44-190">Separators</span></span>
1. <span data-ttu-id="f9c44-191">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9c44-191">Headers</span></span>
1. <span data-ttu-id="f9c44-192">AutoSuggestBox (省略可能)</span><span class="sxs-lookup"><span data-stu-id="f9c44-192">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="f9c44-193">(省略可能) の設定 ボタン</span><span class="sxs-lookup"><span data-stu-id="f9c44-193">Settings button (optional)</span></span>

#### <a name="pane-footer"></a><span data-ttu-id="f9c44-194">ウィンドウのフッター</span><span class="sxs-lookup"><span data-stu-id="f9c44-194">Pane footer</span></span>

<span data-ttu-id="f9c44-195">配置できる自由形式ペインのフッターにコンテンツに追加することによって、 [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-195">You can place free-form content in the pane's footer by adding it to the [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) property.</span></span>

:::row:::
    :::column:::
    <span data-ttu-id="f9c44-196">![ウィンドウ フッター top nav](images/navview-freeform-footer-top.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-196">![Pane footer top nav](images/navview-freeform-footer-top.png)</span></span><br>
     <span data-ttu-id="f9c44-197">_上部ペインのフッター_</span><span class="sxs-lookup"><span data-stu-id="f9c44-197">_Top pane footer_</span></span><br>
    :::column-end:::
    :::column:::
    <span data-ttu-id="f9c44-198">![ウィンドウ フッターの左側のナビゲーション](images/navview-freeform-footer-left.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-198">![Pane footer left nav](images/navview-freeform-footer-left.png)</span></span><br>
    <span data-ttu-id="f9c44-199">_左側のウィンドウのフッター_</span><span class="sxs-lookup"><span data-stu-id="f9c44-199">_Left pane footer_</span></span><br>
    :::column-end:::
:::row-end:::

#### <a name="pane-title-and-header"></a><span data-ttu-id="f9c44-200">ウィンドウのタイトルとヘッダー</span><span class="sxs-lookup"><span data-stu-id="f9c44-200">Pane title and header</span></span>

<span data-ttu-id="f9c44-201">ウィンドウのヘッダー領域のテキスト コンテンツを配置するには設定して、 [PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-201">You can place text content in the pane header area by setting the [PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle) property.</span></span> <span data-ttu-id="f9c44-202">文字列を受け取り、メニュー ボタンの横にあるテキストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-202">It takes a string and shows the text next to the menu button.</span></span>

<span data-ttu-id="f9c44-203">イメージやロゴなどの非テキスト コンテンツを追加することができますに配置する任意の要素のウィンドウのヘッダーに追加することによって、 [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-203">To add non-text content, such as an image or logo, you can place any element in the pane's header by adding it to the [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader) property.</span></span>

<span data-ttu-id="f9c44-204">PaneTitle と PaneHeader の両方は設定されている場合、メニュー ボタン、メニュー ボタンに最も近い PaneTitle の横にあるコンテンツが水平方向に積み上げ横します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-204">If both PaneTitle and PaneHeader are set, the content is stacked horizontally next to the menu button, with the PaneTitle closest to the menu button.</span></span>

:::row:::
    :::column:::
    <span data-ttu-id="f9c44-205">![ウィンドウのヘッダー top nav](images/navview-freeform-header-top.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-205">![Pane header top nav](images/navview-freeform-header-top.png)</span></span><br>
     <span data-ttu-id="f9c44-206">_上部のウィンドウのヘッダー_</span><span class="sxs-lookup"><span data-stu-id="f9c44-206">_Top pane header_</span></span><br>
    :::column-end:::
    :::column:::
    <span data-ttu-id="f9c44-207">![ウィンドウのヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-207">![Pane header left nav](images/navview-freeform-header-left.png)</span></span><br>
    <span data-ttu-id="f9c44-208">_左側のウィンドウのヘッダー_</span><span class="sxs-lookup"><span data-stu-id="f9c44-208">_Left pane header_</span></span><br>
    :::column-end:::
:::row-end:::

#### <a name="pane-content"></a><span data-ttu-id="f9c44-209">ウィンドウのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="f9c44-209">Pane content</span></span>

<span data-ttu-id="f9c44-210">配置できます自由形式ペインでコンテンツに追加することによって、 [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-210">You can place free-form content in the pane by adding it to the [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent) property.</span></span>

:::row:::
    :::column:::
    <span data-ttu-id="f9c44-211">![カスタム ウィンドウ コンテンツ top nav](images/navview-freeform-pane-top.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-211">![Pane custom content top nav](images/navview-freeform-pane-top.png)</span></span><br>
     <span data-ttu-id="f9c44-212">_上部のウィンドウのカスタム コンテンツ_</span><span class="sxs-lookup"><span data-stu-id="f9c44-212">_Top pane custom content_</span></span><br>
    :::column-end:::
    :::column:::
    <span data-ttu-id="f9c44-213">![左のナビゲーション ウィンドウのカスタム コンテンツ](images/navview-freeform-pane-left.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-213">![Pane custom content left nav](images/navview-freeform-pane-left.png)</span></span><br>
    <span data-ttu-id="f9c44-214">_左側のウィンドウのカスタム コンテンツ_</span><span class="sxs-lookup"><span data-stu-id="f9c44-214">_Left pane custom content_</span></span><br>
    :::column-end:::
:::row-end:::

### <a name="header"></a><span data-ttu-id="f9c44-215">Header</span><span class="sxs-lookup"><span data-stu-id="f9c44-215">Header</span></span>

<span data-ttu-id="f9c44-216">ページ タイトルを追加するには設定して、[ヘッダー](/uwp/api/windows.ui.xaml.controls.navigationview.header)プロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-216">You can add a page title by setting the [Header](/uwp/api/windows.ui.xaml.controls.navigationview.header) property.</span></span>

<span data-ttu-id="f9c44-217">![ナビゲーション ビューのヘッダー領域の例](images/nav-header.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-217">![Example of navigation view header area](images/nav-header.png)</span></span><br/>
<span data-ttu-id="f9c44-218">_ナビゲーション ビューのヘッダー_</span><span class="sxs-lookup"><span data-stu-id="f9c44-218">_Navigation view header_</span></span>

<span data-ttu-id="f9c44-219">ヘッダー領域は、ナビゲーション ボタンで、左側のウィンドウの位置に垂直方向に揃えて配置され、上部のウィンドウの位置にウィンドウの下にあります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-219">The header area is vertically aligned with the navigation button in the left pane position, and lies below the pane in the top pane position.</span></span> <span data-ttu-id="f9c44-220">52 の固定の高さがピクセルです。</span><span class="sxs-lookup"><span data-stu-id="f9c44-220">It has a fixed height of 52 px.</span></span> <span data-ttu-id="f9c44-221">これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。</span><span class="sxs-lookup"><span data-stu-id="f9c44-221">Its purpose is to hold the page title of the selected nav category.</span></span> <span data-ttu-id="f9c44-222">ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-222">The header is docked to the top of the page and acts as a scroll clipping point for the content area.</span></span>

<span data-ttu-id="f9c44-223">ヘッダーでは、NavigationView は最小限の表示モードで、いつでも表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-223">The header is visible any time the NavigationView is in Minimal display mode.</span></span> <span data-ttu-id="f9c44-224">ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-224">You may choose to hide the header in other modes, which are used on larger window widths.</span></span> <span data-ttu-id="f9c44-225">ヘッダーを非表示にするには設定、 [AlwaysShowHeader](/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader)プロパティを**false**します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-225">To hide the header, set the [AlwaysShowHeader](/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) property to **false**.</span></span>

### <a name="content"></a><span data-ttu-id="f9c44-226">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="f9c44-226">Content</span></span>

<span data-ttu-id="f9c44-227">![ナビゲーション ビューのコンテンツ領域の例](images/nav-content.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-227">![Example of navigation view content area](images/nav-content.png)</span></span><br/>
<span data-ttu-id="f9c44-228">_ナビゲーション ビューのコンテンツ_</span><span class="sxs-lookup"><span data-stu-id="f9c44-228">_Navigation view content_</span></span>

<span data-ttu-id="f9c44-229">コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-229">The content area is where most of the information for the selected nav category is displayed.</span></span>

<span data-ttu-id="f9c44-230">12 px の余白、コンテンツ エリアをお勧めときに、NavigationView は**最小限**モードと 24px 余白のそれ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="f9c44-230">We recommend 12px margins for your content area when NavigationView is in **Minimal** mode and 24px margins otherwise.</span></span>

## <a name="adaptive-behavior"></a><span data-ttu-id="f9c44-231">アダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="f9c44-231">Adaptive behavior</span></span>

<span data-ttu-id="f9c44-232">既定では、ナビゲーション ビューは自動的に使用可能な画面領域の量に基づくの表示モードを変更します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-232">By default, the navigation view automatically changes its display mode based on the amount of screen space available to it.</span></span> <span data-ttu-id="f9c44-233">[CompactModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.compactmodethresholdwidth)と[ExpandedModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.expandedmodethresholdwidth)プロパティが表示モードを変更するブレークポイントを指定します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-233">The [CompactModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.compactmodethresholdwidth) and [ExpandedModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.expandedmodethresholdwidth) properties specify the breakpoints at which the display mode changes.</span></span> <span data-ttu-id="f9c44-234">状況に応じたディスプレイのモードの動作をカスタマイズするこれらの値を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-234">You can modify these values to customize the adaptive display mode behavior.</span></span>

### <a name="default"></a><span data-ttu-id="f9c44-235">Default</span><span class="sxs-lookup"><span data-stu-id="f9c44-235">Default</span></span>

<span data-ttu-id="f9c44-236">既定値に PaneDisplayMode を設定すると**自動**、アダプティブの動作では説明します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-236">When PaneDisplayMode is set to its default value of **Auto**, the adaptive behavior is to show:</span></span>

- <span data-ttu-id="f9c44-237">大規模なウィンドウの幅で展開されている左側のウィンドウ (1008px 以上)。</span><span class="sxs-lookup"><span data-stu-id="f9c44-237">An expanded left pane on large window widths (1008px or greater).</span></span>
- <span data-ttu-id="f9c44-238">A アイコン専用のままにした中規模のウィンドウの幅でのナビゲーション ウィンドウ (LeftCompact) (641px 1007px に)。</span><span class="sxs-lookup"><span data-stu-id="f9c44-238">A left, icon-only, nav pane (LeftCompact) on medium window widths (641px to 1007px).</span></span>
- <span data-ttu-id="f9c44-239">メニュー ボタンしか (LeftMinimal) 小さいウィンドウの幅で (640 ピクセル以下)。</span><span class="sxs-lookup"><span data-stu-id="f9c44-239">Only a menu button (LeftMinimal) on small window widths (640px or less).</span></span>

<span data-ttu-id="f9c44-240">アダプティブの動作のウィンドウ サイズの詳細については、次を参照してください。[画面サイズやブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-240">For more information about window sizes for adaptive behavior, see [Screen sizes and breakpoints](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

<span data-ttu-id="f9c44-241">![左側のナビゲーション アダプティブの既定の動作](images/displaymode-auto.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-241">![Left navigation default adaptive behavior](images/displaymode-auto.png)</span></span><br/>
<span data-ttu-id="f9c44-242">_ナビゲーション ビューの既定のアダプティブ動作_</span><span class="sxs-lookup"><span data-stu-id="f9c44-242">_Navigation view default adaptive behavior_</span></span>

### <a name="minimal"></a><span data-ttu-id="f9c44-243">最小</span><span class="sxs-lookup"><span data-stu-id="f9c44-243">Minimal</span></span>

<span data-ttu-id="f9c44-244">2 つ目の一般的なアダプティブ パターンでは、大規模なウィンドウの幅、および両方の中規模の大小のウィンドウ幅でのメニュー ボタンのみで展開の左側のウィンドウを使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-244">A second common adaptive pattern is to use an expanded left pane on large window widths, and only a menu button on both medium and small window widths.</span></span>

<span data-ttu-id="f9c44-245">この場合にお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-245">We recommend this when:</span></span>

- <span data-ttu-id="f9c44-246">小さいウィンドウの幅でのアプリのコンテンツのスペースを追加するとします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-246">You want more space for app content on smaller window widths.</span></span>
- <span data-ttu-id="f9c44-247">ナビゲーションのカテゴリは、アイコンで明確に表すことができません。</span><span class="sxs-lookup"><span data-stu-id="f9c44-247">Your navigation categories cannot be clearly represented with icons.</span></span>

<span data-ttu-id="f9c44-248">![左側のナビゲーション最小限アダプティブの動作](images/adaptive-behavior-minimal.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-248">![Left navigation minimal adaptive behavior](images/adaptive-behavior-minimal.png)</span></span><br/>
<span data-ttu-id="f9c44-249">_ナビゲーション ビューの「最小」アダプティブ動作_</span><span class="sxs-lookup"><span data-stu-id="f9c44-249">_Navigation view "minimal" adaptive behavior_</span></span>

<span data-ttu-id="f9c44-250">この動作を構成するには、CompactModeThresholdWidth を折りたたむには、ウィンドウ幅に設定します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-250">To configure this behavior, set CompactModeThresholdWidth to the width at which you want the pane to collapse.</span></span> <span data-ttu-id="f9c44-251">ここでは、640 に 1007 の既定値から変更されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-251">Here, it's changed from the default of 640 to 1007.</span></span> <span data-ttu-id="f9c44-252">値が競合しないことを確認する ExpandedModeThresholdWidth を設定することも必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-252">You should also set ExpandedModeThresholdWidth to ensure the values don't conflict.</span></span>

```xaml
<NavigationView CompactModeThresholdWidth="1007" ExpandedModeThresholdWidth="1007"/>
```

### <a name="compact"></a><span data-ttu-id="f9c44-253">コンパクト</span><span class="sxs-lookup"><span data-stu-id="f9c44-253">Compact</span></span>

<span data-ttu-id="f9c44-254">3 番目の一般的なアダプティブ パターンでは、大規模なウィンドウの幅、および、LeftCompact、アイコンのみ、両方の中規模の大小のウィンドウ幅でのナビゲーション ウィンドウで展開されている左側のウィンドウを使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-254">A third common adaptive pattern is to use an expanded left pane on large window widths, and a LeftCompact, icon-only, nav pane on both medium and small window widths.</span></span>

<span data-ttu-id="f9c44-255">この場合にお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-255">We recommend this when:</span></span>

- <span data-ttu-id="f9c44-256">常に表示される画面上のすべてのナビゲーション オプションは重要です。</span><span class="sxs-lookup"><span data-stu-id="f9c44-256">It is important to always show all navigation options on screen.</span></span>
- <span data-ttu-id="f9c44-257">ナビゲーションのカテゴリは、アイコンで明確に表現できます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-257">Your navigation categories can be clearly represented with icons.</span></span>

<span data-ttu-id="f9c44-258">![左側のナビゲーションがアダプティブの動作を最適化します。](images/adaptive-behavior-compact.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-258">![Left navigation compact adaptive behavior](images/adaptive-behavior-compact.png)</span></span><br/>
<span data-ttu-id="f9c44-259">_ナビゲーション ビュー"compact"のアダプティブ動作_</span><span class="sxs-lookup"><span data-stu-id="f9c44-259">_Navigation view "compact" adaptive behavior_</span></span>

<span data-ttu-id="f9c44-260">この動作を構成するには、CompactModeThresholdWidth を 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-260">To configure this behavior, set CompactModeThresholdWidth to 0.</span></span>

```xaml
<NavigationView CompactModeThresholdWidth="0"/>
```

### <a name="no-adaptive-behavior"></a><span data-ttu-id="f9c44-261">アダプティブ動作はありません。</span><span class="sxs-lookup"><span data-stu-id="f9c44-261">No adaptive behavior</span></span>

<span data-ttu-id="f9c44-262">自動アダプティブの動作を無効にするには、自動以外の値に PaneDisplayMode を設定します。ここでは、設定されているウィンドウの幅に関係なく、LeftMinimal にメニュー ボタンのみが示すようにします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-262">To disable the automatic adaptive behavior, set PaneDisplayMode to a value other than Auto. Here, it's set to LeftMinimal, so only the menu button is shown regardless of the window width.</span></span>

<span data-ttu-id="f9c44-263">![左側のナビゲーション アダプティブ動作はありません。](images/adaptive-behavior-none.png)</span><span class="sxs-lookup"><span data-stu-id="f9c44-263">![Left navigation no adaptive behavior](images/adaptive-behavior-none.png)</span></span><br/>
<span data-ttu-id="f9c44-264">_ナビゲーション ビュー PaneDisplayMode LeftMinimal に設定_</span><span class="sxs-lookup"><span data-stu-id="f9c44-264">_Navigation view with PaneDisplayMode set to LeftMinimal_</span></span>

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

<span data-ttu-id="f9c44-265">既に説明したように、_表示モード_ セクションで、常に展開されている、常にコンパクトまたは常に最低限の上部を常にウィンドウを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-265">As described previously in the _Display modes_ section, you can set the pane to be always on top, always expanded, always compact, or always minimal.</span></span> <span data-ttu-id="f9c44-266">管理することも、表示モード自分でアプリ コード。</span><span class="sxs-lookup"><span data-stu-id="f9c44-266">You can also manage the display modes yourself in your app code.</span></span> <span data-ttu-id="f9c44-267">この例は、次のセクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-267">An example of this is shown in the next section.</span></span>

### <a name="top-to-left-navigation"></a><span data-ttu-id="f9c44-268">上左のナビゲーションから</span><span class="sxs-lookup"><span data-stu-id="f9c44-268">Top to left navigation</span></span>

<span data-ttu-id="f9c44-269">アプリの上部のナビゲーションを使用するとナビゲーション項目をウィンドウの幅が減少としてをオーバーフロー メニューに折りたたみます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-269">When you use top navigation in your app, navigation items collapse into an overflow menu as the window width decreases.</span></span> <span data-ttu-id="f9c44-270">アプリのウィンドウが狭いときにすべての項目をオーバーフロー メニューに折りたたむことのではなく、LeftMinimal のナビゲーションに上から PaneDisplayMode を切り替える優れたユーザー エクスペリエンスを提供できます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-270">When your app window is narrow, it can provide a better user experience to switch the PaneDisplayMode from Top to LeftMinimal navigation, rather than letting all the items collapse into the overflow menu.</span></span>

<span data-ttu-id="f9c44-271">大きなウィンドウ サイズと小さな左側のナビゲーションの上部のナビゲーションを使用することをお勧めします。 ときにウィンドウのサイズを設定します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-271">We recommend using top navigation on large window sizes and left navigation on small window sizes when:</span></span>

- <span data-ttu-id="f9c44-272">等しく重要度を付けるの左側のナビゲーションを折りたたむ場合、このセット内の 1 つのカテゴリは、画面に収まらない、ように同時に、表示される均等に重要なナビゲーションを最上位カテゴリのセットがあります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-272">You have a set of equally important top-level navigation categories to be displayed together, such that if one category in this set doesn't fit on screen, you collapse to left navigation to give them equal importance.</span></span>
- <span data-ttu-id="f9c44-273">小さいウィンドウのサイズにできる限りはるかコンテンツ領域として保持します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-273">You wish to preserve as much content space as possible in small window sizes.</span></span>

<span data-ttu-id="f9c44-274">この例は、使用する方法を示します、 [VisualStateManager](/uwp/api/Windows.UI.Xaml.VisualStateManager)と[AdaptiveTrigger.MinWindowWidth](/uwp/api/windows.ui.xaml.adaptivetrigger.minwindowwidth)上部と LeftMinimal ナビゲーション間を切り替えるプロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-274">This example shows how to use a [VisualStateManager](/uwp/api/Windows.UI.Xaml.VisualStateManager) and [AdaptiveTrigger.MinWindowWidth](/uwp/api/windows.ui.xaml.adaptivetrigger.minwindowwidth) property to switch between Top and LeftMinimal navigation.</span></span>

![上または左アダプティブ動作 1 の例](images/navigation-top-to-left.png)

```xaml
<Grid >
    <NavigationView x:Name="NavigationViewControl" >
        <NavigationView.MenuItems>
            <NavigationViewItem Content="A" x:Name="A" />
            <NavigationViewItem Content="B" x:Name="B" />
            <NavigationViewItem Content="C" x:Name="C" />
        </NavigationView.MenuItems>
    </NavigationView>

    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState>
                <VisualState.StateTriggers>
                    <AdaptiveTrigger
                        MinWindowWidth="{x:Bind NavigationViewControl.CompactModeThresholdWidth}" />
                </VisualState.StateTriggers>

                <VisualState.Setters>
                    <Setter Target="NavigationViewControl.PaneDisplayMode" Value="Top"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>

```

> [!TIP]
> <span data-ttu-id="f9c44-276">AdaptiveTrigger.MinWindowWidth を使用する場合は、ウィンドウが指定した最小幅より広い表示状態がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-276">When you use AdaptiveTrigger.MinWindowWidth, the visual state is triggered when the window is wider than the specified minimum width.</span></span> <span data-ttu-id="f9c44-277">つまり、既定の XAML 定義の幅の狭いウィンドウ、VisualState ウィンドウが広くなるときに適用される変更を定義します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-277">This means the default XAML defines the narrow window, and the VisualState defines the modifications that are applied when the window gets wider.</span></span> <span data-ttu-id="f9c44-278">既定の PaneDisplayMode ナビゲーション ビューが自動的には、そのため場合ウィンドウの幅は CompactModeThresholdWidth、小さい LeftMinimal ナビゲーションが使用されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-278">The default PaneDisplayMode for the navigation view is Auto, so when the window width is less than or equal to CompactModeThresholdWidth, LeftMinimal navigation is used.</span></span> <span data-ttu-id="f9c44-279">ウィンドウが大きくし、VisualState には、既定値よりも優先されます上部のナビゲーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-279">When the window gets wider, the VisualState overrides the default, and Top navigation is used.</span></span>

## <a name="navigation"></a><span data-ttu-id="f9c44-280">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="f9c44-280">Navigation</span></span>

<span data-ttu-id="f9c44-281">ナビゲーション ビューでは、自動的にすべてのナビゲーションのタスクを実行しません。</span><span class="sxs-lookup"><span data-stu-id="f9c44-281">The navigation view doesn't perform any navigation tasks automatically.</span></span> <span data-ttu-id="f9c44-282">ナビゲーション ビューが選択されている項目を表示し、発生させます、ユーザーがナビゲーション項目をタップする、 [ItemInvoked](/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked)イベント。</span><span class="sxs-lookup"><span data-stu-id="f9c44-282">When the user taps on a navigation item, the navigation view shows that item as selected and raises an [ItemInvoked](/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) event.</span></span> <span data-ttu-id="f9c44-283">タップ結果が、新しい項目が選択されている場合、 [SelectionChanged](/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged)イベントも発生します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-283">If the tap results in a new item being selected, a [SelectionChanged](/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) event is also raised.</span></span>

<span data-ttu-id="f9c44-284">要求されたナビゲーションに関連するタスクを実行するのいずれかのイベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-284">You can handle either event to perform tasks related to the requested navigation.</span></span> <span data-ttu-id="f9c44-285">アプリの目的の動作に依存する 1 つを処理する必要がありますとします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-285">Which one you should handle depends on the behavior you want for your app.</span></span> <span data-ttu-id="f9c44-286">通常、要求されたページに移動し、これらのイベントへの応答でナビゲーション ビューのヘッダーを更新します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-286">Typically, you navigate to the requested page and update the navigation view header in response to these events.</span></span>

<span data-ttu-id="f9c44-287">**ItemInvoked**が既に選択されている場合でも、ユーザーが、ナビゲーション項目をタップするたびに発生です。</span><span class="sxs-lookup"><span data-stu-id="f9c44-287">**ItemInvoked** is raised any time the user taps a navigation item, even if it's already selected.</span></span> <span data-ttu-id="f9c44-288">(項目呼び出すこともできますと同等のマウス、キーボード、またはその他の入力を使用して操作します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-288">(The item can also be invoked with an equivalent action using mouse, keyboard, or other input.</span></span> <span data-ttu-id="f9c44-289">詳細については、次を参照してください[入力との相互作用](../input/index.md)。)。ItemInvoked ハンドラーで移動する場合は、既定では、ページが再読み込みされますと重複するエントリ、ナビゲーション スタックに追加されます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-289">For more info, see [Input and interactions](../input/index.md).) If you navigate in the ItemInvoked handler, by default, the page will be reloaded, and a duplicate entry is added to the navigation stack.</span></span> <span data-ttu-id="f9c44-290">項目が呼び出されたときに、移動する場合は、ページの再読み込みを禁止またはページが再読み込みされるときに、重複するエントリがナビゲーション バック スタックで作成しないことを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-290">If you navigate when an item is invoked, you should disallow reloading the page, or ensure that a duplicate entry is not created in the navigation backstack when the page is reloaded.</span></span> <span data-ttu-id="f9c44-291">(コード例を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="f9c44-291">(See code examples.)</span></span>

<span data-ttu-id="f9c44-292">**SelectionChanged**されていない、現在選択されている項目を呼び出すユーザーまたは選択した項目をプログラムで変更することで、発生することができます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-292">**SelectionChanged** can be raised by a user invoking an item that isn't currently selected, or by programmatically changing the selected item.</span></span> <span data-ttu-id="f9c44-293">ユーザーに項目が呼び出されるため、選択の変更が発生した場合、ItemInvoked イベントに最初に発生します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-293">If the selection change occurs because a user invoked an item, the ItemInvoked event occurs first.</span></span> <span data-ttu-id="f9c44-294">選択の変更がプログラムの場合は、ItemInvoked は発生しません。</span><span class="sxs-lookup"><span data-stu-id="f9c44-294">If the selection change is programmatic, ItemInvoked is not raised.</span></span>

### <a name="backwards-navigation"></a><span data-ttu-id="f9c44-295">逆方向のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="f9c44-295">Backwards navigation</span></span>

<span data-ttu-id="f9c44-296">NavigationView は組み込みの戻るボタン。ただし、"進む"ナビゲーションと同様には下位ナビゲーションを自動的に実行します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-296">NavigationView has a built-in back button; but, as with forward navigation, it doesn't perform backwards navigation automatically.</span></span> <span data-ttu-id="f9c44-297">ユーザーが、[戻る] ボタンをタップすると、 [BackRequested](/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested)イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-297">When the user taps the back button, the [BackRequested](/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) event is raised.</span></span> <span data-ttu-id="f9c44-298">旧バージョンとナビゲーションを実行するには、このイベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-298">You handle this event to perform backwards navigation.</span></span> <span data-ttu-id="f9c44-299">詳細情報とコード例については、次を参照してください。[ナビゲーション履歴内を後方に向かってとナビゲーション](../basics/navigation-history-and-backwards-navigation.md)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-299">For more info and code examples, see [Navigation history and backwards navigation](../basics/navigation-history-and-backwards-navigation.md).</span></span>

<span data-ttu-id="f9c44-300">最小限またはコンパクト モードでナビゲーション ビュー ウィンドウがフライアウトとして開きます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-300">In Minimal or Compact mode, the navigation view Pane is open as a flyout.</span></span> <span data-ttu-id="f9c44-301">ここでは、[戻る] ボタンをクリックするとはウィンドウを閉じるし、発生させる、 **PaneClosing**イベント代わりにします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-301">In this case, clicking the back button will close the Pane and raise the **PaneClosing** event instead.</span></span>

<span data-ttu-id="f9c44-302">非表示にするか、これらのプロパティを設定して、[戻る] ボタンを無効にします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-302">You can hide or disable the back button by setting these properties:</span></span>

- <span data-ttu-id="f9c44-303">[IsBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible): を表示し、[戻る] ボタンを非表示に使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-303">[IsBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible): use to show and hide the back button.</span></span> <span data-ttu-id="f9c44-304">このプロパティの値には、 [NavigationViewBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible)列挙体に設定されていると**自動**既定では。</span><span class="sxs-lookup"><span data-stu-id="f9c44-304">This property takes a value of the [NavigationViewBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible) enumeration, and is set to **Auto** by default.</span></span> <span data-ttu-id="f9c44-305">ボタンが折りたたまれているときに領域なし用に予約されてレイアウトにします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-305">When the button is collapsed, no space is reserved for it in the layout.</span></span>
- <span data-ttu-id="f9c44-306">[IsBackEnabled](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled): を使用して有効にする、または [戻る] ボタンを無効にします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-306">[IsBackEnabled](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled): use to enable or disable the back button.</span></span> <span data-ttu-id="f9c44-307">このプロパティをデータ バインドをできます、 [CanGoBack](/uwp/api/windows.ui.xaml.controls.frame.cangoback)ナビゲーション フレームのプロパティ。</span><span class="sxs-lookup"><span data-stu-id="f9c44-307">You can data bind this property to the [CanGoBack](/uwp/api/windows.ui.xaml.controls.frame.cangoback) property of your navigation frame.</span></span> <span data-ttu-id="f9c44-308">**BackRequested**場合は発生しません**IsBackEnabled**は**false**します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-308">**BackRequested** is not raised if **IsBackEnabled** is **false**.</span></span>

:::row:::
    :::column:::
        ![Navigation view back button in the left navigation pane](images/leftnav-back.png)<br/>
        _The back button in the left navigation pane_
    :::column-end:::
    :::column:::
        ![Navigation view back button in the top navigation pane](images/topnav-back.png)<br/>
        _The back button in the top navigation pane_
    :::column-end:::
:::row-end:::

## <a name="code-example"></a><span data-ttu-id="f9c44-309">コードの例</span><span class="sxs-lookup"><span data-stu-id="f9c44-309">Code example</span></span>

<span data-ttu-id="f9c44-310">この例では、大きなウィンドウ サイズで、上部のナビゲーション ウィンドウとサイズの小さいウィンドウの左側のナビゲーション ウィンドウの両方で NavigationView を使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-310">This example shows how you can use NavigationView with both a top navigation pane on large window sizes and a left navigation pane on small window sizes.</span></span> <span data-ttu-id="f9c44-311">削除することで左ナビゲーションに対応ができる、_上部_VisualStateManager でナビゲーション設定します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-311">It can be adapted to left-only navigation by removing the _top_ navigation settings in the VisualStateManager.</span></span>

<span data-ttu-id="f9c44-312">例では、多くの一般的なシナリオに対応するナビゲーション データを設定することをお勧めの方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-312">The example demonstrates a recommended way to set up navigation data that will work for many common scenarios.</span></span> <span data-ttu-id="f9c44-313">下位 NavigationView の戻るボタンとキーボード ナビゲーションを使用したナビゲーションを実装する方法も示します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-313">It also demonstrates how to implement backwards navigation with NavigationView's back button and keyboard navigation.</span></span>

<span data-ttu-id="f9c44-314">このコードでは、アプリがページに移動する次の名前が含まれていると想定します。_ホームページ_、 _AppsPage_、 _GamesPage_、 _MusicPage_、 _MyContentPage_、および_SettingsPage_.</span><span class="sxs-lookup"><span data-stu-id="f9c44-314">This code assumes that your app contains pages with the following names to navigate to: _HomePage_, _AppsPage_, _GamesPage_, _MusicPage_, _MyContentPage_, and _SettingsPage_.</span></span> <span data-ttu-id="f9c44-315">これらのページのコードは表示されません。</span><span class="sxs-lookup"><span data-stu-id="f9c44-315">Code for these pages is not shown.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f9c44-316">アプリのページに関する情報が格納されている、 [ValueTuple](https://docs.microsoft.com/dotnet/api/system.valuetuple)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-316">Information about the app's pages is stored in a [ValueTuple](https://docs.microsoft.com/dotnet/api/system.valuetuple).</span></span> <span data-ttu-id="f9c44-317">この構造体では、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要がありますが必要です。</span><span class="sxs-lookup"><span data-stu-id="f9c44-317">This struct requires that the minimum version for your app project must be SDK 17763 or greater.</span></span> <span data-ttu-id="f9c44-318">以前のバージョンの Windows 10 を対象に NavigationView の WinUI バージョンを使用する場合は、使用、 [System.ValueTuple NuGet パッケージ](https://www.nuget.org/packages/System.ValueTuple/)代わりにします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-318">If you use the WinUI version of NavigationView to target earlier versions of Windows 10, you can use the [System.ValueTuple NuGet package](https://www.nuget.org/packages/System.ValueTuple/) instead.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f9c44-319">このコードは、使用する方法を示します、 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)NavigationView のバージョン。</span><span class="sxs-lookup"><span data-stu-id="f9c44-319">This code shows how to use the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/) version of NavigationView.</span></span> <span data-ttu-id="f9c44-320">NavigationView のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-320">If you use the platform version of NavigationView instead, the minimum version for your app project must be SDK 17763 or greater.</span></span> <span data-ttu-id="f9c44-321">プラットフォームのバージョンを使用するすべての参照を削除`muxc:`します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-321">To use the platform version, remove all references to `muxc:`.</span></span>

```xaml
<!-- xmlns:muxc="using:Microsoft.UI.Xaml.Controls" -->
<Grid>
    <muxc:NavigationView x:Name="NavView"
                         Loaded="NavView_Loaded"
                         ItemInvoked="NavView_ItemInvoked"
                         BackRequested="NavView_BackRequested">
        <muxc:NavigationView.MenuItems>
            <muxc:NavigationViewItem Tag="home" Icon="Home" Content="Home"/>
            <muxc:NavigationViewItemSeparator/>
            <muxc:NavigationViewItemHeader x:Name="MainPagesHeader"
                                           Content="Main pages"/>
            <muxc:NavigationViewItem Tag="apps" Content="Apps">
                <muxc:NavigationViewItem.Icon>
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xEB3C;"/>
                </muxc:NavigationViewItem.Icon>
            </muxc:NavigationViewItem>
            <muxc:NavigationViewItem Tag="games" Content="Games">
                <muxc:NavigationViewItem.Icon>
                    <FontIcon FontFamily="Segoe MDL2 Assets" Glyph="&#xE7FC;"/>
                </muxc:NavigationViewItem.Icon>
            </muxc:NavigationViewItem>
            <muxc:NavigationViewItem Tag="music" Icon="Audio" Content="Music"/>
        </muxc:NavigationView.MenuItems>

        <muxc:NavigationView.AutoSuggestBox>
            <!-- See AutoSuggestBox documentation for
                 more info about how to implement search. -->
            <AutoSuggestBox x:Name="NavViewSearchBox" QueryIcon="Find"/>
        </muxc:NavigationView.AutoSuggestBox>

        <ScrollViewer>
            <Frame x:Name="ContentFrame" Padding="12,0,12,24" IsTabStop="True"
                   NavigationFailed="ContentFrame_NavigationFailed"/>
        </ScrollViewer>
    </muxc:NavigationView>

    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState>
                <VisualState.StateTriggers>
                    <AdaptiveTrigger
                        MinWindowWidth="{x:Bind NavView.CompactModeThresholdWidth}"/>
                </VisualState.StateTriggers>
                <VisualState.Setters>
                    <!-- Remove the next 3 lines for left-only navigation. -->
                    <Setter Target="NavView.PaneDisplayMode" Value="Top"/>
                    <Setter Target="NavViewSearchBox.Width" Value="200"/>
                    <Setter Target="MainPagesHeader.Visibility" Value="Collapsed"/>
                    <!-- Leave the next line for left-only navigation. -->
                    <Setter Target="ContentFrame.Padding" Value="24,0,24,24"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>
</Grid>
```

> [!IMPORTANT]
> <span data-ttu-id="f9c44-322">このコードは、使用する方法を示します、 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)NavigationView のバージョン。</span><span class="sxs-lookup"><span data-stu-id="f9c44-322">This code shows how to use the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/) version of NavigationView.</span></span> <span data-ttu-id="f9c44-323">NavigationView のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-323">If you use the platform version of NavigationView instead, the minimum version for your app project must be SDK 17763 or greater.</span></span> <span data-ttu-id="f9c44-324">プラットフォームのバージョンを使用するすべての参照を削除`muxc`します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-324">To use the platform version, remove all references to `muxc`.</span></span>

```csharp
// Add "using" for WinUI controls.
// using muxc = Microsoft.UI.Xaml.Controls;

private void ContentFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
{
    throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
}

// List of ValueTuple holding the Navigation Tag and the relative Navigation Page
private readonly List<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
{
    ("home", typeof(HomePage)),
    ("apps", typeof(AppsPage)),
    ("games", typeof(GamesPage)),
    ("music", typeof(MusicPage)),
};

private void NavView_Loaded(object sender, RoutedEventArgs e)
{
    // You can also add items in code.
    NavView.MenuItems.Add(new muxc.NavigationViewItemSeparator());
    NavView.MenuItems.Add(new muxc.NavigationViewItem
    {
        Content = "My content",
        Icon = new SymbolIcon((Symbol)0xF1AD),
        Tag = "content"
    });
    _pages.Add(("content", typeof(MyContentPage)));

    // Add handler for ContentFrame navigation.
    ContentFrame.Navigated += On_Navigated;

    // NavView doesn't load any page by default, so load home page.
    NavView.SelectedItem = NavView.MenuItems[0];
    // If navigation occurs on SelectionChanged, this isn't needed.
    // Because we use ItemInvoked to navigate, we need to call Navigate
    // here to load the home page.
    NavView_Navigate("home", new EntranceNavigationTransitionInfo());

    // Add keyboard accelerators for backwards navigation.
    var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
    goBack.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(goBack);

    // ALT routes here
    var altLeft = new KeyboardAccelerator
    {
        Key = VirtualKey.Left,
        Modifiers = VirtualKeyModifiers.Menu
    };
    altLeft.Invoked += BackInvoked;
    this.KeyboardAccelerators.Add(altLeft);
}

private void NavView_ItemInvoked(muxc.NavigationView sender,
                                 muxc.NavigationViewItemInvokedEventArgs args)
{
    if (args.IsSettingsInvoked == true)
    {
        NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
    }
    else if (args.InvokedItemContainer != null)
    {
        var navItemTag = args.InvokedItemContainer.Tag.ToString();
        NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
    }
}

<!-- NavView_SelectionChanged is not used in this example, but is shown for completeness.
     You will typically handle either ItemInvoked or SelectionChanged to perform navigation,
     but not both. -->
private void NavView_SelectionChanged(muxc.NavigationView sender,
                                      muxc.NavigationViewSelectionChangedEventArgs args)
{
    if (args.IsSettingsSelected == true)
    {
        NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
    }
    else if (args.SelectedItemContainer != null)
    {
        var navItemTag = args.SelectedItemContainer.Tag.ToString();
        NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
    }
}

private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
{
    Type _page = null;
    if (navItemTag == "settings")
    {
        _page = typeof(SettingsPage);
    }
    else
    {
        var item = _pages.FirstOrDefault(p => p.Tag.Equals(navItemTag));
        _page = item.Page;
    }
    // Get the page type before navigation so you can prevent duplicate
    // entries in the backstack.
    var preNavPageType = ContentFrame.CurrentSourcePageType;

    // Only navigate if the selected page isn't currently loaded.
    if (!(_page is null) && !Type.Equals(preNavPageType, _page))
    {
        ContentFrame.Navigate(_page, null, transitionInfo);
    }
}

private void NavView_BackRequested(muxc.NavigationView sender,
                                   muxc.NavigationViewBackRequestedEventArgs args)
{
    On_BackRequested();
}

private void BackInvoked(KeyboardAccelerator sender,
                         KeyboardAcceleratorInvokedEventArgs args)
{
    On_BackRequested();
    args.Handled = true;
}

private bool On_BackRequested()
{
    if (!ContentFrame.CanGoBack)
        return false;

    // Don't go back if the nav pane is overlayed.
    if (NavView.IsPaneOpen &&
        (NavView.DisplayMode == muxc.NavigationViewDisplayMode.Compact ||
         NavView.DisplayMode == muxc.NavigationViewDisplayMode.Minimal))
        return false;

    ContentFrame.GoBack();
    return true;
}

private void On_Navigated(object sender, NavigationEventArgs e)
{
    NavView.IsBackEnabled = ContentFrame.CanGoBack;

    if (ContentFrame.SourcePageType == typeof(SettingsPage))
    {
        // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
        NavView.SelectedItem = (muxc.NavigationViewItem)NavView.SettingsItem;
        NavView.Header = "Settings";
    }
    else if (ContentFrame.SourcePageType != null)
    {
        var item = _pages.FirstOrDefault(p => p.Page == e.SourcePageType);

        NavView.SelectedItem = NavView.MenuItems
            .OfType<muxc.NavigationViewItem>()
            .First(n => n.Tag.Equals(item.Tag));

        NavView.Header =
            ((muxc.NavigationViewItem)NavView.SelectedItem)?.Content?.ToString();
    }
}
```

<span data-ttu-id="f9c44-325">次に示します、 [C +/cli WinRT](/windows/uwp/cpp-and-winrt-apis/index)のバージョン、 **NavView_ItemInvoked**からハンドラー、C#上記のコード例です。</span><span class="sxs-lookup"><span data-stu-id="f9c44-325">Below is a [C++/WinRT](/windows/uwp/cpp-and-winrt-apis/index) version of the **NavView_ItemInvoked** handler from the C# code example above.</span></span> <span data-ttu-id="f9c44-326">手法 C +/cli WinRT ハンドラーでは、する必要があります最初に格納する (のタグで、 [ **NavigationViewItem**](/uwp/api/windows.ui.xaml.controls.navigationviewitem)) 移動するページの完全な型名。</span><span class="sxs-lookup"><span data-stu-id="f9c44-326">The technique in the C++/WinRT handler involves you first storing (in the tag of the [**NavigationViewItem**](/uwp/api/windows.ui.xaml.controls.navigationviewitem)) the full type name of the page to which you want to navigate.</span></span> <span data-ttu-id="f9c44-327">ハンドラーで、その値をボックス化解除になると、 [ **::interop::typename** ](/uwp/api/windows.ui.xaml.interop.typename)オブジェクト、および変換先のページに移動するに使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-327">In the handler, you unbox that value, turn it into a [**Windows::UI::Xaml::Interop::TypeName**](/uwp/api/windows.ui.xaml.interop.typename) object, and use that to navigate to the destination page.</span></span> <span data-ttu-id="f9c44-328">という名前のマッピングの変数の必要はありません`_pages`に表示される、C#の例の場合とは、タグの中の値は有効な型のことを確認する単体テストを作成することでしょう。</span><span class="sxs-lookup"><span data-stu-id="f9c44-328">There's no need for the mapping variable named `_pages` that you see in the C# example; and you'll be able to create unit tests confirming that the values inside your tags are of a valid type.</span></span> <span data-ttu-id="f9c44-329">参照してください[c++ IInspectable をボックス化とボックス化解除のスカラー値/cli WinRT](/windows/uwp/cpp-and-winrt-apis/boxing)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-329">Also see [Boxing and unboxing scalar values to IInspectable with C++/WinRT](/windows/uwp/cpp-and-winrt-apis/boxing).</span></span>

```cppwinrt
void MainPage::NavView_ItemInvoked(Windows::Foundation::IInspectable const & /* sender */, Windows::UI::Xaml::Controls::NavigationViewItemInvokedEventArgs const & args)
{
    if (args.IsSettingsInvoked())
    {
        // Navigate to Settings.
    }
    else if (args.InvokedItemContainer())
    {
        Windows::UI::Xaml::Interop::TypeName pageTypeName;
        pageTypeName.Name = unbox_value<hstring>(args.InvokedItemContainer().Tag());
        pageTypeName.Kind = Windows::UI::Xaml::Interop::TypeKind::Primitive;
        ContentFrame().Navigate(pageTypeName, nullptr);
    }
}
```

## <a name="navigation-view-customization"></a><span data-ttu-id="f9c44-330">ナビゲーション ビューのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="f9c44-330">Navigation view customization</span></span>

### <a name="pane-backgrounds"></a><span data-ttu-id="f9c44-331">ウィンドウの背景</span><span class="sxs-lookup"><span data-stu-id="f9c44-331">Pane Backgrounds</span></span>

<span data-ttu-id="f9c44-332">既定では、NavigationView のウィンドウは、表示モードによって異なる背景を使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-332">By default, the NavigationView pane uses a different background depending on the display mode:</span></span>

- <span data-ttu-id="f9c44-333">ペインは、solid グレー色 (左モード) のコンテンツと並行して、左側に展開するとします。</span><span class="sxs-lookup"><span data-stu-id="f9c44-333">the pane is a solid grey color when expanded on the left, side-by-side with the content (in Left mode).</span></span>
- <span data-ttu-id="f9c44-334">ウィンドウでは、(Top、最小、または Compact モード) でコンテンツの上にオーバーレイとして開いているときにアプリ内のアクリルを使用します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-334">the pane uses in-app acrylic when open as an overlay on top of content (in Top, Minimal, or Compact mode).</span></span>

<span data-ttu-id="f9c44-335">ウィンドウの背景を変更するには、各モードで背景の描画に使用される XAML テーマ リソースをオーバーライドできます。</span><span class="sxs-lookup"><span data-stu-id="f9c44-335">To modify the pane background, you can override the XAML theme resources used to render the background in each mode.</span></span> <span data-ttu-id="f9c44-336">(この手法は使用 PaneBackground プロパティを 1 つではなくさまざまな表示モードのさまざまな背景をサポートするために)。</span><span class="sxs-lookup"><span data-stu-id="f9c44-336">(This technique is used rather than a single PaneBackground property in order to support different backgrounds for different display modes.)</span></span>

<span data-ttu-id="f9c44-337">テーマ リソースが各表示モードで使用されるかを示します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-337">This table shows which theme resource is used in each display mode.</span></span>

| <span data-ttu-id="f9c44-338">表示モード</span><span class="sxs-lookup"><span data-stu-id="f9c44-338">Display mode</span></span> | <span data-ttu-id="f9c44-339">テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="f9c44-339">Theme resource</span></span> |
| ------------ | -------------- |
| <span data-ttu-id="f9c44-340">Left</span><span class="sxs-lookup"><span data-stu-id="f9c44-340">Left</span></span> | <span data-ttu-id="f9c44-341">NavigationViewExpandedPaneBackground</span><span class="sxs-lookup"><span data-stu-id="f9c44-341">NavigationViewExpandedPaneBackground</span></span> |
| <span data-ttu-id="f9c44-342">LeftCompact</span><span class="sxs-lookup"><span data-stu-id="f9c44-342">LeftCompact</span></span><br/><span data-ttu-id="f9c44-343">LeftMinimal</span><span class="sxs-lookup"><span data-stu-id="f9c44-343">LeftMinimal</span></span> | <span data-ttu-id="f9c44-344">NavigationViewDefaultPaneBackground</span><span class="sxs-lookup"><span data-stu-id="f9c44-344">NavigationViewDefaultPaneBackground</span></span> |
| <span data-ttu-id="f9c44-345">Top</span><span class="sxs-lookup"><span data-stu-id="f9c44-345">Top</span></span> | <span data-ttu-id="f9c44-346">NavigationViewTopPaneBackground</span><span class="sxs-lookup"><span data-stu-id="f9c44-346">NavigationViewTopPaneBackground</span></span> |

<span data-ttu-id="f9c44-347">この例では、App.xaml でテーマのリソースを上書きする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-347">This example shows how to override the theme resources in App.xaml.</span></span> <span data-ttu-id="f9c44-348">テーマのリソースを上書きするときにする必要があります常に少なくとも、"Default"、「ハイコントラスト」のリソース ディクショナリとディクショナリ「淡色」または「濃色」のリソースに応じて提供します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-348">When you override theme resources, you should always provide "Default" and "HighContrast" resource dictionaries at a minimum, and dictionaries for "Light" or "Dark" resources as needed.</span></span> <span data-ttu-id="f9c44-349">詳細については、次を参照してください。 [ResourceDictionary.ThemeDictionaries](/uwp/api/windows.ui.xaml.resourcedictionary.themedictionaries)します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-349">For more info, see [ResourceDictionary.ThemeDictionaries](/uwp/api/windows.ui.xaml.resourcedictionary.themedictionaries).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f9c44-350">このコードは、使用する方法を示します、 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)AcrylicBrush のバージョン。</span><span class="sxs-lookup"><span data-stu-id="f9c44-350">This code shows how to use the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/) version of AcrylicBrush.</span></span> <span data-ttu-id="f9c44-351">AcrylicBrush のプラットフォームのバージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは 16299 以上の SDK である必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9c44-351">If you use the platform version of AcrylicBrush instead, the minimum version for your app project must be SDK 16299 or greater.</span></span> <span data-ttu-id="f9c44-352">プラットフォームのバージョンを使用するすべての参照を削除`muxm:`します。</span><span class="sxs-lookup"><span data-stu-id="f9c44-352">To use the platform version, remove all references to `muxm:`.</span></span>

```xaml
<Application
    <!-- ... -->
    xmlns:muxm="using:Microsoft.UI.Xaml.Media">
    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <XamlControlsResources xmlns="using:Microsoft.UI.Xaml.Controls"/>
                <ResourceDictionary>
                    <ResourceDictionary.ThemeDictionaries>
                        <ResourceDictionary x:Key="Default">
                            <!-- The "Default" theme dictionary is used unless a specific
                                 light, dark, or high contrast dictionary is provided. These
                                 resources should be tested with both the light and dark themes,
                                 and specific light or dark resources provided as needed. -->
                            <muxm:AcrylicBrush x:Key="NavigationViewDefaultPaneBackground"
                                   BackgroundSource="Backdrop"
                                   TintColor="LightSlateGray"
                                   TintOpacity=".6"/>
                            <muxm:AcrylicBrush x:Key="NavigationViewTopPaneBackground"
                                   BackgroundSource="Backdrop"
                                   TintColor="{ThemeResource SystemAccentColor}"
                                   TintOpacity=".6"/>
                            <LinearGradientBrush x:Key="NavigationViewExpandedPaneBackground"
                                     StartPoint="0.5,0" EndPoint="0.5,1">
                                <GradientStop Color="LightSlateGray" Offset="0.0" />
                                <GradientStop Color="White" Offset="1.0" />
                            </LinearGradientBrush>
                        </ResourceDictionary>
                        <ResourceDictionary x:Key="HighContrast">
                            <!-- Always include a "HighContrast" dictionary when you override
                                 theme resources. This empty dictionary ensures that the 
                                 default high contrast resources are used when the user
                                 turns on high contrast mode. -->
                        </ResourceDictionary>
                    </ResourceDictionary.ThemeDictionaries>
                </ResourceDictionary>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>
</Application>
```

## <a name="related-topics"></a><span data-ttu-id="f9c44-353">関連トピック</span><span class="sxs-lookup"><span data-stu-id="f9c44-353">Related topics</span></span>

- [<span data-ttu-id="f9c44-354">NavigationView クラス</span><span class="sxs-lookup"><span data-stu-id="f9c44-354">NavigationView class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [<span data-ttu-id="f9c44-355">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="f9c44-355">Master/details</span></span>](master-details.md)
- [<span data-ttu-id="f9c44-356">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="f9c44-356">Navigation basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="f9c44-357">Fluent デザイン for UWP の概要</span><span class="sxs-lookup"><span data-stu-id="f9c44-357">Fluent Design for UWP overview</span></span>](../fluent-design-system/index.md)
