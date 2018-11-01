---
title: UserSettings (JSON)
assetID: 17c030cb-05e0-f78e-5ab1-cdbd8b801ceb
permalink: en-us/docs/xboxlive/rest/json-usersettings.html
author: KevinAsgari
description: " UserSettings (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 67b9edcb4ffd4c0da6929de8dfd47652cf7ab375
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5876643"
---
# <a name="usersettings-json"></a><span data-ttu-id="85c27-104">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="85c27-104">UserSettings (JSON)</span></span>
<span data-ttu-id="85c27-105">現在の認証されたユーザーの設定を返します。</span><span class="sxs-lookup"><span data-stu-id="85c27-105">Returns settings for current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usersettings"></a><span data-ttu-id="85c27-106">UserSettings</span><span class="sxs-lookup"><span data-stu-id="85c27-106">UserSettings</span></span>
 
<span data-ttu-id="85c27-107">UserSettings オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="85c27-107">The UserSettings object has the following specification.</span></span>
 
| <span data-ttu-id="85c27-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="85c27-108">Member</span></span>| <span data-ttu-id="85c27-109">種類</span><span class="sxs-lookup"><span data-stu-id="85c27-109">Type</span></span>| <span data-ttu-id="85c27-110">説明</span><span class="sxs-lookup"><span data-stu-id="85c27-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="85c27-111">id</span><span class="sxs-lookup"><span data-stu-id="85c27-111">id</span></span>| <span data-ttu-id="85c27-112">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="85c27-112">32-bit unsigned integer</span></span>| <span data-ttu-id="85c27-113">設定の識別子です。</span><span class="sxs-lookup"><span data-stu-id="85c27-113">The identifier of the setting.</span></span>| 
| <span data-ttu-id="85c27-114">ソース</span><span class="sxs-lookup"><span data-stu-id="85c27-114">source</span></span>| <span data-ttu-id="85c27-115">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="85c27-115">32-bit unsigned integer</span></span>| <span data-ttu-id="85c27-116">設定のソースを表します。</span><span class="sxs-lookup"><span data-stu-id="85c27-116">Represents the source of the setting.</span></span> | 
| <span data-ttu-id="85c27-117">titleId</span><span class="sxs-lookup"><span data-stu-id="85c27-117">titleId</span></span>| <span data-ttu-id="85c27-118">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="85c27-118">32-bit unsigned integer</span></span>| <span data-ttu-id="85c27-119">設定に関連付けられているタイトルの識別子。</span><span class="sxs-lookup"><span data-stu-id="85c27-119">The identifier of the title associated with the setting.</span></span> | 
| <span data-ttu-id="85c27-120">value</span><span class="sxs-lookup"><span data-stu-id="85c27-120">value</span></span>| <span data-ttu-id="85c27-121">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="85c27-121">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="85c27-122">設定の値を表します。</span><span class="sxs-lookup"><span data-stu-id="85c27-122">Represents the value of the setting.</span></span> <span data-ttu-id="85c27-123">クライアント設定を取得して、データを読み取ることができるため表現の書式設定する必要がありますについて説明します。</span><span class="sxs-lookup"><span data-stu-id="85c27-123">Clients retrieving settings must understand the representation format to be able to read the data.</span></span> | 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="85c27-124">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="85c27-124">Sample JSON syntax</span></span>
 

```json
{
   "id":268697600,
   "source":1,
   "titleId":1297287259,
   "value":"CAAAAA=="
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a><span data-ttu-id="85c27-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="85c27-125">See also</span></span>
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a><span data-ttu-id="85c27-126">Parent</span><span class="sxs-lookup"><span data-stu-id="85c27-126">Parent</span></span> 

[<span data-ttu-id="85c27-127">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="85c27-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   