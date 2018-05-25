---
title: 注目の統計とランキング 2017
author: shrutimundra
description: Windows デベロッパー センターで Xbox Live の注目の統計とランキング 2017 を構成する方法について説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 10/30/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: low
keywords: Xbox Live, Xbox, ゲーム, uwp, windows 10, Xbox one, 注目の統計とランキング, ランキング, 統計 2017, Windows デベロッパー センター
ms.openlocfilehash: dda7604b52420d03bc8dc21aacb8a26b9496ccad
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="configuring-featured-stats-and-leaderboards-2017-on-windows-dev-center"></a><span data-ttu-id="d02b3-104">Windows デベロッパー センターで注目の統計とランキング 2017 を構成する</span><span class="sxs-lookup"><span data-stu-id="d02b3-104">Configuring Featured Stats and Leaderboards 2017 on Windows Dev Center</span></span>

<span data-ttu-id="d02b3-105">ゲームで統計サービスを操作するには、[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)で統計を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02b3-105">For a game to interact with the stats service, a stat needs to be defined in the [Windows Dev Center](https://developer.microsoft.com/dashboard).</span></span> <span data-ttu-id="d02b3-106">注目の統計はすべてゲーム ハブに表示され、自動的にランキングとして機能します。</span><span class="sxs-lookup"><span data-stu-id="d02b3-106">All featured stats will show up on the GameHub, which makes it automatically act as a leaderboard.</span></span> <span data-ttu-id="d02b3-107">生の値が保存されますが、ゲームには新しい値が生成する必要があるかどうかを判断するロジックが追加されます。</span><span class="sxs-lookup"><span data-stu-id="d02b3-107">We will store the raw value, however, the game will own the logic for determining if a new value should be provided.</span></span>

![ゲーム ハブの実績ページのスクリーンショット](../../images/dev-center/featured-stats-and-leaderboards/featured-stats-and-leaderboards-2.png)

<span data-ttu-id="d02b3-109">データ プラットフォーム 2017 では、プレイヤーのゲーム ハブ ページで注目として表示されるグローバル ランキングに使用される統計を構成するだけでかまいません。</span><span class="sxs-lookup"><span data-stu-id="d02b3-109">With Data Platform 2017, you only need to configure a stat which is used for a global leaderboard that is featured on a player's GameHub page.</span></span>

<span data-ttu-id="d02b3-110">Windows デベロッパー センターを使うと、ゲームに関連付けられている注目の統計とランキングを構成することができます。</span><span class="sxs-lookup"><span data-stu-id="d02b3-110">You can use Windows Dev Center to configure a featured stat and leaderboard that is associated with your game.</span></span> <span data-ttu-id="d02b3-111">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="d02b3-111">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="d02b3-112">**[サービス]** > **[Xbox Live]** > **[Featured stats and leaderboards]** (注目の統計とランキング) にある、タイトルの **[Featured stats and leaderboards]** (注目の統計とランキング) セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="d02b3-112">Navigate to the **Featured stats and leaderboards** section for your title, located under **Services** > **Xbox Live** > **Featured stats and leaderboards**.</span></span>
2. <span data-ttu-id="d02b3-113">**[新規作成]** ボタンをクリックすると、モーダル フォームで開きます。</span><span class="sxs-lookup"><span data-stu-id="d02b3-113">Click the **New** button which will open a modal form.</span></span> <span data-ttu-id="d02b3-114">入力したら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="d02b3-114">Once filled out, click **Save**.</span></span>

![新しい注目の統計/ランキング ダイアログの画像](../../images/dev-center/featured-stats-and-leaderboards/featured-stats-and-leaderboards-1.png)

<span data-ttu-id="d02b3-116">**[表示名]** フィールドは、ゲーム ハブでユーザーに表示される内容です。</span><span class="sxs-lookup"><span data-stu-id="d02b3-116">The **Display name** field is what users will see in the GameHub.</span></span> <span data-ttu-id="d02b3-117">この文字列は、Xbox Live サービス構成の **[Localize strings]** (文字列のローカライズ) でローカライズすることができます。</span><span class="sxs-lookup"><span data-stu-id="d02b3-117">This string can be localized in the **Localize strings** of the Xbox Live service configuration.</span></span>

<span data-ttu-id="d02b3-118">**[ID]** フィールドは統計の名前です。統計をコードから更新する場合は、この ID で統計を指定します。</span><span class="sxs-lookup"><span data-stu-id="d02b3-118">The **ID** field is the stat name and is how you will refer to your stat when updating it from your code.</span></span> <span data-ttu-id="d02b3-119">詳しくは、「[統計の更新](../../leaderboards-and-stats-2017/player-stats-updating.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d02b3-119">See the [Updating Stats](../../leaderboards-and-stats-2017/player-stats-updating.md) for more details.</span></span>

<span data-ttu-id="d02b3-120">**[形式]** は、統計のデータ形式です。整数、10 進数、パーセンテージ、ショート タイムスパン、ロング タイムスパン、文字列などのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="d02b3-120">The **Format** is the data format of the stat. Options include Integer, Decimal, Percentage, Short timespan, Long timespan and String.</span></span>

<span data-ttu-id="d02b3-121">**[並べ替え]** フィールドでは、ランキングの並べ替え順序を昇順または降順に変更できます。</span><span class="sxs-lookup"><span data-stu-id="d02b3-121">The **Sort** field lets you change the sort order of the leaderboard to be either ascending or descending.</span></span>

<span data-ttu-id="d02b3-122">注目の統計とランキングを構成するときは、次の要件に注意してください。</span><span class="sxs-lookup"><span data-stu-id="d02b3-122">Please note the following requirements when configuring a featured stat and leaderboard:</span></span>

| <span data-ttu-id="d02b3-123">開発者の種類</span><span class="sxs-lookup"><span data-stu-id="d02b3-123">Developer Type</span></span> | <span data-ttu-id="d02b3-124">要件</span><span class="sxs-lookup"><span data-stu-id="d02b3-124">Requirement</span></span> | <span data-ttu-id="d02b3-125">制限</span><span class="sxs-lookup"><span data-stu-id="d02b3-125">Limit</span></span> |
|----------------|-------------|-------|
| <span data-ttu-id="d02b3-126">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="d02b3-126">Xbox Live Creators Program</span></span> | <span data-ttu-id="d02b3-127">統計を注目の統計として指定するための要件はありません</span><span class="sxs-lookup"><span data-stu-id="d02b3-127">There is no requirement to designate any stats as Featured Stats</span></span> | <span data-ttu-id="d02b3-128">20</span><span class="sxs-lookup"><span data-stu-id="d02b3-128">20</span></span> |
| <span data-ttu-id="d02b3-129">ID@Xbox および Microsoft パートナー</span><span class="sxs-lookup"><span data-stu-id="d02b3-129">ID@Xbox and Microsoft Partners</span></span> | <span data-ttu-id="d02b3-130">注目の統計は、3 個以上指定する必要があります</span><span class="sxs-lookup"><span data-stu-id="d02b3-130">You must designate atleast 3 Featured Stats</span></span> | <span data-ttu-id="d02b3-131">20</span><span class="sxs-lookup"><span data-stu-id="d02b3-131">20</span></span> |

## <a name="next-steps"></a><span data-ttu-id="d02b3-132">次のステップ</span><span class="sxs-lookup"><span data-stu-id="d02b3-132">Next steps</span></span>

<span data-ttu-id="d02b3-133">次に、コードから統計を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d02b3-133">Next you'll need to update the stats from your code.</span></span>  <span data-ttu-id="d02b3-134">詳しくは、「[統計の更新](../../leaderboards-and-stats-2017/player-stats-updating.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d02b3-134">See [Updating Stats](../../leaderboards-and-stats-2017/player-stats-updating.md) for more details.</span></span>
