---
title: Xbox アリーナ
author: KevinAsgari
description: Xbox アリーナを使用して、ゲームのトーナメントを実行する方法を説明します。
ms.author: kevinasg
ms.date: 09-20-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アリーナ, トーナメント, UX
ms.localizationpriority: medium
ms.openlocfilehash: 7e4df0894cc2c8ab214e129193a37b68f408194f
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4531027"
---
# <a name="xbox-arena"></a><span data-ttu-id="46cc1-104">Xbox アリーナ</span><span class="sxs-lookup"><span data-stu-id="46cc1-104">Xbox Arena</span></span>

<span data-ttu-id="46cc1-105">Xbox アリーナは、より幅広いユーザーが対戦ゲームを楽しめるように、Xbox One と Windows 10 に対応する Xbox Live 経由のオンライン トーナメントを作成して、実行するためのプラットフォームです。</span><span class="sxs-lookup"><span data-stu-id="46cc1-105">Xbox Arena is a platform for creating and running online tournaments across Xbox One and Windows 10 through Xbox Live, with the goal of bringing the fun of competitive gaming to a broad audience.</span></span>
<span data-ttu-id="46cc1-106">対戦ゲームに関するニーズは、発行元によってすべて異なるため、アリーナにはできる限りの柔軟性を確保しました。</span><span class="sxs-lookup"><span data-stu-id="46cc1-106">Every publisher has different needs when it comes to competitive gaming, and with Arena we want to be as flexible as possible.</span></span> <span data-ttu-id="46cc1-107">アリーナでタイトルのトーナメントを実行する方法には、次の ３ つが用意されています。</span><span class="sxs-lookup"><span data-stu-id="46cc1-107">So there are three different ways to run tournaments for your titles on Arena:</span></span>

* <span data-ttu-id="46cc1-108">フランチャイズ実行型のトーナメントでは、独自のトーナメントをセットアップして実行するためのツールとサービスが Xbox Live によって提供されています。</span><span class="sxs-lookup"><span data-stu-id="46cc1-108">With franchise-run tournaments, Xbox Live provides you with the tools and services to set up and run your own tournaments.</span></span>

* <span data-ttu-id="46cc1-109">Xbox では、業界大手のトーナメント主催者 (TO) と提携しており、これらの TO に委託してタイトルのトーナメントをアリーナ経由で実行できます </span><span class="sxs-lookup"><span data-stu-id="46cc1-109">Xbox has partnered with industry-leading Tournament Organizers (TOs), who you can enable to run tournaments on behalf of your title through Arena.</span></span> <span data-ttu-id="46cc1-110">(サポートされているトーナメント主催者の一覧については、担当の Microsoft アカウント マネージャーにお問い合わせください)。</span><span class="sxs-lookup"><span data-stu-id="46cc1-110">(For a list of supported tournament organizers, contact your Microsoft account manager.)</span></span>

* <span data-ttu-id="46cc1-111">プレイヤーは、ユーザー作成トーナメント (UGT) の機能を使って、独自のアリーナ トーナメントを作成して実行できます。</span><span class="sxs-lookup"><span data-stu-id="46cc1-111">Players can create and run their own Arena tournaments with our user-generated tournaments, or UGTs.</span></span>

<span data-ttu-id="46cc1-112">重要なのは、タイトルにアリーナのサポートを追加すると、これら 3 つの方法をすべて利用できる点です。</span><span class="sxs-lookup"><span data-stu-id="46cc1-112">Most important, adding support for Arena to your titles lets you to take advantage of all three.</span></span> <span data-ttu-id="46cc1-113">マイクロソフトでは、タイトルのゲーム内でトーナメントを宣伝すると共に、参加者がゲームとマッチの間を容易に移動できる信頼性の高い API を提供しています。</span><span class="sxs-lookup"><span data-stu-id="46cc1-113">We provide robust APIs that enable titles to promote tournaments in-game and to facilitate participants’ transition to and from matches.</span></span> <span data-ttu-id="46cc1-114">Xbox アリーナ ハブは、登録、通知、対戦組み合わせとシード処理、結果の報告などのトーナメント管理タスクをサポートします。</span><span class="sxs-lookup"><span data-stu-id="46cc1-114">The Xbox Arena Hub supports tournament-management tasks like registration, notifications, brackets and seeding, and reporting results.</span></span>

> [!IMPORTANT]  
> <span data-ttu-id="46cc1-115">Xbox アリーナの利用は、対象パートナーと ID@Xbox 開発者に限られています。</span><span class="sxs-lookup"><span data-stu-id="46cc1-115">Xbox Arena is only available to managed partners and ID@Xbox developers.</span></span> <span data-ttu-id="46cc1-116">Xbox Live クリエーターズ プログラムでは利用できません。</span><span class="sxs-lookup"><span data-stu-id="46cc1-116">It is not available to the Xbox Live Creators Program.</span></span>

## <a name="a-titles-baseline-tournament-experience"></a><span data-ttu-id="46cc1-117">タイトルの基準トーナメント エクスペリエンス</span><span class="sxs-lookup"><span data-stu-id="46cc1-117">A title's baseline tournament experience</span></span>

<span data-ttu-id="46cc1-118">1 つまたは複数のトーナメント主催者と統合されているタイトルは、基準トーナメント エクスペリエンスを備える必要があります。</span><span class="sxs-lookup"><span data-stu-id="46cc1-118">If your title integrates with one or more tournament organizers, it must provide a baseline tournament experience.</span></span> <span data-ttu-id="46cc1-119">発行元は、タイトルを特定のトーナメント主催者と緊密に統合して、充実した対戦エクスペリエンスを提供することを自由に選択できます。</span><span class="sxs-lookup"><span data-stu-id="46cc1-119">You’re free to integrate more deeply with a specific tournament organizer if you choose, to provide a richer experience for competitions.</span></span> <span data-ttu-id="46cc1-120">しかし、他のトーナメント主催者に対して、また UGT やフランチャイズ実行型トーナメントを実行しようとする場合は、それらに対しても基準エクスペリエンスを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="46cc1-120">But you must still provide the baseline experience for other tournament organizers, and for UGTs and franchise-run tournaments if you choose to run them.</span></span>

### <a name="baseline-requirements-for-a-title"></a><span data-ttu-id="46cc1-121">タイトルの基準要件</span><span class="sxs-lookup"><span data-stu-id="46cc1-121">Baseline requirements for a title</span></span>

* <span data-ttu-id="46cc1-122">すべての要件の一覧については、担当の Microsoft アカウント マネージャーにお問い合わせください。</span><span class="sxs-lookup"><span data-stu-id="46cc1-122">Contact your Microsoft account manager for a full list of requirements.</span></span>

### <a name="ui-recommendations"></a><span data-ttu-id="46cc1-123">UI に関する推奨事項</span><span class="sxs-lookup"><span data-stu-id="46cc1-123">UI recommendations</span></span>

* <span data-ttu-id="46cc1-124">そのマッチがトーナメントであることを UI で明確に示してください。</span><span class="sxs-lookup"><span data-stu-id="46cc1-124">Identify that the match is a tournament in the UI.</span></span>

* <span data-ttu-id="46cc1-125">ロビー UI には、ユーザーを Xbox アリーナ シェル UI またはトーナメント主催者アプリが提供するトーナメント ハブやトーナメントの詳細ページにリンクする UI 要素を含めます。</span><span class="sxs-lookup"><span data-stu-id="46cc1-125">In your Lobby UI, include a UI element that links users to your tournament hub and/or the tournament detail page in the Xbox Arena shell UI or tournament organizer app.</span></span>



<span data-ttu-id="46cc1-126">タイトルの基準ユーザー エクスペリエンスは、数多くの対戦形式に対応できる単純さと柔軟性を備える必要があります。</span><span class="sxs-lookup"><span data-stu-id="46cc1-126">The baseline user experience that your title must provide is simple and flexible enough to work with lots of possible competition formats.</span></span> <span data-ttu-id="46cc1-127">発行元は、タイトルの UI フローに適合し、円滑なユーザー エクスペリエンスを確保できるように、ユーザー エクスペリエンスのガイダンスと要件を自由に変更することができます。</span><span class="sxs-lookup"><span data-stu-id="46cc1-127">You’re free to adapt the user experience guidance and requirements to fit your title’s UI flow and to ensure a smooth user experience.</span></span>

<span data-ttu-id="46cc1-128">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-128">For example:</span></span>

* <span data-ttu-id="46cc1-129">必要な情報は、詳細ページやポップアップなど、何らかの形で提供されていれば、必ずしもメイン画面に表示する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="46cc1-129">The required information doesn’t have to be displayed on the main screen, provided that it’s available somewhere, such as on a detail page or pop-up.</span></span>

* <span data-ttu-id="46cc1-130">各画面はそれぞれ別のバージョンで作成することも、すべてを 1 つの画面にまとめたり、既存のゲーム画面に組み込んだりすることもできます。</span><span class="sxs-lookup"><span data-stu-id="46cc1-130">There may be many versions of each screen, or they may be combined with each other or with existing game screens.</span></span> <span data-ttu-id="46cc1-131">たとえば、多くのゲームでは対戦後に "カーネージ レポート" 画面が表示されますが、これを "結果待ち" 画面と "準備完了" 画面の両方の要件に合わせて変更することができます。</span><span class="sxs-lookup"><span data-stu-id="46cc1-131">For example, many games include a post-match “carnage report” screen, which could be adapted to meet both the “Awaiting Results” and “Ready” screen requirements.</span></span>

* <span data-ttu-id="46cc1-132">ステージが切り替わっても、画面を直ちに切り替える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="46cc1-132">Screens aren’t required to change as soon as the stage does.</span></span> <span data-ttu-id="46cc1-133">たとえば、"準備完了" 画面が表示されているときに、チームのステージが "準備完了" から "プレイ中" に切り替わっても、タイトルを直ちにゲームプレイに切り替える必要はありません。</span><span class="sxs-lookup"><span data-stu-id="46cc1-133">For example, if the team’s stage switches from ”Ready” to ”Playing” while the user is on a “Ready” screen, your title isn’t required to jump immediately into gameplay.</span></span> <span data-ttu-id="46cc1-134">この場合、"マッチ開始待ち" の</span><span class="sxs-lookup"><span data-stu-id="46cc1-134">It can (and probably should) switch the “Waiting for match…”</span></span> <span data-ttu-id="46cc1-135">インジケーターを、たとえば、[プレイ準備完了] というボタンに切り替えることで、ユーザーがフローを制御でき、フローを的確に理解できるようになります (おそらくその方が適切です)。</span><span class="sxs-lookup"><span data-stu-id="46cc1-135">indicator to a button—for example, “Ready to Play”—so that the user is in control of the flow and therefore may have a better understanding of it.</span></span> <span data-ttu-id="46cc1-136">”プレイ中” ステージの要件を満たすのは、ユーザーが切り替えに同意するまで延期できます。</span><span class="sxs-lookup"><span data-stu-id="46cc1-136">It’s okay for the requirements of the “Playing” stage to be postponed until the user acknowledges the transition.</span></span>


## <a name="arena-vs-title-roles"></a><span data-ttu-id="46cc1-137">アリーナとタイトルの "役割"</span><span class="sxs-lookup"><span data-stu-id="46cc1-137">Arena vs. title ‘roles’</span></span>

<span data-ttu-id="46cc1-138">トーナメントのステージが進行すると、ゲームとの間の切り替えがユーザーにとって複雑になることがあります。</span><span class="sxs-lookup"><span data-stu-id="46cc1-138">Moving in and out of the game, as they progress through tournament stages, can get complicated for users.</span></span> <span data-ttu-id="46cc1-139">特にプレイするゲームごとにプロセスが異なる場合、移動先やゲームの動作をすべて記憶するのは困難です。</span><span class="sxs-lookup"><span data-stu-id="46cc1-139">When the process is different for each game they play, there’s even less chance to memorize where to go and what to expect.</span></span>

> [!TIP]
> **<span data-ttu-id="46cc1-140">推奨される UX</span><span class="sxs-lookup"><span data-stu-id="46cc1-140">UX recommendation</span></span>**  
>
> <span data-ttu-id="46cc1-141">ゲームと Xbox アリーナ UI の機能上の役割分担をユーザーが容易に理解できるように、それらを常に明確に区分します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-141">Simplify functional roles between the game and the Xbox Arena UI, by keeping them clearly distinguishable.</span></span> <span data-ttu-id="46cc1-142">たとえば、管理に関連するタスクはすべてアリーナで行い、ゲームのプレイに関連するタスクはすべてゲーム内で行います。</span><span class="sxs-lookup"><span data-stu-id="46cc1-142">For example, all management-related tasks are completed in Arena, and all game play-related tasks are completed inside the game.</span></span>

<span data-ttu-id="46cc1-143">Xbox アリーナの役割 (トーナメントの設定)</span><span class="sxs-lookup"><span data-stu-id="46cc1-143">Xbox Arena role (setting up a tournament)</span></span>   | <span data-ttu-id="46cc1-144">タイトルの役割 (ゲームのプレイ)</span><span class="sxs-lookup"><span data-stu-id="46cc1-144">Title's role (game play)</span></span>
--- | ---
<ul><li><span data-ttu-id="46cc1-145">登録とチェックイン</span><span class="sxs-lookup"><span data-stu-id="46cc1-145">Registration and check-in</span></span></li><li><span data-ttu-id="46cc1-146">通知</span><span class="sxs-lookup"><span data-stu-id="46cc1-146">Notifications</span></span></li><li><span data-ttu-id="46cc1-147">シード処理と対戦組み合わせ</span><span class="sxs-lookup"><span data-stu-id="46cc1-147">Seeding and brackets</span></span></li><li><span data-ttu-id="46cc1-148">チームの編成</span><span class="sxs-lookup"><span data-stu-id="46cc1-148">Team formation</span></span></li></ul> |     <ul><li><span data-ttu-id="46cc1-149">参加者に対するアリーナ UI との間の切り替え</span><span class="sxs-lookup"><span data-stu-id="46cc1-149">Transition of participants to and from the Arena UI</span></span></li><li><span data-ttu-id="46cc1-150">マルチプレイヤー ロビー UI でのトーナメント固有のマッチの特定</span><span class="sxs-lookup"><span data-stu-id="46cc1-150">Identifying tournament-specific matches in multiplayer lobby UI</span></span></li><li><span data-ttu-id="46cc1-151">ゲーム内でのトーナメントの宣伝や閲覧</span><span class="sxs-lookup"><span data-stu-id="46cc1-151">Promotion and/or browsing of tournaments in-game</span></span></li></ul>

## <a name="engineering-guidance"></a><span data-ttu-id="46cc1-152">エンジニアリング ガイダンス</span><span class="sxs-lookup"><span data-stu-id="46cc1-152">Engineering guidance</span></span>

<span data-ttu-id="46cc1-153">記事</span><span class="sxs-lookup"><span data-stu-id="46cc1-153">Article</span></span> | <span data-ttu-id="46cc1-154">説明</span><span class="sxs-lookup"><span data-stu-id="46cc1-154">description</span></span>
--- | ---
[<span data-ttu-id="46cc1-155">アリーナ タイトル統合ガイド</span><span class="sxs-lookup"><span data-stu-id="46cc1-155">Arena title integration</span></span>](arena-title-integration.md) | <span data-ttu-id="46cc1-156">Xbox アリーナのサポートをタイトルに統合する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-156">Learn how to integrate support for Xbox Arena into your title.</span></span>

## <a name="operations-guidance"></a><span data-ttu-id="46cc1-157">操作のガイダンス</span><span class="sxs-lookup"><span data-stu-id="46cc1-157">Operations guidance</span></span>

<span data-ttu-id="46cc1-158">記事</span><span class="sxs-lookup"><span data-stu-id="46cc1-158">Article</span></span> | <span data-ttu-id="46cc1-159">description</span><span class="sxs-lookup"><span data-stu-id="46cc1-159">description</span></span>
--- | ---
[<span data-ttu-id="46cc1-160">Xbox アリーナ操作ポータル</span><span class="sxs-lookup"><span data-stu-id="46cc1-160">Xbox Arena Operations Portal</span></span>](operations-portal.md) | <span data-ttu-id="46cc1-161">操作ポータルを作成し、Xbox アリーナと統合されているタイトルのトーナメントを公式の管理に使用できるについて説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-161">Describes the operations portal that you can use to create and manage official tournaments for a title that is integrated with Xbox Arena.</span></span>

## <a name="user-experience-guidance"></a><span data-ttu-id="46cc1-162">ユーザー エクスペリエンス ガイダンス</span><span class="sxs-lookup"><span data-stu-id="46cc1-162">User experience guidance</span></span>

<span data-ttu-id="46cc1-163">記事</span><span class="sxs-lookup"><span data-stu-id="46cc1-163">Article</span></span> | <span data-ttu-id="46cc1-164">説明</span><span class="sxs-lookup"><span data-stu-id="46cc1-164">description</span></span>
--- | ---
[<span data-ttu-id="46cc1-165">Xbox のトーナメント情報の提供</span><span class="sxs-lookup"><span data-stu-id="46cc1-165">Discovering Xbox tournaments</span></span>](discovering-xbox-tournaments.md) | <span data-ttu-id="46cc1-166">既存のトーナメントの情報を提供するための優れたユーザー エクスペリエンスの作成についてヒントと推奨事項を説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-166">Provides tips and recommendations to craft a great user experience for discovering existing tournaments.</span></span>
[<span data-ttu-id="46cc1-167">トーナメントへの参加</span><span class="sxs-lookup"><span data-stu-id="46cc1-167">Join a tournament</span></span>](arena-ux-join-tournament.md)  |  <span data-ttu-id="46cc1-168">トーナメントに登録して参加するための優れたユーザー エクスペリエンスの作成についてヒントと推奨事項を説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-168">Provides tips and recommendations to craft a great user experience for registering and joining a tournament.</span></span>
[<span data-ttu-id="46cc1-169">マッチの交戦</span><span class="sxs-lookup"><span data-stu-id="46cc1-169">Match engagement</span></span>](arena-ux-match-engagement.md) | <span data-ttu-id="46cc1-170">トーナメントでのプレイヤーの進行に伴うユーザー エクスペリエンスの各ステージについて説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-170">Describes the user experience stages of players progressing through a tournament.</span></span>
[<span data-ttu-id="46cc1-171">アリーナ API の UI メタデータ</span><span class="sxs-lookup"><span data-stu-id="46cc1-171">Arena API UI metadata</span></span>](arena-apis-metadata.md)  | <span data-ttu-id="46cc1-172">アリーナ API によって返されて、トーナメントの現在の状態に関する情報をゲーム内で表示するために使用できるメタデータについて説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-172">Describes the metadata returned by the Arena APIs which you can use to display information in-game about the current state of the tournament.</span></span>
[<span data-ttu-id="46cc1-173">アリーナによる通知</span><span class="sxs-lookup"><span data-stu-id="46cc1-173">Arena notifications</span></span>](arena-notifications.md)  | <span data-ttu-id="46cc1-174">Xbox アリーナが、トーナメント参加者に通知を送信する各条件を説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-174">Describes the conditions when Xbox Arena sends a notification to tournament participants.</span></span>
[<span data-ttu-id="46cc1-175">アリーナのユーザー シナリオ</span><span class="sxs-lookup"><span data-stu-id="46cc1-175">Arena user scenarios</span></span>](arena-user-scenarios.md)  | <span data-ttu-id="46cc1-176">ゲーマーがゲームをプレイする一般的な動機別に、ゲーマーがアリーナを使用するシナリオについて説明します。</span><span class="sxs-lookup"><span data-stu-id="46cc1-176">Describes Arena scenarios for gamers based on their most common motivations.</span></span>
