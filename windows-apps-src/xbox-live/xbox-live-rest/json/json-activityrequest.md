---
title: ActivityRequest (JSON)
assetID: 9eb03ab7-352c-4465-ec86-d544e76f63f9
permalink: en-us/docs/xboxlive/rest/json-activityrequest.html
author: KevinAsgari
description: " ActivityRequest (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6cb39036ccc75f4caec5a0fa6f961d2462ce5bda
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5755219"
---
# <a name="activityrequest-json"></a><span data-ttu-id="d27e9-104">ActivityRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="d27e9-104">ActivityRequest (JSON)</span></span>
<span data-ttu-id="d27e9-105">1 つまたは複数のユーザーのリッチ プレゼンスに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="d27e9-105">A request for information about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrequest"></a><span data-ttu-id="d27e9-106">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="d27e9-106">ActivityRequest</span></span>
 
<span data-ttu-id="d27e9-107">ActivityRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d27e9-107">The ActivityRequest object has the following specification.</span></span>
 
| <span data-ttu-id="d27e9-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="d27e9-108">Member</span></span>| <span data-ttu-id="d27e9-109">種類</span><span class="sxs-lookup"><span data-stu-id="d27e9-109">Type</span></span>| <span data-ttu-id="d27e9-110">説明</span><span class="sxs-lookup"><span data-stu-id="d27e9-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d27e9-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="d27e9-111">richPresence</span></span>| [<span data-ttu-id="d27e9-112">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="d27e9-112">RichPresenceRequest</span></span>](json-richpresencerequest.md)| <span data-ttu-id="d27e9-113">ために使用するリッチ プレゼンス文字列のフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="d27e9-113">The friendly name of the rich presence string that should be used.</span></span>| 
| <span data-ttu-id="d27e9-114">メディア</span><span class="sxs-lookup"><span data-stu-id="d27e9-114">media</span></span>| <span data-ttu-id="d27e9-115">MediaRequest</span><span class="sxs-lookup"><span data-stu-id="d27e9-115">MediaRequest</span></span>| <span data-ttu-id="d27e9-116">どのようなユーザーのメディアの情報が視聴またはをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="d27e9-116">Media information for what the user is watching or listening to.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d27e9-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d27e9-117">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="d27e9-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="d27e9-118">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d27e9-119">Parent</span><span class="sxs-lookup"><span data-stu-id="d27e9-119">Parent</span></span> 

[<span data-ttu-id="d27e9-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d27e9-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   