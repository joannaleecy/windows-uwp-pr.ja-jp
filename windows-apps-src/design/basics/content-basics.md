---
Description: An overview of common page patterns and UI elements for displaying content in your UWP app.
title: ユニバーサル Windows プラットフォーム (UWP) アプリのコンテンツ デザインの基本
ms.assetid: 3102530A-E0D1-4C55-AEFF-99443D39D567
label: Content design basics
template: detail.hbs
op-migration-status: ready
ms.date: 12/1/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: b2d85d97fa704b4fb79e93cf95fdd1bfcc41f8ca
ms.sourcegitcommit: 59f874b6667c3f639d8b0c7eeca886e71bf95614
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 01/14/2019
ms.locfileid: "9004608"
---
# <a name="content-design-basics-for-uwp-apps"></a><span data-ttu-id="9332a-103">UWP アプリのコンテンツ デザインの基本</span><span class="sxs-lookup"><span data-stu-id="9332a-103">Content design basics for UWP apps</span></span>

<span data-ttu-id="9332a-104">どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。</span><span class="sxs-lookup"><span data-stu-id="9332a-104">The main purpose of any app is to provide access to content.</span></span> <span data-ttu-id="9332a-105">アプリはさまざまな目的で存在するため、コンテンツにも多くの形式があります。たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="9332a-105">Since apps exist for many different purposes, content comes in many forms: in a photo-editing app, the photo is the content; in a travel app, maps and information about travel destinations is the content; and so on.</span></span> 

<span data-ttu-id="9332a-106">この記事では、アプリでコンテンツを表示する方法の概要を説明します。</span><span class="sxs-lookup"><span data-stu-id="9332a-106">This article provides an overview of how you can present content in your app.</span></span> <span data-ttu-id="9332a-107">形式にかかわらずコンテンツを表示するために使用できる、一般的なページ パターンと UI 要素について説明します。</span><span class="sxs-lookup"><span data-stu-id="9332a-107">We describe common page patterns and UI elements that you can use to display your content, whatever form it may be in.</span></span>

## <a name="common-page-patterns"></a><span data-ttu-id="9332a-108">一般的なページ パターン</span><span class="sxs-lookup"><span data-stu-id="9332a-108">Common page patterns</span></span>

<span data-ttu-id="9332a-109">多くのアプリは、これらの一般的なページ パターンの一部またはすべてを使用して、さまざまな種類のコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="9332a-109">Many apps use some, or all, of these common page patterns to display different types of content.</span></span> <span data-ttu-id="9332a-110">また、これらのパターンを自由に組み合わせて、アプリのコンテンツを最適化します。</span><span class="sxs-lookup"><span data-stu-id="9332a-110">Likewise, feel free to mix and match these patterns to optimize for your app's content.</span></span>

### <a name="landing"></a><span data-ttu-id="9332a-111">ランディング</span><span class="sxs-lookup"><span data-stu-id="9332a-111">Landing</span></span>

![ランディング ページ](images/content-basics/hero-screen.png)

<span data-ttu-id="9332a-113">通常、ランディング ページ (ヒーロー画面とも呼ばれる) は、アプリのエクスペリエンスのトップ レベルに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9332a-113">Landing pages, also known as hero screens, often appear at the top level of an app experience.</span></span> <span data-ttu-id="9332a-114">大きいサーフェス領域は、ユーザーが参照および使用する可能性があるコンテンツを、アプリが強調表示するためのステージとして機能します。</span><span class="sxs-lookup"><span data-stu-id="9332a-114">The large surface area serves as a stage for apps to highlight content that users may want to browse and consume.</span></span>

### <a name="collections"></a><span data-ttu-id="9332a-115">コレクション</span><span class="sxs-lookup"><span data-stu-id="9332a-115">Collections</span></span>

![ギャラリー](images/content-basics/gridview.png)

<span data-ttu-id="9332a-117">コレクションを使用すると、ユーザーはコンテンツやデータのグループを参照することができます。</span><span class="sxs-lookup"><span data-stu-id="9332a-117">Collections allow users to browse groups of content or data.</span></span> <span data-ttu-id="9332a-118">[グリッド ビュー](../controls-and-patterns/item-templates-gridview.md)は写真またはメディアを中心とするコンテンツに適していて、[リスト ビュー](../controls-and-patterns/item-templates-listview.md)はテキストが多いコンテンツやデータに適しています。</span><span class="sxs-lookup"><span data-stu-id="9332a-118">[Grid view](../controls-and-patterns/item-templates-gridview.md) is a good option for photos or media-centric content, and [list view](../controls-and-patterns/item-templates-listview.md) is a good option for text-heavy content or data.</span></span>


### <a name="masterdetail"></a><span data-ttu-id="9332a-119">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="9332a-119">Master/detail</span></span>

![マスター/詳細](images/content-basics/master-detail.png)

<span data-ttu-id="9332a-121">[マスター/詳細](../controls-and-patterns/master-details.md)モデルは、リスト ビュー (マスター) とコンテンツ ビュー (詳細) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="9332a-121">The [master/details](../controls-and-patterns/master-details.md) model consists of a list view (master) and a content view (detail).</span></span> <span data-ttu-id="9332a-122">両方のウィンドウは固定されていて、垂直方向にスクロールできます。</span><span class="sxs-lookup"><span data-stu-id="9332a-122">Both panes are fixed and have vertical scrolling.</span></span> <span data-ttu-id="9332a-123">リスト項目とコンテンツ ビューの間には明確な関係があります。マスター ビューで項目が選択されると、詳細ビューがそれに応じて更新されます。</span><span class="sxs-lookup"><span data-stu-id="9332a-123">There is a clear relationship between the list item and the content view: the item in the master view is selected, and the detail view is correspondingly updated.</span></span> <span data-ttu-id="9332a-124">詳細ビューのナビゲーションが提供されるだけでなく、マスター ビュー内の項目を追加および削除することができます。</span><span class="sxs-lookup"><span data-stu-id="9332a-124">In addition to providing detail view navigation, items in the master view can be added and removed.</span></span>

### <a name="details"></a><span data-ttu-id="9332a-125">詳細</span><span class="sxs-lookup"><span data-stu-id="9332a-125">Details</span></span>

![複数のビュー](images/multi-view.png)

<span data-ttu-id="9332a-127">ユーザーが探していたコンテンツを見つけたときに、無駄な情報がないページを表示できるように、専用のコンテンツ表示ページを作成することを検討します。</span><span class="sxs-lookup"><span data-stu-id="9332a-127">When users find the content they are looking for, consider creating a dedicated content-viewing page so that users can view the page free of distractions.</span></span> <span data-ttu-id="9332a-128">可能であれば、コンテンツを画面全体に拡張し、他のすべての UI 要素を非表示にする、[全画面表示のオプションを作成](../layout/show-multiple-views.md)します。</span><span class="sxs-lookup"><span data-stu-id="9332a-128">If possible, [create a full-screen view option](../layout/show-multiple-views.md) that expands the content to fill the entire screen and hides all other UI elements.</span></span> 

<span data-ttu-id="9332a-129">画面サイズの変化を調整するために、必要に応じて UI 要素の表示/非表示を切り替える[レスポンシブ デザイン](design-and-ui-intro.md)の作成も検討します。</span><span class="sxs-lookup"><span data-stu-id="9332a-129">To adjust for changes in screen size, also consider creating a [responsive design](design-and-ui-intro.md) that hides/shows UI elements as appropriate.</span></span>

### <a name="forms"></a><span data-ttu-id="9332a-130">フォーム</span><span class="sxs-lookup"><span data-stu-id="9332a-130">Forms</span></span>
![フォーム](images/content-basics/forms.png)

<span data-ttu-id="9332a-132">[フォーム](../controls-and-patterns/forms.md)は、ユーザーからデータを収集して送信するコントロールのグループです。</span><span class="sxs-lookup"><span data-stu-id="9332a-132">A [form](../controls-and-patterns/forms.md) is a group of controls that collect and submit data from users.</span></span> <span data-ttu-id="9332a-133">すべてではなくても、ほとんどのアプリが、設定ページ、ログイン ポータル、フィードバック Hub、アカウントの作成などのために、何らかのフォームを使用しています。</span><span class="sxs-lookup"><span data-stu-id="9332a-133">Most, if not all apps, use a form of some sort for settings pages, log in portals, feedback hubs, account creation, or other purposes.</span></span> 

## <a name="common-content-elements"></a><span data-ttu-id="9332a-134">一般的なコンテンツ要素</span><span class="sxs-lookup"><span data-stu-id="9332a-134">Common content elements</span></span>

<span data-ttu-id="9332a-135">これらのページ パターンを作成するには、個々のコンテンツ要素を組み合わせて使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9332a-135">To create these page patterns, you'll need to use a combination of individual content elements.</span></span> <span data-ttu-id="9332a-136">コンテンツの表示によく使われるいくつかの UI 要素を次に示します。</span><span class="sxs-lookup"><span data-stu-id="9332a-136">Here are some UI elements that are commonly used to display content.</span></span> <span data-ttu-id="9332a-137">UI 要素の全一覧については、「[コントロールとパターン](../controls-and-patterns/index.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9332a-137">(For a complete list of UI elements, see [controls and patterns](../controls-and-patterns/index.md).</span></span>

<div class="mx-responsive-img">
<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="9332a-138">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="9332a-138">Category</span></span></th>
<th align="left"><span data-ttu-id="9332a-139">要素</span><span class="sxs-lookup"><span data-stu-id="9332a-139">Elements</span></span></th>
<th align="left"><span data-ttu-id="9332a-140">説明</span><span class="sxs-lookup"><span data-stu-id="9332a-140">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="9332a-141">オーディオとビデオ</span><span class="sxs-lookup"><span data-stu-id="9332a-141">Audio and video</span></span><br/><br/>
    <img src="images/content-basics/media-transport.png" alt="media transport control" /></td>
<td align="left"><a href="../controls-and-patterns/media-playback.md"><span data-ttu-id="9332a-142">メディア再生コントロールとメディア トランスポート コントロール</span><span class="sxs-lookup"><span data-stu-id="9332a-142">Media playback and transport controls</span></span></a></td>
<td align="left"><span data-ttu-id="9332a-143">オーディオとビデオを再生します。</span><span class="sxs-lookup"><span data-stu-id="9332a-143">Plays audio and video.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="9332a-144">画像ビューアー</span><span class="sxs-lookup"><span data-stu-id="9332a-144">Image viewers</span></span><br/><br/>
    <img src="images/content-basics/flipview.jpg" alt="flip view" /></td>
<td align="left"><span data-ttu-id="9332a-145"><a href="../controls-and-patterns/flipview.md">フリップ ビュー</a>、<a href="../controls-and-patterns/images-imagebrushes.md">画像</a></span><span class="sxs-lookup"><span data-stu-id="9332a-145"><a href="../controls-and-patterns/flipview.md">Flip view</a>, <a href="../controls-and-patterns/images-imagebrushes.md">image</a></span></span></td>
<td align="left"><span data-ttu-id="9332a-146">画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="9332a-146">Displays images.</span></span> <span data-ttu-id="9332a-147">FlipView は、コレクション内の画像 (アルバム内の写真や製品の詳細ページ内の項目など) を一度に 1 つずつ表示します。</span><span class="sxs-lookup"><span data-stu-id="9332a-147">The flip view displays images in a collection, such as photos in an album or items in a product details page, one image at a time.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="9332a-148">コレクション</span><span class="sxs-lookup"><span data-stu-id="9332a-148">Collections</span></span> <br/><br/>
    <img src="images/content-basics/listview.png" alt="list view" /></td>
<td align="left"><a href="../controls-and-patterns/lists.md"><span data-ttu-id="9332a-149">リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="9332a-149">List view and grid view</span></span></a></td>
<td align="left"><span data-ttu-id="9332a-150">対話型のリストまたはグリッド内に項目を表示します。</span><span class="sxs-lookup"><span data-stu-id="9332a-150">Presents items in an interactive list or a grid.</span></span> <span data-ttu-id="9332a-151">これらの要素を使うと、ユーザーは新着の一覧からムービーを選んだり、在庫を管理したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="9332a-151">Use these elements to let users select a movie from a list of new releases or manage an inventory.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="9332a-152">テキストとテキスト入力</span><span class="sxs-lookup"><span data-stu-id="9332a-152">Text and text input</span></span> <br/><br/>
    <img src="images/content-basics/textbox.png" alt="text box" /></td>
<td align="left"><p><span data-ttu-id="9332a-153"><a href="../controls-and-patterns/text-block.md">テキスト ブロック</a>、<a href="../controls-and-patterns/text-box.md">テキスト ボックス</a>、<a href="../controls-and-patterns/rich-edit-box.md">リッチ エディット ボックス</a></span><span class="sxs-lookup"><span data-stu-id="9332a-153"><a href="../controls-and-patterns/text-block.md">Text block</a>, <a href="../controls-and-patterns/text-box.md">text box</a>, <a href="../controls-and-patterns/rich-edit-box.md">rich edit box</a></span></span></p>
</td>
<td align="left"><span data-ttu-id="9332a-154">テキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="9332a-154">Displays text.</span></span> <span data-ttu-id="9332a-155">一部の要素を使うと、ユーザーがテキストを編集することができます。</span><span class="sxs-lookup"><span data-stu-id="9332a-155">Some elements enable the user to edit text.</span></span> <span data-ttu-id="9332a-156">詳しくは、「<a href="../controls-and-patterns/text-controls.md">テキスト コントロール</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9332a-156">For more info, see <a href="../controls-and-patterns/text-controls.md">Text controls</a>.</span></span>
<p><span data-ttu-id="9332a-157">テキストの表示方法のガイドラインについては、「<a href="../style/typography.md">文字体裁</a>」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9332a-157">For guidelines on how to display text, see <a href="../style/typography.md">Typography</a>.</span></span></p>
</td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="9332a-158">マップ</span><span class="sxs-lookup"><span data-stu-id="9332a-158">Maps</span></span><br/><br/>
    <img src="images/content-basics/mapcontrol.png" alt="map control" /></td>
<td align="left"><a href="../../maps-and-location/display-maps.md"><span data-ttu-id="9332a-159">MapControl</span><span class="sxs-lookup"><span data-stu-id="9332a-159">MapControl</span></span></a></td>
<td align="left"><span data-ttu-id="9332a-160">シンボリックまたは写実的な地球のマップを表示します。</span><span class="sxs-lookup"><span data-stu-id="9332a-160">Displays a symbolic or photorealistic map of the Earth.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="9332a-161">WebView</span><span class="sxs-lookup"><span data-stu-id="9332a-161">WebView</span></span></td>
<td align="left"><a href="../controls-and-patterns/web-view.md"><span data-ttu-id="9332a-162">WebView</span><span class="sxs-lookup"><span data-stu-id="9332a-162">WebView</span></span></a></td>
<td align="left"><span data-ttu-id="9332a-163">HTML コンテンツをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="9332a-163">Renders HTML content.</span></span></td>
</tr>
</tbody>
</table>
</div>
