---
title: ActivityRequest (JSON)
assetID: 9eb03ab7-352c-4465-ec86-d544e76f63f9
permalink: en-us/docs/xboxlive/rest/json-activityrequest.html
author: KevinAsgari
description: " ActivityRequest (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a3d1560c7bb8c6a6eb4fe9e4786f0378d74aeca2
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/21/2018
ms.locfileid: "5168515"
---
# <a name="activityrequest-json"></a><span data-ttu-id="5151a-104">ActivityRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="5151a-104">ActivityRequest (JSON)</span></span>
<span data-ttu-id="5151a-105">1 つまたは複数のユーザーのリッチ プレゼンスに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="5151a-105">A request for information about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrequest"></a><span data-ttu-id="5151a-106">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="5151a-106">ActivityRequest</span></span>
 
<span data-ttu-id="5151a-107">ActivityRequest オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="5151a-107">The ActivityRequest object has the following specification.</span></span>
 
| <span data-ttu-id="5151a-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="5151a-108">Member</span></span>| <span data-ttu-id="5151a-109">種類</span><span class="sxs-lookup"><span data-stu-id="5151a-109">Type</span></span>| <span data-ttu-id="5151a-110">説明</span><span class="sxs-lookup"><span data-stu-id="5151a-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5151a-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="5151a-111">richPresence</span></span>| [<span data-ttu-id="5151a-112">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="5151a-112">RichPresenceRequest</span></span>](json-richpresencerequest.md)| <span data-ttu-id="5151a-113">ために使用するリッチ プレゼンス文字列のフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="5151a-113">The friendly name of the rich presence string that should be used.</span></span>| 
| <span data-ttu-id="5151a-114">メディア</span><span class="sxs-lookup"><span data-stu-id="5151a-114">media</span></span>| <span data-ttu-id="5151a-115">MediaRequest</span><span class="sxs-lookup"><span data-stu-id="5151a-115">MediaRequest</span></span>| <span data-ttu-id="5151a-116">どのようなユーザーのメディアの情報は視聴またはをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="5151a-116">Media information for what the user is watching or listening to.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="5151a-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="5151a-117">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="5151a-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="5151a-118">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5151a-119">Parent</span><span class="sxs-lookup"><span data-stu-id="5151a-119">Parent</span></span> 

[<span data-ttu-id="5151a-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="5151a-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   