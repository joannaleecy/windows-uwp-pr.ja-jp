---
title: XuidList (JSON)
assetID: 06938a52-e582-a15b-ec7f-4b053dfc28ad
permalink: en-us/docs/xboxlive/rest/json-xuidlist.html
description: " XuidList (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1d8172063d40f8df77827ab845c4dfd0c0799811
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57627917"
---
# <a name="xuidlist-json"></a><span data-ttu-id="faf81-104">XuidList (JSON)</span><span class="sxs-lookup"><span data-stu-id="faf81-104">XuidList (JSON)</span></span>
<span data-ttu-id="faf81-105">操作を実行する Xuid の一覧です。</span><span class="sxs-lookup"><span data-stu-id="faf81-105">List of XUIDs on which to perform an operation.</span></span> 
<a id="ID4EN"></a>

 
## <a name="xuidlist"></a><span data-ttu-id="faf81-106">XuidList</span><span class="sxs-lookup"><span data-stu-id="faf81-106">XuidList</span></span>
 
<span data-ttu-id="faf81-107">XuidList オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="faf81-107">The XuidList object has the following specification.</span></span>
 
| <span data-ttu-id="faf81-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="faf81-108">Member</span></span>| <span data-ttu-id="faf81-109">種類</span><span class="sxs-lookup"><span data-stu-id="faf81-109">Type</span></span>| <span data-ttu-id="faf81-110">説明</span><span class="sxs-lookup"><span data-stu-id="faf81-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="faf81-111">xuid</span><span class="sxs-lookup"><span data-stu-id="faf81-111">xuids</span></span>| <span data-ttu-id="faf81-112">文字列の配列</span><span class="sxs-lookup"><span data-stu-id="faf81-112">array of string</span></span>| <span data-ttu-id="faf81-113">操作を実行する必要がありますまたはデータを返す必要がある Xbox ユーザー ID (XUID) 値のリスト。</span><span class="sxs-lookup"><span data-stu-id="faf81-113">List of Xbox User ID (XUID) values on which an operation should be performed or data should be returned.</span></span>| 
  
<a id="ID4EMB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="faf81-114">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="faf81-114">Sample JSON syntax</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="faf81-115">関連項目</span><span class="sxs-lookup"><span data-stu-id="faf81-115">See also</span></span>
 
<a id="ID4EXB"></a>

 
##### <a name="parent"></a><span data-ttu-id="faf81-116">Parent</span><span class="sxs-lookup"><span data-stu-id="faf81-116">Parent</span></span> 

[<span data-ttu-id="faf81-117">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="faf81-117">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EBC"></a>

 
##### <a name="reference"></a><span data-ttu-id="faf81-118">リファレンス</span><span class="sxs-lookup"><span data-stu-id="faf81-118">Reference</span></span> 

[<span data-ttu-id="faf81-119">POST (/users/{ownerId}/people/xuids)</span><span class="sxs-lookup"><span data-stu-id="faf81-119">POST (/users/{ownerId}/people/xuids)</span></span>](../uri/people/uri-usersowneridpeoplexuidspost.md)

   