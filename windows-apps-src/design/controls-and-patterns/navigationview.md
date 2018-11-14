---
author: jwmsft
Description: NavigationView is an adaptive control that implements top-level navigation patterns for your app.
title: ナビゲーション ビュー
template: detail.hbs
ms.author: jimwalk
ms.date: 10/02/2018
ms.topic: article
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 9eef1616625ca30b1887e7f317c59f7a75abfeea
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6466308"
---
# <a name="navigation-view"></a><span data-ttu-id="fedb5-103">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="fedb5-103">Navigation view</span></span>

<span data-ttu-id="fedb5-104">NavigationView コントロールでは、アプリのトップレベルのナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-104">The NavigationView control provides top-level navigation for your app.</span></span> <span data-ttu-id="fedb5-105">さまざまな画面サイズに合わせて変化して、_上部_と_左側_のナビゲーションのスタイルをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="fedb5-105">It adapts to a variety of screen sizes and supports both _top_ and _left_ navigation styles.</span></span>

![上部のナビゲーション](images/nav-view-header.png)<br/>
_<span data-ttu-id="fedb5-107">ナビゲーション ビューは、上部と左側のナビゲーション ウィンドウまたはメニューの両方をサポートしています</span><span class="sxs-lookup"><span data-stu-id="fedb5-107">Navigation view supports both top and left navigation pane or menu</span></span>_

> <span data-ttu-id="fedb5-108">**プラットフォーム Api**: [Windows.UI.Xaml.Controls.NavigationView クラス](/uwp/api/windows.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="fedb5-108">**Platform APIs**: [Windows.UI.Xaml.Controls.NavigationView class](/uwp/api/windows.ui.xaml.controls.navigationview)</span></span>
>
> <span data-ttu-id="fedb5-109">**Windows UI ライブラリ Api**: [Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="fedb5-109">**Windows UI Library APIs**: [Microsoft.UI.Xaml.Controls.NavigationView class](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span></span>
>
> <span data-ttu-id="fedb5-110">_上部_のナビゲーションなど、NavigationView の一部の機能に必要な Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) またはそれ以降、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="fedb5-110">Some features of NavigationView, such as _top_ navigation, require Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

## <a name="is-this-the-right-control"></a><span data-ttu-id="fedb5-111">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="fedb5-111">Is this the right control?</span></span>

<span data-ttu-id="fedb5-112">NavigationView に適していますが、アダプティブ ナビゲーション コントロールを示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-112">NavigationView is an adaptive navigation control that works well for:</span></span>

- <span data-ttu-id="fedb5-113">アプリ全体で一貫性のあるナビゲーション エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-113">Providing a consistent navigational experience throughout your app.</span></span>
- <span data-ttu-id="fedb5-114">幅が狭いウィンドウには、画面領域を保持します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-114">Preserving screen real estate on smaller windows.</span></span>
- <span data-ttu-id="fedb5-115">多くのナビゲーション カテゴリへのアクセスを構成します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-115">Organizing access to many navigation categories.</span></span>

<span data-ttu-id="fedb5-116">その他のナビゲーション パターンは、[ナビゲーション デザインの基本](../basics/navigation-basics.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fedb5-116">For other navigation patterns, see [Navigation design basics](../basics/navigation-basics.md).</span></span>

## <a name="examples"></a><span data-ttu-id="fedb5-117">例</span><span class="sxs-lookup"><span data-stu-id="fedb5-117">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="fedb5-118">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="fedb5-118">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/XAML-controls-gallery-app-icon.png" alt="XAML controls gallery" width="168"></img></td>
<td>
    <p><span data-ttu-id="fedb5-119"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/NavigationView">アプリを開き、NavigationView の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="fedb5-119">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/NavigationView">open the app and see the NavigationView in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="fedb5-120">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="fedb5-120">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="fedb5-121">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="fedb5-121">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

## <a name="display-modes"></a><span data-ttu-id="fedb5-122">表示モード</span><span class="sxs-lookup"><span data-stu-id="fedb5-122">Display modes</span></span>

> <span data-ttu-id="fedb5-123">PaneDisplayMode プロパティには、Windows 10 version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) が必要です。 またはそれ以降、または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="fedb5-123">The PaneDisplayMode property requires Windows 10, version 1809 ([SDK 17763](https://developer.microsoft.com/windows/downloads/windows-10-sdk)) or later, or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="fedb5-124">PaneDisplayMode プロパティを使用して、さまざまなナビゲーションのスタイルを構成したり、NavigationView の表示モード、できます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-124">You can use the PaneDisplayMode property to configure different navigation styles, or display modes, for the NavigationView.</span></span>

:::row:::
    :::column:::
    ### <a name="top"></a><span data-ttu-id="fedb5-125">Top</span><span class="sxs-lookup"><span data-stu-id="fedb5-125">Top</span></span>
    <span data-ttu-id="fedb5-126">ウィンドウはコンテンツの上に配置されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-126">The pane is positioned above the content.</span></span></br>
    `PaneDisplayMode="Top"`
    :::column-end:::
    :::column span="2":::
    ![上部のナビゲーションの例](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="fedb5-128">_上部_のナビゲーションをお勧めする場合。</span><span class="sxs-lookup"><span data-stu-id="fedb5-128">We recommend _top_ navigation when:</span></span>

- <span data-ttu-id="fedb5-129">5 または均等に重要ですが、以下のトップレベルのナビゲーション カテゴリと、ドロップダウン オーバーフロー メニューにたどり着きますカテゴリは、重要度の低いと見なされる追加トップレベルのナビゲーションがあります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-129">You have 5 or fewer top-level navigation categories that are equally important, and any additional top-level navigation categories that end up in the dropdown overflow menu are considered less important.</span></span>
- <span data-ttu-id="fedb5-130">画面上のすべてのナビゲーション オプションを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-130">You need to show all navigation options on screen.</span></span>
- <span data-ttu-id="fedb5-131">アプリのコンテンツのスペースを追加するとします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-131">You want more space for your app content.</span></span>
- <span data-ttu-id="fedb5-132">アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。</span><span class="sxs-lookup"><span data-stu-id="fedb5-132">Icons cannot clearly describe your app's navigation categories.</span></span>

:::row:::
    :::column:::
    ### <a name="left"></a><span data-ttu-id="fedb5-133">Left</span><span class="sxs-lookup"><span data-stu-id="fedb5-133">Left</span></span>
    <span data-ttu-id="fedb5-134">ウィンドウが展開され、コンテンツの左側に配置されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-134">The pane is expanded and positioned to the left of the content.</span></span></br>
    `PaneDisplayMode="Left"`
    :::column-end:::
    :::column span="2":::
    ![展開時の左側のナビゲーション ウィンドウの例](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="fedb5-136">_左側_のナビゲーションをお勧めする場合。</span><span class="sxs-lookup"><span data-stu-id="fedb5-136">We recommend _left_ navigation when:</span></span>

- <span data-ttu-id="fedb5-137">5 ~ 10 均等に重要なトップレベルのナビゲーションのカテゴリがあります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-137">You have 5-10 equally important top-level navigation categories.</span></span>
- <span data-ttu-id="fedb5-138">ナビゲーションのカテゴリの他のアプリのコンテンツ領域が少なく、非常に掲示する場合します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-138">You want navigation categories to be very prominent, with less space for other app content.</span></span>

:::row:::
    :::column:::
    ### <a name="leftcompact"></a><span data-ttu-id="fedb5-139">LeftCompact</span><span class="sxs-lookup"><span data-stu-id="fedb5-139">LeftCompact</span></span>
    <span data-ttu-id="fedb5-140">ウィンドウを開くし、コンテンツの左側に配置されるまでアイコンのみを示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-140">The pane shows only icons until opened and is positioned to the left of the content.</span></span></br>
    `PaneDisplayMode="LeftCompact"`
    :::column-end:::
    :::column span="2":::
    ![コンパクトの左側のナビゲーション ウィンドウの例](images/displaymode-leftcompact.png)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
    ### <a name="leftminimal"></a><span data-ttu-id="fedb5-142">LeftMinimal</span><span class="sxs-lookup"><span data-stu-id="fedb5-142">LeftMinimal</span></span>
    <span data-ttu-id="fedb5-143">ウィンドウが開かれるまで、メニュー ボタンのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-143">Only the menu button is shown until the pane is opened.</span></span> <span data-ttu-id="fedb5-144">開いているときは、コンテンツの左側に配置されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-144">When opened, it's positioned to the left of the content.</span></span></br>
    `PaneDisplayMode="LeftMinimal"`
    :::column-end:::
    :::column span="2":::
    ![最小限の左側のナビゲーション ウィンドウの例](images/displaymode-leftminimal.png)
    :::column-end:::
:::row-end:::

### <a name="auto"></a><span data-ttu-id="fedb5-146">自動</span><span class="sxs-lookup"><span data-stu-id="fedb5-146">Auto</span></span>

<span data-ttu-id="fedb5-147">既定では、PaneDisplayMode が Auto に設定されます。自動モードでは、ナビゲーション ビューは、LeftMinimal、ウィンドウが狭い LeftCompact、するときの間で対応し、幅の広いウィンドウを取得し、まま。</span><span class="sxs-lookup"><span data-stu-id="fedb5-147">By default, PaneDisplayMode is set to Auto. In Auto mode, the navigation view adapts between LeftMinimal when the window is narrow, to LeftCompact, and then Left as the window gets wider.</span></span> <span data-ttu-id="fedb5-148">詳しくは、[アダプティブ動作](#adaptive-behavior)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fedb5-148">For more info, see the [adaptive behavior](#adaptive-behavior) section.</span></span>

![左側のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)<br/>
_<span data-ttu-id="fedb5-150">ナビゲーション ビューの既定のアダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="fedb5-150">Navigation view default adaptive behavior</span></span>_

## <a name="anatomy"></a><span data-ttu-id="fedb5-151">構造</span><span class="sxs-lookup"><span data-stu-id="fedb5-151">Anatomy</span></span>

<span data-ttu-id="fedb5-152">これらの画像は、ウィンドウ、ヘッダー、およびコンテンツ領域の_上部_または_左側_のナビゲーション用に構成されている場合、コントロールのレイアウトを表示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-152">These images show the layout of the pane, header, and content areas of the control when configured for _top_ or _left_ navigation.</span></span>

![上部のナビゲーション ビューのレイアウト](images/topnav-anatomy.png)<br/>
_<span data-ttu-id="fedb5-154">上部のナビゲーションのレイアウト</span><span class="sxs-lookup"><span data-stu-id="fedb5-154">Top navigation layout</span></span>_

![左側のナビゲーション ビューのレイアウト](images/leftnav-anatomy.png)<br/>
_<span data-ttu-id="fedb5-156">左側のナビゲーションのレイアウト</span><span class="sxs-lookup"><span data-stu-id="fedb5-156">Left navigation layout</span></span>_

### <a name="pane"></a><span data-ttu-id="fedb5-157">ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="fedb5-157">Pane</span></span>

<span data-ttu-id="fedb5-158">PaneDisplayMode プロパティを使用すると、コンテンツの上またはコンテンツの左側のウィンドウを配置するのにことができます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-158">You can use the PaneDisplayMode property to position the pane above the content or to the left of the content.</span></span>

<span data-ttu-id="fedb5-159">NavigationView ウィンドウを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-159">The NavigationView pane can contain:</span></span>

- <span data-ttu-id="fedb5-160">[NavigationViewItem](/uwp/api/windows.ui.xaml.controls.navigationviewitem)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="fedb5-160">[NavigationViewItem](/uwp/api/windows.ui.xaml.controls.navigationviewitem) objects.</span></span> <span data-ttu-id="fedb5-161">特定のページに移動するためのナビゲーション項目。</span><span class="sxs-lookup"><span data-stu-id="fedb5-161">Navigation items for navigating to specific pages.</span></span>
- <span data-ttu-id="fedb5-162">[NavigationViewItemSeparator](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="fedb5-162">[NavigationViewItemSeparator](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator) objects.</span></span> <span data-ttu-id="fedb5-163">ナビゲーション項目をグループ化するための区切り記号です。</span><span class="sxs-lookup"><span data-stu-id="fedb5-163">Separators for grouping navigation items.</span></span> <span data-ttu-id="fedb5-164">[不透明度](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity)のプロパティを領域としての区切り記号をレンダリングする場合は 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-164">Set the [Opacity](/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity) property to 0 to render the separator as space.</span></span>
- <span data-ttu-id="fedb5-165">[NavigationViewItemHeader](/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="fedb5-165">[NavigationViewItemHeader](/uwp/api/windows.ui.xaml.controls.navigationviewitemheader) objects.</span></span> <span data-ttu-id="fedb5-166">項目のグループにラベルを付けるためのヘッダー。</span><span class="sxs-lookup"><span data-stu-id="fedb5-166">Headers for labeling groups of items.</span></span>
- <span data-ttu-id="fedb5-167">アプリ レベルの検索を許可するオプション[AutoSuggestBox](auto-suggest-box.md)コントロール。</span><span class="sxs-lookup"><span data-stu-id="fedb5-167">An optional [AutoSuggestBox](auto-suggest-box.md) control to allow for app-level search.</span></span> <span data-ttu-id="fedb5-168">[NavigationView.AutoSuggestBox](/uwp/api/windows.ui.xaml.controls.navigationview.autosuggestbox)プロパティには、コントロールを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-168">Assign the control to the [NavigationView.AutoSuggestBox](/uwp/api/windows.ui.xaml.controls.navigationview.autosuggestbox) property.</span></span>
- <span data-ttu-id="fedb5-169">[アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)</span><span class="sxs-lookup"><span data-stu-id="fedb5-169">An optional entry point for [app settings](../app-settings/app-settings-and-data.md).</span></span> <span data-ttu-id="fedb5-170">設定項目を非表示に[IsSettingsVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを**false**に設定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-170">To hide the settings item, set the [IsSettingsVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible) property to **false**.</span></span>

<span data-ttu-id="fedb5-171">左側のウィンドウが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fedb5-171">The left pane also contains:</span></span>

- <span data-ttu-id="fedb5-172">開閉ウィンドウを切り替えるメニュー ボタン。</span><span class="sxs-lookup"><span data-stu-id="fedb5-172">A menu button to toggle the pane opened and closed.</span></span> <span data-ttu-id="fedb5-173">[IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-173">On larger app windows when the pane is open, you may choose to hide this button using the [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) property.</span></span>

<span data-ttu-id="fedb5-174">ナビゲーション ビューには、ウィンドウの左上隅に配置されている"戻る"ボタンがあります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-174">The navigation view has a back button that is placed in the top left-hand corner of the pane.</span></span> <span data-ttu-id="fedb5-175">ただし、自動的に処理する前に戻るナビゲーションし、バック スタックにコンテンツを追加します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-175">However, it does not automatically handle backwards navigation and add content to the back stack.</span></span> <span data-ttu-id="fedb5-176">表示を有効にする前に戻るナビゲーション、[前に戻るナビゲーション](#backwards-navigation)セクション。</span><span class="sxs-lookup"><span data-stu-id="fedb5-176">To enable backwards navigation, see the [backwards navigation](#backwards-navigation) section.</span></span>

<span data-ttu-id="fedb5-177">上部と左側のウィンドウの位置の詳細ウィンドウの構造を次に示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-177">Here is the detailed pane anatomy for the top and left pane positions.</span></span>

#### <a name="top-navigation-pane"></a><span data-ttu-id="fedb5-178">上部のナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="fedb5-178">Top navigation pane</span></span>

![ナビゲーション ビューの上部のウィンドウの構造](images/navview-pane-anatomy-horizontal.png)

1. <span data-ttu-id="fedb5-180">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fedb5-180">Headers</span></span>
1. <span data-ttu-id="fedb5-181">ナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="fedb5-181">Navigation items</span></span>
1. <span data-ttu-id="fedb5-182">区切り文字</span><span class="sxs-lookup"><span data-stu-id="fedb5-182">Separators</span></span>
1. <span data-ttu-id="fedb5-183">AutoSuggestBox (省略可能)</span><span class="sxs-lookup"><span data-stu-id="fedb5-183">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="fedb5-184">設定ボタン (省略可能)</span><span class="sxs-lookup"><span data-stu-id="fedb5-184">Settings button (optional)</span></span>

#### <a name="left-navigation-pane"></a><span data-ttu-id="fedb5-185">左側のナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="fedb5-185">Left navigation pane</span></span>

![左ペインの構造、ナビゲーション ビュー](images/navview-pane-anatomy-vertical.png)

1. <span data-ttu-id="fedb5-187">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="fedb5-187">Menu button</span></span>
1. <span data-ttu-id="fedb5-188">ナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="fedb5-188">Navigation items</span></span>
1. <span data-ttu-id="fedb5-189">区切り文字</span><span class="sxs-lookup"><span data-stu-id="fedb5-189">Separators</span></span>
1. <span data-ttu-id="fedb5-190">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fedb5-190">Headers</span></span>
1. <span data-ttu-id="fedb5-191">AutoSuggestBox (省略可能)</span><span class="sxs-lookup"><span data-stu-id="fedb5-191">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="fedb5-192">設定ボタン (省略可能)</span><span class="sxs-lookup"><span data-stu-id="fedb5-192">Settings button (optional)</span></span>

#### <a name="pane-footer"></a><span data-ttu-id="fedb5-193">ウィンドウのフッター</span><span class="sxs-lookup"><span data-stu-id="fedb5-193">Pane footer</span></span>

<span data-ttu-id="fedb5-194">[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter)プロパティを追加することによって、ウィンドウのフッターの自由形式のコンテンツを配置できます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-194">You can place free-form content in the pane's footer by adding it to the [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) property.</span></span>

:::row:::
    :::column:::
    ![ウィンドウのフッターに目的の上部のナビゲーション](images/navview-freeform-footer-top.png)<br>
     _<span data-ttu-id="fedb5-196">上部のウィンドウのフッター</span><span class="sxs-lookup"><span data-stu-id="fedb5-196">Top pane footer</span></span>_<br>
    :::column-end:::
    :::column:::
    ![ウィンドウのフッターに目的の左側のナビゲーション](images/navview-freeform-footer-left.png)<br>
    _<span data-ttu-id="fedb5-198">左側のウィンドウのフッター</span><span class="sxs-lookup"><span data-stu-id="fedb5-198">Left pane footer</span></span>_<br>
    :::column-end:::
:::row-end:::

#### <a name="pane-title-and-header"></a><span data-ttu-id="fedb5-199">ウィンドウのタイトルとヘッダー</span><span class="sxs-lookup"><span data-stu-id="fedb5-199">Pane title and header</span></span>

<span data-ttu-id="fedb5-200">ウィンドウのヘッダー領域でテキスト コンテンツを配置するには、 [PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-200">You can place text content in the pane header area by setting the [PaneTitle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneTitle) property.</span></span> <span data-ttu-id="fedb5-201">文字列に移動し、メニュー ボタンの横にあるテキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-201">It takes a string and shows the text next to the menu button.</span></span>

<span data-ttu-id="fedb5-202">画像やロゴなどのテキスト以外のコンテンツを追加するには、 [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティを追加することによって、ウィンドウのヘッダーで任意の要素を配置できます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-202">To add non-text content, such as an image or logo, you can place any element in the pane's header by adding it to the [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader) property.</span></span>

<span data-ttu-id="fedb5-203">PaneTitle と PaneHeader の両方が設定されている場合、コンテンツは、メニュー ボタンに最も近い PaneTitle、メニュー ボタンの横にある水平方向 stacked します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-203">If both PaneTitle and PaneHeader are set, the content is stacked horizontally next to the menu button, with the PaneTitle closest to the menu button.</span></span>

:::row:::
    :::column:::
    ![ウィンドウのヘッダーの上部のナビゲーション](images/navview-freeform-header-top.png)<br>
     _<span data-ttu-id="fedb5-205">上部のウィンドウのヘッダー</span><span class="sxs-lookup"><span data-stu-id="fedb5-205">Top pane header</span></span>_<br>
    :::column-end:::
    :::column:::
    ![ウィンドウのヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)<br>
    _<span data-ttu-id="fedb5-207">左側のウィンドウのヘッダー</span><span class="sxs-lookup"><span data-stu-id="fedb5-207">Left pane header</span></span>_<br>
    :::column-end:::
:::row-end:::

#### <a name="pane-content"></a><span data-ttu-id="fedb5-208">ウィンドウのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="fedb5-208">Pane content</span></span>

<span data-ttu-id="fedb5-209">ウィンドウで自由形式のコンテンツを配置するには、 [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティに追加します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-209">You can place free-form content in the pane by adding it to the [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent) property.</span></span>

:::row:::
    :::column:::
    ![ウィンドウ カスタム コンテンツ上部のナビゲーション](images/navview-freeform-pane-top.png)<br>
     _<span data-ttu-id="fedb5-211">上部のウィンドウのカスタム コンテンツ</span><span class="sxs-lookup"><span data-stu-id="fedb5-211">Top pane custom content</span></span>_<br>
    :::column-end:::
    :::column:::
    ![ナビゲーションの左ペインのカスタム コンテンツ](images/navview-freeform-pane-left.png)<br>
    _<span data-ttu-id="fedb5-213">左側のウィンドウのカスタム コンテンツ</span><span class="sxs-lookup"><span data-stu-id="fedb5-213">Left pane custom content</span></span>_<br>
    :::column-end:::
:::row-end:::

### <a name="header"></a><span data-ttu-id="fedb5-214">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fedb5-214">Header</span></span>

<span data-ttu-id="fedb5-215">ページ タイトルを追加するには、 [Header](/uwp/api/windows.ui.xaml.controls.navigationview.header)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-215">You can add a page title by setting the [Header](/uwp/api/windows.ui.xaml.controls.navigationview.header) property.</span></span>

![ナビゲーション ビューのヘッダー領域の例](images/nav-header.png)<br/>
_<span data-ttu-id="fedb5-217">ナビゲーション ビューのヘッダー</span><span class="sxs-lookup"><span data-stu-id="fedb5-217">Navigation view header</span></span>_

<span data-ttu-id="fedb5-218">ヘッダー領域は、左側のウィンドウの位置でナビゲーション ボタンと垂直に揃えし、は、ウィンドウの上部のウィンドウの位置で下に配置します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-218">The header area is vertically aligned with the navigation button in the left pane position, and lies below the pane in the top pane position.</span></span> <span data-ttu-id="fedb5-219">固定高さが 52 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="fedb5-219">It has a fixed height of 52 px.</span></span> <span data-ttu-id="fedb5-220">これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。</span><span class="sxs-lookup"><span data-stu-id="fedb5-220">Its purpose is to hold the page title of the selected nav category.</span></span> <span data-ttu-id="fedb5-221">ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-221">The header is docked to the top of the page and acts as a scroll clipping point for the content area.</span></span>

<span data-ttu-id="fedb5-222">ヘッダーは最小限に抑えながら表示モードは、NavigationView はいつでも表示されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-222">The header is visible any time the NavigationView is in Minimal display mode.</span></span> <span data-ttu-id="fedb5-223">ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-223">You may choose to hide the header in other modes, which are used on larger window widths.</span></span> <span data-ttu-id="fedb5-224">ヘッダーを非表示に[AlwaysShowHeader](/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader)プロパティを**false**に設定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-224">To hide the header, set the [AlwaysShowHeader](/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) property to **false**.</span></span>

### <a name="content"></a><span data-ttu-id="fedb5-225">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="fedb5-225">Content</span></span>

![ナビゲーション ビューのコンテンツ領域の例](images/nav-content.png)<br/>
_<span data-ttu-id="fedb5-227">ナビゲーション ビューのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="fedb5-227">Navigation view content</span></span>_

<span data-ttu-id="fedb5-228">コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-228">The content area is where most of the information for the selected nav category is displayed.</span></span>

<span data-ttu-id="fedb5-229">お勧めします NavigationView が**最小**モードのときは、コンテンツ領域の余白を 12px 24px 余白そうでない場合。</span><span class="sxs-lookup"><span data-stu-id="fedb5-229">We recommend 12px margins for your content area when NavigationView is in **Minimal** mode and 24px margins otherwise.</span></span>

## <a name="adaptive-behavior"></a><span data-ttu-id="fedb5-230">アダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="fedb5-230">Adaptive behavior</span></span>

<span data-ttu-id="fedb5-231">既定では、ナビゲーション ビューは自動的に利用可能な画面領域の量に基づいて表示モードを変更します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-231">By default, the navigation view automatically changes its display mode based on the amount of screen space available to it.</span></span> <span data-ttu-id="fedb5-232">[CompactModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.compactmodethresholdwidth)と[ExpandedModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.expandedmodethresholdwidth)プロパティは、表示モードが変化するブレークポイントを指定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-232">The [CompactModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.compactmodethresholdwidth) and [ExpandedModeThresholdWidth](/uwp/api/windows.ui.xaml.controls.navigationview.expandedmodethresholdwidth) properties specify the breakpoints at which the display mode changes.</span></span> <span data-ttu-id="fedb5-233">アダプティブ表示モードの動作をカスタマイズするこれらの値を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-233">You can modify these values to customize the adaptive display mode behavior.</span></span>

### <a name="default"></a><span data-ttu-id="fedb5-234">既定値</span><span class="sxs-lookup"><span data-stu-id="fedb5-234">Default</span></span>

<span data-ttu-id="fedb5-235">PaneDisplayMode が**自動**の既定値に設定されている場合、アダプティブ動作は表示されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-235">When PaneDisplayMode is set to its default value of **Auto**, the adaptive behavior is to show:</span></span>

- <span data-ttu-id="fedb5-236">大きなウィンドウの幅で展開された左側のウィンドウ (1008 ピクセル以上)。</span><span class="sxs-lookup"><span data-stu-id="fedb5-236">An expanded left pane on large window widths (1008px or greater).</span></span>
- <span data-ttu-id="fedb5-237">A 左、アイコンのみ普通サイズのウィンドウの幅をナビゲーション ウィンドウ (LeftCompact) (641 ピクセル ~ 1007 ピクセル)。</span><span class="sxs-lookup"><span data-stu-id="fedb5-237">A left, icon-only, nav pane (LeftCompact) on medium window widths (641px to 1007px).</span></span>
- <span data-ttu-id="fedb5-238">のみメニュー上のボタン (LeftMinimal) 小さいウィンドウ幅 (640 ピクセル以下以内)。</span><span class="sxs-lookup"><span data-stu-id="fedb5-238">Only a menu button (LeftMinimal) on small window widths (640px or less).</span></span>

<span data-ttu-id="fedb5-239">アダプティブ動作のウィンドウ サイズについて詳しくは、[画面サイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fedb5-239">For more information about window sizes for adaptive behavior, see [Screen sizes and breakpoints](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

![左側のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)<br/>
_<span data-ttu-id="fedb5-241">ナビゲーション ビューの既定のアダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="fedb5-241">Navigation view default adaptive behavior</span></span>_

### <a name="minimal"></a><span data-ttu-id="fedb5-242">最小</span><span class="sxs-lookup"><span data-stu-id="fedb5-242">Minimal</span></span>

<span data-ttu-id="fedb5-243">大きなウィンドウの幅、および両方大小の普通サイズのウィンドウの幅をメニュー ボタンのみで展開された左側のウィンドウを使用する 2 つ目の一般的なアダプティブ パターンです。</span><span class="sxs-lookup"><span data-stu-id="fedb5-243">A second common adaptive pattern is to use an expanded left pane on large window widths, and only a menu button on both medium and small window widths.</span></span>

<span data-ttu-id="fedb5-244">このときをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-244">We recommend this when:</span></span>

- <span data-ttu-id="fedb5-245">小さいウィンドウの幅をアプリのコンテンツのスペースを追加するとします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-245">You want more space for app content on smaller window widths.</span></span>
- <span data-ttu-id="fedb5-246">アイコンを含む、ナビゲーションのカテゴリを明確に表示できません。</span><span class="sxs-lookup"><span data-stu-id="fedb5-246">Your navigation categories cannot be clearly represented with icons.</span></span>

![左側のナビゲーション最小限のアダプティブ動作](images/adaptive-behavior-minimal.png)<br/>
_<span data-ttu-id="fedb5-248">ナビゲーション ビューの「最小」アダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="fedb5-248">Navigation view "minimal" adaptive behavior</span></span>_

<span data-ttu-id="fedb5-249">この動作を構成するを折りたたむウィンドウ幅を CompactModeThresholdWidth を設定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-249">To configure this behavior, set CompactModeThresholdWidth to the width at which you want the pane to collapse.</span></span> <span data-ttu-id="fedb5-250">ここでは、640 を 1007 の既定値から変更されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-250">Here, it's changed from the default of 640 to 1007.</span></span> <span data-ttu-id="fedb5-251">値が競合しないようにする ExpandedModeThresholdWidth を設定することもする必要があります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-251">You should also set ExpandedModeThresholdWidth to ensure the values don't conflict.</span></span>

```xaml
<NavigationView CompactModeThresholdWidth="1007" ExpandedModeThresholdWidth="1007"/>
```

### <a name="compact"></a><span data-ttu-id="fedb5-252">コンパクト</span><span class="sxs-lookup"><span data-stu-id="fedb5-252">Compact</span></span>

<span data-ttu-id="fedb5-253">3 番目の一般的なアダプティブ パターンでは、大きなウィンドウの幅と、LeftCompact、アイコンのみ両方大小の普通サイズのウィンドウの幅をナビゲーション ウィンドウで、展開時の左側のウィンドウを使用します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-253">A third common adaptive pattern is to use an expanded left pane on large window widths, and a LeftCompact, icon-only, nav pane on both medium and small window widths.</span></span>

<span data-ttu-id="fedb5-254">このときをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-254">We recommend this when:</span></span>

- <span data-ttu-id="fedb5-255">常に画面上のすべてのナビゲーション オプションを表示するのには重要です。</span><span class="sxs-lookup"><span data-stu-id="fedb5-255">It is important to always show all navigation options on screen.</span></span>
- <span data-ttu-id="fedb5-256">ナビゲーションのカテゴリは、アイコンを明確に表すことができます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-256">Your navigation categories can be clearly represented with icons.</span></span>

![左側のナビゲーション コンパクトなアダプティブ動作](images/adaptive-behavior-compact.png)<br/>
_<span data-ttu-id="fedb5-258">ナビゲーション ビュー"compact"のアダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="fedb5-258">Navigation view "compact" adaptive behavior</span></span>_

<span data-ttu-id="fedb5-259">この動作を構成するには、CompactModeThresholdWidth を 0 に設定します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-259">To configure this behavior, set CompactModeThresholdWidth to 0.</span></span>

```xaml
<NavigationView CompactModeThresholdWidth="0"/>
```

### <a name="no-adaptive-behavior"></a><span data-ttu-id="fedb5-260">アダプティブ動作がないです。</span><span class="sxs-lookup"><span data-stu-id="fedb5-260">No adaptive behavior</span></span>

<span data-ttu-id="fedb5-261">自動のアダプティブ動作を無効にするには、自動以外の値に PaneDisplayMode を設定します。ここでは、設定されているウィンドウの幅に関係なく、LeftMinimal にメニュー ボタンのみが表示されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-261">To disable the automatic adaptive behavior, set PaneDisplayMode to a value other than Auto. Here, it's set to LeftMinimal, so only the menu button is shown regardless of the window width.</span></span>

![左側のナビゲーションなしのアダプティブ動作](images/adaptive-behavior-none.png)<br/>
_<span data-ttu-id="fedb5-263">PaneDisplayMode LeftMinimal に設定とナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="fedb5-263">Navigation view with PaneDisplayMode set to LeftMinimal</span></span>_

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

<span data-ttu-id="fedb5-264">前述_の表示モード_のセクションで、上部、常に展開された、常にコンパクトまたは常に最低限に常にするウィンドウを設定できます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-264">As described previously in the _Display modes_ section, you can set the pane to be always on top, always expanded, always compact, or always minimal.</span></span> <span data-ttu-id="fedb5-265">管理することも、表示モード自分で、アプリのコードでします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-265">You can also manage the display modes yourself in your app code.</span></span> <span data-ttu-id="fedb5-266">この例は、次のセクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-266">An example of this is shown in the next section.</span></span>

### <a name="top-to-left-navigation"></a><span data-ttu-id="fedb5-267">左側のナビゲーションを上</span><span class="sxs-lookup"><span data-stu-id="fedb5-267">Top to left navigation</span></span>

<span data-ttu-id="fedb5-268">アプリで最上位のナビゲーションを使用する場合のナビゲーション項目をオーバーフロー メニューにウィンドウの幅の減少として折りたたみます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-268">When you use top navigation in your app, navigation items collapse into an overflow menu as the window width decreases.</span></span> <span data-ttu-id="fedb5-269">とき、アプリ ウィンドウが狭い場合は、すべての項目は、オーバーフロー メニューに折りたたむことのではなく、LeftMinimal のナビゲーションを上から PaneDisplayMode を切り替えるユーザー エクスペリエンスの向上を提供できます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-269">When your app window is narrow, it can provide a better user experience to switch the PaneDisplayMode from Top to LeftMinimal navigation, rather than letting all the items collapse into the overflow menu.</span></span>

<span data-ttu-id="fedb5-270">大きなウィンドウのサイズと小さなの左側のナビゲーションでの上部のナビゲーションの使用をお勧めしますウィンドウのサイズを場合。</span><span class="sxs-lookup"><span data-stu-id="fedb5-270">We recommend using top navigation on large window sizes and left navigation on small window sizes when:</span></span>

- <span data-ttu-id="fedb5-271">その重要度が同じを与えるの左側のナビゲーションを折りたたむこのセットの 1 つのカテゴリが画面に収まらない場合、一緒に表示される均等に重要なトップレベルのナビゲーション カテゴリのセットがあります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-271">You have a set of equally important top-level navigation categories to be displayed together, such that if one category in this set doesn't fit on screen, you collapse to left navigation to give them equal importance.</span></span>
- <span data-ttu-id="fedb5-272">小さいウィンドウのサイズで可能な領域がはるかにコンテンツを維持したいです。</span><span class="sxs-lookup"><span data-stu-id="fedb5-272">You wish to preserve as much content space as possible in small window sizes.</span></span>

<span data-ttu-id="fedb5-273">この例では、上部と LeftMinimal ナビゲーション間を切り替える[VisualStateManager](/uwp/api/Windows.UI.Xaml.VisualStateManager)と[AdaptiveTrigger.MinWindowWidth](/uwp/api/windows.ui.xaml.adaptivetrigger.minwindowwidth)プロパティを使用する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-273">This example shows how to use a [VisualStateManager](/uwp/api/Windows.UI.Xaml.VisualStateManager) and [AdaptiveTrigger.MinWindowWidth](/uwp/api/windows.ui.xaml.adaptivetrigger.minwindowwidth) property to switch between Top and LeftMinimal navigation.</span></span>

![または左端のアダプティブ動作 1 の例](images/navigation-top-to-left.png)

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
> <span data-ttu-id="fedb5-275">AdaptiveTrigger.MinWindowWidth を使用すると、ウィンドウが指定された最小幅よりも広い場合、表示状態がトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-275">When you use AdaptiveTrigger.MinWindowWidth, the visual state is triggered when the window is wider than the specified minimum width.</span></span> <span data-ttu-id="fedb5-276">これは、既定の XAML は、幅の狭いウィンドウを定義し、VisualState 幅の広いウィンドウを取得するときに適用される変更を定義することを意味します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-276">This means the default XAML defines the narrow window, and the VisualState defines the modifications that are applied when the window gets wider.</span></span> <span data-ttu-id="fedb5-277">既定の PaneDisplayMode ナビゲーション ビューは、自動、したがってときに、ウィンドウの幅が CompactModeThresholdWidth、小さい LeftMinimal ナビゲーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-277">The default PaneDisplayMode for the navigation view is Auto, so when the window width is less than or equal to CompactModeThresholdWidth, LeftMinimal navigation is used.</span></span> <span data-ttu-id="fedb5-278">ウィンドウが大きく、VisualState は、既定値を上書きし、上部のナビゲーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-278">When the window gets wider, the VisualState overrides the default, and Top navigation is used.</span></span>

## <a name="navigation"></a><span data-ttu-id="fedb5-279">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="fedb5-279">Navigation</span></span>

<span data-ttu-id="fedb5-280">ナビゲーション ビューは、自動的にナビゲーション タスクを実行しません。</span><span class="sxs-lookup"><span data-stu-id="fedb5-280">The navigation view doesn't perform any navigation tasks automatically.</span></span> <span data-ttu-id="fedb5-281">ナビゲーション項目をタップ、ナビゲーション ビューは、選択された項目と[ItemInvoked](/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked)イベントを発生させます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-281">When the user taps on a navigation item, the navigation view shows that item as selected and raises an [ItemInvoked](/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) event.</span></span> <span data-ttu-id="fedb5-282">タップにより新しいアイテムが選択されていると場合も、 [SelectionChanged](/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged)イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-282">If the tap results in a new item being selected, a [SelectionChanged](/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) event is also raised.</span></span>

<span data-ttu-id="fedb5-283">要求されたナビゲーションに関連するタスクを実行するいずれかのイベントを処理することができます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-283">You can handle either event to perform tasks related to the requested navigation.</span></span> <span data-ttu-id="fedb5-284">2 つを処理する必要がありますは、アプリの目的の動作によって異なります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-284">Which one you should handle depends on the behavior you want for your app.</span></span> <span data-ttu-id="fedb5-285">通常、要求されたページに移動し、これらのイベントへの応答でナビゲーション ビューのヘッダーを更新します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-285">Typically, you navigate to the requested page and update the navigation view header in response to these events.</span></span>

<span data-ttu-id="fedb5-286">**ItemInvoked**がまだ選択されている場合でも、いつでも、ユーザーが、ナビゲーション項目をタップ発生します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-286">**ItemInvoked** is raised any time the user taps a navigation item, even if it's already selected.</span></span> <span data-ttu-id="fedb5-287">(項目も呼び出せるマウス、キーボード、またはその他の入力を使用して、同等の操作とします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-287">(The item can also be invoked with an equivalent action using mouse, keyboard, or other input.</span></span> <span data-ttu-id="fedb5-288">詳しくは、参照[入力と操作](../input/index.md))。ItemInvoked ハンドラーで移動する場合は、既定では、ページが再読み込みと重複したエントリがナビゲーション スタックに追加します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-288">For more info, see [Input and interactions](../input/index.md).) If you navigate in the ItemInvoked handler, by default, the page will be reloaded, and a duplicate entry is added to the navigation stack.</span></span> <span data-ttu-id="fedb5-289">呼び出されると、項目を移動する場合は、ページの再読み込みを禁止します。 またはナビゲーション バック スタックに重複するエントリが作成されないである場合、ページが再読み込みすることを確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-289">If you navigate when an item is invoked, you should disallow reloading the page, or ensure that a duplicate entry is not created in the navigation backstack when the page is reloaded.</span></span> <span data-ttu-id="fedb5-290">(詳しくは、コード例を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="fedb5-290">(See code examples.)</span></span>

<span data-ttu-id="fedb5-291">ユーザーではない、現在選択されている項目の呼び出しによって、またはをプログラムで選択した項目を変更することは、 **SelectionChanged**を発生させることができます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-291">**SelectionChanged** can be raised by a user invoking an item that isn't currently selected, or by programmatically changing the selected item.</span></span> <span data-ttu-id="fedb5-292">ユーザーが項目を呼び出すために選択の変更が発生した場合 ItemInvoked イベントが最初に発生します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-292">If the selection change occurs because a user invoked an item, the ItemInvoked event occurs first.</span></span> <span data-ttu-id="fedb5-293">選択の変更がプログラムの場合は、ItemInvoked は発生しません。</span><span class="sxs-lookup"><span data-stu-id="fedb5-293">If the selection change is programmatic, ItemInvoked is not raised.</span></span>

### <a name="backwards-navigation"></a><span data-ttu-id="fedb5-294">逆方向のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="fedb5-294">Backwards navigation</span></span>

<span data-ttu-id="fedb5-295">NavigationView は、組み込みの戻るボタンただしと同様に、ナビゲーションがない前に戻るナビゲーションを自動的に実行します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-295">NavigationView has a built-in back button; but, as with forward navigation, it doesn't perform backwards navigation automatically.</span></span> <span data-ttu-id="fedb5-296">[戻る] ボタンをタップすると、 [BackRequested](/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested)イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-296">When the user taps the back button, the [BackRequested](/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) event is raised.</span></span> <span data-ttu-id="fedb5-297">前に戻るナビゲーションを実行するには、このイベントを処理します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-297">You handle this event to perform backwards navigation.</span></span> <span data-ttu-id="fedb5-298">詳細情報とコード例については、次を参照してください。[ナビゲーション履歴と前に戻るナビゲーション](../basics/navigation-history-and-backwards-navigation.md)します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-298">For more info and code examples, see [Navigation history and backwards navigation](../basics/navigation-history-and-backwards-navigation.md).</span></span>

<span data-ttu-id="fedb5-299">最小限またはコンパクト モードでは、ナビゲーション ビューは、ウィンドウがポップアップとして開いて。</span><span class="sxs-lookup"><span data-stu-id="fedb5-299">In Minimal or Compact mode, the navigation view Pane is open as a flyout.</span></span> <span data-ttu-id="fedb5-300">この例では、"戻る"ボタンのクリックしてはウィンドウを閉じるし、 **PaneClosing**イベントが発生する代わりにします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-300">In this case, clicking the back button will close the Pane and raise the **PaneClosing** event instead.</span></span>

<span data-ttu-id="fedb5-301">非表示にするか、これらのプロパティを設定して、戻るボタンを無効にできます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-301">You can hide or disable the back button by setting these properties:</span></span>

- <span data-ttu-id="fedb5-302">[IsBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible): と"戻る"ボタンを非表示に使用します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-302">[IsBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible): use to show and hide the back button.</span></span> <span data-ttu-id="fedb5-303">このプロパティは、 [NavigationViewBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible)列挙体の値を受け取り、既定では**自動的**に設定されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-303">This property takes a value of the [NavigationViewBackButtonVisible](/uwp/api/windows.ui.xaml.controls.navigationviewbackbuttonvisible) enumeration, and is set to **Auto** by default.</span></span> <span data-ttu-id="fedb5-304">ボタンが折りたたまれていると領域ない用に予約されてレイアウト。</span><span class="sxs-lookup"><span data-stu-id="fedb5-304">When the button is collapsed, no space is reserved for it in the layout.</span></span>
- <span data-ttu-id="fedb5-305">[IsBackEnabled](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled): を有効にするまたは戻るボタンを無効にします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-305">[IsBackEnabled](/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled): use to enable or disable the back button.</span></span> <span data-ttu-id="fedb5-306">このプロパティには、ナビゲーション フレームの[CanGoBack](/uwp/api/windows.ui.xaml.controls.frame.cangoback)プロパティにデータ バインドできます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-306">You can data bind this property to the [CanGoBack](/uwp/api/windows.ui.xaml.controls.frame.cangoback) property of your navigation frame.</span></span> <span data-ttu-id="fedb5-307">**IsBackEnabled**が**false**の場合、 **BackRequested**は発生しません。</span><span class="sxs-lookup"><span data-stu-id="fedb5-307">**BackRequested** is not raised if **IsBackEnabled** is **false**.</span></span>

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

## <a name="code-example"></a><span data-ttu-id="fedb5-308">コードの例</span><span class="sxs-lookup"><span data-stu-id="fedb5-308">Code example</span></span>

<span data-ttu-id="fedb5-309">この例では、大規模なウィンドウ サイズの上部のナビゲーション ウィンドウと小さなウィンドウ サイズの左側のナビゲーション ウィンドウの両方で NavigationView を使用する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fedb5-309">This example shows how you can use NavigationView with both a top navigation pane on large window sizes and a left navigation pane on small window sizes.</span></span> <span data-ttu-id="fedb5-310">VisualStateManager で、_上部_のナビゲーションの設定を削除することで左専用のナビゲーションに合わせることができます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-310">It can be adapted to left-only navigation by removing the _top_ navigation settings in the VisualStateManager.</span></span>

<span data-ttu-id="fedb5-311">多くの一般的なシナリオに対応するナビゲーション データの設定に推奨される方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-311">The example demonstrates a recommended way to set up navigation data that will work for many common scenarios.</span></span> <span data-ttu-id="fedb5-312">また、前に戻るナビゲーションで NavigationView の"戻る"ボタンとキーボード ナビゲーションを実装する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fedb5-312">It also demonstrates how to implement backwards navigation with NavigationView's back button and keyboard navigation.</span></span>

<span data-ttu-id="fedb5-313">このコードでは、アプリがページに移動する次の名前が含まれていると想定しています:_ホームページ_、 _AppsPage_、 _GamesPage_、 _MusicPage_、 _MyContentPage_、および_SettingsPage_します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-313">This code assumes that your app contains pages with the following names to navigate to: _HomePage_, _AppsPage_, _GamesPage_, _MusicPage_, _MyContentPage_, and _SettingsPage_.</span></span> <span data-ttu-id="fedb5-314">これらのページのコードは表示されません。</span><span class="sxs-lookup"><span data-stu-id="fedb5-314">Code for these pages is not shown.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="fedb5-315">アプリのページについては、 [ValueTuple](https://docs.microsoft.com/dotnet/api/system.valuetuple)に格納されます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-315">Information about the app's pages is stored in a [ValueTuple](https://docs.microsoft.com/dotnet/api/system.valuetuple).</span></span> <span data-ttu-id="fedb5-316">この構造体は、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要がありますが必要です。</span><span class="sxs-lookup"><span data-stu-id="fedb5-316">This struct requires that the minimum version for your app project must be SDK 17763 or greater.</span></span> <span data-ttu-id="fedb5-317">Windows 10 の以前のバージョンをターゲットに NavigationView の WinUI バージョンを使用する場合は、代わりに[System.ValueTuple NuGet パッケージ](https://www.nuget.org/packages/System.ValueTuple/)を使用できます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-317">If you use the WinUI version of NavigationView to target earlier versions of Windows 10, you can use the [System.ValueTuple NuGet package](https://www.nuget.org/packages/System.ValueTuple/) instead.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="fedb5-318">このコードは、NavigationView の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fedb5-318">This code shows how to use the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/) version of NavigationView.</span></span> <span data-ttu-id="fedb5-319">NavigationView のプラットフォーム バージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-319">If you use the platform version of NavigationView instead, the minimum version for your app project must be SDK 17763 or greater.</span></span> <span data-ttu-id="fedb5-320">プラットフォームのバージョンを使用するすべての参照を削除する`muxc:`します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-320">To use the platform version, remove all references to `muxc:`.</span></span>

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
> <span data-ttu-id="fedb5-321">このコードは、NavigationView の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fedb5-321">This code shows how to use the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/) version of NavigationView.</span></span> <span data-ttu-id="fedb5-322">NavigationView のプラットフォーム バージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 17763 以上である必要があります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-322">If you use the platform version of NavigationView instead, the minimum version for your app project must be SDK 17763 or greater.</span></span> <span data-ttu-id="fedb5-323">プラットフォームのバージョンを使用するすべての参照を削除する`muxc`します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-323">To use the platform version, remove all references to `muxc`.</span></span>

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

## <a name="navigation-view-customization"></a><span data-ttu-id="fedb5-324">ナビゲーション ビューのカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="fedb5-324">Navigation view customization</span></span>

### <a name="pane-backgrounds"></a><span data-ttu-id="fedb5-325">ウィンドウの背景</span><span class="sxs-lookup"><span data-stu-id="fedb5-325">Pane Backgrounds</span></span>

<span data-ttu-id="fedb5-326">既定では、NavigationView ウィンドウは、表示モードに応じて、さまざまな背景を使用します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-326">By default, the NavigationView pane uses a different background depending on the display mode:</span></span>

- <span data-ttu-id="fedb5-327">ウィンドウは灰色単色 (左モード) では、コンテンツと並行して、左側の展開されたときです。</span><span class="sxs-lookup"><span data-stu-id="fedb5-327">the pane is a solid grey color when expanded on the left, side-by-side with the content (in Left mode).</span></span>
- <span data-ttu-id="fedb5-328">ウィンドウは、コンテンツ (上、最小限に抑えながら、またはコンパクト モードで) 上にオーバーレイとして開くときに、アプリ内アクリルを使用します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-328">the pane uses in-app acrylic when open as an overlay on top of content (in Top, Minimal, or Compact mode).</span></span>

<span data-ttu-id="fedb5-329">ウィンドウの背景を変更するには、各モードの背景をレンダリングするために使用する XAML テーマ リソースを上書きできます。</span><span class="sxs-lookup"><span data-stu-id="fedb5-329">To modify the pane background, you can override the XAML theme resources used to render the background in each mode.</span></span> <span data-ttu-id="fedb5-330">(この手法が使用 PaneBackground の 1 つのプロパティではなくさまざまな表示モードのさまざまな背景をサポートするために)。</span><span class="sxs-lookup"><span data-stu-id="fedb5-330">(This technique is used rather than a single PaneBackground property in order to support different backgrounds for different display modes.)</span></span>

<span data-ttu-id="fedb5-331">次の表では、どのテーマ リソースを使用して各表示モードを示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-331">This table shows which theme resource is used in each display mode.</span></span>

| <span data-ttu-id="fedb5-332">表示モード</span><span class="sxs-lookup"><span data-stu-id="fedb5-332">Display mode</span></span> | <span data-ttu-id="fedb5-333">テーマ リソース</span><span class="sxs-lookup"><span data-stu-id="fedb5-333">Theme resource</span></span> |
| ------------ | -------------- |
| <span data-ttu-id="fedb5-334">Left</span><span class="sxs-lookup"><span data-stu-id="fedb5-334">Left</span></span> | <span data-ttu-id="fedb5-335">NavigationViewExpandedPaneBackground</span><span class="sxs-lookup"><span data-stu-id="fedb5-335">NavigationViewExpandedPaneBackground</span></span> |
| <span data-ttu-id="fedb5-336">LeftCompact</span><span class="sxs-lookup"><span data-stu-id="fedb5-336">LeftCompact</span></span><br/><span data-ttu-id="fedb5-337">LeftMinimal</span><span class="sxs-lookup"><span data-stu-id="fedb5-337">LeftMinimal</span></span> | <span data-ttu-id="fedb5-338">NavigationViewDefaultPaneBackground</span><span class="sxs-lookup"><span data-stu-id="fedb5-338">NavigationViewDefaultPaneBackground</span></span> |
| <span data-ttu-id="fedb5-339">Top</span><span class="sxs-lookup"><span data-stu-id="fedb5-339">Top</span></span> | <span data-ttu-id="fedb5-340">NavigationViewTopPaneBackground</span><span class="sxs-lookup"><span data-stu-id="fedb5-340">NavigationViewTopPaneBackground</span></span> |

<span data-ttu-id="fedb5-341">この例では、App.xaml 内のテーマ リソースをオーバーライドする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-341">This example shows how to override the theme resources in App.xaml.</span></span> <span data-ttu-id="fedb5-342">テーマ リソースをオーバーライドする場合は常を入力してください少なくとも、"Default"と"HighContrast"のリソース ディクショナリとディクショナリ「ライト」または"Dark"のリソースに応じてします。</span><span class="sxs-lookup"><span data-stu-id="fedb5-342">When you override theme resources, you should always provide "Default" and "HighContrast" resource dictionaries at a minimum, and dictionaries for "Light" or "Dark" resources as needed.</span></span> <span data-ttu-id="fedb5-343">詳しくは、 [ResourceDictionary.ThemeDictionaries](/uwp/api/windows.ui.xaml.resourcedictionary.themedictionaries)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fedb5-343">For more info, see [ResourceDictionary.ThemeDictionaries](/uwp/api/windows.ui.xaml.resourcedictionary.themedictionaries).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="fedb5-344">このコードは、AcrylicBrush の[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)のバージョンを使用する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="fedb5-344">This code shows how to use the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/) version of AcrylicBrush.</span></span> <span data-ttu-id="fedb5-345">AcrylicBrush のプラットフォーム バージョンを代わりに使用する場合、アプリ プロジェクトの最小バージョンは SDK 16299 以上である必要があります。</span><span class="sxs-lookup"><span data-stu-id="fedb5-345">If you use the platform version of AcrylicBrush instead, the minimum version for your app project must be SDK 16299 or greater.</span></span> <span data-ttu-id="fedb5-346">プラットフォームのバージョンを使用するすべての参照を削除する`muxm:`します。</span><span class="sxs-lookup"><span data-stu-id="fedb5-346">To use the platform version, remove all references to `muxm:`.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="fedb5-347">関連トピック</span><span class="sxs-lookup"><span data-stu-id="fedb5-347">Related topics</span></span>

- [<span data-ttu-id="fedb5-348">NavigationView クラス</span><span class="sxs-lookup"><span data-stu-id="fedb5-348">NavigationView class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [<span data-ttu-id="fedb5-349">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="fedb5-349">Master/details</span></span>](master-details.md)
- [<span data-ttu-id="fedb5-350">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="fedb5-350">Navigation basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="fedb5-351">UWP 用 Fluent Design の概要</span><span class="sxs-lookup"><span data-stu-id="fedb5-351">Fluent Design for UWP overview</span></span>](../fluent-design-system/index.md)