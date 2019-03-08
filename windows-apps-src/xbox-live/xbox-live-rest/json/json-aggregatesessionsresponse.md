---
title: AggregateSessionsResponse (JSON)
assetID: 020ee9b2-c96c-2e65-4e6d-f9f4bd25a374
permalink: en-us/docs/xboxlive/rest/json-aggregatesessionsresponse.html
description: " AggregateSessionsResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ef026fd5096d047b2014faaf95a667c69827e043
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57608307"
---
# <a name="aggregatesessionsresponse-json"></a><span data-ttu-id="1eb53-104">AggregateSessionsResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="1eb53-104">AggregateSessionsResponse (JSON)</span></span>
<span data-ttu-id="1eb53-105">ユーザーのフィットネス セッションの集計データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="1eb53-105">Contains aggregated data for a user's fitness sessions.</span></span> 
<a id="ID4EN"></a>

 
## <a name="aggregatesessionsresponse"></a><span data-ttu-id="1eb53-106">AggregateSessionsResponse</span><span class="sxs-lookup"><span data-stu-id="1eb53-106">AggregateSessionsResponse</span></span>
 
<span data-ttu-id="1eb53-107">AggregateSessionsResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="1eb53-107">The AggregateSessionsResponse object has the following specification.</span></span>
 
| <span data-ttu-id="1eb53-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="1eb53-108">Member</span></span>| <span data-ttu-id="1eb53-109">種類</span><span class="sxs-lookup"><span data-stu-id="1eb53-109">Type</span></span>| <span data-ttu-id="1eb53-110">説明</span><span class="sxs-lookup"><span data-stu-id="1eb53-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="1eb53-111">totalDurationInSeconds</span><span class="sxs-lookup"><span data-stu-id="1eb53-111">totalDurationInSeconds</span></span>| <span data-ttu-id="1eb53-112">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1eb53-112">64-bit signed integer</span></span>| <span data-ttu-id="1eb53-113">集計期間 (秒) のセッションの合計継続時間。</span><span class="sxs-lookup"><span data-stu-id="1eb53-113">Total duration of sessions in seconds over the aggregation period.</span></span>| 
| <span data-ttu-id="1eb53-114">totalJoules</span><span class="sxs-lookup"><span data-stu-id="1eb53-114">totalJoules</span></span>| <span data-ttu-id="1eb53-115">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1eb53-115">64-bit signed integer</span></span>| <span data-ttu-id="1eb53-116">燃焼されるエネルギーの合計: の単位はジュール: 集計期間にわたるします。</span><span class="sxs-lookup"><span data-stu-id="1eb53-116">Total energy burned—in joules—over the aggregation period.</span></span> | 
| <span data-ttu-id="1eb53-117">totalSessions</span><span class="sxs-lookup"><span data-stu-id="1eb53-117">totalSessions</span></span>| <span data-ttu-id="1eb53-118">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="1eb53-118">64-bit signed integer</span></span>| <span data-ttu-id="1eb53-119">集計期間にわたるセッションの合計数。</span><span class="sxs-lookup"><span data-stu-id="1eb53-119">Total number of sessions over the aggregation period.</span></span>| 
| <span data-ttu-id="1eb53-120">weightedAverageMets</span><span class="sxs-lookup"><span data-stu-id="1eb53-120">weightedAverageMets</span></span>| <span data-ttu-id="1eb53-121">単精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="1eb53-121">single-precision floating-point number</span></span> | <span data-ttu-id="1eb53-122">加重平均代謝値と等価のタスク (MET) 集計期間。</span><span class="sxs-lookup"><span data-stu-id="1eb53-122">Weighted average metabolic equivalent of task (MET) value over the aggregation period.</span></span> <span data-ttu-id="1eb53-123">MET 値は、保存時の個々 の代謝率の基準としたアクティビティの中に、個々 の代謝レートの比率です。</span><span class="sxs-lookup"><span data-stu-id="1eb53-123">The MET value is the ratio of an individual's metabolic rate during an activity relative to the individual's metabolic rate at rest.</span></span> <span data-ttu-id="1eb53-124">代謝のレートを置くは、個々 の重みに関係なく 1.0 MET 値は、個々 の配置されている代謝率の基準としたためは、さまざまな重みの個人によって実行されるアクティビティの強度を比較に使用できます。</span><span class="sxs-lookup"><span data-stu-id="1eb53-124">Because the metabolic rate for resting is 1.0 regardless of an individual's weight, and MET values are relative to an individual's resting metabolic rate, they can be used to compare the intensity of an activity being performed by individuals of different weights.</span></span>| 
  
<a id="ID4ESC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="1eb53-125">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="1eb53-125">Sample JSON syntax</span></span>
 

```json
{
   "totalSessions" : 300,
   "totalDurationInSeconds" : 1240,
   "totalJoules" :  21600,
   "weightedAvgMet" : 21,
}

    
```

  
<a id="ID4E2C"></a>

 
## <a name="see-also"></a><span data-ttu-id="1eb53-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="1eb53-126">See also</span></span>
 
<a id="ID4E4C"></a>

 
##### <a name="parent"></a><span data-ttu-id="1eb53-127">Parent</span><span class="sxs-lookup"><span data-stu-id="1eb53-127">Parent</span></span> 

[<span data-ttu-id="1eb53-128">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="1eb53-128">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   