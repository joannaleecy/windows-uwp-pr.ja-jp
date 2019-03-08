---
title: POST (/users/xuid(xuid)/lists/PINS/{listname})
assetID: 813c0bd2-aca9-a1f6-9e81-a84a4c897b1e
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamepost.html
description: " POST (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d30e5407be128032947f3f701f59ef25a16daaea
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589977"
---
# <a name="post-usersxuidxuidlistspinslistname"></a><span data-ttu-id="1751a-104">POST (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="1751a-104">POST (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="1751a-105">クエリ文字列パラメーターに基づいてインデックス位置にある一覧に項目を挿入**insertIndex**します。</span><span class="sxs-lookup"><span data-stu-id="1751a-105">Inserts items into the list at the index based on the query string parameter **insertIndex**.</span></span> <span data-ttu-id="1751a-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="1751a-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="1751a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="1751a-107">Remarks</span></span>](#ID4EY)
  * [<span data-ttu-id="1751a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1751a-108">URI parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="1751a-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="1751a-109">Query string parameters</span></span>](#ID4E5B)
  * [<span data-ttu-id="1751a-110">承認</span><span class="sxs-lookup"><span data-stu-id="1751a-110">Authorization</span></span>](#ID4EZC)
  * [<span data-ttu-id="1751a-111">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="1751a-111">HTTP status codes</span></span>](#ID4EGD)
  * [<span data-ttu-id="1751a-112">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1751a-112">Required Request Headers</span></span>](#ID4EEAAC)
  * [<span data-ttu-id="1751a-113">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="1751a-113">Sample request</span></span>](#ID4E1BAC)
  * [<span data-ttu-id="1751a-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="1751a-114">Response body</span></span>](#ID4EPCAC)
 
<a id="ID4EY"></a>

 
## <a name="remarks"></a><span data-ttu-id="1751a-115">注釈</span><span class="sxs-lookup"><span data-stu-id="1751a-115">Remarks</span></span>
 
<span data-ttu-id="1751a-116">この呼び出しは、リスト、クエリ文字列パラメーターに基づいてインデックス位置に項目を挿入**insertIndex** (0 またはリストの先頭に既定値)。</span><span class="sxs-lookup"><span data-stu-id="1751a-116">This call will insert items into the list at the index based on the query string parameter **insertIndex** (defaults to 0 or the beginning of the list).</span></span> <span data-ttu-id="1751a-117">要求本文のすべての項目は、一覧でその時点で挿入されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-117">All items in the request body will be inserted at that point in the list.</span></span> <span data-ttu-id="1751a-118">場合、 **insertIndex**数よりも大きいが、最後に、既存の一覧で項目の新しい項目が挿入されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-118">If the **insertIndex** is greater than the number of items in the existing list, the new items will be inserted at the end.</span></span>
 
<span data-ttu-id="1751a-119">挿入する項目を必要なフィールドが; 機能仕様に示されている必要があります。それ以外の場合、HTTP 400 が返されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-119">Items to be inserted must have the required fields indicated in the functional spec; otherwise, an HTTP 400 will be returned.</span></span> <span data-ttu-id="1751a-120">同様に、挿入の結果は (リストの種類ごとに定義された) リストの最大サイズを超える場合、HTTP 400 が返されます、何も挿入されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-120">Similarly, if the result of the insert will exceed the maximum size of the list (defined per list type) then an HTTP 400 will be returned and nothing will be inserted.</span></span>
 
<span data-ttu-id="1751a-121">項目が場合*いない*、先頭またはリストの末尾に挿入する、**場合-一致: versionNumber**ヘッダーが要求に含まれている必要。</span><span class="sxs-lookup"><span data-stu-id="1751a-121">If the item is *not* to be inserted at the beginning or the end of the list, then the **If-Match:versionNumber** header is required to be included in the request.</span></span> <span data-ttu-id="1751a-122">ヘッダーでは、カーソルが先頭または末尾の場合は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="1751a-122">The header is optional if the insertion is for the beginning or the end.</span></span> <span data-ttu-id="1751a-123">存在する場合は、挿入場所に関係なく、ヘッダーが検証されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-123">If present, the header will be validated regardless of the insert location.</span></span> <span data-ttu-id="1751a-124">ヘッダーに**VersionNumber**リストの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="1751a-124">In the header **VersionNumber** is the current version number of the list.</span></span> <span data-ttu-id="1751a-125">いない含まれており、必要な場合または現在のリストのバージョン番号、HTTP 412 (precondition できませんでした) に一致しない状態コードが返され、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="1751a-125">If it is not included and required, or does not match the current list version number, then an HTTP 412 (precondition failed) status code will be returned and the body of the response will contain the latest metadata of the list that includes the current version number.</span></span> <span data-ttu-id="1751a-126">これは、いずれかの別の踏み潰す別のクライアントからの更新を防ぐ。</span><span class="sxs-lookup"><span data-stu-id="1751a-126">This is to guard against updates from different clients trampling on one another.</span></span>
 
<span data-ttu-id="1751a-127">この呼び出しがべき等である; ではないことに注意してください。同じデータを繰り返し呼び出すは、複数の挿入になる可能性があります。</span><span class="sxs-lookup"><span data-stu-id="1751a-127">Note that this call is not idempotent; repeated calls with the same data could result in multiple insertions.</span></span> <span data-ttu-id="1751a-128">ただし、一覧には、重複部分を現在サポートするものはありません、ために繰り返される呼び出しは HTTP 400 で可能性の高い結果コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-128">However, since no list currently supports duplicates, repeated calls will likely result in HTTP 400 codes being returned.</span></span>
  
<a id="ID4ETB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="1751a-129">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="1751a-129">URI parameters</span></span>
 
| <span data-ttu-id="1751a-130">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1751a-130">Parameter</span></span>| <span data-ttu-id="1751a-131">種類</span><span class="sxs-lookup"><span data-stu-id="1751a-131">Type</span></span>| <span data-ttu-id="1751a-132">説明</span><span class="sxs-lookup"><span data-stu-id="1751a-132">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="1751a-133">xuid</span><span class="sxs-lookup"><span data-stu-id="1751a-133">xuid</span></span>| <span data-ttu-id="1751a-134">string</span><span class="sxs-lookup"><span data-stu-id="1751a-134">string</span></span>| <span data-ttu-id="1751a-135">Xbox のユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="1751a-135">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="1751a-136">listtype</span><span class="sxs-lookup"><span data-stu-id="1751a-136">listtype</span></span>| <span data-ttu-id="1751a-137">string</span><span class="sxs-lookup"><span data-stu-id="1751a-137">string</span></span>| <span data-ttu-id="1751a-138">(その使用方法およびどのように機能します) のリストの種類。</span><span class="sxs-lookup"><span data-stu-id="1751a-138">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="1751a-139">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="1751a-139">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="1751a-140">listname</span><span class="sxs-lookup"><span data-stu-id="1751a-140">listname</span></span>| <span data-ttu-id="1751a-141">string</span><span class="sxs-lookup"><span data-stu-id="1751a-141">string</span></span>| <span data-ttu-id="1751a-142">リストの名前 (を操作する特定の listtype のどのリスト)。</span><span class="sxs-lookup"><span data-stu-id="1751a-142">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="1751a-143">常に"XBLPins"の項目のピンです。</span><span class="sxs-lookup"><span data-stu-id="1751a-143">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4E5B"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="1751a-144">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="1751a-144">Query string parameters</span></span>
 
| <span data-ttu-id="1751a-145">パラメーター</span><span class="sxs-lookup"><span data-stu-id="1751a-145">Parameter</span></span>| <span data-ttu-id="1751a-146">種類</span><span class="sxs-lookup"><span data-stu-id="1751a-146">Type</span></span>| <span data-ttu-id="1751a-147">説明</span><span class="sxs-lookup"><span data-stu-id="1751a-147">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1751a-148">insertIndex</span><span class="sxs-lookup"><span data-stu-id="1751a-148">insertIndex</span></span>| <span data-ttu-id="1751a-149">string</span><span class="sxs-lookup"><span data-stu-id="1751a-149">string</span></span>| <span data-ttu-id="1751a-150">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="1751a-150">Optional.</span></span> <span data-ttu-id="1751a-151">項目を挿入する位置を定義します。</span><span class="sxs-lookup"><span data-stu-id="1751a-151">Defines where to insert items.</span></span> <span data-ttu-id="1751a-152">サポートされる値:0、正の整数と「終了」です。</span><span class="sxs-lookup"><span data-stu-id="1751a-152">Supported values: 0, positive integers, and "end".</span></span> <span data-ttu-id="1751a-153">リスト項目の数より大きいインデックス値は、一覧の下部にある新しい項目を追加し、一覧で"blank"のスペースは挿入されません。</span><span class="sxs-lookup"><span data-stu-id="1751a-153">Any index value greater than the number of list items will add the new item at the bottom of the list, and will not insert "blank" space in the list.</span></span> <span data-ttu-id="1751a-154">［既定値］:0。</span><span class="sxs-lookup"><span data-stu-id="1751a-154">Default value: 0.</span></span>| 
  
<a id="ID4EZC"></a>

 
## <a name="authorization"></a><span data-ttu-id="1751a-155">Authorization</span><span class="sxs-lookup"><span data-stu-id="1751a-155">Authorization</span></span>
 
<span data-ttu-id="1751a-156">この呼び出しで、XSTS SAML トークンが必要ですが、**承認**ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="1751a-156">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="1751a-157">Xuid 要求は、呼び出し元を識別するために SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1751a-157">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="1751a-158">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="1751a-158">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="1751a-159">リスト自体も Xuid によって識別され、一覧については、URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="1751a-159">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="1751a-160">これを使用して今後リストへのアクセスの共有のサポートがする機能ではありません、この時点で。</span><span class="sxs-lookup"><span data-stu-id="1751a-160">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="1751a-161">現時点では、ユーザーがアクセスするすべてのリストになりますが自分と共有アクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="1751a-161">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="1751a-162">したがって URI に Xuid は、SAML 要求トークンで Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="1751a-162">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="1751a-163">現時点では、XBL Auth 2.0 と 3.0 のトークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="1751a-163">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4EGD"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="1751a-164">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="1751a-164">HTTP status codes</span></span>
 
<span data-ttu-id="1751a-165">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="1751a-165">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="1751a-166">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="1751a-166">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="1751a-167">コード</span><span class="sxs-lookup"><span data-stu-id="1751a-167">Code</span></span>| <span data-ttu-id="1751a-168">理由語句</span><span class="sxs-lookup"><span data-stu-id="1751a-168">Reason phrase</span></span>| <span data-ttu-id="1751a-169">説明</span><span class="sxs-lookup"><span data-stu-id="1751a-169">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1751a-170">200</span><span class="sxs-lookup"><span data-stu-id="1751a-170">200</span></span>| <span data-ttu-id="1751a-171">OK</span><span class="sxs-lookup"><span data-stu-id="1751a-171">OK</span></span>| <span data-ttu-id="1751a-172">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="1751a-172">The request completed successfully.</span></span> <span data-ttu-id="1751a-173">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="1751a-173">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="1751a-174">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-174">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="1751a-175">201</span><span class="sxs-lookup"><span data-stu-id="1751a-175">201</span></span>| <span data-ttu-id="1751a-176">作成日</span><span class="sxs-lookup"><span data-stu-id="1751a-176">Created</span></span>| <span data-ttu-id="1751a-177">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="1751a-177">A new list has been created.</span></span> <span data-ttu-id="1751a-178">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-178">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="1751a-179">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="1751a-179">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="1751a-180">304</span><span class="sxs-lookup"><span data-stu-id="1751a-180">304</span></span>| <span data-ttu-id="1751a-181">変更されていません</span><span class="sxs-lookup"><span data-stu-id="1751a-181">Not Modified</span></span>| <span data-ttu-id="1751a-182">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="1751a-182">Returned on GETs.</span></span> <span data-ttu-id="1751a-183">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="1751a-183">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="1751a-184">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="1751a-184">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="1751a-185">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-185">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="1751a-186">400</span><span class="sxs-lookup"><span data-stu-id="1751a-186">400</span></span>| <span data-ttu-id="1751a-187">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="1751a-187">Bad Request</span></span>| <span data-ttu-id="1751a-188">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="1751a-188">The request was malformed.</span></span> <span data-ttu-id="1751a-189">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="1751a-189">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="1751a-190">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-190">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="1751a-191">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="1751a-191">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="1751a-192">401</span><span class="sxs-lookup"><span data-stu-id="1751a-192">401</span></span>| <span data-ttu-id="1751a-193">権限がありません</span><span class="sxs-lookup"><span data-stu-id="1751a-193">Unauthorized</span></span>| <span data-ttu-id="1751a-194">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="1751a-194">The request requires user authentication.</span></span>| 
| <span data-ttu-id="1751a-195">403</span><span class="sxs-lookup"><span data-stu-id="1751a-195">403</span></span>| <span data-ttu-id="1751a-196">Forbidden</span><span class="sxs-lookup"><span data-stu-id="1751a-196">Forbidden</span></span>| <span data-ttu-id="1751a-197">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="1751a-197">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="1751a-198">404</span><span class="sxs-lookup"><span data-stu-id="1751a-198">404</span></span>| <span data-ttu-id="1751a-199">検出不可</span><span class="sxs-lookup"><span data-stu-id="1751a-199">Not Found</span></span>| <span data-ttu-id="1751a-200">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="1751a-200">The caller does not have access to the resource.</span></span> <span data-ttu-id="1751a-201">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="1751a-201">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="1751a-202">412</span><span class="sxs-lookup"><span data-stu-id="1751a-202">412</span></span>| <span data-ttu-id="1751a-203">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="1751a-203">Precondition Failed</span></span>| <span data-ttu-id="1751a-204">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="1751a-204">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="1751a-205">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="1751a-205">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="1751a-206">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="1751a-206">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="1751a-207">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-207">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="1751a-208">500</span><span class="sxs-lookup"><span data-stu-id="1751a-208">500</span></span>| <span data-ttu-id="1751a-209">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="1751a-209">Internal Server Error</span></span>| <span data-ttu-id="1751a-210">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="1751a-210">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="1751a-211">501</span><span class="sxs-lookup"><span data-stu-id="1751a-211">501</span></span>| <span data-ttu-id="1751a-212">実装されていません</span><span class="sxs-lookup"><span data-stu-id="1751a-212">Not Implemented</span></span>| <span data-ttu-id="1751a-213">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="1751a-213">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="1751a-214">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="1751a-214">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="1751a-215">503</span><span class="sxs-lookup"><span data-stu-id="1751a-215">503</span></span>| <span data-ttu-id="1751a-216">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="1751a-216">Service Unavailable</span></span>| <span data-ttu-id="1751a-217">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="1751a-217">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="1751a-218">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="1751a-218">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4EEAAC"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="1751a-219">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="1751a-219">Required Request Headers</span></span>
 
| <span data-ttu-id="1751a-220">Header</span><span class="sxs-lookup"><span data-stu-id="1751a-220">Header</span></span>| <span data-ttu-id="1751a-221">説明</span><span class="sxs-lookup"><span data-stu-id="1751a-221">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="1751a-222">Authorization</span><span class="sxs-lookup"><span data-stu-id="1751a-222">Authorization</span></span>| <span data-ttu-id="1751a-223">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1751a-223">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="1751a-224">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="1751a-224">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="1751a-225">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="1751a-225">X-XBL-Contract-Version</span></span>| <span data-ttu-id="1751a-226">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="1751a-226">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="1751a-227">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="1751a-227">Pins supports version 2.</span></span> <span data-ttu-id="1751a-228">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="1751a-228">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="1751a-229">Content-Type</span><span class="sxs-lookup"><span data-stu-id="1751a-229">Content-Type</span></span>| <span data-ttu-id="1751a-230">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="1751a-230">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="1751a-231">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="1751a-231">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="1751a-232">If-Match</span><span class="sxs-lookup"><span data-stu-id="1751a-232">If-Match</span></span>| <span data-ttu-id="1751a-233">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="1751a-233">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="1751a-234">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="1751a-234">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="1751a-235">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="1751a-235">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="1751a-236">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="1751a-236">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4E1BAC"></a>

 
## <a name="sample-request"></a><span data-ttu-id="1751a-237">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="1751a-237">Sample request</span></span>
 
<span data-ttu-id="1751a-238">**ContentType**、 **ItemId**または**ProviderId**、**プロバイダー**と**ロケール**は必須です。</span><span class="sxs-lookup"><span data-stu-id="1751a-238">**ContentType**, **ItemId** or **ProviderId**, **Provider** and **Locale** are mandatory.</span></span>
 

```cpp
{"Items":
  [{
    "ContentType": "Movie",
    "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
    "ProviderId": "",
    "Provider": "",
    "ImageUrl": "https://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC", 
    "AltImageUrl": null, 
    "Title": "The Dark Knight", 
    "SubTitle": null, 
    "Locale": "en-us",
    "DeviceType": "XboxOne"
  }]}
      
```

  
<a id="ID4EPCAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="1751a-239">応答本文</span><span class="sxs-lookup"><span data-stu-id="1751a-239">Response body</span></span>
 
<a id="ID4EVCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="1751a-240">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="1751a-240">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="1751a-241">関連項目</span><span class="sxs-lookup"><span data-stu-id="1751a-241">See also</span></span>
 
<a id="ID4EBDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="1751a-242">Parent</span><span class="sxs-lookup"><span data-stu-id="1751a-242">Parent</span></span> 

[<span data-ttu-id="1751a-243">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="1751a-243">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

   