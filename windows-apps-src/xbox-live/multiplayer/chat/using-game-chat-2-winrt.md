---
title: ゲーム チャット 2 WinRT プロジェクションの使用
author: KevinAsgari
description: WinRT プロジェクションと共に Xbox Live ゲーム チャット 2 を使用して、ゲームに音声通信を追加する方法について説明します。
ms.author: kevinasg
ms.date: 4/11/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, ゲーム チャット 2, ゲーム チャット, 音声通信
ms.localizationpriority: medium
ms.openlocfilehash: 5ca62427a5e8f51143ef9e40faf24272ffbe97d7
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4149662"
---
# <a name="using-game-chat-2-winrt-projections"></a>ゲーム チャット 2 (WinRT プロジェクション) の使用

ここでは、ゲーム チャット 2 の C# API の使用方法について概要を紹介します。 C++ を通じたゲーム チャット 2 へのアクセスを予定しているゲーム開発者は、「[ゲーム チャット 2 の使用](using-game-chat-2.md)」をご覧ください。

1. [前提条件](#prereq)
2. [初期化](#init)
3. [ユーザーの構成](#config)
4. [データ フレームの処理](#data)
5. [状態変更の処理](#state)
6. [テキスト チャット](#text)
7. [ユーザー補助](#access)
8. [UI](#UI)
9. [ミュート](#mute)
10. [悪い評判の自動ミュート](#automute)
11. [権限とプライバシー](#priv)
12. [クリーンアップ](#cleanup)
13. [一般的なシナリオの構成方法](#how-to-configure-popular-scenarios)

## <a name="prerequisites-a-nameprereq"></a>前提条件<a name="prereq">

ゲーム チャット 2 を使うには、[Microsoft.Xbox.Services.GameChat2 nuget パッケージ](https://www.nuget.org/packages/Microsoft.Xbox.Game.Chat.2.WinRT.UWP/)を含める必要があります。

ゲーム チャット 2 のコーディングを始める前に、"マイク" デバイス機能を宣言するアプリの AppXManifest を構成している必要があります。 AppXManifest 機能については、プラットフォームのドキュメントの各セクションで詳しく説明されています。次のスニペットは、パッケージ/機能ノードの下に存在している必要があり、存在しないとチャットがブロックされる "マイク" デバイス機能ノードを示しています。

```xml
 <?xml version="1.0" encoding="utf-8"?>
 <Package ...>
   <Identity ... />
   ...
   <Capabilities>
     <DeviceCapability Name="microphone" />
   </Capabilities>
 </Package>
```

## <a name="initialization-a-nameinit"></a>初期化 <a name="init">

インスタンスに追加されると予想される同時チャット ユーザーの最大数を設定した `GameChat2ChatManager` オブジェクトをインスタンス化することにより、ライブラリの操作を開始します。 この値を変更するには、`GameChat2ChatManager` オブジェクトを破棄し、目的の値で再作成する必要があります。 一度にインスタンス化できる `GameChat2ChatManager` は 1 つだけです。

```cs
GameChat2ChatManager myGameChat2ChatManager = new GameChat2ChatManager(<maxChatUserCount>);
```

`GameChat2ChatManager` オブジェクトは、いつでも構成可能な追加のオプション プロパティです。 次のコード サンプルでは、`myGameChat2ChatManager` オブジェクトでプロパティの設定に使用される前に変数に値が与えられると想定しています。

```cs
GameChat2SpeechToTextConversionMode mySpeechToTextConversionMode;
GameChat2SharedDeviceCommunicationRelationshipResolutionMode mySharedDeviceResolutionMode;
GameChat2CommunicationRelationship myDefaultLocalToRemoteCommunicationRelationship;
float myDefaultAudioRenderVolume;
GameChat2AudioEncodingTypeAndBitrate myAudioEncodingTypeAndBitRate;

...

myGameChat2ChatManager.SpeechToTextConversionMode = mySpeechToTextConversionMode;
myGameChat2ChatManager.SharedDeviceResolutionMode = mySharedDeviceResolutionMode;
myGameChat2ChatManager.DefaultLocalToRemoteCommunicationRelationship = myDefaultLocalToRemoteCommunicationRelationship;
myGameChat2ChatManager.DefaultAudioRenderVolume = myDefaultAudioRenderVolume;
myGameChat2ChatManager.AudioEncodingTypeAndBitRate = myAudioEncodingTypeAndBitRate;
```

## <a name="configuring-users-a-nameconfig"></a>ユーザーの構成 <a name="config">

インスタンスが初期化されたら、GC2 インスタンスにローカル ユーザーを追加する必要があります。 この例では、ユーザー A はローカル ユーザーを表します。

```cs
string userAXuid;

...

IGameChat2ChatUser userA = myGameChat2ChatManager.AddLocalUser(userAXuid);
```

次に、リモート ユーザーと識別子 (各リモート ユーザーがいるリモート "エンドポイント" を表すために使用) を追加する必要があります。 "エンドポイント" は、`IGameChat2Endpoint` インターフェイスを実装するアプリが所有するオブジェクトによって表されます。 次の例は、`IGameChat2Endpoint` を実装する `MyEndpoint` クラスのサンプル実装を示しています。

```cs
class MyEndpoint : IGameChat2Endpoint
{
    private uint endpointIdentifier;
    public MyEndpoint(uint identifier)
    {
        endpointIdentifier = identifier;
    }

    // Implementing IsSameEndpointAs, the only method on the IGameChat2Endpoint interface
    public bool IsSameEndpointAs(IGameChat2Endpoint gameChat2Endpoint)
    {
        return endpointIdentifier == ((MyEndpoint)gameChat2Endpoint).endpointIdentifier;
    }
}
```

次のコード例では、ユーザー B、C、D は追加されるリモート ユーザーです。 ユーザー B は 1 つのリモート デバイスにおり、ユーザー C および D は別のリモート デバイスにいます。 この例では、変数が設定されること、`myGameChat2ChatManager` が `GameChat2ChatManager` のインスタンスであること、"MyEndpoint" が `IGameChat2Endpoint` を実装するクラスであることを想定しています。

```cs
string userBXuid;
string userCXuid;
string userDXuid;
MyEndpoint myRemoteEndpointOne;
MyEndpoint myRemoteEndpointTwo;

...

IGameChat2ChatUser remoteUserB = myGameChat2ChatManager.AddRemoteUser(userBXuid, myRemoteEndpointOne);
IGameChat2ChatUser remoteUserC = myGameChat2ChatManager.AddRemoteUser(userCXuid, myRemoteEndpointTwo);
IGameChat2ChatUser remoteUserD = myGameChat2ChatManager.AddRemoteUser(userDXuid, myRemoteEndpointTwo);
```

これで、各リモート ユーザーとローカル ユーザーとの間の通信リレーションシップが構成されました。 この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。 `GameChat2CommunicationRelationship.SendAndReceiveAll` は、双方向通信を表すように定義されています。 ユーザー A のユーザー B に対するリレーションシップを次のように設定します。

```cs
GameChat2ChatUserLocal localUserA = userA as GameChat2ChatUserLocal;
localUserA.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.SendAndReceiveAll);
```

次に、ユーザー C とユーザー D は "観戦者" であり、ユーザー A を一覧に表示することはできますが、会話は許可されていないと仮定します。 `GameChat2CommunicationRelationship.ReceiveAll` は定義されたこの単方向通信です。 リレーションシップを次のように設定します。

```cs
localUserA.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.ReceiveAll);
localUserA.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.ReceiveAll);
```

任意の時点で、`GameChat2ChatManager` インスタンスに追加されているがローカル ユーザーと通信できるように構成されていないリモート ユーザーがいても問題ありません。 これは、ユーザーがチームを決定中か、会話チャネルを任意に変更できるシナリオで発生する場合があります。 ゲーム チャット 2 がキャッシュするのは、インスタンスに追加されたユーザーの情報 (プライバシー リレーションシップと評判) だけであるため、すべてのユーザー候補について、そのユーザーが特定の時点でローカル ユーザーと会話できない場合でも、ゲーム チャット 2 に通知すると役立ちます。

最後の点として、ユーザー D がゲームを終了したため、ローカル ゲーム チャット 2 インスタンスから削除する必要があるとします。 これは、次の呼び出しで実行できます。

```cs
remoteUserD.Remove();
```

`Remove()` が呼び出されるとすぐにユーザー オブジェクトは無効になります。 ユーザーの最後の状態は、削除されるときにキャッシュされます。 ユーザー オブジェクトが無効になった後で呼び出される情報メソッドは、削除される前のユーザーの状態を反映します。 他のメソッドは、呼び出されるとエラーをスローします。

## <a name="processing-data-frames-a-namedata"></a>データ フレームの処理 <a name="data">

ゲーム チャット 2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。 このプラグインは、アプリによる `GameChat2ChatManager.GetDataFrames()` の定期的かつ頻繁な呼び出しです。 このメソッドを使うと、ゲーム チャット 2 は発信データをアプリに提供できます。 専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。

`GameChat2ChatManager.GetDataFrames()` を呼び出すと、キューに入っているすべてのデータが `IGameChat2DataFrame` オブジェクトのリストで報告されます。 アプリでは、リストを反復処理して、`TargetEndpointIdentifiers` を検査し、アプリのネットワーク層を使用してデータを適切なリモート アプリ インスタンスに配信する必要があります。 この例では、`HandleOutgoingDataFrame` は `Buffer` のデータを、`TransportRequirement` に従って `TargetEndpointIdentifiers` で指定された各 "エンドポイント" の各ユーザーに送信する関数です。

```cs
IReadOnlyList<IGameChat2DataFrame> frames = myGameChat2ChatManager.GetDataFrames();
foreach (IGameChat2DataFrame dataFrame in frames)
{
    HandleOutgoingDataFrame(
        dataFrame.Buffer,
        dataFrame.TargetEndpointIdentifiers,
        dataFrame.TransportRequirement
        );
}
```

データ フレームの処理頻度が高いほど、エンド ユーザーの感じるオーディオの遅延は低くなります。 オーディオは 40 ミリ秒のデータ フレームに結合されます。これは、推奨されるポーリング期間です。

## <a name="processing-state-changes-a-namestate"></a>状態変更の処理 <a name="state">

ゲーム チャット 2 では、アプリによる `GameChat2ChatManager.GetStateChanges()` メソッドの定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。 UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。 これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。

`GameChat2ChatManager.GetStateChanges()` を呼び出すと、キューに入っているすべての更新が `IGameChat2StateChange` オブジェクトのリストで報告されます。 アプリは次の処理を行う必要があります。
1. リストを反復処理する。
2. 具体的な型の基本構造体を検査する。
3. 基本構造体を対応するより詳細な型にキャストする。
4. 必要に応じて更新を処理する。 

```cs
IReadOnlyList<IGameChat2StateChange> stateChanges = myGameChat2ChatManager.GetStateChanges();
foreach (IGameChat2StateChange stateChange in stateChanges)
{
    switch (stateChange.Type)
    {
        case GameChat2StateChangeType.CommunicationRelationshipAdjusterChanged:
        {
            MyHandleCommunicationRelationshipAdjusterChanged(stateChange as GameChat2CommunicationRelationshipAdjusterChangedStateChange);
            break;
        }
        case GameChat2StateChangeType.TextChatReceived:
        {
            MyHandleTextChatReceived(stateChange as GameChat2TextChatReceivedStateChange);
            break;
        }

        ...
    }
}
```

## <a name="text-chat-a-nametext"></a>テキスト チャット <a name="text">

テキスト チャットを送信するには、`GameChat2ChatUserLocal.SendChatText()` を使用します。 次に、例を示します。

```cs
localUserA.SendChatText("Hello");
```

ゲーム チャット 2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。 リモート エンドポイントでデータが処理されると、メッセージは `GameChat2TextChatReceivedStateChange` を通じて公開されます。 ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。 ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは失われます。

ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#access)」を参照してください)。

## <a name="accessibility-a-nameaccess"></a>ユーザー補助 <a name="access">

テキスト チャットの入力と表示をサポートする必要があります。 テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。 同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。 `GameChat2ChatUserLocal.TextToSpeechConversionPreferenceEnabled` および `GameChat2ChatUserLocal.SpeechToTextConversionPreferenceEnabled` プロパティをそれぞれチェックすると、ローカル ユーザーがこれらの設定を検出できます。必要に応じて、テキストのメカニズムを有効にすることもできます。

### <a name="text-to-speech"></a>音声合成

ユーザーが音声合成を有効にしていると、`GameChat2ChatUserLocal.TextToSpeechConversionPreferenceEnabled` は 'true' になります。 この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。 現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `GameChat2ChatUserLocal.SynthesizeTextToSpeech()` メソッドに渡します。 ゲーム チャット 2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。 次に、例を示します。

```cs
localUserA.SynthesizeTextToSpeech("Hello");
```

この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。 音声合成を有効にしていないユーザーから `GameChat2ChatUserLocal.SynthesizeTextToSpeech()` が呼び出された場合、ゲーム チャット 2 では何も実行しません。

### <a name="speech-to-text"></a>音声テキスト変換

ユーザーが音声テキスト変換を有効にしていると、`GameChat2ChatUserLocal.SpeechToTextConversionPreferenceEnabled` は true になります。 この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。 GC では各リモート ユーザーのオーディオを自動的に変換して、`GameChat2TranscribedChatReceivedStateChange` を通じて公開します。

### <a name="speech-to-text-performance-considerations"></a>音声テキスト変換のパフォーマンスに関する考慮事項

音声テキスト変換が有効の場合、各リモート デバイスのゲーム チャット 2 インスタンスでは音声サービス エンドポイントとの Web ソケット接続を開始します。 各リモート ゲーム チャット 2 クライアントではこの WebSocket を通じて音声サービス エンドポイントにオーディオをアップロードします。音声サービス エンドポイントでは随時、トランスクリプション メッセージをリモート デバイスに返します。 その後、リモート デバイスではトランスクリプション メッセージ (つまり、テキスト メッセージ) をローカル デバイスに送信します。ローカル デバイスでは、ゲーム チャット 2 からアプリにテキスト メッセージが提供され、表示されます。

そのため、音声テキスト変換の主なパフォーマンス コストは、ネットワーク使用率です。 ネットワーク トラフィックの大半はエンコードされたオーディオのアップロードです。 "通常" のボイス チャット パスでゲーム チャット 2 によってエンコード済みのオーディオが WebSocket によってアップロードされます。アプリでは `GameChat2ChatManager.AudioEncodingTypeAndBitrate` を通じてビットレートを制御します。

## <a name="ui-a-nameui"></a>UI <a name="UI">

特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。 `IGameChat2ChatUser.ChatIndicator` プロパティは、そのプレイヤーのチャットの現在の瞬間的なステータスを表します。 次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'userA' 変数で指定した `IGameChat2ChatUser` オブジェクトのインジケーター値の取得を示します。

```cs
switch (userA.ChatIndicator)
{
    case GameChat2UserChatIndicator.Silent:
    {
        iconToShow = Icon_InactiveSpeaker;
        break;
    }
    case GameChat2UserChatIndicator.Talking:
    {
        iconToShow = Icon_ActiveSpeaker;
        break;
    }
    case GameChat2UserChatIndicator.LocalMicrophoneMuted:
    {
        iconToShow = Icon_MutedSpeaker;
        break;
    }
    
    ...
}
```

`IGameChat2ChatUser.ChatIndicator` の値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。 そのため、すべての UI フレームをポーリングできるように設計されています。

## <a name="muting-a-namemute"></a>ミュート <a name="mute">

`GameChat2ChatUserLocal.MicrophoneMuted` プロパティを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。 マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。 ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。 このメソッドは、ハードウェア ミュート コントロール (ユーザー ヘッドセットのボタンなど) は反映しません。 ゲーム チャット 2 を通じてユーザーのオーディオ デバイスのハードウェアのミュート状態を取得するメソッドはありません。

`GameChat2ChatUserLocal.SetRemoteUserMuted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。 リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。

## <a name="bad-reputation-auto-mute-a-nameautomute"></a>悪い評判の自動ミュート <a name="automute">

通常、リモート ユーザーはミュートを解除した状態で開始します。 (1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、ゲーム チャット 2 ではユーザーをミュート状態で開始します。 この操作によってユーザーがミュートされている場合、`IGameChat2ChatUser.ChatIndicator` は `GameChat2UserChatIndicator.ReputationRestricted` を返します。 この状態は、そのリモート ユーザーをターゲット ユーザーとして含む `GameChat2ChatUserLocal.SetRemoteUserMuted()` の最初の呼び出しでオーバーライドされます。

## <a name="privilege-and-privacy-a-namepriv"></a>権限とプライバシー <a name="priv">

ゲームによって構成される通信リレーションシップの上に、ゲーム チャット 2 は権限とプライバシーの制限を強制します。 ゲーム チャット 2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `IGameChat2ChatUser.ChatIndicator` は常に `GameChat2UserChatIndicator.Silent` を返します。 ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `IGameChat2ChatUser.ChatIndicator` は `GameChat2UserChatIndicator.PlatformRestricted` を返します。 プラットフォーム通信制限は、音声チャットとテキスト チャットの両方に適用されます。テキスト チャットがプラットフォーム制限によりブロックされて音声チャットが制限されないインスタンスはなく、その逆もありません。

`GameChat2ChatUserLocal.GetEffectiveCommunicationRelationship()` を使用すると、不完全な権限とプライバシーの操作によってユーザーが通信できない場合の区別に役立ちます。 これを使用すると、ゲーム チャット 2 によって強制される通信リレーションシップが `GameChat2CommunicationRelationship` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `GameChat2CommunicationRelationshipAdjuster` の形式で返されます。 たとえば、参照操作が進行中の場合、`GameChat2CommunicationRelationshipAdjuster` は `GameChat2CommunicationRelationshipAdjuster.Initializing` になります。 この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。

## <a name="cleanup-a-namecleanup"></a>クリーンアップ <a name="cleanup">

アプリでゲーム チャット 2 を介した通信が不要になった場合は、`GameChat2ChatManager.Dispose()` を呼び出します。 これにより、ゲーム チャット 2 で通信の管理に割り当てられたリソースを解放できます。

## <a name="how-to-configure-popular-scenarios"></a>一般的なシナリオの構成方法

### <a name="push-to-talk"></a>プッシュして話しかける

プッシュして話しかける機能は、`GameChat2ChatUserLocal.MicrophoneMuted` を使用して実装する必要があります。 会話を許可するには `MicrophoneMuted` を false に設定し、制限するには `MicrophoneMuted` を true に設定します。 このプロパティ変更を使用すると、ゲーム チャット 2 からの応答遅延時間が最少限になります。

### <a name="teams"></a>チーム

ユーザー A とユーザー B が青チーム、ユーザー C とユーザー D が赤チームに属しているとします。 各ユーザーは、アプリの一意のインスタンスに含まれます。

ユーザー A のデバイス:

```cs
localUserA.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.SendAndReceiveAll);
localUserA.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
localUserA.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

ユーザー B のデバイス:

```cs
localUserB.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.SendAndReceiveAll);
localUserB.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
localUserB.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

ユーザー C のデバイス:

```cs
localUserC.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.None);
localUserC.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserC.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.SendAndReceiveAll);
```

ユーザー D のデバイス:

```cs
localUserD.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.None);
localUserD.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserD.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.SendAndReceiveAll);
```

### <a name="broadcast"></a>配信

ユーザー A が指示を出すリーダーで、ユーザー B、C、D は指示を聞くだけと仮定します。 各プレイヤーは、一意のデバイスを使用しています。

ユーザー A のデバイス:

```cs
localUserA.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.SendAll);
localUserA.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.SendAll);
localUserA.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.SendAll);
```

ユーザー B のデバイス:

```cs
localUserB.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.ReceiveAll);
localUserB.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
localUserB.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

ユーザー C のデバイス:

```cs
localUserC.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.ReceiveAll);
localUserC.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserC.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

ユーザー D のデバイス:

```cs
localUserD.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.ReceiveAll);
localUserD.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserD.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
```
