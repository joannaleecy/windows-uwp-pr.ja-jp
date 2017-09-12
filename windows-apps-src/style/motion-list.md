---
author: mijacobs
Description: "リスト アニメーションを使うと、写真のアルバムや検索結果の一覧などのコレクションに対して任意の数の項目を挿入または削除できます。"
title: "UWP アプリでの追加と削除のアニメーション"
ms.assetid: A85006AE-4992-457a-B514-500B8BEF5DC8
label: Motion--add and delete animations
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 40e4ca48132914140fcd4780876615a5864c3157
ms.sourcegitcommit: 10d6736a0827fe813c3c6e8d26d67b20ff110f6c
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/22/2017
---
# <a name="add-and-delete-animations"></a><span data-ttu-id="50376-104">追加と削除のアニメーション</span><span class="sxs-lookup"><span data-stu-id="50376-104">Add and delete animations</span></span>

<link rel="stylesheet" href="https://az835927.vo.msecnd.net/sites/uwp/Resources/css/custom.css">

<span data-ttu-id="50376-105">リスト アニメーションを使うと、写真のアルバムや検索結果の一覧などのコレクションに対して任意の数の項目を挿入または削除できます。</span><span class="sxs-lookup"><span data-stu-id="50376-105">List animations let you insert or remove single or multiple items from a collection, such as a photo album or a list of search results.</span></span>

<div class="important-apis" >
<b><span data-ttu-id="50376-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="50376-106">Important APIs</span></span></b><br/>
<ul>
<li>[**<span data-ttu-id="50376-107">AddDeleteThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="50376-107">AddDeleteThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243048)</li>
</ul>
</div>


## <a name="dos-and-donts"></a><span data-ttu-id="50376-108">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="50376-108">Do's and don'ts</span></span>


-   <span data-ttu-id="50376-109">リスト アニメーションは、既にある一連の項目に新しい項目を 1 つ追加するときに使います。</span><span class="sxs-lookup"><span data-stu-id="50376-109">Use list animations to add a single new item to an existing set of items.</span></span> <span data-ttu-id="50376-110">たとえば、新しい電子メールを受け取ったときや、既にあるセットに新しい写真をインポートするときに使います。</span><span class="sxs-lookup"><span data-stu-id="50376-110">For example, use them when a new email arrives or when a new photo is imported into an existing set.</span></span>
-   <span data-ttu-id="50376-111">リスト アニメーションは、一連の項目に対して複数の項目を一度に追加するときに使います。</span><span class="sxs-lookup"><span data-stu-id="50376-111">Use list animations to add several items to a set at one time.</span></span> <span data-ttu-id="50376-112">たとえば、一連の新しい写真を既にあるコレクションにインポートするときに使います。</span><span class="sxs-lookup"><span data-stu-id="50376-112">For example, use them when you import a new set of photos to an existing collection.</span></span> <span data-ttu-id="50376-113">複数項目の追加と削除は、個々のオブジェクトの処理に間が生じることなく同時に実行されます。</span><span class="sxs-lookup"><span data-stu-id="50376-113">The addition or deletion of multiple items should happen at the same time, with no delay between the action on the individual objects.</span></span>
-   <span data-ttu-id="50376-114">追加と削除のリスト アニメーションは、ペアで使います。</span><span class="sxs-lookup"><span data-stu-id="50376-114">Use add and delete list animations as a pair.</span></span> <span data-ttu-id="50376-115">一方のアニメーションを使った場合は、逆の操作として対応するもう一方のアニメーションを使うようにしてください。</span><span class="sxs-lookup"><span data-stu-id="50376-115">Whenever you use one of these animations, use the corresponding animation for the opposite action.</span></span>
-   <span data-ttu-id="50376-116">リスト アニメーションは、要素または要素のグループを一度に追加または削除できる項目リストに使います。</span><span class="sxs-lookup"><span data-stu-id="50376-116">Use list animations with a list of items to which you can add or delete one element or group of elements at once.</span></span>
-   <span data-ttu-id="50376-117">コンテナーを表示したり非表示にしたりする目的でリスト アニメーションを使うのは避けてください。</span><span class="sxs-lookup"><span data-stu-id="50376-117">Don't use list animations to display or remove a container.</span></span> <span data-ttu-id="50376-118">リスト アニメーションは、既に表示されているコレクションまたはセットのメンバーに対して使います。</span><span class="sxs-lookup"><span data-stu-id="50376-118">These animations are for members of a collection or set that is already being displayed.</span></span> <span data-ttu-id="50376-119">アプリ サーフェス上に一時的なコンテナーを表示したり非表示にしたりするには、ポップアップ アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="50376-119">Use pop-up animations to show or hide a transient container on top of the app surface.</span></span> <span data-ttu-id="50376-120">アプリ サーフェスの一部となっているコンテナーを表示したり置き換えたりするには、コンテンツ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="50376-120">Use content transition animations to display or replace a container that is part of the app surface.</span></span>
-   <span data-ttu-id="50376-121">項目のセット全体に対してリスト アニメーションを使うのは避けてください。</span><span class="sxs-lookup"><span data-stu-id="50376-121">Don't use list animations on an entire set of items.</span></span> <span data-ttu-id="50376-122">コンテナー内のコレクション全体を追加したり削除したりするには、コンテンツ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="50376-122">Use the content transition animations to add or remove an entire collection within your container.</span></span>



## <a name="related-articles"></a><span data-ttu-id="50376-123">関連記事</span><span class="sxs-lookup"><span data-stu-id="50376-123">Related articles</span></span>

* [<span data-ttu-id="50376-124">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="50376-124">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="50376-125">リストの追加と削除のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="50376-125">Animating list additions and deletions</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649430)
* [<span data-ttu-id="50376-126">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="50376-126">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="50376-127">AddDeleteThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="50376-127">AddDeleteThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243048)

 

 




