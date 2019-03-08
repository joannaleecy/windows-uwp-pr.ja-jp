---
title: GET (/users/xuid(xuid)/lists/PINS/{listname})
assetID: a63f595a-61dd-5885-c405-9833230abb94
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameget.html
description: " GET (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1a31e6a6b541276d3191ba5d40767a1929c70168
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641627"
---
# <a name="get-usersxuidxuidlistspinslistname"></a><span data-ttu-id="50146-104">GET (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="50146-104">GET (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="50146-105">一覧の内容を返します。</span><span class="sxs-lookup"><span data-stu-id="50146-105">Returns the contents of a list.</span></span> <span data-ttu-id="50146-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="50146-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="50146-107">注釈</span><span class="sxs-lookup"><span data-stu-id="50146-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="50146-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="50146-108">URI parameters</span></span>](#ID4EIB)
  * [<span data-ttu-id="50146-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="50146-109">Query string parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="50146-110">承認</span><span class="sxs-lookup"><span data-stu-id="50146-110">Authorization</span></span>](#ID4ESD)
  * [<span data-ttu-id="50146-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="50146-111">Required Request Headers</span></span>](#ID4E6D)
  * [<span data-ttu-id="50146-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="50146-112">Request body</span></span>](#ID4EVF)
  * [<span data-ttu-id="50146-113">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="50146-113">HTTP status codes</span></span>](#ID4EAG)
  * [<span data-ttu-id="50146-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="50146-114">Response body</span></span>](#ID4E5CAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="50146-115">注釈</span><span class="sxs-lookup"><span data-stu-id="50146-115">Remarks</span></span>
 
<span data-ttu-id="50146-116">**ListCount**で返されるデータ フィールドは、項目の数が--よう、サービスによって保持される完全な一覧を示します、リストの末尾が、これは、可能性のある数から別の番号を判断するために使用できます特定の項目は、要求によって返されました。</span><span class="sxs-lookup"><span data-stu-id="50146-116">The **listCount** field in the data returned indicates how many items are in the total list maintained by the service -- as such, it can be used to determine where the end of the list is, and this is potentially a different number from how many specific items were returned by the request.</span></span>
 
<span data-ttu-id="50146-117">リストがまだ存在しないかどうかは、結果には、リスト アイテムはありません、 **listCount**は 0 になります、 **listVersion**は 0 になります。</span><span class="sxs-lookup"><span data-stu-id="50146-117">If the list does not yet exist, then the results will contain no list items, the **listCount** will be zero and the **listVersion** will be zero.</span></span>
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="50146-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="50146-118">URI parameters</span></span>
 
| <span data-ttu-id="50146-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="50146-119">Parameter</span></span>| <span data-ttu-id="50146-120">種類</span><span class="sxs-lookup"><span data-stu-id="50146-120">Type</span></span>| <span data-ttu-id="50146-121">説明</span><span class="sxs-lookup"><span data-stu-id="50146-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="50146-122">xuid</span><span class="sxs-lookup"><span data-stu-id="50146-122">xuid</span></span>| <span data-ttu-id="50146-123">string</span><span class="sxs-lookup"><span data-stu-id="50146-123">string</span></span>| <span data-ttu-id="50146-124">Xbox のユーザー ID (XUID)。</span><span class="sxs-lookup"><span data-stu-id="50146-124">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="50146-125">listtype</span><span class="sxs-lookup"><span data-stu-id="50146-125">listtype</span></span>| <span data-ttu-id="50146-126">string</span><span class="sxs-lookup"><span data-stu-id="50146-126">string</span></span>| <span data-ttu-id="50146-127">(その使用方法およびどのように機能します) のリストの種類。</span><span class="sxs-lookup"><span data-stu-id="50146-127">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="50146-128">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="50146-128">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="50146-129">listname</span><span class="sxs-lookup"><span data-stu-id="50146-129">listname</span></span>| <span data-ttu-id="50146-130">string</span><span class="sxs-lookup"><span data-stu-id="50146-130">string</span></span>| <span data-ttu-id="50146-131">リストの名前 (を操作する特定の listtype のどのリスト)。</span><span class="sxs-lookup"><span data-stu-id="50146-131">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="50146-132">常に"XBLPins"の項目のピンです。</span><span class="sxs-lookup"><span data-stu-id="50146-132">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="50146-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="50146-133">Query string parameters</span></span>
 
| <span data-ttu-id="50146-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="50146-134">Parameter</span></span>| <span data-ttu-id="50146-135">種類</span><span class="sxs-lookup"><span data-stu-id="50146-135">Type</span></span>| <span data-ttu-id="50146-136">説明</span><span class="sxs-lookup"><span data-stu-id="50146-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="50146-137">skipItems</span><span class="sxs-lookup"><span data-stu-id="50146-137">skipItems</span></span>| <span data-ttu-id="50146-138">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="50146-138">32-bit signed integer</span></span>| <span data-ttu-id="50146-139">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="50146-139">Optional.</span></span> <span data-ttu-id="50146-140">結果を返す前に列挙でスキップする項目の数。</span><span class="sxs-lookup"><span data-stu-id="50146-140">Number of items to skip in the enumeration before returning results.</span></span> <span data-ttu-id="50146-141">［既定値］:0。</span><span class="sxs-lookup"><span data-stu-id="50146-141">Default value: 0.</span></span>| 
| <span data-ttu-id="50146-142">maxItems</span><span class="sxs-lookup"><span data-stu-id="50146-142">maxItems</span></span>| <span data-ttu-id="50146-143">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="50146-143">32-bit signed integer</span></span>| <span data-ttu-id="50146-144">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="50146-144">Optional.</span></span> <span data-ttu-id="50146-145">返されるアイテムの最大数。</span><span class="sxs-lookup"><span data-stu-id="50146-145">Maximum number of items to return.</span></span> <span data-ttu-id="50146-146">既定では、25 件のアイテムが、要求の最大値が指定されていない場合は。</span><span class="sxs-lookup"><span data-stu-id="50146-146">The default is 25 items if no maximum is specified in the request.</span></span> <span data-ttu-id="50146-147">サービスでは、最大です。 この値に設定されません。値がリスト内の項目の数よりも大きい場合は、すべての項目がエラーなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="50146-147">The service does not place a maximum on this value; if the value is greater than the number of items in the list, then all items will be returned with no error.</span></span>| 
| <span data-ttu-id="50146-148">filterItemId</span><span class="sxs-lookup"><span data-stu-id="50146-148">filterItemId</span></span>| <span data-ttu-id="50146-149">string</span><span class="sxs-lookup"><span data-stu-id="50146-149">string</span></span>| <span data-ttu-id="50146-150">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="50146-150">Optional.</span></span> <span data-ttu-id="50146-151">一覧で検索する項目を指定します。</span><span class="sxs-lookup"><span data-stu-id="50146-151">Specifies the item to find in the list.</span></span> <span data-ttu-id="50146-152">リスト内の項目のすべてのインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="50146-152">Returns all instances of the item in the list.</span></span> <span data-ttu-id="50146-153">クライアントはリストに項目がある場合、そのをすばやく確認できます。</span><span class="sxs-lookup"><span data-stu-id="50146-153">Allows the client to quickly determine if and where an item is in a list.</span></span> <span data-ttu-id="50146-154">大きなリスト全体の一覧を反復処理することがなく、項目のすべてのインスタンスを判断するのに便利です。</span><span class="sxs-lookup"><span data-stu-id="50146-154">Handy for large lists to determine all instances of an item without iterating through the entire list.</span></span> <span data-ttu-id="50146-155">既定値: null。</span><span class="sxs-lookup"><span data-stu-id="50146-155">Default value: null.</span></span>| 
| <span data-ttu-id="50146-156">filterContentType</span><span class="sxs-lookup"><span data-stu-id="50146-156">filterContentType</span></span>| <span data-ttu-id="50146-157">string</span><span class="sxs-lookup"><span data-stu-id="50146-157">string</span></span>| <span data-ttu-id="50146-158">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="50146-158">Optional.</span></span> <span data-ttu-id="50146-159">返すコンテンツの種類のコンマ区切りのリストを指定します (は一覧にない型を返すありませんが)。</span><span class="sxs-lookup"><span data-stu-id="50146-159">Specifies a comma-separated list of content types to return (will not return types not in the list).</span></span> <span data-ttu-id="50146-160">一覧からのみ特定のコンテンツ タイプを取得するために使用します。</span><span class="sxs-lookup"><span data-stu-id="50146-160">Used to only get certain content types from a list.</span></span> <span data-ttu-id="50146-161">コンテンツの種類のコンマ区切りの一覧は、このフィルターに使用されます。</span><span class="sxs-lookup"><span data-stu-id="50146-161">A comma-separated list of content types is used for this filter.</span></span> <span data-ttu-id="50146-162">(複数のコンテンツ タイプを 1 回の呼び出しで照会できます)。サポートされているコンテンツの種類には、Entertainment 検出サービス (EDS) で定義されているすべてのメディアの種類が含まれます。</span><span class="sxs-lookup"><span data-stu-id="50146-162">(Multiple content types can be queried in one call.) Content types supported include all the media types defined by Entertainment Discovery Services (EDS).</span></span> <span data-ttu-id="50146-163">既定値: null (すべてのコンテンツ タイプ)。</span><span class="sxs-lookup"><span data-stu-id="50146-163">Default value: null (all content types).</span></span>| 
| <span data-ttu-id="50146-164">filterDeviceType</span><span class="sxs-lookup"><span data-stu-id="50146-164">filterDeviceType</span></span>| <span data-ttu-id="50146-165">string</span><span class="sxs-lookup"><span data-stu-id="50146-165">string</span></span>| <span data-ttu-id="50146-166">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="50146-166">Optional.</span></span> <span data-ttu-id="50146-167">返されるデバイスの種類のコンマ区切りのリストを指定します (は一覧にない型を返すありませんが)。</span><span class="sxs-lookup"><span data-stu-id="50146-167">Specifies a comma-separated list of device types to return (will not return types not in the list).</span></span> <span data-ttu-id="50146-168">デバイスの種類の特定のセットから挿入されている項目のみを返しますに戻り値の設定をフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="50146-168">Filters the return set to only return items which have been inserted from a specific set of device types.</span></span> <span data-ttu-id="50146-169">デバイスの種類のコンマ区切りの一覧は、(1 回の呼び出しで複数のデバイスの種類を問い合わせることができます)、このフィルターに使用されます。</span><span class="sxs-lookup"><span data-stu-id="50146-169">A comma-separated list of device types is used for this filter (multiple device types can be queried in one call).</span></span> <span data-ttu-id="50146-170">設定可能な値:XboxOne、MCapensis、WindowsPhone、WindowsPhone7、Web、PC、MoLive します。</span><span class="sxs-lookup"><span data-stu-id="50146-170">Possible values: XboxOne, MCapensis, WindowsPhone, WindowsPhone7, Web, PC, MoLive.</span></span> <span data-ttu-id="50146-171">既定値: null (すべてのコンテンツ タイプ)。</span><span class="sxs-lookup"><span data-stu-id="50146-171">Default value: null (all content types).</span></span>| 
  
<a id="ID4ESD"></a>

 
## <a name="authorization"></a><span data-ttu-id="50146-172">Authorization</span><span class="sxs-lookup"><span data-stu-id="50146-172">Authorization</span></span>
 
<span data-ttu-id="50146-173">この呼び出しで、XSTS SAML トークンが必要ですが、**承認**ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="50146-173">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="50146-174">Xuid 要求は、呼び出し元を識別するために SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="50146-174">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="50146-175">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="50146-175">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="50146-176">リスト自体も Xuid によって識別され、一覧については、URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="50146-176">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="50146-177">これを使用して今後リストへのアクセスの共有のサポートがする機能ではありません、この時点で。</span><span class="sxs-lookup"><span data-stu-id="50146-177">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="50146-178">現時点では、ユーザーがアクセスするすべてのリストになりますが自分と共有アクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="50146-178">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="50146-179">したがって URI に Xuid は、SAML 要求トークンで Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="50146-179">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="50146-180">現時点では、XBL Auth 2.0 と 3.0 のトークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="50146-180">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4E6D"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="50146-181">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="50146-181">Required Request Headers</span></span>
 
| <span data-ttu-id="50146-182">Header</span><span class="sxs-lookup"><span data-stu-id="50146-182">Header</span></span>| <span data-ttu-id="50146-183">説明</span><span class="sxs-lookup"><span data-stu-id="50146-183">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="50146-184">Authorization</span><span class="sxs-lookup"><span data-stu-id="50146-184">Authorization</span></span>| <span data-ttu-id="50146-185">認証し、承認の要求に使用した STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="50146-185">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="50146-186">必要があります、XSTS サービスからのトークンであることし、要求の 1 つとして、XUID が含まれます。</span><span class="sxs-lookup"><span data-stu-id="50146-186">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="50146-187">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="50146-187">X-XBL-Contract-Version</span></span>| <span data-ttu-id="50146-188">API バージョンが要求された (正の整数) をされているを指定します。</span><span class="sxs-lookup"><span data-stu-id="50146-188">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="50146-189">バージョン 2 をサポートする pin。</span><span class="sxs-lookup"><span data-stu-id="50146-189">Pins supports version 2.</span></span> <span data-ttu-id="50146-190">このヘッダーが見つからないか、サービスは、400 – を返します、値がサポートされていない場合は、状態の説明にある「サポートされていないか、不足しているコントラクト バージョン ヘッダー」で要求します。</span><span class="sxs-lookup"><span data-stu-id="50146-190">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="50146-191">Content-Type</span><span class="sxs-lookup"><span data-stu-id="50146-191">Content-Type</span></span>| <span data-ttu-id="50146-192">要求/応答本文の内容が json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="50146-192">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="50146-193">サポートされる値は"application/json"および"application/xml"</span><span class="sxs-lookup"><span data-stu-id="50146-193">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="50146-194">If-Match</span><span class="sxs-lookup"><span data-stu-id="50146-194">If-Match</span></span>| <span data-ttu-id="50146-195">このヘッダーは、要求の変更を行うときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="50146-195">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="50146-196">変更要求の使用 PUT、POST、または DELETE 動詞。</span><span class="sxs-lookup"><span data-stu-id="50146-196">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="50146-197">"If-match"ヘッダーにバージョンがリストの現在のバージョンが一致しない場合は、要求は、HTTP 412 で拒否されます – precondition にリターン コードが失敗しました。</span><span class="sxs-lookup"><span data-stu-id="50146-197">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="50146-198">(省略可能)場合も使用できますの取得、存在し、渡されたバージョンと一致する現在のバージョンの一覧表示し、一覧データがありません、HTTP 304-変更いないコードが返されます。</span><span class="sxs-lookup"><span data-stu-id="50146-198">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EVF"></a>

 
## <a name="request-body"></a><span data-ttu-id="50146-199">要求本文</span><span class="sxs-lookup"><span data-stu-id="50146-199">Request body</span></span>
 
<span data-ttu-id="50146-200">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="50146-200">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EAG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="50146-201">HTTP 状態コード</span><span class="sxs-lookup"><span data-stu-id="50146-201">HTTP status codes</span></span>
 
<span data-ttu-id="50146-202">サービスは、このリソースでは、このメソッドを使用した要求に応答には、このセクションではステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="50146-202">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="50146-203">Xbox Live サービスで使用される標準の HTTP ステータス コードの完全な一覧を参照してください。[標準 HTTP 状態コード](../../additional/httpstatuscodes.md)します。</span><span class="sxs-lookup"><span data-stu-id="50146-203">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="50146-204">コード</span><span class="sxs-lookup"><span data-stu-id="50146-204">Code</span></span>| <span data-ttu-id="50146-205">理由語句</span><span class="sxs-lookup"><span data-stu-id="50146-205">Reason phrase</span></span>| <span data-ttu-id="50146-206">説明</span><span class="sxs-lookup"><span data-stu-id="50146-206">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="50146-207">200</span><span class="sxs-lookup"><span data-stu-id="50146-207">200</span></span>| <span data-ttu-id="50146-208">OK</span><span class="sxs-lookup"><span data-stu-id="50146-208">OK</span></span>| <span data-ttu-id="50146-209">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="50146-209">The request completed successfully.</span></span> <span data-ttu-id="50146-210">応答本文は、(GET) の要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="50146-210">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="50146-211">POST および PUT 要求は、最新の一覧のメタデータ (バージョンの一覧表示、カウントなど) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="50146-211">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="50146-212">201</span><span class="sxs-lookup"><span data-stu-id="50146-212">201</span></span>| <span data-ttu-id="50146-213">作成日</span><span class="sxs-lookup"><span data-stu-id="50146-213">Created</span></span>| <span data-ttu-id="50146-214">新しいリストが作成されました。</span><span class="sxs-lookup"><span data-stu-id="50146-214">A new list has been created.</span></span> <span data-ttu-id="50146-215">これが初期の挿入時のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="50146-215">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="50146-216">応答には、リストに最新の状態のメタデータが含まれています。 と一覧については、URI が location ヘッダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="50146-216">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="50146-217">304</span><span class="sxs-lookup"><span data-stu-id="50146-217">304</span></span>| <span data-ttu-id="50146-218">変更されていません</span><span class="sxs-lookup"><span data-stu-id="50146-218">Not Modified</span></span>| <span data-ttu-id="50146-219">返されるを取得します。</span><span class="sxs-lookup"><span data-stu-id="50146-219">Returned on GETs.</span></span> <span data-ttu-id="50146-220">クライアントが最新バージョンの一覧を示します。</span><span class="sxs-lookup"><span data-stu-id="50146-220">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="50146-221">サービス内の値を比較し、 <b>If-match</b>バージョンの一覧表示するヘッダー。</span><span class="sxs-lookup"><span data-stu-id="50146-221">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="50146-222">等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="50146-222">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="50146-223">400</span><span class="sxs-lookup"><span data-stu-id="50146-223">400</span></span>| <span data-ttu-id="50146-224">要求が正しくありません</span><span class="sxs-lookup"><span data-stu-id="50146-224">Bad Request</span></span>| <span data-ttu-id="50146-225">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="50146-225">The request was malformed.</span></span> <span data-ttu-id="50146-226">無効な値または URI またはクエリ文字列パラメーターの型です。</span><span class="sxs-lookup"><span data-stu-id="50146-226">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="50146-227">不足している必要なパラメーターの結果であることができますもまたはデータ値、または要求に存在しないか無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="50146-227">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="50146-228">参照してください、 <b>X XBL コントラクト バージョン</b>ヘッダー。</span><span class="sxs-lookup"><span data-stu-id="50146-228">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="50146-229">401</span><span class="sxs-lookup"><span data-stu-id="50146-229">401</span></span>| <span data-ttu-id="50146-230">権限がありません</span><span class="sxs-lookup"><span data-stu-id="50146-230">Unauthorized</span></span>| <span data-ttu-id="50146-231">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="50146-231">The request requires user authentication.</span></span>| 
| <span data-ttu-id="50146-232">403</span><span class="sxs-lookup"><span data-stu-id="50146-232">403</span></span>| <span data-ttu-id="50146-233">Forbidden</span><span class="sxs-lookup"><span data-stu-id="50146-233">Forbidden</span></span>| <span data-ttu-id="50146-234">ユーザーまたはサービスは、要求することはできません。</span><span class="sxs-lookup"><span data-stu-id="50146-234">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="50146-235">404</span><span class="sxs-lookup"><span data-stu-id="50146-235">404</span></span>| <span data-ttu-id="50146-236">検出不可</span><span class="sxs-lookup"><span data-stu-id="50146-236">Not Found</span></span>| <span data-ttu-id="50146-237">呼び出し元には、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="50146-237">The caller does not have access to the resource.</span></span> <span data-ttu-id="50146-238">これは、このようなリストが作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="50146-238">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="50146-239">412</span><span class="sxs-lookup"><span data-stu-id="50146-239">412</span></span>| <span data-ttu-id="50146-240">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="50146-240">Precondition Failed</span></span>| <span data-ttu-id="50146-241">リストのバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="50146-241">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="50146-242">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="50146-242">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="50146-243">サービス チェック、 <b>If-match</b>ヘッダーのバージョンの一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="50146-243">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="50146-244">リストの現在のバージョンが一致しない場合、操作は失敗し、(を現在のバージョンを含む)、現在のリスト メタデータと共に返されます。</span><span class="sxs-lookup"><span data-stu-id="50146-244">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="50146-245">500</span><span class="sxs-lookup"><span data-stu-id="50146-245">500</span></span>| <span data-ttu-id="50146-246">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="50146-246">Internal Server Error</span></span>| <span data-ttu-id="50146-247">サービスは、サーバー側エラーのために要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="50146-247">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="50146-248">501</span><span class="sxs-lookup"><span data-stu-id="50146-248">501</span></span>| <span data-ttu-id="50146-249">実装されていません</span><span class="sxs-lookup"><span data-stu-id="50146-249">Not Implemented</span></span>| <span data-ttu-id="50146-250">呼び出し元は要求がサーバー上に実装されていない URI です。</span><span class="sxs-lookup"><span data-stu-id="50146-250">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="50146-251">(現在のみを要求するときに使用が可能ホワイト リストに登録ではないリスト名です。)</span><span class="sxs-lookup"><span data-stu-id="50146-251">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="50146-252">503</span><span class="sxs-lookup"><span data-stu-id="50146-252">503</span></span>| <span data-ttu-id="50146-253">サービス利用不可</span><span class="sxs-lookup"><span data-stu-id="50146-253">Service Unavailable</span></span>| <span data-ttu-id="50146-254">サーバーは、通常の負荷が高すぎるため、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="50146-254">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="50146-255">遅延後に (を参照してください、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="50146-255">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4E5CAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="50146-256">応答本文</span><span class="sxs-lookup"><span data-stu-id="50146-256">Response body</span></span>
 
<a id="ID4EEDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="50146-257">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="50146-257">Sample response</span></span>
 

```cpp
{ 
"ListMetadata":
  {"ListVersion": 12,
   "ListCount": 6,
   "MaxListSize": 200,
   "AccessSetting": "OwnerOnly",
   "AllowDuplicates": true
  },
"ListItems":
  [{ 
   "Index": 0,
   "DateAdded": "\/Date(1198908717056)/",
   "DateModified": "\/Date(1198908717056)/",
   "HydrationResult": "Indeterminate",
   "HydratedItem": null

   "Item":
   {
     "ContentType": "Movie",
     "ItemId": "3a5095a5-eac3-4215-944d-27bc051faa47",
     "ProviderId": null,
     "Provider": null,
     "ImageUrl": "https://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC",
     "Title": "The Dark Knight",
     "SubTitle": null,
     "Locale": "en-us",
     "AltImageUrl": null,
     "DeviceType": "XboxOne"
    }
  }]
}
         
```

   
<a id="ID4EODAC"></a>

 
## <a name="see-also"></a><span data-ttu-id="50146-258">関連項目</span><span class="sxs-lookup"><span data-stu-id="50146-258">See also</span></span>
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="50146-259">Parent</span><span class="sxs-lookup"><span data-stu-id="50146-259">Parent</span></span> 

[<span data-ttu-id="50146-260">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="50146-260">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

  
<a id="ID4E1DAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="50146-261">詳細情報</span><span class="sxs-lookup"><span data-stu-id="50146-261">Further Information</span></span> 

[<span data-ttu-id="50146-262">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="50146-262">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="50146-263">その他の参照</span><span class="sxs-lookup"><span data-stu-id="50146-263">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   