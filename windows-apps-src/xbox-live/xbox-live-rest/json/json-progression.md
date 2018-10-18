---
title: Progression (JSON)
assetID: cdff6415-f12b-0a45-61f2-26dbf47b1b56
permalink: en-us/docs/xboxlive/rest/json-progression.html
author: KevinAsgari
description: " Progression (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5a0e534d92e4bcb77565f59de5252afcbbe3eef5
ms.sourcegitcommit: e16c9845b52d5bd43fc02bbe92296a9682d96926
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/18/2018
ms.locfileid: "4966689"
---
# <a name="progression-json"></a><span data-ttu-id="8c84a-104">Progression (JSON)</span><span class="sxs-lookup"><span data-stu-id="8c84a-104">Progression (JSON)</span></span>
<span data-ttu-id="8c84a-105">実績をロック解除に向けたユーザーの進行します。</span><span class="sxs-lookup"><span data-stu-id="8c84a-105">The user's progression toward unlocking the achievement.</span></span> 
<a id="ID4EN"></a>

 
## <a name="progression"></a><span data-ttu-id="8c84a-106">進行状況</span><span class="sxs-lookup"><span data-stu-id="8c84a-106">Progression</span></span>
 
<span data-ttu-id="8c84a-107">進行状況のオブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="8c84a-107">The Progression object has the following specification.</span></span>
 
| <span data-ttu-id="8c84a-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="8c84a-108">Member</span></span>| <span data-ttu-id="8c84a-109">種類</span><span class="sxs-lookup"><span data-stu-id="8c84a-109">Type</span></span>| <span data-ttu-id="8c84a-110">説明</span><span class="sxs-lookup"><span data-stu-id="8c84a-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="8c84a-111">要件</span><span class="sxs-lookup"><span data-stu-id="8c84a-111">requirements</span></span>| <span data-ttu-id="8c84a-112">要件の配列</span><span class="sxs-lookup"><span data-stu-id="8c84a-112">array of Requirement</span></span>| <span data-ttu-id="8c84a-113">実績を獲得するための要件は、ユーザーの関与がロック解除に向けたします。</span><span class="sxs-lookup"><span data-stu-id="8c84a-113">The requirements to earn the achievement and how far along the user is toward unlocking it.</span></span>| 
| <span data-ttu-id="8c84a-114">timeUnlocked</span><span class="sxs-lookup"><span data-stu-id="8c84a-114">timeUnlocked</span></span>| <span data-ttu-id="8c84a-115">DateTime</span><span class="sxs-lookup"><span data-stu-id="8c84a-115">DateTime</span></span>| <span data-ttu-id="8c84a-116">実績ロックが解除された最初の時刻。</span><span class="sxs-lookup"><span data-stu-id="8c84a-116">The time the achievement was first unlocked.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="8c84a-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="8c84a-117">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="8c84a-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="8c84a-118">See also</span></span>
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a><span data-ttu-id="8c84a-119">Parent</span><span class="sxs-lookup"><span data-stu-id="8c84a-119">Parent</span></span> 

[<span data-ttu-id="8c84a-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="8c84a-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   