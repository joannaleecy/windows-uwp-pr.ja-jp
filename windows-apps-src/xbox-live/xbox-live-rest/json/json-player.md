---
title: Player (JSON)
assetID: eaf6d082-869b-d2d3-d548-5cef65e54541
permalink: en-us/docs/xboxlive/rest/json-player.html
description: " Player (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a5967cbfecd47c5675926bd45939442c45dda7b6
ms.sourcegitcommit: a3dc929858415b933943bba5aa7487ffa721899f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/07/2018
ms.locfileid: "8782366"
---
# <a name="player-json"></a><span data-ttu-id="666c8-104">Player (JSON)</span><span class="sxs-lookup"><span data-stu-id="666c8-104">Player (JSON)</span></span>
<span data-ttu-id="666c8-105">ゲーム セッションにプレイヤーのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="666c8-105">Contains data for a player in a game session.</span></span> 
<a id="ID4EN"></a>

 
## <a name="player"></a><span data-ttu-id="666c8-106">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="666c8-106">Player</span></span>
 
<span data-ttu-id="666c8-107">プレイヤー オブジェクトでは、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="666c8-107">The Player object has the following specification.</span></span>
 
| <span data-ttu-id="666c8-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="666c8-108">Member</span></span>| <span data-ttu-id="666c8-109">種類</span><span class="sxs-lookup"><span data-stu-id="666c8-109">Type</span></span>| <span data-ttu-id="666c8-110">説明</span><span class="sxs-lookup"><span data-stu-id="666c8-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="666c8-111">customData</span><span class="sxs-lookup"><span data-stu-id="666c8-111">customData</span></span>| <span data-ttu-id="666c8-112">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="666c8-112">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="666c8-113">Base64 1024 バイトは、ゲーム固有のプレイヤーのデータをエンコードします。</span><span class="sxs-lookup"><span data-stu-id="666c8-113">1024 bytes of Base64 encoded game-specific player data.</span></span> <span data-ttu-id="666c8-114">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="666c8-114">This value is opaque to the server.</span></span>| 
| <span data-ttu-id="666c8-115">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="666c8-115">gamertag</span></span>| <span data-ttu-id="666c8-116">string</span><span class="sxs-lookup"><span data-stu-id="666c8-116">string</span></span>| <span data-ttu-id="666c8-117">ゲーマータグ-は最大 15 文字、プレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="666c8-117">Gamertag—a maximum of 15 characters—of the player.</span></span> <span data-ttu-id="666c8-118">クライアントは、プレイヤーを識別するために、UI でこの値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="666c8-118">The client should use this value in the UI when identifying the player.</span></span> | 
| <span data-ttu-id="666c8-119">isCurrentlyInSession</span><span class="sxs-lookup"><span data-stu-id="666c8-119">isCurrentlyInSession</span></span>| <span data-ttu-id="666c8-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="666c8-120">Boolean value</span></span>| <span data-ttu-id="666c8-121">プレイヤーがセッションで現在使用されてまたはセッションを抜けたかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="666c8-121">Indicates if the player is currently in the session or left the session.</span></span>| 
| <span data-ttu-id="666c8-122">seatIndex</span><span class="sxs-lookup"><span data-stu-id="666c8-122">seatIndex</span></span>| <span data-ttu-id="666c8-123">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="666c8-123">32-bit signed integer</span></span>| <span data-ttu-id="666c8-124">セッションにプレイヤーのインデックス。</span><span class="sxs-lookup"><span data-stu-id="666c8-124">The index of the player in the session.</span></span>| 
| <span data-ttu-id="666c8-125">xuid</span><span class="sxs-lookup"><span data-stu-id="666c8-125">xuid</span></span>| <span data-ttu-id="666c8-126">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="666c8-126">64-bit unsigned integer</span></span>| <span data-ttu-id="666c8-127">Xbox ユーザー ID (XUID) プレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="666c8-127">The Xbox User ID (XUID) of the player.</span></span>| 
  
<a id="ID4E3C"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="666c8-128">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="666c8-128">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="666c8-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="666c8-129">See also</span></span>
 
<a id="ID4EHD"></a>

 
##### <a name="parent"></a><span data-ttu-id="666c8-130">Parent</span><span class="sxs-lookup"><span data-stu-id="666c8-130">Parent</span></span> 

[<span data-ttu-id="666c8-131">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="666c8-131">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference"></a><span data-ttu-id="666c8-132">リファレンス</span><span class="sxs-lookup"><span data-stu-id="666c8-132">Reference</span></span> 

[<span data-ttu-id="666c8-133">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="666c8-133">GameSession (JSON)</span></span>](json-gamesession.md)

   