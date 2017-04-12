---
author: mtoepke
title: "ゲーム プロジェクトのセットアップ"
description: "ゲームを作るための最初の手順は、必要なコード インフラストラクチャ作業の量を最小限に抑えるように Microsoft Visual Studio でプロジェクトを設定することです。"
ms.assetid: 9fde90b3-bf79-bcb3-03b6-d38ab85803f2
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, セットアップ, DirectX"
ms.openlocfilehash: 3bf9e6f70f71dc0b70a2f8af148c44acc1a329fb
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="set-up-the-game-project"></a>ゲーム プロジェクトのセットアップ


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

ゲームを作るための最初の手順は、必要なコード インフラストラクチャ作業の量を最小限に抑えるように Microsoft Visual Studio でプロジェクトを設定することです。 適切なテンプレートを使い、ゲーム開発用にプロジェクトを構成することで、時間や手間を大幅に節約できます。 シンプルなゲーム プロジェクトを設定および構成する手順を紹介します。

## <a name="objective"></a>目標


-   Visual Studio で Direct3D ゲーム プロジェクトを設定する方法について理解する。

## <a name="setting-up-the-game-project"></a>ゲーム プロジェクトの設定


手頃なテキスト エディター、いくつかのサンプル、十分な初心者の頭脳があれば、一からゲームを作ることもできます。 しかし、これでは時間を有効に使っているとは言えません。 ユニバーサル Windows プラットフォーム (UWP) 開発プラットフォームに詳しくない場合は、Visual Studio を利用することをお勧めします。 次に、プロジェクトを開始するための手順について説明します。

## <a name="1-pick-the-right-template"></a>1. 適切なテンプレートを選ぶ


Visual Studio テンプレートは、優先する言語および技術に基づいて、特定の種類のアプリ向けの設定とコード ファイルを集めたものです。 Microsoft Visual Studio 2015 には多くのテンプレートがあり、これらを使うと、ゲームやグラフィックス アプリを簡単に開発することができます。 テンプレートを使わない場合、基本的なグラフィックス レンダリングや表示フレームワークの大部分を自分で開発しなければならず、これは新人のゲーム開発者にとっては骨の折れる仕事となります。

このチュートリアルのための適切なテンプレートは、DirectX 11 アプリ (ユニバーサル Windows) です。 Visual Studio 2015 で、**[ファイル]** &gt; **[新しいプロジェクト]** の順にクリックし、次の手順に従います。

1.  **[テンプレート]** から **[Visual C++]**、**[Windows]**、**[ユニバーサル]**の順に選びます。
2.  中央のウィンドウで、**[DirectX 11 アプリ (ユニバーサル Windows)]** テンプレートを選びます。
3.  ゲーム プロジェクトに名前を付けて、**[OK]** をクリックします。

![Direct3D アプリケーション テンプレートの選択](images/simple-dx-game-vs-new-proj.png)

このテンプレートは、DirectX と C++ を使った UWP アプリの基本的なフレームワークを提供します。 F5 キーでビルドして実行してみましょう。 パウダー ブルーの画面を確認します。 少し時間をとって、テンプレートによって提供されたコードを見てみます。 このテンプレートは、DirectX と C++ を使った UWP アプリの基本的な機能が含まれているコード ファイルを複数作成します。 他のコード ファイルについては、[手順 3](#3-review-the-included-libraries-and-headers) で詳しく説明します。 ここでは、**App.h** を簡単に見ておきましょう。

```cpp
    ref class App sealed : public Windows::ApplicationModel::Core::IFrameworkView
    {
    public:
        App();

        // IFrameworkView Methods.
        virtual void Initialize(Windows::ApplicationModel::Core::CoreApplicationView^ applicationView);
        virtual void SetWindow(Windows::UI::Core::CoreWindow^ window);
        virtual void Load(Platform::String^ entryPoint);
        virtual void Run();
        virtual void Uninitialize();

    protected:
        // Application lifecycle event handlers.
        void OnActivated(Windows::ApplicationModel::Core::CoreApplicationView^ applicationView, Windows::ApplicationModel::Activation::IActivatedEventArgs^ args);
        void OnSuspending(Platform::Object^ sender, Windows::ApplicationModel::SuspendingEventArgs^ args);
        void OnResuming(Platform::Object^ sender, Platform::Object^ args);

        // Window event handlers.
        void OnWindowSizeChanged(Windows::UI::Core::CoreWindow^ sender, Windows::UI::Core::WindowSizeChangedEventArgs^ args);
        void OnVisibilityChanged(Windows::UI::Core::CoreWindow^ sender, Windows::UI::Core::VisibilityChangedEventArgs^ args);
        void OnWindowClosed(Windows::UI::Core::CoreWindow^ sender, Windows::UI::Core::CoreWindowEventArgs^ args);

        // DisplayInformation event handlers.
        void OnDpiChanged(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);
        void OnOrientationChanged(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);
        void OnDisplayContentsInvalidated(Windows::Graphics::Display::DisplayInformation^ sender, Platform::Object^ args);

    private:
        std::shared_ptr<DX::DeviceResources> m_deviceResources;
        std::unique_ptr<MyAwesomeGameMain> m_main;
        bool m_windowClosed;
        bool m_windowVisible;
    };
```

ビュー プロバイダーを定義する [**IFrameworkView**](https://msdn.microsoft.com/library/windows/apps/hh700469) インターフェイスを実装する際に、[**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495)、[**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509)、[**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501)、[**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505)、[**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523) の 5 つのメソッドを作成します。 これらのメソッドはゲームの起動時に作成されるアプリ シングルトンによって実行され、適切なイベント ハンドラーに接続されて、アプリのすべてのリソースが読み込まれます。

**main** メソッドは、**App.cpp** ソース ファイルにあります。 次のようになります。

```cpp
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}
```

ここではビュー プロバイダー ファクトリから Direct3D ビュー プロバイダーのインスタンスが作成され (**App.h** で定義された **Direct3DApplicationSource**)、アプリ シングルトンに渡されて実行されます ([**CoreApplication::Run**](https://msdn.microsoft.com/library/windows/apps/hh700469))。 つまり、ゲームの出発点は、[**IFrameworkView::Run**](https://msdn.microsoft.com/library/windows/apps/hh700505) メソッドの実装の本文にあります (この場合は **App::Run**)。 コードは次のようになります。

```cpp
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_windowVisible)
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

            m_main->Update();

            if (m_main->Render())
            {
                m_deviceResources->Present();
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
}
```

ゲームのウィンドウを閉じなければ、すべてのイベントがディスパッチされ、タイマーが更新され、グラフィックス パイプラインの結果がレンダリングされて表示されます。 これについては、「[ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義](tutorial--building-the-games-metro-style-app-framework.md) 」と「[レンダリング フレームワークの作成](tutorial--assembling-the-rendering-pipeline.md)」で詳しく説明します。 これで、UWP DirectX ゲームのコードの基本構造については理解できました。

## <a name="2-review-and-update-the-packageappxmanifest-file"></a>2. package.appxmanifest ファイルを確認して更新する


テンプレートに含まれるのはコード ファイルだけではありません。 **package.appxmanifest** ファイルには、ゲームのパッケージ化と起動や Windows ストアへの提出に使うプロジェクトのメタデータが含まれます。 プレーヤーのシステムがゲームの実行に必要なリソースへのアクセスを提供するための、重要な情報も含まれます。

**ソリューション エクスプローラー**で **package.appxmanifest** ファイルをダブルクリックして、**マニフェスト デザイナー**を起動します。 次のビューが表示されます。

![package.appxmanifest エディター。](images/simple-dx-game-vs-app-manifest.png)

**package.appxmanifest** ファイルとパッケージ化について詳しくは、[マニフェスト デザイナー](https://msdn.microsoft.com/library/windows/apps/br230259.aspx)に関するページをご覧ください。 それでは、**[機能]** タブとそのオプションを見てみましょう。

![Direct3D アプリの既定の機能。](images/simple-dx-game-vs-capabilities.png)

グローバルなハイ スコア ボードのための**インターネット**へのアクセスなど、ゲームで使う機能を選択しないと、該当するリソースや機能にアクセスできません。 新しいゲームを作る場合、ゲームの実行に必要な機能を忘れずに選択してください。

次に、**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートの残りのファイルを見てみましょう。

## <a name="3-review-the-included-libraries-and-headers"></a>3. 含まれているライブラリとヘッダーを確認する


まだ確認していないファイルがいくつかあります。 それは、Direct3D ゲーム開発シナリオに共通するその他のツールとサポートを提供するファイルです。

| テンプレート ソース ファイル         | 説明                                                                                                                                                                                                            |
|------------------------------|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| StepTimer.h                  | ゲーム アプリまたは対話型レンダリング アプリで役に立つ、高分解能タイマーを定義します。                                                                                                                                       |
| Sample3DSceneRenderer.h/.cpp | DirectX を使った UWP に Direct3D スワップ チェーンとグラフィックス アダプターを接続する基本的なレンダラー実装を定義します。                                                                                            |
| DirectXHelper.h              | DirectX API によって返されたエラー HRESULT 値を Windows ランタイム例外に変換する、単一のメソッド **DX::ThrowIfFailed** を実装します。 このメソッドを使って、DirectX エラーをデバッグするためのブレーク ポイントを配置します。 |
| pch.h/.cpp                   | DirectX 11 API など、Direct3D アプリで使われる API 用のすべての Windows システム インクルードが含まれます。                                                                                                           |
| SamplePixelShader.hlsl       | 非常に基本的なピクセル シェーダー用の上位レベル シェーダー言語 (HLSL) コードが含まれます。                                                                                                                                     |
| SampleVertexShader.hlsl      | 非常に基本的な頂点シェーダー用の上位レベル シェーダー言語 (HLSL) コードが含まれます。                                                                                                                                    |

 

### <a name="next-steps"></a>次のステップ

これで、DirectX を使った UWP ゲーム プロジェクトを作成して、DirectX 11 アプリ (ユニバーサル Windows) テンプレートで提供されるコンポーネントとファイルを識別できるようになりました。

次のチュートリアル、「 [ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義](tutorial--building-the-games-metro-style-app-framework.md)」では、完成したゲームを使って、テンプレートで提供される多くの概念やコンポーネントをどのように利用したり拡張したりするかを確認します。

 

 




