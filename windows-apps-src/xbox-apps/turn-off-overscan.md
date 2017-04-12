---
author: payzer
title: "画面の端に UI を描画する方法"
description: "タイトル セーフ エリアの自動スケーリングを無効にする方法です。"
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 1adb221f-6f70-4255-9329-2046a486ca45
ms.openlocfilehash: 30fc3e357eaea0d36a5deba1b0ea85c2d9bc990e
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="how-to-draw-ui-to-the-edge-of-the-screen"></a>画面の端に UI を描画する方法   
既定では、テレビのセーフ エリアを考慮して、アプリケーションのビューポートの端には境界線が表示されます (詳しくは「[Xbox およびテレビ向け設計](../input-and-devices/designing-for-tv.md#tv-safe-area)」をご覧ください)。 

この設定をオフにして、画面の端に描画することをお勧めします。 アプリケーションの起動時に次のコードを追加することによって、画面の端に描画することができます。
   
```
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```
   
> [!NOTE]
> C++/DirectX アプリケーションの場合、この問題について心配する必要はありません。 システムでは、常にアプリケーションが画面の端にレンダリングされます。

## <a name="see-also"></a>関連項目
- [Xbox のベスト プラクティス](tailoring-for-xbox.md)
- [Xbox One の UWP](index.md)
