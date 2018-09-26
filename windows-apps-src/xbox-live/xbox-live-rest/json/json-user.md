---
title: User (JSON)
assetID: dbc733e4-0348-0e3d-1f55-17b465e599d6
permalink: en-us/docs/xboxlive/rest/json-user.html
author: KevinAsgari
description: " User (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7070d829000821cb48d8fcbaa4fde1d6f393b16a
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4177756"
---
# <a name="user-json"></a><span data-ttu-id="d9784-104">User (JSON)</span><span class="sxs-lookup"><span data-stu-id="d9784-104">User (JSON)</span></span>
<span data-ttu-id="d9784-105">ユーザーのランキング データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d9784-105">Contains user leaderboard data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="user"></a><span data-ttu-id="d9784-106">ユーザー</span><span class="sxs-lookup"><span data-stu-id="d9784-106">User</span></span>
 
<span data-ttu-id="d9784-107">ユーザー オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d9784-107">The User object has the following specification.</span></span>
 
| <span data-ttu-id="d9784-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="d9784-108">Member</span></span>| <span data-ttu-id="d9784-109">種類</span><span class="sxs-lookup"><span data-stu-id="d9784-109">Type</span></span>| <span data-ttu-id="d9784-110">説明</span><span class="sxs-lookup"><span data-stu-id="d9784-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d9784-111">ゲーマータグ</span><span class="sxs-lookup"><span data-stu-id="d9784-111">gamertag</span></span>| <span data-ttu-id="d9784-112">string</span><span class="sxs-lookup"><span data-stu-id="d9784-112">string</span></span>| <span data-ttu-id="d9784-113">(最大で 15 文字の) プレイヤーのゲーマータグです。</span><span class="sxs-lookup"><span data-stu-id="d9784-113">Gamertag of the player (maximum of 15 characters).</span></span> <span data-ttu-id="d9784-114">クライアントは、プレイヤーを識別するため、UI でこの値を使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d9784-114">The client should use this value in the UI when identifying the player.</span></span>| 
| <span data-ttu-id="d9784-115">ランク</span><span class="sxs-lookup"><span data-stu-id="d9784-115">rank</span></span>| <span data-ttu-id="d9784-116">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="d9784-116">32-bit signed integer</span></span>| <span data-ttu-id="d9784-117">ランキング データを要求しているユーザーを基準としたユーザーのランク。</span><span class="sxs-lookup"><span data-stu-id="d9784-117">The rank of the user relative to the user requesting the leaderboard data.</span></span>| 
| <span data-ttu-id="d9784-118">rating</span><span class="sxs-lookup"><span data-stu-id="d9784-118">rating</span></span>| <span data-ttu-id="d9784-119">string</span><span class="sxs-lookup"><span data-stu-id="d9784-119">string</span></span>| <span data-ttu-id="d9784-120">ユーザーの評価です。</span><span class="sxs-lookup"><span data-stu-id="d9784-120">The user's rating.</span></span>| 
| <span data-ttu-id="d9784-121">xuid</span><span class="sxs-lookup"><span data-stu-id="d9784-121">xuid</span></span>| <span data-ttu-id="d9784-122">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d9784-122">64-bit unsigned integer</span></span>| <span data-ttu-id="d9784-123">Xbox ユーザー ID (XUID) ユーザーのします。</span><span class="sxs-lookup"><span data-stu-id="d9784-123">The Xbox User ID (XUID) of the user.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d9784-124">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d9784-124">Sample JSON syntax</span></span>
 

```json
{ 
   "gamertag":"TrueBlue402",
   "rank":2,
   "rating":"2:19:21.17",
   "xuid":1234567890123456 
}
    
```

  
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d9784-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="d9784-125">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d9784-126">Parent</span><span class="sxs-lookup"><span data-stu-id="d9784-126">Parent</span></span> 

[<span data-ttu-id="d9784-127">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d9784-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   