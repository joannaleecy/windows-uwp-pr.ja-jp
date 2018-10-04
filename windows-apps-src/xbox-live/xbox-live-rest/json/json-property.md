---
title: Property (JSON)
assetID: 93de547e-d936-6fcc-92cb-e4dd284dd609
permalink: en-us/docs/xboxlive/rest/json-property.html
author: KevinAsgari
description: " Property (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 033a87580680b054f5eefec7c543215e4351ace3
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4353370"
---
# <a name="property-json"></a><span data-ttu-id="90efc-104">Property (JSON)</span><span class="sxs-lookup"><span data-stu-id="90efc-104">Property (JSON)</span></span>
<span data-ttu-id="90efc-105">マッチメイ キング要求条件のクライアントによって提供されるプロパティ データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="90efc-105">Contains property data provided by the client for matchmaking request criteria.</span></span>
<a id="ID4EN"></a>


## <a name="property"></a><span data-ttu-id="90efc-106">プロパティ</span><span class="sxs-lookup"><span data-stu-id="90efc-106">Property</span></span>

<span data-ttu-id="90efc-107">プロパティ オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="90efc-107">The Property object has the following specification.</span></span>

| <span data-ttu-id="90efc-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="90efc-108">Member</span></span>| <span data-ttu-id="90efc-109">種類</span><span class="sxs-lookup"><span data-stu-id="90efc-109">Type</span></span>| <span data-ttu-id="90efc-110">説明</span><span class="sxs-lookup"><span data-stu-id="90efc-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="90efc-111">id</span><span class="sxs-lookup"><span data-stu-id="90efc-111">id</span></span>| <span data-ttu-id="90efc-112">string</span><span class="sxs-lookup"><span data-stu-id="90efc-112">string</span></span>| <span data-ttu-id="90efc-113">このプロパティの id です。</span><span class="sxs-lookup"><span data-stu-id="90efc-113">An id for this property.</span></span>|
| <span data-ttu-id="90efc-114">type</span><span class="sxs-lookup"><span data-stu-id="90efc-114">type</span></span>| <span data-ttu-id="90efc-115">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="90efc-115">32-bit signed integer</span></span> | <span data-ttu-id="90efc-116">プロパティの型です。</span><span class="sxs-lookup"><span data-stu-id="90efc-116">Type of the property.</span></span> <span data-ttu-id="90efc-117">サポートされる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="90efc-117">Supported values are:</span></span> <ul><li><span data-ttu-id="90efc-118">0 = 整数</span><span class="sxs-lookup"><span data-stu-id="90efc-118">0 = integer</span></span></li><li><span data-ttu-id="90efc-119">1 = 文字列</span><span class="sxs-lookup"><span data-stu-id="90efc-119">1 = string</span></span></li></ul>| 
| <span data-ttu-id="90efc-120">value</span><span class="sxs-lookup"><span data-stu-id="90efc-120">value</span></span>| <span data-ttu-id="90efc-121">string</span><span class="sxs-lookup"><span data-stu-id="90efc-121">string</span></span>| <span data-ttu-id="90efc-122">このプロパティの値。</span><span class="sxs-lookup"><span data-stu-id="90efc-122">Value of this property.</span></span>|

<a id="ID4EGC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="90efc-123">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="90efc-123">Sample JSON syntax</span></span>


```json
{
    "id":"1",
    "value":"20",
    "type":0
}

```


<a id="ID4EPC"></a>


## <a name="see-also"></a><span data-ttu-id="90efc-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="90efc-124">See also</span></span>

<a id="ID4ERC"></a>


##### <a name="parent"></a><span data-ttu-id="90efc-125">Parent</span><span class="sxs-lookup"><span data-stu-id="90efc-125">Parent</span></span>

[<span data-ttu-id="90efc-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="90efc-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
