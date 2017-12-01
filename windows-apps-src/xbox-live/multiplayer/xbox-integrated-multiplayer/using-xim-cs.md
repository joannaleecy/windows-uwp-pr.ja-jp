---
title: "XIM (C#) の使用"
author: KevinAsgari
description: "C# で Xbox Integrated Multiplayer (XIM) を使用する方法について説明します。"
ms.author: kevinasg
ms.date: 09/22/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One"
ms.openlocfilehash: 366701c5b68a48a88e50df60a9a6daf27e200566
ms.sourcegitcommit: 7f34dc774e192caf406d5d556bbc66a343d91638
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2017
---
# <a name="using-xim-c"></a>XIM (C#) の使用

> [!div class="op_single_selector" title1="Language"]
> - [C++](using-xim.md)
> - [C#](using-xim-cs.md)

ここでは、XIM の C# API の使用方法について概要を紹介します。 ゲーム開発者が C++ 経由で XIM にアクセスする場合は、「[XIM (C++) の使用](using-xim.md)」をご覧ください。

1. [前提条件](#prereq)
2. [初期化および起動](#init)
3. [非同期操作および状態変更の処理](#async)
4. [xim_player の基本的な処理](#player)
5. [フレンド参加の有効化とフレンドの招待](#invites)
6. [メッセージの送信と受信](#send)
7. [マッチメイキングの概要および別の XIM ネットワークへの移動](#basicmatch)
8. [XIM ネットワークの退出およびクリーンアップ](#leave)
9. [チャットの操作](#chat)
10. [カスタム プレイヤーおよびネットワーク プロパティの設定](#properties)
11. [プレイヤーごとのスキルまたはロールによるマッチメイキング](#roles)
12. [プレイヤーのチームおよびチャット ターゲットの設定](#teams)
13. [プレイヤー スロットの自動バックグラウンド設定 ("バックフィル" マッチメイキング)](#backfill)

## <a name="prerequisites-a-nameprereq"></a>前提条件<a name="prereq">

XIM のコーディングを始めるには、2 つの前提条件があります。 まず、標準のマルチプレイヤー ネットワーキング機能を使用してアプリの AppXManifest を設定し、その "ネットワーク マニフェスト" を構成して、XIM で使用するのに必要なトラフィック パターン テンプレートを宣言する必要があります。

> AppXManifest 機能およびネットワーク マニフェストについては、プラットフォームのドキュメントの各セクションで詳しく説明されています。また、貼り付ける XIM 固有の XML は、「[XIM プロジェクト構成](xim-manifest.md)」で確認できます。

次に、割り当て済みの Xbox Live タイトル ID と、サービス構成 ID の 2 つのアプリケーション ID 情報を使用できるようにする必要があります。これらは、Xbox Live サービスにアクセスするためにアプリケーションのプロビジョニングの一部として提供されます。 これらの取得に関する詳細については、マイクロソフトの担当者にお問い合わせください。 これらの情報は、初期化時に使用されます。

## <a name="initialization-and-startup-a-nameinit"></a>初期化および起動 <a name="init">


ライブラリーの操作を開始するには、Xbox Live サービス構成 ID の文字列とタイトル ID 番号を使用して XIM の静的クラスのプロパティを初期化します。 次の例では、これらの値はそれぞれ "myServiceConfigurationId" および "myTitleId" 変数に既に存在するものと想定しています。

```cs
XboxIntegratedMultiplayer.ServiceConfigurationId = myServiceConfigurationId;
XboxIntegratedMultiplayer.TitleId = myTitleId;
```

初期化した後は、参加するローカル デバイスに現在存在しているすべてのユーザーの Xbox ユーザー ID 文字列をアプリで取得し、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` の呼び出しに渡す必要があります。 次のサンプル コードでは、1 人のユーザーがコントローラーのボタンを押してプレイする意図を示し、そのユーザーに関連付けられた Xbox ユーザー ID 文字列は "myXuid" 変数に既に取得されているものとします。

```cs
XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds(new List<string>() { myXuid });
```

`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` を呼び出すとすぐに、XIM ネットワークに追加する必要のあるローカル ユーザーに関連付けられている Xbox ユーザー ID が設定されます。 この Xbox ユーザー ID のリストは、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds()` の別の呼び出しによってリストが変更されるまで、以降のすべてのネットワーク操作で使用されます。


この例では、XIM ネットワークはまだ存在していないため、XIM ネットワークへの移動を開始してプロセスを開始する必要があります。 ユーザーが特定の XIM ネットワークをまだ想定していない場合のベスト プラクティスは、単に、新しい空のネットワークに移動することです。そのネットワークは、ユーザーのフレンドの参加を許可することで、次のマルチプレイヤー アクティビティ (一緒にマッチメイキングに入る、など) を共同で選択できる一種の "ロビー" になります。 次に、以前に追加したローカル ユーザーのみが最大で 8 プレイヤーが参加できる空の XIM ネットワークに移動を開始する例を示します。


```cs
XboxIntegratedMultiplayer.MovetoNewNetwork(8, XimPlayersToMove.BringOnlyLocalPlayers);
```
非同期の移動操作が開始し、最終的な結果は状態変化を定期的に処理することで確認できます。

## <a name="asynchronous-operations-and-processing-state-changes-a-nameasync"></a>非同期操作および状態変更の処理 <a name="async">

XIM の中核的な動作は、アプリによる `XboxIntegratedMultiplayer.GetStateChanges()` メソッドの定期的かつ頻繁な呼び出しです。 これらのメソッドを使用して、XIM はアプリがマルチプレイヤーの状態の更新を処理する準備ができた通知を受け取り、キューに入っているすべての更新が含まれた `XimStateChangeCollection` オブジェクトを返してそれらの更新を提供します。 `XboxIntegratedMultiplayer.GetStateChanges()`  は、UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。 XIM API はこのシングルスレッド パターンに最適化されており、`XimStateChangeCollection` オブジェクトが処理される間、このオブジェクトが破棄されない限り、このパターンの状態が変化しないことを保証します。

`XimStateChangeCollection` は、`IXimStateChange` オブジェクトのコレクションです。 アプリでは、配列を反復処理し、より具体的な型の `IXimStateChange` を検査して、`IXimStateChange` 型を対応する詳細な型にキャストしてから、その更新を適切に処理する必要があります。 現在使用可能なすべての `IXimStateChange` オブジェクトが終了した後は、`XimStateChangeCollection.Dispose()` を呼び出すことによってその配列を XIM に戻してリソースを解放する必要があります。 処理が終わった後のリソースが確実に破棄されるように、`using` ステートメントを使用することをお勧めします。 次に、例を示します。

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

これで基本的な処理ループができたので、`XboxIntegratedMultiplayer.MoveToNewNetwork()` の初期操作に関連する状態変化を処理できます。 すべての XIM ネットワーク移動操作は、`XimMoveToNetworkStartingStateChange` で開始します。 何らかの理由で移動が失敗した場合、アプリは `XimNetworkExitedStateChange` を受け取ります。これは、タイトルが XIM ネットワークに移動しないようにする、または現在の XIM ネットワークからタイトルを切断する、非同期重大エラーに対する共通のエラー処理メカニズムです。 移動が成功した場合は、すべての状態が終了され、すべてのプレイヤーが XIM ネットワークに正常に追加された後、移動は `XimMoveToNetworkSucceededStateChange` で完了します。


## <a name="basic-iximplayer-handling-a-nameplayer"></a>IXimPlayer の基本的な処理 <a name="player">

1 人のローカル ユーザーを新しい XIM ネットワークに移動する例が成功したとすると、アプリはローカル `XimLocalPlayer` オブジェクトの `XimPlayerJoinedStateChange` も提供されています。 このオブジェクトは、対応する `XimPlayerLeftStateChange` が提供され、`XimStateChangeCollection.Dispose()` を介して返されるまで、有効な状態が維持されます。 アプリはすべての `XimPlayerLeftStateChange` に対して常に `XimPlayerJoinedStateChange` を提供されます。 `XboxIntegratedMultiplayer.GetPlayers()` を使用することで、いつでも XIM ネットワークのすべての `IXimPlayer` オブジェクトの一覧を取得することもできます。

`IXimPlayer` オブジェクトには、多くの役に立つプロパティとメソッドがあります。たとえば、`IXimPlayer.Gamertag()` は、プレイヤーに関連付けられている現在の Xbox Live ゲーマータグ文字列を表示用に取得します。 `IXimPlayer`がデバイスに対してローカルである場合、IXimPlayer.Local は true を返します。 ローカルの `IXimPlayer` は、ローカル プレイヤーだけが使用できる追加のメソッドを持つ `XimLocalPlayer` にキャストできます。

もちろん、プレイヤーにとって最も重要な状態は XIM が知っている共通の情報ではなく、特定のアプリで追跡する必要のある情報であり、それに対しては独自のオブジェクトがある可能性があるため、`IXimPlayer` オブジェクトをそれにリンクして、XIM が `IXimPlayer` を報告するときはいつでも、カスタム プレイヤー コンテキスト オブジェクトを設定して検索を実行することなく状態をすばやく取得できます。 次の例では、プライベート状態が入ったオブジェクトが変数 "myPlayerStateObject" 内にあり、新しく追加される `IXimPlayer` オブジェクトが変数 "newXimPlayer" 内にあるものとします。

```cs
newXimPlayer.CustomPlayerContext = myPlayerStateObject;
```

これは、指定されたオブジェクトをプレイヤー オブジェクトでローカルに保存します (メモリが有効でないときにリモート デバイスにネットワーク経由で転送されることはありません)。 その後は、カスタム コンテキストを取得して、次の例のようにオブジェクトにキャストすることによって、いつでもオブジェクトに戻ることができます。

```cs
myPlayerStateObject = (MyPlayerState)(newXimPlayer.CustomPlayerContext);
```

このカスタム プレイヤー コンテキストはいつでも変更できます。
この基本プレイヤー処理により、ローカル ユーザーとの既存のソーシャル関係を通してリモート ユーザーがこの XIM ネットワークに参加できるようにすることができます。

## <a name="enabling-friends-to-join-and-inviting-thema-nameinvites"></a>フレンド参加の有効化とフレンドの招待<a name="invites">

プライバシーとセキュリティのため、すべての新しい XIM ネットワークは既定では追加プレイヤーが参加できないように自動的に構成されるので、アプリ側で明示的に許可する必要があります。 次の例では、`XboxIntegratedMultiplayer.SetAllowedPlayerJoins()` を使用して、プレイヤーとして参加する新しいローカル ユーザー、および招待されている、または "フォロー" されている (Xbox Live ソーシャル関係) ユーザーの許可を開始する方法を示します。

```cs
XboxIntegratedMultiplayer.SetAllowedPlayerJoins(XimAllowedPlayerJoins.LocalInvitedOrFollowed);
```

これは非同期的に発生します。 完了すると、`XimAllowedPlayerJoinsChangedStateChange` が提供され、値が既定値の `XimAllowedPlayerJoins.None` から変化したことが通知されます。 新しい値は、`XboxIntegratedMultiplayer.AllowedPlayerJoins` を使用して照会できます。

ローカル プレイヤーはこの XIM ネットワークに参加するようリモート ユーザーに招待を送信できるようになります。 これは、`XimLocalPlayer.ShowInviteUI()` を呼び出してシステム招待 UI を起動し、ローカル ユーザーがユーザーを選択して招待を送信できるように構成することで実現されます。

システム招待 UI が表示され、ユーザーが招待を送信すると (またはそれ以外で UI を閉じると)、`XimShowUICompletedStateChange` が提供されます。 または、アプリは `XimLocalPlayer.InviteUsers()` を使って招待を直接送信できます。 どちらの方法でも、リモート ユーザーはサインインしている場所で Xbox Live 招待メッセージを受け取り、受け入れることができます。 これにより、まだ実行していない場合はデバイスでアプリが起動され、同じ XIM ネットワークに移動するために使用できるイベント引数で "プロトコルのアクティブ化" を行います。 アクティブ化自体について詳しくは、プラットフォームのドキュメントをご覧ください。 次の例では、イベント引数を取得し、`XboxIntegratedMultiplayer.ExtractProtocolActivationInformation()` を呼び出して XIM に適用可能かどうかを確認する方法を示します。未処理の URI 文字列を `Windows.ApplicationModel.Activation.ProtocolActivatedEventArgs` から変数 "uriString" に既に取得してあるものとします。

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

"フォローされている" リモート ユーザーはシステム UI でローカル ユーザーのプレイヤー カードに移動し、招待なしに自分だけで参加の試みを開始できることにも注意してください (前に示したように、そのようなプレイヤーの参加を許可してあるものとします)。 アプリでは招待の場合と同じようにプロトコルのアクティブ化が行され、異なる処理は必要ありません。

プロトコルのアクティブ化を使用した XIM ネットワークへの移動は、前述の手順で行った新しい XIM ネットワークへの移動と同じです。 唯一の違いは、移動が成功すると、移動中のデバイスによって、適用可能なプレイヤーを表すローカルとリモート両方のプレイヤーに `XimPlayerJoinedStateChange` オブジェクトが送信されることです。 また当然、既に XIM ネットワークに存在していたデバイスが移動することはありませんが、`XimPlayerJoinedStateChange` オブジェクトがさらに送信されると、新しいデバイスのユーザーがプレイヤーとして追加されます。


この時点で、音声通信およびテキスト チャット通信は、この XIM ネットワーク内の各デバイスのプレイヤー間で自動的に有効になっています。 これで、マルチプレイヤーおよび送信するアプリ固有メッセージの準備が整います。

## <a name="sending-and-receiving-messages-a-namesend"></a>メッセージの送信と受信 <a name="send">


XIM とその基になっているコンポーネントによって、インターネット経由で手間をかけずに安全な通信チャネルを確立することができるため、接続の問題や、一部のプレイヤーが受信できない可能性があることを心配する必要はありません。 ピア ツー ピア接続の基盤に問題がある場合、XIM ネットワークへの移動は成功しません。 問題がなければ、すべての `IXimPlayer` が、すべてのデバイスのアプリのすべてのインスタンスに通知され、どのデバイスにもメッセージを送信できるようになります。 次の例では、"sendingPlayer" 変数は有効なローカル プレイヤー オブジェクトであり、(特定のプレイヤーの一覧を渡さないことで) XIM ネットワークのすべてのプレイヤー (ローカルまたはリモート) に、保証されたシーケンシャル配信で、'msgBuffer' にコピーされたメッセージ構造体を送信するものとします。

```cs
SendingPlayer.SendDataToOtherPlayers(msgBuffer, null, XimSendType.GuaranteedAndSequential);
```

メッセージのすべての受信者には、データのコピー、メッセージを送信した `IXimPlayer` オブジェクト、メッセージをローカルに受信する `IXimPlayer` オブジェクトの一覧を含む `XimPlayertoPlayerDataReceivedStateChange` が提供されます。


もちろん保証されたシーケンシャル配信は便利ですが、インターネットでパケットがドロップされたりパケットの順序が正しくない場合は XIM は再送信または遅延する必要があるため、効率的ではない送信タイプでもあります。 アプリがパケットのドロップや順序の間違いを許容できるメッセージに対しては他の送信タイプの使用を検討してください。

メッセージ データはリモート コンピューターから送られてくるので、データ形式を明確に定義し (特定のバイト オーダー ("エンディアン") でマルチバイト値をパッキングするなど)、処理する前にデータを検証するのがベスト プラクティスです。 XIM はネットワーク レベルのセキュリティを提供しているため、暗号化や署名スキームを追加実装することはできませんが、アプリケーションのバグから保護したり、異なるバージョンのアプリケーション プロトコルに共存できるように、堅牢な "多重防御" を行うことは常に有益です (開発時や、コンテンツ更新時など)。



ユーザーのインターネット接続も、常に変わり続ける限られたリソースです。 必ず、有益なメッセージ データ形式を使用し、すべての UI フレームを送信するような設計にしないでください。 2 人のプレイヤー間における現在のパスの品質の詳細は、`XimPlayer.NetworkPathInformation` プロパティを検査して確認できます。 このプロパティには、予想される往復遅延時間に加え、接続上の理由から現時点で追加データを送信できないためにローカルのキューに入ったままのメッセージ数が含まれます。 キューがバックアップ中であると表示される場合は、データの送信速度を抑える必要があります。

返される構造体には、予想される往復遅延時間に加え、接続上の理由から現時点で追加データを送信できないためにローカルのキューに入ったままのメッセージ数が含まれます。

`NetworkPathInformation.RoundTripLatency` フィールドは、基盤のネットワークの待機時間と、キューを経由しない場合の XIM の推定待機時間を表します。 実際の遅延時間は、`XimNetworkPathInformation.SendQueueSizeInMessages` が大きくなり、XIM がキュー経由で動作するようになるにつれて増加します。

ゲームの使用状況と要件に基づいて、`SendDataToOtherPlayers` の呼び出しの調整を開始する適切なポイントを選択してください。 送信キューにメッセージがあるということは、実際のネットワーク待機時間が増えることを意味します。

XIM の上限 (現在は 3,500 件のメッセージ) に近い値は、ほとんどのゲームにとっては大きすぎ、`SendDataToOtherPlayers` の呼び出し頻度と各データ ペイロードの大きさに応じて、データが送信されるまでに数秒の待機時間が生じる可能性があります。 代わりに、ゲームの待機時間の要件と、ゲームでの `SendDataToOtherPlayers` の呼び出しパターンの頻度を合わせて考慮して、適切な数値を選択してください。


## <a name="basic-matchmaking-and-moving-to-another-xim-network-with-others-a-namebasicmatch"></a>マッチメイキングの概要および別の XIM ネットワークへの移動 <a name="basicmatch">

フレンドのグループのゲーム体験を拡張するには、Xbox Live マッチメイキング サービスを使用して、共通の関心に基づき、世界中の対戦相手がいる XIM ネットワークにプレイヤーを移動します。 最も基本的な方法は、データの設定された `MatchmakingConfiguration` オブジェクトを使用して、いずれかのデバイスで `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を呼び出し、現在の XIM ネットワークからプレイヤーを移動することです。 以下の例では、no-teams free-for-all 用に合計 8 人のプレイヤーを探すように構成されたマッチメイキング (8 人見つからない場合は、2 ～ 7 人でも許容) を使用して移動を開始します。このとき、MYGAMEMODE_DEATHMATCH の値 (この値は、同一値を指定した他のプレイヤーのみと一致します) で定義されるアプリ固有のゲームモード定数 uint を使用し、ソーシャルな方法で参加したすべてのプレイヤーを現在の XIM ネットワークから移動します。

```cs
XimMatchmakingConfiguration matchmakingConfiguration = new XimMatchmakingConfiguration()
{
    TeamMatchmakingMode = XimTeamMatchmakingMode.NoTeams8PlayersMinimum2;
    CustomGameMode = MYGAMEMODE_DEATHMATCH;
};

XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking(matchmakingConfiguration, XimPlayersToMove.BringExistingSocialPlayers);
```

前述の移動のように、これにより、すべてのデバイスに最初の `MoveToNetworkStartingStateChange` が送信され、成功すると、`MoveToNetworkSucceededStateChange` が送信されます。 この場合は XIM ネットワーク間で移動するため、ローカルユーザーおよびリモートユーザー向けに追加された既存の `IXimPlayer` オブジェクトが存在している点が異なり、このオブジェクトはすべてのプレイヤーを新しい XIM ネットワークにまとめて移動するために保持されます。 マッチメイキングの進行中 (`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` とも呼ばれるマッチメイキング プールのプレイヤー数によって時間がかかる場合がある)、このネットワーク間のチャットおよびデータ通信は、中断されることなく引き続き使用できます。 ユーザーに現在のステータスを通知し続けるために、`XimMatchmakingProgressUpdatedStateChange` は、この操作が終わるまで定期的に送信されます。 一致すると、一般的な `PlayerJoinedStateChange` を使用してユーザーが XIM ネットワークに追加され、移動は完了します。

この "マッチメイキング型" プレイヤーのセットを使用したマルチプレイヤー体験が完了すると、他のマッチメイキングのラウンドを使用して他の XIM ネットワークに移動することができるこのプロセスを繰り返せるようになります。 `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` 操作を介して参加した各プレイヤーによって、同 XIM ネットワーク内に `IXimPlayer` オブジェクトが存在しないことを表す `PlayerLeftStateChange` が送信されます。また、新しいマッチメイキングが行われている間、ソーシャル機能 `XboxIntegratedMultiplayer.MoveToNetworkUsingProtocolActivatedEventArgs()` または `XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableXboxUserId` を介して参加したプレイヤーのみ残ります  (再度 `XimPlayersToMove.BringExistingSocialPlayers` を指定した場合。`XimPlayersToMove.BringOnlyLocalPlayers` を指定した場合はリモート プレイヤーからも切断され、ローカル プレイヤーのみが残ります)。 2 回目の移動操作が完了すると、別の見知らぬユーザーの集合が追加されます。

または、マッチメイキング型でないプレイヤー (またはローカル プレイヤー) のみ新しい XIM ネットワークに完全に移動してから、次のマッチメイキング構成/マルチプレイヤー アクティビティを決めることができます。 次の例では、XIM ネットワークに最大 8 人のプレイヤーを集めるために、再度デバイスの呼び出し `XboxIntegratedMultiplayer.MoveToNewNetwork()` を行います。ただし、今回はソーシャル機能を使用して参加した既存プレイヤーも移動します。

```cs
XboxIntegratedMultiplayer.MovetoNewNetwork(8, XimPlayersToMove.BringExistingSocialPlayers);
```

参加中のすべてのデバイスに、`MoveToNetworkStartingStateChange` および `MoveToNetworkSucceededStateChange` が送信され、加えてマッチメイキング型の残ったプレイヤーには `PlayerLeftStateChange` が送信されます (同様に、移動中の各プレイヤーのデバイスにも、`PlayerLeftStateChange` が送信されます)。

この方法で、必要な回数だけマッチメイキングを使用して (または使用せずに)、引き続き XIM ネットワーク間で移動できます。

パフォーマンス上、Xbox Live サービスは、直接ピア ツー ピア接続を確立できないデバイス上でプレイヤーのグループのマッチングを試行することはありません。 標準の Xbox Live マルチプレイヤーをサポートするように適切に構成されていないネットワーク環境で開発している場合、マッチメイキング条件を満たし、同一のローカル環境にあるすべてのデバイスを移動中および使用中のプレイヤーが十分にいる場合でも、マッチメイキングが行われることなく、マッチメイキングを使用した新しいネットワークへの移動操作が無期限に続くことがあります。 必ずネットワーク設定領域/Xbox アプリケーションでマルチプレイヤーの接続テストを実行し、特に "Strict NAT" についての問題を報告する場合の推奨事項に従ってください。 ただし、ネットワーク管理者が環境に必要な変更を行うことができない場合は、Xbox One 開発キットでテストのブロックを解除できます。そのためには、"Open NAT" デバイスを 一切指定せずに "ストリクト NAT" デバイスをマッチングできるように XIM を構成します。 これを行うには、すべての Xbox One 本体上の "title scratch" ドライブのルートに "xim_disable_matchmaking_nat_rule" と呼ばれるファイル (内容は問いません) を配置します。 配置する方法のひとつとして、アプリを起動する前に XDK コマンド プロンプトから以下を実行し、プレースホルダー "{console_name_or_ip_address}" を適宜各コンソールに置き換える方法があります。

```bat

echo.>%TEMP%\emptyfile.txt
copy %TEMP%\emptyfile.txt \\{console_name_or_ip_address}\TitleScratch\xim_disable_matchmaking_nat_rule
del %TEMP%\emptyfile.txt

```

この開発上の回避策は、現在 Xbox One 排他リソース アプリケーションでのみ使用することができ、ユニバーサル Windows アプリで使用することはできません。 また、コンソールでこの設定を使用している場合は、ネットワーク環境にかかわらず、ファイルが存在しないデバイスにマッチングすることはないため、ファイルは、あらゆる場所で追加または削除することができます。

## <a name="leaving-a-xim-network-and-cleaning-up-a-nameleave"></a>XIM ネットワークの退出およびクリーンアップ <a name="leave">
ローカル ユーザーが XIM ネットワークに参加している場合、新しい XIM ネットワークに戻るだけで、ローカル ユーザー、招待ユーザー、"フォローされている" ユーザーはその XIM ネットワークに参加できるため、引き続きフレンドと協力して次のアクティビティに進むことができます。 しかし、ユーザーがすべてのマルチプレイヤー エクスペリエンスを完全に完了している場合、アプリは、XIM ネットワークからの撤退を開始して、`XboxIntegratedMultiplayer.SetIntendedLocalXboxUserIds` のみが呼び出された場合と同様の状態に戻る場合があります。 この処理を実行するには、`XboxIntegratedMultiplayer.LeaveNetwork()` メソッドを使います。

```cs
 XboxIntegratedMultiplayer.LeaveNetwork();
```

このメソッドでは、他の参加者から非同期的に切断するプロセスを正常に開始します。 これにより、リモート デバイスに対してローカル プレイヤーの `PlayerLeftStateChange`、ローカルデバイスに対してローカルまたはリモートの各プレイヤーの `PlayerLeftStateChange` が送られます。 すべての接続操作が完了すると、最後に `NetworkExitedStateChange` が送信されます。

`NetworkExitedStateChange` がまだ送信されていない場合は、`XboxIntegratedMultiplayer.LeaveNetwork()` を呼び出し、`NetworkExitedStateChange` を待機して、XIM ネットワークを正常終了することを強くお勧めします。

## <a name="working-with-chat-a-namechat"></a>チャットの操作 <a name="chat">
XIM ネットワーク内のプレイヤー間の音声およびテキスト チャット通信は、自動的に有効になります。 XIM は、すべての音声ヘッドセットとマイクのハードウェアとの通信を操作します。 チャットを使用するために必要な設定はアプリにありませんが、テキスト チャットに関する要件が 1 つあります。入力および表示をサポートしていることです。 テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、プレイヤーはこのシステムで、音声合成の支援技術を使用する場合があるためです。 同様に、プレイヤーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。 ローカル プレイヤーのこれらの設定を検出するには、`XimLocalPlayer.ChatTextToSpeechConversionPreferenceEnabled` フィールドと `XimLocalPlayer.ChatSpeechToTextConversionPreferenceEnabled` フィールドにそれぞれアクセスします。必要に応じて、テキストのメカニズムを有効にすることもできます。 ただし、テキスト入力および表示オプションを常に有効にすることを検討してください。


> `Windows::Xbox::UI::Accessability` は、テキストから音声の変換支援技術を搭載したゲーム内のテキストチャットを単純にレンダリングできるように特別に設計された Xbox One のクラスです。

現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `XimLocalPlayer.SendChatText()` メソッドに渡します。 以下のコードは、'localPlayer' 変数によって指定されたローカルの `IXIMPlayer` オブジェクトからハード コードされたサンプル文字列の送信を示します。

```cs
localPlayer.SendChatText(text);
```

このチャット テキストは、発信元のローカル プレイヤーからチャット通信を受信できる、XIM ネットワーク内のすべてのプレイヤーに送信されます。 また、音声に合成され、`XimChatTextReceivedStateChange` として送信されることもあります。 アプリは、受け取ったテキスト文字列のコピーを作成し、発信元プレイヤーの ID の一部と共に、適切な長さの時間 (またはスクロール可能なウインドウで) 表示する必要があります。

チャットに関するベスト プラクティスは他にもいくつかあります。 特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。 これを行うには、`IXimPlayer.ChatIndicator` にアクセスし、プレイヤーのチャットの現在の瞬間的なステータスを表す `XboxIntegratedMultiplayer.XimPlayerChatIndicator` を取得します。

`IXimPlayer.ChatIndicator` によって報告される値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。 そのため、すべての UI フレームをポーリングできるように設計されています。

もう 1 つのベスト プラクティスは、プレイヤーをミュートできるようにすることです。 XIM では、ユーザーはプレイヤー カードを使用してシステムを自動的にミュートできますが、`IXimPlayer.ChatMuted` プロパティを経由してゲーム UI 内で実行されるゲーム固有の一時的なミュートをアプリでもサポートしている必要があります。 以下の例では、'remotePlayer 変数でリモートの `IXIMPlayer` オブジェクトを指定し、ミュートを開始します。これにより、ボイス チャットが聞こえず、テキスト チャットを受け取らない状態になります。

```cs
remotePlayer.ChatMuted = true;
```

ミュートは、すぐに適用され、XIM の状態変更とは関連付けられません。
そのプレイヤーで新しい XIM ネットワークに移動する場合など、`IXIMPlayer` が存在している限り、ミュート設定は引き続き有効です。 プレイヤーが退出し、同じユーザーが (新しい `IXIMPlayer` インスタンスとして) 再参加する場合は、保持されません。

プレイヤーは、通常、ミュートを解除した状態で開始します。 アプリがゲームプレイ上の理由から、ミュートした状態でプレイヤーを開始する場合は、関連付けられた `PlayerJoinedStateChange` の処理を終了する前に、`IXIMPlayer` オブジェクトに `IXIMPlayer.ChatMuted` を設定します。これにより、XIM では、無期限にプレイヤーから音声オーディオが聞こえなくなります。

リモート プレイヤーが XIM ネットワークに参加すると、プレイヤーの評判に基づいて、自動ミュート チェックが行われます。 プレイヤーに不適切な評判のフラグがある場合、プレイヤーは自動的にミュートされます。 ミュートは、ローカル状態にのみ影響を及ぼすため、プレイヤーがネットワーク間を移動する場合は変更されません。 評判ベースの自動ミュート チェックは 1 度のみ行われ、`IXIMPlayer` が有効である限り、再評価されることはありません。

## <a name="configuring-custom-player-and-network-properties-a-nameproperties"></a>カスタム プレイヤーおよびネットワーク プロパティの設定 <a name="properties">
メソッドの受信者や、そのメソッドでパケットの損失などを処理する日時や方法を大部分コントロールできるため、ほとんどのアプリにおいて、データ交換には `XimLocalPlayer.SendDataToOtherPlayers()` メソッドが使用されます。 ただし、プレイヤーにとっては、基本的でまれな変更ステータスを最小限の手間で他者と共有した方が好都合である場合があります。 たとえば、すべてのプレイヤーがゲーム内の表現をレンダリングするために使用するマルチプレイヤーを入力する前に選択したキャラクター モデルを表す文字列は、各プレイヤーによって変更される場合があります。 XIM では、便利な "カスタム プレイヤー プロパティ" 機能が提供されています。この機能では、アプリ定義の名前と値による NULL 終了の文字列ペアをローカル プレイヤーに適用し、これらが変更されると自動的にすべてのデバイスに伝達できます。 XIM ネットワークに参加し、追加したプレイヤーが表示されると、現在の値も自動的に、新しく追加したデバイスに適用されます。 これらを設定するには、'localPlayer' 変数によって指定されるローカルの `IXIMPlayer` オブジェクトに値 "brute" を含めるように "model" という名前のプロパティを設定し、名前と値の文字列を使用して、`XimLocalPlayer.SetPlayerCustomProperty()` を呼び出します。

```cs
localPlayer.SetPlayerCustomProperty("model","brute");
```

プレイヤーのプロパティを変更すると、`XimPlayerCustomPropertiesChangedStateChange` がすべてのデバイスに送信され、変更されているプロパティの名前に警告が通知されます。 指定された名前の値は、`IXIMPlayer.GetPlayerCustomProperty()` を使用して、ローカルまたはリモートで、どのプレイヤーも取得することができます。 以下の例は、'ximPlayer' 変数で指定された `IXIMPlayer` から、"model" という名前のプロパティの値を取得しています。

```cs
string propertyValue = localPlayer.GetPlayerCustomProperty("model");
```

指定のプロパティ名に新しい値を設定すると、既存の値は置き換えられ、null 値の文字列ポインターは、空の値文字列と同様に処理されます。つまり、まだ指定されていないプロパティと同様です。 それ以外の場合、名前および値は、XIM で解釈されません。必要に応じて文字列の内容を検証するアプリによって異なります。

この便利な機能は、"カスタム ネットワーク プロパティ" を使用して、XIM ネットワーク全体で使用することもできます。 `XboxIntegratedMultiplayer.SetNetworkCustomProperty()` を使用して XIM シングルトン オブジェクトで設定されている場合を除き、カスタム ネットワーク プロパティと同様に使用できます。 以下の例では、値が "stronghold" になるように "map" プロパティを設定しています。

```cs
XboxIntegratedMultiplayer.SetNetworkCustomProperty("map", "stronghold");
```

ネットワークのプロパティを変更すると、`NetworkCustomPropertiesChanged` がすべてのデバイスに送信され、変更されているプロパティの名前に警告が通知されます。 指定した名前の値は、以下の例で "map" というプロパティの値を取得しているように、`XboxIntegratedMultiplayer.GetNetworkCustomProperty()` を使用して取得できます。

```
string property = XboxIntegratedMultiplayer.GetNetworkCustomProperty("map")
```
カスタム プレイヤーのプロパティと同じように、指定されたカスタム ネットワーク プロパティ名の値を設定すると、既存の値に置き換えられ、null 値、未設定値、またはクリアされた値は、常に非 null の空の文字列として処理されます。

ある XIM ネットワークから別の XIM ネットワークに移動すると、カスタム プレイヤー プロパティはリセットされ、新しく作成された XIM ネットワークは、常にプロパティが設定されていない状態で開始されます。 ただし、既存の XIM ネットワークに参加する新しいプレイヤーには、既存のプレイヤーおよび XIM ネットワーク自体に設定されているカスタム プロパティが表示されます。

プレイヤーおよびネットワークのカスタム プロパティは、頻繁に変化しない状態を補助するために使用します。 これらの内部的な同期オーバーヘッドは `XimLocalPlayer.SendDataToOtherPlayers()` メソッドより大きくなるため、プレイヤーの位置が高速で入れ替わるような状態では、直接送信を使用する必要があります。


## <a name="matchmaking-using-per-player-skill-or-role-a-nameroles"></a>プレイヤーごとのスキルまたはロールによるマッチメイキング <a name="roles">

固有のアプリ指定のゲーム モードの共通の関心を使用したプレイヤーのマッチングは、優れた基本戦略です。 利用可能なプレイヤーのプールが大きくなるにつれて、ベテラン プレイヤーが、他のベテランと正当な対戦を楽しめるように、ゲームの個人スキル、または体験に基づいて、マッチプレイヤーを考慮する必要がありますが、新しいプレイヤーは、同様の能力の他者と対戦することで、レベルを上げることができます。


これを行うにはまず、マッチメイキングを使用して XIM ネットワークに移動する前に、`XimLocalPlayer.SetMatchmakingConfiguration()` の呼び出しで指定されるプレイヤーごとのマッチメイキング設定構造体で、すべてのローカル プレイヤーにスキル レベルを提供します。 スキル レベルはアプリ固有の概念であり、数が XIM で解釈されることはありません。例外として、マッチメイキングでまず同一のスキル値を持つプレイヤーを探してから、定期的に +/- 10 単位で検索対象の増減を行い、そのスキル範囲内でスキル値を宣言する他のプレイヤーを探すことができます。 以下の例では、ローカルの `XimLocalPlayer` オブジェクトを想定しています。このオブジェクトの変数は 'localPlayer' であり、ローカルまたは Xbox Live のストレージから 'playerSkillValue' と呼ばれる変数に対して取得されたアプリ固有の整数のスキル値が格納されます。

```cs
var config = new XimPlayerMatchmakingConfiguration();
config.Skill = playerSkillValue;
localPlayer.SetMatchmakingConfiguration(config);
```

これが完了すると、この `IXIMPlayer` によってプレイヤーごとのマッチメイキング設定が変更されたことを示す `PlayerMatchmakingConfigurationStateChange` が、すべての参加者に送信されます。 新しい値を取得するには、`IXIMPlayer.MatchmakingConfiguration` を呼び出します。

すべてのプレイヤーに null 以外のマッチメイキング設定が適用されたら、`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` に指定された `MatchmakingConfiguration` 構造体の `RequirePlayerMatchmakingConfiguration` フィールドに true 値を指定してマッチメイキングを使用することで XIM に移動できます。 以下の例では、no-teams free-for-all 用に 合計 2 ～ 8 人のプレイヤーを探すマッチメイキング構成を追加します。このとき、MYGAMEMODE_DEATHMATCH の値で定義されるアプリ固有のゲーム モード定数である Uint64 を使用します。この値は、同一値を指定した他のプレイヤーのみと一致し、使用するにはプレイヤーごとのマッチメイキング構成が必要になります。

```cs
XimMatchmakingConfiguration matchmakingConfiguration = new XimMatchmakingConfiguration()
{
    TeamMatchmakingMode = XimTeamMatchmakingMode.NoTeams8PlayersMinimum2;
    CustomGameMode = MYGAMEMODE_DEATHMATCH;
    RequirePlayerMatchmakingConfiguration = true;
};
```

この構造体が `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` に送信されると、移動するプレイヤーによって、null 以外の `XimPlayerMatchmakingConfiguration` オブジェクトを使用して `XimLocalPlayer.SetMatchmakingConfiguration()` が呼び出されている限り、この移動操作は正常に開始されます。 これが行われていないプレイヤーがいる場合、マッチメイキング処理は一時停止され、`WaitingForPlayerMatchmakingConfiguration` 値が指定された `XimMatchmakingProgressUpdatedStateChange` がすべての参加者に送信されます。 これには、マッチメイキングが完了する前に、事前に送信された招待または他のソーシャルな手段 (`XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableXboxUserId()` の呼び出しなど) で、XIM ネットワークに途中参加したプレイヤーも含まれます。 すべてのプレイヤーが `XimPlayerMatchmakingConfiguration` オブジェクトを送信した時点で、マッチメイキングが再開されます。

プレイヤーごとのマッチメイキング設定を使用してユーザーのマッチメイキング エクスペリエンスを高める別の方法として、必要なプレイヤー ロールを使うことができます。 これは、さまざまな協力型プレイ スタイルを提案するキャラクター タイプを選択できるゲームに最も適しています。つまり、ゲーム内のグラフィカル表現をただ変更するのではなく、防御型 "ヒーラー" に対して近距離型の "メレー" 攻撃や遠距離型の "レンジ" 攻撃のサポートなど、補完的で影響の強い属性を制御するようなものを指します。 ユーザーのパーソナリティは、専門分野としてプレイする場合があるということを意味します。 しかし、各ロールを満たす者が存在せずに、機能的に目的を完了させることができないようにゲームが設計されている場合は、任意のプレイヤーをまとめてマッチングさせるよりもそのようなプレイヤーをまとめてマッチングさせ、集まった時点でプレイヤー間でプレイ スタイルを検討する方が望ましい場合があります。 これを行うには、指定のプレイヤーの `XimPlayerMatchmakingConfiguration` 構造体で指定される各ロールを表す一意のビット フラグを最初に定義します。 以下の例では、ローカルの `XimLocalPlayer` オブジェクトに対して、アプリ固有のロール値である MYROLEBITFLAG_HEALER int を設定します。この変数は、'localPlayer' です。

```cs
var config = new XimPlayerMatchmakingConfiguration();
config.Roles = MYROLEBITFLAG_HEALER;
localPlayer.SetMatchmakingConfiguration(config);
```

上記のスキルで示されたとおり、このプレイヤーに対する `PlayerMatchmakingConfigurationStateChange` がすべての参加者に送信されます。 `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` に指定されたグローバル構造体 `XimMatchmakingConfiguration` には、ビットごとの OR を使用して結合されたすべての必要なロール フラグや、`RequirePlayerMatchmakingConfiguration` フィールドに対する true 値が含まれます。

スキルとロールは、同時に使用することができます。 いずれかのみ指定する場合は、他の構造体に値 0 を指定します。 これは、`PlayerMatchmakingConfiguration` スキル値が 0 であると宣言しているすべてのプレイヤーが常に互いに一致するためであり、`Player` の required_roles フィールドにゼロ以外のビットが存在しない場合は、一致させるためのロール ビットは必要ありません。

`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` や、その他すべての XIM ネットワークの移動操作が完了すると、すべてのプレイヤーの `XimPlayerMatchmakingConfiguration` オブジェクトは、自動的に null にクリアされます (付随して `XimPlayerMatchmakingConfigurationChangedStateChange` 通知が送信されます)。 プレイヤーごとの設定が必要なマッチメイキングを使用して、別の XIM ネットワークに移動する場合、常に最新の情報を含むオブジェクトで、再度 `XimLocalPlayer.SetMatchmakingConfiguration()` を呼び出します。

## <a name="player-teams-and-configuring-chat-targets-a-nameteams"></a>プレイヤーのチームおよびチャット ターゲットの設定 <a name="teams">

マルチプレイヤーのゲームでは、プレイヤーを相手チームに組み込むことも必要になります。 XIM では、指定の設定で 2 つ以上のチームを要求する `XimTeamMatchmakingMode` 値を使用してマッチメイキングを行う際にチームを割り当てやすくなります。 以下の例では、2 チーム 4 人ずつ (4 人見つからない場合は 1 ～ 3 人でも許容可能) の合計 8 人のプレイヤーを探すように構成されたマッチメイキングを使用して移動を開始します。このとき、MYGAMEMODE_CAPTURETHEFLAG の値 (この値は、同一値を指定した他のプレイヤーのみと一致します) によって定義されるアプリ固有のゲーム モード定数 uint64_t を使用し、ソーシャルな方法で参加したすべてのプレイヤーを現在の XIM ネットワークから移動します。

```cs
XimMatchmakingConfiguration matchmakingConfiguration = new XimMatchmakingConfiguration()
{
     TeamMatchmakingMode = XimTeamMatchmakingMode.TwoTeams4v4Minimum1PerTeam;
     CustomGameMode = MYGAMEMODE_CAPTURETHEFLAG;
};

XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking(matchmakingConfiguration, XimPlayersToMove.BringExistingSocialPlayers);
```
このような XIM ネットワークの移動操作が完了すると、リクエストされたチーム数に対応して、プレイヤーに 1 から {n} のチーム インデックス値が割り当てられます。 プレイヤーのチーム インデックスの値は、`IXIMPlayer.TeamIndex` を使用して取得されます。 以下の例では、'ximPlayer' 変数に保存された XIM プレイヤー オブジェクトのチーム インデックスを取得します。

```cs
byte playerIndex = ximPlayer.TeamIndex;
```

Xbox Live のマッチメイキング サービスでは、(プレイヤーによる否定的な行動の機会を制限するだけではなく) 望ましいユーザー エクスペリエンスを実現するために、一緒に XIM ネットワークに移動する複数のプレイヤーが別々のチームに分割されることはありません。

マッチメイキングによって最初に割り当てられているチームのインデックス値は単なる推奨値であり、アプリではいつでも `XimLocalPlayer.SetTeamIndex()` を使用してローカル プレイヤーの値を変更できます。 これは、マッチメイキングを一切使用していない XIM ネットワークで呼び出すこともできます。

プレイヤーに新しいチーム インデックス値が設定された場合、すべてのデバイスは、プレイヤーの `XimPlayerTeamIndexChangedStateChange` を受信することで通知されます。

2 つ以上のチームで `XimTeamMatchmakingMode` を使用している場合、`XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` の呼び出しで、プレイヤーにチームインデックス値 0 が割り当てられることはありません。 これは、他の構成や種類の移動操作 (招待の承認によるプロトコルのアクティブ化など) で XIM ネットワークに追加されるプレイヤーと対照的です。これらのプレイヤーには、常にチーム インデックス値 0 が割り当てられます。 インデックス 0 のチームを特別な "未割り当て" チームとして扱うと便利な場合があります。

特定のチーム インデックス値の本当の意味は、アプリごとに設定できます。 チャット ターゲット構成の同等比較に使用する場合を除き、XIM によるチーム インデックス値の解釈は行われません。 `XboxIntegratedMultiplayer.ChatTargets` で報告されたチャット ターゲット構成が現在 `XimChatTargets.SameTeamIndexOnly` であれば、プレイヤーが相手とチャット通信を行うのは、`IXIMPlayer.TeamIndex` で報告された同一値が両者に設定されている (加えて、プライバシー/ポリシーで許可される) 場合のみです。

競争力のあるシナリオを堅実にサポートするために、新しく作成された XIM ネットワークは既定値が `XimChatTargets.SameTeamIndexOnly` になるように自動的に構成されます。 ただし、対戦後の "ロビー" などで、負けた相手チームとのチャットが望まれることもあります。 プライバシーやポリシーで許可されていれば、すべてのユーザーがほかのすべてのユーザーと対話できるように XIM を設定するには、`XboxIntegratedMultiplayer.SetChatTargets()` を呼び出します。 以下のサンプルでは、`XimChatTargets.AllPlayers` 値が使用されるように、XIM ネットワーク内のすべての参加者を設定します。

```cs
XboxIntegratedMultiplayer.SetChatTargets(XimChatTargets.AllPlayers)
```

新しいターゲット設定が有効になった場合、すべての参加者は、`XimChatTargetsChangedStateChange` を受信することで通知されます。

前述のように、XIM ネットワークのほとんどの移動タイプで、最初はインデックス値 0 がすべてのプレイヤーに割り当てられます。 これは、既定では `XimChatTargets.SameTeamIndexOnly` の設定を `XimChatTargets.AllPlayers` と区別できない可能性が高いことを意味します。 ただし、マッチメイキング構成の `TeamMatchmakingMode` 値で 2 つ以上のチームが宣言されている場合、マッチメイキングを使用して XIM ネットワークに移動するプレイヤーには異なるチーム インデックス値が設定されます。 また、`XimLocalPlayer.SetTeamIndex()` は、上記のようにいつでも呼び出すことができます。 アプリでこれらのメソッドのいずれかを使用して、0 以外のチーム インデックス値を使用している場合は、必ずチャットのターゲット設定を適切に管理してください。

マッチメイキングでは、チームとは別に各プレイヤーに必要なロールが評価されます。 チームはプレイヤーに割り当てられたロールではなくプレイヤーの数で調整されるため、マッチメイキング構成条件として、チームと必要なロールの両方を同時に使用することはお勧めできません。

## <a name="automatic-background-filling-of-player-slots-backfill-matchmaking-a-namebackfill"></a>プレイヤー スロットの自動バックグラウンド設定 ("バックフィル" マッチメイキング) <a name="backfill">

異なるプレイヤー グループが同時に `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を呼び出すことで、Xbox Live マッチメイキング サービスで新しく最適な XIM ネットワークをすばやく構成するための柔軟性が最大になります。 ただし、ゲームプレイ シナリオによっては、特定の XIM ネットワークが変更されない状態で維持する必要があり、追加プレイヤーのマッチメイキングが行われるのは空いているプレイヤー スロットを満たす場合のみというケースもあります。 XIM では、`XboxIntegratedMultiplayer.SetBackfillMatchMakingConfiguration()` メソッドを使用して自動バックグラウンド設定モードで動作するマッチメイキングの構成 ("バックフィリング") もサポートされます。 以下の例では、バックフィル マッチメイキングを構成して、no-teams free-for-all 用に合計 8 人のプレイヤーを探します (8 人見つからない場合は、2 ～ 7 人でも許容可能)。このとき、MYGAMEMODE_DEATHMATCH の値 (この値は、同一値を指定した他のプレイヤーのみと一致します) で定義されるアプリ固有のゲーム モード定数 uint64_t を使用します。

```cs
XimMatchmakingConfiguration matchmakingConfiguration = new XimMatchmakingConfiguration()
{
     TeamMatchmakingMode = XimTeamMatchmakingMode.NoTeams8PlayersMinimum2;
     CustomGameMode = MYGAMEMODE_DEATHMATCH;
};

XboxIntegratedMultiplayer.SetBackfillMatchMakingConfiguration(matchmakingConfiguration);
```

これにより、通常の方法で `XboxIntegratedMultiplayer.MoveToNetworkUsingMatchmaking()` を呼び出すデバイスが既存の XIM ネットワークを利用できるようになります。 これらのデバイスでは、動作の変更がありません。 バックフィリング中の XIM ネットワークにいる参加者は移動できませんが、これらの参加者には、バックフィルが有効になったことを表す <`XimBackfillMatchmakingConfigurationChangedStateChange` や複数の `XimMatchmakingProgressUpdatedStateChange` 通知 (該当する場合) が送信されます。 マッチメイキングで見つかったプレイヤーは、通常の `XimPlayerJoinedStateChange` を使用して XIM ネットワークに追加されます。

バックフィル マッチメイキングは無期限に進行状態になります (XIM ネットワークで既に最大プレイヤー数が `TeamMatchmakingMode` 値で指定されている場合はプレイヤーが追加されることはありません)。 バックフィルは、null で `XboxIntegratedMultiplayer.SetBackfillMatchMakingConfiguration()` を再度呼び出して無効にすることができます。

```cs
XboxIntegratedMultiplayer.SetBackfillMatchMakingConfiguration(null);
```

対応する `XimBackfillMatchmakingConfigurationChangedStateChange` がすべてのデバイスに送信され、この非同期処理が完了すると、マッチメイキングされたプレイヤーがこれ以上 XIM ネットワークに追加されないことを表す `MatchmakingStatus.None` で最終的な `XimMatchmakingProgressUpdatedStateChange` が送信されます。

2 つ以上のチームを宣言する `XimTeamMatchmakingMode` を使用してバックフィル マッチメイキングを有効にする場合、既存のすべてのプレイヤーに有効なチームインデックス値 (1 ～チーム数) が必要になります。 これには、`XimLocalPlayer.SetTeamIndex()` を呼び出してカスタム値を指定したプレイヤーや、招待または他のソーシャルな手段 (例: `XboxIntegratedMultiplayer.MoveToNetworkUsingJoinableXboxUserId()` の呼び出し) によって参加して既定のインデックス値 0 が追加されたプレイヤーも含まれます。 有効なチームインデックス値を持つプレイヤーがいない場合、マッチメイキング処理は保留され、`MatchmakingStatus.WaitingForPlayerTeamIndex` 値が指定された `XimMatchmakingProgressUpdatedStateChange` がすべての参加者に送信されます。 すべてのプレイヤーについて、`XimLocalPlayer.SetTeamIndex()` でチーム インデックス値が指定または修正されると、バックフィル マッチメイキングが再開されます。

同様に、`RequirePlayerMatchmakingConfiguration` フィールドでロールまたはスキルが true に設定されている `MatchmakingConfiguration` 構造体を使用してバックフィル マッチメイキングを有効にする場合、すべてのプレイヤーについて、プレイヤーごとのマッチメイキング構成が null 以外に指定されている必要があります。 これが行われていないプレイヤーがいる場合、マッチメイキング処理は一時停止され、`XimMatchMakingStatus.WaitingForPlayerMatchmakingConfiguration` 値が指定された `XimMatchmakingProgressUpdatedStateChange` がすべての参加者に送信されます。 すべてのプレイヤーが `XimPlayerMatchmakingConfiguration` オブジェクトを送信した時点で、バックフィル マッチメイキングが再開されます。
