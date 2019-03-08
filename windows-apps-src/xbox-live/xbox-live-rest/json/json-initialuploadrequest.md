---
title: InitialUploadRequest (JSON)
assetID: 8b8bce98-cb5f-bbaf-5564-9be2f58d749b
permalink: en-us/docs/xboxlive/rest/json-initialuploadrequest.html
description: " InitialUploadRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 2fbb2417f743d97b487ad16abd241fcb5eea62bb
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57646637"
---
# <a name="initialuploadrequest-json"></a><span data-ttu-id="355bf-104">InitialUploadRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="355bf-104">InitialUploadRequest (JSON)</span></span>
<span data-ttu-id="355bf-105">要求の POST ゲームのクリップだったの本文にアップロードします。</span><span class="sxs-lookup"><span data-stu-id="355bf-105">The body of a POST GameClip upload request.</span></span> 
<a id="ID4EN"></a>

 
## <a name="initialuploadrequest"></a><span data-ttu-id="355bf-106">InitialUploadRequest</span><span class="sxs-lookup"><span data-stu-id="355bf-106">InitialUploadRequest</span></span>
 
<span data-ttu-id="355bf-107">InitialUploadRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="355bf-107">The InitialUploadRequest object has the following specification.</span></span>
 
| <span data-ttu-id="355bf-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="355bf-108">Member</span></span>| <span data-ttu-id="355bf-109">種類</span><span class="sxs-lookup"><span data-stu-id="355bf-109">Type</span></span>| <span data-ttu-id="355bf-110">説明</span><span class="sxs-lookup"><span data-stu-id="355bf-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="355bf-111"><b>greatestMomentId</b></span><span class="sxs-lookup"><span data-stu-id="355bf-111"><b>greatestMomentId</b></span></span>| <span data-ttu-id="355bf-112">string</span><span class="sxs-lookup"><span data-stu-id="355bf-112">string</span></span>| <span data-ttu-id="355bf-113">クリップの名前として使用するテキストの文字列 ID。</span><span class="sxs-lookup"><span data-stu-id="355bf-113">The string ID for the text to use as the name for the clip.</span></span> <span data-ttu-id="355bf-114">これの管理し、開発者のタイトルのタイトルの構成ファイルでローカライズされました。</span><span class="sxs-lookup"><span data-stu-id="355bf-114">This is managed and localized in the config file for the title by the developer of the title.</span></span>| 
| <span data-ttu-id="355bf-115"><b>userCaption</b></span><span class="sxs-lookup"><span data-stu-id="355bf-115"><b>userCaption</b></span></span>| <span data-ttu-id="355bf-116">string</span><span class="sxs-lookup"><span data-stu-id="355bf-116">string</span></span>| <span data-ttu-id="355bf-117">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-117">Optional.</span></span> <span data-ttu-id="355bf-118">ユーザー入力の代替名 250 文字の最大長までゲームにクリップします。</span><span class="sxs-lookup"><span data-stu-id="355bf-118">Alternate user-entered name for game clip up to a maximum length of 250 characters.</span></span>| 
| <span data-ttu-id="355bf-119"><b>sessionRef</b></span><span class="sxs-lookup"><span data-stu-id="355bf-119"><b>sessionRef</b></span></span>| <span data-ttu-id="355bf-120">string</span><span class="sxs-lookup"><span data-stu-id="355bf-120">string</span></span>| <span data-ttu-id="355bf-121">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-121">Optional.</span></span> <span data-ttu-id="355bf-122">ゲーム セッションの記録の実行を参照。</span><span class="sxs-lookup"><span data-stu-id="355bf-122">Game session reference during which the recording was done.</span></span>| 
| <span data-ttu-id="355bf-123"><b>dateRecorded</b></span><span class="sxs-lookup"><span data-stu-id="355bf-123"><b>dateRecorded</b></span></span>| <span data-ttu-id="355bf-124">DateTime</span><span class="sxs-lookup"><span data-stu-id="355bf-124">DateTime</span></span>| <span data-ttu-id="355bf-125">(Utc)、記録の開始時刻。</span><span class="sxs-lookup"><span data-stu-id="355bf-125">The time the recording was started, in UTC.</span></span> <span data-ttu-id="355bf-126">ISO 8601 形式の文字列としてマーシャ リング (を参照してください<a href="https://www.w3.org/TR/NOTE-datetime">日付および時刻書式</a>詳細については)。</span><span class="sxs-lookup"><span data-stu-id="355bf-126">Marshalled as a string in ISO 8601 format (see <a href="https://www.w3.org/TR/NOTE-datetime">Date and Time Formats</a> for more information).</span></span>| 
| <span data-ttu-id="355bf-127"><b>durationInSeconds</b></span><span class="sxs-lookup"><span data-stu-id="355bf-127"><b>durationInSeconds</b></span></span>| <span data-ttu-id="355bf-128">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="355bf-128">32-bit unsigned integer</span></span>| <span data-ttu-id="355bf-129">秒単位で、クリップの長さ。</span><span class="sxs-lookup"><span data-stu-id="355bf-129">The length of the clip in seconds.</span></span>| 
| <span data-ttu-id="355bf-130"><b>expectedBlocks</b></span><span class="sxs-lookup"><span data-stu-id="355bf-130"><b>expectedBlocks</b></span></span>| <span data-ttu-id="355bf-131">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="355bf-131">32-bit unsigned integer</span></span>| <span data-ttu-id="355bf-132">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-132">Optional.</span></span> <span data-ttu-id="355bf-133">ファイルの分割にするブロックの数。</span><span class="sxs-lookup"><span data-stu-id="355bf-133">Number of blocks into which file will be divided.</span></span> <span data-ttu-id="355bf-134">ファイルが 1 つの要求で送信される場合は省略します。</span><span class="sxs-lookup"><span data-stu-id="355bf-134">Omit if file will be transmitted in a single request.</span></span>| 
| <span data-ttu-id="355bf-135"><b>fileSize</b></span><span class="sxs-lookup"><span data-stu-id="355bf-135"><b>fileSize</b></span></span>| <span data-ttu-id="355bf-136">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="355bf-136">32-bit unsigned integer</span></span>| <span data-ttu-id="355bf-137">アップロードされるビデオのバイト単位のサイズ。</span><span class="sxs-lookup"><span data-stu-id="355bf-137">File size in bytes of the video that will be uploaded.</span></span>| 
| <span data-ttu-id="355bf-138"><b>型</b></span><span class="sxs-lookup"><span data-stu-id="355bf-138"><b>type</b></span></span>| [<span data-ttu-id="355bf-139">GameClipType 列挙型</span><span class="sxs-lookup"><span data-stu-id="355bf-139">GameClipType Enumeration</span></span>](../enums/gvr-enum-gamecliptypes.md)| <span data-ttu-id="355bf-140">コンマ区切りである列挙体の文字列値としてマーシャ リング、クリップの種類。</span><span class="sxs-lookup"><span data-stu-id="355bf-140">The type of clip, marshaled as a string value of the enumeration that is comma-delimited.</span></span>| 
| <span data-ttu-id="355bf-141"><b>ソース</b></span><span class="sxs-lookup"><span data-stu-id="355bf-141"><b>source</b></span></span>| [<span data-ttu-id="355bf-142">GameClipSource 列挙型</span><span class="sxs-lookup"><span data-stu-id="355bf-142">GameClipSource Enumeration</span></span>](../enums/gvr-enum-gameclipsource.md)| <span data-ttu-id="355bf-143">クリップの元を示す列挙体の文字列値としてマーシャ リングします。</span><span class="sxs-lookup"><span data-stu-id="355bf-143">Specifies how the clip was sourced, marshaled as a string value of the enumeration.</span></span>| 
| <span data-ttu-id="355bf-144"><b>可視性</b></span><span class="sxs-lookup"><span data-stu-id="355bf-144"><b>visibility</b></span></span>| [<span data-ttu-id="355bf-145">GameClipVisibility 列挙型</span><span class="sxs-lookup"><span data-stu-id="355bf-145">GameClipVisibility Enumeration</span></span>](../enums/gvr-enum-gameclipvisibility.md)| <span data-ttu-id="355bf-146">システムで発行されたが、ゲームのクリップの可視性を指定します。</span><span class="sxs-lookup"><span data-stu-id="355bf-146">Specifies the visibility of the game clip once it is published in the system.</span></span>| 
| <span data-ttu-id="355bf-147"><b>titleData</b></span><span class="sxs-lookup"><span data-stu-id="355bf-147"><b>titleData</b></span></span>| <span data-ttu-id="355bf-148">string</span><span class="sxs-lookup"><span data-stu-id="355bf-148">string</span></span>| <span data-ttu-id="355bf-149">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-149">Optional.</span></span> <span data-ttu-id="355bf-150">このクリップに関連付けられているタイトルに固有のプロパティのプロパティ バッグ。</span><span class="sxs-lookup"><span data-stu-id="355bf-150">Property bag for title-specific properties associated with this clip.</span></span> <span data-ttu-id="355bf-151">格納されているし、として返されるは。</span><span class="sxs-lookup"><span data-stu-id="355bf-151">Stored and returned as-is.</span></span> <span data-ttu-id="355bf-152">タイトル開発者は、このフィールドを使用して、クリップに関するメタデータを保持することができます。</span><span class="sxs-lookup"><span data-stu-id="355bf-152">Title developers can use this field to persist their own metadata about a clip.</span></span>| 
| <span data-ttu-id="355bf-153"><b>titleData</b></span><span class="sxs-lookup"><span data-stu-id="355bf-153"><b>titleData</b></span></span>| <span data-ttu-id="355bf-154">string</span><span class="sxs-lookup"><span data-stu-id="355bf-154">string</span></span>| <span data-ttu-id="355bf-155">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-155">Optional.</span></span> <span data-ttu-id="355bf-156">このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグ。</span><span class="sxs-lookup"><span data-stu-id="355bf-156">Property bag for console-specific properties associated with this clip.</span></span> <span data-ttu-id="355bf-157">格納されているし、として返されるは。</span><span class="sxs-lookup"><span data-stu-id="355bf-157">Stored and returned as-is.</span></span> <span data-ttu-id="355bf-158">コンソールのプラットフォームでは、クリップに関するメタデータを保持するのに、このフィールドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="355bf-158">Console Platform can use this field to persist their own metadata about a clip.</span></span>| 
| <span data-ttu-id="355bf-159"><b>systemProperties</b></span><span class="sxs-lookup"><span data-stu-id="355bf-159"><b>systemProperties</b></span></span>| <span data-ttu-id="355bf-160">string</span><span class="sxs-lookup"><span data-stu-id="355bf-160">string</span></span>| <span data-ttu-id="355bf-161">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-161">Optional.</span></span> <span data-ttu-id="355bf-162">このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグ。</span><span class="sxs-lookup"><span data-stu-id="355bf-162">Property bag for console-specific properties associated with this clip.</span></span> <span data-ttu-id="355bf-163">格納されているしが返されます。</span><span class="sxs-lookup"><span data-stu-id="355bf-163">Stored and returned as is.</span></span> <span data-ttu-id="355bf-164">コンソールのプラットフォームでは、クリップに関するメタデータを保持するのに、このフィールドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="355bf-164">Console Platform can use this field to persist their own metadata about a clip.</span></span>| 
| <span data-ttu-id="355bf-165"><b>usersInSession</b></span><span class="sxs-lookup"><span data-stu-id="355bf-165"><b>usersInSession</b></span></span>| <span data-ttu-id="355bf-166">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="355bf-166">array of string</span></span>| <span data-ttu-id="355bf-167">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-167">Optional.</span></span> <span data-ttu-id="355bf-168">現在のセッションでのユーザーの一覧。</span><span class="sxs-lookup"><span data-stu-id="355bf-168">A list of the users in the current session.</span></span>| 
| <span data-ttu-id="355bf-169"><b>thumbnailSource</b></span><span class="sxs-lookup"><span data-stu-id="355bf-169"><b>thumbnailSource</b></span></span>| [<span data-ttu-id="355bf-170">ThumbnailSource 列挙型</span><span class="sxs-lookup"><span data-stu-id="355bf-170">ThumbnailSource Enumeration</span></span>](../enums/gvr-enum-thumbnailsource.md)| <span data-ttu-id="355bf-171">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-171">Optional.</span></span> <span data-ttu-id="355bf-172">サムネイルのソース。</span><span class="sxs-lookup"><span data-stu-id="355bf-172">The source of the thumbnail.</span></span>| 
| <span data-ttu-id="355bf-173"><b>thumbnailOffsetMillseconds</b></span><span class="sxs-lookup"><span data-stu-id="355bf-173"><b>thumbnailOffsetMillseconds</b></span></span>| <span data-ttu-id="355bf-174">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="355bf-174">32-bit signed integer</span></span>| <span data-ttu-id="355bf-175">生成されたサムネイルのオフセットをミリ秒単位のオフセットを指定します。</span><span class="sxs-lookup"><span data-stu-id="355bf-175">Specifies the offset (in milliseconds) for offset generated thumbnails.</span></span> <span data-ttu-id="355bf-176">指定した場合にのみ<b>thumbnailSource</b>オフセットを設定します。</span><span class="sxs-lookup"><span data-stu-id="355bf-176">Only specified when <b>thumbnailSource</b> is set to Offset.</span></span>| 
| <span data-ttu-id="355bf-177"><b>savedByUser</b></span><span class="sxs-lookup"><span data-stu-id="355bf-177"><b>savedByUser</b></span></span>| <span data-ttu-id="355bf-178">ブール値</span><span class="sxs-lookup"><span data-stu-id="355bf-178">Boolean value</span></span>| <span data-ttu-id="355bf-179">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="355bf-179">Optional.</span></span> <span data-ttu-id="355bf-180">FIFO storage ではなく、ユーザーのクォータに保存するクリップを設定します。</span><span class="sxs-lookup"><span data-stu-id="355bf-180">Sets the clip to be saved to the user's quota instead of FIFO storage.</span></span> <span data-ttu-id="355bf-181">既定値は false。</span><span class="sxs-lookup"><span data-stu-id="355bf-181">Defaults to false.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="355bf-182">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="355bf-182">Sample JSON syntax</span></span>
 

```json
{
   "greatestMomentId": "123abc",
   "userCaption": "OMG Look at this!",
   "sessionRef": "4587552a-a5ad-4c4c-a787-5bc5af70e4c9",
   "dateRecorded": "2012-12-23T11:08:08Z",
   "durationInSeconds": 27,
   "expectedBlocks": 7,
   "fileSize": 1234567,
   "type": "MagicMoment, Achievement",
   "source": "Console",
   "visibility": "Default",
   "titleData": "{ 'Boss': 'The Invincible' }",
   "systemProperties": "{ 'Id': '123456', 'Location': 'C:\\videos\\123456.mp4' }",
   "thumbnailSource": "Offset",
   "thumbnailOffsetMillseconds": 20000,
   "savedByUser": false
 }
    
```

  
<a id="ID4E1H"></a>

 
## <a name="see-also"></a><span data-ttu-id="355bf-183">関連項目</span><span class="sxs-lookup"><span data-stu-id="355bf-183">See also</span></span>
 
<a id="ID4E3H"></a>

 
##### <a name="parent"></a><span data-ttu-id="355bf-184">Parent</span><span class="sxs-lookup"><span data-stu-id="355bf-184">Parent</span></span> 

[<span data-ttu-id="355bf-185">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="355bf-185">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   