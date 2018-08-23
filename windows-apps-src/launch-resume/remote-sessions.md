---
author: PatrickFarley
title: リモート セッションでデバイスを接続する
description: リモート セッションで複数のデバイスを結合することにより、これらのデバイス間で共有エクスペリエンスを作成します。
ms.assetid: 1c8dba9f-c933-4e85-829e-13ad784dd3e2
ms.author: pafarley
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、接続されているデバイス、リモート システム、ローマ、プロジェクト ローマ
ms.localizationpriority: medium
ms.openlocfilehash: 8e5226b23a454bf48add22d590a3ff247c629e4f
ms.sourcegitcommit: 9c79fdab9039ff592edf7984732d300a14e81d92
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/23/2018
ms.locfileid: "2822874"
---
# <a name="connect-devices-through-remote-sessions"></a>リモート セッションでデバイスを接続する

リモート セッション機能を使用すると、セッションを介してアプリを他のデバイスに接続できます。これは明示的なアプリ メッセージングや、ブローカーによるシステム管理データ (Windows Holographic デバイス間のホログラフィック共有に使用する **[SpatialEntityStore](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialentitystore)** など) の交換を目的としています。

リモート セッションはどの Windows デバイスでも作成でき、(他のユーザーがサインインしているデバイスを含めて) どの Windows デバイスでも参加を要求できます (セッションによっては招待のみの可視性が適用されることがあります)。 このガイドには、リモート セッションを利用するあらゆる主要なシナリオの基本的なサンプル コードを記載しています。 このコードは、既存のアプリ プロジェクトに組み込み、必要に応じて変更できます。 エンド ツー エンド実装については、[クイズ ゲームのサンプル アプリ](https://github.com/microsoft/Windows-appsample-remote-system-sessions)をご覧ください。

## <a name="preliminary-setup"></a>準備段階のセットアップ

### <a name="add-the-remotesystem-capability"></a>remoteSystem 機能を追加する

アプリでリモート デバイスのアプリを起動するには、`remoteSystem` 機能をアプリ パッケージ マニフェストに追加する必要があります。 これには、マニフェスト デザイナーで  **[機能]** タブの **[リモート システム]** を選んで追加するか、プロジェクトの _Package.appxmanifest_ ファイルに以下のコードを手動で追加します。

``` xml
<Capabilities>
   <uap3:Capability Name="remoteSystem"/>
</Capabilities>
```

### <a name="enable-cross-user-discovering-on-the-device"></a>デバイスでユーザー間の検出を有効にする
リモート セッションには、複数の異なるユーザーどうしの接続を目的とした機能が備えられているため、各デバイスでユーザー間の共有を有効にしておく必要があります。 このシステム設定は、次のように **RemoteSystem** クラスで静的メソッドを使用することで照会できます。

```csharp
if (!RemoteSystem.IsAuthorizationKindEnabled(RemoteSystemAuthorizationKind.Anonymous)) {
    // The system is not authorized to connect to cross-user devices. 
    // Inform the user that they can discover more devices if they
    // update the setting to "Everyone nearby".
}
```

この設定を変更するには、ユーザーが**設定**アプリを開く必要があります。 **[システム]** > **[共有エクスペリエンス]** > **[デバイス間で共有します]** メニューの順に移動すると、システムで共有可能なデバイスをユーザーが指定できるドロップダウン ボックスがあります。

![[共有エクスペリエンス] 設定ページ](images/shared-experiences-settings.png)

### <a name="include-the-necessary-namespaces"></a>必要な名前空間を含める
このガイドに含まれているコード スニペットを使用するには、クラス ファイルに以下の `using` ステートメントを記述する必要があります。

```csharp
using System.Runtime.Serialization.Json;
using Windows.Foundation.Collections;
using Windows.System.RemoteSystems;
```

## <a name="create-a-remote-session"></a>リモート セッション作成する

リモート セッション インスタンスを作成するには、**[RemoteSystemSessionController](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioncontroller)** オブジェクトから開始する必要があります。 新しいセッションを作成し、他のデバイスからの参加要求を処理するには、以下のフレームワークを使用します。

```csharp
public async void CreateSession() {
    
    // create a session controller
    RemoteSystemSessionController manager = new RemoteSystemSessionController("Bob’s Minecraft game");
    
    // register the following code to handle the JoinRequested event
    manager.JoinRequested += async (sender, args) => {
        // Get the deferral
        var deferral = args.GetDeferral();
        
        // display the participant (args.JoinRequest.Participant) on UI, giving the 
        // user an opportunity to respond
        // ...
        
        // If the user chooses "accept", accept this remote system as a participant
        args.JoinRequest.Accept();
    };
    
    // create and start the session
    RemoteSystemSessionCreationResult createResult = await manager.CreateSessionAsync();
    
    // handle the creation result
    if (createResult.Status == RemoteSystemSessionCreationStatus.Success) {
        // creation was successful, get a reference to the session
        RemoteSystemSession currentSession = createResult.Session;
        
        // optionally subscribe to the disconnection event
        currentSession.Disconnected += async (sender, args) => {
            // update the UI, using args.Reason
            //...
        };
    
        // Use session (see later section)
        //...
    
    } else if (createResult.Status == RemoteSystemSessionCreationStatus.SessionLimitsExceeded) {
        // creation failed. Optionally update UI to indicate that there are too many sessions in progress
    } else {
        // creation failed for an unknown reason. Optionally update UI
    }
}
```

### <a name="make-a-remote-session-invite-only"></a>リモート セッションを招待のみに設定する

リモート セッションを一般に公開しない場合は、招待のみに設定することができます。 招待を受け取ったデバイスのみが参加要求を送信できます。 

手順は上記とほとんど同じですが、**[RemoteSystemSessionController](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioncontroller)** インスタンスを作成する際には、構成済みの **[RemoteSystemSessionOptions](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.RemoteSystemSessionOptions)** オブジェクトを渡します。

```csharp
// define the session options with the invite-only designation
RemoteSystemSessionOptions sessionOptions = new RemoteSystemSessionOptions();
sessionOptions.IsInviteOnly = true;

// create the session controller
RemoteSystemSessionController manager = new RemoteSystemSessionController("Bob's Minecraft game", sessionOptions);

//...
```

招待を送信するには、受信側のリモート システムへの参照 (通常のリモート システム検出を使用して取得) が必要です。 この参照をセッション オブジェクトの **[SendInvitationAsync](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsession.sendinvitationasync)** メソッドに渡します。 すべてのセッション参加者がリモート セッションへの参照にアクセスできるため (次のセクションをご覧ください)、どの参加者も招待を送信することができます。

```csharp
// "currentSession" is a reference to a RemoteSystemSession.
// "guestSystem" is a previously discovered RemoteSystem instance
currentSession.SendInvitationAsync(guestSystem); 
```

## <a name="discover-and-join-a-remote-session"></a>リモート セッションを検出して参加する

リモート セッションを検出するプロセスは、個々のリモート システムの検出に似ており、**[RemoteSystemSessionWatcher](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionwatcher)** クラスによって処理されます。

```csharp
public void DiscoverSessions() {
    
    // create a watcher for remote system sessions
    RemoteSystemSessionWatcher sessionWatcher = RemoteSystemSession.CreateWatcher();
    
    // register a handler for the "added" event
    sessionWatcher.Added += async (sender, args) => {
        
        // get a reference to the info about the discovered session
        RemoteSystemSessionInfo sessionInfo = args.SessionInfo;
        
        // Optionally update the UI with the sessionInfo.DisplayName and 
        // sessionInfo.ControllerDisplayName strings. 
        // Save a reference to this RemoteSystemSessionInfo to use when the
        // user selects this session from the UI
        //...
    };
    
    // Begin watching
    sessionWatcher.Start();
}
```

取得した **[RemoteSystemSessionInfo](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioninfo)** インスタンスは、対応するセッションを制御するデバイスへの参加要求を発行するために使用します。 参加要求が受け入れられると、参加するセッションへの参照が含まれた **[RemoteSystemSessionJoinResult](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionjoinresult)** オブジェクトが返されます。

```csharp
public async void JoinSession(RemoteSystemSessionInfo sessionInfo) {

    // issue a join request and wait for result.
    RemoteSystemSessionJoinResult joinResult = await sessionInfo.JoinAsync();
    if (joinResult.Status == RemoteSystemSessionJoinStatus.Success) {
        // Join request was approved

        // RemoteSystemSession instance "currentSession" was declared at class level.
        // Assign the value obtained from the join result.
        currentSession = joinResult.Session;
        
        // note connection and register to handle disconnection event
        bool isConnected = true;
        currentSession.Disconnected += async (sender, args) => {
            isConnected = false;

            // update the UI with args.Reason value
        };
        
        if (isConnected) {
            // optionally use the session here (see next section)
            //...
        }
    } else {
        // Join was unsuccessful.
        // Update the UI, using joinResult.Status value to show cause of failure.
    }
}
```

同じデバイスが同時に複数のセッションに参加することもできます。 このため、参加のための機能は、各セッションと実際のやり取りから分離する方が望ましい場合があります。 アプリ内で **[RemoteSystemSession](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsession)** インスタンスへの参照が維持されている限り、そのセッションでの通信を試行できます。

## <a name="share-messages-and-data-through-a-remote-session"></a>リモート セッションを介してメッセージとデータを共有する

### <a name="receive-messages"></a>メッセージを受信する

セッション内では、他の参加デバイスとメッセージやデータを交換できます。これには、セッション全体の単一通信チャネルを表す **[RemoteSystemSessionMessageChannel](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionmessagechannel)** インスタンスを使用します。 このインスタンスは、初期化されるとすぐに受信メッセージのリッスンを開始します。

>[!NOTE]
>メッセージの送受信時には、バイト配列からのシリアル化および逆シリアル化を行う必要があります。 次の例にはこの機能が含まれていますが、コードのモジュール性を高めるために、別途実装することもできます。 その例については、[サンプル アプリ](https://github.com/microsoft/Windows-appsample-remote-system-sessions)をご覧ください。

```csharp
public async void StartReceivingMessages() {
    
    // Initialize. The channel name must be known by all participant devices 
    // that will communicate over it.
    RemoteSystemSessionMessageChannel messageChannel = new RemoteSystemSessionMessageChannel(currentSession, 
        "Everyone in Bob's Minecraft game", 
        RemoteSystemSessionMessageChannelReliability.Reliable);
    
    // write the handler for incoming messages on this channel
    messageChannel.ValueSetReceived += async (sender, args) => {
        
        // Update UI: a message was received from the participant args.Sender
        
        // Deserialize the message 
        // (this app must know what key to use and what object type the value is expected to be)
        ValueSet receivedMessage = args.Message;
        object rawData = receivedMessage["appKey"]);
        object value = new ExpectedType(); // this must be whatever type is expected

        using (var stream = new MemoryStream((byte[])rawData)) {
            value = new DataContractJsonSerializer(value.GetType()).ReadObject(stream);
        }
        
        // do something with the "value" object
        //...
    };
}
```

### <a name="send-messages"></a>メッセージを送信する

チャネルが確立されると、すべてのセッション参加者へのメッセージ送信は簡単です。

```csharp
public async void SendMessageToAllParticipantsAsync(RemoteSystemSessionMessageChannel messageChannel, object value){

    // define a ValueSet message to send
    ValueSet message = new ValueSet();
    
    // serialize the "value" object to send
    using (var stream = new MemoryStream()){
        new DataContractJsonSerializer(value.GetType()).WriteObject(stream, value);
        byte[] rawData = stream.ToArray();
            message["appKey"] = rawData;
    }
    
    // Send message to all participants. Ordering is not guaranteed.
    await messageChannel.BroadcastValueSetAsync(message);
}
```

特定の参加者だけにメッセージを送信するには、まずセッションに参加しているリモート システムへの参照を取得する検出プロセスを開始する必要があります。 これは、セッションの外部でリモート システムを検出するプロセスと似ています。 セッションに参加しているデバイスを検出するには、**[RemoteSystemSessionParticipantWatcher](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionparticipantwatcher)** インスタンスを使用します。

```csharp
public void WatchForParticipants() {
    // "currentSession" is a reference to a RemoteSystemSession.
    RemoteSystemSessionParticipantWatcher watcher = currentSession.CreateParticipantWatcher();

    watcher.Added += (sender, participant) => {
        // save a reference to "participant"
        // optionally update UI
    };   

    watcher.Removed += (sender, participant) => {
        // remove reference to "participant"
        // optionally update UI
    };

    watcher.EnumerationCompleted += (sender, args) => {
        // Apps can delay data model render up until this point if they wish.
    };

    // Begin watching for session participants
    watcher.Start();
}
```

セッション参加者への参照の一覧を取得した場合は、参加者のすべてまたは一部にメッセージを送信できます。

単一参加者 (画面でのユーザーによる選択が望ましい) のみにメッセージを送信するには、次のようなメソッドに参照を渡します。

```csharp
public async void SendMessageToParticipantAsync(RemoteSystemSessionMessageChannel messageChannel, RemoteSystemSessionParticipant participant, object value) {
    
    // define a ValueSet message to send
    ValueSet message = new ValueSet();
    
    // serialize the "value" object to send
    using (var stream = new MemoryStream()){
        new DataContractJsonSerializer(value.GetType()).WriteObject(stream, value);
        byte[] rawData = stream.ToArray();
            message["appKey"] = rawData;
    }

    // Send message to the participant
    await messageChannel.SendValueSetAsync(message,participant);
}
```

複数の参加者 (画面でのユーザーによる選択が望ましい) にメッセージを送信するには、対象をリスト オブジェクトに追加し、そのリストを次のようなメソッドに渡します。

```csharp
public async void SendMessageToListAsync(RemoteSystemSessionMessageChannel messageChannel, IReadOnlyList<RemoteSystemSessionParticipant> myTeam, object value){

    // define a ValueSet message to send
    ValueSet message = new ValueSet();
    
    // serialize the "value" object to send
    using (var stream = new MemoryStream()){
        new DataContractJsonSerializer(value.GetType()).WriteObject(stream, value);
        byte[] rawData = stream.ToArray();
            message["appKey"] = rawData;
    }

    // Send message to specific participants. Ordering is not guaranteed.
    await messageChannel.SendValueSetToParticipantsAsync(message, myTeam);   
}
```

## <a name="related-topics"></a>関連トピック
* [接続されるアプリやデバイス ("Rome" プロジェクト)](connected-apps-and-devices.md)
* [リモート システムの API リファレンス](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)
