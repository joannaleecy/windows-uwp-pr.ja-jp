---
title: Xbox Live の新機能
author: staceyhaffner
description: Xbox Live SDK の新機能
ms.author: sthaff
ms.date: 10/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: low
ms.openlocfilehash: df7cfaff8eb4f3129b3effc2ba3c7acc1b65c003
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="whats-new-for-xbox-live"></a><span data-ttu-id="e4250-104">Xbox Live の新機能</span><span class="sxs-lookup"><span data-stu-id="e4250-104">What's new for Xbox Live</span></span>
<span data-ttu-id="e4250-105">[Xbox Live API GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページで、Xbox Live API に最近加えられたすべてのコード変更について確認することもできます。</span><span class="sxs-lookup"><span data-stu-id="e4250-105">You can also check the [Xbox Live API GitHub commit history](https://github.com/Microsoft/xbox-live-api/commits/master) to see all of the recent code changes to the Xbox Live APIs.</span></span>

#### <a name="in-this-article"></a><span data-ttu-id="e4250-106">この記事の内容</span><span class="sxs-lookup"><span data-stu-id="e4250-106">In this article</span></span>

* [<span data-ttu-id="e4250-107">2017 年 8 月</span><span class="sxs-lookup"><span data-stu-id="e4250-107">August 2017</span></span>](#august-2017)
* [<span data-ttu-id="e4250-108">2017 年 7 月</span><span class="sxs-lookup"><span data-stu-id="e4250-108">July 2017</span></span>](#july-2017)
* [<span data-ttu-id="e4250-109">2017 年 6 月</span><span class="sxs-lookup"><span data-stu-id="e4250-109">June 2017</span></span>](#june-2017)
* [<span data-ttu-id="e4250-110">2017 年 5 月</span><span class="sxs-lookup"><span data-stu-id="e4250-110">May 2017</span></span>](#may-2017)
* [<span data-ttu-id="e4250-111">2017 年 4 月</span><span class="sxs-lookup"><span data-stu-id="e4250-111">April 2017</span></span>](#april-2017)
* [<span data-ttu-id="e4250-112">2017 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e4250-112">March 2017</span></span>](#march-2017)
* [<span data-ttu-id="e4250-113">アーカイブされた記事</span><span class="sxs-lookup"><span data-stu-id="e4250-113">Archived</span></span>](#archived)

##<a name="august-2017"></a><span data-ttu-id="e4250-114">2017 年 8 月</span><span class="sxs-lookup"><span data-stu-id="e4250-114">August 2017</span></span>

###<a name="xbox-live-features"></a><span data-ttu-id="e4250-115">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="e4250-115">Xbox Live features</span></span>

####<a name="in-game-clubs"></a><span data-ttu-id="e4250-116">ゲーム内クラブ</span><span class="sxs-lookup"><span data-stu-id="e4250-116">In-Game clubs</span></span>

<span data-ttu-id="e4250-117">開発者は、"ゲーム内クラブ" を作成できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e4250-117">Developers can now create "in-game clubs".</span></span> <span data-ttu-id="e4250-118">ゲーム内クラブは、開発者が完全にカスタマイズ可能であり、ゲームの内部と外部の両方で使うことができる点で標準の Xbox クラブとは異なります、</span><span class="sxs-lookup"><span data-stu-id="e4250-118">In-game clubs differ from standard Xbox clubs in that they are fully customizable by a developer and can be used both inside and outside of the game.</span></span> <span data-ttu-id="e4250-119">ゲーム開発者は、これらを使って、チーム、仲間、スクワッドなど、独自の要件を満たすあらゆる種類の永続グループ シナリオをゲーム内にすばやく構築することができます。</span><span class="sxs-lookup"><span data-stu-id="e4250-119">As a game developer, you can use them to quickly build any type of persistent group scenarios inside your games such as teams, clans, squads, guilds, etc. that match your unique requirements.</span></span>

<span data-ttu-id="e4250-120">Xbox Live メンバーは、Xbox コンソール、PC、または iOS/Android デバイスで自由にチャット、フィード、LFG、Mixer などのクラブ機能を使って、どの Xbox エクスペリエンスにおいてもゲームの外部でゲーム内クラブにアクセスして相互につながり、ゲームとの接続を維持できます。</span><span class="sxs-lookup"><span data-stu-id="e4250-120">Xbox live members can access in-game clubs outside of your game across any Xbox experience to stay connected to each other and to your game by using club features like chat, feed, LFG, and Mixer freely on Xbox console, PC, or iOS/Android devices.</span></span>

<span data-ttu-id="e4250-121">API を使うと、ゲーム内から直接ゲーム内クラブを作成および管理できます。</span><span class="sxs-lookup"><span data-stu-id="e4250-121">APIs are available to create & manage in-game clubs directly from within your game.</span></span> <span data-ttu-id="e4250-122">これらの API は、xbox::services::clubs 名前空間に存在します。</span><span class="sxs-lookup"><span data-stu-id="e4250-122">These APIs exist in the xbox::services::clubs namespace.</span></span>


## <a name="july-2017"></a><span data-ttu-id="e4250-123">2017 年 7 月</span><span class="sxs-lookup"><span data-stu-id="e4250-123">July 2017</span></span>

### <a name="xbox-live-features"></a><span data-ttu-id="e4250-124">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="e4250-124">Xbox Live features</span></span>
#### <a name="multiplayer-updates"></a><span data-ttu-id="e4250-125">マルチプレイヤーの更新</span><span class="sxs-lookup"><span data-stu-id="e4250-125">Multiplayer updates</span></span>

<span data-ttu-id="e4250-126">アクティビティ ハンドルと検索ハンドルの照会の応答にカスタム セッション プロパティが含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e4250-126">Querying activity handles and search handles now includes the custom session properties in the response.</span></span>

#### <a name="tournaments"></a><span data-ttu-id="e4250-127">トーナメント</span><span class="sxs-lookup"><span data-stu-id="e4250-127">Tournaments</span></span>

<span data-ttu-id="e4250-128">トーナメントをサポートするための新しい API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="e4250-128">New APIs have been added to support tournaments.</span></span> <span data-ttu-id="e4250-129">xbox::services::tournaments::tournament_service クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e4250-129">You can now use the xbox::services::tournaments::tournament_service class to access the tournaments service from your title.</span></span>
<span data-ttu-id="e4250-130">これらの新しいトーナメント API では、以下のシナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="e4250-130">These new tournament APIs enable the following scenarios:</span></span>
* <span data-ttu-id="e4250-131">サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。</span><span class="sxs-lookup"><span data-stu-id="e4250-131">Query the service to find all existing tournaments for the current title.</span></span>
* <span data-ttu-id="e4250-132">サービスからトーナメントに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="e4250-132">Retrieve details about a tournament from the service.</span></span>
* <span data-ttu-id="e4250-133">サービスをクエリしてトーナメントのチームの一覧を取得する。</span><span class="sxs-lookup"><span data-stu-id="e4250-133">Query the service to retrieve a list of teams for a tournament.</span></span>
* <span data-ttu-id="e4250-134">サービスからトーナメントのチームに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="e4250-134">Retrieve details about the teams for a tournament from the service.</span></span>
* <span data-ttu-id="e4250-135">リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。</span><span class="sxs-lookup"><span data-stu-id="e4250-135">Track changes to tournaments and teams by using Real Time Activity (RTA) subscriptions.</span></span>

## <a name="june-2017"></a><span data-ttu-id="e4250-136">2017 年 6 月</span><span class="sxs-lookup"><span data-stu-id="e4250-136">June 2017</span></span>

### <a name="xbox-live-features"></a><span data-ttu-id="e4250-137">Xbox Live の機能</span><span class="sxs-lookup"><span data-stu-id="e4250-137">Xbox Live features</span></span>

#### <a name="game-chat-2"></a><span data-ttu-id="e4250-138">ゲーム チャット 2</span><span class="sxs-lookup"><span data-stu-id="e4250-138">Game Chat 2</span></span>

<span data-ttu-id="e4250-139">ゲーム チャットの更新および強化されたバージョンを利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e4250-139">An updated and improved version of Game Chat is now available.</span></span> <span data-ttu-id="e4250-140">詳細については、「[ゲーム チャット 2 の概要](../multiplayer/chat/game-chat-2-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e4250-140">For more information, see the [Game Chat 2 overview](../multiplayer/chat/game-chat-2-overview.md).</span></span>

### <a name="xbox-live-tools"></a><span data-ttu-id="e4250-141">Xbox Live ツール</span><span class="sxs-lookup"><span data-stu-id="e4250-141">Xbox Live tools</span></span>

#### <a name="xbox-live-powershell-module"></a><span data-ttu-id="e4250-142">Xbox Live PowerShell モジュール</span><span class="sxs-lookup"><span data-stu-id="e4250-142">Xbox Live PowerShell Module</span></span>

* <span data-ttu-id="e4250-143">開発用コンピューターでサンドボックスを簡単に切り替えることができるように、PowerShell モジュールが追加されました。</span><span class="sxs-lookup"><span data-stu-id="e4250-143">PowerShell modules have been added to make it easier to switch sandboxes on your development machine.</span></span> <span data-ttu-id="e4250-144">詳細については、「[ツール](../tools/tools.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e4250-144">For more information, see [Tools](../tools/tools.md)</span></span>

#### <a name="bug-fixes"></a><span data-ttu-id="e4250-145">バグ修正</span><span class="sxs-lookup"><span data-stu-id="e4250-145">Bug fixes</span></span>

* <span data-ttu-id="e4250-146">さまざまなバグを修正しました。</span><span class="sxs-lookup"><span data-stu-id="e4250-146">Various bug fixes.</span></span> <span data-ttu-id="e4250-147">詳しい一覧については、[GitHub コミット履歴](https://github.com/Microsoft/xbox-live-api/commits/master)に関するページをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="e4250-147">Check the [GitHub commit history](https://github.com/Microsoft/xbox-live-api/commits/master) for a full list.</span></span>

## <a name="may-2017"></a><span data-ttu-id="e4250-148">2017 年 5 月</span><span class="sxs-lookup"><span data-stu-id="e4250-148">May 2017</span></span>

### <a name="xbox-services-apis"></a><span data-ttu-id="e4250-149">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="e4250-149">Xbox Services APIs</span></span>

#### <a name="multiplayer"></a><span data-ttu-id="e4250-150">マルチプレイヤー</span><span class="sxs-lookup"><span data-stu-id="e4250-150">Multiplayer</span></span>

* <span data-ttu-id="e4250-151">アクティビティ ハンドルと検索ハンドルの照会の応答にカスタム セッション プロパティが含まれるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e4250-151">Querying activity handles and search handles now includes the custom session properties in the response.</span></span>

#### <a name="bug-fixes"></a><span data-ttu-id="e4250-152">バグ修正</span><span class="sxs-lookup"><span data-stu-id="e4250-152">Bug fixes</span></span>

* <span data-ttu-id="e4250-153">有効な HTTP エラー コードではなく "bad json" が返されるバグを修正しました。</span><span class="sxs-lookup"><span data-stu-id="e4250-153">Fixed "bad json" being returned instead of a valid HTTP error code.</span></span>

## <a name="april-2017"></a><span data-ttu-id="e4250-154">2017 年 4 月</span><span class="sxs-lookup"><span data-stu-id="e4250-154">April 2017</span></span>

### <a name="xbox-services-apis"></a><span data-ttu-id="e4250-155">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="e4250-155">Xbox Services APIs</span></span>

#### <a name="visual-studio-2017"></a><span data-ttu-id="e4250-156">Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="e4250-156">Visual Studio 2017</span></span>

<span data-ttu-id="e4250-157">Xbox Live API は、ユニバーサル Windows プラットフォーム (UWP) および Xbox One タイトルのために Visual Studio 2017 をサポートするように更新されました。</span><span class="sxs-lookup"><span data-stu-id="e4250-157">The Xbox Live APIs have been updated to support Visual Studio 2017, for both Universal Windows Platform (UWP) and Xbox One titles.</span></span>

#### <a name="tournaments"></a><span data-ttu-id="e4250-158">トーナメント</span><span class="sxs-lookup"><span data-stu-id="e4250-158">Tournaments</span></span>

<span data-ttu-id="e4250-159">トーナメントをサポートするための新しい API が追加されました。</span><span class="sxs-lookup"><span data-stu-id="e4250-159">New APIs have been added to support tournaments.</span></span> <span data-ttu-id="e4250-160">`xbox::services::tournaments::tournament_service` クラスを使って、タイトルからトーナメント サービスにアクセスできるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e4250-160">You can now use the `xbox::services::tournaments::tournament_service` class to access the tournaments service from your title.</span></span>

<span data-ttu-id="e4250-161">これらの新しいトーナメント API では、以下のシナリオが可能になります。</span><span class="sxs-lookup"><span data-stu-id="e4250-161">These new tournament APIs enable the following scenarios:</span></span>

* <span data-ttu-id="e4250-162">サービスをクエリして現在のタイトルの既存トーナメントをすべて検索する。</span><span class="sxs-lookup"><span data-stu-id="e4250-162">Query the service to find all existing tournaments for the current title.</span></span>
* <span data-ttu-id="e4250-163">サービスからトーナメントに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="e4250-163">Retrieve details about a tournament from the service.</span></span>
* <span data-ttu-id="e4250-164">サービスをクエリしてトーナメントのチームの一覧を取得する。</span><span class="sxs-lookup"><span data-stu-id="e4250-164">Query the service to retrieve a list of teams for a tournament.</span></span>
* <span data-ttu-id="e4250-165">サービスからトーナメントのチームに関する詳細を取得する。</span><span class="sxs-lookup"><span data-stu-id="e4250-165">Retrieve details about the teams for a tournament from the service.</span></span>
* <span data-ttu-id="e4250-166">リアルタイム アクティビティ (RTA) サブスクリプションを使用して、トーナメントおよびチームに対する変更を追跡する。</span><span class="sxs-lookup"><span data-stu-id="e4250-166">Track changes to tournaments and teams by using Real Time Activity (RTA) subscriptions.</span></span>

## <a name="march-2017"></a><span data-ttu-id="e4250-167">2017 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e4250-167">March 2017</span></span>

### <a name="xbox-services-api"></a><span data-ttu-id="e4250-168">Xbox サービス API</span><span class="sxs-lookup"><span data-stu-id="e4250-168">Xbox Services API</span></span>

#### <a name="data-platform-2017"></a><span data-ttu-id="e4250-169">データ プラットフォーム 2017</span><span class="sxs-lookup"><span data-stu-id="e4250-169">Data Platform 2017</span></span>

<span data-ttu-id="e4250-170">簡略化された統計 API が導入されました。</span><span class="sxs-lookup"><span data-stu-id="e4250-170">We have introduced a simplified Stats API.</span></span>  <span data-ttu-id="e4250-171">これまでは XDP またはデベロッパー センターで定義された統計の規則に対応したイベントを送信する必要があり、これらによってクラウドの統計値を更新していました。</span><span class="sxs-lookup"><span data-stu-id="e4250-171">Traditionally you had to send events corresponding to stat rules defined on XDP or Dev Center and these would update the stat values in the cloud.</span></span>  <span data-ttu-id="e4250-172">このモデルを統計 2013 といいます。</span><span class="sxs-lookup"><span data-stu-id="e4250-172">We refer to this model as Stats 2013.</span></span>

<span data-ttu-id="e4250-173">統計 2017 では、タイトルが統計値を制御します。</span><span class="sxs-lookup"><span data-stu-id="e4250-173">With Stats 2017, your title is now in control of your stat values.</span></span>  <span data-ttu-id="e4250-174">最新の統計値のある API を呼び出すだけで、統計値がイベントを必要とせずに直接サービスに送信されます。</span><span class="sxs-lookup"><span data-stu-id="e4250-174">You simply call an API with the most recent stat value, and that gets sent to the service directly without the need for events.</span></span>  <span data-ttu-id="e4250-175">これは、新しい `StatsManager` API を使用するもので、詳細は「[プレイヤー統計](../leaderboards-and-stats-2017/player-stats.md)」に記載されています。</span><span class="sxs-lookup"><span data-stu-id="e4250-175">This uses the new `StatsManager` API and you can read more in [Player Stats](../leaderboards-and-stats-2017/player-stats.md)</span></span>

#### <a name="github"></a><span data-ttu-id="e4250-176">GitHub</span><span class="sxs-lookup"><span data-stu-id="e4250-176">GitHub</span></span>

<span data-ttu-id="e4250-177">Xbox Live API (XSAPI) が [https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api) の GitHub で利用できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="e4250-177">Xbox Live API (XSAPI) is now available on GitHub at [https://github.com/Microsoft/xbox-live-api](https://github.com/Microsoft/xbox-live-api).</span></span>  <span data-ttu-id="e4250-178">XDK に付属のバイナリまたは NuGet パッケージとしての使用も推奨していますが、ソースを使用したり、ソース コードに貢献していただくことも歓迎します。</span><span class="sxs-lookup"><span data-stu-id="e4250-178">Using the binaries that come with the XDK or as NuGet packages is still recommended, however you are welcome to use the source and we welcome source code contributions.</span></span>  

### <a name="xbox-live-creators-program"></a><span data-ttu-id="e4250-179">Xbox Live クリエーターズ プログラム</span><span class="sxs-lookup"><span data-stu-id="e4250-179">Xbox Live Creators Program</span></span>

<span data-ttu-id="e4250-180">Xbox Live クリエーターズ プログラムは、幅広い対象デベロッパーに Xbox Live 機能のサブセットを提供するデベロッパー プログラムです。</span><span class="sxs-lookup"><span data-stu-id="e4250-180">The Xbox Live Creators Program is a developer program offering a subset of Xbox Live functionality to a broader developer audience.</span></span>  <span data-ttu-id="e4250-181">既に ID@Xbox プログラムを使用している場合には、これによる影響はありません。</span><span class="sxs-lookup"><span data-stu-id="e4250-181">If you are already in the ID@Xbox program, this will not have any impact on you.</span></span>

<span data-ttu-id="e4250-182">プログラムの詳細については、「[開発者プログラムの概要](../developer-program-overview.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="e4250-182">You can read more about the program in [Developer Program Overview](../developer-program-overview.md).</span></span>

### <a name="documentation"></a><span data-ttu-id="e4250-183">ドキュメント</span><span class="sxs-lookup"><span data-stu-id="e4250-183">Documentation</span></span>

<span data-ttu-id="e4250-184">以下の新しい記事があります。</span><span class="sxs-lookup"><span data-stu-id="e4250-184">There are the following new articles:</span></span>

| <span data-ttu-id="e4250-185">記事</span><span class="sxs-lookup"><span data-stu-id="e4250-185">Article</span></span> | <span data-ttu-id="e4250-186">説明</span><span class="sxs-lookup"><span data-stu-id="e4250-186">Description</span></span> |
|---------|-------------|
|[<span data-ttu-id="e4250-187">Xbox Live サービス構成</span><span class="sxs-lookup"><span data-stu-id="e4250-187">Xbox Live Service Configuration</span></span>](../xbox-live-service-configuration.md) | <span data-ttu-id="e4250-188">Xbox Live タイトル用のサービス構成の実行に関する最新情報</span><span class="sxs-lookup"><span data-stu-id="e4250-188">Updated information on doing service configuration for your Xbox Live Title</span></span>
| [<span data-ttu-id="e4250-189">Unity で Xbox Live を構成する</span><span class="sxs-lookup"><span data-stu-id="e4250-189">Configure Xbox Live in Unity</span></span>](../get-started-with-creators/configure-xbox-live-in-unity.md) | <span data-ttu-id="e4250-190">Xbox Live クリエーターズ プログラムのデベロッパー向けの Unity セットアップに関する新しい情報</span><span class="sxs-lookup"><span data-stu-id="e4250-190">New information on Unity setup for Xbox Live Creators Program developers</span></span> |
| [<span data-ttu-id="e4250-191">Xbox Live のサンドボックス</span><span class="sxs-lookup"><span data-stu-id="e4250-191">Xbox Live Sandboxes</span></span>](../xbox-live-sandboxes.md) | <span data-ttu-id="e4250-192">Xbox Live サンド ボックスとコンテンツの分離の簡易ガイド</span><span class="sxs-lookup"><span data-stu-id="e4250-192">A simplified guide to Xbox Live sandboxes and content isolation</span></span> |
| [<span data-ttu-id="e4250-193">Xbox Live テスト アカウント</span><span class="sxs-lookup"><span data-stu-id="e4250-193">Xbox Live Test Accounts</span></span>](../xbox-live-test-accounts.md) | <span data-ttu-id="e4250-194">テスト アカウントの機能と Windows デベロッパー センターでのそれらの作成方法に関する情報</span><span class="sxs-lookup"><span data-stu-id="e4250-194">Information about how test accounts work, and how to create them on Windows Dev Center</span></span> |

## <a name="archived"></a><span data-ttu-id="e4250-195">アーカイブされた記事</span><span class="sxs-lookup"><span data-stu-id="e4250-195">Archived</span></span>

* [<span data-ttu-id="e4250-196">2016 年 12 月</span><span class="sxs-lookup"><span data-stu-id="e4250-196">December 2016</span></span>](1612-whats-new.md)
* [<span data-ttu-id="e4250-197">2016 年 11 月</span><span class="sxs-lookup"><span data-stu-id="e4250-197">November 2016</span></span>](1611-whats-new.md)
* [<span data-ttu-id="e4250-198">2016 年 8 月</span><span class="sxs-lookup"><span data-stu-id="e4250-198">August 2016</span></span>](1608-whats-new.md)
* [<span data-ttu-id="e4250-199">2016 年 6 月</span><span class="sxs-lookup"><span data-stu-id="e4250-199">June 2016</span></span>](1606-whats-new.md)
* [<span data-ttu-id="e4250-200">2016 年 4 月</span><span class="sxs-lookup"><span data-stu-id="e4250-200">April 2016</span></span>](1603-whats-new.md)
* [<span data-ttu-id="e4250-201">2016 年 3 月</span><span class="sxs-lookup"><span data-stu-id="e4250-201">March 2016</span></span>](1603-whats-new.md)
* [<span data-ttu-id="e4250-202">2016 年 2 月</span><span class="sxs-lookup"><span data-stu-id="e4250-202">February 2016</span></span>](1602-whats-new.md)
* [<span data-ttu-id="e4250-203">2015 年 10 月</span><span class="sxs-lookup"><span data-stu-id="e4250-203">October 2015</span></span>](1510-whats-new.md)
* [<span data-ttu-id="e4250-204">2015 年 9 月</span><span class="sxs-lookup"><span data-stu-id="e4250-204">September 2015</span></span>](1509-whats-new.md)
* [<span data-ttu-id="e4250-205">2015 年 8 月</span><span class="sxs-lookup"><span data-stu-id="e4250-205">August 2015</span></span>](1508-whats-new.md)
* [<span data-ttu-id="e4250-206">2015 年 6 月</span><span class="sxs-lookup"><span data-stu-id="e4250-206">June 2015</span></span>](1506-whats-new.md)

