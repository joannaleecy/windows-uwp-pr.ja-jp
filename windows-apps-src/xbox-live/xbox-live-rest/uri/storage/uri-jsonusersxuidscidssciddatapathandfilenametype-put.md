---
title: PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)
assetID: 02e43120-1f71-a3e7-c84e-96147b838b97
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype-put.html
author: KevinAsgari
description: " PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f6bcc90cc9758540bd7688e2d54a9f31262116d9
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881503"
---
# <a name="put-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="0ffb8-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="0ffb8-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="0ffb8-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-105">Uploads a file.</span></span> <span data-ttu-id="0ffb8-106">複数のブロックのアップロードの種類の json データはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-106">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="0ffb8-107">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-107">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0ffb8-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0ffb8-108">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="0ffb8-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="0ffb8-109">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="0ffb8-110">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="0ffb8-110">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="0ffb8-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0ffb8-111">Required Request Headers</span></span>](#ID4EXC)
  * [<span data-ttu-id="0ffb8-112">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0ffb8-112">Optional Request Headers</span></span>](#ID4EAE)
  * [<span data-ttu-id="0ffb8-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="0ffb8-113">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="0ffb8-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0ffb8-114">HTTP status codes</span></span>](#ID4EOF)
  * [<span data-ttu-id="0ffb8-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="0ffb8-115">Response body</span></span>](#ID4EBDAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0ffb8-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0ffb8-116">URI parameters</span></span> 
 
| <span data-ttu-id="0ffb8-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0ffb8-117">Parameter</span></span>| <span data-ttu-id="0ffb8-118">型</span><span class="sxs-lookup"><span data-stu-id="0ffb8-118">Type</span></span>| <span data-ttu-id="0ffb8-119">説明</span><span class="sxs-lookup"><span data-stu-id="0ffb8-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0ffb8-120">xuid</span><span class="sxs-lookup"><span data-stu-id="0ffb8-120">xuid</span></span>| <span data-ttu-id="0ffb8-121">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="0ffb8-121">unsigned 64-bit integer</span></span>| <span data-ttu-id="0ffb8-122">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-122">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="0ffb8-123">scid</span><span class="sxs-lookup"><span data-stu-id="0ffb8-123">scid</span></span>| <span data-ttu-id="0ffb8-124">guid</span><span class="sxs-lookup"><span data-stu-id="0ffb8-124">guid</span></span>| <span data-ttu-id="0ffb8-125">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="0ffb8-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="0ffb8-126">pathAndFileName</span></span>| <span data-ttu-id="0ffb8-127">string</span><span class="sxs-lookup"><span data-stu-id="0ffb8-127">string</span></span>| <span data-ttu-id="0ffb8-128">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="0ffb8-129">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="0ffb8-130">ファイル名を空にする場合がありますはいない期間の終了または 2 つの連続するピリオドが含まれては。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="0ffb8-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="0ffb8-131">Authorization</span></span> 
 
<span data-ttu-id="0ffb8-132">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-132">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="0ffb8-133">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-133">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="0ffb8-134">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-134">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="0ffb8-135">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="0ffb8-135">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="0ffb8-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0ffb8-136">Parameter</span></span>| <span data-ttu-id="0ffb8-137">型</span><span class="sxs-lookup"><span data-stu-id="0ffb8-137">Type</span></span>| <span data-ttu-id="0ffb8-138">説明</span><span class="sxs-lookup"><span data-stu-id="0ffb8-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0ffb8-139">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="0ffb8-139">clientFileTime</span></span>| <span data-ttu-id="0ffb8-140">DateTime</span><span class="sxs-lookup"><span data-stu-id="0ffb8-140">DateTime</span></span>| <span data-ttu-id="0ffb8-141">どのクライアント上のファイルの日付/時刻は、最終ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-141">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="0ffb8-142">displayName</span><span class="sxs-lookup"><span data-stu-id="0ffb8-142">displayName</span></span>| <span data-ttu-id="0ffb8-143">string</span><span class="sxs-lookup"><span data-stu-id="0ffb8-143">string</span></span>| <span data-ttu-id="0ffb8-144">ユーザーに表示する必要がありますファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-144">Name of the file that should be shown to the user.</span></span>| 
  
<a id="ID4EXC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0ffb8-145">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0ffb8-145">Required Request Headers</span></span>
 
| <span data-ttu-id="0ffb8-146">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0ffb8-146">Header</span></span>| <span data-ttu-id="0ffb8-147">設定値</span><span class="sxs-lookup"><span data-stu-id="0ffb8-147">Value</span></span>| <span data-ttu-id="0ffb8-148">説明</span><span class="sxs-lookup"><span data-stu-id="0ffb8-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0ffb8-149">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="0ffb8-149">x-xbl-contract-version</span></span>| <span data-ttu-id="0ffb8-150">1</span><span class="sxs-lookup"><span data-stu-id="0ffb8-150">1</span></span>| <span data-ttu-id="0ffb8-151">API コントラクト バージョン。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-151">API contract version.</span></span>| 
| <span data-ttu-id="0ffb8-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="0ffb8-152">Authorization</span></span>| <span data-ttu-id="0ffb8-153">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="0ffb8-153">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="0ffb8-154">STS 認証トークン。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-154">STS authentication token.</span></span> <span data-ttu-id="0ffb8-155">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-155">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="0ffb8-156">STS トークンを取得して、承認ヘッダーの作成について詳しくは、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-156">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EAE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="0ffb8-157">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0ffb8-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="0ffb8-158">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0ffb8-158">Header</span></span>| <span data-ttu-id="0ffb8-159">説明</span><span class="sxs-lookup"><span data-stu-id="0ffb8-159">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0ffb8-160">If-Match</span><span class="sxs-lookup"><span data-stu-id="0ffb8-160">If-Match</span></span>| <span data-ttu-id="0ffb8-161">操作を完了するにより既存項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-161">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="0ffb8-162">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="0ffb8-162">If-None-Match</span></span>| <span data-ttu-id="0ffb8-163">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-163">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="0ffb8-164">要求本文</span><span class="sxs-lookup"><span data-stu-id="0ffb8-164">Request body</span></span> 
 
<span data-ttu-id="0ffb8-165">要求本文には、アップロードされているファイルの完全な内容が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-165">The request body contains the complete contents of the file being uploaded.</span></span> 
  
<a id="ID4EOF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="0ffb8-166">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0ffb8-166">HTTP status codes</span></span> 
 
<span data-ttu-id="0ffb8-167">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-167">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="0ffb8-168">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-168">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="0ffb8-169">コード</span><span class="sxs-lookup"><span data-stu-id="0ffb8-169">Code</span></span>| <span data-ttu-id="0ffb8-170">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="0ffb8-170">Reason phrase</span></span>| <span data-ttu-id="0ffb8-171">説明</span><span class="sxs-lookup"><span data-stu-id="0ffb8-171">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0ffb8-172">200</span><span class="sxs-lookup"><span data-stu-id="0ffb8-172">200</span></span>| <span data-ttu-id="0ffb8-173">OK</span><span class="sxs-lookup"><span data-stu-id="0ffb8-173">OK</span></span> | <span data-ttu-id="0ffb8-174">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-174">The request was successful.</span></span>| 
| <span data-ttu-id="0ffb8-175">201</span><span class="sxs-lookup"><span data-stu-id="0ffb8-175">201</span></span>| <span data-ttu-id="0ffb8-176">Created</span><span class="sxs-lookup"><span data-stu-id="0ffb8-176">Created</span></span> | <span data-ttu-id="0ffb8-177">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-177">The entity was created.</span></span>| 
| <span data-ttu-id="0ffb8-178">400</span><span class="sxs-lookup"><span data-stu-id="0ffb8-178">400</span></span>| <span data-ttu-id="0ffb8-179">Bad Request</span><span class="sxs-lookup"><span data-stu-id="0ffb8-179">Bad Request</span></span> | <span data-ttu-id="0ffb8-180">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-180">Service could not understand malformed request.</span></span> <span data-ttu-id="0ffb8-181">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-181">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="0ffb8-182">401</span><span class="sxs-lookup"><span data-stu-id="0ffb8-182">401</span></span>| <span data-ttu-id="0ffb8-183">権限がありません</span><span class="sxs-lookup"><span data-stu-id="0ffb8-183">Unauthorized</span></span> | <span data-ttu-id="0ffb8-184">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-184">The request requires user authentication.</span></span>| 
| <span data-ttu-id="0ffb8-185">403</span><span class="sxs-lookup"><span data-stu-id="0ffb8-185">403</span></span>| <span data-ttu-id="0ffb8-186">Forbidden</span><span class="sxs-lookup"><span data-stu-id="0ffb8-186">Forbidden</span></span> | <span data-ttu-id="0ffb8-187">要求は、ユーザーまたはサービスは許可されません。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-187">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="0ffb8-188">404</span><span class="sxs-lookup"><span data-stu-id="0ffb8-188">404</span></span>| <span data-ttu-id="0ffb8-189">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-189">Not Found</span></span> | <span data-ttu-id="0ffb8-190">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-190">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="0ffb8-191">406</span><span class="sxs-lookup"><span data-stu-id="0ffb8-191">406</span></span>| <span data-ttu-id="0ffb8-192">許容できません。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-192">Not Acceptable</span></span> | <span data-ttu-id="0ffb8-193">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-193">Resource version is not supported.</span></span>| 
| <span data-ttu-id="0ffb8-194">408</span><span class="sxs-lookup"><span data-stu-id="0ffb8-194">408</span></span>| <span data-ttu-id="0ffb8-195">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="0ffb8-195">Request Timeout</span></span> | <span data-ttu-id="0ffb8-196">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-196">The request took too long to complete.</span></span>| 
| <span data-ttu-id="0ffb8-197">500</span><span class="sxs-lookup"><span data-stu-id="0ffb8-197">500</span></span>| <span data-ttu-id="0ffb8-198">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="0ffb8-198">Internal Server Error</span></span> | <span data-ttu-id="0ffb8-199">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-199">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="0ffb8-200">503</span><span class="sxs-lookup"><span data-stu-id="0ffb8-200">503</span></span>| <span data-ttu-id="0ffb8-201">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="0ffb8-201">Service Unavailable</span></span> | <span data-ttu-id="0ffb8-202">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-202">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EBDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="0ffb8-203">応答本文</span><span class="sxs-lookup"><span data-stu-id="0ffb8-203">Response body</span></span> 
 
<span data-ttu-id="0ffb8-204">アップロードが成功した場合は、{} への返信、201 が返されます。</span><span class="sxs-lookup"><span data-stu-id="0ffb8-204">If the upload is successful, a 201 is returned with a { } response.</span></span>
  
<a id="ID4EODAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="0ffb8-205">関連項目</span><span class="sxs-lookup"><span data-stu-id="0ffb8-205">See also</span></span>
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0ffb8-206">Parent</span><span class="sxs-lookup"><span data-stu-id="0ffb8-206">Parent</span></span>  

[<span data-ttu-id="0ffb8-207">/json/users/xuid({xuid})/scids/{scid} {scid}/data}、json</span><span class="sxs-lookup"><span data-stu-id="0ffb8-207">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

   