---
author: mithom
title: "アーケード スティック"
description: "アーケード スティックの検出と読み取りには、Windows.Gaming.Input アーケード スティック API を使用します。"
ms.assetid: 2E52232F-3014-4C8C-B39D-FAC478BA3E01
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、ゲーム、アーケード スティック、入力"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: b0411dcf1fd75ec7dc31d29a39e95f5c26073953
ms.lasthandoff: 02/07/2017

---

# <a name="arcade-stick"></a>アーケード スティック

このページでは、[Windows.Gaming.Input.ArcadeStick][arcadestick] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った、Xbox One アーケード スティックを対象にしたプログラミングの基礎について説明します。

ここでは、次の項目について紹介します。
* 接続されているアーケード スティックとそのユーザーの一覧を収集する方法
* アーケード スティックが追加または削除されたことを検出する方法
* 1 つ以上のアーケード スティックの入力を読み取る方法
* ナビゲーション デバイスとしてのアーケード スティックの動作


## <a name="arcade-stick-overview"></a>アーケード スティックの概要

アーケード スティックは、店頭のアーケード マシンの雰囲気を再現し、デジタルにより高い精度で制御できる入力デバイスです。 アーケード スティックは、格闘ゲームなどのアーケード ゲームに最適な入力デバイスで、完全デジタル制御に対応しているあらゆるゲームに適しています。 アーケード スティックは、Windows 10 および Xbox One UWP アプリで [Windows.Gaming.Input][] 名前空間によってサポートされています。

Xbox One アーケード スティックは、8 方向のデジタル ジョイスティック、6 個の**操作**ボタン、および 2 個の**特殊**ボタンを搭載しています。完全デジタル入力デバイスで、アナログ制御やバイブレーションはサポートしません。 Xbox One アーケード スティックアーケード スティックには、UI 操作のサポートに使用する **ビュー** ボタンと**メニュー** ボタンも搭載されていますが、これらのボタンはゲームプレイ コマンドのサポートを意図したものではなく、ジョイスティック ボタンとしてすぐに利用できるものではありません。

### <a name="ui-navigation"></a>UI のナビゲーション

ユーザー インターフェイスの操作にさまざまな入力デバイスをサポートする負担を軽くし、ゲームとデバイス間の整合性を高めるため、ほとんどの物理__入力デバイスは、[UI ナビゲーション コントローラー](ui-navigation-controller.md)と呼ばれる個別の論理__入力デバイスとして同時に機能します。 UI ナビゲーション コントローラーは、各種入力デバイスに共通の UI ナビゲーション コマンドのボキャブラリを提供します。

UI ナビゲーション コントローラーとして、アーケード スティックは、ナビゲーション コマンドの[必須セット](ui-navigation-controller.md#required-set)をジョイスティックと**ビュー** ボタン、**メニュー** ボタン、**アクション 1**  ボタン、および**アクション 2** ボタンにマップします。

| ナビゲーション コマンド | アーケード スティック入力  |
| ------------------:| ------------------- |
|                 Up | スティックを上            |
|               Down | スティックを下          |
|               Left | スティックを左          |
|              Right | スティックを右         |
|               View | ビュー ボタン         |
|               Menu | メニュー ボタン         |
|             Accept | アクション 1 ボタン     |
|             Cancel | アクション 2 ボタン     |

アーケード スティックは、ナビゲーション コマンドの[オプション セット](ui-navigation-controller.md#optional-set)はマップしません。


## <a name="detect-and-track-arcade-sticks"></a>アーケード スティックの検出と追跡

アーケード スティックはシステムによって管理されるため、アーケード スティックを自分で作成したり初期化する必要はありません。 接続されているアーケード スティックとイベントの一覧はシステムによって提供され、アーケード スティックが追加または削除されると通知されます。

### <a name="the-arcade-sticks-list"></a>アーケード スティックの一覧

[ArcadeStick][] クラスには静的プロパティである [ArcadeStick][] が用意されています。これは、現在接続されているアーケード スティックの読み取り専用リストです。 接続されているアーケード スティックの一部しか必要ない場合もあるため、`ArcadeSticks` プロパティを利用してデバイスにアクセスするのではなく、独自のコレクションを保持しておくことをお勧めします。

次の例では、接続されているすべてのアーケード スティックを新しいコレクションにコピーします。
```cpp
auto myArcadeSticks = ref new Vector<ArcadeStick^>();

for (auto arcadestick : ArcadeStick::ArcadeSticks)
{
    // This code assumes that you're interested in all arcade sticks.
    myArcadeSticks->Append(arcadestick);
}
```

### <a name="adding-and-removing-arcade-sticks"></a>アーケード スティックの追加と削除

アーケード スティックを追加または削除すると、[ArcadeStickAdded][] および [ArcadeStickRemoved][] イベントが発生します。 これらのイベントのハンドラーを登録することで、現在接続されているアーケード スティックを追跡できます。

次の例では、追加されたアーケード スティックの追跡を開始します。
```cpp
ArcadeStick::ArcadeStickAdded += ref new EventHandler<ArcadeStick^>(Platform::Object^, ArcadeStick^ args)
{
    // This code assumes that you're interested in all new arcade sticks.
    myArcadeSticks->Append(args);
}
```

次の例では、削除されたアーケード スティックの追跡を停止します。
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

### <a name="users-and-headsets"></a>ユーザーとヘッドセット

各アーケード スティックは、ユーザー アカウントと関連付けることでユーザーの ID をユーザーのゲームプレイにリンクできます。また、ボイス チャットやゲーム内機能を円滑化するためにヘッドセットをアタッチすることもできます。 ユーザーとの連携およびヘッドセット操作について詳しくは、[ユーザーおよびそのデバイスの追跡](input-practices-for-games.md#tracking-users-and-their-devices)と、[ヘッドセット](headset.md)に関するページをご覧ください。


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

アーケード スティックの各ボタン (ジョイスティックの 4 方向、6 個の**操作**ボタン、2 個の**特殊**ボタン) は、デジタルの読み取り値によって、押されている (ダウン) か離されている (アップ) かを示します。 効率を高めるため、ボタンの読み取り値は個別のブール値としては表されません。代わりに、読み取り値はすべて、[ArcadeStickButtons][] 列挙型で表される単一のビットフィールドにパックされます。

> **注**    アーケード スティックには、**ビュー** ボタンや**メニュー** ボタンなど、他にも UI 操作に使用するボタンが搭載されています。 これらのボタンは `ArcadeStickButtons` 列挙型には含まれず、UI ナビゲーション デバイスとしてアーケード スティックを利用する場合にしか、読み取られません。 詳しくは、「[UI ナビゲーション デバイス](ui-navigation-controller.md)」をご覧ください。

ボタンの値は、[ArcadeStickReading][] 構造体の `Buttons` プロパティから読み取ります。 このプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。 対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。

次の例では、アクション 1 ボタンが押されているかどうかを判別します。
```cpp
if (ArcadeStickButtons::Action1 == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is pressed
}
```

次の例では、アクション 1 ボタンが離されているかどうかを判別します。
```cpp
if (ArcadeStickButtons::None == (reading.Buttons & ArcadeStickButtons::Action1))
{
    // Action 1 is released (not pressed)
}
```

場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか (一部が押されていて、一部が押されていない) を特定する必要があります。 これらの状態を検出する方法について詳しくは、「[Detecting button transitions (ボタンの移行の検出)](input-practices-for-games.md#detecting-button-transitions)」および「[Detecting complex button arrangements (複雑なボタンのパターンの検出)](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。

## <a name="run-the-inputinterfacing-sample"></a>InputInterfacing サンプルの実行

[InputInterfacingUWP サンプル _(github)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/Samples/System/InputInterfacingUWP) は、アーケード スティックと、種類の異なる入力デバイスとを組み合わせて使用する方法と、これらの入力デバイスが UI ナビゲーション コントローラーとしてどのように動作するかを示します。


## <a name="see-also"></a>参照
[Windows.Gaming.Input.UINavigationController][]
[Windows.Gaming.Input.IGameController][]

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

