---
title: GameClipThumbnail (JSON)
assetID: 3ed87fc1-734c-d8b5-d908-0ae3359769ed
permalink: en-us/docs/xboxlive/rest/json-gameclipthumbnail.html
author: KevinAsgari
description: " GameClipThumbnail (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4fae93f76d9c8647b2d4264463b434d86897e2a5
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7575605"
---
# <a name="gameclipthumbnail-json"></a><span data-ttu-id="ec0f5-104">GameClipThumbnail (JSON)</span><span class="sxs-lookup"><span data-stu-id="ec0f5-104">GameClipThumbnail (JSON)</span></span>
<span data-ttu-id="ec0f5-105">個々 のサムネイルに関連する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="ec0f5-105">Contains the information related to an individual thumbnail.</span></span> <span data-ttu-id="ec0f5-106">1 つのクリップを複数のサイズが存在することができますされ、表示用の適切なものを選択するクライアントまでなります。</span><span class="sxs-lookup"><span data-stu-id="ec0f5-106">There can be multiple sizes per clip, and it is up to the client to select the proper one for display.</span></span> 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a><span data-ttu-id="ec0f5-107">GameClipThumbnail</span><span class="sxs-lookup"><span data-stu-id="ec0f5-107">GameClipThumbnail</span></span>
 
<span data-ttu-id="ec0f5-108">GameClipThumbnail オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="ec0f5-108">The GameClipThumbnail object has the following specification.</span></span>
 
| <span data-ttu-id="ec0f5-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="ec0f5-109">Member</span></span>| <span data-ttu-id="ec0f5-110">種類</span><span class="sxs-lookup"><span data-stu-id="ec0f5-110">Type</span></span>| <span data-ttu-id="ec0f5-111">説明</span><span class="sxs-lookup"><span data-stu-id="ec0f5-111">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="ec0f5-112">uri</span><span class="sxs-lookup"><span data-stu-id="ec0f5-112">uri</span></span></b>| <span data-ttu-id="ec0f5-113">string</span><span class="sxs-lookup"><span data-stu-id="ec0f5-113">string</span></span>| <span data-ttu-id="ec0f5-114">サムネイル画像の URI です。</span><span class="sxs-lookup"><span data-stu-id="ec0f5-114">The URI for the thumbnail image.</span></span>| 
| <b><span data-ttu-id="ec0f5-115">fileSize</span><span class="sxs-lookup"><span data-stu-id="ec0f5-115">fileSize</span></span></b>| <span data-ttu-id="ec0f5-116">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="ec0f5-116">32-bit unsigned integer</span></span>| <span data-ttu-id="ec0f5-117">サムネイル画像の合計ファイル サイズ。</span><span class="sxs-lookup"><span data-stu-id="ec0f5-117">The total file size of the thumbnail image.</span></span>| 
| <b><span data-ttu-id="ec0f5-118">thumbnailType</span><span class="sxs-lookup"><span data-stu-id="ec0f5-118">thumbnailType</span></span></b>| <span data-ttu-id="ec0f5-119">ThumbnailType</span><span class="sxs-lookup"><span data-stu-id="ec0f5-119">ThumbnailType</span></span>| <span data-ttu-id="ec0f5-120">サムネイル画像の種類です。</span><span class="sxs-lookup"><span data-stu-id="ec0f5-120">The type of thumbnail image.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="ec0f5-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="ec0f5-121">Sample JSON syntax</span></span>
 

```json
{
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ec0f5-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="ec0f5-122">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ec0f5-123">Parent</span><span class="sxs-lookup"><span data-stu-id="ec0f5-123">Parent</span></span> 

[<span data-ttu-id="ec0f5-124">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="ec0f5-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   