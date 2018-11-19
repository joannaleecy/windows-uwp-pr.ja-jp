---
author: joannaleecy
title: ゲームの UWP アプリ フレームワークの定義
description: DirectX によるユニバーサル Windows プラットフォーム (UWP) ゲームのコーディングでは、まず、ゲーム オブジェクトと Windows との対話を可能にするフレームワークを構築します。
ms.assetid: 7beac1eb-ba3d-e15c-44a1-da2f5a79bb3b
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 3444c71b4e4c610be0b7d92ac6d761340c5dd5c2
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7290295"
---
#  <a name="define-the-uwp-app-framework"></a>UWP アプリ フレームワークの定義

中断/再開イベント、ウィンドウのフォーカスの変更、スナップなどの Windows ランタイム プロパティを含め、ゲーム オブジェクトが Windows とやり取りできるようにするためのフレームワークを構築します。

このフレームワークを設定するために、まず、アプリ シングルトン (実行中のアプリのインスタンスを定義する Windows ランタイム オブジェクト) が必要なグラフィック リソースにアクセスできるようにするビュー プロバイダーを取得します。 Windows ランタイムを通じて、ゲームはグラフィックス インターフェイスに直接接続して、必要なリソースとその処理方法を指定することもできます。

ビュー プロバイダー オブジェクトは、__IFrameworkView__ インターフェイスを実装します。これには、このゲーム サンプルを作成するために構成する必要がある一連のメソッドが含まれています。

アプリ シングルトンが呼び出す次の 5 つのメソッドを実装する必要があります。
* [__Initialize__](#initialize-the-view-provider)
* [__SetWindow__](#configure-the-window-and-display-behavior)
* [__Load__](#load-method-of-the-view-provider)
* [__Run__](#run-method-of-the-view-provider)
* [__Uninitialize__](#uninitialize-method-of-the-view-provider)

__Initialize__ メソッドは、アプリケーションの起動時に呼び出されます。 __SetWindow__ メソッドは __Initialize__ の後に呼び出されます。 次に、__Load__ メソッドが呼び出されます。 __Run__ メソッドはゲームの実行中に呼び出されます。 ゲームが終了すると、__Uninitialize__ メソッドが呼び出されます。 詳しくは、[__IFrameworkView__ の API リファレンス](https://docs.microsoft.com/uwp/api/windows.applicationmodel.core.iframeworkview)を参照してください。 

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="objective"></a>目標

ユニバーサル Windows プラットフォーム (UWP) DirectX ゲーム用のフレームワークをセットアップし、ゲーム全体のフローを定義するステート マシンを実装します。

## <a name="define-the-view-provider-factory-and-view-provider-object"></a>ビュー プロバイダー ファクトリとビュー プロバイダー オブジェクトを定義する

__App.cpp__ 内の __main__ ループを見てみましょう。 

この手順では、ビューのファクトリを作成 (__IFrameworkViewSource__ を実装) し、次に、ビューを定義するビュー プロバイダー オブジェクトのインスタンスを作成 (__IFrameworkView__ を実装) します。

### <a name="main-method"></a>Main メソッド

GitHub サンプル コードを読み込んでいる場合は、新しい __DirectXApplicationSource__ を作成します  (元の DirectX テンプレートを使用している場合は __Direct3DApplicationSource__ を使用します)。これは、__IFrameworkViewSource__ を実装するビュー プロバイダー ファクトリです。 ビュー プロバイダー ファクトリの __IFrameworkViewSource__ インターフェイスには、__CreateView__ という単一のメソッドが定義されています。

__CoreApplication::Run__ では、__Direct3DApplicationSource__ または __DirectXApplicationSource__ が渡されたときに、アプリ シングルトンによって __CreateView__ メソッドが呼び出されます。

__CreateView__ は、__IFrameworkView__ を実装するアプリ オブジェクトの新しいインスタンスへの参照を返します。これは、このサンプルでは __App__ クラス オブジェクトです。 __App__ クラス オブジェクトがビュー プロバイダー オブジェクトです。

```cpp
// The main function is only used to initialize our IFrameworkView class.
[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto directXApplicationSource = ref new DirectXApplicationSource();
    CoreApplication::Run(directXApplicationSource);
    return 0;
}

//--------------------------------------------------------------------------------------

IFrameworkView^ DirectXApplicationSource::CreateView()
{
    return ref new App();
}
```

## <a name="initialize-the-view-provider"></a>ビュー プロバイダーを初期化する

ビュー プロバイダー オブジェクトが作成されたら、アプリケーションの起動時に、アプリ シングルトンが [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495) メソッドを呼び出します。 このため、メイン ウィンドウのアクティブ化の処理や、ゲームが突然の中断 (とその後に行われる場合がある再開) イベントを処理できることの確認など、UWP ゲームの最も基本的な動作をこのメソッドで処理することが非常に重要です。

この時点で、ゲーム アプリは一時停止 (または再開) メッセージを処理できます。 ただし、まだ操作するウィンドウはなく、ゲームは初期化されていません。 必要なことが、あといくつか残っています。

### <a name="appinitialize-method"></a>App::Initialize メソッド

このメソッドでは、ゲームのアクティブ化、一時停止、再開のためのさまざまなイベント ハンドラーを作成します。

デバイス リソースへのアクセスを取得します。 メモリ リソースが最初に作成されたときに、__make_shared__ 関数を使用して __shared_ptr__ を作成します。 __make_shared__ を使用する利点は例外安全性です。 また、同じ呼び出しを使用して、制御ブロックとリソースにメモリを割り当てて、構築にかかるオーバーヘッドを削減します。

```cpp
void App::Initialize(
    CoreApplicationView^ applicationView
    )
{
    // Register event handlers for app lifecycle. This example includes Activated, so that we
    // can make the CoreWindow active and start rendering on the window.
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);

    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);

    // At this point we have access to the device. 
    // We can create the device-dependent resources.
    m_deviceResources = std::make_shared<DX::DeviceResources>();
}
```

## <a name="configure-the-window-and-display-behaviors"></a>ウィンドウと表示動作を構成する

ここでは、[__SetWindow__](https://msdn.microsoft.com/library/windows/apps/hh700509) の実装を見てみましょう。 __SetWindow__ メソッドでは、ウィンドウと表示動作を構成します。

### <a name="appsetwindow-method"></a>App::SetWindow メソッド

アプリ シングルトンは、ゲームのメイン ウィンドウを表す [__CoreWindow__](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトを提供し、そのリソースとイベントをゲームで使用できるようにします。 操作するウィンドウができたら、ゲームの基本的な UI コンポーネントとイベントを追加できます。

次に、マウスとタッチ コントロールの両方で使用できる __CoreCursor__ メソッドを使用してポインターを作成します。

最後に、(ディスプレイ デバイスが変更された場合に) ウィンドウのサイズ変更、終了、DPI 変更を行うための基本的なイベントを作成します。 これらのイベントの詳細については、「[イベント処理](tutorial-game-flow-management.md#events-handling)」を参照してください。

```cpp
void App::SetWindow(
    CoreWindow^ window
    )
{
    // Codes added to modify the original DirectX template project
    window->PointerCursor = ref new CoreCursor(CoreCursorType::Arrow, 0);

    PointerVisualizationSettings^ visualizationSettings = PointerVisualizationSettings::GetForCurrentView();
    visualizationSettings->IsContactFeedbackEnabled = false;
    visualizationSettings->IsBarrelButtonFeedbackEnabled = false;
    // --end of codes added
    
    m_deviceResources->SetWindow(window);

    window->Activated +=
        ref new TypedEventHandler<CoreWindow^, WindowActivatedEventArgs^>(this, &App::OnWindowActivationChanged);

    window->SizeChanged +=
        ref new TypedEventHandler<CoreWindow^, WindowSizeChangedEventArgs^>(this, &App::OnWindowSizeChanged);

    window->VisibilityChanged +=
        ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &App::OnVisibilityChanged);
        
    window->Closed +=
        ref new TypedEventHandler<CoreWindow^, CoreWindowEventArgs^>(this, &App::OnWindowClosed);

    DisplayInformation^ currentDisplayInformation = DisplayInformation::GetForCurrentView();

    currentDisplayInformation->DpiChanged +=
        ref new TypedEventHandler<DisplayInformation^, Platform::Object^>(this, &App::OnDpiChanged);

    currentDisplayInformation->OrientationChanged +=
        ref new TypedEventHandler<DisplayInformation^, Object^>(this, &App::OnOrientationChanged);
    
    // Codes added to modify the original DirectX template project
    currentDisplayInformation->StereoEnabledChanged +=
        ref new TypedEventHandler<DisplayInformation^, Platform::Object^>(this, &App::OnStereoEnabledChanged);
    // --end of codes added
    
    DisplayInformation::DisplayContentsInvalidated +=
        ref new TypedEventHandler<DisplayInformation^, Platform::Object^>(this, &App::OnDisplayContentsInvalidated);
}
```

## <a name="load-method-of-the-view-provider"></a>ビュー プロバイダーの Load メソッド

メイン ウィンドウが設定された後、アプリ シングルトンは [__Load__](https://msdn.microsoft.com/library/windows/apps/hh700501) を呼び出します。 このメソッドで一連の非同期タスクを使って、ゲーム オブジェクトを作成し、グラフィックス リソースを読み込み、ゲームのステート マシンを初期化します。 ゲームのデータまたはアセットを事前に取得するには、**SetWindow** や **Initialize** よりも、このメソッドが適しています。 

Windows では、非同期タスク パターンを使用して、ゲームが入力の処理を開始するまでにかけることができる時間に制限が設けられているため、ゲームが入力の処理を開始できるように、__Load__ メソッドは迅速に完了するように設計する必要があります。 読み込みに時間がかかる場合やリソースが多い場合は、進行状況バーを用意して定期的に更新するようにします。 開始時の状態やグローバルな値の設定など、ゲームを開始する前に必要な準備を行う場合にも、このメソッドを使用します。

非同期プログラミングとタスクの並列処理の概念に慣れていない場合は、「[C++ での非同期プログラミング](https://docs.microsoft.com/windows/uwp/threading-async/asynchronous-programming-in-cpp-universal-windows-platform-apps)」を参照してください。

### <a name="appload-method"></a>App::Load メソッド

読み込みタスクが含まれる __GameMain__ クラスを作成します。

```cpp
void App::Load(
    Platform::String^ entryPoint
    )
{
        if (!m_main)
    {
        m_main = std::unique_ptr<GameMain>(new GameMain(m_deviceResources));
    }
}
````

### <a name="gamemain-constructor"></a>GameMain コンストラクター

* ゲーム レンダラーを作成して初期化します。 詳細については、「[レンダリング フレームワーク I: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)」を参照してください。
* Simple3Dgame オブジェクトを作成して初期化します。 詳細については、「[メイン ゲーム オブジェクトの定義](tutorial--defining-the-main-game-loop.md)」を参照してください。    
* ゲームの UI コントロール オブジェクトを作成し、リソース ファイルの読み込み時に進行状況バーを表示するゲーム情報オーバーレイを表示します。 詳細については、「[ユーザー インターフェイスの追加](tutorial--adding-a-user-interface.md)」を参照してください。
* コントローラー (タッチ、マウス、または Xbox ワイヤレス コントローラー) からの入力を読み取ることができるようにコントローラーを作成します。 詳細については、「[コントロールの追加](tutorial--adding-controls.md)」を参照してください。
* コントローラーを初期化したら、移動とカメラのそれぞれのタッチ コントロール用に、画面の左下と右下の 2 つの四角形の領域を定義しています。 **SetMoveRect** を呼び出して定義される左下の四角形は、カメラを前後左右に動かすための仮想のコントロール パッドとして使われ、 **SetFireRect** メソッドで定義される右下の四角形は、弾を撃つための仮想のボタンとして使われます。
* __create_task__ と __create_task::then__ を使用して、リソースの読み込みを 2 つの独立したステージに分割します。 Direct3D 11 デバイス コンテキストへのアクセスは、そのデバイス コンテキストが作成されたスレッドに制限されている一方で、オブジェクト作成のための Direct3D 11 デバイスへのアクセスにはスレッドの制限がないため、**CreateGameDeviceResourcesAsync** タスクは、元のスレッドで実行される完了タスク (*FinalizeCreateGameDeviceResources*) とは別のスレッドで実行されます。 **LoadLevelAsync** と **FinalizeLoadLevel** を使うレベル リソースの読み込みにも同様のパターンを使います。

```cpp
GameMain::GameMain(const std::shared_ptr<DX::DeviceResources>& deviceResources) :
    m_deviceResources(deviceResources),
    m_windowClosed(false),
    m_haveFocus(false),
    m_gameInfoOverlayCommand(GameInfoOverlayCommand::None),
    m_visible(true),
    m_loadingCount(0),
    m_updateState(UpdateEngineState::WaitingForResources)
{
    m_deviceResources->RegisterDeviceNotify(this);

    m_renderer = ref new GameRenderer(m_deviceResources);
    m_game = ref new Simple3DGame();

    m_uiControl = m_renderer->GameUIControl();

    m_controller = ref new MoveLookController(CoreWindow::GetForCurrentThread());

    auto bounds = m_deviceResources->GetLogicalSize();

    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(bounds.Width - GameConstants::TouchRectangleSize, bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(bounds.Width, bounds.Height)
        );

    SetGameInfoOverlay(GameInfoOverlayState::Loading);
    m_uiControl->SetAction(GameInfoOverlayCommand::None);
    m_uiControl->ShowGameInfoOverlay();

    create_task([this]()
    {
        // Asynchronously initialize the game class and load the renderer device resources.
        // By doing all this asynchronously, the game gets to its main loop more quickly
        // and in parallel all the necessary resources are loaded on other threads.
        m_game->Initialize(m_controller, m_renderer);

        return m_renderer->CreateGameDeviceResourcesAsync(m_game);

    }).then([this]()
    {
        // The finalize code needs to run in the same thread context
        // as the m_renderer object was created because the D3D device context
        // can ONLY be accessed on a single thread.
        m_renderer->FinalizeCreateGameDeviceResources();

        InitializeGameState();

        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // In the middle of a game so spin up the async task to load the level.
            return m_game->LoadLevelAsync().then([this]()
            {
                // The m_game object may need to deal with D3D device context work so
                // again the finalize code needs to run in the same thread
                // context as the m_renderer object was created because the D3D
                // device context can ONLY be accessed on a single thread.
                m_game->FinalizeLoadLevel();
                m_game->SetCurrentLevelToSavedState();
                m_updateState = UpdateEngineState::ResourcesLoaded;

            }, task_continuation_context::use_current());
        }
        else
        {
            // The game is not in the middle of a level so there aren't any level
            // resources to load.  Creating a no-op task so that in both cases
            // the same continuation logic is used.
            return create_task([]()
            {
            });
        }
    }, task_continuation_context::use_current()).then([this]()
    {
        // Since Game loading is an async task, the app visual state
        // may be too small or not have focus.  Put the state machine
        // into the correct state to reflect these cases.

        if (m_deviceResources->GetLogicalSize().Width < GameConstants::MinPlayableWidth)
        {
            m_updateStateNext = m_updateState;
            m_updateState = UpdateEngineState::TooSmall;
            m_controller->Active(false);
            m_uiControl->HideGameInfoOverlay();
            m_uiControl->ShowTooSmall();
            m_renderNeeded = true;
        }
        else if (!m_haveFocus)
        {
            m_updateStateNext = m_updateState;
            m_updateState = UpdateEngineState::Deactivated;
            m_controller->Active(false);
            m_uiControl->SetAction(GameInfoOverlayCommand::None);
            m_renderNeeded = true;
        }
    }, task_continuation_context::use_current());
}
```

## <a name="run-method-of-the-view-provider"></a>ビュー プロバイダーの Run メソッド

前述の 3 つメソッド __Initialize__、__SetWindow__、__Load__ によって、ステージを設定しました。 次に、ゲームは **Run** メソッドに進んで、楽しいゲームを開始できます。 ゲームの状態間の移行に使われるイベントのディスパッチと処理が行われます。 ゲーム ループの循環に応じてグラフィックスが更新されます。

### <a name="apprun"></a>App::Run

プレイヤーがゲーム ウィンドウを閉じると終了する __while__ ループを開始します。

サンプル コードは、ゲーム エンジンのステート マシンの次の 2 つのいずれかの状態に移行します。
    * __Deactivated__: ゲーム ウィンドウが非アクティブ化される (フォーカスを失う) か、スナップされます。 この場合、ゲームではイベントの処理を中断し、ウィンドウがフォーカスまたはスナップを解除されるまで待機します。
    * __TooSmall__: ゲームが自身の状態を更新し、表示するグラフィックスをレンダリングします。

ゲームにフォーカスがある場合、メッセージ キューに到達する各イベントを処理する必要があるため、[**CoreWindowDispatch.ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を **ProcessAllIfPresent** オプションで呼び出す必要があります。 他のオプションでは、メッセージ イベントの処理に遅延が発生することがあり、この場合、ゲームが応答しなくなったように見えるか、タッチ動作の反応が遅くて "敏感" でないように見える可能性があります。

ゲームが表示されていないときや中断またはスナップ状態のときにリソースを循環させてどこにも到達しないメッセージをディスパッチすることは回避する必要があるため、 ゲームでは **ProcessOneAndAllPending** を使う必要があります。この結果、イベントが取得されるまではブロックが行われ、その後、そのイベントと、そのイベントの処理中にプロセス キューに到達した他のイベントが処理されます。 その後、キューの処理が終了すると、[**ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) に即座に戻ります。

```cpp
void App::Run()
{
    m_main->Run();
}

void GameMain::Run()
{
    while (!m_windowClosed)
    {
        if (m_visible)
        {
            switch (m_updateState)
            {
            case UpdateEngineState::Deactivated:
            case UpdateEngineState::TooSmall:
                if (m_updateStateNext == UpdateEngineState::WaitingForResources)
                {
                    WaitingForResourceLoading();
                    m_renderNeeded = true;
                }
                else if (m_updateStateNext == UpdateEngineState::ResourcesLoaded)
                {
                    // In the device lost case, we transition to the final waiting state
                    // and make sure the display is updated.
                    switch (m_pressResult)
                    {
                    case PressResultState::LoadGame:
                        SetGameInfoOverlay(GameInfoOverlayState::GameStats);
                        break;

                    case PressResultState::PlayLevel:
                        SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
                        break;

                    case PressResultState::ContinueLevel:
                        SetGameInfoOverlay(GameInfoOverlayState::Pause);
                        break;
                    }
                    m_updateStateNext = UpdateEngineState::WaitingForPress;
                    m_uiControl->ShowGameInfoOverlay();
                    m_renderNeeded = true;
                }

                if (!m_renderNeeded)
                {
                    // The App is not currently the active window and not in a transient state so just wait for events.
                    CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
                    break;
                }
                // otherwise fall through and do normal processing to get the rendering handled.
            default:
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                Update();
                m_renderer->Render();
                m_deviceResources->Present();
                m_renderNeeded = false;
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
    m_game->OnSuspending();  // exiting due to window close.  Make sure to save state.
}
```

## <a name="uninitialize-method-of-the-view-provider"></a>ビュー プロバイダーの Uninitialize メソッド

ユーザー最終的にゲーム セッションを終了したら、クリーンアップする必要があります。 **Uninitialize** はまさにそのような用途に使います。

Windows 10 では、アプリ ウィンドウを閉じても強制アプリのプロセスが代わりに、アプリ シングルトンの状態をメモリに書き込まれます。 システムでこのメモリの再利用が必要になった際に、リソースの特別なクリーンアップなどの特別な処理が必要な場合は、そのクリーンアップ用のコードをこのメソッドに入れてください。

### <a name="app-uninitialize"></a>App:: Uninitialize

```cpp
void App::Uninitialize()
{
}
```

## <a name="tips"></a>ヒント

ゲームを開発するときは、これらのメソッドの近くにスタートアップ コードを設計してください。 各メソッドの基本的な推奨事項を次に示します。

-   メイン クラスの割り当てと基本的なイベント ハンドラーの接続には **Initialize** を使います。
-   メイン ウィンドウの作成とウィンドウ固有のイベントの接続には **SetWindow** を使います。
-   その他のセットアップの処理と非同期のオブジェクト作成やリソース読み込みには **Load** を使います。 一時ファイルまたは一時データを作成する必要がある場合は (手続き的に生成されるアセットなど)、その処理もこのメソッドで行います。


## <a name="next-steps"></a>次の手順

ここでは、DirectX を使った UWP ゲームの基本的な構造について説明します。 このチュートリアルの他の部分で参照するので、ここで説明した 5 つのメソッドを覚えておいてください。 次に、「[ゲームのフロー管理](tutorial-game-flow-management.md)」で、ゲームを続行するために、ゲームの状態とイベント処理を管理する方法について詳しく説明します。



