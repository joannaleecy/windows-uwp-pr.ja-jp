---
author: Jwmsft
Description: "マスター/詳細パターンでは、マスター リストと、現在選択されている項目の詳細が表示されます。 このパターンは、メールや連絡先一覧/アドレス帳によく使用されます。"
title: "マスター/詳細"
ms.assetid: 45C9FE8B-ECA6-44BF-8DDE-7D12ED34A7F7
label: Master/details
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 49a586aac0c846cdad02f8448532238bd3eb8551
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="masterdetails-pattern"></a><span data-ttu-id="96f2d-105">マスター/詳細パターン</span><span class="sxs-lookup"><span data-stu-id="96f2d-105">Master/details pattern</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="96f2d-106">マスター/詳細パターンには、コンテンツのマスター ウィンドウ (通常は[リスト ビュー](lists.md)も表示されます) と詳細ウィンドウがあります。</span><span class="sxs-lookup"><span data-stu-id="96f2d-106">The master/details pattern has a master pane (usually with a [list view](lists.md)) and a details pane for content.</span></span> <span data-ttu-id="96f2d-107">マスター リストの項目を選ぶと、詳細ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="96f2d-107">When an item in the master list is selected, the details pane is updated.</span></span> <span data-ttu-id="96f2d-108">このパターンは、メールやアドレス帳によく使われます。</span><span class="sxs-lookup"><span data-stu-id="96f2d-108">This pattern is frequently used for email and address books.</span></span>

> <span data-ttu-id="96f2d-109">**重要な API**: [ListView クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)、[SplitView クラス](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)</span><span class="sxs-lookup"><span data-stu-id="96f2d-109">**Important APIs**: [ListView class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView), [SplitView class](https://docs.microsoft.com/en-us/uwp/api/windows.ui.xaml.controls.splitview)</span></span>

![マスター/詳細パターンの例](images/HIGSecOne_MasterDetail.png)

## <a name="is-this-the-right-pattern"></a><span data-ttu-id="96f2d-111">適切なパターンの選択</span><span class="sxs-lookup"><span data-stu-id="96f2d-111">Is this the right pattern?</span></span>

<span data-ttu-id="96f2d-112">次の場合は、マスター/詳細パターンが適しています。</span><span class="sxs-lookup"><span data-stu-id="96f2d-112">The master/details pattern works well if you want to:</span></span>

-   <span data-ttu-id="96f2d-113">メール アプリ、アドレス帳、またはリスト/詳細レイアウトをベースとするアプリを構築する。</span><span class="sxs-lookup"><span data-stu-id="96f2d-113">Build an email app, address book, or any app that is based on a list-details layout.</span></span>
-   <span data-ttu-id="96f2d-114">大きいコンテンツ コレクションを特定して優先順位を設定する。</span><span class="sxs-lookup"><span data-stu-id="96f2d-114">Locate and prioritize a large collection of content.</span></span>
-   <span data-ttu-id="96f2d-115">コンテキスト間を前後に移動しながら、リストから項目をすばやく追加および削除できるようにする。</span><span class="sxs-lookup"><span data-stu-id="96f2d-115">Allow the quick addition and removal of items from a list while working back-and-forth between contexts.</span></span>

## <a name="choose-the-right-style"></a><span data-ttu-id="96f2d-116">適切なスタイルの選択</span><span class="sxs-lookup"><span data-stu-id="96f2d-116">Choose the right style</span></span>

<span data-ttu-id="96f2d-117">マスター/詳細パターンを実装するとき、利用可能な画面領域の量に応じて、スタック スタイルまたは左右に並べるスタイルを使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="96f2d-117">When implementing the master/details pattern, we recommend that you use either the stacked style or the side-by-side style, based on the amount of available screen space.</span></span>

| <span data-ttu-id="96f2d-118">利用可能なウィンドウの幅</span><span class="sxs-lookup"><span data-stu-id="96f2d-118">Available window width</span></span> | <span data-ttu-id="96f2d-119">推奨スタイル</span><span class="sxs-lookup"><span data-stu-id="96f2d-119">Recommended style</span></span> |
|------------------------|-------------------|
| <span data-ttu-id="96f2d-120">320 epx ～ 719 epx</span><span class="sxs-lookup"><span data-stu-id="96f2d-120">320 epx-719 epx</span></span>        | <span data-ttu-id="96f2d-121">スタック</span><span class="sxs-lookup"><span data-stu-id="96f2d-121">Stacked</span></span>           |
| <span data-ttu-id="96f2d-122">720 epx 以上</span><span class="sxs-lookup"><span data-stu-id="96f2d-122">720 epx or wider</span></span>       | <span data-ttu-id="96f2d-123">左右に並べる</span><span class="sxs-lookup"><span data-stu-id="96f2d-123">Side-by-side</span></span>      |

 
## <a name="stacked-style"></a><span data-ttu-id="96f2d-124">スタック スタイル</span><span class="sxs-lookup"><span data-stu-id="96f2d-124">Stacked style</span></span>

<span data-ttu-id="96f2d-125">スタック スタイルでは、マスター ウィンドウと詳細ウィンドウのうち 1 つのウィンドウだけが一度に表示されます。</span><span class="sxs-lookup"><span data-stu-id="96f2d-125">In the stacked style, only one pane is visible at a time: the master or the details.</span></span>

![スタック モードのマスター詳細](images/patterns-md-stacked.png)

<span data-ttu-id="96f2d-127">ユーザーがマスター ウィンドウで作業を始め、マスター リストで項目を選んで詳細ウィンドウに "ドリルダウン" します。</span><span class="sxs-lookup"><span data-stu-id="96f2d-127">The user starts at the master pane and "drills down" to the details pane by selecting an item in the master list.</span></span> <span data-ttu-id="96f2d-128">ユーザーから見ると、マスター ビューと詳細ビューが別々の 2 つのページに存在するように表示されます。</span><span class="sxs-lookup"><span data-stu-id="96f2d-128">To the user, it appears as though the master and details views exist on two separate pages.</span></span>

### <a name="create-a-stacked-masterdetails-pattern"></a><span data-ttu-id="96f2d-129">スタック マスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="96f2d-129">Create a stacked master/details pattern</span></span>

<span data-ttu-id="96f2d-130">スタック マスター/詳細パターンを作る方法の 1 つは、マスター ウィンドウと詳細ウィンドウにそれぞれ別のページを使うことです。</span><span class="sxs-lookup"><span data-stu-id="96f2d-130">One way to create the stacked master/details pattern is to use separate pages for the master pane and the details pane.</span></span> <span data-ttu-id="96f2d-131">マスター リストを表示するリスト ビューを 1 つのページに配置し、詳細ウィンドウのコンテンツ要素を別のページに配置します。</span><span class="sxs-lookup"><span data-stu-id="96f2d-131">Place the list view that provides the master list on one page, and the content element for the details pane on a separate page.</span></span>

![スタック スタイルのマスター詳細の構成要素](images/patterns-md-stacked-parts.png)

<span data-ttu-id="96f2d-133">マスター ウィンドウでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。</span><span class="sxs-lookup"><span data-stu-id="96f2d-133">For the master pane, a [list view](lists.md) control works well for presenting lists that can contain images and text.</span></span>

<span data-ttu-id="96f2d-134">詳細ウィンドウの場合、最も意味のあるコンテンツ要素を使います。</span><span class="sxs-lookup"><span data-stu-id="96f2d-134">For the details pane, use the content element that makes the most sense.</span></span> <span data-ttu-id="96f2d-135">多くの個別フィールドがある場合は、グリッド レイアウトを使って要素をフォームに配置することを検討します。</span><span class="sxs-lookup"><span data-stu-id="96f2d-135">If you have a lot of separate fields, consider using a grid layout to arrange elements into a form.</span></span>

## <a name="side-by-side-style"></a><span data-ttu-id="96f2d-136">左右に並べるスタイル</span><span class="sxs-lookup"><span data-stu-id="96f2d-136">Side-by-side style</span></span>

<span data-ttu-id="96f2d-137">横に並べるスタイルでは、マスター ウィンドウと詳細ウィンドウを同時に表示できます。</span><span class="sxs-lookup"><span data-stu-id="96f2d-137">In the side-by-side style, the master pane and details pane are visible at the same time.</span></span>

![マスター/詳細パターン](images/patterns-masterdetail-400x227.png)

<span data-ttu-id="96f2d-139">マスター ウィンドウのリストは、現在選択されている項目を示すために選択ビジュアルを使用します。</span><span class="sxs-lookup"><span data-stu-id="96f2d-139">The list in the master pane has a selection visual to indicate the currently selected item.</span></span> <span data-ttu-id="96f2d-140">マスター リストで新しい項目を選ぶと、詳細ウィンドウが更新されます。</span><span class="sxs-lookup"><span data-stu-id="96f2d-140">Selecting a new item in the master list updates the details pane.</span></span>

### <a name="create-a-side-by-side-masterdetails-pattern"></a><span data-ttu-id="96f2d-141">左右に並べるマスター/詳細パターンの作成</span><span class="sxs-lookup"><span data-stu-id="96f2d-141">Create a side-by-side master/details pattern</span></span>

<span data-ttu-id="96f2d-142">マスター ウィンドウでは、イメージとテキストが含まれるリストを表示するのに[リスト ビュー](lists.md) コントロールが適しています。</span><span class="sxs-lookup"><span data-stu-id="96f2d-142">For the master pane, a [list view](lists.md) control works well for presenting lists that can contain images and text.</span></span>

<span data-ttu-id="96f2d-143">詳細ウィンドウの場合、最も意味のあるコンテンツ要素を使います。</span><span class="sxs-lookup"><span data-stu-id="96f2d-143">For the details pane, use the content element that makes the most sense.</span></span> <span data-ttu-id="96f2d-144">多くの個別フィールドがある場合は、グリッド レイアウトを使って要素をフォームに配置することを検討します。</span><span class="sxs-lookup"><span data-stu-id="96f2d-144">If you have a lot of separate fields, consider using a grid layout to arrange elements into a form.</span></span>

## <a name="get-the-code-samples"></a><span data-ttu-id="96f2d-145">コード サンプルを入手する</span><span class="sxs-lookup"><span data-stu-id="96f2d-145">Get the code samples</span></span>

<span data-ttu-id="96f2d-146">マスター/詳細パターンを示すサンプル コードについては、次のサンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="96f2d-146">For sample code that shows the master/details pattern, see these samples:</span></span> 

- [<span data-ttu-id="96f2d-147">顧客注文データベースのサンプル</span><span class="sxs-lookup"><span data-stu-id="96f2d-147">Customer orders database sample</span></span>](https://github.com/Microsoft/Windows-appsample-customers-orders-database) 
- [<span data-ttu-id="96f2d-148">ListView と GridView のサンプル</span><span class="sxs-lookup"><span data-stu-id="96f2d-148">ListView and GridView sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkId=619900)
- [<span data-ttu-id="96f2d-149">RSS リーダーのサンプル</span><span class="sxs-lookup"><span data-stu-id="96f2d-149">RSS Reader sample</span></span>](https://github.com/Microsoft/Windows-appsample-rssreader)

## <a name="related-articles"></a><span data-ttu-id="96f2d-150">関連記事</span><span class="sxs-lookup"><span data-stu-id="96f2d-150">Related articles</span></span>

- [<span data-ttu-id="96f2d-151">リスト</span><span class="sxs-lookup"><span data-stu-id="96f2d-151">Lists</span></span>](lists.md)
- [<span data-ttu-id="96f2d-152">検索</span><span class="sxs-lookup"><span data-stu-id="96f2d-152">Search</span></span>](search.md)
- [<span data-ttu-id="96f2d-153">アプリ バーとコマンド バー</span><span class="sxs-lookup"><span data-stu-id="96f2d-153">App and command bars</span></span>](app-bars.md)
- [<span data-ttu-id="96f2d-154">ListView クラス</span><span class="sxs-lookup"><span data-stu-id="96f2d-154">ListView class</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.ListView)
