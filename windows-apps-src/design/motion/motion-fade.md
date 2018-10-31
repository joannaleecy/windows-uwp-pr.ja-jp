---
author: mijacobs
Description: Use fade animations to bring items into a view or to take items out of a view. The two common fade animations are fade-in and fade-out.
title: UWP アプリでのフェード アニメーション
ms.assetid: 975E5EE3-EFBE-4159-8D10-3C94143DD07F
label: Motion--fades
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d2a9745e35f19066b094b2be187620858166dbd5
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5832944"
---
# <a name="fade-animations"></a><span data-ttu-id="eb34d-103">フェード アニメーション</span><span class="sxs-lookup"><span data-stu-id="eb34d-103">Fade animations</span></span>



<span data-ttu-id="eb34d-104">フェード アニメーションは、項目を画面に表示したり、項目を画面から非表示にするときに使います。</span><span class="sxs-lookup"><span data-stu-id="eb34d-104">Use fade animations to bring items into a view or to take items out of a view.</span></span> <span data-ttu-id="eb34d-105">一般的なフェード アニメーションは、フェード インとフェード アウトの 2 つです。</span><span class="sxs-lookup"><span data-stu-id="eb34d-105">The two common fade animations are fade-in and fade-out.</span></span>

> <span data-ttu-id="eb34d-106">**重要な API**: [**FadeInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210298)、[**FadeOutThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210302)</span><span class="sxs-lookup"><span data-stu-id="eb34d-106">**Important APIs**: [**FadeInThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/br210298), [**FadeOutThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/br210302)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="eb34d-107">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="eb34d-107">Do's and don'ts</span></span>


-   <span data-ttu-id="eb34d-108">アプリで互いに関係のない要素や、テキストの多い要素を切り替えるときには、フェード アウトとフェード インを使います。</span><span class="sxs-lookup"><span data-stu-id="eb34d-108">When your app transitions between unrelated or text-heavy elements, use a fade-out followed by a fade-in.</span></span> <span data-ttu-id="eb34d-109">そうすることで、差し替え前のオブジェクトが完全に消えてから差し替え後のオブジェクトを表示させることができます。</span><span class="sxs-lookup"><span data-stu-id="eb34d-109">This allows the outgoing object to completely disappear before the incoming object is visible.</span></span>
-   <span data-ttu-id="eb34d-110">差し替える 2 つの要素のサイズが一定であり、ユーザーに同じ項目を見ているような印象を与えたいときには、差し替え後の要素を差し替え前の要素の上にフェード インさせます。</span><span class="sxs-lookup"><span data-stu-id="eb34d-110">Fade in the incoming element or elements on top of the outgoing elements if the size of the elements remains constant, and if you want the user to feel that they're looking at the same item.</span></span> <span data-ttu-id="eb34d-111">フェード インが完了したら、差し替え前の項目は消すことができます。</span><span class="sxs-lookup"><span data-stu-id="eb34d-111">Once the fade-in is complete, the outgoing item can be removed.</span></span> <span data-ttu-id="eb34d-112">これは、差し替え後の項目が差し替え前の項目を完全に覆い隠せる場合にのみ可能な方法です。</span><span class="sxs-lookup"><span data-stu-id="eb34d-112">This is only a viable option when the outgoing item will be completely covered by the incoming item.</span></span>
-   <span data-ttu-id="eb34d-113">リストの項目を追加または削除する目的でフェード アニメーションを使うのは避けてください。</span><span class="sxs-lookup"><span data-stu-id="eb34d-113">Avoid fade animations to add or delete items in a list.</span></span> <span data-ttu-id="eb34d-114">そのような場合には、専用に作成したリスト アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="eb34d-114">Instead, use the list animations created for that purpose.</span></span>
-   <span data-ttu-id="eb34d-115">フェード アニメーションは、ページの全コンテンツを変化させるときには使わないでください。</span><span class="sxs-lookup"><span data-stu-id="eb34d-115">Avoid fade animations to change the entire contents of a page.</span></span> <span data-ttu-id="eb34d-116">そのような場合には、専用に作成したページ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="eb34d-116">Instead, use the page transition animations created for that purpose.</span></span>
-   <span data-ttu-id="eb34d-117">フェード アウトは要素を削除するための繊細な方法です。</span><span class="sxs-lookup"><span data-stu-id="eb34d-117">Fade-out is a subtle way to remove an element.</span></span>
## <a name="related-articles"></a><span data-ttu-id="eb34d-118">関連記事</span><span class="sxs-lookup"><span data-stu-id="eb34d-118">Related articles</span></span>

* [<span data-ttu-id="eb34d-119">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="eb34d-119">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="eb34d-120">フェードのアニメーション化</span><span class="sxs-lookup"><span data-stu-id="eb34d-120">Animating fades</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649429)
* [<span data-ttu-id="eb34d-121">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="eb34d-121">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="eb34d-122">FadeInThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="eb34d-122">FadeInThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210298)
* [**<span data-ttu-id="eb34d-123">FadeOutThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="eb34d-123">FadeOutThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210302)

 

 




