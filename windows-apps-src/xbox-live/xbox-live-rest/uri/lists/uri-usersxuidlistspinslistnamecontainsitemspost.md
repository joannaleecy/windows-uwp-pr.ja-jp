---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems
assetID: 86ee6d1a-fb1f-b918-f605-a9b494c0e787
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamecontainsitemspost.html
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: c18bf70773de60d4c831d4be891255f98750efa8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57636877"
---
# <a name="post-usersxuidxuidlistspinslistnamecontainsitems"></a><span data-ttu-id="cf363-104">POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span><span class="sxs-lookup"><span data-stu-id="cf363-104">POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span></span>
<span data-ttu-id="cf363-105">全体の一覧を取得せず、(itemId で指定された) 項目のセットが一覧に含まれて かどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="cf363-105">Determines whether a list contains a set of items (specified by itemId) without retrieving the entire list.</span></span> <span data-ttu-id="cf363-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="cf363-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="cf363-107">注釈</span><span class="sxs-lookup"><span data-stu-id="cf363-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="cf363-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf363-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="cf363-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf363-109">Query string parameters</span></span>](#ID4EJC)
  * [<span data-ttu-id="cf363-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="cf363-110">Request body</span></span>](#ID4EUC)
  * [<span data-ttu-id="cf363-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="cf363-111">HTTP status codes</span></span>](#ID4E6C)
  * [<span data-ttu-id="cf363-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cf363-112">Required Request Headers</span></span>](#ID4EVAAC)
  * [<span data-ttu-id="cf363-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="cf363-113">Response body</span></span>](#ID4ELCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="cf363-114">注釈</span><span class="sxs-lookup"><span data-stu-id="cf363-114">Remarks</span></span> 
 
<span data-ttu-id="cf363-115">このエンドポイントは、1 つまたは複数の項目が検索自体を実際に、一覧を取得せず、指定されたリスト内に存在かどうかを決定する、呼び出し元を使用できます。</span><span class="sxs-lookup"><span data-stu-id="cf363-115">This endpoint allows the caller to determine if one or more items exist in the specified list without actually getting the list and searching for itself.</span></span> <span data-ttu-id="cf363-116">項目のセットが itemid である (またはプロバイダー/providerId コンボ) によって識別され、戻り値のデータが一覧には、各項目が含まれて かどうか ndicating の true または false のブール値で渡されるデータ。</span><span class="sxs-lookup"><span data-stu-id="cf363-116">The set of items are identified by itemId (or provider/providerId combo) and the return data is the data passed in with a Boolean of true or false ndicating whether the list contains each item.</span></span> 
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="cf363-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf363-117">URI parameters</span></span> 
 
| <span data-ttu-id="cf363-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf363-118">Parameter</span></span>| <span data-ttu-id="cf363-119">種類</span><span class="sxs-lookup"><span data-stu-id="cf363-119">Type</span></span>| <span data-ttu-id="cf363-120">説明</span><span class="sxs-lookup"><span data-stu-id="cf363-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cf363-121">XUID</span><span class="sxs-lookup"><span data-stu-id="cf363-121">XUID</span></span>| <span data-ttu-id="cf363-122">string</span><span class="sxs-lookup"><span data-stu-id="cf363-122">string</span></span>| <span data-ttu-id="cf363-123">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="cf363-123">XUID of the user.</span></span>| 
| <span data-ttu-id="cf363-124">listname</span><span class="sxs-lookup"><span data-stu-id="cf363-124">listname</span></span>| <span data-ttu-id="cf363-125">string</span><span class="sxs-lookup"><span data-stu-id="cf363-125">string</span></span>| <span data-ttu-id="cf363-126">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="cf363-126">Name of the list to manipulate.</span></span>| 
  
<a id="ID4EJC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="cf363-127">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="cf363-127">Query string parameters</span></span> 
 
<span data-ttu-id="cf363-128">クエリ パラメーターがサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="cf363-128">Query parameters are not supported.</span></span>
  
<a id="ID4EUC"></a>

 
## <a name="request-body"></a><span data-ttu-id="cf363-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="cf363-129">Request body</span></span> 
 

```cpp
{
  "Items":
  [{"ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
    "ProviderId":  null,
    "Provider": null
  }]
}


    
```

  
<a id="ID4E6C"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="cf363-130">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="cf363-130">HTTP status codes</span></span> 
 
<span data-ttu-id="cf363-131">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="cf363-131">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="cf363-132">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="cf363-132">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="cf363-133">コード</span><span class="sxs-lookup"><span data-stu-id="cf363-133">Code</span></span>| <span data-ttu-id="cf363-134">理由語句</span><span class="sxs-lookup"><span data-stu-id="cf363-134">Reason phrase</span></span>| <span data-ttu-id="cf363-135">説明</span><span class="sxs-lookup"><span data-stu-id="cf363-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cf363-136">200</span><span class="sxs-lookup"><span data-stu-id="cf363-136">200</span></span>| <span data-ttu-id="cf363-137">OK</span><span class="sxs-lookup"><span data-stu-id="cf363-137">OK</span></span> | <span data-ttu-id="cf363-138">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="cf363-138">The request completed successfully.</span></span> <span data-ttu-id="cf363-139">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf363-139">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="cf363-140">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="cf363-140">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="cf363-141">201</span><span class="sxs-lookup"><span data-stu-id="cf363-141">201</span></span>| <span data-ttu-id="cf363-142">作成日</span><span class="sxs-lookup"><span data-stu-id="cf363-142">Created</span></span> | <span data-ttu-id="cf363-143">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="cf363-143">A new list has been created.</span></span> <span data-ttu-id="cf363-144">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="cf363-144">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="cf363-145">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="cf363-145">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="cf363-146">304</span><span class="sxs-lookup"><span data-stu-id="cf363-146">304</span></span>| <span data-ttu-id="cf363-147">変更されていません</span><span class="sxs-lookup"><span data-stu-id="cf363-147">Not Modified</span></span>| <span data-ttu-id="cf363-148">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="cf363-148">Returned on GETs.</span></span> <span data-ttu-id="cf363-149">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="cf363-149">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="cf363-150">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="cf363-150">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="cf363-151">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="cf363-151">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="cf363-152">400</span><span class="sxs-lookup"><span data-stu-id="cf363-152">400</span></span>| <span data-ttu-id="cf363-153">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="cf363-153">Bad Request</span></span> | <span data-ttu-id="cf363-154">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="cf363-154">The request was malformed.</span></span> <span data-ttu-id="cf363-155">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="cf363-155">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="cf363-156">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="cf363-156">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="cf363-157">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="cf363-157">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="cf363-158">401</span><span class="sxs-lookup"><span data-stu-id="cf363-158">401</span></span>| <span data-ttu-id="cf363-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="cf363-159">Unauthorized</span></span> | <span data-ttu-id="cf363-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="cf363-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="cf363-161">403</span><span class="sxs-lookup"><span data-stu-id="cf363-161">403</span></span>| <span data-ttu-id="cf363-162">Forbidden</span><span class="sxs-lookup"><span data-stu-id="cf363-162">Forbidden</span></span> | <span data-ttu-id="cf363-163">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="cf363-163">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="cf363-164">404</span><span class="sxs-lookup"><span data-stu-id="cf363-164">404</span></span>| <span data-ttu-id="cf363-165">検出不可</span><span class="sxs-lookup"><span data-stu-id="cf363-165">Not Found</span></span> | <span data-ttu-id="cf363-166">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="cf363-166">The caller does not have access to the resource.</span></span> <span data-ttu-id="cf363-167">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="cf363-167">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="cf363-168">412</span><span class="sxs-lookup"><span data-stu-id="cf363-168">412</span></span>| <span data-ttu-id="cf363-169">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="cf363-169">Precondition Failed</span></span> | <span data-ttu-id="cf363-170">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="cf363-170">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="cf363-171">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="cf363-171">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="cf363-172">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="cf363-172">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="cf363-173">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="cf363-173">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="cf363-174">500</span><span class="sxs-lookup"><span data-stu-id="cf363-174">500</span></span>| <span data-ttu-id="cf363-175">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="cf363-175">Internal Server Error</span></span> | <span data-ttu-id="cf363-176">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="cf363-176">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="cf363-177">501</span><span class="sxs-lookup"><span data-stu-id="cf363-177">501</span></span>| <span data-ttu-id="cf363-178">実装されていません</span><span class="sxs-lookup"><span data-stu-id="cf363-178">Not Implemented</span></span> | <span data-ttu-id="cf363-179">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="cf363-179">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="cf363-180">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="cf363-180">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="cf363-181">503</span><span class="sxs-lookup"><span data-stu-id="cf363-181">503</span></span>| <span data-ttu-id="cf363-182">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="cf363-182">Service Unavailable</span></span> | <span data-ttu-id="cf363-183">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="cf363-183">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="cf363-184">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="cf363-184">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4EVAAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="cf363-185">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="cf363-185">Required Request Headers</span></span>
 
| <span data-ttu-id="cf363-186">Header</span><span class="sxs-lookup"><span data-stu-id="cf363-186">Header</span></span>| <span data-ttu-id="cf363-187">説明</span><span class="sxs-lookup"><span data-stu-id="cf363-187">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="cf363-188">Authorization</span><span class="sxs-lookup"><span data-stu-id="cf363-188">Authorization</span></span>| <span data-ttu-id="cf363-189">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="cf363-189">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="cf363-190">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="cf363-190">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="cf363-191">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="cf363-191">X-XBL-Contract-Version</span></span>| <span data-ttu-id="cf363-192">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="cf363-192">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="cf363-193">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="cf363-193">Pins supports version 2.</span></span> <span data-ttu-id="cf363-194">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="cf363-194">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span> | 
| <span data-ttu-id="cf363-195">Content-Type</span><span class="sxs-lookup"><span data-stu-id="cf363-195">Content-Type</span></span>| <span data-ttu-id="cf363-196">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="cf363-196">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="cf363-197">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="cf363-197">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="cf363-198">If-Match</span><span class="sxs-lookup"><span data-stu-id="cf363-198">If-Match</span></span>| <span data-ttu-id="cf363-199">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="cf363-199">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="cf363-200">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="cf363-200">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="cf363-201">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="cf363-201">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="cf363-202">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="cf363-202">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4ELCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="cf363-203">応答本文</span><span class="sxs-lookup"><span data-stu-id="cf363-203">Response body</span></span> 
 
<span data-ttu-id="cf363-204">呼び出しが成功した場合か、項目が一覧にあるかどうかを指定する各項目のブール値と共に項目の一覧が返されます。</span><span class="sxs-lookup"><span data-stu-id="cf363-204">If the call is successful, the list of items is returned, along with a boolean for each item specifying whether the item is in the list or not.</span></span> 
 
<a id="ID4EVCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="cf363-205">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="cf363-205">Sample response</span></span> 
 

```cpp
{
  "ContainedItems":
  [{"Contained": "true",
    "Item":
   {"ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
    "ProviderId": null,
    "Provider": null
   }
  }]
}


      
```

   
<a id="ID4EBDAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cf363-206">関連項目</span><span class="sxs-lookup"><span data-stu-id="cf363-206">See also</span></span>
 
<a id="ID4EDDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cf363-207">Parent</span><span class="sxs-lookup"><span data-stu-id="cf363-207">Parent</span></span> 

[<span data-ttu-id="cf363-208">Universal Resource Identifier (URI) のリファレンス</span><span class="sxs-lookup"><span data-stu-id="cf363-208">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   