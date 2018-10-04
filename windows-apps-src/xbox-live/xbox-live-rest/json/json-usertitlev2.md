---
title: UserTitle (JSON)
assetID: 3e5767af-5704-8463-696b-42a7d2a1e231
permalink: en-us/docs/xboxlive/rest/json-usertitlev2.html
author: KevinAsgari
description: " UserTitle (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 068ae15566d73dfc4610f8540972b7e80329de8e
ms.sourcegitcommit: e6daa7ff878f2f0c7015aca9787e7f2730abcfbf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4317995"
---
# <a name="usertitle-json"></a><span data-ttu-id="88472-104">UserTitle (JSON)</span><span class="sxs-lookup"><span data-stu-id="88472-104">UserTitle (JSON)</span></span>
<span data-ttu-id="88472-105">タイトルのユーザー データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="88472-105">Contains user title data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a><span data-ttu-id="88472-106">ユーザー タイトル</span><span class="sxs-lookup"><span data-stu-id="88472-106">UserTitle</span></span>
 
<span data-ttu-id="88472-107">ユーザー タイトル オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="88472-107">The UserTitle object has the following specification.</span></span> <span data-ttu-id="88472-108">すべてのプロパティは、必要があります。</span><span class="sxs-lookup"><span data-stu-id="88472-108">All properties are required.</span></span>
 
| <span data-ttu-id="88472-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="88472-109">Member</span></span>| <span data-ttu-id="88472-110">種類</span><span class="sxs-lookup"><span data-stu-id="88472-110">Type</span></span>| <span data-ttu-id="88472-111">説明</span><span class="sxs-lookup"><span data-stu-id="88472-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="88472-112">lastUnlock</span><span class="sxs-lookup"><span data-stu-id="88472-112">lastUnlock</span></span>| <span data-ttu-id="88472-113">DateTime</span><span class="sxs-lookup"><span data-stu-id="88472-113">DateTime</span></span>| <span data-ttu-id="88472-114">実績が最後に獲得した時刻。</span><span class="sxs-lookup"><span data-stu-id="88472-114">The time an achievement was last earned.</span></span>| 
| <span data-ttu-id="88472-115">titleId</span><span class="sxs-lookup"><span data-stu-id="88472-115">titleId</span></span>| <span data-ttu-id="88472-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="88472-116">32-bit unsigned integer</span></span>| <span data-ttu-id="88472-117">タイトルの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="88472-117">The unique identifier for the title.</span></span>| 
| <span data-ttu-id="88472-118">titleVersion</span><span class="sxs-lookup"><span data-stu-id="88472-118">titleVersion</span></span>| <span data-ttu-id="88472-119">string</span><span class="sxs-lookup"><span data-stu-id="88472-119">string</span></span>| <span data-ttu-id="88472-120">タイトルのバージョンです。</span><span class="sxs-lookup"><span data-stu-id="88472-120">The version of the title.</span></span>| 
| <span data-ttu-id="88472-121">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="88472-121">serviceConfigId</span></span>| <span data-ttu-id="88472-122">string</span><span class="sxs-lookup"><span data-stu-id="88472-122">string</span></span>| <span data-ttu-id="88472-123">タイトルに関連付けられているプライマリ サービス構成のセットの ID です。</span><span class="sxs-lookup"><span data-stu-id="88472-123">ID of the primary service config set associated with the title.</span></span>| 
| <span data-ttu-id="88472-124">タイトル</span><span class="sxs-lookup"><span data-stu-id="88472-124">titleType</span></span>| <span data-ttu-id="88472-125">string</span><span class="sxs-lookup"><span data-stu-id="88472-125">string</span></span>| <span data-ttu-id="88472-126">タイトルの種類。</span><span class="sxs-lookup"><span data-stu-id="88472-126">The title type.</span></span>| 
| <span data-ttu-id="88472-127">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="88472-127">platform</span></span>| <span data-ttu-id="88472-128">string</span><span class="sxs-lookup"><span data-stu-id="88472-128">string</span></span>| <span data-ttu-id="88472-129">サポートされているプラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="88472-129">The supported platform.</span></span>| 
| <span data-ttu-id="88472-130">name</span><span class="sxs-lookup"><span data-stu-id="88472-130">name</span></span>| <span data-ttu-id="88472-131">string</span><span class="sxs-lookup"><span data-stu-id="88472-131">string</span></span>| <span data-ttu-id="88472-132">このタイトルのテキストの名前。</span><span class="sxs-lookup"><span data-stu-id="88472-132">The text name of this title.</span></span> <span data-ttu-id="88472-133">最大長 22 です。</span><span class="sxs-lookup"><span data-stu-id="88472-133">Maximum length 22.</span></span>| 
| <span data-ttu-id="88472-134">earnedAchievements</span><span class="sxs-lookup"><span data-stu-id="88472-134">earnedAchievements</span></span>| <span data-ttu-id="88472-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="88472-135">32-bit unsigned integer</span></span>| <span data-ttu-id="88472-136">実績の数は、ロック解除した実績を含む、タイトルの獲得し、課題が正常に完了します。</span><span class="sxs-lookup"><span data-stu-id="88472-136">The number of achievements earned for the title, including unlocked achievements and successfully completed challenges.</span></span>| 
| <span data-ttu-id="88472-137">currentGamerscore</span><span class="sxs-lookup"><span data-stu-id="88472-137">currentGamerscore</span></span>| <span data-ttu-id="88472-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="88472-138">32-bit unsigned integer</span></span>| <span data-ttu-id="88472-139">このユーザーがこのタイトルでの原因の合計ゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="88472-139">The total gamerscore this user has earned in this title.</span></span>| 
| <span data-ttu-id="88472-140">maxGamerscore</span><span class="sxs-lookup"><span data-stu-id="88472-140">maxGamerscore</span></span>| <span data-ttu-id="88472-141">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="88472-141">32-bit unsigned integer</span></span>| <span data-ttu-id="88472-142">このタイトルの合計の考えられるゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="88472-142">The total possible gamerscore for this title.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a><span data-ttu-id="88472-143">関連項目</span><span class="sxs-lookup"><span data-stu-id="88472-143">See also</span></span>
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a><span data-ttu-id="88472-144">Parent</span><span class="sxs-lookup"><span data-stu-id="88472-144">Parent</span></span> 

[<span data-ttu-id="88472-145">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="88472-145">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   