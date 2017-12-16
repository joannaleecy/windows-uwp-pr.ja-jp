---
title: "マッチの交戦"
author: KevinAsgari
description: "トーナメント エクスペリエンスでのプレイヤーの進行に伴う UX の各ステージについて説明します。"
ms.author: kevinasg
ms.date: 10-10-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アリーナ, トーナメント, UX"
ms.localizationpriority: medium
ms.openlocfilehash: 7d69ab3a5f2ce6092a2aac8dd9cb532ac0848b16
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
---
# <a name="match-engagement"></a><span data-ttu-id="042c5-104">マッチの交戦</span><span class="sxs-lookup"><span data-stu-id="042c5-104">Match engagement</span></span>

<span data-ttu-id="042c5-105">ゲーマーは、トーナメントに登録してチェックインした後、プレイできるように設定されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-105">After a gamer has registered and checked in for a tournament, they’re set up to play.</span></span> <span data-ttu-id="042c5-106">参加者は、次の 4 つのステージのいずれかに存在することになります。</span><span class="sxs-lookup"><span data-stu-id="042c5-106">A participant can be at one of four stages.</span></span> <span data-ttu-id="042c5-107">各ステージには、ゲーム内でのユーザーのトーナメント エクスペリエンスをガイドする独自の条件セットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="042c5-107">Each stage contains a unique set of criteria guiding users through the in-game tournament experience.</span></span> <span data-ttu-id="042c5-108">4 つのステージは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="042c5-108">The four stages are:</span></span>

1.  <span data-ttu-id="042c5-109">準備完了 (アリーナ UI またはゲーム内)</span><span class="sxs-lookup"><span data-stu-id="042c5-109">Ready (Arena UI or in-game)</span></span>
2.  <span data-ttu-id="042c5-110">プレイ (ゲーム内)</span><span class="sxs-lookup"><span data-stu-id="042c5-110">Playing (in-game)</span></span>
3.  <span data-ttu-id="042c5-111">結果 (アリーナ UI またはゲーム内)</span><span class="sxs-lookup"><span data-stu-id="042c5-111">Results (Arena UI or in-game)</span></span>
4.  <span data-ttu-id="042c5-112">終了 (アリーナ UI またはゲーム内)</span><span class="sxs-lookup"><span data-stu-id="042c5-112">End (Arena UI or in-game)</span></span>

> [!NOTE]  
> <span data-ttu-id="042c5-113">"プレイ" は 4 つのステージの中で、唯一、アリーナ UI でサポートされていないステージです。</span><span class="sxs-lookup"><span data-stu-id="042c5-113">Playing is the only stage of the four that is not supported in the Arena UI.</span></span> <span data-ttu-id="042c5-114">タイトルでは、少なくとも、各マッチの終了時 (プレイのステージの完了時) に参加者が結果を確認できるように、アリーナ UI にリダイレクトする必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-114">At a minimum, your title must redirect participants to the Arena UI at the end of each match (when the Playing stage is over), so they can view results.</span></span>

###### <a name="diagram-the-four-stages-of-participant-progression-after-check-in"></a><span data-ttu-id="042c5-115">図: 参加者の進行に伴う、チェックイン後の 4 つのステージ</span><span class="sxs-lookup"><span data-stu-id="042c5-115">Diagram: The four stages of participant progression, after check-in.</span></span>

![マッチの交戦フロー図](../../images/arena/arena-ux-match-flow.png)

![マッチの交戦フローのバー](../../images/arena/arena-ux-match-flow-bar.png)

## <a name="1-ready-waiting-for-match"></a><span data-ttu-id="042c5-118">1. 準備完了 ("マッチ開始待ち")</span><span class="sxs-lookup"><span data-stu-id="042c5-118">1. Ready (“Waiting for match”)</span></span>

![マッチ開始待ちの図](../../images/arena/arena-ux-flow-ready.png)

### <a name="user-impact"></a><span data-ttu-id="042c5-120">ユーザーへの影響</span><span class="sxs-lookup"><span data-stu-id="042c5-120">User impact</span></span>

<span data-ttu-id="042c5-121">このステージで、ゲーマーはマッチのプレイ開始を待っていますが、対戦相手がまだ不明です。</span><span class="sxs-lookup"><span data-stu-id="042c5-121">At this stage, the gamer expects to play in a match, but the opponent isn’t yet known.</span></span> <span data-ttu-id="042c5-122">このステージは、トーナメントが開始され、参加者がマッチ セッションの開始を待っているときにトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="042c5-122">This stage is triggered when a tournament has started and the participant is waiting for their match session to begin.</span></span> <span data-ttu-id="042c5-123">この待機時間の原因として、次のことが考えられます。</span><span class="sxs-lookup"><span data-stu-id="042c5-123">This waiting period could be because:</span></span>

* <span data-ttu-id="042c5-124">チェックイン期間がまだ締め切られていない。</span><span class="sxs-lookup"><span data-stu-id="042c5-124">The check-in period is still open.</span></span>
* <span data-ttu-id="042c5-125">次のラウンドが開始していない。</span><span class="sxs-lookup"><span data-stu-id="042c5-125">The next round hasn’t started.</span></span>
* <span data-ttu-id="042c5-126">参加者が現在のラウンドを不戦勝で勝ち進んでいる。</span><span class="sxs-lookup"><span data-stu-id="042c5-126">The participant has a bye in the current round.</span></span>

### <a name="when-a-bye-is-needed"></a><span data-ttu-id="042c5-127">不戦勝が必要な場合</span><span class="sxs-lookup"><span data-stu-id="042c5-127">When a bye is needed</span></span>

<span data-ttu-id="042c5-128">アリーナでは、シードのチームを分散させて不戦勝をできるだけ回避していますが、不戦勝はトーナメントのすべてのラウンドで発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-128">A bye can happen in any round of a tournament, even though we spread out seeding to try to avoid it.</span></span>

<span data-ttu-id="042c5-129">トーナメントがシングルエリミネーション方式かダブルエリミネーション方式かに関係なく、プレイヤー数やチーム数が 2 の累乗 (4、8、16、32、64、128、256 など) でない限り、不戦勝が必ず発生します。</span><span class="sxs-lookup"><span data-stu-id="042c5-129">Any time a single-elimination or double-elimination tournament involves a number of players or teams that is not a power of 2 (that is, 4, 8, 16, 32, 64, 128, or 256), byes must be awarded.</span></span> <span data-ttu-id="042c5-130">不戦勝とは、単純に、チームがトーナメントの最初のラウンドに参加する必要がなく、戦わずに 2 回戦に進出することを意味します。</span><span class="sxs-lookup"><span data-stu-id="042c5-130">A bye simply means that a team does not have to participate in the first round of the tournament, and instead gets a free pass to the second round.</span></span>

### <a name="discovery"></a><span data-ttu-id="042c5-131">情報表示</span><span class="sxs-lookup"><span data-stu-id="042c5-131">Discovery</span></span>

![チームの情報表示のスクリーンショット](../../images/arena/arena-ux-team-discovery.png)

<span data-ttu-id="042c5-133">準備完了ステージでは、参加者は次の場所でステータスを確認できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-133">In the Ready stage, participants learn about their status in these places:</span></span>

* <span data-ttu-id="042c5-134">アリーナ UI: トーナメントの詳細ページ</span><span class="sxs-lookup"><span data-stu-id="042c5-134">Arena UI: Tournament Detail page</span></span>
* <span data-ttu-id="042c5-135">ゲーム内: トーナメントの一覧、宣伝、マッチ ロビー</span><span class="sxs-lookup"><span data-stu-id="042c5-135">In game: Tournament list, Promotion, Match Lobby</span></span>

> [!TIP]  
> **<span data-ttu-id="042c5-136">推奨される UX</span><span class="sxs-lookup"><span data-stu-id="042c5-136">UX recommendations</span></span>**  
> <span data-ttu-id="042c5-137">プレイヤーがイベントの次のマッチを待っている状態であることを明確に表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-137">Indicate that the player is waiting for their next match in the event.</span></span> <span data-ttu-id="042c5-138">例: "マッチが保留中です"、"不戦勝です" などの通知を表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-138">Examples: “Match pending” or “You have received a bye” notification.</span></span>  
>
> <span data-ttu-id="042c5-139">このステージをサポートする場合は、トーナメントの詳細ページに戻る方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="042c5-139">If this stage is supported, provide a method to return to the Tournament Detail page.</span></span>  
>
> <span data-ttu-id="042c5-140">イベントの情報として、トーナメント名、状態、スタイル、説明、開始時刻や終了日時などを表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-140">Give context of the event: Tournament name, State, Style, description, Start time/end time, etc.</span></span>


###### <a name="ui-example-in-game-multiplayer-lobby"></a><span data-ttu-id="042c5-141">UI の例: ゲーム内のマルチプレイヤー ロビー</span><span class="sxs-lookup"><span data-stu-id="042c5-141">UI Example: In-game Multiplayer Lobby</span></span>

![トーナメント ロビーのスクリーンショット](../../images/arena/arena-ux-tournament-lobby.png)

<span data-ttu-id="042c5-143">トーナメント マッチを宣伝する場合、またはマッチの詳細を表示する場合、常にトーナメントの状態と理由を一定の位置に表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-143">Always present the Tournament State and Reason in a consistent position, wherever a tournament match is promoted or match details are presented.</span></span>

<span data-ttu-id="042c5-144">これらの情報は、ゲーマーが次の判断を行ううえで非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="042c5-144">This is critical guidance for gamers when they must decide:</span></span>

* <span data-ttu-id="042c5-145">ゲームを終了して詳細情報を表示するかどうか。</span><span class="sxs-lookup"><span data-stu-id="042c5-145">To leave the game to learn more.</span></span>
* <span data-ttu-id="042c5-146">トーナメントで次に進むためには、どのような手順が必要か。</span><span class="sxs-lookup"><span data-stu-id="042c5-146">What next steps are needed to progress while in a tournament.</span></span>

### <a name="under-the-hood"></a><span data-ttu-id="042c5-147">内部的な処理</span><span class="sxs-lookup"><span data-stu-id="042c5-147">Under the hood</span></span>
<span data-ttu-id="042c5-148">タイトルでこのステージをサポートする場合は、マッチの準備ができた時点で、プレイのステージに進みます。</span><span class="sxs-lookup"><span data-stu-id="042c5-148">If this stage is supported by the title, proceed to the Playing stage when the match is ready.</span></span>

 
## <a name="2-playing"></a><span data-ttu-id="042c5-149">2. プレイ</span><span class="sxs-lookup"><span data-stu-id="042c5-149">2. Playing</span></span>

![マッチのプレイの図](../../images/arena/arena-ux-flow-play.png)

### <a name="user-impact"></a><span data-ttu-id="042c5-151">ユーザーへの影響</span><span class="sxs-lookup"><span data-stu-id="042c5-151">User impact</span></span>

<span data-ttu-id="042c5-152">プレイヤーの次の対戦相手が明らかになり、マルチプレイヤー セッションの作成が完了します。</span><span class="sxs-lookup"><span data-stu-id="042c5-152">The player’s next match-up is known and the multiplayer session has been created.</span></span> <span data-ttu-id="042c5-153">このステージでは、タイトルでプレイヤーに対して通常のゲーム フローが実行されます (マッチセットアップ画面、ゲーム ロビーなど)。</span><span class="sxs-lookup"><span data-stu-id="042c5-153">During this stage, the title moves the players through the normal game flow (match-setup screens, game lobby, and so on).</span></span> <span data-ttu-id="042c5-154">ユーザーは、マッチの準備が完了すると、このステージに到達します。</span><span class="sxs-lookup"><span data-stu-id="042c5-154">This is the stage that users reach when the match is ready.</span></span>

### <a name="discovery"></a><span data-ttu-id="042c5-155">情報表示</span><span class="sxs-lookup"><span data-stu-id="042c5-155">Discovery</span></span>

<span data-ttu-id="042c5-156">トーナメントの参加者にアラートを表示し、ゲームの外部からトーナメント マッチへの参加を可能にするには、次の 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-156">There are two ways to alert a tournament participant and enable them to join a Tournament Match from outside a game:</span></span>

* <span data-ttu-id="042c5-157">**Xbox のトースト通知**: この通知が表示されるた場合、参加者は ![Nexus ボタン](../../images/xbox-nexus.png) (Nexus ボタン) を長押ししてゲームを起動し、マッチに移動することができます。</span><span class="sxs-lookup"><span data-stu-id="042c5-157">**Xbox toast notification** – When the notification appears, the participant can hold the  ![nexus button](../../images/xbox-nexus.png) (Nexus button) to launch the game and enter a match.</span></span>

  ![マッチの準備完了トースト](../../images/arena/arena-ux-match-ready-toast.png)

* <span data-ttu-id="042c5-159">アリーナのトーナメントの詳細ページ: 参加者は **[Play]** (プレイ) を選択して、ゲームを起動し、マッチに移動します。</span><span class="sxs-lookup"><span data-stu-id="042c5-159">Arena Tournament Detail Page – The participant can select **Play** to launch the game and enter a match</span></span>
 
> [!TIP]  
> <span data-ttu-id="042c5-160">**推奨される UX:** マッチへの移動について、ユーザーに確認を求めます。</span><span class="sxs-lookup"><span data-stu-id="042c5-160">**UX recommendation:** Confirm match entry.</span></span>  
> <span data-ttu-id="042c5-161">マッチ ロビーに直接移動しようとしていることを参加者に通知するか、参加者の確認を求める (またはその両方を行う) UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-161">Show UI that informs and/or confirms that the participant is about to enter directly into a match lobby.</span></span>

###### <a name="ui-example-match-entry-confirmation-dialog-box"></a><span data-ttu-id="042c5-162">UI の例: マッチへの移動を確認するダイアログ ボックス</span><span class="sxs-lookup"><span data-stu-id="042c5-162">UI Example: match entry confirmation dialog box</span></span>

![マッチへの移動を確認するダイアログ ボックス](../../images/arena/arena-ux-confirm-match-entry.png)

<span data-ttu-id="042c5-164">参加者がゲーム以外の場所からトーナメントに移動することを選択した場合に、この UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-164">Display this UI after the participant chooses to enter a tournament from a location outside the game.</span></span> <span data-ttu-id="042c5-165">ゲームの起動後、マッチ ロビーへの移動前にこれを表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-165">Do this after a game has launched and before entering the match lobby.</span></span>

> [!TIP]  
> <span data-ttu-id="042c5-166">**推奨される UX:** キャンセルするオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="042c5-166">**UX recommendation:** Give an option to cancel.</span></span>

<span data-ttu-id="042c5-167">参加者は、トーナメントに向けた準備作業の必要性に気付くことがあります。</span><span class="sxs-lookup"><span data-stu-id="042c5-167">Participants may decide there are other tasks they need to complete to prepare for the tournament.</span></span> <span data-ttu-id="042c5-168">参加者の気が変わったときに対応できる柔軟性が必要です。</span><span class="sxs-lookup"><span data-stu-id="042c5-168">It’s important to give them the flexibility to change their mind.</span></span> <span data-ttu-id="042c5-169">タイトルでは、次のような追加のオプションを提供できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-169">Your title can offer additional options:</span></span>

* <span data-ttu-id="042c5-170">ゲームに留まる </span><span class="sxs-lookup"><span data-stu-id="042c5-170">Stay in the game.</span></span> <span data-ttu-id="042c5-171">(参加者は、メイン メニューに移動します)。</span><span class="sxs-lookup"><span data-stu-id="042c5-171">(The participant is taken to the main menu.)</span></span>
* <span data-ttu-id="042c5-172">アリーナ UI に戻る。</span><span class="sxs-lookup"><span data-stu-id="042c5-172">Return to the Arena UI.</span></span>
* <span data-ttu-id="042c5-173">参加者が、ゲームからの離脱を選択する場合、タイトルで失効タイムアウト制限に達するまでの残り時間を参加者に表示することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="042c5-173">If the participant chooses to leave the game, we recommend that your title inform the participant of the time remaining before the Forfeit time-out limit has been reached.</span></span>

###### <a name="ui-example-match-entry-confirmation--leave-game-warning"></a><span data-ttu-id="042c5-174">UI の例: マッチへの移動の確認とゲーム終了の警告</span><span class="sxs-lookup"><span data-stu-id="042c5-174">UI Example: match entry confirmation – leave game warning</span></span>

![マッチへの移動と失効タイムアウトまでの残り時間を確認するダイアログ ボックス](../../images/arena/arena-ux-confirm-match-cancel.png)

### <a name="playing-a-match"></a><span data-ttu-id="042c5-176">マッチのプレイ</span><span class="sxs-lookup"><span data-stu-id="042c5-176">Playing a match</span></span>

<span data-ttu-id="042c5-177">マッチの開始時刻は、セッション テンプレートで定義されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-177">The start time for the match is defined in the session template.</span></span> <span data-ttu-id="042c5-178">たとえば、`2009-06-15T13:45:30.0900000Z` のように、標準の UTC 形式で日付と時刻が設定されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-178">It is set as a date-time in the standard UTC format—for example, `2009-06-15T13:45:30.0900000Z`.</span></span> <span data-ttu-id="042c5-179">トーナメント主催者は、開始時刻前にいつでも (または開示時刻と同時に) セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-179">The tournament organizer can create the session as far in advance of the start time as it wants to, including concurrently with the start time.</span></span> <span data-ttu-id="042c5-180">マッチ通知は開始時刻にマッチ参加者に送信されるため、タイトルが開始時刻より前にアクティブ化されることはありません。</span><span class="sxs-lookup"><span data-stu-id="042c5-180">Match notifications are sent to the match participants at the start time, so titles never get activated before the start time.</span></span> <span data-ttu-id="042c5-181">一般に、アリーナ セッションは、タイトル自体のマルチプレイヤー セッションと同じ方法で処理できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-181">In general, treat the Arena session the same way that you would treat your title’s own multiplayer session.</span></span> <span data-ttu-id="042c5-182">ただし、いくつか違いがあります。</span><span class="sxs-lookup"><span data-stu-id="042c5-182">However, there are a few differences:</span></span>

* <span data-ttu-id="042c5-183">ゲーム セッションのロースターは、タイトル側では変更できません。</span><span class="sxs-lookup"><span data-stu-id="042c5-183">Your title can’t change the roster of the game session.</span></span>
* <span data-ttu-id="042c5-184">接続速度に問題があるプレイヤーを特定するための、通常の審査プロセスが存在しません。</span><span class="sxs-lookup"><span data-stu-id="042c5-184">There isn’t the usual vetting process for players with problematic connection speeds.</span></span>
* <span data-ttu-id="042c5-185">タイトルは、判定に参加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-185">Your title must participate in arbitration.</span></span>

### <a name="match-lobby-details"></a><span data-ttu-id="042c5-186">マッチ ロビーの詳細情報</span><span class="sxs-lookup"><span data-stu-id="042c5-186">Match lobby details</span></span>

<span data-ttu-id="042c5-187">トーナメントのマッチ ロビーでは、それがトーナメントであり、通常のマルチプレイヤー マッチとは異なることを明確に示す詳細情報を表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-187">A tournament match lobby should include details that make it clear that it’s a tournament, and that it’s different from a standard multiplayer match.</span></span> <span data-ttu-id="042c5-188">このような詳細情報では、たとえば、タイマー、関係するチーム、一連のラウンド番号やステージ番号などを表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-188">Examples of such details are timing, team dependency, and consecutive rounds and stages.</span></span> <span data-ttu-id="042c5-189">マッチが終了した時点で、ステージ 3 (結果待ち) に進むか、アリーナ UI にプレイヤーを戻します。</span><span class="sxs-lookup"><span data-stu-id="042c5-189">When the match is over, either proceed to stage 3 (Awaiting Results) or return the player to the Arena UI.</span></span>

###### <a name="ui-example-match-lobby-details"></a><span data-ttu-id="042c5-190">UI の例: マッチ ロビーの詳細情報</span><span class="sxs-lookup"><span data-stu-id="042c5-190">UI Example: Match Lobby details</span></span>

![マッチ ロビーの詳細情報画面](../../images/arena/arena-ux-match-lobby-details.png)

<span data-ttu-id="042c5-192">**A**: これが ”トーナメント”、つまり ”アリーナ” マッチであることを明確に示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-192">**A** - Reinforce that this is a ”Tournament” or ”Arena” match.</span></span>  
<span data-ttu-id="042c5-193">**B**: トーナメントの詳細</span><span class="sxs-lookup"><span data-stu-id="042c5-193">**B** - Tournament Detail</span></span>  
   1. <span data-ttu-id="042c5-194">トーナメント名 (128 文字以内)</span><span class="sxs-lookup"><span data-stu-id="042c5-194">Tournament name (128 characters maximum)</span></span>  
   2. <span data-ttu-id="042c5-195">スタイル、ゲーム モード</span><span class="sxs-lookup"><span data-stu-id="042c5-195">Style, Game Mode</span></span>  
   3. <span data-ttu-id="042c5-196">ラウンド番号またはステージ番号</span><span class="sxs-lookup"><span data-stu-id="042c5-196">Round or Stage number</span></span>  

<span data-ttu-id="042c5-197">**C**: [Ready Up/Play] (準備/プレイ) ボタン。参加者は既にトーナメントに移動していても、マッチ セッション開始までさらに時間が必要な場合があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-197">**C** - Ready Up/Play button – Participants may have entered a tournament, but require extra time before beginning the match session.</span></span> <span data-ttu-id="042c5-198">たとえば、状況によっては、マッチのためのキャラクター選択などの設定時間が必要です。</span><span class="sxs-lookup"><span data-stu-id="042c5-198">For example, a match may require set-up, such as character selection.</span></span> <span data-ttu-id="042c5-199">このアフォーダンスによって、準備が完了したときに、相手チームのメンバーにそれを通知できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-199">This affordance can inform the other team members when they are ready.</span></span>  
<span data-ttu-id="042c5-200">**D**: カウントダウン タイマー</span><span class="sxs-lookup"><span data-stu-id="042c5-200">**D** - Countdown timer</span></span>
  * <span data-ttu-id="042c5-201">このタイマーは、**失効タイムアウト制限**(ゲームごとに設定) に基づいて表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-201">The timer is based on the **forfeit time-out limit** (set by the game).</span></span>
  * <span data-ttu-id="042c5-202">このタイマーは、この時間内にチームの最小要件が充足されていない場合、ゲームが失効し、アクティブなチームが勝者となることを両方のチームに示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-202">This warns both teams that if the minimum team requirements are not met by this time, the game is forfeited and the active team wins.</span></span>  

<span data-ttu-id="042c5-203">**E**: 配信に関するリマインダー</span><span class="sxs-lookup"><span data-stu-id="042c5-203">**E** - Broadcast reminder</span></span>  
<span data-ttu-id="042c5-204">**F**: チーム名と参加者</span><span class="sxs-lookup"><span data-stu-id="042c5-204">**F** - Team Name + participants</span></span>

 
### <a name="under-the-hood"></a><span data-ttu-id="042c5-205">内部的な処理</span><span class="sxs-lookup"><span data-stu-id="042c5-205">Under the hood</span></span>

#### <a name="protocol-activation"></a><span data-ttu-id="042c5-206">プロトコルのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="042c5-206">Protocol activation</span></span>

<span data-ttu-id="042c5-207">ユーザーがマッチでプレイする準備ができたら (アリーナからの "マッチの準備完了" トーストに同意するなど)、アリーナ UI が参加者を直接タイトルに移動してマッチが開始されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-207">The Arena UI kicks things off by sending participants directly into a title when a user is ready to play a match—for example, when accepting the “match ready” toast sent by the Arena.</span></span> <span data-ttu-id="042c5-208">プロトコルのアクティブ化が行われるタイミングには、タイトルを起動するとき、またはタイトルが既に実行されているときの 2 つの可能性があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-208">Protocol activation can occur at two times: as the title is launched, or when it’s already running.</span></span> <span data-ttu-id="042c5-209">いずれの場合も、アクティブ化は、ユーザーがマルチプレイヤー ゲームへの招待を受け入れ、それに対応してタイトルがアクティブ化される場合と同様に処理されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-209">In both cases,  activation is similar to what happens when a title is activated in response to a user accepting an invitation to the game.</span></span>

* <span data-ttu-id="042c5-210">**タイトルを起動する場合**: **Activated** イベントは、タイトルの起動時に初めて発生します。</span><span class="sxs-lookup"><span data-stu-id="042c5-210">**If the title is being launched** -- The **Activated** event fires for the first time when the title is launched.</span></span> <span data-ttu-id="042c5-211">その最初のアクティブ化がアリーナのプロトコルのアクティブ化である場合、それはタイトルを起動したのが、トーナメントでプレイしようとしているユーザーであることを意味します。</span><span class="sxs-lookup"><span data-stu-id="042c5-211">If that initial activation is an Arena protocol activation, it means that the title was launched by a user attempting to play in a tournament.</span></span> <span data-ttu-id="042c5-212">したがってタイトルは、メイン メニューとログイン画面をバイパスして、できるだけ迅速にマッチにスキップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-212">The title should skip as quickly as possible to the match, bypassing the main menu and sign-in screens.</span></span> <span data-ttu-id="042c5-213">また参加ユーザーの Xbox ユーザー ID (XUID) がアクティブ化 URI に提供されて、ログインが既に完了しています。</span><span class="sxs-lookup"><span data-stu-id="042c5-213">The Xbox User ID (XUID) of the participating user is provided in the activation URI and should already be signed-in.</span></span>

* <span data-ttu-id="042c5-214">**タイトルが既に実行されている場合**: **Activation** イベントは、タイトルが既に実行されているときに、アリーナのプロトコルのアクティブ化と共に生成することもできます。</span><span class="sxs-lookup"><span data-stu-id="042c5-214">**If the title was already running** -- The **Activation** event can also fire with an Arena protocol activation while the title is already running.</span></span> <span data-ttu-id="042c5-215">タイトルがプロトコルのアクティブ化を受信したときに、アイドル状態である場合、タイトルはトーナメント マッチに直ちに切り替える必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-215">If the title is idle when it receives the protocol activation, it should jump immediately to the tournament match.</span></span> <span data-ttu-id="042c5-216">アクティブ化イベントは、明示的なユーザー操作 (マッチを通知するトーストへの操作、またはアリーナ UI からマッチへの切り替え) によってのみトリガーされるため、このような動作を安全に実行できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-216">It’s safe to do that because the activation event is triggered only by an explicit user action (either acting on a toast that leads to the match, or jumping into the match from the Arena UI).</span></span> <span data-ttu-id="042c5-217">またゲームプレイ中にタイトルがプロトコルのアクティブ化を受け取った場合は、ユーザーに対し、最も効率的な方法でゲームを終了して (必要に応じて、その前にゲームを保存し)、トーナメント マッチに移動するオプションを表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-217">If the title receives the protocol activation during gameplay, it should give the user the option to leave the game (saving it first, if necessary) and enter the tournament match in the most expedient way possible.</span></span>

* <span data-ttu-id="042c5-218">**参加者が Xbox のトースト通知をバイパスする場合**: アリーナ対応のタイトルは、起動時にユーザーがアクティブなマッチに参加中かどうかを確認するため、アリーナへのクエリを実行することが推奨されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-218">**If a participant bypasses the Xbox toast notification** -- We recommend that an Arena-enabled title always query Arena on startup to see whether the user is in an active match.</span></span> <span data-ttu-id="042c5-219">その場合、タイトルは "マッチへの移動確認" の UI を表示して、参加するマッチがあることをユーザーに示し、それに移動するかどうかをたずねる必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-219">If so, the title should present the “confirm match entry” UI, to tell the user they have a match and ask whether they want to enter it.</span></span>  

  <span data-ttu-id="042c5-220">これにより、参加者は、トーストを見逃し、(マッチに移行するつもりで) ゲームだけを起動した場合でも、トーナメント マッチに適切に移行できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-220">This ensures that participants make the transition into a tournament match correctly, in case they miss the match toast and simply launch the game (expecting to get into their match).</span></span> <span data-ttu-id="042c5-221">またはゲームがクラッシュした場合も、参加者はタイトルを再起動するだけで、マッチに戻ることができます。</span><span class="sxs-lookup"><span data-stu-id="042c5-221">Or, in case the game crashes and the participant just relaunches the title to get back into their match.</span></span>

> [!NOTE]  
> <span data-ttu-id="042c5-222">タイトルでは、プロトコルのアクティブ化 URI の XUID を確認する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-222">The title should check the XUID on the protocol activation URI.</span></span> <span data-ttu-id="042c5-223">さらに、それがタイトルの現在のプレイヤーと一致しない場合、タイトルではユーザー コンテキストの切り替えも必要になります。</span><span class="sxs-lookup"><span data-stu-id="042c5-223">If it doesn’t match the current player of the title, the title must also switch user contexts.</span></span>

#### <a name="forfeit-time-out"></a><span data-ttu-id="042c5-224">失効タイムアウト</span><span class="sxs-lookup"><span data-stu-id="042c5-224">Forfeit time-out</span></span>

<span data-ttu-id="042c5-225">失効時刻 (開始時刻に失効タイムアウト時間を加えた時刻) の前に、セッション内で少なくとも 1 人のプレイヤーがアクティブである必要があります (「プレイ」の図を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="042c5-225">At least one player must be active in the session before the forfeit time, which is the start time plus the forfeit time-out (See Playing Diagram).</span></span> <span data-ttu-id="042c5-226">失効時刻までに参加済みのアクティブなプレイヤーがいない場合、マッチはキャンセルされ、アリーナの判定によって両方のチームが敗者となります。</span><span class="sxs-lookup"><span data-stu-id="042c5-226">If no one has joined the session as active before the forfeit time, the match is canceled and both teams are given a loss via Arena arbitration.</span></span>
 
## <a name="3-results"></a><span data-ttu-id="042c5-227">3. 結果</span><span class="sxs-lookup"><span data-stu-id="042c5-227">3. Results</span></span>

![マッチの結果の図](../../images/arena/arena-ux-flow-results.png)

<span data-ttu-id="042c5-229">結果ステージは、プレイヤーがマッチを完了し、判定のために結果が報告されるステージです。</span><span class="sxs-lookup"><span data-stu-id="042c5-229">This is the stage when a player has completed the match and the results have been reported to be arbitrated.</span></span> <span data-ttu-id="042c5-230">この時点では、チームがトーナメントに留まるかどうかはまだ確定していません。</span><span class="sxs-lookup"><span data-stu-id="042c5-230">At this point, it’s not yet been determined whether the team is still in the tournament.</span></span> <span data-ttu-id="042c5-231">結果が確定するまでの間、"ゲーム終了" 画面エクスペリエンスでは、(通常のマルチプレイヤー マッチで行われているように)セッションの結果報告を引き続き表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-231">In the meantime, the “end game” screen experience should continue reporting the results of the session (just like in any multiplayer match).</span></span>

<span data-ttu-id="042c5-232">その後、ノー コンテスト (無効試合)、勝利、敗退、引き分け、ランク、不参加などのトーナメント結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-232">The tournament results—No contest (no game), Win, Loss, Draw, Rank, or No Show—will follow.</span></span>

<span data-ttu-id="042c5-233">結果がすぐに表示される場合は、このステージをスキップすることができます。</span><span class="sxs-lookup"><span data-stu-id="042c5-233">It’s possible for this stage to be skipped if the result is available immediately.</span></span>

### <a name="reporting-results"></a><span data-ttu-id="042c5-234">結果の報告</span><span class="sxs-lookup"><span data-stu-id="042c5-234">Reporting results</span></span>

<span data-ttu-id="042c5-235">マッチの結果は、*判定*と呼ばれる機能を使って、セッション経由でアリーナとトーナメント主催者に報告されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-235">The results of the match are reported back to Arena and the tournament organizer through the session by using a feature called *arbitration*.</span></span> <span data-ttu-id="042c5-236">判定は、マッチ セッションを使って安全にマッチをプレイし、結果を報告するフレームワークです。</span><span class="sxs-lookup"><span data-stu-id="042c5-236">Arbitration is a framework for using a match session to securely play a match and report a result.</span></span>

<span data-ttu-id="042c5-237">マッチ セッションが開始されると、そのセッションは判定のフレームワークで管理されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-237">When a match session begins, it is considered an arbitrated session.</span></span> <span data-ttu-id="042c5-238">判定には決まったタイムラインがあり、それによって判定フレームワークが適用されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-238">It has a fixed timeline, which the arbitration framework enforces.</span></span>
 
### <a name="arbitration-time-out"></a><span data-ttu-id="042c5-239">判定タイムアウト</span><span class="sxs-lookup"><span data-stu-id="042c5-239">Arbitration time-out</span></span>

<span data-ttu-id="042c5-240">判定タイムアウトは、マッチの開始後、参加者がプレイして結果を報告するまでの最長時間です。</span><span class="sxs-lookup"><span data-stu-id="042c5-240">The arbitration time-out is the maximum amount of time, after the match start time, that participants have to play and report results.</span></span> <span data-ttu-id="042c5-241">この値は、トーナメント主催者が実施するイベントでは、セッション テンプレートに設定され、UGT やフランチャイズ実行型のイベントでは、アリーナ マルチプレイヤー ゲーム モードで設定されるため、タイトルに必要な時間を自由に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="042c5-241">This value is set in the session template for tournament organizer-run events and in the Arena Multiplayer Game Mode for UGT and franchise-run events, so it can be as much time as your title needs.</span></span>

<span data-ttu-id="042c5-242">タイトルは、開始時刻から判定時刻までの間であれば、いつでも結果を報告できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-242">The title can report results at any time between the start time and the arbitration time.</span></span> <span data-ttu-id="042c5-243">判定は、失効時刻から判定時刻までの間に、セッションのすべてのアクティブなメンバーの結果が送信された後で随時実行されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-243">Arbitration occurs at any time between the forfeit time and the arbitration time, after every active member of the session has submitted results.</span></span> <span data-ttu-id="042c5-244">たとえば、失効時にアクティブなメンバーが 1 人だけのセッションでも、メンバーは結果を投稿でき (または投稿しなければならず)、判定が行われます。</span><span class="sxs-lookup"><span data-stu-id="042c5-244">For example, if just one member is active in the session at the forfeit time, they can (and should) post a result, and arbitration will occur.</span></span> <span data-ttu-id="042c5-245">判定は、判定時刻までに報告された結果の数に関係なく、実行済みでない限り実行されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-245">No matter how many results are available at arbitration time, arbitration will occur if it hasn’t already.</span></span>

<span data-ttu-id="042c5-246">ユーザーのいるセッションが既に判定済みの場合 (判定タイムアウトに達した場合や、ゲーム サーバーがセッションを判定する場合、またはユーザーの参加が遅れた場合)、タイトルはマッチを終了して判定結果をユーザーに表示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-246">If a user happens to be in a session that has already been arbitrated (because the arbitration time-out expired, a game server arbitrates the session, or the user joins late), your title should end the match and display the arbitrated result to the user.</span></span>

<span data-ttu-id="042c5-247">判定結果には、常に、すべてのチームの結果が含まれます。</span><span class="sxs-lookup"><span data-stu-id="042c5-247">Arbitration results always include the outcome for every team.</span></span> <span data-ttu-id="042c5-248">個々のプレイヤーのスコアが報告されると、自分のチームの結果だけでなく、すべてのチームの完全な結果のセットが判定結果に含まれます。</span><span class="sxs-lookup"><span data-stu-id="042c5-248">When an individual player’s score is reported, it includes not just their team’s outcome, but the full set of results for every team.</span></span>
<span data-ttu-id="042c5-249">判定は、最初のクライアントが Xbox Live に結果を報告するとすぐに自動的に開始され、</span><span class="sxs-lookup"><span data-stu-id="042c5-249">Arbitration begins automatically as soon as the first client reports results to Xbox Live.</span></span> <span data-ttu-id="042c5-250">すべてのクライアントが結果を報告すると直ちに終了します。</span><span class="sxs-lookup"><span data-stu-id="042c5-250">It ends as soon as all clients report results.</span></span> <span data-ttu-id="042c5-251">参加者がセッション テンプレートで指定された判定時間を超えてプレイすることがあります。</span><span class="sxs-lookup"><span data-stu-id="042c5-251">There may be instances where participants play longer than the arbitration time specified in the session template.</span></span> <span data-ttu-id="042c5-252">この場合、参加者の準備が完了する前に、マッチが強制的に終了するおそれがあります。</span><span class="sxs-lookup"><span data-stu-id="042c5-252">This incurs a risk that a match is forced to end before participants are ready.</span></span>

> [!TIP]  
> <span data-ttu-id="042c5-253">**推奨される UX:** マッチセッションに固定の時間枠を設定します。</span><span class="sxs-lookup"><span data-stu-id="042c5-253">**UX recommendation:** Provide a fixed match-session time frame.</span></span>
>
> <span data-ttu-id="042c5-254">マッチ セッションの時間制限を事前に定義することで、判定タイムアウトの問題が発生する可能性が減少します。</span><span class="sxs-lookup"><span data-stu-id="042c5-254">Predefined time limits on match sessions will reduce the risk of problems occurring from arbitration time-out.</span></span>

<span data-ttu-id="042c5-255">参加者のプレイが終了する前にマッチが終了することを防止する場合、2 つのオプションがあります。</span><span class="sxs-lookup"><span data-stu-id="042c5-255">There are two options for preventing a match from ending before participants are done playing:</span></span>

* <span data-ttu-id="042c5-256">1 つは、判定タイムアウトを非常に大きな値に設定することです。</span><span class="sxs-lookup"><span data-stu-id="042c5-256">Set a generous time frame for arbitration time-out.</span></span>
* <span data-ttu-id="042c5-257">固定の時間枠を設定することが、タイトルのゲームプレイのスタイルに合わない場合は、次の解決方法を検討してください。</span><span class="sxs-lookup"><span data-stu-id="042c5-257">If a fixed time frame conflicts with your title’s gameplay style, try the following solution:</span></span>
   1.   <span data-ttu-id="042c5-258">結果が報告されていないこと、および判定タイムアウトがまもなく時間切れになること (残り時間が 5 分など) を判断します。</span><span class="sxs-lookup"><span data-stu-id="042c5-258">Determine that results have not been reported, and that the arbitration time-out is about to expire (for example, five minutes are left).</span></span>
   2.   <span data-ttu-id="042c5-259">ゲームが X 分後に終了することを参加者に警告する UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-259">Display UI that alerts the participants their game is about to end in X minutes.</span></span> <span data-ttu-id="042c5-260">このオプションはすべてのトーナメントに実装でき、判定タイムアウトを非常に大きな値に設定している場合、参加者に表示されることはほとんどありません。</span><span class="sxs-lookup"><span data-stu-id="042c5-260">This option can be implemented for all tournaments, and if the arbitration time-out is generous, most participants will never see it.</span></span>

### <a name="returning-to-the-arena-ui-by-using-a-dedicated-a-button-press"></a><span data-ttu-id="042c5-261">専用のボタンを使ってアリーナ UI に戻る</span><span class="sxs-lookup"><span data-stu-id="042c5-261">Returning to the Arena UI by using a dedicated a button-press</span></span>

<span data-ttu-id="042c5-262">タイトルがゲーム内でトーナメントの結果やステージの進行状況を表示しない場合は、これらの情報を提供する UI に戻るための方法を参加者に提供することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="042c5-262">If your title doesn’t surface tournament results or stage progression in-game, we recommend that the participant have a way to return to UI that does offer this information.</span></span> <span data-ttu-id="042c5-263">戻り先は、アリーナ UI か、サードパーティのトーナメント主催者アプリが考えられます。</span><span class="sxs-lookup"><span data-stu-id="042c5-263">This could be the Arena UI or a third-party tournament organizer app.</span></span> <span data-ttu-id="042c5-264">このアフォーダンスは、マッチ終了後、またはプレイヤーがマッチの途中で終了を要求した場合の対応として表示することが適切です。</span><span class="sxs-lookup"><span data-stu-id="042c5-264">Ideally, this affordance would appear after the match is over, or potentially in response to a player’s request to abandon the match in progress.</span></span> <span data-ttu-id="042c5-265">これは、ゲームの終了レポートの画面から実行できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-265">This could be done from an end-of-game report screen.</span></span>

> [!TIP]  
> **<span data-ttu-id="042c5-266">推奨される UX</span><span class="sxs-lookup"><span data-stu-id="042c5-266">UX recommendation</span></span>**  
> <span data-ttu-id="042c5-267">Xbox ダッシュボードに、ゲーマーがアリーナ ハブへ即座に戻るための専用のコントローラー ボタンを用意します。</span><span class="sxs-lookup"><span data-stu-id="042c5-267">Dedicate a controller button as a quick way for gamers to return to the Arena Hub in the Xbox Dashboard.</span></span>  
>
> ![アリーナ ハブのコントローラー ボタン](../../images/arena/arena-ux-arena-hub-button.png)

### <a name="redirect-participants-at-the-end-of-a-match"></a><span data-ttu-id="042c5-269">参加者をマッチの最後にリダイレクトする</span><span class="sxs-lookup"><span data-stu-id="042c5-269">Redirect participants at the end of a match</span></span>

<span data-ttu-id="042c5-270">参加者がマッチを終了した時点で、次のステップを明確に示すことが重要です。</span><span class="sxs-lookup"><span data-stu-id="042c5-270">When participants complete the match, it’s important that your title give clear direction on next steps.</span></span> <span data-ttu-id="042c5-271">これには、トーナメント ラウンドやステージの結果を確認する方法を示すことが含まれます (ゲーム内で提示されない場合)。</span><span class="sxs-lookup"><span data-stu-id="042c5-271">This includes a method to review tournament round or stage results (if not presented in-game).</span></span>

> [!TIP]  
> <span data-ttu-id="042c5-272">**推奨される UX:** ポップアップ オーバーレイを使用します。</span><span class="sxs-lookup"><span data-stu-id="042c5-272">**UX recommendation:** Use a pop-up overlay.</span></span>
>
> <span data-ttu-id="042c5-273">この UI は、トーナメント結果が存在し、ゲーム終了エクスペリエンスが完了したときに表示されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-273">This UI appears when tournament results are in, and the end-game experience is complete.</span></span>

### <a name="recommended-ui-data"></a><span data-ttu-id="042c5-274">推奨される UI データ:</span><span class="sxs-lookup"><span data-stu-id="042c5-274">Recommended UI data:</span></span>

* <span data-ttu-id="042c5-275">トーナメント名</span><span class="sxs-lookup"><span data-stu-id="042c5-275">Tournament name</span></span>
* <span data-ttu-id="042c5-276">次の対戦の組み合わせ</span><span class="sxs-lookup"><span data-stu-id="042c5-276">Next bracket</span></span>
* <span data-ttu-id="042c5-277">次のラウンドまたはステージの詳細</span><span class="sxs-lookup"><span data-stu-id="042c5-277">Next round or stage details</span></span>
* <span data-ttu-id="042c5-278">チームの順位</span><span class="sxs-lookup"><span data-stu-id="042c5-278">Team standing</span></span>
* <span data-ttu-id="042c5-279">判定結果</span><span class="sxs-lookup"><span data-stu-id="042c5-279">Arbitrated results</span></span>
* <span data-ttu-id="042c5-280">トーナメントの詳細へのディープ リンク</span><span class="sxs-lookup"><span data-stu-id="042c5-280">Deep link to Tournament Details</span></span>
* <span data-ttu-id="042c5-281">ゲームに留まるためのオプション</span><span class="sxs-lookup"><span data-stu-id="042c5-281">Option to stay in game</span></span>

### <a name="under-the-hood"></a><span data-ttu-id="042c5-282">内部的な処理</span><span class="sxs-lookup"><span data-stu-id="042c5-282">Under the hood</span></span>

<span data-ttu-id="042c5-283">アリーナ UI を呼び出した後、タイトルは (おそらくは同じ画面で) 引き続き実行され、別のプロトコルのアクティブ化イベントが発生するまで待機する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-283">After invoking the Arena UI, your title should continue running, possibly at that same screen, waiting for another protocol-activation event.</span></span> <span data-ttu-id="042c5-284">これにより、プレイヤーが別のマッチをプレイする場合に、タイトルがすぐに対応できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-284">Then, if the player has another match to play, the title will be ready to go.</span></span> <span data-ttu-id="042c5-285">プレイヤーがタイトルとアリーナ UI を切り替えて、マッチ間をスピーディに移動でき、迅速なユーザー エクスペリエンスが実現します。</span><span class="sxs-lookup"><span data-stu-id="042c5-285">It can expedite the user experience as the player goes from match to match, switching between the title and Arena UI.</span></span>

###### <a name="ui-example-tournament-arbitrated-resultswinning-team"></a><span data-ttu-id="042c5-286">UI の例: トーナメント判定結果 — 勝利チーム</span><span class="sxs-lookup"><span data-stu-id="042c5-286">UI Example: Tournament arbitrated results—Winning team</span></span>

![勝利を伝える画面](../../images/arena/arena-ux-won-game-redirect.png)

###### <a name="ui-example-end-of-tournament-resultsmatch-ended"></a><span data-ttu-id="042c5-288">UI の例: トーナメント終了結果 — マッチ終了</span><span class="sxs-lookup"><span data-stu-id="042c5-288">UI Example: End-of-tournament results—Match ended</span></span> 

![敗退を伝える画面](../../images/arena/arena-ux-lost-game-redirect.png)

## <a name="4-end"></a><span data-ttu-id="042c5-290">4. 終了</span><span class="sxs-lookup"><span data-stu-id="042c5-290">4. End</span></span>

![マッチの終了の図](../../images/arena/arena-ux-flow-end.png)

<span data-ttu-id="042c5-292">トーナメント フローの終了ステージは、トーナメント自体が終了して最終的な結果が報告されたときに発生します。</span><span class="sxs-lookup"><span data-stu-id="042c5-292">The end stage of a tournament flow occurs when the tournament itself has ended and the final results are reported.</span></span>

<span data-ttu-id="042c5-293">参加者には、トーナメントの終了またはプレイヤーの敗退のいずれかが通知されます。</span><span class="sxs-lookup"><span data-stu-id="042c5-293">Participants are informed either that the tournament is over or that the player has been eliminated.</span></span>

### <a name="discovery"></a><span data-ttu-id="042c5-294">情報表示</span><span class="sxs-lookup"><span data-stu-id="042c5-294">Discovery</span></span>

<span data-ttu-id="042c5-295">アリーナ UI では、次のように結果を表示し、優勝者を称えます。</span><span class="sxs-lookup"><span data-stu-id="042c5-295">The Arena UI displays results and celebrates the final winners:</span></span>

* <span data-ttu-id="042c5-296">トーナメントの詳細ページ</span><span class="sxs-lookup"><span data-stu-id="042c5-296">Tournament details page</span></span>
* <span data-ttu-id="042c5-297">プレイヤーまたはクラブのアクティビティ フィードでの参加者による結果の公開</span><span class="sxs-lookup"><span data-stu-id="042c5-297">Results shared by participants in their player or club activity feed</span></span>
* <span data-ttu-id="042c5-298">プレイヤーのプロフィールへのトーナメント結果の投稿</span><span class="sxs-lookup"><span data-stu-id="042c5-298">Tournament results posted to a player’s profile</span></span>

<span data-ttu-id="042c5-299">タイトルでは、ゲーム内に次のようにトーナメント結果を表示できます。</span><span class="sxs-lookup"><span data-stu-id="042c5-299">Your title can surface tournament results in-game:</span></span>

* <span data-ttu-id="042c5-300">参加者が完了した最終ラウンドのゲーム終了エクスペリエンスの後。</span><span class="sxs-lookup"><span data-stu-id="042c5-300">After the end-of-game experience for the final round the participant completed.</span></span>
* <span data-ttu-id="042c5-301">トーナメント閲覧機能の **[My Tournaments]** (マイ トーナメント) の下に表示。</span><span class="sxs-lookup"><span data-stu-id="042c5-301">Listed under **My Tournaments**, in a Tournament Browse feature.</span></span>


###### <a name="ui-example-end-of-tournament-resultstournament-ended"></a><span data-ttu-id="042c5-302">UI の例: トーナメント終了結果 — トーナメント終了</span><span class="sxs-lookup"><span data-stu-id="042c5-302">UI Example: End of Tournament Results—Tournament Ended</span></span>

![トーナメント終了画面](../../images/arena/arena-ux-tournament-completed.png)

* <span data-ttu-id="042c5-304">このステージをサポートする場合、アリーナ UI またはトーナメント主催者アプリに戻るオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="042c5-304">If this stage is supported, provide an option to return to the Arena UI or tournament organizer app.</span></span>
* <span data-ttu-id="042c5-305">イベント名を表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-305">Display the name of the event.</span></span>
* <span data-ttu-id="042c5-306">チームに複数のメンバーが含まれている場合は、チーム名を表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-306">Display the team name, if the team has more than one member.</span></span>
* <span data-ttu-id="042c5-307">可能であれば、イベントでのチームの順位を表示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-307">Display the team’s standing in the event, if available.</span></span> <span data-ttu-id="042c5-308">順位が表示できない場合 (または場合によっては、順位に加えて)、タイトルに、プレイヤーのイベントへの参加が終了したことを明示する必要があります。</span><span class="sxs-lookup"><span data-stu-id="042c5-308">If no standing is available (or optionally, in addition to the standing), your title should indicate that the player’s participation in the event has come to an end.</span></span>
* <span data-ttu-id="042c5-309">タイトルに次の手順を示します (例: [ライブ ストリーミングを視聴]、[別のトーナメントを見つける]、[ゲームに留まる] など)。</span><span class="sxs-lookup"><span data-stu-id="042c5-309">Your title suggests next steps (for example, “Watch live streams,” “Find another tournament,”, “Stay in the game”).</span></span>
* <span data-ttu-id="042c5-310">タイトルは、チームの関与が終了した理由を示します。</span><span class="sxs-lookup"><span data-stu-id="042c5-310">Your title provides a reason why the team’s engagement has ended:</span></span>
  * <span data-ttu-id="042c5-311">[Rejected] (拒否): チームがトーナメントに参加するための条件を満たしませんでした。</span><span class="sxs-lookup"><span data-stu-id="042c5-311">Rejected—The team failed to meet the qualifications for entering the tournament.</span></span>
  * <span data-ttu-id="042c5-312">[Eliminated] (敗退): チームはトーナメント マッチで敗北しました。</span><span class="sxs-lookup"><span data-stu-id="042c5-312">Eliminated—The team has lost the tournament match.</span></span>
  * <span data-ttu-id="042c5-313">[Evicted] (除外): チームは、アクティブなトーナメントから除外されました。</span><span class="sxs-lookup"><span data-stu-id="042c5-313">Evicted—The team has been removed from an active tournament.</span></span>
  * <span data-ttu-id="042c5-314">[Completed] (完了): チームはトーナメントの最終ラウンドを完了しました。</span><span class="sxs-lookup"><span data-stu-id="042c5-314">Completed—The team completed the tournament’s final round.</span></span>
