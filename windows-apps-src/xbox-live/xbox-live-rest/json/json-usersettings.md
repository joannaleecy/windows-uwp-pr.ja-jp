---
title: UserSettings (JSON)
assetID: 17c030cb-05e0-f78e-5ab1-cdbd8b801ceb
permalink: en-us/docs/xboxlive/rest/json-usersettings.html
author: KevinAsgari
description: " UserSettings (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 20ac62403a8248011928089ea81cdf6418259db1
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4087180"
---
# <a name="usersettings-json"></a><span data-ttu-id="f206e-104">UserSettings (JSON)</span><span class="sxs-lookup"><span data-stu-id="f206e-104">UserSettings (JSON)</span></span>
<span data-ttu-id="f206e-105">現在の認証されたユーザーの設定を返します。</span><span class="sxs-lookup"><span data-stu-id="f206e-105">Returns settings for current authenticated user.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usersettings"></a><span data-ttu-id="f206e-106">ユーザー</span><span class="sxs-lookup"><span data-stu-id="f206e-106">UserSettings</span></span>
 
<span data-ttu-id="f206e-107">ユーザー オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f206e-107">The UserSettings object has the following specification.</span></span>
 
| <span data-ttu-id="f206e-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="f206e-108">Member</span></span>| <span data-ttu-id="f206e-109">種類</span><span class="sxs-lookup"><span data-stu-id="f206e-109">Type</span></span>| <span data-ttu-id="f206e-110">説明</span><span class="sxs-lookup"><span data-stu-id="f206e-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f206e-111">id</span><span class="sxs-lookup"><span data-stu-id="f206e-111">id</span></span>| <span data-ttu-id="f206e-112">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f206e-112">32-bit unsigned integer</span></span>| <span data-ttu-id="f206e-113">設定の識別子です。</span><span class="sxs-lookup"><span data-stu-id="f206e-113">The identifier of the setting.</span></span>| 
| <span data-ttu-id="f206e-114">ソース</span><span class="sxs-lookup"><span data-stu-id="f206e-114">source</span></span>| <span data-ttu-id="f206e-115">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f206e-115">32-bit unsigned integer</span></span>| <span data-ttu-id="f206e-116">設定のソースを表します。</span><span class="sxs-lookup"><span data-stu-id="f206e-116">Represents the source of the setting.</span></span> | 
| <span data-ttu-id="f206e-117">titleId</span><span class="sxs-lookup"><span data-stu-id="f206e-117">titleId</span></span>| <span data-ttu-id="f206e-118">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f206e-118">32-bit unsigned integer</span></span>| <span data-ttu-id="f206e-119">設定に関連付けられているタイトルの識別子です。</span><span class="sxs-lookup"><span data-stu-id="f206e-119">The identifier of the title associated with the setting.</span></span> | 
| <span data-ttu-id="f206e-120">value</span><span class="sxs-lookup"><span data-stu-id="f206e-120">value</span></span>| <span data-ttu-id="f206e-121">8 ビットの符号なし整数の配列</span><span class="sxs-lookup"><span data-stu-id="f206e-121">array of 8-bit unsigned integer</span></span>| <span data-ttu-id="f206e-122">設定の値を表します。</span><span class="sxs-lookup"><span data-stu-id="f206e-122">Represents the value of the setting.</span></span> <span data-ttu-id="f206e-123">クライアント設定を取得する表現形式のデータを読み取ることができるを理解する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f206e-123">Clients retrieving settings must understand the representation format to be able to read the data.</span></span> | 
  
<a id="ID4EJC"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="f206e-124">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="f206e-124">Sample JSON syntax</span></span>
 

```json
{
   "id":268697600,
   "source":1,
   "titleId":1297287259,
   "value":"CAAAAA=="
}
    
```

  
<a id="ID4ESC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f206e-125">関連項目</span><span class="sxs-lookup"><span data-stu-id="f206e-125">See also</span></span>
 
<a id="ID4EUC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f206e-126">Parent</span><span class="sxs-lookup"><span data-stu-id="f206e-126">Parent</span></span> 

[<span data-ttu-id="f206e-127">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f206e-127">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   