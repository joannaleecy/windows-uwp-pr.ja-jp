---
title: InitialUploadResponse (JSON)
assetID: 6abb7d37-2c35-2cc3-d9e5-eff695235262
permalink: en-us/docs/xboxlive/rest/json-initialuploadresponse.html
author: KevinAsgari
description: " InitialUploadResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3a643775f835a87b4c1287b0954f698c4c987c10
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/23/2018
ms.locfileid: "5409564"
---
# <a name="initialuploadresponse-json"></a><span data-ttu-id="c31cd-104">InitialUploadResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="c31cd-104">InitialUploadResponse (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="initialuploadresponse"></a><span data-ttu-id="c31cd-105">InitialUploadResponse</span><span class="sxs-lookup"><span data-stu-id="c31cd-105">InitialUploadResponse</span></span>
 
<span data-ttu-id="c31cd-106">InitialUploadResponse オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c31cd-106">The InitialUploadResponse object has the following specification.</span></span>
 
| <span data-ttu-id="c31cd-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="c31cd-107">Member</span></span>| <span data-ttu-id="c31cd-108">種類</span><span class="sxs-lookup"><span data-stu-id="c31cd-108">Type</span></span>| <span data-ttu-id="c31cd-109">説明</span><span class="sxs-lookup"><span data-stu-id="c31cd-109">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="c31cd-110">gameClipId</span><span class="sxs-lookup"><span data-stu-id="c31cd-110">gameClipId</span></span></b>| <span data-ttu-id="c31cd-111">string</span><span class="sxs-lookup"><span data-stu-id="c31cd-111">string</span></span>| <span data-ttu-id="c31cd-112">アップロードのデータ要求に割り当てられている ID。</span><span class="sxs-lookup"><span data-stu-id="c31cd-112">ID assigned for the upload data request.</span></span>| 
| <b><span data-ttu-id="c31cd-113">uploadUri</span><span class="sxs-lookup"><span data-stu-id="c31cd-113">uploadUri</span></span></b>| <span data-ttu-id="c31cd-114">URI</span><span class="sxs-lookup"><span data-stu-id="c31cd-114">URI</span></span>| <span data-ttu-id="c31cd-115">場所は、ゲーム クリップをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c31cd-115">Location to which the game clip should be uploaded.</span></span>| 
| <b><span data-ttu-id="c31cd-116">largeThumbnailUri</span><span class="sxs-lookup"><span data-stu-id="c31cd-116">largeThumbnailUri</span></span></b>| <span data-ttu-id="c31cd-117">URI</span><span class="sxs-lookup"><span data-stu-id="c31cd-117">URI</span></span>| <span data-ttu-id="c31cd-118">省略可能。</span><span class="sxs-lookup"><span data-stu-id="c31cd-118">Optional.</span></span> <span data-ttu-id="c31cd-119">場所は、大きなサムネイルをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c31cd-119">Location to which the large thumbnail should be uploaded.</span></span> <span data-ttu-id="c31cd-120">このフィールドの有無については、(アップロードが指定されているときになります) <b>InitialUploadRequest</b> [ThumbnailSource 列挙型](../enums/gvr-enum-thumbnailsource.md)の値によって決まります。</span><span class="sxs-lookup"><span data-stu-id="c31cd-120">Presence of this field is determined by the [ThumbnailSource Enumeration](../enums/gvr-enum-thumbnailsource.md) value in the <b>InitialUploadRequest</b> (will be present when the upload is specified).</span></span>| 
| <b><span data-ttu-id="c31cd-121">smallThumbnailUri</span><span class="sxs-lookup"><span data-stu-id="c31cd-121">smallThumbnailUri</span></span></b>| <span data-ttu-id="c31cd-122">URI</span><span class="sxs-lookup"><span data-stu-id="c31cd-122">URI</span></span>| <span data-ttu-id="c31cd-123">省略可能。</span><span class="sxs-lookup"><span data-stu-id="c31cd-123">Optional.</span></span> <span data-ttu-id="c31cd-124">小さなサムネイルのアップロード場所です。</span><span class="sxs-lookup"><span data-stu-id="c31cd-124">Location to which the small thumbnail should be uploaded.</span></span> <span data-ttu-id="c31cd-125">このフィールドの有無については、(アップロードが指定されているときになります) <b>InitialUploadRequest</b> [ThumbnailSource 列挙型](../enums/gvr-enum-thumbnailsource.md)の値によって決まります。</span><span class="sxs-lookup"><span data-stu-id="c31cd-125">Presence of this field is determined by the [ThumbnailSource Enumeration](../enums/gvr-enum-thumbnailsource.md) value in the <b>InitialUploadRequest</b> (will be present when the upload is specified).</span></span>| 
  
<a id="ID4EYC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="c31cd-126">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="c31cd-126">Sample JSON syntax</span></span>
 

```json
{
   "gameClipId": "6b364924-5650-480f-86a7-fc002a1ee752"  ,  
   "uploadUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container",
   "largeThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/large",
   "smallThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/small"
 }
    
```

  
<a id="ID4EBD"></a>

 
## <a name="see-also"></a><span data-ttu-id="c31cd-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="c31cd-127">See also</span></span>
 
<a id="ID4EDD"></a>

 
##### <a name="parent"></a><span data-ttu-id="c31cd-128">Parent</span><span class="sxs-lookup"><span data-stu-id="c31cd-128">Parent</span></span> 

[<span data-ttu-id="c31cd-129">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c31cd-129">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   