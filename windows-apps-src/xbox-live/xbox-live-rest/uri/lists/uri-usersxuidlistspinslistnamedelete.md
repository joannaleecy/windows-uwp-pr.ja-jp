---
title: DELETE (/users/xuid(xuid)/lists/PINS/{listname})
assetID: b43e3faa-7791-8bcb-3aec-7bdad8ffbebf
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnamedelete.html
description: " DELETE (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: eed1d73917be450038fdf098b802d0d7c1c44a7b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603347"
---
# <a name="delete-usersxuidxuidlistspinslistname"></a><span data-ttu-id="d2958-104">DELETE (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="d2958-104">DELETE (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="d2958-105">一覧から項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="d2958-105">Removes items from a list.</span></span> <span data-ttu-id="d2958-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="d2958-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="d2958-107">注釈</span><span class="sxs-lookup"><span data-stu-id="d2958-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="d2958-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d2958-108">URI parameters</span></span>](#ID4EIB)
  * [<span data-ttu-id="d2958-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="d2958-109">Query string parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="d2958-110">承認</span><span class="sxs-lookup"><span data-stu-id="d2958-110">Authorization</span></span>](#ID4ETC)
  * [<span data-ttu-id="d2958-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d2958-111">Required Request Headers</span></span>](#ID4EAD)
  * [<span data-ttu-id="d2958-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="d2958-112">Request body</span></span>](#ID4EWE)
  * [<span data-ttu-id="d2958-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="d2958-113">HTTP status codes</span></span>](#ID4EBF)
  * [<span data-ttu-id="d2958-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="d2958-114">Response body</span></span>](#ID4E6BAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="d2958-115">注釈</span><span class="sxs-lookup"><span data-stu-id="d2958-115">Remarks</span></span>
 
<span data-ttu-id="d2958-116">削除する項目はリスト内のインデックスで示されます、クエリ文字列パラメーターで識別されます**インデックス**します。</span><span class="sxs-lookup"><span data-stu-id="d2958-116">Items to be removed are indicated by their index in the list and are identified in the query string parameter **indexes**.</span></span> <span data-ttu-id="d2958-117">インデックスの一覧は、コンマ区切りにする必要があり、100 件のみインデックスを 1 回の呼び出しで渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="d2958-117">The list of indexes must be comma-delimited and only 100 indexes can be passed in a single call.</span></span> <span data-ttu-id="d2958-118">ただし、インデックスに (空のクエリ文字列パラメーター) が渡されない場合、リスト全体の内容は削除 (空のリストは残りますが、およびバージョン番号はインクリメントし続けます)。</span><span class="sxs-lookup"><span data-stu-id="d2958-118">However, if no indexes are passed (empty query string parameter) then the contents of the entire list will be deleted (an empty list will remain, and the version number will continue to increment).</span></span> <span data-ttu-id="d2958-119">項目が削除されると、リストは「圧縮」インデックスの順序に穴が残っていないようにします。</span><span class="sxs-lookup"><span data-stu-id="d2958-119">Once the items are removed, the list is "compacted" such that no holes are left in the ordering of indexes.</span></span> <span data-ttu-id="d2958-120">したがって、この呼び出しをべき等にすることはありません。</span><span class="sxs-lookup"><span data-stu-id="d2958-120">Therefore, this call is not idempotent.</span></span>
 
<span data-ttu-id="d2958-121">この呼び出しが必要です、**場合-一致: versionNumber** 、要求に含まれるヘッダー、 **versionNumber**ファイルの現在のバージョン番号です。</span><span class="sxs-lookup"><span data-stu-id="d2958-121">This call requires an **If-Match:versionNumber** header to be included in the request, where **versionNumber** is the current version number of the file.</span></span> <span data-ttu-id="d2958-122">現在のリストのバージョン番号、HTTP 412 (precondition に失敗しました) と一致しませんが、含まれていない場合は、状態コードが返されます、応答の本文には、現在のバージョン番号を含むリストの最新のメタデータにが含まれます。</span><span class="sxs-lookup"><span data-stu-id="d2958-122">If it is not included, or does not match the current list version number, then an HTTP 412 (precondition failed) status code will be returned and the body of the response will contain the latest metadata of the list that includes the current version number.</span></span> <span data-ttu-id="d2958-123">これは踏み潰すもう 1 つの異なるクライアントからの更新プログラムから保護するためです。</span><span class="sxs-lookup"><span data-stu-id="d2958-123">This is done to guard against updates from different clients trampling on one another.</span></span>
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="d2958-124">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="d2958-124">URI parameters</span></span>
 
| <span data-ttu-id="d2958-125">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d2958-125">Parameter</span></span>| <span data-ttu-id="d2958-126">種類</span><span class="sxs-lookup"><span data-stu-id="d2958-126">Type</span></span>| <span data-ttu-id="d2958-127">説明</span><span class="sxs-lookup"><span data-stu-id="d2958-127">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d2958-128">xuid</span><span class="sxs-lookup"><span data-stu-id="d2958-128">xuid</span></span>| <span data-ttu-id="d2958-129">string</span><span class="sxs-lookup"><span data-stu-id="d2958-129">string</span></span>| <span data-ttu-id="d2958-130">Xbox のユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="d2958-130">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="d2958-131">listtype</span><span class="sxs-lookup"><span data-stu-id="d2958-131">listtype</span></span>| <span data-ttu-id="d2958-132">string</span><span class="sxs-lookup"><span data-stu-id="d2958-132">string</span></span>| <span data-ttu-id="d2958-133">(その使用方法およびどのように機能します) のリストの種類。</span><span class="sxs-lookup"><span data-stu-id="d2958-133">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="d2958-134">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="d2958-134">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="d2958-135">listname</span><span class="sxs-lookup"><span data-stu-id="d2958-135">listname</span></span>| <span data-ttu-id="d2958-136">string</span><span class="sxs-lookup"><span data-stu-id="d2958-136">string</span></span>| <span data-ttu-id="d2958-137">リストの名前 (を操作する特定の listtype のどのリスト)。</span><span class="sxs-lookup"><span data-stu-id="d2958-137">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="d2958-138">常に"XBLPins"の項目のピンです。</span><span class="sxs-lookup"><span data-stu-id="d2958-138">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="d2958-139">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="d2958-139">Query string parameters</span></span>
 
| <span data-ttu-id="d2958-140">パラメーター</span><span class="sxs-lookup"><span data-stu-id="d2958-140">Parameter</span></span>| <span data-ttu-id="d2958-141">種類</span><span class="sxs-lookup"><span data-stu-id="d2958-141">Type</span></span>| <span data-ttu-id="d2958-142">説明</span><span class="sxs-lookup"><span data-stu-id="d2958-142">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d2958-143">インデックス</span><span class="sxs-lookup"><span data-stu-id="d2958-143">indexes</span></span>| <span data-ttu-id="d2958-144">string</span><span class="sxs-lookup"><span data-stu-id="d2958-144">string</span></span>| <span data-ttu-id="d2958-145">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="d2958-145">Optional.</span></span> <span data-ttu-id="d2958-146">項目を削除する場所を指定します。</span><span class="sxs-lookup"><span data-stu-id="d2958-146">Specifies where to remove items.</span></span> <span data-ttu-id="d2958-147">サポートされる値:0、正の整数と「終了」です。</span><span class="sxs-lookup"><span data-stu-id="d2958-147">Supported values: 0, positive integers, and "end".</span></span> <span data-ttu-id="d2958-148">［既定値］:0。</span><span class="sxs-lookup"><span data-stu-id="d2958-148">Default value: 0.</span></span>| 
 
<span data-ttu-id="d2958-149">例:**インデックス = 1, 8** 1 から 8 のインデックスで項目を削除します。</span><span class="sxs-lookup"><span data-stu-id="d2958-149">Example: **indexes=1,8** removes items at indexes 1 and 8.</span></span> <span data-ttu-id="d2958-150">インデックスは一意である必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2958-150">Indexes must be unique.</span></span> <span data-ttu-id="d2958-151">インデックスが指定されていない場合は、全体の一覧がクリアされます。</span><span class="sxs-lookup"><span data-stu-id="d2958-151">If no indexes are provided, the entire list will be cleared.</span></span>
  
<a id="ID4ETC"></a>

 
## <a name="authorization"></a><span data-ttu-id="d2958-152">Authorization</span><span class="sxs-lookup"><span data-stu-id="d2958-152">Authorization</span></span>
 
<span data-ttu-id="d2958-153">この呼び出しで、XSTS SAML トークンが必要ですが、**承認**ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="d2958-153">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="d2958-154">Xuid 要求は、呼び出し元を識別するために SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2958-154">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="d2958-155">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="d2958-155">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="d2958-156">リスト自体も Xuid によって識別され、一覧については、URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="d2958-156">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="d2958-157">これを使用して今後リストへのアクセスの共有のサポートがする機能ではありません、この時点で。</span><span class="sxs-lookup"><span data-stu-id="d2958-157">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="d2958-158">現時点では、ユーザーがアクセスするすべてのリストになりますが自分と共有アクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="d2958-158">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="d2958-159">したがって URI に Xuid は、SAML 要求トークンで Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2958-159">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="d2958-160">現時点では、XBL Auth 2.0 と 3.0 のトークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="d2958-160">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4EAD"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="d2958-161">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="d2958-161">Required Request Headers</span></span>
 
| <span data-ttu-id="d2958-162">Header</span><span class="sxs-lookup"><span data-stu-id="d2958-162">Header</span></span>| <span data-ttu-id="d2958-163">説明</span><span class="sxs-lookup"><span data-stu-id="d2958-163">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d2958-164">Authorization</span><span class="sxs-lookup"><span data-stu-id="d2958-164">Authorization</span></span>| <span data-ttu-id="d2958-165">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d2958-165">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="d2958-166">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="d2958-166">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="d2958-167">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="d2958-167">X-XBL-Contract-Version</span></span>| <span data-ttu-id="d2958-168">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="d2958-168">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="d2958-169">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="d2958-169">Pins supports version 2.</span></span> <span data-ttu-id="d2958-170">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="d2958-170">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="d2958-171">Content-Type</span><span class="sxs-lookup"><span data-stu-id="d2958-171">Content-Type</span></span>| <span data-ttu-id="d2958-172">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="d2958-172">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="d2958-173">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="d2958-173">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="d2958-174">If-Match</span><span class="sxs-lookup"><span data-stu-id="d2958-174">If-Match</span></span>| <span data-ttu-id="d2958-175">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2958-175">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="d2958-176">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="d2958-176">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="d2958-177">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="d2958-177">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="d2958-178">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="d2958-178">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EWE"></a>

 
## <a name="request-body"></a><span data-ttu-id="d2958-179">要求本文</span><span class="sxs-lookup"><span data-stu-id="d2958-179">Request body</span></span>
 
<span data-ttu-id="d2958-180">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="d2958-180">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EBF"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="d2958-181">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="d2958-181">HTTP status codes</span></span>
 
<span data-ttu-id="d2958-182">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="d2958-182">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="d2958-183">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="d2958-183">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="d2958-184">コード</span><span class="sxs-lookup"><span data-stu-id="d2958-184">Code</span></span>| <span data-ttu-id="d2958-185">理由語句</span><span class="sxs-lookup"><span data-stu-id="d2958-185">Reason phrase</span></span>| <span data-ttu-id="d2958-186">説明</span><span class="sxs-lookup"><span data-stu-id="d2958-186">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="d2958-187">200</span><span class="sxs-lookup"><span data-stu-id="d2958-187">200</span></span>| <span data-ttu-id="d2958-188">OK</span><span class="sxs-lookup"><span data-stu-id="d2958-188">OK</span></span>| <span data-ttu-id="d2958-189">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="d2958-189">The request completed successfully.</span></span> <span data-ttu-id="d2958-190">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="d2958-190">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="d2958-191">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="d2958-191">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="d2958-192">201</span><span class="sxs-lookup"><span data-stu-id="d2958-192">201</span></span>| <span data-ttu-id="d2958-193">作成日</span><span class="sxs-lookup"><span data-stu-id="d2958-193">Created</span></span>| <span data-ttu-id="d2958-194">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="d2958-194">A new list has been created.</span></span> <span data-ttu-id="d2958-195">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="d2958-195">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="d2958-196">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="d2958-196">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="d2958-197">304</span><span class="sxs-lookup"><span data-stu-id="d2958-197">304</span></span>| <span data-ttu-id="d2958-198">変更されていません</span><span class="sxs-lookup"><span data-stu-id="d2958-198">Not Modified</span></span>| <span data-ttu-id="d2958-199">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="d2958-199">Returned on GETs.</span></span> <span data-ttu-id="d2958-200">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="d2958-200">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="d2958-201">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="d2958-201">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="d2958-202">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="d2958-202">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="d2958-203">400</span><span class="sxs-lookup"><span data-stu-id="d2958-203">400</span></span>| <span data-ttu-id="d2958-204">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="d2958-204">Bad Request</span></span>| <span data-ttu-id="d2958-205">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="d2958-205">The request was malformed.</span></span> <span data-ttu-id="d2958-206">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="d2958-206">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="d2958-207">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="d2958-207">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="d2958-208">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="d2958-208">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="d2958-209">401</span><span class="sxs-lookup"><span data-stu-id="d2958-209">401</span></span>| <span data-ttu-id="d2958-210">権限がありません</span><span class="sxs-lookup"><span data-stu-id="d2958-210">Unauthorized</span></span>| <span data-ttu-id="d2958-211">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="d2958-211">The request requires user authentication.</span></span>| 
| <span data-ttu-id="d2958-212">403</span><span class="sxs-lookup"><span data-stu-id="d2958-212">403</span></span>| <span data-ttu-id="d2958-213">Forbidden</span><span class="sxs-lookup"><span data-stu-id="d2958-213">Forbidden</span></span>| <span data-ttu-id="d2958-214">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="d2958-214">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="d2958-215">404</span><span class="sxs-lookup"><span data-stu-id="d2958-215">404</span></span>| <span data-ttu-id="d2958-216">検出不可</span><span class="sxs-lookup"><span data-stu-id="d2958-216">Not Found</span></span>| <span data-ttu-id="d2958-217">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="d2958-217">The caller does not have access to the resource.</span></span> <span data-ttu-id="d2958-218">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="d2958-218">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="d2958-219">412</span><span class="sxs-lookup"><span data-stu-id="d2958-219">412</span></span>| <span data-ttu-id="d2958-220">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="d2958-220">Precondition Failed</span></span>| <span data-ttu-id="d2958-221">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="d2958-221">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="d2958-222">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="d2958-222">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="d2958-223">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="d2958-223">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="d2958-224">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="d2958-224">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="d2958-225">500</span><span class="sxs-lookup"><span data-stu-id="d2958-225">500</span></span>| <span data-ttu-id="d2958-226">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="d2958-226">Internal Server Error</span></span>| <span data-ttu-id="d2958-227">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="d2958-227">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="d2958-228">501</span><span class="sxs-lookup"><span data-stu-id="d2958-228">501</span></span>| <span data-ttu-id="d2958-229">実装されていません</span><span class="sxs-lookup"><span data-stu-id="d2958-229">Not Implemented</span></span>| <span data-ttu-id="d2958-230">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="d2958-230">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="d2958-231">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="d2958-231">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="d2958-232">503</span><span class="sxs-lookup"><span data-stu-id="d2958-232">503</span></span>| <span data-ttu-id="d2958-233">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="d2958-233">Service Unavailable</span></span>| <span data-ttu-id="d2958-234">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="d2958-234">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="d2958-235">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="d2958-235">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4E6BAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="d2958-236">応答本文</span><span class="sxs-lookup"><span data-stu-id="d2958-236">Response body</span></span>
 
<a id="ID4EFCAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="d2958-237">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="d2958-237">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="d2958-238">関連項目</span><span class="sxs-lookup"><span data-stu-id="d2958-238">See also</span></span>
 
<a id="ID4ERCAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d2958-239">Parent</span><span class="sxs-lookup"><span data-stu-id="d2958-239">Parent</span></span> 

[<span data-ttu-id="d2958-240">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="d2958-240">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

   