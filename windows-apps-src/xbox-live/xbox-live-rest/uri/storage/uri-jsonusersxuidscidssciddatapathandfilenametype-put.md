---
title: PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)
assetID: 02e43120-1f71-a3e7-c84e-96147b838b97
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype-put.html
description: " PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 35b1f8fdb8150d9f25fee010192e466adb2f2d86
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655667"
---
# <a name="put-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="902fe-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="902fe-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="902fe-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="902fe-105">Uploads a file.</span></span> <span data-ttu-id="902fe-106">データ型の json は、複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="902fe-106">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="902fe-107">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="902fe-107">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="902fe-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="902fe-108">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="902fe-109">承認</span><span class="sxs-lookup"><span data-stu-id="902fe-109">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="902fe-110">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="902fe-110">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="902fe-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="902fe-111">Required Request Headers</span></span>](#ID4EXC)
  * [<span data-ttu-id="902fe-112">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="902fe-112">Optional Request Headers</span></span>](#ID4EAE)
  * [<span data-ttu-id="902fe-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="902fe-113">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="902fe-114">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="902fe-114">HTTP status codes</span></span>](#ID4EOF)
  * [<span data-ttu-id="902fe-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="902fe-115">Response body</span></span>](#ID4EBDAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="902fe-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="902fe-116">URI parameters</span></span> 
 
| <span data-ttu-id="902fe-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="902fe-117">Parameter</span></span>| <span data-ttu-id="902fe-118">種類</span><span class="sxs-lookup"><span data-stu-id="902fe-118">Type</span></span>| <span data-ttu-id="902fe-119">説明</span><span class="sxs-lookup"><span data-stu-id="902fe-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="902fe-120">xuid</span><span class="sxs-lookup"><span data-stu-id="902fe-120">xuid</span></span>| <span data-ttu-id="902fe-121">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="902fe-121">unsigned 64-bit integer</span></span>| <span data-ttu-id="902fe-122">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="902fe-122">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="902fe-123">scid</span><span class="sxs-lookup"><span data-stu-id="902fe-123">scid</span></span>| <span data-ttu-id="902fe-124">guid</span><span class="sxs-lookup"><span data-stu-id="902fe-124">guid</span></span>| <span data-ttu-id="902fe-125">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="902fe-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="902fe-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="902fe-126">pathAndFileName</span></span>| <span data-ttu-id="902fe-127">string</span><span class="sxs-lookup"><span data-stu-id="902fe-127">string</span></span>| <span data-ttu-id="902fe-128">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="902fe-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="902fe-129">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="902fe-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="902fe-130">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="902fe-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="902fe-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="902fe-131">Authorization</span></span> 
 
<span data-ttu-id="902fe-132">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="902fe-132">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="902fe-133">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="902fe-133">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="902fe-134">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="902fe-134">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="902fe-135">省略可能なクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="902fe-135">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="902fe-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="902fe-136">Parameter</span></span>| <span data-ttu-id="902fe-137">種類</span><span class="sxs-lookup"><span data-stu-id="902fe-137">Type</span></span>| <span data-ttu-id="902fe-138">説明</span><span class="sxs-lookup"><span data-stu-id="902fe-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="902fe-139">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="902fe-139">clientFileTime</span></span>| <span data-ttu-id="902fe-140">DateTime</span><span class="sxs-lookup"><span data-stu-id="902fe-140">DateTime</span></span>| <span data-ttu-id="902fe-141">どのようなクライアントが最後に、ファイルをアップロード上のファイルの日付/時刻。</span><span class="sxs-lookup"><span data-stu-id="902fe-141">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="902fe-142">displayName</span><span class="sxs-lookup"><span data-stu-id="902fe-142">displayName</span></span>| <span data-ttu-id="902fe-143">string</span><span class="sxs-lookup"><span data-stu-id="902fe-143">string</span></span>| <span data-ttu-id="902fe-144">ユーザーに表示するファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="902fe-144">Name of the file that should be shown to the user.</span></span>| 
  
<a id="ID4EXC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="902fe-145">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="902fe-145">Required Request Headers</span></span>
 
| <span data-ttu-id="902fe-146">Header</span><span class="sxs-lookup"><span data-stu-id="902fe-146">Header</span></span>| <span data-ttu-id="902fe-147">Value</span><span class="sxs-lookup"><span data-stu-id="902fe-147">Value</span></span>| <span data-ttu-id="902fe-148">説明</span><span class="sxs-lookup"><span data-stu-id="902fe-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="902fe-149">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="902fe-149">x-xbl-contract-version</span></span>| <span data-ttu-id="902fe-150">1</span><span class="sxs-lookup"><span data-stu-id="902fe-150">1</span></span>| <span data-ttu-id="902fe-151">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="902fe-151">API contract version.</span></span>| 
| <span data-ttu-id="902fe-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="902fe-152">Authorization</span></span>| <span data-ttu-id="902fe-153">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="902fe-153">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="902fe-154">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="902fe-154">STS authentication token.</span></span> <span data-ttu-id="902fe-155">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="902fe-155">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="902fe-156">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="902fe-156">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EAE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="902fe-157">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="902fe-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="902fe-158">Header</span><span class="sxs-lookup"><span data-stu-id="902fe-158">Header</span></span>| <span data-ttu-id="902fe-159">説明</span><span class="sxs-lookup"><span data-stu-id="902fe-159">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="902fe-160">If-Match</span><span class="sxs-lookup"><span data-stu-id="902fe-160">If-Match</span></span>| <span data-ttu-id="902fe-161">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="902fe-161">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="902fe-162">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="902fe-162">If-None-Match</span></span>| <span data-ttu-id="902fe-163">操作を完了するすべての既存の項目と一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="902fe-163">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="902fe-164">要求本文</span><span class="sxs-lookup"><span data-stu-id="902fe-164">Request body</span></span> 
 
<span data-ttu-id="902fe-165">要求本文には、アップロードするファイルのすべての内容が含まれています。</span><span class="sxs-lookup"><span data-stu-id="902fe-165">The request body contains the complete contents of the file being uploaded.</span></span> 
  
<a id="ID4EOF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="902fe-166">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="902fe-166">HTTP status codes</span></span> 
 
<span data-ttu-id="902fe-167">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="902fe-167">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="902fe-168">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="902fe-168">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="902fe-169">コード</span><span class="sxs-lookup"><span data-stu-id="902fe-169">Code</span></span>| <span data-ttu-id="902fe-170">理由語句</span><span class="sxs-lookup"><span data-stu-id="902fe-170">Reason phrase</span></span>| <span data-ttu-id="902fe-171">説明</span><span class="sxs-lookup"><span data-stu-id="902fe-171">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="902fe-172">200</span><span class="sxs-lookup"><span data-stu-id="902fe-172">200</span></span>| <span data-ttu-id="902fe-173">OK</span><span class="sxs-lookup"><span data-stu-id="902fe-173">OK</span></span> | <span data-ttu-id="902fe-174">要求が成功します。</span><span class="sxs-lookup"><span data-stu-id="902fe-174">The request was successful.</span></span>| 
| <span data-ttu-id="902fe-175">201</span><span class="sxs-lookup"><span data-stu-id="902fe-175">201</span></span>| <span data-ttu-id="902fe-176">作成日</span><span class="sxs-lookup"><span data-stu-id="902fe-176">Created</span></span> | <span data-ttu-id="902fe-177">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="902fe-177">The entity was created.</span></span>| 
| <span data-ttu-id="902fe-178">400</span><span class="sxs-lookup"><span data-stu-id="902fe-178">400</span></span>| <span data-ttu-id="902fe-179">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="902fe-179">Bad Request</span></span> | <span data-ttu-id="902fe-180">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="902fe-180">Service could not understand malformed request.</span></span> <span data-ttu-id="902fe-181">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="902fe-181">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="902fe-182">401</span><span class="sxs-lookup"><span data-stu-id="902fe-182">401</span></span>| <span data-ttu-id="902fe-183">権限がありません</span><span class="sxs-lookup"><span data-stu-id="902fe-183">Unauthorized</span></span> | <span data-ttu-id="902fe-184">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="902fe-184">The request requires user authentication.</span></span>| 
| <span data-ttu-id="902fe-185">403</span><span class="sxs-lookup"><span data-stu-id="902fe-185">403</span></span>| <span data-ttu-id="902fe-186">Forbidden</span><span class="sxs-lookup"><span data-stu-id="902fe-186">Forbidden</span></span> | <span data-ttu-id="902fe-187">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="902fe-187">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="902fe-188">404</span><span class="sxs-lookup"><span data-stu-id="902fe-188">404</span></span>| <span data-ttu-id="902fe-189">検出不可</span><span class="sxs-lookup"><span data-stu-id="902fe-189">Not Found</span></span> | <span data-ttu-id="902fe-190">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="902fe-190">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="902fe-191">406</span><span class="sxs-lookup"><span data-stu-id="902fe-191">406</span></span>| <span data-ttu-id="902fe-192">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="902fe-192">Not Acceptable</span></span> | <span data-ttu-id="902fe-193">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="902fe-193">Resource version is not supported.</span></span>| 
| <span data-ttu-id="902fe-194">408</span><span class="sxs-lookup"><span data-stu-id="902fe-194">408</span></span>| <span data-ttu-id="902fe-195">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="902fe-195">Request Timeout</span></span> | <span data-ttu-id="902fe-196">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="902fe-196">The request took too long to complete.</span></span>| 
| <span data-ttu-id="902fe-197">500</span><span class="sxs-lookup"><span data-stu-id="902fe-197">500</span></span>| <span data-ttu-id="902fe-198">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="902fe-198">Internal Server Error</span></span> | <span data-ttu-id="902fe-199">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="902fe-199">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="902fe-200">503</span><span class="sxs-lookup"><span data-stu-id="902fe-200">503</span></span>| <span data-ttu-id="902fe-201">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="902fe-201">Service Unavailable</span></span> | <span data-ttu-id="902fe-202">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="902fe-202">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EBDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="902fe-203">応答本文</span><span class="sxs-lookup"><span data-stu-id="902fe-203">Response body</span></span> 
 
<span data-ttu-id="902fe-204">アップロードが成功した場合は、{} の応答で、201 が返されます。</span><span class="sxs-lookup"><span data-stu-id="902fe-204">If the upload is successful, a 201 is returned with a { } response.</span></span>
  
<a id="ID4EODAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="902fe-205">関連項目</span><span class="sxs-lookup"><span data-stu-id="902fe-205">See also</span></span>
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="902fe-206">Parent</span><span class="sxs-lookup"><span data-stu-id="902fe-206">Parent</span></span>  

[<span data-ttu-id="902fe-207">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="902fe-207">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

   