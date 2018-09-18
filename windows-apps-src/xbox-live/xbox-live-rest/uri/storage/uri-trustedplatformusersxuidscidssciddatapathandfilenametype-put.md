---
title: PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: ed037b64-6525-99a2-b7f6-050fdf345de8
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype-put.html
author: KevinAsgari
description: " PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0b64dae884231f36851e650b8ecad0c146741d8e
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4015133"
---
# <a name="put-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="a0721-104">PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="a0721-104">PUT (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="a0721-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="a0721-105">Uploads a file.</span></span> <span data-ttu-id="a0721-106">データやメタデータが送信される 1 つのメッセージで、または一連の小さいブロックのデータやメタデータが送信される複数のブロック アップロードとして完全なアップロードでは、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="a0721-106">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="a0721-107">1 つのメッセージとしては 4 つのメガバイト数よりも小さいファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="a0721-107">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="a0721-108">Json の種類のデータの複数のブロックのアップロードがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a0721-108">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="a0721-109">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="a0721-109">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="a0721-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0721-110">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="a0721-111">Authorization</span><span class="sxs-lookup"><span data-stu-id="a0721-111">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="a0721-112">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0721-112">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="a0721-113">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a0721-113">Required Request Headers</span></span>](#ID4EQE)
  * [<span data-ttu-id="a0721-114">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a0721-114">Optional Request Headers</span></span>](#ID4EZF)
  * [<span data-ttu-id="a0721-115">要求本文</span><span class="sxs-lookup"><span data-stu-id="a0721-115">Request body</span></span>](#ID4E3G)
  * [<span data-ttu-id="a0721-116">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="a0721-116">HTTP status codes</span></span>](#ID4EHH)
  * [<span data-ttu-id="a0721-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="a0721-117">Response body</span></span>](#ID4E1EAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="a0721-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0721-118">URI parameters</span></span> 
 
| <span data-ttu-id="a0721-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0721-119">Parameter</span></span>| <span data-ttu-id="a0721-120">型</span><span class="sxs-lookup"><span data-stu-id="a0721-120">Type</span></span>| <span data-ttu-id="a0721-121">説明</span><span class="sxs-lookup"><span data-stu-id="a0721-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a0721-122">xuid</span><span class="sxs-lookup"><span data-stu-id="a0721-122">xuid</span></span>| <span data-ttu-id="a0721-123">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a0721-123">unsigned 64-bit integer</span></span>| <span data-ttu-id="a0721-124">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="a0721-124">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="a0721-125">scid</span><span class="sxs-lookup"><span data-stu-id="a0721-125">scid</span></span>| <span data-ttu-id="a0721-126">guid</span><span class="sxs-lookup"><span data-stu-id="a0721-126">guid</span></span>| <span data-ttu-id="a0721-127">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="a0721-127">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="a0721-128">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="a0721-128">pathAndFileName</span></span>| <span data-ttu-id="a0721-129">string</span><span class="sxs-lookup"><span data-stu-id="a0721-129">string</span></span>| <span data-ttu-id="a0721-130">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="a0721-130">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="a0721-131">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="a0721-131">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="a0721-132">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="a0721-132">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="a0721-133">type</span><span class="sxs-lookup"><span data-stu-id="a0721-133">type</span></span>| <span data-ttu-id="a0721-134">文字列</span><span class="sxs-lookup"><span data-stu-id="a0721-134">string</span></span>| <span data-ttu-id="a0721-135">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="a0721-135">The format of the data.</span></span> <span data-ttu-id="a0721-136">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="a0721-136">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="a0721-137">Authorization</span><span class="sxs-lookup"><span data-stu-id="a0721-137">Authorization</span></span> 
 
<span data-ttu-id="a0721-138">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0721-138">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="a0721-139">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは 403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="a0721-139">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="a0721-140">ヘッダーが見つからないか無効な場合は、サービスは、401 不正な応答を返します。</span><span class="sxs-lookup"><span data-stu-id="a0721-140">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="a0721-141">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0721-141">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="a0721-142">1 つのメッセージのアップロードのクエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="a0721-142">For single message uploads, the query string parameters are:</span></span>
 
| <span data-ttu-id="a0721-143">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0721-143">Parameter</span></span>| <span data-ttu-id="a0721-144">型</span><span class="sxs-lookup"><span data-stu-id="a0721-144">Type</span></span>| <span data-ttu-id="a0721-145">説明</span><span class="sxs-lookup"><span data-stu-id="a0721-145">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a0721-146">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="a0721-146">clientFileTime</span></span>| <span data-ttu-id="a0721-147">DateTime</span><span class="sxs-lookup"><span data-stu-id="a0721-147">DateTime</span></span>| <span data-ttu-id="a0721-148">どのクライアント上のファイルの日付/時刻は最終ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="a0721-148">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="a0721-149">displayName</span><span class="sxs-lookup"><span data-stu-id="a0721-149">displayName</span></span>| <span data-ttu-id="a0721-150">string</span><span class="sxs-lookup"><span data-stu-id="a0721-150">string</span></span>| <span data-ttu-id="a0721-151">ファイルの名前、ユーザーに表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0721-151">Name of the file that should be shown to the user.</span></span>| 
 
<span data-ttu-id="a0721-152">複数のブロックのアップロードのクエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="a0721-152">For multi-block uploads, the query string parameters are:</span></span>
 
| <span data-ttu-id="a0721-153">パラメーター</span><span class="sxs-lookup"><span data-stu-id="a0721-153">Parameter</span></span>| <span data-ttu-id="a0721-154">型</span><span class="sxs-lookup"><span data-stu-id="a0721-154">Type</span></span>| <span data-ttu-id="a0721-155">説明</span><span class="sxs-lookup"><span data-stu-id="a0721-155">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a0721-156">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="a0721-156">clientFileTime</span></span>| <span data-ttu-id="a0721-157">DateTime</span><span class="sxs-lookup"><span data-stu-id="a0721-157">DateTime</span></span>| <span data-ttu-id="a0721-158">どのクライアント上のファイルの日付/時刻は最終ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="a0721-158">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="a0721-159">displayName</span><span class="sxs-lookup"><span data-stu-id="a0721-159">displayName</span></span>| <span data-ttu-id="a0721-160">string</span><span class="sxs-lookup"><span data-stu-id="a0721-160">string</span></span>| <span data-ttu-id="a0721-161">ファイルの名前、ユーザーに表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0721-161">Name of the file that should be shown to the user.</span></span>| 
| <span data-ttu-id="a0721-162">continuationToken</span><span class="sxs-lookup"><span data-stu-id="a0721-162">continuationToken</span></span>| <span data-ttu-id="a0721-163">string</span><span class="sxs-lookup"><span data-stu-id="a0721-163">string</span></span>| <span data-ttu-id="a0721-164">前回のアップロード要求の応答からの継続トークン。</span><span class="sxs-lookup"><span data-stu-id="a0721-164">The continuation token from the response of the previous upload request.</span></span> <span data-ttu-id="a0721-165">最初のブロックの場合は、これを指定しない必要があります。</span><span class="sxs-lookup"><span data-stu-id="a0721-165">If this is the first block, this should not be specified.</span></span> | 
| <span data-ttu-id="a0721-166">finalBlock</span><span class="sxs-lookup"><span data-stu-id="a0721-166">finalBlock</span></span>| <span data-ttu-id="a0721-167">bool</span><span class="sxs-lookup"><span data-stu-id="a0721-167">bool</span></span>| <span data-ttu-id="a0721-168">ファイルの最後のブロックを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="a0721-168">Set to true for the last block of the file.</span></span> <span data-ttu-id="a0721-169">その他のすべてのブロックでは false に設定します。</span><span class="sxs-lookup"><span data-stu-id="a0721-169">Set to false for all other blocks.</span></span>| 
  
<a id="ID4EQE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="a0721-170">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a0721-170">Required Request Headers</span></span>
 
| <span data-ttu-id="a0721-171">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a0721-171">Header</span></span>| <span data-ttu-id="a0721-172">設定値</span><span class="sxs-lookup"><span data-stu-id="a0721-172">Value</span></span>| <span data-ttu-id="a0721-173">説明</span><span class="sxs-lookup"><span data-stu-id="a0721-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a0721-174">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="a0721-174">x-xbl-contract-version</span></span>| <span data-ttu-id="a0721-175">1</span><span class="sxs-lookup"><span data-stu-id="a0721-175">1</span></span>| <span data-ttu-id="a0721-176">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="a0721-176">API contract version.</span></span>| 
| <span data-ttu-id="a0721-177">Authorization</span><span class="sxs-lookup"><span data-stu-id="a0721-177">Authorization</span></span>| <span data-ttu-id="a0721-178">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="a0721-178">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="a0721-179">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="a0721-179">STS authentication token.</span></span> <span data-ttu-id="a0721-180">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="a0721-180">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="a0721-181">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a0721-181">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EZF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="a0721-182">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a0721-182">Optional Request Headers</span></span>
 
| <span data-ttu-id="a0721-183">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="a0721-183">Header</span></span>| <span data-ttu-id="a0721-184">説明</span><span class="sxs-lookup"><span data-stu-id="a0721-184">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a0721-185">If-Match</span><span class="sxs-lookup"><span data-stu-id="a0721-185">If-Match</span></span>| <span data-ttu-id="a0721-186">操作を完了するにより既存項目と一致する ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="a0721-186">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="a0721-187">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="a0721-187">If-None-Match</span></span>| <span data-ttu-id="a0721-188">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="a0721-188">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4E3G"></a>

 
## <a name="request-body"></a><span data-ttu-id="a0721-189">要求本文</span><span class="sxs-lookup"><span data-stu-id="a0721-189">Request body</span></span> 
 
<span data-ttu-id="a0721-190">要求本文には、アップロードされているファイルの内容が含まれています。</span><span class="sxs-lookup"><span data-stu-id="a0721-190">The request body contains the contents of the file being uploaded.</span></span> <span data-ttu-id="a0721-191">1 つのメッセージのアップロード、本文は、ファイルの完全な内容です。</span><span class="sxs-lookup"><span data-stu-id="a0721-191">For single message uploads, the body is the complete contents of the file.</span></span> <span data-ttu-id="a0721-192">複数のブロックのアップロードの本文は、クエリ文字列パラメーターで指定されたファイルの部分です。</span><span class="sxs-lookup"><span data-stu-id="a0721-192">For multi-block uploads, the body is the portion of the file specified in the query string parameters.</span></span> 
  
<a id="ID4EHH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="a0721-193">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="a0721-193">HTTP status codes</span></span> 
 
<span data-ttu-id="a0721-194">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="a0721-194">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="a0721-195">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="a0721-195">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="a0721-196">コード</span><span class="sxs-lookup"><span data-stu-id="a0721-196">Code</span></span>| <span data-ttu-id="a0721-197">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="a0721-197">Reason phrase</span></span>| <span data-ttu-id="a0721-198">説明</span><span class="sxs-lookup"><span data-stu-id="a0721-198">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="a0721-199">200</span><span class="sxs-lookup"><span data-stu-id="a0721-199">200</span></span>| <span data-ttu-id="a0721-200">OK</span><span class="sxs-lookup"><span data-stu-id="a0721-200">OK</span></span> | <span data-ttu-id="a0721-201">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="a0721-201">The request was successful.</span></span>| 
| <span data-ttu-id="a0721-202">201</span><span class="sxs-lookup"><span data-stu-id="a0721-202">201</span></span>| <span data-ttu-id="a0721-203">Created</span><span class="sxs-lookup"><span data-stu-id="a0721-203">Created</span></span> | <span data-ttu-id="a0721-204">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="a0721-204">The entity was created.</span></span>| 
| <span data-ttu-id="a0721-205">400</span><span class="sxs-lookup"><span data-stu-id="a0721-205">400</span></span>| <span data-ttu-id="a0721-206">Bad Request</span><span class="sxs-lookup"><span data-stu-id="a0721-206">Bad Request</span></span> | <span data-ttu-id="a0721-207">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="a0721-207">Service could not understand malformed request.</span></span> <span data-ttu-id="a0721-208">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="a0721-208">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="a0721-209">401</span><span class="sxs-lookup"><span data-stu-id="a0721-209">401</span></span>| <span data-ttu-id="a0721-210">権限がありません</span><span class="sxs-lookup"><span data-stu-id="a0721-210">Unauthorized</span></span> | <span data-ttu-id="a0721-211">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="a0721-211">The request requires user authentication.</span></span>| 
| <span data-ttu-id="a0721-212">403</span><span class="sxs-lookup"><span data-stu-id="a0721-212">403</span></span>| <span data-ttu-id="a0721-213">Forbidden</span><span class="sxs-lookup"><span data-stu-id="a0721-213">Forbidden</span></span> | <span data-ttu-id="a0721-214">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="a0721-214">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="a0721-215">404</span><span class="sxs-lookup"><span data-stu-id="a0721-215">404</span></span>| <span data-ttu-id="a0721-216">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="a0721-216">Not Found</span></span> | <span data-ttu-id="a0721-217">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="a0721-217">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="a0721-218">406</span><span class="sxs-lookup"><span data-stu-id="a0721-218">406</span></span>| <span data-ttu-id="a0721-219">許容できません。</span><span class="sxs-lookup"><span data-stu-id="a0721-219">Not Acceptable</span></span> | <span data-ttu-id="a0721-220">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="a0721-220">Resource version is not supported.</span></span>| 
| <span data-ttu-id="a0721-221">408</span><span class="sxs-lookup"><span data-stu-id="a0721-221">408</span></span>| <span data-ttu-id="a0721-222">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="a0721-222">Request Timeout</span></span> | <span data-ttu-id="a0721-223">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="a0721-223">The request took too long to complete.</span></span>| 
| <span data-ttu-id="a0721-224">500</span><span class="sxs-lookup"><span data-stu-id="a0721-224">500</span></span>| <span data-ttu-id="a0721-225">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="a0721-225">Internal Server Error</span></span> | <span data-ttu-id="a0721-226">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="a0721-226">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="a0721-227">503</span><span class="sxs-lookup"><span data-stu-id="a0721-227">503</span></span>| <span data-ttu-id="a0721-228">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="a0721-228">Service Unavailable</span></span> | <span data-ttu-id="a0721-229">要求が調整された、クライアント再試行値 (例: 5 秒後) を秒単位で後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="a0721-229">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4E1EAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="a0721-230">応答本文</span><span class="sxs-lookup"><span data-stu-id="a0721-230">Response body</span></span> 
 
<span data-ttu-id="a0721-231">呼び出しは、複数のブロック要求が成功した場合は、サービスは次のブロックを渡す continution トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="a0721-231">If the call is a multi-block request and it is successful, the service will return a continution token to pass with the next block.</span></span>
 
<a id="ID4EGFAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="a0721-232">応答の例</span><span class="sxs-lookup"><span data-stu-id="a0721-232">Sample response</span></span>
 

```cpp
{
    "continuationToken":"abcd1234-1111-2222-3333-abcd12345678-1"
}
         
```

   
<a id="ID4ESFAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="a0721-233">関連項目</span><span class="sxs-lookup"><span data-stu-id="a0721-233">See also</span></span>
 
<a id="ID4EUFAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a0721-234">Parent</span><span class="sxs-lookup"><span data-stu-id="a0721-234">Parent</span></span>  

[<span data-ttu-id="a0721-235">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="a0721-235">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

   