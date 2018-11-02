---
title: GET (/users/xuid({xuid})/achievements)
assetID: 381d49d1-7a4b-4a1e-1baf-cf674f7e0d54
permalink: en-us/docs/xboxlive/rest/uri-achievementsusersxuidachievementsgetv2.html
author: KevinAsgari
description: " GET (/users/xuid({xuid})/achievements)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 550a835bf729b22c9adc79a15ef643fa1cb009b2
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5945616"
---
# <a name="get-usersxuidxuidachievements"></a><span data-ttu-id="09935-104">GET (/users/xuid({xuid})/achievements)</span><span class="sxs-lookup"><span data-stu-id="09935-104">GET (/users/xuid({xuid})/achievements)</span></span>
<span data-ttu-id="09935-105">タイトル、進行中のユーザーが、または、ユーザーがロックを解除するもので定義されている実績の一覧を取得します。</span><span class="sxs-lookup"><span data-stu-id="09935-105">Gets the list of achievements defined on the title, those unlocked by the user, or those the user has in progress.</span></span> <span data-ttu-id="09935-106">これらの Uri のドメインが`achievements.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="09935-106">The domain for these URIs is `achievements.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="09935-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09935-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="09935-108">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="09935-108">Query string parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="09935-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="09935-109">Authorization</span></span>](#ID4ENF)
  * [<span data-ttu-id="09935-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09935-110">Required Request Headers</span></span>](#ID4ESG)
  * [<span data-ttu-id="09935-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09935-111">Optional Request Headers</span></span>](#ID4ESH)
  * [<span data-ttu-id="09935-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="09935-112">Request body</span></span>](#ID4EIBAC)
  * [<span data-ttu-id="09935-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="09935-113">Response body</span></span>](#ID4ETBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="09935-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09935-114">URI parameters</span></span>
 
| <span data-ttu-id="09935-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09935-115">Parameter</span></span>| <span data-ttu-id="09935-116">型</span><span class="sxs-lookup"><span data-stu-id="09935-116">Type</span></span>| <span data-ttu-id="09935-117">説明</span><span class="sxs-lookup"><span data-stu-id="09935-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="09935-118">xuid</span><span class="sxs-lookup"><span data-stu-id="09935-118">xuid</span></span>| <span data-ttu-id="09935-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="09935-119">64-bit unsigned integer</span></span>| <span data-ttu-id="09935-120">Xbox ユーザー ID (XUID) が (リソース) にアクセスしているユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="09935-120">Xbox User ID (XUID) of the user whose (resource) is being accessed.</span></span> <span data-ttu-id="09935-121">認証されたユーザーの XUID が一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="09935-121">Must match the XUID of the authenticated user.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="09935-122">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="09935-122">Query string parameters</span></span>
 
| <span data-ttu-id="09935-123">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09935-123">Parameter</span></span>| <span data-ttu-id="09935-124">必須かどうか</span><span class="sxs-lookup"><span data-stu-id="09935-124">Required</span></span>| <span data-ttu-id="09935-125">種類</span><span class="sxs-lookup"><span data-stu-id="09935-125">Type</span></span>| <span data-ttu-id="09935-126">説明</span><span class="sxs-lookup"><span data-stu-id="09935-126">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="09935-127">skipItems</span><span class="sxs-lookup"><span data-stu-id="09935-127">skipItems</span></span></b>| <span data-ttu-id="09935-128">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-128">No</span></span>| <span data-ttu-id="09935-129">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="09935-129">32-bit signed integer</span></span>| <span data-ttu-id="09935-130">特定の項目数後以降の項目を返します。</span><span class="sxs-lookup"><span data-stu-id="09935-130">Return items beginning after the given number of items.</span></span> <span data-ttu-id="09935-131">たとえば、 <b>skipItems =「3」</b>項目を取得以降では、4 番目の項目を取得します。</span><span class="sxs-lookup"><span data-stu-id="09935-131">For example, <b>skipItems="3"</b> will retrieve items beginning with the fourth item retrieved.</span></span> | 
| <b><span data-ttu-id="09935-132">continuationToken</span><span class="sxs-lookup"><span data-stu-id="09935-132">continuationToken</span></span></b>| <span data-ttu-id="09935-133">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-133">No</span></span>| <span data-ttu-id="09935-134">string</span><span class="sxs-lookup"><span data-stu-id="09935-134">string</span></span>| <span data-ttu-id="09935-135">特定の継続トークンから始まる項目を返します。</span><span class="sxs-lookup"><span data-stu-id="09935-135">Return the items starting at the given continuation token.</span></span> | 
| <b><span data-ttu-id="09935-136">maxItems</span><span class="sxs-lookup"><span data-stu-id="09935-136">maxItems</span></span></b>| <span data-ttu-id="09935-137">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-137">No</span></span>| <span data-ttu-id="09935-138">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="09935-138">32-bit signed integer</span></span>| <span data-ttu-id="09935-139"><b>SkipItems</b>と項目の範囲を返す<b>continuationToken</b>と組み合わせることができるコレクションから返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="09935-139">Maximum number of items to return from the collection, which can be combined with <b>skipItems</b> and <b>continuationToken</b> to return a range of items.</span></span> <span data-ttu-id="09935-140">サービスに結果の最後のページが返されていない場合でもは<b>maxItems</b>が存在しないと、 <b>maxItems</b>より少ないを返す可能性がある場合、既定値を提供可能性があります。</span><span class="sxs-lookup"><span data-stu-id="09935-140">The service may provide a default value if <b>maxItems</b> is not present, and may return fewer than <b>maxItems</b>, even if the last page of results has not yet been returned.</span></span> | 
| <b><span data-ttu-id="09935-141">titleId</span><span class="sxs-lookup"><span data-stu-id="09935-141">titleId</span></span></b>| <span data-ttu-id="09935-142">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-142">No</span></span>| <span data-ttu-id="09935-143">string</span><span class="sxs-lookup"><span data-stu-id="09935-143">string</span></span>| <span data-ttu-id="09935-144">返される結果のフィルターします。</span><span class="sxs-lookup"><span data-stu-id="09935-144">A filter for the returned results.</span></span> <span data-ttu-id="09935-145">1 つまたは複数のコンマで区切られた、10 進数のタイトル id を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="09935-145">Accepts one or more comma-delimited, decimal title identifiers.</span></span>| 
| <b><span data-ttu-id="09935-146">unlockedOnly</span><span class="sxs-lookup"><span data-stu-id="09935-146">unlockedOnly</span></span></b>| <span data-ttu-id="09935-147">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-147">No</span></span>| <span data-ttu-id="09935-148">ブール値</span><span class="sxs-lookup"><span data-stu-id="09935-148">Boolean value</span></span>| <span data-ttu-id="09935-149">返された結果をフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="09935-149">Filter for the returned results.</span></span> <span data-ttu-id="09935-150">場合を<b>true</b>に設定、ユーザーのロック解除した実績をのみが返さになります。</span><span class="sxs-lookup"><span data-stu-id="09935-150">If set to <b>true</b>, will only return the achievements unlocked for the user.</span></span> <span data-ttu-id="09935-151">既定値は<b>false</b>。</span><span class="sxs-lookup"><span data-stu-id="09935-151">Defaults to <b>false</b>.</span></span>| 
| <b><span data-ttu-id="09935-152">possibleOnly</span><span class="sxs-lookup"><span data-stu-id="09935-152">possibleOnly</span></span></b>| <span data-ttu-id="09935-153">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-153">No</span></span>| <span data-ttu-id="09935-154">ブール値</span><span class="sxs-lookup"><span data-stu-id="09935-154">Boolean value</span></span>| <span data-ttu-id="09935-155">返された結果をフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="09935-155">Filter for the returned results.</span></span> <span data-ttu-id="09935-156">場合<b>は true</b>に設定、使用可能なすべての結果がロックされていないいないメタデータ - XMS の実績情報だけが返されます。</span><span class="sxs-lookup"><span data-stu-id="09935-156">If set to <b>true</b>, will return all possible results but not unlocked metadata - just the achievement information from XMS.</span></span> <span data-ttu-id="09935-157">既定値は<b>false</b>。</span><span class="sxs-lookup"><span data-stu-id="09935-157">Defaults to <b>false</b>.</span></span>| 
| <b><span data-ttu-id="09935-158">種類</span><span class="sxs-lookup"><span data-stu-id="09935-158">types</span></span></b>| <span data-ttu-id="09935-159">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-159">No</span></span>| <span data-ttu-id="09935-160">string</span><span class="sxs-lookup"><span data-stu-id="09935-160">string</span></span>| <span data-ttu-id="09935-161">返される結果のフィルターします。</span><span class="sxs-lookup"><span data-stu-id="09935-161">A filter for the returned results.</span></span> <span data-ttu-id="09935-162">「固定」または"Challenge"できます。</span><span class="sxs-lookup"><span data-stu-id="09935-162">Can be "Persistent" or "Challenge".</span></span> <span data-ttu-id="09935-163">既定ではサポートされているすべての種類です。</span><span class="sxs-lookup"><span data-stu-id="09935-163">Default is all supported types.</span></span>| 
| <b><span data-ttu-id="09935-164">orderBy</span><span class="sxs-lookup"><span data-stu-id="09935-164">orderBy</span></span></b>| <span data-ttu-id="09935-165">いいえ</span><span class="sxs-lookup"><span data-stu-id="09935-165">No</span></span>| <span data-ttu-id="09935-166">string</span><span class="sxs-lookup"><span data-stu-id="09935-166">string</span></span>| <span data-ttu-id="09935-167">結果が返される順序を指定します。</span><span class="sxs-lookup"><span data-stu-id="09935-167">Specifies the order in which to return the results.</span></span> <span data-ttu-id="09935-168">「順序指定されていない」、「タイトル」、"UnlockTime"または"EndingSoon"を指定できます。</span><span class="sxs-lookup"><span data-stu-id="09935-168">Can be "Unordered", "Title", "UnlockTime", or "EndingSoon".</span></span> <span data-ttu-id="09935-169">既定値は「順序なし」します。</span><span class="sxs-lookup"><span data-stu-id="09935-169">The default is "Unordered".</span></span>| 
  
<a id="ID4ENF"></a>

 
## <a name="authorization"></a><span data-ttu-id="09935-170">Authorization</span><span class="sxs-lookup"><span data-stu-id="09935-170">Authorization</span></span>
 
| <span data-ttu-id="09935-171">要求</span><span class="sxs-lookup"><span data-stu-id="09935-171">Claim</span></span>| <span data-ttu-id="09935-172">必須?</span><span class="sxs-lookup"><span data-stu-id="09935-172">Required?</span></span>| <span data-ttu-id="09935-173">説明</span><span class="sxs-lookup"><span data-stu-id="09935-173">Description</span></span>| <span data-ttu-id="09935-174">不足している場合の動作</span><span class="sxs-lookup"><span data-stu-id="09935-174">Behavior if missing</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09935-175">ユーザー</span><span class="sxs-lookup"><span data-stu-id="09935-175">User</span></span>| <span data-ttu-id="09935-176">呼び出し元が、承認された Xbox LIVE ユーザーです。</span><span class="sxs-lookup"><span data-stu-id="09935-176">Caller is an authorized Xbox LIVE user.</span></span>| <span data-ttu-id="09935-177">呼び出し元では、Xbox LIVE で有効なユーザーを指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="09935-177">The caller needs to be a valid user on Xbox LIVE.</span></span>| <span data-ttu-id="09935-178">403 Forbidden</span><span class="sxs-lookup"><span data-stu-id="09935-178">403 Forbidden</span></span>| 
  
<a id="ID4ESG"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="09935-179">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09935-179">Required Request Headers</span></span>
 
| <span data-ttu-id="09935-180">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09935-180">Header</span></span>| <span data-ttu-id="09935-181">型</span><span class="sxs-lookup"><span data-stu-id="09935-181">Type</span></span>| <span data-ttu-id="09935-182">説明</span><span class="sxs-lookup"><span data-stu-id="09935-182">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09935-183">Authorization</span><span class="sxs-lookup"><span data-stu-id="09935-183">Authorization</span></span>| <span data-ttu-id="09935-184">string</span><span class="sxs-lookup"><span data-stu-id="09935-184">string</span></span>| <span data-ttu-id="09935-185">HTTP の認証の資格情報を認証します。</span><span class="sxs-lookup"><span data-stu-id="09935-185">Authentication credentials for HTTP authentication.</span></span> <span data-ttu-id="09935-186">値の例:"XBL3.0 x =&lt;userhash > です。&lt;トークン >"します。</span><span class="sxs-lookup"><span data-stu-id="09935-186">Example value: "XBL3.0 x=&lt;userhash>;&lt;token>".</span></span>| 
  
<a id="ID4ESH"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="09935-187">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09935-187">Optional Request Headers</span></span>
 
| <span data-ttu-id="09935-188">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09935-188">Header</span></span>| <span data-ttu-id="09935-189">型</span><span class="sxs-lookup"><span data-stu-id="09935-189">Type</span></span>| <span data-ttu-id="09935-190">説明</span><span class="sxs-lookup"><span data-stu-id="09935-190">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <b><span data-ttu-id="09935-191">X RequestedServiceVersion</span><span class="sxs-lookup"><span data-stu-id="09935-191">X-RequestedServiceVersion</span></span></b>| <span data-ttu-id="09935-192">string</span><span class="sxs-lookup"><span data-stu-id="09935-192">string</span></span>| <span data-ttu-id="09935-193">この要求を送信する必要があります、Xbox LIVE サービスの名前/数をビルドします。</span><span class="sxs-lookup"><span data-stu-id="09935-193">Build name/number of the Xbox LIVE service to which this request should be directed.</span></span> <span data-ttu-id="09935-194">要求は、ヘッダー、要求に認証トークンなどの有効性を確認した後、そのサービスにのみルーティングされます。既定値: 1 です。</span><span class="sxs-lookup"><span data-stu-id="09935-194">The request will only be routed to that service after verifying the validity of the header, the claims in the auth token, etc. Default value: 1.</span></span>| 
| <b><span data-ttu-id="09935-195">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="09935-195">x-xbl-contract-version</span></span></b>| <span data-ttu-id="09935-196">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="09935-196">32-bit unsigned integer</span></span>| <span data-ttu-id="09935-197">存在する場合、2 に設定すると、この API の V2 バージョンが使用されます。</span><span class="sxs-lookup"><span data-stu-id="09935-197">If present and set to 2, the V2 version of this API will be used.</span></span> <span data-ttu-id="09935-198">それ以外の場合、V1 します。</span><span class="sxs-lookup"><span data-stu-id="09935-198">Otherwise, V1.</span></span>| 
| <b><span data-ttu-id="09935-199">同意言語</span><span class="sxs-lookup"><span data-stu-id="09935-199">Accept-Language</span></span></b>| <span data-ttu-id="09935-200">string</span><span class="sxs-lookup"><span data-stu-id="09935-200">string</span></span>| <span data-ttu-id="09935-201">目的のロケールとフォールバック (FR-FR, fr, EN-GB、en 世界、EN-US など) の一覧です。</span><span class="sxs-lookup"><span data-stu-id="09935-201">List of desired locales and fallbacks (e.g., fr-FR, fr, en-GB, en-WW, en-US).</span></span> <span data-ttu-id="09935-202">ローカライズされた文字列の一致が見つかるまで、実績サービスは、一覧で動作します。</span><span class="sxs-lookup"><span data-stu-id="09935-202">The Achievements service will work through the list until it finds matching localized strings.</span></span> <span data-ttu-id="09935-203">見つからない場合は、ユーザーの IP アドレスに由来するユーザーのトークンで定義されている場所と一致しようとします。</span><span class="sxs-lookup"><span data-stu-id="09935-203">If none are found, it attempts to match the location defined in the user token, which comes from the user's IP address.</span></span> <span data-ttu-id="09935-204">まだ一致するローカライズされた文字列はありません。 が見つかった場合、タイトル開発者または発行元によって提供される既定の文字列を使用します。</span><span class="sxs-lookup"><span data-stu-id="09935-204">If still no matching localized strings are found, it uses the default strings provided by the title developer/publisher.</span></span> | 
  
<a id="ID4EIBAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="09935-205">要求本文</span><span class="sxs-lookup"><span data-stu-id="09935-205">Request body</span></span>
 
<span data-ttu-id="09935-206">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="09935-206">No objects are sent in the body of this request.</span></span>
  
<a id="ID4ETBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="09935-207">応答本文</span><span class="sxs-lookup"><span data-stu-id="09935-207">Response body</span></span>
 
<span data-ttu-id="09935-208">呼び出しが成功した場合、サービスは、[実績 (JSON)](../../json/json-achievementv2.md)オブジェクトと[PagingInfo (JSON)](../../json/json-paginginfo.md)オブジェクトの配列を返します。</span><span class="sxs-lookup"><span data-stu-id="09935-208">If the call is successful, the service returns an array of [Achievement (JSON)](../../json/json-achievementv2.md) objects and a [PagingInfo (JSON)](../../json/json-paginginfo.md) object.</span></span>
 
<a id="ID4ECCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="09935-209">応答の例</span><span class="sxs-lookup"><span data-stu-id="09935-209">Sample response</span></span>
 

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
                "url":"http://www.xbox.com"
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

 
## <a name="see-also"></a><span data-ttu-id="09935-210">関連項目</span><span class="sxs-lookup"><span data-stu-id="09935-210">See also</span></span>
 
<a id="ID4ERCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="09935-211">Parent</span><span class="sxs-lookup"><span data-stu-id="09935-211">Parent</span></span> 

[<span data-ttu-id="09935-212">/users/xuid({xuid})/achievements</span><span class="sxs-lookup"><span data-stu-id="09935-212">/users/xuid({xuid})/achievements</span></span>](uri-achievementsusersxuidachievementsv2.md)

  
<a id="ID4E2CAC"></a>

 
##### <a name="reference"></a><span data-ttu-id="09935-213">リファレンス</span><span class="sxs-lookup"><span data-stu-id="09935-213">Reference</span></span> 

[<span data-ttu-id="09935-214">Achievement (JSON)</span><span class="sxs-lookup"><span data-stu-id="09935-214">Achievement (JSON)</span></span>](../../json/json-achievementv2.md)

 [<span data-ttu-id="09935-215">PagingInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="09935-215">PagingInfo (JSON)</span></span>](../../json/json-paginginfo.md)

 [<span data-ttu-id="09935-216">ページング パラメーター</span><span class="sxs-lookup"><span data-stu-id="09935-216">Paging Parameters</span></span>](../../additional/pagingparameters.md)

   