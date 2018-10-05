---
title: ランキング
author: KevinAsgari
description: Xbox Live のランキングを使用してプレイヤーを比較する方法について説明します。
ms.assetid: 132604f9-6107-4479-9246-f8f497978db7
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 190d54fb53192a1cc798b46a0a4b76d7bdd3e074
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4385443"
---
# <a name="leaderboards"></a><span data-ttu-id="5ff9c-104">ランキング</span><span class="sxs-lookup"><span data-stu-id="5ff9c-104">Leaderboards</span></span>

## <a name="introduction"></a><span data-ttu-id="5ff9c-105">はじめに</span><span class="sxs-lookup"><span data-stu-id="5ff9c-105">Introduction</span></span>

<span data-ttu-id="5ff9c-106">「[データ プラットフォームの概要](../data-platform/data-platform.md)」で説明されているように、ランキングは、プレイヤー間の競争を促し、プレイヤー自身やフレンドが持つベスト スコアの更新に関心を持たせる場合に有効な方法です。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-106">As described in [Data Platform Overview](../data-platform/data-platform.md), Leaderboards are a great way to encourage competition between your players, and keep players engaged in trying to beat their previous best score as well as that of their friends.</span></span>

<span data-ttu-id="5ff9c-107">[注目の統計](stats2017.md#configured-stats-and-featured-leaderboards)のランキングはタイトルのゲーム ハブに常に表示され、ホーム ページにピン留めされているとき、タイトルの UI の一部として表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-107">Leaderboards for [Featured Stats](stats2017.md#configured-stats-and-featured-leaderboards) are always displayed in a title's Game Hub and sometimes displayed as a part of the UI for a title when it is pinned to the homepage.</span></span> <span data-ttu-id="5ff9c-108">タイトル内でランキングを作成するのに、構成済みの注目の統計を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-108">You can also use your configured Featured Stats to create Leaderboards inside of your title.</span></span>

## <a name="choosing-good-leaderboards"></a><span data-ttu-id="5ff9c-109">適切なランキングの選択</span><span class="sxs-lookup"><span data-stu-id="5ff9c-109">Choosing Good Leaderboards</span></span>

<span data-ttu-id="5ff9c-110">「[プレイヤーの統計](player-stats.md)」で説明したように、ランキングは定義した統計に対応しています。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-110">As discussed in [Player Stats](player-stats.md), a leaderboard corresponds to a stat that you have defined.</span></span>  <span data-ttu-id="5ff9c-111">プレイヤーが上を目指して努力し、達成できる実績に対応したランキングを選んでください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-111">You should choose leaderboards that correspond to an accomplishment that a player can work towards improving.</span></span>

<span data-ttu-id="5ff9c-112">たとえば、カー レーシング ゲームのベスト ラップ タイムは適切なランキングです。プレイヤーはベスト ラップ タイムを更新しようと努力するためです。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-112">For example, Best Lap Time in a car racing game is a good leaderboard, because players will want to work towards improving their Best Lap Time.</span></span>  <span data-ttu-id="5ff9c-113">他の例としては、戦闘ゲームにおける撃墜と死亡の割合や最大コンボ サイズなどがあります。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-113">Other examples are Kill/Death ratio, or Max Combo Size in a fighting game.</span></span>

## <a name="when-to-display-leaderboards"></a><span data-ttu-id="5ff9c-114">ランキングを表示するタイミング</span><span class="sxs-lookup"><span data-stu-id="5ff9c-114">When To Display Leaderboards</span></span>

<span data-ttu-id="5ff9c-115">ランキングはいつでもタイトルに表示できます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-115">You have the ability to display leaderboards at any time in your title.</span></span>  <span data-ttu-id="5ff9c-116">ランキングがゲームプレイやタイトルのフローを邪魔しない時間を選択してください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-116">You should choose a time when a leaderboard will not interfere with the gameplay or the flow of your title.</span></span>  <span data-ttu-id="5ff9c-117">ラウンドの合間、試合後などが適切なタイミングです。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-117">In between rounds, after matches, etc are all good times.</span></span>

## <a name="how-to-display-leaderboards"></a><span data-ttu-id="5ff9c-118">ランキングを表示する方法</span><span class="sxs-lookup"><span data-stu-id="5ff9c-118">How to Display Leaderboards</span></span>

<span data-ttu-id="5ff9c-119">Xbox Live SDK には、ランキングを表示するためのオプションが多数用意されています。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-119">There are numerous options for displaying leaderboards provided in the Xbox Live SDK.</span></span>  <span data-ttu-id="5ff9c-120">Xbox Live クリエーターズ プログラム で Unity を使用している場合、ランキング プレハブを使ってランキング データを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-120">If you are using Unity with the Xbox Live Creators Program, you can get started with using a Leaderboard Prefab to display your leaderboard data.</span></span>  <span data-ttu-id="5ff9c-121">詳しくは、「[Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-121">See the [Configure Xbox Live in Unity](../get-started-with-creators/configure-xbox-live-in-unity.md) article for specifics.</span></span>

<span data-ttu-id="5ff9c-122">Xbox Live SDK で直接コードを記述している場合、使用できる API についての説明をお読みください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-122">If you are coding against the Xbox Live SDK directly, then read on to learn about the APIs you can use.</span></span>

### <a name="programming-guide"></a><span data-ttu-id="5ff9c-123">プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="5ff9c-123">Programming Guide</span></span>

<span data-ttu-id="5ff9c-124">ランキングの現在の状態を取得する際に使用できるランキング API がいくつか用意されています。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-124">There are several Leaderboard APIs you can use to get the current state of a leaderboard.</span></span>  <span data-ttu-id="5ff9c-125">すべての API は非同期であり、ブロックしません。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-125">All of the APIs are asynchronous and do not block.</span></span>  <span data-ttu-id="5ff9c-126">ランキング データの取得要求を行い、通常のゲーム処理を続行します。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-126">You would make a request to get leaderboard data and continue your usual game processing.</span></span>  <span data-ttu-id="5ff9c-127">ランキング結果がサービスから返されたら、適切なタイミングで結果を表示できます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-127">When the leaderboard results are returned from the service, you can display the results at the appropriate time.</span></span>

<span data-ttu-id="5ff9c-128">プレイヤーがランキングの表示を待ってブロックされないように、サービスから提供されるランキング データは、表示する少し前に要求してください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-128">You should request the leaderboard data from the service, slightly ahead of when you want to display it, so that players are not blocked waiting for the leaderboard to display.</span></span>

<span data-ttu-id="5ff9c-129">すべてのランキング API については、`leaderboard_service` 名前空間をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-129">You can see the `leaderboard_service` namespace for all Leaderboard API.</span></span>

<table>

<tr>
<td><span data-ttu-id="5ff9c-130">C++ API</span><span class="sxs-lookup"><span data-stu-id="5ff9c-130">C++ API</span></span></td><td><span data-ttu-id="5ff9c-131">説明</span><span class="sxs-lookup"><span data-stu-id="5ff9c-131">Description</span></span></td>
</tr>

<tr>
<td markdown="block">

```cpp

pplx::task<xbox_live_result<leaderboard_result>> get_leaderboard(
        const string_t& scid,
        const string_t& name
        );
```

</td>

<td><span data-ttu-id="5ff9c-132">API の最も基本的なバージョン。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-132">Most basic version of the API.</span></span>  <span data-ttu-id="5ff9c-133">これにより、ランキング上位のプレイヤーから順番に、特定のランキングのランキング値が返されます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-133">This will return the leaderboard values for the given leaderboard, starting from the player at the top of the leaderboard.</span></span></td>

</tr>

<tr>
<td markdown="block">

```cpp

pplx::task<xbox_live_result<leaderboard_result>> get_leaderboard(
    _In_ const string_t& scid,
    _In_ const string_t& name,
    _In_ uint32_t skipToRank,
    _In_ uint32_t maxItems = 0
    );

```

</td>

<td><span data-ttu-id="5ff9c-134">この API にはある程度の柔軟性があり、表示するランク (順位) と返す項目の最大値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-134">This API provides some more flexibility, you can specify the rank (position) that you want to display, as well as a max value of items to return.</span></span>  <span data-ttu-id="5ff9c-135">たとえば、順位 1000 から始まるランキングを表示する場合に、この API を使用できます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-135">For example you would use this API if you wanted to display the leaderboard starting at position 1000.</span></span></td>

</tr>

<tr>

<td markdown="block">

```cpp

pplx::task<xbox_live_result<leaderboard_result>> get_leaderboard_skip_to_xuid(
    _In_ const string_t& scid,
    _In_ const string_t& name,
    _In_ const string_t& skipToXuid = string_t(),
    _In_ uint32_t maxItems = 0
    );

```

</td>

<td>

<span data-ttu-id="5ff9c-136">特定のユーザーまでランキングをスキップする場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-136">Use this if you want to skip the leaderboard to a certain user.</span></span>  <span data-ttu-id="5ff9c-137">`XUID` は、各 Xbox ユーザーの一意識別子です。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-137">A `XUID` is a unique identifier for each Xbox User.</span></span>  <span data-ttu-id="5ff9c-138">サインインしたユーザーや、そのユーザーのフレンドの XUID を取得して、この関数に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-138">You can obtain for the signed in user, or any one of their friends, and pass that into this function.</span></span>

</td>

</tr>

</table>

<span data-ttu-id="5ff9c-139">次に、サービスからランキング結果が返されたときに呼び出されるコールバックを設定できます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-139">You can then set a callback to be invoked once the Leaderboard results are returned from the service.</span></span>  <span data-ttu-id="5ff9c-140">以下にこの例を示します。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-140">We will show an example of this below.</span></span>

<span data-ttu-id="5ff9c-141">これらの API から返される `pplx::task` について簡単に説明すると、これは Microsoft 並列プログラミング ライブラリ (PPL) からの非同期タスク オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-141">If you are unfamiliar with the `pplx::task` being returned from these APIs, this is an asynchronous task object from the Microsoft Parallel Programming Library (PPL).</span></span>  <span data-ttu-id="5ff9c-142">詳しくは、[https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks](https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-142">You can learn more about that at [https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks](https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks).</span></span>

<span data-ttu-id="5ff9c-143">以下のセクションでは、ランキング結果を取得して使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-143">The section below shows how you might retrieve Leaderboard results and use them.</span></span>

### <a name="example"></a><span data-ttu-id="5ff9c-144">例</span><span class="sxs-lookup"><span data-stu-id="5ff9c-144">Example</span></span>

#### <a name="1-create-an-async-task-to-retrieve-leaderboard-results"></a><span data-ttu-id="5ff9c-145">1. 非同期タスクを作成してランキング結果を取得する</span><span class="sxs-lookup"><span data-stu-id="5ff9c-145">1. Create an async task to retrieve leaderboard results</span></span>

<span data-ttu-id="5ff9c-146">最初の手順として、ランキング サービスを呼び出して特定のランキングの結果を取得します。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-146">The first step is to call the Leaderboards service to retrieve the results for a particular leaderboard.</span></span>

```cpp
pplx::task<xbox_live_result<leaderboard_result>> asyncTask;
auto& leaderboardService = xboxLiveContext->leaderboard_service();

asyncTask = leaderboardService.get_leaderboard(m_liveResources->GetServiceConfigId(), LeaderboardIdEnemyDefeats);
```

#### <a name="2-setup-a-callback"></a><span data-ttu-id="5ff9c-147">2. コールバックをセットアップする</span><span class="sxs-lookup"><span data-stu-id="5ff9c-147">2. Setup a callback</span></span>

<span data-ttu-id="5ff9c-148">ランキング結果が返されたときに呼び出されるように、[継続タスク](https://msdn.microsoft.com/en-us/library/dd492427(v=vs.110).aspx#continuations)をセットアップできます。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-148">You can setup a [continuation task](https://msdn.microsoft.com/en-us/library/dd492427(v=vs.110).aspx#continuations) to be called once the leaderboard results.</span></span>  <span data-ttu-id="5ff9c-149">以下のように行います。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-149">You do that as follows below.</span></span>

```cpp
asyncTask.then([this](xbox::services::xbox_live_result<xbox::services::leaderboard::leaderboard_result> result)
{
    // Handle result here
});
```

<span data-ttu-id="5ff9c-150">この継続タスクは、最初に呼び出したオブジェクトのコンテキストで呼び出され、タイトルに合った方法で表示可能な ```leaderboard_result``` を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-150">This continuation task is called in the context of the object that originally invoked it, and receives the ```leaderboard_result``` which can be displayed in a manner that suits your title.</span></span>


#### <a name="3-display-leaderboard"></a><span data-ttu-id="5ff9c-151">3. ランキングを表示する</span><span class="sxs-lookup"><span data-stu-id="5ff9c-151">3. Display Leaderboard</span></span>

<span data-ttu-id="5ff9c-152">ランキング データは ```leaderboard_result``` に含まれており、フィールドは一目見ただけでその内容がわかります。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-152">The leaderboard data is contained in ```leaderboard_result``` and the fields are self explanatory.</span></span>  <span data-ttu-id="5ff9c-153">以下の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="5ff9c-153">See below for an example.</span></span>

```cpp
auto leaderboard = result.payload();

for (const xbox::services::leaderboard::leaderboard_row& row : leaderboard.rows())
{
    string_t colValues;
    for (auto columnValue : row.column_values())
    {
        colValues = colValues + L" ";
        colValues = colValues + columnValue;
    }
    m_console->Format(L"%18s %8d %14f %10s\n", row.gamertag().c_str(), row.rank(), row.percentile(), colValues.c_str());
}

```