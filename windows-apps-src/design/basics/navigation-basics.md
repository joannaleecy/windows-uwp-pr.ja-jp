---
author: Jwmsft
Description: Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features.
title: UWP アプリのナビゲーションの基本
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: jimwalk
ms.date: 7/16/2018
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 82623a86548866a78f56385ee0a535bfcb822c46
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5919286"
---
# <a name="navigation-design-basics-for-uwp-apps"></a><span data-ttu-id="b6388-103">UWP アプリのナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="b6388-103">Navigation design basics for UWP apps</span></span>

![ナビゲーションの基本のヘッダー](images/nav/navigation-basics-header.jpg)

<span data-ttu-id="b6388-105">アプリをページの集まりと考えると、*ナビゲーション*は、ページ間およびページ内を移動する動作を表します。</span><span class="sxs-lookup"><span data-stu-id="b6388-105">If you think of an app as a collection of pages, *navigation* describes the act of moving between pages and within a page.</span></span> <span data-ttu-id="b6388-106">これはユーザー エクスペリエンスの出発点です。これによって、ユーザーは利用するコンテンツと機能を見つけます。</span><span class="sxs-lookup"><span data-stu-id="b6388-106">It's the starting point of the user experience, and it's how users find the content and features they're interested in.</span></span> <span data-ttu-id="b6388-107">これは非常に重要ですが、適切な設計が難しい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="b6388-107">It's very important, and it can be difficult to get right.</span></span>

<span data-ttu-id="b6388-108">ナビゲーションに関して行うことができる膨大な数の選択肢があります。</span><span class="sxs-lookup"><span data-stu-id="b6388-108">We have a huge number of choices to make for navigation.</span></span> <span data-ttu-id="b6388-109">以下を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="b6388-109">We could:</span></span>

:::row:::
    :::column:::
        ![navigation example 1](images/nav/nav-1.svg)

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

<span data-ttu-id="b6388-110">1 つのナビゲーション デザインですべてのアプリに対応することはできませんが、アプリの適切な設計を判断するための原則やガイドラインがあります。</span><span class="sxs-lookup"><span data-stu-id="b6388-110">While there's no single navigation design that works for every app, there are principles and guidelines to help you decide the right design for your app.</span></span>

## <a name="principles-of-good-navigation"></a><span data-ttu-id="b6388-111">優れたナビゲーションの原則</span><span class="sxs-lookup"><span data-stu-id="b6388-111">Principles of good navigation</span></span>

<span data-ttu-id="b6388-112">優れたナビゲーション デザインの基本原則から始めましょう。</span><span class="sxs-lookup"><span data-stu-id="b6388-112">Let's start with the basic principles of good navigation design:</span></span>

- <span data-ttu-id="b6388-113">**一貫性:** ユーザーの期待に応えます。</span><span class="sxs-lookup"><span data-stu-id="b6388-113">**Consistency:** Meet user expectations.</span></span>
- <span data-ttu-id="b6388-114">**シンプルさ:** 必要以上のことをしないようにします。</span><span class="sxs-lookup"><span data-stu-id="b6388-114">**Simplicity:** Don't do more than you need to.</span></span>
- <span data-ttu-id="b6388-115">**明確さ:** 明確なパスとオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="b6388-115">**Clarity:** Provide clear paths and options.</span></span>

### <a name="consistency"></a><span data-ttu-id="b6388-116">一貫性</span><span class="sxs-lookup"><span data-stu-id="b6388-116">Consistency</span></span>

<span data-ttu-id="b6388-117">ナビゲーションは、ユーザーの期待に沿ったものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6388-117">Navigation should be consistent with user expectations.</span></span> <span data-ttu-id="b6388-118">[標準のコントロール](#use-the-right-controls)のユーザーに精通しているとアイコンの次の規則を使用すると、場所、およびスタイル設定、ナビゲーション予測可能かつ直感的なユーザーになります。</span><span class="sxs-lookup"><span data-stu-id="b6388-118">Using [standard controls](#use-the-right-controls) that users are familiar with and following standard conventions for icons, location, and styling will make navigation predictable and intuitive for users.</span></span>

![ページ コンポーネントのイメージ](images/nav/page-components.svg)

> <span data-ttu-id="b6388-120">ユーザーは特定の UI 要素が標準の位置にあることを期待します。</span><span class="sxs-lookup"><span data-stu-id="b6388-120">Users expect to find certain UI elements in standard locations.</span></span>

### <a name="simplicity"></a><span data-ttu-id="b6388-121">シンプルさ</span><span class="sxs-lookup"><span data-stu-id="b6388-121">Simplicity</span></span>

<span data-ttu-id="b6388-122">ナビゲーション項目が少ないほど、ユーザーの意思決定がシンプルになります。</span><span class="sxs-lookup"><span data-stu-id="b6388-122">Fewer navigation items simplify decision making for users.</span></span> <span data-ttu-id="b6388-123">重要な移動先に簡単にアクセスできるようにして、重要度の低い項目を非表示にすることで、ユーザーは目的の場所にすばやく移動できるようになります。</span><span class="sxs-lookup"><span data-stu-id="b6388-123">Providing easy access to important destinations and hiding less important items will help users get where they want, faster.</span></span>

:::row:::
    :::column:::
        ![do example](images/nav/do.svg)

        ![navview good](images/nav/navview-good.svg)

        Present navigation items in a familiar navigation menu.
    :::column-end:::
    :::column:::
        ![don't example](images/nav/dont.svg)

        ![navview bad](images/nav/navview-bad.svg)

        Overwhelm users with many navigation options.
    :::column-end:::
:::row-end:::

### <a name="clarity"></a><span data-ttu-id="b6388-124">明確さ</span><span class="sxs-lookup"><span data-stu-id="b6388-124">Clarity</span></span>

<span data-ttu-id="b6388-125">明確なパスを示すと、ユーザーは論理的なナビゲーションを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="b6388-125">Clear paths allow for logical navigation for users.</span></span> <span data-ttu-id="b6388-126">ナビゲーション オプションをわかりやすくし、ページ間の関係を明確にすることで、ユーザーが自分の位置を見失うことを防止できます。</span><span class="sxs-lookup"><span data-stu-id="b6388-126">Making navigation options obvious and clarifying relationships between pages should prevent users from getting lost.</span></span>

![実行例](images/nav/clarity-image.svg)

> <span data-ttu-id="b6388-128">移動先にはわかりやすいラベルが付けられているため、ユーザーは自分の位置を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="b6388-128">Destinations are clearly labeled so users know where they are.</span></span>

## <a name="general-recommendations"></a><span data-ttu-id="b6388-129">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="b6388-129">General recommendations</span></span>

<span data-ttu-id="b6388-130">一貫性、シンプルさ、明確さという設計原則を念頭に置いて、一般的な推奨事項を作成しましょう。</span><span class="sxs-lookup"><span data-stu-id="b6388-130">Now, let's take our design principles--consistency, simplicity, and clarity--and use them to come up with some general recommendations.</span></span>

1. <span data-ttu-id="b6388-131">ユーザーのことを考えてください。</span><span class="sxs-lookup"><span data-stu-id="b6388-131">Think about your users.</span></span> <span data-ttu-id="b6388-132">アプリ使用時のユーザーの一般的な移動パスを追跡し、ページごとに、ユーザーがそのページを表示している理由と、次にどこに移動しようとしているかを考えてください。</span><span class="sxs-lookup"><span data-stu-id="b6388-132">Trace out typical paths they might take through your app, and for each page, think about why the user is there and where they might want to go.</span></span>

2. <span data-ttu-id="b6388-133">高度なナビゲーション階層を避けてください。</span><span class="sxs-lookup"><span data-stu-id="b6388-133">Avoid deep navigation hierarchies.</span></span> <span data-ttu-id="b6388-134">3 レベルを超えるナビゲーションでは、ユーザーは迷ってしまい、深い階層から抜け出せなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="b6388-134">If you go beyond three levels of navigation, you risk stranding your user in a deep hierarchy that they will have difficulty leaving.</span></span>

3. <span data-ttu-id="b6388-135">「ホッピング」を避けます。</span><span class="sxs-lookup"><span data-stu-id="b6388-135">Avoid "pogo-sticking."</span></span> <span data-ttu-id="b6388-136">ホッピングとは、関連するコンテンツに移動するために、ユーザーが上のレベルに移動して、それから下のレベルに移動する必要があるナビゲーションを意味します。</span><span class="sxs-lookup"><span data-stu-id="b6388-136">Pogo-sticking occurs when there is related content, but navigating to it requires the user to go up a level and then down again.</span></span>

## <a name="use-the-right-structure"></a><span data-ttu-id="b6388-137">適切な構造を使う</span><span class="sxs-lookup"><span data-stu-id="b6388-137">Use the right structure</span></span>

<span data-ttu-id="b6388-138">ナビゲーションの一般的な原則について説明しました。次に、アプリの構造について考えます。</span><span class="sxs-lookup"><span data-stu-id="b6388-138">Now that you're familiar with general navigation principles, how should you structure your app?</span></span> <span data-ttu-id="b6388-139">2 種類の一般的な構造があります。フラット構造と階層構造です。</span><span class="sxs-lookup"><span data-stu-id="b6388-139">There are two general structures: flat and hierarchal.</span></span>

:::row:::
    :::column:::
        ![Pages arranged in a flat structure](images/nav/flat-lateral-structure.svg)
    :::column-end:::
    :::column span="2":::
        ### Flat/lateral

        In a flat/lateral structure, pages exist side-by-side. You can go from one page to another in any order.

        We recommend using a flat structure when:

        - <span data-ttu-id="b6388-140">ページをどのような順序でも表示できる場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-140">The pages can be viewed in any order.</span></span>
        - <span data-ttu-id="b6388-141">各ページはそれぞれ異なるページであり、明確な親/子関係はありません。</span><span class="sxs-lookup"><span data-stu-id="b6388-141">The pages are clearly distinct from each other and don't have an obvious parent/child relationship.</span></span>
        - <span data-ttu-id="b6388-142">グループでは、8 より小さいページがあります。</span><span class="sxs-lookup"><span data-stu-id="b6388-142">There are less than 8 pages in the group.</span></span> <br>
        <span data-ttu-id="b6388-143">(ページ数が 8 ページ以上の場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。</span><span class="sxs-lookup"><span data-stu-id="b6388-143">(When there are more pages, it might be difficult for users to understand how the pages are unique or to understand their current location within the group.</span></span> <span data-ttu-id="b6388-144">このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。</span><span class="sxs-lookup"><span data-stu-id="b6388-144">If you don't think that's an issue for your app, go ahead and make the pages peers.</span></span> <span data-ttu-id="b6388-145">このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください。)</span><span class="sxs-lookup"><span data-stu-id="b6388-145">Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups.)</span></span>

    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![Pages arranged in a hierarchy](images/nav/hierarchical-structure.svg)
    :::column-end:::
    :::column span="2":::
        ### Hierarchical

        In a hierarchical structure, pages are organized into a tree-like structure. Each child page has one parent, but a parent can have one or more child pages. To reach a child page, you travel through the parent.

        Hierarchical structures are good for organizing complex content that spans lots of pages. The downside is some navigation overhead: the deeper the structure, the more clicks it takes to get from page to page.

        We recommend a hierarchical structure when:
        
        - <span data-ttu-id="b6388-146">特定の順序でページを移動する必要がある場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-146">Pages should be traversed in a specific order.</span></span>
        - <span data-ttu-id="b6388-147">ページ間に明白な親子関係がある場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-147">There is a clear parent-child relationship between pages.</span></span>
        - <span data-ttu-id="b6388-148">グループ内のページ数が 7 ページを超える場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-148">There are more than 7 pages in the group.</span></span>
        
    :::column-end:::
:::row-end:::

:::row:::
    :::column:::
        ![an app with a hybrid structure](images/nav/combining-structures.svg)
    :::column-end:::
    :::column span="2":::
        ### Combining structures

        You don't have choose to one structure or the other; many well-design apps use both. An app can use flat structures for top-level pages that can be viewed in any order, and hierarchical structures for pages that have more complex relationships.

        If your navigation structure has multiple levels, we recommend that peer-to-peer navigation elements only link to the peers within their current subtree. Consider the adjacent illustration, which shows a navigation structure that has two levels:

        - <span data-ttu-id="b6388-149">レベル 1 では、ピア ツー ピアのナビゲーション要素によって、ページ A、B、C、および D へのアクセスが提供されます。</span><span class="sxs-lookup"><span data-stu-id="b6388-149">At level 1, the peer-to-peer navigation element should provide access to pages A, B, C, and D.</span></span>
        - <span data-ttu-id="b6388-150">レベル 2 では、A2 ページのピア ツー ピアのナビゲーション要素は、他の A2 ページにのみリンクしています。</span><span class="sxs-lookup"><span data-stu-id="b6388-150">At level 2, the peer-to-peer navigation elements for the A2 pages should only link to the other A2 pages.</span></span> <span data-ttu-id="b6388-151">これらのナビゲーション要素は、C サブツリー内にあるレベル 2 のページにはリンクしていません。</span><span class="sxs-lookup"><span data-stu-id="b6388-151">They should not link to level 2 pages in the C subtree.</span></span>
    :::column-end:::
:::row-end:::

## <a name="use-the-right-controls"></a><span data-ttu-id="b6388-152">適切なコントロールを使用する</span><span class="sxs-lookup"><span data-stu-id="b6388-152">Use the right controls</span></span>

<span data-ttu-id="b6388-153">ページの構造を決定したら、ユーザーがページ間をどのように移動するかを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b6388-153">Once you've decided on a page structure, you need to decide how users navigate through those pages.</span></span> <span data-ttu-id="b6388-154">UWP にはさまざまなナビゲーション コントロールが用意されていて、アプリで一貫性があり信頼性が高いナビゲーション エクスペリエンスを提供するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="b6388-154">UWP provides a variety of navigation controls to help ensure a consistent, reliable navigation experience in your app.</span></span>

:::row:::
    :::column:::
        ![Frame image](images/nav/thumbnail-frame.svg)
    :::column-end:::
    :::column span="2":::
        [**Frame**](https://docs.microsoft.com/uwp/api/Windows.UI.Xaml.Controls.Frame)

        With few exceptions, any app that has multiple pages uses a frame. Typically, an app has a main page that contains the frame and a primary navigation element, such as a navigation view control. When the user selects a page, the frame loads and displays it.
:::row-end:::

:::row:::
    :::column:::
        ![tabs and pivot image](images/nav/thumbnail-tabs-pivot.svg)
    :::column-end:::
    :::column span="2":::
        [**Top navigation and tabs**](../controls-and-patterns/navigationview.md)

        Displays a horizontal list of links to pages at the same level. The [NavigationView](../controls-and-patterns/navigationview.md) control implements the top navigation and tabs patterns.
        
        Use top navigation when:

        - <span data-ttu-id="b6388-155">画面上のすべてのナビゲーション オプションを表示するには。</span><span class="sxs-lookup"><span data-stu-id="b6388-155">You want to show all navigation options on the screen.</span></span>
        - <span data-ttu-id="b6388-156">アプリのコンテンツを追加する領域を必要とします。</span><span class="sxs-lookup"><span data-stu-id="b6388-156">You desire more space for your app's content.</span></span>
        - <span data-ttu-id="b6388-157">アイコンは、ナビゲーション カテゴリを明確に記述できません。</span><span class="sxs-lookup"><span data-stu-id="b6388-157">Icons cannot clearly describe your navigation categories.</span></span>
        
        <span data-ttu-id="b6388-158">タブを使用する場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-158">Use tabs when:</span></span>

        - <span data-ttu-id="b6388-159">ナビゲーション履歴とページの状態を維持するには。</span><span class="sxs-lookup"><span data-stu-id="b6388-159">You want to preserve navigation history and page state.</span></span>
        - <span data-ttu-id="b6388-160">ユーザーがタブを頻繁に切り替えるはずです。</span><span class="sxs-lookup"><span data-stu-id="b6388-160">You expect users to switch between tabs frequently.</span></span>

:::row-end:::

:::row:::
    :::column:::
        ![navview image](images/nav/thumbnail-navview.svg)
    :::column-end:::
    :::column span="2":::
        [**Left navigation**](../controls-and-patterns/navigationview.md)

        Displays a vertical list of links to top-level pages. Use when:
        
        - <span data-ttu-id="b6388-161">ページがトップレベルに存在する場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-161">The pages exist at the top level.</span></span>
        - <span data-ttu-id="b6388-162">ナビゲーション項目 (5 個以上) が多い</span><span class="sxs-lookup"><span data-stu-id="b6388-162">There are many navigation items (more than 5)</span></span>
        - <span data-ttu-id="b6388-163">ユーザーが頻繁にページ間を切り替えることを前提としていない場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-163">You don't expect users to switch between pages frequently.</span></span>
        
:::row-end:::

:::row:::
    :::column:::
        ![Master details image](images/nav/thumbnail-master-detail.svg)
    :::column-end:::
    :::column span="2":::
        [**Master/details**](../controls-and-patterns/master-details.md)

        Displays a list (master view) of items. Selecting an item displays its corresponding page in the details section. Use when:
        
        - <span data-ttu-id="b6388-164">ユーザーが頻繁に子項目間を切り替えることを前提としている場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-164">You expect users to switch between child items frequently.</span></span>
        - <span data-ttu-id="b6388-165">ユーザーが個々の項目や項目のグループに対して高いレベルの操作 (削除や並べ替えなど) を実行できるようにする場合、およびユーザーが各項目の詳細情報の表示や更新を実行できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="b6388-165">You want to enable the user to perform high-level operations, such as deleting or sorting, on individual items or groups of items, and also want to enable the user to view or update the details for each item.</span></span>

        <span data-ttu-id="b6388-166">マスター/詳細は、メールの受信トレイ、連絡先リスト、データ入力に適しています。</span><span class="sxs-lookup"><span data-stu-id="b6388-166">Master/details is well suited for email inboxes, contact lists, and data entry.</span></span>
:::row-end:::

:::row:::
    :::column:::
        ![Hyperlinks and buttons image](images/nav/thumbnail-hyperlinks-buttons.svg)
    :::column-end:::
    :::column span="2":::
        [**Hyperlinks**](../controls-and-patterns/hyperlinks.md)

        Embedded navigation elements can appear in a page's content. Unlike other navigation elements, which should be consistent across the pages, content-embedded navigation elements are unique from page to page.
:::row-end:::

## <a name="next-add-navigation-code-to-your-app"></a><span data-ttu-id="b6388-167">次の手順: アプリにナビゲーションのコードを追加する</span><span class="sxs-lookup"><span data-stu-id="b6388-167">Next: Add navigation code to your app</span></span>

<span data-ttu-id="b6388-168">次の記事「[基本的なナビゲーションを実装する](navigate-between-two-pages.md)」では、アプリで 2 つのページ間で基本的なナビゲーションを行うための、Frame コントロールを使用するために必要なコードを示します。</span><span class="sxs-lookup"><span data-stu-id="b6388-168">The next article, [Implement basic navigation](navigate-between-two-pages.md), shows the code required to use a Frame control to enable basic navigation between two pages in your app.</span></span>