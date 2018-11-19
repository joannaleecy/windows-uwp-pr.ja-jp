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
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7278417"
---
# <a name="how-to-turn-off-scaling"></a>スケーリングを無効にする方法   
アプリケーションは既定で、XAML アプリの場合は 200% に、HTML アプリの場合は 150% に拡大されます。 また、既定の倍率を無効にすることもできます。 これにより、アプリケーションをデバイスの実際のピクセル サイズ (1910 x 1080 ピクセル) で使うことができるようになります。   
   
## <a name="html"></a>HTML   
次のコード スニペットを使って倍率を無効にすることができます。 
   
```
var result = Windows.UI.ViewManagement.ApplicationViewScaling.trySetDisableLayoutScaling(true);
```

また、Web 対応の次の方法を使うこともできます。   

```   
@media (max-height: 1080px) {   
    @-ms-viewport {   
        height: 1080px;   
    }   
}   
```

## <a name="xaml"></a>XAML
次のコード スニペットを使って倍率を無効にすることができます。   
   
```
bool result = Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```
   
## <a name="directxc"></a>DirectX/C++   
DirectX/C++ アプリケーションはスケーリングされません。 自動スケーリングは、HTML アプリケーションと XAML アプリケーションにのみ適用されます。  

## <a name="see-also"></a>関連項目
- [Xbox のベスト プラクティス](tailoring-for-xbox.md)
- [Xbox One の UWP](index.md)
