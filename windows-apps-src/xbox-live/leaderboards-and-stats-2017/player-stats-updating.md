---
title: 統計の更新 2017
author: KevinAsgari
description: 統計 2017 を使用して Xbox Live のプレイヤーの統計を更新する方法について説明します。
ms.assetid: 019723e9-4c36-4059-9377-4a191c8b8775
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, プレイヤーの統計, 統計 2017
ms.localizationpriority: low
ms.openlocfilehash: 36e0a8fe2b9909d2825462dcd56dfef6a97e7790
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="updating-stats-2017"></a><span data-ttu-id="f4d72-104">統計の更新 2017</span><span class="sxs-lookup"><span data-stu-id="f4d72-104">Updating Stats 2017</span></span>

<span data-ttu-id="f4d72-105">統計を更新するには、`StatsManager` API (後で説明します) を使用して Xbox Live サービスに最新の値を送信します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-105">You update stats by sending the latest value for the Xbox Live Serivce using the `StatsManager` APIs which will be discussed below.</span></span>

<span data-ttu-id="f4d72-106">プレイヤーの統計を追跡するかどうかは、タイトルに応じて決めることができます。また、統計を必要に応じて更新するには `StatsManager` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-106">It is up to your title to keep track of player stats, and you call `StatsManager` to update these as appropriate.</span></span>  `StatsManager` <span data-ttu-id="f4d72-107">は、あらゆる変更をバッファリングして、定期的にサービスにフラッシュします。</span><span class="sxs-lookup"><span data-stu-id="f4d72-107">will buffer any changes and flush these to the service periodically.</span></span>  <span data-ttu-id="f4d72-108">タイトルでは、手動でフラッシュすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-108">Your title can also manually flush.</span></span>

> <span data-ttu-id="f4d72-109">**注**: 統計を頻繁にフラッシュすることは避けてください。</span><span class="sxs-lookup"><span data-stu-id="f4d72-109">**Note** Do not flush stats too often.</span></span>  <span data-ttu-id="f4d72-110">頻繁にフラッシュすると、タイトルのレートが制限されます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-110">Otherwise your title will be rate limited.</span></span>  <span data-ttu-id="f4d72-111">多くても 5 分に 1 回フラッシュすることが、ベスト プラクティスです。</span><span class="sxs-lookup"><span data-stu-id="f4d72-111">A best practice is to flush at most once every 5 minutes.</span></span>

<span data-ttu-id="f4d72-112">統計をフラッシュしない場合、統計はオペレーティング システムによってサービスに送信されます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-112">If you do not flush stats, they will be sent to the service by the operating system.</span></span>  <span data-ttu-id="f4d72-113">したがって、プレイヤーがタイトルのプレイをやめ、統計の更新が保留されている場合でも、統計は確実に更新され、関連するランキングや注目の統計に反映されます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-113">So even if a player leaves your title, and there are pending stat updates, you can be assured these will be updated and reflect in any related Leaderboards or Featured Stats.</span></span>

### <a name="multiple-devices"></a><span data-ttu-id="f4d72-114">複数のデバイス</span><span class="sxs-lookup"><span data-stu-id="f4d72-114">Multiple Devices</span></span>

<span data-ttu-id="f4d72-115">プレイヤーは複数のデバイスでタイトルをプレイすることができますが、</span><span class="sxs-lookup"><span data-stu-id="f4d72-115">It is possible for a player to play your title on multiple devices.</span></span>  <span data-ttu-id="f4d72-116">その場合には同期のための作業が必要になります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-116">In this case, you need to make certain effort to keep things in sync.</span></span>

<span data-ttu-id="f4d72-117">たとえば、プレイヤーが自宅の Xbox で 15 回ヘッドショットに成功したとします。</span><span class="sxs-lookup"><span data-stu-id="f4d72-117">For example, if a player got 15 headshots on their Xbox at home.</span></span>  <span data-ttu-id="f4d72-118">その後、友人宅の Xbox で さらに 10 回ヘッドショットに成功しました。</span><span class="sxs-lookup"><span data-stu-id="f4d72-118">Later, they got 10 more headshots on their Xbox at a friend's house.</span></span>  <span data-ttu-id="f4d72-119">2 台目のデバイスで 25 という統計値を送信する必要がありますが、</span><span class="sxs-lookup"><span data-stu-id="f4d72-119">You would need to send the stat value of 25 on the second device.</span></span>  <span data-ttu-id="f4d72-120">この情報を同期しないと、正しい統計値を把握することができません。</span><span class="sxs-lookup"><span data-stu-id="f4d72-120">But you would have no way of knowing this without somehow synchronizing this information.</span></span>

<span data-ttu-id="f4d72-121">この同期を実行するための方法を以下に示します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-121">There are a few ways you can do this:</span></span>

1. <span data-ttu-id="f4d72-122">プレイヤーがタイトルを起動したとき、または新しいセッションを開始したときに、`StatsManager` を使って最新の統計を Xbox Live から取得します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-122">Retrieve the latest stats from Xbox Live via `StatsManager` when a player launches your title, or starts a new session.</span></span>  <span data-ttu-id="f4d72-123">これらの値をローカルにキャッシュして、必要に応じて変更し、後でアップロードします。</span><span class="sxs-lookup"><span data-stu-id="f4d72-123">Cache these values locally and modify them as needed, and upload later.</span></span>
2. <span data-ttu-id="f4d72-124">[接続ストレージ](../storage-platform/connected-storage/connected-storage-technical-overview.md)を使用して統計を保存します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-124">Store them using [Connected Storage](../storage-platform/connected-storage/connected-storage-technical-overview.md).</span></span>  <span data-ttu-id="f4d72-125">通常、接続ストレージはユーザーごとのセーブ データに使用します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-125">Usually you would use Connected Storage for per-user save data.</span></span>  <span data-ttu-id="f4d72-126">このデータは、指定されたユーザーの複数のデバイス間で同期が維持されます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-126">This data is kept in sync across different devices for a given user.</span></span>
3. <span data-ttu-id="f4d72-127">タイトルに対して補助的なタスクを実行している独自の Web サービスを既にご利用の場合は、その Web サービスを使用して統計を同期します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-127">Use your own web service to keep stats in sync if you already have one for performing auxillary tasks for your title.</span></span>

### <a name="offline"></a><span data-ttu-id="f4d72-128">オフライン</span><span class="sxs-lookup"><span data-stu-id="f4d72-128">Offline</span></span>

<span data-ttu-id="f4d72-129">上で説明したように、オペレーティング システムは、ユーザーがフラッシュを行わなくてもサービスに対してイベントの同期を実行します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-129">As we mentioned above, the operating system is responsible for synchronizing events to the service, even if you do not flush.</span></span>

<span data-ttu-id="f4d72-130">このため、プレイヤーがインターネットに接続しないでタイトルをプレイしている場合でも、特別な操作を行う必要はありません。</span><span class="sxs-lookup"><span data-stu-id="f4d72-130">Therefore there is no special behavior you must do, if a player is playing your title without an Internet connection.</span></span>

### <a name="examples"></a><span data-ttu-id="f4d72-131">例</span><span class="sxs-lookup"><span data-stu-id="f4d72-131">Examples</span></span>

<span data-ttu-id="f4d72-132">これらの概念を 1 つにまとめるために、例を示します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-132">We will go through an example to tie these concepts together.</span></span>

<span data-ttu-id="f4d72-133">レーシング ゲームの一般的な統計はラップ タイムです。</span><span class="sxs-lookup"><span data-stu-id="f4d72-133">A common stat in a racing game is lap time.</span></span>  <span data-ttu-id="f4d72-134">通常、こうした統計では、より低い数値がより優れた成績を表します。このため、低い数値を優れた成績とする統計および関連するランキングを作成します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-134">Usually lower is better for these stats.  So you would create a stat and associated leaderboard, where lower is better.</span></span>  <span data-ttu-id="f4d72-135">つまり、このランキングは昇順で並べ替えることになります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-135">In other words, this leaderboard would be sorted in ascending order.</span></span>

<span data-ttu-id="f4d72-136">タイトルは、プレイ セッションの間ユーザーのラップ タイムを追跡します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-136">Your title would keep track of a user's lap times during their play session.</span></span>  <span data-ttu-id="f4d72-137">前回の最高記録よりも短いラップ タイムがある場合のみ、StatsManager を更新します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-137">You would update the Stats Manager only if they had a lap time lower than their previous best.</span></span>

<span data-ttu-id="f4d72-138">前回の最高記録を追跡するには、次に示す方法のいずれかを使用します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-138">You can track their previous best in one of the following ways:</span></span>
1. <span data-ttu-id="f4d72-139">プレイヤーがタイトルを開始するときに `StatsManager` を使ってサービスから取得する。</span><span class="sxs-lookup"><span data-stu-id="f4d72-139">Retrieve it from the service via `StatsManager` when a player starts the title.</span></span>
2. <span data-ttu-id="f4d72-140">接続ストレージを使用して保存ファイルから取得する。</span><span class="sxs-lookup"><span data-stu-id="f4d72-140">From the save file using Connected Storage.</span></span>
3. <span data-ttu-id="f4d72-141">独自の Web サービスを使用する。</span><span class="sxs-lookup"><span data-stu-id="f4d72-141">Your own web service.</span></span>

<span data-ttu-id="f4d72-142">サービスは、どのような場合でも統計値を置き換えます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-142">The service will replace the stat value no matter what.</span></span>  <span data-ttu-id="f4d72-143">つまり、ラップ タイムが前回の最高記録より長い場合でも、前回の最高記録が上書きされます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-143">So even if you were to update with a lap time that's greater than their previous best, then their previous best would be overwritten.</span></span>

<span data-ttu-id="f4d72-144">このため、タイトルでは、ゲームプレイ シナリオに基づいて適切な統計値のみを送信してください。</span><span class="sxs-lookup"><span data-stu-id="f4d72-144">So please ensure in your title, that you are only sending the proper stat values based on your gameplay scenario.</span></span>  <span data-ttu-id="f4d72-145">低い数値を優れた成績とする場合も、高い数値を優れた成績とする場合もあります。また、これら 2 つのケースとまったく異なる場合もあります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-145">In some cases lower values might be better, in some other cases higher might be better, or something else entirely.</span></span>

## <a name="programming-guide"></a><span data-ttu-id="f4d72-146">プログラミング ガイド</span><span class="sxs-lookup"><span data-stu-id="f4d72-146">Programming Guide</span></span>

<span data-ttu-id="f4d72-147">通常、統計を使用するフローは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-147">Typically your flow for using stats is:</span></span>

1. <span data-ttu-id="f4d72-148">`StatsManager` API をローカル ユーザーに渡して初期化します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-148">Initialize the `StatsManager` API by passing in a local user.</span></span>
1. <span data-ttu-id="f4d72-149">ゲームプレイ セッションの開始時に Xbox Live サービスから最新の値を取得します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-149">At the start of a gameplay session, retrieve the latest values from the Xbox Live service.</span></span>
1. <span data-ttu-id="f4d72-150">ユーザーがタイトルをプレイしているとき、`set_stat` 関数を使用して統計値を更新します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-150">As a user plays through your title, update stat values using the `set_stat` functions.</span></span>
1. <span data-ttu-id="f4d72-151">これらの統計の更新は、定期的にフラッシュされ Xbox Live に書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-151">These stat updates will be periodically flushed and written to Xbox Live.</span></span>  <span data-ttu-id="f4d72-152">これは手動でも実行できます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-152">You can also do this manually.</span></span>

### <a name="initialization"></a><span data-ttu-id="f4d72-153">初期化</span><span class="sxs-lookup"><span data-stu-id="f4d72-153">Initialization</span></span>

<span data-ttu-id="f4d72-154">必要な情報によって API を初期化するために、ローカル ユーザーを指定して `StatsManager` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-154">You call the `StatsManager` with a local user to initialize the API with the necessary information.</span></span>

<span data-ttu-id="f4d72-155">以下の例をご覧ください</span><span class="sxs-lookup"><span data-stu-id="f4d72-155">See below for an example</span></span>

```cpp
std::shared_ptr<stats_manager> statsManager = stats_manager::get_singleton_instance();
statsManager->add_local_user(user);
statsManager->do_work();  // returns stat_event_type::local_user_added
```

### <a name="writing-stats"></a><span data-ttu-id="f4d72-156">統計の書き込み</span><span class="sxs-lookup"><span data-stu-id="f4d72-156">Writing Stats</span></span>

<span data-ttu-id="f4d72-157">統計は、関数の `stats_manager::set_stat` ファミリを使用して書き込みます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-157">You write stats using the `stats_manager::set_stat` family of functions.</span></span>  <span data-ttu-id="f4d72-158">この関数には、データ型に応じて次の 3 つのバリエーションがあります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-158">There are three variants of this function for each data type:</span></span>

* `set_stat_number` <span data-ttu-id="f4d72-159">(浮動小数点型の場合)。</span><span class="sxs-lookup"><span data-stu-id="f4d72-159">for floats.</span></span>
* `set_stat_integer` <span data-ttu-id="f4d72-160">(整数型の場合)。</span><span class="sxs-lookup"><span data-stu-id="f4d72-160">for integers.</span></span>
* `set_stat_string` <span data-ttu-id="f4d72-161">(文字列型の場合)。</span><span class="sxs-lookup"><span data-stu-id="f4d72-161">for strings.</span></span>

<span data-ttu-id="f4d72-162">これらの関数を呼び出すとき、統計の更新はデバイスでローカルにキャッシュされ、</span><span class="sxs-lookup"><span data-stu-id="f4d72-162">When you call these, the stat updates are cached locally on the device.</span></span>  <span data-ttu-id="f4d72-163">定期的に Xbox Live にフラッシュされます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-163">Periodically these will be flushed to Xbox Live.</span></span>  <span data-ttu-id="f4d72-164">ユーザーがタイトルを終了している場合も同様です。</span><span class="sxs-lookup"><span data-stu-id="f4d72-164">Even if the user quits the title.</span></span>

<span data-ttu-id="f4d72-165">`stats_manager::request_flush_to_service` API を使用して、統計を手動でフラッシュすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-165">You have the option of manually flushing stats via the `stats_manager::request_flush_to_service` API.</span></span>  <span data-ttu-id="f4d72-166">この関数を頻繁に呼び出すとレートが制限されるので注意してください。</span><span class="sxs-lookup"><span data-stu-id="f4d72-166">Please note that if you call this function too often, you will be rate limited.</span></span>  <span data-ttu-id="f4d72-167">頻繁に呼び出した場合でも、統計が更新されなくなるのではなく、</span><span class="sxs-lookup"><span data-stu-id="f4d72-167">This does not mean that the stat will never get updated.</span></span>  <span data-ttu-id="f4d72-168">タイムアウト時間が経過してから更新が行われるようになるだけです。</span><span class="sxs-lookup"><span data-stu-id="f4d72-168">It merely means that the update will happen when the timeout expires.</span></span>

<span data-ttu-id="f4d72-169">*SUM* 型の統計については、増分的に更新を送信することができます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-169">Please note that for stats of type *SUM*, you can send incremental updates.</span></span>  <span data-ttu-id="f4d72-170">たとえば、"*全体の時間における撃墜数*" という統計があり、サーバー上の値が 100 であるとします。</span><span class="sxs-lookup"><span data-stu-id="f4d72-170">Eg: If you have a stat for *Lifetime Kills*, and the value on the server is 100.</span></span>  <span data-ttu-id="f4d72-171">引数 5 を指定して `set_stat_integer` を呼び出すと、</span><span class="sxs-lookup"><span data-stu-id="f4d72-171">If you call `set_stat_integer` with an argument of 5.</span></span>  <span data-ttu-id="f4d72-172">サーバー上の新しい値は 105 になります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-172">The new value on the server is 105.</span></span>

```cpp
statsManager->set_stat_integer(user, L"numHeadshots", 20);
statsManager->request_flush_to_service(user); // requests flush to service, performs a do_work
statsManager->do_work();  // applies the stat changes, returns stat_update_complete after flush to service
```

#### <a name="example"></a><span data-ttu-id="f4d72-173">例</span><span class="sxs-lookup"><span data-stu-id="f4d72-173">Example</span></span>

<span data-ttu-id="f4d72-174">一人称視点のシューティング ゲームをプレイしているとします。</span><span class="sxs-lookup"><span data-stu-id="f4d72-174">Let's say that you have a first-person shooter.</span></span>  <span data-ttu-id="f4d72-175">対戦が行われている間、次の統計を蓄積します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-175">During a match you might accumulate the following stats:</span></span>

| <span data-ttu-id="f4d72-176">統計の名前</span><span class="sxs-lookup"><span data-stu-id="f4d72-176">Stat Name</span></span> | <span data-ttu-id="f4d72-177">形式</span><span class="sxs-lookup"><span data-stu-id="f4d72-177">Format</span></span> |
|-----------|--------|
| <span data-ttu-id="f4d72-178">ラウンドあたりの最高撃墜数</span><span class="sxs-lookup"><span data-stu-id="f4d72-178">Best Kills Per Round</span></span> | <span data-ttu-id="f4d72-179">整数型</span><span class="sxs-lookup"><span data-stu-id="f4d72-179">Integer</span></span> |
| <span data-ttu-id="f4d72-180">全体の時間における撃墜数</span><span class="sxs-lookup"><span data-stu-id="f4d72-180">Lifetime Kills</span></span> | <span data-ttu-id="f4d72-181">整数型</span><span class="sxs-lookup"><span data-stu-id="f4d72-181">Integer</span></span> |
| <span data-ttu-id="f4d72-182">全体の時間における死亡数</span><span class="sxs-lookup"><span data-stu-id="f4d72-182">Lifetime Deaths</span></span> | <span data-ttu-id="f4d72-183">整数型</span><span class="sxs-lookup"><span data-stu-id="f4d72-183">Integer</span></span> |
| <span data-ttu-id="f4d72-184">全体の時間における撃墜と死亡の割合</span><span class="sxs-lookup"><span data-stu-id="f4d72-184">Lifetime Kill/Death Ratio</span></span> | <span data-ttu-id="f4d72-185">数値</span><span class="sxs-lookup"><span data-stu-id="f4d72-185">Number</span></span> |

<span data-ttu-id="f4d72-186">対戦が進むごとに、*ラウンドあたりの最高撃墜数*、*全体の時間における撃墜数*、および*全体の時間における死亡数*をローカルに増分します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-186">As the player goes through the match, you would increment the *Kills Per Round*, *Lifetime Kills* and *Lifetime Deaths* locally.</span></span>

<span data-ttu-id="f4d72-187">対戦が終了するときに、以下を実行します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-187">At the end of the match you would do the following:</span></span>
1. <span data-ttu-id="f4d72-188">ラウンドでの撃墜数と前回の最高記録を比較します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-188">Compare the kills they got in the round, with their previous best.</span></span>  <span data-ttu-id="f4d72-189">今回の方が値が大きい場合は、`StatsManager` を更新します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-189">If it is greater, then update `StatsManager`.</span></span>
2. <span data-ttu-id="f4d72-190">全体の時間における撃墜数と死亡数を新しい値で更新し、`StatsManager` を更新します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-190">Update their Lifetime Kills and Deaths with the new values and update `StatsManager`.</span></span>
3. <span data-ttu-id="f4d72-191">撃墜数を死亡数で除算した割合を計算し、次を更新します: </span><span class="sxs-lookup"><span data-stu-id="f4d72-191">Calculate Kills/Deaths and update</span></span> `StatsManager`

<span data-ttu-id="f4d72-192">手順 1 と 2 では、以前の統計値を知っておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-192">Note that for 1 and 2, you need to know their previous stat values.</span></span>  <span data-ttu-id="f4d72-193">以前の統計値を取得するベスト プラクティスについては、上記のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="f4d72-193">See the above sections for best practices on retrieving these.</span></span>

<span data-ttu-id="f4d72-194">これらの統計はどれもランキングに対応させることができます。詳しくは、次の記事で説明します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-194">Any of these stats could correspond to a leaderboard, which will be discussed in the next article.</span></span>

### <a name="flushing-stats"></a><span data-ttu-id="f4d72-195">統計のフラッシュ</span><span class="sxs-lookup"><span data-stu-id="f4d72-195">Flushing Stats</span></span>

<span data-ttu-id="f4d72-196">手動で統計をフラッシュするには `stats_manager::request_flush_to_service` を使用します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-196">You can manually flush stats using `stats_manager::request_flush_to_service`.</span></span>  <span data-ttu-id="f4d72-197">ランキングを表示する場合は、手動でフラッシュすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="f4d72-197">You might want to do this if you are want to display a leaderboard.</span></span>

<span data-ttu-id="f4d72-198">たとえば、上記の例の `Lifetime Kills` に関するランキングがある場合、ランキングを表示する前に、この統計に対応する統計の更新がサーバーにフラッシュされているようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-198">For example, if you had a leaderboard for `Lifetime Kills` in the above example, you would want to make sure that the stat updates corresponding to this stat had been flushed to the server before displaying the leaderboard.</span></span>  <span data-ttu-id="f4d72-199">これで、ランキングにはプレイヤーの最新の進行状況が反映されるようになります。</span><span class="sxs-lookup"><span data-stu-id="f4d72-199">That way the leaderboards reflects the player's latest progress.</span></span>

### <a name="cleanup"></a><span data-ttu-id="f4d72-200">クリーンアップ</span><span class="sxs-lookup"><span data-stu-id="f4d72-200">Cleanup</span></span>
<span data-ttu-id="f4d72-201">タイトルを終了するときは、StatsManager からユーザーを削除します。</span><span class="sxs-lookup"><span data-stu-id="f4d72-201">When the title closes, remove the user from stats manager.</span></span> <span data-ttu-id="f4d72-202">これにより、サービスに最新の統計値がフラッシュされます。</span><span class="sxs-lookup"><span data-stu-id="f4d72-202">This will flush the latest stat values to the service.</span></span>

```cpp
statsManager->remove_local_user(user);
statsManager->do_work();  // applies the stat changes, returns local_user_removed after flush to service
```
