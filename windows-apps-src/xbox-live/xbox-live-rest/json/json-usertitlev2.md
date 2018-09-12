---
title: ユーザーのタイトル (JSON)
assetID: 3e5767af-5704-8463-696b-42a7d2a1e231
permalink: en-us/docs/xboxlive/rest/json-usertitlev2.html
author: KevinAsgari
description: " ユーザーのタイトル (JSON)"
ms.author: kevinasg
ms.date: 20-12-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 068ae15566d73dfc4610f8540972b7e80329de8e
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3935348"
---
# <a name="usertitle-json"></a><span data-ttu-id="f0b86-104">ユーザーのタイトル (JSON)</span><span class="sxs-lookup"><span data-stu-id="f0b86-104">UserTitle (JSON)</span></span>
<span data-ttu-id="f0b86-105">タイトルのユーザー データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f0b86-105">Contains user title data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a><span data-ttu-id="f0b86-106">ユーザー タイトル</span><span class="sxs-lookup"><span data-stu-id="f0b86-106">UserTitle</span></span>
 
<span data-ttu-id="f0b86-107">ユーザー タイトル オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="f0b86-107">The UserTitle object has the following specification.</span></span> <span data-ttu-id="f0b86-108">すべてのプロパティは、必要があります。</span><span class="sxs-lookup"><span data-stu-id="f0b86-108">All properties are required.</span></span>
 
| <span data-ttu-id="f0b86-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="f0b86-109">Member</span></span>| <span data-ttu-id="f0b86-110">種類</span><span class="sxs-lookup"><span data-stu-id="f0b86-110">Type</span></span>| <span data-ttu-id="f0b86-111">説明</span><span class="sxs-lookup"><span data-stu-id="f0b86-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="f0b86-112">lastUnlock</span><span class="sxs-lookup"><span data-stu-id="f0b86-112">lastUnlock</span></span>| <span data-ttu-id="f0b86-113">DateTime</span><span class="sxs-lookup"><span data-stu-id="f0b86-113">DateTime</span></span>| <span data-ttu-id="f0b86-114">実績を獲得した最後の時刻。</span><span class="sxs-lookup"><span data-stu-id="f0b86-114">The time an achievement was last earned.</span></span>| 
| <span data-ttu-id="f0b86-115">titleId</span><span class="sxs-lookup"><span data-stu-id="f0b86-115">titleId</span></span>| <span data-ttu-id="f0b86-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f0b86-116">32-bit unsigned integer</span></span>| <span data-ttu-id="f0b86-117">タイトルの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="f0b86-117">The unique identifier for the title.</span></span>| 
| <span data-ttu-id="f0b86-118">titleVersion</span><span class="sxs-lookup"><span data-stu-id="f0b86-118">titleVersion</span></span>| <span data-ttu-id="f0b86-119">string</span><span class="sxs-lookup"><span data-stu-id="f0b86-119">string</span></span>| <span data-ttu-id="f0b86-120">タイトルのバージョンです。</span><span class="sxs-lookup"><span data-stu-id="f0b86-120">The version of the title.</span></span>| 
| <span data-ttu-id="f0b86-121">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="f0b86-121">serviceConfigId</span></span>| <span data-ttu-id="f0b86-122">string</span><span class="sxs-lookup"><span data-stu-id="f0b86-122">string</span></span>| <span data-ttu-id="f0b86-123">タイトルに関連付けられているプライマリ サービス構成のセットの ID です。</span><span class="sxs-lookup"><span data-stu-id="f0b86-123">ID of the primary service config set associated with the title.</span></span>| 
| <span data-ttu-id="f0b86-124">タイトル</span><span class="sxs-lookup"><span data-stu-id="f0b86-124">titleType</span></span>| <span data-ttu-id="f0b86-125">string</span><span class="sxs-lookup"><span data-stu-id="f0b86-125">string</span></span>| <span data-ttu-id="f0b86-126">タイトルの種類。</span><span class="sxs-lookup"><span data-stu-id="f0b86-126">The title type.</span></span>| 
| <span data-ttu-id="f0b86-127">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="f0b86-127">platform</span></span>| <span data-ttu-id="f0b86-128">string</span><span class="sxs-lookup"><span data-stu-id="f0b86-128">string</span></span>| <span data-ttu-id="f0b86-129">サポートされているプラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="f0b86-129">The supported platform.</span></span>| 
| <span data-ttu-id="f0b86-130">name</span><span class="sxs-lookup"><span data-stu-id="f0b86-130">name</span></span>| <span data-ttu-id="f0b86-131">string</span><span class="sxs-lookup"><span data-stu-id="f0b86-131">string</span></span>| <span data-ttu-id="f0b86-132">このタイトルのテキストの名前。</span><span class="sxs-lookup"><span data-stu-id="f0b86-132">The text name of this title.</span></span> <span data-ttu-id="f0b86-133">最大長 22 です。</span><span class="sxs-lookup"><span data-stu-id="f0b86-133">Maximum length 22.</span></span>| 
| <span data-ttu-id="f0b86-134">earnedAchievements</span><span class="sxs-lookup"><span data-stu-id="f0b86-134">earnedAchievements</span></span>| <span data-ttu-id="f0b86-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f0b86-135">32-bit unsigned integer</span></span>| <span data-ttu-id="f0b86-136">実績の数は、ロック解除した実績を含む、タイトルの獲得し、課題が正常に完了します。</span><span class="sxs-lookup"><span data-stu-id="f0b86-136">The number of achievements earned for the title, including unlocked achievements and successfully completed challenges.</span></span>| 
| <span data-ttu-id="f0b86-137">currentGamerscore</span><span class="sxs-lookup"><span data-stu-id="f0b86-137">currentGamerscore</span></span>| <span data-ttu-id="f0b86-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f0b86-138">32-bit unsigned integer</span></span>| <span data-ttu-id="f0b86-139">このユーザーがこのタイトルでの原因の合計ゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="f0b86-139">The total gamerscore this user has earned in this title.</span></span>| 
| <span data-ttu-id="f0b86-140">maxGamerscore</span><span class="sxs-lookup"><span data-stu-id="f0b86-140">maxGamerscore</span></span>| <span data-ttu-id="f0b86-141">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="f0b86-141">32-bit unsigned integer</span></span>| <span data-ttu-id="f0b86-142">このタイトルの合計の可能なゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="f0b86-142">The total possible gamerscore for this title.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a><span data-ttu-id="f0b86-143">関連項目</span><span class="sxs-lookup"><span data-stu-id="f0b86-143">See also</span></span>
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a><span data-ttu-id="f0b86-144">Parent</span><span class="sxs-lookup"><span data-stu-id="f0b86-144">Parent</span></span> 

[<span data-ttu-id="f0b86-145">JavaScript オブジェクト Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="f0b86-145">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   