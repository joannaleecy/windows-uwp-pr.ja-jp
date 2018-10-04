---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems
assetID: f7235c68-3214-db10-52ad-c3665b31b8cd
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameremoveitemspost.html
author: KevinAsgari
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dbccbad78dd49db0bd4d4110424a7c32216eff3d
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4355514"
---
# <a name="post-usersxuidxuidlistspinslistnameremoveitems"></a><span data-ttu-id="ebdca-104">POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span><span class="sxs-lookup"><span data-stu-id="ebdca-104">POST /users/xuid(xuid)/lists/PINS/{listname}/RemoveItems</span></span>
<span data-ttu-id="ebdca-105">ItemId によって、一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-105">Removes items from a list by itemId.</span></span> <span data-ttu-id="ebdca-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ebdca-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ebdca-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="ebdca-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebdca-108">URI parameters</span></span>](#ID4EFB)
  * [<span data-ttu-id="ebdca-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebdca-109">Query string parameters</span></span>](#ID4EOC)
  * [<span data-ttu-id="ebdca-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="ebdca-110">Request body</span></span>](#ID4EZC)
  * [<span data-ttu-id="ebdca-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ebdca-111">HTTP status codes</span></span>](#ID4EED)
  * [<span data-ttu-id="ebdca-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ebdca-112">Required Request Headers</span></span>](#ID4E1AAC)
  * [<span data-ttu-id="ebdca-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="ebdca-113">Response body</span></span>](#ID4EQCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="ebdca-114">注釈</span><span class="sxs-lookup"><span data-stu-id="ebdca-114">Remarks</span></span> 
 
<span data-ttu-id="ebdca-115">インデックスではなく項目 id を指定することで、リストから項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-115">Remove items from the list by specifying item ids instead of indexes.</span></span> <span data-ttu-id="ebdca-116">1 つの呼び出しで削除する項目が 100 個のみが許可されている**項目が渡されていないかどうかは、一覧全体が削除されます (リストが残りますが、空のバージョン番号は引き続きインクリメント).**</span><span class="sxs-lookup"><span data-stu-id="ebdca-116">Only 100 items are allowed to be removed in a single call **If no items are passed then the entire list will be deleted (list will remain but empty, version number will continue to increment).**</span></span> <span data-ttu-id="ebdca-117">項目が削除されると一覧が「キーを押してコンパクト」インデックスの順序で穴が残っていないようにします。</span><span class="sxs-lookup"><span data-stu-id="ebdca-117">Once the items are removed, the list is "compacted" such that no holes are left in the ordering of indexes.</span></span> 
 
<span data-ttu-id="ebdca-118">"場合-マッチ: versionNumber"ヘッダーはこの呼び出しの省略可能です。</span><span class="sxs-lookup"><span data-stu-id="ebdca-118">An "If-Match:versionNumber" header is optional for this call.</span></span> <span data-ttu-id="ebdca-119">それが含まれている場合は検証されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-119">If it is included it will be validated.</span></span> <span data-ttu-id="ebdca-120">次のメッセージでは、ファイルの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="ebdca-120">The versionNumber is the current version number of the file.</span></span> <span data-ttu-id="ebdca-121">含まれているし、現在と一致しない場合は一覧のバージョン番号、http/412 – の前提条件が失敗の状態コードが返され、応答の本文には、現在のバージョン番号が含まれている一覧の最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-121">If it is included and does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="ebdca-122">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐため。</span><span class="sxs-lookup"><span data-stu-id="ebdca-122">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4EFB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ebdca-123">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebdca-123">URI parameters</span></span> 
 
| <span data-ttu-id="ebdca-124">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebdca-124">Parameter</span></span>| <span data-ttu-id="ebdca-125">型</span><span class="sxs-lookup"><span data-stu-id="ebdca-125">Type</span></span>| <span data-ttu-id="ebdca-126">説明</span><span class="sxs-lookup"><span data-stu-id="ebdca-126">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ebdca-127">XUID</span><span class="sxs-lookup"><span data-stu-id="ebdca-127">XUID</span></span>| <span data-ttu-id="ebdca-128">string</span><span class="sxs-lookup"><span data-stu-id="ebdca-128">string</span></span>| <span data-ttu-id="ebdca-129">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="ebdca-129">XUID of the user.</span></span>| 
| <span data-ttu-id="ebdca-130">リスト</span><span class="sxs-lookup"><span data-stu-id="ebdca-130">listname</span></span>| <span data-ttu-id="ebdca-131">string</span><span class="sxs-lookup"><span data-stu-id="ebdca-131">string</span></span>| <span data-ttu-id="ebdca-132">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="ebdca-132">Name of the list to manipulate.</span></span>| 
  
<a id="ID4EOC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="ebdca-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="ebdca-133">Query string parameters</span></span> 
 
<span data-ttu-id="ebdca-134">クエリ パラメーターはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="ebdca-134">Query parameters are not supported.</span></span>
  
<a id="ID4EZC"></a>

 
## <a name="request-body"></a><span data-ttu-id="ebdca-135">要求本文</span><span class="sxs-lookup"><span data-stu-id="ebdca-135">Request body</span></span> 
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="ebdca-136">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ebdca-136">HTTP status codes</span></span> 
 
<span data-ttu-id="ebdca-137">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-137">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ebdca-138">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ebdca-138">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="ebdca-139">コード</span><span class="sxs-lookup"><span data-stu-id="ebdca-139">Code</span></span>| <span data-ttu-id="ebdca-140">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="ebdca-140">Reason phrase</span></span>| <span data-ttu-id="ebdca-141">説明</span><span class="sxs-lookup"><span data-stu-id="ebdca-141">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ebdca-142">200</span><span class="sxs-lookup"><span data-stu-id="ebdca-142">200</span></span>| <span data-ttu-id="ebdca-143">OK</span><span class="sxs-lookup"><span data-stu-id="ebdca-143">OK</span></span> | <span data-ttu-id="ebdca-144">要求が正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="ebdca-144">The request completed successfully.</span></span> <span data-ttu-id="ebdca-145">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebdca-145">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="ebdca-146">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-146">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="ebdca-147">201</span><span class="sxs-lookup"><span data-stu-id="ebdca-147">201</span></span>| <span data-ttu-id="ebdca-148">Created</span><span class="sxs-lookup"><span data-stu-id="ebdca-148">Created</span></span> | <span data-ttu-id="ebdca-149">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="ebdca-149">A new list has been created.</span></span> <span data-ttu-id="ebdca-150">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-150">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="ebdca-151">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ebdca-151">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="ebdca-152">304</span><span class="sxs-lookup"><span data-stu-id="ebdca-152">304</span></span>| <span data-ttu-id="ebdca-153">Not Modified</span><span class="sxs-lookup"><span data-stu-id="ebdca-153">Not Modified</span></span>| <span data-ttu-id="ebdca-154">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-154">Returned on GETs.</span></span> <span data-ttu-id="ebdca-155">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-155">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="ebdca-156">サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-156">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="ebdca-157">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-157">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="ebdca-158">400</span><span class="sxs-lookup"><span data-stu-id="ebdca-158">400</span></span>| <span data-ttu-id="ebdca-159">Bad Request</span><span class="sxs-lookup"><span data-stu-id="ebdca-159">Bad Request</span></span> | <span data-ttu-id="ebdca-160">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="ebdca-160">The request was malformed.</span></span> <span data-ttu-id="ebdca-161">無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-161">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="ebdca-162">不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-162">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="ebdca-163"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ebdca-163">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="ebdca-164">401</span><span class="sxs-lookup"><span data-stu-id="ebdca-164">401</span></span>| <span data-ttu-id="ebdca-165">権限がありません</span><span class="sxs-lookup"><span data-stu-id="ebdca-165">Unauthorized</span></span> | <span data-ttu-id="ebdca-166">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="ebdca-166">The request requires user authentication.</span></span>| 
| <span data-ttu-id="ebdca-167">403</span><span class="sxs-lookup"><span data-stu-id="ebdca-167">403</span></span>| <span data-ttu-id="ebdca-168">Forbidden</span><span class="sxs-lookup"><span data-stu-id="ebdca-168">Forbidden</span></span> | <span data-ttu-id="ebdca-169">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="ebdca-169">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="ebdca-170">404</span><span class="sxs-lookup"><span data-stu-id="ebdca-170">404</span></span>| <span data-ttu-id="ebdca-171">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-171">Not Found</span></span> | <span data-ttu-id="ebdca-172">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="ebdca-172">The caller does not have access to the resource.</span></span> <span data-ttu-id="ebdca-173">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-173">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="ebdca-174">412</span><span class="sxs-lookup"><span data-stu-id="ebdca-174">412</span></span>| <span data-ttu-id="ebdca-175">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="ebdca-175">Precondition Failed</span></span> | <span data-ttu-id="ebdca-176">一覧のバージョンが変更されていて、変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-176">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="ebdca-177">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-177">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="ebdca-178">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-178">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="ebdca-179">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-179">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="ebdca-180">500</span><span class="sxs-lookup"><span data-stu-id="ebdca-180">500</span></span>| <span data-ttu-id="ebdca-181">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="ebdca-181">Internal Server Error</span></span> | <span data-ttu-id="ebdca-182">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="ebdca-182">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="ebdca-183">501</span><span class="sxs-lookup"><span data-stu-id="ebdca-183">501</span></span>| <span data-ttu-id="ebdca-184">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="ebdca-184">Not Implemented</span></span> | <span data-ttu-id="ebdca-185">呼び出し元がサーバーに実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-185">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="ebdca-186">(現在のみを使用するとき、要求の対象となるがないホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="ebdca-186">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="ebdca-187">503</span><span class="sxs-lookup"><span data-stu-id="ebdca-187">503</span></span>| <span data-ttu-id="ebdca-188">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="ebdca-188">Service Unavailable</span></span> | <span data-ttu-id="ebdca-189">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="ebdca-189">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="ebdca-190">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-190">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4E1AAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="ebdca-191">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ebdca-191">Required Request Headers</span></span>
 
| <span data-ttu-id="ebdca-192">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ebdca-192">Header</span></span>| <span data-ttu-id="ebdca-193">説明</span><span class="sxs-lookup"><span data-stu-id="ebdca-193">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ebdca-194">Authorization</span><span class="sxs-lookup"><span data-stu-id="ebdca-194">Authorization</span></span>| <span data-ttu-id="ebdca-195">認証し、要求を承認するために使用 STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ebdca-195">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="ebdca-196">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebdca-196">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="ebdca-197">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="ebdca-197">X-XBL-Contract-Version</span></span>| <span data-ttu-id="ebdca-198">API のバージョンが要求された (正の整数) をされているかを指定します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-198">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="ebdca-199">ピンのサポート バージョン 2 です。</span><span class="sxs-lookup"><span data-stu-id="ebdca-199">Pins supports version 2.</span></span> <span data-ttu-id="ebdca-200">このヘッダーが存在しないか、サービスは、400 – を返す、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="ebdca-200">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span> | 
| <span data-ttu-id="ebdca-201">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ebdca-201">Content-Type</span></span>| <span data-ttu-id="ebdca-202">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-202">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="ebdca-203">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="ebdca-203">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="ebdca-204">If-Match</span><span class="sxs-lookup"><span data-stu-id="ebdca-204">If-Match</span></span>| <span data-ttu-id="ebdca-205">このヘッダーは、変更要求を行ったときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ebdca-205">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="ebdca-206">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-206">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="ebdca-207">"If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="ebdca-207">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="ebdca-208">(省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="ebdca-208">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EQCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="ebdca-209">応答本文</span><span class="sxs-lookup"><span data-stu-id="ebdca-209">Response body</span></span> 
 
<span data-ttu-id="ebdca-210">呼び出しが成功した場合は、サービスは、一覧の最新のメタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="ebdca-210">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4E1CAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="ebdca-211">応答の例</span><span class="sxs-lookup"><span data-stu-id="ebdca-211">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="ebdca-212">関連項目</span><span class="sxs-lookup"><span data-stu-id="ebdca-212">See also</span></span>
 
<a id="ID4EIDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ebdca-213">Parent</span><span class="sxs-lookup"><span data-stu-id="ebdca-213">Parent</span></span> 

[<span data-ttu-id="ebdca-214">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="ebdca-214">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   