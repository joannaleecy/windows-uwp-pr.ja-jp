---
title: DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)
assetID: b8d862d1-1651-b6c2-cc25-c5398128e882
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype-delete.html
author: KevinAsgari
description: " DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5b260461de0458f53f5edb93256dcb409d8397ee
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4569351"
---
# <a name="delete-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="e3668-104">DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="e3668-104">DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="e3668-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="e3668-105">Deletes a file.</span></span> <span data-ttu-id="e3668-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e3668-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e3668-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e3668-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="e3668-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="e3668-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="e3668-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3668-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="e3668-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3668-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="e3668-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="e3668-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="e3668-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e3668-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="e3668-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="e3668-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e3668-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e3668-114">URI parameters</span></span> 
 
| <span data-ttu-id="e3668-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e3668-115">Parameter</span></span>| <span data-ttu-id="e3668-116">型</span><span class="sxs-lookup"><span data-stu-id="e3668-116">Type</span></span>| <span data-ttu-id="e3668-117">説明</span><span class="sxs-lookup"><span data-stu-id="e3668-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e3668-118">xuid</span><span class="sxs-lookup"><span data-stu-id="e3668-118">xuid</span></span>| <span data-ttu-id="e3668-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e3668-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="e3668-120">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="e3668-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="e3668-121">scid</span><span class="sxs-lookup"><span data-stu-id="e3668-121">scid</span></span>| <span data-ttu-id="e3668-122">guid</span><span class="sxs-lookup"><span data-stu-id="e3668-122">guid</span></span>| <span data-ttu-id="e3668-123">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="e3668-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="e3668-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="e3668-124">pathAndFileName</span></span>| <span data-ttu-id="e3668-125">string</span><span class="sxs-lookup"><span data-stu-id="e3668-125">string</span></span>| <span data-ttu-id="e3668-126">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="e3668-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="e3668-127">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、(A ~ Z) の大文字、小文字の英字 (a ~ z)、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="e3668-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="e3668-128">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="e3668-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="e3668-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="e3668-129">Authorization</span></span> 
 
<span data-ttu-id="e3668-130">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e3668-130">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="e3668-131">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは 403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="e3668-131">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="e3668-132">ヘッダーが見つからないか無効な場合は、サービスは 401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="e3668-132">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e3668-133">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3668-133">Required Request Headers</span></span>
 
| <span data-ttu-id="e3668-134">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3668-134">Header</span></span>| <span data-ttu-id="e3668-135">設定値</span><span class="sxs-lookup"><span data-stu-id="e3668-135">Value</span></span>| <span data-ttu-id="e3668-136">説明</span><span class="sxs-lookup"><span data-stu-id="e3668-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e3668-137">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="e3668-137">x-xbl-contract-version</span></span>| <span data-ttu-id="e3668-138">1</span><span class="sxs-lookup"><span data-stu-id="e3668-138">1</span></span>| <span data-ttu-id="e3668-139">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="e3668-139">API contract version.</span></span>| 
| <span data-ttu-id="e3668-140">Authorization</span><span class="sxs-lookup"><span data-stu-id="e3668-140">Authorization</span></span>| <span data-ttu-id="e3668-141">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="e3668-141">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="e3668-142">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="e3668-142">STS authentication token.</span></span> <span data-ttu-id="e3668-143">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="e3668-143">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="e3668-144">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e3668-144">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="e3668-145">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3668-145">Optional Request Headers</span></span>
 
| <span data-ttu-id="e3668-146">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e3668-146">Header</span></span>| <span data-ttu-id="e3668-147">説明</span><span class="sxs-lookup"><span data-stu-id="e3668-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e3668-148">If-Match</span><span class="sxs-lookup"><span data-stu-id="e3668-148">If-Match</span></span>| <span data-ttu-id="e3668-149">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="e3668-149">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="e3668-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="e3668-150">Request body</span></span> 
 
<span data-ttu-id="e3668-151">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e3668-151">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="e3668-152">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="e3668-152">HTTP status codes</span></span> 
 
<span data-ttu-id="e3668-153">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e3668-153">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e3668-154">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e3668-154">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="e3668-155">コード</span><span class="sxs-lookup"><span data-stu-id="e3668-155">Code</span></span>| <span data-ttu-id="e3668-156">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="e3668-156">Reason phrase</span></span>| <span data-ttu-id="e3668-157">説明</span><span class="sxs-lookup"><span data-stu-id="e3668-157">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e3668-158">200</span><span class="sxs-lookup"><span data-stu-id="e3668-158">200</span></span>| <span data-ttu-id="e3668-159">OK</span><span class="sxs-lookup"><span data-stu-id="e3668-159">OK</span></span> | <span data-ttu-id="e3668-160">ファイルは正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="e3668-160">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="e3668-161">201</span><span class="sxs-lookup"><span data-stu-id="e3668-161">201</span></span>| <span data-ttu-id="e3668-162">Created</span><span class="sxs-lookup"><span data-stu-id="e3668-162">Created</span></span> | <span data-ttu-id="e3668-163">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="e3668-163">The entity was created.</span></span>| 
| <span data-ttu-id="e3668-164">400</span><span class="sxs-lookup"><span data-stu-id="e3668-164">400</span></span>| <span data-ttu-id="e3668-165">Bad Request</span><span class="sxs-lookup"><span data-stu-id="e3668-165">Bad Request</span></span> | <span data-ttu-id="e3668-166">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="e3668-166">Service could not understand malformed request.</span></span> <span data-ttu-id="e3668-167">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="e3668-167">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="e3668-168">401</span><span class="sxs-lookup"><span data-stu-id="e3668-168">401</span></span>| <span data-ttu-id="e3668-169">権限がありません</span><span class="sxs-lookup"><span data-stu-id="e3668-169">Unauthorized</span></span> | <span data-ttu-id="e3668-170">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="e3668-170">The request requires user authentication.</span></span>| 
| <span data-ttu-id="e3668-171">403</span><span class="sxs-lookup"><span data-stu-id="e3668-171">403</span></span>| <span data-ttu-id="e3668-172">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e3668-172">Forbidden</span></span> | <span data-ttu-id="e3668-173">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="e3668-173">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="e3668-174">404</span><span class="sxs-lookup"><span data-stu-id="e3668-174">404</span></span>| <span data-ttu-id="e3668-175">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="e3668-175">Not Found</span></span> | <span data-ttu-id="e3668-176">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="e3668-176">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="e3668-177">406</span><span class="sxs-lookup"><span data-stu-id="e3668-177">406</span></span>| <span data-ttu-id="e3668-178">許容できません。</span><span class="sxs-lookup"><span data-stu-id="e3668-178">Not Acceptable</span></span> | <span data-ttu-id="e3668-179">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="e3668-179">Resource version is not supported.</span></span>| 
| <span data-ttu-id="e3668-180">408</span><span class="sxs-lookup"><span data-stu-id="e3668-180">408</span></span>| <span data-ttu-id="e3668-181">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="e3668-181">Request Timeout</span></span> | <span data-ttu-id="e3668-182">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="e3668-182">The request took too long to complete.</span></span>| 
| <span data-ttu-id="e3668-183">500</span><span class="sxs-lookup"><span data-stu-id="e3668-183">500</span></span>| <span data-ttu-id="e3668-184">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="e3668-184">Internal Server Error</span></span> | <span data-ttu-id="e3668-185">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="e3668-185">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="e3668-186">503</span><span class="sxs-lookup"><span data-stu-id="e3668-186">503</span></span>| <span data-ttu-id="e3668-187">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="e3668-187">Service Unavailable</span></span> | <span data-ttu-id="e3668-188">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="e3668-188">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="e3668-189">応答本文</span><span class="sxs-lookup"><span data-stu-id="e3668-189">Response body</span></span> 
 
<span data-ttu-id="e3668-190">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="e3668-190">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e3668-191">関連項目</span><span class="sxs-lookup"><span data-stu-id="e3668-191">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e3668-192">Parent</span><span class="sxs-lookup"><span data-stu-id="e3668-192">Parent</span></span>  

[<span data-ttu-id="e3668-193">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="e3668-193">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

   