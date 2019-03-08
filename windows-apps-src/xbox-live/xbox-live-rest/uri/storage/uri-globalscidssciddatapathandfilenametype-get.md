---
title: GET (/global/scids/{scid}/data/{pathAndFileName},{type})
assetID: 5ca8e0dd-3c45-1b7b-022e-d5d61414fd7d
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapathandfilenametype-get.html
description: " GET (/global/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c7d83d6ee4b0b3787fe86c3ff21e64e6524d2a25
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628007"
---
# <a name="get-globalscidssciddatapathandfilenametype"></a><span data-ttu-id="e1379-104">GET (/global/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="e1379-104">GET (/global/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="e1379-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="e1379-105">Downloads a file.</span></span> <span data-ttu-id="e1379-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e1379-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e1379-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e1379-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="e1379-108">承認</span><span class="sxs-lookup"><span data-stu-id="e1379-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="e1379-109">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e1379-109">Optional Query String Parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="e1379-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e1379-110">Required Request Headers</span></span>](#ID4EZC)
  * [<span data-ttu-id="e1379-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e1379-111">Optional Request Headers</span></span>](#ID4ECE)
  * [<span data-ttu-id="e1379-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="e1379-112">Request body</span></span>](#ID4EMF)
  * [<span data-ttu-id="e1379-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e1379-113">HTTP status codes</span></span>](#ID4EZF)
  * [<span data-ttu-id="e1379-114">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e1379-114">Response Headers</span></span>](#ID4EMDAC)
  * [<span data-ttu-id="e1379-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="e1379-115">Response body</span></span>](#ID4EPEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e1379-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e1379-116">URI parameters</span></span>
 
| <span data-ttu-id="e1379-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e1379-117">Parameter</span></span>| <span data-ttu-id="e1379-118">種類</span><span class="sxs-lookup"><span data-stu-id="e1379-118">Type</span></span>| <span data-ttu-id="e1379-119">説明</span><span class="sxs-lookup"><span data-stu-id="e1379-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e1379-120">scid</span><span class="sxs-lookup"><span data-stu-id="e1379-120">scid</span></span>| <span data-ttu-id="e1379-121">guid</span><span class="sxs-lookup"><span data-stu-id="e1379-121">guid</span></span>| <span data-ttu-id="e1379-122">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="e1379-122">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="e1379-123">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="e1379-123">pathAndFileName</span></span>| <span data-ttu-id="e1379-124">string</span><span class="sxs-lookup"><span data-stu-id="e1379-124">string</span></span>| <span data-ttu-id="e1379-125">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="e1379-125">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="e1379-126">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="e1379-126">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="e1379-127">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="e1379-127">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="e1379-128">type</span><span class="sxs-lookup"><span data-stu-id="e1379-128">type</span></span>| <span data-ttu-id="e1379-129">string</span><span class="sxs-lookup"><span data-stu-id="e1379-129">string</span></span>| <span data-ttu-id="e1379-130">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="e1379-130">The format of the data.</span></span> <span data-ttu-id="e1379-131">指定できる値は。 バイナリ、構成、または json です。</span><span class="sxs-lookup"><span data-stu-id="e1379-131">Possible values are: binary, config or json.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="e1379-132">Authorization</span><span class="sxs-lookup"><span data-stu-id="e1379-132">Authorization</span></span> 
 
<span data-ttu-id="e1379-133">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e1379-133">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="e1379-134">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="e1379-134">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="e1379-135">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="e1379-135">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="e1379-136">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e1379-136">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="e1379-137">Blob の種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="e1379-137">Varies by blob type.</span></span> <span data-ttu-id="e1379-138">バイナリの blob は、クエリ パラメーターをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="e1379-138">Binary blobs do not support query parameters.</span></span>
 
| <span data-ttu-id="e1379-139">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e1379-139">Parameter</span></span>| <span data-ttu-id="e1379-140">種類</span><span class="sxs-lookup"><span data-stu-id="e1379-140">Type</span></span>| <span data-ttu-id="e1379-141">説明</span><span class="sxs-lookup"><span data-stu-id="e1379-141">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e1379-142">選択</span><span class="sxs-lookup"><span data-stu-id="e1379-142">select</span></span>| <span data-ttu-id="e1379-143">string</span><span class="sxs-lookup"><span data-stu-id="e1379-143">string</span></span>| <span data-ttu-id="e1379-144">型が json である場合のみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="e1379-144">Only usable when type is json.</span></span> <span data-ttu-id="e1379-145">応答する必要がありますだけを格納するプロパティ/の特定の値、JSON では、このパラメーターによって決定されるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="e1379-145">Specifies that the response should only contain a certain property/value of the JSON, as determined by this parameter.</span></span> <span data-ttu-id="e1379-146">「ドット」(.) を使用して、サブプロパティと角かっこ ('[' と ']') 配列のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="e1379-146">Use a "dot" (.) to specify sub-properties and square brackets ('[' and ']') to specify array indices.</span></span> <span data-ttu-id="e1379-147">たとえば、"配列 1 [4] .prop2"配列「1」配列のインデックス 4 の"prop2"プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="e1379-147">For example, "array1[4].prop2" specifies the "prop2" property of index 4 of the "array1" array.</span></span>| 
| <span data-ttu-id="e1379-148">customSelector</span><span class="sxs-lookup"><span data-stu-id="e1379-148">customSelector</span></span>| <span data-ttu-id="e1379-149">string</span><span class="sxs-lookup"><span data-stu-id="e1379-149">string</span></span>| <span data-ttu-id="e1379-150">タイプ ファイルを構成します。</span><span class="sxs-lookup"><span data-stu-id="e1379-150">For config type files.</span></span> <span data-ttu-id="e1379-151">どのようなカスタムの仮想ノードを含めることを示します。</span><span class="sxs-lookup"><span data-stu-id="e1379-151">Indicates what custom virtual nodes to include.</span></span> <span data-ttu-id="e1379-152">構成の種類のファイルの詳細については、タイトルのストレージを参照してください。</span><span class="sxs-lookup"><span data-stu-id="e1379-152">See Title Storage for more information on config type files.</span></span>| 
  
<a id="ID4EZC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e1379-153">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e1379-153">Required Request Headers</span></span>
 
| <span data-ttu-id="e1379-154">Header</span><span class="sxs-lookup"><span data-stu-id="e1379-154">Header</span></span>| <span data-ttu-id="e1379-155">Value</span><span class="sxs-lookup"><span data-stu-id="e1379-155">Value</span></span>| <span data-ttu-id="e1379-156">説明</span><span class="sxs-lookup"><span data-stu-id="e1379-156">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e1379-157">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="e1379-157">x-xbl-contract-version</span></span>| <span data-ttu-id="e1379-158">1</span><span class="sxs-lookup"><span data-stu-id="e1379-158">1</span></span>| <span data-ttu-id="e1379-159">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="e1379-159">API contract version.</span></span>| 
| <span data-ttu-id="e1379-160">Authorization</span><span class="sxs-lookup"><span data-stu-id="e1379-160">Authorization</span></span>| <span data-ttu-id="e1379-161">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="e1379-161">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="e1379-162">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="e1379-162">STS authentication token.</span></span> <span data-ttu-id="e1379-163">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="e1379-163">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="e1379-164">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e1379-164">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4ECE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="e1379-165">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e1379-165">Optional Request Headers</span></span>
 
| <span data-ttu-id="e1379-166">Header</span><span class="sxs-lookup"><span data-stu-id="e1379-166">Header</span></span>| <span data-ttu-id="e1379-167">説明</span><span class="sxs-lookup"><span data-stu-id="e1379-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e1379-168">If-Match</span><span class="sxs-lookup"><span data-stu-id="e1379-168">If-Match</span></span>| <span data-ttu-id="e1379-169">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="e1379-169">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="e1379-170">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="e1379-170">If-None-Match</span></span>| <span data-ttu-id="e1379-171">操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="e1379-171">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
| <span data-ttu-id="e1379-172">範囲</span><span class="sxs-lookup"><span data-stu-id="e1379-172">Range</span></span>| <span data-ttu-id="e1379-173">ダウンロードするバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="e1379-173">Specifies the range of bytes to download.</span></span> <span data-ttu-id="e1379-174">標準の HTTP 範囲ヘッダーの形式に従います。</span><span class="sxs-lookup"><span data-stu-id="e1379-174">Follows the standard HTTP Range header format.</span></span>| 
  
<a id="ID4EMF"></a>

 
## <a name="request-body"></a><span data-ttu-id="e1379-175">要求本文</span><span class="sxs-lookup"><span data-stu-id="e1379-175">Request body</span></span> 
 
<span data-ttu-id="e1379-176">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e1379-176">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EZF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="e1379-177">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e1379-177">HTTP status codes</span></span> 
 
<span data-ttu-id="e1379-178">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e1379-178">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e1379-179">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="e1379-179">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="e1379-180">コード</span><span class="sxs-lookup"><span data-stu-id="e1379-180">Code</span></span>| <span data-ttu-id="e1379-181">理由語句</span><span class="sxs-lookup"><span data-stu-id="e1379-181">Reason phrase</span></span>| <span data-ttu-id="e1379-182">説明</span><span class="sxs-lookup"><span data-stu-id="e1379-182">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e1379-183">200</span><span class="sxs-lookup"><span data-stu-id="e1379-183">200</span></span>| <span data-ttu-id="e1379-184">OK</span><span class="sxs-lookup"><span data-stu-id="e1379-184">OK</span></span> | <span data-ttu-id="e1379-185">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="e1379-185">The request was successful.</span></span>| 
| <span data-ttu-id="e1379-186">201</span><span class="sxs-lookup"><span data-stu-id="e1379-186">201</span></span>| <span data-ttu-id="e1379-187">作成日</span><span class="sxs-lookup"><span data-stu-id="e1379-187">Created</span></span> | <span data-ttu-id="e1379-188">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="e1379-188">The entity was created.</span></span>| 
| <span data-ttu-id="e1379-189">400</span><span class="sxs-lookup"><span data-stu-id="e1379-189">400</span></span>| <span data-ttu-id="e1379-190">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="e1379-190">Bad Request</span></span> | <span data-ttu-id="e1379-191">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="e1379-191">Service could not understand malformed request.</span></span> <span data-ttu-id="e1379-192">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="e1379-192">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="e1379-193">401</span><span class="sxs-lookup"><span data-stu-id="e1379-193">401</span></span>| <span data-ttu-id="e1379-194">権限がありません</span><span class="sxs-lookup"><span data-stu-id="e1379-194">Unauthorized</span></span> | <span data-ttu-id="e1379-195">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="e1379-195">The request requires user authentication.</span></span>| 
| <span data-ttu-id="e1379-196">403</span><span class="sxs-lookup"><span data-stu-id="e1379-196">403</span></span>| <span data-ttu-id="e1379-197">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e1379-197">Forbidden</span></span> | <span data-ttu-id="e1379-198">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="e1379-198">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="e1379-199">404</span><span class="sxs-lookup"><span data-stu-id="e1379-199">404</span></span>| <span data-ttu-id="e1379-200">検出不可</span><span class="sxs-lookup"><span data-stu-id="e1379-200">Not Found</span></span> | <span data-ttu-id="e1379-201">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="e1379-201">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="e1379-202">406</span><span class="sxs-lookup"><span data-stu-id="e1379-202">406</span></span>| <span data-ttu-id="e1379-203">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="e1379-203">Not Acceptable</span></span> | <span data-ttu-id="e1379-204">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e1379-204">Resource version is not supported.</span></span>| 
| <span data-ttu-id="e1379-205">408</span><span class="sxs-lookup"><span data-stu-id="e1379-205">408</span></span>| <span data-ttu-id="e1379-206">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="e1379-206">Request Timeout</span></span> | <span data-ttu-id="e1379-207">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="e1379-207">The request took too long to complete.</span></span>| 
| <span data-ttu-id="e1379-208">500</span><span class="sxs-lookup"><span data-stu-id="e1379-208">500</span></span>| <span data-ttu-id="e1379-209">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="e1379-209">Internal Server Error</span></span> | <span data-ttu-id="e1379-210">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="e1379-210">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="e1379-211">503</span><span class="sxs-lookup"><span data-stu-id="e1379-211">503</span></span>| <span data-ttu-id="e1379-212">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="e1379-212">Service Unavailable</span></span> | <span data-ttu-id="e1379-213">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="e1379-213">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EMDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="e1379-214">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e1379-214">Response Headers</span></span>
 
| <span data-ttu-id="e1379-215">Header</span><span class="sxs-lookup"><span data-stu-id="e1379-215">Header</span></span>| <span data-ttu-id="e1379-216">説明</span><span class="sxs-lookup"><span data-stu-id="e1379-216">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e1379-217">ETag</span><span class="sxs-lookup"><span data-stu-id="e1379-217">ETag</span></span>| <span data-ttu-id="e1379-218">ETag は、URL にあるリソースの特定のバージョンの web サーバーによって割り当てられた非透過識別子です。</span><span class="sxs-lookup"><span data-stu-id="e1379-218">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="e1379-219">その URL でリソースのコンテンツが変わる場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="e1379-219">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="e1379-220">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="e1379-220">Content-Range</span></span>| <span data-ttu-id="e1379-221">これが部分的なダウンロードである場合、このヘッダーは、ダウンロードされるバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="e1379-221">If this was a partial download, this header specifies the range of bytes downloaded.</span></span>| 
  
<a id="ID4EPEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="e1379-222">応答本文</span><span class="sxs-lookup"><span data-stu-id="e1379-222">Response body</span></span>
<span data-ttu-id="e1379-223">呼び出しが成功した場合、サービスは、ファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="e1379-223">If the call is successful, the service will return the contents of the file.</span></span>  
<a id="ID4EYEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e1379-224">関連項目</span><span class="sxs-lookup"><span data-stu-id="e1379-224">See also</span></span>
 
<a id="ID4E1EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e1379-225">Parent</span><span class="sxs-lookup"><span data-stu-id="e1379-225">Parent</span></span>  

[<span data-ttu-id="e1379-226">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="e1379-226">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-globalscidssciddatapathandfilenametype.md)

  
<a id="ID4EGFAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="e1379-227">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="e1379-227">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

   