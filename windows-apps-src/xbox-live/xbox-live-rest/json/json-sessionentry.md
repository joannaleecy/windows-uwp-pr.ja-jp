---
title: SessionEntry (JSON)
assetID: b5cf5c3d-83b8-635f-d1a5-0be5d9434ea5
permalink: en-us/docs/xboxlive/rest/json-sessionentry.html
description: " SessionEntry (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 73133f898ff219477cb60f54798cbd81acb87ebe
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589737"
---
# <a name="sessionentry-json"></a><span data-ttu-id="3995b-104">SessionEntry (JSON)</span><span class="sxs-lookup"><span data-stu-id="3995b-104">SessionEntry (JSON)</span></span>
<span data-ttu-id="3995b-105">フィットネス セッションにはデータが含まれます。</span><span class="sxs-lookup"><span data-stu-id="3995b-105">Contains data for a fitness session.</span></span> 
<a id="ID4EN"></a>

 
## <a name="sessionentry"></a><span data-ttu-id="3995b-106">SessionEntry</span><span class="sxs-lookup"><span data-stu-id="3995b-106">SessionEntry</span></span>
 
<span data-ttu-id="3995b-107">SessionEntry オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="3995b-107">The SessionEntry object has the following specification.</span></span>
 
| <span data-ttu-id="3995b-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="3995b-108">Member</span></span>| <span data-ttu-id="3995b-109">種類</span><span class="sxs-lookup"><span data-stu-id="3995b-109">Type</span></span>| <span data-ttu-id="3995b-110">説明</span><span class="sxs-lookup"><span data-stu-id="3995b-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3995b-111">durationInSeconds</span><span class="sxs-lookup"><span data-stu-id="3995b-111">durationInSeconds</span></span>| <span data-ttu-id="3995b-112">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="3995b-112">32-bit signed integer</span></span> | <span data-ttu-id="3995b-113">期間: 秒単位で、セッションのです。</span><span class="sxs-lookup"><span data-stu-id="3995b-113">Duration—in seconds—of the session.</span></span> | 
| <span data-ttu-id="3995b-114">コンセント</span><span class="sxs-lookup"><span data-stu-id="3995b-114">joules</span></span>| <span data-ttu-id="3995b-115">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="3995b-115">32-bit signed integer</span></span> | <span data-ttu-id="3995b-116">エネルギー —、コンセントで、セッションに書き込みます。</span><span class="sxs-lookup"><span data-stu-id="3995b-116">Energy—in joules—burned in the session.</span></span> | 
| <span data-ttu-id="3995b-117">満たされる</span><span class="sxs-lookup"><span data-stu-id="3995b-117">met</span></span>| <span data-ttu-id="3995b-118">単精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="3995b-118">single-precision floating-point number</span></span>| <span data-ttu-id="3995b-119">平均では、セッションの期間にわたって値が満たされます。</span><span class="sxs-lookup"><span data-stu-id="3995b-119">Average met value over the session duration.</span></span> <span data-ttu-id="3995b-120">MET 値は、保存時の個々 の代謝率の基準としたアクティビティの中に、個々 の代謝レートの比率です。</span><span class="sxs-lookup"><span data-stu-id="3995b-120">The MET value is the ratio of an individual's metabolic rate during an activity relative to the individual's metabolic rate at rest.</span></span> <span data-ttu-id="3995b-121">代謝のレートを置くは、個々 の重みに関係なく 1.0 MET 値は、個々 の配置されている代謝率の基準としたためは、さまざまな重みの個人によって実行されるアクティビティの強度を比較に使用できます。</span><span class="sxs-lookup"><span data-stu-id="3995b-121">Because the metabolic rate for resting is 1.0 regardless of an individual's weight, and MET values are relative to an individual's resting metabolic rate, they can be used to compare the intensity of an activity being performed by individuals of different weights.</span></span>| 
| <span data-ttu-id="3995b-122">serverTimestamp</span><span class="sxs-lookup"><span data-stu-id="3995b-122">serverTimestamp</span></span>| <span data-ttu-id="3995b-123">DateTime</span><span class="sxs-lookup"><span data-stu-id="3995b-123">DateTime</span></span>| <span data-ttu-id="3995b-124">時間: UTC に基づいています: サーバーにエントリが入力されました。</span><span class="sxs-lookup"><span data-stu-id="3995b-124">Time—based on UTC—entry was entered on server.</span></span> | 
| <span data-ttu-id="3995b-125">ソース</span><span class="sxs-lookup"><span data-stu-id="3995b-125">source</span></span>| <span data-ttu-id="3995b-126">8 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3995b-126">8-bit unsigned integer</span></span>| <span data-ttu-id="3995b-127">セッションのソース。</span><span class="sxs-lookup"><span data-stu-id="3995b-127">Session source.</span></span>| 
| <span data-ttu-id="3995b-128">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="3995b-128">timestamp</span></span>| <span data-ttu-id="3995b-129">DateTime</span><span class="sxs-lookup"><span data-stu-id="3995b-129">DateTime</span></span>| <span data-ttu-id="3995b-130">時間-世界協定時刻 (UTC) に基づいて、クライアントのエントリが作成されました。</span><span class="sxs-lookup"><span data-stu-id="3995b-130">Time—based on Coordinated Universal Time (UTC)—entry was created on the client.</span></span> | 
| <span data-ttu-id="3995b-131">titleId</span><span class="sxs-lookup"><span data-stu-id="3995b-131">titleId</span></span>| <span data-ttu-id="3995b-132">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3995b-132">64-bit unsigned integer</span></span>| <span data-ttu-id="3995b-133">タイトル: 10 進数で、エントリを作成します。</span><span class="sxs-lookup"><span data-stu-id="3995b-133">Title—in decimal—that created the entry.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="3995b-134">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="3995b-134">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3995b-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="3995b-135">See also</span></span>
 
<a id="ID4EQE"></a>

 
##### <a name="parent"></a><span data-ttu-id="3995b-136">Parent</span><span class="sxs-lookup"><span data-stu-id="3995b-136">Parent</span></span> 

[<span data-ttu-id="3995b-137">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="3995b-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   