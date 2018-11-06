---
title: GameMessage (JSON)
assetID: c11606e6-701f-5807-4aef-5608c98ad831
permalink: en-us/docs/xboxlive/rest/json-gamemessage.html
author: KevinAsgari
description: " GameMessage (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f8d04b0487c7b42becd9a899c3532a6e5221f22e
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6022667"
---
# <a name="gamemessage-json"></a><span data-ttu-id="68198-104">GameMessage (JSON)</span><span class="sxs-lookup"><span data-stu-id="68198-104">GameMessage (JSON)</span></span>
<span data-ttu-id="68198-105">ゲーム セッションのメッセージ キューにメッセージのデータを定義する JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="68198-105">A JSON object defining data for a message in a game session's message queue.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="68198-106">GameMessage JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="68198-106">The GameMessage JSON object has the following specification.</span></span>
 
| <span data-ttu-id="68198-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="68198-107">Member</span></span>| <span data-ttu-id="68198-108">種類</span><span class="sxs-lookup"><span data-stu-id="68198-108">Type</span></span>| <span data-ttu-id="68198-109">説明</span><span class="sxs-lookup"><span data-stu-id="68198-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="68198-110">data</span><span class="sxs-lookup"><span data-stu-id="68198-110">data</span></span>| <span data-ttu-id="68198-111">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="68198-111">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="68198-112">ゲームのクライアントが他のゲームのクライアントに送信する必要がある Base64 でエンコードされたデータ。</span><span class="sxs-lookup"><span data-stu-id="68198-112">The Base64-encoded data that the game client wants to send to the other game clients.</span></span> <span data-ttu-id="68198-113">この値は、サーバーに不透明です。</span><span class="sxs-lookup"><span data-stu-id="68198-113">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="68198-114">senderXuid</span><span class="sxs-lookup"><span data-stu-id="68198-114">senderXuid</span></span>| <span data-ttu-id="68198-115">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="68198-115">64-bit unsigned integer</span></span>| <span data-ttu-id="68198-116">メッセージの送信、プレイヤーの Xbox ユーザー ID です。</span><span class="sxs-lookup"><span data-stu-id="68198-116">The Xbox user ID of the player sending the message.</span></span> | 
| <span data-ttu-id="68198-117">シーケンス番号</span><span class="sxs-lookup"><span data-stu-id="68198-117">sequenceNumber</span></span>| <span data-ttu-id="68198-118">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="68198-118">32-bit signed integer</span></span>| <span data-ttu-id="68198-119">ゲームのメッセージのシーケンス番号。</span><span class="sxs-lookup"><span data-stu-id="68198-119">The sequence number of the game message.</span></span> <span data-ttu-id="68198-120">この値は、サーバーが割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="68198-120">This value is assigned by the server.</span></span> <span data-ttu-id="68198-121">シーケンス番号を単調に増加することが保証連続することができない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="68198-121">Sequence numbers are guaranteed to be monotonically increasing, but might not be consecutive.</span></span> <span data-ttu-id="68198-122">シーケンス番号が一意がメッセージ キュー間ではなく、メッセージ キュー内でします。</span><span class="sxs-lookup"><span data-stu-id="68198-122">Sequence numbers are unique within a message queue, but not between message queues.</span></span> | 
| <span data-ttu-id="68198-123">queueIndex</span><span class="sxs-lookup"><span data-stu-id="68198-123">queueIndex</span></span>| <span data-ttu-id="68198-124">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="68198-124">32-bit signed integer</span></span>| <span data-ttu-id="68198-125">メッセージのセッション メッセージ キューのインデックス。</span><span class="sxs-lookup"><span data-stu-id="68198-125">The index of the session message queue for the message.</span></span> <span data-ttu-id="68198-126">設定可能な値は、0 ~ 3 です。</span><span class="sxs-lookup"><span data-stu-id="68198-126">Possible values are 0-3.</span></span>| 
| <span data-ttu-id="68198-127">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="68198-127">timeStamp</span></span>| <span data-ttu-id="68198-128">DateTime</span><span class="sxs-lookup"><span data-stu-id="68198-128">DateTime</span></span>| <span data-ttu-id="68198-129">サーバーは、UTC で、ゲームのメッセージをキューに作成されたときの時間。</span><span class="sxs-lookup"><span data-stu-id="68198-129">Time when the game message was created in the queue by the server, in UTC.</span></span> | 
  
<a id="ID4ERC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="68198-130">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="68198-130">Sample JSON syntax</span></span>
 

```json
{
    "queueIndex": 0,
    "sequenceNumber": 5,
    "senderXuid": 65536,
    "timestamp": "2011-06-23T18:49:50Z",
    "data": null
}
    
```

  
<a id="ID4E1C"></a>

 
## <a name="see-also"></a><span data-ttu-id="68198-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="68198-131">See also</span></span>
 
<a id="ID4E3C"></a>

 
##### <a name="parent"></a><span data-ttu-id="68198-132">Parent</span><span class="sxs-lookup"><span data-stu-id="68198-132">Parent</span></span> 

[<span data-ttu-id="68198-133">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="68198-133">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EGD"></a>

 
##### <a name="reference"></a><span data-ttu-id="68198-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="68198-134">Reference</span></span> 

[<span data-ttu-id="68198-135">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="68198-135">GameSession (JSON)</span></span>](json-gamesession.md)

   