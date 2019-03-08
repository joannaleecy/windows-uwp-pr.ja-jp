---
title: UWP アプリのページ レイアウト
description: アプリを設計するときに最初に検討することは、レイアウト構造です。 この記事では、基本的なページ レイアウト、UI 要素を含む必要があります、およびページが出るの一般的な構造について説明します。 各ページで UWP アプリでは、ナビゲーション、コマンド、およびコンテンツの要素が通常持っています。
ms.date: 03/19/2018
ms.topic: article
keywords: windows 10, uwp
localizationpriority: medium
ms.openlocfilehash: edda9948e70b1757ddb46fae45a579bb2fdb8de1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57633717"
---
# <a name="page-layout"></a><span data-ttu-id="d9f94-106">ページのレイアウト</span><span class="sxs-lookup"><span data-stu-id="d9f94-106">Page layout</span></span>

<span data-ttu-id="d9f94-107">UWP アプリで各[**ページ**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page)通常、ナビゲーション、コマンド、およびコンテンツの要素が存在します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-107">In UWP apps, each [**Page**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page) generally has navigation, command, and content elements.</span></span> 

<span data-ttu-id="d9f94-108">アプリが複数のページがあることができます: ユーザーが、UWP アプリを起動、アプリケーション コードを作成、 [**フレーム**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame)アプリケーションの内部に配置する[**ウィンドウ**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window).</span><span class="sxs-lookup"><span data-stu-id="d9f94-108">Your app can have multiple pages: when a user launches a UWP app, the application code creates a [**Frame**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame) to place inside of the application's [**Window**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.window).</span></span> <span data-ttu-id="d9f94-109">フレームできますし、[移動](../basics/navigate-between-two-pages.md)アプリケーションの間で[**ページ**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page)インスタンス。</span><span class="sxs-lookup"><span data-stu-id="d9f94-109">The Frame can then [navigate](../basics/navigate-between-two-pages.md) between the application's [**Page**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Page) instances.</span></span> 

<span data-ttu-id="d9f94-110">ほとんどのページの次の一般的なレイアウト構造体と、この記事で説明する UI 要素が必要、およびページが出る。</span><span class="sxs-lookup"><span data-stu-id="d9f94-110">Most pages follow a common layout structure, and this article covers which UI elements you'll need, and where they should go on a page.</span></span> 

![ページの構造](images/page-components.svg)

## <a name="navigation"></a><span data-ttu-id="d9f94-112">ナビゲーション</span><span class="sxs-lookup"><span data-stu-id="d9f94-112">Navigation</span></span>
<span data-ttu-id="d9f94-113">ユーザーがアプリでページ間で移動する方法を定義するナビゲーション モデルを選択すると、アプリのレイアウトを開始します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-113">Your app layout begins with the navigation model you choose, which defines how your users navigate between pages in your app.</span></span> <span data-ttu-id="d9f94-114">この記事では、2 つの一般的なナビゲーション パターンについて説明します左のナビゲーションと上部のナビゲーション。</span><span class="sxs-lookup"><span data-stu-id="d9f94-114">For this article, we'll discuss two common navigation patterns: left nav and top nav.</span></span> <span data-ttu-id="d9f94-115">その他のナビゲーション オプションを選択する方法のガイダンスについては、次を参照してください。 [UWP アプリのナビゲーション設計の基本](../basics/navigation-basics.md)します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-115">For guidance on choosing other navigation options, see [Navigation design basics for UWP apps](../basics/navigation-basics.md).</span></span>

![上部と左側のナビゲーション パターン](images/top-left-nav.svg)

### <a name="left-nav"></a><span data-ttu-id="d9f94-117">左側のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="d9f94-117">Left nav</span></span>
<span data-ttu-id="d9f94-118">左のナビゲーションで、または[ナビゲーション ウィンドウ](../controls-and-patterns/navigationview.md)パターン、一般に、アプリ レベルのナビゲーションに予約されている、つまり常にある表示および使用できる、アプリ内で最上位レベルに存在します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-118">Left nav, or the [nav pane](../controls-and-patterns/navigationview.md) pattern, is generally reserved for app-level navigation and exists at the highest level within the app, meaning that it should always be visible and available.</span></span> <span data-ttu-id="d9f94-119">左側のナビゲーションは、複数の 5 つのナビゲーション項目、または、アプリ内の 5 つ以上のページがある場合にお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d9f94-119">We recommend left nav when there are more than five navigational items, or more than five pages in your app.</span></span> <span data-ttu-id="d9f94-120">ナビゲーション ウィンドウのパターンが通常含まれています。</span><span class="sxs-lookup"><span data-stu-id="d9f94-120">The nav pane pattern typically contains:</span></span>
- <span data-ttu-id="d9f94-121">ナビゲーション項目</span><span class="sxs-lookup"><span data-stu-id="d9f94-121">Navigation items</span></span>
- <span data-ttu-id="d9f94-122">アプリの設定へのエントリ ポイント</span><span class="sxs-lookup"><span data-stu-id="d9f94-122">Entry point into app settings</span></span>
- <span data-ttu-id="d9f94-123">アカウントの設定へのエントリ ポイント</span><span class="sxs-lookup"><span data-stu-id="d9f94-123">Entry point into account settings</span></span>

<span data-ttu-id="d9f94-124">[NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview)コントロールは、UWP の左側のナビゲーション パターンを実装します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-124">The [NavigationView](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.navigationview) control implements the left nav pattern for UWP.</span></span>

<span data-ttu-id="d9f94-125">ナビゲーション項目を選択すると、フレームが選択した項目のページに移動します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-125">When a navigation item is selected, the Frame should navigate to the selected item's Page.</span></span>

![ナビゲーション ウィンドウの展開](images/navview-expanded.svg)

<span data-ttu-id="d9f94-127">メニュー ボタンでは、ナビゲーション ウィンドウを閉じたりすることができます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-127">The menu button allows users to expand and collapse the nav pane.</span></span> <span data-ttu-id="d9f94-128">画面のサイズが 640 よりも大きい場合 px、メニュー ボタンをクリックすると、バーにナビゲーション ウィンドウを折りたたみます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-128">When the screen size is larger than 640 px, clicking the menu button collapses the nav pane into a bar.</span></span>

![compact のナビゲーション ウィンドウ](images/navview-compact.svg)

<span data-ttu-id="d9f94-130">画面のサイズが 640 よりも小さい場合 px、ナビゲーション ウィンドウが完全に折りたたまれています。</span><span class="sxs-lookup"><span data-stu-id="d9f94-130">When the screen size is smaller than 640 px, the nav pane is fully collapsed.</span></span>

![最小限のナビゲーション ウィンドウ](images/navview-minimal.svg)

### <a name="top-nav"></a><span data-ttu-id="d9f94-132">上部のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="d9f94-132">Top nav</span></span>

<span data-ttu-id="d9f94-133">上部のナビゲーションは、最上位レベルのナビゲーションとしても機能できます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-133">Top nav can also act as top-level navigation.</span></span> <span data-ttu-id="d9f94-134">左側のナビゲーションは、折りたたみ可能な上部のナビゲーションが常に表示します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-134">While left nav is collapsible, top nav is always visible.</span></span> <span data-ttu-id="d9f94-135">[NavigationView](../controls-and-patterns/navigationview.md)コントロールは、UWP の上部のナビゲーションとタブのパターンを実装します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-135">The [NavigationView](../controls-and-patterns/navigationview.md) control implements the top navigation and tabs pattern for UWP.</span></span>

![上部のナビゲーション](images/pivot-large.svg)

## <a name="command-bar"></a><span data-ttu-id="d9f94-137">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="d9f94-137">Command bar</span></span>

<span data-ttu-id="d9f94-138">次に、アプリの最も一般的なタスクに簡単にアクセスをユーザーに提供する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="d9f94-138">Next, you might want to provide users with easy access to your app's most common tasks.</span></span> <span data-ttu-id="d9f94-139">A[コマンド バー](../controls-and-patterns/app-bars.md)アプリ レベルまたはページ レベルのコマンドにアクセスできるようにし、すべてのナビゲーション パターンを持つために使用できます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-139">A [command bar](../controls-and-patterns/app-bars.md) can provide access to app-level or page-level commands, and it can be used with any navigation pattern.</span></span>

![<span data-ttu-id="d9f94-140">上部にあるコマンド バーの配置</span><span class="sxs-lookup"><span data-stu-id="d9f94-140">command bar placement at top</span></span> ](images/app-bar-desktop.svg)

<span data-ttu-id="d9f94-141">上部またはページの下部にあるコマンド バーを配置できるアプリのどちらかをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d9f94-141">The command bar can be placed at the top or bottom of the page, whichever is best for your app.</span></span>

![下部にあるコマンド バーの配置](images/app-bar-mobile.svg)

## <a name="content"></a><span data-ttu-id="d9f94-143">コンテンツ</span><span class="sxs-lookup"><span data-stu-id="d9f94-143">Content</span></span>

<span data-ttu-id="d9f94-144">最後に、さまざまな方法でコンテンツを表示できるように、コンテンツは、広くからアプリにアプリによって異なります。</span><span class="sxs-lookup"><span data-stu-id="d9f94-144">Finally, content varies widely from app to app, so you can present content in many different ways.</span></span> <span data-ttu-id="d9f94-145">ここでは、アプリで使用する場合がありますいくつかの一般的なページ パターンについて説明します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-145">Here, we describe some common page patterns that you might want to use in your app.</span></span> <span data-ttu-id="d9f94-146">多くのアプリは、これらの一般的なページ パターンの一部またはすべてを使用して、さまざまな種類のコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-146">Many apps use some, or all, of these common page patterns to display different types of content.</span></span> <span data-ttu-id="d9f94-147">同様に、自由に混在させるし、アプリを最適化するためにこれらのパターンに一致します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-147">Likewise, feel free to mix and match these patterns to optimize for your app.</span></span>

## <a name="landing"></a><span data-ttu-id="d9f94-148">ランディング</span><span class="sxs-lookup"><span data-stu-id="d9f94-148">Landing</span></span>

![ランディング ページ](images/hero-screen.svg)

<span data-ttu-id="d9f94-150">通常、ランディング ページ (ヒーロー画面とも呼ばれる) は、アプリのエクスペリエンスのトップ レベルに表示されます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-150">Landing pages, also known as hero screens, often appear at the top level of an app experience.</span></span> <span data-ttu-id="d9f94-151">大きいサーフェス領域は、ユーザーが参照および使用する可能性があるコンテンツを、アプリが強調表示するためのステージとして機能します。</span><span class="sxs-lookup"><span data-stu-id="d9f94-151">The large surface area serves as a stage for apps to highlight content that users may want to browse and consume.</span></span>

## <a name="collections"></a><span data-ttu-id="d9f94-152">コレクション</span><span class="sxs-lookup"><span data-stu-id="d9f94-152">Collections</span></span>

![ギャラリー](images/gridview.svg)

<span data-ttu-id="d9f94-154">コレクションを使用すると、ユーザーはコンテンツやデータのグループを参照することができます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-154">Collections allow users to browse groups of content or data.</span></span> <span data-ttu-id="d9f94-155">[グリッド ビュー](../controls-and-patterns/item-templates-gridview.md)は写真またはメディアを中心とするコンテンツに適していて、[リスト ビュー](../controls-and-patterns/item-templates-listview.md)はテキストが多いコンテンツやデータに適しています。</span><span class="sxs-lookup"><span data-stu-id="d9f94-155">[Grid view](../controls-and-patterns/item-templates-gridview.md) is a good option for photos or media-centric content, and [list view](../controls-and-patterns/item-templates-listview.md) is a good option for text-heavy content or data.</span></span>

## <a name="masterdetail"></a><span data-ttu-id="d9f94-156">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="d9f94-156">Master/detail</span></span>

![マスター/詳細](images/master-detail.svg)

<span data-ttu-id="d9f94-158">[マスター/詳細](../controls-and-patterns/master-details.md)モデルは、リスト ビュー (マスター) とコンテンツ ビュー (詳細) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-158">The [master/details](../controls-and-patterns/master-details.md) model consists of a list view (master) and a content view (detail).</span></span> <span data-ttu-id="d9f94-159">両方のウィンドウは固定されていて、垂直方向にスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-159">Both panes are fixed and have vertical scrolling.</span></span> <span data-ttu-id="d9f94-160">リスト ビュー内のアイテムを選択すると、コンテンツ ビューがそれに応じて更新されます。</span><span class="sxs-lookup"><span data-stu-id="d9f94-160">When an item in the list view is selected, the content view is correspondingly updated.</span></span> 

## <a name="forms"></a><span data-ttu-id="d9f94-161">フォーム</span><span class="sxs-lookup"><span data-stu-id="d9f94-161">Forms</span></span>
![フォーム](images/form.svg)

<span data-ttu-id="d9f94-163">[フォーム](../controls-and-patterns/forms.md)は、ユーザーからデータを収集して送信するコントロールのグループです。</span><span class="sxs-lookup"><span data-stu-id="d9f94-163">A [form](../controls-and-patterns/forms.md) is a group of controls that collect and submit data from users.</span></span> <span data-ttu-id="d9f94-164">すべてではなくても、ほとんどのアプリが、設定ページ、ログイン ポータル、フィードバック Hub、アカウントの作成などのために、何らかのフォームを使用しています。</span><span class="sxs-lookup"><span data-stu-id="d9f94-164">Most, if not all apps, use a form of some sort for settings pages, log in portals, feedback hubs, account creation, or other purposes.</span></span> 

## <a name="sample-apps"></a><span data-ttu-id="d9f94-165">サンプル アプリ</span><span class="sxs-lookup"><span data-stu-id="d9f94-165">Sample apps</span></span>
<span data-ttu-id="d9f94-166">これらのパターンを実装する方法については、チェック アウト、 [UWP サンプル アプリ](https://developer.microsoft.com/en-us/windows/samples):</span><span class="sxs-lookup"><span data-stu-id="d9f94-166">To see how these patterns can be implemented, check out our [UWP sample apps](https://developer.microsoft.com/en-us/windows/samples):</span></span>
- [<span data-ttu-id="d9f94-167">BuildCast ビデオ プレーヤー</span><span class="sxs-lookup"><span data-stu-id="d9f94-167">BuildCast Video Player</span></span>](https://github.com/Microsoft/BuildCast)
- [<span data-ttu-id="d9f94-168">ランチ スケジューラ</span><span class="sxs-lookup"><span data-stu-id="d9f94-168">Lunch Scheduler</span></span>](https://github.com/Microsoft/Windows-appsample-lunch-scheduler)
- [<span data-ttu-id="d9f94-169">塗り絵帳</span><span class="sxs-lookup"><span data-stu-id="d9f94-169">Coloring Book</span></span>](https://github.com/Microsoft/Windows-appsample-coloringbook)
- [<span data-ttu-id="d9f94-170">顧客注文データベース</span><span class="sxs-lookup"><span data-stu-id="d9f94-170">Customers Orders Database</span></span>](https://github.com/Microsoft/Windows-appsample-customers-orders-database)