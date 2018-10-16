---
title: Person (JSON)
assetID: b49234b1-03cd-f16e-c293-c74174382167
permalink: en-us/docs/xboxlive/rest/json-person.html
author: KevinAsgari
description: " Person (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 7e8e4ac4e91c4359ca20822297ccb625d09e3d59
ms.sourcegitcommit: 9354909f9351b9635bee9bb2dc62db60d2d70107
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/16/2018
ms.locfileid: "4689670"
---
# <a name="person-json"></a><span data-ttu-id="bc026-104">Person (JSON)</span><span class="sxs-lookup"><span data-stu-id="bc026-104">Person (JSON)</span></span>
<span data-ttu-id="bc026-105">People システムで 1 人のユーザーに関するメタデータ。</span><span class="sxs-lookup"><span data-stu-id="bc026-105">Metadata about a single Person in the People system.</span></span> 
<a id="ID4EN"></a>

 
## <a name="person"></a><span data-ttu-id="bc026-106">人</span><span class="sxs-lookup"><span data-stu-id="bc026-106">Person</span></span>
 
<span data-ttu-id="bc026-107">Person オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="bc026-107">The Person object has the following specification.</span></span>
 
| <span data-ttu-id="bc026-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="bc026-108">Member</span></span>| <span data-ttu-id="bc026-109">種類</span><span class="sxs-lookup"><span data-stu-id="bc026-109">Type</span></span>| <span data-ttu-id="bc026-110">説明</span><span class="sxs-lookup"><span data-stu-id="bc026-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bc026-111">xuid</span><span class="sxs-lookup"><span data-stu-id="bc026-111">xuid</span></span>| <span data-ttu-id="bc026-112">string</span><span class="sxs-lookup"><span data-stu-id="bc026-112">string</span></span>| <span data-ttu-id="bc026-113">必須。</span><span class="sxs-lookup"><span data-stu-id="bc026-113">Required.</span></span> <span data-ttu-id="bc026-114">Xbox ユーザー ID (XUID)、10 進数。</span><span class="sxs-lookup"><span data-stu-id="bc026-114">Xbox User ID (XUID) in decimal form.</span></span> <span data-ttu-id="bc026-115">値の例: 2603643534573573 します。</span><span class="sxs-lookup"><span data-stu-id="bc026-115">Example value: 2603643534573573.</span></span>| 
| <span data-ttu-id="bc026-116">isFavorite</span><span class="sxs-lookup"><span data-stu-id="bc026-116">isFavorite</span></span>| <span data-ttu-id="bc026-117">ブール値</span><span class="sxs-lookup"><span data-stu-id="bc026-117">Boolean value</span></span>| <span data-ttu-id="bc026-118">必須。</span><span class="sxs-lookup"><span data-stu-id="bc026-118">Required.</span></span> <span data-ttu-id="bc026-119">かどうかこのユーザーは、ユーザーが気詳細です。</span><span class="sxs-lookup"><span data-stu-id="bc026-119">Whether this person is one that the user cares about more.</span></span> <span data-ttu-id="bc026-120">ユーザーでは自分のユーザー リスト内にユーザー数が非常に大規模ながあるためお気に入りユーザーをエクスペリエンスに優先順位し、お気に入りではない他のユーザーの前に表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="bc026-120">Because users can have a very large number of people in their People list, favorite people should be prioritized in experiences and shown before others that are not favorites.</span></span>| 
| <span data-ttu-id="bc026-121">isFollowingCaller</span><span class="sxs-lookup"><span data-stu-id="bc026-121">isFollowingCaller</span></span>| <span data-ttu-id="bc026-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="bc026-122">Boolean value</span></span>| <span data-ttu-id="bc026-123">省略可能。</span><span class="sxs-lookup"><span data-stu-id="bc026-123">Optional.</span></span> <span data-ttu-id="bc026-124">このユーザーがユーザーをフォローするかどうかを代わりに、API 呼び出ししました。</span><span class="sxs-lookup"><span data-stu-id="bc026-124">Whether this person is following the user on whose behalf the API call was made.</span></span>| 
| <span data-ttu-id="bc026-125">socialNetworks</span><span class="sxs-lookup"><span data-stu-id="bc026-125">socialNetworks</span></span>| <span data-ttu-id="bc026-126">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="bc026-126">array of string</span></span>| <span data-ttu-id="bc026-127">省略可能。</span><span class="sxs-lookup"><span data-stu-id="bc026-127">Optional.</span></span> <span data-ttu-id="bc026-128">外部ネットワーク内でユーザーがこの人と関係のあります。</span><span class="sxs-lookup"><span data-stu-id="bc026-128">Within which external networks the user and this person have a relationship.</span></span>| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="bc026-129">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="bc026-129">Sample JSON syntax</span></span>
 

```json
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bc026-130">関連項目</span><span class="sxs-lookup"><span data-stu-id="bc026-130">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bc026-131">Parent</span><span class="sxs-lookup"><span data-stu-id="bc026-131">Parent</span></span> 

[<span data-ttu-id="bc026-132">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="bc026-132">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a><span data-ttu-id="bc026-133">リファレンス</span><span class="sxs-lookup"><span data-stu-id="bc026-133">Reference</span></span> 

[<span data-ttu-id="bc026-134">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="bc026-134">/users/{ownerId}/people/{targetid}</span></span>](../uri/people/uri-usersowneridpeopletargetid.md)

 [<span data-ttu-id="bc026-135">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="bc026-135">/users/{ownerId}/people/xuids</span></span>](../uri/people/uri-usersowneridpeoplexuids.md)

   