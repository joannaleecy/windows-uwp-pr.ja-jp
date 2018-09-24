---
title: Xbox のトーナメント情報の提供
author: KevinAsgari
description: ゲームのトーナメント情報を提供するための UI の作成方法について説明します。
ms.author: kevinasg
ms.date: 10-10-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アリーナ, トーナメント, UX
ms.localizationpriority: medium
ms.openlocfilehash: 3417304a1033084ef7543b602b80901a38a5b0b1
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4152100"
---
# <a name="discovering-xbox-tournaments"></a><span data-ttu-id="84126-104">Xbox のトーナメント情報の提供</span><span class="sxs-lookup"><span data-stu-id="84126-104">Discovering Xbox tournaments</span></span>

<span data-ttu-id="84126-105">ゲーマーは、Xbox ダッシュボードや PC 上の Xbox アプリで、複数の方法によってトーナメントの参加情報や観戦情報を入手できます。</span><span class="sxs-lookup"><span data-stu-id="84126-105">Gamers have multiple options in the Xbox Dashboard, or the Xbox app on a PC, to learn more about participating in or watching a tournament.</span></span> <span data-ttu-id="84126-106">またタイトル内でトーナメント情報を積極的に収集することもできます。</span><span class="sxs-lookup"><span data-stu-id="84126-106">There are also opportunities to increase tournament discovery from within your title.</span></span>  

<span data-ttu-id="84126-107">ゲーマーがアリーナ対応のトーナメントを探すには、次の方法があります。</span><span class="sxs-lookup"><span data-stu-id="84126-107">A gamer can find Arena-enabled tournaments by:</span></span>

* <span data-ttu-id="84126-108">Xbox ホームから、最近プレイしたゲームのトーナメント ハブを開く。</span><span class="sxs-lookup"><span data-stu-id="84126-108">Opening a recently played game's Tournaments Hub from Xbox Home.</span></span>
* <span data-ttu-id="84126-109">プレイヤーのプロフィールにアクセスして、プレイしたトーナメント、プレイ中のトーナメント、登録済みのトーナメントを確認する。</span><span class="sxs-lookup"><span data-stu-id="84126-109">Visiting a player profile for tournaments played, now playing, or registered for.</span></span>
* <span data-ttu-id="84126-110">所属しているクラブ内で、チームが投稿したグループを検索 (LFG) に応募する。</span><span class="sxs-lookup"><span data-stu-id="84126-110">Responding to a team Looking for Group (LFG) post in a club they belong to.</span></span>
* <span data-ttu-id="84126-111">Mixer アプリ、Web サイト、ゲーム ハブやアリーナのウォッチ ピボットで、トーナメントのストリーミングを視聴する。</span><span class="sxs-lookup"><span data-stu-id="84126-111">Watching a tournament stream in the Mixer app, website, or the Watch pivot in the Game Hub/Arena.</span></span>
* <span data-ttu-id="84126-112">Xbox ダッシュボードでゲーム ハブにアクセスする。</span><span class="sxs-lookup"><span data-stu-id="84126-112">Visiting a Game Hub in the Xbox Dashboard.</span></span>

## <a name="promoting-tournaments-in-game"></a><span data-ttu-id="84126-113">ゲーム内でのトーナメントの宣伝</span><span class="sxs-lookup"><span data-stu-id="84126-113">Promoting tournaments in-game</span></span>

<span data-ttu-id="84126-114">ユーザーがトーナメントを観戦するのは、そのタイトルに関心があるからです。</span><span class="sxs-lookup"><span data-stu-id="84126-114">People watch tournaments because they're interested in the title.</span></span> <span data-ttu-id="84126-115">Xbox Games には、ゲーマーが新しいことに挑戦してゲームプレイ体験を広げたいと考えているタイミングを捉えて、ゲーマーを獲得するしくみが用意されています。</span><span class="sxs-lookup"><span data-stu-id="84126-115">Xbox games have a unique opportunity to catch gamers at that crucial moment when they are looking for new ways to extend their gameplay experience.</span></span>

> [!TIP]
> <span data-ttu-id="84126-116">**推奨される UX:** プレイヤーが決断するタイミングでトーナメントを宣伝します。</span><span class="sxs-lookup"><span data-stu-id="84126-116">**UX recommendation:** Promote tournaments at decision-making moments.</span></span>
>
> <span data-ttu-id="84126-117">プレイヤーがプレイを続行するか終了するかを決断するタイミングで、トーナメントを宣伝してください (ゲームの起動時、メイン メニュー、マッチ終了時など)。</span><span class="sxs-lookup"><span data-stu-id="84126-117">Raise awareness for tournaments at times when gamers need to decide whether to keep playing or exit (for example, at game launch, main menu, multiplayer menu, or end of match).</span></span>

### <a name="1--use-a-dynamic-announcement-feature-example-message-of-the-day"></a><span data-ttu-id="84126-118">1 動的なお知らせ機能の使用 (例: "今日のメッセージ" など)。</span><span class="sxs-lookup"><span data-stu-id="84126-118">1.  Use a dynamic announcement feature (example: Message of the Day)</span></span>

<span data-ttu-id="84126-119">ゲーム UI にお知らせ機能が組み込まれているタイトルでは、通常、即時更新が可能なコンテンツ管理システムが使用されています。</span><span class="sxs-lookup"><span data-stu-id="84126-119">Titles that have built an announcement feature into their game UI typically use a content-management system that allows for instant updates.</span></span> <span data-ttu-id="84126-120">これを利用すれば、コンテンツを更新したり、ダウンロード コンテンツ リリースを発行したりせずに、新しいコンテンツをゲーマーにプッシュできます。</span><span class="sxs-lookup"><span data-stu-id="84126-120">This is useful for pushing new content to gamers without relying on a content update or downloadable content release.</span></span> <span data-ttu-id="84126-121">たとえば、Halo では "今日のメッセージ" 機能を使って、コミュニティのお知らせやヒントを表示しています。</span><span class="sxs-lookup"><span data-stu-id="84126-121">For example, Halo uses a “Message of the Day” feature to surface community announcements and tips.</span></span> <span data-ttu-id="84126-122">この機能は、トーナメントの宣伝に最適です。</span><span class="sxs-lookup"><span data-stu-id="84126-122">Tournament promotion is perfect fit for this scenario.</span></span>

**<span data-ttu-id="84126-123">ユーザーへの影響</span><span class="sxs-lookup"><span data-stu-id="84126-123">User impact</span></span>**

* <span data-ttu-id="84126-124">ゲーマーは、ゲーム セッションを開始する前に、新しい対戦形式でゲームをプレイする機会を案内されます。</span><span class="sxs-lookup"><span data-stu-id="84126-124">Gamers are introduced to a new competitive gaming opportunity before initiating a game session.</span></span>
* <span data-ttu-id="84126-125">宣伝の表示は一時的です (起動時に、他のお知らせと共に表示されます)。</span><span class="sxs-lookup"><span data-stu-id="84126-125">Exposure is intermittent (at launch, combined with other announcements).</span></span>
* <span data-ttu-id="84126-126">ゲーマーが詳細情報を表示するには、ゲームを終了してアリーナ ハブにアクセスする必要があります。</span><span class="sxs-lookup"><span data-stu-id="84126-126">To learn more, gamers will be directed to leave the game and go to the Arena Hub.</span></span>
* <span data-ttu-id="84126-127">この機能では、コンテンツを更新せずに情報を設定できます。</span><span class="sxs-lookup"><span data-stu-id="84126-127">The feature does not require a content update to populate.</span></span>
* <span data-ttu-id="84126-128">宣伝の関連性とタイミングは柔軟性が維持されます。</span><span class="sxs-lookup"><span data-stu-id="84126-128">Relevancy and timing of promotion remains flexible.</span></span>

###### <a name="ui-example-message-of-the-day"></a><span data-ttu-id="84126-129">UI の例: "今日のメッセージ"</span><span class="sxs-lookup"><span data-stu-id="84126-129">UI Example: 'Message of the Day'</span></span>

![トーナメントの今日のメッセージ](../../images/arena/arena-ux-motd.png)

#### <a name="a-main-heading-ex-play-watch-learn"></a><span data-ttu-id="84126-131">A.</span><span class="sxs-lookup"><span data-stu-id="84126-131">A.</span></span> <span data-ttu-id="84126-132">大見出し。たとえば、"Play, Watch, Learn" (プレイしよう。観戦しよう。スキルを磨こう。) など</span><span class="sxs-lookup"><span data-stu-id="84126-132">Main Heading ex: Play, Watch, Learn</span></span>  

<span data-ttu-id="84126-133">ゲーマーにすべてのトーナメントについて告知することも、特定のトーナメントについて告知することもできます。</span><span class="sxs-lookup"><span data-stu-id="84126-133">Informs gamers about all tournaments or a specific one.</span></span>

#### <a name="b-go-to-arena-hub"></a><span data-ttu-id="84126-134">B.</span><span class="sxs-lookup"><span data-stu-id="84126-134">B.</span></span> <span data-ttu-id="84126-135">[Go to Arena Hub] (アリーナ ハブへ移動する)</span><span class="sxs-lookup"><span data-stu-id="84126-135">Go to Arena Hub</span></span>  

<span data-ttu-id="84126-136">ゲーム ハブ/トーナメントへのディープリンク: ゲームに関連するすべてのトーナメントを宣伝する場合にお勧めします。</span><span class="sxs-lookup"><span data-stu-id="84126-136">Deep-link to Game Hub/Tournaments - Recommended when promoting all tournaments related to your game.</span></span>  
<span data-ttu-id="84126-137">–または–</span><span class="sxs-lookup"><span data-stu-id="84126-137">–Or–</span></span>  
<span data-ttu-id="84126-138">ゲーム ハブ/トーナメント/詳細情報へのディープリンク: 特定のトーナメントについて告知する場合にお勧めします。</span><span class="sxs-lookup"><span data-stu-id="84126-138">Deep-link to Game Hub/Tournament/Details - Recommended when announcing a specific tournament.</span></span>

#### <a name="c-game-exit-confirmation"></a><span data-ttu-id="84126-139">C.</span><span class="sxs-lookup"><span data-stu-id="84126-139">C.</span></span> <span data-ttu-id="84126-140">ゲームの終了確認</span><span class="sxs-lookup"><span data-stu-id="84126-140">Game-exit confirmation</span></span>

<span data-ttu-id="84126-141">A と B の画面要素によって、ユーザーはゲームを終了して Xbox ダッシュボードに移動します。</span><span class="sxs-lookup"><span data-stu-id="84126-141">Screen elements A and B lead the user out the game to the Xbox Dashboard.</span></span> <span data-ttu-id="84126-142">タイトルの UI によってこれからの動作を予告したうえで、ゲーマーに確認を求めます。</span><span class="sxs-lookup"><span data-stu-id="84126-142">Set that expectation in your title’s UI before the gamer makes a decision.</span></span>

###### <a name="ui-example-exit-game-confirmation"></a><span data-ttu-id="84126-143">UI の例: ゲームの終了確認</span><span class="sxs-lookup"><span data-stu-id="84126-143">UI Example: Exit game confirmation</span></span>
![トーナメントの情報を表示するためのゲーム終了の確認](../../images/arena/arena-ux-exit-confirm.png)

### <a name="2--promote-tournaments-on-the-main-menu"></a><span data-ttu-id="84126-145">2. メイン メニューでのトーナメントの宣伝</span><span class="sxs-lookup"><span data-stu-id="84126-145">2.  Promote tournaments on the Main Menu</span></span>

<span data-ttu-id="84126-146">この例では、対話型広告を使って開催予定のイベントを告知しています。</span><span class="sxs-lookup"><span data-stu-id="84126-146">In this example, the announcement is an interactive ad for an upcoming event.</span></span> <span data-ttu-id="84126-147">この広告では、ゲーマーの関心を引く十分な情報が提供されています。</span><span class="sxs-lookup"><span data-stu-id="84126-147">It gives enough information to entice the gamer to learn more.</span></span> <span data-ttu-id="84126-148">**[Select]** (選択) を選ぶと、ゲーマーはアリーナ ハブのトーナメントの詳細ページに誘導され、そこでトーナメントに登録できます。</span><span class="sxs-lookup"><span data-stu-id="84126-148">On **Select**, the gamer is led to a tournaments detail page in the Arena Hub, where they can manage their registration.</span></span>

###### <a name="ui-example-a-tournament-ad-displayed-alongside-the-main-menu"></a><span data-ttu-id="84126-149">UI の例: メイン メニューと共に表示されているトーナメントの広告</span><span class="sxs-lookup"><span data-stu-id="84126-149">UI Example: A tournament ad displayed alongside the main menu</span></span>

![](../../images/arena/arena-ux-promo.png)

> [!TIP]
> **<span data-ttu-id="84126-150">推奨される UX</span><span class="sxs-lookup"><span data-stu-id="84126-150">UX recommendation</span></span>**  
> <span data-ttu-id="84126-151">お知らせには、ゲーマーが詳細情報を表示するかどうかを決断するために必要な情報のみを表示します。</span><span class="sxs-lookup"><span data-stu-id="84126-151">The announcement should Include just enough detail to help gamers decide if they want to learn more.</span></span> <span data-ttu-id="84126-152">たとえば、***説明***、***人気***、***タイミング***について記載します。</span><span class="sxs-lookup"><span data-stu-id="84126-152">For example, ***description***, ***popularity***, and ***timing***.</span></span>

## <a name="browsing-tournaments-in-game"></a><span data-ttu-id="84126-153">ゲーム内でのトーナメント情報の閲覧</span><span class="sxs-lookup"><span data-stu-id="84126-153">Browsing tournaments in-game</span></span>

<span data-ttu-id="84126-154">アリーナ API からタイトルに提供されるデータを使って、ゲーム内に閲覧エクスペリエンスを作成できます。</span><span class="sxs-lookup"><span data-stu-id="84126-154">The Arena APIs provide enough data for your title to create a browsing experience inside the game.</span></span> <span data-ttu-id="84126-155">閲覧機能を構築する場合は、Multiplayer セクションに **Tournaments** エントリ ポイントを追加します。</span><span class="sxs-lookup"><span data-stu-id="84126-155">If you intend to build a browsing feature, add a **Tournaments** entry point in the Multiplayer section.</span></span>

> [!TIP]
> **<span data-ttu-id="84126-156">推奨される UX</span><span class="sxs-lookup"><span data-stu-id="84126-156">UX recommendations</span></span>**  
> <span data-ttu-id="84126-157">トーナメントをマルチプレイヤー ゲーム モードで提示します。</span><span class="sxs-lookup"><span data-stu-id="84126-157">Present Tournaments as a Multiplayer game mode.</span></span>  
> <span data-ttu-id="84126-158">Xbox アリーナは新しい機能であるため、階層 1 または階層 2 レベルで表示できる状態を維持してください。</span><span class="sxs-lookup"><span data-stu-id="84126-158">Because Xbox Arena is a new feature, be sure to keep it visible at the Tier 1 or Tier 2 level.</span></span>

###### <a name="ui-example-tournaments-listed-as-an-additional-mode-in-the-multiplayer-section"></a><span data-ttu-id="84126-159">UI の例: [Multiplayer] (マルチプレイヤー) セクションに追加のモードとしてトーナメントを表示</span><span class="sxs-lookup"><span data-stu-id="84126-159">UI Example: Tournaments listed as an additional mode in the Multiplayer section</span></span>

![トーナメント モード](../../images/arena/arena-ux-tournament-mode.png)

### <a name="provide-a-comprehensive-list-of-tournaments"></a><span data-ttu-id="84126-161">すべてのトーナメント一覧の提供</span><span class="sxs-lookup"><span data-stu-id="84126-161">Provide a comprehensive list of tournaments</span></span>

<span data-ttu-id="84126-162">ゲーマーが、現在登録済みのトーナメントの状態を素早く確認し、ゲームプレイのセッションとセッションの間にトーナメント情報を確認できる環境を整えます。</span><span class="sxs-lookup"><span data-stu-id="84126-162">Empower gamers to quickly check the status of tournaments they’re currently registered in, and to browse tournaments between gameplay sessions.</span></span>

#### <a name="user-impact"></a><span data-ttu-id="84126-163">ユーザーへの影響</span><span class="sxs-lookup"><span data-stu-id="84126-163">User impact</span></span>

* <span data-ttu-id="84126-164">ゲーマは、たいていの場合、ゲームを終了してダッシュボードを確認しなくても、トーナメントの状態を把握できるようになります。</span><span class="sxs-lookup"><span data-stu-id="84126-164">Minimizes the gamer’s need to leave the game to check tournament status in the Dashboard.</span></span>
* <span data-ttu-id="84126-165">ゲーマーが Xbox アリーナのトースト通知を見逃した場合の、優れたバックアップ ソリューションとなります。</span><span class="sxs-lookup"><span data-stu-id="84126-165">Serves as a great back-up solution if gamers miss Xbox Arena toast notifications.</span></span>
* <span data-ttu-id="84126-166">ゲーム開発者に、管理すべき追加コストが発生します。</span><span class="sxs-lookup"><span data-stu-id="84126-166">Does involve additional cost for the game developer to manage.</span></span>
* <span data-ttu-id="84126-167">ゲーマーは、参加、登録、チェックイン、シード処理、チーム編成のためのアリーナ UI に誘導されます。</span><span class="sxs-lookup"><span data-stu-id="84126-167">Leads gamers to the Arena UI for joining, registration, checking in, seeding and team formation.</span></span>

> [!NOTE]  
> <span data-ttu-id="84126-168">アリーナ API では、ユーザー作成トーナメント (クラブが作成する) を検索するクエリは提供されていません。</span><span class="sxs-lookup"><span data-stu-id="84126-168">The Arena APIs do not provide a query for user-generated tournaments (club generated).</span></span>


> [!TIP]
> **<span data-ttu-id="84126-169">推奨される UX</span><span class="sxs-lookup"><span data-stu-id="84126-169">UX recommendation</span></span>**  
> <span data-ttu-id="84126-170">UI はサイズ変更できるように作成します。また、一覧に膨大な数のトーナメントが含まれていてもゲーマーが管理できるように、適切な機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="84126-170">Create a UI that can scale, and provide methods for gamers to manage a large list of tournaments.</span></span>

### <a name="filters"></a><span data-ttu-id="84126-171">フィルター</span><span class="sxs-lookup"><span data-stu-id="84126-171">Filters</span></span>

<span data-ttu-id="84126-172">トーナメントをフィルター処理する機能を提供します。フィルター条件には、**[All]** (すべて)、**[Active]** (アクティブ) (終了前のすべてのトーナメントを網羅)、**[Canceled]** (キャンセル済み)、**[Completed]** (完了済み) の各状態を使用できるほか、ゲーマーが既にプレイしたトーナメントやこれらから参加するトーナメントのみを表示 (たとえば、[My Tournaments] (マイ トーナメント)など) することができます。</span><span class="sxs-lookup"><span data-stu-id="84126-172">Filter tournaments by **All**, **Active** (which covers everything until the tournament ends), **Canceled**, and **Completed** states, and tournaments a gamer has or will be participating in (for example, My Tournaments).</span></span>

###### <a name="ui-example"></a><span data-ttu-id="84126-173">UI の例:</span><span class="sxs-lookup"><span data-stu-id="84126-173">UI Example:</span></span>

![トーナメントのフィルター画面](../../images/arena/arena-ux-filters.png)

> [!NOTE]  
> <span data-ttu-id="84126-175">API がサポートしていないカスタム フィルターを追加することもできますが、*お勧めしません*。</span><span class="sxs-lookup"><span data-stu-id="84126-175">Adding custom filters, outside of what the API supports is possible, *but not recommended*.</span></span>

<span data-ttu-id="84126-176">タイトルでは、要求したデータに対して、他のプロパティを使ってフィルター処理することはできますが、それらのプロパティをクエリ パラメーターで指定することはできません。</span><span class="sxs-lookup"><span data-stu-id="84126-176">Your title can filter by other properties after it makes the request, but it can’t specify them on the query parameter.</span></span> <span data-ttu-id="84126-177">そのため、この種の UI で、他のプロパティを使ったフィルター処理は信頼性が確保できません。</span><span class="sxs-lookup"><span data-stu-id="84126-177">This makes filtering by other properties unreliable for this type of UI.</span></span> <span data-ttu-id="84126-178">アリーナ API では、一度に取得するタイトル数を指定することができます。たとえば、タイトルで **maxItems** の値を 10 トーナメントに指定できます。</span><span class="sxs-lookup"><span data-stu-id="84126-178">The Arena APIs retrieve a title-specified number of results at a time—for example, the title may specify a **maxItems** value of 10 tournaments.</span></span> <span data-ttu-id="84126-179">これにより、タイトルのパフォーマンスを管理し、膨大な一覧がユーザーに表示されるリスクを最小限に抑えることができます。</span><span class="sxs-lookup"><span data-stu-id="84126-179">This helps your title manage performance and minimizes the risk of overwhelming the user with a large list.</span></span> <span data-ttu-id="84126-180">ただし、ゲームで提供されるカスタム フィルターは、その時点で検索結果として返された 10 個の項目にしか適用できません。</span><span class="sxs-lookup"><span data-stu-id="84126-180">However, any custom filters provided by your game would apply only to the 10 items requested at that time.</span></span> <span data-ttu-id="84126-181">そのため、API 呼び出しを行うたびに、異なる数のフィルター結果が検出される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="84126-181">This could result in an inconsistent number of filtered results after each API call.</span></span> <span data-ttu-id="84126-182">たとえば、最初の検索では、返された 10 個のトーナメントの中の 2 個がカスタム フィルター ("プレイ中" など) に一致するが、</span><span class="sxs-lookup"><span data-stu-id="84126-182">For example, the first set of 10 tournaments returned might contain 2 that are related to a custom filter, like ‘Playing.’</span></span> <span data-ttu-id="84126-183">次回の検索時には、10 個のうち 9 個が一致するといったことが起こります。</span><span class="sxs-lookup"><span data-stu-id="84126-183">But the next 10 may show 9 such items, and so on.</span></span> <span data-ttu-id="84126-184">タイトルで各カスタム フィルターについて、一致するすべての項目を確実に検出するには、アクティブなすべてのトーナメントを要求した後、それらをまとめてフィルター処理するしかありませんが、この方法はお勧めしません。</span><span class="sxs-lookup"><span data-stu-id="84126-184">The only reliable way for your title to fully populate each custom filter is to request every active tournament and then filter them all, which we don’t recommend.</span></span>

#### <a name="filter-recommendations"></a><span data-ttu-id="84126-185">推奨されるフィルター:</span><span class="sxs-lookup"><span data-stu-id="84126-185">Filter recommendations:</span></span>

##### <a name="all"></a><span data-ttu-id="84126-186">[ALL] (すべて)</span><span class="sxs-lookup"><span data-stu-id="84126-186">ALL</span></span>

<span data-ttu-id="84126-187">**[Active]** (アクティブ)、**[Canceled]** (キャンセル済み)、**[Completed]** (完了済み) のすべてのトーナメントが新しい順に表示されます。</span><span class="sxs-lookup"><span data-stu-id="84126-187">View all **Active**, **Canceled**, and **Completed** tournaments, sorted by most recent.</span></span>

<span data-ttu-id="84126-188">結果:</span><span class="sxs-lookup"><span data-stu-id="84126-188">Results:</span></span>

* <span data-ttu-id="84126-189">トーナメントの状態</span><span class="sxs-lookup"><span data-stu-id="84126-189">Tournament state</span></span>
* <span data-ttu-id="84126-190">トーナメント開始日</span><span class="sxs-lookup"><span data-stu-id="84126-190">Tournament start date</span></span>
* <span data-ttu-id="84126-191">トーナメントのステータス: 登録受け付け中など</span><span class="sxs-lookup"><span data-stu-id="84126-191">Tournament status—for example, Registration open</span></span>
* <span data-ttu-id="84126-192">ダッシュボードのトーナメントの詳細ページへのディープ リンク</span><span class="sxs-lookup"><span data-stu-id="84126-192">Deep link to Tournament Detail Page in the dashboard</span></span>

##### <a name="my-tournaments"></a><span data-ttu-id="84126-193">[MY TOURNAMENTS] (マイ トーナメント)</span><span class="sxs-lookup"><span data-stu-id="84126-193">MY TOURNAMENTS</span></span>

<span data-ttu-id="84126-194">参加者が現在登録されているトーナメントが表示されます。</span><span class="sxs-lookup"><span data-stu-id="84126-194">View tournaments that a participant is currently registered in.</span></span>

<span data-ttu-id="84126-195">結果:</span><span class="sxs-lookup"><span data-stu-id="84126-195">Results:</span></span>

* <span data-ttu-id="84126-196">現在サインインしているユーザーの参加トーナメント</span><span class="sxs-lookup"><span data-stu-id="84126-196">Tournaments that the currently signed-in user is participating in</span></span>
* <span data-ttu-id="84126-197">トーナメントのステータス</span><span class="sxs-lookup"><span data-stu-id="84126-197">Tournament status</span></span>
* <span data-ttu-id="84126-198">トーナメント マッチに移行する方法 (ステータスが "マッチの準備完了" の場合)</span><span class="sxs-lookup"><span data-stu-id="84126-198">A method to enter a tournament match (for ‘match ready’ status)</span></span>
* <span data-ttu-id="84126-199">ダッシュボードのトーナメントの詳細ページへのディープ リンク</span><span class="sxs-lookup"><span data-stu-id="84126-199">Deep link to Tournament Detail Page in the Dashboard</span></span>

##### <a name="active"></a><span data-ttu-id="84126-200">[ACTIVE] (アクティブ)</span><span class="sxs-lookup"><span data-stu-id="84126-200">ACTIVE</span></span>

<span data-ttu-id="84126-201">作成済みのすべてのトーナメント (開催予定、登録受付中、チェックイン、プレイ中のトーナメント) が表示されます。</span><span class="sxs-lookup"><span data-stu-id="84126-201">View all tournaments that have been created: upcoming, open for registration, check-in, and playing.</span></span>

<span data-ttu-id="84126-202">結果:</span><span class="sxs-lookup"><span data-stu-id="84126-202">Results:</span></span>

* <span data-ttu-id="84126-203">現在登録受付中で、現在のユーザーがまだ参加していないトーナメント</span><span class="sxs-lookup"><span data-stu-id="84126-203">Tournaments that are open to register for, that the current user has not already joined</span></span>
* <span data-ttu-id="84126-204">登録終了までの残り時間</span><span class="sxs-lookup"><span data-stu-id="84126-204">Time remaining until registration closes</span></span>

##### <a name="completedcanceled"></a><span data-ttu-id="84126-205">[COMPLETED/CANCELED] (完了済み/キャンセル済み)</span><span class="sxs-lookup"><span data-stu-id="84126-205">COMPLETED/CANCELED</span></span>

<span data-ttu-id="84126-206">最近の結果が表示されます。</span><span class="sxs-lookup"><span data-stu-id="84126-206">View recent results.</span></span> <span data-ttu-id="84126-207">終了直後のトーナメントは、終了後もすぐには削除されず、時間の経過と共に表示順位が下がっていきます。</span><span class="sxs-lookup"><span data-stu-id="84126-207">Tournaments that just ended can age out over time, instead of simply disappearing after they are complete.</span></span>

<span data-ttu-id="84126-208">結果:</span><span class="sxs-lookup"><span data-stu-id="84126-208">Results:</span></span>

* <span data-ttu-id="84126-209">ダッシュボードのトーナメントの詳細ページへのディープ リンク</span><span class="sxs-lookup"><span data-stu-id="84126-209">Deep link to Tournament Detail Page in the Dashboard</span></span>
* <span data-ttu-id="84126-210">トーナメントのステータス</span><span class="sxs-lookup"><span data-stu-id="84126-210">Tournament Status</span></span>
* <span data-ttu-id="84126-211">終了日時</span><span class="sxs-lookup"><span data-stu-id="84126-211">End date/time</span></span>

##### <a name="canceled"></a><span data-ttu-id="84126-212">[CANCELED] (キャンセル済み)</span><span class="sxs-lookup"><span data-stu-id="84126-212">CANCELED</span></span>

<span data-ttu-id="84126-213">キャンセル済みのトーナメントが表示されます。</span><span class="sxs-lookup"><span data-stu-id="84126-213">View tournaments that have been canceled.</span></span>

<span data-ttu-id="84126-214">結果:</span><span class="sxs-lookup"><span data-stu-id="84126-214">Results:</span></span>

* <span data-ttu-id="84126-215">ダッシュボードのトーナメントの詳細ページへのディープ リンク</span><span class="sxs-lookup"><span data-stu-id="84126-215">Deep link to Tournament Detail Page in the Dashboard</span></span>
* <span data-ttu-id="84126-216">キャンセル日時</span><span class="sxs-lookup"><span data-stu-id="84126-216">Date/time of cancellation</span></span>

> [!div class="nextstepaction"]
> [<span data-ttu-id="84126-217">アリーナ UI を使ってトーナメントに参加する</span><span class="sxs-lookup"><span data-stu-id="84126-217">Join a tournament by using the Arena UI</span></span>](arena-ux-join-tournament.md)
