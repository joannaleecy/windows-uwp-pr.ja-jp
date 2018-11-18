---
title: AggregateSessionsResponse (JSON)
assetID: 020ee9b2-c96c-2e65-4e6d-f9f4bd25a374
permalink: en-us/docs/xboxlive/rest/json-aggregatesessionsresponse.html
author: KevinAsgari
description: " AggregateSessionsResponse (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 590acdd89d83fa21a401b5573053ba341f7f05c7
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7166253"
---
# <a name="aggregatesessionsresponse-json"></a><span data-ttu-id="bf058-104">AggregateSessionsResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="bf058-104">AggregateSessionsResponse (JSON)</span></span>
<span data-ttu-id="bf058-105">ユーザーの適合性のセッションは、集計されたデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="bf058-105">Contains aggregated data for a user's fitness sessions.</span></span> 
<a id="ID4EN"></a>

 
## <a name="aggregatesessionsresponse"></a><span data-ttu-id="bf058-106">AggregateSessionsResponse</span><span class="sxs-lookup"><span data-stu-id="bf058-106">AggregateSessionsResponse</span></span>
 
<span data-ttu-id="bf058-107">AggregateSessionsResponse オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="bf058-107">The AggregateSessionsResponse object has the following specification.</span></span>
 
| <span data-ttu-id="bf058-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="bf058-108">Member</span></span>| <span data-ttu-id="bf058-109">種類</span><span class="sxs-lookup"><span data-stu-id="bf058-109">Type</span></span>| <span data-ttu-id="bf058-110">説明</span><span class="sxs-lookup"><span data-stu-id="bf058-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bf058-111">totalDurationInSeconds</span><span class="sxs-lookup"><span data-stu-id="bf058-111">totalDurationInSeconds</span></span>| <span data-ttu-id="bf058-112">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="bf058-112">64-bit signed integer</span></span>| <span data-ttu-id="bf058-113">集計期間を秒単位でセッションの合計期間です。</span><span class="sxs-lookup"><span data-stu-id="bf058-113">Total duration of sessions in seconds over the aggregation period.</span></span>| 
| <span data-ttu-id="bf058-114">totalJoules</span><span class="sxs-lookup"><span data-stu-id="bf058-114">totalJoules</span></span>| <span data-ttu-id="bf058-115">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="bf058-115">64-bit signed integer</span></span>| <span data-ttu-id="bf058-116">エネルギーの書き込みの合計-コンセントで-集計期間中です。</span><span class="sxs-lookup"><span data-stu-id="bf058-116">Total energy burned—in joules—over the aggregation period.</span></span> | 
| <span data-ttu-id="bf058-117">totalSessions</span><span class="sxs-lookup"><span data-stu-id="bf058-117">totalSessions</span></span>| <span data-ttu-id="bf058-118">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="bf058-118">64-bit signed integer</span></span>| <span data-ttu-id="bf058-119">集計期間中のセッションの合計数。</span><span class="sxs-lookup"><span data-stu-id="bf058-119">Total number of sessions over the aggregation period.</span></span>| 
| <span data-ttu-id="bf058-120">weightedAverageMets</span><span class="sxs-lookup"><span data-stu-id="bf058-120">weightedAverageMets</span></span>| <span data-ttu-id="bf058-121">単精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="bf058-121">single-precision floating-point number</span></span> | <span data-ttu-id="bf058-122">加重平均代謝と同等の集計期間中のタスク (MET) の値。</span><span class="sxs-lookup"><span data-stu-id="bf058-122">Weighted average metabolic equivalent of task (MET) value over the aggregation period.</span></span> <span data-ttu-id="bf058-123">MET 値は、アクティビティを残りの部分で個人の代謝レートを基準とした時に、個々 の代謝レートの比率です。</span><span class="sxs-lookup"><span data-stu-id="bf058-123">The MET value is the ratio of an individual's metabolic rate during an activity relative to the individual's metabolic rate at rest.</span></span> <span data-ttu-id="bf058-124">静止の代謝レートは、個々 の太さに関係なく 1.0 MET 値は、個人の静止代謝レートを基準としたためは、さまざまな重みの人の従業員が実行しているアクティビティの強さを比較を使用できます。</span><span class="sxs-lookup"><span data-stu-id="bf058-124">Because the metabolic rate for resting is 1.0 regardless of an individual's weight, and MET values are relative to an individual's resting metabolic rate, they can be used to compare the intensity of an activity being performed by individuals of different weights.</span></span>| 
  
<a id="ID4ESC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="bf058-125">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="bf058-125">Sample JSON syntax</span></span>
 

```json
{
   "totalSessions" : 300,
   "totalDurationInSeconds" : 1240,
   "totalJoules" :  21600,
   "weightedAvgMet" : 21,
}

    
```

  
<a id="ID4E2C"></a>

 
## <a name="see-also"></a><span data-ttu-id="bf058-126">関連項目</span><span class="sxs-lookup"><span data-stu-id="bf058-126">See also</span></span>
 
<a id="ID4E4C"></a>

 
##### <a name="parent"></a><span data-ttu-id="bf058-127">Parent</span><span class="sxs-lookup"><span data-stu-id="bf058-127">Parent</span></span> 

[<span data-ttu-id="bf058-128">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="bf058-128">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   