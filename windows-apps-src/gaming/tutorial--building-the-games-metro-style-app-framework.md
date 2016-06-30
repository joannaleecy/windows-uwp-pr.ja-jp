---
author: mtoepke
title: "ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義"
description: "DirectX によるユニバーサル Windows プラットフォーム (UWP) ゲームのコーディングでは、まず、ゲーム オブジェクトと Windows との対話を可能にするフレームワークを構築します。"
ms.assetid: 7beac1eb-ba3d-e15c-44a1-da2f5a79bb3b
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 2ebc7bca06454f78ab375058e49f012cacb00cc8

---

#  ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

DirectX によるユニバーサル Windows プラットフォーム (UWP) ゲームのコーディングでは、まず、ゲーム オブジェクトと Windows との対話を可能にするフレームワークを構築します。 これには、中断/再開イベントの処理、ウィンドウのフォーカス、スナップなどの Windows ランタイムのプロパティや、ユーザー インターフェイスのイベント、対話式操作、トランザクションが含まれます。 ここでは、サンプル ゲームを構成する方法と、サンプル ゲームでプレーヤーとシステムの対話用の上位レベルのステート マシンを定義する方法について説明します。

## 目標


-   UWP DirectX ゲーム用のフレームワークをセットアップし、ゲーム全体のフローを定義するステート マシンを実装する。

## ビュー プロバイダーの初期化と開始


どの UWP DirectX ゲームでも、アプリ シングルトン (実行中のアプリのインスタンスを定義する Windows ランタイム オブジェクト) が必要なグラフィックス リソースにアクセスできるようにするビュー プロバイダーを取得する必要があります。 Windows ランタイムを通じて、アプリはグラフィックス インターフェイスに直接接続できますが、必要なリソースとその処理方法を指定する必要があります。

「[ゲーム プロジェクトの設定](tutorial--setting-up-the-games-infrastructure.md)」で説明したとおり、Microsoft Visual Studio 2015 には、**DirectX 11 アプリ (ユニバーサル Windows)** テンプレートの選択時に使うことができる **Sample3DSceneRenderer.cpp** ファイルに、DirectX 用の基本的なレンダラーの実装が用意されています。

ビュー プロバイダーとレンダラーの概要と作成について詳しくは、「[C++ および DirectX による UWP で DirectX ビューを表示するための設定方法](https://msdn.microsoft.com/library/windows/apps/hh465077)」をご覧ください。

言うまでもなく、アプリ シングルトンが呼び出す 5 つのメソッドの実装を用意する必要があります。

-   [**Initialize**](https://msdn.microsoft.com/library/windows/apps/hh700495)
-   [**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509)
-   [**Load**](https://msdn.microsoft.com/library/windows/apps/hh700501)
-   [**Run**](https://msdn.microsoft.com/library/windows/apps/hh700505)
-   [**Uninitialize**](https://msdn.microsoft.com/library/windows/apps/hh700523)

DirectX11 アプリ (ユニバーサル Windows) テンプレートでは、これら 5 つのメソッドは、[App.h](#code_sample) の **App** オブジェクトに定義されています。 これらのメソッドがこのゲームに実装されている方法を見てみましょう。

ビュー プロバイダーの Initialize メソッド

```cpp
void App::Initialize(
    _In_ CoreApplicationView^ applicationView
    )
{
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);

    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);

    m_controller = ref new MoveLookController();
    m_renderer = ref new GameRenderer();
    m_game = ref new Simple3DGame();
}
```

アプリ シングルトンは、最初に **Initialize** を呼び出します。 このため、メイン ウィンドウのアクティブ化の処理や、ゲームが突然の中断 (とその後に行われる場合がある再開) イベントを処理できることの確認など、UWP ゲームの最も基本的な動作をこのメソッドで処理することが非常に重要です。

ゲーム アプリは、初期化される際、コントローラー専用のメモリを割り当てて、プレーヤーが入力を開始できるようにします。 さらに、ゲームのレンダラーとステート マシンの新しい初期化されていないインスタンスも作成します。 これについては、「[メイン ゲーム オブジェクトの定義](tutorial--defining-the-main-game-loop.md)」で詳しく説明します。

この時点では、このゲーム アプリには、中断 (または再開) メッセージを処理する機能があり、コントローラー、レンダラー、ゲーム自体用のメモリが割り当てられています。 ただし、操作するウィンドウはなく、ゲームは初期化されていません。 必要なことが、あといくつか残っています。

ビュー プロバイダーの SetWindow メソッド

```cpp
void App::SetWindow(
    _In_ CoreWindow^ window
    )
{
    window->PointerCursor = ref new CoreCursor(CoreCursorType::Arrow, 0);

    window->SizeChanged +=
        ref new TypedEventHandler<CoreWindow^, WindowSizeChangedEventArgs^>(this, &App::OnWindowSizeChanged);

    window->Closed +=
        ref new TypedEventHandler<CoreWindow^, CoreWindowEventArgs^>(this, &App::OnWindowClosed);

    window->VisibilityChanged +=
        ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &App::OnVisibilityChanged);

    DisplayProperties::LogicalDpiChanged +=
        ref new DisplayPropertiesEventHandler(this, &App::OnLogicalDpiChanged);

    m_controller->Initialize(window);

    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, window->Bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(window->Bounds.Width - GameConstants::TouchRectangleSize, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(window->Bounds.Width, window->Bounds.Height)
        );

    m_renderer->Initialize(window, DisplayProperties::LogicalDpi);
    SetGameInfoOverlay(GameInfoOverlayState::Loading);
    ShowGameInfoOverlay();
}
```

ここでは、アプリ シングルトンは、[**SetWindow**](https://msdn.microsoft.com/library/windows/apps/hh700509) の実装を呼び出して、ゲームのメイン ウィンドウを表す [**CoreWindow**](https://msdn.microsoft.com/library/windows/apps/br208225) オブジェクトを提供し、そのリソースとイベントをゲームで使用できるようにします。 操作するウィンドウがあるため、この時点で、ゲームはユーザー インターフェイスの基本的なコンポーネントとイベントの追加を開始できます。具体的には、ポインター (マウスとタッチの両方のコントロールで使用) と、ウィンドウのサイズ変更用、ウィンドウを閉じる操作用、DPI の変更用 (表示デバイスが変更された場合) の基本的なイベントを追加します。

ゲーム アプリではさらに、対話するウィンドウがあるため、コントローラーも初期化し、ゲーム オブジェクト自体も初期化します。 ゲーム アプリでは、コントローラー (タッチ、マウス、または Xbox 360 コントローラー) からの入力を読み取ることができます。

コントローラーを初期化したら、移動とカメラのそれぞれのタッチ コントロール用に、画面の左下と右下の 2 つの四角形の領域を定義します。 **SetMoveRect** を呼び出して定義される左下の四角形は、カメラを前後左右に動かすための仮想のコントロール パッドとして使われ、 **SetFireRect** メソッドで定義される右下の四角形は、弾を撃つための仮想のボタンとして使われます。

すべてがまとまり始めました。

ビュー プロバイダーの Load メソッド

```cpp
void App::Load(
    Platform::String^ entryPoint
    )
{
    task<void>([this]()
    {
        m_game->Initialize(m_controller, m_renderer);

        return m_renderer->CreateGameDeviceResourcesAsync(m_game);

    }).then([this]()
    {
        // The finalize code needs to run in the same thread context
        // in which the m_renderer object was created because the D3D device context
        // can be accessed only on a single thread.
        m_renderer->FinalizeCreateGameDeviceResources();

        InitializeGameState();

        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // In the middle of a game, so spin up the async task to load the level.
            create_task([this]()
            {
                return m_game->LoadLevelAsync();

            }).then([this]()
            {
                // The m_game object may need to deal with D3D device context work, so
                // the finalizer code needs to run in the same thread
                // context as the m_renderer object was created because the D3D 
                // device context can  be accessed only on a single thread.
                m_game->FinalizeLoadLevel();
                m_updateState = UpdateEngineState::ResourcesLoaded;

            }, task_continuation_context::use_current());
        }
    }, task_continuation_context::use_current());
}
```

メイン ウィンドウが設定された後、アプリ シングルトンは **Load** を呼び出します。 このサンプルでは、このメソッドで一連の非同期タスク (構文は[並列パターン ライブラリ](https://msdn.microsoft.com/library/windows/apps/dd492418.aspx)で定義されています) を使って、ゲーム オブジェクトを作成し、グラフィックス リソースを読み込み、ゲームのステート マシンを初期化します。 非同期タスク パターンを使うことで、Load メソッドがすばやく完了し、アプリで入力の処理を開始できます。 このメソッドでは、さらに、リソース ファイルの読み込み状況を示す進行状況バーを表示します。

リソースの読み込みは 2 段階に分けて処理します。Direct3D 11 のデバイス コンテキストへのアクセスはそのデバイス コンテキストが作成されたスレッドに制限されるのに対し、オブジェクト作成用の Direct3D 11 のデバイスへのアクセスはスレッドが制限されないからです。 **CreateGameDeviceResourcesAsync** タスクは、元のスレッドで実行される完了タスク (*FinalizeCreateGameDeviceResources*) とは別のスレッドで実行されます。 **LoadLevelAsync** と **FinalizeLoadLevel** を使うレベル リソースの読み込みにも同様のパターンを使います。

ゲームのオブジェクトを作成し、グラフィックス リソースを読み込んだら、ゲームのステート マシンを開始時の状態に初期化します (たとえば、初期状態の弾薬の数、レベル、オブジェクトの位置などを設定します)。 ゲームの状態を確認し、プレーヤーがゲームを再開した状態のときは、現在のレベル (プレーヤーがゲームを中断した時点のプレーヤーのレベル) を読み込みます。

開始時の状態やグローバルな値の設定など、ゲームを開始する前に必要な準備があれば、**Load** メソッドで行います。 ゲームのデータまたはアセットを事前に取得するには、**SetWindow** や **Initialize** よりも、このメソッドが適しています。 ゲームでは、ゲームを起動してから入力の処理を開始するまでの時間に制限があるため、すべての読み込みに非同期タスクを使います。 リソースが多いなど、読み込みに時間がかかる場合は、進行状況バーを用意して定期的に更新するようにします。

ゲームを開発するときは、これらのメソッドの近くにスタートアップ コードを設計してください。 各メソッドの基本的な推奨事項を次に示します。

-   メイン クラスの割り当てと基本的なイベント ハンドラーの接続には **Initialize** を使います。
-   メイン ウィンドウの作成とウィンドウ固有のイベントの接続には **SetWindow** を使います。
-   その他のセットアップの処理と非同期のオブジェクト作成やリソース読み込みには **Load** を使います。 一時ファイルまたは一時データを作成する必要がある場合は (手続き的に生成されるアセットなど)、その処理もこのメソッドで行います。

サンプル ゲームでは、このようにゲームのステート マシンのインスタンスを作成し、開始時の構成に設定します。 また、すべてのシステム イベントと入力イベントを処理し、 コンテンツを表示するウィンドウを提供します。 これで、ゲーム プレイ コードを実行する準備ができました。

ビュー プロバイダーの Run メソッド

```cpp
void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_visible)
        {
            switch (m_updateState)
            {
            case UpdateEngineState::Deactivated:
            case UpdateEngineState::Snapped:
                if (!m_renderNeeded)
                {
                    // The app is not currently the active window, so just wait for events.
                    CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
                    break;
                }
                // Otherwise, fall through and do normal processing to get the rendering handled.
            default:
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                Update();
                m_renderer->Render();
                m_renderNeeded = false;
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
    m_game->OnSuspending();  // Exiting due to window close.  Make sure to save the state.
}
```

これが、ゲーム アプリの実行部分です。 ゲーム アプリは、3 つのメソッドを実行してステージを設定した後、**Run** メソッドを実行します。いよいよお楽しみの始まりです。

このゲーム サンプルでは、プレーヤーがゲーム ウィンドウを閉じると終了する while ループを開始します。 サンプル コードは、ゲーム エンジンのステート マシンの次の 2 つのいずれかの状態に移行します。

-   ゲーム ウィンドウが非アクティブ化される (フォーカスを失う) か、スナップされます。 この場合、ゲームではイベントの処理を中断し、ウィンドウがフォーカスまたはスナップを解除されるまで待機します。
-   または、ゲームが自身の状態を更新し、表示するグラフィックスをレンダリングします。

ゲームにフォーカスがある場合、メッセージ キューに到達する各イベントを処理する必要があるため、[**CoreWindowDispatch.ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208215) を **ProcessAllIfPresent** オプションで呼び出す必要があります。 他のオプションでは、メッセージ イベントの処理に遅延が発生することがあり、この場合、ゲームが応答しなくなったように見えるか、タッチ動作の反応が遅くて "敏感" でないように見えます。

もちろん、アプリが表示されていないときや中断またはスナップ状態のときにリソースを循環させてどこにも到達しないメッセージをディスパッチすることは回避する必要があるため、 ゲームでは **ProcessOneAndAllPending** を使う必要があります。この結果、イベントが取得されるまではブロックが行われ、その後、そのイベントと、そのイベントの処理中にプロセス キューに到達した他のイベントが処理されます。 その後、キューの処理が終了すると、[
              **ProcessEvents**
            ](https://msdn.microsoft.com/library/windows/apps/br208215) に即座に戻ります。

ゲームの実行は続いています。 ゲームの状態間の移行に使われるイベントのディスパッチと処理が行われています。 ゲーム ループの循環に応じてグラフィックスが更新されています。 プレイヤーがずっと楽しんでくれることを願っています。 でも、お楽しみもいつかは終わります。

そして、クリーンアップが必要になります。 **Uninitialize** はまさにそのような用途に使います。

ビュー プロバイダーの Uninitialize メソッド

```cpp
void App::Uninitialize()
{
}
```

このゲーム サンプルでは、ゲームの終了後、ゲームのアプリ シングルトンがすべてのクリーンアップを行います。 Windows 10 では、アプリ ウィンドウを閉じてもアプリのプロセスは強制終了されず、代わりに、アプリ シングルトンの状態がメモリに書き込まれます。 システムでこのメモリの再利用が必要になった際に、リソースの特別なクリーンアップなどの特別な処理が必要な場合は、そのクリーンアップ用のコードをこのメソッドに入れてください。

これら 5 つのメソッドについては、このチュートリアルで再確認するため、忘れないでおいてください。 次に、ゲーム エンジン全体の構造と、それを定義するステート マシンを見てみましょう。

## ゲーム エンジンの状態の初期化


ユーザーは UWP ゲーム アプリを中断状態からいつでも再開できるため、アプリが置かれる可能性のある状態は任意に設定できます。

このゲーム サンプルは、開始時に、次の 3 つのいずれかの状態になります。

-   ゲーム ループが実行中で、いずれかのレベル中の状態。
-   ゲームがちょうど完了したため、ゲーム ループが実行されていない状態。 (ハイ スコアが設定されます。)
-   ゲームが開始されていないか、ゲームが 2 つのレベルの中間にある状態。 (ハイ スコアは 0)。

もちろん、作成するゲームでは、状態の数を増減できます。 繰り返しますが、UWP ゲームはいつでも終了できるため、プレーヤーは再開時に、ゲームをまったく停止していなかったかのようにゲームが動作すると期待することを常に覚えておいてください。

ゲーム サンプルでは、コード フローは次のようになります。

```cpp
void App::InitializeGameState()
{
    //
    // Set up the initial state machine for handling game playing state.
    //
    if (m_game->GameActive() && m_game->LevelActive())
    {
        m_updateState = UpdateEngineState::WaitingForResources;
        // ...

    }
    else if (!m_game->GameActive() && (m_game->HighScore().totalHits > 0))
    {
        m_updateState = UpdateEngineState::WaitingForPress;
        // ...
    }
    else
    {
        m_updateState = UpdateEngineState::WaitingForResources;
        // ...
    }
    SetAction(GameInfoOverlayCommand::PleaseWait);
    ShowGameInfoOverlay();
}
```

初期化では、アプリをコールド スタートするというよりは、終了されたアプリを再起動します。 サンプル ゲームでは状態が常に保存されるので、アプリが常に実行中のように見えます。 中断状態では、ゲーム プレイは中断されますが、ゲームのリソースはメモリに残されます。 同様に、再開イベントは、サンプル ゲームが前回中断または終了された点から再開されることを示しています。 サンプル ゲームが終了後に再起動されると、通常どおり開始され、その後、最後の既知の状態が判断されるため、プレーヤーはゲームの続きを即座に続行できます。

このフローチャートは、ゲーム サンプルの初期化プロセスの初期状態と移行を示しています。

![メイン ループの開始前にゲームの初期化と準備を行うプロセス](images/simple3dgame-appstartup.png)

状態に応じて、異なるオプションがプレーヤーに表示されます。 ゲームは、2 つのレベルの中間から再開された場合、一時停止しているように見え、オーバーレイで続行オプションが表示されます。 また、完了状態から再開された場合は、ハイ スコアと、新しいゲームを開始するオプションが表示されます。 そして、いずれかのレベルが開始される前にゲームが再開された場合は、オーバーレイで開始オプションがユーザーに表示されます。

このゲーム サンプルでは、ゲーム自体のコールド スタート (ゲームが初めて起動されていて、中断イベントがない状態) と、ゲームの中断状態からの再開とを区別していません。 これは、どの UWP アプリにも適切な設計です。

## イベントの処理


サンプル コードでは、特定のイベントに対する多数のハンドラーが **Initialize**、**SetWindow**、**Load** に登録されています。 コード サンプルでは、この登録を、ゲームのしくみやグラフィックスの開発を始めるよりもずっと前に行っているため、これらのイベントが重要であると思っている方もいるでしょう。 その推測は当たっています。 これらのイベントは UWP アプリの適切なエクスペリエンスに不可欠であり、また、UWP アプリはいつでもアクティブ化、非アクティブ化、サイズ変更、スナップ、スナップの解除、中断、再開ができるため、ゲームではこれらのイベント自体をできる限り早く登録し、プレーヤーのエクスペリエンスをスムーズで予測可能な状態に保てる方法で、これらのイベントを処理する必要があります。

次の表に、このサンプルのイベント ハンドラーと、ハンドラーが処理するイベントを示します。 これらのイベント ハンドラーの完全なコードは、「[このセクションのサンプル コード一式](#code_sample)」で確認できます。

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">イベント ハンドラー</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left">OnActivated</td>
<td align="left">[<strong>CoreApplicationView::Activated</strong>](https://msdn.microsoft.com/library/windows/apps/br225018) を処理します。 ゲーム アプリがフォアグラウンドに表示されているため、メイン ウィンドウがアクティブ化されます。</td>
</tr>
<tr class="even">
<td align="left">OnLogicalDpiChanged</td>
<td align="left">[<strong>DisplayProperties::LogicalDpiChanged</strong>](https://msdn.microsoft.com/library/windows/apps/br226150) を処理します。 ゲームのメイン ウィンドウの DPI が変更されていて、それに応じてゲーム アプリがそのリソースを調整します。
<div class="alert">
<strong>注</strong>  [<strong>CoreWindow</strong>](https://msdn.microsoft.com/library/windows/desktop/hh404559) 座標の単位は、[Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370987) と同様に、DIP (デバイスに依存しないピクセル数) です。 このため、2D アセットまたはプリミティブを正しく表示するには、Direct2D に DPI の変更を通知する必要があります。
</div>
<div>
 
</div></td>
</tr>
<tr class="odd">
<td align="left">OnResuming</td>
<td align="left">[<strong>CoreApplication::Resuming</strong>](https://msdn.microsoft.com/library/windows/apps/br205859) を処理します。 ゲーム アプリがゲームを中断状態から復元します。</td>
</tr>
<tr class="even">
<td align="left">OnSuspending</td>
<td align="left">[<strong>CoreApplication::Suspending</strong>](https://msdn.microsoft.com/library/windows/apps/br205860) を処理します。 ゲーム アプリがその状態をディスクに保存します。 ストレージへの状態の保存に使用できる時間は 5 秒です。</td>
</tr>
<tr class="odd">
<td align="left">OnVisibilityChanged</td>
<td align="left">[<strong>CoreWindow::VisibilityChanged</strong>](https://msdn.microsoft.com/library/windows/apps/hh701591) を処理します。 ゲーム アプリの表示が切り替わり、表示されるようになったか、別のアプリが表示されたために非表示になったことを示します。</td>
</tr>
<tr class="even">
<td align="left">OnWindowActivationChanged</td>
<td align="left">[<strong>CoreWindow::Activated</strong>](https://msdn.microsoft.com/library/windows/apps/br208255) を処理します。 ゲーム アプリのメイン ウィンドウが非アクティブ化またはアクティブ化されたため、フォーカスを動かしてゲームを一時停止するか、フォーカスを再取得する必要があります。 どちらの場合も、ゲームが一時停止されていることがオーバーレイに表示されます。</td>
</tr>
<tr class="odd">
<td align="left">OnWindowClosed</td>
<td align="left">[<strong>CoreWindow::Closed</strong>](https://msdn.microsoft.com/library/windows/apps/br208261) を処理します。 ゲーム アプリがメイン ウィンドウを閉じ、ゲームを中断します。</td>
</tr>
<tr class="even">
<td align="left">OnWindowSizeChanged</td>
<td align="left">[<strong>CoreWindow::SizeChanged</strong>](https://msdn.microsoft.com/library/windows/apps/br208283) を処理します。 サイズ変更に応じてゲーム アプリがグラフィックス リソースとオーバーレイを再割り当てし、その後、レンダー ターゲットを更新します。</td>
</tr>
</tbody>
</table>

 

これらのイベントは UWP アプリ設計に含まれるため、作成するゲームではこれらのイベントを処理する必要があります。

## ゲーム エンジンの更新


このサンプルでは、**Run** のゲーム ループ内に、プレーヤーが実行できる主な操作すべてを処理する基本的なステート マシンを実装しています。 このステート マシンの最上位レベルは、ゲームの読み込み、特定のレベルのゲーム プレイ、ゲームが (システムあるいはプレーヤーによって) 一時停止された後のレベルの続行を処理します。

このゲーム サンプルには、ゲームの主な状態 (UpdateEngineState) として次の 3 つがあります。

-   **Waiting for resources**。 ゲーム ループが循環していて、リソース (具体的にはグラフィックス リソース) が使用可能になるまで、移行はできません。 リソースを読み込む非同期タスクが完了すると、状態が **ResourcesLoaded** に更新されます。 これは通常、2 つのレベルの中間で発生します。レベルの中間では、新しいリソースをディスクから読み込む必要があるためです。 このゲーム サンプルでは、その時点ではレベルごとに追加のリソースは必要ないため、この動作はシミュレートされます。
-   **Waiting for press**。 ゲーム ループが循環していて、特定のユーザー入力を待機しています。 この入力は、プレーヤーによるゲームの読み込み、レベルの開始、またはレベルの続行の操作です。 サンプル コードでは、これらの下位状態として、PressResultState 列挙値を使っています。
-   **Dynamics**。 ゲーム ループが実行中で、ユーザーがゲームをしています。 ユーザーがゲームをしている間、ゲームでは移行が可能な 3 つの条件、つまり、レベルの設定時間切れ、プレーヤーによるいずれかのレベルの完了、プレーヤーによる全レベルの完了を確認します。

コード構造は次のとおりです。 完全なコードは、「[このセクションのサンプル コード一式](#code_sample)」にあります。

ゲーム エンジンの更新に使われるステート マシンの構造

```cpp
void App::Update()
{
    m_controller->Update();

    switch (m_updateState)
    {
    case UpdateEngineState::WaitingForResources:
        // Waiting for initial load.  Display an update once per 60 updates.
        loadCount++;
        if ((loadCount % 60) == 0)
        {
            m_loadingCount++;
            SetGameInfoOverlay(m_gameInfoOverlayState);
        }
        break;

    case UpdateEngineState::ResourcesLoaded:
        switch (m_pressResult)
        {
        case PressResultState::LoadGame:
            // ...
            break;

        case PressResultState::PlayLevel:
            // ...
            break;

        case PressResultState::ContinueLevel:
            // ...
            break;
        }
        // ...
        break;

    case UpdateEngineState::WaitingForPress:
        if (m_controller->IsPressComplete() || m_pressComplete)
        {
            m_pressComplete = false;

            switch (m_pressResult)
            {
            case PressResultState::LoadGame:
                // ...
                break;

            case PressResultState::PlayLevel:
                // ...
                break;

            case PressResultState::ContinueLevel:
                // ...
                break;
            }
        }
        break;

    case UpdateEngineState::Dynamics:
        if (m_controller->IsPauseRequested() || m_pauseRequested)
        {
            // ...
        }
        else 
        {
            GameState runState = m_game->RunGame();
            switch (runState)
            {
            case GameState::TimeExpired:
                // ...
                break;

            case GameState::LevelComplete:
                // ...
                break;

            case GameState::GameComplete:
                // ...
                break;
            }
        }

        if (m_updateState == UpdateEngineState::WaitingForPress)
        {
            // transitioning state, so enable waiting for the press event
            m_controller->WaitForPress(m_game->GameInfoOverlayUpperLeft(), m_game->GameInfoOverlayLowerRight());
        }
        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // Transitioning state, so shut down the input controller until resources are loaded
            m_controller->Active(false);
        }

        break;
    }
}
```

図で表すと、ゲームのメイン ステート マシンは次のようになります。

![ゲームのメイン ステート マシン](images/simple3dgame-mainstatemachine.png)

ゲームのロジック自体については、「[メイン ゲーム オブジェクトの定義](tutorial--defining-the-main-game-loop.md)」でより詳しく説明します。 今のところは、ゲームはステート マシンである、という重要なポイントを覚えておいてください。 それぞれの状態に、それを定義する非常に具体的な条件が必要であり、ある状態から別の状態への移行は、ユーザー入力またはシステムによる個々の操作 (グラフィックス リソースの読み込みなど) に基づいて行われる必要があります。 ゲームの計画をするときは、ここで使ったような図を作成し、ユーザーまたはシステムが上位レベルで実行する可能性のあるすべての操作に対処していることを確認してください。 ゲームは非常に複雑な場合があり、ステート マシンは、この複雑さを視覚化して非常に扱いやすくする強力なツールです。

もちろん、今までに見てきたように、ステート マシンの内部にステート マシンがあります。 コントローラーには、プレーヤーが実行可能でコントローラーで許容されるすべての入力を処理するステート マシンがあります。 上の図では、押し操作はユーザー入力の一種です。 このステート マシンは、どのようなユーザー入力かは認識しません。それより上位のレベルで処理されるからです。コントローラーのステート マシンは、移動とシューティングの動作に影響をあたえる移行と、それに関連するレンダリング更新を処理すると想定されます。 入力状態の管理については、「[コントロールの追加](tutorial--adding-controls.md)」で説明します。

## ユーザー インターフェイスの更新


プレーヤーには、システムの状態を継続的に通知して、ゲームのルールに応じて上位レベルの状態を変更できるようにする必要があります。 このゲーム サンプルも含めてほとんどのゲームでは、これは、ゲームの状態や、スコア、弾薬、残りライフ数などのゲームに固有の他の情報の表現が含まれているヘッドアップ ディスプレイで行われます。 これをオーバーレイと呼びます。メインのグラフィックス パイプラインとは別にレンダリングされ、3D プロジェクションの上に配置されるためです。 このサンプル ゲームでは、このオーバーレイを Direct2D API を使って作成しています。 このオーバーレイは、XAML を使って作成することもできます。これについては、「[ゲーム サンプルの紹介](tutorial-resources.md)」で説明します。

ユーザー インターフェイスには次の 2 つのコンポーネントがあります。

-   スコアとゲーム プレイの現在の状態に関する情報が含まれているヘッドアップ ディスプレイ。
-   一時停止ビットマップ。これは、ゲームの一時停止/中断状態中にテキストがオーバーレイされる黒の四角形です。 これがゲーム オーバーレイです。 これについては、「[ユーザー インターフェイスの追加](tutorial--adding-a-user-interface.md)」で詳しく説明します。

当然のことながら、オーバーレイにもステート マシンがあります。 オーバーレイは、レベル開始またはゲーム オーバーのメッセージを表示できます。 これは、ゲームが一時停止または中断されたときに、プレーヤーに表示する必要があるゲームの状態に関する情報を出力するキャンバスのように機能します。

このゲーム サンプルでオーバーレイのステート マシンを構成する方法は次のとおりです。

```cpp
void App::SetGameInfoOverlay(GameInfoOverlayState state)
{
    m_gameInfoOverlayState = state;
    switch (state)
    {

    case GameInfoOverlayState::Loading:
        m_renderer->InfoOverlay()->SetGameLoading(m_loadingCount);
        break;

    case GameInfoOverlayState::GameStats:
        // ...
        break;

    case GameInfoOverlayState::LevelStart:
        // ...
        break;

    case GameInfoOverlayState::GameOverCompleted:
        // ...
        break;

    case GameInfoOverlayState::GameOverExpired:
        // ...
        break;

    case GameInfoOverlayState::Pause:
        // ...
        break;
    }
}
```

ゲーム自体の状態に応じて、6 つの状態画面がオーバーレイに表示されます。ゲームの開始時のリソース読み込み画面、ゲーム プレイ画面、レベル開始メッセージ画面、時間切れにならずに全レベルが完了した場合のゲーム オーバー画面、時間切れの場合のゲーム オーバー画面、一時停止メニュー画面です。

ユーザー インターフェイスをゲームのグラフィックス パイプラインから分離すると、ゲームのグラフィックス レンダリング エンジンとは別に操作でき、ゲームのコードの複雑さが大幅に軽減されます。

## 次のステップ


ここでは、ゲーム サンプルの基本構造について説明し、DirectX を使って UWP ゲーム アプリを開発する際に役立つモデルを紹介しました。 もちろん、それだけではありませんが、 ここでは、ゲームのフレームワークについて簡単に説明しました。 次は、ゲームとそのしくみ、そして、ゲームのコア オブジェクトとしてそのしくみを実装する方法を詳しく見てみましょう。 これについては、「[メイン ゲーム オブジェクトの定義](tutorial--defining-the-main-game-loop.md)」で説明します。

また、サンプル ゲームのグラフィックス エンジンについても詳しく確認する段階になりました。 これについては、「[レンダリング パイプラインのアセンブル](tutorial--assembling-the-rendering-pipeline.md)」で説明します。

## このセクションのサンプル コード一式


App.h

```cpp
///// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

#include "Simple3DGame.h"

enum class UpdateEngineState
{
    WaitingForResources,
    ResourcesLoaded,
    WaitingForPress,
    Dynamics,
    Snapped,
    Suspended,
    Deactivated,
};

enum class PressResultState
{
    LoadGame,
    PlayLevel,
    ContinueLevel,
};

enum class GameInfoOverlayState
{
    Loading,
    GameStats,
    GameOverExpired,
    GameOverCompleted,
    LevelStart,
    Pause,
};

ref class App : public Windows::ApplicationModel::Core::IFrameworkView
{
internal:
    App();

public:
    // IFrameworkView Methods
    virtual void Initialize(_In_ Windows::ApplicationModel::Core::CoreApplicationView^ applicationView);
    virtual void SetWindow(_In_ Windows::UI::Core::CoreWindow^ window);
    virtual void Load(_In_ Platform::String^ entryPoint);
    virtual void Run();
    virtual void Uninitialize();

private:
    void InitializeGameState();

    // Event Handlers
    void OnSuspending(
        _In_ Platform::Object^ sender,
        _In_ Windows::ApplicationModel::SuspendingEventArgs^ args
        );

    void OnResuming(
        _In_ Platform::Object^ sender,
        _In_ Platform::Object^ args
        );

    void UpdateViewState();

    void OnWindowActivationChanged(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::WindowActivatedEventArgs^ args
        );

    void OnWindowSizeChanged(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::WindowSizeChangedEventArgs^ args
        );

    void OnWindowClosed(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::CoreWindowEventArgs^ args
        );

    void OnLogicalDpiChanged(
        _In_ Platform::Object^ sender
        );

    void OnActivated(
        _In_ Windows::ApplicationModel::Core::CoreApplicationView^ applicationView,
        _In_ Windows::ApplicationModel::Activation::IActivatedEventArgs^ args
        );

    void OnVisibilityChanged(
        _In_ Windows::UI::Core::CoreWindow^ sender,
        _In_ Windows::UI::Core::VisibilityChangedEventArgs^ args
        );

    void Update();
    void SetGameInfoOverlay(GameInfoOverlayState state);
    void SetAction (GameInfoOverlayCommand command);
    void ShowGameInfoOverlay();
    void HideGameInfoOverlay();
    void SetSnapped();
    void HideSnapped();

    bool                                                m_windowClosed;
    bool                                                m_renderNeeded;
    bool                                                m_haveFocus;
    bool                                                m_visible;

    MoveLookController^                                 m_controller;
    GameRenderer^                                       m_renderer;
    Simple3DGame^                                       m_game;

    UpdateEngineState                                   m_updateState;
    UpdateEngineState                                   m_updateStateNext;
    PressResultState                                    m_pressResult;
    GameInfoOverlayState                                m_gameInfoOverlayState;
    GameInfoOverlayCommand                              m_gameInfoOverlayCommand;
    uint32                                              m_loadingCount;
};

ref class Direct3DApplicationSource : Windows::ApplicationModel::Core::IFrameworkViewSource
{
public:
    virtual Windows::ApplicationModel::Core::IFrameworkView^ CreateView();
};
```

App.cpp

```cpp
//--------------------------------------------------------------------------------------
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "App.h"

using namespace concurrency;
using namespace DirectX;
using namespace Windows::ApplicationModel;
using namespace Windows::ApplicationModel::Activation;
using namespace Windows::ApplicationModel::Core;
using namespace Windows::Foundation;
using namespace Windows::Graphics::Display;
using namespace Windows::UI::Core;
using namespace Windows::UI::Input;
using namespace Windows::UI::ViewManagement;


App::App() :
    m_windowClosed(false),
    m_haveFocus(false),
    m_gameInfoOverlayCommand(GameInfoOverlayCommand::None),
    m_visible(true),
    m_loadingCount(0),
    m_updateState(UpdateEngineState::WaitingForResources)
{
}

//--------------------------------------------------------------------------------------

void App::Initialize(
    _In_ CoreApplicationView^ applicationView
    )
{
    applicationView->Activated +=
        ref new TypedEventHandler<CoreApplicationView^, IActivatedEventArgs^>(this, &App::OnActivated);

    CoreApplication::Suspending +=
        ref new EventHandler<SuspendingEventArgs^>(this, &App::OnSuspending);

    CoreApplication::Resuming +=
        ref new EventHandler<Platform::Object^>(this, &App::OnResuming);

    m_controller = ref new MoveLookController();
    m_renderer = ref new GameRenderer();
    m_game = ref new Simple3DGame();
}

//--------------------------------------------------------------------------------------

void App::SetWindow(
    _In_ CoreWindow^ window
    )
{
    window->PointerCursor = ref new CoreCursor(CoreCursorType::Arrow, 0);

    PointerVisualizationSettings^ visualizationSettings = PointerVisualizationSettings::GetForCurrentView();
    visualizationSettings->IsContactFeedbackEnabled = false;
    visualizationSettings->IsBarrelButtonFeedbackEnabled = false;

    window->SizeChanged +=
        ref new TypedEventHandler<CoreWindow^, WindowSizeChangedEventArgs^>(this, &App::OnWindowSizeChanged);

    window->Closed +=
        ref new TypedEventHandler<CoreWindow^, CoreWindowEventArgs^>(this, &App::OnWindowClosed);

    window->VisibilityChanged +=
        ref new TypedEventHandler<CoreWindow^, VisibilityChangedEventArgs^>(this, &App::OnVisibilityChanged);

    DisplayProperties::LogicalDpiChanged +=
        ref new DisplayPropertiesEventHandler(this, &App::OnLogicalDpiChanged);

    m_controller->Initialize(window);

    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, window->Bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(window->Bounds.Width - GameConstants::TouchRectangleSize, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(window->Bounds.Width, window->Bounds.Height)
        );

    m_renderer->Initialize(window, DisplayProperties::LogicalDpi);
    SetGameInfoOverlay(GameInfoOverlayState::Loading);
    ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::Load(
    _In_ Platform::String^ /* entryPoint */
    )
{
    create_task([this]()
    {
        // Asynchronously initialize the game class and load the renderer device resources.
        // By doing all this asynchronously, the game gets to its main loop more quickly
        // and loads all the necessary resources in parallel on other threads.
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
            // In the middle of a game, so spin up the async task to load the level.
            create_task([this]()
            {
                return m_game->LoadLevelAsync();

            }).then([this]()
            {
                // The m_game object may need to deal with D3D device context work, so
                // again the finalize code needs to run in the same thread
                // context as the m_renderer object was created because the D3D 
                // device context can ONLY be accessed on a single thread.
                m_game->FinalizeLoadLevel();
                m_updateState = UpdateEngineState::ResourcesLoaded;

            }, task_continuation_context::use_current());
        }
    }, task_continuation_context::use_current());
}

//--------------------------------------------------------------------------------------

void App::Run()
{
    while (!m_windowClosed)
    {
        if (m_visible)
        {
            switch (m_updateState)
            {
            case UpdateEngineState::Deactivated:
            case UpdateEngineState::Snapped:
                if (!m_renderNeeded)
                {
                    // The App is not currently the active window, so just wait for events.
                    CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
                    break;
                }
                // Otherwise, fall through and do normal processing to get the rendering handled.
            default:
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                Update();
                m_renderer->Render();
                m_renderNeeded = false;
            }
        }
        else
        {
            CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
        }
    }
    m_game->OnSuspending();  // Exiting due to window close.  Make sure to save state.
}

//--------------------------------------------------------------------------------------

void App::Uninitialize()
{
}

//--------------------------------------------------------------------------------------

void App::OnWindowSizeChanged(
    _In_ CoreWindow^ window,
    _In_ WindowSizeChangedEventArgs^ /* args */
    )
{
    UpdateViewState();
    m_renderer->UpdateForWindowSizeChange();

    // The location of the GameInfoOverlay may have changed with the size change, so update the controller.
    m_controller->SetMoveRect(
        XMFLOAT2(0.0f, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(GameConstants::TouchRectangleSize, window->Bounds.Height)
        );
    m_controller->SetFireRect(
        XMFLOAT2(window->Bounds.Width - GameConstants::TouchRectangleSize, window->Bounds.Height - GameConstants::TouchRectangleSize),
        XMFLOAT2(window->Bounds.Width, window->Bounds.Height)
        );

    if (m_updateState == UpdateEngineState::WaitingForPress)
    {
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
    }
}

//--------------------------------------------------------------------------------------

void App::OnWindowClosed(
    _In_ CoreWindow^ /* sender */,
    _In_ CoreWindowEventArgs^ /* args */
    )
{
    m_windowClosed = true;
}

//--------------------------------------------------------------------------------------

void App::OnLogicalDpiChanged(
    _In_ Platform::Object^ /* sender */
    )
{
    m_renderer->SetDpi(DisplayProperties::LogicalDpi);

    // The GameInfoOverlay may have been recreated as a result of DPI changes, so
    // regenerate the data.
    SetGameInfoOverlay(m_gameInfoOverlayState);
    SetAction(m_gameInfoOverlayCommand);
}

//--------------------------------------------------------------------------------------

void App::OnActivated(
    _In_ CoreApplicationView^ /* applicationView */,
    _In_ IActivatedEventArgs^ /* args */
    )
{
    CoreWindow::GetForCurrentThread()->Activated +=
        ref new TypedEventHandler<CoreWindow^, WindowActivatedEventArgs^>(this, &App::OnWindowActivationChanged);
    CoreWindow::GetForCurrentThread()->Activate();
}

//--------------------------------------------------------------------------------------

void App::OnVisibilityChanged(
    _In_ CoreWindow^ /* sender */,
    _In_ VisibilityChangedEventArgs^ args
    )
{
    m_visible = args->Visible;
}

//--------------------------------------------------------------------------------------

void App::InitializeGameState()
{
    // Set up the initial state machine for handling the Game playing state.
    if (m_game->GameActive() && m_game->LevelActive())
    {
        // The last time the game terminated it was in the middle
        // of a level.
        // We are waiting for the user to continue the game.
        m_updateState = UpdateEngineState::WaitingForResources;
        m_pressResult = PressResultState::ContinueLevel;
        SetGameInfoOverlay(GameInfoOverlayState::Pause);
        SetAction(GameInfoOverlayCommand::PleaseWait);
    }
    else if (!m_game->GameActive() && (m_game->HighScore().totalHits > 0))
    {
        // The last time the game terminated the game had been completed.
        // Show the high score.
        // We are waiting for the user to acknowledge the high score and start a new game.
        // The level resources for the first level will be loaded later.
        m_updateState = UpdateEngineState::WaitingForPress;
        m_pressResult = PressResultState::LoadGame;
        SetGameInfoOverlay(GameInfoOverlayState::GameStats);
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
        SetAction(GameInfoOverlayCommand::TapToContinue);
    }
    else
    {
        // This is either the first time the game has run or
        // the last time the game terminated the level was completed.
        // We are waiting for the user to begin the next level.
        m_updateState = UpdateEngineState::WaitingForResources;
        m_pressResult = PressResultState::PlayLevel;
        SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
        SetAction(GameInfoOverlayCommand::PleaseWait);
    }
    ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::Update()
{
    static uint32 loadCount = 0;

    m_controller->Update();

    switch (m_updateState)
    {
    case UpdateEngineState::WaitingForResources:
        // Waiting for the initial load.  Display an update once per 60 updates.
        loadCount++;
        if ((loadCount % 60) == 0)
        {
            m_loadingCount++;
            SetGameInfoOverlay(m_gameInfoOverlayState);
        }
        break;

    case UpdateEngineState::ResourcesLoaded:
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
        m_updateState = UpdateEngineState::WaitingForPress;
        SetAction(GameInfoOverlayCommand::TapToContinue);
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
        ShowGameInfoOverlay();
        m_renderNeeded = true;
        break;

    case UpdateEngineState::WaitingForPress:
        if (m_controller->IsPressComplete())
        {
            switch (m_pressResult)
            {
            case PressResultState::LoadGame:
                m_updateState = UpdateEngineState::WaitingForResources;
                m_pressResult = PressResultState::PlayLevel;
                m_controller->Active(false);
                m_game->LoadGame();
                SetAction(GameInfoOverlayCommand::PleaseWait);
                SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
                ShowGameInfoOverlay();

                m_game->LoadLevelAsync().then([this]()
                {
                    m_game->FinalizeLoadLevel();
                    m_updateState = UpdateEngineState::ResourcesLoaded;

                }, task_continuation_context::use_current());
                break;

            case PressResultState::PlayLevel:
                m_updateState = UpdateEngineState::Dynamics;
                HideGameInfoOverlay();
                m_controller->Active(true);
                m_game->StartLevel();
                break;

            case PressResultState::ContinueLevel:
                m_updateState = UpdateEngineState::Dynamics;
                HideGameInfoOverlay();
                m_controller->Active(true);
                m_game->ContinueGame();
                break;
            }
        }
        break;

    case UpdateEngineState::Dynamics:
        if (m_controller->IsPauseRequested())
        {
            m_game->PauseGame();
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            SetAction(GameInfoOverlayCommand::TapToContinue);
            m_updateState = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            ShowGameInfoOverlay();
        }
        else
        {
            GameState runState = m_game->RunGame();
            switch (runState)
            {
            case GameState::TimeExpired:
                SetAction(GameInfoOverlayCommand::TapToContinue);
                SetGameInfoOverlay(GameInfoOverlayState::GameOverExpired);
                ShowGameInfoOverlay();
                m_updateState = UpdateEngineState::WaitingForPress;
                m_pressResult = PressResultState::LoadGame;
                break;

            case GameState::LevelComplete:
                SetAction(GameInfoOverlayCommand::PleaseWait);
                SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
                ShowGameInfoOverlay();
                m_updateState = UpdateEngineState::WaitingForResources;
                m_pressResult = PressResultState::PlayLevel;

                m_game->LoadLevelAsync().then([this]()
                {
                    m_game->FinalizeLoadLevel();
                    m_updateState = UpdateEngineState::ResourcesLoaded;

                }, task_continuation_context::use_current());
                break;

            case GameState::GameComplete:
                SetAction(GameInfoOverlayCommand::TapToContinue);
                SetGameInfoOverlay(GameInfoOverlayState::GameOverCompleted);
                ShowGameInfoOverlay();
                m_updateState  = UpdateEngineState::WaitingForPress;
                m_pressResult = PressResultState::LoadGame;
                break;
            }
        }

        if (m_updateState == UpdateEngineState::WaitingForPress)
        {
            // Transitioning state, so enable waiting for the press event.
            m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
        }
        if (m_updateState == UpdateEngineState::WaitingForResources)
        {
            // Transitioning state, so shut down the input controller until resources are loaded.
            m_controller->Active(false);
        }
        break;
    }
}

//--------------------------------------------------------------------------------------

void App::OnWindowActivationChanged(
    _In_ Windows::UI::Core::CoreWindow^ /* sender */,
    _In_ Windows::UI::Core::WindowActivatedEventArgs^ args
    )
{
    if (args->WindowActivationState == CoreWindowActivationState::Deactivated)
    {
        m_haveFocus = false;

        switch (m_updateState)
        {
        case UpdateEngineState::Dynamics:
            // From Dynamic mode, when coming out of Deactivated rather than going directly back into game play
            // go to the paused state waiting for user input to continue.
            m_updateStateNext = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            ShowGameInfoOverlay();
            m_game->PauseGame();
            m_updateState = UpdateEngineState::Deactivated;
            SetAction(GameInfoOverlayCommand::None);
            m_renderNeeded = true;
            break;

        case UpdateEngineState::WaitingForResources:
        case UpdateEngineState::WaitingForPress:
            m_updateStateNext = m_updateState;
            m_updateState = UpdateEngineState::Deactivated;
            SetAction(GameInfoOverlayCommand::None);
            ShowGameInfoOverlay();
            m_renderNeeded = true;
            break;
        }
        // Don't have focus, so shutdown input processing.
        m_controller->Active(false);
    }
    else if (args->WindowActivationState == CoreWindowActivationState::CodeActivated
        || args->WindowActivationState == CoreWindowActivationState::PointerActivated)
    {
        m_haveFocus = true;

        if (m_updateState == UpdateEngineState::Deactivated)
        {
            m_updateState = m_updateStateNext;

            if (m_updateState == UpdateEngineState::WaitingForPress)
            {
                SetAction(GameInfoOverlayCommand::TapToContinue);
                m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
            }
            else if (m_updateStateNext == UpdateEngineState::WaitingForResources)
            {
                SetAction(GameInfoOverlayCommand::PleaseWait);
            }
        }
    }
}

//--------------------------------------------------------------------------------------

void App::OnSuspending(
    _In_ Platform::Object^ /* sender */,
    _In_ SuspendingEventArgs^ args
    )
{
    // Save application state.
    // If your application needs time to complete a lengthy operation, it can request a deferral.
    // The SuspendingOperation has a deadline time. Make sure all your operations are complete by that time!
    // If the app doesn't return from this handler within five seconds, it will be terminated.
    SuspendingOperation^ op = args->SuspendingOperation;
    SuspendingDeferral^ deferral = op->GetDeferral();

    create_task([=]()
    {
        switch (m_updateState)
        {
        case UpdateEngineState::Dynamics:
            // Game is in the active game play state, Stop Game Timer and Pause play and save the state.
            SetAction(GameInfoOverlayCommand::None);
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            m_updateStateNext = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            m_game->PauseGame();
            break;

        case UpdateEngineState::WaitingForResources:
        case UpdateEngineState::WaitingForPress:
            m_updateStateNext = m_updateState;
            break;

        default:
            // If it is any other state, don't save as the next state as they are transient states and have already set m_updateStateNext
            break;
        }
        m_updateState = UpdateEngineState::Suspended;

        m_controller->Active(false);
        m_game->OnSuspending();

        deferral->Complete();
    });
}

//--------------------------------------------------------------------------------------

void App::OnResuming(
    _In_ Platform::Object^ /* sender */,
    _In_ Platform::Object^ /* args */
    )
{
    if (m_haveFocus)
    {
        m_updateState = m_updateStateNext;
    }
    else
    {
        m_updateState = UpdateEngineState::Deactivated;
    }

    if (m_updateState == UpdateEngineState::WaitingForPress)
    {
        SetAction(GameInfoOverlayCommand::TapToContinue);
        m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
    }
    m_game->OnResuming();
    ShowGameInfoOverlay();
    m_renderNeeded = true;
}

//--------------------------------------------------------------------------------------

void App::UpdateViewState()
{
    m_renderNeeded = true;

    if (ApplicationView::Value == ApplicationViewState::Snapped)
    {
        switch (m_updateState)
        {
        case UpdateEngineState::Dynamics:
            // From Dynamic mode, when coming out of SNAPPED layout rather than going directly back into game play,
            // go to the paused state and wait for user input to continue.
            m_updateStateNext = UpdateEngineState::WaitingForPress;
            m_pressResult = PressResultState::ContinueLevel;
            SetGameInfoOverlay(GameInfoOverlayState::Pause);
            SetAction(GameInfoOverlayCommand::TapToContinue);
            m_game->PauseGame();
            break;

        case UpdateEngineState::WaitingForResources:
        case UpdateEngineState::WaitingForPress:
            // Avoid corrupting the m_updateStateNext on a transition from Snapped -> Snapped.
            // Otherwise, just cache the current state and return to it when leaving SNAPPED layout.

            m_updateStateNext = m_updateState;
            break;

        default:
            break;
        }

        m_updateState = UpdateEngineState::Snapped;
        m_controller->Active(false);
        HideGameInfoOverlay();
        SetSnapped();
    }
    else if (ApplicationView::Value == ApplicationViewState::Filled ||
        ApplicationView::Value == ApplicationViewState::FullScreenLandscape ||
        ApplicationView::Value == ApplicationViewState::FullScreenPortrait)
    {
        if (m_updateState == UpdateEngineState::Snapped)
        {

            HideSnapped();
            ShowGameInfoOverlay();
            m_renderNeeded = true;

            if (m_haveFocus)
            {
                if (m_updateStateNext == UpdateEngineState::WaitingForPress)
                {
                    SetAction(GameInfoOverlayCommand::TapToContinue);
                    m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
                }
                else if (m_updateStateNext == UpdateEngineState::WaitingForResources)
                {
                    SetAction(GameInfoOverlayCommand::PleaseWait);
                }

                m_updateState = m_updateStateNext;
            }
            else
            {
                m_updateState = UpdateEngineState::Deactivated;
                SetAction(GameInfoOverlayCommand::None);
            }
        }
    }
}

//--------------------------------------------------------------------------------------

void App::SetGameInfoOverlay(GameInfoOverlayState state)
{
    m_gameInfoOverlayState = state;
    switch (state)
    {
    case GameInfoOverlayState::Loading:
        m_renderer->InfoOverlay()->SetGameLoading(m_loadingCount);
        break;

    case GameInfoOverlayState::GameStats:
        m_renderer->InfoOverlay()->SetGameStats(
            m_game->HighScore().levelCompleted + 1,
            m_game->HighScore().totalHits,
            m_game->HighScore().totalShots
            );
        break;

    case GameInfoOverlayState::LevelStart:
        m_renderer->InfoOverlay()->SetLevelStart(
            m_game->LevelCompleted() + 1,
            m_game->CurrentLevel()->Objective(),
            m_game->CurrentLevel()->TimeLimit(),
            m_game->BonusTime()
            );
        break;

    case GameInfoOverlayState::GameOverCompleted:
        m_renderer->InfoOverlay()->SetGameOver(
            true,
            m_game->LevelCompleted() + 1,
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::GameOverExpired:
        m_renderer->InfoOverlay()->SetGameOver(
            false,
            m_game->LevelCompleted(),
            m_game->TotalHits(),
            m_game->TotalShots(),
            m_game->HighScore().totalHits
            );
        break;

    case GameInfoOverlayState::Pause:
        m_renderer->InfoOverlay()->SetPause();
        break;
    }
}

//--------------------------------------------------------------------------------------

void App::SetAction (GameInfoOverlayCommand command)
{
    m_gameInfoOverlayCommand = command;
    m_renderer->InfoOverlay()->SetAction(command);
}

//--------------------------------------------------------------------------------------

void App::ShowGameInfoOverlay()
{
    m_renderer->InfoOverlay()->ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::HideGameInfoOverlay()
{
    m_renderer->InfoOverlay()->HideGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::SetSnapped()
{
    m_renderer->InfoOverlay()->SetPause();
    m_renderer->InfoOverlay()->ShowGameInfoOverlay();
}

//--------------------------------------------------------------------------------------

void App::HideSnapped()
{
    m_renderer->InfoOverlay()->HideGameInfoOverlay();
    SetGameInfoOverlay(m_gameInfoOverlayState);
}

//--------------------------------------------------------------------------------------

IFrameworkView^ DirectXAppSource::CreateView()
{
    return ref new App();
}

//--------------------------------------------------------------------------------------

[Platform::MTAThread]
int main(Platform::Array<Platform::String^>^)
{
    auto direct3DApplicationSource = ref new Direct3DApplicationSource();
    CoreApplication::Run(direct3DApplicationSource);
    return 0;
}

//--------------------------------------------------------------------------------------
```

 

 







<!--HONumber=Jun16_HO4-->


