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
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623027"
---
# <a name="usertitle-json"></a><span data-ttu-id="d187f-104">UserTitle (JSON)</span><span class="sxs-lookup"><span data-stu-id="d187f-104">UserTitle (JSON)</span></span>
<span data-ttu-id="d187f-105">ユーザーのタイトルのデータが含まれています。</span><span class="sxs-lookup"><span data-stu-id="d187f-105">Contains user title data.</span></span> 
<a id="ID4EN"></a>

 
## <a name="usertitle"></a><span data-ttu-id="d187f-106">ユーザー タイトル</span><span class="sxs-lookup"><span data-stu-id="d187f-106">UserTitle</span></span>
 
<span data-ttu-id="d187f-107">ユーザー タイトル オブジェクトには、次の仕様があります。</span><span class="sxs-lookup"><span data-stu-id="d187f-107">The UserTitle object has the following specification.</span></span> <span data-ttu-id="d187f-108">すべてのプロパティが必要です。</span><span class="sxs-lookup"><span data-stu-id="d187f-108">All properties are required.</span></span>
 
| <span data-ttu-id="d187f-109">メンバー</span><span class="sxs-lookup"><span data-stu-id="d187f-109">Member</span></span>| <span data-ttu-id="d187f-110">種類</span><span class="sxs-lookup"><span data-stu-id="d187f-110">Type</span></span>| <span data-ttu-id="d187f-111">説明</span><span class="sxs-lookup"><span data-stu-id="d187f-111">Description</span></span>| 
| --- | --- | --- | 
| <span data-ttu-id="d187f-112">lastUnlock</span><span class="sxs-lookup"><span data-stu-id="d187f-112">lastUnlock</span></span>| <span data-ttu-id="d187f-113">DateTime</span><span class="sxs-lookup"><span data-stu-id="d187f-113">DateTime</span></span>| <span data-ttu-id="d187f-114">アチーブメントが獲得された最終時刻。</span><span class="sxs-lookup"><span data-stu-id="d187f-114">The time an achievement was last earned.</span></span>| 
| <span data-ttu-id="d187f-115">titleId</span><span class="sxs-lookup"><span data-stu-id="d187f-115">titleId</span></span>| <span data-ttu-id="d187f-116">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d187f-116">32-bit unsigned integer</span></span>| <span data-ttu-id="d187f-117">タイトルの一意の識別子。</span><span class="sxs-lookup"><span data-stu-id="d187f-117">The unique identifier for the title.</span></span>| 
| <span data-ttu-id="d187f-118">titleVersion</span><span class="sxs-lookup"><span data-stu-id="d187f-118">titleVersion</span></span>| <span data-ttu-id="d187f-119">string</span><span class="sxs-lookup"><span data-stu-id="d187f-119">string</span></span>| <span data-ttu-id="d187f-120">タイトルのバージョン。</span><span class="sxs-lookup"><span data-stu-id="d187f-120">The version of the title.</span></span>| 
| <span data-ttu-id="d187f-121">serviceConfigId</span><span class="sxs-lookup"><span data-stu-id="d187f-121">serviceConfigId</span></span>| <span data-ttu-id="d187f-122">string</span><span class="sxs-lookup"><span data-stu-id="d187f-122">string</span></span>| <span data-ttu-id="d187f-123">タイトルに関連付けられているプライマリ サービスの構成セットの ID。</span><span class="sxs-lookup"><span data-stu-id="d187f-123">ID of the primary service config set associated with the title.</span></span>| 
| <span data-ttu-id="d187f-124">タイトル</span><span class="sxs-lookup"><span data-stu-id="d187f-124">titleType</span></span>| <span data-ttu-id="d187f-125">string</span><span class="sxs-lookup"><span data-stu-id="d187f-125">string</span></span>| <span data-ttu-id="d187f-126">タイトルの種類。</span><span class="sxs-lookup"><span data-stu-id="d187f-126">The title type.</span></span>| 
| <span data-ttu-id="d187f-127">プラットフォーム</span><span class="sxs-lookup"><span data-stu-id="d187f-127">platform</span></span>| <span data-ttu-id="d187f-128">string</span><span class="sxs-lookup"><span data-stu-id="d187f-128">string</span></span>| <span data-ttu-id="d187f-129">サポートされているプラットフォーム。</span><span class="sxs-lookup"><span data-stu-id="d187f-129">The supported platform.</span></span>| 
| <span data-ttu-id="d187f-130">name</span><span class="sxs-lookup"><span data-stu-id="d187f-130">name</span></span>| <span data-ttu-id="d187f-131">string</span><span class="sxs-lookup"><span data-stu-id="d187f-131">string</span></span>| <span data-ttu-id="d187f-132">このタイトルのテキストの名前。</span><span class="sxs-lookup"><span data-stu-id="d187f-132">The text name of this title.</span></span> <span data-ttu-id="d187f-133">最大長 22 です。</span><span class="sxs-lookup"><span data-stu-id="d187f-133">Maximum length 22.</span></span>| 
| <span data-ttu-id="d187f-134">earnedAchievements</span><span class="sxs-lookup"><span data-stu-id="d187f-134">earnedAchievements</span></span>| <span data-ttu-id="d187f-135">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d187f-135">32-bit unsigned integer</span></span>| <span data-ttu-id="d187f-136">アチーブメントの数は、タイトルなどのロック解除のアチーブメントの獲得し、課題を正常に完了しました。</span><span class="sxs-lookup"><span data-stu-id="d187f-136">The number of achievements earned for the title, including unlocked achievements and successfully completed challenges.</span></span>| 
| <span data-ttu-id="d187f-137">currentGamerscore</span><span class="sxs-lookup"><span data-stu-id="d187f-137">currentGamerscore</span></span>| <span data-ttu-id="d187f-138">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d187f-138">32-bit unsigned integer</span></span>| <span data-ttu-id="d187f-139">合計のゲーマーこのタイトルでこのユーザーを獲得しました。</span><span class="sxs-lookup"><span data-stu-id="d187f-139">The total gamerscore this user has earned in this title.</span></span>| 
| <span data-ttu-id="d187f-140">maxGamerscore</span><span class="sxs-lookup"><span data-stu-id="d187f-140">maxGamerscore</span></span>| <span data-ttu-id="d187f-141">32 ビット符号なし整数</span><span class="sxs-lookup"><span data-stu-id="d187f-141">32-bit unsigned integer</span></span>| <span data-ttu-id="d187f-142">このタイトルの可能な合計ゲーマーします。</span><span class="sxs-lookup"><span data-stu-id="d187f-142">The total possible gamerscore for this title.</span></span>| 
  
<a id="ID4EFE"></a>

 
## <a name="see-also"></a><span data-ttu-id="d187f-143">関連項目</span><span class="sxs-lookup"><span data-stu-id="d187f-143">See also</span></span>
 
<a id="ID4EHE"></a>

 
##### <a name="parent"></a><span data-ttu-id="d187f-144">Parent</span><span class="sxs-lookup"><span data-stu-id="d187f-144">Parent</span></span> 

[<span data-ttu-id="d187f-145">JavaScript Object Notation (JSON) オブジェクトの参照</span><span class="sxs-lookup"><span data-stu-id="d187f-145">JavaScript Object Notation (JSON) Object Reference</span></span>](atoc-xboxlivews-reference-json.md)

   