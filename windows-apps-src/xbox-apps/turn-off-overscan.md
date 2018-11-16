---
author: payzer
title: 画面の端に UI を描画する方法
description: タイトル セーフ エリアの自動スケーリングを無効にする方法です。
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 1adb221f-6f70-4255-9329-2046a486ca45
ms.localizationpriority: medium
ms.openlocfilehash: 32932845db47ed47b7e80f68cf4e424ba97e85c0
ms.sourcegitcommit: e2fca6c79f31e521ba76f7ecf343cf8f278e6a15
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/16/2018
ms.locfileid: "6993463"
---
# <a name="how-to-draw-ui-to-the-edge-of-the-screen"></a>画面の端に UI を描画する方法   
既定では、テレビのセーフ エリアを考慮して、アプリケーションのビューポートの端には境界線が表示されます (詳しくは「[Xbox およびテレビ向け設計](../design/devices/designing-for-tv.md#tv-safe-area)」をご覧ください)。 

この設定をオフにして、画面の端に描画することをお勧めします。 アプリケーションの起動時に次のコードを追加することによって、画面の端に描画することができます。
   
```
Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);
```
   
> [!NOTE]
> C++/DirectX アプリケーションの場合、この問題について心配する必要はありません。 システムでは、常にアプリケーションが画面の端にレンダリングされます。

## <a name="see-also"></a>関連項目
- [Xbox のベスト プラクティス](tailoring-for-xbox.md)
- [Xbox One の UWP](index.md)
