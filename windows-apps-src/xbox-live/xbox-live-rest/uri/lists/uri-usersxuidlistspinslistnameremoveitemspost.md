---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
assetID: f7235c68-3214-db10-52ad-c3665b31b8cd
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameremoveitemspost.html
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5e62d978e94286c815f2274c56684e4fd6bbf2d6
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57637297"
---
# <a name="post-usersxuidxuidlistspinslistnameremoveitems"></a><span data-ttu-id="92270-104">POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span><span class="sxs-lookup"><span data-stu-id="92270-104">POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span></span>
<span data-ttu-id="92270-105">アイテム Id で、一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="92270-105">Removes items from a list by itemId.</span></span> <span data-ttu-id="92270-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="92270-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="92270-107">注釈</span><span class="sxs-lookup"><span data-stu-id="92270-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="92270-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92270-108">URI parameters</span></span>](#ID4EFB)
  * [<span data-ttu-id="92270-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="92270-109">Query string parameters</span></span>](#ID4EOC)
  * [<span data-ttu-id="92270-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="92270-110">Request body</span></span>](#ID4EZC)
  * [<span data-ttu-id="92270-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="92270-111">HTTP status codes</span></span>](#ID4EED)
  * [<span data-ttu-id="92270-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="92270-112">Required Request Headers</span></span>](#ID4E1AAC)
  * [<span data-ttu-id="92270-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="92270-113">Response body</span></span>](#ID4EQCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="92270-114">注釈</span><span class="sxs-lookup"><span data-stu-id="92270-114">Remarks</span></span> 
 
<span data-ttu-id="92270-115">インデックスではなく項目 id を指定することで、一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="92270-115">Remove items from the list by specifying item ids instead of indexes.</span></span> <span data-ttu-id="92270-116">1 回の呼び出しで削除する項目を 100 件のみが許可されている**項目が渡されないかどうかは、リスト全体が削除されます (リストに残りますが、空の場合、バージョン番号はインクリメントする続行するが)。**</span><span class="sxs-lookup"><span data-stu-id="92270-116">Only 100 items are allowed to be removed in a single call **If no items are passed then the entire list will be deleted (list will remain but empty, version number will continue to increment).**</span></span> <span data-ttu-id="92270-117">項目が削除されると、リストは「圧縮」インデックスの順序に穴が残っていないようにします。</span><span class="sxs-lookup"><span data-stu-id="92270-117">Once the items are removed, the list is "compacted" such that no holes are left in the ordering of indexes.</span></span> 
 
<span data-ttu-id="92270-118">"場合に一致: versionNumber"ヘッダーはこの呼び出しの省略可能です。</span><span class="sxs-lookup"><span data-stu-id="92270-118">An "If-Match:versionNumber" header is optional for this call.</span></span> <span data-ttu-id="92270-119">含まれる場合が検証されます。</span><span class="sxs-lookup"><span data-stu-id="92270-119">If it is included it will be validated.</span></span> <span data-ttu-id="92270-120">次のメッセージは、ファイルの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="92270-120">The versionNumber is the current version number of the file.</span></span> <span data-ttu-id="92270-121">含まれ、現在と一致しませんリストのバージョン番号、HTTP 412 – precondition 失敗のステータス コードが返され、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="92270-121">If it is included and does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="92270-122">これは相互に踏み潰すさまざまなクライアントからの更新プログラムから保護するためです。</span><span class="sxs-lookup"><span data-stu-id="92270-122">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4EFB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="92270-123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="92270-123">URI parameters</span></span> 
 
| <span data-ttu-id="92270-124">パラメーター</span><span class="sxs-lookup"><span data-stu-id="92270-124">Parameter</span></span>| <span data-ttu-id="92270-125">種類</span><span class="sxs-lookup"><span data-stu-id="92270-125">Type</span></span>| <span data-ttu-id="92270-126">説明</span><span class="sxs-lookup"><span data-stu-id="92270-126">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="92270-127">XUID</span><span class="sxs-lookup"><span data-stu-id="92270-127">XUID</span></span>| <span data-ttu-id="92270-128">string</span><span class="sxs-lookup"><span data-stu-id="92270-128">string</span></span>| <span data-ttu-id="92270-129">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="92270-129">XUID of the user.</span></span>| 
| <span data-ttu-id="92270-130">listname</span><span class="sxs-lookup"><span data-stu-id="92270-130">listname</span></span>| <span data-ttu-id="92270-131">string</span><span class="sxs-lookup"><span data-stu-id="92270-131">string</span></span>| <span data-ttu-id="92270-132">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="92270-132">Name of the list to manipulate.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="92270-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="92270-133">Query string parameters</span></span> 
 
<span data-ttu-id="92270-134">クエリ パラメーターがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="92270-134">Query parameters are not supported.</span></span>
  
<a id="ID4EZC"></a>

 
## <a name="request-body"></a><span data-ttu-id="92270-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="92270-135">Request body</span></span> 
 

```cpp
{
   "Items":
   [{"ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
      "ProviderId":  null,
      "Provider":  null
   }]
}

    
```

  
<a id="ID4EED"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="92270-136">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="92270-136">HTTP status codes</span></span> 
 
<span data-ttu-id="92270-137">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="92270-137">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="92270-138">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="92270-138">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="92270-139">コード</span><span class="sxs-lookup"><span data-stu-id="92270-139">Code</span></span>| <span data-ttu-id="92270-140">理由語句</span><span class="sxs-lookup"><span data-stu-id="92270-140">Reason phrase</span></span>| <span data-ttu-id="92270-141">説明</span><span class="sxs-lookup"><span data-stu-id="92270-141">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="92270-142">200</span><span class="sxs-lookup"><span data-stu-id="92270-142">200</span></span>| <span data-ttu-id="92270-143">OK</span><span class="sxs-lookup"><span data-stu-id="92270-143">OK</span></span> | <span data-ttu-id="92270-144">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="92270-144">The request completed successfully.</span></span> <span data-ttu-id="92270-145">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="92270-145">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="92270-146">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="92270-146">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="92270-147">201</span><span class="sxs-lookup"><span data-stu-id="92270-147">201</span></span>| <span data-ttu-id="92270-148">作成日</span><span class="sxs-lookup"><span data-stu-id="92270-148">Created</span></span> | <span data-ttu-id="92270-149">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="92270-149">A new list has been created.</span></span> <span data-ttu-id="92270-150">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="92270-150">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="92270-151">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="92270-151">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="92270-152">304</span><span class="sxs-lookup"><span data-stu-id="92270-152">304</span></span>| <span data-ttu-id="92270-153">変更されていません</span><span class="sxs-lookup"><span data-stu-id="92270-153">Not Modified</span></span>| <span data-ttu-id="92270-154">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="92270-154">Returned on GETs.</span></span> <span data-ttu-id="92270-155">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="92270-155">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="92270-156">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="92270-156">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="92270-157">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="92270-157">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="92270-158">400</span><span class="sxs-lookup"><span data-stu-id="92270-158">400</span></span>| <span data-ttu-id="92270-159">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="92270-159">Bad Request</span></span> | <span data-ttu-id="92270-160">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="92270-160">The request was malformed.</span></span> <span data-ttu-id="92270-161">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="92270-161">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="92270-162">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="92270-162">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="92270-163">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="92270-163">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="92270-164">401</span><span class="sxs-lookup"><span data-stu-id="92270-164">401</span></span>| <span data-ttu-id="92270-165">権限がありません</span><span class="sxs-lookup"><span data-stu-id="92270-165">Unauthorized</span></span> | <span data-ttu-id="92270-166">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="92270-166">The request requires user authentication.</span></span>| 
| <span data-ttu-id="92270-167">403</span><span class="sxs-lookup"><span data-stu-id="92270-167">403</span></span>| <span data-ttu-id="92270-168">Forbidden</span><span class="sxs-lookup"><span data-stu-id="92270-168">Forbidden</span></span> | <span data-ttu-id="92270-169">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="92270-169">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="92270-170">404</span><span class="sxs-lookup"><span data-stu-id="92270-170">404</span></span>| <span data-ttu-id="92270-171">検出不可</span><span class="sxs-lookup"><span data-stu-id="92270-171">Not Found</span></span> | <span data-ttu-id="92270-172">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="92270-172">The caller does not have access to the resource.</span></span> <span data-ttu-id="92270-173">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="92270-173">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="92270-174">412</span><span class="sxs-lookup"><span data-stu-id="92270-174">412</span></span>| <span data-ttu-id="92270-175">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="92270-175">Precondition Failed</span></span> | <span data-ttu-id="92270-176">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="92270-176">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="92270-177">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="92270-177">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="92270-178">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="92270-178">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="92270-179">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="92270-179">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="92270-180">500</span><span class="sxs-lookup"><span data-stu-id="92270-180">500</span></span>| <span data-ttu-id="92270-181">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="92270-181">Internal Server Error</span></span> | <span data-ttu-id="92270-182">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="92270-182">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="92270-183">501</span><span class="sxs-lookup"><span data-stu-id="92270-183">501</span></span>| <span data-ttu-id="92270-184">実装されていません</span><span class="sxs-lookup"><span data-stu-id="92270-184">Not Implemented</span></span> | <span data-ttu-id="92270-185">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="92270-185">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="92270-186">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="92270-186">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="92270-187">503</span><span class="sxs-lookup"><span data-stu-id="92270-187">503</span></span>| <span data-ttu-id="92270-188">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="92270-188">Service Unavailable</span></span> | <span data-ttu-id="92270-189">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="92270-189">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="92270-190">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="92270-190">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4E1AAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="92270-191">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="92270-191">Required Request Headers</span></span>
 
| <span data-ttu-id="92270-192">Header</span><span class="sxs-lookup"><span data-stu-id="92270-192">Header</span></span>| <span data-ttu-id="92270-193">説明</span><span class="sxs-lookup"><span data-stu-id="92270-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="92270-194">Authorization</span><span class="sxs-lookup"><span data-stu-id="92270-194">Authorization</span></span>| <span data-ttu-id="92270-195">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="92270-195">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="92270-196">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="92270-196">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="92270-197">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="92270-197">X-XBL-Contract-Version</span></span>| <span data-ttu-id="92270-198">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="92270-198">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="92270-199">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="92270-199">Pins supports version 2.</span></span> <span data-ttu-id="92270-200">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="92270-200">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span> | 
| <span data-ttu-id="92270-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="92270-201">Content-Type</span></span>| <span data-ttu-id="92270-202">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="92270-202">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="92270-203">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="92270-203">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="92270-204">If-Match</span><span class="sxs-lookup"><span data-stu-id="92270-204">If-Match</span></span>| <span data-ttu-id="92270-205">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="92270-205">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="92270-206">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="92270-206">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="92270-207">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="92270-207">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="92270-208">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="92270-208">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EQCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="92270-209">応答本文</span><span class="sxs-lookup"><span data-stu-id="92270-209">Response body</span></span> 
 
<span data-ttu-id="92270-210">呼び出しが成功した場合、サービスは、最新の一覧については、メタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="92270-210">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4E1CAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="92270-211">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="92270-211">Sample response</span></span> 
 

```cpp
{
        "ListVersion":  1,
        "ListCount":  1,
        "MaxListSize": 200,
        "AllowDuplicates": "true",
        "AccessSetting":  "OwnerOnly"
        }

      
```

   
<a id="ID4EGDAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="92270-212">関連項目</span><span class="sxs-lookup"><span data-stu-id="92270-212">See also</span></span>
 
<a id="ID4EIDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="92270-213">Parent</span><span class="sxs-lookup"><span data-stu-id="92270-213">Parent</span></span> 

[<span data-ttu-id="92270-214">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="92270-214">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   