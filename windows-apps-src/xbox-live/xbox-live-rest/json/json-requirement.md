---
title: Requirement (JSON)
assetID: 74faee8d-42e3-cfcf-22b3-9dcd9227de6b
permalink: en-us/docs/xboxlive/rest/json-requirement.html
author: KevinAsgari
description: " Requirement (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: f13edfbe5858a5fc3c4f24d22b31eb25f8386e25
ms.sourcegitcommit: 4b97117d3aff38db89d560502a3c372f12bb6ed5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5441245"
---
# <a name="requirement-json"></a><span data-ttu-id="9b5a9-104">Requirement (JSON)</span><span class="sxs-lookup"><span data-stu-id="9b5a9-104">Requirement (JSON)</span></span>
<span data-ttu-id="9b5a9-105">実績とそれらに対応するため、ユーザーは、どのくらいのロック解除基準します。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-105">The unlock criteria for the Achievement and how far the user is toward meeting them.</span></span> 
<a id="ID4EN"></a>

 
## <a name="requirement"></a><span data-ttu-id="9b5a9-106">要件</span><span class="sxs-lookup"><span data-stu-id="9b5a9-106">Requirement</span></span>
 
<span data-ttu-id="9b5a9-107">要件オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-107">The Requirement object has the following specification.</span></span>
 
| <span data-ttu-id="9b5a9-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="9b5a9-108">Member</span></span>| <span data-ttu-id="9b5a9-109">種類</span><span class="sxs-lookup"><span data-stu-id="9b5a9-109">Type</span></span>| <span data-ttu-id="9b5a9-110">説明</span><span class="sxs-lookup"><span data-stu-id="9b5a9-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="9b5a9-111">id</span><span class="sxs-lookup"><span data-stu-id="9b5a9-111">id</span></span>| <span data-ttu-id="9b5a9-112">string</span><span class="sxs-lookup"><span data-stu-id="9b5a9-112">string</span></span>| <span data-ttu-id="9b5a9-113">要件の ID です。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-113">The ID of the requirement.</span></span>| 
| <span data-ttu-id="9b5a9-114">現在の</span><span class="sxs-lookup"><span data-stu-id="9b5a9-114">current</span></span>| <span data-ttu-id="9b5a9-115">string</span><span class="sxs-lookup"><span data-stu-id="9b5a9-115">string</span></span>| <span data-ttu-id="9b5a9-116">要件に進行状況の現在の値。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-116">The current value of progression toward the requirement.</span></span>| 
| <span data-ttu-id="9b5a9-117">ターゲット</span><span class="sxs-lookup"><span data-stu-id="9b5a9-117">target</span></span>| <span data-ttu-id="9b5a9-118">string</span><span class="sxs-lookup"><span data-stu-id="9b5a9-118">string</span></span>| <span data-ttu-id="9b5a9-119">要件のターゲットの値。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-119">The target value of the requirement.</span></span>| 
| <span data-ttu-id="9b5a9-120">入力</span><span class="sxs-lookup"><span data-stu-id="9b5a9-120">operationType</span></span>| <span data-ttu-id="9b5a9-121">string</span><span class="sxs-lookup"><span data-stu-id="9b5a9-121">string</span></span>| <span data-ttu-id="9b5a9-122">要件の操作の種類。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-122">The operation type of the requirement.</span></span> <span data-ttu-id="9b5a9-123">有効な値は、合計、最小、最大値はします。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-123">Valid values are Sum, Minimum, Maximum.</span></span>| 
| <span data-ttu-id="9b5a9-124">ruleParticipationType</span><span class="sxs-lookup"><span data-stu-id="9b5a9-124">ruleParticipationType</span></span>| <span data-ttu-id="9b5a9-125">string</span><span class="sxs-lookup"><span data-stu-id="9b5a9-125">string</span></span>| <span data-ttu-id="9b5a9-126">要件の参加の種類。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-126">The participation type of the requirement.</span></span> <span data-ttu-id="9b5a9-127">有効な値は、ユーザー、グループです。</span><span class="sxs-lookup"><span data-stu-id="9b5a9-127">Valid values are Individual, Group.</span></span>| 
  
<a id="ID4ETC"></a>

 
## <a name="see-also"></a><span data-ttu-id="9b5a9-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="9b5a9-128">See also</span></span>
 
<a id="ID4EVC"></a>

 
##### <a name="parent"></a><span data-ttu-id="9b5a9-129">Parent</span><span class="sxs-lookup"><span data-stu-id="9b5a9-129">Parent</span></span> 

[<span data-ttu-id="9b5a9-130">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="9b5a9-130">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   