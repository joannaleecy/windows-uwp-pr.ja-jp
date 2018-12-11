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
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8872250"
---
# <a name="post-serviceconfigsscidbatch"></a><span data-ttu-id="ab80d-104">POST (/serviceconfigs/{scid}/batch)</span><span class="sxs-lookup"><span data-stu-id="ab80d-104">POST (/serviceconfigs/{scid}/batch)</span></span>
<span data-ttu-id="ab80d-105">サービス構成の複数の Xbox ユーザー Id には、バッチ クエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab80d-105">Creates a batch query on multiple Xbox user IDs for the service configuration.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="ab80d-106">このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="ab80d-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="ab80d-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="ab80d-108">注釈</span><span class="sxs-lookup"><span data-stu-id="ab80d-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="ab80d-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab80d-109">URI parameters</span></span>](#ID4ELB)
  * [<span data-ttu-id="ab80d-110">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab80d-110">Query string parameters</span></span>](#ID4EVB)
  * [<span data-ttu-id="ab80d-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ab80d-111">HTTP status codes</span></span>](#ID4EGF)
  * [<span data-ttu-id="ab80d-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="ab80d-112">Request body</span></span>](#ID4ENF)
  * [<span data-ttu-id="ab80d-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="ab80d-113">Response body</span></span>](#ID4EWF)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="ab80d-114">注釈</span><span class="sxs-lookup"><span data-stu-id="ab80d-114">Remarks</span></span>

<span data-ttu-id="ab80d-115">この HTTP/REST メソッドは、サービス構成 ID (SCID) レベルで複数の Xbox ユーザー Id のバッチのクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="ab80d-115">This HTTP/REST method creates batch queries on multiple Xbox user IDs at the service configuration ID (SCID) level.</span></span> <span data-ttu-id="ab80d-116">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-116">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync**.</span></span>

<span data-ttu-id="ab80d-117">2015 マルチプレイヤーを組み合わせます多くのクエリを 1 つの呼び出しにすべてのクエリが同じ場合、 *xuid*クエリ文字列パラメーターで表される、さまざまな Xbox ユーザー Id (Xuid) を処理します。</span><span class="sxs-lookup"><span data-stu-id="ab80d-117">For 2015 Multiplayer, you can combine many queries into a single call if all the queries are the same but dealing with different Xbox user IDs (XUIDs), as represented in the *xuid* query string parameter.</span></span> <span data-ttu-id="ab80d-118">クエリ文字列パラメーターと、応答は、定期的なクエリおよびバッチ クエリの同じであるに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ab80d-118">Note that the query string parameters, and the responses, are the same for regular queries and batch queries.</span></span>

<span data-ttu-id="ab80d-119">バッチ クエリでは、各 XUID に属するセッションは*xuid*のパラメーターが要求に表示されるように同じ順序で応答に書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-119">For a batch query, the sessions belonging to each XUID are written to the response in the same order as the *xuid* parameters are presented in the request.</span></span> <span data-ttu-id="ab80d-120">同じセッションと一致する各*xuid*に 1 回、応答を複数回のことができます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-120">It is possible for the same session to appear multiple times in the response, once for each *xuid* that it matches.</span></span>

<a id="ID4ELB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="ab80d-121">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab80d-121">URI parameters</span></span>

| <span data-ttu-id="ab80d-122">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab80d-122">Parameter</span></span>| <span data-ttu-id="ab80d-123">型</span><span class="sxs-lookup"><span data-stu-id="ab80d-123">Type</span></span>| <span data-ttu-id="ab80d-124">説明</span><span class="sxs-lookup"><span data-stu-id="ab80d-124">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="ab80d-125">scid</span><span class="sxs-lookup"><span data-stu-id="ab80d-125">scid</span></span>| <span data-ttu-id="ab80d-126">GUID</span><span class="sxs-lookup"><span data-stu-id="ab80d-126">GUID</span></span>| <span data-ttu-id="ab80d-127">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="ab80d-127">Service configuration identifier (SCID).</span></span> <span data-ttu-id="ab80d-128">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="ab80d-128">Part 1 of the session identifier.</span></span>|

<a id="ID4EVB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="ab80d-129">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab80d-129">Query string parameters</span></span>

<span data-ttu-id="ab80d-130">クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-130">A query can be modified using the query string parameters in the next table.</span></span>

| <b><span data-ttu-id="ab80d-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ab80d-131">Parameter</span></span></b>| <b><span data-ttu-id="ab80d-132">型</span><span class="sxs-lookup"><span data-stu-id="ab80d-132">Type</span></span></b>| <b><span data-ttu-id="ab80d-133">説明</span><span class="sxs-lookup"><span data-stu-id="ab80d-133">Description</span></span></b>|
| --- | --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="ab80d-134">キーワード</span><span class="sxs-lookup"><span data-stu-id="ab80d-134">keyword</span></span>| <span data-ttu-id="ab80d-135">string</span><span class="sxs-lookup"><span data-stu-id="ab80d-135">string</span></span>| <span data-ttu-id="ab80d-136">キーワード、たとえば、"foo"にする必要がありますに記載されてセッションまたはテンプレートを取得する場合は、します。</span><span class="sxs-lookup"><span data-stu-id="ab80d-136">A keyword, for example, "foo", that must be found in sessions or templates if they are to be retrieved.</span></span> |
| <span data-ttu-id="ab80d-137">xuid</span><span class="sxs-lookup"><span data-stu-id="ab80d-137">xuid</span></span>| <span data-ttu-id="ab80d-138">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ab80d-138">64-bit unsigned integer</span></span>| <span data-ttu-id="ab80d-139">Xbox ユーザー ID で、たとえば、「123」、セッションをクエリに含めます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-139">The Xbox user ID, for example, "123", for sessions to include in the query.</span></span> <span data-ttu-id="ab80d-140">既定では、ユーザーに含まれているため、セッション内でアクティブにある必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab80d-140">By default, the user must be active in the session for it to be included.</span></span> |
| <span data-ttu-id="ab80d-141">予約</span><span class="sxs-lookup"><span data-stu-id="ab80d-141">reservations</span></span>| <span data-ttu-id="ab80d-142">boolean</span><span class="sxs-lookup"><span data-stu-id="ab80d-142">boolean</span></span>| <span data-ttu-id="ab80d-143">セッションが含まれる場合は true、ユーザーは、予約済みプレイヤーとして設定されますが、アクティブなプレイヤーが参加していません。</span><span class="sxs-lookup"><span data-stu-id="ab80d-143">True to include sessions for which the user is set as a reserved player but has not joined to become an active player.</span></span> <span data-ttu-id="ab80d-144">自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。</span><span class="sxs-lookup"><span data-stu-id="ab80d-144">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="ab80d-145">非アクティブです</span><span class="sxs-lookup"><span data-stu-id="ab80d-145">inactive</span></span>| <span data-ttu-id="ab80d-146">boolean</span><span class="sxs-lookup"><span data-stu-id="ab80d-146">boolean</span></span>| <span data-ttu-id="ab80d-147">True に、ユーザーが受け入れたがアクティブに再生されていないセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-147">True to include sessions that the user has accepted but is not actively playing.</span></span> <span data-ttu-id="ab80d-148">セッションのユーザーが「準備完了」ですが「アクティブ」では、非アクティブとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-148">Sessions in which the user is "ready" but not "active" count as inactive.</span></span> |
| <span data-ttu-id="ab80d-149">プライベート</span><span class="sxs-lookup"><span data-stu-id="ab80d-149">private</span></span>| <span data-ttu-id="ab80d-150">boolean</span><span class="sxs-lookup"><span data-stu-id="ab80d-150">boolean</span></span>| <span data-ttu-id="ab80d-151">プライベート セッションを含める場合は true。</span><span class="sxs-lookup"><span data-stu-id="ab80d-151">True to include private sessions.</span></span> <span data-ttu-id="ab80d-152">自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。</span><span class="sxs-lookup"><span data-stu-id="ab80d-152">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="ab80d-153">visibility</span><span class="sxs-lookup"><span data-stu-id="ab80d-153">visibility</span></span>| <span data-ttu-id="ab80d-154">string</span><span class="sxs-lookup"><span data-stu-id="ab80d-154">string</span></span>| <span data-ttu-id="ab80d-155">セッションの可視性の状態。</span><span class="sxs-lookup"><span data-stu-id="ab80d-155">Visibility state for the sessions.</span></span> <span data-ttu-id="ab80d-156">使用可能な値は、 <b>MultiplayerSessionVisibility</b>によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="ab80d-156">Possible values are defined by the <b>MultiplayerSessionVisibility</b>.</span></span> <span data-ttu-id="ab80d-157">このパラメーターは、「開く」に設定されている場合、クエリが開いている唯一のセッションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab80d-157">If this parameter is set to "open", the query should include only open sessions.</span></span> <span data-ttu-id="ab80d-158"><i>プライベート</i>のパラメーターを設定する必要があります「プライベート」に設定されている場合を true に設定します。</span><span class="sxs-lookup"><span data-stu-id="ab80d-158">If it is set to "private", the <i>private</i> parameter must be set to true.</span></span> |
| <span data-ttu-id="ab80d-159">version</span><span class="sxs-lookup"><span data-stu-id="ab80d-159">version</span></span>| <span data-ttu-id="ab80d-160">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="ab80d-160">32-bit signed integer</span></span>| <span data-ttu-id="ab80d-161">セッションの最大バージョンが含まれている場合があります。</span><span class="sxs-lookup"><span data-stu-id="ab80d-161">The maximum session version that should be included.</span></span> <span data-ttu-id="ab80d-162">たとえば、2 の値は、2 の主なセッションのバージョンでのみそのセッションを指定します。 または含まれている小さい必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab80d-162">For example, a value of 2 specifies that only sessions with a major session version of 2 or less should be included.</span></span> <span data-ttu-id="ab80d-163">バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab80d-163">The version number must be less than or equal to the request's contract version mod 100.</span></span> |
| <span data-ttu-id="ab80d-164">アプリ</span><span class="sxs-lookup"><span data-stu-id="ab80d-164">take</span></span>| <span data-ttu-id="ab80d-165">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="ab80d-165">32-bit signed integer</span></span>| <span data-ttu-id="ab80d-166">取得するセッションの最大数。</span><span class="sxs-lookup"><span data-stu-id="ab80d-166">The maximum number of sessions to retrieve.</span></span> <span data-ttu-id="ab80d-167">この数は 0 ~ 100 の間にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab80d-167">This number must be between 0 and 100.</span></span> |


<span data-ttu-id="ab80d-168">*プライベート*または*予約*のいずれかを true に設定するには、セッションへのサーバー レベルのアクセスが必要です。</span><span class="sxs-lookup"><span data-stu-id="ab80d-168">Setting either *private* or *reservations* to true requires server-level access to the session.</span></span> <span data-ttu-id="ab80d-169">代わりに、これらの設定では、呼び出し元の XUID を要求 URI の XUID フィルターに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ab80d-169">Alternatively, these settings require the caller's XUID claim to match the XUID filter in the URI.</span></span> <span data-ttu-id="ab80d-170">それ以外の場合、/403 HTTP ステータス コードが返されます、そのようなセッションが実際に存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="ab80d-170">Otherwise, the HTTP/403 status code is returned, whether or not any such sessions actually exist.</span></span>

<a id="ID4EGF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="ab80d-171">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ab80d-171">HTTP status codes</span></span>
<span data-ttu-id="ab80d-172">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="ab80d-172">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4ENF"></a>


## <a name="request-body"></a><span data-ttu-id="ab80d-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="ab80d-173">Request body</span></span>


```cpp
{ "xuids": [ "1234", "5678" ] }

```


<a id="ID4EWF"></a>


## <a name="response-body"></a><span data-ttu-id="ab80d-174">応答本文</span><span class="sxs-lookup"><span data-stu-id="ab80d-174">Response body</span></span>

<span data-ttu-id="ab80d-175">このメソッドからの戻り値は、いくつかのセッション データが含まれているインラインでのセッション参照の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="ab80d-175">The return from this method is a JSON array of session references, with some session data included inline.</span></span>


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


## <a name="see-also"></a><span data-ttu-id="ab80d-176">関連項目</span><span class="sxs-lookup"><span data-stu-id="ab80d-176">See also</span></span>

<a id="ID4EFG"></a>


##### <a name="parent"></a><span data-ttu-id="ab80d-177">Parent</span><span class="sxs-lookup"><span data-stu-id="ab80d-177">Parent</span></span>

[<span data-ttu-id="ab80d-178">/serviceconfigs/{scid}/batch</span><span class="sxs-lookup"><span data-stu-id="ab80d-178">/serviceconfigs/{scid}/batch</span></span>](uri-serviceconfigsscidbatch.md)
