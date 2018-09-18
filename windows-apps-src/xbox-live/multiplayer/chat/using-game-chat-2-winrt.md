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
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4017281"
---
# <a name="using-game-chat-2-winrt-projections"></a><span data-ttu-id="72201-104">ゲーム チャット 2 (WinRT プロジェクション) の使用</span><span class="sxs-lookup"><span data-stu-id="72201-104">Using Game Chat 2 (WinRT Projections)</span></span>

<span data-ttu-id="72201-105">ここでは、ゲーム チャット 2 の C# API の使用方法について概要を紹介します。</span><span class="sxs-lookup"><span data-stu-id="72201-105">This is a brief walkthrough on using Game Chat 2's C# API.</span></span> <span data-ttu-id="72201-106">C++ を通じたゲーム チャット 2 へのアクセスを予定しているゲーム開発者は、「[ゲーム チャット 2 の使用](using-game-chat-2.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="72201-106">Game developers wanting to access Game Chat 2 through C++ should see [Using Game Chat 2](using-game-chat-2.md).</span></span>

1. [<span data-ttu-id="72201-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="72201-107">Prerequisites</span></span>](#prereq)
2. [<span data-ttu-id="72201-108">初期化</span><span class="sxs-lookup"><span data-stu-id="72201-108">Initialization</span></span>](#init)
3. [<span data-ttu-id="72201-109">ユーザーの構成</span><span class="sxs-lookup"><span data-stu-id="72201-109">Configuring users</span></span>](#config)
4. [<span data-ttu-id="72201-110">データ フレームの処理</span><span class="sxs-lookup"><span data-stu-id="72201-110">Processing data frames</span></span>](#data)
5. [<span data-ttu-id="72201-111">状態変更の処理</span><span class="sxs-lookup"><span data-stu-id="72201-111">Processing state changes</span></span>](#state)
6. [<span data-ttu-id="72201-112">テキスト チャット</span><span class="sxs-lookup"><span data-stu-id="72201-112">Text chat</span></span>](#text)
7. [<span data-ttu-id="72201-113">ユーザー補助</span><span class="sxs-lookup"><span data-stu-id="72201-113">Accessibility</span></span>](#access)
8. [<span data-ttu-id="72201-114">UI</span><span class="sxs-lookup"><span data-stu-id="72201-114">UI</span></span>](#UI)
9. [<span data-ttu-id="72201-115">ミュート</span><span class="sxs-lookup"><span data-stu-id="72201-115">Muting</span></span>](#mute)
10. [<span data-ttu-id="72201-116">悪い評判の自動ミュート</span><span class="sxs-lookup"><span data-stu-id="72201-116">Bad reputation auto-mute</span></span>](#automute)
11. [<span data-ttu-id="72201-117">権限とプライバシー</span><span class="sxs-lookup"><span data-stu-id="72201-117">Privilege and privacy</span></span>](#priv)
12. [<span data-ttu-id="72201-118">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="72201-118">Cleanup</span></span>](#cleanup)
13. [<span data-ttu-id="72201-119">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="72201-119">How to configure popular scenarios</span></span>](#how-to-configure-popular-scenarios)

## <a name="prerequisites-a-nameprereq"></a><span data-ttu-id="72201-120">前提条件<a name="prereq"></span><span class="sxs-lookup"><span data-stu-id="72201-120">Prerequisites <a name="prereq"></span></span>

<span data-ttu-id="72201-121">ゲーム チャット 2 を使うには、[Microsoft.Xbox.Services.GameChat2 nuget パッケージ](https://www.nuget.org/packages/Microsoft.Xbox.Game.Chat.2.WinRT.UWP/)を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-121">In order to consume Game Chat 2, you must include the [Microsoft.Xbox.Services.GameChat2 nuget package](https://www.nuget.org/packages/Microsoft.Xbox.Game.Chat.2.WinRT.UWP/).</span></span>

<span data-ttu-id="72201-122">ゲーム チャット 2 のコーディングを始める前に、"マイク" デバイス機能を宣言するアプリの AppXManifest を構成している必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-122">Before you get started coding with Game Chat 2, you must have configured your app's AppXManifest to declare the "microphone" device capability.</span></span> <span data-ttu-id="72201-123">AppXManifest 機能については、プラットフォームのドキュメントの各セクションで詳しく説明されています。次のスニペットは、パッケージ/機能ノードの下に存在している必要があり、存在しないとチャットがブロックされる "マイク" デバイス機能ノードを示しています。</span><span class="sxs-lookup"><span data-stu-id="72201-123">AppXManifest capabilities are described in more detail in their respective sections of the platform documentation; the following snippet shows the "microphone" device capability node that should exist under the Package/Capabilities node or else chat will be blocked:</span></span>

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

## <a name="initialization-a-nameinit"></a><span data-ttu-id="72201-124">初期化 <a name="init"></span><span class="sxs-lookup"><span data-stu-id="72201-124">Initialization <a name="init"></span></span>

<span data-ttu-id="72201-125">インスタンスに追加されると予想される同時チャット ユーザーの最大数を設定した `GameChat2ChatManager` オブジェクトをインスタンス化することにより、ライブラリの操作を開始します。</span><span class="sxs-lookup"><span data-stu-id="72201-125">You begin interacting with the library by instantiating a `GameChat2ChatManager` object with the maximum number of concurrent chat users expected to be added to the instance.</span></span> <span data-ttu-id="72201-126">この値を変更するには、`GameChat2ChatManager` オブジェクトを破棄し、目的の値で再作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-126">To change this value, the `GameChat2ChatManager` object must be disposed and recreated with the desired value.</span></span> <span data-ttu-id="72201-127">一度にインスタンス化できる `GameChat2ChatManager` は 1 つだけです。</span><span class="sxs-lookup"><span data-stu-id="72201-127">You may only have one `GameChat2ChatManager` instantiated at a time.</span></span>

```cs
GameChat2ChatManager myGameChat2ChatManager = new GameChat2ChatManager(<maxChatUserCount>);
```

<span data-ttu-id="72201-128">`GameChat2ChatManager` オブジェクトは、いつでも構成可能な追加のオプション プロパティです。</span><span class="sxs-lookup"><span data-stu-id="72201-128">The `GameChat2ChatManager` object has additional, optional properties that may be configured at anytime.</span></span> <span data-ttu-id="72201-129">次のコード サンプルでは、`myGameChat2ChatManager` オブジェクトでプロパティの設定に使用される前に変数に値が与えられると想定しています。</span><span class="sxs-lookup"><span data-stu-id="72201-129">The following code sample assumes that the variables will be given a value before they are used to set the properties on the `myGameChat2ChatManager` object.</span></span>

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

## <a name="configuring-users-a-nameconfig"></a><span data-ttu-id="72201-130">ユーザーの構成 <a name="config"></span><span class="sxs-lookup"><span data-stu-id="72201-130">Configuring users <a name="config"></span></span>

<span data-ttu-id="72201-131">インスタンスが初期化されたら、GC2 インスタンスにローカル ユーザーを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-131">Once the instance is initialized, you must add the local users to the GC2 instance.</span></span> <span data-ttu-id="72201-132">この例では、ユーザー A はローカル ユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="72201-132">In this example, User A will represent a local user.</span></span>

```cs
string userAXuid;

...

IGameChat2ChatUser userA = myGameChat2ChatManager.AddLocalUser(userAXuid);
```

<span data-ttu-id="72201-133">次に、リモート ユーザーと識別子 (各リモート ユーザーがいるリモート "エンドポイント" を表すために使用) を追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-133">You must then add the remote users and identifers that will be used to represent the remote "Endpoints" that each remote user is on.</span></span> <span data-ttu-id="72201-134">"エンドポイント" は、`IGameChat2Endpoint` インターフェイスを実装するアプリが所有するオブジェクトによって表されます。</span><span class="sxs-lookup"><span data-stu-id="72201-134">"Endpoints" are represented by objects owned by the app that implement the `IGameChat2Endpoint` interface.</span></span> <span data-ttu-id="72201-135">次の例は、`IGameChat2Endpoint` を実装する `MyEndpoint` クラスのサンプル実装を示しています。</span><span class="sxs-lookup"><span data-stu-id="72201-135">The following example shows a sample implementation of `MyEndpoint` class that implements the `IGameChat2Endpoint`.</span></span>

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

<span data-ttu-id="72201-136">次のコード例では、ユーザー B、C、D は追加されるリモート ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="72201-136">In the following code example, users B, C, and D are remote users being added.</span></span> <span data-ttu-id="72201-137">ユーザー B は 1 つのリモート デバイスにおり、ユーザー C および D は別のリモート デバイスにいます。</span><span class="sxs-lookup"><span data-stu-id="72201-137">User B is on one remote device and users C and D are on another remote device.</span></span> <span data-ttu-id="72201-138">この例では、変数が設定されること、`myGameChat2ChatManager` が `GameChat2ChatManager` のインスタンスであること、"MyEndpoint" が `IGameChat2Endpoint` を実装するクラスであることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="72201-138">This example assumes that the variables will be set and that `myGameChat2ChatManager` is an instance of `GameChat2ChatManager` and that "MyEndpoint" is a class that implements `IGameChat2Endpoint`.</span></span>

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

<span data-ttu-id="72201-139">これで、各リモート ユーザーとローカル ユーザーとの間の通信リレーションシップが構成されました。</span><span class="sxs-lookup"><span data-stu-id="72201-139">Now you configure the communication relationship between each remote user and the local user.</span></span> <span data-ttu-id="72201-140">この例では、ユーザー A とユーザー B が同じチームに属しており、双方向通信が許可されていると仮定します。</span><span class="sxs-lookup"><span data-stu-id="72201-140">In this example, suppose that User A and User B are on the same team and bidirectional communication is allowed.</span></span> `GameChat2CommunicationRelationship.SendAndReceiveAll` <span data-ttu-id="72201-141">は、双方向通信を表すように定義されています。</span><span class="sxs-lookup"><span data-stu-id="72201-141">is defined to represent bi-directional communication.</span></span> <span data-ttu-id="72201-142">ユーザー A のユーザー B に対するリレーションシップを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="72201-142">Set User A's relationship to User B with:</span></span>

```cs
GameChat2ChatUserLocal localUserA = userA as GameChat2ChatUserLocal;
localUserA.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.SendAndReceiveAll);
```

<span data-ttu-id="72201-143">次に、ユーザー C とユーザー D は "観戦者" であり、ユーザー A を一覧に表示することはできますが、会話は許可されていないと仮定します。</span><span class="sxs-lookup"><span data-stu-id="72201-143">Now suppose that Users C and D are 'spectators' and should be allowed to listen to User A, but not speak.</span></span> `GameChat2CommunicationRelationship.ReceiveAll` <span data-ttu-id="72201-144">は定義されたこの単方向通信です。</span><span class="sxs-lookup"><span data-stu-id="72201-144">is a defined this unidirectional communication.</span></span> <span data-ttu-id="72201-145">リレーションシップを次のように設定します。</span><span class="sxs-lookup"><span data-stu-id="72201-145">Set the relationships with:</span></span>

```cs
localUserA.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.ReceiveAll);
localUserA.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.ReceiveAll);
```

<span data-ttu-id="72201-146">任意の時点で、`GameChat2ChatManager` インスタンスに追加されているがローカル ユーザーと通信できるように構成されていないリモート ユーザーがいても問題ありません。</span><span class="sxs-lookup"><span data-stu-id="72201-146">If at any point there are remote users that have been added to the `GameChat2ChatManager` instance but haven't been configured to communicate with any local users - that's okay!</span></span> <span data-ttu-id="72201-147">これは、ユーザーがチームを決定中か、会話チャネルを任意に変更できるシナリオで発生する場合があります。</span><span class="sxs-lookup"><span data-stu-id="72201-147">This may be expected in scenarios where users are determining teams or can change speaking channels arbitrarily.</span></span> <span data-ttu-id="72201-148">ゲーム チャット 2 がキャッシュするのは、インスタンスに追加されたユーザーの情報 (プライバシー リレーションシップと評判) だけであるため、すべてのユーザー候補について、そのユーザーが特定の時点でローカル ユーザーと会話できない場合でも、ゲーム チャット 2 に通知すると役立ちます。</span><span class="sxs-lookup"><span data-stu-id="72201-148">Game Chat 2 will only cache information (e.g. privacy relationships and reputation) for users that have been added to the instance, so it's useful to inform Game Chat 2 of all possible users even if they can't speak to any local users at a particular point in time.</span></span>

<span data-ttu-id="72201-149">最後の点として、ユーザー D がゲームを終了したため、ローカル ゲーム チャット 2 インスタンスから削除する必要があるとします。</span><span class="sxs-lookup"><span data-stu-id="72201-149">Finally, suppose that User D has left the game and should be removed from the local Game Chat 2 instance.</span></span> <span data-ttu-id="72201-150">これは、次の呼び出しで実行できます。</span><span class="sxs-lookup"><span data-stu-id="72201-150">That can be done with the following call:</span></span>

```cs
remoteUserD.Remove();
```

<span data-ttu-id="72201-151">`Remove()` が呼び出されるとすぐにユーザー オブジェクトは無効になります。</span><span class="sxs-lookup"><span data-stu-id="72201-151">The user object is invalidated immediately when `Remove()` is called.</span></span> <span data-ttu-id="72201-152">ユーザーの最後の状態は、削除されるときにキャッシュされます。</span><span class="sxs-lookup"><span data-stu-id="72201-152">The last state of the user is cached when it is removed.</span></span> <span data-ttu-id="72201-153">ユーザー オブジェクトが無効になった後で呼び出される情報メソッドは、削除される前のユーザーの状態を反映します。</span><span class="sxs-lookup"><span data-stu-id="72201-153">Any informational methods called after the user object is invalidated will reflect the user's state before it was removed.</span></span> <span data-ttu-id="72201-154">他のメソッドは、呼び出されるとエラーをスローします。</span><span class="sxs-lookup"><span data-stu-id="72201-154">Other methods will throw an error when called.</span></span>

## <a name="processing-data-frames-a-namedata"></a><span data-ttu-id="72201-155">データ フレームの処理 <a name="data"></span><span class="sxs-lookup"><span data-stu-id="72201-155">Processing data frames <a name="data"></span></span>

<span data-ttu-id="72201-156">ゲーム チャット 2 には独自のトランスポート層はありません。トランスポート層はアプリで提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-156">Game Chat 2 does not have its own transport layer; this must be provided by the app.</span></span> <span data-ttu-id="72201-157">このプラグインは、アプリによる `GameChat2ChatManager.GetDataFrames()` の定期的かつ頻繁な呼び出しです。</span><span class="sxs-lookup"><span data-stu-id="72201-157">This plugin is managed by the app's regular, frequent calls to the `GameChat2ChatManager.GetDataFrames()`.</span></span> <span data-ttu-id="72201-158">このメソッドを使うと、ゲーム チャット 2 は発信データをアプリに提供できます。</span><span class="sxs-lookup"><span data-stu-id="72201-158">This method is how Game Chat 2 provides outgoing data to the app.</span></span> <span data-ttu-id="72201-159">専用のネットワーク スレッドで頻繁にポーリングできるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="72201-159">It is designed to operate quickly such that it can be polled frequently on a dedicated networking thread.</span></span> <span data-ttu-id="72201-160">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべてのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="72201-160">This provides a convenient place to retrieve all queued data without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="72201-161">`GameChat2ChatManager.GetDataFrames()` を呼び出すと、キューに入っているすべてのデータが `IGameChat2DataFrame` オブジェクトのリストで報告されます。</span><span class="sxs-lookup"><span data-stu-id="72201-161">When `GameChat2ChatManager.GetDataFrames()` is called, all queued data is reported in a list of `IGameChat2DataFrame` objects.</span></span> <span data-ttu-id="72201-162">アプリでは、リストを反復処理して、`TargetEndpointIdentifiers` を検査し、アプリのネットワーク層を使用してデータを適切なリモート アプリ インスタンスに配信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-162">Apps should iterate over the list, inspect the `TargetEndpointIdentifiers`, and use the app's networking layer to deliver the data to the appropriate remote app instances.</span></span> <span data-ttu-id="72201-163">この例では、`HandleOutgoingDataFrame` は `Buffer` のデータを、`TransportRequirement` に従って `TargetEndpointIdentifiers` で指定された各 "エンドポイント" の各ユーザーに送信する関数です。</span><span class="sxs-lookup"><span data-stu-id="72201-163">In this example, `HandleOutgoingDataFrame` is a function that sends the data in the `Buffer` to each user on each "Endpoint" specified in the `TargetEndpointIdentifiers` according to the `TransportRequirement`.</span></span>

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

<span data-ttu-id="72201-164">データ フレームの処理頻度が高いほど、エンド ユーザーの感じるオーディオの遅延は低くなります。</span><span class="sxs-lookup"><span data-stu-id="72201-164">The more frequently the data frames are processed, the lower the audio latency apparent to the end user will be.</span></span> <span data-ttu-id="72201-165">オーディオは 40 ミリ秒のデータ フレームに結合されます。これは、推奨されるポーリング期間です。</span><span class="sxs-lookup"><span data-stu-id="72201-165">The audio is coalesced into 40 ms data frames; this is the suggested polling period.</span></span>

## <a name="processing-state-changes-a-namestate"></a><span data-ttu-id="72201-166">状態変更の処理 <a name="state"></span><span class="sxs-lookup"><span data-stu-id="72201-166">Processing state changes <a name="state"></span></span>

<span data-ttu-id="72201-167">ゲーム チャット 2 では、アプリによる `GameChat2ChatManager.GetStateChanges()` メソッドの定期的かつ頻繁な呼び出しを通じて、受信したテキスト メッセージなどの更新をアプリに提供します。</span><span class="sxs-lookup"><span data-stu-id="72201-167">Game Chat 2 provides updates to the app, such as received text messages, through the app's regular, frequent calls to the `GameChat2ChatManager.GetStateChanges()` method.</span></span> <span data-ttu-id="72201-168">UI レンダリング ループのすべてのグラフィックス フレームで呼び出すことができるよう、素早く動作するように設計されています。</span><span class="sxs-lookup"><span data-stu-id="72201-168">It's designed to operate quickly such that it can be called every graphics frame in your UI rendering loop.</span></span> <span data-ttu-id="72201-169">これを利用することで、ネットワークのタイミングの予測不可能性やマルチスレッド コールバックの複雑さを気にすることなく、キュー内のすべての変更を取得できます。</span><span class="sxs-lookup"><span data-stu-id="72201-169">This provides a convenient place to retrieve all queued changes without worrying about the unpredictability of network timing or multi-threaded callback complexity.</span></span>

<span data-ttu-id="72201-170">`GameChat2ChatManager.GetStateChanges()` を呼び出すと、キューに入っているすべての更新が `IGameChat2StateChange` オブジェクトのリストで報告されます。</span><span class="sxs-lookup"><span data-stu-id="72201-170">When `GameChat2ChatManager.GetStateChanges()` is called, all queued updates are reported in a list of `IGameChat2StateChange` objects.</span></span> <span data-ttu-id="72201-171">アプリは次の処理を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-171">Apps should:</span></span>
1. <span data-ttu-id="72201-172">リストを反復処理する。</span><span class="sxs-lookup"><span data-stu-id="72201-172">Iterate over the list</span></span>
2. <span data-ttu-id="72201-173">具体的な型の基本構造体を検査する。</span><span class="sxs-lookup"><span data-stu-id="72201-173">Inspect the base structure for its more specific type</span></span>
3. <span data-ttu-id="72201-174">基本構造体を対応するより詳細な型にキャストする。</span><span class="sxs-lookup"><span data-stu-id="72201-174">Cast the base structure to the corresponding more detailed type</span></span>
4. <span data-ttu-id="72201-175">必要に応じて更新を処理する。</span><span class="sxs-lookup"><span data-stu-id="72201-175">Handle that update as appropriate.</span></span> 

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

## <a name="text-chat-a-nametext"></a><span data-ttu-id="72201-176">テキスト チャット <a name="text"></span><span class="sxs-lookup"><span data-stu-id="72201-176">Text chat <a name="text"></span></span>

<span data-ttu-id="72201-177">テキスト チャットを送信するには、`GameChat2ChatUserLocal.SendChatText()` を使用します。</span><span class="sxs-lookup"><span data-stu-id="72201-177">To send text chat, use `GameChat2ChatUserLocal.SendChatText()`.</span></span> <span data-ttu-id="72201-178">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="72201-178">For example:</span></span>

```cs
localUserA.SendChatText("Hello");
```

<span data-ttu-id="72201-179">ゲーム チャット 2 では、このメッセージを含むデータ フレームを生成します。このデータ フレームのターゲット エンドポイントは、ローカル ユーザーからテキストを受信するように構成されたユーザーに関連付けられたものになります。</span><span class="sxs-lookup"><span data-stu-id="72201-179">Game Chat 2 will generate a data frame containing this message; the target endpoints for the data frame will be those associated with users that have been configured to receive text from the local user.</span></span> <span data-ttu-id="72201-180">リモート エンドポイントでデータが処理されると、メッセージは `GameChat2TextChatReceivedStateChange` を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="72201-180">When the data is processed by the remote endpoints, the message will be exposed via a `GameChat2TextChatReceivedStateChange`.</span></span> <span data-ttu-id="72201-181">ボイス チャットと同様に、テキスト チャットでは権限とプライバシーの制限が考慮されます。</span><span class="sxs-lookup"><span data-stu-id="72201-181">As with voice chat, privilege and privacy restrictions are respected for text chat.</span></span> <span data-ttu-id="72201-182">ユーザーの間で、テキスト チャットを許可するように構成されているが、権限またはプライバシーの制限によって通信が許可されていない場合、テキスト メッセージは失われます。</span><span class="sxs-lookup"><span data-stu-id="72201-182">If a pair of users have been configured to allow text chat, but privilege or privacy restrictions disallow that communication, the text message will be dropped.</span></span>

<span data-ttu-id="72201-183">ユーザー補助のために、テキスト チャットの入力と表示のサポートが必要です (詳細については、「[ユーザー補助](#access)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="72201-183">Supporting text chat input and display is required for accessibility (see [Accessibility](#access) for more details).</span></span>

## <a name="accessibility-a-nameaccess"></a><span data-ttu-id="72201-184">ユーザー補助 <a name="access"></span><span class="sxs-lookup"><span data-stu-id="72201-184">Accessibility <a name="access"></span></span>

<span data-ttu-id="72201-185">テキスト チャットの入力と表示をサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-185">Supporting text chat input and display is required.</span></span> <span data-ttu-id="72201-186">テキスト入力が必須なのは、従来、物理キーボードを広範的に使用していないプラットフォームやゲーム ジャンルでも、ユーザーはこのシステムで、音声合成の支援技術を使用する場合があるためです。</span><span class="sxs-lookup"><span data-stu-id="72201-186">Text input is required because, even on platforms or game genres that historically haven't had widespread physical keyboard use, users may configure the system to use text-to-speech assistive technologies.</span></span> <span data-ttu-id="72201-187">同様に、ユーザーは音声からテキストの変換を使用できるようにこのシステムを設定する場合があるため、テキスト表示にも対応している必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-187">Similarly, text display is required because users may configure the system to use speech-to-text.</span></span> <span data-ttu-id="72201-188">`GameChat2ChatUserLocal.TextToSpeechConversionPreferenceEnabled` および `GameChat2ChatUserLocal.SpeechToTextConversionPreferenceEnabled` プロパティをそれぞれチェックすると、ローカル ユーザーがこれらの設定を検出できます。必要に応じて、テキストのメカニズムを有効にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="72201-188">These preferences can be detected on local users by checking the `GameChat2ChatUserLocal.TextToSpeechConversionPreferenceEnabled` and `GameChat2ChatUserLocal.SpeechToTextConversionPreferenceEnabled` properties respectively, and you may wish to conditionally enable text mechanisms.</span></span>

### <a name="text-to-speech"></a><span data-ttu-id="72201-189">音声合成</span><span class="sxs-lookup"><span data-stu-id="72201-189">Text-to-speech</span></span>

<span data-ttu-id="72201-190">ユーザーが音声合成を有効にしていると、`GameChat2ChatUserLocal.TextToSpeechConversionPreferenceEnabled` は 'true' になります。</span><span class="sxs-lookup"><span data-stu-id="72201-190">When a user has text-to-speech enabled, `GameChat2ChatUserLocal.TextToSpeechConversionPreferenceEnabled` will be 'true'.</span></span> <span data-ttu-id="72201-191">この状態が検出されると、アプリではテキスト入力の方法を提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-191">When this state is detected, the app must provide a method of text input.</span></span> <span data-ttu-id="72201-192">現実のキーボードまたは仮想キーボードで入力されたテキストを取得したら、その文字列を `GameChat2ChatUserLocal.SynthesizeTextToSpeech()` メソッドに渡します。</span><span class="sxs-lookup"><span data-stu-id="72201-192">Once you have the text input provided by a real or virtual keyboard, pass the string to the `GameChat2ChatUserLocal.SynthesizeTextToSpeech()` method.</span></span> <span data-ttu-id="72201-193">ゲーム チャット 2 では、文字列を検出し、ユーザーの利用可能な音声設定に基づいてオーディオ データを合成します。</span><span class="sxs-lookup"><span data-stu-id="72201-193">Game Chat 2 will detect and synthesize audio data based on the string and the user's accessible voice preference.</span></span> <span data-ttu-id="72201-194">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="72201-194">For example:</span></span>

```cs
localUserA.SynthesizeTextToSpeech("Hello");
```

<span data-ttu-id="72201-195">この操作の一環として合成されたオーディオは、このローカル ユーザーからオーディオを受信するように構成されたユーザー全員に転送されます。</span><span class="sxs-lookup"><span data-stu-id="72201-195">The audio synthesized as part of this operation will be transported to all users that have been configured to receive audio from this local user.</span></span> <span data-ttu-id="72201-196">音声合成を有効にしていないユーザーから `GameChat2ChatUserLocal.SynthesizeTextToSpeech()` が呼び出された場合、ゲーム チャット 2 では何も実行しません。</span><span class="sxs-lookup"><span data-stu-id="72201-196">If `GameChat2ChatUserLocal.SynthesizeTextToSpeech()` is called on a user who does not have text-to-speech enabled Game Chat 2 will take no action.</span></span>

### <a name="speech-to-text"></a><span data-ttu-id="72201-197">音声テキスト変換</span><span class="sxs-lookup"><span data-stu-id="72201-197">Speech-to-text</span></span>

<span data-ttu-id="72201-198">ユーザーが音声テキスト変換を有効にしていると、`GameChat2ChatUserLocal.SpeechToTextConversionPreferenceEnabled` は true になります。</span><span class="sxs-lookup"><span data-stu-id="72201-198">When a user has speech-to-text enabled, `GameChat2ChatUserLocal.SpeechToTextConversionPreferenceEnabled` will be true.</span></span> <span data-ttu-id="72201-199">この状態が検出されると、アプリは変換されたチャット メッセージに関連付けられた UI を提供する準備ができている必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-199">When this state is detected, the app must be prepared to provide UI associated with transcribed chat messages.</span></span> <span data-ttu-id="72201-200">GC では各リモート ユーザーのオーディオを自動的に変換して、`GameChat2TranscribedChatReceivedStateChange` を通じて公開します。</span><span class="sxs-lookup"><span data-stu-id="72201-200">GC will automatically transcribe each remote user's audio and expose it via a `GameChat2TranscribedChatReceivedStateChange`.</span></span>

### <a name="speech-to-text-performance-considerations"></a><span data-ttu-id="72201-201">音声テキスト変換のパフォーマンスに関する考慮事項</span><span class="sxs-lookup"><span data-stu-id="72201-201">Speech-to-text performance considerations</span></span>

<span data-ttu-id="72201-202">音声テキスト変換が有効の場合、各リモート デバイスのゲーム チャット 2 インスタンスでは音声サービス エンドポイントとの Web ソケット接続を開始します。</span><span class="sxs-lookup"><span data-stu-id="72201-202">When speech-to-text is enabled, the Game Chat 2 instance on each remote device initiates a web socket connection with the speech services endpoint.</span></span> <span data-ttu-id="72201-203">各リモート ゲーム チャット 2 クライアントではこの WebSocket を通じて音声サービス エンドポイントにオーディオをアップロードします。音声サービス エンドポイントでは随時、トランスクリプション メッセージをリモート デバイスに返します。</span><span class="sxs-lookup"><span data-stu-id="72201-203">Each remote Game Chat 2 client uploads audio to the speech services endpoint through this websocket; the speech services endpoint occasionally returns a transcription message to the remote device.</span></span> <span data-ttu-id="72201-204">その後、リモート デバイスではトランスクリプション メッセージ (つまり、テキスト メッセージ) をローカル デバイスに送信します。ローカル デバイスでは、ゲーム チャット 2 からアプリにテキスト メッセージが提供され、表示されます。</span><span class="sxs-lookup"><span data-stu-id="72201-204">The remote device then sends the transcription message (i.e. a text message) to the local device, where the transcribed message is given by Game Chat 2 to the app to render.</span></span>

<span data-ttu-id="72201-205">そのため、音声テキスト変換の主なパフォーマンス コストは、ネットワーク使用率です。</span><span class="sxs-lookup"><span data-stu-id="72201-205">Therefore, the primary performance cost of speech-to-text is network usage.</span></span> <span data-ttu-id="72201-206">ネットワーク トラフィックの大半はエンコードされたオーディオのアップロードです。</span><span class="sxs-lookup"><span data-stu-id="72201-206">Most of the network traffic is the upload of encoded audio.</span></span> <span data-ttu-id="72201-207">"通常" のボイス チャット パスでゲーム チャット 2 によってエンコード済みのオーディオが WebSocket によってアップロードされます。アプリでは `GameChat2ChatManager.AudioEncodingTypeAndBitrate` を通じてビットレートを制御します。</span><span class="sxs-lookup"><span data-stu-id="72201-207">The websocket uploads audio that has already been encoded by Game Chat 2 in the “normal” voice chat path; the app has control over the bitrate via `GameChat2ChatManager.AudioEncodingTypeAndBitrate`.</span></span>

## <a name="ui-a-nameui"></a><span data-ttu-id="72201-208">UI <a name="UI"></span><span class="sxs-lookup"><span data-stu-id="72201-208">UI <a name="UI"></span></span>

<span data-ttu-id="72201-209">特にスコアボードなどのゲーマータグのリストにプレイヤーの位置を表示するだけでなく、ユーザーへのフィードバックとして、ミュート済み/発声中のアイコンを併せて表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="72201-209">It's recommended that anywhere players are shown, particularly in a list of gamertags such as a scoreboard, that you also display muted/speaking icons as feedback for the user.</span></span> <span data-ttu-id="72201-210">`IGameChat2ChatUser.ChatIndicator` プロパティは、そのプレイヤーのチャットの現在の瞬間的なステータスを表します。</span><span class="sxs-lookup"><span data-stu-id="72201-210">The `IGameChat2ChatUser.ChatIndicator` property represents the current, instantaneous status of chat for that player.</span></span> <span data-ttu-id="72201-211">次の例では、特定のアイコンの定数値を決めて 'iconToShow' 変数に割り当てるために、'userA' 変数で指定した `IGameChat2ChatUser` オブジェクトのインジケーター値の取得を示します。</span><span class="sxs-lookup"><span data-stu-id="72201-211">The following example demonstrates retrieving the indicator value for a `IGameChat2ChatUser` object pointed to by the variable 'userA' to determine a particular icon constant value to assign to an 'iconToShow' variable:</span></span>

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

<span data-ttu-id="72201-212">`IGameChat2ChatUser.ChatIndicator` の値は、プレイヤーの発声開始から終了までを頻繁に変更することを想定しています。</span><span class="sxs-lookup"><span data-stu-id="72201-212">The value of `IGameChat2ChatUser.ChatIndicator` is expected to change frequently as players start and stop talking, for example.</span></span> <span data-ttu-id="72201-213">そのため、すべての UI フレームをポーリングできるように設計されています。</span><span class="sxs-lookup"><span data-stu-id="72201-213">It is designed to support apps polling it every UI frame as a result.</span></span>

## <a name="muting-a-namemute"></a><span data-ttu-id="72201-214">ミュート <a name="mute"></span><span class="sxs-lookup"><span data-stu-id="72201-214">Muting <a name="mute"></span></span>

<span data-ttu-id="72201-215">`GameChat2ChatUserLocal.MicrophoneMuted` プロパティを使用すると、ローカル ユーザーのマイクのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="72201-215">The `GameChat2ChatUserLocal.MicrophoneMuted` property can be used to toggle the mute state of a local user's microphone.</span></span> <span data-ttu-id="72201-216">マイクがミュート状態の場合、マイクからオーディオはキャプチャされません。</span><span class="sxs-lookup"><span data-stu-id="72201-216">When the microphone is muted, no audio from that microphone will be captured.</span></span> <span data-ttu-id="72201-217">ユーザーが Kinect などの共有デバイスを使用している場合、ミュート状態はすべてのユーザーに適用されます。</span><span class="sxs-lookup"><span data-stu-id="72201-217">If the user is on a shared device, such as Kinect, the mute state applies to all users.</span></span> <span data-ttu-id="72201-218">このメソッドは、ハードウェア ミュート コントロール (ユーザー ヘッドセットのボタンなど) は反映しません。</span><span class="sxs-lookup"><span data-stu-id="72201-218">This method does not reflect a hardware mute control (e.g. a button on the user's headset).</span></span> <span data-ttu-id="72201-219">ゲーム チャット 2 を通じてユーザーのオーディオ デバイスのハードウェアのミュート状態を取得するメソッドはありません。</span><span class="sxs-lookup"><span data-stu-id="72201-219">There is no method for retrieving the hardware mute state of a user's audio device through Game Chat 2.</span></span>

<span data-ttu-id="72201-220">`GameChat2ChatUserLocal.SetRemoteUserMuted()` メソッドを使用すると、特定のローカル ユーザーに関連するリモート ユーザーのミュート状態を切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="72201-220">The `GameChat2ChatUserLocal.SetRemoteUserMuted()` method can be used to toggle the mute state of a remote user in relation to a particular local user.</span></span> <span data-ttu-id="72201-221">リモート ユーザーがミュート状態の場合、ローカル ユーザーにはそのリモート ユーザーの音声は聞こえません。また、そのリモート ユーザーからのテキスト メッセージを受信しません。</span><span class="sxs-lookup"><span data-stu-id="72201-221">When the remote user is muted, the local user won't hear any audio or receive any text messages from the remote user.</span></span>

## <a name="bad-reputation-auto-mute-a-nameautomute"></a><span data-ttu-id="72201-222">悪い評判の自動ミュート <a name="automute"></span><span class="sxs-lookup"><span data-stu-id="72201-222">Bad reputation auto-mute <a name="automute"></span></span>

<span data-ttu-id="72201-223">通常、リモート ユーザーはミュートを解除した状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="72201-223">Typically remote users will start off unmuted.</span></span> <span data-ttu-id="72201-224">(1) リモート ユーザーがローカル ユーザーのフレンドではなく、(2) リモート ユーザーに悪い評判のフラグがある場合、ゲーム チャット 2 ではユーザーをミュート状態で開始します。</span><span class="sxs-lookup"><span data-stu-id="72201-224">Game Chat 2 will start the users in a muted state when (1) the remote user isn't friends with the local user, and (2) the remote user has a bad reputation flag.</span></span> <span data-ttu-id="72201-225">この操作によってユーザーがミュートされている場合、`IGameChat2ChatUser.ChatIndicator` は `GameChat2UserChatIndicator.ReputationRestricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="72201-225">When users are muted due to this operation, `IGameChat2ChatUser.ChatIndicator` will return `GameChat2UserChatIndicator.ReputationRestricted`.</span></span> <span data-ttu-id="72201-226">この状態は、そのリモート ユーザーをターゲット ユーザーとして含む `GameChat2ChatUserLocal.SetRemoteUserMuted()` の最初の呼び出しでオーバーライドされます。</span><span class="sxs-lookup"><span data-stu-id="72201-226">This state will be overridden by the first call to `GameChat2ChatUserLocal.SetRemoteUserMuted()` that includes the remote user as the target user.</span></span>

## <a name="privilege-and-privacy-a-namepriv"></a><span data-ttu-id="72201-227">権限とプライバシー <a name="priv"></span><span class="sxs-lookup"><span data-stu-id="72201-227">Privilege and privacy <a name="priv"></span></span>

<span data-ttu-id="72201-228">ゲームによって構成される通信リレーションシップの上に、ゲーム チャット 2 は権限とプライバシーの制限を強制します。</span><span class="sxs-lookup"><span data-stu-id="72201-228">On top of the communication relationship configured by the game, Game Chat 2 enforces privilege and privacy restrictions.</span></span> <span data-ttu-id="72201-229">ゲーム チャット 2 では、ユーザーが最初に追加されると、権限とプライバシーの制限の参照を実行します。この操作が完了するまで、ユーザーの `IGameChat2ChatUser.ChatIndicator` は常に `GameChat2UserChatIndicator.Silent` を返します。</span><span class="sxs-lookup"><span data-stu-id="72201-229">Game Chat 2 performs privilege and privacy restriction lookups when a user is first added; the user's `IGameChat2ChatUser.ChatIndicator` will always return `GameChat2UserChatIndicator.Silent` until those operations complete.</span></span> <span data-ttu-id="72201-230">ユーザーの通信が権限またはプライバシーの制限による影響を受ける場合、ユーザーの `IGameChat2ChatUser.ChatIndicator` は `GameChat2UserChatIndicator.PlatformRestricted` を返します。</span><span class="sxs-lookup"><span data-stu-id="72201-230">If communication with a user is affected by a privilege or privacy restriciton, the user's `IGameChat2ChatUser.ChatIndicator` will return `GameChat2UserChatIndicator.PlatformRestricted`.</span></span> <span data-ttu-id="72201-231">プラットフォーム通信制限は、音声チャットとテキスト チャットの両方に適用されます。テキスト チャットがプラットフォーム制限によりブロックされて音声チャットが制限されないインスタンスはなく、その逆もありません。</span><span class="sxs-lookup"><span data-stu-id="72201-231">Platform communication restrictions apply to both voice and text chat; there will never be an instance where text chat is blocked by a platform restriction but voice chat is not, or vice versa.</span></span>

`GameChat2ChatUserLocal.GetEffectiveCommunicationRelationship()` <span data-ttu-id="72201-232">を使用すると、不完全な権限とプライバシーの操作によってユーザーが通信できない場合の区別に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="72201-232">can be used to help distinguish when users can't communicate due to incomplete privilege and privacy operations.</span></span> <span data-ttu-id="72201-233">これを使用すると、ゲーム チャット 2 によって強制される通信リレーションシップが `GameChat2CommunicationRelationship` の形式で返されます。また、リレーションシップが構成されたリレーションシップと等しくない理由が `GameChat2CommunicationRelationshipAdjuster` の形式で返されます。</span><span class="sxs-lookup"><span data-stu-id="72201-233">It returns the communication relationship enforced by Game Chat 2 in the form of `GameChat2CommunicationRelationship` and the reason the relationship may not be equal to the configured relationship in the form of `GameChat2CommunicationRelationshipAdjuster`.</span></span> <span data-ttu-id="72201-234">たとえば、参照操作が進行中の場合、`GameChat2CommunicationRelationshipAdjuster` は `GameChat2CommunicationRelationshipAdjuster.Initializing` になります。</span><span class="sxs-lookup"><span data-stu-id="72201-234">For example, if the lookup operations are still in progress, the `GameChat2CommunicationRelationshipAdjuster` will be `GameChat2CommunicationRelationshipAdjuster.Initializing`.</span></span> <span data-ttu-id="72201-235">この方法は、開発シナリオとデバッグ シナリオで使用することを想定しています。UI に影響を与えるために使用しないでください (「[UI](#UI)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="72201-235">This method is expected to be used in development and debugging scenarios; it should not be used to influence UI (see [UI](#UI)).</span></span>

## <a name="cleanup-a-namecleanup"></a><span data-ttu-id="72201-236">クリーンアップ <a name="cleanup"></span><span class="sxs-lookup"><span data-stu-id="72201-236">Cleanup <a name="cleanup"></span></span>

<span data-ttu-id="72201-237">アプリでゲーム チャット 2 を介した通信が不要になった場合は、`GameChat2ChatManager.Dispose()` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="72201-237">When the app no longer needs communications via Game Chat 2, you should call `GameChat2ChatManager.Dispose()`.</span></span> <span data-ttu-id="72201-238">これにより、ゲーム チャット 2 で通信の管理に割り当てられたリソースを解放できます。</span><span class="sxs-lookup"><span data-stu-id="72201-238">This allows Game Chat 2 to reclaim resources that were allocated to manage the communications.</span></span>

## <a name="how-to-configure-popular-scenarios"></a><span data-ttu-id="72201-239">一般的なシナリオの構成方法</span><span class="sxs-lookup"><span data-stu-id="72201-239">How to configure popular scenarios</span></span>

### <a name="push-to-talk"></a><span data-ttu-id="72201-240">プッシュして話しかける</span><span class="sxs-lookup"><span data-stu-id="72201-240">Push-to-talk</span></span>

<span data-ttu-id="72201-241">プッシュして話しかける機能は、`GameChat2ChatUserLocal.MicrophoneMuted` を使用して実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="72201-241">Push-to-talk should be implemented with `GameChat2ChatUserLocal.MicrophoneMuted`.</span></span> <span data-ttu-id="72201-242">会話を許可するには `MicrophoneMuted` を false に設定し、制限するには `MicrophoneMuted` を true に設定します。</span><span class="sxs-lookup"><span data-stu-id="72201-242">Set `MicrophoneMuted` to false to allow speech and `MicrophoneMuted` to true to restrict it.</span></span> <span data-ttu-id="72201-243">このプロパティ変更を使用すると、ゲーム チャット 2 からの応答遅延時間が最少限になります。</span><span class="sxs-lookup"><span data-stu-id="72201-243">This property change will provide the lowest latency response from Game Chat 2.</span></span>

### <a name="teams"></a><span data-ttu-id="72201-244">チーム</span><span class="sxs-lookup"><span data-stu-id="72201-244">Teams</span></span>

<span data-ttu-id="72201-245">ユーザー A とユーザー B が青チーム、ユーザー C とユーザー D が赤チームに属しているとします。</span><span class="sxs-lookup"><span data-stu-id="72201-245">Suppose that User A and User B are on Team Blue, and User C and User D are on Team Red.</span></span> <span data-ttu-id="72201-246">各ユーザーは、アプリの一意のインスタンスに含まれます。</span><span class="sxs-lookup"><span data-stu-id="72201-246">Each user is in a unique instance of the app.</span></span>

<span data-ttu-id="72201-247">ユーザー A のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-247">On User A's device:</span></span>

```cs
localUserA.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.SendAndReceiveAll);
localUserA.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
localUserA.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

<span data-ttu-id="72201-248">ユーザー B のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-248">On User B's device:</span></span>

```cs
localUserB.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.SendAndReceiveAll);
localUserB.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
localUserB.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

<span data-ttu-id="72201-249">ユーザー C のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-249">On User C's device:</span></span>

```cs
localUserC.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.None);
localUserC.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserC.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.SendAndReceiveAll);
```

<span data-ttu-id="72201-250">ユーザー D のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-250">On User D's device:</span></span>

```cs
localUserD.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.None);
localUserD.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserD.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.SendAndReceiveAll);
```

### <a name="broadcast"></a><span data-ttu-id="72201-251">配信</span><span class="sxs-lookup"><span data-stu-id="72201-251">Broadcast</span></span>

<span data-ttu-id="72201-252">ユーザー A が指示を出すリーダーで、ユーザー B、C、D は指示を聞くだけと仮定します。</span><span class="sxs-lookup"><span data-stu-id="72201-252">Suppose that User A is the leader giving orders and Users B, C, and D can only listen.</span></span> <span data-ttu-id="72201-253">各プレイヤーは、一意のデバイスを使用しています。</span><span class="sxs-lookup"><span data-stu-id="72201-253">Each player is on a unique device.</span></span>

<span data-ttu-id="72201-254">ユーザー A のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-254">On User A's device:</span></span>

```cs
localUserA.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.SendAll);
localUserA.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.SendAll);
localUserA.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.SendAll);
```

<span data-ttu-id="72201-255">ユーザー B のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-255">On User B's device:</span></span>

```cs
localUserB.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.ReceiveAll);
localUserB.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
localUserB.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

<span data-ttu-id="72201-256">ユーザー C のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-256">On User C's device:</span></span>

```cs
localUserC.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.ReceiveAll);
localUserC.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserC.SetCommunicationRelationship(remoteUserD, GameChat2CommunicationRelationship.None);
```

<span data-ttu-id="72201-257">ユーザー D のデバイス:</span><span class="sxs-lookup"><span data-stu-id="72201-257">On User D's device:</span></span>

```cs
localUserD.SetCommunicationRelationship(remoteUserA, GameChat2CommunicationRelationship.ReceiveAll);
localUserD.SetCommunicationRelationship(remoteUserB, GameChat2CommunicationRelationship.None);
localUserD.SetCommunicationRelationship(remoteUserC, GameChat2CommunicationRelationship.None);
```
