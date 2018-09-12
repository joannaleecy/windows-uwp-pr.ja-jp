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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3882176"
---
# <a name="personsummary-json"></a><span data-ttu-id="ef7bf-104">PersonSummary (JSON)</span><span class="sxs-lookup"><span data-stu-id="ef7bf-104">PersonSummary (JSON)</span></span>
<span data-ttu-id="ef7bf-105">[ユーザー (JSON)](json-person.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-105">Collection of [Person (JSON)](json-person.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="personsummary"></a><span data-ttu-id="ef7bf-106">PersonSummary</span><span class="sxs-lookup"><span data-stu-id="ef7bf-106">PersonSummary</span></span>
 
<span data-ttu-id="ef7bf-107">PersonSummary オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-107">The PersonSummary object has the following specification.</span></span>
 
| <span data-ttu-id="ef7bf-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="ef7bf-108">Member</span></span>| <span data-ttu-id="ef7bf-109">種類</span><span class="sxs-lookup"><span data-stu-id="ef7bf-109">Type</span></span>| <span data-ttu-id="ef7bf-110">説明</span><span class="sxs-lookup"><span data-stu-id="ef7bf-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ef7bf-111">hasCallerMarkedTargetAsFavorite</span><span class="sxs-lookup"><span data-stu-id="ef7bf-111">hasCallerMarkedTargetAsFavorite</span></span>| <span data-ttu-id="ef7bf-112">ブール値</span><span class="sxs-lookup"><span data-stu-id="ef7bf-112">Boolean value</span></span>| <span data-ttu-id="ef7bf-113">かどうか、呼び出し元では、お気に入りとして、ターゲットをマークいます。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-113">Whether the caller has marked the target as a favorite.</span></span> <span data-ttu-id="ef7bf-114">値の例: true</span><span class="sxs-lookup"><span data-stu-id="ef7bf-114">Example values: true</span></span>| 
| <span data-ttu-id="ef7bf-115">hasCallerMarkedTargetAsKnown</span><span class="sxs-lookup"><span data-stu-id="ef7bf-115">hasCallerMarkedTargetAsKnown</span></span>| <span data-ttu-id="ef7bf-116">ブール値</span><span class="sxs-lookup"><span data-stu-id="ef7bf-116">Boolean value</span></span>| <span data-ttu-id="ef7bf-117">かどうか、呼び出し元が、ターゲット済みとしてマーク呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-117">Whether the caller has marked the target as known.</span></span> <span data-ttu-id="ef7bf-118">値の例: true</span><span class="sxs-lookup"><span data-stu-id="ef7bf-118">Example values: true</span></span>| 
| <span data-ttu-id="ef7bf-119">isCallerFollowingTarget</span><span class="sxs-lookup"><span data-stu-id="ef7bf-119">isCallerFollowingTarget</span></span>| <span data-ttu-id="ef7bf-120">ブール値</span><span class="sxs-lookup"><span data-stu-id="ef7bf-120">Boolean value</span></span>| <span data-ttu-id="ef7bf-121">かどうか、呼び出し元が、ターゲットをフォローします。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-121">Whether the caller is following the target.</span></span> <span data-ttu-id="ef7bf-122">値の例: true</span><span class="sxs-lookup"><span data-stu-id="ef7bf-122">Example values: true</span></span>| 
| <span data-ttu-id="ef7bf-123">isTargetFollowingCaller</span><span class="sxs-lookup"><span data-stu-id="ef7bf-123">isTargetFollowingCaller</span></span>| <span data-ttu-id="ef7bf-124">ブール値</span><span class="sxs-lookup"><span data-stu-id="ef7bf-124">Boolean value</span></span>| <span data-ttu-id="ef7bf-125">かどうか、ターゲットでは、呼び出し元がフォローします。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-125">Whether the target is following the caller.</span></span> <span data-ttu-id="ef7bf-126">値の例: true</span><span class="sxs-lookup"><span data-stu-id="ef7bf-126">Example values: true</span></span>| 
| <span data-ttu-id="ef7bf-127">legacyFriendStatus</span><span class="sxs-lookup"><span data-stu-id="ef7bf-127">legacyFriendStatus</span></span>| <span data-ttu-id="ef7bf-128">string</span><span class="sxs-lookup"><span data-stu-id="ef7bf-128">string</span></span>| <span data-ttu-id="ef7bf-129">従来のフレンド、呼び出し元に示すように、ターゲットの状態です。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-129">Legacy friend status of the target as seen by the caller.</span></span> <span data-ttu-id="ef7bf-130">"None"、"MutuallyAccepted"、"OutgoingRequest"または"IncomingRequest"をすることができます。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-130">Can be "None", "MutuallyAccepted", "OutgoingRequest", or "IncomingRequest".</span></span> <span data-ttu-id="ef7bf-131">値の例:"MutuallyAccepted"</span><span class="sxs-lookup"><span data-stu-id="ef7bf-131">Example values: "MutuallyAccepted"</span></span>| 
| <span data-ttu-id="ef7bf-132">recentChangeCount</span><span class="sxs-lookup"><span data-stu-id="ef7bf-132">recentChangeCount</span></span>| <span data-ttu-id="ef7bf-133">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ef7bf-133">32-bit unsigned integer</span></span>| <span data-ttu-id="ef7bf-134">省略可能。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-134">Optional.</span></span> <span data-ttu-id="ef7bf-135">ターゲットのソーシャル グラフ内の最新の変更の数です。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-135">Number of recent changes in the target's social graph.</span></span> <span data-ttu-id="ef7bf-136">この値は、ユーザーが、独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-136">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="ef7bf-137">値の例: 5</span><span class="sxs-lookup"><span data-stu-id="ef7bf-137">Example values: 5</span></span>| 
| <span data-ttu-id="ef7bf-138">targetFollowerCount</span><span class="sxs-lookup"><span data-stu-id="ef7bf-138">targetFollowerCount</span></span>| <span data-ttu-id="ef7bf-139">> 32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ef7bf-139">>32-bit unsigned integer</span></span>| <span data-ttu-id="ef7bf-140">次のターゲットはユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-140">Number of People that are following the target.</span></span> <span data-ttu-id="ef7bf-141">値の例: 1308</span><span class="sxs-lookup"><span data-stu-id="ef7bf-141">Example values: 1308</span></span>| 
| <span data-ttu-id="ef7bf-142">targetFollowingCount</span><span class="sxs-lookup"><span data-stu-id="ef7bf-142">targetFollowingCount</span></span>| <span data-ttu-id="ef7bf-143">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ef7bf-143">32-bit unsigned integer</span></span>| <span data-ttu-id="ef7bf-144">ターゲットは、次のユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-144">Number of People that the target is following.</span></span> <span data-ttu-id="ef7bf-145">値の例: 112</span><span class="sxs-lookup"><span data-stu-id="ef7bf-145">Example values: 112</span></span>| 
| <span data-ttu-id="ef7bf-146">透かし</span><span class="sxs-lookup"><span data-stu-id="ef7bf-146">watermark</span></span>| <span data-ttu-id="ef7bf-147">string</span><span class="sxs-lookup"><span data-stu-id="ef7bf-147">string</span></span>| <span data-ttu-id="ef7bf-148">省略可能。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-148">Optional.</span></span> <span data-ttu-id="ef7bf-149">ターゲットの最新の変更透かしします。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-149">Recent change watermark for the target.</span></span> <span data-ttu-id="ef7bf-150">この値は、ユーザーが、独自の概要を表示するときにのみ存在します。</span><span class="sxs-lookup"><span data-stu-id="ef7bf-150">This value will only exist when a user is viewing their own summary.</span></span> <span data-ttu-id="ef7bf-151">値の例: 5</span><span class="sxs-lookup"><span data-stu-id="ef7bf-151">Example values: 5</span></span>| 
  
<a id="ID4E4D"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="ef7bf-152">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="ef7bf-152">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="ef7bf-153">関連項目</span><span class="sxs-lookup"><span data-stu-id="ef7bf-153">See also</span></span>
 
<a id="ID4EIE"></a>

 
##### <a name="parent"></a><span data-ttu-id="ef7bf-154">Parent</span><span class="sxs-lookup"><span data-stu-id="ef7bf-154">Parent</span></span> 

[<span data-ttu-id="ef7bf-155">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="ef7bf-155">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   