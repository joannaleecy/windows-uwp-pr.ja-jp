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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881883"
---
# <a name="hopperstatsresults-json"></a><span data-ttu-id="27a76-104">HopperStatsResults (JSON)</span><span class="sxs-lookup"><span data-stu-id="27a76-104">HopperStatsResults (JSON)</span></span>
<span data-ttu-id="27a76-105">ホッパーの統計情報を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="27a76-105">A JSON object representing the statistics for a hopper.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="27a76-106">HopperStatsResults JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="27a76-106">The HopperStatsResults JSON object has the following specification.</span></span>
 
| <span data-ttu-id="27a76-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="27a76-107">Member</span></span>| <span data-ttu-id="27a76-108">種類</span><span class="sxs-lookup"><span data-stu-id="27a76-108">Type</span></span>| <span data-ttu-id="27a76-109">説明</span><span class="sxs-lookup"><span data-stu-id="27a76-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="27a76-110">呼び出します</span><span class="sxs-lookup"><span data-stu-id="27a76-110">hopperName</span></span>| <span data-ttu-id="27a76-111">string</span><span class="sxs-lookup"><span data-stu-id="27a76-111">string</span></span>| <span data-ttu-id="27a76-112">選択したホッパーの名前です。</span><span class="sxs-lookup"><span data-stu-id="27a76-112">The name of the selected hopper.</span></span>| 
| <span data-ttu-id="27a76-113">待機時間</span><span class="sxs-lookup"><span data-stu-id="27a76-113">waitTime</span></span>| <span data-ttu-id="27a76-114">32 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="27a76-114">32-bit signed integer</span></span>| <span data-ttu-id="27a76-115">照合時間 (秒の整数)、ホッパーの平均です。</span><span class="sxs-lookup"><span data-stu-id="27a76-115">Average matching time for the hopper (an integral number of seconds).</span></span> | 
| <span data-ttu-id="27a76-116">高コスト</span><span class="sxs-lookup"><span data-stu-id="27a76-116">population</span></span>| <span data-ttu-id="27a76-117">32 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="27a76-117">32-bit signed integer</span></span>| <span data-ttu-id="27a76-118">ホッパーでマッチを待っているユーザーの数。</span><span class="sxs-lookup"><span data-stu-id="27a76-118">The number of people waiting for matches in the hopper.</span></span>| 
  
<a id="ID4EW"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="27a76-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="27a76-119">Sample JSON syntax</span></span> 
 

```json
{
      "hopperName":"contosoawesome2",
      "waitTime":30,
      "population":1
    }
  
    
```

  
<a id="ID4EGB"></a>

 
## <a name="see-also"></a><span data-ttu-id="27a76-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="27a76-120">See also</span></span>
 
<a id="ID4EIB"></a>

 
##### <a name="parent"></a><span data-ttu-id="27a76-121">Parent</span><span class="sxs-lookup"><span data-stu-id="27a76-121">Parent</span></span> 

[<span data-ttu-id="27a76-122">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="27a76-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUB"></a>

 
##### <a name="reference"></a><span data-ttu-id="27a76-123">リファレンス</span><span class="sxs-lookup"><span data-stu-id="27a76-123">Reference</span></span> 

[<span data-ttu-id="27a76-124">取得する (/serviceconfigs//hoppers/name {/統計)</span><span class="sxs-lookup"><span data-stu-id="27a76-124">GET (/serviceconfigs/{scid}/hoppers/{name}/stats)</span></span>](../uri/matchtickets/uri-serviceconfigsscidhoppershoppernamestatsget.md)

   