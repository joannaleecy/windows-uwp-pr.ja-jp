---
title: PUT (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: b40a1a88-02c2-624f-de00-49664825bde3
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersxuidscidssciddatapathandfilenametype-put.html
author: KevinAsgari
description: " PUT (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: afffb705758c70fd65e01f0ff211254a3f2638d2
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881770"
---
# <a name="put-untrustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="c8eb6-104">PUT (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="c8eb6-104">PUT (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="c8eb6-105">ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-105">Uploads a file.</span></span> <span data-ttu-id="c8eb6-106">メタデータとデータが送信される 1 つのメッセージで、または一連の小さいブロックのデータやメタデータが送信される複数のブロック アップロードとして完全なアップロードでは、データをアップロードできます。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-106">The data can be uploaded in a full upload in which the data and metadata are sent in a single message, or as a multi-block upload in which the data and metadata are sent in a series of smaller blocks.</span></span> <span data-ttu-id="c8eb6-107">1 つのメッセージとしては 4 つのメガバイト数よりも小さいファイルのみを送信できます。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-107">Only files that are smaller than four megabytes can be sent as a single message.</span></span> <span data-ttu-id="c8eb6-108">複数のブロックのアップロードの種類の json データはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-108">Multi-block upload is not supported for data of type json.</span></span> <span data-ttu-id="c8eb6-109">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-109">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="c8eb6-110">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8eb6-110">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="c8eb6-111">Authorization</span><span class="sxs-lookup"><span data-stu-id="c8eb6-111">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="c8eb6-112">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8eb6-112">Optional Query String Parameters</span></span>](#ID4ERB)
  * [<span data-ttu-id="c8eb6-113">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c8eb6-113">Required Request Headers</span></span>](#ID4EOE)
  * [<span data-ttu-id="c8eb6-114">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c8eb6-114">Optional Request Headers</span></span>](#ID4EXF)
  * [<span data-ttu-id="c8eb6-115">要求本文</span><span class="sxs-lookup"><span data-stu-id="c8eb6-115">Request body</span></span>](#ID4E1G)
  * [<span data-ttu-id="c8eb6-116">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c8eb6-116">HTTP status codes</span></span>](#ID4EFH)
  * [<span data-ttu-id="c8eb6-117">応答本文</span><span class="sxs-lookup"><span data-stu-id="c8eb6-117">Response body</span></span>](#ID4EYEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="c8eb6-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8eb6-118">URI parameters</span></span> 
 
| <span data-ttu-id="c8eb6-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8eb6-119">Parameter</span></span>| <span data-ttu-id="c8eb6-120">型</span><span class="sxs-lookup"><span data-stu-id="c8eb6-120">Type</span></span>| <span data-ttu-id="c8eb6-121">説明</span><span class="sxs-lookup"><span data-stu-id="c8eb6-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c8eb6-122">xuid</span><span class="sxs-lookup"><span data-stu-id="c8eb6-122">xuid</span></span>| <span data-ttu-id="c8eb6-123">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c8eb6-123">unsigned 64-bit integer</span></span>| <span data-ttu-id="c8eb6-124">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-124">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="c8eb6-125">scid</span><span class="sxs-lookup"><span data-stu-id="c8eb6-125">scid</span></span>| <span data-ttu-id="c8eb6-126">guid</span><span class="sxs-lookup"><span data-stu-id="c8eb6-126">guid</span></span>| <span data-ttu-id="c8eb6-127">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-127">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="c8eb6-128">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="c8eb6-128">pathAndFileName</span></span>| <span data-ttu-id="c8eb6-129">string</span><span class="sxs-lookup"><span data-stu-id="c8eb6-129">string</span></span>| <span data-ttu-id="c8eb6-130">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-130">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="c8eb6-131">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-131">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="c8eb6-132">ファイル名を空にする場合がありますはいない期間の終了または 2 つの連続するピリオドが含まれては。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-132">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="c8eb6-133">type</span><span class="sxs-lookup"><span data-stu-id="c8eb6-133">type</span></span>| <span data-ttu-id="c8eb6-134">文字列</span><span class="sxs-lookup"><span data-stu-id="c8eb6-134">string</span></span>| <span data-ttu-id="c8eb6-135">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-135">The format of the data.</span></span> <span data-ttu-id="c8eb6-136">値はバイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-136">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="c8eb6-137">Authorization</span><span class="sxs-lookup"><span data-stu-id="c8eb6-137">Authorization</span></span> 
 
<span data-ttu-id="c8eb6-138">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-138">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="c8eb6-139">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-139">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="c8eb6-140">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-140">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="c8eb6-141">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8eb6-141">Optional Query String Parameters</span></span> 
<span data-ttu-id="c8eb6-142">1 つのメッセージのアップロードは、クエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-142">For single message uploads, the query string parameters are:</span></span> 
| <span data-ttu-id="c8eb6-143">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8eb6-143">Parameter</span></span>| <span data-ttu-id="c8eb6-144">型</span><span class="sxs-lookup"><span data-stu-id="c8eb6-144">Type</span></span>| <span data-ttu-id="c8eb6-145">説明</span><span class="sxs-lookup"><span data-stu-id="c8eb6-145">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c8eb6-146">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="c8eb6-146">clientFileTime</span></span>| <span data-ttu-id="c8eb6-147">DateTime</span><span class="sxs-lookup"><span data-stu-id="c8eb6-147">DateTime</span></span>| <span data-ttu-id="c8eb6-148">どのクライアント上のファイルの日付/時刻は、最終ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-148">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="c8eb6-149">displayName</span><span class="sxs-lookup"><span data-stu-id="c8eb6-149">displayName</span></span>| <span data-ttu-id="c8eb6-150">string</span><span class="sxs-lookup"><span data-stu-id="c8eb6-150">string</span></span>| <span data-ttu-id="c8eb6-151">ユーザーに表示する必要がありますファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-151">Name of the file that should be shown to the user.</span></span>| 
 
<span data-ttu-id="c8eb6-152">複数のブロックのアップロードは、クエリ文字列パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-152">For multi-block uploads, the query string parameters are:</span></span>
 
| <span data-ttu-id="c8eb6-153">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c8eb6-153">Parameter</span></span>| <span data-ttu-id="c8eb6-154">型</span><span class="sxs-lookup"><span data-stu-id="c8eb6-154">Type</span></span>| <span data-ttu-id="c8eb6-155">説明</span><span class="sxs-lookup"><span data-stu-id="c8eb6-155">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c8eb6-156">clientFileTime</span><span class="sxs-lookup"><span data-stu-id="c8eb6-156">clientFileTime</span></span>| <span data-ttu-id="c8eb6-157">DateTime</span><span class="sxs-lookup"><span data-stu-id="c8eb6-157">DateTime</span></span>| <span data-ttu-id="c8eb6-158">どのクライアント上のファイルの日付/時刻は、最終ファイルをアップロードします。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-158">Date/Time of the file on whatever client last uploaded the file.</span></span>| 
| <span data-ttu-id="c8eb6-159">displayName</span><span class="sxs-lookup"><span data-stu-id="c8eb6-159">displayName</span></span>| <span data-ttu-id="c8eb6-160">string</span><span class="sxs-lookup"><span data-stu-id="c8eb6-160">string</span></span>| <span data-ttu-id="c8eb6-161">ユーザーに表示する必要がありますファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-161">Name of the file that should be shown to the user.</span></span>| 
| <span data-ttu-id="c8eb6-162">continuationToken</span><span class="sxs-lookup"><span data-stu-id="c8eb6-162">continuationToken</span></span>| <span data-ttu-id="c8eb6-163">string</span><span class="sxs-lookup"><span data-stu-id="c8eb6-163">string</span></span>| <span data-ttu-id="c8eb6-164">前回のアップロード要求の応答には、継続トークン。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-164">The continuation token from the response of the previous upload request.</span></span> <span data-ttu-id="c8eb6-165">最初のブロックの場合は、これを指定しない必要があります。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-165">If this is the first block, this should not be specified.</span></span> | 
| <span data-ttu-id="c8eb6-166">finalBlock</span><span class="sxs-lookup"><span data-stu-id="c8eb6-166">finalBlock</span></span>| <span data-ttu-id="c8eb6-167">bool</span><span class="sxs-lookup"><span data-stu-id="c8eb6-167">bool</span></span>| <span data-ttu-id="c8eb6-168">ファイルの最後のブロックを true に設定します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-168">Set to true for the last block of the file.</span></span> <span data-ttu-id="c8eb6-169">その他のすべてのブロックでは false に設定します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-169">Set to false for all other blocks.</span></span>| 
  
<a id="ID4EOE"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="c8eb6-170">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c8eb6-170">Required Request Headers</span></span>
 
| <span data-ttu-id="c8eb6-171">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c8eb6-171">Header</span></span>| <span data-ttu-id="c8eb6-172">設定値</span><span class="sxs-lookup"><span data-stu-id="c8eb6-172">Value</span></span>| <span data-ttu-id="c8eb6-173">説明</span><span class="sxs-lookup"><span data-stu-id="c8eb6-173">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c8eb6-174">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="c8eb6-174">x-xbl-contract-version</span></span>| <span data-ttu-id="c8eb6-175">1</span><span class="sxs-lookup"><span data-stu-id="c8eb6-175">1</span></span>| <span data-ttu-id="c8eb6-176">API コントラクト バージョン。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-176">API contract version.</span></span>| 
| <span data-ttu-id="c8eb6-177">Authorization</span><span class="sxs-lookup"><span data-stu-id="c8eb6-177">Authorization</span></span>| <span data-ttu-id="c8eb6-178">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="c8eb6-178">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="c8eb6-179">STS 認証トークン。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-179">STS authentication token.</span></span> <span data-ttu-id="c8eb6-180">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-180">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="c8eb6-181">STS トークンを取得して、承認ヘッダーの作成について詳しくは、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-181">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4EXF"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="c8eb6-182">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c8eb6-182">Optional Request Headers</span></span>
 
| <span data-ttu-id="c8eb6-183">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="c8eb6-183">Header</span></span>| <span data-ttu-id="c8eb6-184">説明</span><span class="sxs-lookup"><span data-stu-id="c8eb6-184">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c8eb6-185">If-Match</span><span class="sxs-lookup"><span data-stu-id="c8eb6-185">If-Match</span></span>| <span data-ttu-id="c8eb6-186">操作を完了するにより既存項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-186">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="c8eb6-187">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="c8eb6-187">If-None-Match</span></span>| <span data-ttu-id="c8eb6-188">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-188">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
  
<a id="ID4E1G"></a>

 
## <a name="request-body"></a><span data-ttu-id="c8eb6-189">要求本文</span><span class="sxs-lookup"><span data-stu-id="c8eb6-189">Request body</span></span> 
 
<span data-ttu-id="c8eb6-190">要求本文には、アップロードされているファイルの内容が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-190">The request body contains the contents of the file being uploaded.</span></span> <span data-ttu-id="c8eb6-191">1 つのメッセージのアップロード、本体は、ファイルの完全な内容です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-191">For single message uploads, the body is the complete contents of the file.</span></span> <span data-ttu-id="c8eb6-192">複数のブロックのアップロードの本文は、クエリ文字列パラメーターで指定されたファイルの部分です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-192">For multi-block uploads, the body is the portion of the file specified in the query string parameters.</span></span> 
  
<a id="ID4EFH"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="c8eb6-193">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="c8eb6-193">HTTP status codes</span></span> 
 
<span data-ttu-id="c8eb6-194">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-194">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="c8eb6-195">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-195">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="c8eb6-196">コード</span><span class="sxs-lookup"><span data-stu-id="c8eb6-196">Code</span></span>| <span data-ttu-id="c8eb6-197">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="c8eb6-197">Reason phrase</span></span>| <span data-ttu-id="c8eb6-198">説明</span><span class="sxs-lookup"><span data-stu-id="c8eb6-198">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="c8eb6-199">200</span><span class="sxs-lookup"><span data-stu-id="c8eb6-199">200</span></span>| <span data-ttu-id="c8eb6-200">OK</span><span class="sxs-lookup"><span data-stu-id="c8eb6-200">OK</span></span> | <span data-ttu-id="c8eb6-201">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-201">The request was successful.</span></span>| 
| <span data-ttu-id="c8eb6-202">201</span><span class="sxs-lookup"><span data-stu-id="c8eb6-202">201</span></span>| <span data-ttu-id="c8eb6-203">Created</span><span class="sxs-lookup"><span data-stu-id="c8eb6-203">Created</span></span> | <span data-ttu-id="c8eb6-204">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-204">The entity was created.</span></span>| 
| <span data-ttu-id="c8eb6-205">400</span><span class="sxs-lookup"><span data-stu-id="c8eb6-205">400</span></span>| <span data-ttu-id="c8eb6-206">Bad Request</span><span class="sxs-lookup"><span data-stu-id="c8eb6-206">Bad Request</span></span> | <span data-ttu-id="c8eb6-207">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-207">Service could not understand malformed request.</span></span> <span data-ttu-id="c8eb6-208">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-208">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="c8eb6-209">401</span><span class="sxs-lookup"><span data-stu-id="c8eb6-209">401</span></span>| <span data-ttu-id="c8eb6-210">権限がありません</span><span class="sxs-lookup"><span data-stu-id="c8eb6-210">Unauthorized</span></span> | <span data-ttu-id="c8eb6-211">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-211">The request requires user authentication.</span></span>| 
| <span data-ttu-id="c8eb6-212">403</span><span class="sxs-lookup"><span data-stu-id="c8eb6-212">403</span></span>| <span data-ttu-id="c8eb6-213">Forbidden</span><span class="sxs-lookup"><span data-stu-id="c8eb6-213">Forbidden</span></span> | <span data-ttu-id="c8eb6-214">要求は、ユーザーまたはサービスは許可されません。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-214">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="c8eb6-215">404</span><span class="sxs-lookup"><span data-stu-id="c8eb6-215">404</span></span>| <span data-ttu-id="c8eb6-216">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-216">Not Found</span></span> | <span data-ttu-id="c8eb6-217">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-217">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="c8eb6-218">406</span><span class="sxs-lookup"><span data-stu-id="c8eb6-218">406</span></span>| <span data-ttu-id="c8eb6-219">許容できません。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-219">Not Acceptable</span></span> | <span data-ttu-id="c8eb6-220">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-220">Resource version is not supported.</span></span>| 
| <span data-ttu-id="c8eb6-221">408</span><span class="sxs-lookup"><span data-stu-id="c8eb6-221">408</span></span>| <span data-ttu-id="c8eb6-222">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="c8eb6-222">Request Timeout</span></span> | <span data-ttu-id="c8eb6-223">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-223">The request took too long to complete.</span></span>| 
| <span data-ttu-id="c8eb6-224">500</span><span class="sxs-lookup"><span data-stu-id="c8eb6-224">500</span></span>| <span data-ttu-id="c8eb6-225">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="c8eb6-225">Internal Server Error</span></span> | <span data-ttu-id="c8eb6-226">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-226">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="c8eb6-227">503</span><span class="sxs-lookup"><span data-stu-id="c8eb6-227">503</span></span>| <span data-ttu-id="c8eb6-228">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="c8eb6-228">Service Unavailable</span></span> | <span data-ttu-id="c8eb6-229">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-229">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EYEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="c8eb6-230">応答本文</span><span class="sxs-lookup"><span data-stu-id="c8eb6-230">Response body</span></span> 
 
<span data-ttu-id="c8eb6-231">呼び出しでは、複数のブロック要求が成功した場合は、サービスは、次のブロックを渡す continution トークンを返します。</span><span class="sxs-lookup"><span data-stu-id="c8eb6-231">If the call is a multi-block request and it is successful, the service will return a continution token to pass with the next block.</span></span>
 
<a id="ID4EEFAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="c8eb6-232">応答の例</span><span class="sxs-lookup"><span data-stu-id="c8eb6-232">Sample response</span></span>
 

```cpp
{
    "continuationToken":"abcd1234-1111-2222-3333-abcd12345678-1"
}
         
```

   
<a id="ID4EQFAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c8eb6-233">関連項目</span><span class="sxs-lookup"><span data-stu-id="c8eb6-233">See also</span></span>
 
<a id="ID4ESFAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c8eb6-234">Parent</span><span class="sxs-lookup"><span data-stu-id="c8eb6-234">Parent</span></span>  

[<span data-ttu-id="c8eb6-235">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data {{pathandfilename}, {type}</span><span class="sxs-lookup"><span data-stu-id="c8eb6-235">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.md)

   