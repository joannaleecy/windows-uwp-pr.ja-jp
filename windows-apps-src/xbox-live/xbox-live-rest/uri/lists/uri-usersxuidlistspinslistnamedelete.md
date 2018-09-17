---
title: DELETE (/users/xuid(xuid)/lists/PINS/{listname})
assetID: b43e3faa-7791-8bcb-3aec-7bdad8ffbebf
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamedelete.html
author: KevinAsgari
description: " DELETE (/users/xuid(xuid)/lists/PINS/{listname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0749229af844c7b71496351000cadece7544bfc6
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3989003"
---
# <a name="delete-usersxuidxuidlistspinslistname"></a><span data-ttu-id="10170-104">DELETE (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="10170-104">DELETE (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="10170-105">一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="10170-105">Removes items from a list.</span></span> <span data-ttu-id="10170-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="10170-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="10170-107">注釈</span><span class="sxs-lookup"><span data-stu-id="10170-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="10170-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="10170-108">URI parameters</span></span>](#ID4EIB)
  * [<span data-ttu-id="10170-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="10170-109">Query string parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="10170-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="10170-110">Authorization</span></span>](#ID4ETC)
  * [<span data-ttu-id="10170-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="10170-111">Required Request Headers</span></span>](#ID4EAD)
  * [<span data-ttu-id="10170-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="10170-112">Request body</span></span>](#ID4EWE)
  * [<span data-ttu-id="10170-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="10170-113">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="10170-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="10170-114">Response body</span></span>](#ID4E6BAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="10170-115">注釈</span><span class="sxs-lookup"><span data-stu-id="10170-115">Remarks</span></span>
 
<span data-ttu-id="10170-116">削除する項目は、リスト内のインデックスで示されます、クエリ文字列パラメーター**インデックス**で識別されます。</span><span class="sxs-lookup"><span data-stu-id="10170-116">Items to be removed are indicated by their index in the list and are identified in the query string parameter **indexes**.</span></span> <span data-ttu-id="10170-117">コンマ区切りのインデックスのリストがある必要があります、1 回の呼び出しは 100 のインデックスを渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="10170-117">The list of indexes must be comma-delimited and only 100 indexes can be passed in a single call.</span></span> <span data-ttu-id="10170-118">ただし、インデックスが (空のクエリ文字列パラメーター) を渡されていない場合、一覧の全体の内容が削除されます (バージョン番号がインクリメント引き続きし、空のリストはままです)。</span><span class="sxs-lookup"><span data-stu-id="10170-118">However, if no indexes are passed (empty query string parameter) then the contents of the entire list will be deleted (an empty list will remain, and the version number will continue to increment).</span></span> <span data-ttu-id="10170-119">項目が削除されると一覧が「キーを押してコンパクト」インデックスの順序で穴が残っていないようにします。</span><span class="sxs-lookup"><span data-stu-id="10170-119">Once the items are removed, the list is "compacted" such that no holes are left in the ordering of indexes.</span></span> <span data-ttu-id="10170-120">したがって、この呼び出しは、等ではありません。</span><span class="sxs-lookup"><span data-stu-id="10170-120">Therefore, this call is not idempotent.</span></span>
 
<span data-ttu-id="10170-121">この呼び出しに必要な**場合-マッチ: versionNumber** **versionNumber**がファイルの現在のバージョン番号は、要求に含まれるヘッダー。</span><span class="sxs-lookup"><span data-stu-id="10170-121">This call requires an **If-Match:versionNumber** header to be included in the request, where **versionNumber** is the current version number of the file.</span></span> <span data-ttu-id="10170-122">またはし、現在の一覧のバージョン番号、http/412 (precondition failed) と一致しませんが、含まれていない場合は、ステータス コードが返されます、応答の本文には現在のバージョン番号を含む一覧の最新のメタデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="10170-122">If it is not included, or does not match the current list version number, then an HTTP 412 (precondition failed) status code will be returned and the body of the response will contain the latest metadata of the list that includes the current version number.</span></span> <span data-ttu-id="10170-123">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐため。</span><span class="sxs-lookup"><span data-stu-id="10170-123">This is done to guard against updates from different clients trampling on one another.</span></span>
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="10170-124">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="10170-124">URI parameters</span></span>
 
| <span data-ttu-id="10170-125">パラメーター</span><span class="sxs-lookup"><span data-stu-id="10170-125">Parameter</span></span>| <span data-ttu-id="10170-126">型</span><span class="sxs-lookup"><span data-stu-id="10170-126">Type</span></span>| <span data-ttu-id="10170-127">説明</span><span class="sxs-lookup"><span data-stu-id="10170-127">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="10170-128">xuid</span><span class="sxs-lookup"><span data-stu-id="10170-128">xuid</span></span>| <span data-ttu-id="10170-129">string</span><span class="sxs-lookup"><span data-stu-id="10170-129">string</span></span>| <span data-ttu-id="10170-130">Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="10170-130">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="10170-131">listtype</span><span class="sxs-lookup"><span data-stu-id="10170-131">listtype</span></span>| <span data-ttu-id="10170-132">string</span><span class="sxs-lookup"><span data-stu-id="10170-132">string</span></span>| <span data-ttu-id="10170-133">(その使用方法と動作) の一覧の種類です。</span><span class="sxs-lookup"><span data-stu-id="10170-133">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="10170-134">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="10170-134">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="10170-135">リスト</span><span class="sxs-lookup"><span data-stu-id="10170-135">listname</span></span>| <span data-ttu-id="10170-136">string</span><span class="sxs-lookup"><span data-stu-id="10170-136">string</span></span>| <span data-ttu-id="10170-137">リストの名前 (際に指定された listtype の一覧がどの)。</span><span class="sxs-lookup"><span data-stu-id="10170-137">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="10170-138">常に"XBLPins"の項目のピン留めします。</span><span class="sxs-lookup"><span data-stu-id="10170-138">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="10170-139">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="10170-139">Query string parameters</span></span>
 
| <span data-ttu-id="10170-140">パラメーター</span><span class="sxs-lookup"><span data-stu-id="10170-140">Parameter</span></span>| <span data-ttu-id="10170-141">型</span><span class="sxs-lookup"><span data-stu-id="10170-141">Type</span></span>| <span data-ttu-id="10170-142">説明</span><span class="sxs-lookup"><span data-stu-id="10170-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="10170-143">インデックス</span><span class="sxs-lookup"><span data-stu-id="10170-143">indexes</span></span>| <span data-ttu-id="10170-144">string</span><span class="sxs-lookup"><span data-stu-id="10170-144">string</span></span>| <span data-ttu-id="10170-145">省略可能。</span><span class="sxs-lookup"><span data-stu-id="10170-145">Optional.</span></span> <span data-ttu-id="10170-146">項目を削除する場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="10170-146">Specifies where to remove items.</span></span> <span data-ttu-id="10170-147">サポートされる値: 0、正の整数と「終了」です。</span><span class="sxs-lookup"><span data-stu-id="10170-147">Supported values: 0, positive integers, and "end".</span></span> <span data-ttu-id="10170-148">既定値: 0 です。</span><span class="sxs-lookup"><span data-stu-id="10170-148">Default value: 0.</span></span>| 
 
<span data-ttu-id="10170-149">例:**インデックス = 1、8**インデックス 1 と 8 に項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="10170-149">Example: **indexes=1,8** removes items at indexes 1 and 8.</span></span> <span data-ttu-id="10170-150">インデックスは、一意である必要があります。</span><span class="sxs-lookup"><span data-stu-id="10170-150">Indexes must be unique.</span></span> <span data-ttu-id="10170-151">インデックスが指定されていない場合は、一覧全体がクリアされます。</span><span class="sxs-lookup"><span data-stu-id="10170-151">If no indexes are provided, the entire list will be cleared.</span></span>
  
<a id="ID4ETC"></a>

 
## <a name="authorization"></a><span data-ttu-id="10170-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="10170-152">Authorization</span></span>
 
<span data-ttu-id="10170-153">この呼び出しは、**承認**ヘッダーで XSTS SAML トークンを想定しています。</span><span class="sxs-lookup"><span data-stu-id="10170-153">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="10170-154">Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="10170-154">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="10170-155">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="10170-155">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="10170-156">リスト自体では、同様の Xuid を識別し、リストの URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="10170-156">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="10170-157">これを使用して、お、今後リストに共有サポートへのアクセスがいる機能ではありませんこの時点でします。</span><span class="sxs-lookup"><span data-stu-id="10170-157">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="10170-158">現時点では、ユーザーがアクセスするすべてのリストが自分、共有へのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="10170-158">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="10170-159">したがって、URI の Xuid は SAML クレーム トークン内の Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="10170-159">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="10170-160">現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="10170-160">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4EAD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="10170-161">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="10170-161">Required Request Headers</span></span>
 
| <span data-ttu-id="10170-162">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="10170-162">Header</span></span>| <span data-ttu-id="10170-163">説明</span><span class="sxs-lookup"><span data-stu-id="10170-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="10170-164">Authorization</span><span class="sxs-lookup"><span data-stu-id="10170-164">Authorization</span></span>| <span data-ttu-id="10170-165">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="10170-165">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="10170-166">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="10170-166">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="10170-167">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="10170-167">X-XBL-Contract-Version</span></span>| <span data-ttu-id="10170-168">要求された (正の整数) をされている API のバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="10170-168">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="10170-169">ピンのサポート バージョン 2 です。</span><span class="sxs-lookup"><span data-stu-id="10170-169">Pins supports version 2.</span></span> <span data-ttu-id="10170-170">このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="10170-170">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="10170-171">Content-Type</span><span class="sxs-lookup"><span data-stu-id="10170-171">Content-Type</span></span>| <span data-ttu-id="10170-172">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="10170-172">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="10170-173">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="10170-173">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="10170-174">If-Match</span><span class="sxs-lookup"><span data-stu-id="10170-174">If-Match</span></span>| <span data-ttu-id="10170-175">このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="10170-175">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="10170-176">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="10170-176">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="10170-177">"If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="10170-177">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="10170-178">(省略可能)また場合に使用できますの取得、現在、渡されたバージョンと一致する現在の一覧のバージョンし、データがない一覧 HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="10170-178">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a><span data-ttu-id="10170-179">要求本文</span><span class="sxs-lookup"><span data-stu-id="10170-179">Request body</span></span>
 
<span data-ttu-id="10170-180">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="10170-180">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="10170-181">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="10170-181">HTTP status codes</span></span>
 
<span data-ttu-id="10170-182">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="10170-182">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="10170-183">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="10170-183">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="10170-184">コード</span><span class="sxs-lookup"><span data-stu-id="10170-184">Code</span></span>| <span data-ttu-id="10170-185">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="10170-185">Reason phrase</span></span>| <span data-ttu-id="10170-186">説明</span><span class="sxs-lookup"><span data-stu-id="10170-186">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="10170-187">200</span><span class="sxs-lookup"><span data-stu-id="10170-187">200</span></span>| <span data-ttu-id="10170-188">OK</span><span class="sxs-lookup"><span data-stu-id="10170-188">OK</span></span>| <span data-ttu-id="10170-189">要求が正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="10170-189">The request completed successfully.</span></span> <span data-ttu-id="10170-190">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="10170-190">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="10170-191">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="10170-191">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="10170-192">201</span><span class="sxs-lookup"><span data-stu-id="10170-192">201</span></span>| <span data-ttu-id="10170-193">Created</span><span class="sxs-lookup"><span data-stu-id="10170-193">Created</span></span>| <span data-ttu-id="10170-194">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="10170-194">A new list has been created.</span></span> <span data-ttu-id="10170-195">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="10170-195">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="10170-196">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="10170-196">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="10170-197">304</span><span class="sxs-lookup"><span data-stu-id="10170-197">304</span></span>| <span data-ttu-id="10170-198">Not Modified</span><span class="sxs-lookup"><span data-stu-id="10170-198">Not Modified</span></span>| <span data-ttu-id="10170-199">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="10170-199">Returned on GETs.</span></span> <span data-ttu-id="10170-200">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="10170-200">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="10170-201">サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="10170-201">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="10170-202">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="10170-202">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="10170-203">400</span><span class="sxs-lookup"><span data-stu-id="10170-203">400</span></span>| <span data-ttu-id="10170-204">Bad Request</span><span class="sxs-lookup"><span data-stu-id="10170-204">Bad Request</span></span>| <span data-ttu-id="10170-205">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="10170-205">The request was malformed.</span></span> <span data-ttu-id="10170-206">無効な値または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="10170-206">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="10170-207">不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="10170-207">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="10170-208"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="10170-208">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="10170-209">401</span><span class="sxs-lookup"><span data-stu-id="10170-209">401</span></span>| <span data-ttu-id="10170-210">権限がありません</span><span class="sxs-lookup"><span data-stu-id="10170-210">Unauthorized</span></span>| <span data-ttu-id="10170-211">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="10170-211">The request requires user authentication.</span></span>| 
| <span data-ttu-id="10170-212">403</span><span class="sxs-lookup"><span data-stu-id="10170-212">403</span></span>| <span data-ttu-id="10170-213">Forbidden</span><span class="sxs-lookup"><span data-stu-id="10170-213">Forbidden</span></span>| <span data-ttu-id="10170-214">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="10170-214">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="10170-215">404</span><span class="sxs-lookup"><span data-stu-id="10170-215">404</span></span>| <span data-ttu-id="10170-216">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="10170-216">Not Found</span></span>| <span data-ttu-id="10170-217">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="10170-217">The caller does not have access to the resource.</span></span> <span data-ttu-id="10170-218">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="10170-218">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="10170-219">412</span><span class="sxs-lookup"><span data-stu-id="10170-219">412</span></span>| <span data-ttu-id="10170-220">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="10170-220">Precondition Failed</span></span>| <span data-ttu-id="10170-221">一覧のバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="10170-221">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="10170-222">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="10170-222">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="10170-223">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="10170-223">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="10170-224">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="10170-224">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="10170-225">500</span><span class="sxs-lookup"><span data-stu-id="10170-225">500</span></span>| <span data-ttu-id="10170-226">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="10170-226">Internal Server Error</span></span>| <span data-ttu-id="10170-227">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="10170-227">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="10170-228">501</span><span class="sxs-lookup"><span data-stu-id="10170-228">501</span></span>| <span data-ttu-id="10170-229">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="10170-229">Not Implemented</span></span>| <span data-ttu-id="10170-230">呼び出し元がサーバーに実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="10170-230">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="10170-231">(現在のみを使用するとき、要求の対象となるがないホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="10170-231">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="10170-232">503</span><span class="sxs-lookup"><span data-stu-id="10170-232">503</span></span>| <span data-ttu-id="10170-233">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="10170-233">Service Unavailable</span></span>| <span data-ttu-id="10170-234">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="10170-234">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="10170-235">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="10170-235">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4E6BAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="10170-236">応答本文</span><span class="sxs-lookup"><span data-stu-id="10170-236">Response body</span></span>
 
<a id="ID4EFCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="10170-237">応答の例</span><span class="sxs-lookup"><span data-stu-id="10170-237">Sample response</span></span>
 

```cpp
{
  "ListVersion":  1,
  "ListCount":  1,
  "MaxListSize": 200,
  "AllowDuplicates": "true",
  "AccessSetting":  "OwnerOnly"
}        
         
```

   
<a id="ID4EPCAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="10170-238">関連項目</span><span class="sxs-lookup"><span data-stu-id="10170-238">See also</span></span>
 
<a id="ID4ERCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="10170-239">Parent</span><span class="sxs-lookup"><span data-stu-id="10170-239">Parent</span></span> 

[<span data-ttu-id="10170-240">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="10170-240">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

   