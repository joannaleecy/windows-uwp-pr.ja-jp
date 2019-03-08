---
title: GameClipThumbnail (JSON)
assetID: 3ed87fc1-734c-d8b5-d908-0ae3359769ed
permalink: en-us/docs/xboxlive/rest/json-gameclipthumbnail.html
description: " GameClipThumbnail (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ad2d35431cb4c40690978f4f3920f2e47f2b9bc0
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57606567"
---
# <a name="gameclipthumbnail-json"></a><span data-ttu-id="998e2-104">GameClipThumbnail (JSON)</span><span class="sxs-lookup"><span data-stu-id="998e2-104">GameClipThumbnail (JSON)</span></span>
<span data-ttu-id="998e2-105">個々 のサムネイルに関連する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="998e2-105">Contains the information related to an individual thumbnail.</span></span> <span data-ttu-id="998e2-106">1 つのクリップ、複数のサイズがあり、表示するための適切な 1 つを選択するクライアントの責任です。</span><span class="sxs-lookup"><span data-stu-id="998e2-106">There can be multiple sizes per clip, and it is up to the client to select the proper one for display.</span></span> 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a><span data-ttu-id="998e2-107">GameClipThumbnail</span><span class="sxs-lookup"><span data-stu-id="998e2-107">GameClipThumbnail</span></span>
 
<span data-ttu-id="998e2-108">GameClipThumbnail オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="998e2-108">The GameClipThumbnail object has the following specification.</span></span>
 
| <span data-ttu-id="998e2-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="998e2-109">Member</span></span>| <span data-ttu-id="998e2-110">種類</span><span class="sxs-lookup"><span data-stu-id="998e2-110">Type</span></span>| <span data-ttu-id="998e2-111">説明</span><span class="sxs-lookup"><span data-stu-id="998e2-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="998e2-112"><b>Uri</b></span><span class="sxs-lookup"><span data-stu-id="998e2-112"><b>uri</b></span></span>| <span data-ttu-id="998e2-113">string</span><span class="sxs-lookup"><span data-stu-id="998e2-113">string</span></span>| <span data-ttu-id="998e2-114">サムネイル イメージの URI。</span><span class="sxs-lookup"><span data-stu-id="998e2-114">The URI for the thumbnail image.</span></span>| 
| <span data-ttu-id="998e2-115"><b>fileSize</b></span><span class="sxs-lookup"><span data-stu-id="998e2-115"><b>fileSize</b></span></span>| <span data-ttu-id="998e2-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="998e2-116">32-bit unsigned integer</span></span>| <span data-ttu-id="998e2-117">サムネイル イメージのファイルの合計サイズ。</span><span class="sxs-lookup"><span data-stu-id="998e2-117">The total file size of the thumbnail image.</span></span>| 
| <span data-ttu-id="998e2-118"><b>thumbnailType</b></span><span class="sxs-lookup"><span data-stu-id="998e2-118"><b>thumbnailType</b></span></span>| <span data-ttu-id="998e2-119">ThumbnailType</span><span class="sxs-lookup"><span data-stu-id="998e2-119">ThumbnailType</span></span>| <span data-ttu-id="998e2-120">サムネイル イメージの種類。</span><span class="sxs-lookup"><span data-stu-id="998e2-120">The type of thumbnail image.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="998e2-121">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="998e2-121">Sample JSON syntax</span></span>
 

```json
{
         "uri": "https://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="998e2-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="998e2-122">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="998e2-123">Parent</span><span class="sxs-lookup"><span data-stu-id="998e2-123">Parent</span></span> 

[<span data-ttu-id="998e2-124">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="998e2-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   