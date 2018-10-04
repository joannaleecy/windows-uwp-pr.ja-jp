---
title: GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)
assetID: 9daac964-0b25-3430-fcfd-0f8658aceee1
permalink: en-us/docs/xboxlive/rest/uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessionsget.html
author: KevinAsgari
description: " GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 06d0ad33d258962c4f2ad9f48da7425ab462e473
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4317401"
---
# <a name="get-serviceconfigsscidsessiontemplatessessiontemplatenamesessions"></a><span data-ttu-id="2e915-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span><span class="sxs-lookup"><span data-stu-id="2e915-104">GET (/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions)</span></span>
<span data-ttu-id="2e915-105">セッション テンプレートのドキュメントを取得します。</span><span class="sxs-lookup"><span data-stu-id="2e915-105">Retrieves session template documents.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="2e915-106">この URI メソッドには、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="2e915-106">This URI method requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="2e915-107">注釈</span><span class="sxs-lookup"><span data-stu-id="2e915-107">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="2e915-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e915-108">URI parameters</span></span>](#ID4EKB)
  * [<span data-ttu-id="2e915-109">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="2e915-109">HTTP status codes</span></span>](#ID4EXB)
  * [<span data-ttu-id="2e915-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="2e915-110">Request body</span></span>](#ID4EAC)
  * [<span data-ttu-id="2e915-111">応答本文</span><span class="sxs-lookup"><span data-stu-id="2e915-111">Response body</span></span>](#ID4EKC)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="2e915-112">注釈</span><span class="sxs-lookup"><span data-stu-id="2e915-112">Remarks</span></span>

<span data-ttu-id="2e915-113">この HTTP/REST メソッドは、指定されたフィルターのセッション テンプレートの情報を取得します。</span><span class="sxs-lookup"><span data-stu-id="2e915-113">This HTTP/REST method retrieves session template information for the supplied filters.</span></span> <span data-ttu-id="2e915-114">このメソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="2e915-114">This method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsAsync**.</span></span>


> [!NOTE] 
> <span data-ttu-id="2e915-115">2015 マルチプレイヤーでは、このメソッドは<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync</b>によって呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="2e915-115">For 2015 Multiplayer, this method is called by <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetSessionsForUsersFilterAsync</b>.</span></span>  



> [!NOTE] 
> <span data-ttu-id="2e915-116">このメソッドを呼び出すたびには、キーワード、Xbox ユーザー ID のフィルター、またはその両方を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="2e915-116">Every call to this method must include either a keyword, an Xbox user ID filter, or both.</span></span> <span data-ttu-id="2e915-117">呼び出し元が、<i>プライベート</i>と<i>予約</i>のパラメーターの適切なアクセス許可を持たない場合、このメソッドは、そのようなセッションが実際に存在するかどうか 403 Forbidden のエラー コードを返します。</span><span class="sxs-lookup"><span data-stu-id="2e915-117">If the caller does not have correct permissions for the <i>private</i> and <i>reservations</i> parameters, the method returns an error code of 403 Forbidden, whether or not any such sessions actually exist.</span></span>  


<a id="ID4EKB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="2e915-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e915-118">URI parameters</span></span>

| <span data-ttu-id="2e915-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2e915-119">Parameter</span></span>| <span data-ttu-id="2e915-120">型</span><span class="sxs-lookup"><span data-stu-id="2e915-120">Type</span></span>| <span data-ttu-id="2e915-121">説明</span><span class="sxs-lookup"><span data-stu-id="2e915-121">Description</span></span>|
| --- | --- | --- | --- | --- | --- |
| <span data-ttu-id="2e915-122">scid</span><span class="sxs-lookup"><span data-stu-id="2e915-122">scid</span></span>| <span data-ttu-id="2e915-123">GUID</span><span class="sxs-lookup"><span data-stu-id="2e915-123">GUID</span></span>| <span data-ttu-id="2e915-124">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="2e915-124">Service configuration identifier (SCID).</span></span> <span data-ttu-id="2e915-125">パート 1 セッションの id。</span><span class="sxs-lookup"><span data-stu-id="2e915-125">Part 1 of the session ID.</span></span>|
| <span data-ttu-id="2e915-126">キーワード</span><span class="sxs-lookup"><span data-stu-id="2e915-126">keyword</span></span>| <span data-ttu-id="2e915-127">string</span><span class="sxs-lookup"><span data-stu-id="2e915-127">string</span></span>| <span data-ttu-id="2e915-128">キーワードで文字列を識別するだけでセッションに結果をフィルター処理するために使用します。</span><span class="sxs-lookup"><span data-stu-id="2e915-128">A keyword used to filter results to just sessions identified with that string.</span></span>|
| <span data-ttu-id="2e915-129">xuid</span><span class="sxs-lookup"><span data-stu-id="2e915-129">xuid</span></span>| <span data-ttu-id="2e915-130">GUID</span><span class="sxs-lookup"><span data-stu-id="2e915-130">GUID</span></span>| <span data-ttu-id="2e915-131">セッションを取得する対象のユーザーの Xbox ユーザー Id。</span><span class="sxs-lookup"><span data-stu-id="2e915-131">Xbox user IDs for the users for whom to retrieve sessions.</span></span> <span data-ttu-id="2e915-132">ユーザーは、セッション内でアクティブである必要があります。</span><span class="sxs-lookup"><span data-stu-id="2e915-132">The users must be active in the sessions.</span></span> |
| <span data-ttu-id="2e915-133">予約</span><span class="sxs-lookup"><span data-stu-id="2e915-133">reservations</span></span>| <span data-ttu-id="2e915-134">string</span><span class="sxs-lookup"><span data-stu-id="2e915-134">string</span></span>| <span data-ttu-id="2e915-135">示す値をユーザーが持っていないセッションのリストが含まれている場合は受け入れ。</span><span class="sxs-lookup"><span data-stu-id="2e915-135">Value indicating if the list of sessions includes those that the users have not accepted.</span></span> <span data-ttu-id="2e915-136">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="2e915-136">This parameter can only be set to true.</span></span> <span data-ttu-id="2e915-137">この設定は、呼び出し元が、セッションにサーバー レベルのアクセスを必要と、または Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="2e915-137">This setting requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> |
| <span data-ttu-id="2e915-138">非アクティブです</span><span class="sxs-lookup"><span data-stu-id="2e915-138">inactive</span></span>| <span data-ttu-id="2e915-139">string</span><span class="sxs-lookup"><span data-stu-id="2e915-139">string</span></span>| <span data-ttu-id="2e915-140">セッションの一覧を含むをユーザーが受け入れられますがアクティブにプレイしていないかどうかを示す値。</span><span class="sxs-lookup"><span data-stu-id="2e915-140">Value indicating if the list of sessions includes those that the users have accepted but are not actively playing.</span></span> <span data-ttu-id="2e915-141">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="2e915-141">This parameter can only be set to true.</span></span> |
| <span data-ttu-id="2e915-142">プライベート</span><span class="sxs-lookup"><span data-stu-id="2e915-142">private</span></span>| <span data-ttu-id="2e915-143">string</span><span class="sxs-lookup"><span data-stu-id="2e915-143">string</span></span>| <span data-ttu-id="2e915-144">プライベート セッション、セッションの一覧を示す値。</span><span class="sxs-lookup"><span data-stu-id="2e915-144">Value indicating if the list of sessions includes private sessions.</span></span> <span data-ttu-id="2e915-145">このパラメーターを設定することのみを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="2e915-145">This parameter can only be set to true.</span></span> <span data-ttu-id="2e915-146">独自のセッションをクエリするときにのみ、またはサーバー間を照会すると、無効です。</span><span class="sxs-lookup"><span data-stu-id="2e915-146">It is valid only when querying your own sessions, or when querying server-to-server.</span></span> <span data-ttu-id="2e915-147">このパラメーターを true に設定、呼び出し元が、セッションにサーバー レベルのアクセスを必要とまたは Xbox ユーザー ID フィルターに一致するように、呼び出し元の XUID を要求します。</span><span class="sxs-lookup"><span data-stu-id="2e915-147">Setting this parameter to true requires the caller to have server-level access to the session, or the caller's XUID claim to match the Xbox user ID filter.</span></span> |
| <span data-ttu-id="2e915-148">visibility</span><span class="sxs-lookup"><span data-stu-id="2e915-148">visibility</span></span>| <span data-ttu-id="2e915-149">string</span><span class="sxs-lookup"><span data-stu-id="2e915-149">string</span></span>| <span data-ttu-id="2e915-150">結果のフィルタ リングで使われる表示状態を示す列挙値。</span><span class="sxs-lookup"><span data-stu-id="2e915-150">An enumeration value indicating visibility status used in filtering results.</span></span> <span data-ttu-id="2e915-151">現在このパラメーターのみに設定できます開くを開いているセッションを含めます。</span><span class="sxs-lookup"><span data-stu-id="2e915-151">Currently this parameter can only be set to Open to include open sessions.</span></span> <span data-ttu-id="2e915-152"><b>MultiplayerSessionVisibility</b>を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2e915-152">See <b>MultiplayerSessionVisibility</b>.</span></span> |
| <span data-ttu-id="2e915-153">version</span><span class="sxs-lookup"><span data-stu-id="2e915-153">version</span></span>| <span data-ttu-id="2e915-154">string</span><span class="sxs-lookup"><span data-stu-id="2e915-154">string</span></span>| <span data-ttu-id="2e915-155">正の整数セッションのメジャー バージョンまたはセッションの低下を示すが含まれます。</span><span class="sxs-lookup"><span data-stu-id="2e915-155">A positive integer indicating the major session version or lower of the sessions to include.</span></span> <span data-ttu-id="2e915-156">値は 100 モジュロ要求のコントラクト バージョン以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="2e915-156">The value must be less than or equal to the request's contract version modulo 100.</span></span> |
| <span data-ttu-id="2e915-157">アプリでは</span><span class="sxs-lookup"><span data-stu-id="2e915-157">take</span></span>| <span data-ttu-id="2e915-158">string</span><span class="sxs-lookup"><span data-stu-id="2e915-158">string</span></span>| <span data-ttu-id="2e915-159">正の整数セッションの最大数を示すを取得します。</span><span class="sxs-lookup"><span data-stu-id="2e915-159">A positive integer indicating the maximum number of sessions to retrieve.</span></span>|

<a id="ID4EXB"></a>


## <a name="http-status-codes"></a><span data-ttu-id="2e915-160">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="2e915-160">HTTP status codes</span></span>
<span data-ttu-id="2e915-161">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="2e915-161">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EAC"></a>


## <a name="request-body"></a><span data-ttu-id="2e915-162">要求本文</span><span class="sxs-lookup"><span data-stu-id="2e915-162">Request body</span></span>

<span data-ttu-id="2e915-163">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="2e915-163">No objects are sent in the body of this request.</span></span>

<a id="ID4EKC"></a>


## <a name="response-body"></a><span data-ttu-id="2e915-164">応答本文</span><span class="sxs-lookup"><span data-stu-id="2e915-164">Response body</span></span>

<span data-ttu-id="2e915-165">このメソッドからの戻り値は、いくつかのセッション データが含まれているインラインでのセッション参照の JSON 配列です。</span><span class="sxs-lookup"><span data-stu-id="2e915-165">The return from this method is a JSON array of session references, with some session data included inline.</span></span>


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


<a id="ID4EUC"></a>


## <a name="see-also"></a><span data-ttu-id="2e915-166">関連項目</span><span class="sxs-lookup"><span data-stu-id="2e915-166">See also</span></span>

<a id="ID4EWC"></a>


##### <a name="parent"></a><span data-ttu-id="2e915-167">Parent</span><span class="sxs-lookup"><span data-stu-id="2e915-167">Parent</span></span>

[<span data-ttu-id="2e915-168">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span><span class="sxs-lookup"><span data-stu-id="2e915-168">/serviceconfigs/{scid}/sessiontemplates/{sessionTemplateName}/sessions</span></span>](uri-serviceconfigsscidsessiontemplatessessiontemplatenamesessions.md)
