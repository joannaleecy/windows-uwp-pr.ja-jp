---
title: RichPresenceRequest (JSON)
assetID: 599266be-f747-0be1-fadf-f8e0262dc27f
permalink: en-us/docs/xboxlive/rest/json-richpresencerequest.html
author: KevinAsgari
description: " RichPresenceRequest (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 92e52e4ebb58abb3a522f81a5ae4cce6486785f0
ms.sourcegitcommit: 70ab58b88d248de2332096b20dbd6a4643d137a4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/02/2018
ms.locfileid: "5945048"
---
# <a name="richpresencerequest-json"></a><span data-ttu-id="ba5be-104">RichPresenceRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="ba5be-104">RichPresenceRequest (JSON)</span></span>
<span data-ttu-id="ba5be-105">リッチ プレゼンス情報の使用に関する情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="ba5be-105">Request for information about which rich presence information should be used.</span></span> 
<a id="ID4EN"></a>

 
## <a name="richpresencerequest"></a><span data-ttu-id="ba5be-106">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="ba5be-106">RichPresenceRequest</span></span>
 
<span data-ttu-id="ba5be-107">RichPresenceRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="ba5be-107">The RichPresenceRequest object has the following specification.</span></span>
 
| <span data-ttu-id="ba5be-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="ba5be-108">Member</span></span>| <span data-ttu-id="ba5be-109">種類</span><span class="sxs-lookup"><span data-stu-id="ba5be-109">Type</span></span>| <span data-ttu-id="ba5be-110">説明</span><span class="sxs-lookup"><span data-stu-id="ba5be-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ba5be-111">id</span><span class="sxs-lookup"><span data-stu-id="ba5be-111">id</span></span>| <span data-ttu-id="ba5be-112">string</span><span class="sxs-lookup"><span data-stu-id="ba5be-112">string</span></span>| <span data-ttu-id="ba5be-113">使用するリッチ プレゼンス文字列の<b>フレンドリ名</b>。</span><span class="sxs-lookup"><span data-stu-id="ba5be-113">The <b>friendlyName</b> of the rich presence string to use.</span></span>| 
| <span data-ttu-id="ba5be-114">scid</span><span class="sxs-lookup"><span data-stu-id="ba5be-114">scid</span></span>| <span data-ttu-id="ba5be-115">string</span><span class="sxs-lookup"><span data-stu-id="ba5be-115">string</span></span>| <span data-ttu-id="ba5be-116">リッチ プレゼンス文字列が定義されているを示す Scid です。</span><span class="sxs-lookup"><span data-stu-id="ba5be-116">Scid that tells us where the rich presence strings are defined.</span></span>| 
| <span data-ttu-id="ba5be-117">パラメーター</span><span class="sxs-lookup"><span data-stu-id="ba5be-117">params</span></span>| <span data-ttu-id="ba5be-118">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="ba5be-118">array of string</span></span>| <span data-ttu-id="ba5be-119">リッチ プレゼンス文字列を完了するための<b>フレンドリ名</b>の文字列の配列です。</span><span class="sxs-lookup"><span data-stu-id="ba5be-119">Array of <b>friendlyName</b> strings with which to finish the rich presence string.</span></span> <span data-ttu-id="ba5be-120">列挙フレンドリ名を指定する必要があります、統計ではありません。この空のまま、以前の値が削除されます。</span><span class="sxs-lookup"><span data-stu-id="ba5be-120">Only enumeration-friendly names should be specified, not stats. Leaving this empty will remove any previous value.</span></span>| 
  
<a id="ID4EDC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="ba5be-121">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="ba5be-121">Sample JSON syntax</span></span>
 

```json
{
      id:"playingMapWeapon",
      scid:"abba0123-08ba-48ca-9f1a-21627b189b0f",
    }
    
```

  
<a id="ID4EMC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ba5be-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="ba5be-122">See also</span></span>
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ba5be-123">Parent</span><span class="sxs-lookup"><span data-stu-id="ba5be-123">Parent</span></span> 

[<span data-ttu-id="ba5be-124">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="ba5be-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   