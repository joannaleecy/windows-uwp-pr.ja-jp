---
title: プロトコルのアクティブ化を処理する
author: KevinAsgari
description: Xbox Live Multiplayer Manager を使用してプロトコルのアクティブ化を処理する方法について説明します。
ms.assetid: e514bcb8-4302-4eeb-8c5b-176e23f3929f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, Multiplayer Manager, プロトコルのアクティブ化
ms.localizationpriority: medium
ms.openlocfilehash: 8b0cd9dbde739079fc72a0ee4a7be018afc427ed
ms.sourcegitcommit: 2a63ee6770413bc35ace09b14f56b60007be7433
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/12/2018
ms.locfileid: "3930841"
---
# <a name="handle-protocol-activation"></a><span data-ttu-id="74bbf-104">プロトコルのアクティブ化を処理する</span><span class="sxs-lookup"><span data-stu-id="74bbf-104">Handle protocol activation</span></span>

<span data-ttu-id="74bbf-105">プロトコルのアクティブ化では、別の操作 (通常、プレイヤーが別のプレイヤーからのゲームの招待を受け入れたとき) への応答としてシステムが自動的にゲームを起動します。</span><span class="sxs-lookup"><span data-stu-id="74bbf-105">Protocol activation is when the system automatically starts a game in response to another action, typically when a player accepts a game invite from another player.</span></span>

<span data-ttu-id="74bbf-106">タイトルは、次の方法でプロトコルをアクティブ化できます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-106">Your title can get protocol activated through the following ways:</span></span>

* <span data-ttu-id="74bbf-107">ユーザーがゲームへの招待を受け入れたとき</span><span class="sxs-lookup"><span data-stu-id="74bbf-107">When a user accepts a game invite</span></span>
* <span data-ttu-id="74bbf-108">ユーザーがプレイヤーのゲーマーカードから [ゲームに参加] を選択したとき</span><span class="sxs-lookup"><span data-stu-id="74bbf-108">When a user selects "Join Game" from a player’s gamercard.</span></span>

<span data-ttu-id="74bbf-109">このシナリオでは、タイトルが起動されてロビーおよびゲーム (存在する場合) に参加したときにプロトコルのアクティブ化を処理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="74bbf-109">This scenario covers how to handle the protocol activation when your title is launched and join the lobby and game (if one exists).</span></span>

<span data-ttu-id="74bbf-110">プロセスのフローチャートについては、「[フローチャート - プロトコルのアクティブ化を処理する](mpm-flowcharts/mpm-on-protocol-activation.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="74bbf-110">You can see a flowchart of the process here: [Flowchart - Handle protocol activation player](mpm-flowcharts/mpm-on-protocol-activation.md).</span></span>

| <span data-ttu-id="74bbf-111">メソッド</span><span class="sxs-lookup"><span data-stu-id="74bbf-111">Method</span></span> | <span data-ttu-id="74bbf-112">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="74bbf-112">Event triggered</span></span> |
| -----|----------------|
| `multiplayer_manager::join_lobby(IProtocolActivatedEventArgs^ args, User^)` | `join_lobby_completed_event` |
| `multiplayer_lobby_session::set_local_member_connection_address()` | `local_member_connection_address_write_completed ` |
| `multiplayer_lobby_session::set_local_member_properties()` | `member_property_changed` |

<span data-ttu-id="74bbf-113">プレイヤーがゲームの招待を受け入れたとき、またはプレイヤーのゲーマーカードからフレンドのゲームに参加したとき、プロトコルのアクティブ化を使用してプレイヤーのデバイスでゲームが起動されます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-113">When a player accepts a game invite or joins a friend's game through the player's gamercard, the game is launched on their device by using protocol activation.</span></span> <span data-ttu-id="74bbf-114">ゲームが開始したら、Multiplayer Manager はプロトコルがアクティブ化されたイベント引数を使用してロビーに参加できます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-114">Once the game starts, Multiplayer Manager can use the protocol activated event arguments to join the lobby.</span></span> <span data-ttu-id="74bbf-115">`lobby_session()::add_local_user()` を通してローカル ユーザーを追加していない場合は、必要に応じて`join_lobby()` API によってユーザーのリストに渡すことができます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-115">Optionally, if you haven't added the local users through `lobby_session()::add_local_user()`, you can pass in the list of users via the `join_lobby()` API.</span></span> <span data-ttu-id="74bbf-116">招待されたユーザーが追加されていない場合や、追加されたユーザーではない別のユーザーが招待の対象であった場合、`join_lobby()` は失敗となり、`join_lobby_completed_event_args` の一部として招待の送信先の `invited_xbox_user_id()` が提供されます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-116">If the invited user is not added, or if the invite was for another user than the user that was added, `join_lobby()` will fail and provide the `invited_xbox_user_id()` that the invite was sent for as part of the `join_lobby_completed_event_args`.</span></span>

<span data-ttu-id="74bbf-117">ロビーに参加した後は、ローカル メンバーの接続アドレスに加えて、メンバーのカスタム プロパティを設定することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="74bbf-117">After joining the lobby, Microsoft recommends setting the local member's connection address, as well as any custom properties for the member.</span></span> <span data-ttu-id="74bbf-118">また、`set_synchronized_host` を使用してホストを設定することもできます (存在しない場合)。</span><span class="sxs-lookup"><span data-stu-id="74bbf-118">You can also set the host via `set_synchronized_host` if one doesn't exist.</span></span>

<span data-ttu-id="74bbf-119">最後に、ゲームが既に進行中であり、招待されたユーザーを受け入れる余裕がある場合、Multiplayer Manager はユーザーをゲーム セッションに自動的に参加させます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-119">Finally, the Multiplayer Manager will auto join the user into the game session if a game is already in progress and has room for the invitee.</span></span> <span data-ttu-id="74bbf-120">タイトルには、適切なエラー コードとメッセージを提供する `join_game_completed` イベントによって通知されます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-120">The title will be notified through the `join_game_completed` event providing an appropriate error code and message.</span></span>

**<span data-ttu-id="74bbf-121">例:</span><span class="sxs-lookup"><span data-stu-id="74bbf-121">Example:</span></span>**

```cpp
auto result = mpInstance().join_lobby(IProtocolActivatedEventArgs^ args, users);
if (result.err())
{
  // handle error
}

string_t connectionAddress = L"1.1.1.1";
mpInstance->lobby_session()->set_local_member_connection_address(
    xboxLiveContext->user(),
    connectionAddress);
```

<span data-ttu-id="74bbf-122">エラー/成功は `join_lobby_completed` イベントを介して処理されます。</span><span class="sxs-lookup"><span data-stu-id="74bbf-122">Error/success is handled via the `join_lobby_completed` event</span></span>

**<span data-ttu-id="74bbf-123">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="74bbf-123">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="74bbf-124">RTA およびマルチプレイヤーのサブスクリプションを登録する</span><span class="sxs-lookup"><span data-stu-id="74bbf-124">Register RTA & Multiplayer Subscriptions</span></span>
* <span data-ttu-id="74bbf-125">ロビー セッションに参加する</span><span class="sxs-lookup"><span data-stu-id="74bbf-125">Join Lobby session</span></span>
 * <span data-ttu-id="74bbf-126">既存のロビー状態のクリーンアップ</span><span class="sxs-lookup"><span data-stu-id="74bbf-126">Existing Lobby state cleanup</span></span>
 * <span data-ttu-id="74bbf-127">すべてのローカル プレイヤーをアクティブとして参加させる</span><span class="sxs-lookup"><span data-stu-id="74bbf-127">Join all local players as active</span></span>
 * <span data-ttu-id="74bbf-128">SDA をアップロードする</span><span class="sxs-lookup"><span data-stu-id="74bbf-128">Upload SDA</span></span>
 * <span data-ttu-id="74bbf-129">メンバーのプロパティを設定する</span><span class="sxs-lookup"><span data-stu-id="74bbf-129">Set member properties</span></span>
* <span data-ttu-id="74bbf-130">セッション変更イベントに登録する</span><span class="sxs-lookup"><span data-stu-id="74bbf-130">Register for Session Change Events</span></span>
* <span data-ttu-id="74bbf-131">ロビー セッションをアクティブ セッションとして設定する</span><span class="sxs-lookup"><span data-stu-id="74bbf-131">Set Lobby Session as Active Session</span></span>
* <span data-ttu-id="74bbf-132">ゲーム セッションに参加する (存在する場合)</span><span class="sxs-lookup"><span data-stu-id="74bbf-132">Join Game Session (if exists)</span></span>
 * <span data-ttu-id="74bbf-133">転送ハンドルを使用する</span><span class="sxs-lookup"><span data-stu-id="74bbf-133">Uses transfer handle</span></span>
