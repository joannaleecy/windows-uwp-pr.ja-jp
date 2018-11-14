---
title: POST ({itemID})
assetID: 2c3c166b-e638-cfb9-d68e-9f8ab9a838d3
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurlpost.html
author: KevinAsgari
description: " POST ({itemID})"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: da2a3fc507915f3ed20b718f5a40cca3d0ba5e0b
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6248862"
---
# <a name="post-itemid"></a><span data-ttu-id="f5725-104">POST ({itemID})</span><span class="sxs-lookup"><span data-stu-id="f5725-104">POST ({itemID})</span></span>
<span data-ttu-id="f5725-105">または、コンシューマブルなインベントリ項目の一部が使用されていることを示しますとデクリメント要求の量によって、コンシューマブルの数量。</span><span class="sxs-lookup"><span data-stu-id="f5725-105">Indicates that all or a portion of a consumable inventory item has been used and decrements the quantity of the consumable by the requested amount.</span></span>
<span data-ttu-id="f5725-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="f5725-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="f5725-107">注釈</span><span class="sxs-lookup"><span data-stu-id="f5725-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="f5725-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f5725-108">URI parameters</span></span>](#ID4EQB)
  * [<span data-ttu-id="f5725-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="f5725-109">Request body</span></span>](#ID4E2B)
  * [<span data-ttu-id="f5725-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="f5725-110">Response body</span></span>](#ID4ENC)

<a id="ID4EX"></a>


## <a name="remarks"></a><span data-ttu-id="f5725-111">注釈</span><span class="sxs-lookup"><span data-stu-id="f5725-111">Remarks</span></span>

   * <span data-ttu-id="f5725-112">呼び出し元が利用するよう求め数量は、項目の残りの電源を超えている場合、呼び出しが拒否されます。</span><span class="sxs-lookup"><span data-stu-id="f5725-112">If the quantity the caller asked to consume exceeds the remaining supply of the item, the call will be rejected.</span></span>
   * <span data-ttu-id="f5725-113">呼び出し元が利用するよう求め数量は 0 上の正の整数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="f5725-113">The quantity the caller asked to consume must be a positive integer above 0.</span></span> <span data-ttu-id="f5725-114">消費量の値を 0 または小さい呼び出しが拒否されます。</span><span class="sxs-lookup"><span data-stu-id="f5725-114">Calls with a consumption value of 0 or lower will be rejected.</span></span>
   * <span data-ttu-id="f5725-115">呼び出し元では、空のトランザクション ID を提供する場合は、要求が拒否されます。</span><span class="sxs-lookup"><span data-stu-id="f5725-115">If the caller provides an empty Transaction ID, the request will be rejected.</span></span>
   * <span data-ttu-id="f5725-116">利用可能な場合は、どのタイトルによって報告されている使用量を判断することができるように、タイトル クレームが記録されます。</span><span class="sxs-lookup"><span data-stu-id="f5725-116">If available the title claim will be logged so that it will be possible to determine which title is reporting the consumption.</span></span>
   * <span data-ttu-id="f5725-117">一部の期間は、同じ transactionId とその他の投稿が無視されます。</span><span class="sxs-lookup"><span data-stu-id="f5725-117">Additional POSTs with the same transactionId will be ignored for some time period.</span></span>


> [!NOTE]
> <span data-ttu-id="f5725-118">この API の<b>x xbl コントラクト バージョン ヘッダー</b>は「4」です。</span><span class="sxs-lookup"><span data-stu-id="f5725-118">The <b>x-xbl-contract-version header</b> for this API is "4".</span></span>


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="f5725-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="f5725-119">URI parameters</span></span>

| <span data-ttu-id="f5725-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="f5725-120">Parameter</span></span>| <span data-ttu-id="f5725-121">型</span><span class="sxs-lookup"><span data-stu-id="f5725-121">Type</span></span>| <span data-ttu-id="f5725-122">説明</span><span class="sxs-lookup"><span data-stu-id="f5725-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="f5725-123">itemID</span><span class="sxs-lookup"><span data-stu-id="f5725-123">itemID</span></span>| <span data-ttu-id="f5725-124">string</span><span class="sxs-lookup"><span data-stu-id="f5725-124">string</span></span>| <span data-ttu-id="f5725-125">単一のインベントリ項目の各ユーザーに一意の ID</span><span class="sxs-lookup"><span data-stu-id="f5725-125">the ID unique to each user for a singular inventory item</span></span>|

<a id="ID4E2B"></a>


## <a name="request-body"></a><span data-ttu-id="f5725-126">要求本文</span><span class="sxs-lookup"><span data-stu-id="f5725-126">Request body</span></span>

<a id="ID4EBC"></a>


### <a name="sample-request"></a><span data-ttu-id="f5725-127">要求の例</span><span class="sxs-lookup"><span data-stu-id="f5725-127">Sample request</span></span>


```cpp
{
  "transactionId": String
  "removeQuantity": Int
}

```


<span data-ttu-id="f5725-128">削除の数量フィールドには、コンシューマブルの残りの数量から削除するコンシューマブルの数量を示すために、呼び出し元ことができます。</span><span class="sxs-lookup"><span data-stu-id="f5725-128">The remove quantity field allows the caller to indicate the quantity of consumable they wish to remove from the consumable's remaining quantity.</span></span> <span data-ttu-id="f5725-129">トランザクション ID] フィールドには、同時使用状況を 2 回にカウントのリスクを軽減しつつ、コンシューマブルなコンテンツの操作を使用して再試行する手段を呼び出し元が提供します。</span><span class="sxs-lookup"><span data-stu-id="f5725-129">The Transaction ID field provides the caller with a means to retry using consumable content operations while limiting the risk of counting the same usage twice.</span></span>

<a id="ID4ENC"></a>


## <a name="response-body"></a><span data-ttu-id="f5725-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="f5725-130">Response body</span></span>

<span data-ttu-id="f5725-131">認証の渡し、適切な承認コンテキストが割り当てられていると仮定すると、POST への応答は、POST 要求、コンシューマブルの項目の URL、および項目は新しいでサービスに渡すことと同じ transactionId 受領通知の acknolodgement数量の値。</span><span class="sxs-lookup"><span data-stu-id="f5725-131">The response to the POST, assuming it passes authentication and is assigned the appropriate authorization context is a an acknolodgement of receipt with the same transactionId passed to the service in the POST request, the consumable item's URL, and the item's new quantity value.</span></span>

<a id="ID4EVC"></a>


### <a name="sample-response"></a><span data-ttu-id="f5725-132">応答の例</span><span class="sxs-lookup"><span data-stu-id="f5725-132">Sample response</span></span>


```cpp
{
  "transactionId": String
  "url": String
  "newQuantity": Int
}

```


<a id="ID4E6C"></a>


## <a name="see-also"></a><span data-ttu-id="f5725-133">関連項目</span><span class="sxs-lookup"><span data-stu-id="f5725-133">See also</span></span>

<a id="ID4EBD"></a>


##### <a name="parent"></a><span data-ttu-id="f5725-134">Parent</span><span class="sxs-lookup"><span data-stu-id="f5725-134">Parent</span></span>

[<span data-ttu-id="f5725-135">/users/me/consumables/{itemID}</span><span class="sxs-lookup"><span data-stu-id="f5725-135">/users/me/consumables/{itemID}</span></span>](uri-inventoryconsumablesitemurl.md)


<a id="ID4ELD"></a>


##### <a name="further-information"></a><span data-ttu-id="f5725-136">詳細情報</span><span class="sxs-lookup"><span data-stu-id="f5725-136">Further Information</span></span>

[<span data-ttu-id="f5725-137">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="f5725-137">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="f5725-138">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="f5725-138">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="f5725-139">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="f5725-139">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="f5725-140">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="f5725-140">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="f5725-141">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="f5725-141">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
