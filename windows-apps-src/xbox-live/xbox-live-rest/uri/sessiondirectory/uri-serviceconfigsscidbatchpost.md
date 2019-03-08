---
title: POST (/serviceconfigs/{scid}/batch)
assetID: b821a6eb-1add-ef91-bdf5-10e107082197
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidbatchpost.html
description: " POST (/serviceconfigs/{scid}/batch)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e718fda26264667a7bf08c9254a462eb268dcd74
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603447"
---
# <a name="post-serviceconfigsscidbatch"></a><span data-ttu-id="8c63f-104">POST (/serviceconfigs/{scid}/batch)</span><span class="sxs-lookup"><span data-stu-id="8c63f-104">POST (/serviceconfigs/{scid}/batch)</span></span>
<span data-ttu-id="8c63f-105">サービスの構成の複数の Xbox ユーザー Id には、バッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="8c63f-105">Creates a batch query on multiple Xbox user IDs for the service configuration.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8c63f-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="8c63f-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="8c63f-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="8c63f-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="8c63f-108">注釈</span><span class="sxs-lookup"><span data-stu-id="8c63f-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="8c63f-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8c63f-109">URI parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="8c63f-110">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="8c63f-110">Query string parameters</span></span>](#ID4EVB)
  * [<span data-ttu-id="8c63f-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="8c63f-111">HTTP status codes</span></span>](#ID4EGF)
  * [<span data-ttu-id="8c63f-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="8c63f-112">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="8c63f-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="8c63f-113">Response body</span></span>](#ID4EWF)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="8c63f-114">注釈</span><span class="sxs-lookup"><span data-stu-id="8c63f-114">Remarks</span></span>

<span data-ttu-id="8c63f-115">この HTTP/REST メソッドは、サービス構成の ID (SCID) レベルで複数の Xbox ユーザー Id のバッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="8c63f-115">This HTTP/REST method creates batch queries on multiple Xbox user IDs at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="8c63f-116">このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync**します。</span><span class="sxs-lookup"><span data-stu-id="8c63f-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync**.</span></span>

<span data-ttu-id="8c63f-117">2015 マルチ プレーヤーに結合できます多くのクエリを 1 回の呼び出しのすべてのクエリが同じ場合で表されるように Xbox に異なるユーザー Id (Xuid) を扱う、 *xuid*クエリ文字列パラメーター。</span><span class="sxs-lookup"><span data-stu-id="8c63f-117">For 2015 Multiplayer, you can combine many queries into a single call if all the queries are the same but dealing with different Xbox user IDs (XUIDs), as represented in the *xuid* query string parameter.</span></span> <span data-ttu-id="8c63f-118">クエリ文字列パラメーターと、応答は、通常のクエリとバッチ クエリと同じであるに注意してください。</span><span class="sxs-lookup"><span data-stu-id="8c63f-118">Note that the query string parameters, and the responses, are the same for regular queries and batch queries.</span></span>

<span data-ttu-id="8c63f-119">バッチ クエリの場合は、各 XUID に属しているセッションと同じ順序で応答に書き込まれます、 *xuid*パラメーターは、要求で表示されます。</span><span class="sxs-lookup"><span data-stu-id="8c63f-119">For a batch query, the sessions belonging to each XUID are written to the response in the same order as the *xuid* parameters are presented in the request.</span></span> <span data-ttu-id="8c63f-120">同じセッションごとに 1 回、応答で複数回を出現する可能性があります*xuid*これに一致します。</span><span class="sxs-lookup"><span data-stu-id="8c63f-120">It is possible for the same session to appear multiple times in the response, once for each *xuid* that it matches.</span></span>

<a id="ID4ELB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8c63f-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8c63f-121">URI parameters</span></span>

| <span data-ttu-id="8c63f-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8c63f-122">Parameter</span></span>| <span data-ttu-id="8c63f-123">種類</span><span class="sxs-lookup"><span data-stu-id="8c63f-123">Type</span></span>| <span data-ttu-id="8c63f-124">説明</span><span class="sxs-lookup"><span data-stu-id="8c63f-124">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="8c63f-125">scid</span><span class="sxs-lookup"><span data-stu-id="8c63f-125">scid</span></span>| <span data-ttu-id="8c63f-126">GUID</span><span class="sxs-lookup"><span data-stu-id="8c63f-126">GUID</span></span>| <span data-ttu-id="8c63f-127">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="8c63f-127">Service configuration identifier (SCID).</span></span> <span data-ttu-id="8c63f-128">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="8c63f-128">Part 1 of the session identifier.</span></span>|

<a id="ID4EVB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="8c63f-129">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="8c63f-129">Query string parameters</span></span>

<span data-ttu-id="8c63f-130">クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="8c63f-130">A query can be modified using the query string parameters in the next table.</span></span>

| <span data-ttu-id="8c63f-131"><b>パラメーター</b></span><span class="sxs-lookup"><span data-stu-id="8c63f-131"><b>Parameter</b></span></span>| <span data-ttu-id="8c63f-132"><b>型</b></span><span class="sxs-lookup"><span data-stu-id="8c63f-132"><b>Type</b></span></span>| <span data-ttu-id="8c63f-133"><b>説明</b></span><span class="sxs-lookup"><span data-stu-id="8c63f-133"><b>Description</b></span></span>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="8c63f-134">キーワード</span><span class="sxs-lookup"><span data-stu-id="8c63f-134">keyword</span></span>| <span data-ttu-id="8c63f-135">string</span><span class="sxs-lookup"><span data-stu-id="8c63f-135">string</span></span>| <span data-ttu-id="8c63f-136">キーワード、たとえば、"foo"と、a を取得する場合は、セッションまたはテンプレート内で検出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c63f-136">A keyword, for example, "foo", that must be found in sessions or templates if they are to be retrieved.</span></span> |
| <span data-ttu-id="8c63f-137">xuid</span><span class="sxs-lookup"><span data-stu-id="8c63f-137">xuid</span></span>| <span data-ttu-id="8c63f-138">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="8c63f-138">64-bit unsigned integer</span></span>| <span data-ttu-id="8c63f-139">Xbox ユーザー ID で、たとえば、「123」、セッション、クエリに含める。</span><span class="sxs-lookup"><span data-stu-id="8c63f-139">The Xbox user ID, for example, "123", for sessions to include in the query.</span></span> <span data-ttu-id="8c63f-140">既定では、ユーザーに含まれているセッションでアクティブにある必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c63f-140">By default, the user must be active in the session for it to be included.</span></span> |
| <span data-ttu-id="8c63f-141">予約</span><span class="sxs-lookup"><span data-stu-id="8c63f-141">reservations</span></span>| <span data-ttu-id="8c63f-142">boolean</span><span class="sxs-lookup"><span data-stu-id="8c63f-142">boolean</span></span>| <span data-ttu-id="8c63f-143">対象のセッションが含まれる場合は true、ユーザーは、予約済みのプレーヤーとして設定されますが、作業中のプレーヤーに参加していません。</span><span class="sxs-lookup"><span data-stu-id="8c63f-143">True to include sessions for which the user is set as a reserved player but has not joined to become an active player.</span></span> <span data-ttu-id="8c63f-144">このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。</span><span class="sxs-lookup"><span data-stu-id="8c63f-144">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="8c63f-145">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="8c63f-145">inactive</span></span>| <span data-ttu-id="8c63f-146">boolean</span><span class="sxs-lookup"><span data-stu-id="8c63f-146">boolean</span></span>| <span data-ttu-id="8c63f-147">ユーザーが受け入れたにもかかわらず再生されていないセッションは、true です。</span><span class="sxs-lookup"><span data-stu-id="8c63f-147">True to include sessions that the user has accepted but is not actively playing.</span></span> <span data-ttu-id="8c63f-148">セッションのユーザーが"ready"ですが「アクティブ」では、非アクティブとしてカウントします。</span><span class="sxs-lookup"><span data-stu-id="8c63f-148">Sessions in which the user is "ready" but not "active" count as inactive.</span></span> |
| <span data-ttu-id="8c63f-149">プライベート</span><span class="sxs-lookup"><span data-stu-id="8c63f-149">private</span></span>| <span data-ttu-id="8c63f-150">boolean</span><span class="sxs-lookup"><span data-stu-id="8c63f-150">boolean</span></span>| <span data-ttu-id="8c63f-151">プライベート セッションを含めるには true です。</span><span class="sxs-lookup"><span data-stu-id="8c63f-151">True to include private sessions.</span></span> <span data-ttu-id="8c63f-152">このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。</span><span class="sxs-lookup"><span data-stu-id="8c63f-152">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="8c63f-153">visibility</span><span class="sxs-lookup"><span data-stu-id="8c63f-153">visibility</span></span>| <span data-ttu-id="8c63f-154">string</span><span class="sxs-lookup"><span data-stu-id="8c63f-154">string</span></span>| <span data-ttu-id="8c63f-155">セッションの表示状態。</span><span class="sxs-lookup"><span data-stu-id="8c63f-155">Visibility state for the sessions.</span></span> <span data-ttu-id="8c63f-156">使用可能な値が定義されている、 <b>MultiplayerSessionVisibility</b>します。</span><span class="sxs-lookup"><span data-stu-id="8c63f-156">Possible values are defined by the <b>MultiplayerSessionVisibility</b>.</span></span> <span data-ttu-id="8c63f-157">このパラメーターが「開いている」に設定されている場合、クエリはのみ開いているセッションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c63f-157">If this parameter is set to "open", the query should include only open sessions.</span></span> <span data-ttu-id="8c63f-158">"Private"で、設定されている場合、<i>プライベート</i>パラメーターを設定する必要がありますを true にします。</span><span class="sxs-lookup"><span data-stu-id="8c63f-158">If it is set to "private", the <i>private</i> parameter must be set to true.</span></span> |
| <span data-ttu-id="8c63f-159">version</span><span class="sxs-lookup"><span data-stu-id="8c63f-159">version</span></span>| <span data-ttu-id="8c63f-160">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8c63f-160">32-bit signed integer</span></span>| <span data-ttu-id="8c63f-161">組み込む必要があるセッションの最大バージョン。</span><span class="sxs-lookup"><span data-stu-id="8c63f-161">The maximum session version that should be included.</span></span> <span data-ttu-id="8c63f-162">たとえば、2 の値が 2 の主要なセッションのバージョンでのみそのセッションを指定または小さい必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c63f-162">For example, a value of 2 specifies that only sessions with a major session version of 2 or less should be included.</span></span> <span data-ttu-id="8c63f-163">バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c63f-163">The version number must be less than or equal to the request's contract version mod 100.</span></span> |
| <span data-ttu-id="8c63f-164">Take</span><span class="sxs-lookup"><span data-stu-id="8c63f-164">take</span></span>| <span data-ttu-id="8c63f-165">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8c63f-165">32-bit signed integer</span></span>| <span data-ttu-id="8c63f-166">取得するセッションの最大数。</span><span class="sxs-lookup"><span data-stu-id="8c63f-166">The maximum number of sessions to retrieve.</span></span> <span data-ttu-id="8c63f-167">この数は、0 ~ 100 の範囲にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c63f-167">This number must be between 0 and 100.</span></span> |


<span data-ttu-id="8c63f-168">いずれかを設定*プライベート*または*予約*に true の場合、セッションにサーバー レベルのアクセスが必要です。</span><span class="sxs-lookup"><span data-stu-id="8c63f-168">Setting either *private* or *reservations* to true requires server-level access to the session.</span></span> <span data-ttu-id="8c63f-169">または、これらの設定では、呼び出し元の XUID 要求の URI に XUID フィルターに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8c63f-169">Alternatively, these settings require the caller's XUID claim to match the XUID filter in the URI.</span></span> <span data-ttu-id="8c63f-170">それ以外の場合、HTTP/403 状態コードが返されます、このようなすべてのセッションが実際に存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="8c63f-170">Otherwise, the HTTP/403 status code is returned, whether or not any such sessions actually exist.</span></span>

<a id="ID4EGF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="8c63f-171">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="8c63f-171">HTTP status codes</span></span>
<span data-ttu-id="8c63f-172">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="8c63f-172">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4ENF"></a>


## <a name="request-body"></a><span data-ttu-id="8c63f-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="8c63f-173">Request body</span></span>


```cpp
{ "xuids": [ "1234", "5678" ] }

```


<a id="ID4EWF"></a>


## <a name="response-body"></a><span data-ttu-id="8c63f-174">応答本文</span><span class="sxs-lookup"><span data-stu-id="8c63f-174">Response body</span></span>

<span data-ttu-id="8c63f-175">このメソッドからの戻り値は、いくつかのセッションに含まれるデータをインラインでのセッションの参照の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="8c63f-175">The return from this method is a JSON array of session references, with some session data included inline.</span></span>


```cpp
{
    "results": [ {
      "xuid": "9876",    // If the session was found from a xuid, that xuid.
      "startTime": "2009-06-15T13:45:30.0900000Z",
      "sessionRef": {
        "scid": "foo",
        "templateName": "bar",
        "name": "session-seven"
      },
      "accepted": 4,    // Approximate number of non-reserved members.
      "status": "active",    // or "reserved" or "inactive". This is the state of the user in the session, not the session itself. Only present if the session was found using a xuid.
      "visibility": "open",    // or "private", "visible", or "full"
      "joinRestriction": "local",    // or "followed". Only present if 'visibility' is "open" or "full" and the session has a join restriction.
      "myTurn": true,    // Not present is the same as 'false'. Only present if the session was found using a xuid.
      "keywords": [ "one", "two" ]
    }
  ]
}

```


<a id="ID4EDG"></a>


## <a name="see-also"></a><span data-ttu-id="8c63f-176">関連項目</span><span class="sxs-lookup"><span data-stu-id="8c63f-176">See also</span></span>

<a id="ID4EFG"></a>


##### <a name="parent"></a><span data-ttu-id="8c63f-177">Parent</span><span class="sxs-lookup"><span data-stu-id="8c63f-177">Parent</span></span>

[<span data-ttu-id="8c63f-178">/serviceconfigs/{scid}/batch</span><span class="sxs-lookup"><span data-stu-id="8c63f-178">/serviceconfigs/{scid}/batch</span></span>](uri-serviceconfigsscidbatch.md)
