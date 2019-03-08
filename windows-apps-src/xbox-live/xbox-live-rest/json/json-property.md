---
title: Property (JSON)
assetID: 93de547e-d936-6fcc-92cb-e4dd284dd609
permalink: en-us/docs/xboxlive/rest/json-property.html
description: " Property (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7e2a721886509c49c60d663d491f8d49bc3c95e9
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57659707"
---
# <a name="property-json"></a><span data-ttu-id="10b8d-104">Property (JSON)</span><span class="sxs-lookup"><span data-stu-id="10b8d-104">Property (JSON)</span></span>
<span data-ttu-id="10b8d-105">マッチメイ キング要求条件、クライアントによって提供されるプロパティのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="10b8d-105">Contains property data provided by the client for matchmaking request criteria.</span></span>
<a id="ID4EN"></a>


## <a name="property"></a><span data-ttu-id="10b8d-106">プロパティ</span><span class="sxs-lookup"><span data-stu-id="10b8d-106">Property</span></span>

<span data-ttu-id="10b8d-107">プロパティ オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="10b8d-107">The Property object has the following specification.</span></span>

| <span data-ttu-id="10b8d-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="10b8d-108">Member</span></span>| <span data-ttu-id="10b8d-109">種類</span><span class="sxs-lookup"><span data-stu-id="10b8d-109">Type</span></span>| <span data-ttu-id="10b8d-110">説明</span><span class="sxs-lookup"><span data-stu-id="10b8d-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="10b8d-111">id</span><span class="sxs-lookup"><span data-stu-id="10b8d-111">id</span></span>| <span data-ttu-id="10b8d-112">string</span><span class="sxs-lookup"><span data-stu-id="10b8d-112">string</span></span>| <span data-ttu-id="10b8d-113">このプロパティの id。</span><span class="sxs-lookup"><span data-stu-id="10b8d-113">An id for this property.</span></span>|
| <span data-ttu-id="10b8d-114">type</span><span class="sxs-lookup"><span data-stu-id="10b8d-114">type</span></span>| <span data-ttu-id="10b8d-115">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="10b8d-115">32-bit signed integer</span></span> | <span data-ttu-id="10b8d-116">プロパティの型。</span><span class="sxs-lookup"><span data-stu-id="10b8d-116">Type of the property.</span></span> <span data-ttu-id="10b8d-117">サポートされている値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="10b8d-117">Supported values are:</span></span> <ul><li><span data-ttu-id="10b8d-118">0 = 整数</span><span class="sxs-lookup"><span data-stu-id="10b8d-118">0 = integer</span></span></li><li><span data-ttu-id="10b8d-119">1 = 文字列</span><span class="sxs-lookup"><span data-stu-id="10b8d-119">1 = string</span></span></li></ul>| 
| <span data-ttu-id="10b8d-120">value</span><span class="sxs-lookup"><span data-stu-id="10b8d-120">value</span></span>| <span data-ttu-id="10b8d-121">string</span><span class="sxs-lookup"><span data-stu-id="10b8d-121">string</span></span>| <span data-ttu-id="10b8d-122">このプロパティの値。</span><span class="sxs-lookup"><span data-stu-id="10b8d-122">Value of this property.</span></span>|

<a id="ID4EGC"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="10b8d-123">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="10b8d-123">Sample JSON syntax</span></span>


```json
{
    "id":"1",
    "value":"20",
    "type":0
}

```


<a id="ID4EPC"></a>


## <a name="see-also"></a><span data-ttu-id="10b8d-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="10b8d-124">See also</span></span>

<a id="ID4ERC"></a>


##### <a name="parent"></a><span data-ttu-id="10b8d-125">Parent</span><span class="sxs-lookup"><span data-stu-id="10b8d-125">Parent</span></span>

[<span data-ttu-id="10b8d-126">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="10b8d-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
