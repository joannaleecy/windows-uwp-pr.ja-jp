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
ms.sourcegitcommit: 72710baeee8c898b5ab77ceb66d884eaa9db4cb8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3881737"
---
# <a name="xuidlist-json"></a><span data-ttu-id="12262-104">XuidList (JSON)</span><span class="sxs-lookup"><span data-stu-id="12262-104">XuidList (JSON)</span></span>
<span data-ttu-id="12262-105">操作を実行するに Xuid のリスト。</span><span class="sxs-lookup"><span data-stu-id="12262-105">List of XUIDs on which to perform an operation.</span></span> 
<a id="ID4EN"></a>

 
## <a name="xuidlist"></a><span data-ttu-id="12262-106">XuidList</span><span class="sxs-lookup"><span data-stu-id="12262-106">XuidList</span></span>
 
<span data-ttu-id="12262-107">XuidList オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="12262-107">The XuidList object has the following specification.</span></span>
 
| <span data-ttu-id="12262-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="12262-108">Member</span></span>| <span data-ttu-id="12262-109">種類</span><span class="sxs-lookup"><span data-stu-id="12262-109">Type</span></span>| <span data-ttu-id="12262-110">説明</span><span class="sxs-lookup"><span data-stu-id="12262-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="12262-111">xuid</span><span class="sxs-lookup"><span data-stu-id="12262-111">xuids</span></span>| <span data-ttu-id="12262-112">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="12262-112">array of string</span></span>| <span data-ttu-id="12262-113">操作を実行する必要がありますまたは返されるデータの Xbox ユーザー ID (XUID) 値の一覧。</span><span class="sxs-lookup"><span data-stu-id="12262-113">List of Xbox User ID (XUID) values on which an operation should be performed or data should be returned.</span></span>| 
  
<a id="ID4EMB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="12262-114">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="12262-114">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="12262-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="12262-115">See also</span></span>
 
<a id="ID4EXB"></a>

 
##### <a name="parent"></a><span data-ttu-id="12262-116">Parent</span><span class="sxs-lookup"><span data-stu-id="12262-116">Parent</span></span> 

[<span data-ttu-id="12262-117">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="12262-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EBC"></a>

 
##### <a name="reference"></a><span data-ttu-id="12262-118">リファレンス</span><span class="sxs-lookup"><span data-stu-id="12262-118">Reference</span></span> 

[<span data-ttu-id="12262-119">POST (/users/{ownerId}/ユーザー/xuid)</span><span class="sxs-lookup"><span data-stu-id="12262-119">POST (/users/{ownerId}/people/xuids)</span></span>](../uri/people/uri-usersowneridpeoplexuidspost.md)

   