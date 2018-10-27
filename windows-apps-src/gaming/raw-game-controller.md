---
author: eliotcowley
title: 未加工のゲーム コントローラー
description: ほとんどすべての種類のゲーム コントローラーから入力を読み取るには、Windows.Gaming.Input 未加工のゲーム コントローラー API を使用します。
ms.assetid: 2A466C16-1F51-4D8D-AD13-704B6D3C7BEC
ms.author: wdg-dev-content
ms.date: 03/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, 未加工のゲーム コントローラー
ms.localizationpriority: medium
ms.openlocfilehash: c57db3f9604e20d0dc83d6c3cf2ced87b1f5dcc1
ms.sourcegitcommit: 086001cffaf436e6e4324761d59bcc5e598c15ea
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5682589"
---
# <a name="raw-game-controller"></a>未加工のゲーム コントローラー

このページでは、[Windows.Gaming.Input.RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、ほとんどすべての種類のゲーム コントローラー向けプログラミングの基礎について説明します。

このページでは、次のことを解説します。

* 接続されている未加工のゲーム コントローラーとそのユーザーの一覧を収集する方法
* 未加工のゲーム コントローラーが追加または削除されたことを検出する方法
* 未加工のゲーム コントローラーの機能を取得する方法
* 未加工のゲーム コントローラーからの入力を読み取る方法

## <a name="overview"></a>概要

未加工のゲーム コントローラーは、さまざまな種類の一般的なゲーム コントローラーの入力を備えた、ゲーム コントローラーの汎用的な表現です。 これらの入力は、名前のないボタン、スイッチ、軸の単純な配列として公開されます。 未加工のゲーム コントローラーを使用すると、ユーザーが使っているコントローラーの種類に関係なく、カスタム入力マッピングを作成することができます。

[RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) クラスは、他の入力クラス ([ArcadeStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.arcadestick)、[FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) など) がニーズを満たさない場合のシナリオに対応することを目的としています。つまり、ユーザーがさまざまな種類のゲーム コントローラーを使用することが予想され、より汎用的なクラスが必要な場合は、このクラスが適しています。

## <a name="detect-and-track-raw-game-controllers"></a>未加工のゲーム コントローラーの検出と追跡

未加工のゲーム コントローラーの検出と追跡の方法はゲームパッドの場合とまったく同じですが、[Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) クラスの代わりに [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) クラスを使用する点だけが異なります。 詳細については、「[ゲームパッドと振動](gamepad-and-vibration.md)」を参照してください。

<!-- Raw game controllers are managed by the system, therefore you don't have to create or initialize them. The system provides a list of connected raw game controllers and events to notify you when a raw game controller is added or removed.

### The raw game controller list

The [RawGameController](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller) class provides a static property, [RawGameControllers](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_RawGameControllers), which is a read-only list of raw game controllers that are currently connected. Because you might only be interested in some of the connected raw game controllers, we recommend that you maintain your own collection instead of accessing them through the **RawGameControllers** property.

The following example copies all connected raw game controllers into a new collection:

```cpp
auto myRawGameControllers = ref new Vector<RawGameController^>();

for (auto rawGameController : RawGameController::RawGameControllers)
{
    // This code assumes that you're interested in all raw game controllers.
    myRawGameControllers->Append(rawGameController);
}
```

### Adding and removing raw game controllers

When a raw game controller is added or removed, the [RawGameControllerAdded](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_RawGameControllerAdded) and [RawGameControllerRemoved](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_RawGameControllerRemoved) events are raised. You can register handlers for these events to keep track of the raw game controllers that are currently connected.

The following example starts tracking a raw game controller that's been added:

```cpp
RawGameController::RawGameControllerAdded += 
    ref new EventHandler<RawGameController^>(
        [] (Platform::Object^, RawGameController^ args)
{
    // This code assumes that you're interested in all new raw game controllers.
    myRawGameControllers->Append(args);
});
```

The following example stops tracking a raw game controller that's been removed:

```cpp
RawGameController::RawGameControllerRemoved +=
    ref new EventHandler<RawGameController^>(
        [] (Platform::Object^, RawGameController^ args)
{
    unsigned int indexRemoved;

    if (myRawGameControllers->IndexOf(args, &indexRemoved))
    {
        myRawGameControllers->RemoveAt(indexRemoved);
    }
});
```

### Users and headsets

Each raw game controller can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features. To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md). -->

## <a name="get-the-capabilities-of-a-raw-game-controller"></a>未加工のゲーム コントローラーの機能の取得

対象となる未加工のゲーム コントローラーを特定した後、コントローラーの機能に関する情報を収集できます。 未加工のゲーム コントローラー上のボタンの数は [RawGameController.ButtonCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.ButtonCount) を、アナログ軸の数は [RawGameController.AxisCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.AxisCount) を、スイッチの数は [RawGameController.SwitchCount](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.SwitchCount) を使用して取得できます。 さらに、[RawGameController.GetSwitchKind](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetSwitchKind_System_Int32_) を使用してスイッチの種類を取得できます。

次の例では、未加工のゲーム コントローラーの入力の数を取得します。

```cpp
auto rawGameController = myRawGameControllers->GetAt(0);
int buttonCount = rawGameController->ButtonCount;
int axisCount = rawGameController->AxisCount;
int switchCount = rawGameController->SwitchCount;
```

次の例では、各スイッチの種類を特定します。

```cpp
for (uint32_t i = 0; i < switchCount; i++)
{
    GameControllerSwitchKind mySwitch = rawGameController->GetSwitchKind(i);
}
```

## <a name="reading-the-raw-game-controller"></a>未加工のゲーム コントローラーの読み取り

未加工のゲーム コントローラーの入力の数を確認したら、ゲーム コントローラーからの入力を収集する準備は完了です。 ただし、なじみのある一部の他の種類の入力とは違い、未加工のゲーム コントローラーはイベントを発生することによって状態の変化を伝えるわけではありません。 代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。

### <a name="polling-the-raw-game-controller"></a>未加工のゲーム コントローラーのポーリング

ポーリングでは、明確な時点における未加工のゲーム コントローラーのスナップショットをキャプチャします。 入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。 また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。

未加工のゲーム コントローラーをポーリングするには、[RawGameController.GetCurrentReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetCurrentReading_System_Boolean___Windows_Gaming_Input_GameControllerSwitchPosition___System_Double___) を呼び出します。 この関数は、未加工のゲーム コントローラーの状態を格納する、ボタン、スイッチ、軸の配列を設定します。

次の例では、未加工のゲーム コントローラーをポーリングして現在の状態を確認します。

```cpp
Platform::Array<bool>^ currentButtonReading =
    ref new Platform::Array<bool>(buttonCount);

Platform::Array<GameControllerSwitchPosition>^ currentSwitchReading =
    ref new Platform::Array<GameControllerSwitchPosition>(switchCount);

Platform::Array<double>^ currentAxisReading = ref new Platform::Array<double>(axisCount);

rawGameController->GetCurrentReading(
    currentButtonReading,
    currentSwitchReading,
    currentAxisReading);
```

さまざまな種類のコントローラー間で各配列内のどの位置にどの入力値が保持されるかは保証されていません。そのため、[RawGameController.GetButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetButtonLabel_System_Int32_) メソッドと [RawGameController.GetSwitchKind](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetSwitchKind_System_Int32_) メソッドを使用して、どの入力がどれであるかを確認する必要があります。

**GetButtonLabel** は、ボタンの機能ではなく、物理的なボタンに印字されているテキストや記号を通知します。したがって、UI の補助として使用し、ボタンによって実行される機能についてプレイヤーにヒントを提供する場合に最適です。 **GetSwitchKind** は、スイッチの名前ではなく、スイッチの種類 (つまり、スイッチの位置の数) を通知します。

軸やスイッチのラベルを取得するための標準化された方法はないため、自分でこれらをテストして、どの入力がどれであるかを特定する必要があります。

特定のコントローラーをサポートする必要がある場合は、[RawGameController.HardwareProductId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareProductId) と [RawGameController.HardwareVendorId](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller.HardwareVendorId) を取得して、それらがコントローラーに合致しているかどうかを確認できます。 各配列内の各入力の位置は、同じ **HardwareProductId** と **HardwareVendorId** を持つすべてのコントローラーで同じであるため、同じ種類の異なるコントローラー間でのロジックの一貫性に関する問題について心配する必要はありません。

読み取りデータでは、未加工のゲーム コントローラーの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも返されます。 このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。

### <a name="reading-the-buttons-and-switches"></a>ボタンやスイッチの読み取り

未加工のゲーム コントローラーのボタンはそれぞれ、ボタンが押されている (ダウン) か、離されている (アップ) かを示すデジタルの読み取り値を提供します。 ボタンの読み取り値は、1 つの配列内の個々のブール値として表されます。 各ボタンのラベルは、[RawGameController.GetButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller#Windows_Gaming_Input_RawGameController_GetButtonLabel_System_Int32_) と、配列内のブール値のインデックスを使用して検出できます。 各値は [GameControllerButtonLabel](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerbuttonlabel) として表されます。

次の例では、**XboxA** ボタンが押されているかどうかを判別します。

```cpp
for (uint32_t i = 0; i < buttonCount; i++)
{
    if (currentButtonReading[i])
    {
        GameControllerButtonLabel buttonLabel = rawGameController->GetButtonLabel(i);

        if (buttonLabel == GameControllerButtonLabel::XboxA)
        {
            // XboxA is pressed.
        }
    }
}
```

場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか (一部が押されていて、一部が押されていない) を特定する必要があります。 これらの各状態を検出する方法について詳しくは、「[ボタンの状態遷移の検出](input-practices-for-games.md#detecting-button-transitions)」および「[ボタンの複雑な配置の検出](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。

スイッチの値は、[GameControllerSwitchPosition](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerswitchposition) の配列として提供されます。 このプロパティはビットフィールドであるため、ビット単位のマスクを使用してスイッチの方向を特定します。

次の例では、各スイッチが上の位置であるかどうかを特定します。

```cpp
for (uint32_t i = 0; i < switchCount; i++)
{
    if (GameControllerSwitchPosition::Up ==
        (currentSwitchReading[i] & GameControllerSwitchPosition::Up))
    {
        // The switch is in the up position.
    }
}
```

### <a name="reading-the-analog-inputs-sticks-triggers-throttles-and-so-on"></a>アナログ入力 (スティック、トリガー、スロットルなど) の読み取り

アナログ軸は、0.0 ～ 1.0 の読み取り値を提供します。 これには、標準的なスティックの場合は X と Y、フライト スティックの場合は X、Y、Z 軸 (それぞれロール、ピッチ、ヨー) など、スティックの各次元の値が含まれます。

この値は、アナログ トリガー、スロットル、その他のアナログ入力の種類を表すことができます。 これらの値にラベルは提供されないため、さまざまな入力デバイスでコードをテストし、想定している動作に正しく合致しているかどうかを確認することをお勧めします。

どの軸も、スティックが中央の位置にある場合、値は約 0.5 になりますが、正確な値は、後続の読み取り値間であっても、異なるのが普通です。このばらつきを緩和する対策については、このセクションで後ほど説明します。

次の例は、Xbox コントローラーからアナログ値を読み取る方法を示しています。

```cpp
// Xbox controllers have 6 axes: 2 for each stick and one for each trigger.
float leftStickX = currentAxisReading[0];
float leftStickY = currentAxisReading[1];
float rightStickX = currentAxisReading[2];
float rightStickY = currentAxisReading[3];
float leftTrigger = currentAxisReading[4];
float rightTrigger = currentAxisReading[5];
```

スティックの値を読み取るとき、中央の位置で待機中のサムスティックの値は、一定してニュートラルの 0.5 にはなりません。スティックを動かし、中央の位置に戻るたびに、0.5 に近い値が生成されます。 このばらつきを少なくするために、小さな_デッドゾーン_を実装します。デッドゾーン+は、理想の中央の位置付近の、無視される範囲の値です。

デッドゾーンを実装する方法の 1 つは、スティックが中央から移動された距離を特定し、読み取り値が指定した距離以下の場合は無視することです。 この距離は、ピタゴラスの定理を使って概算できます (スティックの読み取り値は、平面値ではなく、本質的に極値であるため正確な計算にはなりません)。 これで、放射状のデッドゾーンが作られます。

次の例は、ピタゴラスの定理を使った基本的な放射状のデッドゾーンを示しています。

```cpp
// Choose a deadzone. Readings inside this radius are ignored.
const float deadzoneRadius = 0.1f;
const float deadzoneSquared = deadzoneRadius * deadzoneRadius;

// Pythagorean theorem: For a right triangle, hypotenuse^2 = (opposite side)^2 + (adjacent side)^2
float oppositeSquared = leftStickY * leftStickY;
float adjacentSquared = leftStickX * leftStickX;

// Accept and process input if true; otherwise, reject and ignore it.
if ((oppositeSquared + adjacentSquared) < deadzoneSquared)
{
    // Input accepted, process it.
}
```

<!--## Run the RawGameControllerUWP sample

The [RawGameControllerUWP sample (GitHub)](TODO: Link) demonstrates how to use raw game controllers. TODO: More information-->

## <a name="see-also"></a>関連項目

* [ゲームの入力](input-for-games.md)
* [ゲームの入力プラクティス](input-practices-for-games.md)
* [Windows.Gaming.Input 名前空間](https://docs.microsoft.com/uwp/api/windows.gaming.input)
* [Windows.Gaming.Input.RawGameController クラス](https://docs.microsoft.com/uwp/api/windows.gaming.input.rawgamecontroller)
* [Windows.Gaming.Input.IGameController インターフェイス](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller)
* [Windows.Gaming.Input.IGameControllerBatteryInfo インターフェイス](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontrollerbatteryinfo)