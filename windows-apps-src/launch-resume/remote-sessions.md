---
author: PatrickFarley
title: "リモート セッションでデバイスを接続する"
description: "リモート セッションで複数のデバイスを結合することにより、これらのデバイス間で共有エクスペリエンスを作成します。"
ms.assetid: 1c8dba9f-c933-4e85-829e-13ad784dd3e2
ms.author: pafarley
ms.date: 06/28/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9096a93005c628a5cf1f3271fbab3cca2399b75d
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
---
# <a name="connect-devices-through-remote-sessions"></a><span data-ttu-id="30edc-104">リモート セッションでデバイスを接続する</span><span class="sxs-lookup"><span data-stu-id="30edc-104">Connect devices through remote sessions</span></span>

<span data-ttu-id="30edc-105">リモート セッション機能を使用すると、セッションを介してアプリを他のデバイスに接続できます。これは明示的なアプリ メッセージングや、ブローカーによるシステム管理データ (Windows Holographic デバイス間のホログラフィック共有に使用する **[SpatialEntityStore](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialentitystore)** など) の交換を目的としています。</span><span class="sxs-lookup"><span data-stu-id="30edc-105">The Remote Sessions feature allows an app to connect to other devices through a session, either for explicit app messaging or for brokered exchange of system-managed data, such as the **[SpatialEntityStore](https://docs.microsoft.com/uwp/api/windows.perception.spatial.spatialentitystore)** for holographic sharing between Windows Holographic devices.</span></span>

<span data-ttu-id="30edc-106">リモート セッションはどの Windows デバイスでも作成でき、(他のユーザーがサインインしているデバイスを含めて) どの Windows デバイスでも参加を要求できます (セッションによっては招待のみの可視性が適用されることがあります)。</span><span class="sxs-lookup"><span data-stu-id="30edc-106">Remote sessions can be created by any Windows device, and any Windows device can request to join (although sessions can have invite-only visibility), including devices signed in by other users.</span></span> <span data-ttu-id="30edc-107">このガイドには、リモート セッションを利用するあらゆる主要なシナリオの基本的なサンプル コードを記載しています。</span><span class="sxs-lookup"><span data-stu-id="30edc-107">This guide provides basic sample code for all of the major scenarios that make use of remote sessions.</span></span> <span data-ttu-id="30edc-108">このコードは、既存のアプリ プロジェクトに組み込み、必要に応じて変更できます。</span><span class="sxs-lookup"><span data-stu-id="30edc-108">This code can be incorporated into an existing app project and modified as necessary.</span></span> <span data-ttu-id="30edc-109">エンド ツー エンド実装については、[クイズ ゲームのサンプル アプリ](https://github.com/microsoft/Windows-appsample-remote-system-sessions)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="30edc-109">For an end-to-end implementation, see the [Quiz Game sample app](https://github.com/microsoft/Windows-appsample-remote-system-sessions)).</span></span>

## <a name="preliminary-setup"></a><span data-ttu-id="30edc-110">準備段階のセットアップ</span><span class="sxs-lookup"><span data-stu-id="30edc-110">Preliminary setup</span></span>

### <a name="add-the-remotesystem-capability"></a><span data-ttu-id="30edc-111">remoteSystem 機能を追加する</span><span class="sxs-lookup"><span data-stu-id="30edc-111">Add the remoteSystem capability</span></span>

<span data-ttu-id="30edc-112">アプリでリモート デバイスのアプリを起動するには、`remoteSystem` 機能をアプリ パッケージ マニフェストに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-112">In order for your app to launch an app on a remote device, you must add the `remoteSystem` capability to your app package manifest.</span></span> <span data-ttu-id="30edc-113">これには、マニフェスト デザイナーで **[機能]** タブの **[リモート システム]** を選んで追加するか、プロジェクトの Package.appxmanifest ファイルに以下のコードを手動で追加します。</span><span class="sxs-lookup"><span data-stu-id="30edc-113">You can use the package manifest designer to add it by selecting **Remote System** on the **Capabilities** tab, or you can manually add the following line to your project's Package.appxmanifest file.</span></span>

``` xml
<Capabilities>
   <uap3:Capability Name="remoteSystem"/>
</Capabilities>
```

### <a name="enable-cross-user-discovering-on-the-device"></a><span data-ttu-id="30edc-114">デバイスでユーザー間の検出を有効にする</span><span class="sxs-lookup"><span data-stu-id="30edc-114">Enable cross-user discovering on the device</span></span>
<span data-ttu-id="30edc-115">リモート セッションには、複数の異なるユーザーどうしの接続を目的とした機能が備えられているため、各デバイスでユーザー間の共有を有効にしておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-115">Remote Sessions is geared toward connecting multiple different users, so the devices involved will need to have Cross-User Sharing enabled.</span></span> <span data-ttu-id="30edc-116">このシステム設定は、次のように **RemoteSystem** クラスで静的メソッドを使用することで照会できます。</span><span class="sxs-lookup"><span data-stu-id="30edc-116">This is a system setting that can be queried with a static method in the **RemoteSystem** class:</span></span>

```csharp
if (!RemoteSystem.IsAuthorizationKindEnabled(RemoteSystemAuthorizationKind.Anonymous)) {
    // The system is not authorized to connect to cross-user devices. 
    // Inform the user that they can discover more devices if they
    // update the setting to "Everyone nearby".
}
```

<span data-ttu-id="30edc-117">この設定を変更するには、ユーザーが**設定**アプリを開く必要があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-117">To change this setting, the user must open the **Settings** app.</span></span> <span data-ttu-id="30edc-118">**[システム]** > **[共有エクスペリエンス]** > **[デバイス間で共有します]** メニューの順に移動すると、システムで共有可能なデバイスをユーザーが指定できるドロップダウン ボックスがあります。</span><span class="sxs-lookup"><span data-stu-id="30edc-118">In the **System** > **Shared experiences** > **Share across devices** menu, there is a drop-down box where the user can specify which devices their system can share with.</span></span>

![[共有エクスペリエンス] 設定ページ](images/shared-experiences-settings.png)

### <a name="include-the-necessary-namespaces"></a><span data-ttu-id="30edc-120">必要な名前空間を含める</span><span class="sxs-lookup"><span data-stu-id="30edc-120">Include the necessary namespaces</span></span>
<span data-ttu-id="30edc-121">このガイドに含まれているコード スニペットを使用するには、クラス ファイルに以下の `using` ステートメントを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-121">In order to use all of the code snippets in this guide, you will need the following `using` statements in your class file(s).</span></span>

```csharp
using System.Runtime.Serialization.Json;
using Windows.Foundation.Collections;
using Windows.System.RemoteSystems;
```

## <a name="create-a-remote-session"></a><span data-ttu-id="30edc-122">リモート セッション作成する</span><span class="sxs-lookup"><span data-stu-id="30edc-122">Create a remote session</span></span>

<span data-ttu-id="30edc-123">リモート セッション インスタンスを作成するには、**[RemoteSystemSessionController](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioncontroller)** オブジェクトから開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-123">To create a remote session instance, you must start with a **[RemoteSystemSessionController](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioncontroller)** object.</span></span> <span data-ttu-id="30edc-124">新しいセッションを作成し、他のデバイスからの参加要求を処理するには、以下のフレームワークを使用します。</span><span class="sxs-lookup"><span data-stu-id="30edc-124">Use the following framework to create a new session and handle join requests from other devices.</span></span>

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

### <a name="make-a-remote-session-invite-only"></a><span data-ttu-id="30edc-125">リモート セッションを招待のみに設定する</span><span class="sxs-lookup"><span data-stu-id="30edc-125">Make a remote session invite-only</span></span>

<span data-ttu-id="30edc-126">リモート セッションを一般に公開しない場合は、招待のみに設定することができます。</span><span class="sxs-lookup"><span data-stu-id="30edc-126">If you wish to keep your remote session from being publicly discoverable, you can make it invite-only.</span></span> <span data-ttu-id="30edc-127">招待を受け取ったデバイスのみが参加要求を送信できます。</span><span class="sxs-lookup"><span data-stu-id="30edc-127">Only the devices that receive an invitation will be able to send join requests.</span></span> 

<span data-ttu-id="30edc-128">手順は上記とほとんど同じですが、**[RemoteSystemSessionController](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioncontroller)** インスタンスを作成する際には、構成済みの **[RemoteSystemSessionOptions](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.RemoteSystemSessionOptions)** オブジェクトを渡します。</span><span class="sxs-lookup"><span data-stu-id="30edc-128">The procedure is mostly the same as above, but when constructing the **[RemoteSystemSessionController](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioncontroller)** instance, you will pass in a configured **[RemoteSystemSessionOptions](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.RemoteSystemSessionOptions)** object.</span></span>

```csharp
// define the session options with the invite-only designation
RemoteSystemSessionOptions sessionOptions = new RemoteSystemSessionOptions();
sessionOptions.IsInviteOnly = true;

// create the session controller
RemoteSystemSessionController manager = new RemoteSystemSessionController("Bob's Minecraft game", sessionOptions);

//...
```

<span data-ttu-id="30edc-129">招待を送信するには、受信側のリモート システムへの参照 (通常のリモート システム検出を使用して取得) が必要です。</span><span class="sxs-lookup"><span data-stu-id="30edc-129">To send an invitation, you must have a reference to the receiving remote system (acquired through normal remote system discovery).</span></span> <span data-ttu-id="30edc-130">この参照をセッション オブジェクトの **[SendInvitationAsync](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsession#remotesystemsession_sendinvitationasync_1664759118)** メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="30edc-130">Simply pass this reference into the session object's **[SendInvitationAsync](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsession#remotesystemsession_sendinvitationasync_1664759118)** method.</span></span> <span data-ttu-id="30edc-131">すべてのセッション参加者がリモート セッションへの参照にアクセスできるため (次のセクションをご覧ください)、どの参加者も招待を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="30edc-131">All of the participants in a session have a reference to the remote session (see next section), so any participant can send an invitation.</span></span>

```csharp
// "currentSession" is a reference to a RemoteSystemSession.
// "guestSystem" is a previously discovered RemoteSystem instance
currentSession.SendInvitationAsync(guestSystem); 
```

## <a name="discover-and-join-a-remote-session"></a><span data-ttu-id="30edc-132">リモート セッションを検出して参加する</span><span class="sxs-lookup"><span data-stu-id="30edc-132">Discover and join a remote session</span></span>

<span data-ttu-id="30edc-133">リモート セッションを検出するプロセスは、個々のリモート システムの検出に似ており、**[RemoteSystemSessionWatcher](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionwatcher)** クラスによって処理されます。</span><span class="sxs-lookup"><span data-stu-id="30edc-133">The process of discovering remote sessions is handled by the **[RemoteSystemSessionWatcher](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionwatcher)** class and is similar to discovering individual remote systems.</span></span>

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

<span data-ttu-id="30edc-134">取得した **[RemoteSystemSessionInfo](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioninfo)** インスタンスは、対応するセッションを制御するデバイスへの参加要求を発行するために使用します。</span><span class="sxs-lookup"><span data-stu-id="30edc-134">When a **[RemoteSystemSessionInfo](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessioninfo)** instance is obtained, it can be used to issue a join request to the device that controls the corresponding session.</span></span> <span data-ttu-id="30edc-135">参加要求が受け入れられると、参加するセッションへの参照が含まれた **[RemoteSystemSessionJoinResult](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionjoinresult)** オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="30edc-135">An accepted join request will asynchronously return a **[RemoteSystemSessionJoinResult](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionjoinresult)** object that contains a reference to the joined session.</span></span>

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

<span data-ttu-id="30edc-136">同じデバイスが同時に複数のセッションに参加することもできます。</span><span class="sxs-lookup"><span data-stu-id="30edc-136">A device can be joined to multiple sessions at the same time.</span></span> <span data-ttu-id="30edc-137">このため、参加のための機能は、各セッションと実際のやり取りから分離する方が望ましい場合があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-137">For this reason, it may be desirable to separate the joining functionality from the actual interaction with each session.</span></span> <span data-ttu-id="30edc-138">アプリ内で **[RemoteSystemSession](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsession)** インスタンスへの参照が維持されている限り、そのセッションでの通信を試行できます。</span><span class="sxs-lookup"><span data-stu-id="30edc-138">As long as a reference to the **[RemoteSystemSession](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsession)** instance is maintained in the app, communication can be attempted over that session.</span></span>

## <a name="share-messages-and-data-through-a-remote-session"></a><span data-ttu-id="30edc-139">リモート セッションを介してメッセージとデータを共有する</span><span class="sxs-lookup"><span data-stu-id="30edc-139">Share messages and data through a remote session</span></span>

### <a name="receive-messages"></a><span data-ttu-id="30edc-140">メッセージを受信する</span><span class="sxs-lookup"><span data-stu-id="30edc-140">Receive messages</span></span>

<span data-ttu-id="30edc-141">セッション内では、他の参加デバイスとメッセージやデータを交換できます。これには、セッション全体の単一通信チャネルを表す **[RemoteSystemSessionMessageChannel](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionmessagechannel)** インスタンスを使用します。</span><span class="sxs-lookup"><span data-stu-id="30edc-141">You can exchange messages and data with other participant devices in the session by using a **[RemoteSystemSessionMessageChannel](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionmessagechannel)** instance, which represents a single session-wide communication channel.</span></span> <span data-ttu-id="30edc-142">このインスタンスは、初期化されるとすぐに受信メッセージのリッスンを開始します。</span><span class="sxs-lookup"><span data-stu-id="30edc-142">As soon as it's initialized, it begins listening for incoming messages.</span></span>

>[!NOTE]
><span data-ttu-id="30edc-143">メッセージの送受信時には、バイト配列からのシリアル化および逆シリアル化を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-143">Messages must be serialized and deserialized from byte arrays upon sending and receiving.</span></span> <span data-ttu-id="30edc-144">次の例にはこの機能が含まれていますが、コードのモジュール性を高めるために、別途実装することもできます。</span><span class="sxs-lookup"><span data-stu-id="30edc-144">This functionality is included in the following examples, but it can be implemented separately for better code modularity.</span></span> <span data-ttu-id="30edc-145">その例については、[サンプル アプリ](https://github.com/microsoft/Windows-appsample-remote-system-sessions)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="30edc-145">See the [sample app](https://github.com/microsoft/Windows-appsample-remote-system-sessions)) for an example of this.</span></span>

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

### <a name="send-messages"></a><span data-ttu-id="30edc-146">メッセージを送信する</span><span class="sxs-lookup"><span data-stu-id="30edc-146">Send messages</span></span>

<span data-ttu-id="30edc-147">チャネルが確立されると、すべてのセッション参加者へのメッセージ送信は簡単です。</span><span class="sxs-lookup"><span data-stu-id="30edc-147">When the channel is established, sending a message to all of the session participants is straightforward.</span></span>

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

<span data-ttu-id="30edc-148">特定の参加者だけにメッセージを送信するには、まずセッションに参加しているリモート システムへの参照を取得する検出プロセスを開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="30edc-148">In order to send a message to only certain participant(s), you must first initiate a discovery process to acquire references to the remote systems participating in the session.</span></span> <span data-ttu-id="30edc-149">これは、セッションの外部でリモート システムを検出するプロセスと似ています。</span><span class="sxs-lookup"><span data-stu-id="30edc-149">This is similar to the process of discovering remote systems outside of a session.</span></span> <span data-ttu-id="30edc-150">セッションに参加しているデバイスを検出するには、**[RemoteSystemSessionParticipantWatcher](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionparticipantwatcher)** インスタンスを使用します。</span><span class="sxs-lookup"><span data-stu-id="30edc-150">Use a **[RemoteSystemSessionParticipantWatcher](https://docs.microsoft.com/uwp/api/windows.system.remotesystems.remotesystemsessionparticipantwatcher)** instance to find a session's participant devices.</span></span>

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

<span data-ttu-id="30edc-151">セッション参加者への参照の一覧を取得した場合は、参加者のすべてまたは一部にメッセージを送信できます。</span><span class="sxs-lookup"><span data-stu-id="30edc-151">When a list of references to session participants is obtained you can send a message to any set of them.</span></span>

<span data-ttu-id="30edc-152">単一参加者 (画面でのユーザーによる選択が望ましい) のみにメッセージを送信するには、次のようなメソッドに参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="30edc-152">To send a message to a single participant (ideally selected on-screen by the user), simply pass the reference into a method like the following.</span></span>

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

<span data-ttu-id="30edc-153">複数の参加者 (画面でのユーザーによる選択が望ましい) にメッセージを送信するには、対象をリスト オブジェクトに追加し、そのリストを次のようなメソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="30edc-153">To send a message to multiple participants (ideally selected on-screen by the user), add them to a list object and pass the list into a method like the following.</span></span>

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

## <a name="related-topics"></a><span data-ttu-id="30edc-154">関連トピック</span><span class="sxs-lookup"><span data-stu-id="30edc-154">Related topics</span></span>
* [<span data-ttu-id="30edc-155">接続されるアプリやデバイス ("Rome" プロジェクト)</span><span class="sxs-lookup"><span data-stu-id="30edc-155">Connected apps and devices (Project Rome)</span></span>](connected-apps-and-devices.md)
* [<span data-ttu-id="30edc-156">リモート システムの API リファレンス</span><span class="sxs-lookup"><span data-stu-id="30edc-156">Remote Systems API reference</span></span>](https://msdn.microsoft.com/library/windows/apps/Windows.System.RemoteSystems)
