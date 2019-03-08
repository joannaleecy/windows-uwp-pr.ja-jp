---
title: ResetReputation (JSON)
assetID: 15edb5e7-a00b-4188-9b49-9db5774c4a10
permalink: en-us/docs/xboxlive/rest/json-resetreputation.html
description: " ResetReputation (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d09c8bbc1130f91dfea3d4c35e391dcf9adcf127
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57649417"
---
# <a name="resetreputation-json"></a><span data-ttu-id="9c07e-104">ResetReputation (JSON)</span><span class="sxs-lookup"><span data-stu-id="9c07e-104">ResetReputation (JSON)</span></span>
<span data-ttu-id="9c07e-105">ユーザーの既存のスコアを変更する必要があります新しい基本評価スコアが含まれています。</span><span class="sxs-lookup"><span data-stu-id="9c07e-105">Contains the new base Reputation scores to which a user's existing scores should be changed.</span></span> 
<a id="ID4EN"></a>

 
## <a name="resetreputation"></a><span data-ttu-id="9c07e-106">ResetReputation</span><span class="sxs-lookup"><span data-stu-id="9c07e-106">ResetReputation</span></span>
 
<span data-ttu-id="9c07e-107">ResetReputation オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9c07e-107">The ResetReputation object has the following specification.</span></span>
 
| <span data-ttu-id="9c07e-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="9c07e-108">Member</span></span>| <span data-ttu-id="9c07e-109">種類</span><span class="sxs-lookup"><span data-stu-id="9c07e-109">Type</span></span>| <span data-ttu-id="9c07e-110">説明</span><span class="sxs-lookup"><span data-stu-id="9c07e-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9c07e-111">fairplayReputation</span><span class="sxs-lookup"><span data-stu-id="9c07e-111">fairplayReputation</span></span>| <span data-ttu-id="9c07e-112">number</span><span class="sxs-lookup"><span data-stu-id="9c07e-112">number</span></span>| <span data-ttu-id="9c07e-113">必要な基本ユーザー (有効な範囲 0 ~ 75) の Fairplay 評価スコア。</span><span class="sxs-lookup"><span data-stu-id="9c07e-113">The desired new base Fairplay Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="9c07e-114">commsReputation</span><span class="sxs-lookup"><span data-stu-id="9c07e-114">commsReputation</span></span>| <span data-ttu-id="9c07e-115">number</span><span class="sxs-lookup"><span data-stu-id="9c07e-115">number</span></span>| <span data-ttu-id="9c07e-116">必要な基本ユーザー (有効な範囲 0 ~ 75) の通信の評価スコア。</span><span class="sxs-lookup"><span data-stu-id="9c07e-116">The desired new base Comms Reputation score for the user (valid range 0 to 75).</span></span>| 
| <span data-ttu-id="9c07e-117">userContentReputation</span><span class="sxs-lookup"><span data-stu-id="9c07e-117">userContentReputation</span></span>| <span data-ttu-id="9c07e-118">number</span><span class="sxs-lookup"><span data-stu-id="9c07e-118">number</span></span>| <span data-ttu-id="9c07e-119">必要な基本のユーザー (有効な範囲 0 ~ 75) UserContent 評価スコア。</span><span class="sxs-lookup"><span data-stu-id="9c07e-119">The desired new base UserContent Reputation score for the user (valid range 0 to 75).</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="9c07e-120">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="9c07e-120">Sample JSON syntax</span></span>
 

```json
{
    "fairplayReputation": 75,
    "commsReputation": 75,
    "userContentReputation": 75
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9c07e-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="9c07e-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9c07e-122">Parent</span><span class="sxs-lookup"><span data-stu-id="9c07e-122">Parent</span></span> 

[<span data-ttu-id="9c07e-123">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="9c07e-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   