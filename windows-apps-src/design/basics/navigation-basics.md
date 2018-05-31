---
author: serenaz
Description: Navigation in Universal Windows Platform (UWP) apps is based on a flexible model of navigation structures, navigation elements, and system-level features.
title: UWP アプリのナビゲーションの基本
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: sezhen
ms.date: 11/27/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: 3edb7dc28561b5d316a908df951e3052eafc995b
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1654271"
---
# <a name="navigation-design-basics-for-uwp-apps"></a><span data-ttu-id="a7502-103">UWP アプリのナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="a7502-103">Navigation design basics for UWP apps</span></span>

<span data-ttu-id="a7502-104">アプリをページの集まりと考えると、*ナビゲーション*は、ページ間およびページ内を移動する動作を表します。</span><span class="sxs-lookup"><span data-stu-id="a7502-104">If you think of an app as a collection of pages, *navigation* describes the act of moving between pages and within a page.</span></span> <span data-ttu-id="a7502-105">これはユーザー エクスペリエンスの出発点です。これによって、ユーザーは利用するコンテンツと機能を見つけます。</span><span class="sxs-lookup"><span data-stu-id="a7502-105">It's the starting point of the user experience, and it's how users find the content and features they're interested in.</span></span> <span data-ttu-id="a7502-106">これは非常に重要ですが、適切な設計が難しい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="a7502-106">It's very important, and it can be difficult to get right.</span></span>

<span data-ttu-id="a7502-107">適切な設計が難しいのは、アプリの設計者には膨大な数の選択肢があるからです。</span><span class="sxs-lookup"><span data-stu-id="a7502-107">It's difficult because as app designers, we have a huge number of choices to make.</span></span> <span data-ttu-id="a7502-108">一連のページを順に移動するようにユーザーに求めることができます。</span><span class="sxs-lookup"><span data-stu-id="a7502-108">We could require the user to go through a series of pages in order.</span></span> <span data-ttu-id="a7502-109">または、ユーザーが任意のページに直接ジャンプできるメニューを提供することもできます。</span><span class="sxs-lookup"><span data-stu-id="a7502-109">Or we could provide a menu that allows users to jump directly to any page.</span></span> <span data-ttu-id="a7502-110">または、すべてのコンテンツを 1 つのページに配置し、フィルタリングして表示するメカニズムを提供することも可能です。</span><span class="sxs-lookup"><span data-stu-id="a7502-110">Or we could put everything on a single page and provide filtering mechanisms for viewing content.</span></span>
 
<span data-ttu-id="a7502-111">1 つのナビゲーション デザインですべてのアプリに対応することはできませんが、アプリの適切な設計を判断するための原則やガイドラインがあります。</span><span class="sxs-lookup"><span data-stu-id="a7502-111">While there's no single navigation design that works for every app, there are principles and guidelines to help you decide the right design for your app.</span></span> 

<figure class="wdg-figure">
  <img alt="Navigation diagram for an app" src="images/navigation_diagram.png" />
  <figcaption><span data-ttu-id="a7502-112">アプリのナビゲーションの図。</span><span class="sxs-lookup"><span data-stu-id="a7502-112">Diagram of an app's navigation.</span></span></figcaption>
</figure> 

## <a name="principles-of-good-navigation"></a><span data-ttu-id="a7502-113">優れたナビゲーションの原則</span><span class="sxs-lookup"><span data-stu-id="a7502-113">Principles of good navigation</span></span>
<span data-ttu-id="a7502-114">優れたナビゲーション デザインの基本原則から始めましょう。</span><span class="sxs-lookup"><span data-stu-id="a7502-114">Let's start with the basic principles of good navigation design:</span></span> 

* <span data-ttu-id="a7502-115">一貫性: ユーザーの期待に応えます。</span><span class="sxs-lookup"><span data-stu-id="a7502-115">Consistency: Meet user expectations.</span></span>
* <span data-ttu-id="a7502-116">シンプルさ: 必要以上のことをしないようにします。</span><span class="sxs-lookup"><span data-stu-id="a7502-116">Simplicity: Don't do more than you need to.</span></span>
* <span data-ttu-id="a7502-117">明確さ: 明確なパスとオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="a7502-117">Clarity: Provide clear paths and options.</span></span>

### <a name="consistency"></a><span data-ttu-id="a7502-118">一貫性</span><span class="sxs-lookup"><span data-stu-id="a7502-118">Consistency</span></span>
<span data-ttu-id="a7502-119">ナビゲーションは、ユーザーの期待に沿ったものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7502-119">Navigation should be consistent with user expectations.</span></span> <span data-ttu-id="a7502-120">ユーザーが使い慣れた[標準コントロール](#use-the-right-controls)を使用し、アイコン、場所、スタイルの標準的な規則に従うことで、ナビゲーションがユーザーにとって直感的で予測可能なものになります。</span><span class="sxs-lookup"><span data-stu-id="a7502-120">Using [standard controls](#use-the-right-controls) that users are familiar with and following standard conventions for icons, location, and styling will make navigation predictable and intuative for users.</span></span>

<figure class="wdg-figure">
<img src="images/nav/nav-component-layout.png" alt="Preferred location for navigation elements"/>
  <figcaption><span data-ttu-id="a7502-121">ユーザーは特定の UI 要素が標準の位置にあることを期待します。</span><span class="sxs-lookup"><span data-stu-id="a7502-121">Users expect to find certain UI elements in standard locations.</span></span></figcaption>
</figure> 

### <a name="simplicity"></a><span data-ttu-id="a7502-122">シンプルさ</span><span class="sxs-lookup"><span data-stu-id="a7502-122">Simplicity</span></span>
<span data-ttu-id="a7502-123">ナビゲーション項目が少ないほど、ユーザーの意思決定がシンプルになります。</span><span class="sxs-lookup"><span data-stu-id="a7502-123">Fewer navigation items simplify decision making for users.</span></span> <span data-ttu-id="a7502-124">重要な移動先に簡単にアクセスできるようにして、重要度の低い項目を非表示にすることで、ユーザーは目的の場所にすばやく移動できるようになります。</span><span class="sxs-lookup"><span data-stu-id="a7502-124">Providing easy access to important destinations and hiding less important items will help users get where they want, faster.</span></span>

<figure class="wdg-figure">
<img src="images/nav/nav-simple-menus.png" alt="A simple versus a complex menu"/>
  <figcaption> <span data-ttu-id="a7502-125">左側のメニューは項目が少ないため、ユーザーにとって理解しやすく、利用しやすいメニューです。</span><span class="sxs-lookup"><span data-stu-id="a7502-125">The menu on the left will be easier for users to understand and utilize because there are less items.</span></span>
</figcaption>
</figure> 

### <a name="clarity"></a><span data-ttu-id="a7502-126">明確さ</span><span class="sxs-lookup"><span data-stu-id="a7502-126">Clarity</span></span>
<span data-ttu-id="a7502-127">明確なパスを示すと、ユーザーは論理的なナビゲーションを行うことができます。</span><span class="sxs-lookup"><span data-stu-id="a7502-127">Clear paths allow for logical navigation for users.</span></span> <span data-ttu-id="a7502-128">ナビゲーション オプションをわかりやすくし、ページ間の関係を明確にすることで、ユーザーが自分の位置を見失うことを防止できます。</span><span class="sxs-lookup"><span data-stu-id="a7502-128">Making navigation options obvious and clarifying relationships between pages should prevent users from getting lost.</span></span>

<figure class="wdg-figure">
<img src="images/nav/nav-pages.png" alt="Clear paths and destinations"/>
  <figcaption> <span data-ttu-id="a7502-129">移動先にはわかりやすいラベルが付けられているため、ユーザーは自分の位置を知ることができます。</span><span class="sxs-lookup"><span data-stu-id="a7502-129">Destinations are clearly labeled so users know where they are.</span></span>
</figcaption>
</figure> 

## <a name="general-recommendations"></a><span data-ttu-id="a7502-130">一般的な推奨事項</span><span class="sxs-lookup"><span data-stu-id="a7502-130">General recommendations</span></span>
<span data-ttu-id="a7502-131">一貫性、シンプルさ、明確さという設計原則を念頭に置いて、一般的な推奨事項を作成しましょう。</span><span class="sxs-lookup"><span data-stu-id="a7502-131">Now, let's take our design principles--consistency, simplicity, and clarity--and use them to come up with some general recommendations.</span></span>

1. <span data-ttu-id="a7502-132">ユーザーのことを考えてください。</span><span class="sxs-lookup"><span data-stu-id="a7502-132">Think about your users.</span></span> <span data-ttu-id="a7502-133">アプリ使用時のユーザーの一般的な移動パスを追跡し、ページごとに、ユーザーがそのページを表示している理由と、次にどこに移動しようとしているかを考えてください。</span><span class="sxs-lookup"><span data-stu-id="a7502-133">Trace out typical paths they might take through your app, and for each page, think about why the user is there and where they might want to go.</span></span> 

2. <span data-ttu-id="a7502-134">ナビゲーションの深い階層を避けます。</span><span class="sxs-lookup"><span data-stu-id="a7502-134">Avoid deep navigational hierarchies.</span></span> <span data-ttu-id="a7502-135">3 レベルを超えるナビゲーションでは、ユーザーは迷ってしまい、深い階層から抜け出せなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a7502-135">If you go beyond three levels of navigation, you risk stranding your user in a deep hierarchy that they will have difficulty leaving.</span></span>

3. <span data-ttu-id="a7502-136">「ホッピング」を避けます。</span><span class="sxs-lookup"><span data-stu-id="a7502-136">Avoid "pogo-sticking."</span></span> <span data-ttu-id="a7502-137">ホッピングとは、関連するコンテンツに移動するために、ユーザーが上のレベルに移動して、それから下のレベルに移動する必要があるナビゲーションを意味します。</span><span class="sxs-lookup"><span data-stu-id="a7502-137">Pogo-sticking occurs when there is related content, but navigating to it requires the user to go up a level and then down again.</span></span>

## <a name="use-the-right-structure"></a><span data-ttu-id="a7502-138">適切な構造を使う</span><span class="sxs-lookup"><span data-stu-id="a7502-138">Use the right structure</span></span> 
<span data-ttu-id="a7502-139">ナビゲーションの一般的な原則について説明しました。次に、アプリの構造について考えます。</span><span class="sxs-lookup"><span data-stu-id="a7502-139">Now that you're familiar with general navigation principles, how should you structure your app?</span></span> <span data-ttu-id="a7502-140">2 種類の一般的な構造があります。フラット構造と階層構造です。</span><span class="sxs-lookup"><span data-stu-id="a7502-140">There are two general structures: flat and hierarchal.</span></span> 

### <a name="flatlateral"></a><span data-ttu-id="a7502-141">フラット構造/水平構造</span><span class="sxs-lookup"><span data-stu-id="a7502-141">Flat/lateral</span></span>
![フラット構造で配置されたページ](images/nav/nav-pages-peer.png)

<span data-ttu-id="a7502-143">フラット構造/水平構造では、ページは横方向に存在します。</span><span class="sxs-lookup"><span data-stu-id="a7502-143">In a flat/lateral structure, pages exist side-by-side.</span></span> <span data-ttu-id="a7502-144">どのような順序でもページ間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="a7502-144">You can go from on page to another in any order.</span></span> 

<span data-ttu-id="a7502-145">次のような場合に、フラット構造の使用を推奨します。</span><span class="sxs-lookup"><span data-stu-id="a7502-145">We recommend using a flat structure when:</span></span> 
<ul>
<li><span data-ttu-id="a7502-146">ページをどのような順序でも表示できる場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-146">The pages can be viewed in any order.</span></span></li>
<li><span data-ttu-id="a7502-147">各ページはそれぞれ異なるページであり、明確な親/子関係がない場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-147">The pages are clearly distinct from each other and don't have an obvious parent/child relationship.</span></span></li>
<li><span data-ttu-id="a7502-148">グループ内のページ数が 8 ページよりも少ない場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-148">There are fewer than 8 pages in the group.</span></span><br/>
<span data-ttu-id="a7502-149">(ページ数が 8 ページ以上の場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。</span><span class="sxs-lookup"><span data-stu-id="a7502-149">(When there are more pages, it might be difficult for users to understand how the pages are unique or to understand their current location within the group.</span></span> <span data-ttu-id="a7502-150">このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。</span><span class="sxs-lookup"><span data-stu-id="a7502-150">If you don't think that's an issue for your app, go ahead and make the pages peers.</span></span> <span data-ttu-id="a7502-151">このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください。)</span><span class="sxs-lookup"><span data-stu-id="a7502-151">Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups.)</span></span></li>
</ul>

### <a name="hierarchical"></a><span data-ttu-id="a7502-152">階層構造</span><span class="sxs-lookup"><span data-stu-id="a7502-152">Hierarchical</span></span>
![階層構造で配置されたページ](images/nav/nav-pages-hiearchy.png)

<span data-ttu-id="a7502-154">階層構造では、ページはツリー状の構造に配置されています。</span><span class="sxs-lookup"><span data-stu-id="a7502-154">In a hierarchical structure, pages are organized into a tree-like structure.</span></span> <span data-ttu-id="a7502-155">それぞれの子ページの親は 1 つですが、親ページは 1 つ以上の子ページを持つことができます。</span><span class="sxs-lookup"><span data-stu-id="a7502-155">Each child page has one parent, but a parent can have one or more child pages.</span></span> <span data-ttu-id="a7502-156">子ページにアクセスするには、親ページを経由します。</span><span class="sxs-lookup"><span data-stu-id="a7502-156">To reach a child page, you travel through the parent.</span></span>

<span data-ttu-id="a7502-157">階層構造体は、多数のページにわたる複雑なコンテンツを配置する場合に適してします。</span><span class="sxs-lookup"><span data-stu-id="a7502-157">Hierarchical structures are good for organizing complex content that spans lots of pages.</span></span> <span data-ttu-id="a7502-158">欠点は、ナビゲーションのオーバーヘッドが発生することです。階層が深くなると、ページからページへの移動するために、多くのクリックが必要となります。</span><span class="sxs-lookup"><span data-stu-id="a7502-158">The downside is some navigation overhead: the deeper the structure, the more clicks it takes to get from page to page.</span></span> 

<span data-ttu-id="a7502-159">次のような場合に、階層構造の使用を推奨します。</span><span class="sxs-lookup"><span data-stu-id="a7502-159">We recommend a hiearchical structure when:</span></span> 
<ul>
<li><span data-ttu-id="a7502-160">特定の順序でページを移動する必要がある場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-160">Pages should be traversed in a specific order.</span></span></li>
<li><span data-ttu-id="a7502-161">ページ間に明白な親子関係がある場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-161">There is a clear parent-child relationship between pages.</span></span></li>
<li><span data-ttu-id="a7502-162">グループ内のページ数が 7 ページを超える場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-162">There are more than 7 pages in the group.</span></span></li>
</ul>

### <a name="combining-structures"></a><span data-ttu-id="a7502-163">構造を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="a7502-163">Combining structures</span></span>
![ハイブリッド構造のアプリ](images/nav/nav-hybridstructure.png.png)

<span data-ttu-id="a7502-165">1 つの構造のみを選択する必要はありません。優れた設計のアプリの多くは両方を使用しています。</span><span class="sxs-lookup"><span data-stu-id="a7502-165">You don't have choose one structure or the other; many well-design apps use both.</span></span> <span data-ttu-id="a7502-166">アプリでは、トップレベルのページにはフラット構造を使って、任意の順序で参照できるようにし、複雑な関係のあるページには階層構造を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="a7502-166">An app can use flat structures for top-level pages that can be viewed in any order, and hierarchical structures for pages that have more complex relationships.</span></span> 

<span data-ttu-id="a7502-167">ナビゲーション構造に複数のレベルがある場合は、現在のサブツリー内のピアにのみリンクするピア ツー ピアのナビゲーション要素を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7502-167">If your navigation structure has multiple levels, we recommend that peer-to-peer navigation elements only link to the peers within their current subtree.</span></span> <span data-ttu-id="a7502-168">3 つのレベルを持つナビゲーション構造を示す、次の図について考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="a7502-168">Consider the following illustration, which shows a navigation structure that has three levels:</span></span>

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees.png)
- <span data-ttu-id="a7502-170">レベル 1 では、ピア ツー ピアのナビゲーション要素によって、ページ A、B、C、および D へのアクセスが提供されます。</span><span class="sxs-lookup"><span data-stu-id="a7502-170">At level 1, the peer-to-peer navigation element should provide access to pages A, B, C, and D.</span></span>
- <span data-ttu-id="a7502-171">レベル 2 では、A2 ページのピア ツー ピアのナビゲーション要素は、他の A2 ページにのみリンクしています。</span><span class="sxs-lookup"><span data-stu-id="a7502-171">At level 2, the peer-to-peer navigation elements for the A2 pages should only link to the other A2 pages.</span></span> <span data-ttu-id="a7502-172">これらのナビゲーション要素は、C サブツリー内にあるレベル 2 のページにはリンクしていません。</span><span class="sxs-lookup"><span data-stu-id="a7502-172">They should not link to level 2 pages in the C subtree.</span></span>

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees2.png)

## <a name="use-the-right-controls"></a><span data-ttu-id="a7502-174">適切なコントロールを使用する</span><span class="sxs-lookup"><span data-stu-id="a7502-174">Use the right controls</span></span>
<span data-ttu-id="a7502-175">ページの構造を決定したら、ユーザーがページ間をどのように移動するかを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a7502-175">Once you've decided on a page structure, you need to decide how users navigate through those pages.</span></span> <span data-ttu-id="a7502-176">UWP にはさまざまなナビゲーション コントロールが用意されていて、アプリで一貫性があり信頼性が高いナビゲーション エクスペリエンスを提供するために役立ちます。</span><span class="sxs-lookup"><span data-stu-id="a7502-176">UWP provides a variety of navigation controls to help ensure a consistent, reliable navigation experience in your app.</span></span> 

<span data-ttu-id="a7502-177">アプリのナビゲーション要素の数に基づいてナビゲーション コントロールを選択することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a7502-177">We recommend selecting a navigation control based on the number of navigation elements in your app.</span></span> <span data-ttu-id="a7502-178">ナビゲーション項目が 5 個以下の場合は、[タブとピボット](../controls-and-patterns/tabs-pivot.md)などのトップレベルのナビゲーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="a7502-178">If you have five or less navigation items, then use top-level navigation, like [tabs and pivot](../controls-and-patterns/tabs-pivot.md).</span></span> <span data-ttu-id="a7502-179">ナビゲーション項目が 6 個以上ある場合は、[ナビゲーション ビュー](../controls-and-patterns/navigationview.md)や[マスター/詳細](../controls-and-patterns/master-details.md)などの左側のナビゲーションを使用します。</span><span class="sxs-lookup"><span data-stu-id="a7502-179">If you have six or more navigation items, then use left navigation, like [navigation view](../controls-and-patterns/navigationview.md) or [master/details](../controls-and-patterns/master-details.md).</span></span>

<div class="mx-responsive-img">

<table>
<tr>
    <th><span data-ttu-id="a7502-180">コントロール</span><span class="sxs-lookup"><span data-stu-id="a7502-180">Control</span></span></th>
    <th><span data-ttu-id="a7502-181">説明</span><span class="sxs-lookup"><span data-stu-id="a7502-181">Description</span></span></th>
</tr>
<tr>
    <td><a href="https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Frame"><span data-ttu-id="a7502-182">フレーム</span><span class="sxs-lookup"><span data-stu-id="a7502-182">Frame</span></span></a><br/><br/>
    <img src="images/frame.png" alt="Frame" /></td>
    <td><span data-ttu-id="a7502-183">ページを表示します。</span><span class="sxs-lookup"><span data-stu-id="a7502-183">Displays pages.</span></span> <p><span data-ttu-id="a7502-184">少数の例外を除き、複数のページがあるアプリではフレームを使用します。</span><span class="sxs-lookup"><span data-stu-id="a7502-184">With few exceptions, any app that has multiple pages uses a frame.</span></span> <span data-ttu-id="a7502-185">通常、アプリにはフレームと、ナビゲーション ビュー コントロールなどの主要なナビゲーション要素を含むメイン ページがあります。</span><span class="sxs-lookup"><span data-stu-id="a7502-185">Typically, an app has a main page that contains the frame and a primary navigation element, such as a navigation view control.</span></span> <span data-ttu-id="a7502-186">ユーザーがページを選択すると、フレームがページを読み込んで表示します。</span><span class="sxs-lookup"><span data-stu-id="a7502-186">When the user selects a page, the frame loads and displays it.</span></span></p></td>
</tr>
<tr>
    <td><a href="../controls-and-patterns/tabs-pivot.md"><span data-ttu-id="a7502-187">タブとピボット</span><span class="sxs-lookup"><span data-stu-id="a7502-187">Tabs and pivot</span></span></a><br/><br/>
    <img src="images/nav/nav-tabs-sm-300.png" alt="Tab-based navigation" /></td>
    <td><span data-ttu-id="a7502-188">同じレベルにあるページへのリンクの横方向の一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="a7502-188">Displays a horizontal list of links to pages at the same level.</span></span>
<p><span data-ttu-id="a7502-189">次の場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="a7502-189">Use when:</span></span></p>
<ul>
<li><span data-ttu-id="a7502-190">ページ数が 2 ～ 5 ページの場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-190">There are 2-5 pages.</span></span> <span data-ttu-id="a7502-191">5 ページを超える場合でもタブ/ピボットを使うことはできますが、すべてのタブ/ピボットを画面に収めることが難しくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="a7502-191">(You can use tabs/pivots when there are more than 5 pages, but it might be difficult to fit all the tabs/pivots on the screen.)</span></span></li>
<li><span data-ttu-id="a7502-192">ユーザーが頻繁にページ間を切り替えることを前提としている場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-192">You expect users to switch between pages frequently.</span></span></li>
</ul></td>
</tr>
<tr>
    <td><a href="../controls-and-patterns/navigationview.md"><span data-ttu-id="a7502-193">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="a7502-193">Navigation view</span></span></a><br/><br/>
    <img src="images/nav/nav-navpane-4page-thumb.png" alt="A navigation pane" /></td>
    <td><span data-ttu-id="a7502-194">トップレベルのページへのリンクの縦方向の一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="a7502-194">Displays a vertical list of links to top-level pages.</span></span>
<p><span data-ttu-id="a7502-195">次の場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="a7502-195">Use when:</span></span></p>
<ul>
<li><span data-ttu-id="a7502-196">ページがトップレベルに存在する場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-196">The pages exist at the top level.</span></span></li>
<li><span data-ttu-id="a7502-197">ナビゲーション項目が多い場合 (5 個以上)。</span><span class="sxs-lookup"><span data-stu-id="a7502-197">There are many navigational items (more than 5).</span></span></li>
<li><span data-ttu-id="a7502-198">ユーザーが頻繁にページ間を切り替えることを前提としていない場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-198">You don't expect users to switch between pages frequently.</span></span></li>

</ul></td>
</tr>
<tr>
<td><a href="../controls-and-patterns/master-details.md"><span data-ttu-id="a7502-199">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="a7502-199">Master/details</span></span></a><br/><br/>
<img src="images/higsecone-masterdetail-thumb.png" alt="Master/details" /></td>
<td><span data-ttu-id="a7502-200">項目の一覧 (マスター ビュー) を表示します。</span><span class="sxs-lookup"><span data-stu-id="a7502-200">Displays a list (master view) of items.</span></span> <span data-ttu-id="a7502-201">項目を選ぶと、対応するページが詳細セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7502-201">Selecting an item displays its corresponding page in the details section.</span></span>
<p><span data-ttu-id="a7502-202">次の場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="a7502-202">Use when:</span></span></p>
<ul>
<li><span data-ttu-id="a7502-203">ユーザーが頻繁に子項目間を切り替えることを前提としている場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-203">You expect users to switch between child items frequently.</span></span></li>
<li><span data-ttu-id="a7502-204">ユーザーが個々の項目や項目のグループに対して高いレベルの操作 (削除や並べ替えなど) を実行できるようにする場合、およびユーザーが各項目の詳細情報の表示や更新を実行できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-204">You want to enable the user to perform high-level operations, such as deleting or sorting, on individual items or groups of items, and also want to enable the user to view or update the details for each item.</span></span></li>
</ul>
<p><span data-ttu-id="a7502-205">マスター/詳細は、メールの受信トレイ、連絡先リスト、データ入力に適しています。</span><span class="sxs-lookup"><span data-stu-id="a7502-205">Master/details is well suited for email inboxes, contact lists, and data entry.</span></span></p>
</td>
<tr>
<td><a href="../controls-and-patterns/hub.md"><span data-ttu-id="a7502-206">ハブ</span><span class="sxs-lookup"><span data-stu-id="a7502-206">Hub</span></span></a><br/><br/>
<img src="images/hub.png" alt="Hub" /></td>
<td> <span data-ttu-id="a7502-207">順序付けされた項目のセクションをグリッドに表示します。</span><span class="sxs-lookup"><span data-stu-id="a7502-207">Displays sections of ordered items in grids.</span></span> 
<p><span data-ttu-id="a7502-208">次の場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="a7502-208">Use when:</span></span></p>
<ul>
<li><span data-ttu-id="a7502-209">ヒーロー画像が含まれる視覚的ナビゲーションを作成する場合。</span><span class="sxs-lookup"><span data-stu-id="a7502-209">You want to create visual navigation with hero images.</span></span></li>
</ul>
<p><span data-ttu-id="a7502-210">ハブは、閲覧、表示、または購入エクスペリエンスに適しています。</span><span class="sxs-lookup"><span data-stu-id="a7502-210">Hubs are well suited for browsing, viewing, or purchasing experiences.</span></span></p>
</td>
</tr>
<tr>
<td><span data-ttu-id="a7502-211"><a href="../controls-and-patterns/hyperlinks.md">ハイパーリンク</a>と<a href="../controls-and-patterns/buttons.md">ボタン</a></span><span class="sxs-lookup"><span data-stu-id="a7502-211"><a href="../controls-and-patterns/hyperlinks.md">Hyperlinks</a> and <a href="../controls-and-patterns/buttons.md">buttons</a></span></span></td>
<td> <span data-ttu-id="a7502-212">埋め込まれたナビゲーション要素は、ページのコンテンツに表示されます。</span><span class="sxs-lookup"><span data-stu-id="a7502-212">Embedded navigation elements can appear in a page's content.</span></span> <span data-ttu-id="a7502-213">他のナビゲーション要素はページの全体で一貫性がありますが、それとは異なり、コンテンツに埋め込まれたナビゲーション要素はそれぞれのページに固有のナビゲーション要素です。</span><span class="sxs-lookup"><span data-stu-id="a7502-213">Unlike other navigation elements, which should be consistent across the pages, content-embedded navigation elements are unique from page to page.</span></span></td>
</tr>
</table>
</div>

## <a name="next-add-navigation-code-to-your-app"></a><span data-ttu-id="a7502-214">次の手順: アプリにナビゲーションのコードを追加する</span><span class="sxs-lookup"><span data-stu-id="a7502-214">Next: Add navigation code to your app</span></span>
<span data-ttu-id="a7502-215">次の記事「[基本的なナビゲーションを実装する](navigate-between-two-pages.md)」では、アプリで 2 つのページ間で基本的なナビゲーションを行うための、Frame コントロールを使用するために必要なコードを示します。</span><span class="sxs-lookup"><span data-stu-id="a7502-215">The next article, [Implement basic navigation](navigate-between-two-pages.md), shows the code required to use a Frame control to enable basic navigation between two pages in your app.</span></span> 