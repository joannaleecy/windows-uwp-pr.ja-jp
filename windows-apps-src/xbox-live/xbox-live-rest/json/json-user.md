---
title: User (JSON)
assetID: dbc733e4-0348-0e3d-1f55-17b465e599d6
permalink: en-us/docs/xboxlive/rest/json-user.html
description: " User (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5c1b3a34ef329696d51e615dd79d57783a132d05
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8744933"
---
# <a name="user-json"></a><span data-ttu-id="55ab6-104">User (JSON)</span><span class="sxs-lookup"><span data-stu-id="55ab6-104">User (JSON)</span></span>
<span data-ttu-id="55ab6-105">ユーザーのランキング データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="55ab6-105">Contains user leaderboard data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="user"></a><span data-ttu-id="55ab6-106">ユーザー</span><span class="sxs-lookup"><span data-stu-id="55ab6-106">User</span></span>
 
<span data-ttu-id="55ab6-107">ユーザー オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="55ab6-107">The User object has the following specification.</span></span>
 
| <span data-ttu-id="55ab6-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="55ab6-108">Member</span></span>| <span data-ttu-id="55ab6-109">種類</span><span class="sxs-lookup"><span data-stu-id="55ab6-109">Type</span></span>| <span data-ttu-id="55ab6-110">説明</span><span class="sxs-lookup"><span data-stu-id="55ab6-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="55ab6-111">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="55ab6-111">gamertag</span></span>| <span data-ttu-id="55ab6-112">string</span><span class="sxs-lookup"><span data-stu-id="55ab6-112">string</span></span>| <span data-ttu-id="55ab6-113">(最大で 15 文字の) プレイヤーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="55ab6-113">Gamertag of the player (maximum of 15 characters).</span></span> <span data-ttu-id="55ab6-114">クライアントは、プレイヤーを識別するために、UI でこの値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="55ab6-114">The client should use this value in the UI when identifying the player.</span></span>| 
| <span data-ttu-id="55ab6-115">ランク</span><span class="sxs-lookup"><span data-stu-id="55ab6-115">rank</span></span>| <span data-ttu-id="55ab6-116">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="55ab6-116">32-bit signed integer</span></span>| <span data-ttu-id="55ab6-117">ランキング データを要求しているユーザーを基準としたユーザーのランク。</span><span class="sxs-lookup"><span data-stu-id="55ab6-117">The rank of the user relative to the user requesting the leaderboard data.</span></span>| 
| <span data-ttu-id="55ab6-118">rating</span><span class="sxs-lookup"><span data-stu-id="55ab6-118">rating</span></span>| <span data-ttu-id="55ab6-119">string</span><span class="sxs-lookup"><span data-stu-id="55ab6-119">string</span></span>| <span data-ttu-id="55ab6-120">ユーザーの評価です。</span><span class="sxs-lookup"><span data-stu-id="55ab6-120">The user's rating.</span></span>| 
| <span data-ttu-id="55ab6-121">xuid</span><span class="sxs-lookup"><span data-stu-id="55ab6-121">xuid</span></span>| <span data-ttu-id="55ab6-122">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="55ab6-122">64-bit unsigned integer</span></span>| <span data-ttu-id="55ab6-123">Xbox ユーザー ID (XUID) ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="55ab6-123">The Xbox User ID (XUID) of the user.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="55ab6-124">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="55ab6-124">Sample JSON syntax</span></span>
 

```json
{ 
   "gamertag":"TrueBlue402",
   "rank":2,
   "rating":"2:19:21.17",
   "xuid":1234567890123456 
}
    
```

  
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="55ab6-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="55ab6-125">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="55ab6-126">Parent</span><span class="sxs-lookup"><span data-stu-id="55ab6-126">Parent</span></span> 

[<span data-ttu-id="55ab6-127">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="55ab6-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   