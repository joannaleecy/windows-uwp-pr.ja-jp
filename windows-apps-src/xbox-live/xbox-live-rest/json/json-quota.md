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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57654117"
---
# <a name="quotainfo-json"></a><span data-ttu-id="b5615-104">quotaInfo (JSON)</span><span class="sxs-lookup"><span data-stu-id="b5615-104">quotaInfo (JSON)</span></span>
<span data-ttu-id="b5615-105">タイトルのグループのクォータについてを説明します。</span><span class="sxs-lookup"><span data-stu-id="b5615-105">Contains quota information about a title group.</span></span> 
<a id="ID4EN"></a>

 
## <a name="quotainfo"></a><span data-ttu-id="b5615-106">QuotaInfo</span><span class="sxs-lookup"><span data-stu-id="b5615-106">quotaInfo</span></span>
 
<span data-ttu-id="b5615-107">QuotaInfo オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="b5615-107">The quotaInfo object has the following specifications.</span></span>
 
<span data-ttu-id="b5615-108">グローバル ストレージ</span><span class="sxs-lookup"><span data-stu-id="b5615-108">For global storage</span></span>
 
| <span data-ttu-id="b5615-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="b5615-109">Member</span></span>| <span data-ttu-id="b5615-110">種類</span><span class="sxs-lookup"><span data-stu-id="b5615-110">Type</span></span>| <span data-ttu-id="b5615-111">説明</span><span class="sxs-lookup"><span data-stu-id="b5615-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="b5615-112">quotaBytes</span><span class="sxs-lookup"><span data-stu-id="b5615-112">quotaBytes</span></span>| <span data-ttu-id="b5615-113">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="b5615-113">32-bit signed integer</span></span> | <span data-ttu-id="b5615-114">タイトルに使用できるバイトの最大数。</span><span class="sxs-lookup"><span data-stu-id="b5615-114">Maximum number of bytes usable by the title.</span></span>| 
| <span data-ttu-id="b5615-115">usedBytes</span><span class="sxs-lookup"><span data-stu-id="b5615-115">usedBytes</span></span>| <span data-ttu-id="b5615-116">32 ビット符号付き整数</span><span class="sxs-lookup"><span data-stu-id="b5615-116">32-bit signed integer</span></span> | <span data-ttu-id="b5615-117">タイトルに使用されるバイト数。</span><span class="sxs-lookup"><span data-stu-id="b5615-117">Number of bytes used by the title.</span></span>| 
  
<a id="ID4EXB"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="b5615-118">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="b5615-118">Sample JSON syntax</span></span>
 
<span data-ttu-id="b5615-119">次の例では、グローバル ストレージの応答を示します。</span><span class="sxs-lookup"><span data-stu-id="b5615-119">The following example shows the response for global storage:</span></span>
 

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

 
## <a name="see-also"></a><span data-ttu-id="b5615-120">関連項目</span><span class="sxs-lookup"><span data-stu-id="b5615-120">See also</span></span>
 
<a id="ID4EEC"></a>

 
##### <a name="parent"></a><span data-ttu-id="b5615-121">Parent</span><span class="sxs-lookup"><span data-stu-id="b5615-121">Parent</span></span> 

[<span data-ttu-id="b5615-122">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="b5615-122">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   