---
title: GET (/users/me/inventory)
assetID: 7b74dd08-2854-319d-3ed0-ddee75d922b9
permalink: en-us/docs/xboxlive/rest/uri-inventoryget.html
description: " GET (/users/me/inventory)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 31c787108fad84f06b02ded3958f9d2f99727cbe
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57632207"
---
# <a name="get-usersmeinventory"></a><span data-ttu-id="41ab6-104">GET (/users/me/inventory)</span><span class="sxs-lookup"><span data-stu-id="41ab6-104">GET (/users/me/inventory)</span></span>
<span data-ttu-id="41ab6-105">呼び出し元に指定されたユーザーに関連付けられているインベントリのセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-105">Provides the set of inventory currently associated with the provided user back to the caller.</span></span>
<span data-ttu-id="41ab6-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="41ab6-107">注釈</span><span class="sxs-lookup"><span data-stu-id="41ab6-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="41ab6-108">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="41ab6-108">Query string parameters</span></span>](#ID4EHB)
  * [<span data-ttu-id="41ab6-109">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="41ab6-109">Sample request</span></span>](#ID4EDE)
  * [<span data-ttu-id="41ab6-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="41ab6-110">Response body</span></span>](#ID4ERE)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="41ab6-111">注釈</span><span class="sxs-lookup"><span data-stu-id="41ab6-111">Remarks</span></span>

<span data-ttu-id="41ab6-112">ポリシー チェックを行わない、強制、または、この呼び出しの一部としてフィルター処理が発生します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-112">No policy checks, enforcement, or filtering will occur as a part of this call.</span></span> <span data-ttu-id="41ab6-113">呼び出し元では、返される結果の範囲を限定するためにクエリ パラメーターを渡すことがあります。</span><span class="sxs-lookup"><span data-stu-id="41ab6-113">Callers have the option of passing query parameters in order to narrow the scope of the results returned.</span></span>

<span data-ttu-id="41ab6-114">前の応答で提供される、継続トークンを使用して結果を呼び出し元がページできます: **/users/me/inventory? continuationToken = continuationTokenString**します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-114">Callers can page through results with a continuation token as provided through a previous response: **/users/me/inventory?continuationToken=continuationTokenString**.</span></span>

<span data-ttu-id="41ab6-115">呼び出し元には、特定の項目の URL を使用した API の詳細を特定の項目に関する情報を表示するにはの呼び出しを行うことがあります。</span><span class="sxs-lookup"><span data-stu-id="41ab6-115">The caller may make a call to the details API with a specific item URL in order to see information about a specific item.</span></span>

<a id="ID4EHB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="41ab6-116">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="41ab6-116">Query string parameters</span></span>

| <span data-ttu-id="41ab6-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="41ab6-117">Parameter</span></span>| <span data-ttu-id="41ab6-118">種類</span><span class="sxs-lookup"><span data-stu-id="41ab6-118">Type</span></span>| <span data-ttu-id="41ab6-119">説明</span><span class="sxs-lookup"><span data-stu-id="41ab6-119">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="41ab6-120">可用性</span><span class="sxs-lookup"><span data-stu-id="41ab6-120">availability</span></span>| <span data-ttu-id="41ab6-121">string</span><span class="sxs-lookup"><span data-stu-id="41ab6-121">string</span></span>| <span data-ttu-id="41ab6-122">返されるアイテムの現在の可用性。</span><span class="sxs-lookup"><span data-stu-id="41ab6-122">The current availability of items to return.</span></span> <span data-ttu-id="41ab6-123">既定値は、「使用可能」日付範囲にする対象の現在の日付が開始日と終了の間が項目を返します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-123">Default is "Available" which returns items for which the current date falls between the start date and the end date range.</span></span> <span data-ttu-id="41ab6-124">その他の値を含める"All"、すべての項目、および現在の日付の項目を返しますの"Unavailable"は開始日と終了の日付範囲とそのため現在使用できない外になりますが返されます。</span><span class="sxs-lookup"><span data-stu-id="41ab6-124">Other values include "All", which returns all items, and "Unavailable" which returns items for which the current date falls outside the start date and end date range and it therefore not currently available.</span></span> |
| <span data-ttu-id="41ab6-125">コンテナー</span><span class="sxs-lookup"><span data-stu-id="41ab6-125">container</span></span>| <span data-ttu-id="41ab6-126">string</span><span class="sxs-lookup"><span data-stu-id="41ab6-126">string</span></span>| <span data-ttu-id="41ab6-127">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="41ab6-127">Optional.</span></span> <span data-ttu-id="41ab6-128">場合は、インベントリからの結果には、そのゲームに関連する項目にはのみが含まれます。 その後は、ゲームの製品 ID に、値を設定します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-128">If you set the value to the Product ID of a game, then the results from the inventory only include items related to that game.</span></span> <span data-ttu-id="41ab6-129">これは、特定のゲームの製品まで結果をフィルター処理するようにサーバーからインベントリを呼び出すときに特に便利です。</span><span class="sxs-lookup"><span data-stu-id="41ab6-129">This is especially useful when calling the inventory from your server to filter results down to a specific game's products.</span></span>|
| <span data-ttu-id="41ab6-130">expandSatisfyingEntitlements</span><span class="sxs-lookup"><span data-stu-id="41ab6-130">expandSatisfyingEntitlements</span></span>| <span data-ttu-id="41ab6-131">string</span><span class="sxs-lookup"><span data-stu-id="41ab6-131">string</span></span>| <span data-ttu-id="41ab6-132">応答に、ユーザーが、結果内で返されるすべての満足できる権利が含まれますかどうかを示すフラグ。</span><span class="sxs-lookup"><span data-stu-id="41ab6-132">A flag that indicates if the response includes all satisfying entitlements that the user has within the results returned.</span></span> <span data-ttu-id="41ab6-133">既定では"false です"。</span><span class="sxs-lookup"><span data-stu-id="41ab6-133">The default is "false".</span></span> <span data-ttu-id="41ab6-134">このパラメーターに Xbox 360 での購入は、サブスクリプションの特典、Xbox One に移行権利バンドルなどの項目を満たすを介してユーザーに与えられているすべての製品である"true"の値を使用するなどが、結果に追加されます。</span><span class="sxs-lookup"><span data-stu-id="41ab6-134">When this parameter is used with a value of "true", any products that are granted to the user through satisfying entitlements such as bundled items, Xbox 360 purchases migrated to Xbox One, subscription benefits, etc. are added to the results.</span></span> <span data-ttu-id="41ab6-135">この値が"false"の場合、バンドルの ProductID など、親アイテムのみが結果と個々 含まれる項目ではなく返されます。</span><span class="sxs-lookup"><span data-stu-id="41ab6-135">When this value is "false" then only the parent items such as the Bundle's ProductID are returned in the results and not the individual included items.</span></span> <span data-ttu-id="41ab6-136">**注:** ItemType パラメーターが URI に含まれていない場合にのみサポートされて"true"の値は、このパラメーターを使用して、それ以外の場合、HTTP 400 エラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="41ab6-136">**Note:** Using this parameter with a value of “true” is only supported if the itemType parameter is not included in the URI, otherwise you will receive an HTTP 400 error.</span></span> |  
  | <span data-ttu-id="41ab6-137">Productid</span><span class="sxs-lookup"><span data-stu-id="41ab6-137">productIds</span></span> | <span data-ttu-id="41ab6-138">string</span><span class="sxs-lookup"><span data-stu-id="41ab6-138">string</span></span> |  <span data-ttu-id="41ab6-139">具体的には、ユーザーのインベントリから取得する Productid のコレクションで区切られた ','。</span><span class="sxs-lookup"><span data-stu-id="41ab6-139">A collection of ProductIds that you want to specifically retrieve from the user's inventory, separated by ','.</span></span>  <span data-ttu-id="41ab6-140">ユーザーが指定された ProductID インベントリ結果に、その項目は、結果に API 呼び出しからいない表示されます。</span><span class="sxs-lookup"><span data-stu-id="41ab6-140">If the user does not have a supplied ProductID in their inventory results, that item will not appear in the results from the API call.</span></span> <span data-ttu-id="41ab6-141">True に expandSatisfyingEntitlements のパラメータ セットと共にバンドルの productID を渡す場合 (クエリ文字列で、Productid を指定したかどうか) かどうかの呼び出しの結果に、バンドルに含まれるすべての項目が返されます。</span><span class="sxs-lookup"><span data-stu-id="41ab6-141">If you pass in the productID of a bundle along with the expandSatisfyingEntitlements parameter set to true, all items included in the bundle are returned in the call results (whether you specified their productIds in your query string or not).</span></span>   |
  | <span data-ttu-id="41ab6-142">状態</span><span class="sxs-lookup"><span data-stu-id="41ab6-142">state</span></span> | <span data-ttu-id="41ab6-143">string</span><span class="sxs-lookup"><span data-stu-id="41ab6-143">string</span></span> | <span data-ttu-id="41ab6-144">返されるアイテムの状態。</span><span class="sxs-lookup"><span data-stu-id="41ab6-144">The state of the items to return.</span></span> <span data-ttu-id="41ab6-145">既定値は、すべての項目を返す"all"です。</span><span class="sxs-lookup"><span data-stu-id="41ab6-145">The default is "all", which returns all items.</span></span> <span data-ttu-id="41ab6-146">その他の値は"Enabled"、そののみ itemsthat が有効になっていることを示しますが、返すべき「中断」中断されている項目のみが返されること、期限切れになった項目のみが返されることを示す、「期限切れ」を示す"キャンセル"ことを示します取り消される項目のみを返す必要がある"Renewed"書き換えられた項目のみが返されることを示します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-146">Other values are "Enabled", which indicates that only itemsthat are enabled should be returned, "Suspended", which indicates that only items that are suspended should be returned, "Expired", which indicates that only items which have expired should be returned, "Cancelled", which indicates that only items that are cancelled should be returned, and "Renewed", which indicates that only items that have been renewed should be returned.</span></span>  |

<span data-ttu-id="41ab6-147">これらに加えて、リソースでは、標準のページングのメカニズムをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="41ab6-147">In addition to these, the resource supports the standard paging mechanics.</span></span>

<a id="ID4EDE"></a>


## <a name="sample-request"></a><span data-ttu-id="41ab6-148">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="41ab6-148">Sample request</span></span>

<span data-ttu-id="41ab6-149">このメソッドに URI の完全修飾ドメイン名は `https://inventory.xboxlive.com/users/me/inventory.
         `</span><span class="sxs-lookup"><span data-stu-id="41ab6-149">The fully-qualified domain name for this URI method is `https://inventory.xboxlive.com/users/me/inventory.
         `</span></span>

> [!NOTE] 
> <span data-ttu-id="41ab6-150">どのユーザーがあると見なさによって異なります、提供されたトークンが複数のユーザーを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="41ab6-150">Which users are considered depends on the token provided, which may include multiple users.</span></span> <span data-ttu-id="41ab6-151">1 人のユーザーのインベントリを実行する場合は、排他的に検討する特定のユーザーのユーザーのハッシュを指定することも必要があります。</span><span class="sxs-lookup"><span data-stu-id="41ab6-151">If you want a single user's inventory, you must also provide the user hash for the specific user you want to exclusively consider.</span></span>

<span data-ttu-id="41ab6-152">.</span><span class="sxs-lookup"><span data-stu-id="41ab6-152">.</span></span>

<a id="ID4ERE"></a>


## <a name="response-body"></a><span data-ttu-id="41ab6-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="41ab6-153">Response body</span></span>

<span data-ttu-id="41ab6-154">呼び出しが成功した場合、サービスは、インベントリ項目の配列を返します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-154">If the call is successful, the service returns an array of inventory items.</span></span> <span data-ttu-id="41ab6-155">参照してください[inventoryItem (JSON)](../../json/json-inventoryitem.md)します。</span><span class="sxs-lookup"><span data-stu-id="41ab6-155">See [inventoryItem (JSON)](../../json/json-inventoryitem.md).</span></span>

<a id="ID4E4E"></a>


### <a name="sample-response"></a><span data-ttu-id="41ab6-156">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="41ab6-156">Sample response</span></span>


```cpp
{
  "pagingInfo": {
    "continuationToken": string,
    "totalItems": int
  },
  "items":
  {
    "url": string,
    "itemType": "Music",
    "titleId": string,
    "containers": string,
    "obtained": DateTime,
    "startDate": DateTime,
    "endDate": DateTime,
    "state": "Enabled"  
}

```


<a id="ID4EHF"></a>


## <a name="see-also"></a><span data-ttu-id="41ab6-157">関連項目</span><span class="sxs-lookup"><span data-stu-id="41ab6-157">See also</span></span>

<a id="ID4EJF"></a>


##### <a name="parent"></a><span data-ttu-id="41ab6-158">Parent</span><span class="sxs-lookup"><span data-stu-id="41ab6-158">Parent</span></span>

[<span data-ttu-id="41ab6-159">/users/me/inventory</span><span class="sxs-lookup"><span data-stu-id="41ab6-159">/users/me/inventory</span></span>](uri-inventory.md)


<a id="ID4ETF"></a>


##### <a name="further-information"></a><span data-ttu-id="41ab6-160">詳細情報</span><span class="sxs-lookup"><span data-stu-id="41ab6-160">Further Information</span></span>

[<span data-ttu-id="41ab6-161">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="41ab6-161">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="41ab6-162">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="41ab6-162">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="41ab6-163">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="41ab6-163">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="41ab6-164">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="41ab6-164">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="41ab6-165">その他の参照</span><span class="sxs-lookup"><span data-stu-id="41ab6-165">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
