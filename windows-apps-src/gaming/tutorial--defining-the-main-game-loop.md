---
author: mtoepke
title: "メイン ゲーム オブジェクトの定義"
description: "ここでは、ゲーム サンプルのメイン オブジェクトの詳細と、実装するルールをゲーム ワールドとの対話式操作に変換する方法について説明します。"
ms.assetid: 6afeef84-39d0-cb78-aa2e-2e42aef936c9
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 8af939fee50540e5213e624703400d99cbb6785f

---

# メイン ゲーム オブジェクトの定義


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

この時点までに、サンプル ゲームの基本的なフレームワークを紹介し、高度なユーザーの操作とシステムの動作を処理するステート マシンを実装しました。 しかし、ルール、機構、実装方法など、ゲーム サンプルを実際のゲームにする要素についてはまだ検証していません。 ここでは、ゲーム サンプルのメイン オブジェクトの詳細と、実装するルールをゲーム ワールドとの対話式操作に変換する方法について説明します。

## 目標


-   DirectX を使ったシンプルなユニバーサル Windows プラットフォーム (UWP) ゲームのルールやしくみを実装する際に、基本的な開発手法を適用する。

## ゲーム フローの検討


ゲームの基本構造の大部分が次のファイルで定義されます。

-   **App.cpp**
-   **Simple3DGame.cpp**

「[ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義](tutorial--building-the-games-metro-style-app-framework.md)」では、**App.cpp** で定義されたゲームのフレームワークを確認しました。

**Simple3DGame.cpp** には、ゲーム プレイ自体の実装を指定するクラス、**Simple3DGame** のコードが記載されています。 サンプル ゲームを UWP アプリとして扱う処理については前述しました。 ここでは、ゲームを構成するコードを詳しく見てみましょう。

**Simple3DGame.h/.cpp** の完全なコードは、[このセクションのサンプル コード一式](#code_sample)に示します。

**Simple3DGame** クラスの定義を見てみましょう。

## コア ゲーム オブジェクトの定義


アプリ シングルトンが開始すると、ビュー プロバイダーの **Initialize** メソッドにより、メイン ゲーム クラスのインスタンスである **Simple3DGame** オブジェクトが作成されます。 このオブジェクトには、ゲーム状態に生じた変更について、アプリ フレームワークで定義されたステート マシンに伝えたり、アプリからゲーム オブジェクト自体に伝えたりするためのメソッドが含まれています。 また、ゲームのオーバーレイ ビットマップとヘッダアップ ディスプレイの更新やアニメーションやゲーム中の物理学 (力学) の更新に対して情報を返すメソッドも含まれています。 ゲームで使うグラフィックス デバイス リソースを取得するコードは GameRenderer.cpp に含まれています。これについては、次の「[レンダリング フレームワークの作成](tutorial--assembling-the-rendering-pipeline.md)」で説明します。

**Simple3DGame** のコードは次のようになります。

```cpp
ref class GameRenderer;

ref class Simple3DGame
{
internal:
    Simple3DGame();

    void Initialize(
        _In_ MoveLookController^ controller,
        _In_ GameRenderer^ renderer
        );

    void LoadGame();
    concurrency::task<void> LoadLevelAsync();
    void FinalizeLoadLevel();
    void StartLevel();
    void PauseGame();
    void ContinueGame();
    GameState RunGame();

    void OnSuspending();
    void OnResuming();

    // ... Global variable retrieval methods are defined here ...

private:
    void LoadState();
    void SaveState();
    void SaveHighScore();
    void LoadHighScore();
    void InitializeAmmo();
    void UpdateDynamics();

    // ...
                // ... Global variables are defined here.
    // ...
};
```

まず、**Simple3DGame** で定義した内部メソッドについて見てみましょう。

-   **Initialize**。 グローバル変数の開始値を設定し、ゲーム オブジェクトを初期化します。
-   **LoadGame**。 新しいレベルを初期化し、読み込みを開始します。
-   **LoadLevelAsync**。 非同期タスク (詳しくは、[並列パターン ライブラリ](https://msdn.microsoft.com/library/windows/apps/dd492418.aspx)をご覧ください) を開始して、レベルを初期化してから、レンダラーでデバイス固有のレベル リソースを読み込む非同期タスクを呼び出します。 このメソッドは独立したスレッドで実行されます。そのため、このスレッドから呼び出すことができるのは [**ID3D11Device**](https://msdn.microsoft.com/library/windows/desktop/ff476379) メソッドだけです ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385) メソッドは呼び出されません)。 デバイス コンテキストのメソッドは、**FinalizeLoadLevel** メソッドで呼び出されます。
-   **FinalizeLoadLevel**。 メイン スレッドで実行する必要があるレベル読み込みの作業を完了します。 これには、Direct3D 11 のデバイス コンテキスト ([**ID3D11DeviceContext**](https://msdn.microsoft.com/library/windows/desktop/ff476385)) のメソッドの呼び出しが含まれます。
-   **StartLevel**。 新しいレベルでゲーム プレイを開始します。
-   **PauseGame**。 ゲームを一時停止します。
-   **RunGame**。 ゲーム ループの反復を実行します。 ゲームの状態が **App::Update** の場合、ゲーム ループを反復するごとに **Active** から 1 回呼び出されます。
-   **OnSuspending** および **OnResuming**。 前者はゲームのオーディオを中断し、後者はこれを再開します。

さらに、次のプライベート メソッドがあります。

-   **LoadSavedState** および **SaveState**。 前者はゲームの現在の状態の読み込み、後者はこれを保存します。
-   **SaveHighScore** および **LoadHighScore**。 前者はゲーム全体のハイ スコアを読み込み、後者はこれを保存します。
-   **InitializeAmmo**。 弾として使われるそれぞれの球体の状態を各ラウンドの最初に元の状態に戻します。
-   **UpdateDynamics**。 これは、アニメーションのキャンド ルーチンをはじめ、物理学とコントロール入力に基づいてゲーム オブジェクトをすべて更新するため、重要なメソッドになります。 これが、ゲームを定義するインタラクティビティの中核部分に相当します。 これについては、「[ゲームの更新](#update_game)」のセクションで詳しく説明します。

これ以外のパブリック メソッドとして、表示用のアプリ フレームワークにゲーム プレイとオーバーレイ固有の情報を返すプロパティの getter があります。

## ゲーム状態変数の定義


ゲーム オブジェクトの役割の 1 つは、上位レベルでゲームをどのように定義するかに応じてゲームのセッション、レベル、または有効期間を定義するデータのコンテナーとして利用することです。 この場合、ゲーム状態データは、ユーザーがゲームを開始した時点で一度初期化されるゲームの有効期限の間、適用されます。

以下にゲーム オブジェクトの状態変数に対する定義一式を示します。

```cpp
private:
    MoveLookController^                                 m_controller;
    GameRenderer^                                       m_renderer;
    Camera^                                             m_camera;

    Audio^                                              m_audioController;

    std::vector<Sphere^>                                m_ammo;
    uint32                                              m_ammoCount;
    uint32                                              m_ammoNext;

    HighScoreEntry                                      m_topScore;
    PersistentState^                                    m_savedState;

    GameTimer^                                          m_timer;
    bool                                                m_gameActive;
    bool                                                m_levelActive;
    int                                                 m_totalHits;
    int                                                 m_totalShots;
    float                                               m_levelDuration;
    float                                               m_levelBonusTime;
    float                                               m_levelTimeRemaining;
    std::vector<Level^>                                 m_level;
    uint32                                              m_levelCount;
    uint32                                              m_currentLevel;

    Sphere^                                             m_player;
    std::vector<GameObject^>                            m_object;           // object list for intersections
    std::vector<GameObject^>                            m_renderObject;     // all objects to be rendered

    DirectX::XMFLOAT3                                   m_minBound;
    DirectX::XMFLOAT3                                   m_maxBound;
```

コード例の冒頭には、ゲーム ループの実行時にインスタンスが更新される 4 つのオブジェクトがあります。

-   **MoveLookController** オブジェクト。 プレーヤーの入力を表すオブジェクトです (**MoveLookController** オブジェクトについて詳しくは、「[コントロールの追加](tutorial--adding-controls.md)」をご覧ください)。
-   **GameRenderer** オブジェクト。 Direct3D 11 のレンダラーを表すオブジェクトです。デバイス固有のオブジェクトとそのレンダリングをすべて処理する **DirectXBase** クラスから派生します  (詳しくは、「[レンダリング パイプラインのアセンブル](tutorial--assembling-the-rendering-pipeline.md)」をご覧ください)。
-   **Camera** オブジェクト。 ゲーム ワールドに対するプレーヤーの一人称視点を表すオブジェクトです (**Camera** オブジェクトについて詳しくは、「[レンダリング パイプラインのアセンブル](tutorial--assembling-the-rendering-pipeline.md)」をご覧ください)。
-   **Audio** オブジェクト。 ゲームのオーディオ再生をコントロールするオブジェクトです (**Audio** オブジェクトについて詳しくは、「[サウンドの追加](tutorial--adding-sound.md)」をご覧ください)。

残りのゲーム変数には、プリミティブとゲーム内で対応するプリミティブの量を示すリストと、ゲーム プレイ固有のデータと制約が含まれます。 ゲームの初期化時にこれらの変数がどのように設定されるかを見てみましょう。

## ゲームの初期化と開始


プレーヤーがゲームを開始すると、ゲーム オブジェクトはその状態を初期化し、オーバーレイの作成と追加を行い、プレーヤーのパフォーマンスを追跡する変数を設定して、レベルの構築時に使うオブジェクトをインスタンス化する必要があります。

```cpp
void Simple3DGame::Initialize(
    _In_ MoveLookController^ controller,
    _In_ GameRenderer^ renderer
    )
{
    // This method is expected to be called as an asynchronous task.
    // Make sure that you don't call rendering methods on the
    // m_renderer as this would result in the D3D Context being
    // used in multiple threads, which is not allowed.

    m_controller = controller;
    m_renderer = renderer;

    m_audioController = ref new Audio;
    m_audioController->CreateDeviceIndependentResources();

    m_ammo = std::vector<Sphere^>(GameConstants::MaxAmmo);
    m_object = std::vector<GameObject^>();
    m_renderObject = std::vector<GameObject^>();
    m_level = std::vector<Level^>();

    m_savedState = ref new PersistentState();
    m_savedState->Initialize(ApplicationData::Current->LocalSettings->Values, "Game");

    m_timer = ref new GameTimer();

    // Create a sphere primitive to represent the player.
    // The sphere is used to handle collisions and constrain the player in the world.
    // It's not rendered, so it's not added to the list of render objects.
    m_player = ref new Sphere(XMFLOAT3(0.0f, -1.3f, 4.0f), 0.2f);

    m_camera = ref new Camera;
    m_camera->SetProjParams(XM_PI / 2, 1.0f, 0.01f, 100.0f);
    m_camera->SetViewParams(
        m_player->Position(),            // Eye point in world coordinates.
        XMFLOAT3 (0.0f, 0.7f, 0.0f),     // Look at point in world coordinates.
        XMFLOAT3 (0.0f, 1.0f, 0.0f)      // The Up vector for the camera.
        );

    m_controller->Pitch(m_camera->Pitch());
    m_controller->Yaw(m_camera->Yaw());

    // Add the m_player object to the object list to do intersection calculations.
    m_object.push_back(m_player);
    m_player->Active(true);

    // Instantiate the world primitive.  This object maintains the geometry and
    // material properties of the walls, floor, and ceiling of the enclosing world.
    // The TargetId is used to identify the world objects so that the right geometry
    // and textures can be associated with them later after those resources have
    // been created.
    GameObject^ world = ref new GameObject();
    world->TargetId(GameConstants::WorldFloorId);
    world->Active(true);
    m_renderObject.push_back(world);

    world = ref new GameObject();
    world->TargetId(GameConstants::WorldCeilingId);
    world->Active(true);
    m_renderObject.push_back(world);

    world = ref new GameObject();
    world->TargetId(GameConstants::WorldWallsId);
    world->Active(true);
    m_renderObject.push_back(world);

    // Min and max Bound are defining the world space of the game.
    // All camera motion and dynamics are confined to this space.
    m_minBound = XMFLOAT3(-4.0f, -3.0f, -6.0f);
    m_maxBound = XMFLOAT3(4.0f, 3.0f, 6.0f);

    // Instantiate the cylinders for use in the various game levels.
    // Each cylinder has a different initial position, radius, and direction vector,
    // but share a common set of material properties.
    for (int a = 0; a < GameConstants::MaxCylinders; a++)
    {
        Cylinder^ cylinder;
        switch (a)
        {
        case 0:
            cylinder = ref new Cylinder(XMFLOAT3(-2.0f, -3.0f, 0.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 1:
            cylinder = ref new Cylinder(XMFLOAT3(2.0f, -3.0f, 0.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 2:
            cylinder = ref new Cylinder(XMFLOAT3(0.0f, -3.0f, -2.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 3:
            cylinder = ref new Cylinder(XMFLOAT3(-1.5f, -3.0f, -4.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 4:
            cylinder = ref new Cylinder(XMFLOAT3(1.5f, -3.0f, -4.0f), 0.50f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        }
        cylinder->Active(true);
        m_object.push_back(cylinder);
        m_renderObject.push_back(cylinder);
    }

    MediaReader^ mediaReader = ref new MediaReader;
    auto targetHitSound = mediaReader->LoadMedia("hit.wav");

    // Instantiate the targets for use in the game.
    // Each target has a different initial position, size, and orientation,
    // but share a common set of material properties.
    // The target is defined by a position and two vectors that define both
    // the plane of the target in world space and the size of the parallelogram
    // based on the lengths of the vectors.
    // Each target is assigned a number for identification purposes.
    // The Target ID number is 1 based.
    // All targets have the same material properties.
    for (int a = 1; a < GameConstants::MaxTargets; a++)
    {
        Face^ target;
        switch (a)
        {
        case 1:
            target = ref new Face(XMFLOAT3(-2.5f, -1.0f, -1.5f), XMFLOAT3(-1.5f, -1.0f, -2.0f), XMFLOAT3(-2.5f, 1.0f, -1.5f));
            break;
        case 2:
            target = ref new Face(XMFLOAT3(-1.0f, 1.0f, -3.0f), XMFLOAT3(0.0f, 1.0f, -3.0f), XMFLOAT3(-1.0f, 2.0f, -3.0f));
            break;
        case 3:
            target = ref new Face(XMFLOAT3(1.5f, 0.0f, -3.0f), XMFLOAT3(2.5f, 0.0f, -2.0f), XMFLOAT3(1.5f, 2.0f, -3.0f));
            break;
        case 4:
            target = ref new Face(XMFLOAT3(-2.5f, -1.0f, -5.5f), XMFLOAT3(-0.5f, -1.0f, -5.5f), XMFLOAT3(-2.5f, 1.0f, -5.5f));
            break;
        case 5:
            target = ref new Face(XMFLOAT3(0.5f, -2.0f, -5.0f), XMFLOAT3(1.5f, -2.0f, -5.0f), XMFLOAT3(0.5f, 0.0f, -5.0f));
            break;
        case 6:
            target = ref new Face(XMFLOAT3(1.5f, -2.0f, -5.5f), XMFLOAT3(2.5f, -2.0f, -5.0f), XMFLOAT3(1.5f, 0.0f, -5.5f));
            break;
        case 7:
            target = ref new Face(XMFLOAT3(0.0f, 0.0f, 0.0f), XMFLOAT3(0.5f, 0.0f, 0.0f), XMFLOAT3(0.0f, 0.5f, 0.0f));
            break;
        case 8:
            target = ref new Face(XMFLOAT3(0.0f, 0.0f, 0.0f), XMFLOAT3(0.5f, 0.0f, 0.0f), XMFLOAT3(0.0f, 0.5f, 0.0f));
            break;
        case 9:
            target = ref new Face(XMFLOAT3(0.0f, 0.0f, 0.0f), XMFLOAT3(0.5f, 0.0f, 0.0f), XMFLOAT3(0.0f, 0.5f, 0.0f));
            break;
        }

        target->Target(true);
        target->TargetId(a);
        target->Active(true);
        target->HitSound(ref new SoundEffect());
        target->HitSound()->Initialize(
            m_audioController->SoundEffectEngine(),
            mediaReader->GetOutputWaveFormatEx(),
            targetHitSound);

        m_object.push_back(target);
        m_renderObject.push_back(target);
    }

    // Instantiate a set of spheres to be used as ammunition for the game
    // and set the material properties of the spheres.
    auto ammoHitSound = mediaReader->LoadMedia("bounce.wav");

    for (int a = 0; a < GameConstants::MaxAmmo; a++)
    {
        m_ammo[a] = ref new Sphere;
        m_ammo[a]->Radius(GameConstants::AmmoRadius);
        m_ammo[a]->HitSound(ref new SoundEffect());
        m_ammo[a]->HitSound()->Initialize(
            m_audioController->SoundEffectEngine(),
            mediaReader->GetOutputWaveFormatEx(),
            ammoHitSound);
        m_ammo[a]->Active(false);
        m_renderObject.push_back(m_ammo[a]);
    }

    // Instantiate each of the game levels.  The Level class contains methods
    // that initialize the objects in the world for the given level and also
    // define any motion paths for the objects in that level.

    m_level.push_back(ref new Level1);
    m_level.push_back(ref new Level2);
    m_level.push_back(ref new Level3);
    m_level.push_back(ref new Level4);
    m_level.push_back(ref new Level5);
    m_level.push_back(ref new Level6);
    m_levelCount = static_cast<uint32>(m_level.size());

    // Load the top score from disk if it exists.
    LoadHighScore();

    // Load the currentScore for saved state.
    LoadState();

    m_controller->Active(false);
}
```

サンプル ゲームでは、次の順序に従ってゲーム オブジェクトのコンポーネントをセットアップします。

1.  新規のオーディオ再生オブジェクトを作成します。
2.  一連のレベル プリミティブ、弾薬、障害物を含む、ゲームのグラフィック プリミティブの配列を作成します。
3.  ゲーム状態データを保存する場所を作成し、*Game* という名前を付け、[**ApplicationData::Current**](https://msdn.microsoft.com/library/windows/apps/br241619) で指定するアプリ データ設定ストレージの場所に格納します。
4.  ゲーム タイマーと初期ゲーム内オーバーレイ ビットマップを作成します。
5.  具体的なビュー パラメーターとプロジェクション パラメーター セットを使って新規のカメラを作成します。
6.  プレーヤーがコントロール開始位置とカメラ位置の 1 対 1 の対応を確保されるように、入力デバイス (コントローラー) をカメラと同じ位置に上下と左右の開始位置を設定します。
7.  プレーヤー オブジェクトを作成し、アクティブに設定します。 球体を使って、壁や障害物に近接するプレーヤーを検出したり、没入感を阻害するような位置にカメラが入り込むのを阻止したりします。
8.  ゲーム ワールド プリミティブを作成します。
9.  円筒形の障害物を作成します。
10. 標的 (**Face** オブジェクト) を作成し、番号を付けます。
11. 弾薬の球体を作成します。
12. レベルを作成します。
13. ハイ スコアを読み込みます。
14. 以前に保存されたゲーム状態を読み込みます。

ゲームには既に、ワールド、プレーヤー、障害物、標的、弾薬の球体の主要コンポーネントのインスタンスが存在します。 これらの全コンポーネントの設定と個々の固有レベルに対する動作を表すレベルのインスタンスもあります。 ゲームでどのようにレベルが構築されるのかを見てみます。

## ゲーム レベルの構築と読み込み


レベル構築に伴う作業の大部分は **Level.h/.cpp** ファイルで行われます。これについては、きわめて専門的な実装を伴うため、ここでは詳しい説明は省略します。 重要な点は、各レベルのコードがそれぞれ個別の **LevelN** オブジェクトとして実行されるということです。 ゲームを拡張する場合は、割り当てられている数字をパラメーターとして解釈し、障害物と標的を無作為に配置していた **Level** オブジェクトを作成することができます。 または、リソース ファイルからレベルの設定データを読み込ませることもできます。インターネットからも入手可能です。

**Level.h/.cpp** の完全なコードは、[このセクションのサンプル コード一式](#code_sample)に示します。

## ゲーム プレイの定義


この時点でゲームのアセンブルに必要なコンポーネントがすべて揃います。 レベルは、既にプリミティブに基づいてメモリ中に構築されており、プレーヤーが何かしらの形式でやり取りを開始する準備ができています。

優れたゲームでは、プレーヤーからの入力に即座に反応し、瞬時のフィードバックを戻せることが条件となります。 これは、トゥイッチ アクションやリアルタイムのシューティング ゲームをはじめ、ターン制の思考型の戦略ゲームに至るまで、あらゆる種類のゲームに言えることです。

「[ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義](tutorial--building-the-games-metro-style-app-framework.md)」では、ゲームのフローを制御する総合的なステート マシンについて説明してあります。 なお、サンプルではこのフローが **App** クラスの [**Run**](https://msdn.microsoft.com/library/windows/apps/hh702093) メソッド内部にあるループとして実装されており、これ自体が DirectX ビュー プロバイダーの実装として存在することに注意してください。 重要な状態の切り替えはプレーヤーがコントロールし、それに対して明確なフィードバックが戻される必要があります。 このフィードバックに遅れが生じると、プレーヤーはゲームに熱中できなくなります。

以下にゲームの基本フローと上位レベルの状態を表す図を示します。

![ゲームのメイン ステート マシンを示す図](images/simple3dgame-mainstatemachine.png)

サンプル ゲームのプレイが開始すると、ゲーム オブジェクトは次のいずれかの状態に置かれます。

-   **Waiting for resources**。 この状態は、ゲーム オブジェクトが初期化された時点、またはレベルのコンポーネントが読み込まれた時点でアクティブになります。 この状態が、以前のゲームの読み込み要求によってトリガーされた場合は、ゲーム統計のオーバーレイが表示されます。レベルのプレイ要求によってトリガーされた場合は、レベル開始のオーバーレイが表示されます。 リソースの読み込みが完了すると、**Resources loaded** 状態を経て、**Waiting for press** 状態に移行します。
-   **Waiting for press**。 この状態は、プレーヤーまたはシステムによってゲームが一時停止されるとアクティブになります (たとえば、リソースの読み込み後など)。 プレーヤーがこの状態を終了する準備ができている場合、プレーヤーは、新たにゲーム状態を読み込む (LoadGame)、読み込まれたレベルを開始または再開する (StartLevel)、現在のレベルを続行する (ContinueGame) のいずれかを選ぶように要求されます。
-   **Dynamics**。 プレーヤーによる押下入力が終わり、レベルの開始または続行のアクションが選ばれた場合、ゲーム オブジェクトは *Dynamics* の状態に移ります。 ゲームはこの状態でプレイされ、ゲーム ワールドとプレーヤーの各オブジェクトが、アニメーション ルーチンとプレーヤー入力に従って更新されます。 この状態は、プレーヤーが P を押す、メイン ウィンドウを非アクティブにする、レベルをクリアする、ゲームを終了する、のいずれかの操作によって一時停止イベントがトリガーされると終了します。

ここで、このステート マシンを実装する **Update** メソッドに対する **App** クラス (「[ゲームのユニバーサル Windows プラットフォーム (UWP) アプリ フレームワークの定義](tutorial--building-the-games-metro-style-app-framework.md)」をご覧ください) の具体的なコードを見てみましょう。

```cpp
void App::Update()
{
    static uint32 loadCount = 0;

    m_controller->Update();

    switch (m_updateState)
    {
    case UpdateEngineState::WaitingForResources:
        // Waiting for initial load.  Display an update one time per 60 updates.
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
```

このメソッドではまず、[MoveLookController](tutorial--adding-controls.md) インスタンスの固有の **Update** メソッドを呼び出し、コントローラーからのデータを更新します。 このデータには、プレーヤー ビュー (カメラ) が向いている方向やプレーヤーの動きの速度などが含まれます。

ゲームが Dynamics の状態にある場合、つまりプレーヤーがプレイ中の場合に、この呼び出しによって作業は **RunGame** メソッドの中で処理されます。

`GameState runState = m_game->RunGame();`

**RunGame** はゲーム ループの現在行われている反復に対するゲーム プレイの最新状態を定義する一連のデータを処理します。 次のようなフローになります。

1.  メソッドは、レベルが終了するまでの間、残り時間を秒数でカウント ダウンするタイマーを更新し、レベルの時間が過ぎていないかをテストします。 これは、ゲームのルールの 1 つです。標的を全部撃ち落とす前に時間切れになると、ゲーム オーバーになります。
2.  時間切れになると、メソッドは **TimeExpired** ゲーム状態を設定し、前のコードの **Update** メソッドに戻ります。
3.  時間が残っている場合は、ムーブ/ルック コントローラーがポーリングを行って、カメラ位置に更新がないかどうかを確認します。具体的には、カメラ平面 (プレーヤーが見ている面) の延長上にあるビュー法線の角度や、前回のコントローラーのポーリング時からの角度の移動距離が更新されていないかどうかを確認します。
4.  カメラは、ムーブ/ルック コントローラーから送られる新しいデータに従って更新されます。
5.  ダイナミクス、つまりプレーヤーのコントロールからは独立したゲーム ワールド中のオブジェクトのアニメーションや動作が更新されます。 ゲーム サンプルでは、発射された弾丸の動き、柱の障害物のアニメーション、標的の移動などのことです。
6.  メソッドが、レベルの正常な完了に関する基準が満たされているかどうかをチェックします。 満たされていれば、レベルのスコアをファイナライズし、これが最後のレベル (全 6 レベル) であるかどうかを判断します。 最後のレベルであれば、**GameComplete** ゲーム状態を返します。そうでない場合は、**LevelComplete** ゲーム状態を返します。
7.  レベルが完了していない場合は、ゲーム状態を **Active** に設定し、戻ります。

**Simple3DGame.cpp** にある **RunGame** は次のようなコードです。

```cpp
GameState Simple3DGame::RunGame()
{
    m_timer->Update();

    m_levelTimeRemaining = m_levelDuration - m_timer->PlayingTime();

    if (m_levelTimeRemaining <= 0.0f)
    {
        // Time expired, so the game is over.
        m_levelTimeRemaining = 0.0f;
        InitializeAmmo();
        m_timer->Reset();
        m_gameActive = false;
        m_levelActive = false;
        SaveState();

        if (m_totalHits > m_topScore.totalHits)
        {
            m_topScore.totalHits = m_totalHits;
            m_topScore.totalShots = m_totalShots;
            m_topScore.levelCompleted = m_currentLevel;

            SaveHighScore();
        }
        return GameState::TimeExpired;
    }
    else
    {
        // Time has not expired, so run one frame of game play.
        m_player->Velocity(m_controller->Velocity());
        m_camera->LookDirection(m_controller->LookDirection());

        UpdateDynamics();

        // Update the camera with the player position updates from the dynamics calculations.
        m_camera->Eye(m_player->Position());
        m_camera->LookDirection(m_controller->LookDirection());

        if (m_level[m_currentLevel]->Update(m_timer->PlayingTime(), m_timer->DeltaTime(), m_levelTimeRemaining, m_object))
        {
            // The level has been completed.
            m_levelActive = false;
            InitializeAmmo();

            if (m_currentLevel < m_levelCount-1)
            {
                // More levels to go so increment the level number.
                // Actual level loading will occur in the LoadLevelAsync / FinalizeLoadLevel
                // methods.
                m_timer->Reset();
                m_currentLevel++;
                m_levelBonusTime = m_levelTimeRemaining;
                SaveState();
                return GameState::LevelComplete;
            }
            else
            {
                // All levels have been completed.
                m_timer->Reset();
                m_gameActive = false;
                m_levelActive = false;
                SaveState();

                if (m_totalHits > m_topScore.totalHits)
                {
                    m_topScore.totalHits = m_totalHits;
                    m_topScore.totalShots = m_totalShots;
                    m_topScore.levelCompleted = m_currentLevel;

                    SaveHighScore();
                }
                return GameState::GameComplete;
            }
        }
    }
    return GameState::Active;
}}
```

キー コールは次のとおりです。`UpdateDynamics()`。 ここがゲーム ワールドに命を吹き込む部分です。 その内容を確認してみましょう。

## ゲーム ワールドの更新


迅速で流れるようなゲーム エクスペリエンスこそ、ゲーム自体がプレーヤーからの入力から独立した動きを見せる*生き生きとした*世界を再現するための鍵となります。 木々が風になびき、波が海岸に打ち上げ、機械が煙りを上げ、光を発し、異星の怪物が身を伸ばしてはよだれを垂らすなど、動きのある描写が行われます。 ゲームの背景がすべて静止していて、プレーヤーが入力したときにだけ画像が動くとしたら、どのような印象になるのでしょう。 動きが不自然で、あまり魅力的とは言えないでしょう。 プレーヤーは、息をのむような生き生きとした世界にいる感覚を得られてこそ夢中になります。

ゲーム ループでは、一時停止が指定された場合を除き、常にゲーム ワールドを更新し、アニメーション ルーチンを実行していることが求められます。これがキャンド ルーチンであるか、物理アルゴリズムに従ったものであるか、また単に無作為な動きであるかは問いません。 ゲーム サンプルでは、この原理のことを*ダイナミクス*と呼んでいます。これにより、柱の障害物の上下の動き、発砲時に見られる弾薬の球体の動きや物理的動作が統合されます。 また、プレーヤーの球体とワールドの間、または弾薬、障害物、標的の間に生じる衝突を含め、物体どうしの相互作用も統合されます。

こうしたダイナミクスを実装するコードは次のとおりです。

```cpp
void Simple3DGame::UpdateDynamics()
{
    float timeTotal = m_timer->PlayingTime();
    float timeFrame = m_timer->DeltaTime();
    bool fire = m_controller->IsFiring();

#pragma region Shoot Ammo
    // Shoot ammo.
    if (fire)
    {
        static float lastFired;  // Timestamp of the last ammo fired.

        if (timeTotal < lastFired)
        {
            // timeTotal is not guarenteed to be monotomically increasing because it is
            // reset at each level.
            lastFired = timeTotal - GameConstants::Physics::AutoFireDelay;
        }

        if (timeTotal - lastFired >= GameConstants::Physics::AutoFireDelay)
        {
           // Compute the ammo firing behavior.
        }
    }
#pragma endregion

#pragma region Animate Objects
    for (uint32 i = 0; i < m_object.size(); i++)
    {
        if (m_object[i]->AnimatePosition())
        {
            // Animate targets and cylinders based on level parameters and global constants.
        }
    }
#pragma endregion

    // If the elapsed time is too long, we slice up the time and
    // handle physics over several passes.
    float timeLeft = timeFrame;
    float elapsedFrameTime;
    while (timeLeft > 0.0f)
    {
        elapsedFrameTime = min(timeLeft, GameConstants::Physics::FrameLength);
        timeLeft -= elapsedFrameTime;

        // Update the player position.
        m_player->Position(m_player->VectorPosition() + m_player->VectorVelocity() * elapsedFrameTime);

        // Do m_player / object intersections.
        for (uint32 a = 0; a < m_object.size(); a++)
        {
            if (m_object[a]->Active() && m_object[a] != m_player)
            {
                XMFLOAT3 contact;
                XMFLOAT3 normal;

                if (m_object[a]->IsTouching(m_player->Position(), m_player->Radius(), &contact, &normal))
                {
                    XMVECTOR oneToTwo;
                    oneToTwo = -XMLoadFloat3(&normal);

                    // The player is in contact with Object
                    float impact;
                    impact = XMVectorGetX(
                        XMVector3Dot (oneToTwo, m_player->VectorVelocity())
                        );
                    // Make sure that the player is actually headed towards the object at grazing angles; there
                    // could appear to be an impact when the player is actually already hit and moving away.
                    if (impact > 0.0f)
                    {
                        // Compute the normal and tangential components of the player's velocity.
                        XMVECTOR velocityOneNormal = XMVector3Dot(oneToTwo, m_player->VectorVelocity()) * oneToTwo;
                        XMVECTOR velocityOneTangent = m_player->VectorVelocity() - velocityOneNormal;

                        // Compute the post-collision velocity.
                        m_player->Velocity(velocityOneTangent - velocityOneNormal);

                        // Fix the positions so that the ball is exactly GameConstants::AmmoRadius from target.
                        float distanceToMove = m_player->Radius();
                        m_player->Position(XMLoadFloat3(&contact) - (oneToTwo * distanceToMove));
                    }
                }
            }
        }
        {
            // Do collision detection of the player with the bounding world.
            XMFLOAT3 position = m_player->Position();
            XMFLOAT3 velocity = m_player->Velocity();
            float radius = m_player->Radius();

            // Check for player collisions with the walls, floor, or ceiling
            // and adjust the position.

            float limit = m_minBound.x + radius;
            if (position.x < limit)
            {
                position.x = limit;
                velocity.x = -velocity.x * GameConstants::Physics::GroundRestitution;
            }
            limit = m_maxBound.x - radius;
            if (position.x > limit)
            {
                position.x = limit;
                velocity.x = -velocity.x + GameConstants::Physics::GroundRestitution;
            }
            limit = m_minBound.y + radius;
            if (position.y < limit)
            {
                position.y = limit;
                velocity.y = -velocity.y * GameConstants::Physics::GroundRestitution;
            }
            limit = m_maxBound.y - radius;
            if (position.y > limit)
            {
                position.y = limit;
                velocity.y = -velocity.y * GameConstants::Physics::GroundRestitution;
            }
            limit = m_minBound.z + radius;
            if (position.z < limit)
            {
                position.z = limit;
                velocity.z = -velocity.z * GameConstants::Physics::GroundRestitution;
            }
            limit = m_maxBound.z - radius;
            if (position.z > limit)
            {
                position.z = limit;
                velocity.z = -velocity.z * GameConstants::Physics::GroundRestitution;
            }
            m_player->Position(position);
            m_player->Velocity(velocity);
        }

        // Animate the ammo.
        if (m_ammoCount > 0)
        {
            // Check for inter-ammo collision.
#pragma region inter-ammo collision detection
            if (m_ammoCount > 1)
            {
                for (uint32 one = 0; one < m_ammoCount; one++)
                {
                    for (uint32 two = (one + 1); two < m_ammoCount; two++)
                    {
                        // Compute checks for collisions for each ammo object with the other active ammo objects.
                    }
                }
            }
#pragma endregion

#pragma region Ammo-Object intersections
            // Check for intersections with Objects.
            for (uint32 one = 0; one < m_ammoCount; one++)
            {
                // Compute ammo collisions with game objects (targets, cylinders, walls).
            }
#pragma endregion

#pragma region Apply Gravity and world intersection
            // Apply gravity and check for collision against ground and walls.
            for (uint32 i = 0; i < m_ammoCount; i++)
            {
                                                      // Compute the effect of gravity on the ammo, and any ammo collisions with the world objects (walls, floor).
            }
        }
    }

}
```

(このコード例は、わかりやすいように省略したものです。 動作する完全なコードは、このトピックの末尾のコード サンプル一式に掲載しています)

このメソッドは、次の 4 種類の計算を行います。

-   ワールドで発砲された弾薬の球体の位置
-   柱の障害物のアニメーション
-   プレーヤーとワールドの境界の交差部分
-   弾薬の球体と、障害物、標的、他の弾薬球体、ワールドとの衝突

障害物のアニメーションは、**Animate.h/.cpp** で定義されたループとして実行されます。 弾薬と衝突の動作は、簡略化した物理アルゴリズムで定義され、従来のコードから提供されます。また、重力や素材のプロパティも含め、ゲーム ワールドに対する一連のグローバル定数によってパラメーター化されます。 これはすべて、ゲーム ワールドの座標空間で計算されます。

これでシーン中のオブジェクトがすべて更新され、すべての衝突が計算されたため、この情報を使って対応するビジュアルの変更を描画します。 サンプルでは、ゲーム ループの現在の反復中で更新が完了すると直ちに、**Render** を呼び出して更新されたオブジェクト データを使用して新しいシーンを生成し、プレーヤーに提示します。

ここでレンダリングのメソッドを見てみましょう。

## ゲーム ワールド グラフィックスのレンダリング


ゲーム中のグラフィックスはできるだけ頻繁 (最大ではメインのゲーム ループが反復するごと) に更新することをお勧めします。 ループが反復するごとに、プレーヤーからの入力の有無を問わず、ゲームを更新します。 これにより、計算するアニメーションと動作がスムーズに表示されるようになります。 たとえば、プレーヤーがボタンを押したときにのみ、水が流れるという単純なシーンを思い浮かべてください。 ひどくつまらないビジュアルになるでしょう。 優れたゲームは、流れるような自然の動きを伴うものです。

以下に示すような簡単なゲーム ループを例に取ります。 ゲームのメイン ウィンドウが表示されていて、スナップされたり、非アクティブにされたりしなければ、ゲームはそのまま、その更新結果の更新とレンダリングを続けます。

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
```

ここで検証するメソッドでは、**Update** を呼び出した後、状態が **Run** によって更新された直後の状態を表すレンダリングが行われます。これについては、前のセクションで説明したとおりです。

```cpp
void GameRenderer::Render()
{
    int renderingPasses = 1;
    if (m_stereoEnabled)
    {
        renderingPasses = 2;
    }

    for (int i = 0; i < renderingPasses; i++)
    {
        if (m_stereoEnabled && i > 0)
        {
            // Doing the Right Eye View
            m_d3dContext->OMSetRenderTargets(1, m_renderTargetViewRight.GetAddressOf(), m_depthStencilView.Get());
            m_d3dContext->ClearDepthStencilView(m_depthStencilView.Get(), D3D11_CLEAR_DEPTH, 1.0f, 0);
            m_d2dContext->SetTarget(m_d2dTargetBitmapRight.Get());
        }
        else
        {
            // Doing the Mono or Left Eye View
            m_d3dContext->OMSetRenderTargets(1, m_renderTargetView.GetAddressOf(), m_depthStencilView.Get());
            m_d3dContext->ClearDepthStencilView(m_depthStencilView.Get(), D3D11_CLEAR_DEPTH, 1.0f, 0);
            m_d2dContext->SetTarget(m_d2dTargetBitmap.Get());
        }

        if (m_game != nullptr && m_gameResourcesLoaded && m_levelResourcesLoaded)
        {
            // This section is only used after the game state has been initialized and all device
            // resources needed for the game have been created and associated with the game objects.
            if (m_stereoEnabled)
            {
                ConstantBufferChangeOnResize changesOnResize;
                XMStoreFloat4x4(
                    &changesOnResize.projection,
                    XMMatrixMultiply(
                        XMMatrixTranspose(
                            i == 0 ?
                            m_game->GameCamera()->LeftEyeProjection() :
                            m_game->GameCamera()->RightEyeProjection()
                            ),
                        XMMatrixTranspose(XMLoadFloat4x4(&m_rotationTransform3D))
                        )
                    );

                m_d3dContext->UpdateSubresource(
                    m_constantBufferChangeOnResize.Get(),
                    0,
                    nullptr,
                    &changesOnResize,
                    0,
                    0
                    );
            }
            // Update variables that change one time per frame.

            ConstantBufferChangesEveryFrame constantBufferChangesEveryFrame;
            XMStoreFloat4x4(
                &constantBufferChangesEveryFrame.view,
                XMMatrixTranspose(m_game->GameCamera()->View())
                );
            m_d3dContext->UpdateSubresource(
                m_constantBufferChangesEveryFrame.Get(),
                0,
                nullptr,
                &constantBufferChangesEveryFrame,
                0,
                0
                );

            // Set up the Pipeline.

            m_d3dContext->IASetInputLayout(m_vertexLayout.Get());
            m_d3dContext->VSSetConstantBuffers(0, 1, m_constantBufferNeverChanges.GetAddressOf());
            m_d3dContext->VSSetConstantBuffers(1, 1, m_constantBufferChangeOnResize.GetAddressOf());
            m_d3dContext->VSSetConstantBuffers(2, 1, m_constantBufferChangesEveryFrame.GetAddressOf());
            m_d3dContext->VSSetConstantBuffers(3, 1, m_constantBufferChangesEveryPrim.GetAddressOf());

            m_d3dContext->PSSetConstantBuffers(2, 1, m_constantBufferChangesEveryFrame.GetAddressOf());
            m_d3dContext->PSSetConstantBuffers(3, 1, m_constantBufferChangesEveryPrim.GetAddressOf());
            m_d3dContext->PSSetSamplers(0, 1, m_samplerLinear.GetAddressOf());

            // Get all the objects to render from the Game state.
            auto objects = m_game->RenderObjects();
            for (auto object = objects.begin(); object != objects.end(); object++)
            {
                (*object)->Render(m_d3dContext.Get(), m_constantBufferChangesEveryPrim.Get());
            }
        }
        else
        {
            const float ClearColor[4] = {0.1f, 0.1f, 0.1f, 1.0f};

            // Only need to clear the background when not rendering the full 3D scene because
            // the 3D world is a fully enclosed box, and the dynamics prevents the camera from
            // moving outside this space.
            if (m_stereoEnabled && i > 0)
            {
                // Doing the Right Eye View.
                m_d3dContext->ClearRenderTargetView(m_renderTargetViewRight.Get(), ClearColor);
            }
            else
            {
                // Doing the Mono or Left Eye View.
                m_d3dContext->ClearRenderTargetView(m_renderTargetView.Get(), ClearColor);
            }
        }

        m_d2dContext->BeginDraw();

        // To handle the swapchain being pre-rotated, set the D2D transformation to include it.
        m_d2dContext->SetTransform(m_rotationTransform2D);

        if (m_game != nullptr && m_gameResourcesLoaded)
        {
            // This is only used after the game state has been initialized.
            m_gameHud->Render(m_game, m_d2dContext.Get(), m_windowBounds);
        }

        if (m_gameInfoOverlay->Visible())
        {
            m_d2dContext->DrawBitmap(
                m_gameInfoOverlay->Bitmap(),
                D2D1::RectF(
                    (m_windowBounds.Width - GameInfoOverlayConstant::Width)/2.0f,
                    (m_windowBounds.Height - GameInfoOverlayConstant::Height)/2.0f,
                    (m_windowBounds.Width - GameInfoOverlayConstant::Width)/2.0f + GameInfoOverlayConstant::Width,
                    (m_windowBounds.Height - GameInfoOverlayConstant::Height)/2.0f + GameInfoOverlayConstant::Height
                    )
                );
        }

        HRESULT hr = m_d2dContext->EndDraw();
        if (hr != D2DERR_RECREATE_TARGET)
        {
            // The D2DERR_RECREATE_TARGET indicates there has been a problem with the underlying
            // D3D device.  All subsequent rendering will be ignored until the device is recreated.
            // This error will be propagated and the appropriate D3D error will be returned from the
            // swapchain->Present(...) call.   At that point, the sample will recreate the device
            // and all associated resources.  As a result the D2DERR_RECREATE_TARGET doesn't
            // need to be handled here.
            DX::ThrowIfFailed(hr);
        }
    }
    Present();
}
```

このメソッドの完全なコードは、「[レンダリング フレームワークの作成](tutorial--assembling-the-rendering-pipeline.md)」に示しています。

このメソッドではまず 3D ワールドのプロジェクションが描画され、続いてその上に Direct2D オーバーレイが描画されます。 描画が完了すると、表示用に結合されたバッファーとともに最終的なスワップ チェーンが表示されます。

サンプル ゲームの Direct2D オーバーレイには 2 つの状態が存在します。1 つは一時停止メニューのビットマップを含むゲーム情報オーバーレイを表示する状態、もう 1 つはタッチスクリーンのムーブ/ルック コントローラーの長方形とクロスヘアを表示する状態です。 両方の状態でスコア テキストが描画されます。

## 次のステップ


ここまでの説明で、実際のレンダリング エンジンについて、すなわち更新されたプリミティブで **Render** メソッドを呼び出した場合、これが画面上のピクセルでどのように表現されるのかについて関心を持たれていることでしょう。 これについては、「[レンダリング フレームワークのアセンブル](tutorial--assembling-the-rendering-pipeline.md)」で詳しく説明します。 またプレーヤー コントロールによってゲーム状態がどのように更新されるのかについては、「[コントロールの追加](tutorial--adding-controls.md)」をご覧ください。

## このセクションのコード サンプル一式


Simple3DGame.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Game specific Classes
#include "GameConstants.h"
#include "Audio.h"
#include "Camera.h"
#include "Level.h"
#include "GameObject.h"
#include "GameTimer.h"
#include "MoveLookController.h"
#include "PersistentState.h"
#include "Sphere.h"
#include "GameRenderer.h"

//--------------------------------------------------------------------------------------

enum class GameState
{
    Waiting,
    Active,
    LevelComplete,
    TimeExpired,
    GameComplete,
};

typedef struct
{
    Platform::String^ tag;
    int totalHits;
    int totalShots;
    int levelCompleted;
} HighScoreEntry;

typedef std::vector<HighScoreEntry> HighScoreEntries;

//--------------------------------------------------------------------------------------

ref class GameRenderer;

ref class Simple3DGame
{
internal:
    Simple3DGame();

    void Initialize(
        _In_ MoveLookController^ controller,
        _In_ GameRenderer^ renderer
        );

    void LoadGame();
    concurrency::task<void> LoadLevelAsync();
    void FinalizeLoadLevel();
    void StartLevel();
    void PauseGame();
    void ContinueGame();
    GameState RunGame();

    void OnSuspending();
    void OnResuming();

    bool IsActivePlay()                         { return m_timer->Active(); }
    int LevelCompleted()                        { return m_currentLevel; };
    int TotalShots()                            { return m_totalShots; };
    int TotalHits()                             { return m_totalHits; };
    float BonusTime()                           { return m_levelBonusTime; };
    bool GameActive()                           { return m_gameActive; };
    bool LevelActive()                          { return m_levelActive; };
    HighScoreEntry HighScore()                  { return m_topScore; };
    Level^ CurrentLevel()                       { return m_level[m_currentLevel]; };
    float TimeRemaining()                       { return m_levelTimeRemaining; };
    Camera^ GameCamera()                        { return m_camera; };
    std::vector<GameObject^> RenderObjects()    { return m_renderObject; };

private:
    void LoadState();
    void SaveState();
    void SaveHighScore();
    void LoadHighScore();
    void InitializeAmmo();
    void UpdateDynamics();

    MoveLookController^                                 m_controller;
    GameRenderer^                                       m_renderer;
    Camera^                                             m_camera;

    Audio^                                              m_audioController;

    std::vector<Sphere^>                                m_ammo;
    uint32                                              m_ammoCount;
    uint32                                              m_ammoNext;

    HighScoreEntry                                      m_topScore;
    PersistentState^                                    m_savedState;

    GameTimer^                                          m_timer;
    bool                                                m_gameActive;
    bool                                                m_levelActive;
    int                                                 m_totalHits;
    int                                                 m_totalShots;
    float                                               m_levelDuration;
    float                                               m_levelBonusTime;
    float                                               m_levelTimeRemaining;
    std::vector<Level^>                                 m_level;
    uint32                                              m_levelCount;
    uint32                                              m_currentLevel;

    Sphere^                                             m_player;
    std::vector<GameObject^>                            m_object;           // Object list for intersections
    std::vector<GameObject^>                            m_renderObject;     // All objects to be rendered

    DirectX::XMFLOAT3                                   m_minBound;
    DirectX::XMFLOAT3                                   m_maxBound;
};
```

Simple3DGame.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "GameRenderer.h"

#include "DirectXSample.h"
#include "Level1.h"
#include "Level2.h"
#include "Level3.h"
#include "Level4.h"
#include "Level5.h"
#include "Level6.h"
#include "Animate.h"
#include "Sphere.h"
#include "Cylinder.h"
#include "Face.h"
#include "MediaReader.h"

using namespace concurrency;
using namespace DirectX;
using namespace Microsoft::WRL;
using namespace Windows::Storage;
using namespace Windows::UI::Core;

//----------------------------------------------------------------------

Simple3DGame::Simple3DGame():
    m_ammoCount(0),
    m_ammoNext(0),
    m_gameActive(false),
    m_levelActive(false),
    m_totalHits(0),
    m_totalShots(0),
    m_levelBonusTime(0.0),
    m_levelTimeRemaining(0.0),
    m_levelCount(0),
    m_currentLevel(0)
{
    m_topScore.totalHits = 0;
    m_topScore.totalShots = 0;
    m_topScore.levelCompleted = 0;
}

//----------------------------------------------------------------------

void Simple3DGame::Initialize(
    _In_ MoveLookController^ controller,
    _In_ GameRenderer^ renderer
    )
{
    // This method is expected to be called as an asynchronous task.
    // Make sure that you don't call rendering methods on the
    // m_renderer, as this would result in the D3D Context being
    // used in multiple threads, which is not allowed.

    m_controller = controller;
    m_renderer = renderer;

    m_audioController = ref new Audio;
    m_audioController->CreateDeviceIndependentResources();

    m_ammo = std::vector<Sphere^>(GameConstants::MaxAmmo);
    m_object = std::vector<GameObject^>();
    m_renderObject = std::vector<GameObject^>();
    m_level = std::vector<Level^>();

    m_savedState = ref new PersistentState();
    m_savedState->Initialize(ApplicationData::Current->LocalSettings->Values, "Game");

    m_timer = ref new GameTimer();

    // Create a sphere primitive to represent the player.
    // The sphere will be used to handle collisions and constrain the player in the world.
    // It is not rendered, so it is not added to the list of render objects.
    m_player = ref new Sphere(XMFLOAT3(0.0f, -1.3f, 4.0f), 0.2f);

    m_camera = ref new Camera;
    m_camera->SetProjParams(XM_PI / 2, 1.0f, 0.01f, 100.0f);
    m_camera->SetViewParams(
        m_player->Position(),            // Eye point in world coordinates.
        XMFLOAT3 (0.0f, 0.7f, 0.0f),     // Look at point in world coordinates.
        XMFLOAT3 (0.0f, 1.0f, 0.0f)      // The Up vector for the camera.
        );

    m_controller->Pitch(m_camera->Pitch());
    m_controller->Yaw(m_camera->Yaw());

    // Add the m_player object to the object list to do intersection calculations.
    m_object.push_back(m_player);
    m_player->Active(true);

    // Instantiate the world primitive.  This object maintains the geometry and
    // material properties of the walls, floor, and ceiling of the enclosing world.
    // The TargetId is used to identify the world objects, so that the right geometry
    // and textures can be associated with them later after those resources have
    // been created.
    GameObject^ world = ref new GameObject();
    world->TargetId(GameConstants::WorldFloorId);
    world->Active(true);
    m_renderObject.push_back(world);

    world = ref new GameObject();
    world->TargetId(GameConstants::WorldCeilingId);
    world->Active(true);
    m_renderObject.push_back(world);

    world = ref new GameObject();
    world->TargetId(GameConstants::WorldWallsId);
    world->Active(true);
    m_renderObject.push_back(world);

    // Min and max Bound are defining the world space of the game.
    // All camera motion and dynamics are confined to this space.
    m_minBound = XMFLOAT3(-4.0f, -3.0f, -6.0f);
    m_maxBound = XMFLOAT3(4.0f, 3.0f, 6.0f);

    // Instantiate the Cylinders for use in the various game levels.
    // Each cylinder has a different initial position, radius and direction vector,
    // but share a common set of material properties.
    for (int a = 0; a < GameConstants::MaxCylinders; a++)
    {
        Cylinder^ cylinder;
        switch (a)
        {
        case 0:
            cylinder = ref new Cylinder(XMFLOAT3(-2.0f, -3.0f, 0.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 1:
            cylinder = ref new Cylinder(XMFLOAT3(2.0f, -3.0f, 0.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 2:
            cylinder = ref new Cylinder(XMFLOAT3(0.0f, -3.0f, -2.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 3:
            cylinder = ref new Cylinder(XMFLOAT3(-1.5f, -3.0f, -4.0f), 0.25f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        case 4:
            cylinder = ref new Cylinder(XMFLOAT3(1.5f, -3.0f, -4.0f), 0.50f, XMFLOAT3(0.0f, 6.0f, 0.0f));
            break;
        }
        cylinder->Active(true);
        m_object.push_back(cylinder);
        m_renderObject.push_back(cylinder);
    }

    MediaReader^ mediaReader = ref new MediaReader;
    auto targetHitSound = mediaReader->LoadMedia("hit.wav");

    // Instantiate the targets for use in the game.
    // Each target has a different initial position, size and orientation,
    // but share a common set of material properties.
    // The target is defined by a position and two vectors that define both
    // the plane of the target in world space and the size of the parallelogram
    // based on the lengths of the vectors.
    // Each target is assigned a number for identification purposes.
    // The Target ID number is 1 based.
    // All targets has the same material properties.
    for (int a = 1; a < GameConstants::MaxTargets; a++)
    {
        Face^ target;
        switch (a)
        {
        case 1:
            target = ref new Face(XMFLOAT3(-2.5f, -1.0f, -1.5f), XMFLOAT3(-1.5f, -1.0f, -2.0f), XMFLOAT3(-2.5f, 1.0f, -1.5f));
            break;
        case 2:
            target = ref new Face(XMFLOAT3(-1.0f, 1.0f, -3.0f), XMFLOAT3(0.0f, 1.0f, -3.0f), XMFLOAT3(-1.0f, 2.0f, -3.0f));
            break;
        case 3:
            target = ref new Face(XMFLOAT3(1.5f, 0.0f, -3.0f), XMFLOAT3(2.5f, 0.0f, -2.0f), XMFLOAT3(1.5f, 2.0f, -3.0f));
            break;
        case 4:
            target = ref new Face(XMFLOAT3(-2.5f, -1.0f, -5.5f), XMFLOAT3(-0.5f, -1.0f, -5.5f), XMFLOAT3(-2.5f, 1.0f, -5.5f));
            break;
        case 5:
            target = ref new Face(XMFLOAT3(0.5f, -2.0f, -5.0f), XMFLOAT3(1.5f, -2.0f, -5.0f), XMFLOAT3(0.5f, 0.0f, -5.0f));
            break;
        case 6:
            target = ref new Face(XMFLOAT3(1.5f, -2.0f, -5.5f), XMFLOAT3(2.5f, -2.0f, -5.0f), XMFLOAT3(1.5f, 0.0f, -5.5f));
            break;
        case 7:
            target = ref new Face(XMFLOAT3(0.0f, 0.0f, 0.0f), XMFLOAT3(0.5f, 0.0f, 0.0f), XMFLOAT3(0.0f, 0.5f, 0.0f));
            break;
        case 8:
            target = ref new Face(XMFLOAT3(0.0f, 0.0f, 0.0f), XMFLOAT3(0.5f, 0.0f, 0.0f), XMFLOAT3(0.0f, 0.5f, 0.0f));
            break;
        case 9:
            target = ref new Face(XMFLOAT3(0.0f, 0.0f, 0.0f), XMFLOAT3(0.5f, 0.0f, 0.0f), XMFLOAT3(0.0f, 0.5f, 0.0f));
            break;
        }

        target->Target(true);
        target->TargetId(a);
        target->Active(true);
        target->HitSound(ref new SoundEffect());
        target->HitSound()->Initialize(
            m_audioController->SoundEffectEngine(),
            mediaReader->GetOutputWaveFormatEx(),
            targetHitSound);

        m_object.push_back(target);
        m_renderObject.push_back(target);
    }

    // Instantiate a set of spheres to be used as ammunition for the game
    // and set the material properties of the spheres.
    auto ammoHitSound = mediaReader->LoadMedia("bounce.wav");

    for (int a = 0; a < GameConstants::MaxAmmo; a++)
    {
        m_ammo[a] = ref new Sphere;
        m_ammo[a]->Radius(GameConstants::AmmoRadius);
        m_ammo[a]->HitSound(ref new SoundEffect());
        m_ammo[a]->HitSound()->Initialize(
            m_audioController->SoundEffectEngine(),
            mediaReader->GetOutputWaveFormatEx(),
            ammoHitSound);
        m_ammo[a]->Active(false);
        m_renderObject.push_back(m_ammo[a]);
    }

    // Instantiate each of the game levels.  The Level class contains methods
    // that initialize the objects in the world for the given level and also
    // define any motion paths for the objects in that level.

    m_level.push_back(ref new Level1);
    m_level.push_back(ref new Level2);
    m_level.push_back(ref new Level3);
    m_level.push_back(ref new Level4);
    m_level.push_back(ref new Level5);
    m_level.push_back(ref new Level6);
    m_levelCount = static_cast<uint32>(m_level.size());

    // Load the top score from disk if it exists.
    LoadHighScore();

    // Load the currentScore for saved state.
    LoadState();

    m_controller->Active(false);
}

//----------------------------------------------------------------------

void Simple3DGame::LoadGame()
{
    m_player->Position(XMFLOAT3 (0.0f, -1.3f, 4.0f));

    m_camera->SetViewParams(
        m_player->Position(),             // Eye point in world coordinates.
        XMFLOAT3 (0.0f, 0.7f, 0.0f),     // Look at point in world coordinates.
        XMFLOAT3 (0.0f, 1.0f, 0.0f)      // The Up vector for the camera.
        );

    m_controller->Pitch(m_camera->Pitch());
    m_controller->Yaw(m_camera->Yaw());
    m_currentLevel = 0;
    m_levelTimeRemaining = 0.0f;
    m_levelBonusTime = m_levelTimeRemaining;
    m_levelDuration = m_level[m_currentLevel]->TimeLimit() + m_levelBonusTime;
    InitializeAmmo();
    m_totalHits = 0;
    m_totalShots = 0;
    m_gameActive = false;
    m_levelActive = false;
    m_timer->Reset();
}

//----------------------------------------------------------------------

task<void> Simple3DGame::LoadLevelAsync()
{
    // Initialize the level and spin up the async loading of the rendering
    // resources for the level.
    // This will run in a separate thread, so for Direct3D 11, only Device
    // methods are allowed.  Any DeviceContext method calls need to be 
    // done in FinalizeLoadLevel.

    m_level[m_currentLevel]->Initialize(m_object);
    m_levelDuration = m_level[m_currentLevel]->TimeLimit() + m_levelBonusTime;

    return m_renderer->LoadLevelResourcesAsync();
}

//----------------------------------------------------------------------

void Simple3DGame::FinalizeLoadLevel()
{
    // This method is called on the main thread, so Direct3D 11 DeviceContext
    // method calls are allowable here.

    SaveState();

    // Finalize the Level loading.
    m_renderer->FinalizeLoadLevelResources();
}

//----------------------------------------------------------------------

void Simple3DGame::StartLevel()
{
    m_timer->Reset();
    m_timer->Start();
    if (m_currentLevel == 0)
    {
        m_gameActive = true;
    }
    m_levelActive = true;
    m_controller->Active(true);
}

//----------------------------------------------------------------------

void Simple3DGame::PauseGame()
{
    m_timer->Stop();
    SaveState();
}

//----------------------------------------------------------------------

void Simple3DGame::ContinueGame()
{
    m_timer->Start();
    m_controller->Active(true);
}

//----------------------------------------------------------------------

GameState Simple3DGame::RunGame()
{
    m_timer->Update();

    m_levelTimeRemaining = m_levelDuration - m_timer->PlayingTime();

    if (m_levelTimeRemaining <= 0.0f)
    {
        // Time expired, so the game is over.
        m_levelTimeRemaining = 0.0f;
        InitializeAmmo();
        m_timer->Reset();
        m_gameActive = false;
        m_levelActive = false;
        SaveState();

        if (m_totalHits > m_topScore.totalHits)
        {
            m_topScore.totalHits = m_totalHits;
            m_topScore.totalShots = m_totalShots;
            m_topScore.levelCompleted = m_currentLevel;

            SaveHighScore();
        }
        return GameState::TimeExpired;
    }
    else
    {
        // Time has not expired, so run one frame of game play.
        m_player->Velocity(m_controller->Velocity());
        m_camera->LookDirection(m_controller->LookDirection());

        UpdateDynamics();

        // Update the Camera with the player position updates from the dynamics calculations.
        m_camera->Eye(m_player->Position());
        m_camera->LookDirection(m_controller->LookDirection());

        if (m_level[m_currentLevel]->Update(m_timer->PlayingTime(), m_timer->DeltaTime(), m_levelTimeRemaining, m_object))
        {
            // The level has been completed.
            m_levelActive = false;
            InitializeAmmo();

            if (m_currentLevel < m_levelCount-1)
            {
                // More levels to go so increment the level number.
                // Actual level loading will occur in the LoadLevelAsync / FinalizeLoadLevel
                // methods.
                m_timer->Reset();
                m_currentLevel++;
                m_levelBonusTime = m_levelTimeRemaining;
                SaveState();
                return GameState::LevelComplete;
            }
            else
            {
                // All levels have been completed.
                m_timer->Reset();
                m_gameActive = false;
                m_levelActive = false;
                SaveState();

                if (m_totalHits > m_topScore.totalHits)
                {
                    m_topScore.totalHits = m_totalHits;
                    m_topScore.totalShots = m_totalShots;
                    m_topScore.levelCompleted = m_currentLevel;

                    SaveHighScore();
                }
                return GameState::GameComplete;
            }
        }
    }
    return GameState::Active;
}

//----------------------------------------------------------------------

void Simple3DGame::OnSuspending()
{
    m_audioController->SuspendAudio();
}

//----------------------------------------------------------------------

void Simple3DGame::OnResuming()
{
    m_audioController->ResumeAudio();
}

//--------------------------------------------------------------------------------------

void Simple3DGame::UpdateDynamics()
{
    float timeTotal = m_timer->PlayingTime();
    float timeFrame = m_timer->DeltaTime();
    bool fire = m_controller->IsFiring();

#pragma region Shoot Ammo
    // Shoot ammo.
    if (fire)
    {
        static float lastFired;  // Timestamp of the last ammo fired.

        if (timeTotal < lastFired)
        {
            // timeTotal is not guarenteed to be monotomically increasing because it is
            // reset at each level.
            lastFired = timeTotal - GameConstants::Physics::AutoFireDelay;
        }

        if (timeTotal - lastFired >= GameConstants::Physics::AutoFireDelay)
        {
            // Get the inverse view matrix.
            XMMATRIX invView;
            XMVECTOR det;
            invView = XMMatrixInverse(&det, m_camera->View());

            // Compute the initial velocity in world space from camera space.
            XMFLOAT4 initialVelocity(0.0f, 0.0f, 15.0f, 0.0f);
            m_ammo[m_ammoNext]->Velocity(XMVector4Transform(XMLoadFloat4(&initialVelocity), invView));

            // Populate the position.
            // Offset from the player to avoid an initial collision with the player object.
            XMFLOAT4 initialPosition(0.0f, -0.15f, m_player->Radius() + GameConstants::AmmoSize, 1.0f);
            m_ammo[m_ammoNext]->Position(XMVector4Transform(XMLoadFloat4(&initialPosition), invView));

            // Initially not laying on the ground.
            m_ammo[m_ammoNext]->OnGround(false);
            m_ammo[m_ammoNext]->Active(true);

            // Set the position in the array of the next Ammo to use.
            // We will reuse ammo taking the least recently used after we've hit the
            // MaxAmmo in use.
            m_ammoNext = (m_ammoNext + 1) % GameConstants::MaxAmmo;
            m_ammoCount = min(m_ammoCount + 1, GameConstants::MaxAmmo);

            lastFired = timeTotal;
            m_totalShots++;
        }
    }
#pragma endregion

#pragma region Animate Objects
    for (uint32 i = 0; i < m_object.size(); i++)
    {
        if (m_object[i]->AnimatePosition())
        {
            m_object[i]->Position(m_object[i]->AnimatePosition()->Evaluate(timeTotal));
            if (m_object[i]->AnimatePosition()->IsFinished(timeTotal))
            {
                m_object[i]->AnimatePosition(nullptr);
            }
        }
    }
#pragma endregion

    // If the elapsed time is too long, we slice up the time and
    // handle physics over several passes.
    float timeLeft = timeFrame;
    float elapsedFrameTime;
    while (timeLeft > 0.0f)
    {
        elapsedFrameTime = min(timeLeft, GameConstants::Physics::FrameLength);
        timeLeft -= elapsedFrameTime;

        // Update the player position.
        m_player->Position(m_player->VectorPosition() + m_player->VectorVelocity() * elapsedFrameTime);

        // Do m_player / object intersections.
        for (uint32 a = 0; a < m_object.size(); a++)
        {
            if (m_object[a]->Active() && m_object[a] != m_player)
            {
                XMFLOAT3 contact;
                XMFLOAT3 normal;

                if (m_object[a]->IsTouching(m_player->Position(), m_player->Radius(), &contact, &normal))
                {
                    XMVECTOR oneToTwo;
                    oneToTwo = -XMLoadFloat3(&normal);

                    // The player is in contact with Object.
                    float impact;
                    impact = XMVectorGetX(
                        XMVector3Dot (oneToTwo, m_player->VectorVelocity())
                        );
                    // Make sure that the player is actually headed towards the object at grazing angles 
                    // could appear to be an impact when the player is actually already hit and moving away
                    if (impact > 0.0f)
                    {
                        // Compute the normal and tangential components of the player's velocity.
                        XMVECTOR velocityOneNormal = XMVector3Dot(oneToTwo, m_player->VectorVelocity()) * oneToTwo;
                        XMVECTOR velocityOneTangent = m_player->VectorVelocity() - velocityOneNormal;

                        // Compute the post-collision velocity.
                        m_player->Velocity(velocityOneTangent - velocityOneNormal);

                        // Fix the positions so that the ball is exactly GameConstants::AmmoRadius from target.
                        float distanceToMove = m_player->Radius();
                        m_player->Position(XMLoadFloat3(&contact) - (oneToTwo * distanceToMove));
                    }
                }
            }
        }
        {
            // Do collision detection of the player with the bounding world.
            XMFLOAT3 position = m_player->Position();
            XMFLOAT3 velocity = m_player->Velocity();
            float radius = m_player->Radius();

            // Check for player collisions with the walls, floor, or ceiling
            // and adjust the position.

            float limit = m_minBound.x + radius;
            if (position.x < limit)
            {
                position.x = limit;
                velocity.x = -velocity.x * GameConstants::Physics::GroundRestitution;
            }
            limit = m_maxBound.x - radius;
            if (position.x > limit)
            {
                position.x = limit;
                velocity.x = -velocity.x + GameConstants::Physics::GroundRestitution;
            }
            limit = m_minBound.y + radius;
            if (position.y < limit)
            {
                position.y = limit;
                velocity.y = -velocity.y * GameConstants::Physics::GroundRestitution;
            }
            limit = m_maxBound.y - radius;
            if (position.y > limit)
            {
                position.y = limit;
                velocity.y = -velocity.y * GameConstants::Physics::GroundRestitution;
            }
            limit = m_minBound.z + radius;
            if (position.z < limit)
            {
                position.z = limit;
                velocity.z = -velocity.z * GameConstants::Physics::GroundRestitution;
            }
            limit = m_maxBound.z - radius;
            if (position.z > limit)
            {
                position.z = limit;
                velocity.z = -velocity.z * GameConstants::Physics::GroundRestitution;
            }
            m_player->Position(position);
            m_player->Velocity(velocity);
        }

        // Animate the ammo.
        if (m_ammoCount > 0)
        {
            // Check for inter-ammo collision.
#pragma region inter-ammo collision detection
            if (m_ammoCount > 1)
            {
                for (uint32 one = 0; one < m_ammoCount; one++)
                {
                    for (uint32 two = (one + 1); two < m_ammoCount; two++)
                    {
                        // Check for collision between instances One and Two.
                        // vOneToTwo is the collision normal vector.
                        XMVECTOR oneToTwo;
                        oneToTwo = m_ammo[two]->VectorPosition() - m_ammo[one]->VectorPosition();
                        float distanceSquared;
                        distanceSquared = XMVectorGetX(
                            XMVector3LengthSq(oneToTwo)
                            );
                        if (distanceSquared < (GameConstants::AmmoSize * GameConstants::AmmoSize))
                        {
                            oneToTwo = XMVector3Normalize(oneToTwo);

                            // Check if the two instances are already moving away from each other.
                            // If so, skip the collision.  This can happen when a lot of instances are
                            // bunched up next to each other.
                            float impact;
                            impact = XMVectorGetX(
                                XMVector3Dot(oneToTwo, m_ammo[one]->VectorVelocity()) -
                                XMVector3Dot(oneToTwo, m_ammo[two]->VectorVelocity())
                                );
                            if (impact > 0.0f)
                            {
                                // Compute the normal and tangential components of One's velocity.
                                XMVECTOR velocityOneNormal = (1 - GameConstants::Physics::BounceLost) *
                                    XMVector3Dot(oneToTwo, m_ammo[one]->VectorVelocity()) * oneToTwo;
                                XMVECTOR velocityOneTangent = (1 - GameConstants::Physics::BounceLost) *
                                    m_ammo[one]->VectorVelocity() - velocityOneNormal;
                                // Compute the normal and tangential components of Two's velocity.
                                XMVECTOR velocityTwoN = (1 - GameConstants::Physics::BounceLost) *
                                    XMVector3Dot(oneToTwo, m_ammo[two]->VectorVelocity()) * oneToTwo;
                                XMVECTOR velocityTwoT = (1 - GameConstants::Physics::BounceLost) *
                                    m_ammo[two]->VectorVelocity() - velocityTwoN;

                                // Compute the post-collision velocity.
                                m_ammo[one]->Velocity(velocityOneTangent - velocityOneNormal * (1 - GameConstants::Physics::BounceTransfer) +
                                    velocityTwoN * GameConstants::Physics::BounceTransfer);
                                m_ammo[two]->Velocity(velocityTwoT - velocityTwoN * (1 - GameConstants::Physics::BounceTransfer) +
                                    velocityOneNormal * GameConstants::Physics::BounceTransfer);

                                // Fix the positions so that the two balls are exactly GameConstants::AmmoSize apart.
                                float distanceToMove = (GameConstants::AmmoSize - sqrtf(distanceSquared)) * 0.5f;
                                m_ammo[one]->Position(m_ammo[one]->VectorPosition() - (oneToTwo * distanceToMove));
                                m_ammo[two]->Position(m_ammo[two]->VectorPosition() + (oneToTwo * distanceToMove));

                                // Flag the two instances so that they are not laying on ground.
                                m_ammo[one]->OnGround(false);
                                m_ammo[two]->OnGround(false);

                                m_ammo[one]->PlaySound(impact, m_player->Position());
                                m_ammo[two]->PlaySound(impact, m_player->Position());
                            }
                        }
                    }
                }
            }
#pragma endregion

#pragma region Ammo-Object intersections
            // Check for intersections with Objects.
            for (uint32 one = 0; one < m_ammoCount; one++)
            {
                if (m_object.size() > 0)
                {
                    if (!m_ammo[one]->OnGround())
                    {
                        for (uint32 i = 0; i < m_object.size(); i++)
                        {
                            if (m_object[i]->Active())
                            {
                                XMFLOAT3 contact;
                                XMFLOAT3 normal;

                                if (m_object[i]->IsTouching(m_ammo[one]->Position(), GameConstants::AmmoRadius, &contact, &normal))
                                {
                                    XMVECTOR oneToTwo;
                                    oneToTwo = -XMLoadFloat3(&normal);

                                    // Ball is in contact with the Object.
                                    float impact;
                                    impact = XMVectorGetX(
                                        XMVector3Dot (oneToTwo, m_ammo[one]->VectorVelocity())
                                        );
                                    // Make sure that the ball is actually headed towards the object at grazing angles. There
                                    // could appear to be an impact when the ball is actually already hit and moving away.
                                    if (impact > 0.0f)
                                    {
                                        // Compute the normal and tangential components of One's velocity.
                                        XMVECTOR velocityOneNormal = (1 - GameConstants::Physics::BounceLost) * XMVector3Dot(oneToTwo, m_ammo[one]->VectorVelocity()) * oneToTwo;
                                        XMVECTOR velocityOneTangent = (1 - GameConstants::Physics::BounceLost) * m_ammo[one]->VectorVelocity() - velocityOneNormal;

                                        // Compute the post-collision velocity.
                                        m_ammo[one]->Velocity(velocityOneTangent - velocityOneNormal * (1 - GameConstants::Physics::BounceTransfer));

                                        // Fix the positions so that the ball is exactly GameConstants::AmmoRadius from target.
                                        float distanceToMove = GameConstants::AmmoSize;
                                        m_ammo[one]->Position(XMLoadFloat3(&contact) - (oneToTwo * distanceToMove));

                                        // Flag the Ammo as not laying on the ground and mark the object as hit if it is a target.
                                        m_ammo[one]->OnGround(false);

                                        // Play the sound associated with the Ammo hitting something.
                                        m_ammo[one]->PlaySound(impact, m_player->Position());

                                        if (m_object[i]->Target() && !m_object[i]->Hit())
                                        {
                                            m_object[i]->Hit(true);
                                            m_object[i]->HitTime(timeTotal);
                                            m_totalHits++;

                                            // Only play target sound if it was an active hit.
                                            m_object[i]->PlaySound(impact, m_player->Position());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
#pragma endregion

#pragma region Apply Gravity and world intersection
            // Apply gravity and check for collision against the ground and walls.
            for (uint32 i = 0; i < m_ammoCount; i++)
            {
                m_ammo[i]->Position(m_ammo[i]->VectorPosition() + m_ammo[i]->VectorVelocity() * elapsedFrameTime);

                XMFLOAT3 velocity = m_ammo[i]->Velocity();
                XMFLOAT3 position = m_ammo[i]->Position();

                velocity.x -= velocity.x * 0.1f * elapsedFrameTime;
                velocity.z -= velocity.z * 0.1f * elapsedFrameTime;
                // Apply gravity if the ball is not resting on the ground.
                if (!m_ammo[i]->OnGround())
                {
                    velocity.y -= GameConstants::Physics::Gravity * elapsedFrameTime;
                }

                // Check the bounce on the ground.
                if (!m_ammo[i]->OnGround())
                {
                    float limit = m_minBound.y + GameConstants::AmmoRadius;
                    if (position.y < limit)
                    {
                        // Align the ball with the ground.
                        position.y = limit;

                        // Play the sound for impact.
                        m_ammo[i]->PlaySound(-velocity.y, m_player->Position());

                        // Invert the Y velocity.
                        velocity.y = -velocity.y * GameConstants::Physics::GroundRestitution;

                        // X and Z velocity are reduced because of friction.
                        velocity.x *= GameConstants::Physics::Friction;
                        velocity.z *= GameConstants::Physics::Friction;
                    }
                }
                else
                {
                    // Ball is resting or rolling on the ground.
                    // X and Z velocity are reduced because of friction.
                    velocity.x *= GameConstants::Physics::Friction;
                    velocity.z *= GameConstants::Physics::Friction;
                }

                // Check the bounce on the ceiling.
                float limit = m_maxBound.y - GameConstants::AmmoRadius;
                if (position.y > limit)
                {
                    // Align the ball with the ground.
                    position.y = limit;

                    // Play the sound for impact.
                    m_ammo[i]->PlaySound(-velocity.y, m_player->Position());

                    // Invert the Y velocity.
                    velocity.y = -velocity.y * GameConstants::Physics::GroundRestitution;

                    // X and Z velocity are reduced because of friction.
                    velocity.x *= GameConstants::Physics::Friction;
                    velocity.z *= GameConstants::Physics::Friction;
                }

                // If the Y direction motion is below a certain threshold, flag the instance as
                // laying on the ground.
                limit = m_minBound.y + GameConstants::AmmoRadius;
                if ((GameConstants::Physics::Gravity * (position.y - limit) + 0.5f * velocity.y * velocity.y) < GameConstants::Physics::RestThreshold)
                {
                    // Align the ball with the ground.
                    position.y = limit;

                    // Y direction velocity becomes 0.
                    velocity.y = 0.0f;

                    // Flag it.
                    m_ammo[i]->OnGround(true);
                }

                // Check the bounce on the front and back walls.
                limit = m_minBound.z + GameConstants::AmmoRadius;
                if (position.z < limit)
                {
                    // Align the ball with the wall.
                    position.z = limit;

                    // Play the sound for impact.
                    m_ammo[i]->PlaySound(-velocity.z, m_player->Position());

                    // Invert the Z velocity.
                    velocity.z = -velocity.z * GameConstants::Physics::GroundRestitution;
                }
                limit = m_maxBound.z - GameConstants::AmmoRadius;
                if (position.z > limit)
                {
                    // Align the ball with the wall.
                    position.z = limit;

                    // Play the sound for impact.
                    m_ammo[i]->PlaySound(-velocity.z, m_player->Position());

                    // Invert the Z velocity.
                    velocity.z = -velocity.z * GameConstants::Physics::GroundRestitution;
                }

                // Check the bounce on the left and right walls.
                limit = m_minBound.x + GameConstants::AmmoRadius;
                if (position.x < limit)
                {
                    // Align the ball with the wall.
                    position.x = limit;

                    // Play the sound for impact.
                    m_ammo[i]->PlaySound(-velocity.x, m_player->Position());

                    // Invert the X velocity.
                    velocity.x = -velocity.x * GameConstants::Physics::GroundRestitution;
                }
                limit = m_maxBound.x - GameConstants::AmmoRadius;
                if (position.x > limit)
                {
                    // Align the ball with the wall.
                    position.x = limit;

                    m_ammo[i]->PlaySound(-velocity.x, m_player->Position());

                    // Invert the X velocity.
                    velocity.x = -velocity.x * GameConstants::Physics::GroundRestitution;
                }
                m_ammo[i]->Velocity(velocity);
                m_ammo[i]->Position(position);
            }
        }
    }
#pragma endregion
}

//----------------------------------------------------------------------

void Simple3DGame::SaveState()
{
    // Save basic state of the game.
    m_savedState->SaveBool(":GameActive", m_gameActive);
    m_savedState->SaveBool(":LevelActive", m_levelActive);
    m_savedState->SaveInt32(":LevelCompleted", m_currentLevel);
    m_savedState->SaveInt32(":TotalShots", m_totalShots);
    m_savedState->SaveInt32(":TotalHits", m_totalHits);
    m_savedState->SaveSingle(":BonusRoundTime", m_levelBonusTime);
    m_savedState->SaveXMFLOAT3(":PlayerPosition", m_player->Position());
    m_savedState->SaveXMFLOAT3(":PlayerLookDirection", m_controller->LookDirection());

    // Save the extended state of the game because it is currently in the middle of a level.
    if (m_levelActive)
    {
        m_savedState->SaveSingle(":LevelDuration", m_levelDuration);
        m_savedState->SaveSingle(":LevelPlayingTime", m_timer->PlayingTime());

        m_savedState->SaveInt32(":AmmoCount", m_ammoCount);
        m_savedState->SaveInt32(":AmmoNext", m_ammoNext);

        const int bufferLength = 16;
        char16 str[bufferLength];

        for (uint32 i = 0; i < m_ammoCount; i++)
        {
            int len = swprintf_s(str, bufferLength, L"%d", i);
            Platform::String^ string = ref new Platform::String(str, len);

            m_savedState->SaveBool(Platform::String::Concat(":AmmoActive", string), m_ammo[i]->Active());
            m_savedState->SaveXMFLOAT3(Platform::String::Concat(":AmmoPosition", string), m_ammo[i]->Position());
            m_savedState->SaveXMFLOAT3(Platform::String::Concat(":AmmoVelocity", string), m_ammo[i]->Velocity());
        }

        m_savedState->SaveInt32(":ObjectCount", static_cast<int>(m_object.size()));

        for (uint32 i = 0; i < m_object.size(); i++)
        {
            int len = swprintf_s(str, bufferLength, L"%d", i);
            Platform::String^ string = ref new Platform::String(str, len);

            m_savedState->SaveBool(Platform::String::Concat(":ObjectActive", string), m_object[i]->Active());
            m_savedState->SaveBool(Platform::String::Concat(":ObjectTarget", string), m_object[i]->Target());
            m_savedState->SaveXMFLOAT3(Platform::String::Concat(":ObjectPosition", string), m_object[i]->Position());
        }

        m_level[m_currentLevel]->SaveState(m_savedState);
    }
}

//----------------------------------------------------------------------

void Simple3DGame::LoadState()
{
    m_gameActive = m_savedState->LoadBool(":GameActive", m_gameActive);
    m_levelActive = m_savedState->LoadBool(":LevelActive", m_levelActive);

    if (m_gameActive)
    {
        // Loading from the last known state means the Game wasn't finished when it was last played,
        // so set the current level.

        m_totalShots = m_savedState->LoadInt32(":TotalShots", 0);
        m_totalHits = m_savedState->LoadInt32(":TotalHits", 0);
        m_currentLevel = m_savedState->LoadInt32(":LevelCompleted", 0);
        m_levelBonusTime = m_savedState->LoadSingle(":BonusRoundTime", 0.0f);

        m_levelTimeRemaining = m_levelBonusTime;

        // Reload the current player position and set both the camera and the controller
        // with the current Look Direction.
        m_player->Position(
            m_savedState->LoadXMFLOAT3(":PlayerPosition", XMFLOAT3(0.0f, 0.0f, 0.0f))
            );
        m_camera->Eye(m_player->Position());
        m_camera->LookDirection(
            m_savedState->LoadXMFLOAT3(":PlayerLookDirection", XMFLOAT3(0.0f, 0.0f, 1.0f))
            );
        m_controller->Pitch(m_camera->Pitch());
        m_controller->Yaw(m_camera->Yaw());
    }
    else
    {
        // Initialize to the beginning.
        m_currentLevel = 0;
        m_levelBonusTime = 0;
    }

    // Initialize the state of the Update and Render engines and load the current level.
    m_level[m_currentLevel]->Initialize(m_object);

    m_levelDuration = m_level[m_currentLevel]->TimeLimit() + m_levelBonusTime;

    if (m_gameActive)
    {
        if (m_levelActive)
        {
            // Middle of a level so restart where left off.
            m_levelDuration = m_savedState->LoadSingle(":LevelDuration", 0.0f);

            m_timer->Reset();
            m_timer->PlayingTime(m_savedState->LoadSingle(":LevelPlayingTime", 0.0f));

            m_ammoCount = m_savedState->LoadInt32(":AmmoCount", 0);

            m_ammoNext = m_savedState->LoadInt32(":AmmoNext", 0);

            const int bufferLength = 16;
            char16 str[bufferLength];

            for (uint32 i = 0; i < m_ammoCount; i++)
            {
                int len = swprintf_s(str, bufferLength, L"%d", i);
                Platform::String^ string = ref new Platform::String(str, len);

                m_ammo[i]->Active(
                    m_savedState->LoadBool(
                        Platform::String::Concat(":AmmoActive", string),
                        m_ammo[i]->Active()
                        )
                    );
                if (m_ammo[i]->Active())
                {
                    m_ammo[i]->OnGround(false);
                }

                m_ammo[i]->Position(
                    m_savedState->LoadXMFLOAT3(
                        Platform::String::Concat(":AmmoPosition", string),
                        m_ammo[i]->Position()
                        )
                    );

                m_ammo[i]->Velocity(
                    m_savedState->LoadXMFLOAT3(
                        Platform::String::Concat(":AmmoVelocity", string),
                        m_ammo[i]->Velocity()
                        )
                    );
            }

            int storedObjectCount = 0;
            storedObjectCount = m_savedState->LoadInt32(":ObjectCount", 0);

            storedObjectCount = min(storedObjectCount, static_cast<int>(m_object.size()));

            for (int i = 0; i < storedObjectCount; i++)
            {
                int len = swprintf_s(str, bufferLength, L"%d", i);
                Platform::String^ string = ref new Platform::String(str, len);

                m_object[i]->Active(
                    m_savedState->LoadBool(
                        Platform::String::Concat(":ObjectActive", string),
                        m_object[i]->Active()
                        )
                    );

                m_object[i]->Target(
                    m_savedState->LoadBool(
                        Platform::String::Concat(":ObjectTarget", string),
                        m_object[i]->Target()
                        )
                    );

                m_object[i]->Position(
                    m_savedState->LoadXMFLOAT3(
                        Platform::String::Concat(":ObjectPosition", string),
                        m_object[i]->Position()
                        )
                    );
            }

            m_level[m_currentLevel]->LoadState(m_savedState);
            m_levelTimeRemaining = m_level[m_currentLevel]->TimeLimit() + m_levelBonusTime - m_timer->PlayingTime();
        }
    }
}

//----------------------------------------------------------------------

void Simple3DGame::SaveHighScore()
{
    m_savedState->SaveInt32(":HighScore:LevelCompleted", m_topScore.levelCompleted);
    m_savedState->SaveInt32(":HighScore:TotalShots", m_topScore.totalShots);
    m_savedState->SaveInt32(":HighScore:TotalHits", m_topScore.totalHits);
}

//----------------------------------------------------------------------

void Simple3DGame::LoadHighScore()
{
    m_topScore.levelCompleted = m_savedState->LoadInt32(":HighScore:LevelCompleted", 0);
    m_topScore.totalShots = m_savedState->LoadInt32(":HighScore:TotalShots", 0);
    m_topScore.totalHits = m_savedState->LoadInt32(":HighScore:TotalHits", 0);
}

//----------------------------------------------------------------------

void Simple3DGame::InitializeAmmo()
{
    m_ammoCount = 0;
    m_ammoNext = 0;
    for (uint32 i = 0; i < GameConstants::MaxAmmo; i++)
    {
        m_ammo[i]->Active(false);
    }
}
```

Level.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Level:
// This is an abstract class from which all of the levels of the game are derived.
// Each level potentially overrides up to four methods:
//     Initialize - (required) takes a list of objects and enables the objects that
//         are active for the level as well as setting their positions and
//         any animations associated with the objects.
//     Update - this method is called once per time step and is expected to
//         determine if the level has been completed.  The Level class provides
//         a 'standard' Update method which checks each object that is a target
//         and disables any active targets that have been hit.  It returns true
//         once there are no active targets remaining.
//     SaveState - method to save any Level specific state.  Default is defined as
//         not saving any state.
//     LoadState - method to restore any Level specific state.  Default is defined
//         as not restoring any state.

#include "GameObject.h"
#include "PersistentState.h"

ref class Level abstract
{
internal:
    virtual void Initialize(
        std::vector<GameObject^> objects
        ) = 0;

    virtual bool Update(
        float time,
        float elapsedTime,
        float timeRemaining,
        std::vector<GameObject^> objects
        );

    virtual void SaveState(PersistentState^ state);
    virtual void LoadState(PersistentState^ state);

    Platform::String^ Objective();
    float TimeLimit();

protected private:
    Platform::String^ m_objective;
    float             m_timeLimit;
};
            
            
```

Level.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Level.h"

//----------------------------------------------------------------------

bool Level::Update(
    float /* time */,
    float /* elapsedTime */,
    float /* timeRemaining*/,
    std::vector<GameObject^> objects
    )
{
    int left = 0;

    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if ((*object)->Active() && (*object)->Target())
        {
            if ((*object)->Hit())
            {
                (*object)->Active(false);
            }
            else
            {
                left++;
            }
        }
    }
    return (left == 0);
}

//----------------------------------------------------------------------

void Level::SaveState(PersistentState^ /* state */)
{
}

//----------------------------------------------------------------------

void Level::LoadState(PersistentState^ /* state */)
{
}

//----------------------------------------------------------------------

Platform::String^ Level::Objective()
{
    return m_objective;
}

//----------------------------------------------------------------------

float Level::TimeLimit()
{
    return m_timeLimit;
}

//----------------------------------------------------------------------            
            
```

Level1.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Level1:
// This class defines the first level of the game.  There are nine active targets.
// Each of the targets is stationary and can be hit in any order.

#include "Level.h"

ref class Level1: public Level
{
internal:
    Level1();
    virtual void Initialize(std::vector<GameObject^> objects) override;
};
            
```

Level1.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Level1.h"
#include "Face.h"

using namespace DirectX;

//----------------------------------------------------------------------

Level1::Level1()
{
    m_timeLimit = 20.0f;
    m_objective =  "Hit each of the targets before time runs out.\nTouch to aim.  Tap in right box to fire.  Drag in left box to move.";
}

//----------------------------------------------------------------------

void Level1::Initialize(std::vector<GameObject^> objects)
{
    XMFLOAT3 position[] =
    {
        XMFLOAT3(-2.5f, -1.0f, -1.5f),
        XMFLOAT3(-1.0f,  1.0f, -3.0f),
        XMFLOAT3( 1.5f,  0.0f, -3.0f),
        XMFLOAT3(-2.5f, -1.0f, -5.5f),
        XMFLOAT3( 0.5f, -2.0f, -5.0f),
        XMFLOAT3( 1.5f, -2.0f, -5.5f),
        XMFLOAT3( 2.0f,  0.0f,  0.0f),
        XMFLOAT3( 0.0f,  0.0f,  0.0f),
        XMFLOAT3(-2.0f,  0.0f,  0.0f)
    };

    int targetCount = 0;
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if (Face^ target = dynamic_cast<Face^>(*object))
        {
            if (targetCount < 9)
            {
                target->Active(true);
                target->Target(true);
                target->Hit(false);
                target->AnimatePosition(nullptr);
                target->Position(position[targetCount]);
                targetCount++;
            }
            else
            {
                (*object)->Active(false);
            }
        }
        else
        {
            (*object)->Active(false);
        }
    }
}

//----------------------------------------------------------------------
            
            
```

Level2.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Level2:
// This class defines the second level of the game.  It derives from the
// first level.  In this level, the targets must be hit in numeric order.

#include "Level1.h"

ref class Level2: public Level1
{
internal:
    Level2();
    virtual void Initialize(std::vector<GameObject^> objects) override;

    virtual bool Update(
        float time,
        float elapsedTime,
        float timeRemaining,
        std::vector<GameObject^> objects
        ) override;

    virtual void SaveState(PersistentState^ state) override;
    virtual void LoadState(PersistentState^ state) override;

private:
    int m_nextId;
};
            
            
```

Level2.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Level2.h"
#include "Face.h"

//----------------------------------------------------------------------

Level2::Level2()
{
    m_timeLimit = 30.0f;
    m_objective = "Hit each of the targets in ORDER before time runs out.";
}

//----------------------------------------------------------------------

void Level2::Initialize(std::vector<GameObject^> objects)
{
    Level1::Initialize(objects);

    int targetCount = 0;
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if (Face^ target = dynamic_cast<Face^>(*object))
        {
            if (targetCount < 9)
            {
                target->Target(targetCount == 0 ? true : false);
                targetCount++;
            }
        }
    }
    m_nextId = 1;
}

//----------------------------------------------------------------------

bool Level2::Update(
    float /* time */,
    float /* elapsedTime */,
    float /* timeRemaining */,
    std::vector<GameObject^> objects
    )
{
    int left = 0;
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if ((*object)->Active() && ((*object)->TargetId() > 0))
        {
            if ((*object)->Hit()  && ((*object)->TargetId() == m_nextId))
            {
                (*object)->Active(false);
                m_nextId++;
            }
            else
            {
                left++;
            }
        }
        if ((*object)->Active() && ((*object)->TargetId() == m_nextId))
        {
            (*object)->Target(true);
        }
    }
    return (left == 0);
}

//----------------------------------------------------------------------

void Level2::SaveState(PersistentState^ state)
{
    state->SaveInt32(":NextTarget", m_nextId);
}

//----------------------------------------------------------------------

void Level2::LoadState(PersistentState^ state)
{
    m_nextId = state->LoadInt32(":NextTarget", 1);
}

//----------------------------------------------------------------------            
            
```

Level3.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Level3:
// This class defines the third level of the game.  In this level, each of the
// nine targets is moving along closed paths and can be hit
// in any order.

#include "Level.h"

ref class Level3: public Level
{
internal:
    Level3();
    virtual void Initialize(std::vector<GameObject^> objects) override;
};
            
            
```

Level3.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Level3.h"
#include "Face.h"
#include "Animate.h"

using namespace DirectX;

//----------------------------------------------------------------------

Level3::Level3()
{
    m_timeLimit = 30.0f;
    m_objective = "Hit each of the moving targets before time runs out.";
}

//----------------------------------------------------------------------

void Level3::Initialize(std::vector<GameObject^> objects)
{
    XMFLOAT3 position[] =
    {
        XMFLOAT3(-2.5f, -1.0f, -1.5f),
        XMFLOAT3(-1.0f,  1.0f, -3.0f),
        XMFLOAT3( 1.5f,  0.0f, -5.5f),
        XMFLOAT3(-2.5f, -1.0f, -5.5f),
        XMFLOAT3( 0.5f, -2.0f, -5.0f),
        XMFLOAT3( 1.5f, -2.0f, -5.5f),
        XMFLOAT3( 0.0f, -3.6f,  0.0f),
        XMFLOAT3( 0.0f, -3.6f,  0.0f),
        XMFLOAT3( 0.0f, -3.6f,  0.0f)
    };
    XMFLOAT3 LineList1[] =
    {
        XMFLOAT3(-2.5f, -1.0f, -1.5f),
        XMFLOAT3(-0.5f,  1.0f,  1.0f),
        XMFLOAT3(-0.5f, -2.5f,  1.0f),
        XMFLOAT3(-2.5f, -1.0f, -1.5f),
    };
    XMFLOAT3 LineList2[] =
    {
        XMFLOAT3(-1.0f,  1.0f, -3.0f),
        XMFLOAT3(-2.0f,  2.0f, -1.5f),
        XMFLOAT3(-2.0f, -2.5f, -1.5f),
        XMFLOAT3( 1.5f, -2.5f, -1.5f),
        XMFLOAT3( 1.5f, -2.5f, -3.0f),
        XMFLOAT3(-1.0f,  1.0f, -3.0f),
    };
    XMFLOAT3 LineList3[] =
    {
        XMFLOAT3(1.5f,  0.0f, -5.5f),
        XMFLOAT3(1.5f,  1.0f, -5.5f),
        XMFLOAT3(1.5f, -2.5f, -5.5f),
        XMFLOAT3(1.5f,  0.0f, -5.5f),
    };
    XMFLOAT3 LineList4[] =
    {
        XMFLOAT3(-2.5f, -1.0f, -5.5f),
        XMFLOAT3( 1.0f, -1.0f, -5.5f),
        XMFLOAT3( 1.0f,  1.0f, -5.5f),
        XMFLOAT3(-2.5f,  1.0f, -5.5f),
        XMFLOAT3(-2.5f, -1.0f, -5.5f),
    };
    XMFLOAT3 LineList5[] =
    {
        XMFLOAT3( 0.5f, -2.0f, -5.0f),
        XMFLOAT3( 2.0f, -2.0f, -5.0f),
        XMFLOAT3( 2.0f,  1.0f, -5.0f),
        XMFLOAT3(-2.5f,  1.0f, -5.0f),
        XMFLOAT3(-2.5f, -2.0f, -5.0f),
        XMFLOAT3( 0.5f, -2.0f, -5.0f),
    };
    XMFLOAT3 LineList6[] =
    {
        XMFLOAT3( 1.5f, -2.0f, -5.5f),
        XMFLOAT3(-2.5f, -2.0f, -5.5f),
        XMFLOAT3(-2.5f,  1.0f, -5.5f),
        XMFLOAT3( 1.5f,  1.0f, -5.5f),
        XMFLOAT3( 1.5f, -2.0f, -5.5f),
    };

    int targetCount = 0;
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if (Face^ target = dynamic_cast<Face^>(*object))
        {
            if (targetCount < 9)
            {
                target->Active(true);
                target->Target(true);
                target->Hit(false);
                target->Position(position[targetCount]);
                switch (targetCount)
                {
                case 0:
                    target->AnimatePosition(ref new AnimateLineListPosition(4, LineList1, 10.0f, true));
                    break;
                case 1:
                    target->AnimatePosition(ref new AnimateLineListPosition(6, LineList2, 15.0f, true));
                    break;
                case 2:
                    target->AnimatePosition(ref new AnimateLineListPosition(4, LineList3, 15.0f, true));
                    break;
                case 3:
                    target->AnimatePosition(ref new AnimateLineListPosition(5, LineList4, 15.0f, true));
                    break;
                case 4:
                    target->AnimatePosition(ref new AnimateLineListPosition(6, LineList5, 15.0f, true));
                    break;
                case 5:
                    target->AnimatePosition(ref new AnimateLineListPosition(5, LineList6, 15.0f, true));
                    break;
                case 6:
                    target->AnimatePosition(
                        ref new AnimateCirclePosition(
                            XMFLOAT3(0.0f, -2.5f, 0.0f),
                            XMFLOAT3(0.0f, -3.6f, 0.0f),
                            XMFLOAT3(0.0f,  0.0f, 1.0f),
                            9.0f,
                            true,
                            true
                            )
                        );
                    break;
                case 7:
                    target->AnimatePosition(
                        ref new AnimateCirclePosition(
                            XMFLOAT3(0.0f, -2.5f, 0.0f),
                            XMFLOAT3(0.0f, -3.6f, 0.0f),
                            XMFLOAT3(0.0f,  0.0f, 1.0f),
                            9.0f,
                            true,
                            true
                            )
                        );
                    target->AnimatePosition()->Start(3.0f);
                    break;
                case 8:
                    target->AnimatePosition(
                        ref new AnimateCirclePosition(
                            XMFLOAT3(0.0f, -2.5f, 0.0f),
                            XMFLOAT3(0.0f, -3.6f, 0.0f),
                            XMFLOAT3(0.0f,  0.0f, 1.0f),
                            9.0f,
                            true,
                            true
                            )
                        );
                    target->AnimatePosition()->Start(6.0f);
                    break;
                }
                targetCount++;
            }
            else
            {
                target->Active(false);
            }
        }
        else
        {
            (*object)->Active(false);
        }
    }
}

//----------------------------------------------------------------------
            
            
```

Level4.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Level4:
// This class defines the fourth level of the game.  It derives from the
// third level.  The targets must be hit in numeric order.

#include "Level3.h"

ref class Level4: public Level3
{
internal:
    Level4();
    virtual void Initialize(std::vector<GameObject^> objects) override;

    virtual bool Update(
        float time,
        float elapsedTime,
        float timeRemaining,
        std::vector<GameObject^> objects
        ) override;

    virtual void SaveState(PersistentState^ state) override;
    virtual void LoadState(PersistentState^ state) override;

private:
    int m_nextId;
};
            
            
```

Level4.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Level4.h"
#include "Face.h"

//----------------------------------------------------------------------

Level4::Level4()
{
    m_timeLimit = 30.0f;
    m_objective = "Hit each of the moving targets in ORDER before time runs out.";
}

//----------------------------------------------------------------------

void Level4::Initialize(std::vector<GameObject^> objects)
{
    Level3::Initialize(objects);

    int targetCount = 0;
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if (Face^ target = dynamic_cast<Face^>(*object))
        {
            if (targetCount < 9)
            {
                target->Target(targetCount == 0 ? true : false);
                targetCount++;
            }
        }
    }
    m_nextId = 1;
}

//----------------------------------------------------------------------

bool Level4::Update(
    float /* time */,
    float /* elapsedTime */,
    float /* timeRemaining */,
    std::vector<GameObject^> objects
    )
{
    int left = 0;
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if ((*object)->Active() && ((*object)->TargetId() > 0))
        {
            if ((*object)->Hit() && ((*object)->TargetId() == m_nextId))
            {
                (*object)->Active(false);
                m_nextId++;
            }
            else
            {
                left++;
            }
        }
        if ((*object)->Active() && ((*object)->TargetId() == m_nextId))
        {
            (*object)->Target(true);
        }
    }
    return (left == 0);
}

//----------------------------------------------------------------------

void Level4::SaveState(PersistentState^ state)
{
    state->SaveInt32(":NextTarget", m_nextId);
}

//----------------------------------------------------------------------

void Level4::LoadState(PersistentState^ state)
{
    m_nextId = state->LoadInt32(":NextTarget", 1);
}

//----------------------------------------------------------------------
            
            
```

Level5.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Level5:
// This class defines the fifth level of the game.  It derives from the
// third level.  This level introduces obstacles that move into place
// during game play.  The targets may be hit in any order.

#include "Level3.h"

ref class Level5: public Level3
{
internal:
    Level5();
    virtual void Initialize(std::vector<GameObject^> objects) override;
};
            
            
```

Level5.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Level5.h"
#include "Cylinder.h"
#include "Animate.h"

using namespace DirectX;

//----------------------------------------------------------------------

Level5::Level5()
{
    m_timeLimit = 30.0f;
    m_objective = "Hit each of the moving targets while avoiding the obstacles before time runs out.";
}

//----------------------------------------------------------------------

void Level5::Initialize(std::vector<GameObject^> objects)
{
    Level3::Initialize(objects);

    XMFLOAT3 obstacleStartPosition[] =
    {
        XMFLOAT3(-4.5f, -3.0f, 0.0f),
        XMFLOAT3(4.5f, -3.0f, 0.0f),
        XMFLOAT3(0.0f, 3.01f, -2.0f),
        XMFLOAT3(-1.5f, -3.0f, -6.5f),
        XMFLOAT3(1.5f, -3.0f, -6.5f)
    };
    XMFLOAT3 obstacleEndPosition[] =
    {
        XMFLOAT3(-2.0f, -3.0f, 0.0f),
        XMFLOAT3(2.0f, -3.0f, 0.0f),
        XMFLOAT3(0.0f, -3.0f, -2.0f),
        XMFLOAT3(-1.5f, -3.0f, -4.0f),
        XMFLOAT3(1.5f, -3.0f, -4.0f)
    };
    float obstacleStartTime[] =
    {
        2.0f,
        5.0f,
        8.0f,
        11.0f,
        14.0f
    };

    int obstacleCount = 0;
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if (Cylinder^ obstacle = dynamic_cast<Cylinder^>(*object))
        {
            if (obstacleCount < 5)
            {
                obstacle->Active(true);
                obstacle->Position(obstacleStartPosition[obstacleCount]);
                obstacle->AnimatePosition(
                    ref new AnimateLinePosition(
                        obstacleStartPosition[obstacleCount],
                        obstacleEndPosition[obstacleCount],
                        10.0,
                        false
                        )
                    );
                obstacle->AnimatePosition()->Start(obstacleStartTime[obstacleCount]);
                obstacleCount ++;
            }
        }
    }
}

//----------------------------------------------------------------------            
            
```

Level6.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Level6:
// This class defines the sixth and final level of the game.  It derives from the
// fifth level.  In this level, the targets do not disappear when they are hit.
// The target will stay highlighted for two seconds.  As this is the last level,
// the only criteria for completion is time expiring.

#include "Level5.h"

ref class Level6: public Level5
{
internal:
    Level6();
    virtual bool Update(
        float time,
        float elapsedTime,
        float timeRemaining,
        std::vector<GameObject^> objects
        ) override;
};
            
            
```

Level6.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Level6.h"

//----------------------------------------------------------------------

Level6::Level6()
{
    m_timeLimit = 20.0f;
    m_objective = "Hit as many moving targets as possible while avoiding the obstacles before time runs out.";
}

//----------------------------------------------------------------------

bool Level6::Update(
    float time,
    float elapsedTime,
    float timeRemaining,
    std::vector<GameObject^> objects
    )
{
    for (auto object = objects.begin(); object != objects.end(); object++)
    {
        if ((*object)->Active() && (*object)->Target())
        {
            if ((*object)->Hit() && ((*object)->HitTime() < (time - 2.0f)))
            {
                (*object)->Hit(false);
            }
        }
    }
    return ((timeRemaining - elapsedTime) <= 0.0f);
}

//----------------------------------------------------------------------            
            
```

Animate.h

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#pragma once

// Animate:
// This is an abstract class for animations.  It defines a set of
// capabilities for animating XMFLOAT3 variables.  An animation has the following
// characteristics:
//     Start - the time for the animation to start.
//     Duration - the length of time the animation is to run.
//     Continuous - whether the animation loops after duration is reached or just
//         stops.
// There are two query functions:
//     IsActive - determines if the animation is active at time t.
//     IsFinished - determines if the animation is done at time t.
// It is expected that each derived class will provide an Evaluate method for the
// specific kind of animation.

ref class Animate abstract
{
internal:
    Animate();

    virtual DirectX::XMFLOAT3 Evaluate (_In_ float t) = 0;

    bool  IsActive(_In_ float t) { return ((t >= m_startTime) && (m_continuous || (t < (m_startTime + m_duration)))); };
    bool  IsFinished(_In_ float t) { return (!m_continuous && (t >= (m_startTime + m_duration))); }
    float Start();
    void  Start(_In_ float start);
    float Duration();
    void  Duration(_In_ float duration);
    bool  Continuous();
    void  Continuous(_In_ bool continuous);

protected private:
    bool  m_continuous;      // if true means at end cycle back to beginning
    float m_startTime;       // time at which animation begins
    float m_duration;        // for continuous, this is the duration of 1 cycle through path
};

//----------------------------------------------------------------------

// AnimateLinePosition:
// This class is a specialization of Animate that defines an animation of a position vector
// along a straight line defined in world coordinates from startPosition to endPosition.

ref class AnimateLinePosition: public Animate
{
internal:
    AnimateLinePosition(
        _In_ DirectX::XMFLOAT3 startPosition,
        _In_ DirectX::XMFLOAT3 endPosition,
        _In_ float duration,
        _In_ bool continuous
        );
    virtual DirectX::XMFLOAT3 Evaluate(_In_ float t) override;

private:
    DirectX::XMFLOAT3 m_startPosition;
    DirectX::XMFLOAT3 m_endPosition;
    float             m_length;
};

//----------------------------------------------------------------------

struct LineSegment
{
    DirectX::XMFLOAT3 position;
    float             length;
    float             uStart;
    float             uLength;
};

// AnimateLineListPosition:
// This class is a specialization of Animate that defines an animation of a position vector
// along a set of line segments defined by a set of points.  The animation along the path is
// such that the evaluation of the position along the path will be uniform independent of
// the length of each of the line segments.  A continuous loop can be achieved by having the
// first and last points of the list be the same.

ref class AnimateLineListPosition: public Animate
{
internal:
    AnimateLineListPosition(
        _In_ unsigned int count,
        _In_reads_(count) DirectX::XMFLOAT3 position[],
        _In_ float duration,
        _In_ bool continuous
        );
    virtual DirectX::XMFLOAT3 Evaluate(_In_ float t) override;

private:
    unsigned int             m_count;
    float                    m_totalLength;
    std::vector<LineSegment> m_segment;
};

//----------------------------------------------------------------------

// AnimateCirclePosition:
// This class is a specialization of Animate that defines an animation of a position vector
// along a circular path centered at 'center' with a starting point of 'startPosition'.  The
// distance between 'center' and 'startPosition' defines the radius of the circle.  The plane
// of the circle will pass through 'center' and 'startPosition' and have a normal of 'planeNormal'.
// The direction of the animation can be either clockwise or counterclockwise based
// on the 'clockwise' parameter.

ref class AnimateCirclePosition: public Animate
{
internal:
    AnimateCirclePosition(
        _In_ DirectX::XMFLOAT3 center,
        _In_ DirectX::XMFLOAT3 startPosition,
        _In_ DirectX::XMFLOAT3 planeNormal,
        _In_ float duration,
        _In_ bool continuous,
        _In_ bool clockwise
        );
    virtual DirectX::XMFLOAT3 Evaluate(_In_ float t) override;

private:
    DirectX::XMFLOAT4X4 m_rotationMatrix;
    DirectX::XMFLOAT3   m_center;
    DirectX::XMFLOAT3   m_planeNormal;
    DirectX::XMFLOAT3   m_startPosition;
    float               m_radius;
    bool                m_clockwise;
};

//----------------------------------------------------------------------
            
            
```

Animate.cpp

```cpp
//// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
//// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
//// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//// PARTICULAR PURPOSE.
////
//// Copyright (c) Microsoft Corporation. All rights reserved

#include "pch.h"
#include "Animate.h"

using namespace DirectX;

//----------------------------------------------------------------------

Animate::Animate():
    m_continuous(false),
    m_startTime(0.0f),
    m_duration(10.0f)
{
}

//----------------------------------------------------------------------

float Animate::Start()
{
    return m_startTime;
}

//----------------------------------------------------------------------

void Animate::Start(_In_ float start)
{
    m_startTime = start;
}

//----------------------------------------------------------------------

float Animate::Duration()
{
    return m_duration;
}

//----------------------------------------------------------------------

void Animate::Duration(_In_ float duration)
{
    m_duration = duration;
}

//----------------------------------------------------------------------

bool Animate::Continuous()
{
    return m_continuous;
}

//----------------------------------------------------------------------

void Animate::Continuous(_In_ bool continuous)
{
    m_continuous = continuous;
}

//----------------------------------------------------------------------

AnimateLinePosition::AnimateLinePosition(
    _In_ XMFLOAT3 startPosition,
    _In_ XMFLOAT3 endPosition,
    _In_ float duration,
    _In_ bool continuous)
{
    m_startPosition = startPosition;
    m_endPosition = endPosition;
    m_duration = duration;
    m_continuous = continuous;

    m_length = XMVectorGetX(
        XMVector3Length(XMLoadFloat3(&endPosition) - XMLoadFloat3(&startPosition))
        );
}

//----------------------------------------------------------------------

XMFLOAT3 AnimateLinePosition::Evaluate(_In_ float t)
{
    if (t <= m_startTime)
    {
        return m_startPosition;
    }

    if ((t >= (m_startTime + m_duration)) && !m_continuous)
    {
        return m_endPosition;
    }

    float startTime = m_startTime;
    if (m_continuous)
    {
        // For continuous operation, move the start time forward to
        // eliminate previous iterations.
        startTime += ((int)((t - m_startTime) / m_duration)) * m_duration;
    }

    float u = (t - startTime) / m_duration;
    XMFLOAT3 currentPosition;
    currentPosition.x = m_startPosition.x + (m_endPosition.x - m_startPosition.x)*u;
    currentPosition.y = m_startPosition.y + (m_endPosition.y - m_startPosition.y)*u;
    currentPosition.z = m_startPosition.z + (m_endPosition.z - m_startPosition.z)*u;

    return currentPosition;
}

//----------------------------------------------------------------------

AnimateLineListPosition::AnimateLineListPosition(
    _In_ unsigned int count,
    _In_reads_(count) XMFLOAT3 position[],
    _In_ float duration,
    _In_ bool continuous)
{
    m_duration = duration;
    m_continuous = continuous;
    m_count = count;

    std::vector<LineSegment> segment(m_count);
    m_segment = segment;
    m_totalLength = 0.0f;

    m_segment[0].position = position[0];
    for (unsigned int i = 1; i < count; i++)
    {
        m_segment[i].position = position[i];
        m_segment[i - 1].length = XMVectorGetX(
            XMVector3Length(
                XMLoadFloat3(&m_segment[i].position) -
                XMLoadFloat3(&m_segment[i - 1].position)
                )
            );
        m_totalLength += m_segment[i - 1].length;
    }

    // Parameterize the segments to ensure uniform evaluation along the path.
    float u = 0.0f;
    for (unsigned int i = 0; i < (count - 1); i++)
    {
        m_segment[i].uStart = u;
        m_segment[i].uLength = (m_segment[i].length / m_totalLength);
        u += m_segment[i].uLength;
    }
    m_segment[count-1].uStart = 1.0f;
}

//----------------------------------------------------------------------

XMFLOAT3 AnimateLineListPosition::Evaluate(_In_ float t)
{
    if (t <= m_startTime)
    {
        return m_segment[0].position;
    }

    if ((t >= (m_startTime + m_duration)) && !m_continuous)
    {
        return m_segment[m_count-1].position;
    }

    float startTime = m_startTime;
    if (m_continuous)
    {
        // For continuous operation, move the start time forward to
        // eliminate previous iterations.
        startTime += ((int)((t - m_startTime) / m_duration)) * m_duration;
    }

    float u = (t - startTime) / m_duration;
    // Find the right segment.
    unsigned int i = 0;
    while (u > m_segment[i + 1].uStart)
    {
        i++;
    }

    u -= m_segment[i].uStart;
    u /= m_segment[i].uLength;

    XMFLOAT3 currentPosition;
    currentPosition.x = m_segment[i].position.x + (m_segment[i + 1].position.x - m_segment[i].position.x)*u;
    currentPosition.y = m_segment[i].position.y + (m_segment[i + 1].position.y - m_segment[i].position.y)*u;
    currentPosition.z = m_segment[i].position.z + (m_segment[i + 1].position.z - m_segment[i].position.z)*u;

    return currentPosition;
}

//----------------------------------------------------------------------

AnimateCirclePosition:: AnimateCirclePosition(
    _In_ XMFLOAT3 center,
    _In_ XMFLOAT3 startPosition,
    _In_ XMFLOAT3 planeNormal,
    _In_ float duration,
    _In_ bool continuous,
    _In_ bool clockwise)
{
    m_center = center;
    m_planeNormal = planeNormal;
    m_startPosition = startPosition;
    m_duration = duration;
    m_continuous = continuous;
    m_clockwise = clockwise;

    XMVECTOR coordX = XMLoadFloat3(&m_startPosition) - XMLoadFloat3(&m_center);
    m_radius = XMVectorGetX(XMVector3Length(coordX));

    XMVector3Normalize(coordX);

    XMVECTOR coordZ = XMLoadFloat3(&m_planeNormal);
    XMVector3Normalize(coordZ);

    XMVECTOR coordY;
    if (m_clockwise)
    {
        coordY = XMVector3Cross(coordZ, coordX);
    }
    else
    {
        coordY = XMVector3Cross(coordX, coordZ);
    }

    XMVECTOR vectorX = XMVectorSet(1.0f, 0.0f, 0.0f, 1.0f);
    XMVECTOR vectorY = XMVectorSet(0.0f, 1.0f, 0.0f, 1.0f);
    XMMATRIX mat1 = XMMatrixIdentity();
    XMMATRIX mat2 = XMMatrixIdentity();

    if (!XMVector3Equal(coordX, vectorX))
    {
        float angle;
        angle = XMVectorGetX(
            XMVector3AngleBetweenVectors(vectorX, coordX)
            );
        if ((angle * angle) > 0.025)
        {
            XMVECTOR axis1 = XMVector3Cross(vectorX, coordX);

            mat1 = XMMatrixRotationAxis(axis1, angle);
            vectorY = XMVector3TransformCoord(vectorY, mat1);
        }
    }
    if (!XMVector3Equal(vectorY, coordY))
    {
        float angle;
        angle = XMVectorGetX(
            XMVector3AngleBetweenVectors(vectorY, coordY)
            );
        if ((angle * angle) > 0.025)
        {
            XMVECTOR axis2 = XMVector3Cross(vectorY, coordY);
            mat2 = XMMatrixRotationAxis(axis2, angle);
        }
    }
    XMStoreFloat4x4(
        &m_rotationMatrix,
        mat1 *
        mat2 *
        XMMatrixTranslation(m_center.x, m_center.y, m_center.z)
        );
}

//----------------------------------------------------------------------

XMFLOAT3 AnimateCirclePosition::Evaluate(_In_ float t)
{
    if (t <= m_startTime)
    {
        return m_startPosition;
    }

    if ((t >= (m_startTime + m_duration)) && !m_continuous)
    {
        return m_startPosition;
    }

    float startTime = m_startTime;
    if (m_continuous)
    {
        // For continuous operation move the start time forward to
        // eliminate previous iterations.
        startTime += ((int)((t - m_startTime) / m_duration)) * m_duration;
    }

    float u = (t - startTime) / m_duration * XM_2PI;

    XMFLOAT3 currentPosition;
    currentPosition.x = m_radius * cos(u);
    currentPosition.y = m_radius * sin(u);
    currentPosition.z = 0.0f;

    XMStoreFloat3(
        &currentPosition,
        XMVector3TransformCoord(
            XMLoadFloat3(&currentPosition),
            XMLoadFloat4x4(&m_rotationMatrix)
            )
        );

    return currentPosition;
}

//----------------------------------------------------------------------
            
            
```

> **注**  
この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

## 関連トピック


[DirectX によるシンプルな UWP ゲームの作成](tutorial--create-your-first-metro-style-directx-game.md)

 

 







<!--HONumber=Aug16_HO3-->


