---
title: XIM (C#) の使用
author: KevinAsgari
description: C# で Xbox Integrated Multiplayer (XIM) を使用する方法について説明します。
ms.author: kevinasg
ms.date: 04/24/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox Integrated Multiplayer
ms.localizationpriority: medium
ms.openlocfilehash: 71a588a633f2c12a6adf4c062940c4e2bee7fe18
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5970801"
---
# <a name="using-xim-c"></a>XIM (C#) の使用

> [!div class="op_single_selector" title1="Language"]
> - [C++](using-xim.md)
> - [C#](using-xim-cs.md)

ここでは、XIM の C# API の使用方法について概要を紹介します。 ゲーム開発者が C++ 経由で XIM にアクセスする場合は、「[XIM (C++) の使用](using-xim.md)」をご覧ください。
- [XIM (C#) の使用](#using-xim-c)
    - [前提条件](#prerequisites)
    - [初期化および起動](#initialization-and-startup)
    - [非同期操作および状態変更の処理](#asynchronous-operations-and-processing-state-changes)
    - [IXimPlayer の基本的な処理](#basic-iximplayer-handling)
    - [フレンド参加の有効化とフレンドの招待](#enabling-friends-to-join-and-inviting-them)
    - [マッチメイキングの概要および別の XIM ネットワークへの移動](#basic-matchmaking-and-moving-to-another-xim-network-with-others)
    - [デバッグ目的でのマッチメイキング NAT 規則の無効化](#disabling-matchmaking-nat-rule-for-debugging-purposes)
    - [XIM ネットワークの退出およびクリーンアップ](#leaving-a-xim-network-and-cleaning-up)
    - [メッセージの送信と受信](#sending-and-receiving-messages)
    - [データ経路の品質の評価](#assessing-data-pathway-quality)
    - [プレイヤーのカスタム プロパティを使ったデータの共有](#sharing-data-using-player-custom-properties)
    - [ネットワークのカスタム プロパティを使ったデータの共有](#sharing-data-using-network-custom-properties)
    - [プレイヤーごとのスキルによるマッチメイキング](#matchmaking-using-per-player-skill)
    - [プレイヤーごとのロールによるマッチメイキング](#matchmaking-using-per-player-role)
    - [XIM とプレイヤー チームの連携について](#how-xim-works-with-player-teams)
    - [チャットの操作](#working-with-chat)
    - [プレイヤーを消音する](#muting-players)
    - [プレイヤーのチームを使ったチャット ターゲットの構成](#configuring-chat-targets-using-player-teams)
    - [プレイヤー スロットの自動バックグラウンド設定 ("バックフィル" マッチメイキング)](#automatic-background-filling-of-player-slots-backfill-matchmaking)
    - [参加可能なネットワークの照会](#querying-joinable-networks)

## <a name="prerequisites"></a>前提条件

XIM のコーディングを始めるには、2 つの前提条件があります。

1. 標準のマルチプレイヤー ネットワーキング機能を使用してアプリの AppXManifest を設定し、ネットワーク マニフェスト部分を構成して、XIM で使用するのに必要なトラフィック パターン テンプレートを宣言する必要があります。

    AppXManifest 機能およびネットワーク マニフェストについては、プラットフォームのドキュメントの各セクションで詳しく説明されています。また、貼り付ける XIM 固有の XML は、「[XIM プロジェクト構成](xim-manifest.md)」で確認できます。

1. 2 つのアプリケーション ID 情報が必要になります。

    * 割り当てられている Xbox Live タイトル ID。
    * Xbox Live サービスにアクセスするためのアプリケーションのプロビジョニングの一部として提供されるサービス構成 ID。

    これらの取得に関する詳細については、マイクロソフトの担当者にお問い合わせください。 これらの情報は、初期化時に使用されます。

## <a name="initialization-and-startup"></a>初期化および起動 

ライブラリーの操作を開始するには、Xbox Live サービス構成 ID の文字列とタイトル ID 番号を使用して XIM の静的クラスのプロパティを初期化します。 Xbox Services API も使用している場合は、これらを `Microsoft.Xbox.Services.XboxLiveAppConfiguration` から取得すると便利な場合があります。 次の例では、これらの値はそれぞれ "myServiceConfigurationId" および "myTitleId" 変数に既に存在するものと想定しています。

```cs
XboxIntegratedMultiplayer.ServiceConfigurationId = myServiceConfigurationId;
XboxIntegratedMultiplayer.TitleId = myTitleId;
```

初期化した後は、参加するローカル デバイスに現在存在しているすべてのユーザーの Xbox ユーザー ID 文字列をアプリで取得し、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` の呼び出しに渡す必要があります。 次のサンプル コードでは、1 人のユーザーがコントローラーのボタンを押してプレイする意図を示し、そのユーザーに関連付けられた Xbox ユーザー ID 文字列は "myXuid" 変数に既に取得されているものとします。

```cs
XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds(new List<string>() { myXuid });
```

`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` を呼び出すとすぐに、XIM ネットワークに追加する必要のあるローカル ユーザーに関連付けられている Xbox ユーザー ID が設定されます。 この Xbox ユーザー ID のリストは、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` の別の呼び出しによってリストが変更されるまで、以降のすべてのネットワーク操作で使用されます。

XIM ネットワークがまだ存在していない場合、プロセスを開始するために最初の手順として XIM ネットワークに移動します。 ユーザーが特定の XIM ネットワークをまだ想定していない場合のベスト プラクティスは、単に、新しい空のネットワークに移動することです。 そのネットワークは、ユーザーのフレンドの参加を許可することで、次のマルチプレイヤー アクティビティ (一緒にマッチメイキングに入る、など) を共同で選択できる一種の "ロビー" になります。

`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` を使って以前に追加したローカル ユーザーのみを、最大で 8 プレイヤーが参加できる空の XIM ネットワークに移動する方法の例を次に示します。

```cs
XboxIntegratedMultiplayer.MovetoNewNetwork(8, XimPlayersToMove.BringOnlyLocalPlayers);
```

`XboxIntegratedMultiplayer.MovetoNewNetwork()` を呼び出すと、非同期移動操作が開始され、最終的に開発者が定期的に処理する必要がある状態変更イベントが発生します。

## <a name="asynchronous-operations-and-processing-state-changes"></a>非同期操作および状態変更の処理

XIM の中核的な動作は、アプリによる `XboxIntegratedMultiplayer.GetStateChanges()` メソッドの定期的かつ頻繁な呼び出しです。 これらのメソッドを使用して、XIM はアプリがマルチプレイヤーの状態の更新を処理する準備ができた通知を受け取り、キューに入っているすべての更新が含まれた `XimStateChangeCollection` オブジェクトを返してそれらの更新を提供します。 `XboxIntegratedMultiplayer.GetStateChanges()`  は、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。 XIM API は、このシングル スレッド パターン用に実際に最適化されています。 `XimStateChangeCollection` オブジェクトが処理されていて、破棄されない間は、その状態が変化しないことが保証されます。

`XimStateChangeCollection` は、`IXimStateChange` オブジェクトのコレクションです。
アプリは次の処理を行う必要があります。

1. 配列を反復処理する。
1. 具体的な型の `IXimStateChange` を検査する。
1. `IXimStateChange` の型を対応するより詳細な型にキャストする。
1. 必要に応じて更新を処理する。

現在使用可能なすべての `IXimStateChange` オブジェクトが終了した後は、`XimStateChangeCollection.Dispose()` を呼び出すことによってその配列を XIM に戻してリソースを解放する必要があります。 処理が終わった後のリソースが確実に破棄されるように、`using` ステートメントを使用することをお勧めします。 次に、例を示します。

```cs
using (var stateChanges = XboxIntegratedMultiplayer.GetStateChanges())
{
    foreach (var stateChange in stateChanges)
    {
        switch (stateChange.Type)
        {
            case XimStateChangeType.PlayerJoined:
                HandlePlayerJoined((XimPlayerJoinedStateChange)stateChange);
                break;

            case XimStateChangeType.PlayerLeft:
                HandlePlayerLeft((XimPlayerLeftStateChange)stateChange);
                break;

            ...
        }
    }
}
```

これで基本的な処理ループができたので、`XboxIntegratedMultiplayer.MoveToNewNetwork()` の初期操作に関連する状態変化を処理できます。 すべての XIM ネットワーク移動操作は、`XimMoveToNetworkStartingStateChange` で開始します。 何らかの理由で移動が失敗した場合、アプリは `XimNetworkExitedStateChange` を受け取ります。これは、XIM ネットワークへの移動を防止する、または現在の XIM ネットワークからタイトルを切断する、非同期エラーに対する共通のエラー処理メカニズムです。 移動が成功した場合は、すべての状態が終了され、すべてのプレイヤーが XIM ネットワークに正常に追加された後、移動は `XimMoveToNetworkSucceededStateChange` で完了します。

マルチプレイヤー セッションで他のプレイヤーとプレイするプラットフォーム特権がユーザーにない場合、XIM は、XIM ネットワークを作成または参加しようとするデバイスに、理由 `UserMultiplayerRestricted` の `XimNetworkExitedStateChange` を送信します。 これにより、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` を使って設定されたローカル ユーザーすべてに Xbox Live マルチプレイヤーの制限が適用されます。 問題をユーザーに通知して適切に処理してください。

## <a name="basic-iximplayer-handling"></a>IXimPlayer の基本的な処理

1 人のローカル ユーザーを新しい XIM ネットワークに移動する例が成功したとすると、アプリにはローカル `XimLocalPlayer` オブジェクトの `XimPlayerJoinedStateChange` も提供されます。 このオブジェクトは、対応する `XimPlayerLeftStateChange` が提供され、`XimStateChangeCollection.Dispose()` を介して返されるまで、有効な状態が維持されます。 アプリはすべての `XimPlayerLeftStateChange` に対して常に `XimPlayerJoinedStateChange` を提供されます。

`XboxIntegratedMultiplayer.GetPlayers()` を使用することで、いつでも XIM ネットワークのすべての `IXimPlayer` オブジェクトの一覧を取得することもできます。

`IXimPlayer` オブジェクトには、多くの役に立つプロパティとメソッドがあります。たとえば、`IXimPlayer.Gamertag()` は、プレイヤーに関連付けられている現在の Xbox Live ゲーマータグ文字列を表示用に取得します。 `IXimPlayer`がデバイスに対してローカルである場合、IXimPlayer.Local は true を返します。 ローカルの `IXimPlayer` は、ローカル プレイヤーだけが使用できる追加のメソッドを持つ `XimLocalPlayer` にキャストできます。

もちろん、プレイヤーにとって最も重要な状態は XIM が知っている共通の情報ではなく、特定のアプリで追跡する必要のある情報です。その追跡情報に対しては独自のコンストラクトがある可能性があるため、`IXimPlayer` オブジェクトを独自のプレイヤー コンストラクト オブジェクトにリンクして、XIM が `IXimPlayer` を報告するときはいつでも、カスタム プレイヤー コンテキスト オブジェクトを設定して検索を実行することなく状態をすばやく取得できます。 次の例では、プライベート状態が入ったオブジェクトが変数 "myPlayerStateObject" 内にあり、新しく追加される `IXimPlayer` オブジェクトが変数 "newXimPlayer" 内にあるものとします。

```cs
newXimPlayer.CustomPlayerContext = myPlayerStateObject;
```

これは、指定されたオブジェクトをプレイヤー オブジェクトでローカルに保存します (メモリが有効でないときにリモート デバイスにネットワーク経由で転送されることはありません)。 その後は、カスタム コンテキストを取得して、次の例のようにオブジェクトにキャストすることによって、いつでもオブジェクトに戻ることができます。

```cs
myPlayerStateObject = (MyPlayerState)(newXimPlayer.CustomPlayerContext);
```

このカスタム プレイヤー コンテキストはいつでも変更できます。

## <a name="enabling-friends-to-join-and-inviting-them"></a>フレンド参加の有効化とフレンドの招待

プライバシーとセキュリティのため、すべての新しい XIM ネットワークは既定ではローカル プレイヤーのみが参加できるように自動的に構成されるので、準備ができたらアプリ側で明示的に他のプレイヤーを許可する必要があります。 次の例は、`XboxIntegratedMultiplayer.NetworkConfiguration` を使用して現在のネットワーク構成を取得し、`XboxIntegratedMultiplayer.SetNetworkConfiguration()` を使用して参加可能性を更新して、新しいローカル ユーザー、および XIM ネットワーク内の既存のプレイヤーによって招待されたユーザーや "フォロー" されている (Xbox Live ソーシャル関係) ユーザーを、プレイヤーとして参加できるように許可します。

```cs
XimNetworkConfiguration currentConfiguration = new XimNetworkConfiguration(XboxIntegratedMultiplayer.NetworkConfiguration);
currentConfiguration.AllowedPlayerJoins = XimAllowedPlayerJoins.Local | XimAllowedPlayerJoins.Invited | XimAllowedPlayerJoins.Followed;
XboxIntegratedMultiplayer.SetNetworkConfiguration(currentConfiguration);
```

`XboxIntegratedMultiplayer.SetNetworkConfiguration()` が非同期で実行されます。 前のコード サンプルの呼び出しが完了すると、参加可能性の値がその既定値 `XimAllowedPlayerJoins.None` から変更されたことを通知する `XimNetworkConfigurationChangedStateChange` が生成されます。 その後、新しい値は、`XboxIntegratedMultiplayer.NetworkConfiguration.AllowedPlayerJoins` の値をチェックして照会できます。

`XboxIntegratedMultiplayer.NetworkConfiguration.AllowedPlayerJoins` をチェックすることで (デバイスが XIM ネットワーク内にあるとき)、ネットワークの参加可能性を確認できます。

いずれかのローカル プレイヤーが、この XIM ネットワークへの参加招待をリモート ユーザーに送信する場合、アプリは `XimLocalPlayer.ShowInviteUI()` を呼び出してシステム招待 UI を起動できます。 ここでは、ローカル ユーザーが招待するユーザーを選択して、招待を送信できます。

```cs
XimLocalPlayer.ShowInviteUI();
```

上記のステートメントが実行されると、システム招待 UI が表示されます。 ユーザーが招待を送信すると (またはそれ以外で UI を閉じると)、`xim_show_invite_ui_completed_state_change` が提供されます。 または、アプリはシステム招待 UI を表示せずに `XimLocalPlayer.InviteUsers()` を使って直接招待を送信することもできます。

どちらの方法でも、リモート ユーザーはサインインしている場所で Xbox Live 招待メッセージを受け取り、受け入れることができます。 これにより、まだ実行していない場合はデバイスでアプリが起動され、同じ XIM ネットワークに移動するために使用できるイベント引数で "プロトコルのアクティブ化" を行います。

プロトコルのアクティブ化自体について詳しくは、プラットフォームのドキュメントをご覧ください。

次の例は、`XboxIntegratedMultiplayer.ExtractProtocolActivationInformation()` を呼び出して、イベント引数が XIM に適用されるかどうかを調べる方法を示しています。 これは、`Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs` から変数 'uriString' まで生の URI 文字列を取得したことを想定しています。

```cs
XimProtocolActivationInformation protocolActivationInformation;
XboxIntegratedMultiplayer.ExtractProtocolActivationInformation(uriString, out protocolActivationInformation);
if (protocolActivationInformation != null)
{
    // It is a XIM activation.
}
```

XIM のアクティブ化の場合、設定された `XimProtocolActivationInformation` オブジェクトの "LocalXboxUserId" プロパティで示されているローカル ユーザーがサインインしていて、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` に指定されているユーザーに含まれていることを確認する必要があります。 その後、同じ URI 文字列を使用して `XboxIntegratedMultiplayer.MoveToNetworkUsingProtocolActivatedEventArgs()` を呼び出すことで、指定された XIM ネットワークへの移動を開始できます。 次に、例を示します。

```cs
XboxIntegratedMultiplayer.MoveToNetworkUsingProtocolActivatedEventArgs(uriString);
```

"フォローされている" リモート ユーザーはシステム UI でローカル ユーザーのプレイヤー カードに移動し、招待なしに自分だけで参加の試みを開始できることにも注意してください (前に示したように、そのようなプレイヤーの参加を許可してあるものとします)。 このアクションでも、アプリでは招待の場合と同じようにプロトコルのアクティブ化が実行され、同じように処理されます。

プロトコルのアクティブ化を使用した XIM ネットワークへの移動は、「[初期化および起動](#initialization-and-startup)」に示されているように新しい XIM ネットワークへの移動と同じです。 唯一の違いは、移動が成功すると、移動中のデバイスによって、適用可能なプレイヤーを表すローカルとリモート両方のプレイヤーに `XimPlayerJoinedStateChange` オブジェクトが送信されることです。 当然、既に XIM ネットワークに存在していた元のデバイスが移動することはありませんが、`XimPlayerJoinedStateChange` オブジェクトがさらに送信されると、新しいデバイスのユーザーがプレイヤーとして追加されます。

さまざまなデバイスのプレイヤーが XIM ネットワークに一緒に参加すると、マルチプレイヤー シナリオを開始して、音声およびテキストを介して自動的に通信し、アプリ固有のメッセージを送信できます。

## <a name="basic-matchmaking-and-moving-to-another-xim-network-with-others"></a>マッチメイキングの概要および別の XIM ネットワークへの移動

知らないユーザーも含まれる XIM ネットワークにプレイヤーを移動することにより、フレンドのグループのネットワーク エクスペリエンスをさらに拡張できます。 知らないユーザーは世界中から参戦し、同じ興味に基づき Xbox Live マッチメイキング サービスを使って一緒になります。

XIM を使って基本的なマッチメイキングを開始するには、データの設定された `MatchmakingConfiguration` オブジェクトを使用して、いずれかのデバイスで `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を呼び出し、現在の XIM ネットワークからプレイヤーを移動するのが最も簡単です。

次の例では、no-teams free-for-all 用に合計 8 人のプレイヤーを探すようにセットアップされたマッチメイキング構成を使って移動を開始します。 プレイヤーが 8 人見つからない場合、システムにより 2 ～ 7 人のプレイヤーがマッチングされることができます。 この例では、フィルターで除外するゲーム モードを表す、アプリによって定義された定数 (型は uint、名前は MYGAMEMODE_DEATHMATCH) を使います。 XIM のマッチメイキングでは、同じ値を指定する他のプレイヤーだけがこのネットワークとマッチングされ、2 番目のパラメーター `XimPlayersToMove.BringExistingSocialPlayers` を `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` に指定すると、ソーシャル機能を使用して参加したプレイヤーがすべて現在の XIM ネットワークから移行されます。

```cs
var matchmakingConfiguration = new XimMatchmakingConfiguration();
matchmakingConfiguration.TeamConfiguration.TeamCount = 1;
matchmakingConfiguration.TeamConfiguration.MinPlayerCountPerTeam = 2;
matchmakingConfiguration.TeamConfiguration.MaxPlayerCountPerTeam = 8;
matchmakingConfiguration.CustomGameMode = MYGAMEMODE_DEATHMATCH;
XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking(matchmakingConfiguration, XimPlayersToMove.BringExistingSocialPlayers);
```

前述の移動のように、これにより、すべてのデバイスに最初の `MoveToNetworkStartingStateChange` が送信され、成功すると、`MoveToNetworkSucceededStateChange` が送信されます。 この場合は XIM ネットワーク間で移動するため、ローカルユーザーおよびリモートユーザー向けに追加された既存の `IXimPlayer` オブジェクトが存在している点が異なり、このオブジェクトはすべてのプレイヤーを新しい XIM ネットワークにまとめて移動するために保持されます。 プレイヤー間でのチャットとデータ通信は、マッチメイキングが進行中も中断せずに機能し続けます。

同様に `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を呼び出した、マッチメイキング プールに含まれる可能性があるプレイヤーの数によっては、マッチメイキング プロセスに時間がかかることがあります。

ユーザーに現在のステータスを通知し続けるために、`XimMatchmakingProgressUpdatedStateChange` は、この操作が終わるまで定期的に送信されます。 一致すると、一般的な `PlayerJoinedStateChange` を使用してユーザーが XIM ネットワークに追加され、移動は完了します。

この "マッチメイキング型" プレイヤーのセットを使用したマルチプレイヤー体験が完了すると、他のマッチメイキングのラウンドを使用して他の XIM ネットワークに移動することができるこのプロセスを繰り返せるようになります。 以前の `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` 操作によって参加した各プレイヤーが `PlayerLeftStateChange` を生成して、その `IXimPlayer` オブジェクトが同じ XIM ネットワークに存在しなくかったことを示しているのがわかります。

`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を使って再度マッチメイキングを開始することを選んだときに `XimPlayersToMove.BringExistingSocialPlayers` を指定した場合、ソーシャル エントリ ポイントを通じて参加してプレイヤー (`XboxIntegratedMultiplayer.MoveToNetworkUsingProtocolActivatedEventArgs()` or `xXboxIntegratedMultiplayer.MoveToNetworkUsingJoinableXboxUserId`) は、新しいマッチメイキングが行われている間も残ります。 または、`XimPlayersToMove.BringOnlyLocalPlayers` を指定すると、ソーシャル機能を使ってつながったリモート プレイヤーが切断され、ローカル プレイヤーだけが残ります。 どちらの場合も、2 回目の移動操作が完了すると、別の見知らぬユーザーの集合が追加されます。

次のマッチメイキング構成/マルチプレイヤー アクティビティを決めると同時に、マッチメイキング型でないプレイヤー (つまり、ローカル プレイヤー) をまったく新しい XIM ネットワークに移動することも選択できます。

次の例は、XIM ネットワークに最大 8 人のプレイヤーを集めるために、デバイスが `XboxIntegratedMultiplayer.MoveToNewNetwork()` を呼び出す方法を示してます。ただし、今回はソーシャル機能を使用して参加した既存プレイヤーも移動します。

```cs
XboxIntegratedMultiplayer.MovetoNewNetwork(8, XimPlayersToMove.BringExistingSocialPlayers);
```

すべての参加デバイスに`MoveToNetworkStartingStateChange` と `MoveToNetworkSucceededStateChange` が生成され、後に残ったマッチメイキング型のプレイヤーには `PlayerLeftStateChange` が生成されます。 それらのデバイスでも、ネットワークの外に移動された各プレイヤーには `PlayerLeftStateChange` が表示されます。

上記で説明した方法を必要な回数だけ使用して、引き続き XIM ネットワーク間で移動できます。

パフォーマンス上、Xbox Live サービスは、直接ピア ツー ピア接続を確立できないデバイス上でプレイヤーのグループのマッチングを試行することはありません。 標準の Xbox Live マルチプレイヤーをサポートするように適切に構成されていないネットワーク環境で開発している場合、マッチメイキング条件を満たし、同一のローカル環境にあるすべてのデバイスを移動中および使用中のプレイヤーが十分にいる場合でも、正常なマッチメイキングが行われることなく、マッチメイキングを使用した新しいネットワークへの移動操作が無期限に続くことがあります。 必ずネットワーク設定領域/Xbox アプリケーションでマルチプレイヤーの接続テストを実行し、特に "Strict NAT" についての問題を報告する場合の推奨事項に従ってください。

## <a name="disabling-matchmaking-nat-rule-for-debugging-purposes"></a>デバッグ目的でのマッチメイキング NAT 規則の無効化

ネットワーク管理者が環境に必要な変更を行って XIM の NAT 規則をサポートすることができない場合は、Xbox One 開発キットでテストのブロックを解除できます。そのためには、"Open NAT" デバイスを 一切指定せずに "ストリクト NAT" デバイスをマッチングできるように XIM を構成します。 これを行うには、すべての Xbox One 本体上の "title scratch" ドライブのルートに "xim_disable_matchmaking_nat_rule" と呼ばれるファイル (内容は問いません) を配置します。 配置する方法のひとつとして、アプリを起動する前に XDK コマンド プロンプトから以下を実行し、プレースホルダー "{console_name_or_ip_address}" を適宜各コンソールに置き換える方法があります。

```bat
echo.>%TEMP%\emptyfile.txt
copy %TEMP%\emptyfile.txt \\{console_name_or_ip_address}\TitleScratch\xim_disable_matchmaking_nat_rule
del %TEMP%\emptyfile.txt
```

> [!NOTE]
> この開発上の回避策は、現在 Xbox One 排他リソース アプリケーションでのみ使用することができ、ユニバーサル Windows アプリではサポートされません。 また、本体でこの設定を使用している場合は、ネットワーク環境にかかわらず、このファイルも存在しないデバイスにマッチングすることはないため、ファイルは、あらゆる場所で追加および削除することができます。

## <a name="leaving-a-xim-network-and-cleaning-up"></a>XIM ネットワークの退出およびクリーンアップ

ローカル ユーザーが XIM ネットワークに参加している場合、新しい XIM ネットワークに戻るだけで、ローカル ユーザー、招待ユーザー、"フォローされている" ユーザーはその XIM ネットワークに参加できるため、引き続きフレンドと協力して次のアクティビティに進むことができます。 しかし、ユーザーがすべてのマルチプレイヤー エクスペリエンスを完全に完了している場合、アプリは、XIM ネットワークからの撤退を開始して、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds` のみが呼び出された場合と同様の状態に戻る場合があります。 この処理を実行するには、`XboxIntegratedMultiplayer.LeaveNetwork()` メソッドを使います。

```cs
 XboxIntegratedMultiplayer.LeaveNetwork();
```

このメソッドでは、他の参加者から非同期的に切断するプロセスを正常に開始します。 これにより、リモート デバイスで切断されたローカル プレイヤーごとに `PlayerLeftStateChange` が生成されます。 ローカル デバイスでは、切断されたローカル プレイヤーおよびリモート プレイヤーごとに `PlayerLeftStateChange` も生成されます。 すべての接続操作が完了すると、最後に `NetworkExitedStateChange` が送信されます。

`NetworkExitedStateChange` がまだ送信されていない場合は、`XboxIntegratedMultiplayer.LeaveNetwork()` を呼び出し、`NetworkExitedStateChange` を待機して、XIM ネットワークを正常終了することを強くお勧めします。

## <a name="sending-and-receiving-messages"></a>メッセージの送信と受信

XIM とその基になっているコンポーネントによって、インターネット経由で手間をかけずに安全な通信チャネルを確立することができるため、接続の問題や、一部のプレイヤーが受信できない可能性があることを心配する必要はありません。 ピア ツー ピア接続の基盤に問題がある場合、XIM ネットワークへの移動は成功しません。

XIM ネットワークが形成されて `XimMoveToNetworkSucceededStateChange` によって確認された場合、参加しているすべてのデバイス間のアプリのすべてのインスタンスには、`IXimPlayer` が XIM ネットワークに接続するために通知を受け取ることが保証され、そのどれにもメッセージを送信できます。

XIM ネットワーク経由でメッセージを送信する方法について説明します。 次の例では、'sendingPlayer' 変数が有効なローカル プレイヤー オブジェクトであると想定しています。 この例では、'sendingPlayer' のメソッド `SendDataToOtherPlayers()` を使い、'msgBuffer' にコピーされたメッセージ構造体を XIM ネットワーク内のすべてのプレイヤー (ローカルまたはリモート) に送信します。 特定のプレイヤーのリストはメソッドに渡されていないため、すべてのプレイヤーに送信されることに注意してください。

```cs
SendingPlayer.SendDataToOtherPlayers(msgBuffer, null, XimSendType.GuaranteedAndSequential);
```

メッセージのすべての受信者には、データのコピー、メッセージを送信した `IXimPlayer` オブジェクト、メッセージをローカルに受信する `IXimPlayer` オブジェクトの一覧を含む `XimPlayertoPlayerDataReceivedStateChange` が提供されます。

もちろん保証されたシーケンシャル配信は便利ですが、インターネットでパケットがドロップされたりパケットの順序が正しくない場合は XIM はメッセージを再送信または遅延する必要があるため、効率的ではない送信タイプでもあります。 アプリがパケットのドロップや順序の間違いを許容できるメッセージに対しては他の送信タイプの使用を検討してください。 メッセージ データはリモート コンピューターから送られてくるので、データ形式を明確に定義 (特定のバイト オーダー ("エンディアン") でマルチバイト値をパッキングするなど) するのがベスト プラクティスです。 アプリでは、処理する前にデータを検証する必要もあります。

XIM には、ネットワーク レベルのセキュリティが備わっているため、追加の暗号化または署名スキームは必要ありません。 ただし、予想外のアプリケーションのバグから保護して、異なるバージョンのアプリケーション プロトコルの共存 (開発、コンテンツの更新などのとき) を徐々に処理できるように、常に "きめ細かい防御" を採用することをお勧めします。 ユーザーのインターネット接続も、常に変わり続ける限られたリソースです。 有益なメッセージ データ形式を使用し、すべての UI フレームを送信するような設計にしないことを強くお勧めします。

## <a name="assessing-data-pathway-quality"></a>データ経路の品質の評価

2 人のプレイヤー間における現在のデータ経路の品質の詳細は、`XimPlayer.NetworkPathInformation` プロパティを検査して確認できます。 2 人のプレイヤー間における現在のパスの品質の詳細は、`XimPlayer.NetworkPathInformation` プロパティを検査して確認できます。 プロパティには、予想される往復遅延時間に加え、接続上の理由からその時点で追加データを送信できない場合に送信できるように、ローカルのキューに入ったままのメッセージ数が含まれます。

特定の 'IXimPlayer' のキューがバックアップ中であると表示される場合は、データの送信速度を抑える必要があります。

`NetworkPathInformation.RoundTripLatency` フィールドは、基盤のネットワークの待機時間と、キューを経由しない場合の XIM の推定待機時間を表します。 実際の遅延時間は、`XimNetworkPathInformation.SendQueueSizeInMessages` が大きくなり、XIM がキュー経由で動作するようになるにつれて増加します。

ゲームの使用状況と要件に基づいて、`SendDataToOtherPlayers` の呼び出しの調整を開始する適切なポイントを選択してください。 送信キューにメッセージがあるということは、実際のネットワーク待機時間が増えることを意味します。

XIM の上限 (現在は 3,500 件のメッセージ) に近い値は、ほとんどのゲームにとっては大きすぎ、`SendDataToOtherPlayers` の呼び出し頻度と各データ ペイロードの大きさに応じて、データが送信されるまでに数秒の待機時間が生じる可能性があります。 代わりに、ゲームの待機時間の要件と、ゲームでの `SendDataToOtherPlayers` の呼び出しパターンの頻度を合わせて考慮して、適切な数値を選択してください。

## <a name="sharing-data-using-player-custom-properties"></a>プレイヤーのカスタム プロパティを使ったデータの共有

メソッドの受信者や、そのメソッドでパケットの損失などを処理する日時や方法を大部分コントロールできるため、ほとんどのアプリにおいて、データ交換には `XimLocalPlayer.SendDataToOtherPlayers()` メソッドが使用されます。 ただし、プレイヤーにとっては、基本的でまれな変更ステータスを最小限の手間で他者と共有した方が好都合である場合があります。 たとえば、すべてのプレイヤーがゲーム内の表現をレンダリングするために使用するマルチプレイヤーを入力する前に選択したキャラクター モデルを表す文字列は、各プレイヤーによって変更される場合があります。

プレイヤーに関するデータがそれほど頻繁に変化しない場合、XIM はカスタム プロパティをプレイヤーに提供します。 これらのプロパティは、アプリ定義の名前と値で構成されています。この名前と値は、ローカル プレイヤーに適用でき、変更されると自動的にすべてのデバイスに伝達されます。

カスタム プレイヤー プロパティの内部的な同期オーバーヘッドは `XimLocalPlayer.SendDataToOtherPlayers()` メソッドより大きくなるため、すぐに変化するデータの場合 (プレーヤーの位置など)、直接送信を使用する必要があります。

プレイヤー カスタム プロパティのキー/値ペアの現在の値は、それらのデバイスが XIM ネットワークに参加し、追加したプレイヤーが表示されると、自動的に新しく追加したデバイスに適用されます。 値を設定するには、'localPlayer' 変数によって指定されるローカルの `IXIMPlayer` オブジェクトに値 "brute" を含めるように "model" という名前のプロパティを設定し、名前と値の文字列を使用して、`XimLocalPlayer.SetPlayerCustomProperty()` を呼び出します。

```cs
localPlayer.SetPlayerCustomProperty("model","brute");
```

プレイヤーのプロパティを変更すると、`XimPlayerCustomPropertiesChangedStateChange` がすべてのデバイスに送信され、変更されているプロパティの名前に警告が通知されます。 指定された名前の値は、`IXIMPlayer.GetPlayerCustomProperty()` を使用して、ローカルまたはリモートで、どのプレイヤーも取得することができます。 以下の例は、'ximPlayer' 変数で指定された `IXIMPlayer` から、"model" という名前のプロパティの値を取得しています。

```cs
string propertyValue = localPlayer.GetPlayerCustomProperty("model");
```

指定されたプロパティ名に新しい値を設定すると、既存の値が置き換えられます。 プロパティ名を null 値の文字列ポインターの値の設定すると、空の値文字列と同様に処理されます。つまり、まだ指定されていないプロパティと同様です。 名前および値は、XIM で解釈されないため、必要に応じて文字列の内容を検証するアプリに残されます。

別の XIM ネットワークに移動すると、カスタム プレイヤー プロパティが必ずリセットされます。 ただし、XIM ネットワークに参加した新しいプレイヤーは、いくつかが設定されているすべてのプレイヤーの最新のカスタム プレイヤー プロパティを受け取ります。

## <a name="sharing-data-using-network-custom-properties"></a>ネットワークのカスタム プロパティを使ったデータの共有

ネットワーク カスタム プロパティは、頻繁に変わらない XIM ネットワークに固有のデータを簡単に同期できるように用意されています。 ネットワーク カスタム プロパティは、`XboxIntegratedMultiplayer.SetNetworkCustomProperty()` を使用して XIM シングルトン オブジェクトで設定されている場合を除き、[プレイヤー カスタム プロパティ](#sharing-data-using-player-custom-properties)と同様に使用できます。 以下の例では、値が "stronghold" になるように "map" プロパティを設定しています。

```cs
XboxIntegratedMultiplayer.SetNetworkCustomProperty("map", "stronghold");
```

ネットワークのプロパティを変更すると、`NetworkCustomPropertiesChanged` がすべてのデバイスに送信され、変更されているプロパティの名前に警告が通知されます。 指定した名前の値は、以下の例で "map" というプロパティの値を取得しているように、`XboxIntegratedMultiplayer.GetNetworkCustomProperty()` を使用して取得できます。

```cs
string property = XboxIntegratedMultiplayer.GetNetworkCustomProperty("map")
```

[プレイヤー カスタム プロパティ](#sharing-data-using-player-custom-properties)と同様、指定されたプロパティ名に新しい値を設定すると、既存の値が置き換えられます。 プロパティ名を null 値の文字列ポインターの値の設定すると、空の値文字列と同様に処理されます。つまり、まだ指定されていないプロパティと同様です。 名前および値は、XIM で解釈されないため、必要に応じて文字列の内容を検証するアプリに残されます。

新しく作成された XIM ネットワークは常に、ネットワーク カスタム プロパティが設定されていない状態で開始されます。 ただし、既存の XIM ネットワークに参加する新しいプレイヤーは、その XIM ネットワークに設定されたネットワーク カスタム プロパティの最新の値を受け取ります。

## <a name="matchmaking-using-per-player-skill"></a>プレイヤーごとのスキルによるマッチメイキング

固有のアプリ指定のゲーム モードの共通の関心を使用したプレイヤーのマッチングは、優れた基本戦略です。 利用可能なプレイヤーのプールが大きくなるにつれて、ベテラン プレイヤーが、他のベテランと正当な対戦を楽しめるように、ゲームの個人スキル、または体験に基づいて、マッチプレイヤーを考慮する必要がありますが、新しいプレイヤーは、同様の能力の他者と対戦することで、レベルを上げることができます。

これを行うにはまず、マッチメイキングを使用して XIM ネットワークに移動する前に、`XimLocalPlayer.SetRolesAndSkillConfiguration()` の呼び出しで指定されるプレイヤーごとのロールとスキル構成構造体で、すべてのローカル プレイヤーにスキル レベルを提供します。 スキル レベルはアプリ固有の概念であり、数が XIM で解釈されることはありません。例外として、マッチメイキングでまず同一のスキル値を持つプレイヤーを探してから、定期的に +/- 10 単位で検索対象の増減を行い、そのスキル範囲内でスキル値を宣言する他のプレイヤーを探すことができます。 以下の例では、ローカルの `XimLocalPlayer` オブジェクトを想定しています。このオブジェクトの変数は 'localPlayer' であり、ローカルまたは Xbox Live のストレージから 'playerSkillValue' と呼ばれる変数に対して取得されたアプリ固有の整数のスキル値が格納されます。

```cs
var config = new XimPlayerRolesAndSkillConfiguration();
config.Skill = playerSkillValue;
localPlayer.SetRolesAndSkillConfiguration(config);
```

これが完了すると、この `IXIMPlayer` によってプレイヤーごとのロールとスキル構成が変更されたことを示す `XimPlayerRolesAndSkillConfigurationChangedStateChange` が、すべての参加者に送信されます。 新しい値を取得するには、`IXIMPlayer.RolesAndSkillConfiguration` を呼び出します。 すべてのプレイヤーに null 以外のマッチメイキング設定が適用されたら、`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` に指定された `XimMatchmakingConfiguration` 構造体の `RequirePlayerRolesAndSkillConfiguration` フィールドに true 値を指定してマッチメイキングを使用することで XIM に移動できます。

次の例では、no-teams free-for-all 用に合計 2 ～ 8 人のプレイヤーを探すマッチメイキング構成を事前設定します。 さらに、この例では、フィルターで除外するゲーム モードを表す、アプリによって定義された定数 (型は Uint64、名前は MYGAMEMODE_DEATHMATCH) を使います。 XIM ネットワークのプレイヤーと、同じ値を指定しており、プレイヤーごとのマッチメイキング構成を必要とする他のプレイヤーをマッチングするようにマッチメイキングが構成されます。

```cs
XimMatchmakingConfiguration matchmakingConfiguration = new XimMatchmakingConfiguration();
matchmakingConfiguration.TeamConfiguration.TeamCount = 1;
matchmakingConfiguration.TeamConfiguration.MinPlayerCountPerTeam = 2;
matchmakingConfiguration.TeamConfiguration.MaxPlayerCountPerTeam = 8;
matchmakingConfiguration.CustomGameMode = MYGAMEMODE_DEATHMATCH;
matchmakingConfiguration.RequirePlayerRolesAndSkillConfiguration = true;
```

この構造体が `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` に送信されると、移動するプレイヤーによって、null 以外の `XimPlayerRolesAndSkillConfiguration` オブジェクトを使用して `XimLocalPlayer.SetRolesAndSkillConfiguration()` が呼び出されている限り、この移動操作は正常に開始されます。 これが行われていないプレイヤーがいる場合、マッチメイキング処理は一時停止され、`WaitingForPlayerRolesAndSkillConfiguration` 値が指定された `XimMatchmakingProgressUpdatedStateChange` がすべての参加者に送信されます。 これには、マッチメイキングが完了する前に、事前に送信された招待または他のソーシャルな手段 (`XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableXboxUserId()` の呼び出しなど) で、XIM ネットワークに途中参加したプレイヤーも含まれます。 すべてのプレイヤーが `XimPlayerRolesAndSkillConfiguration` オブジェクトを送信した時点で、マッチメイキングが再開されます。

次のセクションで説明するように、プレイヤーごとのスキルを使うマッチメイキングを、プレイヤーごとのロールを使うマッチメイキングと組み合わせることもできます。 いずれかのみ指定する場合は、他のマッチメイキングに値 0 を指定できます。 これは、スキル値 `XimPlayerRolesAndSkillConfiguration` が 0 であると宣言するすべてのプレイヤーは必ず互いにマッチングされるためです。

`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` や、その他すべての XIM ネットワークの移動操作が完了すると、すべてのプレイヤーの `XimPlayerRolesAndSkillConfiguration` 構造体は、自動的に null ポインターにクリアされます (付随して `XimPlayerRolesAndSkillConfigurationChangedStateChange` 通知が送信されます)。 プレイヤーごとの設定が必要なマッチメイキングを使用して、別の XIM ネットワークに移動する場合、常に最新の情報を含むオブジェクトで、再度 `XimLocalPlayer.SetRolesAndSkillConfiguration()` を呼び出します。

## <a name="matchmaking-using-per-player-role"></a>プレイヤーごとのロールによるマッチメイキング

プレイヤーごとのロールとスキル構成を使用してユーザーのマッチメイキング エクスペリエンスを高める別の方法として、必要なプレイヤー ロールを使うことができます。 これは、さまざまな協力型プレイ スタイルを提案するキャラクター タイプを選択できるゲームに最も適しています。 これらのキャラクター タイプは、ゲーム内のグラフィカル表現をただ変更するのではなく、代わりにプレイヤーのゲームプレイ スタイルを変更するものです。 ユーザーは、専門分野としてプレイする場合があるということを意味します。 しかし、各ロールを満たす者が存在せずに、機能的に目的を完了させることができないようにゲームが設計されている場合は、任意のプレイヤーをまとめてマッチングさせるよりもそのようなプレイヤーをまとめてマッチングさせ、集まった時点でプレイヤー間でプレイ スタイルを検討する方が望ましい場合があります。 これを行うには、指定のプレイヤーの `XimPlayerRolesAndSkillConfiguration` 構造体で指定される各ロールを表す一意のビット フラグを最初に定義します。

以下の例では、ローカルの `XimLocalPlayer` オブジェクトに対して、アプリ固有のロール値 (型は byte、名前は MYROLEBITFLAG_HEALER) を設定します。このポインターは、'localPlayer' になります。

```cs
var config = new XimPlayerRolesAndSkillConfiguration();
config.Roles = MYROLEBITFLAG_HEALER;
localPlayer.SetRolesAndSkillConfiguration(config);
```

これが完了すると、この `IXimPlayer` によってプレイヤーごとのロールとスキル構成が変更されたことを示す `XimPlayerRolesAndSkillConfigurationChangedStateChange` が、すべての参加者に送信されます。 新しい値を取得するには、`IXimPlayer.RolesAndSkillConfiguration` を呼び出します。

`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` に指定されたグローバル構造体 `XimMatchmakingConfiguration` には、ビットごとの OR を使用して結合されたすべての必要なロール フラグや、`RequirePlayerRolesAndSkillConfiguration` フィールドに対する true 値が含まれます。

プレイヤーごとのロールを使うマッチメイキングを、プレイヤーごとのスキールを使うマッチメイキングと組み合わせることもできます。 いずれかのみ指定する場合は、他の構造体に値 0 を指定します。 これは、`XimPlayerRolesAndSkillConfiguration` スキル値が 0 であると宣言しているすべてのプレイヤーが常に互いに一致するためであり、`XimMatchmakingConfiguration.RequiredRoles`  フィールドのすべてのビットがゼロの場合は、一致させるためのロール ビットは必要ありません。

`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` や、その他すべての XIM ネットワークの移動操作が完了すると、すべてのプレイヤーの `XimPlayerRolesAndSkillConfiguration` オブジェクトは、自動的に null にクリアされます (付随して `XimPlayerRolesAndSkillConfigurationChangedStateChange` 通知が送信されます)。 プレイヤーごとの設定が必要なマッチメイキングを使用して、別の XIM ネットワークに移動する場合、常に最新の情報を含むオブジェクトで、再度 `XimLocalPlayer.SetRolesAndSkillConfiguration()` を呼び出します。

## <a name="how-xim-works-with-player-teams"></a>XIM とプレイヤー チームの連携について

マルチプレイヤーのゲームでは、プレイヤーを相手チームに組み込むことも必要になります。 XIM では、`XimMatchmakingConfiguration.TeamConfiguration` を設定することにより、マッチメイキング時のチームの割り当てが容易になります。 以下の例では、2 チーム 4 人ずつ (4 人見つからない場合は 1 ～ 3 人でも許容可能) の合計 8 人のプレイヤーを探すように構成されたマッチメイキングを使用して移動を開始します。 さらに、この例では、フィルターで除外するゲーム モードを表す、アプリによって定義された定数 (型は uint、名前は MYGAMEMODE_CAPTURETHEFLAG) を使います。  さらに、ソーシャルな方法で参加したすべてのプレイヤーを現在の XIM ネットワークから移動するように構成がセットアップされます。

```cs
var matchmakingConfiguration = new XimMatchmakingConfiguration();
matchmakingConfiguration.TeamConfiguration.TeamCount = 2;
matchmakingConfiguration.TeamConfiguration.MinPlayerCountPerTeam = 1;
matchmakingConfiguration.TeamConfiguration.MaxPlayerCountPerTeam = 4;
XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking(matchmakingConfiguration, XimPlayersToMove.BringExistingSocialPlayers);
```

このような XIM ネットワークの移動操作が完了すると、リクエストされたチーム数に対応して、プレイヤーに 1 から {n} のチーム インデックス値が割り当てられます。 プレイヤーのチーム インデックスの値は、`IXIMPlayer.TeamIndex` を使用して取得されます。 2 つ以上のチームで `XimMatchmakingConfiguration.TeamConfiguration` を使用している場合、`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` の呼び出しで、プレイヤーにチームインデックス値 0 が割り当てられることはありません。 これは、他の構成や種類の移動操作 (招待の承認によるプロトコルのアクティブ化など) で XIM ネットワークに追加されるプレイヤーと対照的です。これらのプレイヤーには、常にチーム インデックス値 0 が割り当てられます。 インデックス 0 のチームを特別な "未割り当て" チームとして扱うと便利な場合があります。

以下の例では、'ximPlayer' 変数に保存された XIM プレイヤー オブジェクトのチーム インデックスを取得します。

```cs
byte playerIndex = ximPlayer.TeamIndex;
```

Xbox Live のマッチメイキング サービスでは、(プレイヤーによる否定的な行動の機会を制限するだけではなく) 望ましいユーザー エクスペリエンスを実現するために、一緒に XIM ネットワークに移動する複数のプレイヤーが別々のチームに分割されることはありません。

マッチメイキングによって最初に割り当てられているチームのインデックス値は単なる推奨値であり、アプリではいつでも `XimLocalPlayer.SetTeamIndex()` を使用してローカル プレイヤーの値を変更できます。 これは、マッチメイキングを一切使用していない XIM ネットワークで呼び出すこともできます。 以下の例では、新しいチーム インデックス値として 1 が設定されるように、'ximLocalPlayer' 変数に格納される XIM ローカル プレイヤー オブジェクトを構成します。

```cs
ximLocalPlayer.SetTeamIndex(1);
```

プレイヤーに新しいチーム インデックス値が設定された場合、すべてのデバイスは、プレイヤーの `XimPlayerTeamIndexChangedStateChange` を受信することで通知されます。 `XimLocalPlayer.SetTeamIndex()` は、いつでも呼び出すことができます。

マッチメイキングでは、チームとは別に各プレイヤーに必要なロールが評価されます。 チームはプレイヤーに割り当てられたロールではなくプレイヤーの数で調整されるため、マッチメイキング構成条件として、チームと必要なロールの両方を同時に使用することはお勧めできません。

## <a name="working-with-chat"></a>チャットの操作

XIM ネットワーク内のプレイヤー間の音声およびテキスト チャット通信は、自動的に有効になります。 XIM は、すべての音声ヘッドセットとマイクのハードウェアとの通信を操作します。 チャットを使用するために必要な設定はアプリにありませんが、テキスト チャットに関する要件が 1 つあります。入力および表示をサポートしていることです。 テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、プレイヤーはこのシステムで、音声合成の支援技術を使用する場合があるためです。 同様に、プレイヤーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。

必要に応じてテキストのメカニズムを有効にする場合、ローカル プレイヤーのこれらの設定を検出するには、`XimLocalPlayer.ChatTextToSpeechConversionPreferenceEnabled` フィールドと `XimLocalPlayer.ChatSpeechToTextConversionPreferenceEnabled` フィールドにそれぞれアクセスします。必要に応じて、テキストのメカニズムを有効にすることもできます。 ただし、テキスト入力および表示オプションを常に有効にすることを検討することをお勧めします。

`Windows::Xbox::UI::Accessability` は、音声テキスト変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。

現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `XimLocalPlayer.SendChatText()` メソッドに渡します。 以下のコードは、'localPlayer' 変数によって指定されたローカルの `IXIMPlayer` オブジェクトからハード コードされたサンプル文字列の送信を示します。

```cs
localPlayer.SendChatText(text);
```

このチャット テキストは、発信元のローカル プレイヤーからチャット通信を受信できる、XIM ネットワーク内のすべてのプレイヤーに `XimChatTextReceivedStateChange` として送信されます。 TTS が有効な場合、音声に合成される可能性があります。

アプリは、受け取ったテキスト文字列のコピーを作成し、発信元プレイヤーの ID の一部と共に、適切な長さの時間 (またはスクロール可能なウインドウで) 表示する必要があります。

チャットに関するベスト プラクティスは他にもいくつかあります。 特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。 これを行うには、`IXimPlayer.ChatIndicator` にアクセスし、プレイヤーのチャットの現在の瞬間的なステータスを表す `XboxIntegratedMultiplayer.XimPlayerChatIndicator` を取得します。

`IXimPlayer.ChatIndicator` によって報告される値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。 そのため、すべての UI フレームをポーリングできるように設計されています。

> [!NOTE]
> デバイス設定のためにローカル ユーザーが十分な通信権限を持っていない場合、`XimLocalPlayer.ChatIndicator` は値が `XIM_PLAYER_CHAT_INDICATOR_PLATFORM_RESTRICTED` の `XboxIntegratedMultiplayer.XimPlayerChatIndicator` を返します。 プラットフォームに期待される要件は、音声チャットやメッセージのプラットフォーム制限を示すアイコンや問題をユーザーに示すメッセージをアプリに表示することです。 推奨されるメッセージの例は、"申し訳ございません。現在チャットは許可されていません" です。

## <a name="muting-players"></a>プレイヤーを消音する

もう 1 つのベスト プラクティスは、プレイヤーのミュートをサポートすることです。 XIM では、ユーザーはプレイヤー カードを使用してシステムを自動的にミュートできますが、`IXimPlayer.ChatMuted` プロパティを経由してゲーム UI 内で実行されるゲーム固有の一時的なミュートをアプリでもサポートしている必要があります。 以下の例では、'remotePlayer 変数でリモートの `IXIMPlayer` オブジェクトを指定し、ミュートを開始します。これにより、ボイス チャットが聞こえず、テキスト チャットを受け取らない状態になります。

```cs
remotePlayer.ChatMuted = true;
```

ミュートは、すぐに適用され、XIM の状態変更とは関連付けられません。 `IXimPlayer.ChatMuted` プロパティの値を false に変更することができます。 以下の例では、'remotePlayer' 変数によって指定されているリモートの `IXIMPlayer` オブジェクトのミュートを解除します。

```cs
remotePlayer.ChatMuted = false;
```

そのプレイヤーで新しい XIM ネットワークに移動する場合など、`IXIMPlayer` が存在している限り、ミュート設定は引き続き有効です。 プレイヤーが退出し、同じユーザーが (新しい `IXIMPlayer` インスタンスとして) 再参加する場合は、保持されません。

プレイヤーは、通常、ミュートを解除した状態で開始します。 アプリがゲームプレイ上の理由から、ミュートした状態でプレイヤーを開始する場合は、関連付けられた `PlayerJoinedStateChange` の処理を終了する前に、`IXIMPlayer` オブジェクトに `IXIMPlayer.ChatMuted` を設定します。これにより、XIM では、無期限にプレイヤーから音声オーディオが聞こえなくなります。

リモート プレイヤーが XIM ネットワークに参加すると、プレイヤーの評判に基づいて、自動ミュート チェックが行われます。 プレイヤーに不適切な評判のフラグがある場合、プレイヤーは自動的にミュートされます。 ミュートは、ローカル状態にのみ影響を及ぼすため、プレイヤーがネットワーク間を移動する場合は変更されません。 評判ベースの自動ミュート チェックは 1 度のみ行われ、`IXIMPlayer` が有効である限り、再評価されることはありません。

## <a name="configuring-chat-targets-using-player-teams"></a>プレイヤーのチームを使ったチャット ターゲットの構成

このドキュメントの「[XIM とプレイヤー チームの連携について](#how-xim-works-with-player-teams)」で説明したように、特定のチーム インデックス値の本当の意味はアプリ次第です。 チャット ターゲット構成の同等比較に使用する場合を除き、XIM によるチーム インデックス値の解釈は行われません。 `XboxIntegratedMultiplayer.ChatTargets` で報告されたチャット ターゲット構成が現在 `XimChatTargets.SameTeamIndexOnly` であれば、プレイヤーが相手とチャット通信を行うのは、`IXIMPlayer.TeamIndex` で報告された同一値が両者に設定されている (加えて、プライバシー/ポリシーで許可される) 場合のみです。

競争力のあるシナリオを堅実にサポートするために、新しく作成された XIM ネットワークは既定値が `XimChatTargets.SameTeamIndexOnly` になるように自動的に構成されます。 ただし、対戦後の "ロビー" などで、負けた相手チームとのチャットが望まれることもあります。 (プライバシーやポリシーで許可されていれば) すべてのユーザーがほかのすべてのユーザーと対話できるように XIM を設定するには、`XboxIntegratedMultiplayer.SetChatTargets()` を呼び出します。 以下のサンプルでは、`XimChatTargets.AllPlayers` 値が使用されるように、XIM ネットワーク内のすべての参加者を設定します。

```cs
XboxIntegratedMultiplayer.SetChatTargets(XimChatTargets.AllPlayers)
```

新しいターゲット設定が有効になった場合、すべての参加者は、`XimChatTargetsChangedStateChange` を受信することで通知されます。

前述のように、XIM ネットワークのほとんどの移動タイプで、最初はインデックス値 0 がすべてのプレイヤーに割り当てられます。 これは、既定では `XimChatTargets.SameTeamIndexOnly` の設定を `XimChatTargets.AllPlayers` と区別できない可能性が高いことを意味します。 ただし、マッチメイキング構成の `TeamMatchmakingMode` 値で 2 つ以上のチームが宣言されている場合、マッチメイキングを使用して XIM ネットワークに移動するプレイヤーには異なるチーム インデックス値が設定されます。 また、`XimLocalPlayer.SetTeamIndex()` は、上記のようにいつでも呼び出すことができます。 アプリでこれらのメソッドのいずれかを使用して、0 以外のチーム インデックス値を使用している場合は、必ずチャットのターゲット設定を適切に管理してください。

## <a name="automatic-background-filling-of-player-slots-backfill-matchmaking"></a>プレイヤー スロットの自動バックグラウンド設定 ("バックフィル" マッチメイキング)

異なるプレイヤー グループが同時に `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を呼び出すことで、Xbox Live マッチメイキング サービスで新しく最適な XIM ネットワークをすばやく構成するための柔軟性が最大になります。 ただし、ゲームプレイ シナリオによっては、特定の XIM ネットワークが変更されない状態で維持する必要があり、追加プレイヤーのマッチメイキングが行われるのは空いているプレイヤー スロットを満たす場合のみというケースもあります。 XIM では、`XboxIntegratedMultiplayer.SetNetworkConfiguration()` を呼び出して、`XimNetworkConfiguration` の `XimNetworkConfiguration.AllowedPlayerJoins` プロパティで `XimAllowedPlayerJoins.Matchmade` フラグを設定することで、自動バックグラウンド設定モードで動作するマッチメイキングの構成 ("バックフィリング") もサポートされます。

以下の例では、バックフィル マッチメイキングを構成して、no-teams free-for-all 用に合計 8 人のプレイヤーを探します (8 人見つからない場合は、2 ～ 7 人でも許容可能)。このとき、MYGAMEMODE_DEATHMATCH の値 (この値は、同一値を指定した他のプレイヤーのみと一致します) で定義されるアプリ固有のゲーム モード定数 uint64_t を使用します。

```cs
var networkConfiguration = new XimNetworkConfiguration(XboxIntegratedMultiplayer.NetworkConfiguration);
networkConfiguration.AllowedPlayerJoins |= XimAllowedPlayerJoins.Matchmade;
networkConfiguration.TeamConfiguration.TeamCount = 1;
networkConfiguration.TeamConfiguration.MinPlayerCountPerTeam = 2;
networkConfiguration.TeamConfiguration.MaxPlayerCountPerTeam = 8;
networkConfiguration.CustomGameMode = MYGAMEMODE_DEATHMATCH;
XboxIntegratedMultiplayer.SetNetworkConfiguration(networkConfiguration);
```

これにより、通常の方法で `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を呼び出すデバイスが既存の XIM ネットワークを利用できるようになります。 これらのデバイスでは、動作の変更がありません。 バックフィリング中の XIM ネットワークにいる参加者は移動できませんが、これらの参加者には、バックフィルが有効になったことを表す <`XimNetworkConfigurationChangedStateChange` や複数の `XimMatchmakingProgressUpdatedStateChange` 通知 (該当する場合) が送信されます。 マッチメイキングで見つかったプレイヤーは、通常の `XimPlayerJoinedStateChange` を使用して XIM ネットワークに追加されます。

既定では、バックフィル マッチメイキングは無期限に有効になります (XIM ネットワークで既に最大プレイヤー数が `XimNetworkConfiguration.TeamConfiguration` 設定で指定されている場合はプレイヤーが追加されることはありません)。 バックフィルは、`XimNetworkConfiguration.AllowedPlayerJoins` が `XimAllowedPlayerJoins.Matchmade` を含まないように設定することで無効にすることができます。

```cs
var networkConfiguration = new XimNetworkConfiguration(XboxIntegratedMultiplayer.NetworkConfiguration);
networkConfiguration.AllowedPlayerJoins &= ~XimAllowedPlayerJoins.Matchmade;
XboxIntegratedMultiplayer.SetNetworkConfiguration(networkConfiguration);
```

対応する `XimNetworkConfigurationChangedStateChange` がすべてのデバイスに送信され、この非同期処理が完了すると、マッチメイキングされたプレイヤーがこれ以上 XIM ネットワークに追加されないことを表す `MatchmakingStatus.None` で最終的な `XimMatchmakingProgressUpdatedStateChange` が送信されます。

2 つ以上のチームを宣言する `XimNetworkConfiguration.TeamConfiguration` 設定を使用してバックフィル マッチメイキングを有効にする場合、既存のすべてのプレイヤーに有効なチームインデックス値 (1 ～チーム数) が必要になります。 これには、`XimLocalPlayer.SetTeamIndex()` を呼び出してカスタム値を指定したプレイヤーや、招待または他のソーシャルな手段 (例: `XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableXboxUserId()` の呼び出し) によって参加して既定のインデックス値 0 が追加されたプレイヤーも含まれます。 有効なチームインデックス値を持つプレイヤーがいない場合、マッチメイキング処理は保留され、`MatchmakingStatus.WaitingForPlayerTeamIndex` 値が指定された `XimMatchmakingProgressUpdatedStateChange` がすべての参加者に送信されます。 すべてのプレイヤーについて、`XimLocalPlayer.SetTeamIndex()` でチーム インデックス値が指定または修正されると、バックフィル マッチメイキングが再開されます。 詳しくは、このドキュメントの「[XIM とプレイヤー チームの連携について](#how-xim-works-with-player-teams)」をご覧ください。

同様に、`RequirePlayerRolesAndSkillConfiguration` フィールド true に設定されている `XimNetworkConfiguration` 構造体を使用してバックフィル マッチメイキングを有効にする場合、すべてのプレイヤーについて、プレイヤーごとのマッチメイキング構成が null 以外に指定されている必要があります。 これが行われていないプレイヤーがいる場合、マッチメイキング処理は一時停止され、`XimMatchMakingStatus.WaitingForPlayerRolesAndSkillConfiguration` 値が指定された `XimMatchmakingProgressUpdatedStateChange` がすべての参加者に送信されます。 すべてのプレイヤーが `XimPlayerRolesAndSkillConfiguration` オブジェクトを送信した時点で、バックフィル マッチメイキングが再開されます。 詳しくは、このドキュメントの「[プレイヤーごとのスキルによるマッチメイキング](#matchmaking-using-per-player-skill)」と「[プレイヤーごとのロールによるマッチメイキング](#matchmaking-using-per-player-role)」をご覧ください。

## <a name="querying-joinable-networks"></a>参加可能なネットワークの照会

マッチメイキングは、プレイヤーをまとめて簡単に接続する優れた方法ですが、プレイヤーが独自の検索条件を使用して参加可能なネットワークを検出し、参加するネットワークを選択することを許可した方がよい場合もあります。 これは、ゲーム セッションの構成可能なゲーム ルールとプレイヤーの基本設定のセットが大規模である場合に特に便利です。 これを行うには、まず既存のネットワークを照会可能にする必要があります。そのために、参加可能性 `XimAllowedPlayerJoins.Queried` を有効にし、`XboxIntegratedMultiplayer.SetNetworkConfiguration()` の呼び出しによってネットワーク外部の他のユーザーがネットワーク情報を利用できるように構成します。

次の例では、`XimAllowedPlayerJoins.Queried` の参加可能性を有効にして、ネットワーク構成を設定します。このネットワーク構成では、合計 1 ～ 8 人のプレイヤーを 1 チームにまとめることができるチーム構成、値 GAME_MODE_BRAWL によって定義されるアプリ固有のゲーム モード定数 uint64_t、"cat and sheep's boxing match" という説明、値 MAP_KITCHEN によって定義されるアプリ固有のマップ インデックス定数 uint32_t が指定され、および "chatrequired"、"easy"、"spectatorallowed" というタグが含まれています。

```cs
string[] tags = { "chatrequired", "easy", "spectatorallowed" };
var networkConfiguration = new XimNetworkConfiguration(XboxIntegratedMultiplayer.NetworkConfiguration);
networkConfiguration.AllowedPlayerJoins |= XimAllowedPlayerJoins.Queried;
networkConfiguration.TeamConfiguration.TeamCount = 1;
networkConfiguration.TeamConfiguration.MinPlayerCountPerTeam = 1;
networkConfiguration.TeamConfiguration.MaxPlayerCountPerTeam = 8;
networkConfiguration.CustomGameMode = GAME_MODE_BRAWL;
networkConfiguration.Description = "Cat and sheep's boxing match";
networkConfiguration.MapIndex = MAP_KITCHEN;
networkConfiguration.SetTags(tags);
XboxIntegratedMultiplayer.SetNetworkConfiguration(networkConfiguration);
```

ネットワーク外部の他のプレイヤーは、前の xim::set_network_configuration() の呼び出しで取得したネットワーク情報に一致するフィルターのセットを使用して xim::start_joinable_network_query() を呼び出すことにより、このネットワークを検出できます。 次の例では、GAME_MODE_BRAWL 値によって定義されたアプリ固有のゲーム モードを使用するネットワークのみを照会する、ゲーム モード フィルター オプションを使用して、参加可能なネットワークのクエリを開始します。

```cs
XimJoinableNetworkQueryFilters queryFilters = new XimJoinableNetworkQueryFilters();
queryFilters.CustomGameModeFilter = GAME_MODE_BRAWL;
XboxIntegratedMultiplayer.StartJoinableNetworkQuery(queryFilters);
```

次に示す別の例では、タグ フィルター オプションを使用して、一般にクエリ可能な構成で "easy" と "spectatorallowed" というタグが設定されているネットワークのクエリを実行します。

```cs
string[] tagFilters = { "easy", "spectatorallowed" };
XimJoinableNetworkQueryFilters queryFilters = new XimJoinableNetworkQueryFilters();
queryFilters.SetTagFilters(tagFilters);
XboxIntegratedMultiplayer.StartJoinableNetworkQuery(queryFilters);
```

複数のフィルター オプションを組み合わせることもできます。 次の例では、ゲーム モード フィルター オプションとタグ フィルター オプションの両方を使用して、アプリ固有のゲーム モード定数 GAME_MODE_BRAWL とタグ "easy" の両方を含むネットワークのクエリを開始します。

```cs
string[] tagFilters = { "easy" };
XimJoinableNetworkQueryFilters queryFilters = new XimJoinableNetworkQueryFilters();
queryFilters.CustomGameModeFilter = GAME_MODE_BRAWL;
queryFilters.SetTagFilters(tagFilters);
XboxIntegratedMultiplayer.StartJoinableNetworkQuery(queryFilters);
```

クエリの操作が成功すると、アプリは xim_start_joinable_network_query_completed_state_change を受け取り、そこから参加可能なネットワークの一覧を取得できます。 アプリは、手動または自動で停止されるまで、他の参加可能なネットワークと、返された参加可能なネットワークの一覧に加えられた変更を示す `XimJoinableNetworkUpdatedStateChange` を継続的に受け取ります。 進行中のクエリは、`XboxIntegratedMultiplayer.StopJoinableNetworkQuery()` を呼び出すことによって手動で停止できます。 クエリは、`XboxIntegratedMultiplayer.StartJoinableNetworkQuery()` を呼び出して新しいクエリを開始すると、自動的に停止します。

アプリは、`XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableNetworkInformation()` を呼び出すことによって、参加可能なネットワークの一覧にあるネットワークへの参加を試行することができます。 次の例では、'selectedNetwork' で参照された、パスコードでセキュリティが保護されていない (そのため、2 番目のパラメーターで空の文字列を渡している) ネットワークに参加しようとしていると仮定しています。

```cs
XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableNetworkInformation(selectedNetwork, "");
```

2 つ以上のチームを宣言する `XimNetworkConfiguration.TeamConfiguration` を使用してネットワークのクエリを有効にすると、XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableNetworkInformation() を呼び出すことによって参加したプレイヤーの既定のチーム インデックス値は 0 になります。