---
title: DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
assetID: ad049340-f752-e05e-8b34-62adb8e4771f
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameremoveitemsdelete.html
description: " DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d26d8eaf54dcc14de3e31d7c2b54cd4454f2029f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57594097"
---
# <a name="delete-usersxuidxuidlistspinslistnameremoveitems"></a><span data-ttu-id="e14f1-104">DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span><span class="sxs-lookup"><span data-stu-id="e14f1-104">DELETE /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span></span>
<span data-ttu-id="e14f1-105">インデックスを使用して、一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-105">Removes items from a list by index.</span></span> <span data-ttu-id="e14f1-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="e14f1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="e14f1-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="e14f1-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e14f1-108">URI parameters</span></span>](#ID4ECB)
  * [<span data-ttu-id="e14f1-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e14f1-109">Query string parameters</span></span>](#ID4ELC)
  * [<span data-ttu-id="e14f1-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="e14f1-110">Request body</span></span>](#ID4END)
  * [<span data-ttu-id="e14f1-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e14f1-111">HTTP status codes</span></span>](#ID4EYD)
  * [<span data-ttu-id="e14f1-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e14f1-112">Required Request Headers</span></span>](#ID4EOBAC)
  * [<span data-ttu-id="e14f1-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="e14f1-113">Response body</span></span>](#ID4EEDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="e14f1-114">注釈</span><span class="sxs-lookup"><span data-stu-id="e14f1-114">Remarks</span></span> 
 
<span data-ttu-id="e14f1-115">一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-115">Remove items from a list.</span></span> <span data-ttu-id="e14f1-116">削除する項目はリスト内のインデックスで示されますされ、「インデックス」クエリ文字列パラメーターで識別されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-116">Items to be removed are indicated by their index in the list and are identified in the query string parameter "indexes".</span></span> <span data-ttu-id="e14f1-117">インデックスの一覧がコンマ区切りにする必要があり、100 件のみインデックスを 1 回の呼び出しで渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-117">The list of indexes must be comma delimited and only 100 indexes can be passed in a single call.</span></span> <span data-ttu-id="e14f1-118">ただし、インデックスに (空のクエリ文字列パラメーター) が渡されない場合、リスト全体の内容は削除されます (リストに残りますが、空の場合、バージョン番号はインクリメントする続行するが)。</span><span class="sxs-lookup"><span data-stu-id="e14f1-118">However, if no indexes are passed (empty query string parameter) then the contents entire list will be deleted (list will remain but empty, version number will continue to increment).</span></span> <span data-ttu-id="e14f1-119">項目が削除されると、リストは「圧縮」インデックスの順序に穴が残っていないようにします。</span><span class="sxs-lookup"><span data-stu-id="e14f1-119">Once the items are removed, the list is "compacted" such that no holes are left in the ordering of indexes.</span></span> 
 
<span data-ttu-id="e14f1-120">この呼び出しが必要です、"場合に一致: versionNumber"versionNumber がファイルの現在のバージョン番号は、要求に含まれるヘッダー。</span><span class="sxs-lookup"><span data-stu-id="e14f1-120">This call requires an "If-Match:versionNumber" header to be included in the request, where versionNumber is the current version number of the file.</span></span> <span data-ttu-id="e14f1-121">現在と一致しませんが、含まれていない場合リストのバージョン番号、HTTP 412 – precondition 失敗のステータス コードが返され、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-121">If it is not included, or does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="e14f1-122">これは相互に踏み潰すさまざまなクライアントからの更新プログラムから保護するためです。</span><span class="sxs-lookup"><span data-stu-id="e14f1-122">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4ECB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="e14f1-123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="e14f1-123">URI parameters</span></span> 
 
| <span data-ttu-id="e14f1-124">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e14f1-124">Parameter</span></span>| <span data-ttu-id="e14f1-125">種類</span><span class="sxs-lookup"><span data-stu-id="e14f1-125">Type</span></span>| <span data-ttu-id="e14f1-126">説明</span><span class="sxs-lookup"><span data-stu-id="e14f1-126">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e14f1-127">XUID</span><span class="sxs-lookup"><span data-stu-id="e14f1-127">XUID</span></span>| <span data-ttu-id="e14f1-128">string</span><span class="sxs-lookup"><span data-stu-id="e14f1-128">string</span></span>| <span data-ttu-id="e14f1-129">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="e14f1-129">XUID of the user.</span></span>| 
| <span data-ttu-id="e14f1-130">listname</span><span class="sxs-lookup"><span data-stu-id="e14f1-130">listname</span></span>| <span data-ttu-id="e14f1-131">string</span><span class="sxs-lookup"><span data-stu-id="e14f1-131">string</span></span>| <span data-ttu-id="e14f1-132">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="e14f1-132">Name of the list to manipulate.</span></span>| 
  
<a id="ID4ELC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="e14f1-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="e14f1-133">Query string parameters</span></span> 
 
| <span data-ttu-id="e14f1-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="e14f1-134">Parameter</span></span>| <span data-ttu-id="e14f1-135">種類</span><span class="sxs-lookup"><span data-stu-id="e14f1-135">Type</span></span>| <span data-ttu-id="e14f1-136">説明</span><span class="sxs-lookup"><span data-stu-id="e14f1-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e14f1-137">インデックス</span><span class="sxs-lookup"><span data-stu-id="e14f1-137">indexes</span></span>| <span data-ttu-id="e14f1-138">string</span><span class="sxs-lookup"><span data-stu-id="e14f1-138">string</span></span>| <span data-ttu-id="e14f1-139">0 または正の整数。</span><span class="sxs-lookup"><span data-stu-id="e14f1-139">Zero or a positive integer.</span></span> <span data-ttu-id="e14f1-140">連続する数値がありませんでした。</span><span class="sxs-lookup"><span data-stu-id="e14f1-140">The numbers do not have to be contiguous.</span></span> <span data-ttu-id="e14f1-141">クエリ パラメーターのインデックスなど、1 = 8 1 から 8 のインデックスで項目が削除されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-141">For example, the query parameter indexes=1,8 will remove the items at indexes 1 and 8.</span></span> <span data-ttu-id="e14f1-142"><b>インデックスが指定されていない場合は、リスト全体が削除されます。</b></span><span class="sxs-lookup"><span data-stu-id="e14f1-142"><b>If no index is specified, the entire list is deleted.</b></span></span>| 
  
<a id="ID4END"></a>

 
## <a name="request-body"></a><span data-ttu-id="e14f1-143">要求本文</span><span class="sxs-lookup"><span data-stu-id="e14f1-143">Request body</span></span> 
 
<span data-ttu-id="e14f1-144">要求本文は、この呼び出しを空にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="e14f1-144">The request body must be empty for this call.</span></span>
  
<a id="ID4EYD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="e14f1-145">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="e14f1-145">HTTP status codes</span></span> 
 
<span data-ttu-id="e14f1-146">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-146">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="e14f1-147">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-147">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="e14f1-148">コード</span><span class="sxs-lookup"><span data-stu-id="e14f1-148">Code</span></span>| <span data-ttu-id="e14f1-149">理由語句</span><span class="sxs-lookup"><span data-stu-id="e14f1-149">Reason phrase</span></span>| <span data-ttu-id="e14f1-150">説明</span><span class="sxs-lookup"><span data-stu-id="e14f1-150">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e14f1-151">200</span><span class="sxs-lookup"><span data-stu-id="e14f1-151">200</span></span>| <span data-ttu-id="e14f1-152">OK</span><span class="sxs-lookup"><span data-stu-id="e14f1-152">OK</span></span> | <span data-ttu-id="e14f1-153">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="e14f1-153">The request completed successfully.</span></span> <span data-ttu-id="e14f1-154">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e14f1-154">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="e14f1-155">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-155">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="e14f1-156">201</span><span class="sxs-lookup"><span data-stu-id="e14f1-156">201</span></span>| <span data-ttu-id="e14f1-157">作成日</span><span class="sxs-lookup"><span data-stu-id="e14f1-157">Created</span></span> | <span data-ttu-id="e14f1-158">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="e14f1-158">A new list has been created.</span></span> <span data-ttu-id="e14f1-159">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-159">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="e14f1-160">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="e14f1-160">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="e14f1-161">304</span><span class="sxs-lookup"><span data-stu-id="e14f1-161">304</span></span>| <span data-ttu-id="e14f1-162">変更されていません</span><span class="sxs-lookup"><span data-stu-id="e14f1-162">Not Modified</span></span>| <span data-ttu-id="e14f1-163">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-163">Returned on GETs.</span></span> <span data-ttu-id="e14f1-164">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-164">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="e14f1-165">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="e14f1-165">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="e14f1-166">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-166">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="e14f1-167">400</span><span class="sxs-lookup"><span data-stu-id="e14f1-167">400</span></span>| <span data-ttu-id="e14f1-168">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="e14f1-168">Bad Request</span></span> | <span data-ttu-id="e14f1-169">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="e14f1-169">The request was malformed.</span></span> <span data-ttu-id="e14f1-170">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="e14f1-170">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="e14f1-171">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-171">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="e14f1-172">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="e14f1-172">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="e14f1-173">401</span><span class="sxs-lookup"><span data-stu-id="e14f1-173">401</span></span>| <span data-ttu-id="e14f1-174">権限がありません</span><span class="sxs-lookup"><span data-stu-id="e14f1-174">Unauthorized</span></span> | <span data-ttu-id="e14f1-175">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="e14f1-175">The request requires user authentication.</span></span>| 
| <span data-ttu-id="e14f1-176">403</span><span class="sxs-lookup"><span data-stu-id="e14f1-176">403</span></span>| <span data-ttu-id="e14f1-177">Forbidden</span><span class="sxs-lookup"><span data-stu-id="e14f1-177">Forbidden</span></span> | <span data-ttu-id="e14f1-178">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="e14f1-178">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="e14f1-179">404</span><span class="sxs-lookup"><span data-stu-id="e14f1-179">404</span></span>| <span data-ttu-id="e14f1-180">検出不可</span><span class="sxs-lookup"><span data-stu-id="e14f1-180">Not Found</span></span> | <span data-ttu-id="e14f1-181">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="e14f1-181">The caller does not have access to the resource.</span></span> <span data-ttu-id="e14f1-182">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-182">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="e14f1-183">412</span><span class="sxs-lookup"><span data-stu-id="e14f1-183">412</span></span>| <span data-ttu-id="e14f1-184">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="e14f1-184">Precondition Failed</span></span> | <span data-ttu-id="e14f1-185">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-185">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="e14f1-186">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-186">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="e14f1-187">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-187">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="e14f1-188">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-188">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="e14f1-189">500</span><span class="sxs-lookup"><span data-stu-id="e14f1-189">500</span></span>| <span data-ttu-id="e14f1-190">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="e14f1-190">Internal Server Error</span></span> | <span data-ttu-id="e14f1-191">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="e14f1-191">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="e14f1-192">501</span><span class="sxs-lookup"><span data-stu-id="e14f1-192">501</span></span>| <span data-ttu-id="e14f1-193">実装されていません</span><span class="sxs-lookup"><span data-stu-id="e14f1-193">Not Implemented</span></span> | <span data-ttu-id="e14f1-194">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="e14f1-194">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="e14f1-195">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="e14f1-195">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="e14f1-196">503</span><span class="sxs-lookup"><span data-stu-id="e14f1-196">503</span></span>| <span data-ttu-id="e14f1-197">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="e14f1-197">Service Unavailable</span></span> | <span data-ttu-id="e14f1-198">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="e14f1-198">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="e14f1-199">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-199">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4EOBAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="e14f1-200">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="e14f1-200">Required Request Headers</span></span>
 
| <span data-ttu-id="e14f1-201">Header</span><span class="sxs-lookup"><span data-stu-id="e14f1-201">Header</span></span>| <span data-ttu-id="e14f1-202">説明</span><span class="sxs-lookup"><span data-stu-id="e14f1-202">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="e14f1-203">Authorization</span><span class="sxs-lookup"><span data-stu-id="e14f1-203">Authorization</span></span>| <span data-ttu-id="e14f1-204">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e14f1-204">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="e14f1-205">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-205">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="e14f1-206">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="e14f1-206">X-XBL-Contract-Version</span></span>| <span data-ttu-id="e14f1-207">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-207">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="e14f1-208">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="e14f1-208">Pins supports version 2.</span></span> <span data-ttu-id="e14f1-209">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-209">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span> | 
| <span data-ttu-id="e14f1-210">Content-Type</span><span class="sxs-lookup"><span data-stu-id="e14f1-210">Content-Type</span></span>| <span data-ttu-id="e14f1-211">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-211">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="e14f1-212">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="e14f1-212">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="e14f1-213">If-Match</span><span class="sxs-lookup"><span data-stu-id="e14f1-213">If-Match</span></span>| <span data-ttu-id="e14f1-214">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="e14f1-214">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="e14f1-215">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="e14f1-215">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="e14f1-216">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="e14f1-216">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="e14f1-217">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="e14f1-217">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EEDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="e14f1-218">応答本文</span><span class="sxs-lookup"><span data-stu-id="e14f1-218">Response body</span></span> 
 
<span data-ttu-id="e14f1-219">呼び出しが成功した場合、サービスは、最新の一覧については、メタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="e14f1-219">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4EODAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="e14f1-220">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="e14f1-220">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="e14f1-221">関連項目</span><span class="sxs-lookup"><span data-stu-id="e14f1-221">See also</span></span>
 
<a id="ID4E3DAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e14f1-222">Parent</span><span class="sxs-lookup"><span data-stu-id="e14f1-222">Parent</span></span> 

[<span data-ttu-id="e14f1-223">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="e14f1-223">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   