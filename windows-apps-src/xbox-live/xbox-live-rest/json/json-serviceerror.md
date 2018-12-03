---
title: ServiceError (JSON)
assetID: 81c43f6e-bfff-c4b5-d25c-eace22649f01
permalink: en-us/docs/xboxlive/rest/json-serviceerror.html
description: " ServiceError (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: da3d682a1b66d25a12f21a93e9596d13afae7f90
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8337551"
---
# <a name="serviceerror-json"></a><span data-ttu-id="e9a60-104">ServiceError (JSON)</span><span class="sxs-lookup"><span data-stu-id="e9a60-104">ServiceError (JSON)</span></span>
<span data-ttu-id="e9a60-105">サービスに呼び出しが失敗したときに返されるエラーに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="e9a60-105">Contains information about an error returned when a call to the service failed.</span></span> 
<a id="ID4EN"></a>

 
## <a name="serviceerror"></a><span data-ttu-id="e9a60-106">ServiceError</span><span class="sxs-lookup"><span data-stu-id="e9a60-106">ServiceError</span></span>
 
<span data-ttu-id="e9a60-107">ServiceError オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="e9a60-107">The ServiceError object has the following specification.</span></span>
 
| <span data-ttu-id="e9a60-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="e9a60-108">Member</span></span>| <span data-ttu-id="e9a60-109">種類</span><span class="sxs-lookup"><span data-stu-id="e9a60-109">Type</span></span>| <span data-ttu-id="e9a60-110">説明</span><span class="sxs-lookup"><span data-stu-id="e9a60-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e9a60-111">code</span><span class="sxs-lookup"><span data-stu-id="e9a60-111">code</span></span>| <span data-ttu-id="e9a60-112">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="e9a60-112">32-bit signed integer</span></span> | <span data-ttu-id="e9a60-113">エラーの種類です。</span><span class="sxs-lookup"><span data-stu-id="e9a60-113">The type of error.</span></span> <span data-ttu-id="e9a60-114">設定可能な値は、以下の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e9a60-114">See the table below for possible values.</span></span> | 
| <span data-ttu-id="e9a60-115">ソース</span><span class="sxs-lookup"><span data-stu-id="e9a60-115">source</span></span>| <span data-ttu-id="e9a60-116">string</span><span class="sxs-lookup"><span data-stu-id="e9a60-116">string</span></span> | <span data-ttu-id="e9a60-117">エラーが発生したサービスの名前。</span><span class="sxs-lookup"><span data-stu-id="e9a60-117">The name of the service that raised the error.</span></span> <span data-ttu-id="e9a60-118">たとえば、値の<code>ReputationFD</code>評判サービスでエラーがあったことを示します。</span><span class="sxs-lookup"><span data-stu-id="e9a60-118">For example, a value of <code>ReputationFD</code> indicates that the error was in the reputation service.</span></span> | 
| <span data-ttu-id="e9a60-119">description</span><span class="sxs-lookup"><span data-stu-id="e9a60-119">description</span></span>| <span data-ttu-id="e9a60-120">string</span><span class="sxs-lookup"><span data-stu-id="e9a60-120">string</span></span>| <span data-ttu-id="e9a60-121">エラーの説明です。</span><span class="sxs-lookup"><span data-stu-id="e9a60-121">A description of the error.</span></span> | 
 
<a id="ID4EBC"></a>

 
### <a name="error-codes"></a><span data-ttu-id="e9a60-122">エラー コード</span><span class="sxs-lookup"><span data-stu-id="e9a60-122">Error Codes</span></span>
 
| <span data-ttu-id="e9a60-123">値</span><span class="sxs-lookup"><span data-stu-id="e9a60-123">Value</span></span>| <span data-ttu-id="e9a60-124">説明</span><span class="sxs-lookup"><span data-stu-id="e9a60-124">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="e9a60-125">0</span><span class="sxs-lookup"><span data-stu-id="e9a60-125">0</span></span>| <span data-ttu-id="e9a60-126">成功エラーなし</span><span class="sxs-lookup"><span data-stu-id="e9a60-126">Success No error</span></span>| 
| <span data-ttu-id="e9a60-127">4000</span><span class="sxs-lookup"><span data-stu-id="e9a60-127">4000</span></span>| <span data-ttu-id="e9a60-128">POST 要求に失敗しました検証で送信される要求本文 JSON ドキュメントが無効です。</span><span class="sxs-lookup"><span data-stu-id="e9a60-128">Invalid Request Body The JSON document submitted with a POST request failed validation.</span></span> <span data-ttu-id="e9a60-129">詳細については説明フィールドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="e9a60-129">See the description field for details.</span></span> | 
| <span data-ttu-id="e9a60-130">4100</span><span class="sxs-lookup"><span data-stu-id="e9a60-130">4100</span></span>| <span data-ttu-id="e9a60-131">ユーザーがいない存在、XUID 要求 URI に含まれているは XBOX Live で有効なユーザーにはありません。</span><span class="sxs-lookup"><span data-stu-id="e9a60-131">User Does Not Exist The XUID contained in the request URI does not represent a valid user on XBOX Live.</span></span>| 
| <span data-ttu-id="e9a60-132">4500</span><span class="sxs-lookup"><span data-stu-id="e9a60-132">4500</span></span>| <span data-ttu-id="e9a60-133">承認エラー、呼び出し元は、要求された操作を実行する権限がありません。</span><span class="sxs-lookup"><span data-stu-id="e9a60-133">Authorization Error The caller is not authorized to perform the requested operation.</span></span>| 
| <span data-ttu-id="e9a60-134">5000</span><span class="sxs-lookup"><span data-stu-id="e9a60-134">5000</span></span>| <span data-ttu-id="e9a60-135">サービスのエラーがあった、サービスの内部エラー</span><span class="sxs-lookup"><span data-stu-id="e9a60-135">Service Error There was an internal error in the service</span></span>| 
| <span data-ttu-id="e9a60-136">5300</span><span class="sxs-lookup"><span data-stu-id="e9a60-136">5300</span></span>| <span data-ttu-id="e9a60-137">サービス提供を停止、サービスは利用できません。</span><span class="sxs-lookup"><span data-stu-id="e9a60-137">Service Unavailable The service is unavailable.</span></span>| 
   
<a id="ID4EQE"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="e9a60-138">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="e9a60-138">Sample JSON syntax</span></span>
 

```json
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
    
```

  
<a id="ID4EZE"></a>

 
## <a name="see-also"></a><span data-ttu-id="e9a60-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="e9a60-139">See also</span></span>
 
<a id="ID4E2E"></a>

 
##### <a name="parent"></a><span data-ttu-id="e9a60-140">Parent</span><span class="sxs-lookup"><span data-stu-id="e9a60-140">Parent</span></span> 

[<span data-ttu-id="e9a60-141">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="e9a60-141">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   