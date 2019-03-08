---
title: POST (/handles/query?include=relatedInfo)
assetID: 66ecd1fe-24d4-4cd5-256d-8950ac658529
permalink: en-us/docs/xboxlive/rest/uri-handlesqueryincludepost.html
description: " POST (/handles/query?include=relatedInfo)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eb30561c91a085902dd9d79b6c4a2045dc709bfb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632557"
---
# <a name="post-handlesqueryincluderelatedinfo"></a><span data-ttu-id="653c1-104">POST (/handles/query?include=relatedInfo)</span><span class="sxs-lookup"><span data-stu-id="653c1-104">POST (/handles/query?include=relatedInfo)</span></span>
<span data-ttu-id="653c1-105">関連するセッションの情報を含むセッション ハンドルのクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="653c1-105">Creates queries for session handles that include related session information.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="653c1-106">このメソッドは、2015年マルチ プレーヤーを使用し、以降そのマルチ プレーヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="653c1-106">This method is used by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="653c1-107">104/105 またはそれ以降、テンプレートのコントラクトで使用され、X Xbl コントラクト バージョンのヘッダー要素が必要です。104/105 または後ですべての要求。</span><span class="sxs-lookup"><span data-stu-id="653c1-107">It is intended for use with template contract 104/105 or later, and requires a header element of X-Xbl-Contract-Version: 104/105 or later on every request.</span></span>

  * [<span data-ttu-id="653c1-108">注釈</span><span class="sxs-lookup"><span data-stu-id="653c1-108">Remarks</span></span>](#ID4ET)
  * [<span data-ttu-id="653c1-109">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="653c1-109">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="653c1-110">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="653c1-110">Query string parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="653c1-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="653c1-111">HTTP status codes</span></span>](#ID4EAF)
  * [<span data-ttu-id="653c1-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="653c1-112">Request body</span></span>](#ID4EHF)
  * [<span data-ttu-id="653c1-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="653c1-113">Response body</span></span>](#ID4EZF)

<a id="ID4ET"></a>


## <a name="remarks"></a><span data-ttu-id="653c1-114">注釈</span><span class="sxs-lookup"><span data-stu-id="653c1-114">Remarks</span></span>

<span data-ttu-id="653c1-115">この HTTP/REST メソッドでは、"include"クエリ文字列で指定されたセッション情報と共にハンドルのデータに対するクエリを作成します。</span><span class="sxs-lookup"><span data-stu-id="653c1-115">This HTTP/REST method creates queries for handle data with session information specified in the "include" query string.</span></span> <span data-ttu-id="653c1-116">クエリ文字列の値は、コンマ区切りの一覧などをサポートしている、将来のクエリ オプションをサポートするために拡張できるように設計されています"でしょうか。 含める = relatedInfo、セッション"。</span><span class="sxs-lookup"><span data-stu-id="653c1-116">The query string value is designed to be extensible to support future query options, supporting a comma-delimited list, for example, "?include=relatedInfo,session".</span></span> <span data-ttu-id="653c1-117">によって、POST メソッドをラップできる**Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForUsersAsync**します。</span><span class="sxs-lookup"><span data-stu-id="653c1-117">The POST method can be wrapped by **Microsoft.Xbox.Services.Multiplayer.MultiplayerService.GetActivitiesForUsersAsync**.</span></span>

<span data-ttu-id="653c1-118">このメソッドの要求本文の型フィールドは、「アクティビティ」に設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-118">The type field in the request body for this method must be set to "activity".</span></span> <span data-ttu-id="653c1-119">応答本文内の項目がマップのプロパティに直接、 **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**します。</span><span class="sxs-lookup"><span data-stu-id="653c1-119">The items in the response body map directly to the properties of the **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**.</span></span>

<a id="ID4ECB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="653c1-120">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="653c1-120">URI parameters</span></span>

<a id="ID4EPB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="653c1-121">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="653c1-121">Query string parameters</span></span>

<span data-ttu-id="653c1-122">クエリは、次の表に、クエリ文字列パラメーターを使用して変更できます。</span><span class="sxs-lookup"><span data-stu-id="653c1-122">A query can be modified using the query string parameters in the next table.</span></span>

| <span data-ttu-id="653c1-123"><b>パラメーター</b></span><span class="sxs-lookup"><span data-stu-id="653c1-123"><b>Parameter</b></span></span>| <span data-ttu-id="653c1-124"><b>型</b></span><span class="sxs-lookup"><span data-stu-id="653c1-124"><b>Type</b></span></span>| <span data-ttu-id="653c1-125"><b>説明</b></span><span class="sxs-lookup"><span data-stu-id="653c1-125"><b>Description</b></span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="653c1-126">キーワード</span><span class="sxs-lookup"><span data-stu-id="653c1-126">keyword</span></span>| <span data-ttu-id="653c1-127">string</span><span class="sxs-lookup"><span data-stu-id="653c1-127">string</span></span>| <span data-ttu-id="653c1-128">キーワード、たとえば、"foo"と、a を取得する場合は、セッションまたはテンプレート内で検出する必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-128">A keyword, for example, "foo", that must be found in sessions or templates if they are to be retrieved.</span></span> |
| <span data-ttu-id="653c1-129">xuid</span><span class="sxs-lookup"><span data-stu-id="653c1-129">xuid</span></span>| <span data-ttu-id="653c1-130">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="653c1-130">64-bit unsigned integer</span></span>| <span data-ttu-id="653c1-131">Xbox ユーザー ID で、たとえば、「123」、セッション、クエリに含める。</span><span class="sxs-lookup"><span data-stu-id="653c1-131">The Xbox user ID, for example, "123", for sessions to include in the query.</span></span> <span data-ttu-id="653c1-132">既定では、ユーザーに含まれているセッションでアクティブにある必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-132">By default, the user must be active in the session for it to be included.</span></span> |
| <span data-ttu-id="653c1-133">予約</span><span class="sxs-lookup"><span data-stu-id="653c1-133">reservations</span></span>| <span data-ttu-id="653c1-134">boolean</span><span class="sxs-lookup"><span data-stu-id="653c1-134">boolean</span></span>| <span data-ttu-id="653c1-135">対象のセッションが含まれる場合は true、ユーザーは、予約済みのプレーヤーとして設定されますが、作業中のプレーヤーに参加していません。</span><span class="sxs-lookup"><span data-stu-id="653c1-135">True to include sessions for which the user is set as a reserved player but has not joined to become an active player.</span></span> <span data-ttu-id="653c1-136">このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。</span><span class="sxs-lookup"><span data-stu-id="653c1-136">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="653c1-137">非アクティブ</span><span class="sxs-lookup"><span data-stu-id="653c1-137">inactive</span></span>| <span data-ttu-id="653c1-138">boolean</span><span class="sxs-lookup"><span data-stu-id="653c1-138">boolean</span></span>| <span data-ttu-id="653c1-139">ユーザーが受け入れたにもかかわらず再生されていないセッションは、true です。</span><span class="sxs-lookup"><span data-stu-id="653c1-139">True to include sessions that the user has accepted but is not actively playing.</span></span> <span data-ttu-id="653c1-140">セッションのユーザーが"ready"ですが「アクティブ」では、非アクティブとしてカウントします。</span><span class="sxs-lookup"><span data-stu-id="653c1-140">Sessions in which the user is "ready" but not "active" count as inactive.</span></span> |
| <span data-ttu-id="653c1-141">プライベート</span><span class="sxs-lookup"><span data-stu-id="653c1-141">private</span></span>| <span data-ttu-id="653c1-142">boolean</span><span class="sxs-lookup"><span data-stu-id="653c1-142">boolean</span></span>| <span data-ttu-id="653c1-143">プライベート セッションを含めるには true です。</span><span class="sxs-lookup"><span data-stu-id="653c1-143">True to include private sessions.</span></span> <span data-ttu-id="653c1-144">このパラメーターは、自身のセッションを照会するときに、または特定のユーザーのセッションのサーバーを照会するときにのみ使用されます。</span><span class="sxs-lookup"><span data-stu-id="653c1-144">This parameter is only used when querying your own sessions, or when querying a specific user's sessions server-to-server.</span></span> |
| <span data-ttu-id="653c1-145">visibility</span><span class="sxs-lookup"><span data-stu-id="653c1-145">visibility</span></span>| <span data-ttu-id="653c1-146">string</span><span class="sxs-lookup"><span data-stu-id="653c1-146">string</span></span>| <span data-ttu-id="653c1-147">セッションの表示状態。</span><span class="sxs-lookup"><span data-stu-id="653c1-147">Visibility state for the sessions.</span></span> <span data-ttu-id="653c1-148">使用可能な値が定義されている、 <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>します。</span><span class="sxs-lookup"><span data-stu-id="653c1-148">Possible values are defined by the <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>.</span></span> <span data-ttu-id="653c1-149">このパラメーターが「開いている」に設定されている場合、クエリはのみ開いているセッションを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-149">If this parameter is set to "open", the query should include only open sessions.</span></span> <span data-ttu-id="653c1-150">"Private"で、設定されている場合、<i>プライベート</i>パラメーターを設定する必要がありますを true にします。</span><span class="sxs-lookup"><span data-stu-id="653c1-150">If it is set to "private", the <i>private</i> parameter must be set to true.</span></span> |
| <span data-ttu-id="653c1-151">version</span><span class="sxs-lookup"><span data-stu-id="653c1-151">version</span></span>| <span data-ttu-id="653c1-152">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="653c1-152">32-bit signed integer</span></span>| <span data-ttu-id="653c1-153">組み込む必要があるセッションの最大バージョン。</span><span class="sxs-lookup"><span data-stu-id="653c1-153">The maximum session version that should be included.</span></span> <span data-ttu-id="653c1-154">たとえば、2 の値が 2 の主要なセッションのバージョンでのみそのセッションを指定または小さい必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-154">For example, a value of 2 specifies that only sessions with a major session version of 2 or less should be included.</span></span> <span data-ttu-id="653c1-155">バージョン番号は、要求のコントラクト バージョン mod 100 以下である必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-155">The version number must be less than or equal to the request's contract version mod 100.</span></span> |
| <span data-ttu-id="653c1-156">Take</span><span class="sxs-lookup"><span data-stu-id="653c1-156">take</span></span>| <span data-ttu-id="653c1-157">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="653c1-157">32-bit signed integer</span></span>| <span data-ttu-id="653c1-158">取得するセッションの最大数。</span><span class="sxs-lookup"><span data-stu-id="653c1-158">The maximum number of sessions to retrieve.</span></span> <span data-ttu-id="653c1-159">この数は、0 ~ 100 の範囲にある必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-159">This number must be between 0 and 100.</span></span> |


<span data-ttu-id="653c1-160">いずれかを設定*プライベート*または*予約*に true の場合、セッションにサーバー レベルのアクセスが必要です。</span><span class="sxs-lookup"><span data-stu-id="653c1-160">Setting either *private* or *reservations* to true requires server-level access to the session.</span></span> <span data-ttu-id="653c1-161">または、これらの設定では、呼び出し元の XUID 要求の URI に XUID フィルターに一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="653c1-161">Alternatively, these settings require the caller's XUID claim to match the XUID filter in the URI.</span></span> <span data-ttu-id="653c1-162">それ以外の場合、HTTP/403 状態コードが返されます、このようなすべてのセッションが実際に存在するかどうか。</span><span class="sxs-lookup"><span data-stu-id="653c1-162">Otherwise, the HTTP/403 status code is returned, whether or not any such sessions actually exist.</span></span>

<a id="ID4EAF"></a>


## <a name="http-status-codes"></a><span data-ttu-id="653c1-163">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="653c1-163">HTTP status codes</span></span>
<span data-ttu-id="653c1-164">MPSD に適用される、サービスは、HTTP 状態コードを返します。</span><span class="sxs-lookup"><span data-stu-id="653c1-164">The service returns an HTTP status code as it applies to MPSD.</span></span>  
<a id="ID4EHF"></a>


## <a name="request-body"></a><span data-ttu-id="653c1-165">要求本文</span><span class="sxs-lookup"><span data-stu-id="653c1-165">Request body</span></span>

<a id="ID4ENF"></a>


### <a name="sample-request"></a><span data-ttu-id="653c1-166">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="653c1-166">Sample request</span></span>

<span data-ttu-id="653c1-167">にユーザーの「お気に入り」ソーシャル グラフのすべてのアクティビティを取得するには、POST の本文はようになります。</span><span class="sxs-lookup"><span data-stu-id="653c1-167">To get all activities for a user's "favorites" social graph, the POST body looks like this:</span></span>


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


## <a name="response-body"></a><span data-ttu-id="653c1-168">応答本文</span><span class="sxs-lookup"><span data-stu-id="653c1-168">Response body</span></span>

<span data-ttu-id="653c1-169">結果は、各ハンドルに埋め込まれている一意の id、ハンドルの構造体の配列として返されます。</span><span class="sxs-lookup"><span data-stu-id="653c1-169">The results are returned as an array of handle structures, with a unique ID embedded in each handle.</span></span> <span data-ttu-id="653c1-170">特定のセッション情報が返される、 **relatedInfo**オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="653c1-170">The specific session information is returned in the **relatedInfo** object.</span></span> <span data-ttu-id="653c1-171">この情報はこの URI で正規の POST メソッドに返されませんことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="653c1-171">Note that this information is not returned for the regular POST method on this URI.</span></span>

<a id="ID4EDG"></a>


### <a name="sample-response"></a><span data-ttu-id="653c1-172">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="653c1-172">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="653c1-173">関連項目</span><span class="sxs-lookup"><span data-stu-id="653c1-173">See also</span></span>

<a id="ID4EPG"></a>


##### <a name="parent"></a><span data-ttu-id="653c1-174">Parent</span><span class="sxs-lookup"><span data-stu-id="653c1-174">Parent</span></span>

[<span data-ttu-id="653c1-175">/handles/query</span><span class="sxs-lookup"><span data-stu-id="653c1-175">/handles/query</span></span>](uri-handlesquery.md)
