---
title: リアルタイム アクティビティ サービス
description: Xbox Live リアルタイム アクティビティ サービスについて説明します。
ms.assetid: 50de262f-fc55-4301-83b5-0a8a30bc7852
ms.date: 04/04/2017
ms.topic: article
keywords: xbox live, xbox, ゲーム, uwp, windows 10, xbox one, リアルタイム アクティビティ サービス
ms.localizationpriority: medium
ms.openlocfilehash: 36389fac3bd6dea2d2e24c0935087781118d8046
ms.sourcegitcommit: 231065c899d0de285584d41e6335251e0c2c4048
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/10/2018
ms.locfileid: "8824841"
---
# <a name="real-time-activity-service"></a><span data-ttu-id="15958-104">リアルタイム アクティビティ サービス</span><span class="sxs-lookup"><span data-stu-id="15958-104">Real-Time Activity Service</span></span>

<span data-ttu-id="15958-105">リアルタイム アクティビティ (RTA) サービスにより、任意のデバイス上のアプリケーションが状態データ、ユーザー統計情報、およびプレゼンスをサブスクライブできます。</span><span class="sxs-lookup"><span data-stu-id="15958-105">The Real-Time Activity (RTA) service allows an application on any device to subscribe to state data, user statistics, and presence.</span></span> <span data-ttu-id="15958-106">それぞれのプライバシー設定に基づき、任意のタイトルに関する自分自身のデータと他のユーザーのデータをサブスクライブできます。</span><span class="sxs-lookup"><span data-stu-id="15958-106">The system allows subscriptions to one's own data and to others' data in any title based on their privacy settings.</span></span> <span data-ttu-id="15958-107">これにより、常にポーリングして最新データを取得する必要なく、情報のフローが可能になります。</span><span class="sxs-lookup"><span data-stu-id="15958-107">This allows a flow of information without having to constantly poll to get the latest data.</span></span>


## <a name="developer-scenarios"></a><span data-ttu-id="15958-108">開発者のシナリオ</span><span class="sxs-lookup"><span data-stu-id="15958-108">Developer Scenarios</span></span>

<span data-ttu-id="15958-109">RTA がサポートするシナリオは多数あります。</span><span class="sxs-lookup"><span data-stu-id="15958-109">There are many scenarios that RTA supports.</span></span> <span data-ttu-id="15958-110">ここではそれらのほんの一部を示しますが、RTA の真の実力からすれば、まだ想像したこともないようなさまざまなシナリオが考えられます。</span><span class="sxs-lookup"><span data-stu-id="15958-110">Just a few of them are listed here, but the real power of RTA is the many scenarios that you will come up with that we haven't imagined yet.</span></span> <span data-ttu-id="15958-111">ユーザーが Microsoft Surface や Apple iPad を手にしながらコンソール タイトルを操作するような、次世代のゲームプレイを定義できるかもしれません。</span><span class="sxs-lookup"><span data-stu-id="15958-111">You could help define the next generation of gameplay where users often have at hand their Microsoft Surface or Apple iPad while they're interacting with your console title.</span></span> <span data-ttu-id="15958-112">RTA では WebSocket テクノロジーが使用されるため、各種サブトピックのチュートリアルには、Windows で提供されている WebSocket API を使用する実装の概要が含まれます。</span><span class="sxs-lookup"><span data-stu-id="15958-112">RTA uses WebSocket technology, so the various subtopic walkthroughs includes an overview of the implementation using the WebSockets API provided by Windows.</span></span>

<span data-ttu-id="15958-113">タイトルでの RTA の使用例として考えられるいくつかの単純なシナリオを以下に示します。</span><span class="sxs-lookup"><span data-stu-id="15958-113">The following are some simple scenarios that you can create for your title by using RTA:</span></span>

-   <span data-ttu-id="15958-114">実績の進行状況アプリケーション</span><span class="sxs-lookup"><span data-stu-id="15958-114">Achievements progress app</span></span>
-   <span data-ttu-id="15958-115">ゲーム ヘルプ アプリケーション</span><span class="sxs-lookup"><span data-stu-id="15958-115">Game help app</span></span>
-   <span data-ttu-id="15958-116">分隊ビューアー アプリケーション</span><span class="sxs-lookup"><span data-stu-id="15958-116">Squad viewer app</span></span>
-   <span data-ttu-id="15958-117">統計情報ビューアー</span><span class="sxs-lookup"><span data-stu-id="15958-117">Statistics viewer</span></span>
-   <span data-ttu-id="15958-118">プレゼンス ビューアー</span><span class="sxs-lookup"><span data-stu-id="15958-118">Presence Viewer</span></span>


## <a name="achievements-progress-app"></a><span data-ttu-id="15958-119">実績の進行状況アプリケーション</span><span class="sxs-lookup"><span data-stu-id="15958-119">Achievements progress app</span></span>

<span data-ttu-id="15958-120">ユーザーは、ほぼ常に、特定の実績を達成するまでの進行状況を知りたがっています。あるアクションを一定回数実行する必要がある実績については特にそうです。</span><span class="sxs-lookup"><span data-stu-id="15958-120">Users are nearly always curious about their progress towards certain achievements, especially achievements that require performing an action a certain number of times.</span></span> <span data-ttu-id="15958-121">ユーザーの統計情報 (Xbox Live プレイヤー統計サービスで集計される) にリアルタイムでアクセスすることにより、ユーザーがタイトルをプレイしているときに、Xbox One またはコンパニオン デバイス上に各プレイヤーとフレンドの実績やマイルストーン達成までの進行状況をリアルタイムで表示できます。</span><span class="sxs-lookup"><span data-stu-id="15958-121">With real-time access to a user's statistics (which are aggregated in the Xbox Live Player Statistics service), you can present real-time progress for players and their friends towards achievements and milestones, on Xbox One or on a companion device, while the user is playing your title.</span></span>


## <a name="game-help-app"></a><span data-ttu-id="15958-122">ゲーム ヘルプ アプリケーション</span><span class="sxs-lookup"><span data-stu-id="15958-122">Game help app</span></span>

<span data-ttu-id="15958-123">ユーザーがタイトル内を移動するときに、リアルタイムでデータにアクセスすることにより、Xbox One での体験の横または任意のコンパニオン デバイス上にゲーム ヘルプを表示できます。</span><span class="sxs-lookup"><span data-stu-id="15958-123">As users navigate through your title, real-time access to data allows you to present game help either next to the experience on Xbox One or on any companion device.</span></span> <span data-ttu-id="15958-124">ユーザーが新しいマップ、新しいトラック、または困難なボスとの戦いに挑む場合に、ゲーム ヘルプ コンパニオンで、ユーザーまたはデベロッパーが作成したビデオやテキストを表示して、ユーザーがタイトルでの体験を克服する手助けをすることができます。</span><span class="sxs-lookup"><span data-stu-id="15958-124">Users might come up to a new map, new track, or challenging boss fight, and your Game Help companion could display user-generated or developer-generated videos and text to help the user through the experience in your title.</span></span>


## <a name="squad-viewer-app"></a><span data-ttu-id="15958-125">分隊ビューアー アプリケーション</span><span class="sxs-lookup"><span data-stu-id="15958-125">Squad viewer app</span></span>

<span data-ttu-id="15958-126">協力型マルチプレイヤー ゲームでは、プレイヤーとチームメイトは共通の目標に向かって協力します。</span><span class="sxs-lookup"><span data-stu-id="15958-126">In co-op multiplayer games, a player and his or her teammates work together for a shared goal.</span></span> <span data-ttu-id="15958-127">多数のプレイヤーがいると、全体象を把握することが難しい場合があります。</span><span class="sxs-lookup"><span data-stu-id="15958-127">With so many players, it can be hard to keep track of the bigger picture.</span></span> <span data-ttu-id="15958-128">リアルタイム データにアクセスすることにより、高い視点からのマップや、アクションの場所を示すヒート マップを表示するコンパニオン アプリケーションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="15958-128">With access to real-time data, you could create a companion app that shows the high-level map and heat maps of where the action might be.</span></span>


## <a name="statistics-viewer"></a><span data-ttu-id="15958-129">統計情報ビューアー</span><span class="sxs-lookup"><span data-stu-id="15958-129">Statistics viewer</span></span>

<span data-ttu-id="15958-130">RTA について考えるときはコンパニオン アプリケーションを念頭に置くのが一般的ですが、コア タイトルで RTA を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="15958-130">While it's typical to think of companion apps when thinking about RTA, you can also use RTA in your core title.</span></span> <span data-ttu-id="15958-131">たとえば、RTA を使用すると、マルチプレイヤー ゲームのプレイヤーは、マルチプレイヤー マッチ中にコントローラーのビュー ボタンを押すだけで、ゲーム内の全員の現在の統計情報を表示できます。</span><span class="sxs-lookup"><span data-stu-id="15958-131">For example, you can use RTA to provide a player of a multiplayer game with a display of everyone's current statistics within the game, perhaps by the player simply pressing the View button on the controller while in the multiplayer match.</span></span>


## <a name="presence-viewer"></a><span data-ttu-id="15958-132">プレゼンス ビューアー</span><span class="sxs-lookup"><span data-stu-id="15958-132">Presence Viewer</span></span>

<span data-ttu-id="15958-133">ロビーにいるときに、どのフレンドがオンラインか、彼らが同じタイトルをプレイしているかどうかについて最新情報を表示するのに便利です。</span><span class="sxs-lookup"><span data-stu-id="15958-133">When in a lobby, it's useful to have an up-to-date view of which friends are online and if they are playing the same title.</span></span> <span data-ttu-id="15958-134">ユーザーのフレンドのプレゼンスをサブスクライブし、どのフレンドがオンライン状態か、彼らがタイトルのプレイを開始するかどうかを、すべてリアルタイムで示すことができます。</span><span class="sxs-lookup"><span data-stu-id="15958-134">You can subscribe to a user's friends' presence and show which friends are coming online, if they start playing your title, all in real-time.</span></span>


## <a name="subscription-privacy-and-authorization"></a><span data-ttu-id="15958-135">サブスクリプションのプライバシーと認証</span><span class="sxs-lookup"><span data-stu-id="15958-135">Subscription privacy and authorization</span></span>

<span data-ttu-id="15958-136">RTA の最新バージョンには、プライバシー チェックおよび認証/コンテンツの分離チェックが含まれています。</span><span class="sxs-lookup"><span data-stu-id="15958-136">The latest version of RTA includes checks for privacy and authorization/content isolation.</span></span> <span data-ttu-id="15958-137">プライバシー チェックと認証チェックに適合すれば、RTA 対応としてマークされているすべての統計情報をアプリケーションでサブスクライブできます </span><span class="sxs-lookup"><span data-stu-id="15958-137">As long as privacy and authorization checks are satisfied, your app can subscribe to any statistic that is marked as RTA-enabled.</span></span> <span data-ttu-id="15958-138">(統計情報を RTA 対応にする方法の詳細については、[「統計情報通知の登録](register-for-stat-notifications.md)」を参照してください)。</span><span class="sxs-lookup"><span data-stu-id="15958-138">(For more information on how to make a statistic RTA-enabled, see [Register for stat notifications](register-for-stat-notifications.md).</span></span> <span data-ttu-id="15958-139">RTA 対応にできる統計情報の種類に関する制限はありません。デベロッパーが自由に決めることができます。</span><span class="sxs-lookup"><span data-stu-id="15958-139">There are no limitations on the kinds of statistics that can be made RTA-enabled—it's up to you, the developer.</span></span> <span data-ttu-id="15958-140">ただし、アプリ セッションごとにユーザーがサブスクライブできる統計情報の*数*には制限があります。</span><span class="sxs-lookup"><span data-stu-id="15958-140">However, there is a limit to the *number* of statistics that a user can subscribe to per app session.</span></span> <span data-ttu-id="15958-141">ユーザーは、その制限に到達すると、その次のサブスクリプションでエラーを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="15958-141">If a user reaches that limit, he or she will receive an error on the next subscription.</span></span>


## <a name="in-this-section"></a><span data-ttu-id="15958-142">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="15958-142">In this section</span></span>

[<span data-ttu-id="15958-143">プレイヤー統計情報の変更通知の登録</span><span class="sxs-lookup"><span data-stu-id="15958-143">Register for player stat change notifications</span></span>](register-for-stat-notifications.md)  
<span data-ttu-id="15958-144">統計または状態情報のリアルタイム アクティビティ (RTA) を有効にする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="15958-144">Describes how to enable Real-Time Activity (RTA) for statistics or state information.</span></span>

[<span data-ttu-id="15958-145">WinRT API を使用したリアルタイム アクティビティ サービスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="15958-145">Programming the Real-Time Activity (rta) service using winrt apis</span></span>](programming-the-real-time-activity-service.md)  
<span data-ttu-id="15958-146">WinRT API を使用してリアルタイム アクティビティ (RTA) サービスをプログラミングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="15958-146">Describes how to program the Real-Time Activity (RTA) service using WinRT APIs.</span></span>

[<span data-ttu-id="15958-147">RESTful インターフェイスを使用したリアルタイム アクティビティ (RTA) サービスのプログラミング</span><span class="sxs-lookup"><span data-stu-id="15958-147">Programming the Real-Time Activity (rta) service using the restful interface</span></span>](programming-the-real-time-activity-service.md)  
<span data-ttu-id="15958-148">RESTful インターフェイスを使用してリアルタイム アクティビティ (RTA) サービスをプログラミングする方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="15958-148">Describes how to program the Real-Time Activity (RTA) service using the RESTful interface.</span></span>

[<span data-ttu-id="15958-149">リアルタイム アクティビティ (RTA) のベスト プラクティス</span><span class="sxs-lookup"><span data-stu-id="15958-149">Real Time Activity (rta) best practices</span></span>](rta-best-practices.md)  
<span data-ttu-id="15958-150">Xbox サービスのリアルタイム アクティビティ (RTA) サービスを使用して Xbox データ プラットフォームから統計情報および状態データをサブスクライブする場合のベスト プラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="15958-150">Best practices for using the Xbox services Real Time Activity (RTA) service to subscribe to statistics and state data from the Xbox data platform.</span></span>
