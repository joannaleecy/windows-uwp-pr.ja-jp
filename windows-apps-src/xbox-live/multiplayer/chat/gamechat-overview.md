---
title: ゲーム チャットの概要
author: KevinAsgari
description: Xbox Live ゲーム チャットを使用して、ゲームに音声通信を追加する方法について説明します。
ms.assetid: 8ef6a578-e911-4006-ac4e-94d3f2fedb98
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One
ms.localizationpriority: low
ms.openlocfilehash: aa926ce695a538d5019ff5571cada093ab262c70
ms.sourcegitcommit: 01760b73fa8cdb423a9aa1f63e72e70647d8f6ab
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/24/2018
---
# <a name="game-chat-overview"></a><span data-ttu-id="f3a74-104">ゲーム チャットの概要</span><span class="sxs-lookup"><span data-stu-id="f3a74-104">Game Chat overview</span></span>

 <span data-ttu-id="f3a74-105">ゲーム チャットとは、リモート本体上の 1 つのタイトルのユーザー間でのボイス チャットを可能にするために使用できるテクノロジです。</span><span class="sxs-lookup"><span data-stu-id="f3a74-105">Game chat is a technology that you can use to enable voice communications between users of a single title on remote consoles.</span></span> <span data-ttu-id="f3a74-106">これには、本体ユーザー間のより広範な独立したコミュニケーションは含まれません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-106">It does not include wider independent communication among console users.</span></span>

 > [!Note]
 > <span data-ttu-id="f3a74-107">新しいタイトルでは、ゲーム チャットの代わりに[ゲーム チャット 2](game-chat-2-overview.md) を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3a74-107">New titles should use [Game Chat 2](game-chat-2-overview.md) instead of Game Chat.</span></span> <span data-ttu-id="f3a74-108">元のゲーム チャットは、2017 年末までに廃止される予定です。</span><span class="sxs-lookup"><span data-stu-id="f3a74-108">The original Game Chat will be deprecated before the end of 2017.</span></span>

 <span data-ttu-id="f3a74-109">Xbox One には、ハードウェア アクセラレーションに対応した専用のボイス チャット コーデックが用意されています。このコーデックはエンコードとデコードに使用され、`Microsoft.Xbox.GameChat` 名前空間を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-109">Xbox One has a specialized, hardware-accelerated voice chat codec that is used for encode and decode, and is exposed through the `Microsoft.Xbox.GameChat` Namespace.</span></span> <span data-ttu-id="f3a74-110">このコーデックは、タイトルのネットワーク帯域幅の柔軟性に関する複数の品質設定をサポートし、本体が送信するすべてのボイス チャット通信でこのコーデックを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3a74-110">This codec supports several quality settings for title networking bandwidth flexibility, and its use is required for all voice chat communications transmitted by the console.</span></span> <span data-ttu-id="f3a74-111">他のコーデックはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-111">No other codecs are supported.</span></span>

> <span data-ttu-id="f3a74-112">**注:** `Windows.Xbox.Chat` と呼ばれる低レベル名前空間がコーデックを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-112">**Note:** A lower-level namespace called `Windows.Xbox.Chat` calls the codec.</span></span>

  * [<span data-ttu-id="f3a74-113">ゲーム チャット チャンネル</span><span class="sxs-lookup"><span data-stu-id="f3a74-113">Game Chat Channels</span></span>](#ID4EFB)
  * [<span data-ttu-id="f3a74-114">ゲーム チャット クラス</span><span class="sxs-lookup"><span data-stu-id="f3a74-114">Game Chat Classes</span></span>](#ID4EKC)
  * [<span data-ttu-id="f3a74-115">既定の USB エンドポイント</span><span class="sxs-lookup"><span data-stu-id="f3a74-115">Default USB Endpoint</span></span>](#ID4E3D)
  * [<span data-ttu-id="f3a74-116">ボリュームとピッチ</span><span class="sxs-lookup"><span data-stu-id="f3a74-116">Volume and Pitch</span></span>](#ID4EDE)
  * [<span data-ttu-id="f3a74-117">ゲーム チャット中にユーザーを聞こえなくする</span><span class="sxs-lookup"><span data-stu-id="f3a74-117">Making Users Inaudible During Game Chat</span></span>](#ID4EWE)
  * [<span data-ttu-id="f3a74-118">GameChat DLL のコンパイル</span><span class="sxs-lookup"><span data-stu-id="f3a74-118">Compiling the GameChat DLL</span></span>](#ID4E5H)

<a id="ID4EFB"></a>

## <a name="game-chat-channels"></a><span data-ttu-id="f3a74-119">ゲーム チャット チャンネル</span><span class="sxs-lookup"><span data-stu-id="f3a74-119">Game Chat Channels</span></span>


 <span data-ttu-id="f3a74-120">チャット システムは、デバイスではなくユーザーからのローカル入力を関連付けます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-120">The chat system relates local input from users rather than devices.</span></span> <span data-ttu-id="f3a74-121">OS が入力デバイスとプレイヤー ID を関連付けます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-121">The OS associates input devices with player IDs.</span></span> <span data-ttu-id="f3a74-122">重要な機能の 1 つが、複数のチャンネルのサポートです。</span><span class="sxs-lookup"><span data-stu-id="f3a74-122">One of the key features is support for multiple channels.</span></span> <span data-ttu-id="f3a74-123">ゲームでロビーを提供したり、ユーザーがチームに参加したり、チーム内で命令系統を確立したりできます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-123">A game might have a lobby, a user might join a team, and there might be a command structure within the team.</span></span> <span data-ttu-id="f3a74-124">ユーザーは、ゲームで許される限り、同時に複数のチャンネルでアクティブになることができます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-124">Users can be active in multiple channels at the same time as the game permits.</span></span> <span data-ttu-id="f3a74-125">たとえば、ゲームで次のようなチャンネルを提供できます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-125">For example, a game might have the following channels:</span></span>

  * <span data-ttu-id="f3a74-126">赤チーム分隊 1 チャンネル &ndash; 分隊 1 の赤チームのすべてのプレイヤー間でのコミュニケーション。</span><span class="sxs-lookup"><span data-stu-id="f3a74-126">Red team squad 1 channel &ndash; open communication among all red team players on squad 1.</span></span>
  * <span data-ttu-id="f3a74-127">赤チーム分隊 2 チャンネル &ndash; 分隊 2 の赤チームのすべてのプレイヤー間でのコミュニケーション。</span><span class="sxs-lookup"><span data-stu-id="f3a74-127">Red team squad 2 channel &ndash; open communication among all red team players on squad 2.</span></span>

<span data-ttu-id="f3a74-128">**図 1.**&nbsp;&nbsp;**標準のチャット チャンネル**</span><span class="sxs-lookup"><span data-stu-id="f3a74-128">**Figure 1.**&nbsp;&nbsp;**Standard chat channel.**</span></span>

![](../../images/chat/gamechat_standard.png)

  *  <span data-ttu-id="f3a74-129">赤チームの命令チャンネル &ndash; 赤チームの指揮権を持たないすべてのプレイヤー向けの受信専用チャンネル。</span><span class="sxs-lookup"><span data-stu-id="f3a74-129">Red team command channel &ndash; listen-only channel for all red team non-command players.</span></span> <span data-ttu-id="f3a74-130">このチャンネルでは、他のすべての「赤チーム」のチャンネルをダッキングすることができます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-130">This channel can duck all other "red team" channels.</span></span> <span data-ttu-id="f3a74-131">押して話すことができる赤チームの指揮官向けの発信専用チャンネル。</span><span class="sxs-lookup"><span data-stu-id="f3a74-131">Speak-only channel for red team commanders that is enabled with push-to-talk.</span></span>

<span data-ttu-id="f3a74-132">**図 2.**&nbsp;&nbsp;**命令チャット チャンネル**</span><span class="sxs-lookup"><span data-stu-id="f3a74-132">**Figure 2.**&nbsp;&nbsp;**Command chat channel.**</span></span>

![](../../images/chat/gamechat_command.png)

  * <span data-ttu-id="f3a74-133">上記と同様の、青チームのチャンネル。</span><span class="sxs-lookup"><span data-stu-id="f3a74-133">Blue team channels as above.</span></span>



> <span data-ttu-id="f3a74-134">**注:** *ダッキング*とは、別の信号がある場合に、あるオーディオ信号のレベルを下げることを意味するチャット用語です。</span><span class="sxs-lookup"><span data-stu-id="f3a74-134">**Note:** *Ducking* is a chat term meaning the reduction in level of one audio signal in the presence of another signal.</span></span> <span data-ttu-id="f3a74-135">たとえば、ラジオでは、司会者がアナウンスをする間、音楽トラックのボリュームが下げられます (ダッキングされます)。</span><span class="sxs-lookup"><span data-stu-id="f3a74-135">For example, in radio, a music track's volume is lowered (ducked) while a presenter makes an announcement.</span></span>



 <span data-ttu-id="f3a74-136">ユーザー間の標準チャットでは、チャンネルは双方向であるため、ユーザーはそれぞれの関連付けられたチャンネルで着信と発信の両方を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-136">In standard chat between users, the channels are bidirectional so that the users can both listen and talk on their associated channels.</span></span> <span data-ttu-id="f3a74-137">命令チャンネルでは、コミュニケーションを (標準のチャンネルとして) 双方向にすることも、ユーザーがチャンネルでの発信または着信のどちらかを行うことができる一方向にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-137">With the command channel, the communication can either be bidirectional (as the standard channel) or can be set to unidirectional, where a user can either speak or listen on the channel, but not both.</span></span> <span data-ttu-id="f3a74-138">たとえば、通常は、指揮官は発信できるようにし、部下は着信のみとします。</span><span class="sxs-lookup"><span data-stu-id="f3a74-138">Typically, for example, a commander might want to speak, with the subordinates only listening.</span></span> <span data-ttu-id="f3a74-139">命令チャンネルは、他のチャンネルよりも優先度が高いものとして扱われるため、他のチャンネルの音声はダッキングされます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-139">The command channel is treated as having a higher priority than other channels, and will cause other channels' voices to be ducked.</span></span>

 <span data-ttu-id="f3a74-140">ゲーム タイトルで、リモート ユーザーが話している間、チャット以外のオーディオをダッキングできます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-140">Game titles can duck non-chat audio while a remote user is speaking.</span></span> <span data-ttu-id="f3a74-141">また、ボリューム、一部のユーザーの着信専用属性、他のユーザーの発信専用属性などのプロパティを各チャンネルで設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-141">Also properties can be set on each channel, such as volume, listen-only attributes for some users, and speak-only attributes for other users.</span></span>


<a id="ID4EKC"></a>


## <a name="game-chat-classes"></a><span data-ttu-id="f3a74-142">ゲーム チャット クラス</span><span class="sxs-lookup"><span data-stu-id="f3a74-142">Game Chat Classes</span></span>


 <span data-ttu-id="f3a74-143">ゲーム チャットの名前空間は `Microsoft.Xbox.GameChat` です。</span><span class="sxs-lookup"><span data-stu-id="f3a74-143">The namespace for game chat is `Microsoft.Xbox.GameChat`.</span></span> <span data-ttu-id="f3a74-144">このセクションでは、この名前空間のクラス階層について説明します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-144">This section describes the class hierarchy of the namespace.</span></span> <span data-ttu-id="f3a74-145">それぞれのクラス、インターフェイス、列挙型の詳細については、`Microsoft.Xbox.GameChat`名前空間のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="f3a74-145">Refer to the `Microsoft.Xbox.GameChat` namespace documentation for a full description of each class, interface and enumeration.</span></span>

  * [<span data-ttu-id="f3a74-146">ChatManager</span><span class="sxs-lookup"><span data-stu-id="f3a74-146">ChatManager</span></span>](#ID4EYC)
  * [<span data-ttu-id="f3a74-147">ChatManagerSettings</span><span class="sxs-lookup"><span data-stu-id="f3a74-147">ChatManagerSettings</span></span>](#ID4EDD)
  * [<span data-ttu-id="f3a74-148">ChatUser</span><span class="sxs-lookup"><span data-stu-id="f3a74-148">ChatUser</span></span>](#ID4EQD)

<a id="ID4EYC"></a>


### <a name="chatmanager"></a><span data-ttu-id="f3a74-149">ChatManager</span><span class="sxs-lookup"><span data-stu-id="f3a74-149">ChatManager</span></span>


<span data-ttu-id="f3a74-150">`ChatManager` クラスはトップレベルのゲーム チャット クラスです。</span><span class="sxs-lookup"><span data-stu-id="f3a74-150">The `ChatManager` class is the top-level game chat class.</span></span>


<a id="ID4EDD"></a>


### <a name="chatmanagersettings"></a><span data-ttu-id="f3a74-151">ChatManagerSettings</span><span class="sxs-lookup"><span data-stu-id="f3a74-151">ChatManagerSettings</span></span>


 <span data-ttu-id="f3a74-152">`ChatManagerSettings` クラスは `ChatManager` クラスの設定を表します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-152">The `ChatManagerSettings` class class represents the settings for the `ChatManager` class.</span></span>


<a id="ID4EQD"></a>


### <a name="chatuser"></a><span data-ttu-id="f3a74-153">ChatUser</span><span class="sxs-lookup"><span data-stu-id="f3a74-153">ChatUser</span></span>


<span data-ttu-id="f3a74-154">`ChatUser` クラスは、チャンネル上のユーザーを表します。そのユーザーと、同じチャンネル上の他のユーザーの対話に固有の一連のプロパティを持ちます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-154">The `ChatUser` class represents a user on a channel, with a set of properties specific to the interaction of that user with other users on the same channel.</span></span>



<a id="ID4E3D"></a>


## <a name="default-usb-endpoint"></a><span data-ttu-id="f3a74-155">既定の USB エンドポイント</span><span class="sxs-lookup"><span data-stu-id="f3a74-155">Default USB Endpoint</span></span>


 <span data-ttu-id="f3a74-156">既定の USB キャプチャー エンドポイントは、シングル チャンネル モノラルです。</span><span class="sxs-lookup"><span data-stu-id="f3a74-156">The default USB capture endpoint is single channel mono.</span></span> <span data-ttu-id="f3a74-157">これにより、エコー除去をオーディオ ストリームに適用できます。これはチャット アプリケーションにとっては便利な機能です。</span><span class="sxs-lookup"><span data-stu-id="f3a74-157">This enables echo-cancellation to be applied to the audio stream, which is a useful feature for chat applications.</span></span>


<a id="ID4EDE"></a>


## <a name="volume-and-pitch"></a><span data-ttu-id="f3a74-158">ボリュームとピッチ</span><span class="sxs-lookup"><span data-stu-id="f3a74-158">Volume and Pitch</span></span>


<span data-ttu-id="f3a74-159">チャット システムのボリューム コントロールは、Chat API の基盤となる XAudio2 で使用されているものと同じです。</span><span class="sxs-lookup"><span data-stu-id="f3a74-159">Volume controls in the chat system are the same as those used for XAudio2, on which the Chat API is based.</span></span> <span data-ttu-id="f3a74-160">ピッチ コントロールはチャット システムではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-160">Pitch control is not supported by the chat system.</span></span>

 <span data-ttu-id="f3a74-161">XAudio2 のボリューム設定の詳細については、`SetVolume` を参照してください。</span><span class="sxs-lookup"><span data-stu-id="f3a74-161">For details on XAudio2 volume settings, refer to `SetVolume`.</span></span>

 <span data-ttu-id="f3a74-162">XAudio2 は、ボリューム レベルをユーザーのスピーカーの設定に基づいて自動的に調整して、構成全体を通して一貫性のあるボリューム レベルを維持します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-162">XAudio2 automatically adjusts volume levels based on the user's speaker settings to maintain a consistent volume level across configurations.</span></span> <span data-ttu-id="f3a74-163">ユーザーの設定が物理的な構成と一致しない場合、正確な設定のシステムと比較してボリュームが大きすぎるか小さすぎるかのいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="f3a74-163">If the user's settings don't match their physical configuration the volume will either be too loud or too soft compared to a system with accurate settings.</span></span> <span data-ttu-id="f3a74-164">たとえば、5.1 サラウンド サウンド スピーカー用に構成されたシステムが 2 つのスピーカーにしか接続されていなければ、サウンドは小さすぎる結果となります。</span><span class="sxs-lookup"><span data-stu-id="f3a74-164">For example, a system configured for 5.1 surround sound speakers that only has two speakers connected will sound too soft.</span></span> <span data-ttu-id="f3a74-165">XAudio2 は、ユーザーのスピーカー設定が物理的なセットアップに適合しているかどうかを判定できません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-165">XAudio2 is unable to detect whether the user speaker settings correctly match their physical setup.</span></span>


<a id="ID4EWE"></a>


## <a name="making-users-inaudible-during-game-chat"></a><span data-ttu-id="f3a74-166">ゲーム チャット中にユーザーを聞こえなくする</span><span class="sxs-lookup"><span data-stu-id="f3a74-166">Making Users Inaudible During Game Chat</span></span>


<span data-ttu-id="f3a74-167">Xbox One は、ゲーム チャット中にユーザーを聞こえなくするための 2 つのメカニズムをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="f3a74-167">Xbox One supports two mechanisms to render users inaudible during game chat:</span></span>
  * <span data-ttu-id="f3a74-168">ミュート</span><span class="sxs-lookup"><span data-stu-id="f3a74-168">Muting</span></span>
  * <span data-ttu-id="f3a74-169">ブロック</span><span class="sxs-lookup"><span data-stu-id="f3a74-169">Blocking</span></span>


<a id="ID4EFF"></a>


### <a name="muting"></a><span data-ttu-id="f3a74-170">ミュート</span><span class="sxs-lookup"><span data-stu-id="f3a74-170">Muting</span></span>


<span data-ttu-id="f3a74-171">ミュートは多くの場合、一方向です。</span><span class="sxs-lookup"><span data-stu-id="f3a74-171">Muting is frequently unidirectional.</span></span> <span data-ttu-id="f3a74-172">つまり、プレイヤー A がプレイヤー B をミュートしますが、プレイヤー B はプレイヤー A を引き続き聞くことができます。ミュートの例:</span><span class="sxs-lookup"><span data-stu-id="f3a74-172">That is, Player A mutes Player B, but Player B can still hear Player A. Examples of muting:</span></span>
  * <span data-ttu-id="f3a74-173">タイトルに「近接」チャットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f3a74-173">A title has "proximity" chat.</span></span> <span data-ttu-id="f3a74-174">この場合、プレイヤーは近くにいる他のプレイヤーを聞くことができますが、遠すぎるプレイヤーはミュートされます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-174">In this case, a player can hear other players who are located nearby, but players who are too far away are muted.</span></span>
  * <span data-ttu-id="f3a74-175">タイトルは、ユーザーに他の任意のプレイヤー、もしくはすべてのプレイヤーをミュートする機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-175">A title offers users a player the ability to mute any/all other players.</span></span>


<span data-ttu-id="f3a74-176">ミュートは、主にタイトルの判断で実装されます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-176">Muting is primarily implemented at the discretion of the title.</span></span> <span data-ttu-id="f3a74-177">ただし、プレイヤーは、ゲーマーカードまたはシステム UI を使用して、Xbox システム レベルで他のプレイヤーをミュートすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-177">However, a player can also mute other players at the Xbox system level, using the gamercard or system UI.</span></span>


<a id="ID4EVF"></a>


### <a name="blocking"></a><span data-ttu-id="f3a74-178">ブロック</span><span class="sxs-lookup"><span data-stu-id="f3a74-178">Blocking</span></span>


> <span data-ttu-id="f3a74-179">**注:** タイトルは、プレイヤーをブロックしません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-179">**Note:** Titles do not block players.</span></span> <span data-ttu-id="f3a74-180">ブロックは、Xbox システム レベルでのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-180">Blocking is carried out at the Xbox system level only.</span></span>



<span data-ttu-id="f3a74-181">ゲーム プレイヤーは、ブロックの使用によってチャットの可聴性に直接影響を及ぼすことができます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-181">A game player can influence the audibility of chat directly by the use of blocking.</span></span> <span data-ttu-id="f3a74-182">プレイヤーは、ゲーマーカードを通じて他のプレイヤーを直接ブロックすることができます。または、音声通信およびテキスト制限を「ブロック」または「フレンドのみ」に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-182">The player can block other players directly through the gamercard, or can set the voice communication and text restriction to "Block" or "Friends only".</span></span> <span data-ttu-id="f3a74-183">通常、ブロックは双方向です。</span><span class="sxs-lookup"><span data-stu-id="f3a74-183">Typically blocking is bidirectional.</span></span> <span data-ttu-id="f3a74-184">つまり、プレイヤー A がプレイヤー B をブロックする場合、プレイヤー A にプレイヤー B が聞こえないだけでなく、プレイヤー B にもプレイヤー A が聞こえません。ブロックの例:</span><span class="sxs-lookup"><span data-stu-id="f3a74-184">That is, if Player A blocks Player B, not only does Player A not hear Player B, but Player B does not hear Player A. Examples of blocking include:</span></span>
  * <span data-ttu-id="f3a74-185">プレイヤーには子アカウントがあり、その他のすべてのプレイヤーがそのアカウントにアクセスするのをブロックします。</span><span class="sxs-lookup"><span data-stu-id="f3a74-185">Player has a child account and blocks all other players from access to that account.</span></span>
  * <span data-ttu-id="f3a74-186">プレイヤーは、フレンドとのみチャットするようにアカウント構成を設定し、フレンド以外をブロックします。</span><span class="sxs-lookup"><span data-stu-id="f3a74-186">Player sets the account configuration to chat only with friends, and blocks non-friends.</span></span>
  * <span data-ttu-id="f3a74-187">プレイヤー A は、People アプリの評判/フィードバックまたはシステム UI を通じてプレイヤー B に不適切な行動というフラグを付けてプレイヤー B をブロックします。</span><span class="sxs-lookup"><span data-stu-id="f3a74-187">Player A blocks Player B by flagging Player B for inappropriate behavior through reputation/feedback in the People app or through system UI.</span></span>


<span data-ttu-id="f3a74-188">プレイヤーは、物理的にヘッドセットを取り外したり、Kinect センサーを無効にしたりすることで他のプレイヤーをブロックすることもできます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-188">A player can also block other players by physically removing the headset and/or disabling the Kinect sensor.</span></span>


<a id="ID4EJG"></a>


### <a name="what-titles-should-do-to-provide-for-mutingblocking"></a><span data-ttu-id="f3a74-189">ミュート/ブロックを提供するためにタイトルは何を実行する必要があるか</span><span class="sxs-lookup"><span data-stu-id="f3a74-189">What Titles Should Do to Provide for Muting/Blocking</span></span>


<span data-ttu-id="f3a74-190">タイトルは、InGameChat サンプルに示されている、GameChat DLL を使用して実装されるゲーム内オプションを通じてミュートを提供します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-190">A title provides muting through an in-game option implemented using the GameChat DLL, illustrated in the InGameChat sample.</span></span> <span data-ttu-id="f3a74-191">ライブラリはミュート/ブロックのすべての要件を満たします。システム ポリシーに従うためにタイトルからの特定のアクションは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-191">The library meets all requirements for muting/blocking and no specific action is required from the title to abide by system policies.</span></span> <span data-ttu-id="f3a74-192">タイトルが行う必要があるのは、プレイヤーがチャット セッション中に他のプレイヤーをミュート/ブロックすることができるゲーマーカード UI を確実に公開することだけです。</span><span class="sxs-lookup"><span data-stu-id="f3a74-192">The title must only ensure that it exposes gamercard UI that allows players to mute/block other players during chat sessions.</span></span>

 <span data-ttu-id="f3a74-193">ミュートを実装するために、タイトルは `ChatManager.MuteUserFromAllChannels` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-193">To implement muting, the title calls `ChatManager.MuteUserFromAllChannels`.</span></span> <span data-ttu-id="f3a74-194">すべてのユーザーをミュートする必要がある場合は、`MuteAllUsersFromAllChannels` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-194">If it must mute for all users, it calls `MuteAllUsersFromAllChannels`.</span></span> <span data-ttu-id="f3a74-195">タイトルは、必要に応じて `ChatManager.UnmuteUserFromAllChannels` または `UnmuteAllUsersFromAllChannels` の呼び出しを使用して、ミュートされたプレイヤーの可聴性を復元できます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-195">The title can restore audibility for muted players using calls to `ChatManager.UnmuteUserFromAllChannels` or `UnmuteAllUsersFromAllChannels`, as required.</span></span> <span data-ttu-id="f3a74-196">タイトルが `Chat` 名前空間を直接使用することは推奨されません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-196">Titles are discouraged from using the `Chat` namespace directly.</span></span> <span data-ttu-id="f3a74-197">このライブラリの機能のほとんどは `GameChat` を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-197">Most of the functionality of this library is exposed through `GameChat`.</span></span>

<span data-ttu-id="f3a74-198">プレイヤーがチャット チャンネルをクリアし、新しいチャット セッションを作成するとき、セッションはミュートされていた以前のプレイヤーに関する情報を保持しません。</span><span class="sxs-lookup"><span data-stu-id="f3a74-198">When a player clears a chat channel and creates a new chat session, the session does not retain information about the previous players who were muted.</span></span> <span data-ttu-id="f3a74-199">タイトルは、この動作を追跡し、`ChatManager` を呼び出して、ゲームプレイ中のプレイヤーのミュート エクスペリエンスの一貫性を維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="f3a74-199">The title must track this behavior and call `ChatManager` to keep the muting experience consistent for players during gameplay.</span></span>

<span data-ttu-id="f3a74-200">多くのタイトルは、ブロック/ミュート状況で音声トラフィックを制限して、ネットワークを介して送信するデータを少なくすることでネットワーク運用を最適化します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-200">Many titles restrict voice traffic in blocking/muting situations to optimize network operation by sending less data over the network.</span></span> <span data-ttu-id="f3a74-201">たとえば、プレイヤー A がプレイヤー B をブロック/ミュートして、音声トラフィックを制限しますが、タイトルはプレイヤー B からプレイヤー A への音声データの送信を停止しません。この動作の実装は完全にタイトルに委ねられます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-201">For example, Player A blocks/mutes Player B, restricting voice traffic, but the title does not stop the transmission of voice data from Player B to Player A. This behavior is totally up to the title to implement.</span></span> `GameChat` <span data-ttu-id="f3a74-202">はこのケースを処理し、`ChatManager` に渡される場合にプレイヤー B からの音声データをブロックします。</span><span class="sxs-lookup"><span data-stu-id="f3a74-202">handles the case where it blocks voice data from Player B if passed into `ChatManager`.</span></span>


<a id="ID4ERH"></a>


### <a name="debugging-when-players-cannot-hear-each-other"></a><span data-ttu-id="f3a74-203">プレイヤーが互いに聞こえない場合のデバッグ</span><span class="sxs-lookup"><span data-stu-id="f3a74-203">Debugging When Players Cannot Hear Each Other</span></span>

`ChatManager` <span data-ttu-id="f3a74-204"> には、`ChatManagerSettings.DiagnosticsTraceLevel` プロパティおよび `ChatManager.OnDebugMessage` イベントを使用してタイトルが有効にできるデバッグ トレースが含まれています。</span><span class="sxs-lookup"><span data-stu-id="f3a74-204">includes debug traces that the title can enable, using the `ChatManagerSettings.DiagnosticsTraceLevel` property, and the `ChatManager.OnDebugMessage` event.</span></span> <span data-ttu-id="f3a74-205">トレースは、問題の絞り込みに役立つ多くのコンテンツを提供します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-205">The traces offer much content that can help in narrowing down issues.</span></span> <span data-ttu-id="f3a74-206">このコンテンツは、オーディオ デバイスの追加/変更、ローカルおよびリモート ユーザーの追加、各リモート ユーザーからの音声データの取得などから得られます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-206">This content comes from adding/changing audio devices, adding local and remote users, getting voice data from each remote user, and the like.</span></span>


<a id="ID4E5H"></a>


## <a name="compiling-the-gamechat-dll"></a><span data-ttu-id="f3a74-207">GameChat DLL のコンパイル</span><span class="sxs-lookup"><span data-stu-id="f3a74-207">Compiling the GameChat DLL</span></span>


 <span data-ttu-id="f3a74-208">Microsoft.Xbox.GameChat.dll をビルドするためのソースは Xbox デベロッパー ポータルにあります。</span><span class="sxs-lookup"><span data-stu-id="f3a74-208">The source for building the Microsoft.Xbox.GameChat.dll is available on Xbox Developer Portal.</span></span> <span data-ttu-id="f3a74-209">デベロッパーは、このソースをコンパイルして `GameChat` のカスタマイズ バージョンを作成できます。</span><span class="sxs-lookup"><span data-stu-id="f3a74-209">Developers can compile this source to create a customized version of `GameChat`.</span></span> <span data-ttu-id="f3a74-210">一般的なカスタマイズでは、オーディオ データを転送するためのカスタム ネットワーク チャンネルを作成します。</span><span class="sxs-lookup"><span data-stu-id="f3a74-210">A typical customization is to create a custom network channel for transmitting the audio data.</span></span>
