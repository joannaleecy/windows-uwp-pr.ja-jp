---
title: プレイヤー (JSON)
assetID: eaf6d082-869b-d2d3-d548-5cef65e54541
permalink: en-us/docs/xboxlive/rest/json-player.html
author: KevinAsgari
description: " プレイヤー (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 25d9262ac16eab3d1c2f35960445321fa3872c30
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3928765"
---
# <a name="player-json"></a><span data-ttu-id="d0fde-104">プレイヤー (JSON)</span><span class="sxs-lookup"><span data-stu-id="d0fde-104">Player (JSON)</span></span>
<span data-ttu-id="d0fde-105">ゲーム セッションにプレイヤーのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d0fde-105">Contains data for a player in a game session.</span></span> 
<a id="ID4EN"></a>

 
## <a name="player"></a><span data-ttu-id="d0fde-106">プレイヤー</span><span class="sxs-lookup"><span data-stu-id="d0fde-106">Player</span></span>
 
<span data-ttu-id="d0fde-107">プレイヤー オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d0fde-107">The Player object has the following specification.</span></span>
 
| <span data-ttu-id="d0fde-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="d0fde-108">Member</span></span>| <span data-ttu-id="d0fde-109">種類</span><span class="sxs-lookup"><span data-stu-id="d0fde-109">Type</span></span>| <span data-ttu-id="d0fde-110">説明</span><span class="sxs-lookup"><span data-stu-id="d0fde-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d0fde-111">customData</span><span class="sxs-lookup"><span data-stu-id="d0fde-111">customData</span></span>| <span data-ttu-id="d0fde-112">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="d0fde-112">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="d0fde-113">Base64 1024 バイトは、ゲーム固有のプレイヤーのデータをエンコードします。</span><span class="sxs-lookup"><span data-stu-id="d0fde-113">1024 bytes of Base64 encoded game-specific player data.</span></span> <span data-ttu-id="d0fde-114">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="d0fde-114">This value is opaque to the server.</span></span>| 
| <span data-ttu-id="d0fde-115">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="d0fde-115">gamertag</span></span>| <span data-ttu-id="d0fde-116">string</span><span class="sxs-lookup"><span data-stu-id="d0fde-116">string</span></span>| <span data-ttu-id="d0fde-117">ゲーマータグ-は最大 15 文字、プレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="d0fde-117">Gamertag—a maximum of 15 characters—of the player.</span></span> <span data-ttu-id="d0fde-118">クライアントは、プレイヤーを識別するため、UI でこの値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d0fde-118">The client should use this value in the UI when identifying the player.</span></span> | 
| <span data-ttu-id="d0fde-119">isCurrentlyInSession</span><span class="sxs-lookup"><span data-stu-id="d0fde-119">isCurrentlyInSession</span></span>| <span data-ttu-id="d0fde-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="d0fde-120">Boolean value</span></span>| <span data-ttu-id="d0fde-121">プレイヤーがセッションで現在使用されてか、セッションを抜けたかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="d0fde-121">Indicates if the player is currently in the session or left the session.</span></span>| 
| <span data-ttu-id="d0fde-122">seatIndex</span><span class="sxs-lookup"><span data-stu-id="d0fde-122">seatIndex</span></span>| <span data-ttu-id="d0fde-123">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="d0fde-123">32-bit signed integer</span></span>| <span data-ttu-id="d0fde-124">セッションにプレイヤーのインデックス。</span><span class="sxs-lookup"><span data-stu-id="d0fde-124">The index of the player in the session.</span></span>| 
| <span data-ttu-id="d0fde-125">xuid</span><span class="sxs-lookup"><span data-stu-id="d0fde-125">xuid</span></span>| <span data-ttu-id="d0fde-126">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d0fde-126">64-bit unsigned integer</span></span>| <span data-ttu-id="d0fde-127">Xbox ユーザー ID (XUID) プレイヤーのします。</span><span class="sxs-lookup"><span data-stu-id="d0fde-127">The Xbox User ID (XUID) of the player.</span></span>| 
  
<a id="ID4E3C"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d0fde-128">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d0fde-128">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="d0fde-129">関連項目</span><span class="sxs-lookup"><span data-stu-id="d0fde-129">See also</span></span>
 
<a id="ID4EHD"></a>

 
##### <a name="parent"></a><span data-ttu-id="d0fde-130">Parent</span><span class="sxs-lookup"><span data-stu-id="d0fde-130">Parent</span></span> 

[<span data-ttu-id="d0fde-131">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d0fde-131">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ERD"></a>

 
##### <a name="reference"></a><span data-ttu-id="d0fde-132">リファレンス</span><span class="sxs-lookup"><span data-stu-id="d0fde-132">Reference</span></span> 

[<span data-ttu-id="d0fde-133">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="d0fde-133">GameSession (JSON)</span></span>](json-gamesession.md)

   