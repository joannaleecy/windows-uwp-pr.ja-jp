---
title: GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)
assetID: 229cabc6-3c5c-89e1-47e3-96a7f54094c9
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype-get.html
author: KevinAsgari
description: " GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dcc2828487dc57f417608c7f80dde9ce650bbd51
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6248650"
---
# <a name="get-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="62b20-104">GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="62b20-104">GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="62b20-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="62b20-105">Downloads a file.</span></span> <span data-ttu-id="62b20-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="62b20-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="62b20-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="62b20-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="62b20-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="62b20-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="62b20-109">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="62b20-109">Optional Query String Parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="62b20-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-110">Required Request Headers</span></span>](#ID4EQC)
  * [<span data-ttu-id="62b20-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-111">Optional Request Headers</span></span>](#ID4EZD)
  * [<span data-ttu-id="62b20-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="62b20-112">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="62b20-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="62b20-113">HTTP status codes</span></span>](#ID4EQF)
  * [<span data-ttu-id="62b20-114">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-114">Response Headers</span></span>](#ID4EDDAC)
  * [<span data-ttu-id="62b20-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="62b20-115">Response body</span></span>](#ID4EGEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="62b20-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="62b20-116">URI parameters</span></span>
 
| <span data-ttu-id="62b20-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="62b20-117">Parameter</span></span>| <span data-ttu-id="62b20-118">型</span><span class="sxs-lookup"><span data-stu-id="62b20-118">Type</span></span>| <span data-ttu-id="62b20-119">説明</span><span class="sxs-lookup"><span data-stu-id="62b20-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="62b20-120">xuid</span><span class="sxs-lookup"><span data-stu-id="62b20-120">xuid</span></span>| <span data-ttu-id="62b20-121">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="62b20-121">unsigned 64-bit integer</span></span>| <span data-ttu-id="62b20-122">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="62b20-122">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="62b20-123">scid</span><span class="sxs-lookup"><span data-stu-id="62b20-123">scid</span></span>| <span data-ttu-id="62b20-124">guid</span><span class="sxs-lookup"><span data-stu-id="62b20-124">guid</span></span>| <span data-ttu-id="62b20-125">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="62b20-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="62b20-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="62b20-126">pathAndFileName</span></span>| <span data-ttu-id="62b20-127">string</span><span class="sxs-lookup"><span data-stu-id="62b20-127">string</span></span>| <span data-ttu-id="62b20-128">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="62b20-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="62b20-129">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="62b20-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="62b20-130">ファイル名可能性がありますいない空にすること、期間の終了または 2 つの連続するピリオドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="62b20-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="62b20-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="62b20-131">Authorization</span></span> 
 
<span data-ttu-id="62b20-132">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="62b20-132">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="62b20-133">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="62b20-133">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="62b20-134">ヘッダーが見つからないか無効な場合は、サービスは、401 不正な応答を返します。</span><span class="sxs-lookup"><span data-stu-id="62b20-134">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="62b20-135">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="62b20-135">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="62b20-136">Blob の種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="62b20-136">Varies by blob type.</span></span> <span data-ttu-id="62b20-137">バイナリ blob には、クエリ パラメーターをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="62b20-137">Binary blobs do not support query parameters.</span></span>
 
| <span data-ttu-id="62b20-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="62b20-138">Parameter</span></span>| <span data-ttu-id="62b20-139">型</span><span class="sxs-lookup"><span data-stu-id="62b20-139">Type</span></span>| <span data-ttu-id="62b20-140">説明</span><span class="sxs-lookup"><span data-stu-id="62b20-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="62b20-141">選択</span><span class="sxs-lookup"><span data-stu-id="62b20-141">select</span></span>| <span data-ttu-id="62b20-142">string</span><span class="sxs-lookup"><span data-stu-id="62b20-142">string</span></span>| <span data-ttu-id="62b20-143">型は json ときにのみ使用します。</span><span class="sxs-lookup"><span data-stu-id="62b20-143">Only usable when type is json.</span></span> <span data-ttu-id="62b20-144">応答する必要がありますのみを含む特定プロパティ/値、JSON のこのパラメーターによって決定されるを指定します。</span><span class="sxs-lookup"><span data-stu-id="62b20-144">Specifies that the response should only contain a certain property/value of the JSON, as determined by this parameter.</span></span> <span data-ttu-id="62b20-145">「ドット」(.) を使ってサブプロパティと角かっこを指定する ('['、']') 配列のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="62b20-145">Use a "dot" (.) to specify sub-properties and square brackets ('[' and ']') to specify array indices.</span></span> <span data-ttu-id="62b20-146">たとえば、"配列 1 4 .prop2"配列「1」配列のインデックス 4"prop2"プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="62b20-146">For example, "array1[4].prop2" specifies the "prop2" property of index 4 of the "array1" array.</span></span>| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="62b20-147">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-147">Required Request Headers</span></span>
 
| <span data-ttu-id="62b20-148">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-148">Header</span></span>| <span data-ttu-id="62b20-149">設定値</span><span class="sxs-lookup"><span data-stu-id="62b20-149">Value</span></span>| <span data-ttu-id="62b20-150">説明</span><span class="sxs-lookup"><span data-stu-id="62b20-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="62b20-151">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="62b20-151">x-xbl-contract-version</span></span>| <span data-ttu-id="62b20-152">1</span><span class="sxs-lookup"><span data-stu-id="62b20-152">1</span></span>| <span data-ttu-id="62b20-153">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="62b20-153">API contract version.</span></span>| 
| <span data-ttu-id="62b20-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="62b20-154">Authorization</span></span>| <span data-ttu-id="62b20-155">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="62b20-155">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="62b20-156">STS 認証トークン。</span><span class="sxs-lookup"><span data-stu-id="62b20-156">STS authentication token.</span></span> <span data-ttu-id="62b20-157">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="62b20-157">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="62b20-158">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="62b20-158">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="62b20-159">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-159">Optional Request Headers</span></span>
 
| <span data-ttu-id="62b20-160">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-160">Header</span></span>| <span data-ttu-id="62b20-161">説明</span><span class="sxs-lookup"><span data-stu-id="62b20-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="62b20-162">If-Match</span><span class="sxs-lookup"><span data-stu-id="62b20-162">If-Match</span></span>| <span data-ttu-id="62b20-163">操作を完了するにより既存項目と一致する ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="62b20-163">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="62b20-164">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="62b20-164">If-None-Match</span></span>| <span data-ttu-id="62b20-165">操作を完了するには、すべてにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="62b20-165">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
| <span data-ttu-id="62b20-166">範囲</span><span class="sxs-lookup"><span data-stu-id="62b20-166">Range</span></span>| <span data-ttu-id="62b20-167">ダウンロードするバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="62b20-167">Specifies the range of bytes to download.</span></span> <span data-ttu-id="62b20-168">標準の HTTP 範囲ヘッダー形式に従います。</span><span class="sxs-lookup"><span data-stu-id="62b20-168">Follows the standard HTTP Range header format.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="62b20-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="62b20-169">Request body</span></span> 
 
<span data-ttu-id="62b20-170">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="62b20-170">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EQF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="62b20-171">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="62b20-171">HTTP status codes</span></span> 
 
<span data-ttu-id="62b20-172">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="62b20-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="62b20-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="62b20-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="62b20-174">コード</span><span class="sxs-lookup"><span data-stu-id="62b20-174">Code</span></span>| <span data-ttu-id="62b20-175">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="62b20-175">Reason phrase</span></span>| <span data-ttu-id="62b20-176">説明</span><span class="sxs-lookup"><span data-stu-id="62b20-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="62b20-177">200</span><span class="sxs-lookup"><span data-stu-id="62b20-177">200</span></span>| <span data-ttu-id="62b20-178">OK</span><span class="sxs-lookup"><span data-stu-id="62b20-178">OK</span></span> | <span data-ttu-id="62b20-179">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="62b20-179">The request was successful.</span></span>| 
| <span data-ttu-id="62b20-180">201</span><span class="sxs-lookup"><span data-stu-id="62b20-180">201</span></span>| <span data-ttu-id="62b20-181">Created</span><span class="sxs-lookup"><span data-stu-id="62b20-181">Created</span></span> | <span data-ttu-id="62b20-182">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="62b20-182">The entity was created.</span></span>| 
| <span data-ttu-id="62b20-183">400</span><span class="sxs-lookup"><span data-stu-id="62b20-183">400</span></span>| <span data-ttu-id="62b20-184">Bad Request</span><span class="sxs-lookup"><span data-stu-id="62b20-184">Bad Request</span></span> | <span data-ttu-id="62b20-185">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="62b20-185">Service could not understand malformed request.</span></span> <span data-ttu-id="62b20-186">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="62b20-186">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="62b20-187">401</span><span class="sxs-lookup"><span data-stu-id="62b20-187">401</span></span>| <span data-ttu-id="62b20-188">権限がありません</span><span class="sxs-lookup"><span data-stu-id="62b20-188">Unauthorized</span></span> | <span data-ttu-id="62b20-189">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="62b20-189">The request requires user authentication.</span></span>| 
| <span data-ttu-id="62b20-190">403</span><span class="sxs-lookup"><span data-stu-id="62b20-190">403</span></span>| <span data-ttu-id="62b20-191">Forbidden</span><span class="sxs-lookup"><span data-stu-id="62b20-191">Forbidden</span></span> | <span data-ttu-id="62b20-192">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="62b20-192">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="62b20-193">404</span><span class="sxs-lookup"><span data-stu-id="62b20-193">404</span></span>| <span data-ttu-id="62b20-194">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="62b20-194">Not Found</span></span> | <span data-ttu-id="62b20-195">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="62b20-195">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="62b20-196">406</span><span class="sxs-lookup"><span data-stu-id="62b20-196">406</span></span>| <span data-ttu-id="62b20-197">許容できません。</span><span class="sxs-lookup"><span data-stu-id="62b20-197">Not Acceptable</span></span> | <span data-ttu-id="62b20-198">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="62b20-198">Resource version is not supported.</span></span>| 
| <span data-ttu-id="62b20-199">408</span><span class="sxs-lookup"><span data-stu-id="62b20-199">408</span></span>| <span data-ttu-id="62b20-200">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="62b20-200">Request Timeout</span></span> | <span data-ttu-id="62b20-201">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="62b20-201">The request took too long to complete.</span></span>| 
| <span data-ttu-id="62b20-202">500</span><span class="sxs-lookup"><span data-stu-id="62b20-202">500</span></span>| <span data-ttu-id="62b20-203">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="62b20-203">Internal Server Error</span></span> | <span data-ttu-id="62b20-204">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="62b20-204">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="62b20-205">503</span><span class="sxs-lookup"><span data-stu-id="62b20-205">503</span></span>| <span data-ttu-id="62b20-206">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="62b20-206">Service Unavailable</span></span> | <span data-ttu-id="62b20-207">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="62b20-207">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EDDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="62b20-208">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-208">Response Headers</span></span>
 
| <span data-ttu-id="62b20-209">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="62b20-209">Header</span></span>| <span data-ttu-id="62b20-210">説明</span><span class="sxs-lookup"><span data-stu-id="62b20-210">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="62b20-211">ETag</span><span class="sxs-lookup"><span data-stu-id="62b20-211">ETag</span></span>| <span data-ttu-id="62b20-212">ETag は、web サーバーの URL で見つかったリソースの特定のバージョンによって割り当てられる不透明な識別子です。</span><span class="sxs-lookup"><span data-stu-id="62b20-212">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="62b20-213">その URL でリソースのコンテンツが変更された場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="62b20-213">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="62b20-214">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="62b20-214">Content-Range</span></span>| <span data-ttu-id="62b20-215">これには、部分的なダウンロードはでしたが、このヘッダーは、ダウンロードされたバイト数の範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="62b20-215">If this was a partial download, this header specifies the range of bytes downloaded.</span></span>| 
  
<a id="ID4EGEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="62b20-216">応答本文</span><span class="sxs-lookup"><span data-stu-id="62b20-216">Response body</span></span>
 
<span data-ttu-id="62b20-217">呼び出しが成功した場合は、サービスは、ファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="62b20-217">If the call is successful, the service will return the contents of the file.</span></span>
  
<a id="ID4EREAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="62b20-218">関連項目</span><span class="sxs-lookup"><span data-stu-id="62b20-218">See also</span></span>
 
<a id="ID4ETEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="62b20-219">Parent</span><span class="sxs-lookup"><span data-stu-id="62b20-219">Parent</span></span>  

[<span data-ttu-id="62b20-220">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="62b20-220">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

  
<a id="ID4E6EAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="62b20-221">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="62b20-221">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

   