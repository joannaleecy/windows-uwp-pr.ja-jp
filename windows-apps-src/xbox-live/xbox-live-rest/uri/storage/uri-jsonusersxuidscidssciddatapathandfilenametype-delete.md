---
title: DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)
assetID: b8d862d1-1651-b6c2-cc25-c5398128e882
permalink: en-us/docs/xboxlive/rest/uri-jsonusersxuidscidssciddatapathandfilenametype-delete.html
author: KevinAsgari
description: " DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 22748c39c0ba4eef6708659846e2386fc6471202
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6268072"
---
# <a name="delete-jsonusersxuidxuidscidssciddatapathandfilenamejson"></a><span data-ttu-id="fd3d0-104">DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span><span class="sxs-lookup"><span data-stu-id="fd3d0-104">DELETE (/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json)</span></span>
<span data-ttu-id="fd3d0-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-105">Deletes a file.</span></span> <span data-ttu-id="fd3d0-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="fd3d0-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fd3d0-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="fd3d0-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="fd3d0-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="fd3d0-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd3d0-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="fd3d0-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd3d0-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="fd3d0-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="fd3d0-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="fd3d0-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="fd3d0-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="fd3d0-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="fd3d0-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="fd3d0-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="fd3d0-114">URI parameters</span></span> 
 
| <span data-ttu-id="fd3d0-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="fd3d0-115">Parameter</span></span>| <span data-ttu-id="fd3d0-116">型</span><span class="sxs-lookup"><span data-stu-id="fd3d0-116">Type</span></span>| <span data-ttu-id="fd3d0-117">説明</span><span class="sxs-lookup"><span data-stu-id="fd3d0-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="fd3d0-118">xuid</span><span class="sxs-lookup"><span data-stu-id="fd3d0-118">xuid</span></span>| <span data-ttu-id="fd3d0-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fd3d0-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="fd3d0-120">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="fd3d0-121">scid</span><span class="sxs-lookup"><span data-stu-id="fd3d0-121">scid</span></span>| <span data-ttu-id="fd3d0-122">guid</span><span class="sxs-lookup"><span data-stu-id="fd3d0-122">guid</span></span>| <span data-ttu-id="fd3d0-123">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="fd3d0-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="fd3d0-124">pathAndFileName</span></span>| <span data-ttu-id="fd3d0-125">string</span><span class="sxs-lookup"><span data-stu-id="fd3d0-125">string</span></span>| <span data-ttu-id="fd3d0-126">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="fd3d0-127">パスの部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="fd3d0-128">ファイル名可能性がありますいない空にすること、期間の終了または 2 つの連続するピリオドが含まれます。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="fd3d0-129">Authorization</span><span class="sxs-lookup"><span data-stu-id="fd3d0-129">Authorization</span></span> 
 
<span data-ttu-id="fd3d0-130">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-130">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="fd3d0-131">呼び出し元がこのリソースへのアクセスを許可しない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-131">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="fd3d0-132">ヘッダーが見つからないか無効な場合は、サービスは、401 不正な応答を返します。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-132">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="fd3d0-133">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd3d0-133">Required Request Headers</span></span>
 
| <span data-ttu-id="fd3d0-134">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd3d0-134">Header</span></span>| <span data-ttu-id="fd3d0-135">設定値</span><span class="sxs-lookup"><span data-stu-id="fd3d0-135">Value</span></span>| <span data-ttu-id="fd3d0-136">説明</span><span class="sxs-lookup"><span data-stu-id="fd3d0-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fd3d0-137">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="fd3d0-137">x-xbl-contract-version</span></span>| <span data-ttu-id="fd3d0-138">1</span><span class="sxs-lookup"><span data-stu-id="fd3d0-138">1</span></span>| <span data-ttu-id="fd3d0-139">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-139">API contract version.</span></span>| 
| <span data-ttu-id="fd3d0-140">Authorization</span><span class="sxs-lookup"><span data-stu-id="fd3d0-140">Authorization</span></span>| <span data-ttu-id="fd3d0-141">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="fd3d0-141">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="fd3d0-142">STS 認証トークン。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-142">STS authentication token.</span></span> <span data-ttu-id="fd3d0-143">STSTokenString は、認証要求によって返されるトークンに置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-143">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="fd3d0-144">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-144">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="fd3d0-145">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd3d0-145">Optional Request Headers</span></span>
 
| <span data-ttu-id="fd3d0-146">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="fd3d0-146">Header</span></span>| <span data-ttu-id="fd3d0-147">説明</span><span class="sxs-lookup"><span data-stu-id="fd3d0-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fd3d0-148">If-Match</span><span class="sxs-lookup"><span data-stu-id="fd3d0-148">If-Match</span></span>| <span data-ttu-id="fd3d0-149">操作を完了するにより既存項目と一致する ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-149">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="fd3d0-150">要求本文</span><span class="sxs-lookup"><span data-stu-id="fd3d0-150">Request body</span></span> 
 
<span data-ttu-id="fd3d0-151">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-151">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="fd3d0-152">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="fd3d0-152">HTTP status codes</span></span> 
 
<span data-ttu-id="fd3d0-153">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-153">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="fd3d0-154">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-154">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="fd3d0-155">コード</span><span class="sxs-lookup"><span data-stu-id="fd3d0-155">Code</span></span>| <span data-ttu-id="fd3d0-156">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="fd3d0-156">Reason phrase</span></span>| <span data-ttu-id="fd3d0-157">説明</span><span class="sxs-lookup"><span data-stu-id="fd3d0-157">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="fd3d0-158">200</span><span class="sxs-lookup"><span data-stu-id="fd3d0-158">200</span></span>| <span data-ttu-id="fd3d0-159">OK</span><span class="sxs-lookup"><span data-stu-id="fd3d0-159">OK</span></span> | <span data-ttu-id="fd3d0-160">ファイルは正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-160">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="fd3d0-161">201</span><span class="sxs-lookup"><span data-stu-id="fd3d0-161">201</span></span>| <span data-ttu-id="fd3d0-162">Created</span><span class="sxs-lookup"><span data-stu-id="fd3d0-162">Created</span></span> | <span data-ttu-id="fd3d0-163">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-163">The entity was created.</span></span>| 
| <span data-ttu-id="fd3d0-164">400</span><span class="sxs-lookup"><span data-stu-id="fd3d0-164">400</span></span>| <span data-ttu-id="fd3d0-165">Bad Request</span><span class="sxs-lookup"><span data-stu-id="fd3d0-165">Bad Request</span></span> | <span data-ttu-id="fd3d0-166">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-166">Service could not understand malformed request.</span></span> <span data-ttu-id="fd3d0-167">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-167">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="fd3d0-168">401</span><span class="sxs-lookup"><span data-stu-id="fd3d0-168">401</span></span>| <span data-ttu-id="fd3d0-169">権限がありません</span><span class="sxs-lookup"><span data-stu-id="fd3d0-169">Unauthorized</span></span> | <span data-ttu-id="fd3d0-170">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-170">The request requires user authentication.</span></span>| 
| <span data-ttu-id="fd3d0-171">403</span><span class="sxs-lookup"><span data-stu-id="fd3d0-171">403</span></span>| <span data-ttu-id="fd3d0-172">Forbidden</span><span class="sxs-lookup"><span data-stu-id="fd3d0-172">Forbidden</span></span> | <span data-ttu-id="fd3d0-173">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-173">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="fd3d0-174">404</span><span class="sxs-lookup"><span data-stu-id="fd3d0-174">404</span></span>| <span data-ttu-id="fd3d0-175">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-175">Not Found</span></span> | <span data-ttu-id="fd3d0-176">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-176">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="fd3d0-177">406</span><span class="sxs-lookup"><span data-stu-id="fd3d0-177">406</span></span>| <span data-ttu-id="fd3d0-178">許容できません。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-178">Not Acceptable</span></span> | <span data-ttu-id="fd3d0-179">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-179">Resource version is not supported.</span></span>| 
| <span data-ttu-id="fd3d0-180">408</span><span class="sxs-lookup"><span data-stu-id="fd3d0-180">408</span></span>| <span data-ttu-id="fd3d0-181">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="fd3d0-181">Request Timeout</span></span> | <span data-ttu-id="fd3d0-182">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-182">The request took too long to complete.</span></span>| 
| <span data-ttu-id="fd3d0-183">500</span><span class="sxs-lookup"><span data-stu-id="fd3d0-183">500</span></span>| <span data-ttu-id="fd3d0-184">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="fd3d0-184">Internal Server Error</span></span> | <span data-ttu-id="fd3d0-185">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-185">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="fd3d0-186">503</span><span class="sxs-lookup"><span data-stu-id="fd3d0-186">503</span></span>| <span data-ttu-id="fd3d0-187">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="fd3d0-187">Service Unavailable</span></span> | <span data-ttu-id="fd3d0-188">要求がスロット リングされた、(例: 5 秒後) を秒単位でクライアント再試行値後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-188">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="fd3d0-189">応答本文</span><span class="sxs-lookup"><span data-stu-id="fd3d0-189">Response body</span></span> 
 
<span data-ttu-id="fd3d0-190">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="fd3d0-190">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="fd3d0-191">関連項目</span><span class="sxs-lookup"><span data-stu-id="fd3d0-191">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="fd3d0-192">Parent</span><span class="sxs-lookup"><span data-stu-id="fd3d0-192">Parent</span></span>  

[<span data-ttu-id="fd3d0-193">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span><span class="sxs-lookup"><span data-stu-id="fd3d0-193">/json/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},json</span></span>](uri-jsonusersxuidscidssciddatapathandfilenametype.md)

   