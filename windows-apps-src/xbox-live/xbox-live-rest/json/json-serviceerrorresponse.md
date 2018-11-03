---
title: ServiceErrorResponse (JSON)
assetID: a2077df8-f76c-0233-8e41-68267b681862
permalink: en-us/docs/xboxlive/rest/json-serviceerrorresponse.html
author: KevinAsgari
description: " ServiceErrorResponse (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4da4a36bca0cad761ef4dda89f86b23f6cf44c30
ms.sourcegitcommit: 144f5f127fc4fbd852f2f6780ef26054192d68fc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/03/2018
ms.locfileid: "5984504"
---
# <a name="serviceerrorresponse-json"></a><span data-ttu-id="c0f87-104">ServiceErrorResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="c0f87-104">ServiceErrorResponse (JSON)</span></span>
<span data-ttu-id="c0f87-105">サービスのエラーが発生したときは、適切な HTTP エラー コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="c0f87-105">When a service error is encountered, an appropriate HTTP error code will be returned.</span></span> <span data-ttu-id="c0f87-106">必要に応じて、サービスもあります ServiceErrorResponse オブジェクトの下で定義されています。</span><span class="sxs-lookup"><span data-stu-id="c0f87-106">Optionally, the service may also include a ServiceErrorResponse object as defined below.</span></span> <span data-ttu-id="c0f87-107">運用環境での低いデータを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="c0f87-107">In production environments, less data may be included.</span></span> 
<a id="ID4EN"></a>

 
## <a name="serviceerrorresponse"></a><span data-ttu-id="c0f87-108">ServiceErrorResponse</span><span class="sxs-lookup"><span data-stu-id="c0f87-108">ServiceErrorResponse</span></span>
 
<span data-ttu-id="c0f87-109">ServiceErrorResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="c0f87-109">The ServiceErrorResponse object has the following specification.</span></span>
 
| <span data-ttu-id="c0f87-110">メンバー</span><span class="sxs-lookup"><span data-stu-id="c0f87-110">Member</span></span>| <span data-ttu-id="c0f87-111">種類</span><span class="sxs-lookup"><span data-stu-id="c0f87-111">Type</span></span>| <span data-ttu-id="c0f87-112">説明</span><span class="sxs-lookup"><span data-stu-id="c0f87-112">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="c0f87-113">errorCode</span><span class="sxs-lookup"><span data-stu-id="c0f87-113">errorCode</span></span></b>| <span data-ttu-id="c0f87-114">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="c0f87-114">32-bit signed integer</span></span>| <span data-ttu-id="c0f87-115">(Null にすることができます) エラーに関連付けられたコードです。</span><span class="sxs-lookup"><span data-stu-id="c0f87-115">Code associated with the error (can be null).</span></span>| 
| <b><span data-ttu-id="c0f87-116">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="c0f87-116">errorMessage</span></span></b>| <span data-ttu-id="c0f87-117">string</span><span class="sxs-lookup"><span data-stu-id="c0f87-117">string</span></span>| <span data-ttu-id="c0f87-118">エラーに関する詳細を追加します。</span><span class="sxs-lookup"><span data-stu-id="c0f87-118">Additional details about the error.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="c0f87-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="c0f87-119">Sample JSON syntax</span></span>
 

```json
{
   "errorCode": 8377,
   "errorMessage": "XUID specified in the claim does not match URI XUID."
 }
    
```

  
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="c0f87-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="c0f87-120">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="c0f87-121">Parent</span><span class="sxs-lookup"><span data-stu-id="c0f87-121">Parent</span></span> 

[<span data-ttu-id="c0f87-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="c0f87-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   