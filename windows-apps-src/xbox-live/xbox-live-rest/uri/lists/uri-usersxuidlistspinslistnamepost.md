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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881590"
---
# <a name="post-usersxuidxuidlistspinslistname"></a><span data-ttu-id="7b835-104">POST (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="7b835-104">POST (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="7b835-105">クエリ文字列パラメーター **insertIndex**に基づいてインデックスの一覧に項目を挿入します。</span><span class="sxs-lookup"><span data-stu-id="7b835-105">Inserts items into the list at the index based on the query string parameter **insertIndex**.</span></span> <span data-ttu-id="7b835-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="7b835-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="7b835-107">注釈</span><span class="sxs-lookup"><span data-stu-id="7b835-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="7b835-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7b835-108">URI parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="7b835-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="7b835-109">Query string parameters</span></span>](#ID4E5B)
  * [<span data-ttu-id="7b835-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="7b835-110">Authorization</span></span>](#ID4EZC)
  * [<span data-ttu-id="7b835-111">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7b835-111">HTTP status codes</span></span>](#ID4EGD)
  * [<span data-ttu-id="7b835-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7b835-112">Required Request Headers</span></span>](#ID4EEAAC)
  * [<span data-ttu-id="7b835-113">要求の例</span><span class="sxs-lookup"><span data-stu-id="7b835-113">Sample request</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="7b835-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="7b835-114">Response body</span></span>](#ID4EPCAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="7b835-115">注釈</span><span class="sxs-lookup"><span data-stu-id="7b835-115">Remarks</span></span>
 
<span data-ttu-id="7b835-116">この呼び出しは、クエリ文字列パラメーター **insertIndex** (0 または一覧の先頭に既定値) に基づくインデックス リストに項目を挿入します。</span><span class="sxs-lookup"><span data-stu-id="7b835-116">This call will insert items into the list at the index based on the query string parameter **insertIndex** (defaults to 0 or the beginning of the list).</span></span> <span data-ttu-id="7b835-117">要求本文のすべての項目は、その時点で一覧に挿入されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-117">All items in the request body will be inserted at that point in the list.</span></span> <span data-ttu-id="7b835-118">**InsertIndex**が、既存の一覧で項目の数よりも大きい場合は、最後に、新しい項目が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-118">If the **insertIndex** is greater than the number of items in the existing list, the new items will be inserted at the end.</span></span>
 
<span data-ttu-id="7b835-119">挿入する項目の必須フィールド機能仕様では、; に示されている必要があります。それ以外の場合、HTTP 400 が返されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-119">Items to be inserted must have the required fields indicated in the functional spec; otherwise, an HTTP 400 will be returned.</span></span> <span data-ttu-id="7b835-120">同様に、挿入の結果は (一覧の種類ごとに定義されている) リストの最大サイズを超える場合、HTTP 400 が返され、何が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-120">Similarly, if the result of the insert will exceed the maximum size of the list (defined per list type) then an HTTP 400 will be returned and nothing will be inserted.</span></span>
 
<span data-ttu-id="7b835-121">項目が場合*いない*または、一覧の最後の先頭に挿入する、**場合-マッチ: versionNumber**ヘッダーは、要求に含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b835-121">If the item is *not* to be inserted at the beginning or the end of the list, then the **If-Match:versionNumber** header is required to be included in the request.</span></span> <span data-ttu-id="7b835-122">ヘッダーは、先頭または末尾の場合は、カーソルはオプションです。</span><span class="sxs-lookup"><span data-stu-id="7b835-122">The header is optional if the insertion is for the beginning or the end.</span></span> <span data-ttu-id="7b835-123">存在する場合、ヘッダーが挿入場所に関係なく検証されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-123">If present, the header will be validated regardless of the insert location.</span></span> <span data-ttu-id="7b835-124">ヘッダーで**VersionNumber**はリストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="7b835-124">In the header **VersionNumber** is the current version number of the list.</span></span> <span data-ttu-id="7b835-125">いない含まれており、必要な場合や、現在の一覧のバージョン番号し、http/412 (precondition failed) が一致しない状態コードが返され、応答の本文には、現在のバージョン番号を含む一覧の最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="7b835-125">If it is not included and required, or does not match the current list version number, then an HTTP 412 (precondition failed) status code will be returned and the body of the response will contain the latest metadata of the list that includes the current version number.</span></span> <span data-ttu-id="7b835-126">これは、互いに踏み潰すさまざまなクライアントからの更新プログラムを防ぐためです。</span><span class="sxs-lookup"><span data-stu-id="7b835-126">This is to guard against updates from different clients trampling on one another.</span></span>
 
<span data-ttu-id="7b835-127">この呼び出しは、等; ではないことに注意してください。同じデータを繰り返し呼び出すと、複数の挿入する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="7b835-127">Note that this call is not idempotent; repeated calls with the same data could result in multiple insertions.</span></span> <span data-ttu-id="7b835-128">ただし、一覧現在サポートされているのでない重複、繰り返し呼び出すが返されるコードの HTTP 400 を得られます。</span><span class="sxs-lookup"><span data-stu-id="7b835-128">However, since no list currently supports duplicates, repeated calls will likely result in HTTP 400 codes being returned.</span></span>
  
<a id="ID4ETB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="7b835-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="7b835-129">URI parameters</span></span>
 
| <span data-ttu-id="7b835-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7b835-130">Parameter</span></span>| <span data-ttu-id="7b835-131">型</span><span class="sxs-lookup"><span data-stu-id="7b835-131">Type</span></span>| <span data-ttu-id="7b835-132">説明</span><span class="sxs-lookup"><span data-stu-id="7b835-132">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7b835-133">xuid</span><span class="sxs-lookup"><span data-stu-id="7b835-133">xuid</span></span>| <span data-ttu-id="7b835-134">string</span><span class="sxs-lookup"><span data-stu-id="7b835-134">string</span></span>| <span data-ttu-id="7b835-135">Xbox ユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="7b835-135">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="7b835-136">listtype</span><span class="sxs-lookup"><span data-stu-id="7b835-136">listtype</span></span>| <span data-ttu-id="7b835-137">string</span><span class="sxs-lookup"><span data-stu-id="7b835-137">string</span></span>| <span data-ttu-id="7b835-138">(その使用方法と動作) の一覧の種類です。</span><span class="sxs-lookup"><span data-stu-id="7b835-138">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="7b835-139">常に「ピン」これらのメソッドを関連します。</span><span class="sxs-lookup"><span data-stu-id="7b835-139">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="7b835-140">リスト</span><span class="sxs-lookup"><span data-stu-id="7b835-140">listname</span></span>| <span data-ttu-id="7b835-141">string</span><span class="sxs-lookup"><span data-stu-id="7b835-141">string</span></span>| <span data-ttu-id="7b835-142">一覧の名前 (際に特定の listtype の一覧がどの)。</span><span class="sxs-lookup"><span data-stu-id="7b835-142">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="7b835-143">常に"XBLPins"の項目を Pin にします。</span><span class="sxs-lookup"><span data-stu-id="7b835-143">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4E5B"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="7b835-144">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="7b835-144">Query string parameters</span></span>
 
| <span data-ttu-id="7b835-145">パラメーター</span><span class="sxs-lookup"><span data-stu-id="7b835-145">Parameter</span></span>| <span data-ttu-id="7b835-146">型</span><span class="sxs-lookup"><span data-stu-id="7b835-146">Type</span></span>| <span data-ttu-id="7b835-147">説明</span><span class="sxs-lookup"><span data-stu-id="7b835-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7b835-148">insertIndex</span><span class="sxs-lookup"><span data-stu-id="7b835-148">insertIndex</span></span>| <span data-ttu-id="7b835-149">string</span><span class="sxs-lookup"><span data-stu-id="7b835-149">string</span></span>| <span data-ttu-id="7b835-150">省略可能。</span><span class="sxs-lookup"><span data-stu-id="7b835-150">Optional.</span></span> <span data-ttu-id="7b835-151">項目を挿入する位置を定義します。</span><span class="sxs-lookup"><span data-stu-id="7b835-151">Defines where to insert items.</span></span> <span data-ttu-id="7b835-152">サポートされる値: 0、正の整数と「終了」。</span><span class="sxs-lookup"><span data-stu-id="7b835-152">Supported values: 0, positive integers, and "end".</span></span> <span data-ttu-id="7b835-153">リスト項目の数よりも大きいインデックス値は、一覧の下部に新しい項目を追加し、一覧に「空白」は挿入されません。</span><span class="sxs-lookup"><span data-stu-id="7b835-153">Any index value greater than the number of list items will add the new item at the bottom of the list, and will not insert "blank" space in the list.</span></span> <span data-ttu-id="7b835-154">既定値: 0 です。</span><span class="sxs-lookup"><span data-stu-id="7b835-154">Default value: 0.</span></span>| 
  
<a id="ID4EZC"></a>

 
## <a name="authorization"></a><span data-ttu-id="7b835-155">Authorization</span><span class="sxs-lookup"><span data-stu-id="7b835-155">Authorization</span></span>
 
<span data-ttu-id="7b835-156">この呼び出しは、**承認**ヘッダーで、XSTS SAML トークンを想定しています。</span><span class="sxs-lookup"><span data-stu-id="7b835-156">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="7b835-157">Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b835-157">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="7b835-158">この値は、呼び出し元に該当する一覧データへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="7b835-158">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="7b835-159">一覧自体では、同様の Xuid を識別し、一覧については、URI が追加します。</span><span class="sxs-lookup"><span data-stu-id="7b835-159">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="7b835-160">これを使用して、します、今後、一覧へのアクセスの共有のサポートがいる機能ではありませんこの時点で。</span><span class="sxs-lookup"><span data-stu-id="7b835-160">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="7b835-161">現時点では、ユーザーがアクセスするすべてのリストが独自と共有アクセスができなくなります。</span><span class="sxs-lookup"><span data-stu-id="7b835-161">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="7b835-162">したがって、URI の Xuid は SAML 要求トークンの Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b835-162">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="7b835-163">現時点では、XBL 認証 2.0 と 3.0 トークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="7b835-163">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4EGD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="7b835-164">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="7b835-164">HTTP status codes</span></span>
 
<span data-ttu-id="7b835-165">サービスは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションでステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="7b835-165">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="7b835-166">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7b835-166">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="7b835-167">コード</span><span class="sxs-lookup"><span data-stu-id="7b835-167">Code</span></span>| <span data-ttu-id="7b835-168">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="7b835-168">Reason phrase</span></span>| <span data-ttu-id="7b835-169">説明</span><span class="sxs-lookup"><span data-stu-id="7b835-169">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7b835-170">200</span><span class="sxs-lookup"><span data-stu-id="7b835-170">200</span></span>| <span data-ttu-id="7b835-171">OK</span><span class="sxs-lookup"><span data-stu-id="7b835-171">OK</span></span>| <span data-ttu-id="7b835-172">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="7b835-172">The request completed successfully.</span></span> <span data-ttu-id="7b835-173">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b835-173">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="7b835-174">POST、PUT 要求は、最新の状態の一覧のメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-174">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="7b835-175">201</span><span class="sxs-lookup"><span data-stu-id="7b835-175">201</span></span>| <span data-ttu-id="7b835-176">Created</span><span class="sxs-lookup"><span data-stu-id="7b835-176">Created</span></span>| <span data-ttu-id="7b835-177">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="7b835-177">A new list has been created.</span></span> <span data-ttu-id="7b835-178">これは、最初の挿入の一覧に返されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-178">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="7b835-179">応答には、一覧の最新の状態のメタデータが含まれています。 と場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7b835-179">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="7b835-180">304</span><span class="sxs-lookup"><span data-stu-id="7b835-180">304</span></span>| <span data-ttu-id="7b835-181">Not Modified</span><span class="sxs-lookup"><span data-stu-id="7b835-181">Not Modified</span></span>| <span data-ttu-id="7b835-182">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-182">Returned on GETs.</span></span> <span data-ttu-id="7b835-183">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="7b835-183">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="7b835-184">サービスは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="7b835-184">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="7b835-185">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-185">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="7b835-186">400</span><span class="sxs-lookup"><span data-stu-id="7b835-186">400</span></span>| <span data-ttu-id="7b835-187">Bad Request</span><span class="sxs-lookup"><span data-stu-id="7b835-187">Bad Request</span></span>| <span data-ttu-id="7b835-188">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="7b835-188">The request was malformed.</span></span> <span data-ttu-id="7b835-189">無効な値、または URI またはクエリ文字列パラメーターの型にすることができます。</span><span class="sxs-lookup"><span data-stu-id="7b835-189">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="7b835-190">不足している必要なパラメーターの結果ことができます。 またはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-190">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="7b835-191"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="7b835-191">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="7b835-192">401</span><span class="sxs-lookup"><span data-stu-id="7b835-192">401</span></span>| <span data-ttu-id="7b835-193">権限がありません</span><span class="sxs-lookup"><span data-stu-id="7b835-193">Unauthorized</span></span>| <span data-ttu-id="7b835-194">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="7b835-194">The request requires user authentication.</span></span>| 
| <span data-ttu-id="7b835-195">403</span><span class="sxs-lookup"><span data-stu-id="7b835-195">403</span></span>| <span data-ttu-id="7b835-196">Forbidden</span><span class="sxs-lookup"><span data-stu-id="7b835-196">Forbidden</span></span>| <span data-ttu-id="7b835-197">要求は、ユーザーまたはサービスは許可されません。</span><span class="sxs-lookup"><span data-stu-id="7b835-197">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="7b835-198">404</span><span class="sxs-lookup"><span data-stu-id="7b835-198">404</span></span>| <span data-ttu-id="7b835-199">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="7b835-199">Not Found</span></span>| <span data-ttu-id="7b835-200">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="7b835-200">The caller does not have access to the resource.</span></span> <span data-ttu-id="7b835-201">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="7b835-201">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="7b835-202">412</span><span class="sxs-lookup"><span data-stu-id="7b835-202">412</span></span>| <span data-ttu-id="7b835-203">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="7b835-203">Precondition Failed</span></span>| <span data-ttu-id="7b835-204">一覧のバージョンが変更されていて、変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="7b835-204">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="7b835-205">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="7b835-205">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="7b835-206">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="7b835-206">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="7b835-207">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在の一覧メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-207">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="7b835-208">500</span><span class="sxs-lookup"><span data-stu-id="7b835-208">500</span></span>| <span data-ttu-id="7b835-209">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="7b835-209">Internal Server Error</span></span>| <span data-ttu-id="7b835-210">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="7b835-210">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="7b835-211">501</span><span class="sxs-lookup"><span data-stu-id="7b835-211">501</span></span>| <span data-ttu-id="7b835-212">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="7b835-212">Not Implemented</span></span>| <span data-ttu-id="7b835-213">呼び出し元では、サーバーで実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="7b835-213">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="7b835-214">(現在だけの場合、要求の対象となるがホワイト リスト名。)</span><span class="sxs-lookup"><span data-stu-id="7b835-214">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="7b835-215">503</span><span class="sxs-lookup"><span data-stu-id="7b835-215">503</span></span>| <span data-ttu-id="7b835-216">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="7b835-216">Service Unavailable</span></span>| <span data-ttu-id="7b835-217">サーバーは通常負荷が高くなり、要求を拒否します。</span><span class="sxs-lookup"><span data-stu-id="7b835-217">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="7b835-218">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="7b835-218">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4EEAAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="7b835-219">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7b835-219">Required Request Headers</span></span>
 
| <span data-ttu-id="7b835-220">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="7b835-220">Header</span></span>| <span data-ttu-id="7b835-221">説明</span><span class="sxs-lookup"><span data-stu-id="7b835-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="7b835-222">Authorization</span><span class="sxs-lookup"><span data-stu-id="7b835-222">Authorization</span></span>| <span data-ttu-id="7b835-223">認証し、要求を承認するために使用 STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7b835-223">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="7b835-224">トークンが XSTS サービスからと、要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b835-224">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="7b835-225">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="7b835-225">X-XBL-Contract-Version</span></span>| <span data-ttu-id="7b835-226">要求された (正の整数) をされている API バージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="7b835-226">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="7b835-227">バージョン 2 でピンをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="7b835-227">Pins supports version 2.</span></span> <span data-ttu-id="7b835-228">このヘッダーが存在しないか、サービスは、400-を返します、値がサポートされていない状態の説明に「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="7b835-228">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="7b835-229">Content-Type</span><span class="sxs-lookup"><span data-stu-id="7b835-229">Content-Type</span></span>| <span data-ttu-id="7b835-230">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="7b835-230">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="7b835-231">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="7b835-231">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="7b835-232">If-Match</span><span class="sxs-lookup"><span data-stu-id="7b835-232">If-Match</span></span>| <span data-ttu-id="7b835-233">このヘッダーは、変更要求を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7b835-233">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="7b835-234">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="7b835-234">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="7b835-235">現在のバージョン一覧の"If-match"ヘッダー内のバージョンが一致しない場合、http/412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="7b835-235">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="7b835-236">(省略可能)使用できますの取得、現在の一覧のバージョンし一覧データがないと、HTTP 304 存在と渡されたバージョンに一致する場合は変更されませんコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="7b835-236">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4E1BAC"></a>

 
## <a name="sample-request"></a><span data-ttu-id="7b835-237">要求の例</span><span class="sxs-lookup"><span data-stu-id="7b835-237">Sample request</span></span>
 
<span data-ttu-id="7b835-238">**コンテンツ タイプ**、 **ItemId**または**ProviderId**、**プロバイダー** 、**ロケール**は必須です。</span><span class="sxs-lookup"><span data-stu-id="7b835-238">**ContentType**, **ItemId** or **ProviderId**, **Provider** and **Locale** are mandatory.</span></span>
 

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

 
## <a name="response-body"></a><span data-ttu-id="7b835-239">応答本文</span><span class="sxs-lookup"><span data-stu-id="7b835-239">Response body</span></span>
 
<a id="ID4EVCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="7b835-240">応答の例</span><span class="sxs-lookup"><span data-stu-id="7b835-240">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="7b835-241">関連項目</span><span class="sxs-lookup"><span data-stu-id="7b835-241">See also</span></span>
 
<a id="ID4EBDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="7b835-242">Parent</span><span class="sxs-lookup"><span data-stu-id="7b835-242">Parent</span></span> 

[<span data-ttu-id="7b835-243">ユーザー/xuid (xuid)//ピン/{リスト} の一覧を示します</span><span class="sxs-lookup"><span data-stu-id="7b835-243">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

   