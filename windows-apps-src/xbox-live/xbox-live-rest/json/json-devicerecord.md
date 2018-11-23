---
title: DeviceRecord (JSON)
assetID: aca4f4d3-f9b4-8919-5b6d-5ae0fe11e162
permalink: en-us/docs/xboxlive/rest/json-devicerecord.html
author: KevinAsgari
description: " DeviceRecord (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: ecfaf3ff6ee83c2d577614dc613939669ef60d62
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7555286"
---
# <a name="devicerecord-json"></a><span data-ttu-id="82c78-104">DeviceRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="82c78-104">DeviceRecord (JSON)</span></span>
<span data-ttu-id="82c78-105">、その種類とそれに対するアクティブなタイトルなど、デバイスに関する情報。</span><span class="sxs-lookup"><span data-stu-id="82c78-105">Information about a device, including its type and the titles active on it.</span></span> 
<a id="ID4EN"></a>

 
## <a name="devicerecord"></a><span data-ttu-id="82c78-106">DeviceRecord</span><span class="sxs-lookup"><span data-stu-id="82c78-106">DeviceRecord</span></span>
 
<span data-ttu-id="82c78-107">DeviceRecord オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="82c78-107">The DeviceRecord object has the following specification.</span></span>
 
| <span data-ttu-id="82c78-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="82c78-108">Member</span></span>| <span data-ttu-id="82c78-109">種類</span><span class="sxs-lookup"><span data-stu-id="82c78-109">Type</span></span>| <span data-ttu-id="82c78-110">説明</span><span class="sxs-lookup"><span data-stu-id="82c78-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="82c78-111">type</span><span class="sxs-lookup"><span data-stu-id="82c78-111">type</span></span>| <span data-ttu-id="82c78-112">文字列</span><span class="sxs-lookup"><span data-stu-id="82c78-112">string</span></span>| <span data-ttu-id="82c78-113">デバイスのデバイスの種類。</span><span class="sxs-lookup"><span data-stu-id="82c78-113">The device type of the device.</span></span> <span data-ttu-id="82c78-114">"D"、"Xbox360"、"MoLIVE"(Windows)、"WindowsPhone"、"WindowsPhone7"、"PC"(G4WL) の組み合わせが含まれます。</span><span class="sxs-lookup"><span data-stu-id="82c78-114">Possibilities include "D", "Xbox360", "MoLIVE" (Windows), "WindowsPhone", "WindowsPhone7", and "PC" (G4WL).</span></span> <span data-ttu-id="82c78-115">型が (例 iOS、Android、または web ブラウザーに埋め込まれているタイトル) の既知の場合は、"Web"が返されます。</span><span class="sxs-lookup"><span data-stu-id="82c78-115">If the type is unknown (for example iOS, Android, or a title embedded in a web browser), "Web" is returned .</span></span>| 
| <span data-ttu-id="82c78-116">タイトル</span><span class="sxs-lookup"><span data-stu-id="82c78-116">titles</span></span>| <span data-ttu-id="82c78-117">[TitleRecord](json-titlerecord.md)の配列</span><span class="sxs-lookup"><span data-stu-id="82c78-117">array of [TitleRecord](json-titlerecord.md)</span></span>| <span data-ttu-id="82c78-118">このデバイス上でアクティブなタイトルの一覧。</span><span class="sxs-lookup"><span data-stu-id="82c78-118">The list of titles active on this device.</span></span>| 
  
<a id="ID4EWB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="82c78-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="82c78-119">Sample JSON syntax</span></span>
 

```json
[{
    type:"D",
    titles:
    [{
      id:"12341234",
      name:"Contoso 5",
      state:"active",
      placement:"fill",
      timestamp:"2012-09-17T07:15:23.4930000",
      activity:
      {
        richPresence:"Team Deathmatch on Nirvana"
      }
    },
    {
      id:"12341235",
      name:"Contoso Waypoint",
      timestamp:"2012-09-17T07:15:23.4930000",
      placement:"snapped",
      state:"active",
      activity:
      {
        richPresence:"Using radar"
      }
    }]
  }]
    
```

  
<a id="ID4E6B"></a>

 
## <a name="see-also"></a><span data-ttu-id="82c78-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="82c78-120">See also</span></span>
 
<a id="ID4EBC"></a>

 
##### <a name="parent"></a><span data-ttu-id="82c78-121">Parent</span><span class="sxs-lookup"><span data-stu-id="82c78-121">Parent</span></span> 

[<span data-ttu-id="82c78-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="82c78-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4ENC"></a>

 
##### <a name="reference"></a><span data-ttu-id="82c78-123">リファレンス</span><span class="sxs-lookup"><span data-stu-id="82c78-123">Reference</span></span>   