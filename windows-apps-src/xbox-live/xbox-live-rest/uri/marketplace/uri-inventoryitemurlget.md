---
title: GET (/inventory/{itemID})
assetID: d3ca14a5-0214-ef42-091e-3f05f2a3482d
permalink: en-us/docs/xboxlive/rest/uri-inventoryitemurlget.html
author: KevinAsgari
description: " GET (/inventory/{itemID})"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4a94493243178a503ae846608b172af598bf97dd
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4127142"
---
# <a name="get-inventoryitemid"></a><span data-ttu-id="bb05a-104">GET (/inventory/{itemID})</span><span class="sxs-lookup"><span data-stu-id="bb05a-104">GET (/inventory/{itemID})</span></span>
<span data-ttu-id="bb05a-105">特定のインベントリ項目の詳細の完全なセットを提供します。</span><span class="sxs-lookup"><span data-stu-id="bb05a-105">Provides the full set of details for a specific inventory item.</span></span> <span data-ttu-id="bb05a-106">これらの Uri のドメインが`inventory.xboxlive.com`します。</span><span class="sxs-lookup"><span data-stu-id="bb05a-106">The domain for these URIs is `inventory.xboxlive.com`.</span></span>
 
  * [<span data-ttu-id="bb05a-107">注釈</span><span class="sxs-lookup"><span data-stu-id="bb05a-107">Remarks</span></span>](#ID4EX)
  * [<span data-ttu-id="bb05a-108">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bb05a-108">URI parameters</span></span>](#ID4EAB)
  * [<span data-ttu-id="bb05a-109">応答本文</span><span class="sxs-lookup"><span data-stu-id="bb05a-109">Response body</span></span>](#ID4ELB)
 
<a id="ID4EX"></a>

 
## <a name="remarks"></a><span data-ttu-id="bb05a-110">注釈</span><span class="sxs-lookup"><span data-stu-id="bb05a-110">Remarks</span></span>
 
<span data-ttu-id="bb05a-111">ポリシー チェックなし、実施、またはフィルタ リングがこの呼び出しの一部として行われます。</span><span class="sxs-lookup"><span data-stu-id="bb05a-111">No policy checks, enforcement, or filtering will occur as a part of this call.</span></span>
  
<a id="ID4EAB"></a>

 
## <a name="uri-parameters"></a><span data-ttu-id="bb05a-112">URI パラメーター</span><span class="sxs-lookup"><span data-stu-id="bb05a-112">URI parameters</span></span>
 
| <span data-ttu-id="bb05a-113">パラメーター</span><span class="sxs-lookup"><span data-stu-id="bb05a-113">Parameter</span></span>| <span data-ttu-id="bb05a-114">型</span><span class="sxs-lookup"><span data-stu-id="bb05a-114">Type</span></span>| <span data-ttu-id="bb05a-115">説明</span><span class="sxs-lookup"><span data-stu-id="bb05a-115">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bb05a-116">itemID</span><span class="sxs-lookup"><span data-stu-id="bb05a-116">itemID</span></span>| <span data-ttu-id="bb05a-117">string</span><span class="sxs-lookup"><span data-stu-id="bb05a-117">string</span></span>| <span data-ttu-id="bb05a-118">単数形インベントリ項目の各ユーザーに一意の ID</span><span class="sxs-lookup"><span data-stu-id="bb05a-118">the ID unique to each user for a singular inventory item</span></span>| 
  
<a id="ID4ELB"></a>

 
## <a name="response-body"></a><span data-ttu-id="bb05a-119">応答本文</span><span class="sxs-lookup"><span data-stu-id="bb05a-119">Response body</span></span>
 
<a id="ID4ERB"></a>

 
### <a name="sample-response"></a><span data-ttu-id="bb05a-120">応答の例</span><span class="sxs-lookup"><span data-stu-id="bb05a-120">Sample response</span></span>
 
<span data-ttu-id="bb05a-121">認証に合格して、適切な承認コンテキストが割り当てられていると仮定すると、GET 要求に応答は、項目のプロパティの完全なセットを 1 つのインベントリ項目です。</span><span class="sxs-lookup"><span data-stu-id="bb05a-121">The response to a GET request, assuming it passes authentication and is assigned the appropriate authorization context, is a single inventory item with the full set of item properties.</span></span>
 

```cpp
{inventoryItem}
         
```

   
<a id="ID4E4B"></a>

 
## <a name="see-also"></a><span data-ttu-id="bb05a-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="bb05a-122">See also</span></span>
 
<a id="ID4E6B"></a>

 
##### <a name="parent"></a><span data-ttu-id="bb05a-123">Parent</span><span class="sxs-lookup"><span data-stu-id="bb05a-123">Parent</span></span> 

[<span data-ttu-id="bb05a-124">GET (/inventory/{itemID})</span><span class="sxs-lookup"><span data-stu-id="bb05a-124">GET (/inventory/{itemID})</span></span>]()

  
<a id="ID4EJC"></a>

 
##### <a name="further-information"></a><span data-ttu-id="bb05a-125">詳細情報</span><span class="sxs-lookup"><span data-stu-id="bb05a-125">Further Information</span></span> 

[<span data-ttu-id="bb05a-126">EDS 共通ヘッダー</span><span class="sxs-lookup"><span data-stu-id="bb05a-126">EDS Common Headers</span></span>](../../additional/edscommonheaders.md)

 [<span data-ttu-id="bb05a-127">EDS パラメーター</span><span class="sxs-lookup"><span data-stu-id="bb05a-127">EDS Parameters</span></span>](../../additional/edsparameters.md)

 [<span data-ttu-id="bb05a-128">EDS クエリの絞り込み条件</span><span class="sxs-lookup"><span data-stu-id="bb05a-128">EDS Query Refiners</span></span>](../../additional/edsqueryrefiners.md)

 [<span data-ttu-id="bb05a-129">マーケットプレース URI</span><span class="sxs-lookup"><span data-stu-id="bb05a-129">Marketplace URIs</span></span>](atoc-reference-marketplace.md)

 [<span data-ttu-id="bb05a-130">その他の参照情報</span><span class="sxs-lookup"><span data-stu-id="bb05a-130">Additional Reference</span></span>](../../additional/atoc-xboxlivews-reference-additional.md)

   