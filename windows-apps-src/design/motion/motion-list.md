---
author: mijacobs
Description: List animations let you insert or remove single or multiple items from a collection, such as a photo album or a list of search results.
title: UWP アプリでの追加と削除のアニメーション
ms.assetid: A85006AE-4992-457a-B514-500B8BEF5DC8
label: Motion--add and delete animations
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 5ca3845866bafc229968e760a3f19f56df3a96cb
ms.sourcegitcommit: 0ab8f6fac53a6811f977ddc24de039c46c9db0ad
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/15/2018
ms.locfileid: "1653141"
---
# <a name="add-and-delete-animations"></a><span data-ttu-id="b0d78-103">追加と削除のアニメーション</span><span class="sxs-lookup"><span data-stu-id="b0d78-103">Add and delete animations</span></span>



<span data-ttu-id="b0d78-104">リスト アニメーションを使うと、写真のアルバムや検索結果の一覧などのコレクションに対して任意の数の項目を挿入または削除できます。</span><span class="sxs-lookup"><span data-stu-id="b0d78-104">List animations let you insert or remove single or multiple items from a collection, such as a photo album or a list of search results.</span></span>

> <span data-ttu-id="b0d78-105">**重要な API**: [**AddDeleteThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/br243048)</span><span class="sxs-lookup"><span data-stu-id="b0d78-105">**Important APIs**: [**AddDeleteThemeTransition class**](https://msdn.microsoft.com/library/windows/apps/br243048)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="b0d78-106">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="b0d78-106">Do's and don'ts</span></span>


-   <span data-ttu-id="b0d78-107">リスト アニメーションは、既にある一連の項目に新しい項目を 1 つ追加するときに使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-107">Use list animations to add a single new item to an existing set of items.</span></span> <span data-ttu-id="b0d78-108">たとえば、新しい電子メールを受け取ったときや、既にあるセットに新しい写真をインポートするときに使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-108">For example, use them when a new email arrives or when a new photo is imported into an existing set.</span></span>
-   <span data-ttu-id="b0d78-109">リスト アニメーションは、一連の項目に対して複数の項目を一度に追加するときに使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-109">Use list animations to add several items to a set at one time.</span></span> <span data-ttu-id="b0d78-110">たとえば、一連の新しい写真を既にあるコレクションにインポートするときに使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-110">For example, use them when you import a new set of photos to an existing collection.</span></span> <span data-ttu-id="b0d78-111">複数項目の追加と削除は、個々のオブジェクトの処理に間が生じることなく同時に実行されます。</span><span class="sxs-lookup"><span data-stu-id="b0d78-111">The addition or deletion of multiple items should happen at the same time, with no delay between the action on the individual objects.</span></span>
-   <span data-ttu-id="b0d78-112">追加と削除のリスト アニメーションは、ペアで使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-112">Use add and delete list animations as a pair.</span></span> <span data-ttu-id="b0d78-113">一方のアニメーションを使った場合は、逆の操作として対応するもう一方のアニメーションを使うようにしてください。</span><span class="sxs-lookup"><span data-stu-id="b0d78-113">Whenever you use one of these animations, use the corresponding animation for the opposite action.</span></span>
-   <span data-ttu-id="b0d78-114">リスト アニメーションは、要素または要素のグループを一度に追加または削除できる項目リストに使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-114">Use list animations with a list of items to which you can add or delete one element or group of elements at once.</span></span>
-   <span data-ttu-id="b0d78-115">コンテナーを表示したり非表示にしたりする目的でリスト アニメーションを使うのは避けてください。</span><span class="sxs-lookup"><span data-stu-id="b0d78-115">Don't use list animations to display or remove a container.</span></span> <span data-ttu-id="b0d78-116">リスト アニメーションは、既に表示されているコレクションまたはセットのメンバーに対して使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-116">These animations are for members of a collection or set that is already being displayed.</span></span> <span data-ttu-id="b0d78-117">アプリ サーフェス上に一時的なコンテナーを表示したり非表示にしたりするには、ポップアップ アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-117">Use pop-up animations to show or hide a transient container on top of the app surface.</span></span> <span data-ttu-id="b0d78-118">アプリ サーフェスの一部となっているコンテナーを表示したり置き換えたりするには、コンテンツ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-118">Use content transition animations to display or replace a container that is part of the app surface.</span></span>
-   <span data-ttu-id="b0d78-119">項目のセット全体に対してリスト アニメーションを使うのは避けてください。</span><span class="sxs-lookup"><span data-stu-id="b0d78-119">Don't use list animations on an entire set of items.</span></span> <span data-ttu-id="b0d78-120">コンテナー内のコレクション全体を追加したり削除したりするには、コンテンツ切り替えアニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="b0d78-120">Use the content transition animations to add or remove an entire collection within your container.</span></span>



## <a name="related-articles"></a><span data-ttu-id="b0d78-121">関連記事</span><span class="sxs-lookup"><span data-stu-id="b0d78-121">Related articles</span></span>

* [<span data-ttu-id="b0d78-122">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="b0d78-122">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="b0d78-123">リストの追加と削除のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="b0d78-123">Animating list additions and deletions</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649430)
* [<span data-ttu-id="b0d78-124">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="b0d78-124">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="b0d78-125">AddDeleteThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="b0d78-125">AddDeleteThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243048)

 

 




