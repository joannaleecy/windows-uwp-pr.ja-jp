---
title: POST (/handles/query?include=relatedInfo)
assetID: 66ecd1fe-24d4-4cd5-256d-8950ac658529
permalink: en-us/docs/xboxlive/rest/uri-handlesqueryincludepost.html
author: KevinAsgari
description: " POST (/handles/query?include=relatedInfo)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2caffd029e5b5c79eb411678621643a48f65e1f1
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7572808"
---
# <a name="post-handlesqueryincluderelatedinfo"></a><span data-ttu-id="8dd0e-104">POST (/handles/query?include=relatedInfo)</span><span class="sxs-lookup"><span data-stu-id="8dd0e-104">POST (/handles/query?include=relatedInfo)</span></span>
<span data-ttu-id="8dd0e-105">関連するセッションの情報が含まれるセッション ハンドルに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-105">Creates queries for session handles that include related session information.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8dd0e-106">このメソッドは、2015年マルチプレイヤーで使用し、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="8dd0e-107">テンプレート コントラクト 104/105 以降で使用するものであり、X Xbl コントラクト バージョンのヘッダーの要素が必要です: 104/105 または後ですべての要求します。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="8dd0e-108">注釈</span><span class="sxs-lookup"><span data-stu-id="8dd0e-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="8dd0e-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8dd0e-109">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="8dd0e-110">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="8dd0e-110">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="8dd0e-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8dd0e-111">HTTP status codes</span></span>](#ID4EAF)
  * [<span data-ttu-id="8dd0e-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="8dd0e-112">Request body</span></span>](#ID4EHF)
  * [<span data-ttu-id="8dd0e-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="8dd0e-113">Response body</span></span>](#ID4EZF)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="8dd0e-114">注釈</span><span class="sxs-lookup"><span data-stu-id="8dd0e-114">Remarks</span></span>

<span data-ttu-id="8dd0e-115">この HTTP/REST メソッドは、「含める」のクエリ文字列で指定されたセッション情報を使って、データのハンドルに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-115">This HTTP/REST method creates queries for handle data with session information specified in the "include" query string.</span></span> <span data-ttu-id="8dd0e-116">クエリ文字列値はコンマで区切られたリストなどのサポート、今後のクエリ オプションをサポートするために拡張できるように設計されています"? 含める = relatedInfo、セッション"。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-116">The query string value is designed to be extensible to support future query options, supporting a comma-delimited list, for example, "?include=relatedInfo,session".</span></span> <span data-ttu-id="8dd0e-117">POST メソッドは、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForUsersAsync**でラップすることができます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-117">The POST method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForUsersAsync**.</span></span>

<span data-ttu-id="8dd0e-118">このメソッドの要求本文で型フィールドは、「アクティビティ」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-118">The type field in the request body for this method must be set to "activity".</span></span> <span data-ttu-id="8dd0e-119">応答本文内の項目は、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**のプロパティに直接マップされます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-119">The items in the response body map directly to the properties of the **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="8dd0e-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="8dd0e-120">URI parameters</span></span>

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="8dd0e-121">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="8dd0e-121">Query string parameters</span></span>

<span data-ttu-id="8dd0e-122">クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-122">A query can be modified using the query string parameters in the next table.</span></span>

| <b><span data-ttu-id="8dd0e-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="8dd0e-123">Parameter</span></span></b>| <b><span data-ttu-id="8dd0e-124">型</span><span class="sxs-lookup"><span data-stu-id="8dd0e-124">Type</span></span></b>| <b><span data-ttu-id="8dd0e-125">説明</span><span class="sxs-lookup"><span data-stu-id="8dd0e-125">Description</span></span></b>|
| --- | --- | --- | --- |
| <span data-ttu-id="8dd0e-126">キーワード</span><span class="sxs-lookup"><span data-stu-id="8dd0e-126">keyword</span></span>| <span data-ttu-id="8dd0e-127">string</span><span class="sxs-lookup"><span data-stu-id="8dd0e-127">string</span></span>| <span data-ttu-id="8dd0e-128">キーワード、たとえば、"foo"を取得する場合は、セッションまたはテンプレートに含まれてする必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-128">A keyword, for example, "foo", that must be found in sessions or templates if they are to be retrieved.</span></span> |
| <span data-ttu-id="8dd0e-129">xuid</span><span class="sxs-lookup"><span data-stu-id="8dd0e-129">xuid</span></span>| <span data-ttu-id="8dd0e-130">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="8dd0e-130">64-bit unsigned integer</span></span>| <span data-ttu-id="8dd0e-131">Xbox ユーザー ID で、たとえば、「123」、セッションをクエリに含めます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-131">The Xbox user ID, for example, "123", for sessions to include in the query.</span></span> <span data-ttu-id="8dd0e-132">既定では、ユーザーに含まれているため、セッション内でアクティブにある必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-132">By default, the user must be active in the session for it to be included.</span></span> |
| <span data-ttu-id="8dd0e-133">予約</span><span class="sxs-lookup"><span data-stu-id="8dd0e-133">reservations</span></span>| <span data-ttu-id="8dd0e-134">boolean</span><span class="sxs-lookup"><span data-stu-id="8dd0e-134">boolean</span></span>| <span data-ttu-id="8dd0e-135">セッションが含まれる場合は true、ユーザーは、予約済みプレイヤーとして設定されますが、アクティブなプレイヤーが参加していません。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-135">True to include sessions for which the user is set as a reserved player but has not joined to become an active player.</span></span> <span data-ttu-id="8dd0e-136">自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-136">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="8dd0e-137">非アクティブです</span><span class="sxs-lookup"><span data-stu-id="8dd0e-137">inactive</span></span>| <span data-ttu-id="8dd0e-138">boolean</span><span class="sxs-lookup"><span data-stu-id="8dd0e-138">boolean</span></span>| <span data-ttu-id="8dd0e-139">ユーザーが受け入れたがアクティブにプレイしていないセッションを 場合は true。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-139">True to include sessions that the user has accepted but is not actively playing.</span></span> <span data-ttu-id="8dd0e-140">セッションのユーザーが「準備完了」ですが「アクティブ」では、非アクティブとしてカウントされます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-140">Sessions in which the user is "ready" but not "active" count as inactive.</span></span> |
| <span data-ttu-id="8dd0e-141">プライベート</span><span class="sxs-lookup"><span data-stu-id="8dd0e-141">private</span></span>| <span data-ttu-id="8dd0e-142">boolean</span><span class="sxs-lookup"><span data-stu-id="8dd0e-142">boolean</span></span>| <span data-ttu-id="8dd0e-143">プライベート セッションを含める場合は true。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-143">True to include private sessions.</span></span> <span data-ttu-id="8dd0e-144">自分のセッションをクエリするとき、または特定のユーザーのセッションのサーバーを照会すると、このパラメーターは使用のみ。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-144">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="8dd0e-145">visibility</span><span class="sxs-lookup"><span data-stu-id="8dd0e-145">visibility</span></span>| <span data-ttu-id="8dd0e-146">string</span><span class="sxs-lookup"><span data-stu-id="8dd0e-146">string</span></span>| <span data-ttu-id="8dd0e-147">セッションの可視性の状態。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-147">Visibility state for the sessions.</span></span> <span data-ttu-id="8dd0e-148">設定可能な値は、 <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>によって定義されます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-148">Possible values are defined by the <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>.</span></span> <span data-ttu-id="8dd0e-149">このパラメーターは、「開く」に設定されている場合、クエリが開いている唯一のセッションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-149">If this parameter is set to "open", the query should include only open sessions.</span></span> <span data-ttu-id="8dd0e-150"><i>プライベート</i>のパラメーターを設定する必要があります「プライベート」に設定されている場合を true に設定します。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-150">If it is set to "private", the <i>private</i> parameter must be set to true.</span></span> |
| <span data-ttu-id="8dd0e-151">version</span><span class="sxs-lookup"><span data-stu-id="8dd0e-151">version</span></span>| <span data-ttu-id="8dd0e-152">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8dd0e-152">32-bit signed integer</span></span>| <span data-ttu-id="8dd0e-153">セッションの最大バージョンが含まれている場合があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-153">The maximum session version that should be included.</span></span> <span data-ttu-id="8dd0e-154">たとえば、2 の値は、2 の主なセッションのバージョンでのみそのセッションを指定します。 または含まれている小さい必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-154">For example, a value of 2 specifies that only sessions with a major session version of 2 or less should be included.</span></span> <span data-ttu-id="8dd0e-155">バージョン番号は、要求のコントラクト バージョン mod 100 以内である必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-155">The version number must be less than or equal to the request's contract version mod 100.</span></span> |
| <span data-ttu-id="8dd0e-156">アプリでは</span><span class="sxs-lookup"><span data-stu-id="8dd0e-156">take</span></span>| <span data-ttu-id="8dd0e-157">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8dd0e-157">32-bit signed integer</span></span>| <span data-ttu-id="8dd0e-158">取得するセッションの最大数。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-158">The maximum number of sessions to retrieve.</span></span> <span data-ttu-id="8dd0e-159">この数は、0 ~ 100 の間にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-159">This number must be between 0 and 100.</span></span> |


<span data-ttu-id="8dd0e-160">*プライベート*または*予約*のいずれかを true に設定するには、セッションにサーバー レベルのアクセスが必要です。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-160">Setting either *private* or *reservations* to true requires server-level access to the session.</span></span> <span data-ttu-id="8dd0e-161">代わりに、これらの設定では、呼び出し元の XUID を要求 URI の XUID フィルターに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-161">Alternatively, these settings require the caller's XUID claim to match the XUID filter in the URI.</span></span> <span data-ttu-id="8dd0e-162">それ以外の場合、/403 HTTP ステータス コードが返されます、そのようなセッションが実際に存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-162">Otherwise, the HTTP/403 status code is returned, whether or not any such sessions actually exist.</span></span>

<a id="ID4EAF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="8dd0e-163">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="8dd0e-163">HTTP status codes</span></span>
<span data-ttu-id="8dd0e-164">サービスは、MPSD に適用される HTTP ステータス コードを返します。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-164">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EHF"></a>


## <a name="request-body"></a><span data-ttu-id="8dd0e-165">要求本文</span><span class="sxs-lookup"><span data-stu-id="8dd0e-165">Request body</span></span>

<a id="ID4ENF"></a>


### <a name="sample-request"></a><span data-ttu-id="8dd0e-166">要求の例</span><span class="sxs-lookup"><span data-stu-id="8dd0e-166">Sample request</span></span>

<span data-ttu-id="8dd0e-167">ユーザーの「お気に入り」のソーシャル グラフのすべてのアクティビティを取得するには、次のような POST 本文。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-167">To get all activities for a user's "favorites" social graph, the POST body looks like this:</span></span>


```cpp
{
  "type": "activity",
  "scid": "B5B1F71F-A328-4371-89E0-C3AD222D0E92"  // optional filter on scid
  "owners": {
     "people": {
       "moniker": "favorites",
       "monikerXuid": "3210"
     }
  }
}

```


<a id="ID4EZF"></a>


## <a name="response-body"></a><span data-ttu-id="8dd0e-168">応答本文</span><span class="sxs-lookup"><span data-stu-id="8dd0e-168">Response body</span></span>

<span data-ttu-id="8dd0e-169">結果は、各ハンドルに埋め込まれている一意の id、ハンドルの構造体の配列として返されます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-169">The results are returned as an array of handle structures, with a unique ID embedded in each handle.</span></span> <span data-ttu-id="8dd0e-170">**RelatedInfo**オブジェクトでは、特定のセッションの情報が返されます。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-170">The specific session information is returned in the **relatedInfo** object.</span></span> <span data-ttu-id="8dd0e-171">この情報は返されません正規の POST メソッドでこの URI に注意してください。</span><span class="sxs-lookup"><span data-stu-id="8dd0e-171">Note that this information is not returned for the regular POST method on this URI.</span></span>

<a id="ID4EDG"></a>


### <a name="sample-response"></a><span data-ttu-id="8dd0e-172">応答の例</span><span class="sxs-lookup"><span data-stu-id="8dd0e-172">Sample response</span></span>


```cpp
{
    "results": [{
        "id": "11111111-ebe0-42da-885f-033860a818f6",
        "type": "activity",
        "version": 1,
        "sessionRef": {
            "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
            "templateName": "party",
            "name": "e3a836aeac6f4cbe9bcab985494d3175"
        },

    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
        "relatedInfo": {
            "visibility": "open",
            "joinRestriction": "followed",
            "closed": true,
            "maxMembersCount": 8,
            "membersCount": 4,
        }
    },
    {
        "id": "11111111-ebe0-42da-885f-033860a818f7",
        "type": "activity",
        "version": 1,
        "sessionRef": {
            "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
            "templateName": "TitleStorageTestDefault",
            "name": "795fcaa7-8377-4281-bd7e-e86c12843632"
        },
    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
        "relatedInfo": {
            "visibility": "open",
            "joinRestriction": "followed",
            "closed": false,
            "maxMembersCount": 8,
            "membersCount": 4,
        }
    }]
}

```


<a id="ID4ENG"></a>


## <a name="see-also"></a><span data-ttu-id="8dd0e-173">関連項目</span><span class="sxs-lookup"><span data-stu-id="8dd0e-173">See also</span></span>

<a id="ID4EPG"></a>


##### <a name="parent"></a><span data-ttu-id="8dd0e-174">Parent</span><span class="sxs-lookup"><span data-stu-id="8dd0e-174">Parent</span></span>

[<span data-ttu-id="8dd0e-175">/handles/query</span><span class="sxs-lookup"><span data-stu-id="8dd0e-175">/handles/query</span></span>](uri-handlesquery.md)
