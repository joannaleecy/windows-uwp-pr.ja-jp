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
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4572093"
---
# <a name="property-json"></a><span data-ttu-id="589a7-104">Property (JSON)</span><span class="sxs-lookup"><span data-stu-id="589a7-104">Property (JSON)</span></span>
<span data-ttu-id="589a7-105">マッチメイ キング要求条件のクライアントによって提供されるプロパティのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="589a7-105">Contains property data provided by the client for matchmaking request criteria.</span></span>
<a id="ID4EN"></a>


## <a name="property"></a><span data-ttu-id="589a7-106">プロパティ</span><span class="sxs-lookup"><span data-stu-id="589a7-106">Property</span></span>

<span data-ttu-id="589a7-107">プロパティ オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="589a7-107">The Property object has the following specification.</span></span>

| <span data-ttu-id="589a7-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="589a7-108">Member</span></span>| <span data-ttu-id="589a7-109">種類</span><span class="sxs-lookup"><span data-stu-id="589a7-109">Type</span></span>| <span data-ttu-id="589a7-110">説明</span><span class="sxs-lookup"><span data-stu-id="589a7-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="589a7-111">id</span><span class="sxs-lookup"><span data-stu-id="589a7-111">id</span></span>| <span data-ttu-id="589a7-112">string</span><span class="sxs-lookup"><span data-stu-id="589a7-112">string</span></span>| <span data-ttu-id="589a7-113">このプロパティの id。</span><span class="sxs-lookup"><span data-stu-id="589a7-113">An id for this property.</span></span>|
| <span data-ttu-id="589a7-114">type</span><span class="sxs-lookup"><span data-stu-id="589a7-114">type</span></span>| <span data-ttu-id="589a7-115">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="589a7-115">32-bit signed integer</span></span> | <span data-ttu-id="589a7-116">プロパティの型です。</span><span class="sxs-lookup"><span data-stu-id="589a7-116">Type of the property.</span></span> <span data-ttu-id="589a7-117">サポートされる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="589a7-117">Supported values are:</span></span> <ul><li><span data-ttu-id="589a7-118">0 = 整数</span><span class="sxs-lookup"><span data-stu-id="589a7-118">0 = integer</span></span></li><li><span data-ttu-id="589a7-119">1 = 文字列</span><span class="sxs-lookup"><span data-stu-id="589a7-119">1 = string</span></span></li></ul>| 
| <span data-ttu-id="589a7-120">value</span><span class="sxs-lookup"><span data-stu-id="589a7-120">value</span></span>| <span data-ttu-id="589a7-121">string</span><span class="sxs-lookup"><span data-stu-id="589a7-121">string</span></span>| <span data-ttu-id="589a7-122">このプロパティの値。</span><span class="sxs-lookup"><span data-stu-id="589a7-122">Value of this property.</span></span>|

<a id="ID4EGC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="589a7-123">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="589a7-123">Sample JSON syntax</span></span>


```json
{
    "id":"1",
    "value":"20",
    "type":0
}

```


<a id="ID4EPC"></a>


## <a name="see-also"></a><span data-ttu-id="589a7-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="589a7-124">See also</span></span>

<a id="ID4ERC"></a>


##### <a name="parent"></a><span data-ttu-id="589a7-125">Parent</span><span class="sxs-lookup"><span data-stu-id="589a7-125">Parent</span></span>

[<span data-ttu-id="589a7-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="589a7-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
