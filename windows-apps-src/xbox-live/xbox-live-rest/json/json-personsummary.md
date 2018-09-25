---
title: PersonSummary (JSON)
assetID: 22fedb5f-5602-98d8-04a6-786fe3905921
permalink: en-us/docs/xboxlive/rest/json-personsummary.html
author: KevinAsgari
description: " PersonSummary (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: cb093f624d27f28cace771896cf52146059bc332
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4181166"
---
# <a name="personsummary-json"></a><span data-ttu-id="23bdf-104">PersonSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="23bdf-104">PersonSummary (JSON)</span></span>
<span data-ttu-id="23bdf-105">[ユーザー (JSON)](json-person.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="23bdf-105">Collection of [Person (JSON)](json-person.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="personsummary"></a><span data-ttu-id="23bdf-106">PersonSummary</span><span class="sxs-lookup"><span data-stu-id="23bdf-106">PersonSummary</span></span>
 
<span data-ttu-id="23bdf-107">PersonSummary オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="23bdf-107">The PersonSummary object has the following specification.</span></span>
 
| <span data-ttu-id="23bdf-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="23bdf-108">Member</span></span>| <span data-ttu-id="23bdf-109">種類</span><span class="sxs-lookup"><span data-stu-id="23bdf-109">Type</span></span>| <span data-ttu-id="23bdf-110">説明</span><span class="sxs-lookup"><span data-stu-id="23bdf-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="23bdf-111">hasCallerMarkedTargetAsFavorite</span><span class="sxs-lookup"><span data-stu-id="23bdf-111">hasCallerMarkedTargetAsFavorite</span></span>| <span data-ttu-id="23bdf-112">ブール値</span><span class="sxs-lookup"><span data-stu-id="23bdf-112">Boolean value</span></span>| <span data-ttu-id="23bdf-113">かどうか、呼び出し元は、お気に入りとしてターゲットをマークします。</span><span class="sxs-lookup"><span data-stu-id="23bdf-113">Whether the caller has marked the target as a favorite.</span></span> <span data-ttu-id="23bdf-114">値の例: true</span><span class="sxs-lookup"><span data-stu-id="23bdf-114">Example values: true</span></span>| 
| <span data-ttu-id="23bdf-115">hasCallerMarkedTargetAsKnown</span><span class="sxs-lookup"><span data-stu-id="23bdf-115">hasCallerMarkedTargetAsKnown</span></span>| <span data-ttu-id="23bdf-116">ブール値</span><span class="sxs-lookup"><span data-stu-id="23bdf-116">Boolean value</span></span>| <span data-ttu-id="23bdf-117">かどうか、呼び出し元がターゲット済みとしてマーク呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="23bdf-117">Whether the caller has marked the target as known.</span></span> <span data-ttu-id="23bdf-118">値の例: true</span><span class="sxs-lookup"><span data-stu-id="23bdf-118">Example values: true</span></span>| 
| <span data-ttu-id="23bdf-119">isCallerFollowingTarget</span><span class="sxs-lookup"><span data-stu-id="23bdf-119">isCallerFollowingTarget</span></span>| <span data-ttu-id="23bdf-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="23bdf-120">Boolean value</span></span>| <span data-ttu-id="23bdf-121">かどうか、呼び出し元が、ターゲットをフォローします。</span><span class="sxs-lookup"><span data-stu-id="23bdf-121">Whether the caller is following the target.</span></span> <span data-ttu-id="23bdf-122">値の例: true</span><span class="sxs-lookup"><span data-stu-id="23bdf-122">Example values: true</span></span>| 
| <span data-ttu-id="23bdf-123">isTargetFollowingCaller</span><span class="sxs-lookup"><span data-stu-id="23bdf-123">isTargetFollowingCaller</span></span>| <span data-ttu-id="23bdf-124">ブール値</span><span class="sxs-lookup"><span data-stu-id="23bdf-124">Boolean value</span></span>| <span data-ttu-id="23bdf-125">かどうか、ターゲットでは、呼び出し元がフォローします。</span><span class="sxs-lookup"><span data-stu-id="23bdf-125">Whether the target is following the caller.</span></span> <span data-ttu-id="23bdf-126">値の例: true</span><span class="sxs-lookup"><span data-stu-id="23bdf-126">Example values: true</span></span>| 
| <span data-ttu-id="23bdf-127">legacyFriendStatus</span><span class="sxs-lookup"><span data-stu-id="23bdf-127">legacyFriendStatus</span></span>| <span data-ttu-id="23bdf-128">string</span><span class="sxs-lookup"><span data-stu-id="23bdf-128">string</span></span>| <span data-ttu-id="23bdf-129">従来のフレンドのように、呼び出し元のターゲット状態です。</span><span class="sxs-lookup"><span data-stu-id="23bdf-129">Legacy friend status of the target as seen by the caller.</span></span> <span data-ttu-id="23bdf-130">"None"、"MutuallyAccepted"、"OutgoingRequest"または"IncomingRequest"をすることができます。</span><span class="sxs-lookup"><span data-stu-id="23bdf-130">Can be "None", "MutuallyAccepted", "OutgoingRequest", or "IncomingRequest".</span></span> <span data-ttu-id="23bdf-131">値の例:"MutuallyAccepted"</span><span class="sxs-lookup"><span data-stu-id="23bdf-131">Example values: "MutuallyAccepted"</span></span>| 
| <span data-ttu-id="23bdf-132">recentChangeCount</span><span class="sxs-lookup"><span data-stu-id="23bdf-132">recentChangeCount</span></span>| <span data-ttu-id="23bdf-133">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="23bdf-133">32-bit unsigned integer</span></span>| <span data-ttu-id="23bdf-134">省略可能。</span><span class="sxs-lookup"><span data-stu-id="23bdf-134">Optional.</span></span> <span data-ttu-id="23bdf-135">ターゲットのソーシャル グラフの最新の変更の数です。</span><span class="sxs-lookup"><span data-stu-id="23bdf-135">Number of recent changes in the target's social graph.</span></span> <span data-ttu-id="23bdf-136">この値は、ユーザーが、独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="23bdf-136">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="23bdf-137">値の例: 5</span><span class="sxs-lookup"><span data-stu-id="23bdf-137">Example values: 5</span></span>| 
| <span data-ttu-id="23bdf-138">targetFollowerCount</span><span class="sxs-lookup"><span data-stu-id="23bdf-138">targetFollowerCount</span></span>| <span data-ttu-id="23bdf-139">> 32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="23bdf-139">>32-bit unsigned integer</span></span>| <span data-ttu-id="23bdf-140">次のターゲットはユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="23bdf-140">Number of People that are following the target.</span></span> <span data-ttu-id="23bdf-141">値の例: 1308</span><span class="sxs-lookup"><span data-stu-id="23bdf-141">Example values: 1308</span></span>| 
| <span data-ttu-id="23bdf-142">targetFollowingCount</span><span class="sxs-lookup"><span data-stu-id="23bdf-142">targetFollowingCount</span></span>| <span data-ttu-id="23bdf-143">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="23bdf-143">32-bit unsigned integer</span></span>| <span data-ttu-id="23bdf-144">ターゲットが次のユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="23bdf-144">Number of People that the target is following.</span></span> <span data-ttu-id="23bdf-145">値の例: 112</span><span class="sxs-lookup"><span data-stu-id="23bdf-145">Example values: 112</span></span>| 
| <span data-ttu-id="23bdf-146">透かし</span><span class="sxs-lookup"><span data-stu-id="23bdf-146">watermark</span></span>| <span data-ttu-id="23bdf-147">string</span><span class="sxs-lookup"><span data-stu-id="23bdf-147">string</span></span>| <span data-ttu-id="23bdf-148">省略可能。</span><span class="sxs-lookup"><span data-stu-id="23bdf-148">Optional.</span></span> <span data-ttu-id="23bdf-149">ターゲットの最新の変更透かし</span><span class="sxs-lookup"><span data-stu-id="23bdf-149">Recent change watermark for the target.</span></span> <span data-ttu-id="23bdf-150">この値は、ユーザーが、独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="23bdf-150">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="23bdf-151">値の例: 5</span><span class="sxs-lookup"><span data-stu-id="23bdf-151">Example values: 5</span></span>| 
  
<a id="ID4E4D"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="23bdf-152">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="23bdf-152">Sample JSON syntax</span></span>
 

```json
{
    "targetFollowingCount": 87,
    "targetFollowerCount": 19,
    "isCallerFollowingTarget": true,
    "isTargetFollowingCaller": false,
    "hasCallerMarkedTargetAsFavorite": true,
    "hasCallerMarkedTargetAsKnown": true,
    "legacyFriendStatus": "None",
    "recentChangeCount": 5,
    "watermark": "5246775845000319351"
}
    
```

  
<a id="ID4EGE"></a>

 
## <a name="see-also"></a><span data-ttu-id="23bdf-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="23bdf-153">See also</span></span>
 
<a id="ID4EIE"></a>

 
##### <a name="parent"></a><span data-ttu-id="23bdf-154">Parent</span><span class="sxs-lookup"><span data-stu-id="23bdf-154">Parent</span></span> 

[<span data-ttu-id="23bdf-155">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="23bdf-155">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   