---
title: 評判
author: KevinAsgari
description: Xbox Live が評判サービスを使って前向きなゲームプレイを推進している方法について説明します。
ms.assetid: f8966184-5db7-4cab-93ca-9a0250a6077d
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, 評判, ソーシャル プラットフォーム
ms.localizationpriority: medium
ms.openlocfilehash: cc296892a8d3134dd44ff4bad43603fd164ed5fd
ms.sourcegitcommit: fbdc9372dea898a01c7686be54bea47125bab6c0
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/08/2018
ms.locfileid: "4414798"
---
# <a name="reputation"></a><span data-ttu-id="c1bb9-104">評判</span><span class="sxs-lookup"><span data-stu-id="c1bb9-104">Reputation</span></span>

<span data-ttu-id="c1bb9-105">評判は、他と同じようにユーザー統計であり、すべてのユーザー統計を取得し、それらをレポートや追跡で使用するための呼び出しに含まれます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-105">Reputation is a user statistic, just like any other, and is included in calls to retrieve all of a user's statistics and use them in reporting and tracking.</span></span> <span data-ttu-id="c1bb9-106">評判自体は **Reputation クラス**によって表されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-106">The reputation itself is represented by the **Reputation Class**.</span></span> <span data-ttu-id="c1bb9-107">**ReputationService クラス**は、評判サービスを表します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-107">The **ReputationService Class**represents the reputation service.</span></span> <span data-ttu-id="c1bb9-108">対応する URI については、「**評判 URI**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-108">The corresponding URIs are described in **Reputation URIs**.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="c1bb9-109">評判の統計情報は、サービス全体が対象であり、特定のタイトルに結び付けられてはいません。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-109">Reputation statistics are global across the service, not tied to a specific title.</span></span> <span data-ttu-id="c1bb9-110">このサービスのサービス構成 ID (SCID) は、評判統計へのアクセスに使用されるグローバル SCID です。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-110">The service configuration ID (SCID) for the service is the global SCID used to access reputation statistics.</span></span>


## <a name="features-of-the-reputation-service"></a><span data-ttu-id="c1bb9-111">評判サービスの機能</span><span class="sxs-lookup"><span data-stu-id="c1bb9-111">Features of the Reputation Service</span></span>

<span data-ttu-id="c1bb9-112">評判サービスには以下の機能があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-112">The reputation service:</span></span>

-   <span data-ttu-id="c1bb9-113">良い評価と悪い評価を同じ方法で処理します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-113">Handles feedback and complaints in the same way.</span></span> <span data-ttu-id="c1bb9-114">エンティティがユーザーのフィードバックを送信すると、このフィードバックはユーザーの評判に影響します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-114">Entities submit feedback about a user, and this feedback affects the user's reputation.</span></span> <span data-ttu-id="c1bb9-115">このフィードバックはその後、さらなる措置のために執行チームに転送される場合もあります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-115">The feedback can then be forwarded to the Enforcement team for further action.</span></span>
-   <span data-ttu-id="c1bb9-116">ユーザーは他のユーザーに関するフィードバックを提供できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-116">Allows users to give feedback on other users.</span></span> <span data-ttu-id="c1bb9-117">タイトルはフィードバックを自動的に送信できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-117">Titles can submit feedback automatically.</span></span>
-   <span data-ttu-id="c1bb9-118">タイトルは API に直接アクセスできます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-118">Allows titles direct access to the API.</span></span> <span data-ttu-id="c1bb9-119">ユーザーは、ゲーム内から、また、ユーザーが現在いるゲーム領域のコンテキスト内から、フィードバックを直接送信できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-119">A user can submit feedback directly from within a game, and from within the context of the game area where the user is currently.</span></span>
-   <span data-ttu-id="c1bb9-120">評判が低くなると、ユーザーが Xbox Live 上やタイトル内で実行できる内容に影響するように処理します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-120">Handles low reputation as affecting what users are able to do on Xbox Live and within titles.</span></span> <span data-ttu-id="c1bb9-121">したがって、ユーザーは、自分の評判を常に意識し、オンライン プレイでより適切な振る舞いをする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-121">Thus users must keep an eye on their reputation and act more appropriately during online play.</span></span>
-   <span data-ttu-id="c1bb9-122">悪い評価だけでなく、良い評価も受け入れます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-122">Permits positive feedback, as well as negative feedback.</span></span> <span data-ttu-id="c1bb9-123">Xbox コミュニティまたはタイトルのコミュニティに貢献するユーザーには、その労力に見合ったリワードを与えることができ、特別な権限を与えることもできます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-123">Users who help the Xbox community or a title's community can be rewarded for their efforts, and they can even be given special privileges.</span></span>
-   <span data-ttu-id="c1bb9-124">**Reputation.OverallReputation プロパティ**によって表される、単一の総合的な評判を導出します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-124">Derives a single, overall reputation, represented by the **Reputation.OverallReputation Property**.</span></span> <span data-ttu-id="c1bb9-125">次の評判の種類から導出されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-125">It is derived from the following reputation types:</span></span>

    -   <span data-ttu-id="c1bb9-126">フェア プレイ。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-126">Fair play.</span></span> <span data-ttu-id="c1bb9-127">**Reputation.CommunicationsReputation プロパティ**によって表されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-127">Represented by the **Reputation.FairplayReputation Property**.</span></span>
    -   <span data-ttu-id="c1bb9-128">通信。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-128">Communications.</span></span> <span data-ttu-id="c1bb9-129">**Reputation.CommunicationsReputation プロパティ**によって表されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-129">Represented by the **Reputation.CommunicationsReputation Property**.</span></span>
    -   <span data-ttu-id="c1bb9-130">ユーザー作成コンテンツ (UGC)。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-130">User-generated content (UGC).</span></span> <span data-ttu-id="c1bb9-131">**Reputation.UserGeneratedContentReputation プロパティ**によって表されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-131">Represented by the **Reputation.UserGeneratedContentReputation Property**.</span></span>

<span data-ttu-id="c1bb9-132">詳細については、「**ResetReputation (JSON)**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-132">See **ResetReputation (JSON)** for more information.</span></span>


## <a name="usage-flow-for-the-reputation-service"></a><span data-ttu-id="c1bb9-133">評判サービスの使用フロー</span><span class="sxs-lookup"><span data-stu-id="c1bb9-133">Usage Flow for the Reputation Service</span></span>

<span data-ttu-id="c1bb9-134">評判サービスの全体的なフローには、評判のレポートと、評判でフィルター処理されたマッチメイキングの 2 つのフェーズがあります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-134">The overall flow for the reputation service has two phases: reporting reputation and reputation-filtered matchmaking.</span></span>


## <a name="reporting-reputation"></a><span data-ttu-id="c1bb9-135">評判のレポート</span><span class="sxs-lookup"><span data-stu-id="c1bb9-135">Reporting Reputation</span></span>

<span data-ttu-id="c1bb9-136">特定のユーザーについて十分な数の悪い評価がレポートされると、タイトルはそのユーザーの **Reputation.OverallReputation プロパティ**を悪い評判を示すように設定します (JSON 属性 OverallReputationIsBad)。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-136">When enough negative feedback has been reported for a specific user, the title sets the **Reputation.OverallReputation Property** to indicate a bad reputation for that user (JSON attribute OverallReputationIsBad).</span></span> <span data-ttu-id="c1bb9-137">一定の時間、悪い評価がないと、ユーザーの評判はゆっくりと改善し、一度悪い評判になったユーザーが良い評判を再び得ることもできます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-137">Given time without complaints, a user's reputation slowly improves, and it is possible for a user with a once bad reputation to achieve a good reputation again.</span></span>


## <a name="reputation-filtered-matchmaking"></a><span data-ttu-id="c1bb9-138">評判でフィルター処理されたマッチメイキング</span><span class="sxs-lookup"><span data-stu-id="c1bb9-138">Reputation-filtered Matchmaking</span></span>

<span data-ttu-id="c1bb9-139">Xbox 要件 (XR) で指定されている、評判でフィルター処理されたマッチメイキングの場合は、タイトルはプレイヤーの **Reputation.OverallReputation プロパティ**の値を取得します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-139">For reputation-filtered matchmaking, specified by Xbox Requirement (XR), the title retrieves the player's **Reputation.OverallReputation Property**.</span></span> <span data-ttu-id="c1bb9-140">この値は、プレイヤーの総合的な評価の状態を示すスコアです。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-140">This value is a score that indicates the state of the player's overall reputation.</span></span>

> [!NOTE]
> <span data-ttu-id="c1bb9-141">タイトルは、JSON ファイルで OverallReputationIsBad 属性を検索して見つからない場合、ユーザーの評判が良いものと仮定しても安全です。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-141">If your title is looking for the OverallReputationIsBad attribute in a JSON file, and does not find it, it is safe to assume that the user has a good reputation.</span></span> <span data-ttu-id="c1bb9-142">これは、新しいアカウントで、ユーザーのフィードバックが処理されるまでに発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-142">This can happen with new accounts, until feedback has been processed for the user.</span></span> <span data-ttu-id="c1bb9-143">他のユーザーからのフィードバックがあったプレイヤーには必ず評判の統計情報があり、**Reputation.OverallReputation** プロパティに値が設定されています。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-143">Players with any feedback from other users will always have reputation statistics, and a value for the **Reputation.OverallReputation** property.</span></span>


## <a name="reputation-as-an-indicator-of-behavior"></a><span data-ttu-id="c1bb9-144">振る舞いの指標としての評判</span><span class="sxs-lookup"><span data-stu-id="c1bb9-144">Reputation as an Indicator of Behavior</span></span>

<span data-ttu-id="c1bb9-145">評判はユーザーがシステム上でどのような振る舞いをしているかの指標を提供します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-145">Reputation provides an indicator of how the user behaves on the system.</span></span> <span data-ttu-id="c1bb9-146">たとえば、その人はフレンドリーなプレイヤーでしょうか。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-146">For example, is the person a friendly player or not?</span></span> <span data-ttu-id="c1bb9-147">プレイヤーの評判は、他のセッション メンバーからのフィードバックによって決まります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-147">Feedback from other session members determines a player's reputation.</span></span> <span data-ttu-id="c1bb9-148">個々のユーザーが持つ評判スコアは、Xbox One のあらゆる場所でその人に随伴します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-148">Each user has a reputation score that travels with that person everywhere on Xbox One.</span></span> <span data-ttu-id="c1bb9-149">評判スコアはフレンドから見えるソーシャルな場所に目立つように公開されるため、より良い振る舞いをするよう、フレンドがプレイヤーにプレッシャーを与える効果があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-149">It's exposed prominently in social places that friends can see so that they can apply peer pressure to a player to behave better.</span></span> <span data-ttu-id="c1bb9-150">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-150">For example:</span></span>

-   <span data-ttu-id="c1bb9-151">評価スコアは各ユーザーのプロフィール カードに表示されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-151">It's on each user's profile card.</span></span> <span data-ttu-id="c1bb9-152">システム内のすべてのユーザーが、クリック 1 つでそのユーザーのプロフィールを見ることができます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-152">Anyone in the system can look at the user's profile with a single click.</span></span>
-   <span data-ttu-id="c1bb9-153">評価スコアはマルチプレイヤー ゲームで表示されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-153">It's shown in multiplayer games.</span></span> <span data-ttu-id="c1bb9-154">ユーザーどうしがオンラインで一緒にプレイするとき、グループ内で最も評判の低いプレイヤーの評判がグループの評判になります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-154">When users play together online, the group's reputation equates to the reputation of the player with the lowest reputation in the group.</span></span> <span data-ttu-id="c1bb9-155">グループは評判が近い他のグループとしかマッチングされません。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-155">The group is only matched with others with similar reputation.</span></span> <span data-ttu-id="c1bb9-156">他のプレイヤーは評判により、どのようなプレイヤーがそのゲームにいるかを判断し、ゲームに参加したいかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-156">Other players use reputation to decide what kind of players are in that game and decide if they want to join the game.</span></span>


## <a name="key-elements-of-reputation"></a><span data-ttu-id="c1bb9-157">評判の重要な要素</span><span class="sxs-lookup"><span data-stu-id="c1bb9-157">Key Elements of Reputation</span></span>

<span data-ttu-id="c1bb9-158">タイトルでは、ユーザーがフェアプレイ、コミュニケーション、またはユーザー作成コンテンツ (UGC) カテゴリーで敬遠対象レベルに達したかどうかを判定できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-158">A title can determine if a user has reached an Avoid Me level for fair play, communications, or user-generated content (UGC) categories.</span></span> <span data-ttu-id="c1bb9-159">次のいずれかのプロパティが 1 に設定されている場合、ユーザーは関連するカテゴリーについて "敬遠対象" に達しています。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-159">The user has reached Avoid Me for the associated category if any one of the following properties is set to 1:</span></span>

-   <span data-ttu-id="c1bb9-160">**Reputation.OverallReputation プロパティ**。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-160">**Reputation.OverallReputation Property**.</span></span> <span data-ttu-id="c1bb9-161">関連付けられた JSON 属性は OverallReputationIsBad です。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-161">The associated JSON attribute is OverallReputationIsBad.</span></span>
-   <span data-ttu-id="c1bb9-162">**Reputation.FairplayReputation プロパティ**。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-162">**Reputation.FairplayReputation Property**.</span></span> <span data-ttu-id="c1bb9-163">関連付けられた JSON 属性は FairplayReputationIsBad です。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-163">The associated JSON attribute is FairplayReputationIsBad.</span></span>
-   <span data-ttu-id="c1bb9-164">**Reputation.CommunicationsReputation プロパティ**。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-164">**Reputation.CommunicationsReputation Property**.</span></span> <span data-ttu-id="c1bb9-165">関連付けられた JSON 属性は CommsReputationIsBad です。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-165">The associated JSON attribute is CommsReputationIsBad.</span></span>
-   <span data-ttu-id="c1bb9-166">**Reputation.UserGeneratedContentReputation プロパティ**。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-166">**Reputation.UserGeneratedContentReputation Property**.</span></span> <span data-ttu-id="c1bb9-167">関連付けられた JSON 属性は UserContentReputationIsBad です。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-167">The associated JSON attribute is UserContentReputationIsBad.</span></span>


## <a name="good-game-reports"></a><span data-ttu-id="c1bb9-168">楽しかったゲームのレポート</span><span class="sxs-lookup"><span data-stu-id="c1bb9-168">Good Game Reports</span></span>

<span data-ttu-id="c1bb9-169">ユーザーの不適切な行為の報告に加えて、ユーザーどうしが楽しかったゲームのレポートを送信することもできます。これはタイトル内で最優秀プレイヤーへの投票として作成できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-169">In addition to reporting users for bad actions, users can also send each other good game reports, which can be created in titles as voting for the most valuable player.</span></span>


## <a name="feedback-history"></a><span data-ttu-id="c1bb9-170">フィードバック履歴</span><span class="sxs-lookup"><span data-stu-id="c1bb9-170">Feedback History</span></span>

<span data-ttu-id="c1bb9-171">フィードバック履歴は、そのユーザーについて最後に報告されたのはいつか、そのユーザーのどんなことが報告されたのかなどの情報をレポートします。たとえば、"コミュニケーション方法に関して最近送信されたフィードバック" などがあります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-171">Feedback history reports information such as the time when the user was last reported and what was the person reported for, for example, "Recently received feedback on Communication style."</span></span>


## <a name="xbox-requirement-for-reputation"></a><span data-ttu-id="c1bb9-172">評判に関する Xbox 要件</span><span class="sxs-lookup"><span data-stu-id="c1bb9-172">Xbox Requirement for Reputation</span></span>

<span data-ttu-id="c1bb9-173">Xbox 要件 (XR) 068、評判によるマッチメイキングのフィルタリングでは、悪い評判のプレイヤーを良い評判のプレイヤーから分離する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-173">Xbox Requirement (XR) 068, Matchmaking Filtering by Reputation, requires the separation of players with low reputation from those with high reputation.</span></span> <span data-ttu-id="c1bb9-174">これは、プレイヤーの **Reputation.OverallReputation** の値と、ユーザー統計でのプレイヤーの OverallReputationIsBad 属性を見ることによって行われます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-174">This is done by looking at the **Reputation.OverallReputation** value of a player and the player's OverallReputationIsBad attribute in user statistics.</span></span>

<span data-ttu-id="c1bb9-175">**UserStatisticsService.GetSingleUserStatisticsAsync メソッド (String, String, String)** の *statisticName* パラメーターに "OverallReputation" を渡すことによって、ユーザーの評判を取得できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-175">Your title can retrieve a user's reputation by passing "OverallReputation" to the *statisticName* parameter of the **UserStatisticsService.GetSingleUserStatisticsAsync Method (String, String, String)**.</span></span> <span data-ttu-id="c1bb9-176">WinRT メソッドは、次の JSON 本文に示されているように、**GET (/users/xuid({xuid})/scids/{scid}/stats)** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-176">The WinRT method calls **GET (/users/xuid({xuid})/scids/{scid}/stats)** as shown in the following JSON body.</span></span>

```json
    {
      "requestedusers": [
        "2533274792693551"
      ],
      "requestedscids": [
        {
          "scid": "7492baca-c1b4-440d-a391-b7ef364a8d40",
          "requestedstats": [
            "OverallReputationIsBad",
            "FairplayReputationIsBad",
            "CommsReputationIsBad",
            "UserContentReputationIsBad"
          ]
        }
      ]
    }
```

<span data-ttu-id="c1bb9-177">他のプレイヤーからのフィードバックが低レベルに達すると、そのユーザーの OverallReputationIsBad は 1 に設定されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-177">When a user's feedback from other players reaches a low level, OverallReputationIsBad is set to 1 for the user.</span></span> <span data-ttu-id="c1bb9-178">**Reputation.OverallReputation** が 1 である対象ユーザーは **OverallReputation** が 1 に設定された人物とのみマッチングする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-178">People for whom **Reputation.OverallReputation** is 1 should only be matched with other people having **OverallReputation** set to 1.</span></span> <span data-ttu-id="c1bb9-179">既定では、一般的なユーザーがマッチングの際に評判の低いユーザーとマッチングされることはありません。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-179">By default, when people enter a match, they generally don't have to deal with people with low reputations.</span></span> <span data-ttu-id="c1bb9-180">タイトルでは、良い評判のプレイヤーが評判の低いプレイヤーとマッチングすることを許容するオプションを設けることができます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-180">Titles can optionally allow a player with a good reputation to opt in to match with low-reputation players.</span></span>

<span data-ttu-id="c1bb9-181">評判に適用される XR の最新版については、Game Developer Network (GDN) の [Xbox 要件](https://developer.xboxlive.com/en-us/platform/certification/requirements/Pages/home.aspx)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-181">For the most recent version of XRs that apply to reputation, see [Xbox Requirements](https://developer.xboxlive.com/en-us/platform/certification/requirements/Pages/home.aspx) on Game Developer Network (GDN).</span></span>


## <a name="creating-users-with-bad-overall-reputation-for-testing"></a><span data-ttu-id="c1bb9-182">テスト用の、総合的な評判の低いユーザーの作成</span><span class="sxs-lookup"><span data-stu-id="c1bb9-182">Creating Users with Bad Overall Reputation for Testing</span></span>

<span data-ttu-id="c1bb9-183">非常に評判の低いユーザーをテスト用にセットアップし、タイトルのマッチ フィルターの実装をテストできます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-183">For testing, users with very poor reputation can be set up to test the match filtering implementation for a title.</span></span> <span data-ttu-id="c1bb9-184">ユーザーに特定の値を設定するには、テスト用のタイトルまたはツールで、**POST (/users/xuid({xuid})/resetreputation)** を呼び出し、ユーザーの特定の評判値を設定する JSON ファイルを指定します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-184">To set a specific value for a user, the test title or tool calls **POST (/users/xuid({xuid})/resetreputation)** with a JSON file that sets the user's specific reputation values.</span></span> <span data-ttu-id="c1bb9-185">詳細については、「**ResetReputation (JSON)**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-185">See **ResetReputation (JSON)** for more information.</span></span>

<span data-ttu-id="c1bb9-186">たとえば、次の JSON 本文は、ユーザーのフェア プレイの評判を非常に低い値に設定します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-186">For example, the following JSON body sets a user's fair play reputation to a very poor value:</span></span>

```json
    {
      "fairplayReputation": 5,
      "commsReputation": 75,
      "userContentReputation": 75
    }
```

<span data-ttu-id="c1bb9-187">パートナーは RETAIL を除くすべてのサンドボックスに対してこの呼び出しを実行できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-187">Partners can make this call for all sandboxes except for RETAIL.</span></span> <span data-ttu-id="c1bb9-188">この要求はユーザーの基本評判スコアを設定し、プレイヤーの良い評価の重みをすべて消去します。この呼び出しの後のユーザーの実際の評判は、この基本スコアにプレイヤーのアンバサダー ボーナスとプレイヤーのフォロワー ボーナスを加えたものになります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-188">This request sets a user's base reputation scores, and the player's weightings for positive feedback will all be zeroed out. The user's actual reputation after this call consists of these base scores plus the player's ambassador bonus, plus the player's follower bonus.</span></span> <span data-ttu-id="c1bb9-189">このメカニズムにより、マッチ フィルター XR をテストするための、低スコアかつ **Reputation.OverallReputation** が 1 に設定されたユーザーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-189">This mechanism creates a user with a low score and **Reputation.OverallReputation** set to 1 to test for the Match Filter XR.</span></span> <span data-ttu-id="c1bb9-190">このトピックの「評判に関する Xbox 要件」セクションで説明したように、タイトルはユーザーの評判スコアをユーザー統計サービスから取得できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-190">The title can get the user reputation score for the user from the user statistics service, as described in the "Xbox Requirement for Reputation" section of this topic.</span></span>


## <a name="resetting-a-users-reputation-to-the-defaults"></a><span data-ttu-id="c1bb9-191">ユーザーの評判の既定値へのリセット</span><span class="sxs-lookup"><span data-stu-id="c1bb9-191">Resetting a User's Reputation to the Defaults</span></span>

<span data-ttu-id="c1bb9-192">タイトルは、OverallReputationIsBad 属性を設定して、ユーザーの評判が良いことを示します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-192">The title sets the OverallReputationIsBad attribute to indicate that the user has a good reputation.</span></span> <span data-ttu-id="c1bb9-193">**POST (/users/me/resetreputation)** を呼び出し、すべての値を 75 に設定します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-193">It calls **POST (/users/me/resetreputation)** and sets all values to 75.</span></span> <span data-ttu-id="c1bb9-194">**/users/xuid({xuid})/deleteuserdata** を 1 回呼び出すだけで、複数の Xbox ユーザー ID をリセットできます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-194">A single call to **/users/xuid({xuid})/deleteuserdata** can be used to reset multiple Xbox user IDs.</span></span> <span data-ttu-id="c1bb9-195">要求本文は次のようになります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-195">The request body is:</span></span>

```json
    {
      "xuids": [
        "2814659110958830"
      ]
    }
```

## <a name="sending-feedback-from-titles"></a><span data-ttu-id="c1bb9-196">タイトルからのフィードバックの送信</span><span class="sxs-lookup"><span data-stu-id="c1bb9-196">Sending Feedback from Titles</span></span>

<span data-ttu-id="c1bb9-197">タイトルはマッチからプレイヤーのフェアプレイに関するフィードバックを送信できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-197">Titles can send fair play feedback about players from matches.</span></span> <span data-ttu-id="c1bb9-198">これを行うには、タイトルから直接送信するか、またはタイトル サービスからバッチで送信します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-198">This is done either directly from the title or from the title service in batches.</span></span> <span data-ttu-id="c1bb9-199">タイトルでは、**ReputationService.SubmitReputationFeedbackAsync メソッド**か、または次に示す直接の REST メソッドを使用できます。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-199">The title can use the **ReputationService.SubmitReputationFeedbackAsync Method** or the following direct REST methods:</span></span>

|                      |                                                             |
|----------------------|-------------------------------------------------------------|
| <span data-ttu-id="c1bb9-200">Client POST</span><span class="sxs-lookup"><span data-stu-id="c1bb9-200">Client POST</span></span>          | https://reputation.xboxlive.com/users/xuid{XUID}/feedback |
| <span data-ttu-id="c1bb9-201">サービス (バッチ) の POST</span><span class="sxs-lookup"><span data-stu-id="c1bb9-201">Service (Batch) POST</span></span> | https://reputation.xboxlive.com:10443/users/batchfeedback   |

<span data-ttu-id="c1bb9-202">提出用の JSON 本文のサンプルおよび許可されるフィールドの定義については、「**Feedback (JSON)**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-202">See **Feedback (JSON)** for a sample JSON body for the submission and for definitions of the allowed fields.</span></span>


## <a name="types-of-feedback-allowed"></a><span data-ttu-id="c1bb9-203">許可されるフィードバックの種類</span><span class="sxs-lookup"><span data-stu-id="c1bb9-203">Types of Feedback Allowed</span></span>

<span data-ttu-id="c1bb9-204">送信できるフィードバックのカテゴリーについては、「**Feedback (JSON)**」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-204">The categories of feedback that can be posted are defined in **Feedback (JSON)**.</span></span>


## <a name="when-titles-should-send-feedback"></a><span data-ttu-id="c1bb9-205">タイトルがフィードバックを送信する必要がある場合</span><span class="sxs-lookup"><span data-stu-id="c1bb9-205">When Titles Should Send Feedback</span></span>

<span data-ttu-id="c1bb9-206">ゲームでのプレイヤー エクスペリエンスに悪影響を与える状況が発生した場合、タイトルは否定的なフィードバックを送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-206">A title should send negative feedback when an event negatively affects the player experience in a game.</span></span> <span data-ttu-id="c1bb9-207">一般的な規則として、タイトルは、プレイされたラウンドごとに、1 つの種類につき 1 つだけフィードバックを送信します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-207">As a general rule, the title should send only one feedback per type, per round played.</span></span> <span data-ttu-id="c1bb9-208">たとえば、タイトルでは以下のようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-208">For example, the title should:</span></span>

1.  <span data-ttu-id="c1bb9-209">プレイヤーが 3 人以上のチームメイトを倒した場合は、チームメイトを倒すたびにイベントを送信するのではなく、全体に対して 1 つだけ FairPlayKillsTeammates フィードバック項目を送信します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-209">Only send one FairPlayKillsTeammates feedback item for a person per round to kill 3 or more teammates, instead of sending one event every time the person kills a teammate.</span></span>
2.  <span data-ttu-id="c1bb9-210">だれかが意図的に早くマッチを終了したときは、FairplayQuitter フィードバック項目を送信します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-210">Send the FairplayQuitter feedback item when someone purposefully quits a match early.</span></span>
3.  <span data-ttu-id="c1bb9-211">ユーザーがレーシング ゲームで逆方向に走行したときは、レースごとに 1 回、FairplayUnsporting フィードバック項目を送信します。</span><span class="sxs-lookup"><span data-stu-id="c1bb9-211">Send the FairplayUnsporting feedback item, once per race, when a user is driving backwards in a racing game.</span></span>
