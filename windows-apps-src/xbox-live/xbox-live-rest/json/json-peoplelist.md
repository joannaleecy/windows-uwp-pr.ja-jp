---
title: PeopleList (JSON)
assetID: ac538652-c10c-44e5-c1e3-5314ebe8ba83
permalink: en-us/docs/xboxlive/rest/json-peoplelist.html
author: KevinAsgari
description: " PeopleList (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 261ab440091ce3825c1025e2831b054807910e94
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5941056"
---
# <a name="peoplelist-json"></a><span data-ttu-id="f1a0f-104">PeopleList (JSON)</span><span class="sxs-lookup"><span data-stu-id="f1a0f-104">PeopleList (JSON)</span></span>
<span data-ttu-id="f1a0f-105">[Person](json-person.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="f1a0f-105">Collection of [Person](json-person.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="peoplelist"></a><span data-ttu-id="f1a0f-106">PeopleList</span><span class="sxs-lookup"><span data-stu-id="f1a0f-106">PeopleList</span></span>
 
<span data-ttu-id="f1a0f-107">PeopleList オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f1a0f-107">The PeopleList object has the following specification.</span></span>
 
| <span data-ttu-id="f1a0f-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="f1a0f-108">Member</span></span>| <span data-ttu-id="f1a0f-109">種類</span><span class="sxs-lookup"><span data-stu-id="f1a0f-109">Type</span></span>| <span data-ttu-id="f1a0f-110">説明</span><span class="sxs-lookup"><span data-stu-id="f1a0f-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f1a0f-111">People</span><span class="sxs-lookup"><span data-stu-id="f1a0f-111">people</span></span>| <span data-ttu-id="f1a0f-112">[ユーザー](json-person.md)の配列</span><span class="sxs-lookup"><span data-stu-id="f1a0f-112">array of [Person](json-person.md)</span></span>| <span data-ttu-id="f1a0f-113">ユーザーのリストを構成する[Person](json-person.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f1a0f-113">The [Person](json-person.md) objects that make up the people list.</span></span>| 
| <span data-ttu-id="f1a0f-114">totalCount</span><span class="sxs-lookup"><span data-stu-id="f1a0f-114">totalCount</span></span>| <span data-ttu-id="f1a0f-115">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f1a0f-115">32-bit unsigned integer</span></span>| <span data-ttu-id="f1a0f-116">セットで利用可能な[Person](json-person.md)オブジェクトの合計数。</span><span class="sxs-lookup"><span data-stu-id="f1a0f-116">Total number of [Person](json-person.md) objects available in the set.</span></span> <span data-ttu-id="f1a0f-117">この値は、ページングすること、最新の応答だけでなく、セット全体のサイズを表すためのクライアントで使用できます。</span><span class="sxs-lookup"><span data-stu-id="f1a0f-117">This value can be used by clients for paging because it represents the size of the whole set, not just the most recent response.</span></span> <span data-ttu-id="f1a0f-118">値の例: 680 します。</span><span class="sxs-lookup"><span data-stu-id="f1a0f-118">Example value: 680.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="f1a0f-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="f1a0f-119">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="f1a0f-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="f1a0f-120">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f1a0f-121">Parent</span><span class="sxs-lookup"><span data-stu-id="f1a0f-121">Parent</span></span> 

[<span data-ttu-id="f1a0f-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f1a0f-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVC"></a>

 
##### <a name="reference"></a><span data-ttu-id="f1a0f-123">リファレンス</span><span class="sxs-lookup"><span data-stu-id="f1a0f-123">Reference</span></span> 

[<span data-ttu-id="f1a0f-124">GET (/users/{ownerId}/people)</span><span class="sxs-lookup"><span data-stu-id="f1a0f-124">GET (/users/{ownerId}/people)</span></span>](../uri/people/uri-usersowneridpeopleget.md)

 [<span data-ttu-id="f1a0f-125">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="f1a0f-125">POST (/users/{ownerId}/people/xuids)</span></span>](../uri/people/uri-usersowneridpeoplexuidspost.md)

   