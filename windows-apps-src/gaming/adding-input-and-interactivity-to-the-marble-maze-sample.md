---
title: Marble Maze サンプルへの入力と対話機能の追加
description: 入力デバイスを操作するときに留意する必要がある主なプラクティスについて説明します。
ms.assetid: b946bf62-c0ca-f9ec-1a87-8195b89a5ab4
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, サンプル
ms.localizationpriority: medium
ms.openlocfilehash: aee239f76c3d4431426f0bc9fe519a59f8f48838
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/05/2018
ms.locfileid: "8732586"
---
# <a name="adding-input-and-interactivity-to-the-marble-maze-sample"></a>Marble Maze サンプルへの入力と対話機能の追加




ユニバーサル Windows プラットフォーム (UWP) ゲームは、デスクトップ コンピューター、ノート PC、タブレットなど、さまざまなデバイスで実行されます。 デバイスに備わっている入力機構と制御機構も多岐にわたります。 このドキュメントでは、入力デバイスを扱う際に考慮する必要のある主な手法について説明すると共に、それらが Marble Maze でどのように適用されているかを紹介します。

> [!NOTE]
> このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。

 
このドキュメントでは、ゲームで入力を扱う際に重要となるいくつかの事柄について説明します。取り上げる内容は次のとおりです。

-   可能な限り、多様な入力デバイスをサポートし、ゲーム ユーザーの好みや技量に幅広く対応します。 ゲーム コントローラーやセンサーは、必ずしも使う必要はありませんが、プレーヤーのエクスペリエンスを高めるために使用を強くお勧めします。 ゲーム コントローラーとセンサー API は、これらの入力デバイスと容易に連携できるように設計されています。

-   タッチを初期化するには、ポインターがアクティブ化されたとき、離されたとき、移動されたときなどのウィンドウ イベントを登録する必要があります。 加速度計を初期化するには、アプリケーションの初期化時に [Windows::Devices::Sensors::Accelerometer](https://msdn.microsoft.com/library/windows/apps/br225687) オブジェクトを作成します。 Xbox コントローラーは初期化を必要としません。

-   1 プレーヤーのゲームでは、接続されているすべての Xbox コントローラーからの入力を結合します。 このようにすることで、入力とその発生元となったコントローラーの関係をトラッキングする手間が省けます。 または、このサンプルで行っているように、最後に追加されたコントローラーからの入力のみを追跡します。

-   入力デバイスを処理する前に、Windows イベントを処理します。

-   Xbox コントローラーと加速度計では、ポーリングがサポートされています。 つまり、必要に応じてデータをポーリングできます。 タッチの場合は、入力処理コードで利用できるデータ構造にタッチ イベントを記録します。

-   入力値を共通形式に正規化します。 ゲームの他のコンポーネント (物理シミュレーションなど) が入力を解釈する方法を簡略化でき、さまざまな画面解像度で動作するゲームが作成しやすくなります。

## <a name="input-devices-supported-by-marble-maze"></a>Marble Maze でサポートされる入力デバイス


Marble Maze は、メニュー項目の選択に関して Xbox コントローラー、マウス、タッチをサポートし、ゲーム プレイの制御に関して Xbox コントローラー、マウス、タッチ、加速度計をサポートします。 Marble Maze は、[Windows::Gaming::Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) API を使ってコントローラーの入力をポーリングします。 アプリケーションは、タッチ デバイスを通じて指先での入力をトラッキングし、応答することができます。 加速度計は、X、Y、Z 軸方向に加えられた力を測定するセンサーです。 Windows ランタイムを使うと、Windows ランタイムのイベント処理機構を通じてタッチ イベントを受け取るだけでなく、加速度計デバイスの現在の状態をポーリングすることもできます。

> [!NOTE]
> このドキュメントでは、タッチとマウスの両方の入力をタッチと呼び、ポインター イベントを使うすべてのデバイスをポインターと呼びます。 タッチとマウスは標準のポインター イベントを利用するため、どちらのデバイスでもメニュー項目の選択とゲーム プレイの制御を行うことができます。

 

> [!NOTE]
> デバイスを回転させて大理石を転がす際、方向が変わるのを防ぐために、パッケージ マニフェストは、ゲームでサポートされる回転として **Landscape** (横) のみを設定します。 パッケージ マニフェストを表示するには、Visual Studio の**ソリューション エクスプローラー**で、**Package.appxmanifest** を開きます。

 

## <a name="initializing-input-devices"></a>入力デバイスの初期化


Xbox コントローラーは初期化を必要としません。 タッチを初期化するには、ポインターがアクティブになったとき (たとえばプレイヤーがマウス ボタンを押すか画面に触れたとき)、離されたとき、移動されたときなどのウィンドウ イベントを登録する必要があります。 加速度計を初期化するには、アプリケーションの初期化時に [Windows::Devices::Sensors::Accelerometer](https://msdn.microsoft.com/library/windows/apps/br225687) オブジェクトを作成する必要があります。

次の例は、**App::SetWindow** メソッドが [Windows::UI::Core::CoreWindow::PointerPressed](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerPressed)、[Windows::UI::Core::CoreWindow::PointerReleased](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerReleased)、[Windows::UI::Core::CoreWindow::PointerMoved](https://docs.microsoft.com/uwp/api/windows.ui.core.corewindow.PointerMoved) の各ポインター イベントを登録する方法を示します。 これらのイベントは、アプリケーションの初期化中、ゲーム ループの前に登録されます。

これらのイベントは、イベント ハンドラーを呼び出す別のスレッドで処理されます。

アプリケーションの初期化方法について詳しくは、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」をご覧ください。

```cpp
window->PointerPressed += ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(
    this, 
    &App::OnPointerPressed);

window->PointerReleased += ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(
    this, 
    &App::OnPointerReleased);

window->PointerMoved += ref new TypedEventHandler<CoreWindow^, PointerEventArgs^>(
    this, 
    &App::OnPointerMoved);
```

また、**MarbleMazeMain** クラスはタッチ イベントを保持するための **std::map** オブジェクトを作成します。 この map オブジェクトのキーは、入力ポインターを一意に識別する値です。 それぞれのキーは、各タッチ ポイントと画面の中央の間の距離にマップされます。 後で迷路の傾きの量を計算するときに、これらの値が使われます。

```cpp
typedef std::map<int, XMFLOAT2> TouchMap;
TouchMap        m_touches;
```

**MarbleMazeMain** クラスは [Accelerometer](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer) オブジェクトを保持します。

```cpp
Windows::Devices::Sensors::Accelerometer^           m_accelerometer;
```

**Accelerometer** オブジェクトは、次の例に示すように **MarbleMazeMain** のコンストラクターで初期化されます。 [Windows::Devices::Sensors::Accelerometer::GetDefault](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer.GetDefault) メソッドは既定の加速度計のインスタンスを返します。 既定の加速度計がない場合、**Accelerometer::GetDefault** は **nullptr** を返します。

```cpp
// Returns accelerometer ref if there is one; nullptr otherwise.
m_accelerometer = Windows::Devices::Sensors::Accelerometer::GetDefault();
```

##  <a name="navigating-the-menus"></a>メニューの操作

メニューの操作には、次のようにマウス、タッチ、Xbox コントローラーを使うことができます。

-   アクティブなメニュー項目を変更するには、方向パッドを使います。
-   メニュー項目を選択したり現在のメニュー (ハイスコア表など) を閉じたりするには、タッチ、A ボタン、メニュー ボタンを使います。
-   ゲームを一時停止または再開するには、メニュー ボタンを使います。
-   操作を選択するには、マウスでそのメニュー項目をクリックします。

###  <a name="tracking-xbox-controller-input"></a>Xbox コントローラーの入力のトラッキング

デバイスに現在接続されているゲームパッドを追跡するために、**MarbleMazeMain** ではメンバー変数 **m_myGamepads** を定義します。これは、[Windows::Gaming::Input::Gamepad](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad) オブジェクトのコレクションです。 これは、次のようなコンストラクターで初期化されます。

```cpp
m_myGamepads = ref new Vector<Gamepad^>();

for (auto gamepad : Gamepad::Gamepads)
{
    m_myGamepads->Append(gamepad);
}
```

さらに、**MarbleMazeMain** コンストラクターはゲームパッドが追加または削除されたときのイベントを登録します。

```cpp
Gamepad::GamepadAdded += 
    ref new EventHandler<Gamepad^>([=](Platform::Object^, Gamepad^ args)
{
    m_myGamepads->Append(args);
    m_currentGamepadNeedsRefresh = true;
});

Gamepad::GamepadRemoved += 
    ref new EventHandler<Gamepad ^>([=](Platform::Object^, Gamepad^ args)
{
    unsigned int indexRemoved;

    if (m_myGamepads->IndexOf(args, &indexRemoved))
    {
        m_myGamepads->RemoveAt(indexRemoved);
        m_currentGamepadNeedsRefresh = true;
    }
});
```

ゲームパッドが追加されると、**m_myGamepads** に追加されます。ゲームパッドが削除されると、そのゲームパッドが **m_myGamepads** に存在するかどうかを確認し、存在する場合は削除します。 どちらの場合も、**m_currentGamepadNeedsRefresh** を **true** に設定し、**m_gamepad** の再割り当てが必要なことを示します。

最後に、ゲームパッドを **m_gamepad** に割り当てて、**m_currentGamepadNeedsRefresh** を **false** に設定します。

```cpp
m_gamepad = GetLastGamepad();
m_currentGamepadNeedsRefresh = false;
```

**Update** メソッドで、**m_gamepad** を再割り当てする必要があるかどうかを確認します。

```cpp
if (m_currentGamepadNeedsRefresh)
{
    auto mostRecentGamepad = GetLastGamepad();

    if (m_gamepad != mostRecentGamepad)
    {
        m_gamepad = mostRecentGamepad;
    }

    m_currentGamepadNeedsRefresh = false;
}
```

**m_gamepad** を再割り当てする必要がある場合は、次のように定義された **GetLastGamepad** を使用して、最後に追加されたゲームパッドをそれに割り当てます。

```cpp
Gamepad^ MarbleMaze::MarbleMazeMain::GetLastGamepad()
{
    Gamepad^ gamepad = nullptr;

    if (m_myGamepads->Size > 0)
    {
        gamepad = m_myGamepads->GetAt(m_myGamepads->Size - 1);
    }

    return gamepad;
}
```

このメソッドは、単純に最後のゲームパッドを **m_myGamepads** に返します。

1 台の Windows 10 デバイスには最大 4 つの Xbox コントローラーを接続できます。 どのコントローラーがアクティブであるかを特定にすることを回避するために、単に最後に追加されたゲームパッドのみを追跡しています。 複数プレイヤーをサポートするゲームでは、各プレイヤーの入力を個別にトラッキングする必要があります。

**MarbleMazeMain::Update** メソッドは、ゲームパッドの入力をポーリングします。

```cpp
if (m_gamepad != nullptr)
{
    m_oldReading = m_newReading;
    m_newReading = m_gamepad->GetCurrentReading();
}
```

最後のフレームで取得した入力の読み取り値は **m_oldReading** を使用して追跡し、最新の入力の読み取り値は **m_newReading** を使用して追跡します。最新の入力は [gamepad::getcurrentreading](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.GetCurrentReading) を呼び出すことによって取得します。 これは [GamepadReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadreading) オブジェクトを返します。このオブジェクトには、ゲームパッドの現在の状態に関する情報が含まれます。

ボタンがたった今押されたか、離されたかを確認するために、**MarbleMazeMain::ButtonJustPressed** と **MarbleMazeMain::ButtonJustReleased** を定義しています。これは、このフレームと最後のフレームからのボタンの読み取り値を比較します。 これによって、ボタンが最初に押されたか、離されたときにのみアクションを実行し、ボタンが押されたままになっているときは実行しないようにできます。

```cpp
bool MarbleMaze::MarbleMazeMain::ButtonJustPressed(GamepadButtons selection)
{
    bool newSelectionPressed = (selection == (m_newReading.Buttons & selection));
    bool oldSelectionPressed = (selection == (m_oldReading.Buttons & selection));
    return newSelectionPressed && !oldSelectionPressed;
}

bool MarbleMaze::MarbleMazeMain::ButtonJustReleased(GamepadButtons selection)
{
    bool newSelectionReleased = 
        (GamepadButtons::None == (m_newReading.Buttons & selection));

    bool oldSelectionReleased = 
        (GamepadButtons::None == (m_oldReading.Buttons & selection));

    return newSelectionReleased && !oldSelectionReleased;
}
```

[GamepadButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons) の読み取り値は、ビット単位の演算を使用して比較されます。ボタンが押されたかどうかは、*ビット演算 AND* (&) を使用して確認します。 前回の読み取り値と新しい読み取り値を比較することによって、ボタンがたった今押されたか、離されたかを特定します。

上記の方法を使用して、特定のボタンが押されたかどうかを確認し、必要な対応するアクションを実行します。 たとえば、メニュー ボタン (**GamepadButtons::Menu**) が押されたときは、ゲームの状態がアクティブから一時停止、または一時停止からアクティブに変わります。

```cpp
if (ButtonJustPressed(GamepadButtons::Menu) || m_pauseKeyPressed)
{
    m_pauseKeyPressed = false;

    if (m_gameState == GameState::InGameActive)
    {
        SetGameState(GameState::InGamePaused);
    }  
    else if (m_gameState == GameState::InGamePaused)
    {
        SetGameState(GameState::InGameActive);
    }
}
```

また、プレイヤーがビュー ボタンを押したかどうかを確認して、ビュー ボタンが押された場合は、ゲームを再起動したり、ハイ スコア表をクリアしたりします。

```cpp
if (ButtonJustPressed(GamepadButtons::View) || m_homeKeyPressed)
{
    m_homeKeyPressed = false;

    if (m_gameState == GameState::InGameActive ||
        m_gameState == GameState::InGamePaused ||
        m_gameState == GameState::PreGameCountdown)
    {
        SetGameState(GameState::MainMenu);
        m_inGameStopwatchTimer.SetVisible(false);
        m_preGameCountdownTimer.SetVisible(false);
    }
    else if (m_gameState == GameState::HighScoreDisplay)
    {
        m_highScoreTable.Reset();
    }
}
```

メイン メニューがアクティブである場合、方向パッドが上方向または下方向へ押されるとアクティブなメニュー項目が変わります。 ユーザーが現在の選択項目を選択すると、該当する UI 要素が選択中としてマークされます。

```cpp
// Handle menu navigation.
bool chooseSelection = 
    (ButtonJustPressed(GamepadButtons::A) 
    || ButtonJustPressed(GamepadButtons::Menu));

bool moveUp = ButtonJustPressed(GamepadButtons::DPadUp);
bool moveDown = ButtonJustPressed(GamepadButtons::DPadDown);

switch (m_gameState)
{
case GameState::MainMenu:
    if (chooseSelection)
    {
        m_audio.PlaySoundEffect(MenuSelectedEvent);
        if (m_startGameButton.GetSelected())
        {
            m_startGameButton.SetPressed(true);
        }
        if (m_highScoreButton.GetSelected())
        {
            m_highScoreButton.SetPressed(true);
        }
    }
    if (moveUp || moveDown)
    {
        m_startGameButton.SetSelected(!m_startGameButton.GetSelected());
        m_highScoreButton.SetSelected(!m_startGameButton.GetSelected());
        m_audio.PlaySoundEffect(MenuChangeEvent);
    }
    break;

case GameState::HighScoreDisplay:
    if (chooseSelection || anyPoints)
    {
        SetGameState(GameState::MainMenu);
    }
    break;

case GameState::PostGameResults:
    if (chooseSelection || anyPoints)
    {
        SetGameState(GameState::HighScoreDisplay);
    }
    break;

case GameState::InGamePaused:
    if (m_pausedText.IsPressed())
    {
        m_pausedText.SetPressed(false);
        SetGameState(GameState::InGameActive);
    }
    break;
}
```

### <a name="tracking-touch-and-mouse-input"></a>タッチとマウスによる入力のトラッキング

タッチとマウスによる入力では、メニュー項目は、ユーザーがその項目をタッチまたはクリックしたときに選択されます。 次の例は、**MarbleMazeMain::Update** メソッドがポインターの入力を処理してメニュー項目を選択する方法を示します。 **m\_pointQueue** メンバー変数は、ユーザーが画面上でタッチまたはクリックした場所をトラッキングします。 Marble Maze のポインター入力の収集方法については、このドキュメントの「[ポインターの入力の処理](#processing-pointer-input)」で詳しく説明します。

```cpp
// Check whether the user chose a button from the UI. 
bool anyPoints = !m_pointQueue.empty();
while (!m_pointQueue.empty())
{
    UserInterface::GetInstance().HitTest(m_pointQueue.front());
    m_pointQueue.pop();
}
```

**UserInterface::HitTest** メソッドは、指定された点が UI 要素の境界内にあるかどうかを判断します。 このテストに合格した UI 要素はすべて、タッチされているとマークされます。 このメソッドは、指定された点が各 UI 要素の境界内にあるかどうかを判断するために **PointInRect** ヘルパー関数を利用します。

```cpp
void UserInterface::HitTest(D2D1_POINT_2F point)
{
    for (auto iter = m_elements.begin(); iter != m_elements.end(); ++iter)
    {
        if (!(*iter)->IsVisible())
            continue;

        TextButton* textButton = dynamic_cast<TextButton*>(*iter);
        if (textButton != nullptr)
        {
            D2D1_RECT_F bounds = (*iter)->GetBounds();
            textButton->SetPressed(PointInRect(point, bounds));
        }
    }
}
```

### <a name="updating-the-game-state"></a>ゲームの状態の更新

コントローラーとタッチの入力を処理した後、**MarbleMazeMain::Update** メソッドは、いずれかのボタンが押された場合にゲームの状態を更新します。

```cpp
// Update the game state if the user chose a menu option. 
if (m_startGameButton.IsPressed())
{
    SetGameState(GameState::PreGameCountdown);
    m_startGameButton.SetPressed(false);
}
if (m_highScoreButton.IsPressed())
{
    SetGameState(GameState::HighScoreDisplay);
    m_highScoreButton.SetPressed(false);
}
```

##  <a name="controlling-game-play"></a>ゲーム プレイの制御


ゲーム ループと **MarbleMazeMain::Update** メソッドは、連携してゲーム オブジェクトの状態を更新します。 多様なデバイスからの入力を受け付けるゲームを開発する場合、すべてのデバイスからの入力を一連の変数に蓄積することで保守しやすいコードを作成することができます。 **MarbleMazeMain::Update** メソッドは、すべてのデバイスからの動作を蓄積する一連の変数を定義します。

```cpp
float combinedTiltX = 0.0f;
float combinedTiltY = 0.0f;
```

入力機構は入力デバイスによって異なります。 たとえば、ポインターの入力は Windows ランタイムのイベント処理モデルを使って処理されます。 これに対して、Xbox コントローラーからの入力データは必要なときに自分でポーリングします。 デバイスごとに定められた入力機構に常に従うことをお勧めします。 このセクションでは、Marble Maze が各デバイスからの入力を読み取り、結合された入力値を更新し、結合された入力値を使ってゲームの状態を更新する方法について説明します。

###  <a name="processing-pointer-input"></a>ポインターの入力の処理

ポインターの入力を処理するときは、[Windows::UI::Core::CoreDispatcher::ProcessEvents](https://docs.microsoft.com/uwp/api/windows.ui.core.coredispatcher.processevents) メソッドを呼び出してウィンドウ イベントを処理します。 このメソッドは、ゲーム ループ内でシーンの更新またはレンダリングの前に呼び出します。 Marble Maze では、**App::Run** メソッドでこれを呼び出します。 

```cpp
while (!m_windowClosed)
{
    if (m_windowVisible)
    {
        CoreWindow::GetForCurrentThread()->
            Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);

        m_main->Update();

        if (m_main->Render())
        {
            m_deviceResources->Present();
        }
    }
    else
    {
        CoreWindow::GetForCurrentThread()->
            Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessOneAndAllPending);
    }
}
```

ウィンドウが表示されている場合、**CoreProcessEventsOption::ProcessAllIfPresent** を **ProcessEvents** に渡してキュー内のすべてのイベントを処理し、直ちに制御を戻します。それ以外の場合は、**CoreProcessEventsOption::ProcessOneAndAllPending** を渡してキュー内のすべてのイベントを処理し、次の新しいイベントを待機します。 イベントの処理後に Marble Maze はレンダリングを行い、次のフレームを表示します。

Windows ランタイムは、イベントが発生するたびに、登録されているハンドラーを呼び出します。 **App::SetWindow** メソッドはイベントを登録し、ポインターの情報を **MarbleMazeMain** クラスに転送します。

```cpp
void App::OnPointerPressed(
    Windows::UI::Core::CoreWindow^ sender, 
    Windows::UI::Core::PointerEventArgs^ args)
{
    m_main->AddTouch(args->CurrentPoint->PointerId, args->CurrentPoint->Position);
}

void App::OnPointerReleased(
    Windows::UI::Core::CoreWindow^ sender, 
    Windows::UI::Core::PointerEventArgs^ args)
{
    m_main->RemoveTouch(args->CurrentPoint->PointerId);
}

void App::OnPointerMoved(
    Windows::UI::Core::CoreWindow^ sender, 
    Windows::UI::Core::PointerEventArgs^ args)
{
    m_main->UpdateTouch(args->CurrentPoint->PointerId, args->CurrentPoint->Position);
}
```

**MarbleMazeMain** クラスは、タッチ イベントを保持する map オブジェクトを更新することによってポインター イベントに対応します。 **MarbleMazeMain::AddTouch** メソッドは、ポインターが最初に押されたとき (たとえばタッチ対応デバイス上でユーザーが最初に画面に触れたとき) に呼び出されます。 **MarbleMazeMain::UpdateTouch** メソッドは、ポインターの位置が移動したときに呼び出されます。 **MarbleMazeMain::RemoveTouch** メソッドは、ポインターが離されたとき (たとえばユーザーが画面に触れるのを止めたとき) に呼び出されます。

```cpp
void MarbleMazeMain::AddTouch(int id, Windows::Foundation::Point point)
{
    m_touches[id] = PointToTouch(point, m_deviceResources->GetLogicalSize());

    m_pointQueue.push(D2D1::Point2F(point.X, point.Y));
}

void MarbleMazeMain::UpdateTouch(int id, Windows::Foundation::Point point)
{
    if (m_touches.find(id) != m_touches.end())
        m_touches[id] = PointToTouch(point, m_deviceResources->GetLogicalSize());
}

void MarbleMazeMain::RemoveTouch(int id)
{
    m_touches.erase(id);
}
```

**PointToTouch** 関数は、原点が画面の中心に来るように現在のポインターの位置を変換した後、座標をスケーリングして、およそ -1.0 ～ +1.0 の範囲内になるようにします。 これにより、入力方法の違いにかかわらず、一貫した方法で容易に迷路の傾きを計算することができます。

```cpp
inline XMFLOAT2 PointToTouch(Windows::Foundation::Point point, Windows::Foundation::Size bounds)
{
    float touchRadius = min(bounds.Width, bounds.Height);
    float dx = (point.X - (bounds.Width / 2.0f)) / touchRadius;
    float dy = ((bounds.Height / 2.0f) - point.Y) / touchRadius;

    return XMFLOAT2(dx, dy);
}
```

**MarbleMazeMain::Update** メソッドは、傾き係数を一定のスケーリング値ずつインクリメントすることにより、結合された入力値を更新します。 このスケーリング値は、いくつかの値を試して決定されました。

```cpp
// Account for touch input.
for (TouchMap::const_iterator iter = m_touches.cbegin(); 
    iter != m_touches.cend(); 
    ++iter)
{
    combinedTiltX += iter->second.x * m_touchScaleFactor;
    combinedTiltY += iter->second.y * m_touchScaleFactor;
}
```

### <a name="processing-accelerometer-input"></a>加速度計の入力の処理

加速度計の入力を処理するために、**MarbleMazeMain::Update** メソッドは [Windows::Devices::Sensors::Accelerometer::GetCurrentReading](https://msdn.microsoft.com/library/windows/apps/br225699) メソッドを呼び出します。 このメソッドは、加速度計の測定値を表す [Windows::Devices::Sensors::AccelerometerReading](https://msdn.microsoft.com/library/windows/apps/br225688) オブジェクトを返します。 **Windows::Devices::Sensors::AccelerometerReading::AccelerationX** プロパティと **Windows::Devices::Sensors::AccelerometerReading::AccelerationY** プロパティは、X 軸方向と Y 軸方向の重力加速度をそれぞれ保持します。

次の例は、**MarbleMazeMain::Update** メソッドが加速度計をポーリングし、結合された入力値の更新を行う方法を示します。 デバイスを傾けると、重力によって大理石が速く移動します。

```cpp
// Account for sensors.
if (m_accelerometer != nullptr)
{
    Windows::Devices::Sensors::AccelerometerReading^ reading =
        m_accelerometer->GetCurrentReading();

    if (reading != nullptr)
    {
        combinedTiltX += 
            static_cast<float>(reading->AccelerationX) * m_accelerometerScaleFactor;

        combinedTiltY += 
            static_cast<float>(reading->AccelerationY) * m_accelerometerScaleFactor;
    }
}
```

ユーザーのコンピューターに加速度計が搭載されているかどうかは不確かなため、加速度計のポーリングを行う前には必ず、有効な [Accelerometer](https://docs.microsoft.com/uwp/api/Windows.Devices.Sensors.Accelerometer) オブジェクトがあることを確認してください。

### <a name="processing-xbox-controller-input"></a>Xbox コントローラーの入力の処理

**MarbleMazeMain::Update** メソッドで、**m_newReading** を使用して、左のアナログ スティックからの入力を処理します。

```cpp
float leftStickX = static_cast<float>(m_newReading.LeftThumbstickX);
float leftStickY = static_cast<float>(m_newReading.LeftThumbstickY);

auto oppositeSquared = leftStickY * leftStickY;
auto adjacentSquared = leftStickX * leftStickX;

if ((oppositeSquared + adjacentSquared) > m_deadzoneSquared)
{
    combinedTiltX += leftStickX * m_controllerScaleFactor;
    combinedTiltY += leftStickY * m_controllerScaleFactor;
}
```

左のアナログ スティックからの入力がデッド ゾーンの範囲外であるかどうかを確認し、範囲外である場合は、それを **combinedTiltX** と **combinedTiltY** (スケール係数を乗算した値) に追加して、ステージを傾けます。

> [!IMPORTANT]
> Xbox コントローラーを使うときは、常にデッド ゾーンを考慮してください。 デッド ゾーンとは、ゲームパッド間の、最初の移動に対する感度の差異を指します。 小さな移動があったときに、あるコントローラーでは測定値が生成されないのに、別のコントローラーでは測定値が生成されることがあります。 これをゲームで考慮するために、サムスティックの最初の移動に対して、移動なしと見なすゾーンを作成します。 デッド ゾーンについて詳しくは、「[サムスティックの読み取り](gamepad-and-vibration.md#reading-the-thumbsticks)」をご覧ください。

 

###  <a name="applying-input-to-the-game-state"></a>ゲームの状態への入力の適用

デバイスは、さまざまな方法で入力値を報告します。 たとえば、ポインターの入力は通常、画面座標で報告されますが、コントローラーの入力の形式は、それとはまったく異なることが考えられます。 複数のデバイスからの入力を一連の入力値に結合する際の課題の 1 つに、正規化 (共通形式への値の変換) があります。 Marble Maze は、値を範囲 \[-1.0, 1.0\] にスケーリングすることによって正規化します。 このセクションで既に説明した **PointToTouch** 関数は、画面座標をおよそ -1.0 ～ +1.0 の範囲内の正規化された値に変換します。

> [!TIP]
> アプリケーションで用いられる入力方法が 1 つであっても、常に入力値を正規化することをお勧めします。 そうすることで、ゲームの他のコンポーネント (物理シミュレーションなど) が入力を解釈する方法を簡略化でき、さまざまな画面解像度で動作するゲームが作成しやすくなります。

 

入力を処理した後、**MarbleMazeMain::Update** メソッドは、大理石に対する迷路の傾きの影響を表すベクターを作成します。 次の例は、Marble Maze が [XMVector3Normalize](https://msdn.microsoft.com/library/windows/desktop/microsoft.directx_sdk.geometric.xmvector3normalize) 関数を使って正規化された重力ベクターを作成する方法を示します。 **maxTilt** 変数は迷路の傾きの量を制限し、迷路が横向きに傾けられるのを防ぎます。

```cpp
const float maxTilt = 1.0f / 8.0f;

XMVECTOR gravity = XMVectorSet(
    combinedTiltX * maxTilt, 
    combinedTiltY * maxTilt, 
    1.0f, 
    0.0f);

gravity = XMVector3Normalize(gravity);
```

シーン オブジェクトの更新を完了するために、Marble Maze は更新された重力ベクターを物理シミュレーションに渡し、前のフレームからの経過時間の物理シミュレーションを更新したうえで、大理石の位置と方向を更新します。 大理石が迷路から落ちた場合、**MarbleMazeMain::Update** メソッドは、最後に接触したチェックポイントまで大理石を戻し、物理シミュレーションの状態をリセットします。

```cpp
XMFLOAT3A g;
XMStoreFloat3(&g, gravity);
m_physics.SetGravity(g);

if (m_gameState == GameState::InGameActive)
{
    // Only update physics when gameplay is active.
    m_physics.UpdatePhysicsSimulation(static_cast<float>(m_timer.GetElapsedSeconds()));

    // ...Code omitted for simplicity...

}

// ...Code omitted for simplicity...

// Check whether the marble fell off of the maze. 
const float fadeOutDepth = 0.0f;
const float resetDepth = 80.0f;
if (marblePosition.z >= fadeOutDepth)
{
    m_targetLightStrength = 0.0f;
}
if (marblePosition.z >= resetDepth)
{
    // Reset marble.
    memcpy(&marblePosition, &m_checkpoints[m_currentCheckpoint], sizeof(XMFLOAT3));
    oldMarblePosition = marblePosition;
    m_physics.SetPosition((const XMFLOAT3&)marblePosition);
    m_physics.SetVelocity(XMFLOAT3(0, 0, 0));
    m_lightStrength = 0.0f;
    m_targetLightStrength = 1.0f;

    m_resetCamera = true;
    m_resetMarbleRotation = true;
    m_audio.PlaySoundEffect(FallingEvent);
}
```

このセクションでは、物理シミュレーションのしくみについては説明しません。 詳しくは、Marble Maze のソースの **Physics.h** と **Physics.cpp** をご覧ください。

## <a name="next-steps"></a>次の手順


オーディオを扱う際の主な手法については、「[Marble Maze サンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)」をご覧ください。 このドキュメントでは、Marble Maze が Microsoft メディア ファンデーションと XAudio2 を使ってオーディオ リソースの読み込み、ミキシング、再生を行う方法について説明しています。

## <a name="related-topics"></a>関連トピック


* [Marble Maze のサンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)
* [Marble Maze サンプルへの視覚的なコンテンツの追加](adding-visual-content-to-the-marble-maze-sample.md)
* [Marble Maze、C++ と DirectX での UWP ゲームの開発](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 




