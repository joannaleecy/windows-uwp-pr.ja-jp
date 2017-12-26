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
ms.localizationpriority: medium
ms.openlocfilehash: 559ea8e1d8c3d4cb01c2fdfc49996b347ec1683b
ms.sourcegitcommit: f9a4854b6aecfda472fb3f8b4a2d3b271b327800
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/12/2017
---
# <a name="arena-notifications"></a><span data-ttu-id="92947-104">アリーナによる通知</span><span class="sxs-lookup"><span data-stu-id="92947-104">Arena notifications</span></span>

<span data-ttu-id="92947-105">Xbox アリーナでは、アリーナのトーナメントに登録した参加者に対し、トーナメントの各ステージを案内するための通知を表示します。</span><span class="sxs-lookup"><span data-stu-id="92947-105">Xbox Arena surfaces notifications to participants registered for Arena tournaments, to usher them through the tournament stages.</span></span> <span data-ttu-id="92947-106">それ以外のアラート、プロモーション、ゲーム関連の詳細情報は、タイトルが提供する必要があります。</span><span class="sxs-lookup"><span data-stu-id="92947-106">Any additional alerts, promotion, or game-related details must be provided by your title.</span></span>

<span data-ttu-id="92947-107">登録</span><span class="sxs-lookup"><span data-stu-id="92947-107">REGISTRATION</span></span> | <span data-ttu-id="92947-108">チームの編成</span><span class="sxs-lookup"><span data-stu-id="92947-108">TEAM FORMATION</span></span> | <span data-ttu-id="92947-109">トーナメントの状態</span><span class="sxs-lookup"><span data-stu-id="92947-109">TOURNAMENT STATE</span></span>
--- | --- | ---
<span data-ttu-id="92947-110">Team ready to register (チームの登録準備が完了しました)</span><span class="sxs-lookup"><span data-stu-id="92947-110">Team ready to register</span></span> | <span data-ttu-id="92947-111">A player has joined the team (プレイヤーがチームに参加しました)</span><span class="sxs-lookup"><span data-stu-id="92947-111">A player has joined the team</span></span> | <span data-ttu-id="92947-112">Check-in started (チェックインが開始されました)</span><span class="sxs-lookup"><span data-stu-id="92947-112">Check-in started</span></span>
<span data-ttu-id="92947-113">Team registered (チームが登録されました)</span><span class="sxs-lookup"><span data-stu-id="92947-113">Team registered</span></span> | <span data-ttu-id="92947-114">A player has left the team (プレイヤーがチームから離脱しました)</span><span class="sxs-lookup"><span data-stu-id="92947-114">A player has left the team</span></span> | <span data-ttu-id="92947-115">Tournament started (トーナメントが開始されました)</span><span class="sxs-lookup"><span data-stu-id="92947-115">Tournament started</span></span>
<span data-ttu-id="92947-116">Check-in started (チェックインが開始されました)</span><span class="sxs-lookup"><span data-stu-id="92947-116">Check-in started</span></span> | <span data-ttu-id="92947-117">Invitations sent/rejected (招待が送信されました/拒否されました)</span><span class="sxs-lookup"><span data-stu-id="92947-117">Invitations sent/rejected</span></span> | <span data-ttu-id="92947-118">Tournament completed (トーナメントが終了しました)</span><span class="sxs-lookup"><span data-stu-id="92947-118">Tournament completed</span></span>
<span data-ttu-id="92947-119">Tournament starting (トーナメントが開始します)</span><span class="sxs-lookup"><span data-stu-id="92947-119">Tournament starting</span></span> | <span data-ttu-id="92947-120">A player requests to join a team (プレイヤーがチームへの参加を要求しています)</span><span class="sxs-lookup"><span data-stu-id="92947-120">A player requests to join a team</span></span> | <span data-ttu-id="92947-121">Tournament canceled (トーナメントがキャンセルされました)</span><span class="sxs-lookup"><span data-stu-id="92947-121">Tournament canceled</span></span>
<span data-ttu-id="92947-122">Match ready (マッチの準備が完了しました)</span><span class="sxs-lookup"><span data-stu-id="92947-122">Match ready</span></span> | <span data-ttu-id="92947-123">A player has been removed (プレイヤーが削除されました)</span><span class="sxs-lookup"><span data-stu-id="92947-123">A player has been removed</span></span> |
<span data-ttu-id="92947-124">A player has checked in (プレイヤーがチェックインしました)</span><span class="sxs-lookup"><span data-stu-id="92947-124">A player has checked in</span></span> | |
<span data-ttu-id="92947-125">A team has checked in (チームがチェックインしました)</span><span class="sxs-lookup"><span data-stu-id="92947-125">A team has checked in</span></span> | |
<span data-ttu-id="92947-126">A team has unregistered (チームが登録解除されました)</span><span class="sxs-lookup"><span data-stu-id="92947-126">A team has unregistered</span></span> | |