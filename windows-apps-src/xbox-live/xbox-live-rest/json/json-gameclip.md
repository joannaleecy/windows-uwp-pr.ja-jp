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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646507"
---
# <a name="gameclip-json"></a><span data-ttu-id="62b34-104">GameClip (JSON)</span><span class="sxs-lookup"><span data-stu-id="62b34-104">GameClip (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="gameclip"></a><span data-ttu-id="62b34-105">ゲーム クリップだった</span><span class="sxs-lookup"><span data-stu-id="62b34-105">GameClip</span></span>
 
<span data-ttu-id="62b34-106">ゲーム クリップだったオブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="62b34-106">The GameClip object has the following specification.</span></span>
 
| <span data-ttu-id="62b34-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="62b34-107">Member</span></span>| <span data-ttu-id="62b34-108">種類</span><span class="sxs-lookup"><span data-stu-id="62b34-108">Type</span></span>| <span data-ttu-id="62b34-109">説明</span><span class="sxs-lookup"><span data-stu-id="62b34-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="62b34-110"><b>gameClipId</b></span><span class="sxs-lookup"><span data-stu-id="62b34-110"><b>gameClipId</b></span></span>| <span data-ttu-id="62b34-111">string</span><span class="sxs-lookup"><span data-stu-id="62b34-111">string</span></span>| <span data-ttu-id="62b34-112">ゲームのクリップに割り当てられた ID。</span><span class="sxs-lookup"><span data-stu-id="62b34-112">The ID assigned to the game clip.</span></span>| 
| <span data-ttu-id="62b34-113"><b>state</b></span><span class="sxs-lookup"><span data-stu-id="62b34-113"><b>state</b></span></span>| <span data-ttu-id="62b34-114">GameClipState</span><span class="sxs-lookup"><span data-stu-id="62b34-114">GameClipState</span></span>| <span data-ttu-id="62b34-115">システムのゲームのクリップの状態。</span><span class="sxs-lookup"><span data-stu-id="62b34-115">The state of the game clip in the system.</span></span>| 
| <span data-ttu-id="62b34-116"><b>dateRecorded</b></span><span class="sxs-lookup"><span data-stu-id="62b34-116"><b>dateRecorded</b></span></span>| <span data-ttu-id="62b34-117">DateTime</span><span class="sxs-lookup"><span data-stu-id="62b34-117">DateTime</span></span>| <span data-ttu-id="62b34-118">日付と時刻 (utc) (ISO 8601 形式) の記録が開始されました。</span><span class="sxs-lookup"><span data-stu-id="62b34-118">The date and time that the recording was started, in UTC (ISO 8601 format).</span></span>| 
| <span data-ttu-id="62b34-119"><b>LastModified</b></span><span class="sxs-lookup"><span data-stu-id="62b34-119"><b>lastModified</b></span></span>| <span data-ttu-id="62b34-120">DateTime</span><span class="sxs-lookup"><span data-stu-id="62b34-120">DateTime</span></span>| <span data-ttu-id="62b34-121">ゲームのクリップまたは UTC (ISO 8601 形式) でそのメタデータの時間を最後に変更します。</span><span class="sxs-lookup"><span data-stu-id="62b34-121">Last modified time of the game clip or its metadata, in UTC (ISO 8601 format).</span></span>| 
| <span data-ttu-id="62b34-122"><b>userCaption</b></span><span class="sxs-lookup"><span data-stu-id="62b34-122"><b>userCaption</b></span></span>| <span data-ttu-id="62b34-123">string</span><span class="sxs-lookup"><span data-stu-id="62b34-123">string</span></span>| <span data-ttu-id="62b34-124">ユーザーが入力したローカライズされていない文字列のゲームのクリップの。</span><span class="sxs-lookup"><span data-stu-id="62b34-124">The user-entered non-localized string for the game clip.</span></span>| 
| <span data-ttu-id="62b34-125"><b>型</b></span><span class="sxs-lookup"><span data-stu-id="62b34-125"><b>type</b></span></span>| <span data-ttu-id="62b34-126">GameClipTypes</span><span class="sxs-lookup"><span data-stu-id="62b34-126">GameClipTypes</span></span>| <span data-ttu-id="62b34-127">クリップの種類。</span><span class="sxs-lookup"><span data-stu-id="62b34-127">The type of clip.</span></span> <span data-ttu-id="62b34-128">複数の値を指定でき、その場合のコンマ区切りになります。</span><span class="sxs-lookup"><span data-stu-id="62b34-128">Can be multiple values, and will be comma-delimited if so.</span></span>| 
| <span data-ttu-id="62b34-129"><b>ソース</b></span><span class="sxs-lookup"><span data-stu-id="62b34-129"><b>source</b></span></span>| <span data-ttu-id="62b34-130">GameClipSource</span><span class="sxs-lookup"><span data-stu-id="62b34-130">GameClipSource</span></span>| <span data-ttu-id="62b34-131">どのようにクリップのソースとなった。</span><span class="sxs-lookup"><span data-stu-id="62b34-131">How the clip was sourced.</span></span>| 
| <span data-ttu-id="62b34-132"><b>可視性</b></span><span class="sxs-lookup"><span data-stu-id="62b34-132"><b>visibility</b></span></span>| <span data-ttu-id="62b34-133">GameClipVisibility</span><span class="sxs-lookup"><span data-stu-id="62b34-133">GameClipVisibility</span></span>| <span data-ttu-id="62b34-134">システムで発行されたが、ゲームのクリップの可視性。</span><span class="sxs-lookup"><span data-stu-id="62b34-134">The visibility of the game clip once it is published in the system.</span></span>| 
| <span data-ttu-id="62b34-135"><b>durationInSeconds</b></span><span class="sxs-lookup"><span data-stu-id="62b34-135"><b>durationInSeconds</b></span></span>| <span data-ttu-id="62b34-136">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="62b34-136">32-bit unsigned integer</span></span>| <span data-ttu-id="62b34-137">秒単位でゲームのクリップの期間です。</span><span class="sxs-lookup"><span data-stu-id="62b34-137">The duration of the game clip in seconds.</span></span>| 
| <span data-ttu-id="62b34-138"><b>scid</b></span><span class="sxs-lookup"><span data-stu-id="62b34-138"><b>scid</b></span></span>| <span data-ttu-id="62b34-139">string</span><span class="sxs-lookup"><span data-stu-id="62b34-139">string</span></span>| <span data-ttu-id="62b34-140">ゲームのクリップが関連付けられている SCID します。</span><span class="sxs-lookup"><span data-stu-id="62b34-140">SCID to which the game clip is associated.</span></span>| 
| <span data-ttu-id="62b34-141"><b>rating</b></span><span class="sxs-lookup"><span data-stu-id="62b34-141"><b>rating</b></span></span>| <span data-ttu-id="62b34-142">倍精度浮動小数点数</span><span class="sxs-lookup"><span data-stu-id="62b34-142">double-precision floating-point number</span></span>| <span data-ttu-id="62b34-143">範囲 0.0 に 5.0 で、ゲームのクリップに関連する評価します。</span><span class="sxs-lookup"><span data-stu-id="62b34-143">The rating associated with the game clip, in the range 0.0 to 5.0.</span></span>| 
| <span data-ttu-id="62b34-144"><b>ratingCount</b></span><span class="sxs-lookup"><span data-stu-id="62b34-144"><b>ratingCount</b></span></span>| <span data-ttu-id="62b34-145">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="62b34-145">32-bit unsigned integer</span></span>| <span data-ttu-id="62b34-146">このクリップが評価された回数。</span><span class="sxs-lookup"><span data-stu-id="62b34-146">The number of times this clip has been rated.</span></span>| 
| <span data-ttu-id="62b34-147"><b>表示モード</b></span><span class="sxs-lookup"><span data-stu-id="62b34-147"><b>views</b></span></span>| <span data-ttu-id="62b34-148">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="62b34-148">32-bit unsigned integer</span></span>| <span data-ttu-id="62b34-149">ゲームのクリップに関連付けられたビューの数。</span><span class="sxs-lookup"><span data-stu-id="62b34-149">The number of views associated with the game clip.</span></span>| 
| <span data-ttu-id="62b34-150"><b>titleData</b></span><span class="sxs-lookup"><span data-stu-id="62b34-150"><b>titleData</b></span></span>| <span data-ttu-id="62b34-151">string</span><span class="sxs-lookup"><span data-stu-id="62b34-151">string</span></span>| <span data-ttu-id="62b34-152">タイトルに固有のプロパティ バッグ。</span><span class="sxs-lookup"><span data-stu-id="62b34-152">The title-specific property bag.</span></span>| 
| <span data-ttu-id="62b34-153"><b>titleData</b></span><span class="sxs-lookup"><span data-stu-id="62b34-153"><b>titleData</b></span></span>| <span data-ttu-id="62b34-154">string</span><span class="sxs-lookup"><span data-stu-id="62b34-154">string</span></span>| <span data-ttu-id="62b34-155">コンソールに固有のプロパティ バッグ。</span><span class="sxs-lookup"><span data-stu-id="62b34-155">The console-specific property bag.</span></span>| 
| <span data-ttu-id="62b34-156"><b>サムネイル</b></span><span class="sxs-lookup"><span data-stu-id="62b34-156"><b>thumbnails</b></span></span>| <span data-ttu-id="62b34-157">GameClipThumbnail の配列</span><span class="sxs-lookup"><span data-stu-id="62b34-157">array of GameClipThumbnail</span></span>| <span data-ttu-id="62b34-158">GameClipThumbnail オブジェクトの配列。</span><span class="sxs-lookup"><span data-stu-id="62b34-158">Array of GameClipThumbnail objects.</span></span>| 
| <span data-ttu-id="62b34-159"><b>gameClipUris</b></span><span class="sxs-lookup"><span data-stu-id="62b34-159"><b>gameClipUris</b></span></span>| <span data-ttu-id="62b34-160">GameClipUri の配列</span><span class="sxs-lookup"><span data-stu-id="62b34-160">array of GameClipUri</span></span>| <span data-ttu-id="62b34-161">GameClipUri オブジェクトの配列。</span><span class="sxs-lookup"><span data-stu-id="62b34-161">Array of GameClipUri objects.</span></span>| 
| <span data-ttu-id="62b34-162"><b>xuid</b></span><span class="sxs-lookup"><span data-stu-id="62b34-162"><b>xuid</b></span></span>| <span data-ttu-id="62b34-163">string</span><span class="sxs-lookup"><span data-stu-id="62b34-163">string</span></span>| <span data-ttu-id="62b34-164">文字列としてマーシャ リング、ゲームのクリップの所有者の XUID です。</span><span class="sxs-lookup"><span data-stu-id="62b34-164">The XUID of the owner of the game clip, marshaled as a string.</span></span>| 
| <span data-ttu-id="62b34-165"><b>clipName</b></span><span class="sxs-lookup"><span data-stu-id="62b34-165"><b>clipName</b></span></span>| <span data-ttu-id="62b34-166">string</span><span class="sxs-lookup"><span data-stu-id="62b34-166">string</span></span>| <span data-ttu-id="62b34-167">タイトルの管理システムからのクリップの名前、として要求の入力ロケールに基づいてローカライズされたバージョンを検索します。</span><span class="sxs-lookup"><span data-stu-id="62b34-167">The localized version of the clip's name, based on the input locale of the request as looked up from the title management system.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="62b34-168">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="62b34-168">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="62b34-169">関連項目</span><span class="sxs-lookup"><span data-stu-id="62b34-169">See also</span></span>
 
<a id="ID4E3H"></a>

 
##### <a name="parent"></a><span data-ttu-id="62b34-170">Parent</span><span class="sxs-lookup"><span data-stu-id="62b34-170">Parent</span></span> 

[<span data-ttu-id="62b34-171">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="62b34-171">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   