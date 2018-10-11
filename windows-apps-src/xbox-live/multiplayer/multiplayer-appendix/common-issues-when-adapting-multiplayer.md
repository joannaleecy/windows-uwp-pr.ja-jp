---
title: マルチプレイヤー 2015 への移行に関する一般的な問題
author: KevinAsgari
description: マルチプレイヤー 2014 のタイトルを 2015 マルチプレイヤーに適合させるときに発生する可能性のある一般的な問題について説明します。
ms.assetid: 206f8fe4-c7aa-44b8-923b-18f679d8439f
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: medium
ms.openlocfilehash: 5ada600bbfec4b8a1a8faa03ac3b71c6fc2d8fff
ms.sourcegitcommit: 933e71a31989f8063b020746fdd16e9da94a44c4
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/11/2018
ms.locfileid: "4533174"
---
# <a name="common-issues-when-adapting-your-multiplayer-2014-title-to-multiplayer-2015"></a><span data-ttu-id="6d352-104">マルチプレイヤー 2014 のタイトルをマルチプレイヤー 2015 に適合させるときの一般的な問題</span><span class="sxs-lookup"><span data-stu-id="6d352-104">Common issues When adapting your multiplayer 2014 title to multiplayer 2015</span></span>

<span data-ttu-id="6d352-105">ここでは、2014 マルチプレイヤー タイトルを 2015 マルチプレイヤーに適合させるときに考慮する必要がある問題について説明します。</span><span class="sxs-lookup"><span data-stu-id="6d352-105">This topic describes issues that you must consider when adapting your 2014 Multiplayer titles for 2015 Multiplayer.</span></span>


## <a name="configuration-changes-to-make-for-2015-multiplayer"></a><span data-ttu-id="6d352-106">2015 マルチプレイヤーに適合させるための構成の変更</span><span class="sxs-lookup"><span data-stu-id="6d352-106">Configuration Changes to Make for 2015 Multiplayer</span></span>

<span data-ttu-id="6d352-107">ここでは、2015 マルチプレイヤーのセッションとテンプレートを構成するときに注意する必要がある変更について説明します。</span><span class="sxs-lookup"><span data-stu-id="6d352-107">This section describes changes to be aware of when configuring your sessions and templates for 2015 Multiplayer.</span></span> <span data-ttu-id="6d352-108">説明している各項目の例については、「[MPSD セッション テンプレート](multiplayer-session-directory.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6d352-108">For examples of the specific items discussed, see [MPSD Session Templates](multiplayer-session-directory.md).</span></span>

### <a name="add-a-capability-for-active-member-connection"></a><span data-ttu-id="6d352-109">アクティブ メンバー接続の機能の追加</span><span class="sxs-lookup"><span data-stu-id="6d352-109">Add a Capability for Active Member Connection</span></span>

<span data-ttu-id="6d352-110">connectionRequiredForActiveMembers 機能により、2015 マルチプレイヤーの切断検出機能とセッション変更サブスクリプション機能が有効になります。</span><span class="sxs-lookup"><span data-stu-id="6d352-110">The connectionRequiredForActiveMembers capability enables the disconnect detection and session change subscription features of 2015 Multiplayer.</span></span> <span data-ttu-id="6d352-111">すべてのセッション テンプレートの /constants/system/capabilities オブジェクトにこの機能を追加してください。</span><span class="sxs-lookup"><span data-stu-id="6d352-111">Add this capability to the /constants/system/capabilities object for all session templates.</span></span>


### <a name="add-a-system-constant-for-invite-protocol"></a><span data-ttu-id="6d352-112">招待プロトコルのシステム定数の追加</span><span class="sxs-lookup"><span data-stu-id="6d352-112">Add a System Constant for Invite Protocol</span></span>

<span data-ttu-id="6d352-113">inviteProtocol システム定数を追加すると、送信者のタイトルで **MultiplayerService.SendInvitesAsync メソッド**または **SystemUI.ShowSendGameInvitesAsync メソッド (IUser, IMultiplayerSessionReference, String)** が呼び出されたときに、招待の受信者がトーストを受信できるようになります。</span><span class="sxs-lookup"><span data-stu-id="6d352-113">The inviteProtocol system constant enables the recipient of an invite to receive a toast when the sender's title calls the **MultiplayerService.SendInvitesAsync Method** or the **SystemUI.ShowSendGameInvitesAsync Method (IUser, IMultiplayerSessionReference, String)**.</span></span> <span data-ttu-id="6d352-114">タイトルでプレイヤーを招待するセッションについて、すべてのテンプレートの /constants/system オブジェクトにこの定数 ("game" に設定) を追加してください。</span><span class="sxs-lookup"><span data-stu-id="6d352-114">Add this constant, set to "game", to the /constants/system object for all templates for sessions to which the title invites players.</span></span>


## <a name="runtime-considerations-for-2015-multiplayer"></a><span data-ttu-id="6d352-115">2015 マルチプレイヤーに関する実行時の考慮事項</span><span class="sxs-lookup"><span data-stu-id="6d352-115">Runtime Considerations for 2015 Multiplayer</span></span>

<span data-ttu-id="6d352-116">2015 マルチプレイヤー用のタイトルでは、タイトル コードのマルチプレイヤー エリアに入る前に必ず **MultiplayerService.EnableMultiplayerSubscriptions メソッド**を呼び出す必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d352-116">Titles for 2015 Multiplayer must:   Always call the **MultiplayerService.EnableMultiplayerSubscriptions Method** prior to entering the multiplayer area of the title code.</span></span> <span data-ttu-id="6d352-117">この呼び出しによって、セッション変更のサブスクリプションと切断検出の両方が有効になります。</span><span class="sxs-lookup"><span data-stu-id="6d352-117">This call enables both subscriptions to session changes and disconnect detection.</span></span>
-   <span data-ttu-id="6d352-118">同じユーザーによる呼び出しには必ず同じ **XboxLiveContext クラス**のオブジェクトを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d352-118">Be sure to use the same **XboxLiveContext Class** object for all calls by the same user.</span></span> <span data-ttu-id="6d352-119">このコンテキストには、マルチプレイヤーのサブスクリプションと切断検出で使用される接続の管理に関連する状態が含まれます。</span><span class="sxs-lookup"><span data-stu-id="6d352-119">The context contains state related to the management of the connection used for multiplayer subscriptions and disconnect detection.</span></span>
-   <span data-ttu-id="6d352-120">複数のローカル ユーザーが存在する場合は、ユーザーごとに個別の **XboxLiveContext** オブジェクトを使用します。</span><span class="sxs-lookup"><span data-stu-id="6d352-120">If there are multiple local users, use a separate **XboxLiveContext** object for each user.</span></span>


## <a name="migrating-a-session-template-from-contract-version-104105-to-107"></a><span data-ttu-id="6d352-121">コントラクト バージョン 104/105 から 107 へのセッション テンプレートの移行</span><span class="sxs-lookup"><span data-stu-id="6d352-121">Migrating a Session Template from Contract Version 104/105 to 107</span></span>

<span data-ttu-id="6d352-122">セッション テンプレート コントラクトの最新バージョンは 107 で、MPSD に使用されるスキーマの一部に変更があります。</span><span class="sxs-lookup"><span data-stu-id="6d352-122">The latest session template contract version is 107, with some changes to the schema used for MPSD.</span></span> <span data-ttu-id="6d352-123">セッション テンプレート コントラクト バージョン 104/105 に合わせて作成したテンプレートを再発行してバージョン 107 を使用する場合は、そのテンプレートを更新する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d352-123">Templates that you have written for session template contract version 104/105 must be updated if they are republished to use version 107.</span></span> <span data-ttu-id="6d352-124">ここでは、テンプレートを最新バージョンに移行するときに行う変更の概要について説明します。</span><span class="sxs-lookup"><span data-stu-id="6d352-124">This topic summarizes the changes to make in migrating your templates to the latest version.</span></span> <span data-ttu-id="6d352-125">テンプレートについては、「[MPSD セッション テンプレート](multiplayer-session-directory.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="6d352-125">The templates themselves are described in [MPSD Session Templates](multiplayer-session-directory.md).</span></span>

| <span data-ttu-id="6d352-126">重要</span><span class="sxs-lookup"><span data-stu-id="6d352-126">Important</span></span>                                                                                                                                                                                                                                                      |
|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| <span data-ttu-id="6d352-127">テンプレートを使用して設定された機能は、MPSD への書き込みによって変更できません。</span><span class="sxs-lookup"><span data-stu-id="6d352-127">Functionality that is set through a template cannot be changed through writes to MPSD.</span></span> <span data-ttu-id="6d352-128">値を変更するには、必要な変更を行った新しいテンプレートを作成し、送信する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d352-128">To change the values, you must create and submit a new template with the necessary changes.</span></span> <span data-ttu-id="6d352-129">テンプレートで設定されない項目はすべて、MPSD への書き込みによって変更できます。</span><span class="sxs-lookup"><span data-stu-id="6d352-129">Any items that are not set through a template can be changed through writes to the MPSD.</span></span> |


### <a name="changes-to-the-constantssystemmanagedinitialization-object"></a><span data-ttu-id="6d352-130">/constants/system/managedInitialization オブジェクトへの変更</span><span class="sxs-lookup"><span data-stu-id="6d352-130">Changes to the /constants/system/managedInitialization Object</span></span>

<span data-ttu-id="6d352-131">/constants/system/managedInitialization オブジェクトの名前は /constants/system/memberInitialization に変更されています。</span><span class="sxs-lookup"><span data-stu-id="6d352-131">The /constants/system/managedInitialization object has been renamed to /constants/system/memberInitialization.</span></span> <span data-ttu-id="6d352-132">このオブジェクトの名前/値ペアに行う変更は次のとおりです。autoEvaluate は externalEvaluation に名前を変更します。</span><span class="sxs-lookup"><span data-stu-id="6d352-132">Here are the changes to make to the name/value pairs for this object:   autoEvaluate is renamed to externalEvaluation.</span></span> <span data-ttu-id="6d352-133">その極性が変化します。ただし、false は既定値のままです。</span><span class="sxs-lookup"><span data-stu-id="6d352-133">Its polarity changes, except that false remains the default.</span></span>
-   <span data-ttu-id="6d352-134">membersNeededToStart の既定値を 2 から 1 に変更します。</span><span class="sxs-lookup"><span data-stu-id="6d352-134">The default value of membersNeededToStart changes from 2 to 1.</span></span>
-   <span data-ttu-id="6d352-135">joinTimeout の既定値を 5 秒から 10 秒に変更します。</span><span class="sxs-lookup"><span data-stu-id="6d352-135">The default value of joinTimeout changes from 5 seconds to 10 seconds.</span></span>
-   <span data-ttu-id="6d352-136">measurementTimeout の既定値を 5 秒から 30 秒に変更します。</span><span class="sxs-lookup"><span data-stu-id="6d352-136">The default value of measurementTimeout changes from 5 seconds to 30 seconds.</span></span>


### <a name="changes-to-the-constantssystemtimeouts-object"></a><span data-ttu-id="6d352-137">/constants/system/timeouts オブジェクトへの変更</span><span class="sxs-lookup"><span data-stu-id="6d352-137">Changes to the /constants/system/timeouts Object</span></span>

<span data-ttu-id="6d352-138">/constants/system/timeouts オブジェクトは削除され、timeouts の名前は変更され、/constants/system に再配置されます。</span><span class="sxs-lookup"><span data-stu-id="6d352-138">The /constants/system/timeouts object is removed, and the timeouts are renamed and relocated under /constants/system.</span></span> <span data-ttu-id="6d352-139">このオブジェクトの名前/値ペアに行う変更は次のとおりです。予約タイムアウトは reservedRemovalTimeout になります。</span><span class="sxs-lookup"><span data-stu-id="6d352-139">Here are the changes to make to the name/value pairs for this object:   The reserved timeout becomes reservedRemovalTimeout.</span></span>
-   <span data-ttu-id="6d352-140">非アクティブ タイムアウトは inactiveRemovalTimeout になります。</span><span class="sxs-lookup"><span data-stu-id="6d352-140">The inactive timeout becomes inactiveRemovalTimeout.</span></span> <span data-ttu-id="6d352-141">新しい既定値は 0 (時間単位) です。</span><span class="sxs-lookup"><span data-stu-id="6d352-141">Its new default is 0 (hours).</span></span>
-   <span data-ttu-id="6d352-142">ready タイムアウトは readyRemovalTimeout になります。</span><span class="sxs-lookup"><span data-stu-id="6d352-142">The ready timeout becomes readyRemovalTimeout.</span></span>
-   <span data-ttu-id="6d352-143">sessionEmpty タイムアウトは sessionEmptyTimeout になります。</span><span class="sxs-lookup"><span data-stu-id="6d352-143">The sessionEmpty timeout becomes sessionEmptyTimeout.</span></span>

<span data-ttu-id="6d352-144">タイムアウトの詳細については、「[セッション タイムアウト](mpsd-session-details.md)」に記載されています。</span><span class="sxs-lookup"><span data-stu-id="6d352-144">Details of the timeouts are presented in [Session Timeouts](mpsd-session-details.md).</span></span>


### <a name="change-to-the-game-play-capability"></a><span data-ttu-id="6d352-145">ゲーム プレイ機能への変更</span><span class="sxs-lookup"><span data-stu-id="6d352-145">Change to the Game Play Capability</span></span>

<span data-ttu-id="6d352-146">ゲーム プレイ機能は、最近のプレイヤーと評判のレポートを有効にします。</span><span class="sxs-lookup"><span data-stu-id="6d352-146">The game play capability enables recent players and reputation reporting.</span></span> <span data-ttu-id="6d352-147">マッチ セッション、ロビー セッションなどのヘルパー セッションとは対照的に、実際のゲーム プレイを表すセッションでは、/constants/system/capabilities/gameplay フィールドを true に指定する必要があります。</span><span class="sxs-lookup"><span data-stu-id="6d352-147">You must now specify the /constants/system/capabilities/gameplay field as true on sessions that represent actual game play, as opposed to helper sessions, for example, match and lobby sessions.</span></span>


## <a name="see-also"></a><span data-ttu-id="6d352-148">関連項目</span><span class="sxs-lookup"><span data-stu-id="6d352-148">See also</span></span>

[<span data-ttu-id="6d352-149">MPSD セッション テンプレート</span><span class="sxs-lookup"><span data-stu-id="6d352-149">MPSD Session Templates</span></span>](mpsd-session-details.md)
