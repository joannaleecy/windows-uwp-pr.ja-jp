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
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8922764"
---
# <a name="put-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="cd5be-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="cd5be-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="cd5be-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="cd5be-105">Uploads a file.</span></span> <span data-ttu-id="cd5be-106">Json の種類のデータの複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="cd5be-106">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="cd5be-107">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cd5be-107">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cd5be-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd5be-108">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="cd5be-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="cd5be-109">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="cd5be-110">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd5be-110">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="cd5be-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd5be-111">Required Request Headers</span></span>](#ID4EXC)
  * [<span data-ttu-id="cd5be-112">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd5be-112">Optional Request Headers</span></span>](#ID4EAE)
  * [<span data-ttu-id="cd5be-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="cd5be-113">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="cd5be-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="cd5be-114">HTTP status codes</span></span>](#ID4EOF)
  * [<span data-ttu-id="cd5be-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="cd5be-115">Response body</span></span>](#ID4EBDAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cd5be-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd5be-116">URI parameters</span></span> 
 
| <span data-ttu-id="cd5be-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd5be-117">Parameter</span></span>| <span data-ttu-id="cd5be-118">型</span><span class="sxs-lookup"><span data-stu-id="cd5be-118">Type</span></span>| <span data-ttu-id="cd5be-119">説明</span><span class="sxs-lookup"><span data-stu-id="cd5be-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cd5be-120">xuid</span><span class="sxs-lookup"><span data-stu-id="cd5be-120">xuid</span></span>| <span data-ttu-id="cd5be-121">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="cd5be-121">unsigned 64-bit integer</span></span>| <span data-ttu-id="cd5be-122">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="cd5be-122">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="cd5be-123">scid</span><span class="sxs-lookup"><span data-stu-id="cd5be-123">scid</span></span>| <span data-ttu-id="cd5be-124">guid</span><span class="sxs-lookup"><span data-stu-id="cd5be-124">guid</span></span>| <span data-ttu-id="cd5be-125">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="cd5be-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="cd5be-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="cd5be-126">pathAndFileName</span></span>| <span data-ttu-id="cd5be-127">string</span><span class="sxs-lookup"><span data-stu-id="cd5be-127">string</span></span>| <span data-ttu-id="cd5be-128">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="cd5be-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="cd5be-129">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="cd5be-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="cd5be-130">ファイル名を空にすることがありますはいない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="cd5be-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="cd5be-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="cd5be-131">Authorization</span></span> 
 
<span data-ttu-id="cd5be-132">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="cd5be-132">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="cd5be-133">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="cd5be-133">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="cd5be-134">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="cd5be-134">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="cd5be-135">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd5be-135">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="cd5be-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cd5be-136">Parameter</span></span>| <span data-ttu-id="cd5be-137">型</span><span class="sxs-lookup"><span data-stu-id="cd5be-137">Type</span></span>| <span data-ttu-id="cd5be-138">説明</span><span class="sxs-lookup"><span data-stu-id="cd5be-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd5be-139">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="cd5be-139">clientFileTime</span></span>| <span data-ttu-id="cd5be-140">DateTime</span><span class="sxs-lookup"><span data-stu-id="cd5be-140">DateTime</span></span>| <span data-ttu-id="cd5be-141">どのクライアント上のファイルの日付/時刻は最終ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="cd5be-141">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="cd5be-142">displayName</span><span class="sxs-lookup"><span data-stu-id="cd5be-142">displayName</span></span>| <span data-ttu-id="cd5be-143">string</span><span class="sxs-lookup"><span data-stu-id="cd5be-143">string</span></span>| <span data-ttu-id="cd5be-144">ユーザーに表示する必要がありますファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="cd5be-144">Name of the file that should be shown to the user.</span></span>| 
  
<a id="ID4EXC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="cd5be-145">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd5be-145">Required Request Headers</span></span>
 
| <span data-ttu-id="cd5be-146">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd5be-146">Header</span></span>| <span data-ttu-id="cd5be-147">設定値</span><span class="sxs-lookup"><span data-stu-id="cd5be-147">Value</span></span>| <span data-ttu-id="cd5be-148">説明</span><span class="sxs-lookup"><span data-stu-id="cd5be-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd5be-149">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="cd5be-149">x-xbl-contract-version</span></span>| <span data-ttu-id="cd5be-150">1</span><span class="sxs-lookup"><span data-stu-id="cd5be-150">1</span></span>| <span data-ttu-id="cd5be-151">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="cd5be-151">API contract version.</span></span>| 
| <span data-ttu-id="cd5be-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="cd5be-152">Authorization</span></span>| <span data-ttu-id="cd5be-153">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="cd5be-153">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="cd5be-154">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="cd5be-154">STS authentication token.</span></span> <span data-ttu-id="cd5be-155">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="cd5be-155">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="cd5be-156">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cd5be-156">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EAE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="cd5be-157">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd5be-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="cd5be-158">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cd5be-158">Header</span></span>| <span data-ttu-id="cd5be-159">説明</span><span class="sxs-lookup"><span data-stu-id="cd5be-159">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd5be-160">If-Match</span><span class="sxs-lookup"><span data-stu-id="cd5be-160">If-Match</span></span>| <span data-ttu-id="cd5be-161">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="cd5be-161">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="cd5be-162">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="cd5be-162">If-None-Match</span></span>| <span data-ttu-id="cd5be-163">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="cd5be-163">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="cd5be-164">要求本文</span><span class="sxs-lookup"><span data-stu-id="cd5be-164">Request body</span></span> 
 
<span data-ttu-id="cd5be-165">要求本文には、アップロードされているファイルの完全なコンテンツが含まれています。</span><span class="sxs-lookup"><span data-stu-id="cd5be-165">The request body contains the complete contents of the file being uploaded.</span></span> 
  
<a id="ID4EOF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="cd5be-166">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="cd5be-166">HTTP status codes</span></span> 
 
<span data-ttu-id="cd5be-167">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="cd5be-167">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="cd5be-168">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cd5be-168">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="cd5be-169">コード</span><span class="sxs-lookup"><span data-stu-id="cd5be-169">Code</span></span>| <span data-ttu-id="cd5be-170">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="cd5be-170">Reason phrase</span></span>| <span data-ttu-id="cd5be-171">説明</span><span class="sxs-lookup"><span data-stu-id="cd5be-171">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cd5be-172">200</span><span class="sxs-lookup"><span data-stu-id="cd5be-172">200</span></span>| <span data-ttu-id="cd5be-173">OK</span><span class="sxs-lookup"><span data-stu-id="cd5be-173">OK</span></span> | <span data-ttu-id="cd5be-174">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="cd5be-174">The request was successful.</span></span>| 
| <span data-ttu-id="cd5be-175">201</span><span class="sxs-lookup"><span data-stu-id="cd5be-175">201</span></span>| <span data-ttu-id="cd5be-176">Created</span><span class="sxs-lookup"><span data-stu-id="cd5be-176">Created</span></span> | <span data-ttu-id="cd5be-177">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="cd5be-177">The entity was created.</span></span>| 
| <span data-ttu-id="cd5be-178">400</span><span class="sxs-lookup"><span data-stu-id="cd5be-178">400</span></span>| <span data-ttu-id="cd5be-179">Bad Request</span><span class="sxs-lookup"><span data-stu-id="cd5be-179">Bad Request</span></span> | <span data-ttu-id="cd5be-180">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="cd5be-180">Service could not understand malformed request.</span></span> <span data-ttu-id="cd5be-181">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="cd5be-181">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="cd5be-182">401</span><span class="sxs-lookup"><span data-stu-id="cd5be-182">401</span></span>| <span data-ttu-id="cd5be-183">権限がありません</span><span class="sxs-lookup"><span data-stu-id="cd5be-183">Unauthorized</span></span> | <span data-ttu-id="cd5be-184">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="cd5be-184">The request requires user authentication.</span></span>| 
| <span data-ttu-id="cd5be-185">403</span><span class="sxs-lookup"><span data-stu-id="cd5be-185">403</span></span>| <span data-ttu-id="cd5be-186">Forbidden</span><span class="sxs-lookup"><span data-stu-id="cd5be-186">Forbidden</span></span> | <span data-ttu-id="cd5be-187">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="cd5be-187">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="cd5be-188">404</span><span class="sxs-lookup"><span data-stu-id="cd5be-188">404</span></span>| <span data-ttu-id="cd5be-189">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="cd5be-189">Not Found</span></span> | <span data-ttu-id="cd5be-190">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="cd5be-190">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="cd5be-191">406</span><span class="sxs-lookup"><span data-stu-id="cd5be-191">406</span></span>| <span data-ttu-id="cd5be-192">許容できません。</span><span class="sxs-lookup"><span data-stu-id="cd5be-192">Not Acceptable</span></span> | <span data-ttu-id="cd5be-193">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="cd5be-193">Resource version is not supported.</span></span>| 
| <span data-ttu-id="cd5be-194">408</span><span class="sxs-lookup"><span data-stu-id="cd5be-194">408</span></span>| <span data-ttu-id="cd5be-195">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="cd5be-195">Request Timeout</span></span> | <span data-ttu-id="cd5be-196">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="cd5be-196">The request took too long to complete.</span></span>| 
| <span data-ttu-id="cd5be-197">500</span><span class="sxs-lookup"><span data-stu-id="cd5be-197">500</span></span>| <span data-ttu-id="cd5be-198">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="cd5be-198">Internal Server Error</span></span> | <span data-ttu-id="cd5be-199">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="cd5be-199">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="cd5be-200">503</span><span class="sxs-lookup"><span data-stu-id="cd5be-200">503</span></span>| <span data-ttu-id="cd5be-201">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="cd5be-201">Service Unavailable</span></span> | <span data-ttu-id="cd5be-202">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="cd5be-202">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EBDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="cd5be-203">応答本文</span><span class="sxs-lookup"><span data-stu-id="cd5be-203">Response body</span></span> 
 
<span data-ttu-id="cd5be-204">アップロードが成功した場合は、{} への返信、201 が返されます。</span><span class="sxs-lookup"><span data-stu-id="cd5be-204">If the upload is successful, a 201 is returned with a { } response.</span></span>
  
<a id="ID4EODAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cd5be-205">関連項目</span><span class="sxs-lookup"><span data-stu-id="cd5be-205">See also</span></span>
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cd5be-206">Parent</span><span class="sxs-lookup"><span data-stu-id="cd5be-206">Parent</span></span>  

[<span data-ttu-id="cd5be-207">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="cd5be-207">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

   