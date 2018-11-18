---
title: Player (JSON)
assetID: eaf6d082-869b-d2d3-d548-5cef65e54541
permalink: en-us/docs/xboxlive/rest/json-player.html
author: KevinAsgari
description: " Player (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0454f364bf2612c88b8f212ba935872968ce2476
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7166756"
---
# <a name="player-json"></a><span data-ttu-id="496aa-104">Player (JSON)</span><span class="sxs-lookup"><span data-stu-id="496aa-104">Player (JSON)</span></span>
<span data-ttu-id="496aa-105">ゲーム セッションにプレイヤーのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="496aa-105">Contains data for a player in a game session.</span></span> 
<a id="ID4EN"></a>

 
## <a name="player"></a><span data-ttu-id="496aa-106">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="496aa-106">Player</span></span>
 
<span data-ttu-id="496aa-107">プレイヤー オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="496aa-107">The Player object has the following specification.</span></span>
 
| <span data-ttu-id="496aa-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="496aa-108">Member</span></span>| <span data-ttu-id="496aa-109">種類</span><span class="sxs-lookup"><span data-stu-id="496aa-109">Type</span></span>| <span data-ttu-id="496aa-110">説明</span><span class="sxs-lookup"><span data-stu-id="496aa-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="496aa-111">customData</span><span class="sxs-lookup"><span data-stu-id="496aa-111">customData</span></span>| <span data-ttu-id="496aa-112">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="496aa-112">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="496aa-113">Base64 1024 バイトは、ゲーム固有のプレイヤーのデータをエンコードします。</span><span class="sxs-lookup"><span data-stu-id="496aa-113">1024 bytes of Base64 encoded game-specific player data.</span></span> <span data-ttu-id="496aa-114">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="496aa-114">This value is opaque to the server.</span></span>| 
| <span data-ttu-id="496aa-115">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="496aa-115">gamertag</span></span>| <span data-ttu-id="496aa-116">string</span><span class="sxs-lookup"><span data-stu-id="496aa-116">string</span></span>| <span data-ttu-id="496aa-117">ゲーマータグ-は最大 15 文字、プレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="496aa-117">Gamertag—a maximum of 15 characters—of the player.</span></span> <span data-ttu-id="496aa-118">クライアントは、プレイヤーを識別するために、UI でこの値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="496aa-118">The client should use this value in the UI when identifying the player.</span></span> | 
| <span data-ttu-id="496aa-119">isCurrentlyInSession</span><span class="sxs-lookup"><span data-stu-id="496aa-119">isCurrentlyInSession</span></span>| <span data-ttu-id="496aa-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="496aa-120">Boolean value</span></span>| <span data-ttu-id="496aa-121">プレイヤーがセッションで現在使用されてまたはセッションを抜けたかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="496aa-121">Indicates if the player is currently in the session or left the session.</span></span>| 
| <span data-ttu-id="496aa-122">seatIndex</span><span class="sxs-lookup"><span data-stu-id="496aa-122">seatIndex</span></span>| <span data-ttu-id="496aa-123">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="496aa-123">32-bit signed integer</span></span>| <span data-ttu-id="496aa-124">セッション内のプレイヤーのインデックス。</span><span class="sxs-lookup"><span data-stu-id="496aa-124">The index of the player in the session.</span></span>| 
| <span data-ttu-id="496aa-125">xuid</span><span class="sxs-lookup"><span data-stu-id="496aa-125">xuid</span></span>| <span data-ttu-id="496aa-126">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="496aa-126">64-bit unsigned integer</span></span>| <span data-ttu-id="496aa-127">Xbox ユーザー ID (XUID) プレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="496aa-127">The Xbox User ID (XUID) of the player.</span></span>| 
  
<a id="ID4E3C"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="496aa-128">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="496aa-128">Sample JSON syntax</span></span>
 

```json
{
    "xuid": 2533274790412952,
    "gamertag":"MyTestUser",
    "seatindex": 3
    "customData":"AIHJ2?iE?/jiKE!l5S=T..."
    "isCurrentlyInSession":"true"
}
    
```

  
<a id="ID4EFD"></a>

 
## <a name="see-also"></a><span data-ttu-id="496aa-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="496aa-129">See also</span></span>
 
<a id="ID4EHD"></a>

 
##### <a name="parent"></a><span data-ttu-id="496aa-130">Parent</span><span class="sxs-lookup"><span data-stu-id="496aa-130">Parent</span></span> 

[<span data-ttu-id="496aa-131">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="496aa-131">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference"></a><span data-ttu-id="496aa-132">リファレンス</span><span class="sxs-lookup"><span data-stu-id="496aa-132">Reference</span></span> 

[<span data-ttu-id="496aa-133">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="496aa-133">GameSession (JSON)</span></span>](json-gamesession.md)

   