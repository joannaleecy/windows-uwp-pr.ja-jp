---
author: Jwmsft
Description: "入れ子になった UI を使用してリスト項目に対する複数の操作を有効にする"
title: "リスト項目の入れ子になった UI"
label: Nested UI in list items
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 60a29717-56f2-4388-a9ff-0098e34d5896
pm-contact: chigy
design-contact: kimsea
doc-status: Published
ms.openlocfilehash: a8d7ac9ad5cad6d88c0fac0c1e7bba53eaf0045d
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="nested-ui-in-list-items"></a><span data-ttu-id="99f2b-104">リスト項目の入れ子になった UI</span><span class="sxs-lookup"><span data-stu-id="99f2b-104">Nested UI in list items</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css"> 

<span data-ttu-id="99f2b-105">入れ子になった UI は、コンテナー内部に囲まれた、操作できる入れ子になったコントロールを公開するユーザー インターフェイス (UI) です。個別のフォーカスを取得することも可能です。</span><span class="sxs-lookup"><span data-stu-id="99f2b-105">Nested UI is a user interface (UI) that exposes nested actionable controls enclosed inside a container that also can take independent focus.</span></span>

<span data-ttu-id="99f2b-106">入れ子になった UI を使用することで、重要な操作をスムーズに行うことができるようになる追加のオプションをユーザーに提供できます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-106">You can use nested UI to present a user with additional options that help accelerate taking important actions.</span></span> <span data-ttu-id="99f2b-107">ただし、公開する操作の数が増えるにつれて、UI は複雑になります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-107">However, the more actions you expose, the more complicated your UI becomes.</span></span> <span data-ttu-id="99f2b-108">この UI パターンの使用を決めた場合は十分に注意することが必要です。</span><span class="sxs-lookup"><span data-stu-id="99f2b-108">You need to take extra care when you choose to use this UI pattern.</span></span> <span data-ttu-id="99f2b-109">この記事では、特定の UI に最適な一連の操作の判断に役立つガイドラインを提供します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-109">This article provides guidelines to help you determine the best course of action for your particular UI.</span></span>

> <span data-ttu-id="99f2b-110">**重要な API**: [ListView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx)、[GridView クラス](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)</span><span class="sxs-lookup"><span data-stu-id="99f2b-110">**Important APIs**: [ListView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx), [GridView class](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx)</span></span>

<span data-ttu-id="99f2b-111">この記事では、[ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) 項目および [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) 項目の入れ子になった UI の作成について説明します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-111">In this article, we discuss the creation of nested UI in [ListView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) and [GridView](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) items.</span></span> <span data-ttu-id="99f2b-112">このセクションでは、入れ子になった UI の他の例については取り上げませんが、これらの概念は他でも利用できます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-112">While this section does not talk about other nested UI cases, these concepts are transferrable.</span></span> <span data-ttu-id="99f2b-113">始める前に、UI における ListView コントロールまたは GridView コントロールの使用について、一般的なガイダンスを理解している必要があります。この一般的なガイダンスについては、「[リスト](lists.md)」と「[リスト ビューとグリッド ビュー](listview-and-gridview.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-113">Before you start, you should be familiar with the general guidance for using ListView or GridView controls in your UI, which is found in the [Lists](lists.md) and [List view and grid view](listview-and-gridview.md) articles.</span></span>

<span data-ttu-id="99f2b-114">この記事で使用する用語、*リスト*、*リスト項目*、*入れ子になった UI* は次のように定義します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-114">In this article, we use the terms *list*, *list item*, and *nested UI* as defined here:</span></span>
- <span data-ttu-id="99f2b-115">*リスト*は、リスト ビューまたはグリッド ビューに含まれた項目のコレクションを表します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-115">*List* refers to a collection of items contained in a list view or grid view.</span></span>
- <span data-ttu-id="99f2b-116">*リスト項目*は、ユーザーが操作を実行できるリスト上の個別の項目を表します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-116">*List item* refers to an individual item that a user can take action on in a list.</span></span>
- <span data-ttu-id="99f2b-117">*入れ子になった UI* は、リスト項目自体に対する操作とは別にユーザーが操作できるリスト項目内の UI 要素を表します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-117">*Nested UI* refers to UI elements within a list item that a user can take action on separate from taking action on the list item itself.</span></span>

![入れ子になった UI 部](images/nested-ui-example-1.png)

> <span data-ttu-id="99f2b-119">注&nbsp;&nbsp; ListView と GridView はどちらも [ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx) クラスから派生しているため機能は同じですが、データの表示方法が異なります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-119">NOTE&nbsp;&nbsp; ListView and GridView both derive from the [ListViewBase](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.aspx) class, so they have the same functionality, but display data differently.</span></span> <span data-ttu-id="99f2b-120">この記事では、リストについての説明は ListView コントロールにも GridView コントロールにも適用されます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-120">In this article, when we talk about lists, the info applies to both the ListView and GridView controls.</span></span>

## <a name="primary-and-secondary-actions"></a><span data-ttu-id="99f2b-121">プライマリ操作とセカンダリ操作</span><span class="sxs-lookup"><span data-stu-id="99f2b-121">Primary and secondary actions</span></span>

<span data-ttu-id="99f2b-122">リストを使って UI を作成する場合、それらのリスト項目でユーザーがどのような操作を行う可能性があるかを考える必要があります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-122">When creating UI with a list, consider what actions the user might take from those list items.</span></span>  

- <span data-ttu-id="99f2b-123">ユーザーが項目をクリックして操作を実行できるかどうか。</span><span class="sxs-lookup"><span data-stu-id="99f2b-123">Can a user click on the item to perform an action?</span></span>
    - <span data-ttu-id="99f2b-124">通常、リスト項目をクリックすると操作が開始されますが、そうである必要はありません。</span><span class="sxs-lookup"><span data-stu-id="99f2b-124">Typically, clicking a list item initiates an action, but it doesn't have too.</span></span>
- <span data-ttu-id="99f2b-125">ユーザーが 2 つ以上の操作を実行する可能性があるかどうか。</span><span class="sxs-lookup"><span data-stu-id="99f2b-125">Is there more than one action the user can take?</span></span>
    - <span data-ttu-id="99f2b-126">たとえば、リストのメールをタップすることでメールが開きます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-126">For example, tapping an email in a list opens that email.</span></span> <span data-ttu-id="99f2b-127">ただし、メールを削除するなど、メールを開かずに、ユーザーがまず行うことを望む他の操作が存在する場合があります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-127">However, there might be other actions, like deleting the email, that the user would want to take without opening it first.</span></span> <span data-ttu-id="99f2b-128">こうした操作をリストから直接実行できればユーザーにとってメリットになります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-128">It would benefit the user to access this action directly in the list.</span></span>
- <span data-ttu-id="99f2b-129">操作をどのようにユーザーに公開するか。</span><span class="sxs-lookup"><span data-stu-id="99f2b-129">How should the actions be exposed to the user?</span></span>
    - <span data-ttu-id="99f2b-130">入力の種類をすべて検討します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-130">Consider all input types.</span></span> <span data-ttu-id="99f2b-131">入れ子になった UI の形式によっては、1 つの入力方法が適切に機能しても、他の方法では動作しない場合があります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-131">Some forms of nested UI work great with one method of input, but might not work with other methods.</span></span>  

<span data-ttu-id="99f2b-132">*プライマリ操作*は、ユーザーがリスト項目を押したときに発生することが予期される操作です。</span><span class="sxs-lookup"><span data-stu-id="99f2b-132">The *primary action* is what the user expects to happen when they press the list item.</span></span>

<span data-ttu-id="99f2b-133">*セカンダリ操作*は、一般的に、リスト項目と関連付けられたアクセラレータです。</span><span class="sxs-lookup"><span data-stu-id="99f2b-133">*Secondary actions* are typically accelerators associated with list items.</span></span> <span data-ttu-id="99f2b-134">これらのアクセラレータは、リスト管理を対象にしたものものあれば、リスト項目に関する操作用のものである場合もあります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-134">These accelerators can be for list management or actions related to the list item.</span></span>

## <a name="options-for-secondary-actions"></a><span data-ttu-id="99f2b-135">セカンダリ操作のオプション</span><span class="sxs-lookup"><span data-stu-id="99f2b-135">Options for secondary actions</span></span>

<span data-ttu-id="99f2b-136">リスト UI を作成する場合にまず必要なことは、UWP でサポートされるすべての入力方法が考慮されていることを確認することです。</span><span class="sxs-lookup"><span data-stu-id="99f2b-136">When creating list UI, you first need to make sure you account for all input methods that UWP supports.</span></span> <span data-ttu-id="99f2b-137">さまざまな種類の入力について詳しくは、「[操作の基本情報](../input-and-devices/input-primer.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-137">For more info about different kinds of input, see [Input primer](../input-and-devices/input-primer.md).</span></span>

<span data-ttu-id="99f2b-138">UWP でサポートされているすべての入力にアプリが対応していることを確認したら、メイン リストのアクセラレータとして公開するほどに、アプリのセカンダリ操作が重要であるかどうかを判断する必要があります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-138">After you have made sure that your app supports all inputs that UWP supports, you should decide if your app’s secondary actions are important enough to expose as accelerators in the main list.</span></span> <span data-ttu-id="99f2b-139">公開する操作が増えるほど、UI が複雑になることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-139">Remember that the more actions you expose, the more complicated your UI becomes.</span></span> <span data-ttu-id="99f2b-140">セカンダリ操作をメイン リスト UI に公開する必要性は本当にあるのでしょうか。ないとしたら、どこか他の場所に配置できるでしょうか。</span><span class="sxs-lookup"><span data-stu-id="99f2b-140">Do you really need to expose the secondary actions in the main list UI, or can you put them somewhere else?</span></span>

<span data-ttu-id="99f2b-141">どのような入力からでも常時その操作にアクセスできる必要がある場合は、追加の操作をメイン リスト UI に公開することを検討してみましょう。</span><span class="sxs-lookup"><span data-stu-id="99f2b-141">You might consider exposing additional actions in the main list UI when those actions need to be accessible by any input at all times.</span></span>

<span data-ttu-id="99f2b-142">セカンダリ操作をメイン リスト UI に配置することが必要ないと判断しても、他のさまざまな方法でその操作ユーザーに公開できます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-142">If you decide that putting secondary actions in the main list UI is not necessary, there are several other ways you can expose them to the user.</span></span> <span data-ttu-id="99f2b-143">セカンダリ操作の公開場所として検討できるオプションには次のようなものがあります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-143">Here are some options you can consider for where to place secondary actions.</span></span>

### <a name="put-secondary-actions-on-the-detail-page"></a><span data-ttu-id="99f2b-144">詳細ページにセカンダリ操作を配置</span><span class="sxs-lookup"><span data-stu-id="99f2b-144">Put secondary actions on the detail page</span></span>

<span data-ttu-id="99f2b-145">セカンダリ操作を、リスト項目が押されたときの移動先のページに配置します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-145">Put the secondary actions on the page that the list item navigates to when it’s pressed.</span></span> <span data-ttu-id="99f2b-146">マスター/詳細パターンを使用しているなら、多くの場合、詳細ページはセカンダリ操作を配置する適切な場所になります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-146">When you use the master/details pattern, the detail page is often a good place to put secondary actions.</span></span>

<span data-ttu-id="99f2b-147">詳しくは、「[マスター/詳細パターン](master-details.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-147">For more info, see the [Master/detail pattern](master-details.md).</span></span>

### <a name="put-secondary-actions-in-a-context-menu"></a><span data-ttu-id="99f2b-148">コンテキスト メニューにセカンダリ操作を配置</span><span class="sxs-lookup"><span data-stu-id="99f2b-148">Put secondary actions in a context menu</span></span>

<span data-ttu-id="99f2b-149">セカンダリ操作を、ユーザーが右クリックまたは長押しすることでアクセスできるコンテキスト メニューに配置します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-149">Put the secondary actions in a context menu that the user can access via right-click or press-and-hold.</span></span> <span data-ttu-id="99f2b-150">この方法には、詳細ページを読み込むことなく、メールの削除などの操作をユーザーが実行できるメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-150">This provides the benefit of letting the user perform an action, such as deleting an email, without having to load the detail page.</span></span> <span data-ttu-id="99f2b-151">このオプションは詳細ページで利用可能にすることもお勧めします。コンテキスト メニューはプライマリ UI ではなくアクセラレータとして使用することが意図されているためです。</span><span class="sxs-lookup"><span data-stu-id="99f2b-151">It's a good practice to also make these options available on the detail page, as context menus are intended to be accelerators rather than primary UI.</span></span>

<span data-ttu-id="99f2b-152">ゲームパッドやリモコンから入力された場合のセカンダリ操作を公開するには、コンテキスト メニューを使用することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="99f2b-152">To expose secondary actions when input is from a gamepad or remote control, we recommend that you use a context menu.</span></span>

<span data-ttu-id="99f2b-153">詳しくは、「[コンテキスト メニューとポップアップ](menus.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-153">For more info, see [Context menus and flyouts](menus.md).</span></span>

### <a name="put-secondary-actions-in-hover-ui-to-optimize-for-pointer-input"></a><span data-ttu-id="99f2b-154">ポインター入力に最適化するためにセカンダリ操作をホバー UI に配置</span><span class="sxs-lookup"><span data-stu-id="99f2b-154">Put secondary actions in hover UI to optimize for pointer input</span></span>

<span data-ttu-id="99f2b-155">マウスやペンなど、ポインター入力でアプリが使用される頻度が高くなることを見込んでおり、このような入力に対してのみセカンダリ操作をすぐに利用できるようにする必要がある場合、セカンダリ操作をホバー時に限定して表示できます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-155">If you expect your app to be used frequently with pointer input such as mouse and pen, and want to make secondary actions readily available only to those inputs, then you can show the secondary actions only on hover.</span></span> <span data-ttu-id="99f2b-156">このアクセラレータが表示されるのは、ポインター入力が使用されている場合に限られるため、他の入力の種類をサポートするには他のオプションも使用してください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-156">This accelerator is visible only when a pointer input is used, so be sure to use the other options to support other input types as well.</span></span>

![ホバー時に表示される入れ子になった UI](images/nested-ui-hover.png)


<span data-ttu-id="99f2b-158">詳しくは、「[マウス操作](../input-and-devices/mouse-interactions.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-158">For more info, see [Mouse interactions](../input-and-devices/mouse-interactions.md).</span></span>

## <a name="ui-placement-for-primary-and-secondary-actions"></a><span data-ttu-id="99f2b-159">プライマリ操作とセカンダリ操作の UI の配置</span><span class="sxs-lookup"><span data-stu-id="99f2b-159">UI placement for primary and secondary actions</span></span>

<span data-ttu-id="99f2b-160">セカンダリ操作をメイン リスト UI に公開することを決めた場合は、以下のガイドラインに従うことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="99f2b-160">If you decide that secondary actions should be exposed in the main list UI, we recommend the following guidelines.</span></span>

<span data-ttu-id="99f2b-161">プライマリ操作とセカンダリ操作を使用してリスト項目を作成する場合は、プライマリ操作を左側に配置し、セカンダリ操作を右側に配置します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-161">When you create a list item with primary and secondary actions, place the primary action to the left and secondary actions to the right.</span></span> <span data-ttu-id="99f2b-162">左から右に向けて読む文化では、ユーザーはリスト項目の左側にある操作をプライマリ操作と結び付けて考えます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-162">In left-to-right reading cultures, users associate actions on the left side of list item as the primary action.</span></span>

<span data-ttu-id="99f2b-163">この例では、項目が水平方向に向かって表示される (高さよりも幅の方が広い) リスト UI について説明しています。</span><span class="sxs-lookup"><span data-stu-id="99f2b-163">In these examples, we talk about list UI where the item flows more horizontally (it is wider than its height).</span></span> <span data-ttu-id="99f2b-164">ただし、リスト項目が正方形に近かったり、縦長だったりする場合もあることでしょう。</span><span class="sxs-lookup"><span data-stu-id="99f2b-164">However, you might have list items that are more square in shape, or taller than their width.</span></span> <span data-ttu-id="99f2b-165">通常、これらの項目はグリッドで使用されます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-165">Typically, these are items used in a grid.</span></span> <span data-ttu-id="99f2b-166">このような項目では、リストが垂直方向にスクロールしない場合、セカンダリ操作をリスト項目の右側ではなく一番下に配置します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-166">For these items, if the list doesn't scroll vertically, you can place the secondary actions at the bottom of the list item rather than to the right side.</span></span>

## <a name="consider-all-inputs"></a><span data-ttu-id="99f2b-167">すべての入力を検討</span><span class="sxs-lookup"><span data-stu-id="99f2b-167">Consider all inputs</span></span>

<span data-ttu-id="99f2b-168">入れ子になった UI を使用することに決めたら、すべての入力の種類を使ってユーザー エクスペリエンスを評価します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-168">When deciding to use nested UI, also evaluate the user experience with all input types.</span></span> <span data-ttu-id="99f2b-169">前述のように、入れ子になった UI は、一部の種類の入力では適切に動作します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-169">As mentioned earlier, nested UI works great for some input types.</span></span> <span data-ttu-id="99f2b-170">ただし、他の入力方法でも常に適切に動作するとは限りません。</span><span class="sxs-lookup"><span data-stu-id="99f2b-170">However, it does not always work great for some other.</span></span> <span data-ttu-id="99f2b-171">特に、キーボード、コントローラー、およびリモート入力では、入れ子になった UI 要素にアクセスすることが難くなる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="99f2b-171">In particular, keyboard, controller, and remote inputs can have difficulty accessing nested UI elements.</span></span> <span data-ttu-id="99f2b-172">UWP がすべての入力の種類で機能するように、後述のガイダンスに従ってください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-172">Be sure to follow the guidance below to ensure your UWP works with all input types.</span></span>

## <a name="nested-ui-handling"></a><span data-ttu-id="99f2b-173">入れ子になった UI の処理</span><span class="sxs-lookup"><span data-stu-id="99f2b-173">Nested UI handling</span></span>

<span data-ttu-id="99f2b-174">リスト項目内に 2 つ以上の操作がある場合は、このガイダンスに従って、キーボード、ゲームパッド、リモコンなど、非ポインター入力による移動を処理することを勧めします。</span><span class="sxs-lookup"><span data-stu-id="99f2b-174">When you have more than one action nested in the list item, we recommend this guidance to handle navigation with a keyboard, gamepad, remote control, or other non-pointer input.</span></span>

### <a name="nested-ui-where-list-items-perform-an-action"></a><span data-ttu-id="99f2b-175">リスト項目で操作が実行される入れ子になった UI</span><span class="sxs-lookup"><span data-stu-id="99f2b-175">Nested UI where list items perform an action</span></span>

<span data-ttu-id="99f2b-176">入れ子になった要素を含むリスト UI で、呼び出し処理、選択 (単一または複数) 処理、ドラッグ アンド ドロップ処理などの操作をサポートしている場合は、次の方向キーによる手法を使って、入れ子になった UI 要素を移動することがお勧めです。</span><span class="sxs-lookup"><span data-stu-id="99f2b-176">If your list UI with nested elements supports actions such as invoking, selection (single or multiple), or drag-and-drop operations, we recommend these arrowing techniques to navigate through your nested UI elements.</span></span>

![入れ子になった UI 部](images/nested-ui-navigation.png)

**<span data-ttu-id="99f2b-178">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="99f2b-178">Gamepad</span></span>**

<span data-ttu-id="99f2b-179">ゲームパッドで入力された場合、次のユーザー エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-179">When input is from a gamepad, provide this user experience:</span></span>

- <span data-ttu-id="99f2b-180">**A** では、右方向キーでフォーカスを **B** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-180">From **A**, right directional key puts focus on **B**.</span></span>
- <span data-ttu-id="99f2b-181">**B** では、右方向キーでフォーカスを **C** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-181">From **B**, right directional key puts focus on **C**.</span></span>
- <span data-ttu-id="99f2b-182">**C** では、右方向キーでは移動できなくするか、フォーカス可能な UI 要素がリストの右側にある場合は、そこにフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-182">From **C**, right directional key is either no op, or if there is a focusable UI element to the right of List, put the focus there.</span></span>
- <span data-ttu-id="99f2b-183">**C** では、左方向キーでフォーカスを **B** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-183">From **C**, left directional key puts focus on **B**.</span></span>
- <span data-ttu-id="99f2b-184">**B** では、左方向キーでフォーカスを **A** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-184">From **B**, left directional key puts focus on **A**.</span></span>
- <span data-ttu-id="99f2b-185">**A** では、左方向キーでは移動できなくするか、フォーカス可能な UI 要素がリストの右側にある場合は、そこにフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-185">From **A**, left directional key is either no op, or if there is a focusable UI element to the right of List, put the focus there.</span></span>
- <span data-ttu-id="99f2b-186">**A**、**B**、または **C** では、下方向キーでフォーカスを **D** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-186">From **A**, **B**, or **C**, down directional key puts focus on **D**.</span></span>
- <span data-ttu-id="99f2b-187">リスト項目の左側の UI 要素では、右方向キーでフォーカスを **A** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-187">From UI element to the left of List Item, right directional key puts focus on **A**.</span></span>
- <span data-ttu-id="99f2b-188">リスト項目の右側の UI 要素では、左方向キーでフォーカスを **A** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-188">From UI element to the right of List Item, left directional key puts focus on **A**.</span></span>

**<span data-ttu-id="99f2b-189">キーボード</span><span class="sxs-lookup"><span data-stu-id="99f2b-189">Keyboard</span></span>**

<span data-ttu-id="99f2b-190">キーボードで入力された場合、ユーザー エクスペリエンスは次のようにします。</span><span class="sxs-lookup"><span data-stu-id="99f2b-190">When input is from a keyboard, this is the experience user gets:</span></span>

- <span data-ttu-id="99f2b-191">**A** では、Tab キーでフォーカスを **B** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-191">From **A**, tab key puts focus on **B**.</span></span>
- <span data-ttu-id="99f2b-192">**B** では、Tab キーでフォーカスを **C** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-192">From **B**, tab key puts focus on **C**.</span></span>
- <span data-ttu-id="99f2b-193">**C** では、Tab キーで、タブ オーダーで次のフォーカス可能な UI 要素にフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-193">From **C**, tab key puts focus on next focusable UI element in the tab order.</span></span>
- <span data-ttu-id="99f2b-194">**C** では、Shift + Tab キーでフォーカスを **B** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-194">From **C**, shift+tab key puts focus on **B**.</span></span>
- <span data-ttu-id="99f2b-195">**B** では、Shift + Tab キーまたは左方向キーでフォーカスを **A** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-195">From **B**, shift+tab or left arrow key puts focus on **A**.</span></span>
- <span data-ttu-id="99f2b-196">**A** では、Shift + Tab キーで、逆方向のタブ オーダーで次のフォーカス可能な UI 要素にフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-196">From **A**, shift+tab key puts focus on next focusable UI element in the reverse tab order.</span></span>
- <span data-ttu-id="99f2b-197">**A**、**B**、または **C** では、下方向キーでフォーカスを **D** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-197">From **A**, **B**, or **C**, down arrow key puts focus on **D**.</span></span>
- <span data-ttu-id="99f2b-198">リスト項目の左側の UI 要素では、Tab キーでフォーカスを **A** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-198">From UI element to the left of List Item, tab key puts focus on **A**.</span></span>
- <span data-ttu-id="99f2b-199">リスト項目の右側の UI 要素では、Shift + Tab キーでフォーカスを **C** に設定します</span><span class="sxs-lookup"><span data-stu-id="99f2b-199">From UI element to the right of List Item, shift tab key puts focus on **C**.</span></span>

<span data-ttu-id="99f2b-200">この UI を実現するには、リストで [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-200">To achieve this UI, set [IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) to **true** on your list.</span></span> <span data-ttu-id="99f2b-201">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) は、任意の値を使うことができます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-201">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) can be any value.</span></span>

<span data-ttu-id="99f2b-202">これを実装するコードについては、この記事の「[例](#example)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="99f2b-202">For the code to implement this, see the [Example](#example) section of this article.</span></span>

### <a name="nested-ui-where-list-items-do-not-perform-an-action"></a><span data-ttu-id="99f2b-203">リスト項目で操作が実行されない入れ子になった UI</span><span class="sxs-lookup"><span data-stu-id="99f2b-203">Nested UI where list items do not perform an action</span></span>

<span data-ttu-id="99f2b-204">リスト ビューによって仮想化と最適化されたスクロール動作が提供されることからリスト ビューを使用する場合があります。ただし、このとき操作が関連付けられているリスト項目はありません。</span><span class="sxs-lookup"><span data-stu-id="99f2b-204">You might use a list view because it provides virtualization and optimized scrolling behavior, but not have an action associated with a list item.</span></span> <span data-ttu-id="99f2b-205">これらの UI では通常、要素をグループ化して要素をまとめてスクロールできるようにするためだけに、リスト項目を使用します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-205">These UIs typically use the list item only to group elements and ensure they scroll as a set.</span></span>

<span data-ttu-id="99f2b-206">この種類の UI は、前述の例よりもずっと複雑になる傾向があり、ユーザーが操作可能な入れ子になった要素が多数含まれます。</span><span class="sxs-lookup"><span data-stu-id="99f2b-206">This kind of UI tends to be much more complicated than the previous examples, with a lot of nested elements that the user can take action on.</span></span>

![入れ子になった UI 部](images/nested-ui-grouping.png)


<span data-ttu-id="99f2b-208">この UI を実現するには、リストのプロパティを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-208">To achieve this UI, set the following properties on your list:</span></span>
- <span data-ttu-id="99f2b-209">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) を **None** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-209">[SelectionMode](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.selectionmode.aspx) to **None**.</span></span>
- <span data-ttu-id="99f2b-210">[IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) を **false** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-210">[IsItemClickEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listviewbase.isitemclickenabled.aspx) to **false**.</span></span>
- <span data-ttu-id="99f2b-211">[IsFocusEngagementEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isfocusengagementenabled.aspx) を **true** に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-211">[IsFocusEngagementEnabled](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.control.isfocusengagementenabled.aspx) to **true**.</span></span>

```xaml
<ListView SelectionMode="None" IsItemClickEnabled="False" >
    <ListView.ItemContainerStyle>
         <Style TargetType="ListViewItem">
             <Setter Property="IsFocusEngagementEnabled" Value="True"/>
         </Style>
    </ListView.ItemContainerStyle>
</ListView>
```

<span data-ttu-id="99f2b-212">リスト項目で操作が実行されない場合は、次のガイダンスに従ってゲームパッドまたはキーボードによる移動を処理することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="99f2b-212">When the list items do not perform an action, we recommend this guidance to handle navigation with a gamepad or keyboard.</span></span>

**<span data-ttu-id="99f2b-213">ゲームパッド</span><span class="sxs-lookup"><span data-stu-id="99f2b-213">Gamepad</span></span>**

<span data-ttu-id="99f2b-214">ゲームパッドで入力された場合、次のユーザー エクスペリエンスを提供します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-214">When input is from a gamepad, provide this user experience:</span></span>

- <span data-ttu-id="99f2b-215">リスト項目では、下方向キーでフォーカスを次のリスト項目に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-215">From List Item, down directional key puts focus on next List Item.</span></span>
- <span data-ttu-id="99f2b-216">リスト項目では、左または右方向キーでは移動できなくするか、フォーカス可能な UI 要素がリストの右側にある場合は、そこにフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-216">From List Item, left/right key is either no op, or if there is a focusable UI element to the right of List, put the focus there.</span></span>
- <span data-ttu-id="99f2b-217">リスト項目では、A ボタンで、上/左下/右の優先順位で、入れ子になった UI にフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-217">From List Item, 'A' button puts the focus on Nested UI in top/down left/right priority.</span></span>
- <span data-ttu-id="99f2b-218">入れ子になた UI 内部では、XY フォーカス ナビゲーション モデルに従います。</span><span class="sxs-lookup"><span data-stu-id="99f2b-218">While inside Nested UI, follow the XY Focus navigation model.</span></span>  <span data-ttu-id="99f2b-219">ユーザーが B ボタンを押すまで、フォーカスが移動できる対象を現在のリスト項目内にある入れ子になった UI に限定します。B ボタンを押したら、リスト項目にフォーカスを戻します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-219">Focus can only navigate around Nested UI contained inside the current List Item until user presses 'B' button, which puts the focus back onto the List Item.</span></span>

**<span data-ttu-id="99f2b-220">キーボード</span><span class="sxs-lookup"><span data-stu-id="99f2b-220">Keyboard</span></span>**

<span data-ttu-id="99f2b-221">キーボードで入力された場合、ユーザー エクスペリエンスは次のようにします。</span><span class="sxs-lookup"><span data-stu-id="99f2b-221">When input is from a keyboard, this is the experience user gets:</span></span>

- <span data-ttu-id="99f2b-222">リスト項目では、下方向キーでフォーカスを次のリスト項目に設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-222">From List Item, down arrow key puts focus on the next List Item.</span></span>
- <span data-ttu-id="99f2b-223">リスト項目では、左方向キーまたは右方向キーを押しても移動しません。</span><span class="sxs-lookup"><span data-stu-id="99f2b-223">From List Item, pressing left/right key is no op.</span></span>
- <span data-ttu-id="99f2b-224">リスト項目では、TAB キーを押すと、入れ子になった UI 項目の次のタブ ストップにフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-224">From List Item, pressing tab key puts focus on the next tab stop amongst the Nested UI item.</span></span>
- <span data-ttu-id="99f2b-225">いずれかの入れ子になった UI 項目では、TAB キーを押すと、タブ オーダーで、入れ子になった UI 項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-225">From one of the Nested UI items, pressing tab traverses the nested UI items in tab order.</span></span>  <span data-ttu-id="99f2b-226">すべての入れ子になった UI 項目を移動したら、タブ オーダーで ListView 後の次のコントロールにフォーカスを設定します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-226">Once all the Nested UI items are traveled to, it puts the focus onto the next control in tab order after ListView.</span></span>
- <span data-ttu-id="99f2b-227">Shift + Tab キーを押すと、Tab キーの動作と逆方向に動作します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-227">Shift+Tab behaves in reverse direction from tab behavior.</span></span>

## <a name="example"></a><span data-ttu-id="99f2b-228">例</span><span class="sxs-lookup"><span data-stu-id="99f2b-228">Example</span></span>

<span data-ttu-id="99f2b-229">この例は、[リスト項目で操作を実行する入れ子になった UI](#nested-ui-where-list-items-perform-an-action) を実装する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="99f2b-229">This example shows how to implement [nested UI where list items perform an action](#nested-ui-where-list-items-perform-an-action).</span></span>

```xaml
<ListView SelectionMode="None" IsItemClickEnabled="True"
          ChoosingItemContainer="listview1_ChoosingItemContainer"/>
```

```csharp
private void OnListViewItemKeyDown(object sender, KeyRoutedEventArgs e)
{
    // Code to handle going in/out of nested UI with gamepad and remote only.
    if (e.Handled == true)
    {
        return;
    }

    var focusedElementAsListViewItem = FocusManager.GetFocusedElement() as ListViewItem;
    if (focusedElementAsListViewItem != null)
    {
        // Focus is on the ListViewItem.
        // Go in with Right arrow.
        Control candidate = null;

        switch (e.OriginalKey)
        {
            case Windows.System.VirtualKey.GamepadDPadRight:
            case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                var rawPixelsPerViewPixel = DisplayInformation.GetForCurrentView().RawPixelsPerViewPixel;
                GeneralTransform generalTransform = focusedElementAsListViewItem.TransformToVisual(null);
                Point startPoint = generalTransform.TransformPoint(new Point(0, 0));
                Rect hintRect = new Rect(startPoint.X * rawPixelsPerViewPixel, startPoint.Y * rawPixelsPerViewPixel, 1, focusedElementAsListViewItem.ActualHeight * rawPixelsPerViewPixel);
                candidate = FocusManager.FindNextFocusableElement(FocusNavigationDirection.Right, hintRect) as Control;
                break;
        }

        if (candidate != null)
        {
            candidate.Focus(FocusState.Keyboard);
            e.Handled = true;
        }
    }
    else
    {
        // Focus is inside the ListViewItem.
        FocusNavigationDirection direction = FocusNavigationDirection.None;
        switch (e.OriginalKey)
        {
            case Windows.System.VirtualKey.GamepadDPadUp:
            case Windows.System.VirtualKey.GamepadLeftThumbstickUp:
                direction = FocusNavigationDirection.Up;
                break;
            case Windows.System.VirtualKey.GamepadDPadDown:
            case Windows.System.VirtualKey.GamepadLeftThumbstickDown:
                direction = FocusNavigationDirection.Down;
                break;
            case Windows.System.VirtualKey.GamepadDPadLeft:
            case Windows.System.VirtualKey.GamepadLeftThumbstickLeft:
                direction = FocusNavigationDirection.Left;
                break;
            case Windows.System.VirtualKey.GamepadDPadRight:
            case Windows.System.VirtualKey.GamepadLeftThumbstickRight:
                direction = FocusNavigationDirection.Right;
                break;
            default:
                break;
        }

        if (direction != FocusNavigationDirection.None)
        {
            Control candidate = FocusManager.FindNextFocusableElement(direction) as Control;
            if (candidate != null)
            {
                ListViewItem listViewItem = sender as ListViewItem;

                // If the next focusable candidate to the left is outside of ListViewItem,
                // put the focus on ListViewItem.
                if (direction == FocusNavigationDirection.Left &&
                    !listViewItem.IsAncestorOf(candidate))
                {
                    listViewItem.Focus(FocusState.Keyboard);
                }
                else
                {
                    candidate.Focus(FocusState.Keyboard);
                }
            }

            e.Handled = true;
        }
    }
}

private void listview1_ChoosingItemContainer(ListViewBase sender, ChoosingItemContainerEventArgs args)
{
    if (args.ItemContainer == null)
    {
        args.ItemContainer = new ListViewItem();
        args.ItemContainer.KeyDown += OnListViewItemKeyDown;
    }
}
```

```csharp
// DependencyObjectExtensions.cs definition.
public static class DependencyObjectExtensions
{
    public static bool IsAncestorOf(this DependencyObject parent, DependencyObject child)
    {
        DependencyObject current = child;
        bool isAncestor = false;

        while (current != null && !isAncestor)
        {
            if (current == parent)
            {
                isAncestor = true;
            }

            current = VisualTreeHelper.GetParent(current);
        }

        return isAncestor;
    }
}
```
