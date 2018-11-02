---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems
assetID: 86ee6d1a-fb1f-b918-f605-a9b494c0e787
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamecontainsitemspost.html
author: KevinAsgari
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f3deb042d03fbc8e15d12359d00a594cc36c1a87
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5941195"
---
# <a name="post-usersxuidxuidlistspinslistnamecontainsitems"></a><span data-ttu-id="3f8b5-104">POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span><span class="sxs-lookup"><span data-stu-id="3f8b5-104">POST /users/xuid(xuid)/lists/PINS/{listname}/ContainsItems</span></span>
<span data-ttu-id="3f8b5-105">完全な一覧を取得することがなく一連項目 (itemId により指定) にはが一覧に含まれて かどうかを決定します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-105">Determines whether a list contains a set of items (specified by itemId) without retrieving the entire list.</span></span> <span data-ttu-id="3f8b5-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="3f8b5-107">注釈</span><span class="sxs-lookup"><span data-stu-id="3f8b5-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="3f8b5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f8b5-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="3f8b5-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f8b5-109">Query string parameters</span></span>](#ID4EJC)
  * [<span data-ttu-id="3f8b5-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="3f8b5-110">Request body</span></span>](#ID4EUC)
  * [<span data-ttu-id="3f8b5-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3f8b5-111">HTTP status codes</span></span>](#ID4E6C)
  * [<span data-ttu-id="3f8b5-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f8b5-112">Required Request Headers</span></span>](#ID4EVAAC)
  * [<span data-ttu-id="3f8b5-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="3f8b5-113">Response body</span></span>](#ID4ELCAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="3f8b5-114">注釈</span><span class="sxs-lookup"><span data-stu-id="3f8b5-114">Remarks</span></span> 
 
<span data-ttu-id="3f8b5-115">このエンドポイントでは、呼び出し元に 1 つまたは複数の項目が実際にリストを取得して、それ自体を検索することがなく、指定されたリストに存在かどうかを決定できます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-115">This endpoint allows the caller to determine if one or more items exist in the specified list without actually getting the list and searching for itself.</span></span> <span data-ttu-id="3f8b5-116">項目のセットが itemId (または、プロバイダー/providerId コンボ) によって識別され、戻り値のデータは、true または false ndicating のブール値を使用して一覧には、各項目が含まれているかどうかに渡されるデータ。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-116">The set of items are identified by itemId (or provider/providerId combo) and the return data is the data passed in with a Boolean of true or false ndicating whether the list contains each item.</span></span> 
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="3f8b5-117">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f8b5-117">URI parameters</span></span> 
 
| <span data-ttu-id="3f8b5-118">パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f8b5-118">Parameter</span></span>| <span data-ttu-id="3f8b5-119">型</span><span class="sxs-lookup"><span data-stu-id="3f8b5-119">Type</span></span>| <span data-ttu-id="3f8b5-120">説明</span><span class="sxs-lookup"><span data-stu-id="3f8b5-120">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3f8b5-121">XUID</span><span class="sxs-lookup"><span data-stu-id="3f8b5-121">XUID</span></span>| <span data-ttu-id="3f8b5-122">string</span><span class="sxs-lookup"><span data-stu-id="3f8b5-122">string</span></span>| <span data-ttu-id="3f8b5-123">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-123">XUID of the user.</span></span>| 
| <span data-ttu-id="3f8b5-124">リスト</span><span class="sxs-lookup"><span data-stu-id="3f8b5-124">listname</span></span>| <span data-ttu-id="3f8b5-125">string</span><span class="sxs-lookup"><span data-stu-id="3f8b5-125">string</span></span>| <span data-ttu-id="3f8b5-126">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-126">Name of the list to manipulate.</span></span>| 
  
<a id="ID4EJC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="3f8b5-127">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="3f8b5-127">Query string parameters</span></span> 
 
<span data-ttu-id="3f8b5-128">クエリ パラメーターはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-128">Query parameters are not supported.</span></span>
  
<a id="ID4EUC"></a>

 
## <a name="request-body"></a><span data-ttu-id="3f8b5-129">要求本文</span><span class="sxs-lookup"><span data-stu-id="3f8b5-129">Request body</span></span> 
 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="3f8b5-130">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="3f8b5-130">HTTP status codes</span></span> 
 
<span data-ttu-id="3f8b5-131">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-131">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="3f8b5-132">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-132">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="3f8b5-133">コード</span><span class="sxs-lookup"><span data-stu-id="3f8b5-133">Code</span></span>| <span data-ttu-id="3f8b5-134">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="3f8b5-134">Reason phrase</span></span>| <span data-ttu-id="3f8b5-135">説明</span><span class="sxs-lookup"><span data-stu-id="3f8b5-135">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f8b5-136">200</span><span class="sxs-lookup"><span data-stu-id="3f8b5-136">200</span></span>| <span data-ttu-id="3f8b5-137">OK</span><span class="sxs-lookup"><span data-stu-id="3f8b5-137">OK</span></span> | <span data-ttu-id="3f8b5-138">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-138">The request completed successfully.</span></span> <span data-ttu-id="3f8b5-139">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-139">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="3f8b5-140">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-140">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="3f8b5-141">201</span><span class="sxs-lookup"><span data-stu-id="3f8b5-141">201</span></span>| <span data-ttu-id="3f8b5-142">Created</span><span class="sxs-lookup"><span data-stu-id="3f8b5-142">Created</span></span> | <span data-ttu-id="3f8b5-143">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-143">A new list has been created.</span></span> <span data-ttu-id="3f8b5-144">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-144">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="3f8b5-145">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-145">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="3f8b5-146">304</span><span class="sxs-lookup"><span data-stu-id="3f8b5-146">304</span></span>| <span data-ttu-id="3f8b5-147">Not Modified</span><span class="sxs-lookup"><span data-stu-id="3f8b5-147">Not Modified</span></span>| <span data-ttu-id="3f8b5-148">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-148">Returned on GETs.</span></span> <span data-ttu-id="3f8b5-149">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-149">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="3f8b5-150">サービスは、一覧のバージョンに<b>If-match</b>ヘッダーの値を比較します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-150">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="3f8b5-151">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-151">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="3f8b5-152">400</span><span class="sxs-lookup"><span data-stu-id="3f8b5-152">400</span></span>| <span data-ttu-id="3f8b5-153">Bad Request</span><span class="sxs-lookup"><span data-stu-id="3f8b5-153">Bad Request</span></span> | <span data-ttu-id="3f8b5-154">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-154">The request was malformed.</span></span> <span data-ttu-id="3f8b5-155">無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-155">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="3f8b5-156">不足している必要なパラメーターの結果こともできますか、データの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-156">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="3f8b5-157"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-157">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="3f8b5-158">401</span><span class="sxs-lookup"><span data-stu-id="3f8b5-158">401</span></span>| <span data-ttu-id="3f8b5-159">権限がありません</span><span class="sxs-lookup"><span data-stu-id="3f8b5-159">Unauthorized</span></span> | <span data-ttu-id="3f8b5-160">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-160">The request requires user authentication.</span></span>| 
| <span data-ttu-id="3f8b5-161">403</span><span class="sxs-lookup"><span data-stu-id="3f8b5-161">403</span></span>| <span data-ttu-id="3f8b5-162">Forbidden</span><span class="sxs-lookup"><span data-stu-id="3f8b5-162">Forbidden</span></span> | <span data-ttu-id="3f8b5-163">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-163">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="3f8b5-164">404</span><span class="sxs-lookup"><span data-stu-id="3f8b5-164">404</span></span>| <span data-ttu-id="3f8b5-165">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-165">Not Found</span></span> | <span data-ttu-id="3f8b5-166">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-166">The caller does not have access to the resource.</span></span> <span data-ttu-id="3f8b5-167">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-167">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="3f8b5-168">412</span><span class="sxs-lookup"><span data-stu-id="3f8b5-168">412</span></span>| <span data-ttu-id="3f8b5-169">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="3f8b5-169">Precondition Failed</span></span> | <span data-ttu-id="3f8b5-170">一覧のバージョンが変更されていて、変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-170">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="3f8b5-171">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-171">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="3f8b5-172">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-172">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="3f8b5-173">リストの現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-173">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="3f8b5-174">500</span><span class="sxs-lookup"><span data-stu-id="3f8b5-174">500</span></span>| <span data-ttu-id="3f8b5-175">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="3f8b5-175">Internal Server Error</span></span> | <span data-ttu-id="3f8b5-176">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-176">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="3f8b5-177">501</span><span class="sxs-lookup"><span data-stu-id="3f8b5-177">501</span></span>| <span data-ttu-id="3f8b5-178">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-178">Not Implemented</span></span> | <span data-ttu-id="3f8b5-179">呼び出し元では、サーバーで実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-179">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="3f8b5-180">(現在のみを使用するとき、要求の対象となるがホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="3f8b5-180">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="3f8b5-181">503</span><span class="sxs-lookup"><span data-stu-id="3f8b5-181">503</span></span>| <span data-ttu-id="3f8b5-182">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="3f8b5-182">Service Unavailable</span></span> | <span data-ttu-id="3f8b5-183">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-183">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="3f8b5-184">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-184">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4EVAAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="3f8b5-185">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f8b5-185">Required Request Headers</span></span>
 
| <span data-ttu-id="3f8b5-186">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="3f8b5-186">Header</span></span>| <span data-ttu-id="3f8b5-187">説明</span><span class="sxs-lookup"><span data-stu-id="3f8b5-187">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="3f8b5-188">Authorization</span><span class="sxs-lookup"><span data-stu-id="3f8b5-188">Authorization</span></span>| <span data-ttu-id="3f8b5-189">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-189">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="3f8b5-190">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-190">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="3f8b5-191">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="3f8b5-191">X-XBL-Contract-Version</span></span>| <span data-ttu-id="3f8b5-192">要求された (正の整数) をされている API のバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-192">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="3f8b5-193">バージョン 2 のサポートのピン留めします。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-193">Pins supports version 2.</span></span> <span data-ttu-id="3f8b5-194">このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-194">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span> | 
| <span data-ttu-id="3f8b5-195">Content-Type</span><span class="sxs-lookup"><span data-stu-id="3f8b5-195">Content-Type</span></span>| <span data-ttu-id="3f8b5-196">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-196">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="3f8b5-197">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="3f8b5-197">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="3f8b5-198">If-Match</span><span class="sxs-lookup"><span data-stu-id="3f8b5-198">If-Match</span></span>| <span data-ttu-id="3f8b5-199">このヘッダーは、変更要求を行ったときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-199">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="3f8b5-200">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-200">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="3f8b5-201">現在のバージョン一覧の"If-match"ヘッダー内のバージョンが一致しない場合、http/412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-201">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="3f8b5-202">(省略可能)また場合に使用できますの取得、現在、渡されたバージョン一覧の現在のバージョンし、一覧データがないと一致する HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-202">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4ELCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="3f8b5-203">応答本文</span><span class="sxs-lookup"><span data-stu-id="3f8b5-203">Response body</span></span> 
 
<span data-ttu-id="3f8b5-204">場合は、呼び出しが成功した場合、各項目のか、項目のリストにあるかどうかを指定するブール値と、項目の一覧が返されます。</span><span class="sxs-lookup"><span data-stu-id="3f8b5-204">If the call is successful, the list of items is returned, along with a boolean for each item specifying whether the item is in the list or not.</span></span> 
 
<a id="ID4EVCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="3f8b5-205">応答の例</span><span class="sxs-lookup"><span data-stu-id="3f8b5-205">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="3f8b5-206">関連項目</span><span class="sxs-lookup"><span data-stu-id="3f8b5-206">See also</span></span>
 
<a id="ID4EDDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3f8b5-207">Parent</span><span class="sxs-lookup"><span data-stu-id="3f8b5-207">Parent</span></span> 

[<span data-ttu-id="3f8b5-208">ユニバーサル リソース識別子 (URI) リファレンス</span><span class="sxs-lookup"><span data-stu-id="3f8b5-208">Universal Resource Identifier (URI) Reference</span></span>](../atoc-xboxlivews-reference-uris.md)

   