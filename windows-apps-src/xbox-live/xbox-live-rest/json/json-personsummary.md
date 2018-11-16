---
title: PersonSummary (JSON)
assetID: 22fedb5f-5602-98d8-04a6-786fe3905921
permalink: en-us/docs/xboxlive/rest/json-personsummary.html
author: KevinAsgari
description: " PersonSummary (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 33b1cb2adaafba2370e27eb98a10a5143166f0ce
ms.sourcegitcommit: e38b334edb82bf2b1474ba686990f4299b8f59c7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/14/2018
ms.locfileid: "6834591"
---
# <a name="personsummary-json"></a><span data-ttu-id="cb976-104">PersonSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="cb976-104">PersonSummary (JSON)</span></span>
<span data-ttu-id="cb976-105">[ユーザー (JSON)](json-person.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="cb976-105">Collection of [Person (JSON)](json-person.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="personsummary"></a><span data-ttu-id="cb976-106">PersonSummary</span><span class="sxs-lookup"><span data-stu-id="cb976-106">PersonSummary</span></span>
 
<span data-ttu-id="cb976-107">PersonSummary オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="cb976-107">The PersonSummary object has the following specification.</span></span>
 
| <span data-ttu-id="cb976-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="cb976-108">Member</span></span>| <span data-ttu-id="cb976-109">種類</span><span class="sxs-lookup"><span data-stu-id="cb976-109">Type</span></span>| <span data-ttu-id="cb976-110">説明</span><span class="sxs-lookup"><span data-stu-id="cb976-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cb976-111">hasCallerMarkedTargetAsFavorite</span><span class="sxs-lookup"><span data-stu-id="cb976-111">hasCallerMarkedTargetAsFavorite</span></span>| <span data-ttu-id="cb976-112">ブール値</span><span class="sxs-lookup"><span data-stu-id="cb976-112">Boolean value</span></span>| <span data-ttu-id="cb976-113">かどうか、呼び出し元は、お気に入りとしてターゲットをマークします。</span><span class="sxs-lookup"><span data-stu-id="cb976-113">Whether the caller has marked the target as a favorite.</span></span> <span data-ttu-id="cb976-114">値の例: true</span><span class="sxs-lookup"><span data-stu-id="cb976-114">Example values: true</span></span>| 
| <span data-ttu-id="cb976-115">hasCallerMarkedTargetAsKnown</span><span class="sxs-lookup"><span data-stu-id="cb976-115">hasCallerMarkedTargetAsKnown</span></span>| <span data-ttu-id="cb976-116">ブール値</span><span class="sxs-lookup"><span data-stu-id="cb976-116">Boolean value</span></span>| <span data-ttu-id="cb976-117">かどうか、呼び出し元が、ターゲット済みとしてマーク呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="cb976-117">Whether the caller has marked the target as known.</span></span> <span data-ttu-id="cb976-118">値の例: true</span><span class="sxs-lookup"><span data-stu-id="cb976-118">Example values: true</span></span>| 
| <span data-ttu-id="cb976-119">isCallerFollowingTarget</span><span class="sxs-lookup"><span data-stu-id="cb976-119">isCallerFollowingTarget</span></span>| <span data-ttu-id="cb976-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="cb976-120">Boolean value</span></span>| <span data-ttu-id="cb976-121">かどうか、呼び出し元が、ターゲットをフォローします。</span><span class="sxs-lookup"><span data-stu-id="cb976-121">Whether the caller is following the target.</span></span> <span data-ttu-id="cb976-122">値の例: true</span><span class="sxs-lookup"><span data-stu-id="cb976-122">Example values: true</span></span>| 
| <span data-ttu-id="cb976-123">isTargetFollowingCaller</span><span class="sxs-lookup"><span data-stu-id="cb976-123">isTargetFollowingCaller</span></span>| <span data-ttu-id="cb976-124">ブール値</span><span class="sxs-lookup"><span data-stu-id="cb976-124">Boolean value</span></span>| <span data-ttu-id="cb976-125">かどうか、ターゲットでは、呼び出し元がフォローします。</span><span class="sxs-lookup"><span data-stu-id="cb976-125">Whether the target is following the caller.</span></span> <span data-ttu-id="cb976-126">値の例: true</span><span class="sxs-lookup"><span data-stu-id="cb976-126">Example values: true</span></span>| 
| <span data-ttu-id="cb976-127">legacyFriendStatus</span><span class="sxs-lookup"><span data-stu-id="cb976-127">legacyFriendStatus</span></span>| <span data-ttu-id="cb976-128">string</span><span class="sxs-lookup"><span data-stu-id="cb976-128">string</span></span>| <span data-ttu-id="cb976-129">従来のフレンドのように、呼び出し元のターゲット状態です。</span><span class="sxs-lookup"><span data-stu-id="cb976-129">Legacy friend status of the target as seen by the caller.</span></span> <span data-ttu-id="cb976-130">"None"、"MutuallyAccepted"、"OutgoingRequest"または"IncomingRequest"をすることができます。</span><span class="sxs-lookup"><span data-stu-id="cb976-130">Can be "None", "MutuallyAccepted", "OutgoingRequest", or "IncomingRequest".</span></span> <span data-ttu-id="cb976-131">値の例:"MutuallyAccepted"</span><span class="sxs-lookup"><span data-stu-id="cb976-131">Example values: "MutuallyAccepted"</span></span>| 
| <span data-ttu-id="cb976-132">recentChangeCount</span><span class="sxs-lookup"><span data-stu-id="cb976-132">recentChangeCount</span></span>| <span data-ttu-id="cb976-133">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="cb976-133">32-bit unsigned integer</span></span>| <span data-ttu-id="cb976-134">省略可能。</span><span class="sxs-lookup"><span data-stu-id="cb976-134">Optional.</span></span> <span data-ttu-id="cb976-135">ターゲットのソーシャル グラフ内の最新の変更の数です。</span><span class="sxs-lookup"><span data-stu-id="cb976-135">Number of recent changes in the target's social graph.</span></span> <span data-ttu-id="cb976-136">この値は、ユーザーが、独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="cb976-136">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="cb976-137">値の例: 5</span><span class="sxs-lookup"><span data-stu-id="cb976-137">Example values: 5</span></span>| 
| <span data-ttu-id="cb976-138">targetFollowerCount</span><span class="sxs-lookup"><span data-stu-id="cb976-138">targetFollowerCount</span></span>| <span data-ttu-id="cb976-139">> 32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="cb976-139">>32-bit unsigned integer</span></span>| <span data-ttu-id="cb976-140">次のターゲットはユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="cb976-140">Number of People that are following the target.</span></span> <span data-ttu-id="cb976-141">値の例: 1308</span><span class="sxs-lookup"><span data-stu-id="cb976-141">Example values: 1308</span></span>| 
| <span data-ttu-id="cb976-142">targetFollowingCount</span><span class="sxs-lookup"><span data-stu-id="cb976-142">targetFollowingCount</span></span>| <span data-ttu-id="cb976-143">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="cb976-143">32-bit unsigned integer</span></span>| <span data-ttu-id="cb976-144">ターゲットが次のユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="cb976-144">Number of People that the target is following.</span></span> <span data-ttu-id="cb976-145">値の例: 112</span><span class="sxs-lookup"><span data-stu-id="cb976-145">Example values: 112</span></span>| 
| <span data-ttu-id="cb976-146">透かし</span><span class="sxs-lookup"><span data-stu-id="cb976-146">watermark</span></span>| <span data-ttu-id="cb976-147">string</span><span class="sxs-lookup"><span data-stu-id="cb976-147">string</span></span>| <span data-ttu-id="cb976-148">省略可能。</span><span class="sxs-lookup"><span data-stu-id="cb976-148">Optional.</span></span> <span data-ttu-id="cb976-149">ターゲットの最新の変更透かし</span><span class="sxs-lookup"><span data-stu-id="cb976-149">Recent change watermark for the target.</span></span> <span data-ttu-id="cb976-150">この値は、ユーザーが、独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="cb976-150">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="cb976-151">値の例: 5</span><span class="sxs-lookup"><span data-stu-id="cb976-151">Example values: 5</span></span>| 
  
<a id="ID4E4D"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="cb976-152">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="cb976-152">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="cb976-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="cb976-153">See also</span></span>
 
<a id="ID4EIE"></a>

 
##### <a name="parent"></a><span data-ttu-id="cb976-154">Parent</span><span class="sxs-lookup"><span data-stu-id="cb976-154">Parent</span></span> 

[<span data-ttu-id="cb976-155">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="cb976-155">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   