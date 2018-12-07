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
ms.sourcegitcommit: d7613c791107f74b6a3dc12a372d9de916c0454b
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/06/2018
ms.locfileid: "8751273"
---
# <a name="serviceerror-json"></a><span data-ttu-id="7ac05-104">ServiceError (JSON)</span><span class="sxs-lookup"><span data-stu-id="7ac05-104">ServiceError (JSON)</span></span>
<span data-ttu-id="7ac05-105">サービスに呼び出しが失敗したときに返されるエラーに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="7ac05-105">Contains information about an error returned when a call to the service failed.</span></span> 
<a id="ID4EN"></a>

 
## <a name="serviceerror"></a><span data-ttu-id="7ac05-106">ServiceError</span><span class="sxs-lookup"><span data-stu-id="7ac05-106">ServiceError</span></span>
 
<span data-ttu-id="7ac05-107">ServiceError オブジェクトには、次仕様があります。</span><span class="sxs-lookup"><span data-stu-id="7ac05-107">The ServiceError object has the following specification.</span></span>
 
| <span data-ttu-id="7ac05-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="7ac05-108">Member</span></span>| <span data-ttu-id="7ac05-109">種類</span><span class="sxs-lookup"><span data-stu-id="7ac05-109">Type</span></span>| <span data-ttu-id="7ac05-110">説明</span><span class="sxs-lookup"><span data-stu-id="7ac05-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="7ac05-111">code</span><span class="sxs-lookup"><span data-stu-id="7ac05-111">code</span></span>| <span data-ttu-id="7ac05-112">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="7ac05-112">32-bit signed integer</span></span> | <span data-ttu-id="7ac05-113">エラーの種類です。</span><span class="sxs-lookup"><span data-stu-id="7ac05-113">The type of error.</span></span> <span data-ttu-id="7ac05-114">使用可能な値は、以下の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7ac05-114">See the table below for possible values.</span></span> | 
| <span data-ttu-id="7ac05-115">ソース</span><span class="sxs-lookup"><span data-stu-id="7ac05-115">source</span></span>| <span data-ttu-id="7ac05-116">string</span><span class="sxs-lookup"><span data-stu-id="7ac05-116">string</span></span> | <span data-ttu-id="7ac05-117">エラーが発生したサービスの名前。</span><span class="sxs-lookup"><span data-stu-id="7ac05-117">The name of the service that raised the error.</span></span> <span data-ttu-id="7ac05-118">たとえば、値の<code>ReputationFD</code>評判サービスでエラーがあったことを示します。</span><span class="sxs-lookup"><span data-stu-id="7ac05-118">For example, a value of <code>ReputationFD</code> indicates that the error was in the reputation service.</span></span> | 
| <span data-ttu-id="7ac05-119">description</span><span class="sxs-lookup"><span data-stu-id="7ac05-119">description</span></span>| <span data-ttu-id="7ac05-120">string</span><span class="sxs-lookup"><span data-stu-id="7ac05-120">string</span></span>| <span data-ttu-id="7ac05-121">エラーの説明です。</span><span class="sxs-lookup"><span data-stu-id="7ac05-121">A description of the error.</span></span> | 
 
<a id="ID4EBC"></a>

 
### <a name="error-codes"></a><span data-ttu-id="7ac05-122">エラー コード</span><span class="sxs-lookup"><span data-stu-id="7ac05-122">Error Codes</span></span>
 
| <span data-ttu-id="7ac05-123">値</span><span class="sxs-lookup"><span data-stu-id="7ac05-123">Value</span></span>| <span data-ttu-id="7ac05-124">説明</span><span class="sxs-lookup"><span data-stu-id="7ac05-124">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="7ac05-125">0</span><span class="sxs-lookup"><span data-stu-id="7ac05-125">0</span></span>| <span data-ttu-id="7ac05-126">成功エラーなし</span><span class="sxs-lookup"><span data-stu-id="7ac05-126">Success No error</span></span>| 
| <span data-ttu-id="7ac05-127">4000</span><span class="sxs-lookup"><span data-stu-id="7ac05-127">4000</span></span>| <span data-ttu-id="7ac05-128">POST 要求に失敗しましたの検証で送信される要求本文 JSON ドキュメントが無効です。</span><span class="sxs-lookup"><span data-stu-id="7ac05-128">Invalid Request Body The JSON document submitted with a POST request failed validation.</span></span> <span data-ttu-id="7ac05-129">詳細については説明フィールドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="7ac05-129">See the description field for details.</span></span> | 
| <span data-ttu-id="7ac05-130">4100</span><span class="sxs-lookup"><span data-stu-id="7ac05-130">4100</span></span>| <span data-ttu-id="7ac05-131">ユーザーがいない存在、XUID 要求 URI に含まれているは XBOX Live で有効なユーザーにはありません。</span><span class="sxs-lookup"><span data-stu-id="7ac05-131">User Does Not Exist The XUID contained in the request URI does not represent a valid user on XBOX Live.</span></span>| 
| <span data-ttu-id="7ac05-132">4500</span><span class="sxs-lookup"><span data-stu-id="7ac05-132">4500</span></span>| <span data-ttu-id="7ac05-133">承認エラー、呼び出し元は、要求された操作を実行する権限がありません。</span><span class="sxs-lookup"><span data-stu-id="7ac05-133">Authorization Error The caller is not authorized to perform the requested operation.</span></span>| 
| <span data-ttu-id="7ac05-134">5000</span><span class="sxs-lookup"><span data-stu-id="7ac05-134">5000</span></span>| <span data-ttu-id="7ac05-135">サービスの内部エラーがあったにサービスのエラー</span><span class="sxs-lookup"><span data-stu-id="7ac05-135">Service Error There was an internal error in the service</span></span>| 
| <span data-ttu-id="7ac05-136">5300</span><span class="sxs-lookup"><span data-stu-id="7ac05-136">5300</span></span>| <span data-ttu-id="7ac05-137">サービス提供を停止、サービスは利用できません。</span><span class="sxs-lookup"><span data-stu-id="7ac05-137">Service Unavailable The service is unavailable.</span></span>| 
   
<a id="ID4EQE"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="7ac05-138">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="7ac05-138">Sample JSON syntax</span></span>
 

```json
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
    
```

  
<a id="ID4EZE"></a>

 
## <a name="see-also"></a><span data-ttu-id="7ac05-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="7ac05-139">See also</span></span>
 
<a id="ID4E2E"></a>

 
##### <a name="parent"></a><span data-ttu-id="7ac05-140">Parent</span><span class="sxs-lookup"><span data-stu-id="7ac05-140">Parent</span></span> 

[<span data-ttu-id="7ac05-141">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="7ac05-141">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   