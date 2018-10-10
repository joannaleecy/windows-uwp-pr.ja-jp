---
title: POST (/users/xuid(xuid)/lists/PINS/{listname})
assetID: 813c0bd2-aca9-a1f6-9e81-a84a4c897b1e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamepost.html
author: KevinAsgari
description: " POST (/users/xuid(xuid)/lists/PINS/{listname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 77789014fcd242aad70e7302b01907bc10b8bbab
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4502682"
---
# <a name="post-usersxuidxuidlistspinslistname"></a><span data-ttu-id="aea94-104">POST (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="aea94-104">POST (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="aea94-105">クエリ文字列パラメーター **insertIndex**に基づいてインデックスの一覧に項目を挿入します。</span><span class="sxs-lookup"><span data-stu-id="aea94-105">Inserts items into the list at the index based on the query string parameter **insertIndex**.</span></span> <span data-ttu-id="aea94-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="aea94-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="aea94-107">注釈</span><span class="sxs-lookup"><span data-stu-id="aea94-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="aea94-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="aea94-108">URI parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="aea94-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="aea94-109">Query string parameters</span></span>](#ID4E5B)
  * [<span data-ttu-id="aea94-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="aea94-110">Authorization</span></span>](#ID4EZC)
  * [<span data-ttu-id="aea94-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="aea94-111">HTTP status codes</span></span>](#ID4EGD)
  * [<span data-ttu-id="aea94-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="aea94-112">Required Request Headers</span></span>](#ID4EEAAC)
  * [<span data-ttu-id="aea94-113">要求の例</span><span class="sxs-lookup"><span data-stu-id="aea94-113">Sample request</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="aea94-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="aea94-114">Response body</span></span>](#ID4EPCAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="aea94-115">注釈</span><span class="sxs-lookup"><span data-stu-id="aea94-115">Remarks</span></span>
 
<span data-ttu-id="aea94-116">この呼び出しは、クエリ文字列パラメーター **insertIndex** (既定値は 0 またはリストの先頭) に基づくインデックスのリストに項目を挿入します。</span><span class="sxs-lookup"><span data-stu-id="aea94-116">This call will insert items into the list at the index based on the query string parameter **insertIndex** (defaults to 0 or the beginning of the list).</span></span> <span data-ttu-id="aea94-117">要求本文のすべての項目は、その時点で一覧に挿入されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-117">All items in the request body will be inserted at that point in the list.</span></span> <span data-ttu-id="aea94-118">**InsertIndex**が既存のリスト内の項目の数よりも大きい場合は、最後に、新しい項目が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-118">If the **insertIndex** is greater than the number of items in the existing list, the new items will be inserted at the end.</span></span>
 
<span data-ttu-id="aea94-119">挿入する項目の必須フィールド機能仕様では、; に示されている必要があります。それ以外の場合、HTTP 400 が返されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-119">Items to be inserted must have the required fields indicated in the functional spec; otherwise, an HTTP 400 will be returned.</span></span> <span data-ttu-id="aea94-120">同様に、挿入の結果は (リストの種類ごとに定義された) リストの最大サイズを超える場合、HTTP 400 が返され、何が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-120">Similarly, if the result of the insert will exceed the maximum size of the list (defined per list type) then an HTTP 400 will be returned and nothing will be inserted.</span></span>
 
<span data-ttu-id="aea94-121">項目がある場合*いない*または、一覧の最後の先頭に挿入する、**場合-マッチ: versionNumber**ヘッダーは、要求に含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="aea94-121">If the item is *not* to be inserted at the beginning or the end of the list, then the **If-Match:versionNumber** header is required to be included in the request.</span></span> <span data-ttu-id="aea94-122">ヘッダーは、先頭または末尾の場合は、カーソルはオプションです。</span><span class="sxs-lookup"><span data-stu-id="aea94-122">The header is optional if the insertion is for the beginning or the end.</span></span> <span data-ttu-id="aea94-123">存在する場合、ヘッダーが挿入場所に関係なく検証されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-123">If present, the header will be validated regardless of the insert location.</span></span> <span data-ttu-id="aea94-124">ヘッダーで**次のメッセージ**は、リストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="aea94-124">In the header **VersionNumber** is the current version number of the list.</span></span> <span data-ttu-id="aea94-125">いない含まれており、必要な場合またはし、現在の一覧のバージョン番号、http/412 (precondition failed) に一致しない状態コードが返され、応答の本文には、現在のバージョン番号が含まれている一覧の最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="aea94-125">If it is not included and required, or does not match the current list version number, then an HTTP 412 (precondition failed) status code will be returned and the body of the response will contain the latest metadata of the list that includes the current version number.</span></span> <span data-ttu-id="aea94-126">これは互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐためです。</span><span class="sxs-lookup"><span data-stu-id="aea94-126">This is to guard against updates from different clients trampling on one another.</span></span>
 
<span data-ttu-id="aea94-127">この呼び出しは、等; ではないことに注意してください。同じデータを繰り返し呼び出すと、複数の挿入する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="aea94-127">Note that this call is not idempotent; repeated calls with the same data could result in multiple insertions.</span></span> <span data-ttu-id="aea94-128">ただし、一覧には、重複を現在サポートするものはありませんするため繰り返されている呼び出しが返されるコードの HTTP 400 を得られます。</span><span class="sxs-lookup"><span data-stu-id="aea94-128">However, since no list currently supports duplicates, repeated calls will likely result in HTTP 400 codes being returned.</span></span>
  
<a id="ID4ETB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="aea94-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="aea94-129">URI parameters</span></span>
 
| <span data-ttu-id="aea94-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="aea94-130">Parameter</span></span>| <span data-ttu-id="aea94-131">型</span><span class="sxs-lookup"><span data-stu-id="aea94-131">Type</span></span>| <span data-ttu-id="aea94-132">説明</span><span class="sxs-lookup"><span data-stu-id="aea94-132">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="aea94-133">xuid</span><span class="sxs-lookup"><span data-stu-id="aea94-133">xuid</span></span>| <span data-ttu-id="aea94-134">string</span><span class="sxs-lookup"><span data-stu-id="aea94-134">string</span></span>| <span data-ttu-id="aea94-135">Xbox ユーザー ID (XUID) です。</span><span class="sxs-lookup"><span data-stu-id="aea94-135">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="aea94-136">listtype</span><span class="sxs-lookup"><span data-stu-id="aea94-136">listtype</span></span>| <span data-ttu-id="aea94-137">string</span><span class="sxs-lookup"><span data-stu-id="aea94-137">string</span></span>| <span data-ttu-id="aea94-138">(その使用方法と動作) の一覧の種類です。</span><span class="sxs-lookup"><span data-stu-id="aea94-138">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="aea94-139">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="aea94-139">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="aea94-140">リスト</span><span class="sxs-lookup"><span data-stu-id="aea94-140">listname</span></span>| <span data-ttu-id="aea94-141">string</span><span class="sxs-lookup"><span data-stu-id="aea94-141">string</span></span>| <span data-ttu-id="aea94-142">リストの名前 (際に指定された listtype の一覧がどの)。</span><span class="sxs-lookup"><span data-stu-id="aea94-142">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="aea94-143">常に"XBLPins"のアイテムを Pin にします。</span><span class="sxs-lookup"><span data-stu-id="aea94-143">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4E5B"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="aea94-144">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="aea94-144">Query string parameters</span></span>
 
| <span data-ttu-id="aea94-145">パラメーター</span><span class="sxs-lookup"><span data-stu-id="aea94-145">Parameter</span></span>| <span data-ttu-id="aea94-146">型</span><span class="sxs-lookup"><span data-stu-id="aea94-146">Type</span></span>| <span data-ttu-id="aea94-147">説明</span><span class="sxs-lookup"><span data-stu-id="aea94-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="aea94-148">insertIndex</span><span class="sxs-lookup"><span data-stu-id="aea94-148">insertIndex</span></span>| <span data-ttu-id="aea94-149">string</span><span class="sxs-lookup"><span data-stu-id="aea94-149">string</span></span>| <span data-ttu-id="aea94-150">省略可能。</span><span class="sxs-lookup"><span data-stu-id="aea94-150">Optional.</span></span> <span data-ttu-id="aea94-151">項目を挿入する位置を定義します。</span><span class="sxs-lookup"><span data-stu-id="aea94-151">Defines where to insert items.</span></span> <span data-ttu-id="aea94-152">サポートされる値: 0、正の整数と「終了」。</span><span class="sxs-lookup"><span data-stu-id="aea94-152">Supported values: 0, positive integers, and "end".</span></span> <span data-ttu-id="aea94-153">インデックス値がリスト項目の数よりも大きいは、一覧の下部に新しい項目を追加し、一覧に「空白」は挿入されません。</span><span class="sxs-lookup"><span data-stu-id="aea94-153">Any index value greater than the number of list items will add the new item at the bottom of the list, and will not insert "blank" space in the list.</span></span> <span data-ttu-id="aea94-154">既定値: 0 です。</span><span class="sxs-lookup"><span data-stu-id="aea94-154">Default value: 0.</span></span>| 
  
<a id="ID4EZC"></a>

 
## <a name="authorization"></a><span data-ttu-id="aea94-155">Authorization</span><span class="sxs-lookup"><span data-stu-id="aea94-155">Authorization</span></span>
 
<span data-ttu-id="aea94-156">この呼び出しは、**承認**ヘッダーで、XSTS SAML トークンを期待しています。</span><span class="sxs-lookup"><span data-stu-id="aea94-156">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="aea94-157">Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="aea94-157">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="aea94-158">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="aea94-158">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="aea94-159">リスト自体では、同様の Xuid を識別し、リストの URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="aea94-159">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="aea94-160">これを使用して、お、今後リストへのアクセスの共有のサポートがいる機能ではありませんこの時点でします。</span><span class="sxs-lookup"><span data-stu-id="aea94-160">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="aea94-161">現時点では、ユーザーがアクセスするすべてのリストが自分、共有アクセスができなくなります。</span><span class="sxs-lookup"><span data-stu-id="aea94-161">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="aea94-162">したがって、URI の Xuid は SAML クレーム トークン内の Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="aea94-162">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="aea94-163">現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="aea94-163">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4EGD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="aea94-164">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="aea94-164">HTTP status codes</span></span>
 
<span data-ttu-id="aea94-165">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="aea94-165">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="aea94-166">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="aea94-166">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="aea94-167">コード</span><span class="sxs-lookup"><span data-stu-id="aea94-167">Code</span></span>| <span data-ttu-id="aea94-168">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="aea94-168">Reason phrase</span></span>| <span data-ttu-id="aea94-169">説明</span><span class="sxs-lookup"><span data-stu-id="aea94-169">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="aea94-170">200</span><span class="sxs-lookup"><span data-stu-id="aea94-170">200</span></span>| <span data-ttu-id="aea94-171">OK</span><span class="sxs-lookup"><span data-stu-id="aea94-171">OK</span></span>| <span data-ttu-id="aea94-172">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="aea94-172">The request completed successfully.</span></span> <span data-ttu-id="aea94-173">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="aea94-173">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="aea94-174">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-174">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="aea94-175">201</span><span class="sxs-lookup"><span data-stu-id="aea94-175">201</span></span>| <span data-ttu-id="aea94-176">Created</span><span class="sxs-lookup"><span data-stu-id="aea94-176">Created</span></span>| <span data-ttu-id="aea94-177">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="aea94-177">A new list has been created.</span></span> <span data-ttu-id="aea94-178">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-178">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="aea94-179">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="aea94-179">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="aea94-180">304</span><span class="sxs-lookup"><span data-stu-id="aea94-180">304</span></span>| <span data-ttu-id="aea94-181">Not Modified</span><span class="sxs-lookup"><span data-stu-id="aea94-181">Not Modified</span></span>| <span data-ttu-id="aea94-182">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-182">Returned on GETs.</span></span> <span data-ttu-id="aea94-183">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="aea94-183">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="aea94-184">サービスでは、一覧のバージョンに<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="aea94-184">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="aea94-185">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-185">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="aea94-186">400</span><span class="sxs-lookup"><span data-stu-id="aea94-186">400</span></span>| <span data-ttu-id="aea94-187">Bad Request</span><span class="sxs-lookup"><span data-stu-id="aea94-187">Bad Request</span></span>| <span data-ttu-id="aea94-188">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="aea94-188">The request was malformed.</span></span> <span data-ttu-id="aea94-189">無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="aea94-189">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="aea94-190">不足している必要なパラメーターの結果こともできますか、データの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-190">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="aea94-191"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="aea94-191">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="aea94-192">401</span><span class="sxs-lookup"><span data-stu-id="aea94-192">401</span></span>| <span data-ttu-id="aea94-193">権限がありません</span><span class="sxs-lookup"><span data-stu-id="aea94-193">Unauthorized</span></span>| <span data-ttu-id="aea94-194">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="aea94-194">The request requires user authentication.</span></span>| 
| <span data-ttu-id="aea94-195">403</span><span class="sxs-lookup"><span data-stu-id="aea94-195">403</span></span>| <span data-ttu-id="aea94-196">Forbidden</span><span class="sxs-lookup"><span data-stu-id="aea94-196">Forbidden</span></span>| <span data-ttu-id="aea94-197">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="aea94-197">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="aea94-198">404</span><span class="sxs-lookup"><span data-stu-id="aea94-198">404</span></span>| <span data-ttu-id="aea94-199">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="aea94-199">Not Found</span></span>| <span data-ttu-id="aea94-200">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="aea94-200">The caller does not have access to the resource.</span></span> <span data-ttu-id="aea94-201">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="aea94-201">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="aea94-202">412</span><span class="sxs-lookup"><span data-stu-id="aea94-202">412</span></span>| <span data-ttu-id="aea94-203">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="aea94-203">Precondition Failed</span></span>| <span data-ttu-id="aea94-204">一覧のバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="aea94-204">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="aea94-205">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="aea94-205">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="aea94-206">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="aea94-206">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="aea94-207">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-207">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="aea94-208">500</span><span class="sxs-lookup"><span data-stu-id="aea94-208">500</span></span>| <span data-ttu-id="aea94-209">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="aea94-209">Internal Server Error</span></span>| <span data-ttu-id="aea94-210">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="aea94-210">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="aea94-211">501</span><span class="sxs-lookup"><span data-stu-id="aea94-211">501</span></span>| <span data-ttu-id="aea94-212">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="aea94-212">Not Implemented</span></span>| <span data-ttu-id="aea94-213">呼び出し元が要求 URI では、サーバーで実装されていません。</span><span class="sxs-lookup"><span data-stu-id="aea94-213">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="aea94-214">(現在のみを使用するとき、要求の対象となるがホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="aea94-214">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="aea94-215">503</span><span class="sxs-lookup"><span data-stu-id="aea94-215">503</span></span>| <span data-ttu-id="aea94-216">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="aea94-216">Service Unavailable</span></span>| <span data-ttu-id="aea94-217">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="aea94-217">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="aea94-218">遅延の後 (参照、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="aea94-218">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4EEAAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="aea94-219">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="aea94-219">Required Request Headers</span></span>
 
| <span data-ttu-id="aea94-220">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="aea94-220">Header</span></span>| <span data-ttu-id="aea94-221">説明</span><span class="sxs-lookup"><span data-stu-id="aea94-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="aea94-222">Authorization</span><span class="sxs-lookup"><span data-stu-id="aea94-222">Authorization</span></span>| <span data-ttu-id="aea94-223">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="aea94-223">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="aea94-224">トークンが XSTS サービスからをクレームの 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="aea94-224">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="aea94-225">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="aea94-225">X-XBL-Contract-Version</span></span>| <span data-ttu-id="aea94-226">要求された (正の整数) をされている API バージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="aea94-226">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="aea94-227">ピンがサポートするバージョン 2 します。</span><span class="sxs-lookup"><span data-stu-id="aea94-227">Pins supports version 2.</span></span> <span data-ttu-id="aea94-228">このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="aea94-228">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="aea94-229">Content-Type</span><span class="sxs-lookup"><span data-stu-id="aea94-229">Content-Type</span></span>| <span data-ttu-id="aea94-230">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="aea94-230">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="aea94-231">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="aea94-231">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="aea94-232">If-Match</span><span class="sxs-lookup"><span data-stu-id="aea94-232">If-Match</span></span>| <span data-ttu-id="aea94-233">このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="aea94-233">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="aea94-234">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="aea94-234">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="aea94-235">"If-match"ヘッダー内のバージョンで、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="aea94-235">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="aea94-236">(省略可能)また場合に使用できますの取得、現在、渡されたバージョン一覧の現在のバージョンし、一覧データがないと一致する HTTP 304 – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="aea94-236">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4E1BAC"></a>

 
## <a name="sample-request"></a><span data-ttu-id="aea94-237">要求の例</span><span class="sxs-lookup"><span data-stu-id="aea94-237">Sample request</span></span>
 
<span data-ttu-id="aea94-238">**コンテンツ タイプ**、 **ItemId**または**ProviderId**、**プロバイダー** 、**ロケール**は必須です。</span><span class="sxs-lookup"><span data-stu-id="aea94-238">**ContentType**, **ItemId** or **ProviderId**, **Provider** and **Locale** are mandatory.</span></span>
 

```cpp
{"Items":
  [{
    "ContentType": "Movie",
    "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
    "ProviderId": "",
    "Provider": "",
    "ImageUrl": "http://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC", 
    "AltImageUrl": null, 
    "Title": "The Dark Knight", 
    "SubTitle": null, 
    "Locale": "en-us",
    "DeviceType": "XboxOne"
  }]}
      
```

  
<a id="ID4EPCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="aea94-239">応答本文</span><span class="sxs-lookup"><span data-stu-id="aea94-239">Response body</span></span>
 
<a id="ID4EVCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="aea94-240">応答の例</span><span class="sxs-lookup"><span data-stu-id="aea94-240">Sample response</span></span>
 

```cpp
{
  "ListVersion":  1,
  "ListCount":  1,
  "MaxListSize": 200,
  "AllowDuplicates": "true",
  "AccessSetting":  "OwnerOnly"
}        
         
```

   
<a id="ID4E6CAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="aea94-241">関連項目</span><span class="sxs-lookup"><span data-stu-id="aea94-241">See also</span></span>
 
<a id="ID4EBDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="aea94-242">Parent</span><span class="sxs-lookup"><span data-stu-id="aea94-242">Parent</span></span> 

[<span data-ttu-id="aea94-243">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="aea94-243">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

   