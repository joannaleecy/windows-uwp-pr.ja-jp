---
author: QuinnRadich
Description: Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features.
title: UWP アプリのナビゲーションの基本
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: quradic
ms.date: 7/16/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: b731910f53a6152554b74e946374234b827f4a86
ms.sourcegitcommit: 7aa1933e6970f878faf50d59e1f799b90afd7cc7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/05/2018
ms.locfileid: "3382708"
---
# <a name="navigation-design-basics-for-uwp-apps"></a><span data-ttu-id="648a4-103">UWP アプリのナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="648a4-103">Navigation design basics for UWP apps</span></span>

![ナビゲーションの基本のヘッダー](images/nav/navigation-basics-header.jpg)

<span data-ttu-id="648a4-105">アプリをページの集まりと考えると、*ナビゲーション*は、ページ間およびページ内を移動する動作を表します。</span><span class="sxs-lookup"><span data-stu-id="648a4-105">If you think of an app as a collection of pages, *navigation* describes the act of moving between pages and within a page.</span></span> <span data-ttu-id="648a4-106">これはユーザー エクスペリエンスの出発点です。これによって、ユーザーは利用するコンテンツと機能を見つけます。</span><span class="sxs-lookup"><span data-stu-id="648a4-106">It's the starting point of the user experience, and it's how users find the content and features they're interested in.</span></span> <span data-ttu-id="648a4-107">これは非常に重要ですが、適切な設計が難しい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="648a4-107">It's very important, and it can be difficult to get right.</span></span>

<span data-ttu-id="648a4-108">ナビゲーションに関して行うことができる膨大な数の選択肢があります。</span><span class="sxs-lookup"><span data-stu-id="648a4-108">We have a huge number of choices to make for navigation.</span></span> <span data-ttu-id="648a4-109">以下を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="648a4-109">We could:</span></span>

:::row:::
    :::column:::
        ![ナビゲーション例 1](images/nav/nav-1.svg)

        Require users to go through a series of pages in order.
    :::column-end:::
    :::column:::
        ![navigation example 2](images/nav/nav-2.svg)

        Provide a menu that allows users to jump directly to any page.
    :::column-end:::
    :::column:::
        ![navigation example 3](images/nav/nav-3.svg)

        Place everything on a single page and provide filtering mechanisms for viewing content.
    :::column-end:::
:::row-end:::

<span data-ttu-id="648a4-111">1 つのナビゲーション デザインですべてのアプリに対応することはできませんが、アプリの適切な設計を判断するための原則やガイドラインがあります。</span><span class="sxs-lookup"><span data-stu-id="648a4-111">While there's no single navigation design that works for every app, there are principles and guidelines to help you decide the right design for your app.</span></span>

## <a name="principles-of-good-navigation"></a><span data-ttu-id="648a4-112">優れたナビゲーションの原則</span><span class="sxs-lookup"><span data-stu-id="648a4-112">Principles of good navigation</span></span>

<span data-ttu-id="648a4-113">優れたナビゲーション デザインの基本原則から始めましょう。</span><span class="sxs-lookup"><span data-stu-id="648a4-113">Let's start with the basic principles of good navigation design:</span></span>

- <span data-ttu-id="648a4-114">**一貫性:** ユーザーの期待に応えます。</span><span class="sxs-lookup"><span data-stu-id="648a4-114">**Consistency:** Meet user expectations.</span></span>
- <span data-ttu-id="648a4-115">**シンプルさ:** 必要以上のことをしないようにします。</span><span class="sxs-lookup"><span data-stu-id="648a4-115">**Simplicity:** Don't do more than you need to.</span></span>
- <span data-ttu-id="648a4-116">**明確さ:** 明確なパスとオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="648a4-116">**Clarity:** Provide clear paths and options.</span></span>

### <a name="consistency"></a><span data-ttu-id="648a4-117">一貫性</span><span class="sxs-lookup"><span data-stu-id="648a4-117">Consistency</span></span>

<span data-ttu-id="648a4-118">ナビゲーションは、ユーザーの期待に沿ったものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="648a4-118">Navigation should be consistent with user expectations.</span></span> <span data-ttu-id="648a4-119">[標準的なコントロール](#use-the-right-controls)のユーザーを理解している、アイコンの次の標準的な規則を使用して、場所、スタイルはことナビゲーション予測可能な直感的なユーザー向け。</span><span class="sxs-lookup"><span data-stu-id="648a4-119">Using [standard controls](#use-the-right-controls) that users are familiar with and following standard conventions for icons, location, and styling will make navigation predictable and intuitive for users.</span></span>

![ページ コンポーネントのイメージ](images/nav/page-components.svg)

> <span data-ttu-id="648a4-121">ユーザーは特定の UI 要素が標準の位置にあることを期待します。</span><span class="sxs-lookup"><span data-stu-id="648a4-121">Users expect to find certain UI elements in standard locations.</span></span>

### <a name="simplicity"></a><span data-ttu-id="648a4-122">シンプルさ</span><span class="sxs-lookup"><span data-stu-id="648a4-122">Simplicity</span></span>

<span data-ttu-id="648a4-123">ナビゲーション項目が少ないほど、ユーザーの意思決定がシンプルになります。</span><span class="sxs-lookup"><span data-stu-id="648a4-123">Fewer navigation items simplify decision making for users.</span></span> <span data-ttu-id="648a4-124">重要な移動先に簡単にアクセスできるようにして、重要度の低い項目を非表示にすることで、ユーザーは目的の場所にすばやく移動できるようになります。</span><span class="sxs-lookup"><span data-stu-id="648a4-124">Providing easy access to important destinations and hiding less important items will help users get where they want, faster.</span></span>

:::row:::
    :::column:::
        ![実行例](images/nav/do.svg)

        ![navview good](images/nav/navview-good.svg)

        Present navigation items in a familiar navigation menu.
    :::column-end:::
    :::column:::
        ![don't example](images/nav/dont.svg)

        ![navview bad](images/nav/navview-bad.svg)

        Overwhelm users with many navigation options.
    :::column-end:::
:::row-end:::

### <a name="clarity"></a><span data-ttu-id="648a4-126">明確さ</span><span class="sxs-lookup"><span data-stu-id="648a4-126">Clarity</span></span>

<span data-ttu-id="648a4-127">明確なパスを示すと、ユーザーは論理的なナビゲーションを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="648a4-127">Clear paths allow for logical navigation for users.</span></span> <span data-ttu-id="648a4-128">ナビゲーション オプションをわかりやすくし、ページ間の関係を明確にすることで、ユーザーが自分の位置を見失うことを防止できます。</span><span class="sxs-lookup"><span data-stu-id="648a4-128">Making navigation options obvious and clarifying relationships between pages should prevent users from getting lost.</span></span>

![実行例](images/nav/clarity-image.svg)

> <span data-ttu-id="648a4-130">移動先にはわかりやすいラベルが付けられているため、ユーザーは自分の位置を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="648a4-130">Destinations are clearly labeled so users know where they are.</span></span>

## <a name="general-recommendations"></a><span data-ttu-id="648a4-131">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="648a4-131">General recommendations</span></span>

<span data-ttu-id="648a4-132">一貫性、シンプルさ、明確さという設計原則を念頭に置いて、一般的な推奨事項を作成しましょう。</span><span class="sxs-lookup"><span data-stu-id="648a4-132">Now, let's take our design principles--consistency, simplicity, and clarity--and use them to come up with some general recommendations.</span></span>

1. <span data-ttu-id="648a4-133">ユーザーのことを考えてください。</span><span class="sxs-lookup"><span data-stu-id="648a4-133">Think about your users.</span></span> <span data-ttu-id="648a4-134">アプリ使用時のユーザーの一般的な移動パスを追跡し、ページごとに、ユーザーがそのページを表示している理由と、次にどこに移動しようとしているかを考えてください。</span><span class="sxs-lookup"><span data-stu-id="648a4-134">Trace out typical paths they might take through your app, and for each page, think about why the user is there and where they might want to go.</span></span>

2. <span data-ttu-id="648a4-135">ナビゲーションの深い階層を避けます。</span><span class="sxs-lookup"><span data-stu-id="648a4-135">Avoid deep navigation hierarchies.</span></span> <span data-ttu-id="648a4-136">3 レベルを超えるナビゲーションでは、ユーザーは迷ってしまい、深い階層から抜け出せなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="648a4-136">If you go beyond three levels of navigation, you risk stranding your user in a deep hierarchy that they will have difficulty leaving.</span></span>

3. <span data-ttu-id="648a4-137">「ホッピング」を避けます。</span><span class="sxs-lookup"><span data-stu-id="648a4-137">Avoid "pogo-sticking."</span></span> <span data-ttu-id="648a4-138">ホッピングとは、関連するコンテンツに移動するために、ユーザーが上のレベルに移動して、それから下のレベルに移動する必要があるナビゲーションを意味します。</span><span class="sxs-lookup"><span data-stu-id="648a4-138">Pogo-sticking occurs when there is related content, but navigating to it requires the user to go up a level and then down again.</span></span>

## <a name="use-the-right-structure"></a><span data-ttu-id="648a4-139">適切な構造を使う</span><span class="sxs-lookup"><span data-stu-id="648a4-139">Use the right structure</span></span>

<span data-ttu-id="648a4-140">ナビゲーションの一般的な原則について説明しました。次に、アプリの構造について考えます。</span><span class="sxs-lookup"><span data-stu-id="648a4-140">Now that you're familiar with general navigation principles, how should you structure your app?</span></span> <span data-ttu-id="648a4-141">2 種類の一般的な構造があります。フラット構造と階層構造です。</span><span class="sxs-lookup"><span data-stu-id="648a4-141">There are two general structures: flat and hierarchal.</span></span>

:::row:::
    :::column:::
        ![フラット構造で配置されたページ](images/nav/flat-lateral-structure.svg)
    :::column-end:::
    <span data-ttu-id="648a4-143">:::column span =「2」::。</span><span class="sxs-lookup"><span data-stu-id="648a4-143">:::column span="2":::</span></span>
        ### Flat/lateral

        In a flat/lateral structure, pages exist side-by-side. You can go from one page to another in any order.

        We recommend using a flat structure when:

        - The pages can be viewed in any order.
        - The pages are clearly distinct from each other and don't have an obvious parent/child relationship.
        - There are less than 8 pages in the group. <br>
        (When there are more pages, it might be difficult for users to understand how the pages are unique or to understand their current location within the group. If you don't think that's an issue for your app, go ahead and make the pages peers. Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups.)

    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![階層構造で配置されたページ](images/nav/hierarchical-structure.svg)
    :::column-end:::
    <span data-ttu-id="648a4-145">:::column span =「2」::。</span><span class="sxs-lookup"><span data-stu-id="648a4-145">:::column span="2":::</span></span>
        ### Hierarchical

        In a hierarchical structure, pages are organized into a tree-like structure. Each child page has one parent, but a parent can have one or more child pages. To reach a child page, you travel through the parent.

        Hierarchical structures are good for organizing complex content that spans lots of pages. The downside is some navigation overhead: the deeper the structure, the more clicks it takes to get from page to page.

        We recommend a hierarchical structure when:
        
        - Pages should be traversed in a specific order.
        - There is a clear parent-child relationship between pages.
        - There are more than 7 pages in the group.
        
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![ハイブリッド構造のアプリ](images/nav/combining-structures.svg)
    :::column-end:::
    <span data-ttu-id="648a4-147">:::column span =「2」::。</span><span class="sxs-lookup"><span data-stu-id="648a4-147">:::column span="2":::</span></span>
        ### Combining structures

        You don't have choose to one structure or the other; many well-design apps use both. An app can use flat structures for top-level pages that can be viewed in any order, and hierarchical structures for pages that have more complex relationships.

        If your navigation structure has multiple levels, we recommend that peer-to-peer navigation elements only link to the peers within their current subtree. Consider the adjacent illustration, which shows a navigation structure that has two levels:

        - At level 1, the peer-to-peer navigation element should provide access to pages A, B, C, and D.
        - At level 2, the peer-to-peer navigation elements for the A2 pages should only link to the other A2 pages. They should not link to level 2 pages in the C subtree.
    :::column-end:::
:::row-end:::

## <a name="use-the-right-controls"></a><span data-ttu-id="648a4-148">適切なコントロールを使用する</span><span class="sxs-lookup"><span data-stu-id="648a4-148">Use the right controls</span></span>

<span data-ttu-id="648a4-149">ページの構造を決定したら、ユーザーがページ間をどのように移動するかを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="648a4-149">Once you've decided on a page structure, you need to decide how users navigate through those pages.</span></span> <span data-ttu-id="648a4-150">UWP にはさまざまなナビゲーション コントロールが用意されていて、アプリで一貫性があり信頼性が高いナビゲーション エクスペリエンスを提供するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="648a4-150">UWP provides a variety of navigation controls to help ensure a consistent, reliable navigation experience in your app.</span></span>

:::row:::
    :::column:::
        ![フレーム画像](images/nav/thumbnail-frame.svg)
    :::column-end:::
    <span data-ttu-id="648a4-152">:::column span =「2」:::[**フレーム**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame)</span><span class="sxs-lookup"><span data-stu-id="648a4-152">:::column span="2"::: [**Frame**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame)</span></span>

        With few exceptions, any app that has multiple pages uses a frame. Typically, an app has a main page that contains the frame and a primary navigation element, such as a navigation view control. When the user selects a page, the frame loads and displays it.
:::row-end:::

:::row:::
    :::column:::
        ![タブとピボットのイメージ](images/nav/thumbnail-tabs-pivot.svg)
    :::column-end:::
    <span data-ttu-id="648a4-154">:::column span =「2」:::[**上部のナビゲーションとタブ**](../controls-and-patterns/navigationview.md)</span><span class="sxs-lookup"><span data-stu-id="648a4-154">:::column span="2"::: [**Top navigation and tabs**](../controls-and-patterns/navigationview.md)</span></span>

        Displays a horizontal list of links to pages at the same level. The [NavigationView](../controls-and-patterns/navigationview.md) control implements the top navigation and tabs patterns.
        
        Use top navigation when:

        - You want to show all navigation options on the screen.
        - You desire more space for your app's content.
        - Icons cannot clearly describe your navigation categories.
        
        Use tabs when:

        - You want to preserve navigation history and page state.
        - You expect users to switch between tabs frequently.

:::row-end:::

:::row:::
    :::column:::
        ![navview 画像](images/nav/thumbnail-navview.svg)
    :::column-end:::
    <span data-ttu-id="648a4-156">:::column span =「2」:::[**左側のナビゲーション**](../controls-and-patterns/navigationview.md)</span><span class="sxs-lookup"><span data-stu-id="648a4-156">:::column span="2"::: [**Left navigation**](../controls-and-patterns/navigationview.md)</span></span>

        Displays a vertical list of links to top-level pages. Use when:
        
        - The pages exist at the top level.
        - There are many navigation items (more than 5)
        - You don't expect users to switch between pages frequently.
        
:::row-end:::

:::row:::
    :::column:::
        ![マスター/詳細の画像](images/nav/thumbnail-master-detail.svg)
    :::column-end:::
    <span data-ttu-id="648a4-158">:::column span =「2」:::[**マスター/詳細**](../controls-and-patterns/master-details.md)</span><span class="sxs-lookup"><span data-stu-id="648a4-158">:::column span="2"::: [**Master/details**](../controls-and-patterns/master-details.md)</span></span>

        Displays a list (master view) of items. Selecting an item displays its corresponding page in the details section. Use when:
        
        - You expect users to switch between child items frequently.
        - You want to enable the user to perform high-level operations, such as deleting or sorting, on individual items or groups of items, and also want to enable the user to view or update the details for each item.

        Master/details is well suited for email inboxes, contact lists, and data entry.
:::row-end:::

:::row:::
    :::column:::
        ![ハイパーリンクとボタンの画像](images/nav/thumbnail-hyperlinks-buttons.svg)
    :::column-end:::
    <span data-ttu-id="648a4-160">:::column span =「2」:::[**ハイパーリンク**](../controls-and-patterns/hyperlinks.md)</span><span class="sxs-lookup"><span data-stu-id="648a4-160">:::column span="2"::: [**Hyperlinks**](../controls-and-patterns/hyperlinks.md)</span></span>

        Embedded navigation elements can appear in a page's content. Unlike other navigation elements, which should be consistent across the pages, content-embedded navigation elements are unique from page to page.
:::row-end:::

## <a name="next-add-navigation-code-to-your-app"></a><span data-ttu-id="648a4-161">次の手順: アプリにナビゲーションのコードを追加する</span><span class="sxs-lookup"><span data-stu-id="648a4-161">Next: Add navigation code to your app</span></span>

<span data-ttu-id="648a4-162">次の記事「[基本的なナビゲーションを実装する](navigate-between-two-pages.md)」では、アプリで 2 つのページ間で基本的なナビゲーションを行うための、Frame コントロールを使用するために必要なコードを示します。</span><span class="sxs-lookup"><span data-stu-id="648a4-162">The next article, [Implement basic navigation](navigate-between-two-pages.md), shows the code required to use a Frame control to enable basic navigation between two pages in your app.</span></span>