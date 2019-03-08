---
title: InitialUploadResponse (JSON)
assetID: 6abb7d37-2c35-2cc3-d9e5-eff695235262
permalink: en-us/docs/xboxlive/rest/json-initialuploadresponse.html
description: " InitialUploadResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: dab59fefb389cf550a1bc4fc6429f6b0970f50ab
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57589837"
---
# <a name="initialuploadresponse-json"></a><span data-ttu-id="9b6ff-104">InitialUploadResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="9b6ff-104">InitialUploadResponse (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="initialuploadresponse"></a><span data-ttu-id="9b6ff-105">InitialUploadResponse</span><span class="sxs-lookup"><span data-stu-id="9b6ff-105">InitialUploadResponse</span></span>
 
<span data-ttu-id="9b6ff-106">InitialUploadResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-106">The InitialUploadResponse object has the following specification.</span></span>
 
| <span data-ttu-id="9b6ff-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="9b6ff-107">Member</span></span>| <span data-ttu-id="9b6ff-108">種類</span><span class="sxs-lookup"><span data-stu-id="9b6ff-108">Type</span></span>| <span data-ttu-id="9b6ff-109">説明</span><span class="sxs-lookup"><span data-stu-id="9b6ff-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9b6ff-110"><b>gameClipId</b></span><span class="sxs-lookup"><span data-stu-id="9b6ff-110"><b>gameClipId</b></span></span>| <span data-ttu-id="9b6ff-111">string</span><span class="sxs-lookup"><span data-stu-id="9b6ff-111">string</span></span>| <span data-ttu-id="9b6ff-112">データ要求のアップロードに割り当てられた ID。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-112">ID assigned for the upload data request.</span></span>| 
| <span data-ttu-id="9b6ff-113"><b>uploadUri</b></span><span class="sxs-lookup"><span data-stu-id="9b6ff-113"><b>uploadUri</b></span></span>| <span data-ttu-id="9b6ff-114">URI</span><span class="sxs-lookup"><span data-stu-id="9b6ff-114">URI</span></span>| <span data-ttu-id="9b6ff-115">ゲームのクリップのアップロード先となる場所です。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-115">Location to which the game clip should be uploaded.</span></span>| 
| <span data-ttu-id="9b6ff-116"><b>largeThumbnailUri</b></span><span class="sxs-lookup"><span data-stu-id="9b6ff-116"><b>largeThumbnailUri</b></span></span>| <span data-ttu-id="9b6ff-117">URI</span><span class="sxs-lookup"><span data-stu-id="9b6ff-117">URI</span></span>| <span data-ttu-id="9b6ff-118">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-118">Optional.</span></span> <span data-ttu-id="9b6ff-119">場所は、大規模なサムネイルをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-119">Location to which the large thumbnail should be uploaded.</span></span> <span data-ttu-id="9b6ff-120">このフィールドの存在が続く、 [ThumbnailSource 列挙](../enums/gvr-enum-thumbnailsource.md)値、 <b>InitialUploadRequest</b> (存在するが、アップロードが指定されている場合になります)。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-120">Presence of this field is determined by the [ThumbnailSource Enumeration](../enums/gvr-enum-thumbnailsource.md) value in the <b>InitialUploadRequest</b> (will be present when the upload is specified).</span></span>| 
| <span data-ttu-id="9b6ff-121"><b>smallThumbnailUri</b></span><span class="sxs-lookup"><span data-stu-id="9b6ff-121"><b>smallThumbnailUri</b></span></span>| <span data-ttu-id="9b6ff-122">URI</span><span class="sxs-lookup"><span data-stu-id="9b6ff-122">URI</span></span>| <span data-ttu-id="9b6ff-123">(省略可能)。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-123">Optional.</span></span> <span data-ttu-id="9b6ff-124">小規模のサムネイルのアップロード先となる場所です。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-124">Location to which the small thumbnail should be uploaded.</span></span> <span data-ttu-id="9b6ff-125">このフィールドの存在が続く、 [ThumbnailSource 列挙](../enums/gvr-enum-thumbnailsource.md)値、 <b>InitialUploadRequest</b> (存在するが、アップロードが指定されている場合になります)。</span><span class="sxs-lookup"><span data-stu-id="9b6ff-125">Presence of this field is determined by the [ThumbnailSource Enumeration](../enums/gvr-enum-thumbnailsource.md) value in the <b>InitialUploadRequest</b> (will be present when the upload is specified).</span></span>| 
  
<a id="ID4EYC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="9b6ff-126">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="9b6ff-126">Sample JSON syntax</span></span>
 

```json
{
   "gameClipId": "6b364924-5650-480f-86a7-fc002a1ee752"  ,  
   "uploadUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container",
   "largeThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/large",
   "smallThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/small"
 }
    
```

  
<a id="ID4EBD"></a>

 
## <a name="see-also"></a><span data-ttu-id="9b6ff-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="9b6ff-127">See also</span></span>
 
<a id="ID4EDD"></a>

 
##### <a name="parent"></a><span data-ttu-id="9b6ff-128">Parent</span><span class="sxs-lookup"><span data-stu-id="9b6ff-128">Parent</span></span> 

[<span data-ttu-id="9b6ff-129">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="9b6ff-129">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   