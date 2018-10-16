---
title: GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
assetID: eef3c530-2f56-442a-fa47-f459a77f5798
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype-get.html
author: KevinAsgari
description: " GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 747381d7a62e206e5a99e1426f1d7aa01d4343d4
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4619848"
---
# <a name="get-sessionssessionidscidssciddatapathandfilenametype"></a><span data-ttu-id="e9552-104">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="e9552-104">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="e9552-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="e9552-105">Downloads a file.</span></span> <span data-ttu-id="e9552-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e9552-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e9552-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9552-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="e9552-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="e9552-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="e9552-109">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9552-109">Optional Query String Parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="e9552-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-110">Required Request Headers</span></span>](#ID4EQC)
  * [<span data-ttu-id="e9552-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-111">Optional Request Headers</span></span>](#ID4EZD)
  * [<span data-ttu-id="e9552-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="e9552-112">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="e9552-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e9552-113">HTTP status codes</span></span>](#ID4EQF)
  * [<span data-ttu-id="e9552-114">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-114">Response Headers</span></span>](#ID4EDDAC)
  * [<span data-ttu-id="e9552-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="e9552-115">Response body</span></span>](#ID4EGEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e9552-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9552-116">URI parameters</span></span>
 
| <span data-ttu-id="e9552-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9552-117">Parameter</span></span>| <span data-ttu-id="e9552-118">型</span><span class="sxs-lookup"><span data-stu-id="e9552-118">Type</span></span>| <span data-ttu-id="e9552-119">説明</span><span class="sxs-lookup"><span data-stu-id="e9552-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e9552-120">sessionId</span><span class="sxs-lookup"><span data-stu-id="e9552-120">sessionId</span></span>| <span data-ttu-id="e9552-121">string</span><span class="sxs-lookup"><span data-stu-id="e9552-121">string</span></span>| <span data-ttu-id="e9552-122">検索するセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="e9552-122">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="e9552-123">scid</span><span class="sxs-lookup"><span data-stu-id="e9552-123">scid</span></span>| <span data-ttu-id="e9552-124">guid</span><span class="sxs-lookup"><span data-stu-id="e9552-124">guid</span></span>| <span data-ttu-id="e9552-125">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="e9552-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="e9552-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="e9552-126">pathAndFileName</span></span>| <span data-ttu-id="e9552-127">string</span><span class="sxs-lookup"><span data-stu-id="e9552-127">string</span></span>| <span data-ttu-id="e9552-128">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="e9552-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="e9552-129">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="e9552-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="e9552-130">ファイル名を空にする可能性がありますはいない期間の終了または 2 つの連続したピリオドは。</span><span class="sxs-lookup"><span data-stu-id="e9552-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="e9552-131">type</span><span class="sxs-lookup"><span data-stu-id="e9552-131">type</span></span>| <span data-ttu-id="e9552-132">文字列</span><span class="sxs-lookup"><span data-stu-id="e9552-132">string</span></span>| <span data-ttu-id="e9552-133">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="e9552-133">The format of the data.</span></span> <span data-ttu-id="e9552-134">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="e9552-134">Possible values are binary or json.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="e9552-135">Authorization</span><span class="sxs-lookup"><span data-stu-id="e9552-135">Authorization</span></span> 
 
<span data-ttu-id="e9552-136">要求は、有効な Xbox LIVE の承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e9552-136">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="e9552-137">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="e9552-137">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="e9552-138">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="e9552-138">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="e9552-139">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9552-139">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="e9552-140">Blob の種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="e9552-140">Varies by blob type.</span></span> <span data-ttu-id="e9552-141">バイナリ blob には、クエリ パラメーターをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="e9552-141">Binary blobs do not support query parameters.</span></span>
 
| <span data-ttu-id="e9552-142">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e9552-142">Parameter</span></span>| <span data-ttu-id="e9552-143">型</span><span class="sxs-lookup"><span data-stu-id="e9552-143">Type</span></span>| <span data-ttu-id="e9552-144">説明</span><span class="sxs-lookup"><span data-stu-id="e9552-144">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9552-145">選択</span><span class="sxs-lookup"><span data-stu-id="e9552-145">select</span></span>| <span data-ttu-id="e9552-146">string</span><span class="sxs-lookup"><span data-stu-id="e9552-146">string</span></span>| <span data-ttu-id="e9552-147">型は json ときにのみ使用します。</span><span class="sxs-lookup"><span data-stu-id="e9552-147">Only usable when type is json.</span></span> <span data-ttu-id="e9552-148">応答する必要がありますのみを含む特定プロパティ/値、JSON のこのパラメーターによって決定されるを指定します。</span><span class="sxs-lookup"><span data-stu-id="e9552-148">Specifies that the response should only contain a certain property/value of the JSON, as determined by this parameter.</span></span> <span data-ttu-id="e9552-149">「ドット」(.) を使用して、サブプロパティ、角かっこを指定 ('['、']') 配列のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="e9552-149">Use a "dot" (.) to specify sub-properties and square brackets ('[' and ']') to specify array indices.</span></span> <span data-ttu-id="e9552-150">たとえば、"配列 1 [4] .prop2"配列「1」配列のインデックス 4 の"prop2"プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="e9552-150">For example, "array1[4].prop2" specifies the "prop2" property of index 4 of the "array1" array.</span></span>| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e9552-151">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-151">Required Request Headers</span></span>
 
| <span data-ttu-id="e9552-152">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-152">Header</span></span>| <span data-ttu-id="e9552-153">設定値</span><span class="sxs-lookup"><span data-stu-id="e9552-153">Value</span></span>| <span data-ttu-id="e9552-154">説明</span><span class="sxs-lookup"><span data-stu-id="e9552-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9552-155">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="e9552-155">x-xbl-contract-version</span></span>| <span data-ttu-id="e9552-156">1</span><span class="sxs-lookup"><span data-stu-id="e9552-156">1</span></span>| <span data-ttu-id="e9552-157">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="e9552-157">API contract version.</span></span>| 
| <span data-ttu-id="e9552-158">Authorization</span><span class="sxs-lookup"><span data-stu-id="e9552-158">Authorization</span></span>| <span data-ttu-id="e9552-159">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="e9552-159">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="e9552-160">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="e9552-160">STS authentication token.</span></span> <span data-ttu-id="e9552-161">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="e9552-161">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="e9552-162">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e9552-162">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="e9552-163">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-163">Optional Request Headers</span></span>
 
| <span data-ttu-id="e9552-164">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-164">Header</span></span>| <span data-ttu-id="e9552-165">説明</span><span class="sxs-lookup"><span data-stu-id="e9552-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9552-166">If-Match</span><span class="sxs-lookup"><span data-stu-id="e9552-166">If-Match</span></span>| <span data-ttu-id="e9552-167">操作を完了するにより既存項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="e9552-167">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="e9552-168">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="e9552-168">If-None-Match</span></span>| <span data-ttu-id="e9552-169">操作を完了するには、どのにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="e9552-169">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
| <span data-ttu-id="e9552-170">範囲</span><span class="sxs-lookup"><span data-stu-id="e9552-170">Range</span></span>| <span data-ttu-id="e9552-171">ダウンロードするバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="e9552-171">Specifies the range of bytes to download.</span></span> <span data-ttu-id="e9552-172">標準の HTTP 範囲ヘッダー形式に従います。</span><span class="sxs-lookup"><span data-stu-id="e9552-172">Follows the standard HTTP Range header format.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="e9552-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="e9552-173">Request body</span></span> 
 
<span data-ttu-id="e9552-174">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e9552-174">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EQF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="e9552-175">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e9552-175">HTTP status codes</span></span> 
 
<span data-ttu-id="e9552-176">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e9552-176">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e9552-177">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e9552-177">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="e9552-178">コード</span><span class="sxs-lookup"><span data-stu-id="e9552-178">Code</span></span>| <span data-ttu-id="e9552-179">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="e9552-179">Reason phrase</span></span>| <span data-ttu-id="e9552-180">説明</span><span class="sxs-lookup"><span data-stu-id="e9552-180">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9552-181">200</span><span class="sxs-lookup"><span data-stu-id="e9552-181">200</span></span>| <span data-ttu-id="e9552-182">OK</span><span class="sxs-lookup"><span data-stu-id="e9552-182">OK</span></span> | <span data-ttu-id="e9552-183">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="e9552-183">The request was successful.</span></span>| 
| <span data-ttu-id="e9552-184">201</span><span class="sxs-lookup"><span data-stu-id="e9552-184">201</span></span>| <span data-ttu-id="e9552-185">Created</span><span class="sxs-lookup"><span data-stu-id="e9552-185">Created</span></span> | <span data-ttu-id="e9552-186">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="e9552-186">The entity was created.</span></span>| 
| <span data-ttu-id="e9552-187">400</span><span class="sxs-lookup"><span data-stu-id="e9552-187">400</span></span>| <span data-ttu-id="e9552-188">Bad Request</span><span class="sxs-lookup"><span data-stu-id="e9552-188">Bad Request</span></span> | <span data-ttu-id="e9552-189">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e9552-189">Service could not understand malformed request.</span></span> <span data-ttu-id="e9552-190">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="e9552-190">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="e9552-191">401</span><span class="sxs-lookup"><span data-stu-id="e9552-191">401</span></span>| <span data-ttu-id="e9552-192">権限がありません</span><span class="sxs-lookup"><span data-stu-id="e9552-192">Unauthorized</span></span> | <span data-ttu-id="e9552-193">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="e9552-193">The request requires user authentication.</span></span>| 
| <span data-ttu-id="e9552-194">403</span><span class="sxs-lookup"><span data-stu-id="e9552-194">403</span></span>| <span data-ttu-id="e9552-195">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e9552-195">Forbidden</span></span> | <span data-ttu-id="e9552-196">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="e9552-196">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="e9552-197">404</span><span class="sxs-lookup"><span data-stu-id="e9552-197">404</span></span>| <span data-ttu-id="e9552-198">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="e9552-198">Not Found</span></span> | <span data-ttu-id="e9552-199">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="e9552-199">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="e9552-200">406</span><span class="sxs-lookup"><span data-stu-id="e9552-200">406</span></span>| <span data-ttu-id="e9552-201">許容できません。</span><span class="sxs-lookup"><span data-stu-id="e9552-201">Not Acceptable</span></span> | <span data-ttu-id="e9552-202">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e9552-202">Resource version is not supported.</span></span>| 
| <span data-ttu-id="e9552-203">408</span><span class="sxs-lookup"><span data-stu-id="e9552-203">408</span></span>| <span data-ttu-id="e9552-204">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="e9552-204">Request Timeout</span></span> | <span data-ttu-id="e9552-205">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="e9552-205">The request took too long to complete.</span></span>| 
| <span data-ttu-id="e9552-206">500</span><span class="sxs-lookup"><span data-stu-id="e9552-206">500</span></span>| <span data-ttu-id="e9552-207">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="e9552-207">Internal Server Error</span></span> | <span data-ttu-id="e9552-208">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="e9552-208">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="e9552-209">503</span><span class="sxs-lookup"><span data-stu-id="e9552-209">503</span></span>| <span data-ttu-id="e9552-210">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="e9552-210">Service Unavailable</span></span> | <span data-ttu-id="e9552-211">要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="e9552-211">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EDDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="e9552-212">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-212">Response Headers</span></span>
 
| <span data-ttu-id="e9552-213">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e9552-213">Header</span></span>| <span data-ttu-id="e9552-214">説明</span><span class="sxs-lookup"><span data-stu-id="e9552-214">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9552-215">ETag</span><span class="sxs-lookup"><span data-stu-id="e9552-215">ETag</span></span>| <span data-ttu-id="e9552-216">ETag は、web サーバーの URL で見つかったリソースの特定のバージョンによって割り当てられる不透明な識別子です。</span><span class="sxs-lookup"><span data-stu-id="e9552-216">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="e9552-217">その URL でリソースのコンテンツが変更された場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="e9552-217">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="e9552-218">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="e9552-218">Content-Range</span></span>| <span data-ttu-id="e9552-219">これが、部分ダウンロードである場合、このヘッダーは、ダウンロードされたバイト数の範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="e9552-219">If this was a partial download, this header specifies the range of bytes downloaded.</span></span>| 
  
<a id="ID4EGEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="e9552-220">応答本文</span><span class="sxs-lookup"><span data-stu-id="e9552-220">Response body</span></span>
 
<span data-ttu-id="e9552-221">呼び出しが成功した場合は、サービスは、ファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="e9552-221">If the call is successful, the service will return the contents of the file.</span></span>
  
<a id="ID4EREAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e9552-222">関連項目</span><span class="sxs-lookup"><span data-stu-id="e9552-222">See also</span></span>
 
<a id="ID4ETEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e9552-223">Parent</span><span class="sxs-lookup"><span data-stu-id="e9552-223">Parent</span></span>  

[<span data-ttu-id="e9552-224">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="e9552-224">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype.md)

  
<a id="ID4E6EAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="e9552-225">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="e9552-225">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

   