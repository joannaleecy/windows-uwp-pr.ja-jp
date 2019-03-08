---
title: PersonSummary (JSON)
assetID: 22fedb5f-5602-98d8-04a6-786fe3905921
permalink: en-us/docs/xboxlive/rest/json-personsummary.html
description: " PersonSummary (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a787992507405a70185140e879be731d72806eff
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57612627"
---
# <a name="personsummary-json"></a><span data-ttu-id="12175-104">PersonSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="12175-104">PersonSummary (JSON)</span></span>
<span data-ttu-id="12175-105">コレクション[人 (JSON)](json-person.md)オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="12175-105">Collection of [Person (JSON)](json-person.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="personsummary"></a><span data-ttu-id="12175-106">PersonSummary</span><span class="sxs-lookup"><span data-stu-id="12175-106">PersonSummary</span></span>
 
<span data-ttu-id="12175-107">PersonSummary オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="12175-107">The PersonSummary object has the following specification.</span></span>
 
| <span data-ttu-id="12175-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="12175-108">Member</span></span>| <span data-ttu-id="12175-109">種類</span><span class="sxs-lookup"><span data-stu-id="12175-109">Type</span></span>| <span data-ttu-id="12175-110">説明</span><span class="sxs-lookup"><span data-stu-id="12175-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="12175-111">hasCallerMarkedTargetAsFavorite</span><span class="sxs-lookup"><span data-stu-id="12175-111">hasCallerMarkedTargetAsFavorite</span></span>| <span data-ttu-id="12175-112">ブール値</span><span class="sxs-lookup"><span data-stu-id="12175-112">Boolean value</span></span>| <span data-ttu-id="12175-113">かどうか、呼び出し元が、ターゲットは、お気に入りとしてマークしました。</span><span class="sxs-lookup"><span data-stu-id="12175-113">Whether the caller has marked the target as a favorite.</span></span> <span data-ttu-id="12175-114">例の値: true</span><span class="sxs-lookup"><span data-stu-id="12175-114">Example values: true</span></span>| 
| <span data-ttu-id="12175-115">hasCallerMarkedTargetAsKnown</span><span class="sxs-lookup"><span data-stu-id="12175-115">hasCallerMarkedTargetAsKnown</span></span>| <span data-ttu-id="12175-116">ブール値</span><span class="sxs-lookup"><span data-stu-id="12175-116">Boolean value</span></span>| <span data-ttu-id="12175-117">かどうか、呼び出し元がマーク ターゲットと呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="12175-117">Whether the caller has marked the target as known.</span></span> <span data-ttu-id="12175-118">例の値: true</span><span class="sxs-lookup"><span data-stu-id="12175-118">Example values: true</span></span>| 
| <span data-ttu-id="12175-119">isCallerFollowingTarget</span><span class="sxs-lookup"><span data-stu-id="12175-119">isCallerFollowingTarget</span></span>| <span data-ttu-id="12175-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="12175-120">Boolean value</span></span>| <span data-ttu-id="12175-121">かどうか、呼び出し元が、ターゲットをフォローします。</span><span class="sxs-lookup"><span data-stu-id="12175-121">Whether the caller is following the target.</span></span> <span data-ttu-id="12175-122">例の値: true</span><span class="sxs-lookup"><span data-stu-id="12175-122">Example values: true</span></span>| 
| <span data-ttu-id="12175-123">isTargetFollowingCaller</span><span class="sxs-lookup"><span data-stu-id="12175-123">isTargetFollowingCaller</span></span>| <span data-ttu-id="12175-124">ブール値</span><span class="sxs-lookup"><span data-stu-id="12175-124">Boolean value</span></span>| <span data-ttu-id="12175-125">かどうか、ターゲットが呼び出し元をフォローします。</span><span class="sxs-lookup"><span data-stu-id="12175-125">Whether the target is following the caller.</span></span> <span data-ttu-id="12175-126">例の値: true</span><span class="sxs-lookup"><span data-stu-id="12175-126">Example values: true</span></span>| 
| <span data-ttu-id="12175-127">legacyFriendStatus</span><span class="sxs-lookup"><span data-stu-id="12175-127">legacyFriendStatus</span></span>| <span data-ttu-id="12175-128">string</span><span class="sxs-lookup"><span data-stu-id="12175-128">string</span></span>| <span data-ttu-id="12175-129">呼び出し側から見た対象の状態を従来のフレンドです。</span><span class="sxs-lookup"><span data-stu-id="12175-129">Legacy friend status of the target as seen by the caller.</span></span> <span data-ttu-id="12175-130">"None"、"MutuallyAccepted"、"OutgoingRequest"または"IncomingRequest"を指定できます。</span><span class="sxs-lookup"><span data-stu-id="12175-130">Can be "None", "MutuallyAccepted", "OutgoingRequest", or "IncomingRequest".</span></span> <span data-ttu-id="12175-131">値の例:"MutuallyAccepted"</span><span class="sxs-lookup"><span data-stu-id="12175-131">Example values: "MutuallyAccepted"</span></span>| 
| <span data-ttu-id="12175-132">recentChangeCount</span><span class="sxs-lookup"><span data-stu-id="12175-132">recentChangeCount</span></span>| <span data-ttu-id="12175-133">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="12175-133">32-bit unsigned integer</span></span>| <span data-ttu-id="12175-134">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="12175-134">Optional.</span></span> <span data-ttu-id="12175-135">ターゲットのソーシャル グラフでの最近の変更の数。</span><span class="sxs-lookup"><span data-stu-id="12175-135">Number of recent changes in the target's social graph.</span></span> <span data-ttu-id="12175-136">この値は、ユーザーが独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="12175-136">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="12175-137">値の例:5</span><span class="sxs-lookup"><span data-stu-id="12175-137">Example values: 5</span></span>| 
| <span data-ttu-id="12175-138">targetFollowerCount</span><span class="sxs-lookup"><span data-stu-id="12175-138">targetFollowerCount</span></span>| <span data-ttu-id="12175-139">> 32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="12175-139">>32-bit unsigned integer</span></span>| <span data-ttu-id="12175-140">ターゲットをフォローしているユーザーの数。</span><span class="sxs-lookup"><span data-stu-id="12175-140">Number of People that are following the target.</span></span> <span data-ttu-id="12175-141">値の例:1308</span><span class="sxs-lookup"><span data-stu-id="12175-141">Example values: 1308</span></span>| 
| <span data-ttu-id="12175-142">targetFollowingCount</span><span class="sxs-lookup"><span data-stu-id="12175-142">targetFollowingCount</span></span>| <span data-ttu-id="12175-143">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="12175-143">32-bit unsigned integer</span></span>| <span data-ttu-id="12175-144">ターゲットは、次のユーザーの数。</span><span class="sxs-lookup"><span data-stu-id="12175-144">Number of People that the target is following.</span></span> <span data-ttu-id="12175-145">値の例:112</span><span class="sxs-lookup"><span data-stu-id="12175-145">Example values: 112</span></span>| 
| <span data-ttu-id="12175-146">基準値</span><span class="sxs-lookup"><span data-stu-id="12175-146">watermark</span></span>| <span data-ttu-id="12175-147">string</span><span class="sxs-lookup"><span data-stu-id="12175-147">string</span></span>| <span data-ttu-id="12175-148">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="12175-148">Optional.</span></span> <span data-ttu-id="12175-149">ターゲットの最近の変更ウォーターマーク。</span><span class="sxs-lookup"><span data-stu-id="12175-149">Recent change watermark for the target.</span></span> <span data-ttu-id="12175-150">この値は、ユーザーが独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="12175-150">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="12175-151">値の例:5</span><span class="sxs-lookup"><span data-stu-id="12175-151">Example values: 5</span></span>| 
  
<a id="ID4E4D"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="12175-152">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="12175-152">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="12175-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="12175-153">See also</span></span>
 
<a id="ID4EIE"></a>

 
##### <a name="parent"></a><span data-ttu-id="12175-154">Parent</span><span class="sxs-lookup"><span data-stu-id="12175-154">Parent</span></span> 

[<span data-ttu-id="12175-155">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="12175-155">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   