---
title: フライト スティック
description: フライト スティックからの入力を読み取るには、Windows.Gaming.Input フライト スティック API を使用します。
ms.assetid: DC633F6B-FDC9-4D6E-8401-305861F31192
ms.date: 03/06/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, 入力, フライト スティック
ms.localizationpriority: medium
ms.openlocfilehash: 5eceb30c62f1e803397aff71d59b560c39736cf9
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8884859"
---
# <a name="flight-stick"></a>フライト スティック

このページでは、[Windows.Gaming.Input.FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One 認定フライト スティックを対象にしたプログラミングの基礎について説明します。

このページでは、次のことを解説します。

* 接続されているフライト スティックとそのユーザーの一覧を収集する方法
* フライト スティックが追加または削除されたことを検出する方法
* 1 つ以上のフライト スティックの入力を読み取る方法
* フライト スティックを UI ナビゲーション デバイスとして使用する方法

## <a name="overview"></a>概要

フライト スティックは、航空機や宇宙船のコックピットにあるフライト スティックの操作感を再現することを重視したゲーム用の入力デバイスです。 フライトを迅速かつ正確に制御するのに最適な入力デバイスです。 フライト スティックは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input](https://docs.microsoft.com/uwp/api/windows.gaming.input) 名前空間によってサポートされています。

Xbox One のフライト スティックには、次のコントロールが装備されています。

* ロール、ヨー、ピッチに対応したツイスト可能なアナログ ジョイスティック
* アナログ スロットル
* 2 つのファイア ボタン
* 8 方向デジタル ハット スイッチ
* **View** ボタンと **Menu** ボタン

> [!NOTE]
> **View** ボタンと **Menu** ボタンは、ゲームプレイ コマンドではなく、UI ナビゲーションをサポートするために使用されます。したがって、ジョイスティック ボタンとは異なり、簡単にはアクセスできません。

### <a name="ui-navigation"></a>UI のナビゲーション

ユーザー インターフェイスの操作に異なる入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、ほとんどの_物理_入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の_論理_入力デバイスとして同時に機能します。 UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。

フライト スティックは、UI ナビゲーション コント ローラーとして、ナビゲーション コマンドの[必須セット](ui-navigation-controller.md#required-set)を、ジョイスティックと **View**、**Menu**、**FirePrimary**、**FireSecondary** ボタンにマップします。

| ナビゲーション コマンド | フライト スティックの入力                  |
| ------------------:| ----------------------------------- |
|                 上 | ジョイスティック上                         |
|               下 | ジョイスティック下                       |
|               左 | ジョイスティック左                       |
|              右 | ジョイスティック右                      |
|               ビュー | **View** ボタン                     |
|               Menu | **Menu** ボタン                     |
|             OK | **FirePrimary** ボタン              |
|             キャンセル | **FireSecondary** ボタン            |

フライト スティックは、ナビゲーション コマンドの[オプション セット](ui-navigation-controller.md#optional-set)はマップしません。

## <a name="detect-and-track-flight-sticks"></a>フライト スティックの検出と追跡

フライト スティックの検出と追跡の方法はゲームパッドの場合とまったく同じですが、[Gamepad](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad) クラスの代わりに [FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) クラスを使用する点だけが異なります。 詳細については、「[ゲームパッドと振動](gamepad-and-vibration.md)」を参照してください。

<!-- Flight sticks are managed by the system, therefore you don't have to create or initialize them. The system provides a list of connected flight sticks and events to notify you when a flight stick is added or removed.

### The flight stick list

The [FlightStick](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick) class provides a static property, [FlightSticks](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick#Windows_Gaming_Input_FlightStick_FlightSticks), which is a read-only list of flight sticks that are currently connected. Because you might only be interested in some of the connected flight sticks, we recommend that you maintain your own collection instead of accessing them through the `FlightSticks` property.

The following example copies all connected flight sticks into a new collection:

```cpp
auto myFlightSticks = ref new Vector<FlightStick^>();

for (auto flightStick : FlightStick::FlightSticks)
{
    // This code assumes that you're interested in all flight sticks.
    myFlightSticks->Append(flightStick);
}
```

### Adding and removing flight sticks

When a flight stick is added or removed, the [FlightStickAdded](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick#Windows_Gaming_Input_FlightStick_FlightStickAdded) and [FlightStickRemoved](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick#Windows_Gaming_Input_FlightStick_FlightStickRemoved) events are raised. You can register handlers for these events to keep track of the flight sticks that are currently connected.

The following example starts tracking a flight stick that's been added:

```cpp
FlightStick::FlightStickAdded += 
    ref new EventHandler<FlightStick^>([] (Platform::Object^, FlightStick^ args)
{
    // This code assumes that you're interested in all new flight sticks.
    myFlightSticks->Append(args);
});
```

The following example stops tracking a flight stick that's been removed:

```cpp
FlightStick::FlightStickRemoved += 
    ref new EventHandler<FlightStick^>([] (Platform::Object^, FlightStick^ args)
{
    unsigned int indexRemoved;

    if (myFlightSticks->IndexOf(args, &indexRemoved))
    {
        myFlightSticks->RemoveAt(indexRemoved);
    }
});
```

### Users and headsets

Each flight stick can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features. To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md). -->

## <a name="reading-the-flight-stick"></a>フライト スティックの読み取り

目的のフライト スティックを特定したら、入力を収集する準備は完了です。 ただし、なじみのある一部の他の種類の入力とは違い、フライト スティックはイベントを発生することによって状態の変化を伝えるわけではありません。 代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。

### <a name="polling-the-flight-stick"></a>フライト スティックのポーリング

ポーリングでは、明確な時点におけるフライト スティックのスナップショットをキャプチャします。 入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。 また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。

フライト スティックをポーリングするには、[FlightStick.GetCurrentReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstick.GetCurrentReading) を呼び出します。 この関数は、フライト スティックの状態を含む [FlightStickReading](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading) を返します。

次の例では、フライト スティックをポーリングして現在の状態を確認します。

```cpp
auto flightStick = myFlightSticks->GetAt(0);
FlightStickReading reading = flightStick->GetCurrentReading();
```

読み取りデータには、フライト スティックの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　 このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。

### <a name="reading-the-joystick-and-throttle-input"></a>ジョイスティックおよびスロットル入力の読み取り

ジョイスティックは、X、Y、Z 軸で -1.0 ～ +1.0 のアナログの読み取り値 (それぞれロール、ピッチ、ヨー) を提供します。 ロールの場合、-1.0 の値はジョイスティックを最も左に移動した位置に対応し、1.0 の値はジョイスティックを最も右に移動した位置に対応します。 ピッチの場合、-1.0 の値はジョイスティックを最も下に移動した位置に対応し、1.0 の値はジョイスティックを最も上に移動した位置に対応します。 ヨーの場合、-1.0 の値は反時計回りに最もひねった位置に対応し、1.0 の値は時計回り最もひねった位置に対応します。

すべての軸において、ジョイスティックが中央の位置にあるときには値がほぼ 0.0 になりますが、それ以降の読み取り値の間でも、正確な値が変化するのは正常です。 このバリエーションを軽減するための方法は、このセクションで後ほど説明します。

ジョイスティックのロールの値は [FlightStickReading.Roll](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Roll) プロパティから読み取られ、ピッチの値は [FlightStickReading.Pitch](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Pitch) プロパティから読み取られ、ヨーの値は [FlightStickReading.Yaw](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Yaw) プロパティから読み取られます。

```cpp
// Each variable will contain a value between -1.0 and 1.0.
float roll = reading.Roll;
float pitch = reading.Pitch;
float yaw = reading.Yaw;
```

ジョイスティックの値を読み取るとき、中央の位置で待機中のジョイスティックの値は、一定してニュートラルの 0.0 にはなりません。ジョイスティックを動かし、中央の位置に戻るたびに、0.0 に近い値が生成されます。 このばらつきを少なくするために、小さな_デッドゾーン_を実装します。デッドゾーン+は、理想の中央の位置付近の、無視される範囲の値です。

デッドゾーンを実装する方法の 1 つは、ジョイスティックが中央から移動された距離を特定し、読み取り値が指定した距離以下の場合は無視することです。 この距離は、ピタゴラスの定理を使って概算できます (ジョイスティックの読み取り値は、平面値ではなく、本質的に極値であるため正確な計算にはなりません)。 これで、放射状のデッドゾーンが作られます。

次の例は、ピタゴラスの定理を使った基本的な放射状のデッドゾーンを示しています。

```cpp
// Choose a deadzone. Readings inside this radius are ignored.
const float deadzoneRadius = 0.1f;
const float deadzoneSquared = deadzoneRadius * deadzoneRadius;

// Pythagorean theorem: For a right triangle, hypotenuse^2 = (opposite side)^2 + (adjacent side)^2
float oppositeSquared = pitch * pitch;
float adjacentSquared = roll * roll;

// Accept and process input if true; otherwise, reject and ignore it.
if ((oppositeSquared + adjacentSquared) < deadzoneSquared)
{
    // Input accepted, process it.
}
```

### <a name="reading-the-buttons-and-hat-switch"></a>ボタンとハット スイッチの読み取り

フライト スティックの 2 つのファイア ボタンはそれぞれ、ボタンが押されている (ダウン) か、離されている (アップ) かを示すデジタルの読み取り値を提供します。 効率を高めるため、ボタンの読み取り値は個別のブール値としては表されません。代わりに、読み取り値はすべて、[FlightStickButtons](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickbuttons) 列挙型で表される単一のビットフィールドにパックされます。 さらに、8 方向ハット スイッチは、[GameControllerSwitchPosition](https://docs.microsoft.com/uwp/api/windows.gaming.input.gamecontrollerswitchposition) 列挙型で表される単一のビットフィールドにパックされる方向を提供します。

> [!NOTE]
> フライト スティックには、**View** ボタンや **Menu** ボタンなど、UI ナビゲーションに使用するボタンも搭載されています。 これらのボタンは `FlightStickButtons` 列挙型には含まれず、UI ナビゲーション デバイスとしてフライト スティックを利用する場合にのみ読み取られます。 詳しくは、「[UI ナビゲーション コントローラー](ui-navigation-controller.md)」をご覧ください。

ボタンの値は、[FlightStickReading.Buttons](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.Buttons) プロパティから読み取られます。 このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。 対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。

次の例では、**FirePrimary** ボタンが押されているかどうかを判別します。

```cpp
if (FlightStickButtons::FirePrimary == (reading.Buttons & FlightStickButtons::FirePrimary))
{
    // FirePrimary is pressed.
}
```

次の例では、**FirePrimary** ボタンが離されているかどうかを判別します。

```cpp
if (FlightStickButtons::None == (reading.Buttons & FlightStickButtons::FirePrimary))
{
    // FirePrimary is released (not pressed).
}
```

場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか (一部が押されていて、一部が押されていない) を特定する必要があります。 これらの各状態を検出する方法について詳しくは、「[ボタンの状態遷移の検出](input-practices-for-games.md#detecting-button-transitions)」および「[ボタンの複雑な配置の検出](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。

ハット スイッチの値は、[FlightStickReading.HatSwitch](https://docs.microsoft.com/uwp/api/windows.gaming.input.flightstickreading.HatSwitch) プロパティから読み取られます。 このプロパティもビットフィールドであるため、ここでもビット単位のマスクを使用してハット スイッチの位置を特定します。

次の例では、ハット スイッチが上の位置であるかどうかを特定します。

```cpp
if (GameControllerSwitchPosition::Up == (reading.HatSwitch & GameControllerSwitchPosition::Up))
{
    // The hat switch is in the up position.
}
```

次の例では、ハット スイッチが中央の位置であるかどうかを特定します。

```cpp
if (GameControllerSwitchPosition::Center == (reading.HatSwitch & GameControllerSwitchPosition::Center))
{
    // The hat switch is in the center position.
}
```

<!--## Run the InputInterfacingUWP sample

The [InputInterfacingUWP sample _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) demonstrates how to use flight sticks and different kinds of input devices in tandem, as well as how these input devices behave as UI navigation controllers.-->

## <a name="see-also"></a>関連項目

* [Windows.Gaming.Input.UINavigationController クラス](https://docs.microsoft.com/uwp/api/windows.gaming.input.uinavigationcontroller)
* [Windows.Gaming.Input.IGameController インターフェイス](https://docs.microsoft.com/uwp/api/windows.gaming.input.igamecontroller)
* [ゲームの入力プラクティス](input-practices-for-games.md)