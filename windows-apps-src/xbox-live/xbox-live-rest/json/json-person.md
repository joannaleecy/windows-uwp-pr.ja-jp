---
title: Person (JSON)
assetID: b49234b1-03cd-f16e-c293-c74174382167
permalink: en-us/docs/xboxlive/rest/json-person.html
description: " Person (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 175d66ffc7744ca8203fe7681fcb0167e150f012
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640867"
---
# <a name="person-json"></a><span data-ttu-id="dc58d-104">Person (JSON)</span><span class="sxs-lookup"><span data-stu-id="dc58d-104">Person (JSON)</span></span>
<span data-ttu-id="dc58d-105">ユーザーのシステムで 1 人のユーザーに関するメタデータ。</span><span class="sxs-lookup"><span data-stu-id="dc58d-105">Metadata about a single Person in the People system.</span></span> 
<a id="ID4EN"></a>

 
## <a name="person"></a><span data-ttu-id="dc58d-106">人</span><span class="sxs-lookup"><span data-stu-id="dc58d-106">Person</span></span>
 
<span data-ttu-id="dc58d-107">Person オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="dc58d-107">The Person object has the following specification.</span></span>
 
| <span data-ttu-id="dc58d-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="dc58d-108">Member</span></span>| <span data-ttu-id="dc58d-109">種類</span><span class="sxs-lookup"><span data-stu-id="dc58d-109">Type</span></span>| <span data-ttu-id="dc58d-110">説明</span><span class="sxs-lookup"><span data-stu-id="dc58d-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="dc58d-111">xuid</span><span class="sxs-lookup"><span data-stu-id="dc58d-111">xuid</span></span>| <span data-ttu-id="dc58d-112">string</span><span class="sxs-lookup"><span data-stu-id="dc58d-112">string</span></span>| <span data-ttu-id="dc58d-113">必須。</span><span class="sxs-lookup"><span data-stu-id="dc58d-113">Required.</span></span> <span data-ttu-id="dc58d-114">Xbox ユーザー ID (XUID)、10 進数です。</span><span class="sxs-lookup"><span data-stu-id="dc58d-114">Xbox User ID (XUID) in decimal form.</span></span> <span data-ttu-id="dc58d-115">値の例:2603643534573573.</span><span class="sxs-lookup"><span data-stu-id="dc58d-115">Example value: 2603643534573573.</span></span>| 
| <span data-ttu-id="dc58d-116">isFavorite</span><span class="sxs-lookup"><span data-stu-id="dc58d-116">isFavorite</span></span>| <span data-ttu-id="dc58d-117">ブール値</span><span class="sxs-lookup"><span data-stu-id="dc58d-117">Boolean value</span></span>| <span data-ttu-id="dc58d-118">必須。</span><span class="sxs-lookup"><span data-stu-id="dc58d-118">Required.</span></span> <span data-ttu-id="dc58d-119">かどうかこの人は、ユーザーが関心の詳細です。</span><span class="sxs-lookup"><span data-stu-id="dc58d-119">Whether this person is one that the user cares about more.</span></span> <span data-ttu-id="dc58d-120">ユーザーがユーザー一覧にユーザー数が非常に大きいことがあるできます、ため、大好きな人をエクスペリエンスの優先順位し、お気に入りのない他のユーザーの前に表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="dc58d-120">Because users can have a very large number of people in their People list, favorite people should be prioritized in experiences and shown before others that are not favorites.</span></span>| 
| <span data-ttu-id="dc58d-121">isFollowingCaller</span><span class="sxs-lookup"><span data-stu-id="dc58d-121">isFollowingCaller</span></span>| <span data-ttu-id="dc58d-122">ブール値</span><span class="sxs-lookup"><span data-stu-id="dc58d-122">Boolean value</span></span>| <span data-ttu-id="dc58d-123">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="dc58d-123">Optional.</span></span> <span data-ttu-id="dc58d-124">このユーザーがユーザーをフォローしているかどうかが代わりに API 呼び出しが行われました。</span><span class="sxs-lookup"><span data-stu-id="dc58d-124">Whether this person is following the user on whose behalf the API call was made.</span></span>| 
| <span data-ttu-id="dc58d-125">socialNetworks</span><span class="sxs-lookup"><span data-stu-id="dc58d-125">socialNetworks</span></span>| <span data-ttu-id="dc58d-126">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="dc58d-126">array of string</span></span>| <span data-ttu-id="dc58d-127">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="dc58d-127">Optional.</span></span> <span data-ttu-id="dc58d-128">この人と、ユーザーは、外部ネットワーク内でリレーションシップを持ちます。</span><span class="sxs-lookup"><span data-stu-id="dc58d-128">Within which external networks the user and this person have a relationship.</span></span>| 
  
<a id="ID4EHC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="dc58d-129">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="dc58d-129">Sample JSON syntax</span></span>
 

```json
{
    "xuid": "2603643534573581",
    "isFavorite": false,
    "isFollowingCaller": false,
    "socialNetworks": ["LegacyXboxLive"]
}
    
```

  
<a id="ID4EQC"></a>

 
## <a name="see-also"></a><span data-ttu-id="dc58d-130">関連項目</span><span class="sxs-lookup"><span data-stu-id="dc58d-130">See also</span></span>
 
<a id="ID4ESC"></a>

 
##### <a name="parent"></a><span data-ttu-id="dc58d-131">Parent</span><span class="sxs-lookup"><span data-stu-id="dc58d-131">Parent</span></span> 

[<span data-ttu-id="dc58d-132">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="dc58d-132">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E3C"></a>

 
##### <a name="reference"></a><span data-ttu-id="dc58d-133">リファレンス</span><span class="sxs-lookup"><span data-stu-id="dc58d-133">Reference</span></span> 

[<span data-ttu-id="dc58d-134">/users/{ownerId}/people/{targetid}</span><span class="sxs-lookup"><span data-stu-id="dc58d-134">/users/{ownerId}/people/{targetid}</span></span>](../uri/people/uri-usersowneridpeopletargetid.md)

 [<span data-ttu-id="dc58d-135">/users/{ownerId}/people/xuids</span><span class="sxs-lookup"><span data-stu-id="dc58d-135">/users/{ownerId}/people/xuids</span></span>](../uri/people/uri-usersowneridpeoplexuids.md)

   