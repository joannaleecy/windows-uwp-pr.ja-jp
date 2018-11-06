---
title: quotaInfo (JSON)
assetID: 3147ab78-e671-e142-0a3a-688dc4079451
permalink: en-us/docs/xboxlive/rest/json-quota.html
author: KevinAsgari
description: " quotaInfo (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6cb2283f5214d1d25e1aa0e8bcba17f4c51019fd
ms.sourcegitcommit: e814a13978f33654d8e995584f4b047cb53e0aef
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/06/2018
ms.locfileid: "6022815"
---
# <a name="quotainfo-json"></a><span data-ttu-id="0e771-104">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="0e771-104">quotaInfo (JSON)</span></span>
<span data-ttu-id="0e771-105">クォータ タイトル グループについてを説明します。</span><span class="sxs-lookup"><span data-stu-id="0e771-105">Contains quota information about a title group.</span></span> 
<a id="ID4EN"></a>

 
## <a name="quotainfo"></a><span data-ttu-id="0e771-106">quotaInfo</span><span class="sxs-lookup"><span data-stu-id="0e771-106">quotaInfo</span></span>
 
<span data-ttu-id="0e771-107">QuotaInfo オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="0e771-107">The quotaInfo object has the following specifications.</span></span>
 
<span data-ttu-id="0e771-108">グローバル ストレージ</span><span class="sxs-lookup"><span data-stu-id="0e771-108">For global storage</span></span>
 
| <span data-ttu-id="0e771-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="0e771-109">Member</span></span>| <span data-ttu-id="0e771-110">種類</span><span class="sxs-lookup"><span data-stu-id="0e771-110">Type</span></span>| <span data-ttu-id="0e771-111">説明</span><span class="sxs-lookup"><span data-stu-id="0e771-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="0e771-112">quotaBytes</span><span class="sxs-lookup"><span data-stu-id="0e771-112">quotaBytes</span></span>| <span data-ttu-id="0e771-113">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0e771-113">32-bit signed integer</span></span> | <span data-ttu-id="0e771-114">タイトルで使用可能なバイトの最大数。</span><span class="sxs-lookup"><span data-stu-id="0e771-114">Maximum number of bytes usable by the title.</span></span>| 
| <span data-ttu-id="0e771-115">usedBytes</span><span class="sxs-lookup"><span data-stu-id="0e771-115">usedBytes</span></span>| <span data-ttu-id="0e771-116">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="0e771-116">32-bit signed integer</span></span> | <span data-ttu-id="0e771-117">タイトルで使用されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="0e771-117">Number of bytes used by the title.</span></span>| 
  
<a id="ID4EXB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="0e771-118">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="0e771-118">Sample JSON syntax</span></span>
 
<span data-ttu-id="0e771-119">次の例は、グローバル ストレージへの応答を示しています。</span><span class="sxs-lookup"><span data-stu-id="0e771-119">The following example shows the response for global storage:</span></span>
 

```json
{
    "quotaInfo":
    {
        "usedBytes":4194304,
        "quotaBytes":536870912
    }
}
      
```

  
<a id="ID4ECC"></a>

 
## <a name="see-also"></a><span data-ttu-id="0e771-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="0e771-120">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="0e771-121">Parent</span><span class="sxs-lookup"><span data-stu-id="0e771-121">Parent</span></span> 

[<span data-ttu-id="0e771-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="0e771-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   