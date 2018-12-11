---
title: 画面の端に UI を描画する方法
description: タイトル セーフ エリアの自動スケーリングを無効にする方法です。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: 1adb221f-6f70-4255-9329-2046a486ca45
ms.localizationpriority: medium
ms.openlocfilehash: 1ac49d80f1d99a56eff565a0daa8f2f3e9289636
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8891106"
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
