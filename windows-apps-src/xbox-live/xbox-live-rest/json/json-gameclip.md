---
title: GameClip (JSON)
assetID: 204cb702-4ce4-85a8-f231-3b4fb243405f
permalink: en-us/docs/xboxlive/rest/json-gameclip.html
author: KevinAsgari
description: " GameClip (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a0882125e1cf7f82be6273e5f456d22cdf79891e
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7160421"
---
# <a name="gameclip-json"></a><span data-ttu-id="83fc2-104">GameClip (JSON)</span><span class="sxs-lookup"><span data-stu-id="83fc2-104">GameClip (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="gameclip"></a><span data-ttu-id="83fc2-105">GameClip</span><span class="sxs-lookup"><span data-stu-id="83fc2-105">GameClip</span></span>
 
<span data-ttu-id="83fc2-106">GameClip オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="83fc2-106">The GameClip object has the following specification.</span></span>
 
| <span data-ttu-id="83fc2-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="83fc2-107">Member</span></span>| <span data-ttu-id="83fc2-108">種類</span><span class="sxs-lookup"><span data-stu-id="83fc2-108">Type</span></span>| <span data-ttu-id="83fc2-109">説明</span><span class="sxs-lookup"><span data-stu-id="83fc2-109">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="83fc2-110">gameClipId</span><span class="sxs-lookup"><span data-stu-id="83fc2-110">gameClipId</span></span></b>| <span data-ttu-id="83fc2-111">string</span><span class="sxs-lookup"><span data-stu-id="83fc2-111">string</span></span>| <span data-ttu-id="83fc2-112">ゲーム クリップに割り当てられている ID。</span><span class="sxs-lookup"><span data-stu-id="83fc2-112">The ID assigned to the game clip.</span></span>| 
| <b><span data-ttu-id="83fc2-113">状態</span><span class="sxs-lookup"><span data-stu-id="83fc2-113">state</span></span></b>| <span data-ttu-id="83fc2-114">GameClipState</span><span class="sxs-lookup"><span data-stu-id="83fc2-114">GameClipState</span></span>| <span data-ttu-id="83fc2-115">システムでゲーム クリップの状態。</span><span class="sxs-lookup"><span data-stu-id="83fc2-115">The state of the game clip in the system.</span></span>| 
| <b><span data-ttu-id="83fc2-116">dateRecorded</span><span class="sxs-lookup"><span data-stu-id="83fc2-116">dateRecorded</span></span></b>| <span data-ttu-id="83fc2-117">DateTime</span><span class="sxs-lookup"><span data-stu-id="83fc2-117">DateTime</span></span>| <span data-ttu-id="83fc2-118">日付と UTC (ISO 8601 形式) での記録が開始された時刻。</span><span class="sxs-lookup"><span data-stu-id="83fc2-118">The date and time that the recording was started, in UTC (ISO 8601 format).</span></span>| 
| <b><span data-ttu-id="83fc2-119">lastModified</span><span class="sxs-lookup"><span data-stu-id="83fc2-119">lastModified</span></span></b>| <span data-ttu-id="83fc2-120">DateTime</span><span class="sxs-lookup"><span data-stu-id="83fc2-120">DateTime</span></span>| <span data-ttu-id="83fc2-121">最後に修正されたゲーム クリップまたは UTC (ISO 8601 形式) で、メタデータの時間。</span><span class="sxs-lookup"><span data-stu-id="83fc2-121">Last modified time of the game clip or its metadata, in UTC (ISO 8601 format).</span></span>| 
| <b><span data-ttu-id="83fc2-122">userCaption</span><span class="sxs-lookup"><span data-stu-id="83fc2-122">userCaption</span></span></b>| <span data-ttu-id="83fc2-123">string</span><span class="sxs-lookup"><span data-stu-id="83fc2-123">string</span></span>| <span data-ttu-id="83fc2-124">ユーザーが入力したローカライズ文字列ゲーム クリップ。</span><span class="sxs-lookup"><span data-stu-id="83fc2-124">The user-entered non-localized string for the game clip.</span></span>| 
| <b><span data-ttu-id="83fc2-125">type</span><span class="sxs-lookup"><span data-stu-id="83fc2-125">type</span></span></b>| <span data-ttu-id="83fc2-126">GameClipTypes</span><span class="sxs-lookup"><span data-stu-id="83fc2-126">GameClipTypes</span></span>| <span data-ttu-id="83fc2-127">クリップの種類です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-127">The type of clip.</span></span> <span data-ttu-id="83fc2-128">複数の値に設定できますされ、そうである場合をコンマで区切られたになります。</span><span class="sxs-lookup"><span data-stu-id="83fc2-128">Can be multiple values, and will be comma-delimited if so.</span></span>| 
| <b><span data-ttu-id="83fc2-129">ソース</span><span class="sxs-lookup"><span data-stu-id="83fc2-129">source</span></span></b>| <span data-ttu-id="83fc2-130">GameClipSource</span><span class="sxs-lookup"><span data-stu-id="83fc2-130">GameClipSource</span></span>| <span data-ttu-id="83fc2-131">クリップが作成された方法です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-131">How the clip was sourced.</span></span>| 
| <b><span data-ttu-id="83fc2-132">visibility</span><span class="sxs-lookup"><span data-stu-id="83fc2-132">visibility</span></span></b>| <span data-ttu-id="83fc2-133">GameClipVisibility</span><span class="sxs-lookup"><span data-stu-id="83fc2-133">GameClipVisibility</span></span>| <span data-ttu-id="83fc2-134">システムでの公開後に、ゲーム クリップの可視性です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-134">The visibility of the game clip once it is published in the system.</span></span>| 
| <b><span data-ttu-id="83fc2-135">durationInSeconds</span><span class="sxs-lookup"><span data-stu-id="83fc2-135">durationInSeconds</span></span></b>| <span data-ttu-id="83fc2-136">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="83fc2-136">32-bit unsigned integer</span></span>| <span data-ttu-id="83fc2-137">秒単位でゲーム クリップの期間です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-137">The duration of the game clip in seconds.</span></span>| 
| <b><span data-ttu-id="83fc2-138">scid</span><span class="sxs-lookup"><span data-stu-id="83fc2-138">scid</span></span></b>| <span data-ttu-id="83fc2-139">string</span><span class="sxs-lookup"><span data-stu-id="83fc2-139">string</span></span>| <span data-ttu-id="83fc2-140">ゲームのクリップが関連付けられている SCID です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-140">SCID to which the game clip is associated.</span></span>| 
| <b><span data-ttu-id="83fc2-141">rating</span><span class="sxs-lookup"><span data-stu-id="83fc2-141">rating</span></span></b>| <span data-ttu-id="83fc2-142">倍精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="83fc2-142">double-precision floating-point number</span></span>| <span data-ttu-id="83fc2-143">ゲームのクリップ, 0.0 に 5.0 の範囲内に関連付けられている評価です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-143">The rating associated with the game clip, in the range 0.0 to 5.0.</span></span>| 
| <b><span data-ttu-id="83fc2-144">ratingCount</span><span class="sxs-lookup"><span data-stu-id="83fc2-144">ratingCount</span></span></b>| <span data-ttu-id="83fc2-145">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="83fc2-145">32-bit unsigned integer</span></span>| <span data-ttu-id="83fc2-146">このクリップが評価された回数。</span><span class="sxs-lookup"><span data-stu-id="83fc2-146">The number of times this clip has been rated.</span></span>| 
| <b><span data-ttu-id="83fc2-147">表示モード</span><span class="sxs-lookup"><span data-stu-id="83fc2-147">views</span></span></b>| <span data-ttu-id="83fc2-148">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="83fc2-148">32-bit unsigned integer</span></span>| <span data-ttu-id="83fc2-149">ゲーム クリップに関連付けられているビューの数。</span><span class="sxs-lookup"><span data-stu-id="83fc2-149">The number of views associated with the game clip.</span></span>| 
| <b><span data-ttu-id="83fc2-150">titleData</span><span class="sxs-lookup"><span data-stu-id="83fc2-150">titleData</span></span></b>| <span data-ttu-id="83fc2-151">string</span><span class="sxs-lookup"><span data-stu-id="83fc2-151">string</span></span>| <span data-ttu-id="83fc2-152">タイトルに固有のプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="83fc2-152">The title-specific property bag.</span></span>| 
| <b><span data-ttu-id="83fc2-153">titleData</span><span class="sxs-lookup"><span data-stu-id="83fc2-153">titleData</span></span></b>| <span data-ttu-id="83fc2-154">string</span><span class="sxs-lookup"><span data-stu-id="83fc2-154">string</span></span>| <span data-ttu-id="83fc2-155">コンソールに固有のプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="83fc2-155">The console-specific property bag.</span></span>| 
| <b><span data-ttu-id="83fc2-156">サムネイル</span><span class="sxs-lookup"><span data-stu-id="83fc2-156">thumbnails</span></span></b>| <span data-ttu-id="83fc2-157">GameClipThumbnail の配列</span><span class="sxs-lookup"><span data-stu-id="83fc2-157">array of GameClipThumbnail</span></span>| <span data-ttu-id="83fc2-158">GameClipThumbnail オブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-158">Array of GameClipThumbnail objects.</span></span>| 
| <b><span data-ttu-id="83fc2-159">gameClipUris</span><span class="sxs-lookup"><span data-stu-id="83fc2-159">gameClipUris</span></span></b>| <span data-ttu-id="83fc2-160">GameClipUri の配列</span><span class="sxs-lookup"><span data-stu-id="83fc2-160">array of GameClipUri</span></span>| <span data-ttu-id="83fc2-161">GameClipUri オブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-161">Array of GameClipUri objects.</span></span>| 
| <b><span data-ttu-id="83fc2-162">xuid</span><span class="sxs-lookup"><span data-stu-id="83fc2-162">xuid</span></span></b>| <span data-ttu-id="83fc2-163">string</span><span class="sxs-lookup"><span data-stu-id="83fc2-163">string</span></span>| <span data-ttu-id="83fc2-164">ゲーム クリップ, 文字列としてマーシャ リングの所有者の XUID です。</span><span class="sxs-lookup"><span data-stu-id="83fc2-164">The XUID of the owner of the game clip, marshaled as a string.</span></span>| 
| <b><span data-ttu-id="83fc2-165">clipName</span><span class="sxs-lookup"><span data-stu-id="83fc2-165">clipName</span></span></b>| <span data-ttu-id="83fc2-166">string</span><span class="sxs-lookup"><span data-stu-id="83fc2-166">string</span></span>| <span data-ttu-id="83fc2-167">タイトルの管理システムから検索要求の入力のロケールに基づいて、クリップの名前のローカライズされたバージョンです。</span><span class="sxs-lookup"><span data-stu-id="83fc2-167">The localized version of the clip's name, based on the input locale of the request as looked up from the title management system.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="83fc2-168">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="83fc2-168">Sample JSON syntax</span></span>
 

```json
{
     "id": "7ce5c1a7-1255-46d3-a90e-34a0e2dfab06",
     "xuid": "2716903703773872",
     "state": "Published", 
     "dateRecorded": "2012-12-23T12:00:00Z",
     "lastModified": "2012-10-31T10:45:00Z",
     "clipName": "Forza 4",
     "userCaption": "My awesome car flip",
     "type": "DeveloperInitiated, Achievement",
     "source": "TitleDirect",
     "visibility": "Default",
     "durationInSeconds": 30,
     "scid": "ecb5497e-76d4-4a8a-870d-e76a26306b7d",
     "rating": 1.0,
     "views": 5,
     "thumbnails": [
       {
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234565,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       }
     ]
   }
    
```

  
<a id="ID4E1H"></a>

 
## <a name="see-also"></a><span data-ttu-id="83fc2-169">関連項目</span><span class="sxs-lookup"><span data-stu-id="83fc2-169">See also</span></span>
 
<a id="ID4E3H"></a>

 
##### <a name="parent"></a><span data-ttu-id="83fc2-170">Parent</span><span class="sxs-lookup"><span data-stu-id="83fc2-170">Parent</span></span> 

[<span data-ttu-id="83fc2-171">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="83fc2-171">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   