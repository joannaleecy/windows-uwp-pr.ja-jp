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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57651247"
---
# <a name="multiplayersessionreference-json"></a><span data-ttu-id="662fa-104">MultiplayerSessionReference (JSON)</span><span class="sxs-lookup"><span data-stu-id="662fa-104">MultiplayerSessionReference (JSON)</span></span>
<span data-ttu-id="662fa-105">表す JSON オブジェクト、 **MultiplayerSessionReference**します。</span><span class="sxs-lookup"><span data-stu-id="662fa-105">A JSON object representing the **MultiplayerSessionReference**.</span></span> 
<a id="ID4EQ"></a>

  
 
<span data-ttu-id="662fa-106">MultiplayerSessionReference JSON オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="662fa-106">The MultiplayerSessionReference JSON object has the following specification.</span></span>
 
| <span data-ttu-id="662fa-107">メンバー</span><span class="sxs-lookup"><span data-stu-id="662fa-107">Member</span></span>| <span data-ttu-id="662fa-108">種類</span><span class="sxs-lookup"><span data-stu-id="662fa-108">Type</span></span>| <span data-ttu-id="662fa-109">説明</span><span class="sxs-lookup"><span data-stu-id="662fa-109">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="662fa-110">scid</span><span class="sxs-lookup"><span data-stu-id="662fa-110">scid</span></span>| <span data-ttu-id="662fa-111">GUID</span><span class="sxs-lookup"><span data-stu-id="662fa-111">GUID</span></span>| <span data-ttu-id="662fa-112">サービス構成の識別子 (SCID) です。</span><span class="sxs-lookup"><span data-stu-id="662fa-112">Service configuration identifier (SCID).</span></span> <span data-ttu-id="662fa-113">パート 1 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="662fa-113">Part 1 of the session identifier.</span></span>| 
| <span data-ttu-id="662fa-114">templateName</span><span class="sxs-lookup"><span data-stu-id="662fa-114">templateName</span></span> | <span data-ttu-id="662fa-115">string</span><span class="sxs-lookup"><span data-stu-id="662fa-115">string</span></span> | <span data-ttu-id="662fa-116">セッション テンプレートの現在のインスタンスの名前です。</span><span class="sxs-lookup"><span data-stu-id="662fa-116">Name of the current instance of the session template.</span></span> <span data-ttu-id="662fa-117">パート 2 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="662fa-117">Part 2 of the session identifier.</span></span> | 
| <span data-ttu-id="662fa-118">name</span><span class="sxs-lookup"><span data-stu-id="662fa-118">name</span></span> | <span data-ttu-id="662fa-119">string</span><span class="sxs-lookup"><span data-stu-id="662fa-119">string</span></span> | <span data-ttu-id="662fa-120">セッションの名前。</span><span class="sxs-lookup"><span data-stu-id="662fa-120">Name of the session.</span></span> <span data-ttu-id="662fa-121">パート 3 のセッション識別子。</span><span class="sxs-lookup"><span data-stu-id="662fa-121">Part 3 of the session identifier.</span></span> | 
  
<a id="ID4EZ"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="662fa-122">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="662fa-122">Sample JSON syntax</span></span> 
 

```json
{
  "scid": "8d050174-412b-4d51-a29b-d55a34edfdb7",
  "templateName": "integration",
  "name": "19de0095d8bb41048f19edbbb6bc6b04"
}
  
    
```

  
<a id="ID4EJB"></a>

 
## <a name="see-also"></a><span data-ttu-id="662fa-123">関連項目</span><span class="sxs-lookup"><span data-stu-id="662fa-123">See also</span></span>
 
<a id="ID4ELB"></a>

 
##### <a name="parent"></a><span data-ttu-id="662fa-124">Parent</span><span class="sxs-lookup"><span data-stu-id="662fa-124">Parent</span></span> 

[<span data-ttu-id="662fa-125">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="662fa-125">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

  
<a id="ID4EVB"></a>

 
##### <a name="reference"></a><span data-ttu-id="662fa-126">リファレンス</span><span class="sxs-lookup"><span data-stu-id="662fa-126">Reference</span></span> 

[<span data-ttu-id="662fa-127">MultiplayerSession (JSON)</span><span class="sxs-lookup"><span data-stu-id="662fa-127">MultiplayerSession (JSON)</span></span>](json-multiplayersession.md)

   