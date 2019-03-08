---
title: GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
assetID: eef3c530-2f56-442a-fa47-f459a77f5798
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype-get.html
description: " GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5e97a193e4f821b9fcd31b26d3d023929f1dfda8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57661927"
---
# <a name="get-sessionssessionidscidssciddatapathandfilenametype"></a><span data-ttu-id="53edb-104">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="53edb-104">GET (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="53edb-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="53edb-105">Downloads a file.</span></span> <span data-ttu-id="53edb-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="53edb-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="53edb-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="53edb-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="53edb-108">承認</span><span class="sxs-lookup"><span data-stu-id="53edb-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="53edb-109">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="53edb-109">Optional Query String Parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="53edb-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="53edb-110">Required Request Headers</span></span>](#ID4EQC)
  * [<span data-ttu-id="53edb-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="53edb-111">Optional Request Headers</span></span>](#ID4EZD)
  * [<span data-ttu-id="53edb-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="53edb-112">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="53edb-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="53edb-113">HTTP status codes</span></span>](#ID4EQF)
  * [<span data-ttu-id="53edb-114">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="53edb-114">Response Headers</span></span>](#ID4EDDAC)
  * [<span data-ttu-id="53edb-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="53edb-115">Response body</span></span>](#ID4EGEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="53edb-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="53edb-116">URI parameters</span></span>
 
| <span data-ttu-id="53edb-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="53edb-117">Parameter</span></span>| <span data-ttu-id="53edb-118">種類</span><span class="sxs-lookup"><span data-stu-id="53edb-118">Type</span></span>| <span data-ttu-id="53edb-119">説明</span><span class="sxs-lookup"><span data-stu-id="53edb-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="53edb-120">sessionId</span><span class="sxs-lookup"><span data-stu-id="53edb-120">sessionId</span></span>| <span data-ttu-id="53edb-121">string</span><span class="sxs-lookup"><span data-stu-id="53edb-121">string</span></span>| <span data-ttu-id="53edb-122">検索する、セッションの ID。</span><span class="sxs-lookup"><span data-stu-id="53edb-122">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="53edb-123">scid</span><span class="sxs-lookup"><span data-stu-id="53edb-123">scid</span></span>| <span data-ttu-id="53edb-124">guid</span><span class="sxs-lookup"><span data-stu-id="53edb-124">guid</span></span>| <span data-ttu-id="53edb-125">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="53edb-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="53edb-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="53edb-126">pathAndFileName</span></span>| <span data-ttu-id="53edb-127">string</span><span class="sxs-lookup"><span data-stu-id="53edb-127">string</span></span>| <span data-ttu-id="53edb-128">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="53edb-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="53edb-129">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="53edb-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="53edb-130">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="53edb-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="53edb-131">type</span><span class="sxs-lookup"><span data-stu-id="53edb-131">type</span></span>| <span data-ttu-id="53edb-132">string</span><span class="sxs-lookup"><span data-stu-id="53edb-132">string</span></span>| <span data-ttu-id="53edb-133">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="53edb-133">The format of the data.</span></span> <span data-ttu-id="53edb-134">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="53edb-134">Possible values are binary or json.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="53edb-135">Authorization</span><span class="sxs-lookup"><span data-stu-id="53edb-135">Authorization</span></span> 
 
<span data-ttu-id="53edb-136">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="53edb-136">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="53edb-137">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="53edb-137">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="53edb-138">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="53edb-138">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="53edb-139">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="53edb-139">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="53edb-140">Blob の種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="53edb-140">Varies by blob type.</span></span> <span data-ttu-id="53edb-141">バイナリの blob は、クエリ パラメーターをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="53edb-141">Binary blobs do not support query parameters.</span></span>
 
| <span data-ttu-id="53edb-142">パラメーター</span><span class="sxs-lookup"><span data-stu-id="53edb-142">Parameter</span></span>| <span data-ttu-id="53edb-143">種類</span><span class="sxs-lookup"><span data-stu-id="53edb-143">Type</span></span>| <span data-ttu-id="53edb-144">説明</span><span class="sxs-lookup"><span data-stu-id="53edb-144">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="53edb-145">選択</span><span class="sxs-lookup"><span data-stu-id="53edb-145">select</span></span>| <span data-ttu-id="53edb-146">string</span><span class="sxs-lookup"><span data-stu-id="53edb-146">string</span></span>| <span data-ttu-id="53edb-147">型が json である場合のみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="53edb-147">Only usable when type is json.</span></span> <span data-ttu-id="53edb-148">応答する必要がありますだけを格納するプロパティ/の特定の値、JSON では、このパラメーターによって決定されるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="53edb-148">Specifies that the response should only contain a certain property/value of the JSON, as determined by this parameter.</span></span> <span data-ttu-id="53edb-149">「ドット」(.) を使用して、サブプロパティと角かっこ ('[' と ']') 配列のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="53edb-149">Use a "dot" (.) to specify sub-properties and square brackets ('[' and ']') to specify array indices.</span></span> <span data-ttu-id="53edb-150">たとえば、"配列 1 [4] .prop2"配列「1」配列のインデックス 4 の"prop2"プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="53edb-150">For example, "array1[4].prop2" specifies the "prop2" property of index 4 of the "array1" array.</span></span>| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="53edb-151">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="53edb-151">Required Request Headers</span></span>
 
| <span data-ttu-id="53edb-152">Header</span><span class="sxs-lookup"><span data-stu-id="53edb-152">Header</span></span>| <span data-ttu-id="53edb-153">Value</span><span class="sxs-lookup"><span data-stu-id="53edb-153">Value</span></span>| <span data-ttu-id="53edb-154">説明</span><span class="sxs-lookup"><span data-stu-id="53edb-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="53edb-155">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="53edb-155">x-xbl-contract-version</span></span>| <span data-ttu-id="53edb-156">1</span><span class="sxs-lookup"><span data-stu-id="53edb-156">1</span></span>| <span data-ttu-id="53edb-157">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="53edb-157">API contract version.</span></span>| 
| <span data-ttu-id="53edb-158">Authorization</span><span class="sxs-lookup"><span data-stu-id="53edb-158">Authorization</span></span>| <span data-ttu-id="53edb-159">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="53edb-159">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="53edb-160">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="53edb-160">STS authentication token.</span></span> <span data-ttu-id="53edb-161">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="53edb-161">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="53edb-162">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="53edb-162">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="53edb-163">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="53edb-163">Optional Request Headers</span></span>
 
| <span data-ttu-id="53edb-164">Header</span><span class="sxs-lookup"><span data-stu-id="53edb-164">Header</span></span>| <span data-ttu-id="53edb-165">説明</span><span class="sxs-lookup"><span data-stu-id="53edb-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="53edb-166">If-Match</span><span class="sxs-lookup"><span data-stu-id="53edb-166">If-Match</span></span>| <span data-ttu-id="53edb-167">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="53edb-167">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="53edb-168">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="53edb-168">If-None-Match</span></span>| <span data-ttu-id="53edb-169">操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="53edb-169">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
| <span data-ttu-id="53edb-170">範囲</span><span class="sxs-lookup"><span data-stu-id="53edb-170">Range</span></span>| <span data-ttu-id="53edb-171">ダウンロードするバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="53edb-171">Specifies the range of bytes to download.</span></span> <span data-ttu-id="53edb-172">標準の HTTP 範囲ヘッダーの形式に従います。</span><span class="sxs-lookup"><span data-stu-id="53edb-172">Follows the standard HTTP Range header format.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="53edb-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="53edb-173">Request body</span></span> 
 
<span data-ttu-id="53edb-174">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="53edb-174">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EQF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="53edb-175">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="53edb-175">HTTP status codes</span></span> 
 
<span data-ttu-id="53edb-176">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="53edb-176">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="53edb-177">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="53edb-177">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="53edb-178">コード</span><span class="sxs-lookup"><span data-stu-id="53edb-178">Code</span></span>| <span data-ttu-id="53edb-179">理由語句</span><span class="sxs-lookup"><span data-stu-id="53edb-179">Reason phrase</span></span>| <span data-ttu-id="53edb-180">説明</span><span class="sxs-lookup"><span data-stu-id="53edb-180">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="53edb-181">200</span><span class="sxs-lookup"><span data-stu-id="53edb-181">200</span></span>| <span data-ttu-id="53edb-182">OK</span><span class="sxs-lookup"><span data-stu-id="53edb-182">OK</span></span> | <span data-ttu-id="53edb-183">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="53edb-183">The request was successful.</span></span>| 
| <span data-ttu-id="53edb-184">201</span><span class="sxs-lookup"><span data-stu-id="53edb-184">201</span></span>| <span data-ttu-id="53edb-185">作成日</span><span class="sxs-lookup"><span data-stu-id="53edb-185">Created</span></span> | <span data-ttu-id="53edb-186">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="53edb-186">The entity was created.</span></span>| 
| <span data-ttu-id="53edb-187">400</span><span class="sxs-lookup"><span data-stu-id="53edb-187">400</span></span>| <span data-ttu-id="53edb-188">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="53edb-188">Bad Request</span></span> | <span data-ttu-id="53edb-189">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="53edb-189">Service could not understand malformed request.</span></span> <span data-ttu-id="53edb-190">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="53edb-190">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="53edb-191">401</span><span class="sxs-lookup"><span data-stu-id="53edb-191">401</span></span>| <span data-ttu-id="53edb-192">権限がありません</span><span class="sxs-lookup"><span data-stu-id="53edb-192">Unauthorized</span></span> | <span data-ttu-id="53edb-193">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="53edb-193">The request requires user authentication.</span></span>| 
| <span data-ttu-id="53edb-194">403</span><span class="sxs-lookup"><span data-stu-id="53edb-194">403</span></span>| <span data-ttu-id="53edb-195">Forbidden</span><span class="sxs-lookup"><span data-stu-id="53edb-195">Forbidden</span></span> | <span data-ttu-id="53edb-196">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="53edb-196">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="53edb-197">404</span><span class="sxs-lookup"><span data-stu-id="53edb-197">404</span></span>| <span data-ttu-id="53edb-198">検出不可</span><span class="sxs-lookup"><span data-stu-id="53edb-198">Not Found</span></span> | <span data-ttu-id="53edb-199">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="53edb-199">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="53edb-200">406</span><span class="sxs-lookup"><span data-stu-id="53edb-200">406</span></span>| <span data-ttu-id="53edb-201">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="53edb-201">Not Acceptable</span></span> | <span data-ttu-id="53edb-202">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="53edb-202">Resource version is not supported.</span></span>| 
| <span data-ttu-id="53edb-203">408</span><span class="sxs-lookup"><span data-stu-id="53edb-203">408</span></span>| <span data-ttu-id="53edb-204">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="53edb-204">Request Timeout</span></span> | <span data-ttu-id="53edb-205">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="53edb-205">The request took too long to complete.</span></span>| 
| <span data-ttu-id="53edb-206">500</span><span class="sxs-lookup"><span data-stu-id="53edb-206">500</span></span>| <span data-ttu-id="53edb-207">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="53edb-207">Internal Server Error</span></span> | <span data-ttu-id="53edb-208">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="53edb-208">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="53edb-209">503</span><span class="sxs-lookup"><span data-stu-id="53edb-209">503</span></span>| <span data-ttu-id="53edb-210">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="53edb-210">Service Unavailable</span></span> | <span data-ttu-id="53edb-211">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="53edb-211">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EDDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="53edb-212">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="53edb-212">Response Headers</span></span>
 
| <span data-ttu-id="53edb-213">Header</span><span class="sxs-lookup"><span data-stu-id="53edb-213">Header</span></span>| <span data-ttu-id="53edb-214">説明</span><span class="sxs-lookup"><span data-stu-id="53edb-214">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="53edb-215">ETag</span><span class="sxs-lookup"><span data-stu-id="53edb-215">ETag</span></span>| <span data-ttu-id="53edb-216">ETag は、URL にあるリソースの特定のバージョンの web サーバーによって割り当てられた非透過識別子です。</span><span class="sxs-lookup"><span data-stu-id="53edb-216">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="53edb-217">その URL でリソースのコンテンツが変わる場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="53edb-217">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="53edb-218">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="53edb-218">Content-Range</span></span>| <span data-ttu-id="53edb-219">これが部分的なダウンロードである場合、このヘッダーは、ダウンロードされるバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="53edb-219">If this was a partial download, this header specifies the range of bytes downloaded.</span></span>| 
  
<a id="ID4EGEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="53edb-220">応答本文</span><span class="sxs-lookup"><span data-stu-id="53edb-220">Response body</span></span>
 
<span data-ttu-id="53edb-221">呼び出しが成功した場合、サービスは、ファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="53edb-221">If the call is successful, the service will return the contents of the file.</span></span>
  
<a id="ID4EREAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="53edb-222">関連項目</span><span class="sxs-lookup"><span data-stu-id="53edb-222">See also</span></span>
 
<a id="ID4ETEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="53edb-223">Parent</span><span class="sxs-lookup"><span data-stu-id="53edb-223">Parent</span></span>  

[<span data-ttu-id="53edb-224">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="53edb-224">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype.md)

  
<a id="ID4E6EAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="53edb-225">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="53edb-225">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

   