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
ms.sourcegitcommit: c8f6866100a4b38fdda8394ea185b02d7af66411
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/13/2018
ms.locfileid: "3958673"
---
# <a name="gameclipthumbnail-json"></a><span data-ttu-id="c86af-104">GameClipThumbnail (JSON)</span><span class="sxs-lookup"><span data-stu-id="c86af-104">GameClipThumbnail (JSON)</span></span>
<span data-ttu-id="c86af-105">個々 のサムネイルに関連する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="c86af-105">Contains the information related to an individual thumbnail.</span></span> <span data-ttu-id="c86af-106">1 つのクリップを複数のサイズが存在することができ、表示用の適切なものを選択するクライアントがします。</span><span class="sxs-lookup"><span data-stu-id="c86af-106">There can be multiple sizes per clip, and it is up to the client to select the proper one for display.</span></span> 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a><span data-ttu-id="c86af-107">GameClipThumbnail</span><span class="sxs-lookup"><span data-stu-id="c86af-107">GameClipThumbnail</span></span>
 
<span data-ttu-id="c86af-108">GameClipThumbnail オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c86af-108">The GameClipThumbnail object has the following specification.</span></span>
 
| <span data-ttu-id="c86af-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="c86af-109">Member</span></span>| <span data-ttu-id="c86af-110">種類</span><span class="sxs-lookup"><span data-stu-id="c86af-110">Type</span></span>| <span data-ttu-id="c86af-111">説明</span><span class="sxs-lookup"><span data-stu-id="c86af-111">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="c86af-112">uri</span><span class="sxs-lookup"><span data-stu-id="c86af-112">uri</span></span></b>| <span data-ttu-id="c86af-113">string</span><span class="sxs-lookup"><span data-stu-id="c86af-113">string</span></span>| <span data-ttu-id="c86af-114">サムネイル画像の URI です。</span><span class="sxs-lookup"><span data-stu-id="c86af-114">The URI for the thumbnail image.</span></span>| 
| <b><span data-ttu-id="c86af-115">fileSize</span><span class="sxs-lookup"><span data-stu-id="c86af-115">fileSize</span></span></b>| <span data-ttu-id="c86af-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="c86af-116">32-bit unsigned integer</span></span>| <span data-ttu-id="c86af-117">サムネイル画像のファイルの合計サイズ。</span><span class="sxs-lookup"><span data-stu-id="c86af-117">The total file size of the thumbnail image.</span></span>| 
| <b><span data-ttu-id="c86af-118">thumbnailType</span><span class="sxs-lookup"><span data-stu-id="c86af-118">thumbnailType</span></span></b>| <span data-ttu-id="c86af-119">ThumbnailType</span><span class="sxs-lookup"><span data-stu-id="c86af-119">ThumbnailType</span></span>| <span data-ttu-id="c86af-120">サムネイル画像の種類です。</span><span class="sxs-lookup"><span data-stu-id="c86af-120">The type of thumbnail image.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="c86af-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="c86af-121">Sample JSON syntax</span></span>
 

```json
{
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="c86af-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="c86af-122">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c86af-123">Parent</span><span class="sxs-lookup"><span data-stu-id="c86af-123">Parent</span></span> 

[<span data-ttu-id="c86af-124">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c86af-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   