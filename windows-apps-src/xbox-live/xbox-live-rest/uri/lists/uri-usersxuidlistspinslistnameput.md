---
title: PUT (/users/xuid(xuid)/lists/PINS/{listname})
assetID: f7964d2e-a8c8-2caa-ca97-e0d76ef586f4
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameput.html
author: KevinAsgari
description: " PUT (/users/xuid(xuid)/lists/PINS/{listname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: fe69fe9e59fd3c7e523f9823438ff9d9b0b7916a
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4173146"
---
# <a name="put-usersxuidxuidlistspinslistname"></a><span data-ttu-id="ae314-104">PUT (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="ae314-104">PUT (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="ae314-105">要求本文内の各項目に指定されたインデックスに従ってリスト内の項目を更新します。</span><span class="sxs-lookup"><span data-stu-id="ae314-105">Updates the items in a list according to the indexes specified for each item in the request body.</span></span> <span data-ttu-id="ae314-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="ae314-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="ae314-107">注釈</span><span class="sxs-lookup"><span data-stu-id="ae314-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="ae314-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ae314-108">URI parameters</span></span>](#ID4E1B)
  * [<span data-ttu-id="ae314-109">Authorization</span><span class="sxs-lookup"><span data-stu-id="ae314-109">Authorization</span></span>](#ID4EFC)
  * [<span data-ttu-id="ae314-110">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ae314-110">HTTP status codes</span></span>](#ID4ESC)
  * [<span data-ttu-id="ae314-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ae314-111">Required Request Headers</span></span>](#ID4EPH)
  * [<span data-ttu-id="ae314-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="ae314-112">Request body</span></span>](#ID4EGBAC)
  * [<span data-ttu-id="ae314-113">応答本文</span><span class="sxs-lookup"><span data-stu-id="ae314-113">Response body</span></span>](#ID4EWBAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="ae314-114">注釈</span><span class="sxs-lookup"><span data-stu-id="ae314-114">Remarks</span></span>
 
<span data-ttu-id="ae314-115">この呼び出しは、要求本文内の各項目に指定されたインデックスに従ってリスト内の項目に更新されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-115">This call will update the items in a list according to the indexes specified for each item in the request body.</span></span> <span data-ttu-id="ae314-116">この呼び出しリストに項目は挿入されませんなり、項目が指定されたインデックスが存在しない場合はし、呼び出しが 400 正しくない要求の状態を返します。</span><span class="sxs-lookup"><span data-stu-id="ae314-116">This call will not insert items into the list, and if items do not exist at the specified indexes, then the call will return a 400 Bad Request status.</span></span> <span data-ttu-id="ae314-117">1 つの呼び出しで複数の項目に更新することができますが、すべてが、現在の一覧に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae314-117">Multiple items can be updated in a single call, but all must exist in the current list.</span></span> <span data-ttu-id="ae314-118">すべてを取得するように更新または更新を取得します。</span><span class="sxs-lookup"><span data-stu-id="ae314-118">That is, all get updated or none get updated.</span></span>
 
<span data-ttu-id="ae314-119">この呼び出しは、**インデックス**ではなく**itemId**によって指定される更新する項目をことができます。</span><span class="sxs-lookup"><span data-stu-id="ae314-119">This call will allow the item to be updated to be specified by the **itemId** instead of **index**.</span></span> <span data-ttu-id="ae314-120">これを行うには、単に、サービスに送信される**IndexedItems**構造内のインデックスを「-1」を使用します。</span><span class="sxs-lookup"><span data-stu-id="ae314-120">To do this, simply use "-1" for the index in the **IndexedItems** structure that is sent to the service.</span></span> <span data-ttu-id="ae314-121">当然ながらこの場合、 **itemId**は変更できません、更新プログラムの一部としてため、その他のメタデータ フィールドへの変更が機能のみ。</span><span class="sxs-lookup"><span data-stu-id="ae314-121">Obviously in this case, the **itemId**  cannot be changed as part of the update, so it will only work for changes to other metadata fields.</span></span> <span data-ttu-id="ae314-122">**プロバイダー**/項目の識別に**itemId**代わり**providerId**コンボに使うことができます。</span><span class="sxs-lookup"><span data-stu-id="ae314-122">The **provider**/**providerId** combo can be used instead of **itemId** to identify the item.</span></span> <span data-ttu-id="ae314-123">内部では、サービスは、これらの項目を更新する適切なインデックスの図の一覧を検索します。</span><span class="sxs-lookup"><span data-stu-id="ae314-123">Internally, the service searches the list for these items and figures out the proper indexes to update.</span></span> <span data-ttu-id="ae314-124">または複数の項目が見つからない場合 400 正しくない要求のステータスが返され、項目は更新されません。</span><span class="sxs-lookup"><span data-stu-id="ae314-124">If the item or items cannot be found then a 400 Bad Request status will be returned and no items will be updated.</span></span>
 
<span data-ttu-id="ae314-125">この呼び出しに必要な**場合-マッチ: versionNumber**インデックスを使用して、項目を識別する場合、要求に含まれるヘッダー。</span><span class="sxs-lookup"><span data-stu-id="ae314-125">This call requires an **If-Match:versionNumber** header to be included in the request if using indexes to identify items.</span></span> <span data-ttu-id="ae314-126">項目を識別する Id を使用して項目 (一覧は、重複を許可しない) 場合、 **If-match**ヘッダーは省略可能です。</span><span class="sxs-lookup"><span data-stu-id="ae314-126">If using item IDs to identify the items (and the list doesn't allow duplicates), then the **If-Match** header is optional.</span></span> <span data-ttu-id="ae314-127">存在する場合、 **If-match**ヘッダーが常に検証されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-127">If present, the **if-Match** header will always be validated.</span></span> <span data-ttu-id="ae314-128">ヘッダー、 **versionNumber**はリストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="ae314-128">In the header, the **versionNumber** is the current version number of the list.</span></span> <span data-ttu-id="ae314-129">場合に一致し、現在の一覧のバージョン番号、HTTP 412 Precondition Failed のステータス コードが返されると、応答の本文いないが含まれて一覧の最新のメタデータがない含まれている (および必須)、または現在のバージョン番号が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ae314-129">If it is not included (and required), or does not match the current list version number, then an HTTP 412 Precondition Failed status code will be returned and the body of the response will contain the latest metadata of the list that includes the current version number.</span></span> <span data-ttu-id="ae314-130">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを保護します。</span><span class="sxs-lookup"><span data-stu-id="ae314-130">This is to guard against updates from different clients trampling on one another.</span></span>
  
<a id="ID4E1B"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="ae314-131">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="ae314-131">URI parameters</span></span>
 
| <span data-ttu-id="ae314-132">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ae314-132">Parameter</span></span>| <span data-ttu-id="ae314-133">型</span><span class="sxs-lookup"><span data-stu-id="ae314-133">Type</span></span>| <span data-ttu-id="ae314-134">説明</span><span class="sxs-lookup"><span data-stu-id="ae314-134">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ae314-135">xuid</span><span class="sxs-lookup"><span data-stu-id="ae314-135">xuid</span></span>| <span data-ttu-id="ae314-136">string</span><span class="sxs-lookup"><span data-stu-id="ae314-136">string</span></span>| <span data-ttu-id="ae314-137">Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="ae314-137">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="ae314-138">listtype</span><span class="sxs-lookup"><span data-stu-id="ae314-138">listtype</span></span>| <span data-ttu-id="ae314-139">string</span><span class="sxs-lookup"><span data-stu-id="ae314-139">string</span></span>| <span data-ttu-id="ae314-140">(その使用方法と動作) の一覧の種類です。</span><span class="sxs-lookup"><span data-stu-id="ae314-140">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="ae314-141">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="ae314-141">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="ae314-142">リスト</span><span class="sxs-lookup"><span data-stu-id="ae314-142">listname</span></span>| <span data-ttu-id="ae314-143">string</span><span class="sxs-lookup"><span data-stu-id="ae314-143">string</span></span>| <span data-ttu-id="ae314-144">リストの名前 (際に指定された listtype の一覧がどの)。</span><span class="sxs-lookup"><span data-stu-id="ae314-144">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="ae314-145">常に"XBLPins"の項目のピン留めします。</span><span class="sxs-lookup"><span data-stu-id="ae314-145">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4EFC"></a>

 
## <a name="authorization"></a><span data-ttu-id="ae314-146">Authorization</span><span class="sxs-lookup"><span data-stu-id="ae314-146">Authorization</span></span>
 
<span data-ttu-id="ae314-147">この呼び出しは、**承認**ヘッダーで XSTS SAML トークンを想定しています。</span><span class="sxs-lookup"><span data-stu-id="ae314-147">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="ae314-148">Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae314-148">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="ae314-149">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="ae314-149">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="ae314-150">リスト自体では、同様の Xuid を識別し、リストの URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="ae314-150">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="ae314-151">これを使用して、お、今後リストに共有サポートへのアクセスがいる機能ではありませんこの時点でします。</span><span class="sxs-lookup"><span data-stu-id="ae314-151">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="ae314-152">現時点では、ユーザーがアクセスするすべてのリストが自分、共有へのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="ae314-152">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="ae314-153">したがって、URI の Xuid は SAML クレーム トークン内の Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae314-153">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="ae314-154">現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="ae314-154">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4ESC"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="ae314-155">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="ae314-155">HTTP status codes</span></span>
 
<span data-ttu-id="ae314-156">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="ae314-156">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="ae314-157">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ae314-157">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="ae314-158">コード</span><span class="sxs-lookup"><span data-stu-id="ae314-158">Code</span></span>| <span data-ttu-id="ae314-159">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="ae314-159">Reason phrase</span></span>| <span data-ttu-id="ae314-160">説明</span><span class="sxs-lookup"><span data-stu-id="ae314-160">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ae314-161">200</span><span class="sxs-lookup"><span data-stu-id="ae314-161">200</span></span>| <span data-ttu-id="ae314-162">OK</span><span class="sxs-lookup"><span data-stu-id="ae314-162">OK</span></span>| <span data-ttu-id="ae314-163">要求が正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="ae314-163">The request completed successfully.</span></span> <span data-ttu-id="ae314-164">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae314-164">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="ae314-165">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-165">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="ae314-166">201</span><span class="sxs-lookup"><span data-stu-id="ae314-166">201</span></span>| <span data-ttu-id="ae314-167">Created</span><span class="sxs-lookup"><span data-stu-id="ae314-167">Created</span></span>| <span data-ttu-id="ae314-168">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="ae314-168">A new list has been created.</span></span> <span data-ttu-id="ae314-169">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-169">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="ae314-170">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ae314-170">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="ae314-171">304</span><span class="sxs-lookup"><span data-stu-id="ae314-171">304</span></span>| <span data-ttu-id="ae314-172">Not Modified</span><span class="sxs-lookup"><span data-stu-id="ae314-172">Not Modified</span></span>| <span data-ttu-id="ae314-173">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-173">Returned on GETs.</span></span> <span data-ttu-id="ae314-174">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="ae314-174">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="ae314-175">サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="ae314-175">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="ae314-176">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-176">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="ae314-177">400</span><span class="sxs-lookup"><span data-stu-id="ae314-177">400</span></span>| <span data-ttu-id="ae314-178">Bad Request</span><span class="sxs-lookup"><span data-stu-id="ae314-178">Bad Request</span></span>| <span data-ttu-id="ae314-179">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="ae314-179">The request was malformed.</span></span> <span data-ttu-id="ae314-180">無効な値または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="ae314-180">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="ae314-181">不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-181">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="ae314-182"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="ae314-182">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="ae314-183">401</span><span class="sxs-lookup"><span data-stu-id="ae314-183">401</span></span>| <span data-ttu-id="ae314-184">権限がありません</span><span class="sxs-lookup"><span data-stu-id="ae314-184">Unauthorized</span></span>| <span data-ttu-id="ae314-185">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="ae314-185">The request requires user authentication.</span></span>| 
| <span data-ttu-id="ae314-186">403</span><span class="sxs-lookup"><span data-stu-id="ae314-186">403</span></span>| <span data-ttu-id="ae314-187">Forbidden</span><span class="sxs-lookup"><span data-stu-id="ae314-187">Forbidden</span></span>| <span data-ttu-id="ae314-188">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="ae314-188">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="ae314-189">404</span><span class="sxs-lookup"><span data-stu-id="ae314-189">404</span></span>| <span data-ttu-id="ae314-190">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="ae314-190">Not Found</span></span>| <span data-ttu-id="ae314-191">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="ae314-191">The caller does not have access to the resource.</span></span> <span data-ttu-id="ae314-192">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="ae314-192">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="ae314-193">412</span><span class="sxs-lookup"><span data-stu-id="ae314-193">412</span></span>| <span data-ttu-id="ae314-194">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="ae314-194">Precondition Failed</span></span>| <span data-ttu-id="ae314-195">一覧のバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="ae314-195">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="ae314-196">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="ae314-196">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="ae314-197">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="ae314-197">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="ae314-198">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-198">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="ae314-199">500</span><span class="sxs-lookup"><span data-stu-id="ae314-199">500</span></span>| <span data-ttu-id="ae314-200">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="ae314-200">Internal Server Error</span></span>| <span data-ttu-id="ae314-201">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="ae314-201">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="ae314-202">501</span><span class="sxs-lookup"><span data-stu-id="ae314-202">501</span></span>| <span data-ttu-id="ae314-203">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="ae314-203">Not Implemented</span></span>| <span data-ttu-id="ae314-204">呼び出し元がサーバーに実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="ae314-204">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="ae314-205">(現在のみを使用するとき、要求の対象となるがないホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="ae314-205">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="ae314-206">503</span><span class="sxs-lookup"><span data-stu-id="ae314-206">503</span></span>| <span data-ttu-id="ae314-207">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="ae314-207">Service Unavailable</span></span>| <span data-ttu-id="ae314-208">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="ae314-208">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="ae314-209">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="ae314-209">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4EPH"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="ae314-210">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ae314-210">Required Request Headers</span></span>
 
| <span data-ttu-id="ae314-211">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="ae314-211">Header</span></span>| <span data-ttu-id="ae314-212">説明</span><span class="sxs-lookup"><span data-stu-id="ae314-212">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="ae314-213">Authorization</span><span class="sxs-lookup"><span data-stu-id="ae314-213">Authorization</span></span>| <span data-ttu-id="ae314-214">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ae314-214">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="ae314-215">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae314-215">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="ae314-216">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="ae314-216">X-XBL-Contract-Version</span></span>| <span data-ttu-id="ae314-217">要求された (正の整数) をされている API のバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="ae314-217">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="ae314-218">ピンのサポート バージョン 2 です。</span><span class="sxs-lookup"><span data-stu-id="ae314-218">Pins supports version 2.</span></span> <span data-ttu-id="ae314-219">このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="ae314-219">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="ae314-220">Content-Type</span><span class="sxs-lookup"><span data-stu-id="ae314-220">Content-Type</span></span>| <span data-ttu-id="ae314-221">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="ae314-221">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="ae314-222">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="ae314-222">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="ae314-223">If-Match</span><span class="sxs-lookup"><span data-stu-id="ae314-223">If-Match</span></span>| <span data-ttu-id="ae314-224">このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="ae314-224">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="ae314-225">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="ae314-225">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="ae314-226">"If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="ae314-226">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="ae314-227">(省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="ae314-227">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EGBAC"></a>

 
## <a name="request-body"></a><span data-ttu-id="ae314-228">要求本文</span><span class="sxs-lookup"><span data-stu-id="ae314-228">Request body</span></span>
 
<a id="ID4EMBAC"></a>

 
### <a name="sample-request"></a><span data-ttu-id="ae314-229">要求の例</span><span class="sxs-lookup"><span data-stu-id="ae314-229">Sample request</span></span>
 

```cpp
{"IndexedItems":
 [{ "Index": 0, 
     "Item": 
     {
    "ContentType": "Movie",
    "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
    "ProviderId": null,
    "Provider": null,
    "ImageUrl": "http://www.bing.com/thumb/...",
    "Title": "The Dark Knight",
    "SubTitle":null, 
    "Locale": "en-us",
    "DeviceType": "XboxOne"
}
}]}      
      
```

   
<a id="ID4EWBAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="ae314-230">応答本文</span><span class="sxs-lookup"><span data-stu-id="ae314-230">Response body</span></span>
 
<a id="ID4E3BAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="ae314-231">応答の例</span><span class="sxs-lookup"><span data-stu-id="ae314-231">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="ae314-232">関連項目</span><span class="sxs-lookup"><span data-stu-id="ae314-232">See also</span></span>
 
<a id="ID4EICAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ae314-233">Parent</span><span class="sxs-lookup"><span data-stu-id="ae314-233">Parent</span></span> 

[<span data-ttu-id="ae314-234">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="ae314-234">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

   