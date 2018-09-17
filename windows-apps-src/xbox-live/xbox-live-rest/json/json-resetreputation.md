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
ms.sourcegitcommit: 9e2c34a5ed3134aeca7eb9490f05b20eb9a3e5df
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/17/2018
ms.locfileid: "3983270"
---
# <a name="resetreputation-json"></a><span data-ttu-id="bc600-104">ResetReputation (JSON)</span><span class="sxs-lookup"><span data-stu-id="bc600-104">ResetReputation (JSON)</span></span>
<span data-ttu-id="bc600-105">ユーザーの既存のスコアを変更する必要があります新しい基本評判スコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="bc600-105">Contains the new base Reputation scores to which a user's existing scores should be changed.</span></span> 
<a id="ID4EN"></a>

 
## <a name="resetreputation"></a><span data-ttu-id="bc600-106">ResetReputation</span><span class="sxs-lookup"><span data-stu-id="bc600-106">ResetReputation</span></span>
 
<span data-ttu-id="bc600-107">ResetReputation オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="bc600-107">The ResetReputation object has the following specification.</span></span>
 
| <span data-ttu-id="bc600-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="bc600-108">Member</span></span>| <span data-ttu-id="bc600-109">種類</span><span class="sxs-lookup"><span data-stu-id="bc600-109">Type</span></span>| <span data-ttu-id="bc600-110">説明</span><span class="sxs-lookup"><span data-stu-id="bc600-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="bc600-111">fairplayReputation</span><span class="sxs-lookup"><span data-stu-id="bc600-111">fairplayReputation</span></span>| <span data-ttu-id="bc600-112">number</span><span class="sxs-lookup"><span data-stu-id="bc600-112">number</span></span>| <span data-ttu-id="bc600-113">必要な基本フェアプレイ評判スコアのユーザー (有効な範囲 0 ~ 75)。</span><span class="sxs-lookup"><span data-stu-id="bc600-113">The desired new base Fairplay Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="bc600-114">commsReputation</span><span class="sxs-lookup"><span data-stu-id="bc600-114">commsReputation</span></span>| <span data-ttu-id="bc600-115">number</span><span class="sxs-lookup"><span data-stu-id="bc600-115">number</span></span>| <span data-ttu-id="bc600-116">目的の基本 (有効な範囲 0 ~ 75) のユーザーの通信の評判スコア。</span><span class="sxs-lookup"><span data-stu-id="bc600-116">The desired new base Comms Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="bc600-117">userContentReputation</span><span class="sxs-lookup"><span data-stu-id="bc600-117">userContentReputation</span></span>| <span data-ttu-id="bc600-118">number</span><span class="sxs-lookup"><span data-stu-id="bc600-118">number</span></span>| <span data-ttu-id="bc600-119">必要な基本 UserContent 評判スコアのユーザー (有効な範囲 0 ~ 75)。</span><span class="sxs-lookup"><span data-stu-id="bc600-119">The desired new base UserContent Reputation score for the user (valid range 0 to 75).</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="bc600-120">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="bc600-120">Sample JSON syntax</span></span>
 

```json
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="bc600-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="bc600-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="bc600-122">Parent</span><span class="sxs-lookup"><span data-stu-id="bc600-122">Parent</span></span> 

[<span data-ttu-id="bc600-123">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="bc600-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   