---
title: GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: 203345eb-8092-7d38-6eab-cb7d53bda249
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype-get.html
author: KevinAsgari
description: " GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 25666c76f5eaafe4f53aaf3ff76eba68d4be275d
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882323"
---
# <a name="get-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="3da91-104">GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="3da91-104">GET (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="3da91-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="3da91-105">Downloads a file.</span></span> <span data-ttu-id="3da91-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3da91-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3da91-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3da91-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="3da91-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="3da91-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="3da91-109">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3da91-109">Optional Query String Parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="3da91-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-110">Required Request Headers</span></span>](#ID4EQC)
  * [<span data-ttu-id="3da91-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-111">Optional Request Headers</span></span>](#ID4EZD)
  * [<span data-ttu-id="3da91-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="3da91-112">Request body</span></span>](#ID4EDF)
  * [<span data-ttu-id="3da91-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3da91-113">HTTP status codes</span></span>](#ID4EQF)
  * [<span data-ttu-id="3da91-114">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-114">Response Headers</span></span>](#ID4EDDAC)
  * [<span data-ttu-id="3da91-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="3da91-115">Response body</span></span>](#ID4EGEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3da91-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3da91-116">URI parameters</span></span>
 
| <span data-ttu-id="3da91-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3da91-117">Parameter</span></span>| <span data-ttu-id="3da91-118">型</span><span class="sxs-lookup"><span data-stu-id="3da91-118">Type</span></span>| <span data-ttu-id="3da91-119">説明</span><span class="sxs-lookup"><span data-stu-id="3da91-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3da91-120">xuid</span><span class="sxs-lookup"><span data-stu-id="3da91-120">xuid</span></span>| <span data-ttu-id="3da91-121">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3da91-121">unsigned 64-bit integer</span></span>| <span data-ttu-id="3da91-122">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="3da91-122">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="3da91-123">scid</span><span class="sxs-lookup"><span data-stu-id="3da91-123">scid</span></span>| <span data-ttu-id="3da91-124">guid</span><span class="sxs-lookup"><span data-stu-id="3da91-124">guid</span></span>| <span data-ttu-id="3da91-125">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="3da91-125">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="3da91-126">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="3da91-126">pathAndFileName</span></span>| <span data-ttu-id="3da91-127">string</span><span class="sxs-lookup"><span data-stu-id="3da91-127">string</span></span>| <span data-ttu-id="3da91-128">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="3da91-128">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="3da91-129">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="3da91-129">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="3da91-130">ファイル名を空にする場合がありますはいない期間の終了または 2 つの連続するピリオドが含まれては。</span><span class="sxs-lookup"><span data-stu-id="3da91-130">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="3da91-131">type</span><span class="sxs-lookup"><span data-stu-id="3da91-131">type</span></span>| <span data-ttu-id="3da91-132">文字列</span><span class="sxs-lookup"><span data-stu-id="3da91-132">string</span></span>| <span data-ttu-id="3da91-133">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="3da91-133">The format of the data.</span></span> <span data-ttu-id="3da91-134">値はバイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="3da91-134">Possible values are binary or json.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="3da91-135">Authorization</span><span class="sxs-lookup"><span data-stu-id="3da91-135">Authorization</span></span> 
 
<span data-ttu-id="3da91-136">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3da91-136">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="3da91-137">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="3da91-137">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="3da91-138">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="3da91-138">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="3da91-139">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3da91-139">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="3da91-140">Blob の種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="3da91-140">Varies by blob type.</span></span> <span data-ttu-id="3da91-141">バイナリ blob には、クエリ パラメーターをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="3da91-141">Binary blobs do not support query parameters.</span></span>
 
| <span data-ttu-id="3da91-142">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3da91-142">Parameter</span></span>| <span data-ttu-id="3da91-143">型</span><span class="sxs-lookup"><span data-stu-id="3da91-143">Type</span></span>| <span data-ttu-id="3da91-144">説明</span><span class="sxs-lookup"><span data-stu-id="3da91-144">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3da91-145">選択</span><span class="sxs-lookup"><span data-stu-id="3da91-145">select</span></span>| <span data-ttu-id="3da91-146">string</span><span class="sxs-lookup"><span data-stu-id="3da91-146">string</span></span>| <span data-ttu-id="3da91-147">型は json ときにのみ使用します。</span><span class="sxs-lookup"><span data-stu-id="3da91-147">Only usable when type is json.</span></span> <span data-ttu-id="3da91-148">応答する必要がありますのみを含む特定プロパティ/値、JSON のこのパラメーターによって決定されるを指定します。</span><span class="sxs-lookup"><span data-stu-id="3da91-148">Specifies that the response should only contain a certain property/value of the JSON, as determined by this parameter.</span></span> <span data-ttu-id="3da91-149">「ドット」(.) を使用して、サブプロパティ、角かっこを指定 ("['、']') 配列のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="3da91-149">Use a "dot" (.) to specify sub-properties and square brackets ('[' and ']') to specify array indices.</span></span> <span data-ttu-id="3da91-150">たとえば、"配列 1 [4] .prop2"の 4、配列のインデックス配列「1」、"prop2"プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="3da91-150">For example, "array1[4].prop2" specifies the "prop2" property of index 4 of the "array1" array.</span></span>| 
  
<a id="ID4EQC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="3da91-151">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-151">Required Request Headers</span></span>
 
| <span data-ttu-id="3da91-152">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-152">Header</span></span>| <span data-ttu-id="3da91-153">設定値</span><span class="sxs-lookup"><span data-stu-id="3da91-153">Value</span></span>| <span data-ttu-id="3da91-154">説明</span><span class="sxs-lookup"><span data-stu-id="3da91-154">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3da91-155">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="3da91-155">x-xbl-contract-version</span></span>| <span data-ttu-id="3da91-156">1</span><span class="sxs-lookup"><span data-stu-id="3da91-156">1</span></span>| <span data-ttu-id="3da91-157">API コントラクト バージョン。</span><span class="sxs-lookup"><span data-stu-id="3da91-157">API contract version.</span></span>| 
| <span data-ttu-id="3da91-158">Authorization</span><span class="sxs-lookup"><span data-stu-id="3da91-158">Authorization</span></span>| <span data-ttu-id="3da91-159">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="3da91-159">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="3da91-160">STS 認証トークン。</span><span class="sxs-lookup"><span data-stu-id="3da91-160">STS authentication token.</span></span> <span data-ttu-id="3da91-161">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="3da91-161">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="3da91-162">STS トークンを取得して、承認ヘッダーの作成について詳しくは、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3da91-162">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EZD"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="3da91-163">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-163">Optional Request Headers</span></span>
 
| <span data-ttu-id="3da91-164">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-164">Header</span></span>| <span data-ttu-id="3da91-165">説明</span><span class="sxs-lookup"><span data-stu-id="3da91-165">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3da91-166">If-Match</span><span class="sxs-lookup"><span data-stu-id="3da91-166">If-Match</span></span>| <span data-ttu-id="3da91-167">操作を完了するにより既存項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="3da91-167">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="3da91-168">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="3da91-168">If-None-Match</span></span>| <span data-ttu-id="3da91-169">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="3da91-169">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
| <span data-ttu-id="3da91-170">範囲</span><span class="sxs-lookup"><span data-stu-id="3da91-170">Range</span></span>| <span data-ttu-id="3da91-171">ダウンロードのバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="3da91-171">Specifies the range of bytes to download.</span></span> <span data-ttu-id="3da91-172">標準の範囲の HTTP ヘッダーの形式に従います。</span><span class="sxs-lookup"><span data-stu-id="3da91-172">Follows the standard HTTP Range header format.</span></span>| 
  
<a id="ID4EDF"></a>

 
## <a name="request-body"></a><span data-ttu-id="3da91-173">要求本文</span><span class="sxs-lookup"><span data-stu-id="3da91-173">Request body</span></span> 
 
<span data-ttu-id="3da91-174">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="3da91-174">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EQF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="3da91-175">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3da91-175">HTTP status codes</span></span> 
 
<span data-ttu-id="3da91-176">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="3da91-176">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="3da91-177">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3da91-177">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="3da91-178">コード</span><span class="sxs-lookup"><span data-stu-id="3da91-178">Code</span></span>| <span data-ttu-id="3da91-179">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="3da91-179">Reason phrase</span></span>| <span data-ttu-id="3da91-180">説明</span><span class="sxs-lookup"><span data-stu-id="3da91-180">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3da91-181">200</span><span class="sxs-lookup"><span data-stu-id="3da91-181">200</span></span>| <span data-ttu-id="3da91-182">OK</span><span class="sxs-lookup"><span data-stu-id="3da91-182">OK</span></span> | <span data-ttu-id="3da91-183">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="3da91-183">The request was successful.</span></span>| 
| <span data-ttu-id="3da91-184">201</span><span class="sxs-lookup"><span data-stu-id="3da91-184">201</span></span>| <span data-ttu-id="3da91-185">Created</span><span class="sxs-lookup"><span data-stu-id="3da91-185">Created</span></span> | <span data-ttu-id="3da91-186">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="3da91-186">The entity was created.</span></span>| 
| <span data-ttu-id="3da91-187">400</span><span class="sxs-lookup"><span data-stu-id="3da91-187">400</span></span>| <span data-ttu-id="3da91-188">Bad Request</span><span class="sxs-lookup"><span data-stu-id="3da91-188">Bad Request</span></span> | <span data-ttu-id="3da91-189">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3da91-189">Service could not understand malformed request.</span></span> <span data-ttu-id="3da91-190">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="3da91-190">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="3da91-191">401</span><span class="sxs-lookup"><span data-stu-id="3da91-191">401</span></span>| <span data-ttu-id="3da91-192">権限がありません</span><span class="sxs-lookup"><span data-stu-id="3da91-192">Unauthorized</span></span> | <span data-ttu-id="3da91-193">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="3da91-193">The request requires user authentication.</span></span>| 
| <span data-ttu-id="3da91-194">403</span><span class="sxs-lookup"><span data-stu-id="3da91-194">403</span></span>| <span data-ttu-id="3da91-195">Forbidden</span><span class="sxs-lookup"><span data-stu-id="3da91-195">Forbidden</span></span> | <span data-ttu-id="3da91-196">要求は、ユーザーまたはサービスは許可されません。</span><span class="sxs-lookup"><span data-stu-id="3da91-196">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="3da91-197">404</span><span class="sxs-lookup"><span data-stu-id="3da91-197">404</span></span>| <span data-ttu-id="3da91-198">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="3da91-198">Not Found</span></span> | <span data-ttu-id="3da91-199">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="3da91-199">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="3da91-200">406</span><span class="sxs-lookup"><span data-stu-id="3da91-200">406</span></span>| <span data-ttu-id="3da91-201">許容できません。</span><span class="sxs-lookup"><span data-stu-id="3da91-201">Not Acceptable</span></span> | <span data-ttu-id="3da91-202">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3da91-202">Resource version is not supported.</span></span>| 
| <span data-ttu-id="3da91-203">408</span><span class="sxs-lookup"><span data-stu-id="3da91-203">408</span></span>| <span data-ttu-id="3da91-204">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="3da91-204">Request Timeout</span></span> | <span data-ttu-id="3da91-205">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="3da91-205">The request took too long to complete.</span></span>| 
| <span data-ttu-id="3da91-206">500</span><span class="sxs-lookup"><span data-stu-id="3da91-206">500</span></span>| <span data-ttu-id="3da91-207">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="3da91-207">Internal Server Error</span></span> | <span data-ttu-id="3da91-208">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="3da91-208">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="3da91-209">503</span><span class="sxs-lookup"><span data-stu-id="3da91-209">503</span></span>| <span data-ttu-id="3da91-210">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="3da91-210">Service Unavailable</span></span> | <span data-ttu-id="3da91-211">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="3da91-211">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EDDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="3da91-212">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-212">Response Headers</span></span>
 
| <span data-ttu-id="3da91-213">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3da91-213">Header</span></span>| <span data-ttu-id="3da91-214">説明</span><span class="sxs-lookup"><span data-stu-id="3da91-214">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3da91-215">ETag</span><span class="sxs-lookup"><span data-stu-id="3da91-215">ETag</span></span>| <span data-ttu-id="3da91-216">ETag は、特定のバージョンの URL でリソースを web サーバーによって割り当てられる不透明な識別子です。</span><span class="sxs-lookup"><span data-stu-id="3da91-216">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="3da91-217">その URL でリソース コンテンツが変更された場合は、新規および別の ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="3da91-217">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="3da91-218">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="3da91-218">Content-Range</span></span>| <span data-ttu-id="3da91-219">これは、部分的なダウンロードでしたが、このヘッダーは、ダウンロードされたバイト数の範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="3da91-219">If this was a partial download, this header specifies the range of bytes downloaded.</span></span>| 
  
<a id="ID4EGEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="3da91-220">応答本文</span><span class="sxs-lookup"><span data-stu-id="3da91-220">Response body</span></span>
<span data-ttu-id="3da91-221">呼び出しが成功した場合、サービスは、ファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="3da91-221">If the call is successful, the service will return the contents of the file.</span></span>  
<a id="ID4EPEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="3da91-222">関連項目</span><span class="sxs-lookup"><span data-stu-id="3da91-222">See also</span></span>
 
<a id="ID4EREAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3da91-223">Parent</span><span class="sxs-lookup"><span data-stu-id="3da91-223">Parent</span></span>  

[<span data-ttu-id="3da91-224">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="3da91-224">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

  
<a id="ID4E4EAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="3da91-225">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="3da91-225">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

   