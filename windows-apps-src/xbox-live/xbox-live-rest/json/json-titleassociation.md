---
title: TitleAssociation (JSON)
assetID: 05f4edbb-cc3d-c17d-0979-aac9e44a4988
permalink: en-us/docs/xboxlive/rest/json-titleassociation.html
description: " TitleAssociation (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 21a583e7556f98b827a63de3948f43d76f25c907
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57592897"
---
# <a name="titleassociation-json"></a><span data-ttu-id="cadcb-104">TitleAssociation (JSON)</span><span class="sxs-lookup"><span data-stu-id="cadcb-104">TitleAssociation (JSON)</span></span>
<span data-ttu-id="cadcb-105">実績に関連付けられているタイトルです。</span><span class="sxs-lookup"><span data-stu-id="cadcb-105">A title that is associated with the achievement.</span></span> 
<a id="ID4EN"></a>

 
## <a name="titleassociation"></a><span data-ttu-id="cadcb-106">TitleAssociation</span><span class="sxs-lookup"><span data-stu-id="cadcb-106">TitleAssociation</span></span>
 
<span data-ttu-id="cadcb-107">TitleAssociation オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="cadcb-107">The TitleAssociation object has the following specification.</span></span>
 
| <span data-ttu-id="cadcb-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="cadcb-108">Member</span></span>| <span data-ttu-id="cadcb-109">種類</span><span class="sxs-lookup"><span data-stu-id="cadcb-109">Type</span></span>| <span data-ttu-id="cadcb-110">説明</span><span class="sxs-lookup"><span data-stu-id="cadcb-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="cadcb-111">name</span><span class="sxs-lookup"><span data-stu-id="cadcb-111">name</span></span>| <span data-ttu-id="cadcb-112">string</span><span class="sxs-lookup"><span data-stu-id="cadcb-112">string</span></span>| <span data-ttu-id="cadcb-113">コンテンツのローカライズされた名前。</span><span class="sxs-lookup"><span data-stu-id="cadcb-113">The localized name of the content.</span></span>| 
| <span data-ttu-id="cadcb-114">id</span><span class="sxs-lookup"><span data-stu-id="cadcb-114">id</span></span>| <span data-ttu-id="cadcb-115">string</span><span class="sxs-lookup"><span data-stu-id="cadcb-115">string</span></span>| <span data-ttu-id="cadcb-116">タイトル (32 ビット符号なし整数、10 進数で返される) Id。</span><span class="sxs-lookup"><span data-stu-id="cadcb-116">The titleId (32-bit unsigned integer, returned in decimal).</span></span>| 
| <span data-ttu-id="cadcb-117">version</span><span class="sxs-lookup"><span data-stu-id="cadcb-117">version</span></span>| <span data-ttu-id="cadcb-118">string</span><span class="sxs-lookup"><span data-stu-id="cadcb-118">string</span></span>| <span data-ttu-id="cadcb-119">(該当する場合) に関連付けられているタイトルの特定のバージョン。</span><span class="sxs-lookup"><span data-stu-id="cadcb-119">Specific version of the associated title (if appropriate).</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="cadcb-120">サンプルの JSON の構文</span><span class="sxs-lookup"><span data-stu-id="cadcb-120">Sample JSON syntax</span></span>
 

```json
{
  "name":"Microsoft Achievements Sample",
  "id":3051199919,
  "version":"abc"
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="cadcb-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="cadcb-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="cadcb-122">Parent</span><span class="sxs-lookup"><span data-stu-id="cadcb-122">Parent</span></span> 

[<span data-ttu-id="cadcb-123">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="cadcb-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   