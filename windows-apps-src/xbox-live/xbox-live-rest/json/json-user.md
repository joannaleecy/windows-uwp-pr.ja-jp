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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57641357"
---
# <a name="user-json"></a><span data-ttu-id="587ce-104">User (JSON)</span><span class="sxs-lookup"><span data-stu-id="587ce-104">User (JSON)</span></span>
<span data-ttu-id="587ce-105">ユーザーのランキング データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="587ce-105">Contains user leaderboard data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="user"></a><span data-ttu-id="587ce-106">ユーザー</span><span class="sxs-lookup"><span data-stu-id="587ce-106">User</span></span>
 
<span data-ttu-id="587ce-107">ユーザー オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="587ce-107">The User object has the following specification.</span></span>
 
| <span data-ttu-id="587ce-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="587ce-108">Member</span></span>| <span data-ttu-id="587ce-109">種類</span><span class="sxs-lookup"><span data-stu-id="587ce-109">Type</span></span>| <span data-ttu-id="587ce-110">説明</span><span class="sxs-lookup"><span data-stu-id="587ce-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="587ce-111">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="587ce-111">gamertag</span></span>| <span data-ttu-id="587ce-112">string</span><span class="sxs-lookup"><span data-stu-id="587ce-112">string</span></span>| <span data-ttu-id="587ce-113">Player (15 文字の最大値) のゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="587ce-113">Gamertag of the player (maximum of 15 characters).</span></span> <span data-ttu-id="587ce-114">クライアントは、プレーヤーを識別するときに、UI にこの値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="587ce-114">The client should use this value in the UI when identifying the player.</span></span>| 
| <span data-ttu-id="587ce-115">ランク</span><span class="sxs-lookup"><span data-stu-id="587ce-115">rank</span></span>| <span data-ttu-id="587ce-116">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="587ce-116">32-bit signed integer</span></span>| <span data-ttu-id="587ce-117">ランキング データを要求するユーザーを基準としたユーザーのランク。</span><span class="sxs-lookup"><span data-stu-id="587ce-117">The rank of the user relative to the user requesting the leaderboard data.</span></span>| 
| <span data-ttu-id="587ce-118">rating</span><span class="sxs-lookup"><span data-stu-id="587ce-118">rating</span></span>| <span data-ttu-id="587ce-119">string</span><span class="sxs-lookup"><span data-stu-id="587ce-119">string</span></span>| <span data-ttu-id="587ce-120">ユーザーの評価。</span><span class="sxs-lookup"><span data-stu-id="587ce-120">The user's rating.</span></span>| 
| <span data-ttu-id="587ce-121">xuid</span><span class="sxs-lookup"><span data-stu-id="587ce-121">xuid</span></span>| <span data-ttu-id="587ce-122">64 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="587ce-122">64-bit unsigned integer</span></span>| <span data-ttu-id="587ce-123">Xbox ユーザー ID (XUID) のユーザー。</span><span class="sxs-lookup"><span data-stu-id="587ce-123">The Xbox User ID (XUID) of the user.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="587ce-124">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="587ce-124">Sample JSON syntax</span></span>
 

```json
{ 
   "gamertag":"TrueBlue402",
   "rank":2,
   "rating":"2:19:21.17",
   "xuid":1234567890123456 
}
    
```

  
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="587ce-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="587ce-125">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="587ce-126">Parent</span><span class="sxs-lookup"><span data-stu-id="587ce-126">Parent</span></span> 

[<span data-ttu-id="587ce-127">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="587ce-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   