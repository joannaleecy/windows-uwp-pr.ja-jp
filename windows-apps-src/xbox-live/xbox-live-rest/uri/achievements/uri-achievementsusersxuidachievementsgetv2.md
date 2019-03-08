---
title: GET (/users/xuid({xuid})/achievements)
assetID: 381d49d1-7a4b-4a1e-1baf-cf674f7e0d54
permalink: en-us/docs/xboxlive/rest/uri-achievementsusersxuidachievementsgetv2.html
description: " GET (/users/xuid({xuid})/achievements)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 720170e88808db7ef95b88896fbca4f1cda4a091
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655267"
---
# <a name="get-usersxuidxuidachievements"></a><span data-ttu-id="584ad-104">GET (/users/xuid({xuid})/achievements)</span><span class="sxs-lookup"><span data-stu-id="584ad-104">GET (/users/xuid({xuid})/achievements)</span></span>
<span data-ttu-id="584ad-105">タイトル、進行中のユーザーがまたは、ユーザーがロックを解除するもので定義された実績の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="584ad-105">Gets the list of achievements defined on the title, those unlocked by the user, or those the user has in progress.</span></span> <span data-ttu-id="584ad-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="584ad-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="584ad-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="584ad-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="584ad-108">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="584ad-108">Query string parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="584ad-109">承認</span><span class="sxs-lookup"><span data-stu-id="584ad-109">Authorization</span></span>](#ID4ENF)
  * [<span data-ttu-id="584ad-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="584ad-110">Required Request Headers</span></span>](#ID4ESG)
  * [<span data-ttu-id="584ad-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="584ad-111">Optional Request Headers</span></span>](#ID4ESH)
  * [<span data-ttu-id="584ad-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="584ad-112">Request body</span></span>](#ID4EIBAC)
  * [<span data-ttu-id="584ad-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="584ad-113">Response body</span></span>](#ID4ETBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="584ad-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="584ad-114">URI parameters</span></span>
 
| <span data-ttu-id="584ad-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="584ad-115">Parameter</span></span>| <span data-ttu-id="584ad-116">種類</span><span class="sxs-lookup"><span data-stu-id="584ad-116">Type</span></span>| <span data-ttu-id="584ad-117">説明</span><span class="sxs-lookup"><span data-stu-id="584ad-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="584ad-118">xuid</span><span class="sxs-lookup"><span data-stu-id="584ad-118">xuid</span></span>| <span data-ttu-id="584ad-119">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="584ad-119">64-bit unsigned integer</span></span>| <span data-ttu-id="584ad-120">Xbox ユーザー ID (XUID)、ユーザーが (リソース) がアクセスされているのです。</span><span class="sxs-lookup"><span data-stu-id="584ad-120">Xbox User ID (XUID) of the user whose (resource) is being accessed.</span></span> <span data-ttu-id="584ad-121">認証されたユーザーの XUID に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="584ad-121">Must match the XUID of the authenticated user.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="584ad-122">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="584ad-122">Query string parameters</span></span>
 
| <span data-ttu-id="584ad-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="584ad-123">Parameter</span></span>| <span data-ttu-id="584ad-124">必須</span><span class="sxs-lookup"><span data-stu-id="584ad-124">Required</span></span>| <span data-ttu-id="584ad-125">種類</span><span class="sxs-lookup"><span data-stu-id="584ad-125">Type</span></span>| <span data-ttu-id="584ad-126">説明</span><span class="sxs-lookup"><span data-stu-id="584ad-126">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="584ad-127"><b>skipItems</b></span><span class="sxs-lookup"><span data-stu-id="584ad-127"><b>skipItems</b></span></span>| <span data-ttu-id="584ad-128">X</span><span class="sxs-lookup"><span data-stu-id="584ad-128">No</span></span>| <span data-ttu-id="584ad-129">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="584ad-129">32-bit signed integer</span></span>| <span data-ttu-id="584ad-130">指定されたアイテム数の後に開始アイテムを返します。</span><span class="sxs-lookup"><span data-stu-id="584ad-130">Return items beginning after the given number of items.</span></span> <span data-ttu-id="584ad-131">たとえば、 <b>skipItems =「3」</b>項目を取得以降の 4 番目の項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="584ad-131">For example, <b>skipItems="3"</b> will retrieve items beginning with the fourth item retrieved.</span></span> | 
| <span data-ttu-id="584ad-132"><b>continuationToken</b></span><span class="sxs-lookup"><span data-stu-id="584ad-132"><b>continuationToken</b></span></span>| <span data-ttu-id="584ad-133">X</span><span class="sxs-lookup"><span data-stu-id="584ad-133">No</span></span>| <span data-ttu-id="584ad-134">string</span><span class="sxs-lookup"><span data-stu-id="584ad-134">string</span></span>| <span data-ttu-id="584ad-135">指定された継続トークンで始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="584ad-135">Return the items starting at the given continuation token.</span></span> | 
| <span data-ttu-id="584ad-136"><b>maxItems</b></span><span class="sxs-lookup"><span data-stu-id="584ad-136"><b>maxItems</b></span></span>| <span data-ttu-id="584ad-137">X</span><span class="sxs-lookup"><span data-stu-id="584ad-137">No</span></span>| <span data-ttu-id="584ad-138">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="584ad-138">32-bit signed integer</span></span>| <span data-ttu-id="584ad-139">組み合わせて使用できるコレクションから返されるアイテムの最大数<b>skipItems</b>と<b>continuationToken</b>を項目の範囲を返します。</span><span class="sxs-lookup"><span data-stu-id="584ad-139">Maximum number of items to return from the collection, which can be combined with <b>skipItems</b> and <b>continuationToken</b> to return a range of items.</span></span> <span data-ttu-id="584ad-140">場合、サービスは、既定値を指定可能性があります<b>maxItems</b>が存在しないより少ないを返すことが<b>maxItems</b>結果の最後のページが返されていない場合でも、します。</span><span class="sxs-lookup"><span data-stu-id="584ad-140">The service may provide a default value if <b>maxItems</b> is not present, and may return fewer than <b>maxItems</b>, even if the last page of results has not yet been returned.</span></span> | 
| <span data-ttu-id="584ad-141"><b>titleId</b></span><span class="sxs-lookup"><span data-stu-id="584ad-141"><b>titleId</b></span></span>| <span data-ttu-id="584ad-142">X</span><span class="sxs-lookup"><span data-stu-id="584ad-142">No</span></span>| <span data-ttu-id="584ad-143">string</span><span class="sxs-lookup"><span data-stu-id="584ad-143">string</span></span>| <span data-ttu-id="584ad-144">返される結果をフィルターします。</span><span class="sxs-lookup"><span data-stu-id="584ad-144">A filter for the returned results.</span></span> <span data-ttu-id="584ad-145">1 つまたは複数のタイトルをコンマ区切りの 10 進識別子を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="584ad-145">Accepts one or more comma-delimited, decimal title identifiers.</span></span>| 
| <span data-ttu-id="584ad-146"><b>unlockedOnly</b></span><span class="sxs-lookup"><span data-stu-id="584ad-146"><b>unlockedOnly</b></span></span>| <span data-ttu-id="584ad-147">X</span><span class="sxs-lookup"><span data-stu-id="584ad-147">No</span></span>| <span data-ttu-id="584ad-148">ブール値</span><span class="sxs-lookup"><span data-stu-id="584ad-148">Boolean value</span></span>| <span data-ttu-id="584ad-149">返される結果を返すフィルター。</span><span class="sxs-lookup"><span data-stu-id="584ad-149">Filter for the returned results.</span></span> <span data-ttu-id="584ad-150">場合設定<b>true</b>ユーザーのロックを解除する実績をのみを返すには。</span><span class="sxs-lookup"><span data-stu-id="584ad-150">If set to <b>true</b>, will only return the achievements unlocked for the user.</span></span> <span data-ttu-id="584ad-151">既定値は<b>false</b>します。</span><span class="sxs-lookup"><span data-stu-id="584ad-151">Defaults to <b>false</b>.</span></span>| 
| <span data-ttu-id="584ad-152"><b>possibleOnly</b></span><span class="sxs-lookup"><span data-stu-id="584ad-152"><b>possibleOnly</b></span></span>| <span data-ttu-id="584ad-153">X</span><span class="sxs-lookup"><span data-stu-id="584ad-153">No</span></span>| <span data-ttu-id="584ad-154">ブール値</span><span class="sxs-lookup"><span data-stu-id="584ad-154">Boolean value</span></span>| <span data-ttu-id="584ad-155">返される結果を返すフィルター。</span><span class="sxs-lookup"><span data-stu-id="584ad-155">Filter for the returned results.</span></span> <span data-ttu-id="584ad-156">場合に設定<b>true</b>、すべての可能な結果が返されますが、いないだけのメタデータのロックを解除 XMS から情報アチーブメントが獲得されました。</span><span class="sxs-lookup"><span data-stu-id="584ad-156">If set to <b>true</b>, will return all possible results but not unlocked metadata - just the achievement information from XMS.</span></span> <span data-ttu-id="584ad-157">既定値は<b>false</b>します。</span><span class="sxs-lookup"><span data-stu-id="584ad-157">Defaults to <b>false</b>.</span></span>| 
| <span data-ttu-id="584ad-158"><b>型</b></span><span class="sxs-lookup"><span data-stu-id="584ad-158"><b>types</b></span></span>| <span data-ttu-id="584ad-159">X</span><span class="sxs-lookup"><span data-stu-id="584ad-159">No</span></span>| <span data-ttu-id="584ad-160">string</span><span class="sxs-lookup"><span data-stu-id="584ad-160">string</span></span>| <span data-ttu-id="584ad-161">返される結果をフィルターします。</span><span class="sxs-lookup"><span data-stu-id="584ad-161">A filter for the returned results.</span></span> <span data-ttu-id="584ad-162">"Persistent"または「チャレンジ」を指定できます。</span><span class="sxs-lookup"><span data-stu-id="584ad-162">Can be "Persistent" or "Challenge".</span></span> <span data-ttu-id="584ad-163">既定ではサポートされているすべての型です。</span><span class="sxs-lookup"><span data-stu-id="584ad-163">Default is all supported types.</span></span>| 
| <span data-ttu-id="584ad-164"><b>OrderBy</b></span><span class="sxs-lookup"><span data-stu-id="584ad-164"><b>orderBy</b></span></span>| <span data-ttu-id="584ad-165">X</span><span class="sxs-lookup"><span data-stu-id="584ad-165">No</span></span>| <span data-ttu-id="584ad-166">string</span><span class="sxs-lookup"><span data-stu-id="584ad-166">string</span></span>| <span data-ttu-id="584ad-167">結果が返される順序を指定します。</span><span class="sxs-lookup"><span data-stu-id="584ad-167">Specifies the order in which to return the results.</span></span> <span data-ttu-id="584ad-168">「順不同」、"Title""UnlockTime"または"EndingSoon"を指定できます。</span><span class="sxs-lookup"><span data-stu-id="584ad-168">Can be "Unordered", "Title", "UnlockTime", or "EndingSoon".</span></span> <span data-ttu-id="584ad-169">既定値は「順不同」。</span><span class="sxs-lookup"><span data-stu-id="584ad-169">The default is "Unordered".</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="authorization"></a><span data-ttu-id="584ad-170">Authorization</span><span class="sxs-lookup"><span data-stu-id="584ad-170">Authorization</span></span>
 
| <span data-ttu-id="584ad-171">要求</span><span class="sxs-lookup"><span data-stu-id="584ad-171">Claim</span></span>| <span data-ttu-id="584ad-172">必須?</span><span class="sxs-lookup"><span data-stu-id="584ad-172">Required?</span></span>| <span data-ttu-id="584ad-173">説明</span><span class="sxs-lookup"><span data-stu-id="584ad-173">Description</span></span>| <span data-ttu-id="584ad-174">不足している場合の動作</span><span class="sxs-lookup"><span data-stu-id="584ad-174">Behavior if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="584ad-175">ユーザー</span><span class="sxs-lookup"><span data-stu-id="584ad-175">User</span></span>| <span data-ttu-id="584ad-176">呼び出し元は、Xbox LIVE 権限を持つユーザーです。</span><span class="sxs-lookup"><span data-stu-id="584ad-176">Caller is an authorized Xbox LIVE user.</span></span>| <span data-ttu-id="584ad-177">呼び出し元は、Xbox LIVE の有効なユーザーである必要があります。</span><span class="sxs-lookup"><span data-stu-id="584ad-177">The caller needs to be a valid user on Xbox LIVE.</span></span>| <span data-ttu-id="584ad-178">403 許可されていません</span><span class="sxs-lookup"><span data-stu-id="584ad-178">403 Forbidden</span></span>| 
  
<a id="ID4ESG"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="584ad-179">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="584ad-179">Required Request Headers</span></span>
 
| <span data-ttu-id="584ad-180">Header</span><span class="sxs-lookup"><span data-stu-id="584ad-180">Header</span></span>| <span data-ttu-id="584ad-181">種類</span><span class="sxs-lookup"><span data-stu-id="584ad-181">Type</span></span>| <span data-ttu-id="584ad-182">説明</span><span class="sxs-lookup"><span data-stu-id="584ad-182">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="584ad-183">Authorization</span><span class="sxs-lookup"><span data-stu-id="584ad-183">Authorization</span></span>| <span data-ttu-id="584ad-184">string</span><span class="sxs-lookup"><span data-stu-id="584ad-184">string</span></span>| <span data-ttu-id="584ad-185">HTTP 認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="584ad-185">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="584ad-186">値の例:"XBL3.0 x =&lt;userhash >;&lt;トークン >"。</span><span class="sxs-lookup"><span data-stu-id="584ad-186">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
  
<a id="ID4ESH"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="584ad-187">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="584ad-187">Optional Request Headers</span></span>
 
| <span data-ttu-id="584ad-188">Header</span><span class="sxs-lookup"><span data-stu-id="584ad-188">Header</span></span>| <span data-ttu-id="584ad-189">種類</span><span class="sxs-lookup"><span data-stu-id="584ad-189">Type</span></span>| <span data-ttu-id="584ad-190">説明</span><span class="sxs-lookup"><span data-stu-id="584ad-190">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="584ad-191"><b>X RequestedServiceVersion</b></span><span class="sxs-lookup"><span data-stu-id="584ad-191"><b>X-RequestedServiceVersion</b></span></span>| <span data-ttu-id="584ad-192">string</span><span class="sxs-lookup"><span data-stu-id="584ad-192">string</span></span>| <span data-ttu-id="584ad-193">この要求が送られる Xbox LIVE サービスの名前/番号をビルドします。</span><span class="sxs-lookup"><span data-stu-id="584ad-193">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="584ad-194">要求は、ヘッダー、認証トークンなどの要求の有効性を確認した後、サービスにのみルーティングされます。［既定値］:1. </span><span class="sxs-lookup"><span data-stu-id="584ad-194">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <span data-ttu-id="584ad-195"><b>x-xbl-contract-version</b></span><span class="sxs-lookup"><span data-stu-id="584ad-195"><b>x-xbl-contract-version</b></span></span>| <span data-ttu-id="584ad-196">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="584ad-196">32-bit unsigned integer</span></span>| <span data-ttu-id="584ad-197">存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。</span><span class="sxs-lookup"><span data-stu-id="584ad-197">If present and set to 2, the V2 version of this API will be used.</span></span> <span data-ttu-id="584ad-198">それ以外の場合、V1 します。</span><span class="sxs-lookup"><span data-stu-id="584ad-198">Otherwise, V1.</span></span>| 
| <span data-ttu-id="584ad-199"><b>Accept-Language</b></span><span class="sxs-lookup"><span data-stu-id="584ad-199"><b>Accept-Language</b></span></span>| <span data-ttu-id="584ad-200">string</span><span class="sxs-lookup"><span data-stu-id="584ad-200">string</span></span>| <span data-ttu-id="584ad-201">目的のロケールとフォールバック (FR-FR、fr、EN-GB、en WW、EN-US など) の一覧です。</span><span class="sxs-lookup"><span data-stu-id="584ad-201">List of desired locales and fallbacks (e.g., fr-FR, fr, en-GB, en-WW, en-US).</span></span> <span data-ttu-id="584ad-202">ローカライズされた文字列の一致が見つかるまで一覧をアチーブメント サービスの動作します。</span><span class="sxs-lookup"><span data-stu-id="584ad-202">The Achievements service will work through the list until it finds matching localized strings.</span></span> <span data-ttu-id="584ad-203">見つからない場合、ユーザーの IP アドレスから付属しているユーザー トークンで定義されている場所を照合しようと試みます。</span><span class="sxs-lookup"><span data-stu-id="584ad-203">If none are found, it attempts to match the location defined in the user token, which comes from the user's IP address.</span></span> <span data-ttu-id="584ad-204">いない対応するローカライズされた文字列もが見つかった場合は、タイトルの開発者/発行元によって提供される既定の文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="584ad-204">If still no matching localized strings are found, it uses the default strings provided by the title developer/publisher.</span></span> | 
  
<a id="ID4EIBAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="584ad-205">要求本文</span><span class="sxs-lookup"><span data-stu-id="584ad-205">Request body</span></span>
 
<span data-ttu-id="584ad-206">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="584ad-206">No objects are sent in the body of this request.</span></span>
  
<a id="ID4ETBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="584ad-207">応答本文</span><span class="sxs-lookup"><span data-stu-id="584ad-207">Response body</span></span>
 
<span data-ttu-id="584ad-208">呼び出しが成功した場合、サービスは、の配列を返します[アチーブメントが獲得されました (JSON)](../../json/json-achievementv2.md)オブジェクトと[PagingInfo (JSON)](../../json/json-paginginfo.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="584ad-208">If the call is successful, the service returns an array of [Achievement (JSON)](../../json/json-achievementv2.md) objects and a [PagingInfo (JSON)](../../json/json-paginginfo.md) object.</span></span>
 
<a id="ID4ECCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="584ad-209">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="584ad-209">Sample response</span></span>
 

```cpp
{
    "achievements":
    [{
        "id":"3",
        "serviceConfigId":"b5dd9daf-0000-0000-0000-000000000000",
        "name":"Default NameString for Microsoft Achievements Sample Achievement 3",
        "titleAssociations":
        [{
                "name":"Microsoft Achievements Sample",
                "id":3051199919,
                "version":"abc"
        }],
        "progressState":"Achieved",
        "progression":
        {
                "achievementState":"Achieved",
                "requirements":null,
                "timeUnlocked":"2013-01-17T03:19:00.3087016Z",
        },
        "mediaAssets":
        [{
                "name":"Icon Name",
                "type":"Icon",
                "url":"https://www.xbox.com"
        }],
        "platform":"D",
        "isSecret":true,
        "description":"Default DescriptionString for Microsoft Achievements Sample Achievement 3",
        "lockedDescription":"Default UnachievedString for Microsoft Achievements Sample Achievement 3",
        "productId":"12345678-1234-1234-1234-123456789012",
        "achievementType":"Challenge",
        "participationType":"Individual",
        "timeWindow":
        {
                "startDate":"2013-02-01T00:00:00Z",
                "endDate":"2100-07-01T00:00:00Z"
        },
        "rewards":
        [{
                "name":null,
                "description":null,
                "value":"10",
                "type":"Gamerscore",
                "valueType":"Int"
        },
        {
                "name":"Default Name for InAppReward for Microsoft Achievements Sample Achievement 3",
                "description":"Default Description for InAppReward for Microsoft Achievements Sample Achievement 3",
                "value":"1",
                "type":"InApp",
                "valueType":"String"
        }],
        "estimatedTime":"06:12:14",
        "deeplink":"aWFtYWRlZXBsaW5r",
        "isRevoked":false
        }],
        "pagingInfo":
        {
                "continuationToken":null,
                "totalRecords":1
        }
}
         
```

   
<a id="ID4EPCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="584ad-210">関連項目</span><span class="sxs-lookup"><span data-stu-id="584ad-210">See also</span></span>
 
<a id="ID4ERCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="584ad-211">Parent</span><span class="sxs-lookup"><span data-stu-id="584ad-211">Parent</span></span> 

[<span data-ttu-id="584ad-212">/users/xuid({xuid})/achievements</span><span class="sxs-lookup"><span data-stu-id="584ad-212">/users/xuid({xuid})/achievements</span></span>](uri-achievementsusersxuidachievementsv2.md)

  
<a id="ID4E2CAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="584ad-213">リファレンス</span><span class="sxs-lookup"><span data-stu-id="584ad-213">Reference</span></span> 

[<span data-ttu-id="584ad-214">アチーブメントが獲得されました (JSON)</span><span class="sxs-lookup"><span data-stu-id="584ad-214">Achievement (JSON)</span></span>](../../json/json-achievementv2.md)

 [<span data-ttu-id="584ad-215">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="584ad-215">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

 [<span data-ttu-id="584ad-216">ページングのパラメーター</span><span class="sxs-lookup"><span data-stu-id="584ad-216">Paging Parameters</span></span>](../../additional/pagingparameters.md)

   