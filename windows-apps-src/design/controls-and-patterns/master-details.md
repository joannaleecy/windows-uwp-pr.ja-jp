---
Description: マスター/詳細パターンでは、マスター リストと、現在選択されている項目の詳細が表示されます。 このパターンは、メールや連絡先一覧/アドレス帳によく使用されます。
title: マスター/詳細
ms.assetid: 45C9FE8B-ECA6-44BF-8DDE-7D12ED34A7F7
label: Master/details
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: b9d8d8a381c0fce186b39853f57d35c1dce4b8f8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57601257"
---
# <a name="masterdetails-pattern"></a><span data-ttu-id="60ca4-105">マスター/詳細パターン</span><span class="sxs-lookup"><span data-stu-id="60ca4-105">Master/details pattern</span></span>

 

<span data-ttu-id="60ca4-106">マスター/詳細パターンには、コンテンツのマスター ウィンドウ (通常は[リスト ビュー](lists.md)も表示されます) と詳細ウィンドウがあります。</span><span class="sxs-lookup"><span data-stu-id="60ca4-106">The master/details pattern has a master pane (usually with a [list view](lists.md)) and a details pane for content.</span></span> <span data-ttu-id="60ca4-107">マスター リストの項目を選ぶと、詳細ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="60ca4-107">When an item in the master list is selected, the details pane is updated.</span></span> <span data-ttu-id="60ca4-108">このパターンは、メールやアドレス帳によく使われます。</span><span class="sxs-lookup"><span data-stu-id="60ca4-108">This pattern is frequently used for email and address books.</span></span>

> <span data-ttu-id="60ca4-109">**重要な Api**:[ListView クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)、 [SplitView クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)</span><span class="sxs-lookup"><span data-stu-id="60ca4-109">**Important APIs**: [ListView class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView), [SplitView class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)</span></span>

![マスター/詳細パターンの例](images/HIGSecOne_MasterDetail.png)

## <a name="is-this-the-right-pattern"></a><span data-ttu-id="60ca4-111">適切なパターンの選択</span><span class="sxs-lookup"><span data-stu-id="60ca4-111">Is this the right pattern?</span></span>

<span data-ttu-id="60ca4-112">次の場合は、マスター/詳細パターンが適しています。</span><span class="sxs-lookup"><span data-stu-id="60ca4-112">The master/details pattern works well if you want to:</span></span>

-   <span data-ttu-id="60ca4-113">メール アプリ、アドレス帳、またはリスト/詳細レイアウトをベースとするアプリを構築する。</span><span class="sxs-lookup"><span data-stu-id="60ca4-113">Build an email app, address book, or any app that is based on a list-details layout.</span></span>
-   <span data-ttu-id="60ca4-114">大きいコンテンツ コレクションを特定して優先順位を設定する。</span><span class="sxs-lookup"><span data-stu-id="60ca4-114">Locate and prioritize a large collection of content.</span></span>
-   <span data-ttu-id="60ca4-115">コンテキスト間を前後に移動しながら、リストから項目をすばやく追加および削除できるようにする。</span><span class="sxs-lookup"><span data-stu-id="60ca4-115">Allow the quick addition and removal of items from a list while working back-and-forth between contexts.</span></span>

## <a name="choose-the-right-style"></a><span data-ttu-id="60ca4-116">適切なスタイルの選択</span><span class="sxs-lookup"><span data-stu-id="60ca4-116">Choose the right style</span></span>

<span data-ttu-id="60ca4-117">マスター/詳細パターンを実装するとき、利用可能な画面領域の量に応じて、スタック スタイルまたは左右に並べるスタイルを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="60ca4-117">When implementing the master/details pattern, we recommend that you use either the stacked style or the side-by-side style, based on the amount of available screen space.</span></span>

| <span data-ttu-id="60ca4-118">利用可能なウィンドウの幅</span><span class="sxs-lookup"><span data-stu-id="60ca4-118">Available window width</span></span> | <span data-ttu-id="60ca4-119">推奨スタイル</span><span class="sxs-lookup"><span data-stu-id="60ca4-119">Recommended style</span></span> |
|------------------------|-------------------|
| <span data-ttu-id="60ca4-120">320 epx ～ 640 epx</span><span class="sxs-lookup"><span data-stu-id="60ca4-120">320 epx-640 epx</span></span>        | <span data-ttu-id="60ca4-121">スタック</span><span class="sxs-lookup"><span data-stu-id="60ca4-121">Stacked</span></span>           |
| <span data-ttu-id="60ca4-122">641 epx 以上</span><span class="sxs-lookup"><span data-stu-id="60ca4-122">641 epx or wider</span></span>       | <span data-ttu-id="60ca4-123">左右に並べる</span><span class="sxs-lookup"><span data-stu-id="60ca4-123">Side-by-side</span></span>      |

 
## <a name="stacked-style"></a><span data-ttu-id="60ca4-124">スタック スタイル</span><span class="sxs-lookup"><span data-stu-id="60ca4-124">Stacked style</span></span>

<span data-ttu-id="60ca4-125">スタック スタイルでは、マスター ウィンドウと詳細ウィンドウのうち 1 つのウィンドウだけが一度に表示されます。</span><span class="sxs-lookup"><span data-stu-id="60ca4-125">In the stacked style, only one pane is visible at a time: the master or the details.</span></span>

![スタック モードのマスター詳細](images/patterns-md-stacked.png)

<span data-ttu-id="60ca4-127">ユーザーがマスター ウィンドウで作業を始め、マスター リストで項目を選んで詳細ウィンドウに "ドリルダウン" します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-127">The user starts at the master pane and "drills down" to the details pane by selecting an item in the master list.</span></span> <span data-ttu-id="60ca4-128">ユーザーから見ると、マスター ビューと詳細ビューが別々の 2 つのページに存在するように表示されます。</span><span class="sxs-lookup"><span data-stu-id="60ca4-128">To the user, it appears as though the master and details views exist on two separate pages.</span></span>

### <a name="create-a-stacked-masterdetails-pattern"></a><span data-ttu-id="60ca4-129">スタック マスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="60ca4-129">Create a stacked master/details pattern</span></span>

<span data-ttu-id="60ca4-130">スタック マスター/詳細パターンを作る方法の 1 つは、マスター ウィンドウと詳細ウィンドウにそれぞれ別のページを使うことです。</span><span class="sxs-lookup"><span data-stu-id="60ca4-130">One way to create the stacked master/details pattern is to use separate pages for the master pane and the details pane.</span></span> <span data-ttu-id="60ca4-131">マスター ビューを 1 つのページに表示し、詳細ウィンドウを別のページに配置します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-131">Place the master view on one page, and the details pane on a separate page.</span></span>

![スタック スタイルのマスター詳細の構成要素](images/patterns-md-stacked-parts.png)

<span data-ttu-id="60ca4-133">マスター ビュー ページでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。</span><span class="sxs-lookup"><span data-stu-id="60ca4-133">For the master view page, a [list view](lists.md) control works well for presenting lists that can contain images and text.</span></span> 

<span data-ttu-id="60ca4-134">詳細ビュー ページの場合、最も意味のある[コンテンツ要素](../layout/layout-panels.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="60ca4-134">For the details view page, use the [content element](../layout/layout-panels.md) that makes the most sense.</span></span> <span data-ttu-id="60ca4-135">多くの個別フィールドがある場合は、**グリッド** レイアウトを使って要素をフォームに配置することを検討します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-135">If you have a lot of separate fields, consider using a **Grid** layout to arrange elements into a form.</span></span>

<span data-ttu-id="60ca4-136">ページ間の移動の詳細については、「[UWP アプリのナビゲーション履歴と前に戻る移動](../basics/navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="60ca4-136">For navigation between pages, see [navigation history and backwards navigation for UWP apps](../basics/navigation-history-and-backwards-navigation.md).</span></span>

## <a name="side-by-side-style"></a><span data-ttu-id="60ca4-137">左右に並べるスタイル</span><span class="sxs-lookup"><span data-stu-id="60ca4-137">Side-by-side style</span></span>

<span data-ttu-id="60ca4-138">横に並べるスタイルでは、マスター ウィンドウと詳細ウィンドウを同時に表示できます。</span><span class="sxs-lookup"><span data-stu-id="60ca4-138">In the side-by-side style, the master pane and details pane are visible at the same time.</span></span>

![マスター/詳細パターン](images/patterns-masterdetail-400x227.png)

<span data-ttu-id="60ca4-140">マスター ウィンドウのリストは、現在選択されている項目を示すために選択ビジュアルを使用します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-140">The list in the master pane has a selection visual to indicate the currently selected item.</span></span> <span data-ttu-id="60ca4-141">マスター リストで新しい項目を選ぶと、詳細ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="60ca4-141">Selecting a new item in the master list updates the details pane.</span></span>

### <a name="create-a-side-by-side-masterdetails-pattern"></a><span data-ttu-id="60ca4-142">左右に並べるマスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="60ca4-142">Create a side-by-side master/details pattern</span></span>

<span data-ttu-id="60ca4-143">サイド バイ サイドのマスター/詳細パターンを実装する 1 つの方法として、[分割ビュー](split-view.md) コントロールを使用する方法があります。</span><span class="sxs-lookup"><span data-stu-id="60ca4-143">One way to create a side-by-side master/details pattern is to use the [split view](split-view.md) control.</span></span> <span data-ttu-id="60ca4-144">分割ビューのウィンドウにマスター ビューを配置し、分割ビューのコンテンツに詳細ビューを配置します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-144">Place the master view in the split view pane, and the details view in the split view content.</span></span>

![マスター/詳細分割ビュー部品](images/patterns_md_splitview_parts.png)

<span data-ttu-id="60ca4-146">マスター ウィンドウでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。</span><span class="sxs-lookup"><span data-stu-id="60ca4-146">For the master pane, a [list view](lists.md) control works well for presenting lists that can contain images and text.</span></span>

<span data-ttu-id="60ca4-147">詳細コンテンツの場合、最も意味のある[コンテンツ要素](../layout/layout-panels.md) を使います。</span><span class="sxs-lookup"><span data-stu-id="60ca4-147">For the details content, use the [content element](../layout/layout-panels.md) that makes the most sense.</span></span> <span data-ttu-id="60ca4-148">多くの個別フィールドがある場合は、**グリッド** レイアウトを使って要素をフォームに配置することを検討します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-148">If you have a lot of separate fields, consider using a **Grid** layout to arrange elements into a form.</span></span>

## <a name="adaptive-layout"></a><span data-ttu-id="60ca4-149">アダプティブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="60ca4-149">Adaptive layout</span></span>

<span data-ttu-id="60ca4-150">マスター/詳細パターンをすべての画面サイズで実装するには、[アダプティブ レイアウト](../layout/layouts-with-xaml.md) で応答性の高い UI を作成します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-150">To implement a master/details pattern for any screen size, create a responsive UI with an [adaptive layout](../layout/layouts-with-xaml.md).</span></span>

![アダプティブ マスター詳細レイアウト](images/patterns_masterdetail.png)

### <a name="create-an-adaptive-masterdetails-pattern"></a><span data-ttu-id="60ca4-152">アダプティブ マスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="60ca4-152">Create an adaptive master/details pattern</span></span>
<span data-ttu-id="60ca4-153">アダプティブ レイアウトを作成するには、UI のさまざまな [**VisualStates**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.visualstate) を定義し、[**AdaptiveTriggers**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.AdaptiveTrigger) を使用して UI のさまざまな状態のブレークポイントを宣言します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-153">To create an adaptive layout, define different [**VisualStates**](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.visualstate) for your UI, and declare breakpoints for the different states with [**AdaptiveTriggers**](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.AdaptiveTrigger).</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="60ca4-154">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="60ca4-154">Get the sample code</span></span>

<span data-ttu-id="60ca4-155">次のサンプルでは、アダプティブ レイアウトを使用してマスター/詳細パターンを実装し、静的なリソース、データベース リソース、およびオンライン リソースに対するデータ バインディングを示します。</span><span class="sxs-lookup"><span data-stu-id="60ca4-155">The following samples implement the master/details pattern with adaptive layouts and demonstrate data binding to static, database, and online resources:</span></span> 
- [<span data-ttu-id="60ca4-156">マスター/詳細サンプル</span><span class="sxs-lookup"><span data-stu-id="60ca4-156">Master/detail sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlMasterDetail) 
- [<span data-ttu-id="60ca4-157">マスター/詳細とサンプルの選択</span><span class="sxs-lookup"><span data-stu-id="60ca4-157">Master/Details plus Selection sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlListView)
- [<span data-ttu-id="60ca4-158">Windows テンプレート Studio マスター/詳細サンプル</span><span class="sxs-lookup"><span data-stu-id="60ca4-158">Windows Template Studio Master/Detail sample</span></span>](https://github.com/Microsoft/WindowsTemplateStudio/tree/master/templates/Uwp/Pages/MasterDetail)
- [<span data-ttu-id="60ca4-159">顧客注文データベース サンプル</span><span class="sxs-lookup"><span data-stu-id="60ca4-159">Customer orders database sample</span></span>](https://github.com/Microsoft/Windows-appsample-customers-orders-database)
- [<span data-ttu-id="60ca4-160">RSS リーダーのサンプル</span><span class="sxs-lookup"><span data-stu-id="60ca4-160">RSS Reader sample</span></span>](https://github.com/Microsoft/Windows-appsample-rssreader)

## <a name="related-articles"></a><span data-ttu-id="60ca4-161">関連記事</span><span class="sxs-lookup"><span data-stu-id="60ca4-161">Related articles</span></span>

- [<span data-ttu-id="60ca4-162">リスト</span><span class="sxs-lookup"><span data-stu-id="60ca4-162">Lists</span></span>](lists.md)
- [<span data-ttu-id="60ca4-163">検索</span><span class="sxs-lookup"><span data-stu-id="60ca4-163">Search</span></span>](search.md)
- [<span data-ttu-id="60ca4-164">アプリとコマンド バー</span><span class="sxs-lookup"><span data-stu-id="60ca4-164">App and command bars</span></span>](app-bars.md)
- [<span data-ttu-id="60ca4-165">ListView クラス</span><span class="sxs-lookup"><span data-stu-id="60ca4-165">ListView class</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)
- [<span data-ttu-id="60ca4-166">SplitView クラス</span><span class="sxs-lookup"><span data-stu-id="60ca4-166">SplitView class</span></span>](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)
