---
title: "アリーナによる通知"
author: KevinAsgari
description: "トーナメントの各ステージの進行に伴って、プレイヤーに表示される Xbox アリーナの通知について説明します。"
ms.author: kevinasg
ms.date: 10-10-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, アリーナ, トーナメント, UX"
localizationpriority: medium
ms.openlocfilehash: bfc1608cfdd2b65e7150b5d30c86f780e02310fa
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
# <a name="arena-notifications"></a><span data-ttu-id="ad8c0-104">アリーナによる通知</span><span class="sxs-lookup"><span data-stu-id="ad8c0-104">Arena notifications</span></span>

<span data-ttu-id="ad8c0-105">Xbox アリーナでは、アリーナのトーナメントに登録した参加者に対し、トーナメントの各ステージを案内するための通知を表示します。</span><span class="sxs-lookup"><span data-stu-id="ad8c0-105">Xbox Arena surfaces notifications to participants registered for Arena tournaments, to usher them through the tournament stages.</span></span> <span data-ttu-id="ad8c0-106">それ以外のアラート、プロモーション、ゲーム関連の詳細情報は、タイトルが提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="ad8c0-106">Any additional alerts, promotion, or game-related details must be provided by your title.</span></span>

<span data-ttu-id="ad8c0-107">登録</span><span class="sxs-lookup"><span data-stu-id="ad8c0-107">REGISTRATION</span></span> | <span data-ttu-id="ad8c0-108">チームの編成</span><span class="sxs-lookup"><span data-stu-id="ad8c0-108">TEAM FORMATION</span></span> | <span data-ttu-id="ad8c0-109">トーナメントの状態</span><span class="sxs-lookup"><span data-stu-id="ad8c0-109">TOURNAMENT STATE</span></span>
--- | --- | ---
<span data-ttu-id="ad8c0-110">Team ready to register (チームの登録準備が完了しました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-110">Team ready to register</span></span> | <span data-ttu-id="ad8c0-111">A player has joined the team (プレイヤーがチームに参加しました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-111">A player has joined the team</span></span> | <span data-ttu-id="ad8c0-112">Check-in started (チェックインが開始されました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-112">Check-in started</span></span>
<span data-ttu-id="ad8c0-113">Team registered (チームが登録されました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-113">Team registered</span></span> | <span data-ttu-id="ad8c0-114">A player has left the team (プレイヤーがチームから離脱しました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-114">A player has left the team</span></span> | <span data-ttu-id="ad8c0-115">Tournament started (トーナメントが開始されました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-115">Tournament started</span></span>
<span data-ttu-id="ad8c0-116">Check-in started (チェックインが開始されました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-116">Check-in started</span></span> | <span data-ttu-id="ad8c0-117">Invitations sent/rejected (招待が送信されました/拒否されました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-117">Invitations sent/rejected</span></span> | <span data-ttu-id="ad8c0-118">Tournament completed (トーナメントが終了しました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-118">Tournament completed</span></span>
<span data-ttu-id="ad8c0-119">Tournament starting (トーナメントが開始します)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-119">Tournament starting</span></span> | <span data-ttu-id="ad8c0-120">A player requests to join a team (プレイヤーがチームへの参加を要求しています)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-120">A player requests to join a team</span></span> | <span data-ttu-id="ad8c0-121">Tournament canceled (トーナメントがキャンセルされました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-121">Tournament canceled</span></span>
<span data-ttu-id="ad8c0-122">Match ready (マッチの準備が完了しました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-122">Match ready</span></span> | <span data-ttu-id="ad8c0-123">A player has been removed (プレイヤーが削除されました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-123">A player has been removed</span></span> |
<span data-ttu-id="ad8c0-124">A player has checked in (プレイヤーがチェックインしました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-124">A player has checked in</span></span> | |
<span data-ttu-id="ad8c0-125">A team has checked in (チームがチェックインしました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-125">A team has checked in</span></span> | |
<span data-ttu-id="ad8c0-126">A team has unregistered (チームが登録解除されました)</span><span class="sxs-lookup"><span data-stu-id="ad8c0-126">A team has unregistered</span></span> | |
