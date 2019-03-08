---
Description: フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。 一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。
title: UWP アプリでのフェード アニメーション
ms.assetid: 975E5EE3-EFBE-4159-8D10-3C94143DD07F
label: Motion--fades
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 6d3fee78f3608466f588a79d2811f1464e27a0ab
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57620417"
---
# <a name="fade-animations"></a><span data-ttu-id="a5d72-105">フェード アニメーション</span><span class="sxs-lookup"><span data-stu-id="a5d72-105">Fade animations</span></span>



<span data-ttu-id="a5d72-106">フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。</span><span class="sxs-lookup"><span data-stu-id="a5d72-106">Use fade animations to bring items into a view or to take items out of a view.</span></span> <span data-ttu-id="a5d72-107">一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。</span><span class="sxs-lookup"><span data-stu-id="a5d72-107">The two common fade animations are fade-in and fade-out.</span></span>

> <span data-ttu-id="a5d72-108">**重要な Api**:[**FadeInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210298)、 [ **FadeOutThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210302)</span><span class="sxs-lookup"><span data-stu-id="a5d72-108">**Important APIs**: [**FadeInThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/br210298), [**FadeOutThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/br210302)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="a5d72-109">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="a5d72-109">Do's and don'ts</span></span>


-   <span data-ttu-id="a5d72-110">アプリで互いに関係のない要素や、テキストの多い要素を切り替えるときには、フェード アウトとフェード インを使います。</span><span class="sxs-lookup"><span data-stu-id="a5d72-110">When your app transitions between unrelated or text-heavy elements, use a fade-out followed by a fade-in.</span></span> <span data-ttu-id="a5d72-111">そうすることで、差し替え前のオブジェクトが完全に消えてから差し替え後のオブジェクトを表示させることができます。</span><span class="sxs-lookup"><span data-stu-id="a5d72-111">This allows the outgoing object to completely disappear before the incoming object is visible.</span></span>
-   <span data-ttu-id="a5d72-112">差し替える 2 つの要素のサイズが一定であり、ユーザーに同じ項目を見ているような印象を与えたいときには、差し替え後の要素を差し替え前の要素の上にフェード インさせます。</span><span class="sxs-lookup"><span data-stu-id="a5d72-112">Fade in the incoming element or elements on top of the outgoing elements if the size of the elements remains constant, and if you want the user to feel that they're looking at the same item.</span></span> <span data-ttu-id="a5d72-113">フェード インが完了したら、差し替え前の項目は消すことができます。</span><span class="sxs-lookup"><span data-stu-id="a5d72-113">Once the fade-in is complete, the outgoing item can be removed.</span></span> <span data-ttu-id="a5d72-114">これは、差し替え後の項目が差し替え前の項目を完全に覆い隠せる場合にのみ可能な方法です。</span><span class="sxs-lookup"><span data-stu-id="a5d72-114">This is only a viable option when the outgoing item will be completely covered by the incoming item.</span></span>
-   <span data-ttu-id="a5d72-115">リストの項目を追加または削除する目的でフェード アニメーションを使うのは避けてください。</span><span class="sxs-lookup"><span data-stu-id="a5d72-115">Avoid fade animations to add or delete items in a list.</span></span> <span data-ttu-id="a5d72-116">そのような場合には、専用に作成したリスト アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="a5d72-116">Instead, use the list animations created for that purpose.</span></span>
-   <span data-ttu-id="a5d72-117">フェード アニメーションは、ページの全コンテンツを変化させるときには使わないでください。</span><span class="sxs-lookup"><span data-stu-id="a5d72-117">Avoid fade animations to change the entire contents of a page.</span></span> <span data-ttu-id="a5d72-118">そのような場合には、専用に作成したページ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="a5d72-118">Instead, use the page transition animations created for that purpose.</span></span>
-   <span data-ttu-id="a5d72-119">フェード アウトは要素を削除するための繊細な方法です。</span><span class="sxs-lookup"><span data-stu-id="a5d72-119">Fade-out is a subtle way to remove an element.</span></span>
## <a name="related-articles"></a><span data-ttu-id="a5d72-120">関連記事</span><span class="sxs-lookup"><span data-stu-id="a5d72-120">Related articles</span></span>

* [<span data-ttu-id="a5d72-121">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="a5d72-121">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="a5d72-122">フェード アニメーション化</span><span class="sxs-lookup"><span data-stu-id="a5d72-122">Animating fades</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649429)
* [<span data-ttu-id="a5d72-123">クイック スタート:Library のアニメーションを使用して、UI をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="a5d72-123">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [<span data-ttu-id="a5d72-124">**FadeInThemeAnimation クラス**</span><span class="sxs-lookup"><span data-stu-id="a5d72-124">**FadeInThemeAnimation class**</span></span>](https://msdn.microsoft.com/library/windows/apps/br210298)
* [<span data-ttu-id="a5d72-125">**FadeOutThemeAnimation クラス**</span><span class="sxs-lookup"><span data-stu-id="a5d72-125">**FadeOutThemeAnimation class**</span></span>](https://msdn.microsoft.com/library/windows/apps/br210302)

 

 




