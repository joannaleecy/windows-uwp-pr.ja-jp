---
title: UserTitle (JSON)
assetID: 3e5767af-5704-8463-696b-42a7d2a1e231
permalink: en-us/docs/xboxlive/rest/json-usertitlev2.html
description: " UserTitle (JSON)"
ms.date: 10/12/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 33901a5bde25fd17072c2b45d587a33209424378
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/02/2018
ms.locfileid: "8330543"
---
# <a name="usertitle-json"></a><span data-ttu-id="fe7a5-104">UserTitle (JSON)</span><span class="sxs-lookup"><span data-stu-id="fe7a5-104">UserTitle (JSON)</span></span>
<span data-ttu-id="fe7a5-105">タイトルのユーザー データが含まれています。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-105">Contains user title data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a><span data-ttu-id="fe7a5-106">UserTitle</span><span class="sxs-lookup"><span data-stu-id="fe7a5-106">UserTitle</span></span>
 
<span data-ttu-id="fe7a5-107">UserTitle オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-107">The UserTitle object has the following specification.</span></span> <span data-ttu-id="fe7a5-108">すべてのプロパティは、必要があります。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-108">All properties are required.</span></span>
 
| <span data-ttu-id="fe7a5-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="fe7a5-109">Member</span></span>| <span data-ttu-id="fe7a5-110">種類</span><span class="sxs-lookup"><span data-stu-id="fe7a5-110">Type</span></span>| <span data-ttu-id="fe7a5-111">説明</span><span class="sxs-lookup"><span data-stu-id="fe7a5-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="fe7a5-112">lastUnlock</span><span class="sxs-lookup"><span data-stu-id="fe7a5-112">lastUnlock</span></span>| <span data-ttu-id="fe7a5-113">DateTime</span><span class="sxs-lookup"><span data-stu-id="fe7a5-113">DateTime</span></span>| <span data-ttu-id="fe7a5-114">実績を獲得した最後の時刻。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-114">The time an achievement was last earned.</span></span>| 
| <span data-ttu-id="fe7a5-115">titleId</span><span class="sxs-lookup"><span data-stu-id="fe7a5-115">titleId</span></span>| <span data-ttu-id="fe7a5-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fe7a5-116">32-bit unsigned integer</span></span>| <span data-ttu-id="fe7a5-117">タイトルの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-117">The unique identifier for the title.</span></span>| 
| <span data-ttu-id="fe7a5-118">titleVersion</span><span class="sxs-lookup"><span data-stu-id="fe7a5-118">titleVersion</span></span>| <span data-ttu-id="fe7a5-119">string</span><span class="sxs-lookup"><span data-stu-id="fe7a5-119">string</span></span>| <span data-ttu-id="fe7a5-120">タイトルのバージョン。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-120">The version of the title.</span></span>| 
| <span data-ttu-id="fe7a5-121">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="fe7a5-121">serviceConfigId</span></span>| <span data-ttu-id="fe7a5-122">string</span><span class="sxs-lookup"><span data-stu-id="fe7a5-122">string</span></span>| <span data-ttu-id="fe7a5-123">タイトルに関連付けられているプライマリ サービス構成のセットの ID です。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-123">ID of the primary service config set associated with the title.</span></span>| 
| <span data-ttu-id="fe7a5-124">タイトル</span><span class="sxs-lookup"><span data-stu-id="fe7a5-124">titleType</span></span>| <span data-ttu-id="fe7a5-125">string</span><span class="sxs-lookup"><span data-stu-id="fe7a5-125">string</span></span>| <span data-ttu-id="fe7a5-126">タイトルの種類。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-126">The title type.</span></span>| 
| <span data-ttu-id="fe7a5-127">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="fe7a5-127">platform</span></span>| <span data-ttu-id="fe7a5-128">string</span><span class="sxs-lookup"><span data-stu-id="fe7a5-128">string</span></span>| <span data-ttu-id="fe7a5-129">サポートされているプラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-129">The supported platform.</span></span>| 
| <span data-ttu-id="fe7a5-130">name</span><span class="sxs-lookup"><span data-stu-id="fe7a5-130">name</span></span>| <span data-ttu-id="fe7a5-131">string</span><span class="sxs-lookup"><span data-stu-id="fe7a5-131">string</span></span>| <span data-ttu-id="fe7a5-132">このタイトルのテキストの名前。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-132">The text name of this title.</span></span> <span data-ttu-id="fe7a5-133">最大長 22 です。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-133">Maximum length 22.</span></span>| 
| <span data-ttu-id="fe7a5-134">earnedAchievements</span><span class="sxs-lookup"><span data-stu-id="fe7a5-134">earnedAchievements</span></span>| <span data-ttu-id="fe7a5-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fe7a5-135">32-bit unsigned integer</span></span>| <span data-ttu-id="fe7a5-136">実績の数は、ロック解除した実績を含む、タイトルの獲得し、課題が正常に完了します。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-136">The number of achievements earned for the title, including unlocked achievements and successfully completed challenges.</span></span>| 
| <span data-ttu-id="fe7a5-137">currentGamerscore</span><span class="sxs-lookup"><span data-stu-id="fe7a5-137">currentGamerscore</span></span>| <span data-ttu-id="fe7a5-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fe7a5-138">32-bit unsigned integer</span></span>| <span data-ttu-id="fe7a5-139">このユーザーがこのタイトルでの原因の合計ゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-139">The total gamerscore this user has earned in this title.</span></span>| 
| <span data-ttu-id="fe7a5-140">maxGamerscore</span><span class="sxs-lookup"><span data-stu-id="fe7a5-140">maxGamerscore</span></span>| <span data-ttu-id="fe7a5-141">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="fe7a5-141">32-bit unsigned integer</span></span>| <span data-ttu-id="fe7a5-142">このタイトルの合計の可能なゲーマー スコア。</span><span class="sxs-lookup"><span data-stu-id="fe7a5-142">The total possible gamerscore for this title.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a><span data-ttu-id="fe7a5-143">関連項目</span><span class="sxs-lookup"><span data-stu-id="fe7a5-143">See also</span></span>
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a><span data-ttu-id="fe7a5-144">Parent</span><span class="sxs-lookup"><span data-stu-id="fe7a5-144">Parent</span></span> 

[<span data-ttu-id="fe7a5-145">JavaScript Object Notation (JSON) オブジェクト リファレンス</span><span class="sxs-lookup"><span data-stu-id="fe7a5-145">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   