---
author: payzer
title: "マウス モードを無効にする方法"
description: 
area: Xbox
ms.sourcegitcommit: bdf7a32d2f0673ab6c176a775b805eff2b7cf437
ms.openlocfilehash: bd7780f105f86d7d292c5db2535ad40af07d6e4f

---

# マウス モードを無効にする方法
すべてのアプリケーションでは、マウス モードが既定で有効になっています。 つまり、この既定の設定を無効にしていないすべてのアプリケーションは、本体での Edge ブラウザーの場合と同様に、マウス ポインターを受け入れます。 コントローラーの方向移動操作を最適化するため、マウス モードは無効にすることを強くお勧めします。   
   
## HTML   
マウス モードを無効にするには、アプリケーションの JavaScript ファイルに以下を追加します。   
   
```code
navigator.gamepadInputEmulation = "keyboard";
```   

## XAML    
マウス モードを無効にするには、アプリケーションの JavaScript ファイルに以下を追加します。   
   
```code
public App() {
        this.InitializeComponent();
        this.RequiresPointerMode = Windows.UI.Xaml.ApplicationRequiresPointerMode.WhenRequested;
        this.Suspending += OnSuspending;
        }
```

## C++/DirectX   
C++/DirectX アプリを作成する場合は、特に操作は必要ありません。 マウス モードは、HTML アプリケーションと XAML アプリケーションのみに適用されます。



<!--HONumber=Jun16_HO4-->


