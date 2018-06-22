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
ms.openlocfilehash: 4ea89114dc7b1d24f3e92a5b60f3ba189d44347e
ms.sourcegitcommit: e4627686138ec8c885696c4c511f2f05195cf8ff
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 05/17/2018
ms.locfileid: "1893644"
---
# <a name="game-chat-overview"></a><span data-ttu-id="457ef-104">ゲーム チャットの概要</span><span class="sxs-lookup"><span data-stu-id="457ef-104">Game Chat overview</span></span>

 <span data-ttu-id="457ef-105">ゲーム チャットとは、リモート本体上の 1 つのタイトルのユーザー間でのボイス チャットを可能にするために使用できるテクノロジです。</span><span class="sxs-lookup"><span data-stu-id="457ef-105">Game chat is a technology that you can use to enable voice communications between users of a single title on remote consoles.</span></span> <span data-ttu-id="457ef-106">これには、本体ユーザー間のより広範な独立したコミュニケーションは含まれません。</span><span class="sxs-lookup"><span data-stu-id="457ef-106">It does not include wider independent communication among console users.</span></span>

 > [!Note]
 > <span data-ttu-id="457ef-107">新しいタイトルでは、ゲーム チャットの代わりに[ゲーム チャット 2](game-chat-2-overview.md) を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="457ef-107">New titles should use [Game Chat 2](game-chat-2-overview.md) instead of Game Chat.</span></span> <span data-ttu-id="457ef-108">元のゲーム チャットは、2017 年末に非推奨となりました。</span><span class="sxs-lookup"><span data-stu-id="457ef-108">The original Game Chat was deprecated at the end of 2017.</span></span> <span data-ttu-id="457ef-109">元のゲーム チャットを利用しているタイトルでは、[ゲーム チャット 2 移行ガイド](game-chat-2-migration.md)に従って、ゲーム チャットの概念と呼び出しパターンをゲーム チャット 2 にマップすることができます。</span><span class="sxs-lookup"><span data-stu-id="457ef-109">Titles consuming the original Game Chat can use the [Game Chat 2 Migration Guide](game-chat-2-migration.md) to map Game Chat concepts and calling patterns to Game Chat 2.</span></span>

 <span data-ttu-id="457ef-110">Xbox One には、ハードウェア アクセラレーションに対応した専用のボイス チャット コーデックが用意されています。このコーデックはエンコードとデコードに使用され、`Microsoft.Xbox.GameChat` 名前空間を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="457ef-110">Xbox One has a specialized, hardware-accelerated voice chat codec that is used for encode and decode, and is exposed through the `Microsoft.Xbox.GameChat` Namespace.</span></span> <span data-ttu-id="457ef-111">このコーデックは、タイトルのネットワーク帯域幅の柔軟性に関する複数の品質設定をサポートし、本体が送信するすべてのボイス チャット通信でこのコーデックを使用する必要があります。</span><span class="sxs-lookup"><span data-stu-id="457ef-111">This codec supports several quality settings for title networking bandwidth flexibility, and its use is required for all voice chat communications transmitted by the console.</span></span> <span data-ttu-id="457ef-112">他のコーデックはサポートされません。</span><span class="sxs-lookup"><span data-stu-id="457ef-112">No other codecs are supported.</span></span>

> <span data-ttu-id="457ef-113">**注:** `Windows.Xbox.Chat` と呼ばれる低レベル名前空間がコーデックを呼び出します。</span><span class="sxs-lookup"><span data-stu-id="457ef-113">**Note:** A lower-level namespace called `Windows.Xbox.Chat` calls the codec.</span></span>

  * [<span data-ttu-id="457ef-114">ゲーム チャット チャンネル</span><span class="sxs-lookup"><span data-stu-id="457ef-114">Game Chat Channels</span></span>](#ID4EFB)
  * [<span data-ttu-id="457ef-115">ゲーム チャット クラス</span><span class="sxs-lookup"><span data-stu-id="457ef-115">Game Chat Classes</span></span>](#ID4EKC)
  * [<span data-ttu-id="457ef-116">既定の USB エンドポイント</span><span class="sxs-lookup"><span data-stu-id="457ef-116">Default USB Endpoint</span></span>](#ID4E3D)
  * [<span data-ttu-id="457ef-117">ボリュームとピッチ</span><span class="sxs-lookup"><span data-stu-id="457ef-117">Volume and Pitch</span></span>](#ID4EDE)
  * [<span data-ttu-id="457ef-118">ゲーム チャット中にユーザーを聞こえなくする</span><span class="sxs-lookup"><span data-stu-id="457ef-118">Making Users Inaudible During Game Chat</span></span>](#ID4EWE)
  * [<span data-ttu-id="457ef-119">GameChat DLL のコンパイル</span><span class="sxs-lookup"><span data-stu-id="457ef-119">Compiling the GameChat DLL</span></span>](#ID4E5H)

<a id="ID4EFB"></a>

## <a name="game-chat-channels"></a><span data-ttu-id="457ef-120">ゲーム チャット チャンネル</span><span class="sxs-lookup"><span data-stu-id="457ef-120">Game Chat Channels</span></span>


 <span data-ttu-id="457ef-121">チャット システムは、デバイスではなくユーザーからのローカル入力を関連付けます。</span><span class="sxs-lookup"><span data-stu-id="457ef-121">The chat system relates local input from users rather than devices.</span></span> <span data-ttu-id="457ef-122">OS が入力デバイスとプレイヤー ID を関連付けます。</span><span class="sxs-lookup"><span data-stu-id="457ef-122">The OS associates input devices with player IDs.</span></span> <span data-ttu-id="457ef-123">重要な機能の 1 つが、複数のチャンネルのサポートです。</span><span class="sxs-lookup"><span data-stu-id="457ef-123">One of the key features is support for multiple channels.</span></span> <span data-ttu-id="457ef-124">ゲームでロビーを提供したり、ユーザーがチームに参加したり、チーム内で命令系統を確立したりできます。</span><span class="sxs-lookup"><span data-stu-id="457ef-124">A game might have a lobby, a user might join a team, and there might be a command structure within the team.</span></span> <span data-ttu-id="457ef-125">ユーザーは、ゲームで許される限り、同時に複数のチャンネルでアクティブになることができます。</span><span class="sxs-lookup"><span data-stu-id="457ef-125">Users can be active in multiple channels at the same time as the game permits.</span></span> <span data-ttu-id="457ef-126">たとえば、ゲームで次のようなチャンネルを提供できます。</span><span class="sxs-lookup"><span data-stu-id="457ef-126">For example, a game might have the following channels:</span></span>

  * <span data-ttu-id="457ef-127">赤チーム分隊 1 チャンネル &ndash; 分隊 1 の赤チームのすべてのプレイヤー間でのコミュニケーション。</span><span class="sxs-lookup"><span data-stu-id="457ef-127">Red team squad 1 channel &ndash; open communication among all red team players on squad 1.</span></span>
  * <span data-ttu-id="457ef-128">赤チーム分隊 2 チャンネル &ndash; 分隊 2 の赤チームのすべてのプレイヤー間でのコミュニケーション。</span><span class="sxs-lookup"><span data-stu-id="457ef-128">Red team squad 2 channel &ndash; open communication among all red team players on squad 2.</span></span>

<span data-ttu-id="457ef-129">**図 1.**&nbsp;&nbsp;**標準のチャット チャンネル**</span><span class="sxs-lookup"><span data-stu-id="457ef-129">**Figure 1.**&nbsp;&nbsp;**Standard chat channel.**</span></span>

![](../../images/chat/gamechat_standard.png)

  *  <span data-ttu-id="457ef-130">赤チームの命令チャンネル &ndash; 赤チームの指揮権を持たないすべてのプレイヤー向けの受信専用チャンネル。</span><span class="sxs-lookup"><span data-stu-id="457ef-130">Red team command channel &ndash; listen-only channel for all red team non-command players.</span></span> <span data-ttu-id="457ef-131">このチャンネルでは、他のすべての「赤チーム」のチャンネルをダッキングすることができます。</span><span class="sxs-lookup"><span data-stu-id="457ef-131">This channel can duck all other "red team" channels.</span></span> <span data-ttu-id="457ef-132">押して話すことができる赤チームの指揮官向けの発信専用チャンネル。</span><span class="sxs-lookup"><span data-stu-id="457ef-132">Speak-only channel for red team commanders that is enabled with push-to-talk.</span></span>

<span data-ttu-id="457ef-133">**図 2.**&nbsp;&nbsp;**命令チャット チャンネル**</span><span class="sxs-lookup"><span data-stu-id="457ef-133">**Figure 2.**&nbsp;&nbsp;**Command chat channel.**</span></span>

![](../../images/chat/gamechat_command.png)

  * <span data-ttu-id="457ef-134">上記と同様の、青チームのチャンネル。</span><span class="sxs-lookup"><span data-stu-id="457ef-134">Blue team channels as above.</span></span>



> <span data-ttu-id="457ef-135">**注:** *ダッキング*とは、別の信号がある場合に、あるオーディオ信号のレベルを下げることを意味するチャット用語です。</span><span class="sxs-lookup"><span data-stu-id="457ef-135">**Note:** *Ducking* is a chat term meaning the reduction in level of one audio signal in the presence of another signal.</span></span> <span data-ttu-id="457ef-136">たとえば、ラジオでは、司会者がアナウンスをする間、音楽トラックのボリュームが下げられます (ダッキングされます)。</span><span class="sxs-lookup"><span data-stu-id="457ef-136">For example, in radio, a music track's volume is lowered (ducked) while a presenter makes an announcement.</span></span>



 <span data-ttu-id="457ef-137">ユーザー間の標準チャットでは、チャンネルは双方向であるため、ユーザーはそれぞれの関連付けられたチャンネルで着信と発信の両方を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="457ef-137">In standard chat between users, the channels are bidirectional so that the users can both listen and talk on their associated channels.</span></span> <span data-ttu-id="457ef-138">命令チャンネルでは、コミュニケーションを (標準のチャンネルとして) 双方向にすることも、ユーザーがチャンネルでの発信または着信のどちらかを行うことができる一方向にすることもできます。</span><span class="sxs-lookup"><span data-stu-id="457ef-138">With the command channel, the communication can either be bidirectional (as the standard channel) or can be set to unidirectional, where a user can either speak or listen on the channel, but not both.</span></span> <span data-ttu-id="457ef-139">たとえば、通常は、指揮官は発信できるようにし、部下は着信のみとします。</span><span class="sxs-lookup"><span data-stu-id="457ef-139">Typically, for example, a commander might want to speak, with the subordinates only listening.</span></span> <span data-ttu-id="457ef-140">命令チャンネルは、他のチャンネルよりも優先度が高いものとして扱われるため、他のチャンネルの音声はダッキングされます。</span><span class="sxs-lookup"><span data-stu-id="457ef-140">The command channel is treated as having a higher priority than other channels, and will cause other channels' voices to be ducked.</span></span>

 <span data-ttu-id="457ef-141">ゲーム タイトルで、リモート ユーザーが話している間、チャット以外のオーディオをダッキングできます。</span><span class="sxs-lookup"><span data-stu-id="457ef-141">Game titles can duck non-chat audio while a remote user is speaking.</span></span> <span data-ttu-id="457ef-142">また、ボリューム、一部のユーザーの着信専用属性、他のユーザーの発信専用属性などのプロパティを各チャンネルで設定することもできます。</span><span class="sxs-lookup"><span data-stu-id="457ef-142">Also properties can be set on each channel, such as volume, listen-only attributes for some users, and speak-only attributes for other users.</span></span>


<a id="ID4EKC"></a>


## <a name="game-chat-classes"></a><span data-ttu-id="457ef-143">ゲーム チャット クラス</span><span class="sxs-lookup"><span data-stu-id="457ef-143">Game Chat Classes</span></span>


 <span data-ttu-id="457ef-144">ゲーム チャットの名前空間は `Microsoft.Xbox.GameChat` です。</span><span class="sxs-lookup"><span data-stu-id="457ef-144">The namespace for game chat is `Microsoft.Xbox.GameChat`.</span></span> <span data-ttu-id="457ef-145">このセクションでは、この名前空間のクラス階層について説明します。</span><span class="sxs-lookup"><span data-stu-id="457ef-145">This section describes the class hierarchy of the namespace.</span></span> <span data-ttu-id="457ef-146">それぞれのクラス、インターフェイス、列挙型の詳細については、`Microsoft.Xbox.GameChat`名前空間のドキュメントを参照してください。</span><span class="sxs-lookup"><span data-stu-id="457ef-146">Refer to the `Microsoft.Xbox.GameChat` namespace documentation for a full description of each class, interface and enumeration.</span></span>

  * [<span data-ttu-id="457ef-147">ChatManager</span><span class="sxs-lookup"><span data-stu-id="457ef-147">ChatManager</span></span>](#ID4EYC)
  * [<span data-ttu-id="457ef-148">ChatManagerSettings</span><span class="sxs-lookup"><span data-stu-id="457ef-148">ChatManagerSettings</span></span>](#ID4EDD)
  * [<span data-ttu-id="457ef-149">ChatUser</span><span class="sxs-lookup"><span data-stu-id="457ef-149">ChatUser</span></span>](#ID4EQD)

<a id="ID4EYC"></a>


### <a name="chatmanager"></a><span data-ttu-id="457ef-150">ChatManager</span><span class="sxs-lookup"><span data-stu-id="457ef-150">ChatManager</span></span>


<span data-ttu-id="457ef-151">`ChatManager` クラスはトップレベルのゲーム チャット クラスです。</span><span class="sxs-lookup"><span data-stu-id="457ef-151">The `ChatManager` class is the top-level game chat class.</span></span>


<a id="ID4EDD"></a>


### <a name="chatmanagersettings"></a><span data-ttu-id="457ef-152">ChatManagerSettings</span><span class="sxs-lookup"><span data-stu-id="457ef-152">ChatManagerSettings</span></span>


 <span data-ttu-id="457ef-153">`ChatManagerSettings` クラスは `ChatManager` クラスの設定を表します。</span><span class="sxs-lookup"><span data-stu-id="457ef-153">The `ChatManagerSettings` class class represents the settings for the `ChatManager` class.</span></span>


<a id="ID4EQD"></a>


### <a name="chatuser"></a><span data-ttu-id="457ef-154">ChatUser</span><span class="sxs-lookup"><span data-stu-id="457ef-154">ChatUser</span></span>


<span data-ttu-id="457ef-155">`ChatUser` クラスは、チャンネル上のユーザーを表します。そのユーザーと、同じチャンネル上の他のユーザーの対話に固有の一連のプロパティを持ちます。</span><span class="sxs-lookup"><span data-stu-id="457ef-155">The `ChatUser` class represents a user on a channel, with a set of properties specific to the interaction of that user with other users on the same channel.</span></span>



<a id="ID4E3D"></a>


## <a name="default-usb-endpoint"></a><span data-ttu-id="457ef-156">既定の USB エンドポイント</span><span class="sxs-lookup"><span data-stu-id="457ef-156">Default USB Endpoint</span></span>


 <span data-ttu-id="457ef-157">既定の USB キャプチャー エンドポイントは、シングル チャンネル モノラルです。</span><span class="sxs-lookup"><span data-stu-id="457ef-157">The default USB capture endpoint is single channel mono.</span></span> <span data-ttu-id="457ef-158">これにより、エコー除去をオーディオ ストリームに適用できます。これはチャット アプリケーションにとっては便利な機能です。</span><span class="sxs-lookup"><span data-stu-id="457ef-158">This enables echo-cancellation to be applied to the audio stream, which is a useful feature for chat applications.</span></span>


<a id="ID4EDE"></a>


## <a name="volume-and-pitch"></a><span data-ttu-id="457ef-159">ボリュームとピッチ</span><span class="sxs-lookup"><span data-stu-id="457ef-159">Volume and Pitch</span></span>


<span data-ttu-id="457ef-160">チャット システムのボリューム コントロールは、Chat API の基盤となる XAudio2 で使用されているものと同じです。</span><span class="sxs-lookup"><span data-stu-id="457ef-160">Volume controls in the chat system are the same as those used for XAudio2, on which the Chat API is based.</span></span> <span data-ttu-id="457ef-161">ピッチ コントロールはチャット システムではサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="457ef-161">Pitch control is not supported by the chat system.</span></span>

 <span data-ttu-id="457ef-162">XAudio2 のボリューム設定の詳細については、`SetVolume` を参照してください。</span><span class="sxs-lookup"><span data-stu-id="457ef-162">For details on XAudio2 volume settings, refer to `SetVolume`.</span></span>

 <span data-ttu-id="457ef-163">XAudio2 は、ボリューム レベルをユーザーのスピーカーの設定に基づいて自動的に調整して、構成全体を通して一貫性のあるボリューム レベルを維持します。</span><span class="sxs-lookup"><span data-stu-id="457ef-163">XAudio2 automatically adjusts volume levels based on the user's speaker settings to maintain a consistent volume level across configurations.</span></span> <span data-ttu-id="457ef-164">ユーザーの設定が物理的な構成と一致しない場合、正確な設定のシステムと比較してボリュームが大きすぎるか小さすぎるかのいずれかになります。</span><span class="sxs-lookup"><span data-stu-id="457ef-164">If the user's settings don't match their physical configuration the volume will either be too loud or too soft compared to a system with accurate settings.</span></span> <span data-ttu-id="457ef-165">たとえば、5.1 サラウンド サウンド スピーカー用に構成されたシステムが 2 つのスピーカーにしか接続されていなければ、サウンドは小さすぎる結果となります。</span><span class="sxs-lookup"><span data-stu-id="457ef-165">For example, a system configured for 5.1 surround sound speakers that only has two speakers connected will sound too soft.</span></span> <span data-ttu-id="457ef-166">XAudio2 は、ユーザーのスピーカー設定が物理的なセットアップに適合しているかどうかを判定できません。</span><span class="sxs-lookup"><span data-stu-id="457ef-166">XAudio2 is unable to detect whether the user speaker settings correctly match their physical setup.</span></span>


<a id="ID4EWE"></a>


## <a name="making-users-inaudible-during-game-chat"></a><span data-ttu-id="457ef-167">ゲーム チャット中にユーザーを聞こえなくする</span><span class="sxs-lookup"><span data-stu-id="457ef-167">Making Users Inaudible During Game Chat</span></span>


<span data-ttu-id="457ef-168">Xbox One は、ゲーム チャット中にユーザーを聞こえなくするための 2 つのメカニズムをサポートしています。</span><span class="sxs-lookup"><span data-stu-id="457ef-168">Xbox One supports two mechanisms to render users inaudible during game chat:</span></span>
  * <span data-ttu-id="457ef-169">ミュート</span><span class="sxs-lookup"><span data-stu-id="457ef-169">Muting</span></span>
  * <span data-ttu-id="457ef-170">ブロック</span><span class="sxs-lookup"><span data-stu-id="457ef-170">Blocking</span></span>


<a id="ID4EFF"></a>


### <a name="muting"></a><span data-ttu-id="457ef-171">ミュート</span><span class="sxs-lookup"><span data-stu-id="457ef-171">Muting</span></span>


<span data-ttu-id="457ef-172">ミュートは多くの場合、一方向です。</span><span class="sxs-lookup"><span data-stu-id="457ef-172">Muting is frequently unidirectional.</span></span> <span data-ttu-id="457ef-173">つまり、プレイヤー A がプレイヤー B をミュートしますが、プレイヤー B はプレイヤー A を引き続き聞くことができます。ミュートの例:</span><span class="sxs-lookup"><span data-stu-id="457ef-173">That is, Player A mutes Player B, but Player B can still hear Player A. Examples of muting:</span></span>
  * <span data-ttu-id="457ef-174">タイトルに「近接」チャットが含まれています。</span><span class="sxs-lookup"><span data-stu-id="457ef-174">A title has "proximity" chat.</span></span> <span data-ttu-id="457ef-175">この場合、プレイヤーは近くにいる他のプレイヤーを聞くことができますが、遠すぎるプレイヤーはミュートされます。</span><span class="sxs-lookup"><span data-stu-id="457ef-175">In this case, a player can hear other players who are located nearby, but players who are too far away are muted.</span></span>
  * <span data-ttu-id="457ef-176">タイトルは、ユーザーに他の任意のプレイヤー、もしくはすべてのプレイヤーをミュートする機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="457ef-176">A title offers users a player the ability to mute any/all other players.</span></span>


<span data-ttu-id="457ef-177">ミュートは、主にタイトルの判断で実装されます。</span><span class="sxs-lookup"><span data-stu-id="457ef-177">Muting is primarily implemented at the discretion of the title.</span></span> <span data-ttu-id="457ef-178">ただし、プレイヤーは、ゲーマーカードまたはシステム UI を使用して、Xbox システム レベルで他のプレイヤーをミュートすることもできます。</span><span class="sxs-lookup"><span data-stu-id="457ef-178">However, a player can also mute other players at the Xbox system level, using the gamercard or system UI.</span></span>


<a id="ID4EVF"></a>


### <a name="blocking"></a><span data-ttu-id="457ef-179">ブロック</span><span class="sxs-lookup"><span data-stu-id="457ef-179">Blocking</span></span>


> <span data-ttu-id="457ef-180">**注:** タイトルは、プレイヤーをブロックしません。</span><span class="sxs-lookup"><span data-stu-id="457ef-180">**Note:** Titles do not block players.</span></span> <span data-ttu-id="457ef-181">ブロックは、Xbox システム レベルでのみ実行されます。</span><span class="sxs-lookup"><span data-stu-id="457ef-181">Blocking is carried out at the Xbox system level only.</span></span>



<span data-ttu-id="457ef-182">ゲーム プレイヤーは、ブロックの使用によってチャットの可聴性に直接影響を及ぼすことができます。</span><span class="sxs-lookup"><span data-stu-id="457ef-182">A game player can influence the audibility of chat directly by the use of blocking.</span></span> <span data-ttu-id="457ef-183">プレイヤーは、ゲーマーカードを通じて他のプレイヤーを直接ブロックすることができます。または、音声通信およびテキスト制限を「ブロック」または「フレンドのみ」に設定することができます。</span><span class="sxs-lookup"><span data-stu-id="457ef-183">The player can block other players directly through the gamercard, or can set the voice communication and text restriction to "Block" or "Friends only".</span></span> <span data-ttu-id="457ef-184">通常、ブロックは双方向です。</span><span class="sxs-lookup"><span data-stu-id="457ef-184">Typically blocking is bidirectional.</span></span> <span data-ttu-id="457ef-185">つまり、プレイヤー A がプレイヤー B をブロックする場合、プレイヤー A にプレイヤー B が聞こえないだけでなく、プレイヤー B にもプレイヤー A が聞こえません。ブロックの例:</span><span class="sxs-lookup"><span data-stu-id="457ef-185">That is, if Player A blocks Player B, not only does Player A not hear Player B, but Player B does not hear Player A. Examples of blocking include:</span></span>
  * <span data-ttu-id="457ef-186">プレイヤーには子アカウントがあり、その他のすべてのプレイヤーがそのアカウントにアクセスするのをブロックします。</span><span class="sxs-lookup"><span data-stu-id="457ef-186">Player has a child account and blocks all other players from access to that account.</span></span>
  * <span data-ttu-id="457ef-187">プレイヤーは、フレンドとのみチャットするようにアカウント構成を設定し、フレンド以外をブロックします。</span><span class="sxs-lookup"><span data-stu-id="457ef-187">Player sets the account configuration to chat only with friends, and blocks non-friends.</span></span>
  * <span data-ttu-id="457ef-188">プレイヤー A は、People アプリの評判/フィードバックまたはシステム UI を通じてプレイヤー B に不適切な行動というフラグを付けてプレイヤー B をブロックします。</span><span class="sxs-lookup"><span data-stu-id="457ef-188">Player A blocks Player B by flagging Player B for inappropriate behavior through reputation/feedback in the People app or through system UI.</span></span>


<span data-ttu-id="457ef-189">プレイヤーは、物理的にヘッドセットを取り外したり、Kinect センサーを無効にしたりすることで他のプレイヤーをブロックすることもできます。</span><span class="sxs-lookup"><span data-stu-id="457ef-189">A player can also block other players by physically removing the headset and/or disabling the Kinect sensor.</span></span>


<a id="ID4EJG"></a>


### <a name="what-titles-should-do-to-provide-for-mutingblocking"></a><span data-ttu-id="457ef-190">ミュート/ブロックを提供するためにタイトルは何を実行する必要があるか</span><span class="sxs-lookup"><span data-stu-id="457ef-190">What Titles Should Do to Provide for Muting/Blocking</span></span>


<span data-ttu-id="457ef-191">タイトルは、InGameChat サンプルに示されている、GameChat DLL を使用して実装されるゲーム内オプションを通じてミュートを提供します。</span><span class="sxs-lookup"><span data-stu-id="457ef-191">A title provides muting through an in-game option implemented using the GameChat DLL, illustrated in the InGameChat sample.</span></span> <span data-ttu-id="457ef-192">ライブラリはミュート/ブロックのすべての要件を満たします。システム ポリシーに従うためにタイトルからの特定のアクションは必要ありません。</span><span class="sxs-lookup"><span data-stu-id="457ef-192">The library meets all requirements for muting/blocking and no specific action is required from the title to abide by system policies.</span></span> <span data-ttu-id="457ef-193">タイトルが行う必要があるのは、プレイヤーがチャット セッション中に他のプレイヤーをミュート/ブロックすることができるゲーマーカード UI を確実に公開することだけです。</span><span class="sxs-lookup"><span data-stu-id="457ef-193">The title must only ensure that it exposes gamercard UI that allows players to mute/block other players during chat sessions.</span></span>

 <span data-ttu-id="457ef-194">ミュートを実装するために、タイトルは `ChatManager.MuteUserFromAllChannels` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="457ef-194">To implement muting, the title calls `ChatManager.MuteUserFromAllChannels`.</span></span> <span data-ttu-id="457ef-195">すべてのユーザーをミュートする必要がある場合は、`MuteAllUsersFromAllChannels` を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="457ef-195">If it must mute for all users, it calls `MuteAllUsersFromAllChannels`.</span></span> <span data-ttu-id="457ef-196">タイトルは、必要に応じて `ChatManager.UnmuteUserFromAllChannels` または `UnmuteAllUsersFromAllChannels` の呼び出しを使用して、ミュートされたプレイヤーの可聴性を復元できます。</span><span class="sxs-lookup"><span data-stu-id="457ef-196">The title can restore audibility for muted players using calls to `ChatManager.UnmuteUserFromAllChannels` or `UnmuteAllUsersFromAllChannels`, as required.</span></span> <span data-ttu-id="457ef-197">タイトルが `Chat` 名前空間を直接使用することは推奨されません。</span><span class="sxs-lookup"><span data-stu-id="457ef-197">Titles are discouraged from using the `Chat` namespace directly.</span></span> <span data-ttu-id="457ef-198">このライブラリの機能のほとんどは `GameChat` を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="457ef-198">Most of the functionality of this library is exposed through `GameChat`.</span></span>

<span data-ttu-id="457ef-199">プレイヤーがチャット チャンネルをクリアし、新しいチャット セッションを作成するとき、セッションはミュートされていた以前のプレイヤーに関する情報を保持しません。</span><span class="sxs-lookup"><span data-stu-id="457ef-199">When a player clears a chat channel and creates a new chat session, the session does not retain information about the previous players who were muted.</span></span> <span data-ttu-id="457ef-200">タイトルは、この動作を追跡し、`ChatManager` を呼び出して、ゲームプレイ中のプレイヤーのミュート エクスペリエンスの一貫性を維持する必要があります。</span><span class="sxs-lookup"><span data-stu-id="457ef-200">The title must track this behavior and call `ChatManager` to keep the muting experience consistent for players during gameplay.</span></span>

<span data-ttu-id="457ef-201">多くのタイトルは、ブロック/ミュート状況で音声トラフィックを制限して、ネットワークを介して送信するデータを少なくすることでネットワーク運用を最適化します。</span><span class="sxs-lookup"><span data-stu-id="457ef-201">Many titles restrict voice traffic in blocking/muting situations to optimize network operation by sending less data over the network.</span></span> <span data-ttu-id="457ef-202">たとえば、プレイヤー A がプレイヤー B をブロック/ミュートして、音声トラフィックを制限しますが、タイトルはプレイヤー B からプレイヤー A への音声データの送信を停止しません。この動作の実装は完全にタイトルに委ねられます。</span><span class="sxs-lookup"><span data-stu-id="457ef-202">For example, Player A blocks/mutes Player B, restricting voice traffic, but the title does not stop the transmission of voice data from Player B to Player A. This behavior is totally up to the title to implement.</span></span> `GameChat` <span data-ttu-id="457ef-203">はこのケースを処理し、`ChatManager` に渡される場合にプレイヤー B からの音声データをブロックします。</span><span class="sxs-lookup"><span data-stu-id="457ef-203">handles the case where it blocks voice data from Player B if passed into `ChatManager`.</span></span>


<a id="ID4ERH"></a>


### <a name="debugging-when-players-cannot-hear-each-other"></a><span data-ttu-id="457ef-204">プレイヤーが互いに聞こえない場合のデバッグ</span><span class="sxs-lookup"><span data-stu-id="457ef-204">Debugging When Players Cannot Hear Each Other</span></span>

`ChatManager` <span data-ttu-id="457ef-205"> には、`ChatManagerSettings.DiagnosticsTraceLevel` プロパティおよび `ChatManager.OnDebugMessage` イベントを使用してタイトルが有効にできるデバッグ トレースが含まれています。</span><span class="sxs-lookup"><span data-stu-id="457ef-205">includes debug traces that the title can enable, using the `ChatManagerSettings.DiagnosticsTraceLevel` property, and the `ChatManager.OnDebugMessage` event.</span></span> <span data-ttu-id="457ef-206">トレースは、問題の絞り込みに役立つ多くのコンテンツを提供します。</span><span class="sxs-lookup"><span data-stu-id="457ef-206">The traces offer much content that can help in narrowing down issues.</span></span> <span data-ttu-id="457ef-207">このコンテンツは、オーディオ デバイスの追加/変更、ローカルおよびリモート ユーザーの追加、各リモート ユーザーからの音声データの取得などから得られます。</span><span class="sxs-lookup"><span data-stu-id="457ef-207">This content comes from adding/changing audio devices, adding local and remote users, getting voice data from each remote user, and the like.</span></span>


<a id="ID4E5H"></a>


## <a name="compiling-the-gamechat-dll"></a><span data-ttu-id="457ef-208">GameChat DLL のコンパイル</span><span class="sxs-lookup"><span data-stu-id="457ef-208">Compiling the GameChat DLL</span></span>


 <span data-ttu-id="457ef-209">Microsoft.Xbox.GameChat.dll をビルドするためのソースは Xbox デベロッパー ポータルにあります。</span><span class="sxs-lookup"><span data-stu-id="457ef-209">The source for building the Microsoft.Xbox.GameChat.dll is available on Xbox Developer Portal.</span></span> <span data-ttu-id="457ef-210">デベロッパーは、このソースをコンパイルして `GameChat` のカスタマイズ バージョンを作成できます。</span><span class="sxs-lookup"><span data-stu-id="457ef-210">Developers can compile this source to create a customized version of `GameChat`.</span></span> <span data-ttu-id="457ef-211">一般的なカスタマイズでは、オーディオ データを転送するためのカスタム ネットワーク チャンネルを作成します。</span><span class="sxs-lookup"><span data-stu-id="457ef-211">A typical customization is to create a custom network channel for transmitting the audio data.</span></span>
