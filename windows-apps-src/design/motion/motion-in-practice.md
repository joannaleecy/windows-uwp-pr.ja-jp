---
author: jwmsft
Description: Learn how Fluent motion fundamentals come together in your app.
title: 実践的なモーション -  UWP アプリのアニメーション
label: Motion in practice
template: detail.hbs
ms.author: jimwalk
ms.date: 05/19/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
pm-contact: stmoy
design-contact: jeffarn
doc-status: Draft
ms.localizationpriority: medium
ms.openlocfilehash: 87a17d3f73887c9b1b5029e2096c5b41c9444c4e
ms.sourcegitcommit: 517c83baffd344d4c705bc644d7c6d2b1a4c7e1a
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/07/2018
ms.locfileid: "1843865"
---
# <a name="bringing-it-together"></a><span data-ttu-id="f9621-103">まとめる</span><span class="sxs-lookup"><span data-stu-id="f9621-103">Bringing it together</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f9621-104">この記事では、まだリリースされていない機能について説明しています。この機能は、正式版がリリースされるまでに大幅に変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f9621-104">This article describes functionality that hasn’t been released yet and may be substantially modified before it's commercially released.</span></span> <span data-ttu-id="f9621-105">本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。</span><span class="sxs-lookup"><span data-stu-id="f9621-105">Microsoft makes no warranties, express or implied, with respect to the information provided here.</span></span>

<span data-ttu-id="f9621-106">タイミング、イージング、方向、および重力は、連携して Fluent モーションの基礎となります。</span><span class="sxs-lookup"><span data-stu-id="f9621-106">Timing, easing, directionality, and gravity work together to form the foundation of Fluent motion.</span></span> <span data-ttu-id="f9621-107">それぞれが、互いのコンテキストで考慮され、アプリのコンテキストで適切に適用される必要があります。</span><span class="sxs-lookup"><span data-stu-id="f9621-107">Each has to be considered in the context of the others, and applied appropriately in the context of your app.</span></span>

<span data-ttu-id="f9621-108">アプリに Fluent モーションの基礎を適用する 3 つの方法を次に示します。</span><span class="sxs-lookup"><span data-stu-id="f9621-108">Here are 3 ways to apply Fluent motion fundamentals in your app.</span></span>

<span data-ttu-id="f9621-109">:::row::: :::column::: **暗黙的なアニメーション**</span><span class="sxs-lookup"><span data-stu-id="f9621-109">:::row::: :::column::: **Implicit animation**</span></span>

        Automatic tween and timing between values in a parameter change to achieve very simple Fluent motion using the standardized values.
    :::column-end:::
    :::column:::
        **Built-in animation**

        System components, such as common controls and shared motion, are "Fluent by default". Fundamentals have been applied in a manner consistent with their implied usage.
    :::column-end:::
    :::column:::
        **Custom animation following guidance recommendations**

        There may be times when the system does not yet provide an exact motion solution for your scenario. In those cases, use the baseline fundamental recommendations as a starting point for your experiences.
    :::column-end:::
<span data-ttu-id="f9621-110">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="f9621-110">:::row-end:::</span></span>

### **<a name="transition-example"></a><span data-ttu-id="f9621-111">切り替えの例</span><span class="sxs-lookup"><span data-stu-id="f9621-111">Transition example</span></span>**

![機能的なアニメーション](images/pageRefresh.gif)

<span data-ttu-id="f9621-113">:::row::: :::column::: <b>方向前方アウト:</b></span><span class="sxs-lookup"><span data-stu-id="f9621-113">:::row::: :::column::: <b>Direction Forward Out:</b></span></span><br>
        <span data-ttu-id="f9621-114">フェード アウト: 150 m、イージング: 既定加速</span><span class="sxs-lookup"><span data-stu-id="f9621-114">Fade out: 150m; Easing: Default Accelerate</span></span>

        <b>Direction Forward In:</b><br>
        Slide up 150px: 300ms; Easing: Default Decelerate
    :::column-end:::
    :::column:::
         <b>Direction Backward Out:</b><br>
        Slide down 150px: 150ms; Easing: Default Accelerate
      
        <b>Direction Backward In:</b><br>
        Fade in: 300ms; Easing: Default Decelerate
    :::column-end:::
<span data-ttu-id="f9621-115">:::row-end:::</span><span class="sxs-lookup"><span data-stu-id="f9621-115">:::row-end:::</span></span>

 ### **<a name="object-example"></a><span data-ttu-id="f9621-116">オブジェクトの例</span><span class="sxs-lookup"><span data-stu-id="f9621-116">Object example</span></span>**

 ![300 ミリ秒のモーション](images/control.gif)
 
<span data-ttu-id="f9621-118">:::row::: :::column::: <b>方向展開:</b></span><span class="sxs-lookup"><span data-stu-id="f9621-118">:::row::: :::column::: <b>Direction Expand:</b></span></span><br>
        <span data-ttu-id="f9621-119">拡大: 300 ミリ秒、イージング: 標準 :::column-end::: :::column::: <b>方向コントラクト:</b></span><span class="sxs-lookup"><span data-stu-id="f9621-119">Grow: 300ms; Easing: Standard :::column-end::: :::column::: <b>Direction Contract:</b></span></span><br>
        <span data-ttu-id="f9621-120">拡大: 150 ミリ秒、イージング: 既定加速 :::column-end::: :::row-end:::</span><span class="sxs-lookup"><span data-stu-id="f9621-120">Grow: 150ms; Easing: Default Accelerate :::column-end::: :::row-end:::</span></span>

## <a name="related-articles"></a><span data-ttu-id="f9621-121">関連記事</span><span class="sxs-lookup"><span data-stu-id="f9621-121">Related articles</span></span>

- [<span data-ttu-id="f9621-122">モーションの概要</span><span class="sxs-lookup"><span data-stu-id="f9621-122">Motion overview</span></span>](index.md)
- [<span data-ttu-id="f9621-123">タイミングとイージング</span><span class="sxs-lookup"><span data-stu-id="f9621-123">Timing and easing</span></span>](timing-and-easing.md)
- [<span data-ttu-id="f9621-124">方向性と重力</span><span class="sxs-lookup"><span data-stu-id="f9621-124">Directionality and gravity</span></span>](directionality-and-gravity.md)