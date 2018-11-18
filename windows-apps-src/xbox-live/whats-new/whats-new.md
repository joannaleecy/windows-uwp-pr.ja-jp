---
title: Xbox Live の新機能
author: PhillipLucas
description: Xbox Live SDK の新機能
ms.author: aablackm
ms.date: 10/23/2018
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bf536298f075535bf9f5e5198573a87db33dd2a4
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7151016"
---
# <a name="whats-new-for-xbox-live"></a><span data-ttu-id="ebb00-104">Xbox Live の新機能</span><span class="sxs-lookup"><span data-stu-id="ebb00-104">What's new for Xbox Live</span></span>
<span data-ttu-id="ebb00-105">[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="ebb00-105">You can also check the [Xbox Live API GitHub commit history](https://github.com/Microsoft/xbox-live-api/commits/master) to see all of the recent code changes to the Xbox Live APIs.</span></span>

## <a name="in-this-article"></a><span data-ttu-id="ebb00-106">この記事の内容</span><span class="sxs-lookup"><span data-stu-id="ebb00-106">In this article</span></span>

* [<span data-ttu-id="ebb00-107">6 月 2018</span><span class="sxs-lookup"><span data-stu-id="ebb00-107">June 2018</span></span>](#june-2018)
* [<span data-ttu-id="ebb00-108">2017 年 8 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-108">August 2017</span></span>](#august-2017)
* [<span data-ttu-id="ebb00-109">2017 年 7 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-109">July 2017</span></span>](#july-2017)
* [<span data-ttu-id="ebb00-110">2017 年 6 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-110">June 2017</span></span>](#june-2017)
* [<span data-ttu-id="ebb00-111">2017 年 5 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-111">May 2017</span></span>](#may-2017)
* [<span data-ttu-id="ebb00-112">2017 年 4 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-112">April 2017</span></span>](#april-2017)
* [<span data-ttu-id="ebb00-113">2017 年 3 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-113">March 2017</span></span>](#march-2017)
* [<span data-ttu-id="ebb00-114">アーカイブされた記事</span><span class="sxs-lookup"><span data-stu-id="ebb00-114">Archived</span></span>](#archived)

## <a name="june-2018"></a><span data-ttu-id="ebb00-115">6 月 2018</span><span class="sxs-lookup"><span data-stu-id="ebb00-115">June 2018</span></span>

### <a name="xbox-live-features"></a><span data-ttu-id="ebb00-116">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="ebb00-116">Xbox Live Features</span></span>

#### <a name="c-api-layer-for-xsapi"></a><span data-ttu-id="ebb00-117">Xsapi C API レイヤー</span><span class="sxs-lookup"><span data-stu-id="ebb00-117">C API layer for XSAPI</span></span>

<span data-ttu-id="ebb00-118">一部の Xbox Live 機能の C++ Api が利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-118">C APIs are now available for some Xbox Live features.</span></span> <span data-ttu-id="ebb00-119">新しい API レイヤーでは、カスタムのメモリの管理、手動のスレッド管理の非同期タスクは、新しい HTTP ライブラリなど、サポートされている機能の多くのメリットを提供します。</span><span class="sxs-lookup"><span data-stu-id="ebb00-119">The new API layer provides a number of benefits for the supported features, including custom memory management, manual thread management for asynchronous tasks, and a new HTTP library.</span></span>

<span data-ttu-id="ebb00-120">詳細については、 [Xbox Live C Api](../xsapi-flat-c.md)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ebb00-120">For more information, see [Xbox Live C APIs](../xsapi-flat-c.md).</span></span>

## <a name="august-2017"></a><span data-ttu-id="ebb00-121">2017 年 8 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-121">August 2017</span></span>

### <a name="xbox-live-features"></a><span data-ttu-id="ebb00-122">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="ebb00-122">Xbox Live features</span></span>

#### <a name="in-game-clubs"></a><span data-ttu-id="ebb00-123">ゲーム内クラブ</span><span class="sxs-lookup"><span data-stu-id="ebb00-123">In-Game clubs</span></span>

<span data-ttu-id="ebb00-124">開発者は、"ゲーム内クラブ" を作成できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-124">Developers can now create "in-game clubs".</span></span> <span data-ttu-id="ebb00-125">ゲーム内クラブは、開発者が完全にカスタマイズ可能であり、ゲームの内部と外部の両方で使うことができる点で標準の Xbox クラブとは異なります、</span><span class="sxs-lookup"><span data-stu-id="ebb00-125">In-game clubs differ from standard Xbox clubs in that they are fully customizable by a developer and can be used both inside and outside of the game.</span></span> <span data-ttu-id="ebb00-126">ゲーム開発者は、これらを使って、チーム、仲間、スクワッドなど、独自の要件を満たすあらゆる種類の永続グループ シナリオをゲーム内にすばやく構築することができます。</span><span class="sxs-lookup"><span data-stu-id="ebb00-126">As a game developer, you can use them to quickly build any type of persistent group scenarios inside your games such as teams, clans, squads, guilds, etc. that match your unique requirements.</span></span>

<span data-ttu-id="ebb00-127">Xbox Live メンバーは、Xbox コンソール、PC、または iOS/Android デバイスで自由にチャット、フィード、LFG、Mixer などのクラブ機能を使って、どの Xbox エクスペリエンスにおいてもゲームの外部でゲーム内クラブにアクセスして相互につながり、ゲームとの接続を維持できます。</span><span class="sxs-lookup"><span data-stu-id="ebb00-127">Xbox live members can access in-game clubs outside of your game across any Xbox experience to stay connected to each other and to your game by using club features like chat, feed, LFG, and Mixer freely on Xbox console, PC, or iOS/Android devices.</span></span>

<span data-ttu-id="ebb00-128">API を使うと、ゲーム内から直接ゲーム内クラブを作成および管理できます。</span><span class="sxs-lookup"><span data-stu-id="ebb00-128">APIs are available to create & manage in-game clubs directly from within your game.</span></span> <span data-ttu-id="ebb00-129">これらの API は、xbox::services::clubs 名前空間に存在します。</span><span class="sxs-lookup"><span data-stu-id="ebb00-129">These APIs exist in the xbox::services::clubs namespace.</span></span>

## <a name="july-2017"></a><span data-ttu-id="ebb00-130">2017 年 7 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-130">July 2017</span></span>

### <a name="xbox-live-features"></a><span data-ttu-id="ebb00-131">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="ebb00-131">Xbox Live features</span></span>

#### <a name="tournaments"></a><span data-ttu-id="ebb00-132">トーナメント</span><span class="sxs-lookup"><span data-stu-id="ebb00-132">Tournaments</span></span>

<span data-ttu-id="ebb00-133">トーナメントをサポートするための新しい API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-133">New APIs have been added to support tournaments.</span></span> <span data-ttu-id="ebb00-134">xbox::services::tournaments::tournament_service クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-134">You can now use the xbox::services::tournaments::tournament_service class to access the tournaments service from your title.</span></span>
<span data-ttu-id="ebb00-135">これらの新しいトーナメント API では、以下のシナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="ebb00-135">These new tournament APIs enable the following scenarios:</span></span>

* <span data-ttu-id="ebb00-136">サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-136">Query the service to find all existing tournaments for the current title.</span></span>
* <span data-ttu-id="ebb00-137">サービスからトーナメントに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-137">Retrieve details about a tournament from the service.</span></span>
* <span data-ttu-id="ebb00-138">サービスをクエリしてトーナメントのチームの一覧を取得する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-138">Query the service to retrieve a list of teams for a tournament.</span></span>
* <span data-ttu-id="ebb00-139">サービスからトーナメントのチームに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-139">Retrieve details about the teams for a tournament from the service.</span></span>
* <span data-ttu-id="ebb00-140">リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-140">Track changes to tournaments and teams by using Real Time Activity (RTA) subscriptions.</span></span>

## <a name="june-2017"></a><span data-ttu-id="ebb00-141">2017 年 6 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-141">June 2017</span></span>

### <a name="xbox-live-features"></a><span data-ttu-id="ebb00-142">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="ebb00-142">Xbox Live features</span></span>

#### <a name="game-chat-2"></a><span data-ttu-id="ebb00-143">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="ebb00-143">Game Chat 2</span></span>

<span data-ttu-id="ebb00-144">ゲーム チャットの更新および強化されたバージョンを利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-144">An updated and improved version of Game Chat is now available.</span></span> <span data-ttu-id="ebb00-145">詳細については、「[ゲーム チャット 2 の概要](../multiplayer/chat/game-chat-2-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ebb00-145">For more information, see the [Game Chat 2 overview](../multiplayer/chat/game-chat-2-overview.md).</span></span>

### <a name="xbox-live-tools"></a><span data-ttu-id="ebb00-146">Xbox Live ツール</span><span class="sxs-lookup"><span data-stu-id="ebb00-146">Xbox Live tools</span></span>

#### <a name="xbox-live-powershell-module"></a><span data-ttu-id="ebb00-147">Xbox Live PowerShell モジュール</span><span class="sxs-lookup"><span data-stu-id="ebb00-147">Xbox Live PowerShell Module</span></span>

* <span data-ttu-id="ebb00-148">開発用コンピューターでサンドボックスを簡単に切り替えることができるように、PowerShell モジュールが追加されました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-148">PowerShell modules have been added to make it easier to switch sandboxes on your development machine.</span></span> <span data-ttu-id="ebb00-149">詳細については、「[ツール](../tools/tools.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ebb00-149">For more information, see [Tools](../tools/tools.md)</span></span>

#### <a name="bug-fixes"></a><span data-ttu-id="ebb00-150">バグ修正</span><span class="sxs-lookup"><span data-stu-id="ebb00-150">Bug fixes</span></span>

* <span data-ttu-id="ebb00-151">さまざまなバグを修正しました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-151">Various bug fixes.</span></span> <span data-ttu-id="ebb00-152">詳しい一覧については、[GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ebb00-152">Check the [GitHub commit history](https://github.com/Microsoft/xbox-live-api/commits/master) for a full list.</span></span>

## <a name="may-2017"></a><span data-ttu-id="ebb00-153">2017 年 5 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-153">May 2017</span></span>

### <a name="xbox-services-apis"></a><span data-ttu-id="ebb00-154">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="ebb00-154">Xbox Services APIs</span></span>

#### <a name="multiplayer"></a><span data-ttu-id="ebb00-155">マルチプレイヤー</span><span class="sxs-lookup"><span data-stu-id="ebb00-155">Multiplayer</span></span>

* <span data-ttu-id="ebb00-156">検索ハンドルの照会を今すぐには、応答にカスタム セッション プロパティが含まれています。</span><span class="sxs-lookup"><span data-stu-id="ebb00-156">Querying search handles now includes the custom session properties in the response.</span></span>

#### <a name="bug-fixes"></a><span data-ttu-id="ebb00-157">バグ修正</span><span class="sxs-lookup"><span data-stu-id="ebb00-157">Bug fixes</span></span>

* <span data-ttu-id="ebb00-158">有効な HTTP エラー コードではなく "bad json" が返されるバグを修正しました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-158">Fixed "bad json" being returned instead of a valid HTTP error code.</span></span>

## <a name="april-2017"></a><span data-ttu-id="ebb00-159">2017 年 4 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-159">April 2017</span></span>

### <a name="xbox-services-apis"></a><span data-ttu-id="ebb00-160">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="ebb00-160">Xbox Services APIs</span></span>

#### <a name="visual-studio-2017"></a><span data-ttu-id="ebb00-161">Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="ebb00-161">Visual Studio 2017</span></span>

<span data-ttu-id="ebb00-162">Xbox Live API は、ユニバーサル Windows プラットフォーム (UWP) および Xbox One タイトルのために Visual Studio 2017 をサポートするように更新されました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-162">The Xbox Live APIs have been updated to support Visual Studio 2017, for both Universal Windows Platform (UWP) and Xbox One titles.</span></span>

#### <a name="tournaments"></a><span data-ttu-id="ebb00-163">トーナメント</span><span class="sxs-lookup"><span data-stu-id="ebb00-163">Tournaments</span></span>

<span data-ttu-id="ebb00-164">トーナメントをサポートするための新しい API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-164">New APIs have been added to support tournaments.</span></span> <span data-ttu-id="ebb00-165">`xbox::services::tournaments::tournament_service` クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-165">You can now use the `xbox::services::tournaments::tournament_service` class to access the tournaments service from your title.</span></span>

<span data-ttu-id="ebb00-166">これらの新しいトーナメント API では、以下のシナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="ebb00-166">These new tournament APIs enable the following scenarios:</span></span>

* <span data-ttu-id="ebb00-167">サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-167">Query the service to find all existing tournaments for the current title.</span></span>
* <span data-ttu-id="ebb00-168">サービスからトーナメントに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-168">Retrieve details about a tournament from the service.</span></span>
* <span data-ttu-id="ebb00-169">サービスをクエリしてトーナメントのチームの一覧を取得する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-169">Query the service to retrieve a list of teams for a tournament.</span></span>
* <span data-ttu-id="ebb00-170">サービスからトーナメントのチームに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-170">Retrieve details about the teams for a tournament from the service.</span></span>
* <span data-ttu-id="ebb00-171">リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。</span><span class="sxs-lookup"><span data-stu-id="ebb00-171">Track changes to tournaments and teams by using Real Time Activity (RTA) subscriptions.</span></span>

## <a name="march-2017"></a><span data-ttu-id="ebb00-172">2017 年 3 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-172">March 2017</span></span>

### <a name="xbox-services-api"></a><span data-ttu-id="ebb00-173">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="ebb00-173">Xbox Services API</span></span>

#### <a name="data-platform-2017"></a><span data-ttu-id="ebb00-174">データ プラットフォーム 2017</span><span class="sxs-lookup"><span data-stu-id="ebb00-174">Data Platform 2017</span></span>

<span data-ttu-id="ebb00-175">簡略化された統計 API が導入されました。</span><span class="sxs-lookup"><span data-stu-id="ebb00-175">We have introduced a simplified Stats API.</span></span>  <span data-ttu-id="ebb00-176">従来 XDP またはパートナー センターで定義された統計の規則に対応するイベントを送信する必要があるし、これらによってクラウドの統計の値を更新します。</span><span class="sxs-lookup"><span data-stu-id="ebb00-176">Traditionally you had to send events corresponding to stat rules defined on XDP or Partner Center and these would update the stat values in the cloud.</span></span>  <span data-ttu-id="ebb00-177">このモデルを統計 2013 といいます。</span><span class="sxs-lookup"><span data-stu-id="ebb00-177">We refer to this model as Stats 2013.</span></span>

<span data-ttu-id="ebb00-178">統計 2017 では、タイトルが統計値を制御します。</span><span class="sxs-lookup"><span data-stu-id="ebb00-178">With Stats 2017, your title is now in control of your stat values.</span></span>  <span data-ttu-id="ebb00-179">最新の統計値のある API を呼び出すだけで、統計値がイベントを必要とせずに直接サービスに送信されます。</span><span class="sxs-lookup"><span data-stu-id="ebb00-179">You simply call an API with the most recent stat value, and that gets sent to the service directly without the need for events.</span></span>  <span data-ttu-id="ebb00-180">これは、新しい `StatsManager` API を使用するもので、詳細は「[プレイヤー統計](../leaderboards-and-stats-2017/player-stats.md)」に記載されています。</span><span class="sxs-lookup"><span data-stu-id="ebb00-180">This uses the new `StatsManager` API and you can read more in [Player Stats](../leaderboards-and-stats-2017/player-stats.md)</span></span>

#### <a name="github"></a><span data-ttu-id="ebb00-181">GitHub</span><span class="sxs-lookup"><span data-stu-id="ebb00-181">GitHub</span></span>

<span data-ttu-id="ebb00-182">Xbox Live API (XSAPI) は、GitHub ([https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api)) に公開されています。</span><span class="sxs-lookup"><span data-stu-id="ebb00-182">Xbox Live API (XSAPI) is now available on GitHub at [https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api).</span></span>  <span data-ttu-id="ebb00-183">XDK に付属のバイナリまたは NuGet パッケージとしての使用も推奨していますが、ソースを使用したり、ソース コードに貢献していただくことも歓迎します。</span><span class="sxs-lookup"><span data-stu-id="ebb00-183">Using the binaries that come with the XDK or as NuGet packages is still recommended, however you are welcome to use the source and we welcome source code contributions.</span></span>  

### <a name="xbox-live-creators-program"></a><span data-ttu-id="ebb00-184">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="ebb00-184">Xbox Live Creators Program</span></span>

<span data-ttu-id="ebb00-185">Xbox Live クリエーターズ プログラムは、幅広い対象デベロッパーに Xbox Live 機能のサブセットを提供するデベロッパー プログラムです。</span><span class="sxs-lookup"><span data-stu-id="ebb00-185">The Xbox Live Creators Program is a developer program offering a subset of Xbox Live functionality to a broader developer audience.</span></span>  <span data-ttu-id="ebb00-186">既に ID@Xbox プログラムを使用している場合には、これによる影響はありません。</span><span class="sxs-lookup"><span data-stu-id="ebb00-186">If you are already in the ID@Xbox program, this will not have any impact on you.</span></span>

<span data-ttu-id="ebb00-187">プログラムの詳細については、「[開発者プログラムの概要](../developer-program-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="ebb00-187">You can read more about the program in [Developer Program Overview](../developer-program-overview.md).</span></span>

### <a name="documentation"></a><span data-ttu-id="ebb00-188">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="ebb00-188">Documentation</span></span>

<span data-ttu-id="ebb00-189">以下の新しい記事があります。</span><span class="sxs-lookup"><span data-stu-id="ebb00-189">There are the following new articles:</span></span>

| <span data-ttu-id="ebb00-190">記事</span><span class="sxs-lookup"><span data-stu-id="ebb00-190">Article</span></span> | <span data-ttu-id="ebb00-191">説明</span><span class="sxs-lookup"><span data-stu-id="ebb00-191">Description</span></span> |
|---------|-------------|
|[<span data-ttu-id="ebb00-192">Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="ebb00-192">Xbox Live Service Configuration</span></span>](../xbox-live-service-configuration.md) | <span data-ttu-id="ebb00-193">Xbox Live タイトル用のサービス構成の実行に関する最新情報</span><span class="sxs-lookup"><span data-stu-id="ebb00-193">Updated information on doing service configuration for your Xbox Live Title</span></span>
| [<span data-ttu-id="ebb00-194">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="ebb00-194">Configure Xbox Live in Unity</span></span>](../get-started-with-creators/configure-xbox-live-in-unity.md) | <span data-ttu-id="ebb00-195">Xbox Live クリエーターズ プログラムのデベロッパー向けの Unity セットアップに関する新しい情報</span><span class="sxs-lookup"><span data-stu-id="ebb00-195">New information on Unity setup for Xbox Live Creators Program developers</span></span> |
| [<span data-ttu-id="ebb00-196">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="ebb00-196">Xbox Live Sandboxes</span></span>](../xbox-live-sandboxes.md) | <span data-ttu-id="ebb00-197">Xbox Live サンド ボックスとコンテンツの分離の簡易ガイド</span><span class="sxs-lookup"><span data-stu-id="ebb00-197">A simplified guide to Xbox Live sandboxes and content isolation</span></span> |
| [<span data-ttu-id="ebb00-198">Xbox Live テスト アカウント</span><span class="sxs-lookup"><span data-stu-id="ebb00-198">Xbox Live Test Accounts</span></span>](../xbox-live-test-accounts.md) | <span data-ttu-id="ebb00-199">アカウントの機能とパートナー センターでそれらを作成する方法をテストする方法に関する情報</span><span class="sxs-lookup"><span data-stu-id="ebb00-199">Information about how test accounts work, and how to create them on Partner Center</span></span> |

## <a name="archived"></a><span data-ttu-id="ebb00-200">アーカイブされた記事</span><span class="sxs-lookup"><span data-stu-id="ebb00-200">Archived</span></span>

* [<span data-ttu-id="ebb00-201">2016 年 12 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-201">December 2016</span></span>](1612-whats-new.md)
* [<span data-ttu-id="ebb00-202">2016 年 11 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-202">November 2016</span></span>](1611-whats-new.md)
* [<span data-ttu-id="ebb00-203">2016 年 8 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-203">August 2016</span></span>](1608-whats-new.md)
* [<span data-ttu-id="ebb00-204">2016 年 6 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-204">June 2016</span></span>](1606-whats-new.md)
* [<span data-ttu-id="ebb00-205">2016 年 4 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-205">April 2016</span></span>](1603-whats-new.md)
* [<span data-ttu-id="ebb00-206">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-206">March 2016</span></span>](1603-whats-new.md)
* [<span data-ttu-id="ebb00-207">2016 年 2 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-207">February 2016</span></span>](1602-whats-new.md)
* [<span data-ttu-id="ebb00-208">2015 年 10 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-208">October 2015</span></span>](1510-whats-new.md)
* [<span data-ttu-id="ebb00-209">2015 年 9 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-209">September 2015</span></span>](1509-whats-new.md)
* [<span data-ttu-id="ebb00-210">2015 年 8 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-210">August 2015</span></span>](1508-whats-new.md)
* [<span data-ttu-id="ebb00-211">2015 年 6 月</span><span class="sxs-lookup"><span data-stu-id="ebb00-211">June 2015</span></span>](1506-whats-new.md)
