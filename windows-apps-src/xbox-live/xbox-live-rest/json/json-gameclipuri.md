---
title: GameClipUri (JSON)
assetID: 03c097e8-7f29-1026-7a77-5c785b8511e9
permalink: en-us/docs/xboxlive/rest/json-gameclipuri.html
author: KevinAsgari
description: " GameClipUri (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: db92c3e405029d76264b0e1e9b159ae2650d6650
ms.sourcegitcommit: f2c9a050a9137a473f28b613968d5782866142c6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/10/2018
ms.locfileid: "6248912"
---
# <a name="gameclipuri-json"></a><span data-ttu-id="bdb25-104">GameClipUri (JSON)</span><span class="sxs-lookup"><span data-stu-id="bdb25-104">GameClipUri (JSON)</span></span>
 
<a id="ID4EO"></a>

 
## <a name="gameclipuri"></a><span data-ttu-id="bdb25-105">GameClipUri</span><span class="sxs-lookup"><span data-stu-id="bdb25-105">GameClipUri</span></span>
 
<span data-ttu-id="bdb25-106">GameClipUri オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="bdb25-106">The GameClipUri object has the following specification.</span></span>
 
| <span data-ttu-id="bdb25-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="bdb25-107">Member</span></span>| <span data-ttu-id="bdb25-108">種類</span><span class="sxs-lookup"><span data-stu-id="bdb25-108">Type</span></span>| <span data-ttu-id="bdb25-109">説明</span><span class="sxs-lookup"><span data-stu-id="bdb25-109">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="bdb25-110">uri</span><span class="sxs-lookup"><span data-stu-id="bdb25-110">uri</span></span></b>| <span data-ttu-id="bdb25-111">string</span><span class="sxs-lookup"><span data-stu-id="bdb25-111">string</span></span>| <span data-ttu-id="bdb25-112">ビデオのアセットの場所への URI。</span><span class="sxs-lookup"><span data-stu-id="bdb25-112">The URI to the location of the video asset.</span></span>| 
| <b><span data-ttu-id="bdb25-113">fileSize</span><span class="sxs-lookup"><span data-stu-id="bdb25-113">fileSize</span></span></b>| <span data-ttu-id="bdb25-114">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="bdb25-114">32-bit unsigned integer</span></span>| <span data-ttu-id="bdb25-115">サムネイル画像の合計ファイル サイズ。</span><span class="sxs-lookup"><span data-stu-id="bdb25-115">The total file size of the thumbnail image.</span></span>| 
| <b><span data-ttu-id="bdb25-116">uriType</span><span class="sxs-lookup"><span data-stu-id="bdb25-116">uriType</span></span></b>| <span data-ttu-id="bdb25-117">GameClipUriType</span><span class="sxs-lookup"><span data-stu-id="bdb25-117">GameClipUriType</span></span>| <span data-ttu-id="bdb25-118">URI の種類です。</span><span class="sxs-lookup"><span data-stu-id="bdb25-118">The type of the URI.</span></span>| 
| <b><span data-ttu-id="bdb25-119">有効期限</span><span class="sxs-lookup"><span data-stu-id="bdb25-119">expiration</span></span></b>| <span data-ttu-id="bdb25-120">DateTime</span><span class="sxs-lookup"><span data-stu-id="bdb25-120">DateTime</span></span>| <span data-ttu-id="bdb25-121">この応答に含まれている URI の有効期限の時刻。</span><span class="sxs-lookup"><span data-stu-id="bdb25-121">The expiration time of the URI that is included in this response.</span></span> <span data-ttu-id="bdb25-122">URL の場合は、空のまたは再生する前に有効期限切れと見なされ、呼び出し元は RefreshUrl API を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="bdb25-122">If the URL is empty or deemed expired before playback, callers should call the RefreshUrl API.</span></span>| 
  
<a id="ID4EMC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="bdb25-123">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="bdb25-123">Sample JSON syntax</span></span>
 

```json
{
         "uri": "http://gameclips.xbox.com/clips/7ce5c1a7-1255-46d3-a90e-34a0e2dfab06/clip.mp4",
         "fileSize": 1234565,
         "uriType": "Download",
         "expiration": "9999-12-31T23:59:59.9999999"
       }
    
```

  
<a id="ID4EVC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bdb25-124">関連項目</span><span class="sxs-lookup"><span data-stu-id="bdb25-124">See also</span></span>
 
<a id="ID4EXC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bdb25-125">Parent</span><span class="sxs-lookup"><span data-stu-id="bdb25-125">Parent</span></span> 

[<span data-ttu-id="bdb25-126">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="bdb25-126">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   