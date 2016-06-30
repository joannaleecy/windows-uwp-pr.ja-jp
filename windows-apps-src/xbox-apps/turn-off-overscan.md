---
author: payzer
title: "オーバースキャンを無効にする方法"
description: 
area: Xbox
ms.sourcegitcommit: 32a875348debac9aec9f5a26bc4e7e0af2a0a5b4
ms.openlocfilehash: abd06e78364ff32cc10d733e33b153b854dbc467

---

# 画面の端に UI を描画する方法   
既定では、アプリケーションのビューポートの境界に、境界線が表示されます。 これは、テレビのセーフ エリアを構成しています。 詳しくは、「[Xbox およびテレビ向け設計](http://go.microsoft.com/fwlink/?LinkID=760736#tv-safe-area)」をご覧ください。  この設定をオフにして、画面の端に描画することをお勧めします。 アプリケーションの起動時に次のコードを追加することによって、画面の端に描画することができます。
   
`Windows.UI.ViewManagement.ApplicationView.GetForCurrentView().SetDesiredBoundsMode(Windows.UI.ViewManagement.ApplicationViewBoundsMode.UseCoreWindow);`
   
注: C++/DirectX アプリケーションの場合、この問題について心配する必要はありません。 システムでは、常にアプリケーションが画面の端にレンダリングされます。



<!--HONumber=Jun16_HO4-->


