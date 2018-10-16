---
title: Xbox Live の呼び出しのベスト プラクティス
author: KevinAsgari
description: Xbox Live API を呼び出すためのベスト プラクティスについて説明します。
ms.assetid: f4c7156b-7736-41e5-9b3d-e87cc8dd2531
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, ベスト プラクティス
ms.localizationpriority: medium
ms.openlocfilehash: 0ce22d1571d5e4f96b384d6da914f1d359d78641
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4685093"
---
# <a name="best-practices-for-calling-xbox-live"></a><span data-ttu-id="6e781-104">Xbox Live の呼び出しのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="6e781-104">Best practices for calling Xbox Live</span></span>

<span data-ttu-id="6e781-105">Xbox Live サービスは、Xbox Services API (XSAPI) を使用するか、REST エンドポイントを直接呼び出すかの、主に 2 つの方法で呼び出せます。</span><span class="sxs-lookup"><span data-stu-id="6e781-105">The Xbox Live services can be called from two primary ways: using the Xbox Services API (XSAPI), or calling the REST endpoints directly.</span></span> <span data-ttu-id="6e781-106">コードでどのように Xbox Live を呼び出すかにかかわらず、適切な呼び出しパターンと再試行ロジックを備えることが重要です。</span><span class="sxs-lookup"><span data-stu-id="6e781-106">Regardless of how your code calls Xbox Live, it is important to have proper calling patterns and retry logic.</span></span>

<span data-ttu-id="6e781-107">適切な再試行ロジックを記述する方法を理解するには、**べき等**と**非べき等**の 2 種類の REST エンドポイントについて知る必要があります。</span><span class="sxs-lookup"><span data-stu-id="6e781-107">To understand how to write proper retry logic, it is necessary to know about the two types of REST endpoints - **idempotent** and **non-idempotent**.</span></span> <span data-ttu-id="6e781-108">以下で、それぞれについて説明します。</span><span class="sxs-lookup"><span data-stu-id="6e781-108">We will discuss each of these below</span></span>
 
## <a name="non-idempotent-endpoints"></a><span data-ttu-id="6e781-109">非べき等エンドポイント</span><span class="sxs-lookup"><span data-stu-id="6e781-109">Non-idempotent endpoints</span></span>

<span data-ttu-id="6e781-110">繰り返し呼び出しを行うと思わぬ結果が生じる HTTP メソッドは、**非べき等**と見なされます。</span><span class="sxs-lookup"><span data-stu-id="6e781-110">HTTP methods that have side effects upon repeat calls are considered to be **non-idempotent**.</span></span> <span data-ttu-id="6e781-111">これは、たとえばクライアントがエンドポイントを呼び出して、ネットワークのタイムアウトが発生した場合に、リソースが更新されたものの、メソッドが成功したことをネットワークが呼び出し元に通知できなかった可能性があるため、メソッドを再試行するのは安全ではないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="6e781-111">This means that if a client were to call the endpoint and a network timeout occurs, it is not safe to retry the method because the resource may have been updated but the network wasn't able to notify the caller that it was successful.</span></span> <span data-ttu-id="6e781-112">エラー発生時には、クライアントは再試行するのではなく、まず、呼び出しが成功したかどうかを確認するためのクエリを発行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6e781-112">Upon error, instead of retrying, the client must first query to see if the call was successful.</span></span> <span data-ttu-id="6e781-113">呼び出しが失敗であった場合にのみ再試行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6e781-113">Only if the call was not successful then should it retry.</span></span>

<span data-ttu-id="6e781-114">Xbox Services API に含まれる API の一部は、非べき等エンドポイントの呼び出しとして内部的にマーク付けされています。</span><span class="sxs-lookup"><span data-stu-id="6e781-114">In the Xbox Services API, some APIs are internally marked as calling non-idempotent endpoints.</span></span> <span data-ttu-id="6e781-115">これらの API は、非べき等エンドポイントの呼び出し時にエラーが発生した場合、そのエンドポイントの再試行を自動的には行いません。</span><span class="sxs-lookup"><span data-stu-id="6e781-115">This means that if failures occur when calling these endpoints, the APIs will not automatically retry the endpoint.</span></span>

<span data-ttu-id="6e781-116">非べき等エンドポイント API の完全な一覧を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="6e781-116">The full list of non-idempotent APIs are:</span></span>

* <span data-ttu-id="6e781-117">game\_server\_platform\_service::allocate\_cluster()</span><span class="sxs-lookup"><span data-stu-id="6e781-117">game\_server\_platform\_service::allocate\_cluster()</span></span>
<br>
* <span data-ttu-id="6e781-118">game\_server\_platform\_service::allocate\_cluster\_inline()</span><span class="sxs-lookup"><span data-stu-id="6e781-118">game\_server\_platform\_service::allocate\_cluster\_inline()</span></span>
<br>
* <span data-ttu-id="6e781-119">game\_server\_platform\_service::allocate\_session\_host()</span><span class="sxs-lookup"><span data-stu-id="6e781-119">game\_server\_platform\_service::allocate\_session\_host()</span></span>
<br>
* <span data-ttu-id="6e781-120">matchmaking\_service::create\_match\_ticket()</span><span class="sxs-lookup"><span data-stu-id="6e781-120">matchmaking\_service::create\_match\_ticket()</span></span>
<br>
* <span data-ttu-id="6e781-121">multiplayer\_service::write\_session()</span><span class="sxs-lookup"><span data-stu-id="6e781-121">multiplayer\_service::write\_session()</span></span>
<br>
* <span data-ttu-id="6e781-122">multiplayer\_service::write\_session\_by\_handle()</span><span class="sxs-lookup"><span data-stu-id="6e781-122">multiplayer\_service::write\_session\_by\_handle()</span></span>
<br>
* <span data-ttu-id="6e781-123">multiplayer\_service::send\_invites()</span><span class="sxs-lookup"><span data-stu-id="6e781-123">multiplayer\_service::send\_invites()</span></span>
<br>
* <span data-ttu-id="6e781-124">reputation\_service::submit\_batch\_reputation\_feedback()</span><span class="sxs-lookup"><span data-stu-id="6e781-124">reputation\_service::submit\_batch\_reputation\_feedback()</span></span>
<br>
* <span data-ttu-id="6e781-125">reputation\_service::submit\_reputation\_feedback()</span><span class="sxs-lookup"><span data-stu-id="6e781-125">reputation\_service::submit\_reputation\_feedback()</span></span>
 

## <a name="idempotent-methods"></a><span data-ttu-id="6e781-126">べき等メソッド</span><span class="sxs-lookup"><span data-stu-id="6e781-126">Idempotent methods</span></span>

<span data-ttu-id="6e781-127">一方、**べき等** HTTP メソッドは、思わぬ結果をそのままにしません。</span><span class="sxs-lookup"><span data-stu-id="6e781-127">**Idempotent** HTTP methods on the other hand do not leave side effects.</span></span> <span data-ttu-id="6e781-128">これはつまり、こうしたメソッドを再試行しても安全であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="6e781-128">This in turn means they are safe to be retried.</span></span> <span data-ttu-id="6e781-129">Xbox Services API に含まれるべき等メソッドはすべて、一定の条件下で自動的に再試行されます。</span><span class="sxs-lookup"><span data-stu-id="6e781-129">In the Xbox Services API, all idempotent methods are automatically retried under certain conditions.</span></span>

<span data-ttu-id="6e781-130">上の一覧に非べき等として示されなかったすべての API が、べき等 API です。</span><span class="sxs-lookup"><span data-stu-id="6e781-130">The full list of idempotent APIs are all APIs that were not listed above as being non-idempotent.</span></span>


## <a name="retry-logic-best-practices"></a><span data-ttu-id="6e781-131">再試行ロジックのベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="6e781-131">Retry logic Best Practices</span></span>

<span data-ttu-id="6e781-132">べき等呼び出しの場合、以下の条件については自動的に再試行してください。</span><span class="sxs-lookup"><span data-stu-id="6e781-132">For idempotent calls these conditions should be automatically retried:</span></span>

* <span data-ttu-id="6e781-133">すべてのネットワーク エラー</span><span class="sxs-lookup"><span data-stu-id="6e781-133">All network errors</span></span>
* <span data-ttu-id="6e781-134">401: Unauthorized</span><span class="sxs-lookup"><span data-stu-id="6e781-134">401: Unauthorized</span></span>
* <span data-ttu-id="6e781-135">408: RequestTimeout</span><span class="sxs-lookup"><span data-stu-id="6e781-135">408: RequestTimeout</span></span>
* <span data-ttu-id="6e781-136">429: Too Many Requests</span><span class="sxs-lookup"><span data-stu-id="6e781-136">429: Too Many Requests</span></span>
* <span data-ttu-id="6e781-137">500: InternalError</span><span class="sxs-lookup"><span data-stu-id="6e781-137">500: InternalError</span></span>
* <span data-ttu-id="6e781-138">502: BadGateway</span><span class="sxs-lookup"><span data-stu-id="6e781-138">502: BadGateway</span></span>
* <span data-ttu-id="6e781-139">503: ServiceUnavailable</span><span class="sxs-lookup"><span data-stu-id="6e781-139">503: ServiceUnavailable</span></span>
* <span data-ttu-id="6e781-140">504: GatewayTimeout</span><span class="sxs-lookup"><span data-stu-id="6e781-140">504: GatewayTimeout</span></span>


<span data-ttu-id="6e781-141">UWP 上では、401: Unauthorized は固有の処理が行われます。</span><span class="sxs-lookup"><span data-stu-id="6e781-141">On UWP, 401: Unauthorized is treated special.</span></span> <span data-ttu-id="6e781-142">このエラーは Xbox Live 認証トークンの有効期限が切れたことを示すため、Xbox Services API は、OS を呼び出してトークンを更新してから、1 回の再試行として実行されます。</span><span class="sxs-lookup"><span data-stu-id="6e781-142">It indicates the Xbox Live authentication token expired, so the Xbox Services API calls into the OS to refresh the token and then performs as a single retry.</span></span>

<span data-ttu-id="6e781-143">再試行が実行される場合のベスト プラクティスは、"Retry-After" ヘッダーの時間に到達するまでサービスを呼び出さないことです。</span><span class="sxs-lookup"><span data-stu-id="6e781-143">When a retry is performed, it is best practice to not call the service until the "Retry-After" header time has been reached.</span></span> <span data-ttu-id="6e781-144">現状では XSAPI にこのベスト プラクティスが実装されています。</span><span class="sxs-lookup"><span data-stu-id="6e781-144">XSAPI now implements this best practice.</span></span> <span data-ttu-id="6e781-145">いずれかの API でエラーの HTTP ステータス コードや "Retry-After" ヘッダーが返された場合、Retry-After の時間になる前に同じ API を追加呼び出しすると、サービスに到達することなく直ちに元のエラーが返されます。</span><span class="sxs-lookup"><span data-stu-id="6e781-145">If a failure HTTP status code and "Retry-After" header was returned for any API, additional calls to that same API before the Retry-After time will immediately return with the original error without hitting the service.</span></span>

<span data-ttu-id="6e781-146">呼び出しを再試行するときのベスト プラクティスは、ランダムな小さな変動を加えて指数バックオフを実行し、サービスに対する負荷を拡散させることです。</span><span class="sxs-lookup"><span data-stu-id="6e781-146">When retrying a call, it is best practice to perform exponential back-off with a random jitter to spread out the load to the service.</span></span> <span data-ttu-id="6e781-147">XSAPI は既定で 2 秒の遅延を適用して開始されます。この時間は、xbox\_live\_context\_settings::set\_http\_retry\_delay() を使用して制御されます。</span><span class="sxs-lookup"><span data-stu-id="6e781-147">XSAPI starts with a default delay of 2 seconds which is controlled using xbox\_live\_context\_settings::set\_http\_retry\_delay().</span></span> <span data-ttu-id="6e781-148">これは、各再試行では既定で 2 秒、4 秒、8 秒などの指数バックオフが実行され、再試行を試みる一連のデバイス間で負荷をさらに分散させるため、今回と次回のバックオフ値から生じる遅延には、応答時間に基づいた変動が生じることを意味します。</span><span class="sxs-lookup"><span data-stu-id="6e781-148">This means by default each retry does an exponential back-off of 2, 4, 8, etc seconds and it jitters the delay between the current and next back-off value based on the response time to further spread out load across the set of devices attempting the retry.</span></span>

<span data-ttu-id="6e781-149">呼び出しの再試行に費やす時間はタイトル側で制御する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6e781-149">Titles should be in control of how long spend retrying a call.</span></span> <span data-ttu-id="6e781-150">デベロッパーは、XSAPI を利用する場合、xbox\_live\_context\_settings::set\_http\_timeout\_window() 関数を使用してこれを直接制御できます。</span><span class="sxs-lookup"><span data-stu-id="6e781-150">Using XSAPI, developers have direct control of this by using the function xbox\_live\_context\_settings::set\_http\_timeout\_window().</span></span> <span data-ttu-id="6e781-151">既定では、これは 20 秒に設定されます。</span><span class="sxs-lookup"><span data-stu-id="6e781-151">By default, this is set to 20 seconds.</span></span> <span data-ttu-id="6e781-152">これを 0 秒に設定すると、事実上、再試行ロジックがオフになります。</span><span class="sxs-lookup"><span data-stu-id="6e781-152">Setting this to 0 seconds will effectively turn off retry logic.</span></span> <span data-ttu-id="6e781-153">XSAPI では、http\_timeout\_window() での残り時間に基づいて、内部の HTTP タイムアウトも動的に調整されます。</span><span class="sxs-lookup"><span data-stu-id="6e781-153">XSAPI now also dynamically adjusts the internal HTTP timeout based on how much time left remains in the http\_timeout\_window().</span></span> <span data-ttu-id="6e781-154">内部の HTTP タイムアウトは、OS が HTTP ネットワーク操作を中止するまでに、その操作に費やす時間を制御します。</span><span class="sxs-lookup"><span data-stu-id="6e781-154">The internal HTTP timeout controls how long the OS spends doing the HTTP network operation before it aborts.</span></span> <span data-ttu-id="6e781-155">呼び出しが完了するのに十分妥当な時間が与えられるように、http\_timeout\_window() に少なくとも 5 秒残されていないと、呼び出しは再試行されません。</span><span class="sxs-lookup"><span data-stu-id="6e781-155">The call will not be retried unless there remains at least 5 seconds left in the http\_timeout\_window() to give an enough reasonable time for the call to complete.</span></span> <span data-ttu-id="6e781-156">このルールは最初の呼び出しには適用されないので、http\_timeout\_window() を 0 に設定することも可能で、その場合は 1 回の呼び出しとなります。</span><span class="sxs-lookup"><span data-stu-id="6e781-156">This rule doesn't apply to the first call so setting the http\_timeout\_window() to 0 is acceptable, and will result in a single call.</span></span> <span data-ttu-id="6e781-157">このロジックの影響によって、API 呼び出しがいつ返るかに関して、http\_timeout\_window() は大幅に確定的です。</span><span class="sxs-lookup"><span data-stu-id="6e781-157">This logic has the effect that http\_timeout\_window() is a lot more deterministic when the API call will return.</span></span> <span data-ttu-id="6e781-158">"Retry-After" ヘッダーが返された場合、"Retry-After" の時間に達するまで再試行は行われません。</span><span class="sxs-lookup"><span data-stu-id="6e781-158">If a "Retry-After" header was returned, no reties will be made until after the "Retry-After" time has been reached.</span></span> <span data-ttu-id="6e781-159">"Retry-After" の時間が http\_timeout\_window() の後である場合は、http\_timeout\_window() の終わりに呼び出しが返ります。</span><span class="sxs-lookup"><span data-stu-id="6e781-159">If the "Retry-After" time is after the http\_timeout\_window(), then the call return at the end of the http\_timeout\_window().</span></span>


## <a name="error-handling"></a><span data-ttu-id="6e781-160">エラー処理</span><span class="sxs-lookup"><span data-stu-id="6e781-160">Error handling</span></span>

<span data-ttu-id="6e781-161">タイトル デベロッパーは、**すべての**サービス呼び出しに対して**常に**適切なエラー処理を行う必要があり、失敗した応答を適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6e781-161">Title developers should **always** use proper error handling for **every** service call, they need to ensure that they are handling failed responses properly.</span></span>
 
<span data-ttu-id="6e781-162">Xbox Live に対する要求がエラー コードを返す結果になることがある次のような状況は、実際に数多くあります。</span><span class="sxs-lookup"><span data-stu-id="6e781-162">There are many real-world conditions that can result in a request to Xbox Live to return failure codes, such as</span></span>

1.  <span data-ttu-id="6e781-163">ネットワークを利用できない。</span><span class="sxs-lookup"><span data-stu-id="6e781-163">Network is not available.</span></span> <span data-ttu-id="6e781-164">たとえば、デバイスが 4G や Wi-Fi の接続を失ったり、ネットワークがダウン状態になった場合。</span><span class="sxs-lookup"><span data-stu-id="6e781-164">For example, the device lost 4G, lost Wi-Fi, or the network went down.</span></span>
2.  <span data-ttu-id="6e781-165">サービスに対する負荷が大きすぎる (503)</span><span class="sxs-lookup"><span data-stu-id="6e781-165">Too much load on services over load (503)</span></span>
3.  <span data-ttu-id="6e781-166">サービスでエラーが発生した (500)</span><span class="sxs-lookup"><span data-stu-id="6e781-166">A failure happened on the service (500)</span></span>
4.  <span data-ttu-id="6e781-167">サービスに送信された要求が多すぎる (429)</span><span class="sxs-lookup"><span data-stu-id="6e781-167">Too many requests where sent to the service (429)</span></span>
5.  <span data-ttu-id="6e781-168">書き込み操作の競合 (412)。</span><span class="sxs-lookup"><span data-stu-id="6e781-168">Write operation conflict (412).</span></span> <span data-ttu-id="6e781-169">たとえば、マルチプレイヤー セッション内の別のプレイヤーが先に変更を送信した場合。</span><span class="sxs-lookup"><span data-stu-id="6e781-169">For example, another player in a multiplayer session submitted a change first</span></span>
6.  <span data-ttu-id="6e781-170">ユーザーが禁止されている、またはアクセス許可がない</span><span class="sxs-lookup"><span data-stu-id="6e781-170">The user has been banned or does not have permission</span></span>
7.  <span data-ttu-id="6e781-171">ユーザーがサインアウトした</span><span class="sxs-lookup"><span data-stu-id="6e781-171">User has signed-out</span></span>

<span data-ttu-id="6e781-172">これらの状況でゲームが正しく機能するようにするためには、適切なエラー処理が非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="6e781-172">Proper error handler is crucial to ensure that the game functions correctly in these conditions.</span></span>

<span data-ttu-id="6e781-173">XSAPI には 2 種類のエラー処理パターンがあります。</span><span class="sxs-lookup"><span data-stu-id="6e781-173">XSAPI has two types of error handling patterns.</span></span> <span data-ttu-id="6e781-174">1 つは C++/CX、C\#、または JavaScript から WinRT API を使用しているときのパターンで、もう 1 つは新しい C++ API を使用しているときのパターンです。</span><span class="sxs-lookup"><span data-stu-id="6e781-174">One pattern when using the WinRT APIs from C++/CX, C\#, or Javascript, and another pattern when using the new C++ APIs.</span></span> <span data-ttu-id="6e781-175">エラー処理のベスト プラクティスの詳細については、Xbox Live のドキュメント ページ「Error Handling」を参照してください。また、これに関して説明している動画については、[*Xfest 2015 のビデオ*](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2015.aspx)の「*XSAPI: C++, No Exceptions!*」という講演をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6e781-175">Full details on best practices of error handling, see the Xbox Live doc page "Error Handling" and for a video that covers this, please refer to the talk in [*Xfest 2015 Videos*](https://developer.xboxlive.com/en-us/platform/documentlibrary/events/Pages/Xfest2015.aspx) called *XSAPI: C++, No Exceptions!*</span></span>


## <a name="best-calling-patterns"></a><span data-ttu-id="6e781-176">最適な呼び出しパターン</span><span class="sxs-lookup"><span data-stu-id="6e781-176">Best calling patterns</span></span>

### <a name="use-batching-requests"></a><span data-ttu-id="6e781-177">バッチ処理要求を使用する</span><span class="sxs-lookup"><span data-stu-id="6e781-177">Use batching requests</span></span>

<span data-ttu-id="6e781-178">一部のエンドポイントは、バッチ処理、つまり一連の要求を 1 つの呼び出しに集約することをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="6e781-178">Some endpoints support batching or aggregating of a set of requests into a single call.</span></span> <span data-ttu-id="6e781-179">たとえば、Xbox Live プロフィール サービスを使用すると、1 人のユーザーのプロフィールまたはユーザー プロフィールのセットを要求できます。</span><span class="sxs-lookup"><span data-stu-id="6e781-179">For example, with the Xbox Live profile service you can ask for a single user's profile or a set of users profiles.</span></span> <span data-ttu-id="6e781-180">一連のユーザーのユーザー プロフィールが必要な場合、ユーザー プロフィールごとに 1 回エンドポイントや API を呼び出すのは非常に非効率的です。</span><span class="sxs-lookup"><span data-stu-id="6e781-180">So if you need a user profiles for a set of users, it would be very inefficient to call the endpoint or API one at a time for each user profile.</span></span> <span data-ttu-id="6e781-181">それぞれの呼び出しで、多くの認証オーバーヘッドが発生します。</span><span class="sxs-lookup"><span data-stu-id="6e781-181">Each call adds a lot of authentication overhead.</span></span> <span data-ttu-id="6e781-182">そのため何度も API を呼び出すのではなく、情報が必要なすべてのユーザーを一度に API に渡して、エンドポイントがすべてのユーザー プロフィールを同時に処理し、単一の応答を返すことができるようにします。</span><span class="sxs-lookup"><span data-stu-id="6e781-182">So instead, pass all the users you want information about at once to the API, so that the endpoint can process all the user profiles at the same time and return a single response.</span></span>

### <a name="use-the-real-time-activity-rta-service-instead-of-polling"></a><span data-ttu-id="6e781-183">ポーリングの代わりにリアルタイム アクティビティ (RTA) サービスを使用する</span><span class="sxs-lookup"><span data-stu-id="6e781-183">Use the Real Time Activity (RTA) service instead of polling</span></span>

<span data-ttu-id="6e781-184">別のベスト プラクティスは、定期的にポーリングする代わりに、リアルタイム アクティビティ (RTA) サービスを使用することです。</span><span class="sxs-lookup"><span data-stu-id="6e781-184">Another best practice is use the Real Time Activity (RTA) service instead periodic polling.</span></span> <span data-ttu-id="6e781-185">このサービスは、サービスで対象リソースに変更があったときに、クライアントに通知を送信する WebSocket を公開します。</span><span class="sxs-lookup"><span data-stu-id="6e781-185">This service exposes a websocket that sends a notification to clients when target resources change on the service.</span></span> <span data-ttu-id="6e781-186">RTA サービスは、プレゼンスの変更、統計情報の変更、マルチプレイヤー セッション ドキュメントの変更、およびソーシャル関係の変更についての通知を提供します。</span><span class="sxs-lookup"><span data-stu-id="6e781-186">The RTA service gives notifications on presence changes, statistic changes, multiplayer session document changes and social relationship changes.</span></span> <span data-ttu-id="6e781-187">クライアントがどのような情報を必要としているかを認識させるために、クライアントが最初に、WebSocket を介してアイテムにサブスクライブする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6e781-187">To know what the information client is interested in, the client must first subscribe to the item over the websocket.</span></span> <span data-ttu-id="6e781-188">これにより、アイテムの変更があると適切に通知されるため、変更の検出のためにサービスにポーリングする必要がなくなります。</span><span class="sxs-lookup"><span data-stu-id="6e781-188">This avoids polling the service to detect changes since you will be told exactly when the item changes.</span></span>

<span data-ttu-id="6e781-189">XSAPI は RTA サービスを、クライアントが使用できるサブスクライブ API のセットとして公開しています。</span><span class="sxs-lookup"><span data-stu-id="6e781-189">XSAPI exposes the RTA service as a set of subscribe APIs that clients can use.</span></span> <span data-ttu-id="6e781-190">これらの API それぞれに、アイテムの変更時に呼び出されるコールバック関数を引数に取る、対応する \*\_changed\_handler API があります。</span><span class="sxs-lookup"><span data-stu-id="6e781-190">Each of these APIs have corresponding \*\_changed\_handler APIs which take in a callback function that will be called when an item changes.</span></span>

* <span data-ttu-id="6e781-191">presence\_service::subscribe\_to\_device\_presence\_change</span><span class="sxs-lookup"><span data-stu-id="6e781-191">presence\_service::subscribe\_to\_device\_presence\_change</span></span>
<br>
* <span data-ttu-id="6e781-192">presence\_service::subscribe\_to\_title\_presence\_change</span><span class="sxs-lookup"><span data-stu-id="6e781-192">presence\_service::subscribe\_to\_title\_presence\_change</span></span>
<br>
* <span data-ttu-id="6e781-193">user\_statistics\_service::subscribe\_to\_statistic\_change</span><span class="sxs-lookup"><span data-stu-id="6e781-193">user\_statistics\_service::subscribe\_to\_statistic\_change</span></span>
<br>
* <span data-ttu-id="6e781-194">social\_service::subscribe\_to\_social\_relationship\_change</span><span class="sxs-lookup"><span data-stu-id="6e781-194">social\_service::subscribe\_to\_social\_relationship\_change</span></span><br>
 

## <a name="use-xbox-live-client-side-managers"></a><span data-ttu-id="6e781-195">Xbox Live クライアント側マネージャーを使用する</span><span class="sxs-lookup"><span data-stu-id="6e781-195">Use Xbox Live client side managers</span></span>

<span data-ttu-id="6e781-196">XSAPI では新たに、キャッシュおよび特定シナリオの手間がかかる処理をすべて実行するステート マシンとして機能するマネージャーのセットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="6e781-196">New in XSAPI we now have a set of managers which act as cache and state machines that do all the heavy lifting for certain scenarios.</span></span>


### <a name="social-manager"></a><span data-ttu-id="6e781-197">Social Manager</span><span class="sxs-lookup"><span data-stu-id="6e781-197">Social Manager</span></span>

<span data-ttu-id="6e781-198">Social Manager は、フレンド リストとプロフィールに関連する手間がかかる処理をすべて実行します。</span><span class="sxs-lookup"><span data-stu-id="6e781-198">The Social Manager does all the heavy lifting around friends lists and profiles.</span></span> <span data-ttu-id="6e781-199">RTA サービスを使用して、フレンド リスト、フレンドのプロフィールおよびプレゼンス データを最新の状態に保ちます。</span><span class="sxs-lookup"><span data-stu-id="6e781-199">It will keep your friends list, their profiles, and their presence data up to date using the RTA service.</span></span> <span data-ttu-id="6e781-200">このマネージャーは、ゲーム エンジンから非常に利用しやすい同期 API を公開しています。</span><span class="sxs-lookup"><span data-stu-id="6e781-200">The manager exposes a synchronous API that is very game engine friendly.</span></span> <span data-ttu-id="6e781-201">マネージャーがサービスから得た最新情報のメモリー内キャッシュを保持しているため、ゲームはこれらの API を頻繁に呼び出せます。</span><span class="sxs-lookup"><span data-stu-id="6e781-201">Games can call its APIs frequently as it maintains an in-memory cache of the latest information from the service.</span></span> <span data-ttu-id="6e781-202">詳細については、Xbox Live ドキュメントのページ「Social Manager の概要」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6e781-202">For more information, see the Xbox Live documentation page "Introduction to Social Manager"</span></span>

### <a name="multiplayer-manager"></a><span data-ttu-id="6e781-203">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="6e781-203">Multiplayer Manager</span></span>

<span data-ttu-id="6e781-204">Multiplayer Manager は、従来のマルチプレイヤー ゲーム用に簡単に使えるソリューションで、マルチプレイヤー セッションを管理できます。</span><span class="sxs-lookup"><span data-stu-id="6e781-204">For multiplayer session management, the Multiplayer Manager is a drop-in solution for traditional multiplayer games.</span></span> <span data-ttu-id="6e781-205">Multiplayer Manager API には、プレイヤーのロスターとセッション管理が含まれていて、ゲームへの招待、途中参加、マッチメイキングの処理、および既存のネットワーク ソリューションへの接続も可能です。</span><span class="sxs-lookup"><span data-stu-id="6e781-205">The Multiplayer Manager API includes player roster and session management, handles game invites, join in progress, matchmaking, and plugs into your existing networking solution.</span></span> <span data-ttu-id="6e781-206">このマネージャーは、従来のマルチプレイヤー フローの実装に関連する手間がかかる処理をすべて実行します。</span><span class="sxs-lookup"><span data-stu-id="6e781-206">It does all the heavy lifting around implementing traditional multiplayer flows.</span></span> <span data-ttu-id="6e781-207">詳細については、Xbox Live ドキュメントのページ「Introduction to Multiplayer Manager」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6e781-207">For more information, see the Xbox Live documentation page "Introduction to Multiplayer Manager"</span></span>


## <a name="throttling-fine-grained-rate-limiting"></a><span data-ttu-id="6e781-208">スロットリング (きめ細かなレート制限)</span><span class="sxs-lookup"><span data-stu-id="6e781-208">Throttling (fine grained rate limiting)</span></span>

<span data-ttu-id="6e781-209">Xbox Live サービスには、単一デバイスがサービスに極端な負荷をかけることがないように、スロットリングが導入されています。</span><span class="sxs-lookup"><span data-stu-id="6e781-209">Xbox Live services have throttling in place to prevent any single device from putting extreme load on the service.</span></span> <span data-ttu-id="6e781-210">重要なのは、タイトルにいつスロットリングが適用されるかを知ることです。</span><span class="sxs-lookup"><span data-stu-id="6e781-210">It's important to know when your title was throttled.</span></span> <span data-ttu-id="6e781-211">タイトルにスロットリングが適用されたかどうかは、いくつかの異なる方法で確認できます。</span><span class="sxs-lookup"><span data-stu-id="6e781-211">You can tell if your title was throttled in a few different ways:</span></span>


### <a name="monitor-for-http-status-code-429"></a><span data-ttu-id="6e781-212">HTTP ステータス コード 429 を監視する</span><span class="sxs-lookup"><span data-stu-id="6e781-212">Monitor for HTTP Status Code 429</span></span>

<span data-ttu-id="6e781-213">Fiddler を使用して、HTTP ステータス コード 429 が返されたかどうかを監視できます。</span><span class="sxs-lookup"><span data-stu-id="6e781-213">You can use Fiddler and watch if an HTTP Status Code 429 is returned.</span></span> <span data-ttu-id="6e781-214">JSON 応答に、エンドポイントがどのようにスロットリングされたかに関する詳細が含められます。</span><span class="sxs-lookup"><span data-stu-id="6e781-214">The JSON response will contain detail about how the endpoint was throttled.</span></span> <span data-ttu-id="6e781-215">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="6e781-215">For example:</span></span>

```json
{
  "version":1,
  "currentRequests":13,
  "maxRequests":10,
  "periodInSeconds":120,
  "limitType":"Rate"
}
```

<span data-ttu-id="6e781-216">XSAPI を使用している場合、API は http\_status\_429\_too\_many\_requests エラーを返し、API がどのようにスロットリングされたかに関する詳細なエラー メッセージを設定します。</span><span class="sxs-lookup"><span data-stu-id="6e781-216">If you are using XSAPI, APIs will return a http\_status\_429\_too\_many\_requests error and set the error message to be detail about how the API was throttled.</span></span>

### <a name="debug-asserts"></a><span data-ttu-id="6e781-217">デバッグのアサート</span><span class="sxs-lookup"><span data-stu-id="6e781-217">Debug asserts</span></span>

<span data-ttu-id="6e781-218">XSAPI の使用時には、デベロッパー サンドボックス内でタイトルのデバッグ ビルドを使用しているときに呼び出しがスロットリングされると、スロットリングが発生したことを直ちにデベロッパーに知らせるため、アサートが発生します。</span><span class="sxs-lookup"><span data-stu-id="6e781-218">When using XSAPI, if the call is throttled while in a developer sandbox and using a debug build of the title, it will assert to immediately let the developer know that a throttle occurred.</span></span> <span data-ttu-id="6e781-219">これは、コードが正しく記述されていないために 429 スロットリング エラーを意図せず見逃すということがないようにするためです。</span><span class="sxs-lookup"><span data-stu-id="6e781-219">This is to avoid unintentionally missing 429 throttle error due to incorrectly written code.</span></span> <span data-ttu-id="6e781-220">これらのアサートを無効にして、問題のコードを修正せずに作業を続けたい場合は、次の API を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="6e781-220">If you wish to disable these asserts to continue working without fixing the offending code, you can call this API:</span></span>


> <span data-ttu-id="6e781-221">xboxLiveContext-&gt;settings()-&gt;disable\_asserts\_for\_xbox\_live\_throttling\_in\_dev\_sandboxes( xbox\_live\_context\_throttle\_setting::this\_code\_needs\_to\_be\_changed\_to\_avoid\_throttling );</span><span class="sxs-lookup"><span data-stu-id="6e781-221">xboxLiveContext-&gt;settings()-&gt;disable\_asserts\_for\_xbox\_live\_throttling\_in\_dev\_sandboxes( xbox\_live\_context\_throttle\_setting::this\_code\_needs\_to\_be\_changed\_to\_avoid\_throttling );</span></span>

<span data-ttu-id="6e781-222">ただし、この API によってタイトルのスロットリングが回避されるわけではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="6e781-222">but note that this API will not prevent your title from being throttled.</span></span> <span data-ttu-id="6e781-223">タイトルは、変わらずスロットリングされます。</span><span class="sxs-lookup"><span data-stu-id="6e781-223">Your title will still be throttled.</span></span> <span data-ttu-id="6e781-224">この API は、デベロッパー サンドボックス内でデバッグ ビルドを使用するときにアサートを無効にするだけです。</span><span class="sxs-lookup"><span data-stu-id="6e781-224">This simply disables the asserts when in dev sandboxes while using a debug build.</span></span> 

### <a name="xbox-live-trace-analyzer-tool"></a><span data-ttu-id="6e781-225">Xbox Live Trace Analyzer ツール</span><span class="sxs-lookup"><span data-stu-id="6e781-225">Xbox Live Trace Analyzer tool</span></span>

<span data-ttu-id="6e781-226">Xbox Live 呼び出しのトレースを記録してから、[Xbox Live Trace Analyzer ツール](https://docs.microsoft.com/windows/uwp/xbox-live/tools/analyze-service-calls)を使用して、そのトレースを分析することもできます。</span><span class="sxs-lookup"><span data-stu-id="6e781-226">Another option is to record a trace of the Xbox Live calls and then analyze that trace using the [Xbox Live Trace Analyzer tool.](https://docs.microsoft.com/windows/uwp/xbox-live/tools/analyze-service-calls)</span></span>

<span data-ttu-id="6e781-227">トレースを記録するには、Fiddler を使用して .SAZ ファイルを記録するか、XSAPI の組み込みトレース ログを使用します。</span><span class="sxs-lookup"><span data-stu-id="6e781-227">To record a trace, you can either use Fiddler to record a .SAZ file, or by using the built-in trace logging of XSAPI.</span></span> <span data-ttu-id="6e781-228">XSAPI でトレースをオンにする方法の詳細については、Xbox Live ドキュメントのページ「Xbox Live サービスへの呼び出しを分析する」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="6e781-228">For more information, how to use turn on traces in XSAPI see the Xbox Live documentation page "Analyze calls to Xbox Live Services".</span></span> <span data-ttu-id="6e781-229">トレースを用意すると、スロットリングされた呼び出しの検出時に Xbox Live Trace Analyzer ツールが警告を発します。</span><span class="sxs-lookup"><span data-stu-id="6e781-229">Once you have a trace, the Xbox Live Trace Analyzer tool will warn upon detecting throttled calls.</span></span>

## <a name="is-xbox-live-up"></a><span data-ttu-id="6e781-230">Xbox Live は稼働中か</span><span class="sxs-lookup"><span data-stu-id="6e781-230">Is Xbox Live Up?</span></span>

<span data-ttu-id="6e781-231">Xbox Live は、プロフィール、フレンドとプレゼンス、統計情報、ランキング、実績、マルチプレイヤー、マッチメイキングなどの Xbox Live の機能を公開するマイクロサービスの集合体です。</span><span class="sxs-lookup"><span data-stu-id="6e781-231">Xbox Live is a collection of microservices that expose Xbox Live features such as profile, friends and presence, stats, leaderboards, achievements, multiplayer, and matchmaking.</span></span> <span data-ttu-id="6e781-232">Xbox Live が稼働中かどうかを決める単一のサーバーやエンドポイントは存在しません。</span><span class="sxs-lookup"><span data-stu-id="6e781-232">There isn’t a single server or endpoint that defines if Xbox Live is up.</span></span> <span data-ttu-id="6e781-233">1 台のサーバーがダウンした場合でも、Xbox Live の残りのマイクロサービスは、その大部分が独立していて、動作可能です。</span><span class="sxs-lookup"><span data-stu-id="6e781-233">If a single server goes down, the rest of the Xbox Live microservices are largely independent and should be operational.</span></span>

<span data-ttu-id="6e781-234">1 つのサービスで一時的な停止が発生している場合、そのサービスの呼び出しがゲームにとってミッション クリティカルであるかどうかを知ることが重要です。</span><span class="sxs-lookup"><span data-stu-id="6e781-234">If a single service experiences a temporary outage, it’s important to know if this service call is mission critical for your game.</span></span> <span data-ttu-id="6e781-235">ネットワークやサービスの問題が断続的に発生しているときには、適切なエクスペリエンスを提供するようにしてください。</span><span class="sxs-lookup"><span data-stu-id="6e781-235">Try to provide reasonable experience while there are intermittent network or service issues.</span></span> <span data-ttu-id="6e781-236">たとえば、プレゼンス サービスがエラーを返している場合、その呼び出しはおそらくゲームにとってミッション クリティカルではありません。</span><span class="sxs-lookup"><span data-stu-id="6e781-236">For example, if the presence service is returning failure that call likely isn’t mission critical for your game.</span></span> <span data-ttu-id="6e781-237">そのためユーザーには、Xbox Live がダウンしていることを報告するのではなく、最後の既知のプレゼンス情報を報告するだけにします。</span><span class="sxs-lookup"><span data-stu-id="6e781-237">So simply report to the user the last known presence instead of reporting that Xbox Live is down.</span></span>

<span data-ttu-id="6e781-238">Xbox Live は、結果整合性という一貫性モデルにも従っています。</span><span class="sxs-lookup"><span data-stu-id="6e781-238">Xbox Live also follows the consistency model of eventual consistency.</span></span> <span data-ttu-id="6e781-239">これは、新しい更新が行われない場合、最終的には、そのリソースに対するすべての要求で、最後に更新された値が報告されることを意味します。</span><span class="sxs-lookup"><span data-stu-id="6e781-239">This means that if no new updates are made, that eventually all requests for that resource will report the last updated value.</span></span> <span data-ttu-id="6e781-240">これはつまり、データが伝播するまで情報が古いままである、短い期間があることを意味しています。</span><span class="sxs-lookup"><span data-stu-id="6e781-240">This in effect means that a small period where the information is stale as the data propagates.</span></span>
