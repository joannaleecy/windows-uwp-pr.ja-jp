---
title: 取得する (グローバル//global/scids/{scid}/data/{pathAndFileName} {の種類})
assetID: 5ca8e0dd-3c45-1b7b-022e-d5d61414fd7d
permalink: en-us/docs/xboxlive/rest/uri-globalscidssciddatapathandfilenametype-get.html
author: KevinAsgari
description: " 取得する (グローバル//global/scids/{scid}/data/{pathAndFileName} {の種類})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 03da8b482dcfb8a4972fee69c0e3995d792cb87a
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3935230"
---
# <a name="get-globalscidssciddatapathandfilenametype"></a><span data-ttu-id="911c7-104">取得する (グローバル//global/scids/{scid}/data/{pathAndFileName} {の種類})</span><span class="sxs-lookup"><span data-stu-id="911c7-104">GET (/global/scids/{scid}/data/{pathAndFileName},{type})</span></span>
<span data-ttu-id="911c7-105">ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="911c7-105">Downloads a file.</span></span> <span data-ttu-id="911c7-106">これらの Uri のドメインが`titlestorage.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="911c7-106">The domain for these URIs is `titlestorage.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="911c7-107">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="911c7-107">URI parameters</span></span>](#ID4EX)
  * [<span data-ttu-id="911c7-108">Authorization</span><span class="sxs-lookup"><span data-stu-id="911c7-108">Authorization</span></span>](#ID4ECB)
  * [<span data-ttu-id="911c7-109">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="911c7-109">Optional Query String Parameters</span></span>](#ID4EPB)
  * [<span data-ttu-id="911c7-110">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-110">Required Request Headers</span></span>](#ID4EZC)
  * [<span data-ttu-id="911c7-111">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-111">Optional Request Headers</span></span>](#ID4ECE)
  * [<span data-ttu-id="911c7-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="911c7-112">Request body</span></span>](#ID4EMF)
  * [<span data-ttu-id="911c7-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="911c7-113">HTTP status codes</span></span>](#ID4EZF)
  * [<span data-ttu-id="911c7-114">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-114">Response Headers</span></span>](#ID4EMDAC)
  * [<span data-ttu-id="911c7-115">応答本文</span><span class="sxs-lookup"><span data-stu-id="911c7-115">Response body</span></span>](#ID4EPEAC)
 
<a id="ID4EX"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="911c7-116">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="911c7-116">URI parameters</span></span>
 
| <span data-ttu-id="911c7-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="911c7-117">Parameter</span></span>| <span data-ttu-id="911c7-118">型</span><span class="sxs-lookup"><span data-stu-id="911c7-118">Type</span></span>| <span data-ttu-id="911c7-119">説明</span><span class="sxs-lookup"><span data-stu-id="911c7-119">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="911c7-120">scid</span><span class="sxs-lookup"><span data-stu-id="911c7-120">scid</span></span>| <span data-ttu-id="911c7-121">guid</span><span class="sxs-lookup"><span data-stu-id="911c7-121">guid</span></span>| <span data-ttu-id="911c7-122">ルックアップ サービス構成の ID です。</span><span class="sxs-lookup"><span data-stu-id="911c7-122">the ID of the service config to look up.</span></span>| 
| <span data-ttu-id="911c7-123">pathAndFileName</span><span class="sxs-lookup"><span data-stu-id="911c7-123">pathAndFileName</span></span>| <span data-ttu-id="911c7-124">string</span><span class="sxs-lookup"><span data-stu-id="911c7-124">string</span></span>| <span data-ttu-id="911c7-125">アクセスできる項目のパスとファイル名。</span><span class="sxs-lookup"><span data-stu-id="911c7-125">Path and file name for the item to be accessed.</span></span> <span data-ttu-id="911c7-126">(となどを含む最終的なスラッシュ) のパス部分に有効な文字は大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9)、アンダー スコア (_) を含めるし、スラッシュ (/)。パス部分を空にすることがあります。有効な文字 (すべての最終的なスラッシュ後) ファイル名の部分には、大文字 (A ~ Z)、(a ~ z) 小文字の英字、数字 (0 ~ 9) が含まれているアンダー スコア (_)、ピリオド (.)、およびハイフン (-)。</span><span class="sxs-lookup"><span data-stu-id="911c7-126">Valid characters for the path portion (up to and including the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), and forward slash (/). The path portion may be empty. Valid characters for the file name portion (everything after the final forward slash) include uppercase letters (A-Z), lowercase letters (a-z), numbers (0-9), underscore (_), period (.), and hyphen (-).</span></span> <span data-ttu-id="911c7-127">ファイル名可能性がありますいないを空にする、期間の終了または 2 つの連続するピリオドが含まれています。</span><span class="sxs-lookup"><span data-stu-id="911c7-127">The file name may not be empty, end in a period or contain two consecutive periods.</span></span>| 
| <span data-ttu-id="911c7-128">type</span><span class="sxs-lookup"><span data-stu-id="911c7-128">type</span></span>| <span data-ttu-id="911c7-129">文字列</span><span class="sxs-lookup"><span data-stu-id="911c7-129">string</span></span>| <span data-ttu-id="911c7-130">データの形式です。</span><span class="sxs-lookup"><span data-stu-id="911c7-130">The format of the data.</span></span> <span data-ttu-id="911c7-131">使用可能な値: バイナリ、config または json します。</span><span class="sxs-lookup"><span data-stu-id="911c7-131">Possible values are: binary, config or json.</span></span>| 
  
<a id="ID4ECB"></a>

 
## <a name="authorization"></a><span data-ttu-id="911c7-132">Authorization</span><span class="sxs-lookup"><span data-stu-id="911c7-132">Authorization</span></span> 
 
<span data-ttu-id="911c7-133">要求は、Xbox LIVE の有効な承認ヘッダーを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="911c7-133">The request must include a valid Xbox LIVE authorization header.</span></span> <span data-ttu-id="911c7-134">呼び出し元がこのリソースへのアクセス許可されていない場合、サービスは、403 Forbidden 応答を返します。</span><span class="sxs-lookup"><span data-stu-id="911c7-134">If caller is not allowed to access this resource, the service will return a 403 Forbidden response.</span></span> <span data-ttu-id="911c7-135">ヘッダーが見つからないか無効な場合は、サービスは、401 承認されていない応答を返します。</span><span class="sxs-lookup"><span data-stu-id="911c7-135">If the header is invalid or missing, the service will return a 401 Unauthorized response.</span></span> 
  
<a id="ID4EPB"></a>

 
## <a name="optional-query-string-parameters"></a><span data-ttu-id="911c7-136">オプションのクエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="911c7-136">Optional Query String Parameters</span></span> 
 
<span data-ttu-id="911c7-137">Blob の種類によって異なります。</span><span class="sxs-lookup"><span data-stu-id="911c7-137">Varies by blob type.</span></span> <span data-ttu-id="911c7-138">バイナリ blob には、クエリ パラメーターをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="911c7-138">Binary blobs do not support query parameters.</span></span>
 
| <span data-ttu-id="911c7-139">パラメーター</span><span class="sxs-lookup"><span data-stu-id="911c7-139">Parameter</span></span>| <span data-ttu-id="911c7-140">型</span><span class="sxs-lookup"><span data-stu-id="911c7-140">Type</span></span>| <span data-ttu-id="911c7-141">説明</span><span class="sxs-lookup"><span data-stu-id="911c7-141">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="911c7-142">選択</span><span class="sxs-lookup"><span data-stu-id="911c7-142">select</span></span>| <span data-ttu-id="911c7-143">string</span><span class="sxs-lookup"><span data-stu-id="911c7-143">string</span></span>| <span data-ttu-id="911c7-144">型は json ときにのみ使用します。</span><span class="sxs-lookup"><span data-stu-id="911c7-144">Only usable when type is json.</span></span> <span data-ttu-id="911c7-145">応答する必要がありますのみを含む特定プロパティ/値、JSON のこのパラメーターによって決定されるを指定します。</span><span class="sxs-lookup"><span data-stu-id="911c7-145">Specifies that the response should only contain a certain property/value of the JSON, as determined by this parameter.</span></span> <span data-ttu-id="911c7-146">サブプロパティと角かっこを指定する「ドット」(.) を使用して ('[' と ']') を配列のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="911c7-146">Use a "dot" (.) to specify sub-properties and square brackets ('[' and ']') to specify array indices.</span></span> <span data-ttu-id="911c7-147">たとえば、"配列 1 [4] .prop2"配列「1」配列のインデックス 4 の"prop2"プロパティを指定します。</span><span class="sxs-lookup"><span data-stu-id="911c7-147">For example, "array1[4].prop2" specifies the "prop2" property of index 4 of the "array1" array.</span></span>| 
| <span data-ttu-id="911c7-148">customSelector</span><span class="sxs-lookup"><span data-stu-id="911c7-148">customSelector</span></span>| <span data-ttu-id="911c7-149">string</span><span class="sxs-lookup"><span data-stu-id="911c7-149">string</span></span>| <span data-ttu-id="911c7-150">タイプのファイルを構成します。</span><span class="sxs-lookup"><span data-stu-id="911c7-150">For config type files.</span></span> <span data-ttu-id="911c7-151">どのようなカスタムの仮想ノードを含めることを示します。</span><span class="sxs-lookup"><span data-stu-id="911c7-151">Indicates what custom virtual nodes to include.</span></span> <span data-ttu-id="911c7-152">Config タイプのファイルについて詳しくは、タイトル ストレージを参照してください。</span><span class="sxs-lookup"><span data-stu-id="911c7-152">See Title Storage for more information on config type files.</span></span>| 
  
<a id="ID4EZC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="911c7-153">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-153">Required Request Headers</span></span>
 
| <span data-ttu-id="911c7-154">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-154">Header</span></span>| <span data-ttu-id="911c7-155">設定値</span><span class="sxs-lookup"><span data-stu-id="911c7-155">Value</span></span>| <span data-ttu-id="911c7-156">説明</span><span class="sxs-lookup"><span data-stu-id="911c7-156">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="911c7-157">x xbl コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="911c7-157">x-xbl-contract-version</span></span>| <span data-ttu-id="911c7-158">1</span><span class="sxs-lookup"><span data-stu-id="911c7-158">1</span></span>| <span data-ttu-id="911c7-159">API コントラクト バージョンです。</span><span class="sxs-lookup"><span data-stu-id="911c7-159">API contract version.</span></span>| 
| <span data-ttu-id="911c7-160">Authorization</span><span class="sxs-lookup"><span data-stu-id="911c7-160">Authorization</span></span>| <span data-ttu-id="911c7-161">XBL3.0 x = [ハッシュ]。[トークン]</span><span class="sxs-lookup"><span data-stu-id="911c7-161">XBL3.0 x=[hash];[token]</span></span>| <span data-ttu-id="911c7-162">STS 認証トークンです。</span><span class="sxs-lookup"><span data-stu-id="911c7-162">STS authentication token.</span></span> <span data-ttu-id="911c7-163">STSTokenString は認証要求によって返されるトークンで置き換えられます。</span><span class="sxs-lookup"><span data-stu-id="911c7-163">STSTokenString is replaced by the token returned by the authentication request.</span></span> <span data-ttu-id="911c7-164">STS トークンを取得し、承認ヘッダーを作成する方法については、用いた認証し、Xbox LIVE サービス要求の承認を参照してください。</span><span class="sxs-lookup"><span data-stu-id="911c7-164">See Authenticating and Authorizing Xbox LIVE Services Requests for additional information about retrieving an STS token and creating an authorization header.</span></span>| 
  
<a id="ID4ECE"></a>

 
## <a name="optional-request-headers"></a><span data-ttu-id="911c7-165">オプションの要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-165">Optional Request Headers</span></span>
 
| <span data-ttu-id="911c7-166">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-166">Header</span></span>| <span data-ttu-id="911c7-167">説明</span><span class="sxs-lookup"><span data-stu-id="911c7-167">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="911c7-168">If-Match</span><span class="sxs-lookup"><span data-stu-id="911c7-168">If-Match</span></span>| <span data-ttu-id="911c7-169">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="911c7-169">Specifies an ETag that must match an exisitng item to complete the operation.</span></span>| 
| <span data-ttu-id="911c7-170">If-None-Match</span><span class="sxs-lookup"><span data-stu-id="911c7-170">If-None-Match</span></span>| <span data-ttu-id="911c7-171">操作を完了するにより既存項目に一致する必要があります ETag を指定します。</span><span class="sxs-lookup"><span data-stu-id="911c7-171">Specifies an ETag that must not match any exisitng items to complete the operation.</span></span>| 
| <span data-ttu-id="911c7-172">範囲</span><span class="sxs-lookup"><span data-stu-id="911c7-172">Range</span></span>| <span data-ttu-id="911c7-173">ダウンロードするバイトの範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="911c7-173">Specifies the range of bytes to download.</span></span> <span data-ttu-id="911c7-174">標準の範囲の HTTP ヘッダーの形式に従います。</span><span class="sxs-lookup"><span data-stu-id="911c7-174">Follows the standard HTTP Range header format.</span></span>| 
  
<a id="ID4EMF"></a>

 
## <a name="request-body"></a><span data-ttu-id="911c7-175">要求本文</span><span class="sxs-lookup"><span data-stu-id="911c7-175">Request body</span></span> 
 
<span data-ttu-id="911c7-176">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="911c7-176">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EZF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="911c7-177">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="911c7-177">HTTP status codes</span></span> 
 
<span data-ttu-id="911c7-178">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="911c7-178">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="911c7-179">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="911c7-179">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="911c7-180">コード</span><span class="sxs-lookup"><span data-stu-id="911c7-180">Code</span></span>| <span data-ttu-id="911c7-181">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="911c7-181">Reason phrase</span></span>| <span data-ttu-id="911c7-182">説明</span><span class="sxs-lookup"><span data-stu-id="911c7-182">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="911c7-183">200</span><span class="sxs-lookup"><span data-stu-id="911c7-183">200</span></span>| <span data-ttu-id="911c7-184">OK</span><span class="sxs-lookup"><span data-stu-id="911c7-184">OK</span></span> | <span data-ttu-id="911c7-185">要求が成功しました。</span><span class="sxs-lookup"><span data-stu-id="911c7-185">The request was successful.</span></span>| 
| <span data-ttu-id="911c7-186">201</span><span class="sxs-lookup"><span data-stu-id="911c7-186">201</span></span>| <span data-ttu-id="911c7-187">Created</span><span class="sxs-lookup"><span data-stu-id="911c7-187">Created</span></span> | <span data-ttu-id="911c7-188">エンティティが作成されました。</span><span class="sxs-lookup"><span data-stu-id="911c7-188">The entity was created.</span></span>| 
| <span data-ttu-id="911c7-189">400</span><span class="sxs-lookup"><span data-stu-id="911c7-189">400</span></span>| <span data-ttu-id="911c7-190">Bad Request</span><span class="sxs-lookup"><span data-stu-id="911c7-190">Bad Request</span></span> | <span data-ttu-id="911c7-191">サービスは、形式が正しくない要求を理解していない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="911c7-191">Service could not understand malformed request.</span></span> <span data-ttu-id="911c7-192">通常、無効なパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="911c7-192">Typically an invalid parameter.</span></span>| 
| <span data-ttu-id="911c7-193">401</span><span class="sxs-lookup"><span data-stu-id="911c7-193">401</span></span>| <span data-ttu-id="911c7-194">権限がありません</span><span class="sxs-lookup"><span data-stu-id="911c7-194">Unauthorized</span></span> | <span data-ttu-id="911c7-195">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="911c7-195">The request requires user authentication.</span></span>| 
| <span data-ttu-id="911c7-196">403</span><span class="sxs-lookup"><span data-stu-id="911c7-196">403</span></span>| <span data-ttu-id="911c7-197">Forbidden</span><span class="sxs-lookup"><span data-stu-id="911c7-197">Forbidden</span></span> | <span data-ttu-id="911c7-198">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="911c7-198">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="911c7-199">404</span><span class="sxs-lookup"><span data-stu-id="911c7-199">404</span></span>| <span data-ttu-id="911c7-200">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="911c7-200">Not Found</span></span> | <span data-ttu-id="911c7-201">指定されたリソースは見つかりませんでした。</span><span class="sxs-lookup"><span data-stu-id="911c7-201">The specified resource could not be found.</span></span>| 
| <span data-ttu-id="911c7-202">406</span><span class="sxs-lookup"><span data-stu-id="911c7-202">406</span></span>| <span data-ttu-id="911c7-203">許容できません。</span><span class="sxs-lookup"><span data-stu-id="911c7-203">Not Acceptable</span></span> | <span data-ttu-id="911c7-204">リソースのバージョンがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="911c7-204">Resource version is not supported.</span></span>| 
| <span data-ttu-id="911c7-205">408</span><span class="sxs-lookup"><span data-stu-id="911c7-205">408</span></span>| <span data-ttu-id="911c7-206">要求のタイムアウト</span><span class="sxs-lookup"><span data-stu-id="911c7-206">Request Timeout</span></span> | <span data-ttu-id="911c7-207">要求にかかった時間が長すぎます。</span><span class="sxs-lookup"><span data-stu-id="911c7-207">The request took too long to complete.</span></span>| 
| <span data-ttu-id="911c7-208">500</span><span class="sxs-lookup"><span data-stu-id="911c7-208">500</span></span>| <span data-ttu-id="911c7-209">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="911c7-209">Internal Server Error</span></span> | <span data-ttu-id="911c7-210">サーバーには、要求を満たすことを禁止する予期しない状態が発生しました。</span><span class="sxs-lookup"><span data-stu-id="911c7-210">The server encountered an unexpected condition which prevented it from fulfilling the request.</span></span>| 
| <span data-ttu-id="911c7-211">503</span><span class="sxs-lookup"><span data-stu-id="911c7-211">503</span></span>| <span data-ttu-id="911c7-212">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="911c7-212">Service Unavailable</span></span> | <span data-ttu-id="911c7-213">要求が調整された、(例: 5 秒後) を秒単位でクライアント再試行の値の後にもう一度やり直してください。</span><span class="sxs-lookup"><span data-stu-id="911c7-213">Request has been throttled, try the request again after the client-retry value in seconds (e.g. 5 seconds later).</span></span>| 
  
<a id="ID4EMDAC"></a>

 
## <a name="response-headers"></a><span data-ttu-id="911c7-214">応答ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-214">Response Headers</span></span>
 
| <span data-ttu-id="911c7-215">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="911c7-215">Header</span></span>| <span data-ttu-id="911c7-216">説明</span><span class="sxs-lookup"><span data-stu-id="911c7-216">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="911c7-217">ETag</span><span class="sxs-lookup"><span data-stu-id="911c7-217">ETag</span></span>| <span data-ttu-id="911c7-218">ETag は、web サーバーの URL で見つかったリソースの特定のバージョンによって割り当てられる不透明な識別子です。</span><span class="sxs-lookup"><span data-stu-id="911c7-218">ETag is an opaque identifier assigned by a web server to a specific version of a resource found at a URL.</span></span> <span data-ttu-id="911c7-219">その URL でリソースのコンテンツが変更された場合は、新しいとは異なる ETag が割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="911c7-219">If the resource content at that URL ever changes, a new and different ETag is assigned.</span></span>| 
| <span data-ttu-id="911c7-220">コンテンツ範囲</span><span class="sxs-lookup"><span data-stu-id="911c7-220">Content-Range</span></span>| <span data-ttu-id="911c7-221">これは、部分的なダウンロードでしたが、このヘッダーは、ダウンロードされたバイト数の範囲を指定します。</span><span class="sxs-lookup"><span data-stu-id="911c7-221">If this was a partial download, this header specifies the range of bytes downloaded.</span></span>| 
  
<a id="ID4EPEAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="911c7-222">応答本文</span><span class="sxs-lookup"><span data-stu-id="911c7-222">Response body</span></span>
<span data-ttu-id="911c7-223">呼び出しが成功した場合は、サービスは、ファイルの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="911c7-223">If the call is successful, the service will return the contents of the file.</span></span>  
<a id="ID4EYEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="911c7-224">関連項目</span><span class="sxs-lookup"><span data-stu-id="911c7-224">See also</span></span>
 
<a id="ID4E1EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="911c7-225">Parent</span><span class="sxs-lookup"><span data-stu-id="911c7-225">Parent</span></span>  

[<span data-ttu-id="911c7-226">/global/scids/{scid}/data/{pathAndFileName},{type}</span><span class="sxs-lookup"><span data-stu-id="911c7-226">/global/scids/{scid}/data/{pathAndFileName},{type}</span></span>](uri-globalscidssciddatapathandfilenametype.md)

  
<a id="ID4EGFAC"></a>

 
##### <a name="reference--titleblob-jsonjsonjson-titleblobmd"></a><span data-ttu-id="911c7-227">参照[TitleBlob (JSON)](../../json/json-titleblob.md)</span><span class="sxs-lookup"><span data-stu-id="911c7-227">Reference  [TitleBlob (JSON)](../../json/json-titleblob.md)</span></span>

   