---
title: DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
assetID: b4ddc3d2-890d-f677-0109-45d318c3128d
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype-delete.html
author: KevinAsgari
description: " DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e4fbce69fe23b3b69c2b6cefa69b47aa4662cfb0
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7148880"
---
# <a name="delete-sessionssessionidscidssciddatapathandfilenametype"></a><span data-ttu-id="0a428-104">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="0a428-104">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="0a428-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="0a428-105">Deletes a file.</span></span> <span data-ttu-id="0a428-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0a428-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0a428-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a428-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="0a428-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="0a428-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="0a428-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a428-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="0a428-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a428-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="0a428-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="0a428-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="0a428-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0a428-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="0a428-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="0a428-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0a428-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a428-114">URI parameters</span></span> 
 
| <span data-ttu-id="0a428-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0a428-115">Parameter</span></span>| <span data-ttu-id="0a428-116">型</span><span class="sxs-lookup"><span data-stu-id="0a428-116">Type</span></span>| <span data-ttu-id="0a428-117">説明</span><span class="sxs-lookup"><span data-stu-id="0a428-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0a428-118">sessionId</span><span class="sxs-lookup"><span data-stu-id="0a428-118">sessionId</span></span>| <span data-ttu-id="0a428-119">string</span><span class="sxs-lookup"><span data-stu-id="0a428-119">string</span></span>| <span data-ttu-id="0a428-120">検索するセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="0a428-120">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="0a428-121">scid</span><span class="sxs-lookup"><span data-stu-id="0a428-121">scid</span></span>| <span data-ttu-id="0a428-122">guid</span><span class="sxs-lookup"><span data-stu-id="0a428-122">guid</span></span>| <span data-ttu-id="0a428-123">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="0a428-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="0a428-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="0a428-124">pathAndFileName</span></span>| <span data-ttu-id="0a428-125">string</span><span class="sxs-lookup"><span data-stu-id="0a428-125">string</span></span>| <span data-ttu-id="0a428-126">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="0a428-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="0a428-127">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="0a428-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="0a428-128">ファイル名可能性がありますいない空にすること、期間の終了または 2 つの連続するピリオドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0a428-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="0a428-129">type</span><span class="sxs-lookup"><span data-stu-id="0a428-129">type</span></span>| <span data-ttu-id="0a428-130">文字列</span><span class="sxs-lookup"><span data-stu-id="0a428-130">string</span></span>| <span data-ttu-id="0a428-131">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="0a428-131">The format of the data.</span></span> <span data-ttu-id="0a428-132">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="0a428-132">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="0a428-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="0a428-133">Authorization</span></span> 
 
<span data-ttu-id="0a428-134">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0a428-134">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="0a428-135">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="0a428-135">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="0a428-136">ヘッダーが見つからないか無効な場合は、サービスは、401 不正な応答を返します。</span><span class="sxs-lookup"><span data-stu-id="0a428-136">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0a428-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a428-137">Required Request Headers</span></span>
 
| <span data-ttu-id="0a428-138">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a428-138">Header</span></span>| <span data-ttu-id="0a428-139">設定値</span><span class="sxs-lookup"><span data-stu-id="0a428-139">Value</span></span>| <span data-ttu-id="0a428-140">説明</span><span class="sxs-lookup"><span data-stu-id="0a428-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0a428-141">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="0a428-141">x-xbl-contract-version</span></span>| <span data-ttu-id="0a428-142">1</span><span class="sxs-lookup"><span data-stu-id="0a428-142">1</span></span>| <span data-ttu-id="0a428-143">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="0a428-143">API contract version.</span></span>| 
| <span data-ttu-id="0a428-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="0a428-144">Authorization</span></span>| <span data-ttu-id="0a428-145">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="0a428-145">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="0a428-146">STS 認証トークン。</span><span class="sxs-lookup"><span data-stu-id="0a428-146">STS authentication token.</span></span> <span data-ttu-id="0a428-147">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="0a428-147">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="0a428-148">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0a428-148">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="0a428-149">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a428-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="0a428-150">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0a428-150">Header</span></span>| <span data-ttu-id="0a428-151">説明</span><span class="sxs-lookup"><span data-stu-id="0a428-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0a428-152">If-Match</span><span class="sxs-lookup"><span data-stu-id="0a428-152">If-Match</span></span>| <span data-ttu-id="0a428-153">操作を完了するにより既存項目と一致する ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="0a428-153">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="0a428-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="0a428-154">Request body</span></span> 
 
<span data-ttu-id="0a428-155">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0a428-155">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="0a428-156">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0a428-156">HTTP status codes</span></span> 
 
<span data-ttu-id="0a428-157">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="0a428-157">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="0a428-158">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0a428-158">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="0a428-159">コード</span><span class="sxs-lookup"><span data-stu-id="0a428-159">Code</span></span>| <span data-ttu-id="0a428-160">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="0a428-160">Reason phrase</span></span>| <span data-ttu-id="0a428-161">説明</span><span class="sxs-lookup"><span data-stu-id="0a428-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0a428-162">200</span><span class="sxs-lookup"><span data-stu-id="0a428-162">200</span></span>| <span data-ttu-id="0a428-163">OK</span><span class="sxs-lookup"><span data-stu-id="0a428-163">OK</span></span> | <span data-ttu-id="0a428-164">ファイルは正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="0a428-164">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="0a428-165">201</span><span class="sxs-lookup"><span data-stu-id="0a428-165">201</span></span>| <span data-ttu-id="0a428-166">Created</span><span class="sxs-lookup"><span data-stu-id="0a428-166">Created</span></span> | <span data-ttu-id="0a428-167">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="0a428-167">The entity was created.</span></span>| 
| <span data-ttu-id="0a428-168">400</span><span class="sxs-lookup"><span data-stu-id="0a428-168">400</span></span>| <span data-ttu-id="0a428-169">Bad Request</span><span class="sxs-lookup"><span data-stu-id="0a428-169">Bad Request</span></span> | <span data-ttu-id="0a428-170">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0a428-170">Service could not understand malformed request.</span></span> <span data-ttu-id="0a428-171">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="0a428-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="0a428-172">401</span><span class="sxs-lookup"><span data-stu-id="0a428-172">401</span></span>| <span data-ttu-id="0a428-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="0a428-173">Unauthorized</span></span> | <span data-ttu-id="0a428-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="0a428-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="0a428-175">403</span><span class="sxs-lookup"><span data-stu-id="0a428-175">403</span></span>| <span data-ttu-id="0a428-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="0a428-176">Forbidden</span></span> | <span data-ttu-id="0a428-177">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="0a428-177">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="0a428-178">404</span><span class="sxs-lookup"><span data-stu-id="0a428-178">404</span></span>| <span data-ttu-id="0a428-179">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="0a428-179">Not Found</span></span> | <span data-ttu-id="0a428-180">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="0a428-180">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="0a428-181">406</span><span class="sxs-lookup"><span data-stu-id="0a428-181">406</span></span>| <span data-ttu-id="0a428-182">許容できません。</span><span class="sxs-lookup"><span data-stu-id="0a428-182">Not Acceptable</span></span> | <span data-ttu-id="0a428-183">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0a428-183">Resource version is not supported.</span></span>| 
| <span data-ttu-id="0a428-184">408</span><span class="sxs-lookup"><span data-stu-id="0a428-184">408</span></span>| <span data-ttu-id="0a428-185">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="0a428-185">Request Timeout</span></span> | <span data-ttu-id="0a428-186">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="0a428-186">The request took too long to complete.</span></span>| 
| <span data-ttu-id="0a428-187">500</span><span class="sxs-lookup"><span data-stu-id="0a428-187">500</span></span>| <span data-ttu-id="0a428-188">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="0a428-188">Internal Server Error</span></span> | <span data-ttu-id="0a428-189">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="0a428-189">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="0a428-190">503</span><span class="sxs-lookup"><span data-stu-id="0a428-190">503</span></span>| <span data-ttu-id="0a428-191">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="0a428-191">Service Unavailable</span></span> | <span data-ttu-id="0a428-192">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="0a428-192">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="0a428-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="0a428-193">Response body</span></span> 
 
<span data-ttu-id="0a428-194">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0a428-194">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="0a428-195">関連項目</span><span class="sxs-lookup"><span data-stu-id="0a428-195">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0a428-196">Parent</span><span class="sxs-lookup"><span data-stu-id="0a428-196">Parent</span></span>  

[<span data-ttu-id="0a428-197">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0a428-197">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype.md)

   