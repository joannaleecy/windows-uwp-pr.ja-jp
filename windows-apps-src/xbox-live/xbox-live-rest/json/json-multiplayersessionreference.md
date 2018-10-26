---
title: MultiplayerSessionReference (JSON)
assetID: 6e03e060-8c9b-b394-415f-af7e85be569f
permalink: en-us/docs/xboxlive/rest/json-multiplayersessionreference.html
author: KevinAsgari
description: " MultiplayerSessionReference (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: e54c7359456d5fb608fcdd82d0130298bb8605c8
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5561427"
---
# <a name="multiplayersessionreference-json"></a><span data-ttu-id="6a481-104">MultiplayerSessionReference (JSON)</span><span class="sxs-lookup"><span data-stu-id="6a481-104">MultiplayerSessionReference (JSON)</span></span>
<span data-ttu-id="6a481-105">**MultiplayerSessionReference**を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="6a481-105">A JSON object representing the **MultiplayerSessionReference**.</span></span> 
<a id="ID4EQ"></a>

  
 
<span data-ttu-id="6a481-106">MultiplayerSessionReference JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="6a481-106">The MultiplayerSessionReference JSON object has the following specification.</span></span>
 
| <span data-ttu-id="6a481-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="6a481-107">Member</span></span>| <span data-ttu-id="6a481-108">種類</span><span class="sxs-lookup"><span data-stu-id="6a481-108">Type</span></span>| <span data-ttu-id="6a481-109">説明</span><span class="sxs-lookup"><span data-stu-id="6a481-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="6a481-110">scid</span><span class="sxs-lookup"><span data-stu-id="6a481-110">scid</span></span>| <span data-ttu-id="6a481-111">GUID</span><span class="sxs-lookup"><span data-stu-id="6a481-111">GUID</span></span>| <span data-ttu-id="6a481-112">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="6a481-112">Service configuration identifier (SCID).</span></span> <span data-ttu-id="6a481-113">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="6a481-113">Part 1 of the session identifier.</span></span>| 
| <span data-ttu-id="6a481-114">templateName</span><span class="sxs-lookup"><span data-stu-id="6a481-114">templateName</span></span> | <span data-ttu-id="6a481-115">string</span><span class="sxs-lookup"><span data-stu-id="6a481-115">string</span></span> | <span data-ttu-id="6a481-116">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="6a481-116">Name of the current instance of the session template.</span></span> <span data-ttu-id="6a481-117">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="6a481-117">Part 2 of the session identifier.</span></span> | 
| <span data-ttu-id="6a481-118">name</span><span class="sxs-lookup"><span data-stu-id="6a481-118">name</span></span> | <span data-ttu-id="6a481-119">string</span><span class="sxs-lookup"><span data-stu-id="6a481-119">string</span></span> | <span data-ttu-id="6a481-120">セッションの名前です。</span><span class="sxs-lookup"><span data-stu-id="6a481-120">Name of the session.</span></span> <span data-ttu-id="6a481-121">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="6a481-121">Part 3 of the session identifier.</span></span> | 
  
<a id="ID4EZ"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="6a481-122">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="6a481-122">Sample JSON syntax</span></span> 
 

```json
{
  "scid": "8d050174-412b-4d51-a29b-d55a34edfdb7",
  "templateName": "integration",
  "name": "19de0095d8bb41048f19edbbb6bc6b04"
}
  
    
```

  
<a id="ID4EJB"></a>

 
## <a name="see-also"></a><span data-ttu-id="6a481-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="6a481-123">See also</span></span>
 
<a id="ID4ELB"></a>

 
##### <a name="parent"></a><span data-ttu-id="6a481-124">Parent</span><span class="sxs-lookup"><span data-stu-id="6a481-124">Parent</span></span> 

[<span data-ttu-id="6a481-125">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="6a481-125">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVB"></a>

 
##### <a name="reference"></a><span data-ttu-id="6a481-126">リファレンス</span><span class="sxs-lookup"><span data-stu-id="6a481-126">Reference</span></span> 

[<span data-ttu-id="6a481-127">MultiplayerSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="6a481-127">MultiplayerSession (JSON)</span></span>](json-multiplayersession.md)

   