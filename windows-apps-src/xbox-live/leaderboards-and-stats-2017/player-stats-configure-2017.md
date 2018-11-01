---
title: 統計とランキングの構成 2017
author: KevinAsgari
description: データ プラットフォーム 2017 を使用して、Xbox Live の注目の統計とランキングをユニバーサル デベロッパー センターで構成する方法について説明します。
ms.assetid: e0f307d2-ea02-48ea-bcdf-828272a894d4
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 6de9aa9c1e85655a9295370a963a485de5eb474a
ms.sourcegitcommit: cd00bb829306871e5103db481cf224ea7fb613f0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/01/2018
ms.locfileid: "5881458"
---
# <a name="configuring-featured-stats-or-leaderboards-on-universal-dev-center-with-data-platform-2017"></a><span data-ttu-id="a9ca8-104">データ プラットフォーム 2017 を使用した、ユニバーサル デベロッパー センターでの注目の統計とランキングの構成</span><span class="sxs-lookup"><span data-stu-id="a9ca8-104">Configuring Featured Stats or Leaderboards on Universal Dev Center with Data Platform 2017</span></span>

<span data-ttu-id="a9ca8-105">データ プラットフォーム 2017 では、統計を構成する必要があるのは次の 2 つの場合のみです。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-105">With Data Platform 2017, you only need to configure a stat in two cases:</span></span>

* <span data-ttu-id="a9ca8-106">統計がグローバル ランキングの基準として使用される場合</span><span class="sxs-lookup"><span data-stu-id="a9ca8-106">The stat is used as a basis for a global leaderboard, or</span></span>
* <span data-ttu-id="a9ca8-107">統計が、ゲーム ハブ ページに表示される "注目のプレイヤーの統計" として使用される場合</span><span class="sxs-lookup"><span data-stu-id="a9ca8-107">The stat is a featured player stat that will be displayed on the game hub page.</span></span>

<span data-ttu-id="a9ca8-108">どちらの場合でも、統計とランキングを一緒に構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-108">In either case, you must configure stats and leaderboards together.</span></span> <span data-ttu-id="a9ca8-109">すべてのランキングは統計を基準としており、"注目のプレイヤーの統計" でランキングを使用しない場合であっても、関連するグローバル ランキングを構成しないと統計を構成することはできません。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-109">Every leaderboard is based on a stat, and you cannot configure a stat without also configuring an associated global leaderboard, even if you do not plan to use a leaderboard for a featured player stat.</span></span>

<span data-ttu-id="a9ca8-110">"注目のプレイヤーの統計" 以外の統計、およびグローバル ランキングで使用されない統計は構成する必要がありません。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-110">You do not need to configure stats that are not featured player stats, and are not used by a global leaderboard.</span></span>

## <a name="configure-a-global-leaderboard-and-an-associated-player-stat"></a><span data-ttu-id="a9ca8-111">グローバル ランキング、および関連付するプレイヤーの統計を構成する</span><span class="sxs-lookup"><span data-stu-id="a9ca8-111">Configure a global leaderboard and an associated player stat</span></span>

<span data-ttu-id="a9ca8-112">まず、次に示すようにタイトルの [プレイヤーの統計] セクションに移動します。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-112">First, go to the Player Stats section for your title as shown below.</span></span>

![](../images/omega/dev_center_player_stats_creators.png)

<span data-ttu-id="a9ca8-113">次に [`Create your first featured stat/leaderboard`] ボタンをクリックし、ダイアログに入力したら [保存] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-113">Then click the `Create your first featured stat/leaderboard` button, and then fill out this dialog and click Save.</span></span>

![](../images/omega/dev_center_player_stats_creators_leaderboard.png)

<span data-ttu-id="a9ca8-114">[`Display name`] フィールドは、ゲーム ハブでユーザーに表示される名前です。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-114">The `Display name` field is what users will see in the GameHub.</span></span>  <span data-ttu-id="a9ca8-115">この文字列は [`Localize strings`] セクションでローカライズすることができます。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-115">This string can be localized in the `Localize strings` section.</span></span>  <span data-ttu-id="a9ca8-116">文字列をローカライズする方法の詳細を確認するには、[`Localize strings`] セクションの [`Show Options`] をクリックしてください。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-116">Click `Show Options` in the `Localize strings` section to see details on how to localize these strings.</span></span>

<span data-ttu-id="a9ca8-117">[`ID`] フィールドは統計の名前です。統計をタイトル コードから更新する場合は、この ID で統計を指定します。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-117">The `ID` field is the stat name and will be how you will refer to your stat when updating it from your title code.</span></span>   <span data-ttu-id="a9ca8-118">詳しくは、「[統計の更新](player-stats-updating.md)」セクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-118">See the [Updating Stats](player-stats-updating.md) section below for more detail.</span></span>

<span data-ttu-id="a9ca8-119">[`Format`] は、統計のデータ形式です。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-119">The `Format` is the data format of the stat.</span></span>

<span data-ttu-id="a9ca8-120">[`Display Logic`] では、[`Player progression`]、[`Personal best`]、[`Counter`] のいずれかを選択します。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-120">The `Display Logic` offers the choice between `Player progression`, `Personal best`, and `Counter`:</span></span>
- <span data-ttu-id="a9ca8-121">[Player progression] (プレイヤーの進行状況): ゲームでの各プレイヤーのレベルや進行状況を表します。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-121">Player progression: Represents an individual player level or progression in the game.</span></span>  <span data-ttu-id="a9ca8-122">最新の値セットが、ユーザーに表示されます </span><span class="sxs-lookup"><span data-stu-id="a9ca8-122">The last value set is what users will see.</span></span>  <span data-ttu-id="a9ca8-123">(たとえば、現在のラウンドにおける順位など)。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-123">For example, position in current round.</span></span>
- <span data-ttu-id="a9ca8-124">[Personal Best] (自己ベスト): プレイヤーが投稿した現在のベスト スコアを表します。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-124">Personal Best: Represents the current best score a player has posted.</span></span> <span data-ttu-id="a9ca8-125">並べ替え順序に応じて最大または最小の値セットが、ユーザーに表示されます </span><span class="sxs-lookup"><span data-stu-id="a9ca8-125">The max or min value set depending on sort order is what users will see.</span></span>  <span data-ttu-id="a9ca8-126">(たとえば、最速ラップなど)。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-126">For example, fastest lap.</span></span>
- <span data-ttu-id="a9ca8-127">[Counter] (カウンター): 他のプレイヤーの値に追加され、累積数を計算できます。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-127">Counter: Can be added to other player's to calculate a cumulative number.</span></span>  

<span data-ttu-id="a9ca8-128">[`Sort`] フィールドでは、ランキングの並べ替え順序を変更することができます。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-128">The `Sort` field lets you change the sort order of the leaderboard.</span></span>

<span data-ttu-id="a9ca8-129">この統計を `Featured Stat` にすることもできますが、そのためには、[`Feature on players' profiles`] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-129">You can also choose to make this stat a `Featured Stat`, but clicking on `Feature on players' profiles`.</span></span>  

## <a name="configure-featured-stats"></a><span data-ttu-id="a9ca8-130">注目の統計を構成する</span><span class="sxs-lookup"><span data-stu-id="a9ca8-130">Configure Featured Stats</span></span>

<span data-ttu-id="a9ca8-131">プレイヤーの統計を定義するとき、`Featured Stat` を有効にするオプションを使用することができます。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-131">When you define a player stat, you have the option of checking `Featured Stat`.</span></span>  <span data-ttu-id="a9ca8-132">要件は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-132">Please note the following requirements</span></span>

| <span data-ttu-id="a9ca8-133">開発者の種類</span><span class="sxs-lookup"><span data-stu-id="a9ca8-133">Developer Type</span></span> | <span data-ttu-id="a9ca8-134">要件</span><span class="sxs-lookup"><span data-stu-id="a9ca8-134">Requirement</span></span> |
|----------------|-------------|
| <span data-ttu-id="a9ca8-135">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="a9ca8-135">Xbox Live Creators Program</span></span> | <span data-ttu-id="a9ca8-136">統計を注目の統計として指定するための要件はありませんが、指定できる注目の統計の数は最大 10 個に制限されます。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-136">There is no requirement to designate any stats as Featured Stats.  Though you are limited to a maximum of 10</span></span> |
| <span data-ttu-id="a9ca8-137">ID@Xbox および Microsoft パートナー</span><span class="sxs-lookup"><span data-stu-id="a9ca8-137">ID@Xbox and Microsoft Partners</span></span> | <span data-ttu-id="a9ca8-138">注目の統計は、3 ～ 10 個まで指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-138">You must designate between 3 and 10 Featured Stats</span></span> |

## <a name="next-steps"></a><span data-ttu-id="a9ca8-139">次の手順</span><span class="sxs-lookup"><span data-stu-id="a9ca8-139">Next Steps</span></span>

<span data-ttu-id="a9ca8-140">次に、タイトル コードから統計を更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-140">Next you'll need to update the stat from title code.</span></span>  <span data-ttu-id="a9ca8-141">詳しくは、「[統計の更新](player-stats-updating.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="a9ca8-141">See [Updating Stats](player-stats-updating.md) for more detail.</span></span>