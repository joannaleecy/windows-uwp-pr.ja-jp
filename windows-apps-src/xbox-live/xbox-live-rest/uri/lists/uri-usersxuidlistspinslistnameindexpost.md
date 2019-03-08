---
title: POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}
assetID: df61be42-c229-7408-5e4c-dbf4ae95b52b
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameindexpost.html
description: " POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7711beee6551c40afe1afcb031278484a3dc5820
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627467"
---
# <a name="post-usersxuidxuidlistspinslistnameindexindexinsertindexinsertindex"></a><span data-ttu-id="6c6d6-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="6c6d6-104">POST /users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>
<span data-ttu-id="6c6d6-105">リストの項目を一覧内の別の位置に移動します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-105">Moves an item in a list to a different position within the list.</span></span> <span data-ttu-id="6c6d6-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="6c6d6-107">注釈</span><span class="sxs-lookup"><span data-stu-id="6c6d6-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="6c6d6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c6d6-108">URI parameters</span></span>](#ID4EEB)
  * [<span data-ttu-id="6c6d6-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c6d6-109">Query string parameters</span></span>](#ID4EWC)
  * [<span data-ttu-id="6c6d6-110">要求本文</span><span class="sxs-lookup"><span data-stu-id="6c6d6-110">Request body</span></span>](#ID4EVD)
  * [<span data-ttu-id="6c6d6-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="6c6d6-111">HTTP status codes</span></span>](#ID4EEE)
  * [<span data-ttu-id="6c6d6-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6c6d6-112">Required Request Headers</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="6c6d6-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="6c6d6-113">Response body</span></span>](#ID4EQDAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="6c6d6-114">注釈</span><span class="sxs-lookup"><span data-stu-id="6c6d6-114">Remarks</span></span> 
 
<span data-ttu-id="6c6d6-115">この呼び出しは、クライアントは、1 回の操作で、一覧内の別のインデックスに項目を簡単に移動できるように提供されています。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-115">This call is provided to allow the client to easily move an item to a different index within the list in a single operation.</span></span> <span data-ttu-id="6c6d6-116">一度に 1 つの項目を移動する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-116">Only one item may be moved at a time.</span></span> <span data-ttu-id="6c6d6-117">移動する項目のインデックスが存在しない場合は、HTTP 400 が返されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-117">If the index of the item to be moved does not exist then an HTTP 400 will be returned.</span></span> <span data-ttu-id="6c6d6-118">カーソル位置のインデックスでは、標準的な挿入と同じ規則に従います。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-118">The index for the insertion point follows the same rules as a standard insert.</span></span> <span data-ttu-id="6c6d6-119">0 – リストの先頭に既定では、リスト内の項目の数よりも大きい任意の数は、リストの末尾にある項目を再挿入します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-119">It will default to 0 – the beginning of the list and any number greater than the number of items in the list will re-insert the item at the end of the list.</span></span> <span data-ttu-id="6c6d6-120">同様に"end"insertIndex を渡すことによって、リストの末尾を指示できます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-120">Similarly the end of the list can be indicated by passing "end" for insertIndex.</span></span> 
 
<span data-ttu-id="6c6d6-121">この呼び出しでは、itemid である (またはプロバイダー/providerId コンボ) で移動するアイテムを識別することもできます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-121">This call also allows you to identify the item to be moved by the itemId (or provider/providerId combo).</span></span> <span data-ttu-id="6c6d6-122">ここでは、要求の本文に、itemId を渡す必要があるし、リスト内の既存の項目に一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-122">In this case, the itemId must be passed in the body of the request and it must match an existing item in the list.</span></span> <span data-ttu-id="6c6d6-123">その場合はの説明で IndexOutOfRange で HTTP 400 エラーが返されます呼び出しのこの特殊なバージョンでは、移動する項目のインデックスとして「-1」を使用します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-123">If it does not, an HTTP 400 error will be returned with IndexOutOfRange in the description; for this special version of the call, use "-1" as the index of the item to be moved.</span></span> 
 
<span data-ttu-id="6c6d6-124">この呼び出しが必要です、"場合に一致: versionNumber"に含まれる要求の項目を指定する場合は、インデックスを使用してヘッダー。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-124">This call requires an "If-Match:versionNumber" header to be included in the request if specifying the item by index.</span></span> <span data-ttu-id="6c6d6-125">ItemId を移動するには、どの項目を示すためを使用して場合、"If-match"ヘッダーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-125">If using itemId to indicate which item to move, then the "If-Match" header is optional.</span></span> <span data-ttu-id="6c6d6-126">存在する場合、"If-match"ヘッダーは常に検証されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-126">If present, the "If-Match" header will always be validated.</span></span> <span data-ttu-id="6c6d6-127">"If-match"ヘッダーを次のメッセージは、リストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-127">In the "if-Match" header, the versionNumber is the current version number of the list.</span></span> <span data-ttu-id="6c6d6-128">かどうかはないに含まれる (および必要な)、または現在に一致しないリストのバージョン番号、HTTP 412 – precondition 失敗のステータス コードが返され、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます.</span><span class="sxs-lookup"><span data-stu-id="6c6d6-128">If it is not included (and required), or does not match the current list version number, then an HTTP 412 – precondition failed status code will be returned and the body of the response will contain the latest metadata of the list which includes the current version number.</span></span> <span data-ttu-id="6c6d6-129">これは相互に踏み潰すさまざまなクライアントからの更新プログラムから保護するためです。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-129">This is done to guard against updates from different clients trampling on each other.</span></span> 
  
<a id="ID4EEB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="6c6d6-130">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c6d6-130">URI parameters</span></span> 
 
| <span data-ttu-id="6c6d6-131">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c6d6-131">Parameter</span></span>| <span data-ttu-id="6c6d6-132">種類</span><span class="sxs-lookup"><span data-stu-id="6c6d6-132">Type</span></span>| <span data-ttu-id="6c6d6-133">説明</span><span class="sxs-lookup"><span data-stu-id="6c6d6-133">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6c6d6-134">XUID</span><span class="sxs-lookup"><span data-stu-id="6c6d6-134">XUID</span></span>| <span data-ttu-id="6c6d6-135">string</span><span class="sxs-lookup"><span data-stu-id="6c6d6-135">string</span></span>| <span data-ttu-id="6c6d6-136">ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-136">XUID of the user.</span></span>| 
| <span data-ttu-id="6c6d6-137">listname</span><span class="sxs-lookup"><span data-stu-id="6c6d6-137">listname</span></span>| <span data-ttu-id="6c6d6-138">string</span><span class="sxs-lookup"><span data-stu-id="6c6d6-138">string</span></span>| <span data-ttu-id="6c6d6-139">操作するリストの名前。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-139">Name of the list to manipulate.</span></span>| 
| <span data-ttu-id="6c6d6-140">インデックス</span><span class="sxs-lookup"><span data-stu-id="6c6d6-140">index</span></span>| <span data-ttu-id="6c6d6-141">string</span><span class="sxs-lookup"><span data-stu-id="6c6d6-141">string</span></span>| <span data-ttu-id="6c6d6-142">移動するアイテムの現在のインデックスを指定します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-142">Specifies the current index of the item to be moved.</span></span> <span data-ttu-id="6c6d6-143">インデックス値が 0 または正の整数の場合は、これは、項目の現在のインデックスを呼び出しの要求本文を空にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-143">If the index value is zero or a positive integer, this refers to the current index of the item, and the request body of the call should be empty.</span></span> <span data-ttu-id="6c6d6-144">ただし、インデックス値が「-1」の場合は、ItemId またはプロバイダー/ProviderID 呼び出しの要求本文内で移動する項目を指定してください。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-144">However, if the index value is "-1", the item to be moved must be specified by ItemId or Provider/ProviderID in the request body of the call.</span></span>| 
  
<a id="ID4EWC"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="6c6d6-145">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c6d6-145">Query string parameters</span></span> 
 
| <span data-ttu-id="6c6d6-146">パラメーター</span><span class="sxs-lookup"><span data-stu-id="6c6d6-146">Parameter</span></span>| <span data-ttu-id="6c6d6-147">種類</span><span class="sxs-lookup"><span data-stu-id="6c6d6-147">Type</span></span>| <span data-ttu-id="6c6d6-148">説明</span><span class="sxs-lookup"><span data-stu-id="6c6d6-148">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6c6d6-149">insertIndex</span><span class="sxs-lookup"><span data-stu-id="6c6d6-149">insertIndex</span></span>| <span data-ttu-id="6c6d6-150">string</span><span class="sxs-lookup"><span data-stu-id="6c6d6-150">string</span></span>| <span data-ttu-id="6c6d6-151">項目を挿入するリストの場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-151">Specifies the list location to insert the item.</span></span> <span data-ttu-id="6c6d6-152">使用できる値は 0、正の整数、および"end"は。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-152">Allowed values are zero, positive integers, and "end".</span></span> <span data-ttu-id="6c6d6-153">"end"では、現在のリストの末尾に項目を配置します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-153">"end" places the item at the end of the current list.</span></span> <span data-ttu-id="6c6d6-154">指定した値がリストの末尾を越える場合は、項目は、リストの末尾に挿入されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-154">If the specified value is beyond the end of the list, the item is inserted at the end of the list.</span></span> | 
  
<a id="ID4EVD"></a>

 
## <a name="request-body"></a><span data-ttu-id="6c6d6-155">要求本文</span><span class="sxs-lookup"><span data-stu-id="6c6d6-155">Request body</span></span> 
 
<span data-ttu-id="6c6d6-156">要求本文は itemid であるか、プロバイダー/ProviderId を移動するアイテムを指定する場合にのみ送信されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-156">A request body is sent only when specifying the item to move by itemId or by Provider/ProviderId.</span></span>
 
<a id="ID4E6D"></a>

  
<span data-ttu-id="6c6d6-157">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="6c6d6-157">Sample Request</span></span> 

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

 
## <a name="http-status-codes"></a><span data-ttu-id="6c6d6-158">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="6c6d6-158">HTTP status codes</span></span> 
 
<span data-ttu-id="6c6d6-159">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-159">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="6c6d6-160">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-160">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="6c6d6-161">コード</span><span class="sxs-lookup"><span data-stu-id="6c6d6-161">Code</span></span>| <span data-ttu-id="6c6d6-162">理由語句</span><span class="sxs-lookup"><span data-stu-id="6c6d6-162">Reason phrase</span></span>| <span data-ttu-id="6c6d6-163">説明</span><span class="sxs-lookup"><span data-stu-id="6c6d6-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6c6d6-164">200</span><span class="sxs-lookup"><span data-stu-id="6c6d6-164">200</span></span>| <span data-ttu-id="6c6d6-165">OK</span><span class="sxs-lookup"><span data-stu-id="6c6d6-165">OK</span></span> | <span data-ttu-id="6c6d6-166">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-166">The request completed successfully.</span></span> <span data-ttu-id="6c6d6-167">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-167">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="6c6d6-168">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-168">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="6c6d6-169">201</span><span class="sxs-lookup"><span data-stu-id="6c6d6-169">201</span></span>| <span data-ttu-id="6c6d6-170">作成日</span><span class="sxs-lookup"><span data-stu-id="6c6d6-170">Created</span></span> | <span data-ttu-id="6c6d6-171">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-171">A new list has been created.</span></span> <span data-ttu-id="6c6d6-172">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-172">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="6c6d6-173">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-173">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="6c6d6-174">304</span><span class="sxs-lookup"><span data-stu-id="6c6d6-174">304</span></span>| <span data-ttu-id="6c6d6-175">変更されていません</span><span class="sxs-lookup"><span data-stu-id="6c6d6-175">Not Modified</span></span>| <span data-ttu-id="6c6d6-176">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-176">Returned on GETs.</span></span> <span data-ttu-id="6c6d6-177">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-177">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="6c6d6-178">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-178">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="6c6d6-179">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-179">If they are equal, then a 304 gets returned with no data.</span></span> | 
| <span data-ttu-id="6c6d6-180">400</span><span class="sxs-lookup"><span data-stu-id="6c6d6-180">400</span></span>| <span data-ttu-id="6c6d6-181">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="6c6d6-181">Bad Request</span></span> | <span data-ttu-id="6c6d6-182">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-182">The request was malformed.</span></span> <span data-ttu-id="6c6d6-183">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-183">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="6c6d6-184">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-184">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="6c6d6-185">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-185">See the <b>X-XBL-Contract-Version</b> header.</span></span> | 
| <span data-ttu-id="6c6d6-186">401</span><span class="sxs-lookup"><span data-stu-id="6c6d6-186">401</span></span>| <span data-ttu-id="6c6d6-187">権限がありません</span><span class="sxs-lookup"><span data-stu-id="6c6d6-187">Unauthorized</span></span> | <span data-ttu-id="6c6d6-188">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-188">The request requires user authentication.</span></span>| 
| <span data-ttu-id="6c6d6-189">403</span><span class="sxs-lookup"><span data-stu-id="6c6d6-189">403</span></span>| <span data-ttu-id="6c6d6-190">Forbidden</span><span class="sxs-lookup"><span data-stu-id="6c6d6-190">Forbidden</span></span> | <span data-ttu-id="6c6d6-191">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-191">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="6c6d6-192">404</span><span class="sxs-lookup"><span data-stu-id="6c6d6-192">404</span></span>| <span data-ttu-id="6c6d6-193">検出不可</span><span class="sxs-lookup"><span data-stu-id="6c6d6-193">Not Found</span></span> | <span data-ttu-id="6c6d6-194">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-194">The caller does not have access to the resource.</span></span> <span data-ttu-id="6c6d6-195">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-195">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="6c6d6-196">412</span><span class="sxs-lookup"><span data-stu-id="6c6d6-196">412</span></span>| <span data-ttu-id="6c6d6-197">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="6c6d6-197">Precondition Failed</span></span> | <span data-ttu-id="6c6d6-198">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-198">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="6c6d6-199">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-199">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="6c6d6-200">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-200">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="6c6d6-201">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-201">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span> | 
| <span data-ttu-id="6c6d6-202">500</span><span class="sxs-lookup"><span data-stu-id="6c6d6-202">500</span></span>| <span data-ttu-id="6c6d6-203">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="6c6d6-203">Internal Server Error</span></span> | <span data-ttu-id="6c6d6-204">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-204">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="6c6d6-205">501</span><span class="sxs-lookup"><span data-stu-id="6c6d6-205">501</span></span>| <span data-ttu-id="6c6d6-206">実装されていません</span><span class="sxs-lookup"><span data-stu-id="6c6d6-206">Not Implemented</span></span> | <span data-ttu-id="6c6d6-207">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-207">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="6c6d6-208">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="6c6d6-208">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="6c6d6-209">503</span><span class="sxs-lookup"><span data-stu-id="6c6d6-209">503</span></span>| <span data-ttu-id="6c6d6-210">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="6c6d6-210">Service Unavailable</span></span> | <span data-ttu-id="6c6d6-211">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-211">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="6c6d6-212">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-212">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span> | 
  
<a id="ID4E1BAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="6c6d6-213">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="6c6d6-213">Required Request Headers</span></span>
 
| <span data-ttu-id="6c6d6-214">Header</span><span class="sxs-lookup"><span data-stu-id="6c6d6-214">Header</span></span>| <span data-ttu-id="6c6d6-215">説明</span><span class="sxs-lookup"><span data-stu-id="6c6d6-215">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="6c6d6-216">Authorization</span><span class="sxs-lookup"><span data-stu-id="6c6d6-216">Authorization</span></span>| <span data-ttu-id="6c6d6-217">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-217">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="6c6d6-218">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-218">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="6c6d6-219">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="6c6d6-219">X-XBL-Contract-Version</span></span>| <span data-ttu-id="6c6d6-220">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-220">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="6c6d6-221">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-221">Pins supports version 2.</span></span> <span data-ttu-id="6c6d6-222">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-222">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="6c6d6-223">Content-Type</span><span class="sxs-lookup"><span data-stu-id="6c6d6-223">Content-Type</span></span>| <span data-ttu-id="6c6d6-224">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-224">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="6c6d6-225">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="6c6d6-225">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="6c6d6-226">If-Match</span><span class="sxs-lookup"><span data-stu-id="6c6d6-226">If-Match</span></span>| <span data-ttu-id="6c6d6-227">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-227">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="6c6d6-228">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-228">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="6c6d6-229">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-229">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="6c6d6-230">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-230">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EQDAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="6c6d6-231">応答本文</span><span class="sxs-lookup"><span data-stu-id="6c6d6-231">Response body</span></span> 
 
<span data-ttu-id="6c6d6-232">呼び出しが成功した場合、サービスは、最新の一覧については、メタデータを返します。</span><span class="sxs-lookup"><span data-stu-id="6c6d6-232">If the call is successful, the service returns the latest metadata for the list.</span></span> 
 
<a id="ID4E1DAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="6c6d6-233">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="6c6d6-233">Sample response</span></span> 
 

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

 
## <a name="see-also"></a><span data-ttu-id="6c6d6-234">関連項目</span><span class="sxs-lookup"><span data-stu-id="6c6d6-234">See also</span></span>
 
<a id="ID4EKEAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6c6d6-235">Parent</span><span class="sxs-lookup"><span data-stu-id="6c6d6-235">Parent</span></span> 

[<span data-ttu-id="6c6d6-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span><span class="sxs-lookup"><span data-stu-id="6c6d6-236">/users/xuid(xuid)/lists/PINS/{listname}/index({index})?insertIndex={insertIndex}</span></span>](uri-usersxuidlistspinslistnameindex.md)

   