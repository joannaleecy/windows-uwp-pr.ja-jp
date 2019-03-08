---
title: PUT (/users/xuid(xuid)/lists/PINS/{listname})
assetID: f7964d2e-a8c8-2caa-ca97-e0d76ef586f4
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameput.html
description: " PUT (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 35527df28c2ca482d0c5ae2fe25637b3bc29f6ca
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622927"
---
# <a name="put-usersxuidxuidlistspinslistname"></a><span data-ttu-id="f3fe0-104">PUT (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="f3fe0-104">PUT (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="f3fe0-105">要求本文内の各項目に指定されたインデックスによってリスト内の項目を更新します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-105">Updates the items in a list according to the indexes specified for each item in the request body.</span></span> <span data-ttu-id="f3fe0-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="f3fe0-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f3fe0-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="f3fe0-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fe0-108">URI parameters</span></span>](#ID4E1B)
  * [<span data-ttu-id="f3fe0-109">承認</span><span class="sxs-lookup"><span data-stu-id="f3fe0-109">Authorization</span></span>](#ID4EFC)
  * [<span data-ttu-id="f3fe0-110">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f3fe0-110">HTTP status codes</span></span>](#ID4ESC)
  * [<span data-ttu-id="f3fe0-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f3fe0-111">Required Request Headers</span></span>](#ID4EPH)
  * [<span data-ttu-id="f3fe0-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="f3fe0-112">Request body</span></span>](#ID4EGBAC)
  * [<span data-ttu-id="f3fe0-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="f3fe0-113">Response body</span></span>](#ID4EWBAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="f3fe0-114">注釈</span><span class="sxs-lookup"><span data-stu-id="f3fe0-114">Remarks</span></span>
 
<span data-ttu-id="f3fe0-115">この呼び出しでは、要求本文内の各項目に指定されたインデックスによってリスト内の項目を更新します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-115">This call will update the items in a list according to the indexes specified for each item in the request body.</span></span> <span data-ttu-id="f3fe0-116">この呼び出しは、リストに項目を挿入しないと、指定したインデックスに項目が存在しない場合は、呼び出しが 400 正しくない要求の状態が返します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-116">This call will not insert items into the list, and if items do not exist at the specified indexes, then the call will return a 400 Bad Request status.</span></span> <span data-ttu-id="f3fe0-117">1 回の呼び出しで複数の項目を更新することができますが、すべて現在のリスト内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-117">Multiple items can be updated in a single call, but all must exist in the current list.</span></span> <span data-ttu-id="f3fe0-118">つまり、すべてが更新または更新なし。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-118">That is, all get updated or none get updated.</span></span>
 
<span data-ttu-id="f3fe0-119">この呼び出しによって指定される更新する項目をにより、 **itemId**の代わりに**インデックス**します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-119">This call will allow the item to be updated to be specified by the **itemId** instead of **index**.</span></span> <span data-ttu-id="f3fe0-120">これを行うには、内のインデックスを単に「-1」を使用、 **IndexedItems**サービスに送信される構造体。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-120">To do this, simply use "-1" for the index in the **IndexedItems** structure that is sent to the service.</span></span> <span data-ttu-id="f3fe0-121">ここでは明らかに、 **itemId**更新プログラムの一部として変更できないので、その他のメタデータ フィールドへの変更にのみ機能します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-121">Obviously in this case, the **itemId**  cannot be changed as part of the update, so it will only work for changes to other metadata fields.</span></span> <span data-ttu-id="f3fe0-122">**プロバイダー**/**providerId**コンボはの代わりに使用できる**itemId**項目を識別します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-122">The **provider**/**providerId** combo can be used instead of **itemId** to identify the item.</span></span> <span data-ttu-id="f3fe0-123">内部的には、サービスは、これらのアイテムおよび図を更新する適切なインデックスの一覧を検索します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-123">Internally, the service searches the list for these items and figures out the proper indexes to update.</span></span> <span data-ttu-id="f3fe0-124">項目または項目が見つからない場合は、400 正しくない要求の状態が返され、項目は更新されません。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-124">If the item or items cannot be found then a 400 Bad Request status will be returned and no items will be updated.</span></span>
 
<span data-ttu-id="f3fe0-125">この呼び出しが必要です、**場合に一致: versionNumber**項目を識別するためにインデックスを使用する場合、要求に含まれるヘッダー。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-125">This call requires an **If-Match:versionNumber** header to be included in the request if using indexes to identify items.</span></span> <span data-ttu-id="f3fe0-126">かどうか、項目の項目を識別する Id を使用して (および一覧は、重複を許可しない)、次に、 **If-match**ヘッダーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-126">If using item IDs to identify the items (and the list doesn't allow duplicates), then the **If-Match** header is optional.</span></span> <span data-ttu-id="f3fe0-127">存在する場合、 **If-match**ヘッダーは常に検証されます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-127">If present, the **if-Match** header will always be validated.</span></span> <span data-ttu-id="f3fe0-128">ヘッダーで、 **versionNumber**リストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-128">In the header, the **versionNumber** is the current version number of the list.</span></span> <span data-ttu-id="f3fe0-129">ない一致し、現在のリストのバージョン番号、HTTP 412 Precondition Failed のステータス コードが返される応答の本文が格納されますリストの最新のメタデータがないに含まれる (および必要な)、または現在のバージョン番号を含みます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-129">If it is not included (and required), or does not match the current list version number, then an HTTP 412 Precondition Failed status code will be returned and the body of the response will contain the latest metadata of the list that includes the current version number.</span></span> <span data-ttu-id="f3fe0-130">これは、いずれかの別の踏み潰す別のクライアントからの更新を防ぐ。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-130">This is to guard against updates from different clients trampling on one another.</span></span>
  
<a id="ID4E1B"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="f3fe0-131">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fe0-131">URI parameters</span></span>
 
| <span data-ttu-id="f3fe0-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f3fe0-132">Parameter</span></span>| <span data-ttu-id="f3fe0-133">種類</span><span class="sxs-lookup"><span data-stu-id="f3fe0-133">Type</span></span>| <span data-ttu-id="f3fe0-134">説明</span><span class="sxs-lookup"><span data-stu-id="f3fe0-134">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f3fe0-135">xuid</span><span class="sxs-lookup"><span data-stu-id="f3fe0-135">xuid</span></span>| <span data-ttu-id="f3fe0-136">string</span><span class="sxs-lookup"><span data-stu-id="f3fe0-136">string</span></span>| <span data-ttu-id="f3fe0-137">Xbox のユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-137">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="f3fe0-138">listtype</span><span class="sxs-lookup"><span data-stu-id="f3fe0-138">listtype</span></span>| <span data-ttu-id="f3fe0-139">string</span><span class="sxs-lookup"><span data-stu-id="f3fe0-139">string</span></span>| <span data-ttu-id="f3fe0-140">(その使用方法およびどのように機能します) のリストの種類。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-140">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="f3fe0-141">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-141">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="f3fe0-142">listname</span><span class="sxs-lookup"><span data-stu-id="f3fe0-142">listname</span></span>| <span data-ttu-id="f3fe0-143">string</span><span class="sxs-lookup"><span data-stu-id="f3fe0-143">string</span></span>| <span data-ttu-id="f3fe0-144">リストの名前 (を操作する特定の listtype のどのリスト)。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-144">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="f3fe0-145">常に"XBLPins"の項目のピンです。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-145">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="authorization"></a><span data-ttu-id="f3fe0-146">Authorization</span><span class="sxs-lookup"><span data-stu-id="f3fe0-146">Authorization</span></span>
 
<span data-ttu-id="f3fe0-147">この呼び出しで、XSTS SAML トークンが必要ですが、**承認**ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-147">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="f3fe0-148">Xuid 要求は、呼び出し元を識別するために SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-148">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="f3fe0-149">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-149">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="f3fe0-150">リスト自体も Xuid によって識別され、一覧については、URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-150">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="f3fe0-151">これを使用して今後リストへのアクセスの共有のサポートがする機能ではありません、この時点で。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-151">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="f3fe0-152">現時点では、ユーザーがアクセスするすべてのリストになりますが自分と共有アクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-152">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="f3fe0-153">したがって URI に Xuid は、SAML 要求トークンで Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-153">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="f3fe0-154">現時点では、XBL Auth 2.0 と 3.0 のトークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-154">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4ESC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="f3fe0-155">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="f3fe0-155">HTTP status codes</span></span>
 
<span data-ttu-id="f3fe0-156">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-156">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="f3fe0-157">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-157">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="f3fe0-158">コード</span><span class="sxs-lookup"><span data-stu-id="f3fe0-158">Code</span></span>| <span data-ttu-id="f3fe0-159">理由語句</span><span class="sxs-lookup"><span data-stu-id="f3fe0-159">Reason phrase</span></span>| <span data-ttu-id="f3fe0-160">説明</span><span class="sxs-lookup"><span data-stu-id="f3fe0-160">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f3fe0-161">200</span><span class="sxs-lookup"><span data-stu-id="f3fe0-161">200</span></span>| <span data-ttu-id="f3fe0-162">OK</span><span class="sxs-lookup"><span data-stu-id="f3fe0-162">OK</span></span>| <span data-ttu-id="f3fe0-163">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-163">The request completed successfully.</span></span> <span data-ttu-id="f3fe0-164">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-164">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="f3fe0-165">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-165">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="f3fe0-166">201</span><span class="sxs-lookup"><span data-stu-id="f3fe0-166">201</span></span>| <span data-ttu-id="f3fe0-167">作成日</span><span class="sxs-lookup"><span data-stu-id="f3fe0-167">Created</span></span>| <span data-ttu-id="f3fe0-168">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-168">A new list has been created.</span></span> <span data-ttu-id="f3fe0-169">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-169">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="f3fe0-170">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-170">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="f3fe0-171">304</span><span class="sxs-lookup"><span data-stu-id="f3fe0-171">304</span></span>| <span data-ttu-id="f3fe0-172">変更されていません</span><span class="sxs-lookup"><span data-stu-id="f3fe0-172">Not Modified</span></span>| <span data-ttu-id="f3fe0-173">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-173">Returned on GETs.</span></span> <span data-ttu-id="f3fe0-174">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-174">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="f3fe0-175">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-175">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="f3fe0-176">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-176">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="f3fe0-177">400</span><span class="sxs-lookup"><span data-stu-id="f3fe0-177">400</span></span>| <span data-ttu-id="f3fe0-178">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="f3fe0-178">Bad Request</span></span>| <span data-ttu-id="f3fe0-179">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-179">The request was malformed.</span></span> <span data-ttu-id="f3fe0-180">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-180">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="f3fe0-181">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-181">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="f3fe0-182">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-182">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="f3fe0-183">401</span><span class="sxs-lookup"><span data-stu-id="f3fe0-183">401</span></span>| <span data-ttu-id="f3fe0-184">権限がありません</span><span class="sxs-lookup"><span data-stu-id="f3fe0-184">Unauthorized</span></span>| <span data-ttu-id="f3fe0-185">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-185">The request requires user authentication.</span></span>| 
| <span data-ttu-id="f3fe0-186">403</span><span class="sxs-lookup"><span data-stu-id="f3fe0-186">403</span></span>| <span data-ttu-id="f3fe0-187">Forbidden</span><span class="sxs-lookup"><span data-stu-id="f3fe0-187">Forbidden</span></span>| <span data-ttu-id="f3fe0-188">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-188">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="f3fe0-189">404</span><span class="sxs-lookup"><span data-stu-id="f3fe0-189">404</span></span>| <span data-ttu-id="f3fe0-190">検出不可</span><span class="sxs-lookup"><span data-stu-id="f3fe0-190">Not Found</span></span>| <span data-ttu-id="f3fe0-191">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-191">The caller does not have access to the resource.</span></span> <span data-ttu-id="f3fe0-192">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-192">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="f3fe0-193">412</span><span class="sxs-lookup"><span data-stu-id="f3fe0-193">412</span></span>| <span data-ttu-id="f3fe0-194">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="f3fe0-194">Precondition Failed</span></span>| <span data-ttu-id="f3fe0-195">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-195">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="f3fe0-196">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-196">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="f3fe0-197">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-197">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="f3fe0-198">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-198">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="f3fe0-199">500</span><span class="sxs-lookup"><span data-stu-id="f3fe0-199">500</span></span>| <span data-ttu-id="f3fe0-200">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="f3fe0-200">Internal Server Error</span></span>| <span data-ttu-id="f3fe0-201">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-201">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="f3fe0-202">501</span><span class="sxs-lookup"><span data-stu-id="f3fe0-202">501</span></span>| <span data-ttu-id="f3fe0-203">実装されていません</span><span class="sxs-lookup"><span data-stu-id="f3fe0-203">Not Implemented</span></span>| <span data-ttu-id="f3fe0-204">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-204">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="f3fe0-205">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="f3fe0-205">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="f3fe0-206">503</span><span class="sxs-lookup"><span data-stu-id="f3fe0-206">503</span></span>| <span data-ttu-id="f3fe0-207">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="f3fe0-207">Service Unavailable</span></span>| <span data-ttu-id="f3fe0-208">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-208">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="f3fe0-209">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-209">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4EPH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="f3fe0-210">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f3fe0-210">Required Request Headers</span></span>
 
| <span data-ttu-id="f3fe0-211">Header</span><span class="sxs-lookup"><span data-stu-id="f3fe0-211">Header</span></span>| <span data-ttu-id="f3fe0-212">説明</span><span class="sxs-lookup"><span data-stu-id="f3fe0-212">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="f3fe0-213">Authorization</span><span class="sxs-lookup"><span data-stu-id="f3fe0-213">Authorization</span></span>| <span data-ttu-id="f3fe0-214">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-214">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="f3fe0-215">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-215">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="f3fe0-216">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="f3fe0-216">X-XBL-Contract-Version</span></span>| <span data-ttu-id="f3fe0-217">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-217">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="f3fe0-218">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-218">Pins supports version 2.</span></span> <span data-ttu-id="f3fe0-219">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-219">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="f3fe0-220">Content-Type</span><span class="sxs-lookup"><span data-stu-id="f3fe0-220">Content-Type</span></span>| <span data-ttu-id="f3fe0-221">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-221">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="f3fe0-222">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="f3fe0-222">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="f3fe0-223">If-Match</span><span class="sxs-lookup"><span data-stu-id="f3fe0-223">If-Match</span></span>| <span data-ttu-id="f3fe0-224">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-224">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="f3fe0-225">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-225">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="f3fe0-226">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-226">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="f3fe0-227">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="f3fe0-227">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EGBAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="f3fe0-228">要求本文</span><span class="sxs-lookup"><span data-stu-id="f3fe0-228">Request body</span></span>
 
<a id="ID4EMBAC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="f3fe0-229">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="f3fe0-229">Sample request</span></span>
 

```cpp
{"IndexedItems":
 [{ "Index": 0, 
     "Item": 
     {
    "ContentType": "Movie",
    "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
    "ProviderId": null,
    "Provider": null,
    "ImageUrl": "https://www.bing.com/thumb/...",
    "Title": "The Dark Knight",
    "SubTitle":null, 
    "Locale": "en-us",
    "DeviceType": "XboxOne"
}
}]}      
      
```

   
<a id="ID4EWBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="f3fe0-230">応答本文</span><span class="sxs-lookup"><span data-stu-id="f3fe0-230">Response body</span></span>
 
<a id="ID4E3BAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="f3fe0-231">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="f3fe0-231">Sample response</span></span>
 

```cpp
{
  "ListVersion":  1,
  "ListCount":  1,
  "MaxListSize": 200,
  "AllowDuplicates": "true",
  "AccessSetting":  "OwnerOnly"
}        
         
```

   
<a id="ID4EGCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f3fe0-232">関連項目</span><span class="sxs-lookup"><span data-stu-id="f3fe0-232">See also</span></span>
 
<a id="ID4EICAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f3fe0-233">Parent</span><span class="sxs-lookup"><span data-stu-id="f3fe0-233">Parent</span></span> 

[<span data-ttu-id="f3fe0-234">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="f3fe0-234">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

   