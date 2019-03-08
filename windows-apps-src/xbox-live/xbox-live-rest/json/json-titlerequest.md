---
title: TitleRequest (JSON)
assetID: 43aeb6f9-726d-9260-e2ba-f005ea688bf1
permalink: en-us/docs/xboxlive/rest/json-titlerequest.html
description: " TitleRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a90f42c2f830ba6f04f77a1acaba067a2746a062
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57593797"
---
# <a name="titlerequest-json"></a><span data-ttu-id="e3149-104">TitleRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="e3149-104">TitleRequest (JSON)</span></span>
<span data-ttu-id="e3149-105">タイトルに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="e3149-105">Request for information about a title.</span></span> 
<a id="ID4EN"></a>

 
## <a name="titlerequest"></a><span data-ttu-id="e3149-106">TitleRequest</span><span class="sxs-lookup"><span data-stu-id="e3149-106">TitleRequest</span></span>
 
<span data-ttu-id="e3149-107">TitleRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="e3149-107">The TitleRequest object has the following specification.</span></span>
 
| <span data-ttu-id="e3149-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="e3149-108">Member</span></span>| <span data-ttu-id="e3149-109">種類</span><span class="sxs-lookup"><span data-stu-id="e3149-109">Type</span></span>| <span data-ttu-id="e3149-110">説明</span><span class="sxs-lookup"><span data-stu-id="e3149-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e3149-111">id</span><span class="sxs-lookup"><span data-stu-id="e3149-111">id</span></span>| <span data-ttu-id="e3149-112">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="e3149-112">32-bit unsigned integer</span></span>| <span data-ttu-id="e3149-113">タイトルの識別子です。</span><span class="sxs-lookup"><span data-stu-id="e3149-113">Identifier of the title.</span></span>| 
| <span data-ttu-id="e3149-114">activity (アクティビティ)</span><span class="sxs-lookup"><span data-stu-id="e3149-114">activity</span></span>| [<span data-ttu-id="e3149-115">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="e3149-115">ActivityRequest</span></span>](json-activityrequest.md)| <span data-ttu-id="e3149-116">タイトルで - については、使用可能な場合は、豊富なプレゼンスおよびメディア情報を含むです。</span><span class="sxs-lookup"><span data-stu-id="e3149-116">In-title information, including rich presence and media information, if available.</span></span>| 
| <span data-ttu-id="e3149-117">状態</span><span class="sxs-lookup"><span data-stu-id="e3149-117">state</span></span>| <span data-ttu-id="e3149-118">string</span><span class="sxs-lookup"><span data-stu-id="e3149-118">string</span></span>| <span data-ttu-id="e3149-119">ユーザーがアクティブかどうか。</span><span class="sxs-lookup"><span data-stu-id="e3149-119">Whether a user is active or not.</span></span> <span data-ttu-id="e3149-120">ユーザーを非アクティブとしてマークするには、このフィールドは必須です。</span><span class="sxs-lookup"><span data-stu-id="e3149-120">This field is required to mark a user as inactive.</span></span> <span data-ttu-id="e3149-121">既定では「アクティブ」です。</span><span class="sxs-lookup"><span data-stu-id="e3149-121">The default is "active".</span></span>| 
| <span data-ttu-id="e3149-122">配置</span><span class="sxs-lookup"><span data-stu-id="e3149-122">placement</span></span>| <span data-ttu-id="e3149-123">string</span><span class="sxs-lookup"><span data-stu-id="e3149-123">string</span></span>| <span data-ttu-id="e3149-124">タイトルの配置モードです。</span><span class="sxs-lookup"><span data-stu-id="e3149-124">The placement mode of the title.</span></span> <span data-ttu-id="e3149-125">使用可能な値には、"full"、「fill"」、「スナップ」型、または"background"が含まれます。</span><span class="sxs-lookup"><span data-stu-id="e3149-125">Possible values include "full", "fill", "snapped", or "background".</span></span> <span data-ttu-id="e3149-126">既定では「完全」です。</span><span class="sxs-lookup"><span data-stu-id="e3149-126">The default is "full".</span></span>| 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="e3149-127">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="e3149-127">Sample JSON syntax</span></span>
 

```json
{
  id:"12341234",
  placement:"snapped",
  state:"active",
  activity:
  {
    richPresence:
    {
      id:"playingMapWeapon",
      scid:"82b11353-08ba-48ca-9f1a-21627b189b0f"
    }
  }
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a><span data-ttu-id="e3149-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="e3149-128">See also</span></span>
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e3149-129">Parent</span><span class="sxs-lookup"><span data-stu-id="e3149-129">Parent</span></span> 

[<span data-ttu-id="e3149-130">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="e3149-130">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a><span data-ttu-id="e3149-131">リファレンス</span><span class="sxs-lookup"><span data-stu-id="e3149-131">Reference</span></span> 

[<span data-ttu-id="e3149-132">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="e3149-132">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentpost.md)

   