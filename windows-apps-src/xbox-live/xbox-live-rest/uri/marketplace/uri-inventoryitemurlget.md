---
title: GET (/inventory/{itemID})
assetID: d3ca14a5-0214-ef42-091e-3f05f2a3482d
permalink: en-us/docs/xboxlive/rest/uri-inventoryitemurlget.html
description: " GET (/inventory/{itemID})"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 446197eb20820304088ddac4a6379fa3b2510873
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606697"
---
# <a name="get-inventoryitemid"></a><span data-ttu-id="4000d-104">GET (/inventory/{itemID})</span><span class="sxs-lookup"><span data-stu-id="4000d-104">GET (/inventory/{itemID})</span></span>
<span data-ttu-id="4000d-105">特定のインベントリ項目の詳細情報の完全なセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="4000d-105">Provides the full set of details for a specific inventory item.</span></span> <span data-ttu-id="4000d-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="4000d-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="4000d-107">注釈</span><span class="sxs-lookup"><span data-stu-id="4000d-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="4000d-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4000d-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="4000d-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="4000d-109">Response body</span></span>](#ID4ELB)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="4000d-110">注釈</span><span class="sxs-lookup"><span data-stu-id="4000d-110">Remarks</span></span>
 
<span data-ttu-id="4000d-111">ポリシー チェックを行わない、強制、または、この呼び出しの一部としてフィルター処理が発生します。</span><span class="sxs-lookup"><span data-stu-id="4000d-111">No policy checks, enforcement, or filtering will occur as a part of this call.</span></span>
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="4000d-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="4000d-112">URI parameters</span></span>
 
| <span data-ttu-id="4000d-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="4000d-113">Parameter</span></span>| <span data-ttu-id="4000d-114">種類</span><span class="sxs-lookup"><span data-stu-id="4000d-114">Type</span></span>| <span data-ttu-id="4000d-115">説明</span><span class="sxs-lookup"><span data-stu-id="4000d-115">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="4000d-116">アイテム Id</span><span class="sxs-lookup"><span data-stu-id="4000d-116">itemID</span></span>| <span data-ttu-id="4000d-117">string</span><span class="sxs-lookup"><span data-stu-id="4000d-117">string</span></span>| <span data-ttu-id="4000d-118">単数形のインベントリ項目のユーザーごとに一意の ID</span><span class="sxs-lookup"><span data-stu-id="4000d-118">the ID unique to each user for a singular inventory item</span></span>| 
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a><span data-ttu-id="4000d-119">応答本文</span><span class="sxs-lookup"><span data-stu-id="4000d-119">Response body</span></span>
 
<a id="ID4ERB"></a>

 
### <a name="sample-response"></a><span data-ttu-id="4000d-120">応答のサンプル</span><span class="sxs-lookup"><span data-stu-id="4000d-120">Sample response</span></span>
 
<span data-ttu-id="4000d-121">認証し、適切な承認コンテキストが割り当てられていると仮定すると、GET 要求に対する応答は、アイテムのプロパティの完全なセットを 1 つの在庫アイテムです。</span><span class="sxs-lookup"><span data-stu-id="4000d-121">The response to a GET request, assuming it passes authentication and is assigned the appropriate authorization context, is a single inventory item with the full set of item properties.</span></span>
 

```cpp
{inventoryItem}
         
```

   
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="4000d-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="4000d-122">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="4000d-123">Parent</span><span class="sxs-lookup"><span data-stu-id="4000d-123">Parent</span></span> 

[<span data-ttu-id="4000d-124">GET (/inventory/{itemID})</span><span class="sxs-lookup"><span data-stu-id="4000d-124">GET (/inventory/{itemID})</span></span>](uri-inventoryget.md)

  
<a id="ID4EJC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="4000d-125">詳細情報</span><span class="sxs-lookup"><span data-stu-id="4000d-125">Further Information</span></span> 

[<span data-ttu-id="4000d-126">EDS の一般的なヘッダー</span><span class="sxs-lookup"><span data-stu-id="4000d-126">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="4000d-127">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="4000d-127">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="4000d-128">EDS は、絞り込み条件をクエリします。</span><span class="sxs-lookup"><span data-stu-id="4000d-128">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="4000d-129">Marketplace の Uri</span><span class="sxs-lookup"><span data-stu-id="4000d-129">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="4000d-130">その他の参照</span><span class="sxs-lookup"><span data-stu-id="4000d-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   