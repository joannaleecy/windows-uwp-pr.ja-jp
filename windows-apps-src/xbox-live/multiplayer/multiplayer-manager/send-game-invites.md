---
title: ゲームへの招待を送信する
author: KevinAsgari
description: Xbox Live Multiplayer Manager を使用して、プレイヤーにゲームの招待の送信を許可する方法について説明します。
ms.assetid: 8b9a98af-fb78-431b-9a2a-876168e2fd76
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー, Multiplayer Manager, フローチャート, ゲームへの招待
ms.localizationpriority: medium
ms.openlocfilehash: b14ff62d1bb08c5115e5fa766b1b56abf37cbff2
ms.sourcegitcommit: 194ab5aa395226580753869c6b66fce88be83522
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/24/2018
ms.locfileid: "4153308"
---
# <a name="send-game-invites"></a><span data-ttu-id="d7feb-104">ゲームへの招待を送信する</span><span class="sxs-lookup"><span data-stu-id="d7feb-104">Send game invites</span></span>

<span data-ttu-id="d7feb-105">簡単なマルチプレイヤー シナリオの 1 つは、ゲーマーにフレンドとのオンラインでのゲーム プレイを許可することです。</span><span class="sxs-lookup"><span data-stu-id="d7feb-105">One of the simpler multiplayer scenarios is to allow a gamer to play your game online with friends.</span></span> <span data-ttu-id="d7feb-106">このシナリオには、ゲームへの参加の招待を別のプレイヤーに送信するために必要な手順が含まれます。</span><span class="sxs-lookup"><span data-stu-id="d7feb-106">This scenario covers the steps you need to send invites to another player to join your game.</span></span>

<span data-ttu-id="d7feb-107">[Multiplayer Manager を初期化](play-multiplayer-with-friends.md)し、[ローカル ユーザーを追加することでロビー セッションを作成](play-multiplayer-with-friends.md)した後は、`user_added` イベントを受け取るまで待ってから、招待の送信を始める必要があります。</span><span class="sxs-lookup"><span data-stu-id="d7feb-107">Once you've [initialized the Multiplayer Manager](play-multiplayer-with-friends.md), and have [created a Lobby session by adding local users](play-multiplayer-with-friends.md), you must wait until you receive the `user_added` event before you can start sending invites.</span></span>

<span data-ttu-id="d7feb-108">招待を送信するには 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="d7feb-108">There are two ways to send an invite:</span></span>

1. [<span data-ttu-id="d7feb-109">Xbox プラットフォームの招待 TCUI</span><span class="sxs-lookup"><span data-stu-id="d7feb-109">Xbox Platform Invite TCUI</span></span>](#xbox-platform-invite-tcui)
2. [<span data-ttu-id="d7feb-110">タイトルで実装したカスタム UI</span><span class="sxs-lookup"><span data-stu-id="d7feb-110">Title implemented custom UI</span></span>](#title-implemented-custom-ui)

<span data-ttu-id="d7feb-111">プロセスのフローチャートについては、「[フローチャート - 別のプレイヤーに招待を送信する](mpm-flowcharts/mpm-send-invites.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="d7feb-111">You can see a flowchart of the process here: [Flowchart - Send Invitation to another player](mpm-flowcharts/mpm-send-invites.md).</span></span>

### <a name="1-xbox-platform-invite-tcui-a-namexbox-platform-invite-tcui"></a><span data-ttu-id="d7feb-112">1) Xbox プラットフォームの招待 TCUI <a name="xbox-platform-invite-tcui"></span><span class="sxs-lookup"><span data-stu-id="d7feb-112">1) Xbox Platform Invite TCUI <a name="xbox-platform-invite-tcui"></span></span>

| <span data-ttu-id="d7feb-113">メソッド</span><span class="sxs-lookup"><span data-stu-id="d7feb-113">Method</span></span> | <span data-ttu-id="d7feb-114">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="d7feb-114">Event triggered</span></span> |
| -----|----------------|
| `multiplayer_lobby_session::invite_friends()` | `invite_sent` |

<span data-ttu-id="d7feb-115">`invite_friends()` を呼び出すと、フレンド招待用の標準の Xbox UI が表示されます。</span><span class="sxs-lookup"><span data-stu-id="d7feb-115">Calling `invite_friends()` will bring up the standard Xbox UI for inviting friends.</span></span> <span data-ttu-id="d7feb-116">表示される UI を使用することでプレイヤーは、フレンドまたは最近のプレイヤーを選択し、ゲームに招待できます。</span><span class="sxs-lookup"><span data-stu-id="d7feb-116">This displays a UI that allows the player to select friends or recent players to invite to the game.</span></span> <span data-ttu-id="d7feb-117">プレイヤーの確認が得られたら、Multiplayer Manager は選択されたプレイヤーに招待を送信します。</span><span class="sxs-lookup"><span data-stu-id="d7feb-117">Once the player hits confirm, Multiplayer Manager sends the invites to the selected players.</span></span>

**<span data-ttu-id="d7feb-118">例:</span><span class="sxs-lookup"><span data-stu-id="d7feb-118">Example:</span></span>**

```cpp
auto result = mpInstance->lobby_session()->invite_friends(xboxLiveContext);
if (result.err())
{
  // handle error
}
```

**<span data-ttu-id="d7feb-119">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="d7feb-119">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="d7feb-120">Xbox ストックのタイトルが呼び出せる UI (TCUI) を表示する</span><span class="sxs-lookup"><span data-stu-id="d7feb-120">Brings up the Xbox stock title callable UI (TCUI)</span></span>
* <span data-ttu-id="d7feb-121">選択されたプレイヤーに直接、招待を送信する</span><span class="sxs-lookup"><span data-stu-id="d7feb-121">Sends invite directly to the selected players</span></span>

### <a name="2-title-implemented-custom-uia-nametitle-implemented-custom-ui"></a><span data-ttu-id="d7feb-122">2) タイトルで実装したカスタム UI<a name="title-implemented-custom-ui"></span><span class="sxs-lookup"><span data-stu-id="d7feb-122">2) Title implemented custom UI<a name="title-implemented-custom-ui"></span></span>

| <span data-ttu-id="d7feb-123">メソッド</span><span class="sxs-lookup"><span data-stu-id="d7feb-123">Method</span></span> | <span data-ttu-id="d7feb-124">トリガーされるイベント</span><span class="sxs-lookup"><span data-stu-id="d7feb-124">Event triggered</span></span> |
|-----|----------------|
| `multiplayer_lobby_session::invite_users()` | `invite_sent` |

<span data-ttu-id="d7feb-125">タイトルでは、オンラインのフレンドを表示して招待するためのカスタム TCUI を実装できます。</span><span class="sxs-lookup"><span data-stu-id="d7feb-125">Your title can implement a custom TCUI for viewing online friends and inviting them.</span></span> <span data-ttu-id="d7feb-126">ゲームでは、`invite_users()` メソッドを使用し、Xbox Live ユーザー ID によって定義された一連のユーザーに招待を送信できます。</span><span class="sxs-lookup"><span data-stu-id="d7feb-126">Games can use the `invite_users()` method to send invites to a set of people defined by their Xbox Live User Ids.</span></span> <span data-ttu-id="d7feb-127">これは、ストック Xbox UI の代わりに独自のゲーム内 UI を使用する場合に役立ちます。</span><span class="sxs-lookup"><span data-stu-id="d7feb-127">This is useful if you prefer to use your own in-game UI instead of the stock Xbox UI.</span></span>

**<span data-ttu-id="d7feb-128">例:</span><span class="sxs-lookup"><span data-stu-id="d7feb-128">Example:</span></span>**

```cpp
std::vector<string_t>& xboxUserIds;
xboxUserIds.push_back();  // Add xbox_user_ids from your in-game roster list

auto result = mpInstance->lobby_session()->invite_users(xboxUserIds);
if (result.err())
{
  // handle error
}
```

**<span data-ttu-id="d7feb-129">Multiplayer Manager によって実行される機能</span><span class="sxs-lookup"><span data-stu-id="d7feb-129">Functions performed by Multiplayer Manager</span></span>**

* <span data-ttu-id="d7feb-130">選択されたプレイヤーに直接、招待を送信する</span><span class="sxs-lookup"><span data-stu-id="d7feb-130">Sends invite directly to the selected players</span></span>
