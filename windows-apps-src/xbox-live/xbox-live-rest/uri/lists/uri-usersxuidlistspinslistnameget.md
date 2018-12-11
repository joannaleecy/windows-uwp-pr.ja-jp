---
title: GET (/users/xuid(xuid)/lists/PINS/{listname})
assetID: a63f595a-61dd-5885-c405-9833230abb94
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameget.html
description: " GET (/users/xuid(xuid)/lists/PINS/{listname})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d9f522ccd2edde8952b729fead486401f5e66ca3
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8881527"
---
# <a name="get-usersxuidxuidlistspinslistname"></a><span data-ttu-id="44ae6-104">GET (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="44ae6-104">GET (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="44ae6-105">リストの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-105">Returns the contents of a list.</span></span> <span data-ttu-id="44ae6-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="44ae6-107">注釈</span><span class="sxs-lookup"><span data-stu-id="44ae6-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="44ae6-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="44ae6-108">URI parameters</span></span>](#ID4EIB)
  * [<span data-ttu-id="44ae6-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="44ae6-109">Query string parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="44ae6-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="44ae6-110">Authorization</span></span>](#ID4ESD)
  * [<span data-ttu-id="44ae6-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="44ae6-111">Required Request Headers</span></span>](#ID4E6D)
  * [<span data-ttu-id="44ae6-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="44ae6-112">Request body</span></span>](#ID4EVF)
  * [<span data-ttu-id="44ae6-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="44ae6-113">HTTP status codes</span></span>](#ID4EAG)
  * [<span data-ttu-id="44ae6-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="44ae6-114">Response body</span></span>](#ID4E5CAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="44ae6-115">注釈</span><span class="sxs-lookup"><span data-stu-id="44ae6-115">Remarks</span></span>
 
<span data-ttu-id="44ae6-116">返されるデータの**行数**フィールドには項目の数はサービスによって--ようを管理する合計リストでは、リストの最後であり、これは、可能性のある特定の項目の数が retu から別の数字を判断するために使用できます。要求によって rned します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-116">The **listCount** field in the data returned indicates how many items are in the total list maintained by the service -- as such, it can be used to determine where the end of the list is, and this is potentially a different number from how many specific items were returned by the request.</span></span>
 
<span data-ttu-id="44ae6-117">一覧が存在しない場合結果にリスト項目はありません、**数える**0 になり、 **listVersion**は 0 になります。</span><span class="sxs-lookup"><span data-stu-id="44ae6-117">If the list does not yet exist, then the results will contain no list items, the **listCount** will be zero and the **listVersion** will be zero.</span></span>
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="44ae6-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="44ae6-118">URI parameters</span></span>
 
| <span data-ttu-id="44ae6-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="44ae6-119">Parameter</span></span>| <span data-ttu-id="44ae6-120">型</span><span class="sxs-lookup"><span data-stu-id="44ae6-120">Type</span></span>| <span data-ttu-id="44ae6-121">説明</span><span class="sxs-lookup"><span data-stu-id="44ae6-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="44ae6-122">xuid</span><span class="sxs-lookup"><span data-stu-id="44ae6-122">xuid</span></span>| <span data-ttu-id="44ae6-123">string</span><span class="sxs-lookup"><span data-stu-id="44ae6-123">string</span></span>| <span data-ttu-id="44ae6-124">Xbox ユーザー ID (XUID) です。</span><span class="sxs-lookup"><span data-stu-id="44ae6-124">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="44ae6-125">listtype</span><span class="sxs-lookup"><span data-stu-id="44ae6-125">listtype</span></span>| <span data-ttu-id="44ae6-126">string</span><span class="sxs-lookup"><span data-stu-id="44ae6-126">string</span></span>| <span data-ttu-id="44ae6-127">(その使用方法と動作) の一覧の種類です。</span><span class="sxs-lookup"><span data-stu-id="44ae6-127">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="44ae6-128">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-128">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="44ae6-129">リスト</span><span class="sxs-lookup"><span data-stu-id="44ae6-129">listname</span></span>| <span data-ttu-id="44ae6-130">string</span><span class="sxs-lookup"><span data-stu-id="44ae6-130">string</span></span>| <span data-ttu-id="44ae6-131">リストの名前 (際に指定された listtype の一覧がどの)。</span><span class="sxs-lookup"><span data-stu-id="44ae6-131">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="44ae6-132">常に"XBLPins"の項目のピン留めします。</span><span class="sxs-lookup"><span data-stu-id="44ae6-132">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="44ae6-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="44ae6-133">Query string parameters</span></span>
 
| <span data-ttu-id="44ae6-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="44ae6-134">Parameter</span></span>| <span data-ttu-id="44ae6-135">型</span><span class="sxs-lookup"><span data-stu-id="44ae6-135">Type</span></span>| <span data-ttu-id="44ae6-136">説明</span><span class="sxs-lookup"><span data-stu-id="44ae6-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="44ae6-137">skipItems</span><span class="sxs-lookup"><span data-stu-id="44ae6-137">skipItems</span></span>| <span data-ttu-id="44ae6-138">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="44ae6-138">32-bit signed integer</span></span>| <span data-ttu-id="44ae6-139">省略可能。</span><span class="sxs-lookup"><span data-stu-id="44ae6-139">Optional.</span></span> <span data-ttu-id="44ae6-140">結果を返す前に列挙型でスキップされる項目の数です。</span><span class="sxs-lookup"><span data-stu-id="44ae6-140">Number of items to skip in the enumeration before returning results.</span></span> <span data-ttu-id="44ae6-141">既定値: 0 です。</span><span class="sxs-lookup"><span data-stu-id="44ae6-141">Default value: 0.</span></span>| 
| <span data-ttu-id="44ae6-142">maxItems</span><span class="sxs-lookup"><span data-stu-id="44ae6-142">maxItems</span></span>| <span data-ttu-id="44ae6-143">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="44ae6-143">32-bit signed integer</span></span>| <span data-ttu-id="44ae6-144">省略可能。</span><span class="sxs-lookup"><span data-stu-id="44ae6-144">Optional.</span></span> <span data-ttu-id="44ae6-145">返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="44ae6-145">Maximum number of items to return.</span></span> <span data-ttu-id="44ae6-146">要求で最大値が指定されていない場合、既定値は 25 項目はします。</span><span class="sxs-lookup"><span data-stu-id="44ae6-146">The default is 25 items if no maximum is specified in the request.</span></span> <span data-ttu-id="44ae6-147">サービスがこの値に最大を配置しません。値がリスト内の項目の数よりも大きい場合は、エラーなしですべての項目が返されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-147">The service does not place a maximum on this value; if the value is greater than the number of items in the list, then all items will be returned with no error.</span></span>| 
| <span data-ttu-id="44ae6-148">filterItemId</span><span class="sxs-lookup"><span data-stu-id="44ae6-148">filterItemId</span></span>| <span data-ttu-id="44ae6-149">string</span><span class="sxs-lookup"><span data-stu-id="44ae6-149">string</span></span>| <span data-ttu-id="44ae6-150">省略可能。</span><span class="sxs-lookup"><span data-stu-id="44ae6-150">Optional.</span></span> <span data-ttu-id="44ae6-151">一覧で検索する項目を指定します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-151">Specifies the item to find in the list.</span></span> <span data-ttu-id="44ae6-152">リストの項目のすべてのインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-152">Returns all instances of the item in the list.</span></span> <span data-ttu-id="44ae6-153">により、クライアントはリストの項目には、そのをすばやく確認します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-153">Allows the client to quickly determine if and where an item is in a list.</span></span> <span data-ttu-id="44ae6-154">大規模なリスト全体のリストを反復処理することがなく、項目のすべてのインスタンスを判断するのに便利です。</span><span class="sxs-lookup"><span data-stu-id="44ae6-154">Handy for large lists to determine all instances of an item without iterating through the entire list.</span></span> <span data-ttu-id="44ae6-155">既定値: null。</span><span class="sxs-lookup"><span data-stu-id="44ae6-155">Default value: null.</span></span>| 
| <span data-ttu-id="44ae6-156">filterContentType</span><span class="sxs-lookup"><span data-stu-id="44ae6-156">filterContentType</span></span>| <span data-ttu-id="44ae6-157">string</span><span class="sxs-lookup"><span data-stu-id="44ae6-157">string</span></span>| <span data-ttu-id="44ae6-158">省略可能。</span><span class="sxs-lookup"><span data-stu-id="44ae6-158">Optional.</span></span> <span data-ttu-id="44ae6-159">返されるコンテンツの種類のコンマ区切りの一覧を指定します (戻りませんの種類の一覧ではなく)。</span><span class="sxs-lookup"><span data-stu-id="44ae6-159">Specifies a comma-separated list of content types to return (will not return types not in the list).</span></span> <span data-ttu-id="44ae6-160">のみがリストから特定のコンテンツの種類を取得するために使用します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-160">Used to only get certain content types from a list.</span></span> <span data-ttu-id="44ae6-161">コンテンツの種類のコンマ区切りの一覧は、このフィルターに使用されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-161">A comma-separated list of content types is used for this filter.</span></span> <span data-ttu-id="44ae6-162">(複数のコンテンツの種類を 1 つの呼び出しで照会できます)。サポートされているコンテンツの種類には、エンターテインメント探索サービス (EDS) で定義されているすべてのメディアの種類が含まれます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-162">(Multiple content types can be queried in one call.) Content types supported include all the media types defined by Entertainment Discovery Services (EDS).</span></span> <span data-ttu-id="44ae6-163">既定値: null (すべてのコンテンツの種類)。</span><span class="sxs-lookup"><span data-stu-id="44ae6-163">Default value: null (all content types).</span></span>| 
| <span data-ttu-id="44ae6-164">filterDeviceType</span><span class="sxs-lookup"><span data-stu-id="44ae6-164">filterDeviceType</span></span>| <span data-ttu-id="44ae6-165">string</span><span class="sxs-lookup"><span data-stu-id="44ae6-165">string</span></span>| <span data-ttu-id="44ae6-166">省略可能。</span><span class="sxs-lookup"><span data-stu-id="44ae6-166">Optional.</span></span> <span data-ttu-id="44ae6-167">返されるデバイスの種類のコンマ区切りの一覧を指定します (戻りませんの種類の一覧ではなく)。</span><span class="sxs-lookup"><span data-stu-id="44ae6-167">Specifies a comma-separated list of device types to return (will not return types not in the list).</span></span> <span data-ttu-id="44ae6-168">戻り値のセットを特定のデバイスの種類のセットから挿入されている項目を返すだけをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-168">Filters the return set to only return items which have been inserted from a specific set of device types.</span></span> <span data-ttu-id="44ae6-169">デバイスの種類のコンマ区切りの一覧は、このフィルター (1 つの呼び出しで複数のデバイスの種類を問い合わせることができます) に使用されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-169">A comma-separated list of device types is used for this filter (multiple device types can be queried in one call).</span></span> <span data-ttu-id="44ae6-170">使用可能な値: XboxOne、MCapensis、WindowsPhone、WindowsPhone7、Web、PC、MoLive します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-170">Possible values: XboxOne, MCapensis, WindowsPhone, WindowsPhone7, Web, PC, MoLive.</span></span> <span data-ttu-id="44ae6-171">既定値: null (すべてのコンテンツの種類)。</span><span class="sxs-lookup"><span data-stu-id="44ae6-171">Default value: null (all content types).</span></span>| 
  
<a id="ID4ESD"></a>

 
## <a name="authorization"></a><span data-ttu-id="44ae6-172">Authorization</span><span class="sxs-lookup"><span data-stu-id="44ae6-172">Authorization</span></span>
 
<span data-ttu-id="44ae6-173">この呼び出しは、**承認**ヘッダーで、XSTS SAML トークンを想定しています。</span><span class="sxs-lookup"><span data-stu-id="44ae6-173">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="44ae6-174">Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="44ae6-174">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="44ae6-175">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-175">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="44ae6-176">リスト自体では、同様の Xuid を識別し、リストの URI が含められます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-176">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="44ae6-177">これを使用して、します、今後、一覧へのアクセスの共有のサポートがいる機能ではありませんこの時点でします。</span><span class="sxs-lookup"><span data-stu-id="44ae6-177">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="44ae6-178">現時点では、すべてのリストをユーザーにアクセスすることが、独自と共有へのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="44ae6-178">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="44ae6-179">したがって、URI の Xuid は SAML クレーム トークンの Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="44ae6-179">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="44ae6-180">現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="44ae6-180">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4E6D"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="44ae6-181">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="44ae6-181">Required Request Headers</span></span>
 
| <span data-ttu-id="44ae6-182">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="44ae6-182">Header</span></span>| <span data-ttu-id="44ae6-183">説明</span><span class="sxs-lookup"><span data-stu-id="44ae6-183">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="44ae6-184">Authorization</span><span class="sxs-lookup"><span data-stu-id="44ae6-184">Authorization</span></span>| <span data-ttu-id="44ae6-185">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="44ae6-185">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="44ae6-186">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="44ae6-186">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="44ae6-187">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="44ae6-187">X-XBL-Contract-Version</span></span>| <span data-ttu-id="44ae6-188">要求された (正の整数) をされている API のバージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-188">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="44ae6-189">バージョン 2 のサポートのピン留めします。</span><span class="sxs-lookup"><span data-stu-id="44ae6-189">Pins supports version 2.</span></span> <span data-ttu-id="44ae6-190">このヘッダーが存在しないか、サービスには、400-が返されます後、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="44ae6-190">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="44ae6-191">Content-Type</span><span class="sxs-lookup"><span data-stu-id="44ae6-191">Content-Type</span></span>| <span data-ttu-id="44ae6-192">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-192">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="44ae6-193">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="44ae6-193">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="44ae6-194">If-Match</span><span class="sxs-lookup"><span data-stu-id="44ae6-194">If-Match</span></span>| <span data-ttu-id="44ae6-195">このヘッダーは、変更要求を行ったときに、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="44ae6-195">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="44ae6-196">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-196">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="44ae6-197">"If-match"ヘッダー内のバージョンが、一覧の現在のバージョンが一致しない場合は、HTTP 412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="44ae6-197">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="44ae6-198">(省略可能)また場合に使用できますの取得、現在の一覧のバージョン一覧データがないし、HTTP 304 存在し、渡されたバージョンに一致する – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-198">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EVF"></a>

 
## <a name="request-body"></a><span data-ttu-id="44ae6-199">要求本文</span><span class="sxs-lookup"><span data-stu-id="44ae6-199">Request body</span></span>
 
<span data-ttu-id="44ae6-200">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="44ae6-200">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EAG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="44ae6-201">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="44ae6-201">HTTP status codes</span></span>
 
<span data-ttu-id="44ae6-202">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、ステータス コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-202">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="44ae6-203">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="44ae6-203">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="44ae6-204">コード</span><span class="sxs-lookup"><span data-stu-id="44ae6-204">Code</span></span>| <span data-ttu-id="44ae6-205">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="44ae6-205">Reason phrase</span></span>| <span data-ttu-id="44ae6-206">説明</span><span class="sxs-lookup"><span data-stu-id="44ae6-206">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="44ae6-207">200</span><span class="sxs-lookup"><span data-stu-id="44ae6-207">200</span></span>| <span data-ttu-id="44ae6-208">OK</span><span class="sxs-lookup"><span data-stu-id="44ae6-208">OK</span></span>| <span data-ttu-id="44ae6-209">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="44ae6-209">The request completed successfully.</span></span> <span data-ttu-id="44ae6-210">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="44ae6-210">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="44ae6-211">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-211">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="44ae6-212">201</span><span class="sxs-lookup"><span data-stu-id="44ae6-212">201</span></span>| <span data-ttu-id="44ae6-213">Created</span><span class="sxs-lookup"><span data-stu-id="44ae6-213">Created</span></span>| <span data-ttu-id="44ae6-214">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="44ae6-214">A new list has been created.</span></span> <span data-ttu-id="44ae6-215">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-215">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="44ae6-216">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="44ae6-216">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="44ae6-217">304</span><span class="sxs-lookup"><span data-stu-id="44ae6-217">304</span></span>| <span data-ttu-id="44ae6-218">Not Modified</span><span class="sxs-lookup"><span data-stu-id="44ae6-218">Not Modified</span></span>| <span data-ttu-id="44ae6-219">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-219">Returned on GETs.</span></span> <span data-ttu-id="44ae6-220">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-220">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="44ae6-221">サービスでは、一覧のバージョンを<b>If-match</b>ヘッダーで値を比較します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-221">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="44ae6-222">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-222">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="44ae6-223">400</span><span class="sxs-lookup"><span data-stu-id="44ae6-223">400</span></span>| <span data-ttu-id="44ae6-224">Bad Request</span><span class="sxs-lookup"><span data-stu-id="44ae6-224">Bad Request</span></span>| <span data-ttu-id="44ae6-225">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="44ae6-225">The request was malformed.</span></span> <span data-ttu-id="44ae6-226">無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-226">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="44ae6-227">不足している必要なパラメーターの結果であることもまたはデータの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-227">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="44ae6-228"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="44ae6-228">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="44ae6-229">401</span><span class="sxs-lookup"><span data-stu-id="44ae6-229">401</span></span>| <span data-ttu-id="44ae6-230">権限がありません</span><span class="sxs-lookup"><span data-stu-id="44ae6-230">Unauthorized</span></span>| <span data-ttu-id="44ae6-231">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="44ae6-231">The request requires user authentication.</span></span>| 
| <span data-ttu-id="44ae6-232">403</span><span class="sxs-lookup"><span data-stu-id="44ae6-232">403</span></span>| <span data-ttu-id="44ae6-233">Forbidden</span><span class="sxs-lookup"><span data-stu-id="44ae6-233">Forbidden</span></span>| <span data-ttu-id="44ae6-234">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="44ae6-234">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="44ae6-235">404</span><span class="sxs-lookup"><span data-stu-id="44ae6-235">404</span></span>| <span data-ttu-id="44ae6-236">Not Found します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-236">Not Found</span></span>| <span data-ttu-id="44ae6-237">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="44ae6-237">The caller does not have access to the resource.</span></span> <span data-ttu-id="44ae6-238">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-238">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="44ae6-239">412</span><span class="sxs-lookup"><span data-stu-id="44ae6-239">412</span></span>| <span data-ttu-id="44ae6-240">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="44ae6-240">Precondition Failed</span></span>| <span data-ttu-id="44ae6-241">一覧のバージョンが変更された変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-241">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="44ae6-242">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-242">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="44ae6-243">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-243">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="44ae6-244">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-244">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="44ae6-245">500</span><span class="sxs-lookup"><span data-stu-id="44ae6-245">500</span></span>| <span data-ttu-id="44ae6-246">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="44ae6-246">Internal Server Error</span></span>| <span data-ttu-id="44ae6-247">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="44ae6-247">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="44ae6-248">501</span><span class="sxs-lookup"><span data-stu-id="44ae6-248">501</span></span>| <span data-ttu-id="44ae6-249">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="44ae6-249">Not Implemented</span></span>| <span data-ttu-id="44ae6-250">呼び出し元では、サーバーで実装されていない URI を要求します。</span><span class="sxs-lookup"><span data-stu-id="44ae6-250">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="44ae6-251">(現在のみを使用するとき、要求の対象となるがホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="44ae6-251">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="44ae6-252">503</span><span class="sxs-lookup"><span data-stu-id="44ae6-252">503</span></span>| <span data-ttu-id="44ae6-253">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="44ae6-253">Service Unavailable</span></span>| <span data-ttu-id="44ae6-254">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="44ae6-254">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="44ae6-255">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="44ae6-255">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4E5CAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="44ae6-256">応答本文</span><span class="sxs-lookup"><span data-stu-id="44ae6-256">Response body</span></span>
 
<a id="ID4EEDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="44ae6-257">応答の例</span><span class="sxs-lookup"><span data-stu-id="44ae6-257">Sample response</span></span>
 

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
     "ImageUrl": "http://www.bing.com/thumb/get?bid=Gw%2fsjCGSS4kAAQ584x800&bn=SANGAM&fbid=7wIR63+Clmj+0A&fbn=CC",
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

 
## <a name="see-also"></a><span data-ttu-id="44ae6-258">関連項目</span><span class="sxs-lookup"><span data-stu-id="44ae6-258">See also</span></span>
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="44ae6-259">Parent</span><span class="sxs-lookup"><span data-stu-id="44ae6-259">Parent</span></span> 

[<span data-ttu-id="44ae6-260">/users/xuid(xuid)/lists/PINS/{listname}</span><span class="sxs-lookup"><span data-stu-id="44ae6-260">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

  
<a id="ID4E1DAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="44ae6-261">詳細情報</span><span class="sxs-lookup"><span data-stu-id="44ae6-261">Further Information</span></span> 

[<span data-ttu-id="44ae6-262">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="44ae6-262">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="44ae6-263">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="44ae6-263">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   