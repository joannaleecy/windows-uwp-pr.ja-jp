---
title: UserTitle (JSON)
assetID: 3e5767af-5704-8463-696b-42a7d2a1e231
permalink: en-us/docs/xboxlive/rest/json-usertitlev2.html
author: KevinAsgari
description: " UserTitle (JSON)"
ms.author: kevinasg
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 1735b7fcedd358c290b289b97417e0ea3a6c090b
ms.sourcegitcommit: 93c0a60cf531c7d9fe7b00e7cf78df86906f9d6e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/23/2018
ms.locfileid: "7572149"
---
# <a name="usertitle-json"></a><span data-ttu-id="75ee4-104">UserTitle (JSON)</span><span class="sxs-lookup"><span data-stu-id="75ee4-104">UserTitle (JSON)</span></span>
<span data-ttu-id="75ee4-105">タイトルのユーザー データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="75ee4-105">Contains user title data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a><span data-ttu-id="75ee4-106">UserTitle</span><span class="sxs-lookup"><span data-stu-id="75ee4-106">UserTitle</span></span>
 
<span data-ttu-id="75ee4-107">UserTitle オブジェクトでは、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="75ee4-107">The UserTitle object has the following specification.</span></span> <span data-ttu-id="75ee4-108">すべてのプロパティは、必要があります。</span><span class="sxs-lookup"><span data-stu-id="75ee4-108">All properties are required.</span></span>
 
| <span data-ttu-id="75ee4-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="75ee4-109">Member</span></span>| <span data-ttu-id="75ee4-110">種類</span><span class="sxs-lookup"><span data-stu-id="75ee4-110">Type</span></span>| <span data-ttu-id="75ee4-111">説明</span><span class="sxs-lookup"><span data-stu-id="75ee4-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="75ee4-112">lastUnlock</span><span class="sxs-lookup"><span data-stu-id="75ee4-112">lastUnlock</span></span>| <span data-ttu-id="75ee4-113">DateTime</span><span class="sxs-lookup"><span data-stu-id="75ee4-113">DateTime</span></span>| <span data-ttu-id="75ee4-114">実績を獲得した最後の時刻。</span><span class="sxs-lookup"><span data-stu-id="75ee4-114">The time an achievement was last earned.</span></span>| 
| <span data-ttu-id="75ee4-115">titleId</span><span class="sxs-lookup"><span data-stu-id="75ee4-115">titleId</span></span>| <span data-ttu-id="75ee4-116">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="75ee4-116">32-bit unsigned integer</span></span>| <span data-ttu-id="75ee4-117">タイトルの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="75ee4-117">The unique identifier for the title.</span></span>| 
| <span data-ttu-id="75ee4-118">titleVersion</span><span class="sxs-lookup"><span data-stu-id="75ee4-118">titleVersion</span></span>| <span data-ttu-id="75ee4-119">string</span><span class="sxs-lookup"><span data-stu-id="75ee4-119">string</span></span>| <span data-ttu-id="75ee4-120">タイトルのバージョンです。</span><span class="sxs-lookup"><span data-stu-id="75ee4-120">The version of the title.</span></span>| 
| <span data-ttu-id="75ee4-121">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="75ee4-121">serviceConfigId</span></span>| <span data-ttu-id="75ee4-122">string</span><span class="sxs-lookup"><span data-stu-id="75ee4-122">string</span></span>| <span data-ttu-id="75ee4-123">タイトルに関連付けられているプライマリー サービス構成のセットの ID です。</span><span class="sxs-lookup"><span data-stu-id="75ee4-123">ID of the primary service config set associated with the title.</span></span>| 
| <span data-ttu-id="75ee4-124">タイトル</span><span class="sxs-lookup"><span data-stu-id="75ee4-124">titleType</span></span>| <span data-ttu-id="75ee4-125">string</span><span class="sxs-lookup"><span data-stu-id="75ee4-125">string</span></span>| <span data-ttu-id="75ee4-126">タイトルの種類。</span><span class="sxs-lookup"><span data-stu-id="75ee4-126">The title type.</span></span>| 
| <span data-ttu-id="75ee4-127">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="75ee4-127">platform</span></span>| <span data-ttu-id="75ee4-128">string</span><span class="sxs-lookup"><span data-stu-id="75ee4-128">string</span></span>| <span data-ttu-id="75ee4-129">サポートされているプラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="75ee4-129">The supported platform.</span></span>| 
| <span data-ttu-id="75ee4-130">name</span><span class="sxs-lookup"><span data-stu-id="75ee4-130">name</span></span>| <span data-ttu-id="75ee4-131">string</span><span class="sxs-lookup"><span data-stu-id="75ee4-131">string</span></span>| <span data-ttu-id="75ee4-132">このタイトルのテキストの名前。</span><span class="sxs-lookup"><span data-stu-id="75ee4-132">The text name of this title.</span></span> <span data-ttu-id="75ee4-133">最大長 22 です。</span><span class="sxs-lookup"><span data-stu-id="75ee4-133">Maximum length 22.</span></span>| 
| <span data-ttu-id="75ee4-134">earnedAchievements</span><span class="sxs-lookup"><span data-stu-id="75ee4-134">earnedAchievements</span></span>| <span data-ttu-id="75ee4-135">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="75ee4-135">32-bit unsigned integer</span></span>| <span data-ttu-id="75ee4-136">実績の数は、ロック解除した実績を含む、タイトルの獲得し、チャレンジを正常に完了します。</span><span class="sxs-lookup"><span data-stu-id="75ee4-136">The number of achievements earned for the title, including unlocked achievements and successfully completed challenges.</span></span>| 
| <span data-ttu-id="75ee4-137">currentGamerscore</span><span class="sxs-lookup"><span data-stu-id="75ee4-137">currentGamerscore</span></span>| <span data-ttu-id="75ee4-138">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="75ee4-138">32-bit unsigned integer</span></span>| <span data-ttu-id="75ee4-139">このユーザーがこのタイトルでの原因の合計ゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="75ee4-139">The total gamerscore this user has earned in this title.</span></span>| 
| <span data-ttu-id="75ee4-140">maxGamerscore</span><span class="sxs-lookup"><span data-stu-id="75ee4-140">maxGamerscore</span></span>| <span data-ttu-id="75ee4-141">32 ビットの符号なし整数</span><span class="sxs-lookup"><span data-stu-id="75ee4-141">32-bit unsigned integer</span></span>| <span data-ttu-id="75ee4-142">このタイトルの合計の考えられるゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="75ee4-142">The total possible gamerscore for this title.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a><span data-ttu-id="75ee4-143">関連項目</span><span class="sxs-lookup"><span data-stu-id="75ee4-143">See also</span></span>
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a><span data-ttu-id="75ee4-144">Parent</span><span class="sxs-lookup"><span data-stu-id="75ee4-144">Parent</span></span> 

[<span data-ttu-id="75ee4-145">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="75ee4-145">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   