---
title: PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: ed037b64-6525-99a2-b7f6-050fdf345de8
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.html
description: " PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f04deef3a7c9eba494fdce8e7df16d9815cfc1ba
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594127"
---
# <a name="put-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="09111-104">PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="09111-104">PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="09111-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="09111-105">Uploads a file.</span></span> <span data-ttu-id="09111-106">データおよびメタデータが送信される一連の小さなブロックのデータとメタデータが送信される複数のブロックのアップロードや 1 つのメッセージで完全なアップロードには、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="09111-106">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="09111-107">1 つのメッセージとして 4 メガバイト未満のファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="09111-107">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="09111-108">データ型の json は、複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="09111-108">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="09111-109">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="09111-109">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="09111-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09111-110">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="09111-111">承認</span><span class="sxs-lookup"><span data-stu-id="09111-111">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="09111-112">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="09111-112">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="09111-113">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09111-113">Required Request Headers</span></span>](#ID4EQE)
  * [<span data-ttu-id="09111-114">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09111-114">Optional Request Headers</span></span>](#ID4EZF)
  * [<span data-ttu-id="09111-115">要求本文</span><span class="sxs-lookup"><span data-stu-id="09111-115">Request body</span></span>](#ID4E3G)
  * [<span data-ttu-id="09111-116">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="09111-116">HTTP status codes</span></span>](#ID4EHH)
  * [<span data-ttu-id="09111-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="09111-117">Response body</span></span>](#ID4E1EAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="09111-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09111-118">URI parameters</span></span> 
 
| <span data-ttu-id="09111-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09111-119">Parameter</span></span>| <span data-ttu-id="09111-120">種類</span><span class="sxs-lookup"><span data-stu-id="09111-120">Type</span></span>| <span data-ttu-id="09111-121">説明</span><span class="sxs-lookup"><span data-stu-id="09111-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="09111-122">xuid</span><span class="sxs-lookup"><span data-stu-id="09111-122">xuid</span></span>| <span data-ttu-id="09111-123">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="09111-123">unsigned 64-bit integer</span></span>| <span data-ttu-id="09111-124">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="09111-124">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="09111-125">scid</span><span class="sxs-lookup"><span data-stu-id="09111-125">scid</span></span>| <span data-ttu-id="09111-126">guid</span><span class="sxs-lookup"><span data-stu-id="09111-126">guid</span></span>| <span data-ttu-id="09111-127">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="09111-127">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="09111-128">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="09111-128">pathAndFileName</span></span>| <span data-ttu-id="09111-129">string</span><span class="sxs-lookup"><span data-stu-id="09111-129">string</span></span>| <span data-ttu-id="09111-130">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="09111-130">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="09111-131">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="09111-131">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="09111-132">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="09111-132">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="09111-133">type</span><span class="sxs-lookup"><span data-stu-id="09111-133">type</span></span>| <span data-ttu-id="09111-134">string</span><span class="sxs-lookup"><span data-stu-id="09111-134">string</span></span>| <span data-ttu-id="09111-135">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="09111-135">The format of the data.</span></span> <span data-ttu-id="09111-136">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="09111-136">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="09111-137">Authorization</span><span class="sxs-lookup"><span data-stu-id="09111-137">Authorization</span></span> 
 
<span data-ttu-id="09111-138">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="09111-138">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="09111-139">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="09111-139">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="09111-140">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="09111-140">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="09111-141">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="09111-141">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="09111-142">1 つのメッセージのアップロードは、クエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="09111-142">For single message uploads, the query string parameters are:</span></span>
 
| <span data-ttu-id="09111-143">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09111-143">Parameter</span></span>| <span data-ttu-id="09111-144">種類</span><span class="sxs-lookup"><span data-stu-id="09111-144">Type</span></span>| <span data-ttu-id="09111-145">説明</span><span class="sxs-lookup"><span data-stu-id="09111-145">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09111-146">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="09111-146">clientFileTime</span></span>| <span data-ttu-id="09111-147">DateTime</span><span class="sxs-lookup"><span data-stu-id="09111-147">DateTime</span></span>| <span data-ttu-id="09111-148">どのようなクライアントが最後に、ファイルをアップロード上のファイルの日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="09111-148">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="09111-149">displayName</span><span class="sxs-lookup"><span data-stu-id="09111-149">displayName</span></span>| <span data-ttu-id="09111-150">string</span><span class="sxs-lookup"><span data-stu-id="09111-150">string</span></span>| <span data-ttu-id="09111-151">ユーザーに表示するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="09111-151">Name of the file that should be shown to the user.</span></span>| 
 
<span data-ttu-id="09111-152">複数のブロックのアップロードは、クエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="09111-152">For multi-block uploads, the query string parameters are:</span></span>
 
| <span data-ttu-id="09111-153">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09111-153">Parameter</span></span>| <span data-ttu-id="09111-154">種類</span><span class="sxs-lookup"><span data-stu-id="09111-154">Type</span></span>| <span data-ttu-id="09111-155">説明</span><span class="sxs-lookup"><span data-stu-id="09111-155">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09111-156">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="09111-156">clientFileTime</span></span>| <span data-ttu-id="09111-157">DateTime</span><span class="sxs-lookup"><span data-stu-id="09111-157">DateTime</span></span>| <span data-ttu-id="09111-158">どのようなクライアントが最後に、ファイルをアップロード上のファイルの日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="09111-158">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="09111-159">displayName</span><span class="sxs-lookup"><span data-stu-id="09111-159">displayName</span></span>| <span data-ttu-id="09111-160">string</span><span class="sxs-lookup"><span data-stu-id="09111-160">string</span></span>| <span data-ttu-id="09111-161">ユーザーに表示するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="09111-161">Name of the file that should be shown to the user.</span></span>| 
| <span data-ttu-id="09111-162">continuationToken</span><span class="sxs-lookup"><span data-stu-id="09111-162">continuationToken</span></span>| <span data-ttu-id="09111-163">string</span><span class="sxs-lookup"><span data-stu-id="09111-163">string</span></span>| <span data-ttu-id="09111-164">前回のアップロード要求の応答から継続トークンです。</span><span class="sxs-lookup"><span data-stu-id="09111-164">The continuation token from the response of the previous upload request.</span></span> <span data-ttu-id="09111-165">最初のブロックの場合は、これを指定しない必要があります。</span><span class="sxs-lookup"><span data-stu-id="09111-165">If this is the first block, this should not be specified.</span></span> | 
| <span data-ttu-id="09111-166">finalBlock</span><span class="sxs-lookup"><span data-stu-id="09111-166">finalBlock</span></span>| <span data-ttu-id="09111-167">bool</span><span class="sxs-lookup"><span data-stu-id="09111-167">bool</span></span>| <span data-ttu-id="09111-168">ファイルの最後のブロックに対して true に設定します。</span><span class="sxs-lookup"><span data-stu-id="09111-168">Set to true for the last block of the file.</span></span> <span data-ttu-id="09111-169">その他のすべてのブロックに対して false に設定します。</span><span class="sxs-lookup"><span data-stu-id="09111-169">Set to false for all other blocks.</span></span>| 
  
<a id="ID4EQE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="09111-170">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09111-170">Required Request Headers</span></span>
 
| <span data-ttu-id="09111-171">Header</span><span class="sxs-lookup"><span data-stu-id="09111-171">Header</span></span>| <span data-ttu-id="09111-172">Value</span><span class="sxs-lookup"><span data-stu-id="09111-172">Value</span></span>| <span data-ttu-id="09111-173">説明</span><span class="sxs-lookup"><span data-stu-id="09111-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09111-174">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="09111-174">x-xbl-contract-version</span></span>| <span data-ttu-id="09111-175">1</span><span class="sxs-lookup"><span data-stu-id="09111-175">1</span></span>| <span data-ttu-id="09111-176">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="09111-176">API contract version.</span></span>| 
| <span data-ttu-id="09111-177">Authorization</span><span class="sxs-lookup"><span data-stu-id="09111-177">Authorization</span></span>| <span data-ttu-id="09111-178">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="09111-178">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="09111-179">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="09111-179">STS authentication token.</span></span> <span data-ttu-id="09111-180">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="09111-180">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="09111-181">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="09111-181">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EZF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="09111-182">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09111-182">Optional Request Headers</span></span>
 
| <span data-ttu-id="09111-183">Header</span><span class="sxs-lookup"><span data-stu-id="09111-183">Header</span></span>| <span data-ttu-id="09111-184">説明</span><span class="sxs-lookup"><span data-stu-id="09111-184">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09111-185">If-Match</span><span class="sxs-lookup"><span data-stu-id="09111-185">If-Match</span></span>| <span data-ttu-id="09111-186">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="09111-186">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="09111-187">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="09111-187">If-None-Match</span></span>| <span data-ttu-id="09111-188">操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="09111-188">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4E3G"></a>

 
## <a name="request-body"></a><span data-ttu-id="09111-189">要求本文</span><span class="sxs-lookup"><span data-stu-id="09111-189">Request body</span></span> 
 
<span data-ttu-id="09111-190">要求本文には、アップロードするファイルの内容が含まれています。</span><span class="sxs-lookup"><span data-stu-id="09111-190">The request body contains the contents of the file being uploaded.</span></span> <span data-ttu-id="09111-191">1 つのメッセージのアップロード、本文は、ファイルの完全な内容です。</span><span class="sxs-lookup"><span data-stu-id="09111-191">For single message uploads, the body is the complete contents of the file.</span></span> <span data-ttu-id="09111-192">複数のブロックのアップロードは、本文は、クエリ文字列パラメーターで指定されたファイルの部分です。</span><span class="sxs-lookup"><span data-stu-id="09111-192">For multi-block uploads, the body is the portion of the file specified in the query string parameters.</span></span> 
  
<a id="ID4EHH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="09111-193">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="09111-193">HTTP status codes</span></span> 
 
<span data-ttu-id="09111-194">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="09111-194">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="09111-195">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="09111-195">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="09111-196">コード</span><span class="sxs-lookup"><span data-stu-id="09111-196">Code</span></span>| <span data-ttu-id="09111-197">理由語句</span><span class="sxs-lookup"><span data-stu-id="09111-197">Reason phrase</span></span>| <span data-ttu-id="09111-198">説明</span><span class="sxs-lookup"><span data-stu-id="09111-198">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09111-199">200</span><span class="sxs-lookup"><span data-stu-id="09111-199">200</span></span>| <span data-ttu-id="09111-200">OK</span><span class="sxs-lookup"><span data-stu-id="09111-200">OK</span></span> | <span data-ttu-id="09111-201">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="09111-201">The request was successful.</span></span>| 
| <span data-ttu-id="09111-202">201</span><span class="sxs-lookup"><span data-stu-id="09111-202">201</span></span>| <span data-ttu-id="09111-203">作成日</span><span class="sxs-lookup"><span data-stu-id="09111-203">Created</span></span> | <span data-ttu-id="09111-204">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="09111-204">The entity was created.</span></span>| 
| <span data-ttu-id="09111-205">400</span><span class="sxs-lookup"><span data-stu-id="09111-205">400</span></span>| <span data-ttu-id="09111-206">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="09111-206">Bad Request</span></span> | <span data-ttu-id="09111-207">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="09111-207">Service could not understand malformed request.</span></span> <span data-ttu-id="09111-208">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="09111-208">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="09111-209">401</span><span class="sxs-lookup"><span data-stu-id="09111-209">401</span></span>| <span data-ttu-id="09111-210">権限がありません</span><span class="sxs-lookup"><span data-stu-id="09111-210">Unauthorized</span></span> | <span data-ttu-id="09111-211">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="09111-211">The request requires user authentication.</span></span>| 
| <span data-ttu-id="09111-212">403</span><span class="sxs-lookup"><span data-stu-id="09111-212">403</span></span>| <span data-ttu-id="09111-213">Forbidden</span><span class="sxs-lookup"><span data-stu-id="09111-213">Forbidden</span></span> | <span data-ttu-id="09111-214">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="09111-214">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="09111-215">404</span><span class="sxs-lookup"><span data-stu-id="09111-215">404</span></span>| <span data-ttu-id="09111-216">検出不可</span><span class="sxs-lookup"><span data-stu-id="09111-216">Not Found</span></span> | <span data-ttu-id="09111-217">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="09111-217">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="09111-218">406</span><span class="sxs-lookup"><span data-stu-id="09111-218">406</span></span>| <span data-ttu-id="09111-219">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="09111-219">Not Acceptable</span></span> | <span data-ttu-id="09111-220">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="09111-220">Resource version is not supported.</span></span>| 
| <span data-ttu-id="09111-221">408</span><span class="sxs-lookup"><span data-stu-id="09111-221">408</span></span>| <span data-ttu-id="09111-222">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="09111-222">Request Timeout</span></span> | <span data-ttu-id="09111-223">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="09111-223">The request took too long to complete.</span></span>| 
| <span data-ttu-id="09111-224">500</span><span class="sxs-lookup"><span data-stu-id="09111-224">500</span></span>| <span data-ttu-id="09111-225">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="09111-225">Internal Server Error</span></span> | <span data-ttu-id="09111-226">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="09111-226">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="09111-227">503</span><span class="sxs-lookup"><span data-stu-id="09111-227">503</span></span>| <span data-ttu-id="09111-228">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="09111-228">Service Unavailable</span></span> | <span data-ttu-id="09111-229">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="09111-229">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4E1EAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="09111-230">応答本文</span><span class="sxs-lookup"><span data-stu-id="09111-230">Response body</span></span> 
 
<span data-ttu-id="09111-231">呼び出しが複数のブロックの要求で、成功した場合、サービスは次のブロックと共に渡す continution トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="09111-231">If the call is a multi-block request and it is successful, the service will return a continution token to pass with the next block.</span></span>
 
<a id="ID4EGFAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="09111-232">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="09111-232">Sample response</span></span>
 

```cpp
{
    "continuationToken":"abcd1234-1111-2222-3333-abcd12345678-1"
}
         
```

   
<a id="ID4ESFAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="09111-233">関連項目</span><span class="sxs-lookup"><span data-stu-id="09111-233">See also</span></span>
 
<a id="ID4EUFAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="09111-234">Parent</span><span class="sxs-lookup"><span data-stu-id="09111-234">Parent</span></span>  

[<span data-ttu-id="09111-235">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="09111-235">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

   