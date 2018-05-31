---
author: serenaz
Description: Learn how to use page transitions in your UWP apps.
title: UWP アプリのページ切り替え効果
template: detail.hbs
ms.author: sezhen
ms.date: 04/08/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10、UWP
pm-contact: stmoy
ms.localizationpriority: medium
ms.openlocfilehash: dc42199eba00071f5dbabd83a4ae524298a619ee
ms.sourcegitcommit: 91511d2d1dc8ab74b566aaeab3ef2139e7ed4945
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 04/30/2018
ms.locfileid: "1818436"
---
# <a name="page-transitions"></a><span data-ttu-id="c1388-103">ページ切り替え効果</span><span class="sxs-lookup"><span data-stu-id="c1388-103">Page transitions</span></span>

<span data-ttu-id="c1388-104">ページ切り替え効果は、ユーザーがアプリ内のページ間を移動するときに再生されるアニメーションです。</span><span class="sxs-lookup"><span data-stu-id="c1388-104">Page transitions are animations that play when users navigate between pages in an app, providing feedback as the relationship between pages.</span></span> <span data-ttu-id="c1388-105">ページ切り替え効果により、ナビゲーション階層の最上位にいるのか、兄弟ページ間を移動しているのか、またはページ階層をより深く移動しているのかを、ユーザーが理解しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="c1388-105">Page transitions help users understand if they are at the top of a navigation hierarchy, moving between sibling pages, or navigating deeper into the page hierarchy.</span></span>

<span data-ttu-id="c1388-106">アプリ内のページ間のナビゲーションについて 2 つの異なるアニメーション (*ページの更新*および*ドリル*) が提供されており、[NavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo)のサブクラスとして表されています。</span><span class="sxs-lookup"><span data-stu-id="c1388-106">Two different animations are provided for navigation between pages in an app, *page refresh* and *drill*, and are represented by subclasses of [NavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo).</span></span>

## <a name="page-refresh"></a><span data-ttu-id="c1388-107">ページの更新</span><span class="sxs-lookup"><span data-stu-id="c1388-107">Page refresh</span></span>

<span data-ttu-id="c1388-108">ページの更新は、受信したコンテンツのスライド アップ アニメーションとフェード イン アニメーションの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="c1388-108">Page refresh is a combination of a slide up animation and a fade in animation for the incoming content.</span></span> <span data-ttu-id="c1388-109">ユーザーが処理を開始したという意識を持てるようにします。</span><span class="sxs-lookup"><span data-stu-id="c1388-109">The desired feeling is that the user has started over.</span></span>

<span data-ttu-id="c1388-110">ページの更新は、ユーザーがナビゲーション スタックの最上位に移動したときに使用します ([タブ](../controls-and-patterns/tabs-pivot.md) 間や[左側のナビゲーション](../controls-and-patterns/navigationview.md)の項目間の移動など)。</span><span class="sxs-lookup"><span data-stu-id="c1388-110">Use page refresh when the user is taken to the top of a navigational stack, such as navigating between [tabs](../controls-and-patterns/tabs-pivot.md) or [left-nav](../controls-and-patterns/navigationview.md) items.</span></span> <span data-ttu-id="c1388-111">既定では、[Frame.Navigate()](/uwp/api/windows.ui.xaml.controls.frame.navigate)はページの更新を使用します。</span><span class="sxs-lookup"><span data-stu-id="c1388-111">By default, [Frame.Navigate()](/uwp/api/windows.ui.xaml.controls.frame.navigate) uses page refresh.</span></span>

![ページの更新のアニメーション](images/page-refresh.gif)

<span data-ttu-id="c1388-113">ページの更新のアニメーションは、[EntranceNavigationTransitionInfoClass](/uwp/api/windows.ui.xaml.media.animation.entrancenavigationtransitioninfo) で表されます。</span><span class="sxs-lookup"><span data-stu-id="c1388-113">The page refresh animation is represented by the [EntranceNavigationTransitionInfoClass](/uwp/api/windows.ui.xaml.media.animation.entrancenavigationtransitioninfo).</span></span>

```csharp
// Explicitly play the page refresh animation
myFrame.Navigate(typeof(Page2), null, new EntranceNavigationTransitionInfo());
```

## <a name="drill"></a><span data-ttu-id="c1388-114">ドリル</span><span class="sxs-lookup"><span data-stu-id="c1388-114">Drill</span></span>

<span data-ttu-id="c1388-115">ドリルは、項目を選択した後で詳細情報を表示するなど、ユーザーがアプリ内でより深く移動するときに使用します。</span><span class="sxs-lookup"><span data-stu-id="c1388-115">Use drill when users navigate deeper into an app, such as displaying more information after selecting an item.</span></span>

<span data-ttu-id="c1388-116">ユーザーがアプリ内をより深く移動したという意識を持てるようにします。</span><span class="sxs-lookup"><span data-stu-id="c1388-116">The desired feeling is that the user has gone deeper into the app.</span></span>

![ドリルのアニメーション](images/drill.gif)

<span data-ttu-id="c1388-118">ドリルのアニメーションは、[DrillInNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.drillinnavigationtransitioninfo) クラスで表されます。</span><span class="sxs-lookup"><span data-stu-id="c1388-118">The drill animation is represented by the [DrillInNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.drillinnavigationtransitioninfo) class.</span></span>

```csharp
// Play the drill in animation
myFrame.Navigate(typeof(Page2), null, new DrillInNavigationTransitionInfo());
```

## <a name="suppress"></a><span data-ttu-id="c1388-119">抑制</span><span class="sxs-lookup"><span data-stu-id="c1388-119">Suppress</span></span>

<span data-ttu-id="c1388-120">アニメーションの抑制は、[接続型アニメーション](connected-animation.md)または暗黙的な表示/非表示アニメーションを使用して独自の切り替え効果を作成している場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c1388-120">Suppressing the animation is useful if you are building your own transition using [Connected Animations](connected-animation.md) or implicit show/hide animations.</span></span>

<span data-ttu-id="c1388-121">ナビゲーション中にアニメーションの再生を回避するには、[SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) を他の [NavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo) サブタイプの代わりに使用します。</span><span class="sxs-lookup"><span data-stu-id="c1388-121">To avoid playing any animation during navigation, use [SuppressNavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) in the place of other [NavigationTransitionInfo](/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo) subtypes.</span></span>

```csharp
// Suppress the default animation
myFrame.Navigate(typeof(Page2), null, new SuppressNavigationTransitionInfo());
```

## <a name="backwards-navigation"></a><span data-ttu-id="c1388-122">逆方向のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="c1388-122">Backwards navigation</span></span>

<span data-ttu-id="c1388-123">既定では、[Frame.GoBack()](/uwp/api/windows.ui.xaml.controls.frame.goback) は、ページへの移動時に再生されるアニメーションに基づいて、対応する "戻る" アニメーションを再生します。</span><span class="sxs-lookup"><span data-stu-id="c1388-123">By default, [Frame.GoBack()](/uwp/api/windows.ui.xaml.controls.frame.goback) plays the corresponding "go back" animation based on the animation played to navigate to the page.</span></span> <span data-ttu-id="c1388-124">たとえば、ページへの移動にドリルを使用するアプリでは、ユーザーが逆方向に移動するときにドリルアウトが表示されます。</span><span class="sxs-lookup"><span data-stu-id="c1388-124">For example, an app that uses drill in to navigate into a page will see a drill out when users navigate backwards.</span></span>

<span data-ttu-id="c1388-125">逆方向に移動するときに特定の切り替え効果を再生するには、`Frame.GoBack(NavigationTransitionInfo)` を使用します。</span><span class="sxs-lookup"><span data-stu-id="c1388-125">To play a specific transition when navigating backwards, use `Frame.GoBack(NavigationTransitionInfo)`.</span></span> <span data-ttu-id="c1388-126">これは、たとえば応答性の高いマスター/詳細シナリオなど、画面サイズに基づいて移動動作を動的に変更する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c1388-126">This can be useful when you modify navigation behavior dynamically based on screen size, for example, in a responsive master/detail scenario.</span></span>

## <a name="related-topics"></a><span data-ttu-id="c1388-127">関連トピック</span><span class="sxs-lookup"><span data-stu-id="c1388-127">Related topics</span></span>

- [<span data-ttu-id="c1388-128">2 つのページ間の移動</span><span class="sxs-lookup"><span data-stu-id="c1388-128">Navigate between two pages</span></span>](../basics/navigate-between-two-pages.md)
- [<span data-ttu-id="c1388-129">UWP アプリのモーション</span><span class="sxs-lookup"><span data-stu-id="c1388-129">Motion in UWP apps</span></span>](index.md)
