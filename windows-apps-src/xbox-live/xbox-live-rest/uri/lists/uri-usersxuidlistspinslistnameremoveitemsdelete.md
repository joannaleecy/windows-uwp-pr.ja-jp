---
title: DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
assetID: ad049340-f752-e05e-8b34-62adb8e4771f
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameremoveitemsdelete.html
author: KevinAsgari
description: " DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d400e54ae2ac1651fde1997734c18764b1ea03db
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6250086"
---
# <a name="delete-usersxuidxuidlistspinslistnameremoveitems"></a><span data-ttu-id="688b2-104">DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span><span class="sxs-lookup"><span data-stu-id="688b2-104">DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span></span>
<span data-ttu-id="688b2-105">インデックスを使用して、一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="688b2-105">Removes items from a list by index.</span></span> <span data-ttu-id="688b2-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="688b2-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="688b2-107">注釈</span><span class="sxs-lookup"><span data-stu-id="688b2-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="688b2-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="688b2-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="688b2-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="688b2-109">Query string parameters</span></span>](#ID4ELC)
  * [<span data-ttu-id="688b2-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="688b2-110">Request body</span></span>](#ID4END)
  * [<span data-ttu-id="688b2-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="688b2-111">HTTP status codes</span></span>](#ID4EYD)
  * [<span data-ttu-id="688b2-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="688b2-112">Required Request Headers</span></span>](#ID4EOBAC)
  * [<span data-ttu-id="688b2-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="688b2-113">Response body</span></span>](#ID4EEDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="688b2-114">注釈</span><span class="sxs-lookup"><span data-stu-id="688b2-114">Remarks</span></span> 
 
<span data-ttu-id="688b2-115">リストから項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="688b2-115">Remove items from a list.</span></span> <span data-ttu-id="688b2-116">削除する項目は、返される一覧内のインデックスとクエリ文字列パラメーター「インデックス」で示されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-116">Items to be removed are indicated by their index in the list and are identified in the query string parameter "indexes".</span></span> <span data-ttu-id="688b2-117">インデックスのリストはコンマで区切られたである必要があります、1 回の呼び出しは 100 のインデックスを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="688b2-117">The list of indexes must be comma delimited and only 100 indexes can be passed in a single call.</span></span> <span data-ttu-id="688b2-118">ただし、インデックスが (空のクエリ文字列パラメーター) を渡されていない場合、リストの内容全体が削除されます (一覧が保持されますが、空のバージョン番号は引き続き増分)。</span><span class="sxs-lookup"><span data-stu-id="688b2-118">However, if no indexes are passed (empty query string parameter) then the contents entire list will be deleted (list will remain but empty, version number will continue to increment).</span></span> <span data-ttu-id="688b2-119">項目が削除されると、リストが「キーを押してコンパクト」インデックスの順序で穴が残っていないようにします。</span><span class="sxs-lookup"><span data-stu-id="688b2-119">Once the items are removed, the list is "compacted" such that no holes are left in the ordering of indexes.</span></span> 
 
<span data-ttu-id="688b2-120">この呼び出しが必要とする"場合-マッチ: versionNumber"versionNumber がファイルの現在のバージョン番号は、要求に含まれるヘッダー。</span><span class="sxs-lookup"><span data-stu-id="688b2-120">This call requires an "If-Match:versionNumber" header to be included in the request, where versionNumber is the current version number of the file.</span></span> <span data-ttu-id="688b2-121">それが、含まれていないか、現在に一致しない場合は、一覧のバージョン番号、http/412 – の前提条件が失敗した状態コードが返され、応答の本文には、現在のバージョン番号が含まれている一覧の最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="688b2-121">If it is not included, or does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="688b2-122">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐためです。</span><span class="sxs-lookup"><span data-stu-id="688b2-122">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="688b2-123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="688b2-123">URI parameters</span></span> 
 
| <span data-ttu-id="688b2-124">パラメーター</span><span class="sxs-lookup"><span data-stu-id="688b2-124">Parameter</span></span>| <span data-ttu-id="688b2-125">型</span><span class="sxs-lookup"><span data-stu-id="688b2-125">Type</span></span>| <span data-ttu-id="688b2-126">説明</span><span class="sxs-lookup"><span data-stu-id="688b2-126">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="688b2-127">XUID</span><span class="sxs-lookup"><span data-stu-id="688b2-127">XUID</span></span>| <span data-ttu-id="688b2-128">string</span><span class="sxs-lookup"><span data-stu-id="688b2-128">string</span></span>| <span data-ttu-id="688b2-129">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="688b2-129">XUID of the user.</span></span>| 
| <span data-ttu-id="688b2-130">リスト</span><span class="sxs-lookup"><span data-stu-id="688b2-130">listname</span></span>| <span data-ttu-id="688b2-131">string</span><span class="sxs-lookup"><span data-stu-id="688b2-131">string</span></span>| <span data-ttu-id="688b2-132">操作をするリストの名前。</span><span class="sxs-lookup"><span data-stu-id="688b2-132">Name of the list to manipulate.</span></span>| 
  
<a id="ID4ELC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="688b2-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="688b2-133">Query string parameters</span></span> 
 
| <span data-ttu-id="688b2-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="688b2-134">Parameter</span></span>| <span data-ttu-id="688b2-135">型</span><span class="sxs-lookup"><span data-stu-id="688b2-135">Type</span></span>| <span data-ttu-id="688b2-136">説明</span><span class="sxs-lookup"><span data-stu-id="688b2-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="688b2-137">インデックス</span><span class="sxs-lookup"><span data-stu-id="688b2-137">indexes</span></span>| <span data-ttu-id="688b2-138">string</span><span class="sxs-lookup"><span data-stu-id="688b2-138">string</span></span>| <span data-ttu-id="688b2-139">0 または正の整数です。</span><span class="sxs-lookup"><span data-stu-id="688b2-139">Zero or a positive integer.</span></span> <span data-ttu-id="688b2-140">数値は、連続する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="688b2-140">The numbers do not have to be contiguous.</span></span> <span data-ttu-id="688b2-141">たとえば、クエリ パラメーター インデックス = 1、8 インデックス 1 と 8 項目が削除されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-141">For example, the query parameter indexes=1,8 will remove the items at indexes 1 and 8.</span></span> <b><span data-ttu-id="688b2-142">インデックスが指定されていない場合は、一覧全体が削除されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-142">If no index is specified, the entire list is deleted.</span></span></b>| 
  
<a id="ID4END"></a>

 
## <a name="request-body"></a><span data-ttu-id="688b2-143">要求本文</span><span class="sxs-lookup"><span data-stu-id="688b2-143">Request body</span></span> 
 
<span data-ttu-id="688b2-144">要求本文は、この呼び出しは空である必要があります。</span><span class="sxs-lookup"><span data-stu-id="688b2-144">The request body must be empty for this call.</span></span>
  
<a id="ID4EYD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="688b2-145">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="688b2-145">HTTP status codes</span></span> 
 
<span data-ttu-id="688b2-146">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="688b2-146">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="688b2-147">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="688b2-147">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="688b2-148">コード</span><span class="sxs-lookup"><span data-stu-id="688b2-148">Code</span></span>| <span data-ttu-id="688b2-149">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="688b2-149">Reason phrase</span></span>| <span data-ttu-id="688b2-150">説明</span><span class="sxs-lookup"><span data-stu-id="688b2-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="688b2-151">200</span><span class="sxs-lookup"><span data-stu-id="688b2-151">200</span></span>| <span data-ttu-id="688b2-152">OK</span><span class="sxs-lookup"><span data-stu-id="688b2-152">OK</span></span> | <span data-ttu-id="688b2-153">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="688b2-153">The request completed successfully.</span></span> <span data-ttu-id="688b2-154">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="688b2-154">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="688b2-155">POST、PUT 要求は、最新の状態の一覧のメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-155">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="688b2-156">201</span><span class="sxs-lookup"><span data-stu-id="688b2-156">201</span></span>| <span data-ttu-id="688b2-157">Created</span><span class="sxs-lookup"><span data-stu-id="688b2-157">Created</span></span> | <span data-ttu-id="688b2-158">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="688b2-158">A new list has been created.</span></span> <span data-ttu-id="688b2-159">これは初期の挿入の一覧に返されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-159">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="688b2-160">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="688b2-160">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="688b2-161">304</span><span class="sxs-lookup"><span data-stu-id="688b2-161">304</span></span>| <span data-ttu-id="688b2-162">Not Modified</span><span class="sxs-lookup"><span data-stu-id="688b2-162">Not Modified</span></span>| <span data-ttu-id="688b2-163">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-163">Returned on GETs.</span></span> <span data-ttu-id="688b2-164">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="688b2-164">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="688b2-165">サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="688b2-165">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="688b2-166">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-166">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="688b2-167">400</span><span class="sxs-lookup"><span data-stu-id="688b2-167">400</span></span>| <span data-ttu-id="688b2-168">Bad Request</span><span class="sxs-lookup"><span data-stu-id="688b2-168">Bad Request</span></span> | <span data-ttu-id="688b2-169">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="688b2-169">The request was malformed.</span></span> <span data-ttu-id="688b2-170">無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="688b2-170">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="688b2-171">不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-171">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="688b2-172"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="688b2-172">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="688b2-173">401</span><span class="sxs-lookup"><span data-stu-id="688b2-173">401</span></span>| <span data-ttu-id="688b2-174">権限がありません</span><span class="sxs-lookup"><span data-stu-id="688b2-174">Unauthorized</span></span> | <span data-ttu-id="688b2-175">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="688b2-175">The request requires user authentication.</span></span>| 
| <span data-ttu-id="688b2-176">403</span><span class="sxs-lookup"><span data-stu-id="688b2-176">403</span></span>| <span data-ttu-id="688b2-177">Forbidden</span><span class="sxs-lookup"><span data-stu-id="688b2-177">Forbidden</span></span> | <span data-ttu-id="688b2-178">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="688b2-178">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="688b2-179">404</span><span class="sxs-lookup"><span data-stu-id="688b2-179">404</span></span>| <span data-ttu-id="688b2-180">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="688b2-180">Not Found</span></span> | <span data-ttu-id="688b2-181">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="688b2-181">The caller does not have access to the resource.</span></span> <span data-ttu-id="688b2-182">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="688b2-182">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="688b2-183">412</span><span class="sxs-lookup"><span data-stu-id="688b2-183">412</span></span>| <span data-ttu-id="688b2-184">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="688b2-184">Precondition Failed</span></span> | <span data-ttu-id="688b2-185">一覧のバージョンが変更されていて、変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="688b2-185">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="688b2-186">変更要求は、挿入、更新、または削除されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-186">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="688b2-187">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="688b2-187">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="688b2-188">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-188">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="688b2-189">500</span><span class="sxs-lookup"><span data-stu-id="688b2-189">500</span></span>| <span data-ttu-id="688b2-190">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="688b2-190">Internal Server Error</span></span> | <span data-ttu-id="688b2-191">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="688b2-191">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="688b2-192">501</span><span class="sxs-lookup"><span data-stu-id="688b2-192">501</span></span>| <span data-ttu-id="688b2-193">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="688b2-193">Not Implemented</span></span> | <span data-ttu-id="688b2-194">呼び出し元が要求 URI では、サーバーで実装されていません。</span><span class="sxs-lookup"><span data-stu-id="688b2-194">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="688b2-195">(現在だけの場合、要求の対象となるがホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="688b2-195">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="688b2-196">503</span><span class="sxs-lookup"><span data-stu-id="688b2-196">503</span></span>| <span data-ttu-id="688b2-197">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="688b2-197">Service Unavailable</span></span> | <span data-ttu-id="688b2-198">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="688b2-198">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="688b2-199">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="688b2-199">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4EOBAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="688b2-200">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="688b2-200">Required Request Headers</span></span>
 
| <span data-ttu-id="688b2-201">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="688b2-201">Header</span></span>| <span data-ttu-id="688b2-202">説明</span><span class="sxs-lookup"><span data-stu-id="688b2-202">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="688b2-203">Authorization</span><span class="sxs-lookup"><span data-stu-id="688b2-203">Authorization</span></span>| <span data-ttu-id="688b2-204">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="688b2-204">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="688b2-205">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="688b2-205">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="688b2-206">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="688b2-206">X-XBL-Contract-Version</span></span>| <span data-ttu-id="688b2-207">要求された (正の整数) をされている API のバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="688b2-207">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="688b2-208">バージョン 2 のサポートのピン留めします。</span><span class="sxs-lookup"><span data-stu-id="688b2-208">Pins supports version 2.</span></span> <span data-ttu-id="688b2-209">このヘッダーが存在しないか、サービスは、400 – を返す、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="688b2-209">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span> | 
| <span data-ttu-id="688b2-210">Content-Type</span><span class="sxs-lookup"><span data-stu-id="688b2-210">Content-Type</span></span>| <span data-ttu-id="688b2-211">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="688b2-211">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="688b2-212">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="688b2-212">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="688b2-213">If-Match</span><span class="sxs-lookup"><span data-stu-id="688b2-213">If-Match</span></span>| <span data-ttu-id="688b2-214">このヘッダーは、変更要求を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="688b2-214">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="688b2-215">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="688b2-215">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="688b2-216">"If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="688b2-216">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="688b2-217">(省略可能)また場合に使用できますの取得、現在およびで渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="688b2-217">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EEDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="688b2-218">応答本文</span><span class="sxs-lookup"><span data-stu-id="688b2-218">Response body</span></span> 
 
<span data-ttu-id="688b2-219">呼び出しが成功した場合は、サービスは、一覧の最新のメタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="688b2-219">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4EODAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="688b2-220">応答の例</span><span class="sxs-lookup"><span data-stu-id="688b2-220">Sample response</span></span> 
 

```cpp
{
        "ListVersion":  1,
        "ListCount":  1,
        "MaxListSize": 200,
        "AllowDuplicates": "true",
        "AccessSetting":  "OwnerOnly"
        }

      
```

   
<a id="ID4E1DAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="688b2-221">関連項目</span><span class="sxs-lookup"><span data-stu-id="688b2-221">See also</span></span>
 
<a id="ID4E3DAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="688b2-222">Parent</span><span class="sxs-lookup"><span data-stu-id="688b2-222">Parent</span></span> 

[<span data-ttu-id="688b2-223">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="688b2-223">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   