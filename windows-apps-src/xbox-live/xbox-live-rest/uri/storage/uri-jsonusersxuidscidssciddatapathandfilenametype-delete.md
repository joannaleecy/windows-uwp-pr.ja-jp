---
title: DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)
assetID: b8d862d1-1651-b6c2-cc25-c5398128e882
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype-delete.html
description: " DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 40089ce5b719d74aed5274e42ace01e79adad61c
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662277"
---
# <a name="delete-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="855b3-104">DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="855b3-104">DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="855b3-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="855b3-105">Deletes a file.</span></span> <span data-ttu-id="855b3-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="855b3-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="855b3-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="855b3-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="855b3-108">承認</span><span class="sxs-lookup"><span data-stu-id="855b3-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="855b3-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="855b3-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="855b3-110">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="855b3-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="855b3-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="855b3-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="855b3-112">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="855b3-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="855b3-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="855b3-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="855b3-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="855b3-114">URI parameters</span></span> 
 
| <span data-ttu-id="855b3-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="855b3-115">Parameter</span></span>| <span data-ttu-id="855b3-116">種類</span><span class="sxs-lookup"><span data-stu-id="855b3-116">Type</span></span>| <span data-ttu-id="855b3-117">説明</span><span class="sxs-lookup"><span data-stu-id="855b3-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="855b3-118">xuid</span><span class="sxs-lookup"><span data-stu-id="855b3-118">xuid</span></span>| <span data-ttu-id="855b3-119">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="855b3-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="855b3-120">Xbox のユーザー ID を (XUID)、プレーヤーの要求を行う。</span><span class="sxs-lookup"><span data-stu-id="855b3-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="855b3-121">scid</span><span class="sxs-lookup"><span data-stu-id="855b3-121">scid</span></span>| <span data-ttu-id="855b3-122">guid</span><span class="sxs-lookup"><span data-stu-id="855b3-122">guid</span></span>| <span data-ttu-id="855b3-123">検索するサービス構成の ID。</span><span class="sxs-lookup"><span data-stu-id="855b3-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="855b3-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="855b3-124">pathAndFileName</span></span>| <span data-ttu-id="855b3-125">string</span><span class="sxs-lookup"><span data-stu-id="855b3-125">string</span></span>| <span data-ttu-id="855b3-126">アクセスする項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="855b3-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="855b3-127">有効な文字 (最大、および最後のスラッシュを含む) のパス部分に含まれている大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、アンダー スコア (_)、スラッシュ (/) とします。パスの部分を空にすることがあります。有効な文字の大文字 (A ~ Z)、英小文字 (a ~ z)、数字 (0 ~ 9)、ファイル名の部分 (最後のスラッシュの後の部分すべて) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="855b3-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="855b3-128">ファイル名を空にする可能性がありますはいない末尾をピリオドまたは 2 つの連続するピリオドを含めることは。</span><span class="sxs-lookup"><span data-stu-id="855b3-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="855b3-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="855b3-129">Authorization</span></span> 
 
<span data-ttu-id="855b3-130">要求には、有効な Xbox LIVE の authorization ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="855b3-130">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="855b3-131">呼び出し元がこのリソースへのアクセスを許可されていない場合、サービスは 403 forbidden」応答を返します。</span><span class="sxs-lookup"><span data-stu-id="855b3-131">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="855b3-132">ヘッダーが無効であるか不足している場合、サービスは、401 を返します。</span><span class="sxs-lookup"><span data-stu-id="855b3-132">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="855b3-133">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="855b3-133">Required Request Headers</span></span>
 
| <span data-ttu-id="855b3-134">Header</span><span class="sxs-lookup"><span data-stu-id="855b3-134">Header</span></span>| <span data-ttu-id="855b3-135">Value</span><span class="sxs-lookup"><span data-stu-id="855b3-135">Value</span></span>| <span data-ttu-id="855b3-136">説明</span><span class="sxs-lookup"><span data-stu-id="855b3-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="855b3-137">x-xbl-contract-version</span><span class="sxs-lookup"><span data-stu-id="855b3-137">x-xbl-contract-version</span></span>| <span data-ttu-id="855b3-138">1</span><span class="sxs-lookup"><span data-stu-id="855b3-138">1</span></span>| <span data-ttu-id="855b3-139">API コントラクトのバージョン。</span><span class="sxs-lookup"><span data-stu-id="855b3-139">API contract version.</span></span>| 
| <span data-ttu-id="855b3-140">Authorization</span><span class="sxs-lookup"><span data-stu-id="855b3-140">Authorization</span></span>| <span data-ttu-id="855b3-141">XBL3.0 x = [ハッシュ] です。[トークン]</span><span class="sxs-lookup"><span data-stu-id="855b3-141">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="855b3-142">STS の認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="855b3-142">STS authentication token.</span></span> <span data-ttu-id="855b3-143">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="855b3-143">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="855b3-144">STS トークンを取得および authorization ヘッダーの作成の詳細については、認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="855b3-144">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="855b3-145">省略可能な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="855b3-145">Optional Request Headers</span></span>
 
| <span data-ttu-id="855b3-146">Header</span><span class="sxs-lookup"><span data-stu-id="855b3-146">Header</span></span>| <span data-ttu-id="855b3-147">説明</span><span class="sxs-lookup"><span data-stu-id="855b3-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="855b3-148">If-Match</span><span class="sxs-lookup"><span data-stu-id="855b3-148">If-Match</span></span>| <span data-ttu-id="855b3-149">操作を完了する既存の項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="855b3-149">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="855b3-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="855b3-150">Request body</span></span> 
 
<span data-ttu-id="855b3-151">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="855b3-151">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="855b3-152">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="855b3-152">HTTP status codes</span></span> 
 
<span data-ttu-id="855b3-153">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="855b3-153">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="855b3-154">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="855b3-154">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="855b3-155">コード</span><span class="sxs-lookup"><span data-stu-id="855b3-155">Code</span></span>| <span data-ttu-id="855b3-156">理由語句</span><span class="sxs-lookup"><span data-stu-id="855b3-156">Reason phrase</span></span>| <span data-ttu-id="855b3-157">説明</span><span class="sxs-lookup"><span data-stu-id="855b3-157">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="855b3-158">200</span><span class="sxs-lookup"><span data-stu-id="855b3-158">200</span></span>| <span data-ttu-id="855b3-159">OK</span><span class="sxs-lookup"><span data-stu-id="855b3-159">OK</span></span> | <span data-ttu-id="855b3-160">ファイルは、正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="855b3-160">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="855b3-161">201</span><span class="sxs-lookup"><span data-stu-id="855b3-161">201</span></span>| <span data-ttu-id="855b3-162">作成日</span><span class="sxs-lookup"><span data-stu-id="855b3-162">Created</span></span> | <span data-ttu-id="855b3-163">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="855b3-163">The entity was created.</span></span>| 
| <span data-ttu-id="855b3-164">400</span><span class="sxs-lookup"><span data-stu-id="855b3-164">400</span></span>| <span data-ttu-id="855b3-165">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="855b3-165">Bad Request</span></span> | <span data-ttu-id="855b3-166">サービスは、形式が正しくない要求を理解できませんでした。</span><span class="sxs-lookup"><span data-stu-id="855b3-166">Service could not understand malformed request.</span></span> <span data-ttu-id="855b3-167">通常、無効なパラメーター。</span><span class="sxs-lookup"><span data-stu-id="855b3-167">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="855b3-168">401</span><span class="sxs-lookup"><span data-stu-id="855b3-168">401</span></span>| <span data-ttu-id="855b3-169">権限がありません</span><span class="sxs-lookup"><span data-stu-id="855b3-169">Unauthorized</span></span> | <span data-ttu-id="855b3-170">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="855b3-170">The request requires user authentication.</span></span>| 
| <span data-ttu-id="855b3-171">403</span><span class="sxs-lookup"><span data-stu-id="855b3-171">403</span></span>| <span data-ttu-id="855b3-172">Forbidden</span><span class="sxs-lookup"><span data-stu-id="855b3-172">Forbidden</span></span> | <span data-ttu-id="855b3-173">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="855b3-173">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="855b3-174">404</span><span class="sxs-lookup"><span data-stu-id="855b3-174">404</span></span>| <span data-ttu-id="855b3-175">検出不可</span><span class="sxs-lookup"><span data-stu-id="855b3-175">Not Found</span></span> | <span data-ttu-id="855b3-176">指定されたリソースが見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="855b3-176">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="855b3-177">406</span><span class="sxs-lookup"><span data-stu-id="855b3-177">406</span></span>| <span data-ttu-id="855b3-178">Not Acceptable</span><span class="sxs-lookup"><span data-stu-id="855b3-178">Not Acceptable</span></span> | <span data-ttu-id="855b3-179">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="855b3-179">Resource version is not supported.</span></span>| 
| <span data-ttu-id="855b3-180">408</span><span class="sxs-lookup"><span data-stu-id="855b3-180">408</span></span>| <span data-ttu-id="855b3-181">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="855b3-181">Request Timeout</span></span> | <span data-ttu-id="855b3-182">要求がかかり過ぎて、完了します。</span><span class="sxs-lookup"><span data-stu-id="855b3-182">The request took too long to complete.</span></span>| 
| <span data-ttu-id="855b3-183">500</span><span class="sxs-lookup"><span data-stu-id="855b3-183">500</span></span>| <span data-ttu-id="855b3-184">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="855b3-184">Internal Server Error</span></span> | <span data-ttu-id="855b3-185">サーバーには、要求を満たせませんでした。 予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="855b3-185">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="855b3-186">503</span><span class="sxs-lookup"><span data-stu-id="855b3-186">503</span></span>| <span data-ttu-id="855b3-187">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="855b3-187">Service Unavailable</span></span> | <span data-ttu-id="855b3-188">要求が調整されて、クライアント再試行値 (秒) (例: 5 秒後) の後にもう一度要求を再試行してください。</span><span class="sxs-lookup"><span data-stu-id="855b3-188">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="855b3-189">応答本文</span><span class="sxs-lookup"><span data-stu-id="855b3-189">Response body</span></span> 
 
<span data-ttu-id="855b3-190">応答の本文では、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="855b3-190">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="855b3-191">関連項目</span><span class="sxs-lookup"><span data-stu-id="855b3-191">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="855b3-192">Parent</span><span class="sxs-lookup"><span data-stu-id="855b3-192">Parent</span></span>  

[<span data-ttu-id="855b3-193">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="855b3-193">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

   