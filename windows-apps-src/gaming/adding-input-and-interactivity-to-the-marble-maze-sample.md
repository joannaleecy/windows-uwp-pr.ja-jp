---
author: mtoepke
title: "Marble Maze サンプルへの入力と対話機能の追加"
description: "ユニバーサル Windows プラットフォーム (UWP) アプリ ゲームは、デスクトップ コンピューター、ノート PC、タブレットなど、さまざまなデバイスで実行されます。"
ms.assetid: b946bf62-c0ca-f9ec-1a87-8195b89a5ab4
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: ddaa13c6bf7d1bcf5a01d7525389a893a077f4f4

---

# Marble Maze サンプルへの入力と対話機能の追加


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください \]


ユニバーサル Windows プラットフォーム (UWP) アプリ ゲームは、デスクトップ コンピューター、ノート PC、タブレットなど、さまざまなデバイスで実行されます。 デバイスに備わっている入力機構と制御機構も多岐にわたります。 多様な入力デバイスをサポートすることによって、ゲーム ユーザーの好みや技量に幅広く対応することができます。 このドキュメントでは、入力デバイスを扱う際に考慮する必要のある主な手法について説明すると共に、それらが Marble Maze でどのように適用されているかを紹介します。

> **注**   このドキュメントに対応するサンプル コードは、[DirectX Marble Maze ゲームのサンプルに関するページ](http://go.microsoft.com/fwlink/?LinkId=624011)にあります。

 
このドキュメントでは、ゲームで入力を扱う際に重要となるいくつかの事柄について説明します。取り上げる内容は次のとおりです。

-   可能な限り、多様な入力デバイスをサポートし、ゲーム ユーザーの好みや技量に幅広く対応します。 ゲーム コントローラーやセンサーは、必ずしも使う必要はありませんが、プレーヤーのエクスペリエンスを高めるために使用を強くお勧めします。 ゲーム コントローラーとセンサー API は、これらの入力デバイスと容易に連携できるように設計されています。
-   タッチを初期化するには、ポインターがアクティブ化されたとき、離されたとき、移動されたときなどのウィンドウ イベントを登録する必要があります。 加速度計を初期化するには、アプリケーションの初期化時に [**Windows::Devices::Sensors::Accelerometer**](https://msdn.microsoft.com/library/windows/apps/br225687) オブジェクトを作成します。 Xbox 360 コントローラーは初期化を必要としません。
-   1 プレーヤーのゲームでは、接続されているすべての Xbox 360 コントローラーからの入力を結合します。 このようにすることで、入力とその発生元となったコントローラーの関係をトラッキングする手間が省けます。
-   入力デバイスを処理する前に、Windows イベントを処理します。
-   Xbox 360 コントローラーと加速度計では、ポーリングがサポートされています。 つまり、必要に応じてデータをポーリングできます。 タッチの場合は、入力処理コードで利用できるデータ構造にタッチ イベントを記録します。
-   入力値を共通形式に正規化します。 ゲームの他のコンポーネント (物理シミュレーションなど) が入力を解釈する方法を簡略化でき、さまざまな画面解像度で動作するゲームが作成しやすくなります。

## Marble Maze でサポートされる入力デバイス


Marble Maze は、メニュー項目の選択に関して Xbox 360 共通コントローラー デバイス、マウス、タッチをサポートし、ゲーム プレイの制御に関して Xbox 360 コントローラー、マウス、タッチ、加速度計をサポートします。 Marble Maze は、XInput API を使ってコントローラーの入力をポーリングします。 アプリケーションは、タッチ デバイスを通じて指先での入力をトラッキングし、応答することができます。 加速度計は、x、y、z 軸方向に加えられた力を測定するセンサーです。 Windows ランタイムを使うと、Windows ランタイムのイベント処理機構を通じてタッチ イベントを受け取るだけでなく、加速度計デバイスの現在の状態をポーリングすることもできます。

> **注**  このドキュメントでは、タッチとマウスの両方の入力をタッチと呼び、ポインター イベントを使うすべてのデバイスをポインターと呼びます。 タッチとマウスは標準のポインター イベントを利用するため、どちらのデバイスでもメニュー項目の選択とゲーム プレイの制御を行うことができます。

 

> **注**  デバイスを回転させて大理石を転がす際、方向が変わるのを防ぐために、パッケージ マニフェストは、ゲームでサポートされる回転として [横] を設定します。

 

## 入力デバイスの初期化


Xbox 360 コントローラーは初期化を必要としません。 タッチを初期化するには、ポインターがアクティブになったとき (たとえばユーザーがマウス ボタンを押すか画面に触れたとき)、離されたとき、移動されたときなどのウィンドウ イベントを登録する必要があります。 加速度計を初期化するには、アプリケーションの初期化時に [**Windows::Devices::Sensors::Accelerometer**](https://msdn.microsoft.com/library/windows/apps/br225687) オブジェクトを作成する必要があります。

次の例では、**DirectXPage** コンストラクターが [**SwapChainPanel**](https://msdn.microsoft.com/library/windows/apps/dn252834) の [**Windows::UI::Core::CoreIndependentInputSource::PointerPressed**](https://msdn.microsoft.com/library/windows/apps/dn298471) ポインター イベント、[**Windows::UI::Core::CoreIndependentInputSource::PointerReleased**](https://msdn.microsoft.com/library/windows/apps/dn298472) ポインター イベント、および [**Windows::UI::Core::CoreIndependentInputSource::PointerMoved**](https://msdn.microsoft.com/library/windows/apps/dn298469) ポインター イベントに対して登録する方法を示しています。 これらのイベントは、アプリの初期化中、ゲーム ループの前に登録されます。

これらのイベントは、イベント ハンドラーを呼び出す別のスレッドで処理されます。

アプリケーションの初期化方法について詳しくは、「[Marble Maze のアプリケーション構造](marble-maze-application-structure.md)」をご覧ください。

```cpp
coreInput->PointerPressed += ref new TypedEventHandler<Object^, PointerEventArgs^>(this, &DirectXPage::OnPointerPressed);
coreInput->PointerMoved += ref new TypedEventHandler<Object^, PointerEventArgs^>(this, &DirectXPage::OnPointerMoved);
coreInput->PointerReleased += ref new TypedEventHandler<Object^, PointerEventArgs^>(this, &DirectXPage::OnPointerReleased);
```

また、MarbleMaze クラスはタッチ イベントを保持するための std::map オブジェクトを作成します。 この map オブジェクトのキーは、入力ポインターを一意に識別する値です。 それぞれのキーは、各タッチ ポイントと画面の中央の間の距離にマップされます。 後で迷路の傾きの量を計算するときに、これらの値が使われます。

```cpp
typedef std::map<int, XMFLOAT2> TouchMap;
TouchMap        m_touches;
```

MarbleMaze クラスは Accelerometer オブジェクトを保持します。

```cpp
Windows::Devices::Sensors::Accelerometer^           m_accelerometer;
```

Accelerometer オブジェクトは、次の例に示すように MarbleMaze::Initialize メソッドで初期化されます。 Windows::Devices::Sensors::Accelerometer::GetDefault メソッドは既定の加速度計のインスタンスを返します。 既定の加速度計がない場合、Accelerometer::GetDefault の m\_accelerometer 値は nullptr のままになります。

```cpp
// Returns accelerometer ref if there is one; nullptr otherwise.
m_accelerometer = Windows::Devices::Sensors::Accelerometer::GetDefault();
```

##  メニューの操作


###  Xbox 360 コントローラーの入力のトラッキング

メニューの操作には、次のようにマウス、タッチ、Xbox 360 コントローラーを使うことができます。

-   アクティブなメニュー項目を変更するには、方向パッドを使います。
-   メニュー項目を選択したり現在のメニュー (ハイスコア表など) を閉じたりするには、タッチ、A ボタン、[スタート] ボタンを使います。
-   ゲームを一時停止または再開するには、[スタート] ボタンを使います。
-   操作を選択するには、マウスでそのメニュー項目をクリックします。

###  タッチとマウスによる入力のトラッキング

Xbox 360 コントローラーの入力をトラッキングするために、**MarbleMaze::Update** メソッドは入力動作を定義するボタンの配列を定義します。 XInput から提供されるのは、コントローラーの現在の状態のみです。 そのため、**MarbleMaze::Update** も 2 つの配列を定義します。使用可能な各 Xbox 360 コントローラーについて、各ボタンが前のフレームの間に押されたかどうかと、各ボタンが現在押されているかどうかをこれらの配列によってトラッキングします。

```cpp
// This array contains the constants from XINPUT that map to the 
// particular buttons that are used by the game. 
// The index of the array is used to associate the state of that button in 
// the wasButtonDown, isButtonDown, and combinedButtonPressed variables. 

static const WORD buttons[] = {
    XINPUT_GAMEPAD_A,
    XINPUT_GAMEPAD_START,
    XINPUT_GAMEPAD_DPAD_UP,
    XINPUT_GAMEPAD_DPAD_DOWN,
    XINPUT_GAMEPAD_DPAD_LEFT,
    XINPUT_GAMEPAD_DPAD_RIGHT,
    XINPUT_GAMEPAD_BACK,
};

static const int buttonCount = ARRAYSIZE(buttons);
static bool wasButtonDown[XUSER_MAX_COUNT][buttonCount] = { false, };
bool isButtonDown[XUSER_MAX_COUNT][buttonCount] = { false, };
```

1 台の Windows デバイスには最大 4 つの Xbox 360 コントローラーを接続できます。 どのコントローラーがアクティブであるかを識別する手間を省くため、**MarbleMaze::Update** メソッドは、すべてのコントローラーの入力を結合します。

```cpp
bool combinedButtonPressed[buttonCount] = { false, };
```

複数プレーヤーをサポートするゲームでは、各プレーヤーの入力を個別にトラッキングする必要があります。

**MarbleMaze::Update** メソッドは、ループ内で各コントローラーの入力をポーリングし、各ボタンの状態を読み込みます。

```cpp
// Account for input on any connected controller.
XINPUT_STATE inputState = {0};
for (DWORD userIndex = 0; userIndex < XUSER_MAX_COUNT; ++userIndex)
{
    DWORD result = XInputGetState(userIndex, &inputState);
    if(result != ERROR_SUCCESS) 
        continue;

    SHORT thumbLeftX = inputState.Gamepad.sThumbLX;
    if (abs(thumbLeftX) < XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE) 
        thumbLeftX = 0;

    SHORT thumbLeftY = inputState.Gamepad.sThumbLY;
    if (abs(thumbLeftY) < XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE) 
        thumbLeftY = 0;

    combinedTiltX += static_cast<float>(thumbLeftX) / 32768.0f;
    combinedTiltY += static_cast<float>(thumbLeftY) / 32768.0f;

    for (int i = 0; i < buttonCount; ++i)
        isButtonDown[userIndex][i] = (inputState.Gamepad.wButtons & buttons[i]) == buttons[i];
}
```

入力のポーリング後、**MarbleMaze::Update** メソッドは結合された入力配列を更新します。 結合された入力配列によってトラッキングされるのは、現在は押されているが、それ以前は押されていなかったボタンのみです。 これによって、ボタンが最初に押されたときにのみアクションを実行し、ボタンが押されたままになっているときは実行しないようにできます。

```cpp
bool combinedButtonPressed[buttonCount] = { false, };
for (int i = 0; i < buttonCount; ++i)
{
    for (DWORD userIndex = 0; userIndex < XUSER_MAX_COUNT; ++userIndex)
    {
        bool pressed = !wasButtonDown[userIndex][i] && isButtonDown[userIndex][i];
        combinedButtonPressed[i] = combinedButtonPressed[i] || pressed;
    }
}
```

ボタンの入力を収集した後、**MarbleMaze::Update** メソッドは必要なアクションがあれば実行します。 たとえば、[スタート] ボタン (XINPUT\_GAMEPAD\_START) が押されたときは、ゲームの状態がアクティブから一時停止、または一時停止からアクティブに変わります。

```cpp
// Check whether the user paused or resumed the game. 
// XINPUT_GAMEPAD_START  
if (combinedButtonPressed[1] || m_pauseKeyPressed)
{
    m_pauseKeyPressed = false;
    if (m_gameState == GameState::InGameActive)
        SetGameState(GameState::InGamePaused);
    else if (m_gameState == GameState::InGamePaused)
        SetGameState(GameState::InGameActive);
}
```

メイン メニューがアクティブである場合、方向パッドが上方向または下方向へ押されるとアクティブなメニュー項目が変わります。 ユーザーが現在の選択項目を選択すると、該当する UI 要素が選択中としてマークされます。

```cpp
// Handle menu navigation. 

// XINPUT_GAMEPAD_A or XINPUT_GAMEPAD_START 
bool chooseSelection = (combinedButtonPressed[0] || combinedButtonPressed[1]);

// XINPUT_GAMEPAD_DPAD_UP 
bool moveUp = combinedButtonPressed[2];

// XINPUT_GAMEPAD_DPAD_DOWN 
bool moveDown = combinedButtonPressed[3];                                           

switch (m_gameState)
{
case GameState::MainMenu:
    if (chooseSelection)
    {
        m_audio.PlaySoundEffect(MenuSelectedEvent);

        if (m_startGameButton.GetSelected())
            m_startGameButton.SetPressed(true);

        if (m_highScoreButton.GetSelected())
            m_highScoreButton.SetPressed(true);
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
        SetGameState(GameState::MainMenu);
    break;

case GameState::PostGameResults:
    if (chooseSelection || anyPoints)
        SetGameState(GameState::HighScoreDisplay);
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

コントローラーの入力を処理した後、**MarbleMaze::Update** メソッドは次のフレームのために現在の入力状態を保存します。

```cpp
// Update the button state for the next frame.
memcpy(wasButtonDown, isButtonDown, sizeof(wasButtonDown));
```

### タッチとマウスによる入力のトラッキング

タッチとマウスによる入力では、メニュー項目は、ユーザーがその項目をタッチまたはクリックしたときに選択されます。 次の例は、**MarbleMaze::Update** メソッドがポインターの入力を処理してメニュー項目を選択する方法を示します。 **m\_pointQueue** メンバー変数は、ユーザーが画面上でタッチまたはクリックした場所をトラッキングします。 Marble Maze のポインター入力の収集方法については、このドキュメントの「ポインターの入力の処理」で詳しく説明します。

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

### ゲームの状態の更新

コントローラーとタッチの入力を処理した後、**MarbleMaze::Update** メソッドは、いずれかのボタンが押された場合にゲームの状態を更新します。

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

##  ゲーム プレイの制御


ゲーム ループと **MarbleMaze::Update** メソッドは、連携してゲーム オブジェクトの状態を更新します。 多様なデバイスからの入力を受け付けるゲームを開発する場合、すべてのデバイスからの入力を一連の変数に蓄積することで保守しやすいコードを作成することができます。 **MarbleMaze::Update** メソッドは、すべてのデバイスからの動作を蓄積する一連の変数を定義します。

```cpp
float combinedTiltX = 0.0f;
float combinedTiltY = 0.0f;
```

入力機構は入力デバイスによって異なります。 たとえば、ポインターの入力は Windows ランタイムのイベント処理モデルを使って処理されます。 これに対して、Xbox 360 コントローラーからの入力データは必要なときに自分でポーリングします。 デバイスごとに定められた入力機構に常に従うことをお勧めします。 このセクションでは、Marble Maze が各デバイスからの入力を読み取り、結合された入力値を更新し、結合された入力値を使ってゲームの状態を更新する方法について説明します。

###  ポインターの入力の処理

ポインターの入力を処理するときは、[**Windows::UI::Core::CoreDispatcher::ProcessEvents**](https://msdn.microsoft.com/library/windows/apps/br208217) メソッドを呼び出してウィンドウ イベントを処理します。 このメソッドは、ゲーム ループ内でシーンの更新またはレンダリングの前に呼び出します。 Marble Maze は、このメソッドに **CoreProcessEventsOption::ProcessAllIfPresent** を渡してキュー内のすべてのイベントを処理した後、すぐに制御を戻します。 イベントの処理後に Marble Maze はレンダリングを行い、次のフレームを表示します。

```cpp
// Process windowing events.
CoreWindow::GetForCurrentThread()->Dispatcher->ProcessEvents(CoreProcessEventsOption::ProcessAllIfPresent);
```

Windows ランタイムは、イベントが発生するたびに、登録されているハンドラーを呼び出します。 **DirectXApp** クラスはイベントを登録し、ポインターの情報を **MarbleMaze** クラスに転送します。

```cpp
void DirectXApp::OnPointerPressed(
    _In_ Windows::UI::Core::CoreWindow^ sender,
    _In_ Windows::UI::Core::PointerEventArgs^ args
    )
{
    m_renderer->AddTouch(args->CurrentPoint->PointerId, args->CurrentPoint->Position);
}

void DirectXApp::OnPointerReleased(
    _In_ Windows::UI::Core::CoreWindow^ sender,
    _In_ Windows::UI::Core::PointerEventArgs^ args
    )
{
    m_renderer->RemoveTouch(args->CurrentPoint->PointerId);
}

void DirectXApp::OnPointerMoved(
    _In_ Windows::UI::Core::CoreWindow^ sender,
    _In_ Windows::UI::Core::PointerEventArgs^ args
    )
{
    m_renderer->UpdateTouch(args->CurrentPoint->PointerId, args->CurrentPoint->Position);
}
```

**MarbleMaze** クラスは、タッチ イベントを保持する map オブジェクトを更新することによってポインター イベントに対応します。 **MarbleMaze::AddTouch** メソッドは、ポインターが最初に押されたとき (たとえばタッチ対応デバイス上でユーザーが最初に画面に触れたとき) に呼び出されます。 **MarbleMaze::AddTouch** メソッドは、ポインターの位置が移動したときに呼び出されます。 **MarbleMaze::RemoveTouch** メソッドは、ポインターが離されたとき (たとえばユーザーが画面に触れるのを止めたとき) に呼び出されます。

```cpp
void MarbleMaze::AddTouch(int id, Windows::Foundation::Point point)
{
    m_touches[id] = PointToTouch(point, m_windowBounds);

    m_pointQueue.push(D2D1::Point2F(point.X, point.Y));
}

void MarbleMaze::UpdateTouch(int id, Windows::Foundation::Point point)
{
    if (m_touches.find(id) != m_touches.end())
        m_touches[id] = PointToTouch(point, m_windowBounds);
}

void MarbleMaze::RemoveTouch(int id)
{
    m_touches.erase(id);
}
```

PointToTouch 関数は、原点が画面の中心に来るように現在のポインターの位置を変換した後、座標をスケーリングして、およそ -1.0 ～ +1.0 の範囲内になるようにします。 これにより、入力方法の違いにかかわらず、一貫した方法で容易に迷路の傾きを計算することができます。

```cpp
inline XMFLOAT2 PointToTouch(Windows::Foundation::Point point, Windows::Foundation::Rect bounds)
{
    float touchRadius = min(bounds.Width, bounds.Height);
    float dx = (point.X - (bounds.Width / 2.0f)) / touchRadius;
    float dy = ((bounds.Height / 2.0f) - point.Y) / touchRadius;

    return XMFLOAT2(dx, dy);
}
```

**MarbleMaze::Update** メソッドは、傾き係数を一定のスケーリング値ずつインクリメントすることにより、結合された入力値を更新します。 このスケーリング値は、いくつかの値を試して決定されました。

```cpp
// Account for touch input. 
const float touchScalingFactor = 2.0f;
for (TouchMap::const_iterator iter = m_touches.cbegin(); iter != m_touches.cend(); ++iter)
{
    combinedTiltX += iter->second.x * touchScalingFactor;
    combinedTiltY += iter->second.y * touchScalingFactor;
}
```

### 加速度計の入力の処理

加速度計の入力を処理するために、**MarbleMaze::Update** メソッドは [**Windows::Devices::Sensors::Accelerometer::GetCurrentReading**](https://msdn.microsoft.com/library/windows/apps/br225699) メソッドを呼び出します。 このメソッドは、加速度計の測定値を表す [**Windows::Devices::Sensors::AccelerometerReading**](https://msdn.microsoft.com/library/windows/apps/br225688) オブジェクトを返します。 **Windows::Devices::Sensors::AccelerometerReading::AccelerationX** プロパティと **Windows::Devices::Sensors::AccelerometerReading::AccelerationY** プロパティは、x 軸方向と y 軸方向の重力加速度をそれぞれ保持します。

次の例は、**MarbleMaze::Update** メソッドが加速度計をポーリングし、結合された入力値の更新を行う方法を示します。 デバイスを傾けると、重力によって大理石が速く移動します。

```cpp
// Account for sensors. 
const float acceleromterScalingFactor = 3.5f;
if (m_accelerometer != nullptr)
{
    Windows::Devices::Sensors::AccelerometerReading^ reading =
        m_accelerometer->GetCurrentReading();

    if (reading != nullptr)
    {
        combinedTiltX += static_cast<float>(reading->AccelerationX) * acceleromterScalingFactor;
        combinedTiltY += static_cast<float>(reading->AccelerationY) * acceleromterScalingFactor;
    }
}
```

ユーザーのコンピューターに加速度計が搭載されているかどうかは不確かなため、加速度計のポーリングを行う前には必ず、有効な Accelerometer オブジェクトがあることを確認してください。

### Xbox 360 コントローラーの入力の処理

次の例は、**MarbleMaze::Update** メソッドが Xbox 360 コントローラーからの読み取りを行い、結合された入力値を更新する方法を示します。 **MarbleMaze::Update** メソッドは for ループを使って、接続されたコントローラーから入力を受け取ることができるようにします。 **XInputGetState** メソッドは、XINPUT\_STATE オブジェクトにコントローラーの現在の状態を設定します。 **combinedTiltX** 値と **combinedTiltY** 値は、左スティックの x 値と y 値に従って更新されます。

```cpp
// Account for input on any connected controller.
XINPUT_STATE inputState = {0};
for (DWORD userIndex = 0; userIndex < XUSER_MAX_COUNT; ++userIndex)
{
    DWORD result = XInputGetState(userIndex, &inputState);
    if(result != ERROR_SUCCESS) 
        continue;

    SHORT thumbLeftX = inputState.Gamepad.sThumbLX;
    if (abs(thumbLeftX) < XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE) 
        thumbLeftX = 0;

    SHORT thumbLeftY = inputState.Gamepad.sThumbLY;
    if (abs(thumbLeftY) < XINPUT_GAMEPAD_LEFT_THUMB_DEADZONE) 
        thumbLeftY = 0;

    combinedTiltX += static_cast<float>(thumbLeftX) / 32768.0f;
    combinedTiltY += static_cast<float>(thumbLeftY) / 32768.0f;

    for (int i = 0; i < buttonCount; ++i)
        isButtonDown[userIndex][i] = (inputState.Gamepad.wButtons & buttons[i]) == buttons[i];
}
```

XInput は、左スティックの定数 **XINPUT\_GAMEPAD\_LEFT\_THUMB\_DEADZONE** を定義します。 これは、ほとんどのゲームに適したデッド ゾーンのしきい値です。

> **重要**  Xbox 360 コントローラーを使うときは、常にデッド ゾーンを考慮してください。 デッド ゾーンとは、ゲームパッド間の、最初の移動に対する感度の差異を指します。 小さな移動があったときに、あるコントローラーでは測定値が生成されないのに、別のコントローラーでは測定値が生成されることがあります。 これをゲームで考慮するために、サムスティックの最初の移動に対して、移動なしと見なすゾーンを作成します。 デッド ゾーンについて詳しくは、「[XInput の概要](https://msdn.microsoft.com/library/windows/desktop/ee417001)」をご覧ください。

 

###  ゲームの状態への入力の適用

デバイスは、さまざまな方法で入力値を報告します。 たとえば、ポインターの入力は通常、画面座標で報告されますが、コントローラーの入力の形式は、それとはまったく異なることが考えられます。 複数のデバイスからの入力を一連の入力値に結合する際の課題の 1 つに、正規化 (共通形式への値の変換) があります。 Marble Maze は、値を範囲 \[-1.0, 1.0\] にスケーリングすることによって正規化します。 Xbox 360 コントローラーの入力を正規化するために、Marble Maze は入力値を 32768 で除算します。これは、サムスティックの入力値が常に -32768 ～ 32767 の範囲内であるためです。 このセクションで既に説明した **PointToTouch** 関数は、画面座標をおよそ -1.0 ～ +1.0 の範囲内の正規化された値に変換することによって同様の結果を得ます。

> **ヒント**  アプリケーションで用いられる入力方法が 1 つであっても、常に入力値を正規化することをお勧めします。 そうすることで、ゲームの他のコンポーネント (物理シミュレーションなど) が入力を解釈する方法を簡略化でき、さまざまな画面解像度で動作するゲームが作成しやすくなります。

 

入力を処理した後、**MarbleMaze::Update** メソッドは、大理石に対する迷路の傾きの影響を表すベクターを作成します。 次の例は、Marble Maze が **XMVector3Normalize** 関数を使って正規化された重力ベクターを作成する方法を示します。 *MaxTilt* 変数は迷路の傾きの量を制限し、迷路が横向きに傾けられるのを防ぎます。

```cpp
const float maxTilt = 1.0f / 8.0f;
XMVECTOR gravity = XMVectorSet(combinedTiltX * maxTilt, combinedTiltY * maxTilt, 1.0f, 0.0f);
gravity = XMVector3Normalize(gravity);
```

シーン オブジェクトの更新を完了するために、Marble Maze は更新された重力ベクターを物理シミュレーションに渡し、前のフレームからの経過時間の物理シミュレーションを更新したうえで、大理石の位置と方向を更新します。 大理石が迷路から落ちた場合、**MarbleMaze::Update** メソッドは、最後に接触したチェックポイントまで大理石を戻し、物理シミュレーションの状態をリセットします。

```cpp
XMFLOAT3 g;
XMStoreFloat3(&g, gravity);
m_physics.SetGravity(g);
```

```cpp
// Only update physics when gameplay is active.
m_physics.UpdatePhysicsSimulation(timeDelta);
```

```cpp
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

このセクションでは、物理シミュレーションのしくみについては説明しません。 詳しくは、Marble Maze のソースの Physics.h と Physics.cpp をご覧ください。

## 次の手順


オーディオを扱う際の主な手法については、「[Marble Maze サンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)」をご覧ください。 このドキュメントでは、Marble Maze が Microsoft メディア ファンデーションと XAudio2 を使ってオーディオ リソースの読み込み、ミキシング、再生を行う方法について説明しています。

## 関連トピック


* [Marble Maze のサンプルへのオーディオの追加](adding-audio-to-the-marble-maze-sample.md)
* [Marble Maze サンプルへの視覚的なコンテンツの追加](adding-visual-content-to-the-marble-maze-sample.md)
* [Marble Maze、C++ と DirectX での UWP ゲームの開発](developing-marble-maze-a-windows-store-game-in-cpp-and-directx.md)

 

 







<!--HONumber=Aug16_HO3-->


