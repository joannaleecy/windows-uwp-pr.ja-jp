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
ms.sourcegitcommit: d10fb9eb5f75f2d10e1c543a177402b50fe4019e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/12/2018
ms.locfileid: "4568480"
---
# <a name="userlist-json"></a><span data-ttu-id="f1ab4-104">UserList (JSON)</span><span class="sxs-lookup"><span data-stu-id="f1ab4-104">UserList (JSON)</span></span>
<span data-ttu-id="f1ab4-105">[ユーザー](json-user.md)オブジェクトのコレクションです。</span><span class="sxs-lookup"><span data-stu-id="f1ab4-105">A collection of [User](json-user.md) objects.</span></span> 
<a id="ID4ER"></a>

 
## <a name="userlist"></a><span data-ttu-id="f1ab4-106">UserList</span><span class="sxs-lookup"><span data-stu-id="f1ab4-106">UserList</span></span>
 
<span data-ttu-id="f1ab4-107">UserList オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f1ab4-107">The UserList object has the following specification.</span></span>
 
| <span data-ttu-id="f1ab4-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="f1ab4-108">Member</span></span>| <span data-ttu-id="f1ab4-109">種類</span><span class="sxs-lookup"><span data-stu-id="f1ab4-109">Type</span></span>| <span data-ttu-id="f1ab4-110">説明</span><span class="sxs-lookup"><span data-stu-id="f1ab4-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f1ab4-111">ユーザー</span><span class="sxs-lookup"><span data-stu-id="f1ab4-111">users</span></span>| <span data-ttu-id="f1ab4-112">[ユーザー (JSON)](json-user.md)の配列</span><span class="sxs-lookup"><span data-stu-id="f1ab4-112">Array of [User (JSON)](json-user.md)</span></span>| <span data-ttu-id="f1ab4-113">次の JSON 例を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f1ab4-113">See JSON example below.</span></span>| 
  
<a id="ID4EPB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="f1ab4-114">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="f1ab4-114">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="f1ab4-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="f1ab4-115">See also</span></span>
 
<a id="ID4E1B"></a>

 
##### <a name="parent"></a><span data-ttu-id="f1ab4-116">Parent</span><span class="sxs-lookup"><span data-stu-id="f1ab4-116">Parent</span></span> 

[<span data-ttu-id="f1ab4-117">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f1ab4-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   