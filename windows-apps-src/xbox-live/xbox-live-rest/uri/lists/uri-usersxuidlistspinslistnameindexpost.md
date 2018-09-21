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
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4083620"
---
# <a name="post-usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a><span data-ttu-id="f2fb3-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="f2fb3-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>
<span data-ttu-id="f2fb3-105">リスト項目をリスト内の異なる位置に移動します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-105">Moves an item in a list to a different position within the list.</span></span> <span data-ttu-id="f2fb3-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f2fb3-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f2fb3-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="f2fb3-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2fb3-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="f2fb3-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2fb3-109">Query string parameters</span></span>](#ID4EWC)
  * [<span data-ttu-id="f2fb3-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="f2fb3-110">Request body</span></span>](#ID4EVD)
  * [<span data-ttu-id="f2fb3-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f2fb3-111">HTTP status codes</span></span>](#ID4EEE)
  * [<span data-ttu-id="f2fb3-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2fb3-112">Required Request Headers</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="f2fb3-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="f2fb3-113">Response body</span></span>](#ID4EQDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="f2fb3-114">注釈</span><span class="sxs-lookup"><span data-stu-id="f2fb3-114">Remarks</span></span> 
 
<span data-ttu-id="f2fb3-115">この呼び出しは、クライアントが単一の操作でリスト内のさまざまなインデックスに項目を簡単に移動できる提供されています。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-115">This call is provided to allow the client to easily move an item to a different index within the list in a single operation.</span></span> <span data-ttu-id="f2fb3-116">一度に 1 つの項目を移動する場合があります。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-116">Only one item may be moved at a time.</span></span> <span data-ttu-id="f2fb3-117">移動する項目のインデックスが存在しない場合は、HTTP 400 が返されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-117">If the index of the item to be moved does not exist then an HTTP 400 will be returned.</span></span> <span data-ttu-id="f2fb3-118">挿入ポイントのインデックスは、標準的な挿入と同じ規則に従います。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-118">The index for the insertion point follows the same rules as a standard insert.</span></span> <span data-ttu-id="f2fb3-119">既定値は 0 ~ リストの先頭と、リスト内の項目数よりも大きい任意の数は、一覧の最後の項目を再挿入します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-119">It will default to 0 – the beginning of the list and any number greater than the number of items in the list will re-insert the item at the end of the list.</span></span> <span data-ttu-id="f2fb3-120">同様に insertIndex の「終了」を渡すことによって、リストの末尾を示すことができます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-120">Similarly the end of the list can be indicated by passing "end" for insertIndex.</span></span> 
 
<span data-ttu-id="f2fb3-121">この呼び出しでは、itemId (またはプロバイダー/providerId コンボ) によって移動する項目を識別することもできます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-121">This call also allows you to identify the item to be moved by the itemId (or provider/providerId combo).</span></span> <span data-ttu-id="f2fb3-122">この場合、要求の本文で、itemId を渡す必要があります、リスト内の既存の項目に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-122">In this case, the itemId must be passed in the body of the request and it must match an existing item in the list.</span></span> <span data-ttu-id="f2fb3-123">その場合は、説明; IndexOutOfRange でエラーが返される、HTTP 400この特別なバージョンの呼び出しを移動する項目のインデックスとして「-1」を使用します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-123">If it does not, an HTTP 400 error will be returned with IndexOutOfRange in the description; for this special version of the call, use "-1" as the index of the item to be moved.</span></span> 
 
<span data-ttu-id="f2fb3-124">この呼び出しが必要とする"場合-マッチ: versionNumber"ヘッダーに含まれる要求で項目を指定する場合は、インデックスをします。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-124">This call requires an "If-Match:versionNumber" header to be included in the request if specifying the item by index.</span></span> <span data-ttu-id="f2fb3-125">使って場合 itemId を移動するには、どの項目を示すために、"If-match"ヘッダーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-125">If using itemId to indicate which item to move, then the "If-Match" header is optional.</span></span> <span data-ttu-id="f2fb3-126">存在する場合、"If-match"ヘッダーが常に検証されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-126">If present, the "If-Match" header will always be validated.</span></span> <span data-ttu-id="f2fb3-127">"If-match"ヘッダーで、versionNumber はリストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-127">In the "if-Match" header, the versionNumber is the current version number of the list.</span></span> <span data-ttu-id="f2fb3-128">かどうかはない含まれている (および必須)、または、現在は一致しない一覧のバージョン番号、http/412 – の前提条件が失敗の状態コードが返され、応答の本文には現在のバージョン番号が含まれている一覧の最新のメタデータが含まれています.</span><span class="sxs-lookup"><span data-stu-id="f2fb3-128">If it is not included (and required), or does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="f2fb3-129">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐため。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-129">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f2fb3-130">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2fb3-130">URI parameters</span></span> 
 
| <span data-ttu-id="f2fb3-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2fb3-131">Parameter</span></span>| <span data-ttu-id="f2fb3-132">型</span><span class="sxs-lookup"><span data-stu-id="f2fb3-132">Type</span></span>| <span data-ttu-id="f2fb3-133">説明</span><span class="sxs-lookup"><span data-stu-id="f2fb3-133">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f2fb3-134">XUID</span><span class="sxs-lookup"><span data-stu-id="f2fb3-134">XUID</span></span>| <span data-ttu-id="f2fb3-135">string</span><span class="sxs-lookup"><span data-stu-id="f2fb3-135">string</span></span>| <span data-ttu-id="f2fb3-136">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-136">XUID of the user.</span></span>| 
| <span data-ttu-id="f2fb3-137">リスト</span><span class="sxs-lookup"><span data-stu-id="f2fb3-137">listname</span></span>| <span data-ttu-id="f2fb3-138">string</span><span class="sxs-lookup"><span data-stu-id="f2fb3-138">string</span></span>| <span data-ttu-id="f2fb3-139">操作をするリストの名前。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-139">Name of the list to manipulate.</span></span>| 
| <span data-ttu-id="f2fb3-140">インデックス</span><span class="sxs-lookup"><span data-stu-id="f2fb3-140">index</span></span>| <span data-ttu-id="f2fb3-141">string</span><span class="sxs-lookup"><span data-stu-id="f2fb3-141">string</span></span>| <span data-ttu-id="f2fb3-142">移動する項目の現在のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-142">Specifies the current index of the item to be moved.</span></span> <span data-ttu-id="f2fb3-143">インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを参照し、呼び出しの要求本文は空にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-143">If the index value is zero or a positive integer, this refers to the current index of the item, and the request body of the call should be empty.</span></span> <span data-ttu-id="f2fb3-144">ただし、インデックス値が「-1」の場合、ItemId または呼び出しの要求本文には、プロバイダー/ProviderID によって移動する項目を指定してください。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-144">However, if the index value is "-1", the item to be moved must be specified by ItemId or Provider/ProviderID in the request body of the call.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="f2fb3-145">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2fb3-145">Query string parameters</span></span> 
 
| <span data-ttu-id="f2fb3-146">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f2fb3-146">Parameter</span></span>| <span data-ttu-id="f2fb3-147">型</span><span class="sxs-lookup"><span data-stu-id="f2fb3-147">Type</span></span>| <span data-ttu-id="f2fb3-148">説明</span><span class="sxs-lookup"><span data-stu-id="f2fb3-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f2fb3-149">insertIndex</span><span class="sxs-lookup"><span data-stu-id="f2fb3-149">insertIndex</span></span>| <span data-ttu-id="f2fb3-150">string</span><span class="sxs-lookup"><span data-stu-id="f2fb3-150">string</span></span>| <span data-ttu-id="f2fb3-151">項目を挿入する一覧の場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-151">Specifies the list location to insert the item.</span></span> <span data-ttu-id="f2fb3-152">許容値は、0、正の整数「終了」です。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-152">Allowed values are zero, positive integers, and "end".</span></span> <span data-ttu-id="f2fb3-153">「終了」は、現在のリストの最後に、項目を配置します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-153">"end" places the item at the end of the current list.</span></span> <span data-ttu-id="f2fb3-154">指定された値がリストの最後を超える場合は、リストの最後に、項目が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-154">If the specified value is beyond the end of the list, the item is inserted at the end of the list.</span></span> | 
  
<a id="ID4EVD"></a>

 
## <a name="request-body"></a><span data-ttu-id="f2fb3-155">要求本文</span><span class="sxs-lookup"><span data-stu-id="f2fb3-155">Request body</span></span> 
 
<span data-ttu-id="f2fb3-156">要求本文は itemId またはプロバイダー/ProviderId を移動する項目を指定するときにのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-156">A request body is sent only when specifying the item to move by itemId or by Provider/ProviderId.</span></span>
 
<a id="ID4E6D"></a>

  
<span data-ttu-id="f2fb3-157">要求の例</span><span class="sxs-lookup"><span data-stu-id="f2fb3-157">Sample Request</span></span> 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="f2fb3-158">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="f2fb3-158">HTTP status codes</span></span> 
 
<span data-ttu-id="f2fb3-159">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-159">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="f2fb3-160">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-160">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="f2fb3-161">コード</span><span class="sxs-lookup"><span data-stu-id="f2fb3-161">Code</span></span>| <span data-ttu-id="f2fb3-162">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="f2fb3-162">Reason phrase</span></span>| <span data-ttu-id="f2fb3-163">説明</span><span class="sxs-lookup"><span data-stu-id="f2fb3-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f2fb3-164">200</span><span class="sxs-lookup"><span data-stu-id="f2fb3-164">200</span></span>| <span data-ttu-id="f2fb3-165">OK</span><span class="sxs-lookup"><span data-stu-id="f2fb3-165">OK</span></span> | <span data-ttu-id="f2fb3-166">要求が正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-166">The request completed successfully.</span></span> <span data-ttu-id="f2fb3-167">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-167">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="f2fb3-168">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-168">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="f2fb3-169">201</span><span class="sxs-lookup"><span data-stu-id="f2fb3-169">201</span></span>| <span data-ttu-id="f2fb3-170">Created</span><span class="sxs-lookup"><span data-stu-id="f2fb3-170">Created</span></span> | <span data-ttu-id="f2fb3-171">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-171">A new list has been created.</span></span> <span data-ttu-id="f2fb3-172">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-172">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="f2fb3-173">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-173">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="f2fb3-174">304</span><span class="sxs-lookup"><span data-stu-id="f2fb3-174">304</span></span>| <span data-ttu-id="f2fb3-175">Not Modified</span><span class="sxs-lookup"><span data-stu-id="f2fb3-175">Not Modified</span></span>| <span data-ttu-id="f2fb3-176">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-176">Returned on GETs.</span></span> <span data-ttu-id="f2fb3-177">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-177">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="f2fb3-178">サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-178">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="f2fb3-179">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-179">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="f2fb3-180">400</span><span class="sxs-lookup"><span data-stu-id="f2fb3-180">400</span></span>| <span data-ttu-id="f2fb3-181">Bad Request</span><span class="sxs-lookup"><span data-stu-id="f2fb3-181">Bad Request</span></span> | <span data-ttu-id="f2fb3-182">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-182">The request was malformed.</span></span> <span data-ttu-id="f2fb3-183">無効な値または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-183">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="f2fb3-184">不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-184">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="f2fb3-185"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-185">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="f2fb3-186">401</span><span class="sxs-lookup"><span data-stu-id="f2fb3-186">401</span></span>| <span data-ttu-id="f2fb3-187">権限がありません</span><span class="sxs-lookup"><span data-stu-id="f2fb3-187">Unauthorized</span></span> | <span data-ttu-id="f2fb3-188">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-188">The request requires user authentication.</span></span>| 
| <span data-ttu-id="f2fb3-189">403</span><span class="sxs-lookup"><span data-stu-id="f2fb3-189">403</span></span>| <span data-ttu-id="f2fb3-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="f2fb3-190">Forbidden</span></span> | <span data-ttu-id="f2fb3-191">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-191">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="f2fb3-192">404</span><span class="sxs-lookup"><span data-stu-id="f2fb3-192">404</span></span>| <span data-ttu-id="f2fb3-193">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-193">Not Found</span></span> | <span data-ttu-id="f2fb3-194">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-194">The caller does not have access to the resource.</span></span> <span data-ttu-id="f2fb3-195">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-195">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="f2fb3-196">412</span><span class="sxs-lookup"><span data-stu-id="f2fb3-196">412</span></span>| <span data-ttu-id="f2fb3-197">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="f2fb3-197">Precondition Failed</span></span> | <span data-ttu-id="f2fb3-198">一覧のバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-198">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="f2fb3-199">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-199">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="f2fb3-200">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-200">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="f2fb3-201">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-201">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="f2fb3-202">500</span><span class="sxs-lookup"><span data-stu-id="f2fb3-202">500</span></span>| <span data-ttu-id="f2fb3-203">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="f2fb3-203">Internal Server Error</span></span> | <span data-ttu-id="f2fb3-204">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-204">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="f2fb3-205">501</span><span class="sxs-lookup"><span data-stu-id="f2fb3-205">501</span></span>| <span data-ttu-id="f2fb3-206">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-206">Not Implemented</span></span> | <span data-ttu-id="f2fb3-207">呼び出し元がサーバーに実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-207">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="f2fb3-208">(現在のみを使用するとき、要求の対象となるがないホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="f2fb3-208">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="f2fb3-209">503</span><span class="sxs-lookup"><span data-stu-id="f2fb3-209">503</span></span>| <span data-ttu-id="f2fb3-210">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="f2fb3-210">Service Unavailable</span></span> | <span data-ttu-id="f2fb3-211">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-211">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="f2fb3-212">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-212">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4E1BAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="f2fb3-213">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2fb3-213">Required Request Headers</span></span>
 
| <span data-ttu-id="f2fb3-214">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f2fb3-214">Header</span></span>| <span data-ttu-id="f2fb3-215">説明</span><span class="sxs-lookup"><span data-stu-id="f2fb3-215">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f2fb3-216">Authorization</span><span class="sxs-lookup"><span data-stu-id="f2fb3-216">Authorization</span></span>| <span data-ttu-id="f2fb3-217">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-217">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="f2fb3-218">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-218">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="f2fb3-219">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="f2fb3-219">X-XBL-Contract-Version</span></span>| <span data-ttu-id="f2fb3-220">要求された (正の整数) をされている API のバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-220">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="f2fb3-221">ピンのサポート バージョン 2 です。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-221">Pins supports version 2.</span></span> <span data-ttu-id="f2fb3-222">このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-222">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="f2fb3-223">Content-Type</span><span class="sxs-lookup"><span data-stu-id="f2fb3-223">Content-Type</span></span>| <span data-ttu-id="f2fb3-224">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-224">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="f2fb3-225">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="f2fb3-225">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="f2fb3-226">If-Match</span><span class="sxs-lookup"><span data-stu-id="f2fb3-226">If-Match</span></span>| <span data-ttu-id="f2fb3-227">このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-227">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="f2fb3-228">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-228">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="f2fb3-229">"If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-229">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="f2fb3-230">(省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-230">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EQDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="f2fb3-231">応答本文</span><span class="sxs-lookup"><span data-stu-id="f2fb3-231">Response body</span></span> 
 
<span data-ttu-id="f2fb3-232">呼び出しが成功した場合は、サービスは、一覧の最新のメタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="f2fb3-232">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4E1DAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="f2fb3-233">応答の例</span><span class="sxs-lookup"><span data-stu-id="f2fb3-233">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="f2fb3-234">関連項目</span><span class="sxs-lookup"><span data-stu-id="f2fb3-234">See also</span></span>
 
<a id="ID4EKEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f2fb3-235">Parent</span><span class="sxs-lookup"><span data-stu-id="f2fb3-235">Parent</span></span> 

[<span data-ttu-id="f2fb3-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="f2fb3-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>](uri-usersxuidlistspinslistnameindex.md)

   