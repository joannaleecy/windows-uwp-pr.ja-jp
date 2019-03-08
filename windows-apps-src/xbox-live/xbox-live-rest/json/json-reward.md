---
title: Reward (JSON)
assetID: d1c92e8a-afbc-22c5-c0b5-6063963f8c4d
permalink: en-us/docs/xboxlive/rest/json-reward.html
description: " Reward (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1d58d34263e7e0e90091c41c1df4fd5e078f5055
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57607497"
---
# <a name="reward-json"></a><span data-ttu-id="9d23a-104">Reward (JSON)</span><span class="sxs-lookup"><span data-stu-id="9d23a-104">Reward (JSON)</span></span>
<span data-ttu-id="9d23a-105">実績に関連付けられている特典です。</span><span class="sxs-lookup"><span data-stu-id="9d23a-105">The reward associated with the achievement.</span></span>
<a id="ID4EN"></a>


## <a name="reward"></a><span data-ttu-id="9d23a-106">報酬</span><span class="sxs-lookup"><span data-stu-id="9d23a-106">Reward</span></span>

<span data-ttu-id="9d23a-107">Reward オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9d23a-107">The Reward object has the following specification.</span></span>

| <span data-ttu-id="9d23a-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="9d23a-108">Member</span></span>| <span data-ttu-id="9d23a-109">種類</span><span class="sxs-lookup"><span data-stu-id="9d23a-109">Type</span></span>| <span data-ttu-id="9d23a-110">説明</span><span class="sxs-lookup"><span data-stu-id="9d23a-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="9d23a-111">name</span><span class="sxs-lookup"><span data-stu-id="9d23a-111">name</span></span>| <span data-ttu-id="9d23a-112">string</span><span class="sxs-lookup"><span data-stu-id="9d23a-112">string</span></span>| <span data-ttu-id="9d23a-113">報酬のユーザーに表示される名前。</span><span class="sxs-lookup"><span data-stu-id="9d23a-113">The user-facing name of the Reward.</span></span>|
| <span data-ttu-id="9d23a-114">説明</span><span class="sxs-lookup"><span data-stu-id="9d23a-114">description</span></span>| <span data-ttu-id="9d23a-115">string</span><span class="sxs-lookup"><span data-stu-id="9d23a-115">string</span></span>| <span data-ttu-id="9d23a-116">報酬のユーザーに表示される説明です。</span><span class="sxs-lookup"><span data-stu-id="9d23a-116">The user-facing description of the Reward.</span></span>|
| <span data-ttu-id="9d23a-117">value</span><span class="sxs-lookup"><span data-stu-id="9d23a-117">value</span></span>| <span data-ttu-id="9d23a-118">string</span><span class="sxs-lookup"><span data-stu-id="9d23a-118">string</span></span>| <span data-ttu-id="9d23a-119">報酬の値。</span><span class="sxs-lookup"><span data-stu-id="9d23a-119">The Reward's value.</span></span>|
| <span data-ttu-id="9d23a-120">type</span><span class="sxs-lookup"><span data-stu-id="9d23a-120">type</span></span>| <span data-ttu-id="9d23a-121">RewardType 列挙型</span><span class="sxs-lookup"><span data-stu-id="9d23a-121">RewardType enumeration</span></span>| <span data-ttu-id="9d23a-122">報酬の種類:</span><span class="sxs-lookup"><span data-stu-id="9d23a-122">The Reward type:</span></span> <ul><li><span data-ttu-id="9d23a-123">(0) が無効です。報酬を不明なサポートされていない型が構成されました。</span><span class="sxs-lookup"><span data-stu-id="9d23a-123">invalid (0): An unknown and unsupported reward type was configured.</span></span></li><li><span data-ttu-id="9d23a-124">ゲーマー (1):報酬は、プレーヤーのゲーマーにポイントを追加します。</span><span class="sxs-lookup"><span data-stu-id="9d23a-124">Gamerscore (1): The reward adds points to the player's Gamerscore.</span></span></li><li><span data-ttu-id="9d23a-125">inApp (2):報酬が定義され、タイトルに配信します。</span><span class="sxs-lookup"><span data-stu-id="9d23a-125">inApp (2): The reward is defined and delivered by the title.</span></span></li><li><span data-ttu-id="9d23a-126">アート (3):報酬は、デジタル資産です。</span><span class="sxs-lookup"><span data-stu-id="9d23a-126">Art (3): The reward is a digital asset.</span></span></li></ul> | 
| <span data-ttu-id="9d23a-127">ValueType</span><span class="sxs-lookup"><span data-stu-id="9d23a-127">valueType</span></span>| <span data-ttu-id="9d23a-128">ProgressValueDataType 列挙型</span><span class="sxs-lookup"><span data-stu-id="9d23a-128">ProgressValueDataType enumeration</span></span>| <span data-ttu-id="9d23a-129">値の型。</span><span class="sxs-lookup"><span data-stu-id="9d23a-129">The type of value.</span></span> <span data-ttu-id="9d23a-130">参照してください[要件 (JSON)](json-requirement.md)詳細についてはします。</span><span class="sxs-lookup"><span data-stu-id="9d23a-130">See [Requirement (JSON)](json-requirement.md) for more information.</span></span>|

<a id="ID4EBD"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="9d23a-131">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="9d23a-131">Sample JSON syntax</span></span>


```json
{
  "name":null,
  "description":null,
  "value":"10",
  "type":"Gamerscore",
  "valueType":"Int"
}

```


<a id="ID4EKD"></a>


## <a name="see-also"></a><span data-ttu-id="9d23a-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="9d23a-132">See also</span></span>

<a id="ID4EMD"></a>


##### <a name="parent"></a><span data-ttu-id="9d23a-133">Parent</span><span class="sxs-lookup"><span data-stu-id="9d23a-133">Parent</span></span>

[<span data-ttu-id="9d23a-134">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="9d23a-134">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
