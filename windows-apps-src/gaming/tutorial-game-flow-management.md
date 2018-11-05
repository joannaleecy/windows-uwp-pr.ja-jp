---
author: joannaleecy
title: ゲームのフロー管理
description: ゲームの状態の初期化、イベントの処理、ゲームの更新ループのセットアップの方法について説明します。
ms.assetid: 6c33bf09-b46a-4bb5-8a59-ca83ce257eb3
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: 610b794c0ded6791e93c14d8960366132afd973b
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6044582"
---
# <a name="game-flow-management"></a>ゲームのフロー管理

ゲームは、ウィンドウを持ち、いくつかのイベント ハンドラーを登録し、アセットを非同期的に読み込むようになりました。 このセクションでは、ゲームの状態の使用方法、特定の主要なゲーム状態を管理する方法、ゲーム エンジンの更新ループを作成する方法について説明します。 次に、ユーザー インターフェイスのフローについて学習し、最後に、UWP ゲームに必要なイベント ハンドラーとイベントについての理解を深めます。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="game-states-used-to-manage-game-flow"></a>ゲームのフローを管理するために使用するゲームの状態

ゲームのフローを管理するには、ゲームの状態を使用します。 ユーザーは UWP ゲーム アプリを中断状態からいつでも再開できるため、アプリが置かれる可能性のある状態は任意に設定できます。

このゲーム サンプルの場合、ゲームの開始時に、次の 3 つのいずれかの状態になります。
* ゲーム ループが実行中で、いずれかのレベル中の状態。
* ゲームがちょうど完了したため、ゲーム ループが実行されていない状態。 (ハイ スコアが設定されます)
* ゲームが開始されていないか、ゲームが 2 つのレベルの中間にある状態。 (ハイ スコアは 0)

ゲームのニーズに応じて必要なの数の状態を定義することができます。 繰り返しますが、UWP ゲームはいつでも終了できるため、プレイヤーは再開時に、ゲームをまったく停止していなかったかのようにゲームが動作すると期待することを覚えておいてください。

## <a name="game-states-initialization"></a>ゲームの状態の初期化

ゲームの初期化では、ゲームのコールド スタートだけでなく、一時停止または終了後の再開も考慮します。 サンプル ゲームではゲームの状態が常に保存されるので、アプリの実行が継続しているように見えます。 

中断状態では、ゲーム プレイは中断されますが、ゲームのリソースはメモリに残されます。 

同様に、再開イベントでは、サンプル ゲームが前回中断または終了された時点から再開されます。 サンプル ゲームが終了後に再起動されると、通常どおり開始され、その後、最後の既知の状態が判断されるため、プレーヤーはゲームの続きを即座に続行できます。

状態に応じて、異なるオプションがプレイヤーに表示されます。 

* ゲームは、2 つのレベルの中間から再開された場合、一時停止しているように見え、オーバーレイで続行オプションが表示されます。
* また、完了状態から再開された場合は、ハイ スコアと、新しいゲームを開始するオプションが表示されます。
* そして、いずれかのレベルが開始される前にゲームが再開された場合は、オーバーレイで開始オプションがユーザーに表示されます。

このゲーム サンプルでは、ゲームのコールド スタート、中断イベントがない状態での初めての起動、ゲームの中断状態からの再開を区別していません。 これは、どの UWP アプリにも適切な設計です。

このサンプルでは、[__GameMain::InitializeGameState__](#gamemaininitializegamestate-method) でゲームの状態の初期化が行われます。

このフローを視覚化するためのフローチャートを以下に示します。これは、初期化と更新ループの両方を示しています。

* 初期化は、__Start__ ノードから始まり、現在のゲームの状態をチェックします。 ゲームのコードについては、[__GameMain::InitializeGameState__](#gamemaininitializegamestate-method) の説明をご覧ください。
* 更新ループについて詳しくは、「[ゲーム エンジンを更新する](#update-game-engine)」をご覧ください。 ゲームのコードについては、[__App::Update__](#appupdate-method) の説明をご覧ください。

![ゲームのメイン ステート マシン](images/simple-dx-game-flow-statemachine.png)

### <a name="gamemaininitializegamestate-method"></a>GameMain::InitializeGameState メソッド

__InitializeGameState__ メソッドは、[__GameMain__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L32-L131) コンストラクター クラスから呼び出されます。このコンストラクターは、[__App::Load__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L115-L123) メソッドで __GameMain__ クラスのオブジェクトが作成されるときに呼び出されます。

```cpp

GameMain::GameMain(...)
{
    m_deviceResources->RegisterDeviceNotify(this);
    ...

    create_task([this]()
    {
        ...

    }).then([this]()
    {
        // The finalize code needs to run in the same thread context
        // as the m_renderer object was created because the D3D device context
        // can ONLY be accessed on a single thread.
        m_renderer->FinalizeCreateGameDeviceResources();

        InitializeGameState(); //Initialization of game states occurs here.
        
        ...
    
    }, task_continuation_context::use_current()).then([this]()
    {
        ...
        
    }, task_continuation_context::use_current());
}

```

```cpp

void GameMain::InitializeGameState()
{
    // Set up the initial state machine for handling Game playing state.
    if (m_game->GameActive() && m_game->LevelActive())
    {
        // The last time the game terminated it was in the middle of a level.
        // We are waiting for the user to continue the game.
        //...
    }
    else if (!m_game->GameActive() && (m_game->HighScore().totalHits > 0))
    {
        // The last time the game terminated the game had been completed.
        // Show the high score.
        // We are waiting for the user to acknowledge the high score and start a new game.
        // The level resources for the first level will be loaded later.
        //...
    }
    else
    {
        // This is either the first time the game has run or
        // the last time the game terminated the level was completed.
        // We are waiting for the user to begin the next level.
        m_updateState = UpdateEngineState::WaitingForResources;
        m_pressResult = PressResultState::PlayLevel;
        SetGameInfoOverlay(GameInfoOverlayState::LevelStart);
        m_uiControl->SetAction(GameInfoOverlayCommand::PleaseWait);
    }
    m_uiControl->ShowGameInfoOverlay();
}

```

## <a name="update-game-engine"></a>ゲーム エンジンを更新する

[__App::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L127-L130) メソッドで、[__GameMain::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L143-L202) を呼び出します。 このサンプルでは、このメソッド内に、プレイヤーが実行できる主な操作すべてを処理する基本的なステート マシンを実装しています。 このステート マシンの最上位レベルは、ゲームの読み込み、特定のレベルのゲーム プレイ、ゲームが (システムあるいはプレーヤーによって) 一時停止された後のレベルの続行を処理します。

このゲーム サンプルには、ゲームの主な状態 (__UpdateEngineState__) として次の 3 つがあります。

1. __Waiting for resources__: ゲーム ループが循環していて、リソース (具体的にはグラフィックス リソース) が使用可能になるまで、移行できません。 リソースを読み込む非同期タスクが完了すると、状態が __ResourcesLoaded__ に更新されます。 これは通常、2 つのレベルの中間で発生します。レベルの中間では、新しいリソースをディスク、ゲーム サーバー、クラウド バックエンドから読み込みます。 このゲーム サンプルでは、その時点ではレベルごとに追加のリソースは必要ないため、この動作はシミュレートされます。
2. __Waiting for press__: ゲーム ループが循環していて、特定のユーザー入力を待機しています。 この入力は、プレイヤーによるゲームの読み込み、レベルの開始、またはレベルの続行の操作です。 サンプル コードでは、これらの下位状態として、__PressResultState__ 列挙値を使っています。
3. __Dynamics__: ゲーム ループが実行中で、ユーザーがプレイしています。 ユーザーがプレイ中に、ゲームは移行できる 3 つの条件をチェックします。 
    * __TimeExpired__: レベルに設定されている時間の有効期限
    * __LevelComplete__: プレイヤーによるレベルの完了 
    * __GameComplete__: プレイヤーによるすべてのレベルの完了

ゲームは、複数の小さいステート マシンが含まれているステート マシンにすぎません。 それぞれの状態は、非常に具体的な条件によって定義されている必要があります。 ある状態から別の状態への移行は、ユーザー入力またはシステムによる個々の操作 (グラフィックス リソースの読み込みなど) に基づいて行われる必要があります。 ゲームの計画時に、ユーザーやシステムが実行すると考えられるすべての操作に確実に対応できるように、ゲーム フローの全体像を詳細に計画することを検討してください。 ゲームは非常に複雑な場合があり、ステート マシンは、この複雑さを視覚化して扱いやすくする強力なツールです。

次に、更新ループのコードを見てみましょう。

### <a name="appupdate-method"></a>App::Update メソッド

ゲーム エンジンの更新に使われるステート マシンの構造

```cpp
void GameMain::Update()
{
    m_controller->Update(); //the controller instance has its own update loop.

    switch (m_updateState)
    {
    case UpdateEngineState::WaitingForResources:
        //...
        break;

    case UpdateEngineState::ResourcesLoaded:
        //...
        break;

    case UpdateEngineState::WaitingForPress:
        if (m_controller->IsPressComplete())
        {
            //...
        }
        break;

    case UpdateEngineState::Dynamics:
        if (m_controller->IsPauseRequested())
        {
            //...
        }
        else
        {
            GameState runState = m_game->RunGame(); //when the player is playing, the work is handled by this Simple3DGame::RunGame method.
            switch (runState)
            {
            case GameState::TimeExpired:
                //...
                break;

            case GameState::LevelComplete:
                //...
                break;

            case GameState::GameComplete:
                //...
                break;
            }
        }

        if (m_updateState == UpdateEngineState::WaitingForPress)
        {
            // Transitioning state, so enable waiting for the press event
            m_controller->WaitForPress(m_renderer->GameInfoOverlayUpperLeft(), m_renderer->GameInfoOverlayLowerRight());
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

## <a name="update-user-interface"></a>ユーザー インターフェイスを更新する

プレイヤーには、システムの状態を継続的に通知して、プレイヤーの操作とゲームを定義するルールに応じて、ゲームの状態を変更できるようにする必要があります。 このゲームのサンプルを含む多くのゲームは、通常、ユーザー インターフェイス (UI) を使用して、プレイヤーにこの情報を表示します。 UI には、ゲームの状態や、スコア、弾薬、残りのチャンスの数などのプレイ固有の情報が表されます。 UI はオーバーレイとも呼ばれます。メインのグラフィックス パイプラインとは別にレンダリングされ、3D プロジェクションの上に配置されるためです。 一部の UI の情報は、ヘッドアップ ディスプレイ (HUD) としても表示され、ユーザーはゲームプレイのメイン領域から視線を移動することなく、これらの情報を把握できます。 このサンプル ゲームでは、このオーバーレイを Direct2D API を使って作成しています。 このオーバーレイは、XAML を使って作成することもできます。これについては、「[ゲーム サンプルの紹介](tutorial-resources.md)」で説明します。

ユーザー インターフェイスには次の 2 つのコンポーネントがあります。

-   スコアとゲーム プレイの現在の状態に関する情報が含まれている HUD。
-   一時停止ビットマップ。これは、ゲームの一時停止/中断状態中にテキストがオーバーレイされる黒の四角形です。 これがゲーム オーバーレイです。 これについては、「[ユーザー インターフェイスの追加](tutorial--adding-a-user-interface.md)」で詳しく説明します。

当然のことながら、オーバーレイにもステート マシンがあります。 オーバーレイは、レベル開始またはゲーム オーバーのメッセージを表示できます。 これは、ゲームが一時停止または中断されたときに、プレーヤーに表示する必要があるゲームの状態に関する情報を出力するキャンバスのように機能します。

オーバーレイのレンダリングには、ゲームの状態に応じて、6 つの画面のいずれかを指定できます。 
1. ゲームの開始時のリソースの読み込み画面
2. ゲームのプレイ開始画面
3. レベルの開始メッセージ画面
4. 時間切れになる前にすべてのレベルが完了した場合のゲーム オーバー画面
5. 時間切れになった場合のゲーム オーバー画面
6. 一時停止メニュー画面

ユーザー インターフェイスをゲームのグラフィックス パイプラインから分離すると、ゲームのグラフィックス レンダリング エンジンとは別に操作でき、ゲームのコードの複雑さが大幅に軽減されます。

このゲーム サンプルでオーバーレイのステート マシンを構成する方法は次のとおりです。

```cpp
void GameMain::SetGameInfoOverlay(GameInfoOverlayState state)
{
    m_gameInfoOverlayState = state;
    switch (state)
    {
    case GameInfoOverlayState::Loading:
        m_uiControl->SetGameLoading(m_loadingCount);
        break;

    case GameInfoOverlayState::GameStats:
        //...
        break;

    case GameInfoOverlayState::LevelStart:
        //...
        break;

    case GameInfoOverlayState::GameOverCompleted:
        //...
        break;

    case GameInfoOverlayState::GameOverExpired:
        //...
        break;

    case GameInfoOverlayState::Pause:
        //...
        break;
    }
}
```

## <a name="events-handling"></a>イベントの処理

サンプル コードでは、特定のイベントに対する多数のハンドラーが App.cpp の **Initialize**、**SetWindow**、**Load** に登録されています。 これらは重要なイベントであり、ゲームのしくみを追加したり、グラフィックス開発を開始したりする前に処理する必要があります。 これらのイベントは、適切な UWP アプリのエクスペリエンスの基本です。 UWP アプリはいつでもアクティブ化、非アクティブ化、サイズ変更、スナップ、スナップの解除、中断、再開ができるため、ゲームではこれらのイベント自体をできる限り早く登録し、プレイヤーのエクスペリエンスをスムーズで予測可能な状態に保てる方法で、これらのイベントを処理する必要があります。

次の表に、このサンプルで使用されているイベント ハンドラーと、ハンドラーが処理するイベントを示します。

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
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/br225018"><strong>CoreApplicationView::Activated</strong></a> を処理します。 ゲーム アプリがフォアグラウンドに表示されているため、メイン ウィンドウがアクティブ化されます。</td>
</tr>
<tr class="even">
<td align="left">OnDpiChanged</td>
<td align="left"><a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_DpiChanged"><strong>Graphics::Display::DisplayInformation::DpiChanged</strong></a> を処理します。 ディスプレイの DPI が変更されていて、それに応じてゲームそのリソースを調整します。
<div class="alert">
<strong>注:</strong>[<strong>CoreWindow</strong>] (https://msdn.microsoft.com/library/windows/desktop/hh404559)座標は、 [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370987)の Dip (デバイスに依存しないピクセル) にします。 このため、2D アセットまたはプリミティブを正しく表示するには、Direct2D に DPI の変更を通知する必要があります。
</div>
<div>
</div></td>
</tr>
<tr class="odd">
<td align="left">OnOrientationChanged</td>
<td align="left"><a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_OrientationChanged"><strong>Graphics::Display::DisplayInformation::OrientationChanged</strong></a> を処理します。 ディスプレイの向きが変更され、レンダリングを更新する必要があります。</td>
</tr>
<tr class="even">
<td align="left">OnDisplayContentsInvalidated</td>
<td align="left"><a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_DisplayContentsInvalidated"><strong>Graphics::Display::DisplayInformation::DisplayContentsInvalidated</strong></a> を処理します。 ディスプレイを再描画する必要があり、ゲームをもう一度レンダリングする必要があります。</td>
</tr>
<tr class="odd">
<td align="left">OnResuming</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/br205859"><strong>CoreApplication::Resuming</strong></a> を処理します。 ゲーム アプリがゲームを中断状態から復元します。</td>
</tr>
<tr class="even">
<td align="left">OnSuspending</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/br205860"><strong>CoreApplication::Suspending</strong></a> を処理します。 ゲーム アプリがその状態をディスクに保存します。 ストレージへの状態の保存に使用できる時間は 5 秒です。</td>
</tr>
<tr class="odd">
<td align="left">OnVisibilityChanged</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/hh701591"><strong>CoreWindow::VisibilityChanged</strong></a> を処理します。 ゲーム アプリの表示が切り替わり、表示されるようになったか、別のアプリが表示されたために非表示になったことを示します。</td>
</tr>
<tr class="even">
<td align="left">OnWindowActivationChanged</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/br208255"><strong>CoreWindow::Activated</strong></a> を処理します。 ゲーム アプリのメイン ウィンドウが非アクティブ化またはアクティブ化されたため、フォーカスを動かしてゲームを一時停止するか、フォーカスを再取得する必要があります。 どちらの場合も、ゲームが一時停止されていることがオーバーレイに表示されます。</td>
</tr>
<tr class="odd">
<td align="left">OnWindowClosed</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/br208261"><strong>CoreWindow::Closed</strong></a> を処理します。 ゲーム アプリがメイン ウィンドウを閉じ、ゲームを中断します。</td>
</tr>
<tr class="even">
<td align="left">OnWindowSizeChanged</td>
<td align="left"><a href="https://msdn.microsoft.com/library/windows/apps/br208283"><strong>CoreWindow::SizeChanged</strong></a> を処理します。 サイズ変更に応じてゲーム アプリがグラフィックス リソースとオーバーレイを再割り当てし、その後、レンダー ターゲットを更新します。</td>
</tr>
</tbody>
</table>

## <a name="next-steps"></a>次のステップ

このトピックでは、ゲームの状態を使用してゲーム フロー全体を管理する方法と、ゲームが複数の異なるステート マシンで構成されていることを説明しました。 また、UI を更新する方法や、主要なアプリのイベント ハンドラーを管理する方法についても説明しました。 これで、レンダリング ループ、ゲーム、そのしくみを解説する準備が整いました。
 
任意の順序でこのゲームを構成するその他のコンポーネントについて学習することができます。
* [メイン ゲーム オブジェクトの定義](tutorial--defining-the-main-game-loop.md)
* [レンダリング フレームワーク I: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)
* [レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)
* [ユーザー インターフェイスの追加](tutorial--adding-a-user-interface.md)
* [コントロールの追加](tutorial--adding-controls.md)
* [サウンドの追加](tutorial--adding-sound.md)