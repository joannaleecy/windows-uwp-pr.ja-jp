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
ms.sourcegitcommit: a160b91a554f8352de963d9fa37f7df89f8a0e23
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/22/2018
ms.locfileid: "4129030"
---
# <a name="requirement-json"></a><span data-ttu-id="f1665-104">Requirement (JSON)</span><span class="sxs-lookup"><span data-stu-id="f1665-104">Requirement (JSON)</span></span>
<span data-ttu-id="f1665-105">実績とそれらに対応するため、ユーザーは、どのくらいのロック解除条件。</span><span class="sxs-lookup"><span data-stu-id="f1665-105">The unlock criteria for the Achievement and how far the user is toward meeting them.</span></span> 
<a id="ID4EN"></a>

 
## <a name="requirement"></a><span data-ttu-id="f1665-106">要件</span><span class="sxs-lookup"><span data-stu-id="f1665-106">Requirement</span></span>
 
<span data-ttu-id="f1665-107">要件のオブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f1665-107">The Requirement object has the following specification.</span></span>
 
| <span data-ttu-id="f1665-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="f1665-108">Member</span></span>| <span data-ttu-id="f1665-109">種類</span><span class="sxs-lookup"><span data-stu-id="f1665-109">Type</span></span>| <span data-ttu-id="f1665-110">説明</span><span class="sxs-lookup"><span data-stu-id="f1665-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f1665-111">id</span><span class="sxs-lookup"><span data-stu-id="f1665-111">id</span></span>| <span data-ttu-id="f1665-112">string</span><span class="sxs-lookup"><span data-stu-id="f1665-112">string</span></span>| <span data-ttu-id="f1665-113">要件の ID です。</span><span class="sxs-lookup"><span data-stu-id="f1665-113">The ID of the requirement.</span></span>| 
| <span data-ttu-id="f1665-114">現在の</span><span class="sxs-lookup"><span data-stu-id="f1665-114">current</span></span>| <span data-ttu-id="f1665-115">string</span><span class="sxs-lookup"><span data-stu-id="f1665-115">string</span></span>| <span data-ttu-id="f1665-116">要件に向けた進行状況の現在の値。</span><span class="sxs-lookup"><span data-stu-id="f1665-116">The current value of progression toward the requirement.</span></span>| 
| <span data-ttu-id="f1665-117">ターゲット</span><span class="sxs-lookup"><span data-stu-id="f1665-117">target</span></span>| <span data-ttu-id="f1665-118">string</span><span class="sxs-lookup"><span data-stu-id="f1665-118">string</span></span>| <span data-ttu-id="f1665-119">要件のターゲットの値。</span><span class="sxs-lookup"><span data-stu-id="f1665-119">The target value of the requirement.</span></span>| 
| <span data-ttu-id="f1665-120">入力</span><span class="sxs-lookup"><span data-stu-id="f1665-120">operationType</span></span>| <span data-ttu-id="f1665-121">string</span><span class="sxs-lookup"><span data-stu-id="f1665-121">string</span></span>| <span data-ttu-id="f1665-122">要件の操作の種類。</span><span class="sxs-lookup"><span data-stu-id="f1665-122">The operation type of the requirement.</span></span> <span data-ttu-id="f1665-123">有効な値は、合計、最小、最大値はします。</span><span class="sxs-lookup"><span data-stu-id="f1665-123">Valid values are Sum, Minimum, Maximum.</span></span>| 
| <span data-ttu-id="f1665-124">ruleParticipationType</span><span class="sxs-lookup"><span data-stu-id="f1665-124">ruleParticipationType</span></span>| <span data-ttu-id="f1665-125">string</span><span class="sxs-lookup"><span data-stu-id="f1665-125">string</span></span>| <span data-ttu-id="f1665-126">要件の参加の種類。</span><span class="sxs-lookup"><span data-stu-id="f1665-126">The participation type of the requirement.</span></span> <span data-ttu-id="f1665-127">有効な値は、個人のグループです。</span><span class="sxs-lookup"><span data-stu-id="f1665-127">Valid values are Individual, Group.</span></span>| 
  
<a id="ID4ETC"></a>

 
## <a name="see-also"></a><span data-ttu-id="f1665-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="f1665-128">See also</span></span>
 
<a id="ID4EVC"></a>

 
##### <a name="parent"></a><span data-ttu-id="f1665-129">Parent</span><span class="sxs-lookup"><span data-stu-id="f1665-129">Parent</span></span> 

[<span data-ttu-id="f1665-130">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f1665-130">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   