---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
assetID: df61be42-c229-7408-5e4c-dbf4ae95b52b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindexpost.html
author: KevinAsgari
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1aecb7f73a49e7628b076fe943774ccf89aa71bc
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4684066"
---
# <a name="post-usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a><span data-ttu-id="f63f0-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="f63f0-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>
<span data-ttu-id="f63f0-105">リスト内の異なる位置に一覧で項目を移動します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-105">Moves an item in a list to a different position within the list.</span></span> <span data-ttu-id="f63f0-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f63f0-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f63f0-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="f63f0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f63f0-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="f63f0-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f63f0-109">Query string parameters</span></span>](#ID4EWC)
  * [<span data-ttu-id="f63f0-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="f63f0-110">Request body</span></span>](#ID4EVD)
  * [<span data-ttu-id="f63f0-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f63f0-111">HTTP status codes</span></span>](#ID4EEE)
  * [<span data-ttu-id="f63f0-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f63f0-112">Required Request Headers</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="f63f0-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="f63f0-113">Response body</span></span>](#ID4EQDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="f63f0-114">注釈</span><span class="sxs-lookup"><span data-stu-id="f63f0-114">Remarks</span></span> 
 
<span data-ttu-id="f63f0-115">この呼び出しは、クライアントが単一の操作でリスト内の別のインデックスに項目を簡単に移動できる提供されています。</span><span class="sxs-lookup"><span data-stu-id="f63f0-115">This call is provided to allow the client to easily move an item to a different index within the list in a single operation.</span></span> <span data-ttu-id="f63f0-116">一度に 1 つの項目を移動することがあります。</span><span class="sxs-lookup"><span data-stu-id="f63f0-116">Only one item may be moved at a time.</span></span> <span data-ttu-id="f63f0-117">移動する項目のインデックスが存在しない場合は、HTTP 400 が返されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-117">If the index of the item to be moved does not exist then an HTTP 400 will be returned.</span></span> <span data-ttu-id="f63f0-118">挿入ポイントのインデックスは、標準的な挿入と同じ規則に従います。</span><span class="sxs-lookup"><span data-stu-id="f63f0-118">The index for the insertion point follows the same rules as a standard insert.</span></span> <span data-ttu-id="f63f0-119">既定値は 0 ~ リストの先頭と、任意の数は、リスト内の項目数よりも大きいはリストの末尾に項目を再挿入します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-119">It will default to 0 – the beginning of the list and any number greater than the number of items in the list will re-insert the item at the end of the list.</span></span> <span data-ttu-id="f63f0-120">同様に insertIndex の「終了」を渡すことによって、リストの末尾を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-120">Similarly the end of the list can be indicated by passing "end" for insertIndex.</span></span> 
 
<span data-ttu-id="f63f0-121">この呼び出しでは、itemId (またはプロバイダー/providerId コンボ) によって移動する項目を識別することもできます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-121">This call also allows you to identify the item to be moved by the itemId (or provider/providerId combo).</span></span> <span data-ttu-id="f63f0-122">この例では、要求の本文で、itemId を渡す必要があります、リスト内の既存の項目に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f63f0-122">In this case, the itemId must be passed in the body of the request and it must match an existing item in the list.</span></span> <span data-ttu-id="f63f0-123">その場合は、説明に IndexOutOfRange でエラーが返される、HTTP 400呼び出しのこの特別なバージョンでは、移動する項目のインデックスとして「-1」を使用します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-123">If it does not, an HTTP 400 error will be returned with IndexOutOfRange in the description; for this special version of the call, use "-1" as the index of the item to be moved.</span></span> 
 
<span data-ttu-id="f63f0-124">この呼び出しが必要とする"場合-マッチ: versionNumber"ヘッダーに含まれる要求で、項目を指定する場合は、インデックスをします。</span><span class="sxs-lookup"><span data-stu-id="f63f0-124">This call requires an "If-Match:versionNumber" header to be included in the request if specifying the item by index.</span></span> <span data-ttu-id="f63f0-125">使って場合 itemId を移動するには、どの項目を示すために、"If-match"ヘッダーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="f63f0-125">If using itemId to indicate which item to move, then the "If-Match" header is optional.</span></span> <span data-ttu-id="f63f0-126">存在する場合、"If-match"ヘッダーが常に検証されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-126">If present, the "If-Match" header will always be validated.</span></span> <span data-ttu-id="f63f0-127">"If-match"ヘッダーで、次のメッセージは、リストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="f63f0-127">In the "if-Match" header, the versionNumber is the current version number of the list.</span></span> <span data-ttu-id="f63f0-128">かどうかにはいない含まれている (、必要な)、または、現在は一致しない一覧のバージョン番号、http/412 – の前提条件が失敗した状態コードが返され、応答の本文が現在のバージョン番号が含まれている一覧の最新のメタデータを含める.</span><span class="sxs-lookup"><span data-stu-id="f63f0-128">If it is not included (and required), or does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="f63f0-129">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐためです。</span><span class="sxs-lookup"><span data-stu-id="f63f0-129">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f63f0-130">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f63f0-130">URI parameters</span></span> 
 
| <span data-ttu-id="f63f0-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f63f0-131">Parameter</span></span>| <span data-ttu-id="f63f0-132">型</span><span class="sxs-lookup"><span data-stu-id="f63f0-132">Type</span></span>| <span data-ttu-id="f63f0-133">説明</span><span class="sxs-lookup"><span data-stu-id="f63f0-133">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f63f0-134">XUID</span><span class="sxs-lookup"><span data-stu-id="f63f0-134">XUID</span></span>| <span data-ttu-id="f63f0-135">string</span><span class="sxs-lookup"><span data-stu-id="f63f0-135">string</span></span>| <span data-ttu-id="f63f0-136">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="f63f0-136">XUID of the user.</span></span>| 
| <span data-ttu-id="f63f0-137">リスト</span><span class="sxs-lookup"><span data-stu-id="f63f0-137">listname</span></span>| <span data-ttu-id="f63f0-138">string</span><span class="sxs-lookup"><span data-stu-id="f63f0-138">string</span></span>| <span data-ttu-id="f63f0-139">操作をするリストの名前。</span><span class="sxs-lookup"><span data-stu-id="f63f0-139">Name of the list to manipulate.</span></span>| 
| <span data-ttu-id="f63f0-140">インデックス</span><span class="sxs-lookup"><span data-stu-id="f63f0-140">index</span></span>| <span data-ttu-id="f63f0-141">string</span><span class="sxs-lookup"><span data-stu-id="f63f0-141">string</span></span>| <span data-ttu-id="f63f0-142">移動する項目の現在のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-142">Specifies the current index of the item to be moved.</span></span> <span data-ttu-id="f63f0-143">インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを参照し、呼び出しの要求本文は空にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f63f0-143">If the index value is zero or a positive integer, this refers to the current index of the item, and the request body of the call should be empty.</span></span> <span data-ttu-id="f63f0-144">ただし、インデックス値が「-1」の場合、ItemId または呼び出しの要求本文には、プロバイダー/ProviderID によって移動する項目を指定してください。</span><span class="sxs-lookup"><span data-stu-id="f63f0-144">However, if the index value is "-1", the item to be moved must be specified by ItemId or Provider/ProviderID in the request body of the call.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="f63f0-145">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f63f0-145">Query string parameters</span></span> 
 
| <span data-ttu-id="f63f0-146">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f63f0-146">Parameter</span></span>| <span data-ttu-id="f63f0-147">型</span><span class="sxs-lookup"><span data-stu-id="f63f0-147">Type</span></span>| <span data-ttu-id="f63f0-148">説明</span><span class="sxs-lookup"><span data-stu-id="f63f0-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f63f0-149">insertIndex</span><span class="sxs-lookup"><span data-stu-id="f63f0-149">insertIndex</span></span>| <span data-ttu-id="f63f0-150">string</span><span class="sxs-lookup"><span data-stu-id="f63f0-150">string</span></span>| <span data-ttu-id="f63f0-151">項目を挿入する一覧の場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-151">Specifies the list location to insert the item.</span></span> <span data-ttu-id="f63f0-152">許可された値は 0、正の整数、および「終了」です。</span><span class="sxs-lookup"><span data-stu-id="f63f0-152">Allowed values are zero, positive integers, and "end".</span></span> <span data-ttu-id="f63f0-153">「終了」は、現在のリストの最後に、項目を配置します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-153">"end" places the item at the end of the current list.</span></span> <span data-ttu-id="f63f0-154">指定された値が一覧の終了後にある場合は、リストの最後に、項目が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-154">If the specified value is beyond the end of the list, the item is inserted at the end of the list.</span></span> | 
  
<a id="ID4EVD"></a>

 
## <a name="request-body"></a><span data-ttu-id="f63f0-155">要求本文</span><span class="sxs-lookup"><span data-stu-id="f63f0-155">Request body</span></span> 
 
<span data-ttu-id="f63f0-156">要求本文は itemId またはプロバイダー/ProviderId を移動する項目を指定するときにのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-156">A request body is sent only when specifying the item to move by itemId or by Provider/ProviderId.</span></span>
 
<a id="ID4E6D"></a>

  
<span data-ttu-id="f63f0-157">要求の例</span><span class="sxs-lookup"><span data-stu-id="f63f0-157">Sample Request</span></span> 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="f63f0-158">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f63f0-158">HTTP status codes</span></span> 
 
<span data-ttu-id="f63f0-159">サービスでは、このリソースには、この方法で行った要求に応答には、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-159">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="f63f0-160">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f63f0-160">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="f63f0-161">コード</span><span class="sxs-lookup"><span data-stu-id="f63f0-161">Code</span></span>| <span data-ttu-id="f63f0-162">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="f63f0-162">Reason phrase</span></span>| <span data-ttu-id="f63f0-163">説明</span><span class="sxs-lookup"><span data-stu-id="f63f0-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f63f0-164">200</span><span class="sxs-lookup"><span data-stu-id="f63f0-164">200</span></span>| <span data-ttu-id="f63f0-165">OK</span><span class="sxs-lookup"><span data-stu-id="f63f0-165">OK</span></span> | <span data-ttu-id="f63f0-166">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="f63f0-166">The request completed successfully.</span></span> <span data-ttu-id="f63f0-167">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f63f0-167">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="f63f0-168">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-168">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="f63f0-169">201</span><span class="sxs-lookup"><span data-stu-id="f63f0-169">201</span></span>| <span data-ttu-id="f63f0-170">Created</span><span class="sxs-lookup"><span data-stu-id="f63f0-170">Created</span></span> | <span data-ttu-id="f63f0-171">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="f63f0-171">A new list has been created.</span></span> <span data-ttu-id="f63f0-172">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-172">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="f63f0-173">応答には、一覧の最新の状態のメタデータが含まれています。 と場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f63f0-173">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="f63f0-174">304</span><span class="sxs-lookup"><span data-stu-id="f63f0-174">304</span></span>| <span data-ttu-id="f63f0-175">Not Modified</span><span class="sxs-lookup"><span data-stu-id="f63f0-175">Not Modified</span></span>| <span data-ttu-id="f63f0-176">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-176">Returned on GETs.</span></span> <span data-ttu-id="f63f0-177">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-177">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="f63f0-178">サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-178">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="f63f0-179">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-179">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="f63f0-180">400</span><span class="sxs-lookup"><span data-stu-id="f63f0-180">400</span></span>| <span data-ttu-id="f63f0-181">Bad Request</span><span class="sxs-lookup"><span data-stu-id="f63f0-181">Bad Request</span></span> | <span data-ttu-id="f63f0-182">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="f63f0-182">The request was malformed.</span></span> <span data-ttu-id="f63f0-183">無効な値または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-183">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="f63f0-184">不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-184">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="f63f0-185"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="f63f0-185">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="f63f0-186">401</span><span class="sxs-lookup"><span data-stu-id="f63f0-186">401</span></span>| <span data-ttu-id="f63f0-187">権限がありません</span><span class="sxs-lookup"><span data-stu-id="f63f0-187">Unauthorized</span></span> | <span data-ttu-id="f63f0-188">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="f63f0-188">The request requires user authentication.</span></span>| 
| <span data-ttu-id="f63f0-189">403</span><span class="sxs-lookup"><span data-stu-id="f63f0-189">403</span></span>| <span data-ttu-id="f63f0-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="f63f0-190">Forbidden</span></span> | <span data-ttu-id="f63f0-191">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f63f0-191">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="f63f0-192">404</span><span class="sxs-lookup"><span data-stu-id="f63f0-192">404</span></span>| <span data-ttu-id="f63f0-193">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="f63f0-193">Not Found</span></span> | <span data-ttu-id="f63f0-194">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="f63f0-194">The caller does not have access to the resource.</span></span> <span data-ttu-id="f63f0-195">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-195">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="f63f0-196">412</span><span class="sxs-lookup"><span data-stu-id="f63f0-196">412</span></span>| <span data-ttu-id="f63f0-197">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="f63f0-197">Precondition Failed</span></span> | <span data-ttu-id="f63f0-198">一覧のバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-198">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="f63f0-199">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-199">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="f63f0-200">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-200">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="f63f0-201">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-201">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="f63f0-202">500</span><span class="sxs-lookup"><span data-stu-id="f63f0-202">500</span></span>| <span data-ttu-id="f63f0-203">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="f63f0-203">Internal Server Error</span></span> | <span data-ttu-id="f63f0-204">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="f63f0-204">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="f63f0-205">501</span><span class="sxs-lookup"><span data-stu-id="f63f0-205">501</span></span>| <span data-ttu-id="f63f0-206">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="f63f0-206">Not Implemented</span></span> | <span data-ttu-id="f63f0-207">呼び出し元では、サーバーで実装されていないする URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-207">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="f63f0-208">(現在だけの場合、要求の対象となるがホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="f63f0-208">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="f63f0-209">503</span><span class="sxs-lookup"><span data-stu-id="f63f0-209">503</span></span>| <span data-ttu-id="f63f0-210">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="f63f0-210">Service Unavailable</span></span> | <span data-ttu-id="f63f0-211">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="f63f0-211">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="f63f0-212">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-212">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4E1BAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="f63f0-213">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f63f0-213">Required Request Headers</span></span>
 
| <span data-ttu-id="f63f0-214">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f63f0-214">Header</span></span>| <span data-ttu-id="f63f0-215">説明</span><span class="sxs-lookup"><span data-stu-id="f63f0-215">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f63f0-216">Authorization</span><span class="sxs-lookup"><span data-stu-id="f63f0-216">Authorization</span></span>| <span data-ttu-id="f63f0-217">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f63f0-217">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="f63f0-218">トークンが XSTS サービスからし、要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f63f0-218">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="f63f0-219">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="f63f0-219">X-XBL-Contract-Version</span></span>| <span data-ttu-id="f63f0-220">API のバージョンが要求された (正の整数) をされているかを指定します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-220">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="f63f0-221">バージョン 2 のサポートのピン留めします。</span><span class="sxs-lookup"><span data-stu-id="f63f0-221">Pins supports version 2.</span></span> <span data-ttu-id="f63f0-222">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="f63f0-222">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="f63f0-223">Content-Type</span><span class="sxs-lookup"><span data-stu-id="f63f0-223">Content-Type</span></span>| <span data-ttu-id="f63f0-224">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-224">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="f63f0-225">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="f63f0-225">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="f63f0-226">If-Match</span><span class="sxs-lookup"><span data-stu-id="f63f0-226">If-Match</span></span>| <span data-ttu-id="f63f0-227">このヘッダーは、変更要求を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f63f0-227">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="f63f0-228">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-228">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="f63f0-229">"If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="f63f0-229">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="f63f0-230">(省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョン、リスト データがない HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="f63f0-230">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EQDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="f63f0-231">応答本文</span><span class="sxs-lookup"><span data-stu-id="f63f0-231">Response body</span></span> 
 
<span data-ttu-id="f63f0-232">呼び出しが成功した場合は、サービスは、一覧の最新のメタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="f63f0-232">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4E1DAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="f63f0-233">応答の例</span><span class="sxs-lookup"><span data-stu-id="f63f0-233">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="f63f0-234">関連項目</span><span class="sxs-lookup"><span data-stu-id="f63f0-234">See also</span></span>
 
<a id="ID4EKEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f63f0-235">Parent</span><span class="sxs-lookup"><span data-stu-id="f63f0-235">Parent</span></span> 

[<span data-ttu-id="f63f0-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="f63f0-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>](uri-usersxuidlistspinslistnameindex.md)

   