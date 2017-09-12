---
author: Jwmsft
Description: "リストでは、コレクション ベースのコンテンツを表示して対話式で操作できます。"
title: "リスト"
ms.assetid: C73125E8-3768-46A5-B078-FDDF42AB1077
label: Lists
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: predavid
design-contact: kimsea
dev-contact: ranjeshj
doc-status: Published
ms.openlocfilehash: 0249132942cbb15a009c85c929185bffcba23cd9
ms.sourcegitcommit: 690320e6cbfc16ed9e935a136fecc44d68e95719
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/31/2017
---
# <a name="lists"></a><span data-ttu-id="29a03-104">リスト</span><span class="sxs-lookup"><span data-stu-id="29a03-104">Lists</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">


<span data-ttu-id="29a03-105">リストでは、コレクション ベースのコンテンツを表示して対話式で操作できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-105">Lists display and enable interactions with collection-based content.</span></span> <span data-ttu-id="29a03-106">この記事では、次に示す 4 種類のリスト パターンについて説明します。</span><span class="sxs-lookup"><span data-stu-id="29a03-106">The four list patterns covered in this article include:</span></span>

-   <span data-ttu-id="29a03-107">リスト ビュー: 主に、テキストの多いコンテンツのコレクションを表示するために使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-107">List views, which are primarily used to display text-heavy content collections</span></span>
-   <span data-ttu-id="29a03-108">グリッド ビュー: 主に、画像の多いコンテンツのコレクションを表示するために使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-108">Grid views, which are primarily used to display image-heavy content collections</span></span>
-   <span data-ttu-id="29a03-109">ドロップダウン リスト: 拡張可能なリストから、ユーザーが 1 つの項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-109">Drop-down lists, which let users choose one item from an expanding list</span></span>
-   <span data-ttu-id="29a03-110">リスト ボックス: スクロール可能なボックスから、ユーザーが 1 つまたは複数の項目を選択できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-110">List boxes, which let users choose one item or multiple items from a box that can be scrolled</span></span>

<span data-ttu-id="29a03-111">ここでは、各リスト パターンについて、設計のガイドライン、特徴、例を示します。</span><span class="sxs-lookup"><span data-stu-id="29a03-111">Design guidelines, features, and examples are given for each list pattern.</span></span>

> <span data-ttu-id="29a03-112">**重要な API**: [ListView クラス](https://msdn.microsoft.com/library/windows/apps/br242878)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/br242705)、[ComboBox クラス](https://msdn.microsoft.com/library/windows/apps/br209348)</span><span class="sxs-lookup"><span data-stu-id="29a03-112">**Important APIs**: [ListView class](https://msdn.microsoft.com/library/windows/apps/br242878), [GridView class](https://msdn.microsoft.com/library/windows/apps/br242705), [ComboBox class](https://msdn.microsoft.com/library/windows/apps/br209348)</span></span>

> <div id="main">
> <strong><span class="uwpd-prelease"><span data-ttu-id="29a03-113">プレリリース。</span><span class="sxs-lookup"><span data-stu-id="29a03-113">Prerelease.</span></span></span> <span data-ttu-id="29a03-114">Fall Creators Update (Windows 10 Insider Preview ビルド 16215 以降) - 動作の変更</span><span class="sxs-lookup"><span data-stu-id="29a03-114">Fall Creators Update (Windows 10 Insider Preview Build 16215 and later) - Behavior change</span></span></strong>
> </div>
> <span data-ttu-id="29a03-115">既定では、UWP アプリでは、アクティブ ペンは、選択の実行ではなく、リストのスクロール/パン (タッチ、タッチパッド、パッシブ ペンなどと同様に) をするようになりました。</span><span class="sxs-lookup"><span data-stu-id="29a03-115">By default, instead of performing selection, an active pen now scrolls/pans a list in UWP apps (like touch, touchpad, and passive pen).</span></span>
> <span data-ttu-id="29a03-116">アプリが以前の動作に依存している場合は、ペン スクロールを上書きして、以前の動作に戻すことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-116">If your app depends on the previous behavior, you can override pen scrolling and revert to the previous behavior.</span></span> <span data-ttu-id="29a03-117">詳しくは、[ScrollViewer クラス] (https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer) の API リファレンスのトピックをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="29a03-117">See the [ScrollViewer Class] (https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.scrollviewer) API reference topic for details.</span></span>

## <a name="list-views"></a><span data-ttu-id="29a03-118">リスト ビュー</span><span class="sxs-lookup"><span data-stu-id="29a03-118">List views</span></span>

<span data-ttu-id="29a03-119">リスト ビューでは、項目の分類、グループ ヘッダーの割り当て、項目のドラッグ アンド ドロップ、コンテンツの管理、項目の順序変更を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-119">List views let you categorize items and assign group headers, drag and drop items, curate content, and reorder items.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="29a03-120">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="29a03-120">Is this the right control?</span></span>

<span data-ttu-id="29a03-121">リスト ビューは、次の用途で使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-121">Use a list view to:</span></span>

-   <span data-ttu-id="29a03-122">主にテキストで構成されるコンテンツのコレクションを表示する。</span><span class="sxs-lookup"><span data-stu-id="29a03-122">Display a content collection that primarily consists of text.</span></span>
-   <span data-ttu-id="29a03-123">コンテンツの単一のコレクションまたはカテゴリ別コレクションをナビゲートする。</span><span class="sxs-lookup"><span data-stu-id="29a03-123">Navigate a single or categorized collection of content.</span></span>
-   <span data-ttu-id="29a03-124">[マスター/詳細パターン](master-details.md)のマスター ウィンドウを作成する。</span><span class="sxs-lookup"><span data-stu-id="29a03-124">Create the master pane in the [master/details pattern](master-details.md).</span></span> <span data-ttu-id="29a03-125">マスター/詳細パターンは、メール アプリによく使われます。このパターンでは、選択できる項目の一覧を一方のウィンドウ (マスター) に表示し、選択された項目の詳細ビューをもう一方のウィンドウ (詳細) に表示します。</span><span class="sxs-lookup"><span data-stu-id="29a03-125">A master/details pattern is often used in email apps, in which one pane (the master) has a list of selectable items while the other pane (details) has a detailed view of the selected item.</span></span>

### <a name="examples"></a><span data-ttu-id="29a03-126">例</span><span class="sxs-lookup"><span data-stu-id="29a03-126">Examples</span></span>

<span data-ttu-id="29a03-127">これは、電話での単純なリスト ビューの例で、グループ化されたデータを表示しています。</span><span class="sxs-lookup"><span data-stu-id="29a03-127">Here's a simple list view showing grouped data on a phone.</span></span>

![グループ化されたデータを表示するリスト ビュー](images/simple-list-view-phone.png)

### <a name="recommendations"></a><span data-ttu-id="29a03-129">推奨事項</span><span class="sxs-lookup"><span data-stu-id="29a03-129">Recommendations</span></span>

-   <span data-ttu-id="29a03-130">同じリストに含まれる各項目の動作は同じにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-130">Items within a list should have the same behavior.</span></span>
-   <span data-ttu-id="29a03-131">リストがグループに分割されている場合、グループ化されたコンテンツ内をユーザーが移動しやすくなるように、[セマンティック ズーム](semantic-zoom.md)を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-131">If your list is divided into groups, you can use [semantic zoom](semantic-zoom.md) to make it easier for users to navigate through grouped content.</span></span>

### <a name="list-view-articles"></a><span data-ttu-id="29a03-132">リスト ビューに関する記事</span><span class="sxs-lookup"><span data-stu-id="29a03-132">List view articles</span></span>
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="29a03-133">トピック</span><span class="sxs-lookup"><span data-stu-id="29a03-133">Topic</span></span></th>
<th align="left"><span data-ttu-id="29a03-134">説明</span><span class="sxs-lookup"><span data-stu-id="29a03-134">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[<span data-ttu-id="29a03-135">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="29a03-135">List view and grid view</span></span>](listview-and-gridview.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-136">アプリでリスト ビューやグリッド ビューを使用するための基本情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="29a03-136">Learn the essentials of using a list view or grid view in your app.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>[<span data-ttu-id="29a03-137">リスト ビュー項目テンプレート</span><span class="sxs-lookup"><span data-stu-id="29a03-137">List view item templates</span></span>](listview-item-templates.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-138">リストやグリッドに表示される項目は、アプリの全体的な見た目を左右する要素になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-138">The items you display in a list or grid can play a major role in the overall look of your app.</span></span> <span data-ttu-id="29a03-139">コントロール テンプレートとデータ テンプレートを変更して、項目の外観を定義し、アプリの見栄えをよくします。</span><span class="sxs-lookup"><span data-stu-id="29a03-139">Modify control templates and data templates to define the look of the items and make your app look great.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<span data-ttu-id="29a03-140">反転リスト</span><span class="sxs-lookup"><span data-stu-id="29a03-140">Inverted lists</span></span>](inverted-lists.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-141">反転リストでは、チャット アプリのように、新しい項目が下部に追加されます。</span><span class="sxs-lookup"><span data-stu-id="29a03-141">Inverted lists have new items added at the bottom, like in a chat app.</span></span> <span data-ttu-id="29a03-142">アプリで反転リストを使用する場合は、こちらのガイダンスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="29a03-142">Follow this guidance to use an inverted list in your app.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>[<span data-ttu-id="29a03-143">引っ張って更新</span><span class="sxs-lookup"><span data-stu-id="29a03-143">Pull-to-refresh</span></span>](pull-to-refresh.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-144">引っ張って更新パターンを使うと、より多くのデータを取得するためにタッチ操作でデータのリストを引き下げることができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-144">The pull-to-refresh pattern lets a user pull down on a list of data using touch in order to retrieve more data.</span></span> <span data-ttu-id="29a03-145">リスト ビューに引っ張って更新を実装する場合は、こちらのガイダンスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="29a03-145">Use this guidance to implement pull-to-refresh in your list view.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<span data-ttu-id="29a03-146">入れ子になった UI</span><span class="sxs-lookup"><span data-stu-id="29a03-146">Nested UI</span></span>](nested-ui.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-147">入れ子になった UI は、ユーザーも操作が可能なコンテナー内部に囲まれた、操作できるコントロールを公開するユーザー インターフェイス (UI) です。</span><span class="sxs-lookup"><span data-stu-id="29a03-147">Nested UI is a user interface (UI) that exposes actionable controls enclosed inside a container that a user can also take action on.</span></span> <span data-ttu-id="29a03-148">たとえば、ボタンを含むリスト ビュー項目があるとします。ユーザーはそのリスト項目を選択することも、項目内に入れ子になっているボタンを押すこともできます。</span><span class="sxs-lookup"><span data-stu-id="29a03-148">For example, you might have list view item that contains a button, and the user can select the list item, or press the button nested within it.</span></span> <span data-ttu-id="29a03-149">以下のベスト プラクティスに従って、ユーザーにとって最適な入れ子になった UI のエクスペリエンスを提供してください。</span><span class="sxs-lookup"><span data-stu-id="29a03-149">Follow these best practices to provide the best nested UI experience for your users.</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="grid-views"></a><span data-ttu-id="29a03-150">グリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="29a03-150">Grid views</span></span>

<span data-ttu-id="29a03-151">グリッド ビューは、画像ベースのコンテンツのコレクションを配置および閲覧する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="29a03-151">Grid views are suited for arranging and browsing image-based content collections.</span></span> <span data-ttu-id="29a03-152">グリッド ビュー レイアウトでは、スクロールが垂直方向、パンが水平方向で行われます。</span><span class="sxs-lookup"><span data-stu-id="29a03-152">A grid view layout scrolls vertically and pans horizontally.</span></span> <span data-ttu-id="29a03-153">項目は、左から右、上から下の読み取り順序で配置されます。</span><span class="sxs-lookup"><span data-stu-id="29a03-153">Items are laid out in a left-to-right, then top-to-bottom reading order.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="29a03-154">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="29a03-154">Is this the right control?</span></span>

<span data-ttu-id="29a03-155">グリッド ビューは、次の用途で使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-155">Use a list view to:</span></span>

-   <span data-ttu-id="29a03-156">主に画像で構成されるコンテンツのコレクションを表示する。</span><span class="sxs-lookup"><span data-stu-id="29a03-156">Display a content collection that primarily consists of images.</span></span>
-   <span data-ttu-id="29a03-157">コンテンツ ライブラリを表示する。</span><span class="sxs-lookup"><span data-stu-id="29a03-157">Display content libraries.</span></span>
-   <span data-ttu-id="29a03-158">[セマンティック ズーム](semantic-zoom.md)に関連付けられた 2 つのコンテンツ ビューの形式を設定する。</span><span class="sxs-lookup"><span data-stu-id="29a03-158">Format the two content views associated with [semantic zoom](semantic-zoom.md).</span></span>

### <a name="examples"></a><span data-ttu-id="29a03-159">例</span><span class="sxs-lookup"><span data-stu-id="29a03-159">Examples</span></span>

<span data-ttu-id="29a03-160">ここでは、アプリの参照用を例として、標準的なグリッド ビューのレイアウトを示します。</span><span class="sxs-lookup"><span data-stu-id="29a03-160">This example shows a typical grid view layout, in this case for browsing apps.</span></span> <span data-ttu-id="29a03-161">グリッド ビュー項目のメタデータは通常、数行のテキストと項目の評価に制限されます。</span><span class="sxs-lookup"><span data-stu-id="29a03-161">Metadata for grid view items is usually restricted to a few lines of text and an item rating.</span></span>

![グリッド ビューのレイアウトの例](images/controls_gridview_example02.png)

<span data-ttu-id="29a03-163">グリッド ビューは、写真やビデオなどのメディアを表示するためによく使用される、コンテンツ ライブラリに最適なソリューションです。</span><span class="sxs-lookup"><span data-stu-id="29a03-163">A grid view is an ideal solution for a content library, which is often used to present media such as pictures and videos.</span></span> <span data-ttu-id="29a03-164">コンテンツ ライブラリでは、ユーザーが項目をタップして動作を開始します。</span><span class="sxs-lookup"><span data-stu-id="29a03-164">In a content library, users expect to be able to tap an item to invoke an action.</span></span>

![コンテンツ ライブラリの例](images/controls_list_contentlibrary.png)

### <a name="recommendations"></a><span data-ttu-id="29a03-166">推奨事項</span><span class="sxs-lookup"><span data-stu-id="29a03-166">Recommendations</span></span>

-   <span data-ttu-id="29a03-167">同じリストに含まれる各項目の動作は同じにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-167">Items within a list should have the same behavior.</span></span>
-   <span data-ttu-id="29a03-168">リストがグループに分割されている場合、グループ化されたコンテンツ内をユーザーが移動しやすくなるように、[セマンティック ズーム](semantic-zoom.md)を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-168">If your list is divided into groups, you can use [semantic zoom](semantic-zoom.md) to make it easier for users to navigate through grouped content.</span></span>

### <a name="grid-view-articles"></a><span data-ttu-id="29a03-169">グリッド ビューの記事</span><span class="sxs-lookup"><span data-stu-id="29a03-169">Grid view articles</span></span>
<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="29a03-170">トピック</span><span class="sxs-lookup"><span data-stu-id="29a03-170">Topic</span></span></th>
<th align="left"><span data-ttu-id="29a03-171">説明</span><span class="sxs-lookup"><span data-stu-id="29a03-171">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p>[<span data-ttu-id="29a03-172">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="29a03-172">List view and grid view</span></span>](listview-and-gridview.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-173">アプリでリスト ビューやグリッド ビューを使用するための基本情報を提供します。</span><span class="sxs-lookup"><span data-stu-id="29a03-173">Learn the essentials of using a list view or grid view in your app.</span></span></p></td>
</tr>
<tr class="even">
<td align="left"><p>[<span data-ttu-id="29a03-174">リスト ビュー項目テンプレート</span><span class="sxs-lookup"><span data-stu-id="29a03-174">List view item templates</span></span>](listview-item-templates.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-175">リストやグリッドに表示される項目は、アプリの全体的な見た目を左右する要素になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-175">The items you display in a list or grid can play a major role in the overall look of your app.</span></span> <span data-ttu-id="29a03-176">コントロール テンプレートとデータ テンプレートを変更して、項目の外観を定義し、アプリの見栄えをよくします。</span><span class="sxs-lookup"><span data-stu-id="29a03-176">Modify control templates and data templates to define the look of the items and make your app look great.</span></span></p></td>
</tr>
<tr class="odd">
<td align="left"><p>[<span data-ttu-id="29a03-177">入れ子になった UI</span><span class="sxs-lookup"><span data-stu-id="29a03-177">Nested UI</span></span>](nested-ui.md)</p></td>
<td align="left"><p><span data-ttu-id="29a03-178">入れ子になった UI は、ユーザーも操作が可能なコンテナー内部に囲まれた、操作できるコントロールを公開するユーザー インターフェイス (UI) です。</span><span class="sxs-lookup"><span data-stu-id="29a03-178">Nested UI is a user interface (UI) that exposes actionable controls enclosed inside a container that a user can also take action on.</span></span> <span data-ttu-id="29a03-179">たとえば、ボタンを含むリスト ビュー項目があるとします。ユーザーはそのリスト項目を選択することも、項目内に入れ子になっているボタンを押すこともできます。</span><span class="sxs-lookup"><span data-stu-id="29a03-179">For example, you might have list view item that contains a button, and the user can select the list item, or press the button nested within it.</span></span> <span data-ttu-id="29a03-180">以下のベスト プラクティスに従って、ユーザーにとって最適な入れ子になった UI のエクスペリエンスを提供してください。</span><span class="sxs-lookup"><span data-stu-id="29a03-180">Follow these best practices to provide the best nested UI experience for your users.</span></span></p></td>
</tr>
</tbody>
</table>

## <a name="drop-down-lists"></a><span data-ttu-id="29a03-181">ドロップダウン リスト</span><span class="sxs-lookup"><span data-stu-id="29a03-181">Drop-down lists</span></span>

<span data-ttu-id="29a03-182">ドロップダウン リストはコンボ ボックスとも呼ばれます。最初はコンパクトな状態ですが、拡張して、選択可能な項目の一覧を表示することができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-182">Drop-down lists, also known as combo boxes, start in a compact state and expand to show a list of selectable items.</span></span> <span data-ttu-id="29a03-183">選ばれた項目は常に表示されます。表示されていない項目は、コンボ ボックスをタップして拡張すると表示されます。</span><span class="sxs-lookup"><span data-stu-id="29a03-183">The selected item is always visible, and non-visible items can be brought into view when the user taps the combo box to expand it.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="29a03-184">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="29a03-184">Is this the right control?</span></span>

-   <span data-ttu-id="29a03-185">1 行のテキストで十分に表すことができる項目のセットから、ユーザーが単一の値を選ぶことができるようにするには、ドロップダウン リストを使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-185">Use a drop-down list to let users select a single value from a set of items that can be adequately represented with single lines of text.</span></span>
-   <span data-ttu-id="29a03-186">複数のテキスト行や画像が含まれる項目を表示するには、コンボ ボックスではなくリスト ビューまたはグリッド ビューを使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-186">Use a list or grid view instead of a combo box to display items that contain multiple lines of text or images.</span></span>
-   <span data-ttu-id="29a03-187">項目が 5 個より少ない場合は、[ラジオ ボタン](radio-button.md) (1 つの項目だけを選ぶことができる場合)、または[チェック ボックス](checkbox.md) (複数の項目を選ぶことができる場合) の使用を検討します。</span><span class="sxs-lookup"><span data-stu-id="29a03-187">When there are fewer than five items, consider using [radio buttons](radio-button.md) (if only one item can be selected) or [check boxes](checkbox.md) (if multiple items can be selected).</span></span>
-   <span data-ttu-id="29a03-188">選択項目がアプリのフローにおいて二次的な重要性しか持たない場合は、コンボ ボックスを使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-188">Use a combo box when the selection items are of secondary importance in the flow of your app.</span></span> <span data-ttu-id="29a03-189">多くの状況でほとんどのユーザーに対して既定のオプションが推奨されている場合、リスト ビューを使ってすべての項目を表示すると、既定以外のオプションに必要以上の注意を引いてしまう可能性があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-189">If the default option is recommended for most users in most situations, showing all the items by using a list view might draw more attention to the options than necessary.</span></span> <span data-ttu-id="29a03-190">コンボ ボックスを使うことで、領域を節約し、無駄な情報を最小限にすることができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-190">You can save space and minimize distraction by using a combo box.</span></span>

### <a name="examples"></a><span data-ttu-id="29a03-191">例</span><span class="sxs-lookup"><span data-stu-id="29a03-191">Examples</span></span>

<span data-ttu-id="29a03-192">コンパクトな状態のコンボ ボックスには、ヘッダーを表示できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-192">A combo box in its compact state can show a header.</span></span>

![コンパクトな状態のドロップダウン リストの例](images/combo_box_collapsed.png)

<span data-ttu-id="29a03-194">コンボ ボックスは、長い文字列の幅をサポートするために拡張できますが、読みづらくなるような長すぎる文字列は使わないでください。</span><span class="sxs-lookup"><span data-stu-id="29a03-194">Although combo boxes expand to support longer string lengths, avoid excessively long strings that are difficult to read.</span></span>

![長い文字列のドロップダウン リストの例](images/combo_box_listitemstate.png)

<span data-ttu-id="29a03-196">コンボ ボックス内のコレクションが一定の長さに達すると、対応できるようにスクロール バーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="29a03-196">If the collection in a combo box is long enough, a scroll bar will appear to accommodate it.</span></span> <span data-ttu-id="29a03-197">リスト内の項目は論理的にグループ化します。</span><span class="sxs-lookup"><span data-stu-id="29a03-197">Group items logically in the list.</span></span>

![ドロップダウン リストに表示されたスクロール バーの例](images/combo_box_scroll.png)

### <a name="recommendations"></a><span data-ttu-id="29a03-199">推奨事項</span><span class="sxs-lookup"><span data-stu-id="29a03-199">Recommendations</span></span>

-   <span data-ttu-id="29a03-200">コンボ ボックス項目のテキストのコンテンツは、単一行に制限します。</span><span class="sxs-lookup"><span data-stu-id="29a03-200">Limit the text content of combo box items to a single line.</span></span>
-   <span data-ttu-id="29a03-201">コンボ ボックス内の項目は、最も論理的な順序に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="29a03-201">Sort items in a combo box in the most logical order.</span></span> <span data-ttu-id="29a03-202">関連するオプションをグループ化し、最も一般的なオプションを先頭に配置します。</span><span class="sxs-lookup"><span data-stu-id="29a03-202">Group together related options and place the most common options at the top.</span></span> <span data-ttu-id="29a03-203">名前はアルファベット順、数値は数値順、日付は時系列順に並べ替えます。</span><span class="sxs-lookup"><span data-stu-id="29a03-203">Sort names in alphabetical order, numbers in numerical order, and dates in chronological order.</span></span>
-   <span data-ttu-id="29a03-204">ユーザーが方向キーを押している間にライブ更新するコンボ ボックスを作成するには (フォント選択ドロップダウン リストなど)、SelectionChangedTrigger を Always に設定します。</span><span class="sxs-lookup"><span data-stu-id="29a03-204">To make a combo box that live updates while the user is using the arrow keys (like a Font selection drop-down), set SelectionChangedTrigger to “Always”.</span></span>  

### <a name="text-search"></a><span data-ttu-id="29a03-205">テキスト検索</span><span class="sxs-lookup"><span data-stu-id="29a03-205">Text Search</span></span>

<span data-ttu-id="29a03-206">コンボ ボックスでは、コレクション内を自動的に検索できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-206">Combo boxes automatically support search within their collections.</span></span> <span data-ttu-id="29a03-207">開かれた状態または閉じた状態のコンボ ボックスにフォーカスがあるときに、物理的なキーボードで文字を入力すると、ユーザーが入力した文字列に一致する候補がビューに表示されます。</span><span class="sxs-lookup"><span data-stu-id="29a03-207">As users type characters on a physical keyboard while focused on an open or closed combo box, candidates matching the user's string are brought into view.</span></span> <span data-ttu-id="29a03-208">この機能は、長いリストを操作するときに特に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="29a03-208">This functionality is especially helpful when navigating a long list.</span></span> <span data-ttu-id="29a03-209">たとえば、州のリストが含まれているドロップダウンを操作するとき、“w” キーを押すと、“Washington” (ワシントン) がビューに表示され、すばやく選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-209">For example, when interacting with a drop-down containing a list of states, users can press the “w” key to bring “Washington” into view for quick selection.</span></span>


## <a name="list-boxes"></a><span data-ttu-id="29a03-210">リスト ボックス</span><span class="sxs-lookup"><span data-stu-id="29a03-210">List boxes</span></span>

<span data-ttu-id="29a03-211">リスト ボックスを使うと、ユーザーはコレクションから 1 つまたは複数の項目を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-211">A list box allows the user to choose either a single item or multiple items from a collection.</span></span> <span data-ttu-id="29a03-212">リスト ボックスはドロップダウン リストと似ていますが、常に開いている点がドロップダウン リストと異なります。リスト ボックスには、コンパクトな (展開されていない) 状態がありません。</span><span class="sxs-lookup"><span data-stu-id="29a03-212">List boxes are similar to drop-down lists, except that list boxes are always open—there is no compact (non-expanded) state for a list box.</span></span> <span data-ttu-id="29a03-213">すべての項目を表示する領域がない場合には、リスト内の項目をスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="29a03-213">Items in the list can be scrolled if there isn't space to show everything.</span></span>

### <a name="is-this-the-right-control"></a><span data-ttu-id="29a03-214">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="29a03-214">Is this the right control?</span></span>

-   <span data-ttu-id="29a03-215">リスト ボックスは、リスト内の項目が重要であるため目立つように表示する場合や、項目一式を表示するための十分な画面領域がある場合に便利です。</span><span class="sxs-lookup"><span data-stu-id="29a03-215">A list box can be useful when items in the list are important enough to prominently display, and when there's enough screen real estate, to show the full list.</span></span>
-   <span data-ttu-id="29a03-216">リスト ボックスでは、重要な選択で完全な代替セットにユーザーの注意を向ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-216">A list box should draw the user's attention to the full set of alternatives in an important choice.</span></span> <span data-ttu-id="29a03-217">ドロップダウン リストの場合はまず、選択した項目にユーザーの注意を引き付けます。</span><span class="sxs-lookup"><span data-stu-id="29a03-217">By contrast, a drop-down list initially draws the user's attention to the selected item.</span></span>
-   <span data-ttu-id="29a03-218">次のような場合はリスト ボックスの使用を避けてください。</span><span class="sxs-lookup"><span data-stu-id="29a03-218">Avoid using a list box if:</span></span>
    -   <span data-ttu-id="29a03-219">リスト内の項目が非常に少ない場合。</span><span class="sxs-lookup"><span data-stu-id="29a03-219">There is a very small number of items for the list.</span></span> <span data-ttu-id="29a03-220">単一選択のリスト ボックスで常に同じ 2 つのオプションを提示するのであれば、[オプション ボタン](radio-button.md)の方が適している可能性があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-220">A single-select list box that always has the same 2 options might be better presented as [radio buttons](radio-button.md).</span></span> <span data-ttu-id="29a03-221">3 ～ 4 個の静的な項目を提示する場合もオプション ボタンの使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="29a03-221">Also consider using radio buttons when there are 3 or 4 static items in the list.</span></span>
    -   <span data-ttu-id="29a03-222">リスト ボックスが単一選択であり、リスト内のオプションが常に同じ 2 項目で、その一方が他方の否定を意味している場合 ("オン" と "オフ" など)。</span><span class="sxs-lookup"><span data-stu-id="29a03-222">The list box is single-select and it always has the same 2 options where one can be implied as not the other, such as "on" and "off."</span></span> <span data-ttu-id="29a03-223">このような場合は、単一のチェック ボックスまたはトグル スイッチを使用してください。</span><span class="sxs-lookup"><span data-stu-id="29a03-223">Use a single check box or a toggle switch.</span></span>
    -   <span data-ttu-id="29a03-224">項目数が非常に多い場合。</span><span class="sxs-lookup"><span data-stu-id="29a03-224">There is a very large number of items.</span></span> <span data-ttu-id="29a03-225">長いリストには、グリッド ビューまたはリスト ビューの方が適しています。</span><span class="sxs-lookup"><span data-stu-id="29a03-225">A better choice for long lists are grid view and list view.</span></span> <span data-ttu-id="29a03-226">グループ化されたデータの非常に長いリストの場合はセマンティック ズームの使用をお勧めします。</span><span class="sxs-lookup"><span data-stu-id="29a03-226">For very long lists of grouped data, semantic zoom is preferred.</span></span>
    -   <span data-ttu-id="29a03-227">項目が連続する数値である場合。</span><span class="sxs-lookup"><span data-stu-id="29a03-227">The items are contiguous numerical values.</span></span> <span data-ttu-id="29a03-228">このような場合は、[スライダー](slider.md)の使用を検討してください。</span><span class="sxs-lookup"><span data-stu-id="29a03-228">If that's the case, consider using a [slider](slider.md).</span></span>
    -   <span data-ttu-id="29a03-229">選択項目がアプリのフローで二次的な重要性しか持たないか、または大半の状況で大半のユーザーに既定のオプションが推奨される場合。</span><span class="sxs-lookup"><span data-stu-id="29a03-229">The selection items are of secondary importance in the flow of your app or the default option is recommended for most users in most situations.</span></span> <span data-ttu-id="29a03-230">このような場合は、ドロップダウン リストを使用してください。</span><span class="sxs-lookup"><span data-stu-id="29a03-230">Use a drop-down list instead.</span></span>

### <a name="recommendations"></a><span data-ttu-id="29a03-231">推奨事項</span><span class="sxs-lookup"><span data-stu-id="29a03-231">Recommendations</span></span>

-   <span data-ttu-id="29a03-232">リスト ボックス内の項目数の最適な範囲は 3 ～ 9 です。</span><span class="sxs-lookup"><span data-stu-id="29a03-232">The ideal range of items in a list box is 3 to 9.</span></span>
-   <span data-ttu-id="29a03-233">リスト ボックスは、項目が動的に変化する可能性がある場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="29a03-233">A list box works well when its items can dynamically vary.</span></span>
-   <span data-ttu-id="29a03-234">可能であれば、項目のリストのパンまたはスクロールが必要にならないように、リスト ボックスのサイズを設定します。</span><span class="sxs-lookup"><span data-stu-id="29a03-234">If possible, set the size of a list box so that its list of items don't need to be panned or scrolled.</span></span>
-   <span data-ttu-id="29a03-235">リスト ボックスの目的、および現在選択されている項目が明確であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="29a03-235">Verify that the purpose of the list box, and which items are currently selected, is clear.</span></span>
-   <span data-ttu-id="29a03-236">タッチ フィードバックおよび項目の選択状態の視覚効果とアニメーションを予約します。</span><span class="sxs-lookup"><span data-stu-id="29a03-236">Reserve visual effects and animations for touch feedback, and for the selected state of items.</span></span>
-   <span data-ttu-id="29a03-237">リスト ボックス項目のテキストのコンテンツは、単一行に制限します。</span><span class="sxs-lookup"><span data-stu-id="29a03-237">Limit the list box item's text content to a single line.</span></span> <span data-ttu-id="29a03-238">項目がビジュアルである場合、サイズをカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="29a03-238">If the items are visuals, you can customize the size.</span></span> <span data-ttu-id="29a03-239">項目に複数行のテキストまたは画像が含まれる場合は、グリッド ビューまたはリスト ビューを使用してください。</span><span class="sxs-lookup"><span data-stu-id="29a03-239">If an item contains multiple lines of text or images, instead use a grid view or list view.</span></span>
-   <span data-ttu-id="29a03-240">ブランドのガイドラインで別のフォントが指示されていない限り、既定のフォントを使います。</span><span class="sxs-lookup"><span data-stu-id="29a03-240">Use the default font unless your brand guidelines indicate to use another.</span></span>
-   <span data-ttu-id="29a03-241">コマンドの実行または他のコントロールの動的な表示と非表示の切り替えのためにリスト ボックスを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="29a03-241">Don't use a list box to perform commands or to dynamically show or hide other controls.</span></span>

## <a name="selection-mode"></a><span data-ttu-id="29a03-242">選択モード</span><span class="sxs-lookup"><span data-stu-id="29a03-242">Selection mode</span></span>

<span data-ttu-id="29a03-243">選択モードでは、単一の項目または複数の項目を選択して、それらの項目に対して操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-243">Selection mode lets users select and take action on a single item or on multiple items.</span></span> <span data-ttu-id="29a03-244">選択モードは、コンテキスト メニュー、Crtl キーまたは Shift キーを押しながらの項目のクリック、またはギャラリー ビューでの項目に対するターゲットのロールオーバーによって起動できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-244">It can be invoked through a context menu, by using CTRL+click or SHIFT+click on an item, or by rolling-over a target on an item in a gallery view.</span></span> <span data-ttu-id="29a03-245">選択モードがアクティブであるとき、各リスト項目の横にチェック ボックスを表示し、画面の上部または下部に操作を表示できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-245">When selection mode is active, check boxes appear next to each list item, and actions can appear at the top or the bottom of the screen.</span></span>

<span data-ttu-id="29a03-246">選択モードには、次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="29a03-246">There are three selection modes:</span></span>

-   <span data-ttu-id="29a03-247">単一: ユーザーは同時に 1 つの項目だけを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-247">Single: The user can select only one item at a time.</span></span>
-   <span data-ttu-id="29a03-248">複数: ユーザーは修飾キーを使わずに複数の項目を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-248">Multiple: The user can select multiple items without using a modifier.</span></span>
-   <span data-ttu-id="29a03-249">拡張: ユーザーは、Shift キーを押すなど修飾キーを使って複数の項目を選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="29a03-249">Extended: The user can select multiple items with a modifier, such as holding down the SHIFT key.</span></span>

<span data-ttu-id="29a03-250">項目の任意の場所をタップすると、項目が選ばれます。</span><span class="sxs-lookup"><span data-stu-id="29a03-250">Tapping anywhere on an item selects it.</span></span> <span data-ttu-id="29a03-251">コマンド バーの操作をタップすると、選択したすべての項目に影響します。</span><span class="sxs-lookup"><span data-stu-id="29a03-251">Tapping on the command bar action affects all selected items.</span></span> <span data-ttu-id="29a03-252">項目が選ばれていない場合、コマンド バーの操作は [すべて選択] を除いて非アクティブになります。</span><span class="sxs-lookup"><span data-stu-id="29a03-252">If no item is selected, command bar actions should be inactive, except for "Select All".</span></span>

<span data-ttu-id="29a03-253">選択モードには簡易非表示モデルがありません。選択モードがアクティブなフレームの外側をタップしても、モードを取り消すことはできません。</span><span class="sxs-lookup"><span data-stu-id="29a03-253">Selection mode doesn't have a light dismiss model; tapping outside of the frame in which selection mode is active won't cancel the mode.</span></span> <span data-ttu-id="29a03-254">これにより、モードが誤って非アクティブ化されることを防止できます。</span><span class="sxs-lookup"><span data-stu-id="29a03-254">This is to prevent accidental deactivation of the mode.</span></span> <span data-ttu-id="29a03-255">戻るボタンをクリックすると、複数選択モードが終了します。</span><span class="sxs-lookup"><span data-stu-id="29a03-255">Clicking the back button dismisses the multi-select mode.</span></span>

<span data-ttu-id="29a03-256">操作が選択されているときは、確認できるように視覚的に示します。</span><span class="sxs-lookup"><span data-stu-id="29a03-256">Show a visual confirmation when an action is selected.</span></span> <span data-ttu-id="29a03-257">特定の操作に対して (特に破棄を伴う削除などの操作に対して)、確認ダイアログを表示することを検討します。</span><span class="sxs-lookup"><span data-stu-id="29a03-257">Consider displaying a confirmation dialog for certain actions, especially destructive actions such as delete.</span></span>

<span data-ttu-id="29a03-258">選択モードは、選択モードをアクティブにしたページに限定され、そのページ以外の項目に影響を与えることはできません。</span><span class="sxs-lookup"><span data-stu-id="29a03-258">Selection mode is confined to the page in which it is active, and can't affect any items outside of that page.</span></span>

<span data-ttu-id="29a03-259">選択モードへのエントリ ポイントは、そのモードが影響を与えるコンテンツに対して並置する必要があります。</span><span class="sxs-lookup"><span data-stu-id="29a03-259">The entry point to selection mode should be juxtaposed against the content it affects.</span></span>

<span data-ttu-id="29a03-260">コマンド バーの推奨事項については、「[コマンド バーのガイドライン](app-bars.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="29a03-260">For command bar recommendations, see [guidelines for command bars](app-bars.md).</span></span>

## <a name="globalization-and-localization-checklist"></a><span data-ttu-id="29a03-261">グローバリゼーションとローカライズのチェックリスト</span><span class="sxs-lookup"><span data-stu-id="29a03-261">Globalization and localization checklist</span></span>

<table>
<tr>
<th><span data-ttu-id="29a03-262">折り返し</span><span class="sxs-lookup"><span data-stu-id="29a03-262">Wrapping</span></span></th><td><span data-ttu-id="29a03-263">一覧のラベルを 2 行にできます。</span><span class="sxs-lookup"><span data-stu-id="29a03-263">Allow two lines for the list label.</span></span></td>
</tr>
<tr>
<th><span data-ttu-id="29a03-264">水平方向の拡張</span><span class="sxs-lookup"><span data-stu-id="29a03-264">Horizontal expansion</span></span></th><td><span data-ttu-id="29a03-265">フィールドがテキストの伸張とスクロールに対応できるようにします。</span><span class="sxs-lookup"><span data-stu-id="29a03-265">Make sure fields can accomdation text expension and are scrollable.</span></span></td>
</tr>
<tr>
<th><span data-ttu-id="29a03-266">垂直方向の間隔</span><span class="sxs-lookup"><span data-stu-id="29a03-266">Vertical spacing</span></span></th><td><span data-ttu-id="29a03-267">垂直方向の間隔に非ラテン文字を使用し、非ラテン文字が適切に表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="29a03-267">Use non-Latin chracters for vertical spacing to ensure non-Latin scripts will display properly.</span></span></td>
</tr>
</table>


## <a name="related-articles"></a><span data-ttu-id="29a03-268">関連記事</span><span class="sxs-lookup"><span data-stu-id="29a03-268">Related articles</span></span>

- [<span data-ttu-id="29a03-269">ハブ</span><span class="sxs-lookup"><span data-stu-id="29a03-269">Hub</span></span>](hub.md)
- [<span data-ttu-id="29a03-270">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="29a03-270">Master/details</span></span>](master-details.md)
- [<span data-ttu-id="29a03-271">ナビゲーション ウィンドウ</span><span class="sxs-lookup"><span data-stu-id="29a03-271">Nav pane</span></span>](navigationview.md)
- [<span data-ttu-id="29a03-272">セマンティック ズーム</span><span class="sxs-lookup"><span data-stu-id="29a03-272">Semantic zoom</span></span>](semantic-zoom.md)
- [<span data-ttu-id="29a03-273">ドラッグ アンド ドロップ</span><span class="sxs-lookup"><span data-stu-id="29a03-273">Drag and drop</span></span>](https://msdn.microsoft.com/windows/uwp/app-to-app/drag-and-drop)

**<span data-ttu-id="29a03-274">開発者向け</span><span class="sxs-lookup"><span data-stu-id="29a03-274">For developers</span></span>**
- [<span data-ttu-id="29a03-275">ListView クラス</span><span class="sxs-lookup"><span data-stu-id="29a03-275">ListView class</span></span>](https://msdn.microsoft.com/library/windows/apps/br242878)
- [<span data-ttu-id="29a03-276">GridView クラス</span><span class="sxs-lookup"><span data-stu-id="29a03-276">GridView class</span></span>](https://msdn.microsoft.com/library/windows/apps/br242705)
- [<span data-ttu-id="29a03-277">ComboBox クラス</span><span class="sxs-lookup"><span data-stu-id="29a03-277">ComboBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br209348)
- [<span data-ttu-id="29a03-278">ListBox クラス</span><span class="sxs-lookup"><span data-stu-id="29a03-278">ListBox class</span></span>](https://msdn.microsoft.com/library/windows/apps/br242868)