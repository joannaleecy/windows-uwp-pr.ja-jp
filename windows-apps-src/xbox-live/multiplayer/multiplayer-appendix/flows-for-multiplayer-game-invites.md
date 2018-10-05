---
title: マルチプレイヤー ゲームへの招待に関する更新されたフロー
author: KevinAsgari
description: Xbox Live のマルチプレイヤー ゲームへの招待を改善するために更新されたフローを説明します。
ms.assetid: 1569588e-3bbc-47d3-8b7d-cc9774071adc
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, マルチプレイヤー 2015
ms.localizationpriority: medium
ms.openlocfilehash: 66de8c34857d667b66cdfb091f83106fed777279
ms.sourcegitcommit: 63cef0a7805f1594984da4d4ff2f76894f12d942
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/05/2018
ms.locfileid: "4386415"
---
# <a name="updated-flows-for-multiplayer-game-invites"></a><span data-ttu-id="613f1-104">マルチプレイヤー ゲームへの招待に関する更新されたフロー</span><span class="sxs-lookup"><span data-stu-id="613f1-104">Updated Flows For Multiplayer Game Invites</span></span>

<span data-ttu-id="613f1-105">Xbox One ベータ フィードバックの結果として、2013 年 11 月 6 日にリリースされた Xbox One Recovery Update 24 で、マルチプレイヤー ゲームへの招待のユーザー エクスペリエンス フローが変更されました。</span><span class="sxs-lookup"><span data-stu-id="613f1-105">As a result of Xbox One beta feedback, the user experience flow for multiplayer game invites has been changed as of Xbox One Recovery Update 24, released on November 6, 2013.</span></span> <span data-ttu-id="613f1-106">この変更は**ユーザー エクスペリエンス (UX) のみ**に限定され、ゲーム タイトルから見た動作や機能には影響しません。</span><span class="sxs-lookup"><span data-stu-id="613f1-106">This is a change to the **user-experience (UX) only** and will not affect any behavior or functionality from the perspective of a game title.</span></span> <span data-ttu-id="613f1-107">タイトル デベロッパーがコードを変更する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="613f1-107">Title developers will not need to make any code changes.</span></span>

## <a name="summary-of-changes"></a><span data-ttu-id="613f1-108">変更の概要</span><span class="sxs-lookup"><span data-stu-id="613f1-108">Summary of changes</span></span>

-   <span data-ttu-id="613f1-109">最初の招待トーストが [join my party] (パーティーに参加) から [&lt;ゲーム タイトル&gt; Let’s Play] (プレイしよう) に変更され、ユーザーがゲームプレイをすぐに開始できるボタンが用意されました。</span><span class="sxs-lookup"><span data-stu-id="613f1-109">The initial invitation toast has changed from “join my party” to “&lt;game title&gt; Let’s Play” and now has a button that allows users to launch the game and jump right into gameplay.</span></span>

-   <span data-ttu-id="613f1-110">ユーザーが新しい [&lt;ゲーム タイトル&gt; Let’s Play] (プレイしよう) オプションを選択した場合、パーティー アプリは既定ではスナップされません。</span><span class="sxs-lookup"><span data-stu-id="613f1-110">The Party app is not snapped by default when the user chooses the new “&lt;game title&gt; Let’s Play” option.</span></span> <span data-ttu-id="613f1-111">この変更のもう 1 つの目的は、ユーザーがゲームプレイにすぐに参加できるようにすることです。</span><span class="sxs-lookup"><span data-stu-id="613f1-111">This change is also made so that the user can jump right into gameplay.</span></span>

-   <span data-ttu-id="613f1-112">送信者側には、[Adding \[*人数*\] friends to the game] ([人数] 人のフレンドをゲームに追加) という新しいトーストが追加されました。</span><span class="sxs-lookup"><span data-stu-id="613f1-112">A new toast has been added on the sender’s side that says “Adding \[*number*\] friends to the game”.</span></span> <span data-ttu-id="613f1-113">これにより、ゲーム セッションがユーザーのパーティーと関連付けられている場合、招待が送信されたことがはっきりわかるようになります。</span><span class="sxs-lookup"><span data-stu-id="613f1-113">This makes it clear that invites were sent out when a game session is associated with a user’s party.</span></span>

<span data-ttu-id="613f1-114">以下の例では、詳細なユーザー エクスペリエンス フローについて説明します。</span><span class="sxs-lookup"><span data-stu-id="613f1-114">The detailed user experience flows are described in the following examples.</span></span> <span data-ttu-id="613f1-115">各表では、2 人のユーザー David と Laura に関するフローの例を示します。</span><span class="sxs-lookup"><span data-stu-id="613f1-115">Each table shows an example flow for two users, David and Laura.</span></span> <span data-ttu-id="613f1-116">これらフローは各列で示されており、並行して行われます。</span><span class="sxs-lookup"><span data-stu-id="613f1-116">These flows are shown in each column and occur in parallel.</span></span> <span data-ttu-id="613f1-117"><b style="background-color: #FFFF00">強調表示されているテキスト</b>は、以前の UX フローから調整が行われたことを示します。</span><span class="sxs-lookup"><span data-stu-id="613f1-117">The <b style="background-color: #FFFF00">highlighted text</b> shows the adjustments that have been made from the prior UX flows.</span></span>

## <a name="inviting-users-from-within-a-game"></a><span data-ttu-id="613f1-118">ゲーム内からのユーザーの招待</span><span class="sxs-lookup"><span data-stu-id="613f1-118">Inviting users from within a game</span></span>

<table>
  <tr>
    <td style="border-bottom:solid 1px #fff">
<span data-ttu-id="613f1-119">David は、自分がプレイしているゲームのマルチプレイヤー ロビーにいます。</span><span class="sxs-lookup"><span data-stu-id="613f1-119">David is in the multiplayer lobby for a game he is playing.</span></span><p><br><span data-ttu-id="613f1-120">David は <b>[Invite a Friend]</b> (フレンドを招待する) を選択します。</span><span class="sxs-lookup"><span data-stu-id="613f1-120">David chooses <b>Invite a Friend</b>.</span></span><p><br><span data-ttu-id="613f1-121">David は Laura を選択します。</span><span class="sxs-lookup"><span data-stu-id="613f1-121">David selects Laura.</span></span><p><br><span data-ttu-id="613f1-122">招待が送信されたことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-122">Toast pops up indicating that an invite was sent.</span></span> <span data-ttu-id="613f1-123">| Laura は別のゲームをプレイしています。</span><span class="sxs-lookup"><span data-stu-id="613f1-123">| Laura is playing a different game.</span></span>
    </td>
    <td style="border-bottom:solid 1px #fff">
<span data-ttu-id="613f1-124">Laura は別のゲームをプレイしています。</span><span class="sxs-lookup"><span data-stu-id="613f1-124">Laura is playing a different game.</span></span>
    </td>
  </tr>
  <tr>
    <td></td>
    <td>
<span data-ttu-id="613f1-125">David からの招待を示すトーストが表示され、<b style="background-color: #FFFF00">ゲームの名前とアイコンが表示されます</b> </span><span class="sxs-lookup"><span data-stu-id="613f1-125">Toast pops up indicating an invitation from David, and <b style="background-color: #FFFF00">displays the game name and icon</b>.</span></span> <span data-ttu-id="613f1-126">(パーティー アプリは自動スナップしません)。</span><span class="sxs-lookup"><span data-stu-id="613f1-126">(The Party app does not auto-snap.)</span></span> <p><br>
<span data-ttu-id="613f1-127">通知センターで、Laura は <b style="background-color: #FFFF00">[Launch and accept invite] (起動して招待を受ける)</b>、<b>[Accept invite] (招待を受ける)</b>、または <b style="background-color: #FFFF00">[Decline Invite] (招待を断る)</b>を選択できます。</span><span class="sxs-lookup"><span data-stu-id="613f1-127">In the Notification Center, <b style="background-color: #FFFF00">Laura can choose Launch and accept invite</b>, <b>Accept invite</b>, or <b style="background-color: #FFFF00">Decline Invite</b>.</span></span>
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align:center"><span data-ttu-id="613f1-128"><b style="background-color: #FFFF00">ケース 1: Laura が [Launch and accept invite] (起動して招待を承諾) を選択する</b> (これは新しいオプションです)</span><span class="sxs-lookup"><span data-stu-id="613f1-128"><b style="background-color: #FFFF00">Case 1: Laura selects Launch and accept invite</b> (This is a new option)</span></span></td>
  </tr>
  <tr>
    <td>
<span data-ttu-id="613f1-129">Laura が David のパーティーに参加したことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-129">Toast pops up indicating that Laura has joined David’s party.</span></span>             
    <p><br>
<span data-ttu-id="613f1-130">David はマルチプレイヤー ロビーからゲームを開始します。</span><span class="sxs-lookup"><span data-stu-id="613f1-130">David starts the game from multiplayer lobby.</span></span>                              
    <p><br>
    <b style="background-color: #FFFF00"><span data-ttu-id="613f1-131">ゲームへの招待が Laura に送信されたことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-131">Toast pops up indicating that a game invite was sent to Laura.</span></span></b>
    </td>
    <td>
<span data-ttu-id="613f1-132">ゲームが起動し、パーティー アプリはスナップしません。</span><span class="sxs-lookup"><span data-stu-id="613f1-132">The game launches and the Party app does not snap.</span></span>
    </td>
  </tr>
  <tr>
    <td colspan="2" style="text-align:center"><b><span data-ttu-id="613f1-133">ケース 2: Laura が [Accept invite] (招待を受ける) を選択する</span><span class="sxs-lookup"><span data-stu-id="613f1-133">Case 2: Laura selects Accept invite</span></span></b></td>
  </tr>
  <tr>
    <td style="border-bottom:solid 1px #fff"></td>
    <td style="border-bottom:solid 1px #fff"><span data-ttu-id="613f1-134">Laura がパーティーに参加します。</span><span class="sxs-lookup"><span data-stu-id="613f1-134">Laura joins the party.</span></span></td>
  </tr>
  <tr>
    <td style="border-bottom:solid 1px #fff"><b style="background-color: #FFFF00"><span data-ttu-id="613f1-135">ゲームへの招待が Laura に送信されたことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-135">Toast pops up indicating that a game invite was sent to Laura.</span></span></b></td>
    <td style="border-bottom:solid 1px #fff"></td>
  </tr>
  <tr>
    <td></td>
    <td><span data-ttu-id="613f1-136">そのパーティーに対するゲームが見つかったことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-136">Toast pops up indicating that a game was found for the party.</span></span>
    <p><br>
<span data-ttu-id="613f1-137">通知センターで、Laura は以下を選択できます。</span><span class="sxs-lookup"><span data-stu-id="613f1-137">In the Notification Center, Laura can choose:</span></span> <ul>
    <li>   <span data-ttu-id="613f1-138"><b>[ゲームへの招待を受ける]:</b> ゲームが起動します。</span><span class="sxs-lookup"><span data-stu-id="613f1-138"><b>Accept game invite:</b> Game launches.</span></span>
    <li>   <span data-ttu-id="613f1-139"><b>[ゲームへの招待を断る]:</b> ゲームは起動しません。</span><span class="sxs-lookup"><span data-stu-id="613f1-139"><b>Decline game invite:</b> No game launches.</span></span> <span data-ttu-id="613f1-140">Laura はまだパーティー内にいて、その後のゲームへの招待を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="613f1-140">Laura is still in the party and will receive subsequent game invites.</span></span>         
    <li>   <b style="background-color: #FFFF00"><span data-ttu-id="613f1-141">[パーティーから出る]: ゲームは起動しません。</span><span class="sxs-lookup"><span data-stu-id="613f1-141">Leave party: No game launches.</span></span> <span data-ttu-id="613f1-142">Laura はパーティーから削除されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-142">Laura is removed from the party.</span></span></b>
    </ul>
    </td>
  </tr>
</table>

## <a name="in-game-invite-flow-in-a-party-and-switching-titles"></a><span data-ttu-id="613f1-143">ゲーム内招待のフロー: パーティー内でのタイトルの切り替え</span><span class="sxs-lookup"><span data-stu-id="613f1-143">In-game invite flow: In a party, and switching titles</span></span>

<table>
  <tr>
    <td>
<span data-ttu-id="613f1-144">一緒にゲームをプレイしています。</span><span class="sxs-lookup"><span data-stu-id="613f1-144">Playing a game together.</span></span>
    <p><br>
<span data-ttu-id="613f1-145">David は異なるゲームに切り替えて、マルチプレイヤー メニューに移動します。</span><span class="sxs-lookup"><span data-stu-id="613f1-145">David switches to a different game and goes to the multiplayer menu.</span></span>
     <p><br>
<span data-ttu-id="613f1-146">Xbox システム UI で David に対してパーティーを新しいゲームに切り替えるかどうかが確認され、David は <b>[はい]</b> または <b>[いいえ]</b> を選択できます。</span><span class="sxs-lookup"><span data-stu-id="613f1-146">The Xbox System UI asks David if he would like to switch his Party to the new game, to which he can answer <b>Yes</b> or <b>No</b>.</span></span>
    </td>
    <td style="text-align:top">
<span data-ttu-id="613f1-147">一緒にゲームをプレイしています。</span><span class="sxs-lookup"><span data-stu-id="613f1-147">Playing a game together.</span></span>
    </td>
  </tr>
  <tr>
    <td colspan=2 style="text-align:center">
      <b><span data-ttu-id="613f1-148">ケース 1: [はい]</span><span class="sxs-lookup"><span data-stu-id="613f1-148">Case 1: Yes</span></span></b>
    </td>
  </tr>
  <tr>
    <td style="border-bottom:solid 1px #fff">
<span data-ttu-id="613f1-149">パーティーは新しいタイトルに移行します。</span><span class="sxs-lookup"><span data-stu-id="613f1-149">Party comes to the new title.</span></span>
    <p><br>
<span data-ttu-id="613f1-150">David はマルチプレイヤー ロビーからゲームを開始します。</span><span class="sxs-lookup"><span data-stu-id="613f1-150">From the multiplayer lobby, David starts the game.</span></span>
    <p><br>
    <b style="background-color: #FFFF00"><span data-ttu-id="613f1-151">ゲームへの招待が Laura に送信されたことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-151">Toast pops up indicating that a game invite has been sent to Laura.</span></span>
    </td>
    <td style="border-bottom:solid 1px #fff">
    </td>
  </tr>
  <tr>
    <td></td>
    <td><span data-ttu-id="613f1-152">そのパーティーに対するゲームが見つかったことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-152">Toast pops up indicating that a game was found for the party.</span></span>
    <p><br>
<span data-ttu-id="613f1-153">通知センターで、Laura は以下を選択できます。</span><span class="sxs-lookup"><span data-stu-id="613f1-153">From the Notification Center, Laura can choose:</span></span> <ul>
     <li><span data-ttu-id="613f1-154"><b>[ゲームへの招待を受ける]:</b> 新しいゲームが起動します。</span><span class="sxs-lookup"><span data-stu-id="613f1-154"><b>Accept game invite</b>: New game launches</span></span> <li><span data-ttu-id="613f1-155"><b>[ゲームへの招待を断る]:</b> ゲームは起動しませんが、Laura はまだパーティー内にいて、それ以降のゲームへの招待を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="613f1-155"><b>Decline game invite:</b> No game launches, but Laura is still in the party and will receive subsequent game invites.</span></span>
     <li><b style="background-color: #FFFF00"><span data-ttu-id="613f1-156"><b>[パーティーから出る]:</b> ゲームは起動せず、Laura はパーティーから削除されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-156"><b>Leave party:</b> No game launches and Laura is removed from the party.</span></span></b>
     </ul>
     </td>
  </tr>
  <tr>
    <td colspan=2 style="text-align:center">
      <b><span data-ttu-id="613f1-157">ケース 2: [いいえ]</span><span class="sxs-lookup"><span data-stu-id="613f1-157">Case 2: No</span></span></b>
    </td>
  </tr>
  <tr>
    <td>
<span data-ttu-id="613f1-158">パーティーは新しいタイトルに移行しません。</span><span class="sxs-lookup"><span data-stu-id="613f1-158">Party does not come to the new title.</span></span>
<span data-ttu-id="613f1-159">David は、パーティー メンバーのいないマルチプレイヤー モードでプレイします。</span><span class="sxs-lookup"><span data-stu-id="613f1-159">David plays on multiplayer mode without his party members.</span></span>
<span data-ttu-id="613f1-160">David はまだパーティー内にいます。</span><span class="sxs-lookup"><span data-stu-id="613f1-160">David is still in the party.</span></span>
    </td>
    <td>
    </td>
  </tr>
</table>

## <a name="invite-flow-from-home"></a><span data-ttu-id="613f1-161">ホームからの招待のフロー</span><span class="sxs-lookup"><span data-stu-id="613f1-161">Invite flow from Home</span></span>

<table>
  <tr>
    <td>
<span data-ttu-id="613f1-162">David は <b>[ホーム]</b> を表示しており、<b>[フレンド]</b> のリストでは Laura がオンラインであることがわかります。</span><span class="sxs-lookup"><span data-stu-id="613f1-162">David is browsing <b>Home</b>, and in his <b>Friends</b> list, he sees that Laura is online.</span></span>
    <p><br>
<span data-ttu-id="613f1-163">David は Laura をパーティーに招待することを選択します。</span><span class="sxs-lookup"><span data-stu-id="613f1-163">David chooses to invite Laura to his party.</span></span> <span data-ttu-id="613f1-164">招待が送信されたことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-164">Toast pops up indicating that the invite is sent.</span></span> <span data-ttu-id="613f1-165">パーティー アプリは David にスナップされます。</span><span class="sxs-lookup"><span data-stu-id="613f1-165">The Party app is snapped for David.</span></span>
    </td>
    <td>
<span data-ttu-id="613f1-166">Laura はゲームをプレイしています。</span><span class="sxs-lookup"><span data-stu-id="613f1-166">Laura is playing a game.</span></span>
    </td>
  </tr>
  <tr>
    <td></td>
    <td>
<span data-ttu-id="613f1-167">David が自分のパーティーに Laura を招待したことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-167">Toast pops up indicating that David has invited Laura to his party.</span></span>
    <p><br>
<span data-ttu-id="613f1-168">通知センターで、Laura には <b>[Accept the invite] (招待を受ける)</b> オプションがあります。</span><span class="sxs-lookup"><span data-stu-id="613f1-168">In the Notification Center, Laura has the option to <b>Accept the invite</b>.</span></span>
    <p><br>
<span data-ttu-id="613f1-169">Laura が招待を受けると、パーティー アプリがスナップします。</span><span class="sxs-lookup"><span data-stu-id="613f1-169">When Laura accepts, the Party app snaps.</span></span>                                                                         </td>
  </tr>
  <tr>
    <td>
<span data-ttu-id="613f1-170">Laura がパーティーに参加したことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-170">Toast pops up indicating that Laura has joined the party.</span></span>
    <p><br>
<span data-ttu-id="613f1-171">David と Laura はプレイするゲームを相談します。</span><span class="sxs-lookup"><span data-stu-id="613f1-171">David and Laura discuss what game they want to play.</span></span> <span data-ttu-id="613f1-172">David はゲームを起動し、マルチプレイヤー ゲーム モードに入ります。</span><span class="sxs-lookup"><span data-stu-id="613f1-172">David launches the game and enters the multiplayer game mode.</span></span>
    <p><br>
<span data-ttu-id="613f1-173">ゲームでは、フレンドを招待するか、またはパーティー メンバーを自動的にプルするオプションが提供されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-173">Game will either give an option to invite friends, or auto-pull the party members.</span></span>
    <p><br>
    <b style="background-color: #FFFF00"><span data-ttu-id="613f1-174">ゲームへの招待が送信されたことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-174">Toast pops up indicating that a game invite has been sent.</span></span></b>
    </td>
    <td>
<span data-ttu-id="613f1-175">そのパーティーに対するゲームが見つかったことを示すトーストが表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-175">Toast pops up indicating that a game has been found for the party.</span></span>
    <p><br>
<span data-ttu-id="613f1-176">通知センターで、Laura は以下を選択できます。</span><span class="sxs-lookup"><span data-stu-id="613f1-176">In the Notification Center, Laura can:</span></span> <ul>
    <li>   <span data-ttu-id="613f1-177"><b>[ゲームへの招待を受ける]:</b> ゲームが起動します。</span><span class="sxs-lookup"><span data-stu-id="613f1-177"><b>Accept game invite:</b> Game launches</span></span> <li>   <span data-ttu-id="613f1-178"><b>[ゲームへの招待を断る]:</b> ゲームは起動せず、Laura はまだパーティー内にいて、それ以降の招待を受け取ります。</span><span class="sxs-lookup"><span data-stu-id="613f1-178"><b>Decline game invite:</b> No game launches, Laura is still in the party and will receive subsequent invites.</span></span>
    <li>   <b style="background-color: #FFFF00"><span data-ttu-id="613f1-179">[パーティーから出る]: ゲームは起動せず、Laura はパーティーから削除されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-179">Leave party: No game launches, Laura is removed from the party.</span></span></b>
    </ul>  
    </td>
  </tr>
</table>


## <a name="more-about-the-game-invite-sent-toast"></a><span data-ttu-id="613f1-180">[ゲームへ招待しました] トーストの詳細</span><span class="sxs-lookup"><span data-stu-id="613f1-180">More about the Game Invite Sent toast</span></span>

<span data-ttu-id="613f1-181">**[ゲームへ招待しました]** トーストは、リモート パーティー メンバーとのゲーム セッションが初めて確立されたときにのみ表示されます。</span><span class="sxs-lookup"><span data-stu-id="613f1-181">The **Game Invite Sent** toast will only appear the first time a game session is established with remote party members.</span></span> <span data-ttu-id="613f1-182">それ以降にリモート パーティー メンバーに送信される要求では、このトーストは生成されません。</span><span class="sxs-lookup"><span data-stu-id="613f1-182">Subsequent requests sent to remote party members will not generate this toast.</span></span> <span data-ttu-id="613f1-183">これにより、タイトルが **PullReservedPlayersAsync** を複数回呼び出した場合にユーザーが **[ゲームへ招待しました]** トーストを何度も受け取ることがなくなります。</span><span class="sxs-lookup"><span data-stu-id="613f1-183">This prevents the user from being spammed with repeated **Game Invite Sent** toasts if the title makes multiple calls to **PullReservedPlayersAsync**.</span></span>

<span data-ttu-id="613f1-184">**注意  \*\* ベスト プラクティスとしては、招待するすべてのフレンドを予約済みにして追加した後、**PullReservedPlayersAsync\*\* を 1 回だけ呼び出します。</span><span class="sxs-lookup"><span data-stu-id="613f1-184">**Note** The best practice is to add all desired friends as Reserved, and then call **PullReservedPlayersAsync** only once.</span></span>
