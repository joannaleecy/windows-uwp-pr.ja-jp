---
author: eliotcowley
title: UI ナビゲーション コントローラー
description: Windows.Gaming.Input UI ナビゲーション コントローラー API を使うと、UI ナビゲーション用のさまざまな種類の入力デバイスを検出して読み取ることができます。
ms.assetid: 5A14926D-8C2E-4DE8-AAFB-BEEB9BFE91A5
ms.author: elcowle
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP, ゲーム, UI, ナビゲーション
ms.localizationpriority: medium
ms.openlocfilehash: 4f95094ebf31c4b80ee8858ad849da33ff16434a
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4622901"
---
# <a name="ui-navigation-controller"></a>UI ナビゲーション コントローラー

このページでは、[Windows.Gaming.Input.UINavigationController][uinavigationcontroller] とユニバーサル Windows プラットフォーム (UWP) 用の関連 API を使った UI ナビゲーション デバイス向けプログラミングの基礎について説明します。

ここでは、次の項目について紹介します。
* 接続されている UI ナビゲーション デバイスとそのユーザーの一覧を収集する方法
* ナビゲーション デバイスが追加または削除されたことを検出する方法
* 1 つ以上の UI ナビゲーション デバイスの入力を読み取る方法
* ゲームパッドやアーケード スティックがナビゲーション デバイスとして動作するしくみ

## <a name="ui-navigation-controller-overview"></a>UI ナビゲーション コントローラーの概要

それが単なるゲーム開始前のメニューであれ、ゲーム内のダイアログであれ、ほぼすべてのゲームに、ゲームプレイと切り離されたユーザー インターフェイスが少なくとも何かしらは用意されています。 プレイヤーは、どのような入力デバイスを選んでも、その入力デバイスを使ってこのような UI を操作できる必要があります。しかし、各種入力デバイス固有のサポートを追加することは開発者にとって負担になります。また、それによりゲームと入力デバイス間で不整合が生じ、プレイヤーの混乱を招く可能性もあります。 こうした理由から、[UINavigationController][] API が作成されました。

UI ナビゲーション コントローラーは_論理_入力デバイスであり、さまざまな_物理_入力デバイスでサポートできる一般的な UI ナビゲーション コマンドのボキャブラリを提供するために存在しています。 _UI ナビゲーション コントローラー_は物理入力デバイスを確認する別の方法に過ぎません。ナビゲーション コントローラーとして表示されている任意の物理入力デバイスを参照するには_ナビゲーション デバイス_を使用します。 特定の入力デバイスではなく、ナビゲーション デバイスを対象にプログラミングすることで、開発者はさまざまな入力デバイスをサポートする負担を回避しながら既定の状態で整合性を実現できます。

各種入力デバイスでサポートされているコントロールの数と種類は大きく異なる可能性があり、特定の入力デバイスではナビゲーション コマンドをさらに豊富にサポートすることが推奨されるため、ナビゲーション コントローラー インターフェイスではコマンドのボキャブラリを、最も一般的で不可欠なコマンドを含む_必須セット_と、便利だが不可欠ではないコマンドを含む_オプション セット_に分けています。 ナビゲーション デバイスはいずれも_必須セット_のすべてのコマンドをサポートしていますが、_オプション セット_については、そのコマンドをすべてサポートしている場合もあれば、その一部だけをサポートしている場合もあり、まったくサポートしていない場合もあります。

### <a name="required-set"></a>必須セット

ナビゲーション デバイスは_必須セット_内のナビゲーション コマンドをすべてサポートする必要があります。これには、方向 (UP、Down、Left、Right)、View、Menu、Accept、および Cancel のコマンドが該当します。

方向コマンドは、単一の UI 要素間におけるプライマリ [XY フォーカス ナビゲーション](../design/devices/designing-for-tv.md#xy-focus-navigation-and-interaction)を目的としています。 View コマンドおよび Menu コマンドは、ゲームプレイ情報を (多くの場合は一時的に、場合によってはモーダルに) 表示することと、ゲームプレイとメニューのコンテキストを切り替えることをそれぞれ目的としています。 Accept および Cancel コマンドは、肯定的 (はい) および否定的 (いいえ) に応答することをそれぞれ意図しています。

次の表は、これらのコマンドとその使用目的を例と共にまとめたものです。
| コマンド | 使用目的
| -------:| ---------------
|      Up | XY フォーカス ナビゲーションの上
|    Down | XY フォーカス ナビゲーションの下
|    Left | XY フォーカス ナビゲーションの左
|   Right | XY フォーカス ナビゲーションの右
|    View | ゲームプレイの情報を表示 _(スコアボード、ゲーム統計、目標、世界やマップ領域)_
|    Menu | プライマリ メニューまたは一時停止 _(設定、状態、装備、道具、一時停止)_
|  Accept | 肯定的な応答 _(同意する、進む、確認する、開始する、はい)_
|  Cancel | 否定的な応答 _(拒否する、後退する、断る、停止する、いいえ)_


### <a name="optional-set"></a>オプション セット

ナビゲーション デバイスは、_オプション セット_のナビゲーション コマンドをすべてサポートする場合あれば、一部のみサポートしたり、まったくサポートしなかったりする場合もあります。これらには、ページング (上、下、左、および右)、スクロール (上、下、左、および右)、コンテキスト依存 (コンテキスト 1 ～ 4) のコマンドが該当します。

コンテキスト依存のコマンドは、アプリケーション固有のコマンドやナビゲーション ショートカットとしての使用を明確に意図しています。 ページング コマンドとスクロール コマンドは、UI 要素のページやグループ間ですばやく移動することと、UI 要素内で細かく移動することをそれぞれ目的としています。

次の表は、これらのコマンドとその使用目的をまとめたものです。
|     コマンド | 使用目的
| -----------:| ------------
|      PageUp | 上方向にジャンプ (上側または垂直方向の前のページやグループに対して)
|    PageDown | 下方向にジャンプ (下側または垂直方向の次のページやグループに対して)
|    PageLeft | 左方向にジャンプ (左側または水平方向の前のページやグループに対して)
|   PageRight | 右方向にジャンプ (右側または水平方向の次のページやグループに対して)
|    ScrollUp | 上方向にスクロール (フォーカスが置かれた UI 要素またはスクロール可能なグループ内)
|  ScrollDown | 下方向にスクロール (フォーカスが置かれた UI 要素またはスクロール可能なグループ内)
|  ScrollLeft | 左方向にスクロール (フォーカスが置かれた UI 要素またはスクロール可能なグループ内)
| ScrollRight | 右方向にスクロール (フォーカスが置かれた UI 要素またはスクロール可能なグループ内)
|    Context1 | 最初のコンテキスト アクション
|    Context2 | 2 番目のコンテキスト アクション
|    Context3 | 3 番目のコンテキスト アクション
|    Context4 | 4 番目のコンテキスト アクション

> **注:** ゲームは、実際の機能が使用目的と異なっているコマンドに対して自由に応答できますが、予期しない動作は避ける必要があります。 特に、目的の用途を必要とする場合はコマンドの実際の機能を変更しないでください。また、斬新な機能は最も合理的なコマンドに割り当てるようにして、対を成す機能は PageUp/PageDown のような対を成すコマンドに割り当てるようにしてください。 最後に、各種入力デバイスでどのコマンドがサポートされ、そうしたコマンドがどのコントロールにマッピングされるかを考慮して、どのデバイスからでも重要なコマンドにアクセスできるようにしてください。

## <a name="gamepad-arcade-stick-and-racing-wheel-navigation"></a>ゲームパッド、アーケード スティック、およびレース ホイールのナビゲーション

Windows.Gaming.Input 名前空間でサポートされている入力デバイスはすべて UI ナビゲーション デバイスです。

次の表は、_必須セット_のナビゲーション コマンドをさまざまな入力デバイスにマッピングする方法をまとめたものです。

| ナビゲーション コマンド | ゲームパッド入力                       | アーケード スティック入力 | レース ホイール入力 |
| ------------------:| ----------------------------------- | ------------------ | ------------------ |
|                 Up | 左スティックを上/方向パッドを上       | スティックを上           | 方向パッドを上           |
|               Down | 左スティックを下/方向パッドを下   | スティックを下         | 方向パッドを下         |
|               Left | 左スティックを左/方向パッドを左   | スティックを左         | 方向パッドを左         |
|              Right | 左スティックを右/方向パッドを右 | スティックを右        | 方向パッドを右        |
|               View | 表示ボタン                         | 表示ボタン        | 表示ボタン        |
|               Menu | メニュー ボタン                         | メニュー ボタン        | メニュー ボタン        |
|             Accept | A ボタン                            | アクション 1 ボタン    | A ボタン           |
|             Cancel | B ボタン                            | アクション 2 ボタン    | B ボタン           |

次の表は、_オプション セット_のナビゲーション コマンドをさまざまな入力デバイスにマッピングする方法をまとめたものです。

| ナビゲーション コマンド | ゲームパッド入力          | アーケード スティック入力 | レース ホイール入力    |
| ------------------:| ---------------------- | ------------------ | --------------------- |
|             PageUp | 左トリガー           | _サポート外_    | _状況により異なる_              |
|           PageDown | 右トリガー          | _サポート外_    | _状況により異なる_              |
|           PageLeft | L ボタン            | _サポート外_    | _状況により異なる_              |
|          PageRight | R ボタン           | _サポート外_    | _状況により異なる_              |
|           ScrollUp | 右スティックを上    | _サポート外_    | _状況により異なる_              |
|         ScrollDown | 右スティックを下  | _サポート外_    | _状況により異なる_              |
|         ScrollLeft | 右スティックを左  | _サポート外_    | _状況により異なる_              |
|        ScrollRight | 右スティックを右 | _サポート外_    | _状況により異なる_              |
|           Context1 | X ボタン               | _サポート外_    | X ボタン (_一般的な場合_) |
|           Context2 | Y ボタン               | _サポート外_    | Y ボタン (_一般的な場合_) |
|           Context3 | 左スティックを押す  | _サポート外_    | _状況により異なる_              |
|           Context4 | 右スティックを押す | _サポート外_    | _状況により異なる_              |


## <a name="detect-and-track-ui-navigation-controllers"></a>UI ナビゲーション コントローラーの検出と追跡

UI ナビゲーション コントローラーは論理入力デバイスですが、これらは物理デバイスを表しており、物理デバイスと同じようにシステムで管理されます。 UI ナビゲーション コントローラーを自分で作成したり初期化したりする必要はありません。接続されている UI ナビゲーション コントローラーとイベントの一覧はシステムによって提供され、ナビゲーション コントローラーが追加または削除されると通知されます。

### <a name="the-ui-navigation-controllers-list"></a>UI ナビゲーション コントローラーの一覧

[UINavigationController][] クラスには静的プロパティである [UINavigationControllers][] が用意されています。これは、現在接続されている UI ナビゲーション デバイスの読み取り専用リストです。 接続されているナビゲーション デバイスの一部にのみ関心を持つ場合もあるため、`UINavigationControllers` プロパティを利用してデバイスにアクセスするのではなく、独自のコレクションを保持しておくことをお勧めします。

次の例では、接続されているすべての UI ナビゲーション コントローラーを新しいコレクションにコピーします。
```cpp
auto myNavigationControllers = ref new Vector<UINavigationController^>();

for (auto device : UINavigationController::UINavigationControllers)
{
    // This code assumes that you're interested in all navigation controllers.
    myNavigationControllers->Append(device);
}
```

### <a name="adding-and-removing-ui-navigation-controllers"></a>UI ナビゲーション コントローラーの追加と削除

UI ナビゲーション コントローラーが追加または削除されると、[UINavigationControllerAdded][] イベントおよび [UINavigationControllerRemoved][] イベントが発生します。 これらのイベントのイベント ハンドラーを登録することで、現在接続されているナビゲーション デバイスを追跡できます。

次の例では、追加された UI ナビゲーション デバイスの追跡を開始します。
```cpp
UINavigationController::UINavigationControllerAdded += ref new EventHandler<UINavigationController^>(Platform::Object^, UINavigationController^ args)
{
    // This code assumes that you're interested in all new navigation controllers.
    myNavigationControllers->Append(args);
}
```

次の例では、削除されたアーケード スティックの追跡を停止します。
```cpp
UINavigationController::UINavigationControllerRemoved += ref new EventHandler<UINavigationController^>(Platform::Object^, UINavigationController^ args)
{
    unsigned int indexRemoved;

    if(myNavigationControllers->IndexOf(args, &indexRemoved))
    {
        myNavigationControllers->RemoveAt(indexRemoved);
    }
}
```

### <a name="users-and-headsets"></a>ユーザーとヘッドセット

各ナビゲーション デバイスは、ユーザー アカウントと関連付けることでユーザーの ID をその入力にリンクできます。また、ボイス チャットやナビゲーションの機能を円滑化するためにヘッドセットをアタッチすることもできます。 ユーザーとの連携およびヘッドセット操作について詳しくは、[ユーザーおよびそのデバイスの追跡](input-practices-for-games.md#tracking-users-and-their-devices)と、[ヘッドセット](headset.md)に関するページをご覧ください。

## <a name="reading-the-ui-navigation-controller"></a>UI ナビゲーション コントローラーの読み取り

関心のある UI ナビゲーション デバイスを特定したら、その入力を収集する準備ができました。 ただし、なじみのある一部の他の種類の入力とは違い、ナビゲーション デバイスはイベントを発生することによって状態の変化を伝えるわけではありません。 代わりに、イベントを_ポーリング_することで現在の状態を定期的に読み取ります。

### <a name="polling-the-ui-navigation-controller"></a>UI ナビゲーション コントローラーのポーリング

ポーリングでは、明確な時点におけるナビゲーション デバイスのスナップショットをキャプチャします。 入力を収集するこのアプローチはほとんどのゲームに最適です。ゲームのロジックはイベント駆動型ではなく、確定的なループの中で実行されることが一般的なためです。また通常は、徐々に集めた多数の単一の入力によるコマンドを解釈するより、一度に集めた入力によるゲーム コマンドを解釈する方が簡単になります。

ナビゲーション デバイスをポーリングするには、[UINavigationController.GetCurrentReading][getcurrentreading] を呼び出します。この関数はナビゲーション デバイスの状態が格納された [UINavigationReading][] を返します。

```cpp
auto navigationController = myNavigationControllers[0];

UINavigationReading reading = navigationController->GetCurrentReading();
```

### <a name="reading-the-buttons"></a>ボタンの読み取り

各 UI ナビゲーション ボタンは、ボタンが押されているか (ダウン)、離されているか (アップ) に対応するブール型の読み取り値を渡します。 効率を上げるために、ボタンの読み取り値は個々のブール値としては表されません。代わりに、読み取り値はすべて、[RequiredUINavigationButtons][] 列挙型および [OptionalUINavigationButtons][] 列挙型で表される 2 つのビットフィールドのいずれかにパックされます。

_必須セット_に属するボタンは [UINavigationReading][] 構造体の `RequiredButtons` プロパティから読み取ります。_オプション セット_に属するボタンは `OptionalButtons` から読み取ります。 これらのプロパティはビットフィールドであるため、ビット演算子マスクを使用して目的のボタンの値を分離します。 対応するビットが設定されているときはボタンが押されており (ダウン)、それ以外の場合はボタンが離されています (アップ)。

次の例では、_必須セット_の Accept ボタンが押されているかどうかを判別します。
```cpp
if (RequiredUINavigationButtons::Accept == (reading.RequiredButtons & RequiredUINavigationButtons::Accept))
{
    // Accept is pressed
}
```

次の例では、_必須セット_の Accept ボタンが離されているかどうかを判別します。
```cpp
if (RequiredUINavigationButtons::None == (reading.RequiredButtons & RequiredUINavigationButtons::Accept))
{
    // Accept is released (not pressed)
}
```

_オプション セット_のボタンを読み取る場合は必ず `OptionalButtons` プロパティおよび `OptionalUINavigationButtons` 列挙型を使用してください。

次の例では、_オプション セット_の Context1 ボタンが押されているかどうかを判別します。
```cpp
if (OptionalUINavigationButtons::Context1 == (reading.OptionalButtons & OptionalUINavigationButtons::Context1))
{
    // Context 1 is pressed
}
```

場合によっては、ボタンが押された状態から離された状態への移行またはその逆方向への移行のタイミング、複数のボタンが押されているか離されているかの状態、または一連のボタンが特定のパターンの状態になっているかどうか (一部が押されていて、一部が押されていない) を特定する必要があります。 これらの状態を検出する方法について詳しくは、「[Detecting button transitions (ボタンの移行の検出)](input-practices-for-games.md#detecting-button-transitions)」および「[Detecting complex button arrangements (複雑なボタンのパターンの検出)](input-practices-for-games.md#detecting-complex-button-arrangements)」をご覧ください。


## <a name="run-the-ui-navigation-controller-sample"></a>UI ナビゲーション コントローラーのサンプルを実行

[InputInterfacingUWP サンプル _(GitHub)_](https://github.com/Microsoft/Xbox-ATG-Samples/tree/master/UWPSamples/System/InputInterfacingUWP) は、さまざまな入力デバイスが UI ナビゲーション コントローラーとしてどのように動作するかを示します。

## <a name="see-also"></a>関連項目
[Windows.Gaming.Input.Gamepad][]
[Windows.Gaming.Input.ArcadeStick][]
[Windows.Gaming.Input.RacingWheel][]
[Windows.Gaming.Input.IGameController][]


[Windows.Gaming.Input]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.aspx
[Windows.Gaming.Input.Gamepad]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.gamepad.aspx
[Windows.Gaming.Input.Arcadestick]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.arcadestick.aspx
[Windows.Gaming.Input.Racingwheel]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.racingwheel.aspx
[Windows.Gaming.Input.IGameController]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.igamecontroller.aspx
[uinavigationcontroller]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.aspx
[uinavigationcontrollers]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.uinavigationcontrollers.aspx
[uinavigationcontrolleradded]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.uinavigationcontrolleradded.aspx
[uinavigationcontrollerremoved]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.uinavigationcontrollerremoved.aspx
[getcurrentreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationcontroller.getcurrentreading.aspx
[uinavigationreading]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.uinavigationreading.aspx
[requireduinavigationbuttons]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.requireduinavigationbuttons.aspx
[optionaluinavigationbuttons]: https://msdn.microsoft.com/library/windows/apps/windows.gaming.input.optionaluinavigationbuttons.aspx
