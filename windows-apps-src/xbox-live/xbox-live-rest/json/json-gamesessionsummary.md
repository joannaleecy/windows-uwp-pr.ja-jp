---
title: GameSessionSummary (JSON)
assetID: 50cf91ba-29d3-1260-7643-bcb3f8d74fc0
permalink: en-us/docs/xboxlive/rest/json-gamesessionsummary.html
description: " GameSessionSummary (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8dace19404ae7c8b1d1ef296a21c874e4dd14c6f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613387"
---
# <a name="gamesessionsummary-json"></a><span data-ttu-id="ce645-104">GameSessionSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="ce645-104">GameSessionSummary (JSON)</span></span>
<span data-ttu-id="ce645-105">ゲーム セッションの集計データを表す JSON オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="ce645-105">A JSON object representing summary data for a game session.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="ce645-106">GameSessionSummary JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="ce645-106">The GameSessionSummary JSON object has the following specification.</span></span>
 
| <span data-ttu-id="ce645-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="ce645-107">Member</span></span>| <span data-ttu-id="ce645-108">種類</span><span class="sxs-lookup"><span data-stu-id="ce645-108">Type</span></span>| <span data-ttu-id="ce645-109">説明</span><span class="sxs-lookup"><span data-stu-id="ce645-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ce645-110">CreationTime</span><span class="sxs-lookup"><span data-stu-id="ce645-110">creationTime</span></span>| <span data-ttu-id="ce645-111">DateTime</span><span class="sxs-lookup"><span data-stu-id="ce645-111">DateTime</span></span>| <span data-ttu-id="ce645-112">日付と時刻 (utc)、セッションの作成時にします。</span><span class="sxs-lookup"><span data-stu-id="ce645-112">The date and time when the session was created, in UTC.</span></span> | 
| <span data-ttu-id="ce645-113">customData</span><span class="sxs-lookup"><span data-stu-id="ce645-113">customData</span></span>| <span data-ttu-id="ce645-114">8 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="ce645-114">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="ce645-115">ゲームに固有のセッション データの 1024 バイト数。</span><span class="sxs-lookup"><span data-stu-id="ce645-115">1024 bytes of game-specific session data.</span></span> <span data-ttu-id="ce645-116">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="ce645-116">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="ce645-117">displayName</span><span class="sxs-lookup"><span data-stu-id="ce645-117">displayName</span></span>| <span data-ttu-id="ce645-118">string</span><span class="sxs-lookup"><span data-stu-id="ce645-118">string</span></span>| <span data-ttu-id="ce645-119">表示ゲームの名前のセッション、最大長が 128 文字です。</span><span class="sxs-lookup"><span data-stu-id="ce645-119">The display name of the game session, with a maximum length of 128 characters.</span></span> <span data-ttu-id="ce645-120">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="ce645-120">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="ce645-121">hasEnded</span><span class="sxs-lookup"><span data-stu-id="ce645-121">hasEnded</span></span>| <span data-ttu-id="ce645-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="ce645-122">Boolean value</span></span>| <span data-ttu-id="ce645-123">セッションが終了した場合は true と false それ以外の場合。</span><span class="sxs-lookup"><span data-stu-id="ce645-123">True if the session has ended, and false otherwise.</span></span> <span data-ttu-id="ce645-124">さらにデータがセッションに送信されていることを防ぐ場合は true。 マークとして読み取り専用のゲーム セッションにこのフィールドを設定します。</span><span class="sxs-lookup"><span data-stu-id="ce645-124">Setting this field to true marks the game session as read-only, preventing further data from being submitted to the session.</span></span> | 
| <span data-ttu-id="ce645-125">sessionId</span><span class="sxs-lookup"><span data-stu-id="ce645-125">sessionId</span></span>| <span data-ttu-id="ce645-126">文字列、セッション id。</span><span class="sxs-lookup"><span data-stu-id="ce645-126">string The session ID.</span></span> | 
| <span data-ttu-id="ce645-127">titleId</span><span class="sxs-lookup"><span data-stu-id="ce645-127">titleId</span></span>| <span data-ttu-id="ce645-128">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ce645-128">32-bit unsigned integer</span></span>| <span data-ttu-id="ce645-129">ゲーム セッションを作成するタイトルの ID。</span><span class="sxs-lookup"><span data-stu-id="ce645-129">The ID of the title creating the game session.</span></span>| 
| <span data-ttu-id="ce645-130">variant</span><span class="sxs-lookup"><span data-stu-id="ce645-130">variant</span></span>| <span data-ttu-id="ce645-131">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="ce645-131">32-bit signed integer</span></span>| <span data-ttu-id="ce645-132">ゲームのバリアント。</span><span class="sxs-lookup"><span data-stu-id="ce645-132">The game variant.</span></span> <span data-ttu-id="ce645-133">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="ce645-133">This value is opaque to the server.</span></span>| 
  
<a id="ID4EID"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="ce645-134">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="ce645-134">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="ce645-135">関連項目</span><span class="sxs-lookup"><span data-stu-id="ce645-135">See also</span></span>
 
<a id="ID4ETD"></a>

 
##### <a name="parent"></a><span data-ttu-id="ce645-136">Parent</span><span class="sxs-lookup"><span data-stu-id="ce645-136">Parent</span></span> 

[<span data-ttu-id="ce645-137">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="ce645-137">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E4D"></a>

 
##### <a name="reference"></a><span data-ttu-id="ce645-138">リファレンス</span><span class="sxs-lookup"><span data-stu-id="ce645-138">Reference</span></span> 

[<span data-ttu-id="ce645-139">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="ce645-139">GameSession (JSON)</span></span>](json-gamesession.md)

   