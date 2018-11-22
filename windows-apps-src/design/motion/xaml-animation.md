---
author: Jwmsft
ms.assetid: 0C8DEE75-FB7B-4E59-81E3-55F8D65CD982
title: アニメーションの概要
description: Windows ランタイム アニメーション ライブラリのアニメーションを使って、Windows の見た目や操作感を自分のアプリに取り入れることができます。
ms.author: jimwalk
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP
ms.localizationpriority: medium
ms.openlocfilehash: d7c3c4a9e46ce38298d7dcdd50477c4de0e9960c
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/22/2018
ms.locfileid: "7578096"
---
# <a name="animations-in-xaml"></a><span data-ttu-id="12ac5-104">XAML でのアニメーション</span><span class="sxs-lookup"><span data-stu-id="12ac5-104">Animations in XAML</span></span>

<span data-ttu-id="12ac5-105">UWP のアニメーションは、アプリに躍動感と双方向性を与えます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-105">UWP animations can enhance your app by adding movement and interactivity.</span></span> <span data-ttu-id="12ac5-106">Windows ランタイム アニメーション ライブラリのアニメーションを使って、Windows の見た目や操作感を自分のアプリに取り入れることができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-106">By using the animations from the Windows Runtime animation library, you can integrate the Windows look and feel into your app.</span></span> <span data-ttu-id="12ac5-107">ここでは、アニメーションの概要と、それぞれのアニメーションが適用される通常のシナリオ例について説明します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-107">This topic provides a summary of the animations and examples of typical scenarios where each is used.</span></span>

> [!TIP]
> <span data-ttu-id="12ac5-108">XAML 用の Windows ランタイム コントロールには、特定の種類のアニメーションが、アニメーション ライブラリから取得される組み込みの動作として含まれています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-108">The Windows Runtime controls for XAML include certain types of animations as built-in behaviors that come from an animation library.</span></span> <span data-ttu-id="12ac5-109">こうしたコントロールを利用することで、アニメーション化された見た目や操作感を自分でプログラミングしなくてもアプリに取り入れることができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-109">By using these controls in your app, you can get the animated look and feel without having to program it yourself.</span></span>

<span data-ttu-id="12ac5-110">Windows ランタイム アニメーション ライブラリのアニメーションには次のような利点があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-110">Animations from the Windows Runtime animation library provide these benefits:</span></span>

-   <span data-ttu-id="12ac5-111">「[アニメーションのガイドライン](https://msdn.microsoft.com/library/windows/apps/Dn611854)」に従った動き</span><span class="sxs-lookup"><span data-stu-id="12ac5-111">Motions that align to the [Guidelines for animations](https://msdn.microsoft.com/library/windows/apps/Dn611854)</span></span>
-   <span data-ttu-id="12ac5-112">ユーザーの気をそらさずに必要な情報を伝える、UI 状態の高速で滑らかな切り替え</span><span class="sxs-lookup"><span data-stu-id="12ac5-112">Fast, fluid transitions between UI states that inform but do not distract the user</span></span>
-   <span data-ttu-id="12ac5-113">アプリ内の画面切り替えをユーザーに示す視覚的動作</span><span class="sxs-lookup"><span data-stu-id="12ac5-113">Visual behavior that indicates transitions within an app to the user</span></span>

<span data-ttu-id="12ac5-114">たとえば、ユーザーがリストに項目を追加すると、新しい項目が即座に表示されてリストが瞬間的に更新されるのではなく、新しい項目が動きを伴ってリストの中に入ります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-114">For example, when the user adds an item to a list, instead of the new item instantly appearing in the list, the new item animates into place.</span></span> <span data-ttu-id="12ac5-115">他のリスト項目は短時間で移動されて、追加のためのスペースが確保されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-115">The other items in the list animate to their new positions over a short period of time, making room for the added item.</span></span> <span data-ttu-id="12ac5-116">この画面切り替え動作により、ユーザーはコントロールの動作をはっきりと理解することができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-116">The transition behavior here makes the control interaction more apparent to the user.</span></span>

<span data-ttu-id="12ac5-117">Windows 10 バージョン 1607 では、ナビゲーション時にビューの間でアニメーション化する要素が表示されるアニメーションを実装するために、新しい [**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx) API が導入されました。</span><span class="sxs-lookup"><span data-stu-id="12ac5-117">Windows 10, version 1607 introduces a new [**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx) API for implementing animations where an element appears to animate between views during a navigation.</span></span> <span data-ttu-id="12ac5-118">この API は、他のアニメーション ライブラリ API とは使用パターンが異なります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-118">This API has a different usage pattern from the other animation library API's.</span></span> <span data-ttu-id="12ac5-119">**ConnectedAnimationService** の使用については、[リファレンス ページ](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-119">Usage of **ConnectedAnimationService** is covered in the [reference page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx).</span></span>

<span data-ttu-id="12ac5-120">すべてのシナリオに対応するアニメーションがアニメーション ライブラリに用意されているわけではありません。</span><span class="sxs-lookup"><span data-stu-id="12ac5-120">The animation library does not provide animations for every possible scenario.</span></span> <span data-ttu-id="12ac5-121">XAML でカスタム アニメーションを作ることが必要になる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-121">There are cases where you might wish to create a custom animation in XAML.</span></span> <span data-ttu-id="12ac5-122">詳しくは、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-122">For more info, see [Storyboarded animations](storyboarded-animations.md).</span></span>

<span data-ttu-id="12ac5-123">さらに、ScrollViewer のスクロール位置に基づいた項目のアニメーション化など、特定の高度なシナリオでは、開発者がビジュアル レイヤーの相互運用を使ってカスタム アニメーションを実装することが必要になる場合があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-123">Additionally, for certain advanced scenarios like animating an item based on scroll position of a ScrollViewer, developers may wish to use Visual Layer interoperation to implement custom animations.</span></span> <span data-ttu-id="12ac5-124">詳しくは、「[ビジュアル レイヤー](https://msdn.microsoft.com/windows/uwp/composition/visual-layer)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-124">See [Visual Layer](https://msdn.microsoft.com/windows/uwp/composition/visual-layer) for more information.</span></span>

## <a name="types-of-animations"></a><span data-ttu-id="12ac5-125">アニメーションの種類</span><span class="sxs-lookup"><span data-stu-id="12ac5-125">Types of animations</span></span>

<span data-ttu-id="12ac5-126">Windows ランタイム アニメーション システムとアニメーション ライブラリには、コントロールと UI のその他の部分が動作をアニメーション化できるようにするという、より大きな目的があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-126">The Windows Runtime animation system and the animation library serve the larger goal of enabling controls and other parts of UI to have an animated behavior.</span></span> <span data-ttu-id="12ac5-127">アニメーションには、いくつかの個別の種類があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-127">There are several distinct types of animations.</span></span>

-   <span data-ttu-id="12ac5-128">*テーマ切り替え*は、UI で特定の条件が変化したときに自動的に適用されます。定義済みの Windows ランタイム XAML UI 型のコントロールまたは要素が対象になります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-128">*Theme transitions* are applied automatically when certain conditions change in the UI, involving controls or elements from the predefined Windows Runtime XAML UI types.</span></span> <span data-ttu-id="12ac5-129">これらのアニメーションは、Windows の外観と操作性をサポートし、すべてのアプリが操作モードを切り替えるときに特定の UI シナリオに対して行うことを定義しているので、*テーマ切り替え*と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-129">These are termed *theme transitions* because the animations support the Windows look and feel, and define what all apps do for particular UI scenarios when they change from one interaction mode to another.</span></span> <span data-ttu-id="12ac5-130">テーマ切り替えは、アニメーション ライブラリの一部です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-130">The theme transitions are part of the animation library.</span></span>
-   <span data-ttu-id="12ac5-131">*テーマ アニメーション*は、定義済み Windows ランタイム XAML UI 型の 1 つ以上のプロパティに対するアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-131">*Theme animations* are animations to one or more properties of predefined Windows Runtime XAML UI types.</span></span> <span data-ttu-id="12ac5-132">テーマ アニメーションは、特定の 1 要素を対象とし、コントロール内に特定の表示状態で存在するという点でテーマ切り替えとは異なります。一方、テーマ切り替えは、表示状態の外側に存在するコントロールのプロパティに割り当てられ、表示状態間の切り替えに影響を及ぼします。</span><span class="sxs-lookup"><span data-stu-id="12ac5-132">Theme animations differ from theme transitions because theme animations target one specific element and exist in specific visual states within a control, whereas the theme transitions are assigned to properties of the control that exist outside of the visual states and influence the transitions between those states.</span></span> <span data-ttu-id="12ac5-133">Windows ランタイム XAML コントロールの多くは、コントロール テンプレートの一部であり、表示状態がアニメーションのきっかけとなるテーマ アニメーションをストーリーボード内に含んでいます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-133">Many of the Windows Runtime XAML controls include theme animations within storyboards that are part of their control template, with the animations triggered by visual states.</span></span> <span data-ttu-id="12ac5-134">テンプレートを変更しない限り、UI のコントロールでこの組み込みのテーマ アニメーションを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-134">So long as you're not modifying the templates, you'll have those built-in theme animations available for the controls in your UI.</span></span> <span data-ttu-id="12ac5-135">ただし、テンプレートを置き換えた場合は、組み込みのテーマ アニメーションも削除されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-135">However, if you do replace templates, then you'll be removing the built-in control theme animations too.</span></span> <span data-ttu-id="12ac5-136">テーマ アニメーションを元に戻すには、コントロールの表示状態セット内にテーマ アニメーションを含むストーリーボードを定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-136">To get them back, you must define a storyboard that includes theme animations within the control's set of visual states.</span></span> <span data-ttu-id="12ac5-137">また、ストーリーボードから表示状態内にないテーマ アニメーションを実行し、[**Begin**](https://msdn.microsoft.com/library/windows/apps/BR210491) メソッドを使って開始することもできますが、これは一般的ではありません。</span><span class="sxs-lookup"><span data-stu-id="12ac5-137">You can also run theme animations from storyboards that aren't within visual states and start them with the [**Begin**](https://msdn.microsoft.com/library/windows/apps/BR210491) method, but that's less common.</span></span> <span data-ttu-id="12ac5-138">テーマ アニメーションはアニメーション ライブラリの一部です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-138">Theme animations are part of the animation library.</span></span>
-   <span data-ttu-id="12ac5-139">*視覚的な切り替え*は、コントロールが定義済みの 1 つの表示状態から別の状態に切り替えられたときに適用されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-139">*Visual transitions* are applied when a control transitions from one of its defined visual states to another state.</span></span> <span data-ttu-id="12ac5-140">これらは、開発者が記述するカスタム アニメーションです。通常は、コントロールのために記述したカスタム テンプレートと、そのテンプレート内の表示状態の定義に関連しています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-140">These are custom animations that you write, and are typically related to the custom template you write for a control and the visual state definitions within that template.</span></span> <span data-ttu-id="12ac5-141">アニメーションは状態間の切り替え中だけに実行され、通常は、最大でも数秒間のわずかな時間です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-141">The animation only runs during the time between states, and that's typically a short amount of time, a few seconds at most.</span></span> <span data-ttu-id="12ac5-142">詳しくは、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808#VisualTransition)」の「VisualTransition」のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-142">For more info, see ["VisualTransition" section of Storyboarded animations for visual states](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808#VisualTransition).</span></span>
-   <span data-ttu-id="12ac5-143">*ストーリーボードに設定されたアニメーション*は、時間の経過と共に Windows ランタイム依存関係プロパティの値をアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-143">*Storyboarded animations* animate the value of a Windows Runtime dependency property over time.</span></span> <span data-ttu-id="12ac5-144">ストーリーボードは、視覚的切り替えの一部として定義することも、実行時にアプリケーションによってトリガーすることもできます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-144">Storyboards can be defined as part of a visual transition, or triggered at runtime by the application.</span></span> <span data-ttu-id="12ac5-145">詳しくは、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-145">For more info, see [Storyboarded animations](storyboarded-animations.md).</span></span> <span data-ttu-id="12ac5-146">依存関係プロパティとその存在場所について詳しくは、「[依存関係プロパティの概要](https://msdn.microsoft.com/library/windows/apps/Mt185583)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-146">For more info about dependency properties and where they exist, see [Dependency properties overview](https://msdn.microsoft.com/library/windows/apps/Mt185583).</span></span>
-   <span data-ttu-id="12ac5-147">新しい [**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx) API によって提供される*接続型アニメーション*により、開発者はナビゲーション時にビューの間で要素がアニメーション化される効果を容易に作成できます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-147">*Connected animations* provided by the new [**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx) API allow developers to easily create an effect where an element appears to animate between views during a navigation.</span></span> <span data-ttu-id="12ac5-148">この API は、Windows 10 バージョン 1607 以降で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-148">This API is available starting in Windows 10, version 1607.</span></span> <span data-ttu-id="12ac5-149">詳しくは、「[**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-149">See [**ConnectedAnimationService**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.connectedanimationservice.aspx) for more information.</span></span>

## <a name="animations-available-in-the-library"></a><span data-ttu-id="12ac5-150">ライブラリに用意されているアニメーション</span><span class="sxs-lookup"><span data-stu-id="12ac5-150">Animations available in the library</span></span>

<span data-ttu-id="12ac5-151">アニメーション ライブラリには、次のアニメーションが用意されています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-151">The following animations are supplied in the animation library.</span></span> <span data-ttu-id="12ac5-152">アニメーションの名前をクリックすると、主な使用シナリオ、その定義方法、アニメーション例の詳しい情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-152">Click on the name of an animation to learn more about their main usage scenarios, how to define them, and to see an example of the animation.</span></span>

-   <span data-ttu-id="12ac5-153">[ページ切り替え](#page-transition): [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) 内のページ切り替えをアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-153">[Page transition](#page-transition): Animates page transitions in a [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682).</span></span>
-   <span data-ttu-id="12ac5-154">[コンテンツ切り替えと開始切り替え](#content-transition-and-entrance-transition): コンテンツの断片やまとまりをアニメーション化して画面に表示したり、画面から消したりします。</span><span class="sxs-lookup"><span data-stu-id="12ac5-154">[Content and entrance transition](#content-transition-and-entrance-transition): Animates one piece or set of content into or out of view.</span></span>
-   <span data-ttu-id="12ac5-155">[フェード イン/アウトとクロスフェード](#fade-in-out-and-crossfade): 一時的な要素またはコントロールを表示し、コンテンツ領域を更新します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-155">[Fade in/out, and crossfade](#fade-in-out-and-crossfade): Shows transient elements or controls, or refreshes a content area.</span></span>
-   <span data-ttu-id="12ac5-156">[ポインター アップ/ダウン](#pointer-up-down): タイルでのタップまたはクリックの視覚的なフィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-156">[Pointer up/down](#pointer-up-down): Gives visual feedback of a tap or click on a tile.</span></span>
-   <span data-ttu-id="12ac5-157">[位置の変更](#reposition): 要素を新しい位置に移動します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-157">[Reposition](#reposition): Moves an element into a new position.</span></span>
-   <span data-ttu-id="12ac5-158">[ポップアップの表示/非表示](#show-hide-popup): コンテキストに沿った UI を画面上に表示します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-158">[Show/hide popup](#show-hide-popup): Displays contextual UI on top of the view.</span></span>
-   <span data-ttu-id="12ac5-159">[エッジ (端) UI の表示/非表示](#show-hide-edge-ui): パネルのように大きな UI も含めて、端に基づく UI をスライドして画面に表示したり、画面から消したりします。</span><span class="sxs-lookup"><span data-stu-id="12ac5-159">[Show/hide edge UI](#show-hide-edge-ui): Slides edge-based UI, including large UI such as a panel, into or out of view.</span></span>
-   <span data-ttu-id="12ac5-160">[リスト項目の変更](#list-item-changes): リストについて項目の追加、項目の削除、項目の並べ替えを行います。</span><span class="sxs-lookup"><span data-stu-id="12ac5-160">[List item changes](#list-item-changes): Adds or deletes an item from a list, or reordering of the items.</span></span>
-   <span data-ttu-id="12ac5-161">[ドラッグ/ドロップ](#drag-drop): ドラッグ アンド ドロップ操作中に視覚的なフィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-161">[Drag/drop](#drag-drop): Gives visual feedback during a drag-and-drop operation.</span></span>

### <a name="page-transition"></a><span data-ttu-id="12ac5-162">ページ切り替え</span><span class="sxs-lookup"><span data-stu-id="12ac5-162">Page transition</span></span>

<span data-ttu-id="12ac5-163">アプリ内でのナビゲーションをアニメーション化するには、ページ切り替えを使います。</span><span class="sxs-lookup"><span data-stu-id="12ac5-163">Use page transitions to animate navigation within an app.</span></span> <span data-ttu-id="12ac5-164">ほぼすべてのアプリで、ある種のナビゲーションが使用されるため、ページ切り替えアニメーションはアプリで使用される最も一般的な種類のテーマ アニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-164">Since almost all apps use some kind of navigation, page transition animations are the most common type of theme animation used by apps.</span></span> <span data-ttu-id="12ac5-165">ページ切り替えの API について詳しくは、「[**NavigationThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-165">See [**NavigationThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition) for more information about the page transition APIs.</span></span>



### <a name="content-transition-and-entrance-transition"></a><span data-ttu-id="12ac5-166">コンテンツ切り替えと開始切り替え</span><span class="sxs-lookup"><span data-stu-id="12ac5-166">Content transition and entrance transition</span></span>

<span data-ttu-id="12ac5-167">コンテンツ切り替えアニメーション ([**ContentThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243103)) を使って、コンテンツの断片やまとまりを移動して現在の画面に表示したり、画面から消したりします。</span><span class="sxs-lookup"><span data-stu-id="12ac5-167">Use content transition animations ([**ContentThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243103)) to move a piece or a set of content into or out of the current view.</span></span> <span data-ttu-id="12ac5-168">たとえば、コンテンツ切り替えアニメーションは、ページが最初に読み込まれたとき、またはページの 1 セクションのコンテンツを変更したときに表示できなかったコンテンツを表示する場合に使われます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-168">For example, the content transition animations show content that was not ready to display when the page was first loaded, or when the content changes on a section of a page.</span></span>

<span data-ttu-id="12ac5-169">[**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) は、ページまたは UI の大きなセクションが最初に読み込まれたときに、コンテンツに適用できるモーションを表します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-169">[**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) represents a motion that can apply to content when a page or large section of UI is first loaded.</span></span> <span data-ttu-id="12ac5-170">したがって、最初にコンテンツを表示するときは、コンテンツ切り替え時とは異なるフィードバックとすることができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-170">Thus the first appearance of content can offer different feedback than a change to content does.</span></span> <span data-ttu-id="12ac5-171">[**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) は、既定のパラメーターを指定した場合の [**NavigationThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition) と同じですが、[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) の外部で使用できます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-171">[**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) is equivalent to a [**NavigationThemeTransition**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition) with the default parameters, but may be used outside of a [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682).</span></span>
 
 
<span id="fade-in-out-and-crossfade"/>

### <a name="fade-inout-and-crossfade"></a><span data-ttu-id="12ac5-172">フェード イン/アウトとクロスフェード</span><span class="sxs-lookup"><span data-stu-id="12ac5-172">Fade in/out, and crossfade</span></span>

<span data-ttu-id="12ac5-173">フェード イン/アウト アニメーションを使って、一時的な UI またはコントロールを表示したり、非表示にしたりします。</span><span class="sxs-lookup"><span data-stu-id="12ac5-173">Use fade in and fade out animations to show or hide transient UI or controls.</span></span> <span data-ttu-id="12ac5-174">XAML では、これは [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) として表されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-174">In XAML these are represented as [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) and [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302).</span></span> <span data-ttu-id="12ac5-175">たとえば、ユーザーの操作により新しいコントロールが表示されるアプリ バーでこのアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="12ac5-175">One example is in an app bar in which new controls can appear due to user interaction.</span></span> <span data-ttu-id="12ac5-176">また、一定期間ユーザーの入力が検出されないとフェード アウトする一時的なスクロール バーとパン インジケーターにもこのアニメーションが適用されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-176">Another example is a transient scroll bar or panning indicator that is faded out after no user input has been detected for some amount of time.</span></span> <span data-ttu-id="12ac5-177">アプリで、コンテンツが動的に読み込まれてプレースホルダー項目から最終項目に切り替わるときにもフェード イン アニメーションが使われます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-177">Apps should also use the fade in animation when they transition from a placeholder item to the final item as content loads dynamically.</span></span>

<span data-ttu-id="12ac5-178">クロスフェード アニメーションを使って、画面の現在のコンテンツを更新している場合など、項目の状態が変化しているときにスムーズに切り替えます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-178">Use a crossfade animation to smooth the transition when an item's state is changing; for example, when the app refreshes the current contents of a view.</span></span> <span data-ttu-id="12ac5-179">XAML アニメーション ライブラリには専用のクロスフェード アニメーション ([**crossFade**](https://msdn.microsoft.com/library/windows/apps/BR212661) と同等のもの) がありませんが、タイミングを重ねて [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) を使うことで同じ結果を実現できます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-179">The XAML animation library does not supply a dedicated crossfade animation (no equivalent for [**crossFade**](https://msdn.microsoft.com/library/windows/apps/BR212661)), but you can achieve the same result using [**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) and [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) with overlapped timing.</span></span>

<span id="pointer-up-down"/>

### <a name="pointer-updown"></a><span data-ttu-id="12ac5-180">ポインター アップ/ダウン</span><span class="sxs-lookup"><span data-stu-id="12ac5-180">Pointer up/down</span></span>

<span data-ttu-id="12ac5-181">[**PointerUpThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969168) アニメーションと [**PointerDownThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969164) アニメーションを使って、タイルでのタップやクリックが正常に行われたことについてユーザーにフィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-181">Use the [**PointerUpThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969168) and [**PointerDownThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/Hh969164) animations to give the user feedback for a successful tap or click on a tile.</span></span> <span data-ttu-id="12ac5-182">たとえば、ユーザーがタイルを下にクリックまたはタップすると、ポインター ダウン アニメーションが再生されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-182">For example, when a user clicks or taps down on a tile, the pointer down animation is played.</span></span> <span data-ttu-id="12ac5-183">クリックまたはタップが解放されると、ポインター アップ アニメーションが再生されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-183">Once the click or tap has been released, the pointer up animation is played.</span></span>

### <a name="reposition"></a><span data-ttu-id="12ac5-184">位置の変更</span><span class="sxs-lookup"><span data-stu-id="12ac5-184">Reposition</span></span>

<span data-ttu-id="12ac5-185">位置変更アニメーション ([**RepositionThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210421) または [**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429)) を使って、要素を新しい位置に移動します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-185">Use the reposition animations ([**RepositionThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210421) or [**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429)) to move an element into a new position.</span></span> <span data-ttu-id="12ac5-186">たとえば、項目のコントロールでヘッダーを動かすと、位置変更アニメーションが適用されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-186">For example, moving the headers in an items control uses the reposition animation.</span></span>

<span id="show-hide-popup"/>

### <a name="showhide-popup"></a><span data-ttu-id="12ac5-187">ポップアップの表示/非表示</span><span class="sxs-lookup"><span data-stu-id="12ac5-187">Show/hide popup</span></span>

<span data-ttu-id="12ac5-188">[**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210383) と [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210391) を使って、[**Popup**](https://msdn.microsoft.com/library/windows/apps/BR227842) や類似のコンテキストに沿った UI を現在の画面に表示し、画面から消します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-188">Use the [**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210383) and [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210391) when you show and hide a [**Popup**](https://msdn.microsoft.com/library/windows/apps/BR227842) or similar contextual UI on top of the current view.</span></span> <span data-ttu-id="12ac5-189">[**PopupThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969172) は、ポップアップを簡易非表示にする場合、便利なフィードバックとなるテーマ切り替えです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-189">[**PopupThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969172) is a theme transition that's useful feedback if you want to light dismiss a popup.</span></span>

<span id="show-hide-edge-ui"/>

### <a name="showhide-edge-ui"></a><span data-ttu-id="12ac5-190">エッジ (端) UI の表示/非表示</span><span class="sxs-lookup"><span data-stu-id="12ac5-190">Show/hide edge UI</span></span>

<span data-ttu-id="12ac5-191">[**EdgeUIThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh702324) アニメーションを使って、端に基づく小さい UI をスライドして画面に表示したり、画面から消したりします。</span><span class="sxs-lookup"><span data-stu-id="12ac5-191">Use the [**EdgeUIThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh702324) animation to slide small, edge-based UI into and out of view.</span></span> <span data-ttu-id="12ac5-192">たとえば、画面の上部や下部にカスタムのアプリ バーを表示したり、画面の上部にエラーや警告の UI サーフェスを表示したりするときに、これらのアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="12ac5-192">For example, use these animations when you show a custom app bar at the top or bottom of the screen or a UI surface for errors and warnings at the top of the screen.</span></span>

<span data-ttu-id="12ac5-193">ウィンドウまたはパネルの表示や非表示には [**PaneThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969160) アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="12ac5-193">Use the [**PaneThemeTransition**](https://msdn.microsoft.com/library/windows/apps/Hh969160) animation to show and hide a pane or panel.</span></span> <span data-ttu-id="12ac5-194">これはカスタム キーボードや作業ウィンドウのような端に基づく大きな UI 用です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-194">This is for large edge-based UI such as a custom keyboard or a task pane.</span></span>

### <a name="list-item-changes"></a><span data-ttu-id="12ac5-195">リスト項目の変更</span><span class="sxs-lookup"><span data-stu-id="12ac5-195">List item changes</span></span>

<span data-ttu-id="12ac5-196">[**AddDeleteThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243047) アニメーションは、既にあるリストに項目の追加時または削除時のアニメーション動作を追加するときに使います。</span><span class="sxs-lookup"><span data-stu-id="12ac5-196">Use the [**AddDeleteThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243047) animation to add animated behavior when you add or delete an item in an existing list.</span></span> <span data-ttu-id="12ac5-197">追加時の切り替えの場合、最初にリスト内の既にある項目の位置が変更され、新しい項目用のスペースが確保されてから、新しい項目が追加されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-197">For add, the transition will first reposition existing items in the list to make space for the new items, and then add the new items.</span></span> <span data-ttu-id="12ac5-198">削除時の切り替えの場合、リストから項目が削除され、必要に応じて、残りのリスト項目の位置が変更されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-198">For delete, the transition removes items from a list and, if necessary, repositions the remaining list items once the deleted items have been removed.</span></span>

<span data-ttu-id="12ac5-199">項目のリスト内の位置が変わった場合に適用される別の [**ReorderThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210409) もあります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-199">There's also a separate [**ReorderThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210409) that you apply if an item changes position in a list.</span></span> <span data-ttu-id="12ac5-200">これは、項目を削除してそれを新しい位置に追加するときに使われる関連する削除/追加アニメーションとは異なるアニメーションになります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-200">This is animated differently than deleting an item and adding it in a new place with the associated delete/add animations.</span></span>

<span data-ttu-id="12ac5-201">これらのアニメーションは、既定の [**ListView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) テンプレートと [**GridView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) テンプレートに含まれているため、これらのコントロールを既に使用している場合、これらのアニメーションを手動で追加する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="12ac5-201">Note that these animations are included in the default [**ListView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.listview.aspx) and [**GridView**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.gridview.aspx) templates so you do not need to manually add these animations if you are already using these controls.</span></span>

<span id="drag-drop"/>

### <a name="dragdrop"></a><span data-ttu-id="12ac5-202">ドラッグ/ドロップ</span><span class="sxs-lookup"><span data-stu-id="12ac5-202">Drag/drop</span></span>

<span data-ttu-id="12ac5-203">ドラッグ アニメーション ([**DragItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243173)、[**DragOverThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243177)) とドロップ アニメーション ([**DropTargetItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243185)) を使って、ユーザーが項目をドラッグまたはドロップするときに視覚的なフィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-203">Use the drag animations ([**DragItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243173), [**DragOverThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243177)) and drop animation ([**DropTargetItemThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243185)) to give visual feedback when the user drags or drops an item.</span></span>

<span data-ttu-id="12ac5-204">有効にすると、リストにドロップした項目の前後の項目の位置が変更されることがアニメーションによってユーザーに示されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-204">When active, the animations show the user that the list can be rearranged around a dropped item.</span></span> <span data-ttu-id="12ac5-205">このアニメーションを使うと、ユーザーは項目を現在の位置にドロップしたときに、項目がリスト内のどの位置に配置されるかを把握できるため便利です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-205">It is helpful for users to know where the item will be placed in a list if it is dropped at the current location.</span></span> <span data-ttu-id="12ac5-206">アニメーションでは、ドラッグしている項目を、リストの他の 2 つの項目間にドロップできること、およびそれらの項目は移動することを視覚的なフィードバックで示します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-206">The animations give visual feedback that an item being dragged can be dropped between two other items in the list and that those items will move out of the way.</span></span>

## <a name="using-animations-with-custom-controls"></a><span data-ttu-id="12ac5-207">アニメーションとカスタム コントロールの使用</span><span class="sxs-lookup"><span data-stu-id="12ac5-207">Using animations with custom controls</span></span>

<span data-ttu-id="12ac5-208">カスタマイズした Windows ランタイム コントロールを作るときに、どのアニメーションを使う必要があるかについての推奨事項を次の表にまとめます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-208">The following table summarizes our recommendations for which animation you should use when you create a custom version of these Windows Runtime controls:</span></span>

| <span data-ttu-id="12ac5-209">UI の種類</span><span class="sxs-lookup"><span data-stu-id="12ac5-209">UI type</span></span> | <span data-ttu-id="12ac5-210">推奨されるアニメーション</span><span class="sxs-lookup"><span data-stu-id="12ac5-210">Recommended animation</span></span> |
|---------|-----------------------|
| <span data-ttu-id="12ac5-211">ダイアログ ボックス</span><span class="sxs-lookup"><span data-stu-id="12ac5-211">Dialog box</span></span> | <span data-ttu-id="12ac5-212">[**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302)</span><span class="sxs-lookup"><span data-stu-id="12ac5-212">[**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) and [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302)</span></span> |
| <span data-ttu-id="12ac5-213">ポップアップ</span><span class="sxs-lookup"><span data-stu-id="12ac5-213">Flyout</span></span> | <span data-ttu-id="12ac5-214">[**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popinthemeanimation.popinthemeanimation.aspx) と [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popoutthemeanimation.popoutthemeanimation)</span><span class="sxs-lookup"><span data-stu-id="12ac5-214">[**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popinthemeanimation.popinthemeanimation.aspx) and [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popoutthemeanimation.popoutthemeanimation)</span></span> |
| <span data-ttu-id="12ac5-215">ヒント</span><span class="sxs-lookup"><span data-stu-id="12ac5-215">Tooltip</span></span> | <span data-ttu-id="12ac5-216">[**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302)</span><span class="sxs-lookup"><span data-stu-id="12ac5-216">[**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210298) and [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302)</span></span> |
| <span data-ttu-id="12ac5-217">ショートカット メニュー</span><span class="sxs-lookup"><span data-stu-id="12ac5-217">Context menu</span></span> | <span data-ttu-id="12ac5-218">[**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popinthemeanimation.popinthemeanimation.aspx) と [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popoutthemeanimation.popoutthemeanimation)</span><span class="sxs-lookup"><span data-stu-id="12ac5-218">[**PopInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popinthemeanimation.popinthemeanimation.aspx) and [**PopOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.popoutthemeanimation.popoutthemeanimation)</span></span> |
| <span data-ttu-id="12ac5-219">コマンド バー</span><span class="sxs-lookup"><span data-stu-id="12ac5-219">Command bar</span></span> | [**<span data-ttu-id="12ac5-220">EdgeUIThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-220">EdgeUIThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.edgeuithemetransition.edgeuithemetransition) |
| <span data-ttu-id="12ac5-221">作業ウィンドウまたは端に基づくパネル</span><span class="sxs-lookup"><span data-stu-id="12ac5-221">Task pane or edge-based panel</span></span> | [**<span data-ttu-id="12ac5-222">PaneThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-222">PaneThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.panethemetransition.panethemetransition) |
| <span data-ttu-id="12ac5-223">各種 UI コンテナーのコンテンツ</span><span class="sxs-lookup"><span data-stu-id="12ac5-223">Contents of any UI container</span></span> | [**<span data-ttu-id="12ac5-224">ContentThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-224">ContentThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.contentthemetransition.contentthemetransition) |
| <span data-ttu-id="12ac5-225">コントロールに対して (または他に該当するアニメーションがない場合に) 適用する</span><span class="sxs-lookup"><span data-stu-id="12ac5-225">For controls or if no other animation applies</span></span> | <span data-ttu-id="12ac5-226">[**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.fadeinthemeanimation.fadeinthemeanimation.aspx) と [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302)</span><span class="sxs-lookup"><span data-stu-id="12ac5-226">[**FadeInThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.fadeinthemeanimation.fadeinthemeanimation.aspx) and [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302)</span></span> |

 

## <a name="transition-animation-examples"></a><span data-ttu-id="12ac5-227">切り替え効果のアニメーションの例</span><span class="sxs-lookup"><span data-stu-id="12ac5-227">Transition animation examples</span></span>

<span data-ttu-id="12ac5-228">アプリが使うアニメーションは、ユーザーを困惑させることなく、ユーザー インターフェイスを豊かに、魅力的にするものであるのが理想です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-228">Ideally, your app uses animations to enhance the user interface or to make it more attractive without annoying your users.</span></span> <span data-ttu-id="12ac5-229">1 つの方法は、切り替え効果のアニメーションを UI に適用することです。画面に何かが出入りするなど、何かの変化が起きたときに、アニメーションによって、その変化にユーザーの注意を惹き付けます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-229">One way you can do this is to apply animated transitions to UI so that when something enters or leaves the screen or otherwise changes, the animation draws the attention of the user to the change.</span></span> <span data-ttu-id="12ac5-230">たとえば、ボタンの場合、単に画面に表示したり画面から消したりするのではなく、フェード イン/フェード アウトさせるようにします。</span><span class="sxs-lookup"><span data-stu-id="12ac5-230">For example, your buttons may rapidly fade in and out of view rather than just appear and disappear.</span></span> <span data-ttu-id="12ac5-231">一貫性のあるお勧めの (標準的な) 切り替え効果アニメーションを作ることができる API を多数用意しました。</span><span class="sxs-lookup"><span data-stu-id="12ac5-231">We created a number of APIs that can be used to create recommended or typical animation transitions that are consistent.</span></span> <span data-ttu-id="12ac5-232">ここでは、ボタンがスライドしながら勢いよく画面に表示されるアニメーションの適用方法を紹介します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-232">The example here shows how to apply an animation to a button so that it swiftly slides into view.</span></span>

```xml
<Button Content="Transitioning Button">
     <Button.Transitions>
         <TransitionCollection> 
             <EntranceThemeTransition/>
         </TransitionCollection>
     </Button.Transitions>
 </Button>
 ```

<span data-ttu-id="12ac5-233">このコードでは、ボタンの切り替え効果のコレクション (TransitionCollection) に [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) オブジェクトを追加します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-233">In this code, we add the [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) object to the transition collection of the button.</span></span> <span data-ttu-id="12ac5-234">これで、ボタンが最初にレンダリングされるときに、ただ表示されるのではなく、スライドしながら勢いよく画面に表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-234">Now, when the button is first rendered, it swiftly slides into view rather than just appear.</span></span> <span data-ttu-id="12ac5-235">アニメーション オブジェクトには、スライドする距離と方向を調整する目的でいくつかのプロパティを設定できますが、API としては、特定のシナリオ、つまり、出入り口 (entrance) を目立たせることを意図した非常に単純なものです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-235">You can set a few properties on the animation object in order to adjust how far it slides and from what direction, but it's really meant to be a simple API for a specific scenario, that is, to make an eye-catching entrance.</span></span>

<span data-ttu-id="12ac5-236">切り替え効果のアニメーションのテーマをアプリのスタイル リソースで定義して、統一感のある効果を適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-236">You can also define transition animation themes in the style resources of your app, allowing you to apply the effect uniformly.</span></span> <span data-ttu-id="12ac5-237">先ほどの例に相当する内容を [**Style**](https://msdn.microsoft.com/library/windows/apps/BR208849) を使って実現したのが次のコードです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-237">This example is equivalent to the previous one, only it is applied using a [**Style**](https://msdn.microsoft.com/library/windows/apps/BR208849):</span></span>

```xml
<UserControl.Resources>
     <Style x:Key="DefaultButtonStyle" TargetType="Button">
         <Setter Property="Transitions">
             <Setter.Value>
                 <TransitionCollection>
                     <EntranceThemeTransition/>
                 </TransitionCollection>
             </Setter.Value>
        </Setter>
    </Style>
</UserControl.Resources>
      
<StackPanel x:Name="LayoutRoot">
    <Button Style="{StaticResource DefaultButtonStyle}" Content="Transitioning Button"/>
</StackPanel>
```

<span data-ttu-id="12ac5-238">これまでの例では、テーマ切り替えを個々のコントロールに適用していましたが、それをオブジェクトのコンテナーに適用すると、もっとおもしろいことが起こります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-238">The previous examples apply a theme transition to an individual control, however, theme transitions are even more interesting when you apply them to a container of objects.</span></span> <span data-ttu-id="12ac5-239">コンテナーに含まれているすべての子オブジェクトに、切り替え効果が適用されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-239">When you do this, all the child objects of the container take part in the transition.</span></span> <span data-ttu-id="12ac5-240">次の例では、[**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) を四角形から成る [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) に適用しています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-240">In the following example, an [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) is applied to a [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) of rectangles.</span></span>

```xml
<!-- If you set an EntranceThemeTransition animation on a panel, the
     children of the panel will automatically offset when they animate
     into view to create a visually appealing entrance. -->        
<ItemsControl Grid.Row="1" x:Name="rectangleItems">
    <ItemsControl.ItemContainerTransitions>
        <TransitionCollection>
            <EntranceThemeTransition/>
        </TransitionCollection>
    </ItemsControl.ItemContainerTransitions>
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <WrapGrid Height="400"/>
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>
            
    <!-- The sequence children appear depends on their order in 
         the panel's children, not necessarily on where they render
         on the screen. Be sure to arrange your child elements in
         the order you want them to transition into view. -->
    <ItemsControl.Items>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
    </ItemsControl.Items>
</ItemsControl>
```

<span data-ttu-id="12ac5-241">切り替え効果が適用された [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) の子である四角形が次々に表示され、見ていて楽しい気分になります。同じアニメーションを個々の四角形に適用した場合は、すべての四角形がいっせいに表示されますが、それとは対照的です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-241">The child rectangles of the [**Grid**](https://msdn.microsoft.com/library/windows/apps/BR242704) transition into view one after the other in a visually pleasing way rather than all at once as would be the case if you applied this animation to the rectangles individually.</span></span>

<span data-ttu-id="12ac5-242">このアニメーションのデモを次に示します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-242">Here's a demonstration of this animation:</span></span>

![子である四角形をビューに切り替えて表示するアニメーション](./images/animation-child-rectangles.gif)

<span data-ttu-id="12ac5-244">いずれかの子の位置が変化した場合は、コンテナーの子オブジェクトを再度流し込むことができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-244">Child objects of a container can also re-flow when one or more of those children change position.</span></span> <span data-ttu-id="12ac5-245">次の例では、[**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429) を四角形から成るグリッドに適用しています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-245">In the following example, we apply a [**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429) to a grid of rectangles.</span></span> <span data-ttu-id="12ac5-246">いずれかの四角形を削除すると、その他すべての四角形が新しい位置に再度流し込まれます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-246">When you remove one of the rectangles, all the other rectangles re-flow into their new position.</span></span>

```xml
<Button Content="Remove Rectangle" Click="RemoveButton_Click"/>
        
<ItemsControl Grid.Row="1" x:Name="rectangleItems">
    <ItemsControl.ItemContainerTransitions>
        <TransitionCollection>
                    
            <!-- Without this, there would be no animation when items 
                 are removed. -->
            <RepositionThemeTransition/>
        </TransitionCollection>
    </ItemsControl.ItemContainerTransitions>
    <ItemsControl.ItemsPanel>
        <ItemsPanelTemplate>
            <WrapGrid Height="400"/>
        </ItemsPanelTemplate>
    </ItemsControl.ItemsPanel>
            
    <!-- All these rectangles are just to demonstrate how the items
         in the grid re-flow into position when one of the child items
         are removed. -->
    <ItemsControl.Items>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
        <Rectangle Fill="Red" Width="100" Height="100" Margin="10"/>
    </ItemsControl.Items>
</ItemsControl>
```

```cs
private void RemoveButton_Click(object sender, RoutedEventArgs e)
{
    if (rectangleItems.Items.Count > 0)
    {    
        rectangleItems.Items.RemoveAt(0);
    }                         
}
```

```cpp
// .h
private:
void RemoveButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e);

//.cpp
void BlankPage::RemoveButton_Click(Platform::Object^ sender, Windows::UI::Xaml::RoutedEventArgs^ e)
{
    if (rectangleItems->Items->Size > 0)
    {    
        rectangleItems->Items->RemoveAt(0);
    }
}
```

<span data-ttu-id="12ac5-247">切り替え効果のアニメーションは、1 つのオブジェクトまたは 1 つのオブジェクト コンテナーに対し複数適用することができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-247">You can apply multiple transition animations to a single object or object container.</span></span> <span data-ttu-id="12ac5-248">たとえば、アニメーションで表示する一連の四角形があり、四角形の位置が変化したときにもアニメーションを適用する必要がある場合、[**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429) と [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) を次のように適用します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-248">For example, if you want the list of rectangles to animate into view and also animate when they change position, you can apply the [**RepositionThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210429) and [**EntranceThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR210288) like this:</span></span>

```xml
...
<ItemsControl.ItemContainerTransitions>
    <TransitionCollection>
        <EntranceThemeTransition/>                    
        <RepositionThemeTransition/>
    </TransitionCollection>
</ItemsControl.ItemContainerTransitions>
...      
```

<span data-ttu-id="12ac5-249">切り替え効果には、さまざまな種類が存在し、UI 要素の追加時、削除時、並べ替え時などに、それに応じたアニメーションを適用することができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-249">There are several transition effects to create animations on your UI elements as they are added, removed, reordered, and so on.</span></span> <span data-ttu-id="12ac5-250">これらの API はすべて、名前に "ThemeTransition" という単語が含まれています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-250">The names of these APIs all contain "ThemeTransition":</span></span>

| <span data-ttu-id="12ac5-251">API</span><span class="sxs-lookup"><span data-stu-id="12ac5-251">API</span></span> | <span data-ttu-id="12ac5-252">説明</span><span class="sxs-lookup"><span data-stu-id="12ac5-252">Description</span></span> |
|-----|-------------|
| [**<span data-ttu-id="12ac5-253">NavigationThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-253">NavigationThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.navigationthemetransition) | <span data-ttu-id="12ac5-254">[**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682) 内でのページ ナビゲーションに Windows パーソナリティ アニメーションを提供します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-254">Provides a Windows personality animation for page navigation in a [**Frame**](https://msdn.microsoft.com/library/windows/apps/br242682).</span></span> |
| [**<span data-ttu-id="12ac5-255">AddDeleteThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-255">AddDeleteThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243047) | <span data-ttu-id="12ac5-256">コントロールの子やコンテンツが追加されたり削除されたりしたときの切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-256">Provides the animated transition behavior for when controls add or delete children or content.</span></span> <span data-ttu-id="12ac5-257">ここでいうコントロールは通常、項目コンテナーです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-257">Typically the control is an item container.</span></span> |
| [**<span data-ttu-id="12ac5-258">ContentThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-258">ContentThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243103) | <span data-ttu-id="12ac5-259">コントロールのコンテンツが変化しているときの切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-259">Provides the animated transition behavior for when the content of a control is changing.</span></span> <span data-ttu-id="12ac5-260">このアニメーションは、[**AddDeleteThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243047) に追加する形で適用することができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-260">You can apply this in addition to [**AddDeleteThemeTransition**](https://msdn.microsoft.com/library/windows/apps/BR243047).</span></span> |
| [**<span data-ttu-id="12ac5-261">EdgeUIThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-261">EdgeUIThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/Hh702324) | <span data-ttu-id="12ac5-262">(小さい) エッジ UI の切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-262">Provides the animated transition behavior for a (small) edge UI transition.</span></span> |
| [**<span data-ttu-id="12ac5-263">EntranceThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-263">EntranceThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210288) | <span data-ttu-id="12ac5-264">コントロールが最初に表示されるときの切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-264">Provides the animated transition behavior for when controls first appear.</span></span> |
| [**<span data-ttu-id="12ac5-265">PaneThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-265">PaneThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/Hh969160) | <span data-ttu-id="12ac5-266">パネル (大きなエッジ UI) の切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-266">Provides the animated transition behavior for a panel (large edge UI) UI transition.</span></span> |
| [**<span data-ttu-id="12ac5-267">PopupThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-267">PopupThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/Hh969172) | <span data-ttu-id="12ac5-268">コントロールのポップイン コンポーネント (オブジェクトに関するツールヒント風の UI など) が表示されるときに適用される切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-268">Provides the animated transition behavior that applies to pop-in components of controls (for example, tooltip-like UI on an object) as they appear.</span></span> |
| [**<span data-ttu-id="12ac5-269">ReorderThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-269">ReorderThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210409) | <span data-ttu-id="12ac5-270">リスト ビュー コントロールの項目の順序が変わったときの切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-270">Provides the animated transition behavior for when list-view controls items change order.</span></span> <span data-ttu-id="12ac5-271">通常、この変化は、ドラッグ アンド ドロップ操作の結果として起こります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-271">Typically this happens as a result of a drag-drop operation.</span></span> <span data-ttu-id="12ac5-272">コントロールやテーマの種類によって、アニメーションの特性が異なる場合があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-272">Different controls and themes can have varying characteristics for the animations.</span></span> |
| [**<span data-ttu-id="12ac5-273">RepositionThemeTransition</span><span class="sxs-lookup"><span data-stu-id="12ac5-273">RepositionThemeTransition</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210429) | <span data-ttu-id="12ac5-274">コントロールの位置が変わったときの切り替え動作のアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-274">Provides the animated transition behavior for when controls change position.</span></span> |

 

## <a name="theme-animation-examples"></a><span data-ttu-id="12ac5-275">テーマ アニメーションの例</span><span class="sxs-lookup"><span data-stu-id="12ac5-275">Theme animation examples</span></span>

<span data-ttu-id="12ac5-276">切り替え効果のアニメーションは簡単に適用できます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-276">Transition animations are simple to apply.</span></span> <span data-ttu-id="12ac5-277">しかし、場合によっては、アニメーション効果のタイミングや順序をもっと細かく制御する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-277">But you may want to have a bit more control over the timing and order of your animation effects.</span></span> <span data-ttu-id="12ac5-278">テーマ アニメーションを使うと、アニメーションの動作に一貫したテーマを使いながら、より細かな制御を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-278">You can use theme animations to enable more control while still using a consistent theme for how your animation behaves.</span></span> <span data-ttu-id="12ac5-279">テーマ アニメーションも、カスタム アニメーションよりマークアップを少なくする必要があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-279">Theme animations also require less markup than custom animations.</span></span> <span data-ttu-id="12ac5-280">ここでは、[**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) を使って、四角形をフェード アウトさせています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-280">Here, we use the [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) to make a rectangle fade out of view.</span></span>

```xml
<StackPanel>    
    <StackPanel.Resources>
        <Storyboard x:Name="myStoryboard">
            <FadeOutThemeAnimation TargetName="myRectangle" />
        </Storyboard>
    </StackPanel.Resources>
    <Rectangle PointerPressed="Rectangle_Tapped" x:Name="myRectangle"  
              Fill="Blue" Width="200" Height="300"/>
</StackPanel>
```

```cs
// When the user taps the rectangle, the animation begins.
private void Rectangle_Tapped(object sender, PointerRoutedEventArgs e)
{
    myStoryboard.Begin();
}
```

```vb
' When the user taps the rectangle, the animation begins.
Private Sub Rectangle_Tapped(sender As Object, e As PointerRoutedEventArgs)
    myStoryboard.Begin()
End Sub
```

```cpp
//.h
void Rectangle_Tapped(Platform::Object^ sender, Windows::UI::Xaml::Input::PointerRoutedEventArgs^ e);

//.cpp
void BlankPage::Rectangle_Tapped(Object^ sender, PointerRoutedEventArgs^ e)
{
    myStoryboard->Begin();
}
```

<span data-ttu-id="12ac5-281">切り替え効果のアニメーションとは異なり、テーマ アニメーションでは、アニメーションを自動的に実行する組み込みのトリガー (切り替え) がありません。</span><span class="sxs-lookup"><span data-stu-id="12ac5-281">Unlike transition animations, a theme animation doesn't have a built-in trigger (the transition) that runs it automatically.</span></span> <span data-ttu-id="12ac5-282">XAML でテーマ アニメーションを定義するときは、[**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490) を使ってそれを格納する必要があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-282">You must use a [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490) to contain a theme animation when you define it in XAML.</span></span> <span data-ttu-id="12ac5-283">アニメーションの既定の動作を変更することもできます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-283">You can also change the default behavior of the animation.</span></span> <span data-ttu-id="12ac5-284">たとえば、[**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302) の [**Duration**](https://msdn.microsoft.com/library/windows/apps/BR243207) の時間値を増やすと、フェード アウトの速度を遅くすることができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-284">For example, you can slow down the fade-out by increasing the [**Duration**](https://msdn.microsoft.com/library/windows/apps/BR243207) time value on the [**FadeOutThemeAnimation**](https://msdn.microsoft.com/library/windows/apps/BR210302).</span></span>

<span data-ttu-id="12ac5-285">**注:** 基本的なアニメーション技法を示すためを使用しますアプリ コードに[**ストーリー ボード**](https://msdn.microsoft.com/library/windows/apps/BR210490)のメソッドを呼び出すことによって、アニメーションを開始します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-285">**Note**For purposes of showing basic animation techniques, we're using app code to start the animation by calling methods of [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490).</span></span> <span data-ttu-id="12ac5-286">**Storyboard** クラスの [**Begin**](https://msdn.microsoft.com/library/windows/apps/BR210491)、[**Stop**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.stop)、[**Pause**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.pause.aspx)、[**Resume**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.resume.aspx) の各メソッドを使うと、**Storyboard** アニメーションを実行する方法を制御できます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-286">You can control how the **Storyboard** animations run using the [**Begin**](https://msdn.microsoft.com/library/windows/apps/BR210491), [**Stop**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.stop), [**Pause**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.pause.aspx), and [**Resume**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.storyboard.resume.aspx) **Storyboard** methods.</span></span> <span data-ttu-id="12ac5-287">ただし、これはライブラリ アニメーションをアプリに含める通常の方法ではありません。</span><span class="sxs-lookup"><span data-stu-id="12ac5-287">However, that's not typically how you include library animations in apps.</span></span> <span data-ttu-id="12ac5-288">むしろ、通常は、コントロールまたは要素に適用される XAML スタイルとテンプレートにライブラリ アニメーションを統合します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-288">Rather, you usually integrate the library animations into the XAML styles and templates applied to controls or elements.</span></span> <span data-ttu-id="12ac5-289">テンプレートと表示状態の説明はもう少し込み入ったものになります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-289">Learning about templates and visual states is a little more involved.</span></span> <span data-ttu-id="12ac5-290">ただし、表示状態でライブラリ アニメーションを使用する方法については、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808)」トピックの一部として取り上げています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-290">But we do cover how you'd use library animations in visual states as part of the [Storyboarded animations for visual states](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808) topic.</span></span>

 

<span data-ttu-id="12ac5-291">そのほかにもさまざまなテーマ アニメーションを UI 要素に適用して、アニメーション効果を作ることができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-291">You can apply several other theme animations to your UI elements to create animation effects.</span></span> <span data-ttu-id="12ac5-292">これらの API はすべて、名前に "ThemeAnimation" という単語が含まれています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-292">The names of these API all contain "ThemeAnimation":</span></span>

| <span data-ttu-id="12ac5-293">API</span><span class="sxs-lookup"><span data-stu-id="12ac5-293">API</span></span> | <span data-ttu-id="12ac5-294">説明</span><span class="sxs-lookup"><span data-stu-id="12ac5-294">Description</span></span> |
|-----|-------------|
| [**<span data-ttu-id="12ac5-295">DragItemThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-295">DragItemThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243173) | <span data-ttu-id="12ac5-296">ドラッグされている項目要素に適用される事前構成済みのアニメーションを表します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-296">Represents the preconfigured animation that applies to item elements being dragged.</span></span> |
| [**<span data-ttu-id="12ac5-297">DragOverThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-297">DragOverThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243177) | <span data-ttu-id="12ac5-298">ドラッグされている要素の下にある要素に適用される事前構成済みのアニメーションを表します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-298">Represents the preconfigured animation that applies to the elements underneath an element being dragged.</span></span> |
| [**<span data-ttu-id="12ac5-299">DropTargetItemThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-299">DropTargetItemThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR243185) | <span data-ttu-id="12ac5-300">ドロップ先となりうる要素に適用される事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-300">The preconfigured animation that applies to potential drop target elements.</span></span> |
| [**<span data-ttu-id="12ac5-301">FadeInThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-301">FadeInThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210298) | <span data-ttu-id="12ac5-302">透明から不透明への変化を表す事前構成済みのアニメーションです。コントロールが最初に表示されるときに適用されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-302">The preconfigured opacity animation that applies to controls when they first appear.</span></span> |
| [**<span data-ttu-id="12ac5-303">FadeOutThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-303">FadeOutThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210302) | <span data-ttu-id="12ac5-304">透明から不透明への変化を表す事前構成済みのアニメーションです。コントロールが UI から削除されたり非表示になるときに適用されます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-304">The preconfigured opacity animation that applies to controls when they are removed from UI or hidden.</span></span> |
| [**<span data-ttu-id="12ac5-305">PointerDownThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-305">PointerDownThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/Hh969164) | <span data-ttu-id="12ac5-306">項目または要素をタップまたはクリックするユーザー操作の事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-306">The preconfigured animation for user action that taps or clicks an item or element.</span></span> |
| [**<span data-ttu-id="12ac5-307">PointerUpThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-307">PointerUpThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/Hh969168) | <span data-ttu-id="12ac5-308">ユーザーが項目または要素をタップし、指を離すと実行される事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-308">The preconfigured animation for user action that runs after a user taps down on an item or element and the action is released.</span></span> |
| [**<span data-ttu-id="12ac5-309">PopInThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-309">PopInThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210383) | <span data-ttu-id="12ac5-310">コントロールのポップイン コンポーネントが表示されるときに適用される事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-310">The preconfigured animation that applies to pop-in components of controls as they appear.</span></span> <span data-ttu-id="12ac5-311">このアニメーションには、不透明度と変換が組み合わされています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-311">This animation combines opacity and translation.</span></span> |
| [**<span data-ttu-id="12ac5-312">PopOutThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-312">PopOutThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210391) | <span data-ttu-id="12ac5-313">コントロールのポップイン コンポーネントが閉じたり削除されたりするときに適用される事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-313">The preconfigured animation that applies to pop-in components of controls as they are closed or removed.</span></span> <span data-ttu-id="12ac5-314">このアニメーションには、不透明度と変換が組み合わされています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-314">This animation combines opacity and translation.</span></span> |
| [**<span data-ttu-id="12ac5-315">RepositionThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-315">RepositionThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210421) | <span data-ttu-id="12ac5-316">オブジェクトの位置が変更されたときに適用される事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-316">The preconfigured animation for an object as it is repositioned.</span></span> |
| [**<span data-ttu-id="12ac5-317">SplitCloseThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-317">SplitCloseThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210454) | <span data-ttu-id="12ac5-318">[**ComboBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) を開閉するときのスタイルのアニメーションでターゲット UI を非表示にする事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-318">The preconfigured animation that conceals a target UI using an animation in the style of a [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) opening and closing.</span></span> |
| [**<span data-ttu-id="12ac5-319">SplitOpenThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-319">SplitOpenThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/BR210472) | <span data-ttu-id="12ac5-320">[**ComboBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) を開閉するときのスタイルのアニメーションでターゲット UI を表示する事前構成済みのアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="12ac5-320">The preconfigured animation that reveals a target UI using an animation in the style of a [**ComboBox**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.combobox.aspx) opening and closing.</span></span> |
| [**<span data-ttu-id="12ac5-321">DrillInThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-321">DrillInThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.drillinthemeanimation) | <span data-ttu-id="12ac5-322">マスター ページから詳細ページのように、ユーザーが論理階層を順方向に移動するときに実行される事前構成済みのアニメーションを表します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-322">Represents a preconfigured animation that runs when a user navigates forward in a logical hierarchy, like from a master page to a detail page.</span></span> |
| [**<span data-ttu-id="12ac5-323">DrillOutThemeAnimation</span><span class="sxs-lookup"><span data-stu-id="12ac5-323">DrillOutThemeAnimation</span></span>**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.animation.drilloutthemeanimation.aspx) | <span data-ttu-id="12ac5-324">詳細ページからマスター ページのように、ユーザーが論理階層を逆方向に移動するときに実行される事前構成済みのアニメーションを表します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-324">Represents a preconfigured animation that runs when a user navigates backward in a logical hierarchy, like from a detail page to a master page.</span></span> |

 

## <a name="create-your-own-animations"></a><span data-ttu-id="12ac5-325">カスタム アニメーションの作成</span><span class="sxs-lookup"><span data-stu-id="12ac5-325">Create your own animations</span></span>

<span data-ttu-id="12ac5-326">テーマ アニメーションでは自分のニーズが満たせない場合は、アニメーションを独自に作ることができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-326">When theme animations are not enough for your needs, you can create your own animations.</span></span> <span data-ttu-id="12ac5-327">オブジェクトのプロパティ値のいくつかをアニメーション化することによって、オブジェクトに動きを与えることができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-327">You animate objects by animating one or more of their property values.</span></span> <span data-ttu-id="12ac5-328">たとえば、四角形の幅や [**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/BR242932) の角度、ボタンの色の値をアニメーション化することができます。</span><span class="sxs-lookup"><span data-stu-id="12ac5-328">For example, you can animate the width of a rectangle, the angle of a [**RotateTransform**](https://msdn.microsoft.com/library/windows/apps/BR242932), or the color value of a button.</span></span> <span data-ttu-id="12ac5-329">この種のカスタム アニメーションは、事前構成済みのアニメーションの種類として Windows ランタイムに既に用意されているライブラリ アニメーションと区別するために、"ストーリーボードに設定されたアニメーション" と呼ばれています。</span><span class="sxs-lookup"><span data-stu-id="12ac5-329">We term this type of custom animation a storyboarded animation, to distinguish it from the library animations that the Windows Runtime already provides as a preconfigured animation type.</span></span> <span data-ttu-id="12ac5-330">ストーリーボードに設定されたアニメーションの場合、特定の型の値を変更できるアニメーション (**Double** をアニメーションできる [**DoubleAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243136) など) を使い、そのアニメーションを [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490) 内に配置して制御します。</span><span class="sxs-lookup"><span data-stu-id="12ac5-330">For storyboarded animations, you use an animation that can change values of a particular type (for example [**DoubleAnimation**](https://msdn.microsoft.com/library/windows/apps/BR243136) to animate a **Double**) and put that animation within a [**Storyboard**](https://msdn.microsoft.com/library/windows/apps/BR210490) to control it.</span></span>

<span data-ttu-id="12ac5-331">アニメーション化するためには、アニメーション化しているプロパティが*依存関係プロパティ*である必要があります。</span><span class="sxs-lookup"><span data-stu-id="12ac5-331">In order to be animated, the property you are animating must be a *dependency property*.</span></span> <span data-ttu-id="12ac5-332">依存関係プロパティについて詳しくは、「[依存関係プロパティの概要](https://msdn.microsoft.com/library/windows/apps/Mt185583)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-332">For more info about dependency properties, see [Dependency properties overview](https://msdn.microsoft.com/library/windows/apps/Mt185583).</span></span> <span data-ttu-id="12ac5-333">ストーリーボードに設定されたカスタム アニメーションの作成について詳しくは、対象に選ぶ方法や制御方法も含め、「[ストーリーボードに設定されたアニメーション](storyboarded-animations.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-333">For more info on creating custom storyboarded animations, including how to target and control them, see [Storyboarded animations](storyboarded-animations.md).</span></span>

<span data-ttu-id="12ac5-334">ストーリーボードに設定されたカスタム アニメーションを定義する際に XAML のアプリ UI 定義で最大となるのは、XAML でコントロールの表示状態を定義する場合です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-334">The biggest area of app UI definition in XAML where you'll define custom storyboarded animations is if you are defining visual states for controls in XAML.</span></span> <span data-ttu-id="12ac5-335">これを行うのは、新たにコントロール クラスを作成するか、既にあるコントロールのうち、コントロール テンプレートに表示状態があるものに対してもう一度テンプレートを作成する場合です。</span><span class="sxs-lookup"><span data-stu-id="12ac5-335">You'll be doing this either because you are creating a new control class, or because you are re-templating an existing control that has visual states in its control template.</span></span> <span data-ttu-id="12ac5-336">詳しくは、「[表示状態用にストーリーボードに設定されたアニメーション](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="12ac5-336">For more info, see [Storyboarded animations for visual states](https://msdn.microsoft.com/library/windows/apps/xaml/JJ819808).</span></span>

 

 




