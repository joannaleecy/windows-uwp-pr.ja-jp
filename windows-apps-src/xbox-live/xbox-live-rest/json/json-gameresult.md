---
title: GameResult (JSON)
assetID: 43d863c0-2179-ae46-5d4a-2f08cd44b667
permalink: en-us/docs/xboxlive/rest/json-gameresult.html
description: " GameResult (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b408b1aaae5e6f54958a016575c4a2c37765f1e9
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8350752"
---
# <a name="gameresult-json"></a><span data-ttu-id="449ef-104">GameResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="449ef-104">GameResult (JSON)</span></span>
<span data-ttu-id="449ef-105">ゲーム セッションの結果を示すデータを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="449ef-105">A JSON object representing data that describes the results of a game session.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="449ef-106">GameResult JSON オブジェクトには、次のメンバーがあります。</span><span class="sxs-lookup"><span data-stu-id="449ef-106">The GameResult JSON object has the following members.</span></span>
 
| <span data-ttu-id="449ef-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="449ef-107">Member</span></span>| <span data-ttu-id="449ef-108">種類</span><span class="sxs-lookup"><span data-stu-id="449ef-108">Type</span></span>| <span data-ttu-id="449ef-109">説明</span><span class="sxs-lookup"><span data-stu-id="449ef-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="449ef-110">blob</span><span class="sxs-lookup"><span data-stu-id="449ef-110">blob</span></span>| <span data-ttu-id="449ef-111">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="449ef-111">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="449ef-112">タイトルに固有のカスタムの結果データです。</span><span class="sxs-lookup"><span data-stu-id="449ef-112">Custom title-specific result data.</span></span>| 
| <span data-ttu-id="449ef-113">結果</span><span class="sxs-lookup"><span data-stu-id="449ef-113">outcome</span></span>| <span data-ttu-id="449ef-114">string</span><span class="sxs-lookup"><span data-stu-id="449ef-114">string</span></span>| <span data-ttu-id="449ef-115">ゲーム セッションにプレイヤーの参加の結果。</span><span class="sxs-lookup"><span data-stu-id="449ef-115">The outcome of the player's participation in the game session.</span></span> <span data-ttu-id="449ef-116">有効な値は、"Win"、"Loss"または「結び付けられて」はします。</span><span class="sxs-lookup"><span data-stu-id="449ef-116">Valid values are "Win", "Loss", or "Tie".</span></span> | 
| <span data-ttu-id="449ef-117">スコア</span><span class="sxs-lookup"><span data-stu-id="449ef-117">score</span></span>| <span data-ttu-id="449ef-118">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="449ef-118">64-bit signed integer</span></span>| <span data-ttu-id="449ef-119">プレイヤーがゲーム セッションで受信スコアです。</span><span class="sxs-lookup"><span data-stu-id="449ef-119">The score that the player received in the game session.</span></span>| 
| <span data-ttu-id="449ef-120">time</span><span class="sxs-lookup"><span data-stu-id="449ef-120">time</span></span>| <span data-ttu-id="449ef-121">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="449ef-121">64-bit signed integer</span></span>| <span data-ttu-id="449ef-122">ゲーム セッションのプレイヤーの時間。</span><span class="sxs-lookup"><span data-stu-id="449ef-122">The player's time for the game session.</span></span>| 
| <span data-ttu-id="449ef-123">xuid</span><span class="sxs-lookup"><span data-stu-id="449ef-123">xuid</span></span>| <span data-ttu-id="449ef-124">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="449ef-124">64-bit unsigned integer</span></span>| <span data-ttu-id="449ef-125">結果の適用先のプレイヤーの Xbox ユーザー ID。</span><span class="sxs-lookup"><span data-stu-id="449ef-125">The Xbox user ID of the player to whom the results apply.</span></span>| 
  
<a id="ID4EPC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="449ef-126">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="449ef-126">Sample JSON syntax</span></span>
 

```json
{
   "xuid": 2533274790412952,
   "outcome": "Win",
   "score": 100
}
    
```

  
<a id="ID4EYC"></a>

 
## <a name="see-also"></a><span data-ttu-id="449ef-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="449ef-127">See also</span></span>
 
<a id="ID4E1C"></a>

 
##### <a name="parent"></a><span data-ttu-id="449ef-128">Parent</span><span class="sxs-lookup"><span data-stu-id="449ef-128">Parent</span></span> 

[<span data-ttu-id="449ef-129">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="449ef-129">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   