---
title: InitialUploadRequest (JSON)
assetID: 8b8bce98-cb5f-bbaf-5564-9be2f58d749b
permalink: en-us/docs/xboxlive/rest/json-initialuploadrequest.html
author: KevinAsgari
description: " InitialUploadRequest (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: b6a0856c23ebaf06eab7ef7fc1688e06cc445b4b
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6025038"
---
# <a name="initialuploadrequest-json"></a><span data-ttu-id="54b17-104">InitialUploadRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="54b17-104">InitialUploadRequest (JSON)</span></span>
<span data-ttu-id="54b17-105">POST GameClip の本文は、要求をアップロードします。</span><span class="sxs-lookup"><span data-stu-id="54b17-105">The body of a POST GameClip upload request.</span></span> 
<a id="ID4EN"></a>

 
## <a name="initialuploadrequest"></a><span data-ttu-id="54b17-106">InitialUploadRequest</span><span class="sxs-lookup"><span data-stu-id="54b17-106">InitialUploadRequest</span></span>
 
<span data-ttu-id="54b17-107">InitialUploadRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="54b17-107">The InitialUploadRequest object has the following specification.</span></span>
 
| <span data-ttu-id="54b17-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="54b17-108">Member</span></span>| <span data-ttu-id="54b17-109">種類</span><span class="sxs-lookup"><span data-stu-id="54b17-109">Type</span></span>| <span data-ttu-id="54b17-110">説明</span><span class="sxs-lookup"><span data-stu-id="54b17-110">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="54b17-111">greatestMomentId</span><span class="sxs-lookup"><span data-stu-id="54b17-111">greatestMomentId</span></span></b>| <span data-ttu-id="54b17-112">string</span><span class="sxs-lookup"><span data-stu-id="54b17-112">string</span></span>| <span data-ttu-id="54b17-113">文字列は、テキストのクリップの名として使用する ID。</span><span class="sxs-lookup"><span data-stu-id="54b17-113">The string ID for the text to use as the name for the clip.</span></span> <span data-ttu-id="54b17-114">これの管理し、タイトルの開発者によってタイトルの構成ファイル内のローカライズされました。</span><span class="sxs-lookup"><span data-stu-id="54b17-114">This is managed and localized in the config file for the title by the developer of the title.</span></span>| 
| <b><span data-ttu-id="54b17-115">userCaption</span><span class="sxs-lookup"><span data-stu-id="54b17-115">userCaption</span></span></b>| <span data-ttu-id="54b17-116">string</span><span class="sxs-lookup"><span data-stu-id="54b17-116">string</span></span>| <span data-ttu-id="54b17-117">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-117">Optional.</span></span> <span data-ttu-id="54b17-118">ユーザーが入力したの代替名最大 250 文字の最大長のゲーム クリップされます。</span><span class="sxs-lookup"><span data-stu-id="54b17-118">Alternate user-entered name for game clip up to a maximum length of 250 characters.</span></span>| 
| <b><span data-ttu-id="54b17-119">sessionRef</span><span class="sxs-lookup"><span data-stu-id="54b17-119">sessionRef</span></span></b>| <span data-ttu-id="54b17-120">string</span><span class="sxs-lookup"><span data-stu-id="54b17-120">string</span></span>| <span data-ttu-id="54b17-121">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-121">Optional.</span></span> <span data-ttu-id="54b17-122">レコーディングの実行中になるゲーム セッションの参照です。</span><span class="sxs-lookup"><span data-stu-id="54b17-122">Game session reference during which the recording was done.</span></span>| 
| <b><span data-ttu-id="54b17-123">dateRecorded</span><span class="sxs-lookup"><span data-stu-id="54b17-123">dateRecorded</span></span></b>| <span data-ttu-id="54b17-124">DateTime</span><span class="sxs-lookup"><span data-stu-id="54b17-124">DateTime</span></span>| <span data-ttu-id="54b17-125">UTC で、レコーディングを開始した時刻。</span><span class="sxs-lookup"><span data-stu-id="54b17-125">The time the recording was started, in UTC.</span></span> <span data-ttu-id="54b17-126">ISO 8601 形式の文字列としてマーシャ リング (詳細については、<a href="http://www.w3.org/TR/NOTE-datetime">日付と時刻の形式</a>を参照) の書式を設定します。</span><span class="sxs-lookup"><span data-stu-id="54b17-126">Marshalled as a string in ISO 8601 format (see <a href="http://www.w3.org/TR/NOTE-datetime">Date and Time Formats</a> for more information).</span></span>| 
| <b><span data-ttu-id="54b17-127">durationInSeconds</span><span class="sxs-lookup"><span data-stu-id="54b17-127">durationInSeconds</span></span></b>| <span data-ttu-id="54b17-128">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="54b17-128">32-bit unsigned integer</span></span>| <span data-ttu-id="54b17-129">秒単位でのクリップの長さ。</span><span class="sxs-lookup"><span data-stu-id="54b17-129">The length of the clip in seconds.</span></span>| 
| <b><span data-ttu-id="54b17-130">expectedBlocks</span><span class="sxs-lookup"><span data-stu-id="54b17-130">expectedBlocks</span></span></b>| <span data-ttu-id="54b17-131">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="54b17-131">32-bit unsigned integer</span></span>| <span data-ttu-id="54b17-132">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-132">Optional.</span></span> <span data-ttu-id="54b17-133">ファイルを分類するブロックの数。</span><span class="sxs-lookup"><span data-stu-id="54b17-133">Number of blocks into which file will be divided.</span></span> <span data-ttu-id="54b17-134">省略ファイルは、1 つの要求で送信されます。</span><span class="sxs-lookup"><span data-stu-id="54b17-134">Omit if file will be transmitted in a single request.</span></span>| 
| <b><span data-ttu-id="54b17-135">fileSize</span><span class="sxs-lookup"><span data-stu-id="54b17-135">fileSize</span></span></b>| <span data-ttu-id="54b17-136">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="54b17-136">32-bit unsigned integer</span></span>| <span data-ttu-id="54b17-137">ファイル サイズのアップロードされるビデオのバイト数。</span><span class="sxs-lookup"><span data-stu-id="54b17-137">File size in bytes of the video that will be uploaded.</span></span>| 
| <b><span data-ttu-id="54b17-138">type</span><span class="sxs-lookup"><span data-stu-id="54b17-138">type</span></span></b>| [<span data-ttu-id="54b17-139">GameClipType 列挙型</span><span class="sxs-lookup"><span data-stu-id="54b17-139">GameClipType Enumeration</span></span>](../enums/gvr-enum-gamecliptypes.md)| <span data-ttu-id="54b17-140">コンマ区切りで列挙型の文字列値としてマーシャ リング、クリップの種類です。</span><span class="sxs-lookup"><span data-stu-id="54b17-140">The type of clip, marshaled as a string value of the enumeration that is comma-delimited.</span></span>| 
| <b><span data-ttu-id="54b17-141">ソース</span><span class="sxs-lookup"><span data-stu-id="54b17-141">source</span></span></b>| [<span data-ttu-id="54b17-142">GameClipSource 列挙型</span><span class="sxs-lookup"><span data-stu-id="54b17-142">GameClipSource Enumeration</span></span>](../enums/gvr-enum-gameclipsource.md)| <span data-ttu-id="54b17-143">クリップの元の指定、列挙体の文字列値としてマーシャ リングします。</span><span class="sxs-lookup"><span data-stu-id="54b17-143">Specifies how the clip was sourced, marshaled as a string value of the enumeration.</span></span>| 
| <b><span data-ttu-id="54b17-144">visibility</span><span class="sxs-lookup"><span data-stu-id="54b17-144">visibility</span></span></b>| [<span data-ttu-id="54b17-145">GameClipVisibility 列挙型</span><span class="sxs-lookup"><span data-stu-id="54b17-145">GameClipVisibility Enumeration</span></span>](../enums/gvr-enum-gameclipvisibility.md)| <span data-ttu-id="54b17-146">システムの公開後に、ゲーム クリップの可視性を指定します。</span><span class="sxs-lookup"><span data-stu-id="54b17-146">Specifies the visibility of the game clip once it is published in the system.</span></span>| 
| <b><span data-ttu-id="54b17-147">titleData</span><span class="sxs-lookup"><span data-stu-id="54b17-147">titleData</span></span></b>| <span data-ttu-id="54b17-148">string</span><span class="sxs-lookup"><span data-stu-id="54b17-148">string</span></span>| <span data-ttu-id="54b17-149">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-149">Optional.</span></span> <span data-ttu-id="54b17-150">このクリップに関連付けられているタイトル固有のプロパティのプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="54b17-150">Property bag for title-specific properties associated with this clip.</span></span> <span data-ttu-id="54b17-151">格納され、として返された-です。</span><span class="sxs-lookup"><span data-stu-id="54b17-151">Stored and returned as-is.</span></span> <span data-ttu-id="54b17-152">タイトル デベロッパーは、クリップに関するメタデータを保持するため、このフィールドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="54b17-152">Title developers can use this field to persist their own metadata about a clip.</span></span>| 
| <b><span data-ttu-id="54b17-153">titleData</span><span class="sxs-lookup"><span data-stu-id="54b17-153">titleData</span></span></b>| <span data-ttu-id="54b17-154">string</span><span class="sxs-lookup"><span data-stu-id="54b17-154">string</span></span>| <span data-ttu-id="54b17-155">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-155">Optional.</span></span> <span data-ttu-id="54b17-156">このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="54b17-156">Property bag for console-specific properties associated with this clip.</span></span> <span data-ttu-id="54b17-157">格納され、として返された-です。</span><span class="sxs-lookup"><span data-stu-id="54b17-157">Stored and returned as-is.</span></span> <span data-ttu-id="54b17-158">本体のプラットフォームでは、クリップに関するメタデータを保持するため、このフィールドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="54b17-158">Console Platform can use this field to persist their own metadata about a clip.</span></span>| 
| <b><span data-ttu-id="54b17-159">systemProperties</span><span class="sxs-lookup"><span data-stu-id="54b17-159">systemProperties</span></span></b>| <span data-ttu-id="54b17-160">string</span><span class="sxs-lookup"><span data-stu-id="54b17-160">string</span></span>| <span data-ttu-id="54b17-161">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-161">Optional.</span></span> <span data-ttu-id="54b17-162">このクリップに関連付けられているコンソールに固有のプロパティのプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="54b17-162">Property bag for console-specific properties associated with this clip.</span></span> <span data-ttu-id="54b17-163">格納され、として返されます。</span><span class="sxs-lookup"><span data-stu-id="54b17-163">Stored and returned as is.</span></span> <span data-ttu-id="54b17-164">本体のプラットフォームでは、クリップに関するメタデータを保持するため、このフィールドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="54b17-164">Console Platform can use this field to persist their own metadata about a clip.</span></span>| 
| <b><span data-ttu-id="54b17-165">usersInSession</span><span class="sxs-lookup"><span data-stu-id="54b17-165">usersInSession</span></span></b>| <span data-ttu-id="54b17-166">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="54b17-166">array of string</span></span>| <span data-ttu-id="54b17-167">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-167">Optional.</span></span> <span data-ttu-id="54b17-168">現在のセッション内のユーザーの一覧。</span><span class="sxs-lookup"><span data-stu-id="54b17-168">A list of the users in the current session.</span></span>| 
| <b><span data-ttu-id="54b17-169">thumbnailSource</span><span class="sxs-lookup"><span data-stu-id="54b17-169">thumbnailSource</span></span></b>| [<span data-ttu-id="54b17-170">ThumbnailSource 列挙型</span><span class="sxs-lookup"><span data-stu-id="54b17-170">ThumbnailSource Enumeration</span></span>](../enums/gvr-enum-thumbnailsource.md)| <span data-ttu-id="54b17-171">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-171">Optional.</span></span> <span data-ttu-id="54b17-172">サムネイルのソース。</span><span class="sxs-lookup"><span data-stu-id="54b17-172">The source of the thumbnail.</span></span>| 
| <b><span data-ttu-id="54b17-173">thumbnailOffsetMillseconds</span><span class="sxs-lookup"><span data-stu-id="54b17-173">thumbnailOffsetMillseconds</span></span></b>| <span data-ttu-id="54b17-174">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="54b17-174">32-bit signed integer</span></span>| <span data-ttu-id="54b17-175">生成されたオフセットのサムネイルを (ミリ秒単位) のオフセットを指定します。</span><span class="sxs-lookup"><span data-stu-id="54b17-175">Specifies the offset (in milliseconds) for offset generated thumbnails.</span></span> <span data-ttu-id="54b17-176"><b>ThumbnailSource</b>をオフセットを設定するときに指定だけです。</span><span class="sxs-lookup"><span data-stu-id="54b17-176">Only specified when <b>thumbnailSource</b> is set to Offset.</span></span>| 
| <b><span data-ttu-id="54b17-177">savedByUser</span><span class="sxs-lookup"><span data-stu-id="54b17-177">savedByUser</span></span></b>| <span data-ttu-id="54b17-178">ブール値</span><span class="sxs-lookup"><span data-stu-id="54b17-178">Boolean value</span></span>| <span data-ttu-id="54b17-179">省略可能。</span><span class="sxs-lookup"><span data-stu-id="54b17-179">Optional.</span></span> <span data-ttu-id="54b17-180">FIFO 記憶域ではなく、ユーザーのクォータに保存するクリップを設定します。</span><span class="sxs-lookup"><span data-stu-id="54b17-180">Sets the clip to be saved to the user's quota instead of FIFO storage.</span></span> <span data-ttu-id="54b17-181">既定値は false です。</span><span class="sxs-lookup"><span data-stu-id="54b17-181">Defaults to false.</span></span>| 
  
<a id="ID4ERH"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="54b17-182">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="54b17-182">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="54b17-183">関連項目</span><span class="sxs-lookup"><span data-stu-id="54b17-183">See also</span></span>
 
<a id="ID4E3H"></a>

 
##### <a name="parent"></a><span data-ttu-id="54b17-184">Parent</span><span class="sxs-lookup"><span data-stu-id="54b17-184">Parent</span></span> 

[<span data-ttu-id="54b17-185">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="54b17-185">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   