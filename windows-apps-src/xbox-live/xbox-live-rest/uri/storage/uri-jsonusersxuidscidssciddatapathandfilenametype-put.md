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
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4570287"
---
# <a name="put-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="09df0-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="09df0-104">PUT (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="09df0-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="09df0-105">Uploads a file.</span></span> <span data-ttu-id="09df0-106">Json の種類のデータの複数のブロックのアップロードはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="09df0-106">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="09df0-107">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="09df0-107">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="09df0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09df0-108">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="09df0-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="09df0-109">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="09df0-110">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="09df0-110">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="09df0-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09df0-111">Required Request Headers</span></span>](#ID4EXC)
  * [<span data-ttu-id="09df0-112">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09df0-112">Optional Request Headers</span></span>](#ID4EAE)
  * [<span data-ttu-id="09df0-113">要求本文</span><span class="sxs-lookup"><span data-stu-id="09df0-113">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="09df0-114">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="09df0-114">HTTP status codes</span></span>](#ID4EOF)
  * [<span data-ttu-id="09df0-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="09df0-115">Response body</span></span>](#ID4EBDAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="09df0-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="09df0-116">URI parameters</span></span> 
 
| <span data-ttu-id="09df0-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09df0-117">Parameter</span></span>| <span data-ttu-id="09df0-118">型</span><span class="sxs-lookup"><span data-stu-id="09df0-118">Type</span></span>| <span data-ttu-id="09df0-119">説明</span><span class="sxs-lookup"><span data-stu-id="09df0-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="09df0-120">xuid</span><span class="sxs-lookup"><span data-stu-id="09df0-120">xuid</span></span>| <span data-ttu-id="09df0-121">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="09df0-121">unsigned 64-bit integer</span></span>| <span data-ttu-id="09df0-122">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="09df0-122">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="09df0-123">scid</span><span class="sxs-lookup"><span data-stu-id="09df0-123">scid</span></span>| <span data-ttu-id="09df0-124">guid</span><span class="sxs-lookup"><span data-stu-id="09df0-124">guid</span></span>| <span data-ttu-id="09df0-125">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="09df0-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="09df0-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="09df0-126">pathAndFileName</span></span>| <span data-ttu-id="09df0-127">string</span><span class="sxs-lookup"><span data-stu-id="09df0-127">string</span></span>| <span data-ttu-id="09df0-128">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="09df0-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="09df0-129">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="09df0-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="09df0-130">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="09df0-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="09df0-131">Authorization</span><span class="sxs-lookup"><span data-stu-id="09df0-131">Authorization</span></span> 
 
<span data-ttu-id="09df0-132">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="09df0-132">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="09df0-133">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは 403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="09df0-133">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="09df0-134">ヘッダーが見つからないか無効な場合は、サービスは 401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="09df0-134">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="09df0-135">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="09df0-135">Optional Query String Parameters</span></span> 
 
| <span data-ttu-id="09df0-136">パラメーター</span><span class="sxs-lookup"><span data-stu-id="09df0-136">Parameter</span></span>| <span data-ttu-id="09df0-137">型</span><span class="sxs-lookup"><span data-stu-id="09df0-137">Type</span></span>| <span data-ttu-id="09df0-138">説明</span><span class="sxs-lookup"><span data-stu-id="09df0-138">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09df0-139">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="09df0-139">clientFileTime</span></span>| <span data-ttu-id="09df0-140">DateTime</span><span class="sxs-lookup"><span data-stu-id="09df0-140">DateTime</span></span>| <span data-ttu-id="09df0-141">どのクライアント上のファイルの日付/時刻は、最終ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="09df0-141">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="09df0-142">displayName</span><span class="sxs-lookup"><span data-stu-id="09df0-142">displayName</span></span>| <span data-ttu-id="09df0-143">string</span><span class="sxs-lookup"><span data-stu-id="09df0-143">string</span></span>| <span data-ttu-id="09df0-144">ユーザーに表示する必要があるファイルの名前。</span><span class="sxs-lookup"><span data-stu-id="09df0-144">Name of the file that should be shown to the user.</span></span>| 
  
<a id="ID4EXC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="09df0-145">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09df0-145">Required Request Headers</span></span>
 
| <span data-ttu-id="09df0-146">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09df0-146">Header</span></span>| <span data-ttu-id="09df0-147">設定値</span><span class="sxs-lookup"><span data-stu-id="09df0-147">Value</span></span>| <span data-ttu-id="09df0-148">説明</span><span class="sxs-lookup"><span data-stu-id="09df0-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09df0-149">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="09df0-149">x-xbl-contract-version</span></span>| <span data-ttu-id="09df0-150">1</span><span class="sxs-lookup"><span data-stu-id="09df0-150">1</span></span>| <span data-ttu-id="09df0-151">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="09df0-151">API contract version.</span></span>| 
| <span data-ttu-id="09df0-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="09df0-152">Authorization</span></span>| <span data-ttu-id="09df0-153">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="09df0-153">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="09df0-154">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="09df0-154">STS authentication token.</span></span> <span data-ttu-id="09df0-155">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="09df0-155">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="09df0-156">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="09df0-156">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EAE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="09df0-157">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09df0-157">Optional Request Headers</span></span>
 
| <span data-ttu-id="09df0-158">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="09df0-158">Header</span></span>| <span data-ttu-id="09df0-159">説明</span><span class="sxs-lookup"><span data-stu-id="09df0-159">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09df0-160">If-Match</span><span class="sxs-lookup"><span data-stu-id="09df0-160">If-Match</span></span>| <span data-ttu-id="09df0-161">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="09df0-161">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="09df0-162">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="09df0-162">If-None-Match</span></span>| <span data-ttu-id="09df0-163">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="09df0-163">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="09df0-164">要求本文</span><span class="sxs-lookup"><span data-stu-id="09df0-164">Request body</span></span> 
 
<span data-ttu-id="09df0-165">要求本文には、アップロードされているファイルの完全なコンテンツが含まれています。</span><span class="sxs-lookup"><span data-stu-id="09df0-165">The request body contains the complete contents of the file being uploaded.</span></span> 
  
<a id="ID4EOF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="09df0-166">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="09df0-166">HTTP status codes</span></span> 
 
<span data-ttu-id="09df0-167">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="09df0-167">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="09df0-168">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="09df0-168">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="09df0-169">コード</span><span class="sxs-lookup"><span data-stu-id="09df0-169">Code</span></span>| <span data-ttu-id="09df0-170">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="09df0-170">Reason phrase</span></span>| <span data-ttu-id="09df0-171">説明</span><span class="sxs-lookup"><span data-stu-id="09df0-171">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="09df0-172">200</span><span class="sxs-lookup"><span data-stu-id="09df0-172">200</span></span>| <span data-ttu-id="09df0-173">OK</span><span class="sxs-lookup"><span data-stu-id="09df0-173">OK</span></span> | <span data-ttu-id="09df0-174">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="09df0-174">The request was successful.</span></span>| 
| <span data-ttu-id="09df0-175">201</span><span class="sxs-lookup"><span data-stu-id="09df0-175">201</span></span>| <span data-ttu-id="09df0-176">Created</span><span class="sxs-lookup"><span data-stu-id="09df0-176">Created</span></span> | <span data-ttu-id="09df0-177">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="09df0-177">The entity was created.</span></span>| 
| <span data-ttu-id="09df0-178">400</span><span class="sxs-lookup"><span data-stu-id="09df0-178">400</span></span>| <span data-ttu-id="09df0-179">Bad Request</span><span class="sxs-lookup"><span data-stu-id="09df0-179">Bad Request</span></span> | <span data-ttu-id="09df0-180">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="09df0-180">Service could not understand malformed request.</span></span> <span data-ttu-id="09df0-181">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="09df0-181">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="09df0-182">401</span><span class="sxs-lookup"><span data-stu-id="09df0-182">401</span></span>| <span data-ttu-id="09df0-183">権限がありません</span><span class="sxs-lookup"><span data-stu-id="09df0-183">Unauthorized</span></span> | <span data-ttu-id="09df0-184">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="09df0-184">The request requires user authentication.</span></span>| 
| <span data-ttu-id="09df0-185">403</span><span class="sxs-lookup"><span data-stu-id="09df0-185">403</span></span>| <span data-ttu-id="09df0-186">Forbidden</span><span class="sxs-lookup"><span data-stu-id="09df0-186">Forbidden</span></span> | <span data-ttu-id="09df0-187">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="09df0-187">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="09df0-188">404</span><span class="sxs-lookup"><span data-stu-id="09df0-188">404</span></span>| <span data-ttu-id="09df0-189">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="09df0-189">Not Found</span></span> | <span data-ttu-id="09df0-190">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="09df0-190">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="09df0-191">406</span><span class="sxs-lookup"><span data-stu-id="09df0-191">406</span></span>| <span data-ttu-id="09df0-192">許容できません。</span><span class="sxs-lookup"><span data-stu-id="09df0-192">Not Acceptable</span></span> | <span data-ttu-id="09df0-193">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="09df0-193">Resource version is not supported.</span></span>| 
| <span data-ttu-id="09df0-194">408</span><span class="sxs-lookup"><span data-stu-id="09df0-194">408</span></span>| <span data-ttu-id="09df0-195">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="09df0-195">Request Timeout</span></span> | <span data-ttu-id="09df0-196">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="09df0-196">The request took too long to complete.</span></span>| 
| <span data-ttu-id="09df0-197">500</span><span class="sxs-lookup"><span data-stu-id="09df0-197">500</span></span>| <span data-ttu-id="09df0-198">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="09df0-198">Internal Server Error</span></span> | <span data-ttu-id="09df0-199">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="09df0-199">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="09df0-200">503</span><span class="sxs-lookup"><span data-stu-id="09df0-200">503</span></span>| <span data-ttu-id="09df0-201">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="09df0-201">Service Unavailable</span></span> | <span data-ttu-id="09df0-202">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="09df0-202">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EBDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="09df0-203">応答本文</span><span class="sxs-lookup"><span data-stu-id="09df0-203">Response body</span></span> 
 
<span data-ttu-id="09df0-204">アップロードが成功した場合は、{} への返信を 201 が返されます。</span><span class="sxs-lookup"><span data-stu-id="09df0-204">If the upload is successful, a 201 is returned with a { } response.</span></span>
  
<a id="ID4EODAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="09df0-205">関連項目</span><span class="sxs-lookup"><span data-stu-id="09df0-205">See also</span></span>
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="09df0-206">Parent</span><span class="sxs-lookup"><span data-stu-id="09df0-206">Parent</span></span>  

[<span data-ttu-id="09df0-207">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="09df0-207">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

   