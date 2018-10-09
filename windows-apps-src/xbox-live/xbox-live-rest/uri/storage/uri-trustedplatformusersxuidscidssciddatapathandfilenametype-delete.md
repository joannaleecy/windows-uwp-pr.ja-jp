---
title: DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: 0a0355f6-940f-c959-bd5e-63b81872c1da
permalink: en-us/docs/xboxlive/rest/uri-trustedplatformusersxuidscidssciddatapathandfilenametype-delete.html
author: KevinAsgari
description: " DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bf3547689984d21efa442d8b2d346e0a42f1de2e
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4430255"
---
# <a name="delete-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="7ec2e-104">DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="7ec2e-104">DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="7ec2e-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-105">Deletes a file.</span></span> <span data-ttu-id="7ec2e-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7ec2e-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ec2e-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="7ec2e-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ec2e-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="7ec2e-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ec2e-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="7ec2e-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ec2e-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="7ec2e-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="7ec2e-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="7ec2e-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7ec2e-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="7ec2e-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="7ec2e-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7ec2e-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ec2e-114">URI parameters</span></span> 
 
| <span data-ttu-id="7ec2e-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7ec2e-115">Parameter</span></span>| <span data-ttu-id="7ec2e-116">型</span><span class="sxs-lookup"><span data-stu-id="7ec2e-116">Type</span></span>| <span data-ttu-id="7ec2e-117">説明</span><span class="sxs-lookup"><span data-stu-id="7ec2e-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7ec2e-118">xuid</span><span class="sxs-lookup"><span data-stu-id="7ec2e-118">xuid</span></span>| <span data-ttu-id="7ec2e-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="7ec2e-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="7ec2e-120">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="7ec2e-121">scid</span><span class="sxs-lookup"><span data-stu-id="7ec2e-121">scid</span></span>| <span data-ttu-id="7ec2e-122">guid</span><span class="sxs-lookup"><span data-stu-id="7ec2e-122">guid</span></span>| <span data-ttu-id="7ec2e-123">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="7ec2e-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="7ec2e-124">pathAndFileName</span></span>| <span data-ttu-id="7ec2e-125">string</span><span class="sxs-lookup"><span data-stu-id="7ec2e-125">string</span></span>| <span data-ttu-id="7ec2e-126">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="7ec2e-127">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="7ec2e-128">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="7ec2e-129">type</span><span class="sxs-lookup"><span data-stu-id="7ec2e-129">type</span></span>| <span data-ttu-id="7ec2e-130">文字列</span><span class="sxs-lookup"><span data-stu-id="7ec2e-130">string</span></span>| <span data-ttu-id="7ec2e-131">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-131">The format of the data.</span></span> <span data-ttu-id="7ec2e-132">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-132">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="7ec2e-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ec2e-133">Authorization</span></span> 
 
<span data-ttu-id="7ec2e-134">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-134">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="7ec2e-135">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは 403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-135">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="7ec2e-136">ヘッダーが見つからないか無効な場合は、サービスは 401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-136">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="7ec2e-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ec2e-137">Required Request Headers</span></span>
 
| <span data-ttu-id="7ec2e-138">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ec2e-138">Header</span></span>| <span data-ttu-id="7ec2e-139">設定値</span><span class="sxs-lookup"><span data-stu-id="7ec2e-139">Value</span></span>| <span data-ttu-id="7ec2e-140">説明</span><span class="sxs-lookup"><span data-stu-id="7ec2e-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7ec2e-141">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="7ec2e-141">x-xbl-contract-version</span></span>| <span data-ttu-id="7ec2e-142">1</span><span class="sxs-lookup"><span data-stu-id="7ec2e-142">1</span></span>| <span data-ttu-id="7ec2e-143">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-143">API contract version.</span></span>| 
| <span data-ttu-id="7ec2e-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="7ec2e-144">Authorization</span></span>| <span data-ttu-id="7ec2e-145">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="7ec2e-145">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="7ec2e-146">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-146">STS authentication token.</span></span> <span data-ttu-id="7ec2e-147">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-147">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="7ec2e-148">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-148">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="7ec2e-149">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ec2e-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="7ec2e-150">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7ec2e-150">Header</span></span>| <span data-ttu-id="7ec2e-151">説明</span><span class="sxs-lookup"><span data-stu-id="7ec2e-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7ec2e-152">If-Match</span><span class="sxs-lookup"><span data-stu-id="7ec2e-152">If-Match</span></span>| <span data-ttu-id="7ec2e-153">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-153">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="7ec2e-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="7ec2e-154">Request body</span></span> 
 
<span data-ttu-id="7ec2e-155">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-155">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="7ec2e-156">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7ec2e-156">HTTP status codes</span></span> 
 
<span data-ttu-id="7ec2e-157">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-157">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="7ec2e-158">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-158">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="7ec2e-159">コード</span><span class="sxs-lookup"><span data-stu-id="7ec2e-159">Code</span></span>| <span data-ttu-id="7ec2e-160">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="7ec2e-160">Reason phrase</span></span>| <span data-ttu-id="7ec2e-161">説明</span><span class="sxs-lookup"><span data-stu-id="7ec2e-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7ec2e-162">200</span><span class="sxs-lookup"><span data-stu-id="7ec2e-162">200</span></span>| <span data-ttu-id="7ec2e-163">OK</span><span class="sxs-lookup"><span data-stu-id="7ec2e-163">OK</span></span> | <span data-ttu-id="7ec2e-164">ファイルは正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-164">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="7ec2e-165">201</span><span class="sxs-lookup"><span data-stu-id="7ec2e-165">201</span></span>| <span data-ttu-id="7ec2e-166">Created</span><span class="sxs-lookup"><span data-stu-id="7ec2e-166">Created</span></span> | <span data-ttu-id="7ec2e-167">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-167">The entity was created.</span></span>| 
| <span data-ttu-id="7ec2e-168">400</span><span class="sxs-lookup"><span data-stu-id="7ec2e-168">400</span></span>| <span data-ttu-id="7ec2e-169">Bad Request</span><span class="sxs-lookup"><span data-stu-id="7ec2e-169">Bad Request</span></span> | <span data-ttu-id="7ec2e-170">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-170">Service could not understand malformed request.</span></span> <span data-ttu-id="7ec2e-171">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="7ec2e-172">401</span><span class="sxs-lookup"><span data-stu-id="7ec2e-172">401</span></span>| <span data-ttu-id="7ec2e-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="7ec2e-173">Unauthorized</span></span> | <span data-ttu-id="7ec2e-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="7ec2e-175">403</span><span class="sxs-lookup"><span data-stu-id="7ec2e-175">403</span></span>| <span data-ttu-id="7ec2e-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="7ec2e-176">Forbidden</span></span> | <span data-ttu-id="7ec2e-177">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-177">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="7ec2e-178">404</span><span class="sxs-lookup"><span data-stu-id="7ec2e-178">404</span></span>| <span data-ttu-id="7ec2e-179">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-179">Not Found</span></span> | <span data-ttu-id="7ec2e-180">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-180">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="7ec2e-181">406</span><span class="sxs-lookup"><span data-stu-id="7ec2e-181">406</span></span>| <span data-ttu-id="7ec2e-182">許容できません。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-182">Not Acceptable</span></span> | <span data-ttu-id="7ec2e-183">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-183">Resource version is not supported.</span></span>| 
| <span data-ttu-id="7ec2e-184">408</span><span class="sxs-lookup"><span data-stu-id="7ec2e-184">408</span></span>| <span data-ttu-id="7ec2e-185">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="7ec2e-185">Request Timeout</span></span> | <span data-ttu-id="7ec2e-186">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-186">The request took too long to complete.</span></span>| 
| <span data-ttu-id="7ec2e-187">500</span><span class="sxs-lookup"><span data-stu-id="7ec2e-187">500</span></span>| <span data-ttu-id="7ec2e-188">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="7ec2e-188">Internal Server Error</span></span> | <span data-ttu-id="7ec2e-189">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-189">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="7ec2e-190">503</span><span class="sxs-lookup"><span data-stu-id="7ec2e-190">503</span></span>| <span data-ttu-id="7ec2e-191">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="7ec2e-191">Service Unavailable</span></span> | <span data-ttu-id="7ec2e-192">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-192">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="7ec2e-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="7ec2e-193">Response body</span></span> 
 
<span data-ttu-id="7ec2e-194">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="7ec2e-194">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="7ec2e-195">関連項目</span><span class="sxs-lookup"><span data-stu-id="7ec2e-195">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7ec2e-196">Parent</span><span class="sxs-lookup"><span data-stu-id="7ec2e-196">Parent</span></span>  

[<span data-ttu-id="7ec2e-197">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="7ec2e-197">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

   