---
title: PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
assetID: 40005e52-cd24-38ed-cfed-2c590cc2276f
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype-put.html
description: " PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 95e3c9498de3657093377447deabc76e27a2bd07
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57645757"
---
# <a name="put-sessionssessionidscidssciddatapathandfilenametype"></a><span data-ttu-id="2eac4-104">PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="2eac4-104">PUT (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="2eac4-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="2eac4-105">Uploads a file.</span></span> <span data-ttu-id="2eac4-106">データおよびメタデータが送信される一連の小さなブロックのデータとメタデータが送信される複数のブロックのアップロードや 1 つのメッセージで完全なアップロードには、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="2eac4-106">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="2eac4-107">1 つのメッセージとして 4 メガバイト未満のファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="2eac4-107">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="2eac4-108">データ型の json は、複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="2eac4-108">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="2eac4-109">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-109">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="2eac4-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2eac4-110">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="2eac4-111">承認</span><span class="sxs-lookup"><span data-stu-id="2eac4-111">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="2eac4-112">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="2eac4-112">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="2eac4-113">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2eac4-113">Required Request Headers</span></span>](#ID4ENE)
  * [<span data-ttu-id="2eac4-114">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2eac4-114">Optional Request Headers</span></span>](#ID4EWF)
  * [<span data-ttu-id="2eac4-115">要求本文</span><span class="sxs-lookup"><span data-stu-id="2eac4-115">Request body</span></span>](#ID4EZG)
  * [<span data-ttu-id="2eac4-116">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="2eac4-116">HTTP status codes</span></span>](#ID4EEH)
  * [<span data-ttu-id="2eac4-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="2eac4-117">Response body</span></span>](#ID4EXEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="2eac4-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="2eac4-118">URI parameters</span></span> 
 
| <span data-ttu-id="2eac4-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2eac4-119">Parameter</span></span>| <span data-ttu-id="2eac4-120">種類</span><span class="sxs-lookup"><span data-stu-id="2eac4-120">Type</span></span>| <span data-ttu-id="2eac4-121">説明</span><span class="sxs-lookup"><span data-stu-id="2eac4-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="2eac4-122">sessionId</span><span class="sxs-lookup"><span data-stu-id="2eac4-122">sessionId</span></span>| <span data-ttu-id="2eac4-123">string</span><span class="sxs-lookup"><span data-stu-id="2eac4-123">string</span></span>| <span data-ttu-id="2eac4-124">検索する、セッションの ID。</span><span class="sxs-lookup"><span data-stu-id="2eac4-124">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="2eac4-125">scid</span><span class="sxs-lookup"><span data-stu-id="2eac4-125">scid</span></span>| <span data-ttu-id="2eac4-126">guid</span><span class="sxs-lookup"><span data-stu-id="2eac4-126">guid</span></span>| <span data-ttu-id="2eac4-127">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="2eac4-127">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="2eac4-128">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="2eac4-128">pathAndFileName</span></span>| <span data-ttu-id="2eac4-129">string</span><span class="sxs-lookup"><span data-stu-id="2eac4-129">string</span></span>| <span data-ttu-id="2eac4-130">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="2eac4-130">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="2eac4-131">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="2eac4-131">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="2eac4-132">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="2eac4-132">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="2eac4-133">type</span><span class="sxs-lookup"><span data-stu-id="2eac4-133">type</span></span>| <span data-ttu-id="2eac4-134">string</span><span class="sxs-lookup"><span data-stu-id="2eac4-134">string</span></span>| <span data-ttu-id="2eac4-135">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="2eac4-135">The format of the data.</span></span> <span data-ttu-id="2eac4-136">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="2eac4-136">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="2eac4-137">Authorization</span><span class="sxs-lookup"><span data-stu-id="2eac4-137">Authorization</span></span> 
 
<span data-ttu-id="2eac4-138">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="2eac4-138">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="2eac4-139">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-139">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="2eac4-140">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-140">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="2eac4-141">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="2eac4-141">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="2eac4-142">1 つのメッセージのアップロードは、クエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="2eac4-142">For single message uploads, the query string parameters are:</span></span>
 
| <span data-ttu-id="2eac4-143">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2eac4-143">Parameter</span></span>| <span data-ttu-id="2eac4-144">種類</span><span class="sxs-lookup"><span data-stu-id="2eac4-144">Type</span></span>| <span data-ttu-id="2eac4-145">説明</span><span class="sxs-lookup"><span data-stu-id="2eac4-145">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2eac4-146">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="2eac4-146">clientFileTime</span></span>| <span data-ttu-id="2eac4-147">DateTime</span><span class="sxs-lookup"><span data-stu-id="2eac4-147">DateTime</span></span>| <span data-ttu-id="2eac4-148">どのようなクライアントが最後に、ファイルをアップロード上のファイルの日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="2eac4-148">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="2eac4-149">displayName</span><span class="sxs-lookup"><span data-stu-id="2eac4-149">displayName</span></span>| <span data-ttu-id="2eac4-150">string</span><span class="sxs-lookup"><span data-stu-id="2eac4-150">string</span></span>| <span data-ttu-id="2eac4-151">ユーザーに表示するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="2eac4-151">Name of the file that should be shown to the user.</span></span>| 
 
<span data-ttu-id="2eac4-152">複数のブロックのアップロードは、クエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="2eac4-152">For multi-block uploads, the query string parameters are:</span></span>
 
| <span data-ttu-id="2eac4-153">パラメーター</span><span class="sxs-lookup"><span data-stu-id="2eac4-153">Parameter</span></span>| <span data-ttu-id="2eac4-154">種類</span><span class="sxs-lookup"><span data-stu-id="2eac4-154">Type</span></span>| <span data-ttu-id="2eac4-155">説明</span><span class="sxs-lookup"><span data-stu-id="2eac4-155">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2eac4-156">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="2eac4-156">clientFileTime</span></span>| <span data-ttu-id="2eac4-157">DateTime</span><span class="sxs-lookup"><span data-stu-id="2eac4-157">DateTime</span></span>| <span data-ttu-id="2eac4-158">どのようなクライアントが最後に、ファイルをアップロード上のファイルの日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="2eac4-158">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="2eac4-159">displayName</span><span class="sxs-lookup"><span data-stu-id="2eac4-159">displayName</span></span>| <span data-ttu-id="2eac4-160">string</span><span class="sxs-lookup"><span data-stu-id="2eac4-160">string</span></span>| <span data-ttu-id="2eac4-161">ユーザーに表示するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="2eac4-161">Name of the file that should be shown to the user.</span></span>| 
| <span data-ttu-id="2eac4-162">continuationToken</span><span class="sxs-lookup"><span data-stu-id="2eac4-162">continuationToken</span></span>| <span data-ttu-id="2eac4-163">string</span><span class="sxs-lookup"><span data-stu-id="2eac4-163">string</span></span>| <span data-ttu-id="2eac4-164">前回のアップロード要求の応答から継続トークンです。</span><span class="sxs-lookup"><span data-stu-id="2eac4-164">The continuation token from the response of the previous upload request.</span></span> <span data-ttu-id="2eac4-165">最初のブロックの場合は、これを指定しない必要があります。</span><span class="sxs-lookup"><span data-stu-id="2eac4-165">If this is the first block, this should not be specified.</span></span> | 
| <span data-ttu-id="2eac4-166">finalBlock</span><span class="sxs-lookup"><span data-stu-id="2eac4-166">finalBlock</span></span>| <span data-ttu-id="2eac4-167">bool</span><span class="sxs-lookup"><span data-stu-id="2eac4-167">bool</span></span>| <span data-ttu-id="2eac4-168">ファイルの最後のブロックに対して true に設定します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-168">Set to true for the last block of the file.</span></span> <span data-ttu-id="2eac4-169">その他のすべてのブロックに対して false に設定します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-169">Set to false for all other blocks.</span></span>| 
  
<a id="ID4ENE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="2eac4-170">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2eac4-170">Required Request Headers</span></span>
 
| <span data-ttu-id="2eac4-171">Header</span><span class="sxs-lookup"><span data-stu-id="2eac4-171">Header</span></span>| <span data-ttu-id="2eac4-172">Value</span><span class="sxs-lookup"><span data-stu-id="2eac4-172">Value</span></span>| <span data-ttu-id="2eac4-173">説明</span><span class="sxs-lookup"><span data-stu-id="2eac4-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2eac4-174">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="2eac4-174">x-xbl-contract-version</span></span>| <span data-ttu-id="2eac4-175">1</span><span class="sxs-lookup"><span data-stu-id="2eac4-175">1</span></span>| <span data-ttu-id="2eac4-176">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="2eac4-176">API contract version.</span></span>| 
| <span data-ttu-id="2eac4-177">Authorization</span><span class="sxs-lookup"><span data-stu-id="2eac4-177">Authorization</span></span>| <span data-ttu-id="2eac4-178">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="2eac4-178">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="2eac4-179">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="2eac4-179">STS authentication token.</span></span> <span data-ttu-id="2eac4-180">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="2eac4-180">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="2eac4-181">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="2eac4-181">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EWF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="2eac4-182">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="2eac4-182">Optional Request Headers</span></span>
 
| <span data-ttu-id="2eac4-183">Header</span><span class="sxs-lookup"><span data-stu-id="2eac4-183">Header</span></span>| <span data-ttu-id="2eac4-184">説明</span><span class="sxs-lookup"><span data-stu-id="2eac4-184">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2eac4-185">If-Match</span><span class="sxs-lookup"><span data-stu-id="2eac4-185">If-Match</span></span>| <span data-ttu-id="2eac4-186">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-186">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="2eac4-187">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="2eac4-187">If-None-Match</span></span>| <span data-ttu-id="2eac4-188">操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-188">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4EZG"></a>

 
## <a name="request-body"></a><span data-ttu-id="2eac4-189">要求本文</span><span class="sxs-lookup"><span data-stu-id="2eac4-189">Request body</span></span> 
 
<span data-ttu-id="2eac4-190">要求本文には、アップロードするファイルの内容が含まれています。</span><span class="sxs-lookup"><span data-stu-id="2eac4-190">The request body contains the contents of the file being uploaded.</span></span> <span data-ttu-id="2eac4-191">1 つのメッセージのアップロード、本文は、ファイルの完全な内容です。</span><span class="sxs-lookup"><span data-stu-id="2eac4-191">For single message uploads, the body is the complete contents of the file.</span></span> <span data-ttu-id="2eac4-192">複数のブロックのアップロードは、本文は、クエリ文字列パラメーターで指定されたファイルの部分です。</span><span class="sxs-lookup"><span data-stu-id="2eac4-192">For multi-block uploads, the body is the portion of the file specified in the query string parameters.</span></span> 
  
<a id="ID4EEH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="2eac4-193">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="2eac4-193">HTTP status codes</span></span> 
 
<span data-ttu-id="2eac4-194">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-194">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="2eac4-195">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-195">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="2eac4-196">コード</span><span class="sxs-lookup"><span data-stu-id="2eac4-196">Code</span></span>| <span data-ttu-id="2eac4-197">理由語句</span><span class="sxs-lookup"><span data-stu-id="2eac4-197">Reason phrase</span></span>| <span data-ttu-id="2eac4-198">説明</span><span class="sxs-lookup"><span data-stu-id="2eac4-198">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="2eac4-199">200</span><span class="sxs-lookup"><span data-stu-id="2eac4-199">200</span></span>| <span data-ttu-id="2eac4-200">OK</span><span class="sxs-lookup"><span data-stu-id="2eac4-200">OK</span></span> | <span data-ttu-id="2eac4-201">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-201">The request was successful.</span></span>| 
| <span data-ttu-id="2eac4-202">201</span><span class="sxs-lookup"><span data-stu-id="2eac4-202">201</span></span>| <span data-ttu-id="2eac4-203">作成日</span><span class="sxs-lookup"><span data-stu-id="2eac4-203">Created</span></span> | <span data-ttu-id="2eac4-204">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="2eac4-204">The entity was created.</span></span>| 
| <span data-ttu-id="2eac4-205">400</span><span class="sxs-lookup"><span data-stu-id="2eac4-205">400</span></span>| <span data-ttu-id="2eac4-206">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="2eac4-206">Bad Request</span></span> | <span data-ttu-id="2eac4-207">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="2eac4-207">Service could not understand malformed request.</span></span> <span data-ttu-id="2eac4-208">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="2eac4-208">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="2eac4-209">401</span><span class="sxs-lookup"><span data-stu-id="2eac4-209">401</span></span>| <span data-ttu-id="2eac4-210">権限がありません</span><span class="sxs-lookup"><span data-stu-id="2eac4-210">Unauthorized</span></span> | <span data-ttu-id="2eac4-211">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="2eac4-211">The request requires user authentication.</span></span>| 
| <span data-ttu-id="2eac4-212">403</span><span class="sxs-lookup"><span data-stu-id="2eac4-212">403</span></span>| <span data-ttu-id="2eac4-213">Forbidden</span><span class="sxs-lookup"><span data-stu-id="2eac4-213">Forbidden</span></span> | <span data-ttu-id="2eac4-214">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="2eac4-214">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="2eac4-215">404</span><span class="sxs-lookup"><span data-stu-id="2eac4-215">404</span></span>| <span data-ttu-id="2eac4-216">検出不可</span><span class="sxs-lookup"><span data-stu-id="2eac4-216">Not Found</span></span> | <span data-ttu-id="2eac4-217">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="2eac4-217">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="2eac4-218">406</span><span class="sxs-lookup"><span data-stu-id="2eac4-218">406</span></span>| <span data-ttu-id="2eac4-219">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="2eac4-219">Not Acceptable</span></span> | <span data-ttu-id="2eac4-220">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="2eac4-220">Resource version is not supported.</span></span>| 
| <span data-ttu-id="2eac4-221">408</span><span class="sxs-lookup"><span data-stu-id="2eac4-221">408</span></span>| <span data-ttu-id="2eac4-222">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="2eac4-222">Request Timeout</span></span> | <span data-ttu-id="2eac4-223">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-223">The request took too long to complete.</span></span>| 
| <span data-ttu-id="2eac4-224">500</span><span class="sxs-lookup"><span data-stu-id="2eac4-224">500</span></span>| <span data-ttu-id="2eac4-225">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="2eac4-225">Internal Server Error</span></span> | <span data-ttu-id="2eac4-226">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="2eac4-226">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="2eac4-227">503</span><span class="sxs-lookup"><span data-stu-id="2eac4-227">503</span></span>| <span data-ttu-id="2eac4-228">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="2eac4-228">Service Unavailable</span></span> | <span data-ttu-id="2eac4-229">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="2eac4-229">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EXEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="2eac4-230">応答本文</span><span class="sxs-lookup"><span data-stu-id="2eac4-230">Response body</span></span> 
 
<span data-ttu-id="2eac4-231">呼び出しが複数のブロックの要求で、成功した場合、サービスは次のブロックと共に渡す continution トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="2eac4-231">If the call is a multi-block request and it is successful, the service will return a continution token to pass with the next block.</span></span>
 
<a id="ID4EDFAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="2eac4-232">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="2eac4-232">Sample response</span></span>
 

```cpp
{
    "continuationToken":"abcd1234-1111-2222-3333-abcd12345678-1"
}
         
```

   
<a id="ID4EPFAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="2eac4-233">関連項目</span><span class="sxs-lookup"><span data-stu-id="2eac4-233">See also</span></span>
 
<a id="ID4ERFAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="2eac4-234">Parent</span><span class="sxs-lookup"><span data-stu-id="2eac4-234">Parent</span></span>  

[<span data-ttu-id="2eac4-235">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="2eac4-235">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype.md)

   