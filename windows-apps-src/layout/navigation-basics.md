---
author: mijacobs
Description: "ユニバーサル Windows プラットフォーム (UWP) アプリのナビゲーションは、ナビゲーション構造、ナビゲーション要素、システム レベルの機能から成る柔軟なモデルに基づいています。"
title: "UWP アプリのナビゲーションの基本"
ms.assetid: B65D33BA-AAFE-434D-B6D5-1A0C49F59664
label: Navigation design basics
template: detail.hbs
op-migration-status: ready
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP"
ms.openlocfilehash: a944e02ea116c0e054918397d9d46d366d43622a
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="navigation-design-basics-for-uwp-apps"></a><span data-ttu-id="cc097-104">UWP アプリのナビゲーション デザインの基本</span><span class="sxs-lookup"><span data-stu-id="cc097-104">Navigation design basics for UWP apps</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="cc097-105">アプリをページの集まりと考えると、*ナビゲーション*という言葉は、ページ間およびページ内を移動する動作を表します。</span><span class="sxs-lookup"><span data-stu-id="cc097-105">If you think of an app as a collection of pages, the term *navigation* describes the act of moving between pages and within the page.</span></span> <span data-ttu-id="cc097-106">これはユーザー エクスペリエンスの出発点です。</span><span class="sxs-lookup"><span data-stu-id="cc097-106">It's the starting point of the user experience.</span></span> <span data-ttu-id="cc097-107">これによってユーザーは、利用するコンテンツと機能を見つけます。</span><span class="sxs-lookup"><span data-stu-id="cc097-107">It's how users find the content and features they're interested in.</span></span> <span data-ttu-id="cc097-108">これは非常に重要ですが、適切な設計が難しい場合もあります。</span><span class="sxs-lookup"><span data-stu-id="cc097-108">It's very important, and it can be difficult to get right.</span></span> 

> <span data-ttu-id="cc097-109">**重要な API**: [Frame クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Frame)、[Pivot クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Pivot)、[NavigationView クラス](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.NavigationView)</span><span class="sxs-lookup"><span data-stu-id="cc097-109">**Important APIs**: [Frame](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Frame), [Pivot class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Pivot), [NavigationView class](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.NavigationView)</span></span>

<span data-ttu-id="cc097-110">適切な設計が難しい理由の 1 つは、アプリの設計者には膨大な数の選択肢があることです。</span><span class="sxs-lookup"><span data-stu-id="cc097-110">Part of the reason it's difficult to get right is that, as app designers, we have a huge number of choices to make.</span></span> <span data-ttu-id="cc097-111">たとえば書籍を設計する場合であれば、選択肢はシンプルで、各章の順序を設計すれば済みます。</span><span class="sxs-lookup"><span data-stu-id="cc097-111">If we were designing a book, our choices would be simple: what order do the chapters go in.</span></span> <span data-ttu-id="cc097-112">アプリの場合は、書籍に例えるなら、ユーザーが順に移動するように、一連のページのナビゲーションを作成することも可能です。</span><span class="sxs-lookup"><span data-stu-id="cc097-112">With an app, we can create a navigation experience that mimics a book, requiring the user to go through a series of pages in order.</span></span> <span data-ttu-id="cc097-113">または、ユーザーが必要なページに直接移動できるメニューを提供することも可能ですが、多数のページがある場合には、ユーザーを混乱させることになります。</span><span class="sxs-lookup"><span data-stu-id="cc097-113">Or we could provide a menu that lets the user jump directly to any page he or she wants--but if we have too many pages, we might overwhelm the user with choices.</span></span> <span data-ttu-id="cc097-114">または、すべてのコンテンツを 1 つのページに配置し、フィルタリングして表示するメカニズムを提供することも可能です。</span><span class="sxs-lookup"><span data-stu-id="cc097-114">Or we could put everything on a single page and provide filtering mechanisms for viewing content.</span></span> 

<span data-ttu-id="cc097-115">1 つのナビゲーション デザインですべてのアプリに対応することはできませんが、アプリの適切な設計を行うための、いくつかの原則やガイドラインがあります。</span><span class="sxs-lookup"><span data-stu-id="cc097-115">While there's no single navigation design that works for every app, there are a set of principles and guidelines you can follow to help you figure out the right design for your app.</span></span> 

## <a name="principles-of-good-design"></a><span data-ttu-id="cc097-116">優れた設計の原則</span><span class="sxs-lookup"><span data-stu-id="cc097-116">Principles of good design</span></span> 
<span data-ttu-id="cc097-117">優れたナビゲーション デザインの基盤を作成するための、基本的な原則から始めましょう。調査によると、次のような原則が重要です。</span><span class="sxs-lookup"><span data-stu-id="cc097-117">Let's start with the basic principles that research has shown form the foundation of good navigation design:</span></span> 

* <span data-ttu-id="cc097-118">一貫性を保ちます。ユーザーの期待に応えます。</span><span class="sxs-lookup"><span data-stu-id="cc097-118">Be consistent: Meet user expectations.</span></span>
* <span data-ttu-id="cc097-119">シンプルにします。必要以上のことをしないようにします。</span><span class="sxs-lookup"><span data-stu-id="cc097-119">Keep it simple: Don't do more than you need to.</span></span>
* <span data-ttu-id="cc097-120">クリーンにします。ナビゲーション機能がユーザーを妨げないようにします。</span><span class="sxs-lookup"><span data-stu-id="cc097-120">Keep it clean: Don't let navigation features get in the user's way.</span></span>

### <a name="be-consistent"></a><span data-ttu-id="cc097-121">一貫性を保つ</span><span class="sxs-lookup"><span data-stu-id="cc097-121">Be consistent</span></span> 
<span data-ttu-id="cc097-122">ナビゲーションは、ユーザーの期待に沿ったものであり、アイコン、位置、スタイルなどの標準規則に沿ったものである必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-122">Navigation should be consistent with user expectations, leaning on standard conventions  for icons, location and styling.</span></span> 

<span data-ttu-id="cc097-123">たとえば、次の図では、ユーザーが通常、ナビゲーション ウィンドウやコマンド バーなどの機能があると期待する場所を示しています。</span><span class="sxs-lookup"><span data-stu-id="cc097-123">For example, in the following illustration, you can see the spots where users will typically expect to find functionality, like the navigation pane and command bar.</span></span> <span data-ttu-id="cc097-124">デバイス ファミリによって、ナビゲーション要素には独自の規則があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-124">Different device families have their own conventions for navigational elements.</span></span> <span data-ttu-id="cc097-125">たとえば、ナビゲーション ウィンドウは、タブレットでは通常、画面の左側に表示されますが、モバイル デバイスでは画面の上部に表示されます。</span><span class="sxs-lookup"><span data-stu-id="cc097-125">For example,  the navigation pane typically appears on the left side of the screen for tablets, but up top for mobile devices.</span></span>

<figure class="wdg-figure">
  ![推奨されるナビゲーション要素の位置](images/nav/nav-component-layout.png)
  <figcaption><span data-ttu-id="cc097-127">ユーザーは特定の UI 要素が標準の位置にあることを期待します。</span><span class="sxs-lookup"><span data-stu-id="cc097-127">Users expect to find certain UI elements in standard locations.</span></span></figcaption>
</figure> 

### <a name="keep-it-simple"></a><span data-ttu-id="cc097-128">シンプルにする</span><span class="sxs-lookup"><span data-stu-id="cc097-128">Keep it simple</span></span>
<span data-ttu-id="cc097-129">ナビゲーション デザインでもう 1 つの重要な要素は、Hick-Hyman の法則です。これは多くの場合、ナビゲーションの選択肢に関して当てはまります。</span><span class="sxs-lookup"><span data-stu-id="cc097-129">Another important factor in navigation design is the Hick-Hyman Law, often cited in relation to navigational options.</span></span> <span data-ttu-id="cc097-130">この法則によると、メニューにはなるべく少ない選択肢を含むことが推奨されます。</span><span class="sxs-lookup"><span data-stu-id="cc097-130">This law encourages us to add fewer options to the menu.</span></span> <span data-ttu-id="cc097-131">選択肢が多いほど、ユーザーの操作に時間がかかります。ユーザーが新しいアプリを使う場合には、特に当てはまります。</span><span class="sxs-lookup"><span data-stu-id="cc097-131">The more options there are, the slower user interactions with them will be, particularly when users are exploring a new app.</span></span> 

<figure class="wdg-figure">
  ![シンプルなメニューと複雑なメニュー](images/nav/nav-simple-menus.png)
  <figcaption> <span data-ttu-id="cc097-133">左側の例では、ユーザーが選ぶ選択肢が少なく、右側の例では、多数の選択肢があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-133">On the left, notice there are fewer options for the  user to select, whereas on the right, there are several.</span></span> <span data-ttu-id="cc097-134">Hick-Hyman の法則によると、左側のメニューはユーザーにとって、より理解しやすく、利用しやすいメニューです。</span><span class="sxs-lookup"><span data-stu-id="cc097-134">The  Hick-Hyman Law indicates that the menu on the left will be  easier for users to understand and utilize.</span></span>
</figcaption>
</figure> 

### <a name="keep-it-clean"></a><span data-ttu-id="cc097-135">クリーンにする</span><span class="sxs-lookup"><span data-stu-id="cc097-135">Keep it clean</span></span>
<span data-ttu-id="cc097-136">ナビゲーションに必要な最後の特徴は、さまざまな場合のナビゲーションの物理的な操作における、クリーンな操作です。</span><span class="sxs-lookup"><span data-stu-id="cc097-136">The final key characteristic of navigation is clean interaction, which refers to the physical way that users interact with navigation across a variety of contexts.</span></span> <span data-ttu-id="cc097-137">これについては、ユーザーの立場に立って、自分のデザインを見直してみる必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-137">This is one area where putting yourself in the users position will inform your design.</span></span> <span data-ttu-id="cc097-138">ユーザーとその動作を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-138">Try to understand your user and their behaviors.</span></span> <span data-ttu-id="cc097-139">たとえば、料理アプリを設計している場合、買い物リストやタイマーへの簡単なアクセスの提供を検討することができます。</span><span class="sxs-lookup"><span data-stu-id="cc097-139">For example, if you're designing a cooking app, you might consider providing easy access to a shopping list and a timer.</span></span> 

## <a name="three-general-rules"></a><span data-ttu-id="cc097-140">一般的な 3 つの規則</span><span class="sxs-lookup"><span data-stu-id="cc097-140">Three general rules</span></span>
<span data-ttu-id="cc097-141">一貫性、シンプル、クリーンという設計原則を念頭に置いて、一般的な規則を作成します。</span><span class="sxs-lookup"><span data-stu-id="cc097-141">Now lets take our design principles--consistency, simplicity, and clean interaction--and use them to come up with some general rules.</span></span> <span data-ttu-id="cc097-142">これらを出発点として利用し、必要に応じて調整することを推奨します。</span><span class="sxs-lookup"><span data-stu-id="cc097-142">As with any rule of thumb, use them as starting points and tweak as needed.</span></span> 

1. <span data-ttu-id="cc097-143">ナビゲーションの深い階層を避けます。</span><span class="sxs-lookup"><span data-stu-id="cc097-143">Avoid deep navigational hierarchies.</span></span> <span data-ttu-id="cc097-144">ユーザーに最適なナビゲーションのレベルの数はどれだけでしょうか。</span><span class="sxs-lookup"><span data-stu-id="cc097-144">How many levels of navigation are best for your users?</span></span> <span data-ttu-id="cc097-145">トップレベルのナビゲーションと、その下に 1 つのレベルのナビゲーションがあれば、通常は十分です。</span><span class="sxs-lookup"><span data-stu-id="cc097-145">A top-level navigation and one level beneath it is usually plenty.</span></span> <span data-ttu-id="cc097-146">3 レベルよりも多いナビゲーションでは、シンプルな操作の原則に反します。</span><span class="sxs-lookup"><span data-stu-id="cc097-146">If you go beyond three levels of navigation, then you break the principle of simplicity.</span></span> <span data-ttu-id="cc097-147">ユーザーは迷ってしまい、深い階層から抜け出せなくなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-147">Even worse, you risk stranding your user in a deep hierarchy that they will have difficulty leaving.</span></span>

2. <span data-ttu-id="cc097-148">ナビゲーションの選択肢が多すぎないようにします。</span><span class="sxs-lookup"><span data-stu-id="cc097-148">Avoid too many navigational options.</span></span> <span data-ttu-id="cc097-149">各レベルで 3 ～ 6 個のナビゲーション要素とすることが最も一般的です。</span><span class="sxs-lookup"><span data-stu-id="cc097-149">Three to six navigation elements per level are most common.</span></span> <span data-ttu-id="cc097-150">(特に階層のトップ レベルで) それより多いナビゲーションが必要な場合、1 つアプリであまりに多くのことをしようとしています。アプリを複数に分割することを検討する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-150">If your navigation needs more than this, especially at the top level of your hierarchy, then you might consider splitting your app into multiple apps, since you may be trying to do too much in one place.</span></span> <span data-ttu-id="cc097-151">アプリのナビゲーション要素が多すぎるのは、多くの場合、一貫性がなく関係のない目的によるものです。</span><span class="sxs-lookup"><span data-stu-id="cc097-151">Too many navigation elements in an app usually lead to inconsistent and unrelated objectives.</span></span>

3. <span data-ttu-id="cc097-152">「ホッピング」を避けます。</span><span class="sxs-lookup"><span data-stu-id="cc097-152">Avoid "pogo-sticking."</span></span> <span data-ttu-id="cc097-153">ホッピングとは、関連するコンテンツに移動するために、ユーザーが上のレベルに移動して、それから下のレベルに移動する必要があるナビゲーションを意味します。</span><span class="sxs-lookup"><span data-stu-id="cc097-153">Pogo-sticking occurs when there is related content, but navigating to it requires the user to go up a level and then down again.</span></span> <span data-ttu-id="cc097-154">ホッピングは、目的を達するために、不要なクリックや不要な操作を必要とするため、クリーンな操作の原則に反します。次の例では、一連の関連するコンテンツを見るという目的です。</span><span class="sxs-lookup"><span data-stu-id="cc097-154">Pogo-sticking violates the principle of clean interaction by requiring unnecessary clicks or interactions to achieve an obvious goal—in this case, looking at related content in a series.</span></span> <span data-ttu-id="cc097-155">(検索と参照を行うとき、必要な幅と深さを提供するためにホッピングが唯一の方法である場合は、このルールの例外となります。)</span><span class="sxs-lookup"><span data-stu-id="cc097-155">(The exception to this rule is in search and browse, where pogo-sticking may be the only way to provide the diversity and depth required.)</span></span>
<figure class="wdg-figure">
  ![ホッピングの例](images/nav/nav-pogo-sticking-1.png)
  <figcaption> <span data-ttu-id="cc097-157">アプリのナビゲーションでのホッピング —  ユーザーは緑の [戻る] 矢印を使って、メイン ページに戻ってから、[プロジェクト] タブにナビゲーションする必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-157">Pogo-sticking to navigate through an app—the user has to go back (green back arrow)  to the main page in order to navigate to the “Projects” tab.</span></span>
</figcaption>
</figure> 
<figure class="wdg-figure">
  ![スワイプによる水平方向ナビゲーションにより、ホッピングを解決する](images/nav/nav-pogo-sticking-2.png)
  <figcaption><span data-ttu-id="cc097-159">アイコンを使ってホッピングの問題を解決できます (緑のスワイプ ジェスチャに注目してください)</span><span class="sxs-lookup"><span data-stu-id="cc097-159">You can resolve some pogo-sticking issues with an icon (note the swipe gesture in green).</span></span>
</figcaption>
</figure> 


## <a name="use-the-right-structure"></a><span data-ttu-id="cc097-160">適切な構造を使う</span><span class="sxs-lookup"><span data-stu-id="cc097-160">Use the right structure</span></span> 
<span data-ttu-id="cc097-161">ナビゲーションの一般的な原則と規則について説明しました。次に、ナビゲーションに関して最も重要な決定を行います。それはアプリの構造です。</span><span class="sxs-lookup"><span data-stu-id="cc097-161">Now that you're familiar with general navigation principles and rules, it's time to make the most important of all navigation decisions: how should you structure your app?</span></span> <span data-ttu-id="cc097-162">2 種類の一般的な構造があります。フラット構造と階層構造です。</span><span class="sxs-lookup"><span data-stu-id="cc097-162">There are two general structures: flat and hierarchal.</span></span> 

### <a name="flatlateral"></a><span data-ttu-id="cc097-163">フラット構造/水平構造</span><span class="sxs-lookup"><span data-stu-id="cc097-163">Flat/lateral</span></span>
<span data-ttu-id="cc097-164">フラット構造/水平構造では、ページは横方向に存在します。</span><span class="sxs-lookup"><span data-stu-id="cc097-164">In a flat/lateral structure, pages exist side-by-side.</span></span> <span data-ttu-id="cc097-165">どのような順序でもページ間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="cc097-165">You can go from on page to another in any order.</span></span> 
<figure class="wdg-figure">
  <img src="images/nav/nav-pages-peer.png" alt="Pages arranged in a flat structure" />
<figcaption><span data-ttu-id="cc097-166">フラット構造で配置されたページ</span><span class="sxs-lookup"><span data-stu-id="cc097-166">Pages arranged in a flat structure</span></span></figcaption>
</figure> 

<span data-ttu-id="cc097-167">フラット構造には多くのメリットがあります。シンプルで、理解が容易です。ユーザーは、中間ページを経由する必要なく、特定のページに直接移動できます。</span><span class="sxs-lookup"><span data-stu-id="cc097-167">Flat structures have many benefits: they're simple and they're easy to understand, and they let the user jump directly to a specific page without having to wade through intermediary pages.</span></span>  <span data-ttu-id="cc097-168">一般に、フラット構造は優れていますが、すべてのアプリに対応できるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="cc097-168">In general, flat structures are great--but they don't work for every app.</span></span> <span data-ttu-id="cc097-169">アプリに多数のページがある場合には、フラット構造では圧倒されてしまいます。</span><span class="sxs-lookup"><span data-stu-id="cc097-169">If your app has a lot of pages, a flat list can be overwhelming.</span></span> <span data-ttu-id="cc097-170">ページを特定の順序で表示する必要がある場合には、フラット構造は適しません。</span><span class="sxs-lookup"><span data-stu-id="cc097-170">If pages need to be viewed in a particular order, a flat structure doesn't work.</span></span> 

<span data-ttu-id="cc097-171">次のような場合に、フラット構造の使用を推奨します。</span><span class="sxs-lookup"><span data-stu-id="cc097-171">We recommend using a flat structure when:</span></span> 
<ul>
<li><span data-ttu-id="cc097-172">ページをどのような順序でも表示できる場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-172">The pages can be viewed in any order.</span></span></li>
<li><span data-ttu-id="cc097-173">各ページはそれぞれ異なるページであり、明確な親/子関係がない場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-173">The pages are clearly distinct from each other and don't have an obvious parent/child relationship.</span></span></li>
<li><span data-ttu-id="cc097-174">グループ内のページ数が 8 ページよりも少ない場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-174">There are fewer than 8 pages in the group.</span></span><br/>
<span data-ttu-id="cc097-175">グループ内のページ数が 7 ページを超える場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-175">When there are more than 7 pages in the group, it might be difficult for users to understand how the pages are unique or to understand their current location within the group.</span></span> <span data-ttu-id="cc097-176">このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。</span><span class="sxs-lookup"><span data-stu-id="cc097-176">If you don't think that's an issue for your app, go ahead and make the pages peers.</span></span> <span data-ttu-id="cc097-177">このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください </span><span class="sxs-lookup"><span data-stu-id="cc097-177">Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups.</span></span> <span data-ttu-id="cc097-178">(ハブ コントロールを使うと、ページをカテゴリにグループ化できます)。</span><span class="sxs-lookup"><span data-stu-id="cc097-178">(A hub control can help you group pages into categories.)</span></span></li>
</ul>


### <a name="hierarchical"></a><span data-ttu-id="cc097-179">階層構造</span><span class="sxs-lookup"><span data-stu-id="cc097-179">Hierarchical</span></span>

<span data-ttu-id="cc097-180">階層構造では、ページはツリー状の構造に配置されています。</span><span class="sxs-lookup"><span data-stu-id="cc097-180">In a hierarchical structure, pages are organized into a tree-like structure.</span></span> <span data-ttu-id="cc097-181">それぞれの子ページの親は 1 つだけですが、親ページは 1 つ以上の子ページを持つことができます。</span><span class="sxs-lookup"><span data-stu-id="cc097-181">Each child page has only one parent, but a parent can have one or more child pages.</span></span> <span data-ttu-id="cc097-182">子ページにアクセスするには、親ページを経由します。</span><span class="sxs-lookup"><span data-stu-id="cc097-182">To reach a child page, you travel through the parent.</span></span>

<figure class="wdg-figure">
  <img src="images/nav/nav-pages-hiearchy.png" alt="Pages arranged in a hierarchy" />
<figcaption><span data-ttu-id="cc097-183">階層構造で配置されたページ</span><span class="sxs-lookup"><span data-stu-id="cc097-183">Pages arranged in a hierarchy</span></span></figcaption>
</figure>

<span data-ttu-id="cc097-184">階層構造は、多数のページにわたる複雑なコンテンツを配置する場合、またページを特定の順序で表示する場合に適してします。</span><span class="sxs-lookup"><span data-stu-id="cc097-184">Hierarchical structures are good for organizing complex content that spans lots of pages or when pages should be viewed in a particular order.</span></span> <span data-ttu-id="cc097-185">欠点は、階層構造のページでは、ナビゲーションのオーバーヘッドが発生することです。階層が深くなると、ユーザーがページからページへの移動するために、多くのクリックが必要となります。</span><span class="sxs-lookup"><span data-stu-id="cc097-185">The downside is that hierarchical pages introduce some navigation overhead: the deeper the structure, the more clicks it takes for users to get from page to page.</span></span> 

<span data-ttu-id="cc097-186">次のような場合に、階層構造の使用を推奨します。</span><span class="sxs-lookup"><span data-stu-id="cc097-186">We recommend a hiearchical structure when:</span></span> 
<ul>
<li><span data-ttu-id="cc097-187">ユーザーが特定の順序でページ間を移動する必要がある場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-187">You expect the user to traverse the pages in a specific order.</span></span> <span data-ttu-id="cc097-188">その順序を強制的に適用するように階層を配置します。</span><span class="sxs-lookup"><span data-stu-id="cc097-188">Arrange the hierarchy to enforce that order.</span></span></li>
<li><span data-ttu-id="cc097-189">グループ内の各ページ間には明確な親子関係がある場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-189">There is a clear parent-child relationship between one of the pages and the other pages in the group.</span></span></li>
<li><span data-ttu-id="cc097-190">グループ内のページ数が 7 ページを超える場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-190">There are more than 7 pages in the group.</span></span><br/>
<span data-ttu-id="cc097-191">グループ内のページ数が 7 ページを超える場合、ページが一意であるかどうかを判断したり、グループ内の現在の位置を把握したりするのが難しくなる場合があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-191">When there are more than 7 pages in the group, it might be difficult for users to understand how the pages are unique or to understand their current location within the group.</span></span> <span data-ttu-id="cc097-192">このことがアプリでは問題にはならないと考えられる場合は、ページをピアとして作成します。</span><span class="sxs-lookup"><span data-stu-id="cc097-192">If you don't think that's an issue for your app, go ahead and make the pages peers.</span></span> <span data-ttu-id="cc097-193">このことが問題となる可能性がある場合は、階層構造を使って、ページを 2 つ以上の小さなグループに分割することを検討してください </span><span class="sxs-lookup"><span data-stu-id="cc097-193">Otherwise, consider using a hierarchical structure to break the pages into two or more smaller groups.</span></span> <span data-ttu-id="cc097-194">(ハブ コントロールを使うと、ページをカテゴリにグループ化できます)。</span><span class="sxs-lookup"><span data-stu-id="cc097-194">(A hub control can help you group pages into categories.)</span></span></li>
</ul>

### <a name="combining-structures"></a><span data-ttu-id="cc097-195">構造を組み合わせる</span><span class="sxs-lookup"><span data-stu-id="cc097-195">Combining structures</span></span>
<span data-ttu-id="cc097-196">1 つの構造のみを選択する必要はありません。優れた設計のアプリの多くは、フラット構造と階層構造の両方を使用しています。</span><span class="sxs-lookup"><span data-stu-id="cc097-196">You don't have choose one structure or the other; many well-design apps use both flat and hierarchical structures:</span></span>

![ハイブリッド構造のアプリ](images/nav/nav-hybridstructure.png.png)

<span data-ttu-id="cc097-198">これらのアプリでは、トップレベルのページにはフラット構造を使って、任意の順序で参照できるようにし、複雑な関係のあるページには階層構造を使っています。</span><span class="sxs-lookup"><span data-stu-id="cc097-198">These apps use flat structures for top-level pages that can be viewed in any order, and hierarchical structures for pages that have more complex relationships.</span></span> 

<span data-ttu-id="cc097-199">ナビゲーション構造に複数のレベルがある場合は、現在のサブツリー内のピアにのみリンクするピア ツー ピアのナビゲーション要素を使うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="cc097-199">If your navigation structure has multiple levels, we recommend that peer-to-peer navigation elements only link to the peers within their current subtree.</span></span> <span data-ttu-id="cc097-200">3 つのレベルを持つナビゲーション構造を示す、次の図について考えてみましょう。</span><span class="sxs-lookup"><span data-stu-id="cc097-200">Consider the following illustration, which shows a navigation structure that has three levels:</span></span>

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees.png)
-   <span data-ttu-id="cc097-202">レベル 1 では、ピア ツー ピアのナビゲーション要素によって、ページ A、B、C、および D へのアクセスが提供されます。</span><span class="sxs-lookup"><span data-stu-id="cc097-202">For level 1, the peer-to-peer navigation element should provide access to pages A, B, C, and D.</span></span>
-   <span data-ttu-id="cc097-203">レベル 2 では、A2 ページのピア ツー ピアのナビゲーション要素は、他の A2 ページにのみリンクしています。</span><span class="sxs-lookup"><span data-stu-id="cc097-203">At level 2, the peer-to-peer navigation elements for the A2 pages should only link to the other A2 pages.</span></span> <span data-ttu-id="cc097-204">これらのナビゲーション要素は、C サブツリー内にあるレベル 2 のページにはリンクしていません。</span><span class="sxs-lookup"><span data-stu-id="cc097-204">They should not link to level 2 pages in the C subtree.</span></span>

![2 つのサブツリーを含むアプリ](images/nav/nav-subtrees2.png)
 

## <a name="use-the-right-controls"></a><span data-ttu-id="cc097-206">適切なコントロールを使用する</span><span class="sxs-lookup"><span data-stu-id="cc097-206">Use the right controls</span></span>

<span data-ttu-id="cc097-207">ページの構造を決定したら、ユーザーがページ間をどのように移動するかを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="cc097-207">Once you've decided on a page structure, you need to decide how users navigate through those pages.</span></span> <span data-ttu-id="cc097-208">UWP では、さまざまなナビゲーション コントロールを提供しています。</span><span class="sxs-lookup"><span data-stu-id="cc097-208">UWP provides a variety of navigation controls to help you.</span></span> <span data-ttu-id="cc097-209">これらのコントロールは、すべての UWP アプリで利用できるため、それらを使用すると、一貫性と信頼性を備えたナビゲーション エクスペリエンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="cc097-209">Because these controls are available to every UWP app, using them helps ensure a consistent and reliable navigation experience.</span></span> 


<table>
<tr>
    <th><span data-ttu-id="cc097-210">コントロール</span><span class="sxs-lookup"><span data-stu-id="cc097-210">Control</span></span></th>
    <th><span data-ttu-id="cc097-211">説明</span><span class="sxs-lookup"><span data-stu-id="cc097-211">Description</span></span></th>
</tr>
<tr>
    <td>[<span data-ttu-id="cc097-212">フレーム</span><span class="sxs-lookup"><span data-stu-id="cc097-212">Frame</span></span>](https://docs.microsoft.com/en-us/uwp/api/Windows.UI.Xaml.Controls.Frame)</td>
    <td><span data-ttu-id="cc097-213">少数の例外を除き、複数のページを持つアプリでは、フレームを使用しています。</span><span class="sxs-lookup"><span data-stu-id="cc097-213">With few exceptions, any app that has multiple pages uses the frame.</span></span> <span data-ttu-id="cc097-214">通常のセットアップでは、アプリには、フレームとナビゲーション ビュー コントロールなどの主要なナビゲーション要素を含むメイン メージがあります。</span><span class="sxs-lookup"><span data-stu-id="cc097-214">In a typical setup, the app has a main page that contains the frame and a primary navigation element, such as a navigation view control.</span></span> <span data-ttu-id="cc097-215">ユーザーがページを選択すると、フレームがページを読み込んで表示します。</span><span class="sxs-lookup"><span data-stu-id="cc097-215">When the user selects a page, the frame loads and displays it.</span></span></td>
</tr>
<tr>
    <td>[<span data-ttu-id="cc097-216">タブとピボット</span><span class="sxs-lookup"><span data-stu-id="cc097-216">Tabs and pivot</span></span>](../controls-and-patterns/tabs-pivot.md)<br/><br/>
    <img src="images/nav/nav-tabs-sm-300.png" alt="Tab-based navigation" /></td>
    <td><span data-ttu-id="cc097-217">同じレベルにあるページへのリンクの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="cc097-217">Displays a list of links to pages at the same level.</span></span>
<p><span data-ttu-id="cc097-218">次のような場合に、タブ/ピボットを使います。</span><span class="sxs-lookup"><span data-stu-id="cc097-218">Use tabs/pivots when:</span></span></p>
<ul>
<li><p><span data-ttu-id="cc097-219">ページ数が 2 ～ 5 ページの場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-219">There are 2-5 pages.</span></span></p>
<p><span data-ttu-id="cc097-220">5 ページを超える場合でもタブ/ピボットを使うことはできますが、すべてのタブ/ピボットを画面に収めることが難しくなることがあります。</span><span class="sxs-lookup"><span data-stu-id="cc097-220">(You can use tabs/pivots when there are more than 5 pages, but it might be difficult to fit all the tabs/pivots on the screen.)</span></span></p></li>
<li><span data-ttu-id="cc097-221">ユーザーが頻繁にページ間を切り替えることを前提としている場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-221">You expect users to switch between pages frequently.</span></span></li>
</ul></td>
</tr>
<tr>
    <td>[<span data-ttu-id="cc097-222">ナビゲーション ビュー</span><span class="sxs-lookup"><span data-stu-id="cc097-222">Nav view</span></span>](../controls-and-patterns/navigationview.md)<br/><br/>
    <img src="images/nav/nav-navpane-4page-thumb.png" alt="A navigation pane" /></td>
    <td><span data-ttu-id="cc097-223">トップレベルのページへのリンクの一覧を表示します。</span><span class="sxs-lookup"><span data-stu-id="cc097-223">Displays a list of links to top-level pages.</span></span>
<p><span data-ttu-id="cc097-224">次のような場合に、ナビゲーション ウィンドウを使います。</span><span class="sxs-lookup"><span data-stu-id="cc097-224">Use a navigation pane when:</span></span></p>
<ul>
<li><span data-ttu-id="cc097-225">ユーザーが頻繁にページ間を切り替えることを前提としていない場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-225">You don't expect users to switch between pages frequently.</span></span></li>
<li><span data-ttu-id="cc097-226">ナビゲーション操作の速度を低下させて、領域を節約する必要がある場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-226">You want to conserve space at the expense of slowing down navigation operations.</span></span></li>
<li><span data-ttu-id="cc097-227">ページがトップレベルに存在する場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-227">The pages exist at the top level.</span></span></li>
</ul></td>
</tr>
<tr>
<td>[<span data-ttu-id="cc097-228">マスター/詳細</span><span class="sxs-lookup"><span data-stu-id="cc097-228">Master/details</span></span>](../controls-and-patterns/master-details.md)<br/><br/>
<img src="images/higsecone-masterdetail-thumb.png" alt="Master/details" /></td>
<td><span data-ttu-id="cc097-229">項目の概要の一覧 (マスター ビュー) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="cc097-229">Displays a list (master view) of item summaries.</span></span> <span data-ttu-id="cc097-230">項目を選ぶと、対応する項目ページが詳細セクションに表示されます。</span><span class="sxs-lookup"><span data-stu-id="cc097-230">Selecting an item displays its corresponding items page in the details section.</span></span>
<p><span data-ttu-id="cc097-231">マスター/詳細要素を使う場合</span><span class="sxs-lookup"><span data-stu-id="cc097-231">Use the Master/details element when:</span></span></p>
<ul>
<li><span data-ttu-id="cc097-232">ユーザーが頻繁に子項目間を切り替えることを前提としている場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-232">You expect users to switch between child items frequently.</span></span></li>
<li><span data-ttu-id="cc097-233">ユーザーが個々の項目や項目のグループに対して高いレベルの操作 (削除や並べ替えなど) を実行できるようにする場合、およびユーザーが各項目の詳細情報の表示や更新を実行できるようにする場合。</span><span class="sxs-lookup"><span data-stu-id="cc097-233">You want to enable the user to perform high-level operations, such as deleting or sorting, on individual items or groups of items, and also want to enable the user to view or update the details for each item.</span></span></li>
</ul>
<p><span data-ttu-id="cc097-234">マスター/詳細要素は、メールの受信トレイ、連絡先リスト、データ入力に適しています。</span><span class="sxs-lookup"><span data-stu-id="cc097-234">Master/details elements are well suited for email inboxes, contact lists, and data entry.</span></span></p>
</td>
</tr>
<tr>
<td s>[<span data-ttu-id="cc097-235">戻る</span><span class="sxs-lookup"><span data-stu-id="cc097-235">Back</span></span>](navigation-history-and-backwards-navigation.md)</td>
<td style="vertical-align:top;"><span data-ttu-id="cc097-236">ユーザーは、アプリ内のナビゲーション履歴や、デバイスによってはアプリ間を移動できます。</span><span class="sxs-lookup"><span data-stu-id="cc097-236">Lets the user traverse the navigation history within an app and, depending on the device, from app to app.</span></span> <span data-ttu-id="cc097-237">詳しくは、「[ナビゲーション履歴と前に戻る移動](navigation-history-and-backwards-navigation.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cc097-237">For more info, see the [Navigation history and backwards navigation article](navigation-history-and-backwards-navigation.md).</span></span></td>
</tr>
<tr class="odd">
<td><span data-ttu-id="cc097-238">ハイパーリンクとボタン</span><span class="sxs-lookup"><span data-stu-id="cc097-238">Hyperlinks and buttons</span></span></td>
<td><span data-ttu-id="cc097-239">コンテンツに埋め込まれたナビゲーション要素は、ページのコンテンツに表示されます。</span><span class="sxs-lookup"><span data-stu-id="cc097-239">Content-embedded navigation elements appear in a page's content.</span></span> <span data-ttu-id="cc097-240">他のナビゲーション要素はページのグループやサブツリー全体で一貫性がありますが、それとは異なり、コンテンツに埋め込まれたナビゲーション要素はそれぞれのページに固有のナビゲーション要素です。</span><span class="sxs-lookup"><span data-stu-id="cc097-240">Unlike other navigation elements, which should be consistent across the page's group or subtree, content-embedded navigation elements are unique from page to page.</span></span></td>
</tr>
</table>

## <a name="next-add-navigation-code-to-your-app"></a><span data-ttu-id="cc097-241">次の手順: アプリにナビゲーションのコードを追加する</span><span class="sxs-lookup"><span data-stu-id="cc097-241">Next: Add navigation code to your app</span></span>
<span data-ttu-id="cc097-242">次の記事「[基本的なナビゲーションを実装する](navigate-between-two-pages.md)」では、アプリで基本的なナビゲーションを行うための、XAML と Frame コントロールを使用するために必要なコードを説明します。</span><span class="sxs-lookup"><span data-stu-id="cc097-242">The next article, [Implement basic navigation](navigate-between-two-pages.md), shows the XAML and code required to use a Frame control to enable basic navigation in your app.</span></span> 


<!--
## History and the back button
UWP provides a back button and a system for traversing the user's navigation hsitory within an app. This system does most of the work for you, but there are a few APIs you need to call so that it works properly. For more info and instructions, see [History and backwards navigation](navigation-history-and-backwards-navigation.md). 
-->





