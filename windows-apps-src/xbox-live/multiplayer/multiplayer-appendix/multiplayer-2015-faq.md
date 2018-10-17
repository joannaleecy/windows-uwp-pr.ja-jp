---
title: マルチプレイヤー 2015 の FAQ とトラブルシューティング
author: KevinAsgari
description: Xbox Live マルチプレイヤー 2015 ついてよく寄せられる質問とトラブルシューティングを示します。
ms.assetid: 75823f10-b342-4e20-b885-e5ad4392bc3d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー
ms.localizationpriority: medium
ms.openlocfilehash: 2c319db5c93f6bc06f551fbb3b76f975fc3de87a
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4742717"
---
# <a name="multiplayer-2015-faq-and-troubleshooting"></a><span data-ttu-id="ee8cd-104">マルチプレイヤー 2015 の FAQ とトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="ee8cd-104">Multiplayer 2015 FAQ and troubleshooting</span></span>

-   <span data-ttu-id="ee8cd-105">新しいタイトルを開発しています。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-105">I am developing a new title.</span></span> <span data-ttu-id="ee8cd-106">どのマルチプレイヤー API 要素を使用する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-106">Which multiplayer API elements should I use?</span></span>
-   <span data-ttu-id="ee8cd-107">新しいマルチプレイヤー API にサービスからアクセスするにはどうすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-107">How can I access the new multiplayer API from a service?</span></span>
-   <span data-ttu-id="ee8cd-108">タイトルで複数のセッションの変更をサブスクライブできますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-108">Can my title subscribe to changes for more than one session?</span></span>
-   <span data-ttu-id="ee8cd-109">ユーザーがネットワーク接続を失ったか、本体の電源をオフにした場合、そのユーザーはすぐに削除されますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-109">Will a user be removed immediately if he/she loses a network connection or turns off the console?</span></span>
-   <span data-ttu-id="ee8cd-110">使用する SCID、セッション テンプレート、サンドボックスを調べる方法を教えてください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-110">How do I find out what SCID, session template, and sandbox to use?</span></span>
-   <span data-ttu-id="ee8cd-111">自分のタイトル用のものと比較できる要求本文の例はありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-111">Is there an example of a request body that I can compare to the one for my title?</span></span>
-   <span data-ttu-id="ee8cd-112">MPSD を呼び出すと HTTP/403 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-112">I am getting an HTTP/403 code when calling MPSD.</span></span>
-   <span data-ttu-id="ee8cd-113">MPSD を呼び出すと HTTP/404 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-113">I am getting an HTTP/404 code when calling MPSD.</span></span>
-   <span data-ttu-id="ee8cd-114">**MultiplayerService.WriteSessionByHandleAsync** または **MultiplayerService.GetCurrentSessionByHandleAsync** を呼び出すと HTTP/404 コードを受け取るのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-114">Why am I getting an HTTP/404 code when calling **MultiplayerService.WriteSessionByHandleAsync** or **MultiplayerService.GetCurrentSessionByHandleAsync**?</span></span>
-   <span data-ttu-id="ee8cd-115">MPSD を呼び出すと HTTP/412 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-115">I am getting an HTTP/412 code when calling MPSD.</span></span>
-   <span data-ttu-id="ee8cd-116">MPSD を呼び出すと HTTP/400、405、409、503 などのコードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-116">I am getting an HTTP/400, 405, 409, 503, etc. code when calling MPSD.</span></span>
-   <span data-ttu-id="ee8cd-117">タイトルのセッション テンプレートでは何を変更できますか、または何を変更する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-117">What can or should I change in the session templates for my title?</span></span>
-   <span data-ttu-id="ee8cd-118">セッションが初期化されていないことを示すエラーが示されます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-118">I'm getting an error that is saying my session isn't initialized.</span></span>
-   <span data-ttu-id="ee8cd-119">セッションが作成されず、HTTP/204 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-119">My session is not being created and I'm getting an HTTP/204 code.</span></span>
-   <span data-ttu-id="ee8cd-120">どのようなときに MPSD をポーリングする必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-120">When should I poll MPSD?</span></span>
-   <span data-ttu-id="ee8cd-121">セッションに予約または招待されたプレイヤーがセッションに参加しないとどうなりますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-121">What happens if a player who was reserved or invited to the session does not join it?</span></span>
-   <span data-ttu-id="ee8cd-122">作成したセッションがマッチメイキングによって見つからないのはどうしてでしょうか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-122">Why would a created session not be found by matchmaking?</span></span>
-   <span data-ttu-id="ee8cd-123">2015 マルチプレイヤーでのパーティーの適切な使用法と 2014 マルチプレイヤーでの使用法の主な違いは何ですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-123">What is the key difference between the way parties are properly used by 2015 Multiplayer and the way they were used in 2014 Multiplayer?</span></span>
-   <span data-ttu-id="ee8cd-124">ゲーム セッションに空きプレイヤー スロットがあり、ゲーム セッションが途中参加をサポートしている場合、開始したセッションをユーザーが見つけられないのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-124">If a game session has open player slots and supports join in progress, why would users not be able to find the session once it has started?</span></span>
-   <span data-ttu-id="ee8cd-125">ゲーム セッションが開いている場合、ゲームに参加したばかりのユーザーは、予約を待つ必要はなく、単にセッションに参加してプレイを開始できますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-125">If a game session is open, can a user who has just joined a game simply join the session and start playing without having to wait for the reservation?</span></span>
-   <span data-ttu-id="ee8cd-126">タイトルで大規模なゲーム セッションをプレイしているときに、ゲーム招待トーストを受け取らないセッション メンバーがいるのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-126">When large game sessions are playing in my title, why aren't all session members seeing the game invite toast?</span></span>
-   <span data-ttu-id="ee8cd-127">ゲームの動作に一貫性がなく、ゲーム パーティー機能を参照するプロトコルのアクティベーション情報を受け取りました。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-127">I am seeing inconsistent game behavior and have received protocol activation information referencing game party features.</span></span>
-   <span data-ttu-id="ee8cd-128">V107 セッション テンプレートを構成したのに、v105 セッション ドキュメントの構文がトレースで表示されるのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-128">Why am I seeing the syntax for v105 session documents in my traces although I have configured a v107 session template?</span></span>


### <a name="i-am-developing-a-new-title-which-multiplayer-api-elements-should-i-use"></a><span data-ttu-id="ee8cd-129">新しいタイトルを開発しています。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-129">I am developing a new title.</span></span> <span data-ttu-id="ee8cd-130">どのマルチプレイヤー API 要素を使用する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-130">Which multiplayer API elements should I use?</span></span>

<span data-ttu-id="ee8cd-131">2014 マルチプレイヤー機能は、引き続き既存のタイトルに適用されますが、関連する API 要素は非推奨となる可能性が高いです。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-131">2014 Multiplayer functionality will continue to apply for existing titles, but the associated API elements most likely be deprecated.</span></span> <span data-ttu-id="ee8cd-132">2015 年のリリースに向けてクライアントを準備するときは、2015 マルチプレイヤーの使用を強くお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-132">We strongly recommend the use of 2015 Multiplayer when preparing your clients for release in 2015.</span></span>


### <a name="how-can-i-access-the-new-multiplayer-api-from-a-service"></a><span data-ttu-id="ee8cd-133">新しいマルチプレイヤー API にサービスからアクセスするにはどうすればよいですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-133">How can I access the new multiplayer API from a service?</span></span>

<span data-ttu-id="ee8cd-134">「[MPSD の呼び出し](multiplayer-session-directory.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-134">See [Calling MPSD](multiplayer-session-directory.md).</span></span>


### <a name="can-my-title-subscribe-to-changes-for-more-than-one-session"></a><span data-ttu-id="ee8cd-135">タイトルで複数のセッションの変更をサブスクライブできますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-135">Can my title subscribe to changes for more than one session?</span></span>

<span data-ttu-id="ee8cd-136">はい、タイトルは 1 接続あたり最大 10 個のセッションに関する変更の受信をサブスクライブできます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-136">Yes, a title can subscribe to receive changes on up to 10 sessions per connection.</span></span>


### <a name="will-a-user-be-removed-immediately-if-heshe-loses-a-network-connection-or-turns-off-the-console"></a><span data-ttu-id="ee8cd-137">ユーザーがネットワーク接続を失ったか、本体の電源をオフにした場合、そのユーザーはすぐに削除されますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-137">Will a user be removed immediately if he/she loses a network connection or turns off the console?</span></span>

<span data-ttu-id="ee8cd-138">Web ソケット接続では、MPSD はクライアントの切断を迅速に検出し、そのクライアントを非アクティブに設定することができます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-138">The web socket connection allows MPSD to rapidly detect client disconnection and set the client to inactive.</span></span> <span data-ttu-id="ee8cd-139">セッション メンバーは、非アクティブ削除タイムアウトが経過するとすぐに削除されます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-139">Session members are removed as soon as the inactive removal timeout expires.</span></span> <span data-ttu-id="ee8cd-140">詳細については、「[セッション タイムアウト](mpsd-session-details.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-140">For more information, see [Session Timeouts](mpsd-session-details.md).</span></span>


### <a name="how-do-i-find-out-what-scid-session-template-and-sandbox-to-use"></a><span data-ttu-id="ee8cd-141">使用する SCID、セッション テンプレート、サンドボックスを調べる方法を教えてください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-141">How do I find out what SCID, session template, and sandbox to use?</span></span>

<span data-ttu-id="ee8cd-142">タイトルの最初の登録にかかわっていなかった場合は、この情報が作成されたときに、この情報にアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-142">If you were not involved in the initial registration of your title, when this information was created, you do not have access to this information.</span></span> <span data-ttu-id="ee8cd-143">この情報を入手するには、担当のデベロッパー アカウント マネージャーにお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-143">Contact your Developer Account Manager, who can get this data for you.</span></span>


### <a name="is-there-an-example-of-a-request-body-that-i-can-compare-to-the-one-for-my-title"></a><span data-ttu-id="ee8cd-144">自分のタイトル用のものと比較できる要求本文の例はありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-144">Is there an example of a request body that I can compare to the one for my title?</span></span>

<span data-ttu-id="ee8cd-145">「**MultiplayerSessionRequest (JSON)**」の要求の構造を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-145">See the request structure in **MultiplayerSessionRequest (JSON)**</span></span>


### <a name="i-am-getting-an-http403-code-when-calling-mpsd"></a><span data-ttu-id="ee8cd-146">MPSD を呼び出すと HTTP/403 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-146">I am getting an HTTP/403 code when calling MPSD.</span></span>

<span data-ttu-id="ee8cd-147">通常、これはアクセス許可またはスコープの問題です。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-147">This is usually a permissions or scope issue.</span></span> <span data-ttu-id="ee8cd-148">Fiddler トレースを収集して情報を取得し、一般的な 403 メッセージの HttpResponse 本文の一部として返されたメッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-148">Collect Fiddler traces to get more information and then check the messages returned as part of the HttpResponse body for common 403 messages:</span></span>

-   <span data-ttu-id="ee8cd-149">要求されたサービス構成にアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-149">The requested service config cannot be accessed.</span></span>
    1.  <span data-ttu-id="ee8cd-150">サンドボックスにアクセスできるアカウントを使用していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-150">Confirm that you are using an account that has access to the sandbox.</span></span>
    2.  <span data-ttu-id="ee8cd-151">適切なサンドボックス内にいることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-151">Confirm that you are within the correct sandbox.</span></span>
     3.  <span data-ttu-id="ee8cd-152">証明書認証を使用していてこのエラーが発生する場合は、担当のデベロッパー アカウント マネージャーに問い合わせてください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-152">If you are using certificate authentication and getting this error, contact your Developer Account Manager.</span></span>   <span data-ttu-id="ee8cd-153">要求されたセッションにアクセスできません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-153">The requested session cannot be accessed.</span></span> <span data-ttu-id="ee8cd-154">呼び出し元のユーザーにはマルチプレイヤー権限が必要であり、プライベート セッションはセッション メンバーによってのみ読み取り可能です。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-154">The calling user must have multiplayer privilege, and private sessions can only be read by session members.</span></span>

    <span data-ttu-id="ee8cd-155">おそらく可視性がプライベートのセッションにアクセスしようとしているため、セッションを表示できません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-155">You don't have the ability to see the session, possibly because you are trying to access a session that has a visibility of Private.</span></span> <span data-ttu-id="ee8cd-156">可視性がプライベートに設定されている場合、そのセッションのメンバーだけがセッション ドキュメントを読み取ることができます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-156">If the visibility is set to Private, only members of that session can read the session document.</span></span>

| <span data-ttu-id="ee8cd-157">注意</span><span class="sxs-lookup"><span data-stu-id="ee8cd-157">Note</span></span>                                                                                                                                                  |
|--------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="ee8cd-158">新しいセッションに登録するには、ユーザーにゴールド アカウントが必要です。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-158">A user must have a Gold account to register a new session.</span></span> <span data-ttu-id="ee8cd-159">プレイ中のユーザーにゴールド アカウント権限がない場合、新しいセッションの登録を要求すると HTTP/403 が返されます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-159">Without Gold account privileges for a playing user, requests to register a new session return HTTP/403.</span></span> |

-   <span data-ttu-id="ee8cd-160">認証プリンシパルにサーバーが含まれていない場合、要求本文に既存メンバーの参照を含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-160">The request body can't contain existing member references unless the authentication principal includes a server.</span></span>

    <span data-ttu-id="ee8cd-161">ユーザーの代わりに別のユーザーをセッションに参加させることはできません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-161">You cannot join another user to a session on behalf of a user.</span></span> <span data-ttu-id="ee8cd-162">招待のみ可能です。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-162">You can only invite.</span></span> <span data-ttu-id="ee8cd-163">プレイヤーを招待するには、インデックスを"reserve\_&lt;number&gt;" に設定します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-163">Set the index to "reserve\_&lt;number&gt;" to invite a player.</span></span>


### <a name="i-am-getting-an-http404-code-when-calling-mpsd"></a><span data-ttu-id="ee8cd-164">MPSD を呼び出すと HTTP/404 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-164">I am getting an HTTP/404 code when calling MPSD.</span></span>

<span data-ttu-id="ee8cd-165">Fiddler トレースを収集して詳しい情報を入手した後、以下の手順に従います。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-165">Collect Fiddler traces to get more information and then do the following:</span></span>

1.  <span data-ttu-id="ee8cd-166">一般的な 404 メッセージの HttpResponse 本文の一部として返されたメッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-166">Check the message returned as part of the HttpResponse body for common 404 messages:</span></span>
    -   <span data-ttu-id="ee8cd-167">要求されたサービス構成は無効であるか、またはセッション用に構成されていません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-167">The requested service config is either invalid or not configured for sessions.</span></span> <span data-ttu-id="ee8cd-168">使用している SCID が正しいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-168">Ensure that the SCID being used is correct.</span></span>
    -   <span data-ttu-id="ee8cd-169">要求されたセッションが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-169">The requested session wasn't found.</span></span> <span data-ttu-id="ee8cd-170">セッションが作成されていること、およびセッションを取得する前にセッション テンプレートが正しいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-170">Ensure that the session is created and that the session template is correct before retrieving it.</span></span> <span data-ttu-id="ee8cd-171">PUT 呼び出しを使用してセッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-171">You can create a session with a PUT call.</span></span>

2.  <span data-ttu-id="ee8cd-172">使用している URI を確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-172">Check the URI you are using.</span></span>
3.  <span data-ttu-id="ee8cd-173">本体を再起動するか、新しいユーザーで試します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-173">Reboot the console or try with a new user.</span></span>
4.  <span data-ttu-id="ee8cd-174">ゲーム デベロッパー フォーラムでエラー コードまたは他の解決策を調べます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-174">Check the Game Developer Forums for the error code or other solutions.</span></span>
5.  <span data-ttu-id="ee8cd-175">セッションが、空になったために削除されたのではないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-175">Confirm that the session was not deleted as a result of being empty.</span></span> <span data-ttu-id="ee8cd-176">ユーザーのタイムアウトが理由でセッションが空になることがあります。これが発生するのは、通常、すべてのセッションのメンバーが "準備完了" や "非アクティブ" などのタイムアウトが適用される状態になっているためです。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-176">Sessions can become empty because users time out. When this happens, it is frequently because all session members are in a state to which a timeout is applied, such as "ready" or "inactive".</span></span> <span data-ttu-id="ee8cd-177">ユーザーの状態の詳細については、「[セッションのユーザーの状態](mpsd-session-details.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-177">See [Session User States](mpsd-session-details.md) for user state details.</span></span>


### <a name="why-am-i-getting-an-http404-code-when-calling-multiplayerservicewritesessionbyhandleasync-or-multiplayerservicegetcurrentsessionbyhandleasync"></a><span data-ttu-id="ee8cd-178">**MultiplayerService.WriteSessionByHandleAsync** または **MultiplayerService.GetCurrentSessionByHandleAsync** を呼び出すと HTTP/404 コードを受け取るのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-178">Why am I getting an HTTP/404 code when calling **MultiplayerService.WriteSessionByHandleAsync** or **MultiplayerService.GetCurrentSessionByHandleAsync**?</span></span>

<span data-ttu-id="ee8cd-179">タイトルがハンドル ID を含む参加プロトコルのアクティブ化に応答してハンドルによって MPSD セッションにアクセスする場合、プロトコルのアクティブ化のハンドル ID が以下の理由のいずれかのために古くなっている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-179">If your title is accessing an MPSD session by handle in response to a join protocol activation containing a handle ID, the handle ID in the protocol activation might be stale for one of the following reasons:</span></span>

-   <span data-ttu-id="ee8cd-180">タイトルが参加を開始した Xbox のシェルの UI ビューが古くなっている可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-180">The UI view in the Xbox shell from which the title initiated the join might be out of date.</span></span> <span data-ttu-id="ee8cd-181">ユーザーのプロファイル カードなどの一部の UI ビューは、開かれている間、参加ハンドルを自動的に更新しません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-181">Some UI views, for example, the user's profile card, do not automatically refresh join handles while they are open.</span></span> <span data-ttu-id="ee8cd-182">HTTP/404 コードの受信を避けるには、参加する前に、タイトルでビューを閉じ、再度開いてデータを更新します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-182">To avoid receiving the HTTP/404 code, the title should close and reopen the view to refresh the data before joining.</span></span>
-   <span data-ttu-id="ee8cd-183">タイトルが参加させようとしているユーザーが、タイトルが Xbox シェル UI からの参加操作を選択した後でアクティビティ セッションを切り替えた可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-183">The user that the title is joining might have switched activity sessions after the title selected the join operation from the Xbox shell UI.</span></span> <span data-ttu-id="ee8cd-184">これが HTTP/404 コードの原因となるのはまれです。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-184">This reason for the HTTP/404 code should be rare.</span></span>

<span data-ttu-id="ee8cd-185">いずれの場合でも、タイトル コードでは、参加するユーザーに参加が失敗したことを示すエラー メッセージを示す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-185">In either of these cases, your title code should show the joining user an error message indicating that the join failed.</span></span>


### <a name="i-am-getting-an-http412-code-when-calling-mpsd"></a><span data-ttu-id="ee8cd-186">MPSD を呼び出すと HTTP/412 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-186">I am getting an HTTP/412 code when calling MPSD.</span></span>

<span data-ttu-id="ee8cd-187">既にセッションが存在する場合、次のような要求は HTTP/412 を返します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-187">The following request returns HTTP/412 if the session already exists:</span></span>

    PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1
    Content-Type: application/json
    If-None-Match: *


<span data-ttu-id="ee8cd-188">セッションの etag が If-Match ヘッダーと一致しない場合、次のような要求は HTTP/412 を返します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-188">The following request returns HTTP/412 if the session etag doesn't match the If-Match header:</span></span>

    PUT /serviceconfigs/00000000-0000-0000-0000-000000000000/sessiontemplates/quick/sessions/foo HTTP/1.1
    Content-Type: application/json
    If-Match: 9555A7DE-8B91-40E4-8CFB-0629312C9C7D


<span data-ttu-id="ee8cd-189">詳細については、「[セッション更新の同期](multiplayer-session-directory.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-189">See [Synchronization of Session Updates](multiplayer-session-directory.md) for more information.</span></span>


### <a name="i-am-getting-an-http400-405-409-503-etc-code-when-calling-mpsd"></a><span data-ttu-id="ee8cd-190">MPSD を呼び出すと HTTP/400、405、409、503 などのコードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-190">I am getting an HTTP/400, 405, 409, 503, etc. code when calling MPSD.</span></span>

<span data-ttu-id="ee8cd-191">Fiddler トレースを収集して情報を取得し、HttpResponse 本文の一部として返されたメッセージを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-191">Collect Fiddler traces to get more information, and then check messages returned as part of the HttpResponse body.</span></span> <span data-ttu-id="ee8cd-192">これにより、エラーを識別して修正するのに十分な情報が得られます。または、開発者フォーラムで解決策を検索できます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-192">This should give you enough information to identify and fix the error, or you can search the developer forums for resolutions.</span></span>

<span data-ttu-id="ee8cd-193">また、XSAPI を使用している場合は、「[Xbox Live サービス API のトラブルシューティング](../../using-xbox-live/troubleshooting/troubleshooting-the-xbox-live-services-api.md)」で説明されているように、応答本文を取得できます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-193">You can also get the response body if you are using XSAPI, as described in [Troubleshooting the Xbox Live Services API](../../using-xbox-live/troubleshooting/troubleshooting-the-xbox-live-services-api.md).</span></span> <span data-ttu-id="ee8cd-194">コードで **XboxLiveContextSettings.EnableServiceCallRoutedEvents** プロパティを使用して出力をタイトル UI に送信することもできます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-194">Alternatively, your code can use the **XboxLiveContextSettings.EnableServiceCallRoutedEvents** property to send output to your title UI.</span></span>


### <a name="what-can-or-should-i-change-in-the-session-templates-for-my-title"></a><span data-ttu-id="ee8cd-195">タイトルのセッション テンプレートでは何を変更できますか、または何を変更する必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-195">What can or should I change in the session templates for my title?</span></span>

<span data-ttu-id="ee8cd-196">セッション テンプレートはセッションのパターンなので、テンプレートで既に設定されている定数を上書きすることはできません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-196">Session templates are patterns for your sessions, and you can't override the constants already set in the templates.</span></span> <span data-ttu-id="ee8cd-197">ただし、新しいプロパティを追加することは可能です。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-197">However, you can add new properties to the templates.</span></span> <span data-ttu-id="ee8cd-198">詳細については、「[MPSD セッション テンプレート](multiplayer-session-directory.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-198">See [MPSD Session Templates](multiplayer-session-directory.md) for more detail.</span></span>


### <a name="im-getting-an-error-that-is-saying-my-session-isnt-initialized"></a><span data-ttu-id="ee8cd-199">セッションが初期化されていないことを示すエラーが示されます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-199">I'm getting an error that is saying my session isn't initialized.</span></span>

<span data-ttu-id="ee8cd-200">応答エラーの例:</span><span class="sxs-lookup"><span data-stu-id="ee8cd-200">Example response error:</span></span>

<span data-ttu-id="ee8cd-201">400 - \[ResponseBody\]: This session is configured for managed initialization requiring at least 2 members to start. (このセッションは、開始するために少なくとも 2 人のメンバーが必要な管理された初期化用に構成されています)</span><span class="sxs-lookup"><span data-stu-id="ee8cd-201">400 - \[ResponseBody\]: This session is configured for managed initialization requiring at least 2 members to start.</span></span>

<span data-ttu-id="ee8cd-202">"initialize" フィールドが true に設定された十分な数のセッション メンバー予約が要求に含まれないため、セッションを作成できません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-202">The session can't be created because not enough session member reservations with the "initialize" field set to true are included in the request.</span></span> <span data-ttu-id="ee8cd-203">コードで **MultiplayerSession.AddMemberReservation** メソッドまたは **MultiplayerSession.Join** メソッドの *initializeRequested* パラメーターを使用してメンバーに対してこのフィールドを設定できます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-203">Your code can set this field for a member using the *initializeRequested* parameter for the **MultiplayerSession.AddMemberReservation** method or the **MultiplayerSession.Join** method.</span></span>

<span data-ttu-id="ee8cd-204">初期化がセッション テンプレートで指定されている場合、マッチメイキング QoS に合格するのに十分な数のメンバー予約に対して "initialize":"true" が設定されていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-204">When initialization is specified in your session template, make sure that "initialize":"true" is set for enough of the member reservations to pass matchmaking QoS.</span></span> <span data-ttu-id="ee8cd-205">詳細については、「[ターゲット セッションの初期化と QoS](smartmatch-matchmaking.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-205">For more information, see [Target Session Initialization and QoS](smartmatch-matchmaking.md).</span></span>


### <a name="my-session-is-not-being-created-and-im-getting-an-http204-code"></a><span data-ttu-id="ee8cd-206">セッションが作成されず、HTTP/204 コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-206">My session is not being created and I'm getting an HTTP/204 code.</span></span>

<span data-ttu-id="ee8cd-207">このステータス コードは、セッションを作成したときにユーザーがセッションに追加されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-207">This status code indicates that no users were added to the session when you created it.</span></span> <span data-ttu-id="ee8cd-208">セッション作成時にセッションにユーザーが存在せず、空セッション タイムアウトが 0 (既定) の場合、セッションは作成されません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-208">If there are no users in the session when it's created and the session empty timeout is zero (default), the session is not created.</span></span>

<span data-ttu-id="ee8cd-209">セッションの作成時に、少なくとも 1 人のプレイヤーを必ず追加します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-209">Make sure that you include at least one player when creating a session.</span></span> <span data-ttu-id="ee8cd-210">専用サーバー シナリオの場合は、マッチを作成しようとしているプレイヤーまたはマッチを作成する必要があるプレイヤーを取得して、そのプレイヤーをそのマッチの初期プレイヤーにします。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-210">For dedicated server scenarios, obtain a player who is trying to create a match or who needs to create a match and make that player the initial player in the match.</span></span> <span data-ttu-id="ee8cd-211">または、空セッション タイムアウトを変更または削除してもかまいません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-211">Alternatively, you can change or remove the session empty timeout.</span></span> <span data-ttu-id="ee8cd-212">詳細については、「[セッション タイムアウト](mpsd-session-details.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-212">For more information, see [Session Timeouts](mpsd-session-details.md).</span></span>


### <a name="when-should-i-poll-mpsd"></a><span data-ttu-id="ee8cd-213">どのようなときに MPSD をポーリングする必要がありますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-213">When should I poll MPSD?</span></span>

<span data-ttu-id="ee8cd-214">タイトルは MPSD のポーリングを避ける必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-214">Your titles must avoid polling MPSD.</span></span> <span data-ttu-id="ee8cd-215">タイトルは、MPSD セッションへの変更を検出する必要がある場合は、セッション変更イベントをサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-215">If a title must discover changes to MPSD sessions, it should subscribe for session change events.</span></span> <span data-ttu-id="ee8cd-216">詳細については、「[方法: MPSD セッション変更通知のサブスクライブ](multiplayer-how-tos.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-216">For more information, see [How to: Subscribe for MPSD Session Change Notifications](multiplayer-how-tos.md).</span></span>


### <a name="what-happens-if-a-player-who-was-reserved-or-invited-to-the-session-does-not-join-it"></a><span data-ttu-id="ee8cd-217">セッションに予約または招待されたプレイヤーがセッションに参加しないとどうなりますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-217">What happens if a player who was reserved or invited to the session does not join it?</span></span>

<span data-ttu-id="ee8cd-218">ゲーム セッションの準備ができたことがプレイヤーに通知されたときにタイトルが動作しているかどうかによって異なります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-218">It depends on whether or not the title is running when the player is notified that the game session is ready.</span></span> <span data-ttu-id="ee8cd-219">プレイヤーがタイトル内にいて、タイトル UI 内からのゲーム セッション通知を受け入れない場合、**MultiplayerSession.Leave** メソッドによるゲーム セッションからのプレイヤーの削除はタイトルに委ねられます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-219">If the player is in the title and does not accept the game session notification from the title UI, it is up to the title to remove the player from the game session with the **MultiplayerSession.Leave** method.</span></span>

<span data-ttu-id="ee8cd-220">タイトルが制限されているか、または実行していない場合は、スロットが使用可能であることをプレイヤーに伝える通知をシェルが提供します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-220">If the title is constrained or not running, the shell provides a notification that informs the player that a slot is available.</span></span> <span data-ttu-id="ee8cd-221">プレイヤーがシステムからの通知を拒否または無視すると、MPSD はそのプレイヤーをゲーム セッションから削除します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-221">If the player declines or ignores the system notification, MPSD removes that person from the game session.</span></span>


### <a name="why-would-a-created-session-not-be-found-by-matchmaking"></a><span data-ttu-id="ee8cd-222">作成したセッションがマッチメイキングによって見つからないのはどうしてでしょうか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-222">Why would a created session not be found by matchmaking?</span></span>

<span data-ttu-id="ee8cd-223">Xbox One では、セッションを作成しただけでは、マッチメイキングは新しいセッションを検索しません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-223">On Xbox One, simply creating a session isn't enough for matchmaking to find the new session.</span></span> <span data-ttu-id="ee8cd-224">マッチ チケットを作成して、マッチメイキング サービスへのセッションの公開を開始する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-224">You must create a match ticket to start advertising the session to the matchmaking service.</span></span> <span data-ttu-id="ee8cd-225">「[SmartMatch マッチメイキング](smartmatch-matchmaking.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-225">See [SmartMatch Matchmaking](smartmatch-matchmaking.md).</span></span>


### <a name="what-is-the-key-difference-between-the-way-parties-are-properly-used-by-2015-multiplayer-and-the-way-they-were-used-in-2014-multiplayer"></a><span data-ttu-id="ee8cd-226">2015 マルチプレイヤーでのパーティーの適切な使用法と 2014 マルチプレイヤーでの使用法の主な違いは何ですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-226">What is the key difference between the way parties are properly used by 2015 Multiplayer and the way they were used in 2014 Multiplayer?</span></span>

<span data-ttu-id="ee8cd-227">2015 マルチプレイヤーでは、マルチプレイヤー API はシステム レベルのゲーム パーティーを定義せず、チャット パーティーのみを定義します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-227">In 2015 Multiplayer, the multiplayer API defines no system-level game party, only chat parties.</span></span> <span data-ttu-id="ee8cd-228">ゲーム パーティーを使用するのではなく、タイトルはセッションを使用して参加、招待、および関連する機能を制御します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-228">Instead of using game parties, the title uses sessions to control joining, invites, and related features.</span></span> <span data-ttu-id="ee8cd-229">2014 マルチプレイヤーでは、Xbox One の マルチプレイヤー API は、ゲーム パーティーの概念 (**Party** クラス) を顕著に使用し、実質的には、ゲームへの招待ではなく、システム レベルの参加ロビーを実装していました。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-229">For 2014 Multiplayer, the multiplayer API on Xbox One prominently used the game party concept (**Party** class), which effectively implements a system-level join lobby instead of game invites.</span></span>


### <a name="if-a-game-session-has-open-player-slots-and-supports-join-in-progress-why-would-users-not-be-able-to-find-the-session-once-it-has-started"></a><span data-ttu-id="ee8cd-230">ゲーム セッションに空きプレイヤー スロットがあり、ゲーム セッションが途中参加をサポートしている場合、開始したセッションをユーザーが見つけられないのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-230">If a game session has open player slots and supports join in progress, why would users not be able to find the session once it has started?</span></span>

<span data-ttu-id="ee8cd-231">ゲーム セッションは、開始時に、マッチメイキング サービスで公開されなくなりました。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-231">When a game session starts, it is no longer advertised on the matchmaking service.</span></span> <span data-ttu-id="ee8cd-232">プレイヤー スロットがセッション内で使用可能になり、アービター (ホスト) が新しいプレイヤーを集める場合、アービターは **MatchmakingService.CreateMatchTicketAsync** メソッドを使用して進行中のセッションに対する新しいマッチ チケットを作成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-232">If player slots become available within the session and the arbiter (host) wants to attract new players, the arbiter must create a new match ticket for the in-progress session with the **MatchmakingService.CreateMatchTicketAsync** method.</span></span> <span data-ttu-id="ee8cd-233">チケットは、セッションを再び公開して、さらにプレイヤーを探します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-233">The ticket advertises the session again and finds more players.</span></span> <span data-ttu-id="ee8cd-234">「[SmartMatch マッチメイキング](smartmatch-matchmaking.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-234">See [SmartMatch Matchmaking](smartmatch-matchmaking.md).</span></span>


### <a name="if-a-game-session-is-open-can-a-user-who-has-just-joined-a-game-simply-join-the-session-and-start-playing-without-having-to-wait-for-the-reservation"></a><span data-ttu-id="ee8cd-235">ゲーム セッションが開いている場合、ゲームに参加したばかりのユーザーは、予約を待つ必要はなく、単にセッションに参加してプレイを開始できますか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-235">If a game session is open, can a user who has just joined a game simply join the session and start playing without having to wait for the reservation?</span></span>

<span data-ttu-id="ee8cd-236">できます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-236">Yes.</span></span> <span data-ttu-id="ee8cd-237">これは、タイトルで複数のセッションを使用してゲーム セッション内でプレイヤーのサブグループを追跡する場合に特に便利です。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-237">This is especially useful in cases where your title uses multiple sessions to track sub-groups of players within a game session.</span></span> <span data-ttu-id="ee8cd-238">参加ユーザーは自分のグループを表すセッションに参加し、それよりも大きいゲーム セッションに参加する必要がある可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-238">The joining user might join the session representing his/her group, and then need to join the larger game session.</span></span>


### <a name="when-large-game-sessions-are-playing-in-my-title-why-arent-all-session-members-seeing-the-game-invite-toast"></a><span data-ttu-id="ee8cd-239">タイトルで大規模なゲーム セッションをプレイしているときに、ゲーム招待トーストを受け取らないセッション メンバーがいるのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-239">When large game sessions are playing in my title, why aren't all session members seeing the game invite toast?</span></span>

<span data-ttu-id="ee8cd-240">参加を通じてタイトルがユーザーをセッションに追加するとき、タイトルは常に **MultiplayerSessionMember.InitializeRequested** プロパティを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-240">When your title adds a user to the session through joining, the title always sets the **MultiplayerSessionMember.InitializeRequested** property to true.</span></span> <span data-ttu-id="ee8cd-241">これにより、ゲームを初期化ステージから移行する前に残りのセッション メンバーを待つように MPSD に指示します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-241">This tells MPSD to wait for the rest of the session members before moving the game out of the initialization stage.</span></span> <span data-ttu-id="ee8cd-242">そうでない場合は、ユーザーが参加できる時間が非常に短くなり、トーストとセッション変更通知を見逃す可能性があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-242">Otherwise, users have a very short window in which to join and can miss toasts and notifications of session changes.</span></span>


### <a name="i-am-seeing-inconsistent-game-behavior-and-have-received-protocol-activation-information-referencing-game-party-features"></a><span data-ttu-id="ee8cd-243">ゲームの動作に一貫性がなく、ゲーム パーティー機能を参照するプロトコルのアクティベーション情報を受け取りました。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-243">I am seeing inconsistent game behavior and have received protocol activation information referencing game party features.</span></span>

<span data-ttu-id="ee8cd-244">これは、2014 マルチプレイヤーと 2015 マルチプレイヤーの機能が混在していることを示しています。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-244">This indicates that you are mixing 2014 Multiplayer and 2015 Multiplayer functionality.</span></span> <span data-ttu-id="ee8cd-245">2015 マルチプレイヤー用の API は、2014 マルチプレイヤー用に記述されたコードでは決して使わないでください。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-245">The API for 2015 Multiplayer should never be used with code written for 2014 Multiplayer.</span></span>


### <a name="why-am-i-seeing-the-syntax-for-v105-session-documents-in-my-traces-although-i-have-configured-a-v107-session-template"></a><span data-ttu-id="ee8cd-246">V107 セッション テンプレートを構成したのに、v105 セッション ドキュメントの構文がトレースで表示されるのはなぜですか。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-246">Why am I seeing the syntax for v105 session documents in my traces although I have configured a v107 session template?</span></span>

<span data-ttu-id="ee8cd-247">MPSD は、クライアントの要求に基づいて、セッション ドキュメント バージョン間の自動変換を実行します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-247">The MPSD performs automatic conversion between session document versions based on the client request.</span></span> <span data-ttu-id="ee8cd-248">現在、すべての Xbox Service API は、MPSD への要求に v105 を使用します。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-248">Currently all Xbox Service APIs use v105 for requests to the MPSD.</span></span> <span data-ttu-id="ee8cd-249">このために、v107 セッション テンプレートと v105 トレースとの間で構文が異なる場合がありますが、それ以外の機能的な影響はありません。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-249">This may result in different syntax between v107 session templates and v105 traces but has no other functional impact.</span></span> <span data-ttu-id="ee8cd-250">セッション テンプレートは、v107 として構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-250">Session templates should be configured as v107.</span></span>

<span data-ttu-id="ee8cd-251">© 2015 Microsoft Corporation.</span><span class="sxs-lookup"><span data-stu-id="ee8cd-251">© 2015 Microsoft Corporation.</span></span> <span data-ttu-id="ee8cd-252">All rights reserved. </span><span class="sxs-lookup"><span data-stu-id="ee8cd-252">All rights reserved.</span></span>
<span data-ttu-id="ee8cd-253">フィードバックは <https://forums.xboxlive.com/spaces/22/index.html> で送信できます。</span><span class="sxs-lookup"><span data-stu-id="ee8cd-253">Submit feedback on <https://forums.xboxlive.com/spaces/22/index.html>.</span></span>
<span data-ttu-id="ee8cd-254">バージョン: 2.0.90731.0</span><span class="sxs-lookup"><span data-stu-id="ee8cd-254">Version: 2.0.90731.0</span></span>
