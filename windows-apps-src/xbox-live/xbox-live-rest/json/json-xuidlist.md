---
title: XuidList (JSON)
assetID: 06938a52-e582-a15b-ec7f-4b053dfc28ad
permalink: en-us/docs/xboxlive/rest/json-xuidlist.html
author: KevinAsgari
description: " XuidList (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 3853140ce5e7c3f7710f489709945fc70b6703b4
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4125038"
---
# <a name="xuidlist-json"></a><span data-ttu-id="08ff8-104">XuidList (JSON)</span><span class="sxs-lookup"><span data-stu-id="08ff8-104">XuidList (JSON)</span></span>
<span data-ttu-id="08ff8-105">操作を実行する Xuid のリスト。</span><span class="sxs-lookup"><span data-stu-id="08ff8-105">List of XUIDs on which to perform an operation.</span></span> 
<a id="ID4EN"></a>

 
## <a name="xuidlist"></a><span data-ttu-id="08ff8-106">XuidList</span><span class="sxs-lookup"><span data-stu-id="08ff8-106">XuidList</span></span>
 
<span data-ttu-id="08ff8-107">XuidList オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="08ff8-107">The XuidList object has the following specification.</span></span>
 
| <span data-ttu-id="08ff8-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="08ff8-108">Member</span></span>| <span data-ttu-id="08ff8-109">種類</span><span class="sxs-lookup"><span data-stu-id="08ff8-109">Type</span></span>| <span data-ttu-id="08ff8-110">説明</span><span class="sxs-lookup"><span data-stu-id="08ff8-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="08ff8-111">xuid</span><span class="sxs-lookup"><span data-stu-id="08ff8-111">xuids</span></span>| <span data-ttu-id="08ff8-112">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="08ff8-112">array of string</span></span>| <span data-ttu-id="08ff8-113">操作を実行する必要がありますまたは返されるデータの Xbox ユーザー ID (XUID) 値の一覧です。</span><span class="sxs-lookup"><span data-stu-id="08ff8-113">List of Xbox User ID (XUID) values on which an operation should be performed or data should be returned.</span></span>| 
  
<a id="ID4EMB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="08ff8-114">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="08ff8-114">Sample JSON syntax</span></span>
 

```json
{
    "xuids": [
        "2533274790395904", 
        "2533274792986770", 
        "2533274794866999"
    ]
}
    
```

  
<a id="ID4EVB"></a>

 
## <a name="see-also"></a><span data-ttu-id="08ff8-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="08ff8-115">See also</span></span>
 
<a id="ID4EXB"></a>

 
##### <a name="parent"></a><span data-ttu-id="08ff8-116">Parent</span><span class="sxs-lookup"><span data-stu-id="08ff8-116">Parent</span></span> 

[<span data-ttu-id="08ff8-117">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="08ff8-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EBC"></a>

 
##### <a name="reference"></a><span data-ttu-id="08ff8-118">リファレンス</span><span class="sxs-lookup"><span data-stu-id="08ff8-118">Reference</span></span> 

[<span data-ttu-id="08ff8-119">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="08ff8-119">POST (/users/{ownerId}/people/xuids)</span></span>](../uri/people/uri-usersowneridpeoplexuidspost.md)

   