---
title: ServiceErrorResponse (JSON)
assetID: a2077df8-f76c-0233-8e41-68267b681862
permalink: en-us/docs/xboxlive/rest/json-serviceerrorresponse.html
description: " ServiceErrorResponse (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 86f9389f6f76c1c51955a6c784393e9b05909298
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57597507"
---
# <a name="serviceerrorresponse-json"></a><span data-ttu-id="acf4b-104">ServiceErrorResponse (JSON)</span><span class="sxs-lookup"><span data-stu-id="acf4b-104">ServiceErrorResponse (JSON)</span></span>
<span data-ttu-id="acf4b-105">サービスのエラーが発生した場合に適切な HTTP エラー コードが返されます。</span><span class="sxs-lookup"><span data-stu-id="acf4b-105">When a service error is encountered, an appropriate HTTP error code will be returned.</span></span> <span data-ttu-id="acf4b-106">必要に応じて、以下に定義されている、サービスは ServiceErrorResponse オブジェクトを含めることもできます。</span><span class="sxs-lookup"><span data-stu-id="acf4b-106">Optionally, the service may also include a ServiceErrorResponse object as defined below.</span></span> <span data-ttu-id="acf4b-107">運用環境での低いデータを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="acf4b-107">In production environments, less data may be included.</span></span> 
<a id="ID4EN"></a>

 
## <a name="serviceerrorresponse"></a><span data-ttu-id="acf4b-108">ServiceErrorResponse</span><span class="sxs-lookup"><span data-stu-id="acf4b-108">ServiceErrorResponse</span></span>
 
<span data-ttu-id="acf4b-109">ServiceErrorResponse オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="acf4b-109">The ServiceErrorResponse object has the following specification.</span></span>
 
| <span data-ttu-id="acf4b-110">メンバー</span><span class="sxs-lookup"><span data-stu-id="acf4b-110">Member</span></span>| <span data-ttu-id="acf4b-111">種類</span><span class="sxs-lookup"><span data-stu-id="acf4b-111">Type</span></span>| <span data-ttu-id="acf4b-112">説明</span><span class="sxs-lookup"><span data-stu-id="acf4b-112">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="acf4b-113"><b>errorCode</b></span><span class="sxs-lookup"><span data-stu-id="acf4b-113"><b>errorCode</b></span></span>| <span data-ttu-id="acf4b-114">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="acf4b-114">32-bit signed integer</span></span>| <span data-ttu-id="acf4b-115">(Null にすることができます)、エラーに関連付けられているコードです。</span><span class="sxs-lookup"><span data-stu-id="acf4b-115">Code associated with the error (can be null).</span></span>| 
| <span data-ttu-id="acf4b-116"><b>errorMessage</b></span><span class="sxs-lookup"><span data-stu-id="acf4b-116"><b>errorMessage</b></span></span>| <span data-ttu-id="acf4b-117">string</span><span class="sxs-lookup"><span data-stu-id="acf4b-117">string</span></span>| <span data-ttu-id="acf4b-118">エラーの詳細を追加します。</span><span class="sxs-lookup"><span data-stu-id="acf4b-118">Additional details about the error.</span></span>| 
  
<a id="ID4EVB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="acf4b-119">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="acf4b-119">Sample JSON syntax</span></span>
 

```json
{
   "errorCode": 8377,
   "errorMessage": "XUID specified in the claim does not match URI XUID."
 }
    
```

  
<a id="ID4E5B"></a>

 
## <a name="see-also"></a><span data-ttu-id="acf4b-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="acf4b-120">See also</span></span>
 
<a id="ID4EAC"></a>

 
##### <a name="parent"></a><span data-ttu-id="acf4b-121">Parent</span><span class="sxs-lookup"><span data-stu-id="acf4b-121">Parent</span></span> 

[<span data-ttu-id="acf4b-122">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="acf4b-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   