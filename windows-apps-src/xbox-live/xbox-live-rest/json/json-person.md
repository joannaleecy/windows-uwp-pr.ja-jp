---
title: Person (JSON)
assetID: b49234b1-03cd-f16e-c293-c74174382167
permalink: en-us/docs/xboxlive/rest/json-person.html
author: KevinAsgari
description: " Person (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 69ab54fce4631e8b1d0c5361863078d28d0cf3f2
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5933731"
---
# <a name="person-json"></a><span data-ttu-id="32169-104">Person (JSON)</span><span class="sxs-lookup"><span data-stu-id="32169-104">Person (JSON)</span></span>
<span data-ttu-id="32169-105">People システムで 1 人のユーザーに関するメタデータ。</span><span class="sxs-lookup"><span data-stu-id="32169-105">Metadata about a single Person in the People system.</span></span> 
<a id="ID4EN"></a>

 
## <a name="person"></a><span data-ttu-id="32169-106">人</span><span class="sxs-lookup"><span data-stu-id="32169-106">Person</span></span>
 
<span data-ttu-id="32169-107">ユーザー オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="32169-107">The Person object has the following specification.</span></span>
 
| <span data-ttu-id="32169-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="32169-108">Member</span></span>| <span data-ttu-id="32169-109">種類</span><span class="sxs-lookup"><span data-stu-id="32169-109">Type</span></span>| <span data-ttu-id="32169-110">説明</span><span class="sxs-lookup"><span data-stu-id="32169-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="32169-111">xuid</span><span class="sxs-lookup"><span data-stu-id="32169-111">xuid</span></span>| <span data-ttu-id="32169-112">string</span><span class="sxs-lookup"><span data-stu-id="32169-112">string</span></span>| <span data-ttu-id="32169-113">必須。</span><span class="sxs-lookup"><span data-stu-id="32169-113">Required.</span></span> <span data-ttu-id="32169-114">Xbox ユーザー ID (XUID)、10 進数。</span><span class="sxs-lookup"><span data-stu-id="32169-114">Xbox User ID (XUID) in decimal form.</span></span> <span data-ttu-id="32169-115">値の例: 2603643534573573 します。</span><span class="sxs-lookup"><span data-stu-id="32169-115">Example value: 2603643534573573.</span></span>| 
| <span data-ttu-id="32169-116">isFavorite</span><span class="sxs-lookup"><span data-stu-id="32169-116">isFavorite</span></span>| <span data-ttu-id="32169-117">ブール値</span><span class="sxs-lookup"><span data-stu-id="32169-117">Boolean value</span></span>| <span data-ttu-id="32169-118">必須。</span><span class="sxs-lookup"><span data-stu-id="32169-118">Required.</span></span> <span data-ttu-id="32169-119">かどうかこのユーザーは、ユーザーが気詳細です。</span><span class="sxs-lookup"><span data-stu-id="32169-119">Whether this person is one that the user cares about more.</span></span> <span data-ttu-id="32169-120">ユーザーためできますユーザー数が非常に大規模な自分のユーザー リストで、にお気に入りユーザーをエクスペリエンスの優先し、する前に [お気に入り] ではない他のユーザーに表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="32169-120">Because users can have a very large number of people in their People list, favorite people should be prioritized in experiences and shown before others that are not favorites.</span></span>| 
| <span data-ttu-id="32169-121">isFollowingCaller</span><span class="sxs-lookup"><span data-stu-id="32169-121">isFollowingCaller</span></span>| <span data-ttu-id="32169-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="32169-122">Boolean value</span></span>| <span data-ttu-id="32169-123">省略可能。</span><span class="sxs-lookup"><span data-stu-id="32169-123">Optional.</span></span> <span data-ttu-id="32169-124">このユーザーがユーザーをフォローするかどうかを代わりに、API 呼び出ししました。</span><span class="sxs-lookup"><span data-stu-id="32169-124">Whether this person is following the user on whose behalf the API call was made.</span></span>| 
| <span data-ttu-id="32169-125">socialNetworks</span><span class="sxs-lookup"><span data-stu-id="32169-125">socialNetworks</span></span>| <span data-ttu-id="32169-126">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="32169-126">array of string</span></span>| <span data-ttu-id="32169-127">省略可能。</span><span class="sxs-lookup"><span data-stu-id="32169-127">Optional.</span></span> <span data-ttu-id="32169-128">外部ネットワーク内でユーザーがこの人と関係のあります。</span><span class="sxs-lookup"><span data-stu-id="32169-128">Within which external networks the user and this person have a relationship.</span></span>| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="32169-129">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="32169-129">Sample JSON syntax</span></span>
 

```json
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="32169-130">関連項目</span><span class="sxs-lookup"><span data-stu-id="32169-130">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="32169-131">Parent</span><span class="sxs-lookup"><span data-stu-id="32169-131">Parent</span></span> 

[<span data-ttu-id="32169-132">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="32169-132">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a><span data-ttu-id="32169-133">リファレンス</span><span class="sxs-lookup"><span data-stu-id="32169-133">Reference</span></span> 

[<span data-ttu-id="32169-134">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="32169-134">/users/{ownerId}/people/{targetid}</span></span>](../uri/people/uri-usersowneridpeopletargetid.md)

 [<span data-ttu-id="32169-135">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="32169-135">/users/{ownerId}/people/xuids</span></span>](../uri/people/uri-usersowneridpeoplexuids.md)

   