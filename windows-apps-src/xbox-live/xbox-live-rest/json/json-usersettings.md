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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57655047"
---
# <a name="usersettings-json"></a><span data-ttu-id="9d077-104">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="9d077-104">UserSettings (JSON)</span></span>
<span data-ttu-id="9d077-105">現在の認証済みユーザーの設定を返します。</span><span class="sxs-lookup"><span data-stu-id="9d077-105">Returns settings for current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usersettings"></a><span data-ttu-id="9d077-106">UserSettings</span><span class="sxs-lookup"><span data-stu-id="9d077-106">UserSettings</span></span>
 
<span data-ttu-id="9d077-107">UserSettings オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9d077-107">The UserSettings object has the following specification.</span></span>
 
| <span data-ttu-id="9d077-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="9d077-108">Member</span></span>| <span data-ttu-id="9d077-109">種類</span><span class="sxs-lookup"><span data-stu-id="9d077-109">Type</span></span>| <span data-ttu-id="9d077-110">説明</span><span class="sxs-lookup"><span data-stu-id="9d077-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9d077-111">id</span><span class="sxs-lookup"><span data-stu-id="9d077-111">id</span></span>| <span data-ttu-id="9d077-112">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9d077-112">32-bit unsigned integer</span></span>| <span data-ttu-id="9d077-113">設定の識別子です。</span><span class="sxs-lookup"><span data-stu-id="9d077-113">The identifier of the setting.</span></span>| 
| <span data-ttu-id="9d077-114">ソース</span><span class="sxs-lookup"><span data-stu-id="9d077-114">source</span></span>| <span data-ttu-id="9d077-115">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9d077-115">32-bit unsigned integer</span></span>| <span data-ttu-id="9d077-116">設定のソースを表します。</span><span class="sxs-lookup"><span data-stu-id="9d077-116">Represents the source of the setting.</span></span> | 
| <span data-ttu-id="9d077-117">titleId</span><span class="sxs-lookup"><span data-stu-id="9d077-117">titleId</span></span>| <span data-ttu-id="9d077-118">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="9d077-118">32-bit unsigned integer</span></span>| <span data-ttu-id="9d077-119">設定に関連付けられているタイトルの識別子。</span><span class="sxs-lookup"><span data-stu-id="9d077-119">The identifier of the title associated with the setting.</span></span> | 
| <span data-ttu-id="9d077-120">value</span><span class="sxs-lookup"><span data-stu-id="9d077-120">value</span></span>| <span data-ttu-id="9d077-121">8 ビット符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="9d077-121">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="9d077-122">設定の値を表します。</span><span class="sxs-lookup"><span data-stu-id="9d077-122">Represents the value of the setting.</span></span> <span data-ttu-id="9d077-123">クライアント設定を取得するには、データを読み取ることができる表現形式を理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9d077-123">Clients retrieving settings must understand the representation format to be able to read the data.</span></span> | 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="9d077-124">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="9d077-124">Sample JSON syntax</span></span>
 

```json
{
   "id":268697600,
   "source":1,
   "titleId":1297287259,
   "value":"CAAAAA=="
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9d077-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="9d077-125">See also</span></span>
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9d077-126">Parent</span><span class="sxs-lookup"><span data-stu-id="9d077-126">Parent</span></span> 

[<span data-ttu-id="9d077-127">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="9d077-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   