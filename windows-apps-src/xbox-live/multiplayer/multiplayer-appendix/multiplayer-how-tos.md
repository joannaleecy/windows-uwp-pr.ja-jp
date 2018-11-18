---
title: マルチプレイヤーの実行方法
author: KevinAsgari
description: Xbox Live マルチプレイヤー 2015 で一般的なタスクを実装する方法について説明します。
ms.assetid: 99c5b7c4-018c-4f7a-b2c9-0deed0e34097
ms.author: kevinasg
ms.date: 08/29/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー 2015
ms.localizationpriority: medium
ms.openlocfilehash: e845d1d714b42e1c1989b442a9c232f610b72ae4
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7153963"
---
# <a name="multiplayer-how-tos"></a>マルチプレイヤーの実行方法

このトピックには、マルチプレイヤー 2015 の使用に関連する特定のタスクの実装方法についての情報が含まれています。

* MPSD セッション変更通知のサブスクライブ
* MPSD セッションの作成
* MPSD セッションのアービターの設定
* タイトルのアクティベーションの管理
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
| セッションの変更をサブスクライブするには、関連付けられているプレイヤーがセッションでアクティブであることが必要です。 また、connectionRequiredForActiveMembers フィールドが、セッションの /constants/system/capabilities オブジェクトで true に設定されている必要があります。 このフィールドは、通常、セッション テンプレートで設定します。 「[MPSD セッション テンプレート](multiplayer-session-directory.md)」を参照してください。 |



MPSD セッション変更通知を受信するには、タイトルは次の手順を実行することができます。

1.  同じユーザーによる呼び出しには必ず同じ **XboxLiveContext クラス** オブジェクトを使用します。 サブスクリプションは、このオブジェクトの有効期間に関連付けられます。 複数のローカル ユーザーが存在する場合は、ユーザーごとに個別の **XboxLiveContext** オブジェクトを使用します。
2.  **RealTimeActivityService.MultiplayerSessionChanged イベント**および **RealTimeActivityService.MultiplayerSubscriptionsLost イベント**のイベント ハンドラーを実装します。
3.  複数のユーザーの変更をサブスクライブする場合は、不要な作業を避けるためのコードを **MultiplayerSessionChanged** イベント ハンドラーに追加します。 **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**と **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**を使用します。 これらのプロパティを使用することで、最後に確認された変更を追跡し、より古い変更を無視できます。
4.  **MultiplayerService.EnableMultiplayerSubscriptions メソッド**を呼び出してサブスクリプションを許可します。
5.  ローカル セッション オブジェクトを作成し、そのセッションをアクティブとして参加させます。
6.  各ユーザーに対して **MultiplayerSession.SetSessionChangeSubscription メソッド**の呼び出しを行い、通知の対象となるセッション変更の種類を渡します。
7.  「**方法: マルチプレイヤー セッションの更新**」に説明されているように、セッションを MPSD に書き込みます。

次のフロー チャートは、この手順で説明するイベントにサブスクライブしてマルチプレイヤーを開始する方法を示しています。

![](../../images/multiplayer/Multiplayer_2015_Start_Multiplayer.png)


### <a name="parsing-duplicate-session-change-notifications"></a>重複するセッション変更通知の解析

同じセッションの通知をサブスクライブする複数のユーザーがいる場合、そのセッションへの変更はすべて、各ユーザーに対してショルダー タップをトリガーします。 これらは 1 つを除いてすべて重複になります。 タイトルが通知に対してセッション内のすべてのユーザーをサブスクライブすることをお勧めするものの、既に通知された変更は無視してください。これは、Branch および ChangeNumber プロパティを使用して行うことができます。

複数のショルダー タップを検出するには、タイトルで以下を行う必要があります。

-   確認される **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**値ごとに、最新の **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**を保存します。
-   ショルダー タップの **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**がその **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**で最後に確認されたものよりも高い場合は、それを処理し、最新の **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**を更新します。
-   ショルダー タップの **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**がその **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**より高くない場合は、スキップします。 その変更は、既に処理されています。

| 注意                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**値は、セッションによってではなく、**RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**によって追跡する必要があります。 **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**値はセッションの有効期間内に変更される (および **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**がリセットされる) 可能性があります。 |

## <a name="create-an-mpsd-session"></a>MPSD セッションの作成


| 注意                                                                                                                                                                                                                           |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| 既定では、最初のメンバーが参加したときに MPSD セッションが作成されます。 タイトル ロジックが参加時にタイトルが存在するか存在しないかを予期している場合は、セッション更新時に適切な書き込みモードの値を書き込みメソッドに渡すことができます。 |



タイトルは以下の処理を実行し、新しいセッションを作成する必要があります。

1.  新しい **XboxLiveContext クラス**オブジェクトを作成します。 タイトルはこのオブジェクトを 1 回作成して格納し、ソース コード全体で必要に応じて再利用します。 特にセッションのサブスクリプションを使用する場合は、まったく同じコンテキストを使用する必要があります。
2.  新しい **MultiplayerSession クラス** オブジェクトを作成し、MPSD による新しいセッションの作成に必要なすべてのセッション データを準備します。
3.  セッションを MPSD に書き込む前に必要な変更を行います。 たとえば、**MultiplayerSession.Join メソッド**を呼び出してメンバーをセッションに参加させる場合は、クライアントは、セッション更新の呼び出し時に参加させるように MPSD に指示する非表示ローカル要求データを追加します。
4.  ローカルの変更が完了したら、「**方法: マルチプレイヤー セッションの更新**」で説明されているように MPSD に書き込みます。
5.  MPSD から、多くのフィールドが入力された新しい **MultiplayerSession** オブジェクトを受け取ります。
6.  今後は、この新しいセッション オブジェクトを使用し、新しいセッションを作成するための非表示要求が含まれている古いコピーは破棄します。

### <a name="example"></a>例

    void Example_MultiplayerService_CreateSession()
    {
      XboxLiveContext^ xboxLiveContext = ref new Microsoft::Xbox::Services::XboxLiveContext(User::Users->GetAt(0));

      // Values found in Xbox Developer Portal(XDP) or Partner Center configuration
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

| 注意                                                                                                                                       |
|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| メンバーのデバイス トークン (潜在的なホスト) は、メンバーがセッションに参加して、セキュア デバイス アドレスが含まれるまでは利用できません。 |

1.  **MultiplayerSession.Members プロパティ**を使用して、MPSD からホスト候補のデバイス トークンを取得します。

| 注意                                                                                                                                                                                                                     |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | SmartMatch マッチメイキングによってセッションが作成された場合、クライアントは、**MultiplayerSession.HostCandidates プロパティ**を通じて MPSD から利用できるホスト候補を使用できます。 |

2.  ホスト候補の一覧から、必要なホストを選択します。
3.  **MultiplayerSession.SetHostDeviceToken メソッド**を呼び出して、MPSD のローカル キャッシュでデバイス トークンを設定します。 ホスト デバイス トークンを設定する呼び出しが成功した場合、ローカル デバイス トークンがホストのトークンに取って代わります。
4.  ホスト デバイス トークンを設定しようとしたときに HTTP/412 ステータス コードを受け取った場合は、セッション データを照会して、ホスト デバイス トークンがローカル本体用かどうか確認してください。 ローカル本体用でない場合は、別の本体がアービターとして指定されています。

| 注意                                                                                                                                                                                                                              |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| HTTP/412 は標準的なエラーを示していないので、クライアントはその他の HTTP コードとは切り離して HTTP/412 ステータス コードを処理する必要があります。 ステータス コードの詳細については、「[マルチプレイヤー セッション ステータス コード](multiplayer-session-status-codes.md)」を参照してください。 |

5.  「**方法: マルチプレイヤー セッションの更新**」で説明されているように、MPSD でセッションを更新します。

| 注意                                                                                                                                                                                                                                           |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| より良いアルゴリズムがない場合、クライアントでは、他にホストが設定されていない場合に、各ホストが自分自身をホストとして設定しようとする greedy algorithm (貪欲法) を実装できます。 詳しくは、「[セッション アービター](mpsd-session-details.md)」をご覧ください。 |

## <a name="manage-title-activation"></a>タイトルのアクティベーションの管理

Xbox One は、プロトコル アクティベーション時に **CoreApplicationView.Activated イベント**を発生させます。 マルチプレイヤー API に関しては、ユーザーが招待を受け入れるか、別のユーザーに加わるときにこのイベントが発生します。 これらのアクションは、参加するユーザーをターゲット ユーザーとのゲーム プレイに加えることにより、タイトルが対応する必要があるアクティベーションをトリガーします。

| 注意                                                                                       |
|---------------------------------------------------------------------------------------------------------|
| タイトルでは常に新しいアクティベーション引数を予期する必要があり、長さに関するコーディングを行わないようにする必要があります。 |

タイトルがアクティベーションを処理するためには、次の主な手順を実行する必要があります。

1.  **CoreApplicationView.Activated イベント**のイベント ハンドラーを設定します。 このハンドラーは、タイトルが既に実行されている場合でも、プロトコルのアクティベーションが発生するたびにトリガーされます。
2.  タイトルのアクティベーション時にセッションを開始し、セッションの変更通知をサブスクライブします。 「**方法: MPSD セッション変更通知のサブスクライブ**」を参照してください。
3.  ユーザーをアクティブとしてセッションに参加させます。 「**方法: タイトルのアクティベーションからの MPSD セッションへの参加**」を参照してください。
4.  ロビー セッションを、プロフィール UI を通じて公開されるアクティビティ セッションとして設定します。 「**方法: ユーザーの現在のアクティビティの設定**」を参照してください。
5.  ユーザーをアクティブとしてゲーム セッションに参加させます。 ユーザーはピアに接続し、ゲーム プレイまたはロビーに入ることができるようになります。

次のフロー チャートは、タイトルのアクティベーションを処理する方法を示しています。

![](../../images/multiplayer/Multiplayer_2015_OnActivation.png)

## <a name="make-the-user-joinable"></a>ユーザーを参加可能にする

ユーザーを参加可能にするには、タイトルで次の手順を行う必要があります。

1.  セッション オブジェクトを作成し、必要に応じて属性を変更します。
2.  ユーザーをアクティブとしてセッションに参加させます。 「**方法: タイトルのアクティベーションからの MPSD セッションへの参加**」を参照してください。
3.  ユーザーがセッション アービターとして指定されているかどうかを確認します。
4.  ユーザーがアービターでない場合は、手順 7 に進みます。
5.  ユーザーがアービターである場合は、「**MultiplayerSession.SetHostDeviceToken メソッド**を呼び出します。
6.  **MultiplayerService.TryWriteSessionAsync メソッド**の呼び出しを使用して、セッションの書き込みを試みます。
7.  セッションをアクティブなセッションとして設定します。 「**方法: ユーザーの現在のアクティビティの設定**」を参照してください。

次のフロー チャートは、ゲーム中に他のプレイヤーによってユーザーが参加できるようにするための手順を示します。

![](../../images/multiplayer/Multiplayer_2015_Become_Joinable.png)

## <a name="send-game-invites"></a>ゲームへの招待の送信

タイトルでは、次の方法でプレイヤーがゲームへの招待を送信することを可能にできます。

-   ロビー セッションの招待を送信する。
-   一般的な Xbox プラットフォームの招待 UI を使用して、ゲーム セッションの参照と共に招待を送信する。

プレイヤーにゲームへの招待を送信するには、タイトルで次の手順を行う必要があります。

1.  招待側プレイヤーを参加可能にします。 「**方法: ユーザーを参加可能にする**」を参照してください。
2.  招待をロビー セッション経由で送信するか、招待 UI を使用して送信するかを決定します。
3.  ロビー セッションを使用する場合は、**MultiplayerService.SendInvitesAsync メソッド**の呼び出しを使用して招待を送信します。 このメソッドには、**SystemUI.ShowPeoplePickerAsync メソッド**または **PartyChat.GetPartyChatViewAsync メソッド**を使用するゲーム内 UI ロースターの構築が必要な場合があります。
4.  招待 UI を使用する場合は、**SystemUI.ShowSendGameInvitesAsync メソッド**を呼び出して招待 UI を表示します。
5.  リモート プレイヤーが参加した後に、ローカル プレイヤーの **RealTimeActivityService.MultiplayerSessionChanged イベント**を処理します。
6.  リモート プレイヤーのために、タイトルのアクティベーション コードを実装します。 「**方法: タイトルのアクティベーションの管理**」を参照してください。

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

ユーザーが Xbox シェル UI を使用してフレンドのアクティビティに参加する、または招待を受け入れることを選択すると、タイトルは、ユーザーが参加を希望するセッションを示すパラメーターを使ってアクティブ化されます。 タイトルは、このアクティベーションを処理し、対応するセッションにユーザーを追加する必要があります。

タイトルで実行する手順を次に示します。

1.  **CoreApplicationView.Activated イベント**のイベント ハンドラーを実装します。 このイベントは、タイトルのアクティベーションを通知します。
2.  ハンドラーが発生したら、**IActivatedEventArgs.Kind プロパティ**を調べます。 Protocol に設定されている場合は、イベント引数を **ProtocolActivatedEventArgs クラス**にキャストします。
3.  **ProtocolActivatedEventArgs** オブジェクトを調べます。 **ProtocolActivatedEventArgs.Uri プロパティ**に指定されている URI が inviteHandleAccept (受け入れた招待に対応) または activityHandleJoin (シェル UI 経由での参加に対応) のいずれかに一致する場合は、キーと値のペアを含む通常の URI クエリ文字列としてフォーマットされた、URI のクエリ文字列を解析し、以下のフィールドを抽出します。
    -   受け入れた招待の場合:
        1.  ハンドル
        2.  invitedXuid
        3.  senderXuid
    -   参加の場合:
        1.  ハンドル
        2.  joinerXuid
        3.  joineeXuid

4.  タイトルのマルチプレイヤー コードを開始します。このコードには、**MultiplayerService.EnableMultiplayerSubscriptions メソッド**の呼び出しが含まれている必要があります。
5.  ローカルの **MultiplayerSession クラス** オブジェクトを、**MultiplayerSession コンストラクター (XboxLiveContext)** を使用して作成します。
6.  **MultiplayerSession.Join メソッド (String, Boolean, Boolean)** を呼び出してセッションに参加します。 以下のパラメーターを設定して、参加がアクティブとして設定されるようにします。
    -   *memberCustomConstantsJson* = null
    -   *initializeRequested* = false
    -   *joinWithActiveStatus* = true

7.  **MultiplayerSession.SetSessionChangeSubscription メソッド**を呼び出して、参加後にセッションが変更したときにショルダー タップを受けられるようにします。
8.  手順 3 の説明に従って取得したハンドルを使用して、**MultiplayerService.WriteSessionByHandleAsync メソッド**を呼び出します。 ユーザーはセッションのメンバーになっているので、セッション内のデータを使用してゲームに接続できます。

## <a name="set-the-users-current-activity"></a>ユーザーの現在のアクティビティの設定

ユーザーの現在のアクティビティは、タイトルの Xbox ダッシュボードのユーザー エクスペリエンスに表示されます。 ユーザーのアクティビティは、セッションまたはタイトルのアクティベーションを通じて設定できます。 後者の場合、ユーザーはマッチメイキングを通じて、またはゲームを起動してセッションを開始します。

| 注意                                                                                                                                                  |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| セッションを通じて設定されたアクティビティは、**MultiplayerService.ClearActivityAsync メソッド**の呼び出しで削除できます。 |

セッションをユーザーの現在のアクティビティとして設定するには、タイトルは **MultiplayerService.SetActivityAsync メソッド**を呼び出し、セッションの参照を渡します。

タイトルのアクティベーションを通じてユーザーの現在のアクティビティを設定するには、「**方法: タイトルのアクティベーションからの MPSD セッションへの参加**」をご覧ください。

## <a name="update-an-mpsd-session"></a>MPSD セッションの更新

| 注意                                                                                                                                                 |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| タイトルがマルチプレイヤー API を使用して既存のセッションを更新する場合は、セッションの書き込みを呼び出すまで、ローカル コピーを扱うことになるので注意してください。 |

既存のセッションを更新するには、タイトルは以下の操作を実行する必要があります。

1.  現在のセッションを必要に応じて変更します (たとえば **MultiplayerSession.Leave メソッド**を呼び出すことで)。
2.  すべての変更を加えたら、以下のメソッドのいずれかを使用して、MPSD へローカルの変更内容を書き込みます。

    -   **MultiplayerService.WriteSessionAsync メソッド**
    -   **MultiplayerService.WriteSessionByHandleAsync メソッド**
    -   **MultiplayerService.TryWriteSessionAsync メソッド**
    -   **MultiplayerService.TryWriteSessionByHandleAsync メソッド**

    他のタイトルも変更できる共有部分に書き込む場合は、書き込みモードを **SynchronizedUpdate** に設定します。 詳細については、「[セッション更新の同期](multiplayer-session-directory.md)」を参照してください。

    書き込みメソッドは参加をサーバーに書き込み、最新のセッションを取得して、そのセッションから他のセッション メンバーと本体のセキュア デバイス アドレス (SDA) を検出します。 これらの本体間でネットワーク接続を確立する方法の詳細については、「**Xbox One の Winsock の概要**」を参照してください。

3.  最新の既知のセッション状態に基づいて今後の処理を実行できるように、古いローカルのセッション オブジェクトを破棄し、新たに取得したセッション オブジェクトを使用します。

## <a name="leave-an-mpsd-session"></a>MPSD セッションからの退出

ユーザーがセッションから退出できるようにするには、タイトルで次の手順を行う必要があります。

1.  ゲーム セッションの **MultiplayerSession.Leave メソッド**を呼び出します。
2.  「**方法: マルチプレイヤー セッションの更新**」で説明されているように、MPSD でゲーム セッションを更新します。
3.  必要に応じて、ロビー セッションの **Leave** メソッドを呼び出し、そのセッションを更新します。
4.  ロビー セッションに必要な場合、**RealTimeActivityService.MultiplayerSubscriptionsLost イベント**と **RealTimeActivityService.MultiplayerSessionChanged イベント**の登録を解除して、マルチプレイヤー API をシャット ダウンします。

次のフロー チャートは、セッションから退出して、シャットダウンする方法を示します。

![](../../images/multiplayer/Multiplayer_2015_Shut_Down.png)

## <a name="fill-open-session-slots-during-matchmaking"></a>マッチメイキング中に空きセッション スロットを埋める

マッチメイキング中にチケット セッションの空きスロットを埋めるには、タイトルで次のような手順に従う必要があります。

1.  マッチメイキング中に作成されたチケット セッションの最新のセッション状態にアクセスします。
2.  ロビー セッションからゲーム プレイに参加可能なプレイヤーを追加します。
3.  チケット セッションがいっぱいになっているかどうかを確認します。
4.  セッションがいっぱいの場合、ゲーム プレイを続行します。
5.  セッションがまだいっぱいでない場合は、「**方法: マッチ チケットの作成**」で説明されているようにマッチ チケットを作成します。 チケットを作成するには必ず *preserveSession* パラメーターを Always に設定します。
6.  マッチメイキングを続行します。 「[SmartMatch マッチメイキングの使用](using-smartmatch-matchmaking.md)」を参照してください。

次のフロー チャートは、マッチメイキング中に空きセッション スロットを埋める方法を示しています。

![](../../images/multiplayer/Multiplayer_2015_Fill_Open_Slots.png)

## <a name="create-a-match-ticket"></a>マッチ チケットの作成

マッチ チケットを作成するには、マッチメイキング スカウトは次の処理を実行する必要があります。

1.  **MatchmakingService.CreateMatchTicketAsync メソッド**を呼び出し、チケット セッションへの参照を渡します。 このメソッドは、MPSD からチケット セッションを読み取り、セッション内のユーザーのマッチメイキングを開始します。 メソッドは内部的に **POST (/serviceconfigs/{scid}/hoppers/{hoppername})** を呼び出します。
2.  マッチメイキング サービスがセッションのメンバーを新しいセッションまたは別の既存のセッションにマッチングする場合は、*preserveSession* パラメーターを Never に設定します。 タイトルがゲーム プレイを続行するためのチケット セッションとして既存のゲーム セッションを再利用できるようにするには、*preserveSession* パラメーターを Always に設定します。 この場合、マッチメイキング サービスは、送信されたセッションを保持し、適合したプレイヤーをそのセッションに追加できるようになります。

3.  **CreateMatchTicketResponse クラス** オブジェクトで返される **CreateMatchTicketResponse.EstimatedWaitTime プロパティ**を使用して、マッチメイキング時間のユーザーの期待を設定します。
4.  必要な場合は、応答オブジェクトで返される **CreateMatchTicketResponse.MatchTicketId プロパティ**を使用して、チケットを削除することによって、セッションのマッチメイキングをキャンセルします。 チケットの削除には **MatchmakingService.DeleteMatchTicketAsync メソッド**を使用します。

## <a name="get-match-ticket-status"></a>マッチ チケットのステータスの取得

タイトルがマッチ チケットのステータスを取得するには、次の手順を実行します。

1.  チケット セッションの **MultiplayerSession クラス** オブジェクトを取得します。
2.  **MultiplayerSession.MatchmakingServer プロパティ**を使用して、マッチメイキングに使用される **MatchmakingServer クラス** オブジェクトにアクセスします。
3.  一致するものが見つかった場合、**MatchmakingServer** オブジェクトをチェックして、マッチメイキング プロセスのステータス、セッションの標準的な待機時間、およびターゲット セッションの参照を特定します。
