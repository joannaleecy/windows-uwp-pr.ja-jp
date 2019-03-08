---
title: RichPresenceRequest (JSON)
assetID: 599266be-f747-0be1-fadf-f8e0262dc27f
permalink: en-us/docs/xboxlive/rest/json-richpresencerequest.html
description: " RichPresenceRequest (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4c49da63ecd091a886a68f508af09e33fb9c58ac
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654127"
---
# <a name="richpresencerequest-json"></a><span data-ttu-id="306cf-104">RichPresenceRequest (JSON)</span><span class="sxs-lookup"><span data-stu-id="306cf-104">RichPresenceRequest (JSON)</span></span>
<span data-ttu-id="306cf-105">豊富なプレゼンス情報の使用についての情報を要求します。</span><span class="sxs-lookup"><span data-stu-id="306cf-105">Request for information about which rich presence information should be used.</span></span> 
<a id="ID4EN"></a>

 
## <a name="richpresencerequest"></a><span data-ttu-id="306cf-106">RichPresenceRequest</span><span class="sxs-lookup"><span data-stu-id="306cf-106">RichPresenceRequest</span></span>
 
<span data-ttu-id="306cf-107">RichPresenceRequest オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="306cf-107">The RichPresenceRequest object has the following specification.</span></span>
 
| <span data-ttu-id="306cf-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="306cf-108">Member</span></span>| <span data-ttu-id="306cf-109">種類</span><span class="sxs-lookup"><span data-stu-id="306cf-109">Type</span></span>| <span data-ttu-id="306cf-110">説明</span><span class="sxs-lookup"><span data-stu-id="306cf-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="306cf-111">id</span><span class="sxs-lookup"><span data-stu-id="306cf-111">id</span></span>| <span data-ttu-id="306cf-112">string</span><span class="sxs-lookup"><span data-stu-id="306cf-112">string</span></span>| <span data-ttu-id="306cf-113"><b>FriendlyName</b>プレゼンスの文字列を使用するのです。</span><span class="sxs-lookup"><span data-stu-id="306cf-113">The <b>friendlyName</b> of the rich presence string to use.</span></span>| 
| <span data-ttu-id="306cf-114">scid</span><span class="sxs-lookup"><span data-stu-id="306cf-114">scid</span></span>| <span data-ttu-id="306cf-115">string</span><span class="sxs-lookup"><span data-stu-id="306cf-115">string</span></span>| <span data-ttu-id="306cf-116">プレゼンスの文字列が定義されていることを指示する Scid します。</span><span class="sxs-lookup"><span data-stu-id="306cf-116">Scid that tells us where the rich presence strings are defined.</span></span>| 
| <span data-ttu-id="306cf-117">params</span><span class="sxs-lookup"><span data-stu-id="306cf-117">params</span></span>| <span data-ttu-id="306cf-118">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="306cf-118">array of string</span></span>| <span data-ttu-id="306cf-119">配列<b>friendlyName</b>プレゼンス文字列を終了する文字列します。</span><span class="sxs-lookup"><span data-stu-id="306cf-119">Array of <b>friendlyName</b> strings with which to finish the rich presence string.</span></span> <span data-ttu-id="306cf-120">列挙型の表示名のみを指定する必要があります、統計ではありません。この空のまま、以前の値が削除されます。</span><span class="sxs-lookup"><span data-stu-id="306cf-120">Only enumeration-friendly names should be specified, not stats. Leaving this empty will remove any previous value.</span></span>| 
  
<a id="ID4EDC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="306cf-121">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="306cf-121">Sample JSON syntax</span></span>
 

```json
{
      id:"playingMapWeapon",
      scid:"abba0123-08ba-48ca-9f1a-21627b189b0f",
    }
    
```

  
<a id="ID4EMC"></a>

 
## <a name="see-also"></a><span data-ttu-id="306cf-122">関連項目</span><span class="sxs-lookup"><span data-stu-id="306cf-122">See also</span></span>
 
<a id="ID4EOC"></a>

 
##### <a name="parent"></a><span data-ttu-id="306cf-123">Parent</span><span class="sxs-lookup"><span data-stu-id="306cf-123">Parent</span></span> 

[<span data-ttu-id="306cf-124">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="306cf-124">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   