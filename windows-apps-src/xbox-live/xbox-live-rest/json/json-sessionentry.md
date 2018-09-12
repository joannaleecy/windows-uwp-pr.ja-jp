---
title: SessionEntry (JSON)
assetID: b5cf5c3d-83b8-635f-d1a5-0be5d9434ea5
permalink: en-us/docs/xboxlive/rest/json-sessionentry.html
author: KevinAsgari
description: " SessionEntry (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6076f4dfbef0f926563f4696f8ee0e2660d0fc24
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881867"
---
# <a name="sessionentry-json"></a><span data-ttu-id="193e4-104">SessionEntry (JSON)</span><span class="sxs-lookup"><span data-stu-id="193e4-104">SessionEntry (JSON)</span></span>
<span data-ttu-id="193e4-105">フィットネス セッションは、データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="193e4-105">Contains data for a fitness session.</span></span> 
<a id="ID4EN"></a>

 
## <a name="sessionentry"></a><span data-ttu-id="193e4-106">SessionEntry</span><span class="sxs-lookup"><span data-stu-id="193e4-106">SessionEntry</span></span>
 
<span data-ttu-id="193e4-107">SessionEntry オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="193e4-107">The SessionEntry object has the following specification.</span></span>
 
| <span data-ttu-id="193e4-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="193e4-108">Member</span></span>| <span data-ttu-id="193e4-109">種類</span><span class="sxs-lookup"><span data-stu-id="193e4-109">Type</span></span>| <span data-ttu-id="193e4-110">説明</span><span class="sxs-lookup"><span data-stu-id="193e4-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="193e4-111">durationInSeconds</span><span class="sxs-lookup"><span data-stu-id="193e4-111">durationInSeconds</span></span>| <span data-ttu-id="193e4-112">32 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="193e4-112">32-bit signed integer</span></span> | <span data-ttu-id="193e4-113">継続時間-秒単位で、セッションのします。</span><span class="sxs-lookup"><span data-stu-id="193e4-113">Duration—in seconds—of the session.</span></span> | 
| <span data-ttu-id="193e4-114">コンセント</span><span class="sxs-lookup"><span data-stu-id="193e4-114">joules</span></span>| <span data-ttu-id="193e4-115">32 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="193e4-115">32-bit signed integer</span></span> | <span data-ttu-id="193e4-116">電力-コンセントで-セッションに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="193e4-116">Energy—in joules—burned in the session.</span></span> | 
| <span data-ttu-id="193e4-117">満たされています。</span><span class="sxs-lookup"><span data-stu-id="193e4-117">met</span></span>| <span data-ttu-id="193e4-118">単精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="193e4-118">single-precision floating-point number</span></span>| <span data-ttu-id="193e4-119">平均には、セッションの期間の値が満たされています。</span><span class="sxs-lookup"><span data-stu-id="193e4-119">Average met value over the session duration.</span></span> <span data-ttu-id="193e4-120">MET 値は、残りの部分で個人の代謝レートを基準としたアクティビティ中に、個人の代謝レートの比率です。</span><span class="sxs-lookup"><span data-stu-id="193e4-120">The MET value is the ratio of an individual's metabolic rate during an activity relative to the individual's metabolic rate at rest.</span></span> <span data-ttu-id="193e4-121">静止代謝、レートが個人の太さに関係なく 1.0 MET 値は、個人の静止代謝レートを基準としたためは、さまざまな重みの人の従業員が実行しているアクティビティの強さを比較を使用できます。</span><span class="sxs-lookup"><span data-stu-id="193e4-121">Because the metabolic rate for resting is 1.0 regardless of an individual's weight, and MET values are relative to an individual's resting metabolic rate, they can be used to compare the intensity of an activity being performed by individuals of different weights.</span></span>| 
| <span data-ttu-id="193e4-122">serverTimestamp</span><span class="sxs-lookup"><span data-stu-id="193e4-122">serverTimestamp</span></span>| <span data-ttu-id="193e4-123">DateTime</span><span class="sxs-lookup"><span data-stu-id="193e4-123">DateTime</span></span>| <span data-ttu-id="193e4-124">時間: UTC に基づいて-エントリは、サーバーで入力されたものです。</span><span class="sxs-lookup"><span data-stu-id="193e4-124">Time—based on UTC—entry was entered on server.</span></span> | 
| <span data-ttu-id="193e4-125">ソース</span><span class="sxs-lookup"><span data-stu-id="193e4-125">source</span></span>| <span data-ttu-id="193e4-126">8 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="193e4-126">8-bit unsigned integer</span></span>| <span data-ttu-id="193e4-127">セッションのソース。</span><span class="sxs-lookup"><span data-stu-id="193e4-127">Session source.</span></span>| 
| <span data-ttu-id="193e4-128">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="193e4-128">timestamp</span></span>| <span data-ttu-id="193e4-129">DateTime</span><span class="sxs-lookup"><span data-stu-id="193e4-129">DateTime</span></span>| <span data-ttu-id="193e4-130">時間: 協定世界時 (UTC) に基づく-エントリは、クライアントで作成されました。</span><span class="sxs-lookup"><span data-stu-id="193e4-130">Time—based on Coordinated Universal Time (UTC)—entry was created on the client.</span></span> | 
| <span data-ttu-id="193e4-131">titleId</span><span class="sxs-lookup"><span data-stu-id="193e4-131">titleId</span></span>| <span data-ttu-id="193e4-132">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="193e4-132">64-bit unsigned integer</span></span>| <span data-ttu-id="193e4-133">タイトル: 10 進数で、エントリを作成します。</span><span class="sxs-lookup"><span data-stu-id="193e4-133">Title—in decimal—that created the entry.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="193e4-134">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="193e4-134">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="193e4-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="193e4-135">See also</span></span>
 
<a id="ID4EQE"></a>

 
##### <a name="parent"></a><span data-ttu-id="193e4-136">Parent</span><span class="sxs-lookup"><span data-stu-id="193e4-136">Parent</span></span> 

[<span data-ttu-id="193e4-137">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="193e4-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   