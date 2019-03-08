---
title: GameSession (JSON)
assetID: 325af9ae-a9a9-5b36-8342-1aff5aff01d1
permalink: en-us/docs/xboxlive/rest/json-gamesession.html
description: " GameSession (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ca7276ccdc13d896d19873811b4fa9df9a831cd1
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646517"
---
# <a name="gamesession-json"></a><span data-ttu-id="237eb-104">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="237eb-104">GameSession (JSON)</span></span>
<span data-ttu-id="237eb-105">マルチ プレーヤーのセッションのゲーム データを表す JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="237eb-105">A JSON object representing game data for a multiplayer session.</span></span> 
<a id="ID4ER"></a>

  
 
<span data-ttu-id="237eb-106">GameSession JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="237eb-106">The GameSession JSON object has the following specification.</span></span>
 
| <span data-ttu-id="237eb-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="237eb-107">Member</span></span>| <span data-ttu-id="237eb-108">種類</span><span class="sxs-lookup"><span data-stu-id="237eb-108">Type</span></span>| <span data-ttu-id="237eb-109">説明</span><span class="sxs-lookup"><span data-stu-id="237eb-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="237eb-110">CreationTime</span><span class="sxs-lookup"><span data-stu-id="237eb-110">creationTime</span></span>| <span data-ttu-id="237eb-111">DateTime</span><span class="sxs-lookup"><span data-stu-id="237eb-111">DateTime</span></span>| <span data-ttu-id="237eb-112">日付と時刻 (utc)、セッションの作成時にします。</span><span class="sxs-lookup"><span data-stu-id="237eb-112">The date and time when the session was created, in UTC.</span></span> | 
| <span data-ttu-id="237eb-113">customData</span><span class="sxs-lookup"><span data-stu-id="237eb-113">customData</span></span>| <span data-ttu-id="237eb-114">8 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="237eb-114">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="237eb-115">ゲームに固有のセッション データの 1024 バイト数。</span><span class="sxs-lookup"><span data-stu-id="237eb-115">1024 bytes of game-specific session data.</span></span> <span data-ttu-id="237eb-116">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="237eb-116">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="237eb-117">displayName</span><span class="sxs-lookup"><span data-stu-id="237eb-117">displayName</span></span>| <span data-ttu-id="237eb-118">string</span><span class="sxs-lookup"><span data-stu-id="237eb-118">string</span></span>| <span data-ttu-id="237eb-119">表示ゲームの名前のセッション、最大長が 128 文字です。</span><span class="sxs-lookup"><span data-stu-id="237eb-119">The display name of the game session, with a maximum length of 128 characters.</span></span> <span data-ttu-id="237eb-120">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="237eb-120">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="237eb-121">hasEnded</span><span class="sxs-lookup"><span data-stu-id="237eb-121">hasEnded</span></span>| <span data-ttu-id="237eb-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="237eb-122">Boolean value</span></span>| <span data-ttu-id="237eb-123">セッションが終了した場合は true と false それ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="237eb-123">True if the session has ended, and false otherwise.</span></span> <span data-ttu-id="237eb-124">さらにデータがセッションに送信されていることを防ぐ場合は true。 マークとして読み取り専用のゲーム セッションにこのフィールドを設定します。</span><span class="sxs-lookup"><span data-stu-id="237eb-124">Setting this field to true marks the game session as read-only, preventing further data from being submitted to the session.</span></span> | 
| <span data-ttu-id="237eb-125">IsClosed</span><span class="sxs-lookup"><span data-stu-id="237eb-125">isClosed</span></span>| <span data-ttu-id="237eb-126">ブール値</span><span class="sxs-lookup"><span data-stu-id="237eb-126">Boolean value</span></span>| <span data-ttu-id="237eb-127">True の場合は、セッションが閉じられたでき、複数プレイヤー追加、および false それ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="237eb-127">True if the session is closed and no more players can be added, and false otherwise.</span></span> <span data-ttu-id="237eb-128">この値が true の場合は、セッションに参加する要求は拒否されます。</span><span class="sxs-lookup"><span data-stu-id="237eb-128">If this value is true, requests to join the session are rejected.</span></span> | 
| <span data-ttu-id="237eb-129">maxPlayers</span><span class="sxs-lookup"><span data-stu-id="237eb-129">maxPlayers</span></span>| <span data-ttu-id="237eb-130">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="237eb-130">32-bit signed integer</span></span>| <span data-ttu-id="237eb-131">セッションを同時にすることができるプレーヤーの最大数。</span><span class="sxs-lookup"><span data-stu-id="237eb-131">Maximum number of players that can be in the session concurrently.</span></span> <span data-ttu-id="237eb-132">値の範囲は、2 個から 16 です。</span><span class="sxs-lookup"><span data-stu-id="237eb-132">The range of values is 2-16.</span></span> <span data-ttu-id="237eb-133">セッションには、プレーヤーの最大数が含まれていますとさらに、セッションに参加する要求は拒否されます。</span><span class="sxs-lookup"><span data-stu-id="237eb-133">Once the session contains the maximum number of players, further requests to join the session are rejected.</span></span> | 
| <span data-ttu-id="237eb-134">playersCanBeRemovedBy</span><span class="sxs-lookup"><span data-stu-id="237eb-134">playersCanBeRemovedBy</span></span>| <span data-ttu-id="237eb-135">PlayerAcl</span><span class="sxs-lookup"><span data-stu-id="237eb-135">PlayerAcl</span></span>| <span data-ttu-id="237eb-136">その他のプレイヤーをセッションから削除を許可されているプレーヤーを示す値。</span><span class="sxs-lookup"><span data-stu-id="237eb-136">A value that indicates the player who is allowed to remove other players from the session.</span></span> <span data-ttu-id="237eb-137">指定できる値は取ります、Self、および AnyPlayer です。</span><span class="sxs-lookup"><span data-stu-id="237eb-137">Possible values are NoOne, Self, and AnyPlayer.</span></span> | 
| <span data-ttu-id="237eb-138">名簿</span><span class="sxs-lookup"><span data-stu-id="237eb-138">roster</span></span>| <span data-ttu-id="237eb-139">player オブジェクトの配列</span><span class="sxs-lookup"><span data-stu-id="237eb-139">array of player objects</span></span>| <span data-ttu-id="237eb-140">セッションのプレイヤーの配列。</span><span class="sxs-lookup"><span data-stu-id="237eb-140">An array of players in the session.</span></span> <span data-ttu-id="237eb-141">リストには、現在のプレーヤーとのセッションで以前が残っているプレイヤーが含まれています。</span><span class="sxs-lookup"><span data-stu-id="237eb-141">The roster contains current players and players who were previously in the session, but have left.</span></span> <span data-ttu-id="237eb-142">名簿のプレイヤーの順序は変更できません。</span><span class="sxs-lookup"><span data-stu-id="237eb-142">The order of players in the roster never changes.</span></span> <span data-ttu-id="237eb-143">新しいプレーヤーは、配列の末尾に追加されます。</span><span class="sxs-lookup"><span data-stu-id="237eb-143">New players are added to the end of the array.</span></span> | 
| <span data-ttu-id="237eb-144">seatsAvailable</span><span class="sxs-lookup"><span data-stu-id="237eb-144">seatsAvailable</span></span>| <span data-ttu-id="237eb-145">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="237eb-145">32-bit signed integer</span></span>| <span data-ttu-id="237eb-146">プレーヤーの最大数に達する前にセッションに参加できますも選手の数。</span><span class="sxs-lookup"><span data-stu-id="237eb-146">The number of players who can still join the session before the maximum number of players is reached.</span></span> <span data-ttu-id="237eb-147">この値は読み取り専用、常に maxPlayers フィールドの値より小さい。</span><span class="sxs-lookup"><span data-stu-id="237eb-147">This value is read-only, and is always less than the value of the maxPlayers field.</span></span> | 
| <span data-ttu-id="237eb-148">sessionId</span><span class="sxs-lookup"><span data-stu-id="237eb-148">sessionId</span></span>| <span data-ttu-id="237eb-149">string</span><span class="sxs-lookup"><span data-stu-id="237eb-149">string</span></span>| <span data-ttu-id="237eb-150">セッション ID、セッションが作成されたときに、MPSD によって割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="237eb-150">The session ID assigned by the MPSD when the session is created.</span></span> <span data-ttu-id="237eb-151">この値にがセッションに格納されている情報にアクセスするときに、URI に通常含まれて。</span><span class="sxs-lookup"><span data-stu-id="237eb-151">This value is usually included in the URI when accessing the information stored in a session.</span></span>| 
| <span data-ttu-id="237eb-152">titleId</span><span class="sxs-lookup"><span data-stu-id="237eb-152">titleId</span></span>| <span data-ttu-id="237eb-153">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="237eb-153">32-bit unsigned integer</span></span>| <span data-ttu-id="237eb-154">ゲーム セッションを作成するタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="237eb-154">The ID of the title creating the game session.</span></span>| 
| <span data-ttu-id="237eb-155">variant</span><span class="sxs-lookup"><span data-stu-id="237eb-155">variant</span></span>| <span data-ttu-id="237eb-156">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="237eb-156">32-bit signed integer</span></span>| <span data-ttu-id="237eb-157">ゲームのバリアント。</span><span class="sxs-lookup"><span data-stu-id="237eb-157">The game variant.</span></span> <span data-ttu-id="237eb-158">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="237eb-158">This value is opaque to the server.</span></span>| 
| <span data-ttu-id="237eb-159">visibility</span><span class="sxs-lookup"><span data-stu-id="237eb-159">visibility</span></span>| <span data-ttu-id="237eb-160">VisibilityLevel</span><span class="sxs-lookup"><span data-stu-id="237eb-160">VisibilityLevel</span></span>| <span data-ttu-id="237eb-161">セッションの可視性を示す値。</span><span class="sxs-lookup"><span data-stu-id="237eb-161">A value that indicates session visibility.</span></span> <span data-ttu-id="237eb-162">設定可能な値は、次のとおりです。PlayersCurrentlyInSession、PlayersEverInSession、およびそのすべてのユーザー。</span><span class="sxs-lookup"><span data-stu-id="237eb-162">Possible values are: PlayersCurrentlyInSession, PlayersEverInSession, and Everyone.</span></span>| 
  
<a id="ID4EEF"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="237eb-163">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="237eb-163">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="237eb-164">関連項目</span><span class="sxs-lookup"><span data-stu-id="237eb-164">See also</span></span>
 
<a id="ID4EPF"></a>

 
##### <a name="parent"></a><span data-ttu-id="237eb-165">Parent</span><span class="sxs-lookup"><span data-stu-id="237eb-165">Parent</span></span> 

[<span data-ttu-id="237eb-166">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="237eb-166">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EZF"></a>

 
##### <a name="reference"></a><span data-ttu-id="237eb-167">リファレンス</span><span class="sxs-lookup"><span data-stu-id="237eb-167">Reference</span></span> 

[<span data-ttu-id="237eb-168">GameMessage (JSON)</span><span class="sxs-lookup"><span data-stu-id="237eb-168">GameMessage (JSON)</span></span>](json-gamemessage.md)

 [<span data-ttu-id="237eb-169">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="237eb-169">GameSessionSummary (JSON)</span></span>](json-gamesessionsummary.md)

 [<span data-ttu-id="237eb-170">プレーヤー (JSON)</span><span class="sxs-lookup"><span data-stu-id="237eb-170">Player (JSON)</span></span>](json-player.md)

   