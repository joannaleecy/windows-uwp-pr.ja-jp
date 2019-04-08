---
Description: エッジに基づく UI アニメーションでは、画面の端を起点とする UI の表示と非表示を切り替えられます。
title: UWP アプリでのエッジに基づく UI アニメーション
ms.assetid: 5A8F73B1-F4F6-424b-9EDF-A9766C5DEAE8
label: Motion--edge-based UI
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: e07ac565fe2e223b2fb33573ad083edfdfbc888a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57610207"
---
# <a name="edge-based-ui-animations"></a><span data-ttu-id="fc50d-104">エッジに基づく UI アニメーション</span><span class="sxs-lookup"><span data-stu-id="fc50d-104">Edge-based UI animations</span></span>





<span data-ttu-id="fc50d-105">エッジに基づく UI アニメーションでは、画面の端を起点とする UI の表示と非表示を切り替えられます。</span><span class="sxs-lookup"><span data-stu-id="fc50d-105">Edge-based animations show or hide UI that originates from the edge of the screen.</span></span> <span data-ttu-id="fc50d-106">この表示と非表示のアクションは、ユーザーが開始することも、アプリから開始することもできます。</span><span class="sxs-lookup"><span data-stu-id="fc50d-106">The show and hide actions can be initiated either by the user or by the app.</span></span> <span data-ttu-id="fc50d-107">UI は、アプリの手前に表示するか、メイン アプリ サーフェスの一部として表示することができます。</span><span class="sxs-lookup"><span data-stu-id="fc50d-107">The UI can either overlay the app or be part of the main app surface.</span></span> <span data-ttu-id="fc50d-108">UI をアプリ サーフェスの一部として表示する場合は、UI を表示できるようにアプリの残りの部分のサイズを調整する必要があります。</span><span class="sxs-lookup"><span data-stu-id="fc50d-108">If the UI is part of the app surface, the rest of the app might need to be resized to accommodate it.</span></span>

> <span data-ttu-id="fc50d-109">**重要な API**:[**EdgeUIThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh702324)</span><span class="sxs-lookup"><span data-stu-id="fc50d-109">**Important APIs**: [**EdgeUIThemeTransition class**](https://msdn.microsoft.com/library/windows/apps/hh702324)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="fc50d-110">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="fc50d-110">Do's and don'ts</span></span>


-   <span data-ttu-id="fc50d-111">画面領域をあまり占有しないカスタム メッセージ バーやエラー バーを表示または非表示にするには、エッジ (端) UI アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="fc50d-111">Use edge UI animations to show or hide a custom message or error bar that does not extend far into the screen.</span></span>
-   <span data-ttu-id="fc50d-112">作業ウィンドウやカスタム ソフト キーボードなど、画面内側にスライドして領域を大きく確保する UI を表示するには、パネル アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="fc50d-112">Use panel animations to show UI that slides a significant distance into the screen, such as a task pane or a custom soft keyboard.</span></span>
-   <span data-ttu-id="fc50d-113">UI を開くには、それが関連付けられている端から画面内側にスライドします。</span><span class="sxs-lookup"><span data-stu-id="fc50d-113">Slide the UI in from the same edge it will be attached to.</span></span>
-   <span data-ttu-id="fc50d-114">UI を閉じるには、画面内側から、開いたときと同じ端に向かってスライドします。</span><span class="sxs-lookup"><span data-stu-id="fc50d-114">Slide the UI out to the same edge it came from.</span></span>
-   <span data-ttu-id="fc50d-115">UI のスライド操作に応じてアプリのコンテンツ サイズを変更する必要がある場合は、フェード アニメーションを使ってサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="fc50d-115">If the contents of the app need to resize in response to the UI sliding in or out, use fade animations for the resize.</span></span>
    -   <span data-ttu-id="fc50d-116">UI を画面内側に向かってスライドする場合は、エッジ (端) UI アニメーションまたはパネル アニメーションの後にフェード アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="fc50d-116">If the UI is sliding in, use a fade animation after the edge UI or panel animation.</span></span>
    -   <span data-ttu-id="fc50d-117">UI を画面外側に向かってスライドする場合は、エッジ (端) UI アニメーションまたはパネル アニメーションと同時にフェード アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="fc50d-117">If the UI is sliding out, use a fade animation at the same time as the edge UI or panel animation.</span></span>
-   <span data-ttu-id="fc50d-118">通知には、このアニメーションを適用しないでください。</span><span class="sxs-lookup"><span data-stu-id="fc50d-118">Don't apply these animations to notifications.</span></span> <span data-ttu-id="fc50d-119">エッジに基づく UI に通知を格納することはお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="fc50d-119">Notifications should not be housed within edge-based UI.</span></span>
-   <span data-ttu-id="fc50d-120">画面のエッジ (端) にない UI コンテナーやコントロールには、エッジ (端) UI アニメーションとパネル アニメーションを適用しないでください。</span><span class="sxs-lookup"><span data-stu-id="fc50d-120">Don't apply the edge UI or panel animations to any UI container or control that is not at the edge of the screen.</span></span> <span data-ttu-id="fc50d-121">このアニメーションは、画面のエッジ (端) にある UI の開閉とサイズ変更にのみ使います。</span><span class="sxs-lookup"><span data-stu-id="fc50d-121">These animations are used only for showing, resizing, and dismissing UI at the edges of the screen.</span></span> <span data-ttu-id="fc50d-122">他のタイプの UI を移動するには、位置変更アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="fc50d-122">To move other types of UI, use reposition animations.</span></span>

    ![エッジ (端) UI アニメーションまたはパネル アニメーションを使うケースと位置変更を使うケースの図](images/edgevsreposition.png)

## <a name="related-articles"></a><span data-ttu-id="fc50d-124">関連記事</span><span class="sxs-lookup"><span data-stu-id="fc50d-124">Related articles</span></span>


<span data-ttu-id="fc50d-125">**開発者向け**</span><span class="sxs-lookup"><span data-stu-id="fc50d-125">**For developers**</span></span>
* [<span data-ttu-id="fc50d-126">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="fc50d-126">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="fc50d-127">Edge ベースの UI をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="fc50d-127">Animating edge-based UI</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649428)
* [<span data-ttu-id="fc50d-128">クイック スタート:Library のアニメーションを使用して、UI をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="fc50d-128">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [<span data-ttu-id="fc50d-129">**EdgeUIThemeTransition クラス**</span><span class="sxs-lookup"><span data-stu-id="fc50d-129">**EdgeUIThemeTransition class**</span></span>](https://msdn.microsoft.com/library/windows/apps/hh702324)
* [<span data-ttu-id="fc50d-130">**PaneThemeTransition クラス**</span><span class="sxs-lookup"><span data-stu-id="fc50d-130">**PaneThemeTransition class**</span></span>](https://msdn.microsoft.com/library/windows/apps/hh969160)
* [<span data-ttu-id="fc50d-131">フェード アニメーション化</span><span class="sxs-lookup"><span data-stu-id="fc50d-131">Animating fades</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649429)
* [<span data-ttu-id="fc50d-132">位置を変更をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="fc50d-132">Animating repositions</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649434)

 

 




