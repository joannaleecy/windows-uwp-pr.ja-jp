---
title: メイン ゲーム オブジェクトの定義
description: ここでは、ゲーム サンプルのメイン オブジェクトの詳細と、実装するルールをゲーム ワールドとの対話式操作に変換する方法について説明します。
ms.assetid: 6afeef84-39d0-cb78-aa2e-2e42aef936c9
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, メイン オブジェクト
ms.localizationpriority: medium
ms.openlocfilehash: 96aefc8b053dd7490f47910ca5bb79989855e1a3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651497"
---
# <a name="define-the-main-game-object"></a>メイン ゲーム オブジェクトの定義

サンプルのゲームの基本的なフレームワークをレイアウトし、高度なユーザーとシステムの動作を処理するステート マシンを実装したら後をルールと、ゲームにゲームのサンプルを有効にするメカニズムを確認します。 ゲームの世界との対話にゲームのルールを変換する方法と、ゲームのサンプルのメインのオブジェクトの詳細を見てみましょう。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="objective"></a>目標

ゲームのルールおよび UWP の DirectX ゲームのメカニズムを実装する基本的な開発手法を適用する方法について説明します。

## <a name="main-game-object"></a>メイン ゲーム オブジェクト

このサンプル ゲーム__Simple3DGame__ゲーム オブジェクトのメイン クラスです。 インスタンス__Simple3DGame__でオブジェクトが構築された、 __App::Load__メソッド。

__Simple3DGame__クラス オブジェクト。
* ゲーム ロジックの実装を指定します
* 通信するメソッドが含まれます。
    * アプリケーション フレームワークで定義されているステート マシンに、ゲームの状態の変更。
    * ゲーム オブジェクト自体に、アプリから、ゲームの状態の変更。
    * ゲームの UI (オーバーレイとヘッドアップ ディスプレイ)、アニメーション、および物理学 (dynamics) を更新するための詳細。

    >[!Note]
    >グラフィックスの更新はによって処理される、 __GameRenderer__クラスを取得して、ゲームで使用されるグラフィックス デバイス リソースを使用するメソッドが含まれます。 詳細については、次を参照してください[レンダリング framework i:。レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)します。

* レベル、ゲームのセッションを定義するデータまたは高レベルでゲームを定義する方法に応じて、有効期間のコンテナーとして機能します。 この場合は、ゲームの状態データは、ゲームの有効期間はされ、ユーザーがゲームを起動するときに 1 回が初期化されます。

メソッドと、このクラスのオブジェクトで定義されているデータを表示するには[Simple3DGame オブジェクト](#simple3dgame-object)します。

## <a name="initialize-and-start-the-game"></a>初期化して、ゲームを開始

プレーヤーがゲームを開始すると、ゲーム オブジェクトはその状態を初期化し、オーバーレイの作成と追加を行い、プレーヤーのパフォーマンスを追跡する変数を設定して、レベルの構築時に使うオブジェクトをインスタンス化する必要があります。 このサンプルでは、これは、ときに、新しい__GameMain__でインスタンスが作成される[ __App::Load__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L115-L123)します。 

ゲーム オブジェクト__Simple3DGame__で作成、 __GameMain__コンス トラクター。 使用して、初期化、 [ __Simple3DGame::Initialize__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L54-L250)メソッド中に、[非同期でタスクを作成する、 __GameMain__コンス トラクター](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L65-L74).

### <a name="simple3dgameinitialize-method"></a>Simple3DGame::Initialize メソッド

ゲームのサンプルは、ゲーム オブジェクトには、次のコンポーネントを設定します。

* 新規のオーディオ再生オブジェクトを作成します。
* 一連のレベル プリミティブ、弾薬、障害物を含む、ゲームのグラフィック プリミティブの配列を作成します。
* ゲーム状態データを保存する場所を作成し、*Game* という名前を付け、[**ApplicationData::Current**](https://msdn.microsoft.com/library/windows/apps/br241619) で指定するアプリ データ設定ストレージの場所に格納します。
* ゲーム タイマーと初期ゲーム内オーバーレイ ビットマップを作成します。
* 具体的なビュー パラメーターとプロジェクション パラメーター セットを使って新規のカメラを作成します。
* プレーヤーがコントロール開始位置とカメラ位置の 1 対 1 の対応を確保されるように、入力デバイス (コントローラー) をカメラと同じ位置に上下と左右の開始位置を設定します。
* プレーヤー オブジェクトを作成し、アクティブに設定します。 球オブジェクトを使用して、壁や障害物をプレイヤーの近接性を検出し、カメラ immersion を壊す可能性がある位置に配置を取得することを防止します。
* ゲーム ワールド プリミティブを作成します。
* 円筒形の障害物を作成します。
* 標的 (**Face** オブジェクト) を作成し、番号を付けます。
* 弾薬の球体を作成します。
* レベルを作成します。
* ハイ スコアを読み込みます。
* 以前に保存されたゲーム状態を読み込みます。

ゲームには既に、ワールド、プレーヤー、障害物、標的、弾薬の球体の主要コンポーネントのインスタンスが存在します。 これらの全コンポーネントの設定と個々の固有レベルに対する動作を表すレベルのインスタンスもあります。 ゲームでどのようにレベルが構築されるのかを見てみます。

## <a name="build-and-load-game-levels"></a>ビルドやロード ゲーム レベル

面倒な作業のほとんどでレベルの構築が行われる、 __Level.h/.cpp__ファイルにある、 __GameLevels__サンプル ソリューションのフォルダー。 非常に特定の実装に焦点を当てます、ため、私たちは取り上げませんにここでします。 重要な点は、各レベルのコードがそれぞれ個別の __LevelN__ オブジェクトとして実行されるということです。 ゲームを拡張したい場合は作成、**レベル**オブジェクトをパラメーターとして、ランダムに割り当てられた数を受け取るが、障害物とターゲットを配置します。 または、リソース ファイル、またはインターネットからレベルの構成データを読み込むことができます。

## <a name="define-the-game-play"></a>ゲームのプレイを定義します。

この時点でゲームのアセンブルに必要なコンポーネントがすべて揃います。 レベルは、プリミティブからメモリ内の構築し、プレーヤーが操作を開始する準備が整いました。

とこの最高のゲームでは、プレイヤーの入力に瞬時に反応し、迅速なフィードバックを提供します。 これは、twitch アクション、リアルタイムの最初のユーザー連発銃ターンに基づくよく考えられた戦略ゲームからゲームの任意の型の場合は true。

### <a name="simple3dgamerungame-method"></a>Simple3DGame::RunGame メソッド

レベルを再生するときに、ゲームは、 __Dynamics__状態。 

[__GameMain::Update__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329)は次のように、フレームごとに 1 回、アプリケーションの状態を更新する更新プログラムのメイン ループします。 Update ループで呼び出して、 [ __Simple3DGame::RunGame__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)ゲームがある場合は、作業を処理するメソッドを__Dynamics__状態。

```cpp
// Updates the application state once per frame.
void GameMain::Update()
{
    m_controller->Update(); //the controller instance has its own update loop.

    switch (m_updateState)
    {
        //...

    case UpdateEngineState::Dynamics:
        if (m_controller->IsPauseRequested())
        {
            //...
        }
        else
        {
            GameState runState = m_game->RunGame(); //when playing a level, the game is in the Dynamics state. Work is handled by Simple3DGame::RunGame method.
            switch (runState)
            {
                
      //...
```
          
[__Simple3DGame::RunGame__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)ゲーム ループの現在のイテレーションのゲーム プレイの現在の状態を定義するデータのセットを処理します。

ゲームのフロー ロジックで__RunGame__:
*  メソッドは、レベルが終了するまでの間、残り時間を秒数でカウント ダウンするタイマーを更新し、レベルの時間が過ぎていないかをテストします。 これは、ゲームのルールの 1 つ: 時間がなくなるし、すべてのターゲットがショットされていない、ときに、ゲーム オーバーです。
*  時間切れになると、メソッドは **TimeExpired** ゲーム状態を設定し、前のコードの **Update** メソッドに戻ります。
*  時間が残っている場合は、ムーブ/ルック コントローラーがポーリングを行って、カメラ位置に更新がないかどうかを確認します。具体的には、カメラ平面 (プレーヤーが見ている面) の延長上にあるビュー法線の角度や、前回のコントローラーのポーリング時からの角度の移動距離が更新されていないかどうかを確認します。
*  カメラは、ムーブ/ルック コントローラーから送られる新しいデータに従って更新されます。
*  ダイナミクス、つまりプレーヤーのコントロールからは独立したゲーム ワールド中のオブジェクトのアニメーションや動作が更新されます。 このゲームのサンプルでは、 [ __UpdateDynamics()__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856)が起動されている、柱となる障害物のアニメーションとターゲットの動きを弾薬球の動きを更新するメソッドが呼び出されます。 詳細については、次を参照してください。[ゲームの世界を更新](#update-the-game-world)します。
*  メソッドが、レベルの正常な完了に関する基準が満たされているかどうかをチェックします。 満たされていれば、レベルのスコアをファイナライズし、これが最後のレベル (全 6 レベル) であるかどうかを判断します。 最後のレベルであれば、**GameComplete** ゲーム状態を返します。そうでない場合は、__LevelComplete__ ゲーム状態を返します。
*  レベルが完了していない場合は、ゲーム状態を __Active__ に設定し、戻ります。

## <a name="update-the-game-world"></a>ゲームの世界を更新します。

このサンプルでは、ゲームの実行時に、 [ __Simple3DGame::UpdateDynamics()__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856)メソッドの呼び出し元、 [ __Simple3DGame::RunGame__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)メソッド (から呼び出されるか[ __GameMain::Update__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329)) ゲームのシーンが表示されるオブジェクトを更新します。

__UpdateDynamics__ループ、呼び出しでモーション、プレイヤーの入力の独立したゲームの世界を設定するために使用するメソッドは、魅力的なゲーム エクスペリエンスを作成して、レベルが*アライブ*します。 グラフィックス レンダリングする必要がありますにはが含まれ、実行中のアニメーションが生きているものでは、プレイヤーの入力がない場合でもを世界を実現できるループします。 たとえば、岸行、機械禁煙、エイリアン モンスターの移動を拡大したりに沿って cresting ウェーブ、風にまきをツリー。 また、プレーヤーの球体とワールドの間、または弾薬、障害物、標的の間に生じる衝突を含め、物体どうしの相互作用も統合されます。

ゲームのループは常に物理アルゴリズムでは、ゲームのロジックに基づいているかどうか、または単純かどうか、ゲームの世界中の更新のゲームが具体的には一時停止を除く、ランダムなを保持します。 

ゲーム サンプルでは、この原理のことを*ダイナミクス*と呼んでいます。これにより、柱の障害物の上下の動き、発砲時に見られる弾薬の球体の動きや物理的動作が統合されます。 

### <a name="simple3dgameupdatedynamics-method"></a>Simple3DGame::UpdateDynamics メソッド 

このメソッドは、次の 4 種類の計算を行います。

* ワールドで発砲された弾薬の球体の位置
* 柱の障害物のアニメーション
* プレーヤーとワールドの境界の交差部分
* 弾薬の球体と、障害物、標的、他の弾薬球体、ワールドとの衝突

障害物のアニメーションは、**Animate.h/.cpp** で定義されたループとして実行されます。 弾薬とすべての競合の動作の簡略化された物理学のアルゴリズムで定義されている、コードで指定および重力や素材のプロパティを含む、ゲームの世界のグローバル定数のセットによってパラメーター化していること。 これはすべて、ゲーム ワールドの座標空間で計算されます。

### <a name="review-the-flow"></a>フローを確認してください。

これで、シーン内のすべてのオブジェクトを更新し、すべての競合を計算しましたしたら、この情報を使用して、対応する視覚的な変更を描画する必要があります。 

後__GameMain::Update()__ 、現在のイテレーションが完了すると、サンプルのゲームのループでは、呼び出してすぐに__Render()__ 更新されたオブジェクト データを受け取り、として、プレーヤーに表示する新しいシーンを生成するには次に示します。 次に、レンダリングを見てみましょう。

```cpp
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
                // ...
                // otherwise fall through and do normal processing to get the rendering handled.
            default:
                CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
                Update(); // GameMain::Update calls Simple3DGame::RunGame() if game is in Dynamics state, uses Simple3DGame::UpdateDynamics() to update game world.
                m_renderer->Render(); //Render() is called immediately after the Update() loop
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

## <a name="render-the-game-worlds-graphics"></a>ゲームの世界中のグラフィックスをレンダリングします。

ゲーム中のグラフィックスはできるだけ頻繁 (最大ではメインのゲーム ループが反復するごと) に更新することをお勧めします。 ループが反復するごとに、プレーヤーからの入力の有無を問わず、ゲームを更新します。 これにより、計算するアニメーションと動作がスムーズに表示されるようになります。 たとえば、プレーヤーがボタンを押したときにのみ、水が流れるという単純なシーンを思い浮かべてください。 ひどくつまらないビジュアルになるでしょう。 優れたゲームは、流れるような自然の動きを伴うものです。

上記のサンプル ゲームのループを思い出してください[ __GameMain::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L143-L202)します。 ゲームのメイン ウィンドウが表示されていて、スナップされたり、非アクティブにされたりしなければ、ゲームはそのまま、その更新結果の更新とレンダリングを続けます。 [__レンダリング__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameRenderer.cpp#L474-L624)調べているメソッドは今すぐその状態の表示を描画します。 呼び出しの直後にこれは、**更新**が含まれています**RunGame**前のセクションで説明した更新プログラムの状態にします。

このメソッドではまず 3D ワールドのプロジェクションが描画され、続いてその上に Direct2D オーバーレイが描画されます。 描画が完了すると、表示用に結合されたバッファーとともに最終的なスワップ チェーンが表示されます。

>[!Note]
>サンプル ゲームの Direct2D のオーバーレイの 2 つの状態があります 1 つのゲームが一時停止 メニューとゲームがタッチ スクリーンの移動についての四角形と十字線を表示する 1 つのビットマップを含むゲーム情報オーバーレイが表示されます。コント ローラー。 両方の状態でスコア テキストが描画されます。 詳細については、次を参照してください[レンダリング framework i:。レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)します。

### <a name="gamerendererrender-method"></a>GameRenderer::Render メソッド

```cpp
void GameRenderer::Render()
{
    bool stereoEnabled = m_deviceResources->GetStereoState();

    auto d3dContext = m_deviceResources->GetD3DDeviceContext();
    auto d2dContext = m_deviceResources->GetD2DDeviceContext();
   
        // ...
        if (m_game != nullptr && m_gameResourcesLoaded && m_levelResourcesLoaded)
        {
            // This section is only used after the game state has been initialized and all device
            // resources needed for the game have been created and associated with the game objects.
            //...
            auto objects = m_game->RenderObjects();
            for (auto object = objects.begin(); object != objects.end(); object++)
            {
                (*object)->Render(d3dContext, m_constantBufferChangesEveryPrim.Get()); // Renders the 3D objects
            }

        //...
        d3dContext->BeginEventInt(L"D2D BeginDraw", 1);
        d2dContext->BeginDraw(); //Start drawing the overlays
        
        // To handle the swapchain being pre-rotated, set the D2D transformation to include it.
        d2dContext->SetTransform(m_deviceResources->GetOrientationTransform2D());

        if (m_game != nullptr && m_gameResourcesLoaded)
        {
            // This is only used after the game state has been initialized.
            m_gameHud->Render(m_game); // Renders number of hits, shots, and time
        }

        if (m_gameInfoOverlay->Visible())
        {
            d2dContext->DrawBitmap(     // Renders the game overlay
                m_gameInfoOverlay->Bitmap(),
                m_gameInfoOverlayRect
                );
        }
        //...
    }
}
```

## <a name="simple3dgame-object"></a>Simple3DGame オブジェクト

これらは、メソッドとに定義されているデータ、 __Simple3DGame__オブジェクト クラス。

### <a name="methods"></a>メソッド

定義された内部メソッド**Simple3DGame**が含まれます。

-   **初期化**:グローバル変数の開始値を設定し、ゲーム オブジェクトを初期化します。 これについては、[を初期化して、ゲームを開始](#initialize-and-start-the-game)セクション。
-   **LoadGame**:新しいレベルを初期化し、読み込みを開始します。
-   **LoadLevelAsync**:非同期タスクを開始 (非同期タスクを慣れていない場合を参照してください。[並列パターン ライブラリ](https://docs.microsoft.com/cpp/parallel/concrt/parallel-patterns-library-ppl)) に、レベルを初期化し、デバイスの特定レベル リソースを読み込むレンダラーの非同期タスクを呼び出します。 このメソッドは独立したスレッドで実行されます。そのため、このスレッドから呼び出すことができるのは [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) メソッドだけです ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) メソッドは呼び出されません)。 デバイス コンテキストのメソッドは、**FinalizeLoadLevel** メソッドで呼び出されます。
-   **FinalizeLoadLevel**:メイン スレッドで実行する必要があるレベル読み込みの作業を完了します。 これには、Direct3D 11 のデバイス コンテキスト ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)) のメソッドの呼び出しが含まれます。
-   **StartLevel**:新しいレベルでゲーム プレイを開始します。
-   **PauseGame**:ゲームを一時停止します。
-   **RunGame**:ゲーム ループの反復を実行します。 ゲームの状態が **App::Update** の場合、ゲーム ループを反復するごとに **Active** から 1 回呼び出されます。
-   **OnSuspending**と**OnResuming**:前者はゲームのオーディオを中断し、後者はこれを再開します。

さらに、次のプライベート メソッドがあります。

-   **LoadSavedState**と**SaveState**:前者はゲームの現在の状態の読み込み、後者はこれを保存します。
-   **SaveHighScore**と**LoadHighScore**:前者はゲーム全体のハイ スコアを読み込み、後者はこれを保存します。
-   **InitializeAmmo**:弾として使われるそれぞれの球体の状態を各ラウンドの最初に元の状態に戻します。
-   **UpdateDynamics**:これは、アニメーションのキャンド ルーチンをはじめ、物理学とコントロール入力に基づいてゲーム オブジェクトをすべて更新するため、重要なメソッドになります。 これが、ゲームを定義するインタラクティビティの中核部分に相当します。 これについては、[ゲームの世界を更新](#update-the-game-world)セクション。

これ以外のパブリック メソッドとして、表示用のアプリ フレームワークにゲーム プレイとオーバーレイ固有の情報を返すプロパティの getter があります。

### <a name="data"></a>データ

コード例の冒頭には、ゲーム ループの実行時にインスタンスが更新される 4 つのオブジェクトがあります。

-   **MoveLookController**オブジェクト。プレイヤーの入力を表します。 詳細については、「[コントロールの追加](tutorial--adding-controls.md)」を参照してください。
-   **GameRenderer**オブジェクト。派生した Direct3D 11 のレンダラーを表す、 **DirectXBase**デバイスに固有のすべてのオブジェクトと、レンダリングを処理するクラスです。 詳細については、次を参照してください。[レンダリングのフレームワークは](tutorial--assembling-the-rendering-pipeline.md)します。
-   **オーディオ**オブジェクト。ゲームのオーディオ再生を制御します。 詳細については、次を参照してください。[サウンドを追加する](tutorial--adding-sound.md)します。

残りのゲーム変数には、プリミティブとゲーム内で対応するプリミティブの量を示すリストと、ゲーム プレイ固有のデータと制約が含まれます。

## <a name="next-steps"></a>次のステップ

ここまでで、興味おそらく実際のレンダリング エンジンに関する: 方法への呼び出し、__レンダリング__更新されたプリミティブをメソッドを取得、画面上のピクセルになっています。 これは 2 つの部分で説明&mdash;[レンダリング framework i:レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)と[レンダリング framework II:ゲームのレンダリング](tutorial-game-rendering.md)します。 またプレーヤー コントロールによってゲーム状態がどのように更新されるのかについては、「[コントロールの追加](tutorial--adding-controls.md)」をご覧ください。
