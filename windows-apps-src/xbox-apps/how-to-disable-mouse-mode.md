---
author: payzer
title: "マウス モードを無効にする方法"
description: "既定のマウス モードを無効にするための指示。"
translationtype: Human Translation
ms.sourcegitcommit: b4df1f944d909640791e4ed7e3bcf8d8bdf7a0d1
ms.openlocfilehash: 91e530a3313d53c4e693b88a64b849f3188a72de

---

# マウス モードを無効にする方法
マウス モードは、すべてのアプリケーションについて既定でオンになっています。つまり、オプトアウトしていないすべてのアプリケーションがマウス ポインターを受け取ります (コンソール上の Edge ブラウザー内のアプリケーションに似ています)。 コントローラーの方向移動操作を最適化するため、マウス モードは無効にすることを強くお勧めします。   
   
## HTML   
JavaScript ユニバーサル Windows プラットフォーム (UWP) アプリでコントローラーの方向移動操作を有効にするには、[TVHelpers 方向ナビゲーション](https://github.com/Microsoft/TVHelpers/wiki/Using-DirectionalNavigation) JavaScript ライブラリを使います。 アプリ パッケージに方向ナビゲーションの JavaScript ファイルを含め、コントローラーの方向移動操作を必要とするすべての HTML ページにこのファイルへの参照を追加します。

```code
<script src="directionalnavigation-1.0.0.0.js"></script>
```
詳しくは、[方向ナビゲーションに関する Wiki](https://github.com/Microsoft/TVHelpers/wiki/Using-DirectionalNavigation) をご覧ください。

マウス モードをオフにして、DOM または WinRT のゲームパッド API を直接使う場合は、API を必要とするすべてのページで次のコードを実行します。 
   
```code
navigator.gamepadInputEmulation = "gamepad";
```   

   このプロパティの既定値は `mouse` で、マウス モードを有効にします。 このプロパティを `keyboard` に設定すると、マウス モードが無効になり、代わりにゲームパッドによって DOM のキーボード イベントが生成されます。 このプロパティを `gamepad` に設定すると、マウス モードは無効になりますが、DOM のキーボード イベントは生成されず、DOM または WinRT のゲームパッド API のみを使用できます。

## XAML    
マウス モードを無効にするには、次のコードをアプリのコンストラクターに追加します。   
   
```code
public App() {
        this.InitializeComponent();
        this.RequiresPointerMode = Windows.UI.Xaml.ApplicationRequiresPointerMode.WhenRequested;
        this.Suspending += OnSuspending;
}
```

## C++/DirectX   
C++/DirectX アプリを作成する場合は、特に操作は必要ありません。 マウス モードは、HTML アプリケーションと XAML アプリケーションのみに適用されます。

## 関連項目
- [Xbox のベスト プラクティス](tailoring-for-xbox.md)
- [Xbox One の UWP](index.md)




<!--HONumber=Aug16_HO3-->


