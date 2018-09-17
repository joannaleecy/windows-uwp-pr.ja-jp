---
title: Reward (JSON)
assetID: d1c92e8a-afbc-22c5-c0b5-6063963f8c4d
permalink: en-us/docs/xboxlive/rest/json-reward.html
author: KevinAsgari
description: " Reward (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0ddecacdf77305b6c9449bd5e903a5e4c0fa74d7
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3988758"
---
# <a name="reward-json"></a><span data-ttu-id="e003c-104">Reward (JSON)</span><span class="sxs-lookup"><span data-stu-id="e003c-104">Reward (JSON)</span></span>
<span data-ttu-id="e003c-105">実績に関連付けられているリワードです。</span><span class="sxs-lookup"><span data-stu-id="e003c-105">The reward associated with the achievement.</span></span>
<a id="ID4EN"></a>


## <a name="reward"></a><span data-ttu-id="e003c-106">リワード</span><span class="sxs-lookup"><span data-stu-id="e003c-106">Reward</span></span>

<span data-ttu-id="e003c-107">リワード オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="e003c-107">The Reward object has the following specification.</span></span>

| <span data-ttu-id="e003c-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="e003c-108">Member</span></span>| <span data-ttu-id="e003c-109">種類</span><span class="sxs-lookup"><span data-stu-id="e003c-109">Type</span></span>| <span data-ttu-id="e003c-110">説明</span><span class="sxs-lookup"><span data-stu-id="e003c-110">Description</span></span>|
| --- | --- | --- |
| <span data-ttu-id="e003c-111">name</span><span class="sxs-lookup"><span data-stu-id="e003c-111">name</span></span>| <span data-ttu-id="e003c-112">string</span><span class="sxs-lookup"><span data-stu-id="e003c-112">string</span></span>| <span data-ttu-id="e003c-113">ユーザーに表示されるリワードの名前です。</span><span class="sxs-lookup"><span data-stu-id="e003c-113">The user-facing name of the Reward.</span></span>|
| <span data-ttu-id="e003c-114">description</span><span class="sxs-lookup"><span data-stu-id="e003c-114">description</span></span>| <span data-ttu-id="e003c-115">string</span><span class="sxs-lookup"><span data-stu-id="e003c-115">string</span></span>| <span data-ttu-id="e003c-116">ユーザーに表示されるリワードの説明です。</span><span class="sxs-lookup"><span data-stu-id="e003c-116">The user-facing description of the Reward.</span></span>|
| <span data-ttu-id="e003c-117">value</span><span class="sxs-lookup"><span data-stu-id="e003c-117">value</span></span>| <span data-ttu-id="e003c-118">string</span><span class="sxs-lookup"><span data-stu-id="e003c-118">string</span></span>| <span data-ttu-id="e003c-119">リワードの値です。</span><span class="sxs-lookup"><span data-stu-id="e003c-119">The Reward's value.</span></span>|
| <span data-ttu-id="e003c-120">type</span><span class="sxs-lookup"><span data-stu-id="e003c-120">type</span></span>| <span data-ttu-id="e003c-121">RewardType 列挙</span><span class="sxs-lookup"><span data-stu-id="e003c-121">RewardType enumeration</span></span>| <span data-ttu-id="e003c-122">リワードの種類:</span><span class="sxs-lookup"><span data-stu-id="e003c-122">The Reward type:</span></span> <ul><li><span data-ttu-id="e003c-123">無効 (0): 不明なおよびサポートされていないリワード型が構成されています。</span><span class="sxs-lookup"><span data-stu-id="e003c-123">invalid (0): An unknown and unsupported reward type was configured.</span></span></li><li><span data-ttu-id="e003c-124">(1): ゲーマー スコア リワードでは、プレイヤーのゲーマー スコアにポイントを追加します。</span><span class="sxs-lookup"><span data-stu-id="e003c-124">Gamerscore (1): The reward adds points to the player's Gamerscore.</span></span></li><li><span data-ttu-id="e003c-125">inApp (2): リワードが定義されているし、タイトルによって配信します。</span><span class="sxs-lookup"><span data-stu-id="e003c-125">inApp (2): The reward is defined and delivered by the title.</span></span></li><li><span data-ttu-id="e003c-126">アート (3): リワードは、デジタル資産です。</span><span class="sxs-lookup"><span data-stu-id="e003c-126">Art (3): The reward is a digital asset.</span></span></li></ul> | 
| <span data-ttu-id="e003c-127">valueType</span><span class="sxs-lookup"><span data-stu-id="e003c-127">valueType</span></span>| <span data-ttu-id="e003c-128">ProgressValueDataType 列挙</span><span class="sxs-lookup"><span data-stu-id="e003c-128">ProgressValueDataType enumeration</span></span>| <span data-ttu-id="e003c-129">値の種類です。</span><span class="sxs-lookup"><span data-stu-id="e003c-129">The type of value.</span></span> <span data-ttu-id="e003c-130">詳細については、[要件 (JSON)](json-requirement.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e003c-130">See [Requirement (JSON)](json-requirement.md) for more information.</span></span>|

<a id="ID4EBD"></a>


## <a name="sample-json-syntax"></a><span data-ttu-id="e003c-131">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="e003c-131">Sample JSON syntax</span></span>


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


## <a name="see-also"></a><span data-ttu-id="e003c-132">関連項目</span><span class="sxs-lookup"><span data-stu-id="e003c-132">See also</span></span>

<a id="ID4EMD"></a>


##### <a name="parent"></a><span data-ttu-id="e003c-133">Parent</span><span class="sxs-lookup"><span data-stu-id="e003c-133">Parent</span></span>

[<span data-ttu-id="e003c-134">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="e003c-134">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)
