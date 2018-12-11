---
Description: Learn how to use page transitions in your UWP apps.
title: UWP アプリのページ切り替え効果
template: detail.hbs
ms.date: 04/08/2018
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
ms.localizationpriority: medium
ms.custom: RS5
ms.openlocfilehash: 38fe6b92828459f91ba6ea2f836d274c2cc8d761
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8886018"
---
# <a name="page-transitions"></a><span data-ttu-id="8a834-103">ページ切り替え効果</span><span class="sxs-lookup"><span data-stu-id="8a834-103">Page transitions</span></span>

<span data-ttu-id="8a834-104">ページ切り替え効果により、ユーザーがアプリ内のページ間を移動するため、ページ間の関係がフィードバックされます。</span><span class="sxs-lookup"><span data-stu-id="8a834-104">Page transitions navigate users between pages in an app, providing feedback as the relationship between pages.</span></span> <span data-ttu-id="8a834-105">ページ切り替え効果により、ナビゲーション階層の最上位にいるのか、兄弟ページ間を移動しているのか、またはページ階層をより深く移動しているのかを、ユーザーが理解しやすくなります。</span><span class="sxs-lookup"><span data-stu-id="8a834-105">Page transitions help users understand if they are at the top of a navigation hierarchy, moving between sibling pages, or navigating deeper into the page hierarchy.</span></span>

<span data-ttu-id="8a834-106">アプリ内のページ間のナビゲーションについて 2 つの異なるアニメーション (*ページの更新*および*ドリル*) が提供されており、[**NavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo) のサブクラスとして表されています。</span><span class="sxs-lookup"><span data-stu-id="8a834-106">Two different animations are provided for navigation between pages in an app, *Page refresh* and *Drill*, and are represented by subclasses of [**NavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.navigationtransitioninfo).</span></span>

## <a name="page-refresh"></a><span data-ttu-id="8a834-107">ページの更新</span><span class="sxs-lookup"><span data-stu-id="8a834-107">Page refresh</span></span>

<span data-ttu-id="8a834-108">ページの更新は、受信したコンテンツのスライド アップ アニメーションとフェード イン アニメーションの組み合わせです。</span><span class="sxs-lookup"><span data-stu-id="8a834-108">Page refresh is a combination of a slide up animation and a fade in animation for the incoming content.</span></span> <span data-ttu-id="8a834-109">ページの更新は、ユーザーがナビゲーション スタックの最上位に移動したときに使用します (タブ間や左側のナビゲーションの項目間の移動など)。</span><span class="sxs-lookup"><span data-stu-id="8a834-109">Use page refresh when the user is taken to the top of a navigational stack, such as navigating between tabs or left-nav items.</span></span>

<span data-ttu-id="8a834-110">ユーザーが処理を開始したという意識を持てるようにします。</span><span class="sxs-lookup"><span data-stu-id="8a834-110">The desired feeling is that the user has started over.</span></span>

![ページの更新のアニメーション](images/page-refresh.gif)

<span data-ttu-id="8a834-112">ページの更新のアニメーションは、[**EntranceNavigationTransitionInfoClass**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.entrancenavigationtransitioninfo) で表されます。</span><span class="sxs-lookup"><span data-stu-id="8a834-112">The page refresh animation is represented by the [**EntranceNavigationTransitionInfoClass**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.entrancenavigationtransitioninfo).</span></span>

```csharp
// Explicitly play the page refresh animation
myFrame.Navigate(typeof(Page2), null, new EntranceNavigationTransitionInfo());

```

<span data-ttu-id="8a834-113">**注**: [**フレーム**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame)は自動的に [**NavigationThemeTransition**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.navigationthemetransition) を使用して 2 つのページ間のナビゲーションをアニメーション化します。</span><span class="sxs-lookup"><span data-stu-id="8a834-113">**Note**: A [**Frame**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.controls.frame) automatically uses [**NavigationThemeTransition**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.navigationthemetransition) to animate navigation between two pages.</span></span> <span data-ttu-id="8a834-114">既定では、アニメーションはページの更新です。</span><span class="sxs-lookup"><span data-stu-id="8a834-114">By default, the animation is page refresh.</span></span>

## <a name="drill"></a><span data-ttu-id="8a834-115">ドリル</span><span class="sxs-lookup"><span data-stu-id="8a834-115">Drill</span></span>

<span data-ttu-id="8a834-116">ドリルは、項目を選択した後で詳細情報を表示するなど、ユーザーがアプリ内でより深く移動するときに使用します。</span><span class="sxs-lookup"><span data-stu-id="8a834-116">Use drill when users navigate deeper into an app, such as displaying more information after selecting an item.</span></span>

<span data-ttu-id="8a834-117">ユーザーがアプリ内をより深く移動したという意識を持てるようにします。</span><span class="sxs-lookup"><span data-stu-id="8a834-117">The desired feeling is that the user has gone deeper into the app.</span></span>

![ドリルのアニメーション](images/drill.gif)

<span data-ttu-id="8a834-119">ドリルのアニメーションは、[**DrillInNavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.drillinnavigationtransitioninfo) クラスで表されます。</span><span class="sxs-lookup"><span data-stu-id="8a834-119">The drill animation is represented by the [**DrillInNavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.drillinnavigationtransitioninfo) class.</span></span>

```csharp
// Play the drill in animation
myFrame.Navigate(typeof(Page2), null, new DrillInNavigationTransitionInfo());
```

## <a name="horizontal-slide"></a><span data-ttu-id="8a834-120">水平方向のスライド</span><span class="sxs-lookup"><span data-stu-id="8a834-120">Horizontal slide</span></span>

<span data-ttu-id="8a834-121">水平方向のスライドを使用して、兄弟のページに並べて表示されることを示します。</span><span class="sxs-lookup"><span data-stu-id="8a834-121">Use horizontal slide to show that sibling pages appear next to each other.</span></span> <span data-ttu-id="8a834-122">[NavigationView](../controls-and-patterns/navigationview.md)コントロールは自動的に、上部のナビゲーションのこのアニメーションを使用が水平方向のナビゲーション エクスペリエンスを構築する場合するを実装できます SlideNavigationTransitionInfo と水平方向にスライドします。</span><span class="sxs-lookup"><span data-stu-id="8a834-122">The [NavigationView](../controls-and-patterns/navigationview.md) control automatically uses this animation for top nav, but if you are building your own horizontal navigation experience, then you can implement horizonal slide with SlideNavigationTransitionInfo.</span></span>

<span data-ttu-id="8a834-123">持てるでは、ユーザーが互いの横にあるページ間で移動することです。</span><span class="sxs-lookup"><span data-stu-id="8a834-123">The desired feeling is that the user is navigating between pages that are next to each other.</span></span> 

```csharp
// Navigate to the right, ie. from LeftPage to RightPage
myFrame.Navigate(typeof(RightPage), null, new SlideNavigationTransitionInfo() { SlideNavigationTransitionEffect.FromRight } );

// Navigate to the left, ie. from RightPage to LeftPage
myFrame.Navigate(typeof(LeftPage), null, new SlideNavigationTransitionInfo() { SlideNavigationTransitionEffect.FromLeft } );
```

## <a name="suppress"></a><span data-ttu-id="8a834-124">抑制</span><span class="sxs-lookup"><span data-stu-id="8a834-124">Suppress</span></span>

<span data-ttu-id="8a834-125">ナビゲーション中にアニメーションの再生を回避するには、[**SuppressNavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) を他の **NavigationTransitionInfo** サブタイプの代わりに使用します。</span><span class="sxs-lookup"><span data-stu-id="8a834-125">To avoid playing any animation during navigation, use [**SuppressNavigationTransitionInfo**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.media.animation.suppressnavigationtransitioninfo) in the place of other **NavigationTransitionInfo** subtypes.</span></span>

```csharp
// Suppress the default animation
myFrame.Navigate(typeof(Page2), null, new SuppressNavigationTransitionInfo());
```

<span data-ttu-id="8a834-126">アニメーションの抑制は、[接続型アニメーション](connected-animation.md)または暗黙的な表示/非表示アニメーションを使用して独自の切り替え効果を作成している場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="8a834-126">Suppressing the animation is useful if you are building your own transition using [Connected Animations](connected-animation.md) or implicit show/hide animations.</span></span>

## <a name="backwards-navigation"></a><span data-ttu-id="8a834-127">逆方向のナビゲーション</span><span class="sxs-lookup"><span data-stu-id="8a834-127">Backwards navigation</span></span>

<span data-ttu-id="8a834-128">`Frame.GoBack(NavigationTransitionInfo)` を使用して逆方向に移動するときに特定の切り替え効果を再生することができます。</span><span class="sxs-lookup"><span data-stu-id="8a834-128">You can use `Frame.GoBack(NavigationTransitionInfo)` to play a specific transition when navigating backwards.</span></span>

<span data-ttu-id="8a834-129">これは、たとえば応答性の高いマスター/詳細シナリオなど、画面サイズに基づいて移動動作を動的に変更する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="8a834-129">This can be useful when you modify navigation behavior dynamically based on screen size; for example, in a responsive master/detail scenario.</span></span>

## <a name="related-topics"></a><span data-ttu-id="8a834-130">関連トピック</span><span class="sxs-lookup"><span data-stu-id="8a834-130">Related topics</span></span>

- [<span data-ttu-id="8a834-131">2 つのページ間の移動</span><span class="sxs-lookup"><span data-stu-id="8a834-131">Navigate between two pages</span></span>](../basics/navigate-between-two-pages.md)
- [<span data-ttu-id="8a834-132">UWP アプリのモーション</span><span class="sxs-lookup"><span data-stu-id="8a834-132">Motion in UWP apps</span></span>](index.md)
