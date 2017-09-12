---
author: mijacobs
Description: "フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。 一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。"
title: "UWP アプリでのフェード アニメーション"
ms.assetid: 975E5EE3-EFBE-4159-8D10-3C94143DD07F
label: Motion--fades
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 2090d68bfc2e4dc1e1c6770a17241cd1cffcffb4
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="fade-animations"></a><span data-ttu-id="fec5e-105">フェード アニメーション</span><span class="sxs-lookup"><span data-stu-id="fec5e-105">Fade animations</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="fec5e-106">フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。</span><span class="sxs-lookup"><span data-stu-id="fec5e-106">Use fade animations to bring items into a view or to take items out of a view.</span></span> <span data-ttu-id="fec5e-107">一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。</span><span class="sxs-lookup"><span data-stu-id="fec5e-107">The two common fade animations are fade-in and fade-out.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="fec5e-108">重要な API</span><span class="sxs-lookup"><span data-stu-id="fec5e-108">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="fec5e-109">FadeInThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="fec5e-109">FadeInThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210298)</li>
<li>[**<span data-ttu-id="fec5e-110">FadeOutThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="fec5e-110">FadeOutThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210302)</li>
</ul>
</div>


## <a name="dos-and-donts"></a><span data-ttu-id="fec5e-111">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="fec5e-111">Do's and don'ts</span></span>


-   <span data-ttu-id="fec5e-112">アプリで互いに関係のない要素や、テキストの多い要素を切り替えるときには、フェード アウトとフェード インを使います。</span><span class="sxs-lookup"><span data-stu-id="fec5e-112">When your app transitions between unrelated or text-heavy elements, use a fade-out followed by a fade-in.</span></span> <span data-ttu-id="fec5e-113">そうすることで、差し替え前のオブジェクトが完全に消えてから差し替え後のオブジェクトを表示させることができます。</span><span class="sxs-lookup"><span data-stu-id="fec5e-113">This allows the outgoing object to completely disappear before the incoming object is visible.</span></span>
-   <span data-ttu-id="fec5e-114">差し替える 2 つの要素のサイズが一定であり、ユーザーに同じ項目を見ているような印象を与えたいときには、差し替え後の要素を差し替え前の要素の上にフェード インさせます。</span><span class="sxs-lookup"><span data-stu-id="fec5e-114">Fade in the incoming element or elements on top of the outgoing elements if the size of the elements remains constant, and if you want the user to feel that they're looking at the same item.</span></span> <span data-ttu-id="fec5e-115">フェード インが完了したら、差し替え前の項目は消すことができます。</span><span class="sxs-lookup"><span data-stu-id="fec5e-115">Once the fade-in is complete, the outgoing item can be removed.</span></span> <span data-ttu-id="fec5e-116">これは、差し替え後の項目が差し替え前の項目を完全に覆い隠せる場合にのみ可能な方法です。</span><span class="sxs-lookup"><span data-stu-id="fec5e-116">This is only a viable option when the outgoing item will be completely covered by the incoming item.</span></span>
-   <span data-ttu-id="fec5e-117">リストの項目を追加または削除する目的でフェード アニメーションを使うのは避けてください。</span><span class="sxs-lookup"><span data-stu-id="fec5e-117">Avoid fade animations to add or delete items in a list.</span></span> <span data-ttu-id="fec5e-118">そのような場合には、専用に作成したリスト アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="fec5e-118">Instead, use the list animations created for that purpose.</span></span>
-   <span data-ttu-id="fec5e-119">フェード アニメーションは、ページの全コンテンツを変化させるときには使わないでください。</span><span class="sxs-lookup"><span data-stu-id="fec5e-119">Avoid fade animations to change the entire contents of a page.</span></span> <span data-ttu-id="fec5e-120">そのような場合には、専用に作成したページ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="fec5e-120">Instead, use the page transition animations created for that purpose.</span></span>
-   <span data-ttu-id="fec5e-121">フェード アウトは要素を削除するための繊細な方法です。</span><span class="sxs-lookup"><span data-stu-id="fec5e-121">Fade-out is a subtle way to remove an element.</span></span>
## <a name="related-articles"></a><span data-ttu-id="fec5e-122">関連記事</span><span class="sxs-lookup"><span data-stu-id="fec5e-122">Related articles</span></span>

* [<span data-ttu-id="fec5e-123">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="fec5e-123">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="fec5e-124">フェードのアニメーション化</span><span class="sxs-lookup"><span data-stu-id="fec5e-124">Animating fades</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649429)
* [<span data-ttu-id="fec5e-125">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="fec5e-125">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="fec5e-126">FadeInThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="fec5e-126">FadeInThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210298)
* [**<span data-ttu-id="fec5e-127">FadeOutThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="fec5e-127">FadeOutThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210302)

 

 




