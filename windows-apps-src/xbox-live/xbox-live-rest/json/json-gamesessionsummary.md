---
title: GameSessionSummary (JSON)
assetID: 50cf91ba-29d3-1260-7643-bcb3f8d74fc0
permalink: en-us/docs/xboxlive/rest/json-gamesessionsummary.html
author: KevinAsgari
description: " GameSessionSummary (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 610f771641352447f9d38fc4217231ba3230e6fb
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3986460"
---
# <a name="gamesessionsummary-json"></a><span data-ttu-id="f8780-104">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="f8780-104">GameSessionSummary (JSON)</span></span>
<span data-ttu-id="f8780-105">ゲーム セッションの集計データを表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f8780-105">A JSON object representing summary data for a game session.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="f8780-106">GameSessionSummary JSON オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f8780-106">The GameSessionSummary JSON object has the following specification.</span></span>
 
| <span data-ttu-id="f8780-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="f8780-107">Member</span></span>| <span data-ttu-id="f8780-108">種類</span><span class="sxs-lookup"><span data-stu-id="f8780-108">Type</span></span>| <span data-ttu-id="f8780-109">説明</span><span class="sxs-lookup"><span data-stu-id="f8780-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f8780-110">creationTime</span><span class="sxs-lookup"><span data-stu-id="f8780-110">creationTime</span></span>| <span data-ttu-id="f8780-111">DateTime</span><span class="sxs-lookup"><span data-stu-id="f8780-111">DateTime</span></span>| <span data-ttu-id="f8780-112">日付と、セッションが作成された、UTC でします。</span><span class="sxs-lookup"><span data-stu-id="f8780-112">The date and time when the session was created, in UTC.</span></span> | 
| <span data-ttu-id="f8780-113">customData</span><span class="sxs-lookup"><span data-stu-id="f8780-113">customData</span></span>| <span data-ttu-id="f8780-114">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="f8780-114">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="f8780-115">ゲーム固有のセッション データの 1024 バイトです。</span><span class="sxs-lookup"><span data-stu-id="f8780-115">1024 bytes of game-specific session data.</span></span> <span data-ttu-id="f8780-116">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="f8780-116">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="f8780-117">displayName</span><span class="sxs-lookup"><span data-stu-id="f8780-117">displayName</span></span>| <span data-ttu-id="f8780-118">string</span><span class="sxs-lookup"><span data-stu-id="f8780-118">string</span></span>| <span data-ttu-id="f8780-119">表示名ゲームのセッション 128 文字の最大長を持つ。</span><span class="sxs-lookup"><span data-stu-id="f8780-119">The display name of the game session, with a maximum length of 128 characters.</span></span> <span data-ttu-id="f8780-120">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="f8780-120">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="f8780-121">hasEnded</span><span class="sxs-lookup"><span data-stu-id="f8780-121">hasEnded</span></span>| <span data-ttu-id="f8780-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="f8780-122">Boolean value</span></span>| <span data-ttu-id="f8780-123">セッションが終了した場合は true、それ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="f8780-123">True if the session has ended, and false otherwise.</span></span> <span data-ttu-id="f8780-124">さらにデータがセッションに送信されているように true マーク読み取り専用とゲーム セッションにこのフィールドを設定します。</span><span class="sxs-lookup"><span data-stu-id="f8780-124">Setting this field to true marks the game session as read-only, preventing further data from being submitted to the session.</span></span> | 
| <span data-ttu-id="f8780-125">sessionId</span><span class="sxs-lookup"><span data-stu-id="f8780-125">sessionId</span></span>| <span data-ttu-id="f8780-126">文字列セッション id。</span><span class="sxs-lookup"><span data-stu-id="f8780-126">string The session ID.</span></span> | 
| <span data-ttu-id="f8780-127">titleId</span><span class="sxs-lookup"><span data-stu-id="f8780-127">titleId</span></span>| <span data-ttu-id="f8780-128">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f8780-128">32-bit unsigned integer</span></span>| <span data-ttu-id="f8780-129">ゲーム セッションの作成、タイトルの ID です。</span><span class="sxs-lookup"><span data-stu-id="f8780-129">The ID of the title creating the game session.</span></span>| 
| <span data-ttu-id="f8780-130">variant</span><span class="sxs-lookup"><span data-stu-id="f8780-130">variant</span></span>| <span data-ttu-id="f8780-131">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="f8780-131">32-bit signed integer</span></span>| <span data-ttu-id="f8780-132">ゲームのバリアントです。</span><span class="sxs-lookup"><span data-stu-id="f8780-132">The game variant.</span></span> <span data-ttu-id="f8780-133">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="f8780-133">This value is opaque to the server.</span></span>| 
  
<a id="ID4EID"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="f8780-134">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="f8780-134">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="f8780-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="f8780-135">See also</span></span>
 
<a id="ID4ETD"></a>

 
##### <a name="parent"></a><span data-ttu-id="f8780-136">Parent</span><span class="sxs-lookup"><span data-stu-id="f8780-136">Parent</span></span> 

[<span data-ttu-id="f8780-137">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f8780-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a><span data-ttu-id="f8780-138">リファレンス</span><span class="sxs-lookup"><span data-stu-id="f8780-138">Reference</span></span> 

[<span data-ttu-id="f8780-139">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="f8780-139">GameSession (JSON)</span></span>](json-gamesession.md)

   