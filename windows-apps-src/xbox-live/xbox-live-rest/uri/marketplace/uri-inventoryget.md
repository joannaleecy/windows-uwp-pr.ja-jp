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
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4020725"
---
# <a name="get-usersmeinventory"></a><span data-ttu-id="55fc9-104">GET (/users/me/inventory)</span><span class="sxs-lookup"><span data-stu-id="55fc9-104">GET (/users/me/inventory)</span></span>
<span data-ttu-id="55fc9-105">呼び出し元に提供されているユーザーに関連付けられているインベントリのセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="55fc9-105">Provides the set of inventory currently associated with the provided user back to the caller.</span></span>
<span data-ttu-id="55fc9-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="55fc9-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="55fc9-107">注釈</span><span class="sxs-lookup"><span data-stu-id="55fc9-107">Remarks</span></span>](#ID4EV)
  * [<span data-ttu-id="55fc9-108">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="55fc9-108">Query string parameters</span></span>](#ID4EHB)
  * [<span data-ttu-id="55fc9-109">要求の例</span><span class="sxs-lookup"><span data-stu-id="55fc9-109">Sample request</span></span>](#ID4EDE)
  * [<span data-ttu-id="55fc9-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="55fc9-110">Response body</span></span>](#ID4ERE)

<a id="ID4EV"></a>


## <a name="remarks"></a><span data-ttu-id="55fc9-111">注釈</span><span class="sxs-lookup"><span data-stu-id="55fc9-111">Remarks</span></span>

<span data-ttu-id="55fc9-112">ポリシー チェックなし、実施、またはフィルタ リングがこの呼び出しの一部として行われます。</span><span class="sxs-lookup"><span data-stu-id="55fc9-112">No policy checks, enforcement, or filtering will occur as a part of this call.</span></span> <span data-ttu-id="55fc9-113">呼び出し元では、返される結果の範囲を絞り込むためにクエリ パラメーターを渡すことのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="55fc9-113">Callers have the option of passing query parameters in order to narrow the scope of the results returned.</span></span>

<span data-ttu-id="55fc9-114">前の応答を通じて提供されるため、呼び出し元が継続トークンを使用して結果をページことができます: **/users/me/inventory?continuationToken = continuationTokenString**します。</span><span class="sxs-lookup"><span data-stu-id="55fc9-114">Callers can page through results with a continuation token as provided through a previous response: **/users/me/inventory?continuationToken=continuationTokenString**.</span></span>

<span data-ttu-id="55fc9-115">呼び出し元では、特定の項目に関する情報を参照するために特定の項目の URL を使用して API の詳細への呼び出しをことがあります。</span><span class="sxs-lookup"><span data-stu-id="55fc9-115">The caller may make a call to the details API with a specific item URL in order to see information about a specific item.</span></span>

<a id="ID4EHB"></a>


## <a name="query-string-parameters"></a><span data-ttu-id="55fc9-116">クエリ文字列パラメーター</span><span class="sxs-lookup"><span data-stu-id="55fc9-116">Query string parameters</span></span>

| <span data-ttu-id="55fc9-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="55fc9-117">Parameter</span></span>| <span data-ttu-id="55fc9-118">型</span><span class="sxs-lookup"><span data-stu-id="55fc9-118">Type</span></span>| <span data-ttu-id="55fc9-119">説明</span><span class="sxs-lookup"><span data-stu-id="55fc9-119">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="55fc9-120">使用可能状況</span><span class="sxs-lookup"><span data-stu-id="55fc9-120">availability</span></span>| <span data-ttu-id="55fc9-121">string</span><span class="sxs-lookup"><span data-stu-id="55fc9-121">string</span></span>| <span data-ttu-id="55fc9-122">現在利用可能な項目を返します。</span><span class="sxs-lookup"><span data-stu-id="55fc9-122">The current availability of items to return.</span></span> <span data-ttu-id="55fc9-123">既定では「使用可能」の日付範囲の開始日と終了の該当する現在の日付を返す項目です。</span><span class="sxs-lookup"><span data-stu-id="55fc9-123">Default is "Available" which returns items for which the current date falls between the start date and the end date range.</span></span> <span data-ttu-id="55fc9-124">その他の値には"All"、すべての項目、および「利用不可」の項目を返します。 現在の日付の外側開始日と終了日の範囲したがって現在できないことを返すが含まれます。</span><span class="sxs-lookup"><span data-stu-id="55fc9-124">Other values include "All", which returns all items, and "Unavailable" which returns items for which the current date falls outside the start date and end date range and it therefore not currently available.</span></span> |
| <span data-ttu-id="55fc9-125">コンテナー</span><span class="sxs-lookup"><span data-stu-id="55fc9-125">container</span></span>| <span data-ttu-id="55fc9-126">string</span><span class="sxs-lookup"><span data-stu-id="55fc9-126">string</span></span>| <span data-ttu-id="55fc9-127">省略可能。</span><span class="sxs-lookup"><span data-stu-id="55fc9-127">Optional.</span></span> <span data-ttu-id="55fc9-128">場合は、ゲームの製品 ID を [値を設定すると、インベントリからの結果には、そのゲームに関連する項目にはのみが含まれます。</span><span class="sxs-lookup"><span data-stu-id="55fc9-128">If you set the value to the Product ID of a game, then the results from the inventory only include items related to that game.</span></span> <span data-ttu-id="55fc9-129">これは、特定のゲームの製品に結果をフィルター処理するようにサーバーから、インベントリを呼び出すときに特に便利です。</span><span class="sxs-lookup"><span data-stu-id="55fc9-129">This is especially useful when calling the inventory from your server to filter results down to a specific game's products.</span></span>|
| <span data-ttu-id="55fc9-130">expandSatisfyingEntitlements</span><span class="sxs-lookup"><span data-stu-id="55fc9-130">expandSatisfyingEntitlements</span></span>| <span data-ttu-id="55fc9-131">string</span><span class="sxs-lookup"><span data-stu-id="55fc9-131">string</span></span>| <span data-ttu-id="55fc9-132">応答に、ユーザーが、結果内で返されるすべてのニーズを満たして権利が含まれているかどうかを示すフラグ。</span><span class="sxs-lookup"><span data-stu-id="55fc9-132">A flag that indicates if the response includes all satisfying entitlements that the user has within the results returned.</span></span> <span data-ttu-id="55fc9-133">既定値は"false"です。</span><span class="sxs-lookup"><span data-stu-id="55fc9-133">The default is "false".</span></span> <span data-ttu-id="55fc9-134">このパラメーターは、値"true"、Xbox 360 の購入に移行するサブスクリプション特典では、Xbox One、次のようにバンドルの権利の項目を満たすことによってユーザーに付与されているすべての製品を使用する場合などは、結果に追加されます。</span><span class="sxs-lookup"><span data-stu-id="55fc9-134">When this parameter is used with a value of "true", any products that are granted to the user through satisfying entitlements such as bundled items, Xbox 360 purchases migrated to Xbox One, subscription benefits, etc. are added to the results.</span></span> <span data-ttu-id="55fc9-135">この値は"false"とバンドルの ProductID などの親項目のみが結果と含まれている個々 の項目いないで返されます。</span><span class="sxs-lookup"><span data-stu-id="55fc9-135">When this value is "false" then only the parent items such as the Bundle's ProductID are returned in the results and not the individual included items.</span></span> <span data-ttu-id="55fc9-136">**注:** URI に itemType パラメーターが含まれていない場合のみサポートは、値"true"をこのパラメーターを使用して、それ以外の場合、HTTP 400 エラーが表示されます。</span><span class="sxs-lookup"><span data-stu-id="55fc9-136">**Note:** Using this parameter with a value of “true” is only supported if the itemType parameter is not included in the URI, otherwise you will receive an HTTP 400 error.</span></span> |  
  | <span data-ttu-id="55fc9-137">productIds</span><span class="sxs-lookup"><span data-stu-id="55fc9-137">productIds</span></span> | <span data-ttu-id="55fc9-138">string</span><span class="sxs-lookup"><span data-stu-id="55fc9-138">string</span></span> |  <span data-ttu-id="55fc9-139">具体的には、ユーザーの在庫から取得する ProductIds のコレクション コンマで区切って '、' です。</span><span class="sxs-lookup"><span data-stu-id="55fc9-139">A collection of ProductIds that you want to specifically retrieve from the user's inventory, separated by ','.</span></span>  <span data-ttu-id="55fc9-140">ユーザーが指定した ProductID、インベントリの結果で、その項目は表示されません結果に API の呼び出しから。</span><span class="sxs-lookup"><span data-stu-id="55fc9-140">If the user does not have a supplied ProductID in their inventory results, that item will not appear in the results from the API call.</span></span> <span data-ttu-id="55fc9-141">ExpandSatisfyingEntitlements パラメーター セットと共にバンドルの productID で渡すを true に設定すると、バンドルに含まれているすべての項目が呼び出しの結果で返されます (かは、クエリ文字列で、productIds を指定) かどうか。</span><span class="sxs-lookup"><span data-stu-id="55fc9-141">If you pass in the productID of a bundle along with the expandSatisfyingEntitlements parameter set to true, all items included in the bundle are returned in the call results (whether you specified their productIds in your query string or not).</span></span>   |
  | <span data-ttu-id="55fc9-142">状態</span><span class="sxs-lookup"><span data-stu-id="55fc9-142">state</span></span> | <span data-ttu-id="55fc9-143">string</span><span class="sxs-lookup"><span data-stu-id="55fc9-143">string</span></span> | <span data-ttu-id="55fc9-144">返される項目の状態。</span><span class="sxs-lookup"><span data-stu-id="55fc9-144">The state of the items to return.</span></span> <span data-ttu-id="55fc9-145">既定ではすべての項目を取得する"all"します。</span><span class="sxs-lookup"><span data-stu-id="55fc9-145">The default is "all", which returns all items.</span></span> <span data-ttu-id="55fc9-146">その他の値は「有効」、だけその itemsthat が有効になっていることを示しますが、返すべき「一時停止」が中断されている項目のみを返すこと、"Expired"は、期限切れになった項目のみが返されることを示すを示す""を取り消した場合、することを示しますが取り消された項目のみを返す必要が、"Renewed"を示す更新されている項目のみを返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="55fc9-146">Other values are "Enabled", which indicates that only itemsthat are enabled should be returned, "Suspended", which indicates that only items that are suspended should be returned, "Expired", which indicates that only items which have expired should be returned, "Cancelled", which indicates that only items that are cancelled should be returned, and "Renewed", which indicates that only items that have been renewed should be returned.</span></span>  |

<span data-ttu-id="55fc9-147">これらは、に加えては、リソースは、標準のページングのしくみをサポートします。</span><span class="sxs-lookup"><span data-stu-id="55fc9-147">In addition to these, the resource supports the standard paging mechanics.</span></span>

<a id="ID4EDE"></a>


## <a name="sample-request"></a><span data-ttu-id="55fc9-148">要求の例</span><span class="sxs-lookup"><span data-stu-id="55fc9-148">Sample request</span></span>

<span data-ttu-id="55fc9-149">このメソッドで URI の完全修飾ドメイン名が</span><span class="sxs-lookup"><span data-stu-id="55fc9-149">The fully-qualified domain name for this URI method is</span></span> `https://inventory.xboxlive.com/users/me/inventory.
         `

> [!NOTE] 
> <span data-ttu-id="55fc9-150">ユーザーと見なされるによって異なります、提供されたトークンが複数のユーザーを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="55fc9-150">Which users are considered depends on the token provided, which may include multiple users.</span></span> <span data-ttu-id="55fc9-151">1 人のユーザーのインベントリを設定する場合は、排他的を検討する特定のユーザーのユーザー ハッシュを提供することもする必要があります。</span><span class="sxs-lookup"><span data-stu-id="55fc9-151">If you want a single user's inventory, you must also provide the user hash for the specific user you want to exclusively consider.</span></span>

<span data-ttu-id="55fc9-152">.</span><span class="sxs-lookup"><span data-stu-id="55fc9-152">.</span></span>

<a id="ID4ERE"></a>


## <a name="response-body"></a><span data-ttu-id="55fc9-153">応答本文</span><span class="sxs-lookup"><span data-stu-id="55fc9-153">Response body</span></span>

<span data-ttu-id="55fc9-154">呼び出しが成功した場合は、サービスがインベントリ項目の配列を返します。</span><span class="sxs-lookup"><span data-stu-id="55fc9-154">If the call is successful, the service returns an array of inventory items.</span></span> <span data-ttu-id="55fc9-155">[InventoryItem (JSON)](../../json/json-inventoryitem.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="55fc9-155">See [inventoryItem (JSON)](../../json/json-inventoryitem.md).</span></span>

<a id="ID4E4E"></a>


### <a name="sample-response"></a><span data-ttu-id="55fc9-156">応答の例</span><span class="sxs-lookup"><span data-stu-id="55fc9-156">Sample response</span></span>


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


## <a name="see-also"></a><span data-ttu-id="55fc9-157">関連項目</span><span class="sxs-lookup"><span data-stu-id="55fc9-157">See also</span></span>

<a id="ID4EJF"></a>


##### <a name="parent"></a><span data-ttu-id="55fc9-158">Parent</span><span class="sxs-lookup"><span data-stu-id="55fc9-158">Parent</span></span>

[<span data-ttu-id="55fc9-159">/users/me/inventory</span><span class="sxs-lookup"><span data-stu-id="55fc9-159">/users/me/inventory</span></span>](uri-inventory.md)


<a id="ID4ETF"></a>


##### <a name="further-information"></a><span data-ttu-id="55fc9-160">詳細情報</span><span class="sxs-lookup"><span data-stu-id="55fc9-160">Further Information</span></span>

[<span data-ttu-id="55fc9-161">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="55fc9-161">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="55fc9-162">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="55fc9-162">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="55fc9-163">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="55fc9-163">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="55fc9-164">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="55fc9-164">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="55fc9-165">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="55fc9-165">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
