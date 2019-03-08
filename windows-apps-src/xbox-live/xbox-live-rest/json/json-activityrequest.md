---
title: ActivityRequest (JSON)
assetID: 9eb03ab7-352c-4465-ec86-d544e76f63f9
permalink: en-us/docs/xboxlive/rest/json-activityrequest.html
description: " ActivityRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 791a566d278b92aeb34ab36d38719b44e9cc6c8f
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57628157"
---
# <a name="activityrequest-json"></a><span data-ttu-id="86acd-104">ActivityRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="86acd-104">ActivityRequest (JSON)</span></span>
<span data-ttu-id="86acd-105">1 つまたは複数のユーザーのプレゼンス情報の要求。</span><span class="sxs-lookup"><span data-stu-id="86acd-105">A request for information about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrequest"></a><span data-ttu-id="86acd-106">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="86acd-106">ActivityRequest</span></span>
 
<span data-ttu-id="86acd-107">ActivityRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="86acd-107">The ActivityRequest object has the following specification.</span></span>
 
| <span data-ttu-id="86acd-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="86acd-108">Member</span></span>| <span data-ttu-id="86acd-109">種類</span><span class="sxs-lookup"><span data-stu-id="86acd-109">Type</span></span>| <span data-ttu-id="86acd-110">説明</span><span class="sxs-lookup"><span data-stu-id="86acd-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="86acd-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="86acd-111">richPresence</span></span>| [<span data-ttu-id="86acd-112">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="86acd-112">RichPresenceRequest</span></span>](json-richpresencerequest.md)| <span data-ttu-id="86acd-113">使用する必要がある豊富なプレゼンス文字列のフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="86acd-113">The friendly name of the rich presence string that should be used.</span></span>| 
| <span data-ttu-id="86acd-114">メディア</span><span class="sxs-lookup"><span data-stu-id="86acd-114">media</span></span>| <span data-ttu-id="86acd-115">MediaRequest</span><span class="sxs-lookup"><span data-stu-id="86acd-115">MediaRequest</span></span>| <span data-ttu-id="86acd-116">どのようなユーザーのメディア情報が視聴またはリッスンします。</span><span class="sxs-lookup"><span data-stu-id="86acd-116">Media information for what the user is watching or listening to.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="86acd-117">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="86acd-117">Sample JSON syntax</span></span>
 

```json
{
    richPresence:
    {
      id:"playingMapWeapon",
      scid:"abba0123-08ba-48ca-9f1a-21627b189b0f"
    }
  }
    
```

  
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="86acd-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="86acd-118">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="86acd-119">Parent</span><span class="sxs-lookup"><span data-stu-id="86acd-119">Parent</span></span> 

[<span data-ttu-id="86acd-120">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="86acd-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   