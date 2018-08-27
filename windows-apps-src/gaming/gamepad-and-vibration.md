---
author: eliotcowley
title: ゲームパッドと振動
description: ゲームパッドの検出、読み取り、およびゲームパッドへの振動とリアル コマンドの送信には、Windows.Gaming.Input ゲームパッド API を使用します。
ms.assetid: BB03BB8E-255F-4AE8-AC43-1E519CA860FE
ms.author: wdg-dev-content
ms.date: 8/23/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, ゲームパッド, 振動
ms.localizationpriority: medium
ms.openlocfilehash: f44d5f4dee8293ed40d22a301f2a3d2a9611e15d
ms.sourcegitcommit: 753dfcd0f9fdfc963579dd0b217b445c4b110a18
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/27/2018
ms.locfileid: "2864821"
---
# <a name="gamepad-and-vibration"></a>ゲームパッドと振動

このページでは、[Windows.Gaming.Input.Gamepad][gamepad] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One ゲームパッドを対象にしたプログラミングの基礎について説明します。

ここでは、次の項目について紹介します。

* 接続されているゲームパッドとそのユーザーの一覧を収集する方法
* ゲームパッドが追加または削除されたことを検出する方法
* 1 つ以上のゲームパッドの入力を読み取る方法
* 振動とリアル コマンドを送信する方法
* UI のナビゲーションのデバイスとしてゲームパッドの動作

## <a name="gamepad-overview"></a>ゲームパッドの概要

Xbox ワイヤレス コントローラーや Xbox ワイヤレス コントローラー S などのゲームパッドは、汎用のゲーム入力デバイスです。 ゲームパッドは Xbox One の標準入力デバイスです。一般的に、キーボードやマウスを好まない Windows のゲーマーが選びます。 ゲームパッドは、Windows 10 および Xbox UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。

Xbox 1 つのゲームパッドかが装備、道路パッド (パッド)。**A**、 **B**、 **X**、 **Y**、**ビュー**、および**メニュー**ボタン左と右サムスティック、エンジン、およびトリガーです。4 つのバイブレーション モーター合計します。 どちらのサムスティックも、X 軸と Y 軸のデュアル アナログの読み取り値を提供し、内側に押すとボタンとしても機能します。 各トリガーをどの程度には、引いたを表すアナログの閲覧を提供します。

<!-- > [!NOTE]
> The Xbox Elite Wireless Controller is equipped with four additional **Paddle** buttons on its underside. These can be used to provide redundant access to game commands that are difficult to use together (such as the right thumbstick together with any of the **A**, **B**, **X**, or **Y** buttons) or to provide dedicated access to additional commands. -->

> [!NOTE]
> `Windows.Gaming.Input.Gamepad` また、標準の Xbox 1 ゲームパッドと同じコントロール レイアウトを持つ Xbox 360 ゲームパッドをサポートしています。

### <a name="vibration-and-impulse-triggers"></a>振動とリアル トリガー

Xbox One ゲームパッドには、強弱のゲームパッドの振動を生むための独立した 2 つのモーターと、トリガーごとに鋭い振動を生む 2 つの専用のモーターがあります (この独自の機能のために、Xbox One ゲームパッドのトリガーは_リアル トリガー_と呼ばれています)。

> [!NOTE]
> Xbox 360 ゲームパッド_インパルス トリガー_が備わっていません。

詳しくは、「[振動とリアル トリガーの概要](#vibration-and-impulse-triggers-overview)」をご覧ください。

### <a name="thumbstick-deadzones"></a>サムスティックのデッドゾーン

中央の位置で待機中のサムスティックは、常に安定してニュートラルな X 軸と Y 軸の読み取り値を生成することが理想的ですが、 機械的な力とサムスティックの感度のために、中央の位置での実際の読み取り値は、理想的なニュートラルの値の近似値でしかなく、読み取りごとに異なる可能性があります。 このため、常に使う必要があります small_デッドゾーン_&mdash;は無視される理想的な中央位置に近い値の範囲&mdash;製造の相違点、機械の損傷やその他のゲーム パッド問題の補正にします。

デッドゾーンを大きくすることは、意図する入力と意図しない入力とを分ける簡単な方法です。

詳しくは、「[サムスティックの読み取り](#reading-the-thumbsticks)」をご覧ください。

### <a name="ui-navigation"></a>UI のナビゲーション

ユーザー インターフェイスの操作に異なる入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、ほとんどの物理__ 入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の論理__ 入力デバイスとして同時に機能します。 UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。

UI のナビゲーションのコント ローラーとしてゲームパッドにナビゲーション コマンドの[セットが必要な](ui-navigation-controller.md#required-set)左スティック、パッド、**ビュー**、**メニュー** **A**、 **B**のボタンにマップします。

| ナビゲーション コマンド | ゲームパッド入力                       |
| ------------------:| ----------------------------------- |
|                 Up | 左スティックを上/方向パッドを上       |
|               Down | 左スティックを下/方向パッドを下   |
|               Left | 左スティックを左/方向パッドを左   |
|              Right | 左スティックを右/方向パッドを右 |
|               View | ビュー ボタン                         |
|               Menu | メニュー ボタン                         |
|             Accept | A ボタン                            |
|             Cancel | B ボタン                            |

また、ゲームパッドはナビゲーション コマンドのすべての[オプション セット](ui-navigation-controller.md#optional-set)をその他の入力にマップします。

| ナビゲーション コマンド | ゲームパッド入力          |
| ------------------:| ---------------------- |
|            PageUp | 左トリガー           |
|          PageDown | 右トリガー          |
|          Page Left | L ボタン            |
|         Page Right | R ボタン           |
|          Scroll Up | 右スティックを上    |
|        Scroll Down | 右スティックを下  |
|        Scroll Left | 右スティックを左  |
|       Scroll Right | 右スティックを右 |
|          Context 1 | X ボタン               |
|          Context 2 | Y ボタン               |
|          Context 3 | 左スティックを押す  |
|          Context 4 | 右スティックを押す |

## <a name="detect-and-track-gamepads"></a>ゲームパッドの検出と追跡

ゲームパッドはシステムによって管理されるため、ゲームパッドを自分で作成したり初期化する必要はありません。 接続されているゲームパッドとイベントの一覧はシステムによって提供され、ゲームパッドが追加または削除されると通知されます。

### <a name="the-gamepads-list"></a>ゲームパッドの一覧

[Gamepad][] クラスには静的プロパティである [Gamepad][] が用意されています。これは、現在接続されているゲームパッドの読み取り専用リストです。 接続されているゲームパッドのいくつかの関連のみ可能性がある、ためにへのアクセスを使用してではなく、独自のコレクションを管理することをお勧めしますが、`Gamepads`プロパティ。

次の例では、接続されているすべてのゲームパッドを新しいコレクションにコピーします。 メモのため、バック グラウンドで他のスレッドは ( [GamepadAdded][]と[GamepadRemoved][]イベント) では、このコレクションにアクセスする、コードの読み取りや更新コレクションにロックを配置する必要があります。

```cpp
auto myGamepads = ref new Vector<Gamepad^>();
critical_section myLock{};

for (auto gamepad : Gamepad::Gamepads)
{
    // Check if the gamepad is already in myGamepads; if it isn't, add it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myGamepads), end(myGamepads), gamepad);

    if (it == end(myGamepads))
    {
        // This code assumes that you're interested in all gamepads.
        myGamepads->Append(gamepad);
    }
}
```

### <a name="adding-and-removing-gamepads"></a>ゲームパッドの追加と削除

ゲーム パッドを追加または削除すると、 [GamepadAdded][]と[GamepadRemoved][]イベントが発生します。 これらのイベントハンドラーを登録することで、現在接続されているゲームパッドを追跡できます。

次の例では、追加されたゲームパッドの追跡を開始します。

```cpp
Gamepad::GamepadAdded += ref new EventHandler<Gamepad^>(Platform::Object^, Gamepad^ args)
{
    // Check if the just-added gamepad is already in myGamepads; if it isn't, add
    // it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myGamepads), end(myGamepads), args);

    if (it == end(myGamepads))
    {
        // This code assumes that you're interested in all new gamepads.
        myGamepads->Append(args);
    }
}
```

次の例では、削除されているゲーム パッドの追跡を停止します。 また、削除しているときに追跡しているゲームパッドに動作を処理する必要があります。たとえば、このコードはのみ 1 つのゲーム パッドからの入力を追跡し、単に設定`nullptr`ときは削除されます。 すべて、ゲーム パッドがアクティブになっている場合は、フレームとどのゲーム パッド コント ローラーが接続されているし、接続が切断からの入力を収集している更新プログラムをチェックする必要があります。

```cpp
Gamepad::GamepadRemoved += ref new EventHandler<Gamepad^>(Platform::Object^, Gamepad^ args)
{
    unsigned int indexRemoved;
    critical_section::scoped_lock lock{ myLock };

    if(myGamepads->IndexOf(args, &indexRemoved))
    {
        if (m_gamepad == myGamepads->GetAt(indexRemoved))
        {
            m_gamepad = nullptr;
        }

        myGamepads->RemoveAt(indexRemoved);
    }
}
```

詳細については、[ゲーム入力プラクティス](input-practices-for-games.md)を参照してください。

### <a name="users-and-headsets"></a>ユーザーとヘッドセット

各ゲームパッドは、ユーザー アカウントと関連付けることでユーザーの ID をユーザーのゲームプレイにリンクできます。また、ボイス チャットやゲーム内機能を円滑化するためにヘッドセットをアタッチすることもできます。 ユーザーとの連携およびヘッドセット操作について詳しくは、[ユーザーおよびそのデバイスの追跡](input-practices-for-games.md#tracking-users-and-their-devices)と、[ヘッドセット](headset.md)に関するページをご覧ください。

## <a name="reading-the-gamepad"></a>ゲームパッドの読み取り

目的のゲームパッドを特定したら、入力を収集する準備は完了です。 ただし、なじみのある一部の他の種類の入力とは違い、ゲームパッドはイベントを発生することによって状態の変化を伝えるわけではありません。 代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。

### <a name="polling-the-gamepad"></a>ゲームパッドのポーリング

ポーリングでは、明確な時点におけるナビゲーション デバイスのスナップショットをキャプチャします。 入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。

ゲームパッドをポーリングするには、[GetCurrentReading][] を呼び出します。この関数はゲームパッドの状態が格納された [GamepadReading][] を返します。

次の例では、ゲームパッドをポーリングして現在の状態を確認します。

```cpp
auto gamepad = myGamepads[0];

GamepadReading reading = gamepad->GetCurrentReading();
```

読み取りデータには、ゲームパッドの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　 このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。

### <a name="reading-the-thumbsticks"></a>サムスティックの読み取り

各サムスティックは、X 軸と Y 軸で -1.0 ～ +1.0 のアナログの読み取り値を提供します。 X 軸では、-1.0 の値はサムスティックを最も左に移動した位置に対応し、+1.0 の値はサムスティックを最も右に移動した位置に対応します。 Y 軸では、-1.0 の値はサムスティックを最も下に移動した位置に対応し、+1.0 の値はサムスティックを最も上に移動した位置に対応します。 両方の軸の値は、約それ以降の測定値の間でさらに 0.0 スティック、中央でが正確に変えるには、値の標準時。このバリエーションを軽減するための方法については、このセクションの後で説明します。

左のサムスティックの X 軸の値は、[GamepadReading][] 構造体の `LeftThumbstickX` プロパティから読み取られ、Y 軸の値は `LeftThumbstickY` プロパティから読み取られます。 右のサムスティックの X 軸の値は、`RightThumbstickX` プロパティから読み取られ、Y 軸の値は `RightThumbstickY` プロパティから読み取られます。

```cpp
float leftStickX = reading.LeftThumbstickX;   // returns a value between -1.0 and +1.0
float leftStickY = reading.LeftThumbstickY;   // returns a value between -1.0 and +1.0
float rightStickX = reading.RightThumbstickX; // returns a value between -1.0 and +1.0
float rightStickY = reading.RightThumbstickY; // returns a value between -1.0 and +1.0
```

サムスティックの値を読み取るとき、中央の位置で待機中のサムスティックの値は、一定してニュートラルの 0.0 にはなりません。サムスティックを動かし、中央の位置に戻るたびに、0.0 に近い値が生成されます。 このばらつきを少なくするために、小さな_デッドゾーン_を実装します。デッドゾーン+は、理想の中央の位置付近の、無視される範囲の値です。 デッドゾーンを実装する方法の 1 つは、サムスティックが中央から移動された距離を特定し、読み取り値が指定した距離以下の場合は無視することです。 ほぼ距離を計算することができます&mdash;スティック測定値が基本的に同心円、平面がない、値であるために、正確なことはありません&mdash;ピタゴラスの定理を使用してだけです。 これで、放射状のデッドゾーンが作られます。

次の例は、ピタゴラスの定理を使った基本的な放射状のデッドゾーンを示しています。

```cpp
float leftStickX = reading.LeftThumbstickX;   // returns a value between -1.0 and +1.0
float leftStickY = reading.LeftThumbstickY;   // returns a value between -1.0 and +1.0

// choose a deadzone -- readings inside this radius are ignored.
const float deadzoneRadius = 0.1;
const float deadzoneSquared = deadzoneRadius * deadzoneRadius;

// Pythagorean theorem -- for a right triangle, hypotenuse^2 = (opposite side)^2 + (adjacent side)^2
auto oppositeSquared = leftStickY * leftStickY;
auto adjacentSquared = leftStickX * leftStickX;

// accept and process input if true; otherwise, reject and ignore it.
if ((oppositeSquared + adjacentSquared) > deadzoneSquared)
{
    // input accepted, process it
}
```

各サムスティックは、内側に押すことでボタンとしても機能します。この入力の読み取りの詳細については、「[ボタンの読み取り](#reading-the-buttons)」をご覧ください。

### <a name="reading-the-triggers"></a>トリガーの読み取り

トリガーは、0.0 (完全に離された状態) ～ 1.0 (完全に押された状態) の浮動小数点値として表されます。 左のトリガーの値は、[GamepadReading][] 構造体の `LeftTrigger` プロパティから、右のトリガーの値は `RightTrigger` プロパティから読み取られます。

```cpp
float leftTrigger  = reading.LeftTrigger;  // returns a value between 0.0 and 1.0
float rightTrigger = reading.RightTrigger; // returns a value between 0.0 and 1.0
```

### <a name="reading-the-buttons"></a>ボタンの読み取り

各ゲーム パッド ボタン&mdash;パッド、左と右エンジン、左と右スティック キーを押して、 **A**、 **B**、 **X**、 **Y**、**ビュー**と**メニュー**の 4 つの方向&mdash;閲覧するデジタルを提供します。押さ () または (上) にリリースされたかどうかを示します。 効率性、] ボタンの測定値がない個々 のブール値として表されます。代わりに、すべて豊富な[GamepadButtons][]列挙で表される 1 つビット フィールドにします。

<!-- > [!NOTE]
> The Xbox Elite Wireless Controller is equipped with four additional **paddle** buttons on its underside. These buttons are also represented in the `GamepadButtons` enumeration and their values are read in the same way as the standard gamepad buttons. -->

ボタンの値は、[GamepadReading][] 構造体の `Buttons` プロパティから読み取ります。 このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。 対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。

次の例では、A ボタンが押されているかどうかを判別します。

```cpp
if (GamepadButtons::A == (reading.Buttons & GamepadButtons::A))
{
    // button A is pressed
}
```

次の例では、A ボタンが離されているかどうかを判別します。

```cpp
if (GamepadButtons::None == (reading.Buttons & GamepadButtons::A))
{
    // button A is pressed
}
```

可能性がありますを確認するボタンがから移行する場合にリリースされた押したり、複数のボタンを押したまたはリリースかどうか、または特定の方法でボタンのセットが配置されている場合に、クリック時にリリース&mdash;一部を押すと、いません。 これらの各状態を検出する方法について詳しくは、「[ボタンの状態遷移の検出](input-practices-for-games.md#detecting-button-transitions)」および「[ボタンの複雑な配置の検出](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。

## <a name="run-the-gamepad-input-sample"></a>ゲームパッド入力のサンプルの実行

[GamepadUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/System/GamepadUWP) は、ゲームパッドに接続して、その状態を読み取る方法を示しています。

## <a name="vibration-and-impulse-triggers-overview"></a>振動とリアル トリガーの概要

ゲームパッド内の振動モーターは、触覚的なフィードバックをユーザーに提供することを目的としています。 ゲームではこの機能を、より高い没入感を生み出す、状態情報 (ダメージを受けたなど) の伝達を助ける、重要なアイテムに近接信号を送るなど、クリエイティブな用途に利用します。

Xbox One ゲームパッドには、独立した振動モーターが合計 4 つ搭載されています。 2 つは、ゲーム パッド本文内にある大きなモーターです。左困難は、右困難を提供しますが減ってより複雑なバイブレーション大まかな、高振幅のバイブレーションを提供します。 残り 2 つは小型のモーターで、各トリガー内に 1 つずつ組み込まれていて、トリガーを操作しているユーザーの指に直接、鋭い弾けるような振動を伝えます。Xbox One ゲームパッドのトリガーは、この独自の機能のために、_リアル トリガー_と呼ばれます。 これらのモーターが協調することで、幅広い種類の触感を生成できます。

## <a name="using-vibration-and-impulse"></a>振動とリアル トリガーの使用

ゲームパッドの振動は、[Gamepad][] クラスの [Vibration][] プロパティによって制御されます。 `Vibration` は、[GamepadVibration][] 構造のインスタンスで、4 つの浮動小数点値で構成されます。各値は、それぞれのモーターの強さを表します。

メンバー、`Gamepad.Vibration`プロパティを直接変更できる、個別を初期化することをお勧め`GamepadVibration`のインスタンスにコピーし、目的の値を`Gamepad.Vibration`プロパティをすべて一度に実績運動輝度を変更します。

次の例は、モーターの強さを一度に変更する方法を示しています。

```cpp
// get the first gamepad
Gamepad^ gamepad = Gamepad::Gamepads->GetAt(0);

// create an instance of GamepadVibration
GamepadVibration vibration;

// ... set vibration levels on vibration struct here

// copy the GamepadVibration struct to the gamepad
gamepad.Vibration = vibration;
```

### <a name="using-the-vibration-motors"></a>振動モーターの使用

左右の振動モーターの値は、0.0 (振動なし) ～ 1.0 (最も強い振動) の浮動小数点値になります。 左のモーターの強さは、[GamepadVibration][] 構造体の `LeftMotor` プロパティによって設定され、右のモーターの強さは `RightMotor` プロパティによって設定されます。

次の例では両方の振動モーターの強さを設定し、ゲームパッドの振動を有効にします。

```cpp
GamepadVibration vibration;
vibration.LeftMotor = 0.80;  // sets the intensity of the left motor to 80%
vibration.RightMotor = 0.25; // sets the intensity of the right motor to 25%
gamepad.Vibration = vibration;
```

この 2 つのモーターは同じではないため、これらのプロパティを同じ値に設定しても、一方のモーターともう一方のモーターの振動は同じになりません。 左側の困難任意の値には右モーターするよりも強力なバイブレーション低い頻度でが生成されます&mdash;同じ値の&mdash;高い頻度で穏やかバイブレーションが生成されます。 最大値でも、左のモーターでは右のモーターと同じ高い周波数を生成することはできず、右のモーターは左のモーターほど強い力を生み出すことはできません。 ただし、これらのモーターはゲームパッドの本体によってしっかりと連結しているため、各モーターの特徴は異なり、振動の強度が異なる場合でも、プレイヤーがそれぞれの振動を完全に分けて感じることはありません。 このアレンジによって、モーターがまったく同じ場合よりも、より幅広く表現豊かに触感を生み出すことができます。

### <a name="using-the-impulse-triggers"></a>リアル トリガーの使用

各リアル トリガーのモーターの値は、0.0 (振動なし) ～ 1.0 (最も強い振動) の浮動小数点値になります。 左のトリガー モーターの強さは、[GamepadVibration][] 構造体の `LeftTrigger` プロパティによって設定され、右のトリガー の強さは `RightTrigger` プロパティによって設定されます。

次の例では両方のリアル トリガーの強さを設定し、有効にします。

```cpp
GamepadVibration vibration;
vibration.LeftTrigger = 0.75;  // sets the intensity of the left trigger to 75%
vibration.RightTrigger = 0.50; // sets the intensity of the right trigger to 50%
gamepad.Vibration = vibration;
```

本体のモーターと異なり、トリガー内のこの 2 つの振動モーターは同じであるため、同じ値を設定すると、どちらのモーターでも同じ振動が生成されます。 ただし、これらのモーターは何らかの形で強く連結されてはいないため、プレイヤーは振動を個別に感じます。 このアレンジでは、完全に独立した感覚を両方のトリガーに提供することができ、ゲームパッド本体のモーターよりも、個別の情報を伝えることができます。

## <a name="run-the-gamepad-vibration-sample"></a>ゲームパッドの振動のサンプルの実行

[GamepadVibrationUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/System/GamepadVibrationUWP) では、ゲームパッドの振動モーターとリアル トリガーを使用して、さまざまな効果を生む方法を示しています。

## <a name="see-also"></a>参照

* [Windows.Gaming.Input.UINavigationController][]
* [Windows.Gaming.Input.IGameController][]
* [ゲームの入力プラクティス](input-practices-for-games.md)

[Windows.Gaming.Input]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[Windows.Gaming.Input.UINavigationController]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.aspx
[Windows.Gaming.Input.IGameController]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[gamepad]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.aspx
[gamepads]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.gamepads.aspx
[gamepadadded]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.gamepadadded.aspx
[gamepadremoved]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.gamepadremoved.aspx
[getcurrentreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.getcurrentreading.aspx
[vibration]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.vibration.aspx
[gamepadreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepadreading.aspx
[gamepadbuttons]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepadbuttons.aspx
[gamepadvibration]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepadvibration.aspx
