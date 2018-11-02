---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
assetID: df61be42-c229-7408-5e4c-dbf4ae95b52b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindexpost.html
author: KevinAsgari
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9e1ca061505efe06622302b11a9cd25cd35e93d7
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5926868"
---
# <a name="post-usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a><span data-ttu-id="70d74-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="70d74-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>
<span data-ttu-id="70d74-105">リスト項目をリスト内の異なる位置に移動します。</span><span class="sxs-lookup"><span data-stu-id="70d74-105">Moves an item in a list to a different position within the list.</span></span> <span data-ttu-id="70d74-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="70d74-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="70d74-107">注釈</span><span class="sxs-lookup"><span data-stu-id="70d74-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="70d74-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="70d74-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="70d74-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="70d74-109">Query string parameters</span></span>](#ID4EWC)
  * [<span data-ttu-id="70d74-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="70d74-110">Request body</span></span>](#ID4EVD)
  * [<span data-ttu-id="70d74-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="70d74-111">HTTP status codes</span></span>](#ID4EEE)
  * [<span data-ttu-id="70d74-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="70d74-112">Required Request Headers</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="70d74-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="70d74-113">Response body</span></span>](#ID4EQDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="70d74-114">注釈</span><span class="sxs-lookup"><span data-stu-id="70d74-114">Remarks</span></span> 
 
<span data-ttu-id="70d74-115">この呼び出しは、クライアントが単一の操作でリスト内の別のインデックスに項目を簡単に移動できるに提供されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-115">This call is provided to allow the client to easily move an item to a different index within the list in a single operation.</span></span> <span data-ttu-id="70d74-116">一度に 1 つの項目を移動することがあります。</span><span class="sxs-lookup"><span data-stu-id="70d74-116">Only one item may be moved at a time.</span></span> <span data-ttu-id="70d74-117">移動する項目のインデックスが存在しない場合はその後、HTTP 400 が返されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-117">If the index of the item to be moved does not exist then an HTTP 400 will be returned.</span></span> <span data-ttu-id="70d74-118">挿入ポイントのインデックスは、標準的な挿入と同じ規則に従います。</span><span class="sxs-lookup"><span data-stu-id="70d74-118">The index for the insertion point follows the same rules as a standard insert.</span></span> <span data-ttu-id="70d74-119">既定値は 0 ~ リストの先頭と、任意の数は、リスト内の項目数よりも大きいはリストの末尾に項目を再挿入します。</span><span class="sxs-lookup"><span data-stu-id="70d74-119">It will default to 0 – the beginning of the list and any number greater than the number of items in the list will re-insert the item at the end of the list.</span></span> <span data-ttu-id="70d74-120">同様に insertIndex の「終了」を渡すことによって、リストの末尾を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="70d74-120">Similarly the end of the list can be indicated by passing "end" for insertIndex.</span></span> 
 
<span data-ttu-id="70d74-121">この呼び出しでは、itemId (またはプロバイダー/providerId コンボ) によって移動する項目を識別することもできます。</span><span class="sxs-lookup"><span data-stu-id="70d74-121">This call also allows you to identify the item to be moved by the itemId (or provider/providerId combo).</span></span> <span data-ttu-id="70d74-122">この例では、要求の本文で、itemId を渡す必要があります、リスト内の既存の項目に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="70d74-122">In this case, the itemId must be passed in the body of the request and it must match an existing item in the list.</span></span> <span data-ttu-id="70d74-123">その場合は、説明で IndexOutOfRange でエラーが返されます、HTTP 400この特別なバージョンの呼び出しには、移動する項目のインデックスとして「-1」を使用します。</span><span class="sxs-lookup"><span data-stu-id="70d74-123">If it does not, an HTTP 400 error will be returned with IndexOutOfRange in the description; for this special version of the call, use "-1" as the index of the item to be moved.</span></span> 
 
<span data-ttu-id="70d74-124">この呼び出しが必要とする"場合-マッチ: versionNumber"ヘッダーに含まれる要求で、項目を指定する場合は、インデックスを。</span><span class="sxs-lookup"><span data-stu-id="70d74-124">This call requires an "If-Match:versionNumber" header to be included in the request if specifying the item by index.</span></span> <span data-ttu-id="70d74-125">使って場合 itemId を移動するには、どの項目を示すために、"If-match"ヘッダーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="70d74-125">If using itemId to indicate which item to move, then the "If-Match" header is optional.</span></span> <span data-ttu-id="70d74-126">存在する場合、"If-match"ヘッダーが常に検証されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-126">If present, the "If-Match" header will always be validated.</span></span> <span data-ttu-id="70d74-127">"If-match"ヘッダー、versionNumber はリストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="70d74-127">In the "if-Match" header, the versionNumber is the current version number of the list.</span></span> <span data-ttu-id="70d74-128">かどうかは、いない含まれている (および必須)、または、現在は一致しない一覧のバージョン番号、http/412 – の前提条件が失敗した状態コードが返され、応答の本文が現在のバージョン番号が含まれている一覧の最新のメタデータを含める.</span><span class="sxs-lookup"><span data-stu-id="70d74-128">If it is not included (and required), or does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="70d74-129">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐためです。</span><span class="sxs-lookup"><span data-stu-id="70d74-129">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="70d74-130">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="70d74-130">URI parameters</span></span> 
 
| <span data-ttu-id="70d74-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="70d74-131">Parameter</span></span>| <span data-ttu-id="70d74-132">型</span><span class="sxs-lookup"><span data-stu-id="70d74-132">Type</span></span>| <span data-ttu-id="70d74-133">説明</span><span class="sxs-lookup"><span data-stu-id="70d74-133">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="70d74-134">XUID</span><span class="sxs-lookup"><span data-stu-id="70d74-134">XUID</span></span>| <span data-ttu-id="70d74-135">string</span><span class="sxs-lookup"><span data-stu-id="70d74-135">string</span></span>| <span data-ttu-id="70d74-136">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="70d74-136">XUID of the user.</span></span>| 
| <span data-ttu-id="70d74-137">リスト</span><span class="sxs-lookup"><span data-stu-id="70d74-137">listname</span></span>| <span data-ttu-id="70d74-138">string</span><span class="sxs-lookup"><span data-stu-id="70d74-138">string</span></span>| <span data-ttu-id="70d74-139">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="70d74-139">Name of the list to manipulate.</span></span>| 
| <span data-ttu-id="70d74-140">インデックス</span><span class="sxs-lookup"><span data-stu-id="70d74-140">index</span></span>| <span data-ttu-id="70d74-141">string</span><span class="sxs-lookup"><span data-stu-id="70d74-141">string</span></span>| <span data-ttu-id="70d74-142">移動する項目の現在のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="70d74-142">Specifies the current index of the item to be moved.</span></span> <span data-ttu-id="70d74-143">インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを参照し、呼び出しの要求本文は空にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="70d74-143">If the index value is zero or a positive integer, this refers to the current index of the item, and the request body of the call should be empty.</span></span> <span data-ttu-id="70d74-144">ただし、インデックス値が「-1」の場合は、ItemId または呼び出しの要求本文には、プロバイダー/ProviderID によって移動する項目を指定してください。</span><span class="sxs-lookup"><span data-stu-id="70d74-144">However, if the index value is "-1", the item to be moved must be specified by ItemId or Provider/ProviderID in the request body of the call.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="70d74-145">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="70d74-145">Query string parameters</span></span> 
 
| <span data-ttu-id="70d74-146">パラメーター</span><span class="sxs-lookup"><span data-stu-id="70d74-146">Parameter</span></span>| <span data-ttu-id="70d74-147">型</span><span class="sxs-lookup"><span data-stu-id="70d74-147">Type</span></span>| <span data-ttu-id="70d74-148">説明</span><span class="sxs-lookup"><span data-stu-id="70d74-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="70d74-149">insertIndex</span><span class="sxs-lookup"><span data-stu-id="70d74-149">insertIndex</span></span>| <span data-ttu-id="70d74-150">string</span><span class="sxs-lookup"><span data-stu-id="70d74-150">string</span></span>| <span data-ttu-id="70d74-151">項目を挿入する一覧の場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="70d74-151">Specifies the list location to insert the item.</span></span> <span data-ttu-id="70d74-152">許可された値は 0、正の整数、および「終了」します。</span><span class="sxs-lookup"><span data-stu-id="70d74-152">Allowed values are zero, positive integers, and "end".</span></span> <span data-ttu-id="70d74-153">「終了」は、現在のリストの最後に、項目を配置します。</span><span class="sxs-lookup"><span data-stu-id="70d74-153">"end" places the item at the end of the current list.</span></span> <span data-ttu-id="70d74-154">指定された値は、リストの末尾外ですが、一覧の最後に、項目が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-154">If the specified value is beyond the end of the list, the item is inserted at the end of the list.</span></span> | 
  
<a id="ID4EVD"></a>

 
## <a name="request-body"></a><span data-ttu-id="70d74-155">要求本文</span><span class="sxs-lookup"><span data-stu-id="70d74-155">Request body</span></span> 
 
<span data-ttu-id="70d74-156">要求本文はプロバイダー/ProviderId や itemId によって移動する項目を指定するときにのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-156">A request body is sent only when specifying the item to move by itemId or by Provider/ProviderId.</span></span>
 
<a id="ID4E6D"></a>

  
<span data-ttu-id="70d74-157">要求の例</span><span class="sxs-lookup"><span data-stu-id="70d74-157">Sample Request</span></span> 

```cpp
{
  "Item":
  {
    "ItemId":  "ed591a0c-dde3-563f-99af-530278a3c402",
    "ProviderId":  null,
    "Provider": null
  }
}
    
```

  
<a id="ID4EEE"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="70d74-158">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="70d74-158">HTTP status codes</span></span> 
 
<span data-ttu-id="70d74-159">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="70d74-159">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="70d74-160">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="70d74-160">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="70d74-161">コード</span><span class="sxs-lookup"><span data-stu-id="70d74-161">Code</span></span>| <span data-ttu-id="70d74-162">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="70d74-162">Reason phrase</span></span>| <span data-ttu-id="70d74-163">説明</span><span class="sxs-lookup"><span data-stu-id="70d74-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="70d74-164">200</span><span class="sxs-lookup"><span data-stu-id="70d74-164">200</span></span>| <span data-ttu-id="70d74-165">OK</span><span class="sxs-lookup"><span data-stu-id="70d74-165">OK</span></span> | <span data-ttu-id="70d74-166">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="70d74-166">The request completed successfully.</span></span> <span data-ttu-id="70d74-167">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="70d74-167">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="70d74-168">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-168">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="70d74-169">201</span><span class="sxs-lookup"><span data-stu-id="70d74-169">201</span></span>| <span data-ttu-id="70d74-170">Created</span><span class="sxs-lookup"><span data-stu-id="70d74-170">Created</span></span> | <span data-ttu-id="70d74-171">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="70d74-171">A new list has been created.</span></span> <span data-ttu-id="70d74-172">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-172">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="70d74-173">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="70d74-173">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="70d74-174">304</span><span class="sxs-lookup"><span data-stu-id="70d74-174">304</span></span>| <span data-ttu-id="70d74-175">Not Modified</span><span class="sxs-lookup"><span data-stu-id="70d74-175">Not Modified</span></span>| <span data-ttu-id="70d74-176">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-176">Returned on GETs.</span></span> <span data-ttu-id="70d74-177">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="70d74-177">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="70d74-178">サービスは、一覧のバージョンに<b>If-match</b>ヘッダーの値を比較します。</span><span class="sxs-lookup"><span data-stu-id="70d74-178">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="70d74-179">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-179">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="70d74-180">400</span><span class="sxs-lookup"><span data-stu-id="70d74-180">400</span></span>| <span data-ttu-id="70d74-181">Bad Request</span><span class="sxs-lookup"><span data-stu-id="70d74-181">Bad Request</span></span> | <span data-ttu-id="70d74-182">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="70d74-182">The request was malformed.</span></span> <span data-ttu-id="70d74-183">無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="70d74-183">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="70d74-184">不足している必要なパラメーターの結果こともできますか、データの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-184">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="70d74-185"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="70d74-185">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="70d74-186">401</span><span class="sxs-lookup"><span data-stu-id="70d74-186">401</span></span>| <span data-ttu-id="70d74-187">権限がありません</span><span class="sxs-lookup"><span data-stu-id="70d74-187">Unauthorized</span></span> | <span data-ttu-id="70d74-188">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="70d74-188">The request requires user authentication.</span></span>| 
| <span data-ttu-id="70d74-189">403</span><span class="sxs-lookup"><span data-stu-id="70d74-189">403</span></span>| <span data-ttu-id="70d74-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="70d74-190">Forbidden</span></span> | <span data-ttu-id="70d74-191">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="70d74-191">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="70d74-192">404</span><span class="sxs-lookup"><span data-stu-id="70d74-192">404</span></span>| <span data-ttu-id="70d74-193">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="70d74-193">Not Found</span></span> | <span data-ttu-id="70d74-194">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="70d74-194">The caller does not have access to the resource.</span></span> <span data-ttu-id="70d74-195">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="70d74-195">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="70d74-196">412</span><span class="sxs-lookup"><span data-stu-id="70d74-196">412</span></span>| <span data-ttu-id="70d74-197">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="70d74-197">Precondition Failed</span></span> | <span data-ttu-id="70d74-198">一覧のバージョンが変更されていて、変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="70d74-198">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="70d74-199">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="70d74-199">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="70d74-200">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="70d74-200">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="70d74-201">リストの現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-201">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="70d74-202">500</span><span class="sxs-lookup"><span data-stu-id="70d74-202">500</span></span>| <span data-ttu-id="70d74-203">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="70d74-203">Internal Server Error</span></span> | <span data-ttu-id="70d74-204">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="70d74-204">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="70d74-205">501</span><span class="sxs-lookup"><span data-stu-id="70d74-205">501</span></span>| <span data-ttu-id="70d74-206">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="70d74-206">Not Implemented</span></span> | <span data-ttu-id="70d74-207">呼び出し元では、サーバーで実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="70d74-207">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="70d74-208">(現在のみを使用するとき、要求の対象となるがホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="70d74-208">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="70d74-209">503</span><span class="sxs-lookup"><span data-stu-id="70d74-209">503</span></span>| <span data-ttu-id="70d74-210">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="70d74-210">Service Unavailable</span></span> | <span data-ttu-id="70d74-211">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="70d74-211">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="70d74-212">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="70d74-212">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4E1BAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="70d74-213">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="70d74-213">Required Request Headers</span></span>
 
| <span data-ttu-id="70d74-214">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="70d74-214">Header</span></span>| <span data-ttu-id="70d74-215">説明</span><span class="sxs-lookup"><span data-stu-id="70d74-215">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="70d74-216">Authorization</span><span class="sxs-lookup"><span data-stu-id="70d74-216">Authorization</span></span>| <span data-ttu-id="70d74-217">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="70d74-217">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="70d74-218">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="70d74-218">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="70d74-219">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="70d74-219">X-XBL-Contract-Version</span></span>| <span data-ttu-id="70d74-220">要求された (正の整数) をされている API のバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="70d74-220">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="70d74-221">バージョン 2 のサポートのピン留めします。</span><span class="sxs-lookup"><span data-stu-id="70d74-221">Pins supports version 2.</span></span> <span data-ttu-id="70d74-222">このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="70d74-222">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="70d74-223">Content-Type</span><span class="sxs-lookup"><span data-stu-id="70d74-223">Content-Type</span></span>| <span data-ttu-id="70d74-224">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="70d74-224">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="70d74-225">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="70d74-225">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="70d74-226">If-Match</span><span class="sxs-lookup"><span data-stu-id="70d74-226">If-Match</span></span>| <span data-ttu-id="70d74-227">このヘッダーは、変更要求を行ったときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="70d74-227">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="70d74-228">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="70d74-228">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="70d74-229">現在のバージョン一覧の"If-match"ヘッダー内のバージョンが一致しない場合、http/412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="70d74-229">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="70d74-230">(省略可能)また場合に使用できますの取得、現在、渡されたバージョン一覧の現在のバージョンし、一覧データがないと一致する HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="70d74-230">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EQDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="70d74-231">応答本文</span><span class="sxs-lookup"><span data-stu-id="70d74-231">Response body</span></span> 
 
<span data-ttu-id="70d74-232">呼び出しが成功した場合は、サービスは、一覧の最新のメタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="70d74-232">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4E1DAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="70d74-233">応答の例</span><span class="sxs-lookup"><span data-stu-id="70d74-233">Sample response</span></span> 
 

```cpp
{ 
  "ListVersion":  1,
  "ListCount":  1,
  "MaxListSize": 200,
  "AllowDuplicates": "true",
  "AccessSetting":  "OwnerOnly"
}

      
```

   
<a id="ID4EIEAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="70d74-234">関連項目</span><span class="sxs-lookup"><span data-stu-id="70d74-234">See also</span></span>
 
<a id="ID4EKEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="70d74-235">Parent</span><span class="sxs-lookup"><span data-stu-id="70d74-235">Parent</span></span> 

[<span data-ttu-id="70d74-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="70d74-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>](uri-usersxuidlistspinslistnameindex.md)

   