---
Description: コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。 新しいコンテンツはフェード インします。 既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。
title: コンテンツ切り替えアニメーションのガイドライン
ms.assetid: 0188FDB4-E183-466f-8A03-EE3FF5C474B1
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 096cc0aaa9b0580eb6b45328a3243ba75d82f202
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649807"
---
# <a name="content-transition-animations"></a><span data-ttu-id="8d762-106">コンテンツ切り替えアニメーション</span><span class="sxs-lookup"><span data-stu-id="8d762-106">Content transition animations</span></span>



<span data-ttu-id="8d762-107">コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。</span><span class="sxs-lookup"><span data-stu-id="8d762-107">Content transition animations let you change the content of an area of the screen while keeping the container or background constant.</span></span> <span data-ttu-id="8d762-108">新しいコンテンツはフェード インします。</span><span class="sxs-lookup"><span data-stu-id="8d762-108">New content fades in.</span></span> <span data-ttu-id="8d762-109">既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。</span><span class="sxs-lookup"><span data-stu-id="8d762-109">If there is existing content to be replaced, that content fades out.</span></span>

> <span data-ttu-id="8d762-110">**重要な API**:[**ContentThemeTransition クラス (XAML)**](https://msdn.microsoft.com/library/windows/apps/br243104)</span><span class="sxs-lookup"><span data-stu-id="8d762-110">**Important APIs**: [**ContentThemeTransition class (XAML)**](https://msdn.microsoft.com/library/windows/apps/br243104)</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="8d762-111">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="8d762-111">Do's and don'ts</span></span>


-   <span data-ttu-id="8d762-112">開始アニメーションは、空のコンテナーに一連の新しい項目を流し込むときに使います。</span><span class="sxs-lookup"><span data-stu-id="8d762-112">Use an entrance animation when there is a set of new items to bring into an empty container.</span></span> <span data-ttu-id="8d762-113">たとえば、アプリの初期読み込みの直後は、アプリのコンテンツの一部が表示に間に合わない場合があります。</span><span class="sxs-lookup"><span data-stu-id="8d762-113">For example, after the initial load of an app, part of the app's content might not be immediately available for display.</span></span> <span data-ttu-id="8d762-114">このような場合、コンテンツを表示する準備が整った段階で、コンテンツ切り替えアニメーションを使い、遅れてコンテンツが表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="8d762-114">When that content is ready to be shown, use a content transition animation to bring that late content into the view.</span></span>
-   <span data-ttu-id="8d762-115">あるコンテンツの組み合わせを、画面内の同じコンテナー内に既に存在する別のコンテンツの組み合わせに置き換えるときに、コンテンツ切り替えを使います。</span><span class="sxs-lookup"><span data-stu-id="8d762-115">Use content transitions to replace one set of content with another set of content that already resides in the same container within a view.</span></span>
-   <span data-ttu-id="8d762-116">新しいコンテンツを画面に表示するときには、一般的なページのフロー (読む方向) とは逆にコンテンツを上に (下から上に) スライドさせます。</span><span class="sxs-lookup"><span data-stu-id="8d762-116">When bringing in new content, slide that content up (from bottom to top) into the view against the general page flow or reading order.</span></span>
-   <span data-ttu-id="8d762-117">新しいコンテンツは論理的な流れで配置します。たとえば、最も重要なコンテンツを最後にします。</span><span class="sxs-lookup"><span data-stu-id="8d762-117">Introduce new content in a logical manner, for example, introduce the most important piece of content last.</span></span>
-   <span data-ttu-id="8d762-118">更新対象のコンテンツを含んだコンテナーが複数存在する場合、切り替え効果アニメーションは、間を置かずにすべて同時にトリガーします。</span><span class="sxs-lookup"><span data-stu-id="8d762-118">If you have more than one container whose content is to be updated, trigger all of the transition animations simultaneously without any staggering or delay.</span></span>
-   <span data-ttu-id="8d762-119">コンテンツ切り替えアニメーションは、ページの全体が変化する場合には使わないでください。</span><span class="sxs-lookup"><span data-stu-id="8d762-119">Don't use content transition animations when the entire page is changing.</span></span> <span data-ttu-id="8d762-120">この場合には、ページ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="8d762-120">In that case, use the page transition animations instead.</span></span>
-   <span data-ttu-id="8d762-121">コンテンツの更新のみであれば、コンテンツ切り替えアニメーションは使わないでください。</span><span class="sxs-lookup"><span data-stu-id="8d762-121">Don't use content transition animations if the content is only refreshing.</span></span> <span data-ttu-id="8d762-122">コンテンツ切り替えアニメーションは、動きを表現するために使います。</span><span class="sxs-lookup"><span data-stu-id="8d762-122">Content transition animations are meant to show movement.</span></span> <span data-ttu-id="8d762-123">更新には、フェード アニメーションを使ってください。</span><span class="sxs-lookup"><span data-stu-id="8d762-123">For refreshes, use fade animations.</span></span>



## <a name="related-articles"></a><span data-ttu-id="8d762-124">関連記事</span><span class="sxs-lookup"><span data-stu-id="8d762-124">Related articles</span></span>

<span data-ttu-id="8d762-125">**開発者向け (XAML)**</span><span class="sxs-lookup"><span data-stu-id="8d762-125">**For developers (XAML)**</span></span>
* [<span data-ttu-id="8d762-126">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="8d762-126">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="8d762-127">コンテンツの切り替えをアニメーション化</span><span class="sxs-lookup"><span data-stu-id="8d762-127">Animating content transitions</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649426)
* [<span data-ttu-id="8d762-128">クイック スタート:Library のアニメーションを使用して、UI をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="8d762-128">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [<span data-ttu-id="8d762-129">**ContentThemeTransition クラス**</span><span class="sxs-lookup"><span data-stu-id="8d762-129">**ContentThemeTransition class**</span></span>](https://msdn.microsoft.com/library/windows/apps/br243104)

 

 




