---
title: SessionEntry (JSON)
assetID: b5cf5c3d-83b8-635f-d1a5-0be5d9434ea5
permalink: en-us/docs/xboxlive/rest/json-sessionentry.html
author: KevinAsgari
description: " SessionEntry (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a8ec59202300912d4646b0e759e7bbf037853608
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7558370"
---
# <a name="sessionentry-json"></a><span data-ttu-id="fdcfe-104">SessionEntry (JSON)</span><span class="sxs-lookup"><span data-stu-id="fdcfe-104">SessionEntry (JSON)</span></span>
<span data-ttu-id="fdcfe-105">フィットネス セッションのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-105">Contains data for a fitness session.</span></span> 
<a id="ID4EN"></a>

 
## <a name="sessionentry"></a><span data-ttu-id="fdcfe-106">SessionEntry</span><span class="sxs-lookup"><span data-stu-id="fdcfe-106">SessionEntry</span></span>
 
<span data-ttu-id="fdcfe-107">SessionEntry オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-107">The SessionEntry object has the following specification.</span></span>
 
| <span data-ttu-id="fdcfe-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="fdcfe-108">Member</span></span>| <span data-ttu-id="fdcfe-109">種類</span><span class="sxs-lookup"><span data-stu-id="fdcfe-109">Type</span></span>| <span data-ttu-id="fdcfe-110">説明</span><span class="sxs-lookup"><span data-stu-id="fdcfe-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="fdcfe-111">durationInSeconds</span><span class="sxs-lookup"><span data-stu-id="fdcfe-111">durationInSeconds</span></span>| <span data-ttu-id="fdcfe-112">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="fdcfe-112">32-bit signed integer</span></span> | <span data-ttu-id="fdcfe-113">継続時間-秒単位で、セッションのします。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-113">Duration—in seconds—of the session.</span></span> | 
| <span data-ttu-id="fdcfe-114">コンセント</span><span class="sxs-lookup"><span data-stu-id="fdcfe-114">joules</span></span>| <span data-ttu-id="fdcfe-115">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="fdcfe-115">32-bit signed integer</span></span> | <span data-ttu-id="fdcfe-116">エネルギー-コンセントで-セッションに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-116">Energy—in joules—burned in the session.</span></span> | 
| <span data-ttu-id="fdcfe-117">満たされています。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-117">met</span></span>| <span data-ttu-id="fdcfe-118">単精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="fdcfe-118">single-precision floating-point number</span></span>| <span data-ttu-id="fdcfe-119">平均では、セッションの期間にわたって値が満たされています。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-119">Average met value over the session duration.</span></span> <span data-ttu-id="fdcfe-120">MET 値は、アクティビティを残りの部分で個人の代謝レートを基準とした時に、個々 の代謝レートの比率です。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-120">The MET value is the ratio of an individual's metabolic rate during an activity relative to the individual's metabolic rate at rest.</span></span> <span data-ttu-id="fdcfe-121">静止の代謝レートは、個々 の太さに関係なく 1.0 MET 値は、個人の静止代謝レートを基準としたためは、さまざまな重みの人の従業員が実行しているアクティビティの強さを比較を使用できます。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-121">Because the metabolic rate for resting is 1.0 regardless of an individual's weight, and MET values are relative to an individual's resting metabolic rate, they can be used to compare the intensity of an activity being performed by individuals of different weights.</span></span>| 
| <span data-ttu-id="fdcfe-122">serverTimestamp</span><span class="sxs-lookup"><span data-stu-id="fdcfe-122">serverTimestamp</span></span>| <span data-ttu-id="fdcfe-123">DateTime</span><span class="sxs-lookup"><span data-stu-id="fdcfe-123">DateTime</span></span>| <span data-ttu-id="fdcfe-124">時間: UTC に基づいて-エントリは、サーバーで入力されたものです。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-124">Time—based on UTC—entry was entered on server.</span></span> | 
| <span data-ttu-id="fdcfe-125">ソース</span><span class="sxs-lookup"><span data-stu-id="fdcfe-125">source</span></span>| <span data-ttu-id="fdcfe-126">8 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fdcfe-126">8-bit unsigned integer</span></span>| <span data-ttu-id="fdcfe-127">セッションのソース。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-127">Session source.</span></span>| 
| <span data-ttu-id="fdcfe-128">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="fdcfe-128">timestamp</span></span>| <span data-ttu-id="fdcfe-129">DateTime</span><span class="sxs-lookup"><span data-stu-id="fdcfe-129">DateTime</span></span>| <span data-ttu-id="fdcfe-130">時間: 協定世界時 (UTC) に基づく、エントリは、クライアントで作成されました。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-130">Time—based on Coordinated Universal Time (UTC)—entry was created on the client.</span></span> | 
| <span data-ttu-id="fdcfe-131">titleId</span><span class="sxs-lookup"><span data-stu-id="fdcfe-131">titleId</span></span>| <span data-ttu-id="fdcfe-132">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fdcfe-132">64-bit unsigned integer</span></span>| <span data-ttu-id="fdcfe-133">タイトル: 10 進数で、エントリを作成します。</span><span class="sxs-lookup"><span data-stu-id="fdcfe-133">Title—in decimal—that created the entry.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="fdcfe-134">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="fdcfe-134">Sample JSON syntax</span></span>
 

```json
{
   "titleId" : "1234567",
   "timestamp" : "2011-11-18T08:08:46Z",
   "serverTimestamp" : "2011-11-20T04:04:23Z",
   "durationInSeconds" : 240,
   "joules" :  1600,
   "met" :  "124"
   "source" :  "1"
}
    
```

  
<a id="ID4EOE"></a>

 
## <a name="see-also"></a><span data-ttu-id="fdcfe-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="fdcfe-135">See also</span></span>
 
<a id="ID4EQE"></a>

 
##### <a name="parent"></a><span data-ttu-id="fdcfe-136">Parent</span><span class="sxs-lookup"><span data-stu-id="fdcfe-136">Parent</span></span> 

[<span data-ttu-id="fdcfe-137">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="fdcfe-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   