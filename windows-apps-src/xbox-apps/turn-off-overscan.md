---
title: 画面の端に UI を描画する方法
description: タイトル セーフ エリアの自動スケーリングを無効にする方法です。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 1adb221f-6f70-4255-9329-2046a486ca45
ms.localizationpriority: medium
ms.openlocfilehash: 1ac49d80f1d99a56eff565a0daa8f2f3e9289636
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8744670"
---
# <a name="how-to-draw-ui-to-the-edge-of-the-screen"></a><span data-ttu-id="4c146-104">画面の端に UI を描画する方法</span><span class="sxs-lookup"><span data-stu-id="4c146-104">How to draw UI to the edge of the screen</span></span>   
<span data-ttu-id="4c146-105">既定では、テレビのセーフ エリアを考慮して、アプリケーションのビューポートの端には境界線が表示されます (詳しくは「[Xbox およびテレビ向け設計](../design/devices/designing-for-tv.md#tv-safe-area)」をご覧ください)。</span><span class="sxs-lookup"><span data-stu-id="4c146-105">By default, applications will have borders placed at the edges of the viewport to account for the TV-safe area (for more information, see [Designing for Xbox and TV](../design/devices/designing-for-tv.md#tv-safe-area)).</span></span> 

<span data-ttu-id="4c146-106">この設定をオフにして、画面の端に描画することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="4c146-106">We recommend turning this off and drawing to the edge of the screen.</span></span> <span data-ttu-id="4c146-107">アプリケーションの起動時に次のコードを追加することによって、画面の端に描画することができます。</span><span class="sxs-lookup"><span data-stu-id="4c146-107">You can draw to the edge of the screen by adding the following code when your application starts:</span></span>
   
```
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```
   
> [!NOTE]
> <span data-ttu-id="4c146-108">C++/DirectX アプリケーションの場合、この問題について心配する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="4c146-108">C++/DirectX applications do not have to worry about this.</span></span> <span data-ttu-id="4c146-109">システムでは、常にアプリケーションが画面の端にレンダリングされます。</span><span class="sxs-lookup"><span data-stu-id="4c146-109">The system will always render your application to the edge of the screen.</span></span>

## <a name="see-also"></a><span data-ttu-id="4c146-110">関連項目</span><span class="sxs-lookup"><span data-stu-id="4c146-110">See also</span></span>
- [<span data-ttu-id="4c146-111">Xbox のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="4c146-111">Best practices for Xbox</span></span>](tailoring-for-xbox.md)
- [<span data-ttu-id="4c146-112">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="4c146-112">UWP on Xbox One</span></span>](index.md)
