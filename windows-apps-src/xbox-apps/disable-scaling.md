---
author: payzer
title: "スケーリングを無効にする方法"
description: "既定の倍率を無効にする方法を説明します。"
translationtype: Human Translation
ms.sourcegitcommit: 582f5677c15f7cd62c398103b48743ba4bea6c5b
ms.openlocfilehash: 8079be9685558277565766fa8d0ebbfd4a555904

---

# スケーリングを無効にする方法   
アプリケーションは既定で、XAML アプリの場合は 200% に、HTML アプリの場合は 150% に拡大されます。 また、既定の倍率を無効にすることもできます。 これにより、アプリケーションをデバイスの実際のピクセル サイズ (1910 x 1080 ピクセル) で使うことができるようになります。   
   
## HTML   
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

## XAML
次のコード スニペットを使って倍率を無効にすることができます。   
   
```
bool result = Windows.UI.ViewManagement.ApplicationViewScaling.TrySetDisableLayoutScaling(true);
```
   
## DirectX/C++   
DirectX/C++ アプリケーションはスケーリングされません。 自動スケーリングは、HTML アプリケーションと XAML アプリケーションにのみ適用されます。  

## 関連項目
- [Xbox のベスト プラクティス](tailoring-for-xbox.md)
- [Xbox One の UWP](index.md)



<!--HONumber=Aug16_HO3-->


