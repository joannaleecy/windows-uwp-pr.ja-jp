---
Description: ポインター アニメーションを使って、ユーザーが項目をタップまたはクリックしたときに視覚的なフィードバックをユーザーに提供します。
title: UWP アプリでのポインター クリックのアニメーション
ms.assetid: EEB10A2C-629A-4705-8468-4D019D74DDFF
ms.date: 08/09/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: f1abd71cda8358e3f7e2fe36091f9c42f05bcb00
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57663797"
---
# <a name="pointer-click-animations"></a><span data-ttu-id="3d393-104">ポインター クリックのアニメーション</span><span class="sxs-lookup"><span data-stu-id="3d393-104">Pointer click animations</span></span>



<span data-ttu-id="3d393-105">ポインター アニメーションを使って、ユーザーが項目をタップまたはクリックしたときに視覚的なフィードバックをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="3d393-105">Use pointer animations to provide users with visual feedback when the user taps on an item.</span></span> <span data-ttu-id="3d393-106">ポインター ダウン アニメーション (押された項目を若干縮小して傾ける) は、項目が最初にタップされたときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="3d393-106">The pointer down animation slightly shrinks and tilts the pressed item, and plays when an item is first tapped.</span></span> <span data-ttu-id="3d393-107">ポインター アップ アニメーション (項目を元の位置に復元する) は、ユーザーがポインターから指を離したときに再生されます。</span><span class="sxs-lookup"><span data-stu-id="3d393-107">The pointer up animation, which restores the item to its original position, is played when the user releases the pointer.</span></span>


> <span data-ttu-id="3d393-108">**重要な Api**:[**PointerUpThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969168)、 [ **PointerDownThemeAnimation クラス**](https://msdn.microsoft.com/library/windows/apps/hh969164)</span><span class="sxs-lookup"><span data-stu-id="3d393-108">**Important APIs**: [**PointerUpThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/hh969168), [**PointerDownThemeAnimation class**](https://msdn.microsoft.com/library/windows/apps/hh969164)</span></span>


## <a name="dos-and-donts"></a><span data-ttu-id="3d393-109">推奨と非推奨</span><span class="sxs-lookup"><span data-stu-id="3d393-109">Do's and don'ts</span></span>

-   <span data-ttu-id="3d393-110">ポインター アップ アニメーションを使うときには、ユーザーが指を離した直後にアニメーションを開始するようにします。</span><span class="sxs-lookup"><span data-stu-id="3d393-110">When you use a pointer up animation, immediately trigger the animation when the user releases the pointer.</span></span> <span data-ttu-id="3d393-111">これにより、タップによってトリガーされたアクション (新しいページへの移動など) の応答が遅れたとしても、ユーザーの操作が認識されたというフィードバックを即座に返すことができます。</span><span class="sxs-lookup"><span data-stu-id="3d393-111">This provides instant feedback to the user that their action has been recognized, even if the action triggered by the tap (such as navigating to a new page) is slower to respond.</span></span>

## <a name="related-articles"></a><span data-ttu-id="3d393-112">関連記事</span><span class="sxs-lookup"><span data-stu-id="3d393-112">Related articles</span></span>

* [<span data-ttu-id="3d393-113">アニメーションの概要</span><span class="sxs-lookup"><span data-stu-id="3d393-113">Animations overview</span></span>](https://msdn.microsoft.com/library/windows/apps/mt187350)
* [<span data-ttu-id="3d393-114">アニメーション ポインター数回のクリック</span><span class="sxs-lookup"><span data-stu-id="3d393-114">Animating pointer clicks</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/jj649432)
* [<span data-ttu-id="3d393-115">クイック スタート:Library のアニメーションを使用して、UI をアニメーション化</span><span class="sxs-lookup"><span data-stu-id="3d393-115">Quickstart: Animating your UI using library animations</span></span>](https://msdn.microsoft.com/library/windows/apps/xaml/hh452703)
* [<span data-ttu-id="3d393-116">**PointerUpThemeAnimation クラス**</span><span class="sxs-lookup"><span data-stu-id="3d393-116">**PointerUpThemeAnimation class**</span></span>](https://msdn.microsoft.com/library/windows/apps/hh969168)
* [<span data-ttu-id="3d393-117">**PointerDownThemeAnimation クラス**</span><span class="sxs-lookup"><span data-stu-id="3d393-117">**PointerDownThemeAnimation class**</span></span>](https://msdn.microsoft.com/library/windows/apps/hh969164)

 

 




