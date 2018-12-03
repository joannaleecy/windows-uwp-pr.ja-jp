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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8327059"
---
# <a name="usersettings-json"></a><span data-ttu-id="96534-104">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="96534-104">UserSettings (JSON)</span></span>
<span data-ttu-id="96534-105">現在の認証されたユーザーの設定を返します。</span><span class="sxs-lookup"><span data-stu-id="96534-105">Returns settings for current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usersettings"></a><span data-ttu-id="96534-106">UserSettings</span><span class="sxs-lookup"><span data-stu-id="96534-106">UserSettings</span></span>
 
<span data-ttu-id="96534-107">UserSettings オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="96534-107">The UserSettings object has the following specification.</span></span>
 
| <span data-ttu-id="96534-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="96534-108">Member</span></span>| <span data-ttu-id="96534-109">種類</span><span class="sxs-lookup"><span data-stu-id="96534-109">Type</span></span>| <span data-ttu-id="96534-110">説明</span><span class="sxs-lookup"><span data-stu-id="96534-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="96534-111">id</span><span class="sxs-lookup"><span data-stu-id="96534-111">id</span></span>| <span data-ttu-id="96534-112">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="96534-112">32-bit unsigned integer</span></span>| <span data-ttu-id="96534-113">設定の識別子です。</span><span class="sxs-lookup"><span data-stu-id="96534-113">The identifier of the setting.</span></span>| 
| <span data-ttu-id="96534-114">ソース</span><span class="sxs-lookup"><span data-stu-id="96534-114">source</span></span>| <span data-ttu-id="96534-115">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="96534-115">32-bit unsigned integer</span></span>| <span data-ttu-id="96534-116">設定のソースを表します。</span><span class="sxs-lookup"><span data-stu-id="96534-116">Represents the source of the setting.</span></span> | 
| <span data-ttu-id="96534-117">titleId</span><span class="sxs-lookup"><span data-stu-id="96534-117">titleId</span></span>| <span data-ttu-id="96534-118">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="96534-118">32-bit unsigned integer</span></span>| <span data-ttu-id="96534-119">設定に関連付けられているタイトルの識別子。</span><span class="sxs-lookup"><span data-stu-id="96534-119">The identifier of the title associated with the setting.</span></span> | 
| <span data-ttu-id="96534-120">value</span><span class="sxs-lookup"><span data-stu-id="96534-120">value</span></span>| <span data-ttu-id="96534-121">8 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="96534-121">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="96534-122">設定の値を表します。</span><span class="sxs-lookup"><span data-stu-id="96534-122">Represents the value of the setting.</span></span> <span data-ttu-id="96534-123">クライアント設定を取得してデータを読み取ることができるため表現の書式設定する必要がありますについて説明します。</span><span class="sxs-lookup"><span data-stu-id="96534-123">Clients retrieving settings must understand the representation format to be able to read the data.</span></span> | 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="96534-124">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="96534-124">Sample JSON syntax</span></span>
 

```json
{
   "id":268697600,
   "source":1,
   "titleId":1297287259,
   "value":"CAAAAA=="
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a><span data-ttu-id="96534-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="96534-125">See also</span></span>
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a><span data-ttu-id="96534-126">Parent</span><span class="sxs-lookup"><span data-stu-id="96534-126">Parent</span></span> 

[<span data-ttu-id="96534-127">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="96534-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   