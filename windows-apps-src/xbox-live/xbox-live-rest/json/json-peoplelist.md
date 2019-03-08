---
title: PeopleList (JSON)
assetID: ac538652-c10c-44e5-c1e3-5314ebe8ba83
permalink: en-us/docs/xboxlive/rest/json-peoplelist.html
description: " PeopleList (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1f9ab412088707752d62cc20fd54da2639f26ddc
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57613327"
---
# <a name="peoplelist-json"></a><span data-ttu-id="a48cc-104">PeopleList (JSON)</span><span class="sxs-lookup"><span data-stu-id="a48cc-104">PeopleList (JSON)</span></span>
<span data-ttu-id="a48cc-105">コレクション[Person](json-person.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="a48cc-105">Collection of [Person](json-person.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="peoplelist"></a><span data-ttu-id="a48cc-106">PeopleList</span><span class="sxs-lookup"><span data-stu-id="a48cc-106">PeopleList</span></span>
 
<span data-ttu-id="a48cc-107">PeopleList オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="a48cc-107">The PeopleList object has the following specification.</span></span>
 
| <span data-ttu-id="a48cc-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="a48cc-108">Member</span></span>| <span data-ttu-id="a48cc-109">種類</span><span class="sxs-lookup"><span data-stu-id="a48cc-109">Type</span></span>| <span data-ttu-id="a48cc-110">説明</span><span class="sxs-lookup"><span data-stu-id="a48cc-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="a48cc-111">[People]</span><span class="sxs-lookup"><span data-stu-id="a48cc-111">people</span></span>| <span data-ttu-id="a48cc-112">配列[人](json-person.md)</span><span class="sxs-lookup"><span data-stu-id="a48cc-112">array of [Person](json-person.md)</span></span>| <span data-ttu-id="a48cc-113">[Person](json-person.md)連絡先リストを構成するオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="a48cc-113">The [Person](json-person.md) objects that make up the people list.</span></span>| 
| <span data-ttu-id="a48cc-114">totalCount</span><span class="sxs-lookup"><span data-stu-id="a48cc-114">totalCount</span></span>| <span data-ttu-id="a48cc-115">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="a48cc-115">32-bit unsigned integer</span></span>| <span data-ttu-id="a48cc-116">合計数[Person](json-person.md)セットで使用可能なオブジェクト。</span><span class="sxs-lookup"><span data-stu-id="a48cc-116">Total number of [Person](json-person.md) objects available in the set.</span></span> <span data-ttu-id="a48cc-117">この値は、最新の応答だけでなく、セット全体のサイズを表すためにのページングのクライアントで使用できます。</span><span class="sxs-lookup"><span data-stu-id="a48cc-117">This value can be used by clients for paging because it represents the size of the whole set, not just the most recent response.</span></span> <span data-ttu-id="a48cc-118">値の例:680.</span><span class="sxs-lookup"><span data-stu-id="a48cc-118">Example value: 680.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="a48cc-119">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="a48cc-119">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="a48cc-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="a48cc-120">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="a48cc-121">Parent</span><span class="sxs-lookup"><span data-stu-id="a48cc-121">Parent</span></span> 

[<span data-ttu-id="a48cc-122">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="a48cc-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVC"></a>

 
##### <a name="reference"></a><span data-ttu-id="a48cc-123">リファレンス</span><span class="sxs-lookup"><span data-stu-id="a48cc-123">Reference</span></span> 

[<span data-ttu-id="a48cc-124">GET (/users/{ownerId}/people)</span><span class="sxs-lookup"><span data-stu-id="a48cc-124">GET (/users/{ownerId}/people)</span></span>](../uri/people/uri-usersowneridpeopleget.md)

 [<span data-ttu-id="a48cc-125">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="a48cc-125">POST (/users/{ownerId}/people/xuids)</span></span>](../uri/people/uri-usersowneridpeoplexuidspost.md)

   