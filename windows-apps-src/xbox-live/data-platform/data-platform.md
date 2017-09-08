---
title: "Xbox Live データ プラットフォーム"
author: KevinAsgari
description: "実績、プレイヤーの統計、ランキングを管理するサービスで構成される、Xbox Live データ プラットフォームの概要について説明します。"
ms.assetid: a8bb7c4f-09fe-4dba-b3ce-1fab60453831
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 統計, 実績, ランキング, 設計, データ プラットフォーム"
ms.openlocfilehash: 86f140744d7a3a90bc3bf5d0e546d8e72b1527d3
ms.sourcegitcommit: 90fbdc0e25e0dff40c571d6687143dd7e16ab8a8
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 07/06/2017
---
# <a name="xbox-live-data-platform---stats-leaderboards-achievements"></a><span data-ttu-id="bf8f6-104">Xbox Live データ プラットフォーム - 統計、ランキング、実績</span><span class="sxs-lookup"><span data-stu-id="bf8f6-104">Xbox Live Data Platform - Stats, Leaderboards, Achievements</span></span>

<span data-ttu-id="bf8f6-105">ゲーム データを Xbox Live データ プラットフォームに書き込むことにより、タイトルをサービスとして実行できます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-105">Writing game data to the Xbox Live Data Platform enables your title to run as a service.</span></span> <span data-ttu-id="bf8f6-106">また、Xbox Live データプラットフォームは、統計、ランキング、実績を利用して、ユーザーがタイトルに関心を持つように促したり、本体のシェルと Xbox アプリに注目の統計を表示したりします。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-106">Additionally, the Xbox Live Data Platform drives user engagement with your title using stats, leaderboards, and achievements, and surfaces featured stats in the console shell and Xbox App.</span></span>

<span data-ttu-id="bf8f6-107">ドラッグ ストリップ モードで走行した全レース数はレーシング ゲームの統計の一例であり、これを使用して、スコアをコミュニティと比較するランキングを作成し、リッチ プレゼンスの文字列にリアルタイムで反映できます (例: "GoTeamEmily はドラッグ ストリップ モードをプレイ中: 523 レースを完了")。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-107">One example of a stat for a racing game might be the total races run in drag strip mode, which can be used to create a leaderboard to compare your score against the community, and can be reflected in your Rich Presence string in real time (for example, "GoTeamEmily is playing Drag Strip Mode: 523 races completed").</span></span> <span data-ttu-id="bf8f6-108">ドラッグ ストリップ モードの全レース数はマッチメイキングの条件としても使用でき、類似した経験を持つプレイヤーどうしが対戦する可能性を高めることができます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-108">Total races in drag strip mode could also be used as a criterion for Matchmaking, assuring players with similar experience are more likely to be matched together.</span></span>

<span data-ttu-id="bf8f6-109">タイトルでは、プレイヤーの統計に基づいてランキングを表示できます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-109">Your title can display leaderboards based on player stats.</span></span> <span data-ttu-id="bf8f6-110">たとえば、ランキングを完了したレースのグローバル ランキングにすることができます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-110">For example, the leaderboard could be a global ranking of races completed.</span></span> <span data-ttu-id="bf8f6-111">これらのサービスは、Xbox Live API を使って直接呼び出すか、Unity などのゲーム エンジンでラッパーを使って呼び出します。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-111">You call these services using the Xbox Live APIs directly, or wrappers in a game engine like Unity.</span></span>

<span data-ttu-id="bf8f6-112">特定の統計を注目の統計として指定できます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-112">You can designate certain stats as featured stats.</span></span> <span data-ttu-id="bf8f6-113">注目の統計は、タイトルのゲーム ハブに表示され、プレイヤーとフレンドの成績を比較することができます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-113">Featured stats are shown in your title's GameHub and compare players against their friends.</span></span>

<span data-ttu-id="bf8f6-114">実績は統計に基づいて動作するのではなく、実績がロック解除されるタイミングはタイトルが決定します。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-114">Achievements are not powered by stats, and your title decides when an achievement is unlocked.</span></span> <span data-ttu-id="bf8f6-115">たとえば、タイトルでは、レースの完了に関する実績を 1 分未満保持することができます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-115">For example your title might have an achievement for completing a race in under a minute.</span></span> <span data-ttu-id="bf8f6-116">タイトルは、実績のロック解除に必要なパラメーターを追跡します。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-116">Your title keeps track of the parameters needed to unlock the achievement.</span></span> <span data-ttu-id="bf8f6-117">この例では、レースの所要時間を測定して実績を付与する処理はタイトルが行います。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-117">In this example it would be up to your title to measure how long the race took, and then award the achievement.</span></span> <span data-ttu-id="bf8f6-118">通常、ゲーマースコアは実績の完了と同時に付与されます。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-118">Typically, Gamerscore is awarded along with the completion of achievements.</span></span> <span data-ttu-id="bf8f6-119">各実績で使用するゲーマースコアの量はユーザーが決定します。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-119">It is up to you to decided the amount of Gamerscore for each achievement.</span></span>

## <a name="features"></a><span data-ttu-id="bf8f6-120">機能</span><span class="sxs-lookup"><span data-stu-id="bf8f6-120">Features</span></span> ##
<span data-ttu-id="bf8f6-121">以下のトピックでは、Xbox Live データ プラットフォームの機能について、さらに詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="bf8f6-121">The following topics provide more information about Xbox Live Data Platform features:</span></span>

* [<span data-ttu-id="bf8f6-122">プレイヤーの統計</span><span class="sxs-lookup"><span data-stu-id="bf8f6-122">Player Stats</span></span>](../leaderboards-and-stats-2017/player-stats.md)
* [<span data-ttu-id="bf8f6-123">実績</span><span class="sxs-lookup"><span data-stu-id="bf8f6-123">Achievements</span></span>](../achievements-2017/achievements.md)
* [<span data-ttu-id="bf8f6-124">ランキング</span><span class="sxs-lookup"><span data-stu-id="bf8f6-124">Leaderboards</span></span>](../leaderboards-and-stats-2017/leaderboards.md)
