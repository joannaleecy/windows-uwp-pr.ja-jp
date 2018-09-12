---
title: POST ({itemID})
assetID: 2c3c166b-e638-cfb9-d68e-9f8ab9a838d3
permalink: en-us/docs/xboxlive/rest/uri-inventoryconsumablesitemurlpost.html
author: KevinAsgari
description: " POST ({itemID})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 910e2e46725c8628d6984983c808bf5fc9937f9f
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882091"
---
# <a name="post-itemid"></a><span data-ttu-id="c45b5-104">POST ({itemID})</span><span class="sxs-lookup"><span data-stu-id="c45b5-104">POST ({itemID})</span></span>
<span data-ttu-id="c45b5-105">または、コンシューマブルなインベントリ項目の一部が使用されていることを示しますとデクリメント、要求された時間の長さによって、コンシューマブルの数量。</span><span class="sxs-lookup"><span data-stu-id="c45b5-105">Indicates that all or a portion of a consumable inventory item has been used and decrements the quantity of the consumable by the requested amount.</span></span>
<span data-ttu-id="c45b5-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="c45b5-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>

  * [<span data-ttu-id="c45b5-107">注釈</span><span class="sxs-lookup"><span data-stu-id="c45b5-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="c45b5-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c45b5-108">URI parameters</span></span>](#ID4EQB)
  * [<span data-ttu-id="c45b5-109">要求本文</span><span class="sxs-lookup"><span data-stu-id="c45b5-109">Request body</span></span>](#ID4E2B)
  * [<span data-ttu-id="c45b5-110">応答本文</span><span class="sxs-lookup"><span data-stu-id="c45b5-110">Response body</span></span>](#ID4ENC)

<a id="ID4EX"></a>


## <a name="remarks"></a><span data-ttu-id="c45b5-111">注釈</span><span class="sxs-lookup"><span data-stu-id="c45b5-111">Remarks</span></span>

   * <span data-ttu-id="c45b5-112">呼び出し元が利用するよう求め数量は、項目の残りの提供を超えている場合は、呼び出しは拒否されます。</span><span class="sxs-lookup"><span data-stu-id="c45b5-112">If the quantity the caller asked to consume exceeds the remaining supply of the item, the call will be rejected.</span></span>
   * <span data-ttu-id="c45b5-113">呼び出し元が利用するよう求め数量は 0 上の正の整数である必要があります。</span><span class="sxs-lookup"><span data-stu-id="c45b5-113">The quantity the caller asked to consume must be a positive integer above 0.</span></span> <span data-ttu-id="c45b5-114">消費量の値を 0 または小さい呼び出しが拒否されます。</span><span class="sxs-lookup"><span data-stu-id="c45b5-114">Calls with a consumption value of 0 or lower will be rejected.</span></span>
   * <span data-ttu-id="c45b5-115">呼び出し元では、空のトランザクション ID を提供する場合は、要求は拒否されます。</span><span class="sxs-lookup"><span data-stu-id="c45b5-115">If the caller provides an empty Transaction ID, the request will be rejected.</span></span>
   * <span data-ttu-id="c45b5-116">利用可能な場合は、どのタイトルによって報告されている使用量を判断することができるようにタイトル クレームが記録されます。</span><span class="sxs-lookup"><span data-stu-id="c45b5-116">If available the title claim will be logged so that it will be possible to determine which title is reporting the consumption.</span></span>
   * <span data-ttu-id="c45b5-117">一部の期間の同じ transactionId と共に追加の投稿は無視されます。</span><span class="sxs-lookup"><span data-stu-id="c45b5-117">Additional POSTs with the same transactionId will be ignored for some time period.</span></span>


> [!NOTE]
> <span data-ttu-id="c45b5-118">この API の<b>x xbl コントラクト バージョン ヘッダー</b>は「4」です。</span><span class="sxs-lookup"><span data-stu-id="c45b5-118">The <b>x-xbl-contract-version header</b> for this API is "4".</span></span>


<a id="ID4EQB"></a>


## <a name="uri-parameters"></a><span data-ttu-id="c45b5-119">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="c45b5-119">URI parameters</span></span>

| <span data-ttu-id="c45b5-120">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c45b5-120">Parameter</span></span>| <span data-ttu-id="c45b5-121">型</span><span class="sxs-lookup"><span data-stu-id="c45b5-121">Type</span></span>| <span data-ttu-id="c45b5-122">説明</span><span class="sxs-lookup"><span data-stu-id="c45b5-122">Description</span></span>|
| --- | --- | --- | --- |
| <span data-ttu-id="c45b5-123">itemID</span><span class="sxs-lookup"><span data-stu-id="c45b5-123">itemID</span></span>| <span data-ttu-id="c45b5-124">string</span><span class="sxs-lookup"><span data-stu-id="c45b5-124">string</span></span>| <span data-ttu-id="c45b5-125">単一のインベントリ項目の各ユーザーに一意の ID</span><span class="sxs-lookup"><span data-stu-id="c45b5-125">the ID unique to each user for a singular inventory item</span></span>|

<a id="ID4E2B"></a>


## <a name="request-body"></a><span data-ttu-id="c45b5-126">要求本文</span><span class="sxs-lookup"><span data-stu-id="c45b5-126">Request body</span></span>

<a id="ID4EBC"></a>


### <a name="sample-request"></a><span data-ttu-id="c45b5-127">要求の例</span><span class="sxs-lookup"><span data-stu-id="c45b5-127">Sample request</span></span>


```cpp
{
  "transactionId": String
  "removeQuantity": Int
}

```


<span data-ttu-id="c45b5-128">削除の数量フィールドには、コンシューマブルの残りの数量から削除するコンシューマブルの数量を示すために、呼び出し元ことができます。</span><span class="sxs-lookup"><span data-stu-id="c45b5-128">The remove quantity field allows the caller to indicate the quantity of consumable they wish to remove from the consumable's remaining quantity.</span></span> <span data-ttu-id="c45b5-129">トランザクション ID] フィールドには、同じの使用状況を 2 回にカウントのリスクを軽減しながらコンシューマブルなコンテンツの操作を使用して再試行する手段を呼び出し元が提供します。</span><span class="sxs-lookup"><span data-stu-id="c45b5-129">The Transaction ID field provides the caller with a means to retry using consumable content operations while limiting the risk of counting the same usage twice.</span></span>

<a id="ID4ENC"></a>


## <a name="response-body"></a><span data-ttu-id="c45b5-130">応答本文</span><span class="sxs-lookup"><span data-stu-id="c45b5-130">Response body</span></span>

<span data-ttu-id="c45b5-131">認証に合格して適切な承認コンテキストが割り当てられていると想定すると、投稿への応答は、POST 要求、コンシューマブルの項目の URL、および項目は新しいでサービスに渡すことと同じ transactionId 受領通知の acknolodgement数量の値。</span><span class="sxs-lookup"><span data-stu-id="c45b5-131">The response to the POST, assuming it passes authentication and is assigned the appropriate authorization context is a an acknolodgement of receipt with the same transactionId passed to the service in the POST request, the consumable item's URL, and the item's new quantity value.</span></span>

<a id="ID4EVC"></a>


### <a name="sample-response"></a><span data-ttu-id="c45b5-132">応答の例</span><span class="sxs-lookup"><span data-stu-id="c45b5-132">Sample response</span></span>


```cpp
{
  "transactionId": String
  "url": String
  "newQuantity": Int
}

```


<a id="ID4E6C"></a>


## <a name="see-also"></a><span data-ttu-id="c45b5-133">関連項目</span><span class="sxs-lookup"><span data-stu-id="c45b5-133">See also</span></span>

<a id="ID4EBD"></a>


##### <a name="parent"></a><span data-ttu-id="c45b5-134">Parent</span><span class="sxs-lookup"><span data-stu-id="c45b5-134">Parent</span></span>

[<span data-ttu-id="c45b5-135">ユーザー/me/コンシューマブル/{itemID}</span><span class="sxs-lookup"><span data-stu-id="c45b5-135">/users/me/consumables/{itemID}</span></span>](uri-inventoryconsumablesitemurl.md)


<a id="ID4ELD"></a>


##### <a name="further-information"></a><span data-ttu-id="c45b5-136">詳細情報</span><span class="sxs-lookup"><span data-stu-id="c45b5-136">Further Information</span></span>

[<span data-ttu-id="c45b5-137">EDS 一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="c45b5-137">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="c45b5-138">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="c45b5-138">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="c45b5-139">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="c45b5-139">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="c45b5-140">Marketplace Uri</span><span class="sxs-lookup"><span data-stu-id="c45b5-140">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="c45b5-141">その他の参照</span><span class="sxs-lookup"><span data-stu-id="c45b5-141">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)
