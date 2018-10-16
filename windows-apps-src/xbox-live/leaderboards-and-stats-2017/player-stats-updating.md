---
title: 統計の更新 2017
author: KevinAsgari
description: 統計 2017 を使用して Xbox Live のプレイヤーの統計を更新する方法について説明します。
ms.assetid: 019723e9-4c36-4059-9377-4a191c8b8775
ms.author: kevinasg
ms.date: 08/24/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, プレイヤーの統計, 統計 2017
ms.localizationpriority: medium
ms.openlocfilehash: 57d52b102d46efa1a2e6d35dedd46e6aba577977
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4621740"
---
# <a name="updating-stats-2017"></a><span data-ttu-id="7c9a2-104">統計の更新 2017</span><span class="sxs-lookup"><span data-stu-id="7c9a2-104">Updating Stats 2017</span></span>

<span data-ttu-id="7c9a2-105">統計を更新するには、`StatsManager` API (後で説明します) を使用して Xbox Live サービスに最新の値を送信します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-105">You update stats by sending the latest value for the Xbox Live Serivce using the `StatsManager` APIs which will be discussed below.</span></span>

<span data-ttu-id="7c9a2-106">プレイヤーの統計を追跡するかどうかは、タイトルに応じて決めることができます。また、統計を必要に応じて更新するには `StatsManager` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-106">It is up to your title to keep track of player stats, and you call `StatsManager` to update these as appropriate.</span></span>  `StatsManager` <span data-ttu-id="7c9a2-107">は、あらゆる変更をバッファリングして、定期的にサービスにフラッシュします。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-107">will buffer any changes and flush these to the service periodically.</span></span>  <span data-ttu-id="7c9a2-108">タイトルでは、手動でフラッシュすることもできます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-108">Your title can also manually flush.</span></span>

> [!NOTE]
> <span data-ttu-id="7c9a2-109">統計を頻繁にフラッシュ避けてください。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-109">Do not flush stats too often.</span></span>  <span data-ttu-id="7c9a2-110">頻繁にフラッシュすると、タイトルのレートが制限されます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-110">Otherwise your title will be rate limited.</span></span>  <span data-ttu-id="7c9a2-111">多くても 5 分に 1 回フラッシュすることが、ベスト プラクティスです。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-111">A best practice is to flush at most once every 5 minutes.</span></span>

### <a name="multiple-devices"></a><span data-ttu-id="7c9a2-112">複数のデバイス</span><span class="sxs-lookup"><span data-stu-id="7c9a2-112">Multiple Devices</span></span>

<span data-ttu-id="7c9a2-113">プレイヤーは複数のデバイスでタイトルをプレイすることができますが、</span><span class="sxs-lookup"><span data-stu-id="7c9a2-113">It is possible for a player to play your title on multiple devices.</span></span>  <span data-ttu-id="7c9a2-114">その場合には同期のための作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-114">In this case, you need to make certain effort to keep things in sync.</span></span>

<span data-ttu-id="7c9a2-115">たとえば、プレイヤーが自宅の Xbox で 15 回ヘッドショットに成功したとします。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-115">For example, if a player got 15 headshots on their Xbox at home.</span></span>  <span data-ttu-id="7c9a2-116">その後、友人宅の Xbox で さらに 10 回ヘッドショットに成功しました。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-116">Later, they got 10 more headshots on their Xbox at a friend's house.</span></span>  <span data-ttu-id="7c9a2-117">2 台目のデバイスで 25 という統計値を送信する必要がありますが、</span><span class="sxs-lookup"><span data-stu-id="7c9a2-117">You would need to send the stat value of 25 on the second device.</span></span>  <span data-ttu-id="7c9a2-118">この情報を同期しないと、正しい統計値を把握することができません。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-118">But you would have no way of knowing this without somehow synchronizing this information.</span></span>

<span data-ttu-id="7c9a2-119">この同期を実行するための方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-119">There are a few ways you can do this:</span></span>

1. <span data-ttu-id="7c9a2-120">[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)を使用して統計を保存します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-120">Store them using [Connected Storage](../storage-platform/connected-storage/connected-storage-technical-overview.md).</span></span>  <span data-ttu-id="7c9a2-121">通常、接続ストレージはユーザーごとのセーブ データに使用します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-121">Usually you would use Connected Storage for per-user save data.</span></span>  <span data-ttu-id="7c9a2-122">このデータは、指定されたユーザーの複数のデバイス間で同期が維持されます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-122">This data is kept in sync across different devices for a given user.</span></span>
2. <span data-ttu-id="7c9a2-123">タイトルに対して補助的なタスクを実行している独自の Web サービスを既にご利用の場合は、その Web サービスを使用して統計を同期します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-123">Use your own web service to keep stats in sync if you already have one for performing auxillary tasks for your title.</span></span>

### <a name="offline"></a><span data-ttu-id="7c9a2-124">オフライン</span><span class="sxs-lookup"><span data-stu-id="7c9a2-124">Offline</span></span>

<span data-ttu-id="7c9a2-125">前述のとおり、タイトルはプレイヤーの統計を追跡し、オフラインのシナリオをサポートする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-125">As we mentioned above, your title is responsible to keep track of player stats and, therefore, responsbile to support offline scenarios.</span></span> 

### <a name="examples"></a><span data-ttu-id="7c9a2-126">例</span><span class="sxs-lookup"><span data-stu-id="7c9a2-126">Examples</span></span>

<span data-ttu-id="7c9a2-127">これらの概念を 1 つにまとめるために、例を示します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-127">We will go through an example to tie these concepts together.</span></span>

<span data-ttu-id="7c9a2-128">レーシング ゲームの一般的な統計はラップ タイムです。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-128">A common stat in a racing game is lap time.</span></span>  <span data-ttu-id="7c9a2-129">通常、こうした統計では、より低い数値がより優れた成績を表します。このため、低い数値を優れた成績とする統計および関連するランキングを作成します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-129">Usually lower is better for these stats.  So you would create a stat and associated leaderboard, where lower is better.</span></span>  <span data-ttu-id="7c9a2-130">つまり、このランキングは昇順で並べ替えることになります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-130">In other words, this leaderboard would be sorted in ascending order.</span></span>

<span data-ttu-id="7c9a2-131">タイトルは、プレイ セッションの間ユーザーのラップ タイムを追跡します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-131">Your title would keep track of a user's lap times during their play session.</span></span>  <span data-ttu-id="7c9a2-132">前回の最高記録よりも短いラップ タイムがある場合のみ、StatsManager を更新します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-132">You would update the Stats Manager only if they had a lap time lower than their previous best.</span></span>

<span data-ttu-id="7c9a2-133">前回の最高記録を追跡するには、次に示す方法のいずれかを使用します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-133">You can track their previous best in one of the following ways:</span></span>
1. <span data-ttu-id="7c9a2-134">接続ストレージを使用して保存ファイルから取得する。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-134">From the save file using Connected Storage.</span></span>
2. <span data-ttu-id="7c9a2-135">独自の Web サービスを使用する。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-135">Your own web service.</span></span>

<span data-ttu-id="7c9a2-136">サービスは、どのような場合でも統計値を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-136">The service will replace the stat value no matter what.</span></span>  <span data-ttu-id="7c9a2-137">つまり、ラップ タイムが前回の最高記録より長い場合でも、前回の最高記録が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-137">So even if you were to update with a lap time that's greater than their previous best, then their previous best would be overwritten.</span></span>

<span data-ttu-id="7c9a2-138">このため、タイトルでは、ゲームプレイ シナリオに基づいて適切な統計値のみを送信してください。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-138">So please ensure in your title, that you are only sending the proper stat values based on your gameplay scenario.</span></span>  <span data-ttu-id="7c9a2-139">低い数値を優れた成績とする場合も、高い数値を優れた成績とする場合もあります。また、これら 2 つのケースとまったく異なる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-139">In some cases lower values might be better, in some other cases higher might be better, or something else entirely.</span></span>

## <a name="programming-guide"></a><span data-ttu-id="7c9a2-140">プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="7c9a2-140">Programming Guide</span></span>

<span data-ttu-id="7c9a2-141">通常、統計を使用するフローは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-141">Typically your flow for using stats is:</span></span>

1. <span data-ttu-id="7c9a2-142">`StatsManager` API をローカル ユーザーに渡して初期化します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-142">Initialize the `StatsManager` API by passing in a local user.</span></span>
1. <span data-ttu-id="7c9a2-143">ユーザーがタイトルをプレイしているとき、`set_stat` 関数を使用して統計値を更新します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-143">As a user plays through your title, update stat values using the `set_stat` functions.</span></span>
1. <span data-ttu-id="7c9a2-144">これらの統計の更新は、定期的にフラッシュされ Xbox Live に書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-144">These stat updates will be periodically flushed and written to Xbox Live.</span></span>  <span data-ttu-id="7c9a2-145">これは手動でも実行できます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-145">You can also do this manually.</span></span>

### <a name="initialization"></a><span data-ttu-id="7c9a2-146">初期化</span><span class="sxs-lookup"><span data-stu-id="7c9a2-146">Initialization</span></span>

<span data-ttu-id="7c9a2-147">必要な情報によって API を初期化するために、ローカル ユーザーを指定して `StatsManager` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-147">You call the `StatsManager` with a local user to initialize the API with the necessary information.</span></span>

<span data-ttu-id="7c9a2-148">以下の例をご覧ください</span><span class="sxs-lookup"><span data-stu-id="7c9a2-148">See below for an example</span></span>

```cpp
std::shared_ptr<stats_manager> statsManager = stats_manager::get_singleton_instance();
statsManager->add_local_user(user);
statsManager->do_work();  // returns stat_event_type::local_user_added
```

```csharp
Microsoft.Xbox.Services.Statistics.Manager.StatisticManager statManager = StatisticManager.SingletonInstance;
statManager.AddLocalUser(user);
statEvent = statManager.DoWork();
```

### <a name="writing-stats"></a><span data-ttu-id="7c9a2-149">統計の書き込み</span><span class="sxs-lookup"><span data-stu-id="7c9a2-149">Writing Stats</span></span>

<span data-ttu-id="7c9a2-150">統計は、関数の `stats_manager::set_stat` ファミリを使用して書き込みます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-150">You write stats using the `stats_manager::set_stat` family of functions.</span></span>  <span data-ttu-id="7c9a2-151">この関数には、データ型に応じて次の 3 つのバリエーションがあります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-151">There are three variants of this function for each data type:</span></span>

* `set_stat_number` <span data-ttu-id="7c9a2-152">(浮動小数点型の場合)。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-152">for floats.</span></span>
* `set_stat_integer` <span data-ttu-id="7c9a2-153">(整数型の場合)。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-153">for integers.</span></span>
* `set_stat_string` <span data-ttu-id="7c9a2-154">(文字列型の場合)。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-154">for strings.</span></span>

<span data-ttu-id="7c9a2-155">これらの関数を呼び出すとき、統計の更新はデバイスでローカルにキャッシュされ、</span><span class="sxs-lookup"><span data-stu-id="7c9a2-155">When you call these, the stat updates are cached locally on the device.</span></span>  <span data-ttu-id="7c9a2-156">定期的に Xbox Live にフラッシュされます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-156">Periodically these will be flushed to Xbox Live.</span></span>

<span data-ttu-id="7c9a2-157">`stats_manager::request_flush_to_service` API を使用して、統計を手動でフラッシュすることもできます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-157">You have the option of manually flushing stats via the `stats_manager::request_flush_to_service` API.</span></span>  <span data-ttu-id="7c9a2-158">この関数を頻繁に呼び出すとレートが制限されるので注意してください。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-158">Please note that if you call this function too often, you will be rate limited.</span></span>  <span data-ttu-id="7c9a2-159">頻繁に呼び出した場合でも、統計が更新されなくなるのではなく、</span><span class="sxs-lookup"><span data-stu-id="7c9a2-159">This does not mean that the stat will never get updated.</span></span>  <span data-ttu-id="7c9a2-160">タイムアウト時間が経過してから更新が行われるようになるだけです。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-160">It merely means that the update will happen when the timeout expires.</span></span>

```cpp
statsManager->set_stat_integer(user, L"numHeadshots", 20);
statsManager->request_flush_to_service(user); // requests flush to service, performs a do_work
statsManager->do_work();  // applies the stat changes, returns stat_update_complete after flush to service
```

```csharp
statManager.SetStatisticIntegerData(user, statName, (long)statValue);
statManager.RequestFlushToService(user);
statManager.DoWork();
```

#### <a name="example"></a><span data-ttu-id="7c9a2-161">例</span><span class="sxs-lookup"><span data-stu-id="7c9a2-161">Example</span></span>

<span data-ttu-id="7c9a2-162">一人称視点のシューティング ゲームをプレイしているとします。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-162">Let's say that you have a first-person shooter.</span></span>  <span data-ttu-id="7c9a2-163">対戦が行われている間、次の統計を蓄積します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-163">During a match you might accumulate the following stats:</span></span>

| <span data-ttu-id="7c9a2-164">統計の名前</span><span class="sxs-lookup"><span data-stu-id="7c9a2-164">Stat Name</span></span> | <span data-ttu-id="7c9a2-165">形式</span><span class="sxs-lookup"><span data-stu-id="7c9a2-165">Format</span></span> |
|-----------|--------|
| <span data-ttu-id="7c9a2-166">ラウンドあたりの最高撃墜数</span><span class="sxs-lookup"><span data-stu-id="7c9a2-166">Best Kills Per Round</span></span> | <span data-ttu-id="7c9a2-167">整数型</span><span class="sxs-lookup"><span data-stu-id="7c9a2-167">Integer</span></span> |
| <span data-ttu-id="7c9a2-168">全体の時間における撃墜数</span><span class="sxs-lookup"><span data-stu-id="7c9a2-168">Lifetime Kills</span></span> | <span data-ttu-id="7c9a2-169">整数型</span><span class="sxs-lookup"><span data-stu-id="7c9a2-169">Integer</span></span> |
| <span data-ttu-id="7c9a2-170">全体の時間における死亡数</span><span class="sxs-lookup"><span data-stu-id="7c9a2-170">Lifetime Deaths</span></span> | <span data-ttu-id="7c9a2-171">整数型</span><span class="sxs-lookup"><span data-stu-id="7c9a2-171">Integer</span></span> |
| <span data-ttu-id="7c9a2-172">全体の時間における撃墜と死亡の割合</span><span class="sxs-lookup"><span data-stu-id="7c9a2-172">Lifetime Kill/Death Ratio</span></span> | <span data-ttu-id="7c9a2-173">数値</span><span class="sxs-lookup"><span data-stu-id="7c9a2-173">Number</span></span> |

<span data-ttu-id="7c9a2-174">対戦が進むごとに、*ラウンドあたりの最高撃墜数*、*全体の時間における撃墜数*、および*全体の時間における死亡数*をローカルに増分します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-174">As the player goes through the match, you would increment the *Kills Per Round*, *Lifetime Kills* and *Lifetime Deaths* locally.</span></span>

<span data-ttu-id="7c9a2-175">対戦が終了するときに、以下を実行します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-175">At the end of the match you would do the following:</span></span>
1. <span data-ttu-id="7c9a2-176">ラウンドでの撃墜数と前回の最高記録を比較します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-176">Compare the kills they got in the round, with their previous best.</span></span>  <span data-ttu-id="7c9a2-177">今回の方が値が大きい場合は、`StatsManager` を更新します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-177">If it is greater, then update `StatsManager`.</span></span>
2. <span data-ttu-id="7c9a2-178">全体の時間における撃墜数と死亡数を新しい値で更新し、`StatsManager` を更新します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-178">Update their Lifetime Kills and Deaths with the new values and update `StatsManager`.</span></span>
3. <span data-ttu-id="7c9a2-179">撃墜数を死亡数で除算した割合を計算し、次を更新します: </span><span class="sxs-lookup"><span data-stu-id="7c9a2-179">Calculate Kills/Deaths and update</span></span> `StatsManager`

<span data-ttu-id="7c9a2-180">手順 1 と 2 では、以前の統計値を知っておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-180">Note that for 1 and 2, you need to know their previous stat values.</span></span>  <span data-ttu-id="7c9a2-181">以前の統計値を取得するベスト プラクティスについては、上記のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-181">See the above sections for best practices on retrieving these.</span></span>

<span data-ttu-id="7c9a2-182">これらの統計はどれもランキングに対応させることができます。詳しくは、次の記事で説明します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-182">Any of these stats could correspond to a leaderboard, which will be discussed in the next article.</span></span>

### <a name="flushing-stats"></a><span data-ttu-id="7c9a2-183">統計のフラッシュ</span><span class="sxs-lookup"><span data-stu-id="7c9a2-183">Flushing Stats</span></span>

<span data-ttu-id="7c9a2-184">手動で統計をフラッシュするには `stats_manager::request_flush_to_service` を使用します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-184">You can manually flush stats using `stats_manager::request_flush_to_service`.</span></span>  <span data-ttu-id="7c9a2-185">ランキングを表示する場合は、手動でフラッシュすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-185">You might want to do this if you are want to display a leaderboard.</span></span>

<span data-ttu-id="7c9a2-186">たとえば、上記の例の `Lifetime Kills` に関するランキングがある場合、ランキングを表示する前に、この統計に対応する統計の更新がサーバーにフラッシュされているようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-186">For example, if you had a leaderboard for `Lifetime Kills` in the above example, you would want to make sure that the stat updates corresponding to this stat had been flushed to the server before displaying the leaderboard.</span></span>  <span data-ttu-id="7c9a2-187">これで、ランキングにはプレイヤーの最新の進行状況が反映されるようになります。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-187">That way the leaderboards reflects the player's latest progress.</span></span>

### <a name="cleanup"></a><span data-ttu-id="7c9a2-188">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="7c9a2-188">Cleanup</span></span>
<span data-ttu-id="7c9a2-189">タイトルを終了するときは、StatsManager からユーザーを削除します。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-189">When the title closes, remove the user from stats manager.</span></span> <span data-ttu-id="7c9a2-190">これにより、サービスに最新の統計値がフラッシュされます。</span><span class="sxs-lookup"><span data-stu-id="7c9a2-190">This will flush the latest stat values to the service.</span></span>

```cpp
statsManager->remove_local_user(user);
statsManager->do_work();  // applies the stat changes, returns local_user_removed after flush to service
```

```csharp
statManager.RemoveLocalUser(user);
statManager.DoWork();
```
