---
title: GameResult (JSON)
assetID: 43d863c0-2179-ae46-5d4a-2f08cd44b667
permalink: en-us/docs/xboxlive/rest/json-gameresult.html
author: KevinAsgari
description: " GameResult (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 24f5af1639f5348fe20c36c56c1301f723d832f7
ms.sourcegitcommit: 49aab071aa2bd88f1c165438ee7e5c854b3e4f61
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/09/2018
ms.locfileid: "4470298"
---
# <a name="gameresult-json"></a><span data-ttu-id="5979c-104">GameResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="5979c-104">GameResult (JSON)</span></span>
<span data-ttu-id="5979c-105">ゲーム セッションの結果を示すデータを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="5979c-105">A JSON object representing data that describes the results of a game session.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="5979c-106">GameResult JSON オブジェクトには、次のメンバーがあります。</span><span class="sxs-lookup"><span data-stu-id="5979c-106">The GameResult JSON object has the following members.</span></span>
 
| <span data-ttu-id="5979c-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="5979c-107">Member</span></span>| <span data-ttu-id="5979c-108">種類</span><span class="sxs-lookup"><span data-stu-id="5979c-108">Type</span></span>| <span data-ttu-id="5979c-109">説明</span><span class="sxs-lookup"><span data-stu-id="5979c-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5979c-110">blob</span><span class="sxs-lookup"><span data-stu-id="5979c-110">blob</span></span>| <span data-ttu-id="5979c-111">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="5979c-111">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="5979c-112">タイトルに固有のカスタムの結果データです。</span><span class="sxs-lookup"><span data-stu-id="5979c-112">Custom title-specific result data.</span></span>| 
| <span data-ttu-id="5979c-113">結果</span><span class="sxs-lookup"><span data-stu-id="5979c-113">outcome</span></span>| <span data-ttu-id="5979c-114">string</span><span class="sxs-lookup"><span data-stu-id="5979c-114">string</span></span>| <span data-ttu-id="5979c-115">ゲーム セッションにプレイヤーの参加の結果。</span><span class="sxs-lookup"><span data-stu-id="5979c-115">The outcome of the player's participation in the game session.</span></span> <span data-ttu-id="5979c-116">有効な値は"Win"、"Loss"または「結び付けられて」です。</span><span class="sxs-lookup"><span data-stu-id="5979c-116">Valid values are "Win", "Loss", or "Tie".</span></span> | 
| <span data-ttu-id="5979c-117">スコア</span><span class="sxs-lookup"><span data-stu-id="5979c-117">score</span></span>| <span data-ttu-id="5979c-118">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="5979c-118">64-bit signed integer</span></span>| <span data-ttu-id="5979c-119">プレイヤーがゲーム セッションで受信スコアです。</span><span class="sxs-lookup"><span data-stu-id="5979c-119">The score that the player received in the game session.</span></span>| 
| <span data-ttu-id="5979c-120">時間</span><span class="sxs-lookup"><span data-stu-id="5979c-120">time</span></span>| <span data-ttu-id="5979c-121">64 ビットの符号付き整数</span><span class="sxs-lookup"><span data-stu-id="5979c-121">64-bit signed integer</span></span>| <span data-ttu-id="5979c-122">ゲーム セッションのプレイヤーの時間。</span><span class="sxs-lookup"><span data-stu-id="5979c-122">The player's time for the game session.</span></span>| 
| <span data-ttu-id="5979c-123">xuid</span><span class="sxs-lookup"><span data-stu-id="5979c-123">xuid</span></span>| <span data-ttu-id="5979c-124">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="5979c-124">64-bit unsigned integer</span></span>| <span data-ttu-id="5979c-125">結果の適用先のプレイヤーの Xbox ユーザー ID です。</span><span class="sxs-lookup"><span data-stu-id="5979c-125">The Xbox user ID of the player to whom the results apply.</span></span>| 
  
<a id="ID4EPC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="5979c-126">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="5979c-126">Sample JSON syntax</span></span>
 

```json
{
   "xuid": 2533274790412952,
   "outcome": "Win",
   "score": 100
}
    
```

  
<a id="ID4EYC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5979c-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="5979c-127">See also</span></span>
 
<a id="ID4E1C"></a>

 
##### <a name="parent"></a><span data-ttu-id="5979c-128">Parent</span><span class="sxs-lookup"><span data-stu-id="5979c-128">Parent</span></span> 

[<span data-ttu-id="5979c-129">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="5979c-129">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   