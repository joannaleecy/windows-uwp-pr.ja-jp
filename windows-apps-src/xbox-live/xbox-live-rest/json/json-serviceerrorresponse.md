---
title: ServiceErrorResponse (JSON)
assetID: a2077df8-f76c-0233-8e41-68267b681862
permalink: en-us/docs/xboxlive/rest/json-serviceerrorresponse.html
author: KevinAsgari
description: " ServiceErrorResponse (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f0eed745b9350bd1bc2f4860cb3db5e5a6b9ad7c
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4394259"
---
# <a name="serviceerrorresponse-json"></a><span data-ttu-id="3845a-104">ServiceErrorResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="3845a-104">ServiceErrorResponse (JSON)</span></span>
<span data-ttu-id="3845a-105">サービスのエラーが発生したときは、適切な HTTP エラー コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="3845a-105">When a service error is encountered, an appropriate HTTP error code will be returned.</span></span> <span data-ttu-id="3845a-106">必要に応じて、サービスもあります ServiceErrorResponse オブジェクトの下に定義されています。</span><span class="sxs-lookup"><span data-stu-id="3845a-106">Optionally, the service may also include a ServiceErrorResponse object as defined below.</span></span> <span data-ttu-id="3845a-107">運用環境での低いデータを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="3845a-107">In production environments, less data may be included.</span></span> 
<a id="ID4EN"></a>

 
## <a name="serviceerrorresponse"></a><span data-ttu-id="3845a-108">ServiceErrorResponse</span><span class="sxs-lookup"><span data-stu-id="3845a-108">ServiceErrorResponse</span></span>
 
<span data-ttu-id="3845a-109">ServiceErrorResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="3845a-109">The ServiceErrorResponse object has the following specification.</span></span>
 
| <span data-ttu-id="3845a-110">メンバー</span><span class="sxs-lookup"><span data-stu-id="3845a-110">Member</span></span>| <span data-ttu-id="3845a-111">種類</span><span class="sxs-lookup"><span data-stu-id="3845a-111">Type</span></span>| <span data-ttu-id="3845a-112">説明</span><span class="sxs-lookup"><span data-stu-id="3845a-112">Description</span></span>| 
| --- | --- | --- | 
| <b><span data-ttu-id="3845a-113">errorCode</span><span class="sxs-lookup"><span data-stu-id="3845a-113">errorCode</span></span></b>| <span data-ttu-id="3845a-114">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="3845a-114">32-bit signed integer</span></span>| <span data-ttu-id="3845a-115">(Null にすることができます) エラーに関連付けられたコードです。</span><span class="sxs-lookup"><span data-stu-id="3845a-115">Code associated with the error (can be null).</span></span>| 
| <b><span data-ttu-id="3845a-116">エラー メッセージ</span><span class="sxs-lookup"><span data-stu-id="3845a-116">errorMessage</span></span></b>| <span data-ttu-id="3845a-117">string</span><span class="sxs-lookup"><span data-stu-id="3845a-117">string</span></span>| <span data-ttu-id="3845a-118">エラーの詳細を追加します。</span><span class="sxs-lookup"><span data-stu-id="3845a-118">Additional details about the error.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="3845a-119">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="3845a-119">Sample JSON syntax</span></span>
 

```json
{
   "errorCode": 8377,
   "errorMessage": "XUID specified in the claim does not match URI XUID."
 }
    
```

  
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="3845a-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="3845a-120">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="3845a-121">Parent</span><span class="sxs-lookup"><span data-stu-id="3845a-121">Parent</span></span> 

[<span data-ttu-id="3845a-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="3845a-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   