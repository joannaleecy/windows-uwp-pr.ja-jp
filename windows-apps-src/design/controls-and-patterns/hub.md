---
author: Jwmsft
Description: The hub control uses a hierarchical navigation pattern to support apps with a relational information architecture.
title: ハブ コントロール
ms.assetid: F1319960-63C6-4A8B-8DA1-451D59A01AC2
label: Hub
template: detail.hbs
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: yulikl
design-contact: kimsea
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 3d73ff59b03f288227b1435b0b931d11860259ec
ms.sourcegitcommit: d0e836dfc937ebf7dfa9c424620f93f3c8e0a7e8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5664919"
---
# <a name="hub-controlpattern"></a><span data-ttu-id="31e13-103">ハブ コントロール/パターン</span><span class="sxs-lookup"><span data-stu-id="31e13-103">Hub control/pattern</span></span>

 


<span data-ttu-id="31e13-104">ハブ コントロールを使うと、アプリのコンテンツを、関連した別個のセクションやカテゴリに整理できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-104">A hub control lets you organize app content into distinct, yet related, sections or categories.</span></span> <span data-ttu-id="31e13-105">ハブのセクションは、優先順に走査するためのものであり、さらに細かい操作性を実現するための出発点として使うことができます。</span><span class="sxs-lookup"><span data-stu-id="31e13-105">Sections in a hub are meant to be traversed in a preferred order, and can serve as the starting point for more detailed experiences.</span></span>

> <span data-ttu-id="31e13-106">**重要な API**: [Hub クラス](https://msdn.microsoft.com/library/windows/apps/dn251843)、[HubSection クラス](https://msdn.microsoft.com/library/windows/apps/dn251845)</span><span class="sxs-lookup"><span data-stu-id="31e13-106">**Important APIs**: [Hub class](https://msdn.microsoft.com/library/windows/apps/dn251843), [HubSection class](https://msdn.microsoft.com/library/windows/apps/dn251845)</span></span>

![ハブの例](images/hub_example_tablet.png)

<span data-ttu-id="31e13-108">ハブのコンテンツはパノラマ ビューに表示でき、ユーザーは、新しい情報、入手可能な情報、関連する情報がひとめでわかります。</span><span class="sxs-lookup"><span data-stu-id="31e13-108">Content in a hub can be displayed in a panoramic view that allows users to get a glimpse of what's new, what's available, and what's relevant.</span></span> <span data-ttu-id="31e13-109">ハブには通常、ページ ヘッダーがあり、各コンテンツ セクションにはセクション ヘッダーがあります。</span><span class="sxs-lookup"><span data-stu-id="31e13-109">Hubs typically have a page header, and content sections each get a section header.</span></span>


## <a name="is-this-the-right-control"></a><span data-ttu-id="31e13-110">適切なコントロールの選択</span><span class="sxs-lookup"><span data-stu-id="31e13-110">Is this the right control?</span></span>

<span data-ttu-id="31e13-111">ハブ コントロールは、階層に配置された大量のコンテンツを表示する場合に適しています。</span><span class="sxs-lookup"><span data-stu-id="31e13-111">The hub control works well for displaying large amounts of content that is arranged in a hierarchy.</span></span> <span data-ttu-id="31e13-112">ハブは、新しいコンテンツの閲覧と検出の優先順位を設定し、ストアやメディア コレクション内の項目を表示する際に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="31e13-112">Hubs prioritize the browsing and discovery of new content, making them useful for displaying items in a store or a media collection.</span></span>

<span data-ttu-id="31e13-113">ハブ コントロールには、コンテンツのナビゲーション パターンを構築するのに適したいくつかの機能があります。</span><span class="sxs-lookup"><span data-stu-id="31e13-113">The hub control has several features that make it work well for building a content navigation pattern.</span></span>

-   **<span data-ttu-id="31e13-114">視覚的なナビゲーション</span><span class="sxs-lookup"><span data-stu-id="31e13-114">Visual navigation</span></span>**

    <span data-ttu-id="31e13-115">ハブを使うと、多様性のある簡潔なスキャンしやすい配列にコンテンツを表示できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-115">A hub allows content to be displayed in a diverse, brief, easy-to-scan array.</span></span>

-   **<span data-ttu-id="31e13-116">分類</span><span class="sxs-lookup"><span data-stu-id="31e13-116">Categorization</span></span>**

    <span data-ttu-id="31e13-117">各ハブ セクションでは、コンテンツを論理的な順序に配置できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-117">Each hub section allows for its content to be arranged in a logical order.</span></span>

-   **<span data-ttu-id="31e13-118">混在したコンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="31e13-118">Mixed content types</span></span>**

    <span data-ttu-id="31e13-119">コンテンツの種類が混在する場合、資産の可変サイズと比率は共通です。</span><span class="sxs-lookup"><span data-stu-id="31e13-119">With mixed content types, variable asset sizes and ratios are common.</span></span> <span data-ttu-id="31e13-120">ハブを使うと、コンテンツの各種類を一意なものにし、各ハブ セクションに整然と配置できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-120">A hub allows each content type to be uniquely and neatly laid out in each hub section.</span></span>

-   **<span data-ttu-id="31e13-121">ページとコンテンツの可変幅</span><span class="sxs-lookup"><span data-stu-id="31e13-121">Variable page and content widths</span></span>**

    <span data-ttu-id="31e13-122">パノラマ モデルであるハブでは、セクション幅を調整できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-122">Being a panoramic model, the hub allows for variability in its section widths.</span></span> <span data-ttu-id="31e13-123">これは異なる深度や量を含んだコンテンツに適してします。</span><span class="sxs-lookup"><span data-stu-id="31e13-123">This is great for content of different depths or quantities.</span></span>

-   **<span data-ttu-id="31e13-124">柔軟なアーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="31e13-124">Flexible architecture</span></span>**

    <span data-ttu-id="31e13-125">アプリのアーキテクチャを浅く維持する場合、すべてのチャネル コンテンツをハブ セクションの概要に収めることができます。</span><span class="sxs-lookup"><span data-stu-id="31e13-125">If you'd prefer to keep your app architecture shallow, you can fit all channel content into a hub section summary.</span></span>

<span data-ttu-id="31e13-126">ハブは、いくつかある利用可能なナビゲーション要素の 1 つです。ナビゲーション パターンと他のナビゲーション要素について詳しくは、「[ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーション デザインの基本](../basics/navigation-basics.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="31e13-126">A hub is just one of several navigation elements you can use; to learn more about navigation patterns and the other navigation elements, see the [Navigation design basics for Universal Windows Platform (UWP) apps](../basics/navigation-basics.md).</span></span>

## <a name="hub-architecture"></a><span data-ttu-id="31e13-127">ハブのアーキテクチャ</span><span class="sxs-lookup"><span data-stu-id="31e13-127">Hub architecture</span></span>

<span data-ttu-id="31e13-128">ハブ コントロールには、リレーショナル情報アーキテクチャを使ったアプリをサポートする階層型ナビゲーション パターンがあります。</span><span class="sxs-lookup"><span data-stu-id="31e13-128">The hub control has a hierarchical navigation pattern that support apps with a relational information architecture.</span></span> <span data-ttu-id="31e13-129">ハブはさまざまなカテゴリのコンテンツで構成され、それぞれがアプリのセクション ページに対応付けられています。</span><span class="sxs-lookup"><span data-stu-id="31e13-129">A hub consists of different categories of content, each of which maps to the app's section pages.</span></span> <span data-ttu-id="31e13-130">セクション ページは、シナリオとセクションに含まれるコンテンツが最適に表現されるような形で表示できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-130">Section pages can be displayed in any form that best represents the scenario and content that the section contains.</span></span>

![階層型の Food with Friends アプリのワイヤーフレーム](images/navigation_diagram_food_with_friends_app_new.png)

## <a name="layouts-and-panningscrolling"></a><span data-ttu-id="31e13-132">レイアウトとパン/スクロール</span><span class="sxs-lookup"><span data-stu-id="31e13-132">Layouts and panning/scrolling</span></span>

<span data-ttu-id="31e13-133">コンテンツをハブに配置して移動する方法はたくさんあります。ハブのコンテンツ リストが常にハブのスクロール方向に対して垂直にパンされる点だけ確認してください。</span><span class="sxs-lookup"><span data-stu-id="31e13-133">There are a number of ways to lay out and navigate content in a hub; just be sure that content lists in a hub always pan in a direction perpendicular to the direction in which the hub scrolls.</span></span>

**<span data-ttu-id="31e13-134">水平方向のパン</span><span class="sxs-lookup"><span data-stu-id="31e13-134">Horizontal panning</span></span>**

![<span data-ttu-id="31e13-135">水平方向にパンするハブの例](images/controls_hub_horizontal_pan.png)
**垂直方向のパン**</span><span class="sxs-lookup"><span data-stu-id="31e13-135">Example of a horizontally panning hub](images/controls_hub_horizontal_pan.png)
**Vertical panning**</span></span>

![<span data-ttu-id="31e13-136">垂直方向にパンするハブの例](images/controls_hub_vertical_pan.png)
**垂直方向のリストとグリッドのスクロールによる水平方向のパン**</span><span class="sxs-lookup"><span data-stu-id="31e13-136">Example of a vertically panning hub](images/controls_hub_vertical_pan.png)
**Horizontal panning with vertically scrolling list/grid**</span></span>

![<span data-ttu-id="31e13-137">垂直方向のリストのスクロールによる水平方向にパンするハブの例](images/controls_hub_horizontal_vertical_scroll.png)
**水平方向のリストとグリッドのスクロールによる垂直方向のパン**</span><span class="sxs-lookup"><span data-stu-id="31e13-137">Example of a horizontally panning hub with a vertically scrolling list](images/controls_hub_horizontal_vertical_scroll.png)
**Vertical panning with horizontally scrolling list/grid**</span></span>

![水平方向にパンするハブの例](images/controls_hub_vertical_horizontal_scroll.png)

## <a name="examples"></a><span data-ttu-id="31e13-139">例</span><span class="sxs-lookup"><span data-stu-id="31e13-139">Examples</span></span>

<table>
<th align="left"><span data-ttu-id="31e13-140">XAML コントロール ギャラリー</span><span class="sxs-lookup"><span data-stu-id="31e13-140">XAML Controls Gallery</span></span><th>
<tr>
<td><img src="images/xaml-controls-gallery-sm.png" alt="XAML controls gallery"></img></td>
<td>
    <p><span data-ttu-id="31e13-141"><strong style="font-weight: semi-bold">XAML コントロール ギャラリー</strong> アプリがインストールされている場合、こちらをクリックして<a href="xamlcontrolsgallery:/item/Hub">アプリを開き、Hub の動作を確認</a>してください。</span><span class="sxs-lookup"><span data-stu-id="31e13-141">If you have the <strong style="font-weight: semi-bold">XAML Controls Gallery</strong> app installed, click here to <a href="xamlcontrolsgallery:/item/Hub">open the app and see the Hub in action</a>.</span></span></p>
    <ul>
    <li><a href="https://www.microsoft.com/store/productId/9MSVH128X2ZT"><span data-ttu-id="31e13-142">XAML コントロール ギャラリー アプリを入手する (Microsoft Store)</span><span class="sxs-lookup"><span data-stu-id="31e13-142">Get the XAML Controls Gallery app (Microsoft Store)</span></span></a></li>
    <li><a href="https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics"><span data-ttu-id="31e13-143">ソース コード (GitHub) を入手する</span><span class="sxs-lookup"><span data-stu-id="31e13-143">Get the source code (GitHub)</span></span></a></li>
    </ul>
</td>
</tr>
</table>

<span data-ttu-id="31e13-144">ハブは、設計上の大きな柔軟性を備えています。</span><span class="sxs-lookup"><span data-stu-id="31e13-144">The hub provides a great deal of design flexibility.</span></span> <span data-ttu-id="31e13-145">そのため、魅力的で視覚に訴えるさまざまなエクスペリエンスを提供するアプリを設計できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-145">This lets you design apps that have a wide variety of compelling and visually rich experiences.</span></span> <span data-ttu-id="31e13-146">最初のグループには、ヒーロー画像やコンテンツ セクションを使うことができます。ヒーローには、最も強調したい内容を失うことなく垂直方向と水平方向にトリミングできる大きい画像を使ってください。</span><span class="sxs-lookup"><span data-stu-id="31e13-146">You can use a hero image or content section for the first group; a large image for the hero can be cropped both vertically and horizontally without losing the center of interest.</span></span> <span data-ttu-id="31e13-147">次の例は、1 つのヒーロー画像と、その画像を横長、縦長、狭い幅で表示するためにトリミングする方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="31e13-147">Here is an example of a single hero image and how that image may be cropped for landscape, portrait, and narrow width.</span></span>

![さまざまなウィンドウ サイズに合わせてトリミングされたヒーロー画像](images/hub_hero_cropped2.png)

<span data-ttu-id="31e13-149">モバイル デバイスでは、一度に 1 つのハブ セクションを表示できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-149">On mobile devices, one hub section is visible at a time.</span></span>

![小型画面上のハブ パターンの例](images/phone_hub_example.png)

## <a name="recommendations"></a><span data-ttu-id="31e13-151">推奨事項</span><span class="sxs-lookup"><span data-stu-id="31e13-151">Recommendations</span></span>

-   <span data-ttu-id="31e13-152">ハブ セクションに他のコンテンツがあることがユーザーにわかるように、一定量のコンテンツが見えるようにコンテンツをクリッピングすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="31e13-152">To let users know that there's more content in a hub section, we recommend clipping the content so that a certain amount of it peeks.</span></span>
-   <span data-ttu-id="31e13-153">アプリの必要に基づいて、ハブ コントロールに複数のハブ セクションを追加し、各セクションに独自の機能目的を持たせることができます。</span><span class="sxs-lookup"><span data-stu-id="31e13-153">Based on the needs of your app, you can add several hub sections to the hub control, with each one offering its own functional purpose.</span></span> <span data-ttu-id="31e13-154">たとえば、あるセクションには一連のリンクとコントロールを含め、別のセクションはサムネイルのリポジトリとすることができます。</span><span class="sxs-lookup"><span data-stu-id="31e13-154">For example, one section could contain a series of links and controls, while another could be a repository for thumbnails.</span></span> <span data-ttu-id="31e13-155">ユーザーは、ハブ コントロールに組み込まれているジェスチャのサポートを使って、これらのセクション間をパンすることができます。</span><span class="sxs-lookup"><span data-stu-id="31e13-155">A user can pan between these sections using the gesture support built into the hub control.</span></span>
-   <span data-ttu-id="31e13-156">さまざまなウィンドウ サイズに対応できるように、コンテンツを動的に再配置するのが最適です。</span><span class="sxs-lookup"><span data-stu-id="31e13-156">Having content dynamically reflow is the best way to accommodate different window sizes.</span></span>
-   <span data-ttu-id="31e13-157">多くのハブ セクションがある場合は、ハブにセマンティック ズームを追加することを検討します。</span><span class="sxs-lookup"><span data-stu-id="31e13-157">If you have many hub sections, consider adding semantic zoom.</span></span> <span data-ttu-id="31e13-158">これには、アプリが狭い幅に合わせてサイズ変更されたときにセクションを見つけやすくなるという利点もあります。</span><span class="sxs-lookup"><span data-stu-id="31e13-158">This also makes it easier to find sections when the app is resized to a narrow width.</span></span>
-   <span data-ttu-id="31e13-159">ハブ セクション内の項目から別のハブに移動することはお勧めしません。代わりに、対話型ヘッダーを使って別のセクションまたはページに移動します。</span><span class="sxs-lookup"><span data-stu-id="31e13-159">We recommend not having an item in a hub section lead to another hub; instead, you can use interactive headers to navigate to another hub section or page.</span></span>
-   <span data-ttu-id="31e13-160">ハブを基盤として使って、アプリの必要に合わせてカスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="31e13-160">The hub is a starting point and is meant to be customized to fit the needs of your app.</span></span> <span data-ttu-id="31e13-161">ハブの次の機能を変更できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-161">You can change the following aspects of a hub:</span></span>
    -   <span data-ttu-id="31e13-162">セクションの数</span><span class="sxs-lookup"><span data-stu-id="31e13-162">Number of sections</span></span>
    -   <span data-ttu-id="31e13-163">各セクションのコンテンツの種類</span><span class="sxs-lookup"><span data-stu-id="31e13-163">Type of content in each section</span></span>
    -   <span data-ttu-id="31e13-164">セクションの配置と順序</span><span class="sxs-lookup"><span data-stu-id="31e13-164">Placement and order of sections</span></span>
    -   <span data-ttu-id="31e13-165">セクションのサイズ</span><span class="sxs-lookup"><span data-stu-id="31e13-165">Size of sections</span></span>
    -   <span data-ttu-id="31e13-166">セクションとセクションの間隔</span><span class="sxs-lookup"><span data-stu-id="31e13-166">Spacing between sections</span></span>
    -   <span data-ttu-id="31e13-167">セクションとハブの上端または下端の間隔</span><span class="sxs-lookup"><span data-stu-id="31e13-167">Spacing between a section and the top or bottom of the hub</span></span>
    -   <span data-ttu-id="31e13-168">ヘッダーとコンテンツのテキストのスタイルとサイズ</span><span class="sxs-lookup"><span data-stu-id="31e13-168">Text style and size in headers and content</span></span>
    -   <span data-ttu-id="31e13-169">背景、セクション、セクション ヘッダー、セクション コンテンツの色</span><span class="sxs-lookup"><span data-stu-id="31e13-169">Color of the background, sections, section headers, and section content</span></span>

## <a name="get-the-sample-code"></a><span data-ttu-id="31e13-170">サンプル コードを入手する</span><span class="sxs-lookup"><span data-stu-id="31e13-170">Get the sample code</span></span>

- <span data-ttu-id="31e13-171">[XAML コントロール ギャラリー サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - インタラクティブな形で XAML コントロールのすべてを参照できます。</span><span class="sxs-lookup"><span data-stu-id="31e13-171">[XAML Controls Gallery sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/XamlUIBasics) - See all the XAML controls in an interactive format.</span></span>

## <a name="related-articles"></a><span data-ttu-id="31e13-172">関連記事</span><span class="sxs-lookup"><span data-stu-id="31e13-172">Related articles</span></span>

- [<span data-ttu-id="31e13-173">Hub クラス</span><span class="sxs-lookup"><span data-stu-id="31e13-173">Hub class</span></span>](https://msdn.microsoft.com/library/windows/apps/dn251843)
- [<span data-ttu-id="31e13-174">ナビゲーションの基本</span><span class="sxs-lookup"><span data-stu-id="31e13-174">Navigation basics</span></span>](../basics/navigation-basics.md)
- [<span data-ttu-id="31e13-175">ハブの使用</span><span class="sxs-lookup"><span data-stu-id="31e13-175">Using a hub</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/dn308518)
- [<span data-ttu-id="31e13-176">XAML ハブ コントロールのサンプル</span><span class="sxs-lookup"><span data-stu-id="31e13-176">XAML Hub control sample</span></span>](http://go.microsoft.com/fwlink/p/?LinkID=310072)
