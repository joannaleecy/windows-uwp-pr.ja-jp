---
title: Progression (JSON)
assetID: cdff6415-f12b-0a45-61f2-26dbf47b1b56
permalink: en-us/docs/xboxlive/rest/json-progression.html
description: " Progression (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dda124e5be9a4d21a1ee5b9d6130290207e31921
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8751189"
---
# <a name="progression-json"></a><span data-ttu-id="f6ded-104">Progression (JSON)</span><span class="sxs-lookup"><span data-stu-id="f6ded-104">Progression (JSON)</span></span>
<span data-ttu-id="f6ded-105">実績をロック解除に向けたユーザーの進行します。</span><span class="sxs-lookup"><span data-stu-id="f6ded-105">The user's progression toward unlocking the achievement.</span></span> 
<a id="ID4EN"></a>

 
## <a name="progression"></a><span data-ttu-id="f6ded-106">進行状況</span><span class="sxs-lookup"><span data-stu-id="f6ded-106">Progression</span></span>
 
<span data-ttu-id="f6ded-107">進行状況のオブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f6ded-107">The Progression object has the following specification.</span></span>
 
| <span data-ttu-id="f6ded-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="f6ded-108">Member</span></span>| <span data-ttu-id="f6ded-109">種類</span><span class="sxs-lookup"><span data-stu-id="f6ded-109">Type</span></span>| <span data-ttu-id="f6ded-110">説明</span><span class="sxs-lookup"><span data-stu-id="f6ded-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f6ded-111">要件</span><span class="sxs-lookup"><span data-stu-id="f6ded-111">requirements</span></span>| <span data-ttu-id="f6ded-112">要件の配列</span><span class="sxs-lookup"><span data-stu-id="f6ded-112">array of Requirement</span></span>| <span data-ttu-id="f6ded-113">実績を獲得するための要件と、ユーザーの関与がロック解除に向けたです。</span><span class="sxs-lookup"><span data-stu-id="f6ded-113">The requirements to earn the achievement and how far along the user is toward unlocking it.</span></span>| 
| <span data-ttu-id="f6ded-114">timeUnlocked</span><span class="sxs-lookup"><span data-stu-id="f6ded-114">timeUnlocked</span></span>| <span data-ttu-id="f6ded-115">DateTime</span><span class="sxs-lookup"><span data-stu-id="f6ded-115">DateTime</span></span>| <span data-ttu-id="f6ded-116">実績ロックが解除された最初の時刻。</span><span class="sxs-lookup"><span data-stu-id="f6ded-116">The time the achievement was first unlocked.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="f6ded-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="f6ded-117">Sample JSON syntax</span></span>
 

```json
{
  "requirements":
  [{
    "id":"12345678-1234-1234-1234-123456789012",
    "current":null,
    "target":"100"
  }],
  "timeUnlocked":"2013-01-17T03:19:00.3087016Z",
}
    
```

  
<a id="ID4E3B"></a>

 
## <a name="see-also"></a><span data-ttu-id="f6ded-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="f6ded-118">See also</span></span>
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a><span data-ttu-id="f6ded-119">Parent</span><span class="sxs-lookup"><span data-stu-id="f6ded-119">Parent</span></span> 

[<span data-ttu-id="f6ded-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f6ded-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   