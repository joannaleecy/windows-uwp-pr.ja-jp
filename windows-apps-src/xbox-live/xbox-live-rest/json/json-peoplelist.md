---
title: PeopleList (JSON)
assetID: ac538652-c10c-44e5-c1e3-5314ebe8ba83
permalink: en-us/docs/xboxlive/rest/json-peoplelist.html
author: KevinAsgari
description: " PeopleList (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 44102cb2ee1c996be9d0b42626f11a64ffb5c377
ms.sourcegitcommit: f5321b525034e2b3af202709e9b942ad5557e193
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2018
ms.locfileid: "4015787"
---
# <a name="peoplelist-json"></a><span data-ttu-id="6822b-104">PeopleList (JSON)</span><span class="sxs-lookup"><span data-stu-id="6822b-104">PeopleList (JSON)</span></span>
<span data-ttu-id="6822b-105">[Person](json-person.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="6822b-105">Collection of [Person](json-person.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="peoplelist"></a><span data-ttu-id="6822b-106">PeopleList</span><span class="sxs-lookup"><span data-stu-id="6822b-106">PeopleList</span></span>
 
<span data-ttu-id="6822b-107">PeopleList オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="6822b-107">The PeopleList object has the following specification.</span></span>
 
| <span data-ttu-id="6822b-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="6822b-108">Member</span></span>| <span data-ttu-id="6822b-109">種類</span><span class="sxs-lookup"><span data-stu-id="6822b-109">Type</span></span>| <span data-ttu-id="6822b-110">説明</span><span class="sxs-lookup"><span data-stu-id="6822b-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6822b-111">People</span><span class="sxs-lookup"><span data-stu-id="6822b-111">people</span></span>| <span data-ttu-id="6822b-112">[ユーザー](json-person.md)の配列</span><span class="sxs-lookup"><span data-stu-id="6822b-112">array of [Person](json-person.md)</span></span>| <span data-ttu-id="6822b-113">ユーザーのリストを構成する[Person](json-person.md)オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="6822b-113">The [Person](json-person.md) objects that make up the people list.</span></span>| 
| <span data-ttu-id="6822b-114">totalCount</span><span class="sxs-lookup"><span data-stu-id="6822b-114">totalCount</span></span>| <span data-ttu-id="6822b-115">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="6822b-115">32-bit unsigned integer</span></span>| <span data-ttu-id="6822b-116">セットで利用可能な[Person](json-person.md)オブジェクトの合計数。</span><span class="sxs-lookup"><span data-stu-id="6822b-116">Total number of [Person](json-person.md) objects available in the set.</span></span> <span data-ttu-id="6822b-117">この値は、全体のセットだけでなく、最新の応答のサイズを表すためにのページングのクライアントで使用できます。</span><span class="sxs-lookup"><span data-stu-id="6822b-117">This value can be used by clients for paging because it represents the size of the whole set, not just the most recent response.</span></span> <span data-ttu-id="6822b-118">値の例: 680 します。</span><span class="sxs-lookup"><span data-stu-id="6822b-118">Example value: 680.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="6822b-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="6822b-119">Sample JSON syntax</span></span>
 

```json
{
    "people": [
        {
            "xuid": "2603643534573573",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573572",
            "isFavorite": true,
            "isFollowingCaller": false,
            "socialNetworks": ["LegacyXboxLive"]
        },
        {
            "xuid": "2603643534573577",
            "isFavorite": false,
            "isFollowingCaller": false
        },
    ],
    "totalCount": 3
}
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="6822b-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="6822b-120">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="6822b-121">Parent</span><span class="sxs-lookup"><span data-stu-id="6822b-121">Parent</span></span> 

[<span data-ttu-id="6822b-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="6822b-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVC"></a>

 
##### <a name="reference"></a><span data-ttu-id="6822b-123">リファレンス</span><span class="sxs-lookup"><span data-stu-id="6822b-123">Reference</span></span> 

[<span data-ttu-id="6822b-124">GET (/users/{ownerId}/people)</span><span class="sxs-lookup"><span data-stu-id="6822b-124">GET (/users/{ownerId}/people)</span></span>](../uri/people/uri-usersowneridpeopleget.md)

 [<span data-ttu-id="6822b-125">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="6822b-125">POST (/users/{ownerId}/people/xuids)</span></span>](../uri/people/uri-usersowneridpeoplexuidspost.md)

   