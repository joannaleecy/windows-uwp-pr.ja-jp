---
title: Xbox Live エクスペリエンスの設計
author: KevinAsgari
description: Xbox Live メンバー向けの優れたエクスペリエンスを設計する方法について説明します。そのためには、タイトルに関連するプレイヤーの統計、ランキング、実績についての計画を立てます。
ms.assetid: d2a85621-7d02-4b11-a7fa-9ebaee0092d5
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 統計, 実績, ランキング, 設計
ms.localizationpriority: medium
ms.openlocfilehash: 112beacc2009f495da64475a0740560b7271b43d
ms.sourcegitcommit: 4f6dc806229a8226894c55ceb6d6eab391ec8ab6
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/20/2018
ms.locfileid: "4091295"
---
# <a name="designing-xbox-live-experiences"></a><span data-ttu-id="e3a98-104">Xbox Live エクスペリエンスの設計</span><span class="sxs-lookup"><span data-stu-id="e3a98-104">Designing Xbox Live Experiences</span></span>

<span data-ttu-id="e3a98-105">このトピックでは、サンプル プロセスを検討材料として使用し、ユーザーの統計情報、実績、ランキングをゲームに追加することを検討します。ここでは、Xbox Live のデータ プラットフォーム機能を使用します。</span><span class="sxs-lookup"><span data-stu-id="e3a98-105">This topic walks you through a sample process of thinking about and adding user statistics, achievements, and leaderboards to your game by using the Data Platform features of Xbox Live.</span></span>

## <a name="example"></a><span data-ttu-id="e3a98-106">例</span><span class="sxs-lookup"><span data-stu-id="e3a98-106">Example</span></span>
<span data-ttu-id="e3a98-107">架空のゲームを構成して、Xbox One ダッシュボード、Windows 10 の Xbox アプリ、およびゲーム内で優れた Xbox Live エクスペリエンスを検討する際に、データ プラットフォームがどのように役立つかを示してみましょう。</span><span class="sxs-lookup"><span data-stu-id="e3a98-107">Let's configure a fictional game that shows you how Data Platform can help you light up amazing Xbox Live experiences in the Xbox One dashboard, the Xbox app on Windows 10, and in your game.</span></span> <span data-ttu-id="e3a98-108">このシナリオでは、_Races 2015_ という名前の架空のレーシング ゲームを使って作業します。</span><span class="sxs-lookup"><span data-stu-id="e3a98-108">For this scenario, we'll work with an imaginary racing game called _Races 2015_.</span></span>

<span data-ttu-id="e3a98-109">このゲームでのエクスペリエンスを最大限に活用するために、推奨される以下の計画フェーズに従います。</span><span class="sxs-lookup"><span data-stu-id="e3a98-109">To get the most value out of these experiences, we will follow these recommended planning phases:</span></span>
1. <span data-ttu-id="e3a98-110">XBL エクスペリエンスを設計する</span><span class="sxs-lookup"><span data-stu-id="e3a98-110">Design your XBL experiences</span></span>
2. <span data-ttu-id="e3a98-111">シナリオを実現するために必要な統計を設計する</span><span class="sxs-lookup"><span data-stu-id="e3a98-111">Design the stats needed to power your scenarios</span></span>
3. <span data-ttu-id="e3a98-112">注目の統計、実績、ランキングを必要に応じて構成する</span><span class="sxs-lookup"><span data-stu-id="e3a98-112">Configure Featured Stats, Achievements, or Leaderboards as needed</span></span>


## <a name="1-design-your-xbox-live-experiences"></a><span data-ttu-id="e3a98-113">1. Xbox Live エクスペリエンスの設計</span><span class="sxs-lookup"><span data-stu-id="e3a98-113">1. Design your Xbox Live experiences</span></span>
<span data-ttu-id="e3a98-114">ゲームの内容や外観にユーザーの関心を引き付けておくことができるように、_Race 2015_ では Xbox Live を最大限に活用します。</span><span class="sxs-lookup"><span data-stu-id="e3a98-114">We want _Race 2015_ to get the most out of Xbox Live in order to keep users engaged both inside and outside of the game.</span></span> <span data-ttu-id="e3a98-115">最初に以下のことを確認してください。</span><span class="sxs-lookup"><span data-stu-id="e3a98-115">The first questions to ask are:</span></span>

1. <span data-ttu-id="e3a98-116">ゲーム ハブの [実績] タブでのエクスペリエンスはどのようにしたいか。</span><span class="sxs-lookup"><span data-stu-id="e3a98-116">What do we want our GameHub's Achievements tab experience to be like?</span></span> <span data-ttu-id="e3a98-117">(注目の統計とソーシャル ランキング)</span><span class="sxs-lookup"><span data-stu-id="e3a98-117">(Featured Statistics & Social Leaderboards)</span></span>
2. <span data-ttu-id="e3a98-118">ゲーム内で実行する目標や動機付けとして何をプレイヤーに提供するか。</span><span class="sxs-lookup"><span data-stu-id="e3a98-118">What goals and motivations do we want to give to the players to do in the game?</span></span> <span data-ttu-id="e3a98-119">(実績)</span><span class="sxs-lookup"><span data-stu-id="e3a98-119">(Achievements)</span></span>
3. <span data-ttu-id="e3a98-120">ゲーム内でプレイヤーが自身を他のプレイヤーに対してランク付けするために、どのようなスコアや統計を使用させるか。</span><span class="sxs-lookup"><span data-stu-id="e3a98-120">What scores or stats do we want players to use to rank themselves against other players in game?</span></span> <span data-ttu-id="e3a98-121">(ランキング)</span><span class="sxs-lookup"><span data-stu-id="e3a98-121">(Leaderboards)</span></span>


### <a name="gamehubs---featured-statistics-and-social-leaderboards"></a><span data-ttu-id="e3a98-122">ゲーム ハブ - 注目の統計とソーシャル ランキング</span><span class="sxs-lookup"><span data-stu-id="e3a98-122">GameHubs - Featured Statistics and social Leaderboards</span></span>
<span data-ttu-id="e3a98-123">ゲーム ハブは、ユーザーがゲームに関するすべての情報を理解する場合に参照する場所です。</span><span class="sxs-lookup"><span data-stu-id="e3a98-123">GameHubs are landing experiences where users can learn everything about a game.</span></span> <span data-ttu-id="e3a98-124">またゲーム ハブは、開発者や公開元にとっては、まだゲームを購入していない Xbox ユーザーに対して、ゲームがいかにすばらしく価値があるかを示す_ショーケース_として最適な場所です。</span><span class="sxs-lookup"><span data-stu-id="e3a98-124">As a developer and/or publisher, this is the perfect place for you to _showcase_ how great and rich your game is to Xbox users who have not bought the game yet.</span></span> <span data-ttu-id="e3a98-125">ゲーム ハブでは、進行状況やユーザーの興味を引くメトリックを、既にタイトルを所有しているゲーマーに対して提示することも目的としています。</span><span class="sxs-lookup"><span data-stu-id="e3a98-125">GameHubs are also designed to show progress and engaging metrics to gamers who already own the title.</span></span> <span data-ttu-id="e3a98-126">ユーザーは [実績] タブで、ゲームの進行状況と実績、ヒーロー情報、ソーシャル ランキングを参照できます。</span><span class="sxs-lookup"><span data-stu-id="e3a98-126">Under the Achievements tab, users can find Game Progress & Achievements, Hero Stats, and social Leaderboards.</span></span>

<span data-ttu-id="e3a98-127">このセクションの目的は、ユーザーの興味を最も引くゲームのメトリックを把握し、明確にすることです。これにより、ゲームでのプレイヤーのエクスペリエンスを表すユニークな画面イメージを示し、ソーシャル ランキングではプレイヤーをフレンドと比較してランク付けすることができます。</span><span class="sxs-lookup"><span data-stu-id="e3a98-127">This section's goal is to capture the most engaging metrics for the game and expose them to provide a unique picture of the players's experience with the game and rank them against their friends in a social leaderboard.</span></span> <span data-ttu-id="e3a98-128">たとえば、Forza 6 の [Achievement] タブは次のように表示されます。</span><span class="sxs-lookup"><span data-stu-id="e3a98-128">For instance, the Forza 6 Achievement tab could look something like this:</span></span>

![ゲーム ハブのイメージ](../images/omega/forza_gamehub.png)


<span data-ttu-id="e3a98-130">[Miles Driven] や [First Place Finishes] などの統計情報に、フレンドと比較した場合のプレイヤーのランクを示すゴールド、シルバー、またはブロンズのマークが付いていることがわかります。</span><span class="sxs-lookup"><span data-stu-id="e3a98-130">You'll notice some of the statistics such as Miles Driven and First Place Finishes have gold, silver, or bronze decorations that illustrate where the player ranks against his friends.</span></span> <span data-ttu-id="e3a98-131">これらの統計情報を操作すると、次のような完全なランキングが表示されます。</span><span class="sxs-lookup"><span data-stu-id="e3a98-131">Interacting with any of these statistics will show a complete leaderboard like this:</span></span>

![ランキング](../images/omega/progress_gamehub_lb.png)

 <span data-ttu-id="e3a98-133">_Race 2015_ については、以下の情報が、タイトルでのプレイヤーの経験を表す適切な統計情報のセットであり、ランキング メトリックとしても適切な情報であると考えています。</span><span class="sxs-lookup"><span data-stu-id="e3a98-133">For _Race 2015_, we believe the following is a good set of statistics that represent a player's experience with the title as well as good ranking metrics:</span></span>
 * <span data-ttu-id="e3a98-134">最速ラップ タイム</span><span class="sxs-lookup"><span data-stu-id="e3a98-134">Fastest lap</span></span>
 * <span data-ttu-id="e3a98-135">第 1 位での勝利数</span><span class="sxs-lookup"><span data-stu-id="e3a98-135">Most 1st place wins</span></span>
 * <span data-ttu-id="e3a98-136">走行マイル数</span><span class="sxs-lookup"><span data-stu-id="e3a98-136">Miles driven</span></span>


### <a name="achievements"></a><span data-ttu-id="e3a98-137">実績</span><span class="sxs-lookup"><span data-stu-id="e3a98-137">Achievements</span></span>
<span data-ttu-id="e3a98-138">実績は、すべてのゲームにわたって一貫性のある方法でユーザーのゲーム内アクションを管理し報奨を与えるためのシステム規模のメカニズムです。</span><span class="sxs-lookup"><span data-stu-id="e3a98-138">Achievements are a system-wide mechanism for directing and rewarding users' in-game actions in a consistent manner across all games.</span></span> <span data-ttu-id="e3a98-139">実績を正しく設計することにより、ユーザーはゲームを十分に体験することができ、ゲームがより長く存続することにもつながります。</span><span class="sxs-lookup"><span data-stu-id="e3a98-139">Designing this correctly helps guide users to experience the game at its fullest and extends the lifetime of the game.</span></span>

<span data-ttu-id="e3a98-140">_Races 2015_ では、実績の一部は次のように構成されます。</span><span class="sxs-lookup"><span data-stu-id="e3a98-140">For _Races 2015_, here is a subset of the achievements we want to configure:</span></span>
* <span data-ttu-id="e3a98-141">60 秒未満で 1 ラップ終了する</span><span class="sxs-lookup"><span data-stu-id="e3a98-141">Finish 1 lap in under 60 seconds</span></span>
* <span data-ttu-id="e3a98-142">10 レースを第 1 位で終える</span><span class="sxs-lookup"><span data-stu-id="e3a98-142">Finish 10 races in 1st place</span></span>
* <span data-ttu-id="e3a98-143">各トラックで少なくとも 1 レース完走する</span><span class="sxs-lookup"><span data-stu-id="e3a98-143">Complete at least 1 race in each the tracks</span></span>
* <span data-ttu-id="e3a98-144">5 台の車を所有する</span><span class="sxs-lookup"><span data-stu-id="e3a98-144">Own 5 cars</span></span>
* <span data-ttu-id="e3a98-145">10,000 マイル走行する</span><span class="sxs-lookup"><span data-stu-id="e3a98-145">Drive for 10,000 miles</span></span>
* <span data-ttu-id="e3a98-146">...</span><span class="sxs-lookup"><span data-stu-id="e3a98-146">...</span></span>


###  <a name="leaderboards"></a><span data-ttu-id="e3a98-147">ランキング</span><span class="sxs-lookup"><span data-stu-id="e3a98-147">Leaderboards</span></span>
<span data-ttu-id="e3a98-148">ランキングは、ゲームで達成できる特定のアクションについて、他のゲーマーと比較して自分を評価する方法をゲーマーに提供します。</span><span class="sxs-lookup"><span data-stu-id="e3a98-148">Leaderboards provide a way for gamers to rate themselves against other gamers for specific actions they can achieve in the game.</span></span> <span data-ttu-id="e3a98-149">ゲーム ハブのソーシャル ランキングだけでなく、ゲームで使用されるグローバル ランキングを構成することもできます。</span><span class="sxs-lookup"><span data-stu-id="e3a98-149">Besides the social leaderboards in the GameHubs, we can configure Global Leaderboards to be used in game.</span></span> <span data-ttu-id="e3a98-150">以下は、すべてのユーザーをランク付けするランキングの一部です。</span><span class="sxs-lookup"><span data-stu-id="e3a98-150">These are some of the Leaderboards we'll want to rank all of our users on:</span></span>

* <span data-ttu-id="e3a98-151">最速ラップ タイム</span><span class="sxs-lookup"><span data-stu-id="e3a98-151">Fastest lap time</span></span>
 * <span data-ttu-id="e3a98-152">メタデータ: このタイムが発生したレース トラック</span><span class="sxs-lookup"><span data-stu-id="e3a98-152">Metadata: track where this happened</span></span>
 * <span data-ttu-id="e3a98-153">メタデータ: 使用された車</span><span class="sxs-lookup"><span data-stu-id="e3a98-153">Metadata: car used</span></span>
 * <span data-ttu-id="e3a98-154">メタデータ: 天気の状態</span><span class="sxs-lookup"><span data-stu-id="e3a98-154">Metadata: weather conditions</span></span>
* <span data-ttu-id="e3a98-155">第 1 位での勝利数</span><span class="sxs-lookup"><span data-stu-id="e3a98-155">Most 1st place wins</span></span>
* <span data-ttu-id="e3a98-156">車の最大収集数</span><span class="sxs-lookup"><span data-stu-id="e3a98-156">Most cars collected</span></span>

## <a name="next-steps"></a><span data-ttu-id="e3a98-157">次の手順</span><span class="sxs-lookup"><span data-stu-id="e3a98-157">Next Steps</span></span>
<span data-ttu-id="e3a98-158">ここでは、統計、ランキング、実績を効率的に設計する方法について説明しました。次の手順では、統計、ランキング、実績をタイトルに実装してください。</span><span class="sxs-lookup"><span data-stu-id="e3a98-158">Now that you know how to effectively design Stats, Leaderboards and Achievements, you can now begin to start implementing these in your title.</span></span>  <span data-ttu-id="e3a98-159">以降のセクションでは、デベロッパー センターでの構成から始まるプロセスについて詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="e3a98-159">The next few sections will describe the end-to-end process starting with configuration on Dev Center.</span></span>

<span data-ttu-id="e3a98-160">「[プレイヤーの統計](../leaderboards-and-stats-2017/player-stats.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e3a98-160">See [Player Stats](../leaderboards-and-stats-2017/player-stats.md)</span></span>
