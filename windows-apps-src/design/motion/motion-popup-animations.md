---
Description: ポップアップ アニメーションを使って、ポップアップ UI やカスタム ポップアップ UI 要素の表示と非表示を切り替えます。 ポップアップ要素とは、アプリのコンテンツの上に表示されるコンテナーのことで、ユーザーがポップアップ要素の外部をタップまたはクリックすると消えます。
title: UWP アプリでのポップアップ UI のアニメーション
ms.assetid: 4E9025CE-FC90-4d4c-9DE6-EC6B6F2AD9DF
label: Motion--Pop-up animations
template: detail.hbs
ms.date: 05/19/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: d79c369e14236b827bdc18aba6c74349528728b3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57635177"
---
# <a name="pop-up-ui-animations"></a><span data-ttu-id="37397-105">ポップアップ UI のアニメーション</span><span class="sxs-lookup"><span data-stu-id="37397-105">Pop-up UI animations</span></span>



<span data-ttu-id="37397-106">ポップアップ アニメーションを使って、ポップアップ UI やカスタム ポップアップ UI 要素の表示と非表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="37397-106">Use pop-up animations to show and hide pop-up UI for flyouts or custom pop-up UI elements.</span></span> <span data-ttu-id="37397-107">ポップアップ要素とは、アプリのコンテンツの上に表示されるコンテナーのことで、ユーザーがポップアップ要素の外部をタップまたはクリックすると消えます。</span><span class="sxs-lookup"><span data-stu-id="37397-107">Pop-up elements are containers that appear over the app's content and are dismissed if the user taps or clicks outside of the pop-up element.</span></span>

> <span data-ttu-id="37397-108">**重要な Api**:[**PopInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210383)、 [ **PopupThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh969172)</span><span class="sxs-lookup"><span data-stu-id="37397-108">**Important APIs**: [**PopInThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/br210383), [**PopupThemeTransition class**](https://msdn.microsoft.com/library/windows/apps/hh969172)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="37397-109">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="37397-109">Do's and don'ts</span></span>


-   <span data-ttu-id="37397-110">ポップアップ アニメーションは、アプリ ページ自体には含まれないカスタム ポップアップ UI 要素を表示したり非表示にしたりするために使います。</span><span class="sxs-lookup"><span data-stu-id="37397-110">Use pop-up animations to show or hide custom pop-up UI elements that aren't a part of the app page itself.</span></span> <span data-ttu-id="37397-111">Windows で用意されているコモン コントロールには、既にこのアニメーションが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="37397-111">The common controls provided by Windows already have these animations built in.</span></span>
-   <span data-ttu-id="37397-112">ヒントやダイアログにポップアップ アニメーションを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="37397-112">Don't use pop-up animations for tooltips or dialogs.</span></span>
-   <span data-ttu-id="37397-113">アプリのメイン コンテンツ内の UI の表示と非表示を切り替えるためにポップアップ アニメーションを使わないでください。ポップアップ アニメーションは、メイン アプリ コンテンツの上に表示されるポップアップ コンテナーの表示と非表示を切り替えるときにのみ使います。</span><span class="sxs-lookup"><span data-stu-id="37397-113">Don't use pop-up animations to show or hide UI within the main content of your app; only use pop-up animations to show or hide a pop-up container that displays on top of the main app content.</span></span>

## <a name="related-articles"></a><span data-ttu-id="37397-114">関連記事</span><span class="sxs-lookup"><span data-stu-id="37397-114">Related articles</span></span>

* [<span data-ttu-id="37397-115">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="37397-115">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="37397-116">ポップアップの UI をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="37397-116">Animating pop-up UI</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649433)
* [<span data-ttu-id="37397-117">クイック スタート:Library のアニメーションを使用して、UI をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="37397-117">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [<span data-ttu-id="37397-118">**PopInThemeAnimation クラス**</span><span class="sxs-lookup"><span data-stu-id="37397-118">**PopInThemeAnimation class**</span></span>](https://msdn.microsoft.com/library/windows/apps/br210383)
* [<span data-ttu-id="37397-119">**PopOutThemeAnimation クラス**</span><span class="sxs-lookup"><span data-stu-id="37397-119">**PopOutThemeAnimation class**</span></span>](https://msdn.microsoft.com/library/windows/apps/br210391)
* [<span data-ttu-id="37397-120">**PopupThemeTransition クラス**</span><span class="sxs-lookup"><span data-stu-id="37397-120">**PopupThemeTransition class**</span></span>](https://msdn.microsoft.com/library/windows/apps/hh969172)

 

 




