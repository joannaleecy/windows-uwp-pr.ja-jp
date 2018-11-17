---
author: mijacobs
Description: Content transition animations let you change the content of an area of the screen while keeping the container or background constant. New content fades in. If there is existing content to be replaced, that content fades out.
title: コンテンツ切り替えアニメーションのガイドライン
ms.assetid: 0188FDB4-E183-466f-8A03-EE3FF5C474B1
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
pm-contact: stmoy
design-contact: conrwi
doc-status: Published
ms.localizationpriority: medium
ms.openlocfilehash: 14d5120632833e91e82ed7dd717ba04a9abb0efb
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "7172728"
---
# <a name="content-transition-animations"></a><span data-ttu-id="6deca-103">コンテンツ切り替えアニメーション</span><span class="sxs-lookup"><span data-stu-id="6deca-103">Content transition animations</span></span>



<span data-ttu-id="6deca-104">コンテンツ切り替えアニメーションを使うと、コンテナーや背景はそのままに、画面のある領域のコンテンツを変更できます。</span><span class="sxs-lookup"><span data-stu-id="6deca-104">Content transition animations let you change the content of an area of the screen while keeping the container or background constant.</span></span> <span data-ttu-id="6deca-105">新しいコンテンツはフェード インします。</span><span class="sxs-lookup"><span data-stu-id="6deca-105">New content fades in.</span></span> <span data-ttu-id="6deca-106">既にあるコンテンツを差し替える場合、そのコンテンツはフェード アウトします。</span><span class="sxs-lookup"><span data-stu-id="6deca-106">If there is existing content to be replaced, that content fades out.</span></span>

> <span data-ttu-id="6deca-107">**重要な API**: [**ContentThemeTransition クラス (XAML)**](https://msdn.microsoft.com/library/windows/apps/br243104)</span><span class="sxs-lookup"><span data-stu-id="6deca-107">**Important APIs**: [**ContentThemeTransition class (XAML)**](https://msdn.microsoft.com/library/windows/apps/br243104)</span></span>

## <a name="dos-and-donts"></a><span data-ttu-id="6deca-108">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="6deca-108">Do's and don'ts</span></span>


-   <span data-ttu-id="6deca-109">開始アニメーションは、空のコンテナーに一連の新しい項目を流し込むときに使います。</span><span class="sxs-lookup"><span data-stu-id="6deca-109">Use an entrance animation when there is a set of new items to bring into an empty container.</span></span> <span data-ttu-id="6deca-110">たとえば、アプリの初期読み込みの直後は、アプリのコンテンツの一部が表示に間に合わない場合があります。</span><span class="sxs-lookup"><span data-stu-id="6deca-110">For example, after the initial load of an app, part of the app's content might not be immediately available for display.</span></span> <span data-ttu-id="6deca-111">このような場合、コンテンツを表示する準備が整った段階で、コンテンツ切り替えアニメーションを使い、遅れてコンテンツが表示されるようにします。</span><span class="sxs-lookup"><span data-stu-id="6deca-111">When that content is ready to be shown, use a content transition animation to bring that late content into the view.</span></span>
-   <span data-ttu-id="6deca-112">あるコンテンツの組み合わせを、画面内の同じコンテナー内に既に存在する別のコンテンツの組み合わせに置き換えるときに、コンテンツ切り替えを使います。</span><span class="sxs-lookup"><span data-stu-id="6deca-112">Use content transitions to replace one set of content with another set of content that already resides in the same container within a view.</span></span>
-   <span data-ttu-id="6deca-113">新しいコンテンツを画面に表示するときには、一般的なページのフロー (読む方向) とは逆にコンテンツを上に (下から上に) スライドさせます。</span><span class="sxs-lookup"><span data-stu-id="6deca-113">When bringing in new content, slide that content up (from bottom to top) into the view against the general page flow or reading order.</span></span>
-   <span data-ttu-id="6deca-114">新しいコンテンツは論理的な流れで配置します。たとえば、最も重要なコンテンツを最後にします。</span><span class="sxs-lookup"><span data-stu-id="6deca-114">Introduce new content in a logical manner, for example, introduce the most important piece of content last.</span></span>
-   <span data-ttu-id="6deca-115">更新対象のコンテンツを含んだコンテナーが複数存在する場合、切り替え効果アニメーションは、間を置かずにすべて同時にトリガーします。</span><span class="sxs-lookup"><span data-stu-id="6deca-115">If you have more than one container whose content is to be updated, trigger all of the transition animations simultaneously without any staggering or delay.</span></span>
-   <span data-ttu-id="6deca-116">コンテンツ切り替えアニメーションは、ページの全体が変化する場合には使わないでください。</span><span class="sxs-lookup"><span data-stu-id="6deca-116">Don't use content transition animations when the entire page is changing.</span></span> <span data-ttu-id="6deca-117">この場合には、ページ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="6deca-117">In that case, use the page transition animations instead.</span></span>
-   <span data-ttu-id="6deca-118">コンテンツの更新のみであれば、コンテンツ切り替えアニメーションは使わないでください。</span><span class="sxs-lookup"><span data-stu-id="6deca-118">Don't use content transition animations if the content is only refreshing.</span></span> <span data-ttu-id="6deca-119">コンテンツ切り替えアニメーションは、動きを表現するために使います。</span><span class="sxs-lookup"><span data-stu-id="6deca-119">Content transition animations are meant to show movement.</span></span> <span data-ttu-id="6deca-120">更新には、フェード アニメーションを使ってください。</span><span class="sxs-lookup"><span data-stu-id="6deca-120">For refreshes, use fade animations.</span></span>



## <a name="related-articles"></a><span data-ttu-id="6deca-121">関連記事</span><span class="sxs-lookup"><span data-stu-id="6deca-121">Related articles</span></span>

**<span data-ttu-id="6deca-122">開発者向け (XAML)</span><span class="sxs-lookup"><span data-stu-id="6deca-122">For developers (XAML)</span></span>**
* [<span data-ttu-id="6deca-123">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="6deca-123">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="6deca-124">コンテンツ切り替えのアニメーション化</span><span class="sxs-lookup"><span data-stu-id="6deca-124">Animating content transitions</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649426)
* [<span data-ttu-id="6deca-125">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="6deca-125">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="6deca-126">ContentThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="6deca-126">ContentThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243104)

 

 




