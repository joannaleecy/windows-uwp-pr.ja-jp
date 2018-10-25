---
title: マルチプレイヤー シナリオ
author: KevinAsgari
description: さまざまなマルチプレイヤー シナリオと、Xbox Live によるこれらのシナリオのサポートについて説明します。
ms.assetid: 470914df-cbb5-4580-b33a-edb353873e32
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: d104a92a7245e008c3ac579a49220db42713675c
ms.sourcegitcommit: 82c3fc0b06ad490c3456ad18180a6b23ecd9c1a7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/24/2018
ms.locfileid: "5469234"
---
# <a name="multiplayer-scenarios"></a><span data-ttu-id="0f2b9-104">マルチプレイヤー シナリオ</span><span class="sxs-lookup"><span data-stu-id="0f2b9-104">Multiplayer scenarios</span></span>
<span data-ttu-id="0f2b9-105">マルチプレイヤー シナリオには多くの種類があります。適切なシナリオを選択することで、プレイヤーのエンゲージメントを高め、ゲームのプレイヤー ベースを拡大することができます。これは、ゲームがアクティブにプレイされる期間をできるだけ長くするために有効です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-105">There are many different types of multiplayer scenarios, and choosing the right scenario can increase player engagement and the player base for your game, which in turn helps extend the active life of your game for as long as possible.</span></span>

<span data-ttu-id="0f2b9-106">大部分がシングル プレイヤー エクスペリエンスであるゲームであっても、ランキング、統計情報、ソーシャル要素のような Xbox Live の競争機能を使用するメリットがあります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-106">Even games that are mostly single player experiences can benefit from competitive Xbox Live features like Leaderboards, Stats or Social elements.</span></span>

<span data-ttu-id="0f2b9-107">以下の一覧では、Xbox Live を使用して実装できる一般的なマルチプレイヤー シナリオについて説明します。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-107">The following list describes some of the more common multiplayer scenarios that you can implement with Xbox Live.</span></span> <span data-ttu-id="0f2b9-108">この一覧は、複雑さ、および実装とテストに必要な作業量の観点から順序付けされています。ゲームでサポートするシナリオの種類を決定するときには、これらの要因を考慮に入れる必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-108">The list is ordered in terms of complexity and amount of work required to implement and test, and you should consider these factors when deciding on type scenarios that you want your game to support.</span></span>

## <a name="comparative-indirect-play"></a><span data-ttu-id="0f2b9-109">比較 (間接) プレイ</span><span class="sxs-lookup"><span data-stu-id="0f2b9-109">Comparative (Indirect) Play</span></span>
<span data-ttu-id="0f2b9-110">このシナリオでは、プレイヤーは、ゲームの同一インスタンス内で直接ゲームプレイをすることなく、間接的に競争します。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-110">In this scenario, players are competing with each other indirectly, without direct gameplay in the same instance of a game.</span></span> <span data-ttu-id="0f2b9-111">これは、シングル プレイヤー エクスペリエンスが中心ではあるものの、多少競争的な側面があり、プレイヤーが自分のプレイを他のプレイヤーと比較するゲームに適しています。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-111">It is well suited for games that are oriented towards a single player experience, but contain some competitive aspects that let players compare how they did to other players.</span></span>

<span data-ttu-id="0f2b9-112">このシナリオに向く機能の例には、以下が含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-112">Example functionality for this scenario includes:</span></span>

* <span data-ttu-id="0f2b9-113">ランキング。ゲーマーは、他のプレイヤーと比較して、カテゴリー最高の "スコア" を達成しようとします。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-113">Leaderboards, where a gamer tries to achieve the best "score" in a category relative to other players.</span></span> <span data-ttu-id="0f2b9-114">これには、フレンドのみと競争するためのソーシャル ランキング システムを含めることができます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-114">This can include a social leaderboard system for competing with friends only.</span></span>
* <span data-ttu-id="0f2b9-115">実績と統計。ゲーマーは自分の進行状況やパフォーマンスをフレンドと比較し、特に難しい実績を達成したときなどは自慢することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-115">Achievements and stats, where a gamer wants to be able to compare his progress/performance against that of his friends, and possibly brag about beating a particularly challenging achievement.</span></span>
* <span data-ttu-id="0f2b9-116">"ゴースト"、つまり "仮想マルチプレイヤー"。ゲーマーは、レーシング ゲームのラップ タイムなど、他のゲーマーが達成した以前のパフォーマンスの記録 (または自分の記録) と競うことができます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-116">"Ghosting" or "virtual multiplayer", where a gamer can compete against a recording of another gamer's (or their own) previous performance, such as a lap in a racing game.</span></span>

<span data-ttu-id="0f2b9-117">この種類のマルチプレイヤーは、以下の Xbox Live サービスを使用して実現できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-117">This type of multiplayer can be achieved by using the following Xbox Live services:</span></span>

* <span data-ttu-id="0f2b9-118">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-118">Presence</span></span>
* <span data-ttu-id="0f2b9-119">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-119">Stats</span></span>
* <span data-ttu-id="0f2b9-120">Social Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-120">Social Manager</span></span>
* <span data-ttu-id="0f2b9-121">実績</span><span class="sxs-lookup"><span data-stu-id="0f2b9-121">Achievements</span></span>
* <span data-ttu-id="0f2b9-122">スコアボード</span><span class="sxs-lookup"><span data-stu-id="0f2b9-122">Leaderboards</span></span>
* <span data-ttu-id="0f2b9-123">接続ストレージ</span><span class="sxs-lookup"><span data-stu-id="0f2b9-123">Connected storage</span></span>

<span data-ttu-id="0f2b9-124">この種類のマルチプレイヤーに、Xbox Live マルチプレイヤー特有のサービスは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-124">This type of multiplayer does not require any of the Xbox Live Multiplayer specific services.</span></span> <span data-ttu-id="0f2b9-125">このシナリオをテストするのに必要なのは、複数の Xbox Live アカウントのみです。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-125">Testing this scenario requires multiple Xbox Live accounts only.</span></span>

## <a name="local-play-living-room-play"></a><span data-ttu-id="0f2b9-126">ローカル プレイ (リビング ルーム プレイ)</span><span class="sxs-lookup"><span data-stu-id="0f2b9-126">Local Play (Living Room Play)</span></span>
<span data-ttu-id="0f2b9-127">この種類のマルチプレイヤーは、単一デバイス上で 2 人以上のプレイヤーがゲームを一緒に (対戦または協力のいずれか) プレイしていることが基本になります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-127">This type of multiplayer is based on two or more players playing a game together (either versus each other, or cooperatively) on a single device.</span></span> <span data-ttu-id="0f2b9-128">タイトルはユーザー全員に対して 1 つの画面を使用する場合も、各プレイヤー用に画面エクスペリエンスを分割する場合もあります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-128">A title may use a single screen for all players or a split screen experience for each player.</span></span> <span data-ttu-id="0f2b9-129">または、ターン (順番) 制のゲームでは、各プレイヤーが自分のターンの間はゲームを制御する "ホット シート" アプローチを使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-129">Alternatively, in turn based games, you may use a "hot seat" approach where each player takes control of the game during their turn.</span></span>

<span data-ttu-id="0f2b9-130">Xbox One 本体では、複数のゲーマーが 1 つの本体にサインインできます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-130">On the Xbox One console multiple gamers can be signed in on a single console.</span></span> <span data-ttu-id="0f2b9-131">各プレイヤーはコントローラーに関連付けられます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-131">Each player is tied to a controller.</span></span> <span data-ttu-id="0f2b9-132">現在、Windows 10 デバイスは 1 つの Xbox Live アカウントのサインインのみをサポートしていますが、Microsoft は将来のアップデートでこれを変更することを検討しています。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-132">Currently, Windows 10 devices only support sign-in of a single Xbox Live account, but Microsoft is investigating changing this in a future update.</span></span>

<span data-ttu-id="0f2b9-133">Xbox Live マルチプレイヤー サービスを使用して、ローカル プレイ専用形式のマルチプレイヤーを設計することも可能ですが、このシナリオは、オンライン エクスペリエンスを包含する、より広範なマルチプレイヤー シナリオのサブセットと考える方が適切な場合があります。これは、マルチプレイヤー シナリオを拡張することで得られるメリットと比較して、必要とされる追加作業が最小限であるためです。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-133">While it is possible to design a local play only style of multiplayer by using Xbox Live Multiplayer services, it may be better to consider this scenario as a subset of a more expansive multiplayer scenario that incorporates online experiences, as the additional investment required is minimal compared to the potential return of expanding the multiplayer scenario.</span></span>

<span data-ttu-id="0f2b9-134">この種類のマルチプレイヤーでは、前のシナリオと同様のサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-134">This type of multiplayer can use similar services as the previous scenario:</span></span>

* <span data-ttu-id="0f2b9-135">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-135">Presence</span></span>
* <span data-ttu-id="0f2b9-136">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-136">Stats</span></span>
* <span data-ttu-id="0f2b9-137">Social Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-137">Social Manager</span></span>
* <span data-ttu-id="0f2b9-138">実績</span><span class="sxs-lookup"><span data-stu-id="0f2b9-138">Achievements</span></span>
* <span data-ttu-id="0f2b9-139">スコアボード</span><span class="sxs-lookup"><span data-stu-id="0f2b9-139">Leaderboards</span></span>
* <span data-ttu-id="0f2b9-140">接続ストレージ</span><span class="sxs-lookup"><span data-stu-id="0f2b9-140">Connected storage</span></span>

<span data-ttu-id="0f2b9-141">このシナリオのテストには、複数の Xbox Live アカウントと、単一デバイス上の複数のコントローラーが必要です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-141">Testing this scenario requires multiple Xbox Live accounts and multiple controllers on a single device.</span></span>

##  <a name="online-play-with-friends"></a><span data-ttu-id="0f2b9-142">フレンドとのオンライン プレイ</span><span class="sxs-lookup"><span data-stu-id="0f2b9-142">Online Play with friends</span></span>
<span data-ttu-id="0f2b9-143">このシナリオは、最も以前からあるオンライン マルチプレイヤー エクスペリエンスです。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-143">This scenario is the most traditional online multiplayer experience.</span></span> <span data-ttu-id="0f2b9-144">このシナリオでは、Xbox Live メンバーは、ゲームをフレンドだけとプレイすることを望み、見知らぬプレイヤーとのプレイは希望しません。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-144">In this scenario, an Xbox Live member wants to play a game with friends only, but does not want to play with strangers.</span></span> <span data-ttu-id="0f2b9-145">フレンドは招待されるか、進行中のゲームに参加します。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-145">Friends are either invited or join an ongoing game as it is in progress.</span></span>

<span data-ttu-id="0f2b9-146">保護者による制限については、多くのマルチプレイヤー タイトルが (後述するように) オンライン マルチプレイヤーをフレンドだけに制限し、このシナリオにフォール バックする機能を備えています。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-146">For parental control a broader multiplayer title (as shown later) should have the ability to limit online multiplayer to friends only and fall back to this scenario.</span></span> <span data-ttu-id="0f2b9-147">見知らぬプレイヤーとのやり取りを制限する保護者による制限は、Xbox Live サービスを通しても適用されます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-147">Parental controls that limit interactions with strangers are also enforced through the Xbox Live service.</span></span>

<span data-ttu-id="0f2b9-148">この種類のマルチプレイヤーは、以下の Xbox Live サービスを使用して実現できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-148">This type of multiplayer can be achieved by using the following Xbox Live services:</span></span>

* <span data-ttu-id="0f2b9-149">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-149">Multiplayer Manager</span></span>
* <span data-ttu-id="0f2b9-150">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-150">Presence</span></span>
* <span data-ttu-id="0f2b9-151">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-151">Stats</span></span>
* <span data-ttu-id="0f2b9-152">Social Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-152">Social Manager</span></span>

<span data-ttu-id="0f2b9-153">このシナリオをテストするのに必要なのは、複数の Xbox Live アカウントと複数のデバイスです。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-153">Testing this scenario requires multiple Xbox Live accounts and multiple devices.</span></span>

## <a name="online-play-through-a-list-of-game-sessions"></a><span data-ttu-id="0f2b9-154">ゲーム セッションのリストを介したオンライン プレイ</span><span class="sxs-lookup"><span data-stu-id="0f2b9-154">Online Play through a list of game sessions</span></span>
<span data-ttu-id="0f2b9-155">このシナリオでは、プレイヤーはゲーム内で参加可能なゲームプレイ セッションのリストを参照し、どのセッションに参加するかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-155">In this scenario, a player can browse a list of joinable gameplay sessions in a game and then select which one to join.</span></span> <span data-ttu-id="0f2b9-156">プレイヤーは、ゲームをローカルでホストすることで、新しいゲーム セッション インスタンスを作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-156">The player also has the ability to create new game session instances by hosting a game locally.</span></span> <span data-ttu-id="0f2b9-157">これらのゲーム インスタンスでは、カスタム設定 (ゲーム モード、レベル、ゲーム ルールなど) を利用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-157">These game instances may allow custom preferences (like game mode, level or game rules).</span></span> <span data-ttu-id="0f2b9-158">タイトルの設計に応じて、ゲーム セッションで、参加のためのパスワードや一定のプレイヤー/スキル レベルを要求するなどの制限をサポートすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-158">Depending on the title design, game sessions may support restrictions like requiring a password to join or certain player/skill levels.</span></span> <span data-ttu-id="0f2b9-159">これらのゲーム セッション インスタンスは、ゲームでセッションの閲覧や参加をどのように実装しているかに応じて、完全に公開することも非公開にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-159">These game session instances can also be fully public or hidden, depending on how your game implements the session browsing and joining.</span></span>

<span data-ttu-id="0f2b9-160">このシナリオでは、プレイヤー自身がゲーム セッションを選択できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-160">This scenario allows players to self-select a game session.</span></span> <span data-ttu-id="0f2b9-161">これによってプレイヤーに選択の自由が与えられますが、セッションで快適なエクスペリエンスが提供されるという保証はありません。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-161">This gives control to the player but there is no guarantee that a session will provide a good experience.</span></span> <span data-ttu-id="0f2b9-162">希望するスキル レベルの、適切なプレイヤーがセッションに追加されるとは限らないためです。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-162">A session may not be filled with the correct player set at an interesting skill level.</span></span> <span data-ttu-id="0f2b9-163">セッション リストが最も効果的なのは、ゲームのアクティブなマルチプレイヤー コミュニティが小さい場合です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-163">A session list is most effective when games have a small active multiplayer community.</span></span>

<span data-ttu-id="0f2b9-164">この種類のマルチプレイヤーでは、前のシナリオと同様のサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-164">This type of multiplayer can use similar services as the previous scenario:</span></span>

* <span data-ttu-id="0f2b9-165">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-165">Multiplayer Manager</span></span>
* [<span data-ttu-id="0f2b9-166">セッション参照</span><span class="sxs-lookup"><span data-stu-id="0f2b9-166">Session Browse</span></span>](session-browse.md)
* <span data-ttu-id="0f2b9-167">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-167">Presence</span></span>
* <span data-ttu-id="0f2b9-168">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-168">Stats</span></span>
* <span data-ttu-id="0f2b9-169">Social Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-169">Social Manager</span></span>

<span data-ttu-id="0f2b9-170">このシナリオのテストでは、正確にテストするために、多数の Xbox Live アカウントとデバイスのセットが必要です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-170">Testing this scenario requires a large set of Xbox Live accounts and devices to test accurately.</span></span> <span data-ttu-id="0f2b9-171">デベロッパーは、セッション リストのプレイヤーの実際の動的状況は、大規模なプレイヤー ベースでのみ正確にテストできることに注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-171">Developers should note that true player dynamics for session lists can only be tested with large player bases.</span></span>

## <a name="online-play-though-looking-for-group"></a><span data-ttu-id="0f2b9-172">グループの検索を介したオンライン プレイ</span><span class="sxs-lookup"><span data-stu-id="0f2b9-172">Online Play though Looking for group</span></span>
<span data-ttu-id="0f2b9-173">このシナリオはセッション リストのシナリオと似ていますが、いくつかの重要な点で、異なっています。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-173">This scenario is similar to the Session List scenario, however it diverges from it in important points.</span></span> <span data-ttu-id="0f2b9-174">タイトル内のゲーム リストの代わりに、プラットフォームから、ゲーム外のゲーム セッションをリストする機能が提供されます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-174">Instead of a game list in the title the platform provides functionality to list game sessions outside the game.</span></span> <span data-ttu-id="0f2b9-175">これらの "Looking For Group" 広告は、ソーシャル エクスペリエンスを強化し、ゲームプレイ、スキル、およびソーシャル関係の制限を含めることを目的としています。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-175">These Looking For Group advertisements are aimed to provide a more social experience and include gameplay, skill, and social relationship restrictions.</span></span> <span data-ttu-id="0f2b9-176">これによりゲームでは、セッション リストでのエクスペリエンスを強化し、セッションの作成者がより詳細な制御を行えるようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-176">This allows a game to provide an improved experience over session lists and also gives the creator of the session more control.</span></span>

<span data-ttu-id="0f2b9-177">"Looking For Group" セッションを作成したプレイヤーは、他のプレイヤーからのグループへの参加要求を承認または拒否できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-177">The player who created the "looking for group" session can approve or deny requests to join their group from other players.</span></span> <span data-ttu-id="0f2b9-178">これによってゲーマーは、プレイスタイルの好みが同じ、他のゲーマーを見つけることができます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-178">This allows gamers to find other gamers that share their playstyle preferences.</span></span>

<span data-ttu-id="0f2b9-179">Xbox Live LFG サービスは 2016 年の新機能で、タイトルで使用可能なプレビュー API が 5 月に提供される予定です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-179">The Xbox Live LFG service is new for 2016, and preview APIs are expected to be available for titles in May.</span></span>

<span data-ttu-id="0f2b9-180">この種類のマルチプレイヤーでは、前のシナリオと同様のサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-180">This type of multiplayer can use similar services as the previous scenario:</span></span>

* <span data-ttu-id="0f2b9-181">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-181">Multiplayer Manager</span></span>
* <span data-ttu-id="0f2b9-182">Xbox グループを検索</span><span class="sxs-lookup"><span data-stu-id="0f2b9-182">Xbox Looking for Group</span></span>
* <span data-ttu-id="0f2b9-183">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-183">Presence</span></span>
* <span data-ttu-id="0f2b9-184">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-184">Stats</span></span>
* <span data-ttu-id="0f2b9-185">Social Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-185">Social Manager</span></span>
* <span data-ttu-id="0f2b9-186">LFG サービス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-186">LFG service</span></span>

<span data-ttu-id="0f2b9-187">このシナリオのテストでは、多数の Xbox Live アカウントとデバイスのセットが必要です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-187">Testing this scenario requires a large set of Xbox Live accounts and devices to test.</span></span>

## <a name="simple-matchmaking"></a><span data-ttu-id="0f2b9-188">単純なマッチメイキング</span><span class="sxs-lookup"><span data-stu-id="0f2b9-188">Simple MatchMaking</span></span>
<span data-ttu-id="0f2b9-189">このシナリオでは、プレイヤー (またはプレイヤーのグループ) が、オンライン ゲームのために他のプレイヤー (プレイヤーの知人である場合もそうでない場合もあります) を探します。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-189">In this scenario, a player (or group of players) is looking for other players (who may or may not be known to the player) for an online game.</span></span> <span data-ttu-id="0f2b9-190">フレンドを選択する代わりに、ゲームが単純なマッチメイキング フローを提供し、プレイヤーはそれを利用して他のプレイヤーとのゲーム セッションに参加できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-190">Instead of selecting friends, the game provides a simple matchmaking flow that allows players to join into game sessions with other players.</span></span> <span data-ttu-id="0f2b9-191">このシナリオのマッチメイキング フローは単純で、プレイヤーは特別なマッチメイキング構成なしで他のプレイヤーを検索して見つけます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-191">The matchmaking flow in this scenario is simple: players search and find other players without any significant matchmaking configuration.</span></span> <span data-ttu-id="0f2b9-192">このシナリオは、オンライン プレイヤーの数が多い場合に最適です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-192">This scenario works best with a larger online audiences.</span></span>

<span data-ttu-id="0f2b9-193">プレイヤーどうしを適切にマッチするために、マッチメイキングでは Xbox Live での評判とブロック リストを考慮に入れることを検討してください。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-193">To match players together appropriately, any matchmaking should try to honor reputation and block lists on Xbox Live.</span></span> <span data-ttu-id="0f2b9-194">Xbox Live SmartMatch サービスは、これらの制限事項を自動的に処理します。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-194">The Xbox Live SmartMatch service handles these restrictions automatically.</span></span> <span data-ttu-id="0f2b9-195">これらの制限を考慮に入れることで、プレイヤーがより安全で優れたエクスペリエンスを得られるようになります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-195">Honoring restrictions like these helps to ensure a safer and better experience for players.</span></span>

<span data-ttu-id="0f2b9-196">マッチメイキングの重要な要素の 1 つに、サービス品質 (QoS) に関するネットワークのチェックがあります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-196">A important part of matchmaking are Quality of Service (QoS) networking checks.</span></span> <span data-ttu-id="0f2b9-197">こうしたチェックにより、2 人のプレイヤー間のネットワーク接続が、良好なゲームプレイ エクスペリエンスを得るのに十分であるかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-197">These checks ensure that the network connectivity between two players is sufficient for a good gameplay experience.</span></span> <span data-ttu-id="0f2b9-198">ネットワーク接続に問題がある場合にマッチメイキングを繰り返して他のプレイヤーを見つけることが可能なため、これはフレンドとのオンライン プレイのシナリオとは異なります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-198">This is different than in the Online Play with friends scenario since it is possible to repeat matchmaking and find other players in case of a bad network connection.</span></span>

<span data-ttu-id="0f2b9-199">この種類のマルチプレイヤーでは、前のシナリオと同様のサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-199">This type of multiplayer can use similar services as the previous scenario:</span></span>

* <span data-ttu-id="0f2b9-200">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-200">Multiplayer Manager</span></span>
* <span data-ttu-id="0f2b9-201">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-201">Presence</span></span>
* <span data-ttu-id="0f2b9-202">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-202">Stats</span></span>
* <span data-ttu-id="0f2b9-203">Social Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-203">Social Manager</span></span>
* <span data-ttu-id="0f2b9-204">SmartMatch マッチメイキング</span><span class="sxs-lookup"><span data-stu-id="0f2b9-204">SmartMatch matchmaking</span></span>

<span data-ttu-id="0f2b9-205">このシナリオのテストでは、正確にテストするために、多数の Xbox Live アカウントとデバイスのセットが必要です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-205">Testing this scenario requires a large set of Xbox Live accounts and devices to test accurately.</span></span> <span data-ttu-id="0f2b9-206">デベロッパーは、セッション リストのプレイヤーの実際の動的状況は、大規模なプレイヤー ベースでのみ正確にテストできることに注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-206">Developers should note that true player dynamics for session lists can only be tested with large player bases.</span></span> <span data-ttu-id="0f2b9-207">ネットワーク状況と SmartMatch のテストを簡素化するためにツールを利用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-207">Tools are available to simplify network condition and SmartMatch testing.</span></span>

## <a name="skill-based-matchmaking"></a><span data-ttu-id="0f2b9-208">スキル ベースのマッチメイキング</span><span class="sxs-lookup"><span data-stu-id="0f2b9-208">Skill-Based Matchmaking</span></span>
<span data-ttu-id="0f2b9-209">スキル ベースのマッチメイキングは、単純なマッチメイキング シナリオを改良したものです。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-209">Skill-based matchmaking is a refinement of simple matchmaking scenario.</span></span> <span data-ttu-id="0f2b9-210">このシナリオでは、マッチメイキング サービスに、スキル、プレイヤー レベル、その他のゲーム固有のプロパティなどの、より高度なルール セットが含まれます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-210">In this scenario the matchmaking service includes more advanced rule sets like skill, player level and other game-specific properties.</span></span> <span data-ttu-id="0f2b9-211">マッチメイキング サービスは、これらのマッチ パラメーターを使用するルールを利用して、プレイヤーのためにより高品質なセッションを見つけます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-211">The matchmaking service uses rules that use these match paramerters to find a more high-quality session for the player.</span></span> <span data-ttu-id="0f2b9-212">ゲームの設計に応じて、マッチ パラメーターはプレイヤーによって直接構成されるか、タイトルによって自動設定されます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-212">Depending on game design match parameters are configured directly by the player or are automatically set by the title.</span></span>

<span data-ttu-id="0f2b9-213">Xbox Live SmartMatch には、スキル ベースのマッチメイキングに使用できるルールのセットが用意されています。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-213">Xbox Live SmartMatch provides a set of rules that can be used for skill-based matchmaking.</span></span> <span data-ttu-id="0f2b9-214">SmartMatch サービスは、TrueSkill と呼ばれる Xbox Live 機能を使用して、プレイヤーの相対スキルを評価します。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-214">The SmartMatch service uses an Xbox Live feature called TrueSkill to help evaluate the relative skill of a player.</span></span>

<span data-ttu-id="0f2b9-215">この種類のマルチプレイヤーでは、前のシナリオと同様のサービスを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-215">This type of multiplayer can use similar services as the previous scenario:</span></span>

* <span data-ttu-id="0f2b9-216">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-216">Multiplayer Manager</span></span>
* <span data-ttu-id="0f2b9-217">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-217">Presence</span></span>
* <span data-ttu-id="0f2b9-218">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-218">Stats</span></span>
* <span data-ttu-id="0f2b9-219">Social Manager</span><span class="sxs-lookup"><span data-stu-id="0f2b9-219">Social Manager</span></span>
* <span data-ttu-id="0f2b9-220">SmartMatch マッチメイキング</span><span class="sxs-lookup"><span data-stu-id="0f2b9-220">SmartMatch matchmaking</span></span>

<span data-ttu-id="0f2b9-221">このシナリオのテストでは、多数の Xbox Live アカウントとデバイスのセットが必要です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-221">Testing this scenario requires a large set of Xbox Live accounts and devices.</span></span> <span data-ttu-id="0f2b9-222">デベロッパーは、セッション リストのプレイヤーの実際の動的状況は、大規模なプレイヤー ベースでのみ正確にテストできることに注意する必要があります。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-222">Developers should note that true player dynamics for session lists can only be tested with large player bases.</span></span> <span data-ttu-id="0f2b9-223">ネットワーク状況、TrueSkill、および SmartMatch のテストを簡素化するためにツールを利用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-223">Tools are available to simplify network condition, TrueSkill and SmartMatch testing.</span></span>

## <a name="tournaments"></a><span data-ttu-id="0f2b9-224">トーナメント</span><span class="sxs-lookup"><span data-stu-id="0f2b9-224">Tournaments</span></span>
<span data-ttu-id="0f2b9-225">トーナメントでは、適切に管理された形式で、スキルを積んだゲーマーが互いに競争することができます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-225">Tournaments allow for skilled gamers to compete with each other in an organized format.</span></span> <span data-ttu-id="0f2b9-226">一般には、トーナメントは独立したサード パーティー組織によって主催され、管理されます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-226">Typically, tournaments are hosted and organized by independent third party organizations.</span></span>

<span data-ttu-id="0f2b9-227">Xbox Live には 2016 年に新機能が追加されていて、タイトルでは承認されたサード パーティーのトーナメント主催者と連携して、Xbox Live マッチメイキングを使用できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-227">Xbox Live has added a new feature in 2016 to allow titles to use Xbox Live matchmaking in conjunction with approved third party tournament organizers.</span></span> <span data-ttu-id="0f2b9-228">この機能により、タイトルではトーナメントをシームレスに Xbox シェル エクスペリエンスと統合でき、プレイヤーが外部の Web サイトで登録を行う必要はありません。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-228">This feature allows titles to seamlessly integrate tournaments with the Xbox shell experience, without requiring players to register on external websites.</span></span>

<span data-ttu-id="0f2b9-229">この種類のマルチプレイヤーは、以下の Xbox Live サービスを使用して実現できます。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-229">This type of multiplayer can be achieved by using Xbox Live services such as:</span></span>

* <span data-ttu-id="0f2b9-230">プレゼンス</span><span class="sxs-lookup"><span data-stu-id="0f2b9-230">Presence</span></span>
* <span data-ttu-id="0f2b9-231">統計情報</span><span class="sxs-lookup"><span data-stu-id="0f2b9-231">Stats</span></span>
* <span data-ttu-id="0f2b9-232">ソーシャル</span><span class="sxs-lookup"><span data-stu-id="0f2b9-232">Social</span></span>
* <span data-ttu-id="0f2b9-233">レピュテーション</span><span class="sxs-lookup"><span data-stu-id="0f2b9-233">Reputation</span></span>
* <span data-ttu-id="0f2b9-234">マルチプレーヤー</span><span class="sxs-lookup"><span data-stu-id="0f2b9-234">Multiplayer</span></span>
* <span data-ttu-id="0f2b9-235">SmartMatch マッチメイキング</span><span class="sxs-lookup"><span data-stu-id="0f2b9-235">SmartMatch matchmaking</span></span>
* <span data-ttu-id="0f2b9-236">トーナメント</span><span class="sxs-lookup"><span data-stu-id="0f2b9-236">Tournaments</span></span>

<span data-ttu-id="0f2b9-237">このシナリオのテストでは、多数の Xbox Live アカウントとデバイスのセットが必要です。</span><span class="sxs-lookup"><span data-stu-id="0f2b9-237">Testing this scenario requires a large set of Xbox Live accounts and devices.</span></span>
