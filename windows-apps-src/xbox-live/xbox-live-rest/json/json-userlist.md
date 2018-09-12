---
title: UserList (JSON)
assetID: 894f5a39-4eed-0c5b-fc45-cb0097dc46fd
permalink: en-us/docs/xboxlive/rest/json-userlist.html
author: KevinAsgari
description: " UserList (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 51dd19ebed394bb0c3c8b5f4649dd5c83a58027c
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3934376"
---
# <a name="userlist-json"></a><span data-ttu-id="7823c-104">UserList (JSON)</span><span class="sxs-lookup"><span data-stu-id="7823c-104">UserList (JSON)</span></span>
<span data-ttu-id="7823c-105">[ユーザー](json-user.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="7823c-105">A collection of [User](json-user.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="userlist"></a><span data-ttu-id="7823c-106">UserList</span><span class="sxs-lookup"><span data-stu-id="7823c-106">UserList</span></span>
 
<span data-ttu-id="7823c-107">UserList オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7823c-107">The UserList object has the following specification.</span></span>
 
| <span data-ttu-id="7823c-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="7823c-108">Member</span></span>| <span data-ttu-id="7823c-109">種類</span><span class="sxs-lookup"><span data-stu-id="7823c-109">Type</span></span>| <span data-ttu-id="7823c-110">説明</span><span class="sxs-lookup"><span data-stu-id="7823c-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7823c-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="7823c-111">users</span></span>| <span data-ttu-id="7823c-112">[ユーザー (JSON)](json-user.md)の配列</span><span class="sxs-lookup"><span data-stu-id="7823c-112">Array of [User (JSON)](json-user.md)</span></span>| <span data-ttu-id="7823c-113">次の JSON 例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="7823c-113">See JSON example below.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="7823c-114">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="7823c-114">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="7823c-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="7823c-115">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="7823c-116">Parent</span><span class="sxs-lookup"><span data-stu-id="7823c-116">Parent</span></span> 

[<span data-ttu-id="7823c-117">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="7823c-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   