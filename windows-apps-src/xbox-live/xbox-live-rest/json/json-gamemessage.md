---
title: GameMessage (JSON)
assetID: c11606e6-701f-5807-4aef-5608c98ad831
permalink: en-us/docs/xboxlive/rest/json-gamemessage.html
description: " GameMessage (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a2bddd9e26b4716fd1e33c4b5bbde56672b5d3f8
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651297"
---
# <a name="gamemessage-json"></a><span data-ttu-id="3b0dd-104">GameMessage (JSON)</span><span class="sxs-lookup"><span data-stu-id="3b0dd-104">GameMessage (JSON)</span></span>
<span data-ttu-id="3b0dd-105">ゲーム セッションのメッセージ キューでメッセージのデータを定義する JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-105">A JSON object defining data for a message in a game session's message queue.</span></span> 
<a id="ID4EN"></a>

  
 
<span data-ttu-id="3b0dd-106">GameMessage JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-106">The GameMessage JSON object has the following specification.</span></span>
 
| <span data-ttu-id="3b0dd-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="3b0dd-107">Member</span></span>| <span data-ttu-id="3b0dd-108">種類</span><span class="sxs-lookup"><span data-stu-id="3b0dd-108">Type</span></span>| <span data-ttu-id="3b0dd-109">説明</span><span class="sxs-lookup"><span data-stu-id="3b0dd-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="3b0dd-110">データ</span><span class="sxs-lookup"><span data-stu-id="3b0dd-110">data</span></span>| <span data-ttu-id="3b0dd-111">8 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="3b0dd-111">array of 8-bit unsigned integers</span></span>| <span data-ttu-id="3b0dd-112">ゲームのクライアントが他のゲームのクライアントに送信する必要がある Base64 でエンコードされたデータ。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-112">The Base64-encoded data that the game client wants to send to the other game clients.</span></span> <span data-ttu-id="3b0dd-113">この値は、サーバーに対して非透過的です。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-113">This value is opaque to the server.</span></span> | 
| <span data-ttu-id="3b0dd-114">senderXuid</span><span class="sxs-lookup"><span data-stu-id="3b0dd-114">senderXuid</span></span>| <span data-ttu-id="3b0dd-115">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="3b0dd-115">64-bit unsigned integer</span></span>| <span data-ttu-id="3b0dd-116">メッセージを送信する、プレーヤーの Xbox ユーザー ID。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-116">The Xbox user ID of the player sending the message.</span></span> | 
| <span data-ttu-id="3b0dd-117">SequenceNumber</span><span class="sxs-lookup"><span data-stu-id="3b0dd-117">sequenceNumber</span></span>| <span data-ttu-id="3b0dd-118">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="3b0dd-118">32-bit signed integer</span></span>| <span data-ttu-id="3b0dd-119">ゲームのメッセージのシーケンス番号。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-119">The sequence number of the game message.</span></span> <span data-ttu-id="3b0dd-120">この値は、サーバーによって割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-120">This value is assigned by the server.</span></span> <span data-ttu-id="3b0dd-121">シーケンス番号を単調に増加することが保証されますが、連続することができない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-121">Sequence numbers are guaranteed to be monotonically increasing, but might not be consecutive.</span></span> <span data-ttu-id="3b0dd-122">シーケンス番号が一意のメッセージ キュー間ではなくが、メッセージ キュー内で。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-122">Sequence numbers are unique within a message queue, but not between message queues.</span></span> | 
| <span data-ttu-id="3b0dd-123">queueIndex</span><span class="sxs-lookup"><span data-stu-id="3b0dd-123">queueIndex</span></span>| <span data-ttu-id="3b0dd-124">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="3b0dd-124">32-bit signed integer</span></span>| <span data-ttu-id="3b0dd-125">メッセージのセッションのメッセージ キューのインデックス。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-125">The index of the session message queue for the message.</span></span> <span data-ttu-id="3b0dd-126">使用可能な値は、0 ~ 3 です。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-126">Possible values are 0-3.</span></span>| 
| <span data-ttu-id="3b0dd-127">タイムスタンプ</span><span class="sxs-lookup"><span data-stu-id="3b0dd-127">timeStamp</span></span>| <span data-ttu-id="3b0dd-128">DateTime</span><span class="sxs-lookup"><span data-stu-id="3b0dd-128">DateTime</span></span>| <span data-ttu-id="3b0dd-129">時刻 (utc)、サーバーによって、ゲームのメッセージのキューの作成時にします。</span><span class="sxs-lookup"><span data-stu-id="3b0dd-129">Time when the game message was created in the queue by the server, in UTC.</span></span> | 
  
<a id="ID4ERC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="3b0dd-130">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="3b0dd-130">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="3b0dd-131">関連項目</span><span class="sxs-lookup"><span data-stu-id="3b0dd-131">See also</span></span>
 
<a id="ID4E3C"></a>

 
##### <a name="parent"></a><span data-ttu-id="3b0dd-132">Parent</span><span class="sxs-lookup"><span data-stu-id="3b0dd-132">Parent</span></span> 

[<span data-ttu-id="3b0dd-133">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="3b0dd-133">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EGD"></a>

 
##### <a name="reference"></a><span data-ttu-id="3b0dd-134">リファレンス</span><span class="sxs-lookup"><span data-stu-id="3b0dd-134">Reference</span></span> 

[<span data-ttu-id="3b0dd-135">GameSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="3b0dd-135">GameSession (JSON)</span></span>](json-gamesession.md)

   