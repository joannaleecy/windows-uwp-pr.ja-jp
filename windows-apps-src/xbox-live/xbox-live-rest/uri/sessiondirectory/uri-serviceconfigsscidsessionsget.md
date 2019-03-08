---
title: GET (/serviceconfigs/{scid}/sessions)
assetID: adc65d0b-58dd-bfb9-54c8-9bc9d02e68ec
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessionsget.html
description: " GET (/serviceconfigs/{scid}/sessions)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e54c9cd68a899cfd040bc3e16a05f6deb2daa7c3
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57614107"
---
# <a name="get-serviceconfigsscidsessions"></a><span data-ttu-id="f536f-104">GET (/serviceconfigs/{scid}/sessions)</span><span class="sxs-lookup"><span data-stu-id="f536f-104">GET (/serviceconfigs/{scid}/sessions)</span></span>
<span data-ttu-id="f536f-105">指定したセッションの情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="f536f-105">Retrieves specified session information.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="f536f-106">このメソッドには、X Xbl コントラクト バージョンのヘッダー要素が必要になりました。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="f536f-106">This method now requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="f536f-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f536f-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="f536f-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f536f-108">URI parameters</span></span>](#ID4EKB)
  * [<span data-ttu-id="f536f-109">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f536f-109">HTTP status codes</span></span>](#ID4EXB)
  * [<span data-ttu-id="f536f-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="f536f-110">Request body</span></span>](#ID4EAC)
  * [<span data-ttu-id="f536f-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="f536f-111">Response body</span></span>](#ID4ELC)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="f536f-112">注釈</span><span class="sxs-lookup"><span data-stu-id="f536f-112">Remarks</span></span>

<span data-ttu-id="f536f-113">この HTTP/REST メソッドでは、指定されたフィルターに関するセッション情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="f536f-113">This HTTP/REST method retrieves session information for the supplied filters.</span></span> <span data-ttu-id="f536f-114">このメソッドによってラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsAsync**します。</span><span class="sxs-lookup"><span data-stu-id="f536f-114">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsAsync**.</span></span>


> [!NOTE] 
> <span data-ttu-id="f536f-115">このメソッドを呼び出して 2015年マルチ プレーヤーの<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync</b>します。</span><span class="sxs-lookup"><span data-stu-id="f536f-115">For 2015 Multiplayer, this method is called by <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync</b>.</span></span>  



> [!NOTE] 
> <span data-ttu-id="f536f-116">このメソッドを呼び出すたびには、キーワード、Xbox ユーザー ID フィルター、またはその両方を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f536f-116">Every call to this method must include either a keyword, an Xbox user ID filter, or both.</span></span> <span data-ttu-id="f536f-117">呼び出し元がの適切なアクセス許可を持たない場合、<i>プライベート</i>と<i>予約</i>パラメーター、メソッドを返すエラー コード 403 Forbidden、実際には、このようなセッションが存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="f536f-117">If the caller does not have correct permissions for the <i>private</i> and <i>reservations</i> parameters, the method returns an error code of 403 Forbidden, whether or not any such sessions actually exist.</span></span>  


<a id="ID4EKB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="f536f-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f536f-118">URI parameters</span></span>

| <span data-ttu-id="f536f-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f536f-119">Parameter</span></span>| <span data-ttu-id="f536f-120">種類</span><span class="sxs-lookup"><span data-stu-id="f536f-120">Type</span></span>| <span data-ttu-id="f536f-121">説明</span><span class="sxs-lookup"><span data-stu-id="f536f-121">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="f536f-122">scid</span><span class="sxs-lookup"><span data-stu-id="f536f-122">scid</span></span>| <span data-ttu-id="f536f-123">GUID</span><span class="sxs-lookup"><span data-stu-id="f536f-123">GUID</span></span>| <span data-ttu-id="f536f-124">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="f536f-124">Service configuration identifier (SCID).</span></span> <span data-ttu-id="f536f-125">セッションの第 1 部 id。</span><span class="sxs-lookup"><span data-stu-id="f536f-125">Part 1 of the session ID.</span></span>|
| <span data-ttu-id="f536f-126">キーワード</span><span class="sxs-lookup"><span data-stu-id="f536f-126">keyword</span></span>| <span data-ttu-id="f536f-127">string</span><span class="sxs-lookup"><span data-stu-id="f536f-127">string</span></span>| <span data-ttu-id="f536f-128">結果文字列で識別されるだけでセッションをフィルター処理するために使用するキーワードです。</span><span class="sxs-lookup"><span data-stu-id="f536f-128">A keyword used to filter results to just sessions identified with that string.</span></span>|
| <span data-ttu-id="f536f-129">xuid</span><span class="sxs-lookup"><span data-stu-id="f536f-129">xuid</span></span>| <span data-ttu-id="f536f-130">GUID</span><span class="sxs-lookup"><span data-stu-id="f536f-130">GUID</span></span>| <span data-ttu-id="f536f-131">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="f536f-131">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="f536f-132">ユーザーは、セッションでアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="f536f-132">The users must be active in the sessions.</span></span>|
| <span data-ttu-id="f536f-133">予約</span><span class="sxs-lookup"><span data-stu-id="f536f-133">reservations</span></span>| <span data-ttu-id="f536f-134">string</span><span class="sxs-lookup"><span data-stu-id="f536f-134">string</span></span>| <span data-ttu-id="f536f-135">セッションの一覧が、ユーザー同意していないものも含まれますかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="f536f-135">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="f536f-136">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="f536f-136">This parameter can only be set to true.</span></span> <span data-ttu-id="f536f-137">この設定は、呼び出し元に、セッションにサーバー レベルのアクセスを要求または呼び出し元の XUID は Xbox のユーザー ID のフィルターに一致する要求。</span><span class="sxs-lookup"><span data-stu-id="f536f-137">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> |
| <span data-ttu-id="f536f-138">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="f536f-138">inactive</span></span>| <span data-ttu-id="f536f-139">string</span><span class="sxs-lookup"><span data-stu-id="f536f-139">string</span></span>| <span data-ttu-id="f536f-140">セッションの一覧が、ユーザーが承諾しましたが、積極的に再生しないものを含むかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="f536f-140">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="f536f-141">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="f536f-141">This parameter can only be set to true.</span></span>|
| <span data-ttu-id="f536f-142">プライベート</span><span class="sxs-lookup"><span data-stu-id="f536f-142">private</span></span>| <span data-ttu-id="f536f-143">string</span><span class="sxs-lookup"><span data-stu-id="f536f-143">string</span></span>| <span data-ttu-id="f536f-144">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="f536f-144">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="f536f-145">このパラメーターを設定することができますのみ true に設定します。</span><span class="sxs-lookup"><span data-stu-id="f536f-145">This parameter can only be set to true.</span></span> <span data-ttu-id="f536f-146">サーバーからサーバーを照会するときに、または自身のセッションのクエリを実行する場合にのみ有効です。</span><span class="sxs-lookup"><span data-stu-id="f536f-146">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="f536f-147">Xbox のユーザー ID のフィルターに一致する要求の呼び出し元の XUID または、呼び出し元に、セッションにサーバー レベルのアクセスを必要このパラメーターを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="f536f-147">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> |
| <span data-ttu-id="f536f-148">visibility</span><span class="sxs-lookup"><span data-stu-id="f536f-148">visibility</span></span>| <span data-ttu-id="f536f-149">string</span><span class="sxs-lookup"><span data-stu-id="f536f-149">string</span></span>| <span data-ttu-id="f536f-150">結果をフィルター処理で使用される表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="f536f-150">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="f536f-151">現在このパラメーターのみ設定できます開くを開いているセッションを含める。</span><span class="sxs-lookup"><span data-stu-id="f536f-151">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="f536f-152">参照してください<b>MultiplayerSessionVisibility</b>します。</span><span class="sxs-lookup"><span data-stu-id="f536f-152">See <b>MultiplayerSessionVisibility</b>.</span></span>|
| <span data-ttu-id="f536f-153">version</span><span class="sxs-lookup"><span data-stu-id="f536f-153">version</span></span>| <span data-ttu-id="f536f-154">string</span><span class="sxs-lookup"><span data-stu-id="f536f-154">string</span></span>| <span data-ttu-id="f536f-155">正の整数バージョンの主要なセッションまたはセッションの下位に含めます。</span><span class="sxs-lookup"><span data-stu-id="f536f-155">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="f536f-156">値は 100 剰余の要求のコントラクトのバージョン以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="f536f-156">The value must be less than or equal to the request's contract version modulo 100.</span></span>|
| <span data-ttu-id="f536f-157">Take</span><span class="sxs-lookup"><span data-stu-id="f536f-157">take</span></span>| <span data-ttu-id="f536f-158">string</span><span class="sxs-lookup"><span data-stu-id="f536f-158">string</span></span>| <span data-ttu-id="f536f-159">正の整数のセッションの最大数を取得します。</span><span class="sxs-lookup"><span data-stu-id="f536f-159">A positive integer indicating the maximum number of sessions to retrieve.</span></span>|

<a id="ID4EXB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="f536f-160">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f536f-160">HTTP status codes</span></span>
<span data-ttu-id="f536f-161">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="f536f-161">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EAC"></a>


## <a name="request-body"></a><span data-ttu-id="f536f-162">要求本文</span><span class="sxs-lookup"><span data-stu-id="f536f-162">Request body</span></span>

<span data-ttu-id="f536f-163">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="f536f-163">No objects are sent in the body of this request.</span></span>

<a id="ID4ELC"></a>


## <a name="response-body"></a><span data-ttu-id="f536f-164">応答本文</span><span class="sxs-lookup"><span data-stu-id="f536f-164">Response body</span></span>

<span data-ttu-id="f536f-165">このメソッドからの戻り値は、いくつかのセッションに含まれるデータをインラインでのセッションの参照の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="f536f-165">The return from this method is a JSON array of session references, with some session data included inline.</span></span>


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


<a id="ID4EWC"></a>


## <a name="see-also"></a><span data-ttu-id="f536f-166">関連項目</span><span class="sxs-lookup"><span data-stu-id="f536f-166">See also</span></span>

<a id="ID4EYC"></a>


##### <a name="parent"></a><span data-ttu-id="f536f-167">Parent</span><span class="sxs-lookup"><span data-stu-id="f536f-167">Parent</span></span>

[<span data-ttu-id="f536f-168">/serviceconfigs/{scid}/sessions</span><span class="sxs-lookup"><span data-stu-id="f536f-168">/serviceconfigs/{scid}/sessions</span></span>](uri-serviceconfigsscidsessions.md)
