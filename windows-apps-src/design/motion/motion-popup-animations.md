---
author: mijacobs
Description: Use pop-up animations to show and hide pop-up UI for flyouts or custom pop-up UI elements. Pop-up elements are containers that appear over the app's content and are dismissed if the user taps or clicks outside of the pop-up element.
title: UWP アプリでのポップアップ UI のアニメーション
ms.assetid: 4E9025CE-FC90-4d4c-9DE6-EC6B6F2AD9DF
label: Motion--Pop-up animations
template: detail.hbs
ms.author: mijacobs
ms.date: 05/19/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 1a304df30986c904f19cc2401c9a1fb468514f6f
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5977034"
---
# <a name="pop-up-ui-animations"></a><span data-ttu-id="1fbb5-103">ポップアップ UI のアニメーション</span><span class="sxs-lookup"><span data-stu-id="1fbb5-103">Pop-up UI animations</span></span>



<span data-ttu-id="1fbb5-104">ポップアップ アニメーションを使って、ポップアップ UI やカスタム ポップアップ UI 要素の表示と非表示を切り替えます。</span><span class="sxs-lookup"><span data-stu-id="1fbb5-104">Use pop-up animations to show and hide pop-up UI for flyouts or custom pop-up UI elements.</span></span> <span data-ttu-id="1fbb5-105">ポップアップ要素とは、アプリのコンテンツの上に表示されるコンテナーのことで、ユーザーがポップアップ要素の外部をタップまたはクリックすると消えます。</span><span class="sxs-lookup"><span data-stu-id="1fbb5-105">Pop-up elements are containers that appear over the app's content and are dismissed if the user taps or clicks outside of the pop-up element.</span></span>

> <span data-ttu-id="1fbb5-106">**重要な API**: [**PopInThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/br210383)、[**PopupThemeTransition クラス**](https://msdn.microsoft.com/library/windows/apps/hh969172)</span><span class="sxs-lookup"><span data-stu-id="1fbb5-106">**Important APIs**: [**PopInThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/br210383), [**PopupThemeTransition class**](https://msdn.microsoft.com/library/windows/apps/hh969172)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="1fbb5-107">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="1fbb5-107">Do's and don'ts</span></span>


-   <span data-ttu-id="1fbb5-108">ポップアップ アニメーションは、アプリ ページ自体には含まれないカスタム ポップアップ UI 要素を表示したり非表示にしたりするために使います。</span><span class="sxs-lookup"><span data-stu-id="1fbb5-108">Use pop-up animations to show or hide custom pop-up UI elements that aren't a part of the app page itself.</span></span> <span data-ttu-id="1fbb5-109">Windows で用意されているコモン コントロールには、既にこのアニメーションが組み込まれています。</span><span class="sxs-lookup"><span data-stu-id="1fbb5-109">The common controls provided by Windows already have these animations built in.</span></span>
-   <span data-ttu-id="1fbb5-110">ヒントやダイアログにポップアップ アニメーションを使わないでください。</span><span class="sxs-lookup"><span data-stu-id="1fbb5-110">Don't use pop-up animations for tooltips or dialogs.</span></span>
-   <span data-ttu-id="1fbb5-111">アプリのメイン コンテンツ内の UI の表示と非表示を切り替えるためにポップアップ アニメーションを使わないでください。ポップアップ アニメーションは、メイン アプリ コンテンツの上に表示されるポップアップ コンテナーの表示と非表示を切り替えるときにのみ使います。</span><span class="sxs-lookup"><span data-stu-id="1fbb5-111">Don't use pop-up animations to show or hide UI within the main content of your app; only use pop-up animations to show or hide a pop-up container that displays on top of the main app content.</span></span>

## <a name="related-articles"></a><span data-ttu-id="1fbb5-112">関連記事</span><span class="sxs-lookup"><span data-stu-id="1fbb5-112">Related articles</span></span>

* [<span data-ttu-id="1fbb5-113">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="1fbb5-113">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="1fbb5-114">ポップアップ UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="1fbb5-114">Animating pop-up UI</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649433)
* [<span data-ttu-id="1fbb5-115">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="1fbb5-115">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="1fbb5-116">PopInThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="1fbb5-116">PopInThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210383)
* [**<span data-ttu-id="1fbb5-117">PopOutThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="1fbb5-117">PopOutThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/br210391)
* [**<span data-ttu-id="1fbb5-118">PopupThemeTransition クラス</span><span class="sxs-lookup"><span data-stu-id="1fbb5-118">PopupThemeTransition class</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh969172)

 

 




