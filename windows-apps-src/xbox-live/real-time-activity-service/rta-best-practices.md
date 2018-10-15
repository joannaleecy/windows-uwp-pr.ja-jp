---
title: RTA のベスト プラクティス
author: KevinAsgari
description: Xbox Live リアルタイム アクティビティ サービスを使うときのベスト プラクティスについて説明します。
ms.assetid: 543b78e3-d06b-4969-95db-2cb996a8bbd3
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リアルタイム アクティビティ
ms.localizationpriority: medium
ms.openlocfilehash: a80d25ee14ada799bce5d9e341869522e600e6a5
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4613600"
---
# <a name="real-time-activity-rta-best-practices"></a><span data-ttu-id="f2b61-104">リアルタイム アクティビティ (RTA) のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="f2b61-104">Real Time Activity (RTA) Best Practices</span></span>
<span data-ttu-id="f2b61-105">これらのベスト プラクティスにより、タイトルで RTA を最大限に活用できます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-105">These best practices will help you make the most out of your title's use of RTA.</span></span>


## <a name="the-basics"></a><span data-ttu-id="f2b61-106">基本</span><span class="sxs-lookup"><span data-stu-id="f2b61-106">The Basics</span></span>

<span data-ttu-id="f2b61-107">RTA は、WebSocket セッションを使用してクライアントとの固定接続を作成します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-107">RTA uses WebSocket sessions to create a persistent connection with the client.</span></span> <span data-ttu-id="f2b61-108">それにより、サービスは統計情報をデベロッパーに提供します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-108">That's how the service will deliver statistics to you.</span></span> <span data-ttu-id="f2b61-109">クライアントは認証接続要求を送信する必要があり、RTA は、その要求で提供されたトークンを使用して接続を作成できることを確認し、接続を確立します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-109">A client needs to send an authenticated connection request, and RTA will use the token provided on the request to verify the connection can be made and then establish it.</span></span>

<span data-ttu-id="f2b61-110">接続が確立されると、アプリケーションは特定の統計情報のサブスクライブを要求できます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-110">Once the connection has been established, your app can make requests to subscribe to particular statistics.</span></span> <span data-ttu-id="f2b61-111">サブスクリプションが成功すると、RTA は、応答のペイロードとして、現在の値といくつかの追加のメタデータ (統計情報の型など) を返します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-111">On a successful subscription, RTA will return the current value and some additional metadata, like type of statistic, as part of the response payload.</span></span> <span data-ttu-id="f2b61-112">その後、RTA は、クライアントのサブスクライブ中にその統計情報に更新が発生すれば、その更新情報を送信します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-112">Then, RTA will forward any updates that happen to the statistic while the client is subscribed.</span></span>

<span data-ttu-id="f2b61-113">タイトルがリアルタイムでの統計情報の更新を必要としない場合は、その統計情報に対するサブスクリプションを終了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-113">When your title doesn't require real-time updates on a statistic, it should terminate its subscription to that statistic.</span></span>


## <a name="handling-disconnects"></a><span data-ttu-id="f2b61-114">切断の処理</span><span class="sxs-lookup"><span data-stu-id="f2b61-114">Handling Disconnects</span></span>

<span data-ttu-id="f2b61-115">タイトルは、ユーザーの認証トークンが期限切れになるとサービスによってセッションが終了されることを認識しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-115">Titles should be aware that when the authentication token for the user expires, their session will be terminated by the service.</span></span> <span data-ttu-id="f2b61-116">タイトルは、そのようなイベントの発生を検出し、再接続して、それまでサブスクライブしていたすべての統計情報を再度サブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-116">The title needs to be capable of detecting when such event happens, reconnect and re-subscribe to all the statistics it was previously subscribed to.</span></span>

<span data-ttu-id="f2b61-117">RTA の接続は、設計上、再接続するクライアントを強制的に 2 時間後閉じられます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-117">RTA connections are closed after two hours by design, which will force the client to reconnect.</span></span> <span data-ttu-id="f2b61-118">これは、メッセージの帯域幅に保存する接続の認証トークンがキャッシュされるためです。</span><span class="sxs-lookup"><span data-stu-id="f2b61-118">This is done because the auth token for the connection is cached to save on message bandwidth.</span></span> <span data-ttu-id="f2b61-119">最終的にトークンの期限が切れます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-119">Eventually that token will expire.</span></span> <span data-ttu-id="f2b61-120">接続を閉じると、強制的に再接続してクライアントが強制的に認証トークンを更新します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-120">By closing the connection and forcing the client to reconnect the client is forced to refresh the auth token.</span></span>

<span data-ttu-id="f2b61-121">クライアントは、ユーザーの ISP に問題がある場合、またはタイトルのプロセスが一時停止された場合にも切断されることがあります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-121">A client could also get disconnected due to a user's ISP having issues or when the process for the title is suspended.</span></span> <span data-ttu-id="f2b61-122">この切断が発生した場合は、クライアントに知らせるために WebSocket イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-122">When this happens, a WebSocket event is raised to let the client know.</span></span> <span data-ttu-id="f2b61-123">通常は、サービスから切断を処理できるようにすることが最良の方法です。</span><span class="sxs-lookup"><span data-stu-id="f2b61-123">In general, it is best practice to be able to handle disconnects from the service.</span></span>

> [!WARNING]
> <span data-ttu-id="f2b61-124">クライアントがマルチプレイヤー セッションは、RTA を使用して、30 秒間の切断された場合は、[マルチプレイヤー セッション Directory(MPSD)](../multiplayer/multiplayer-appendix/multiplayer-session-directory.md) RTA セッションが閉じられ、セッションからユーザーが開始を検出します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-124">If a client uses RTA for multiplayer sessions, and is disconnected for thirty seconds, the [Multiplayer Session Directory(MPSD)](../multiplayer/multiplayer-appendix/multiplayer-session-directory.md) detects that the RTA session is closed, and kicks the user out of the session.</span></span> <span data-ttu-id="f2b61-125">RTA クライアントが接続が閉じられたときに検出、再接続を開始し、MPSD セッションを終了する前にサブスクライブすることです。</span><span class="sxs-lookup"><span data-stu-id="f2b61-125">It's up to the RTA client to detect when the connection is closed and initiate a reconnect and resubscribe before the MPSD ends the session.</span></span>

## <a name="managing-subscriptions"></a><span data-ttu-id="f2b61-126">サブスクリプションの管理</span><span class="sxs-lookup"><span data-stu-id="f2b61-126">Managing Subscriptions</span></span>

<span data-ttu-id="f2b61-127">トークンが期限切れになったときのサブスクリプションの管理に関して、タイトルは、どのサブスクリプションが作成されたかを常に追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-127">In relation to managing subscriptions when a token expires, your title should track at all times which subscriptions have been made.</span></span> <span data-ttu-id="f2b61-128">サブスクリプションが成功すると、RTA は、サブスクライブされた各統計情報の一意の識別子を返します。</span><span class="sxs-lookup"><span data-stu-id="f2b61-128">Upon successfully subscribing, RTA returns a unique identifier for each subscribed statistic.</span></span> <span data-ttu-id="f2b61-129">その統計情報に対するその後のすべての更新では、統計情報の名前ではなくこの識別子が使用されます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-129">In all future updates to that statistic, the identifier will be used instead of the name of the statistic.</span></span> <span data-ttu-id="f2b61-130">これは、帯域幅を節約するためです。</span><span class="sxs-lookup"><span data-stu-id="f2b61-130">This is done to save bandwidth.</span></span> <span data-ttu-id="f2b61-131">クライアントは、統計情報と RTA のサブスクリプション ID の自身のマッピングを維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-131">Clients are responsible for maintaining their own mapping of statistics to RTA subscription IDs.</span></span>


## <a name="unsubscribing"></a><span data-ttu-id="f2b61-132">サブスクライブ解除</span><span class="sxs-lookup"><span data-stu-id="f2b61-132">Unsubscribing</span></span>

<span data-ttu-id="f2b61-133">使用されていないサブスクリプションを保持することはお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="f2b61-133">Having unused subscriptions is not recommended.</span></span> <span data-ttu-id="f2b61-134">サービスでは、ユーザーがタイトルごとに一度に保持できるサブスクリプション数に制限があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-134">The service limits the number of subscriptions a user can have per title at a given time.</span></span> <span data-ttu-id="f2b61-135">何から何までサブスクライブしていると、その制限に達する可能性があり、そのために一部の重要な統計情報をサブスクライブできなくなる可能性があります </span><span class="sxs-lookup"><span data-stu-id="f2b61-135">If you are subscribing to everything and anything, you may hit that limit, and this may prevent subscription to some important statistics.</span></span> <span data-ttu-id="f2b61-136">(サブスクリプションの制限の詳細については、この後の「**調整**」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="f2b61-136">(For more information about subscription limits, see **Throttles**, later in this topic.)</span></span>

<span data-ttu-id="f2b61-137">たとえば、タイトルでは特定のシーンに対するサブスクリプションのみが必要であるとします。</span><span class="sxs-lookup"><span data-stu-id="f2b61-137">For example, your title might only need a subscription to a certain scene.</span></span> <span data-ttu-id="f2b61-138">ユーザーがそのシーンに入ったときに、タイトルはサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-138">When the user enters that scene, your title should subscribe.</span></span> <span data-ttu-id="f2b61-139">ユーザーがそのシーンを離れたときには、それらの統計情報のサブスクライブを解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-139">When the user leaves that scene, those statistics should be unsubscribed.</span></span> <span data-ttu-id="f2b61-140">また、サブスクリプションを一切必要としない場合は unsubscribe-all メッセージを使用できます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-140">Similarly, there is an unsubscribe-all message that can be used if no subscriptions are needed.</span></span>

<span data-ttu-id="f2b61-141">サブスクライブの解除後、その統計情報のサブスクリプション ID は使用されなくなります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-141">After unsubscribing, the subscription identifier for that statistic will no longer be used.</span></span>


## <a name="awareness-of-latent-items-in-the-queue"></a><span data-ttu-id="f2b61-142">キュー内の潜在項目について</span><span class="sxs-lookup"><span data-stu-id="f2b61-142">Awareness of Latent Items in the Queue</span></span>

<span data-ttu-id="f2b61-143">統計情報のサブスクライブ解除時に、その統計情報の更新があるにもかかわらずそれがクライアントにまだ届いていない場合があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-143">When unsubscribing from a statistic, it's possible that there is an update for the statistic still in the process of reaching your client.</span></span> <span data-ttu-id="f2b61-144">そのため、タイトルが統計情報のサブスクライブを解除しても、その統計情報に関する 1 ～ 2 個の更新をまだ受け取る可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="f2b61-144">So, even if your title has just unsubscribed from a statistic, be aware that it may still get an update or two related to that statistic.</span></span>

<span data-ttu-id="f2b61-145">サブスクリプション ID を認識できない場合は、その統計情報の更新を無視することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f2b61-145">The recommendation is to ignore the updates for statistics when the subscription identifier is not recognized.</span></span>


## <a name="ignore-messages-you-do-not-understand"></a><span data-ttu-id="f2b61-146">理解できないメッセージは無視する</span><span class="sxs-lookup"><span data-stu-id="f2b61-146">Ignore Messages You do not Understand</span></span>

<span data-ttu-id="f2b61-147">メッセージ プロトコルは更新される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-147">It's possible that the message protocol will get updated.</span></span> <span data-ttu-id="f2b61-148">アプリケーションが新しいメッセージに縛られないようにするために、タイトルでは、不明な種類のメッセージはそのまま破棄することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f2b61-148">To keep your app agnostic of any new messages, we recommend that your title simply discard unknown message types.</span></span>


## <a name="throttles"></a><span data-ttu-id="f2b61-149">調整</span><span class="sxs-lookup"><span data-stu-id="f2b61-149">Throttles</span></span>

<span data-ttu-id="f2b61-150">RTA はサービスに対して一定の調整を行います。</span><span class="sxs-lookup"><span data-stu-id="f2b61-150">RTA enforces certain throttles on the service:</span></span>

-   <span data-ttu-id="f2b61-151">UserStats: 1000</span><span class="sxs-lookup"><span data-stu-id="f2b61-151">UserStats: 1000</span></span>
-   <span data-ttu-id="f2b61-152">Presence: 2500</span><span class="sxs-lookup"><span data-stu-id="f2b61-152">Presence: 2500</span></span>

<span data-ttu-id="f2b61-153">調整の制限に達すると、クライアントはサブスクライブ/サブスクライブ解除呼び出しの一部としてエラーを受け取るか、または切断されます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-153">If a client hits the throttling limit it will either receive an error as part of a subscribe/unsubscribe call, or it will be disconnected.</span></span> <span data-ttu-id="f2b61-154">どちらの場合も、エラー メッセージまたは切断メッセージと共に、到達した調整の制限に関する詳細情報がクライアントに提供されます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-154">In either case, more information about the throttling limitation that was hit will be available to the client along with the error message or disconnect message.</span></span>

<span data-ttu-id="f2b61-155">タイトルの開発時には、これらの概念を心に留めておいてください。</span><span class="sxs-lookup"><span data-stu-id="f2b61-155">When developing your title, keep these concepts in mind.</span></span> <span data-ttu-id="f2b61-156">何か極端なことをしようとすると、サービスが呼び出しを制限する可能性があるため、アプリケーションのエクスペリエンスが低下する場合があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-156">If you are doing something extreme, you may have a degraded app experience because the service could be throttling your calls.</span></span> <span data-ttu-id="f2b61-157">現在、サービスではアプリケーションのインスタンスあたり、統計情報に対する 1000 個のサブスクリプションが認められています。</span><span class="sxs-lookup"><span data-stu-id="f2b61-157">Right now, the service allows 1000 subscriptions to statistics per instance of an application.</span></span> <span data-ttu-id="f2b61-158">それに加えて、アプリケーションのインスタンスでは、プレゼンスの更新のためにユーザーのユーザー リスト全体をサブスクライブすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f2b61-158">In addition to that, an instance of an application can also subscribe to a user's entire people list length for presence updates.</span></span> <span data-ttu-id="f2b61-159">この数は調整中であり、今後のリリースで変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="f2b61-159">This number is being tuned, so it may change in future releases.</span></span>
