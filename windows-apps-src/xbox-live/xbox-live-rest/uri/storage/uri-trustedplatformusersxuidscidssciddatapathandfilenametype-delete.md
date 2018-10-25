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
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5472555"
---
# <a name="delete-trustedplatformusersxuidxuidscidssciddatapathandfilenametype"></a><span data-ttu-id="87c70-104">DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span><span class="sxs-lookup"><span data-stu-id="87c70-104">DELETE (/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="87c70-105">ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="87c70-105">Deletes a file.</span></span> <span data-ttu-id="87c70-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="87c70-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="87c70-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="87c70-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="87c70-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="87c70-108">Authorization</span></span>](#ID4EEB)
  * [<span data-ttu-id="87c70-109">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="87c70-109">Required Request Headers</span></span>](#ID4ERB)
  * [<span data-ttu-id="87c70-110">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="87c70-110">Optional Request Headers</span></span>](#ID4E1C)
  * [<span data-ttu-id="87c70-111">要求本文</span><span class="sxs-lookup"><span data-stu-id="87c70-111">Request body</span></span>](#ID4EWD)
  * [<span data-ttu-id="87c70-112">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="87c70-112">HTTP status codes</span></span>](#ID4EDE)
  * [<span data-ttu-id="87c70-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="87c70-113">Response body</span></span>](#ID4EUBAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="87c70-114">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="87c70-114">URI parameters</span></span> 
 
| <span data-ttu-id="87c70-115">パラメーター</span><span class="sxs-lookup"><span data-stu-id="87c70-115">Parameter</span></span>| <span data-ttu-id="87c70-116">型</span><span class="sxs-lookup"><span data-stu-id="87c70-116">Type</span></span>| <span data-ttu-id="87c70-117">説明</span><span class="sxs-lookup"><span data-stu-id="87c70-117">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="87c70-118">xuid</span><span class="sxs-lookup"><span data-stu-id="87c70-118">xuid</span></span>| <span data-ttu-id="87c70-119">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="87c70-119">unsigned 64-bit integer</span></span>| <span data-ttu-id="87c70-120">Xbox ユーザー ID を (XUID) プレイヤーの要求を行っているユーザー。</span><span class="sxs-lookup"><span data-stu-id="87c70-120">The Xbox User ID (XUID) of the player who making the request.</span></span>| 
| <span data-ttu-id="87c70-121">scid</span><span class="sxs-lookup"><span data-stu-id="87c70-121">scid</span></span>| <span data-ttu-id="87c70-122">guid</span><span class="sxs-lookup"><span data-stu-id="87c70-122">guid</span></span>| <span data-ttu-id="87c70-123">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="87c70-123">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="87c70-124">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="87c70-124">pathAndFileName</span></span>| <span data-ttu-id="87c70-125">string</span><span class="sxs-lookup"><span data-stu-id="87c70-125">string</span></span>| <span data-ttu-id="87c70-126">アクセスできる項目のパスとファイルの名前です。</span><span class="sxs-lookup"><span data-stu-id="87c70-126">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="87c70-127">パス部分 (となどを含む最終的なスラッシュ) の有効な文字が大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="87c70-127">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="87c70-128">ファイル名を空にする可能性がありますはない期間の終了または 2 つの連続するピリオドが含まれてはします。</span><span class="sxs-lookup"><span data-stu-id="87c70-128">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="87c70-129">type</span><span class="sxs-lookup"><span data-stu-id="87c70-129">type</span></span>| <span data-ttu-id="87c70-130">文字列</span><span class="sxs-lookup"><span data-stu-id="87c70-130">string</span></span>| <span data-ttu-id="87c70-131">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="87c70-131">The format of the data.</span></span> <span data-ttu-id="87c70-132">可能な値は、バイナリまたは json です。</span><span class="sxs-lookup"><span data-stu-id="87c70-132">Possible values are binary or json.</span></span>| 
  
<a id="ID4EEB"></a>

 
## <a name="authorization"></a><span data-ttu-id="87c70-133">Authorization</span><span class="sxs-lookup"><span data-stu-id="87c70-133">Authorization</span></span> 
 
<span data-ttu-id="87c70-134">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="87c70-134">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="87c70-135">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="87c70-135">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="87c70-136">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="87c70-136">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4ERB"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="87c70-137">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="87c70-137">Required Request Headers</span></span>
 
| <span data-ttu-id="87c70-138">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="87c70-138">Header</span></span>| <span data-ttu-id="87c70-139">設定値</span><span class="sxs-lookup"><span data-stu-id="87c70-139">Value</span></span>| <span data-ttu-id="87c70-140">説明</span><span class="sxs-lookup"><span data-stu-id="87c70-140">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="87c70-141">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="87c70-141">x-xbl-contract-version</span></span>| <span data-ttu-id="87c70-142">1</span><span class="sxs-lookup"><span data-stu-id="87c70-142">1</span></span>| <span data-ttu-id="87c70-143">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="87c70-143">API contract version.</span></span>| 
| <span data-ttu-id="87c70-144">Authorization</span><span class="sxs-lookup"><span data-stu-id="87c70-144">Authorization</span></span>| <span data-ttu-id="87c70-145">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="87c70-145">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="87c70-146">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="87c70-146">STS authentication token.</span></span> <span data-ttu-id="87c70-147">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="87c70-147">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="87c70-148">STS トークンを取得して、承認ヘッダーの作成について詳しくは、用いた認証と Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="87c70-148">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4E1C"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="87c70-149">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="87c70-149">Optional Request Headers</span></span>
 
| <span data-ttu-id="87c70-150">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="87c70-150">Header</span></span>| <span data-ttu-id="87c70-151">説明</span><span class="sxs-lookup"><span data-stu-id="87c70-151">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="87c70-152">If-Match</span><span class="sxs-lookup"><span data-stu-id="87c70-152">If-Match</span></span>| <span data-ttu-id="87c70-153">操作を完了するにより既存項目に一致する必要がある ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="87c70-153">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
  
<a id="ID4EWD"></a>

 
## <a name="request-body"></a><span data-ttu-id="87c70-154">要求本文</span><span class="sxs-lookup"><span data-stu-id="87c70-154">Request body</span></span> 
 
<span data-ttu-id="87c70-155">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="87c70-155">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EDE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="87c70-156">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="87c70-156">HTTP status codes</span></span> 
 
<span data-ttu-id="87c70-157">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="87c70-157">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="87c70-158">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="87c70-158">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="87c70-159">コード</span><span class="sxs-lookup"><span data-stu-id="87c70-159">Code</span></span>| <span data-ttu-id="87c70-160">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="87c70-160">Reason phrase</span></span>| <span data-ttu-id="87c70-161">説明</span><span class="sxs-lookup"><span data-stu-id="87c70-161">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="87c70-162">200</span><span class="sxs-lookup"><span data-stu-id="87c70-162">200</span></span>| <span data-ttu-id="87c70-163">OK</span><span class="sxs-lookup"><span data-stu-id="87c70-163">OK</span></span> | <span data-ttu-id="87c70-164">ファイルは正常に削除されたか、存在しません。</span><span class="sxs-lookup"><span data-stu-id="87c70-164">The file was deleted successfully, or does not exist.</span></span>| 
| <span data-ttu-id="87c70-165">201</span><span class="sxs-lookup"><span data-stu-id="87c70-165">201</span></span>| <span data-ttu-id="87c70-166">Created</span><span class="sxs-lookup"><span data-stu-id="87c70-166">Created</span></span> | <span data-ttu-id="87c70-167">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="87c70-167">The entity was created.</span></span>| 
| <span data-ttu-id="87c70-168">400</span><span class="sxs-lookup"><span data-stu-id="87c70-168">400</span></span>| <span data-ttu-id="87c70-169">Bad Request</span><span class="sxs-lookup"><span data-stu-id="87c70-169">Bad Request</span></span> | <span data-ttu-id="87c70-170">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="87c70-170">Service could not understand malformed request.</span></span> <span data-ttu-id="87c70-171">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="87c70-171">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="87c70-172">401</span><span class="sxs-lookup"><span data-stu-id="87c70-172">401</span></span>| <span data-ttu-id="87c70-173">権限がありません</span><span class="sxs-lookup"><span data-stu-id="87c70-173">Unauthorized</span></span> | <span data-ttu-id="87c70-174">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="87c70-174">The request requires user authentication.</span></span>| 
| <span data-ttu-id="87c70-175">403</span><span class="sxs-lookup"><span data-stu-id="87c70-175">403</span></span>| <span data-ttu-id="87c70-176">Forbidden</span><span class="sxs-lookup"><span data-stu-id="87c70-176">Forbidden</span></span> | <span data-ttu-id="87c70-177">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="87c70-177">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="87c70-178">404</span><span class="sxs-lookup"><span data-stu-id="87c70-178">404</span></span>| <span data-ttu-id="87c70-179">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="87c70-179">Not Found</span></span> | <span data-ttu-id="87c70-180">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="87c70-180">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="87c70-181">406</span><span class="sxs-lookup"><span data-stu-id="87c70-181">406</span></span>| <span data-ttu-id="87c70-182">許容できません。</span><span class="sxs-lookup"><span data-stu-id="87c70-182">Not Acceptable</span></span> | <span data-ttu-id="87c70-183">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="87c70-183">Resource version is not supported.</span></span>| 
| <span data-ttu-id="87c70-184">408</span><span class="sxs-lookup"><span data-stu-id="87c70-184">408</span></span>| <span data-ttu-id="87c70-185">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="87c70-185">Request Timeout</span></span> | <span data-ttu-id="87c70-186">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="87c70-186">The request took too long to complete.</span></span>| 
| <span data-ttu-id="87c70-187">500</span><span class="sxs-lookup"><span data-stu-id="87c70-187">500</span></span>| <span data-ttu-id="87c70-188">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="87c70-188">Internal Server Error</span></span> | <span data-ttu-id="87c70-189">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="87c70-189">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="87c70-190">503</span><span class="sxs-lookup"><span data-stu-id="87c70-190">503</span></span>| <span data-ttu-id="87c70-191">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="87c70-191">Service Unavailable</span></span> | <span data-ttu-id="87c70-192">要求がスロット リングされて、秒 (例: 5 秒後) のクライアント再試行値後にもう一度要求を行ってください。</span><span class="sxs-lookup"><span data-stu-id="87c70-192">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EUBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="87c70-193">応答本文</span><span class="sxs-lookup"><span data-stu-id="87c70-193">Response body</span></span> 
 
<span data-ttu-id="87c70-194">応答の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="87c70-194">No objects are sent in the body of the response.</span></span>
  
<a id="ID4EDCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="87c70-195">関連項目</span><span class="sxs-lookup"><span data-stu-id="87c70-195">See also</span></span>
 
<a id="ID4EFCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="87c70-196">Parent</span><span class="sxs-lookup"><span data-stu-id="87c70-196">Parent</span></span>  

[<span data-ttu-id="87c70-197">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="87c70-197">/trustedplatform/users/xuid({xuid})/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-trustedplatformusersxuidscidssciddatapathandfilenametype.md)

   