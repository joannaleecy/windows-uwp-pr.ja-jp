---
author: mijacobs
Description: "コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。 新しいコンテンツはフェード インします。 既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。"
title: "コンテンツ切り替えアニメーションのガイドライン"
ms.assetid: 0188FDB4-E183-466f-8A03-EE3FF5C474B1
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.openlocfilehash: 881059e8ec15ec1006a15f453e5f488ed8d04bed
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="content-transition-animations"></a><span data-ttu-id="e42c6-106">コンテンツ切り替えアニメーション</span><span class="sxs-lookup"><span data-stu-id="e42c6-106">Content transition animations</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="e42c6-107">コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。</span><span class="sxs-lookup"><span data-stu-id="e42c6-107">Content transition animations let you change the content of an area of the screen while keeping the container or background constant.</span></span> <span data-ttu-id="e42c6-108">新しいコンテンツはフェード インします。</span><span class="sxs-lookup"><span data-stu-id="e42c6-108">New content fades in.</span></span> <span data-ttu-id="e42c6-109">既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。</span><span class="sxs-lookup"><span data-stu-id="e42c6-109">If there is existing content to be replaced, that content fades out.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="e42c6-110">重要な API</span><span class="sxs-lookup"><span data-stu-id="e42c6-110">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="e42c6-111">ContentThemeTransition クラス (XAML)</span><span class="sxs-lookup"><span data-stu-id="e42c6-111">ContentThemeTransition class (XAML)</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243104)</li>
</ul>
</div>

## <a name="dos-and-donts"></a><span data-ttu-id="e42c6-112">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="e42c6-112">Do's and don'ts</span></span>


-   <span data-ttu-id="e42c6-113">開始アニメーションは、空のコンテナーに一連の新しい項目を流し込むときに使います。</span><span class="sxs-lookup"><span data-stu-id="e42c6-113">Use an entrance animation when there is a set of new items to bring into an empty container.</span></span> <span data-ttu-id="e42c6-114">たとえば、アプリの初期読み込みの直後は、アプリのコンテンツの一部が表示に間に合わない場合があります。</span><span class="sxs-lookup"><span data-stu-id="e42c6-114">For example, after the initial load of an app, part of the app's content might not be immediately available for display.</span></span> <span data-ttu-id="e42c6-115">このような場合、コンテンツを表示する準備が整った段階で、コンテンツ切り替えアニメーションを使い、遅れてコンテンツが表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="e42c6-115">When that content is ready to be shown, use a content transition animation to bring that late content into the view.</span></span>
-   <span data-ttu-id="e42c6-116">あるコンテンツの組み合わせを、画面内の同じコンテナー内に既に存在する別のコンテンツの組み合わせに置き換えるときに、コンテンツ切り替えを使います。</span><span class="sxs-lookup"><span data-stu-id="e42c6-116">Use content transitions to replace one set of content with another set of content that already resides in the same container within a view.</span></span>
-   <span data-ttu-id="e42c6-117">新しいコンテンツを画面に表示するときには、一般的なページのフロー (読む方向) とは逆にコンテンツを上に (下から上に) スライドさせます。</span><span class="sxs-lookup"><span data-stu-id="e42c6-117">When bringing in new content, slide that content up (from bottom to top) into the view against the general page flow or reading order.</span></span>
-   <span data-ttu-id="e42c6-118">新しいコンテンツは論理的な流れで配置します。たとえば、最も重要なコンテンツを最後にします。</span><span class="sxs-lookup"><span data-stu-id="e42c6-118">Introduce new content in a logical manner, for example, introduce the most important piece of content last.</span></span>
-   <span data-ttu-id="e42c6-119">更新対象のコンテンツを含んだコンテナーが複数存在する場合、切り替え効果アニメーションは、間を置かずにすべて同時にトリガーします。</span><span class="sxs-lookup"><span data-stu-id="e42c6-119">If you have more than one container whose content is to be updated, trigger all of the transition animations simultaneously without any staggering or delay.</span></span>
-   <span data-ttu-id="e42c6-120">コンテンツ切り替えアニメーションは、ページの全体が変化する場合には使わないでください。</span><span class="sxs-lookup"><span data-stu-id="e42c6-120">Don't use content transition animations when the entire page is changing.</span></span> <span data-ttu-id="e42c6-121">この場合には、ページ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="e42c6-121">In that case, use the page transition animations instead.</span></span>
-   <span data-ttu-id="e42c6-122">コンテンツの更新のみであれば、コンテンツ切り替えアニメーションは使わないでください。</span><span class="sxs-lookup"><span data-stu-id="e42c6-122">Don't use content transition animations if the content is only refreshing.</span></span> <span data-ttu-id="e42c6-123">コンテンツ切り替えアニメーションは、動きを表現するために使います。</span><span class="sxs-lookup"><span data-stu-id="e42c6-123">Content transition animations are meant to show movement.</span></span> <span data-ttu-id="e42c6-124">更新には、フェード アニメーションを使ってください。</span><span class="sxs-lookup"><span data-stu-id="e42c6-124">For refreshes, use fade animations.</span></span>



## <a name="related-articles"></a><span data-ttu-id="e42c6-125">関連記事</span><span class="sxs-lookup"><span data-stu-id="e42c6-125">Related articles</span></span>

**<span data-ttu-id="e42c6-126">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="e42c6-126">For developers (XAML)</span></span>**
* [<span data-ttu-id="e42c6-127">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="e42c6-127">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="e42c6-128">コンテンツ切り替えのアニメーション化</span><span class="sxs-lookup"><span data-stu-id="e42c6-128">Animating content transitions</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649426)
* [<span data-ttu-id="e42c6-129">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="e42c6-129">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="e42c6-130">ContentThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="e42c6-130">ContentThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243104)

 

 




