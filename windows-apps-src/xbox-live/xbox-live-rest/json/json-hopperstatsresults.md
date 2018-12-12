---
title: HopperStatsResults (JSON)
assetID: 91927da1-2e97-f7bc-ae62-7e0e9966b98e
permalink: en-us/docs/xboxlive/rest/json-hopperstatsresults.html
description: " HopperStatsResults (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 38e345fc20e92cdf6446c6ae1100e347fe634eff
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8936793"
---
# <a name="hopperstatsresults-json"></a><span data-ttu-id="75f87-104">HopperStatsResults (JSON)</span><span class="sxs-lookup"><span data-stu-id="75f87-104">HopperStatsResults (JSON)</span></span>
<span data-ttu-id="75f87-105">ホッパーの統計情報を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="75f87-105">A JSON object representing the statistics for a hopper.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="75f87-106">HopperStatsResults JSON オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="75f87-106">The HopperStatsResults JSON object has the following specification.</span></span>
 
| <span data-ttu-id="75f87-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="75f87-107">Member</span></span>| <span data-ttu-id="75f87-108">種類</span><span class="sxs-lookup"><span data-stu-id="75f87-108">Type</span></span>| <span data-ttu-id="75f87-109">説明</span><span class="sxs-lookup"><span data-stu-id="75f87-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="75f87-110">hopperName</span><span class="sxs-lookup"><span data-stu-id="75f87-110">hopperName</span></span>| <span data-ttu-id="75f87-111">string</span><span class="sxs-lookup"><span data-stu-id="75f87-111">string</span></span>| <span data-ttu-id="75f87-112">選択したホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="75f87-112">The name of the selected hopper.</span></span>| 
| <span data-ttu-id="75f87-113">待機時間</span><span class="sxs-lookup"><span data-stu-id="75f87-113">waitTime</span></span>| <span data-ttu-id="75f87-114">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="75f87-114">32-bit signed integer</span></span>| <span data-ttu-id="75f87-115">照合時間 (秒の整数)、ホッパーの平均です。</span><span class="sxs-lookup"><span data-stu-id="75f87-115">Average matching time for the hopper (an integral number of seconds).</span></span> | 
| <span data-ttu-id="75f87-116">カタログの作成</span><span class="sxs-lookup"><span data-stu-id="75f87-116">population</span></span>| <span data-ttu-id="75f87-117">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="75f87-117">32-bit signed integer</span></span>| <span data-ttu-id="75f87-118">一致するものをホッパーで待機しているユーザーの数。</span><span class="sxs-lookup"><span data-stu-id="75f87-118">The number of people waiting for matches in the hopper.</span></span>| 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="75f87-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="75f87-119">Sample JSON syntax</span></span> 
 

```json
{
      "hopperName":"contosoawesome2",
      "waitTime":30,
      "population":1
    }
  
    
```

  
<a id="ID4EGB"></a>

 
## <a name="see-also"></a><span data-ttu-id="75f87-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="75f87-120">See also</span></span>
 
<a id="ID4EIB"></a>

 
##### <a name="parent"></a><span data-ttu-id="75f87-121">Parent</span><span class="sxs-lookup"><span data-stu-id="75f87-121">Parent</span></span> 

[<span data-ttu-id="75f87-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="75f87-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUB"></a>

 
##### <a name="reference"></a><span data-ttu-id="75f87-123">リファレンス</span><span class="sxs-lookup"><span data-stu-id="75f87-123">Reference</span></span> 

[<span data-ttu-id="75f87-124">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span><span class="sxs-lookup"><span data-stu-id="75f87-124">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span></span>](../uri/matchtickets/uri-serviceconfigsscidhoppershoppernamestatsget.md)

   