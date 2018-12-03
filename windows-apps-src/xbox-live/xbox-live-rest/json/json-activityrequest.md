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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8345410"
---
# <a name="activityrequest-json"></a><span data-ttu-id="20151-104">ActivityRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="20151-104">ActivityRequest (JSON)</span></span>
<span data-ttu-id="20151-105">1 つまたは複数のユーザーのリッチ プレゼンスに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="20151-105">A request for information about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrequest"></a><span data-ttu-id="20151-106">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="20151-106">ActivityRequest</span></span>
 
<span data-ttu-id="20151-107">ActivityRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="20151-107">The ActivityRequest object has the following specification.</span></span>
 
| <span data-ttu-id="20151-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="20151-108">Member</span></span>| <span data-ttu-id="20151-109">種類</span><span class="sxs-lookup"><span data-stu-id="20151-109">Type</span></span>| <span data-ttu-id="20151-110">説明</span><span class="sxs-lookup"><span data-stu-id="20151-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="20151-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="20151-111">richPresence</span></span>| [<span data-ttu-id="20151-112">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="20151-112">RichPresenceRequest</span></span>](json-richpresencerequest.md)| <span data-ttu-id="20151-113">ために使用するリッチ プレゼンス文字列のフレンドリ名。</span><span class="sxs-lookup"><span data-stu-id="20151-113">The friendly name of the rich presence string that should be used.</span></span>| 
| <span data-ttu-id="20151-114">メディア</span><span class="sxs-lookup"><span data-stu-id="20151-114">media</span></span>| <span data-ttu-id="20151-115">MediaRequest</span><span class="sxs-lookup"><span data-stu-id="20151-115">MediaRequest</span></span>| <span data-ttu-id="20151-116">どのようなユーザーのメディア情報が視聴またはをリッスンします。</span><span class="sxs-lookup"><span data-stu-id="20151-116">Media information for what the user is watching or listening to.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="20151-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="20151-117">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="20151-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="20151-118">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="20151-119">Parent</span><span class="sxs-lookup"><span data-stu-id="20151-119">Parent</span></span> 

[<span data-ttu-id="20151-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="20151-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   