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
# <a name="define-the-main-game-object"></a><span data-ttu-id="0fd75-104">メイン ゲーム オブジェクトの定義</span><span class="sxs-lookup"><span data-stu-id="0fd75-104">Define the main game object</span></span>

<span data-ttu-id="0fd75-105">サンプルのゲームの基本的なフレームワークをレイアウトし、高度なユーザーとシステムの動作を処理するステート マシンを実装したら後をルールと、ゲームにゲームのサンプルを有効にするメカニズムを確認します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-105">Once you’ve laid out the basic framework of the sample game and implemented a state machine that handles the high-level user and system behaviors, you’ll want to examine the rules and mechanics that turn the game sample into a game.</span></span> <span data-ttu-id="0fd75-106">ゲームの世界との対話にゲームのルールを変換する方法と、ゲームのサンプルのメインのオブジェクトの詳細を見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="0fd75-106">Let’s look at the details of the game sample's main object, and how to translate game rules into interactions with the game world.</span></span>

>[!Note]
><span data-ttu-id="0fd75-107">このサンプルの最新ゲーム コードをダウンロードしていない場合は、[Direct3D ゲーム サンプルのページ](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX)に移動してください。</span><span class="sxs-lookup"><span data-stu-id="0fd75-107">If you haven't downloaded the latest game code for this sample, go to [Direct3D game sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Simple3DGameDX).</span></span> <span data-ttu-id="0fd75-108">このサンプルは、UWP 機能のサンプルの大規模なコレクションの一部です。</span><span class="sxs-lookup"><span data-stu-id="0fd75-108">This sample is part of a large collection of UWP feature samples.</span></span> <span data-ttu-id="0fd75-109">サンプルをダウンロードする手順については、「[GitHub から UWP のサンプルを取得する](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fd75-109">For instructions on how to download the sample, see [Get the UWP samples from GitHub](https://docs.microsoft.com/windows/uwp/get-started/get-uwp-app-samples).</span></span>

## <a name="objective"></a><span data-ttu-id="0fd75-110">目標</span><span class="sxs-lookup"><span data-stu-id="0fd75-110">Objective</span></span>

<span data-ttu-id="0fd75-111">ゲームのルールおよび UWP の DirectX ゲームのメカニズムを実装する基本的な開発手法を適用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-111">Learn how to apply basic development techniques to implement game rules and mechanics for a UWP DirectX game.</span></span>

## <a name="main-game-object"></a><span data-ttu-id="0fd75-112">メイン ゲーム オブジェクト</span><span class="sxs-lookup"><span data-stu-id="0fd75-112">Main game object</span></span>

<span data-ttu-id="0fd75-113">このサンプル ゲーム__Simple3DGame__ゲーム オブジェクトのメイン クラスです。</span><span class="sxs-lookup"><span data-stu-id="0fd75-113">In this sample game, __Simple3DGame__ is the main game object class.</span></span> <span data-ttu-id="0fd75-114">インスタンス__Simple3DGame__でオブジェクトが構築された、 __App::Load__メソッド。</span><span class="sxs-lookup"><span data-stu-id="0fd75-114">An instance of __Simple3DGame__ object is constructed in the __App::Load__ method.</span></span>

<span data-ttu-id="0fd75-115">__Simple3DGame__クラス オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="0fd75-115">The __Simple3DGame__ class object:</span></span>
* <span data-ttu-id="0fd75-116">ゲーム ロジックの実装を指定します</span><span class="sxs-lookup"><span data-stu-id="0fd75-116">Specifies implementation of the gameplay logic</span></span>
* <span data-ttu-id="0fd75-117">通信するメソッドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-117">Contains methods that communicate:</span></span>
    * <span data-ttu-id="0fd75-118">アプリケーション フレームワークで定義されているステート マシンに、ゲームの状態の変更。</span><span class="sxs-lookup"><span data-stu-id="0fd75-118">Changes in the game state to the state machine defined in the app framework.</span></span>
    * <span data-ttu-id="0fd75-119">ゲーム オブジェクト自体に、アプリから、ゲームの状態の変更。</span><span class="sxs-lookup"><span data-stu-id="0fd75-119">Changes in the game state from the app to the game object itself.</span></span>
    * <span data-ttu-id="0fd75-120">ゲームの UI (オーバーレイとヘッドアップ ディスプレイ)、アニメーション、および物理学 (dynamics) を更新するための詳細。</span><span class="sxs-lookup"><span data-stu-id="0fd75-120">Details for updating the game's UI (overlay and heads-up display), animations, and physics (the dynamics).</span></span>

    >[!Note]
    ><span data-ttu-id="0fd75-121">グラフィックスの更新はによって処理される、 __GameRenderer__クラスを取得して、ゲームで使用されるグラフィックス デバイス リソースを使用するメソッドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-121">Updating of graphics is handled by the __GameRenderer__ class, which contains methods to obtain and use graphics device resources used by the game.</span></span> <span data-ttu-id="0fd75-122">詳細については、次を参照してください[レンダリング framework i:。レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-122">For more info, see [Rendering framework I: Intro to rendering](tutorial--assembling-the-rendering-pipeline.md).</span></span>

* <span data-ttu-id="0fd75-123">レベル、ゲームのセッションを定義するデータまたは高レベルでゲームを定義する方法に応じて、有効期間のコンテナーとして機能します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-123">Serves as a container for the data that defines a game session, level, or lifetime, depending on how you define your game at a high level.</span></span> <span data-ttu-id="0fd75-124">この場合は、ゲームの状態データは、ゲームの有効期間はされ、ユーザーがゲームを起動するときに 1 回が初期化されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-124">In this case, the game state data is for the lifetime of the game, and is initialized one time when a user launches the game.</span></span>

<span data-ttu-id="0fd75-125">メソッドと、このクラスのオブジェクトで定義されているデータを表示するには[Simple3DGame オブジェクト](#simple3dgame-object)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-125">To view methods and data defined in this class object, go to [Simple3DGame object](#simple3dgame-object).</span></span>

## <a name="initialize-and-start-the-game"></a><span data-ttu-id="0fd75-126">初期化して、ゲームを開始</span><span class="sxs-lookup"><span data-stu-id="0fd75-126">Initialize and start the game</span></span>

<span data-ttu-id="0fd75-127">プレーヤーがゲームを開始すると、ゲーム オブジェクトはその状態を初期化し、オーバーレイの作成と追加を行い、プレーヤーのパフォーマンスを追跡する変数を設定して、レベルの構築時に使うオブジェクトをインスタンス化する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-127">When a player starts the game, the game object must initialize its state, create and add the overlay, set the variables that track the player's performance, and instantiate the objects that it will use to build the levels.</span></span> <span data-ttu-id="0fd75-128">このサンプルでは、これは、ときに、新しい__GameMain__でインスタンスが作成される[ __App::Load__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L115-L123)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-128">In this sample, this is done when the new __GameMain__ instance is created in [__App::Load__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/App.cpp#L115-L123).</span></span> 

<span data-ttu-id="0fd75-129">ゲーム オブジェクト__Simple3DGame__で作成、 __GameMain__コンス トラクター。</span><span class="sxs-lookup"><span data-stu-id="0fd75-129">The game object, __Simple3DGame__, is created in the __GameMain__ constructor.</span></span> <span data-ttu-id="0fd75-130">使用して、初期化、 [ __Simple3DGame::Initialize__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L54-L250)メソッド中に、[非同期でタスクを作成する、 __GameMain__コンス トラクター](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L65-L74).</span><span class="sxs-lookup"><span data-stu-id="0fd75-130">It is then initialized using the [__Simple3DGame::Initialize__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L54-L250) method during the [async create task in the __GameMain__ constructor](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L65-L74).</span></span>

### <a name="simple3dgameinitialize-method"></a><span data-ttu-id="0fd75-131">Simple3DGame::Initialize メソッド</span><span class="sxs-lookup"><span data-stu-id="0fd75-131">Simple3DGame::Initialize method</span></span>

<span data-ttu-id="0fd75-132">ゲームのサンプルは、ゲーム オブジェクトには、次のコンポーネントを設定します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-132">The game sample sets up the following components in the game object:</span></span>

* <span data-ttu-id="0fd75-133">新規のオーディオ再生オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-133">A new audio playback object is created.</span></span>
* <span data-ttu-id="0fd75-134">一連のレベル プリミティブ、弾薬、障害物を含む、ゲームのグラフィック プリミティブの配列を作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-134">Arrays for the game's graphic primitives are created, including arrays for the level primitives, ammo, and obstacles.</span></span>
* <span data-ttu-id="0fd75-135">ゲーム状態データを保存する場所を作成し、*Game* という名前を付け、[**ApplicationData::Current**](https://msdn.microsoft.com/library/windows/apps/br241619) で指定するアプリ データ設定ストレージの場所に格納します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-135">A location for saving game state data is created, named *Game*, and placed in the app data settings storage location specified by [**ApplicationData::Current**](https://msdn.microsoft.com/library/windows/apps/br241619).</span></span>
* <span data-ttu-id="0fd75-136">ゲーム タイマーと初期ゲーム内オーバーレイ ビットマップを作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-136">A game timer and the initial in-game overlay bitmap are created.</span></span>
* <span data-ttu-id="0fd75-137">具体的なビュー パラメーターとプロジェクション パラメーター セットを使って新規のカメラを作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-137">A new camera is created with a specific set of view and projection parameters.</span></span>
* <span data-ttu-id="0fd75-138">プレーヤーがコントロール開始位置とカメラ位置の 1 対 1 の対応を確保されるように、入力デバイス (コントローラー) をカメラと同じ位置に上下と左右の開始位置を設定します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-138">The input device (the controller) is set to the same starting pitch and yaw as the camera, so the player has a 1-to-1 correspondence between the starting control position and the camera position.</span></span>
* <span data-ttu-id="0fd75-139">プレーヤー オブジェクトを作成し、アクティブに設定します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-139">The player object is created and set to active.</span></span> <span data-ttu-id="0fd75-140">球オブジェクトを使用して、壁や障害物をプレイヤーの近接性を検出し、カメラ immersion を壊す可能性がある位置に配置を取得することを防止します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-140">We use a sphere object to detect the player's proximity to walls and obstacles and to keep the camera from getting placed in a position that might break immersion.</span></span>
* <span data-ttu-id="0fd75-141">ゲーム ワールド プリミティブを作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-141">The game world primitive is created.</span></span>
* <span data-ttu-id="0fd75-142">円筒形の障害物を作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-142">The cylinder obstacles are created.</span></span>
* <span data-ttu-id="0fd75-143">標的 (**Face** オブジェクト) を作成し、番号を付けます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-143">The targets (**Face** objects) are created and numbered.</span></span>
* <span data-ttu-id="0fd75-144">弾薬の球体を作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-144">The ammo spheres are created.</span></span>
* <span data-ttu-id="0fd75-145">レベルを作成します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-145">The levels are created.</span></span>
* <span data-ttu-id="0fd75-146">ハイ スコアを読み込みます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-146">The high score is loaded.</span></span>
* <span data-ttu-id="0fd75-147">以前に保存されたゲーム状態を読み込みます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-147">Any prior saved game state is loaded.</span></span>

<span data-ttu-id="0fd75-148">ゲームには既に、ワールド、プレーヤー、障害物、標的、弾薬の球体の主要コンポーネントのインスタンスが存在します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-148">The game now has instances of all the key components: the world, the player, the obstacles, the targets, and the ammo spheres.</span></span> <span data-ttu-id="0fd75-149">これらの全コンポーネントの設定と個々の固有レベルに対する動作を表すレベルのインスタンスもあります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-149">It also has instances of the levels, which represent configurations of all of the above components and their behaviors for each specific level.</span></span> <span data-ttu-id="0fd75-150">ゲームでどのようにレベルが構築されるのかを見てみます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-150">Let's see how the game builds the levels.</span></span>

## <a name="build-and-load-game-levels"></a><span data-ttu-id="0fd75-151">ビルドやロード ゲーム レベル</span><span class="sxs-lookup"><span data-stu-id="0fd75-151">Build and load game levels</span></span>

<span data-ttu-id="0fd75-152">面倒な作業のほとんどでレベルの構築が行われる、 __Level.h/.cpp__ファイルにある、 __GameLevels__サンプル ソリューションのフォルダー。</span><span class="sxs-lookup"><span data-stu-id="0fd75-152">Most of the heavy lifting for the level construction is done in the __Level.h/.cpp__ files found in the __GameLevels__ folder of the sample solution.</span></span> <span data-ttu-id="0fd75-153">非常に特定の実装に焦点を当てます、ため、私たちは取り上げませんにここでします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-153">Because it focuses on a very specific implementation, we won't be covering them here.</span></span> <span data-ttu-id="0fd75-154">重要な点は、各レベルのコードがそれぞれ個別の __LevelN__ オブジェクトとして実行されるということです。</span><span class="sxs-lookup"><span data-stu-id="0fd75-154">The important thing is that the code for each level is run as a separate __LevelN__ object.</span></span> <span data-ttu-id="0fd75-155">ゲームを拡張したい場合は作成、**レベル**オブジェクトをパラメーターとして、ランダムに割り当てられた数を受け取るが、障害物とターゲットを配置します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-155">If you'd like to extend the game, you can create a **Level** object that takes an assigned number as a parameter and randomly places the obstacles and targets.</span></span> <span data-ttu-id="0fd75-156">または、リソース ファイル、またはインターネットからレベルの構成データを読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-156">Or, you can have it load level configuration data from a resource file, or even the Internet.</span></span>

## <a name="define-the-game-play"></a><span data-ttu-id="0fd75-157">ゲームのプレイを定義します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-157">Define the game play</span></span>

<span data-ttu-id="0fd75-158">この時点でゲームのアセンブルに必要なコンポーネントがすべて揃います。</span><span class="sxs-lookup"><span data-stu-id="0fd75-158">At this point, we have all the components we need to assemble the game.</span></span> <span data-ttu-id="0fd75-159">レベルは、プリミティブからメモリ内の構築し、プレーヤーが操作を開始する準備が整いました。</span><span class="sxs-lookup"><span data-stu-id="0fd75-159">The levels have been constructed in memory from the primitives, and are ready for the player to start interacting with.</span></span>

<span data-ttu-id="0fd75-160">とこの最高のゲームでは、プレイヤーの入力に瞬時に反応し、迅速なフィードバックを提供します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-160">Tthe best games react instantly to player input, and provide immediate feedback.</span></span> <span data-ttu-id="0fd75-161">これは、twitch アクション、リアルタイムの最初のユーザー連発銃ターンに基づくよく考えられた戦略ゲームからゲームの任意の型の場合は true。</span><span class="sxs-lookup"><span data-stu-id="0fd75-161">This is true for any type of a game, from twitch-action, real-time First-person shooters to thoughtful, turn-based strategy games.</span></span>

### <a name="simple3dgamerungame-method"></a><span data-ttu-id="0fd75-162">Simple3DGame::RunGame メソッド</span><span class="sxs-lookup"><span data-stu-id="0fd75-162">Simple3DGame::RunGame method</span></span>

<span data-ttu-id="0fd75-163">レベルを再生するときに、ゲームは、 __Dynamics__状態。</span><span class="sxs-lookup"><span data-stu-id="0fd75-163">When playing a level, the game is in the __Dynamics__ state.</span></span> 

<span data-ttu-id="0fd75-164">[__GameMain::Update__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329)は次のように、フレームごとに 1 回、アプリケーションの状態を更新する更新プログラムのメイン ループします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-164">[__GameMain::Update__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329) is the main update loop that updates the application state once per frame as shown below.</span></span> <span data-ttu-id="0fd75-165">Update ループで呼び出して、 [ __Simple3DGame::RunGame__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)ゲームがある場合は、作業を処理するメソッドを__Dynamics__状態。</span><span class="sxs-lookup"><span data-stu-id="0fd75-165">In the update loop, it calls the [__Simple3DGame::RunGame__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418) method to handle the work if the game is in the __Dynamics__ state.</span></span>

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
          
<span data-ttu-id="0fd75-166">[__Simple3DGame::RunGame__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)ゲーム ループの現在のイテレーションのゲーム プレイの現在の状態を定義するデータのセットを処理します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-166">[__Simple3DGame::RunGame__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418) handles the set of data that defines the current state of the game play for the current iteration of the game loop.</span></span>

<span data-ttu-id="0fd75-167">ゲームのフロー ロジックで__RunGame__:</span><span class="sxs-lookup"><span data-stu-id="0fd75-167">Game flow logic in __RunGame__:</span></span>
*  <span data-ttu-id="0fd75-168">メソッドは、レベルが終了するまでの間、残り時間を秒数でカウント ダウンするタイマーを更新し、レベルの時間が過ぎていないかをテストします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-168">The method updates the timer that counts down the seconds until the level is completed, and tests to see if the level's time has expired.</span></span> <span data-ttu-id="0fd75-169">これは、ゲームのルールの 1 つ: 時間がなくなるし、すべてのターゲットがショットされていない、ときに、ゲーム オーバーです。</span><span class="sxs-lookup"><span data-stu-id="0fd75-169">This is one of the rules of the game: when time runs out and all the targets have not been shot, it's game over.</span></span>
*  <span data-ttu-id="0fd75-170">時間切れになると、メソッドは **TimeExpired** ゲーム状態を設定し、前のコードの **Update** メソッドに戻ります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-170">If time has run out, the method sets the **TimeExpired** game state, and returns to the **Update** method in the previous code.</span></span>
*  <span data-ttu-id="0fd75-171">時間が残っている場合は、ムーブ/ルック コントローラーがポーリングを行って、カメラ位置に更新がないかどうかを確認します。具体的には、カメラ平面 (プレーヤーが見ている面) の延長上にあるビュー法線の角度や、前回のコントローラーのポーリング時からの角度の移動距離が更新されていないかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-171">If time remains, the move-look controller is polled for an update to the camera position; specifically, an update to the angle of the view normal projecting from the camera plane (where the player is looking), and the distance that angle has moved from the previous time the controller was polled.</span></span>
*  <span data-ttu-id="0fd75-172">カメラは、ムーブ/ルック コントローラーから送られる新しいデータに従って更新されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-172">The camera is updated based on the new data from the move-look controller.</span></span>
*  <span data-ttu-id="0fd75-173">ダイナミクス、つまりプレーヤーのコントロールからは独立したゲーム ワールド中のオブジェクトのアニメーションや動作が更新されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-173">The dynamics, or the animations and behaviors of objects in the game world independent of player control, are updated.</span></span> <span data-ttu-id="0fd75-174">このゲームのサンプルでは、 [ __UpdateDynamics()__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856)が起動されている、柱となる障害物のアニメーションとターゲットの動きを弾薬球の動きを更新するメソッドが呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-174">In this game sample, the [__UpdateDynamics()__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856) method is called to update the motion of the ammo spheres that have been fired, the animation of the pillar obstacles and the movement of the targets.</span></span> <span data-ttu-id="0fd75-175">詳細については、次を参照してください。[ゲームの世界を更新](#update-the-game-world)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-175">For more information, see [Update the game world](#update-the-game-world).</span></span>
*  <span data-ttu-id="0fd75-176">メソッドが、レベルの正常な完了に関する基準が満たされているかどうかをチェックします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-176">The method checks to see if the criteria for the successful completion of a level have been met.</span></span> <span data-ttu-id="0fd75-177">満たされていれば、レベルのスコアをファイナライズし、これが最後のレベル (全 6 レベル) であるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-177">If so, it finalizes the score for the level and checks to see if this is the last level (of 6).</span></span> <span data-ttu-id="0fd75-178">最後のレベルであれば、**GameComplete** ゲーム状態を返します。そうでない場合は、__LevelComplete__ ゲーム状態を返します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-178">If it's the last level, the method returns the **GameComplete** game state; otherwise, it returns the __LevelComplete__ game state.</span></span>
*  <span data-ttu-id="0fd75-179">レベルが完了していない場合は、ゲーム状態を __Active__ に設定し、戻ります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-179">If the level isn't complete, the method sets the game state to __Active__ and returns.</span></span>

## <a name="update-the-game-world"></a><span data-ttu-id="0fd75-180">ゲームの世界を更新します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-180">Update the game world</span></span>

<span data-ttu-id="0fd75-181">このサンプルでは、ゲームの実行時に、 [ __Simple3DGame::UpdateDynamics()__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856)メソッドの呼び出し元、 [ __Simple3DGame::RunGame__ ](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418)メソッド (から呼び出されるか[ __GameMain::Update__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329)) ゲームのシーンが表示されるオブジェクトを更新します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-181">In this sample, when the game is running, the [__Simple3DGame::UpdateDynamics()__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L436-L856) method is called from the [__Simple3DGame::RunGame__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/Simple3DGame.cpp#L337-L418) method (which is called from [__GameMain::Update__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L261-L329)) to update objects that are rendered in a game scene.</span></span>

<span data-ttu-id="0fd75-182">__UpdateDynamics__ループ、呼び出しでモーション、プレイヤーの入力の独立したゲームの世界を設定するために使用するメソッドは、魅力的なゲーム エクスペリエンスを作成して、レベルが*アライブ*します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-182">In the __UpdateDynamics__ loop, call methods that are used to set the game world in motion, independent of the player input, create an immersive game experience and make the level come *alive*.</span></span> <span data-ttu-id="0fd75-183">グラフィックス レンダリングする必要がありますにはが含まれ、実行中のアニメーションが生きているものでは、プレイヤーの入力がない場合でもを世界を実現できるループします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-183">This includes graphics that needs to be rendered and running animation loops to bring about a living, breathing world even when there's no player input.</span></span> <span data-ttu-id="0fd75-184">たとえば、岸行、機械禁煙、エイリアン モンスターの移動を拡大したりに沿って cresting ウェーブ、風にまきをツリー。</span><span class="sxs-lookup"><span data-stu-id="0fd75-184">For example, trees swaying in the wind, waves cresting along shore lines, machinery smoking, and alien monsters stretching and moving around.</span></span> <span data-ttu-id="0fd75-185">また、プレーヤーの球体とワールドの間、または弾薬、障害物、標的の間に生じる衝突を含め、物体どうしの相互作用も統合されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-185">It also encompasses the interaction between objects, including collisions between the player sphere and the world, or between the ammo and the obstacles and targets.</span></span>

<span data-ttu-id="0fd75-186">ゲームのループは常に物理アルゴリズムでは、ゲームのロジックに基づいているかどうか、または単純かどうか、ゲームの世界中の更新のゲームが具体的には一時停止を除く、ランダムなを保持します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-186">The game loop should always keep updating the game world whether it's based on game logic, physical algorithms, or whether it's just plain random, except when the game is specifically paused.</span></span> 

<span data-ttu-id="0fd75-187">ゲーム サンプルでは、この原理のことを*ダイナミクス*と呼んでいます。これにより、柱の障害物の上下の動き、発砲時に見られる弾薬の球体の動きや物理的動作が統合されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-187">In the game sample, this principle is called *dynamics*, and it encompasses the rise and fall of the pillar obstacles, and the motion and physical behaviors of the ammo spheres as they are fired.</span></span> 

### <a name="simple3dgameupdatedynamics-method"></a><span data-ttu-id="0fd75-188">Simple3DGame::UpdateDynamics メソッド</span><span class="sxs-lookup"><span data-stu-id="0fd75-188">Simple3DGame::UpdateDynamics method</span></span> 

<span data-ttu-id="0fd75-189">このメソッドは、次の 4 種類の計算を行います。</span><span class="sxs-lookup"><span data-stu-id="0fd75-189">This method deals with four sets of computations:</span></span>

* <span data-ttu-id="0fd75-190">ワールドで発砲された弾薬の球体の位置</span><span class="sxs-lookup"><span data-stu-id="0fd75-190">The positions of the fired ammo spheres in the world.</span></span>
* <span data-ttu-id="0fd75-191">柱の障害物のアニメーション</span><span class="sxs-lookup"><span data-stu-id="0fd75-191">The animation of the pillar obstacles.</span></span>
* <span data-ttu-id="0fd75-192">プレーヤーとワールドの境界の交差部分</span><span class="sxs-lookup"><span data-stu-id="0fd75-192">The intersection of the player and the world boundaries.</span></span>
* <span data-ttu-id="0fd75-193">弾薬の球体と、障害物、標的、他の弾薬球体、ワールドとの衝突</span><span class="sxs-lookup"><span data-stu-id="0fd75-193">The collisions of the ammo spheres with the obstacles, the targets, other ammo spheres, and the world.</span></span>

<span data-ttu-id="0fd75-194">障害物のアニメーションは、**Animate.h/.cpp** で定義されたループとして実行されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-194">The animation of the obstacles is a loop defined in **Animate.h/.cpp**.</span></span> <span data-ttu-id="0fd75-195">弾薬とすべての競合の動作の簡略化された物理学のアルゴリズムで定義されている、コードで指定および重力や素材のプロパティを含む、ゲームの世界のグローバル定数のセットによってパラメーター化していること。</span><span class="sxs-lookup"><span data-stu-id="0fd75-195">The behavior of the ammo and any collisions are defined by simplified physics algorithms, supplied in the code and parameterized by a set of global constants for the game world, including gravity and material properties.</span></span> <span data-ttu-id="0fd75-196">これはすべて、ゲーム ワールドの座標空間で計算されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-196">This is all computed in the game world coordinate space.</span></span>

### <a name="review-the-flow"></a><span data-ttu-id="0fd75-197">フローを確認してください。</span><span class="sxs-lookup"><span data-stu-id="0fd75-197">Review the flow</span></span>

<span data-ttu-id="0fd75-198">これで、シーン内のすべてのオブジェクトを更新し、すべての競合を計算しましたしたら、この情報を使用して、対応する視覚的な変更を描画する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-198">Now that we've updated all the objects in the scene and calculated any collisions, we need to use this info to draw the corresponding visual changes.</span></span> 

<span data-ttu-id="0fd75-199">後__GameMain::Update()__ 、現在のイテレーションが完了すると、サンプルのゲームのループでは、呼び出してすぐに__Render()__ 更新されたオブジェクト データを受け取り、として、プレーヤーに表示する新しいシーンを生成するには次に示します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-199">After __GameMain::Update()__ completes the current iteration of the game loop, the sample immediately calls __Render()__ to take the updated object data and generate a new scene to present to the player, as shown here.</span></span> <span data-ttu-id="0fd75-200">次に、レンダリングを見てみましょう。</span><span class="sxs-lookup"><span data-stu-id="0fd75-200">Next, let's take a look at the rendering.</span></span>

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

## <a name="render-the-game-worlds-graphics"></a><span data-ttu-id="0fd75-201">ゲームの世界中のグラフィックスをレンダリングします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-201">Render the game world's graphics</span></span>

<span data-ttu-id="0fd75-202">ゲーム中のグラフィックスはできるだけ頻繁 (最大ではメインのゲーム ループが反復するごと) に更新することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-202">We recommend that the graphics in a game update as often as possible, which, at maximum, is every time the main game loop iterates.</span></span> <span data-ttu-id="0fd75-203">ループが反復するごとに、プレーヤーからの入力の有無を問わず、ゲームを更新します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-203">As the loop iterates, the game is updated, with or without player input.</span></span> <span data-ttu-id="0fd75-204">これにより、計算するアニメーションと動作がスムーズに表示されるようになります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-204">This allows the animations and behaviors that are calculated to be displayed smoothly.</span></span> <span data-ttu-id="0fd75-205">たとえば、プレーヤーがボタンを押したときにのみ、水が流れるという単純なシーンを思い浮かべてください。</span><span class="sxs-lookup"><span data-stu-id="0fd75-205">Imagine if we had a simple scene of water that only moved when the player pressed a button.</span></span> <span data-ttu-id="0fd75-206">ひどくつまらないビジュアルになるでしょう。</span><span class="sxs-lookup"><span data-stu-id="0fd75-206">That would make for terribly boring visuals.</span></span> <span data-ttu-id="0fd75-207">優れたゲームは、流れるような自然の動きを伴うものです。</span><span class="sxs-lookup"><span data-stu-id="0fd75-207">A good game looks smooth and fluid.</span></span>

<span data-ttu-id="0fd75-208">上記のサンプル ゲームのループを思い出してください[ __GameMain::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L143-L202)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-208">Recall the sample game's loop as shown above in [__GameMain::Run__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameMain.cpp#L143-L202).</span></span> <span data-ttu-id="0fd75-209">ゲームのメイン ウィンドウが表示されていて、スナップされたり、非アクティブにされたりしなければ、ゲームはそのまま、その更新結果の更新とレンダリングを続けます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-209">If the game's main window is visible, and isn't snapped or deactivated, the game continues to update and render the results of that update.</span></span> <span data-ttu-id="0fd75-210">[__レンダリング__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameRenderer.cpp#L474-L624)調べているメソッドは今すぐその状態の表示を描画します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-210">The [__Render__](https://github.com/Microsoft/Windows-universal-samples/blob/5f0d0912214afc1c2a7c7470203933ddb46f7c89/Samples/Simple3DGameDX/cpp/GameRenderer.cpp#L474-L624) method we're examining now renders a representation of that state.</span></span> <span data-ttu-id="0fd75-211">呼び出しの直後にこれは、**更新**が含まれています**RunGame**前のセクションで説明した更新プログラムの状態にします。</span><span class="sxs-lookup"><span data-stu-id="0fd75-211">This is done immediately after a call to **Update**, which includes **RunGame** to update states, which was discussed in the previous section.</span></span>

<span data-ttu-id="0fd75-212">このメソッドではまず 3D ワールドのプロジェクションが描画され、続いてその上に Direct2D オーバーレイが描画されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-212">This method draws the projection of the 3D world, and then draws the Direct2D overlay on top of it.</span></span> <span data-ttu-id="0fd75-213">描画が完了すると、表示用に結合されたバッファーとともに最終的なスワップ チェーンが表示されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-213">When completed, it presents the final swap chain with the combined buffers for display.</span></span>

>[!Note]
><span data-ttu-id="0fd75-214">サンプル ゲームの Direct2D のオーバーレイの 2 つの状態があります 1 つのゲームが一時停止 メニューとゲームがタッチ スクリーンの移動についての四角形と十字線を表示する 1 つのビットマップを含むゲーム情報オーバーレイが表示されます。コント ローラー。</span><span class="sxs-lookup"><span data-stu-id="0fd75-214">There are two states for the sample game's Direct2D overlay: one where the game displays the game info overlay that contains the bitmap for the pause menu, and one where the game displays the cross hairs along with the rectangles for the touchscreen move-look controller.</span></span> <span data-ttu-id="0fd75-215">両方の状態でスコア テキストが描画されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-215">The score text is drawn in both states.</span></span> <span data-ttu-id="0fd75-216">詳細については、次を参照してください[レンダリング framework i:。レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-216">For more information, see [Rendering framework I: Intro to rendering](tutorial--assembling-the-rendering-pipeline.md).</span></span>

### <a name="gamerendererrender-method"></a><span data-ttu-id="0fd75-217">GameRenderer::Render メソッド</span><span class="sxs-lookup"><span data-stu-id="0fd75-217">GameRenderer::Render method</span></span>

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

## <a name="simple3dgame-object"></a><span data-ttu-id="0fd75-218">Simple3DGame オブジェクト</span><span class="sxs-lookup"><span data-stu-id="0fd75-218">Simple3DGame object</span></span>

<span data-ttu-id="0fd75-219">これらは、メソッドとに定義されているデータ、 __Simple3DGame__オブジェクト クラス。</span><span class="sxs-lookup"><span data-stu-id="0fd75-219">These are the methods and data that are defined in the __Simple3DGame__ object class.</span></span>

### <a name="methods"></a><span data-ttu-id="0fd75-220">メソッド</span><span class="sxs-lookup"><span data-stu-id="0fd75-220">Methods</span></span>

<span data-ttu-id="0fd75-221">定義された内部メソッド**Simple3DGame**が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-221">The internal methods defined on **Simple3DGame** include:</span></span>

-   <span data-ttu-id="0fd75-222">**初期化**:グローバル変数の開始値を設定し、ゲーム オブジェクトを初期化します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-222">**Initialize**: Sets the starting values of the global variables and initializes the game objects.</span></span> <span data-ttu-id="0fd75-223">これについては、[を初期化して、ゲームを開始](#initialize-and-start-the-game)セクション。</span><span class="sxs-lookup"><span data-stu-id="0fd75-223">This is covered in the [Initialize and start the game](#initialize-and-start-the-game) section.</span></span>
-   <span data-ttu-id="0fd75-224">**LoadGame**:新しいレベルを初期化し、読み込みを開始します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-224">**LoadGame**: Initializes a new level and starts loading it.</span></span>
-   <span data-ttu-id="0fd75-225">**LoadLevelAsync**:非同期タスクを開始 (非同期タスクを慣れていない場合を参照してください。[並列パターン ライブラリ](https://docs.microsoft.com/cpp/parallel/concrt/parallel-patterns-library-ppl)) に、レベルを初期化し、デバイスの特定レベル リソースを読み込むレンダラーの非同期タスクを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-225">**LoadLevelAsync**: Starts an async task (if you're unfamiliar with async tasks, see [Parallel Patterns Library](https://docs.microsoft.com/cpp/parallel/concrt/parallel-patterns-library-ppl)) to initialize the level and then invoke an async task on the renderer to load the device specific level resources.</span></span> <span data-ttu-id="0fd75-226">このメソッドは独立したスレッドで実行されます。そのため、このスレッドから呼び出すことができるのは [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) メソッドだけです ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) メソッドは呼び出されません)。</span><span class="sxs-lookup"><span data-stu-id="0fd75-226">This method runs in a separate thread; as a result, only [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) methods (as opposed to [**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) methods) can be called from this thread.</span></span> <span data-ttu-id="0fd75-227">デバイス コンテキストのメソッドは、**FinalizeLoadLevel** メソッドで呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-227">Any device context methods are called in the **FinalizeLoadLevel** method.</span></span>
-   <span data-ttu-id="0fd75-228">**FinalizeLoadLevel**:メイン スレッドで実行する必要があるレベル読み込みの作業を完了します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-228">**FinalizeLoadLevel**: Completes any work for level loading that needs to be done on the main thread.</span></span> <span data-ttu-id="0fd75-229">これには、Direct3D 11 のデバイス コンテキスト ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)) のメソッドの呼び出しが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-229">This includes any calls to Direct3D 11 device context ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)) methods.</span></span>
-   <span data-ttu-id="0fd75-230">**StartLevel**:新しいレベルでゲーム プレイを開始します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-230">**StartLevel**: Starts the game play for a new level.</span></span>
-   <span data-ttu-id="0fd75-231">**PauseGame**:ゲームを一時停止します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-231">**PauseGame**: Pauses the game.</span></span>
-   <span data-ttu-id="0fd75-232">**RunGame**:ゲーム ループの反復を実行します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-232">**RunGame**: Runs an iteration of the game loop.</span></span> <span data-ttu-id="0fd75-233">ゲームの状態が **App::Update** の場合、ゲーム ループを反復するごとに **Active** から 1 回呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-233">It's called from **App::Update** one time every iteration of the game loop if the game state is **Active**.</span></span>
-   <span data-ttu-id="0fd75-234">**OnSuspending**と**OnResuming**:前者はゲームのオーディオを中断し、後者はこれを再開します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-234">**OnSuspending** and **OnResuming**: Suspends and resumes the game's audio, respectively.</span></span>

<span data-ttu-id="0fd75-235">さらに、次のプライベート メソッドがあります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-235">And the private methods:</span></span>

-   <span data-ttu-id="0fd75-236">**LoadSavedState**と**SaveState**:前者はゲームの現在の状態の読み込み、後者はこれを保存します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-236">**LoadSavedState** and **SaveState**: Loads and saves the current state of the game, respectively.</span></span>
-   <span data-ttu-id="0fd75-237">**SaveHighScore**と**LoadHighScore**:前者はゲーム全体のハイ スコアを読み込み、後者はこれを保存します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-237">**SaveHighScore** and **LoadHighScore**: Saves and loads the high score across games, respectively.</span></span>
-   <span data-ttu-id="0fd75-238">**InitializeAmmo**:弾として使われるそれぞれの球体の状態を各ラウンドの最初に元の状態に戻します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-238">**InitializeAmmo**: Resets the state of each sphere object used as ammunition back to its original state for the beginning of each round.</span></span>
-   <span data-ttu-id="0fd75-239">**UpdateDynamics**:これは、アニメーションのキャンド ルーチンをはじめ、物理学とコントロール入力に基づいてゲーム オブジェクトをすべて更新するため、重要なメソッドになります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-239">**UpdateDynamics**: This is an important method, because it updates all the game objects based on canned animation routines, physics, and control input.</span></span> <span data-ttu-id="0fd75-240">これが、ゲームを定義するインタラクティビティの中核部分に相当します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-240">This is the heart of the interactivity that defines the game.</span></span> <span data-ttu-id="0fd75-241">これについては、[ゲームの世界を更新](#update-the-game-world)セクション。</span><span class="sxs-lookup"><span data-stu-id="0fd75-241">This is covered in the [Update the game world](#update-the-game-world) section.</span></span>

<span data-ttu-id="0fd75-242">これ以外のパブリック メソッドとして、表示用のアプリ フレームワークにゲーム プレイとオーバーレイ固有の情報を返すプロパティの getter があります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-242">The other public methods are property getters that return game play and overlay specific information to the app framework for display.</span></span>

### <a name="data"></a><span data-ttu-id="0fd75-243">データ</span><span class="sxs-lookup"><span data-stu-id="0fd75-243">Data</span></span>

<span data-ttu-id="0fd75-244">コード例の冒頭には、ゲーム ループの実行時にインスタンスが更新される 4 つのオブジェクトがあります。</span><span class="sxs-lookup"><span data-stu-id="0fd75-244">At the top of the code example, there are four objects whose instances are updated as the game loop runs.</span></span>

-   <span data-ttu-id="0fd75-245">**MoveLookController**オブジェクト。プレイヤーの入力を表します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-245">**MoveLookController** object: Represents the player input.</span></span> <span data-ttu-id="0fd75-246">詳細については、「[コントロールの追加](tutorial--adding-controls.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0fd75-246">For more information, see [Adding controls](tutorial--adding-controls.md).</span></span>
-   <span data-ttu-id="0fd75-247">**GameRenderer**オブジェクト。派生した Direct3D 11 のレンダラーを表す、 **DirectXBase**デバイスに固有のすべてのオブジェクトと、レンダリングを処理するクラスです。</span><span class="sxs-lookup"><span data-stu-id="0fd75-247">**GameRenderer** object: Represents the Direct3D 11 renderer derived from the **DirectXBase** class that handles all the device-specific objects and their rendering.</span></span> <span data-ttu-id="0fd75-248">詳細については、次を参照してください。[レンダリングのフレームワークは](tutorial--assembling-the-rendering-pipeline.md)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-248">For more information, see [Rendering framework I](tutorial--assembling-the-rendering-pipeline.md).</span></span>
-   <span data-ttu-id="0fd75-249">**オーディオ**オブジェクト。ゲームのオーディオ再生を制御します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-249">**Audio** object: Controls the audio playback for the game.</span></span> <span data-ttu-id="0fd75-250">詳細については、次を参照してください。[サウンドを追加する](tutorial--adding-sound.md)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-250">For more information, see [Adding sound](tutorial--adding-sound.md).</span></span>

<span data-ttu-id="0fd75-251">残りのゲーム変数には、プリミティブとゲーム内で対応するプリミティブの量を示すリストと、ゲーム プレイ固有のデータと制約が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0fd75-251">The rest of the game variables contain the lists of the primitives and their respective in-game amounts, and game play specific data and constraints.</span></span>

## <a name="next-steps"></a><span data-ttu-id="0fd75-252">次のステップ</span><span class="sxs-lookup"><span data-stu-id="0fd75-252">Next steps</span></span>

<span data-ttu-id="0fd75-253">ここまでで、興味おそらく実際のレンダリング エンジンに関する: 方法への呼び出し、__レンダリング__更新されたプリミティブをメソッドを取得、画面上のピクセルになっています。</span><span class="sxs-lookup"><span data-stu-id="0fd75-253">By now, you're probably curious about the actual rendering engine: how calls to the __Render__ methods on the updated primitives get turned into pixels on your screen.</span></span> <span data-ttu-id="0fd75-254">これは 2 つの部分で説明&mdash;[レンダリング framework i:レンダリングの概要](tutorial--assembling-the-rendering-pipeline.md)と[レンダリング framework II:ゲームのレンダリング](tutorial-game-rendering.md)します。</span><span class="sxs-lookup"><span data-stu-id="0fd75-254">This is covered in two parts &mdash; [Rendering framework I: Intro to rendering](tutorial--assembling-the-rendering-pipeline.md) and [Rendering framework II: Game rendering](tutorial-game-rendering.md).</span></span> <span data-ttu-id="0fd75-255">またプレーヤー コントロールによってゲーム状態がどのように更新されるのかについては、「[コントロールの追加](tutorial--adding-controls.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0fd75-255">If you're more interested in how the player controls update the game state, then check out [Adding controls](tutorial--adding-controls.md).</span></span>
