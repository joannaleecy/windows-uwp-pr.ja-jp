---
title: GameClipThumbnail (JSON)
assetID: 3ed87fc1-734c-d8b5-d908-0ae3359769ed
permalink: en-us/docs/xboxlive/rest/json-gameclipthumbnail.html
author: KevinAsgari
description: " GameClipThumbnail (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 681a269cd861f741e2bbde3554acc1b25104d90d
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4205781"
---
# <a name="gameclipthumbnail-json"></a><span data-ttu-id="5ac81-104">GameClipThumbnail (JSON)</span><span class="sxs-lookup"><span data-stu-id="5ac81-104">GameClipThumbnail (JSON)</span></span>
<span data-ttu-id="5ac81-105">個々 のサムネイルに関連する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="5ac81-105">Contains the information related to an individual thumbnail.</span></span> <span data-ttu-id="5ac81-106">1 つのクリップを複数のサイズが存在することができ、表示用の適切なものを選択するクライアントがします。</span><span class="sxs-lookup"><span data-stu-id="5ac81-106">There can be multiple sizes per clip, and it is up to the client to select the proper one for display.</span></span> 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a><span data-ttu-id="5ac81-107">GameClipThumbnail</span><span class="sxs-lookup"><span data-stu-id="5ac81-107">GameClipThumbnail</span></span>
 
<span data-ttu-id="5ac81-108">GameClipThumbnail オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="5ac81-108">The GameClipThumbnail object has the following specification.</span></span>
 
| <span data-ttu-id="5ac81-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="5ac81-109">Member</span></span>| <span data-ttu-id="5ac81-110">種類</span><span class="sxs-lookup"><span data-stu-id="5ac81-110">Type</span></span>| <span data-ttu-id="5ac81-111">説明</span><span class="sxs-lookup"><span data-stu-id="5ac81-111">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="5ac81-112">uri</span><span class="sxs-lookup"><span data-stu-id="5ac81-112">uri</span></span></b>| <span data-ttu-id="5ac81-113">string</span><span class="sxs-lookup"><span data-stu-id="5ac81-113">string</span></span>| <span data-ttu-id="5ac81-114">サムネイル画像の URI。</span><span class="sxs-lookup"><span data-stu-id="5ac81-114">The URI for the thumbnail image.</span></span>| 
| <b><span data-ttu-id="5ac81-115">fileSize</span><span class="sxs-lookup"><span data-stu-id="5ac81-115">fileSize</span></span></b>| <span data-ttu-id="5ac81-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="5ac81-116">32-bit unsigned integer</span></span>| <span data-ttu-id="5ac81-117">サムネイル画像のファイルの合計サイズ。</span><span class="sxs-lookup"><span data-stu-id="5ac81-117">The total file size of the thumbnail image.</span></span>| 
| <b><span data-ttu-id="5ac81-118">thumbnailType</span><span class="sxs-lookup"><span data-stu-id="5ac81-118">thumbnailType</span></span></b>| <span data-ttu-id="5ac81-119">ThumbnailType</span><span class="sxs-lookup"><span data-stu-id="5ac81-119">ThumbnailType</span></span>| <span data-ttu-id="5ac81-120">サムネイル画像の種類です。</span><span class="sxs-lookup"><span data-stu-id="5ac81-120">The type of thumbnail image.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="5ac81-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="5ac81-121">Sample JSON syntax</span></span>
 

```json
{
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5ac81-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="5ac81-122">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5ac81-123">Parent</span><span class="sxs-lookup"><span data-stu-id="5ac81-123">Parent</span></span> 

[<span data-ttu-id="5ac81-124">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="5ac81-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   