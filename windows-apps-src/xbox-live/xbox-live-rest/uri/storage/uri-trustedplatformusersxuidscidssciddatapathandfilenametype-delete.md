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
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4681197"
---
# <a name="delete-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="89c8a-104">DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="89c8a-104">DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="89c8a-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="89c8a-105">Deletes a file.</span></span> <span data-ttu-id="89c8a-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="89c8a-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="89c8a-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="89c8a-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="89c8a-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="89c8a-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="89c8a-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="89c8a-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="89c8a-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="89c8a-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="89c8a-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="89c8a-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="89c8a-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="89c8a-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="89c8a-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="89c8a-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="89c8a-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="89c8a-114">URI parameters</span></span> 
 
| <span data-ttu-id="89c8a-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="89c8a-115">Parameter</span></span>| <span data-ttu-id="89c8a-116">型</span><span class="sxs-lookup"><span data-stu-id="89c8a-116">Type</span></span>| <span data-ttu-id="89c8a-117">説明</span><span class="sxs-lookup"><span data-stu-id="89c8a-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="89c8a-118">xuid</span><span class="sxs-lookup"><span data-stu-id="89c8a-118">xuid</span></span>| <span data-ttu-id="89c8a-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="89c8a-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="89c8a-120">Xbox ユーザー ID を (XUID)、プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="89c8a-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="89c8a-121">scid</span><span class="sxs-lookup"><span data-stu-id="89c8a-121">scid</span></span>| <span data-ttu-id="89c8a-122">guid</span><span class="sxs-lookup"><span data-stu-id="89c8a-122">guid</span></span>| <span data-ttu-id="89c8a-123">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="89c8a-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="89c8a-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="89c8a-124">pathAndFileName</span></span>| <span data-ttu-id="89c8a-125">string</span><span class="sxs-lookup"><span data-stu-id="89c8a-125">string</span></span>| <span data-ttu-id="89c8a-126">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="89c8a-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="89c8a-127">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="89c8a-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="89c8a-128">ファイル名を空にする可能性がありますはいない期間の終了または 2 つの連続したピリオドは。</span><span class="sxs-lookup"><span data-stu-id="89c8a-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="89c8a-129">type</span><span class="sxs-lookup"><span data-stu-id="89c8a-129">type</span></span>| <span data-ttu-id="89c8a-130">文字列</span><span class="sxs-lookup"><span data-stu-id="89c8a-130">string</span></span>| <span data-ttu-id="89c8a-131">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="89c8a-131">The format of the data.</span></span> <span data-ttu-id="89c8a-132">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="89c8a-132">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="89c8a-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="89c8a-133">Authorization</span></span> 
 
<span data-ttu-id="89c8a-134">要求は、有効な Xbox LIVE の承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="89c8a-134">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="89c8a-135">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="89c8a-135">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="89c8a-136">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="89c8a-136">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="89c8a-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="89c8a-137">Required Request Headers</span></span>
 
| <span data-ttu-id="89c8a-138">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="89c8a-138">Header</span></span>| <span data-ttu-id="89c8a-139">設定値</span><span class="sxs-lookup"><span data-stu-id="89c8a-139">Value</span></span>| <span data-ttu-id="89c8a-140">説明</span><span class="sxs-lookup"><span data-stu-id="89c8a-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="89c8a-141">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="89c8a-141">x-xbl-contract-version</span></span>| <span data-ttu-id="89c8a-142">1</span><span class="sxs-lookup"><span data-stu-id="89c8a-142">1</span></span>| <span data-ttu-id="89c8a-143">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="89c8a-143">API contract version.</span></span>| 
| <span data-ttu-id="89c8a-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="89c8a-144">Authorization</span></span>| <span data-ttu-id="89c8a-145">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="89c8a-145">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="89c8a-146">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="89c8a-146">STS authentication token.</span></span> <span data-ttu-id="89c8a-147">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="89c8a-147">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="89c8a-148">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="89c8a-148">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="89c8a-149">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="89c8a-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="89c8a-150">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="89c8a-150">Header</span></span>| <span data-ttu-id="89c8a-151">説明</span><span class="sxs-lookup"><span data-stu-id="89c8a-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="89c8a-152">If-Match</span><span class="sxs-lookup"><span data-stu-id="89c8a-152">If-Match</span></span>| <span data-ttu-id="89c8a-153">操作を完了するにより既存項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="89c8a-153">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="89c8a-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="89c8a-154">Request body</span></span> 
 
<span data-ttu-id="89c8a-155">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="89c8a-155">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="89c8a-156">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="89c8a-156">HTTP status codes</span></span> 
 
<span data-ttu-id="89c8a-157">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="89c8a-157">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="89c8a-158">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="89c8a-158">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="89c8a-159">コード</span><span class="sxs-lookup"><span data-stu-id="89c8a-159">Code</span></span>| <span data-ttu-id="89c8a-160">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="89c8a-160">Reason phrase</span></span>| <span data-ttu-id="89c8a-161">説明</span><span class="sxs-lookup"><span data-stu-id="89c8a-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="89c8a-162">200</span><span class="sxs-lookup"><span data-stu-id="89c8a-162">200</span></span>| <span data-ttu-id="89c8a-163">OK</span><span class="sxs-lookup"><span data-stu-id="89c8a-163">OK</span></span> | <span data-ttu-id="89c8a-164">ファイルは正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="89c8a-164">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="89c8a-165">201</span><span class="sxs-lookup"><span data-stu-id="89c8a-165">201</span></span>| <span data-ttu-id="89c8a-166">Created</span><span class="sxs-lookup"><span data-stu-id="89c8a-166">Created</span></span> | <span data-ttu-id="89c8a-167">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="89c8a-167">The entity was created.</span></span>| 
| <span data-ttu-id="89c8a-168">400</span><span class="sxs-lookup"><span data-stu-id="89c8a-168">400</span></span>| <span data-ttu-id="89c8a-169">Bad Request</span><span class="sxs-lookup"><span data-stu-id="89c8a-169">Bad Request</span></span> | <span data-ttu-id="89c8a-170">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="89c8a-170">Service could not understand malformed request.</span></span> <span data-ttu-id="89c8a-171">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="89c8a-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="89c8a-172">401</span><span class="sxs-lookup"><span data-stu-id="89c8a-172">401</span></span>| <span data-ttu-id="89c8a-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="89c8a-173">Unauthorized</span></span> | <span data-ttu-id="89c8a-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="89c8a-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="89c8a-175">403</span><span class="sxs-lookup"><span data-stu-id="89c8a-175">403</span></span>| <span data-ttu-id="89c8a-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="89c8a-176">Forbidden</span></span> | <span data-ttu-id="89c8a-177">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="89c8a-177">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="89c8a-178">404</span><span class="sxs-lookup"><span data-stu-id="89c8a-178">404</span></span>| <span data-ttu-id="89c8a-179">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="89c8a-179">Not Found</span></span> | <span data-ttu-id="89c8a-180">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="89c8a-180">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="89c8a-181">406</span><span class="sxs-lookup"><span data-stu-id="89c8a-181">406</span></span>| <span data-ttu-id="89c8a-182">許容できません。</span><span class="sxs-lookup"><span data-stu-id="89c8a-182">Not Acceptable</span></span> | <span data-ttu-id="89c8a-183">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="89c8a-183">Resource version is not supported.</span></span>| 
| <span data-ttu-id="89c8a-184">408</span><span class="sxs-lookup"><span data-stu-id="89c8a-184">408</span></span>| <span data-ttu-id="89c8a-185">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="89c8a-185">Request Timeout</span></span> | <span data-ttu-id="89c8a-186">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="89c8a-186">The request took too long to complete.</span></span>| 
| <span data-ttu-id="89c8a-187">500</span><span class="sxs-lookup"><span data-stu-id="89c8a-187">500</span></span>| <span data-ttu-id="89c8a-188">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="89c8a-188">Internal Server Error</span></span> | <span data-ttu-id="89c8a-189">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="89c8a-189">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="89c8a-190">503</span><span class="sxs-lookup"><span data-stu-id="89c8a-190">503</span></span>| <span data-ttu-id="89c8a-191">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="89c8a-191">Service Unavailable</span></span> | <span data-ttu-id="89c8a-192">要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="89c8a-192">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="89c8a-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="89c8a-193">Response body</span></span> 
 
<span data-ttu-id="89c8a-194">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="89c8a-194">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="89c8a-195">関連項目</span><span class="sxs-lookup"><span data-stu-id="89c8a-195">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="89c8a-196">Parent</span><span class="sxs-lookup"><span data-stu-id="89c8a-196">Parent</span></span>  

[<span data-ttu-id="89c8a-197">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="89c8a-197">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

   