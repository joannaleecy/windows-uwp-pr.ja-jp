---
title: POST ({itemID})
assetID: 2c3c166b-e638-cfb9-d68e-9f8ab9a838d3
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurlpost.html
description: " POST ({itemID})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 877986ce9d48269295a68dbfd644f14785916b88
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640857"
---
# <a name="post-itemid"></a><span data-ttu-id="65865-104">POST ({itemID})</span><span class="sxs-lookup"><span data-stu-id="65865-104">POST ({itemID})</span></span>
<span data-ttu-id="65865-105">または使用できるインベントリ項目の一部が使用されていることを示しますおよびデクリメントの要求の量で使用できる数量。</span><span class="sxs-lookup"><span data-stu-id="65865-105">Indicates that all or a portion of a consumable inventory item has been used and decrements the quantity of the consumable by the requested amount.</span></span>
<span data-ttu-id="65865-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="65865-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="65865-107">注釈</span><span class="sxs-lookup"><span data-stu-id="65865-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="65865-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="65865-108">URI parameters</span></span>](#ID4EQB)
  * [<span data-ttu-id="65865-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="65865-109">Request body</span></span>](#ID4E2B)
  * [<span data-ttu-id="65865-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="65865-110">Response body</span></span>](#ID4ENC)

<a id="ID4EX"></a>


## <a name="remarks"></a><span data-ttu-id="65865-111">注釈</span><span class="sxs-lookup"><span data-stu-id="65865-111">Remarks</span></span>

   * <span data-ttu-id="65865-112">呼び出し元が使用するように求められる数量が、項目の残りの提供を超えている場合、呼び出しは拒否されます。</span><span class="sxs-lookup"><span data-stu-id="65865-112">If the quantity the caller asked to consume exceeds the remaining supply of the item, the call will be rejected.</span></span>
   * <span data-ttu-id="65865-113">呼び出し元が使用するように求められる数量は 0 より大きい正の整数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="65865-113">The quantity the caller asked to consume must be a positive integer above 0.</span></span> <span data-ttu-id="65865-114">消費値は 0 以下の呼び出しは拒否されます。</span><span class="sxs-lookup"><span data-stu-id="65865-114">Calls with a consumption value of 0 or lower will be rejected.</span></span>
   * <span data-ttu-id="65865-115">呼び出し元は、空のトランザクション ID を提供する場合は、要求は拒否されます。</span><span class="sxs-lookup"><span data-stu-id="65865-115">If the caller provides an empty Transaction ID, the request will be rejected.</span></span>
   * <span data-ttu-id="65865-116">使用可能な場合は、消費量を報告するタイトルを特定することができるように、タイトルの要求が記録されます。</span><span class="sxs-lookup"><span data-stu-id="65865-116">If available the title claim will be logged so that it will be possible to determine which title is reporting the consumption.</span></span>
   * <span data-ttu-id="65865-117">一定の期間には、同じ transactionId の他の投稿が無視されます。</span><span class="sxs-lookup"><span data-stu-id="65865-117">Additional POSTs with the same transactionId will be ignored for some time period.</span></span>


> [!NOTE]
> <span data-ttu-id="65865-118"><b>X xbl コントラクト バージョン ヘッダー</b>この API は、「4」にします。</span><span class="sxs-lookup"><span data-stu-id="65865-118">The <b>x-xbl-contract-version header</b> for this API is "4".</span></span>


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="65865-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="65865-119">URI parameters</span></span>

| <span data-ttu-id="65865-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="65865-120">Parameter</span></span>| <span data-ttu-id="65865-121">種類</span><span class="sxs-lookup"><span data-stu-id="65865-121">Type</span></span>| <span data-ttu-id="65865-122">説明</span><span class="sxs-lookup"><span data-stu-id="65865-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="65865-123">アイテム Id</span><span class="sxs-lookup"><span data-stu-id="65865-123">itemID</span></span>| <span data-ttu-id="65865-124">string</span><span class="sxs-lookup"><span data-stu-id="65865-124">string</span></span>| <span data-ttu-id="65865-125">単数形のインベントリ項目のユーザーごとに一意の ID</span><span class="sxs-lookup"><span data-stu-id="65865-125">the ID unique to each user for a singular inventory item</span></span>|

<a id="ID4E2B"></a>


## <a name="request-body"></a><span data-ttu-id="65865-126">要求本文</span><span class="sxs-lookup"><span data-stu-id="65865-126">Request body</span></span>

<a id="ID4EBC"></a>


### <a name="sample-request"></a><span data-ttu-id="65865-127">要求のサンプル</span><span class="sxs-lookup"><span data-stu-id="65865-127">Sample request</span></span>


```cpp
{
  "transactionId": String
  "removeQuantity": Int
}

```


<span data-ttu-id="65865-128">削除の quantity フィールドを使用できる、消耗品の残りの数量から削除するの数量を示すために、呼び出し元を使用できます。</span><span class="sxs-lookup"><span data-stu-id="65865-128">The remove quantity field allows the caller to indicate the quantity of consumable they wish to remove from the consumable's remaining quantity.</span></span> <span data-ttu-id="65865-129">トランザクション ID フィールドには、同じ使用状況を 2 回カウントのリスクを制限しながら使用できるコンテンツの操作を使用して再試行するための手段を呼び出し元が提供します。</span><span class="sxs-lookup"><span data-stu-id="65865-129">The Transaction ID field provides the caller with a means to retry using consumable content operations while limiting the risk of counting the same usage twice.</span></span>

<a id="ID4ENC"></a>


## <a name="response-body"></a><span data-ttu-id="65865-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="65865-130">Response body</span></span>

<span data-ttu-id="65865-131">認証を渡し、適切な承認コンテキストが割り当てられていると仮定した場合、POST に対する応答は、POST 要求、使用できる項目の URL、および項目は新しいサービスに渡される、acknolodgement の同じ transactionId を含む受信数量の値。</span><span class="sxs-lookup"><span data-stu-id="65865-131">The response to the POST, assuming it passes authentication and is assigned the appropriate authorization context is a an acknolodgement of receipt with the same transactionId passed to the service in the POST request, the consumable item's URL, and the item's new quantity value.</span></span>

<a id="ID4EVC"></a>


### <a name="sample-response"></a><span data-ttu-id="65865-132">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="65865-132">Sample response</span></span>


```cpp
{
  "transactionId": String
  "url": String
  "newQuantity": Int
}

```


<a id="ID4E6C"></a>


## <a name="see-also"></a><span data-ttu-id="65865-133">関連項目</span><span class="sxs-lookup"><span data-stu-id="65865-133">See also</span></span>

<a id="ID4EBD"></a>


##### <a name="parent"></a><span data-ttu-id="65865-134">Parent</span><span class="sxs-lookup"><span data-stu-id="65865-134">Parent</span></span>

[<span data-ttu-id="65865-135">/users/me/consumables/{itemID}</span><span class="sxs-lookup"><span data-stu-id="65865-135">/users/me/consumables/{itemID}</span></span>](uri-inventoryconsumablesitemurl.md)


<a id="ID4ELD"></a>


##### <a name="further-information"></a><span data-ttu-id="65865-136">詳細情報</span><span class="sxs-lookup"><span data-stu-id="65865-136">Further Information</span></span>

[<span data-ttu-id="65865-137">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="65865-137">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="65865-138">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="65865-138">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="65865-139">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="65865-139">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="65865-140">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="65865-140">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="65865-141">その他の参照</span><span class="sxs-lookup"><span data-stu-id="65865-141">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
