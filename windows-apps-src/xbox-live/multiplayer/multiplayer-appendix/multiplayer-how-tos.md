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
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6264055"
---
# <a name="multiplayer-how-tos"></a><span data-ttu-id="90757-104">マルチプレイヤーの実行方法</span><span class="sxs-lookup"><span data-stu-id="90757-104">Multiplayer how-to's</span></span>

<span data-ttu-id="90757-105">このトピックには、マルチプレイヤー 2015 の使用に関連する特定のタスクの実装方法についての情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="90757-105">This topic contains information on how to implement specific tasks related to using multiplayer 2015.</span></span>

* <span data-ttu-id="90757-106">MPSD セッション変更通知のサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="90757-106">Subscribe for MPSD session change notifications</span></span>
* <span data-ttu-id="90757-107">MPSD セッションの作成</span><span class="sxs-lookup"><span data-stu-id="90757-107">Create an MPSD session</span></span>
* <span data-ttu-id="90757-108">MPSD セッションのアービターの設定</span><span class="sxs-lookup"><span data-stu-id="90757-108">Set an arbiter for an MPSD session</span></span>
* <span data-ttu-id="90757-109">タイトルのアクティベーションの管理</span><span class="sxs-lookup"><span data-stu-id="90757-109">Manage Title Activation</span></span>
* <span data-ttu-id="90757-110">ユーザーを参加可能にする</span><span class="sxs-lookup"><span data-stu-id="90757-110">Make the user joinable</span></span>
* <span data-ttu-id="90757-111">ゲームへの招待の送信</span><span class="sxs-lookup"><span data-stu-id="90757-111">Send game invites</span></span>
* <span data-ttu-id="90757-112">ロビー セッションからゲーム セッションへの参加</span><span class="sxs-lookup"><span data-stu-id="90757-112">Join a game session from a lobby session</span></span>
* <span data-ttu-id="90757-113">タイトルのアクティベーションからの MPSD セッションへの参加</span><span class="sxs-lookup"><span data-stu-id="90757-113">Join an MPSD session from a Title Activation</span></span>
* <span data-ttu-id="90757-114">ユーザーの現在のアクティビティの設定</span><span class="sxs-lookup"><span data-stu-id="90757-114">Set the user's current activity</span></span>
* <span data-ttu-id="90757-115">MPSD セッションの更新</span><span class="sxs-lookup"><span data-stu-id="90757-115">Update an MPSD session</span></span>
* <span data-ttu-id="90757-116">MPSD セッションからの退出</span><span class="sxs-lookup"><span data-stu-id="90757-116">Leave an MPSD session</span></span>
* <span data-ttu-id="90757-117">マッチメイキング中に空きセッション スロットを埋める</span><span class="sxs-lookup"><span data-stu-id="90757-117">Fill open session slots during matchmaking</span></span>
* <span data-ttu-id="90757-118">マッチ チケットの作成</span><span class="sxs-lookup"><span data-stu-id="90757-118">Create a match ticket</span></span>
* <span data-ttu-id="90757-119">マッチ チケットのステータスの取得</span><span class="sxs-lookup"><span data-stu-id="90757-119">Get match ticket status</span></span>

## <a name="subscribe-for-mpsd-session-change-notifications"></a><span data-ttu-id="90757-120">MPSD セッション変更通知のサブスクライブ</span><span class="sxs-lookup"><span data-stu-id="90757-120">Subscribe for MPSD session change notifications</span></span>

| <span data-ttu-id="90757-121">注意</span><span class="sxs-lookup"><span data-stu-id="90757-121">Note</span></span>                                                                                                                                                                                                                                                                                                                                    |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-122">セッションの変更をサブスクライブするには、関連付けられているプレイヤーがセッションでアクティブであることが必要です。</span><span class="sxs-lookup"><span data-stu-id="90757-122">Subscribing for changes to a session requires the associated player to be active in the session.</span></span> <span data-ttu-id="90757-123">また、connectionRequiredForActiveMembers フィールドが、セッションの /constants/system/capabilities オブジェクトで true に設定されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-123">The connectionRequiredForActiveMembers field must also be set to true in the /constants/system/capabilities object for the session.</span></span> <span data-ttu-id="90757-124">このフィールドは、通常、セッション テンプレートで設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-124">This field is usually set in the session template.</span></span> <span data-ttu-id="90757-125">「[MPSD セッション テンプレート](multiplayer-session-directory.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-125">See [MPSD Session Templates](multiplayer-session-directory.md).</span></span> |



<span data-ttu-id="90757-126">MPSD セッション変更通知を受信するには、タイトルは次の手順を実行することができます。</span><span class="sxs-lookup"><span data-stu-id="90757-126">To receive MPSD session change notifications, the title can follow the procedure below.</span></span>

1.  <span data-ttu-id="90757-127">同じユーザーによる呼び出しには必ず同じ **XboxLiveContext クラス** オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="90757-127">Use the same **XboxLiveContext Class** object for all calls by the same user.</span></span> <span data-ttu-id="90757-128">サブスクリプションは、このオブジェクトの有効期間に関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="90757-128">Subscriptions are tied to the lifetime of this object.</span></span> <span data-ttu-id="90757-129">複数のローカル ユーザーが存在する場合は、ユーザーごとに個別の **XboxLiveContext** オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="90757-129">If there are multiple local users, use a separate **XboxLiveContext** object for each user.</span></span>
2.  <span data-ttu-id="90757-130">**RealTimeActivityService.MultiplayerSessionChanged イベント**および **RealTimeActivityService.MultiplayerSubscriptionsLost イベント**のイベント ハンドラーを実装します。</span><span class="sxs-lookup"><span data-stu-id="90757-130">Implement event handlers for the **RealTimeActivityService.MultiplayerSessionChanged Event** and the **RealTimeActivityService.MultiplayerSubscriptionsLost Event**.</span></span>
3.  <span data-ttu-id="90757-131">複数のユーザーの変更をサブスクライブする場合は、不要な作業を避けるためのコードを **MultiplayerSessionChanged** イベント ハンドラーに追加します。</span><span class="sxs-lookup"><span data-stu-id="90757-131">If subscribing to changes for more than one user, add code to your **MultiplayerSessionChanged** event handler to avoid unnecessary work.</span></span> <span data-ttu-id="90757-132">**RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**と **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**を使用します。</span><span class="sxs-lookup"><span data-stu-id="90757-132">Use the **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property** and the **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property**.</span></span> <span data-ttu-id="90757-133">これらのプロパティを使用することで、最後に確認された変更を追跡し、より古い変更を無視できます。</span><span class="sxs-lookup"><span data-stu-id="90757-133">Use of these properties allows tracking of the last change seen and ignoring of older changes.</span></span>
4.  <span data-ttu-id="90757-134">**MultiplayerService.EnableMultiplayerSubscriptions メソッド**を呼び出してサブスクリプションを許可します。</span><span class="sxs-lookup"><span data-stu-id="90757-134">Call the **MultiplayerService.EnableMultiplayerSubscriptions Method** to allow subscriptions.</span></span>
5.  <span data-ttu-id="90757-135">ローカル セッション オブジェクトを作成し、そのセッションをアクティブとして参加させます。</span><span class="sxs-lookup"><span data-stu-id="90757-135">Create a local session object and join that session as active.</span></span>
6.  <span data-ttu-id="90757-136">各ユーザーに対して **MultiplayerSession.SetSessionChangeSubscription メソッド**の呼び出しを行い、通知の対象となるセッション変更の種類を渡します。</span><span class="sxs-lookup"><span data-stu-id="90757-136">Make calls for each user to the **MultiplayerSession.SetSessionChangeSubscription Method**, passing the session change type for which to be notified.</span></span>
7.  <span data-ttu-id="90757-137">「**方法: マルチプレイヤー セッションの更新**」に説明されているように、セッションを MPSD に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="90757-137">Now write the session to MPSD as described in **How to: Update a Multiplayer Session**.</span></span>

<span data-ttu-id="90757-138">次のフロー チャートは、この手順で説明するイベントにサブスクライブしてマルチプレイヤーを開始する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="90757-138">The following flow chart illustrates how to start Multplayer by subscribing to the events described in this procedure.</span></span>

![](../../images/multiplayer/Multiplayer_2015_Start_Multiplayer.png)


### <a name="parsing-duplicate-session-change-notifications"></a><span data-ttu-id="90757-139">重複するセッション変更通知の解析</span><span class="sxs-lookup"><span data-stu-id="90757-139">Parsing duplicate session change notifications</span></span>

<span data-ttu-id="90757-140">同じセッションの通知をサブスクライブする複数のユーザーがいる場合、そのセッションへの変更はすべて、各ユーザーに対してショルダー タップをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="90757-140">When there are multiple users subscribed to notifications for the same session, every change to that session will trigger a shoulder tap for each user.</span></span> <span data-ttu-id="90757-141">これらは 1 つを除いてすべて重複になります。</span><span class="sxs-lookup"><span data-stu-id="90757-141">All but one of these will be duplicates.</span></span> <span data-ttu-id="90757-142">タイトルが通知に対してセッション内のすべてのユーザーをサブスクライブすることをお勧めするものの、既に通知された変更は無視してください。これは、Branch および ChangeNumber プロパティを使用して行うことができます。</span><span class="sxs-lookup"><span data-stu-id="90757-142">While it's still recommended that a title subscribe every user in a session to notifications, a title should ignore any changes that it's already been notified of; you can do this using the Branch and ChangeNumber properties.</span></span>

<span data-ttu-id="90757-143">複数のショルダー タップを検出するには、タイトルで以下を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-143">To detect multiple shoulder taps, a title should:</span></span>

-   <span data-ttu-id="90757-144">確認される **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**値ごとに、最新の **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**を保存します。</span><span class="sxs-lookup"><span data-stu-id="90757-144">For each **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property** value seen, store the latest **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property**.</span></span>
-   <span data-ttu-id="90757-145">ショルダー タップの **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**がその **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**で最後に確認されたものよりも高い場合は、それを処理し、最新の **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**を更新します。</span><span class="sxs-lookup"><span data-stu-id="90757-145">If a shoulder tap has a higher **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** than the last seen for that **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property**, process it and update the latest **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property**.</span></span>
-   <span data-ttu-id="90757-146">ショルダー タップの **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**がその **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**より高くない場合は、スキップします。</span><span class="sxs-lookup"><span data-stu-id="90757-146">If a shoulder tap does not have a higher **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** for that **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property**, skip it.</span></span> <span data-ttu-id="90757-147">その変更は、既に処理されています。</span><span class="sxs-lookup"><span data-stu-id="90757-147">That change has already been handled.</span></span>

| <span data-ttu-id="90757-148">注意</span><span class="sxs-lookup"><span data-stu-id="90757-148">Note</span></span>                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-149">**RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**値は、セッションによってではなく、**RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**によって追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-149">**RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** values need to be tracked by **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property**, not by session.</span></span> <span data-ttu-id="90757-150">**RealTimeActivityMultiplayerSessionChangeEventArgs.Branch プロパティ**値はセッションの有効期間内に変更される (および **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber プロパティ**がリセットされる) 可能性があります。</span><span class="sxs-lookup"><span data-stu-id="90757-150">It's possible for the **RealTimeActivityMultiplayerSessionChangeEventArgs.Branch Property** value to change (and the **RealTimeActivityMultiplayerSessionChangeEventArgs.ChangeNumber Property** to reset) within the lifetime of a session.</span></span> |

## <a name="create-an-mpsd-session"></a><span data-ttu-id="90757-151">MPSD セッションの作成</span><span class="sxs-lookup"><span data-stu-id="90757-151">Create an MPSD session</span></span>


| <span data-ttu-id="90757-152">注意</span><span class="sxs-lookup"><span data-stu-id="90757-152">Note</span></span>                                                                                                                                                                                                                           |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-153">既定では、最初のメンバーが参加したときに MPSD セッションが作成されます。</span><span class="sxs-lookup"><span data-stu-id="90757-153">By default, an MPSD session is created when the first member joins it.</span></span> <span data-ttu-id="90757-154">タイトル ロジックが参加時にタイトルが存在するか存在しないかを予期している場合は、セッション更新時に適切な書き込みモードの値を書き込みメソッドに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="90757-154">If your title logic expects the title to exist or not exist at join time, it can pass an appropriate write mode value to the write method during the session update.</span></span> |



<span data-ttu-id="90757-155">タイトルは以下の処理を実行し、新しいセッションを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-155">The title must do the following to create a new session:</span></span>

1.  <span data-ttu-id="90757-156">新しい **XboxLiveContext クラス**オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="90757-156">Create a new **XboxLiveContext Class** object.</span></span> <span data-ttu-id="90757-157">タイトルはこのオブジェクトを 1 回作成して格納し、ソース コード全体で必要に応じて再利用します。</span><span class="sxs-lookup"><span data-stu-id="90757-157">Your title creates this object once, stores it, and reuses it as required throughout the source code.</span></span> <span data-ttu-id="90757-158">特にセッションのサブスクリプションを使用する場合は、まったく同じコンテキストを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-158">Especially when working with session subscriptions, it is necessary to use exactly the same context.</span></span>
2.  <span data-ttu-id="90757-159">新しい **MultiplayerSession クラス** オブジェクトを作成し、MPSD による新しいセッションの作成に必要なすべてのセッション データを準備します。</span><span class="sxs-lookup"><span data-stu-id="90757-159">Create a new **MultiplayerSession Class** object to prepare all the session data that the MPSD needs to create a new session.</span></span>
3.  <span data-ttu-id="90757-160">セッションを MPSD に書き込む前に必要な変更を行います。</span><span class="sxs-lookup"><span data-stu-id="90757-160">Make required changes before writing the session to MPSD.</span></span> <span data-ttu-id="90757-161">たとえば、**MultiplayerSession.Join メソッド**を呼び出してメンバーをセッションに参加させる場合は、クライアントは、セッション更新の呼び出し時に参加させるように MPSD に指示する非表示ローカル要求データを追加します。</span><span class="sxs-lookup"><span data-stu-id="90757-161">For example, when joining a member to the session with a call to **MultiplayerSession.Join Method**, the client adds hidden local request data that tells MPSD to join upon the call to update the session.</span></span>
4.  <span data-ttu-id="90757-162">ローカルの変更が完了したら、「**方法: マルチプレイヤー セッションの更新**」で説明されているように MPSD に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="90757-162">When finished making local changes, write them to MPSD as described in **How to: Update a Multiplayer Session**.</span></span>
5.  <span data-ttu-id="90757-163">MPSD から、多くのフィールドが入力された新しい **MultiplayerSession** オブジェクトを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="90757-163">Receive the new **MultiplayerSession** object from MPSD, with many fields filled in.</span></span>
6.  <span data-ttu-id="90757-164">今後は、この新しいセッション オブジェクトを使用し、新しいセッションを作成するための非表示要求が含まれている古いコピーは破棄します。</span><span class="sxs-lookup"><span data-stu-id="90757-164">Use the new session object going forward, and discard the old copy, which contains a hidden request to create a new session.</span></span>

### <a name="example"></a><span data-ttu-id="90757-165">例</span><span class="sxs-lookup"><span data-stu-id="90757-165">Example</span></span>

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


## <a name="set-an-arbiter-for-an-mpsd-session"></a><span data-ttu-id="90757-166">MPSD セッションのアービターの設定</span><span class="sxs-lookup"><span data-stu-id="90757-166">Set an arbiter for an MPSD session</span></span>




<span data-ttu-id="90757-167">タイトルは、次の手順を使用して、作成済みのセッションのアービターを設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-167">The title uses the following procedure to set an arbiter for a session that has already been created.</span></span>

| <span data-ttu-id="90757-168">注意</span><span class="sxs-lookup"><span data-stu-id="90757-168">Note</span></span>                                                                                                                                       |
|---------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-169">メンバーのデバイス トークン (潜在的なホスト) は、メンバーがセッションに参加して、セキュア デバイス アドレスが含まれるまでは利用できません。</span><span class="sxs-lookup"><span data-stu-id="90757-169">Device tokens for the members (potential hosts) are not available until the members have joined the session and included their secure device addresses.</span></span> |

1.  <span data-ttu-id="90757-170">**MultiplayerSession.Members プロパティ**を使用して、MPSD からホスト候補のデバイス トークンを取得します。</span><span class="sxs-lookup"><span data-stu-id="90757-170">Retrieve the device tokens for host candidates from the MPSD by using the **MultiplayerSession.Members Property**.</span></span>

| <span data-ttu-id="90757-171">注意</span><span class="sxs-lookup"><span data-stu-id="90757-171">Note</span></span>                                                                                                                                                                                                                     |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
    | <span data-ttu-id="90757-172">SmartMatch マッチメイキングによってセッションが作成された場合、クライアントは、**MultiplayerSession.HostCandidates プロパティ**を通じて MPSD から利用できるホスト候補を使用できます。</span><span class="sxs-lookup"><span data-stu-id="90757-172">If the session was created by SmartMatch matchmaking, your clients can use the host candidates available from MPSD through the **MultiplayerSession.HostCandidates Property**.</span></span> |

2.  <span data-ttu-id="90757-173">ホスト候補の一覧から、必要なホストを選択します。</span><span class="sxs-lookup"><span data-stu-id="90757-173">Select the required host from the list of host candidates.</span></span>
3.  <span data-ttu-id="90757-174">**MultiplayerSession.SetHostDeviceToken メソッド**を呼び出して、MPSD のローカル キャッシュでデバイス トークンを設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-174">Call the **MultiplayerSession.SetHostDeviceToken Method** to set the device token in the local cache of the MPSD.</span></span> <span data-ttu-id="90757-175">ホスト デバイス トークンを設定する呼び出しが成功した場合、ローカル デバイス トークンがホストのトークンに取って代わります。</span><span class="sxs-lookup"><span data-stu-id="90757-175">If the call to set the host device token succeeds, the local device token replaces the host's token.</span></span>
4.  <span data-ttu-id="90757-176">ホスト デバイス トークンを設定しようとしたときに HTTP/412 ステータス コードを受け取った場合は、セッション データを照会して、ホスト デバイス トークンがローカル本体用かどうか確認してください。</span><span class="sxs-lookup"><span data-stu-id="90757-176">If an HTTP/412 status code is received when trying to set the host device token, query the session data and see if the host device token is for the local console.</span></span> <span data-ttu-id="90757-177">ローカル本体用でない場合は、別の本体がアービターとして指定されています。</span><span class="sxs-lookup"><span data-stu-id="90757-177">If it is not for the local console, another console has been designated as the arbiter.</span></span>

| <span data-ttu-id="90757-178">注意</span><span class="sxs-lookup"><span data-stu-id="90757-178">Note</span></span>                                                                                                                                                                                                                              |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-179">HTTP/412 は標準的なエラーを示していないので、クライアントはその他の HTTP コードとは切り離して HTTP/412 ステータス コードを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-179">Your client should handle the HTTP/412 status code separately from other HTTP codes, since HTTP/412 does not indicate a standard failure.</span></span> <span data-ttu-id="90757-180">ステータス コードの詳細については、「[マルチプレイヤー セッション ステータス コード](multiplayer-session-status-codes.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-180">For more about the status code, see [Multiplayer Session Status Codes](multiplayer-session-status-codes.md).</span></span> |

5.  <span data-ttu-id="90757-181">「**方法: マルチプレイヤー セッションの更新**」で説明されているように、MPSD でセッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="90757-181">Update the session in MPSD, as described in **How to: Update a Multiplayer Session**.</span></span>

| <span data-ttu-id="90757-182">注意</span><span class="sxs-lookup"><span data-stu-id="90757-182">Note</span></span>                                                                                                                                                                                                                                           |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-183">より良いアルゴリズムがない場合、クライアントでは、他にホストが設定されていない場合に、各ホストが自分自身をホストとして設定しようとする greedy algorithm (貪欲法) を実装できます。</span><span class="sxs-lookup"><span data-stu-id="90757-183">If you have no better algorithm, the client can implement a greedy algorithm in which each host candidate attempts to set itself as the host if nobody else has done it yet.</span></span> <span data-ttu-id="90757-184">詳しくは、「[セッション アービター](mpsd-session-details.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="90757-184">For more information, see [Session Arbiter](mpsd-session-details.md).</span></span> |

## <a name="manage-title-activation"></a><span data-ttu-id="90757-185">タイトルのアクティベーションの管理</span><span class="sxs-lookup"><span data-stu-id="90757-185">Manage title activation</span></span>

<span data-ttu-id="90757-186">Xbox One は、プロトコル アクティベーション時に **CoreApplicationView.Activated イベント**を発生させます。</span><span class="sxs-lookup"><span data-stu-id="90757-186">Xbox One fires the **CoreApplicationView.Activated Event** during protocol activation.</span></span> <span data-ttu-id="90757-187">マルチプレイヤー API に関しては、ユーザーが招待を受け入れるか、別のユーザーに加わるときにこのイベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="90757-187">In the context of the multiplayer API, this event is fired when a user accepts an invite or joins another user.</span></span> <span data-ttu-id="90757-188">これらのアクションは、参加するユーザーをターゲット ユーザーとのゲーム プレイに加えることにより、タイトルが対応する必要があるアクティベーションをトリガーします。</span><span class="sxs-lookup"><span data-stu-id="90757-188">These actions trigger an activation that the title must react to by bringing the joining user into game play with the target user.</span></span>

| <span data-ttu-id="90757-189">注意</span><span class="sxs-lookup"><span data-stu-id="90757-189">Note</span></span>                                                                                       |
|---------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-190">タイトルでは常に新しいアクティベーション引数を予期する必要があり、長さに関するコーディングを行わないようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-190">Your title should expect new activation arguments at any time and should never be coded against length.</span></span> |

<span data-ttu-id="90757-191">タイトルがアクティベーションを処理するためには、次の主な手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-191">The title must perform the following main steps to handle title activation.</span></span>

1.  <span data-ttu-id="90757-192">**CoreApplicationView.Activated イベント**のイベント ハンドラーを設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-192">Set up an event handler for the **CoreApplicationView.Activated Event**.</span></span> <span data-ttu-id="90757-193">このハンドラーは、タイトルが既に実行されている場合でも、プロトコルのアクティベーションが発生するたびにトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="90757-193">This handler triggers every time protocol activation occurs, even if the title is already running.</span></span>
2.  <span data-ttu-id="90757-194">タイトルのアクティベーション時にセッションを開始し、セッションの変更通知をサブスクライブします。</span><span class="sxs-lookup"><span data-stu-id="90757-194">At title activation, begin a session and subscribe for session change notifications.</span></span> <span data-ttu-id="90757-195">「**方法: MPSD セッション変更通知のサブスクライブ**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-195">See **How to: Subscribe for MPSD Session Change Notifications**.</span></span>
3.  <span data-ttu-id="90757-196">ユーザーをアクティブとしてセッションに参加させます。</span><span class="sxs-lookup"><span data-stu-id="90757-196">Join the user to the session as active.</span></span> <span data-ttu-id="90757-197">「**方法: タイトルのアクティベーションからの MPSD セッションへの参加**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-197">See **How to: Join an MPSD Session from a Title Activation**.</span></span>
4.  <span data-ttu-id="90757-198">ロビー セッションを、プロフィール UI を通じて公開されるアクティビティ セッションとして設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-198">Set the lobby session as the activity session, exposed through the profile UI.</span></span> <span data-ttu-id="90757-199">「**方法: ユーザーの現在のアクティビティの設定**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-199">See **How to: Set the User's Current Activity**.</span></span>
5.  <span data-ttu-id="90757-200">ユーザーをアクティブとしてゲーム セッションに参加させます。</span><span class="sxs-lookup"><span data-stu-id="90757-200">Join the user to the game session as active.</span></span> <span data-ttu-id="90757-201">ユーザーはピアに接続し、ゲーム プレイまたはロビーに入ることができるようになります。</span><span class="sxs-lookup"><span data-stu-id="90757-201">Now the user can connect to peers and enter game play or the lobby.</span></span>

<span data-ttu-id="90757-202">次のフロー チャートは、タイトルのアクティベーションを処理する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="90757-202">The following flow chart illustrates how to handle title activation.</span></span>

![](../../images/multiplayer/Multiplayer_2015_OnActivation.png)

## <a name="make-the-user-joinable"></a><span data-ttu-id="90757-203">ユーザーを参加可能にする</span><span class="sxs-lookup"><span data-stu-id="90757-203">Make the user joinable</span></span>

<span data-ttu-id="90757-204">ユーザーを参加可能にするには、タイトルで次の手順を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-204">To make the user joinable, the title must do the following:</span></span>

1.  <span data-ttu-id="90757-205">セッション オブジェクトを作成し、必要に応じて属性を変更します。</span><span class="sxs-lookup"><span data-stu-id="90757-205">Create a session object, and modify the attributes as required.</span></span>
2.  <span data-ttu-id="90757-206">ユーザーをアクティブとしてセッションに参加させます。</span><span class="sxs-lookup"><span data-stu-id="90757-206">Join the user to the session as active.</span></span> <span data-ttu-id="90757-207">「**方法: タイトルのアクティベーションからの MPSD セッションへの参加**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-207">See **How to: Join an MPSD Session from a Title Activation**.</span></span>
3.  <span data-ttu-id="90757-208">ユーザーがセッション アービターとして指定されているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="90757-208">Determine if the user has been designated as the session arbiter.</span></span>
4.  <span data-ttu-id="90757-209">ユーザーがアービターでない場合は、手順 7 に進みます。</span><span class="sxs-lookup"><span data-stu-id="90757-209">If the user is not the arbiter, go to step 7.</span></span>
5.  <span data-ttu-id="90757-210">ユーザーがアービターである場合は、「**MultiplayerSession.SetHostDeviceToken メソッド**を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="90757-210">If the user is the arbiter, call the **MultiplayerSession.SetHostDeviceToken Method**.</span></span>
6.  <span data-ttu-id="90757-211">**MultiplayerService.TryWriteSessionAsync メソッド**の呼び出しを使用して、セッションの書き込みを試みます。</span><span class="sxs-lookup"><span data-stu-id="90757-211">Attempt to write the session using a call to the **MultiplayerService.TryWriteSessionAsync Method**.</span></span>
7.  <span data-ttu-id="90757-212">セッションをアクティブなセッションとして設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-212">Set the session as the active session.</span></span> <span data-ttu-id="90757-213">「**方法: ユーザーの現在のアクティビティの設定**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-213">See **How to: Set the User's Current Activity**.</span></span>

<span data-ttu-id="90757-214">次のフロー チャートは、ゲーム中に他のプレイヤーによってユーザーが参加できるようにするための手順を示します。</span><span class="sxs-lookup"><span data-stu-id="90757-214">The following flow chart illustrates the steps to take to allow a user to be joined by other players during a game.</span></span>

![](../../images/multiplayer/Multiplayer_2015_Become_Joinable.png)

## <a name="send-game-invites"></a><span data-ttu-id="90757-215">ゲームへの招待の送信</span><span class="sxs-lookup"><span data-stu-id="90757-215">Send game invites</span></span>

<span data-ttu-id="90757-216">タイトルでは、次の方法でプレイヤーがゲームへの招待を送信することを可能にできます。</span><span class="sxs-lookup"><span data-stu-id="90757-216">The title can enable a player to send game invites in the following ways:</span></span>

-   <span data-ttu-id="90757-217">ロビー セッションの招待を送信する。</span><span class="sxs-lookup"><span data-stu-id="90757-217">Send the invites for the lobby session.</span></span>
-   <span data-ttu-id="90757-218">一般的な Xbox プラットフォームの招待 UI を使用して、ゲーム セッションの参照と共に招待を送信する。</span><span class="sxs-lookup"><span data-stu-id="90757-218">Send the invites using the generic Xbox platform invite UI with the game session reference.</span></span>

<span data-ttu-id="90757-219">プレイヤーにゲームへの招待を送信するには、タイトルで次の手順を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-219">To send game invites for a player, the title must do the following:</span></span>

1.  <span data-ttu-id="90757-220">招待側プレイヤーを参加可能にします。</span><span class="sxs-lookup"><span data-stu-id="90757-220">Make the inviting game player joinable.</span></span> <span data-ttu-id="90757-221">「**方法: ユーザーを参加可能にする**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-221">See **How to: Make the User Joinable**.</span></span>
2.  <span data-ttu-id="90757-222">招待をロビー セッション経由で送信するか、招待 UI を使用して送信するかを決定します。</span><span class="sxs-lookup"><span data-stu-id="90757-222">Determine if the invites are to be sent via the lobby session or using the invite UI.</span></span>
3.  <span data-ttu-id="90757-223">ロビー セッションを使用する場合は、**MultiplayerService.SendInvitesAsync メソッド**の呼び出しを使用して招待を送信します。</span><span class="sxs-lookup"><span data-stu-id="90757-223">If using the lobby session, send the invites using a call to **MultiplayerService.SendInvitesAsync Method**.</span></span> <span data-ttu-id="90757-224">このメソッドには、**SystemUI.ShowPeoplePickerAsync メソッド**または **PartyChat.GetPartyChatViewAsync メソッド**を使用するゲーム内 UI ロースターの構築が必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="90757-224">This method might require the building of an in-game UI roster using the **SystemUI.ShowPeoplePickerAsync Method** or the **PartyChat.GetPartyChatViewAsync Method**.</span></span>
4.  <span data-ttu-id="90757-225">招待 UI を使用する場合は、**SystemUI.ShowSendGameInvitesAsync メソッド**を呼び出して招待 UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="90757-225">If using the invite UI, call the **SystemUI.ShowSendGameInvitesAsync Method** to show the invite UI.</span></span>
5.  <span data-ttu-id="90757-226">リモート プレイヤーが参加した後に、ローカル プレイヤーの **RealTimeActivityService.MultiplayerSessionChanged イベント**を処理します。</span><span class="sxs-lookup"><span data-stu-id="90757-226">Handle the **RealTimeActivityService.MultiplayerSessionChanged Event** for the local player after the remote player joins.</span></span>
6.  <span data-ttu-id="90757-227">リモート プレイヤーのために、タイトルのアクティベーション コードを実装します。</span><span class="sxs-lookup"><span data-stu-id="90757-227">For the remote player, implement title activation code.</span></span> <span data-ttu-id="90757-228">「**方法: タイトルのアクティベーションの管理**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-228">See **How to: Manage Title Activation**.</span></span>

<span data-ttu-id="90757-229">次のフロー チャートは、招待を送信する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="90757-229">The following flow chart illustrates how to send invites.</span></span>

![](../../images/multiplayer/Multiplayer_2015_Send_Invites.png)

## <a name="join-a-game-session-from-a-lobby-session"></a><span data-ttu-id="90757-230">ロビー セッションからゲーム セッションへの参加</span><span class="sxs-lookup"><span data-stu-id="90757-230">Join a game session from a lobby session</span></span>

<span data-ttu-id="90757-231">Windows 10 デバイスのゲームプレイ セッションでは、大規模なセッションでない場合、`userAuthorizationStyle` 機能を **true** に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-231">Gameplay sessions on Windows 10 devices must have the `userAuthorizationStyle` capability set to **true** if they are not large sessions.</span></span> <span data-ttu-id="90757-232">つまり、`joinRestriction` プロパティを "none" にすることはできません。これは、セッションへの一般からの直接参加はできないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="90757-232">This means that the `joinRestriction` property cannot be "none", which means that the session can't be publicly joinable directly.</span></span>

<span data-ttu-id="90757-233">一般的なシナリオでは、ロビー セッションを作成してプレイヤーを集め、それらのプレイヤーをゲームプレイ セッションまたはマッチメイキング セッションに移動します。</span><span class="sxs-lookup"><span data-stu-id="90757-233">A common scenario is to create a lobby session to gather players, and then move those players into a gameplay session or matchmaking session.</span></span> <span data-ttu-id="90757-234">ただし、ゲームプレイ セッションが一般から参加不可能な場合、ゲーム クライアントは `joinRestriction` 設定を満たしていない限りゲームプレイ セッションに参加できません。この制限は、このようなシナリオには厳しすぎる場合がほとんどです。</span><span class="sxs-lookup"><span data-stu-id="90757-234">But if the gameplay session is not publicly joinable, then the game clients will not be able to join the gameplay session unless they meet the `joinRestriction` setting, which is too restrictive in most cases for this scenario.</span></span>

<span data-ttu-id="90757-235">これを解決するには、転送ハンドルを使ってロビー セッションとゲーム セッションをリンクします。</span><span class="sxs-lookup"><span data-stu-id="90757-235">The solution is use a transfer handle to link the lobby session and the game session.</span></span>  <span data-ttu-id="90757-236">タイトルでは、次の操作でこれを実行できます。</span><span class="sxs-lookup"><span data-stu-id="90757-236">The title can do this by doing the following:</span></span>

1. <span data-ttu-id="90757-237">ゲーム セッションの作成時に、`multiplayer_service::set_transfer_handle(gameSessionRef, lobbySessionRef)` API を使って、ロビー セッションとゲーム セッションをリンクする転送ハンドルを作成します。</span><span class="sxs-lookup"><span data-stu-id="90757-237">When you create the game session, use the `multiplayer_service::set_transfer_handle(gameSessionRef, lobbySessionRef)` API to create a transfer handle that links the lobby session and the game session.</span></span>
2. <span data-ttu-id="90757-238">ゲーム セッションのセッション参照の代わりに、転送ハンドルの GUID をロビー セッションに格納します。</span><span class="sxs-lookup"><span data-stu-id="90757-238">Store the transfer handle GUID in the lobby session instead of the game session's session reference.</span></span>
3. <span data-ttu-id="90757-239">タイトルでロビー セッションからゲーム セッションにメンバーを移動するとき、各クライアントでは、ロビー セッションから転送ハンドルを使い、`multiplayer_service::write_session_by_handle(multiplayerSession, multiplayerSessionWriteMode, handleId)` API を呼び出してゲーム セッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="90757-239">When the title wants to move members from the lobby session to the game session, each client would use the transfer handle from the lobby session to join the game session by using the `multiplayer_service::write_session_by_handle(multiplayerSession, multiplayerSessionWriteMode, handleId)` API.</span></span>
4. <span data-ttu-id="90757-240">MPSD は、ロビー セッションを検索し、転送ハンドルを使ってゲーム セッションに参加しようとしているユーザーがロビー セッションにも存在することを確認します。</span><span class="sxs-lookup"><span data-stu-id="90757-240">MPSD looks up the lobby session to verify that the members attempting to join the game session by using the transfer handle are also in the lobby session.</span></span>
5. <span data-ttu-id="90757-241">ロビー セッションに存在するメンバーであれば、ゲーム セッションにアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="90757-241">If the members are in the lobby session, they will be able to access the game session.</span></span>

## <a name="join-an-mpsd-session-from-a-title-activation"></a><span data-ttu-id="90757-242">タイトルのアクティベーションからの MPSD セッションへの参加</span><span class="sxs-lookup"><span data-stu-id="90757-242">Join an MPSD session from a title activation</span></span>

<span data-ttu-id="90757-243">ユーザーが Xbox シェル UI を使用してフレンドのアクティビティに参加する、または招待を受け入れることを選択すると、タイトルは、ユーザーが参加を希望するセッションを示すパラメーターを使ってアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="90757-243">When a user chooses to join a friend's activity or accept an invite using Xbox shell UI, the title is activated with parameters that indicate what session the user would like to join.</span></span> <span data-ttu-id="90757-244">タイトルは、このアクティベーションを処理し、対応するセッションにユーザーを追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-244">The title must handle this activation and add the user to the corresponding session.</span></span>

<span data-ttu-id="90757-245">タイトルで実行する手順を次に示します。</span><span class="sxs-lookup"><span data-stu-id="90757-245">Here are the steps the title should follow:</span></span>

1.  <span data-ttu-id="90757-246">**CoreApplicationView.Activated イベント**のイベント ハンドラーを実装します。</span><span class="sxs-lookup"><span data-stu-id="90757-246">Implement an event handler for the **CoreApplicationView.Activated Event**.</span></span> <span data-ttu-id="90757-247">このイベントは、タイトルのアクティベーションを通知します。</span><span class="sxs-lookup"><span data-stu-id="90757-247">This event notifies of activations for the title.</span></span>
2.  <span data-ttu-id="90757-248">ハンドラーが発生したら、**IActivatedEventArgs.Kind プロパティ**を調べます。</span><span class="sxs-lookup"><span data-stu-id="90757-248">When the handler fires, examine the **IActivatedEventArgs.Kind Property**.</span></span> <span data-ttu-id="90757-249">Protocol に設定されている場合は、イベント引数を **ProtocolActivatedEventArgs クラス**にキャストします。</span><span class="sxs-lookup"><span data-stu-id="90757-249">If it is set to Protocol, cast the event arguments to **ProtocolActivatedEventArgs Class**.</span></span>
3.  <span data-ttu-id="90757-250">**ProtocolActivatedEventArgs** オブジェクトを調べます。</span><span class="sxs-lookup"><span data-stu-id="90757-250">Examine the **ProtocolActivatedEventArgs** object.</span></span> <span data-ttu-id="90757-251">**ProtocolActivatedEventArgs.Uri プロパティ**に指定されている URI が inviteHandleAccept (受け入れた招待に対応) または activityHandleJoin (シェル UI 経由での参加に対応) のいずれかに一致する場合は、キーと値のペアを含む通常の URI クエリ文字列としてフォーマットされた、URI のクエリ文字列を解析し、以下のフィールドを抽出します。</span><span class="sxs-lookup"><span data-stu-id="90757-251">If the URI indicated in the **ProtocolActivatedEventArgs.Uri Property** matches either inviteHandleAccept (corresponding to an accepted invite) or activityHandleJoin (corresponding to a join via shell UI), parse the query string of the URI, which is formatted as a normal URI query string with key/value pairs, extracting the following fields:</span></span>
    -   <span data-ttu-id="90757-252">受け入れた招待の場合:</span><span class="sxs-lookup"><span data-stu-id="90757-252">For an accepted invite:</span></span>
        1.  <span data-ttu-id="90757-253">ハンドル</span><span class="sxs-lookup"><span data-stu-id="90757-253">handle</span></span>
        2.  <span data-ttu-id="90757-254">invitedXuid</span><span class="sxs-lookup"><span data-stu-id="90757-254">invitedXuid</span></span>
        3.  <span data-ttu-id="90757-255">senderXuid</span><span class="sxs-lookup"><span data-stu-id="90757-255">senderXuid</span></span>
    -   <span data-ttu-id="90757-256">参加の場合:</span><span class="sxs-lookup"><span data-stu-id="90757-256">For a join:</span></span>
        1.  <span data-ttu-id="90757-257">ハンドル</span><span class="sxs-lookup"><span data-stu-id="90757-257">handle</span></span>
        2.  <span data-ttu-id="90757-258">joinerXuid</span><span class="sxs-lookup"><span data-stu-id="90757-258">joinerXuid</span></span>
        3.  <span data-ttu-id="90757-259">joineeXuid</span><span class="sxs-lookup"><span data-stu-id="90757-259">joineeXuid</span></span>

4.  <span data-ttu-id="90757-260">タイトルのマルチプレイヤー コードを開始します。このコードには、**MultiplayerService.EnableMultiplayerSubscriptions メソッド**の呼び出しが含まれている必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-260">Start the title's multiplayer code, which should include calling the **MultiplayerService.EnableMultiplayerSubscriptions Method**.</span></span>
5.  <span data-ttu-id="90757-261">ローカルの **MultiplayerSession クラス** オブジェクトを、**MultiplayerSession コンストラクター (XboxLiveContext)** を使用して作成します。</span><span class="sxs-lookup"><span data-stu-id="90757-261">Create a local **MultiplayerSession Class** object, using the **MultiplayerSession Constructor (XboxLiveContext)**.</span></span>
6.  <span data-ttu-id="90757-262">**MultiplayerSession.Join メソッド (String, Boolean, Boolean)** を呼び出してセッションに参加します。</span><span class="sxs-lookup"><span data-stu-id="90757-262">Call the **MultiplayerSession.Join Method (String, Boolean, Boolean)** to join the session.</span></span> <span data-ttu-id="90757-263">以下のパラメーターを設定して、参加がアクティブとして設定されるようにします。</span><span class="sxs-lookup"><span data-stu-id="90757-263">Use the following parameter settings so that the join is set as active:</span></span>
    -   <span data-ttu-id="90757-264">*memberCustomConstantsJson* = null</span><span class="sxs-lookup"><span data-stu-id="90757-264">*memberCustomConstantsJson* = null</span></span>
    -   <span data-ttu-id="90757-265">*initializeRequested* = false</span><span class="sxs-lookup"><span data-stu-id="90757-265">*initializeRequested* = false</span></span>
    -   <span data-ttu-id="90757-266">*joinWithActiveStatus* = true</span><span class="sxs-lookup"><span data-stu-id="90757-266">*joinWithActiveStatus* = true</span></span>

7.  <span data-ttu-id="90757-267">**MultiplayerSession.SetSessionChangeSubscription メソッド**を呼び出して、参加後にセッションが変更したときにショルダー タップを受けられるようにします。</span><span class="sxs-lookup"><span data-stu-id="90757-267">Call the **MultiplayerSession.SetSessionChangeSubscription Method** to be shoulder-tapped when the session changes after joining.</span></span>
8.  <span data-ttu-id="90757-268">手順 3 の説明に従って取得したハンドルを使用して、**MultiplayerService.WriteSessionByHandleAsync メソッド**を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="90757-268">Call the **MultiplayerService.WriteSessionByHandleAsync Method**, using the handle acquired as described in step 3.</span></span> <span data-ttu-id="90757-269">ユーザーはセッションのメンバーになっているので、セッション内のデータを使用してゲームに接続できます。</span><span class="sxs-lookup"><span data-stu-id="90757-269">Now the user is a member of the session, and can use data in the session to connect to the game.</span></span>

## <a name="set-the-users-current-activity"></a><span data-ttu-id="90757-270">ユーザーの現在のアクティビティの設定</span><span class="sxs-lookup"><span data-stu-id="90757-270">Set the user's current activity</span></span>

<span data-ttu-id="90757-271">ユーザーの現在のアクティビティは、タイトルの Xbox ダッシュボードのユーザー エクスペリエンスに表示されます。</span><span class="sxs-lookup"><span data-stu-id="90757-271">The user's current activity is displayed in Xbox dashboard user experiences for the title.</span></span> <span data-ttu-id="90757-272">ユーザーのアクティビティは、セッションまたはタイトルのアクティベーションを通じて設定できます。</span><span class="sxs-lookup"><span data-stu-id="90757-272">Activity for a user can be set through a session or through title activation.</span></span> <span data-ttu-id="90757-273">後者の場合、ユーザーはマッチメイキングを通じて、またはゲームを起動してセッションを開始します。</span><span class="sxs-lookup"><span data-stu-id="90757-273">In the latter case, the user enters a session through matchmaking or by starting a game.</span></span>

| <span data-ttu-id="90757-274">注意</span><span class="sxs-lookup"><span data-stu-id="90757-274">Note</span></span>                                                                                                                                                  |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-275">セッションを通じて設定されたアクティビティは、**MultiplayerService.ClearActivityAsync メソッド**の呼び出しで削除できます。</span><span class="sxs-lookup"><span data-stu-id="90757-275">Activity set through a session can be deleted with a call to the **MultiplayerService.ClearActivityAsync Method**.</span></span> |

<span data-ttu-id="90757-276">セッションをユーザーの現在のアクティビティとして設定するには、タイトルは **MultiplayerService.SetActivityAsync メソッド**を呼び出し、セッションの参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="90757-276">To set a session as the user's current activity, the title calls the **MultiplayerService.SetActivityAsync Method**, passing the session reference for the session.</span></span>

<span data-ttu-id="90757-277">タイトルのアクティベーションを通じてユーザーの現在のアクティビティを設定するには、「**方法: タイトルのアクティベーションからの MPSD セッションへの参加**」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="90757-277">To set the user's current activity through title activation, see **How to: Join an MPSD Session from a Title Activation**.</span></span>

## <a name="update-an-mpsd-session"></a><span data-ttu-id="90757-278">MPSD セッションの更新</span><span class="sxs-lookup"><span data-stu-id="90757-278">Update an MPSD session</span></span>

| <span data-ttu-id="90757-279">注意</span><span class="sxs-lookup"><span data-stu-id="90757-279">Note</span></span>                                                                                                                                                 |
|-------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="90757-280">タイトルがマルチプレイヤー API を使用して既存のセッションを更新する場合は、セッションの書き込みを呼び出すまで、ローカル コピーを扱うことになるので注意してください。</span><span class="sxs-lookup"><span data-stu-id="90757-280">When your title updates an existing session using the multiplayer API, remember that it is working with a local copy, until it makes a call to write the session.</span></span> |

<span data-ttu-id="90757-281">既存のセッションを更新するには、タイトルは以下の操作を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-281">To update an existing session, the title must:</span></span>

1.  <span data-ttu-id="90757-282">現在のセッションを必要に応じて変更します (たとえば **MultiplayerSession.Leave メソッド**を呼び出すことで)。</span><span class="sxs-lookup"><span data-stu-id="90757-282">Make changes to the current session as required, for example, by calling the **MultiplayerSession.Leave Method**.</span></span>
2.  <span data-ttu-id="90757-283">すべての変更を加えたら、以下のメソッドのいずれかを使用して、MPSD へローカルの変更内容を書き込みます。</span><span class="sxs-lookup"><span data-stu-id="90757-283">When all changes are made, write the local changes to MPSD, using any of these methods:</span></span>

    -   **<span data-ttu-id="90757-284">MultiplayerService.WriteSessionAsync メソッド</span><span class="sxs-lookup"><span data-stu-id="90757-284">MultiplayerService.WriteSessionAsync Method</span></span>**
    -   <span data-ttu-id="90757-285">**MultiplayerService.WriteSessionByHandleAsync メソッド**</span><span class="sxs-lookup"><span data-stu-id="90757-285">**MultiplayerService.WriteSessionByHandleAsync Method**.</span></span>
    -   **<span data-ttu-id="90757-286">MultiplayerService.TryWriteSessionAsync メソッド</span><span class="sxs-lookup"><span data-stu-id="90757-286">MultiplayerService.TryWriteSessionAsync Method</span></span>**
    -   **<span data-ttu-id="90757-287">MultiplayerService.TryWriteSessionByHandleAsync メソッド</span><span class="sxs-lookup"><span data-stu-id="90757-287">MultiplayerService.TryWriteSessionByHandleAsync Method</span></span>**

    <span data-ttu-id="90757-288">他のタイトルも変更できる共有部分に書き込む場合は、書き込みモードを **SynchronizedUpdate** に設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-288">Set the write mode to **SynchronizedUpdate** if writing to a shared portion that other titles can also modify.</span></span> <span data-ttu-id="90757-289">詳細については、「[セッション更新の同期](multiplayer-session-directory.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-289">See [Synchronization of Session Updates](multiplayer-session-directory.md) for more information.</span></span>

    <span data-ttu-id="90757-290">書き込みメソッドは参加をサーバーに書き込み、最新のセッションを取得して、そのセッションから他のセッション メンバーと本体のセキュア デバイス アドレス (SDA) を検出します。</span><span class="sxs-lookup"><span data-stu-id="90757-290">The write method writes the join to the server and gets the latest session, from which to discover other session members and the secure device addresses (SDAs) of their consoles.</span></span> <span data-ttu-id="90757-291">これらの本体間でネットワーク接続を確立する方法の詳細については、「**Xbox One の Winsock の概要**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-291">For more information about establishing a network connection among these consoles, see **Introduction to Winsock on Xbox One**.</span></span>

3.  <span data-ttu-id="90757-292">最新の既知のセッション状態に基づいて今後の処理を実行できるように、古いローカルのセッション オブジェクトを破棄し、新たに取得したセッション オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="90757-292">Discard the old local session object, and use the newly retrieved session object so that future actions are based on the latest known session state.</span></span>

## <a name="leave-an-mpsd-session"></a><span data-ttu-id="90757-293">MPSD セッションからの退出</span><span class="sxs-lookup"><span data-stu-id="90757-293">Leave an MPSD session</span></span>

<span data-ttu-id="90757-294">ユーザーがセッションから退出できるようにするには、タイトルで次の手順を行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-294">To allow a user to leave a session, the title must do the following.</span></span>

1.  <span data-ttu-id="90757-295">ゲーム セッションの **MultiplayerSession.Leave メソッド**を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="90757-295">Call the **MultiplayerSession.Leave Method** for the game session.</span></span>
2.  <span data-ttu-id="90757-296">「**方法: マルチプレイヤー セッションの更新**」で説明されているように、MPSD でゲーム セッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="90757-296">Update the game session in MPSD, as described in **How to: Update a Multiplayer Session**.</span></span>
3.  <span data-ttu-id="90757-297">必要に応じて、ロビー セッションの **Leave** メソッドを呼び出し、そのセッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="90757-297">If necessary, call **Leave** method for the lobby session, and update that session.</span></span>
4.  <span data-ttu-id="90757-298">ロビー セッションに必要な場合、**RealTimeActivityService.MultiplayerSubscriptionsLost イベント**と **RealTimeActivityService.MultiplayerSessionChanged イベント**の登録を解除して、マルチプレイヤー API をシャット ダウンします。</span><span class="sxs-lookup"><span data-stu-id="90757-298">If necessary for the lobby session, shut down the multiplayer API by unregistering the **RealTimeActivityService.MultiplayerSubscriptionsLost Event** and the **RealTimeActivityService.MultiplayerSessionChanged Event**.</span></span>

<span data-ttu-id="90757-299">次のフロー チャートは、セッションから退出して、シャットダウンする方法を示します。</span><span class="sxs-lookup"><span data-stu-id="90757-299">The following flow chart illustrates how to leave the session and shut down.</span></span>

![](../../images/multiplayer/Multiplayer_2015_Shut_Down.png)

## <a name="fill-open-session-slots-during-matchmaking"></a><span data-ttu-id="90757-300">マッチメイキング中に空きセッション スロットを埋める</span><span class="sxs-lookup"><span data-stu-id="90757-300">Fill open session slots during matchmaking</span></span>

<span data-ttu-id="90757-301">マッチメイキング中にチケット セッションの空きスロットを埋めるには、タイトルで次のような手順に従う必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-301">To fill open slots in a ticket session during matchmaking, the title must follow steps similar to the following:</span></span>

1.  <span data-ttu-id="90757-302">マッチメイキング中に作成されたチケット セッションの最新のセッション状態にアクセスします。</span><span class="sxs-lookup"><span data-stu-id="90757-302">Access the latest session state for the ticket session created during matchmaking.</span></span>
2.  <span data-ttu-id="90757-303">ロビー セッションからゲーム プレイに参加可能なプレイヤーを追加します。</span><span class="sxs-lookup"><span data-stu-id="90757-303">Add available players for game play from the lobby session.</span></span>
3.  <span data-ttu-id="90757-304">チケット セッションがいっぱいになっているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="90757-304">Determine if the ticket session is full.</span></span>
4.  <span data-ttu-id="90757-305">セッションがいっぱいの場合、ゲーム プレイを続行します。</span><span class="sxs-lookup"><span data-stu-id="90757-305">If the session is full, continue game play.</span></span>
5.  <span data-ttu-id="90757-306">セッションがまだいっぱいでない場合は、「**方法: マッチ チケットの作成**」で説明されているようにマッチ チケットを作成します。</span><span class="sxs-lookup"><span data-stu-id="90757-306">If the session is not yet full, create the match ticket as described in **How to: Create a Match Ticket**.</span></span> <span data-ttu-id="90757-307">チケットを作成するには必ず *preserveSession* パラメーターを Always に設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-307">Be sure to create the ticket with the *preserveSession* parameter set to Always.</span></span>
6.  <span data-ttu-id="90757-308">マッチメイキングを続行します。</span><span class="sxs-lookup"><span data-stu-id="90757-308">Continue with matchmaking.</span></span> <span data-ttu-id="90757-309">「[SmartMatch マッチメイキングの使用](using-smartmatch-matchmaking.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="90757-309">See [Using SmartMatch Matchmaking](using-smartmatch-matchmaking.md).</span></span>

<span data-ttu-id="90757-310">次のフロー チャートは、マッチメイキング中に空きセッション スロットを埋める方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="90757-310">The following flow chart illustrates how to fill open session slots during matchmaking.</span></span>

![](../../images/multiplayer/Multiplayer_2015_Fill_Open_Slots.png)

## <a name="create-a-match-ticket"></a><span data-ttu-id="90757-311">マッチ チケットの作成</span><span class="sxs-lookup"><span data-stu-id="90757-311">Create a match ticket</span></span>

<span data-ttu-id="90757-312">マッチ チケットを作成するには、マッチメイキング スカウトは次の処理を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="90757-312">To create a match ticket, the matchmaking scout must:</span></span>

1.  <span data-ttu-id="90757-313">**MatchmakingService.CreateMatchTicketAsync メソッド**を呼び出し、チケット セッションへの参照を渡します。</span><span class="sxs-lookup"><span data-stu-id="90757-313">Call the **MatchmakingService.CreateMatchTicketAsync Method**, passing in a reference to the ticket session.</span></span> <span data-ttu-id="90757-314">このメソッドは、MPSD からチケット セッションを読み取り、セッション内のユーザーのマッチメイキングを開始します。</span><span class="sxs-lookup"><span data-stu-id="90757-314">The method reads the ticket session from MPSD, and starts matchmaking for the users in the session.</span></span> <span data-ttu-id="90757-315">メソッドは内部的に **POST (/serviceconfigs/{scid}/hoppers/{hoppername})** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="90757-315">Internally the method calls the **POST (/serviceconfigs/{scid}/hoppers/{hoppername})**.</span></span>
2.  <span data-ttu-id="90757-316">マッチメイキング サービスがセッションのメンバーを新しいセッションまたは別の既存のセッションにマッチングする場合は、*preserveSession* パラメーターを Never に設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-316">Set the *preserveSession* parameter to Never if the matchmaking service is to match the members of the session into a new session or another existing session.</span></span> <span data-ttu-id="90757-317">タイトルがゲーム プレイを続行するためのチケット セッションとして既存のゲーム セッションを再利用できるようにするには、*preserveSession* パラメーターを Always に設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-317">Set the *preserveSession* parameter to Always to allow the title to reuse an existing game session as a ticket session to continue game play.</span></span> <span data-ttu-id="90757-318">この場合、マッチメイキング サービスは、送信されたセッションを保持し、適合したプレイヤーをそのセッションに追加できるようになります。</span><span class="sxs-lookup"><span data-stu-id="90757-318">The matchmaking service can then ensure that the submitted session is preserved and any matched players are added to that session.</span></span>

3.  <span data-ttu-id="90757-319">**CreateMatchTicketResponse クラス** オブジェクトで返される **CreateMatchTicketResponse.EstimatedWaitTime プロパティ**を使用して、マッチメイキング時間のユーザーの期待を設定します。</span><span class="sxs-lookup"><span data-stu-id="90757-319">Use the **CreateMatchTicketResponse.EstimatedWaitTime Property** returned in the **CreateMatchTicketResponse Class** object to set user expectations of matchmaking time.</span></span>
4.  <span data-ttu-id="90757-320">必要な場合は、応答オブジェクトで返される **CreateMatchTicketResponse.MatchTicketId プロパティ**を使用して、チケットを削除することによって、セッションのマッチメイキングをキャンセルします。</span><span class="sxs-lookup"><span data-stu-id="90757-320">Use the **CreateMatchTicketResponse.MatchTicketId Property** returned in the response object to cancel matchmaking for the session if needed, by deleting the ticket.</span></span> <span data-ttu-id="90757-321">チケットの削除には **MatchmakingService.DeleteMatchTicketAsync メソッド**を使用します。</span><span class="sxs-lookup"><span data-stu-id="90757-321">Ticket deletion uses the **MatchmakingService.DeleteMatchTicketAsync Method**.</span></span>

## <a name="get-match-ticket-status"></a><span data-ttu-id="90757-322">マッチ チケットのステータスの取得</span><span class="sxs-lookup"><span data-stu-id="90757-322">Get match ticket status</span></span>

<span data-ttu-id="90757-323">タイトルがマッチ チケットのステータスを取得するには、次の手順を実行します。</span><span class="sxs-lookup"><span data-stu-id="90757-323">Your title should do the following to retrieve match ticket status:</span></span>

1.  <span data-ttu-id="90757-324">チケット セッションの **MultiplayerSession クラス** オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="90757-324">Obtain the **MultiplayerSession Class** object for the ticket session.</span></span>
2.  <span data-ttu-id="90757-325">**MultiplayerSession.MatchmakingServer プロパティ**を使用して、マッチメイキングに使用される **MatchmakingServer クラス** オブジェクトにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="90757-325">Use the **MultiplayerSession.MatchmakingServer Property** to access the **MatchmakingServer Class** object used in matchmaking.</span></span>
3.  <span data-ttu-id="90757-326">一致するものが見つかった場合、**MatchmakingServer** オブジェクトをチェックして、マッチメイキング プロセスのステータス、セッションの標準的な待機時間、およびターゲット セッションの参照を特定します。</span><span class="sxs-lookup"><span data-stu-id="90757-326">Check the **MatchmakingServer** object to determine the status of the matchmaking process, the typical wait time for the session, and the target session reference, if a match has been found.</span></span>
