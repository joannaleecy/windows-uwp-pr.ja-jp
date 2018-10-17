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
ms.sourcegitcommit: 1c6325aa572868b789fcdd2efc9203f67a83872a
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/17/2018
ms.locfileid: "4743811"
---
# <a name="resetreputation-json"></a><span data-ttu-id="5ed74-104">ResetReputation (JSON)</span><span class="sxs-lookup"><span data-stu-id="5ed74-104">ResetReputation (JSON)</span></span>
<span data-ttu-id="5ed74-105">ユーザーの既存のスコアを変更する必要があります新しい基本評判スコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="5ed74-105">Contains the new base Reputation scores to which a user's existing scores should be changed.</span></span> 
<a id="ID4EN"></a>

 
## <a name="resetreputation"></a><span data-ttu-id="5ed74-106">ResetReputation</span><span class="sxs-lookup"><span data-stu-id="5ed74-106">ResetReputation</span></span>
 
<span data-ttu-id="5ed74-107">ResetReputation オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="5ed74-107">The ResetReputation object has the following specification.</span></span>
 
| <span data-ttu-id="5ed74-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="5ed74-108">Member</span></span>| <span data-ttu-id="5ed74-109">種類</span><span class="sxs-lookup"><span data-stu-id="5ed74-109">Type</span></span>| <span data-ttu-id="5ed74-110">説明</span><span class="sxs-lookup"><span data-stu-id="5ed74-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="5ed74-111">fairplayReputation</span><span class="sxs-lookup"><span data-stu-id="5ed74-111">fairplayReputation</span></span>| <span data-ttu-id="5ed74-112">number</span><span class="sxs-lookup"><span data-stu-id="5ed74-112">number</span></span>| <span data-ttu-id="5ed74-113">必要な基本フェアプレイ評判スコアのユーザー (有効な範囲 0 ~ 75)。</span><span class="sxs-lookup"><span data-stu-id="5ed74-113">The desired new base Fairplay Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="5ed74-114">commsReputation</span><span class="sxs-lookup"><span data-stu-id="5ed74-114">commsReputation</span></span>| <span data-ttu-id="5ed74-115">number</span><span class="sxs-lookup"><span data-stu-id="5ed74-115">number</span></span>| <span data-ttu-id="5ed74-116">目的の基本 (有効な範囲 0 ~ 75) のユーザーの通信の評判スコア。</span><span class="sxs-lookup"><span data-stu-id="5ed74-116">The desired new base Comms Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="5ed74-117">userContentReputation</span><span class="sxs-lookup"><span data-stu-id="5ed74-117">userContentReputation</span></span>| <span data-ttu-id="5ed74-118">number</span><span class="sxs-lookup"><span data-stu-id="5ed74-118">number</span></span>| <span data-ttu-id="5ed74-119">必要な基本 UserContent 評判スコアのユーザー (有効な範囲 0 ~ 75)。</span><span class="sxs-lookup"><span data-stu-id="5ed74-119">The desired new base UserContent Reputation score for the user (valid range 0 to 75).</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="5ed74-120">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="5ed74-120">Sample JSON syntax</span></span>
 

```json
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="5ed74-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="5ed74-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="5ed74-122">Parent</span><span class="sxs-lookup"><span data-stu-id="5ed74-122">Parent</span></span> 

[<span data-ttu-id="5ed74-123">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="5ed74-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   