---
title: ランキング
author: aablackm
description: Xbox Live のランキングを使用してプレイヤーを比較する方法について説明します。
ms.assetid: 132604f9-6107-4479-9246-f8f497978db7
ms.author: aablackm
ms.date: 09/28/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 25b0b16963147328a7ababf58634bcd9c134637a
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5550015"
---
# <a name="leaderboards"></a><span data-ttu-id="00584-104">ランキング</span><span class="sxs-lookup"><span data-stu-id="00584-104">Leaderboards</span></span>

## <a name="introduction"></a><span data-ttu-id="00584-105">はじめに</span><span class="sxs-lookup"><span data-stu-id="00584-105">Introduction</span></span>

<span data-ttu-id="00584-106">「[データ プラットフォームの概要](../data-platform/data-platform.md)」で説明されているように、ランキングは、プレイヤー間の競争を促し、プレイヤー自身やフレンドが持つベスト スコアの更新に関心を持たせる場合に有効な方法です。</span><span class="sxs-lookup"><span data-stu-id="00584-106">As described in [Data Platform Overview](../data-platform/data-platform.md), Leaderboards are a great way to encourage competition between your players, and keep players engaged in trying to beat their previous best score as well as that of their friends.</span></span>

<span data-ttu-id="00584-107">[注目の統計](stats2017.md#configured-stats-and-featured-leaderboards)のランキングは常に、タイトルのゲーム ハブに表示され、ホームページにピン留めされているとき、タイトルの UI の一部として表示される場合があります。</span><span class="sxs-lookup"><span data-stu-id="00584-107">Leaderboards for [Featured Stats](stats2017.md#configured-stats-and-featured-leaderboards) are always displayed in a title's Game Hub and sometimes displayed as a part of the UI for a title when it is pinned to the homepage.</span></span> <span data-ttu-id="00584-108">タイトル内でランキングを作成するのに、構成済みの注目の統計を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="00584-108">You can also use your configured Featured Stats to create Leaderboards inside of your title.</span></span>

## <a name="choosing-good-leaderboards"></a><span data-ttu-id="00584-109">適切なランキングの選択</span><span class="sxs-lookup"><span data-stu-id="00584-109">Choosing Good Leaderboards</span></span>

<span data-ttu-id="00584-110">「[プレイヤーの統計](player-stats.md)」で説明したように、ランキングは定義した統計に対応しています。</span><span class="sxs-lookup"><span data-stu-id="00584-110">As discussed in [Player Stats](player-stats.md), a leaderboard corresponds to a stat that you have defined.</span></span>  <span data-ttu-id="00584-111">プレイヤーが上を目指して努力し、達成できる実績に対応したランキングを選んでください。</span><span class="sxs-lookup"><span data-stu-id="00584-111">You should choose leaderboards that correspond to an accomplishment that a player can work towards improving.</span></span>

<span data-ttu-id="00584-112">たとえば、レーシング ゲームでのベスト ラップ_タイムはプレイヤーはベスト ラップ_タイムと努力するため、適切なランキングです。</span><span class="sxs-lookup"><span data-stu-id="00584-112">For example, Best Lap Time in a racing game is a good leaderboard, because players will want to work towards improving their Best Lap Time.</span></span>  <span data-ttu-id="00584-113">他の例は、ガン、や最大コンボ サイズの戦闘ゲームでの/死亡の割合です。</span><span class="sxs-lookup"><span data-stu-id="00584-113">Other examples are Kill/Death ratio for shooters, or Max Combo Size in a fighting game.</span></span>

## <a name="when-to-display-leaderboards"></a><span data-ttu-id="00584-114">ランキングを表示するタイミング</span><span class="sxs-lookup"><span data-stu-id="00584-114">When To Display Leaderboards</span></span>

<span data-ttu-id="00584-115">ランキングはいつでもタイトルに表示できます。</span><span class="sxs-lookup"><span data-stu-id="00584-115">You have the ability to display leaderboards at any time in your title.</span></span>  <span data-ttu-id="00584-116">ランキングがゲームプレイやタイトルのフローを邪魔しない時間を選択してください。</span><span class="sxs-lookup"><span data-stu-id="00584-116">You should choose a time when a leaderboard will not interfere with the gameplay or the flow of your title.</span></span>  <span data-ttu-id="00584-117">ラウンドの合間し、後の一致は両方の適切なタイミングです。</span><span class="sxs-lookup"><span data-stu-id="00584-117">In between rounds and after matches are both good times.</span></span>

## <a name="how-to-display-leaderboards"></a><span data-ttu-id="00584-118">ランキングを表示する方法</span><span class="sxs-lookup"><span data-stu-id="00584-118">How to Display Leaderboards</span></span>

<span data-ttu-id="00584-119">Xbox Live SDK には、ランキングを表示するためのオプションが多数用意されています。</span><span class="sxs-lookup"><span data-stu-id="00584-119">There are numerous options for displaying leaderboards provided in the Xbox Live SDK.</span></span>  <span data-ttu-id="00584-120">Xbox Live クリエーターズ プログラムで Unity を使用する場合は、ランキング データを表示する、ランキング プレハブを使用して開始できます。</span><span class="sxs-lookup"><span data-stu-id="00584-120">If you are using Unity with the Xbox Live Creators Program, you can get started by using a Leaderboard Prefab to display your leaderboard data.</span></span>  <span data-ttu-id="00584-121">詳しくは、「[Unity で Xbox Live を構成する](../get-started-with-creators/configure-xbox-live-in-unity.md)」の記事をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00584-121">See the [Configure Xbox Live in Unity](../get-started-with-creators/configure-xbox-live-in-unity.md) article for specifics.</span></span>

<span data-ttu-id="00584-122">Xbox Live SDK で直接コードを記述している場合、使用できる API についての説明をお読みください。</span><span class="sxs-lookup"><span data-stu-id="00584-122">If you are coding against the Xbox Live SDK directly, then read on to learn about the APIs you can use.</span></span>

## <a name="programming-guide"></a><span data-ttu-id="00584-123">プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="00584-123">Programming Guide</span></span>

<span data-ttu-id="00584-124">ランキングの現在の状態を取得する際に使用できるランキング API がいくつか用意されています。</span><span class="sxs-lookup"><span data-stu-id="00584-124">There are several Leaderboard APIs you can use to get the current state of a leaderboard.</span></span>  <span data-ttu-id="00584-125">すべての API は非同期であり、ブロックしません。</span><span class="sxs-lookup"><span data-stu-id="00584-125">All of the APIs are asynchronous and do not block.</span></span>  <span data-ttu-id="00584-126">ランキング データの取得要求を行い、通常のゲーム処理を続行します。</span><span class="sxs-lookup"><span data-stu-id="00584-126">You would make a request to get leaderboard data and continue your usual game processing.</span></span>  <span data-ttu-id="00584-127">ランキング結果がサービスから返されたら、適切なタイミングで結果を表示できます。</span><span class="sxs-lookup"><span data-stu-id="00584-127">When the leaderboard results are returned from the service, you can display the results at the appropriate time.</span></span>

<span data-ttu-id="00584-128">プレイヤーがランキングの表示を待ってブロックされないように、サービスから提供されるランキング データは、表示する少し前に要求してください。</span><span class="sxs-lookup"><span data-stu-id="00584-128">You should request the leaderboard data from the service, slightly ahead of when you want to display it, so that players are not blocked waiting for the leaderboard to display.</span></span>

## <a name="leaderboards-2013-apis"></a><span data-ttu-id="00584-129">ランキング 2013 Api</span><span class="sxs-lookup"><span data-stu-id="00584-129">Leaderboards 2013 APIs</span></span>

<span data-ttu-id="00584-130">表示できます、`leaderboard_service`名前空間のすべての統計 2013年のランキング API についています。</span><span class="sxs-lookup"><span data-stu-id="00584-130">You can see the `leaderboard_service` namespace for all Stats 2013 Leaderboard API.</span></span>

<table>

<tr>
<td><span data-ttu-id="00584-131">C++ API</span><span class="sxs-lookup"><span data-stu-id="00584-131">C++ API</span></span></td><td><span data-ttu-id="00584-132">説明</span><span class="sxs-lookup"><span data-stu-id="00584-132">Description</span></span></td>
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

<td><span data-ttu-id="00584-133">API の最も基本的なバージョン。</span><span class="sxs-lookup"><span data-stu-id="00584-133">Most basic version of the API.</span></span>  <span data-ttu-id="00584-134">これにより、ランキング上位のプレイヤーから順番に、特定のランキングのランキング値が返されます。</span><span class="sxs-lookup"><span data-stu-id="00584-134">This will return the leaderboard values for the given leaderboard, starting from the player at the top of the leaderboard.</span></span></td>

</tr>

<tr>

<td markdown="block">

```csharp
Windows::Foundation::IAsyncOperation< LeaderboardResult^> ^  GetLeaderboardAsync (
        _In_ Platform::String^ serviceConfigurationId,
         _In_ Platform::String^ leaderboardName
        ) 
```

</td>

<td><span data-ttu-id="00584-135">WinRT の c# コードでは、サービス構成 ID とランキングの名前を指定する 1 つのランキングのランキングを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-135">WinRT C# Code - Get a leaderboard for a single leaderboard given a service configuration ID and a leaderboard name.</span></span></td>

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

<td><span data-ttu-id="00584-136">この API にはある程度の柔軟性があり、表示するランク (順位) と返す項目の最大値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="00584-136">This API provides some more flexibility, you can specify the rank (position) that you want to display, as well as a max value of items to return.</span></span>  <span data-ttu-id="00584-137">たとえば、順位 1000 から始まるランキングを表示する場合に、この API を使用できます。</span><span class="sxs-lookup"><span data-stu-id="00584-137">For example you would use this API if you wanted to display the leaderboard starting at position 1000.</span></span></td>

</tr>

<tr>

<td markdown="block">

```csharp
Windows::Foundation::IAsyncOperation< LeaderboardResult^> ^  GetLeaderboardAsync (
         _In_ Platform::String^ serviceConfigurationId,
         _In_ Platform::String^ leaderboardName,
         _In_ uint32 skipToRank,
         _In_ uint32 maxItems
        ) 
```

</td>

<td><span data-ttu-id="00584-138">WinRT の c# コードの 1 つのランキングのランキングのページが結果を取得、サービス構成 ID とランキング名の"skipToRank"ランクにランキング結果が開始されます。</span><span class="sxs-lookup"><span data-stu-id="00584-138">WinRT C# code - Get a page of leaderboard results for a single leaderboard give a service configuration ID and a leaderboard name, leaderboard results will start at the "skipToRank" rank.</span></span></td>

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

<span data-ttu-id="00584-139">特定のユーザーまでランキングをスキップする場合に使用します。</span><span class="sxs-lookup"><span data-stu-id="00584-139">Use this if you want to skip the leaderboard to a certain user.</span></span>  <span data-ttu-id="00584-140">`XUID` は、各 Xbox ユーザーの一意識別子です。</span><span class="sxs-lookup"><span data-stu-id="00584-140">A `XUID` is a unique identifier for each Xbox User.</span></span>  <span data-ttu-id="00584-141">サインインしたユーザーや、そのユーザーのフレンドの XUID を取得して、この関数に渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="00584-141">You can obtain for the signed in user, or any one of their friends, and pass that into this function.</span></span>

</td>

</tr>

<tr>

<td markdown="block">

```csharp
Windows::Foundation::IAsyncOperation< LeaderboardResult^> ^  GetLeaderboardWithSkipToUserAsync (
         _In_ Platform::String^ serviceConfigurationId,
         _In_ Platform::String^ leaderboardName,
         _In_opt_ Platform::String^ skipToXboxUserId,
         _In_ uint32 maxItems
        )
```

</td>

<td><span data-ttu-id="00584-142">WinRT の c# コードのプレイヤーのランクに関係なく、指定されたプレイヤーから始まるランキングを取得またはスコア、プレイヤーの位ランク順に</span><span class="sxs-lookup"><span data-stu-id="00584-142">WinRT C# code - Get a leaderboard starting at a specified player, regardless of the player's rank or score, ordered by the player's percentile rank</span></span></td>

</tr>

</table>

## <a name="2013-c-example"></a><span data-ttu-id="00584-143">2013 の C++ の例</span><span class="sxs-lookup"><span data-stu-id="00584-143">2013 C++ Example</span></span>

<span data-ttu-id="00584-144">C++ API レイヤーを使用する場合は、サービスからランキング結果が返されたに呼び出されるコールバックを設定できます。</span><span class="sxs-lookup"><span data-stu-id="00584-144">When using the C++ API layer you can then set a callback to be invoked once the Leaderboard results are returned from the service.</span></span>  <span data-ttu-id="00584-145">以下にこの例を示します。</span><span class="sxs-lookup"><span data-stu-id="00584-145">We will show an example of this below.</span></span>

<span data-ttu-id="00584-146">これらの API から返される `pplx::task` について簡単に説明すると、これは Microsoft 並列プログラミング ライブラリ (PPL) からの非同期タスク オブジェクトです。</span><span class="sxs-lookup"><span data-stu-id="00584-146">If you are unfamiliar with the `pplx::task` being returned from these APIs, this is an asynchronous task object from the Microsoft Parallel Programming Library (PPL).</span></span>  <span data-ttu-id="00584-147">詳しくは、[https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks](https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks) を参照してください。</span><span class="sxs-lookup"><span data-stu-id="00584-147">You can learn more about that at [https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks](https://github.com/Microsoft/cpprestsdk/wiki/Programming-with-Tasks).</span></span>

<span data-ttu-id="00584-148">以下のセクションでは、ランキング結果を取得して使用する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="00584-148">The section below shows how you might retrieve Leaderboard results and use them.</span></span>

### <a name="1-create-an-async-task-to-retrieve-leaderboard-results"></a><span data-ttu-id="00584-149">1. 非同期タスクを作成してランキング結果を取得する</span><span class="sxs-lookup"><span data-stu-id="00584-149">1. Create an async task to retrieve leaderboard results</span></span>

<span data-ttu-id="00584-150">最初の手順として、ランキング サービスを呼び出して特定のランキングの結果を取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-150">The first step is to call the Leaderboards service to retrieve the results for a particular leaderboard.</span></span>

```cpp
pplx::task<xbox_live_result<leaderboard_result>> asyncTask;
auto& leaderboardService = xboxLiveContext->leaderboard_service();

asyncTask = leaderboardService.get_leaderboard(m_liveResources->GetServiceConfigId(), LeaderboardIdEnemyDefeats);
```

### <a name="2-setup-a-callback"></a><span data-ttu-id="00584-151">2. コールバックをセットアップする</span><span class="sxs-lookup"><span data-stu-id="00584-151">2. Setup a callback</span></span>

<span data-ttu-id="00584-152">ランキング結果が返されると呼び出される、[継続タスク](https://msdn.microsoft.com/en-us/library/dd492427(v=vs.110).aspx#continuations)をセットアップすることができます。</span><span class="sxs-lookup"><span data-stu-id="00584-152">You can setup a [continuation task](https://msdn.microsoft.com/en-us/library/dd492427(v=vs.110).aspx#continuations) to be called once the leaderboard results are returned.</span></span>  <span data-ttu-id="00584-153">以下のように行います。</span><span class="sxs-lookup"><span data-stu-id="00584-153">You do that as follows below.</span></span>

```cpp
asyncTask.then([this](xbox::services::xbox_live_result<xbox::services::leaderboard::leaderboard_result> result)
{
    // Handle result here
});
```

<span data-ttu-id="00584-154">この継続タスクは、最初に呼び出したオブジェクトのコンテキストで呼び出され、タイトルに合った方法で表示可能な ```leaderboard_result``` を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="00584-154">This continuation task is called in the context of the object that originally invoked it, and receives the ```leaderboard_result``` which can be displayed in a manner that suits your title.</span></span>


### <a name="3-display-leaderboard"></a><span data-ttu-id="00584-155">3. ランキングを表示する</span><span class="sxs-lookup"><span data-stu-id="00584-155">3. Display Leaderboard</span></span>

<span data-ttu-id="00584-156">ランキング データは ```leaderboard_result``` に含まれており、フィールドは一目見ただけでその内容がわかります。</span><span class="sxs-lookup"><span data-stu-id="00584-156">The leaderboard data is contained in ```leaderboard_result``` and the fields are self explanatory.</span></span>  <span data-ttu-id="00584-157">以下の例をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="00584-157">See below for an example.</span></span>

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

## <a name="2013-winrt-c-example"></a><span data-ttu-id="00584-158">2013 WinRT c# の例</span><span class="sxs-lookup"><span data-stu-id="00584-158">2013 WinRT C# Example</span></span>

<span data-ttu-id="00584-159">WinRT c# レイヤーを使用する場合は、タスクし、使用する必要があるだけでは、それぞれ個別のコールバックを作成する必要はありません、`await`ランキング サービスを呼び出すときにキーワードです。</span><span class="sxs-lookup"><span data-stu-id="00584-159">When using the WinRT C# layer you will not need to make a separate callback task and will simply need to use the `await` keyword when calling the leaderboard service.</span></span>

### <a name="1-access-the-leaderboardservice"></a><span data-ttu-id="00584-160">1. アクセス、LeaderboardService</span><span class="sxs-lookup"><span data-stu-id="00584-160">1. Access the LeaderboardService</span></span>

<span data-ttu-id="00584-161">`LeaderboardService`から取得できる、`XboxLiveContext`をゲームに、ユーザーにサインインするときに作成、必要になるのランキング データを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="00584-161">The `LeaderboardService` can be retrieved from the `XboxLiveContext` created when signing in a user to the game, you will need it to call for leaderboard data.</span></span>

```csharp
XboxLiveContext xboxLiveContext = idManager.xboxLiveContext;
LeaderboardService boardService = xboxLiveContext.LeaderboardService;
```

### <a name="2-call-the-leaderboardservice"></a><span data-ttu-id="00584-162">2. 呼び出し、LeaderboardService</span><span class="sxs-lookup"><span data-stu-id="00584-162">2. Call the LeaderboardService</span></span>

```csharp
LeaderboardResult boardResult = await boardService.GetLeaderboardAsync(
     xboxLiveConfig.ServiceConfigurationId,
     leaderboardName
     );
```

### <a name="3-retrieve-leaderboard-data"></a><span data-ttu-id="00584-163">3. ランキング データを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-163">3. Retrieve Leaderboard data</span></span>

`GetLeaderboardAsync()` <span data-ttu-id="00584-164">返します、`LeaderboardResult`これは、名前付きのランキングを作成する統計情報が含まれます。</span><span class="sxs-lookup"><span data-stu-id="00584-164">returns a `LeaderboardResult` which will contain the statistics populating the named leaderboard.</span></span>

`LeaderboardResult` <span data-ttu-id="00584-165">いくつかの関数とプロパティをランキング データの読み取りを容易にあります。</span><span class="sxs-lookup"><span data-stu-id="00584-165">has several functions and properties to facilitate the reading of leaderboard data.</span></span>

|<span data-ttu-id="00584-166">プロパティ</span><span class="sxs-lookup"><span data-stu-id="00584-166">Property</span></span>  |<span data-ttu-id="00584-167">説明</span><span class="sxs-lookup"><span data-stu-id="00584-167">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="00584-168">パブリック IAsyncOperation<LeaderboardResult> GetNextAsync (uint maxItems)。</span><span class="sxs-lookup"><span data-stu-id="00584-168">public IAsyncOperation<LeaderboardResult> GetNextAsync(uint maxItems);</span></span>     |<span data-ttu-id="00584-169">次の一連の maxItems パラメーターの数までのランクを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-169">Retrieves the next set of ranks up to the number of the maxItems parameter.</span></span> <span data-ttu-id="00584-170">これは、基本的に別の呼び出し</span><span class="sxs-lookup"><span data-stu-id="00584-170">This is essentially another call to</span></span> `GetLeaderboard()`         |
|<span data-ttu-id="00584-171">パブリック LeaderboardQuery GetNextQuery() です。</span><span class="sxs-lookup"><span data-stu-id="00584-171">public LeaderboardQuery GetNextQuery();</span></span>     |<span data-ttu-id="00584-172">次の一連のデータを取得するランキングの呼び出しに使われる LeaderboardQuery を取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-172">Retrieves the LeaderboardQuery that could be used to make the Leaderboard call to retrieve the next set of data.</span></span>         |
|<span data-ttu-id="00584-173">パブリック bool HasNext {get;}</span><span class="sxs-lookup"><span data-stu-id="00584-173">public bool HasNext { get; }</span></span>    |<span data-ttu-id="00584-174">ランキング行が取得するかどうかを指定します。</span><span class="sxs-lookup"><span data-stu-id="00584-174">designates whether or not there are more leaderboard rows to retrieve</span></span>         |
|<span data-ttu-id="00584-175">パブリック IReadOnlyList<LeaderboardRow>行 {get;}</span><span class="sxs-lookup"><span data-stu-id="00584-175">public IReadOnlyList<LeaderboardRow> Rows { get; }</span></span>     | <span data-ttu-id="00584-176">ランクごとのランキング データを含む行</span><span class="sxs-lookup"><span data-stu-id="00584-176">Rows containing Leaderboard data per rank</span></span>        |
|<span data-ttu-id="00584-177">パブリック IReadOnlyList<LeaderboardColumn>列 {get;}</span><span class="sxs-lookup"><span data-stu-id="00584-177">public IReadOnlyList<LeaderboardColumn> Columns { get; }</span></span>     | <span data-ttu-id="00584-178">ランキングを構成する列のリスト</span><span class="sxs-lookup"><span data-stu-id="00584-178">The list of columns that make up the leaderboard</span></span>        |
|<span data-ttu-id="00584-179">パブリック uint TotalRowCount {get;}</span><span class="sxs-lookup"><span data-stu-id="00584-179">public uint TotalRowCount { get; }</span></span>     | <span data-ttu-id="00584-180">ランキングの行の合計金額</span><span class="sxs-lookup"><span data-stu-id="00584-180">Total amount of rows in Leaderboard</span></span>        |
|<span data-ttu-id="00584-181">パブリック文字列 DisplayName {get;}</span><span class="sxs-lookup"><span data-stu-id="00584-181">public string DisplayName { get; }</span></span>     | <span data-ttu-id="00584-182">ランキングを表示する名前</span><span class="sxs-lookup"><span data-stu-id="00584-182">Name to be displayed for Leaderboard</span></span>       |

<span data-ttu-id="00584-183">ランキング データが、一度に 1 つのページを提供されます。</span><span class="sxs-lookup"><span data-stu-id="00584-183">Leaderboard data will be provided one page at a time.</span></span> <span data-ttu-id="00584-184">ループする可能性があります、`LeaderboardResult`行と列は、データを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-184">You may loop through the `LeaderboardResult` Rows and Columns to retrieve the data.</span></span>  
<span data-ttu-id="00584-185">使用して、`HasNext`ブール値と`GetNextAsync()`ランキング データの以降のページを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-185">Use the `HasNext` boolean and `GetNextAsync()` function to retrieve later pages of Leaderboard data.</span></span>

```csharp
if (boardResult != null)
{
    foreach (LeaderboardRow row in boardResult.Rows)
    {
        Debug.Write(string.Format("Rank: {0} | Gamertag: {1} | {2}\n", row.Rank, row.Gamertag, row.Values.ToString()));
    }
}
```

## <a name="leaderboard-2017"></a><span data-ttu-id="00584-186">ランキング 2017</span><span class="sxs-lookup"><span data-stu-id="00584-186">Leaderboard 2017</span></span>

<span data-ttu-id="00584-187">使用する統計 2017年ランキング サービスへの呼び出しを`StatisticManager`ランキング api の代わりに、`LeaderboardService`ランキング api です。</span><span class="sxs-lookup"><span data-stu-id="00584-187">To make calls to the Stats 2017 Leaderboard service you will use the `StatisticManager` leaderboard apis instead of the `LeaderboardService` leaderboard apis.</span></span>  

`xbox::services::stats:manager::stats_manager::get_leaderboard`  

```cpp
xbox_live_result< void >  get_leaderboard (
     _In_ const xbox_live_user_t &user,
     _In_ const string_t &statName,
     _In_ leaderboard::leaderboard_query query
     ) 
```  

`xbox::services::stats:manager::stats_manager::get_leaderboard`  

```cpp
xbox_live_result< void >  get_social_leaderboard (_In_ const xbox_live_user_t &user,
     _In_ const string_t &statName,
     _In_ const string_t &socialGroup,
     _In_ leaderboard::leaderboard_query query
)
```  

`Microsoft.Xbox.Services.Statistics.Manager.StatisticManager.GetLeaderboard`  

```csharp
public void GetLeaderboard(
    XboxLiveUser user,
    string statName,
    LeaderboardQuery query
    )
```  

`Microsoft.Xbox.Services.Statistics.Manager.StatisticManager.GetSocialLeaderboard`  

```csharp
public void GetSocialLeaderboard(
    XboxLiveUser user,
    string statName,
    string socialGroup,
    LeaderboardQuery query
    )
```  

## <a name="2017-c-example"></a><span data-ttu-id="00584-188">2017 C++ の例</span><span class="sxs-lookup"><span data-stu-id="00584-188">2017 C++ Example</span></span>

### <a name="1-get-a-singleton-instance-of-the-statsmanager"></a><span data-ttu-id="00584-189">1.、stats_manager のシングルトン インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-189">1. Get a Singleton Instance of the stats_manager</span></span>

<span data-ttu-id="00584-190">呼び出す前に、`stats_manager`関数シングルトン インスタンスに変数を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00584-190">Before you can call the `stats_manager` functions you will need to set a variable to it's Singleton Instance.</span></span>

```csharp
m_statsManager = stats_manager::get_singleton_instance();
```

### <a name="2-create-a-leaderboardquery"></a><span data-ttu-id="00584-191">2.、LeaderboardQuery を作成します。</span><span class="sxs-lookup"><span data-stu-id="00584-191">2. Create a LeaderboardQuery</span></span>

<span data-ttu-id="00584-192">`leaderboard_query`金額、順序を決定し、ランキングの呼び出しから返されるデータのポイントを開始します。</span><span class="sxs-lookup"><span data-stu-id="00584-192">The `leaderboard_query` will dictate the amount, order, and starting point of the data returned from the leaderboard call.</span></span>

<span data-ttu-id="00584-193">A`leaderboard_query`にいくつかの属性設定できるが返されるデータに影響があります。</span><span class="sxs-lookup"><span data-stu-id="00584-193">A `leaderboard_query` has a few attributes that can be set which will effect the data returned:</span></span>

|<span data-ttu-id="00584-194">プロパティ</span><span class="sxs-lookup"><span data-stu-id="00584-194">Property</span></span> |<span data-ttu-id="00584-195">説明</span><span class="sxs-lookup"><span data-stu-id="00584-195">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="00584-196">m_skipResultToRank</span><span class="sxs-lookup"><span data-stu-id="00584-196">m_skipResultToRank</span></span>     |<span data-ttu-id="00584-197">ランキング データをランク付けは開始を返す場合、この uint 変数が決定されます。</span><span class="sxs-lookup"><span data-stu-id="00584-197">this uint variable will determine what ranking the leaderboard data will start with when returning.</span></span> <span data-ttu-id="00584-198">ランキングは、ランク 1 から始まります。</span><span class="sxs-lookup"><span data-stu-id="00584-198">Rankings start at rank 1.</span></span>         |
|<span data-ttu-id="00584-199">m_skipResultToMe</span><span class="sxs-lookup"><span data-stu-id="00584-199">m_skipResultToMe</span></span>     |<span data-ttu-id="00584-200">かどうかに設定をこのブール値を true には、開始時刻から返されるランキング データ、`XboxLiveUser`で使用される、`get_leaderboard()`呼び出します。</span><span class="sxs-lookup"><span data-stu-id="00584-200">if set to true this boolean value will cause the leaderboard data returned to start at the `XboxLiveUser` used in the `get_leaderboard()` call.</span></span>  |
|<span data-ttu-id="00584-201">m_order</span><span class="sxs-lookup"><span data-stu-id="00584-201">m_order</span></span>     |<span data-ttu-id="00584-202">列挙型の`xbox::services::leaderboard::sort_order`は昇順であり、降順で 2 つの可能な値があります。</span><span class="sxs-lookup"><span data-stu-id="00584-202">Enums of type `xbox::services::leaderboard::sort_order` have two possible values, ascending, and descending.</span></span> <span data-ttu-id="00584-203">クエリのこの変数を設定すると、ランキングの並べ替え順序を決定します。</span><span class="sxs-lookup"><span data-stu-id="00584-203">Setting this variable for your query will determine the sort order of your leaderboard.</span></span>        |
|<span data-ttu-id="00584-204">m_maxItems</span><span class="sxs-lookup"><span data-stu-id="00584-204">m_maxItems</span></span>     |<span data-ttu-id="00584-205">この uint 呼び出しごとに返す行の最大数を決定する`get_leaderboard`または`get_social_leaderboard()`します。</span><span class="sxs-lookup"><span data-stu-id="00584-205">This uint determines the maximum number of rows to return per call to `get_leaderboard` or `get_social_leaderboard()`.</span></span>         |

`leaderboard_query` <span data-ttu-id="00584-206">いくつかのセット関数を使って、これらのプロパティに値を割り当てるがあります。</span><span class="sxs-lookup"><span data-stu-id="00584-206">has several set function you can use to assign value to these properties.</span></span> <span data-ttu-id="00584-207">次のコードでは説明をセットアップする方法、</span><span class="sxs-lookup"><span data-stu-id="00584-207">The following code will show you how to setup your</span></span> `leaderboard_query`

```cpp
leaderboard::leaderboard_query leaderboardQuery;
leaderboardQuery.set_skip_result_to_rank(10);
leaderboardQuery.set_max_items(10);
leaderboardQuery.set_order(sort_order::descending);
```

<span data-ttu-id="00584-208">このクエリ戻ったら、100 から始まるランキングの 10 行がランク付け個々 します。</span><span class="sxs-lookup"><span data-stu-id="00584-208">This query would return ten rows of the leaderboard starting at the 100th ranked individual.</span></span>

> [!WARNING]
> <span data-ttu-id="00584-209">ランキング内に含まれるプレイヤーの数よりも高い SkipResultToRank が発生 0 行を返すランキング データ。</span><span class="sxs-lookup"><span data-stu-id="00584-209">Setting SkipResultToRank higher than the number of players contained within the leaderboard will cause the leaderboard data to return with zero rows.</span></span>

### <a name="3-call-getleaderboard"></a><span data-ttu-id="00584-210">3. get_leaderboard を呼び出す</span><span class="sxs-lookup"><span data-stu-id="00584-210">3. Call get_leaderboard</span></span>

```cpp
leaderboard::leaderboard_query leaderboardQuery;
m_statsManager->get_leaderboard(user, statName, leaderboardQuery);
```

> [!IMPORTANT]
> <span data-ttu-id="00584-211">`statName`で使用される、`GetLeaderboard()`呼び出しは小文字が区別されます、 [Windows デベロッパー センター ダッシュ ボード](https://developer.microsoft.com/en-us/dashboard/windows/overview)でタイトル用に構成された統計の名前と同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="00584-211">The `statName` used in the `GetLeaderboard()` call must be the same as the name of a stat configured for your title on its [Windows Dev Center dashboard](https://developer.microsoft.com/en-us/dashboard/windows/overview), which is case-sensitive.</span></span>

### <a name="4-read-the-leaderboard-data"></a><span data-ttu-id="00584-212">4. ランキング データを読み取る</span><span class="sxs-lookup"><span data-stu-id="00584-212">4. Read the Leaderboard data</span></span>

<span data-ttu-id="00584-213">呼び出す必要がありますランキング データを読み取るために、`stats_manager::do_work()`の一覧を返す関数`stat_event`値。</span><span class="sxs-lookup"><span data-stu-id="00584-213">In order to read the leaderboard data you will need to call the `stats_manager::do_work()` function which will return a list of `stat_event` values.</span></span> <span data-ttu-id="00584-214">ランキング データは含まれている、`stat_event`型の`stat_event_type::get_leaderboard_complete`します。</span><span class="sxs-lookup"><span data-stu-id="00584-214">Leaderboard data will be contained in a `stat_event` of the type `stat_event_type::get_leaderboard_complete`.</span></span> <span data-ttu-id="00584-215">この種類の一覧でのイベントが発生したとき`stat_event`s に目を通すことがあります、`leaderboard_result`に含まれている、`stat_event`データにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="00584-215">When you come across an event of this type in the list of `stat_event`s you may look through the `leaderboard_result` contained in the `stat_event` to access the data.</span></span>

<span data-ttu-id="00584-216">サンプル`do_work()`ハンドラー</span><span class="sxs-lookup"><span data-stu-id="00584-216">Sample `do_work()` handler</span></span>

```cpp
void Sample::UpdateStatsManager()
{
    // Process events from the stats manager
    // This should be called each frame update

    auto statsEvents = m_statsManager->do_work();
    std::wstring text;

    for (const auto& evt : statsEvents)
    {
        switch (evt.event_type())
        {
            case stat_event_type::local_user_added: 
                text = L"local_user_added"; 
                break;

            case stat_event_type::local_user_removed: 
                text = L"local_user_removed"; 
                break;

            case stat_event_type::stat_update_complete: 
                text = L"stat_update_complete"; 
                break;

            case stat_event_type::get_leaderboard_complete: //leaderboard data is read here
                text = L"get_leaderboard_complete";
                auto getLeaderboardCompleteArgs = std::dynamic_pointer_cast<leaderboard_result_event_args>(evt.event_args());
                ProcessLeaderboards(evt.local_user(), getLeaderboardCompleteArgs->result());
                break;
        }

        stringstream_t source;
        source << _T("StatsManager event: ");
        source << text;
        source << _T(".");
        m_console->WriteLine(source.str().c_str());
    }
}
```

<span data-ttu-id="00584-217">ランキング結果からランキング データを読み取る</span><span class="sxs-lookup"><span data-stu-id="00584-217">Reading the Leaderboard data from the Leaderboard Result</span></span>  

```cpp
void Sample::PrintLeaderboard(const xbox::services::leaderboard::leaderboard_result& leaderboard)
{
    if (leaderboard.rows().size() > 0)
    {
        m_console->Format(L"%16s %6s %12s %12s\n", L"Gamertag", L"Rank", L"Percentile", L"Values");
    }

    for (const xbox::services::leaderboard::leaderboard_row& row : leaderboard.rows())
    {
        string_t colValues;
        for (auto columnValue : row.column_values())
        {
            colValues = colValues + L" ";
            colValues = colValues + columnValue;
        }
        m_console->Format(L"%16s %6d %12f %12s\n", row.gamertag().c_str(), row.rank(), row.percentile(), colValues.c_str());
    }
}
```  

<span data-ttu-id="00584-218">ランキングからさらにページのデータを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-218">Retrieve further pages of data from the leaderboard.</span></span>  

```cpp
void Sample::ProcessLeaderboards(
    _In_ std::shared_ptr<xbox::services::system::xbox_live_user> user,
    _In_ xbox::services::xbox_live_result<xbox::services::leaderboard::leaderboard_result> result
    )
{
    if (!result.err())
    {
        auto leaderboardResult = result.payload();
        PrintLeaderboard(leaderboardResult);

        // Keep processing if there is more data in the leaderboard
        if (leaderboardResult.has_next())
        {
            if (!leaderboardResult.get_next_query().err())
            {               
                auto lbQuery = leaderboardResult.get_next_query().payload();
                if (lbQuery.social_group().empty())
                {
                    m_statsManager->get_leaderboard(user, lbQuery.stat_name(), lbQuery);
                }
                else
                {
                    m_statsManager->get_social_leaderboard(user, lbQuery.stat_name(), lbQuery.social_group(), lbQuery);
                }
            }
        }
    }
}
```  

## <a name="2017-winrt-c-example"></a><span data-ttu-id="00584-219">2017 WinRT c# の例</span><span class="sxs-lookup"><span data-stu-id="00584-219">2017 WinRT C# Example</span></span>

### <a name="1-get-a-singleton-instance-of-the-statisticmanager"></a><span data-ttu-id="00584-220">1.、StatisticManager のシングルトン インスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-220">1. Get a singleton instance of the StatisticManager</span></span>

<span data-ttu-id="00584-221">呼び出す前に、`StatisticManager`関数シングルトン インスタンスに変数を設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00584-221">Before you can call the `StatisticManager` functions you will need to set a variable to it's Singleton Instance.</span></span>

```csharp
statManager = StatisticManager.SingletonInstance;
```

### <a name="2-create-a-leaderboardquery"></a><span data-ttu-id="00584-222">2.、LeaderboardQuery を作成します。</span><span class="sxs-lookup"><span data-stu-id="00584-222">2. Create a LeaderboardQuery</span></span>

<span data-ttu-id="00584-223">`LeaderboardQuery`金額、順序を決定し、ランキングの呼び出しから返されるデータのポイントを開始します。</span><span class="sxs-lookup"><span data-stu-id="00584-223">The `LeaderboardQuery` will dictate the amount, order, and starting point of the data returned from the leaderboard call.</span></span>  

```csharp
public sealed class LeaderboardQuery : __ILeaderboardQueryPublicNonVirtuals
    {
        [Overload("CreateInstance1")]
        public LeaderboardQuery();

        public bool HasNext { get; }
        public string SocialGroup { get; }
        public string StatName { get; }
        public SortOrder Order { get; set; }
        public uint MaxItems { get; set; }
        public uint SkipResultToRank { get; set; }
        public bool SkipResultToMe { get; set; }
    }
```

<span data-ttu-id="00584-224">A`LeaderboardQuery`にいくつかの属性設定できるが返されるデータに影響があります。</span><span class="sxs-lookup"><span data-stu-id="00584-224">A `LeaderboardQuery` has a few attributes that can be set which will effect the data returned:</span></span>

|<span data-ttu-id="00584-225">プロパティ</span><span class="sxs-lookup"><span data-stu-id="00584-225">Property</span></span> |<span data-ttu-id="00584-226">説明</span><span class="sxs-lookup"><span data-stu-id="00584-226">Description</span></span>  |
|---------|---------|
|<span data-ttu-id="00584-227">SkipResultToRank</span><span class="sxs-lookup"><span data-stu-id="00584-227">SkipResultToRank</span></span>     |<span data-ttu-id="00584-228">ランキング データをランク付けは開始を返す場合、この uint 変数が決定されます。</span><span class="sxs-lookup"><span data-stu-id="00584-228">this uint variable will determine what ranking the leaderboard data will start with when returning.</span></span> <span data-ttu-id="00584-229">ランキングは、ランク 1 から始まります。</span><span class="sxs-lookup"><span data-stu-id="00584-229">Rankings start at rank 1.</span></span>         |
|<span data-ttu-id="00584-230">SkipResultToMe</span><span class="sxs-lookup"><span data-stu-id="00584-230">SkipResultToMe</span></span>     |<span data-ttu-id="00584-231">かどうかに設定をこのブール値を true には、開始時刻から返されるランキング データ、`XboxLiveUser`で使用される、`GetLeaderboard()`呼び出します。</span><span class="sxs-lookup"><span data-stu-id="00584-231">if set to true this boolean value will cause the leaderboard data returned to start at the `XboxLiveUser` used in the `GetLeaderboard()` call.</span></span>  |
|<span data-ttu-id="00584-232">Order</span><span class="sxs-lookup"><span data-stu-id="00584-232">Order</span></span>     |<span data-ttu-id="00584-233">列挙型の`Microsoft.Xbox.Services.Leaderboard.SortOrder`は昇順であり、降順で 2 つの可能な値があります。</span><span class="sxs-lookup"><span data-stu-id="00584-233">Enums of type `Microsoft.Xbox.Services.Leaderboard.SortOrder` have two possible values, ascending, and descending.</span></span> <span data-ttu-id="00584-234">クエリのこの変数を設定すると、ランキングの並べ替え順序を決定します。</span><span class="sxs-lookup"><span data-stu-id="00584-234">Setting this variable for your query will determine the sort order of your leaderboard.</span></span>        |
|<span data-ttu-id="00584-235">MaxItems</span><span class="sxs-lookup"><span data-stu-id="00584-235">MaxItems</span></span>     |<span data-ttu-id="00584-236">この uint 呼び出しごとに返す行の最大数を決定する`GetLeaderboard()`または`GetSocialLeaderboard()`します。</span><span class="sxs-lookup"><span data-stu-id="00584-236">This uint determines the maximum number of rows to return per call to `GetLeaderboard()` or `GetSocialLeaderboard()`.</span></span>         |

<span data-ttu-id="00584-237">形成、`LeaderboardQuery`は、次のようになります。</span><span class="sxs-lookup"><span data-stu-id="00584-237">Forming your `LeaderboardQuery` may look like the following:</span></span>

```csharp
using Microsoft.Xbox.Services.Leaderboard;

LeaderboardQuery query = new LeaderboardQuery
        {
            SkipResultToRank = 100,
            MaxItems = 5
        };
```

<span data-ttu-id="00584-238">このクエリ戻ったら、5 行、100 から始まるランキングの順位個々 します。</span><span class="sxs-lookup"><span data-stu-id="00584-238">This query would return five rows of the leaderboard starting at the 100th ranked individual.</span></span>

> [!WARNING]
> <span data-ttu-id="00584-239">ランキング内に含まれるプレイヤーの数よりも高い SkipResultToRank が発生 0 行を返すランキング データ。</span><span class="sxs-lookup"><span data-stu-id="00584-239">Setting SkipResultToRank higher than the number of players contained within the leaderboard will cause the leaderboard data to return with zero rows.</span></span>

### <a name="3-call-getleaderboard"></a><span data-ttu-id="00584-240">3. GetLeaderboard() を呼び出す</span><span class="sxs-lookup"><span data-stu-id="00584-240">3. Call GetLeaderboard()</span></span>

<span data-ttu-id="00584-241">ここで呼び出すことができます`GetLeaderboard()`で、 `XboxLiveUser`、統計の名前と`LeaderboardQuery`します。</span><span class="sxs-lookup"><span data-stu-id="00584-241">You can now call `GetLeaderboard()` with your `XboxLiveUser`, the name of your statistic, and a `LeaderboardQuery`.</span></span>

```csharp
statManager.GetLeaderboard(xboxLiveUser, statName, leaderboardQuery);
```

> [!IMPORTANT]
> <span data-ttu-id="00584-242">`statName`で使用される、`GetLeaderboard()`呼び出しは小文字が区別されます、 [Windows デベロッパー センター ダッシュ ボード](https://developer.microsoft.com/en-us/dashboard/windows/overview)でタイトル用に構成された統計の名前と同じである必要があります。</span><span class="sxs-lookup"><span data-stu-id="00584-242">The `statName` used in the `GetLeaderboard()` call must be the same as the name of a stat configured for your title on its [Windows Dev Center dashboard](https://developer.microsoft.com/en-us/dashboard/windows/overview), which is case-sensitive.</span></span>

### <a name="4-read-leaderboard-data"></a><span data-ttu-id="00584-243">4. 読み取りランキング データ</span><span class="sxs-lookup"><span data-stu-id="00584-243">4. Read Leaderboard data</span></span>

<span data-ttu-id="00584-244">呼び出す必要がありますランキング データを読み取るために、`StatisticManager.DoWork()`の一覧を返す関数`StatisticEvent`値。</span><span class="sxs-lookup"><span data-stu-id="00584-244">In order to read the leaderboard data you will need to call the `StatisticManager.DoWork()` function which will return a list of `StatisticEvent` values.</span></span> <span data-ttu-id="00584-245">ランキング データは含まれている、`StatisticEvent`型の`GetLeaderboardComplete`します。</span><span class="sxs-lookup"><span data-stu-id="00584-245">Leaderboard data will be contained in a `StatisticEvent` of the type `GetLeaderboardComplete`.</span></span> <span data-ttu-id="00584-246">この種類の一覧でのイベントが発生したとき`StatisticEvent`s に目を通すことがあります、`LeaderboardResult`に含まれている、`StatisticEvent`データにアクセスします。</span><span class="sxs-lookup"><span data-stu-id="00584-246">When you come across an event of this type in the list of `StatisticEvent`s you may look through the `LeaderboardResult` contained in the `StatisticEvent` to access the data.</span></span>

```csharp
IReadOnlyList<StatisticEvent> statEvents = statManager.DoWork(); //In practice this should be called every update frame

foreach(StatisticEvent statEvent in statEvents)
{
    if(statEvent.EventType == StatisticEventType.GetLeaderboardComplete
        && statEvent.ErrorCode == 0)
    {
        LeaderboardResultEventArgs leaderArgs = (LeaderboardResultEventArgs)statEvent.EventArgs;
        LeaderboardResult leaderboardResult = leaderArgs.Result;
        foreach(LeaderboardRow leaderRow in leaderboardResult.Rows)
        {
            Debug.WriteLine(string.Format("Rank: {0} | Gamertag: {1} | {2}:{3}\n\n", leaderRow.Rank, leaderRow.Gamertag, "test", leaderRow.Values[0]));
        }
    }
}
```

<span data-ttu-id="00584-247">タイトル コードで`StatisticManager.DoWork()`統計情報マネージャーのすべての着信イベントを処理し、ランキング用だけではなくするために使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="00584-247">In your title code `StatisticManager.DoWork()` should be used to handle all incoming Statistic Manager events and not just for leaderboards.</span></span> 

> [!NOTE]
> <span data-ttu-id="00584-248">取得するために、`LeaderboardResultEventArgs`キャストする必要があります、`StatisticEvent.EventArgs`として、`LeaderboardResultEventArgs`変数です。</span><span class="sxs-lookup"><span data-stu-id="00584-248">In order to retrieve the `LeaderboardResultEventArgs` you will need to cast the `StatisticEvent.EventArgs` as a `LeaderboardResultEventArgs` variable.</span></span>

### <a name="5-retrieve-more-leaderboard-data"></a><span data-ttu-id="00584-249">5. より多くのランキング データを取得します。</span><span class="sxs-lookup"><span data-stu-id="00584-249">5. Retrieve more leaderboard data</span></span>

<span data-ttu-id="00584-250">ランキング データを使用する必要がありますの以降のページを取得するために、`LeaderboardResult.HasNext`プロパティと`LeaderboardResult.GetNextQuery()`を取得する関数、`LeaderboardQuery`データの次のページが表示するされます。</span><span class="sxs-lookup"><span data-stu-id="00584-250">In order to retrieve later pages of leaderboard data you will need to use the `LeaderboardResult.HasNext` property and the `LeaderboardResult.GetNextQuery()` function to retrieve the `LeaderboardQuery` that will bring you the next page of data.</span></span>

```csharp
while (leaderboardResult.HasNext)
{
    leaderboardQuery = leaderboardResult.GetNextQuery();
    statManager.GetLeaderboard(xboxLiveUser, leaderboardQuery.StatName, leaderboardQuery)
    // StatisticManager.DoWork() is called
    // Leaderboard results are read
}
```