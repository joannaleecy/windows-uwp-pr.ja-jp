---
title: GameClipUri (JSON)
assetID: 03c097e8-7f29-1026-7a77-5c785b8511e9
permalink: en-us/docs/xboxlive/rest/json-gameclipuri.html
author: KevinAsgari
description: " GameClipUri (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d9c5f2e4aa27f86069578211c5c3188b2921449a
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5431159"
---
# <a name="gameclipuri-json"></a><span data-ttu-id="d09ff-104">GameClipUri (JSON)</span><span class="sxs-lookup"><span data-stu-id="d09ff-104">GameClipUri (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="gameclipuri"></a><span data-ttu-id="d09ff-105">GameClipUri</span><span class="sxs-lookup"><span data-stu-id="d09ff-105">GameClipUri</span></span>
 
<span data-ttu-id="d09ff-106">GameClipUri オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d09ff-106">The GameClipUri object has the following specification.</span></span>
 
| <span data-ttu-id="d09ff-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="d09ff-107">Member</span></span>| <span data-ttu-id="d09ff-108">種類</span><span class="sxs-lookup"><span data-stu-id="d09ff-108">Type</span></span>| <span data-ttu-id="d09ff-109">説明</span><span class="sxs-lookup"><span data-stu-id="d09ff-109">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="d09ff-110">uri</span><span class="sxs-lookup"><span data-stu-id="d09ff-110">uri</span></span></b>| <span data-ttu-id="d09ff-111">string</span><span class="sxs-lookup"><span data-stu-id="d09ff-111">string</span></span>| <span data-ttu-id="d09ff-112">ビデオのアセットの場所への URI。</span><span class="sxs-lookup"><span data-stu-id="d09ff-112">The URI to the location of the video asset.</span></span>| 
| <b><span data-ttu-id="d09ff-113">fileSize</span><span class="sxs-lookup"><span data-stu-id="d09ff-113">fileSize</span></span></b>| <span data-ttu-id="d09ff-114">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d09ff-114">32-bit unsigned integer</span></span>| <span data-ttu-id="d09ff-115">サムネイル画像の合計ファイル サイズ。</span><span class="sxs-lookup"><span data-stu-id="d09ff-115">The total file size of the thumbnail image.</span></span>| 
| <b><span data-ttu-id="d09ff-116">uriType</span><span class="sxs-lookup"><span data-stu-id="d09ff-116">uriType</span></span></b>| <span data-ttu-id="d09ff-117">GameClipUriType</span><span class="sxs-lookup"><span data-stu-id="d09ff-117">GameClipUriType</span></span>| <span data-ttu-id="d09ff-118">URI の種類です。</span><span class="sxs-lookup"><span data-stu-id="d09ff-118">The type of the URI.</span></span>| 
| <b><span data-ttu-id="d09ff-119">有効期限</span><span class="sxs-lookup"><span data-stu-id="d09ff-119">expiration</span></span></b>| <span data-ttu-id="d09ff-120">DateTime</span><span class="sxs-lookup"><span data-stu-id="d09ff-120">DateTime</span></span>| <span data-ttu-id="d09ff-121">この応答に含まれている URI の有効期限の時刻。</span><span class="sxs-lookup"><span data-stu-id="d09ff-121">The expiration time of the URI that is included in this response.</span></span> <span data-ttu-id="d09ff-122">URL の場合は、空のまたは再生する前に有効期限切れと見なされ、呼び出し元は RefreshUrl API を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d09ff-122">If the URL is empty or deemed expired before playback, callers should call the RefreshUrl API.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="d09ff-123">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="d09ff-123">Sample JSON syntax</span></span>
 

```json
{
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234565,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       }
    
```

  
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="d09ff-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="d09ff-124">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="d09ff-125">Parent</span><span class="sxs-lookup"><span data-stu-id="d09ff-125">Parent</span></span> 

[<span data-ttu-id="d09ff-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="d09ff-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   