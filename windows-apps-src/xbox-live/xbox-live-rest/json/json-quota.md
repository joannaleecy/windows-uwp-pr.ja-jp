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
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5811380"
---
# <a name="quotainfo-json"></a><span data-ttu-id="e5191-104">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="e5191-104">quotaInfo (JSON)</span></span>
<span data-ttu-id="e5191-105">クォータ タイトル グループについてを説明します。</span><span class="sxs-lookup"><span data-stu-id="e5191-105">Contains quota information about a title group.</span></span> 
<a id="ID4EN"></a>

 
## <a name="quotainfo"></a><span data-ttu-id="e5191-106">quotaInfo</span><span class="sxs-lookup"><span data-stu-id="e5191-106">quotaInfo</span></span>
 
<span data-ttu-id="e5191-107">QuotaInfo オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="e5191-107">The quotaInfo object has the following specifications.</span></span>
 
<span data-ttu-id="e5191-108">グローバル ストレージ</span><span class="sxs-lookup"><span data-stu-id="e5191-108">For global storage</span></span>
 
| <span data-ttu-id="e5191-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="e5191-109">Member</span></span>| <span data-ttu-id="e5191-110">種類</span><span class="sxs-lookup"><span data-stu-id="e5191-110">Type</span></span>| <span data-ttu-id="e5191-111">説明</span><span class="sxs-lookup"><span data-stu-id="e5191-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="e5191-112">quotaBytes</span><span class="sxs-lookup"><span data-stu-id="e5191-112">quotaBytes</span></span>| <span data-ttu-id="e5191-113">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="e5191-113">32-bit signed integer</span></span> | <span data-ttu-id="e5191-114">タイトルで使用可能なバイトの最大数。</span><span class="sxs-lookup"><span data-stu-id="e5191-114">Maximum number of bytes usable by the title.</span></span>| 
| <span data-ttu-id="e5191-115">usedBytes</span><span class="sxs-lookup"><span data-stu-id="e5191-115">usedBytes</span></span>| <span data-ttu-id="e5191-116">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="e5191-116">32-bit signed integer</span></span> | <span data-ttu-id="e5191-117">タイトルで使用されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="e5191-117">Number of bytes used by the title.</span></span>| 
  
<a id="ID4EXB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="e5191-118">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="e5191-118">Sample JSON syntax</span></span>
 
<span data-ttu-id="e5191-119">次の例は、グローバル ストレージへの応答を示しています。</span><span class="sxs-lookup"><span data-stu-id="e5191-119">The following example shows the response for global storage:</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="e5191-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="e5191-120">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="e5191-121">Parent</span><span class="sxs-lookup"><span data-stu-id="e5191-121">Parent</span></span> 

[<span data-ttu-id="e5191-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="e5191-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   