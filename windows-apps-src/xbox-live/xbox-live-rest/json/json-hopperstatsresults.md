---
title: HopperStatsResults (JSON)
assetID: 91927da1-2e97-f7bc-ae62-7e0e9966b98e
permalink: en-us/docs/xboxlive/rest/json-hopperstatsresults.html
author: KevinAsgari
description: " HopperStatsResults (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 17b6bf856dd87abc72a000cb92724baf91452d73
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4206627"
---
# <a name="hopperstatsresults-json"></a><span data-ttu-id="8abf2-104">HopperStatsResults (JSON)</span><span class="sxs-lookup"><span data-stu-id="8abf2-104">HopperStatsResults (JSON)</span></span>
<span data-ttu-id="8abf2-105">ホッパーの統計情報を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="8abf2-105">A JSON object representing the statistics for a hopper.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="8abf2-106">HopperStatsResults JSON オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="8abf2-106">The HopperStatsResults JSON object has the following specification.</span></span>
 
| <span data-ttu-id="8abf2-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="8abf2-107">Member</span></span>| <span data-ttu-id="8abf2-108">種類</span><span class="sxs-lookup"><span data-stu-id="8abf2-108">Type</span></span>| <span data-ttu-id="8abf2-109">説明</span><span class="sxs-lookup"><span data-stu-id="8abf2-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8abf2-110">hopperName</span><span class="sxs-lookup"><span data-stu-id="8abf2-110">hopperName</span></span>| <span data-ttu-id="8abf2-111">string</span><span class="sxs-lookup"><span data-stu-id="8abf2-111">string</span></span>| <span data-ttu-id="8abf2-112">選択したホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="8abf2-112">The name of the selected hopper.</span></span>| 
| <span data-ttu-id="8abf2-113">待機時間</span><span class="sxs-lookup"><span data-stu-id="8abf2-113">waitTime</span></span>| <span data-ttu-id="8abf2-114">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8abf2-114">32-bit signed integer</span></span>| <span data-ttu-id="8abf2-115">照合時間 (秒の整数)、ホッパーの平均です。</span><span class="sxs-lookup"><span data-stu-id="8abf2-115">Average matching time for the hopper (an integral number of seconds).</span></span> | 
| <span data-ttu-id="8abf2-116">カタログの作成</span><span class="sxs-lookup"><span data-stu-id="8abf2-116">population</span></span>| <span data-ttu-id="8abf2-117">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="8abf2-117">32-bit signed integer</span></span>| <span data-ttu-id="8abf2-118">一致するものをホッパーで待機しているユーザーの数。</span><span class="sxs-lookup"><span data-stu-id="8abf2-118">The number of people waiting for matches in the hopper.</span></span>| 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="8abf2-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="8abf2-119">Sample JSON syntax</span></span> 
 

```json
{
      "hopperName":"contosoawesome2",
      "waitTime":30,
      "population":1
    }
  
    
```

  
<a id="ID4EGB"></a>

 
## <a name="see-also"></a><span data-ttu-id="8abf2-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="8abf2-120">See also</span></span>
 
<a id="ID4EIB"></a>

 
##### <a name="parent"></a><span data-ttu-id="8abf2-121">Parent</span><span class="sxs-lookup"><span data-stu-id="8abf2-121">Parent</span></span> 

[<span data-ttu-id="8abf2-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="8abf2-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUB"></a>

 
##### <a name="reference"></a><span data-ttu-id="8abf2-123">リファレンス</span><span class="sxs-lookup"><span data-stu-id="8abf2-123">Reference</span></span> 

[<span data-ttu-id="8abf2-124">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span><span class="sxs-lookup"><span data-stu-id="8abf2-124">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span></span>](../uri/matchtickets/uri-serviceconfigsscidhoppershoppernamestatsget.md)

   