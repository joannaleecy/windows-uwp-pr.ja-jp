---
title: MultiplayerSessionReference (JSON)
assetID: 6e03e060-8c9b-b394-415f-af7e85be569f
permalink: en-us/docs/xboxlive/rest/json-multiplayersessionreference.html
description: " MultiplayerSessionReference (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5986079e1cae3338d8cc24a9e85f6941cf4fbec4
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8328039"
---
# <a name="multiplayersessionreference-json"></a><span data-ttu-id="f60c3-104">MultiplayerSessionReference (JSON)</span><span class="sxs-lookup"><span data-stu-id="f60c3-104">MultiplayerSessionReference (JSON)</span></span>
<span data-ttu-id="f60c3-105">**MultiplayerSessionReference**を表す JSON オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="f60c3-105">A JSON object representing the **MultiplayerSessionReference**.</span></span> 
<a id="ID4EQ"></a>

  
 
<span data-ttu-id="f60c3-106">MultiplayerSessionReference JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f60c3-106">The MultiplayerSessionReference JSON object has the following specification.</span></span>
 
| <span data-ttu-id="f60c3-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="f60c3-107">Member</span></span>| <span data-ttu-id="f60c3-108">種類</span><span class="sxs-lookup"><span data-stu-id="f60c3-108">Type</span></span>| <span data-ttu-id="f60c3-109">説明</span><span class="sxs-lookup"><span data-stu-id="f60c3-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f60c3-110">scid</span><span class="sxs-lookup"><span data-stu-id="f60c3-110">scid</span></span>| <span data-ttu-id="f60c3-111">GUID</span><span class="sxs-lookup"><span data-stu-id="f60c3-111">GUID</span></span>| <span data-ttu-id="f60c3-112">サービス構成 id (SCID)。</span><span class="sxs-lookup"><span data-stu-id="f60c3-112">Service configuration identifier (SCID).</span></span> <span data-ttu-id="f60c3-113">セッション識別子のパート 1 です。</span><span class="sxs-lookup"><span data-stu-id="f60c3-113">Part 1 of the session identifier.</span></span>| 
| <span data-ttu-id="f60c3-114">templateName</span><span class="sxs-lookup"><span data-stu-id="f60c3-114">templateName</span></span> | <span data-ttu-id="f60c3-115">string</span><span class="sxs-lookup"><span data-stu-id="f60c3-115">string</span></span> | <span data-ttu-id="f60c3-116">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="f60c3-116">Name of the current instance of the session template.</span></span> <span data-ttu-id="f60c3-117">セッション識別子のパート 2 です。</span><span class="sxs-lookup"><span data-stu-id="f60c3-117">Part 2 of the session identifier.</span></span> | 
| <span data-ttu-id="f60c3-118">name</span><span class="sxs-lookup"><span data-stu-id="f60c3-118">name</span></span> | <span data-ttu-id="f60c3-119">string</span><span class="sxs-lookup"><span data-stu-id="f60c3-119">string</span></span> | <span data-ttu-id="f60c3-120">セッションの名前です。</span><span class="sxs-lookup"><span data-stu-id="f60c3-120">Name of the session.</span></span> <span data-ttu-id="f60c3-121">セッション識別子のパート 3 です。</span><span class="sxs-lookup"><span data-stu-id="f60c3-121">Part 3 of the session identifier.</span></span> | 
  
<a id="ID4EZ"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="f60c3-122">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="f60c3-122">Sample JSON syntax</span></span> 
 

```json
{
  "scid": "8d050174-412b-4d51-a29b-d55a34edfdb7",
  "templateName": "integration",
  "name": "19de0095d8bb41048f19edbbb6bc6b04"
}
  
    
```

  
<a id="ID4EJB"></a>

 
## <a name="see-also"></a><span data-ttu-id="f60c3-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="f60c3-123">See also</span></span>
 
<a id="ID4ELB"></a>

 
##### <a name="parent"></a><span data-ttu-id="f60c3-124">Parent</span><span class="sxs-lookup"><span data-stu-id="f60c3-124">Parent</span></span> 

[<span data-ttu-id="f60c3-125">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f60c3-125">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVB"></a>

 
##### <a name="reference"></a><span data-ttu-id="f60c3-126">リファレンス</span><span class="sxs-lookup"><span data-stu-id="f60c3-126">Reference</span></span> 

[<span data-ttu-id="f60c3-127">MultiplayerSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="f60c3-127">MultiplayerSession (JSON)</span></span>](json-multiplayersession.md)

   