---
title: GET (/users/xuid(xuid)/lists/PINS/{listname})
assetID: a63f595a-61dd-5885-c405-9833230abb94
permalink: en-us/docs/xboxlive/rest/uri-usersxuidlistspinslistnameget.html
author: KevinAsgari
description: " GET (/users/xuid(xuid)/lists/PINS/{listname})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 42f40428f79110e55aae7e881c25a3789899fee7
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3956083"
---
# <a name="get-usersxuidxuidlistspinslistname"></a><span data-ttu-id="436ce-104">GET (/users/xuid(xuid)/lists/PINS/{listname})</span><span class="sxs-lookup"><span data-stu-id="436ce-104">GET (/users/xuid(xuid)/lists/PINS/{listname})</span></span>
<span data-ttu-id="436ce-105">リストの内容を返します。</span><span class="sxs-lookup"><span data-stu-id="436ce-105">Returns the contents of a list.</span></span> <span data-ttu-id="436ce-106">これらの Uri のドメインが`eplists.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="436ce-106">The domain for these URIs is `eplists.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="436ce-107">注釈</span><span class="sxs-lookup"><span data-stu-id="436ce-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="436ce-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="436ce-108">URI parameters</span></span>](#ID4EIB)
  * [<span data-ttu-id="436ce-109">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="436ce-109">Query string parameters</span></span>](#ID4ETB)
  * [<span data-ttu-id="436ce-110">Authorization</span><span class="sxs-lookup"><span data-stu-id="436ce-110">Authorization</span></span>](#ID4ESD)
  * [<span data-ttu-id="436ce-111">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="436ce-111">Required Request Headers</span></span>](#ID4E6D)
  * [<span data-ttu-id="436ce-112">要求本文</span><span class="sxs-lookup"><span data-stu-id="436ce-112">Request body</span></span>](#ID4EVF)
  * [<span data-ttu-id="436ce-113">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="436ce-113">HTTP status codes</span></span>](#ID4EAG)
  * [<span data-ttu-id="436ce-114">応答本文</span><span class="sxs-lookup"><span data-stu-id="436ce-114">Response body</span></span>](#ID4E5CAC)
 
<a id="ID4EV"></a>

 
## <a name="remarks"></a><span data-ttu-id="436ce-115">注釈</span><span class="sxs-lookup"><span data-stu-id="436ce-115">Remarks</span></span>
 
<span data-ttu-id="436ce-116">返されるデータの**行数**フィールドは、項目の数はサービスによって--ようを管理する合計リストを示し、リストの最後であり、これは、可能性のある特定の項目の数が retu から別の数字を判断するために使用できます。要求によって rned します。</span><span class="sxs-lookup"><span data-stu-id="436ce-116">The **listCount** field in the data returned indicates how many items are in the total list maintained by the service -- as such, it can be used to determine where the end of the list is, and this is potentially a different number from how many specific items were returned by the request.</span></span>
 
<span data-ttu-id="436ce-117">リストが存在しない場合、結果は項目がない一覧、**数える**は 0 になり、 **listVersion**は 0 になります。</span><span class="sxs-lookup"><span data-stu-id="436ce-117">If the list does not yet exist, then the results will contain no list items, the **listCount** will be zero and the **listVersion** will be zero.</span></span>
  
<a id="ID4EIB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="436ce-118">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="436ce-118">URI parameters</span></span>
 
| <span data-ttu-id="436ce-119">パラメーター</span><span class="sxs-lookup"><span data-stu-id="436ce-119">Parameter</span></span>| <span data-ttu-id="436ce-120">型</span><span class="sxs-lookup"><span data-stu-id="436ce-120">Type</span></span>| <span data-ttu-id="436ce-121">説明</span><span class="sxs-lookup"><span data-stu-id="436ce-121">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="436ce-122">xuid</span><span class="sxs-lookup"><span data-stu-id="436ce-122">xuid</span></span>| <span data-ttu-id="436ce-123">string</span><span class="sxs-lookup"><span data-stu-id="436ce-123">string</span></span>| <span data-ttu-id="436ce-124">Xbox ユーザー ID (XUID) です。</span><span class="sxs-lookup"><span data-stu-id="436ce-124">Xbox User ID (XUID).</span></span>| 
| <span data-ttu-id="436ce-125">listtype</span><span class="sxs-lookup"><span data-stu-id="436ce-125">listtype</span></span>| <span data-ttu-id="436ce-126">string</span><span class="sxs-lookup"><span data-stu-id="436ce-126">string</span></span>| <span data-ttu-id="436ce-127">(その使用方法と動作) の一覧の種類です。</span><span class="sxs-lookup"><span data-stu-id="436ce-127">Type of the list (how it is used and how it acts).</span></span> <span data-ttu-id="436ce-128">常に「ピン」これらのメソッドに関連します。</span><span class="sxs-lookup"><span data-stu-id="436ce-128">Always "PINS" for these related methods.</span></span>| 
| <span data-ttu-id="436ce-129">リスト</span><span class="sxs-lookup"><span data-stu-id="436ce-129">listname</span></span>| <span data-ttu-id="436ce-130">string</span><span class="sxs-lookup"><span data-stu-id="436ce-130">string</span></span>| <span data-ttu-id="436ce-131">リストの名前 (際に指定された listtype の一覧がどの)。</span><span class="sxs-lookup"><span data-stu-id="436ce-131">Name of the list (which list of a given listtype to act on).</span></span> <span data-ttu-id="436ce-132">常に"XBLPins"の項目のピン留めします。</span><span class="sxs-lookup"><span data-stu-id="436ce-132">Always "XBLPins" for items in Pins.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="query-string-parameters"></a><span data-ttu-id="436ce-133">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="436ce-133">Query string parameters</span></span>
 
| <span data-ttu-id="436ce-134">パラメーター</span><span class="sxs-lookup"><span data-stu-id="436ce-134">Parameter</span></span>| <span data-ttu-id="436ce-135">型</span><span class="sxs-lookup"><span data-stu-id="436ce-135">Type</span></span>| <span data-ttu-id="436ce-136">説明</span><span class="sxs-lookup"><span data-stu-id="436ce-136">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="436ce-137">skipItems</span><span class="sxs-lookup"><span data-stu-id="436ce-137">skipItems</span></span>| <span data-ttu-id="436ce-138">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="436ce-138">32-bit signed integer</span></span>| <span data-ttu-id="436ce-139">省略可能。</span><span class="sxs-lookup"><span data-stu-id="436ce-139">Optional.</span></span> <span data-ttu-id="436ce-140">結果を返す前に列挙型でスキップされる項目の数です。</span><span class="sxs-lookup"><span data-stu-id="436ce-140">Number of items to skip in the enumeration before returning results.</span></span> <span data-ttu-id="436ce-141">既定値: 0 です。</span><span class="sxs-lookup"><span data-stu-id="436ce-141">Default value: 0.</span></span>| 
| <span data-ttu-id="436ce-142">maxItems</span><span class="sxs-lookup"><span data-stu-id="436ce-142">maxItems</span></span>| <span data-ttu-id="436ce-143">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="436ce-143">32-bit signed integer</span></span>| <span data-ttu-id="436ce-144">省略可能。</span><span class="sxs-lookup"><span data-stu-id="436ce-144">Optional.</span></span> <span data-ttu-id="436ce-145">返される項目の最大数。</span><span class="sxs-lookup"><span data-stu-id="436ce-145">Maximum number of items to return.</span></span> <span data-ttu-id="436ce-146">要求で最大値が指定されていない場合、既定値は 25 項目はします。</span><span class="sxs-lookup"><span data-stu-id="436ce-146">The default is 25 items if no maximum is specified in the request.</span></span> <span data-ttu-id="436ce-147">サービスがこの値は最大を配置しません。値が大きい場合、リスト内の項目の数よりも、エラーなしですべての項目が返されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-147">The service does not place a maximum on this value; if the value is greater than the number of items in the list, then all items will be returned with no error.</span></span>| 
| <span data-ttu-id="436ce-148">filterItemId</span><span class="sxs-lookup"><span data-stu-id="436ce-148">filterItemId</span></span>| <span data-ttu-id="436ce-149">string</span><span class="sxs-lookup"><span data-stu-id="436ce-149">string</span></span>| <span data-ttu-id="436ce-150">省略可能。</span><span class="sxs-lookup"><span data-stu-id="436ce-150">Optional.</span></span> <span data-ttu-id="436ce-151">一覧で検索する項目を指定します。</span><span class="sxs-lookup"><span data-stu-id="436ce-151">Specifies the item to find in the list.</span></span> <span data-ttu-id="436ce-152">リストの項目のすべてのインスタンスを返します。</span><span class="sxs-lookup"><span data-stu-id="436ce-152">Returns all instances of the item in the list.</span></span> <span data-ttu-id="436ce-153">により、クライアントはリストの項目には、そのをすばやく確認します。</span><span class="sxs-lookup"><span data-stu-id="436ce-153">Allows the client to quickly determine if and where an item is in a list.</span></span> <span data-ttu-id="436ce-154">大規模なリスト全体のリストを反復処理することがなく、項目のすべてのインスタンスを判断するのに便利です。</span><span class="sxs-lookup"><span data-stu-id="436ce-154">Handy for large lists to determine all instances of an item without iterating through the entire list.</span></span> <span data-ttu-id="436ce-155">既定値: null。</span><span class="sxs-lookup"><span data-stu-id="436ce-155">Default value: null.</span></span>| 
| <span data-ttu-id="436ce-156">filterContentType</span><span class="sxs-lookup"><span data-stu-id="436ce-156">filterContentType</span></span>| <span data-ttu-id="436ce-157">string</span><span class="sxs-lookup"><span data-stu-id="436ce-157">string</span></span>| <span data-ttu-id="436ce-158">省略可能。</span><span class="sxs-lookup"><span data-stu-id="436ce-158">Optional.</span></span> <span data-ttu-id="436ce-159">返されるコンテンツの種類のコンマ区切りの一覧を指定します (戻りませんの種類の一覧ではなく)。</span><span class="sxs-lookup"><span data-stu-id="436ce-159">Specifies a comma-separated list of content types to return (will not return types not in the list).</span></span> <span data-ttu-id="436ce-160">のみがリストから特定のコンテンツの種類を取得するために使用します。</span><span class="sxs-lookup"><span data-stu-id="436ce-160">Used to only get certain content types from a list.</span></span> <span data-ttu-id="436ce-161">コンテンツの種類のコンマ区切りの一覧は、このフィルターに使用されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-161">A comma-separated list of content types is used for this filter.</span></span> <span data-ttu-id="436ce-162">(複数のコンテンツの種類を 1 つの呼び出しで照会できます)。サポートされているコンテンツの種類には、エンターテインメント探索サービス (EDS) で定義されているすべてのメディアの種類が含まれます。</span><span class="sxs-lookup"><span data-stu-id="436ce-162">(Multiple content types can be queried in one call.) Content types supported include all the media types defined by Entertainment Discovery Services (EDS).</span></span> <span data-ttu-id="436ce-163">既定値: null (すべてのコンテンツの種類)。</span><span class="sxs-lookup"><span data-stu-id="436ce-163">Default value: null (all content types).</span></span>| 
| <span data-ttu-id="436ce-164">filterDeviceType</span><span class="sxs-lookup"><span data-stu-id="436ce-164">filterDeviceType</span></span>| <span data-ttu-id="436ce-165">string</span><span class="sxs-lookup"><span data-stu-id="436ce-165">string</span></span>| <span data-ttu-id="436ce-166">省略可能。</span><span class="sxs-lookup"><span data-stu-id="436ce-166">Optional.</span></span> <span data-ttu-id="436ce-167">返されるデバイスの種類のコンマ区切りの一覧を指定します (戻りませんの種類の一覧ではなく)。</span><span class="sxs-lookup"><span data-stu-id="436ce-167">Specifies a comma-separated list of device types to return (will not return types not in the list).</span></span> <span data-ttu-id="436ce-168">戻り値のセットを特定のデバイスの種類のセットから挿入されている項目を返すだけをフィルター処理します。</span><span class="sxs-lookup"><span data-stu-id="436ce-168">Filters the return set to only return items which have been inserted from a specific set of device types.</span></span> <span data-ttu-id="436ce-169">デバイスの種類のコンマ区切りの一覧は、このフィルター (複数のデバイスの種類は 1 つの呼び出しで照会できます) に使用されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-169">A comma-separated list of device types is used for this filter (multiple device types can be queried in one call).</span></span> <span data-ttu-id="436ce-170">設定可能な値: XboxOne、MCapensis、WindowsPhone、WindowsPhone7、Web、PC、MoLive します。</span><span class="sxs-lookup"><span data-stu-id="436ce-170">Possible values: XboxOne, MCapensis, WindowsPhone, WindowsPhone7, Web, PC, MoLive.</span></span> <span data-ttu-id="436ce-171">既定値: null (すべてのコンテンツの種類)。</span><span class="sxs-lookup"><span data-stu-id="436ce-171">Default value: null (all content types).</span></span>| 
  
<a id="ID4ESD"></a>

 
## <a name="authorization"></a><span data-ttu-id="436ce-172">Authorization</span><span class="sxs-lookup"><span data-stu-id="436ce-172">Authorization</span></span>
 
<span data-ttu-id="436ce-173">この呼び出しでは、**承認**ヘッダーで、XSTS SAML トークンが必要です。</span><span class="sxs-lookup"><span data-stu-id="436ce-173">This call expects an XSTS SAML token in the **Authorization** header.</span></span> <span data-ttu-id="436ce-174">Xuid クレームは、呼び出し元を識別するには、その SAML トークン内に存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="436ce-174">A Xuid claim must exist within that SAML token to identify the caller.</span></span> <span data-ttu-id="436ce-175">この値は、呼び出し元に問題のリストのデータへのアクセス権かどうかを使用します。</span><span class="sxs-lookup"><span data-stu-id="436ce-175">This value is used to determine if the caller has access rights to the list data in question.</span></span> <span data-ttu-id="436ce-176">リスト自体では、同様の Xuid を識別し、リストの URI に含まれます。</span><span class="sxs-lookup"><span data-stu-id="436ce-176">The list itself will be identified by the Xuid as well and will be included in the URI for the list.</span></span> <span data-ttu-id="436ce-177">これを使用して、お、今後リストに共有サポートへのアクセスがいる機能ではありませんこの時点でします。</span><span class="sxs-lookup"><span data-stu-id="436ce-177">Using this, we may in the future support shared access to lists, but that is not a feature at this time.</span></span> <span data-ttu-id="436ce-178">現時点では、ユーザーがアクセスするすべてのリストが自分、共有アクセスができなくなります。</span><span class="sxs-lookup"><span data-stu-id="436ce-178">Currently, all lists that a user accesses will be their own and there is no shared access.</span></span> <span data-ttu-id="436ce-179">したがって、URI の Xuid は SAML クレーム トークンの Xuid と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="436ce-179">Thus the Xuid in the URI must match the Xuid in the SAML claims token.</span></span> 

> [!NOTE] 
> <span data-ttu-id="436ce-180">現時点では、XBL Auth 2.0 と 3.0 トークンの両方がサポートされています。</span><span class="sxs-lookup"><span data-stu-id="436ce-180">Both XBL Auth 2.0 and 3.0 tokens are supported at present.</span></span> 


  
<a id="ID4E6D"></a>

 
## <a name="required-request-headers"></a><span data-ttu-id="436ce-181">必要な要求ヘッダー</span><span class="sxs-lookup"><span data-stu-id="436ce-181">Required Request Headers</span></span>
 
| <span data-ttu-id="436ce-182">ヘッダー</span><span class="sxs-lookup"><span data-stu-id="436ce-182">Header</span></span>| <span data-ttu-id="436ce-183">説明</span><span class="sxs-lookup"><span data-stu-id="436ce-183">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="436ce-184">Authorization</span><span class="sxs-lookup"><span data-stu-id="436ce-184">Authorization</span></span>| <span data-ttu-id="436ce-185">認証し、要求を承認する STS トークンが含まれています。</span><span class="sxs-lookup"><span data-stu-id="436ce-185">Contains the STS token used to authenticate and authorize the request.</span></span> <span data-ttu-id="436ce-186">トークンが XSTS サービスからを要求の 1 つとして、XUID を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="436ce-186">Must be a token from XSTS service and include the XUID as one of the claims.</span></span> | 
| <span data-ttu-id="436ce-187">X XBL コントラクト バージョン</span><span class="sxs-lookup"><span data-stu-id="436ce-187">X-XBL-Contract-Version</span></span>| <span data-ttu-id="436ce-188">要求された (正の整数) をされている API バージョンを指定します。</span><span class="sxs-lookup"><span data-stu-id="436ce-188">Specifies which API version is being requested (positive integers).</span></span> <span data-ttu-id="436ce-189">バージョン 2 のサポートのピン留めします。</span><span class="sxs-lookup"><span data-stu-id="436ce-189">Pins supports version 2.</span></span> <span data-ttu-id="436ce-190">このヘッダーが存在しないか、サービスは、400 – を返します、値がサポートされていない状態の説明で「サポートされていないか、不足しているコントラクト バージョン ヘッダー」を含む要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="436ce-190">If this header is missing or the value is not supported then the service will return a 400 – Bad request with "Unsupported or missing contract version header" in the status description.</span></span>| 
| <span data-ttu-id="436ce-191">Content-Type</span><span class="sxs-lookup"><span data-stu-id="436ce-191">Content-Type</span></span>| <span data-ttu-id="436ce-192">要求/応答の本文のコンテンツは json または xml であるかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="436ce-192">Specifies whether the content of request/response bodies will be in json or xml.</span></span> <span data-ttu-id="436ce-193">サポートされる値は"アプリケーション/json"と"アプリケーション/xml"</span><span class="sxs-lookup"><span data-stu-id="436ce-193">Supported values are "application/json" and "application/xml"</span></span>| 
| <span data-ttu-id="436ce-194">If-Match</span><span class="sxs-lookup"><span data-stu-id="436ce-194">If-Match</span></span>| <span data-ttu-id="436ce-195">このヘッダーは、変更要求を行うとき、リストの現在のバージョン番号を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="436ce-195">This header must contain the current version number of a list when making modify requests.</span></span> <span data-ttu-id="436ce-196">変更要求の使用 PUT、POST、または動詞を削除します。</span><span class="sxs-lookup"><span data-stu-id="436ce-196">Modify requests use PUT, POST, or DELETE verbs.</span></span> <span data-ttu-id="436ce-197">"If-match"ヘッダー内のバージョンで、一覧の現在のバージョンが一致しない場合、http/412 で、要求は拒否されます: precondition failed リターン コード。</span><span class="sxs-lookup"><span data-stu-id="436ce-197">If the version in the "If-Match" header does not match the current version of the list, the request will be rejected with an HTTP 412 – precondition failed return code.</span></span> <span data-ttu-id="436ce-198">(省略可能)また場合に使用できますの取得、現在の一覧のバージョン一覧データがないし、HTTP 304 存在し、渡されたバージョンに一致する – Not Modified コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-198">(optional) Can also be used for GETs, if present and the passed in version matches the current list version then no list data and an HTTP 304 – Not Modified code will be returned.</span></span> | 
  
<a id="ID4EVF"></a>

 
## <a name="request-body"></a><span data-ttu-id="436ce-199">要求本文</span><span class="sxs-lookup"><span data-stu-id="436ce-199">Request body</span></span>
 
<span data-ttu-id="436ce-200">この要求の本文には、オブジェクトは送信されません。</span><span class="sxs-lookup"><span data-stu-id="436ce-200">No objects are sent in the body of this request.</span></span>
  
<a id="ID4EAG"></a>

 
## <a name="http-status-codes"></a><span data-ttu-id="436ce-201">HTTP ステータス コード</span><span class="sxs-lookup"><span data-stu-id="436ce-201">HTTP status codes</span></span>
 
<span data-ttu-id="436ce-202">サービスでは、このリソースには、この方法で行った要求に対する応答としてでは、このセクションで、状態コードのいずれかを返します。</span><span class="sxs-lookup"><span data-stu-id="436ce-202">The service returns one of the status codes in this section in response to a request made with this method on this resource.</span></span> <span data-ttu-id="436ce-203">Xbox Live サービスで使用される標準の HTTP ステータス コードの一覧は、[標準の HTTP ステータス コード](../../additional/httpstatuscodes.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="436ce-203">For a complete list of standard HTTP status codes used with Xbox Live Services, see [Standard HTTP status codes](../../additional/httpstatuscodes.md).</span></span>
 
| <span data-ttu-id="436ce-204">コード</span><span class="sxs-lookup"><span data-stu-id="436ce-204">Code</span></span>| <span data-ttu-id="436ce-205">理由フレーズ</span><span class="sxs-lookup"><span data-stu-id="436ce-205">Reason phrase</span></span>| <span data-ttu-id="436ce-206">説明</span><span class="sxs-lookup"><span data-stu-id="436ce-206">Description</span></span>| 
| --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | --- | 
| <span data-ttu-id="436ce-207">200</span><span class="sxs-lookup"><span data-stu-id="436ce-207">200</span></span>| <span data-ttu-id="436ce-208">OK</span><span class="sxs-lookup"><span data-stu-id="436ce-208">OK</span></span>| <span data-ttu-id="436ce-209">要求は正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="436ce-209">The request completed successfully.</span></span> <span data-ttu-id="436ce-210">応答本文では、(GET) 用、要求されたリソースを含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="436ce-210">The response body should contain the requested resource (for a GET).</span></span> <span data-ttu-id="436ce-211">POST、PUT 要求は、最新の状態のリストのメタデータ (一覧のバージョン、数など) に表示されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-211">POST and PUT requests will receive up-to-date list metadata (list version, count, etc.).</span></span>| 
| <span data-ttu-id="436ce-212">201</span><span class="sxs-lookup"><span data-stu-id="436ce-212">201</span></span>| <span data-ttu-id="436ce-213">Created</span><span class="sxs-lookup"><span data-stu-id="436ce-213">Created</span></span>| <span data-ttu-id="436ce-214">新しい一覧が作成されました。</span><span class="sxs-lookup"><span data-stu-id="436ce-214">A new list has been created.</span></span> <span data-ttu-id="436ce-215">これは初期の挿入のリストに返されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-215">This is returned on the initial insert to a list.</span></span> <span data-ttu-id="436ce-216">応答には、最新の状態のメタデータが含まれています、場所ヘッダーには、リストの URI が含まれています。</span><span class="sxs-lookup"><span data-stu-id="436ce-216">The response includes up-to-date metadata on the list and the location header contains the URI for the list.</span></span>| 
| <span data-ttu-id="436ce-217">304</span><span class="sxs-lookup"><span data-stu-id="436ce-217">304</span></span>| <span data-ttu-id="436ce-218">Not Modified</span><span class="sxs-lookup"><span data-stu-id="436ce-218">Not Modified</span></span>| <span data-ttu-id="436ce-219">取得で返されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-219">Returned on GETs.</span></span> <span data-ttu-id="436ce-220">クライアントに一覧の最新バージョンがあることを示します。</span><span class="sxs-lookup"><span data-stu-id="436ce-220">Indicates that the client has the latest version of the list.</span></span> <span data-ttu-id="436ce-221">サービスは、一覧のバージョンを<b>If-match</b>ヘッダーの値を比較します。</span><span class="sxs-lookup"><span data-stu-id="436ce-221">The service compares the value in the <b>If-Match</b> header to the list version.</span></span> <span data-ttu-id="436ce-222">これらが等しい場合、304 取得データなしで返されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-222">If they are equal, then a 304 gets returned with no data.</span></span>| 
| <span data-ttu-id="436ce-223">400</span><span class="sxs-lookup"><span data-stu-id="436ce-223">400</span></span>| <span data-ttu-id="436ce-224">Bad Request</span><span class="sxs-lookup"><span data-stu-id="436ce-224">Bad Request</span></span>| <span data-ttu-id="436ce-225">要求が正しくありません。</span><span class="sxs-lookup"><span data-stu-id="436ce-225">The request was malformed.</span></span> <span data-ttu-id="436ce-226">無効な値、または URI またはクエリ文字列パラメーターの型として使用できます。</span><span class="sxs-lookup"><span data-stu-id="436ce-226">Could be an invalid value or type for a URI or query string parameter.</span></span> <span data-ttu-id="436ce-227">不足している必要なパラメーターの結果こともできますか、データの値、または要求に存在しないか、無効なバージョンの API が示されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-227">Can also be the result of a missing required parameter or data value, or the request indicated a missing or invalid version of the API.</span></span> <span data-ttu-id="436ce-228"><b>X XBL コントラクト バージョン</b>ヘッダーを参照してください。</span><span class="sxs-lookup"><span data-stu-id="436ce-228">See the <b>X-XBL-Contract-Version</b> header.</span></span>| 
| <span data-ttu-id="436ce-229">401</span><span class="sxs-lookup"><span data-stu-id="436ce-229">401</span></span>| <span data-ttu-id="436ce-230">権限がありません</span><span class="sxs-lookup"><span data-stu-id="436ce-230">Unauthorized</span></span>| <span data-ttu-id="436ce-231">要求には、ユーザー認証が必要です。</span><span class="sxs-lookup"><span data-stu-id="436ce-231">The request requires user authentication.</span></span>| 
| <span data-ttu-id="436ce-232">403</span><span class="sxs-lookup"><span data-stu-id="436ce-232">403</span></span>| <span data-ttu-id="436ce-233">Forbidden</span><span class="sxs-lookup"><span data-stu-id="436ce-233">Forbidden</span></span>| <span data-ttu-id="436ce-234">ユーザーまたはサービスの要求は許可されていません。</span><span class="sxs-lookup"><span data-stu-id="436ce-234">The request is not allowed for the user or service.</span></span>| 
| <span data-ttu-id="436ce-235">404</span><span class="sxs-lookup"><span data-stu-id="436ce-235">404</span></span>| <span data-ttu-id="436ce-236">見つかりません。</span><span class="sxs-lookup"><span data-stu-id="436ce-236">Not Found</span></span>| <span data-ttu-id="436ce-237">呼び出し元では、リソースへのアクセスはありません。</span><span class="sxs-lookup"><span data-stu-id="436ce-237">The caller does not have access to the resource.</span></span> <span data-ttu-id="436ce-238">これは、このような一覧が作成されていないことを示します。</span><span class="sxs-lookup"><span data-stu-id="436ce-238">This indicates that no such list has been created.</span></span>| 
| <span data-ttu-id="436ce-239">412</span><span class="sxs-lookup"><span data-stu-id="436ce-239">412</span></span>| <span data-ttu-id="436ce-240">Precondition Failed</span><span class="sxs-lookup"><span data-stu-id="436ce-240">Precondition Failed</span></span>| <span data-ttu-id="436ce-241">一覧のバージョンが変更されていて、変更要求が失敗したことを示します。</span><span class="sxs-lookup"><span data-stu-id="436ce-241">Indicates that the version of the list has changed and a modify request has failed.</span></span> <span data-ttu-id="436ce-242">変更要求は、挿入、更新、または削除します。</span><span class="sxs-lookup"><span data-stu-id="436ce-242">A modify request is an insert, update, or remove.</span></span> <span data-ttu-id="436ce-243">サービスは、一覧のバージョンの<b>If-match</b>ヘッダーを確認します。</span><span class="sxs-lookup"><span data-stu-id="436ce-243">The service checks the <b>If-Match</b> header for the list version.</span></span> <span data-ttu-id="436ce-244">一覧の現在のバージョンが一致しない場合、操作は失敗し、これは、現在のリスト メタデータ (を現在のバージョンを含む) と共に返されます。</span><span class="sxs-lookup"><span data-stu-id="436ce-244">If it does not match the current version of the list, then the operation fails and this is returned along with the current list metadata (which includes the current version).</span></span>| 
| <span data-ttu-id="436ce-245">500</span><span class="sxs-lookup"><span data-stu-id="436ce-245">500</span></span>| <span data-ttu-id="436ce-246">内部サーバー エラー</span><span class="sxs-lookup"><span data-stu-id="436ce-246">Internal Server Error</span></span>| <span data-ttu-id="436ce-247">サービスはサーバー側のエラーのための要求を拒否しています。</span><span class="sxs-lookup"><span data-stu-id="436ce-247">The service is refusing the request due to a server-side error.</span></span>| 
| <span data-ttu-id="436ce-248">501</span><span class="sxs-lookup"><span data-stu-id="436ce-248">501</span></span>| <span data-ttu-id="436ce-249">実装されていません。</span><span class="sxs-lookup"><span data-stu-id="436ce-249">Not Implemented</span></span>| <span data-ttu-id="436ce-250">呼び出し元が要求 URI では、サーバーで実装されていません。</span><span class="sxs-lookup"><span data-stu-id="436ce-250">The caller requested a URI that has not been implemented on the server.</span></span> <span data-ttu-id="436ce-251">(現在のみを使用するとき、要求の対象となるがホワイト リストの名前です。)</span><span class="sxs-lookup"><span data-stu-id="436ce-251">(Currently only used when a request is made for a list name that is not whitelisted.)</span></span>| 
| <span data-ttu-id="436ce-252">503</span><span class="sxs-lookup"><span data-stu-id="436ce-252">503</span></span>| <span data-ttu-id="436ce-253">Service Unavailable</span><span class="sxs-lookup"><span data-stu-id="436ce-253">Service Unavailable</span></span>| <span data-ttu-id="436ce-254">サーバーは、通常は負荷が高くなり、要求拒否しています。</span><span class="sxs-lookup"><span data-stu-id="436ce-254">The server is refusing the request, usually due to excessive load.</span></span> <span data-ttu-id="436ce-255">遅延の後 (表示、 <b>retry-after 後</b>ヘッダー)、要求を再試行することができます。</span><span class="sxs-lookup"><span data-stu-id="436ce-255">After a delay (see the <b>Retry-after</b> header), the request can be retried.</span></span>| 
  
<a id="ID4E5CAC"></a>

 
## <a name="response-body"></a><span data-ttu-id="436ce-256">応答本文</span><span class="sxs-lookup"><span data-stu-id="436ce-256">Response body</span></span>
 
<a id="ID4EEDAC"></a>

 
### <a name="sample-response"></a><span data-ttu-id="436ce-257">応答の例</span><span class="sxs-lookup"><span data-stu-id="436ce-257">Sample response</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="436ce-258">関連項目</span><span class="sxs-lookup"><span data-stu-id="436ce-258">See also</span></span>
 
<a id="ID4EQDAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="436ce-259">Parent</span><span class="sxs-lookup"><span data-stu-id="436ce-259">Parent</span></span> 

[<span data-ttu-id="436ce-260">ユーザー/xuid (xuid)//ピン/{リスト} の一覧を示します</span><span class="sxs-lookup"><span data-stu-id="436ce-260">/users/xuid(xuid)/lists/PINS/{listname}</span></span>](uri-usersxuidlistspinslistname.md)

  
<a id="ID4E1DAC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="436ce-261">詳細情報</span><span class="sxs-lookup"><span data-stu-id="436ce-261">Further Information</span></span> 

[<span data-ttu-id="436ce-262">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="436ce-262">Marketplace URIs</span></span>](../marketplace/atoc-reference-marketplace.md)

 [<span data-ttu-id="436ce-263">その他の参照</span><span class="sxs-lookup"><span data-stu-id="436ce-263">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   