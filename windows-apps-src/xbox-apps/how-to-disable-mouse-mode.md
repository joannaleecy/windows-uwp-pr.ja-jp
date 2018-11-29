---
title: マウス モードを無効にする方法
description: 既定のマウス モードを無効にするための操作手順。
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.assetid: e57ee4e6-7807-4943-a933-c2b4dc80fc01
ms.localizationpriority: medium
ms.openlocfilehash: 1e4b8868f416494daf978d65d4a4ccde02d6ccf5
ms.sourcegitcommit: 89ff8ff88ef58f4fe6d3b1368fe94f62e59118ad
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/29/2018
ms.locfileid: "8188637"
---
# <a name="how-to-disable-mouse-mode"></a><span data-ttu-id="71c2d-104">マウス モードを無効にする方法</span><span class="sxs-lookup"><span data-stu-id="71c2d-104">How to disable mouse mode</span></span>
<span data-ttu-id="71c2d-105">マウス モードは、すべてのアプリケーションについて既定でオンになっています。つまり、オプトアウトしていないすべてのアプリケーションがマウス ポインターを受け取ります (コンソール上の Edge ブラウザー内のアプリケーションに似ています)。</span><span class="sxs-lookup"><span data-stu-id="71c2d-105">Mouse mode is on by default for all applications, which means that all applications that have not opted out will receive a mouse pointer (similar to the one in the Edge browser on the console).</span></span> <span data-ttu-id="71c2d-106">コントローラーの方向移動操作を最適化するため、マウス モードは無効にすることを強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="71c2d-106">We strongly recommend that you turn this off and optimize for directional controller navigation.</span></span>   
   
## <a name="html"></a><span data-ttu-id="71c2d-107">HTML</span><span class="sxs-lookup"><span data-stu-id="71c2d-107">HTML</span></span>   
<span data-ttu-id="71c2d-108">JavaScript ユニバーサル Windows プラットフォーム (UWP) アプリでコントローラーの方向移動操作を有効にするには、[TVHelpers 方向ナビゲーション](https://github.com/Microsoft/TVHelpers/wiki/Using-DirectionalNavigation) JavaScript ライブラリを使います。</span><span class="sxs-lookup"><span data-stu-id="71c2d-108">To turn on directional controller navigation in a JavaScript Universal Windows Platform (UWP) app, use the [TVHelpers directional navigation](https://github.com/Microsoft/TVHelpers/wiki/Using-DirectionalNavigation) JavaScript library.</span></span> <span data-ttu-id="71c2d-109">アプリ パッケージに方向ナビゲーションの JavaScript ファイルを含め、コントローラーの方向移動操作を必要とするすべての HTML ページにこのファイルへの参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="71c2d-109">Include the directional navigation JavaScript file in your app package, and add a reference to it in all of the HTML pages that require directional controller navigation:</span></span>

```code
<script src="directionalnavigation-1.0.0.0.js"></script>
```
<span data-ttu-id="71c2d-110">詳しくは、[方向ナビゲーションに関する Wiki](https://github.com/Microsoft/TVHelpers/wiki/Using-DirectionalNavigation) をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="71c2d-110">For more details, see the [directional navigation wiki](https://github.com/Microsoft/TVHelpers/wiki/Using-DirectionalNavigation).</span></span>

<span data-ttu-id="71c2d-111">マウス モードをオフにして、DOM または WinRT のゲームパッド API を直接使う場合は、API を必要とするすべてのページで次のコードを実行します。</span><span class="sxs-lookup"><span data-stu-id="71c2d-111">If you instead want to turn off mouse mode and use the DOM or WinRT gamepad APIs directly, run the following for every page that requires it:</span></span> 
   
```code
navigator.gamepadInputEmulation = "gamepad";
```   

   <span data-ttu-id="71c2d-112">このプロパティの既定値は `mouse` で、マウス モードを有効にします。</span><span class="sxs-lookup"><span data-stu-id="71c2d-112">This property defaults to `mouse`, which enables mouse mode.</span></span> <span data-ttu-id="71c2d-113">このプロパティを `keyboard` に設定すると、マウス モードが無効になり、代わりにゲームパッドによって DOM のキーボード イベントが生成されます。</span><span class="sxs-lookup"><span data-stu-id="71c2d-113">Setting it to `keyboard` turns off mouse mode, and instead gamepad input generates DOM keyboard events.</span></span> <span data-ttu-id="71c2d-114">このプロパティを `gamepad` に設定すると、マウス モードは無効になりますが、DOM のキーボード イベントは生成されず、DOM または WinRT のゲームパッド API のみを使用できます。</span><span class="sxs-lookup"><span data-stu-id="71c2d-114">Setting it to `gamepad` turns off mouse mode and does not generate DOM keyboard events, and allows you to just use the DOM or WinRT gamepad APIs.</span></span>

## <a name="xaml"></a><span data-ttu-id="71c2d-115">XAML</span><span class="sxs-lookup"><span data-stu-id="71c2d-115">XAML</span></span>    
<span data-ttu-id="71c2d-116">マウス モードを無効にするには、次のコードをアプリのコンストラクターに追加します。</span><span class="sxs-lookup"><span data-stu-id="71c2d-116">To turn off mouse mode, add the following to the constructor for your app:</span></span>   
   
```code
public App() {
        this.InitializeComponent();
        this.RequiresPointerMode = Windows.UI.Xaml.ApplicationRequiresPointerMode.WhenRequested;
        this.Suspending += OnSuspending;
}
```

## <a name="cdirectx"></a><span data-ttu-id="71c2d-117">C++/DirectX</span><span class="sxs-lookup"><span data-stu-id="71c2d-117">C++/DirectX</span></span>   
<span data-ttu-id="71c2d-118">C++/DirectX アプリを作成する場合は、特に操作は必要ありません。</span><span class="sxs-lookup"><span data-stu-id="71c2d-118">If you are writing a C++/DirectX app, there's nothing to do.</span></span> <span data-ttu-id="71c2d-119">マウス モードは、HTML アプリケーションと XAML アプリケーションのみに適用されます。</span><span class="sxs-lookup"><span data-stu-id="71c2d-119">Mouse mode only applies to HTML and XAML applications.</span></span>

## <a name="see-also"></a><span data-ttu-id="71c2d-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="71c2d-120">See also</span></span>
- [<span data-ttu-id="71c2d-121">Xbox のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="71c2d-121">Best practices for Xbox</span></span>](tailoring-for-xbox.md)
- [<span data-ttu-id="71c2d-122">Xbox One の UWP</span><span class="sxs-lookup"><span data-stu-id="71c2d-122">UWP on Xbox One</span></span>](index.md)

