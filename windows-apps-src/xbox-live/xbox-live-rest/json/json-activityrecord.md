---
title: ActivityRecord (JSON)
assetID: e3a7465b-3451-0266-f8ba-b7602b59f7af
permalink: en-us/docs/xboxlive/rest/json-activityrecord.html
author: KevinAsgari
description: " ActivityRecord (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 0eb34d64daa9b1349c4f956a59ccf5d8efa5b565
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4497886"
---
# <a name="activityrecord-json"></a><span data-ttu-id="7aeb7-104">ActivityRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="7aeb7-104">ActivityRecord (JSON)</span></span>
<span data-ttu-id="7aeb7-105">1 つまたは複数のユーザーのリッチ プレゼンスの書式設定されたとローカライズされた文字列です。</span><span class="sxs-lookup"><span data-stu-id="7aeb7-105">A formatted and localized string about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrecord"></a><span data-ttu-id="7aeb7-106">ActivityRecord</span><span class="sxs-lookup"><span data-stu-id="7aeb7-106">ActivityRecord</span></span>
 
<span data-ttu-id="7aeb7-107">ActivityRecord オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7aeb7-107">The ActivityRecord object has the following specification.</span></span>
 
| <span data-ttu-id="7aeb7-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="7aeb7-108">Member</span></span>| <span data-ttu-id="7aeb7-109">種類</span><span class="sxs-lookup"><span data-stu-id="7aeb7-109">Type</span></span>| <span data-ttu-id="7aeb7-110">説明</span><span class="sxs-lookup"><span data-stu-id="7aeb7-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7aeb7-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="7aeb7-111">richPresence</span></span>| <span data-ttu-id="7aeb7-112">string</span><span class="sxs-lookup"><span data-stu-id="7aeb7-112">string</span></span>| <span data-ttu-id="7aeb7-113">フォーマットされて、ローカライズされたリッチ プレゼンス文字列。</span><span class="sxs-lookup"><span data-stu-id="7aeb7-113">The rich presence string, formatted and localized.</span></span>| 
| <span data-ttu-id="7aeb7-114">メディア</span><span class="sxs-lookup"><span data-stu-id="7aeb7-114">media</span></span>| <span data-ttu-id="7aeb7-115">MediaRecord</span><span class="sxs-lookup"><span data-stu-id="7aeb7-115">MediaRecord</span></span>| <span data-ttu-id="7aeb7-116">ユーザーの視聴やをリッスンしています。</span><span class="sxs-lookup"><span data-stu-id="7aeb7-116">What the user is watching or listening to.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="7aeb7-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="7aeb7-117">Sample JSON syntax</span></span>
 

```json
{
        richPresence:"Team Deathmatch on Nirvana"
      }
    
```

  
<a id="ID4E3B"></a>

 
## <a name="see-also"></a><span data-ttu-id="7aeb7-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="7aeb7-118">See also</span></span>
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a><span data-ttu-id="7aeb7-119">Parent</span><span class="sxs-lookup"><span data-stu-id="7aeb7-119">Parent</span></span> 

[<span data-ttu-id="7aeb7-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="7aeb7-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   