---
title: quotaInfo (JSON)
assetID: 3147ab78-e671-e142-0a3a-688dc4079451
permalink: en-us/docs/xboxlive/rest/json-quota.html
description: " quotaInfo (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f3499fdba972d6e953813fc490d080910921698e
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8918395"
---
# <a name="quotainfo-json"></a><span data-ttu-id="b6599-104">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="b6599-104">quotaInfo (JSON)</span></span>
<span data-ttu-id="b6599-105">クォータ タイトル グループについてを説明します。</span><span class="sxs-lookup"><span data-stu-id="b6599-105">Contains quota information about a title group.</span></span> 
<a id="ID4EN"></a>

 
## <a name="quotainfo"></a><span data-ttu-id="b6599-106">quotaInfo</span><span class="sxs-lookup"><span data-stu-id="b6599-106">quotaInfo</span></span>
 
<span data-ttu-id="b6599-107">QuotaInfo オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="b6599-107">The quotaInfo object has the following specifications.</span></span>
 
<span data-ttu-id="b6599-108">グローバル ストレージ</span><span class="sxs-lookup"><span data-stu-id="b6599-108">For global storage</span></span>
 
| <span data-ttu-id="b6599-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="b6599-109">Member</span></span>| <span data-ttu-id="b6599-110">種類</span><span class="sxs-lookup"><span data-stu-id="b6599-110">Type</span></span>| <span data-ttu-id="b6599-111">説明</span><span class="sxs-lookup"><span data-stu-id="b6599-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b6599-112">quotaBytes</span><span class="sxs-lookup"><span data-stu-id="b6599-112">quotaBytes</span></span>| <span data-ttu-id="b6599-113">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="b6599-113">32-bit signed integer</span></span> | <span data-ttu-id="b6599-114">タイトルで使用可能なバイトの最大数。</span><span class="sxs-lookup"><span data-stu-id="b6599-114">Maximum number of bytes usable by the title.</span></span>| 
| <span data-ttu-id="b6599-115">usedBytes</span><span class="sxs-lookup"><span data-stu-id="b6599-115">usedBytes</span></span>| <span data-ttu-id="b6599-116">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="b6599-116">32-bit signed integer</span></span> | <span data-ttu-id="b6599-117">タイトルで使用されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="b6599-117">Number of bytes used by the title.</span></span>| 
  
<a id="ID4EXB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="b6599-118">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="b6599-118">Sample JSON syntax</span></span>
 
<span data-ttu-id="b6599-119">次の例は、グローバル ストレージへの応答を示しています。</span><span class="sxs-lookup"><span data-stu-id="b6599-119">The following example shows the response for global storage:</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="b6599-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="b6599-120">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b6599-121">Parent</span><span class="sxs-lookup"><span data-stu-id="b6599-121">Parent</span></span> 

[<span data-ttu-id="b6599-122">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="b6599-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   