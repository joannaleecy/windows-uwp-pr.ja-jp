---
author: eliotcowley
title: ゲームの入力プラクティス
description: 入力デバイスを効果的に使用するためのパターンと手法について説明します。
ms.assetid: CBAD3345-3333-4924-B6D8-705279F52676
ms.author: elcowle
ms.date: 11/20/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力
ms.localizationpriority: medium
ms.openlocfilehash: ed0d611c761315e42decb89e1a5a5ad84f4b067a
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5980964"
---
# <a name="input-practices-for-games"></a>ゲームの入力プラクティス

このページでは、ユニバーサル Windows プラットフォーム (UWP) ゲームで入力デバイスを効果的に使用するためのパターンと手法について説明します。

このページでは、次のことを解説します。

* プレイヤーと、そのプレイヤーが現在使用中の入力デバイスとナビゲーション デバイスを追跡する方法
* ボタンの状態遷移 (押してから離す、離してから押す) を検出する方法
* 1 回のテストでボタンの複雑な配置を検出する方法

## <a name="choosing-an-input-device-class"></a>入力デバイス クラスの選択

利用できる入力 API には、[ArcadeStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick)、[Gamepad](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad) など多くの種類が存在します。 ゲームに使用する API をどのように決定すればよいのでしょうか。

ゲームに最も適切な入力を提供する API 選択する必要があります。 たとえば、2D プラットフォームのゲームを作成する場合は、通常、**Gamepad** クラスを使用するだけで対応でき、その他のクラスで利用可能な追加機能を使用する必要はありません。 このクラスは、ゲームのサポートをゲームパッドのみに制限し、コードを追加することなく、多くの異なるゲームパッドで動作する一貫したインターフェイスを提供します。

その一方で、複雑なフライトやレーシングのシミュレーションでは、すべての [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) オブジェクトを基準として列挙し、熱心なプレイヤーが所有しているあらゆるニッチ デバイス (シングル プレイヤー用の独立したペダルやスロットルなどのデバイス) を確実にサポートできます。 

そこから、入力クラスの **FromGameController** メソッド ([Gamepad.FromGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.fromgamecontroller) など) を使用して、各デバイスが整理されたビューが表示するかどうかを確認できます。 たとえば、デバイスが **Gamepad** でもある場合、それを反映するようにボタン マッピング UI を調整し、選択可能ないくつかの適切な既定のボタン マッピングを提供できます  (これは、**RawGameController** のみを使用している場合、プレイヤーがゲームパッド入力を手動で構成することが必要になるのとは対照的です)。 

代わりに、**RawGameController** のベンダー ID (VID) と製品 ID (PID) を参照し (それぞれ [HardwareVendorId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareVendorId) と [HardwareProductId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareProductId) を使用)、一般的なデバイスの推奨されるボタン マッピングを提供できます。その一方で、プレイヤーが手動でマッピングすることにより将来の未知のデバイスとの互換性を維持できます。

## <a name="keeping-track-of-connected-controllers"></a>接続されているコントローラーの追跡

各コントローラーの型には、接続されているコントローラーのリスト ([Gamepad.Gamepads](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepad.Gamepads) など) が含まれていますが、独自のコントローラーのリストを保持することをお勧めします。 詳細については、「[ゲームパッドの一覧](gamepad-and-vibration.md#the-gamepads-list)」を参照してください (各コントローラーの型には、それぞれのトピックに類似する名前のセクションがあります)。

それでは、プレイヤーがコントローラーを取り外した場合や、新しいコントローラーを接続した場合は、どうなるでしょうか。 これらのイベントを処理し、リストを適宜更新する必要があります。 詳細については、「[ゲームパッドの追加と削除](gamepad-and-vibration.md#adding-and-removing-gamepads)」を参照してください (ここでも、各コントローラーの型には、それぞれのトピックに類似する名前のセクションがあります)。

追加および削除のイベントは非同期的に発生するため、コントローラーの一覧を処理するときに誤った結果を取得する可能性があります。 そのため、コントローラーのリストにアクセスするときは、常に、一度に 1 つのスレッドのみがリストにアクセスできるようにその周囲にロックを配置する必要があります。 この処理は、**&lt;ppl.h&gt;** の[同時実行ランタイム](https://docs.microsoft.com/cpp/parallel/concrt/concurrency-runtime)、具体的には、[critical_section クラス](https://docs.microsoft.com/cpp/parallel/concrt/reference/critical-section-class)で行うことができます。

もう 1 つ考慮しなければならないのは、接続されているコントローラーのリストは最初は空であり、設定されるのに 1、2 秒かかるという点です。 start メソッドで、現在のゲームパッドを割り当てるだけでは、**null** になります。

この問題を解決するには、メイン ゲームパッドを "更新する" メソッドが必要です (シングル プレイヤー ゲームの場合。マルチプレイヤー ゲームではさらに高度な解決策が必要になります)。 コントローラーの追加とコントローラーの削除の両方のイベント ハンドラー、または update メソッドで、このメソッドを呼び出す必要があります。

次のメソッドは、単にリストの最初のゲームパッド (またはリストが空の場合は **nullptr**) を返します。 したがって、コントローラーについて何か処理をする場合は、常に **nullptr** かどうかを確認することを忘れないようにする必要があります。 コントローラーが接続されていない場合にゲームプレイをブロックする (たとえば、ゲームを一時停止する) か、入力を無視して単にゲームプレイを続行させるかは、開発者が決定できます。

```cpp
#include <ppl.h>

using namespace Platform::Collections;
using namespace Windows::Gaming::Input;
using namespace concurrency;

Vector<Gamepad^>^ m_myGamepads = ref new Vector<Gamepad^>();

Gamepad^ GetFirstGamepad()
{
    Gamepad^ gamepad = nullptr;
    critical_section::scoped_lock{ m_lock };

    if (m_myGamepads->Size > 0)
    {
        gamepad = m_myGamepads->GetAt(0);
    }

    return gamepad;
}
```

これらをまとめて、ゲームパッドからの入力を処理する方法の例を次に示します。

```cpp
#include <algorithm>
#include <ppl.h>

using namespace Platform::Collections;
using namespace Windows::Foundation;
using namespace Windows::Gaming::Input;
using namespace concurrency;

static Vector<Gamepad^>^ m_myGamepads = ref new Vector<Gamepad^>();
static Gamepad^          m_gamepad = nullptr;
static critical_section  m_lock{};

void Start()
{
    // Register for gamepad added and removed events.
    Gamepad::GamepadAdded += ref new EventHandler<Gamepad^>(&OnGamepadAdded);
    Gamepad::GamepadRemoved += ref new EventHandler<Gamepad^>(&OnGamepadRemoved);

    // Add connected gamepads to m_myGamepads.
    for (auto gamepad : Gamepad::Gamepads)
    {
        OnGamepadAdded(nullptr, gamepad);
    }
}

void Update()
{
    // Update the current gamepad if necessary.
    if (m_gamepad == nullptr)
    {
        auto gamepad = GetFirstGamepad();

        if (m_gamepad != gamepad)
        {
            m_gamepad = gamepad;
        }
    }

    if (m_gamepad != nullptr)
    {
        // Gather gamepad reading.
    }
}

// Get the first gamepad in the list.
Gamepad^ GetFirstGamepad()
{
    Gamepad^ gamepad = nullptr;
    critical_section::scoped_lock{ m_lock };

    if (m_myGamepads->Size > 0)
    {
        gamepad = m_myGamepads->GetAt(0);
    }

    return gamepad;
}

void OnGamepadAdded(Platform::Object^ sender, Gamepad^ args)
{
    // Check if the just-added gamepad is already in m_myGamepads; if it isn't, 
    // add it.
    critical_section::scoped_lock lock{ m_lock };
    auto it = std::find(begin(m_myGamepads), end(m_myGamepads), args);

    if (it == end(m_myGamepads))
    {
        m_myGamepads->Append(args);
    }
}

void OnGamepadRemoved(Platform::Object^ sender, Gamepad^ args)
{
    // Remove the gamepad that was just disconnected from m_myGamepads.
    unsigned int indexRemoved;
    critical_section::scoped_lock lock{ m_lock };

    if (m_myGamepads->IndexOf(args, &indexRemoved))
    {
        if (m_gamepad == m_myGamepads->GetAt(indexRemoved))
        {
            m_gamepad = nullptr;
        }

        m_myGamepads->RemoveAt(indexRemoved);
    }
}
```

## <a name="tracking-users-and-their-devices"></a>ユーザーおよびそのデバイスの追跡

ユーザーの ID をゲームプレイ、成績、設定の変更などのアクティビティにリンクできるように、すべての入力デバイスが [User](https://docs.microsoft.com/uwp/api/windows.system.user) に関連付けられます。 ユーザーは必要に応じてサインインまたはサインアウトできます。一般的には、前のユーザーがサインアウトした後、入力デバイスをシステムに接続したまま別のユーザーがサインインします。ユーザーがサインインまたはサインアウトするときに、[IGameController.UserChanged](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller.UserChanged) イベントが発生します。 このイベントのイベント ハンドラーを登録することで、プレイヤーとプレイヤーが使用中のデバイスを追跡できます。

ユーザー ID は、入力デバイスを対応する [UI ナビゲーション コント ローラー](ui-navigation-controller.md)に関連付けるための方法でもあります。

これらの理由から、デバイス クラス ([IGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller) インターフェイスから継承) の [User](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller.User) プロパティを使用して、プレイヤーの入力が追跡され、関係付けられます。

[UserGamepadPairingUWP (GitHub)](
https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/UserGamepadPairingUWP) サンプルでは、ユーザーとそのユーザーが使用中のデバイスを追跡する方法を示してます。

## <a name="detecting-button-transitions"></a>ボタンの状態遷移の検出

ボタンを最初に押したタイミング、または離したタイミングを把握したい場合があります。正確には、離した状態から押した状態への、または押した状態から離した状態へのボタンの状態遷移のタイミングを把握したい場合があります。 これを判断するには、デバイスの前回読み取り結果を記憶し、現在の読み取り結果と比較して状態変化を確認する必要があります。

次の例では、前回の読み取り結果を記憶する基本的な方法を示します。ここで示しているのはゲームパッドですが、アーケード スティック、レース ホイール、その他の種類の入力デバイスでも原理は同じです。

```cpp
Gamepad gamepad;
GamepadReading newReading();
GamepadReading oldReading();

// Called at the start of the game.
void Game::Start()
{
    gamepad = Gamepad::Gamepads[0];
}

// Game::Loop represents one iteration of a typical game loop
void Game::Loop()
{
    // move previous newReading into oldReading before getting next newReading
    oldReading = newReading, newReading = gamepad.GetCurrentReading();

    // process device readings using buttonJustPressed/buttonJustReleased (see below)
}
```

他の処理を行う前に、`Game::Loop` では `newReading` の既存の値 (前回ループの反復でのゲームパッドの読み取り結果) を `oldReading` に移動して、現在の反復でのゲームパッドの新しい読み取り結果を `newReading` に格納しています。 これにより、ボタンの状態遷移を検出するために必要な情報を提供します。

次の例では、ボタンの状態遷移を検出する基本的な方法を示します。

```cpp
bool ButtonJustPressed(const GamepadButtons selection)
{
    bool newSelectionPressed = (selection == (newReading.Buttons & selection));
    bool oldSelectionPressed = (selection == (oldReading.Buttons & selection));

    return newSelectionPressed && !oldSelectionPressed;
}

bool ButtonJustReleased(GamepadButtons selection)
{
    bool newSelectionReleased =
        (GamepadButtons.None == (newReading.Buttons & selection));

    bool oldSelectionReleased =
        (GamepadButtons.None == (oldReading.Buttons & selection));

    return newSelectionReleased && !oldSelectionReleased;
}
```

上記の 2 つの関数は、まず `newReading` と `oldReading` からボタンの選択状態をブール値で求めています。次に、ブール値の論理演算を実行し、対象となるボタンの状態遷移が発生しているかどうかを判断します。 この 2 つの関数は、新しい読み取り結果が目的の状態 (それぞれ押した状態または離した状態) を含み、** かつ、前回の読み取り結果が目的の状態を含まない場合にのみ **true** を返します。それ以外の場合は **false** を返します。

## <a name="detecting-complex-button-arrangements"></a>ボタンの複雑な配置の検出

入力デバイスの各ボタンは、ボタンが押されている (ダウン) か、離されている (アップ) かどうかを示すデジタルの読み取り結果を提供します。 効率を高めるため、ボタンの読み取り結果は個別のブール値としては表現しません代わりに、読み取り結果はすべて、[GamepadButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons) などのデバイス固有の列挙型で表されるビットフィールドにパックされます。 特定のボタンを読み取るには、ビット単位のマスクを使用して、目的のボタンの値を切り分けます。 対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。

次の例では、1 つのボタンが押されている状態か離されている状態かを判断する方法を示します。ここで示しているのはゲームパッドですが、アーケード スティック、レース ホイール、その他の種類の入力デバイスでも原理は同じです。

```cpp
GamepadReading reading = gamepad.GetCurrentReading();

// Determines whether gamepad button A is pressed.
if (GamepadButtons::A == (reading.Buttons & GamepadButtons::A))
{
    // The A button is pressed.
}

// Determines whether gamepad button A is released.
if (GamepadButtons::None == (reading.Buttons & GamepadButtons::A))
{
    // The A button is released (not pressed).
}
```

ご覧のように、1 つのボタンの状態を判断するのは簡単ですが、場合によっては、複数のボタンが押されたか離されたか、または一連のボタンの一部押されていて一部離されているような特定の方法で配置されているかどうかを判断したいことがあります。 複数のボタンを判断するのは 1 つのボタンを判断するより複雑です。特にボタンの状態が混在する可能性のあるときはなおさらです。ただし、1 つのボタンにも複数のボタンにも同様に当てはめることができる簡単な式を使ってボタン状態を判定できます。

次の例では、ゲームパッドのボタン A とボタン B が両方押されているかどうかを判断します。

```cpp
if ((GamepadButtons::A | GamepadButtons::B) == (reading.Buttons & (GamepadButtons::A | GamepadButtons::B))
{
    // The A and B buttons are both pressed.
}
```

次の例では、ゲームパッドのボタン A とボタン B が両方離されているかどうかを判断します。

```cpp
if ((GamepadButtons::None == (reading.Buttons & GamepadButtons::A | GamepadButtons::B))
{
    // The A and B buttons are both released (not pressed).
}
```

次の例では、ゲームパッドのボタン A が押されていてボタン B が離されているかどうかを判断します。

```cpp
if (GamepadButtons::A == (reading.Buttons & (GamepadButtons::A | GamepadButtons::B))
{
    // The A button is pressed and the B button is released (B is not pressed).
}
```

上記の例すべての式に共通しているのは、テストするボタンの配置を等号演算子の左辺で指定し、状態を検討するボタンを等号演算子の右辺のマスク式で選択していることです。

次の例では、上記の例を書き直して、式をより分かりやすく表現する例を示しています。

```cpp
auto buttonArrangement = GamepadButtons::A;
auto buttonSelection = (reading.Buttons & (GamepadButtons::A | GamepadButtons::B));

if (buttonArrangement == buttonSelection)
{
    // The A button is pressed and the B button is released (B is not pressed).
}
```

上記の式は、ボタンの数、配置、テストする状態を問わず、どのような場合でも当てはめることができます。

## <a name="get-the-state-of-the-battery"></a>バッテリーの状態を取得する

[IGameControllerBatteryInfo](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo) インターフェイスを実装しているゲーム コントローラーの場合は、コントローラー インスタンスで [TryGetBatteryReport](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo.TryGetBatteryReport) を呼び出すことによって、コントローラーのバッテリーに関する情報を提供する [BatteryReport](https://docs.microsoft.com/uwp/api/windows.devices.power.batteryreport) オブジェクトを取得できます。 バッテリーの充電速度 ([ChargeRateInMilliwatts](https://docs.microsoft.com/uwp/api/windows.devices.power.batteryreport.ChargeRateInMilliwatts))、新しいバッテリーの電力容量の見積もり ([DesignCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.DesignCapacityInMilliwattHours))、現在のバッテリーの完全に充電した場合の電力容量 ([FullChargeCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.FullChargeCapacityInMilliwattHours)) などのプロパティを取得することができます。

詳細なバッテリーのレポートをサポートするゲーム コントローラーの場合、「[バッテリー情報の取得](../devices-sensors/get-battery-info.md)」で説明されているように、この情報に加えて、バッテリーに関するさらに詳しい情報を取得できます。 ただし、ほとんどのゲーム コントローラーはこのレベルのバッテリー レポートをサポートしておらず、代わりに低コストのハードウェアを使用しています。 このようなコントローラーでは、次の考慮事項に留意する必要があります。

* **ChargeRateInMilliwatts** と **DesignCapacityInMilliwattHours** は常に **NULL** になります。

* バッテリ残量の割合は、[RemainingCapacityInMilliwattHours](https://docs.microsoft.com/en-us/uwp/api/windows.devices.power.batteryreport.RemainingCapacityInMilliwattHours) / **FullChargeCapacityInMilliwattHours** を計算することによって取得できます。 これらのプロパティの値を無視して、計算される割合のみを処理する必要があります。

* 前の項目の割合は、常に次のいずれかになります。

    * 100% (フル)
    * 70% (中)
    * 40% (低)
    * 10% (バッテリー切れ)

コードが、バッテリー残量の割合に基づいて何かアクションを実行する (UI の描画など) 場合、上記の値に準拠しているかどうかを確認します。 たとえば、コントローラーのバッテリー残量が少ないときにプレイヤーに警告を表示する場合は、10% に達したときに表示します。

## <a name="see-also"></a>関連項目

* [Windows.System.User クラス](https://docs.microsoft.com/uwp/api/windows.system.user)
* [Windows.Gaming.Input.IGameController インターフェイス](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller)
* [Windows.Gaming.Input.GamepadButtons 列挙型](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamepadbuttons)
