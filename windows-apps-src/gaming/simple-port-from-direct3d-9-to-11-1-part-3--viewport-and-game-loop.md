---
author: mtoepke
title: ゲーム ループの移植
description: IFrameworkView を作成して、全画面表示の CoreWindow を制御する方法など、ユニバーサル Windows プラットフォーム (UWP) ゲームのウィンドウを実装する方法とゲーム ループを移植する方法について説明します。
ms.assetid: 070dd802-cb27-4672-12ba-a7f036ff495c
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 移植, ゲーム ループ, Direct3D 9, DirectX 11
ms.localizationpriority: medium
ms.openlocfilehash: 4db2ed74144ead22643ece17a7496b6267f7e6b8
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5928510"
---
# <a name="port-the-game-loop"></a>ゲーム ループの移植



**概要**

-   [パート 1: Direct3D 11 の初期化](simple-port-from-direct3d-9-to-11-1-part-1--initializing-direct3d.md)
-   [パート 2: レンダリング フレームワークの変換](simple-port-from-direct3d-9-to-11-1-part-2--rendering.md)
-   パート 3: ゲーム ループの移植


[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を作成して、全画面表示の [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) を制御する方法など、ユニバーサル Windows プラットフォーム (UWP) ゲームのウィンドウを実装する方法とゲーム ループを移植する方法について説明します。 「[チュートリアル: DirectX 11 とユニバーサル Windows プラットフォーム (UWP) への簡単な Direct3D 9 アプリの移植](walkthrough--simple-port-from-direct3d-9-to-11-1.md)」のパート 3 です。

## <a name="create-a-window"></a>ウィンドウの作成


Direct3D 9 のビューポートを使ってデスクトップ ウィンドウを設定するためには、デスクトップ アプリ用の従来のウィンドウ フレームワークを実装する必要がありました。 また、HWND の作成、ウィンドウ サイズの設定、ウィンドウ処理コールバックの提供、ウィンドウの表示などを実行する必要もありました。

UWP 環境には、はるかに簡単なシステムが用意されています。 DirectX を使った Microsoft Store ゲームでは、従来のウィンドウを設定する代わりに、[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) を実装します。 このインターフェイスは、アプリ コンテナー内の [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) で直接 DirectX アプリやゲームを実行するために存在します。

> **注:**  Windows は、ソース アプリケーション オブジェクトや[**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225)などのリソースへの管理ポインターを提供します。 [**オブジェクト演算子 (^) へのハンドル**を] を参照してください。https://msdn.microsoft.com/library/windows/apps/yk97tc08.aspxします。

 

"main" クラスには、[**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) から継承し、5 つの **IFrameworkView** メソッド ([**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495)、[**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509)、[**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501)、[**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505)、[**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523)) を実装する必要があります。 (実質的に) ゲームが存在する場所となる **IFrameworkView** の作成に加えて、**IFrameworkView** のインスタンスを作成するファクトリ クラスを実装する必要があります。 ゲームにはこれまでどおり **main()** と呼ばれるメソッドを含む実行可能ファイルが存在しますが、main で実行できる操作は、ファクトリを使って、**IFrameworkView** のインスタンスを作成することだけです。

main 関数

```cpp
//-----------------------------------------------------------------------------
// Required method for a DirectX-only app.
// The main function is only used to initialize the app's IFrameworkView class.
//-----------------------------------------------------------------------------
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}
```

IFrameworkView ファクトリ

```cpp
//-----------------------------------------------------------------------------
// This class creates our IFrameworkView.
//-----------------------------------------------------------------------------
ref class Direct3DApplicationSource sealed : 
    Windows::ApplicationModel::Core::IFrameworkViewSource
{
public:
    virtual Windows::ApplicationModel::Core::IFrameworkView^ CreateView()
    {
        return ref new Cube11();
    };
};
```

## <a name="port-the-game-loop"></a>ゲーム ループの移植


次に、Direct3D 9 の実装のゲーム ループを見てみましょう。 このコードは、アプリの main 関数内に存在します。 このループの各反復では、ウィンドウ メッセージを処理するか、フレームをレンダリングします。

Direct3D 9 デスクトップ ゲームのゲーム ループ

```cpp
while(WM_QUIT != msg.message)
{
    // Process window events.
    // Use PeekMessage() so we can use idle time to render the scene. 
    bGotMsg = (PeekMessage(&msg, NULL, 0U, 0U, PM_REMOVE) != 0);

    if(bGotMsg)
    {
        // Translate and dispatch the message
        TranslateMessage(&msg);
        DispatchMessage(&msg);
    }
    else
    {
        // Render a new frame.
        // Render frames during idle time (when no messages are waiting).
        RenderFrame();
    }
}
```

このゲーム ループは、UWP バージョンのゲームと似ていますが、それよりも簡単です。

このゲームは [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700478) クラス内で機能するため、ゲーム ループは (**main()** ではなく) [**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドで実行されます。

メッセージ処理フレームワークを実装し、[**PeekMessage**](https://msdn.microsoft.com/library/windows/desktop/ms644943) を呼び出す代わりに、アプリ ウィンドウの [**CoreDispatcher**](https://msdn.microsoft.com/library/windows/apps/br208211) に組み込まれている [**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) メソッドを呼び出すことができます。 ゲーム ループで分岐し、メッセージを処理する必要はありません。**ProcessEvents** を呼び出し、次に進むだけです。

Direct3D 11 Microsoft Store ゲームのゲーム ループ

```cpp
// UWP apps should not exit. Use app lifecycle events instead.
while (true)
{
    // Process window events.
    auto dispatcher = CoreWindow::GetForCurrentThread()->Dispatcher;
    dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

    // Render a new frame.
    RenderFrame();
}
```

これで、DirectX 9 の例と同じように、基本的なグラフィックス インフラストラクチャをセットアップし、同じカラフルな立方体をレンダリングする UWP アプリが完成しました。

## <a name="where-do-i-go-from-here"></a>次の段階


「[DirectX 11 の移植に関する FAQ](directx-porting-faq.md)」をブックマークに追加してください。

DirectX UWP テンプレートには、ゲームですぐに使うことができる堅牢な Direct3D デバイス インフラストラクチャが含まれています。 適切なテンプレートを選ぶためのガイダンスについては、「[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。

Microsoft Store ゲームの開発に関する次の詳しい記事をご覧ください。

-   [チュートリアル: DirectX によるシンプルな UWP ゲームの作成](tutorial--create-your-first-uwp-directx-game.md)
-   [ゲームのオーディオ](working-with-audio-in-your-directx-game.md)
-   [ゲームのムーブ/ルック コントロール](tutorial--adding-move-look-controls-to-your-directx-game.md)

 

 




