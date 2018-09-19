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
ms.openlocfilehash: c8641fc534a9fa4e5fb0f23d091f5d18823b719f
ms.sourcegitcommit: 68fcac3288d5698a13dbcbd57f51b30592f24860
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/19/2018
ms.locfileid: "4056405"
---
# <a name="real-time-activity-rta-best-practices"></a><span data-ttu-id="2045f-104">リアルタイム アクティビティ (RTA) のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="2045f-104">Real Time Activity (RTA) Best Practices</span></span>
<span data-ttu-id="2045f-105">これらのベスト プラクティスにより、タイトルで RTA を最大限に活用できます。</span><span class="sxs-lookup"><span data-stu-id="2045f-105">These best practices will help you make the most out of your title's use of RTA.</span></span>


## <a name="the-basics"></a><span data-ttu-id="2045f-106">基本</span><span class="sxs-lookup"><span data-stu-id="2045f-106">The Basics</span></span>

<span data-ttu-id="2045f-107">RTA は、WebSocket セッションを使用してクライアントとの固定接続を作成します。</span><span class="sxs-lookup"><span data-stu-id="2045f-107">RTA uses WebSocket sessions to create a persistent connection with the client.</span></span> <span data-ttu-id="2045f-108">それにより、サービスは統計情報をデベロッパーに提供します。</span><span class="sxs-lookup"><span data-stu-id="2045f-108">That's how the service will deliver statistics to you.</span></span> <span data-ttu-id="2045f-109">クライアントは認証接続要求を送信する必要があり、RTA は、その要求で提供されたトークンを使用して接続を作成できることを確認し、接続を確立します。</span><span class="sxs-lookup"><span data-stu-id="2045f-109">A client needs to send an authenticated connection request, and RTA will use the token provided on the request to verify the connection can be made and then establish it.</span></span>

<span data-ttu-id="2045f-110">接続が確立されると、アプリケーションは特定の統計情報のサブスクライブを要求できます。</span><span class="sxs-lookup"><span data-stu-id="2045f-110">Once the connection has been established, your app can make requests to subscribe to particular statistics.</span></span> <span data-ttu-id="2045f-111">サブスクリプションが成功すると、RTA は、応答のペイロードとして、現在の値といくつかの追加のメタデータ (統計情報の型など) を返します。</span><span class="sxs-lookup"><span data-stu-id="2045f-111">On a successful subscription, RTA will return the current value and some additional metadata, like type of statistic, as part of the response payload.</span></span> <span data-ttu-id="2045f-112">その後、RTA は、クライアントのサブスクライブ中にその統計情報に更新が発生すれば、その更新情報を送信します。</span><span class="sxs-lookup"><span data-stu-id="2045f-112">Then, RTA will forward any updates that happen to the statistic while the client is subscribed.</span></span>

<span data-ttu-id="2045f-113">タイトルがリアルタイムでの統計情報の更新を必要としない場合は、その統計情報に対するサブスクリプションを終了する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-113">When your title doesn't require real-time updates on a statistic, it should terminate its subscription to that statistic.</span></span>


## <a name="handling-disconnects"></a><span data-ttu-id="2045f-114">切断の処理</span><span class="sxs-lookup"><span data-stu-id="2045f-114">Handling Disconnects</span></span>

<span data-ttu-id="2045f-115">タイトルは、ユーザーの認証トークンが期限切れになるとサービスによってセッションが終了されることを認識しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-115">Titles should be aware that when the authentication token for the user expires, their session will be terminated by the service.</span></span> <span data-ttu-id="2045f-116">タイトルは、そのようなイベントの発生を検出し、再接続して、それまでサブスクライブしていたすべての統計情報を再度サブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-116">The title needs to be capable of detecting when such event happens, reconnect and re-subscribe to all the statistics it was previously subscribed to.</span></span>

<span data-ttu-id="2045f-117">クライアントは、ユーザーの ISP に問題がある場合、またはタイトルのプロセスが一時停止された場合にも切断されることがあります。</span><span class="sxs-lookup"><span data-stu-id="2045f-117">A client could also get disconnected due to a user's ISP having issues or when the process for the title is suspended.</span></span> <span data-ttu-id="2045f-118">この切断が発生した場合は、クライアントに知らせるために WebSocket イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="2045f-118">When this happens, a WebSocket event is raised to let the client know.</span></span> <span data-ttu-id="2045f-119">通常は、サービスから切断を処理できるようにすることが最良の方法です。</span><span class="sxs-lookup"><span data-stu-id="2045f-119">In general, it is best practice to be able to handle disconnects from the service.</span></span>


## <a name="managing-subscriptions"></a><span data-ttu-id="2045f-120">サブスクリプションの管理</span><span class="sxs-lookup"><span data-stu-id="2045f-120">Managing Subscriptions</span></span>

<span data-ttu-id="2045f-121">トークンが期限切れになったときのサブスクリプションの管理に関して、タイトルは、どのサブスクリプションが作成されたかを常に追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-121">In relation to managing subscriptions when a token expires, your title should track at all times which subscriptions have been made.</span></span> <span data-ttu-id="2045f-122">サブスクリプションが成功すると、RTA は、サブスクライブされた各統計情報の一意の識別子を返します。</span><span class="sxs-lookup"><span data-stu-id="2045f-122">Upon successfully subscribing, RTA returns a unique identifier for each subscribed statistic.</span></span> <span data-ttu-id="2045f-123">その統計情報に対するその後のすべての更新では、統計情報の名前ではなくこの識別子が使用されます。</span><span class="sxs-lookup"><span data-stu-id="2045f-123">In all future updates to that statistic, the identifier will be used instead of the name of the statistic.</span></span> <span data-ttu-id="2045f-124">これは、帯域幅を節約するためです。</span><span class="sxs-lookup"><span data-stu-id="2045f-124">This is done to save bandwidth.</span></span> <span data-ttu-id="2045f-125">クライアントは、統計情報と RTA のサブスクリプション ID の自身のマッピングを維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-125">Clients are responsible for maintaining their own mapping of statistics to RTA subscription IDs.</span></span>


## <a name="unsubscribing"></a><span data-ttu-id="2045f-126">サブスクライブ解除</span><span class="sxs-lookup"><span data-stu-id="2045f-126">Unsubscribing</span></span>

<span data-ttu-id="2045f-127">使用されていないサブスクリプションを保持することはお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="2045f-127">Having unused subscriptions is not recommended.</span></span> <span data-ttu-id="2045f-128">サービスでは、ユーザーがタイトルごとに一度に保持できるサブスクリプション数に制限があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-128">The service limits the number of subscriptions a user can have per title at a given time.</span></span> <span data-ttu-id="2045f-129">何から何までサブスクライブしていると、その制限に達する可能性があり、そのために一部の重要な統計情報をサブスクライブできなくなる可能性があります </span><span class="sxs-lookup"><span data-stu-id="2045f-129">If you are subscribing to everything and anything, you may hit that limit, and this may prevent subscription to some important statistics.</span></span> <span data-ttu-id="2045f-130">(サブスクリプションの制限の詳細については、この後の「**調整**」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="2045f-130">(For more information about subscription limits, see **Throttles**, later in this topic.)</span></span>

<span data-ttu-id="2045f-131">たとえば、タイトルでは特定のシーンに対するサブスクリプションのみが必要であるとします。</span><span class="sxs-lookup"><span data-stu-id="2045f-131">For example, your title might only need a subscription to a certain scene.</span></span> <span data-ttu-id="2045f-132">ユーザーがそのシーンに入ったときに、タイトルはサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-132">When the user enters that scene, your title should subscribe.</span></span> <span data-ttu-id="2045f-133">ユーザーがそのシーンを離れたときには、それらの統計情報のサブスクライブを解除する必要があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-133">When the user leaves that scene, those statistics should be unsubscribed.</span></span> <span data-ttu-id="2045f-134">また、サブスクリプションを一切必要としない場合は unsubscribe-all メッセージを使用できます。</span><span class="sxs-lookup"><span data-stu-id="2045f-134">Similarly, there is an unsubscribe-all message that can be used if no subscriptions are needed.</span></span>

<span data-ttu-id="2045f-135">サブスクライブの解除後、その統計情報のサブスクリプション ID は使用されなくなります。</span><span class="sxs-lookup"><span data-stu-id="2045f-135">After unsubscribing, the subscription identifier for that statistic will no longer be used.</span></span>


## <a name="awareness-of-latent-items-in-the-queue"></a><span data-ttu-id="2045f-136">キュー内の潜在項目について</span><span class="sxs-lookup"><span data-stu-id="2045f-136">Awareness of Latent Items in the Queue</span></span>

<span data-ttu-id="2045f-137">統計情報のサブスクライブ解除時に、その統計情報の更新があるにもかかわらずそれがクライアントにまだ届いていない場合があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-137">When unsubscribing from a statistic, it's possible that there is an update for the statistic still in the process of reaching your client.</span></span> <span data-ttu-id="2045f-138">そのため、タイトルが統計情報のサブスクライブを解除しても、その統計情報に関する 1 ～ 2 個の更新をまだ受け取る可能性があることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="2045f-138">So, even if your title has just unsubscribed from a statistic, be aware that it may still get an update or two related to that statistic.</span></span>

<span data-ttu-id="2045f-139">サブスクリプション ID を認識できない場合は、その統計情報の更新を無視することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2045f-139">The recommendation is to ignore the updates for statistics when the subscription identifier is not recognized.</span></span>


## <a name="ignore-messages-you-do-not-understand"></a><span data-ttu-id="2045f-140">理解できないメッセージは無視する</span><span class="sxs-lookup"><span data-stu-id="2045f-140">Ignore Messages You do not Understand</span></span>

<span data-ttu-id="2045f-141">メッセージ プロトコルは更新される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-141">It's possible that the message protocol will get updated.</span></span> <span data-ttu-id="2045f-142">アプリケーションが新しいメッセージに縛られないようにするために、タイトルでは、不明な種類のメッセージはそのまま破棄することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="2045f-142">To keep your app agnostic of any new messages, we recommend that your title simply discard unknown message types.</span></span>


## <a name="throttles"></a><span data-ttu-id="2045f-143">調整</span><span class="sxs-lookup"><span data-stu-id="2045f-143">Throttles</span></span>

<span data-ttu-id="2045f-144">RTA はサービスに対して一定の調整を行います。</span><span class="sxs-lookup"><span data-stu-id="2045f-144">RTA enforces certain throttles on the service:</span></span>

-   <span data-ttu-id="2045f-145">UserStats: 1000</span><span class="sxs-lookup"><span data-stu-id="2045f-145">UserStats: 1000</span></span>
-   <span data-ttu-id="2045f-146">Presence: 2500</span><span class="sxs-lookup"><span data-stu-id="2045f-146">Presence: 2500</span></span>

<span data-ttu-id="2045f-147">調整の制限に達すると、クライアントはサブスクライブ/サブスクライブ解除呼び出しの一部としてエラーを受け取るか、または切断されます。</span><span class="sxs-lookup"><span data-stu-id="2045f-147">If a client hits the throttling limit it will either receive an error as part of a subscribe/unsubscribe call, or it will be disconnected.</span></span> <span data-ttu-id="2045f-148">どちらの場合も、エラー メッセージまたは切断メッセージと共に、到達した調整の制限に関する詳細情報がクライアントに提供されます。</span><span class="sxs-lookup"><span data-stu-id="2045f-148">In either case, more information about the throttling limitation that was hit will be available to the client along with the error message or disconnect message.</span></span>

<span data-ttu-id="2045f-149">タイトルの開発時には、これらの概念を心に留めておいてください。</span><span class="sxs-lookup"><span data-stu-id="2045f-149">When developing your title, keep these concepts in mind.</span></span> <span data-ttu-id="2045f-150">何か極端なことをしようとすると、サービスが呼び出しを制限する可能性があるため、アプリケーションのエクスペリエンスが低下する場合があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-150">If you are doing something extreme, you may have a degraded app experience because the service could be throttling your calls.</span></span> <span data-ttu-id="2045f-151">現在、サービスではアプリケーションのインスタンスあたり、統計情報に対する 1000 個のサブスクリプションが認められています。</span><span class="sxs-lookup"><span data-stu-id="2045f-151">Right now, the service allows 1000 subscriptions to statistics per instance of an application.</span></span> <span data-ttu-id="2045f-152">それに加えて、アプリケーションのインスタンスでは、プレゼンスの更新のためにユーザーのユーザー リスト全体をサブスクライブすることもできます。</span><span class="sxs-lookup"><span data-stu-id="2045f-152">In addition to that, an instance of an application can also subscribe to a user's entire people list length for presence updates.</span></span> <span data-ttu-id="2045f-153">この数は調整中であり、今後のリリースで変更される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="2045f-153">This number is being tuned, so it may change in future releases.</span></span>
