---
title: ActivityRecord (JSON)
assetID: e3a7465b-3451-0266-f8ba-b7602b59f7af
permalink: en-us/docs/xboxlive/rest/json-activityrecord.html
description: " ActivityRecord (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: a8679c96c86754a8b929b44b5bd4eb402d851e90
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8752750"
---
# <a name="activityrecord-json"></a><span data-ttu-id="7c2ae-104">ActivityRecord (JSON)</span><span class="sxs-lookup"><span data-stu-id="7c2ae-104">ActivityRecord (JSON)</span></span>
<span data-ttu-id="7c2ae-105">1 つまたは複数のユーザーのリッチ プレゼンスの書式設定されたとローカライズされた文字列です。</span><span class="sxs-lookup"><span data-stu-id="7c2ae-105">A formatted and localized string about one or more users' rich presence.</span></span> 
<a id="ID4EN"></a>

 
## <a name="activityrecord"></a><span data-ttu-id="7c2ae-106">ActivityRecord</span><span class="sxs-lookup"><span data-stu-id="7c2ae-106">ActivityRecord</span></span>
 
<span data-ttu-id="7c2ae-107">ActivityRecord オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7c2ae-107">The ActivityRecord object has the following specification.</span></span>
 
| <span data-ttu-id="7c2ae-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="7c2ae-108">Member</span></span>| <span data-ttu-id="7c2ae-109">種類</span><span class="sxs-lookup"><span data-stu-id="7c2ae-109">Type</span></span>| <span data-ttu-id="7c2ae-110">説明</span><span class="sxs-lookup"><span data-stu-id="7c2ae-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7c2ae-111">richPresence</span><span class="sxs-lookup"><span data-stu-id="7c2ae-111">richPresence</span></span>| <span data-ttu-id="7c2ae-112">string</span><span class="sxs-lookup"><span data-stu-id="7c2ae-112">string</span></span>| <span data-ttu-id="7c2ae-113">フォーマットされ、ローカライズされたリッチ プレゼンス文字列。</span><span class="sxs-lookup"><span data-stu-id="7c2ae-113">The rich presence string, formatted and localized.</span></span>| 
| <span data-ttu-id="7c2ae-114">メディア</span><span class="sxs-lookup"><span data-stu-id="7c2ae-114">media</span></span>| <span data-ttu-id="7c2ae-115">MediaRecord</span><span class="sxs-lookup"><span data-stu-id="7c2ae-115">MediaRecord</span></span>| <span data-ttu-id="7c2ae-116">ユーザーの視聴やをリッスンしています。</span><span class="sxs-lookup"><span data-stu-id="7c2ae-116">What the user is watching or listening to.</span></span>| 
  
<a id="ID4ETB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="7c2ae-117">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="7c2ae-117">Sample JSON syntax</span></span>
 

```json
{
        richPresence:"Team Deathmatch on Nirvana"
      }
    
```

  
<a id="ID4E3B"></a>

 
## <a name="see-also"></a><span data-ttu-id="7c2ae-118">関連項目</span><span class="sxs-lookup"><span data-stu-id="7c2ae-118">See also</span></span>
 
<a id="ID4E5B"></a>

 
##### <a name="parent"></a><span data-ttu-id="7c2ae-119">Parent</span><span class="sxs-lookup"><span data-stu-id="7c2ae-119">Parent</span></span> 

[<span data-ttu-id="7c2ae-120">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="7c2ae-120">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   