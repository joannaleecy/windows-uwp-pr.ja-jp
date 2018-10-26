---
title: GameClipThumbnail (JSON)
assetID: 3ed87fc1-734c-d8b5-d908-0ae3359769ed
permalink: en-us/docs/xboxlive/rest/json-gameclipthumbnail.html
author: KevinAsgari
description: " GameClipThumbnail (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 8dbf2343f293c7a78c467da651f2185b738b9df8
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5559709"
---
# <a name="gameclipthumbnail-json"></a><span data-ttu-id="d52dc-104">GameClipThumbnail (JSON)</span><span class="sxs-lookup"><span data-stu-id="d52dc-104">GameClipThumbnail (JSON)</span></span>
<span data-ttu-id="d52dc-105">個々 のサムネイルに関連する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="d52dc-105">Contains the information related to an individual thumbnail.</span></span> <span data-ttu-id="d52dc-106">1 つのクリップを複数のサイズが存在することができ、表示用の適切なものを選択するクライアントがします。</span><span class="sxs-lookup"><span data-stu-id="d52dc-106">There can be multiple sizes per clip, and it is up to the client to select the proper one for display.</span></span> 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a><span data-ttu-id="d52dc-107">GameClipThumbnail</span><span class="sxs-lookup"><span data-stu-id="d52dc-107">GameClipThumbnail</span></span>
 
<span data-ttu-id="d52dc-108">GameClipThumbnail オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d52dc-108">The GameClipThumbnail object has the following specification.</span></span>
 
| <span data-ttu-id="d52dc-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="d52dc-109">Member</span></span>| <span data-ttu-id="d52dc-110">種類</span><span class="sxs-lookup"><span data-stu-id="d52dc-110">Type</span></span>| <span data-ttu-id="d52dc-111">説明</span><span class="sxs-lookup"><span data-stu-id="d52dc-111">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="d52dc-112">uri</span><span class="sxs-lookup"><span data-stu-id="d52dc-112">uri</span></span></b>| <span data-ttu-id="d52dc-113">string</span><span class="sxs-lookup"><span data-stu-id="d52dc-113">string</span></span>| <span data-ttu-id="d52dc-114">サムネイル画像の URI です。</span><span class="sxs-lookup"><span data-stu-id="d52dc-114">The URI for the thumbnail image.</span></span>| 
| <b><span data-ttu-id="d52dc-115">fileSize</span><span class="sxs-lookup"><span data-stu-id="d52dc-115">fileSize</span></span></b>| <span data-ttu-id="d52dc-116">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d52dc-116">32-bit unsigned integer</span></span>| <span data-ttu-id="d52dc-117">サムネイル画像の合計ファイル サイズ。</span><span class="sxs-lookup"><span data-stu-id="d52dc-117">The total file size of the thumbnail image.</span></span>| 
| <b><span data-ttu-id="d52dc-118">thumbnailType</span><span class="sxs-lookup"><span data-stu-id="d52dc-118">thumbnailType</span></span></b>| <span data-ttu-id="d52dc-119">ThumbnailType</span><span class="sxs-lookup"><span data-stu-id="d52dc-119">ThumbnailType</span></span>| <span data-ttu-id="d52dc-120">サムネイル画像の種類です。</span><span class="sxs-lookup"><span data-stu-id="d52dc-120">The type of thumbnail image.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d52dc-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d52dc-121">Sample JSON syntax</span></span>
 

```json
{
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d52dc-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="d52dc-122">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d52dc-123">Parent</span><span class="sxs-lookup"><span data-stu-id="d52dc-123">Parent</span></span> 

[<span data-ttu-id="d52dc-124">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d52dc-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   