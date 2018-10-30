---
title: GameSessionSummary (JSON)
assetID: 50cf91ba-29d3-1260-7643-bcb3f8d74fc0
permalink: en-us/docs/xboxlive/rest/json-gamesessionsummary.html
author: KevinAsgari
description: " GameSessionSummary (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3e7f91062ca9bbc19bd56cfc2773aece95e7fc30
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5752313"
---
# <a name="gamesessionsummary-json"></a><span data-ttu-id="6caa0-104">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="6caa0-104">GameSessionSummary (JSON)</span></span>
<span data-ttu-id="6caa0-105">ゲーム セッションの集計データを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="6caa0-105">A JSON object representing summary data for a game session.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="6caa0-106">GameSessionSummary JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="6caa0-106">The GameSessionSummary JSON object has the following specification.</span></span>
 
| <span data-ttu-id="6caa0-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="6caa0-107">Member</span></span>| <span data-ttu-id="6caa0-108">種類</span><span class="sxs-lookup"><span data-stu-id="6caa0-108">Type</span></span>| <span data-ttu-id="6caa0-109">説明</span><span class="sxs-lookup"><span data-stu-id="6caa0-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6caa0-110">creationTime</span><span class="sxs-lookup"><span data-stu-id="6caa0-110">creationTime</span></span>| <span data-ttu-id="6caa0-111">DateTime</span><span class="sxs-lookup"><span data-stu-id="6caa0-111">DateTime</span></span>| <span data-ttu-id="6caa0-112">日付と、セッションが作成された、UTC で。</span><span class="sxs-lookup"><span data-stu-id="6caa0-112">The date and time when the session was created, in UTC.</span></span> | 
| <span data-ttu-id="6caa0-113">customData</span><span class="sxs-lookup"><span data-stu-id="6caa0-113">customData</span></span>| <span data-ttu-id="6caa0-114">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="6caa0-114">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="6caa0-115">ゲーム固有のセッション データの 1024 バイトです。</span><span class="sxs-lookup"><span data-stu-id="6caa0-115">1024 bytes of game-specific session data.</span></span> <span data-ttu-id="6caa0-116">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="6caa0-116">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="6caa0-117">displayName</span><span class="sxs-lookup"><span data-stu-id="6caa0-117">displayName</span></span>| <span data-ttu-id="6caa0-118">string</span><span class="sxs-lookup"><span data-stu-id="6caa0-118">string</span></span>| <span data-ttu-id="6caa0-119">表示名ゲームのセッション 128 文字の最大長を持つ。</span><span class="sxs-lookup"><span data-stu-id="6caa0-119">The display name of the game session, with a maximum length of 128 characters.</span></span> <span data-ttu-id="6caa0-120">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="6caa0-120">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="6caa0-121">hasEnded</span><span class="sxs-lookup"><span data-stu-id="6caa0-121">hasEnded</span></span>| <span data-ttu-id="6caa0-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="6caa0-122">Boolean value</span></span>| <span data-ttu-id="6caa0-123">セッションが終了した場合は true、それ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="6caa0-123">True if the session has ended, and false otherwise.</span></span> <span data-ttu-id="6caa0-124">さらにデータがセッションに送信されているように true マーク読み取り専用とゲーム セッションにこのフィールドを設定します。</span><span class="sxs-lookup"><span data-stu-id="6caa0-124">Setting this field to true marks the game session as read-only, preventing further data from being submitted to the session.</span></span> | 
| <span data-ttu-id="6caa0-125">sessionId</span><span class="sxs-lookup"><span data-stu-id="6caa0-125">sessionId</span></span>| <span data-ttu-id="6caa0-126">文字列セッション id。</span><span class="sxs-lookup"><span data-stu-id="6caa0-126">string The session ID.</span></span> | 
| <span data-ttu-id="6caa0-127">titleId</span><span class="sxs-lookup"><span data-stu-id="6caa0-127">titleId</span></span>| <span data-ttu-id="6caa0-128">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6caa0-128">32-bit unsigned integer</span></span>| <span data-ttu-id="6caa0-129">ゲーム セッションの作成、タイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="6caa0-129">The ID of the title creating the game session.</span></span>| 
| <span data-ttu-id="6caa0-130">variant</span><span class="sxs-lookup"><span data-stu-id="6caa0-130">variant</span></span>| <span data-ttu-id="6caa0-131">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="6caa0-131">32-bit signed integer</span></span>| <span data-ttu-id="6caa0-132">ゲームのバリアントです。</span><span class="sxs-lookup"><span data-stu-id="6caa0-132">The game variant.</span></span> <span data-ttu-id="6caa0-133">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="6caa0-133">This value is opaque to the server.</span></span>| 
  
<a id="ID4EID"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="6caa0-134">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="6caa0-134">Sample JSON syntax</span></span>
 

```json
{
    "sessionId": "702e5aaf-e7bd-4a7c-abea-9dd4be10edec",
    "titleId": 1297287259,
    "variant": 1,
    "displayName": "Contoso Cards",
    "creationTime": "2011-06-23T17:13:06Z",
    "customData": null,
    "hasEnded": false,
}
    
```

  
<a id="ID4ERD"></a>

 
## <a name="see-also"></a><span data-ttu-id="6caa0-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="6caa0-135">See also</span></span>
 
<a id="ID4ETD"></a>

 
##### <a name="parent"></a><span data-ttu-id="6caa0-136">Parent</span><span class="sxs-lookup"><span data-stu-id="6caa0-136">Parent</span></span> 

[<span data-ttu-id="6caa0-137">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="6caa0-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a><span data-ttu-id="6caa0-138">リファレンス</span><span class="sxs-lookup"><span data-stu-id="6caa0-138">Reference</span></span> 

[<span data-ttu-id="6caa0-139">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="6caa0-139">GameSession (JSON)</span></span>](json-gamesession.md)

   