---
title: ActivityRecord (JSON)
assetID: e3a7465b-3451-0266-f8ba-b7602b59f7af
permalink: en-us/docs/xboxlive/rest/json-activityrecord.html
author: KevinAsgari
description: " ActivityRecord (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bb78941f2ab9cab4395dbb1ba5eb8fb3b09dee08
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7144030"
---
# <a name="activityrecord-json"></a><span data-ttu-id="363fd-104">ActivityRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="363fd-104">ActivityRecord (JSON)</span></span>
<span data-ttu-id="363fd-105">1 つまたは複数のユーザーのリッチ プレゼンスの形式とローカライズされた文字列です。</span><span class="sxs-lookup"><span data-stu-id="363fd-105">A formatted and localized string about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrecord"></a><span data-ttu-id="363fd-106">ActivityRecord</span><span class="sxs-lookup"><span data-stu-id="363fd-106">ActivityRecord</span></span>
 
<span data-ttu-id="363fd-107">ActivityRecord オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="363fd-107">The ActivityRecord object has the following specification.</span></span>
 
| <span data-ttu-id="363fd-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="363fd-108">Member</span></span>| <span data-ttu-id="363fd-109">種類</span><span class="sxs-lookup"><span data-stu-id="363fd-109">Type</span></span>| <span data-ttu-id="363fd-110">説明</span><span class="sxs-lookup"><span data-stu-id="363fd-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="363fd-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="363fd-111">richPresence</span></span>| <span data-ttu-id="363fd-112">string</span><span class="sxs-lookup"><span data-stu-id="363fd-112">string</span></span>| <span data-ttu-id="363fd-113">フォーマットし、ローカライズされたリッチ プレゼンス文字列。</span><span class="sxs-lookup"><span data-stu-id="363fd-113">The rich presence string, formatted and localized.</span></span>| 
| <span data-ttu-id="363fd-114">メディア</span><span class="sxs-lookup"><span data-stu-id="363fd-114">media</span></span>| <span data-ttu-id="363fd-115">MediaRecord</span><span class="sxs-lookup"><span data-stu-id="363fd-115">MediaRecord</span></span>| <span data-ttu-id="363fd-116">どのようなユーザーは視聴またはをリッスンしています。</span><span class="sxs-lookup"><span data-stu-id="363fd-116">What the user is watching or listening to.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="363fd-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="363fd-117">Sample JSON syntax</span></span>
 

```json
{
        richPresence:"Team Deathmatch on Nirvana"
      }
    
```

  
<a id="ID4E3B"></a>

 
## <a name="see-also"></a><span data-ttu-id="363fd-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="363fd-118">See also</span></span>
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a><span data-ttu-id="363fd-119">Parent</span><span class="sxs-lookup"><span data-stu-id="363fd-119">Parent</span></span> 

[<span data-ttu-id="363fd-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="363fd-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   