---
title: Property (JSON)
assetID: 93de547e-d936-6fcc-92cb-e4dd284dd609
permalink: en-us/docs/xboxlive/rest/json-property.html
author: KevinAsgari
description: " Property (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d37054d03f6ebe8299db78673dc631c9b4b4bc16
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5742869"
---
# <a name="property-json"></a><span data-ttu-id="e86a1-104">Property (JSON)</span><span class="sxs-lookup"><span data-stu-id="e86a1-104">Property (JSON)</span></span>
<span data-ttu-id="e86a1-105">マッチメイ キング要求条件のクライアントによって提供されるプロパティ データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="e86a1-105">Contains property data provided by the client for matchmaking request criteria.</span></span>
<a id="ID4EN"></a>


## <a name="property"></a><span data-ttu-id="e86a1-106">プロパティ</span><span class="sxs-lookup"><span data-stu-id="e86a1-106">Property</span></span>

<span data-ttu-id="e86a1-107">プロパティ オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="e86a1-107">The Property object has the following specification.</span></span>

| <span data-ttu-id="e86a1-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="e86a1-108">Member</span></span>| <span data-ttu-id="e86a1-109">種類</span><span class="sxs-lookup"><span data-stu-id="e86a1-109">Type</span></span>| <span data-ttu-id="e86a1-110">説明</span><span class="sxs-lookup"><span data-stu-id="e86a1-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="e86a1-111">id</span><span class="sxs-lookup"><span data-stu-id="e86a1-111">id</span></span>| <span data-ttu-id="e86a1-112">string</span><span class="sxs-lookup"><span data-stu-id="e86a1-112">string</span></span>| <span data-ttu-id="e86a1-113">このプロパティの id。</span><span class="sxs-lookup"><span data-stu-id="e86a1-113">An id for this property.</span></span>|
| <span data-ttu-id="e86a1-114">type</span><span class="sxs-lookup"><span data-stu-id="e86a1-114">type</span></span>| <span data-ttu-id="e86a1-115">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="e86a1-115">32-bit signed integer</span></span> | <span data-ttu-id="e86a1-116">プロパティの型です。</span><span class="sxs-lookup"><span data-stu-id="e86a1-116">Type of the property.</span></span> <span data-ttu-id="e86a1-117">サポートされる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="e86a1-117">Supported values are:</span></span> <ul><li><span data-ttu-id="e86a1-118">0 = 整数</span><span class="sxs-lookup"><span data-stu-id="e86a1-118">0 = integer</span></span></li><li><span data-ttu-id="e86a1-119">1 = 文字列</span><span class="sxs-lookup"><span data-stu-id="e86a1-119">1 = string</span></span></li></ul>| 
| <span data-ttu-id="e86a1-120">value</span><span class="sxs-lookup"><span data-stu-id="e86a1-120">value</span></span>| <span data-ttu-id="e86a1-121">string</span><span class="sxs-lookup"><span data-stu-id="e86a1-121">string</span></span>| <span data-ttu-id="e86a1-122">このプロパティの値。</span><span class="sxs-lookup"><span data-stu-id="e86a1-122">Value of this property.</span></span>|

<a id="ID4EGC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="e86a1-123">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="e86a1-123">Sample JSON syntax</span></span>


```json
{
    "id":"1",
    "value":"20",
    "type":0
}

```


<a id="ID4EPC"></a>


## <a name="see-also"></a><span data-ttu-id="e86a1-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="e86a1-124">See also</span></span>

<a id="ID4ERC"></a>


##### <a name="parent"></a><span data-ttu-id="e86a1-125">Parent</span><span class="sxs-lookup"><span data-stu-id="e86a1-125">Parent</span></span>

[<span data-ttu-id="e86a1-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="e86a1-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
