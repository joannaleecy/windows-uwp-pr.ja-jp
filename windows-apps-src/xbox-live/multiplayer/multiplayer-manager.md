---
title: Multiplayer Manager
author: KevinAsgari
description: Xbox Live Multiplayer Manager について説明します。これは、マルチプレイヤーを簡単に実装できるように設計された高レベルの API です。
ms.assetid: f3a6c8bc-4f73-4b99-ac51-aadee73c8cfa
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: bf931a2811a9a627c40a7dc45178688236437fa8
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4262333"
---
# <a name="multiplayer-manager"></a><span data-ttu-id="c065e-104">Multiplayer Manager</span><span class="sxs-lookup"><span data-stu-id="c065e-104">Multiplayer Manager</span></span>

<span data-ttu-id="c065e-105">Xbox Live は、タイトルにマルチプレイヤー機能を追加するための広範なサポートを提供し、ゲームで世界中の Xbox Live メンバーを接続できるようにします。</span><span class="sxs-lookup"><span data-stu-id="c065e-105">Xbox Live provides extensive support for adding multiplayer functionality to your titles, allowing your game to connect Xbox Live members across the world.</span></span>  <span data-ttu-id="c065e-106">これには、多様なマッチメイキング シナリオや、進行中のフレンドのゲームにプレイヤーが参加する機能などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c065e-106">This includes rich matchmaking scenarios, the ability for a player to join a friend's game in progress, and more.</span></span> <span data-ttu-id="c065e-107">ただし、マルチプレイヤー 2015 API を直接使用して Xbox Live マルチプレイヤーを実装することは複雑な作業になる可能性があります。ベスト プラクティスに従い認定要件を満たしていることを確認するために、多くの設計とテストが必要になります。</span><span class="sxs-lookup"><span data-stu-id="c065e-107">However, implementing Xbox Live multiplayer by using the Multiplayer 2015 APIs directly can be a complex task, requiring a large degree of design and testing to verify that you are following the best practices, and meeting certification requirements.</span></span>

<span data-ttu-id="c065e-108">Multiplayer Manager を使用すると、セッションとマッチメイキングを管理し、状態とイベントに基づくプログラミング モデルの提供により、ゲームにマルチプレイヤー機能を簡単に追加できます。</span><span class="sxs-lookup"><span data-stu-id="c065e-108">Multiplayer Manager makes it easy to add multiplayer functionality to your game by managing sessions and matchmaking, and by providing a state and event based programming model.</span></span> <span data-ttu-id="c065e-109">Multiplayer Manager は、Xbox Live ゲーム向けのマルチプレイヤー シナリオの実装を容易にするために設計された一連の API です。</span><span class="sxs-lookup"><span data-stu-id="c065e-109">It is a set of APIs designed to make it easy to implement multiplayer scenarios for your Xbox Live game.</span></span> <span data-ttu-id="c065e-110">Multiplayer Manager では、フレンドとのマルチプレイヤー ゲームのプレイ、ゲームへの招待の処理、途中参加の処理、マッチメイキングなどの一般的なマルチプレイヤー シナリオを念頭に置いて設計された API が提供されます。</span><span class="sxs-lookup"><span data-stu-id="c065e-110">It provides an API that is oriented around common multiplayer scenarios such as playing multiplayer games with friends, handling game invites, handling join in progress, matchmaking, and more.</span></span> <span data-ttu-id="c065e-111">複数のローカル ユーザーがサポートされ、サードパーティーのマッチメイキング サービスを使用する場合には、タイトルを容易にマルチプレイヤー セッション ディレクトリと統合できます。</span><span class="sxs-lookup"><span data-stu-id="c065e-111">It supports multiple local users and makes it easier for your title to integrate with Multiplayer Session Directory if you are using a third party matchmaking service.</span></span> <span data-ttu-id="c065e-112">これらのシナリオの多くは、わずか数回の API 呼び出しで実現できます。</span><span class="sxs-lookup"><span data-stu-id="c065e-112">Many of these scenarios can be accomplished with just a few API calls.</span></span>

## <a name="key-features"></a><span data-ttu-id="c065e-113">主な機能</span><span class="sxs-lookup"><span data-stu-id="c065e-113">Key Features</span></span>
<span data-ttu-id="c065e-114">Multiplayer Manager API の主な機能を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c065e-114">These are the main features of the Multiplayer Manager API:</span></span>

* <span data-ttu-id="c065e-115">容易なセッション管理と Xbox Live マッチメイキング</span><span class="sxs-lookup"><span data-stu-id="c065e-115">Easy session management and Xbox Live Matchmaking</span></span>
* <span data-ttu-id="c065e-116">状態とイベントに基づくプログラミング モデル</span><span class="sxs-lookup"><span data-stu-id="c065e-116">State and event based programming model.</span></span>
* <span data-ttu-id="c065e-117">Xbox Live のベスト プラクティスの確保およびマルチプレイヤーの XR 準拠</span><span class="sxs-lookup"><span data-stu-id="c065e-117">Ensures Xbox Live Best Practices  along with being Multiplayer XR compliant.</span></span>
* <span data-ttu-id="c065e-118">Xbox One XDK および UWP タイトルのサポート</span><span class="sxs-lookup"><span data-stu-id="c065e-118">Supports both Xbox One XDK and UWP titles.</span></span>
* <span data-ttu-id="c065e-119">[マルチプレイヤー 2015 のフローチャート](https://developer.xboxlive.com/en-us/platform/development/education/Documents/Xbox%20One%20Multiplayer%202015%20Developer%20Flowcharts.aspx)の実装</span><span class="sxs-lookup"><span data-stu-id="c065e-119">Implements [Multiplayer 2015 flowcharts](https://developer.xboxlive.com/en-us/platform/development/education/Documents/Xbox%20One%20Multiplayer%202015%20Developer%20Flowcharts.aspx).</span></span>
* <span data-ttu-id="c065e-120">従来のマルチプレイヤー 2015 API との共存</span><span class="sxs-lookup"><span data-stu-id="c065e-120">Works alongside the traditional Multiplayer 2015 APIs.</span></span>

><span data-ttu-id="c065e-121">**重要**: 認定に合格するためには、オンライン マルチプレイヤーのために必要なイベントをゲームに実装する必要があることに変更はありません。</span><span class="sxs-lookup"><span data-stu-id="c065e-121">**Important** - Your game must still implement required events for online multiplayer in order to pass certification.</span></span>

## <a name="overview"></a><span data-ttu-id="c065e-122">概要</span><span class="sxs-lookup"><span data-stu-id="c065e-122">Overview</span></span>
<span data-ttu-id="c065e-123">Multiplayer Manager には、いくつかの重要な概念があります。</span><span class="sxs-lookup"><span data-stu-id="c065e-123">Multiplayer Manager is oriented around a few key concepts:</span></span>
* `lobby_session` <span data-ttu-id="c065e-124">: このデバイスに対してローカルなユーザーと、ゲームに招待したフレンドを管理するために使用する永続的なセッションです。</span><span class="sxs-lookup"><span data-stu-id="c065e-124">: A persistent session used for managing users that are local to this device and your invited friends that wish to play together.</span></span> <span data-ttu-id="c065e-125">グループは、ゲームの複数のラウンドやマップ、レベルなどをプレイすることがあり、ロビー セッションがこのフレンドのコア グループ (デバイスにローカルのプレイヤーを含む) を追跡します。</span><span class="sxs-lookup"><span data-stu-id="c065e-125">The group may play multiple rounds, maps, levels, etc., of the game, and the lobby session tracks this core group of friends (including players local to the device).</span></span> <span data-ttu-id="c065e-126">一般に、このグループは、ホストがメニューを移動し、グループ メンバーとチャットしてどのゲーム モードをプレイするかを決めるときに形成されます。</span><span class="sxs-lookup"><span data-stu-id="c065e-126">Typically, this group is formed while the host may be navigating through the menus, chatting with the group members to decide what game mode they want to play.</span></span>

* `game_session` <span data-ttu-id="c065e-127">: ゲームの特定のインスタンスをプレイしているプレイヤーを追跡します。</span><span class="sxs-lookup"><span data-stu-id="c065e-127">: Tracks players who are playing a specific instance of the game.</span></span> <span data-ttu-id="c065e-128">たとえば、レース、マップ、レベルです。</span><span class="sxs-lookup"><span data-stu-id="c065e-128">For example, a race, map, or level.</span></span> <span data-ttu-id="c065e-129">ロビー セッションのメンバーが含まれる `join_game_from_lobby` で新しいゲーム セッションを作成できます。</span><span class="sxs-lookup"><span data-stu-id="c065e-129">You can create a new game session via `join_game_from_lobby` that includes the members in the lobby session.</span></span>  <span data-ttu-id="c065e-130">メンバーが招待を受け入れると、メンバーはロビーおよびゲーム セッションに追加されます (空きがある場合)。</span><span class="sxs-lookup"><span data-stu-id="c065e-130">When a member accepts an invite, they will be added to the lobby and the game session (if there is room).</span></span> <span data-ttu-id="c065e-131">マッチメイキングが有効になっている場合はゲーム セッションに他のプレイヤーを追加できますが、それらの追加プレイヤーはロビー セッションには追加されません。</span><span class="sxs-lookup"><span data-stu-id="c065e-131">Additional players may be added to the game session if matchmaking is enabled, but those additional players are not added to the lobby session.</span></span> <span data-ttu-id="c065e-132">これは、ゲームが終了すると、ロビー セッション内のプレイヤーはまだ一緒にいますが、マッチメイキングからの追加プレイヤーはそうではないことを意味します。</span><span class="sxs-lookup"><span data-stu-id="c065e-132">This means that once the game ends, the players in the lobby session are still together, while the extra players from matchmaking are not.</span></span>

* `multiplayer_member` <span data-ttu-id="c065e-133">: ローカルまたはリモート デバイスにサインインしている個々のユーザーを表します。</span><span class="sxs-lookup"><span data-stu-id="c065e-133">: Represents an individual user signed in on a local or remote device.</span></span>

* `do_work` <span data-ttu-id="c065e-134">: タイトルと Xbox Live マルチプレイヤー サービスとの間で適切なゲームの状態の更新が維持されるようにします。</span><span class="sxs-lookup"><span data-stu-id="c065e-134">: Ensures proper game state updates are maintained between the title and the Xbox Live Multiplayer Service.</span></span> <span data-ttu-id="c065e-135">最適なパフォーマンスを得るには、do_work() を頻繁に呼び出す必要があります (フレームごとに 1 回 など)。</span><span class="sxs-lookup"><span data-stu-id="c065e-135">To ensure best performance, do_work() must be called frequently, such as once per frame.</span></span> <span data-ttu-id="c065e-136">do_work() は、ゲームで処理する `multiplayer_event` コールバック イベントのリストを提供します。</span><span class="sxs-lookup"><span data-stu-id="c065e-136">It provides you with a list of `multiplayer_event` callback events for the game to handle.</span></span>

## <a name="state-machine"></a><span data-ttu-id="c065e-137">ステート マシン</span><span class="sxs-lookup"><span data-stu-id="c065e-137">State Machine</span></span>
<span data-ttu-id="c065e-138">`do_work()` 呼び出しは、状態を最新に維持するために必要です。</span><span class="sxs-lookup"><span data-stu-id="c065e-138">The `do_work()` call is necessary to ensure your state is kept fresh.</span></span>  <span data-ttu-id="c065e-139">Multiplayer Manager が機能するためには、デベロッパーが `do_work()` メソッドを定期的に呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="c065e-139">For Multiplayer Manager to do its work, developers must call the `do_work()` method regularly.</span></span> <span data-ttu-id="c065e-140">これを行う最も信頼性の高い方法は、フレームごとに少なくとも 1 回呼び出すことです。</span><span class="sxs-lookup"><span data-stu-id="c065e-140">The most reliable way to do this is to call at least once per frame.</span></span> `do_work()` <span data-ttu-id="c065e-141">で実行する作業がないと迅速に制御が戻るため、呼び出しの頻度が多すぎることについて心配する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="c065e-141">returns quickly when it has no work to do, so there is no reason for concern about calling it too often.</span></span>

<span data-ttu-id="c065e-142">Multiplayer Manager API によって返されるすべてのオブジェクトがスレッドセーフであるとは見なさないでください。</span><span class="sxs-lookup"><span data-stu-id="c065e-142">All objects returned by the Multiplayer Manager API should not be considered thread-safe.</span></span> <span data-ttu-id="c065e-143">ただし、複数のスレッドから呼び出す場合は、スレッドの同期の実行を制御できます。</span><span class="sxs-lookup"><span data-stu-id="c065e-143">However, it gives you control to do thread synchronization if you are calling it from multiple threads.</span></span> <span data-ttu-id="c065e-144">ライブラリには内部的なマルチスレッド保護機能がありますが、別のスレッドが `do_work()` を呼び出している可能性がある間に、あるスレッドで任意の値にアクセスする必要がある場合は (たとえば、members() リストの処理)、独自のロック処理を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c065e-144">The library has internal multithreading protection, but you will still need to implement your own locking if you require one thread to access any values – for example, walking the members() list while another thread might be invoking `do_work()`.</span></span>

<span data-ttu-id="c065e-145">Multiplayer Manager は、状態に基づくモデルを管理し、プレイヤーの参加、退出、またはセッションの更新が発生するとバックグラウンドでセッションを更新します。</span><span class="sxs-lookup"><span data-stu-id="c065e-145">Multiplayer Manager maintains a state based model updating the sessions in the background as players join, leave, or are when sessions are updated.</span></span> <span data-ttu-id="c065e-146">UI スレッドとゲーム スレッドの間でスレッド同期の問題が発生しないようにするため、Multiplayer Manager は `do_work()` メソッドが呼び出されるまで、アプリのセッションの表示状態を更新しません。</span><span class="sxs-lookup"><span data-stu-id="c065e-146">In order to help avoid thread synchronization problems between the UI thread and your game thread, Multiplayer Manager does not update the app visible state of the sessions until you call the `do_work()` method.</span></span> <span data-ttu-id="c065e-147">従来は、セッションの変更などのイベントに関する通知をバックグラウンド スレッドで受信してから UI スレッドと同期し、それらの変更を表示する必要がありました。</span><span class="sxs-lookup"><span data-stu-id="c065e-147">Traditionally you would receive notifications about events such as session changes on a background thread, and then have to synchronize it with a UI thread to display these changes.</span></span> <span data-ttu-id="c065e-148">Multiplayer Manager では、この処理は自動的に行われます。</span><span class="sxs-lookup"><span data-stu-id="c065e-148">With Multiplayer Manager, this work is done for you behind the scenes.</span></span>  <span data-ttu-id="c065e-149">必要なときにメイン スレッドで `do_work()` を呼び出して、Multiplayer Manager が自動的にバッファーリングしている、状態の最新スナップショットを取得できます。</span><span class="sxs-lookup"><span data-stu-id="c065e-149">You can call `do_work()` on your main thread at the time of your choosing, to get the latest snapshot of the state which Multiplayer Manager is buffering for you behind the scenes.</span></span>

## <a name="events-and-notifications"></a><span data-ttu-id="c065e-150">イベントと通知</span><span class="sxs-lookup"><span data-stu-id="c065e-150">Events and Notifications</span></span>
<span data-ttu-id="c065e-151">Multiplayer Manager は、重要なイベント (`multiplayer_event_type` を参照) のセットを定義し、イベントの発生時に `do_work()` メソッドを通じてタイトルに通知します </span><span class="sxs-lookup"><span data-stu-id="c065e-151">Multiplayer Manager defines a set of significant events (see `multiplayer_event_type`) and notifies the title via the `do_work()` method when they happen.</span></span> <span data-ttu-id="c065e-152">(リモート プレーヤーの参加または退出、メンバーのプロパティ変更、セッション状態の変更などのイベント)。</span><span class="sxs-lookup"><span data-stu-id="c065e-152">Events such as remote players joining or leaving, member properties changing, or session state changing.</span></span> <span data-ttu-id="c065e-153">すべての Multiplayer Manager API は同期的です。</span><span class="sxs-lookup"><span data-stu-id="c065e-153">All Multiplayer Manager APIs are synchronous.</span></span> <span data-ttu-id="c065e-154">`do_work()` メソッドは、非同期操作が完了したときにイベントのリストを返します。</span><span class="sxs-lookup"><span data-stu-id="c065e-154">The `do_work()` method returns a list of events when these asynchronous operations are completed.</span></span> <span data-ttu-id="c065e-155">タイトルはこれらのイベントを適切に処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c065e-155">Your title should handle these events as you see appropriate.</span></span> <span data-ttu-id="c065e-156">詳しくは、`multiplayer_event` クラスのドキュメントをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c065e-156">Please see the `multiplayer_event` class documentation for more details.</span></span>

<span data-ttu-id="c065e-157">イベントごとに、イベント タイプに応じて `event_args` を適切なイベント引数クラスにキャストし、イベントのプロパティを取得する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c065e-157">For each event, depending on the event type, you must cast the `event_args` to the appropriate event arg class to get the event properties.</span></span> <span data-ttu-id="c065e-158">次の例は、`do_work()` を使用したイベントの処理を示しています。</span><span class="sxs-lookup"><span data-stu-id="c065e-158">The following example demonstrates using `do_work()` to handle events:</span></span>

```cpp
auto eventQueue = mpInstance.do_work();
for (auto& event : eventQueue)
{
    switch (event.event_type())
    {
      case multiplayer_event_type::member_joined:
      {
        auto memberJoinedArgs =  std::dynamic_pointer_cast<member_joined_event_args>(event.event_args());
        HandleMemberJoined(memberJoinedArgs);
        break;
      }
      case multiplayer_event_type::session_property_changed:
      {
        auto sessionPropertyChangedArgs =  std::dynamic_pointer_cast<session_property_changed_event_args>(event.event_args());
        HandlePropertiesChanged(sessionPropertyChangedArgs);
        break;
      }
      . . .
    }
}

```

## <a name="scenarios"></a><span data-ttu-id="c065e-159">シナリオ</span><span class="sxs-lookup"><span data-stu-id="c065e-159">Scenarios</span></span>

<span data-ttu-id="c065e-160">このセクションでは、いくつかの一般的なシナリオと、各シナリオで呼び出すことがある API を紹介します。</span><span class="sxs-lookup"><span data-stu-id="c065e-160">In this section we will go through some common scenarios, and the APIs you would call in each scenario.</span></span>  <span data-ttu-id="c065e-161">Multiplayer Manager がバックグラウンドで行っていることについても説明しています。</span><span class="sxs-lookup"><span data-stu-id="c065e-161">Some information on what Multiplayer Manager is doing behind the scenes is also provided.</span></span>

* [<span data-ttu-id="c065e-162">フレンドとのプレイ</span><span class="sxs-lookup"><span data-stu-id="c065e-162">Play with friends</span></span>](multiplayer-manager/play-multiplayer-with-friends.md)
* [<span data-ttu-id="c065e-163">マッチを探す</span><span class="sxs-lookup"><span data-stu-id="c065e-163">Find a match</span></span>](multiplayer-manager/play-multiplayer-with-matchmaking.md)
* [<span data-ttu-id="c065e-164">ゲームへの招待を送信する</span><span class="sxs-lookup"><span data-stu-id="c065e-164">Send game invites</span></span>](multiplayer-manager/send-game-invites.md)
* [<span data-ttu-id="c065e-165">プロトコルのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="c065e-165">Handle protocol activation</span></span>](multiplayer-manager/handle-protocol-activation.md)

<span data-ttu-id="c065e-166">API の概要については、「[Multiplayer Manager API の概要](multiplayer-manager/multiplayer-manager-api-overview.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c065e-166">A high level overview of the API can be found at [Multiplayer Manager API overview](multiplayer-manager/multiplayer-manager-api-overview.md).</span></span>

## <a name="what-multiplayer-manager-does-not-do"></a><span data-ttu-id="c065e-167">Multiplayer Manager でサポートされないこと</span><span class="sxs-lookup"><span data-stu-id="c065e-167">What Multiplayer Manager does not do</span></span>
<span data-ttu-id="c065e-168">Multiplayer Manager によってマルチプレイヤー シナリオの実装は大幅に容易になり、デベロッパーからのデータの一部が抽象化されますが、処理できないことや、適していないことがいくつかあります。</span><span class="sxs-lookup"><span data-stu-id="c065e-168">While Multiplayer Manager makes it much easier to implement multiplayer scenarios and abstracts some  of the data from the developer, there are a few things it does not handle, or is not best suited for.</span></span>

* <span data-ttu-id="c065e-169">大規模な (1 セッション内のプレイヤー数が 100 人を超える) セッションを必要とする、MMO やその他の種類のゲームのような、永続的なオンライン サーバー ゲーム。</span><span class="sxs-lookup"><span data-stu-id="c065e-169">Persistent online server games, such as MMOs, or other game types that require large sessions (over 100 players in a session).</span></span>
* <span data-ttu-id="c065e-170">サーバー間のセッション管理。</span><span class="sxs-lookup"><span data-stu-id="c065e-170">Server to server session management</span></span>

><span data-ttu-id="c065e-171">Multiplayer Manager は特定のネットワーク技術に縛られず、どのネットワーク レイヤーでも機能する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c065e-171">Multiplayer Manager is not tied to any specific network technology, and should work with any network layer.</span></span>

## <a name="next-steps"></a><span data-ttu-id="c065e-172">次の手順</span><span class="sxs-lookup"><span data-stu-id="c065e-172">Next Steps</span></span>

<span data-ttu-id="c065e-173">動作する API の例については、C++ または WinRT いずれかの *Multiplayer* サンプルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c065e-173">Please see either the C++ or WinRT *Multiplayer* sample for a working example of the API.</span></span>

<span data-ttu-id="c065e-174">API ドキュメントは、Microsoft::Xbox::Services::Multiplayer::Manager 名前空間の C++ ガイドまたは WinRT ガイドにあります。</span><span class="sxs-lookup"><span data-stu-id="c065e-174">The API documentation can be found in the C++ or WinRT guides in the Microsoft::Xbox::Services::Multiplayer::Manager namespace.</span></span>  <span data-ttu-id="c065e-175">`multiplayer_manager.h` ヘッダーもご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c065e-175">You can also see the `multiplayer_manager.h` header.</span></span>

<span data-ttu-id="c065e-176">に関する質問やフィードバック、または Multiplayer Manager を使用して問題が発生した場合ください、担当の DAM に問い合わせてまたはフォーラムでサポート スレッドを投稿[https://forums.xboxlive.com](https://forums.xboxlive.com)します。</span><span class="sxs-lookup"><span data-stu-id="c065e-176">If you have any questions, feedback, or run into any issues using the Multiplayer Manager, please contact your DAM or post a support thread on the forums at [https://forums.xboxlive.com](https://forums.xboxlive.com).</span></span>
