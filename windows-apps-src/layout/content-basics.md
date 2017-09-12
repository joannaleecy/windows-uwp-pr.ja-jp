---
author: mijacobs
Description: "どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。 たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。"
title: "ユニバーサル Windows プラットフォーム (UWP) アプリのコンテンツ デザインの基本"
ms.assetid: 3102530A-E0D1-4C55-AEFF-99443D39D567
label: Content design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 988fa8c4b0a9b0731fbe6976b5a71da06e77b559
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
#  <a name="content-design-basics-for-uwp-apps"></a><span data-ttu-id="b61e1-105">UWP アプリのコンテンツ デザインの基本</span><span class="sxs-lookup"><span data-stu-id="b61e1-105">Content design basics for UWP apps</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="b61e1-106">どのようなアプリでも、主な目的はコンテンツへのアクセスを提供することです。たとえば、写真編集アプリでは写真がコンテンツであり、旅行アプリでは地図と旅行の目的地に関する情報がコンテンツです。</span><span class="sxs-lookup"><span data-stu-id="b61e1-106">The main purpose of any app is to provide access to content: in a photo-editing app, the photo is the content; in a travel app, maps and info about travel destinations is the content; and so on.</span></span> <span data-ttu-id="b61e1-107">ナビゲーション要素はコンテンツへのアクセスを提供します。コマンド要素はユーザーがコンテンツを操作できるようにし、コンテンツ要素は実際のコンテンツを表示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-107">Navigation elements provide access to content; command elements enable the user to interact with content; content elements display the actual content.</span></span>

<span data-ttu-id="b61e1-108">この記事では、3 つのコンテンツ シナリオでのコンテンツの設計に関する推奨事項を示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-108">This article provides content design recommendations for the three content scenarios.</span></span>

## <a name="design-for-the-right-content-scenario"></a><span data-ttu-id="b61e1-109">適切なコンテンツ シナリオの設計</span><span class="sxs-lookup"><span data-stu-id="b61e1-109">Design for the right content scenario</span></span>


<span data-ttu-id="b61e1-110">次の 3 つの主要なコンテンツ シナリオがあります。</span><span class="sxs-lookup"><span data-stu-id="b61e1-110">There are three main content scenarios:</span></span>

-   <span data-ttu-id="b61e1-111">**使用**: コンテンツを使用する、主に一方向のエクスペリエンス。</span><span class="sxs-lookup"><span data-stu-id="b61e1-111">**Consumption**: A primarily one-way experience where content is consumed.</span></span> <span data-ttu-id="b61e1-112">使用は、読む、音楽を聴く、ビデオを見る、写真や画像を表示するなどのタスクです。</span><span class="sxs-lookup"><span data-stu-id="b61e1-112">It includes tasks like reading, listening to music, watching videos, and photo and image viewing.</span></span>
-   <span data-ttu-id="b61e1-113">**作成**: 新しいコンテンツの作成が焦点となる、主に一方向のエクスペリエンス。</span><span class="sxs-lookup"><span data-stu-id="b61e1-113">**Creation**: A primarily one-way experience where the focus is creating new content.</span></span> <span data-ttu-id="b61e1-114">作成は、写真やビデオの撮影のように何かをゼロから作る、描画アプリで新しい画像を作る、新しいドキュメントを開くなどに分かれます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-114">It can be broken down into making things from scratch, like shooting a photo or video, creating a new image in a painting app, or opening a fresh document.</span></span>
-   <span data-ttu-id="b61e1-115">**対話型**: コンテンツの使用、作成、修正を含む、2 方向のコンテンツ エクスペリエンス。</span><span class="sxs-lookup"><span data-stu-id="b61e1-115">**Interactive**: A two-way content experience that includes consuming, creating, and revising content.</span></span>

## <a name="consumption-focused-apps"></a><span data-ttu-id="b61e1-116">使用に重点を置いたアプリ</span><span class="sxs-lookup"><span data-stu-id="b61e1-116">Consumption-focused apps</span></span>


<span data-ttu-id="b61e1-117">使用に重点を置いたアプリでは、コンテンツ要素の優先順位が最も高く、ユーザーが目的のコンテンツを探すために必要な [ナビゲーション要素](navigation-basics.md) が次に続きます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-117">Content elements receive the highest priority in a consumption-focused app, followed by the [navigation elements](navigation-basics.md) needed to help users find the content they want.</span></span> <span data-ttu-id="b61e1-118">使用に重点を置いたアプリの例として、ムービー プレーヤー、読書アプリ、音楽アプリ、フォト ビューアーなどがあります。</span><span class="sxs-lookup"><span data-stu-id="b61e1-118">Examples of consumption-focused apps include movie players, reading apps, music apps, and photo viewers.</span></span>

![ニュースリーダー アプリ](images/news-reader/v2/newsreader-v2-tablet-phone.png)

<span data-ttu-id="b61e1-120">使用に重点を置いたアプリに関する一般的な推奨事項:</span><span class="sxs-lookup"><span data-stu-id="b61e1-120">General recommendations for consumption-focused apps:</span></span>

-   <span data-ttu-id="b61e1-121">専用の [ナビゲーション](navigation-basics.md) ページとコンテンツ表示ページを作成し、ユーザーが探していたコンテンツを見つけたときに、無駄な情報がない専用のページでそのコンテンツを表示できるようにすることを検討します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-121">Consider creating dedicated [navigation](navigation-basics.md) pages and content-viewing pages, so that when users find the content they are looking for, they can view it on a dedicated page free of distractions.</span></span>
-   <span data-ttu-id="b61e1-122">コンテンツを画面全体に拡張し、その他のすべての UI 要素を非表示にする、全画面表示のオプションを作成することを検討します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-122">Consider creating a full-screen view option that expands the content to fill the entire screen and hides all other UI elements.</span></span>

## <a name="creation-focused-apps"></a><span data-ttu-id="b61e1-123">作成に重点を置いたアプリ</span><span class="sxs-lookup"><span data-stu-id="b61e1-123">Creation-focused apps</span></span>


<span data-ttu-id="b61e1-124">コンテンツと [コマンド](commanding-basics.md) 要素は、作成に重点を置いたアプリでは最も重要な UI 要素です。コマンド要素により、ユーザーは新しいコンテンツを作成することができます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-124">Content and [command](commanding-basics.md) elements are the most import UI elements in a creation-focused app: command elements enable the user to create new content.</span></span> <span data-ttu-id="b61e1-125">この例には、ペイント アプリ、写真編集アプリ、ビデオ編集アプリ、ワード プロセッシング アプリがあります。</span><span class="sxs-lookup"><span data-stu-id="b61e1-125">Examples include painting apps, photo editing apps, video editing apps, and word processing apps.</span></span>

<span data-ttu-id="b61e1-126">例として、コマンド バーを使ってツールや写真操作オプションにアクセスできるようにするフォト アプリのデザインを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-126">As an example, here's a design for a photo app that uses command bars to provide access to tools and photo manipulation options.</span></span> <span data-ttu-id="b61e1-127">すべてのコマンドがコマンド バーにあるため、アプリは画面のスペースのほとんどをそのコンテンツ (編集する写真) に充てることができます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-127">Because all the commands are in the command bar, the app can devote most of its screen space to its content, the photo being edited.</span></span>

![アクティブなキャンバスを使った写真編集アプリの設計例](images/photo-editor/uap-photo-tabletphone-sbs.png)

<span data-ttu-id="b61e1-129">作成に重点を置いたアプリに関する一般的な推奨事項:</span><span class="sxs-lookup"><span data-stu-id="b61e1-129">General recommendations for creation-focused apps:</span></span>

-   <span data-ttu-id="b61e1-130">[ナビゲーション](navigation-basics.md) 要素の使用を最小限に抑えます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-130">Minimize the use of [navigation](navigation-basics.md) elements.</span></span>
-   <span data-ttu-id="b61e1-131">[コマンド](commanding-basics.md)要素は、作成に重点を置いたアプリで特に重要です。</span><span class="sxs-lookup"><span data-stu-id="b61e1-131">[Command](commanding-basics.md) elements are especially important in creation-focused apps.</span></span> <span data-ttu-id="b61e1-132">ユーザーは多くのコマンドを実行するため、コマンド履歴/元に戻す機能を提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b61e1-132">Since users will be executing a lot of commands, we recommend providing a command history/undo functionality.</span></span>

## <a name="apps-with-interactive-content"></a><span data-ttu-id="b61e1-133">対話型コンテンツを含むアプリ</span><span class="sxs-lookup"><span data-stu-id="b61e1-133">Apps with interactive content</span></span>


<span data-ttu-id="b61e1-134">対話型コンテンツを含むアプリでは、ユーザーはコンテンツを作成、表示、編集します。多くのアプリはこのカテゴリに分類されます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-134">In an app with interactive content, users create, view, and edit content; many apps fit into this category.</span></span> <span data-ttu-id="b61e1-135">これらの種類のアプリの例には、基幹業務アプリ、在庫管理アプリ、ユーザーがレシピを作成または変更できる料理のアプリなどがあります。</span><span class="sxs-lookup"><span data-stu-id="b61e1-135">Examples of these types of apps include line of business apps, inventory management apps, cooking apps that enable the user to create or modify recipes.</span></span>

![コラボレーション ツールの設計、対話型コンテンツを含むアプリ](images/collaboration-tool/uap-collaboration-tabphone-700.png)

<span data-ttu-id="b61e1-137">これらの種類のアプリでは、次の 3 つすべての UI 要素のバランスを取る必要があります。</span><span class="sxs-lookup"><span data-stu-id="b61e1-137">These sort of apps need to balance all three UI elements:</span></span>

-   <span data-ttu-id="b61e1-138">[ナビゲーション](navigation-basics.md)要素を使用すると、ユーザーがコンテンツを見つけて表示しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="b61e1-138">[Navigation](navigation-basics.md) elements help users find and view content.</span></span> <span data-ttu-id="b61e1-139">コンテンツの表示と検索が最も重要なシナリオである場合は、ナビゲーション要素、フィルター処理と並べ替え、検索を優先します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-139">If viewing and finding content is the most important scenario, prioritize navigation elements, filtering and sorting, and search.</span></span>
-   <span data-ttu-id="b61e1-140">[コマンド](commanding-basics.md)要素を使用すると、ユーザーはコンテンツを作成、編集、操作できます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-140">[Command](commanding-basics.md) elements let the user create, edit, and manipulate content.</span></span>

<span data-ttu-id="b61e1-141">対話型コンテンツを使ったアプリに関する一般的な推奨事項:</span><span class="sxs-lookup"><span data-stu-id="b61e1-141">General recommendations for apps with interactive content:</span></span>

-   <span data-ttu-id="b61e1-142">3 つすべてが重要であるときに、ナビゲーション、コンテンツ、およびコマンド要素のバランスを取ることは困難である場合があります。</span><span class="sxs-lookup"><span data-stu-id="b61e1-142">It can be difficult to balance navigation, content, and command elements when all three are important.</span></span> <span data-ttu-id="b61e1-143">可能であれば、コンテンツの閲覧、作成、編集用の別の画面を作成するか、モード スイッチを提供することを検討します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-143">If possible, consider creating separate screens for browsing, creating, and editing content, or providing mode switches.</span></span>

## <a name="commonly-used-content-elements"></a><span data-ttu-id="b61e1-144">よく使われるコンテンツ要素</span><span class="sxs-lookup"><span data-stu-id="b61e1-144">Commonly used content elements</span></span>


<span data-ttu-id="b61e1-145">コンテンツの表示によく使われるいくつかの UI 要素を次に示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-145">Here are some UI elements commonly used to display content.</span></span> <span data-ttu-id="b61e1-146">UI 要素の全一覧については、「[コントロールと UI 要素](https://msdn.microsoft.com/library/windows/apps/dn611856)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b61e1-146">(For a complete list of UI elements, see [Controls and UI elements](https://msdn.microsoft.com/library/windows/apps/dn611856).)</span></span>

<table>
<colgroup>
<col width="33%" />
<col width="33%" />
<col width="33%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="b61e1-147">カテゴリ</span><span class="sxs-lookup"><span data-stu-id="b61e1-147">Category</span></span></th>
<th align="left"><span data-ttu-id="b61e1-148">要素</span><span class="sxs-lookup"><span data-stu-id="b61e1-148">Elements</span></span></th>
<th align="left"><span data-ttu-id="b61e1-149">説明</span><span class="sxs-lookup"><span data-stu-id="b61e1-149">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="b61e1-150">オーディオとビデオ</span><span class="sxs-lookup"><span data-stu-id="b61e1-150">Audio and video</span></span></td>
<td align="left">[<span data-ttu-id="b61e1-151">メディア再生コントロールとメディア トランスポート コントロール</span><span class="sxs-lookup"><span data-stu-id="b61e1-151">Media playback and transport controls</span></span>](../controls-and-patterns/media-playback.md)</td>
<td align="left"><span data-ttu-id="b61e1-152">オーディオとビデオを再生します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-152">Plays audio and video.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="b61e1-153">画像ビューアー</span><span class="sxs-lookup"><span data-stu-id="b61e1-153">Image viewers</span></span></td>
<td align="left"><span data-ttu-id="b61e1-154">[フリップ ビュー](../controls-and-patterns/flipview.md)、[画像](../controls-and-patterns/images-imagebrushes.md)</span><span class="sxs-lookup"><span data-stu-id="b61e1-154">[Flip view](../controls-and-patterns/flipview.md), [image](../controls-and-patterns/images-imagebrushes.md)</span></span></td>
<td align="left"><span data-ttu-id="b61e1-155">画像を表示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-155">Displays images.</span></span> <span data-ttu-id="b61e1-156">FlipView は、コレクション内の画像 (アルバム内の写真や製品の詳細ページ内の項目など) を一度に 1 つずつ表示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-156">The flip view displays images in a collection, such as photos in an album or items in a product details page, one image at a time.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="b61e1-157">リスト</span><span class="sxs-lookup"><span data-stu-id="b61e1-157">Lists</span></span></td>
<td align="left">[<span data-ttu-id="b61e1-158">ドロップダウン リスト、リスト ボックス、リスト ビューとグリッド ビュー</span><span class="sxs-lookup"><span data-stu-id="b61e1-158">drop-down list, list box, list view and grid view</span></span>](../controls-and-patterns/lists.md)</td>
<td align="left"><span data-ttu-id="b61e1-159">対話型のリストまたはグリッド内に項目を表示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-159">Presents items in an interactive list or a grid.</span></span> <span data-ttu-id="b61e1-160">これらの要素を使うと、ユーザーは新着の一覧からムービーを選んだり、在庫を管理したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-160">Use these elements to let users select a movie from a list of new releases or manage an inventory.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="b61e1-161">テキストとテキスト入力</span><span class="sxs-lookup"><span data-stu-id="b61e1-161">Text and text input</span></span></td>
<td align="left"><p><span data-ttu-id="b61e1-162">[テキスト ブロック](../controls-and-patterns/text-block.md)、[テキスト ボックス](../controls-and-patterns/text-box.md)、[リッチ エディット ボックス](../controls-and-patterns/rich-edit-box.md)</span><span class="sxs-lookup"><span data-stu-id="b61e1-162">[Text block](../controls-and-patterns/text-block.md), [text box](../controls-and-patterns/text-box.md), [rich edit box](../controls-and-patterns/rich-edit-box.md)</span></span></p>
</td>
<td align="left"><span data-ttu-id="b61e1-163">テキストを表示します。</span><span class="sxs-lookup"><span data-stu-id="b61e1-163">Displays text.</span></span> <span data-ttu-id="b61e1-164">一部の要素を使うと、ユーザーがテキストを編集することができます。</span><span class="sxs-lookup"><span data-stu-id="b61e1-164">Some elements enable the user to edit text.</span></span> <span data-ttu-id="b61e1-165">詳しくは、「[テキスト コントロール](../controls-and-patterns/text-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="b61e1-165">For more info, see [Text controls](../controls-and-patterns/text-controls.md)</span></span></td>
</tr>
</tbody>
</table>



 

 




