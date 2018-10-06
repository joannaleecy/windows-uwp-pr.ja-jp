---
title: MultiplayerActivityDetails (JSON)
assetID: f982aa5e-2694-4ef9-bc55-6c099a3cf9ec
permalink: en-us/docs/xboxlive/rest/json-multiplayeractivitydetails.html
author: KevinAsgari
description: " MultiplayerActivityDetails (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4de72a24c34af1a5f145c44b2acfa11a7bd07f95
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4388073"
---
# <a name="multiplayeractivitydetails-json"></a><span data-ttu-id="33741-104">MultiplayerActivityDetails (JSON)</span><span class="sxs-lookup"><span data-stu-id="33741-104">MultiplayerActivityDetails (JSON)</span></span>
<span data-ttu-id="33741-105">**Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="33741-105">A JSON object representing the **Microsoft.Xbox.Services.Multiplayer.MultiplayerActivityDetails**.</span></span> 

> [!NOTE] 
> <span data-ttu-id="33741-106">このオブジェクトは、2015年マルチプレイヤーで実装され、以降そのマルチプレイヤーのバージョンにのみ適用されます。</span><span class="sxs-lookup"><span data-stu-id="33741-106">This object is implemented by the 2015 Multiplayer and applies only to that multiplayer version and later.</span></span> <span data-ttu-id="33741-107">テンプレート コントラクト 104/105 以降で使用する概念があることです。</span><span class="sxs-lookup"><span data-stu-id="33741-107">It is intended for use with template contract 104/105 or later.</span></span>  

 
<a id="ID4ES"></a>

  
 
<span data-ttu-id="33741-108">MultiplayerActivityDetails JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="33741-108">The MultiplayerActivityDetails JSON object has the following specification.</span></span>
 
| <span data-ttu-id="33741-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="33741-109">Member</span></span>| <span data-ttu-id="33741-110">種類</span><span class="sxs-lookup"><span data-stu-id="33741-110">Type</span></span>| <span data-ttu-id="33741-111">説明</span><span class="sxs-lookup"><span data-stu-id="33741-111">Description</span></span>| 
| --- | --- | --- | --- | 
| <span data-ttu-id="33741-112">SessionReference</span><span class="sxs-lookup"><span data-stu-id="33741-112">SessionReference</span></span>| <span data-ttu-id="33741-113">MultiplayerSessionReference</span><span class="sxs-lookup"><span data-stu-id="33741-113">MultiplayerSessionReference</span></span>| <span data-ttu-id="33741-114">セッションの識別情報を表す<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference</b>オブジェクトを返します。</span><span class="sxs-lookup"><span data-stu-id="33741-114">A <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionReference</b> object representing identifying information for the session.</span></span>| 
| <span data-ttu-id="33741-115">ハンドル id を使用</span><span class="sxs-lookup"><span data-stu-id="33741-115">HandleId</span></span>| <span data-ttu-id="33741-116">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="33741-116">64-bit unsigned integer</span></span>| <span data-ttu-id="33741-117">アクティビティに対応するハンドル ID。</span><span class="sxs-lookup"><span data-stu-id="33741-117">The handle ID corresponding to the activity.</span></span>| 
| <span data-ttu-id="33741-118">TitleId</span><span class="sxs-lookup"><span data-stu-id="33741-118">TitleId</span></span>| <span data-ttu-id="33741-119">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="33741-119">32-bit unsigned integer</span></span>| <span data-ttu-id="33741-120">タイトル ID は、アクティビティに参加するために起動する必要があります。</span><span class="sxs-lookup"><span data-stu-id="33741-120">The title ID that should be launched in order to join the activity.</span></span>| 
| <span data-ttu-id="33741-121">表示</span><span class="sxs-lookup"><span data-stu-id="33741-121">Visibility</span></span>| <span data-ttu-id="33741-122">MultiplayerSessionVisibility</span><span class="sxs-lookup"><span data-stu-id="33741-122">MultiplayerSessionVisibility</span></span>| <span data-ttu-id="33741-123">セッションの可視性の状態を示す<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b>値。</span><span class="sxs-lookup"><span data-stu-id="33741-123">A <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionVisibility</b> value indicating the visibility state of the session.</span></span>| 
| <span data-ttu-id="33741-124">による</span><span class="sxs-lookup"><span data-stu-id="33741-124">JoinRestriction</span></span>| <span data-ttu-id="33741-125">MultiplayerSessionJoinRestriction</span><span class="sxs-lookup"><span data-stu-id="33741-125">MultiplayerSessionJoinRestriction</span></span>| <span data-ttu-id="33741-126">セッションの参加制限を示す<b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionJoinRestriction</b>値。</span><span class="sxs-lookup"><span data-stu-id="33741-126">A <b>Microsoft.Xbox.Services.Multiplayer.MultiplayerSessionJoinRestriction</b> value indicating the join restriction for the session.</span></span> <span data-ttu-id="33741-127">表示のフィールドが「開く」に設定されている場合、この制限が適用されます。</span><span class="sxs-lookup"><span data-stu-id="33741-127">This restriction applies if the visiblity field is set to "open".</span></span>| 
| <span data-ttu-id="33741-128">終了</span><span class="sxs-lookup"><span data-stu-id="33741-128">Closed</span></span>| <span data-ttu-id="33741-129">ブール値</span><span class="sxs-lookup"><span data-stu-id="33741-129">Boolean value</span></span>| <span data-ttu-id="33741-130">セッションが一時的に閉じている場合、参加するため、false それ以外の場合は true。</span><span class="sxs-lookup"><span data-stu-id="33741-130">True if the session is temporarily closed for joining, and false otherwise.</span></span>| 
| <span data-ttu-id="33741-131">OwnerXboxUserId</span><span class="sxs-lookup"><span data-stu-id="33741-131">OwnerXboxUserId</span></span>| <span data-ttu-id="33741-132">64 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="33741-132">64-bit unsigned integer</span></span>| <span data-ttu-id="33741-133">アクティビティを所有しているメンバーの Xbox ユーザー ID。</span><span class="sxs-lookup"><span data-stu-id="33741-133">Xbox user ID of the member who owns the activity.</span></span>| 
| <span data-ttu-id="33741-134">MaxMembersCount</span><span class="sxs-lookup"><span data-stu-id="33741-134">MaxMembersCount</span></span>| <span data-ttu-id="33741-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="33741-135">32-bit unsigned integer</span></span>| <span data-ttu-id="33741-136">スロットの合計数。</span><span class="sxs-lookup"><span data-stu-id="33741-136">Number of total slots.</span></span>| 
| <span data-ttu-id="33741-137">MembersCount</span><span class="sxs-lookup"><span data-stu-id="33741-137">MembersCount</span></span>| <span data-ttu-id="33741-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="33741-138">32-bit unsigned integer</span></span>| <span data-ttu-id="33741-139">スロットを占有の数。</span><span class="sxs-lookup"><span data-stu-id="33741-139">Number of slots occupied.</span></span>| 
  
<a id="ID4E3D"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="33741-140">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="33741-140">Sample JSON syntax</span></span>
 

```json
{
  "results": [{
    "id": "11111111-ebe0-42da-885f-033860a818f6",
    "type": "activity",
    "version": 1,
    "sessionRef": {
      "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
      "templateName": "party",
      "name": "e3a836aeac6f4cbe9bcab985494d3175"
    },
    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
    "relatedInfo": {
      "visibility": "open",
      "joinRestriction": "followed",
      "closed": true,
      "maxMembersCount": 8,
      "membersCount": 4,
    }
  },
  {
    "id": "11111111-ebe0-42da-885f-033860a818f7",
    "type": "activity",
    "version": 1,
    "sessionRef": {
      "scid": "8dfb0100-ebe0-42da-885f-033860a818f6",
      "templateName": "TitleStorageTestDefault",
      "name": "795fcaa7-8377-4281-bd7e-e86c12843632"
    },
    "titleId": "1234567",
    "ownerXuid": "3212",

    // Only if ?include=relatedInfo
    "relatedInfo": {
      "visibility": "open",
      "joinRestriction": "followed",
      "closed": false,
      "maxMembersCount": 8,
      "membersCount": 4,
    }
  }]
}
    
```

  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a><span data-ttu-id="33741-141">関連項目</span><span class="sxs-lookup"><span data-stu-id="33741-141">See also</span></span>
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a><span data-ttu-id="33741-142">Parent</span><span class="sxs-lookup"><span data-stu-id="33741-142">Parent</span></span> 

[<span data-ttu-id="33741-143">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="33741-143">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   