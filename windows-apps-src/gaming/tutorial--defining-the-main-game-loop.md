---
author: joannaleecy
title: メイン ゲーム オブジェクトの定義
description: ここでは、ゲーム サンプルのメイン オブジェクトの詳細と、実装するルールをゲーム ワールドとの対話式操作に変換する方法について説明します。
ms.assetid: 6afeef84-39d0-cb78-aa2e-2e42aef936c9
ms.author: joanlee
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, メイン オブジェクト
ms.localizationpriority: medium
ms.openlocfilehash: b94d7139f35b3a18edd66af9959a0958d0bdcbc1
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/05/2018
ms.locfileid: "6038473"
---
# <a name="define-the-main-game-object"></a>メイン ゲーム オブジェクトの定義

サンプル ゲームの基本的なフレームワークを紹介し、高度なユーザーとシステムの動作を処理するステート マシンを実装したら、規則と、ゲームにゲームのサンプルを有効にするしくみを確認するされます。 ゲーム ワールドとのやり取りにゲームのルールに変換する方法と、ゲーム サンプルのメイン オブジェクトの詳細を見てみましょう。

>[!Note]
>このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。 このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。 サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。

## <a name="objective"></a>目標

ゲームのルールおよび UWP DirectX ゲームのしくみを実装する基本的な開発手法を適用する方法について説明します。

## <a name="main-game-object"></a>メイン ゲーム オブジェクト

このサンプル ゲームでは、 __Simple3DGame__は、メイン ゲーム オブジェクト クラスです。 __App::load__メソッドでは、 __Simple3DGame__オブジェクトのインスタンスが構築されます。

__Simple3DGame__クラス オブジェクト。
* ゲームプレイのロジックの実装を指定します。
* 通信メソッドが含まれています。
    * アプリのフレームワークで定義されたステート マシンにゲーム状態の変化します。
    * ゲーム オブジェクト自体をアプリからゲームの状態の変化します。
    * ゲームの UI (オーバーレイとヘッドアップ ディスプレイ)、アニメーション、および物理学 (力学) を更新するための説明します。

    >[!Note]
    >グラフィックスの更新は取得し、ゲームで使用されるグラフィックス デバイス リソースを使用するメソッドが含まれている__GameRenderer__クラスによって処理されます。 詳しくは、[レンダリング フレームワーク i: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)をご覧ください。

* 大まかに言うゲームの定義方法に応じて、有効期間またはレベルでゲームのセッションを定義するデータのコンテナーとして機能します。 この例では、ゲームの状態データは、ゲームの有効期間はされ、ユーザーがゲームを起動するときに 1 回が初期化されます。

メソッドとをこのクラスのオブジェクトで定義されているデータを表示するには、 [Simple3DGame オブジェクト](#simple3dgame-object)に移動します。

## <a name="initialize-and-start-the-game"></a>初期化し、ゲームを開始します。

プレーヤーがゲームを開始すると、ゲーム オブジェクトはその状態を初期化し、オーバーレイの作成と追加を行い、プレーヤーのパフォーマンスを追跡する変数を設定して、レベルの構築時に使うオブジェクトをインスタンス化する必要があります。 このサンプルでは、このに[__app::load__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L115-L123)で新しい__GameMain__インスタンスが作成される行われます。 

__GameMain__コンス トラクターで、 __Simple3DGame__、ゲーム オブジェクトが作成されます。 その後、[非同期__GameMain__コンス トラクターでタスクの作成](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L65-L74)中に[__Simple3DGame::Initialize__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L54-L250)メソッドを使用してを初期化します。

### <a name="simple3dgameinitialize-method"></a>Simple3DGame::Initialize メソッド

このゲーム サンプルは、ゲーム オブジェクトで、次のコンポーネントを設定します。

* 新規のオーディオ再生オブジェクトを作成します。
* 一連のレベル プリミティブ、弾薬、障害物を含む、ゲームのグラフィック プリミティブの配列を作成します。
* ゲーム状態データを保存する場所を作成し、*Game* という名前を付け、[**ApplicationData::Current**](https://msdn.microsoft.com/library/windows/apps/br241619) で指定するアプリ データ設定ストレージの場所に格納します。
* ゲーム タイマーと初期ゲーム内オーバーレイ ビットマップを作成します。
* 具体的なビュー パラメーターとプロジェクション パラメーター セットを使って新規のカメラを作成します。
* プレーヤーがコントロール開始位置とカメラ位置の 1 対 1 の対応を確保されるように、入力デバイス (コントローラー) をカメラと同じ位置に上下と左右の開始位置を設定します。
* プレーヤー オブジェクトを作成し、アクティブに設定します。 球体を使用して、プレイヤーのまでの近さ壁や障害物を検出して、カメラが没入を阻害する位置に配置を取得することを防ぐ。
* ゲーム ワールド プリミティブを作成します。
* 円筒形の障害物を作成します。
* 標的 (**Face** オブジェクト) を作成し、番号を付けます。
* 弾薬の球体を作成します。
* レベルを作成します。
* ハイ スコアを読み込みます。
* 以前に保存されたゲーム状態を読み込みます。

ゲームには既に、ワールド、プレーヤー、障害物、標的、弾薬の球体の主要コンポーネントのインスタンスが存在します。 これらの全コンポーネントの設定と個々の固有レベルに対する動作を表すレベルのインスタンスもあります。 ゲームでどのようにレベルが構築されるのかを見てみます。

## <a name="build-and-load-game-levels"></a>ビルドして、ゲームのレベルを読み込む

レベルの構築を面倒な作業のほとんどは、サンプル ソリューションの__GameLevels__フォルダーにある__Level.h/.cpp__ファイルで行われます。 非常に特定の実装に重点を置いています、ためしますは説明しませんに次にします。 重要な点は、各レベルのコードがそれぞれ個別の __LevelN__ オブジェクトとして実行されるということです。 ゲームを拡張したい場合は、**レベル**のオブジェクトを受け取り、割り当てられている数字をパラメーターとして、障害物、標的を無作為に配置を作成できます。 または、リソース ファイル、またはインターネットからレベルの構成データを読み込むことができます。

## <a name="define-the-game-play"></a>ゲーム プレイを定義します。

この時点でゲームのアセンブルに必要なコンポーネントがすべて揃います。 レベルは、中、プリミティブからメモリに構築されているし、プレイヤーにやり取りを開始する準備ができました。

この最適なゲームでは、プレイヤーの入力に即座に反応や、瞬時のフィードバックを提供します。 これは、トゥイッチ アクションやリアルタイムの主観ガン、ターン制の戦略ゲームからすべての種類のゲームの場合は true。

### <a name="simple3dgamerungame-method"></a>Simple3DGame::RunGame メソッド

レベルを再生するには、ゲームが__Dynamics__の状態です。 

[__お__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329)では、次に示すように、フレームごとに 1 回、アプリケーションの状態を更新する更新プログラムのメイン ループです。 更新ループで、ゲームが__Dynamics__の状態にある場合は、作業を処理する[__Simple3DGame::RunGame__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)メソッドを呼び出します。

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
          
[__Simple3DGame::RunGame__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)では、ゲーム ループの現在の反復でのゲーム プレイの現在の状態を定義するデータのセットを処理します。

ゲームのフロー ロジック__RunGame__:
*  メソッドは、レベルが終了するまでの間、残り時間を秒数でカウント ダウンするタイマーを更新し、レベルの時間が過ぎていないかをテストします。 これは、ゲームのルールの 1 つ: 時間切れ、すべてのターゲットが撮影されていないときは、ゲーム オーバーします。
*  時間切れになると、メソッドは **TimeExpired** ゲーム状態を設定し、前のコードの **Update** メソッドに戻ります。
*  時間が残っている場合は、ムーブ/ルック コントローラーがポーリングを行って、カメラ位置に更新がないかどうかを確認します。具体的には、カメラ平面 (プレーヤーが見ている面) の延長上にあるビュー法線の角度や、前回のコントローラーのポーリング時からの角度の移動距離が更新されていないかどうかを確認します。
*  カメラは、ムーブ/ルック コントローラーから送られる新しいデータに従って更新されます。
*  ダイナミクス、つまりプレーヤーのコントロールからは独立したゲーム ワールド中のオブジェクトのアニメーションや動作が更新されます。 このゲーム サンプルで[__UpdateDynamics()__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856)メソッドが呼び出されてが起動されている弾薬の球体の動き、柱の障害物のアニメーションとターゲットの動きを更新します。 詳細については、[ゲーム ワールドの更新](#update-the-game-world)を参照してください。
*  メソッドが、レベルの正常な完了に関する基準が満たされているかどうかをチェックします。 満たされていれば、レベルのスコアをファイナライズし、これが最後のレベル (全 6 レベル) であるかどうかを判断します。 最後のレベルであれば、**GameComplete** ゲーム状態を返します。そうでない場合は、__LevelComplete__ ゲーム状態を返します。
*  レベルが完了していない場合は、ゲーム状態を __Active__ に設定し、戻ります。

## <a name="update-the-game-world"></a>ゲーム ワールドを更新します。

このサンプルでゲームが実行されているとき、 [__Simple3DGame::UpdateDynamics()__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856)メソッドが呼び出されて ([__お__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329)から呼び出される) [__Simple3DGame::RunGame__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)メソッドからゲームのシーンをレンダリングするオブジェクトを更新します。

__UpdateDynamics__ループで、モーション、プレイヤーの独立したゲーム ワールドの設定に使用されるメソッドの呼び出し入力、イマーシブなゲーム エクスペリエンスを作成および*始め*、レベルを調整します。 これは、グラフィックス レンダリングする必要があると実行中のアニメーションは、プレイヤーの入力がない場合でも、ワールドを息生きた実現するためにループします。 たとえば、ツリーで wind、まきが風になびき、波禁煙区域など、エイリアンの怪物伸縮と動き回るに沿って cresting 生まれました。 また、プレーヤーの球体とワールドの間、または弾薬、障害物、標的の間に生じる衝突を含め、物体どうしの相互作用も統合されます。

ゲーム ループが常に物理アルゴリズムは、ゲームのロジックに基づいているかどうか、または単かどうか、ゲーム ワールドの更新を除くと、ゲームが一時停止具体的には、ランダムな維持します。 

ゲーム サンプルでは、この原理のことを*ダイナミクス*と呼んでいます。これにより、柱の障害物の上下の動き、発砲時に見られる弾薬の球体の動きや物理的動作が統合されます。 

### <a name="simple3dgameupdatedynamics-method"></a>Simple3DGame::UpdateDynamics メソッド 

このメソッドは、次の 4 種類の計算を行います。

* ワールドで発砲された弾薬の球体の位置
* 柱の障害物のアニメーション
* プレーヤーとワールドの境界の交差部分
* 弾薬の球体と、障害物、標的、他の弾薬球体、ワールドとの衝突

障害物のアニメーションは、**Animate.h/.cpp** で定義されたループとして実行されます。 弾薬と衝突の動作が簡略化した物理アルゴリズムで定義されているコードで指定された、一連の重力や素材のプロパティも含め、ゲーム ワールドのグローバル定数によってパラメーター化します。 これはすべて、ゲーム ワールドの座標空間で計算されます。

### <a name="review-the-flow"></a>フローを確認します。

これでシーン内のすべてのオブジェクトが更新され、すべての衝突が計算した、この情報を使用して、対応する視覚的な変更を描画する必要があります。 

__GameMain::Update()__ には、ゲーム ループの現在の反復処理が完了すると、サンプルはすぐに更新されたオブジェクトのデータを取得し、次のように、プレイヤーに表示する新しいシーンを生成__Render()__ を呼び出します。 次に、レンダリングを見てみましょう。

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

## <a name="render-the-game-worlds-graphics"></a>ゲーム ワールドのグラフィックスをレンダリングします。

ゲーム中のグラフィックスはできるだけ頻繁 (最大ではメインのゲーム ループが反復するごと) に更新することをお勧めします。 ループが反復するごとに、プレーヤーからの入力の有無を問わず、ゲームを更新します。 これにより、計算するアニメーションと動作がスムーズに表示されるようになります。 たとえば、プレーヤーがボタンを押したときにのみ、水が流れるという単純なシーンを思い浮かべてください。 ひどくつまらないビジュアルになるでしょう。 優れたゲームは、流れるような自然の動きを伴うものです。

[__Gamemain::run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L143-L202)で上記のように、サンプル ゲームのループを思い出してください。 ゲームのメイン ウィンドウが表示されていて、スナップされたり、非アクティブにされたりしなければ、ゲームはそのまま、その更新結果の更新とレンダリングを続けます。 いるを調べること[__Render__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameRenderer.cpp#L474-L624)メソッドは、今すぐの状態を表すをレンダリングします。 これは、**更新**、 **RunGame**状態を更新する前のセクションで説明したが含まれているへの呼び出しの直後にします。

このメソッドではまず 3D ワールドのプロジェクションが描画され、続いてその上に Direct2D オーバーレイが描画されます。 描画が完了すると、表示用に結合されたバッファーとともに最終的なスワップ チェーンが表示されます。

>[!Note]
>サンプル ゲームの Direct2D オーバーレイの 2 つの状態: いずれかのゲームが一時停止メニューで、もう 1 つのゲームのムーブ/ルックのタッチ スクリーン用の四角形と共に十字表示位置のビットマップが含まれているゲーム情報オーバーレイを表示コント ローラー。 両方の状態でスコア テキストが描画されます。 詳細については、「[レンダリング フレームワーク I: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)」を参照してください。

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

これらは、メソッドと__Simple3DGame__オブジェクトのクラスで定義されているデータです。

### <a name="methods"></a>メソッド

**Simple3DGame**で定義した内部メソッドは次のとおりです。

-   **初期化**: グローバル変数の開始値を設定し、ゲーム オブジェクトを初期化します。 これは、セクションで説明[を初期化しゲームを開始](#initialize-and-start-the-game)します。
-   **LoadGame**: 新しいレベルを初期化し、読み込みを開始します。
-   **LoadLevelAsync**: 非同期タスクを開始 (非同期タスクに慣れていない場合は[並列パターン ライブラリ](https://docs.microsoft.com/cpp/parallel/concrt/parallel-patterns-library-ppl)を参照)、レベルを初期化してから、レンダラーでデバイス固有のレベルのリソースの読み込みを非同期タスクを呼び出します。 このメソッドは独立したスレッドで実行されます。そのため、このスレッドから呼び出すことができるのは [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) メソッドだけです ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) メソッドは呼び出されません)。 デバイス コンテキストのメソッドは、**FinalizeLoadLevel** メソッドで呼び出されます。
-   **FinalizeLoadLevel**: メイン スレッドで実行する必要があるレベル読み込みの作業を完了します。 これには、Direct3D 11 のデバイス コンテキスト ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)) のメソッドの呼び出しが含まれます。
-   **StartLevel**: 新しいレベルでゲームのプレイを開始します。
-   **PauseGame**: ゲームを一時停止します。
-   **RunGame**: ゲーム ループの反復を実行します。 ゲームの状態が **App::Update** の場合、ゲーム ループを反復するごとに **Active** から 1 回呼び出されます。
-   **OnSuspending**と**OnResuming**: 一時停止し、それぞれ、ゲームのオーディオを再開します。

さらに、次のプライベート メソッドがあります。

-   **LoadSavedState**と**SaveState**: 読み込みし、それぞれ、ゲームの現在の状態を保存します。
-   **SaveHighScore**と**LoadHighScore**: を保存し、それぞれ、ゲーム全体のハイ スコアを読み込みます。
-   **InitializeAmmo**: 各ラウンドの最初の元の状態に戻す弾として使われるそれぞれの球体の状態にリセットします。
-   **UpdateDynamics**: これは、アニメーションのキャンド ルーチンをはじめ、物理学とコントロール入力に基づいてゲーム オブジェクトをすべて更新するための重要な方法です。 これが、ゲームを定義するインタラクティビティの中核部分に相当します。 これについては、[ゲーム ワールドの更新](#update-the-game-world)のセクションで説明します。

これ以外のパブリック メソッドとして、表示用のアプリ フレームワークにゲーム プレイとオーバーレイ固有の情報を返すプロパティの getter があります。

### <a name="data"></a>データ

コード例の冒頭には、ゲーム ループの実行時にインスタンスが更新される 4 つのオブジェクトがあります。

-   **MoveLookController**オブジェクト: プレイヤーの入力を表します。 詳細については、「[コントロールの追加](tutorial--adding-controls.md)」を参照してください。
-   **GameRenderer**オブジェクト: direct3d11 のレンダラー クラスから派生した**DirectXBase**デバイスに固有のすべてのオブジェクトとそのレンダリング処理を表します。 詳細については、次を参照してください。[レンダリング フレームワーク I](tutorial--assembling-the-rendering-pipeline.md)します。
-   **オーディオ**オブジェクト: ゲームのオーディオの再生を制御します。 詳細については、[サウンドの追加](tutorial--adding-sound.md)を参照してください。

残りのゲーム変数には、プリミティブとゲーム内で対応するプリミティブの量を示すリストと、ゲーム プレイ固有のデータと制約が含まれます。

## <a name="next-steps"></a>次のステップ

ここでは、実際のレンダリング エンジンに興味がおそらく場合: 画面上、更新されたプリミティブの__レンダリング__メソッドを呼び出すをピクセルに変換を取得する方法。 これは 2 つの部分で説明&mdash;[レンダリング フレームワーク i: レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)と[レンダリング フレームワーク II: ゲームのレンダリング](tutorial-game-rendering.md)します。 またプレーヤー コントロールによってゲーム状態がどのように更新されるのかについては、「[コントロールの追加](tutorial--adding-controls.md)」をご覧ください。
