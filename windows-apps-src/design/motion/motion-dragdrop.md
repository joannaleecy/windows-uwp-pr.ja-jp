---
author: mijacobs
Description: Use drag-and-drop animations when users move objects, such as moving an item within a list, or dropping an item on top of another.
title: UWP アプリでのドラッグ アニメーション
ms.assetid: 6064755F-6E24-4901-A4FF-263F05F0DFD6
label: Motion--Drag and drop
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: d271d0b9c8e7ce73835457789aca3fa2cb5eda97
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/15/2018
ms.locfileid: "6837390"
---
# <a name="drag-animations"></a><span data-ttu-id="a17a6-103">ドラッグ アニメーション</span><span class="sxs-lookup"><span data-stu-id="a17a6-103">Drag animations</span></span>




<span data-ttu-id="a17a6-104">ドラッグ アンド ドロップ アニメーションは、リスト内で項目を移動するときや、特定の項目を別の項目上にドロップするときなど、オブジェクトを移動する際に使います。</span><span class="sxs-lookup"><span data-stu-id="a17a6-104">Use drag-and-drop animations when users move objects, such as moving an item within a list, or dropping an item on top of another.</span></span>

> <span data-ttu-id="a17a6-105">**重要な API**: [**DragItemThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br243174)</span><span class="sxs-lookup"><span data-stu-id="a17a6-105">**Important APIs**: [**DragItemThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/br243174)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="a17a6-106">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="a17a6-106">Do's and don'ts</span></span>


**<span data-ttu-id="a17a6-107">ドラッグの開始アニメーション</span><span class="sxs-lookup"><span data-stu-id="a17a6-107">Drag start animation</span></span>**

-   <span data-ttu-id="a17a6-108">ドラッグの開始アニメーションは、ユーザーがオブジェクトを動かし始めるときに使います。</span><span class="sxs-lookup"><span data-stu-id="a17a6-108">Use the drag start animation when the user begins to move an object.</span></span>
-   <span data-ttu-id="a17a6-109">ドラッグ アンド ドロップ操作の影響を受けるオブジェクトが他に存在する場合に限り、それらのオブジェクトをアニメーションに含めるようにします。</span><span class="sxs-lookup"><span data-stu-id="a17a6-109">Include affected objects in the animation if and only if there are other objects that can be affected by the drag-and-drop operation.</span></span>
-   <span data-ttu-id="a17a6-110">ドラッグの開始アニメーションによって始まったアニメーションのシーケンスの終了には、ドラッグの終了アニメーションを使います。</span><span class="sxs-lookup"><span data-stu-id="a17a6-110">Use the drag end animation to complete any animation sequence that began with the drag start animation.</span></span> <span data-ttu-id="a17a6-111">ドラッグの終了アニメーションにより、ドラッグの開始アニメーションで変化したドラッグされたオブジェクトのサイズが元に戻ります。</span><span class="sxs-lookup"><span data-stu-id="a17a6-111">This reverses the size change in the dragged object that was caused by the drag start animation.</span></span>

**<span data-ttu-id="a17a6-112">ドラッグの終了アニメーション</span><span class="sxs-lookup"><span data-stu-id="a17a6-112">Drag end animation</span></span>**

-   <span data-ttu-id="a17a6-113">ドラッグの終了アニメーションは、ドラッグされたオブジェクトをドロップするときに使います。</span><span class="sxs-lookup"><span data-stu-id="a17a6-113">Use the drag end animation when the user drops a dragged object.</span></span>
-   <span data-ttu-id="a17a6-114">ドラッグの終了アニメーションは、リストの追加および削除アニメーションと組み合わせて使います。</span><span class="sxs-lookup"><span data-stu-id="a17a6-114">Use the drag end animation in combination with add and delete animations for lists.</span></span>
-   <span data-ttu-id="a17a6-115">ドラッグの開始アニメーションに影響を受けるオブジェクトが存在する場合に限り、それらのオブジェクトをドラッグの終了アニメーションに含めるようにします。</span><span class="sxs-lookup"><span data-stu-id="a17a6-115">Include affected objects in the drag end animation if and only if you included those same affected objects in the drag start animation.</span></span>
-   <span data-ttu-id="a17a6-116">ドラッグの終了アニメーションは、ドラッグの開始アニメーションよりも先に使わないでください。</span><span class="sxs-lookup"><span data-stu-id="a17a6-116">Don't use the drag end animation if you have not first used the drag start animation.</span></span> <span data-ttu-id="a17a6-117">ドラッグ シーケンスの完了後にオブジェクトを元のサイズに戻すためには、両方のアニメーションを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="a17a6-117">You need to use both animations to return objects to their original sizes after the drag sequence is complete.</span></span>

**<span data-ttu-id="a17a6-118">項目間でのドラッグの開始アニメーション</span><span class="sxs-lookup"><span data-stu-id="a17a6-118">Drag between enter animation</span></span>**

-   <span data-ttu-id="a17a6-119">項目間でのドラッグの開始アニメーションは、2 つのオブジェクトの間のドロップ可能な場所にドラッグ ソースをドラッグするときに使います。</span><span class="sxs-lookup"><span data-stu-id="a17a6-119">Use the drag between enter animation when the user drags the drag source into a drop area where it can be dropped between two other objects.</span></span>
-   <span data-ttu-id="a17a6-120">適度な大きさのドロップ ターゲット領域を選んでください。</span><span class="sxs-lookup"><span data-stu-id="a17a6-120">Choose a reasonable drop target area.</span></span> <span data-ttu-id="a17a6-121">この領域が小さすぎると、ドラッグ ソースをドロップする際に重ね合わせるのが難しくなるため、好ましくありません。</span><span class="sxs-lookup"><span data-stu-id="a17a6-121">This area should not be so small that it is difficult for the user to position the drag source for the drop.</span></span>
-   <span data-ttu-id="a17a6-122">ドロップ可能な場所を示すために影響を受けるオブジェクトが移動するときには、互いにまっすぐに引き離すことをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="a17a6-122">The recommended direction to move affected objects to show the drop area is directly apart from each other.</span></span> <span data-ttu-id="a17a6-123">移動方向が上下になるか、左右になるかは、影響を受けるオブジェクトが並ぶ向きによって異なります。</span><span class="sxs-lookup"><span data-stu-id="a17a6-123">Whether they move vertically or horizontally depends on the orientation of the affected objects to each other.</span></span>
-   <span data-ttu-id="a17a6-124">ドラッグ ソースを領域内にドロップできない場合、項目間でのドラッグの開始アニメーションは使わないでください。</span><span class="sxs-lookup"><span data-stu-id="a17a6-124">Don't use the drag between enter animation if the drag source cannot be dropped in an area.</span></span> <span data-ttu-id="a17a6-125">項目間へのドラッグの開始アニメーションは、影響を受けるオブジェクトの間にドラッグ ソースをドラッグできることをユーザーに知らせるためのものです。</span><span class="sxs-lookup"><span data-stu-id="a17a6-125">The drag between enter animation tells the user that the drag source can be dropped between the affected objects.</span></span>

**<span data-ttu-id="a17a6-126">項目間でのドラッグの中止アニメーション</span><span class="sxs-lookup"><span data-stu-id="a17a6-126">Drag between leave animation</span></span>**

-   <span data-ttu-id="a17a6-127">項目間でのドラッグの中止アニメーションは、ユーザーがオブジェクトをドラッグして 2 つのオブジェクトの間のドロップ可能な領域から出すときに使います。</span><span class="sxs-lookup"><span data-stu-id="a17a6-127">Use the drag between leave animation when the user drags an object away from an area where it could have been dropped between two other objects.</span></span>
-   <span data-ttu-id="a17a6-128">項目間でのドラッグの開始アニメーションよりも先に、項目間でのドラッグの中止アニメーションを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="a17a6-128">Don't use the drag between leave animation if you have not first used the drag between enter animation.</span></span>


## <a name="related-articles"></a><span data-ttu-id="a17a6-129">関連記事</span><span class="sxs-lookup"><span data-stu-id="a17a6-129">Related articles</span></span>

**<span data-ttu-id="a17a6-130">開発者向け</span><span class="sxs-lookup"><span data-stu-id="a17a6-130">For developers</span></span>**
* [<span data-ttu-id="a17a6-131">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="a17a6-131">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="a17a6-132">ドラッグ アンド ドロップ シーケンスのアニメーション化</span><span class="sxs-lookup"><span data-stu-id="a17a6-132">Animating drag-and-drop sequences</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649427)
* [<span data-ttu-id="a17a6-133">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="a17a6-133">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="a17a6-134">DragItemThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="a17a6-134">DragItemThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243174)
* [**<span data-ttu-id="a17a6-135">DropTargetItemThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="a17a6-135">DropTargetItemThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243186)
* [**<span data-ttu-id="a17a6-136">DragOverThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="a17a6-136">DragOverThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br243180)


 




