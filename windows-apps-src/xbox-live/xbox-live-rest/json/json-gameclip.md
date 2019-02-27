---
title: GameClip (JSON)
assetID: 204cb702-4ce4-85a8-f231-3b4fb243405f
permalink: en-us/docs/xboxlive/rest/json-gameclip.html
description: " GameClip (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4cfc2ac0a635e4aacdc9eeefb5097c6bd946a518
ms.sourcegitcommit: 079801609165bc7eb69670d771a05bffe236d483
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/27/2019
ms.locfileid: "9115391"
---
# <a name="gameclip-json"></a><span data-ttu-id="58621-104">GameClip (JSON)</span><span class="sxs-lookup"><span data-stu-id="58621-104">GameClip (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="gameclip"></a><span data-ttu-id="58621-105">GameClip</span><span class="sxs-lookup"><span data-stu-id="58621-105">GameClip</span></span>
 
<span data-ttu-id="58621-106">GameClip オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="58621-106">The GameClip object has the following specification.</span></span>
 
| <span data-ttu-id="58621-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="58621-107">Member</span></span>| <span data-ttu-id="58621-108">種類</span><span class="sxs-lookup"><span data-stu-id="58621-108">Type</span></span>| <span data-ttu-id="58621-109">説明</span><span class="sxs-lookup"><span data-stu-id="58621-109">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="58621-110">gameClipId</span><span class="sxs-lookup"><span data-stu-id="58621-110">gameClipId</span></span></b>| <span data-ttu-id="58621-111">string</span><span class="sxs-lookup"><span data-stu-id="58621-111">string</span></span>| <span data-ttu-id="58621-112">ゲーム クリップに割り当てられている ID。</span><span class="sxs-lookup"><span data-stu-id="58621-112">The ID assigned to the game clip.</span></span>| 
| <b><span data-ttu-id="58621-113">状態</span><span class="sxs-lookup"><span data-stu-id="58621-113">state</span></span></b>| <span data-ttu-id="58621-114">GameClipState</span><span class="sxs-lookup"><span data-stu-id="58621-114">GameClipState</span></span>| <span data-ttu-id="58621-115">システムでゲーム クリップの状態。</span><span class="sxs-lookup"><span data-stu-id="58621-115">The state of the game clip in the system.</span></span>| 
| <b><span data-ttu-id="58621-116">dateRecorded</span><span class="sxs-lookup"><span data-stu-id="58621-116">dateRecorded</span></span></b>| <span data-ttu-id="58621-117">DateTime</span><span class="sxs-lookup"><span data-stu-id="58621-117">DateTime</span></span>| <span data-ttu-id="58621-118">日付と UTC (ISO 8601 形式) で、録画が開始された時刻。</span><span class="sxs-lookup"><span data-stu-id="58621-118">The date and time that the recording was started, in UTC (ISO 8601 format).</span></span>| 
| <b><span data-ttu-id="58621-119">lastModified</span><span class="sxs-lookup"><span data-stu-id="58621-119">lastModified</span></span></b>| <span data-ttu-id="58621-120">DateTime</span><span class="sxs-lookup"><span data-stu-id="58621-120">DateTime</span></span>| <span data-ttu-id="58621-121">最後に修正されたゲーム クリップまたは UTC (ISO 8601 形式) で、メタデータの時間。</span><span class="sxs-lookup"><span data-stu-id="58621-121">Last modified time of the game clip or its metadata, in UTC (ISO 8601 format).</span></span>| 
| <b><span data-ttu-id="58621-122">userCaption</span><span class="sxs-lookup"><span data-stu-id="58621-122">userCaption</span></span></b>| <span data-ttu-id="58621-123">string</span><span class="sxs-lookup"><span data-stu-id="58621-123">string</span></span>| <span data-ttu-id="58621-124">ユーザーが入力したローカライズ文字列ゲーム クリップのします。</span><span class="sxs-lookup"><span data-stu-id="58621-124">The user-entered non-localized string for the game clip.</span></span>| 
| <b><span data-ttu-id="58621-125">type</span><span class="sxs-lookup"><span data-stu-id="58621-125">type</span></span></b>| <span data-ttu-id="58621-126">GameClipTypes</span><span class="sxs-lookup"><span data-stu-id="58621-126">GameClipTypes</span></span>| <span data-ttu-id="58621-127">クリップの種類です。</span><span class="sxs-lookup"><span data-stu-id="58621-127">The type of clip.</span></span> <span data-ttu-id="58621-128">そうである場合をコンマで区切られたことが、複数の値ができます。</span><span class="sxs-lookup"><span data-stu-id="58621-128">Can be multiple values, and will be comma-delimited if so.</span></span>| 
| <b><span data-ttu-id="58621-129">ソース</span><span class="sxs-lookup"><span data-stu-id="58621-129">source</span></span></b>| <span data-ttu-id="58621-130">GameClipSource</span><span class="sxs-lookup"><span data-stu-id="58621-130">GameClipSource</span></span>| <span data-ttu-id="58621-131">方法クリップされたデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="58621-131">How the clip was sourced.</span></span>| 
| <b><span data-ttu-id="58621-132">visibility</span><span class="sxs-lookup"><span data-stu-id="58621-132">visibility</span></span></b>| <span data-ttu-id="58621-133">GameClipVisibility</span><span class="sxs-lookup"><span data-stu-id="58621-133">GameClipVisibility</span></span>| <span data-ttu-id="58621-134">システムでの公開後に、ゲーム クリップの可視性です。</span><span class="sxs-lookup"><span data-stu-id="58621-134">The visibility of the game clip once it is published in the system.</span></span>| 
| <b><span data-ttu-id="58621-135">durationInSeconds</span><span class="sxs-lookup"><span data-stu-id="58621-135">durationInSeconds</span></span></b>| <span data-ttu-id="58621-136">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="58621-136">32-bit unsigned integer</span></span>| <span data-ttu-id="58621-137">秒単位でゲーム クリップの期間です。</span><span class="sxs-lookup"><span data-stu-id="58621-137">The duration of the game clip in seconds.</span></span>| 
| <b><span data-ttu-id="58621-138">scid</span><span class="sxs-lookup"><span data-stu-id="58621-138">scid</span></span></b>| <span data-ttu-id="58621-139">string</span><span class="sxs-lookup"><span data-stu-id="58621-139">string</span></span>| <span data-ttu-id="58621-140">ゲームのクリップが関連付けられている SCID です。</span><span class="sxs-lookup"><span data-stu-id="58621-140">SCID to which the game clip is associated.</span></span>| 
| <b><span data-ttu-id="58621-141">rating</span><span class="sxs-lookup"><span data-stu-id="58621-141">rating</span></span></b>| <span data-ttu-id="58621-142">倍精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="58621-142">double-precision floating-point number</span></span>| <span data-ttu-id="58621-143">ゲーム クリップ, 0.0 に 5.0 の範囲内に関連付けられている評価します。</span><span class="sxs-lookup"><span data-stu-id="58621-143">The rating associated with the game clip, in the range 0.0 to 5.0.</span></span>| 
| <b><span data-ttu-id="58621-144">ratingCount</span><span class="sxs-lookup"><span data-stu-id="58621-144">ratingCount</span></span></b>| <span data-ttu-id="58621-145">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="58621-145">32-bit unsigned integer</span></span>| <span data-ttu-id="58621-146">このクリップが評価された回数。</span><span class="sxs-lookup"><span data-stu-id="58621-146">The number of times this clip has been rated.</span></span>| 
| <b><span data-ttu-id="58621-147">表示モード</span><span class="sxs-lookup"><span data-stu-id="58621-147">views</span></span></b>| <span data-ttu-id="58621-148">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="58621-148">32-bit unsigned integer</span></span>| <span data-ttu-id="58621-149">ゲーム クリップに関連付けられたビューの数。</span><span class="sxs-lookup"><span data-stu-id="58621-149">The number of views associated with the game clip.</span></span>| 
| <b><span data-ttu-id="58621-150">titleData</span><span class="sxs-lookup"><span data-stu-id="58621-150">titleData</span></span></b>| <span data-ttu-id="58621-151">string</span><span class="sxs-lookup"><span data-stu-id="58621-151">string</span></span>| <span data-ttu-id="58621-152">タイトルに固有のプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="58621-152">The title-specific property bag.</span></span>| 
| <b><span data-ttu-id="58621-153">titleData</span><span class="sxs-lookup"><span data-stu-id="58621-153">titleData</span></span></b>| <span data-ttu-id="58621-154">string</span><span class="sxs-lookup"><span data-stu-id="58621-154">string</span></span>| <span data-ttu-id="58621-155">コンソールに固有のプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="58621-155">The console-specific property bag.</span></span>| 
| <b><span data-ttu-id="58621-156">縮小表示</span><span class="sxs-lookup"><span data-stu-id="58621-156">thumbnails</span></span></b>| <span data-ttu-id="58621-157">GameClipThumbnail の配列</span><span class="sxs-lookup"><span data-stu-id="58621-157">array of GameClipThumbnail</span></span>| <span data-ttu-id="58621-158">GameClipThumbnail オブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="58621-158">Array of GameClipThumbnail objects.</span></span>| 
| <b><span data-ttu-id="58621-159">gameClipUris</span><span class="sxs-lookup"><span data-stu-id="58621-159">gameClipUris</span></span></b>| <span data-ttu-id="58621-160">GameClipUri の配列</span><span class="sxs-lookup"><span data-stu-id="58621-160">array of GameClipUri</span></span>| <span data-ttu-id="58621-161">GameClipUri オブジェクトの配列です。</span><span class="sxs-lookup"><span data-stu-id="58621-161">Array of GameClipUri objects.</span></span>| 
| <b><span data-ttu-id="58621-162">xuid</span><span class="sxs-lookup"><span data-stu-id="58621-162">xuid</span></span></b>| <span data-ttu-id="58621-163">string</span><span class="sxs-lookup"><span data-stu-id="58621-163">string</span></span>| <span data-ttu-id="58621-164">文字列としてマーシャ リング、ゲーム クリップの所有者の XUID です。</span><span class="sxs-lookup"><span data-stu-id="58621-164">The XUID of the owner of the game clip, marshaled as a string.</span></span>| 
| <b><span data-ttu-id="58621-165">clipName</span><span class="sxs-lookup"><span data-stu-id="58621-165">clipName</span></span></b>| <span data-ttu-id="58621-166">string</span><span class="sxs-lookup"><span data-stu-id="58621-166">string</span></span>| <span data-ttu-id="58621-167">タイトルの管理システムから検索要求の入力のロケールに基づいて、クリップの名前のローカライズされたバージョン。</span><span class="sxs-lookup"><span data-stu-id="58621-167">The localized version of the clip's name, based on the input locale of the request as looked up from the title management system.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="58621-168">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="58621-168">Sample JSON syntax</span></span>
 

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
         "uri": "https://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
     ],
     "gameClipUris": [
       {
         "uri": "https://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234565,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       }
     ]
   }
    
```

  
<a id="ID4E1H"></a>

 
## <a name="see-also"></a><span data-ttu-id="58621-169">関連項目</span><span class="sxs-lookup"><span data-stu-id="58621-169">See also</span></span>
 
<a id="ID4E3H"></a>

 
##### <a name="parent"></a><span data-ttu-id="58621-170">Parent</span><span class="sxs-lookup"><span data-stu-id="58621-170">Parent</span></span> 

[<span data-ttu-id="58621-171">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="58621-171">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   