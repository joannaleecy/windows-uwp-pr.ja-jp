---
title: GameSession (JSON)
assetID: 325af9ae-a9a9-5b36-8342-1aff5aff01d1
permalink: en-us/docs/xboxlive/rest/json-gamesession.html
author: KevinAsgari
description: " GameSession (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a0ed4b66c50baa89432f44d53e313f042138b7de
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3956501"
---
# <a name="gamesession-json"></a><span data-ttu-id="915ab-104">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="915ab-104">GameSession (JSON)</span></span>
<span data-ttu-id="915ab-105">マルチプレイヤー セッションのゲーム データを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="915ab-105">A JSON object representing game data for a multiplayer session.</span></span> 
<a id="ID4ER"></a>

  
 
<span data-ttu-id="915ab-106">GameSession JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="915ab-106">The GameSession JSON object has the following specification.</span></span>
 
| <span data-ttu-id="915ab-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="915ab-107">Member</span></span>| <span data-ttu-id="915ab-108">種類</span><span class="sxs-lookup"><span data-stu-id="915ab-108">Type</span></span>| <span data-ttu-id="915ab-109">説明</span><span class="sxs-lookup"><span data-stu-id="915ab-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="915ab-110">creationTime</span><span class="sxs-lookup"><span data-stu-id="915ab-110">creationTime</span></span>| <span data-ttu-id="915ab-111">DateTime</span><span class="sxs-lookup"><span data-stu-id="915ab-111">DateTime</span></span>| <span data-ttu-id="915ab-112">日付と、セッションが作成された、UTC で。</span><span class="sxs-lookup"><span data-stu-id="915ab-112">The date and time when the session was created, in UTC.</span></span> | 
| <span data-ttu-id="915ab-113">customData</span><span class="sxs-lookup"><span data-stu-id="915ab-113">customData</span></span>| <span data-ttu-id="915ab-114">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="915ab-114">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="915ab-115">ゲーム固有のセッション データの 1024 バイトです。</span><span class="sxs-lookup"><span data-stu-id="915ab-115">1024 bytes of game-specific session data.</span></span> <span data-ttu-id="915ab-116">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="915ab-116">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="915ab-117">displayName</span><span class="sxs-lookup"><span data-stu-id="915ab-117">displayName</span></span>| <span data-ttu-id="915ab-118">string</span><span class="sxs-lookup"><span data-stu-id="915ab-118">string</span></span>| <span data-ttu-id="915ab-119">表示名ゲームのセッション 128 文字の最大長。</span><span class="sxs-lookup"><span data-stu-id="915ab-119">The display name of the game session, with a maximum length of 128 characters.</span></span> <span data-ttu-id="915ab-120">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="915ab-120">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="915ab-121">hasEnded</span><span class="sxs-lookup"><span data-stu-id="915ab-121">hasEnded</span></span>| <span data-ttu-id="915ab-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="915ab-122">Boolean value</span></span>| <span data-ttu-id="915ab-123">セッションが終了した場合は true、それ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="915ab-123">True if the session has ended, and false otherwise.</span></span> <span data-ttu-id="915ab-124">さらにデータがセッションに送信されているように true マーク読み取り専用とゲーム セッションにこのフィールドを設定します。</span><span class="sxs-lookup"><span data-stu-id="915ab-124">Setting this field to true marks the game session as read-only, preventing further data from being submitted to the session.</span></span> | 
| <span data-ttu-id="915ab-125">閉じられても</span><span class="sxs-lookup"><span data-stu-id="915ab-125">isClosed</span></span>| <span data-ttu-id="915ab-126">ブール値</span><span class="sxs-lookup"><span data-stu-id="915ab-126">Boolean value</span></span>| <span data-ttu-id="915ab-127">True の場合、セッションが閉じられ、いない追加のプレイヤーは、追加、false そうでない場合。</span><span class="sxs-lookup"><span data-stu-id="915ab-127">True if the session is closed and no more players can be added, and false otherwise.</span></span> <span data-ttu-id="915ab-128">この値が true の場合、セッションへの参加要求が拒否されます。</span><span class="sxs-lookup"><span data-stu-id="915ab-128">If this value is true, requests to join the session are rejected.</span></span> | 
| <span data-ttu-id="915ab-129">maxPlayers</span><span class="sxs-lookup"><span data-stu-id="915ab-129">maxPlayers</span></span>| <span data-ttu-id="915ab-130">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="915ab-130">32-bit signed integer</span></span>| <span data-ttu-id="915ab-131">セッションを同時にすることができるプレイヤーの最大数。</span><span class="sxs-lookup"><span data-stu-id="915ab-131">Maximum number of players that can be in the session concurrently.</span></span> <span data-ttu-id="915ab-132">値の範囲は、2 ~ 16 です。</span><span class="sxs-lookup"><span data-stu-id="915ab-132">The range of values is 2-16.</span></span> <span data-ttu-id="915ab-133">セッションにプレイヤーの最大数が含まれているとさらに、セッションへの参加要求が拒否されます。</span><span class="sxs-lookup"><span data-stu-id="915ab-133">Once the session contains the maximum number of players, further requests to join the session are rejected.</span></span> | 
| <span data-ttu-id="915ab-134">playersCanBeRemovedBy</span><span class="sxs-lookup"><span data-stu-id="915ab-134">playersCanBeRemovedBy</span></span>| <span data-ttu-id="915ab-135">PlayerAcl</span><span class="sxs-lookup"><span data-stu-id="915ab-135">PlayerAcl</span></span>| <span data-ttu-id="915ab-136">その他のプレイヤーをセッションから削除が許可されているプレイヤーを示す値。</span><span class="sxs-lookup"><span data-stu-id="915ab-136">A value that indicates the player who is allowed to remove other players from the session.</span></span> <span data-ttu-id="915ab-137">設定可能な値は、取ります、Self AnyPlayer します。</span><span class="sxs-lookup"><span data-stu-id="915ab-137">Possible values are NoOne, Self, and AnyPlayer.</span></span> | 
| <span data-ttu-id="915ab-138">名簿</span><span class="sxs-lookup"><span data-stu-id="915ab-138">roster</span></span>| <span data-ttu-id="915ab-139">プレイヤー オブジェクトの配列</span><span class="sxs-lookup"><span data-stu-id="915ab-139">array of player objects</span></span>| <span data-ttu-id="915ab-140">セッション内のプレイヤーの配列です。</span><span class="sxs-lookup"><span data-stu-id="915ab-140">An array of players in the session.</span></span> <span data-ttu-id="915ab-141">名簿には、現在のプレイヤーとプレイヤーがセッションで以前が左が含まれています。</span><span class="sxs-lookup"><span data-stu-id="915ab-141">The roster contains current players and players who were previously in the session, but have left.</span></span> <span data-ttu-id="915ab-142">名簿内のプレイヤーの順序は不変です。</span><span class="sxs-lookup"><span data-stu-id="915ab-142">The order of players in the roster never changes.</span></span> <span data-ttu-id="915ab-143">新しいプレイヤーは、配列の末尾に追加されます。</span><span class="sxs-lookup"><span data-stu-id="915ab-143">New players are added to the end of the array.</span></span> | 
| <span data-ttu-id="915ab-144">seatsAvailable</span><span class="sxs-lookup"><span data-stu-id="915ab-144">seatsAvailable</span></span>| <span data-ttu-id="915ab-145">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="915ab-145">32-bit signed integer</span></span>| <span data-ttu-id="915ab-146">プレイヤーの最大数に達する前に、セッションがまだ参加するプレイヤーの数。</span><span class="sxs-lookup"><span data-stu-id="915ab-146">The number of players who can still join the session before the maximum number of players is reached.</span></span> <span data-ttu-id="915ab-147">この値は読み取り専用であり常に maxPlayers フィールドの値よりも少なくなります。</span><span class="sxs-lookup"><span data-stu-id="915ab-147">This value is read-only, and is always less than the value of the maxPlayers field.</span></span> | 
| <span data-ttu-id="915ab-148">sessionId</span><span class="sxs-lookup"><span data-stu-id="915ab-148">sessionId</span></span>| <span data-ttu-id="915ab-149">string</span><span class="sxs-lookup"><span data-stu-id="915ab-149">string</span></span>| <span data-ttu-id="915ab-150">セッションが作成されると、MPSD によって割り当てられているセッションの ID。</span><span class="sxs-lookup"><span data-stu-id="915ab-150">The session ID assigned by the MPSD when the session is created.</span></span> <span data-ttu-id="915ab-151">この値は、セッションに格納されている情報にアクセスするときに通常 URI に含められます。</span><span class="sxs-lookup"><span data-stu-id="915ab-151">This value is usually included in the URI when accessing the information stored in a session.</span></span>| 
| <span data-ttu-id="915ab-152">titleId</span><span class="sxs-lookup"><span data-stu-id="915ab-152">titleId</span></span>| <span data-ttu-id="915ab-153">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="915ab-153">32-bit unsigned integer</span></span>| <span data-ttu-id="915ab-154">ゲーム セッションの作成、タイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="915ab-154">The ID of the title creating the game session.</span></span>| 
| <span data-ttu-id="915ab-155">variant</span><span class="sxs-lookup"><span data-stu-id="915ab-155">variant</span></span>| <span data-ttu-id="915ab-156">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="915ab-156">32-bit signed integer</span></span>| <span data-ttu-id="915ab-157">ゲームのバリアントです。</span><span class="sxs-lookup"><span data-stu-id="915ab-157">The game variant.</span></span> <span data-ttu-id="915ab-158">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="915ab-158">This value is opaque to the server.</span></span>| 
| <span data-ttu-id="915ab-159">visibility</span><span class="sxs-lookup"><span data-stu-id="915ab-159">visibility</span></span>| <span data-ttu-id="915ab-160">VisibilityLevel</span><span class="sxs-lookup"><span data-stu-id="915ab-160">VisibilityLevel</span></span>| <span data-ttu-id="915ab-161">セッションの可視性を示す値。</span><span class="sxs-lookup"><span data-stu-id="915ab-161">A value that indicates session visibility.</span></span> <span data-ttu-id="915ab-162">使用可能な値: PlayersCurrentlyInSession、PlayersEverInSession、すべてのユーザーとします。</span><span class="sxs-lookup"><span data-stu-id="915ab-162">Possible values are: PlayersCurrentlyInSession, PlayersEverInSession, and Everyone.</span></span>| 
  
<a id="ID4EEF"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="915ab-163">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="915ab-163">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="915ab-164">関連項目</span><span class="sxs-lookup"><span data-stu-id="915ab-164">See also</span></span>
 
<a id="ID4EPF"></a>

 
##### <a name="parent"></a><span data-ttu-id="915ab-165">Parent</span><span class="sxs-lookup"><span data-stu-id="915ab-165">Parent</span></span> 

[<span data-ttu-id="915ab-166">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="915ab-166">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EZF"></a>

 
##### <a name="reference"></a><span data-ttu-id="915ab-167">リファレンス</span><span class="sxs-lookup"><span data-stu-id="915ab-167">Reference</span></span> 

[<span data-ttu-id="915ab-168">GameMessage (JSON)</span><span class="sxs-lookup"><span data-stu-id="915ab-168">GameMessage (JSON)</span></span>](json-gamemessage.md)

 [<span data-ttu-id="915ab-169">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="915ab-169">GameSessionSummary (JSON)</span></span>](json-gamesessionsummary.md)

 [<span data-ttu-id="915ab-170">プレイヤー (JSON)</span><span class="sxs-lookup"><span data-stu-id="915ab-170">Player (JSON)</span></span>](json-player.md)

   