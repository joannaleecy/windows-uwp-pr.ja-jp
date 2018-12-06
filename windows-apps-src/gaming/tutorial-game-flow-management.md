---
title: ゲームのフロー管理
description: ゲームの状態の初期化、イベントの処理、ゲームの更新ループのセットアップの方法について説明します。
ms.assetid: 6c33bf09-b46a-4bb5-8a59-ca83ce257eb3
ms.date: 10/24/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, DirectX
ms.localizationpriority: medium
ms.openlocfilehash: c6d13b848a9e5d2dfc145431f732187c35c46ab6
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8757063"
---
# <a name="game-flow-management"></a><span data-ttu-id="809f1-104">ゲームのフロー管理</span><span class="sxs-lookup"><span data-stu-id="809f1-104">Game flow management</span></span>

<span data-ttu-id="809f1-105">ゲームは、ウィンドウを持ち、いくつかのイベント ハンドラーを登録し、アセットを非同期的に読み込むようになりました。</span><span class="sxs-lookup"><span data-stu-id="809f1-105">The game now has a window, registered a couple event handlers, and loads assets asynchronously.</span></span> <span data-ttu-id="809f1-106">このセクションでは、ゲームの状態の使用方法、特定の主要なゲーム状態を管理する方法、ゲーム エンジンの更新ループを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="809f1-106">This section explains about the use of game states, how to manage specific key game states, and how to create an update loop for the game engine.</span></span> <span data-ttu-id="809f1-107">次に、ユーザー インターフェイスのフローについて学習し、最後に、UWP ゲームに必要なイベント ハンドラーとイベントについての理解を深めます。</span><span class="sxs-lookup"><span data-stu-id="809f1-107">Then we'll learn about the user interface flow and finally, understand more about event handlers and events that are needed for a UWP game.</span></span>

>[!Note]
><span data-ttu-id="809f1-108">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="809f1-108">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="809f1-109">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="809f1-109">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="809f1-110">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="809f1-110">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="game-states-used-to-manage-game-flow"></a><span data-ttu-id="809f1-111">ゲームのフローを管理するために使用するゲームの状態</span><span class="sxs-lookup"><span data-stu-id="809f1-111">Game states used to manage game flow</span></span>

<span data-ttu-id="809f1-112">ゲームのフローを管理するには、ゲームの状態を使用します。</span><span class="sxs-lookup"><span data-stu-id="809f1-112">We make use of game states to manage the flow of the game.</span></span> <span data-ttu-id="809f1-113">ユーザーは UWP ゲーム アプリを中断状態からいつでも再開できるため、アプリが置かれる可能性のある状態は任意に設定できます。</span><span class="sxs-lookup"><span data-stu-id="809f1-113">Your game can have any number of possible states because a user can resume a UWP game app from a suspended state at any time.</span></span>

<span data-ttu-id="809f1-114">このゲーム サンプルの場合、ゲームの開始時に、次の 3 つのいずれかの状態になります。</span><span class="sxs-lookup"><span data-stu-id="809f1-114">For this game sample, it can be in one of the three states when it starts:</span></span>
* <span data-ttu-id="809f1-115">ゲーム ループが実行中で、いずれかのレベル中の状態。</span><span class="sxs-lookup"><span data-stu-id="809f1-115">The game loop is running and is in the middle of a level.</span></span>
* <span data-ttu-id="809f1-116">ゲームがちょうど完了したため、ゲーム ループが実行されていない状態。</span><span class="sxs-lookup"><span data-stu-id="809f1-116">The game loop is not running because a game had just been completed.</span></span> <span data-ttu-id="809f1-117">(ハイ スコアが設定されます)</span><span class="sxs-lookup"><span data-stu-id="809f1-117">(The high score is set)</span></span>
* <span data-ttu-id="809f1-118">ゲームが開始されていないか、ゲームが 2 つのレベルの中間にある状態。</span><span class="sxs-lookup"><span data-stu-id="809f1-118">No game has been started, or the game is between levels.</span></span> <span data-ttu-id="809f1-119">(ハイ スコアは 0)</span><span class="sxs-lookup"><span data-stu-id="809f1-119">(The high score is 0)</span></span>

<span data-ttu-id="809f1-120">ゲームのニーズに応じて必要なの数の状態を定義することができます。</span><span class="sxs-lookup"><span data-stu-id="809f1-120">You can have define the number of states required depending on your game's needs.</span></span> <span data-ttu-id="809f1-121">繰り返しますが、UWP ゲームはいつでも終了できるため、プレイヤーは再開時に、ゲームをまったく停止していなかったかのようにゲームが動作すると期待することを覚えておいてください。</span><span class="sxs-lookup"><span data-stu-id="809f1-121">Again, be aware that your UWP game can be terminated at any time, and when it resumes, the player expects the game to behave as though they had never stopped playing.</span></span>

## <a name="game-states-initialization"></a><span data-ttu-id="809f1-122">ゲームの状態の初期化</span><span class="sxs-lookup"><span data-stu-id="809f1-122">Game states initialization</span></span>

<span data-ttu-id="809f1-123">ゲームの初期化では、ゲームのコールド スタートだけでなく、一時停止または終了後の再開も考慮します。</span><span class="sxs-lookup"><span data-stu-id="809f1-123">In game initialization, you are not just focused on cold starting the game but also restarting after it has been paused or terminated.</span></span> <span data-ttu-id="809f1-124">サンプル ゲームではゲームの状態が常に保存されるので、アプリの実行が継続しているように見えます。</span><span class="sxs-lookup"><span data-stu-id="809f1-124">The sample game always saves the game state giving it the appearance that it has stayed running.</span></span> 

<span data-ttu-id="809f1-125">中断状態では、ゲーム プレイは中断されますが、ゲームのリソースはメモリに残されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-125">In a suspended state, game play is suspended but the resources of the game are still in memory.</span></span> 

<span data-ttu-id="809f1-126">同様に、再開イベントでは、サンプル ゲームが前回中断または終了された時点から再開されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-126">Likewise, the resume event is to ensure that the sample game picks up where it was last suspended or terminated.</span></span> <span data-ttu-id="809f1-127">サンプル ゲームが終了後に再起動されると、通常どおり開始され、その後、最後の既知の状態が判断されるため、プレーヤーはゲームの続きを即座に続行できます。</span><span class="sxs-lookup"><span data-stu-id="809f1-127">When the sample game restarts after termination, it starts up normally and then determines the last known state so the player can immediately continue playing.</span></span>

<span data-ttu-id="809f1-128">状態に応じて、異なるオプションがプレイヤーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-128">Depending on the state, different options are presented to the player.</span></span> 

* <span data-ttu-id="809f1-129">ゲームは、2 つのレベルの中間から再開された場合、一時停止しているように見え、オーバーレイで続行オプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-129">If the game resumes mid-level, it appears as paused, and the overlay presents a continue option.</span></span>
* <span data-ttu-id="809f1-130">また、完了状態から再開された場合は、ハイ スコアと、新しいゲームを開始するオプションが表示されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-130">If the game resumes in a state where the game is completed, it displays the high scores and an option to play a new game.</span></span>
* <span data-ttu-id="809f1-131">そして、いずれかのレベルが開始される前にゲームが再開された場合は、オーバーレイで開始オプションがユーザーに表示されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-131">Lastly, if the game resumes before a level has started, the overlay presents a start option to the user.</span></span>

<span data-ttu-id="809f1-132">このゲーム サンプルでは、ゲームのコールド スタート、中断イベントがない状態での初めての起動、ゲームの中断状態からの再開を区別していません。</span><span class="sxs-lookup"><span data-stu-id="809f1-132">The game sample doesn't distinguish whether the game is cold starting, launching for the first time without a suspend event, or resuming from a suspended state.</span></span> <span data-ttu-id="809f1-133">これは、どの UWP アプリにも適切な設計です。</span><span class="sxs-lookup"><span data-stu-id="809f1-133">This is the proper design for any UWP app.</span></span>

<span data-ttu-id="809f1-134">このサンプルでは、[__GameMain::InitializeGameState__](#gamemaininitializegamestate-method) でゲームの状態の初期化が行われます。</span><span class="sxs-lookup"><span data-stu-id="809f1-134">In this sample, initialization of the game states occurs in [__GameMain::InitializeGameState__](#gamemaininitializegamestate-method).</span></span>

<span data-ttu-id="809f1-135">このフローを視覚化するためのフローチャートを以下に示します。これは、初期化と更新ループの両方を示しています。</span><span class="sxs-lookup"><span data-stu-id="809f1-135">This is a flowchart to help you visualize the flow, it covers both initialization and the update loop.</span></span>

* <span data-ttu-id="809f1-136">初期化は、__Start__ ノードから始まり、現在のゲームの状態をチェックします。</span><span class="sxs-lookup"><span data-stu-id="809f1-136">Initialization begins at the __Start__ node when you check for the current game state.</span></span> <span data-ttu-id="809f1-137">ゲームのコードについては、[__GameMain::InitializeGameState__](#gamemaininitializegamestate-method) の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="809f1-137">For game code, go to [__GameMain::InitializeGameState__](#gamemaininitializegamestate-method).</span></span>
* <span data-ttu-id="809f1-138">更新ループについて詳しくは、「[ゲーム エンジンを更新する](#update-game-engine)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="809f1-138">For more info about the update loop, go to [Update game engine](#update-game-engine).</span></span> <span data-ttu-id="809f1-139">ゲームのコードについては、[__App::Update__](#appupdate-method) の説明をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="809f1-139">For game code, go to [__App::Update__](#appupdate-method).</span></span>

![ゲームのメイン ステート マシン](images/simple-dx-game-flow-statemachine.png)

### <a name="gamemaininitializegamestate-method"></a><span data-ttu-id="809f1-141">GameMain::InitializeGameState メソッド</span><span class="sxs-lookup"><span data-stu-id="809f1-141">GameMain::InitializeGameState method</span></span>

<span data-ttu-id="809f1-142">__InitializeGameState__ メソッドは、[__GameMain__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L32-L131) コンストラクター クラスから呼び出されます。このコンストラクターは、[__App::Load__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L115-L123) メソッドで __GameMain__ クラスのオブジェクトが作成されるときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-142">The __InitializeGameState__ method is called from the [__GameMain__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L32-L131) constructor class, which is called when the  __GameMain__ class object is created in the [__App::Load__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L115-L123) method.</span></span>

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

## <a name="update-game-engine"></a><span data-ttu-id="809f1-143">ゲーム エンジンを更新する</span><span class="sxs-lookup"><span data-stu-id="809f1-143">Update game engine</span></span>

<span data-ttu-id="809f1-144">[__App::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L127-L130) メソッドで、[__GameMain::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L143-L202) を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="809f1-144">In the [__App::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L127-L130) method, it calls [__GameMain::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L143-L202).</span></span> <span data-ttu-id="809f1-145">このサンプルでは、このメソッド内に、プレイヤーが実行できる主な操作すべてを処理する基本的なステート マシンを実装しています。</span><span class="sxs-lookup"><span data-stu-id="809f1-145">Within this method, the sample has implemented a basic state machine for handling all the major actions the player can take.</span></span> <span data-ttu-id="809f1-146">このステート マシンの最上位レベルは、ゲームの読み込み、特定のレベルのゲーム プレイ、ゲームが (システムあるいはプレーヤーによって) 一時停止された後のレベルの続行を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-146">The highest level of this state machine deals with loading a game, playing a specific level, or continuing a level after the game has been paused (by the system or the player).</span></span>

<span data-ttu-id="809f1-147">このゲーム サンプルには、ゲームの主な状態 (__UpdateEngineState__) として次の 3 つがあります。</span><span class="sxs-lookup"><span data-stu-id="809f1-147">In the game sample, there are 3 major states (__UpdateEngineState__) the game can be:</span></span>

1. <span data-ttu-id="809f1-148">__Waiting for resources__: ゲーム ループが循環していて、リソース (具体的にはグラフィックス リソース) が使用可能になるまで、移行できません。</span><span class="sxs-lookup"><span data-stu-id="809f1-148">__Waiting for resources__: The game loop is cycling, unable to transition until resources (specifically graphics resources) are available.</span></span> <span data-ttu-id="809f1-149">リソースを読み込む非同期タスクが完了すると、状態が __ResourcesLoaded__ に更新されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-149">When the async tasks for loading resources completes, it updates the state to __ResourcesLoaded__.</span></span> <span data-ttu-id="809f1-150">これは通常、2 つのレベルの中間で発生します。レベルの中間では、新しいリソースをディスク、ゲーム サーバー、クラウド バックエンドから読み込みます。</span><span class="sxs-lookup"><span data-stu-id="809f1-150">This usually happens between levels when the level is loading new resources from disk, game server, or cloud backend.</span></span> <span data-ttu-id="809f1-151">このゲーム サンプルでは、その時点ではレベルごとに追加のリソースは必要ないため、この動作はシミュレートされます。</span><span class="sxs-lookup"><span data-stu-id="809f1-151">In the game sample, we simulate this behavior because the sample doesn't need any additional per-level resources at that time.</span></span>
2. <span data-ttu-id="809f1-152">__Waiting for press__: ゲーム ループが循環していて、特定のユーザー入力を待機しています。</span><span class="sxs-lookup"><span data-stu-id="809f1-152">__Waiting for press__: The game loop is cycling, waiting for specific user input.</span></span> <span data-ttu-id="809f1-153">この入力は、プレイヤーによるゲームの読み込み、レベルの開始、またはレベルの続行の操作です。</span><span class="sxs-lookup"><span data-stu-id="809f1-153">This input is a player action to load a game, start a level, or continue a level.</span></span> <span data-ttu-id="809f1-154">サンプル コードでは、これらの下位状態として、__PressResultState__ 列挙値を使っています。</span><span class="sxs-lookup"><span data-stu-id="809f1-154">The sample code refers to these sub-states as __PressResultState__ enumeration values.</span></span>
3. <span data-ttu-id="809f1-155">__Dynamics__: ゲーム ループが実行中で、ユーザーがプレイしています。</span><span class="sxs-lookup"><span data-stu-id="809f1-155">In __Dynamics__: The game loop is running with the user playing.</span></span> <span data-ttu-id="809f1-156">ユーザーがプレイ中に、ゲームは移行できる 3 つの条件をチェックします。</span><span class="sxs-lookup"><span data-stu-id="809f1-156">While the user is playing, the game checks for 3 conditions that it can transition on:</span></span> 
    * <span data-ttu-id="809f1-157">__TimeExpired__: レベルに設定されている時間の有効期限</span><span class="sxs-lookup"><span data-stu-id="809f1-157">__TimeExpired__: expiration of the set time for a level</span></span>
    * <span data-ttu-id="809f1-158">__LevelComplete__: プレイヤーによるレベルの完了</span><span class="sxs-lookup"><span data-stu-id="809f1-158">__LevelComplete__: completion of a level by the player</span></span> 
    * <span data-ttu-id="809f1-159">__GameComplete__: プレイヤーによるすべてのレベルの完了</span><span class="sxs-lookup"><span data-stu-id="809f1-159">__GameComplete__: completion of all levels by the player</span></span>

<span data-ttu-id="809f1-160">ゲームは、複数の小さいステート マシンが含まれているステート マシンにすぎません。</span><span class="sxs-lookup"><span data-stu-id="809f1-160">Your game is simply a state machine containing multiple smaller state machines.</span></span> <span data-ttu-id="809f1-161">それぞれの状態は、非常に具体的な条件によって定義されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-161">For each specific state, it must be defined by a very specific criteria.</span></span> <span data-ttu-id="809f1-162">ある状態から別の状態への移行は、ユーザー入力またはシステムによる個々の操作 (グラフィックス リソースの読み込みなど) に基づいて行われる必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-162">How it transitions from one state to another must be based on discrete user input or system actions (such as graphics resource loading).</span></span> <span data-ttu-id="809f1-163">ゲームの計画時に、ユーザーやシステムが実行すると考えられるすべての操作に確実に対応できるように、ゲーム フローの全体像を詳細に計画することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="809f1-163">While planning for your game, consider drawing out the entire game flow, to ensure that you've addressed all possible actions the user or the system can take.</span></span> <span data-ttu-id="809f1-164">ゲームは非常に複雑な場合があり、ステート マシンは、この複雑さを視覚化して扱いやすくする強力なツールです。</span><span class="sxs-lookup"><span data-stu-id="809f1-164">Games can be very complicated so a state machine is a powerful tool to help visualize this complexity and make it more manageable.</span></span>

<span data-ttu-id="809f1-165">次に、更新ループのコードを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="809f1-165">Let's take a look at the codes for the update loop below.</span></span>

### <a name="appupdate-method"></a><span data-ttu-id="809f1-166">App::Update メソッド</span><span class="sxs-lookup"><span data-stu-id="809f1-166">App::Update method</span></span>

<span data-ttu-id="809f1-167">ゲーム エンジンの更新に使われるステート マシンの構造</span><span class="sxs-lookup"><span data-stu-id="809f1-167">The structure of the state machine used to update the game engine</span></span>

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

## <a name="update-user-interface"></a><span data-ttu-id="809f1-168">ユーザー インターフェイスを更新する</span><span class="sxs-lookup"><span data-stu-id="809f1-168">Update user interface</span></span>

<span data-ttu-id="809f1-169">プレイヤーには、システムの状態を継続的に通知して、プレイヤーの操作とゲームを定義するルールに応じて、ゲームの状態を変更できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-169">We need to keep the player apprised of the state of the system, and allow the game state to change depending on the player's actions and the rules that define the game.</span></span> <span data-ttu-id="809f1-170">このゲームのサンプルを含む多くのゲームは、通常、ユーザー インターフェイス (UI) を使用して、プレイヤーにこの情報を表示します。</span><span class="sxs-lookup"><span data-stu-id="809f1-170">Many games, including this game sample, commonly use user interface (UI) elements to present this info to the player.</span></span> <span data-ttu-id="809f1-171">UI には、ゲームの状態や、スコア、弾薬、残りのチャンスの数などのプレイ固有の情報が表されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-171">The UI contains representations of game state, and other play-specific info such as score, or ammo, or the number of chances remaining.</span></span> <span data-ttu-id="809f1-172">UI はオーバーレイとも呼ばれます。メインのグラフィックス パイプラインとは別にレンダリングされ、3D プロジェクションの上に配置されるためです。</span><span class="sxs-lookup"><span data-stu-id="809f1-172">UI is also called the overlay because it is rendered separately from the main graphics pipeline and placed on top the 3D projection.</span></span> <span data-ttu-id="809f1-173">一部の UI の情報は、ヘッドアップ ディスプレイ (HUD) としても表示され、ユーザーはゲームプレイのメイン領域から視線を移動することなく、これらの情報を把握できます。</span><span class="sxs-lookup"><span data-stu-id="809f1-173">Some UI info is also presented as a heads-up display (HUD) to allow users to get these info without taking their eyes off the main gameplay area.</span></span> <span data-ttu-id="809f1-174">このサンプル ゲームでは、このオーバーレイを Direct2D API を使って作成しています。</span><span class="sxs-lookup"><span data-stu-id="809f1-174">In the sample game, we create this overlay using the Direct2D APIs.</span></span> <span data-ttu-id="809f1-175">このオーバーレイは、XAML を使って作成することもできます。これについては、「[ゲーム サンプルの紹介](tutorial-resources.md)」で説明します。</span><span class="sxs-lookup"><span data-stu-id="809f1-175">We can also create this overlay using XAML, which we discuss in [Extending the game sample](tutorial-resources.md).</span></span>

<span data-ttu-id="809f1-176">ユーザー インターフェイスには次の 2 つのコンポーネントがあります。</span><span class="sxs-lookup"><span data-stu-id="809f1-176">There are two components to the user interface:</span></span>

-   <span data-ttu-id="809f1-177">スコアとゲーム プレイの現在の状態に関する情報が含まれている HUD。</span><span class="sxs-lookup"><span data-stu-id="809f1-177">The HUD that contains the score and info about the current state of game play.</span></span>
-   <span data-ttu-id="809f1-178">一時停止ビットマップ。これは、ゲームの一時停止/中断状態中にテキストがオーバーレイされる黒の四角形です。</span><span class="sxs-lookup"><span data-stu-id="809f1-178">The pause bitmap, which is a black rectangle with text overlaid during the paused/suspended state of the game.</span></span> <span data-ttu-id="809f1-179">これがゲーム オーバーレイです。</span><span class="sxs-lookup"><span data-stu-id="809f1-179">This is the game overlay.</span></span> <span data-ttu-id="809f1-180">これについては、「[ユーザー インターフェイスの追加](tutorial--adding-a-user-interface.md)」で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="809f1-180">We discuss it further in [Adding a user interface](tutorial--adding-a-user-interface.md).</span></span>

<span data-ttu-id="809f1-181">当然のことながら、オーバーレイにもステート マシンがあります。</span><span class="sxs-lookup"><span data-stu-id="809f1-181">Unsurprisingly, the overlay has a state machine too.</span></span> <span data-ttu-id="809f1-182">オーバーレイは、レベル開始またはゲーム オーバーのメッセージを表示できます。</span><span class="sxs-lookup"><span data-stu-id="809f1-182">The overlay can display a level start or game over message.</span></span> <span data-ttu-id="809f1-183">これは、ゲームが一時停止または中断されたときに、プレーヤーに表示する必要があるゲームの状態に関する情報を出力するキャンバスのように機能します。</span><span class="sxs-lookup"><span data-stu-id="809f1-183">It is essentially a canvas to output any info about game state that we display to the player when the game is paused or suspended.</span></span>

<span data-ttu-id="809f1-184">オーバーレイのレンダリングには、ゲームの状態に応じて、6 つの画面のいずれかを指定できます。</span><span class="sxs-lookup"><span data-stu-id="809f1-184">Overlay rendered can be one of the six screens, depending on the state of the game:</span></span> 
1. <span data-ttu-id="809f1-185">ゲームの開始時のリソースの読み込み画面</span><span class="sxs-lookup"><span data-stu-id="809f1-185">Resources loading screen at the start of the game</span></span>
2. <span data-ttu-id="809f1-186">ゲームのプレイ開始画面</span><span class="sxs-lookup"><span data-stu-id="809f1-186">Game stats play screen</span></span>
3. <span data-ttu-id="809f1-187">レベルの開始メッセージ画面</span><span class="sxs-lookup"><span data-stu-id="809f1-187">Level start message screen</span></span>
4. <span data-ttu-id="809f1-188">時間切れになる前にすべてのレベルが完了した場合のゲーム オーバー画面</span><span class="sxs-lookup"><span data-stu-id="809f1-188">Game over screen when all of the levels are completed without time running out</span></span>
5. <span data-ttu-id="809f1-189">時間切れになった場合のゲーム オーバー画面</span><span class="sxs-lookup"><span data-stu-id="809f1-189">Game over screen when time runs out</span></span>
6. <span data-ttu-id="809f1-190">一時停止メニュー画面</span><span class="sxs-lookup"><span data-stu-id="809f1-190">Pause menu screen</span></span>

<span data-ttu-id="809f1-191">ユーザー インターフェイスをゲームのグラフィックス パイプラインから分離すると、ゲームのグラフィックス レンダリング エンジンとは別に操作でき、ゲームのコードの複雑さが大幅に軽減されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-191">Separating your user interface from your game's graphics pipeline allows you to work on it independent of the game's graphics rendering engine and decreases the complexity of your game's code significantly.</span></span>

<span data-ttu-id="809f1-192">このゲーム サンプルでオーバーレイのステート マシンを構成する方法は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="809f1-192">Here's how the game sample structures the overlay's state machine.</span></span>

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

## <a name="events-handling"></a><span data-ttu-id="809f1-193">イベントの処理</span><span class="sxs-lookup"><span data-stu-id="809f1-193">Events handling</span></span>

<span data-ttu-id="809f1-194">サンプル コードでは、特定のイベントに対する多数のハンドラーが App.cpp の **Initialize**、**SetWindow**、**Load** に登録されています。</span><span class="sxs-lookup"><span data-stu-id="809f1-194">Our sample code registered a number of handlers for specific events in **Initialize**, **SetWindow**, and **Load** in the App.cpp.</span></span> <span data-ttu-id="809f1-195">これらは重要なイベントであり、ゲームのしくみを追加したり、グラフィックス開発を開始したりする前に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-195">These are important events that needs to work before we can add game mechanics or start graphics development.</span></span> <span data-ttu-id="809f1-196">これらのイベントは、適切な UWP アプリのエクスペリエンスの基本です。</span><span class="sxs-lookup"><span data-stu-id="809f1-196">These events are fundamental to a proper UWP app experience.</span></span> <span data-ttu-id="809f1-197">UWP アプリはいつでもアクティブ化、非アクティブ化、サイズ変更、スナップ、スナップの解除、中断、再開ができるため、ゲームではこれらのイベント自体をできる限り早く登録し、プレイヤーのエクスペリエンスをスムーズで予測可能な状態に保てる方法で、これらのイベントを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-197">Because a UWP app can be activated, deactivated, resized, snapped, unsnapped, suspended, or resumed at any time, the game must register for these events as soon as it can, and handle them in a way that keeps the experience smooth and predictable for the player.</span></span>

<span data-ttu-id="809f1-198">次の表に、このサンプルで使用されているイベント ハンドラーと、ハンドラーが処理するイベントを示します。</span><span class="sxs-lookup"><span data-stu-id="809f1-198">These are the event handlers used in this sample and the events they handle.</span></span>

<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left"><span data-ttu-id="809f1-199">イベント ハンドラー</span><span class="sxs-lookup"><span data-stu-id="809f1-199">Event handler</span></span></th>
<th align="left"><span data-ttu-id="809f1-200">説明</span><span class="sxs-lookup"><span data-stu-id="809f1-200">Description</span></span></th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><span data-ttu-id="809f1-201">OnActivated</span><span class="sxs-lookup"><span data-stu-id="809f1-201">OnActivated</span></span></td>
<td align="left"><span data-ttu-id="809f1-202"><a href="https://msdn.microsoft.com/library/windows/apps/br225018"><strong>CoreApplicationView::Activated</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-202">Handles <a href="https://msdn.microsoft.com/library/windows/apps/br225018"><strong>CoreApplicationView::Activated</strong></a>.</span></span> <span data-ttu-id="809f1-203">ゲーム アプリがフォアグラウンドに表示されているため、メイン ウィンドウがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-203">The game app has been brought to the foreground, so the main window is activated.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="809f1-204">OnDpiChanged</span><span class="sxs-lookup"><span data-stu-id="809f1-204">OnDpiChanged</span></span></td>
<td align="left"><span data-ttu-id="809f1-205"><a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_DpiChanged"><strong>Graphics::Display::DisplayInformation::DpiChanged</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-205">Handles <a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_DpiChanged"><strong>Graphics::Display::DisplayInformation::DpiChanged</strong></a>.</span></span> <span data-ttu-id="809f1-206">ディスプレイの DPI が変更されていて、それに応じてゲームそのリソースを調整します。</span><span class="sxs-lookup"><span data-stu-id="809f1-206">The DPI of the display has changed and the game adjusts its resources accordingly.</span></span>
<div class="alert"><span data-ttu-id="809f1-207">
<strong>注:</strong>[<strong>CoreWindow</strong>] (https://msdn.microsoft.com/library/windows/desktop/hh404559)座標は、 [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370987)の Dip (デバイスに依存しないピクセル) にします。</span><span class="sxs-lookup"><span data-stu-id="809f1-207">
<strong>Note</strong>[<strong>CoreWindow</strong>](https://msdn.microsoft.com/library/windows/desktop/hh404559) coordinates are in DIPs (Device Independent Pixels) for [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370987).</span></span> <span data-ttu-id="809f1-208">このため、2D アセットまたはプリミティブを正しく表示するには、Direct2D に DPI の変更を通知する必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-208">As a result, you must notify Direct2D of the change in DPI to display any 2D assets or primitives correctly.</span></span>
</div>
<div>
</div></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="809f1-209">OnOrientationChanged</span><span class="sxs-lookup"><span data-stu-id="809f1-209">OnOrientationChanged</span></span></td>
<td align="left"><span data-ttu-id="809f1-210"><a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_OrientationChanged"><strong>Graphics::Display::DisplayInformation::OrientationChanged</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-210">Handles <a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_OrientationChanged"><strong>Graphics::Display::DisplayInformation::OrientationChanged</strong></a>.</span></span> <span data-ttu-id="809f1-211">ディスプレイの向きが変更され、レンダリングを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-211">The orientation of the display changes and rendering needs to be updated.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="809f1-212">OnDisplayContentsInvalidated</span><span class="sxs-lookup"><span data-stu-id="809f1-212">OnDisplayContentsInvalidated</span></span></td>
<td align="left"><span data-ttu-id="809f1-213"><a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_DisplayContentsInvalidated"><strong>Graphics::Display::DisplayInformation::DisplayContentsInvalidated</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-213">Handles <a href="https://docs.microsoft.com/uwp/api/windows.graphics.display.displayinformation#Windows_Graphics_Display_DisplayInformation_DisplayContentsInvalidated"><strong>Graphics::Display::DisplayInformation::DisplayContentsInvalidated</strong></a>.</span></span> <span data-ttu-id="809f1-214">ディスプレイを再描画する必要があり、ゲームをもう一度レンダリングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-214">The display requires redrawing and your game needs to be rendered again.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="809f1-215">OnResuming</span><span class="sxs-lookup"><span data-stu-id="809f1-215">OnResuming</span></span></td>
<td align="left"><span data-ttu-id="809f1-216"><a href="https://msdn.microsoft.com/library/windows/apps/br205859"><strong>CoreApplication::Resuming</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-216">Handles <a href="https://msdn.microsoft.com/library/windows/apps/br205859"><strong>CoreApplication::Resuming</strong></a>.</span></span> <span data-ttu-id="809f1-217">ゲーム アプリがゲームを中断状態から復元します。</span><span class="sxs-lookup"><span data-stu-id="809f1-217">The game app restores the game from a suspended state.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="809f1-218">OnSuspending</span><span class="sxs-lookup"><span data-stu-id="809f1-218">OnSuspending</span></span></td>
<td align="left"><span data-ttu-id="809f1-219"><a href="https://msdn.microsoft.com/library/windows/apps/br205860"><strong>CoreApplication::Suspending</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-219">Handles <a href="https://msdn.microsoft.com/library/windows/apps/br205860"><strong>CoreApplication::Suspending</strong></a>.</span></span> <span data-ttu-id="809f1-220">ゲーム アプリがその状態をディスクに保存します。</span><span class="sxs-lookup"><span data-stu-id="809f1-220">The game app saves its state to disk.</span></span> <span data-ttu-id="809f1-221">ストレージへの状態の保存に使用できる時間は 5 秒です。</span><span class="sxs-lookup"><span data-stu-id="809f1-221">It has 5 seconds to save state to storage.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="809f1-222">OnVisibilityChanged</span><span class="sxs-lookup"><span data-stu-id="809f1-222">OnVisibilityChanged</span></span></td>
<td align="left"><span data-ttu-id="809f1-223"><a href="https://msdn.microsoft.com/library/windows/apps/hh701591"><strong>CoreWindow::VisibilityChanged</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-223">Handles <a href="https://msdn.microsoft.com/library/windows/apps/hh701591"><strong>CoreWindow::VisibilityChanged</strong></a>.</span></span> <span data-ttu-id="809f1-224">ゲーム アプリの表示が切り替わり、表示されるようになったか、別のアプリが表示されたために非表示になったことを示します。</span><span class="sxs-lookup"><span data-stu-id="809f1-224">The game app has changed visibility, and has either become visible or been made invisible by another app becoming visible.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="809f1-225">OnWindowActivationChanged</span><span class="sxs-lookup"><span data-stu-id="809f1-225">OnWindowActivationChanged</span></span></td>
<td align="left"><span data-ttu-id="809f1-226"><a href="https://msdn.microsoft.com/library/windows/apps/br208255"><strong>CoreWindow::Activated</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-226">Handles <a href="https://msdn.microsoft.com/library/windows/apps/br208255"><strong>CoreWindow::Activated</strong></a>.</span></span> <span data-ttu-id="809f1-227">ゲーム アプリのメイン ウィンドウが非アクティブ化またはアクティブ化されたため、フォーカスを動かしてゲームを一時停止するか、フォーカスを再取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="809f1-227">The game app's main window has been deactivated or activated, so it must remove focus and pause the game, or regain focus.</span></span> <span data-ttu-id="809f1-228">どちらの場合も、ゲームが一時停止されていることがオーバーレイに表示されます。</span><span class="sxs-lookup"><span data-stu-id="809f1-228">In both cases, the overlay indicates that the game is paused.</span></span></td>
</tr>
<tr class="odd">
<td align="left"><span data-ttu-id="809f1-229">OnWindowClosed</span><span class="sxs-lookup"><span data-stu-id="809f1-229">OnWindowClosed</span></span></td>
<td align="left"><span data-ttu-id="809f1-230"><a href="https://msdn.microsoft.com/library/windows/apps/br208261"><strong>CoreWindow::Closed</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-230">Handles <a href="https://msdn.microsoft.com/library/windows/apps/br208261"><strong>CoreWindow::Closed</strong></a>.</span></span> <span data-ttu-id="809f1-231">ゲーム アプリがメイン ウィンドウを閉じ、ゲームを中断します。</span><span class="sxs-lookup"><span data-stu-id="809f1-231">The game app closes the main window and suspends the game.</span></span></td>
</tr>
<tr class="even">
<td align="left"><span data-ttu-id="809f1-232">OnWindowSizeChanged</span><span class="sxs-lookup"><span data-stu-id="809f1-232">OnWindowSizeChanged</span></span></td>
<td align="left"><span data-ttu-id="809f1-233"><a href="https://msdn.microsoft.com/library/windows/apps/br208283"><strong>CoreWindow::SizeChanged</strong></a> を処理します。</span><span class="sxs-lookup"><span data-stu-id="809f1-233">Handles <a href="https://msdn.microsoft.com/library/windows/apps/br208283"><strong>CoreWindow::SizeChanged</strong></a>.</span></span> <span data-ttu-id="809f1-234">サイズ変更に応じてゲーム アプリがグラフィックス リソースとオーバーレイを再割り当てし、その後、レンダー ターゲットを更新します。</span><span class="sxs-lookup"><span data-stu-id="809f1-234">The game app reallocates the graphics resources and overlay to accommodate the size change, and then updates the render target.</span></span></td>
</tr>
</tbody>
</table>

## <a name="next-steps"></a><span data-ttu-id="809f1-235">次のステップ</span><span class="sxs-lookup"><span data-stu-id="809f1-235">Next steps</span></span>

<span data-ttu-id="809f1-236">このトピックでは、ゲームの状態を使用してゲーム フロー全体を管理する方法と、ゲームが複数の異なるステート マシンで構成されていることを説明しました。</span><span class="sxs-lookup"><span data-stu-id="809f1-236">In this topic, we've covered how the overall game flow is managed using game states and that a game is made up of multiple different state machines.</span></span> <span data-ttu-id="809f1-237">また、UI を更新する方法や、主要なアプリのイベント ハンドラーを管理する方法についても説明しました。</span><span class="sxs-lookup"><span data-stu-id="809f1-237">We've also learnt about how to update the UI and manage key app event handlers.</span></span> <span data-ttu-id="809f1-238">これで、レンダリング ループ、ゲーム、そのしくみを解説する準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="809f1-238">Now we are ready to dive into the rendering loop, the game, and its mechanics.</span></span>
 
<span data-ttu-id="809f1-239">任意の順序でこのゲームを構成するその他のコンポーネントについて学習することができます。</span><span class="sxs-lookup"><span data-stu-id="809f1-239">You can go through the other components that make up this game in any order:</span></span>
* [<span data-ttu-id="809f1-240">メイン ゲーム オブジェクトの定義</span><span class="sxs-lookup"><span data-stu-id="809f1-240">Define the main game object</span></span>](tutorial--defining-the-main-game-loop.md)
* [<span data-ttu-id="809f1-241">レンダリング フレームワーク I: レンダリングの概要</span><span class="sxs-lookup"><span data-stu-id="809f1-241">Rendering framework I: Intro to rendering</span></span>](tutorial--assembling-the-rendering-pipeline.md)
* [<span data-ttu-id="809f1-242">レンダリング フレームワーク II: ゲームのレンダリング</span><span class="sxs-lookup"><span data-stu-id="809f1-242">Rendering framework II: Game rendering</span></span>](tutorial-game-rendering.md)
* [<span data-ttu-id="809f1-243">ユーザー インターフェイスの追加</span><span class="sxs-lookup"><span data-stu-id="809f1-243">Add a user interface</span></span>](tutorial--adding-a-user-interface.md)
* [<span data-ttu-id="809f1-244">コントロールの追加</span><span class="sxs-lookup"><span data-stu-id="809f1-244">Add controls</span></span>](tutorial--adding-controls.md)
* [<span data-ttu-id="809f1-245">サウンドの追加</span><span class="sxs-lookup"><span data-stu-id="809f1-245">Add sound</span></span>](tutorial--adding-sound.md)