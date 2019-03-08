---
title: TitleRecord (JSON)
assetID: 8e1bd699-e408-67c8-31da-2d968adfbc21
permalink: en-us/docs/xboxlive/rest/json-titlerecord.html
description: " TitleRecord (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 89baf7e9a737428d492246f1647a561a4a8170cf
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57603987"
---
# <a name="titlerecord-json"></a><span data-ttu-id="ac892-104">TitleRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="ac892-104">TitleRecord (JSON)</span></span>
<span data-ttu-id="ac892-105">タイトル、名前、最終変更タイムスタンプなどについて説明します。</span><span class="sxs-lookup"><span data-stu-id="ac892-105">Information about a title, including its name and a last-modified timestamp.</span></span> 
<a id="ID4EN"></a>

 
## <a name="titlerecord"></a><span data-ttu-id="ac892-106">TitleRecord</span><span class="sxs-lookup"><span data-stu-id="ac892-106">TitleRecord</span></span>
 
<span data-ttu-id="ac892-107">TitleRecord DeviceRecord、または、LastSeenRecord、含める必要がありますは含まれません。</span><span class="sxs-lookup"><span data-stu-id="ac892-107">A TitleRecord must contain a DeviceRecord or a LastSeenRecord, but may not contain both.</span></span>
 
<span data-ttu-id="ac892-108">TitleRecord オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="ac892-108">The TitleRecord object has the following specification.</span></span>
 
| <span data-ttu-id="ac892-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="ac892-109">Member</span></span>| <span data-ttu-id="ac892-110">種類</span><span class="sxs-lookup"><span data-stu-id="ac892-110">Type</span></span>| <span data-ttu-id="ac892-111">説明</span><span class="sxs-lookup"><span data-stu-id="ac892-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ac892-112">id</span><span class="sxs-lookup"><span data-stu-id="ac892-112">id</span></span>| <span data-ttu-id="ac892-113">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ac892-113">32-bit unsigned integer</span></span>| <span data-ttu-id="ac892-114">レコードのタイトルの Id。</span><span class="sxs-lookup"><span data-stu-id="ac892-114">TitleId of the record.</span></span>| 
| <span data-ttu-id="ac892-115">name</span><span class="sxs-lookup"><span data-stu-id="ac892-115">name</span></span>| <span data-ttu-id="ac892-116">string</span><span class="sxs-lookup"><span data-stu-id="ac892-116">string</span></span>| <span data-ttu-id="ac892-117">ローカライズされたタイトルの名前。</span><span class="sxs-lookup"><span data-stu-id="ac892-117">Localized name of the title.</span></span>| 
| <span data-ttu-id="ac892-118">activity (アクティビティ)</span><span class="sxs-lookup"><span data-stu-id="ac892-118">activity</span></span>| [<span data-ttu-id="ac892-119">ActivityRecord</span><span class="sxs-lookup"><span data-stu-id="ac892-119">ActivityRecord</span></span>](json-activityrecord.md)| <span data-ttu-id="ac892-120">タイトル内のユーザーのアクティビティ。</span><span class="sxs-lookup"><span data-stu-id="ac892-120">The activity of the user in the title.</span></span> <span data-ttu-id="ac892-121">深さが"all"かどうかにのみ返されます。</span><span class="sxs-lookup"><span data-stu-id="ac892-121">Only returned if depth is "all".</span></span>| 
| <span data-ttu-id="ac892-122">lastModified</span><span class="sxs-lookup"><span data-stu-id="ac892-122">lastModified</span></span>| <span data-ttu-id="ac892-123">DateTime</span><span class="sxs-lookup"><span data-stu-id="ac892-123">DateTime</span></span>| <span data-ttu-id="ac892-124">レコードが最後に更新されたときの UTC タイムスタンプ。</span><span class="sxs-lookup"><span data-stu-id="ac892-124">UTC timestamp when the record was last updated.</span></span>| 
| <span data-ttu-id="ac892-125">配置</span><span class="sxs-lookup"><span data-stu-id="ac892-125">placement</span></span>| <span data-ttu-id="ac892-126">string</span><span class="sxs-lookup"><span data-stu-id="ac892-126">string</span></span>| <span data-ttu-id="ac892-127">ユーザー インターフェイス内でアプリの場所。</span><span class="sxs-lookup"><span data-stu-id="ac892-127">The location of the app within the user interface.</span></span> <span data-ttu-id="ac892-128">可能性には、"fill"、"full"、「スナップ」または"background"が含まれます。</span><span class="sxs-lookup"><span data-stu-id="ac892-128">Possibilities include "fill", "full", "snapped", or "background".</span></span> <span data-ttu-id="ac892-129">既定では「完全」のデバイス アプリを配置することはできません。</span><span class="sxs-lookup"><span data-stu-id="ac892-129">The default is "full" for devices without the ability to place apps.</span></span>| 
| <span data-ttu-id="ac892-130">状態</span><span class="sxs-lookup"><span data-stu-id="ac892-130">state</span></span>| <span data-ttu-id="ac892-131">string</span><span class="sxs-lookup"><span data-stu-id="ac892-131">string</span></span>| <span data-ttu-id="ac892-132">タイトルの状態。</span><span class="sxs-lookup"><span data-stu-id="ac892-132">The state of the title.</span></span> <span data-ttu-id="ac892-133">"Active"または「非アクティブ」にすることができます (既定)。</span><span class="sxs-lookup"><span data-stu-id="ac892-133">Can be "active" or "inactive" (the default).</span></span> <span data-ttu-id="ac892-134">タイトルは、アクティビティおよび非アクティブ状態の基準に基づいて状態を設定します。</span><span class="sxs-lookup"><span data-stu-id="ac892-134">The title sets the state based on its own criteria for activity and inactivity.</span></span>| 
  
<a id="ID4E6C"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="ac892-135">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="ac892-135">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="ac892-136">関連項目</span><span class="sxs-lookup"><span data-stu-id="ac892-136">See also</span></span>
 
<a id="ID4EKD"></a>

 
##### <a name="parent"></a><span data-ttu-id="ac892-137">Parent</span><span class="sxs-lookup"><span data-stu-id="ac892-137">Parent</span></span> 

[<span data-ttu-id="ac892-138">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="ac892-138">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EUD"></a>

 
##### <a name="reference"></a><span data-ttu-id="ac892-139">リファレンス</span><span class="sxs-lookup"><span data-stu-id="ac892-139">Reference</span></span> 

[<span data-ttu-id="ac892-140">POST (/users/xuid({xuid})/devices/current/titles/current)</span><span class="sxs-lookup"><span data-stu-id="ac892-140">POST (/users/xuid({xuid})/devices/current/titles/current)</span></span>](../uri/presence/uri-usersxuiddevicescurrenttitlescurrentpost.md)

   