---
title: "アリーナ タイトル統合ガイド"
author: KevinAsgari
description: "Xbox Live Arena プラットフォームのサポートをタイトルに組み込む方法について説明します。"
ms.assetid: 470914df-cbb5-4580-b33a-edb353873e32
ms.author: kevinasg
ms.date: 09-14-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Arena, トーナメント"
ms.openlocfilehash: 6800795797fdc588fc8619894fb535b68bcfd1f0
ms.sourcegitcommit: 6c2a2646aad7f4e7a09aa8b90d1eee0de79c1254
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/18/2017
---
# <a name="arena-title-integration-guide"></a><span data-ttu-id="76e95-104">アリーナ タイトル統合ガイド</span><span class="sxs-lookup"><span data-stu-id="76e95-104">Arena title integration guide</span></span>

## <a name="introduction"></a><span data-ttu-id="76e95-105">はじめに</span><span class="sxs-lookup"><span data-stu-id="76e95-105">Introduction</span></span>

<span data-ttu-id="76e95-106">Xbox の Arena プラットフォームでは、トーナメント主催者 (TO) が Arena をサポートするタイトルで、トーナメントを作成して運営できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-106">The Arena platform for Xbox allows Tournament Organizers (TOs) to create and operate tournaments for titles that support Arena.</span></span> <span data-ttu-id="76e95-107">Arena は、Xbox Live TO をサポートして、発行元やユーザーによるトーナメントの実行を可能にするだけでなく、Arena と連携するサードパーティの TO もサポートします。</span><span class="sxs-lookup"><span data-stu-id="76e95-107">Arena supports both an Xbox Live TO that enables publisher and user-run tournaments, as well as third-party TOs who integrate with Arena.</span></span> <span data-ttu-id="76e95-108">シングル エリミネーション (勝ち抜きトーナメント) やスイス ドローなど、トーナメントのスタイルは TO が決定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-108">The style of tournament, such as single elimination or Swiss, is determined by the TO.</span></span>

<span data-ttu-id="76e95-109">このトピックでは、タイトル開発者を対象に、タイトルに Arena のサポートを実装する手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="76e95-109">This topic walks you, as a title developer, through how to implement support for Arena in your title.</span></span> <span data-ttu-id="76e95-110">Arena 対応に設定したゲームは、TO が選択した、サポートされている任意のトーナメント形式に従って動作します。</span><span class="sxs-lookup"><span data-stu-id="76e95-110">After a game is Arena enabled, it will work with any supported tournament format selected by the TO.</span></span> <span data-ttu-id="76e95-111">TO はトーナメントの構造に従って、タイトルのマッチを編成します。</span><span class="sxs-lookup"><span data-stu-id="76e95-111">The TO orchestrates matches for your title according to the structure of the tournament.</span></span> <span data-ttu-id="76e95-112">これを受けて Arena 対応のタイトルは、ゲーム内の各マッチに適切なユーザーを配置し、マッチ結果を TO に報告します。</span><span class="sxs-lookup"><span data-stu-id="76e95-112">The Arena-enabled title then places the right users into each match within the game and reports match results back to the TO.</span></span>

## <a name="overview"></a><span data-ttu-id="76e95-113">概要</span><span class="sxs-lookup"><span data-stu-id="76e95-113">Overview</span></span>

<span data-ttu-id="76e95-114">Xbox Arena では、Xbox のマルチプレイヤー ゲーム開発で一般的な概念が使われています。</span><span class="sxs-lookup"><span data-stu-id="76e95-114">Xbox Arena uses concepts familiar to Xbox multiplayer game development.</span></span> <span data-ttu-id="76e95-115">Xbox マルチプレイヤー システムに慣れていない場合は、このガイドを読み進める前に、それに関するドキュメントを確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="76e95-115">If you’re not familiar with the Xbox multiplayer system, we recommend that you review that documentation before continuing.</span></span> <span data-ttu-id="76e95-116">プロセスは、ユーザーがマルチプレイヤー ゲームへの招待を受け入れるプロセスに似ています。</span><span class="sxs-lookup"><span data-stu-id="76e95-116">The process is similar to that of a user accepting an invitation into a multiplayer game.</span></span> <span data-ttu-id="76e95-117">Arena トーナメントでユーザーのマッチの準備ができると、ユーザーに通知するトーストが別ウィンドウで表示されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-117">When it’s time for a user to play a match in an Arena tournament, a toast pops up to inform the user.</span></span> <span data-ttu-id="76e95-118">ユーザーがトーストを承諾すると、タイトルは Arena の標準のプロトコルのアクティブ化イベントを受信します。</span><span class="sxs-lookup"><span data-stu-id="76e95-118">Accepting the toast causes your title to receive a standard Arena protocol activation event.</span></span> <span data-ttu-id="76e95-119">タイトルがまだ実行されていない場合は、この時点で起動されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-119">If your title isn’t already running, it is launched at this time.</span></span>

<span data-ttu-id="76e95-120">トーナメント マッチ自体の調整には、マルチプレイヤー セッション ディレクトリ (MPSD) セッションが使用されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-120">The tournament match itself is coordinated by using a Multiplayer Session Directory (MPSD) session.</span></span> <span data-ttu-id="76e95-121">Arena の場合、このセッションは、タイトルによってではなく、Arena プラットフォームによって作成されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-121">In the case of Arena, the session is created by the Arena platform instead of by your title.</span></span> <span data-ttu-id="76e95-122">セッションの作成には、セッション テンプレートに加え、タイトル発行元が作成した追加のゲーム構成が使われます。</span><span class="sxs-lookup"><span data-stu-id="76e95-122">This is done by using a session template and additional game configuration which have been created by you as the title publisher.</span></span> <span data-ttu-id="76e95-123">トーナメント マッチ参加者は、この時点で既にこのセッションに参加しています。</span><span class="sxs-lookup"><span data-stu-id="76e95-123">The tournament match participants will already have been joined to the session.</span></span> <span data-ttu-id="76e95-124">タイトル発行元は、Arena が結果報告の判定をサポートするために使用するセッション テンプレートを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-124">As the title publisher, you must configure the session template used for Arena to support arbitration for results reporting.</span></span> <span data-ttu-id="76e95-125">このセッションのすべての要件については、このガイドで後ほど説明します。</span><span class="sxs-lookup"><span data-stu-id="76e95-125">The full requirements for the session are included later in this document.</span></span> <span data-ttu-id="76e95-126">タイトルはまた、その他のセッションを必要に応じて自由に作成することもできます。</span><span class="sxs-lookup"><span data-stu-id="76e95-126">Your title is also free to create any additional sessions it needs.</span></span>

<span data-ttu-id="76e95-127">タイトルは、このセッションを使って、マッチを設定し、結果をレポートします。</span><span class="sxs-lookup"><span data-stu-id="76e95-127">Your title uses the session to set up the match and report results.</span></span> <span data-ttu-id="76e95-128">タイトルが Arena に対応するためには、少なくとも、プロトコルのアクティブ化に対応し、MPSD セッションとやり取りするための統合が必要です。</span><span class="sxs-lookup"><span data-stu-id="76e95-128">Responding to protocol activation and interacting with the MPSD session is the minimum level of integration required by Arena titles.</span></span> <span data-ttu-id="76e95-129">トーナメントの参照とトーナメントへの登録は、Xbox Arena UI を通じてサポートされます。</span><span class="sxs-lookup"><span data-stu-id="76e95-129">Browsing and registering for tournaments is supported via the Xbox Arena UI.</span></span> <span data-ttu-id="76e95-130">タイトルは、必要に応じてトーナメント ハブ サービスからトーナメントに関する追加情報を取得して、さらに充実したタイトル内エクスペリエンスを実現できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-130">Optionally, titles can get additional information about the tournament from the Tournaments Hub service, enabling a richer in-title experience.</span></span> <span data-ttu-id="76e95-131">たとえば、タイトルはトーナメント ハブを使用して、チーム名などのコンテキストを表示したり、ユーザーの新しいマッチ セッションを検索したりすることができます。</span><span class="sxs-lookup"><span data-stu-id="76e95-131">For example, by using the Tournaments Hub, your title can display context such as the team names, and discover new match sessions for a user.</span></span> <span data-ttu-id="76e95-132">次の図では、このデータ フローを緑の矢印で示します。このデータ フローについて詳しくは、「[エクスペリエンス要件とベスト プラクティス](#experience-requirements-and-best-practices)」のセクションで説明します。</span><span class="sxs-lookup"><span data-stu-id="76e95-132">This data flow is depicted by the green arrows in the following diagram, and is described in detail in the [Experience requirements and best practices](#experience-requirements-and-best-practices) section.</span></span> <span data-ttu-id="76e95-133">薄い色の矢印は、ユーザーがトーナメント内のマッチ間を移動し、それによって時間と共にチームからセッションへの参照が変化することを示しています。</span><span class="sxs-lookup"><span data-stu-id="76e95-133">The faded arrows indicate that the reference from the team to the session changes over time, as the user moves from match to match within the tournament.</span></span>

![](../../images/arena/tournament-flow.png)


<span data-ttu-id="76e95-134">Arena プロトコルのアクティブ化 URI には、トーナメントや、マッチのセッション、マッチ終了時にタイトルが起動できるディープ リンクに関する情報が含まれています。</span><span class="sxs-lookup"><span data-stu-id="76e95-134">The Arena protocol activation URI contains information about the tournament, the session for the match, and a deep link that your title can invoke when the match is over.</span></span> <span data-ttu-id="76e95-135">ディープ リンクは、ユーザーを Xbox Arena UI に戻すためのリンクです。</span><span class="sxs-lookup"><span data-stu-id="76e95-135">The deep link returns the user to the Xbox Arena UI.</span></span> <span data-ttu-id="76e95-136">これらの URI のコンポーネントについて詳しくは、「[Arena 統合の基本的要件](#basic-requirements-for-arena-integration)」の「[プロトコルのアクティブ化](#protocol-activation)」のセクションをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="76e95-136">These URI components are described in more detail in the [Protocol activation](#protocol-activation) section of [Basic requirements for Arena integration](#basic-requirements-for-arena-integration).</span></span>

## <a name="basic-requirements-for-arena-integration"></a><span data-ttu-id="76e95-137">Arena 統合の基本的要件</span><span class="sxs-lookup"><span data-stu-id="76e95-137">Basic requirements for Arena integration</span></span>

<span data-ttu-id="76e95-138">ここでは、Arena のサポートに必要な最小限の要件を使用してタイトルを統合するための、技術的なガイダンスと詳細情報を示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-138">This section provides technical guidance and details for integrating your title with the minimum requirements for supporting Arena.</span></span> <span data-ttu-id="76e95-139">このスタイルの統合は、次の概略図でオレンジ色の矢印で示されているデータ フローを利用します。</span><span class="sxs-lookup"><span data-stu-id="76e95-139">This style of integration leverages the data flow depicted by the orange arrows in the following overview diagram.</span></span>

![](../../images/arena/arena-data-flow.png)

<span data-ttu-id="76e95-140">タイトルでのプロトコルのアクティブ化は、Xbox Arena UI から実行されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-140">Your title is protocol-activated from the Xbox Arena UI.</span></span> <span data-ttu-id="76e95-141">これは、トースト通知、トーナメントの詳細ページのほか、マッチへのあらゆるエントリ ポイントから発生します。</span><span class="sxs-lookup"><span data-stu-id="76e95-141">This could originate from a toast notification, the details page for the tournament, or any other entry point for the match.</span></span> <span data-ttu-id="76e95-142">ユーザーがマッチに参加するときは、次のステップが実行されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-142">The steps that occur when a user participates in a match are:</span></span>

1.  <span data-ttu-id="76e95-143">Xbox Arena UI によって、タイトルでプロトコルがアクティブ化されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-143">Your title is protocol-activated by the Xbox Arena UI.</span></span>
2.  <span data-ttu-id="76e95-144">タイトルでアクティブ化パラメーターを使って、シングル マッチがプレイされます。</span><span class="sxs-lookup"><span data-stu-id="76e95-144">Your title uses the activation parameters to play a single match.</span></span>
3.  <span data-ttu-id="76e95-145">マッチが終了したら、タイトルが MPSD ゲーム セッションに結果を報告します。</span><span class="sxs-lookup"><span data-stu-id="76e95-145">When the match is over, your title reports the results to the MPSD game session.</span></span>
4.  <span data-ttu-id="76e95-146">タイトルが、ユーザーを Arena UI に戻すオプションを表示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-146">Your title gives the user the option to return to the Arena UI.</span></span>

<span data-ttu-id="76e95-147">以降の各セクションでは、これらの各ステップについて詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="76e95-147">The following sections go through each of these steps in detail.</span></span>

### <a name="1--protocol-activation"></a><span data-ttu-id="76e95-148">1. プロトコルのアクティブ化</span><span class="sxs-lookup"><span data-stu-id="76e95-148">1.  Protocol activation</span></span>

<span data-ttu-id="76e95-149">ユーザーのマッチの準備ができたら、Arena UI によってタイトルでプロトコルがアクティブ化されて処理が開始します。</span><span class="sxs-lookup"><span data-stu-id="76e95-149">The Arena UI kicks things off by protocol-activating your title when a match is ready for the user.</span></span> <span data-ttu-id="76e95-150">プロトコルのアクティブ化には、この時点でタイトルを起動する場合と、既にタイトルが実行されている場合の 2 つの場合があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-150">There are two cases: your title may be launched at this time, or it may already be running.</span></span> <span data-ttu-id="76e95-151">いずれの場合も、ユーザーがマルチプレイヤー ゲームへの招待を受け入れ、それに対応してタイトルがアクティブ化される場合と似た動作が行われます。</span><span class="sxs-lookup"><span data-stu-id="76e95-151">Both cases are similar to what happens when a title is activated in response to a user accepting an invitation to a multiplayer game.</span></span>

#### <a name="if-your-title-is-launched-at-the-time-of-protocol-activation"></a><span data-ttu-id="76e95-152">プロトコルのアクティブ化の時点で、タイトルが起動される場合</span><span class="sxs-lookup"><span data-stu-id="76e95-152">If your title is launched at the time of protocol activation</span></span>

<span data-ttu-id="76e95-153">**Activated** イベントは、タイトルの起動時に初めて発生します。</span><span class="sxs-lookup"><span data-stu-id="76e95-153">The **Activated** event fires for the first time when your title is launched.</span></span> <span data-ttu-id="76e95-154">最初のアクティブ化が Arena のプロトコルのアクティブ化である場合、タイトルは、ユーザーがトーナメントでプレイしようとしたことで起動されています。</span><span class="sxs-lookup"><span data-stu-id="76e95-154">If that initial activation is an Arena protocol activation, your title was launched by a user attempting to play in a tournament.</span></span> <span data-ttu-id="76e95-155">メニューとログイン画面をバイパスして、できるだけ迅速にタイトルでマッチにスキップする必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-155">Have your title skip as quickly as possible to the match, bypassing menu and sign-in screens.</span></span> <span data-ttu-id="76e95-156">また参加ユーザーの Xbox ユーザー ID (XUID) がアクティブ化 URI に提供されるため、ログインが既に完了しています。</span><span class="sxs-lookup"><span data-stu-id="76e95-156">The Xbox User ID (XUID) of the participating user is provided in the activation URI and should already be signed in.</span></span>

#### <a name="if-your-title-is-already-running"></a><span data-ttu-id="76e95-157">タイトルが既に実行されている場合</span><span class="sxs-lookup"><span data-stu-id="76e95-157">If your title is already running</span></span>

<span data-ttu-id="76e95-158">タイトルが既に実行されている場合、Arena のプロトコルのアクティブ化と併せて **Activated** イベントを生成することもできます。</span><span class="sxs-lookup"><span data-stu-id="76e95-158">The **Activated** event can also fire with an Arena protocol activation while your title is already running.</span></span> <span data-ttu-id="76e95-159">**Activation** イベントは、明示的なユーザー操作 (マッチを通知するトーストへの操作、または Xbox Arena UI からマッチへのジャンプ) によってのみトリガーされます。</span><span class="sxs-lookup"><span data-stu-id="76e95-159">The **Activation** event is triggered only by an explicit user action (either acting on a toast that indicates the match, or jumping into the match from the Xbox Arena UI).</span></span> <span data-ttu-id="76e95-160">タイトルが、メニュー画面で待機している場合は、すぐにトーナメント マッチにジャンプする必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-160">If your title has been waiting on a menu screen, have it jump immediately to the tournament match.</span></span> <span data-ttu-id="76e95-161">またゲームプレイ中にタイトルがプロトコルのアクティブ化を受け取った場合は、ユーザーに対し、最も効率的な方法でゲームを退出して、トーナメント マッチに移動するオプションを提供します。</span><span class="sxs-lookup"><span data-stu-id="76e95-161">If your title receives the protocol activation during gameplay, have it give the user the option to leave the game and enter the tournament match in the most expedient way it can.</span></span> <span data-ttu-id="76e95-162">必要に応じて、プレイ中のゲームを保存するオプションをユーザーに提供します。</span><span class="sxs-lookup"><span data-stu-id="76e95-162">Give the user a chance to save their game if necessary.</span></span>

<span data-ttu-id="76e95-163">プロトコルのアクティブ化は、`CoreApplicationView.Activated` イベントを介してタイトルに配信されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-163">Protocol activations are delivered to your title via the `CoreApplicationView.Activated` event.</span></span> <span data-ttu-id="76e95-164">このイベントの `IActivatedEventArgs.Kind` プロパティが `Protocol` に設定されている場合、アクティブ化はプロトコルのアクティブ化であり、引数を`ProtocolActivatedEventArgs` クラスにキャストすることができます。この場合、プロトコルのアクティブ化 URI が `Uri` プロパティを介して提供されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-164">If the `IActivatedEventArgs.Kind` property of the event arguments is set to `Protocol`, the activation is a protocol activation, and the arguments can be cast to the `ProtocolActivatedEventArgs` class, where the protocol-activation URI is available via the `Uri` property.</span></span>

<span data-ttu-id="76e95-165">タイトルで、プロトコルのアクティブ化 URI の XUID を確認します。</span><span class="sxs-lookup"><span data-stu-id="76e95-165">Have your title check the XUID on the protocol activation URI.</span></span> <span data-ttu-id="76e95-166">またそれが現在のプレイヤーと一致しない場合は、タイトルでユーザー コンテキストを切り替える必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-166">If it doesn’t match the current player, your title will also need to switch user contexts.</span></span>

#### <a name="the-protocol-activation-uri"></a><span data-ttu-id="76e95-167">プロトコルのアクティブ化 URI</span><span class="sxs-lookup"><span data-stu-id="76e95-167">The protocol-activation URI</span></span>

<span data-ttu-id="76e95-168">この URI のテンプレートは次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="76e95-168">The template for the URI is:</span></span>

```URI
ms-xbl-multiplayer://tournament?action=joinGame&joinerXuid={memberId}&organizer={organizerId}&tournamentId={tournamentId}&teamId={teamId}&scid={scid}&templateName={templateName}&name={name}&returnUri={returnUri}&returnPfn={returnPfn}
```

<span data-ttu-id="76e95-169">本体で ERA タイトルが実行されている場合、アクティブ化スキームが若干異なります。</span><span class="sxs-lookup"><span data-stu-id="76e95-169">For ERA titles on the console, the activation scheme is slightly different:</span></span>

```
ms-xbl-{titleIdHex}://
```

<span data-ttu-id="76e95-170">これは招待の場合と同じです。</span><span class="sxs-lookup"><span data-stu-id="76e95-170">This is the same as for invitations.</span></span> <span data-ttu-id="76e95-171">このために、タイトル ID は、8 桁の 16 進数文字でなければならず、必要に応じて先頭にゼロが挿入されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-171">For this purpose, the title ID must be eight hexadecimal characters, so it will include leading zeroes if necessary.</span></span>

<span data-ttu-id="76e95-172">まず `Uri.Host` (区切り文字 “://” の直後の名前) が “tournament” であることを確認します。</span><span class="sxs-lookup"><span data-stu-id="76e95-172">First make sure that the `Uri.Host` (the name immediately following the “://” separator) is “tournament”.</span></span> <span data-ttu-id="76e95-173">この部分によって、Arena のプロトコルのアクティブ化が他の機能のアクティブ化 (ゲームへの招待など) から区別されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-173">That’s how Arena’s protocol activations are distinguished from activations of other features, such as game invitations.</span></span>

<span data-ttu-id="76e95-174">クエリ文字列の引数は URL エンコードされ、大文字小文字が区別されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-174">The query-string arguments will be URL encoded and are case insensitive.</span></span> <span data-ttu-id="76e95-175">タイトルは、パラメーターの順序に依存してはなりません。また認識されていないパラメーターを無視する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-175">Your title shouldn’t depend on the order of the parameters, and it should ignore unrecognized parameters.</span></span>


<span data-ttu-id="76e95-176">パラメーター</span><span class="sxs-lookup"><span data-stu-id="76e95-176">Paramater(s)</span></span> | <span data-ttu-id="76e95-177">説明</span><span class="sxs-lookup"><span data-stu-id="76e95-177">Description</span></span>
--- | ---
**<span data-ttu-id="76e95-178">action</span><span class="sxs-lookup"><span data-stu-id="76e95-178">action</span></span>** | <span data-ttu-id="76e95-179">操作は "joinGame" のみがサポートされています。</span><span class="sxs-lookup"><span data-stu-id="76e95-179">The only supported action is “joinGame”.</span></span> <span data-ttu-id="76e95-180">**action** が指定されていないか、別の値が指定されている場合は、アクティブ化を無視します。</span><span class="sxs-lookup"><span data-stu-id="76e95-180">If the **action** is missing or another value is specified for it, ignore the activation.</span></span>
**<span data-ttu-id="76e95-181">joinerXuid</span><span class="sxs-lookup"><span data-stu-id="76e95-181">joinerXuid</span></span>** | <span data-ttu-id="76e95-182">**joinerXuid** は、トーナメント マッチでプレイしようとしているログイン ユーザーの XUID です。</span><span class="sxs-lookup"><span data-stu-id="76e95-182">The **joinerXuid** is the XUID of the signed-in user who is attempting to play in a tournament match.</span></span> <span data-ttu-id="76e95-183">タイトルでは、このユーザーのコンテキストに切り替えられる必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-183">Your title must allow switching to this user’s context.</span></span> <span data-ttu-id="76e95-184">**joinerXuid** がログインしていない場合、タイトルはアカウント ピッカーを表示して、ユーザーにログインを促す必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-184">If the **joinerXuid** is not signed in, your title must prompt the user to do so by bringing up the account picker.</span></span> <span data-ttu-id="76e95-185">XUID は、常に 10 進数で表されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-185">XUIDs are always expressed in decimal.</span></span>
**<span data-ttu-id="76e95-186">organizerId、tournamentId</span><span class="sxs-lookup"><span data-stu-id="76e95-186">organizerId, tournamentId</span></span>** | <span data-ttu-id="76e95-187">**organizerId** と **tournamentId** の組み合わせは、マッチが関連付けられているトーナメントの一意の識別子となります。</span><span class="sxs-lookup"><span data-stu-id="76e95-187">The **organizerId** and **tournamentId**, when combined, form the unique identifier for the tournament that the match is associated with.</span></span> <span data-ttu-id="76e95-188">トーナメントに関する詳細な情報をタイトルに表示する場合は、この識別子を使ってトーナメント ハブから情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-188">Use this identifier to retrieve more detailed information about the tournament from the Tournaments Hub, if you choose to display it in your title.</span></span>
**<span data-ttu-id="76e95-189">teamId</span><span class="sxs-lookup"><span data-stu-id="76e95-189">teamId</span></span>** | <span data-ttu-id="76e95-190">**teamId** は、トーナメントのコンテキストで、(**joinerXuid** パラメーターで指定された) ユーザーの所属チームを示す一意の識別子です。</span><span class="sxs-lookup"><span data-stu-id="76e95-190">The **teamId** is a unique identifier for the team, in the context of the tournament that the user (specified by the **joinerXuid** parameter) is a member of.</span></span> <span data-ttu-id="76e95-191">**organizerId** パラメーターと **tournamentId** パラメーターの組み合わせと同様、必要に応じて、**teamId** を使ってトーナメント ハブからチームに関する情報を取得できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-191">Like the **organizerId** and **tournamentId** parameters, you can use the **teamId** to optionally retrieve information about the team from the Tournaments Hub.</span></span>
**<span data-ttu-id="76e95-192">scid、templateName、name</span><span class="sxs-lookup"><span data-stu-id="76e95-192">scid, templateName, name</span></span>** | <span data-ttu-id="76e95-193">組み合わせて使用して、セッションを識別できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-193">Together, these identify the session.</span></span> <span data-ttu-id="76e95-194">セッションへの MPSD URI パスで指定されているのと同じ 3 つのパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="76e95-194">These are the same three parameters in the MPSD URI path to the session:</span></span></br> </br>`https://sessiondirectory.xboxlive.com/serviceconfigs/{scid}/sessiontemplates/{templateName}/sessions{name}`<span data-ttu-id="76e95-195">.</span><span class="sxs-lookup"><span data-stu-id="76e95-195">.</span></span></br></br><span data-ttu-id="76e95-196">XSAPI では、これらは `multiplayer_session_reference ` コンストラクターを指す 3 つのパラメーターです。</span><span class="sxs-lookup"><span data-stu-id="76e95-196">In XSAPI, they’re the three parameters to the `multiplayer_session_reference `constructor.</span></span>
**<span data-ttu-id="76e95-197">returnUri、returnPfn</span><span class="sxs-lookup"><span data-stu-id="76e95-197">returnUri, returnPfn</span></span>** | <span data-ttu-id="76e95-198">**returnUri** は、ユーザーを Xbox Arena UI に戻すためのプロトコルのアクティブ化 URI です。</span><span class="sxs-lookup"><span data-stu-id="76e95-198">The **returnUri** is a protocol-activation URI to return the user to the Xbox Arena UI.</span></span> <span data-ttu-id="76e95-199">**returnPfn** パラメーターは、指定されていない場合もあります。</span><span class="sxs-lookup"><span data-stu-id="76e95-199">The **returnPfn** parameter may or may not be present.</span></span> <span data-ttu-id="76e95-200">指定されている場合は、**returnUri** を処理するためのアプリの製品ファミリ名 (PFN) です。</span><span class="sxs-lookup"><span data-stu-id="76e95-200">If it is, it’s the Product Family Name (PFN) for the app that’s intended to handle the **returnUri**.</span></span> <span data-ttu-id="76e95-201">これらの値の使用方法を示すサンプル コードについては、「[Xbox Arena UI への復帰](#returning-to-the-xbox-arena-ui)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="76e95-201">For sample code that shows how to use these values, see [Returning to the Xbox Arena UI](#returning-to-the-xbox-arena-ui).</span></span>

### <a name="2--playing-the-match"></a><span data-ttu-id="76e95-202">2. マッチの実行</span><span class="sxs-lookup"><span data-stu-id="76e95-202">2.  Playing the match</span></span>

<span data-ttu-id="76e95-203">トーナメント主催者が MPSD セッションを作成すると、ユーザーはそのセッションの非アクティブなメンバーとして設定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-203">When the MPSD session is created by the Tournament Organizer, the user is set as an inactive member of that session.</span></span> <span data-ttu-id="76e95-204">タイトルでは `multiplayer_session::join()` を使用して、すぐにプレイヤーをアクティブに設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-204">Your title must immediately set the player to active by using `multiplayer_session::join()`.</span></span> <span data-ttu-id="76e95-205">これにより、Xbox Live および他のユーザーに対して、対象のユーザーがタイトル内に存在し、プレイの準備ができていることが示されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-205">This indicates to Xbox Live and the other users in the match that the user is in your title and ready to play.</span></span>

<span data-ttu-id="76e95-206">マッチの開始時刻は、セッション内の `/servers/arbitration/constants/system/startTime` で、標準 UTC 形式の日付と時刻の値を使って指定されます (たとえば、"2009-06-15T13:45:30.0900000Z")。</span><span class="sxs-lookup"><span data-stu-id="76e95-206">The start time for the match is in the session at `/servers/arbitration/constants/system/startTime` as a date-time value in the standard UTC format (for example, “2009-06-15T13:45:30.0900000Z”).</span></span> <span data-ttu-id="76e95-207">1703 XDK 以降の XSAPI では、開始時刻が `multiplayer_session_arbitration_server::arbitration_start_time()` で指定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-207">(Start time is also available in XSAPI as `multiplayer_session_arbitration_server::arbitration_start_time()`, starting in the 1703 XDK).</span></span> <span data-ttu-id="76e95-208">TO は、開始時刻前にいつでも (または開示時刻と同時に) セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-208">The TO can create the session as far in advance of the start time as it wants (including concurrently with the start time).</span></span> <span data-ttu-id="76e95-209">マッチ通知は開始時刻にマッチ参加者に送信されるため、タイトルが開始時刻より前にアクティブ化されることはありません。</span><span class="sxs-lookup"><span data-stu-id="76e95-209">Match notifications are sent to the match participants at the start time, so titles never get activated before the start time.</span></span> <span data-ttu-id="76e95-210">またマッチの結果報告は、開始時刻になって初めて MPSD によって許可されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-210">The start time is also the earliest time at which MPSD will allow results to be reported for the match.</span></span>

<span data-ttu-id="76e95-211">タイトルは、各メンバーの `/member/{index}/constants/system/team` プロパティ (`multiplayer_session_member::team_id()`) を確認して、各ユーザーが所属するチームを判断します。</span><span class="sxs-lookup"><span data-stu-id="76e95-211">Your title looks at each member’s `/member/{index}/constants/system/team` property (`multiplayer_session_member::team_id()`) to figure out which team each user is on.</span></span>

<span data-ttu-id="76e95-212">タイトルはまたセッションを使用して、マップやモードなどのマッチの設定を把握します。</span><span class="sxs-lookup"><span data-stu-id="76e95-212">Your title also uses the session to determine the match settings, such as map and mode.</span></span> <span data-ttu-id="76e95-213">これらのタイトル固有の設定は、セッション テンプレートで設定するか、トーナメント定義の中でカスタムの定数として設定できます </span><span class="sxs-lookup"><span data-stu-id="76e95-213">These title-specific settings can be set in the session template or as part of the tournament definition as custom constants.</span></span> <span data-ttu-id="76e95-214">(詳しくは、「[Arena 向けのタイトルの構成手順](#configuring-a-title-for-arena)」をご覧ください)。次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-214">(For more information, see [Configuring a title for Arena](#configuring-a-title-for-arena).) Here’s an example:</span></span>

```json
{
    "constants": {
        "custom": {
            "enableCheats": false,
            "bestOf": 3,
            "map": "winter-fall",
            "mode": "capture-the-throne"
        }
    }
}
```

<span data-ttu-id="76e95-215">これらの設定は、`multiplayer_session_constants::session_custom_constants_json()` API を使って、セッションから JavaScript Object Notation (JSON) オブジェクトとして取得できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-215">You can retrieve these settings from the session as a JavaScript Object Notation (JSON) object by using the `multiplayer_session_constants::session_custom_constants_json()` API.</span></span>

<span data-ttu-id="76e95-216">一般に、タイトルは、それ自体の MPSD セッションと同じ方法で Arena セッションを処理します。</span><span class="sxs-lookup"><span data-stu-id="76e95-216">In general, your title should treat the Arena session the same way it would treat its own MPSD session.</span></span> <span data-ttu-id="76e95-217">たとえば、ハンドルを作成し、RTA 通知をサブスクライブすることができます。</span><span class="sxs-lookup"><span data-stu-id="76e95-217">For example, it can create handles and subscribe for RTA notifications.</span></span> <span data-ttu-id="76e95-218">ただし、違いがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="76e95-218">But there are a few differences.</span></span> <span data-ttu-id="76e95-219">たとえば、タイトルは、ゲーム セッションの参加者名簿を変更できず、セッションのサービスの品質 (QoS) 機能を使用できません。また、判定に参加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-219">For example, your title can’t change the roster of the game session or use the Quality of Service (QoS) features of the session, and it must participate in arbitration.</span></span> <span data-ttu-id="76e95-220">セッションについて詳しくは、このガイドで後ほど説明します。</span><span class="sxs-lookup"><span data-stu-id="76e95-220">The complete details of the session are provided later in this document.</span></span>

### <a name="3--reporting-results"></a><span data-ttu-id="76e95-221">3. 結果の報告</span><span class="sxs-lookup"><span data-stu-id="76e95-221">3.  Reporting results</span></span>

<span data-ttu-id="76e95-222">マッチの結果は、判定と呼ばれる機能を使って、セッション経由で Arena と TO に報告されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-222">The results of the match are reported back to Arena and the TO through the session by using a feature called arbitration.</span></span> <span data-ttu-id="76e95-223">判定は、セッションを使って安全にマッチをプレイし、結果を報告するフレームワークです。</span><span class="sxs-lookup"><span data-stu-id="76e95-223">Arbitration is a framework for using a session to securely play a match and report a result.</span></span>

<span data-ttu-id="76e95-224">プロトコルのアクティブ化のステップでタイトルに提供されるセッションは、判定済みセッションとなります。これは、判定フレームワークが適用する固定タイムラインを持つセッションです。</span><span class="sxs-lookup"><span data-stu-id="76e95-224">The session provided to your title in the protocol-activation step will be an arbitrated session, which means that it has a fixed timeline that the arbitration framework enforces.</span></span> <span data-ttu-id="76e95-225">次の図に、判定のタイムラインを示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-225">This diagram shows the arbitration timeline.</span></span>

![](../../images/arena/arbitration-timeline.png)

<span data-ttu-id="76e95-226">失効時刻 (開始時刻に失効タイムアウト時間を加えた時刻) の前に、少なくとも 1 人のプレイヤーがアクティブである必要があります (`multiplayer_session_arbitration_server::arbitration_start_time()`)。失効タイムアウトは、セッション内の `/constants/system/arbitration/forfeitTimeout` (`multiplayer_session_constants::forfeit_timeout()`) に、ミリ秒単位で指定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-226">At least one player must be active in the session before the forfeit time, which is the start time (`multiplayer_session_arbitration_server::arbitration_start_time()`) plus the forfeit time-out. The forfeit time-out is in the session as a number of milliseconds at `/constants/system/arbitration/forfeitTimeout` (`multiplayer_session_constants::forfeit_timeout()`).</span></span> <span data-ttu-id="76e95-227">失効時刻までに参加済みのアクティブなプレイヤーがいない場合、マッチはキャンセルされます。</span><span class="sxs-lookup"><span data-stu-id="76e95-227">If no one has joined the session as active before the forfeit time, the match is canceled.</span></span>

<span data-ttu-id="76e95-228">判定タイムアウトは、`/constants/system/arbitration/arbitrationTimeout` (`multiplayer_session_constants::arbitration_timeout()`) にミリ秒で指定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-228">The arbitration time-out is in milliseconds at `/constants/system/arbitration/arbitrationTimeout` (`multiplayer_session_constants::arbitration_timeout()`) .</span></span> <span data-ttu-id="76e95-229">判定時刻は、開始時刻に判定タイムアウト時間を加えた時刻であり、プレイヤーはこの時刻までにマッチを完了して結果を報告する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-229">Arbitration time is the start time plus the value of the arbitration time-out, and represents the time by which the players must have completed the match and reported results.</span></span> <span data-ttu-id="76e95-230">この値は、発行元が、セッション テンプレートまたはゲーム モードで設定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-230">This value is set in the session template or game mode by the publisher.</span></span> <span data-ttu-id="76e95-231">この値は、タイトルでマッチを完了できるように必要な時間を設定してください。</span><span class="sxs-lookup"><span data-stu-id="76e95-231">Set it to allow as much time as your title needs for the match to be completed.</span></span>

<span data-ttu-id="76e95-232">タイトルは、開始時刻から判定時刻までの間、いつでも結果を報告できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-232">Your title can report results at any time between the start time and the arbitration time.</span></span> <span data-ttu-id="76e95-233">判定は、失効時刻から判定時刻までの間に、セッションのすべてのアクティブなメンバーの結果が送信された後で随時実行されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-233">Arbitration occurs at any time between the forfeit time and the arbitration time, after every active member of the session has submitted results.</span></span> <span data-ttu-id="76e95-234">たとえば、失効時にアクティブなメンバーが 1 人だけのセッションでも、メンバーは結果を投稿でき (または投稿しなければならず)、判定が行われます。</span><span class="sxs-lookup"><span data-stu-id="76e95-234">For example, if just one member is active in the session at the forfeit time, they can (and should) post a result, and arbitration will occur.</span></span> <span data-ttu-id="76e95-235">判定時刻までに報告された結果の数に関係なく、判定は、既に行われていない限り行われます。</span><span class="sxs-lookup"><span data-stu-id="76e95-235">No matter how many results are available at arbitration time, arbitration will occur if it hasn’t already.</span></span> <span data-ttu-id="76e95-236">判定時刻に結果がまったく提出されていない場合、マッチのすべての参加者が敗者と判定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-236">If no results are submitted when arbitration time is reached, all participants in the match are given a loss.</span></span>

<span data-ttu-id="76e95-237">また判定済みの結果を書き込むだけで、ゲーム サーバーによっていつでも判定を強制できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-237">It’s also possible for a game server to force arbitration at any time by simply writing an arbitrated result.</span></span>

<span data-ttu-id="76e95-238">セッション内のユーザーが既に判定済みの場合 (判定タイムアウトに達した場合や、ゲーム サーバーによる判定済みの場合、またはユーザーの参加が遅れた場合)、タイトルはマッチを終了し、判定結果をユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-238">If a user is in a session that has already been arbitrated (either because the arbitration time-out expired, a game server arbitrates the session, or the user joins late), your title ends the match and displays the arbitrated result to the user.</span></span>

<span data-ttu-id="76e95-239">判定結果には、常に、すべてのチームの結果が含まれます。</span><span class="sxs-lookup"><span data-stu-id="76e95-239">Arbitration results always include the outcome for every team.</span></span> <span data-ttu-id="76e95-240">個々のプレイヤーがセッションに結果を書き込むと、自分のチームの結果だけでなく、すべてのチームの完全な結果のセットが判定結果に含まれます。</span><span class="sxs-lookup"><span data-stu-id="76e95-240">When an individual player writes a result to the session, it includes not just their team’s outcome, but the full set of results for every team.</span></span>

<span data-ttu-id="76e95-241">JSON では、結果が次のように記述されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-241">The results in JSON look like this.</span></span>

```json
"results": {
    "red": {
        "outcome": "rank",
        "ranking": 1
    },
    "blue": {
        "outcome": "rank",
        "ranking": 2
    }
}
```

<span data-ttu-id="76e95-242">この例で、チーム ID は “red” と “blue” です。</span><span class="sxs-lookup"><span data-stu-id="76e95-242">In this example, the team IDs are “red” and “blue”.</span></span> <span data-ttu-id="76e95-243">red チームが 1 位、blue チームが 2 位です。</span><span class="sxs-lookup"><span data-stu-id="76e95-243">The red team came in first and the blue team second.</span></span> <span data-ttu-id="76e95-244">**outcome** の値には、この他に次の値を使用できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-244">Other possible values for **outcome** are:</span></span>

* <span data-ttu-id="76e95-245">“win”</span><span class="sxs-lookup"><span data-stu-id="76e95-245">“win”</span></span>
* <span data-ttu-id="76e95-246">“loss”</span><span class="sxs-lookup"><span data-stu-id="76e95-246">“loss”</span></span>
* <span data-ttu-id="76e95-247">“draw”</span><span class="sxs-lookup"><span data-stu-id="76e95-247">“draw”</span></span>
* <span data-ttu-id="76e95-248">“noshow”</span><span class="sxs-lookup"><span data-stu-id="76e95-248">“noshow”</span></span>

<span data-ttu-id="76e95-249">**outcome** が “rank” 以外の場合、そのチームの順位が省略されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-249">If **outcome** is anything other than “rank,” the ranking is omitted for that team.</span></span>

<span data-ttu-id="76e95-250">個々のユーザーは、マッチの結果を `/members/{index}/properties/system/arbitration` (`multiplayer_session::set_current_user_member_arbitration_results()` に書き込みます。</span><span class="sxs-lookup"><span data-stu-id="76e95-250">Individual users write the match results to `/members/{index}/properties/system/arbitration` (`multiplayer_session::set_current_user_member_arbitration_results()`).</span></span> <span data-ttu-id="76e95-251">以下では、タイトルがチームベースでない場合 (つまり、すべてのプレイヤーが 1 人のチームに属する場合) に、タイトルを構築し、結果セットを提出する方法の例を示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-251">The following example illustrates how a title might construct and submit a set of results, assuming that your title isn’t team based (that is, all players are on teams of one).</span></span>

```c++
void Sample::SubmitResultsForArbitration()
{
    std::unordered_map<string_t, tournament_team_result> results;

    for (auto& member : arbitratedSession->members())
    {
        tournament_team_result teamResult;
        teamResult.set_state(tournament_game_result_state::rank);
        teamResult.set_ranking(memberRank);

        results.insert(std::pair<string_t, tournament_team_result>(
            member->team_id(),
            teamResult));
    }

    arbitratedSession->set_current_user_member_arbitration_results(results);
    xboxLiveContext->multiplayer_service().write_session(
arbitratedSession,
multiplayer_session_write_mode::update_existing)
    .then([](xbox_live_result<std::shared_ptr<multiplayer_session>> sessionResult)
    {
        if (sessionResult.err())
        {
            // Handle error.
        }
        else
        {
            // Update local session cache.
        }
    });
}
```

<span data-ttu-id="76e95-252">判定が行われた後、MPSD は最終結果を、以下に示す他の少数のプロパティと共に `/servers/arbitration/properties/system`(`multiplayer_session::arbitration_server()`) に配置します。</span><span class="sxs-lookup"><span data-stu-id="76e95-252">After arbitration occurs, MPSD places the final results in `/servers/arbitration/properties/system` (`multiplayer_session::arbitration_server()`), along with a few other properties as shown here.</span></span>

```json
{
    "resultState": "completed”,
    "resultSource": "arbitration",
    "resultConfidenceLevel": 75,

    "results": { ... }
}
```

<span data-ttu-id="76e95-253">**resultState** に格納できる値は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="76e95-253">Possibilities for **resultState** include:</span></span>

* <span data-ttu-id="76e95-254">“completed”: すべてのアクティブなプレイヤーが結果を報告しました。</span><span class="sxs-lookup"><span data-stu-id="76e95-254">“completed”: All active players reported a result.</span></span>
* <span data-ttu-id="76e95-255">“partialresults”: 判定タイムアウトの前に、全部ではないが一部のプレイヤーが結果を報告しました。</span><span class="sxs-lookup"><span data-stu-id="76e95-255">“partialresults”: Some but not all active players reported a result before the arbitration time-out.</span></span>
* <span data-ttu-id="76e95-256">“noresults”: 判定タイムアウトの前に、結果を報告したプレイヤーはいませんでした。</span><span class="sxs-lookup"><span data-stu-id="76e95-256">“noresults”: None of the active players reported a result before the arbitration time-out.</span></span>
* <span data-ttu-id="76e95-257">“canceled”: 失効タイムアウトまでに、アクティブなプレイヤーが 1 人も参加しませんでした。</span><span class="sxs-lookup"><span data-stu-id="76e95-257">“canceled”: No active players arrived before the forfeit time-out.</span></span>

<span data-ttu-id="76e95-258">“noresults” と “canceled” の場合は、結果が省略されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-258">In the case of “noresults” and “canceled”, the results are omitted.</span></span>

<span data-ttu-id="76e95-259">個々のプレイヤーが報告する結果に基づいて MPSD が判定を行う場合、**resultSource** が “arbitration” に設定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-259">The **resultSource** is “arbitration” when MPSD performs the arbitration based on the results reported by individual players.</span></span> <span data-ttu-id="76e95-260">ゲーム サーバーは、判定をバイパスして /servers/arbitration/properties/system 自体に書き込むことができます。</span><span class="sxs-lookup"><span data-stu-id="76e95-260">A game server can write to /servers/arbitration/properties/system itself, bypassing arbitration.</span></span> <span data-ttu-id="76e95-261">その場合、**resultSource** が "server" に設定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-261">In that case, it indicates a **resultSource** of “server”.</span></span> <span data-ttu-id="76e95-262">ゲーム サーバーが結果を書き換える (修正または調整する) こともできます。その場合、**resultSource** が “adjusted” に設定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-262">It’s also possible for a game server to rewrite (that is, fix or adjust) the results, in which case it sets **resultSource** to “adjusted”.</span></span>

<span data-ttu-id="76e95-263">**resultConfidenceLevel** は、結果の合意レベルを示す 0 ～ 100 の整数です。</span><span class="sxs-lookup"><span data-stu-id="76e95-263">The **resultConfidenceLevel** is an integer between 0 and 100 that indicates the level of consensus in the result.</span></span> <span data-ttu-id="76e95-264">100 は、すべてのプレイヤーが同意していることを意味します。</span><span class="sxs-lookup"><span data-stu-id="76e95-264">100 means all players agree.</span></span> <span data-ttu-id="76e95-265">0 は合意がなく、基本的には、提出された結果からランダムに選択された結果であることを意味します。</span><span class="sxs-lookup"><span data-stu-id="76e95-265">0 means there was no consensus, and a result was chosen essentially at random from those submitted.</span></span> <span data-ttu-id="76e95-266">ゲーム サーバーが判定結果を設定しているときは、**resultConfidenceLevel** が通常、100 に設定されます。しかし、なんらかの理由でゲーム サーバーの判定が確実でない場合 (ゲーム サーバー自体の機能によって、プレイヤーによる投票手続きの結果を報告している場合など) は、異なる数値が設定されることもあります。</span><span class="sxs-lookup"><span data-stu-id="76e95-266">When a game server sets the arbitration results, it sets the **resultConfidenceLevel**-typically to 100, unless for some reason even the game server itself isn’t sure (for example, if it’s reporting the results of its own per-player voting procedure).</span></span> <span data-ttu-id="76e95-267">**resultConfidenceLevel** は、調整結果の信頼度を反映して結果が調整された場合にも設定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-267">Set the **resultConfidenceLevel** also when results are adjusted to reflect the confidence in the adjusted results.</span></span>

<span data-ttu-id="76e95-268">**resultSource** が “arbitration” の場合 (かつ、**resultState** が “completed” または “partialresults” の場合)、提供される結果は、プレイヤーが報告した結果の少なくとも 1 つの正確なコピーです。</span><span class="sxs-lookup"><span data-stu-id="76e95-268">When the **resultSource** is “arbitration” (and the **resultState** is “completed” or “partialresults”), the results provided are an exact copy of at least one of the player-reported results.</span></span>

### <a name="4--returning-to-the-xbox-arena-ui"></a><span data-ttu-id="76e95-269">4. Xbox Arena UI への復帰</span><span class="sxs-lookup"><span data-stu-id="76e95-269">4.  Returning to the Xbox Arena UI</span></span>

<span data-ttu-id="76e95-270">マッチの終了時には (または進行中のマッチの破棄を求めるプレイヤーの要求に対応して)、プレイヤーが、マッチの参加時に使った Xbox Arena UI に戻るためのオプションを表示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-270">When the match is over (or potentially in response to a player’s request to abandon the match in progress), present an option for the player to return to the Xbox Arena UI from where they joined the match.</span></span> <span data-ttu-id="76e95-271">これは、マッチ終了後の結果画面またはその他の任意のゲーム終了 UI に表示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-271">This can be done from a post-match results screen or any other end-of-game UI.</span></span>

<span data-ttu-id="76e95-272">Arena UI に戻るには、`Windows::System::Launcher` クラスを使って、プロトコルのアクティブ化 URI から渡された **returnUri** を起動します。</span><span class="sxs-lookup"><span data-stu-id="76e95-272">To return to the Arena UI, invoke the **returnUri** that was passed in from the protocol-activation URI by using the `Windows::System::Launcher` class.</span></span> <span data-ttu-id="76e95-273">必ずユーザー コンテキストを含めてください。</span><span class="sxs-lookup"><span data-stu-id="76e95-273">Be sure to include the user context.</span></span>

<span data-ttu-id="76e95-274">ERA ゲームに対しては、起動 API の動作が、ユニバーサル Windows プラットフォーム (UWP) ゲームに対する場合とは若干異なります。</span><span class="sxs-lookup"><span data-stu-id="76e95-274">The launch API is exposed slightly differently to ERA games than to Universal Windows Platform (UWP) games.</span></span> <span data-ttu-id="76e95-275">ERA バージョンの API では PFN を指定できないため、アクティブ化 URI で PFN が指定されていても無視されることがあります。</span><span class="sxs-lookup"><span data-stu-id="76e95-275">The ERA version of the API doesn’t allow the PFN to be supplied, so the PFN can be ignored even if present on the activation URI.</span></span>

<span data-ttu-id="76e95-276">ERA でユーザーを Arena UI に戻すためのコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-276">Here’s example code for an ERA to return the user to the Arena UI.</span></span>

```c++
void Sample::LaunchReturnUi(Uri ^returnUri, Windows::Xbox::System::User ^currentUser)
{
    auto options = ref new LauncherOptions();
    options->Context = currentUser;

    Launcher::LaunchUriAsync(returnUri, options);
}
```

<span data-ttu-id="76e95-277">UWP ゲームでは、プロトコルのアクティブ化 URI で戻り PFN が指定されている場合、**LauncherOptions** の **TargetApplicationPackageFamilyName** プロパティをその戻り PFN に設定できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-277">UWP games can set the **TargetApplicationPackageFamilyName** property on **LauncherOptions** to the return PFN, if one was provided on the protocol activation URI.</span></span> <span data-ttu-id="76e95-278">これにより特定のアプリが起動され、そのアプリがまだインストールされていない場合は、ユーザーが Store に誘導されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-278">That ensures that the specific app is launched and that the user is taken to the Store if the app isn’t already installed.</span></span>

<span data-ttu-id="76e95-279">UWP アプリでユーザーを Arena UI に戻すためのコード例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-279">Here’s example code for a UWP app to return the user to the Arena UI.</span></span>

```c++
void Sample::LaunchReturnUi(Uri ^returnUri, String ^returnPfn, User ^currentUser)
{
    auto options = ref new LauncherOptions();

    if (returnPfn != nullptr)
    {
        options->TargetApplicationPackageFamilyName = returnPfn;
    }

    Launcher::LaunchUriForUserAsync(currentUser, returnUri, options);
}
```

<span data-ttu-id="76e95-280">Arena UI を呼び出した後、タイトルは場合によっては同じ画面で引き続き実行され、別のプロトコルのアクティブ化イベントが発生するまで待機します。</span><span class="sxs-lookup"><span data-stu-id="76e95-280">After invoking the Arena UI, your title continues running, possibly at that same screen, waiting for another protocol activation event.</span></span> <span data-ttu-id="76e95-281">これにより、プレイヤーが別のマッチでプレイする場合に、タイトルがすぐに対応できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-281">That way, if the player has another match to play, your title is ready to go.</span></span> <span data-ttu-id="76e95-282">その結果、プレイヤーがタイトルと Xbox Arena UI を切り替えて、マッチ間をスピーディに移動できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-282">This expedites the user experience as the player goes from match to match, switching between your title and Xbox Arena UI.</span></span>

### <a name="handling-errors-and-edge-cases"></a><span data-ttu-id="76e95-283">エラーおよびエッジ ケースの処理</span><span class="sxs-lookup"><span data-stu-id="76e95-283">Handling errors and edge cases</span></span>

<span data-ttu-id="76e95-284">前のセクションのフローは、問題なくマッチをプレイできる場合のパスについて説明しています。</span><span class="sxs-lookup"><span data-stu-id="76e95-284">The flow in the preceding section describes the golden path through playing a match.</span></span> <span data-ttu-id="76e95-285">しかし、予期しない動作が生じたり、問題が発生したりする可能性のある箇所は数多く存在します。</span><span class="sxs-lookup"><span data-stu-id="76e95-285">There are many places where you may see unexpected behavior, or issues might arise.</span></span> <span data-ttu-id="76e95-286">このセクションでは、いくつかの潜在的なエラーやエッジ ケースを取り上げ、タイトル内での推奨される処理方法を示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-286">This section covers a number of potential errors or edge cases, and provides recommendations for handling them in your title.</span></span>

#### <a name="game-session-not-found"></a><span data-ttu-id="76e95-287">ゲーム セッションが見つからない</span><span class="sxs-lookup"><span data-stu-id="76e95-287">Game session not found</span></span>

<span data-ttu-id="76e95-288">マッチへのセッション参照によってタイトルを起動していて、クライアントがそのセッションを MPSD から要求する際にエラーが発生した場合は、マッチに参加できないことを示すエラーをユーザーに表示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-288">If your title is launched with a session ref for a match, and the client then fails to get an error when requesting that session from MPSD, present an error to the user indicating that they are unable to join the match.</span></span>

#### <a name="user-attempts-to-join-a-match-that-has-been-played"></a><span data-ttu-id="76e95-289">ユーザーが既にプレイしたマッチに参加を試みている</span><span class="sxs-lookup"><span data-stu-id="76e95-289">User attempts to join a match that has been played</span></span>

<span data-ttu-id="76e95-290">結果が既に報告された後でユーザーがマッチに参加しようとした場合は、クライアントが新しいマッチを開始できないように阻止し、ユーザーにエラーを表示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-290">If a user attempts to join a match after results have been reported, block that client from starting a new match and present the user with an error.</span></span> <span data-ttu-id="76e95-291">セッションのメンバーを反復処理して、`/members/{index}/arbitrationStatus` (`multiplayer_session_member::tournament_arbitration_status`) が “complete” に設定されているメンバーをチェックすることで、結果が報告済みかどうかを確認できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-291">You can check whether results have been reported by iterating through the members of the session to see if any have a `/members/{index}/arbitrationStatus` (`multiplayer_session_member::tournament_arbitration_status`) set to “complete”.</span></span>

#### <a name="game-clients-unable-to-establish-a-p2p-connection"></a><span data-ttu-id="76e95-292">ゲーム クライアントが p2p 接続を確立できない</span><span class="sxs-lookup"><span data-stu-id="76e95-292">Game clients unable to establish a p2p connection</span></span>

<span data-ttu-id="76e95-293">タイトルで、マルチプレイヤー対応のためにクライアント間でユーザー間 (p2p) 接続を使用しているが、リレーがサポートされない場合、マッチングされたユーザーが p2p 接続を確立できない可能性があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-293">If your title uses person-to-person (p2p) connections between clients for multiplayer and doesn’t have support for relays, there may be instances where users who are matched together are unable to form a p2p connection.</span></span>

<span data-ttu-id="76e95-294">クライアントがマッチのセッションは取得できるが、他のクライアントに接続できない場合、`/members/{index}/properties/system/arbitration/results`(`multiplayer_session::set_current_user_member_arbitration_results()`) で各チームに対して "draw" (引き分け) の結果を報告します。</span><span class="sxs-lookup"><span data-stu-id="76e95-294">If the client is able to retrieve the session for the match but can’t connect to other clients, report a “draw” result for each team under `/members/{index}/properties/system/arbitration/results` (`multiplayer_session::set_current_user_member_arbitration_results()`).</span></span> <span data-ttu-id="76e95-295">Xbox Live に対しては、マッチが実行されなかったものとして処理されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-295">This indicates to Xbox Live that the match has not taken place.</span></span> <span data-ttu-id="76e95-296">またこれにより、強制的に p2p 接続エラーを発生させてトーナメントを進めようとする不正行為も防止できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-296">It also prevents exploits where users can advance through a tournament by forcing a p2p connection failure.</span></span>

#### <a name="game-client-disconnects-mid-match"></a><span data-ttu-id="76e95-297">ゲームのクライアントが、マッチの途中で切断される</span><span class="sxs-lookup"><span data-stu-id="76e95-297">Game client disconnects mid-match</span></span>

<span data-ttu-id="76e95-298">最も一般的なエラー状況の 1 つが、マッチのプレイ中にクライアントが切断されるというエラーです。</span><span class="sxs-lookup"><span data-stu-id="76e95-298">One of the most common error scenarios is when clients disconnect while a match is being played.</span></span> <span data-ttu-id="76e95-299">このケースを処理する方法については、マッチと実装の状態に応じていくつかの選択肢があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-299">Depending on the state of the match and your implementation, there are a few options for handling this case:</span></span>

* <span data-ttu-id="76e95-300">トーナメント マッチが 1 対 1 の場合、またはチームのすべてのメンバーが他のクライアントやゲーム サービスから切断された場合、切断されたチームについて "loss" (消失) を報告することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="76e95-300">If the tournament match is one vs. one, or if all members of a team disconnect from the other clients and/or your game service, we recommend that you report a “loss” for the team that is no longer connected.</span></span> <span data-ttu-id="76e95-301">これにより、負けそうなユーザーが、結果の報告を阻止しようとして強制的に切断することを防止できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-301">This prevents the case in which users can force a disconnect from a match they are losing to prevent the result from being reported.</span></span>
* <span data-ttu-id="76e95-302">複数メンバーのチーム間のマッチで、一部のチーム メンバーがマッチの途中で切断された場合は、その時点でマッチを終了するか、残りのメンバーでマッチを続けるかを選択できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-302">If the match is between teams with multiple members, and a subset of the clients for a team disconnect mid-match, you can choose to end the match at that point or allow it to continue with the remaining users.</span></span> <span data-ttu-id="76e95-303">マッチを続行する場合、切断されたユーザーにマッチへの再参加を許可するという選択肢も考えられます。</span><span class="sxs-lookup"><span data-stu-id="76e95-303">If you choose to continue the match, you may also optionally allow users who disconnected to rejoin the match.</span></span>

#### <a name="full-teams-not-present"></a><span data-ttu-id="76e95-304">チーム メンバーが揃わない</span><span class="sxs-lookup"><span data-stu-id="76e95-304">Full team(s) not present</span></span>

<span data-ttu-id="76e95-305">複数メンバーのチーム間のマッチをサポートするタイトルの場合、チームの一部のメンバーが、タイトルを起動できずマッチに参加できないことがあります。</span><span class="sxs-lookup"><span data-stu-id="76e95-305">If your title supports matches with teams of two or more, you may encounter cases where some members of a team fail to launch your title for their match.</span></span> <span data-ttu-id="76e95-306">この場合、それらのチーム メンバーを除いたチームでプレイを許可することができます。さらに、アクセスできないメンバーがゲームの進行中に途中参加できるように設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="76e95-306">In this case, you can choose to allow the members of the team to play without their team member, and optionally allow that team member to join the match in progress.</span></span>

<span data-ttu-id="76e95-307">または、このマッチに対して、結果を強制適用することもできます。</span><span class="sxs-lookup"><span data-stu-id="76e95-307">Alternatively, you can automatically enforce a result.</span></span> <span data-ttu-id="76e95-308">その場合、forfeitTimeout に達するまで待ち、すべての参加者に参加の機会を確保したうえで結果を適用します。</span><span class="sxs-lookup"><span data-stu-id="76e95-308">If you do that, wait until the forfeitTimeout time to give all participants an opportunity to join the match before you enforce the result.</span></span> <span data-ttu-id="76e95-309">これにより、タイトルを更新する必要なしに、トーナメントのゲーム モードを変更してウィンドウを調整できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-309">This allows you to adjust the window with changes to the game mode for the tournament instead of having to update your title.</span></span>

#### <a name="length-of-match-exceeds-arbitrationtimeout"></a><span data-ttu-id="76e95-310">マッチの長さが arbitrationTimeout を超えている</span><span class="sxs-lookup"><span data-stu-id="76e95-310">Length of match exceeds arbitrationTimeout</span></span>

<span data-ttu-id="76e95-311">**arbitrationTimeout** の値を、マッチの最大所要時間よりも大きい値に設定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-311">Set the value for **arbitrationTimeout** to be greater than the maximum length of time a match can possibly take.</span></span> <span data-ttu-id="76e95-312">しかし、タイトルのモードによっては、マッチの所要時間が非常に長くなることがあり、最大時間がないこともあります。</span><span class="sxs-lookup"><span data-stu-id="76e95-312">That being said, your title may feature modes in which the possible match lengths are extremely long, or in which there is no maximum.</span></span> <span data-ttu-id="76e95-313">このような場合は、次のいずれかの方法を検討します。</span><span class="sxs-lookup"><span data-stu-id="76e95-313">In these cases, you consider either:</span></span>

* <span data-ttu-id="76e95-314">トーナメントのプレイを固定の最大時間があるモードに制限する。</span><span class="sxs-lookup"><span data-stu-id="76e95-314">Limiting tournament play to only modes with fixed, maximum lengths of time.</span></span>
* <span data-ttu-id="76e95-315">時間制限をユーザーに通知し、マッチ内で同点決勝ゲームを行って **arbitrationTimeout** までに結果を報告する。</span><span class="sxs-lookup"><span data-stu-id="76e95-315">Informing the user of the time limit, and reporting a result before the **arbitrationTimeout** based on an in-match tiebreaker.</span></span>

#### <a name="other-cases"></a><span data-ttu-id="76e95-316">それ以外の場合</span><span class="sxs-lookup"><span data-stu-id="76e95-316">Other cases</span></span>

<span data-ttu-id="76e95-317">その他のエラーについては、ユーザーにエラーを通知し、Xbox Arena UI にユーザーを戻すことが一般的な対処方法です。</span><span class="sxs-lookup"><span data-stu-id="76e95-317">For any other failure cases, the general guidance is to inform the user of the error and return the user to the Xbox Arena UI.</span></span>

## <a name="experience-requirements-and-best-practices"></a><span data-ttu-id="76e95-318">エクスペリエンス要件とベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="76e95-318">Experience requirements and best practices</span></span>

<span data-ttu-id="76e95-319">Arena はタイトルを個別のマッチでのみ提示するため、タイトルを更新する必要なしに、時間と共に新しい形式を導入できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-319">Because Arena only ever presents your title with individual matches, new formats can be introduced over time without requiring updates to your title.</span></span> <span data-ttu-id="76e95-320">そのため、Arena に統合されるタイトルの基本的なユーザー エクスペリエンスは、複数の対決形式と連携できるシンプルかつ柔軟なものでなければなりません。</span><span class="sxs-lookup"><span data-stu-id="76e95-320">Therefore the baseline user experience for an Arena integrated title must be simple and flexible enough to work with multiple competition formats.</span></span>

## <a name="configuring-a-title-for-arena"></a><span data-ttu-id="76e95-321">Arena 向けのタイトルの構成手順</span><span class="sxs-lookup"><span data-stu-id="76e95-321">Configuring a title for Arena</span></span>

<span data-ttu-id="76e95-322">タイトルを Arena で有効にするには、Xbox デベロッパー ポータル (XDP) またはユニバーサル デベロッパー センター (UDC) で構成タイトルを構成する際に、次の追加の手順を実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-322">To enable a title for Arena, some additional steps are required when you configure it in the Xbox Developer Portal (XDP) or Universal Dev Center (UDC).</span></span>

### <a name="enabling-arena-for-your-title"></a><span data-ttu-id="76e95-323">タイトルでの Arena の有効化</span><span class="sxs-lookup"><span data-stu-id="76e95-323">Enabling Arena for your title</span></span>

<span data-ttu-id="76e95-324">Arena を有効にするには、XDP でタイトルのサービス構成ページに移動し、[Arena] を選択します。</span><span class="sxs-lookup"><span data-stu-id="76e95-324">To enable Arena, go to the service configuration page for your title in XDP and select ‘Arena’.</span></span>

![](../../images/arena/arena-configure-xdp.png)

<span data-ttu-id="76e95-325">ここには、複数のオプションが用意されています。</span><span class="sxs-lookup"><span data-stu-id="76e95-325">Here, you’ll have several options:</span></span>

* <span data-ttu-id="76e95-326">**[Arena Enabled]** (Arena を有効にする): このサンド ボックスで Arena を有効にするには、このチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="76e95-326">**Arena Enabled** – Select this check box to enable Arena for this sandbox.</span></span>
* <span data-ttu-id="76e95-327">**[Arena Features]** (Arena 機能): このセクションには、ユーザー作成トーナメントをサンドボックス内で有効にするチェックボックスと、クロス プレイ (異なるプラットフォームを使用する複数のユーザーが同じトーナメントに参加できる機能) を有効にするチェック ボックスがあります。</span><span class="sxs-lookup"><span data-stu-id="76e95-327">**Arena Features** – This section includes check boxes to enable user-generated tournaments in the sandbox, and to enable cross play, which allows users on multiple platforms to participate in the same tournaments.</span></span>
* <span data-ttu-id="76e95-328">**[Arena Platforms]** (Arena プラットフォーム): タイトルのトーナメントをプレイできるプラットフォームを選択できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-328">**Arena Platforms** – Lets you select the platforms on which tournaments can be played for your title.</span></span>
* <span data-ttu-id="76e95-329">**[Tournament Assets]** (トーナメントのアセット): (従来、[Multiplayer and Matchmaking] (マルチプレーヤーとマッチメイキング) のセクションにあった項目)。これらはタイトルのトーナメント イメージです。</span><span class="sxs-lookup"><span data-stu-id="76e95-329">**Tournament Assets** – (Formerly in the ‘Multiplayer and Matchmaking’ section.) These are the tournament images for your title.</span></span>

<span data-ttu-id="76e95-330">変更を有効にするには、サービス構成を公開する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-330">You must publish the service configuration for your changes to take effect.</span></span> <span data-ttu-id="76e95-331">現在、UDC を介したセルフ サービスの Arena の構成はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="76e95-331">Self-service Arena configuration is currently not supported through UDC.</span></span> <span data-ttu-id="76e95-332">サービス構成に UDC を使用している場合は、Arena の有効化についてデベロッパー アカウント マネージャにご相談ください。</span><span class="sxs-lookup"><span data-stu-id="76e95-332">If you’re using UDC for service configuration, work with your Development Account Manager to onboard with Arena.</span></span>

### <a name="setting-up-game-modes"></a><span data-ttu-id="76e95-333">ゲーム モードの設定</span><span class="sxs-lookup"><span data-stu-id="76e95-333">Setting up game modes</span></span>

<span data-ttu-id="76e95-334">ゲーム モードは、発行元がトーナメント マッチの設定を事前に構成できる Xbox Live の機能です。</span><span class="sxs-lookup"><span data-stu-id="76e95-334">Game modes are an Xbox Live feature that enables the publisher to preconfigure settings for a tournament match.</span></span> <span data-ttu-id="76e95-335">これらのゲーム モードにより、トーナメントの作成時に、Xbox Live とタイトルがトーナメントに適用しているルールが設定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-335">These game modes are used upon tournament creation to set the rules enforced by Xbox Live and your title for the tournament.</span></span> <span data-ttu-id="76e95-336">タイトルでユーザー作成トーナメントを有効にするには、発行元が 1 つ以上のゲーム モードを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-336">As the title publisher, you need at least one game mode to enable user-generated tournaments for your title.</span></span> <span data-ttu-id="76e95-337">ゲーム モードには次の要素があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-337">Elements of the game mode include:</span></span>

#### <a name="supports-ugt"></a><span data-ttu-id="76e95-338">UGT 対応または非対応</span><span class="sxs-lookup"><span data-stu-id="76e95-338">Supports UGT?</span></span>

<span data-ttu-id="76e95-339">ユーザー作成トーナメント (UGT) で使用するゲーム モードを有効にすることができます。</span><span class="sxs-lookup"><span data-stu-id="76e95-339">Game modes can be enabled for use with user-generated tournaments (UGTs).</span></span> <span data-ttu-id="76e95-340">タイトルが UGT をサポートする場合、ゲーム モードをオンにすると、Xbox Live ユーザーがこのタイトルでトーナメントを作成する際にゲーム モードを選択できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-340">If your title is configured to support UGT, you can mark game modes so that they can be selected by Xbox Live users when creating tournaments for your title.</span></span>

#### <a name="team-size"></a><span data-ttu-id="76e95-341">チームの規模</span><span class="sxs-lookup"><span data-stu-id="76e95-341">Team size</span></span>

<span data-ttu-id="76e95-342">チームとしてトーナメントに参加できるユーザーの数です。</span><span class="sxs-lookup"><span data-stu-id="76e95-342">This is the number of users that can participate in the tournament as a team.</span></span> <span data-ttu-id="76e95-343">シングル ユーザーのタイトルまたはトーナメントでは、ゲーム モードのチーム サイズは 1 です。</span><span class="sxs-lookup"><span data-stu-id="76e95-343">For a single-user title or tournament, the game mode has a team size of one.</span></span> <span data-ttu-id="76e95-344">Arena は、現時点で、規模の変更が可能なトーナメント チームをサポートしていません。</span><span class="sxs-lookup"><span data-stu-id="76e95-344">Arena currently doesn’t support variable team sizes for tournaments.</span></span>

#### <a name="forfeittimeout"></a><span data-ttu-id="76e95-345">forfeitTimeout</span><span class="sxs-lookup"><span data-stu-id="76e95-345">forfeitTimeout</span></span>

<span data-ttu-id="76e95-346">マッチの開始時刻後、プレイヤーが 1 人も参加しない場合 (つまり、プレイヤーがセッションで自分をアクティブに設定しない場合) に、マッチがキャンセルされるまでの時間の長さです (ミリ秒単位)。</span><span class="sxs-lookup"><span data-stu-id="76e95-346">This is the number of milliseconds, after the match start time, before the match is canceled if no players show up for it (that is, if no players set themselves to active in the session).</span></span> <span data-ttu-id="76e95-347">少なくとも、プレイヤーがトースト通知を受け取ってタイトルを起動し、トーナメント マッチに参加できる十分な時間を設定してください。</span><span class="sxs-lookup"><span data-stu-id="76e95-347">Set this to an amount of time that’s at least long enough for a player to launch your title and get into the tournament match from the time they see the toast notification.</span></span>

#### <a name="arbitrationtimeout"></a><span data-ttu-id="76e95-348">arbitrationTimeout</span><span class="sxs-lookup"><span data-stu-id="76e95-348">arbitrationTimeout</span></span>

<span data-ttu-id="76e95-349">マッチの開始時刻後、結果の受け付けを締め切るまでの時間の長さ (ミリ秒単位) です。</span><span class="sxs-lookup"><span data-stu-id="76e95-349">This is the number of milliseconds, after the match start time, after which no more results will be accepted.</span></span> <span data-ttu-id="76e95-350">失効タイムアウト時間とマッチの最大所要時間の合計よりも長い時間を設定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-350">Set it to the forfeit time-out plus an amount of time longer than the longest match could possibly take.</span></span> <span data-ttu-id="76e95-351">これにより、失効時刻直前にプレイを開始したプレイヤーも、マッチを完了することができます。</span><span class="sxs-lookup"><span data-stu-id="76e95-351">That way, even if the players start playing right before the forfeit time, they still have enough time to finish the match.</span></span> <span data-ttu-id="76e95-352">**arbitrationTimeout** の時間内に結果が報告されない場合、マッチの参加者全員が敗者となります。</span><span class="sxs-lookup"><span data-stu-id="76e95-352">If no results are reported by the time of the **arbitrationTimeout**, the participants of the match all receive a loss.</span></span> <span data-ttu-id="76e95-353">Xbox Arena はまた、**arbitrationTimeout** までの間すべてのアクティブ メンバーが結果を報告するのを待ち、その後、判定を開始します。</span><span class="sxs-lookup"><span data-stu-id="76e95-353">Xbox Arena also waits up until the **arbitrationTimeout** for all active members to report results before beginning arbitration.</span></span>

<span data-ttu-id="76e95-354">このタイムアウトは、問題が発生してプレイヤーが結果を報告できない場合の安全弁として機能します。</span><span class="sxs-lookup"><span data-stu-id="76e95-354">This time-out acts as a backstop in case something goes wrong and a result doesn’t get reported for a player.</span></span> <span data-ttu-id="76e95-355">このタイムアウトを設定することで、トーナメント全体を停止するのではなく、トーナメントが結果を待つ最大時間が設定されます。</span><span class="sxs-lookup"><span data-stu-id="76e95-355">Rather than stalling the entire tournament, this time-out puts an upper bound on the amount of time that the tournament will wait.</span></span> <span data-ttu-id="76e95-356">したがって、この値によって各トーナメント ラウンドの最大時間が決まるため、過度に大きな値を設定しないように注意してください。</span><span class="sxs-lookup"><span data-stu-id="76e95-356">For that reason, it shouldn’t be set too high, because it determines the maximum length of each tournament round.</span></span>

#### <a name="name"></a><span data-ttu-id="76e95-357">名前</span><span class="sxs-lookup"><span data-stu-id="76e95-357">Name</span></span>

<span data-ttu-id="76e95-358">ユーザーに表示されるゲーム モード名です。</span><span class="sxs-lookup"><span data-stu-id="76e95-358">This is the user-facing name for game mode.</span></span> <span data-ttu-id="76e95-359">この値はローカライズ可能です。</span><span class="sxs-lookup"><span data-stu-id="76e95-359">This value is localizable.</span></span>

#### <a name="description"></a><span data-ttu-id="76e95-360">説明</span><span class="sxs-lookup"><span data-stu-id="76e95-360">Description</span></span>

<span data-ttu-id="76e95-361">ユーザーに表示されるゲーム モードの説明です。</span><span class="sxs-lookup"><span data-stu-id="76e95-361">This is the user-facing description for game mode.</span></span> <span data-ttu-id="76e95-362">この値はローカライズ可能です。</span><span class="sxs-lookup"><span data-stu-id="76e95-362">This value is localizable.</span></span>

#### <a name="custom"></a><span data-ttu-id="76e95-363">カスタム設定</span><span class="sxs-lookup"><span data-stu-id="76e95-363">Custom</span></span>

<span data-ttu-id="76e95-364">ゲーム モードの **custom** セクションは、開発者がトーナメント マッチに関するタイトル固有のあらゆる構成設定を挿入できるプロパティ バッグです。</span><span class="sxs-lookup"><span data-stu-id="76e95-364">The **custom** section for the game mode is a property bag where developers can insert any title-specific configuration settings for the tournament match.</span></span> <span data-ttu-id="76e95-365">カスタム セクションの一部として定義される値は、`/properties/custom/` のマッチ MPSD セッションに書き込まれます。</span><span class="sxs-lookup"><span data-stu-id="76e95-365">Values defined as part of the custom section are written to the match MPSD session under `/properties/custom/`.</span></span>

<span data-ttu-id="76e95-366">現時点では、XDP または UDC を介したゲーム モードのセットアップはサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="76e95-366">Currently, game mode setup is not supported through XDP or UDC.</span></span> <span data-ttu-id="76e95-367">タイトルのゲーム モードを作成するには、担当のデベロッパー アカウント マネージャーにご連絡ください。</span><span class="sxs-lookup"><span data-stu-id="76e95-367">To create game modes for your title, contact your Developer Account Manager.</span></span>

### <a name="requirements-for-the-session-template"></a><span data-ttu-id="76e95-368">セッション テンプレートの要件</span><span class="sxs-lookup"><span data-stu-id="76e95-368">Requirements for the session template</span></span>

<span data-ttu-id="76e95-369">タイトル デベロッパーは、TO がマッチ セッションの作成時に使用するセッション テンプレートを提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-369">As the title developer, you must provide the session template for the TO for use when creating sessions for matches.</span></span> <span data-ttu-id="76e95-370">このテンプレートには、いくつか必要な設定値があります。</span><span class="sxs-lookup"><span data-stu-id="76e95-370">There are some expectations about the contents of the template.</span></span>

```json
{
    "version": 1,
    "inviteProtocol": "tournamentGame",
    "memberInitialization": null,

    "capabilities": {
        "gameplay": true,
        "arbitration": true,

        "large": false,
        "broadcast": false,
        "blockBadMsaReputation": false
    },

    "maxMembersCount": {maxMembersCount},
}
```

<span data-ttu-id="76e95-371">必要に応じて、これ以外のプロパティも設定できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-371">Other properties not shown here can be set however you want.</span></span>

<span data-ttu-id="76e95-372">Arena セッションは、常に、バージョン 1 です。</span><span class="sxs-lookup"><span data-stu-id="76e95-372">Arena sessions are always version 1.</span></span> <span data-ttu-id="76e95-373">**inviteProtocol** を “tournamentGame” に設定して、トーナメント参加者にマッチの準備完了通知を送信します。</span><span class="sxs-lookup"><span data-stu-id="76e95-373">Setting the **inviteProtocol** to “tournamentGame” enables the match-ready notifications to be sent to tournament participants.</span></span> <span data-ttu-id="76e95-374">**memberInitialization** は null に設定して QoS を無効にします。</span><span class="sxs-lookup"><span data-stu-id="76e95-374">**memberInitialization** is set to null to disable QoS.</span></span> <span data-ttu-id="76e95-375">これはマッチのセッションであるため、ゲームプレイ機能をオンにします。判定機能は、結果の報告に必要です。</span><span class="sxs-lookup"><span data-stu-id="76e95-375">The gameplay capability must be set because the session represents a match, and the arbitration capability is required for results reporting.</span></span> <span data-ttu-id="76e95-376">**large**、**broadcast**、**blockBadMsaReputation** の各機能は、セッションの動作を阻害するため無効にします。</span><span class="sxs-lookup"><span data-stu-id="76e95-376">The **large**, **broadcast**, and **blockBadMsaReputation** capabilities must be disabled because they would interfere with the operation of the session.</span></span>

<span data-ttu-id="76e95-377">タイトルでは、このテンプレートを使用するすべてのトーナメントに固定の値を適用する設定項目について、テンプレートの custom セクションに固有の設定値を指定できます。</span><span class="sxs-lookup"><span data-stu-id="76e95-377">Your title can specify its own settings in the custom section of the template, for settings that have a fixed value for all tournaments that use the template.</span></span> <span data-ttu-id="76e95-378">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="76e95-378">Here’s an example.</span></span>

```json
        "custom": {
            "enableCheats": false,
            "bestOf": 3
        }
```

<span data-ttu-id="76e95-379">最後に、**maxMembersCount** システム設定が必要です。</span><span class="sxs-lookup"><span data-stu-id="76e95-379">Finally, the **maxMembersCount** system setting is required.</span></span> <span data-ttu-id="76e95-380">これには、トーナメント マッチでプレイできるプレイヤーの合計数を設定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-380">Set it to the total number of players that can play in a tournament match.</span></span> <span data-ttu-id="76e95-381">プレイヤーの数は、ゲーム モードの設定によってさらに制限できるため、セッションで設定する値には、必ずタイトルでサポートされる最大プレイヤー合計数を設定してください。</span><span class="sxs-lookup"><span data-stu-id="76e95-381">The number of players can be further constrained by game mode settings, so make sure that the value set in the session represents the highest total number of players supported for your title.</span></span> <span data-ttu-id="76e95-382">たとえば、ゲームが 1 回のマッチで最大 5 人対 ５ 人のプレイヤーをサポートする場合は、**maxMembersCount** を 10 に設定します。</span><span class="sxs-lookup"><span data-stu-id="76e95-382">For example, if the maximum number of players your game supports for a match is 5 vs. 5, set **maxMembersCount** to 10.</span></span> <span data-ttu-id="76e95-383">この MPSD テンプレートを使用した場合、**maxMembersCount** を上限として、任意の数のプレイヤーのマッチがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="76e95-383">This MPSD template can be used to support matches of any number of players up to the **maxMembersCount**.</span></span>