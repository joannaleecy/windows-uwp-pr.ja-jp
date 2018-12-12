---
title: DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})
assetID: b4ddc3d2-890d-f677-0109-45d318c3128d
permalink: en-us/docs/xboxlive/rest/uri-sessionssessionidscidssciddatapathandfilenametype-delete.html
description: " DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8864892392e1cfddba7f510fc0f9e7efdb2dd036
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8940077"
---
# <a name="delete-sessionssessionidscidssciddatapathandfilenametype"></a><span data-ttu-id="0d214-104">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="0d214-104">DELETE (/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="0d214-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="0d214-105">Deletes a file.</span></span> <span data-ttu-id="0d214-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="0d214-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="0d214-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0d214-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="0d214-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="0d214-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="0d214-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d214-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="0d214-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d214-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="0d214-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="0d214-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="0d214-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0d214-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="0d214-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="0d214-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="0d214-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="0d214-114">URI parameters</span></span> 
 
| <span data-ttu-id="0d214-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="0d214-115">Parameter</span></span>| <span data-ttu-id="0d214-116">型</span><span class="sxs-lookup"><span data-stu-id="0d214-116">Type</span></span>| <span data-ttu-id="0d214-117">説明</span><span class="sxs-lookup"><span data-stu-id="0d214-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0d214-118">sessionId</span><span class="sxs-lookup"><span data-stu-id="0d214-118">sessionId</span></span>| <span data-ttu-id="0d214-119">string</span><span class="sxs-lookup"><span data-stu-id="0d214-119">string</span></span>| <span data-ttu-id="0d214-120">検索するセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="0d214-120">the ID of the session to look up.</span></span>| 
| <span data-ttu-id="0d214-121">scid</span><span class="sxs-lookup"><span data-stu-id="0d214-121">scid</span></span>| <span data-ttu-id="0d214-122">guid</span><span class="sxs-lookup"><span data-stu-id="0d214-122">guid</span></span>| <span data-ttu-id="0d214-123">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="0d214-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="0d214-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="0d214-124">pathAndFileName</span></span>| <span data-ttu-id="0d214-125">string</span><span class="sxs-lookup"><span data-stu-id="0d214-125">string</span></span>| <span data-ttu-id="0d214-126">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="0d214-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="0d214-127">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="0d214-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="0d214-128">ファイル名を空にすることがありますはいない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="0d214-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="0d214-129">type</span><span class="sxs-lookup"><span data-stu-id="0d214-129">type</span></span>| <span data-ttu-id="0d214-130">文字列</span><span class="sxs-lookup"><span data-stu-id="0d214-130">string</span></span>| <span data-ttu-id="0d214-131">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="0d214-131">The format of the data.</span></span> <span data-ttu-id="0d214-132">使用可能な値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="0d214-132">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="0d214-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="0d214-133">Authorization</span></span> 
 
<span data-ttu-id="0d214-134">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="0d214-134">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="0d214-135">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="0d214-135">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="0d214-136">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="0d214-136">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="0d214-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d214-137">Required Request Headers</span></span>
 
| <span data-ttu-id="0d214-138">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d214-138">Header</span></span>| <span data-ttu-id="0d214-139">設定値</span><span class="sxs-lookup"><span data-stu-id="0d214-139">Value</span></span>| <span data-ttu-id="0d214-140">説明</span><span class="sxs-lookup"><span data-stu-id="0d214-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d214-141">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="0d214-141">x-xbl-contract-version</span></span>| <span data-ttu-id="0d214-142">1</span><span class="sxs-lookup"><span data-stu-id="0d214-142">1</span></span>| <span data-ttu-id="0d214-143">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="0d214-143">API contract version.</span></span>| 
| <span data-ttu-id="0d214-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="0d214-144">Authorization</span></span>| <span data-ttu-id="0d214-145">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="0d214-145">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="0d214-146">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="0d214-146">STS authentication token.</span></span> <span data-ttu-id="0d214-147">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="0d214-147">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="0d214-148">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0d214-148">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="0d214-149">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d214-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="0d214-150">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="0d214-150">Header</span></span>| <span data-ttu-id="0d214-151">説明</span><span class="sxs-lookup"><span data-stu-id="0d214-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d214-152">If-Match</span><span class="sxs-lookup"><span data-stu-id="0d214-152">If-Match</span></span>| <span data-ttu-id="0d214-153">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="0d214-153">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="0d214-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="0d214-154">Request body</span></span> 
 
<span data-ttu-id="0d214-155">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0d214-155">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="0d214-156">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="0d214-156">HTTP status codes</span></span> 
 
<span data-ttu-id="0d214-157">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="0d214-157">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="0d214-158">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="0d214-158">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="0d214-159">コード</span><span class="sxs-lookup"><span data-stu-id="0d214-159">Code</span></span>| <span data-ttu-id="0d214-160">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="0d214-160">Reason phrase</span></span>| <span data-ttu-id="0d214-161">説明</span><span class="sxs-lookup"><span data-stu-id="0d214-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="0d214-162">200</span><span class="sxs-lookup"><span data-stu-id="0d214-162">200</span></span>| <span data-ttu-id="0d214-163">OK</span><span class="sxs-lookup"><span data-stu-id="0d214-163">OK</span></span> | <span data-ttu-id="0d214-164">ファイルは正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="0d214-164">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="0d214-165">201</span><span class="sxs-lookup"><span data-stu-id="0d214-165">201</span></span>| <span data-ttu-id="0d214-166">Created</span><span class="sxs-lookup"><span data-stu-id="0d214-166">Created</span></span> | <span data-ttu-id="0d214-167">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="0d214-167">The entity was created.</span></span>| 
| <span data-ttu-id="0d214-168">400</span><span class="sxs-lookup"><span data-stu-id="0d214-168">400</span></span>| <span data-ttu-id="0d214-169">Bad Request</span><span class="sxs-lookup"><span data-stu-id="0d214-169">Bad Request</span></span> | <span data-ttu-id="0d214-170">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="0d214-170">Service could not understand malformed request.</span></span> <span data-ttu-id="0d214-171">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="0d214-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="0d214-172">401</span><span class="sxs-lookup"><span data-stu-id="0d214-172">401</span></span>| <span data-ttu-id="0d214-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="0d214-173">Unauthorized</span></span> | <span data-ttu-id="0d214-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="0d214-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="0d214-175">403</span><span class="sxs-lookup"><span data-stu-id="0d214-175">403</span></span>| <span data-ttu-id="0d214-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="0d214-176">Forbidden</span></span> | <span data-ttu-id="0d214-177">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="0d214-177">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="0d214-178">404</span><span class="sxs-lookup"><span data-stu-id="0d214-178">404</span></span>| <span data-ttu-id="0d214-179">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="0d214-179">Not Found</span></span> | <span data-ttu-id="0d214-180">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="0d214-180">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="0d214-181">406</span><span class="sxs-lookup"><span data-stu-id="0d214-181">406</span></span>| <span data-ttu-id="0d214-182">許容できません。</span><span class="sxs-lookup"><span data-stu-id="0d214-182">Not Acceptable</span></span> | <span data-ttu-id="0d214-183">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="0d214-183">Resource version is not supported.</span></span>| 
| <span data-ttu-id="0d214-184">408</span><span class="sxs-lookup"><span data-stu-id="0d214-184">408</span></span>| <span data-ttu-id="0d214-185">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="0d214-185">Request Timeout</span></span> | <span data-ttu-id="0d214-186">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="0d214-186">The request took too long to complete.</span></span>| 
| <span data-ttu-id="0d214-187">500</span><span class="sxs-lookup"><span data-stu-id="0d214-187">500</span></span>| <span data-ttu-id="0d214-188">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="0d214-188">Internal Server Error</span></span> | <span data-ttu-id="0d214-189">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="0d214-189">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="0d214-190">503</span><span class="sxs-lookup"><span data-stu-id="0d214-190">503</span></span>| <span data-ttu-id="0d214-191">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="0d214-191">Service Unavailable</span></span> | <span data-ttu-id="0d214-192">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="0d214-192">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="0d214-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="0d214-193">Response body</span></span> 
 
<span data-ttu-id="0d214-194">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="0d214-194">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="0d214-195">関連項目</span><span class="sxs-lookup"><span data-stu-id="0d214-195">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0d214-196">Parent</span><span class="sxs-lookup"><span data-stu-id="0d214-196">Parent</span></span>  

[<span data-ttu-id="0d214-197">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="0d214-197">/sessions/{sessionId}/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-sessionssessionidscidssciddatapathandfilenametype.md)

   