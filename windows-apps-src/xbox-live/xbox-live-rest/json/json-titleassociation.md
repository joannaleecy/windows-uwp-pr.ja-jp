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
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8339607"
---
# <a name="titleassociation-json"></a><span data-ttu-id="ee917-104">TitleAssociation (JSON)</span><span class="sxs-lookup"><span data-stu-id="ee917-104">TitleAssociation (JSON)</span></span>
<span data-ttu-id="ee917-105">実績に関連付けられているタイトルです。</span><span class="sxs-lookup"><span data-stu-id="ee917-105">A title that is associated with the achievement.</span></span> 
<a id="ID4EN"></a>

 
## <a name="titleassociation"></a><span data-ttu-id="ee917-106">TitleAssociation</span><span class="sxs-lookup"><span data-stu-id="ee917-106">TitleAssociation</span></span>
 
<span data-ttu-id="ee917-107">TitleAssociation オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="ee917-107">The TitleAssociation object has the following specification.</span></span>
 
| <span data-ttu-id="ee917-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="ee917-108">Member</span></span>| <span data-ttu-id="ee917-109">種類</span><span class="sxs-lookup"><span data-stu-id="ee917-109">Type</span></span>| <span data-ttu-id="ee917-110">説明</span><span class="sxs-lookup"><span data-stu-id="ee917-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="ee917-111">name</span><span class="sxs-lookup"><span data-stu-id="ee917-111">name</span></span>| <span data-ttu-id="ee917-112">string</span><span class="sxs-lookup"><span data-stu-id="ee917-112">string</span></span>| <span data-ttu-id="ee917-113">コンテンツのローカライズされた名前です。</span><span class="sxs-lookup"><span data-stu-id="ee917-113">The localized name of the content.</span></span>| 
| <span data-ttu-id="ee917-114">id</span><span class="sxs-lookup"><span data-stu-id="ee917-114">id</span></span>| <span data-ttu-id="ee917-115">string</span><span class="sxs-lookup"><span data-stu-id="ee917-115">string</span></span>| <span data-ttu-id="ee917-116">タイトル Id (32 ビット符号なし整数、10 進数で返されます)。</span><span class="sxs-lookup"><span data-stu-id="ee917-116">The titleId (32-bit unsigned integer, returned in decimal).</span></span>| 
| <span data-ttu-id="ee917-117">version</span><span class="sxs-lookup"><span data-stu-id="ee917-117">version</span></span>| <span data-ttu-id="ee917-118">string</span><span class="sxs-lookup"><span data-stu-id="ee917-118">string</span></span>| <span data-ttu-id="ee917-119">(該当する場合) に関連付けられているタイトルの特定のバージョン。</span><span class="sxs-lookup"><span data-stu-id="ee917-119">Specific version of the associated title (if appropriate).</span></span>| 
  
<a id="ID4E4B"></a>

 
## <a name="sample-json-syntax"></a><span data-ttu-id="ee917-120">JSON 構文の例</span><span class="sxs-lookup"><span data-stu-id="ee917-120">Sample JSON syntax</span></span>
 

```json
{
  "name":"Microsoft Achievements Sample",
  "id":3051199919,
  "version":"abc"
}
    
```

  
<a id="ID4EGC"></a>

 
## <a name="see-also"></a><span data-ttu-id="ee917-121">関連項目</span><span class="sxs-lookup"><span data-stu-id="ee917-121">See also</span></span>
 
<a id="ID4EIC"></a>

 
##### <a name="parent"></a><span data-ttu-id="ee917-122">Parent</span><span class="sxs-lookup"><span data-stu-id="ee917-122">Parent</span></span> 

[<span data-ttu-id="ee917-123">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="ee917-123">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   