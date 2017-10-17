---
title: Game Chat overview
author: KevinAsgari
description: Learn how to add voice communication to your game by using Xbox Live Game Chat.
ms.assetid: 8ef6a578-e911-4006-ac4e-94d3f2fedb98
ms.author: kevinasg
ms.date: 04-04-2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: xbox live, xbox, games, uwp, windows 10, xbox one
ms.openlocfilehash: 482cba7c08877488d8ef00cad38698039e2cac8d
ms.sourcegitcommit: 698650216533c20cb7b9773bb51ece9b5ef7d761
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/25/2017
---
# <a name="game-chat-overview"></a><span data-ttu-id="45080-104">Game Chat overview</span><span class="sxs-lookup"><span data-stu-id="45080-104">Game Chat overview</span></span>

 <span data-ttu-id="45080-105">Game chat is a technology that you can use to enable voice communications between users of a single title on remote consoles.</span><span class="sxs-lookup"><span data-stu-id="45080-105">Game chat is a technology that you can use to enable voice communications between users of a single title on remote consoles.</span></span> <span data-ttu-id="45080-106">It does not include wider independent communication among console users.</span><span class="sxs-lookup"><span data-stu-id="45080-106">It does not include wider independent communication among console users.</span></span>

 > [!Note]
 > <span data-ttu-id="45080-107">新しいタイトルでは、ゲーム チャットの代わりに[ゲーム チャット 2](game-chat-2-overview.md) を使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="45080-107">New titles should use [Game Chat 2](game-chat-2-overview.md) instead of Game Chat.</span></span> <span data-ttu-id="45080-108">元のゲーム チャットは、2017 年末までに廃止される予定です。</span><span class="sxs-lookup"><span data-stu-id="45080-108">The original Game Chat will be deprecated before the end of 2017.</span></span>

 <span data-ttu-id="45080-109">Xbox One には、ハードウェア アクセラレーションに対応した専用のボイス チャット コーデックが用意されています。このコーデックはエンコードとデコードに使用され、`Microsoft.Xbox.GameChat` 名前空間を通じて公開されます。</span><span class="sxs-lookup"><span data-stu-id="45080-109">Xbox One has a specialized, hardware-accelerated voice chat codec that is used for encode and decode, and is exposed through the `Microsoft.Xbox.GameChat` Namespace.</span></span> <span data-ttu-id="45080-110">This codec supports several quality settings for title networking bandwidth flexibility, and its use is required for all voice chat communications transmitted by the console.</span><span class="sxs-lookup"><span data-stu-id="45080-110">This codec supports several quality settings for title networking bandwidth flexibility, and its use is required for all voice chat communications transmitted by the console.</span></span> <span data-ttu-id="45080-111">No other codecs are supported.</span><span class="sxs-lookup"><span data-stu-id="45080-111">No other codecs are supported.</span></span>

> <span data-ttu-id="45080-112">**Note:** A lower-level namespace called `Windows.Xbox.Chat` calls the codec.</span><span class="sxs-lookup"><span data-stu-id="45080-112">**Note:** A lower-level namespace called `Windows.Xbox.Chat` calls the codec.</span></span>

  * [<span data-ttu-id="45080-113">Game Chat Channels</span><span class="sxs-lookup"><span data-stu-id="45080-113">Game Chat Channels</span></span>](#ID4EFB)
  * [<span data-ttu-id="45080-114">Game Chat Classes</span><span class="sxs-lookup"><span data-stu-id="45080-114">Game Chat Classes</span></span>](#ID4EKC)
  * [<span data-ttu-id="45080-115">Default USB Endpoint</span><span class="sxs-lookup"><span data-stu-id="45080-115">Default USB Endpoint</span></span>](#ID4E3D)
  * [<span data-ttu-id="45080-116">Volume and Pitch</span><span class="sxs-lookup"><span data-stu-id="45080-116">Volume and Pitch</span></span>](#ID4EDE)
  * [<span data-ttu-id="45080-117">Making Users Inaudible During Game Chat</span><span class="sxs-lookup"><span data-stu-id="45080-117">Making Users Inaudible During Game Chat</span></span>](#ID4EWE)
  * [<span data-ttu-id="45080-118">Compiling the GameChat DLL</span><span class="sxs-lookup"><span data-stu-id="45080-118">Compiling the GameChat DLL</span></span>](#ID4E5H)

<a id="ID4EFB"></a>

## <a name="game-chat-channels"></a><span data-ttu-id="45080-119">Game Chat Channels</span><span class="sxs-lookup"><span data-stu-id="45080-119">Game Chat Channels</span></span>


 <span data-ttu-id="45080-120">The chat system relates local input from users rather than devices.</span><span class="sxs-lookup"><span data-stu-id="45080-120">The chat system relates local input from users rather than devices.</span></span> <span data-ttu-id="45080-121">The OS associates input devices with player IDs.</span><span class="sxs-lookup"><span data-stu-id="45080-121">The OS associates input devices with player IDs.</span></span> <span data-ttu-id="45080-122">One of the key features is support for multiple channels.</span><span class="sxs-lookup"><span data-stu-id="45080-122">One of the key features is support for multiple channels.</span></span> <span data-ttu-id="45080-123">A game might have a lobby, a user might join a team, and there might be a command structure within the team.</span><span class="sxs-lookup"><span data-stu-id="45080-123">A game might have a lobby, a user might join a team, and there might be a command structure within the team.</span></span> <span data-ttu-id="45080-124">Users can be active in multiple channels at the same time as the game permits.</span><span class="sxs-lookup"><span data-stu-id="45080-124">Users can be active in multiple channels at the same time as the game permits.</span></span> <span data-ttu-id="45080-125">For example, a game might have the following channels:</span><span class="sxs-lookup"><span data-stu-id="45080-125">For example, a game might have the following channels:</span></span>

  * <span data-ttu-id="45080-126">Red team squad 1 channel &ndash; open communication among all red team players on squad 1.</span><span class="sxs-lookup"><span data-stu-id="45080-126">Red team squad 1 channel &ndash; open communication among all red team players on squad 1.</span></span>
  * <span data-ttu-id="45080-127">Red team squad 2 channel &ndash; open communication among all red team players on squad 2.</span><span class="sxs-lookup"><span data-stu-id="45080-127">Red team squad 2 channel &ndash; open communication among all red team players on squad 2.</span></span>

<span data-ttu-id="45080-128">**Figure 1.**&nbsp;&nbsp;**Standard chat channel.**</span><span class="sxs-lookup"><span data-stu-id="45080-128">**Figure 1.**&nbsp;&nbsp;**Standard chat channel.**</span></span>

![](../../images/chat/gamechat_standard.png)

  *  <span data-ttu-id="45080-129">Red team command channel &ndash; listen-only channel for all red team non-command players.</span><span class="sxs-lookup"><span data-stu-id="45080-129">Red team command channel &ndash; listen-only channel for all red team non-command players.</span></span> <span data-ttu-id="45080-130">This channel can duck all other "red team" channels.</span><span class="sxs-lookup"><span data-stu-id="45080-130">This channel can duck all other "red team" channels.</span></span> <span data-ttu-id="45080-131">Speak-only channel for red team commanders that is enabled with push-to-talk.</span><span class="sxs-lookup"><span data-stu-id="45080-131">Speak-only channel for red team commanders that is enabled with push-to-talk.</span></span>

<span data-ttu-id="45080-132">**Figure 2.**&nbsp;&nbsp;**Command chat channel.**</span><span class="sxs-lookup"><span data-stu-id="45080-132">**Figure 2.**&nbsp;&nbsp;**Command chat channel.**</span></span>

![](../../images/chat/gamechat_command.png)

  * <span data-ttu-id="45080-133">Blue team channels as above.</span><span class="sxs-lookup"><span data-stu-id="45080-133">Blue team channels as above.</span></span>



> <span data-ttu-id="45080-134">**Note:** *Ducking* is a chat term meaning the reduction in level of one audio signal in the presence of another signal.</span><span class="sxs-lookup"><span data-stu-id="45080-134">**Note:** *Ducking* is a chat term meaning the reduction in level of one audio signal in the presence of another signal.</span></span> <span data-ttu-id="45080-135">For example, in radio, a music track's volume is lowered (ducked) while a presenter makes an announcement.</span><span class="sxs-lookup"><span data-stu-id="45080-135">For example, in radio, a music track's volume is lowered (ducked) while a presenter makes an announcement.</span></span>



 <span data-ttu-id="45080-136">In standard chat between users, the channels are bidirectional so that the users can both listen and talk on their associated channels.</span><span class="sxs-lookup"><span data-stu-id="45080-136">In standard chat between users, the channels are bidirectional so that the users can both listen and talk on their associated channels.</span></span> <span data-ttu-id="45080-137">With the command channel, the communication can either be bidirectional (as the standard channel) or can be set to unidirectional, where a user can either speak or listen on the channel, but not both.</span><span class="sxs-lookup"><span data-stu-id="45080-137">With the command channel, the communication can either be bidirectional (as the standard channel) or can be set to unidirectional, where a user can either speak or listen on the channel, but not both.</span></span> <span data-ttu-id="45080-138">Typically, for example, a commander might want to speak, with the subordinates only listening.</span><span class="sxs-lookup"><span data-stu-id="45080-138">Typically, for example, a commander might want to speak, with the subordinates only listening.</span></span> <span data-ttu-id="45080-139">The command channel is treated as having a higher priority than other channels, and will cause other channels' voices to be ducked.</span><span class="sxs-lookup"><span data-stu-id="45080-139">The command channel is treated as having a higher priority than other channels, and will cause other channels' voices to be ducked.</span></span>

 <span data-ttu-id="45080-140">Game titles can duck non-chat audio while a remote user is speaking.</span><span class="sxs-lookup"><span data-stu-id="45080-140">Game titles can duck non-chat audio while a remote user is speaking.</span></span> <span data-ttu-id="45080-141">Also properties can be set on each channel, such as volume, listen-only attributes for some users, and speak-only attributes for other users.</span><span class="sxs-lookup"><span data-stu-id="45080-141">Also properties can be set on each channel, such as volume, listen-only attributes for some users, and speak-only attributes for other users.</span></span>


<a id="ID4EKC"></a>


## <a name="game-chat-classes"></a><span data-ttu-id="45080-142">Game Chat Classes</span><span class="sxs-lookup"><span data-stu-id="45080-142">Game Chat Classes</span></span>


 <span data-ttu-id="45080-143">The namespace for game chat is `Microsoft.Xbox.GameChat`.</span><span class="sxs-lookup"><span data-stu-id="45080-143">The namespace for game chat is `Microsoft.Xbox.GameChat`.</span></span> <span data-ttu-id="45080-144">This section describes the class hierarchy of the namespace.</span><span class="sxs-lookup"><span data-stu-id="45080-144">This section describes the class hierarchy of the namespace.</span></span> <span data-ttu-id="45080-145">Refer to the `Microsoft.Xbox.GameChat` namespace documentation for a full description of each class, interface and enumeration.</span><span class="sxs-lookup"><span data-stu-id="45080-145">Refer to the `Microsoft.Xbox.GameChat` namespace documentation for a full description of each class, interface and enumeration.</span></span>

  * [<span data-ttu-id="45080-146">ChatManager</span><span class="sxs-lookup"><span data-stu-id="45080-146">ChatManager</span></span>](#ID4EYC)
  * [<span data-ttu-id="45080-147">ChatManagerSettings</span><span class="sxs-lookup"><span data-stu-id="45080-147">ChatManagerSettings</span></span>](#ID4EDD)
  * [<span data-ttu-id="45080-148">ChatUser</span><span class="sxs-lookup"><span data-stu-id="45080-148">ChatUser</span></span>](#ID4EQD)

<a id="ID4EYC"></a>


### <a name="chatmanager"></a><span data-ttu-id="45080-149">ChatManager</span><span class="sxs-lookup"><span data-stu-id="45080-149">ChatManager</span></span>


<span data-ttu-id="45080-150">The `ChatManager` class is the top-level game chat class.</span><span class="sxs-lookup"><span data-stu-id="45080-150">The `ChatManager` class is the top-level game chat class.</span></span>


<a id="ID4EDD"></a>


### <a name="chatmanagersettings"></a><span data-ttu-id="45080-151">ChatManagerSettings</span><span class="sxs-lookup"><span data-stu-id="45080-151">ChatManagerSettings</span></span>


 <span data-ttu-id="45080-152">The `ChatManagerSettings` class class represents the settings for the `ChatManager` class.</span><span class="sxs-lookup"><span data-stu-id="45080-152">The `ChatManagerSettings` class class represents the settings for the `ChatManager` class.</span></span>


<a id="ID4EQD"></a>


### <a name="chatuser"></a><span data-ttu-id="45080-153">ChatUser</span><span class="sxs-lookup"><span data-stu-id="45080-153">ChatUser</span></span>


<span data-ttu-id="45080-154">The `ChatUser` class represents a user on a channel, with a set of properties specific to the interaction of that user with other users on the same channel.</span><span class="sxs-lookup"><span data-stu-id="45080-154">The `ChatUser` class represents a user on a channel, with a set of properties specific to the interaction of that user with other users on the same channel.</span></span>



<a id="ID4E3D"></a>


## <a name="default-usb-endpoint"></a><span data-ttu-id="45080-155">Default USB Endpoint</span><span class="sxs-lookup"><span data-stu-id="45080-155">Default USB Endpoint</span></span>


 <span data-ttu-id="45080-156">The default USB capture endpoint is single channel mono.</span><span class="sxs-lookup"><span data-stu-id="45080-156">The default USB capture endpoint is single channel mono.</span></span> <span data-ttu-id="45080-157">This enables echo-cancellation to be applied to the audio stream, which is a useful feature for chat applications.</span><span class="sxs-lookup"><span data-stu-id="45080-157">This enables echo-cancellation to be applied to the audio stream, which is a useful feature for chat applications.</span></span>


<a id="ID4EDE"></a>


## <a name="volume-and-pitch"></a><span data-ttu-id="45080-158">Volume and Pitch</span><span class="sxs-lookup"><span data-stu-id="45080-158">Volume and Pitch</span></span>


<span data-ttu-id="45080-159">Volume controls in the chat system are the same as those used for XAudio2, on which the Chat API is based.</span><span class="sxs-lookup"><span data-stu-id="45080-159">Volume controls in the chat system are the same as those used for XAudio2, on which the Chat API is based.</span></span> <span data-ttu-id="45080-160">Pitch control is not supported by the chat system.</span><span class="sxs-lookup"><span data-stu-id="45080-160">Pitch control is not supported by the chat system.</span></span>

 <span data-ttu-id="45080-161">For details on XAudio2 volume settings, refer to `SetVolume`.</span><span class="sxs-lookup"><span data-stu-id="45080-161">For details on XAudio2 volume settings, refer to `SetVolume`.</span></span>

 <span data-ttu-id="45080-162">XAudio2 automatically adjusts volume levels based on the user's speaker settings to maintain a consistent volume level across configurations.</span><span class="sxs-lookup"><span data-stu-id="45080-162">XAudio2 automatically adjusts volume levels based on the user's speaker settings to maintain a consistent volume level across configurations.</span></span> <span data-ttu-id="45080-163">If the user's settings don't match their physical configuration the volume will either be too loud or too soft compared to a system with accurate settings.</span><span class="sxs-lookup"><span data-stu-id="45080-163">If the user's settings don't match their physical configuration the volume will either be too loud or too soft compared to a system with accurate settings.</span></span> <span data-ttu-id="45080-164">For example, a system configured for 5.1 surround sound speakers that only has two speakers connected will sound too soft.</span><span class="sxs-lookup"><span data-stu-id="45080-164">For example, a system configured for 5.1 surround sound speakers that only has two speakers connected will sound too soft.</span></span> <span data-ttu-id="45080-165">XAudio2 is unable to detect whether the user speaker settings correctly match their physical setup.</span><span class="sxs-lookup"><span data-stu-id="45080-165">XAudio2 is unable to detect whether the user speaker settings correctly match their physical setup.</span></span>


<a id="ID4EWE"></a>


## <a name="making-users-inaudible-during-game-chat"></a><span data-ttu-id="45080-166">Making Users Inaudible During Game Chat</span><span class="sxs-lookup"><span data-stu-id="45080-166">Making Users Inaudible During Game Chat</span></span>


<span data-ttu-id="45080-167">Xbox One supports two mechanisms to render users inaudible during game chat:</span><span class="sxs-lookup"><span data-stu-id="45080-167">Xbox One supports two mechanisms to render users inaudible during game chat:</span></span>
  * <span data-ttu-id="45080-168">Muting</span><span class="sxs-lookup"><span data-stu-id="45080-168">Muting</span></span>
  * <span data-ttu-id="45080-169">Blocking</span><span class="sxs-lookup"><span data-stu-id="45080-169">Blocking</span></span>


<a id="ID4EFF"></a>


### <a name="muting"></a><span data-ttu-id="45080-170">Muting</span><span class="sxs-lookup"><span data-stu-id="45080-170">Muting</span></span>


<span data-ttu-id="45080-171">Muting is frequently unidirectional.</span><span class="sxs-lookup"><span data-stu-id="45080-171">Muting is frequently unidirectional.</span></span> <span data-ttu-id="45080-172">That is, Player A mutes Player B, but Player B can still hear Player A. Examples of muting:</span><span class="sxs-lookup"><span data-stu-id="45080-172">That is, Player A mutes Player B, but Player B can still hear Player A. Examples of muting:</span></span>
  * <span data-ttu-id="45080-173">A title has "proximity" chat.</span><span class="sxs-lookup"><span data-stu-id="45080-173">A title has "proximity" chat.</span></span> <span data-ttu-id="45080-174">In this case, a player can hear other players who are located nearby, but players who are too far away are muted.</span><span class="sxs-lookup"><span data-stu-id="45080-174">In this case, a player can hear other players who are located nearby, but players who are too far away are muted.</span></span>
  * <span data-ttu-id="45080-175">A title offers users a player the ability to mute any/all other players.</span><span class="sxs-lookup"><span data-stu-id="45080-175">A title offers users a player the ability to mute any/all other players.</span></span>


<span data-ttu-id="45080-176">Muting is primarily implemented at the discretion of the title.</span><span class="sxs-lookup"><span data-stu-id="45080-176">Muting is primarily implemented at the discretion of the title.</span></span> <span data-ttu-id="45080-177">However, a player can also mute other players at the Xbox system level, using the gamercard or system UI.</span><span class="sxs-lookup"><span data-stu-id="45080-177">However, a player can also mute other players at the Xbox system level, using the gamercard or system UI.</span></span>


<a id="ID4EVF"></a>


### <a name="blocking"></a><span data-ttu-id="45080-178">Blocking</span><span class="sxs-lookup"><span data-stu-id="45080-178">Blocking</span></span>


> <span data-ttu-id="45080-179">**Note:** Titles do not block players.</span><span class="sxs-lookup"><span data-stu-id="45080-179">**Note:** Titles do not block players.</span></span> <span data-ttu-id="45080-180">Blocking is carried out at the Xbox system level only.</span><span class="sxs-lookup"><span data-stu-id="45080-180">Blocking is carried out at the Xbox system level only.</span></span>



<span data-ttu-id="45080-181">A game player can influence the audibility of chat directly by the use of blocking.</span><span class="sxs-lookup"><span data-stu-id="45080-181">A game player can influence the audibility of chat directly by the use of blocking.</span></span> <span data-ttu-id="45080-182">The player can block other players directly through the gamercard, or can set the voice communication and text restriction to "Block" or "Friends only".</span><span class="sxs-lookup"><span data-stu-id="45080-182">The player can block other players directly through the gamercard, or can set the voice communication and text restriction to "Block" or "Friends only".</span></span> <span data-ttu-id="45080-183">Typically blocking is bidirectional.</span><span class="sxs-lookup"><span data-stu-id="45080-183">Typically blocking is bidirectional.</span></span> <span data-ttu-id="45080-184">That is, if Player A blocks Player B, not only does Player A not hear Player B, but Player B does not hear Player A. Examples of blocking include:</span><span class="sxs-lookup"><span data-stu-id="45080-184">That is, if Player A blocks Player B, not only does Player A not hear Player B, but Player B does not hear Player A. Examples of blocking include:</span></span>
  * <span data-ttu-id="45080-185">Player has a child account and blocks all other players from access to that account.</span><span class="sxs-lookup"><span data-stu-id="45080-185">Player has a child account and blocks all other players from access to that account.</span></span>
  * <span data-ttu-id="45080-186">Player sets the account configuration to chat only with friends, and blocks non-friends.</span><span class="sxs-lookup"><span data-stu-id="45080-186">Player sets the account configuration to chat only with friends, and blocks non-friends.</span></span>
  * <span data-ttu-id="45080-187">Player A blocks Player B by flagging Player B for inappropriate behavior through reputation/feedback in the People app or through system UI.</span><span class="sxs-lookup"><span data-stu-id="45080-187">Player A blocks Player B by flagging Player B for inappropriate behavior through reputation/feedback in the People app or through system UI.</span></span>


<span data-ttu-id="45080-188">A player can also block other players by physically removing the headset and/or disabling the Kinect sensor.</span><span class="sxs-lookup"><span data-stu-id="45080-188">A player can also block other players by physically removing the headset and/or disabling the Kinect sensor.</span></span>


<a id="ID4EJG"></a>


### <a name="what-titles-should-do-to-provide-for-mutingblocking"></a><span data-ttu-id="45080-189">What Titles Should Do to Provide for Muting/Blocking</span><span class="sxs-lookup"><span data-stu-id="45080-189">What Titles Should Do to Provide for Muting/Blocking</span></span>


<span data-ttu-id="45080-190">A title provides muting through an in-game option implemented using the GameChat DLL, illustrated in the InGameChat sample.</span><span class="sxs-lookup"><span data-stu-id="45080-190">A title provides muting through an in-game option implemented using the GameChat DLL, illustrated in the InGameChat sample.</span></span> <span data-ttu-id="45080-191">The library meets all requirements for muting/blocking and no specific action is required from the title to abide by system policies.</span><span class="sxs-lookup"><span data-stu-id="45080-191">The library meets all requirements for muting/blocking and no specific action is required from the title to abide by system policies.</span></span> <span data-ttu-id="45080-192">The title must only ensure that it exposes gamercard UI that allows players to mute/block other players during chat sessions.</span><span class="sxs-lookup"><span data-stu-id="45080-192">The title must only ensure that it exposes gamercard UI that allows players to mute/block other players during chat sessions.</span></span>

 <span data-ttu-id="45080-193">To implement muting, the title calls `ChatManager.MuteUserFromAllChannels`.</span><span class="sxs-lookup"><span data-stu-id="45080-193">To implement muting, the title calls `ChatManager.MuteUserFromAllChannels`.</span></span> <span data-ttu-id="45080-194">If it must mute for all users, it calls `MuteAllUsersFromAllChannels`.</span><span class="sxs-lookup"><span data-stu-id="45080-194">If it must mute for all users, it calls `MuteAllUsersFromAllChannels`.</span></span> <span data-ttu-id="45080-195">The title can restore audibility for muted players using calls to `ChatManager.UnmuteUserFromAllChannels` or `UnmuteAllUsersFromAllChannels`, as required.</span><span class="sxs-lookup"><span data-stu-id="45080-195">The title can restore audibility for muted players using calls to `ChatManager.UnmuteUserFromAllChannels` or `UnmuteAllUsersFromAllChannels`, as required.</span></span> <span data-ttu-id="45080-196">Titles are discouraged from using the `Chat` namespace directly.</span><span class="sxs-lookup"><span data-stu-id="45080-196">Titles are discouraged from using the `Chat` namespace directly.</span></span> <span data-ttu-id="45080-197">Most of the functionality of this library is exposed through `GameChat`.</span><span class="sxs-lookup"><span data-stu-id="45080-197">Most of the functionality of this library is exposed through `GameChat`.</span></span>

<span data-ttu-id="45080-198">When a player clears a chat channel and creates a new chat session, the session does not retain information about the previous players who were muted.</span><span class="sxs-lookup"><span data-stu-id="45080-198">When a player clears a chat channel and creates a new chat session, the session does not retain information about the previous players who were muted.</span></span> <span data-ttu-id="45080-199">The title must track this behavior and call `ChatManager` to keep the muting experience consistent for players during gameplay.</span><span class="sxs-lookup"><span data-stu-id="45080-199">The title must track this behavior and call `ChatManager` to keep the muting experience consistent for players during gameplay.</span></span>

<span data-ttu-id="45080-200">Many titles restrict voice traffic in blocking/muting situations to optimize network operation by sending less data over the network.</span><span class="sxs-lookup"><span data-stu-id="45080-200">Many titles restrict voice traffic in blocking/muting situations to optimize network operation by sending less data over the network.</span></span> <span data-ttu-id="45080-201">For example, Player A blocks/mutes Player B, restricting voice traffic, but the title does not stop the transmission of voice data from Player B to Player A. This behavior is totally up to the title to implement.</span><span class="sxs-lookup"><span data-stu-id="45080-201">For example, Player A blocks/mutes Player B, restricting voice traffic, but the title does not stop the transmission of voice data from Player B to Player A. This behavior is totally up to the title to implement.</span></span> `GameChat` <span data-ttu-id="45080-202">handles the case where it blocks voice data from Player B if passed into `ChatManager`.</span><span class="sxs-lookup"><span data-stu-id="45080-202">handles the case where it blocks voice data from Player B if passed into `ChatManager`.</span></span>


<a id="ID4ERH"></a>


### <a name="debugging-when-players-cannot-hear-each-other"></a><span data-ttu-id="45080-203">Debugging When Players Cannot Hear Each Other</span><span class="sxs-lookup"><span data-stu-id="45080-203">Debugging When Players Cannot Hear Each Other</span></span>

`ChatManager` <span data-ttu-id="45080-204">includes debug traces that the title can enable, using the `ChatManagerSettings.DiagnosticsTraceLevel` property, and the `ChatManager.OnDebugMessage` event.</span><span class="sxs-lookup"><span data-stu-id="45080-204">includes debug traces that the title can enable, using the `ChatManagerSettings.DiagnosticsTraceLevel` property, and the `ChatManager.OnDebugMessage` event.</span></span> <span data-ttu-id="45080-205">The traces offer much content that can help in narrowing down issues.</span><span class="sxs-lookup"><span data-stu-id="45080-205">The traces offer much content that can help in narrowing down issues.</span></span> <span data-ttu-id="45080-206">This content comes from adding/changing audio devices, adding local and remote users, getting voice data from each remote user, and the like.</span><span class="sxs-lookup"><span data-stu-id="45080-206">This content comes from adding/changing audio devices, adding local and remote users, getting voice data from each remote user, and the like.</span></span>


<a id="ID4E5H"></a>


## <a name="compiling-the-gamechat-dll"></a><span data-ttu-id="45080-207">Compiling the GameChat DLL</span><span class="sxs-lookup"><span data-stu-id="45080-207">Compiling the GameChat DLL</span></span>


 <span data-ttu-id="45080-208">The source for building the Microsoft.Xbox.GameChat.dll is available on Xbox Developer Portal.</span><span class="sxs-lookup"><span data-stu-id="45080-208">The source for building the Microsoft.Xbox.GameChat.dll is available on Xbox Developer Portal.</span></span> <span data-ttu-id="45080-209">Developers can compile this source to create a customized version of `GameChat`.</span><span class="sxs-lookup"><span data-stu-id="45080-209">Developers can compile this source to create a customized version of `GameChat`.</span></span> <span data-ttu-id="45080-210">A typical customization is to create a custom network channel for transmitting the audio data.</span><span class="sxs-lookup"><span data-stu-id="45080-210">A typical customization is to create a custom network channel for transmitting the audio data.</span></span>
