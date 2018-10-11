---
title: ResetReputation (JSON)
assetID: 15edb5e7-a00b-4188-9b49-9db5774c4a10
permalink: en-us/docs/xboxlive/rest/json-resetreputation.html
author: KevinAsgari
description: " ResetReputation (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 494f4a8977a298265c264b050d6a222bd2bdd7d2
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4534038"
---
# <a name="resetreputation-json"></a><span data-ttu-id="27b16-104">ResetReputation (JSON)</span><span class="sxs-lookup"><span data-stu-id="27b16-104">ResetReputation (JSON)</span></span>
<span data-ttu-id="27b16-105">ユーザーの既存のスコアを変更する必要があります新しい基本評判スコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="27b16-105">Contains the new base Reputation scores to which a user's existing scores should be changed.</span></span> 
<a id="ID4EN"></a>

 
## <a name="resetreputation"></a><span data-ttu-id="27b16-106">ResetReputation</span><span class="sxs-lookup"><span data-stu-id="27b16-106">ResetReputation</span></span>
 
<span data-ttu-id="27b16-107">ResetReputation オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="27b16-107">The ResetReputation object has the following specification.</span></span>
 
| <span data-ttu-id="27b16-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="27b16-108">Member</span></span>| <span data-ttu-id="27b16-109">種類</span><span class="sxs-lookup"><span data-stu-id="27b16-109">Type</span></span>| <span data-ttu-id="27b16-110">説明</span><span class="sxs-lookup"><span data-stu-id="27b16-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="27b16-111">fairplayReputation</span><span class="sxs-lookup"><span data-stu-id="27b16-111">fairplayReputation</span></span>| <span data-ttu-id="27b16-112">number</span><span class="sxs-lookup"><span data-stu-id="27b16-112">number</span></span>| <span data-ttu-id="27b16-113">目的の基本 (有効な範囲 0 ~ 75) のユーザーのフェアプレイ評判スコア。</span><span class="sxs-lookup"><span data-stu-id="27b16-113">The desired new base Fairplay Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="27b16-114">commsReputation</span><span class="sxs-lookup"><span data-stu-id="27b16-114">commsReputation</span></span>| <span data-ttu-id="27b16-115">number</span><span class="sxs-lookup"><span data-stu-id="27b16-115">number</span></span>| <span data-ttu-id="27b16-116">目的の基本 (有効な範囲 0 ~ 75) のユーザーの通信の評判スコア。</span><span class="sxs-lookup"><span data-stu-id="27b16-116">The desired new base Comms Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="27b16-117">userContentReputation</span><span class="sxs-lookup"><span data-stu-id="27b16-117">userContentReputation</span></span>| <span data-ttu-id="27b16-118">number</span><span class="sxs-lookup"><span data-stu-id="27b16-118">number</span></span>| <span data-ttu-id="27b16-119">必要な基本 UserContent 評判スコアのユーザー (有効な範囲 0 ~ 75)。</span><span class="sxs-lookup"><span data-stu-id="27b16-119">The desired new base UserContent Reputation score for the user (valid range 0 to 75).</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="27b16-120">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="27b16-120">Sample JSON syntax</span></span>
 

```json
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="27b16-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="27b16-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="27b16-122">Parent</span><span class="sxs-lookup"><span data-stu-id="27b16-122">Parent</span></span> 

[<span data-ttu-id="27b16-123">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="27b16-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   