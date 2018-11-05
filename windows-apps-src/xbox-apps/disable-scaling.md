---
author: payzer
title: スケーリングを無効にする方法
description: 既定の倍率を無効にする方法を説明します。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 6e68c1fc-a407-4c0b-b0f4-e445ccb72ff3
ms.localizationpriority: medium
ms.openlocfilehash: 82b42b25d3894a82e92af9a520ee5f951a5ba344
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6026164"
---
# <a name="how-to-turn-off-scaling"></a><span data-ttu-id="9052d-104">スケーリングを無効にする方法</span><span class="sxs-lookup"><span data-stu-id="9052d-104">How to turn off scaling</span></span>   
<span data-ttu-id="9052d-105">アプリケーションは既定で、XAML アプリの場合は 200% に、HTML アプリの場合は 150% に拡大されます。</span><span class="sxs-lookup"><span data-stu-id="9052d-105">By default, applications are scaled to 200% for XAML and 150% for HTML apps.</span></span> <span data-ttu-id="9052d-106">また、既定の倍率を無効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="9052d-106">It is possible to turn off the default scale factor.</span></span> <span data-ttu-id="9052d-107">これにより、アプリケーションをデバイスの実際のピクセル サイズ (1910 x 1080 ピクセル) で使うことができるようになります。</span><span class="sxs-lookup"><span data-stu-id="9052d-107">This will cause your application to use the actual pixel dimensions of the device (1910 x 1080 pixels).</span></span>   
   
## <a name="html"></a><span data-ttu-id="9052d-108">HTML</span><span class="sxs-lookup"><span data-stu-id="9052d-108">HTML</span></span>   
<span data-ttu-id="9052d-109">次のコード スニペットを使って倍率を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="9052d-109">You can opt out of scale factor by using the following code snippet:</span></span> 
   
```
var result = Windows.UI.ViewManagement.ApplicationViewScaling.trySetDisableLayoutScaling(true);
```

<span data-ttu-id="9052d-110">また、Web 対応の次の方法を使うこともできます。</span><span class="sxs-lookup"><span data-stu-id="9052d-110">Or, you can use a web-friendly method:</span></span>   

```   
@media (max-height: 1080px) {   
    @-ms-viewport {   
        height: 1080px;   
    }   
}   
```

## <a name="xaml"></a><span data-ttu-id="9052d-111">XAML</span><span class="sxs-lookup"><span data-stu-id="9052d-111">XAML</span></span>
<span data-ttu-id="9052d-112">次のコード スニペットを使って倍率を無効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="9052d-112">You can opt out of scale factor by using the following code snippet:</span></span>   
   
```
bool result = Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```
   
## <a name="directxc"></a><span data-ttu-id="9052d-113">DirectX/C++</span><span class="sxs-lookup"><span data-stu-id="9052d-113">DirectX/C++</span></span>   
<span data-ttu-id="9052d-114">DirectX/C++ アプリケーションはスケーリングされません。</span><span class="sxs-lookup"><span data-stu-id="9052d-114">DirectX/C++ applications are not scaled.</span></span> <span data-ttu-id="9052d-115">自動スケーリングは、HTML アプリケーションと XAML アプリケーションにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="9052d-115">Automatic scaling only applies to HTML and XAML applications.</span></span>  

## <a name="see-also"></a><span data-ttu-id="9052d-116">関連項目</span><span class="sxs-lookup"><span data-stu-id="9052d-116">See also</span></span>
- [<span data-ttu-id="9052d-117">Xbox のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="9052d-117">Best practices for Xbox</span></span>](tailoring-for-xbox.md)
- [<span data-ttu-id="9052d-118">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="9052d-118">UWP on Xbox One</span></span>](index.md)
