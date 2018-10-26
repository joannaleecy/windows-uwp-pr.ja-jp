---
title: トーナメントへの参加
author: KevinAsgari
description: プレイヤーがゲームのトーナメントに参加するための UI の作成方法について説明します。
ms.author: kevinasg
ms.date: 10-10-2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アリーナ, トーナメント, UX
ms.localizationpriority: medium
ms.openlocfilehash: 701545085f095bd9c26598ac063780c49ee94c0d
ms.sourcegitcommit: 6cc275f2151f78db40c11ace381ee2d35f0155f9
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/26/2018
ms.locfileid: "5558779"
---
# <a name="join-a-tournament-by-using-the-arena-ui"></a><span data-ttu-id="84ee4-104">アリーナ UI を使ってトーナメントに参加する</span><span class="sxs-lookup"><span data-stu-id="84ee4-104">Join a tournament by using the Arena UI</span></span>

<span data-ttu-id="84ee4-105">アリーナ API は、登録、チェックイン、チームに関する情報をタイトルに提供できますが、それに関する*タスクを実行する機能*は*備えていません*。</span><span class="sxs-lookup"><span data-stu-id="84ee4-105">The Arena APIs can provide your title with data about registration, check-in, and team info, but they *don’t* provide the functionality to *execute* the related tasks.</span></span> <span data-ttu-id="84ee4-106">タイトルでは、アリーナ UI または第三者のトーナメント主催者 (TO) を使用するか、独自のトーナメント管理サポートを構築する必要があります。</span><span class="sxs-lookup"><span data-stu-id="84ee4-106">Your title is expected to use the Arena UI or a third-party Tournament Organizer (TO), or to build their own tournament-management support.</span></span>

## <a name="xbox-arena-ui-team-formation"></a><span data-ttu-id="84ee4-107">Xbox アリーナ UI: チームの編成</span><span class="sxs-lookup"><span data-stu-id="84ee4-107">Xbox Arena UI: Team formation</span></span>

<span data-ttu-id="84ee4-108">アリーナ UI は、ゲーマーがチームを編成したり、チームに参加したりする方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="84ee4-108">The Arena UI provides a method for gamers to form or a join a team.</span></span> <span data-ttu-id="84ee4-109">タイトルについての要件はありません。</span><span class="sxs-lookup"><span data-stu-id="84ee4-109">There is no requirement for the title.</span></span>

###### <a name="ui-example-create-a-team"></a><span data-ttu-id="84ee4-110">UI の例: チームの作成</span><span class="sxs-lookup"><span data-stu-id="84ee4-110">UI Example: Create a team</span></span>

![チーム編成画面](../../images/arena/arena-ux-create-team.png)

#### <a name="when-forming-a-team-a-gamer-can"></a><span data-ttu-id="84ee4-112">チームの編成時に、ゲーマーは次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="84ee4-112">When forming a team, a gamer can:</span></span>

* <span data-ttu-id="84ee4-113">1 人または複数のフレンドやクラブ メンバーに、参加の招待を送信する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-113">Send invitations to join to one or more friends or club members.</span></span>
* <span data-ttu-id="84ee4-114">LFG 広告を投稿して、チーム メンバーを募集する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-114">Find team members by posting an LFG ad.</span></span>
* <span data-ttu-id="84ee4-115">チームを登録または登録解除する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-115">Register or unregister a team.</span></span>
* <span data-ttu-id="84ee4-116">チームのメンバーを削除する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-116">Remove a member of a team.</span></span>

## <a name="xbox-arena-ui-registration"></a><span data-ttu-id="84ee4-117">Xbox アリーナ UI: 登録</span><span class="sxs-lookup"><span data-stu-id="84ee4-117">Xbox Arena UI: Registration</span></span>

<span data-ttu-id="84ee4-118">アリーナ UI は、ゲーマーがチームを登録する方法を提供します。</span><span class="sxs-lookup"><span data-stu-id="84ee4-118">The Arena UI provides a method for gamers to register a team.</span></span> <span data-ttu-id="84ee4-119">タイトルについての要件はありません。</span><span class="sxs-lookup"><span data-stu-id="84ee4-119">There is no requirement for the title.</span></span>

###### <a name="ui-example-register-a-team"></a><span data-ttu-id="84ee4-120">UI の例: チームの登録</span><span class="sxs-lookup"><span data-stu-id="84ee4-120">UI Example: Register a team</span></span>

![チーム登録画面](../../images/arena/arena-ux-register-team.png)

#### <a name="when-registering-for-a-tournament-a-user-can"></a><span data-ttu-id="84ee4-122">トーナメントへの登録時、ユーザーは次の操作を実行できます。</span><span class="sxs-lookup"><span data-stu-id="84ee4-122">When registering for a tournament, a user can:</span></span>

* <span data-ttu-id="84ee4-123">登録受付の*締め切り前*に、トーナメントへの登録を解除する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-123">Unregister for a tournament *before* registration has closed.</span></span>
* <span data-ttu-id="84ee4-124">チェックイン時またはトーナメント進行中にチームの登録を解除する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-124">Unregister a team at check-in or when the tournament is in progress.</span></span>
* <span data-ttu-id="84ee4-125">チーム全体の登録を解除する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-125">Unregister an entire team.</span></span> *<span data-ttu-id="84ee4-126">個別のユーザーがチームを離脱すると、チーム全体の登録が解除されることに注意してください。</span><span class="sxs-lookup"><span data-stu-id="84ee4-126">Note that an individual user leaving a team unregisters the whole team.</span></span>*
* <span data-ttu-id="84ee4-127">キャプテンとして登録する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-127">Register as a captain.</span></span>
* <span data-ttu-id="84ee4-128">登録前に、トーナメントの要件と交戦ルールを確認する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-128">Understand the tournament requirements and rules of engagement prior to registering.</span></span>
* <span data-ttu-id="84ee4-129">登録が正常に完了したことの通知を受信する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-129">Receive a notification that registration was successful.</span></span>
* <span data-ttu-id="84ee4-130">トーナメントのステータスが "registered" (登録済み) に変更されたことをリアルタイムで確認する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-130">See the tournament status change to 'registered' in real time.</span></span>
* <span data-ttu-id="84ee4-131">トーナメントの開始時に、対戦表をプレビューする。</span><span class="sxs-lookup"><span data-stu-id="84ee4-131">Preview the bracket at the time a tournament starts.</span></span>
* <span data-ttu-id="84ee4-132">トーナメントに登録済みのプレイヤーを参照する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-132">See players who have already registered for the tournament.</span></span>
* <span data-ttu-id="84ee4-133">それらのプレイヤーがトーナメントの条件を満たしていない場合、登録を拒否する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-133">Be blocked from registering if they do not meet the tournament qualifications.</span></span>
* <span data-ttu-id="84ee4-134">プレイヤーが登録を禁止されている場合、登録を拒否する。</span><span class="sxs-lookup"><span data-stu-id="84ee4-134">Be blocked from registering if a player has been banned.</span></span>

> [!div class="nextstepaction"]
> [<span data-ttu-id="84ee4-135">マッチの交戦</span><span class="sxs-lookup"><span data-stu-id="84ee4-135">Match engagement</span></span>](arena-ux-match-engagement.md)
