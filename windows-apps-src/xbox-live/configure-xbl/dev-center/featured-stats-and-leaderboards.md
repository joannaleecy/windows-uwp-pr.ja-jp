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
ms.localizationpriority: medium
keywords: Xbox Live, Xbox, ゲーム, uwp, windows 10, Xbox one, 注目の統計とランキング, ランキング, 統計 2017, Windows デベロッパー センター
ms.openlocfilehash: ed965c4d7e2c15e76494fd197808c7f47db2d584
ms.sourcegitcommit: 8e30651fd691378455ea1a57da10b2e4f50e66a0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/10/2018
ms.locfileid: "4497737"
---
# <a name="configuring-featured-stats-and-leaderboards-2017-on-windows-dev-center"></a><span data-ttu-id="64086-104">Windows デベロッパー センターで注目の統計とランキング 2017 を構成する</span><span class="sxs-lookup"><span data-stu-id="64086-104">Configuring Featured Stats and Leaderboards 2017 on Windows Dev Center</span></span>

<span data-ttu-id="64086-105">ゲームで統計サービスを操作するには、[Windows デベロッパー センター](https://developer.microsoft.com/dashboard)で統計を定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="64086-105">For a game to interact with the stats service, a stat needs to be defined in the [Windows Dev Center](https://developer.microsoft.com/dashboard).</span></span> <span data-ttu-id="64086-106">注目の統計はすべてゲーム ハブに表示され、自動的にランキングとして機能します。</span><span class="sxs-lookup"><span data-stu-id="64086-106">All Featured Stats will show up on the GameHub, which makes it automatically act as a leaderboard.</span></span> <span data-ttu-id="64086-107">生の値が保存されますが、ゲームには新しい値が生成する必要があるかどうかを判断するロジックが追加されます。</span><span class="sxs-lookup"><span data-stu-id="64086-107">We will store the raw value, however, the game will own the logic for determining if a new value should be provided.</span></span>

![<span data-ttu-id="64086-108">ゲーム ハブの実績ページのスクリーンショット](../../images/dev-center/featured-stats-and-leaderboards/featured-stats-and-leaderboards-2.png) 上の図は、タイトルのゲーム ハブに、注目の統計がどのように表示されるかを示しています。</span><span class="sxs-lookup"><span data-stu-id="64086-108">Screenshot of the achievements page on the Game Hub](../../images/dev-center/featured-stats-and-leaderboards/featured-stats-and-leaderboards-2.png) The picture above shows how Featured Stats will look in your title's GameHub.</span></span> <span data-ttu-id="64086-109">注目の統計は赤のボックス内に表示されています。</span><span class="sxs-lookup"><span data-stu-id="64086-109">The Featured Stats are shown withing the red box.</span></span>

<span data-ttu-id="64086-110">データ プラットフォーム 2017 のみに表示されるソーシャル ランキングは、プレイヤーのゲーム ハブ ページで注目としてに使用されます。 統計を構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="64086-110">With Data Platform 2017, you only need to configure a stat which is used for a social leaderboard that is featured on a player's GameHub page.</span></span>

<span data-ttu-id="64086-111">Windows デベロッパー センターを使うと、ゲームに関連付けられている注目の統計とランキングを構成することができます。</span><span class="sxs-lookup"><span data-stu-id="64086-111">You can use Windows Dev Center to configure a featured stat and leaderboard that is associated with your game.</span></span> <span data-ttu-id="64086-112">次の手順に従って、構成を追加します。</span><span class="sxs-lookup"><span data-stu-id="64086-112">Add configuration by doing the following:</span></span>

1. <span data-ttu-id="64086-113">**[サービス]** > **[Xbox Live]** > **[Featured stats and leaderboards]** (注目の統計とランキング) にある、タイトルの **[Featured stats and leaderboards]** (注目の統計とランキング) セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="64086-113">Navigate to the **Featured Stats and Leaderboards** section for your title, located under **Services** > **Xbox Live** > **Featured Stats and Leaderboards**.</span></span>
2. <span data-ttu-id="64086-114">**[新規作成]** ボタンをクリックすると、モーダル フォームで開きます。</span><span class="sxs-lookup"><span data-stu-id="64086-114">Click the **New** button which will open a modal form.</span></span> <span data-ttu-id="64086-115">入力したら、**[保存]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="64086-115">Once filled out, click **Save**.</span></span>

![新しい注目の統計/ランキング ダイアログの画像](../../images/dev-center/featured-stats-and-leaderboards/featured-stats-and-leaderboards-1.png)

<span data-ttu-id="64086-117">**[表示名]** フィールドは、ゲーム ハブでユーザーに表示される内容です。</span><span class="sxs-lookup"><span data-stu-id="64086-117">The **Display name** field is what users will see in the GameHub.</span></span> <span data-ttu-id="64086-118">この文字列は、Xbox Live サービス構成の **[Localize strings]** (文字列のローカライズ) でローカライズすることができます。</span><span class="sxs-lookup"><span data-stu-id="64086-118">This string can be localized in the **Localize strings** of the Xbox Live service configuration.</span></span>

<span data-ttu-id="64086-119">**[ID]** フィールドは統計の名前です。統計をコードから更新する場合は、この ID で統計を指定します。</span><span class="sxs-lookup"><span data-stu-id="64086-119">The **ID** field is the stat name and is how you will refer to your stat when updating it from your code.</span></span> <span data-ttu-id="64086-120">詳しくは、「[統計の更新](../../leaderboards-and-stats-2017/player-stats-updating.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64086-120">See the [Updating Stats](../../leaderboards-and-stats-2017/player-stats-updating.md) for more details.</span></span>

<span data-ttu-id="64086-121">**[形式]** は、統計のデータ形式です。整数、10 進数、パーセンテージ、ショート タイムスパン、ロング タイムスパン、文字列などのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="64086-121">The **Format** is the data format of the stat. Options include Integer, Decimal, Percentage, Short timespan, Long timespan and String.</span></span>

<span data-ttu-id="64086-122">**[形式]** の各オプションを選択すると、ドロップダウン リストに指定できる値や形式に関する情報が表示されます。</span><span class="sxs-lookup"><span data-stu-id="64086-122">Each **Format** option will give some information on acceptable values or formatting under the drop down when selected.</span></span>

* <span data-ttu-id="64086-123">整数の統計では、1、2、100 のような整数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="64086-123">Integer stats accept whole numbers like 1, 2, or 100.</span></span>
* <span data-ttu-id="64086-124">10 進数の統計では、1.05 や 12.00 などの小数点以下 2 桁は小数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="64086-124">Decimal stats accept fractional numbers with two decimal places like 1.05 or 12.00</span></span>
* <span data-ttu-id="64086-125">パーセンテージの統計では、0 ～ 100 の整数を使用できます。</span><span class="sxs-lookup"><span data-stu-id="64086-125">Percentage stats accept whole numbers between 0 and 100.</span></span> <span data-ttu-id="64086-126">整数の末尾に「%」が追加されます </span><span class="sxs-lookup"><span data-stu-id="64086-126">'%' will be appended to the end of the whole number.</span></span> <span data-ttu-id="64086-127">(例: 0%、100%)。</span><span class="sxs-lookup"><span data-stu-id="64086-127">(e.g. 0%, 100%)</span></span>
* <span data-ttu-id="64086-128">ショート タイムスパンの統計では、HH:MM:SS 形式 (02:10:30 など) に従い、統計の時間単位を指定するよう求められます。使用可能な時間単位は、ミリ秒、秒、分、時間、日です。</span><span class="sxs-lookup"><span data-stu-id="64086-128">Short timespan stats follow the HH:MM:SS format like 02:10:30, and will ask you to provide a time unit for the stat.   The available time units are milliseconds, seconds, minutes, hours, and days.</span></span>
* <span data-ttu-id="64086-129">ロング タイムスパンの統計では、Xd Xh Xm 形式 (1d 2h 10m など) に従い、この統計も統計の時間単位を指定するよう求められます。</span><span class="sxs-lookup"><span data-stu-id="64086-129">Long timespan stat follow the Xd Xh Xm format like 1d 2h 10m, this stat will also ask you to provide a time unit for the stat.</span></span>

<span data-ttu-id="64086-130">**[並べ替え]** フィールドでは、ランキングの並べ替え順序を昇順または降順に変更できます。</span><span class="sxs-lookup"><span data-stu-id="64086-130">The **Sort** field lets you change the sort order of the leaderboard to be either ascending or descending.</span></span>

<span data-ttu-id="64086-131">注目の統計とランキングを構成するときは、次の要件に注意してください。</span><span class="sxs-lookup"><span data-stu-id="64086-131">Please note the following requirements when configuring a featured stat and leaderboard:</span></span>

| <span data-ttu-id="64086-132">開発者の種類</span><span class="sxs-lookup"><span data-stu-id="64086-132">Developer Type</span></span> | <span data-ttu-id="64086-133">要件</span><span class="sxs-lookup"><span data-stu-id="64086-133">Requirement</span></span> | <span data-ttu-id="64086-134">制限</span><span class="sxs-lookup"><span data-stu-id="64086-134">Limit</span></span> |
|----------------|-------------|-------|
| <span data-ttu-id="64086-135">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="64086-135">Xbox Live Creators Program</span></span> | <span data-ttu-id="64086-136">統計を注目の統計として指定するための要件はありません</span><span class="sxs-lookup"><span data-stu-id="64086-136">There is no requirement to designate any stats as Featured Stats</span></span> | <span data-ttu-id="64086-137">20</span><span class="sxs-lookup"><span data-stu-id="64086-137">20</span></span> |
| <span data-ttu-id="64086-138">ID@Xbox および Microsoft パートナー</span><span class="sxs-lookup"><span data-stu-id="64086-138">ID@Xbox and Microsoft Partners</span></span> | <span data-ttu-id="64086-139">注目の統計は、3 個以上指定する必要があります</span><span class="sxs-lookup"><span data-stu-id="64086-139">You must designate at least 3 Featured Stats</span></span> | <span data-ttu-id="64086-140">20</span><span class="sxs-lookup"><span data-stu-id="64086-140">20</span></span> |

## <a name="next-steps"></a><span data-ttu-id="64086-141">次のステップ</span><span class="sxs-lookup"><span data-stu-id="64086-141">Next steps</span></span>

<span data-ttu-id="64086-142">次に、コードから統計を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="64086-142">Next you'll need to update the stats from your code.</span></span>  <span data-ttu-id="64086-143">詳しくは、「[統計の更新](../../leaderboards-and-stats-2017/player-stats-updating.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="64086-143">See [Updating Stats](../../leaderboards-and-stats-2017/player-stats-updating.md) for more details.</span></span>
