---
title: Requirement (JSON)
assetID: 74faee8d-42e3-cfcf-22b3-9dcd9227de6b
permalink: en-us/docs/xboxlive/rest/json-requirement.html
description: " Requirement (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 4e8ccd2d38c6683ef54ad1576f47a8d3e5197d4e
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8322592"
---
# <a name="requirement-json"></a><span data-ttu-id="16192-104">Requirement (JSON)</span><span class="sxs-lookup"><span data-stu-id="16192-104">Requirement (JSON)</span></span>
<span data-ttu-id="16192-105">実績とそれらに対応するため、ユーザーは、どのくらいのロック解除条件。</span><span class="sxs-lookup"><span data-stu-id="16192-105">The unlock criteria for the Achievement and how far the user is toward meeting them.</span></span> 
<a id="ID4EN"></a>

 
## <a name="requirement"></a><span data-ttu-id="16192-106">要件</span><span class="sxs-lookup"><span data-stu-id="16192-106">Requirement</span></span>
 
<span data-ttu-id="16192-107">要件オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="16192-107">The Requirement object has the following specification.</span></span>
 
| <span data-ttu-id="16192-108">メンバー</span><span class="sxs-lookup"><span data-stu-id="16192-108">Member</span></span>| <span data-ttu-id="16192-109">種類</span><span class="sxs-lookup"><span data-stu-id="16192-109">Type</span></span>| <span data-ttu-id="16192-110">説明</span><span class="sxs-lookup"><span data-stu-id="16192-110">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="16192-111">id</span><span class="sxs-lookup"><span data-stu-id="16192-111">id</span></span>| <span data-ttu-id="16192-112">string</span><span class="sxs-lookup"><span data-stu-id="16192-112">string</span></span>| <span data-ttu-id="16192-113">要件の ID です。</span><span class="sxs-lookup"><span data-stu-id="16192-113">The ID of the requirement.</span></span>| 
| <span data-ttu-id="16192-114">現在の</span><span class="sxs-lookup"><span data-stu-id="16192-114">current</span></span>| <span data-ttu-id="16192-115">string</span><span class="sxs-lookup"><span data-stu-id="16192-115">string</span></span>| <span data-ttu-id="16192-116">要件に向けた進行状況の現在の値。</span><span class="sxs-lookup"><span data-stu-id="16192-116">The current value of progression toward the requirement.</span></span>| 
| <span data-ttu-id="16192-117">ターゲット</span><span class="sxs-lookup"><span data-stu-id="16192-117">target</span></span>| <span data-ttu-id="16192-118">string</span><span class="sxs-lookup"><span data-stu-id="16192-118">string</span></span>| <span data-ttu-id="16192-119">要件のターゲットの値。</span><span class="sxs-lookup"><span data-stu-id="16192-119">The target value of the requirement.</span></span>| 
| <span data-ttu-id="16192-120">入力</span><span class="sxs-lookup"><span data-stu-id="16192-120">operationType</span></span>| <span data-ttu-id="16192-121">string</span><span class="sxs-lookup"><span data-stu-id="16192-121">string</span></span>| <span data-ttu-id="16192-122">要件の操作の種類。</span><span class="sxs-lookup"><span data-stu-id="16192-122">The operation type of the requirement.</span></span> <span data-ttu-id="16192-123">有効な値は、合計、最小、最大値はします。</span><span class="sxs-lookup"><span data-stu-id="16192-123">Valid values are Sum, Minimum, Maximum.</span></span>| 
| <span data-ttu-id="16192-124">ruleParticipationType</span><span class="sxs-lookup"><span data-stu-id="16192-124">ruleParticipationType</span></span>| <span data-ttu-id="16192-125">string</span><span class="sxs-lookup"><span data-stu-id="16192-125">string</span></span>| <span data-ttu-id="16192-126">要件の参加の種類。</span><span class="sxs-lookup"><span data-stu-id="16192-126">The participation type of the requirement.</span></span> <span data-ttu-id="16192-127">有効な値は、個人, グループです。</span><span class="sxs-lookup"><span data-stu-id="16192-127">Valid values are Individual, Group.</span></span>| 
  
<a id="ID4ETC"></a>

 
## <a name="see-also"></a><span data-ttu-id="16192-128">関連項目</span><span class="sxs-lookup"><span data-stu-id="16192-128">See also</span></span>
 
<a id="ID4EVC"></a>

 
##### <a name="parent"></a><span data-ttu-id="16192-129">Parent</span><span class="sxs-lookup"><span data-stu-id="16192-129">Parent</span></span> 

[<span data-ttu-id="16192-130">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="16192-130">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   