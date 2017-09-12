---
author: mijacobs
Description: "ポップアップ アニメーションを使って、ポップアップ UI やカスタム ポップアップ UI 要素の表示と非表示を切り替えます。 ポップアップ要素とは、アプリのコンテンツの上に表示されるコンテナーのことで、ユーザーがポップアップ要素の外部をタップまたはクリックすると消えます。"
title: "UWP アプリでのポップアップ UI のアニメーション"
ms.assetid: 4E9025CE-FC90-4d4c-9DE6-EC6B6F2AD9DF
label: Motion--Pop-up animations
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: c91e5cd3d4bad1b29d070f4750beb3dd95b3c5dc
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="pop-up-ui-animations"></a><span data-ttu-id="50748-105">ポップアップ UI のアニメーション</span><span class="sxs-lookup"><span data-stu-id="50748-105">Pop-up UI animations</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="50748-106">ポップアップ アニメーションを使って、ポップアップ UI やカスタム ポップアップ UI 要素の表示と非表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="50748-106">Use pop-up animations to show and hide pop-up UI for flyouts or custom pop-up UI elements.</span></span> <span data-ttu-id="50748-107">ポップアップ要素とは、アプリのコンテンツの上に表示されるコンテナーのことで、ユーザーがポップアップ要素の外部をタップまたはクリックすると消えます。</span><span class="sxs-lookup"><span data-stu-id="50748-107">Pop-up elements are containers that appear over the app's content and are dismissed if the user taps or clicks outside of the pop-up element.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="50748-108">重要な API</span><span class="sxs-lookup"><span data-stu-id="50748-108">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="50748-109">PopInThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="50748-109">PopInThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210383)</li>
<li>[**<span data-ttu-id="50748-110">PopupThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="50748-110">PopupThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh969172)</li>
</ul>
</div>


## <a name="dos-and-donts"></a><span data-ttu-id="50748-111">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="50748-111">Do's and don'ts</span></span>


-   <span data-ttu-id="50748-112">ポップアップ アニメーションは、アプリ ページ自体には含まれないカスタム ポップアップ UI 要素を表示したり非表示にしたりするために使います。</span><span class="sxs-lookup"><span data-stu-id="50748-112">Use pop-up animations to show or hide custom pop-up UI elements that aren't a part of the app page itself.</span></span> <span data-ttu-id="50748-113">Windows で用意されているコモン コントロールには、既にこのアニメーションが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="50748-113">The common controls provided by Windows already have these animations built in.</span></span>
-   <span data-ttu-id="50748-114">ヒントやダイアログにポップアップ アニメーションを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="50748-114">Don't use pop-up animations for tooltips or dialogs.</span></span>
-   <span data-ttu-id="50748-115">アプリのメイン コンテンツ内の UI の表示と非表示を切り替えるためにポップアップ アニメーションを使わないでください。ポップアップ アニメーションは、メイン アプリ コンテンツの上に表示されるポップアップ コンテナーの表示と非表示を切り替えるときにのみ使います。</span><span class="sxs-lookup"><span data-stu-id="50748-115">Don't use pop-up animations to show or hide UI within the main content of your app; only use pop-up animations to show or hide a pop-up container that displays on top of the main app content.</span></span>

## <a name="related-articles"></a><span data-ttu-id="50748-116">関連記事</span><span class="sxs-lookup"><span data-stu-id="50748-116">Related articles</span></span>

* [<span data-ttu-id="50748-117">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="50748-117">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="50748-118">ポップアップ UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="50748-118">Animating pop-up UI</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649433)
* [<span data-ttu-id="50748-119">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="50748-119">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="50748-120">PopInThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="50748-120">PopInThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210383)
* [**<span data-ttu-id="50748-121">PopOutThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="50748-121">PopOutThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210391)
* [**<span data-ttu-id="50748-122">PopupThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="50748-122">PopupThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh969172)

 

 




