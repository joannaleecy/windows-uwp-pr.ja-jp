---
Description: Use pointer animations to provide users with visual feedback when the user taps on an item.
title: UWP アプリでのポインター クリックのアニメーション
ms.assetid: EEB10A2C-629A-4705-8468-4D019D74DDFF
ms.date: 08/9/2017
ms.topic: article
keywords: windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 8cedab3f589f41b791a6c387ec776dc4c8ee23a6
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7826338"
---
# <a name="pointer-click-animations"></a><span data-ttu-id="3eba4-103">ポインター クリックのアニメーション</span><span class="sxs-lookup"><span data-stu-id="3eba4-103">Pointer click animations</span></span>



<span data-ttu-id="3eba4-104">ポインター アニメーションを使って、ユーザーが項目をタップまたはクリックしたときに視覚的なフィードバックをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="3eba4-104">Use pointer animations to provide users with visual feedback when the user taps on an item.</span></span> <span data-ttu-id="3eba4-105">ポインター ダウン アニメーション (押された項目を若干縮小して傾ける) は、項目が最初にタップされたときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="3eba4-105">The pointer down animation slightly shrinks and tilts the pressed item, and plays when an item is first tapped.</span></span> <span data-ttu-id="3eba4-106">ポインター アップ アニメーション (項目を元の位置に復元する) は、ユーザーがポインターから指を離したときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="3eba4-106">The pointer up animation, which restores the item to its original position, is played when the user releases the pointer.</span></span>


> <span data-ttu-id="3eba4-107">**重要な API**: [**PointerUpThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969168)、[**PointerDownThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969164)</span><span class="sxs-lookup"><span data-stu-id="3eba4-107">**Important APIs**: [**PointerUpThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/hh969168), [**PointerDownThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/hh969164)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="3eba4-108">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="3eba4-108">Do's and don'ts</span></span>

-   <span data-ttu-id="3eba4-109">ポインター アップ アニメーションを使うときには、ユーザーが指を離した直後にアニメーションを開始するようにします。</span><span class="sxs-lookup"><span data-stu-id="3eba4-109">When you use a pointer up animation, immediately trigger the animation when the user releases the pointer.</span></span> <span data-ttu-id="3eba4-110">これにより、タップによってトリガーされたアクション (新しいページへの移動など) の応答が遅れたとしても、ユーザーの操作が認識されたというフィードバックを即座に返すことができます。</span><span class="sxs-lookup"><span data-stu-id="3eba4-110">This provides instant feedback to the user that their action has been recognized, even if the action triggered by the tap (such as navigating to a new page) is slower to respond.</span></span>

## <a name="related-articles"></a><span data-ttu-id="3eba4-111">関連記事</span><span class="sxs-lookup"><span data-stu-id="3eba4-111">Related articles</span></span>

* [<span data-ttu-id="3eba4-112">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="3eba4-112">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="3eba4-113">ポインター クリックのアニメーション化</span><span class="sxs-lookup"><span data-stu-id="3eba4-113">Animating pointer clicks</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649432)
* [<span data-ttu-id="3eba4-114">クイック スタート: ライブラリのアニメーションを使った UI のアニメーション化</span><span class="sxs-lookup"><span data-stu-id="3eba4-114">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [**<span data-ttu-id="3eba4-115">PointerUpThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="3eba4-115">PointerUpThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh969168)
* [**<span data-ttu-id="3eba4-116">PointerDownThemeAnimation クラス</span><span class="sxs-lookup"><span data-stu-id="3eba4-116">PointerDownThemeAnimation class</span></span>**](https://msdn.microsoft.com/library/windows/apps/hh969164)

 

 




