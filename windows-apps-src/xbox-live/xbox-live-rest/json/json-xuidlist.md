---
title: XuidList (JSON)
assetID: 06938a52-e582-a15b-ec7f-4b053dfc28ad
permalink: en-us/docs/xboxlive/rest/json-xuidlist.html
author: KevinAsgari
description: " XuidList (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 990357eef8ef0ea8ec43822090a5133a10f8ec6c
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7162274"
---
# <a name="xuidlist-json"></a><span data-ttu-id="1138b-104">XuidList (JSON)</span><span class="sxs-lookup"><span data-stu-id="1138b-104">XuidList (JSON)</span></span>
<span data-ttu-id="1138b-105">操作を実行するに Xuid のリスト。</span><span class="sxs-lookup"><span data-stu-id="1138b-105">List of XUIDs on which to perform an operation.</span></span> 
<a id="ID4EN"></a>

 
## <a name="xuidlist"></a><span data-ttu-id="1138b-106">XuidList</span><span class="sxs-lookup"><span data-stu-id="1138b-106">XuidList</span></span>
 
<span data-ttu-id="1138b-107">XuidList オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="1138b-107">The XuidList object has the following specification.</span></span>
 
| <span data-ttu-id="1138b-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="1138b-108">Member</span></span>| <span data-ttu-id="1138b-109">種類</span><span class="sxs-lookup"><span data-stu-id="1138b-109">Type</span></span>| <span data-ttu-id="1138b-110">説明</span><span class="sxs-lookup"><span data-stu-id="1138b-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="1138b-111">xuid</span><span class="sxs-lookup"><span data-stu-id="1138b-111">xuids</span></span>| <span data-ttu-id="1138b-112">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="1138b-112">array of string</span></span>| <span data-ttu-id="1138b-113">操作を実行する必要がありますまたは返されるデータの Xbox ユーザー ID (XUID) 値の一覧。</span><span class="sxs-lookup"><span data-stu-id="1138b-113">List of Xbox User ID (XUID) values on which an operation should be performed or data should be returned.</span></span>| 
  
<a id="ID4EMB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="1138b-114">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="1138b-114">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="1138b-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="1138b-115">See also</span></span>
 
<a id="ID4EXB"></a>

 
##### <a name="parent"></a><span data-ttu-id="1138b-116">Parent</span><span class="sxs-lookup"><span data-stu-id="1138b-116">Parent</span></span> 

[<span data-ttu-id="1138b-117">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="1138b-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EBC"></a>

 
##### <a name="reference"></a><span data-ttu-id="1138b-118">リファレンス</span><span class="sxs-lookup"><span data-stu-id="1138b-118">Reference</span></span> 

[<span data-ttu-id="1138b-119">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="1138b-119">POST (/users/{ownerId}/people/xuids)</span></span>](../uri/people/uri-usersowneridpeoplexuidspost.md)

   