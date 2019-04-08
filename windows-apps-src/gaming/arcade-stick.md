---
title: アーケード スティック
description: アーケード スティックの検出と読み取りには、Windows.Gaming.Input アーケード スティック API を使用します。
ms.assetid: 2E52232F-3014-4C8C-B39D-FAC478BA3E01
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10、UWP、ゲーム、アーケード スティック、入力
ms.localizationpriority: medium
ms.openlocfilehash: 6f9e3ff29dfb17b6e2a07df52153013b5266206e
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593147"
---
# <a name="arcade-stick"></a>アーケード スティック

このページでは、[Windows.Gaming.Input.ArcadeStick][arcadestick] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One アーケード スティックを対象にしたプログラミングの基礎について説明します。

ここでは、次の項目について紹介します。

* 接続されているアーケード スティックとそのユーザーの一覧を収集する方法
* アーケード スティックが追加または削除されたことを検出する方法
* 1 つ以上のアーケード スティックの入力を読み取る方法
* アーケード スティックを UI ナビゲーション デバイスとして動作する方法

## <a name="arcade-stick-overview"></a>アーケード スティックの概要

アーケード スティックは、店頭のアーケード マシンの雰囲気を再現し、デジタルにより高い精度で制御できる入力デバイスです。 アーケード スティックは、格闘ゲームなどのアーケード ゲームに最適な入力デバイスで、完全デジタル制御に対応しているあらゆるゲームに適しています。 アーケード スティックは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。

Xbox One アーケード スティックに 8 ウェイのデジタル ジョイスティックが装備されて 6**アクション**(下の画像の A1 A6 として表されます) のボタンと 2 つ**特別な**(S1 と s2 の場合として表されます) ボタンになる。アナログ コントロールまたは振動をサポートしていないすべてデジタル入力デバイス。 Xbox One アーケード スティックが装備されても**ビュー**と**メニュー**ボタン UI のナビゲーションをサポートするために使用がゲームプレイ コマンドをサポートするためにしているものでありません、ジョイスティックのボタンとして簡単にアクセスすることはできません.

![4 方向のジョイスティックをスティックをアーケード 6 アクション ボタン (A1 A6)、および 2 つの特殊なボタン (S1 と s2 の場合)](images/arcade-stick-1.png)

### <a name="ui-navigation"></a>UI のナビゲーション

ユーザー インターフェイスの操作にさまざまな入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、_ほとんどの物理_入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の論理_入力デバイスとして同時に機能します_。 UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。

アーケード スティック マップを UI のナビゲーション コント ローラーとして、[セットに必要な](ui-navigation-controller.md#required-set)のジョイスティックをナビゲーション コマンドと**ビュー**、**メニュー**、**アクション 1**、および**アクション 2**ボタン。

| ナビゲーション コマンド | アーケード スティック入力  |
| ------------------:| ------------------- |
|                 Up | スティックを上            |
|               Down | スティックを下          |
|               Left | スティックを左          |
|              右 | スティックを右         |
|               ビュー | 表示ボタン         |
|               Menu | メニュー ボタン         |
|             OK | アクション 1 ボタン     |
|             Cancel | アクション 2 ボタン     |

アーケード スティックは、ナビゲーション コマンドの[オプション セット](ui-navigation-controller.md#optional-set)はマップしません。

## <a name="detect-and-track-arcade-sticks"></a>アーケード スティックの検出と追跡

検出と追跡アーケード スティックとまったく同じ方法では同様に機能、ゲームパッドの以外に、 [ArcadeStick][]クラスの代わりに、[ゲームパッド](https://docs.microsoft.com/uwp/api/Windows.Gaming.Input.Gamepad)クラス。 詳細については、「[ゲームパッドと振動](gamepad-and-vibration.md)」を参照してください。

<!-- Arcade sticks are managed by the system, therefore you don't have to create or initialize them. The system provides a list of connected arcades sticks and events to notify you when an arcade stick is added or removed.

### The arcade sticks list

The [ArcadeStick][] class provides a static property, [ArcadeSticks][], which is a read-only list of arcade sticks that are currently connected. Because you might only be interested in some of the connected arcade sticks, it's recommended that you maintain your own collection instead of accessing them through the `ArcadeSticks` property.

The following example copies all connected arcade sticks into a new collection. Note that because other threads in the background will be accessing this collection (in the [ArcadeStickAdded][] and [ArcadeStickRemoved][] events), you need to place a lock around any code that reads or updates the collection.

```cpp
auto myArcadeSticks = ref new Vector<ArcadeStick^>();
critical_section myLock{};

for (auto arcadeStick : ArcadeStick::ArcadeSticks)
{
    // Check if the arcade stick is already in myArcadeSticks; if it isn't, add
    // it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myArcadeSticks), end(myArcadeSticks), arcadeStick);

    if (it == end(myArcadeSticks))
    {
        // This code assumes that you're interested in all arcade sticks.
        myArcadeSticks->Append(arcadeStick);
    }
}
```

### Adding and removing arcade sticks

When an arcade stick is added or removed the [ArcadeStickAdded][] and [ArcadeStickRemoved][] events are raised. You can register handlers for these events to keep track of the arcade sticks that are currently connected.

The following example starts tracking an arcade stick that's been added.

```cpp
ArcadeStick::ArcadeStickAdded += ref new EventHandler<ArcadeStick^>(Platform::Object^, ArcadeStick^ args)
{
    // Check if the just-added arcade stick is already in myArcadeSticks; if it
    // isn't, add it.
    critical_section::scoped_lock lock{ myLock };
    auto it = std::find(begin(myGamepads), end(myGamepads), args);

    // This code assumes that you're interested in all new arcade sticks.
    myArcadeSticks->Append(args);
}
```

The following example stops tracking an arcade stick that's been removed.

```cpp
ArcadeStick::ArcadeStickRemoved += ref new EventHandler<ArcadeStick^>(Platform::Object^, ArcadeStick^ args)
{
    unsigned int indexRemoved;

    if(myArcadeSticks->IndexOf(args, &indexRemoved))
    {
        myArcadeSticks->RemoveAt(indexRemoved);
    }
}
```

### Users and headsets

Each arcade stick can be associated with a user account to link their identity to their gameplay, and can have a headset attached to facilitate voice chat or in-game features. To learn more about working with users and headsets, see [Tracking users and their devices](input-practices-for-games.md#tracking-users-and-their-devices) and [Headset](headset.md). -->

## <a name="reading-the-arcade-stick"></a>アーケード スティックの読み取り

目的のアーケード スティックを特定したら、入力を収集する準備は完了です。 ただし、なじみのある一部の他の種類の入力とは違い、アーケード スティックはイベントを発生することによって状態の変化を伝えるわけではありません。 代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。

### <a name="polling-the-arcade-stick"></a>アーケード スティックのポーリング

ポーリングでは、明確な時点におけるアーケード スティックのスナップショットをキャプチャします。 入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。

アーケード スティックをポーリングするには、[GetCurrentReading][] を呼び出します。この関数はアーケード スティックの状態が格納された [ArcadeStickReading][] を返します。

次の例では、アーケード スティックをポーリングして現在の状態を確認します。

```cpp
auto arcadestick = myArcadeSticks[0];

ArcadeStickReading reading = arcadestick->GetCurrentReading();
```

読み取りデータには、アーケード スティックの状態だけでなく、正確にいつ状態が取得されたかを示すタイムスタンプも含まれます。　 このタイムスタンプは、以前の読み取りのタイミングや、ゲームのシミュレーションのタイミングと関連付けに便利です。

### <a name="reading-the-buttons"></a>ボタンの読み取り

各アーケード スティック ボタン&mdash;、ジョイスティックの 4 つの方向 6**アクション**ボタン、および 2**特別な**ボタン&mdash;示すデジタル閲覧を提供するかどうか押されて (いる) または (up) リリースしました。 効率性、ボタンの測定値がない個々 のブール値として表されます。代わりに、すべて豊富で表される 1 つのビット フィールドに、 [ArcadeStickButtons][]列挙体。

> [!NOTE]
> アーケード スティックに UI のナビゲーションなどに使用するその他のボタンが装備されて、**ビュー**と**メニュー**ボタン。 これらのボタンは `ArcadeStickButtons` 列挙型には含まれず、UI ナビゲーション デバイスとしてアーケード スティックを利用する場合にしか、読み取られません。 詳しくは、「[UI ナビゲーション デバイス](ui-navigation-controller.md)」をご覧ください。

ボタンの値は、[ArcadeStickReading][] 構造体の `Buttons` プロパティから読み取ります。 このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。 対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。

次の例を決定するかどうか、**アクション 1**ボタンが押されました。

```cpp
if (ArcadeStickButtons::Action1 == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is pressed
}
```

次の例を決定するかどうか、**アクション 1**ボタンが離されました。

```cpp
if (ArcadeStickButtons::None == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is released (not pressed)
}
```

たいことがありますから、ボタンが遷移するときに決定するリリースに押された状態または、複数のボタンが押された状態またはリリースされるかどうか、または特定の方法で一連のボタンが配置されている場合に押されたリリース&mdash;いくつか押すと、失敗します。 これらの状態を検出する方法について詳しくは、「[Detecting button transitions (ボタンの移行の検出)](input-practices-for-games.md#detecting-button-transitions)」および「[Detecting complex button arrangements (複雑なボタンのパターンの検出)](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。

## <a name="run-the-inputinterfacing-sample"></a>InputInterfacing サンプルの実行

[InputInterfacingUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) は、アーケード スティックと、種類の異なる入力デバイスとを組み合わせて使用する方法と、これらの入力デバイスが UI ナビゲーション コントローラーとしてどのように動作するかを示します。

## <a name="see-also"></a>関連項目

* [Windows.Gaming.Input.UINavigationController][]
* [Windows.Gaming.Input.IGameController][]
* [ゲームの入力のプラクティス](input-practices-for-games.md)

[Windows.Gaming.Input]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[Windows.Gaming.Input.IGameController]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[Windows.Gaming.Input.UINavigationController]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.aspx
[arcadestick]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.aspx
[arcadesticks]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadesticks.aspx
[arcadestickadded]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadestickadded.aspx
[arcadestickremoved]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.arcadestickremoved.aspx
[getcurrentreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.getcurrentreading.aspx
[arcadestickreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestickreading.aspx
[arcadestickbuttons]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestickbuttons.aspx
