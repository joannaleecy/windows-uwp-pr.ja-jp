---
title: プレイヤーの統計
author: StaceyHaffner
description: Xbox Live でプレイヤーの統計をセットアップする方法について説明します。
ms.assetid: 5ec7cec6-4296-483d-960d-2f025af6896e
ms.author: kevinasg
ms.date: 11/10/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, プレイヤーの統計, ランキング
ms.localizationpriority: low
ms.openlocfilehash: 252dd93c0382f19d0135345434ab197137add141
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="player-stats"></a><span data-ttu-id="9fd28-104">プレイヤーの統計</span><span class="sxs-lookup"><span data-stu-id="9fd28-104">Player Stats</span></span>

<span data-ttu-id="9fd28-105">「[データ プラットフォームの概要](../data-platform/data-platform.md)」で説明されているように、統計とは、プレイヤーを追跡する場合に必要となる重要な情報です。</span><span class="sxs-lookup"><span data-stu-id="9fd28-105">As described in [Data Platform Overview](../data-platform/data-platform.md), stats are key pieces of information you want to track about a player.</span></span> <span data-ttu-id="9fd28-106">たとえば、*ヘッド ショット*や*最速のラップ タイム*などを例として挙げることができます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-106">For example *Head Shots* or *Fastest Lap Time*.</span></span>

<span data-ttu-id="9fd28-107">これらの統計は、[ゲーム ハブ](../data-platform/designing-xbox-live-experiences.md)に表示したり、ランキングの設定に使用したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-107">These stats can be shown in the [Game Hub](../data-platform/designing-xbox-live-experiences.md), or used to populate leaderboards.</span></span> <span data-ttu-id="9fd28-108">たとえば "*最速のラップ タイム*" の統計があれば、この統計に応じて、世界中のプレイヤーのラップ タイムを表示するランキングを作成できます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-108">For example, if you have a stat for *Fastest Lap Time*, you could then have a corresponding leaderboard showing lap times for players around the world.</span></span>

## <a name="defining-stats"></a><span data-ttu-id="9fd28-109">統計の定義</span><span class="sxs-lookup"><span data-stu-id="9fd28-109">Defining Stats</span></span>

<span data-ttu-id="9fd28-110">特定の種類の統計は、デベロッパー センターで構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9fd28-110">For certain types of stats, you will need to configure them on Dev Center.</span></span> <span data-ttu-id="9fd28-111">こうした統計について、以下で説明します。</span><span class="sxs-lookup"><span data-stu-id="9fd28-111">We will list these out below.</span></span>

### <a name="what-needs-to-be-configured"></a><span data-ttu-id="9fd28-112">構成が必要なもの</span><span class="sxs-lookup"><span data-stu-id="9fd28-112">What needs to be configured</span></span>

<span data-ttu-id="9fd28-113">通常の統計は構成する必要はありませんが、統計が "注目の統計" として使用される場合、デベロッパー センターで定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9fd28-113">In general stats do not need to be configured, but if your stat is a Featured Stat you will need to define this on Dev Center.</span></span> <span data-ttu-id="9fd28-114">注目の統計は、タイトルのゲーム ハブに表示されます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-114">Featured stats will appear on your title's Game Hub.</span></span> <span data-ttu-id="9fd28-115">これによりゲーム ハブの外観がさらにプレイヤーの興味をひきつけるようになります。また、ランキングが自動で生成されるのでプレイヤーの参加を継続的に促すことができます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-115">These will make your Game Hub look more interesting and generate automatic leaderboards to keep players engaged.</span></span> <span data-ttu-id="9fd28-116">注目の統計は、タイトルを所有していない人も含め Xbox Live のすべてのプレイヤーに表示されます。このため、注目の統計を利用することで、タイトルにおける特定のゲームプレイのしくみに注意を引き付けることもできます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-116">You can also use them to draw attention to certain gameplay mechanics in your title since these are visible to all players on Xbox Live, even if they don't own your title.</span></span>

<span data-ttu-id="9fd28-117">注目の統計には、全期間と毎月の世界ランキングが自動的に提供されます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-117">Featured stats are automatically given global all-time and monthly leaderboards.</span></span> <span data-ttu-id="9fd28-118">これらのランキングはゲーム ハブに表示され、フレンドと比較したプレイヤーの進行状況が示されます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-118">These leaderboards are shown in the GameHub and will show player's progress as compared to their friends.</span></span> <span data-ttu-id="9fd28-119">通常のランキングと同じようにタイトルに表示することもできます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-119">They can also be shown in your title the same way as regular leaderboards.</span></span> <span data-ttu-id="9fd28-120">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="9fd28-120">For example:</span></span>

![](../images/omega/gamehub_featuredstats.png)

<span data-ttu-id="9fd28-121">統計が*グローバル ランキング*に対応している場合も、デベロッパー センターで定義する必要があります。</span><span class="sxs-lookup"><span data-stu-id="9fd28-121">If your stat corresponds to a *Global Leaderboard*, you will also need to define it on Dev Center.</span></span> <span data-ttu-id="9fd28-122">*グローバル ランキング*について詳しくは、「[ランキング](leaderboards.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9fd28-122">The [Leaderboards](leaderboards.md) article will describe *Global Leaderboards* in more detail.</span></span> <span data-ttu-id="9fd28-123">簡単に説明すると、グローバル ランキングとは、あるプレイヤーが世界中の他のプレイヤーを対象として、どの順位に位置するかを示すものです。</span><span class="sxs-lookup"><span data-stu-id="9fd28-123">Briefly, a Global Leaderboard is one where a player is ranked against all other players in the world.</span></span>

<span data-ttu-id="9fd28-124">統計が*ソーシャル ランキング*にのみ対応する場合は、デベロッパー センターで構成する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="9fd28-124">If your stat only corresponds to a *Social Leaderboard*, you do not need to do any configuration on Dev Center.</span></span> <span data-ttu-id="9fd28-125">*ソーシャル ランキング*について詳しくは、「[ランキング](leaderboards.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9fd28-125">The [Leaderboards](leaderboards.md) article will describe *Social Leaderboards* in more detail.</span></span> <span data-ttu-id="9fd28-126">簡単に説明すると、ソーシャル ランキングとは、あるプレイヤーがフレンドであるプレイヤー (プレイヤーのフォロワーおよびフォロー先) のみを対象として、どの順位に位置するかを示すものです。</span><span class="sxs-lookup"><span data-stu-id="9fd28-126">Briefly, a Social Leaderboard is one where a player is ranked only against players who they are friends with (someone who is following them, and they are following).</span></span>

### <a name="configured-on-dev-center"></a><span data-ttu-id="9fd28-127">デベロッパー センターでの構成</span><span class="sxs-lookup"><span data-stu-id="9fd28-127">Configured on Dev Center</span></span>

<span data-ttu-id="9fd28-128">構成の操作は、使用しているデータ プラットフォームのバージョンによって異なります。</span><span class="sxs-lookup"><span data-stu-id="9fd28-128">The configuration experience depends on version of the Data Platform you are using.</span></span>

> <span data-ttu-id="9fd28-129">**注** Xbox Live クリエーターズ プログラムの一環としてタイトルを作成している場合は、データ プラットフォーム 2017 を使用していることになります。</span><span class="sxs-lookup"><span data-stu-id="9fd28-129">**Note** If you are making a title as part of the Xbox Live Creators Program you are using Data Platform 2017.</span></span>

<span data-ttu-id="9fd28-130">Xbox Live クリエーターズ プログラムに参加している場合、またはデータ プラットフォーム 2017 を使用している場合は、「[Windows デベロッパー センターでの注目の統計とランキングの構成](../configure-xbl/dev-center/featured-stats-and-leaderboards.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9fd28-130">If you are in the Xbox Live Creators Program or using Data Platform 2017, please see [Configuring Featured Stats or Leaderboards on Windows Dev Center](../configure-xbl/dev-center/featured-stats-and-leaderboards.md)</span></span>

<span data-ttu-id="9fd28-131">XDK と以前の UWP のタイトルで使用されているデータ プラットフォーム 2013 では、統計によって実績を操作することができます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-131">In the case of Data Platform 2013 which is used on XDK and older UWP titles, stats can drive achievements.</span></span> <span data-ttu-id="9fd28-132">対象パートナーであり、さらに詳しい情報が必要な場合は、「[データ プラットフォーム 2013 のユーザー統計](https://developer.microsoft.com/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/user-stats)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9fd28-132">If you are a managed partner and need more information, please see [User Stats for Data Platform 2013](https://developer.microsoft.com/games/xbox/docs/xboxlive/xbox-live-partners/event-driven-data-platform/user-stats).</span></span>  

## <a name="next-steps"></a><span data-ttu-id="9fd28-133">次の手順</span><span class="sxs-lookup"><span data-stu-id="9fd28-133">Next Steps</span></span>

<span data-ttu-id="9fd28-134">以上で、プレイヤーの統計と注目の統計の構成が完了しました。</span><span class="sxs-lookup"><span data-stu-id="9fd28-134">Now that you have some Player Stats and Featured Stats configured.</span></span> <span data-ttu-id="9fd28-135">これで、ランキングの作成に取りかかることができます。</span><span class="sxs-lookup"><span data-stu-id="9fd28-135">You are ready to create a leaderboard.</span></span> <span data-ttu-id="9fd28-136">作業を開始するには「[ランキング](leaderboards.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="9fd28-136">Please see [Leaderboards](leaderboards.md) to get started.</span></span>


