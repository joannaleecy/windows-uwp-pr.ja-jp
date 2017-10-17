---
title: Multiplayer how-tos
author: KevinAsgari
description: Describes how to implement common tasks in Xbox Live Multiplayer 2015.
ms.assetid: 99c5b7c4-018c-4f7a-b2c9-0deed0e34097
ms.author: kevinasg
ms.date: 08-29-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one, multiplayer 2015
ms.openlocfilehash: 932a61bbdf3dc6e1bd3584f1487fd8341b98df20
ms.sourcegitcommit: bf5cbc3c1fda6ba2dab2a198ede7b9b1b54583e9
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/11/2017
---
# <a name="multiplayer-how-tos"></a>Multiplayer how-to's

このトピックには、マルチプレイヤー 2015 の使用に関連する特定のタスクの実装方法についての情報が含まれています。

* MPSD セッション変更通知のサブスクライブ
* MPSD セッションの作成
* MPSD セッションのアービターの設定
* Manage Title Activation
* ユーザーを参加可能にする
* ゲームへの招待の送信
* ロビー セッションからゲーム セッションへの参加
* タイトルのアクティベーションからの MPSD セッションへの参加
* ユーザーの現在のアクティビティの設定
* MPSD セッションの更新
* MPSD セッションからの退出
* マッチメイキング中に空きセッション スロットを埋める
* マッチ チケットの作成
* マッチ チケットのステータスの取得

## <a name="subscribe-for-mpsd-session-change-notifications"></a>MPSD セッション変更通知のサブスクライブ

| 注意                                                                                                                                                                                                                                                                                                                                    |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Subscribing for changes to a session requires the associated player to be active in the session. The connectionRequiredForActiveMembers field must also be set to true in the /constants/system/capabilities object for the session. This field is usually set in the session template. See [MPSD Session Templates](multiplayer-session-directory.md). |



To receive MPSD session change notifications, the title can follow the procedure below.

1.  Use the same **XboxLiveContext Class** object for all calls by the same user. Subscriptions are tied to the lifetime of this object. If there are multiple local users, use a separate **XboxLiveContext** object for each user.
2.  Implement event handlers for the **RealTimeActivityService.MultiplayerSessionChanged Event** and the **RealTimeActivityService.MultiplayerSubscriptionsLost Event**.
3.  If subscribing to changes for more than one user, add code to your **MultiplayerSessionChanged** event handler to avoid unnecessary work. Use the **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property** and the **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property**. Use of these properties allows tracking of the last change seen and ignoring of older changes.
4.  Call the **RealTimeActivityService.EnableMultiplayerSubscriptions Method** to allow subscriptions.
5.  Create a local session object and join that session as active.
6.  Make calls for each user to the **MultiplayerSession.SetSessionChangeSubscription Method**, passing the session change type for which to be notified.
7.  Now write the session to MPSD as described in **How to: Update a Multiplayer Session**.

次のフロー チャートは、この手順で説明するイベントにサブスクライブしてマルチプレイヤーを開始する方法を示しています。

![](../../images/multiplayer/Multiplayer_2015_Start_Multiplayer.png)


### <a name="parsing-duplicate-session-change-notifications"></a>重複するセッション変更通知の解析

When there are multiple users subscribed to notifications for the same session, every change to that session will trigger a shoulder tap for each user. All but one of these will be duplicates. While it's still recommended that a title subscribe every user in a session to notifications, a title should ignore any changes that it's already been notified of; you can do this using the Branch and ChangeNumber properties.

To detect multiple shoulder taps, a title should:

-   For each **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property** value seen, store the latest **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property**.
-   If a shoulder tap has a higher **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** than the last seen for that **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property**, process it and update the latest **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property**.
-   If a shoulder tap does not have a higher **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** for that **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property**, skip it. That change has already been handled.

| Note                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** values need to be tracked by **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property**, not by session. It's possible for the **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property** value to change (and the **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** to reset) within the lifetime of a session. |

## <a name="create-an-mpsd-session"></a>MPSD セッションの作成


| 注意                                                                                                                                                                                                                           |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| By default, an MPSD session is created when the first member joins it. If your title logic expects the title to exist or not exist at join time, it can pass an appropriate write mode value to the write method during the session update. |



The title must do the following to create a new session:

1.  Create a new **XboxLiveContext Class** object. Your title creates this object once, stores it, and reuses it as required throughout the source code. Especially when working with session subscriptions, it is necessary to use exactly the same context.
2.  Create a new **MultiplayerSession Class** object to prepare all the session data that the MPSD needs to create a new session.
3.  Make required changes before writing the session to MPSD. For example, when joining a member to the session with a call to **MultiplayerSession.Join Method**, the client adds hidden local request data that tells MPSD to join upon the call to update the session.
4.  When finished making local changes, write them to MPSD as described in **How to: Update a Multiplayer Session**.
5.  Receive the new **MultiplayerSession** object from MPSD, with many fields filled in.
6.  Use the new session object going forward, and discard the old copy, which contains a hidden request to create a new session.

### <a name="example"></a>例

    void Example_MultiplayerService_CreateSession()
    {
      XboxLiveContext^ xboxLiveContext = ref new Microsoft::Xbox::Services::XboxLiveContext(User::Users->GetAt(0));

      // These from XDP web portal
      MultiplayerSessionReference^ multiplayerSessionReference = ref new MultiplayerSessionReference(
        "c83c597b-7377-4886-99e3-2b5818fa5e4f", // serviceConfigurationId
        "team-deathmatch", // sessionTemplateName
        "mySession" // sessionName
        );

      MultiplayerSession^ multiplayerSession = ref new MultiplayerSession(
        xboxLiveContext,
        multiplayerSessionReference
        );

      auto asyncOp = xboxLiveContext->MultiplayerService->WriteSessionAsync(
        multiplayerSession,
        MultiplayerSessionWriteMode::CreateNew
        );

      create_task(asyncOp)
      .then([](MultiplayerSession^ newMultiplayerSession)
      {
        // Throw away stale multiplayerSession, and use newMultiplayerSession from now on
      });
    }


## <a name="set-an-arbiter-for-an-mpsd-session"></a>MPSD セッションのアービターの設定




タイトルは、次の手順を使用して、作成済みのセッションのアービターを設定します。

| Note                                                                                                                                       |
|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| Device tokens for the members (potential hosts) are not available until the members have joined the session and included their secure device addresses. |

1.  Retrieve the device tokens for host candidates from the MPSD by using the **MultiplayerSession.Members Property**.

| Note                                                                                                                                                                                                                     |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | If the session was created by SmartMatch matchmaking, your clients can use the host candidates available from MPSD through the **MultiplayerSession.HostCandidates Property**. |

2.  Select the required host from the list of host candidates.
3.  Call the **MultiplayerSession.SetHostDeviceToken Method** to set the device token in the local cache of the MPSD. If the call to set the host device token succeeds, the local device token replaces the host's token.
4.  If an HTTP/412 status code is received when trying to set the host device token, query the session data and see if the host device token is for the local console. If it is not for the local console, another console has been designated as the arbiter.

| Note                                                                                                                                                                                                                              |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Your client should handle the HTTP/412 status code separately from other HTTP codes, since HTTP/412 does not indicate a standard failure. For more about the status code, see [Multiplayer Session Status Codes](multiplayer-session-status-codes.md). |

5.  Update the session in MPSD, as described in **How to: Update a Multiplayer Session**.

| Note                                                                                                                                                                                                                                           |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| If you have no better algorithm, the client can implement a greedy algorithm in which each host candidate attempts to set itself as the host if nobody else has done it yet. 詳しくは、「[セッション アービター](mpsd-session-details.md)」をご覧ください。 |

## <a name="manage-title-activation"></a>タイトルのアクティベーションの管理

Xbox One は、プロトコル アクティベーション時に **CoreApplicationView.Activated イベント**を発生させます。 In the context of the multiplayer API, this event is fired when a user accepts an invite or joins another user. These actions trigger an activation that the title must react to by bringing the joining user into game play with the target user.

| Note                                                                                       |
|---------------------------------------------------------------------------------------------------------|
| Your title should expect new activation arguments at any time and should never be coded against length. |

The title must perform the following main steps to handle title activation.

1.  Set up an event handler for the **CoreApplicationView.Activated Event**. This handler triggers every time protocol activation occurs, even if the title is already running.
2.  At title activation, begin a session and subscribe for session change notifications. See **How to: Subscribe for MPSD Session Change Notifications**.
3.  Join the user to the session as active. See **How to: Join an MPSD Session from a Title Activation**.
4.  Set the lobby session as the activity session, exposed through the profile UI. See **How to: Set the User's Current Activity**.
5.  Join the user to the game session as active. Now the user can connect to peers and enter game play or the lobby.

次のフロー チャートは、タイトルのアクティベーションを処理する方法を示しています。

![](../../images/multiplayer/Multiplayer_2015_OnActivation.png)

## <a name="make-the-user-joinable"></a>ユーザーを参加可能にする

ユーザーを参加可能にするには、タイトルで次の手順を行う必要があります。

1.  Create a session object, and modify the attributes as required.
2.  Join the user to the session as active. See **How to: Join an MPSD Session from a Title Activation**.
3.  Determine if the user has been designated as the session arbiter.
4.  If the user is not the arbiter, go to step 7.
5.  If the user is the arbiter, call the **MultiplayerSession.SetHostDeviceToken Method**.
6.  Attempt to write the session using a call to the **MultiplayerService.TryWriteSessionAsync Method**.
7.  Set the session as the active session. See **How to: Set the User's Current Activity**.

次のフロー チャートは、ゲーム中に他のプレイヤーによってユーザーが参加できるようにするための手順を示します。

![](../../images/multiplayer/Multiplayer_2015_Become_Joinable.png)

## <a name="send-game-invites"></a>ゲームへの招待の送信

タイトルでは、次の方法でプレイヤーがゲームへの招待を送信することを可能にできます。

-   Send the invites for the lobby session.
-   Send the invites using the generic Xbox platform invite UI with the game session reference.

To send game invites for a player, the title must do the following:

1.  Make the inviting game player joinable. See **How to: Make the User Joinable**.
2.  Determine if the invites are to be sent via the lobby session or using the invite UI.
3.  If using the lobby session, send the invites using a call to **MultiplayerService.SendInvitesAsync Method**. This method might require the building of an in-game UI roster using the **SystemUI.ShowPeoplePickerAsync Method** or the **PartyChat.GetPartyChatViewAsync Method**.
4.  If using the invite UI, call the **SystemUI.ShowSendGameInvitesAsync Method** to show the invite UI.
5.  Handle the **RealTimeActivityService.MultiplayerSessionChanged Event** for the local player after the remote player joins.
6.  For the remote player, implement title activation code. See **How to: Manage Title Activation**.

次のフロー チャートは、招待を送信する方法を示しています。

![](../../images/multiplayer/Multiplayer_2015_Send_Invites.png)

## <a name="join-a-game-session-from-a-lobby-session"></a>ロビー セッションからゲーム セッションへの参加

Windows 10 デバイスのゲームプレイ セッションでは、大規模なセッションでない場合、`userAuthorizationStyle` 機能を **true** に設定する必要があります。 つまり、`joinRestriction` プロパティを "none" にすることはできません。これは、セッションへの一般からの直接参加はできないことを意味します。

一般的なシナリオでは、ロビー セッションを作成してプレイヤーを集め、それらのプレイヤーをゲームプレイ セッションまたはマッチメイキング セッションに移動します。 ただし、ゲームプレイ セッションが一般から参加不可能な場合、ゲーム クライアントは `joinRestriction` 設定を満たしていない限りゲームプレイ セッションに参加できません。この制限は、このようなシナリオには厳しすぎる場合がほとんどです。

これを解決するには、転送ハンドルを使ってロビー セッションとゲーム セッションをリンクします。  タイトルでは、次の操作でこれを実行できます。

1. ゲーム セッションの作成時に、`multiplayer_service::set_transfer_handle(gameSessionRef, lobbySessionRef)` API を使って、ロビー セッションとゲーム セッションをリンクする転送ハンドルを作成します。
2. ゲーム セッションのセッション参照の代わりに、転送ハンドルの GUID をロビー セッションに格納します。
3. タイトルでロビー セッションからゲーム セッションにメンバーを移動するとき、各クライアントでは、ロビー セッションから転送ハンドルを使い、`multiplayer_service::write_session_by_handle(multiplayerSession, multiplayerSessionWriteMode, handleId)` API を呼び出してゲーム セッションに参加します。
4. MPSD は、ロビー セッションを検索し、転送ハンドルを使ってゲーム セッションに参加しようとしているユーザーがロビー セッションにも存在することを確認します。
5. ロビー セッションに存在するメンバーであれば、ゲーム セッションにアクセスできるようになります。

## <a name="join-an-mpsd-session-from-a-title-activation"></a>タイトルのアクティベーションからの MPSD セッションへの参加

When a user chooses to join a friend's activity or accept an invite using Xbox shell UI, the title is activated with parameters that indicate what session the user would like to join. The title must handle this activation and add the user to the corresponding session.

Here are the steps the title should follow:

1.  Implement an event handler for the **CoreApplicationView.Activated Event**. This event notifies of activations for the title.
2.  When the handler fires, examine the **IActivatedEventArgs.Kind Property**. If it is set to Protocol, cast the event arguments to **ProtocolActivatedEventArgs Class**.
3.  Examine the **ProtocolActivatedEventArgs** object. If the URI indicated in the **ProtocolActivatedEventArgs.Uri Property** matches either inviteHandleAccept (corresponding to an accepted invite) or activityHandleJoin (corresponding to a join via shell UI), parse the query string of the URI, which is formatted as a normal URI query string with key/value pairs, extracting the following fields:
    -   For an accepted invite:
        1.  handle
        2.  invitedXuid
        3.  senderXuid
    -   For a join:
        1.  handle
        2.  joinerXuid
        3.  joineeXuid

4.  Start the title's multiplayer code, which should include calling the **RealTimeActivityService.EnableMultiplayerSubscriptions Method**.
5.  Create a local **MultiplayerSession Class** object, using the **MultiplayerSession Constructor (XboxLiveContext)**.
6.  Call the **MultiplayerSession.Join Method (String, Boolean, Boolean)** to join the session. Use the following parameter settings so that the join is set as active:
    -   *memberCustomConstantsJson* = null
    -   *initializeRequested* = false
    -   *joinWithActiveStatus* = true

7.  Call the **MultiplayerSession.SetSessionChangeSubscription Method** to be shoulder-tapped when the session changes after joining.
8.  Call the **MultiplayerService.WriteSessionByHandleAsync Method**, using the handle acquired as described in step 3. ユーザーはセッションのメンバーになっているので、セッション内のデータを使用してゲームに接続できます。

## <a name="set-the-users-current-activity"></a>ユーザーの現在のアクティビティの設定

ユーザーの現在のアクティビティは、タイトルの Xbox ダッシュボードのユーザー エクスペリエンスに表示されます。 Activity for a user can be set through a session or through title activation. In the latter case, the user enters a session through matchmaking or by starting a game.

| Note                                                                                                                                                  |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| Activity set through a session can be deleted with a call to the **MultiplayerService.ClearActivityAsync Method**. |

To set a session as the user's current activity, the title calls the **MultiplayerService.SetActivityAsync Method**, passing the session reference for the session.

タイトルのアクティベーションを通じてユーザーの現在のアクティビティを設定するには、「**方法: タイトルのアクティベーションからの MPSD セッションへの参加**」をご覧ください。

## <a name="update-an-mpsd-session"></a>MPSD セッションの更新

| 注意                                                                                                                                                 |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| When your title updates an existing session using the multiplayer API, remember that it is working with a local copy, until it makes a call to write the session. |

To update an existing session, the title must:

1.  Make changes to the current session as required, for example, by calling the **MultiplayerSession.Leave Method**.
2.  When all changes are made, write the local changes to MPSD, using any of these methods:

    -   **MultiplayerService.WriteSessionAsync Method**
    -   **MultiplayerService.WriteSessionByHandleAsync Method**.
    -   **MultiplayerService.TryWriteSessionAsync Method**
    -   **MultiplayerService.TryWriteSessionByHandleAsync Method**

    Set the write mode to **SynchronizedUpdate** if writing to a shared portion that other titles can also modify. See [Synchronization of Session Updates](multiplayer-session-directory.md) for more information.

    The write method writes the join to the server and gets the latest session, from which to discover other session members and the secure device addresses (SDAs) of their consoles. For more information about establishing a network connection among these consoles, see **Introduction to Winsock on Xbox One**.

3.  Discard the old local session object, and use the newly retrieved session object so that future actions are based on the latest known session state.

## <a name="leave-an-mpsd-session"></a>MPSD セッションからの退出

ユーザーがセッションから退出できるようにするには、タイトルで次の手順を行う必要があります。

1.  Call the **MultiplayerSession.Leave Method** for the game session.
2.  Update the game session in MPSD, as described in **How to: Update a Multiplayer Session**.
3.  If necessary, call **Leave** method for the lobby session, and update that session.
4.  If necessary for the lobby session, shut down the multiplayer API by unregistering the **RealTimeActivityService.MultiplayerSubscriptionsLost Event** and the **RealTimeActivityService.MultiplayerSessionChanged Event**.

次のフロー チャートは、セッションから退出して、シャットダウンする方法を示します。

![](../../images/multiplayer/Multiplayer_2015_Shut_Down.png)

## <a name="fill-open-session-slots-during-matchmaking"></a>マッチメイキング中に空きセッション スロットを埋める

マッチメイキング中にチケット セッションの空きスロットを埋めるには、タイトルで次のような手順に従う必要があります。

1.  Access the latest session state for the ticket session created during matchmaking.
2.  Add available players for game play from the lobby session.
3.  Determine if the ticket session is full.
4.  If the session is full, continue game play.
5.  If the session is not yet full, create the match ticket as described in **How to: Create a Match Ticket**. Be sure to create the ticket with the *preserveSession* parameter set to Always.
6.  Continue with matchmaking. See [Using SmartMatch Matchmaking](using-smartmatch-matchmaking.md).

次のフロー チャートは、マッチメイキング中に空きセッション スロットを埋める方法を示しています。

![](../../images/multiplayer/Multiplayer_2015_Fill_Open_Slots.png)

## <a name="create-a-match-ticket"></a>マッチ チケットの作成

マッチ チケットを作成するには、マッチメイキング スカウトは次の処理を実行する必要があります。

1.  Call the **MatchmakingService.CreateMatchTicketAsync Method**, passing in a reference to the ticket session. The method reads the ticket session from MPSD, and starts matchmaking for the users in the session. Internally the method calls the **POST (/serviceconfigs/{scid}/hoppers/{hoppername})**.
2.  Set the *preserveSession* parameter to Never if the matchmaking service is to match the members of the session into a new session or another existing session. Set the *preserveSession* parameter to Always to allow the title to reuse an existing game session as a ticket session to continue game play. The matchmaking service can then ensure that the submitted session is preserved and any matched players are added to that session.

3.  Use the **CreateMatchTicketResponse.EstimatedWaitTime Property** returned in the **CreateMatchTicketResponse Class** object to set user expectations of matchmaking time.
4.  Use the **CreateMatchTicketResponse.MatchTicketId Property** returned in the response object to cancel matchmaking for the session if needed, by deleting the ticket. チケットの削除には **MatchmakingService.DeleteMatchTicketAsync メソッド**を使用します。

## <a name="get-match-ticket-status"></a>マッチ チケットのステータスの取得

タイトルがマッチ チケットのステータスを取得するには、次の手順を実行します。

1.  Obtain the **MultiplayerSession Class** object for the ticket session.
2.  Use the **MultiplayerSession.MatchmakingServer Property** to access the **MatchmakingServer Class** object used in matchmaking.
3.  Check the **MatchmakingServer** object to determine the status of the matchmaking process, the typical wait time for the session, and the target session reference, if a match has been found.
