---
title: ServiceError (JSON)
assetID: 81c43f6e-bfff-c4b5-d25c-eace22649f01
permalink: en-us/docs/xboxlive/rest/json-serviceerror.html
author: KevinAsgari
description: " ServiceError (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 9f9f5cb3f4dc0565cafc073cea35e3e6e00d273f
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4088088"
---
# <a name="serviceerror-json"></a><span data-ttu-id="0b9c8-104">ServiceError (JSON)</span><span class="sxs-lookup"><span data-stu-id="0b9c8-104">ServiceError (JSON)</span></span>
<span data-ttu-id="0b9c8-105">サービスへの呼び出しが失敗したときに返されるエラーに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-105">Contains information about an error returned when a call to the service failed.</span></span> 
<a id="ID4EN"></a>

 
## <a name="serviceerror"></a><span data-ttu-id="0b9c8-106">ServiceError</span><span class="sxs-lookup"><span data-stu-id="0b9c8-106">ServiceError</span></span>
 
<span data-ttu-id="0b9c8-107">ServiceError オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-107">The ServiceError object has the following specification.</span></span>
 
| <span data-ttu-id="0b9c8-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="0b9c8-108">Member</span></span>| <span data-ttu-id="0b9c8-109">種類</span><span class="sxs-lookup"><span data-stu-id="0b9c8-109">Type</span></span>| <span data-ttu-id="0b9c8-110">説明</span><span class="sxs-lookup"><span data-stu-id="0b9c8-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0b9c8-111">code</span><span class="sxs-lookup"><span data-stu-id="0b9c8-111">code</span></span>| <span data-ttu-id="0b9c8-112">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0b9c8-112">32-bit signed integer</span></span> | <span data-ttu-id="0b9c8-113">エラーの種類です。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-113">The type of error.</span></span> <span data-ttu-id="0b9c8-114">設定可能な値は、以下の表をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-114">See the table below for possible values.</span></span> | 
| <span data-ttu-id="0b9c8-115">ソース</span><span class="sxs-lookup"><span data-stu-id="0b9c8-115">source</span></span>| <span data-ttu-id="0b9c8-116">string</span><span class="sxs-lookup"><span data-stu-id="0b9c8-116">string</span></span> | <span data-ttu-id="0b9c8-117">エラーが発生したサービスの名前です。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-117">The name of the service that raised the error.</span></span> <span data-ttu-id="0b9c8-118">たとえば、値の<code>ReputationFD</code>評判サービスでエラーがあったことを示します。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-118">For example, a value of <code>ReputationFD</code> indicates that the error was in the reputation service.</span></span> | 
| <span data-ttu-id="0b9c8-119">description</span><span class="sxs-lookup"><span data-stu-id="0b9c8-119">description</span></span>| <span data-ttu-id="0b9c8-120">string</span><span class="sxs-lookup"><span data-stu-id="0b9c8-120">string</span></span>| <span data-ttu-id="0b9c8-121">エラーの説明です。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-121">A description of the error.</span></span> | 
 
<a id="ID4EBC"></a>

 
### <a name="error-codes"></a><span data-ttu-id="0b9c8-122">エラー コード</span><span class="sxs-lookup"><span data-stu-id="0b9c8-122">Error Codes</span></span>
 
| <span data-ttu-id="0b9c8-123">値</span><span class="sxs-lookup"><span data-stu-id="0b9c8-123">Value</span></span>| <span data-ttu-id="0b9c8-124">説明</span><span class="sxs-lookup"><span data-stu-id="0b9c8-124">Description</span></span>| 
| --- | --- | --- | --- | --- | 
| <span data-ttu-id="0b9c8-125">0</span><span class="sxs-lookup"><span data-stu-id="0b9c8-125">0</span></span>| <span data-ttu-id="0b9c8-126">成功エラーなし</span><span class="sxs-lookup"><span data-stu-id="0b9c8-126">Success No error</span></span>| 
| <span data-ttu-id="0b9c8-127">4000</span><span class="sxs-lookup"><span data-stu-id="0b9c8-127">4000</span></span>| <span data-ttu-id="0b9c8-128">POST 要求に失敗しました検証で送信される要求本文 JSON ドキュメントが無効です。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-128">Invalid Request Body The JSON document submitted with a POST request failed validation.</span></span> <span data-ttu-id="0b9c8-129">詳細については説明フィールドを参照してください。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-129">See the description field for details.</span></span> | 
| <span data-ttu-id="0b9c8-130">4100</span><span class="sxs-lookup"><span data-stu-id="0b9c8-130">4100</span></span>| <span data-ttu-id="0b9c8-131">ユーザーがいない存在、XUID 要求 URI に含まれているは XBOX Live で有効なユーザーにはありません。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-131">User Does Not Exist The XUID contained in the request URI does not represent a valid user on XBOX Live.</span></span>| 
| <span data-ttu-id="0b9c8-132">4500</span><span class="sxs-lookup"><span data-stu-id="0b9c8-132">4500</span></span>| <span data-ttu-id="0b9c8-133">承認エラー、呼び出し元は、要求された操作を実行する権限がありません。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-133">Authorization Error The caller is not authorized to perform the requested operation.</span></span>| 
| <span data-ttu-id="0b9c8-134">5000</span><span class="sxs-lookup"><span data-stu-id="0b9c8-134">5000</span></span>| <span data-ttu-id="0b9c8-135">サービスのエラーがあったサービスの内部エラー</span><span class="sxs-lookup"><span data-stu-id="0b9c8-135">Service Error There was an internal error in the service</span></span>| 
| <span data-ttu-id="0b9c8-136">5300</span><span class="sxs-lookup"><span data-stu-id="0b9c8-136">5300</span></span>| <span data-ttu-id="0b9c8-137">サービス提供を停止、サービスは利用できません。</span><span class="sxs-lookup"><span data-stu-id="0b9c8-137">Service Unavailable The service is unavailable.</span></span>| 
   
<a id="ID4EQE"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="0b9c8-138">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="0b9c8-138">Sample JSON syntax</span></span>
 

```json
{
    "code": 4000,
    "source": "ReputationFD",
    "description": "No targetXuid field was supplied in the request"
}
    
```

  
<a id="ID4EZE"></a>

 
## <a name="see-also"></a><span data-ttu-id="0b9c8-139">関連項目</span><span class="sxs-lookup"><span data-stu-id="0b9c8-139">See also</span></span>
 
<a id="ID4E2E"></a>

 
##### <a name="parent"></a><span data-ttu-id="0b9c8-140">Parent</span><span class="sxs-lookup"><span data-stu-id="0b9c8-140">Parent</span></span> 

[<span data-ttu-id="0b9c8-141">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="0b9c8-141">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   