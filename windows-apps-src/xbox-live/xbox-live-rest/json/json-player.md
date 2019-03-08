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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57622497"
---
# <a name="player-json"></a><span data-ttu-id="d61c0-104">Player (JSON)</span><span class="sxs-lookup"><span data-stu-id="d61c0-104">Player (JSON)</span></span>
<span data-ttu-id="d61c0-105">プレーヤーのゲームのセッションでデータを格納します。</span><span class="sxs-lookup"><span data-stu-id="d61c0-105">Contains data for a player in a game session.</span></span> 
<a id="ID4EN"></a>

 
## <a name="player"></a><span data-ttu-id="d61c0-106">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="d61c0-106">Player</span></span>
 
<span data-ttu-id="d61c0-107">Player オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d61c0-107">The Player object has the following specification.</span></span>
 
| <span data-ttu-id="d61c0-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="d61c0-108">Member</span></span>| <span data-ttu-id="d61c0-109">種類</span><span class="sxs-lookup"><span data-stu-id="d61c0-109">Type</span></span>| <span data-ttu-id="d61c0-110">説明</span><span class="sxs-lookup"><span data-stu-id="d61c0-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d61c0-111">customData</span><span class="sxs-lookup"><span data-stu-id="d61c0-111">customData</span></span>| <span data-ttu-id="d61c0-112">8 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="d61c0-112">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="d61c0-113">プレーヤーのゲームに固有のデータを 1024 バイトの Base64 にエンコードされます。</span><span class="sxs-lookup"><span data-stu-id="d61c0-113">1024 bytes of Base64 encoded game-specific player data.</span></span> <span data-ttu-id="d61c0-114">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="d61c0-114">This value is opaque to the server.</span></span>| 
| <span data-ttu-id="d61c0-115">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="d61c0-115">gamertag</span></span>| <span data-ttu-id="d61c0-116">string</span><span class="sxs-lookup"><span data-stu-id="d61c0-116">string</span></span>| <span data-ttu-id="d61c0-117">ゲーマータグ — 15 文字の最大値-プレーヤーの。</span><span class="sxs-lookup"><span data-stu-id="d61c0-117">Gamertag—a maximum of 15 characters—of the player.</span></span> <span data-ttu-id="d61c0-118">クライアントは、プレーヤーを識別するときに、UI にこの値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d61c0-118">The client should use this value in the UI when identifying the player.</span></span> | 
| <span data-ttu-id="d61c0-119">isCurrentlyInSession</span><span class="sxs-lookup"><span data-stu-id="d61c0-119">isCurrentlyInSession</span></span>| <span data-ttu-id="d61c0-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="d61c0-120">Boolean value</span></span>| <span data-ttu-id="d61c0-121">プレーヤーをセッションで現在使用されて、セッションのままかを示します。</span><span class="sxs-lookup"><span data-stu-id="d61c0-121">Indicates if the player is currently in the session or left the session.</span></span>| 
| <span data-ttu-id="d61c0-122">seatIndex</span><span class="sxs-lookup"><span data-stu-id="d61c0-122">seatIndex</span></span>| <span data-ttu-id="d61c0-123">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="d61c0-123">32-bit signed integer</span></span>| <span data-ttu-id="d61c0-124">セッションでプレイヤーのインデックス。</span><span class="sxs-lookup"><span data-stu-id="d61c0-124">The index of the player in the session.</span></span>| 
| <span data-ttu-id="d61c0-125">xuid</span><span class="sxs-lookup"><span data-stu-id="d61c0-125">xuid</span></span>| <span data-ttu-id="d61c0-126">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d61c0-126">64-bit unsigned integer</span></span>| <span data-ttu-id="d61c0-127">Xbox ユーザー ID (XUID)、プレイヤーの。</span><span class="sxs-lookup"><span data-stu-id="d61c0-127">The Xbox User ID (XUID) of the player.</span></span>| 
  
<a id="ID4E3C"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d61c0-128">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="d61c0-128">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="d61c0-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="d61c0-129">See also</span></span>
 
<a id="ID4EHD"></a>

 
##### <a name="parent"></a><span data-ttu-id="d61c0-130">Parent</span><span class="sxs-lookup"><span data-stu-id="d61c0-130">Parent</span></span> 

[<span data-ttu-id="d61c0-131">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="d61c0-131">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference"></a><span data-ttu-id="d61c0-132">リファレンス</span><span class="sxs-lookup"><span data-stu-id="d61c0-132">Reference</span></span> 

[<span data-ttu-id="d61c0-133">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="d61c0-133">GameSession (JSON)</span></span>](json-gamesession.md)

   