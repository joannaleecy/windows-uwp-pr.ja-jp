---
author: QuinnRadich
Description: The master/detail pattern displays a master list and the details for the currently selected item. This pattern is frequently used for email and contact lists/address books.
title: マスター/詳細
ms.assetid: 45C9FE8B-ECA6-44BF-8DDE-7D12ED34A7F7
label: Master/details
template: detail.hbs
ms.author: quradic
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 28a6160019fd3bf64dd1f75bc5c6df29cd3165ad
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2018
ms.locfileid: "3846116"
---
# <a name="masterdetails-pattern"></a><span data-ttu-id="e33dd-103">マスター/詳細パターン</span><span class="sxs-lookup"><span data-stu-id="e33dd-103">Master/details pattern</span></span>

 

<span data-ttu-id="e33dd-104">マスター/詳細パターンには、コンテンツのマスター ウィンドウ (通常は[リスト ビュー](lists.md)も表示されます) と詳細ウィンドウがあります。</span><span class="sxs-lookup"><span data-stu-id="e33dd-104">The master/details pattern has a master pane (usually with a [list view](lists.md)) and a details pane for content.</span></span> <span data-ttu-id="e33dd-105">マスター リストの項目を選ぶと、詳細ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="e33dd-105">When an item in the master list is selected, the details pane is updated.</span></span> <span data-ttu-id="e33dd-106">このパターンは、メールやアドレス帳によく使われます。</span><span class="sxs-lookup"><span data-stu-id="e33dd-106">This pattern is frequently used for email and address books.</span></span>

> <span data-ttu-id="e33dd-107">**重要な API**: [ListView クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)、[SplitView クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)</span><span class="sxs-lookup"><span data-stu-id="e33dd-107">**Important APIs**: [ListView class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView), [SplitView class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)</span></span>

![マスター/詳細パターンの例](images/HIGSecOne_MasterDetail.png)

## <a name="is-this-the-right-pattern"></a><span data-ttu-id="e33dd-109">適切なパターンの選択</span><span class="sxs-lookup"><span data-stu-id="e33dd-109">Is this the right pattern?</span></span>

<span data-ttu-id="e33dd-110">次の場合は、マスター/詳細パターンが適しています。</span><span class="sxs-lookup"><span data-stu-id="e33dd-110">The master/details pattern works well if you want to:</span></span>

-   <span data-ttu-id="e33dd-111">メール アプリ、アドレス帳、またはリスト/詳細レイアウトをベースとするアプリを構築する。</span><span class="sxs-lookup"><span data-stu-id="e33dd-111">Build an email app, address book, or any app that is based on a list-details layout.</span></span>
-   <span data-ttu-id="e33dd-112">大きいコンテンツ コレクションを特定して優先順位を設定する。</span><span class="sxs-lookup"><span data-stu-id="e33dd-112">Locate and prioritize a large collection of content.</span></span>
-   <span data-ttu-id="e33dd-113">コンテキスト間を前後に移動しながら、リストから項目をすばやく追加および削除できるようにする。</span><span class="sxs-lookup"><span data-stu-id="e33dd-113">Allow the quick addition and removal of items from a list while working back-and-forth between contexts.</span></span>

## <a name="choose-the-right-style"></a><span data-ttu-id="e33dd-114">適切なスタイルの選択</span><span class="sxs-lookup"><span data-stu-id="e33dd-114">Choose the right style</span></span>

<span data-ttu-id="e33dd-115">マスター/詳細パターンを実装するとき、利用可能な画面領域の量に応じて、スタック スタイルまたは左右に並べるスタイルを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="e33dd-115">When implementing the master/details pattern, we recommend that you use either the stacked style or the side-by-side style, based on the amount of available screen space.</span></span>

| <span data-ttu-id="e33dd-116">利用可能なウィンドウの幅</span><span class="sxs-lookup"><span data-stu-id="e33dd-116">Available window width</span></span> | <span data-ttu-id="e33dd-117">推奨スタイル</span><span class="sxs-lookup"><span data-stu-id="e33dd-117">Recommended style</span></span> |
|------------------------|-------------------|
| <span data-ttu-id="e33dd-118">320 epx ～ 640 epx</span><span class="sxs-lookup"><span data-stu-id="e33dd-118">320 epx-640 epx</span></span>        | <span data-ttu-id="e33dd-119">スタック</span><span class="sxs-lookup"><span data-stu-id="e33dd-119">Stacked</span></span>           |
| <span data-ttu-id="e33dd-120">641 epx 以上</span><span class="sxs-lookup"><span data-stu-id="e33dd-120">641 epx or wider</span></span>       | <span data-ttu-id="e33dd-121">左右に並べる</span><span class="sxs-lookup"><span data-stu-id="e33dd-121">Side-by-side</span></span>      |

 
## <a name="stacked-style"></a><span data-ttu-id="e33dd-122">スタック スタイル</span><span class="sxs-lookup"><span data-stu-id="e33dd-122">Stacked style</span></span>

<span data-ttu-id="e33dd-123">スタック スタイルでは、マスター ウィンドウと詳細ウィンドウのうち 1 つのウィンドウだけが一度に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e33dd-123">In the stacked style, only one pane is visible at a time: the master or the details.</span></span>

![スタック モードのマスター詳細](images/patterns-md-stacked.png)

<span data-ttu-id="e33dd-125">ユーザーがマスター ウィンドウで作業を始め、マスター リストで項目を選んで詳細ウィンドウに "ドリルダウン" します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-125">The user starts at the master pane and "drills down" to the details pane by selecting an item in the master list.</span></span> <span data-ttu-id="e33dd-126">ユーザーから見ると、マスター ビューと詳細ビューが別々の 2 つのページに存在するように表示されます。</span><span class="sxs-lookup"><span data-stu-id="e33dd-126">To the user, it appears as though the master and details views exist on two separate pages.</span></span>

### <a name="create-a-stacked-masterdetails-pattern"></a><span data-ttu-id="e33dd-127">スタック マスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="e33dd-127">Create a stacked master/details pattern</span></span>

<span data-ttu-id="e33dd-128">スタック マスター/詳細パターンを作る方法の 1 つは、マスター ウィンドウと詳細ウィンドウにそれぞれ別のページを使うことです。</span><span class="sxs-lookup"><span data-stu-id="e33dd-128">One way to create the stacked master/details pattern is to use separate pages for the master pane and the details pane.</span></span> <span data-ttu-id="e33dd-129">マスター ビューを 1 つのページに表示し、詳細ウィンドウを別のページに配置します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-129">Place the master view on one page, and the details pane on a separate page.</span></span>

![スタック スタイルのマスター詳細の構成要素](images/patterns-md-stacked-parts.png)

<span data-ttu-id="e33dd-131">マスター ビュー ページでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。</span><span class="sxs-lookup"><span data-stu-id="e33dd-131">For the master view page, a [list view](lists.md) control works well for presenting lists that can contain images and text.</span></span> 

<span data-ttu-id="e33dd-132">詳細ビュー ページの場合、最も意味のある[コンテンツ要素](../layout/layout-panels.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="e33dd-132">For the details view page, use the [content element](../layout/layout-panels.md) that makes the most sense.</span></span> <span data-ttu-id="e33dd-133">多くの個別フィールドがある場合は、**グリッド** レイアウトを使って要素をフォームに配置することを検討します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-133">If you have a lot of separate fields, consider using a **Grid** layout to arrange elements into a form.</span></span>

<span data-ttu-id="e33dd-134">ページ間の移動の詳細については、「[UWP アプリのナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e33dd-134">For navigation between pages, see [navigation history and backwards navigation for UWP apps](../basics/navigation-history-and-backwards-navigation.md).</span></span>

## <a name="side-by-side-style"></a><span data-ttu-id="e33dd-135">左右に並べるスタイル</span><span class="sxs-lookup"><span data-stu-id="e33dd-135">Side-by-side style</span></span>

<span data-ttu-id="e33dd-136">横に並べるスタイルでは、マスター ウィンドウと詳細ウィンドウを同時に表示できます。</span><span class="sxs-lookup"><span data-stu-id="e33dd-136">In the side-by-side style, the master pane and details pane are visible at the same time.</span></span>

![マスター/詳細パターン](images/patterns-masterdetail-400x227.png)

<span data-ttu-id="e33dd-138">マスター ウィンドウのリストは、現在選択されている項目を示すために選択ビジュアルを使用します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-138">The list in the master pane has a selection visual to indicate the currently selected item.</span></span> <span data-ttu-id="e33dd-139">マスター リストで新しい項目を選ぶと、詳細ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="e33dd-139">Selecting a new item in the master list updates the details pane.</span></span>

### <a name="create-a-side-by-side-masterdetails-pattern"></a><span data-ttu-id="e33dd-140">左右に並べるマスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="e33dd-140">Create a side-by-side master/details pattern</span></span>

<span data-ttu-id="e33dd-141">サイド バイ サイドのマスター/詳細パターンを実装する 1 つの方法として、[分割ビュー](split-view.md) コントロールを使用する方法があります。</span><span class="sxs-lookup"><span data-stu-id="e33dd-141">One way to create a side-by-side master/details pattern is to use the [split view](split-view.md) control.</span></span> <span data-ttu-id="e33dd-142">分割ビューのウィンドウにマスター ビューを配置し、分割ビューのコンテンツに詳細ビューを配置します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-142">Place the master view in the split view pane, and the details view in the split view content.</span></span>

![マスター/詳細分割ビュー部品](images/patterns_md_splitview_parts.png)

<span data-ttu-id="e33dd-144">マスター ウィンドウでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。</span><span class="sxs-lookup"><span data-stu-id="e33dd-144">For the master pane, a [list view](lists.md) control works well for presenting lists that can contain images and text.</span></span>

<span data-ttu-id="e33dd-145">詳細コンテンツの場合、最も意味のある[コンテンツ要素](../layout/layout-panels.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="e33dd-145">For the details content, use the [content element](../layout/layout-panels.md) that makes the most sense.</span></span> <span data-ttu-id="e33dd-146">多くの個別フィールドがある場合は、**グリッド** レイアウトを使って要素をフォームに配置することを検討します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-146">If you have a lot of separate fields, consider using a **Grid** layout to arrange elements into a form.</span></span>

## <a name="adaptive-layout"></a><span data-ttu-id="e33dd-147">アダプティブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="e33dd-147">Adaptive layout</span></span>

<span data-ttu-id="e33dd-148">マスター/詳細パターンをすべての画面サイズで実装するには、[アダプティブ レイアウト](../layout/layouts-with-xaml.md) で応答性の高い UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-148">To implement a master/details pattern for any screen size, create a responsive UI with an [adaptive layout](../layout/layouts-with-xaml.md).</span></span>

![アダプティブ マスター詳細レイアウト](images/patterns_masterdetail.png)

### <a name="create-an-adaptive-masterdetails-pattern"></a><span data-ttu-id="e33dd-150">アダプティブ マスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="e33dd-150">Create an adaptive master/details pattern</span></span>
<span data-ttu-id="e33dd-151">アダプティブ レイアウトを作成するには、UI のさまざまな [**VisualStates**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.visualstate) を定義し、[**AdaptiveTriggers**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.AdaptiveTrigger) を使用して UI のさまざまな状態のブレークポイントを宣言します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-151">To create an adaptive layout, define different [**VisualStates**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.visualstate) for your UI, and declare breakpoints for the different states with [**AdaptiveTriggers**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.AdaptiveTrigger).</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="e33dd-152">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="e33dd-152">Get the sample code</span></span>

<span data-ttu-id="e33dd-153">次のサンプルでは、アダプティブ レイアウトを使用してマスター/詳細パターンを実装し、静的なリソース、データベース リソース、およびオンライン リソースに対するデータ バインディングを示します。</span><span class="sxs-lookup"><span data-stu-id="e33dd-153">The following samples implement the master/details pattern with adaptive layouts and demonstrate data binding to static, database, and online resources:</span></span> 
- [<span data-ttu-id="e33dd-154">マスター/詳細のサンプル</span><span class="sxs-lookup"><span data-stu-id="e33dd-154">Master/detail sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlMasterDetail) 
- [<span data-ttu-id="e33dd-155">マスター/詳細と選択のサンプル</span><span class="sxs-lookup"><span data-stu-id="e33dd-155">Master/Details plus Selection sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)
- [<span data-ttu-id="e33dd-156">Windows Template Studio マスター/詳細のサンプル</span><span class="sxs-lookup"><span data-stu-id="e33dd-156">Windows Template Studio Master/Detail sample</span></span>](https://github.com/Microsoft/WindowsTemplateStudio/tree/master/templates/Uwp/Pages/MasterDetail)
- [<span data-ttu-id="e33dd-157">顧客注文データベースのサンプル</span><span class="sxs-lookup"><span data-stu-id="e33dd-157">Customer orders database sample</span></span>](https://github.com/Microsoft/Windows-appsample-customers-orders-database)
- [<span data-ttu-id="e33dd-158">RSS リーダーのサンプル</span><span class="sxs-lookup"><span data-stu-id="e33dd-158">RSS Reader sample</span></span>](https://github.com/Microsoft/Windows-appsample-rssreader)

## <a name="related-articles"></a><span data-ttu-id="e33dd-159">関連記事</span><span class="sxs-lookup"><span data-stu-id="e33dd-159">Related articles</span></span>

- [<span data-ttu-id="e33dd-160">リスト</span><span class="sxs-lookup"><span data-stu-id="e33dd-160">Lists</span></span>](lists.md)
- [<span data-ttu-id="e33dd-161">検索</span><span class="sxs-lookup"><span data-stu-id="e33dd-161">Search</span></span>](search.md)
- [<span data-ttu-id="e33dd-162">アプリ バーとコマンド バー</span><span class="sxs-lookup"><span data-stu-id="e33dd-162">App and command bars</span></span>](app-bars.md)
- [<span data-ttu-id="e33dd-163">ListView クラス</span><span class="sxs-lookup"><span data-stu-id="e33dd-163">ListView class</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)
- [<span data-ttu-id="e33dd-164">SplitView クラス</span><span class="sxs-lookup"><span data-stu-id="e33dd-164">SplitView class</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)
