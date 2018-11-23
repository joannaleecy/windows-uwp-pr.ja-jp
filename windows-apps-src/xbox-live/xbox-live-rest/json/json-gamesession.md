---
title: GameSession (JSON)
assetID: 325af9ae-a9a9-5b36-8342-1aff5aff01d1
permalink: en-us/docs/xboxlive/rest/json-gamesession.html
author: KevinAsgari
description: " GameSession (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a62dd48857ed9c7ba8601d5ca08179c6a32b0db5
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7574990"
---
# <a name="gamesession-json"></a><span data-ttu-id="69258-104">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="69258-104">GameSession (JSON)</span></span>
<span data-ttu-id="69258-105">マルチプレイヤー セッションのゲーム データを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="69258-105">A JSON object representing game data for a multiplayer session.</span></span> 
<a id="ID4ER"></a>

  
 
<span data-ttu-id="69258-106">GameSession JSON オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="69258-106">The GameSession JSON object has the following specification.</span></span>
 
| <span data-ttu-id="69258-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="69258-107">Member</span></span>| <span data-ttu-id="69258-108">種類</span><span class="sxs-lookup"><span data-stu-id="69258-108">Type</span></span>| <span data-ttu-id="69258-109">説明</span><span class="sxs-lookup"><span data-stu-id="69258-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="69258-110">creationTime</span><span class="sxs-lookup"><span data-stu-id="69258-110">creationTime</span></span>| <span data-ttu-id="69258-111">DateTime</span><span class="sxs-lookup"><span data-stu-id="69258-111">DateTime</span></span>| <span data-ttu-id="69258-112">日付と時刻とき、セッションが作成された、UTC でします。</span><span class="sxs-lookup"><span data-stu-id="69258-112">The date and time when the session was created, in UTC.</span></span> | 
| <span data-ttu-id="69258-113">customData</span><span class="sxs-lookup"><span data-stu-id="69258-113">customData</span></span>| <span data-ttu-id="69258-114">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="69258-114">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="69258-115">ゲーム固有のセッション データの 1024 バイトです。</span><span class="sxs-lookup"><span data-stu-id="69258-115">1024 bytes of game-specific session data.</span></span> <span data-ttu-id="69258-116">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="69258-116">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="69258-117">displayName</span><span class="sxs-lookup"><span data-stu-id="69258-117">displayName</span></span>| <span data-ttu-id="69258-118">string</span><span class="sxs-lookup"><span data-stu-id="69258-118">string</span></span>| <span data-ttu-id="69258-119">表示名ゲームのセッション 128 文字の最大長を持つ。</span><span class="sxs-lookup"><span data-stu-id="69258-119">The display name of the game session, with a maximum length of 128 characters.</span></span> <span data-ttu-id="69258-120">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="69258-120">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="69258-121">hasEnded</span><span class="sxs-lookup"><span data-stu-id="69258-121">hasEnded</span></span>| <span data-ttu-id="69258-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="69258-122">Boolean value</span></span>| <span data-ttu-id="69258-123">セッションが終了した場合は true、それ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="69258-123">True if the session has ended, and false otherwise.</span></span> <span data-ttu-id="69258-124">セッションへの提出からさらにデータを妨げて true マーク読み取り専用とゲーム セッションにこのフィールドを設定します。</span><span class="sxs-lookup"><span data-stu-id="69258-124">Setting this field to true marks the game session as read-only, preventing further data from being submitted to the session.</span></span> | 
| <span data-ttu-id="69258-125">閉じられても</span><span class="sxs-lookup"><span data-stu-id="69258-125">isClosed</span></span>| <span data-ttu-id="69258-126">ブール値</span><span class="sxs-lookup"><span data-stu-id="69258-126">Boolean value</span></span>| <span data-ttu-id="69258-127">セッションが閉じられていていない追加のプレイヤーは、追加、false それ以外の場合は true。</span><span class="sxs-lookup"><span data-stu-id="69258-127">True if the session is closed and no more players can be added, and false otherwise.</span></span> <span data-ttu-id="69258-128">この値が true の場合、セッションに参加する要求が拒否されます。</span><span class="sxs-lookup"><span data-stu-id="69258-128">If this value is true, requests to join the session are rejected.</span></span> | 
| <span data-ttu-id="69258-129">maxPlayers</span><span class="sxs-lookup"><span data-stu-id="69258-129">maxPlayers</span></span>| <span data-ttu-id="69258-130">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="69258-130">32-bit signed integer</span></span>| <span data-ttu-id="69258-131">セッションを同時にすることができるプレイヤーの最大数。</span><span class="sxs-lookup"><span data-stu-id="69258-131">Maximum number of players that can be in the session concurrently.</span></span> <span data-ttu-id="69258-132">値の範囲は、2 ~ 16 です。</span><span class="sxs-lookup"><span data-stu-id="69258-132">The range of values is 2-16.</span></span> <span data-ttu-id="69258-133">セッションにプレイヤーの最大数が含まれているとはさらにセッションに参加要求が拒否されます。</span><span class="sxs-lookup"><span data-stu-id="69258-133">Once the session contains the maximum number of players, further requests to join the session are rejected.</span></span> | 
| <span data-ttu-id="69258-134">playersCanBeRemovedBy</span><span class="sxs-lookup"><span data-stu-id="69258-134">playersCanBeRemovedBy</span></span>| <span data-ttu-id="69258-135">PlayerAcl</span><span class="sxs-lookup"><span data-stu-id="69258-135">PlayerAcl</span></span>| <span data-ttu-id="69258-136">その他のプレイヤーをセッションから削除が許可されているプレイヤーを示す値。</span><span class="sxs-lookup"><span data-stu-id="69258-136">A value that indicates the player who is allowed to remove other players from the session.</span></span> <span data-ttu-id="69258-137">設定可能な値は、取ります、Self AnyPlayer します。</span><span class="sxs-lookup"><span data-stu-id="69258-137">Possible values are NoOne, Self, and AnyPlayer.</span></span> | 
| <span data-ttu-id="69258-138">名簿</span><span class="sxs-lookup"><span data-stu-id="69258-138">roster</span></span>| <span data-ttu-id="69258-139">プレイヤー オブジェクトの配列</span><span class="sxs-lookup"><span data-stu-id="69258-139">array of player objects</span></span>| <span data-ttu-id="69258-140">セッション内のプレイヤーの配列です。</span><span class="sxs-lookup"><span data-stu-id="69258-140">An array of players in the session.</span></span> <span data-ttu-id="69258-141">名簿には、現在のプレイヤーとを離れたが、セッションで以前のプレイヤーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="69258-141">The roster contains current players and players who were previously in the session, but have left.</span></span> <span data-ttu-id="69258-142">名簿内のプレイヤーの順序は不変です。</span><span class="sxs-lookup"><span data-stu-id="69258-142">The order of players in the roster never changes.</span></span> <span data-ttu-id="69258-143">新しいプレイヤーは、配列の末尾に追加されます。</span><span class="sxs-lookup"><span data-stu-id="69258-143">New players are added to the end of the array.</span></span> | 
| <span data-ttu-id="69258-144">seatsAvailable</span><span class="sxs-lookup"><span data-stu-id="69258-144">seatsAvailable</span></span>| <span data-ttu-id="69258-145">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="69258-145">32-bit signed integer</span></span>| <span data-ttu-id="69258-146">まだ参加できるプレイヤーの最大数に達する前に、セッションのプレイヤーの数。</span><span class="sxs-lookup"><span data-stu-id="69258-146">The number of players who can still join the session before the maximum number of players is reached.</span></span> <span data-ttu-id="69258-147">この値は読み取り専用であり常に maxPlayers フィールドの値よりも少なくなります。</span><span class="sxs-lookup"><span data-stu-id="69258-147">This value is read-only, and is always less than the value of the maxPlayers field.</span></span> | 
| <span data-ttu-id="69258-148">sessionId</span><span class="sxs-lookup"><span data-stu-id="69258-148">sessionId</span></span>| <span data-ttu-id="69258-149">string</span><span class="sxs-lookup"><span data-stu-id="69258-149">string</span></span>| <span data-ttu-id="69258-150">セッションが作成されると、MPSD によって割り当てられているセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="69258-150">The session ID assigned by the MPSD when the session is created.</span></span> <span data-ttu-id="69258-151">URI には、この値が、セッションに格納されている情報にアクセスする通常は含まれています。</span><span class="sxs-lookup"><span data-stu-id="69258-151">This value is usually included in the URI when accessing the information stored in a session.</span></span>| 
| <span data-ttu-id="69258-152">titleId</span><span class="sxs-lookup"><span data-stu-id="69258-152">titleId</span></span>| <span data-ttu-id="69258-153">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="69258-153">32-bit unsigned integer</span></span>| <span data-ttu-id="69258-154">ゲーム セッションの作成、タイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="69258-154">The ID of the title creating the game session.</span></span>| 
| <span data-ttu-id="69258-155">variant</span><span class="sxs-lookup"><span data-stu-id="69258-155">variant</span></span>| <span data-ttu-id="69258-156">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="69258-156">32-bit signed integer</span></span>| <span data-ttu-id="69258-157">ゲームのバリアントです。</span><span class="sxs-lookup"><span data-stu-id="69258-157">The game variant.</span></span> <span data-ttu-id="69258-158">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="69258-158">This value is opaque to the server.</span></span>| 
| <span data-ttu-id="69258-159">visibility</span><span class="sxs-lookup"><span data-stu-id="69258-159">visibility</span></span>| <span data-ttu-id="69258-160">VisibilityLevel</span><span class="sxs-lookup"><span data-stu-id="69258-160">VisibilityLevel</span></span>| <span data-ttu-id="69258-161">セッションの可視性を示す値。</span><span class="sxs-lookup"><span data-stu-id="69258-161">A value that indicates session visibility.</span></span> <span data-ttu-id="69258-162">使用可能な値: PlayersCurrentlyInSession、PlayersEverInSession、すべてのユーザーとします。</span><span class="sxs-lookup"><span data-stu-id="69258-162">Possible values are: PlayersCurrentlyInSession, PlayersEverInSession, and Everyone.</span></span>| 
  
<a id="ID4EEF"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="69258-163">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="69258-163">Sample JSON syntax</span></span>
 

```json
{
    "sessionId": "702e5aaf-e7bd-4a7c-abea-9dd4be10edec",
    "titleId": 1297287259,
    "variant": 1,
    "displayName": "Contoso Cards",
    "creationTime": "2011-06-23T17:13:06Z",
    "customData": null,
    "maxPlayers": 4,
    "seatsAvailable": 4,
    "isClosed": false,
    "hasEnded": false,
    "roster": [],
    "visibility": "PlayersCurrentlyInSession",
    "playersCanBeRemovedBy": "Self",
 }
    
```

  
<a id="ID4ENF"></a>

 
## <a name="see-also"></a><span data-ttu-id="69258-164">関連項目</span><span class="sxs-lookup"><span data-stu-id="69258-164">See also</span></span>
 
<a id="ID4EPF"></a>

 
##### <a name="parent"></a><span data-ttu-id="69258-165">Parent</span><span class="sxs-lookup"><span data-stu-id="69258-165">Parent</span></span> 

[<span data-ttu-id="69258-166">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="69258-166">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EZF"></a>

 
##### <a name="reference"></a><span data-ttu-id="69258-167">リファレンス</span><span class="sxs-lookup"><span data-stu-id="69258-167">Reference</span></span> 

[<span data-ttu-id="69258-168">GameMessage (JSON)</span><span class="sxs-lookup"><span data-stu-id="69258-168">GameMessage (JSON)</span></span>](json-gamemessage.md)

 [<span data-ttu-id="69258-169">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="69258-169">GameSessionSummary (JSON)</span></span>](json-gamesessionsummary.md)

 [<span data-ttu-id="69258-170">Player (JSON)</span><span class="sxs-lookup"><span data-stu-id="69258-170">Player (JSON)</span></span>](json-player.md)

   