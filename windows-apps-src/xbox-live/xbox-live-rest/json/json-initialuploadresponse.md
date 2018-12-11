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
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8888095"
---
# <a name="initialuploadresponse-json"></a><span data-ttu-id="2f20c-104">InitialUploadResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="2f20c-104">InitialUploadResponse (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="initialuploadresponse"></a><span data-ttu-id="2f20c-105">InitialUploadResponse</span><span class="sxs-lookup"><span data-stu-id="2f20c-105">InitialUploadResponse</span></span>
 
<span data-ttu-id="2f20c-106">InitialUploadResponse オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="2f20c-106">The InitialUploadResponse object has the following specification.</span></span>
 
| <span data-ttu-id="2f20c-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="2f20c-107">Member</span></span>| <span data-ttu-id="2f20c-108">種類</span><span class="sxs-lookup"><span data-stu-id="2f20c-108">Type</span></span>| <span data-ttu-id="2f20c-109">説明</span><span class="sxs-lookup"><span data-stu-id="2f20c-109">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="2f20c-110">gameClipId</span><span class="sxs-lookup"><span data-stu-id="2f20c-110">gameClipId</span></span></b>| <span data-ttu-id="2f20c-111">string</span><span class="sxs-lookup"><span data-stu-id="2f20c-111">string</span></span>| <span data-ttu-id="2f20c-112">アップロードのデータ要求に割り当てられている ID。</span><span class="sxs-lookup"><span data-stu-id="2f20c-112">ID assigned for the upload data request.</span></span>| 
| <b><span data-ttu-id="2f20c-113">uploadUri</span><span class="sxs-lookup"><span data-stu-id="2f20c-113">uploadUri</span></span></b>| <span data-ttu-id="2f20c-114">URI</span><span class="sxs-lookup"><span data-stu-id="2f20c-114">URI</span></span>| <span data-ttu-id="2f20c-115">場所は、ゲーム クリップをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f20c-115">Location to which the game clip should be uploaded.</span></span>| 
| <b><span data-ttu-id="2f20c-116">largeThumbnailUri</span><span class="sxs-lookup"><span data-stu-id="2f20c-116">largeThumbnailUri</span></span></b>| <span data-ttu-id="2f20c-117">URI</span><span class="sxs-lookup"><span data-stu-id="2f20c-117">URI</span></span>| <span data-ttu-id="2f20c-118">省略可能。</span><span class="sxs-lookup"><span data-stu-id="2f20c-118">Optional.</span></span> <span data-ttu-id="2f20c-119">場所は、大きなサムネイルをアップロードする必要があります。</span><span class="sxs-lookup"><span data-stu-id="2f20c-119">Location to which the large thumbnail should be uploaded.</span></span> <span data-ttu-id="2f20c-120">このフィールドの有無については、(存在するは、アップロードが指定されているときになります) <b>InitialUploadRequest</b> [ThumbnailSource 列挙型](../enums/gvr-enum-thumbnailsource.md)の値によって決まります。</span><span class="sxs-lookup"><span data-stu-id="2f20c-120">Presence of this field is determined by the [ThumbnailSource Enumeration](../enums/gvr-enum-thumbnailsource.md) value in the <b>InitialUploadRequest</b> (will be present when the upload is specified).</span></span>| 
| <b><span data-ttu-id="2f20c-121">smallThumbnailUri</span><span class="sxs-lookup"><span data-stu-id="2f20c-121">smallThumbnailUri</span></span></b>| <span data-ttu-id="2f20c-122">URI</span><span class="sxs-lookup"><span data-stu-id="2f20c-122">URI</span></span>| <span data-ttu-id="2f20c-123">省略可能。</span><span class="sxs-lookup"><span data-stu-id="2f20c-123">Optional.</span></span> <span data-ttu-id="2f20c-124">小さなサムネイルのアップロード場所です。</span><span class="sxs-lookup"><span data-stu-id="2f20c-124">Location to which the small thumbnail should be uploaded.</span></span> <span data-ttu-id="2f20c-125">このフィールドの有無については、(存在するは、アップロードが指定されているときになります) <b>InitialUploadRequest</b> [ThumbnailSource 列挙型](../enums/gvr-enum-thumbnailsource.md)の値によって決まります。</span><span class="sxs-lookup"><span data-stu-id="2f20c-125">Presence of this field is determined by the [ThumbnailSource Enumeration](../enums/gvr-enum-thumbnailsource.md) value in the <b>InitialUploadRequest</b> (will be present when the upload is specified).</span></span>| 
  
<a id="ID4EYC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="2f20c-126">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="2f20c-126">Sample JSON syntax</span></span>
 

```json
{
   "gameClipId": "6b364924-5650-480f-86a7-fc002a1ee752"  ,  
   "uploadUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container",
   "largeThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/large",
   "smallThumbnailUri": "https://gameclips.xbox.live/upload/xuid(2716903703773872)/6b364924-5650-480f-86a7-fc002a1ee752/container/thumbnails/small"
 }
    
```

  
<a id="ID4EBD"></a>

 
## <a name="see-also"></a><span data-ttu-id="2f20c-127">関連項目</span><span class="sxs-lookup"><span data-stu-id="2f20c-127">See also</span></span>
 
<a id="ID4EDD"></a>

 
##### <a name="parent"></a><span data-ttu-id="2f20c-128">Parent</span><span class="sxs-lookup"><span data-stu-id="2f20c-128">Parent</span></span> 

[<span data-ttu-id="2f20c-129">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="2f20c-129">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   