---
title: TitleRecord (JSON)
assetID: 8e1bd699-e408-67c8-31da-2d968adfbc21
permalink: en-us/docs/xboxlive/rest/json-titlerecord.html
author: KevinAsgari
description: " TitleRecord (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4e7fb10a0f81e24215ebc24d2545f1197d4520bc
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4501226"
---
# <a name="titlerecord-json"></a><span data-ttu-id="36998-104">TitleRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="36998-104">TitleRecord (JSON)</span></span>
<span data-ttu-id="36998-105">最終更新タイムスタンプとその名前を含む、タイトルに関する情報。</span><span class="sxs-lookup"><span data-stu-id="36998-105">Information about a title, including its name and a last-modified timestamp.</span></span> 
<a id="ID4EN"></a>

 
## <a name="titlerecord"></a><span data-ttu-id="36998-106">TitleRecord</span><span class="sxs-lookup"><span data-stu-id="36998-106">TitleRecord</span></span>
 
<span data-ttu-id="36998-107">TitleRecord、DeviceRecord または、LastSeenRecord を含める必要がありますが、両方を含めない場合があります。</span><span class="sxs-lookup"><span data-stu-id="36998-107">A TitleRecord must contain a DeviceRecord or a LastSeenRecord, but may not contain both.</span></span>
 
<span data-ttu-id="36998-108">TitleRecord オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="36998-108">The TitleRecord object has the following specification.</span></span>
 
| <span data-ttu-id="36998-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="36998-109">Member</span></span>| <span data-ttu-id="36998-110">種類</span><span class="sxs-lookup"><span data-stu-id="36998-110">Type</span></span>| <span data-ttu-id="36998-111">説明</span><span class="sxs-lookup"><span data-stu-id="36998-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="36998-112">id</span><span class="sxs-lookup"><span data-stu-id="36998-112">id</span></span>| <span data-ttu-id="36998-113">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="36998-113">32-bit unsigned integer</span></span>| <span data-ttu-id="36998-114">レコードのタイトル Id。</span><span class="sxs-lookup"><span data-stu-id="36998-114">TitleId of the record.</span></span>| 
| <span data-ttu-id="36998-115">name</span><span class="sxs-lookup"><span data-stu-id="36998-115">name</span></span>| <span data-ttu-id="36998-116">string</span><span class="sxs-lookup"><span data-stu-id="36998-116">string</span></span>| <span data-ttu-id="36998-117">タイトルのローカライズされた名前です。</span><span class="sxs-lookup"><span data-stu-id="36998-117">Localized name of the title.</span></span>| 
| <span data-ttu-id="36998-118">activity (アクティビティ)</span><span class="sxs-lookup"><span data-stu-id="36998-118">activity</span></span>| [<span data-ttu-id="36998-119">ActivityRecord</span><span class="sxs-lookup"><span data-stu-id="36998-119">ActivityRecord</span></span>](json-activityrecord.md)| <span data-ttu-id="36998-120">タイトルでのユーザーのアクティビティ。</span><span class="sxs-lookup"><span data-stu-id="36998-120">The activity of the user in the title.</span></span> <span data-ttu-id="36998-121">のみ深度"all"が返されます。</span><span class="sxs-lookup"><span data-stu-id="36998-121">Only returned if depth is "all".</span></span>| 
| <span data-ttu-id="36998-122">lastModified</span><span class="sxs-lookup"><span data-stu-id="36998-122">lastModified</span></span>| <span data-ttu-id="36998-123">DateTime</span><span class="sxs-lookup"><span data-stu-id="36998-123">DateTime</span></span>| <span data-ttu-id="36998-124">レコードが最後に更新されたときにタイムスタンプを UTC です。</span><span class="sxs-lookup"><span data-stu-id="36998-124">UTC timestamp when the record was last updated.</span></span>| 
| <span data-ttu-id="36998-125">配置</span><span class="sxs-lookup"><span data-stu-id="36998-125">placement</span></span>| <span data-ttu-id="36998-126">string</span><span class="sxs-lookup"><span data-stu-id="36998-126">string</span></span>| <span data-ttu-id="36998-127">ユーザー インターフェイス内でアプリの場所です。</span><span class="sxs-lookup"><span data-stu-id="36998-127">The location of the app within the user interface.</span></span> <span data-ttu-id="36998-128">可能性には、"fill"、「完全」、「スナップ」または"background"が含まれます。</span><span class="sxs-lookup"><span data-stu-id="36998-128">Possibilities include "fill", "full", "snapped", or "background".</span></span> <span data-ttu-id="36998-129">既定値は、アプリを配置することができないデバイスの「完全」です。</span><span class="sxs-lookup"><span data-stu-id="36998-129">The default is "full" for devices without the ability to place apps.</span></span>| 
| <span data-ttu-id="36998-130">状態</span><span class="sxs-lookup"><span data-stu-id="36998-130">state</span></span>| <span data-ttu-id="36998-131">string</span><span class="sxs-lookup"><span data-stu-id="36998-131">string</span></span>| <span data-ttu-id="36998-132">タイトルの状態。</span><span class="sxs-lookup"><span data-stu-id="36998-132">The state of the title.</span></span> <span data-ttu-id="36998-133">「アクティブ」や「非アクティブ」にすることができます (既定)。</span><span class="sxs-lookup"><span data-stu-id="36998-133">Can be "active" or "inactive" (the default).</span></span> <span data-ttu-id="36998-134">タイトルは、アクティビティおよび非アクティブの独自の基準に基づいて状態を設定します。</span><span class="sxs-lookup"><span data-stu-id="36998-134">The title sets the state based on its own criteria for activity and inactivity.</span></span>| 
  
<a id="ID4E6C"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="36998-135">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="36998-135">Sample JSON syntax</span></span>
 

```json
{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    }
    
```

  
<a id="ID4EID"></a>

 
## <a name="see-also"></a><span data-ttu-id="36998-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="36998-136">See also</span></span>
 
<a id="ID4EKD"></a>

 
##### <a name="parent"></a><span data-ttu-id="36998-137">Parent</span><span class="sxs-lookup"><span data-stu-id="36998-137">Parent</span></span> 

[<span data-ttu-id="36998-138">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="36998-138">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUD"></a>

 
##### <a name="reference"></a><span data-ttu-id="36998-139">リファレンス</span><span class="sxs-lookup"><span data-stu-id="36998-139">Reference</span></span> 

[<span data-ttu-id="36998-140">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="36998-140">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentpost.md)

   