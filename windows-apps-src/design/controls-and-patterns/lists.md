---
Description: リストでは、コレクション ベースのコンテンツを表示して対話式で操作できます。
title: リスト
ms.assetid: C73125E8-3768-46A5-B078-FDDF42AB1077
label: Lists
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: predavid
design-contact: kimsea
dev-contact: ranjeshj
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: eb9c600e58be04d8ce967eb119777d6746507fbe
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636367"
---
# <a name="lists"></a><span data-ttu-id="ed811-104">リスト</span><span class="sxs-lookup"><span data-stu-id="ed811-104">Lists</span></span>

<span data-ttu-id="ed811-105">リストでは、コレクション ベースのコンテンツを表示して対話式で操作できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-105">Lists display and enable interactions with collection-based content.</span></span> <span data-ttu-id="ed811-106">この記事では、次に示す 4 種類のリスト パターンについて説明します。</span><span class="sxs-lookup"><span data-stu-id="ed811-106">The four list patterns covered in this article include:</span></span>

-   <span data-ttu-id="ed811-107">リスト ビュー: 主に、テキストの多いコンテンツのコレクションを表示するために使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-107">List views, which are primarily used to display text-heavy content collections</span></span>
-   <span data-ttu-id="ed811-108">グリッド ビュー: 主に、画像の多いコンテンツのコレクションを表示するために使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-108">Grid views, which are primarily used to display image-heavy content collections</span></span>
-   <span data-ttu-id="ed811-109">ドロップダウン リスト: 拡張可能なリストから、ユーザーが 1 つの項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-109">Drop-down lists, which let users choose one item from an expanding list</span></span>
-   <span data-ttu-id="ed811-110">リスト ボックス: スクロール可能なボックスから、ユーザーが 1 つまたは複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-110">List boxes, which let users choose one item or multiple items from a box that can be scrolled</span></span>

<span data-ttu-id="ed811-111">ここでは、各リスト パターンについて、設計のガイドライン、特徴、例を示します。</span><span class="sxs-lookup"><span data-stu-id="ed811-111">Design guidelines, features, and examples are given for each list pattern.</span></span>

> <span data-ttu-id="ed811-112">**重要な API**:[ListView クラス](https://msdn.microsoft.com/library/windows/apps/br242878)、 [GridView クラス](https://msdn.microsoft.com/library/windows/apps/br242705)、 [ComboBox クラス](https://msdn.microsoft.com/library/windows/apps/br209348)</span><span class="sxs-lookup"><span data-stu-id="ed811-112">**Important APIs**: [ListView class](https://msdn.microsoft.com/library/windows/apps/br242878), [GridView class](https://msdn.microsoft.com/library/windows/apps/br242705), [ComboBox class](https://msdn.microsoft.com/library/windows/apps/br209348)</span></span>


> <div id="main"><span data-ttu-id="ed811-113">
> <strong>Windows 10 Fall Creators Update の動作の変更</strong>
> </span><span class="sxs-lookup"><span data-stu-id="ed811-113">
> <strong>Windows 10 Fall Creators Update - Behavior change</strong>
> </span></span></div>
<span data-ttu-id="ed811-114">既定では、UWP アプリでは、アクティブ ペンは、選択の実行ではなく、リストのスクロール/パン (タッチ、タッチパッド、パッシブ ペンなどと同様に) をするようになりました。</span><span class="sxs-lookup"><span data-stu-id="ed811-114">By default, instead of performing selection, an active pen now scrolls/pans a list in UWP apps (like touch, touchpad, and passive pen).</span></span>
<span data-ttu-id="ed811-115">アプリが以前の動作に依存している場合は、ペン スクロールを上書きして、以前の動作に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-115">If your app depends on the previous behavior, you can override pen scrolling and revert to the previous behavior.</span></span> <span data-ttu-id="ed811-116">詳細については、API リファレンスのトピックを参照してください、 <a href="https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer">ScrollViewer クラス</a>します。</span><span class="sxs-lookup"><span data-stu-id="ed811-116">For details, see the API reference topic for the <a href="https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer">ScrollViewer Class</a>.</span></span>

## <a name="list-views"></a><span data-ttu-id="ed811-117">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="ed811-117">List views</span></span>

<span data-ttu-id="ed811-118">リスト ビューでは、項目の分類、グループ ヘッダーの割り当て、項目のドラッグ アンド ドロップ、コンテンツの管理、項目の順序変更を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-118">List views let you categorize items and assign group headers, drag and drop items, curate content, and reorder items.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="ed811-119">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="ed811-119">Is this the right control?</span></span>

<span data-ttu-id="ed811-120">グリッド ビューは、次の用途で使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-120">Use a list view to:</span></span>

-   <span data-ttu-id="ed811-121">主にテキストで構成されるコンテンツのコレクションを表示する。</span><span class="sxs-lookup"><span data-stu-id="ed811-121">Display a content collection that primarily consists of text.</span></span>
-   <span data-ttu-id="ed811-122">コンテンツの単一のコレクションまたはカテゴリ別コレクションをナビゲートする。</span><span class="sxs-lookup"><span data-stu-id="ed811-122">Navigate a single or categorized collection of content.</span></span>
-   <span data-ttu-id="ed811-123">[マスター/詳細パターン](master-details.md)のマスター ウィンドウを作成する。</span><span class="sxs-lookup"><span data-stu-id="ed811-123">Create the master pane in the [master/details pattern](master-details.md).</span></span> <span data-ttu-id="ed811-124">マスター/詳細パターンは、メール アプリによく使われます。このパターンでは、選択できる項目の一覧を一方のウィンドウ (マスター) に表示し、選択された項目の詳細ビューをもう一方のウィンドウ (詳細) に表示します。</span><span class="sxs-lookup"><span data-stu-id="ed811-124">A master/details pattern is often used in email apps, in which one pane (the master) has a list of selectable items while the other pane (details) has a detailed view of the selected item.</span></span>

### <a name="examples"></a><span data-ttu-id="ed811-125">例</span><span class="sxs-lookup"><span data-stu-id="ed811-125">Examples</span></span>

<span data-ttu-id="ed811-126">これは、電話での単純なリスト ビューの例で、グループ化されたデータを表示しています。</span><span class="sxs-lookup"><span data-stu-id="ed811-126">Here's a simple list view showing grouped data on a phone.</span></span>

![グループ化されたデータを表示するリスト ビュー](images/simple-list-view-phone.png)

### <a name="recommendations"></a><span data-ttu-id="ed811-128">推奨事項</span><span class="sxs-lookup"><span data-stu-id="ed811-128">Recommendations</span></span>

-   <span data-ttu-id="ed811-129">同じリストに含まれる各項目の動作は同じにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-129">Items within a list should have the same behavior.</span></span>
-   <span data-ttu-id="ed811-130">リストがグループに分割されている場合、グループ化されたコンテンツ内をユーザーが移動しやすくなるように、[セマンティック ズーム](semantic-zoom.md)を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-130">If your list is divided into groups, you can use [semantic zoom](semantic-zoom.md) to make it easier for users to navigate through grouped content.</span></span>

### <a name="list-view-articles"></a><span data-ttu-id="ed811-131">リスト ビューに関する記事</span><span class="sxs-lookup"><span data-stu-id="ed811-131">List view articles</span></span>
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="ed811-132">トピック</span><span class="sxs-lookup"><span data-stu-id="ed811-132">Topic</span></span></th>
<th align="left"><span data-ttu-id="ed811-133">説明</span><span class="sxs-lookup"><span data-stu-id="ed811-133">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="ed811-134"><a href="listview-and-gridview.md">リスト ビューおよびグリッド ビュー</a></span><span class="sxs-lookup"><span data-stu-id="ed811-134"><a href="listview-and-gridview.md">List view and grid view</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-135">アプリでリスト ビューやグリッド ビューを使用するための基本情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="ed811-135">Learn the essentials of using a list view or grid view in your app.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="ed811-136"><a href="item-containers-templates.md">項目コンテナーとテンプレート</a></span><span class="sxs-lookup"><span data-stu-id="ed811-136"><a href="item-containers-templates.md">Item containers and templates</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-137">リストやグリッドに表示される項目は、アプリの全体的な見た目を左右する要素になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-137">The items you display in a list or grid can play a major role in the overall look of your app.</span></span> <span data-ttu-id="ed811-138">コントロール テンプレートとデータ テンプレートを変更して、項目の外観を定義し、アプリの見栄えをよくします。</span><span class="sxs-lookup"><span data-stu-id="ed811-138">Modify control templates and data templates to define the look of the items and make your app look great.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="ed811-139"><a href="item-templates-listview.md">リスト ビューの項目テンプレート</a></span><span class="sxs-lookup"><span data-stu-id="ed811-139"><a href="item-templates-listview.md">Item templates for list view</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-140">これらの ListView 用のサンプル項目テンプレートを使って、一般的な種類のアプリの外観を設定できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-140">Use these example item templates for a ListView to get the look of common app types.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="ed811-141"><a href="inverted-lists.md">反転されたリスト</a></span><span class="sxs-lookup"><span data-stu-id="ed811-141"><a href="inverted-lists.md">Inverted lists</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-142">反転リストでは、チャット アプリのように、新しい項目が下部に追加されます。</span><span class="sxs-lookup"><span data-stu-id="ed811-142">Inverted lists have new items added at the bottom, like in a chat app.</span></span> <span data-ttu-id="ed811-143">アプリで反転リストを使用する場合は、こちらのガイダンスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="ed811-143">Follow this guidance to use an inverted list in your app.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="ed811-144"><a href="pull-to-refresh.md">プルの更新</a></span><span class="sxs-lookup"><span data-stu-id="ed811-144"><a href="pull-to-refresh.md">Pull-to-refresh</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-145">引っ張って更新パターンを使うと、より多くのデータを取得するためにタッチ操作でデータのリストを引き下げることができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-145">The pull-to-refresh pattern lets a user pull down on a list of data using touch in order to retrieve more data.</span></span> <span data-ttu-id="ed811-146">リスト ビューに引っ張って更新を実装する場合は、こちらのガイダンスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="ed811-146">Use this guidance to implement pull-to-refresh in your list view.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="ed811-147"><a href="nested-ui.md">入れ子になった UI</a></span><span class="sxs-lookup"><span data-stu-id="ed811-147"><a href="nested-ui.md">Nested UI</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-148">入れ子になった UI は、ユーザーも操作が可能なコンテナー内部に囲まれた、操作できるコントロールを公開するユーザー インターフェイス (UI) です。</span><span class="sxs-lookup"><span data-stu-id="ed811-148">Nested UI is a user interface (UI) that exposes actionable controls enclosed inside a container that a user can also take action on.</span></span> <span data-ttu-id="ed811-149">たとえば、ボタンを含むリスト ビュー項目があるとします。ユーザーはそのリスト項目を選択することも、項目内に入れ子になっているボタンを押すこともできます。</span><span class="sxs-lookup"><span data-stu-id="ed811-149">For example, you might have list view item that contains a button, and the user can select the list item, or press the button nested within it.</span></span> <span data-ttu-id="ed811-150">以下のベスト プラクティスに従って、ユーザーにとって最適な入れ子になった UI のエクスペリエンスを提供してください。</span><span class="sxs-lookup"><span data-stu-id="ed811-150">Follow these best practices to provide the best nested UI experience for your users.</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="grid-views"></a><span data-ttu-id="ed811-151">グリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="ed811-151">Grid views</span></span>

<span data-ttu-id="ed811-152">グリッド ビューは、画像ベースのコンテンツのコレクションを配置および閲覧する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="ed811-152">Grid views are suited for arranging and browsing image-based content collections.</span></span> <span data-ttu-id="ed811-153">グリッド ビュー レイアウトでは、スクロールが垂直方向、パンが水平方向で行われます。</span><span class="sxs-lookup"><span data-stu-id="ed811-153">A grid view layout scrolls vertically and pans horizontally.</span></span> <span data-ttu-id="ed811-154">項目は、左から右、上から下の読み取り順序で配置されます。</span><span class="sxs-lookup"><span data-stu-id="ed811-154">Items are laid out in a left-to-right, then top-to-bottom reading order.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="ed811-155">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="ed811-155">Is this the right control?</span></span>

<span data-ttu-id="ed811-156">グリッド ビューは、次の用途で使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-156">Use a list view to:</span></span>

-   <span data-ttu-id="ed811-157">主に画像で構成されるコンテンツのコレクションを表示する。</span><span class="sxs-lookup"><span data-stu-id="ed811-157">Display a content collection that primarily consists of images.</span></span>
-   <span data-ttu-id="ed811-158">コンテンツ ライブラリを表示する。</span><span class="sxs-lookup"><span data-stu-id="ed811-158">Display content libraries.</span></span>
-   <span data-ttu-id="ed811-159">[セマンティック ズーム](semantic-zoom.md)に関連付けられた 2 つのコンテンツ ビューの形式を設定する。</span><span class="sxs-lookup"><span data-stu-id="ed811-159">Format the two content views associated with [semantic zoom](semantic-zoom.md).</span></span>

### <a name="examples"></a><span data-ttu-id="ed811-160">例</span><span class="sxs-lookup"><span data-stu-id="ed811-160">Examples</span></span>

<span data-ttu-id="ed811-161">ここでは、アプリの参照用を例として、標準的なグリッド ビューのレイアウトを示します。</span><span class="sxs-lookup"><span data-stu-id="ed811-161">This example shows a typical grid view layout, in this case for browsing apps.</span></span> <span data-ttu-id="ed811-162">グリッド ビュー項目のメタデータは通常、数行のテキストと項目の評価に制限されます。</span><span class="sxs-lookup"><span data-stu-id="ed811-162">Metadata for grid view items is usually restricted to a few lines of text and an item rating.</span></span>

![グリッド ビューのレイアウトの例](images/controls_gridview_example02.png)

<span data-ttu-id="ed811-164">グリッド ビューは、写真やビデオなどのメディアを表示するためによく使用される、コンテンツ ライブラリに最適なソリューションです。</span><span class="sxs-lookup"><span data-stu-id="ed811-164">A grid view is an ideal solution for a content library, which is often used to present media such as pictures and videos.</span></span> <span data-ttu-id="ed811-165">コンテンツ ライブラリでは、ユーザーが項目をタップして動作を開始します。</span><span class="sxs-lookup"><span data-stu-id="ed811-165">In a content library, users expect to be able to tap an item to invoke an action.</span></span>

![コンテンツ ライブラリの例](images/controls_list_contentlibrary.png)

### <a name="recommendations"></a><span data-ttu-id="ed811-167">推奨事項</span><span class="sxs-lookup"><span data-stu-id="ed811-167">Recommendations</span></span>

-   <span data-ttu-id="ed811-168">同じリストに含まれる各項目の動作は同じにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-168">Items within a list should have the same behavior.</span></span>
-   <span data-ttu-id="ed811-169">リストがグループに分割されている場合、グループ化されたコンテンツ内をユーザーが移動しやすくなるように、[セマンティック ズーム](semantic-zoom.md)を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-169">If your list is divided into groups, you can use [semantic zoom](semantic-zoom.md) to make it easier for users to navigate through grouped content.</span></span>

### <a name="grid-view-articles"></a><span data-ttu-id="ed811-170">グリッド ビューの記事</span><span class="sxs-lookup"><span data-stu-id="ed811-170">Grid view articles</span></span>
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="ed811-171">トピック</span><span class="sxs-lookup"><span data-stu-id="ed811-171">Topic</span></span></th>
<th align="left"><span data-ttu-id="ed811-172">説明</span><span class="sxs-lookup"><span data-stu-id="ed811-172">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><span data-ttu-id="ed811-173"><a href="listview-and-gridview.md">リスト ビューおよびグリッド ビュー</a></span><span class="sxs-lookup"><span data-stu-id="ed811-173"><a href="listview-and-gridview.md">List view and grid view</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-174">アプリでリスト ビューやグリッド ビューを使用するための基本情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="ed811-174">Learn the essentials of using a list view or grid view in your app.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="ed811-175"><a href="item-containers-templates.md">項目コンテナーとテンプレート</a></span><span class="sxs-lookup"><span data-stu-id="ed811-175"><a href="item-containers-templates.md">Item containers and templates</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-176">リストやグリッドに表示される項目は、アプリの全体的な見た目を左右する要素になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-176">The items you display in a list or grid can play a major role in the overall look of your app.</span></span> <span data-ttu-id="ed811-177">コントロール テンプレートとデータ テンプレートを変更して、項目の外観を定義し、アプリの見栄えをよくします。</span><span class="sxs-lookup"><span data-stu-id="ed811-177">Modify control templates and data templates to define the look of the items and make your app look great.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p><span data-ttu-id="ed811-178"><a href="item-templates-gridview.md">グリッド ビューの項目テンプレート</a></span><span class="sxs-lookup"><span data-stu-id="ed811-178"><a href="item-templates-gridview.md">Item templates for grid view</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-179">これらの GridView 用のサンプル項目テンプレートを使って、一般的な種類のアプリの外観を設定できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-179">Use these example item templates for GridView to get the look of common app types.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p><span data-ttu-id="ed811-180"><a href="nested-ui.md">入れ子になった UI</a></span><span class="sxs-lookup"><span data-stu-id="ed811-180"><a href="nested-ui.md">Nested UI</a></span></span></p></td>
<td align="left"><p><span data-ttu-id="ed811-181">入れ子になった UI は、ユーザーも操作が可能なコンテナー内部に囲まれた、操作できるコントロールを公開するユーザー インターフェイス (UI) です。</span><span class="sxs-lookup"><span data-stu-id="ed811-181">Nested UI is a user interface (UI) that exposes actionable controls enclosed inside a container that a user can also take action on.</span></span> <span data-ttu-id="ed811-182">たとえば、ボタンを含むリスト ビュー項目があるとします。ユーザーはそのリスト項目を選択することも、項目内に入れ子になっているボタンを押すこともできます。</span><span class="sxs-lookup"><span data-stu-id="ed811-182">For example, you might have list view item that contains a button, and the user can select the list item, or press the button nested within it.</span></span> <span data-ttu-id="ed811-183">以下のベスト プラクティスに従って、ユーザーにとって最適な入れ子になった UI のエクスペリエンスを提供してください。</span><span class="sxs-lookup"><span data-stu-id="ed811-183">Follow these best practices to provide the best nested UI experience for your users.</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="drop-down-lists"></a><span data-ttu-id="ed811-184">ドロップダウン リスト</span><span class="sxs-lookup"><span data-stu-id="ed811-184">Drop-down lists</span></span>

<span data-ttu-id="ed811-185">ドロップダウン リストはコンボ ボックスとも呼ばれます。最初はコンパクトな状態ですが、拡張して、選択可能な項目の一覧を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-185">Drop-down lists, also known as combo boxes, start in a compact state and expand to show a list of selectable items.</span></span> <span data-ttu-id="ed811-186">選ばれた項目は常に表示されます。表示されていない項目は、コンボ ボックスをタップして拡張すると表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed811-186">The selected item is always visible, and non-visible items can be brought into view when the user taps the combo box to expand it.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="ed811-187">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="ed811-187">Is this the right control?</span></span>

-   <span data-ttu-id="ed811-188">1 行のテキストで十分に表すことができる項目のセットから、ユーザーが単一の値を選ぶことができるようにするには、ドロップダウン リストを使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-188">Use a drop-down list to let users select a single value from a set of items that can be adequately represented with single lines of text.</span></span>
-   <span data-ttu-id="ed811-189">複数のテキスト行や画像が含まれる項目を表示するには、コンボ ボックスではなくリスト ビューまたはグリッド ビューを使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-189">Use a list or grid view instead of a combo box to display items that contain multiple lines of text or images.</span></span>
-   <span data-ttu-id="ed811-190">項目が 5 個より少ない場合は、[ラジオ ボタン](radio-button.md) (1 つの項目だけを選ぶことができる場合)、または[チェック ボックス](checkbox.md) (複数の項目を選ぶことができる場合) の使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="ed811-190">When there are fewer than five items, consider using [radio buttons](radio-button.md) (if only one item can be selected) or [check boxes](checkbox.md) (if multiple items can be selected).</span></span>
-   <span data-ttu-id="ed811-191">選択項目がアプリのフローにおいて二次的な重要性しか持たない場合は、コンボ ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-191">Use a combo box when the selection items are of secondary importance in the flow of your app.</span></span> <span data-ttu-id="ed811-192">多くの状況でほとんどのユーザーに対して既定のオプションが推奨されている場合、リスト ビューを使ってすべての項目を表示すると、既定以外のオプションに必要以上の注意を引いてしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-192">If the default option is recommended for most users in most situations, showing all the items by using a list view might draw more attention to the options than necessary.</span></span> <span data-ttu-id="ed811-193">コンボ ボックスを使うことで、領域を節約し、無駄な情報を最小限にすることができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-193">You can save space and minimize distraction by using a combo box.</span></span>

### <a name="examples"></a><span data-ttu-id="ed811-194">例</span><span class="sxs-lookup"><span data-stu-id="ed811-194">Examples</span></span>

<span data-ttu-id="ed811-195">コンパクトな状態のコンボ ボックスには、ヘッダーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-195">A combo box in its compact state can show a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

<span data-ttu-id="ed811-197">コンボ ボックスは、長い文字列の幅をサポートするために拡張できますが、読みづらくなるような長すぎる文字列は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="ed811-197">Although combo boxes expand to support longer string lengths, avoid excessively long strings that are difficult to read.</span></span>

![長い文字列のドロップダウン リストの例](images/combo_box_listitemstate.png)

<span data-ttu-id="ed811-199">コンボ ボックス内のコレクションが一定の長さに達すると、対応できるようにスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed811-199">If the collection in a combo box is long enough, a scroll bar will appear to accommodate it.</span></span> <span data-ttu-id="ed811-200">リスト内の項目は論理的にグループ化します。</span><span class="sxs-lookup"><span data-stu-id="ed811-200">Group items logically in the list.</span></span>

![ドロップダウン リストに表示されたスクロール バーの例](images/combo_box_scroll.png)

### <a name="recommendations"></a><span data-ttu-id="ed811-202">推奨事項</span><span class="sxs-lookup"><span data-stu-id="ed811-202">Recommendations</span></span>

-   <span data-ttu-id="ed811-203">コンボ ボックス項目のテキストのコンテンツは、単一行に制限します。</span><span class="sxs-lookup"><span data-stu-id="ed811-203">Limit the text content of combo box items to a single line.</span></span>
-   <span data-ttu-id="ed811-204">コンボ ボックス内の項目は、最も論理的な順序に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="ed811-204">Sort items in a combo box in the most logical order.</span></span> <span data-ttu-id="ed811-205">関連するオプションをグループ化し、最も一般的なオプションを先頭に配置します。</span><span class="sxs-lookup"><span data-stu-id="ed811-205">Group together related options and place the most common options at the top.</span></span> <span data-ttu-id="ed811-206">名前はアルファベット順、数値は数値順、日付は時系列順に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="ed811-206">Sort names in alphabetical order, numbers in numerical order, and dates in chronological order.</span></span>
-   <span data-ttu-id="ed811-207">ユーザーが方向キーを押している間にライブ更新するコンボ ボックスを作成するには (フォント選択ドロップダウン リストなど)、SelectionChangedTrigger を Always に設定します。</span><span class="sxs-lookup"><span data-stu-id="ed811-207">To make a combo box that live updates while the user is using the arrow keys (like a Font selection drop-down), set SelectionChangedTrigger to “Always”.</span></span>  

### <a name="text-search"></a><span data-ttu-id="ed811-208">テキスト検索</span><span class="sxs-lookup"><span data-stu-id="ed811-208">Text Search</span></span>

<span data-ttu-id="ed811-209">コンボ ボックスでは、コレクション内を自動的に検索できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-209">Combo boxes automatically support search within their collections.</span></span> <span data-ttu-id="ed811-210">開かれた状態または閉じた状態のコンボ ボックスにフォーカスがあるときに、物理的なキーボードで文字を入力すると、ユーザーが入力した文字列に一致する候補がビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="ed811-210">As users type characters on a physical keyboard while focused on an open or closed combo box, candidates matching the user's string are brought into view.</span></span> <span data-ttu-id="ed811-211">この機能は、長いリストを操作するときに特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ed811-211">This functionality is especially helpful when navigating a long list.</span></span> <span data-ttu-id="ed811-212">たとえば、州のリストが含まれているドロップダウンを操作するとき、“w” キーを押すと、“Washington” (ワシントン) がビューに表示され、すばやく選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="ed811-212">For example, when interacting with a drop-down containing a list of states, users can press the “w” key to bring “Washington” into view for quick selection.</span></span>


## <a name="list-boxes"></a><span data-ttu-id="ed811-213">リスト ボックス</span><span class="sxs-lookup"><span data-stu-id="ed811-213">List boxes</span></span>

<span data-ttu-id="ed811-214">リスト ボックスを使うと、ユーザーはコレクションから 1 つまたは複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-214">A list box allows the user to choose either a single item or multiple items from a collection.</span></span> <span data-ttu-id="ed811-215">リスト ボックスはドロップダウン リストと似ていますが、常に開いている点がドロップダウン リストと異なります。リスト ボックスには、コンパクトな (展開されていない) 状態がありません。</span><span class="sxs-lookup"><span data-stu-id="ed811-215">List boxes are similar to drop-down lists, except that list boxes are always open—there is no compact (non-expanded) state for a list box.</span></span> <span data-ttu-id="ed811-216">すべての項目を表示する領域がない場合には、リスト内の項目をスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="ed811-216">Items in the list can be scrolled if there isn't space to show everything.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="ed811-217">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="ed811-217">Is this the right control?</span></span>

-   <span data-ttu-id="ed811-218">リスト ボックスは、リスト内の項目が重要であるため目立つように表示する場合や、項目一式を表示するための十分な画面領域がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="ed811-218">A list box can be useful when items in the list are important enough to prominently display, and when there's enough screen real estate, to show the full list.</span></span>
-   <span data-ttu-id="ed811-219">リスト ボックスでは、重要な選択で完全な代替セットにユーザーの注意を向ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-219">A list box should draw the user's attention to the full set of alternatives in an important choice.</span></span> <span data-ttu-id="ed811-220">ドロップダウン リストの場合はまず、選択した項目にユーザーの注意を引き付けます。</span><span class="sxs-lookup"><span data-stu-id="ed811-220">By contrast, a drop-down list initially draws the user's attention to the selected item.</span></span>
-   <span data-ttu-id="ed811-221">次のような場合はリスト ボックスの使用を避けてください。</span><span class="sxs-lookup"><span data-stu-id="ed811-221">Avoid using a list box if:</span></span>
    -   <span data-ttu-id="ed811-222">リスト内の項目が非常に少ない場合。</span><span class="sxs-lookup"><span data-stu-id="ed811-222">There is a very small number of items for the list.</span></span> <span data-ttu-id="ed811-223">単一選択のリスト ボックスで常に同じ 2 つのオプションを提示するのであれば、[オプション ボタン](radio-button.md)の方が適している可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-223">A single-select list box that always has the same 2 options might be better presented as [radio buttons](radio-button.md).</span></span> <span data-ttu-id="ed811-224">3 ～ 4 個の静的な項目を提示する場合もオプション ボタンの使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="ed811-224">Also consider using radio buttons when there are 3 or 4 static items in the list.</span></span>
    -   <span data-ttu-id="ed811-225">リスト ボックスが単一選択であり、リスト内のオプションが常に同じ 2 項目で、その一方が他方の否定を意味している場合 ("オン" と "オフ" など)。</span><span class="sxs-lookup"><span data-stu-id="ed811-225">The list box is single-select and it always has the same 2 options where one can be implied as not the other, such as "on" and "off."</span></span> <span data-ttu-id="ed811-226">このような場合は、単一のチェック ボックスまたはトグル スイッチを使用してください。</span><span class="sxs-lookup"><span data-stu-id="ed811-226">Use a single check box or a toggle switch.</span></span>
    -   <span data-ttu-id="ed811-227">項目数が非常に多い場合。</span><span class="sxs-lookup"><span data-stu-id="ed811-227">There is a very large number of items.</span></span> <span data-ttu-id="ed811-228">長いリストには、グリッド ビューまたはリスト ビューの方が適しています。</span><span class="sxs-lookup"><span data-stu-id="ed811-228">A better choice for long lists are grid view and list view.</span></span> <span data-ttu-id="ed811-229">グループ化されたデータの非常に長いリストの場合はセマンティック ズームの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ed811-229">For very long lists of grouped data, semantic zoom is preferred.</span></span>
    -   <span data-ttu-id="ed811-230">項目が連続する数値である場合。</span><span class="sxs-lookup"><span data-stu-id="ed811-230">The items are contiguous numerical values.</span></span> <span data-ttu-id="ed811-231">このような場合は、[スライダー](slider.md)の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="ed811-231">If that's the case, consider using a [slider](slider.md).</span></span>
    -   <span data-ttu-id="ed811-232">選択項目がアプリのフローで二次的な重要性しか持たないか、または大半の状況で大半のユーザーに既定のオプションが推奨される場合。</span><span class="sxs-lookup"><span data-stu-id="ed811-232">The selection items are of secondary importance in the flow of your app or the default option is recommended for most users in most situations.</span></span> <span data-ttu-id="ed811-233">このような場合は、ドロップダウン リストを使用してください。</span><span class="sxs-lookup"><span data-stu-id="ed811-233">Use a drop-down list instead.</span></span>

### <a name="recommendations"></a><span data-ttu-id="ed811-234">推奨事項</span><span class="sxs-lookup"><span data-stu-id="ed811-234">Recommendations</span></span>

-   <span data-ttu-id="ed811-235">リスト ボックス内の項目数の最適な範囲は 3 ～ 9 です。</span><span class="sxs-lookup"><span data-stu-id="ed811-235">The ideal range of items in a list box is 3 to 9.</span></span>
-   <span data-ttu-id="ed811-236">リスト ボックスは、項目が動的に変化する可能性がある場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="ed811-236">A list box works well when its items can dynamically vary.</span></span>
-   <span data-ttu-id="ed811-237">可能であれば、項目のリストのパンまたはスクロールが必要にならないように、リスト ボックスのサイズを設定します。</span><span class="sxs-lookup"><span data-stu-id="ed811-237">If possible, set the size of a list box so that its list of items don't need to be panned or scrolled.</span></span>
-   <span data-ttu-id="ed811-238">リスト ボックスの目的、および現在選択されている項目が明確であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ed811-238">Verify that the purpose of the list box, and which items are currently selected, is clear.</span></span>
-   <span data-ttu-id="ed811-239">タッチ フィードバックおよび項目の選択状態の視覚効果とアニメーションを予約します。</span><span class="sxs-lookup"><span data-stu-id="ed811-239">Reserve visual effects and animations for touch feedback, and for the selected state of items.</span></span>
-   <span data-ttu-id="ed811-240">リスト ボックス項目のテキストのコンテンツは、単一行に制限します。</span><span class="sxs-lookup"><span data-stu-id="ed811-240">Limit the list box item's text content to a single line.</span></span> <span data-ttu-id="ed811-241">項目がビジュアルである場合、サイズをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="ed811-241">If the items are visuals, you can customize the size.</span></span> <span data-ttu-id="ed811-242">項目に複数行のテキストまたは画像が含まれる場合は、グリッド ビューまたはリスト ビューを使用してください。</span><span class="sxs-lookup"><span data-stu-id="ed811-242">If an item contains multiple lines of text or images, instead use a grid view or list view.</span></span>
-   <span data-ttu-id="ed811-243">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="ed811-243">Use the default font unless your brand guidelines indicate to use another.</span></span>
-   <span data-ttu-id="ed811-244">コマンドの実行または他のコントロールの動的な表示と非表示の切り替えのためにリスト ボックスを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="ed811-244">Don't use a list box to perform commands or to dynamically show or hide other controls.</span></span>

## <a name="selection-mode"></a><span data-ttu-id="ed811-245">選択モード</span><span class="sxs-lookup"><span data-stu-id="ed811-245">Selection mode</span></span>

<span data-ttu-id="ed811-246">選択モードでは、単一の項目または複数の項目を選択して、それらの項目に対して操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-246">Selection mode lets users select and take action on a single item or on multiple items.</span></span> <span data-ttu-id="ed811-247">選択モードは、コンテキスト メニュー、Crtl キーまたは Shift キーを押しながらの項目のクリック、またはギャラリー ビューでの項目に対するターゲットのロールオーバーによって起動できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-247">It can be invoked through a context menu, by using CTRL+click or SHIFT+click on an item, or by rolling-over a target on an item in a gallery view.</span></span> <span data-ttu-id="ed811-248">選択モードがアクティブであるとき、各リスト項目の横にチェック ボックスを表示し、画面の上部または下部に操作を表示できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-248">When selection mode is active, check boxes appear next to each list item, and actions can appear at the top or the bottom of the screen.</span></span>

<span data-ttu-id="ed811-249">選択モードには、次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="ed811-249">There are three selection modes:</span></span>

-   <span data-ttu-id="ed811-250">1 つ。ユーザーは、一度に 1 つだけの項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-250">Single: The user can select only one item at a time.</span></span>
-   <span data-ttu-id="ed811-251">複数。ユーザーは、修飾子を使用しても、複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-251">Multiple: The user can select multiple items without using a modifier.</span></span>
-   <span data-ttu-id="ed811-252">拡張。ユーザーは、SHIFT キーを押しながらなどの修飾子を使って複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-252">Extended: The user can select multiple items with a modifier, such as holding down the SHIFT key.</span></span>

<span data-ttu-id="ed811-253">項目の任意の場所をタップすると、項目が選ばれます。</span><span class="sxs-lookup"><span data-stu-id="ed811-253">Tapping anywhere on an item selects it.</span></span> <span data-ttu-id="ed811-254">コマンド バーの操作をタップすると、選択したすべての項目に影響します。</span><span class="sxs-lookup"><span data-stu-id="ed811-254">Tapping on the command bar action affects all selected items.</span></span> <span data-ttu-id="ed811-255">項目が選ばれていない場合、コマンド バーの操作は [すべて選択] を除いて非アクティブになります。</span><span class="sxs-lookup"><span data-stu-id="ed811-255">If no item is selected, command bar actions should be inactive, except for "Select All".</span></span>

<span data-ttu-id="ed811-256">選択モードには簡易非表示モデルがありません。選択モードがアクティブなフレームの外側をタップしても、モードを取り消すことはできません。</span><span class="sxs-lookup"><span data-stu-id="ed811-256">Selection mode doesn't have a light dismiss model; tapping outside of the frame in which selection mode is active won't cancel the mode.</span></span> <span data-ttu-id="ed811-257">これにより、モードが誤って非アクティブ化されることを防止できます。</span><span class="sxs-lookup"><span data-stu-id="ed811-257">This is to prevent accidental deactivation of the mode.</span></span> <span data-ttu-id="ed811-258">戻るボタンをクリックすると、複数選択モードが終了します。</span><span class="sxs-lookup"><span data-stu-id="ed811-258">Clicking the back button dismisses the multi-select mode.</span></span>

<span data-ttu-id="ed811-259">操作が選択されているときは、確認できるように視覚的に示します。</span><span class="sxs-lookup"><span data-stu-id="ed811-259">Show a visual confirmation when an action is selected.</span></span> <span data-ttu-id="ed811-260">特定の操作に対して (特に破棄を伴う削除などの操作に対して)、確認ダイアログを表示することを検討します。</span><span class="sxs-lookup"><span data-stu-id="ed811-260">Consider displaying a confirmation dialog for certain actions, especially destructive actions such as delete.</span></span>

<span data-ttu-id="ed811-261">選択モードは、選択モードをアクティブにしたページに限定され、そのページ以外の項目に影響を与えることはできません。</span><span class="sxs-lookup"><span data-stu-id="ed811-261">Selection mode is confined to the page in which it is active, and can't affect any items outside of that page.</span></span>

<span data-ttu-id="ed811-262">選択モードへのエントリ ポイントは、そのモードが影響を与えるコンテンツに対して並置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ed811-262">The entry point to selection mode should be juxtaposed against the content it affects.</span></span>

<span data-ttu-id="ed811-263">コマンド バーの推奨事項については、「[コマンド バーのガイドライン](app-bars.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ed811-263">For command bar recommendations, see [guidelines for command bars](app-bars.md).</span></span>

## <a name="globalization-and-localization-checklist"></a><span data-ttu-id="ed811-264">グローバリゼーションとローカライズのチェックリスト</span><span class="sxs-lookup"><span data-stu-id="ed811-264">Globalization and localization checklist</span></span>

<table>
<tr>
<th><span data-ttu-id="ed811-265">折り返し</span><span class="sxs-lookup"><span data-stu-id="ed811-265">Wrapping</span></span></th><td><span data-ttu-id="ed811-266">一覧のラベルを 2 行にできます。</span><span class="sxs-lookup"><span data-stu-id="ed811-266">Allow two lines for the list label.</span></span></td>
</tr>
<tr>
<th><span data-ttu-id="ed811-267">水平方向の拡張</span><span class="sxs-lookup"><span data-stu-id="ed811-267">Horizontal expansion</span></span></th><td><span data-ttu-id="ed811-268">フィールドがテキストの伸張とスクロールに対応できるようにします。</span><span class="sxs-lookup"><span data-stu-id="ed811-268">Make sure fields can accomdation text expension and are scrollable.</span></span></td>
</tr>
<tr>
<th><span data-ttu-id="ed811-269">垂直方向の間隔</span><span class="sxs-lookup"><span data-stu-id="ed811-269">Vertical spacing</span></span></th><td><span data-ttu-id="ed811-270">垂直方向の間隔に非ラテン文字を使用し、非ラテン文字が適切に表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="ed811-270">Use non-Latin chracters for vertical spacing to ensure non-Latin scripts will display properly.</span></span></td>
</tr>
</table>


## <a name="related-articles"></a><span data-ttu-id="ed811-271">関連記事</span><span class="sxs-lookup"><span data-stu-id="ed811-271">Related articles</span></span>

- [<span data-ttu-id="ed811-272">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="ed811-272">Master/details</span></span>](master-details.md)
- [<span data-ttu-id="ed811-273">ナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="ed811-273">Nav pane</span></span>](navigationview.md)
- [<span data-ttu-id="ed811-274">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="ed811-274">Semantic zoom</span></span>](semantic-zoom.md)
- [<span data-ttu-id="ed811-275">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="ed811-275">Drag and drop</span></span>](https://msdn.microsoft.com/windows/uwp/app-to-app/drag-and-drop)
- [<span data-ttu-id="ed811-276">縮小表示イメージ</span><span class="sxs-lookup"><span data-stu-id="ed811-276">Thumbnail images</span></span>](../../files/thumbnails.md)

<span data-ttu-id="ed811-277">**開発者向け**</span><span class="sxs-lookup"><span data-stu-id="ed811-277">**For developers**</span></span>
- [<span data-ttu-id="ed811-278">ListView クラス</span><span class="sxs-lookup"><span data-stu-id="ed811-278">ListView class</span></span>](https://msdn.microsoft.com/library/windows/apps/br242878)
- [<span data-ttu-id="ed811-279">GridView クラス</span><span class="sxs-lookup"><span data-stu-id="ed811-279">GridView class</span></span>](https://msdn.microsoft.com/library/windows/apps/br242705)
- [<span data-ttu-id="ed811-280">コンボ ボックス クラス</span><span class="sxs-lookup"><span data-stu-id="ed811-280">ComboBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209348)
- [<span data-ttu-id="ed811-281">ListBox クラス</span><span class="sxs-lookup"><span data-stu-id="ed811-281">ListBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br242868)