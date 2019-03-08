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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57602337"
---
# <a name="gameresult-json"></a><span data-ttu-id="34587-104">GameResult (JSON)</span><span class="sxs-lookup"><span data-stu-id="34587-104">GameResult (JSON)</span></span>
<span data-ttu-id="34587-105">ゲーム セッションの結果を説明するデータを表す JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="34587-105">A JSON object representing data that describes the results of a game session.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="34587-106">GameResult JSON オブジェクトには、次のメンバーがあります。</span><span class="sxs-lookup"><span data-stu-id="34587-106">The GameResult JSON object has the following members.</span></span>
 
| <span data-ttu-id="34587-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="34587-107">Member</span></span>| <span data-ttu-id="34587-108">種類</span><span class="sxs-lookup"><span data-stu-id="34587-108">Type</span></span>| <span data-ttu-id="34587-109">説明</span><span class="sxs-lookup"><span data-stu-id="34587-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="34587-110">blob</span><span class="sxs-lookup"><span data-stu-id="34587-110">blob</span></span>| <span data-ttu-id="34587-111">8 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="34587-111">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="34587-112">カスタムのタイトルに固有の結果データです。</span><span class="sxs-lookup"><span data-stu-id="34587-112">Custom title-specific result data.</span></span>| 
| <span data-ttu-id="34587-113">結果</span><span class="sxs-lookup"><span data-stu-id="34587-113">outcome</span></span>| <span data-ttu-id="34587-114">string</span><span class="sxs-lookup"><span data-stu-id="34587-114">string</span></span>| <span data-ttu-id="34587-115">プレーヤーのゲーム セッションへの参加の結果。</span><span class="sxs-lookup"><span data-stu-id="34587-115">The outcome of the player's participation in the game session.</span></span> <span data-ttu-id="34587-116">有効な値は、"Win"、「損失」または「結び付ける」です。</span><span class="sxs-lookup"><span data-stu-id="34587-116">Valid values are "Win", "Loss", or "Tie".</span></span> | 
| <span data-ttu-id="34587-117">スコア</span><span class="sxs-lookup"><span data-stu-id="34587-117">score</span></span>| <span data-ttu-id="34587-118">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="34587-118">64-bit signed integer</span></span>| <span data-ttu-id="34587-119">プレーヤーがゲームのセッションで受信したスコアです。</span><span class="sxs-lookup"><span data-stu-id="34587-119">The score that the player received in the game session.</span></span>| 
| <span data-ttu-id="34587-120">time</span><span class="sxs-lookup"><span data-stu-id="34587-120">time</span></span>| <span data-ttu-id="34587-121">64 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="34587-121">64-bit signed integer</span></span>| <span data-ttu-id="34587-122">ゲームのセッションのプレイヤーの時間。</span><span class="sxs-lookup"><span data-stu-id="34587-122">The player's time for the game session.</span></span>| 
| <span data-ttu-id="34587-123">xuid</span><span class="sxs-lookup"><span data-stu-id="34587-123">xuid</span></span>| <span data-ttu-id="34587-124">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="34587-124">64-bit unsigned integer</span></span>| <span data-ttu-id="34587-125">結果を適用する、プレーヤーの Xbox ユーザー ID。</span><span class="sxs-lookup"><span data-stu-id="34587-125">The Xbox user ID of the player to whom the results apply.</span></span>| 
  
<a id="ID4EPC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="34587-126">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="34587-126">Sample JSON syntax</span></span>
 

```json
{
   "xuid": 2533274790412952,
   "outcome": "Win",
   "score": 100
}
    
```

  
<a id="ID4EYC"></a>

 
## <a name="see-also"></a><span data-ttu-id="34587-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="34587-127">See also</span></span>
 
<a id="ID4E1C"></a>

 
##### <a name="parent"></a><span data-ttu-id="34587-128">Parent</span><span class="sxs-lookup"><span data-stu-id="34587-128">Parent</span></span> 

[<span data-ttu-id="34587-129">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="34587-129">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   