---
title: アービターの移行
author: KevinAsgari
description: Xbox Live マルチプレイヤー 2015 でアービターを移行する方法を説明します。
ms.assetid: 9fb5d2c0-d548-4a22-b64e-6b215f78d22e
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アービター, マルチプレイヤー 2015
ms.localizationpriority: medium
ms.openlocfilehash: 073f189d8571a93eb0d5b6ac4ec536e29e6a80e3
ms.sourcegitcommit: e4f3e1b2d08a02b9920e78e802234e5b674e7223
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/26/2018
ms.locfileid: "4206703"
---
# <a name="migrating-an-arbiter"></a><span data-ttu-id="f8848-104">アービターの移行</span><span class="sxs-lookup"><span data-stu-id="f8848-104">Migrating an arbiter</span></span>

<span data-ttu-id="f8848-105">セッション全体のある時点で、アービター移行を使用して新しいアービターを選択する必要が生じる場合があります。</span><span class="sxs-lookup"><span data-stu-id="f8848-105">At some point during a complete session, you might need to select a new arbiter using arbiter migration.</span></span> <span data-ttu-id="f8848-106">移行には、次の 2 種類があります。</span><span class="sxs-lookup"><span data-stu-id="f8848-106">There are two types of migration:</span></span>

-   **<span data-ttu-id="f8848-107">正常なアービター移行</span><span class="sxs-lookup"><span data-stu-id="f8848-107">Graceful arbiter migration</span></span>**
-   **<span data-ttu-id="f8848-108">フェールオーバー アービター移行</span><span class="sxs-lookup"><span data-stu-id="f8848-108">Failover arbiter migration</span></span>**

<span data-ttu-id="f8848-109">次のフロー チャートは、アービターを移行する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="f8848-109">The following flow chart illustrates how to migrate an arbiter.</span></span>

![](../../images/multiplayer/Multiplayer_2015_HostMigration.png)

## <a name="graceful-arbiter-migration"></a><span data-ttu-id="f8848-110">正常なアービター移行</span><span class="sxs-lookup"><span data-stu-id="f8848-110">Graceful Arbiter Migration</span></span>

<span data-ttu-id="f8848-111">正常なアービター移行では、退出するアービターが移行作業を支援して新しいアービターを決定できます。</span><span class="sxs-lookup"><span data-stu-id="f8848-111">In graceful arbiter migration, the outgoing arbiter can assist with the migration task and determine a new arbiter.</span></span> <span data-ttu-id="f8848-112">この種類の移行では、「[方法: MPSD セッションのアービターの設定](multiplayer-how-tos.md)」に説明されているアービターの設定を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8848-112">This type of migration uses the setting of an arbiter as described in [How to: Set an Arbiter for an MPSD Session](multiplayer-how-tos.md).</span></span>


## <a name="failover-arbiter-migration"></a><span data-ttu-id="f8848-113">フェールオーバー アービター移行</span><span class="sxs-lookup"><span data-stu-id="f8848-113">Failover Arbiter Migration</span></span>

<span data-ttu-id="f8848-114">フェールオーバー アービター移行では、以前のアービターへの接続が失われ、残りのピアがセッションの新しいアービターを決定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8848-114">In a failover arbiter migration, connection to the previous arbiter is lost and the remaining peers must determine a new arbiter for the session.</span></span> <span data-ttu-id="f8848-115">フェールオーバー アービター移行でも、正常なアービター移行と同様に、ホスト デバイス トークンを設定し、HTTP/412 ステータス コードを処理します。</span><span class="sxs-lookup"><span data-stu-id="f8848-115">Failover arbiter migration also sets the host device token, and handles HTTP/412 status codes just as graceful arbiter migration does.</span></span> <span data-ttu-id="f8848-116">ただし、フェールオーバー アービター移行中に新しいアービターを選択する方法は複数あります。</span><span class="sxs-lookup"><span data-stu-id="f8848-116">However, there are multiple approaches for selecting a new arbiter during a failover arbiter migration.</span></span>
## <a name="select-arbiter-using-the-host-candidate-list"></a><span data-ttu-id="f8848-117">ホスト候補リストを使用したアービターの選択</span><span class="sxs-lookup"><span data-stu-id="f8848-117">Select Arbiter Using the Host Candidate List</span></span>

<span data-ttu-id="f8848-118">特定の操作中に測定されたマッチメイキング QoS メトリックに基づく順序付きのホスト候補リストを提供するように MPSD を構成することができます。</span><span class="sxs-lookup"><span data-stu-id="f8848-118">You can configure MPSD to provide an ordered host candidate list based on matchmaking QoS metrics that are measured during certain operations.</span></span> <span data-ttu-id="f8848-119">クライアントは、このリストを使用して新しいアービターを決定できます。</span><span class="sxs-lookup"><span data-stu-id="f8848-119">The client can use this list to determine a new arbiter.</span></span> <span data-ttu-id="f8848-120">このリストをアービター移行中に利用するために、各ピアは以下を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="f8848-120">To take advantage of this list during arbiter migration, each peer can:</span></span>

1.  <span data-ttu-id="f8848-121">前のアービターのリスト位置を識別します。</span><span class="sxs-lookup"><span data-stu-id="f8848-121">Identify the list position of the previous arbiter.</span></span>
2.  <span data-ttu-id="f8848-122">リスト内の次の本体を評価します。</span><span class="sxs-lookup"><span data-stu-id="f8848-122">Evaluate the next console in the list.</span></span>
3.  <span data-ttu-id="f8848-123">その本体がローカル本体の場合は、それを新しいアービターとして使用します。</span><span class="sxs-lookup"><span data-stu-id="f8848-123">If the console is the local console, use it as new the arbiter.</span></span>
4.  <span data-ttu-id="f8848-124">その本体がマルチプレイヤー セッション内にもう存在していない、またはそのピアから切断されている場合は、リスト内の次の候補に移動し、前の手順と同様にそれを評価します。</span><span class="sxs-lookup"><span data-stu-id="f8848-124">If the console is no longer present in the multiplayer session, or has disconnected from its peers, move on to the next candidate in the list and evaluate it as in the previous steps.</span></span>
5.  <span data-ttu-id="f8848-125">リストの末尾に達しても新しいアービターが選択されない場合は、アービター選択に対して、接続が切断される可能性がある greedy 法 (貪欲法) を使用します。</span><span class="sxs-lookup"><span data-stu-id="f8848-125">If reaching the end of the list with no new arbiter selected, use a greedy approach to arbiter selection, which can break connectivity.</span></span> <span data-ttu-id="f8848-126">「greedy 法 (貪欲法) によるアービター選択の使用」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8848-126">See "Use Greedy Arbiter Selection."</span></span>

| <span data-ttu-id="f8848-127">注意</span><span class="sxs-lookup"><span data-stu-id="f8848-127">Note</span></span>                                                                                                                                                                                                                                                                                    |
|------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="f8848-128">明示的なタイトル内 QoS プローブによってマッチメイキング後にゲーム内でホスト候補リストを作成することはお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="f8848-128">It is not recommended to create a host candidate list in-game after matchmaking through explicit in-title QoS probes.</span></span> <span data-ttu-id="f8848-129">このメカニズムがどうしても必要な場合は、クライアントが Xbox ユーザー ID などのユーザー情報の代わりにホスト デバイス トークンを使用してアービター候補を決定するようにします。</span><span class="sxs-lookup"><span data-stu-id="f8848-129">If this mechanism is absolutely necessary, have your client use the host device token instead of user information, for example, Xbox user ID, to determine arbiter candidates.</span></span> |


### <a name="select-arbiter-using-peer-voting"></a><span data-ttu-id="f8848-130">ピア投票を使用したアービターの選択</span><span class="sxs-lookup"><span data-stu-id="f8848-130">Select Arbiter Using Peer Voting</span></span>

<span data-ttu-id="f8848-131">すべてのピア間の完全な接続が存在する場合は、ピア メッセージを使用して新しいアービターの投票および選択を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="f8848-131">If full connectivity exists among all peers, they can use peer messages to vote and select a new arbiter.</span></span> <span data-ttu-id="f8848-132">新しいアービターは、同期更新を使用して、セッションのホスト デバイス トークンを更新します。</span><span class="sxs-lookup"><span data-stu-id="f8848-132">The new arbiter then updates the host device token for the session using a synchronized update.</span></span> <span data-ttu-id="f8848-133">「[方法: マルチプレイヤー セッションの更新](multiplayer-how-tos.md)」を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f8848-133">See [How to: Update a Multiplayer Session](multiplayer-how-tos.md).</span></span>


### <a name="use-greedy-arbiter-selection"></a><span data-ttu-id="f8848-134">greedy 法 (貪欲法) によるアービター選択の使用</span><span class="sxs-lookup"><span data-stu-id="f8848-134">Use Greedy Arbiter Selection</span></span>

<span data-ttu-id="f8848-135">使用可能なホスト候補リストがない、または接続 QoS が不要な場合 (たとえば、純粋なアービターの責任の場合) があります。</span><span class="sxs-lookup"><span data-stu-id="f8848-135">Sometimes no host candidate list is available or connectivity QoS is not needed, for example, for pure arbiter responsibilities.</span></span> <span data-ttu-id="f8848-136">このような場合は、クライアントは greedy 法 (貪欲法) によるアービター選択を使用できます。</span><span class="sxs-lookup"><span data-stu-id="f8848-136">In these cases, your client can use a greedy arbiter selection approach.</span></span> <span data-ttu-id="f8848-137">この場合、ピアは、**MultiplayerSessionChanged** イベントによって報告される、元のアービターがゲーム セッションを離れたことを検出するとすぐに、新しいアービターを設定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f8848-137">In this case, a peer should set the new arbiter as soon as it detects that the original arbiter has left the game session, as reported by the **MultiplayerSessionChanged** event.</span></span> <span data-ttu-id="f8848-138">他のすべてのピアは、この時点で他の変更がセッションに対して行われていないと仮定すると、ホスト デバイス トークンを設定しようとすると HTTP/412 ステータス コードを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="f8848-138">All other peers see an HTTP/412 status code when trying to set the host device token, assuming no other changes to the session are made at this point.</span></span> <span data-ttu-id="f8848-139">1 つのピアのみが、新しいアービターの選択に成功します。</span><span class="sxs-lookup"><span data-stu-id="f8848-139">Only one peer succeeds in selecting the new arbiter.</span></span>


## <a name="see-also"></a><span data-ttu-id="f8848-140">関連項目</span><span class="sxs-lookup"><span data-stu-id="f8848-140">See also</span></span>

[<span data-ttu-id="f8848-141">MPSD セッションの詳細</span><span class="sxs-lookup"><span data-stu-id="f8848-141">MPSD session details</span></span>](mpsd-session-details.md)
