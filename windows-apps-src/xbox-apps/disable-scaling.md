---
author: payzer
title: "スケーリングを無効にする方法"
description: 
area: Xbox
ms.sourcegitcommit: 2fcccb9a045aad268afde615d31f8faa002b8a87
ms.openlocfilehash: 65416dd2b6c8656078b63c316f3972cda9c792fc

---

# スケーリングを無効にする方法   
アプリケーションは既定で、XAML アプリの場合は 200% に、HTML アプリの場合は 150% に拡大されます。 また、既定の倍率を無効にすることもできます。 これにより、アプリケーションをデバイスの実際のピクセル サイズ (1910 x 1080 ピクセル) で使うことができるようになります。   
   
## HTML   
次のコード スニペットを使って倍率を無効にすることができます。 
   
`bool result = Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);` 

また、Web 対応の次の方法を使うこともできます。   

```   
@media (max-height: 1080px) {   
    @-ms-viewport {   
        height: 1080px;   
    }   
}   
```

## XAML
次のコード スニペットを使って倍率を無効にすることができます。   
   
`bool result = Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);`   
   
## DirectX/C++   
DirectX/C++ アプリケーションはスケーリングされません。 自動スケーリングは、HTML アプリケーションと XAML アプリケーションにのみ適用されます。   



<!--HONumber=Jun16_HO5-->


