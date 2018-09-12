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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882282"
---
# <a name="activityrequest-json"></a><span data-ttu-id="c9fb1-104">ActivityRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="c9fb1-104">ActivityRequest (JSON)</span></span>
<span data-ttu-id="c9fb1-105">1 つまたは複数のユーザーのリッチ プレゼンスに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="c9fb1-105">A request for information about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrequest"></a><span data-ttu-id="c9fb1-106">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="c9fb1-106">ActivityRequest</span></span>
 
<span data-ttu-id="c9fb1-107">ActivityRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c9fb1-107">The ActivityRequest object has the following specification.</span></span>
 
| <span data-ttu-id="c9fb1-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="c9fb1-108">Member</span></span>| <span data-ttu-id="c9fb1-109">種類</span><span class="sxs-lookup"><span data-stu-id="c9fb1-109">Type</span></span>| <span data-ttu-id="c9fb1-110">説明</span><span class="sxs-lookup"><span data-stu-id="c9fb1-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="c9fb1-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="c9fb1-111">richPresence</span></span>| [<span data-ttu-id="c9fb1-112">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="c9fb1-112">RichPresenceRequest</span></span>](json-richpresencerequest.md)| <span data-ttu-id="c9fb1-113">ために使用するリッチ プレゼンス文字列のフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="c9fb1-113">The friendly name of the rich presence string that should be used.</span></span>| 
| <span data-ttu-id="c9fb1-114">メディア</span><span class="sxs-lookup"><span data-stu-id="c9fb1-114">media</span></span>| <span data-ttu-id="c9fb1-115">MediaRequest</span><span class="sxs-lookup"><span data-stu-id="c9fb1-115">MediaRequest</span></span>| <span data-ttu-id="c9fb1-116">どのようなユーザーのメディアの情報が視聴またはをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="c9fb1-116">Media information for what the user is watching or listening to.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="c9fb1-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="c9fb1-117">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="c9fb1-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="c9fb1-118">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c9fb1-119">Parent</span><span class="sxs-lookup"><span data-stu-id="c9fb1-119">Parent</span></span> 

[<span data-ttu-id="c9fb1-120">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c9fb1-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   