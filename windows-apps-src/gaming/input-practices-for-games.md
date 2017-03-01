---
author: mithom
title: "ゲームの入力プラクティス"
description: "入力デバイスを効果的に使用するためのパターンと手法について説明します。"
ms.assetid: CBAD3345-3333-4924-B6D8-705279F52676
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10, UWP, ゲーム, 入力"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: 15d56a27ad914b258bb19b80b3498510d01105cd
ms.lasthandoff: 02/07/2017

---

# <a name="input-practices-for-games"></a>ゲームの入力プラクティス

このページでは、ユニバーサル Windows プラットフォーム (UWP) ゲームで入力デバイスを効果的に使用するためのパターンと手法について説明します。

このページでは、次のことを解説します。
* プレイヤーと、そのプレイヤーが現在使用中の入力デバイスとナビゲーション デバイスを追跡する方法
* ボタンの状態遷移 (押してから離す、離してから押す) を検出する方法
* 1 回のテストでボタンの複雑な配置を検出する方法

## <a name="tracking-users-and-their-devices"></a>ユーザーおよびそのデバイスの追跡

ユーザーの ID をゲームプレイ、成績、設定の変更などのアクティビティにリンクできるように、すべての入力デバイスが [User][Windows.System.User] に関連付けられます。 ユーザーは必要に応じてサインインまたはサインアウトできます。一般的には、前のユーザーがサインアウトした後、入力デバイスをシステムに接続したまま別のユーザーがサインインします。 ユーザーがサインインまたはサインアウトするときに、[IGameController.UserChanged][] イベントが発生します。 このイベントのイベント ハンドラーを登録することで、プレイヤーとプレイヤーが使用中のデバイスを追跡できます。

ユーザー ID は、入力デバイスを対応する UI ナビゲーション コント ローラーに関連付けるための方法でもあります。

これらの理由から、デバイス クラス ([IGameController][] インターフェイスから継承) の [User][igamecontroller.user] プロパティを使用して、プレイヤーの入力が追跡され、関係付けられます。

[UserGamepadPairingUWP _(github)_](
https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/UserGamepadPairingUWP) サンプルでは、ユーザーとそのユーザーが使用中のデバイスを追跡する方法を示してます。

## <a name="detecting-button-transitions"></a>ボタンの状態遷移の検出

ボタンを最初に押したタイミング、または離したタイミングを把握したい場合があります。正確には、離した状態から押した状態への、または押した状態から離した状態へのボタンの状態遷移のタイミングを把握したい場合があります。 これを判断するには、デバイスの前回読み取り結果を記憶し、現在の読み取り結果と比較して状態変化を確認する必要があります。

次の例では、前回の読み取り結果を記憶する基本的な方法を示します。ここで示しているのはゲームパッドですが、アーケード スティック、レース ホイール、および UI ナビゲーション ボタンでも原理は同じです。

```cpp
GamepadReading newReading();
GamepadReading oldReading();

// Game::Loop represents one iteration of a typical game loop
void Game::Loop()
{
    // move previous newReading into oldReading before getting next newReading
    oldReading = newReading, newReading = gamepad.CurrentReading();

    // process device readings using buttonJustPressed/buttonJustReleased
}
```

他の処理を行う前に、`Game::Loop` では `newReading` の既存の値 (前回ループの反復でのゲームパッドの読み取り結果) を `oldReading` に移動して、現在の反復でのゲームパッドの新しい読み取り結果を `newReading` に格納しています。 これにより、ボタンの状態遷移を検出するために必要な情報を提供します。

次の例では、ボタンの状態遷移を検出する基本的な方法を示します。

```cpp
bool buttonJustPressed(const gamepadButtons selection)
{
    bool newSelectionPressed = (selection == (newReading.Buttons & selection));
    bool oldSelectionPressed = (selection == (oldReading.Buttons & selection));

    return newSelectionPressed && !oldSelectionPressed;
}

bool buttonJustReleased(gamepadButtons selection)
{
    bool newSelectionReleased = (gamepadButtons.None == (newReading.Buttons & selection));
    bool oldSelectionReleased = (gamepadButtons.None == (oldReading.Buttons & selection));

    return newSelectionReleased && !oldSelectionReleased;
}
```

上記の 2 つの関数は、まず `newReading` と `oldReading` からボタンの選択状態をブール値で求めています。次に、ブール値の論理演算を実行し、対象となるボタンの状態遷移が発生しているかどうかを判断します。 この 2 つの関数は、新しい読み取り結果が目的の状態 (それぞれ押した状態または離した状態) を含み、**かつ、前回の読み取り結果が目的の状態を含まない場合にのみ _true_ を返します。それ以外の場合は _false_ を返します。


## <a name="detecting-complex-button-arrangements"></a>ボタンの複雑な配置の検出

入力デバイスの各ボタンは、ボタンが押されている (ダウン) か、離されている (アップ) かどうかを示すデジタルの読み取り結果を提供します。 効率を高めるため、ボタンの読み取り結果は個別のブール値としては表現しません代わりに、読み取り結果はすべて、[GamepadButtons][] などのデバイス固有の列挙型で表されるビットフィールドにパックされます。 特定のボタンを読み取るには、ビット単位のマスクを使用して、目的のボタンの値を切り分けます。 マスクに対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。

次の例では、1 つのボタンが押されている状態か離されている状態かを判断する方法を示します。ここで示しているのはゲームパッドですが、アーケード スティック、レース ホイール、および UI ナビゲーション ボタンでも原理は同じです。

```cpp
// determines whether gamepad button A is pressed
if (GamepadButtons::A == (reading.Buttons & GamepadButtons::A))
{
    // button A is pressed
}

// determines whether gamepad button A is released
if (GamepadButtons::None == (reading.Buttons & GamepadButtons::A))
{
    // button A is released (not pressed)
}
```

ご覧のように、1 つのボタンの状態を判断するのは簡単ですが、場合によっては、複数のボタンが押されたか離されたか、または一連のボタンの一部押されていて一部離されているような特定の方法で配置されているかどうかを判断したいことがあります。 複数のボタンを判断するのは 1 つのボタンを判断するより複雑です。特にボタンの状態が混在する可能性のあるときはなおさらです。ただし、1 つのボタンにも複数のボタンにも同様に当てはめることができる簡単な式を使ってボタン状態を判定できます。

次の例では、ゲームパッドのボタン A とボタン B が両方押されているかどうかを判断します。

```cpp
if ((GamepadButtons::A | GamepadButtons::B) == (reading.Buttons & (GamepadButtons::A | GamepadButtons::B))
{
    // buttons A and B are pressed
}
```

次の例では、ゲームパッドのボタン A とボタン B が両方離されているかどうかを判断します。

```cpp
if ((GamepadButtons::None == (reading.Buttons & GamepadButtons::A | GamepadButtons::B))
{
    // buttons A and B are released (not pressed)
}
```

次の例では、ゲームパッドのボタン A が押されていてボタン B が離されているかどうかを判断します。

```cpp
if (GamepadButtons::A == (reading.Buttons & (GamepadButtons::A | GamepadButtons::B))
{
    // button A is pressed and button B is released (button B is not pressed)
}
```

上記の例すべての式に共通しているのは、テストするボタンの配置を等号演算子の左辺で指定し、状態を検討するボタンを等号演算子の右辺のマスク式で選択していることです。

次の例では、上記の例を書き直して、式をより分かりやすく表現する例を示しています。

```cpp
auto buttonArrangement = GamepadButtons::A;
auto buttonSelection = (reading.Buttons & (GamepadButtons::A | GamepadButtons::B));

if (buttonArrangement == buttonSelection)
{
    // button A is pressed and button B is released (button B is not pressed)
}
```

上記の式は、ボタンの数、配置、テストする状態を問わず、どのような場合でも当てはめることができます。



[Windows.System.User]: https://msdn.microsoft.com/library/windows/apps/windows.system.user.aspx
[igamecontroller]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[igamecontroller.user]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.user.aspx
[igamecontroller.userchanged]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.userchanged.aspx
[gamepadbuttons]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepadbuttons.aspx

