---
title: GameClipThumbnail (JSON)
assetID: 3ed87fc1-734c-d8b5-d908-0ae3359769ed
permalink: en-us/docs/xboxlive/rest/json-gameclipthumbnail.html
description: " GameClipThumbnail (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a491b70b8e34c1c736667b50271af7b970b6bb2a
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8349851"
---
# <a name="gameclipthumbnail-json"></a><span data-ttu-id="4f334-104">GameClipThumbnail (JSON)</span><span class="sxs-lookup"><span data-stu-id="4f334-104">GameClipThumbnail (JSON)</span></span>
<span data-ttu-id="4f334-105">個々 のサムネイルに関連する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="4f334-105">Contains the information related to an individual thumbnail.</span></span> <span data-ttu-id="4f334-106">1 つのクリップを複数のサイズが存在することができ、クライアントを表示用の適切なものを選択することができます。</span><span class="sxs-lookup"><span data-stu-id="4f334-106">There can be multiple sizes per clip, and it is up to the client to select the proper one for display.</span></span> 
<a id="ID4EN"></a>

 
## <a name="gameclipthumbnail"></a><span data-ttu-id="4f334-107">GameClipThumbnail</span><span class="sxs-lookup"><span data-stu-id="4f334-107">GameClipThumbnail</span></span>
 
<span data-ttu-id="4f334-108">GameClipThumbnail オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="4f334-108">The GameClipThumbnail object has the following specification.</span></span>
 
| <span data-ttu-id="4f334-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="4f334-109">Member</span></span>| <span data-ttu-id="4f334-110">種類</span><span class="sxs-lookup"><span data-stu-id="4f334-110">Type</span></span>| <span data-ttu-id="4f334-111">説明</span><span class="sxs-lookup"><span data-stu-id="4f334-111">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="4f334-112">uri</span><span class="sxs-lookup"><span data-stu-id="4f334-112">uri</span></span></b>| <span data-ttu-id="4f334-113">string</span><span class="sxs-lookup"><span data-stu-id="4f334-113">string</span></span>| <span data-ttu-id="4f334-114">サムネイル画像の URI です。</span><span class="sxs-lookup"><span data-stu-id="4f334-114">The URI for the thumbnail image.</span></span>| 
| <b><span data-ttu-id="4f334-115">fileSize</span><span class="sxs-lookup"><span data-stu-id="4f334-115">fileSize</span></span></b>| <span data-ttu-id="4f334-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="4f334-116">32-bit unsigned integer</span></span>| <span data-ttu-id="4f334-117">サムネイル画像のファイルの合計サイズ。</span><span class="sxs-lookup"><span data-stu-id="4f334-117">The total file size of the thumbnail image.</span></span>| 
| <b><span data-ttu-id="4f334-118">thumbnailType</span><span class="sxs-lookup"><span data-stu-id="4f334-118">thumbnailType</span></span></b>| <span data-ttu-id="4f334-119">ThumbnailType</span><span class="sxs-lookup"><span data-stu-id="4f334-119">ThumbnailType</span></span>| <span data-ttu-id="4f334-120">サムネイル画像の種類です。</span><span class="sxs-lookup"><span data-stu-id="4f334-120">The type of thumbnail image.</span></span>| 
  
<a id="ID4EAC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="4f334-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="4f334-121">Sample JSON syntax</span></span>
 

```json
{
         "uri": "http://gameclips.xbox.com/thumbnails/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/small.jpg",
         "fileSize": 123,
         "width": 120,
         "height": 250
       }
    
```

  
<a id="ID4EJC"></a>

 
## <a name="see-also"></a><span data-ttu-id="4f334-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="4f334-122">See also</span></span>
 
<a id="ID4ELC"></a>

 
##### <a name="parent"></a><span data-ttu-id="4f334-123">Parent</span><span class="sxs-lookup"><span data-stu-id="4f334-123">Parent</span></span> 

[<span data-ttu-id="4f334-124">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="4f334-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   