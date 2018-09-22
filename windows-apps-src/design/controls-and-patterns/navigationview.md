---
author: QuinnRadich
Description: NavigationView is an adaptive control that implements top-level navigation patterns for your app.
title: ナビゲーション ビュー
template: detail.hbs
ms.author: quradic
ms.date: 06/25/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 6c75169f118e2c8ef575fa251a7badc8cfe44247
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4127789"
---
# <a name="navigation-view-preview-version"></a><span data-ttu-id="24eaa-103">ナビゲーション ビュー (プレビュー版)</span><span class="sxs-lookup"><span data-stu-id="24eaa-103">Navigation view (Preview version)</span></span>

> <span data-ttu-id="24eaa-104">**これは、プレビュー版**: この記事ではまだ開発段階には、NavigationView コントロールの新しいバージョンをについて説明します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-104">**This is a preview version**: This article describes a new version of the NavigationView control that's still in development.</span></span> <span data-ttu-id="24eaa-105">それを使用するには、これで、必要な[最新の Windows Insider ビルドと SDK](https://insider.windows.com/for-developers/)または[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)。</span><span class="sxs-lookup"><span data-stu-id="24eaa-105">To use it now, you need the [latest Windows Insider build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="24eaa-106">NavigationView コントロールでは、アプリのトップレベルのナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-106">The NavigationView control provides top-level navigation for your app.</span></span> <span data-ttu-id="24eaa-107">適応するように、さまざまな画面サイズをサポートする複数のナビゲーションのスタイル。</span><span class="sxs-lookup"><span data-stu-id="24eaa-107">It adapts to a variety of screen sizes supports multiple navigation styles.</span></span>

> <span data-ttu-id="24eaa-108">**Windows UI ライブラリ Api**: [Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="24eaa-108">**Windows UI Library APIs**: [Microsoft.UI.Xaml.Controls.NavigationView class](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span></span>

> <span data-ttu-id="24eaa-109">**プラットフォーム Api**: [Windows.UI.Xaml.Controls.NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="24eaa-109">**Platform APIs**: [Windows.UI.Xaml.Controls.NavigationView class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)</span></span>

## <a name="get-the-windows-ui-library"></a><span data-ttu-id="24eaa-110">Windows UI のライブラリを入手します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-110">Get the Windows UI Library</span></span>

<span data-ttu-id="24eaa-111">このコントロールは、Windows UI のライブラリ、新しいコントロールと UWP アプリの UI の機能が含まれている NuGet パッケージの一部として含まれています。</span><span class="sxs-lookup"><span data-stu-id="24eaa-111">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="24eaa-112">詳しくは、インストールの手順を含む、 [Windows UI のライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="24eaa-112">For more info, including installation instructions, see the  [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> 

## <a name="navigation-styles"></a><span data-ttu-id="24eaa-113">ナビゲーションのスタイル</span><span class="sxs-lookup"><span data-stu-id="24eaa-113">Navigation styles</span></span>

<span data-ttu-id="24eaa-114">NavigationView がサポートしています。</span><span class="sxs-lookup"><span data-stu-id="24eaa-114">NavigationView supports:</span></span>

**<span data-ttu-id="24eaa-115">左側のナビゲーション ウィンドウやメニュー</span><span class="sxs-lookup"><span data-stu-id="24eaa-115">Left navigation pane or menu</span></span>**

![ナビゲーション ウィンドウの展開](images/displaymode-left.png)

**<span data-ttu-id="24eaa-117">上部のナビゲーション ウィンドウやメニュー</span><span class="sxs-lookup"><span data-stu-id="24eaa-117">Top navigation pane or menu</span></span>**

![上部のナビゲーション](images/displaymode-top.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="24eaa-119">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="24eaa-119">Is this the right control?</span></span>

<span data-ttu-id="24eaa-120">NavigationView は、適しているアダプティブ ナビゲーション コントロールです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-120">NavigationView is an adaptive navigation control that works well for:</span></span>

- <span data-ttu-id="24eaa-121">アプリ全体で一貫性のあるナビゲーション エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-121">Providing a consistent navigational experience throughout your app.</span></span>
- <span data-ttu-id="24eaa-122">幅が狭いウィンドウには、画面領域を保持します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-122">Preserving screen real estate on smaller windows.</span></span>
- <span data-ttu-id="24eaa-123">多くのナビゲーション カテゴリへのアクセスを編成します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-123">Organizing access to many navigation categories.</span></span>

<span data-ttu-id="24eaa-124">他のナビゲーション コントロールは、[ナビゲーション デザインの基本](../basics/navigation-basics.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24eaa-124">For other navigation controls, see [Navigation design basics](../basics/navigation-basics.md).</span></span>

<span data-ttu-id="24eaa-125">ナビゲーションで NavigationView でサポートされていないより複雑な動作が必要な場合、[マスター/詳細](master-details.md) パターンを代わりに検討することもできます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-125">If your navigation requires more complex behavior that is not supported by NavigationView, then you might want to consider the [Master/details](master-details.md) pattern instead.</span></span>

:::row:::
    :::column:::
        ![一部の画像](images/XAML-controls-gallery-app-icon.png)
    :::column-end:::
    <span data-ttu-id="24eaa-127">:::column span =「2」::: **XAML コントロール ギャラリー**</span><span class="sxs-lookup"><span data-stu-id="24eaa-127">:::column span="2"::: **XAML Controls Gallery**</span></span><br>
        <span data-ttu-id="24eaa-128">XAML コントロール ギャラリー アプリをインストールした場合は、クリックして<a href="xamlcontrolsgallery:/item/NavigationView">ここで</a>アプリを開き、NavigationView の操作を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24eaa-128">If you have the XAML Controls Gallery app installed, click <a href="xamlcontrolsgallery:/item/NavigationView">here</a> to open the app and see NavigationView in action.</span></span>

        <a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a><br>
        <a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">Get the source code (GitHub)</a>
    :::column-end:::
:::row-end:::

## <a name="display-modes"></a><span data-ttu-id="24eaa-129">表示モード</span><span class="sxs-lookup"><span data-stu-id="24eaa-129">Display modes</span></span>

<span data-ttu-id="24eaa-130">NavigationView は、経由で、さまざまな表示モードを設定できる、`PaneDisplayMode`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="24eaa-130">NavigationView can be set to different display modes, via the `PaneDisplayMode` property:</span></span>

:::row:::
    :::column:::
    ### Left
    Displays an expanded left positioned pane.
    :::column-end:::
    :::column span="2":::
    ![left nav pane expanded](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="24eaa-131">左側のナビゲーションをお勧めする場合。</span><span class="sxs-lookup"><span data-stu-id="24eaa-131">We recommend left navigation when:</span></span>

- <span data-ttu-id="24eaa-132">同様に重要なトップレベルのナビゲーション カテゴリの中程度の数 (5 ~ 10) があります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-132">You have a medium-to-high number (5-10) of equally important top-level navigation categories.</span></span>
- <span data-ttu-id="24eaa-133">他のアプリのコンテンツの領域を節約を非常に目立つナビゲーションのカテゴリがしたいです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-133">You desire very prominent navigation categories with less space for other app content.</span></span>

:::row:::
    :::column:::
    ### Top
    Displays a top positioned pane.
    :::column-end:::
    :::column span="2":::
    ![top navigation](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="24eaa-134">上部のナビゲーションをお勧めする場合。</span><span class="sxs-lookup"><span data-stu-id="24eaa-134">We recommend top navigation when:</span></span>

- <span data-ttu-id="24eaa-135">5 均等に重要なトップレベルのナビゲーションのカテゴリを小さくできるよう、ドロップダウン リストで最終的にすべての追加のトップレベルのナビゲーション カテゴリのオーバーフロー メニューと見なされます重要度の低いか。</span><span class="sxs-lookup"><span data-stu-id="24eaa-135">You have 5 or less equally important top-level navigation categories, such that any additional top-level navigation categories that end up in the dropdown overflow menu are considered less important.</span></span>
- <span data-ttu-id="24eaa-136">画面上のすべてのナビゲーション オプションを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-136">You need to show all navigation options on screen.</span></span>
- <span data-ttu-id="24eaa-137">アプリのコンテンツの多くのスペースをしたいです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-137">You desire more space for your app content.</span></span>
- <span data-ttu-id="24eaa-138">アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。</span><span class="sxs-lookup"><span data-stu-id="24eaa-138">Icons cannot clearly describe your app's navigation categories.</span></span>

:::row:::
    :::column:::
    ### LeftCompact
    Displays a thin sliver with icons on the left.
    :::column-end:::
    :::column span="2":::
    ![nav pane compact](images/displaymode-leftcompact.png)
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
    ### LeftMinimal
    Displays only the menu button.
    :::column-end:::
    :::column span="2":::
    ![nav pane minimal](images/displaymode-leftminimal.png)
    :::column-end:::
:::row-end:::

### <a name="auto"></a><span data-ttu-id="24eaa-139">自動</span><span class="sxs-lookup"><span data-stu-id="24eaa-139">Auto</span></span>

![gif 左のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)

<span data-ttu-id="24eaa-141">普通サイズの画面と大画面の左上の小さな画面で LeftMinimal、LeftCompact 間適応します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-141">Adapts between LeftMinimal on small screens, LeftCompact on medium screens, and Left on large screens.</span></span> <span data-ttu-id="24eaa-142">詳細については、[アダプティブ動作](#adaptive-behavior)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24eaa-142">See the [adaptive behavior](#adaptive-behavior) section for more information.</span></span>

## <a name="anatomy"></a><span data-ttu-id="24eaa-143">構造</span><span class="sxs-lookup"><span data-stu-id="24eaa-143">Anatomy</span></span>

<b><span data-ttu-id="24eaa-144">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-144">Left nav</span></span></b><br>

![左側のナビゲーション ビューのセクション](images/leftnav-anatomy.png)

<b><span data-ttu-id="24eaa-146">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-146">Top nav</span></span></b><br>

![上部のナビゲーション ビューのセクション](images/topnav-anatomy.png)

## <a name="pane"></a><span data-ttu-id="24eaa-148">ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="24eaa-148">Pane</span></span>

<span data-ttu-id="24eaa-149">ウィンドウで、上部または左のいずれか経由で配置する、`PanePosition`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="24eaa-149">The pane can be positioned either on top or on left, via the `PanePosition` property.</span></span>

<span data-ttu-id="24eaa-150">ウィンドウの左と上の位置の詳細ウィンドウの構造を次に示します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-150">Here is the detailed pane anatomy for the left and top pane positions:</span></span>

<b><span data-ttu-id="24eaa-151">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-151">Left nav</span></span></b><br>

![NavigationView の構造](images/navview-pane-anatomy-vertical.png)

1. <span data-ttu-id="24eaa-153">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="24eaa-153">Menu button</span></span>
1. <span data-ttu-id="24eaa-154">ナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="24eaa-154">Navigation items</span></span>
1. <span data-ttu-id="24eaa-155">区切り文字</span><span class="sxs-lookup"><span data-stu-id="24eaa-155">Separators</span></span>
1. <span data-ttu-id="24eaa-156">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="24eaa-156">Headers</span></span>
1. <span data-ttu-id="24eaa-157">AutoSuggestBox (省略可能)</span><span class="sxs-lookup"><span data-stu-id="24eaa-157">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="24eaa-158">(省略可能) の設定] ボタン</span><span class="sxs-lookup"><span data-stu-id="24eaa-158">Settings button (optional)</span></span>

<b><span data-ttu-id="24eaa-159">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-159">Top nav</span></span></b><br>

![NavigationView の構造](images/navview-pane-anatomy-horizontal.png)

1. <span data-ttu-id="24eaa-161">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="24eaa-161">Headers</span></span>
1. <span data-ttu-id="24eaa-162">ナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="24eaa-162">Navigation items</span></span>
1. <span data-ttu-id="24eaa-163">区切り文字</span><span class="sxs-lookup"><span data-stu-id="24eaa-163">Separators</span></span>
1. <span data-ttu-id="24eaa-164">AutoSuggestBox (省略可能)</span><span class="sxs-lookup"><span data-stu-id="24eaa-164">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="24eaa-165">(省略可能) の設定] ボタン</span><span class="sxs-lookup"><span data-stu-id="24eaa-165">Settings button (optional)</span></span>

<span data-ttu-id="24eaa-166">"戻る"ボタン、ウィンドウの左上隅に表示されますが、NavigationView でコンテンツが自動的にバック スタックに追加できません。</span><span class="sxs-lookup"><span data-stu-id="24eaa-166">The back button appears in the top left-hand corner of the pane, but NavigationView does not automatically add content to the back stack.</span></span> <span data-ttu-id="24eaa-167">表示を有効にする前に戻るナビゲーション、[前に戻るナビゲーション](#backwards-navigation)セクションします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-167">To enable backwards navigation, see the [backwards navigation](#backwards-navigation) section.</span></span>

<span data-ttu-id="24eaa-168">NavigationView ウィンドウも含めることができます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-168">The NavigationView pane can also contain:</span></span>

1. <span data-ttu-id="24eaa-169">特定のページに移動するための[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)フォーム内のナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="24eaa-169">Navigation items, in the form of [NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem), for navigating to specific pages.</span></span>
2. <span data-ttu-id="24eaa-170">区切り文字、 [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)の形式でナビゲーション項目をグループ化します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-170">Separators, in the form of [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator), for grouping navigation items.</span></span> <span data-ttu-id="24eaa-171">レンダリング領域としての区切り記号を 0 に[Opacity](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-171">Set the [Opacity](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity) property to 0 to render the separator as space.</span></span>
3. <span data-ttu-id="24eaa-172">項目のグループにラベルを付けるための[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)フォーム内のヘッダー</span><span class="sxs-lookup"><span data-stu-id="24eaa-172">Headers, in the form of [NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader), for labeling groups of items.</span></span>
4. <span data-ttu-id="24eaa-173">アプリ レベルの検索を許可するオプション[AutoSuggestBox](auto-suggest-box.md)します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-173">An optional [AutoSuggestBox](auto-suggest-box.md) to allow for app-level search.</span></span>
5. <span data-ttu-id="24eaa-174">[アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)</span><span class="sxs-lookup"><span data-stu-id="24eaa-174">An optional entry point for [app settings](../app-settings/app-settings-and-data.md).</span></span> <span data-ttu-id="24eaa-175">設定項目を非表示にするには、 [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-175">To hide the settings item, use the [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible) property.</span></span>

<span data-ttu-id="24eaa-176">左側のウィンドウが含まれています。</span><span class="sxs-lookup"><span data-stu-id="24eaa-176">The left pane contains:</span></span>

6. <span data-ttu-id="24eaa-177">メニュー ボタンのウィンドウを開くと閉じるを切り替えます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-177">Menu button to toggle the pane open and close.</span></span> <span data-ttu-id="24eaa-178">[IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-178">On larger app windows when the pane is open, you may choose to hide this button using the [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) property.</span></span>

### <a name="pane-footer"></a><span data-ttu-id="24eaa-179">ウィンドウのフッター</span><span class="sxs-lookup"><span data-stu-id="24eaa-179">Pane footer</span></span>

<span data-ttu-id="24eaa-180">[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="24eaa-180">Free-form content in the pane’s footer, when added to the [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) property</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="24eaa-181">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-181">Left nav</span></span></b><br>
    ![ウィンドウのフッターに目的の左側のナビゲーション](images/navview-freeform-footer-left.png)<br>
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="24eaa-183">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-183">Top nav</span></span></b><br>
    ![ウィンドウのヘッダーの上部のナビゲーション](images/navview-freeform-footer-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-header"></a><span data-ttu-id="24eaa-185">ウィンドウのヘッダー</span><span class="sxs-lookup"><span data-stu-id="24eaa-185">Pane header</span></span>

<span data-ttu-id="24eaa-186">[PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティに追加すると、ウィンドウのヘッダーで自由形式のコンテンツ</span><span class="sxs-lookup"><span data-stu-id="24eaa-186">Free-form content in the pane's header, when added to the [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader) property</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="24eaa-187">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-187">Left nav</span></span></b><br>
    ![ウィンドウのヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)<br>
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="24eaa-189">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-189">Top nav</span></span></b><br>
    ![ウィンドウのヘッダーの上部のナビゲーション](images/navview-freeform-header-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-content"></a><span data-ttu-id="24eaa-191">ウィンドウのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="24eaa-191">Pane content</span></span>

<span data-ttu-id="24eaa-192">フリー フォーム[PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティに追加すると、ウィンドウのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="24eaa-192">Free-form content in the pane, when added to the [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent) property</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="24eaa-193">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-193">Left nav</span></span></b><br>
    ![ウィンドウのカスタム contentleft ナビゲーション](images/navview-freeform-pane-left.png)<br>
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="24eaa-195">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-195">Top nav</span></span></b><br>
    ![ウィンドウ カスタム コンテンツ上部のナビゲーション](images/navview-freeform-pane-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="visual-style"></a><span data-ttu-id="24eaa-197">視覚スタイル</span><span class="sxs-lookup"><span data-stu-id="24eaa-197">Visual style</span></span>

<span data-ttu-id="24eaa-198">ハードウェアおよびソフトウェア要件が満たされている場合、NavigationView は、そのウィンドウで、[アクリル素材](../style/acrylic.md)とのみで、左側のウィンドウの[表示ハイライト](../style/reveal.md)に自動的に使用します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-198">When hardware and software requirements are met, NavigationView automatically uses the [Acrylic material](../style/acrylic.md) in its pane, and [Reveal highlight](../style/reveal.md) only in its left pane.</span></span>

## <a name="header"></a><span data-ttu-id="24eaa-199">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="24eaa-199">Header</span></span>

![ヘッダー領域の汎用的な画像を navview](images/nav-header.png)

<span data-ttu-id="24eaa-201">ヘッダー領域は、左側のウィンドウの位置でナビゲーション ボタンと垂直に揃えし、は、ウィンドウの上部のウィンドウの位置で下に配置します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-201">The header area is vertically aligned with the navigation button in the left pane position, and lies below the pane in the top pane position.</span></span> <span data-ttu-id="24eaa-202">固定高さが 52 ピクセルです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-202">It has a fixed height of 52 px.</span></span> <span data-ttu-id="24eaa-203">これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-203">Its purpose is to hold the page title of the selected nav category.</span></span> <span data-ttu-id="24eaa-204">ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-204">The header is docked to the top of the page and acts as a scroll clipping point for the content area.</span></span>

<span data-ttu-id="24eaa-205">NavigationView が最小限に抑えながら表示モードの場合、ヘッダーが表示される必要があります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-205">The header must be visible when NavigationView is in Minimal display mode.</span></span> <span data-ttu-id="24eaa-206">ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-206">You may choose to hide the header in other modes, which are used on larger window widths.</span></span> <span data-ttu-id="24eaa-207">これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-207">To do so, set the [AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) property to **false**.</span></span>

## <a name="content"></a><span data-ttu-id="24eaa-208">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="24eaa-208">Content</span></span>

![コンテンツ領域の汎用的な画像を navview](images/nav-content.png)

<span data-ttu-id="24eaa-210">コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-210">The content area is where most of the information for the selected nav category is displayed.</span></span>

<span data-ttu-id="24eaa-211">NavigationView が最小モードの場合はコンテンツ領域に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-211">We recommend 12px margins for your content area when NavigationView is in Minimal mode and 24px margins otherwise.</span></span>

## <a name="adaptive-behavior"></a><span data-ttu-id="24eaa-212">アダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="24eaa-212">Adaptive behavior</span></span>

<span data-ttu-id="24eaa-213">NavigationView は、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-213">NavigationView automatically changes its display mode based on the amount of screen space available to it.</span></span> <span data-ttu-id="24eaa-214">ただし、アダプティブ表示モードの動作をカスタマイズする場合があります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-214">However, you might want to customize the adaptive display mode behavior.</span></span>

### <a name="default"></a><span data-ttu-id="24eaa-215">既定値</span><span class="sxs-lookup"><span data-stu-id="24eaa-215">Default</span></span>

<span data-ttu-id="24eaa-216">NavigationView の既定のアダプティブ動作小さいウィンドウの幅を大きなウィンドウの幅で展開された左側のウィンドウ、普通サイズのウィンドウの幅でアイコン専用の左側のナビゲーション ウィンドウとハンバーガー メニュー ボタンを表示することです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-216">The default adaptive behavior of NavigationView is to show an expanded left pane on large window widths, a left icon-only nav pane on medium window widths, and a hamburger menu button on small window widths.</span></span> <span data-ttu-id="24eaa-217">アダプティブ動作のためのウィンドウ サイズについて詳しくは、[画面サイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24eaa-217">For more information about window sizes for adaptive behavior, see [Screen sizes and breakpoints](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

![gif 左のナビゲーションの既定のアダプティブ動作](images/displaymode-auto.png)

```xaml
<NavigationView />
```

### <a name="minimal"></a><span data-ttu-id="24eaa-219">最小</span><span class="sxs-lookup"><span data-stu-id="24eaa-219">Minimal</span></span>

<span data-ttu-id="24eaa-220">大きなウィンドウの幅と両方大小の普通サイズのウィンドウの幅をハンバーガー メニューで展開された左側のウィンドウを使用する 2 つ目の一般的なアダプティブ パターンです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-220">A second common adaptive pattern is to use an expanded left pane on large window widths, and a hamburger menu on both medium and small window widths.</span></span>

![gif 左のナビゲーションのアダプティブ動作 2](images/adaptive-behavior-minimal.png)

```xaml
<NavigationView CompactModeThresholdWidth="1008" ExpandedModeThresholdWidth="1007" />
```

<span data-ttu-id="24eaa-222">このときをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-222">We recommend this when:</span></span>

- <span data-ttu-id="24eaa-223">小さいウィンドウの幅をアプリのコンテンツを追加する領域がしたいです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-223">You desire more space for app content on smaller window widths.</span></span>
- <span data-ttu-id="24eaa-224">アイコンを含む、ナビゲーションのカテゴリを明確に表示できません。</span><span class="sxs-lookup"><span data-stu-id="24eaa-224">Your navigation categories cannot be clearly represented with icons.</span></span>

### <a name="compact"></a><span data-ttu-id="24eaa-225">コンパクト</span><span class="sxs-lookup"><span data-stu-id="24eaa-225">Compact</span></span>

<span data-ttu-id="24eaa-226">3 番目の一般的なアダプティブ パターンでは、大きなウィンドウの幅と両方大小の普通サイズのウィンドウの幅をアイコン専用の左側のナビゲーション ウィンドウで展開された左側のウィンドウを使用します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-226">A third common adaptive pattern is to use an expanded left pane on large window widths, and a left icon-only nav pane on both medium and small window widths.</span></span> <span data-ttu-id="24eaa-227">これの良い例では、メール アプリです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-227">A good example of this is the Mail app.</span></span>

![gif 左のナビゲーションのアダプティブ動作 3](images/adaptive-behavior-compact.png)

```xaml
<NavigationView CompactModeThresholdWidth="0" ExpandedModeThresholdWidth="1007" />
```

<span data-ttu-id="24eaa-229">このときをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-229">We recommend this when:</span></span>

- <span data-ttu-id="24eaa-230">常に画面上のすべてのナビゲーション オプションを表示するのには重要です。</span><span class="sxs-lookup"><span data-stu-id="24eaa-230">It is important to always show all navigation options on screen.</span></span>
- <span data-ttu-id="24eaa-231">ナビゲーションのカテゴリは、アイコンを含む明確に表すことができます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-231">your navigation categories can be clearly represented with icons.</span></span>

### <a name="no-adaptive-behavior"></a><span data-ttu-id="24eaa-232">アダプティブ動作がないです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-232">No adaptive behavior</span></span>

<span data-ttu-id="24eaa-233">場合がありますすべてのすべてのアダプティブ動作をしない出す可能性があります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-233">Sometimes you may not desire any adaptive behavior at all.</span></span> <span data-ttu-id="24eaa-234">展開、常にコンパクトまたは最小限常に常にウィンドウを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-234">You can set the pane to be always expanded, always compact, or always minimal.</span></span>

![gif 左のナビゲーションのアダプティブ動作 4](images/adaptive-behavior-none.png)

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

### <a name="top-to-left-navigation"></a><span data-ttu-id="24eaa-236">左側のナビゲーションを上</span><span class="sxs-lookup"><span data-stu-id="24eaa-236">Top to left navigation</span></span>

<span data-ttu-id="24eaa-237">大きなウィンドウのサイズと小さなの左側のナビゲーションでの上部のナビゲーションの使用をお勧めします。 ウィンドウのサイズを場合。</span><span class="sxs-lookup"><span data-stu-id="24eaa-237">We recommend using top navigation on large window sizes and left navigation on small window sizes when:</span></span>

- <span data-ttu-id="24eaa-238">、一緒に表示される均等に重要なトップレベルのナビゲーション カテゴリのセットがある場合に重要度が同じ左側のナビゲーションを折りたたむこのセットの 1 つのカテゴリが画面に収まらない場合、などを設定します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-238">You have a set of equally important top-level navigation categories to be displayed together, such that if one category in this set doesn't fit on screen, you collapse to left navigation to give them equal importance.</span></span>
- <span data-ttu-id="24eaa-239">小さいウィンドウ サイズにできるだけ領域がかなりコンテンツを維持したいです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-239">You wish to preserve as much content space as possible in small window sizes.</span></span>

<span data-ttu-id="24eaa-240">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-240">Here is an example:</span></span>

![gif 上または左側のナビゲーションのアダプティブ動作 1](images/navigation-top-to-left.png)

```xaml
<Grid >
    <VisualStateManager.VisualStateGroups>
        <VisualStateGroup>
            <VisualState>
                <VisualState.StateTriggers>
                    <AdaptiveTrigger MinWindowWidth="{x:Bind NavigationViewControl.CompactModeThresholdWidth}" />
                </VisualState.StateTriggers>

                <VisualState.Setters>
                    <Setter Target="NavigationViewControl.PaneDisplayMode" Value="Top"/>
                </VisualState.Setters>
            </VisualState>
        </VisualStateGroup>
    </VisualStateManager.VisualStateGroups>

    <NavigationView x:Name="NavigationViewControl" >
        <NavigationView.MenuItems>
            <NavigationViewItem Content="A" x:Name="A" />
            <NavigationViewItem Content="B" x:Name="B" />
            <NavigationViewItem Content="C" x:Name="C" />
        </NavigationView.MenuItems>
    </NavigationView>
</Grid>

```

<span data-ttu-id="24eaa-242">場合によってアプリは、上部のウィンドウの左側のウィンドウを別のデータをバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-242">Sometimes apps need to bind different data to the top pane and left pane.</span></span> <span data-ttu-id="24eaa-243">多くの場合、左側のウィンドウより多くのナビゲーション要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="24eaa-243">Often the left pane includes more navigation elements.</span></span>

<span data-ttu-id="24eaa-244">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-244">Here is an example:</span></span>

![gif 上または左側のナビゲーションのアダプティブ動作 2](images/navigation-top-to-left2.png)

```xaml
<Page >
    <Page.Resources>
        <DataTemplate x:name="navItem_top_temp" x:DataType="models:Item">
            <NavigationViewItem Background= Icon={x:Bind TopIcon}, Content={x:Bind TopContent}, Visibility={x:Bind TopVisibility} />
        </DataTemplate>

        <DataTemplate x:name="navItem_temp" x:DataType="models:Item">
            <NavigationViewItem Icon={x:Bind Icon}, Content={x:Bind Content}, Visibility={x:Bind Visibility} />
        </DataTemplate>
        
        <services:NavViewDataTemplateSelector x:Key="navview_selector" 
              NavItemTemplate="{StaticResource navItem_temp}" 
              NavItemTopTemplate="{StaticResource navItem_top_temp}" 
              NavPaneDisplayMode="{x:Bind NavigationViewControl.PaneDisplayMode}">
        </services:NavViewDataTemplateSelector>
    </Page.Resources>

    <Grid >
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="{x:Bind NavigationViewControl.CompactModeThresholdWidth}" />
                    </VisualState.StateTriggers>

                    <VisualState.Setters>
                        <Setter Target="NavigationViewControl.PaneDisplayMode" Value="Top"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <NavView x:Name='NavigationViewControl' MenuItemsSource={x:Bind items}   
                 PanePosition = "Top" MenuItemTemplateSelector="navview_selector" />
    </Grid>
</Page>

```

```csharp
ObservableCollection<Item> items = new ObservableCollection<Item>();
items.Add(new Item() {
    Content = "Aa",
    TopContent ="A",
    Icon = new BitmapIcon() { UriSource = new Uri("ms-appx:///testimage.jpg") },
    TopIcon = new BitmapIcon(),
    ItemVisibility = Visibility.Visible,
    TopItemVisiblity = Visibility.Visible 
});
items.Add(new Item() {
    Content = "Bb",
    TopContent = "B",
    Icon = new BitmapIcon() { UriSource = new Uri("ms-appx:///testimage.jpg") },
    TopIcon = new BitmapIcon(),
    ItemVisibility = Visibility.Visible,
    TopItemVisiblity = Visibility.Visible 
});
items.Add(new Item() {
    Content = "Cc",
    TopContent = "C",
    Icon = new BitmapIcon() { UriSource = new Uri("ms-appx:///testimage.jpg") },
    TopIcon = new BitmapIcon(),
    ItemVisibility = Visibility.Visible,
    TopItemVisiblity = Visibility.Visible 
});

public class NavViewDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate NavItemTemplate { get; set; }

        public DataTemplate NavItemTopTemplate { get; set; }    

     public NavigationViewPaneDisplayMode NavPaneDisplayMode { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            Item currItem = item as Item;
            if (NavPaneDisplayMode == NavigationViewPanePosition.Top)
                return NavItemTopTemplate;
            else 
                return NavItemTemplate;
        }   

    }

```

## <a name="interaction"></a><span data-ttu-id="24eaa-246">操作</span><span class="sxs-lookup"><span data-stu-id="24eaa-246">Interaction</span></span>

<span data-ttu-id="24eaa-247">ウィンドウのナビゲーション項目をユーザーがタップすると、選択された項目が NavigationView によって表示されて、[ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-247">When users tap on a navigation item in the Pane, NavigationView will show that item as selected and will raise an [ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) event.</span></span> <span data-ttu-id="24eaa-248">タップにより新しいアイテムが選択されると、NavigationView でさらに [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-248">If the tap results in a new item being selected, NavigationView will also raise a [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) event.</span></span>

<span data-ttu-id="24eaa-249">アプリは、このユーザー操作に応じてヘッダーとコンテンツを適切な情報で更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="24eaa-249">Your app is responsible for updating the Header and Content with appropriate information in response to this user interaction.</span></span> <span data-ttu-id="24eaa-250">また、プログラムによってナビゲーション項目からコンテンツに[フォーカス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.FocusState) を移動することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-250">In addition, we recommend programmatically moving [focus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.FocusState) from the navigation item to the content.</span></span> <span data-ttu-id="24eaa-251">読み込み時に最初のフォーカスを設定することで、ユーザー フローが合理化され、予測されるキーボード フォーカスの移動回数が最小限に抑えられます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-251">By setting initial focus on load, you streamline the user flow and minimize the expected number of keyboard focus moves.</span></span>

### <a name="tabs"></a><span data-ttu-id="24eaa-252">タブ</span><span class="sxs-lookup"><span data-stu-id="24eaa-252">Tabs</span></span>

<span data-ttu-id="24eaa-253">タブのモデルでは、選択とフォーカスが関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-253">In the tabs model, selection and focus are tied.</span></span> <span data-ttu-id="24eaa-254">通常フォーカスが選択範囲を変えてはも動作を確認します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-254">An action that normally shifts focus would also shift selection.</span></span> <span data-ttu-id="24eaa-255">次の例では、適切なポイントは選択インジケーターからへの移行ディスプレイ拡大鏡します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-255">In the below example, right arrowing would move the selection indicator from Display to Magnifier.</span></span> <span data-ttu-id="24eaa-256">[SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.selectionfollowsfocus)プロパティを有効に設定して、これを実現することができます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-256">You can achieve this by setting the [SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.selectionfollowsfocus) property to Enabled.</span></span>

![テキストのみの最上位 navview のスクリーン ショット](images/nav-tabs.png)

<span data-ttu-id="24eaa-258">ここでは XAML の例は、その。</span><span class="sxs-lookup"><span data-stu-id="24eaa-258">Here is the example XAML for that:</span></span>

```xaml
<NavigationView PanePosition="Top" SelectionFollowsFocus="Enabled" >
   <NavigationView.MenuItems>
        <NavigationViewItem Content="Display" />
        <NavigationViewItem Content="Magnifier"  />
        <NavigationViewItem Content="Keyboard" />
    </NavigationView.MenuItems>
</NavigationView>

```

<span data-ttu-id="24eaa-259">タブの選択を変更する場合は、コンテンツを入れ替える、フレームの[NavigateWithOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame.NavigateToType)メソッドを使ってを False に設定した FrameNavigationOptions.IsNavigationStackEnabled と NavigateOptions.TransitionInfoOverride が適切な側面を側に設定スライドのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="24eaa-259">To swap out content when changing tab selection, you can use Frame's [NavigateWithOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame.NavigateToType) method with FrameNavigationOptions.IsNavigationStackEnabled set to False, and NavigateOptions.TransitionInfoOverride set to the appropriate side-to-side slide animation.</span></span> <span data-ttu-id="24eaa-260">例については、次の[コード例](#code-example)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="24eaa-260">For an example, see the [code example](#code-example) below.</span></span>

<span data-ttu-id="24eaa-261">既定のスタイルを変更する場合は、NavigationView の[MenuItemContainerStyle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemcontainerstyle)プロパティを上書きすることができます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-261">If you wish to change the default Style, you can override NavigationView's [MenuItemContainerStyle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemcontainerstyle) property.</span></span> <span data-ttu-id="24eaa-262">さまざまなデータ テンプレートを指定する、[それに続く](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemtemplate)プロパティを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-262">You can also set the [MenuItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemtemplate) property to specify a different data template.</span></span>

## <a name="backwards-navigation"></a><span data-ttu-id="24eaa-263">逆方向のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-263">Backwards navigation</span></span>

<span data-ttu-id="24eaa-264">NavigationView には組み込みの [戻る] ボタンがあります。これは、次のプロパティで有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-264">NavigationView has a built-in back button, which can be enabled with the following properties:</span></span>

- <span data-ttu-id="24eaa-265">[**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) は既定で NavigationViewBackButtonVisible 列挙と「自動」になっています。</span><span class="sxs-lookup"><span data-stu-id="24eaa-265">[**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) is a NavigationViewBackButtonVisible enum and "Auto" by default.</span></span> <span data-ttu-id="24eaa-266">[戻る] ボタンの表示/非表示を切り替えるために使用します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-266">It is used to show/hide the back button.</span></span> <span data-ttu-id="24eaa-267">ボタンが表示されていない場合は、[戻る] ボタンを描画するための領域は折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-267">When the button is not visible, the space for drawing the back button will be collapsed.</span></span>
- <span data-ttu-id="24eaa-268">[**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) は既定では false に設定されており、[戻る] ボタンの状態を切り替えるために使用できます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-268">[**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) is false by default and can be used to toggle the back button states.</span></span>
- <span data-ttu-id="24eaa-269">[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) はユーザーが [戻る] ボタンをクリックした場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-269">[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) is fired when a user clicks on the back button.</span></span>
    - <span data-ttu-id="24eaa-270">最小/コンパクト モードで NavigationView.Pane がポップアップとして開いているときに [戻る] ボタンをクリックすると、ウィンドウが閉じ、代わりに **PaneClosing** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-270">In Minimal/Compact mode, when the NavigationView.Pane is open as a flyout, clicking the back button will close the Pane and fire **PaneClosing** event instead.</span></span>
    - <span data-ttu-id="24eaa-271">IsBackEnabled が false の場合は発生しません。</span><span class="sxs-lookup"><span data-stu-id="24eaa-271">Not fired if IsBackEnabled is false.</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="24eaa-272">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-272">Left nav</span></span></b><br>
    ![NavigationView の"戻る"ボタンを左のナビゲーション](images/leftnav-back.png)
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="24eaa-274">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="24eaa-274">Top nav</span></span></b><br>
    ![上部のナビゲーションで NavigationView の戻るボタン](images/topnav-back.png)
    :::column-end:::
:::row-end:::

## <a name="code-example"></a><span data-ttu-id="24eaa-276">コードの例</span><span class="sxs-lookup"><span data-stu-id="24eaa-276">Code example</span></span>

> [!NOTE]
> <span data-ttu-id="24eaa-277">NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="24eaa-277">NavigationView should serve as the root container of your app, as this control is designed to span the full width and height of the app window.</span></span>
<span data-ttu-id="24eaa-278">その動作を変更する必要がある場合は、[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) プロパティと [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) プロパティを使用して、ナビゲーション ビューで表示モードが変わる幅をオーバーライドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="24eaa-278">You can override the widths at which the navigation view changes display modes by using the [CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) and [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) properties.</span></span>

<span data-ttu-id="24eaa-279">大規模なウィンドウ サイズの上部のナビゲーション ウィンドウと小さなウィンドウ サイズの左側のナビゲーション ウィンドウの両方で NavigationView を組み込む方法のエンド ツー エンドの例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-279">The following is an end-to-end example of how you can incorporate NavigationView with both a top navigation pane on large window sizes and a left navigation pane on small window sizes.</span></span>

<span data-ttu-id="24eaa-280">このサンプルで頻繁に新しいナビゲーションのカテゴリを選択するエンドユーザーと考えてためします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-280">In this sample, we expect end users to frequently select new navigation categories, and so we:</span></span>

- <span data-ttu-id="24eaa-281">有効に[SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-281">Set the [SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion) property to Enabled</span></span>
- <span data-ttu-id="24eaa-282">ナビゲーション履歴に追加しないでフレームのナビゲーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-282">Use Frame navigations that do not add to the navigation stack.</span></span>
- <span data-ttu-id="24eaa-283">ゲームパッドの左/右バンパーがあるかどうか、アプリのトップレベルのナビゲーションのカテゴリをナビゲートを示すために使用される[ShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティを既定値を保持します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-283">Keep the default value on the [ShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion) property, which is used to indicate if left/right bumpers on a gamepad navigate the top-level navigation categories of your app.</span></span> <span data-ttu-id="24eaa-284">既定では"WhenSelectionFollowsFocus です"。</span><span class="sxs-lookup"><span data-stu-id="24eaa-284">The default is "WhenSelectionFollowsFocus".</span></span> <span data-ttu-id="24eaa-285">可能なその他の値は、「しない」と「常に」します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-285">The other possible values are "Always" and "Never".</span></span>

<span data-ttu-id="24eaa-286">また、前に戻る NavigationView の [戻る] ボタンによるナビゲーションを実装する方法についても説明します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-286">We also demonstrate how to implement backwards navigation with NavigationView's back button.</span></span>

<span data-ttu-id="24eaa-287">サンプルの内容のレコーディングを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-287">Here's a recording of what the sample demonstrates:</span></span>

![NavigationView エンド ツー エンドのサンプル](images/nav-code-example.gif)

<span data-ttu-id="24eaa-289">サンプル コードを次に示します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-289">Here's the sample code:</span></span>

> [!NOTE]
> <span data-ttu-id="24eaa-290">[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`xmlns:controls="using:Microsoft.UI.Xaml.Controls"`します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-290">If you're using the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/), then you'll need to add a reference to the toolkit: `xmlns:controls="using:Microsoft.UI.Xaml.Controls"`.</span></span>

```xaml
<Page
    x:Class="NavigationViewSample.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:NavigationViewSample"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d">

    <Grid Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
        <VisualStateManager.VisualStateGroups>
            <VisualStateGroup>
                <VisualState>
                    <VisualState.StateTriggers>
                        <AdaptiveTrigger MinWindowWidth="{x:Bind NavView.CompactModeThresholdWidth}" />
                    </VisualState.StateTriggers>

                    <VisualState.Setters>
                        <Setter Target="NavView.PaneDisplayMode" Value="Top"/>
                    </VisualState.Setters>
                </VisualState>
            </VisualStateGroup>
        </VisualStateManager.VisualStateGroups>

        <NavigationView x:Name="NavView"
                    SelectionFollowsFocus="Enabled"
                    ItemInvoked="NavView_ItemInvoked"
                    IsSettingsVisible="True"
                    Loaded="NavView_Loaded"
                    BackRequested="NavView_BackRequested"
                    Header="Welcome">

            <NavigationView.MenuItems>
                <NavigationViewItem Content="Home" x:Name="home" Tag="home">
                    <NavigationViewItem.Icon>
                        <FontIcon Glyph="&#xE10F;"/>
                    </NavigationViewItem.Icon>
                </NavigationViewItem>
                <NavigationViewItemSeparator/>
                <NavigationViewItemHeader Content="Main pages"/>
                <NavigationViewItem Icon="AllApps" Content="Apps" x:Name="apps" Tag="apps"/>
                <NavigationViewItem Icon="Video" Content="Games" x:Name="games" Tag="games"/>
                <NavigationViewItem Icon="Audio" Content="Music" x:Name="music" Tag="music"/>
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

            <Frame x:Name="ContentFrame" Margin="24"/>

        </NavigationView>
    </Grid>
</Page>
```

> [!NOTE]
> <span data-ttu-id="24eaa-291">[Windows UI のライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`using MUXC = Microsoft.UI.Xaml.Controls;`します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-291">If you're using the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/), then you'll need to add a reference to the toolkit: `using MUXC = Microsoft.UI.Xaml.Controls;`.</span></span>

```csharp
// List of ValueTuple holding the Navigation Tag and the relative Navigation Page 
private readonly IList<(string Tag, Type Page)> _pages = new List<(string Tag, Type Page)>
{
    ("home", typeof(HomePage)),
    ("apps", typeof(AppsPage)),
    ("games", typeof(GamesPage)),
    ("music", typeof(MusicPage)),
};

private void NavView_Loaded(object sender, RoutedEventArgs e)
{
    // You can also add items in code behind
    NavView.MenuItems.Add(new NavigationViewItemSeparator());
    NavView.MenuItems.Add(new NavigationViewItem
    {
        Content = "My content",
        Icon = new SymbolIcon(Symbol.Folder),
        Tag = "content"
    });
    _pages.Add(("content", typeof(MyContentPage)));

    ContentFrame.Navigated += On_Navigated;

    // NavView doesn't load any page by default: you need to specify it
    NavView_Navigate("home");

    // Add keyboard accelerators for backwards navigation
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

private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
{

    if (args.IsSettingsInvoked)
        ContentFrame.Navigate(typeof(SettingsPage));
    else
    {
        // Getting the Tag from Content (args.InvokedItem is the content of NavigationViewItem)
        var navItemTag = NavView.MenuItems
            .OfType<NavigationViewItem>()
            .First(i => args.InvokedItem.Equals(i.Content))
            .Tag.ToString();

        NavView_Navigate(navItemTag);
    }
}

private void NavView_Navigate(string navItemTag)
{
    var item = _pages.First(p => p.Tag.Equals(navItemTag));
    ContentFrame.Navigate(item.Page);
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
    if (!ContentFrame.CanGoBack)
        return false;

    // Don't go back if the nav pane is overlayed
    if (NavView.IsPaneOpen &&
        (NavView.DisplayMode == NavigationViewDisplayMode.Compact ||
        NavView.DisplayMode == NavigationViewDisplayMode.Minimal))
        return false;

    ContentFrame.GoBack();
    return true;
}

private void On_Navigated(object sender, NavigationEventArgs e)
{
    NavView.IsBackEnabled = ContentFrame.CanGoBack;

    if (ContentFrame.SourcePageType == typeof(SettingsPage))
    {
        // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag
        NavView.SelectedItem = (NavigationViewItem)NavView.SettingsItem;
    }
    else
    {
        var item = _pages.First(p => p.Page == e.SourcePageType);

        NavView.SelectedItem = NavView.MenuItems
            .OfType<NavigationViewItem>()
            .First(n => n.Tag.Equals(item.Tag));
    }
}
```

## <a name="customizing-backgrounds"></a><span data-ttu-id="24eaa-292">背景をカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="24eaa-292">Customizing backgrounds</span></span>

<span data-ttu-id="24eaa-293">NavigationView のメイン領域の背景を変更するには、その `Background` プロパティを目的のブラシに設定します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-293">To change the background of NavigationView's main area, set its `Background` property to your preferred brush.</span></span>

<span data-ttu-id="24eaa-294">NavigationView が上を最小限に抑えながら、またはコンパクト モードの場合、ウィンドウの背景はアプリ内アクリルを示します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-294">The Pane's background shows in-app acrylic when NavigationView is in Top, Minimal, or Compact mode.</span></span> <span data-ttu-id="24eaa-295">この動作を更新したり、ウィンドウのアクリルの外観をカスタマイズしたりするには、App.xaml で上書きすることで、2 つのテーマ リソースを変更します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-295">To update this behavior or customize the appearance of your Pane's acrylic, modify the two theme resources by overwriting them in your App.xaml.</span></span>

```xaml
<Application.Resources>
    <ResourceDictionary>
        <AcrylicBrush x:Key="NavigationViewDefaultPaneBackground"
        BackgroundSource="Backdrop" TintColor="Yellow" TintOpacity=".6"/>
        <AcrylicBrush x:Key="NavigationViewTopPaneBackground"
        BackgroundSource="Backdrop" TintColor="Yellow" TintOpacity=".6"/>
        <AcrylicBrush x:Key="NavigationViewExpandedPaneBackground"
        BackgroundSource="HostBackdrop" TintColor="Orange" TintOpacity=".8"/>
    </ResourceDictionary>
</Application.Resources>
```

## <a name="scroll-content-under-top-pane"></a><span data-ttu-id="24eaa-296">上部のウィンドウの下にスクロール コンテンツ</span><span class="sxs-lookup"><span data-stu-id="24eaa-296">Scroll content under top pane</span></span>

<span data-ttu-id="24eaa-297">シームレスな外観と操作感、ScrollViewer を使用するページは、アプリがいて、ナビゲーション ウィンドウは、上部に配置すると、お勧め上部のナビゲーション ウィンドウの下にあるコンテンツのスクロールします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-297">For a seamless look+feel, if your app has pages that use a ScrollViewer and your navigation pane is top positioned, we recommend having the content scroll underneath the top nav pane.</span></span>

<span data-ttu-id="24eaa-298">これを行うには、 [CanContentRenderOutsideBounds](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer.cancontentrenderoutsidebounds)プロパティを true に関連する ScrollViewer を設定します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-298">This can be achieved by setting the [CanContentRenderOutsideBounds](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer.cancontentrenderoutsidebounds) property on the relevant ScrollViewer to true.</span></span>

![navview スクロールのナビゲーション ウィンドウ](images/nav-scroll-content.png)

<span data-ttu-id="24eaa-300">非常に長いスクロールするコンテンツは、アプリがある、場合は、上部のナビゲーション ウィンドウにアタッチし、スムーズなサーフェスを形成する固定ヘッダーを組み込むことを検討してください。</span><span class="sxs-lookup"><span data-stu-id="24eaa-300">If your app has very long scrolling content, you may want to consider incorporating sticky headers that attach to the top nav pane and form a smooth surface.</span></span> 

![navview スクロール固定ヘッダー](images/nav-scroll-stickyheader.png)

<span data-ttu-id="24eaa-302">これを実現するには NavigationView を[ContentOverlay](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="24eaa-302">You can achieve this by setting the [ContentOverlay](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay) property on NavigationView.</span></span> 

<span data-ttu-id="24eaa-303">場合によっては、ユーザーは、下へスクロール場合、NavigationView で[IsPaneVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを false に設定して、ナビゲーション ウィンドウを非表示にします。</span><span class="sxs-lookup"><span data-stu-id="24eaa-303">Sometimes, if the user is scrolling down, you may want to hide the nav pane, achieved by setting the [IsPaneVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay) property on NavigationView to false.</span></span>

![navview スクロールの非表示のナビゲーション](images/nav-scroll-hidepane.png)

## <a name="related-topics"></a><span data-ttu-id="24eaa-305">関連トピック</span><span class="sxs-lookup"><span data-stu-id="24eaa-305">Related topics</span></span>

- [<span data-ttu-id="24eaa-306">NavigationView クラス</span><span class="sxs-lookup"><span data-stu-id="24eaa-306">NavigationView class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [<span data-ttu-id="24eaa-307">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="24eaa-307">Master/details</span></span>](master-details.md)
- [<span data-ttu-id="24eaa-308">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="24eaa-308">Pivot control</span></span>](tabs-pivot.md)
- [<span data-ttu-id="24eaa-309">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="24eaa-309">Navigation basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="24eaa-310">UWP 用 Fluent Design の概要</span><span class="sxs-lookup"><span data-stu-id="24eaa-310">Fluent Design for UWP overview</span></span>](../fluent-design-system/index.md)