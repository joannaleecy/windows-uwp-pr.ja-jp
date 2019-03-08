---
title: GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)
assetID: 229cabc6-3c5c-89e1-47e3-96a7f54094c9
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype-get.html
description: " GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 78933c206111a63a1a928b6d9fcdae43cb4192d4
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622687"
---
# <a name="get-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="c0388-104">GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="c0388-104">GET (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="c0388-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="c0388-105">Downloads a file.</span></span> <span data-ttu-id="c0388-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c0388-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c0388-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c0388-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="c0388-108">承認</span><span class="sxs-lookup"><span data-stu-id="c0388-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="c0388-109">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c0388-109">Optional Query String Parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="c0388-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c0388-110">Required Request Headers</span></span>](#ID4EQC)
  * [<span data-ttu-id="c0388-111">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c0388-111">Optional Request Headers</span></span>](#ID4EZD)
  * [<span data-ttu-id="c0388-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="c0388-112">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="c0388-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c0388-113">HTTP status codes</span></span>](#ID4EQF)
  * [<span data-ttu-id="c0388-114">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c0388-114">Response Headers</span></span>](#ID4EDDAC)
  * [<span data-ttu-id="c0388-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="c0388-115">Response body</span></span>](#ID4EGEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c0388-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c0388-116">URI parameters</span></span>
 
| <span data-ttu-id="c0388-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c0388-117">Parameter</span></span>| <span data-ttu-id="c0388-118">種類</span><span class="sxs-lookup"><span data-stu-id="c0388-118">Type</span></span>| <span data-ttu-id="c0388-119">説明</span><span class="sxs-lookup"><span data-stu-id="c0388-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c0388-120">xuid</span><span class="sxs-lookup"><span data-stu-id="c0388-120">xuid</span></span>| <span data-ttu-id="c0388-121">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c0388-121">unsigned 64-bit integer</span></span>| <span data-ttu-id="c0388-122">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="c0388-122">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="c0388-123">scid</span><span class="sxs-lookup"><span data-stu-id="c0388-123">scid</span></span>| <span data-ttu-id="c0388-124">guid</span><span class="sxs-lookup"><span data-stu-id="c0388-124">guid</span></span>| <span data-ttu-id="c0388-125">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="c0388-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="c0388-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="c0388-126">pathAndFileName</span></span>| <span data-ttu-id="c0388-127">string</span><span class="sxs-lookup"><span data-stu-id="c0388-127">string</span></span>| <span data-ttu-id="c0388-128">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="c0388-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="c0388-129">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="c0388-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="c0388-130">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="c0388-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="c0388-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="c0388-131">Authorization</span></span> 
 
<span data-ttu-id="c0388-132">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="c0388-132">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="c0388-133">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="c0388-133">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="c0388-134">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="c0388-134">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span>
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="c0388-135">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c0388-135">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="c0388-136">Blob の種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="c0388-136">Varies by blob type.</span></span> <span data-ttu-id="c0388-137">バイナリの blob は、クエリ パラメーターをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="c0388-137">Binary blobs do not support query parameters.</span></span>
 
| <span data-ttu-id="c0388-138">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c0388-138">Parameter</span></span>| <span data-ttu-id="c0388-139">種類</span><span class="sxs-lookup"><span data-stu-id="c0388-139">Type</span></span>| <span data-ttu-id="c0388-140">説明</span><span class="sxs-lookup"><span data-stu-id="c0388-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c0388-141">選択</span><span class="sxs-lookup"><span data-stu-id="c0388-141">select</span></span>| <span data-ttu-id="c0388-142">string</span><span class="sxs-lookup"><span data-stu-id="c0388-142">string</span></span>| <span data-ttu-id="c0388-143">型が json である場合のみ使用できます。</span><span class="sxs-lookup"><span data-stu-id="c0388-143">Only usable when type is json.</span></span> <span data-ttu-id="c0388-144">応答する必要がありますだけを格納するプロパティ/の特定の値、JSON では、このパラメーターによって決定されるかを指定します。</span><span class="sxs-lookup"><span data-stu-id="c0388-144">Specifies that the response should only contain a certain property/value of the JSON, as determined by this parameter.</span></span> <span data-ttu-id="c0388-145">「ドット」(.) を使用して、サブプロパティと角かっこ ('[' と ']') 配列のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="c0388-145">Use a "dot" (.) to specify sub-properties and square brackets ('[' and ']') to specify array indices.</span></span> <span data-ttu-id="c0388-146">たとえば、"配列 1 [4] .prop2"配列「1」配列のインデックス 4 の"prop2"プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="c0388-146">For example, "array1[4].prop2" specifies the "prop2" property of index 4 of the "array1" array.</span></span>| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="c0388-147">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c0388-147">Required Request Headers</span></span>
 
| <span data-ttu-id="c0388-148">Header</span><span class="sxs-lookup"><span data-stu-id="c0388-148">Header</span></span>| <span data-ttu-id="c0388-149">Value</span><span class="sxs-lookup"><span data-stu-id="c0388-149">Value</span></span>| <span data-ttu-id="c0388-150">説明</span><span class="sxs-lookup"><span data-stu-id="c0388-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c0388-151">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="c0388-151">x-xbl-contract-version</span></span>| <span data-ttu-id="c0388-152">1</span><span class="sxs-lookup"><span data-stu-id="c0388-152">1</span></span>| <span data-ttu-id="c0388-153">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="c0388-153">API contract version.</span></span>| 
| <span data-ttu-id="c0388-154">Authorization</span><span class="sxs-lookup"><span data-stu-id="c0388-154">Authorization</span></span>| <span data-ttu-id="c0388-155">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="c0388-155">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="c0388-156">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="c0388-156">STS authentication token.</span></span> <span data-ttu-id="c0388-157">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="c0388-157">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="c0388-158">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c0388-158">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="c0388-159">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c0388-159">Optional Request Headers</span></span>
 
| <span data-ttu-id="c0388-160">Header</span><span class="sxs-lookup"><span data-stu-id="c0388-160">Header</span></span>| <span data-ttu-id="c0388-161">説明</span><span class="sxs-lookup"><span data-stu-id="c0388-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c0388-162">If-Match</span><span class="sxs-lookup"><span data-stu-id="c0388-162">If-Match</span></span>| <span data-ttu-id="c0388-163">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="c0388-163">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="c0388-164">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="c0388-164">If-None-Match</span></span>| <span data-ttu-id="c0388-165">操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="c0388-165">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
| <span data-ttu-id="c0388-166">範囲</span><span class="sxs-lookup"><span data-stu-id="c0388-166">Range</span></span>| <span data-ttu-id="c0388-167">ダウンロードするバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="c0388-167">Specifies the range of bytes to download.</span></span> <span data-ttu-id="c0388-168">標準の HTTP 範囲ヘッダーの形式に従います。</span><span class="sxs-lookup"><span data-stu-id="c0388-168">Follows the standard HTTP Range header format.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="c0388-169">要求本文</span><span class="sxs-lookup"><span data-stu-id="c0388-169">Request body</span></span> 
 
<span data-ttu-id="c0388-170">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="c0388-170">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EQF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="c0388-171">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="c0388-171">HTTP status codes</span></span> 
 
<span data-ttu-id="c0388-172">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="c0388-172">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="c0388-173">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="c0388-173">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="c0388-174">コード</span><span class="sxs-lookup"><span data-stu-id="c0388-174">Code</span></span>| <span data-ttu-id="c0388-175">理由語句</span><span class="sxs-lookup"><span data-stu-id="c0388-175">Reason phrase</span></span>| <span data-ttu-id="c0388-176">説明</span><span class="sxs-lookup"><span data-stu-id="c0388-176">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c0388-177">200</span><span class="sxs-lookup"><span data-stu-id="c0388-177">200</span></span>| <span data-ttu-id="c0388-178">OK</span><span class="sxs-lookup"><span data-stu-id="c0388-178">OK</span></span> | <span data-ttu-id="c0388-179">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="c0388-179">The request was successful.</span></span>| 
| <span data-ttu-id="c0388-180">201</span><span class="sxs-lookup"><span data-stu-id="c0388-180">201</span></span>| <span data-ttu-id="c0388-181">作成日</span><span class="sxs-lookup"><span data-stu-id="c0388-181">Created</span></span> | <span data-ttu-id="c0388-182">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="c0388-182">The entity was created.</span></span>| 
| <span data-ttu-id="c0388-183">400</span><span class="sxs-lookup"><span data-stu-id="c0388-183">400</span></span>| <span data-ttu-id="c0388-184">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="c0388-184">Bad Request</span></span> | <span data-ttu-id="c0388-185">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="c0388-185">Service could not understand malformed request.</span></span> <span data-ttu-id="c0388-186">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="c0388-186">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="c0388-187">401</span><span class="sxs-lookup"><span data-stu-id="c0388-187">401</span></span>| <span data-ttu-id="c0388-188">権限がありません</span><span class="sxs-lookup"><span data-stu-id="c0388-188">Unauthorized</span></span> | <span data-ttu-id="c0388-189">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="c0388-189">The request requires user authentication.</span></span>| 
| <span data-ttu-id="c0388-190">403</span><span class="sxs-lookup"><span data-stu-id="c0388-190">403</span></span>| <span data-ttu-id="c0388-191">Forbidden</span><span class="sxs-lookup"><span data-stu-id="c0388-191">Forbidden</span></span> | <span data-ttu-id="c0388-192">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="c0388-192">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="c0388-193">404</span><span class="sxs-lookup"><span data-stu-id="c0388-193">404</span></span>| <span data-ttu-id="c0388-194">検出不可</span><span class="sxs-lookup"><span data-stu-id="c0388-194">Not Found</span></span> | <span data-ttu-id="c0388-195">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c0388-195">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="c0388-196">406</span><span class="sxs-lookup"><span data-stu-id="c0388-196">406</span></span>| <span data-ttu-id="c0388-197">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="c0388-197">Not Acceptable</span></span> | <span data-ttu-id="c0388-198">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c0388-198">Resource version is not supported.</span></span>| 
| <span data-ttu-id="c0388-199">408</span><span class="sxs-lookup"><span data-stu-id="c0388-199">408</span></span>| <span data-ttu-id="c0388-200">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="c0388-200">Request Timeout</span></span> | <span data-ttu-id="c0388-201">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="c0388-201">The request took too long to complete.</span></span>| 
| <span data-ttu-id="c0388-202">500</span><span class="sxs-lookup"><span data-stu-id="c0388-202">500</span></span>| <span data-ttu-id="c0388-203">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="c0388-203">Internal Server Error</span></span> | <span data-ttu-id="c0388-204">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="c0388-204">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="c0388-205">503</span><span class="sxs-lookup"><span data-stu-id="c0388-205">503</span></span>| <span data-ttu-id="c0388-206">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="c0388-206">Service Unavailable</span></span> | <span data-ttu-id="c0388-207">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="c0388-207">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EDDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="c0388-208">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c0388-208">Response Headers</span></span>
 
| <span data-ttu-id="c0388-209">Header</span><span class="sxs-lookup"><span data-stu-id="c0388-209">Header</span></span>| <span data-ttu-id="c0388-210">説明</span><span class="sxs-lookup"><span data-stu-id="c0388-210">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c0388-211">ETag</span><span class="sxs-lookup"><span data-stu-id="c0388-211">ETag</span></span>| <span data-ttu-id="c0388-212">ETag は、URL にあるリソースの特定のバージョンの web サーバーによって割り当てられた非透過識別子です。</span><span class="sxs-lookup"><span data-stu-id="c0388-212">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="c0388-213">その URL でリソースのコンテンツが変わる場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="c0388-213">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="c0388-214">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="c0388-214">Content-Range</span></span>| <span data-ttu-id="c0388-215">これが部分的なダウンロードである場合、このヘッダーは、ダウンロードされるバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="c0388-215">If this was a partial download, this header specifies the range of bytes downloaded.</span></span>| 
  
<a id="ID4EGEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="c0388-216">応答本文</span><span class="sxs-lookup"><span data-stu-id="c0388-216">Response body</span></span>
 
<span data-ttu-id="c0388-217">呼び出しが成功した場合、サービスは、ファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="c0388-217">If the call is successful, the service will return the contents of the file.</span></span>
  
<a id="ID4EREAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c0388-218">関連項目</span><span class="sxs-lookup"><span data-stu-id="c0388-218">See also</span></span>
 
<a id="ID4ETEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c0388-219">Parent</span><span class="sxs-lookup"><span data-stu-id="c0388-219">Parent</span></span>  

[<span data-ttu-id="c0388-220">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="c0388-220">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

  
<a id="ID4E6EAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="c0388-221">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="c0388-221">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

   