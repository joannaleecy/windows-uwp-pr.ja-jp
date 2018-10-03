---
title: SmartMatch を使用してマルチプレイヤー ゲームをプレイする
author: KevinAsgari
description: Xbox Live Multiplayer Manager を使用して、プレイヤーが SmartMatch によってマルチプレイヤー ゲームを探すことができるようにする方法について説明します。
ms.assetid: f9001364-214f-4ba0-a0a6-0f3be0b2f523
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, Multiplayer Manager, フローチャート, SmartMatch
ms.localizationpriority: medium
ms.openlocfilehash: 3bc23c73df1bdd8a030165ae623fc59c036104bd
ms.sourcegitcommit: 1938851dc132c60348f9722daf994b86f2ead09e
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/03/2018
ms.locfileid: "4261610"
---
# <a name="find-a-multiplayer-game-by-using-smartmatch"></a><span data-ttu-id="10654-104">SmartMatch を使用してマルチプレイヤー ゲームを検索する</span><span class="sxs-lookup"><span data-stu-id="10654-104">Find a multiplayer game by using SmartMatch</span></span>

<span data-ttu-id="10654-105">ゲームをプレイしたいがオンラインのフレンドの人数が足りない場合や、ゲーマーが単にランダムなプレイヤーを相手にオンラインでプレイしたい場合があります。</span><span class="sxs-lookup"><span data-stu-id="10654-105">Sometimes, a gamer may not have enough friends online when they want to play a game, or they just want to play against random people online.</span></span> <span data-ttu-id="10654-106">Xbox Live SmartMatch サービスを使用して、他の Xbox Live プレイヤーを探すことができます。</span><span class="sxs-lookup"><span data-stu-id="10654-106">You can use the Xbox Live SmartMatch service to find other Xbox Live players</span></span>

<span data-ttu-id="10654-107">このページでは、Multiplayer Manager を使用して SmartMatch マッチメイキングを実装するために必要な基本手順を説明します。</span><span class="sxs-lookup"><span data-stu-id="10654-107">This page covers the basic steps you need to implement SmartMatch matchmaking by using Multiplayer Manager.</span></span>

## <a name="find-a-match"></a><span data-ttu-id="10654-108">マッチを探す</span><span class="sxs-lookup"><span data-stu-id="10654-108">Find a match</span></span>

<span data-ttu-id="10654-109">Multiplayer Manager を使用してユーザーのフレンドに招待を送信し、そのフレンドがゲームに途中参加するときの処理は 4 つのステップからなります。</span><span class="sxs-lookup"><span data-stu-id="10654-109">There are four steps involved when using the Multiplayer Manager to send an invite to a user's friend, and then for that friend to join the game in progress:</span></span>

1. [<span data-ttu-id="10654-110">Multiplayer Manager を初期化する</span><span class="sxs-lookup"><span data-stu-id="10654-110">Initialize Multiplayer Manager</span></span>](#initialize-multiplayer-manager)
2. [<span data-ttu-id="10654-111">ローカル ユーザーを追加することでロビー セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="10654-111">Create the lobby session by adding local users</span></span>](#create-lobby)
3. [<span data-ttu-id="10654-112">フレンドに招待を送信する</span><span class="sxs-lookup"><span data-stu-id="10654-112">Send invites to friends</span></span>](#send-invites)
4. [<span data-ttu-id="10654-113">招待を受け入れる</span><span class="sxs-lookup"><span data-stu-id="10654-113">Accept invites</span></span>](#accept-invites)
5. [<span data-ttu-id="10654-114">マッチを探す</span><span class="sxs-lookup"><span data-stu-id="10654-114">Find a match</span></span>](#find-match)

<span data-ttu-id="10654-115">手順 1、2、3、5 は、招待を実行したデバイス上で行います。</span><span class="sxs-lookup"><span data-stu-id="10654-115">Steps 1, 2, 3, and 5 are done on the device performing the invite.</span></span>  <span data-ttu-id="10654-116">手順 4 は通常、プロトコルのアクティブ化によるアプリ起動の後、招待されたユーザーのマシンで開始されます。</span><span class="sxs-lookup"><span data-stu-id="10654-116">Step 4 would typically be initiated on the invitee's machine following app launch via protocol activation.</span></span>

<span data-ttu-id="10654-117">プロセスのフローチャートについては、「[フローチャート - SmartMatch マッチメイキングを使用してマルチプレイヤー ゲームをプレイする](mpm-flowcharts/mpm-play-with-smartmatch-matchmaking.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="10654-117">You can see a flowchart of the process here: [Flowchart - Play a multiplayer game by using SmartMatch matchmaking](mpm-flowcharts/mpm-play-with-smartmatch-matchmaking.md).</span></span>

### <a name="1-initialize-multiplayer-manager-a-nameinitialize-multiplayer-manager"></a><span data-ttu-id="10654-118">1) Multiplayer Manager を初期化する <a name="initialize-multiplayer-manager"></span><span class="sxs-lookup"><span data-stu-id="10654-118">1) Initialize Multiplayer Manager <a name="initialize-multiplayer-manager"></span></span>

| <span data-ttu-id="10654-119">呼び出し</span><span class="sxs-lookup"><span data-stu-id="10654-119">Call</span></span> | <span data-ttu-id="10654-120">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="10654-120">Event triggered</span></span> |
|-----|----------------|
| `multiplayer_manager::initialize(lobbySessionTemplateName)` | <span data-ttu-id="10654-121">該当なし</span><span class="sxs-lookup"><span data-stu-id="10654-121">N/A</span></span> |

<span data-ttu-id="10654-122">(サービス構成で構成される) 有効なセッション テンプレート名が指定されていることを前提に、Multiplayer Manager の初期化時にロビー セッション オブジェクトが自動的に作成されます。</span><span class="sxs-lookup"><span data-stu-id="10654-122">The lobby session object is automatically created upon initializing the Multiplayer Manager, assuming that a valid session template name (configured in the service configuration) is specified.</span></span> <span data-ttu-id="10654-123">このとき、サービスでロビー セッション インスタンスが作成されるわけではないことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="10654-123">Note that this does not create the lobby session instance on the service.</span></span>

**<span data-ttu-id="10654-124">例:</span><span class="sxs-lookup"><span data-stu-id="10654-124">Example:</span></span>**

```cpp
auto mpInstance = multiplayer_manager::get_singleton_instance();

mpInstance->initialize(lobbySessionTemplateName);
```


### <a name="2-create-the-lobby-session-by-adding-local-usersa-namecreate-lobby"></a><span data-ttu-id="10654-125">2) ローカル ユーザーを追加することでロビー セッションを作成する<a name="create-lobby"></span><span class="sxs-lookup"><span data-stu-id="10654-125">2) Create the lobby session by adding local users<a name="create-lobby"></span></span>

| <span data-ttu-id="10654-126">メソッド</span><span class="sxs-lookup"><span data-stu-id="10654-126">Method</span></span> | <span data-ttu-id="10654-127">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="10654-127">Event triggered</span></span> |
|-----|----------------|
| `multiplayer_lobby_session::add_local_user()` | `user_added_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

<span data-ttu-id="10654-128">ここでは、ローカルでサインインしている Xbox Live ユーザーをロビー セッションに追加します。</span><span class="sxs-lookup"><span data-stu-id="10654-128">Here, you add the locally signed in Xbox Live users to the lobby session.</span></span> <span data-ttu-id="10654-129">最初のユーザーが追加されたときに新しいロビーをホストします。</span><span class="sxs-lookup"><span data-stu-id="10654-129">This hosts a new lobby when the first user is added.</span></span> <span data-ttu-id="10654-130">他のすべてのユーザーについては、セカンダリー ユーザーとして既存のロビーに追加されます。</span><span class="sxs-lookup"><span data-stu-id="10654-130">For all other users, they will be added to the existing lobby as secondary users.</span></span> <span data-ttu-id="10654-131">この API は、フレンドが参加するシェルのロビーも公開します。</span><span class="sxs-lookup"><span data-stu-id="10654-131">This API will also advertise the lobby in the shell for friends to join.</span></span> <span data-ttu-id="10654-132">招待の送信、ロビーのプロパティの設定、および lobby() を介したロビー メンバーへのアクセスは、ローカル ユーザーの追加後にのみ可能です。</span><span class="sxs-lookup"><span data-stu-id="10654-132">You can send invites, set lobby properties, access lobby members via lobby() only once you've added the local user.</span></span>

<span data-ttu-id="10654-133">ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="10654-133">After joining the lobby, Microsoft recommends setting the local member's connection address, as well as any custom properties for the member.</span></span>

<span data-ttu-id="10654-134">ローカルにサインインしたすべてのユーザーに対して、このプロセスを繰り返す必要があります。</span><span class="sxs-lookup"><span data-stu-id="10654-134">You must repeat this process for all locally signed in users.</span></span>

**<span data-ttu-id="10654-135">例: (1 人のローカル ユーザー)</span><span class="sxs-lookup"><span data-stu-id="10654-135">Example: (single local user)</span></span>**

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
    xboxLiveContext->user(), connectionAddress);

// Set custom member properties
mpInstance->lobby_session()->set_local_member_properties(xboxLivecontext->user(), ..., ...)
```

**<span data-ttu-id="10654-136">例: (複数のローカル ユーザー)</span><span class="sxs-lookup"><span data-stu-id="10654-136">Example: (multiple local users)</span></span>**

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


<span data-ttu-id="10654-137">変更は次回の `do_work()` 呼び出しでバッチ処理されます。</span><span class="sxs-lookup"><span data-stu-id="10654-137">The changes are batched on the next `do_work()` call.</span></span>  
<span data-ttu-id="10654-138">Multiplayer Manager は、ユーザーがロビー セッションに追加されるたびに `user_added` イベントを生成します。</span><span class="sxs-lookup"><span data-stu-id="10654-138">Multiplayer manager fires a `user_added` event each time a user is added to the lobby session.</span></span> <span data-ttu-id="10654-139">イベントのエラー コードを調べて、そのユーザーが正常に追加されたかどうかを確認することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="10654-139">Its recommended that you inspect the error code of the event to see if that user was successfully added.</span></span> <span data-ttu-id="10654-140">障害が発生した場合は、障害の詳細な理由がエラー メッセージで提供されます。</span><span class="sxs-lookup"><span data-stu-id="10654-140">In case of a failure, an error message will be provided detailing the reasons of the failure.</span></span>

**<span data-ttu-id="10654-141">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="10654-141">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="10654-142">リアルタイム アクティビティおよびマルチプレイヤーのサブスクリプションを Xbox Live マルチプレイヤー サービスに登録する</span><span class="sxs-lookup"><span data-stu-id="10654-142">Register Real Time Activity & Multiplayer Subscriptions with the Xbox Live multiplayer service</span></span>
* <span data-ttu-id="10654-143">ロビー セッションを作成する</span><span class="sxs-lookup"><span data-stu-id="10654-143">Create Lobby Session</span></span>
* <span data-ttu-id="10654-144">すべてのローカル プレイヤーをアクティブとして参加させる</span><span class="sxs-lookup"><span data-stu-id="10654-144">Join all local players as active</span></span>
* <span data-ttu-id="10654-145">SDA をアップロードする</span><span class="sxs-lookup"><span data-stu-id="10654-145">Upload SDA</span></span>
* <span data-ttu-id="10654-146">メンバーのプロパティを設定する</span><span class="sxs-lookup"><span data-stu-id="10654-146">Set member properties</span></span>
* <span data-ttu-id="10654-147">セッション変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="10654-147">Register for Session Change Events</span></span>
* <span data-ttu-id="10654-148">ロビー セッションをアクティブ セッションとして設定する</span><span class="sxs-lookup"><span data-stu-id="10654-148">Set Lobby Session as Active Session</span></span>

### <a name="3-send-invites-to-friends-optional-a-namesend-invites"></a><span data-ttu-id="10654-149">3) フレンドに招待を送信する (オプション) <a name="send-invites"></span><span class="sxs-lookup"><span data-stu-id="10654-149">3) Send invites to friends (optional) <a name="send-invites"></span></span>

| <span data-ttu-id="10654-150">メソッド</span><span class="sxs-lookup"><span data-stu-id="10654-150">Method</span></span> | <span data-ttu-id="10654-151">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="10654-151">Event triggered</span></span> |
| -----|----------------|
| `multiplayer_lobby_session::invite_friends()` | `invite_sent` |
| `multiplayer_lobby_session::invite_users()` | `invite_sent` |

<span data-ttu-id="10654-152">次に、フレンド招待用の標準 Xbox UI を表示します。</span><span class="sxs-lookup"><span data-stu-id="10654-152">Next, you'll want to bring up the standard Xbox UI for inviting friends.</span></span> <span data-ttu-id="10654-153">表示される UI を使用することでプレイヤーは、フレンドまたは最近のプレイヤーを選択し、ゲームに招待できます。</span><span class="sxs-lookup"><span data-stu-id="10654-153">This displays a UI that allows the player to select friends  or recent players to invite to the game.</span></span> <span data-ttu-id="10654-154">プレイヤーの確認が得られたら、Multiplayer Manager は選択されたプレイヤーに招待を送信します。</span><span class="sxs-lookup"><span data-stu-id="10654-154">Once the player hits confirm, Multiplayer Manager sends the invites to the selected players.</span></span>

<span data-ttu-id="10654-155">ゲームでは、`invite_users()` メソッドを使用し、Xbox Live ユーザー ID によって定義された一連のユーザーに招待を送信することもできます。</span><span class="sxs-lookup"><span data-stu-id="10654-155">Games can also use the `invite_users()` method to send invites to a set of people defined by their Xbox Live User Ids.</span></span> <span data-ttu-id="10654-156">これは、ストック Xbox UI の代わりに独自のゲーム内 UI を使用する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="10654-156">This is useful if you prefer to use your own in-game UI instead of the stock Xbox UI.</span></span>

**<span data-ttu-id="10654-157">例:</span><span class="sxs-lookup"><span data-stu-id="10654-157">Example:</span></span>**

```cpp
auto result = mpInstance->lobby_session()->invite_friends(xboxLiveContext);
if (result.err())
{
  // handle error
}
```

**<span data-ttu-id="10654-158">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="10654-158">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="10654-159">Xbox ストックのタイトルが呼び出せる UI (TCUI) を表示する</span><span class="sxs-lookup"><span data-stu-id="10654-159">Brings up the Xbox stock title callable UI (TCUI)</span></span>
* <span data-ttu-id="10654-160">選択されたプレイヤーに直接、招待を送信する</span><span class="sxs-lookup"><span data-stu-id="10654-160">Sends invite directly to the selected players</span></span>

### <a name="4-accept-invites-optional-a-nameaccept-invites"></a><span data-ttu-id="10654-161">4) 招待を受け入れる (オプション) <a name="accept-invites"></span><span class="sxs-lookup"><span data-stu-id="10654-161">4) Accept invites (optional) <a name="accept-invites"></span></span>

| <span data-ttu-id="10654-162">メソッド</span><span class="sxs-lookup"><span data-stu-id="10654-162">Method</span></span> | <span data-ttu-id="10654-163">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="10654-163">Event triggered</span></span> |
| -----|----------------|
| `multiplayer_manager::join_lobby(Windows::ApplicationModel::Activation::IProtocolActivatedEventArgs^ args)` | `join_lobby_completed_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

<span data-ttu-id="10654-164">招待されたプレイヤーがゲームの招待を受け入れると、またはシェル UI でフレンドのゲームに参加すると、プロトコルのアクティブ化を使用してデバイスでゲームが起動されます。</span><span class="sxs-lookup"><span data-stu-id="10654-164">When an invited player accepts a game invite or joined a friends game via a shell UI, the game is launched on their device by using protocol activation.</span></span> <span data-ttu-id="10654-165">ゲームが開始したら、Multiplayer Manager はプロトコルがアクティブ化されたイベント引数を使用してロビーに参加できます。</span><span class="sxs-lookup"><span data-stu-id="10654-165">Once the game starts, Multiplayer Manager can use the protocol activated event arguments to join the lobby.</span></span> <span data-ttu-id="10654-166">lobby_session()::add_local_user() を通してローカル ユーザーを追加していない場合は、必要に応じて、join_lobby() API によってユーザーのリストに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="10654-166">Optionally, if you haven't added the local users through lobby_session()::add_local_user(), you can pass in the list of users via the join_lobby() API.</span></span> <span data-ttu-id="10654-167">招待されたユーザーが lobby_session()::add_local_user() または join_lobby() によって追加されない場合、join_lobby() は失敗し、join_lobby_completed_event_args() の一部として招待が送信された invited_xbox_user_id が提供されます。</span><span class="sxs-lookup"><span data-stu-id="10654-167">If the invited user is not added either via lobby_session()::add_local_user() or through join_lobby(), then join_lobby() will fail and provide the invited_xbox_user_id() that the invite was sent for as part of the join_lobby_completed_event_args().</span></span>

<span data-ttu-id="10654-168">ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="10654-168">After joining the lobby, Microsoft recommends setting the local member's connection address, as well as any custom properties for the member.</span></span> <span data-ttu-id="10654-169">また、set_synchronized_host を使用してホストを設定することもできます (存在しない場合)。</span><span class="sxs-lookup"><span data-stu-id="10654-169">You can also set the host via set_synchronized_host if one doesn't exist.</span></span>

<span data-ttu-id="10654-170">最後に、ゲームが既に進行中であり、招待されたユーザーを受け入れる余裕がある場合、Multiplayer Manager はユーザーをゲーム セッションに自動的に参加させます。</span><span class="sxs-lookup"><span data-stu-id="10654-170">Finally, the Multiplayer Manager will auto join the user into the game session if a game is already in progress and has room for the invitee.</span></span> <span data-ttu-id="10654-171">タイトルには、適切なエラー コードとメッセージを提供する join_game_completed イベントによって通知されます。</span><span class="sxs-lookup"><span data-stu-id="10654-171">The title will be notified through the join_game_completed event providing an appropriate error code and message.</span></span>

**<span data-ttu-id="10654-172">例:</span><span class="sxs-lookup"><span data-stu-id="10654-172">Example:</span></span>**

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

<span data-ttu-id="10654-173">エラー/成功は `join_lobby_completed` イベントを介して処理されます。</span><span class="sxs-lookup"><span data-stu-id="10654-173">Error/success is handled via the `join_lobby_completed` event</span></span>

**<span data-ttu-id="10654-174">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="10654-174">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="10654-175">RTA およびマルチプレイヤーのサブスクリプションを登録する</span><span class="sxs-lookup"><span data-stu-id="10654-175">Register RTA & Multiplayer Subscriptions</span></span>
* <span data-ttu-id="10654-176">ロビー セッションに参加する</span><span class="sxs-lookup"><span data-stu-id="10654-176">Join Lobby session</span></span>
 * <span data-ttu-id="10654-177">既存のロビー状態のクリーンアップ</span><span class="sxs-lookup"><span data-stu-id="10654-177">Existing Lobby state cleanup</span></span>
 * <span data-ttu-id="10654-178">すべてのローカル プレイヤーをアクティブとして参加させる</span><span class="sxs-lookup"><span data-stu-id="10654-178">Join all local players as active</span></span>
 * <span data-ttu-id="10654-179">SDA をアップロードする</span><span class="sxs-lookup"><span data-stu-id="10654-179">Upload SDA</span></span>
 * <span data-ttu-id="10654-180">メンバーのプロパティを設定する</span><span class="sxs-lookup"><span data-stu-id="10654-180">Set member properties</span></span>
* <span data-ttu-id="10654-181">セッション変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="10654-181">Register for Session Change Events</span></span>
* <span data-ttu-id="10654-182">ロビー セッションをアクティブ セッションとして設定する</span><span class="sxs-lookup"><span data-stu-id="10654-182">Set Lobby Session as Active Session</span></span>
* <span data-ttu-id="10654-183">ゲーム セッションに参加する (存在する場合)</span><span class="sxs-lookup"><span data-stu-id="10654-183">Join Game Session (if exists)</span></span>
 * <span data-ttu-id="10654-184">転送ハンドルを使用する</span><span class="sxs-lookup"><span data-stu-id="10654-184">Uses transfer handle</span></span>


### <a name="5-find-match-a-namefind-match"></a><span data-ttu-id="10654-185">5) マッチを探す <a name="find-match"></span><span class="sxs-lookup"><span data-stu-id="10654-185">5) Find match <a name="find-match"></span></span>

| <span data-ttu-id="10654-186">呼び出し</span><span class="sxs-lookup"><span data-stu-id="10654-186">Call</span></span> | <span data-ttu-id="10654-187">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="10654-187">Event triggered</span></span> |
|-----|----------------|
| `multiplayer_manager::find_match()` | <span data-ttu-id="10654-188">```match_status``` に記述されている多数のイベント (```searching```、```found```、```measuring``` など)</span><span class="sxs-lookup"><span data-stu-id="10654-188">Many events, as described in ```match_status``` (eg: ```searching```, ```found```, ```measuring```, etc)</span></span> |

<span data-ttu-id="10654-189">招待 (ある場合) が受け入れられ、ホストでゲームのプレイを開始する準備が整った後、SmartMatch を使用すると、`find_match()` を呼び出すことにより、ロビー セッションにいるメンバー全員が参加するために十分な数の空きプレイヤー スロットがある既存のゲームを探すことも、`join_game_from_lobby()` に続いて `set_auto_fill_members_during_matchmaking()` を呼び出すことにより、ロビー セッションのメンバー全員を含む新しいゲーム セッションを作成して、同じゲーム タイプのマッチを探している他のプレイヤーで空きスロットを埋めることもできます。</span><span class="sxs-lookup"><span data-stu-id="10654-189">After invites, if any, have been accepted, and the host is ready to start playing the game, you can use SmartMatch to either find an existing game that has enough open player slots for all of the members in the lobby session by calling `find_match()`, or create a new game session that includes all of the members from the lobby session and fill up open spots with other people looking for a match of the same game type, by calling `join_game_from_lobby()` followed with `set_auto_fill_members_during_matchmaking()`.</span></span>

<span data-ttu-id="10654-190">`find_match()` を呼び出す前には、まずサービス構成でホッパーを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="10654-190">Before you can call `find_match()`, you must first configure hoppers in your service configuration.</span></span> <span data-ttu-id="10654-191">ホッパーは、SmartMatch がプレイヤーのマッチングに使用する規則を定義します。</span><span class="sxs-lookup"><span data-stu-id="10654-191">A hopper defines the rules that SmartMatch uses to match players.</span></span>

**<span data-ttu-id="10654-192">例:</span><span class="sxs-lookup"><span data-stu-id="10654-192">Example:</span></span>**

```cpp
auto result = mpInstance.find_match(HOPPER_NAME);
if (result.err())
{
  // handle error
}
```

**<span data-ttu-id="10654-193">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="10654-193">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="10654-194">マッチ チケットを作成する</span><span class="sxs-lookup"><span data-stu-id="10654-194">Create a match ticket</span></span>
* <span data-ttu-id="10654-195">すべての QoS ステージを処理する</span><span class="sxs-lookup"><span data-stu-id="10654-195">Handle all of the QoS stages</span></span>
* <span data-ttu-id="10654-196">参加者一覧の変更を処理する</span><span class="sxs-lookup"><span data-stu-id="10654-196">Handle roster changes</span></span>
 * <span data-ttu-id="10654-197">再送信する (必要な場合)</span><span class="sxs-lookup"><span data-stu-id="10654-197">Resubmit (if needed)</span></span>
* <span data-ttu-id="10654-198">ターゲット ゲーム セッションに参加する</span><span class="sxs-lookup"><span data-stu-id="10654-198">Joins target Game session</span></span>
* <span data-ttu-id="10654-199">ロビー セッションを介してゲームを公開する</span><span class="sxs-lookup"><span data-stu-id="10654-199">Advertise Game via Lobby Session</span></span>
