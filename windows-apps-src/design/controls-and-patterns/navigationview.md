---
author: serenaz
Description: NavigationView is an adaptive control that implements top-level navigation patterns for your app.
title: ナビゲーション ビュー
template: detail.hbs
ms.author: sezhen
ms.date: 08/06/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
dev-contact: ''
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 4c0857005d584b1fde0eb52a6ab0ef5ec29eaf44
ms.sourcegitcommit: f2f4820dd2026f1b47a2b1bf2bc89d7220a79c1a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/22/2018
ms.locfileid: "2791994"
---
# <a name="navigation-view-preview-version"></a><span data-ttu-id="c2614-103">ナビゲーション ビュー (プレビュー版)</span><span class="sxs-lookup"><span data-stu-id="c2614-103">Navigation view (Preview version)</span></span>

> <span data-ttu-id="c2614-104">**これは、プレビューのバージョン**: NavigationView コントロールを開発中の新しいバージョンについて説明します。</span><span class="sxs-lookup"><span data-stu-id="c2614-104">**This is a preview version**: This article describes a new version of the NavigationView control that's still in development.</span></span> <span data-ttu-id="c2614-105">それを使用するには、] が必要になった[最新の Windows 内部ビルドと SDK](https://insider.windows.com/for-developers/) 」または「 [Windows UI ライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)です。</span><span class="sxs-lookup"><span data-stu-id="c2614-105">To use it now, you need the [latest Windows Insider build and SDK](https://insider.windows.com/for-developers/) or the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span>

<span data-ttu-id="c2614-106">NavigationView コントロールでは、アプリの最上位レベルのナビゲーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="c2614-106">The NavigationView control provides top-level navigation for your app.</span></span> <span data-ttu-id="c2614-107">適応するようにさまざまな画面サイズのサポートに複数のナビゲーションのスタイル。</span><span class="sxs-lookup"><span data-stu-id="c2614-107">It adapts to a variety of screen sizes supports multiple navigation styles.</span></span>

> <span data-ttu-id="c2614-108">**Windows UI ライブラリ Api**: [Microsoft.UI.Xaml.Controls.NavigationView クラス](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="c2614-108">**Windows UI Library APIs**: [Microsoft.UI.Xaml.Controls.NavigationView class](/uwp/api/microsoft.ui.xaml.controls.navigationview)</span></span>

> <span data-ttu-id="c2614-109">**Platform Api**: [Windows.UI.Xaml.Controls.NavigationView クラス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)</span><span class="sxs-lookup"><span data-stu-id="c2614-109">**Platform APIs**: [Windows.UI.Xaml.Controls.NavigationView class](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)</span></span>

## <a name="get-the-windows-ui-library"></a><span data-ttu-id="c2614-110">Windows の UI ライブラリを取得します。</span><span class="sxs-lookup"><span data-stu-id="c2614-110">Get the Windows UI Library</span></span>

<span data-ttu-id="c2614-111">このコントロールは、Windows UI ライブラリで、新しいコントロールと UWP アプリの UI の機能を含む NuGet パッケージの一部として含める。</span><span class="sxs-lookup"><span data-stu-id="c2614-111">This control is included as part of the Windows UI Library, a NuGet package that contains new controls and UI features for UWP apps.</span></span> <span data-ttu-id="c2614-112">インストール方法など、さらに詳しい情報は、 [Windows UI ライブラリの概要](https://docs.microsoft.com/uwp/toolkits/winui/)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c2614-112">For more info, including installation instructions, see the  [Windows UI Library overview](https://docs.microsoft.com/uwp/toolkits/winui/).</span></span> 

## <a name="navigation-styles"></a><span data-ttu-id="c2614-113">ナビゲーションのスタイル</span><span class="sxs-lookup"><span data-stu-id="c2614-113">Navigation styles</span></span>

<span data-ttu-id="c2614-114">NavigationView がサポートしています。</span><span class="sxs-lookup"><span data-stu-id="c2614-114">NavigationView supports:</span></span>

**<span data-ttu-id="c2614-115">左側のナビゲーション ウィンドウまたは [メニュー</span><span class="sxs-lookup"><span data-stu-id="c2614-115">Left navigation pane or menu</span></span>**

![ナビゲーション ウィンドウの展開](images/displaymode-left.png)

**<span data-ttu-id="c2614-117">上部のナビゲーション ウィンドウまたは [メニュー</span><span class="sxs-lookup"><span data-stu-id="c2614-117">Top navigation pane or menu</span></span>**

![上部のナビゲーション](images/displaymode-top.png)

## <a name="is-this-the-right-control"></a><span data-ttu-id="c2614-119">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="c2614-119">Is this the right control?</span></span>

<span data-ttu-id="c2614-120">適している適応ナビゲーション コントロールを NavigationView には。</span><span class="sxs-lookup"><span data-stu-id="c2614-120">NavigationView is an adaptive navigation control that works well for:</span></span>

- <span data-ttu-id="c2614-121">アプリ全体で一貫したナビゲーション エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="c2614-121">Providing a consistent navigational experience throughout your app.</span></span>
- <span data-ttu-id="c2614-122">小さい windows で画面を保持します。</span><span class="sxs-lookup"><span data-stu-id="c2614-122">Preserving screen real estate on smaller windows.</span></span>
- <span data-ttu-id="c2614-123">多くのナビゲーション カテゴリへのアクセスを整理します。</span><span class="sxs-lookup"><span data-stu-id="c2614-123">Organizing access to many navigation categories.</span></span>

<span data-ttu-id="c2614-124">他のナビゲーション コントロール[ナビゲーション設計の基本」](../basics/navigation-basics.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c2614-124">For other navigation controls, see [Navigation design basics](../basics/navigation-basics.md).</span></span>

<span data-ttu-id="c2614-125">ナビゲーションで NavigationView でサポートされていないより複雑な動作が必要な場合、[マスター/詳細](master-details.md) パターンを代わりに検討することもできます。</span><span class="sxs-lookup"><span data-stu-id="c2614-125">If your navigation requires more complex behavior that is not supported by NavigationView, then you might want to consider the [Master/details](master-details.md) pattern instead.</span></span>

:::row:::
    :::column:::
        ![一部の画像](images/XAML-controls-gallery-app-icon.png)
    :::column-end:::
    <span data-ttu-id="c2614-127">::: 列 =「2」::: **XAML コントロール] ギャラリー**</span><span class="sxs-lookup"><span data-stu-id="c2614-127">:::column span="2"::: **XAML Controls Gallery**</span></span><br>
        <span data-ttu-id="c2614-128">をクリックして、XAML コントロール ギャラリー アプリがインストールされている場合は、<a href="xamlcontrolsgallery:/item/NavigationView">次のとおり</a>にアプリを開き、アクションの NavigationView を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c2614-128">If you have the XAML Controls Gallery app installed, click <a href="xamlcontrolsgallery:/item/NavigationView">here</a> to open the app and see NavigationView in action.</span></span>

        <a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT">Get the XAML Controls Gallery app (Microsoft Store)</a><br>
        <a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics">Get the source code (GitHub)</a>
    :::column-end:::
:::row-end:::

## <a name="display-modes"></a><span data-ttu-id="c2614-129">表示モード</span><span class="sxs-lookup"><span data-stu-id="c2614-129">Display modes</span></span>

<span data-ttu-id="c2614-130">さまざまな表示モードに設定できます NavigationView、`PaneDisplayMode`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="c2614-130">NavigationView can be set to different display modes, via the `PaneDisplayMode` property:</span></span>

:::row:::
    :::column:::
    ### Left
    Displays an expanded left positioned pane.
    :::column-end:::
    :::column span="2":::
    ![left nav pane expanded](images/displaymode-left.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="c2614-131">左側のナビゲーションをお勧め場合。</span><span class="sxs-lookup"><span data-stu-id="c2614-131">We recommend left navigation when:</span></span>

- <span data-ttu-id="c2614-132">中程度が高く番号 (5 ~ 10) 同等の最上位のカテゴリの情報があります。</span><span class="sxs-lookup"><span data-stu-id="c2614-132">You have a medium-to-high number (5-10) of equally important top-level navigation categories.</span></span>
- <span data-ttu-id="c2614-133">必要に応じて、非常に目立つナビゲーションの他のアプリのコンテンツの領域が少なくカテゴリに分類します。</span><span class="sxs-lookup"><span data-stu-id="c2614-133">You desire very prominent navigation categories with less space for other app content.</span></span>

:::row:::
    :::column:::
    ### Top
    Displays a top positioned pane.
    :::column-end:::
    :::column span="2":::
    ![top navigation](images/displaymode-top.png)
    :::column-end:::
:::row-end:::

<span data-ttu-id="c2614-134">上部のナビゲーションをお勧め場合。</span><span class="sxs-lookup"><span data-stu-id="c2614-134">We recommend top navigation when:</span></span>

- <span data-ttu-id="c2614-135">5 があるまたは同等の最上位ナビゲーション カテゴリでは、以下を最上位レベルの追加のナビゲーション項目のドロップダウン リストでのオーバーフロー] メニューの [重要度の低い。</span><span class="sxs-lookup"><span data-stu-id="c2614-135">You have 5 or less equally important top-level navigation categories, such that any additional top-level navigation categories that end up in the dropdown overflow menu are considered less important.</span></span>
- <span data-ttu-id="c2614-136">画面上のすべてのナビゲーション オプションを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2614-136">You need to show all navigation options on screen.</span></span>
- <span data-ttu-id="c2614-137">多くの領域を希望するには、アプリのコンテンツにします。</span><span class="sxs-lookup"><span data-stu-id="c2614-137">You desire more space for your app content.</span></span>
- <span data-ttu-id="c2614-138">アイコンは、アプリのナビゲーションのカテゴリを明確に記述ことはできません。</span><span class="sxs-lookup"><span data-stu-id="c2614-138">Icons cannot clearly describe your app's navigation categories.</span></span>

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

### <a name="auto"></a><span data-ttu-id="c2614-139">自動</span><span class="sxs-lookup"><span data-stu-id="c2614-139">Auto</span></span>

![gif 左のナビゲーションの既定の適応動作](images/displaymode-auto.png)

<span data-ttu-id="c2614-141">小さな画面に LeftMinimal、LeftCompact (m)、および大きい画面で、左上に適合します。</span><span class="sxs-lookup"><span data-stu-id="c2614-141">Adapts between LeftMinimal on small screens, LeftCompact on medium screens, and Left on large screens.</span></span> <span data-ttu-id="c2614-142">詳細については、[適応動作](#adaptive-behavior)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c2614-142">See the [adaptive behavior](#adaptive-behavior) section for more information.</span></span>

## <a name="anatomy"></a><span data-ttu-id="c2614-143">構造</span><span class="sxs-lookup"><span data-stu-id="c2614-143">Anatomy</span></span>

<b><span data-ttu-id="c2614-144">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-144">Left nav</span></span></b><br>

![左側の NavigationView セクション](images/leftnav-anatomy.png)

<b><span data-ttu-id="c2614-146">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-146">Top nav</span></span></b><br>

![トップ NavigationView セクション](images/topnav-anatomy.png)

## <a name="pane"></a><span data-ttu-id="c2614-148">ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="c2614-148">Pane</span></span>

<span data-ttu-id="c2614-149">ウィンドウの上部または左側に経由で配置する、`PanePosition`プロパティ。</span><span class="sxs-lookup"><span data-stu-id="c2614-149">The pane can be positioned either on top or on left, via the `PanePosition` property.</span></span>

<span data-ttu-id="c2614-150">ウィンドウの左端と上端の位置の詳細ウィンドウの構造を示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-150">Here is the detailed pane anatomy for the left and top pane positions:</span></span>

<b><span data-ttu-id="c2614-151">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-151">Left nav</span></span></b><br>

![NavigationView 構造](images/navview-pane-anatomy-vertical.png)

1. <span data-ttu-id="c2614-153">メニュー ボタン</span><span class="sxs-lookup"><span data-stu-id="c2614-153">Menu button</span></span>
1. <span data-ttu-id="c2614-154">ナビゲーション アイテム</span><span class="sxs-lookup"><span data-stu-id="c2614-154">Navigation items</span></span>
1. <span data-ttu-id="c2614-155">区切り文字</span><span class="sxs-lookup"><span data-stu-id="c2614-155">Separators</span></span>
1. <span data-ttu-id="c2614-156">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2614-156">Headers</span></span>
1. <span data-ttu-id="c2614-157">(オプション) AutoSuggestBox</span><span class="sxs-lookup"><span data-stu-id="c2614-157">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="c2614-158">(オプション) [設定] ボタン</span><span class="sxs-lookup"><span data-stu-id="c2614-158">Settings button (optional)</span></span>

<b><span data-ttu-id="c2614-159">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-159">Top nav</span></span></b><br>

![NavigationView 構造](images/navview-pane-anatomy-horizontal.png)

1. <span data-ttu-id="c2614-161">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2614-161">Headers</span></span>
1. <span data-ttu-id="c2614-162">ナビゲーション アイテム</span><span class="sxs-lookup"><span data-stu-id="c2614-162">Navigation items</span></span>
1. <span data-ttu-id="c2614-163">区切り文字</span><span class="sxs-lookup"><span data-stu-id="c2614-163">Separators</span></span>
1. <span data-ttu-id="c2614-164">(オプション) AutoSuggestBox</span><span class="sxs-lookup"><span data-stu-id="c2614-164">AutoSuggestBox (optional)</span></span>
1. <span data-ttu-id="c2614-165">(オプション) [設定] ボタン</span><span class="sxs-lookup"><span data-stu-id="c2614-165">Settings button (optional)</span></span>

<span data-ttu-id="c2614-166">ウィンドウの左上隅の [戻る] ボタンが表示されますが、NavigationView でコンテンツが自動的に戻るスタックに追加されません。</span><span class="sxs-lookup"><span data-stu-id="c2614-166">The back button appears in the top left-hand corner of the pane, but NavigationView does not automatically add content to the back stack.</span></span> <span data-ttu-id="c2614-167">下位のナビゲーションを有効にする] を参照してください、[下位ナビゲーション](#backwards-navigation)] セクション。</span><span class="sxs-lookup"><span data-stu-id="c2614-167">To enable backwards navigation, see the [backwards navigation](#backwards-navigation) section.</span></span>

<span data-ttu-id="c2614-168">NavigationView ウィンドウを含めることもできます。</span><span class="sxs-lookup"><span data-stu-id="c2614-168">The NavigationView pane can also contain:</span></span>

1. <span data-ttu-id="c2614-169">ナビゲーション アイテム、特定のページに移動するための[NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem)フォームにします。</span><span class="sxs-lookup"><span data-stu-id="c2614-169">Navigation items, in the form of [NavigationViewItem](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitem), for navigating to specific pages.</span></span>
2. <span data-ttu-id="c2614-170">区切り記号、 [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator)を表すナビゲーション アイテムをグループ化します。</span><span class="sxs-lookup"><span data-stu-id="c2614-170">Separators, in the form of [NavigationViewItemSeparator](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator), for grouping navigation items.</span></span> <span data-ttu-id="c2614-171">0 領域としての区切り記号を表示するには、[透明度](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity)のプロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="c2614-171">Set the [Opacity](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemseparator.opacity) property to 0 to render the separator as space.</span></span>
3. <span data-ttu-id="c2614-172">ヘッダー、アイテムのグループに付けるラベルの[NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader)を表す。</span><span class="sxs-lookup"><span data-stu-id="c2614-172">Headers, in the form of [NavigationViewItemHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationviewitemheader), for labeling groups of items.</span></span>
4. <span data-ttu-id="c2614-173">省略可能な[AutoSuggestBox](auto-suggest-box.md)のアプリ レベルの検索を許可します。</span><span class="sxs-lookup"><span data-stu-id="c2614-173">An optional [AutoSuggestBox](auto-suggest-box.md) to allow for app-level search.</span></span>
5. <span data-ttu-id="c2614-174">[アプリ設定](../app-settings/app-settings-and-data.md)のエントリ ポイント (オプション)</span><span class="sxs-lookup"><span data-stu-id="c2614-174">An optional entry point for [app settings](../app-settings/app-settings-and-data.md).</span></span> <span data-ttu-id="c2614-175">設定項目を非表示にするには、 [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible)プロパティを使用します。</span><span class="sxs-lookup"><span data-stu-id="c2614-175">To hide the settings item, use the [IsSettingsVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsSettingsVisible) property.</span></span>

<span data-ttu-id="c2614-176">左側のウィンドウが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c2614-176">The left pane contains:</span></span>

6. <span data-ttu-id="c2614-177">ウィンドウを開く/閉じるを切り替えます] メニューをクリックします。</span><span class="sxs-lookup"><span data-stu-id="c2614-177">Menu button to toggle the pane open and close.</span></span> <span data-ttu-id="c2614-178">[IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) プロパティを使うと、ウィンドウが開いたとき、大きなアプリ ウィンドウで、このボタンを非表示にすることを選択できます。</span><span class="sxs-lookup"><span data-stu-id="c2614-178">On larger app windows when the pane is open, you may choose to hide this button using the [IsPaneToggleButtonVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsPaneToggleButtonVisible) property.</span></span>

### <a name="pane-footer"></a><span data-ttu-id="c2614-179">ウィンドウのフッター</span><span class="sxs-lookup"><span data-stu-id="c2614-179">Pane footer</span></span>

<span data-ttu-id="c2614-180">[PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) プロパティに追加された場合の、ウィンドウのフッターの自由形式のコンテンツ。</span><span class="sxs-lookup"><span data-stu-id="c2614-180">Free-form content in the pane’s footer, when added to the [PaneFooter](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneFooter) property</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="c2614-181">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-181">Left nav</span></span></b><br>
    ![フッターの左側のナビゲーションをウィンドウ](images/navview-freeform-footer-left.png)<br>
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="c2614-183">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-183">Top nav</span></span></b><br>
    ![ウィンドウ ヘッダーの上部のナビゲーション](images/navview-freeform-footer-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-header"></a><span data-ttu-id="c2614-185">ウィンドウのヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2614-185">Pane header</span></span>

<span data-ttu-id="c2614-186">[PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader)プロパティを追加すると、ウィンドウのヘッダーのコンテンツをフリー フォーム</span><span class="sxs-lookup"><span data-stu-id="c2614-186">Free-form content in the pane's header, when added to the [PaneHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneHeader) property</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="c2614-187">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-187">Left nav</span></span></b><br>
    ![ウィンドウ ヘッダーの左側のナビゲーション](images/navview-freeform-header-left.png)<br>
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="c2614-189">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-189">Top nav</span></span></b><br>
    ![ウィンドウ ヘッダーの上部のナビゲーション](images/navview-freeform-header-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="pane-content"></a><span data-ttu-id="c2614-191">ウィンドウのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="c2614-191">Pane content</span></span>

<span data-ttu-id="c2614-192">[PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent)プロパティを追加すると、ウィンドウの自由形式の内容</span><span class="sxs-lookup"><span data-stu-id="c2614-192">Free-form content in the pane, when added to the [PaneCustomContent](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PaneCustomContent) property</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="c2614-193">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-193">Left nav</span></span></b><br>
    ![ウィンドウのカスタム contentleft ナビゲーション](images/navview-freeform-pane-left.png)<br>
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="c2614-195">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-195">Top nav</span></span></b><br>
    ![ウィンドウ カスタム コンテンツ上部のナビゲーション](images/navview-freeform-pane-top.png)<br>
    :::column-end:::
:::row-end:::

### <a name="visual-style"></a><span data-ttu-id="c2614-197">視覚スタイル</span><span class="sxs-lookup"><span data-stu-id="c2614-197">Visual style</span></span>

<span data-ttu-id="c2614-198">ハードウェアおよびソフトウェア要件が満たされる NavigationView 自動的にでは、 [Acrylic 数量単価型](../style/acrylic.md)のウィンドウと、左側のウィンドウでのみに[蛍光ペンを表示](../style/reveal.md)します。</span><span class="sxs-lookup"><span data-stu-id="c2614-198">When hardware and software requirements are met, NavigationView automatically uses the [Acrylic material](../style/acrylic.md) in its pane, and [Reveal highlight](../style/reveal.md) only in its left pane.</span></span>

## <a name="header"></a><span data-ttu-id="c2614-199">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c2614-199">Header</span></span>

![ヘッダー領域の navview 標準の画像](images/nav-header.png)

<span data-ttu-id="c2614-201">ヘッダー領域は、左側のウィンドウの位置] の [ナビゲーション] ボタンと垂直方向に配置し、上のウィンドウの位置に、ウィンドウの下にあます。</span><span class="sxs-lookup"><span data-stu-id="c2614-201">The header area is vertically aligned with the navigation button in the left pane position, and lies below the pane in the top pane position.</span></span> <span data-ttu-id="c2614-202">52 の固定の高さがピクセルします。</span><span class="sxs-lookup"><span data-stu-id="c2614-202">It has a fixed height of 52 px.</span></span> <span data-ttu-id="c2614-203">これは、選択されたナビゲーション カテゴリのページ タイトルを保持するためです。</span><span class="sxs-lookup"><span data-stu-id="c2614-203">Its purpose is to hold the page title of the selected nav category.</span></span> <span data-ttu-id="c2614-204">ヘッダーはページ上部に固定され、コンテンツ領域のスクロール クリッピング ポイントとして機能します。</span><span class="sxs-lookup"><span data-stu-id="c2614-204">The header is docked to the top of the page and acts as a scroll clipping point for the content area.</span></span>

<span data-ttu-id="c2614-205">ヘッダーは、NavigationView が最低限の表示モード表示されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2614-205">The header must be visible when NavigationView is in Minimal display mode.</span></span> <span data-ttu-id="c2614-206">ウィンドウの幅をもっと広げて使用される他のモードでは、ヘッダーを非表示にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="c2614-206">You may choose to hide the header in other modes, which are used on larger window widths.</span></span> <span data-ttu-id="c2614-207">これを行うには、[AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) プロパティを **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="c2614-207">To do so, set the [AlwaysShowHeader](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.AlwaysShowHeader) property to **false**.</span></span>

## <a name="content"></a><span data-ttu-id="c2614-208">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="c2614-208">Content</span></span>

![コンテンツ領域の navview 標準の画像](images/nav-content.png)

<span data-ttu-id="c2614-210">コンテンツ領域には、選んだナビゲーション カテゴリのほとんどの情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="c2614-210">The content area is where most of the information for the selected nav category is displayed.</span></span>

<span data-ttu-id="c2614-211">NavigationView が最小モードの場合はコンテンツ領域に 12 ピクセルの余白を設定し、それ以外の場合は 24 ピクセルの余白を設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c2614-211">We recommend 12px margins for your content area when NavigationView is in Minimal mode and 24px margins otherwise.</span></span>

## <a name="adaptive-behavior"></a><span data-ttu-id="c2614-212">アダプティブ動作</span><span class="sxs-lookup"><span data-stu-id="c2614-212">Adaptive behavior</span></span>

<span data-ttu-id="c2614-213">NavigationView は、利用可能な画面領域の大きさに基づいて自動的に表示モードが変わります。</span><span class="sxs-lookup"><span data-stu-id="c2614-213">NavigationView automatically changes its display mode based on the amount of screen space available to it.</span></span> <span data-ttu-id="c2614-214">ただし、適応表示モードの動作をカスタマイズすることがあります。</span><span class="sxs-lookup"><span data-stu-id="c2614-214">However, you might want to customize the adaptive display mode behavior.</span></span>

### <a name="default"></a><span data-ttu-id="c2614-215">既定値</span><span class="sxs-lookup"><span data-stu-id="c2614-215">Default</span></span>

<span data-ttu-id="c2614-216">NavigationView 適応既定では、小さなウィンドウ幅に大きなウィンドウの幅で展開された、左側のウィンドウ、中程度のウィンドウの幅を [アイコンのみの左側のナビゲーション ウィンドウとハンバーガー メニュー ボタンを表示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-216">The default adaptive behavior of NavigationView is to show an expanded left pane on large window widths, a left icon-only nav pane on medium window widths, and a hamburger menu button on small window widths.</span></span> <span data-ttu-id="c2614-217">適応動作のウィンドウのサイズの詳細については、[画面のサイズとブレークポイント](../layout/screen-sizes-and-breakpoints-for-responsive-design.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c2614-217">For more information about window sizes for adaptive behavior, see [Screen sizes and breakpoints](../layout/screen-sizes-and-breakpoints-for-responsive-design.md).</span></span>

![gif 左のナビゲーションの既定の適応動作](images/displaymode-auto.png)

```xaml
<NavigationView />
```

### <a name="minimal"></a><span data-ttu-id="c2614-219">最小</span><span class="sxs-lookup"><span data-stu-id="c2614-219">Minimal</span></span>

<span data-ttu-id="c2614-220">2 番目の一般的な適応パターンでは、大きなウィンドウの幅、および両方中小ウィンドウの幅でハンバーガー メニューを展開した左側のウィンドウを使用します。</span><span class="sxs-lookup"><span data-stu-id="c2614-220">A second common adaptive pattern is to use an expanded left pane on large window widths, and a hamburger menu on both medium and small window widths.</span></span>

![gif の左のナビゲーション適応動作 2](images/adaptive-behavior-minimal.png)

```xaml
<NavigationView CompactModeThresholdWidth="1008" ExpandedModeThresholdWidth="1007" />
```

<span data-ttu-id="c2614-222">このときに行うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c2614-222">We recommend this when:</span></span>

- <span data-ttu-id="c2614-223">必要に応じて、小さなウィンドウの幅のアプリのコンテンツ領域を広くします。</span><span class="sxs-lookup"><span data-stu-id="c2614-223">You desire more space for app content on smaller window widths.</span></span>
- <span data-ttu-id="c2614-224">アイコンを含む、ナビゲーション カテゴリを明確に表示できません。</span><span class="sxs-lookup"><span data-stu-id="c2614-224">Your navigation categories cannot be clearly represented with icons.</span></span>

### <a name="compact"></a><span data-ttu-id="c2614-225">コンパクト</span><span class="sxs-lookup"><span data-stu-id="c2614-225">Compact</span></span>

<span data-ttu-id="c2614-226">3 番目の一般的な適応パターンでは、大きなウィンドウの幅、および両方中小ウィンドウの幅でアイコンのみの左側のナビゲーション ウィンドウの展開の左側のウィンドウを使用します。</span><span class="sxs-lookup"><span data-stu-id="c2614-226">A third common adaptive pattern is to use an expanded left pane on large window widths, and a left icon-only nav pane on both medium and small window widths.</span></span> <span data-ttu-id="c2614-227">この例では、メール アプリです。</span><span class="sxs-lookup"><span data-stu-id="c2614-227">A good example of this is the Mail app.</span></span>

![gif の左のナビゲーション適応動作 3](images/adaptive-behavior-compact.png)

```xaml
<NavigationView CompactModeThresholdWidth="0" ExpandedModeThresholdWidth="1007" />
```

<span data-ttu-id="c2614-229">このときに行うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c2614-229">We recommend this when:</span></span>

- <span data-ttu-id="c2614-230">常に画面上のすべてのナビゲーション オプションを表示するのには重要です。</span><span class="sxs-lookup"><span data-stu-id="c2614-230">It is important to always show all navigation options on screen.</span></span>
- <span data-ttu-id="c2614-231">ナビゲーション カテゴリのアイコンを含む明確に表すことができます。</span><span class="sxs-lookup"><span data-stu-id="c2614-231">your navigation categories can be clearly represented with icons.</span></span>

### <a name="no-adaptive-behavior"></a><span data-ttu-id="c2614-232">適応動作なし</span><span class="sxs-lookup"><span data-stu-id="c2614-232">No adaptive behavior</span></span>

<span data-ttu-id="c2614-233">ありますまったく適応、動作をいない望む可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c2614-233">Sometimes you may not desire any adaptive behavior at all.</span></span> <span data-ttu-id="c2614-234">常に展開された、常にコンパクト、または常に最低限のウィンドウを設定することができます。</span><span class="sxs-lookup"><span data-stu-id="c2614-234">You can set the pane to be always expanded, always compact, or always minimal.</span></span>

![gif の左のナビゲーション適応動作 4](images/adaptive-behavior-none.png)

```xaml
<NavigationView PaneDisplayMode="LeftMinimal" />
```

### <a name="top-to-left-navigation"></a><span data-ttu-id="c2614-236">左側のナビゲーションの先頭へ</span><span class="sxs-lookup"><span data-stu-id="c2614-236">Top to left navigation</span></span>

<span data-ttu-id="c2614-237">大きなウィンドウのサイズと小規模の左側のナビゲーションのトップ ナビゲーションを使用することをお勧め] ウィンドウのサイズを場合。</span><span class="sxs-lookup"><span data-stu-id="c2614-237">We recommend using top navigation on large window sizes and left navigation on small window sizes when:</span></span>

- <span data-ttu-id="c2614-238">非表示に等しい重要度を指定したり、左側のナビゲーションにこのセット内の 1 つのカテゴリを画面に収まらない場合は、次のような一緒に表示されるにはカテゴリを均等に重要な最上位レベルのナビゲーションのセットがあります。</span><span class="sxs-lookup"><span data-stu-id="c2614-238">You have a set of equally important top-level navigation categories to be displayed together, such that if one category in this set doesn't fit on screen, you collapse to left navigation to give them equal importance.</span></span>
- <span data-ttu-id="c2614-239">小さなウィンドウ サイズにできるだけスペースを大幅にコンテンツを保持したいです。</span><span class="sxs-lookup"><span data-stu-id="c2614-239">You wish to preserve as much content space as possible in small window sizes.</span></span>

<span data-ttu-id="c2614-240">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-240">Here is an example:</span></span>

![gif の上部または左側のナビゲーション適応動作 1](images/navigation-top-to-left.png)

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

<span data-ttu-id="c2614-242">アプリは、上のウィンドウと左側のウィンドウに別のデータにバインドする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2614-242">Sometimes apps need to bind different data to the top pane and left pane.</span></span> <span data-ttu-id="c2614-243">左側のウィンドウにはナビゲーションの他の要素が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c2614-243">Often the left pane includes more navigation elements.</span></span>

<span data-ttu-id="c2614-244">以下に例を示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-244">Here is an example:</span></span>

![gif の上部または左側のナビゲーション適応動作 2](images/navigation-top-to-left2.png)

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

## <a name="interaction"></a><span data-ttu-id="c2614-246">操作</span><span class="sxs-lookup"><span data-stu-id="c2614-246">Interaction</span></span>

<span data-ttu-id="c2614-247">ウィンドウのナビゲーション項目をユーザーがタップすると、選択された項目が NavigationView によって表示されて、[ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="c2614-247">When users tap on a navigation item in the Pane, NavigationView will show that item as selected and will raise an [ItemInvoked](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ItemInvoked) event.</span></span> <span data-ttu-id="c2614-248">タップにより新しいアイテムが選択されると、NavigationView でさらに [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="c2614-248">If the tap results in a new item being selected, NavigationView will also raise a [SelectionChanged](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.SelectionChanged) event.</span></span>

<span data-ttu-id="c2614-249">アプリは、このユーザー操作に応じてヘッダーとコンテンツを適切な情報で更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c2614-249">Your app is responsible for updating the Header and Content with appropriate information in response to this user interaction.</span></span> <span data-ttu-id="c2614-250">また、プログラムによってナビゲーション項目からコンテンツに[フォーカス](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.FocusState) を移動することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="c2614-250">In addition, we recommend programmatically moving [focus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.control.FocusState) from the navigation item to the content.</span></span> <span data-ttu-id="c2614-251">読み込み時に最初のフォーカスを設定することで、ユーザー フローが合理化され、予測されるキーボード フォーカスの移動回数が最小限に抑えられます。</span><span class="sxs-lookup"><span data-stu-id="c2614-251">By setting initial focus on load, you streamline the user flow and minimize the expected number of keyboard focus moves.</span></span>

### <a name="tabs"></a><span data-ttu-id="c2614-252">タブ</span><span class="sxs-lookup"><span data-stu-id="c2614-252">Tabs</span></span>

<span data-ttu-id="c2614-253">モデルでは、タブ、オブジェクトの選択とフォーカスが関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="c2614-253">In the tabs model, selection and focus are tied.</span></span> <span data-ttu-id="c2614-254">通常の方法でフォーカスを移動が選択範囲を移動するも動作します。</span><span class="sxs-lookup"><span data-stu-id="c2614-254">An action that normally shifts focus would also shift selection.</span></span> <span data-ttu-id="c2614-255">例では、下にある右ポイントはインジケーターを移動選択表示拡大します。</span><span class="sxs-lookup"><span data-stu-id="c2614-255">In the below example, right arrowing would move the selection indicator from Display to Magnifier.</span></span> <span data-ttu-id="c2614-256">[SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.selectionfollowsfocus)プロパティを有効に設定して、これを実現できます。</span><span class="sxs-lookup"><span data-stu-id="c2614-256">You can achieve this by setting the [SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.selectionfollowsfocus) property to Enabled.</span></span>

![テキストのみの最上位 navview のスクリーン ショット](images/nav-tabs.png)

<span data-ttu-id="c2614-258">ここ XAML の例ではその。</span><span class="sxs-lookup"><span data-stu-id="c2614-258">Here is the example XAML for that:</span></span>

```xaml
<NavigationView PanePosition="Top" SelectionFollowsFocus="Enabled" >
   <NavigationView.MenuItems>
        <NavigationViewItem Content="Display" />
        <NavigationViewItem Content="Magnifier"  />
        <NavigationViewItem Content="Keyboard" />
    </NavigationView.MenuItems>
</NavigationView>

```

<span data-ttu-id="c2614-259">False に設定された FrameNavigationOptions.IsNavigationStackEnabled フレームの[NavigateWithOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame.NavigateToType)メソッドを使用する] タブの [選択範囲を変更するときに、コンテンツを入れ替える] と、該当する情報をスナップする NavigateOptions.TransitionInfoOverride を設定します。アニメーションにスライドします。</span><span class="sxs-lookup"><span data-stu-id="c2614-259">To swap out content when changing tab selection, you can use Frame's [NavigateWithOptions](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame.NavigateToType) method with FrameNavigationOptions.IsNavigationStackEnabled set to False, and NavigateOptions.TransitionInfoOverride set to the appropriate side-to-side slide animation.</span></span> <span data-ttu-id="c2614-260">例については、次の[例](#code-example)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c2614-260">For an example, see the [code example](#code-example) below.</span></span>

<span data-ttu-id="c2614-261">既定のスタイルを変更する場合は、NavigationView の[MenuItemContainerStyle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemcontainerstyle)プロパティを無視することができます。</span><span class="sxs-lookup"><span data-stu-id="c2614-261">If you wish to change the default Style, you can override NavigationView's [MenuItemContainerStyle](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemcontainerstyle) property.</span></span> <span data-ttu-id="c2614-262">別のデータのテンプレートを指定するのには、[それに続く](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemtemplate)プロパティを設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="c2614-262">You can also set the [MenuItemTemplate](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.menuitemtemplate) property to specify a different data template.</span></span>

## <a name="backwards-navigation"></a><span data-ttu-id="c2614-263">逆方向のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-263">Backwards navigation</span></span>

<span data-ttu-id="c2614-264">NavigationView には組み込みの [戻る] ボタンがあります。これは、次のプロパティで有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="c2614-264">NavigationView has a built-in back button, which can be enabled with the following properties:</span></span>

- <span data-ttu-id="c2614-265">[**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) は既定で NavigationViewBackButtonVisible 列挙と「自動」になっています。</span><span class="sxs-lookup"><span data-stu-id="c2614-265">[**IsBackButtonVisible**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackButtonVisible) is a NavigationViewBackButtonVisible enum and "Auto" by default.</span></span> <span data-ttu-id="c2614-266">[戻る] ボタンの表示/非表示を切り替えるために使用します。</span><span class="sxs-lookup"><span data-stu-id="c2614-266">It is used to show/hide the back button.</span></span> <span data-ttu-id="c2614-267">ボタンが表示されていない場合は、[戻る] ボタンを描画するための領域は折りたたまれます。</span><span class="sxs-lookup"><span data-stu-id="c2614-267">When the button is not visible, the space for drawing the back button will be collapsed.</span></span>
- <span data-ttu-id="c2614-268">[**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) は既定では false に設定されており、[戻る] ボタンの状態を切り替えるために使用できます。</span><span class="sxs-lookup"><span data-stu-id="c2614-268">[**IsBackEnabled**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.IsBackEnabled) is false by default and can be used to toggle the back button states.</span></span>
- <span data-ttu-id="c2614-269">[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) はユーザーが [戻る] ボタンをクリックした場合に発生します。</span><span class="sxs-lookup"><span data-stu-id="c2614-269">[**BackRequested**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.BackRequested) is fired when a user clicks on the back button.</span></span>
    - <span data-ttu-id="c2614-270">最小/コンパクト モードで NavigationView.Pane がポップアップとして開いているときに [戻る] ボタンをクリックすると、ウィンドウが閉じ、代わりに **PaneClosing** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="c2614-270">In Minimal/Compact mode, when the NavigationView.Pane is open as a flyout, clicking the back button will close the Pane and fire **PaneClosing** event instead.</span></span>
    - <span data-ttu-id="c2614-271">IsBackEnabled が false の場合は発生しません。</span><span class="sxs-lookup"><span data-stu-id="c2614-271">Not fired if IsBackEnabled is false.</span></span>

:::row:::
    :::column:::
    <b><span data-ttu-id="c2614-272">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-272">Left nav</span></span></b><br>
    ![[戻る] ボタンを NavigationView 左のナビゲーション](images/leftnav-back.png)
    :::column-end:::
    :::column:::
     <b><span data-ttu-id="c2614-274">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c2614-274">Top nav</span></span></b><br>
    ![上部のナビゲーションで [戻る] ボタンを NavigationView](images/topnav-back.png)
    :::column-end:::
:::row-end:::

## <a name="code-example"></a><span data-ttu-id="c2614-276">コードの例</span><span class="sxs-lookup"><span data-stu-id="c2614-276">Code example</span></span>

> [!NOTE]
> <span data-ttu-id="c2614-277">NavigationView は、アプリのルート コンテナーとしての役割を果たします。このコントロールは、アプリ ウィンドウの全幅と全高にまたがるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="c2614-277">NavigationView should serve as the root container of your app, as this control is designed to span the full width and height of the app window.</span></span>
<span data-ttu-id="c2614-278">その動作を変更する必要がある場合は、[CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) プロパティと [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) プロパティを使用して、ナビゲーション ビューで表示モードが変わる幅をオーバーライドすることもできます。</span><span class="sxs-lookup"><span data-stu-id="c2614-278">You can override the widths at which the navigation view changes display modes by using the [CompactModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.CompactModeThresholdWidth) and [ExpandedModeThresholdWidth](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ExpandedModeThresholdWidth) properties.</span></span>

<span data-ttu-id="c2614-279">次に、サイズの大きなウィンドウの上部のナビゲーション ウィンドウと、小さなウィンドウ サイズに左側のナビゲーション ウィンドウの両方を含む NavigationView を組み込む方法のエンドの例を示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-279">The following is an end-to-end example of how you can incorporate NavigationView with both a top navigation pane on large window sizes and a left navigation pane on small window sizes.</span></span>

<span data-ttu-id="c2614-280">エンドユーザー頻繁に新しいナビゲーション カテゴリを選択するには、この例では、予想などは。</span><span class="sxs-lookup"><span data-stu-id="c2614-280">In this sample, we expect end users to frequently select new navigation categories, and so we:</span></span>

- <span data-ttu-id="c2614-281">有効に[SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="c2614-281">Set the [SelectionFollowsFocus](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion) property to Enabled</span></span>
- <span data-ttu-id="c2614-282">ナビゲーション スタックに追加しないフレーム ナビゲーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="c2614-282">Use Frame navigations that do not add to the navigation stack.</span></span>
- <span data-ttu-id="c2614-283">既定値を示す、ゲーム パッドで左/右エンジンがアプリのナビゲーションのトップレベル カテゴリを移動するかどうかに使用される[ShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion)プロパティは、オンのままにします。</span><span class="sxs-lookup"><span data-stu-id="c2614-283">Keep the default value on the [ShoulderNavigationEnabled](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.PanePostion) property, which is used to indicate if left/right bumpers on a gamepad navigate the top-level navigation categories of your app.</span></span> <span data-ttu-id="c2614-284">既定では"WhenSelectionFollowsFocus です"。</span><span class="sxs-lookup"><span data-stu-id="c2614-284">The default is "WhenSelectionFollowsFocus".</span></span> <span data-ttu-id="c2614-285">しない] と、他の値は「常に」です。</span><span class="sxs-lookup"><span data-stu-id="c2614-285">The other possible values are "Always" and "Never".</span></span>

<span data-ttu-id="c2614-286">下位の NavigationView の [戻る] ボタンとナビゲーションを実装する方法を説明します。</span><span class="sxs-lookup"><span data-stu-id="c2614-286">We also demonstrate how to implement backwards navigation with NavigationView's back button.</span></span>

<span data-ttu-id="c2614-287">サンプルの内容の記録を示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-287">Here's a recording of what the sample demonstrates:</span></span>

![NavigationView-エンドツー エンドのサンプル](images/nav-code-example.gif)

<span data-ttu-id="c2614-289">サンプル コードを示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-289">Here's the sample code:</span></span>

> [!NOTE]
> <span data-ttu-id="c2614-290">[Windows ユーザー インターフェイスのライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`xmlns:controls="using:Microsoft.UI.Xaml.Controls"`します。</span><span class="sxs-lookup"><span data-stu-id="c2614-290">If you're using the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/), then you'll need to add a reference to the toolkit: `xmlns:controls="using:Microsoft.UI.Xaml.Controls"`.</span></span>

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
> <span data-ttu-id="c2614-291">[Windows ユーザー インターフェイスのライブラリ](https://docs.microsoft.com/uwp/toolkits/winui/)を使用しているかどうかは、ツールキットへの参照を追加する必要があります:`using MUXC = Microsoft.UI.Xaml.Controls;`します。</span><span class="sxs-lookup"><span data-stu-id="c2614-291">If you're using the [Windows UI Library](https://docs.microsoft.com/uwp/toolkits/winui/), then you'll need to add a reference to the toolkit: `using MUXC = Microsoft.UI.Xaml.Controls;`.</span></span>

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

## <a name="customizing-backgrounds"></a><span data-ttu-id="c2614-292">背景をカスタマイズ</span><span class="sxs-lookup"><span data-stu-id="c2614-292">Customizing backgrounds</span></span>

<span data-ttu-id="c2614-293">NavigationView のメイン領域の背景を変更するには、その `Background` プロパティを目的のブラシに設定します。</span><span class="sxs-lookup"><span data-stu-id="c2614-293">To change the background of NavigationView's main area, set its `Background` property to your preferred brush.</span></span>

<span data-ttu-id="c2614-294">ウィンドウの背景は、上、最低限、またはコンパクト モードでは、NavigationView した場合に、アプリで acrylic を示します。</span><span class="sxs-lookup"><span data-stu-id="c2614-294">The Pane's background shows in-app acrylic when NavigationView is in Top, Minimal, or Compact mode.</span></span> <span data-ttu-id="c2614-295">この動作を更新したり、ウィンドウのアクリルの外観をカスタマイズしたりするには、App.xaml で上書きすることで、2 つのテーマ リソースを変更します。</span><span class="sxs-lookup"><span data-stu-id="c2614-295">To update this behavior or customize the appearance of your Pane's acrylic, modify the two theme resources by overwriting them in your App.xaml.</span></span>

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

## <a name="scroll-content-under-top-pane"></a><span data-ttu-id="c2614-296">上のウィンドウの下にスクロール コンテンツ</span><span class="sxs-lookup"><span data-stu-id="c2614-296">Scroll content under top pane</span></span>

<span data-ttu-id="c2614-297">シームレスな外観 + 外観の場合は、アプリを ScrollViewer を使用するページがあり、ナビゲーション ウィンドウが上に配置すると、お勧めが生じるコンテンツの上部のナビゲーション ウィンドウの下にスクロールします。</span><span class="sxs-lookup"><span data-stu-id="c2614-297">For a seamless look+feel, if your app has pages that use a ScrollViewer and your navigation pane is top positioned, we recommend having the content scroll underneath the top nav pane.</span></span>

<span data-ttu-id="c2614-298">これを true に関連する ScrollViewer で[CanContentRenderOutsideBounds](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer.cancontentrenderoutsidebounds)プロパティを設定して実現できます。</span><span class="sxs-lookup"><span data-stu-id="c2614-298">This can be achieved by setting the [CanContentRenderOutsideBounds](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer.cancontentrenderoutsidebounds) property on the relevant ScrollViewer to true.</span></span>

![navview スクロールのナビゲーション ウィンドウ](images/nav-scroll-content.png)

<span data-ttu-id="c2614-300">アプリが非常に長いコンテンツをスクロールに場合は、固定のヘッダーを上部のナビゲーション ウィンドウに添付して、フォームの面が滑らかに組み込むことを検討することができます。</span><span class="sxs-lookup"><span data-stu-id="c2614-300">If your app has very long scrolling content, you may want to consider incorporating sticky headers that attach to the top nav pane and form a smooth surface.</span></span> 

![navview スクロールの上部に固定されたヘッダー](images/nav-scroll-stickyheader.png)

<span data-ttu-id="c2614-302">これを行う NavigationView で[ContentOverlay](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを設定します。</span><span class="sxs-lookup"><span data-stu-id="c2614-302">You can achieve this by setting the [ContentOverlay](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay) property on NavigationView.</span></span> 

<span data-ttu-id="c2614-303">場合によっては、ユーザーは、下へスクロール場合は NavigationView で[IsPaneVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay)プロパティを false に設定して、ナビゲーション ウィンドウを非表示にすることがあります。</span><span class="sxs-lookup"><span data-stu-id="c2614-303">Sometimes, if the user is scrolling down, you may want to hide the nav pane, achieved by setting the [IsPaneVisible](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview.ContentOverlay) property on NavigationView to false.</span></span>

![navview スクロールの非表示のナビゲーション](images/nav-scroll-hidepane.png)

## <a name="related-topics"></a><span data-ttu-id="c2614-305">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c2614-305">Related topics</span></span>

- [<span data-ttu-id="c2614-306">NavigationView クラス</span><span class="sxs-lookup"><span data-stu-id="c2614-306">NavigationView class</span></span>](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)
- [<span data-ttu-id="c2614-307">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="c2614-307">Master/details</span></span>](master-details.md)
- [<span data-ttu-id="c2614-308">ピボット コントロール</span><span class="sxs-lookup"><span data-stu-id="c2614-308">Pivot control</span></span>](tabs-pivot.md)
- [<span data-ttu-id="c2614-309">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="c2614-309">Navigation basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="c2614-310">UWP 用 Fluent Design の概要</span><span class="sxs-lookup"><span data-stu-id="c2614-310">Fluent Design for UWP overview</span></span>](../fluent-design-system/index.md)