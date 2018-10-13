---
title: GET (/users/me/inventory)
assetID: 7b74dd08-2854-319d-3ed0-ddee75d922b9
permalink: en-us/docs/xboxlive/rest/uri-inventoryget.html
author: KevinAsgari
description: " GET (/users/me/inventory)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 270f36d354ee4561d12f78644436ad51e286768c
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4571265"
---
# <a name="get-usersmeinventory"></a><span data-ttu-id="b0ea1-104">GET (/users/me/inventory)</span><span class="sxs-lookup"><span data-stu-id="b0ea1-104">GET (/users/me/inventory)</span></span>
<span data-ttu-id="b0ea1-105">呼び出し元に指定されたユーザーに関連付けられているインベントリのセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-105">Provides the set of inventory currently associated with the provided user back to the caller.</span></span>
<span data-ttu-id="b0ea1-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="b0ea1-107">注釈</span><span class="sxs-lookup"><span data-stu-id="b0ea1-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="b0ea1-108">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="b0ea1-108">Query string parameters</span></span>](#ID4EHB)
  * [<span data-ttu-id="b0ea1-109">要求の例</span><span class="sxs-lookup"><span data-stu-id="b0ea1-109">Sample request</span></span>](#ID4EDE)
  * [<span data-ttu-id="b0ea1-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="b0ea1-110">Response body</span></span>](#ID4ERE)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="b0ea1-111">注釈</span><span class="sxs-lookup"><span data-stu-id="b0ea1-111">Remarks</span></span>

<span data-ttu-id="b0ea1-112">ポリシー チェックなし、実施、またはフィルタ リングがこの呼び出しの一部として行われます。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-112">No policy checks, enforcement, or filtering will occur as a part of this call.</span></span> <span data-ttu-id="b0ea1-113">呼び出し元では、返される結果の範囲を限定するためにクエリ パラメーターを渡すことのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-113">Callers have the option of passing query parameters in order to narrow the scope of the results returned.</span></span>

<span data-ttu-id="b0ea1-114">前の応答を通じて提供されるため、呼び出し元が継続トークンを使用して結果をページことができます: **/users/me/inventory?continuationToken = continuationTokenString**します。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-114">Callers can page through results with a continuation token as provided through a previous response: **/users/me/inventory?continuationToken=continuationTokenString**.</span></span>

<span data-ttu-id="b0ea1-115">呼び出し元では、特定の項目に関する情報を参照するために特定の項目の URL を使用して API の詳細への呼び出しをことがあります。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-115">The caller may make a call to the details API with a specific item URL in order to see information about a specific item.</span></span>

<a id="ID4EHB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="b0ea1-116">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="b0ea1-116">Query string parameters</span></span>

| <span data-ttu-id="b0ea1-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="b0ea1-117">Parameter</span></span>| <span data-ttu-id="b0ea1-118">型</span><span class="sxs-lookup"><span data-stu-id="b0ea1-118">Type</span></span>| <span data-ttu-id="b0ea1-119">説明</span><span class="sxs-lookup"><span data-stu-id="b0ea1-119">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="b0ea1-120">使用可能状況</span><span class="sxs-lookup"><span data-stu-id="b0ea1-120">availability</span></span>| <span data-ttu-id="b0ea1-121">string</span><span class="sxs-lookup"><span data-stu-id="b0ea1-121">string</span></span>| <span data-ttu-id="b0ea1-122">現在利用可能な項目を返します。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-122">The current availability of items to return.</span></span> <span data-ttu-id="b0ea1-123">既定値は、「使用可能」の日付範囲の開始日と終了の間で該当する現在の日付を返す項目です。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-123">Default is "Available" which returns items for which the current date falls between the start date and the end date range.</span></span> <span data-ttu-id="b0ea1-124">その他の値には"All"、すべての項目、および「利用不可」の項目を返します。 現在の日付の外側開始日と終了日の範囲と、したがって現在は利用できませんを返すが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-124">Other values include "All", which returns all items, and "Unavailable" which returns items for which the current date falls outside the start date and end date range and it therefore not currently available.</span></span> |
| <span data-ttu-id="b0ea1-125">コンテナー</span><span class="sxs-lookup"><span data-stu-id="b0ea1-125">container</span></span>| <span data-ttu-id="b0ea1-126">string</span><span class="sxs-lookup"><span data-stu-id="b0ea1-126">string</span></span>| <span data-ttu-id="b0ea1-127">省略可能。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-127">Optional.</span></span> <span data-ttu-id="b0ea1-128">場合は、ゲームの製品 ID を [値を設定すると、インベントリからの結果には、そのゲームに関連する項目にはのみが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-128">If you set the value to the Product ID of a game, then the results from the inventory only include items related to that game.</span></span> <span data-ttu-id="b0ea1-129">これは、特定のゲームの製品に結果をフィルター処理するようにサーバーから、インベントリを呼び出すときに特に便利です。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-129">This is especially useful when calling the inventory from your server to filter results down to a specific game's products.</span></span>|
| <span data-ttu-id="b0ea1-130">expandSatisfyingEntitlements</span><span class="sxs-lookup"><span data-stu-id="b0ea1-130">expandSatisfyingEntitlements</span></span>| <span data-ttu-id="b0ea1-131">string</span><span class="sxs-lookup"><span data-stu-id="b0ea1-131">string</span></span>| <span data-ttu-id="b0ea1-132">応答に、ユーザーが、結果内で返されるすべてのニーズを満たして権利が含まれているかどうかを示すフラグ。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-132">A flag that indicates if the response includes all satisfying entitlements that the user has within the results returned.</span></span> <span data-ttu-id="b0ea1-133">既定では"false です"。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-133">The default is "false".</span></span> <span data-ttu-id="b0ea1-134">このパラメーターは、値"true"、Xbox 360 の購入がサブスクリプション特典では、Xbox One に移行、次のようにバンドルの権利の項目を満たすことによってユーザーに付与されているすべての製品を使用する場合などは、結果に追加されます。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-134">When this parameter is used with a value of "true", any products that are granted to the user through satisfying entitlements such as bundled items, Xbox 360 purchases migrated to Xbox One, subscription benefits, etc. are added to the results.</span></span> <span data-ttu-id="b0ea1-135">この値は"false"とき、バンドルの ProductID などの親項目のみは、結果と含まれている個々 の項目いないで返されます。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-135">When this value is "false" then only the parent items such as the Bundle's ProductID are returned in the results and not the individual included items.</span></span> <span data-ttu-id="b0ea1-136">**注:** URI に itemType パラメーターが含まれていない場合にのみサポートは、値"true"をこのパラメーターを使用して、それ以外の場合、HTTP 400 エラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-136">**Note:** Using this parameter with a value of “true” is only supported if the itemType parameter is not included in the URI, otherwise you will receive an HTTP 400 error.</span></span> |  
  | <span data-ttu-id="b0ea1-137">productIds</span><span class="sxs-lookup"><span data-stu-id="b0ea1-137">productIds</span></span> | <span data-ttu-id="b0ea1-138">string</span><span class="sxs-lookup"><span data-stu-id="b0ea1-138">string</span></span> |  <span data-ttu-id="b0ea1-139">具体的には、ユーザーの在庫から取得する ProductIds のコレクションがで区切られた '、' です。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-139">A collection of ProductIds that you want to specifically retrieve from the user's inventory, separated by ','.</span></span>  <span data-ttu-id="b0ea1-140">ユーザーが指定した ProductID、インベントリの結果で、その項目は表示されません結果に API の呼び出しから。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-140">If the user does not have a supplied ProductID in their inventory results, that item will not appear in the results from the API call.</span></span> <span data-ttu-id="b0ea1-141">渡すと、バンドルと共に expandSatisfyingEntitlements パラメーター セットの productID を true に、バンドルに含まれているすべての項目が呼び出しの結果に返されます (かは、クエリ文字列で、productIds を指定) かどうか。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-141">If you pass in the productID of a bundle along with the expandSatisfyingEntitlements parameter set to true, all items included in the bundle are returned in the call results (whether you specified their productIds in your query string or not).</span></span>   |
  | <span data-ttu-id="b0ea1-142">状態</span><span class="sxs-lookup"><span data-stu-id="b0ea1-142">state</span></span> | <span data-ttu-id="b0ea1-143">string</span><span class="sxs-lookup"><span data-stu-id="b0ea1-143">string</span></span> | <span data-ttu-id="b0ea1-144">返される項目の状態。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-144">The state of the items to return.</span></span> <span data-ttu-id="b0ea1-145">既定ではすべての項目を取得する"all"です。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-145">The default is "all", which returns all items.</span></span> <span data-ttu-id="b0ea1-146">その他の値は「有効」、そののみ itemsthat が有効になっていることを示します、返すべき「中断」が中断されている項目のみを返すこと、期限切れになった項目のみが返されることを示す、「期限切れ」を示す""を取り消した場合、することを示しますが取り消された項目のみが返されます、"Renewed"更新されている項目のみが返されることを示します。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-146">Other values are "Enabled", which indicates that only itemsthat are enabled should be returned, "Suspended", which indicates that only items that are suspended should be returned, "Expired", which indicates that only items which have expired should be returned, "Cancelled", which indicates that only items that are cancelled should be returned, and "Renewed", which indicates that only items that have been renewed should be returned.</span></span>  |

<span data-ttu-id="b0ea1-147">これらは、だけでなくリソースには、ページングする標準的なしくみがサポートしています。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-147">In addition to these, the resource supports the standard paging mechanics.</span></span>

<a id="ID4EDE"></a>


## <a name="sample-request"></a><span data-ttu-id="b0ea1-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="b0ea1-148">Sample request</span></span>

<span data-ttu-id="b0ea1-149">このメソッドで URI の完全修飾ドメイン名が</span><span class="sxs-lookup"><span data-stu-id="b0ea1-149">The fully-qualified domain name for this URI method is</span></span> `https://inventory.xboxlive.com/users/me/inventory.
         `

> [!NOTE] 
> <span data-ttu-id="b0ea1-150">ユーザーと見なされるによって異なります、提供されたトークンが複数のユーザーが含まれます。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-150">Which users are considered depends on the token provided, which may include multiple users.</span></span> <span data-ttu-id="b0ea1-151">1 人のユーザーのインベントリを設定する場合は、排他的を検討する特定のユーザーのユーザー ハッシュを提供することもする必要があります。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-151">If you want a single user's inventory, you must also provide the user hash for the specific user you want to exclusively consider.</span></span>

<span data-ttu-id="b0ea1-152">.</span><span class="sxs-lookup"><span data-stu-id="b0ea1-152">.</span></span>

<a id="ID4ERE"></a>


## <a name="response-body"></a><span data-ttu-id="b0ea1-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="b0ea1-153">Response body</span></span>

<span data-ttu-id="b0ea1-154">呼び出しが成功した場合は、サービスがインベントリ項目の配列を返します。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-154">If the call is successful, the service returns an array of inventory items.</span></span> <span data-ttu-id="b0ea1-155">[InventoryItem (JSON)](../../json/json-inventoryitem.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="b0ea1-155">See [inventoryItem (JSON)](../../json/json-inventoryitem.md).</span></span>

<a id="ID4E4E"></a>


### <a name="sample-response"></a><span data-ttu-id="b0ea1-156">応答の例</span><span class="sxs-lookup"><span data-stu-id="b0ea1-156">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="b0ea1-157">関連項目</span><span class="sxs-lookup"><span data-stu-id="b0ea1-157">See also</span></span>

<a id="ID4EJF"></a>


##### <a name="parent"></a><span data-ttu-id="b0ea1-158">Parent</span><span class="sxs-lookup"><span data-stu-id="b0ea1-158">Parent</span></span>

[<span data-ttu-id="b0ea1-159">/users/me/inventory</span><span class="sxs-lookup"><span data-stu-id="b0ea1-159">/users/me/inventory</span></span>](uri-inventory.md)


<a id="ID4ETF"></a>


##### <a name="further-information"></a><span data-ttu-id="b0ea1-160">詳細情報</span><span class="sxs-lookup"><span data-stu-id="b0ea1-160">Further Information</span></span>

[<span data-ttu-id="b0ea1-161">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="b0ea1-161">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="b0ea1-162">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="b0ea1-162">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="b0ea1-163">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="b0ea1-163">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="b0ea1-164">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="b0ea1-164">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="b0ea1-165">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="b0ea1-165">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
