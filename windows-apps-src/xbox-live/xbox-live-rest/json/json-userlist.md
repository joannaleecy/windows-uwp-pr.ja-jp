---
title: UserList (JSON)
assetID: 894f5a39-4eed-0c5b-fc45-cb0097dc46fd
permalink: en-us/docs/xboxlive/rest/json-userlist.html
description: " UserList (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 46e5323f4eae8e91b61295c4112b5bacfc8a1759
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8322425"
---
# <a name="userlist-json"></a><span data-ttu-id="233d3-104">UserList (JSON)</span><span class="sxs-lookup"><span data-stu-id="233d3-104">UserList (JSON)</span></span>
<span data-ttu-id="233d3-105">[ユーザー](json-user.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="233d3-105">A collection of [User](json-user.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="userlist"></a><span data-ttu-id="233d3-106">UserList</span><span class="sxs-lookup"><span data-stu-id="233d3-106">UserList</span></span>
 
<span data-ttu-id="233d3-107">UserList オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="233d3-107">The UserList object has the following specification.</span></span>
 
| <span data-ttu-id="233d3-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="233d3-108">Member</span></span>| <span data-ttu-id="233d3-109">種類</span><span class="sxs-lookup"><span data-stu-id="233d3-109">Type</span></span>| <span data-ttu-id="233d3-110">説明</span><span class="sxs-lookup"><span data-stu-id="233d3-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="233d3-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="233d3-111">users</span></span>| <span data-ttu-id="233d3-112">[ユーザー (JSON)](json-user.md)の配列</span><span class="sxs-lookup"><span data-stu-id="233d3-112">Array of [User (JSON)](json-user.md)</span></span>| <span data-ttu-id="233d3-113">次の JSON 例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="233d3-113">See JSON example below.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="233d3-114">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="233d3-114">Sample JSON syntax</span></span>
 

```json
{
    "users":
    [
        { "xuid":"12345" },
        { "xuid":"23456" }
    ] 
}
    
```

  
<a id="ID4EYB"></a>

 
## <a name="see-also"></a><span data-ttu-id="233d3-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="233d3-115">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="233d3-116">Parent</span><span class="sxs-lookup"><span data-stu-id="233d3-116">Parent</span></span> 

[<span data-ttu-id="233d3-117">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="233d3-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   