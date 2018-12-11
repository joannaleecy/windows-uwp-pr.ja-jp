---
title: UserSettings (JSON)
assetID: 17c030cb-05e0-f78e-5ab1-cdbd8b801ceb
permalink: en-us/docs/xboxlive/rest/json-usersettings.html
description: " UserSettings (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5451c59ab608105677a657ade41154bd2b622f5e
ms.sourcegitcommit: 8921a9cc0dd3e5665345ae8eca7ab7aeb83ccc6f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8887383"
---
# <a name="usersettings-json"></a><span data-ttu-id="92148-104">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="92148-104">UserSettings (JSON)</span></span>
<span data-ttu-id="92148-105">現在の認証されたユーザーの設定を返します。</span><span class="sxs-lookup"><span data-stu-id="92148-105">Returns settings for current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usersettings"></a><span data-ttu-id="92148-106">UserSettings</span><span class="sxs-lookup"><span data-stu-id="92148-106">UserSettings</span></span>
 
<span data-ttu-id="92148-107">UserSettings オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="92148-107">The UserSettings object has the following specification.</span></span>
 
| <span data-ttu-id="92148-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="92148-108">Member</span></span>| <span data-ttu-id="92148-109">種類</span><span class="sxs-lookup"><span data-stu-id="92148-109">Type</span></span>| <span data-ttu-id="92148-110">説明</span><span class="sxs-lookup"><span data-stu-id="92148-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="92148-111">id</span><span class="sxs-lookup"><span data-stu-id="92148-111">id</span></span>| <span data-ttu-id="92148-112">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="92148-112">32-bit unsigned integer</span></span>| <span data-ttu-id="92148-113">設定の識別子です。</span><span class="sxs-lookup"><span data-stu-id="92148-113">The identifier of the setting.</span></span>| 
| <span data-ttu-id="92148-114">ソース</span><span class="sxs-lookup"><span data-stu-id="92148-114">source</span></span>| <span data-ttu-id="92148-115">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="92148-115">32-bit unsigned integer</span></span>| <span data-ttu-id="92148-116">設定のソースを表します。</span><span class="sxs-lookup"><span data-stu-id="92148-116">Represents the source of the setting.</span></span> | 
| <span data-ttu-id="92148-117">titleId</span><span class="sxs-lookup"><span data-stu-id="92148-117">titleId</span></span>| <span data-ttu-id="92148-118">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="92148-118">32-bit unsigned integer</span></span>| <span data-ttu-id="92148-119">設定に関連付けられているタイトルの識別子です。</span><span class="sxs-lookup"><span data-stu-id="92148-119">The identifier of the title associated with the setting.</span></span> | 
| <span data-ttu-id="92148-120">value</span><span class="sxs-lookup"><span data-stu-id="92148-120">value</span></span>| <span data-ttu-id="92148-121">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="92148-121">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="92148-122">設定の値を表します。</span><span class="sxs-lookup"><span data-stu-id="92148-122">Represents the value of the setting.</span></span> <span data-ttu-id="92148-123">クライアント設定を取得してデータを読み取ることができるため表現の書式設定する必要がありますについて説明します。</span><span class="sxs-lookup"><span data-stu-id="92148-123">Clients retrieving settings must understand the representation format to be able to read the data.</span></span> | 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="92148-124">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="92148-124">Sample JSON syntax</span></span>
 

```json
{
   "id":268697600,
   "source":1,
   "titleId":1297287259,
   "value":"CAAAAA=="
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a><span data-ttu-id="92148-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="92148-125">See also</span></span>
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a><span data-ttu-id="92148-126">Parent</span><span class="sxs-lookup"><span data-stu-id="92148-126">Parent</span></span> 

[<span data-ttu-id="92148-127">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="92148-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   