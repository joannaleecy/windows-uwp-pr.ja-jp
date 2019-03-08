---
title: DELETE (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})
assetID: f390cc37-6a30-962c-ccd5-e1528a91d30b
permalink: en-us/docs/xboxlive/rest/uri-untrustedplatformusersxuidscidssciddatapathandfilenametype-delete.html
description: " DELETE (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4af180d758d14a2726046a6221889acc33efc897
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57657657"
---
# <a name="delete-untrustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="e409b-104">DELETE (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="e409b-104">DELETE (/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="e409b-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="e409b-105">Deletes a file.</span></span> <span data-ttu-id="e409b-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e409b-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e409b-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e409b-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="e409b-108">承認</span><span class="sxs-lookup"><span data-stu-id="e409b-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="e409b-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e409b-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="e409b-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e409b-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="e409b-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="e409b-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="e409b-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e409b-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="e409b-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="e409b-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e409b-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e409b-114">URI parameters</span></span> 
 
| <span data-ttu-id="e409b-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e409b-115">Parameter</span></span>| <span data-ttu-id="e409b-116">種類</span><span class="sxs-lookup"><span data-stu-id="e409b-116">Type</span></span>| <span data-ttu-id="e409b-117">説明</span><span class="sxs-lookup"><span data-stu-id="e409b-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e409b-118">xuid</span><span class="sxs-lookup"><span data-stu-id="e409b-118">xuid</span></span>| <span data-ttu-id="e409b-119">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e409b-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="e409b-120">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="e409b-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="e409b-121">scid</span><span class="sxs-lookup"><span data-stu-id="e409b-121">scid</span></span>| <span data-ttu-id="e409b-122">guid</span><span class="sxs-lookup"><span data-stu-id="e409b-122">guid</span></span>| <span data-ttu-id="e409b-123">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="e409b-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="e409b-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="e409b-124">pathAndFileName</span></span>| <span data-ttu-id="e409b-125">string</span><span class="sxs-lookup"><span data-stu-id="e409b-125">string</span></span>| <span data-ttu-id="e409b-126">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="e409b-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="e409b-127">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="e409b-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="e409b-128">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="e409b-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="e409b-129">type</span><span class="sxs-lookup"><span data-stu-id="e409b-129">type</span></span>| <span data-ttu-id="e409b-130">string</span><span class="sxs-lookup"><span data-stu-id="e409b-130">string</span></span>| <span data-ttu-id="e409b-131">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="e409b-131">The format of the data.</span></span> <span data-ttu-id="e409b-132">有効値とは、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="e409b-132">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="e409b-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="e409b-133">Authorization</span></span> 
 
<span data-ttu-id="e409b-134">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e409b-134">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="e409b-135">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="e409b-135">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="e409b-136">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="e409b-136">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span>
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e409b-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e409b-137">Required Request Headers</span></span>
 
| <span data-ttu-id="e409b-138">Header</span><span class="sxs-lookup"><span data-stu-id="e409b-138">Header</span></span>| <span data-ttu-id="e409b-139">Value</span><span class="sxs-lookup"><span data-stu-id="e409b-139">Value</span></span>| <span data-ttu-id="e409b-140">説明</span><span class="sxs-lookup"><span data-stu-id="e409b-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e409b-141">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="e409b-141">x-xbl-contract-version</span></span>| <span data-ttu-id="e409b-142">1</span><span class="sxs-lookup"><span data-stu-id="e409b-142">1</span></span>| <span data-ttu-id="e409b-143">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="e409b-143">API contract version.</span></span>| 
| <span data-ttu-id="e409b-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="e409b-144">Authorization</span></span>| <span data-ttu-id="e409b-145">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="e409b-145">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="e409b-146">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="e409b-146">STS authentication token.</span></span> <span data-ttu-id="e409b-147">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="e409b-147">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="e409b-148">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e409b-148">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="e409b-149">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e409b-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="e409b-150">Header</span><span class="sxs-lookup"><span data-stu-id="e409b-150">Header</span></span>| <span data-ttu-id="e409b-151">説明</span><span class="sxs-lookup"><span data-stu-id="e409b-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e409b-152">If-Match</span><span class="sxs-lookup"><span data-stu-id="e409b-152">If-Match</span></span>| <span data-ttu-id="e409b-153">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="e409b-153">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="e409b-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="e409b-154">Request body</span></span> 
 
<span data-ttu-id="e409b-155">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e409b-155">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="e409b-156">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e409b-156">HTTP status codes</span></span> 
 
<span data-ttu-id="e409b-157">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e409b-157">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e409b-158">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="e409b-158">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="e409b-159">コード</span><span class="sxs-lookup"><span data-stu-id="e409b-159">Code</span></span>| <span data-ttu-id="e409b-160">理由語句</span><span class="sxs-lookup"><span data-stu-id="e409b-160">Reason phrase</span></span>| <span data-ttu-id="e409b-161">説明</span><span class="sxs-lookup"><span data-stu-id="e409b-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e409b-162">200</span><span class="sxs-lookup"><span data-stu-id="e409b-162">200</span></span>| <span data-ttu-id="e409b-163">OK</span><span class="sxs-lookup"><span data-stu-id="e409b-163">OK</span></span> | <span data-ttu-id="e409b-164">ファイルは、正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="e409b-164">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="e409b-165">201</span><span class="sxs-lookup"><span data-stu-id="e409b-165">201</span></span>| <span data-ttu-id="e409b-166">作成日</span><span class="sxs-lookup"><span data-stu-id="e409b-166">Created</span></span> | <span data-ttu-id="e409b-167">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="e409b-167">The entity was created.</span></span>| 
| <span data-ttu-id="e409b-168">400</span><span class="sxs-lookup"><span data-stu-id="e409b-168">400</span></span>| <span data-ttu-id="e409b-169">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="e409b-169">Bad Request</span></span> | <span data-ttu-id="e409b-170">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="e409b-170">Service could not understand malformed request.</span></span> <span data-ttu-id="e409b-171">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="e409b-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="e409b-172">401</span><span class="sxs-lookup"><span data-stu-id="e409b-172">401</span></span>| <span data-ttu-id="e409b-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="e409b-173">Unauthorized</span></span> | <span data-ttu-id="e409b-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="e409b-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="e409b-175">403</span><span class="sxs-lookup"><span data-stu-id="e409b-175">403</span></span>| <span data-ttu-id="e409b-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e409b-176">Forbidden</span></span> | <span data-ttu-id="e409b-177">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="e409b-177">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="e409b-178">404</span><span class="sxs-lookup"><span data-stu-id="e409b-178">404</span></span>| <span data-ttu-id="e409b-179">検出不可</span><span class="sxs-lookup"><span data-stu-id="e409b-179">Not Found</span></span> | <span data-ttu-id="e409b-180">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="e409b-180">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="e409b-181">406</span><span class="sxs-lookup"><span data-stu-id="e409b-181">406</span></span>| <span data-ttu-id="e409b-182">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="e409b-182">Not Acceptable</span></span> | <span data-ttu-id="e409b-183">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e409b-183">Resource version is not supported.</span></span>| 
| <span data-ttu-id="e409b-184">408</span><span class="sxs-lookup"><span data-stu-id="e409b-184">408</span></span>| <span data-ttu-id="e409b-185">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="e409b-185">Request Timeout</span></span> | <span data-ttu-id="e409b-186">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="e409b-186">The request took too long to complete.</span></span>| 
| <span data-ttu-id="e409b-187">500</span><span class="sxs-lookup"><span data-stu-id="e409b-187">500</span></span>| <span data-ttu-id="e409b-188">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="e409b-188">Internal Server Error</span></span> | <span data-ttu-id="e409b-189">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="e409b-189">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="e409b-190">503</span><span class="sxs-lookup"><span data-stu-id="e409b-190">503</span></span>| <span data-ttu-id="e409b-191">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="e409b-191">Service Unavailable</span></span> | <span data-ttu-id="e409b-192">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="e409b-192">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="e409b-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="e409b-193">Response body</span></span> 
 
<span data-ttu-id="e409b-194">応答の本文では、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e409b-194">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e409b-195">関連項目</span><span class="sxs-lookup"><span data-stu-id="e409b-195">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e409b-196">Parent</span><span class="sxs-lookup"><span data-stu-id="e409b-196">Parent</span></span>  

[<span data-ttu-id="e409b-197">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="e409b-197">/untrustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-untrustedplatformusersxuidscidssciddatapathandfilenametype.md)

   