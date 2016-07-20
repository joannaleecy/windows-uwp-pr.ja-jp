---
author: payzer
title: "スケーリングを無効にする方法"
description: 
area: Xbox
translationtype: Human Translation
ms.sourcegitcommit: 192de32bf3afd11cd375655ad92d194ccb09dae1
ms.openlocfilehash: 307606bc290e9c5268fc5a37b72770d6b1ada4da

---

# スケーリングを無効にする方法   
アプリケーションは既定で、XAML アプリの場合は 200% に、HTML アプリの場合は 150% に拡大されます。 また、既定の倍率を無効にすることもできます。 これにより、アプリケーションをデバイスの実際のピクセル サイズ (1910 x 1080 ピクセル) で使うことができるようになります。   
   
## HTML   
次のコード スニペットを使って倍率を無効にすることができます。 
   
`var result = Windows.UI.ViewManagement.ApplicationViewScaling.trySetDisableLayoutScaling(true);` 

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



<!--HONumber=Jul16_HO1-->


