---
title: TitleRequest (JSON)
assetID: 43aeb6f9-726d-9260-e2ba-f005ea688bf1
permalink: en-us/docs/xboxlive/rest/json-titlerequest.html
author: KevinAsgari
description: " TitleRequest (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ab030f1f8086bc33243b4a764ccafd8747ea6c81
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6029056"
---
# <a name="titlerequest-json"></a><span data-ttu-id="468f6-104">TitleRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="468f6-104">TitleRequest (JSON)</span></span>
<span data-ttu-id="468f6-105">タイトルに関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="468f6-105">Request for information about a title.</span></span> 
<a id="ID4EN"></a>

 
## <a name="titlerequest"></a><span data-ttu-id="468f6-106">TitleRequest</span><span class="sxs-lookup"><span data-stu-id="468f6-106">TitleRequest</span></span>
 
<span data-ttu-id="468f6-107">TitleRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="468f6-107">The TitleRequest object has the following specification.</span></span>
 
| <span data-ttu-id="468f6-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="468f6-108">Member</span></span>| <span data-ttu-id="468f6-109">種類</span><span class="sxs-lookup"><span data-stu-id="468f6-109">Type</span></span>| <span data-ttu-id="468f6-110">説明</span><span class="sxs-lookup"><span data-stu-id="468f6-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="468f6-111">id</span><span class="sxs-lookup"><span data-stu-id="468f6-111">id</span></span>| <span data-ttu-id="468f6-112">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="468f6-112">32-bit unsigned integer</span></span>| <span data-ttu-id="468f6-113">タイトルの識別子です。</span><span class="sxs-lookup"><span data-stu-id="468f6-113">Identifier of the title.</span></span>| 
| <span data-ttu-id="468f6-114">activity (アクティビティ)</span><span class="sxs-lookup"><span data-stu-id="468f6-114">activity</span></span>| [<span data-ttu-id="468f6-115">ActivityRequest</span><span class="sxs-lookup"><span data-stu-id="468f6-115">ActivityRequest</span></span>](json-activityrequest.md)| <span data-ttu-id="468f6-116">タイトルでの利用可能な場合は、リッチ プレゼンスおよびメディア情報をなどの情報をします。</span><span class="sxs-lookup"><span data-stu-id="468f6-116">In-title information, including rich presence and media information, if available.</span></span>| 
| <span data-ttu-id="468f6-117">状態</span><span class="sxs-lookup"><span data-stu-id="468f6-117">state</span></span>| <span data-ttu-id="468f6-118">string</span><span class="sxs-lookup"><span data-stu-id="468f6-118">string</span></span>| <span data-ttu-id="468f6-119">かどうか、ユーザーがアクティブか。</span><span class="sxs-lookup"><span data-stu-id="468f6-119">Whether a user is active or not.</span></span> <span data-ttu-id="468f6-120">ユーザーを非アクティブとしてマークするには、このフィールドが必要です。</span><span class="sxs-lookup"><span data-stu-id="468f6-120">This field is required to mark a user as inactive.</span></span> <span data-ttu-id="468f6-121">既定では「アクティブ」です。</span><span class="sxs-lookup"><span data-stu-id="468f6-121">The default is "active".</span></span>| 
| <span data-ttu-id="468f6-122">配置</span><span class="sxs-lookup"><span data-stu-id="468f6-122">placement</span></span>| <span data-ttu-id="468f6-123">string</span><span class="sxs-lookup"><span data-stu-id="468f6-123">string</span></span>| <span data-ttu-id="468f6-124">タイトルの配置モードです。</span><span class="sxs-lookup"><span data-stu-id="468f6-124">The placement mode of the title.</span></span> <span data-ttu-id="468f6-125">設定可能な値には、「完全」、「入力と」、「スナップ」または"background"が含まれます。</span><span class="sxs-lookup"><span data-stu-id="468f6-125">Possible values include "full", "fill", "snapped", or "background".</span></span> <span data-ttu-id="468f6-126">既定値は、「完全」です。</span><span class="sxs-lookup"><span data-stu-id="468f6-126">The default is "full".</span></span>| 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="468f6-127">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="468f6-127">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="468f6-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="468f6-128">See also</span></span>
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a><span data-ttu-id="468f6-129">Parent</span><span class="sxs-lookup"><span data-stu-id="468f6-129">Parent</span></span> 

[<span data-ttu-id="468f6-130">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="468f6-130">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4E5C"></a>

 
##### <a name="reference"></a><span data-ttu-id="468f6-131">リファレンス</span><span class="sxs-lookup"><span data-stu-id="468f6-131">Reference</span></span> 

[<span data-ttu-id="468f6-132">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="468f6-132">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentpost.md)

   