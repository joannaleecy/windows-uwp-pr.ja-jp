---
title: マルチプレイヤー ゲームをフレンドとプレイする
author: KevinAsgari
description: Xbox Live Multiplayer Manager を使用して、プレイヤーがフレンドとマルチプレイヤー ゲームをプレイできるようにする方法について説明します。
ms.assetid: 6eefee0e-6c0d-473a-97e7-f3e45f574712
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, Multiplayer Manager, フローチャート
ms.localizationpriority: medium
ms.openlocfilehash: 7a1023fdfd564013549a7445875af9cb06af3f11
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4266514"
---
# <a name="play-a-multiplayer-game-with-friends"></a><span data-ttu-id="ea259-104">マルチプレイヤー ゲームをフレンドとプレイする</span><span class="sxs-lookup"><span data-stu-id="ea259-104">Play a multiplayer game with friends</span></span>

<span data-ttu-id="ea259-105">簡単なマルチプレイヤー シナリオの 1 つは、ゲーマーにフレンドとのオンラインでのゲーム プレイを許可することです。</span><span class="sxs-lookup"><span data-stu-id="ea259-105">One of the simpler multiplayer scenarios is to allow a gamer to play your game online with friends.</span></span> <span data-ttu-id="ea259-106">このシナリオでは、Multiplayer Manager を使用して実装するために必要な基本手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="ea259-106">This scenario covers the basic steps you need to implement by using Multiplayer Manager.</span></span>

## <a name="inviting-friends"></a><span data-ttu-id="ea259-107">フレンドの招待</span><span class="sxs-lookup"><span data-stu-id="ea259-107">Inviting friends</span></span>

<span data-ttu-id="ea259-108">Multiplayer Manager を使用してユーザーのフレンドに招待を送信し、そのフレンドがゲームに途中参加するときの処理は 4 つのステップからなります。</span><span class="sxs-lookup"><span data-stu-id="ea259-108">There are four steps involved when using the Multiplayer Manager to send an invite to a user's friend, and then for that friend to join the game in progress:</span></span>

1. [<span data-ttu-id="ea259-109">Multiplayer Manager を初期化する</span><span class="sxs-lookup"><span data-stu-id="ea259-109">Initialize Multiplayer Manager</span></span>](#initialize-multiplayer-manager)
2. [<span data-ttu-id="ea259-110">ローカル ユーザーを追加することでロビー セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="ea259-110">Create the lobby session by adding local users</span></span>](#create-lobby)
3. [<span data-ttu-id="ea259-111">フレンドに招待を送信する</span><span class="sxs-lookup"><span data-stu-id="ea259-111">Send invites to friends</span></span>](#send-invites)
4. [<span data-ttu-id="ea259-112">招待を受け入れる</span><span class="sxs-lookup"><span data-stu-id="ea259-112">Accept invites</span></span>](#accept-invites)
5. [<span data-ttu-id="ea259-113">ロビーからゲーム セッションに参加する</span><span class="sxs-lookup"><span data-stu-id="ea259-113">Join a game session from the lobby</span></span>](#join-game)

<span data-ttu-id="ea259-114">手順 1、2、3、5 は、招待を実行したデバイス上で行います。</span><span class="sxs-lookup"><span data-stu-id="ea259-114">Steps 1, 2, 3, and 5 are done on the device performing the invite.</span></span>  <span data-ttu-id="ea259-115">手順 4 は通常、プロトコルのアクティブ化によるアプリ起動の後、招待されたユーザーのマシンで開始されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-115">Step 4 would typically be initiated on the invitee's machine following app launch via protocol activation.</span></span>

<span data-ttu-id="ea259-116">プロセスのフローチャートについては、「[フローチャート - フレンドとマルチプレイヤー/協力型ゲームをプレイする](mpm-flowcharts/mpm-play-with-friends.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="ea259-116">You can see a flowchart of the process here: [Flowchart - Play a multiplayer/co-op game with friends](mpm-flowcharts/mpm-play-with-friends.md).</span></span>

### <a name="1-initialize-multiplayer-manager-a-nameinitialize-multiplayer-manager"></a><span data-ttu-id="ea259-117">1) Multiplayer Manager を初期化する <a name="initialize-multiplayer-manager"></span><span class="sxs-lookup"><span data-stu-id="ea259-117">1) Initialize Multiplayer Manager <a name="initialize-multiplayer-manager"></span></span>

| <span data-ttu-id="ea259-118">呼び出し</span><span class="sxs-lookup"><span data-stu-id="ea259-118">Call</span></span> | <span data-ttu-id="ea259-119">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="ea259-119">Event triggered</span></span> |
|-----|----------------|
| `multiplayer_manager::initialize(lobbySessionTemplateName)` | <span data-ttu-id="ea259-120">該当なし</span><span class="sxs-lookup"><span data-stu-id="ea259-120">N/A</span></span> |

<span data-ttu-id="ea259-121">(サービス構成で構成される) 有効なセッション テンプレート名が指定されていることを前提に、Multiplayer Manager の初期化時にロビー セッション オブジェクトが自動的に作成されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-121">The lobby session object is automatically created upon initializing the Multiplayer Manager, assuming that a valid session template name (configured in the service configuration) is specified.</span></span> <span data-ttu-id="ea259-122">このとき、サービスでロビー セッション インスタンスが作成されるわけではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="ea259-122">Note that this does not create the lobby session instance on the service.</span></span>

**<span data-ttu-id="ea259-123">例:</span><span class="sxs-lookup"><span data-stu-id="ea259-123">Example:</span></span>**

```cpp
auto mpInstance = multiplayer_manager::get_singleton_instance();

mpInstance->initialize(lobbySessionTemplateName);
```


### <a name="2-create-the-lobby-session-by-adding-local-usersa-namecreate-lobby"></a><span data-ttu-id="ea259-124">2) ローカル ユーザーを追加することでロビー セッションを作成する<a name="create-lobby"></span><span class="sxs-lookup"><span data-stu-id="ea259-124">2) Create the lobby session by adding local users<a name="create-lobby"></span></span>

| <span data-ttu-id="ea259-125">メソッド</span><span class="sxs-lookup"><span data-stu-id="ea259-125">Method</span></span> | <span data-ttu-id="ea259-126">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="ea259-126">Event triggered</span></span> |
|-----|----------------|
| `multiplayer_lobby_session::add_local_user()` | `user_added_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

<span data-ttu-id="ea259-127">ここでは、ローカルでサインインしている Xbox Live ユーザーをロビー セッションに追加します。</span><span class="sxs-lookup"><span data-stu-id="ea259-127">Here, you add the locally signed in Xbox Live users to the lobby session.</span></span> <span data-ttu-id="ea259-128">最初のユーザーが追加されたときに新しいロビーをホストします。</span><span class="sxs-lookup"><span data-stu-id="ea259-128">This hosts a new lobby when the first user is added.</span></span> <span data-ttu-id="ea259-129">他のすべてのユーザーについては、セカンダリー ユーザーとして既存のロビーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-129">For all other users, they will be added to the existing lobby as secondary users.</span></span> <span data-ttu-id="ea259-130">この API は、フレンドが参加するシェルのロビーも公開します。</span><span class="sxs-lookup"><span data-stu-id="ea259-130">This API will also advertise the lobby in the shell for friends to join.</span></span> <span data-ttu-id="ea259-131">招待の送信、ロビーのプロパティの設定、および lobby() を介したロビー メンバーへのアクセスは、ローカル ユーザーの追加後にのみ可能です。</span><span class="sxs-lookup"><span data-stu-id="ea259-131">You can send invites, set lobby properties, access lobby members via lobby() only once you've added the local user.</span></span>

<span data-ttu-id="ea259-132">ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ea259-132">After joining the lobby, Microsoft recommends setting the local member's connection address, as well as any custom properties for the member.</span></span>

<span data-ttu-id="ea259-133">ローカルにサインインしたすべてのユーザーに対して、このプロセスを繰り返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="ea259-133">You must repeat this process for all locally signed in users.</span></span>

**<span data-ttu-id="ea259-134">例: (1 人のローカル ユーザー)</span><span class="sxs-lookup"><span data-stu-id="ea259-134">Example: (single local user)</span></span>**

```cpp
auto mpInstance = multiplayer_manager::get_singleton_instance();

auto result = mpInstance->lobby_session()->add_local_user(xboxLiveContext->user());
if (result.err())
{
  // handle error
}

// Set member connection address
string_t connectionAddress = L"1.1.1.1";
mpInstance->lobby_session()->set_local_member_connection_address(
    xboxLiveContext->user(),
    connectionAddress);

// Set custom member properties
mpInstance->lobby_session()->set_local_member_properties(xboxLivecontext->user(), ..., ...)
```

**<span data-ttu-id="ea259-135">例: (複数のローカル ユーザー)</span><span class="sxs-lookup"><span data-stu-id="ea259-135">Example: (multiple local users)</span></span>**

```cpp
auto mpInstance = multiplayer_manager::get_singleton_instance();
string_t connectionAddress = L"1.1.1.1";

for (User^ user : User::Users)
{
  if( user->IsSignedIn )
  {
    auto result = mpInstance.lobby_session()->add_local_user(user);
    if (result.err())
    {
      // handle error
    }

    // Set member connection address
    mpInstance->lobby_session()->set_local_member_connection_address(
        xboxLiveContext->user(), connectionAddress);

    // Set custom member properties
    mpInstance->lobby_session()->set_local_member_properties(xboxLivecontext->user(), ..., ...)
  }
}

```


<span data-ttu-id="ea259-136">変更は次回の `do_work()` 呼び出しでバッチ処理されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-136">The changes are batched on the next `do_work()` call.</span></span>  
<span data-ttu-id="ea259-137">Multiplayer Manager は、ユーザーがロビー セッションに追加されるたびに `user_added` イベントを生成します。</span><span class="sxs-lookup"><span data-stu-id="ea259-137">Multiplayer manager fires a `user_added` event each time a user is added to the lobby session.</span></span> <span data-ttu-id="ea259-138">イベントのエラー コードを調べて、そのユーザーが正常に追加されたかどうかを確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ea259-138">Its recommended that you inspect the error code of the event to see if that user was successfully added.</span></span> <span data-ttu-id="ea259-139">障害が発生した場合は、障害の詳細な理由がエラー メッセージで提供されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-139">In case of a failure, an error message will be provided detailing the reasons of the failure.</span></span>

**<span data-ttu-id="ea259-140">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="ea259-140">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="ea259-141">リアルタイム アクティビティおよびマルチプレイヤーのサブスクリプションを Xbox Live マルチプレイヤー サービスに登録する</span><span class="sxs-lookup"><span data-stu-id="ea259-141">Register Real Time Activity & Multiplayer Subscriptions with the Xbox Live multiplayer service</span></span>
* <span data-ttu-id="ea259-142">ロビー セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="ea259-142">Create Lobby Session</span></span>
* <span data-ttu-id="ea259-143">すべてのローカル プレイヤーをアクティブとして参加させる</span><span class="sxs-lookup"><span data-stu-id="ea259-143">Join all local players as active</span></span>
* <span data-ttu-id="ea259-144">SDA をアップロードする</span><span class="sxs-lookup"><span data-stu-id="ea259-144">Upload SDA</span></span>
* <span data-ttu-id="ea259-145">メンバーのプロパティを設定する</span><span class="sxs-lookup"><span data-stu-id="ea259-145">Set member properties</span></span>
* <span data-ttu-id="ea259-146">セッション変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="ea259-146">Register for Session Change Events</span></span>
* <span data-ttu-id="ea259-147">ロビー セッションをアクティブ セッションとして設定する</span><span class="sxs-lookup"><span data-stu-id="ea259-147">Set Lobby Session as Active Session</span></span>

### <a name="3-send-invites-to-friends-a-namesend-invites"></a><span data-ttu-id="ea259-148">3) フレンドに招待を送信する <a name="send-invites"></span><span class="sxs-lookup"><span data-stu-id="ea259-148">3) Send invites to friends <a name="send-invites"></span></span>

| <span data-ttu-id="ea259-149">メソッド</span><span class="sxs-lookup"><span data-stu-id="ea259-149">Method</span></span> | <span data-ttu-id="ea259-150">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="ea259-150">Event triggered</span></span> |
| -----|----------------|
| `multiplayer_lobby_session::invite_friends()` | `invite_sent` |
| `multiplayer_lobby_session::invite_users()` | `invite_sent` |

<span data-ttu-id="ea259-151">次に、フレンド招待用の標準 Xbox UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="ea259-151">Next, you'll want to bring up the standard Xbox UI for inviting friends.</span></span> <span data-ttu-id="ea259-152">表示される UI を使用することでプレイヤーは、フレンドまたは最近のプレイヤーを選択し、ゲームに招待できます。</span><span class="sxs-lookup"><span data-stu-id="ea259-152">This displays a UI that allows the player to select friends  or recent players to invite to the game.</span></span> <span data-ttu-id="ea259-153">プレイヤーの確認が得られたら、Multiplayer Manager は選択されたプレイヤーに招待を送信します。</span><span class="sxs-lookup"><span data-stu-id="ea259-153">Once the player hits confirm, Multiplayer Manager sends the invites to the selected players.</span></span>

<span data-ttu-id="ea259-154">ゲームでは、`invite_users()` メソッドを使用し、Xbox Live ユーザー ID によって定義された一連のユーザーに招待を送信することもできます。</span><span class="sxs-lookup"><span data-stu-id="ea259-154">Games can also use the `invite_users()` method to send invites to a set of people defined by their Xbox Live User Ids.</span></span> <span data-ttu-id="ea259-155">これは、ストック Xbox UI の代わりに独自のゲーム内 UI を使用する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="ea259-155">This is useful if you prefer to use your own in-game UI instead of the stock Xbox UI.</span></span>

**<span data-ttu-id="ea259-156">例:</span><span class="sxs-lookup"><span data-stu-id="ea259-156">Example:</span></span>**

```cpp
auto result = mpInstance->lobby_session()->invite_friends(xboxLiveContext);
if (result.err())
{
  // handle error
}
```

**<span data-ttu-id="ea259-157">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="ea259-157">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="ea259-158">Xbox ストックのタイトルが呼び出せる UI (TCUI) を表示する</span><span class="sxs-lookup"><span data-stu-id="ea259-158">Brings up the Xbox stock title callable UI (TCUI)</span></span>
* <span data-ttu-id="ea259-159">選択されたプレイヤーに直接、招待を送信する</span><span class="sxs-lookup"><span data-stu-id="ea259-159">Sends invite directly to the selected players</span></span>

### <a name="4-accept-invites-a-nameaccept-invites"></a><span data-ttu-id="ea259-160">4) 招待を受け入れる <a name="accept-invites"></span><span class="sxs-lookup"><span data-stu-id="ea259-160">4) Accept invites <a name="accept-invites"></span></span>

| <span data-ttu-id="ea259-161">メソッド</span><span class="sxs-lookup"><span data-stu-id="ea259-161">Method</span></span> | <span data-ttu-id="ea259-162">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="ea259-162">Event triggered</span></span> |
| -----|----------------|
| `multiplayer_manager::join_lobby(Windows::ApplicationModel::Activation::IProtocolActivatedEventArgs^ args)` | `join_lobby_completed_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

<span data-ttu-id="ea259-163">招待されたプレイヤーがゲームの招待を受け入れると、またはシェル UI でフレンドのゲームに参加すると、プロトコルのアクティブ化を使用してデバイスでゲームが起動されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-163">When an invited player accepts a game invite or joined a friends game via a shell UI, the game is launched on their device by using protocol activation.</span></span> <span data-ttu-id="ea259-164">ゲームが開始したら、Multiplayer Manager はプロトコルがアクティブ化されたイベント引数を使用してロビーに参加できます。</span><span class="sxs-lookup"><span data-stu-id="ea259-164">Once the game starts, Multiplayer Manager can use the protocol activated event arguments to join the lobby.</span></span> <span data-ttu-id="ea259-165">lobby_session()::add_local_user() を通してローカル ユーザーを追加していない場合は、必要に応じて、join_lobby() API によってユーザーのリストに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="ea259-165">Optionally, if you haven't added the local users through lobby_session()::add_local_user(), you can pass in the list of users via the join_lobby() API.</span></span> <span data-ttu-id="ea259-166">招待されたユーザーが lobby_session()::add_local_user() または join_lobby() によって追加されない場合、join_lobby() は失敗し、join_lobby_completed_event_args() の一部として招待が送信された invited_xbox_user_id が提供されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-166">If the invited user is not added either via lobby_session()::add_local_user() or through join_lobby(), then join_lobby() will fail and provide the invited_xbox_user_id() that the invite was sent for as part of the join_lobby_completed_event_args().</span></span>

<span data-ttu-id="ea259-167">ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="ea259-167">After joining the lobby, Microsoft recommends setting the local member's connection address, as well as any custom properties for the member.</span></span> <span data-ttu-id="ea259-168">また、set_synchronized_host を使用してホストを設定することもできます (存在しない場合)。</span><span class="sxs-lookup"><span data-stu-id="ea259-168">You can also set the host via set_synchronized_host if one doesn't exist.</span></span>

<span data-ttu-id="ea259-169">最後に、ゲームが既に進行中であり、招待されたユーザーを受け入れる余裕がある場合、Multiplayer Manager はユーザーをゲーム セッションに自動的に参加させます。</span><span class="sxs-lookup"><span data-stu-id="ea259-169">Finally, the Multiplayer Manager will auto join the user into the game session if a game is already in progress and has room for the invitee.</span></span> <span data-ttu-id="ea259-170">タイトルには、適切なエラー コードとメッセージを提供する join_game_completed イベントによって通知されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-170">The title will be notified through the join_game_completed event providing an appropriate error code and message.</span></span>

**<span data-ttu-id="ea259-171">例:</span><span class="sxs-lookup"><span data-stu-id="ea259-171">Example:</span></span>**

```cpp
auto result = mpInstance().join_lobby(IProtocolActivatedEventArgs^ args);
if (result.err())
{
  // handle error
}

string_t connectionAddress = L"1.1.1.1";
mpInstance->lobby_session()->set_local_member_connection_address(
    xboxLiveContext->user(), connectionAddress);
```

<span data-ttu-id="ea259-172">エラー/成功は `join_lobby_completed` イベントを介して処理されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-172">Error/success is handled via the `join_lobby_completed` event</span></span>

**<span data-ttu-id="ea259-173">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="ea259-173">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="ea259-174">RTA およびマルチプレイヤーのサブスクリプションを登録する</span><span class="sxs-lookup"><span data-stu-id="ea259-174">Register RTA & Multiplayer Subscriptions</span></span>
* <span data-ttu-id="ea259-175">ロビー セッションに参加する</span><span class="sxs-lookup"><span data-stu-id="ea259-175">Join Lobby session</span></span>
 * <span data-ttu-id="ea259-176">既存のロビー状態のクリーンアップ</span><span class="sxs-lookup"><span data-stu-id="ea259-176">Existing Lobby state cleanup</span></span>
 * <span data-ttu-id="ea259-177">すべてのローカル プレイヤーをアクティブとして参加させる</span><span class="sxs-lookup"><span data-stu-id="ea259-177">Join all local players as active</span></span>
 * <span data-ttu-id="ea259-178">SDA をアップロードする</span><span class="sxs-lookup"><span data-stu-id="ea259-178">Upload SDA</span></span>
 * <span data-ttu-id="ea259-179">メンバーのプロパティを設定する</span><span class="sxs-lookup"><span data-stu-id="ea259-179">Set member properties</span></span>
* <span data-ttu-id="ea259-180">セッション変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="ea259-180">Register for Session Change Events</span></span>
* <span data-ttu-id="ea259-181">ロビー セッションをアクティブ セッションとして設定する</span><span class="sxs-lookup"><span data-stu-id="ea259-181">Set Lobby Session as Active Session</span></span>
* <span data-ttu-id="ea259-182">ゲーム セッションに参加する (存在する場合)</span><span class="sxs-lookup"><span data-stu-id="ea259-182">Join Game Session (if exists)</span></span>
 * <span data-ttu-id="ea259-183">転送ハンドルを使用する</span><span class="sxs-lookup"><span data-stu-id="ea259-183">Uses transfer handle</span></span>

### <a name="5-join-a-game-session-from-the-lobby-a-namejoin-game"></a><span data-ttu-id="ea259-184">5) ロビーからゲーム セッションに参加する <a name="join-game"></span><span class="sxs-lookup"><span data-stu-id="ea259-184">5) Join a game session from the lobby <a name="join-game"></span></span>

| <span data-ttu-id="ea259-185">メソッド</span><span class="sxs-lookup"><span data-stu-id="ea259-185">Method</span></span> | <span data-ttu-id="ea259-186">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="ea259-186">Event triggered</span></span> |
|-----|----------------|
| `multiplayer_manager::join_game_from_lobby()` | `join_game_completed_event` |

<span data-ttu-id="ea259-187">招待が受け入れられて、ホストがゲームのプレイを開始できる状態になったら、`join_game_from_lobby()` を呼び出すことによってロビー セッションのメンバーを含む新しいゲームを開始できます。</span><span class="sxs-lookup"><span data-stu-id="ea259-187">After invites have been accepted, and the host is ready to start playing the game, you can start a new game that includes the members of the lobby session by calling `join_game_from_lobby()`.</span></span>

**<span data-ttu-id="ea259-188">例:</span><span class="sxs-lookup"><span data-stu-id="ea259-188">Example:</span></span>**

```cpp
auto result = mpInstance.join_game_from_lobby();
if (result.err())
{
  // handle error
}
```

<span data-ttu-id="ea259-189">エラー/成功は `join_game_completed` イベントを介して処理されます。</span><span class="sxs-lookup"><span data-stu-id="ea259-189">Error/success is handled via `join_game_completed` event</span></span>

**<span data-ttu-id="ea259-190">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="ea259-190">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="ea259-191">ゲーム セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="ea259-191">Create Game Session</span></span>
 * <span data-ttu-id="ea259-192">すべてのローカル プレイヤーをアクティブとして参加させる</span><span class="sxs-lookup"><span data-stu-id="ea259-192">Join all local players as active</span></span>
 * <span data-ttu-id="ea259-193">SDA をアップロードする</span><span class="sxs-lookup"><span data-stu-id="ea259-193">Upload SDA</span></span>
 * <span data-ttu-id="ea259-194">メンバーのプロパティを設定する</span><span class="sxs-lookup"><span data-stu-id="ea259-194">Set member properties</span></span>
* <span data-ttu-id="ea259-195">セッション変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="ea259-195">Register for Session Change Events</span></span>
* <span data-ttu-id="ea259-196">ロビー セッションを介してゲームを公開する</span><span class="sxs-lookup"><span data-stu-id="ea259-196">Advertise Game via Lobby Session</span></span>
